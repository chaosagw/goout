#coding:shift_jis
####coded by agawa####

import os, sys, traceback, atexit, fnmatch
from arcpy import *
from arcpy.management import *

def owari():
  print u"おわり"
  raw_input("終了するには Enter キーを押してください")

atexit.register( owari )

import time
t1 = time.time()

try:
  # ワークスペースの設定
  env.workspace = sys.path[0]
  env.overwriteOutput = True

  inpath = sys.path[0]

  #家屋一覧テーブル
  joinTbl_list = os.path.join(inpath, "tbl_一覧.csv")
  #住棟マスタテーブル
  joinTbl_master = os.path.join(inpath, "tbl_マスタ.csv")

  # tatemono.shpのリストを取得
  #features = arcpy.ListFeatureClasses()
  blds = []
  for root, dirs, files in os.walk(inpath):
    for filename in fnmatch.filter(files, "*tatemono.shp"):
        blds.append(os.path.join(root, filename))

  
  for bld in blds:
    print bld + "を処理中..."
    result = GetCount_management(bld)
    if int(result.getOutput(0)) > 0:
      #リンクキー演算
      #CalculateField_management(bld, "Attr24", "[Attr01] & [Attr05]", "VB", "")
      AddField_management(bld,"key","TEXT")
      MakeFeatureLayer_management(bld, "ft_lyr")
      AddJoin_management("ft_lyr", "Attr24", joinTbl_list, "リンク")
      CalculateField_management("ft_lyr", "id", "[tbl_一覧.csv.家屋一覧No]", "VB", "")
      CalculateField_management(bld, "key", "[id]", "VB", "")
      MakeFeatureLayer_management(bld, "ft_lyr")

      AddJoin_management("ft_lyr","key",joinTbl_master,"家屋一覧No")
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

      AddJoin_management("ft_lyr", "Attr24", joinTbl_list, "リンク")
      CalculateField_management("ft_lyr", "Attr18", "[tbl_一覧.csv.所在地]", "VB", "")
      CalculateField_management("ft_lyr", "Attr19", "[tbl_一覧.csv.家屋番号]", "VB", "")
      CalculateField_management("ft_lyr", "Attr20", "[tbl_一覧.csv.階数]", "VB", "")
      CalculateField_management("ft_lyr", "Attr21", "[tbl_一覧.csv.床面積]", "VB", "")
      CalculateField_management("ft_lyr", "Attr22", "[tbl_一覧.csv.専有床面積1]", "VB", "")
      CalculateField_management("ft_lyr", "Attr23", "[tbl_一覧.csv.専有床面積2]", "VB", "")

      CalculateField_management("ft_lyr", "Attr25", "int(!shape.area@SQUAREMETERS!)", "PYTHON_9.3")
      DeleteField_management(bld, "key")


except:
  print u"エラーです!"
  print traceback.format_exc(sys.exc_info()[2])

print ('\n 処理時間: %.1f 秒' % (time.time() - t1))
