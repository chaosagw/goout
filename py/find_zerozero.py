#coding:shift_jis
####coded by agawa####

import os, sys, time, traceback, atexit, codecs
from arcpy import *
from arcpy.management import *


def owari():
  print u"�����"
  raw_input("�I������ɂ� Enter �L�[�������Ă�������")

atexit.register( owari )

try:
  # ���[�N�X�y�[�X�̐ݒ�
  env.workspace = sys.path[0]
  env.overwriteOutput = True

  inpath = sys.path[0]
  out_txt = os.path.join(inpath,"0000000�J�E���g.txt")
  fw = codecs.open(out_txt,"w","shift_jis")


  # fc�̃��X�g���擾
  features = arcpy.ListFeatureClasses()

  # ���ׂĂ�feature�ɑ΂��ă��[�v�Ŏ��s

  for ft in features:
    print ft.encode('shift-jis') + "��������..."
    tou_cnt = int(GetCount_management(ft).getOutput(0))
    if tou_cnt > 1:
      query_sel = ' "���ԍ�" = ' + "'0000000'"
      MakeFeatureLayer_management(ft,"touNo_nashi",query_sel)
      touNo_nashi_cnt = int(GetCount_management("touNo_nashi").getOutput(0))
      if touNo_nashi_cnt > 0:
        if tou_cnt == touNo_nashi_cnt:
          name = ft.encode('shift-jis')[0:5]
          fw.write(name + "," + str(tou_cnt) + "\n")

  fw.close()

except:
  print u"�G���[�ł�!"
  print traceback.format_exc(sys.exc_info()[2])

