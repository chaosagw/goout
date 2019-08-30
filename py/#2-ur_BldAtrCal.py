#coding:shift_jis
####coded by agawa####

import os, sys, traceback, atexit, fnmatch
from arcpy import *
from arcpy.management import *

def owari():
  print u"�����"
  raw_input("�I������ɂ� Enter �L�[�������Ă�������")

atexit.register( owari )

import time
t1 = time.time()

try:
  # ���[�N�X�y�[�X�̐ݒ�
  env.workspace = sys.path[0]
  env.overwriteOutput = True

  inpath = sys.path[0]

  #�Ɖ��ꗗ�e�[�u��
  joinTbl_list = os.path.join(inpath, "tbl_�ꗗ.csv")
  #�Z���}�X�^�e�[�u��
  joinTbl_master = os.path.join(inpath, "tbl_�}�X�^.csv")

  # tatemono.shp�̃��X�g���擾
  #features = arcpy.ListFeatureClasses()
  blds = []
  for root, dirs, files in os.walk(inpath):
    for filename in fnmatch.filter(files, "*tatemono.shp"):
        blds.append(os.path.join(root, filename))

  
  for bld in blds:
    print bld + "��������..."
    result = GetCount_management(bld)
    if int(result.getOutput(0)) > 0:
      #�����N�L�[���Z
      #CalculateField_management(bld, "Attr24", "[Attr01] & [Attr05]", "VB", "")
      AddField_management(bld,"key","TEXT")
      MakeFeatureLayer_management(bld, "ft_lyr")
      AddJoin_management("ft_lyr", "Attr24", joinTbl_list, "�����N")
      CalculateField_management("ft_lyr", "id", "[tbl_�ꗗ.csv.�Ɖ��ꗗNo]", "VB", "")
      CalculateField_management(bld, "key", "[id]", "VB", "")
      MakeFeatureLayer_management(bld, "ft_lyr")

      AddJoin_management("ft_lyr","key",joinTbl_master,"�Ɖ��ꗗNo")
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

      AddJoin_management("ft_lyr", "Attr24", joinTbl_list, "�����N")
      CalculateField_management("ft_lyr", "Attr18", "[tbl_�ꗗ.csv.���ݒn]", "VB", "")
      CalculateField_management("ft_lyr", "Attr19", "[tbl_�ꗗ.csv.�Ɖ��ԍ�]", "VB", "")
      CalculateField_management("ft_lyr", "Attr20", "[tbl_�ꗗ.csv.�K��]", "VB", "")
      CalculateField_management("ft_lyr", "Attr21", "[tbl_�ꗗ.csv.���ʐ�]", "VB", "")
      CalculateField_management("ft_lyr", "Attr22", "[tbl_�ꗗ.csv.��L���ʐ�1]", "VB", "")
      CalculateField_management("ft_lyr", "Attr23", "[tbl_�ꗗ.csv.��L���ʐ�2]", "VB", "")

      CalculateField_management("ft_lyr", "Attr25", "int(!shape.area@SQUAREMETERS!)", "PYTHON_9.3")
      DeleteField_management(bld, "key")


except:
  print u"�G���[�ł�!"
  print traceback.format_exc(sys.exc_info()[2])

print ('\n ��������: %.1f �b' % (time.time() - t1))
