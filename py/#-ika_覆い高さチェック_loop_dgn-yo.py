# encoding: shift-JIS

import os, sys, glob, shutil, traceback, atexit

from arcpy import *
from arcpy.management import *

def owari():
  print (u"おわり")
  raw_input("終了するには Enter キーを押してください")

class MyExcepion(Exception): #Exceptionを継承
  def __init__(self, value):
        self.value = value
  def __str__(self):
        return repr(self.value)

#処理終了時に実行されるFuncを登録
atexit.register( owari )

in_path = sys.path[0]

#print (u'\n  接続CK....  \n')

env.overwriteOutput = True

import time
t1 = time.time()

os.chdir(in_path)
env.workspace = in_path

cads = glob.glob(in_path + os.sep + 'dgn' + os.sep + '*.dgn')
for cad in cads:
  cad_lin_dgn = cad + os.sep + "polyline"
  cad_ply_dgn = cad + os.sep + "polygon"
  cad_lin = os.path.join(in_path,"cad_l.shp")
  cad_ply = os.path.join(in_path,"cad_p.shp")
  if Exists(cad_lin): Delete(cad_lin)
  if Exists(cad_ply): Delete(cad_ply)
  query_ln =  ' "Layer" like ' + " 'LN%' "
  query_ooi =  ' "Layer" like ' + " '覆いエリア%' "
  Select_analysis(cad_lin_dgn,cad_lin,query_ln)
  Select_analysis(cad_ply_dgn,cad_ply,query_ooi)

  fname = os.path.basename(cad)[0:-4]
  print (fname + "　覆いエリアをチェックします。")
    
  try:
    tolerance = 0.01
    seed = in_path + os.sep + "work_3D.dgn"
    err_list = []
    #--------------------------------------------
    #覆いエリア高さCK
    clp_ln = os.path.join(in_path,"clp_ln.shp")
    if Exists(clp_ln): Delete(clp_ln)
    Clip_analysis(cad_lin,cad_ply,clp_ln,tolerance)
    AddField_management(clp_ln,"z","DOUBLE")
    rows3 = arcpy.da.UpdateCursor(clp_ln, ["SHAPE@","z"])
    for row3 in rows3:
      z_list2 = []
      for part in row3[0]:
        for pnt in part:
          if pnt:
            z_list2.append(pnt.Z)
      z_list2.sort()
      row3[1] = z_list2[0]
      rows3.updateRow(row3)
    ln_cent = os.path.join(in_path,"ln_cent.shp")
    if Exists(ln_cent): Delete(ln_cent)
    FeatureVerticesToPoints_management(clp_ln,ln_cent,"MID")

    rows = arcpy.da.SearchCursor(cad_ply, ["OID@","elevation","SHAPE@"])
    for row in rows:
      z_list = []
      for part in row[2]:
        for pnt in part:
          if pnt:
            z_list.append(pnt.Z)
      #z_list.reverse(key = float)
      z_list.sort(key = float,reverse = True)
      ooi_z = z_list[0]
#       print("覆いの高さ")
#       print(ooi_z)
      #print(z_list)
      ft = row[2]
      MakeFeatureLayer_management(ln_cent,"cent_tmp")
      SelectLayerByLocation_management("cent_tmp", "INTERSECT", ft, "", "NEW_SELECTION")
      rows2 = arcpy.da.SearchCursor("cent_tmp", ["OID@", "elevation", "z"])
      for row2 in rows2:
        ln_z = row2[2]
#         print(row2[0])
#         print("中心線の高さ")
#         print(ln_z)
        if ooi_z < ln_z:
          err_list.append(row[0])
          break

    MakeFeatureLayer_management(cad_ply,"ooi_tmp")
    if len(err_list) > 0:
      if len(err_list) == 1:
        err_list.append(9999)
      DeleteField_management("ooi_tmp","elevation")
      query =  ' "FID" in ' + str(tuple(err_list))
      SelectLayerByAttribute_management("ooi_tmp","NEW_SELECTION",query)
      err_ooi_shp = in_path + os.sep + "err_ooi.shp"
      err_ooi = in_path + os.sep + fname + "_覆いエリア高さエラー.dgn"
      if Exists(err_ooi_shp): Delete(err_ooi_shp)
      if Exists(err_ooi): Delete(err_ooi)
      CopyFeatures_management("ooi_tmp",err_ooi_shp)
      ExportCAD_conversion(err_ooi_shp,"DGN_V8",err_ooi,"IGNORE_FILENAMES_IN_TABLES","OVERWRITE_EXISTING_FILES",seed)
      if Exists(err_ooi_shp): Delete(err_ooi_shp)

