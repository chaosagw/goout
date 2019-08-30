#coding:shift_jis
####coded by agawa####

import os, sys, time, traceback, atexit
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

  joinTbl_code = inpath + os.sep + "�s�����R�[�htbl.xls" + os.sep + "Sheet1$"

  # ft�̃��X�g���擾
  features = arcpy.ListFeatureClasses()

  # ���ׂĂ�feature�ɑ΂��ă��[�v�Ŏ��s
  
  for ft in features:
    print ft.encode('shift-jis') + "��������..."
    result = GetCount_management(ft)
    if int(result.getOutput(0)) > 0:
      MakeFeatureLayer_management(ft,"ft_lyr")
      AddJoin_management("ft_lyr","Attr01",joinTbl_code,"�c�n�R�[�h")
      CalculateField_management("ft_lyr","Attr02","[Sheet1$.�s�����R�[�h]", "VB", "")


except:
  print u"�G���[�ł�!"
  print traceback.format_exc(sys.exc_info()[2])

