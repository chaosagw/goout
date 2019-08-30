#coding:shift_jis
####coded by agawa####

import os, sys, time, traceback, atexit
from arcpy import *
from arcpy.management import *

def owari():
  print u"おわり"
  raw_input("終了するには Enter キーを押してください")

atexit.register( owari )

try:
  # ワークスペースの設定
  env.workspace = sys.path[0]
  env.overwriteOutput = True

  inpath = sys.path[0]

  joinTbl_code = inpath + os.sep + "市町村コードtbl.xls" + os.sep + "Sheet1$"

  # ftのリストを取得
  features = arcpy.ListFeatureClasses()

  # すべてのfeatureに対してループで実行
  
  for ft in features:
    print ft.encode('shift-jis') + "を処理中..."
    result = GetCount_management(ft)
    if int(result.getOutput(0)) > 0:
      MakeFeatureLayer_management(ft,"ft_lyr")
      AddJoin_management("ft_lyr","Attr01",joinTbl_code,"団地コード")
      CalculateField_management("ft_lyr","Attr02","[Sheet1$.市町村コード]", "VB", "")


except:
  print u"エラーです!"
  print traceback.format_exc(sys.exc_info()[2])

