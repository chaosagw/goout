# encoding: shift-JIS

import os, sys, glob, shutil, traceback, atexit, csv, fnmatch

from arcpy import *
from arcpy.management import *

def owari():
  print (u"�����")
  raw_input("�I������ɂ� Enter �L�[�������Ă�������")

atexit.register( owari )

in_path = sys.path[0]

print (u'\n  �Ɖ��ԍ���....  \n')

env.overwriteOutput = True

import time
t1 = time.time()

os.chdir(in_path)
env.workspace = in_path

#kaoku_no.txt�͏����O�ɉƉ�NO�Ń\�[�g������
try:
  del_list = os.path.join(in_path,"kaoku_no.txt")
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
          list_new.write(code2 + "\t" + atr)
        else:
          list_new.write("\n" + code2 + "\t" + atr)
        code1 = code2
      else:
        list_new.write("," + atr)
  list_new.close()
  
except:
  #��ƃt�@�C�����|��
  print (u"�G���[�ł�!")
  print (traceback.format_exc(sys.exc_info()[2]))

print ('\n ��������: %.1f �b' % (time.time() - t1))
print ('\n �����I��. \n')
