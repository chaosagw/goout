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
  for fc in fcs:
    AddField_management(fc,"id","LONG",9)
    AddField_management(fc,"Attr01","TEXT",field_length=5)
    AddField_management(fc,"Attr02","TEXT",field_length=254)
    AddField_management(fc,"Attr03","TEXT",field_length=7)
    AddField_management(fc,"Attr04","SHORT",4)
    AddField_management(fc,"Attr05","LONG",2)
    AddField_management(fc,"Attr06","TEXT",field_length=2)
    AddField_management(fc,"Attr07","TEXT",field_length=4)
    AddField_management(fc,"Attr08","TEXT",field_length=254)
    AddField_management(fc,"Attr09","LONG",2)
    AddField_management(fc,"Attr10","LONG",4)
    AddField_management(fc,"Attr11","DOUBLE",8,1)
    AddField_management(fc,"Attr12","DOUBLE",8,1)
    AddField_management(fc,"Attr13","LONG",4)
    AddField_management(fc,"Attr14","DOUBLE",8,1)
    AddField_management(fc,"Attr15","LONG",2)
    AddField_management(fc,"Attr16","TEXT",field_length=254)
    AddField_management(fc,"Attr17","TEXT",field_length=254)
    AddField_management(fc,"Attr23","LONG",2)
    AddField_management(fc,"Attr24","DOUBLE",9,2)
    AddField_management(fc,"Attr25","DOUBLE",9,2)
    AddField_management(fc,"Attr26","DOUBLE",9,2)
    AddField_management(fc,"Attr18","TEXT",field_length=254)
    AddField_management(fc,"Attr19","TEXT",field_length=254)
    AddField_management(fc,"Attr20","TEXT",field_length=254)
    AddField_management(fc,"Attr21","TEXT",field_length=254)
    AddField_management(fc,"Attr22","TEXT",field_length=254)

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

