#coding:shift_jis
####coded by agawa####

import arcpy, os, sys, time, traceback, atexit

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

  # fc�̃��X�g���擾
  features = ListFeatureClasses()

  # ���ׂĂ�feature�ɑ΂��ă��[�v�Ŏ��s
  log = os.path.join(inpath,"Field_list.csv")
  f = open(log,"w")
  for ft in features:
    #print ft.encode('shift-jis') + "��������..."
    result = GetCount_management(ft)
    if int(result.getOutput(0)) > 0:
#       strs = ft.split("_")
#       code = strs[0]
#       name = strs[1]
#       new_name = code + "_" + name
#       arcpy.AddField_management(ft, "f_name", "TEXT")
      fields = ListFields(ft)
      fldNames = ft
      for fld in fields:
        if not fld.required:
          fldNames = fldNames + "," + fld.name
      fldNames = fldNames + "\n"
      #print(fldNames)
      f.write(fldNames.encode('shift-jis'))
  f.close()

except:
  print u"�G���[�ł�!"
  print traceback.format_exc(sys.exc_info()[2])

