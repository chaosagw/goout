#coding:shift_jis
####coded by agawa####

import arcpy, os, sys, time, traceback, atexit

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

  # fcのリストを取得
  features = ListFeatureClasses()

  # すべてのfeatureに対してループで実行
  log = os.path.join(inpath,"Field_list.csv")
  f = open(log,"w")
  for ft in features:
    #print ft.encode('shift-jis') + "を処理中..."
    result = GetCount_management(ft)
    if int(result.getOutput(0)) > 0:
#       strs = ft.split("_")
#       code = strs[0]
#       name = strs[1]
#       new_name = code + "_" + name
#       arcpy.AddField_management(ft, "f_name", "TEXT")
      fields = ListFields(ft)
      fldNames = ft
      for fld in fields:
        if not fld.required:
          fldNames = fldNames + "," + fld.name
      fldNames = fldNames + "\n"
      #print(fldNames)
      f.write(fldNames.encode('shift-jis'))
  f.close()

except:
  print u"エラーです!"
  print traceback.format_exc(sys.exc_info()[2])

