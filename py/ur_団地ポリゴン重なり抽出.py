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
  
  list_1kei = []
  list_2kei = []
  list_3kei = []
  list_4kei = []
  list_5kei = []
  list_6kei = []
  list_7kei = []
  list_8kei = []
  list_9kei = []
  list_10kei = []
  list_11kei = []
  list_12kei = []
  list_13kei = []
  list_14kei = []

  for fc in fcs:
    projection = Describe(fc).spatialReference.factoryCode
    print(fc)
    #print(projection)

    #1kei
    if projection == 6669:
      list_1kei.append(in_path + os.sep + fc)
    #2kei
    elif projection == 6670:
      list_2kei.append(in_path + os.sep + fc)
    #3kei
    elif projection == 6671:
      list_3kei.append(in_path + os.sep + fc)
    #4kei
    elif projection == 6672:
      list_4kei.append(in_path + os.sep + fc)
    #5kei
    elif projection == 6673:
      list_5kei.append(in_path + os.sep + fc)
    #6kei
    elif projection == 6674:
      list_6kei.append(in_path + os.sep + fc)
    #7kei
    elif projection == 6675:
      list_7kei.append(in_path + os.sep + fc)
    #8kei
    elif projection == 6676:
      list_8kei.append(in_path + os.sep + fc)
    #9kei
    elif projection == 6677:
      list_9kei.append(in_path + os.sep + fc)
    #10kei
    elif projection == 6678:
      list_10kei.append(in_path + os.sep + fc)
    #11kei
    elif projection == 6679:
      list_11kei.append(in_path + os.sep + fc)
    #12kei
    elif projection == 6680:
      list_12kei.append(in_path + os.sep + fc)
    #13kei
    elif projection == 6681:
      list_13kei.append(in_path + os.sep + fc)
    #14kei
    elif projection == 6682:
      list_14kei.append(in_path + os.sep + fc)
    else:
      print("座標系が範囲外です！")

  if len(list_1kei) > 0:
    out_intsct = in_path + os.sep + "err.gdb" + os.sep + "ck1kei_cross"
    out_merge = in_path + os.sep + "1kei_merge.shp"
    Merge_management(list_1kei,out_merge)
    Intersect_analysis(out_merge,out_intsct)
    if int(GetCount(out_intsct)[0]) == 0: Delete(out_intsct)

  if len(list_2kei) > 0:
    out_intsct = in_path + os.sep + "err.gdb" + os.sep + "ck2kei_cross"
    out_merge = in_path + os.sep + "2kei_merge.shp"
    Merge_management(list_2kei,out_merge)
    Intersect_analysis(out_merge,out_intsct)
    if int(GetCount(out_intsct)[0]) == 0: Delete(out_intsct)

  if len(list_3kei) > 0:
    out_intsct = in_path + os.sep + "err.gdb" + os.sep + "ck3kei_cross"
    out_merge = in_path + os.sep + "3kei_merge.shp"
    Merge_management(list_3kei,out_merge)
    Intersect_analysis(out_merge,out_intsct)
    if int(GetCount(out_intsct)[0]) == 0: Delete(out_intsct)

  if len(list_4kei) > 0:
    out_intsct = in_path + os.sep + "err.gdb" + os.sep + "ck4kei_cross"
    out_merge = in_path + os.sep + "4kei_merge.shp"
    Merge_management(list_4kei,out_merge)
    Intersect_analysis(out_merge,out_intsct)
    if int(GetCount(out_intsct)[0]) == 0: Delete(out_intsct)

  if len(list_5kei) > 0:
    out_intsct = in_path + os.sep + "err.gdb" + os.sep + "ck5kei_cross"
    out_merge = in_path + os.sep + "5kei_merge.shp"
    Merge_management(list_5kei,out_merge)
    Intersect_analysis(out_merge,out_intsct)
    if int(GetCount(out_intsct)[0]) == 0: Delete(out_intsct)

  if len(list_6kei) > 0:
    out_intsct = in_path + os.sep + "err.gdb" + os.sep + "ck6kei_cross"
    out_merge = in_path + os.sep + "6kei_merge.shp"
    Merge_management(list_6kei,out_merge)
    Intersect_analysis(out_merge,out_intsct)
    if int(GetCount(out_intsct)[0]) == 0: Delete(out_intsct)

  if len(list_7kei) > 0:
    out_intsct = in_path + os.sep + "err.gdb" + os.sep + "ck7kei_cross"
    out_merge = in_path + os.sep + "7kei_merge.shp"
    Merge_management(list_7kei,out_merge)
    Intersect_analysis(out_merge,out_intsct)
    if int(GetCount(out_intsct)[0]) == 0: Delete(out_intsct)

  if len(list_8kei) > 0:
    out_intsct = in_path + os.sep + "err.gdb" + os.sep + "ck8kei_cross"
    out_merge = in_path + os.sep + "8kei_merge.shp"
    Merge_management(list_8kei,out_merge)
    Intersect_analysis(out_merge,out_intsct)
    if int(GetCount(out_intsct)[0]) == 0: Delete(out_intsct)

  if len(list_9kei) > 0:
    out_intsct = in_path + os.sep + "err.gdb" + os.sep + "ck9kei_cross"
    out_merge = in_path + os.sep + "9kei_merge.shp"
    Merge_management(list_9kei,out_merge)
    Intersect_analysis(out_merge,out_intsct)
    if int(GetCount(out_intsct)[0]) == 0: Delete(out_intsct)

  if len(list_10kei) > 0:
    out_intsct = in_path + os.sep + "err.gdb" + os.sep + "ck10kei_cross"
    out_merge = in_path + os.sep + "10kei_merge.shp"
    Merge_management(list_1kei,out_merge)
    Intersect_analysis(out_merge,out_intsct)
    if int(GetCount(out_intsct)[0]) == 0: Delete(out_intsct)

  if len(list_11kei) > 0:
    out_intsct = in_path + os.sep + "err.gdb" + os.sep + "ck11kei_cross"
    out_merge = in_path + os.sep + "11kei_merge.shp"
    Merge_management(list_11kei,out_merge)
    Intersect_analysis(out_merge,out_intsct)
    if int(GetCount(out_intsct)[0]) == 0: Delete(out_intsct)

  if len(list_12kei) > 0:
    out_intsct = in_path + os.sep + "err.gdb" + os.sep + "ck12kei_cross"
    out_merge = in_path + os.sep + "12kei_merge.shp"
    Merge_management(list_12kei,out_merge)
    Intersect_analysis(out_merge,out_intsct)
    if int(GetCount(out_intsct)[0]) == 0: Delete(out_intsct)

  if len(list_13kei) > 0:
    out_intsct = in_path + os.sep + "err.gdb" + os.sep + "ck13kei_cross"
    out_merge = in_path + os.sep + "13kei_merge.shp"
    Merge_management(list_13kei,out_merge)
    Intersect_analysis(out_merge,out_intsct)
    if int(GetCount(out_intsct)[0]) == 0: Delete(out_intsct)

  if len(list_14kei) > 0:
    out_intsct = in_path + os.sep + "err.gdb" + os.sep + "ck14kei_cross"
    out_merge = in_path + os.sep + "14kei_merge.shp"
    Merge_management(list_14kei,out_merge)
    Intersect_analysis(out_merge,out_intsct)
    if int(GetCount(out_intsct)[0]) == 0: Delete(out_intsct)


except:
  print (u"エラーです!")
  print (traceback.format_exc(sys.exc_info()[2]))

print ('\n 処理時間: %.1f 秒' % (time.time() - t1))
print ('\n 処理終了. \n')

