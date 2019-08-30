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

  joinTbl_list = inpath + os.sep + "tbl_一覧.xls" + os.sep + "全データ$"
  joinTbl_master = os.path.join(inpath,"tbl_マスタ.csv")

  # ftのリストを取得
  features = arcpy.ListFeatureClasses()

  # すべてのfeatureに対してループで実行
  
  for ft in features:
    print ft.encode('shift-jis') + "を処理中..."
    result = GetCount_management(ft)
    if int(result.getOutput(0)) > 0:
      MakeFeatureLayer_management(ft,"ft_lyr")
      AddJoin_management("ft_lyr","Attr24",joinTbl_list,"リンク")
      CalculateField_management("ft_lyr","id","[全データ$.家屋一覧No]", "VB", "")

      AddJoin_management("ft_lyr","id",joinTbl_master,"家屋一覧No")
      CalculateField_management("ft_lyr", "Attr06", "[tbl_マスタ.csv.開始年度西]", "VB", "")
      CalculateField_management("ft_lyr", "Attr07", "[tbl_マスタ.csv.開始年度和]", "VB", "")
      CalculateField_management("ft_lyr", "Attr08", "[tbl_マスタ.csv.工法区分]", "VB", "")
      CalculateField_management("ft_lyr", "Attr09", "[tbl_マスタ.csv.建物型式コ]", "VB", "")
      CalculateField_management("ft_lyr", "Attr10", "[tbl_マスタ.csv.建物型式名]", "VB", "")
      CalculateField_management("ft_lyr", "Attr11", "[tbl_マスタ.csv.階数]", "VB", "")
      CalculateField_management("ft_lyr", "Attr12", "[tbl_マスタ.csv.戸数]", "VB", "")
      CalculateField_management("ft_lyr", "Attr12", "[tbl_マスタ.csv.建築面積]", "VB", "")
      CalculateField_management("ft_lyr", "Attr14", "[tbl_マスタ.csv.専用床面積]", "VB", "")
      CalculateField_management("ft_lyr", "Attr15", "[tbl_マスタ.csv.施設数]", "VB", "")
      CalculateField_management("ft_lyr", "Attr16", "[tbl_マスタ.csv.施設床面積]", "VB", "")
      CalculateField_management("ft_lyr", "Attr17", "[tbl_マスタ.csv.戸１以上]", "VB", "")

      CalculateField_management("ft_lyr", "Attr18", "[全データ$.所在地]", "VB", "")
      CalculateField_management("ft_lyr", "Attr19", "[全データ$.家屋番号]", "VB", "")
      CalculateField_management("ft_lyr", "Attr20", "[全データ$.階数]", "VB", "")
      CalculateField_management("ft_lyr", "Attr21", "[全データ$.床面積]", "VB", "")
      CalculateField_management("ft_lyr", "Attr22", "[全データ$.専有床面積]", "VB", "")
#      CalculateField_management("ft_lyr", "Attr23", "[全データ$.専有床面積]", "VB", "")


except:
  print u"エラーです!"
  print traceback.format_exc(sys.exc_info()[2])

