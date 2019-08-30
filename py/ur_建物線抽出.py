# encoding: shift-JIS

import os, sys, glob, shutil, traceback, atexit, codecs

from arcpy import *
from arcpy.management import *

def owari():
  print (u"おわり")
  raw_input("終了するには Enter キーを押してください")

#処理終了時に実行されるFuncを登録
atexit.register( owari )

in_path = sys.path[0]

print (u'\n  建物中....  \n')

env.overwriteOutput = True

import time
t1 = time.time()

os.chdir(in_path)
env.workspace = in_path

fcs = ListFeatureClasses()

try:
  
  kbn_path = "D:\WS\UR_pre\kiban\line"
  for fc in fcs:
    projection = Describe(fc).spatialReference.factoryCode
    print(fc)
    #print(projection)
    #1kei
    if projection == 6669:
      kbn = os.path.join(kbn_path,"建築物の外周線_1kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    #2kei
    elif projection == 6670:
      kbn = os.path.join(kbn_path,"建築物の外周線_2kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    #3kei
    elif projection == 6671:
      kbn = os.path.join(kbn_path,"建築物の外周線_3kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    #4kei
    elif projection == 6672:
      kbn = os.path.join(kbn_path,"建築物の外周線_4kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    #5kei
    elif projection == 6673:
      kbn = os.path.join(kbn_path,"建築物の外周線_5kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    #6kei
    elif projection == 6674:
      kbn = os.path.join(kbn_path,"建築物の外周線_6kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    #7kei
    elif projection == 6675:
      kbn = os.path.join(kbn_path,"建築物の外周線_7kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    #8kei
    elif projection == 6676:
      kbn = os.path.join(kbn_path,"建築物の外周線_8kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    #9kei
    elif projection == 6677:
      kbn = os.path.join(kbn_path,"建築物の外周線_9kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    #10kei
    elif projection == 6678:
      kbn = os.path.join(kbn_path,"建築物の外周線_10kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    #11kei
    elif projection == 6679:
      kbn = os.path.join(kbn_path,"建築物の外周線_11kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    #12kei
    elif projection == 6680:
      kbn = os.path.join(kbn_path,"建築物の外周線_12kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    #13kei
    elif projection == 6681:
      kbn = os.path.join(kbn_path,"建築物の外周線_13kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    #14kei
    elif projection == 6682:
      kbn = os.path.join(kbn_path,"建築物の外周線_14kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    #15kei
    elif projection == 6683:
      kbn = os.path.join(kbn_path,"建築物の外周線_15kei.shp")
      MakeFeatureLayer_management(kbn,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"1 Meters")
      tatemono = in_path + os.sep + "gaisyu_" + fc
      CopyFeatures("tmp_kbn",tatemono)
      SelectLayerByAttribute_management("tmp_kbn","CLEAR_SELECTION")
    else:
      print("座標系が範囲外です！")
  #merge_tmp = in_path + os.sep + "標識.shp"
#   merge_tmp = 'in_memory/merge_tmp'
#   Merge_management(cad_lins,merge_tmp)
#   query1 =  ' "Layer" like ' + " '標識%' "
#   MakeFeatureLayer_management(merge_tmp,"tmp_sign",query1)
#   query2 =  ' "Layer" like ' + " '標識_C323_V0%' "
#   SelectLayerByAttribute_management("tmp_sign","NEW_SELECTION",query2)
#   CalculateField_management("tmp_sign","Layer",'"標識_C323_V0"',"VB")
#   SelectLayerByAttribute_management("tmp_sign","CLEAR_SELECTION")
# 
#   buff = 'in_memory/buff'
#   Buffer_analysis("tmp_sign",buff,"1 Meters")
#   ol = 'in_memory/ol'
#   Intersect_analysis(buff,ol)
# 
#   dup_tbl = 'in_memory/dup_tbl'
#   FindIdentical_management(ol,dup_tbl,["Shape","Layer"],"0.01 Meters",output_record_option="ONLY_DUPLICATES")
#   rows = da.SearchCursor(dup_tbl, ['IN_FID'])
#   sel_list = []
# 
#   for row in rows:
#     sel_list.append(row[0])
# 
#   if len(sel_list) >0:
#     query3 = ' "OID" in ' + str(tuple(sel_list))
#     MakeFeatureLayer_management(ol,"tmp_ol")
#     SelectLayerByAttribute_management("tmp_ol","NEW_SELECTION",query3)
#     SelectLayerByLocation_management("tmp_sign","INTERSECT","tmp_ol")
#     err = in_path + os.sep + "標識重複エラー.dgn"
#     if Exists(err): Delete(err)
#     ExportCAD_conversion("tmp_sign","DGN_V8",err,"IGNORE_FILENAMES_IN_TABLES","OVERWRITE_EXISTING_FILES",seed)
  #--------------------------------------------
  #お掃除
#   Delete_management('in_memory')
#   if len(glob.glob('*.xml')) > 0:
#     os.system('del *.xml')

except:
  print (u"エラーです!")
  print (traceback.format_exc(sys.exc_info()[2]))

print ('\n 処理時間: %.1f 秒' % (time.time() - t1))
print ('\n 処理終了. \n')

