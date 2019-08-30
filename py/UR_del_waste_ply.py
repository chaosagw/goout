# encoding: shift-JIS

import os, sys, glob, shutil, traceback, atexit, csv, fnmatch

from arcpy import *
from arcpy.management import *

def owari():
  print (u"おわり")
  raw_input("終了するには Enter キーを押してください")

atexit.register( owari )

in_path = sys.path[0]

print (u'\n  UR不要建物削除中....  \n')

env.overwriteOutput = True

import time
t1 = time.time()

os.chdir(in_path)
env.workspace = in_path

try:
  del_list = os.path.join(in_path,"del_list.csv")
  tmp_list = os.path.join(in_path,"tmp_list.csv")
  if Exists(tmp_list): Delete(tmp_list)
  code1 = 0
  list_new = open(tmp_list,"w")
  with open(del_list) as f:
    reader = csv.reader(f)
    for row in reader:
      code2 = row[0]
      atr = row[1]
      if code1 <> code2:
        if code1 == 0:
          list_new.write(code2 + "," + atr)
        else:
          list_new.write("\n" + code2 + "," + atr)
        code1 = code2
      else:
        list_new.write("," + atr)
  list_new.close()
  
  with open(tmp_list) as f:
    reader = csv.reader(f)
    for row in reader:
      del_atr = []
      for i in range(len(row)):
        if i == 0:
          fname = str(row[i]) + "tatemono.shp"
          #処理するファイルをサブディレクトリまで検索
          del_shp = []
          for root, dirs, files in os.walk(in_path):
            for filename in fnmatch.filter(files, fname):
              del_shp.append(os.path.join(root, filename)) 
        else:
          #print(row[i])
          del_atr.append(row[i])
      
#       print(del_shp)
      print(fname + "を処理してます。")
      print(del_atr)
      if len(del_atr) == 1:
        del_atr.append("9999")
      query =  ' "Attr05" in ' + str(tuple(del_atr))
#       print(query)
      if len(del_shp) > 0:
        MakeFeatureLayer_management(del_shp[0],"tatemono_ply")
        SelectLayerByAttribute_management("tatemono_ply","NEW_SELECTION",query)
        DeleteFeatures_management("tatemono_ply")


except:
  #作業ファイルお掃除
  print (u"エラーです!")
  print (traceback.format_exc(sys.exc_info()[2]))

print ('\n 処理時間: %.1f 秒' % (time.time() - t1))
print ('\n 処理終了. \n')
