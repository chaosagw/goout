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

print (u'\n  ������....  \n')

env.overwriteOutput = True

import time
t1 = time.time()

os.chdir(in_path)
env.workspace = in_path

fcs = ListFeatureClasses()

try:
  
  for fc in fcs:
    MakeFeatureLayer_management(fc,"tmp_kbn")
    query1 =  ' "���" like ' + " '%���ǎ�' "
    SelectLayerByAttribute_management("tmp_kbn","NEW_SELECTION",query1)
    tatemono = "D:\WS\UR_pre\kiban\m_" + fc
    CopyFeatures("tmp_kbn",tatemono)
    DeleteFeatures_management("tmp_kbn")

except:
  print (u"�G���[�ł�!")
  print (traceback.format_exc(sys.exc_info()[2]))

print ('\n ��������: %.1f �b' % (time.time() - t1))
print ('\n �����I��. \n')

