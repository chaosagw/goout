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
    MakeFeatureLayer_management(fc,"tmp_kbn")
    query1 =  ' "種別" like ' + " '%無壁舎' "
    SelectLayerByAttribute_management("tmp_kbn","NEW_SELECTION",query1)
    tatemono = "D:\WS\UR_pre\kiban\m_" + fc
    CopyFeatures("tmp_kbn",tatemono)
    DeleteFeatures_management("tmp_kbn")

except:
  print (u"エラーです!")
  print (traceback.format_exc(sys.exc_info()[2]))

print ('\n 処理時間: %.1f 秒' % (time.time() - t1))
print ('\n 処理終了. \n')

