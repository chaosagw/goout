#coding:shift_jis
####coded by agawa####

import arcpy, os, sys, time, traceback, atexit, codecs, math, codecs
from arcpy import env

def owari():
  print u"�����"
  raw_input("�I������ɂ� Enter �L�[�������Ă�������")

atexit.register( owari )

try:
  # ���[�N�X�y�[�X�̐ݒ�
  env.workspace = sys.path[0]
  env.overwriteOutput = True

  inpath = sys.path[0]

  # �p�X���̃t�B�[�`���N���X���X�g���擾
  features = arcpy.ListFeatureClasses()
  FC_CountFile = inpath + os.sep + "FC_Count.csv"
  #���{����������ނ̂ŕ����R�[�h���w�肵�ď������ރt�@�C�����I�[�v��
  f = codecs.open(FC_CountFile,"w", "shift_jis")

  # �p�X���̂��ׂẴt�B�[�`���N���X�ɑ΂��ă��[�v�Ŏ��s
  for feature in features:
      print feature + u"��������"
      arcpy.MakeFeatureLayer_management(feature,"fc")
      no = arcpy.GetCount_management("fc")
      query1 =  ' "���ԍ�" = ' + " '' "
      arcpy.SelectLayerByAttribute_management("fc","NEW_SELECTION",query1)
      no_fumei = arcpy.GetCount_management("fc")
      strs = feature + "," + str(no) + "," + str(no_fumei) + "\n"
      f.write(strs)
      #print no

  f.close()

except:
  print u"�G���[�ł�!"
  print traceback.format_exc(sys.exc_info()[2])