#     #--------------------------------------------
#     #覆いエリアいるいらないCK
    SelectLayerByAttribute_management("ooi_tmp","CLEAR_SELECTION")
    SelectLayerByLocation_management("ooi_tmp","INTERSECT", cad_lin,"","NEW_SELECTION")
    SelectLayerByAttribute_management("ooi_tmp","SWITCH_SELECTION")
    cnt = int(GetCount_management("ooi_tmp").getOutput(0))
    if cnt > 0:
      err_ooi2 = in_path + os.sep + fname + "_覆いエリア過剰エラー.dgn"
      if Exists(err_ooi2): Delete(err_ooi2)
      ExportCAD_conversion("ooi_tmp","DGN_V8",err_ooi2,"IGNORE_FILENAMES_IN_TABLES","OVERWRITE_EXISTING_FILES",seed)
# 
#     #--------------------------------------------
#     #覆いエリアトンネル区切りCK
    query_tnl =  ' "Layer" like ' + " '%U1' "
    MakeFeatureLayer_management(cad_lin,"tnl_tmp",query_tnl)
    tnl_node = in_path + os.sep + "tnl_node.shp"
    if Exists(tnl_node): Delete(tnl_node)
    FeatureVerticesToPoints_management("tnl_tmp",tnl_node,"BOTH_ENDS")
    MakeFeatureLayer_management(tnl_node,"tnl_nd_tmp")
    SelectLayerByLocation_management("tnl_nd_tmp","INTERSECT", cad_ply,"0.005 Meters","NEW_SELECTION")
    SelectLayerByAttribute_management("tnl_nd_tmp","SWITCH_SELECTION")
    cnt2 = int(GetCount_management("tnl_nd_tmp").getOutput(0))
    if cnt2 > 0:
      err_ooi3 = in_path + os.sep + fname + "_トンネル区間不一致エラー.dgn"
      if Exists(err_ooi3): Delete(err_ooi3)
      tnl_node_err = 'in_memory/tnl_node_err'
      Buffer_analysis("tnl_nd_tmp",tnl_node_err,"0.5 Meters")
      ExportCAD_conversion(tnl_node_err,"DGN_V8",err_ooi3,"IGNORE_FILENAMES_IN_TABLES","OVERWRITE_EXISTING_FILES",seed)

#     #--------------------------------------------
#     #覆いエリア取得もれCK
    kbn = 'in_memory/kbn'
    kbn_diso = 'in_memory/k_diso'
    query_kbn =  ' "Layer" = ' + " '区分線' "
    Select_analysis(cad_lin_dgn,kbn,query_kbn)
    Dissolve_management(kbn,kbn_diso)

    kosa_pnt = os.path.join(in_path,"kosa_pnt.shp")
    if Exists(kosa_pnt): Delete(kosa_pnt)
    Intersect_analysis([cad_lin,cad_lin],kosa_pnt,"ALL",0.01,"point")
    MakeFeatureLayer_management(kosa_pnt,"kosa_tmp")
    SelectLayerByLocation_management("kosa_tmp","INTERSECT", kbn_diso,"0.005 Meters","NEW_SELECTION")
    DeleteFeatures_management("kosa_tmp")
    SelectLayerByLocation_management("kosa_tmp","INTERSECT", cad_ply,"0.5 Meters","NEW_SELECTION")
    DeleteFeatures_management("kosa_tmp")
    cnt3 = int(GetCount_management("kosa_tmp").getOutput(0))
    if cnt3 > 0:
      err_ooi4 = in_path + os.sep + fname + "_覆い漏れてエラー.dgn"
      if Exists(err_ooi4): Delete(err_ooi4)
      more_err = 'in_memory/more'
      Buffer_analysis("kosa_tmp",more_err,"0.5 Meters")
      DeleteIdentical_management(more_err,["Shape"],"0.5 Meters")
      ExportCAD_conversion(more_err,"DGN_V8",err_ooi4,"IGNORE_FILENAMES_IN_TABLES","OVERWRITE_EXISTING_FILES",seed)


    #--------------------------------------------------------------------------------------------------------------

    #作業ファイルお掃除
    if Exists(clp_ln): Delete(clp_ln)
    if Exists(ln_cent): Delete(ln_cent)
    if Exists(cad_lin): Delete(cad_lin)
    if Exists(cad_ply): Delete(cad_ply)
    if Exists(tnl_node): Delete(tnl_node)
    if Exists(kosa_pnt): Delete(kosa_pnt)

    Delete_management('in_memory')
    if len(glob.glob('*.xml')) > 0:
      os.system('del *.xml')
    if len(glob.glob('*エラー.prj')) > 0:
      os.system('del *エラー.prj')

  except:
    #作業ファイルお掃除
    Delete_management('in_memory')
    print (u"エラーです!")
    print (traceback.format_exc(sys.exc_info()[2]))

print ('\n 処理時間: %.1f 秒' % (time.time() - t1))
print ('\n 処理終了. \n')
