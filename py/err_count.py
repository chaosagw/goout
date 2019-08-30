# encoding: shift-JIS

import os, sys, glob, shutil, traceback, atexit, codecs

from arcpy import *
from arcpy.management import *

def owari():
  print (u"�����")
  raw_input("�I������ɂ� Enter �L�[�������Ă�������")

#�����I�����Ɏ��s�����Func��o�^
atexit.register( owari )

in_path = sys.path[0]

print (u'\n  err count....  \n')

env.overwriteOutput = True

import time
t1 = time.time()

os.chdir(in_path)
env.workspace = in_path

cads = glob.glob(in_path + os.sep + '*.dxf')

errLog = in_path + os.sep + 'err_cnt.txt'
if Exists(errLog): Delete(errLog)
fw = codecs.open(errLog,"w","shift_jis")

for cad in cads:

  try:
    fname = os.path.basename(cad)[0:-4]
    cad_fc = cad + os.sep + "point"
    err_cnt = int(GetCount_management(cad_fc).getOutput(0))
#     print(type(fname))
#     print(type(str(err_cnt)))
    l = fname + "\t" + str(err_cnt)
    print(l)
    #fw.write(l + "\n")

  except:
    print (u"�G���[�ł�!")
    print (traceback.format_exc(sys.exc_info()[2]))

fw.close()

print ('\n ��������: %.1f �b' % (time.time() - t1))
print ('\n �����I��. \n')

