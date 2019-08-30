#coding:shift_jis
####coded by agawa####

import arcpy, os, sys, time, traceback, atexit
from arcpy import env
from arcpy import management

def owari():
  print u"おわり"
  raw_input("終了するには Enter キーを押してください")

atexit.register( owari )

try:
  # ワークスペースの設定
  env.workspace = sys.path[0]
  env.overwriteOutput = True

  inpath = sys.path[0]

  # ftのリストを取得
#   features = arcpy.ListFeatureClasses()
  ft = "D:\WS\地形分類図\清川\New File Geodatabase.gdb\清川_0612"
  # すべてのfeatureに対してループで実行

#   for ft in features:
#     print ft.encode('shift-jis') + "を処理中..."
#     result = arcpy.GetCount_management(ft)
#     if int(result.getOutput(0)) > 0:
      
#      strs = ft.split("_")
#      code = str(strs[0])
#      name =code[-3:] + strs[1].replace(".shp","")
#      new_name = code + "_" + name
      
#      arcpy.DeleteField_management(ft,["OBJECTID","種別","Shape_Leng","Shape_Area","id","Attr01","Attr02","Attr03","Attr04","Attr05","Attr06","Attr07","Attr08","Attr09","Attr10","Attr11","Attr12","Attr13","Attr14","Attr15","Attr16","Attr17","Attr23","Attr24","Attr25","Attr26","Attr18","Attr19","Attr20","Attr21","Attr22"])
#      arcpy.DeleteField_management(ft,["OBJECTID","種別","Shape_Leng","Shape_Area","id","Attr01","Attr02","Attr03","Attr04","Attr05","Attr06","Attr07","Attr08","Attr09","Attr10","Attr11","Attr12","Attr13","Attr14","Attr15","Attr16","Attr17","Attr23","Attr24","Attr25","Attr26","Attr18","Attr19","Attr20","Attr21","Attr22","Attr23","Attr24","Attr25","Attr26","Attr27","Attr28","Attr29","Attr30"])
      
#  arcpy.DeleteField_management(ft,"ORIG_FID")
  arcpy.DeleteField_management(ft,"id")
  arcpy.AddField_management(ft,"Basic","TEXT","","",90)
  arcpy.AddField_management(ft,"Slope","TEXT","","",90)
  arcpy.AddField_management(ft,"Height","TEXT","","",90)
  arcpy.AddField_management(ft,"Add","TEXT","","",90)
  arcpy.AddField_management(ft,"PrefCode","TEXT","","",2)
  arcpy.AddField_management(ft,"MapName","TEXT","","",90)
  arcpy.AddField_management(ft,"Legend","TEXT","","",90)
  arcpy.AddField_management(ft,"check1","TEXT","","",90)
  arcpy.AddField_management(ft,"old_code","TEXT","","",90)
  arcpy.AddField_management(ft,"check2","TEXT","","",90)
                   
  arcpy.CalculateField_management(ft,"old_code","!コード!","PYTHON_9.3")
  arcpy.CalculateField_management(ft,"PrefCode","'06'","PYTHON_9.3")

#       fields = ['f_name']
#       rows = arcpy.da.UpdateCursor(ft,fields)
#       for row in rows:
#           row[0] = new_name
#           rows.updateRow(row)
# 
#       del row
#       del rows

except:
  print u"エラーです!"
  print traceback.format_exc(sys.exc_info()[2])

