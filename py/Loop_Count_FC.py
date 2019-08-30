#coding:shift_jis
####coded by agawa####

import arcpy, os, sys, time, traceback, atexit, codecs, math, codecs
from arcpy import env

def owari():
  print u"おわり"
  raw_input("終了するには Enter キーを押してください")

atexit.register( owari )

try:
  # ワークスペースの設定
  env.workspace = sys.path[0]
  env.overwriteOutput = True

  inpath = sys.path[0]

  # パス内のフィーチャクラスリストを取得
  features = arcpy.ListFeatureClasses()
  FC_CountFile = inpath + os.sep + "FC_Count.csv"
  #日本語を書き込むので文字コードを指定して書き込むファイルをオープン
  f = codecs.open(FC_CountFile,"w", "shift_jis")

  # パス内のすべてのフィーチャクラスに対してループで実行
  for feature in features:
      print feature + u"を処理中"
      arcpy.MakeFeatureLayer_management(feature,"fc")
      no = arcpy.GetCount_management("fc")
      query1 =  ' "棟番号" = ' + " '' "
      arcpy.SelectLayerByAttribute_management("fc","NEW_SELECTION",query1)
      no_fumei = arcpy.GetCount_management("fc")
      strs = feature + "," + str(no) + "," + str(no_fumei) + "\n"
      f.write(strs)
      #print no

  f.close()

except:
  print u"エラーです!"
  print traceback.format_exc(sys.exc_info()[2])
