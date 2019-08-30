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

print (u'\n  接続CK....  \n')

env.overwriteOutput = True

import time
t1 = time.time()

os.chdir(in_path)
env.workspace = in_path

cads = glob.glob(in_path + os.sep + 'dgn' + os.sep + '*.dgn')
for cad in cads:
  cad_lin_dgn = cad + os.sep + "polyline"
  cad_lin = os.path.join(in_path,"cad_l.shp")
  if Exists(cad_lin): Delete(cad_lin)
  CopyFeatures(cad_lin_dgn,cad_lin)
  RepairGeometry_management(cad_lin,'DELETE_NULL')
  CalculateField(cad_lin,'Entity',"'" + "LineString" + "'", 'Python_9.3')
  sr =  arcpy.SpatialReference(in_path + os.sep + "prj" + os.sep + "jgd20011_1.prj")
  DefineProjection_management(cad_lin,sr)
  fname = os.path.basename(cad)[0:-4]
  print (fname + "をチェックします。")
    
  try:
    tolerance = 0.005
    query1 =  ' "Layer" like ' + " '区分線%' "
    seed = in_path + os.sep + "work_3D.dgn"
  
    #--------------------------------------------
    kubun = os.path.join(in_path,"kubun.shp")
    kubun_diso = os.path.join(in_path,"kubun_diso.shp")
    if Exists(kubun): Delete(kubun)
    if Exists(kubun_diso): Delete(kubun_diso)
    Select_analysis(cad_lin,kubun,query1)
    DefineProjection_management(kubun,sr)
    Dissolve_management(kubun,kubun_diso)
  
    #query2 = ' "Layer" not like ' + " '区分線%' "
    query2 = ' "Layer" like ' + " 'LN%' " + ' or ' + ' "Layer" like ' + " '境界%' " + ' or ' + ' "Layer" like ' + " '区画%' "
    sonota_l = os.path.join(in_path,"sonota_l.shp")
    if Exists(sonota_l): Delete(sonota_l)
    Select_analysis(cad_lin,sonota_l,query2)
    nodes = os.path.join(in_path,"nodes.shp")
    if Exists(nodes): Delete(nodes)
    dup_nodes_tbl = 'in_memory/dup_nodes_tbl'
    FeatureVerticesToPoints_management(sonota_l,nodes,"BOTH_ENDS")
    FindIdentical_management(nodes,dup_nodes_tbl,["Shape"],tolerance,output_record_option="ONLY_DUPLICATES")
    #FindIdentical_management(nodes,dup_nodes_tbl,["Shape","Layer"],tolerance,output_record_option="ONLY_DUPLICATES")
    MakeFeatureLayer_management(nodes,"tmp_nodes")
    #dup_nodes2 = os.path.join(in_path,'dup_nodes2.shp')
    dup_nodes2 = 'in_memory/dup_nodes2'
    if Exists(dup_nodes2): Delete(dup_nodes2)
    FeatureVerticesToPoints_management(sonota_l,dup_nodes2,"BOTH_ENDS")
    
    print ("端点を準備中...")
    rows = da.SearchCursor(dup_nodes_tbl, ['IN_FID'])
    sel_list = []
    for row in rows:
      sel_list.append(row[0])
    if len(sel_list) == 1:
      sel_list.append(99999)
    if len(sel_list) == 0:
      sel_list.append(99998)
      sel_list.append(99999)

    query3 =  ' "FID" in ' + str(tuple(sel_list))
    SelectLayerByAttribute_management("tmp_nodes","NEW_SELECTION",query3)
    dup_nodes = os.path.join(in_path,"dup_nodes.shp")
    if Exists(dup_nodes): Delete(dup_nodes)
    CopyFeatures("tmp_nodes",dup_nodes)
    DeleteIdentical_management(dup_nodes,["Shape"],tolerance)
    query5 = ' "Layer" like ' + " '区画%' "
    kukaku_nodes3 = os.path.join(in_path,"kukaku_nodes3.shp")
    if Exists(kukaku_nodes3): Delete(kukaku_nodes3)
    Select_analysis(dup_nodes,kukaku_nodes3,query5)
    kukaku = os.path.join(in_path,"kukaku.shp")
    if Exists(kukaku): Delete(kukaku)
    Select_analysis(cad_lin,kukaku,query5)
    kukaku_nodes3_sj = os.path.join(in_path,"kukaku_nodes3_sj.shp")
    if Exists(kukaku_nodes3_sj): Delete(kukaku_nodes3_sj)
    SpatialJoin_analysis(kukaku_nodes3,kukaku,kukaku_nodes3_sj,"JOIN_ONE_TO_ONE","KEEP_ALL","#","INTERSECT",0.01)
    query_sel = ' "Join_Count" > ' + " 2 "
    MakeFeatureLayer_management(kukaku_nodes3_sj,"tmp_kukaku_nd",query_sel)
    
    #--------------------------------------------------------------------------------------------------------------

    print ("区分線が無い箇所で切れているかチェック...")
    err_tmp = os.path.join(in_path,"err_tmp.shp")
    if Exists(err_tmp): Delete(err_tmp)
    MakeFeatureLayer_management(kubun_diso,"tmp_kubun")
    #print "1"
    MakeFeatureLayer_management(dup_nodes,"tmp_dup_nodes")
    #kubun_buff = 'in_memory/kubun_buff'
    kubun_buff = os.path.join(in_path,"kubun_buff.shp")
    Buffer_analysis(kubun_diso,kubun_buff,0.01)
    SelectLayerByLocation_management("tmp_dup_nodes","INTERSECT",kubun_buff)
    DeleteFeatures_management("tmp_dup_nodes")
    #print "7"
    #SelectLayerByAttribute_management("tmp_dup_nodes","SWITCH_SELECTION")
    #print "8"
    err_pnt = in_path + os.sep + fname + "_区分線無いのに切れてるエラー.dgn"
    if Exists(err_pnt): Delete(err_pnt)
    #cnt_n = int(GetCount_management("tmp_dup_nodes").getOutput(0))
    #print cnt_n
    #CalculateField_management("tmp_dup_nodes","LineWt",10,"VB")
    err_pnt_shp = in_path + os.sep + "err.shp"
    if Exists(err_pnt_shp): Delete(err_pnt_shp)
    err_circle_shp = in_path + os.sep + "err_circle.shp"
    if Exists(err_circle_shp): Delete(err_circle_shp)
    CopyFeatures_management("tmp_dup_nodes",err_pnt_shp)
    RepairGeometry_management(err_pnt_shp)
    flds = ListFields(err_pnt_shp)
    AddField_management(err_pnt_shp,"err","SHORT")
    def_flds = ["FID","Shape"]
    for fld in flds:
      if not fld.name in def_flds:
        DeleteField_management(err_pnt_shp,fld.name)
    #err_sj = os.path.join(in_path,"err_sj.shp")
    err_sj = 'in_memory/err_sj'
    SpatialJoin_analysis(err_pnt_shp,sonota_l,err_sj,"JOIN_ONE_TO_ONE","KEEP_ALL","#","INTERSECT",0.01)
    AddField_management(err_sj,"Layer","TEXT")
    CalculateField(err_sj,'Layer',"'" + "区分線無いのに切れてる" + "'", 'Python_9.3')
    Buffer_analysis(err_sj,err_circle_shp,0.5)
    query_sj = ' "Join_Count" > ' + " 1 "
    #2本のラインの接続箇所のみエラーにする
    MakeFeatureLayer_management(err_circle_shp,"tmp_esj",query_sj)
    SelectLayerByLocation_management("tmp_esj","INTERSECT","tmp_kukaku_nd",0.01)
    DeleteFeatures_management("tmp_esj")
    cnt_n = int(GetCount_management("tmp_esj").getOutput(0))
    if cnt_n > 0:
      ExportCAD_conversion("tmp_esj","DGN_V8",err_pnt,"IGNORE_FILENAMES_IN_TABLES","OVERWRITE_EXISTING_FILES",seed)
    
    #--------------------------------------------------------------------------------------------------------------
    #区分線のノードと一致しないその他ラインのノードを抽出
    print ("区分線があるのに切れてないチェック...")
    query_kkk = ' "Layer" like ' + " '境界%' "
    kukaku_l = os.path.join(in_path,"kukaku_l.shp")
    err_tmp2 = os.path.join(in_path,"err_tmp2.shp")
    kubun_diso2 = os.path.join(in_path,"kubun_diso2.shp")
    kubun_node = os.path.join(in_path,"kubun_nd.shp")
    kubun_node2 = os.path.join(in_path,"kubun_nd2.shp")

    if Exists(kukaku_l): Delete(kukaku_l)
    if Exists(err_tmp2): Delete(err_tmp2)
    if Exists(kubun_diso2): Delete(kubun_diso2)
    if Exists(kubun_node): Delete(kubun_node)
    if Exists(kubun_node2): Delete(kubun_node2)

    FeatureVerticesToPoints_management(kubun,kubun_node2,"BOTH_ENDS")
    MakeFeatureLayer_management(kubun_node2,"tmp_kubun_node2")
    SelectLayerByLocation_management("tmp_kubun_node2","INTERSECT",dup_nodes2,0.005)
    DeleteFeatures_management("tmp_kubun_node2")


    Select_analysis(cad_lin,kukaku_l,query_kkk)
    Dissolve_management(kubun,kubun_diso2,"","","SINGLE_PART")
    FeatureVerticesToPoints_management(kubun_diso2,kubun_node,"BOTH_ENDS")
    MakeFeatureLayer_management(kubun_node,"tmp_kubun_node")
    SelectLayerByLocation_management("tmp_kubun_node","INTERSECT",kukaku_l,0.0001)
    #SelectLayerByAttribute_management("tmp_kubun_node","SWITCH_SELECTION")
    DeleteFeatures_management("tmp_kubun_node")
    AddField_management("tmp_kubun_node","Elevation","DOUBLE")
    rows = arcpy.da.UpdateCursor("tmp_kubun_node", ["SHAPE@Z","Elevation"])
    for row in rows:
      row[1] = row[0]
      rows.updateRow(row)

  
    f_count = int(GetCount_management("tmp_kubun_node2").getOutput(0))
    f_count2 = int(GetCount_management("tmp_kubun_node").getOutput(0))
    
    if f_count > 0:
      err_tmp_circle = 'in_memory/err_tmp_circle'
      if Exists(err_tmp2): Delete(err_tmp2)
      if Exists(err_tmp_circle): Delete(err_tmp_circle)
      err_pnt2 = in_path + os.sep + fname + "_区分線があるのに切れてないエラー.dgn"
      if Exists(err_pnt2): Delete(err_pnt2)
      #CalculateField_management(err_tmp2,"LineWt",10,"VB")
      Buffer_analysis("tmp_kubun_node2",err_tmp_circle,0.5)
      AddField_management(err_tmp_circle,"Layer","TEXT")
      CalculateField(err_tmp_circle,'Layer',"'" + "区分線あるのに切れてない" + "'", 'Python_9.3')
      ExportCAD_conversion(err_tmp_circle,"DGN_V8",err_pnt2,"IGNORE_FILENAMES_IN_TABLES","OVERWRITE_EXISTING_FILES",seed)
    if f_count2 > 0:
      #print (f_count2)
      err_pnt3 = in_path + os.sep + fname + "_区分線が届いてないエラー.dgn"
      tmp_kubun_circle = 'in_memory/err_circle'
      if Exists(err_pnt3): Delete(err_pnt3)
      if Exists(tmp_kubun_circle): Delete(tmp_kubun_circle)
      DeleteField_management("tmp_kubun_node",["LineWt"])
      Buffer_analysis("tmp_kubun_node",tmp_kubun_circle,0.5)
      AddField_management(tmp_kubun_circle,"Layer","TEXT")
      CalculateField(tmp_kubun_circle,'Layer',"'" + "区分線が届いてない" + "'", 'Python_9.3')
      ExportCAD_conversion(tmp_kubun_circle,"DGN_V8",err_pnt3,"IGNORE_FILENAMES_IN_TABLES","OVERWRITE_EXISTING_FILES",seed)
      #print ("err3")
  
    #--------------------------------------------------------------------------------------------------------------

    print ("線の向きチェック...")
    MakeFeatureLayer_management(sonota_l,"tmp_sonota",query2)
    query_bnd = ' "Layer" like ' + " '境界%' "
    MakeFeatureLayer_management(cad_lin,"tmp_bnd",query_bnd)
  
    pnt_s = 'in_memory/p_start'
    pnt_e = 'in_memory/p_end'
    #pnt_nd = in_path + os.sep + "p_nd.shp"
    pnt_nd = 'in_memory/p_nd'
    #ok_err = in_path + os.sep + "okerr.shp"
    ok_err = 'in_memory/ok_e'
    #no_ok_err = in_path + os.sep + "Nokerr.shp"
    no_ok_err = 'in_memory/n_ok_e'

    FeatureVerticesToPoints_management("tmp_sonota",pnt_s,"START")
    FeatureVerticesToPoints_management("tmp_sonota",pnt_e,"END")
    FeatureVerticesToPoints_management("tmp_bnd",pnt_nd,"BOTH_ENDS")

    DeleteIdentical_management(pnt_nd,["Shape","Layer"])
    del_bnd_nd_tbl = 'in_memory/del_bnd_nd_tbl'
    FindIdentical_management(pnt_nd,del_bnd_nd_tbl,["Shape"],tolerance,output_record_option="ONLY_DUPLICATES")
    rows_nd = da.SearchCursor(del_bnd_nd_tbl, ['IN_FID'])
    sel_list_nd = []
    #print("tbl")
    for row_nd in rows_nd:
      sel_list_nd.append(row_nd[0])
    if len(sel_list_nd) == 1:
      sel_list_nd.append(99999)
    if len(sel_list_nd) == 0:
      sel_list_nd.append(99998)
      sel_list_nd.append(99999)
    query_nd =  ' "FID" in ' + str(tuple(sel_list_nd))
    #print("OKEｒｒ")
    #OKエラーから境界と仮想境界の接続箇所を削除
    Select_analysis(pnt_nd,ok_err,query_nd)
    query_no = ' "Layer" like ' + " '%K1' "
    Select_analysis(ok_err,no_ok_err,query_no)
    MakeFeatureLayer_management(ok_err,"ok_err")
    SelectLayerByLocation_management("ok_err","INTERSECT",no_ok_err,0.01)
    DeleteFeatures_management("ok_err")

    AddField_management(pnt_s,"kind","TEXT")
    AddField_management(pnt_e,"kind","TEXT")
  
    rows_s = da.UpdateCursor(pnt_s, ['kind'])
    for row_s in rows_s:
      row_s[0] = "s"
      rows_s.updateRow(row_s)
    rows_e = da.UpdateCursor(pnt_e, ['kind'])
    for row_e in rows_e:
      row_e[0] = "e"
      rows_e.updateRow(row_e)
    node_merge = in_path + os.sep + 'node_merge.shp'
    #node_merge = 'in_memory/node_merge'
    if Exists(node_merge): Delete(node_merge)
    Merge_management([pnt_s,pnt_e],node_merge)
    MakeFeatureLayer_management(node_merge,"node_del")
    mNode_tbl = 'in_memory/mNode_tbl'
    FindIdentical_management(node_merge,mNode_tbl,["Shape"],tolerance,output_record_option="ONLY_DUPLICATES")
  
    rows_m = da.SearchCursor(mNode_tbl, ['IN_FID'])
    sel_list_m = []
    for row_m in rows_m:
      sel_list_m.append(row_m[0])
    if len(sel_list_m) == 1:
      sel_list_m.append(99999)
    if len(sel_list_m) == 0:
      sel_list_m.append(99998)
      sel_list_m.append(99999)
    query_m =  ' "FID" in ' + str(tuple(sel_list_m))
    SelectLayerByAttribute_management("node_del","NEW_SELECTION",query_m)
    SelectLayerByAttribute_management("node_del","SWITCH_SELECTION")
    DeleteFeatures_management("node_del")

    #print("エラー出力")

    #Append_management(pnt_e,pnt_s,"TEST")
    #CopyFeatures(pnt_s,in_path + os.sep + "pnt_s.shp")
    #node_buff = in_path + os.sep + 'node_buff.shp'
    node_buff = 'in_memory/node_buff'
    Buffer_analysis(node_merge,node_buff,tolerance)
    node_diso = 'in_memory/node_diso'
    #print("dissolve")
    #Dissolve_management(node_buff,node_diso,["kind"],"","SINGLE_PART")
    DeleteIdentical_management(node_buff,["Shape","kind"])
    seNode_tbl = 'in_memory/seNode_tbl'
    #print("FindIdentical")
    FindIdentical_management(node_buff,seNode_tbl,["Shape"],tolerance,output_record_option="ONLY_DUPLICATES")
    #print("MakeFeatureLayer")
    MakeFeatureLayer_management(node_buff,"tmp_node_diso")
  
    f_count1 = int(GetCount_management("tmp_node_diso").getOutput(0))
    #print(f_count1)

    rows3 = da.SearchCursor(seNode_tbl, ['IN_FID'])
    sel_list_se = []
    for row3 in rows3:
      sel_list_se.append(row3[0])
    if len(sel_list_se) == 1:
      sel_list_se.append(99999)
    if len(sel_list_se) == 0:
      sel_list_se.append(99998)
      sel_list_se.append(99999)
    query4 =  ' "FID" in ' + str(tuple(sel_list_se))
    SelectLayerByAttribute_management("tmp_node_diso","NEW_SELECTION",query4)
    SelectLayerByAttribute_management("tmp_node_diso","SWITCH_SELECTION")
  
    f_count2 = int(GetCount_management("tmp_node_diso").getOutput(0))
    err_nodes_circle = in_path + os.sep + 'err_nodes_circle.shp'

    if f_count2 < f_count1:
      #print("エラーあり")
      if Exists(err_nodes_circle): Delete(err_nodes_circle)
      Buffer_analysis("tmp_node_diso",err_nodes_circle,0.5)
      MakeFeatureLayer_management(err_nodes_circle,"tmp_ec")
      SelectLayerByLocation_management("tmp_ec","INTERSECT",ok_err,0.01,"NEW_SELECTION")
      DeleteFeatures_management("tmp_ec")
      err_pnt3 = in_path + os.sep + fname + "_線の方向エラー.dgn"
      if Exists(err_pnt3): Delete(err_pnt3)
      #CalculateField_management(err_nodes_pnt,"LineWt",10,"VB")
      DeleteField_management(err_nodes_circle,["LineWt"])
      AddField_management(err_nodes_circle,"Layer","TEXT")
      CalculateField(err_nodes_circle,'Layer',"'" + "線の方向" + "'", 'Python_9.3')
      f_count3 = int(GetCount_management(err_nodes_circle).getOutput(0))
      #print("線の向き終了")
      if f_count3 > 0:
        ExportCAD_conversion(err_nodes_circle,"DGN_V8",err_pnt3,"IGNORE_FILENAMES_IN_TABLES","OVERWRITE_EXISTING_FILES",seed)
        #print("線の向きエラー出力")

    
    #--------------------------------------------------------------------------------------------------------------

    print ("線の途中接続チェック... \n")
    sj = 'in_memory/sj'
    #sj_err = 'in_memory/sj_err'
    #端点
    nodes2 = os.path.join(in_path,"nodes2.shp")
    if Exists(nodes2): Delete(nodes2)
    MakeFeatureLayer_management(sonota_l,"tmp_sonota",query2)
    FeatureVerticesToPoints_management("tmp_sonota",nodes2,"BOTH_ENDS")
    MakeFeatureLayer_management(nodes2,"tmp_nodes2")
    node_del_tbl = 'in_memory/node_del_tbl'
    FindIdentical_management("tmp_nodes2",node_del_tbl,["Shape"],tolerance,output_record_option="ONLY_DUPLICATES")
    node_del_lst = []
    rows_lst = da.SearchCursor(node_del_tbl, ['IN_FID'])
    for row_lst in rows_lst:
      node_del_lst.append(row_lst[0])
    if len(node_del_lst) == 1:
      node_del_lst.append(99999)
    if len(node_del_lst) == 0:
      node_del_lst.append(99998)
      node_del_lst.append(99999)
    query_del_n =  ' "FID" in ' + str(tuple(node_del_lst))
    SelectLayerByAttribute_management("tmp_nodes2","NEW_SELECTION",query_del_n)
    DeleteFeatures_management("tmp_nodes2")

    SpatialJoin_analysis("tmp_nodes2",sonota_l,sj,"JOIN_ONE_TO_ONE","KEEP_ALL","#","INTERSECT",tolerance)
    MakeFeatureLayer_management(sj,"tmp_sj")
    query_sj = ' "Join_Count" > 1 '
    SelectLayerByAttribute_management("tmp_sj","NEW_SELECTION",query_sj)
    err_pnt4 = in_path + os.sep + fname + "_途中接続エラー.dgn"
    err_pnt4_shp = in_path + os.sep + "err4.shp"
    err_pnt4_circle = in_path + os.sep + "err4_circle.shp"
    if Exists(err_pnt4): Delete(err_pnt4)
    if Exists(err_pnt4_shp): Delete(err_pnt4_shp)
    if Exists(err_pnt4_circle): Delete(err_pnt4_circle)
    cnt_sj = int(GetCount_management("tmp_sj").getOutput(0))
    #print cnt_sj
    if cnt_sj > 0:
      CopyFeatures_management("tmp_sj",err_pnt4_shp)
      flds = ListFields(err_pnt4_shp)
      AddField_management(err_pnt4_shp,"err","SHORT")
      def_flds = ["FID","Shape"]
      for fld in flds:
        #print fld.name
        if not fld.name in def_flds:
          DeleteField_management(err_pnt4_shp,fld.name)
      Buffer_analysis(err_pnt4_shp,err_pnt4_circle,0.5)
      AddField_management(err_pnt4_circle,"Layer","TEXT")
      CalculateField(err_pnt4_circle,'Layer',"'" + "途中接続" + "'", 'Python_9.3')
      ExportCAD_conversion(err_pnt4_circle,"DGN_V8",err_pnt4,"IGNORE_FILENAMES_IN_TABLES","OVERWRITE_EXISTING_FILES",seed)
      
    #--------------------------------------------------------------------------------------------------------------
    print ("中心線切れてるのに同じ属性チェック... \n")
    nodes3 = 'in_memory/nodes3'
    if Exists(nodes3): Delete(nodes3)
    query3 = ' "Layer" like ' + " 'LN%' "
    MakeFeatureLayer_management(sonota_l,"tmp_lane",query3)
    FeatureVerticesToPoints_management("tmp_lane",nodes3,"BOTH_ENDS")
    MakeFeatureLayer_management(nodes3,"tmp_nodes3")
    node_del_tbl3 = 'in_memory/node_del_tbl3'
    FindIdentical_management("tmp_nodes3",node_del_tbl3,["Shape","Layer"],tolerance,output_record_option="ONLY_DUPLICATES")
    node_del_lst3 = []
    rows_lst3 = da.SearchCursor(node_del_tbl3, ['IN_FID'])
    for row_lst3 in rows_lst3:
      node_del_lst3.append(row_lst3[0])
    if len(node_del_lst3) == 1:
      node_del_lst3.append(99999)
    if len(node_del_lst3) == 0:
      node_del_lst3.append(99998)
      node_del_lst3.append(99999)
    query_sel_nd =  ' "FID" in ' + str(tuple(node_del_lst3))
    SelectLayerByAttribute_management("tmp_nodes3","NEW_SELECTION",query_sel_nd)

    err_pnt5 = in_path + os.sep + fname + "_中心線同じ属性エラー.dgn"
    err_pnt5_circle = 'in_memory/err_pnt5_cl'
    if Exists(err_pnt5): Delete(err_pnt5)
    cnt_e5 = int(GetCount_management("tmp_nodes3").getOutput(0))
    #print(cnt_e5)
    if cnt_e5 > 0:
      Buffer_analysis("tmp_nodes3",err_pnt5_circle,0.5)
      #AddField_management(err_pnt5_circle,"Layer","TEXT")
      DeleteIdentical_management(err_pnt5_circle,["Shape"],tolerance)
      CalculateField(err_pnt5_circle,'Layer',"'" + "中心線切れてるけど同じ属性" + "'", 'Python_9.3')
      ExportCAD_conversion(err_pnt5_circle,"DGN_V8",err_pnt5,"IGNORE_FILENAMES_IN_TABLES","OVERWRITE_EXISTING_FILES",seed)
    #--------------------------------------------------------------------------------------------------------------

    #作業ファイルお掃除
    Delete_management('in_memory')
    if Exists(kukaku): Delete(kukaku)
    if Exists(kukaku_nodes3_sj): Delete(kukaku_nodes3_sj)
    if Exists(kukaku_nodes3): Delete(kukaku_nodes3)
    if Exists(kubun): Delete(kubun)
    if Exists(kubun_diso): Delete(kubun_diso)
    if Exists(sonota_l): Delete(sonota_l)
    if Exists(nodes): Delete(nodes)
    if Exists(kubun_buff): Delete(kubun_buff)
    if Exists(dup_nodes): Delete(dup_nodes)
    if Exists(err_tmp): Delete(err_tmp)
    if Exists(cad_lin): Delete(cad_lin)
    if Exists(err_pnt_shp): Delete(err_pnt_shp)
    if Exists(err_circle_shp): Delete(err_circle_shp)
    if Exists(err_pnt4_shp): Delete(err_pnt4_shp)
    if Exists(err_pnt4_circle): Delete(err_pnt4_circle)
    if Exists(kubun_diso2): Delete(kubun_diso2)
    if Exists(kubun_node): Delete(kubun_node)
    if Exists(kukaku_l): Delete(kukaku_l)
    if Exists(nodes2): Delete(nodes2)
    if Exists(node_merge): Delete(node_merge)
    if Exists(err_nodes_circle): Delete(err_nodes_circle)
    if Exists(kubun_node2): Delete(kubun_node2)
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
