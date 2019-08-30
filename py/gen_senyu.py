# encoding: shift-JIS

import os, sys, glob, shutil, traceback, atexit, csv, fnmatch


def owari():
  print (u"おわり")
  raw_input("終了するには Enter キーを押してください")

atexit.register( owari )

in_path = sys.path[0]

print (u'\n  専有中....  \n')


import time
t1 = time.time()

os.chdir(in_path)

#senyu.txtは処理前に家屋NOでソートかける
try:
  del_list = os.path.join(in_path,"senyu.txt")
  tmp_list = os.path.join(in_path,"senyu_menseki.txt")
  if os.path.exists(tmp_list): os.remove(tmp_list)
  code1 = 0
  list_new = open(tmp_list,"w")
  with open(del_list) as f:
    reader = csv.reader(f)
    for row in reader:
      code2 = row[0]
      men1 = row[1]
      men2 = row[2]
      if code1 <> code2:
        if code1 == 0:
          list_new.write(code2 + "," + men1 + "," + men2)
        else:
          list_new.write("\n" + code2 + "," + men1 + "," + men2)
        code1 = code2
      else:
        list_new.write("," + men1 + "," + men2)
  list_new.close()
  
except:
  print (u"エラーです!")
  print (traceback.format_exc(sys.exc_info()[2]))

print ('\n 処理時間: %.1f 秒' % (time.time() - t1))
print ('\n 処理終了. \n')
