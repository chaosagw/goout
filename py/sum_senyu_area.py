# encoding: shift-JIS

import os, sys, glob, shutil, traceback, atexit, csv, fnmatch

def owari():
  print (u"おわり")
  #wait = input("終了するには Enter キーを押してください")
  raw_input("終了するには Enter キーを押してください")

atexit.register( owari )

in_path = sys.path[0]

print (u'\n  専有中....  \n')

import time
t1 = time.time()

os.chdir(in_path)

try:
  del_list = os.path.join(in_path,"senyu_menseki.txt")
  tmp_list = os.path.join(in_path,"sum_senyu.txt")
  if os.path.exists(tmp_list): os.remove(tmp_list)
  #code1 = 0

  list_new = open(tmp_list,"w")
  with open(del_list) as f:
    reader = csv.reader(f)
    for row in reader:
      code2 = row[0]
      leng = len(row)
      men1 = 0
      men2 = 0
      if leng == 3:
        men1 = row[1]
        men2 = row[2]
        list_new.write(code2 + "\t" + str(men1) + "\t" + str(men2) + "\n")
      else:
        for i in range(1,leng,2):
          men1 = float(men1) + float(row[i])
        for ii in range(2,leng,2):
          men2 = float(men2) + float(row[ii])
        list_new.write(code2 + "\t" + str(men1) + "\t" + str(men2) + "\n")

  list_new.close()
  
except:
  print (u"エラーです!")
  print (traceback.format_exc(sys.exc_info()[2]))

print ('\n 処理時間: %.1f 秒' % (time.time() - t1))
print ('\n 処理終了. \n')
