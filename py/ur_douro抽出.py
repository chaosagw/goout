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

print (u'\n  道路中....  \n')

env.overwriteOutput = True

import time
t1 = time.time()

os.chdir(in_path)
env.workspace = in_path

fcs = ListFeatureClasses()

try:
  
  kbn_path = "D:\WS\UR\work\gis\doro\doro_9kei.shp"
  out_path = "D:\WS\UR\work\gis\out"
  for fc in fcs:
      MakeFeatureLayer_management(kbn_path,"tmp_kbn")
      SelectLayerByLocation_management("tmp_kbn","INTERSECT",fc,"200 Meters")
      doro = out_path + os.sep + fc.replace("danchi","_doro")
      CopyFeatures_management("tmp_kbn",doro)

except:
  print (u"エラーです!")
  print (traceback.format_exc(sys.exc_info()[2]))

print ('\n 処理時間: %.1f 秒' % (time.time() - t1))
print ('\n 処理終了. \n')

