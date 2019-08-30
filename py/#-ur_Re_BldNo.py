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

  joinTbl_list = inpath + os.sep + "tbl_�ꗗ.xls" + os.sep + "�S�f�[�^$"
  joinTbl_master = os.path.join(inpath,"tbl_�}�X�^.csv")

  # ft�̃��X�g���擾
  features = arcpy.ListFeatureClasses()

  # ���ׂĂ�feature�ɑ΂��ă��[�v�Ŏ��s
  
  for ft in features:
    print ft.encode('shift-jis') + "��������..."
    result = GetCount_management(ft)
    if int(result.getOutput(0)) > 0:
      MakeFeatureLayer_management(ft,"ft_lyr")
      AddJoin_management("ft_lyr","Attr24",joinTbl_list,"�����N")
      CalculateField_management("ft_lyr","id","[�S�f�[�^$.�Ɖ��ꗗNo]", "VB", "")

      AddJoin_management("ft_lyr","id",joinTbl_master,"�Ɖ��ꗗNo")
      CalculateField_management("ft_lyr", "Attr06", "[tbl_�}�X�^.csv.�J�n�N�x��]", "VB", "")
      CalculateField_management("ft_lyr", "Attr07", "[tbl_�}�X�^.csv.�J�n�N�x�a]", "VB", "")
      CalculateField_management("ft_lyr", "Attr08", "[tbl_�}�X�^.csv.�H�@�敪]", "VB", "")
      CalculateField_management("ft_lyr", "Attr09", "[tbl_�}�X�^.csv.�����^���R]", "VB", "")
      CalculateField_management("ft_lyr", "Attr10", "[tbl_�}�X�^.csv.�����^����]", "VB", "")
      CalculateField_management("ft_lyr", "Attr11", "[tbl_�}�X�^.csv.�K��]", "VB", "")
      CalculateField_management("ft_lyr", "Attr12", "[tbl_�}�X�^.csv.�ː�]", "VB", "")
      CalculateField_management("ft_lyr", "Attr12", "[tbl_�}�X�^.csv.���z�ʐ�]", "VB", "")
      CalculateField_management("ft_lyr", "Attr14", "[tbl_�}�X�^.csv.��p���ʐ�]", "VB", "")
      CalculateField_management("ft_lyr", "Attr15", "[tbl_�}�X�^.csv.�{�ݐ�]", "VB", "")
      CalculateField_management("ft_lyr", "Attr16", "[tbl_�}�X�^.csv.�{�ݏ��ʐ�]", "VB", "")
      CalculateField_management("ft_lyr", "Attr17", "[tbl_�}�X�^.csv.�˂P�ȏ�]", "VB", "")

      CalculateField_management("ft_lyr", "Attr18", "[�S�f�[�^$.���ݒn]", "VB", "")
      CalculateField_management("ft_lyr", "Attr19", "[�S�f�[�^$.�Ɖ��ԍ�]", "VB", "")
      CalculateField_management("ft_lyr", "Attr20", "[�S�f�[�^$.�K��]", "VB", "")
      CalculateField_management("ft_lyr", "Attr21", "[�S�f�[�^$.���ʐ�]", "VB", "")
      CalculateField_management("ft_lyr", "Attr22", "[�S�f�[�^$.��L���ʐ�]", "VB", "")
#      CalculateField_management("ft_lyr", "Attr23", "[�S�f�[�^$.��L���ʐ�]", "VB", "")


except:
  print u"�G���[�ł�!"
  print traceback.format_exc(sys.exc_info()[2])

