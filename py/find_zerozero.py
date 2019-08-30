#coding:shift_jis
####coded by agawa####

import os, sys, time, traceback, atexit, codecs
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
  out_txt = os.path.join(inpath,"0000000カウント.txt")
  fw = codecs.open(out_txt,"w","shift_jis")


  # fcのリストを取得
  features = arcpy.ListFeatureClasses()

  # すべてのfeatureに対してループで実行

  for ft in features:
    print ft.encode('shift-jis') + "を処理中..."
    tou_cnt = int(GetCount_management(ft).getOutput(0))
    if tou_cnt > 1:
      query_sel = ' "棟番号" = ' + "'0000000'"
      MakeFeatureLayer_management(ft,"touNo_nashi",query_sel)
      touNo_nashi_cnt = int(GetCount_management("touNo_nashi").getOutput(0))
      if touNo_nashi_cnt > 0:
        if tou_cnt == touNo_nashi_cnt:
          name = ft.encode('shift-jis')[0:5]
          fw.write(name + "," + str(tou_cnt) + "\n")

  fw.close()

except:
  print u"エラーです!"
  print traceback.format_exc(sys.exc_info()[2])

