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
  features = arcpy.ListFeatureClasses()

  # すべてのfeatureに対してループで実行

  for ft in features:
    print ft.encode('shift-jis') + "を処理中..."
    result = arcpy.GetCount_management(ft)
    if int(result.getOutput(0)) > 0:
      
      strs = ft.split("_")
      code = str(strs[0])
      name =code[-3:] + strs[1].replace(".shp","")
#      new_name = code + "_" + name
      
#      arcpy.DeleteField_management(ft,["OBJECTID","種別","Shape_Leng","Shape_Area","id","Attr01","Attr02","Attr03","Attr04","Attr05","Attr06","Attr07","Attr08","Attr09","Attr10","Attr11","Attr12","Attr13","Attr14","Attr15","Attr16","Attr17","Attr23","Attr24","Attr25","Attr26","Attr18","Attr19","Attr20","Attr21","Attr22"])
      arcpy.DeleteField_management(ft,["OBJECTID","種別","Shape_Leng","Shape_Area","id","Attr01","Attr02","Attr03","Attr04","Attr05","Attr06","Attr07","Attr08","Attr09","Attr10","Attr11","Attr12","Attr13","Attr14","Attr15","Attr16","Attr17","Attr23","Attr24","Attr25","Attr26","Attr18","Attr19","Attr20","Attr21","Attr22","Attr23","Attr24","Attr25","Attr26","Attr27","Attr28","Attr29","Attr30"])
      arcpy.AddField_management(ft,"id","LONG",9)
      arcpy.AddField_management(ft,"Attr01","TEXT","","",5)
      arcpy.AddField_management(ft,"Attr02","TEXT","","",6)
      arcpy.AddField_management(ft,"Attr03","LONG",1)
      arcpy.AddField_management(ft,"Attr04","TEXT","","",254)
      arcpy.AddField_management(ft,"Attr05","TEXT","","",7)
      arcpy.AddField_management(ft,"Attr06","LONG",4)
      arcpy.AddField_management(ft,"Attr07","LONG",2)
      arcpy.AddField_management(ft,"Attr08","TEXT","","",2)
      arcpy.AddField_management(ft,"Attr09","TEXT","","",4)
      arcpy.AddField_management(ft,"Attr10","TEXT","","",254)
      arcpy.AddField_management(ft,"Attr11","LONG",2)
      arcpy.AddField_management(ft,"Attr12","LONG",4)
      arcpy.AddField_management(ft,"Attr13","DOUBLE",8,1)
      arcpy.AddField_management(ft,"Attr14","DOUBLE",8,1)
      arcpy.AddField_management(ft,"Attr15","LONG",4)
      arcpy.AddField_management(ft,"Attr16","DOUBLE",8,1)
      arcpy.AddField_management(ft,"Attr17","LONG",2)
      arcpy.AddField_management(ft,"Attr18","TEXT","","",254)
      arcpy.AddField_management(ft,"Attr19","TEXT","","",254)
      arcpy.AddField_management(ft,"Attr20","LONG",2)
      arcpy.AddField_management(ft,"Attr21","DOUBLE",9,2)
      arcpy.AddField_management(ft,"Attr22","DOUBLE",9,2)
      arcpy.AddField_management(ft,"Attr23","DOUBLE",9,2)
      arcpy.AddField_management(ft,"Attr24","TEXT","","",254)
      arcpy.AddField_management(ft,"Attr25","DOUBLE",9,2)
      arcpy.AddField_management(ft,"Attr26","TEXT","","",254)
      arcpy.AddField_management(ft,"Attr27","TEXT","","",254)
      arcpy.AddField_management(ft,"Attr28","TEXT","","",254)
      arcpy.AddField_management(ft,"Attr29","TEXT","","",254)
      arcpy.AddField_management(ft,"Attr30","TEXT","","",254)

      arcpy.CalculateField_management(ft,"Attr01",code)
      arcpy.CalculateField_management(ft,"Attr04","'" + name + "'","PYTHON_9.3")
      arcpy.CalculateField_management(ft,"Attr05","!棟番号!","PYTHON_9.3")
      arcpy.CalculateField_management(ft,"Attr24","'" + code + "'" + "!棟番号!","PYTHON_9.3")
      arcpy.CalculateField_management(ft,"Attr25","!SHAPE.AREA!","PYTHON_9.3")

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

