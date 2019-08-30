#coding:shift_jis
####coded by agawa####

import arcpy, os, sys, time, traceback, atexit, codecs, math
from arcpy import env

def owari():
  print u"�����"
  raw_input("�I������ɂ� Enter �L�[�������Ă�������")

atexit.register( owari )

def createNodes(fc):

    rows = arcpy.SearchCursor(fc, "", "", "", "")
    desc = arcpy.Describe(fc)
    shapefieldname = desc.ShapeFieldName
    outFC = inpath + os.sep + fc.replace(".shp", "") + "_node.shp"

    arcpy.CreateFeatureclass_management(os.path.dirname(outFC),os.path.basename(outFC),"Point")
    arcpy.AddField_management(outFC,"angle","FLOAT")

    # Iterate through the rows in the cursor
    for row in rows:

    # Create the geometry object
        ft = row.getValue(shapefieldname)

        # Step through each vertex in the feature
        pntNum = ft.pointCount
        part = ft.getPart(0)

        angleF = GetAzimuth(ft.firstPoint,part.getObject(1))
        angleL = GetAzimuth(ft.lastPoint,part.getObject(pntNum - 2))

        cur = arcpy.InsertCursor(outFC)

        pointF = cur.newRow()
        pointF.shape = ft.firstPoint
        pointF.angle = angleF
        cur.insertRow(pointF)

        pointL = cur.newRow()
        pointL.shape = ft.lastPoint
        pointL.angle = angleL
        cur.insertRow(pointL)

        del cur

def GetAzimuth(pntL,pntF):
    radian = math.atan2((pntL.Y - pntF.Y),(pntL.X - pntF.X))
    degrees = radian * 180 / math.pi
    if 0 <= degrees <= 90:
      angle = 90 - degrees
    elif degrees <= 180:
      angle = 90 - degrees
    elif -180 <= degrees <= -90:
      angle = -(degrees+270)
    else:
      angle = 180 + degrees
    
    #���ʊp�ɕϊ�
    angle = (-(angle % 360) + 90 + 360) % 360
    return angle


try:
  # ���[�N�X�y�[�X�̐ݒ�
  env.workspace = sys.path[0]
  env.overwriteOutput = True

  inpath = sys.path[0]

  # �p�X���̃t�B�[�`���N���X���X�g���擾
  features = arcpy.ListFeatureClasses()

  # �p�X���̂��ׂẴt�B�[�`���N���X�ɑ΂��ă��[�v�Ŏ��s
  for feature in features:
      print feature + u"��������"
      createNodes(feature)

except:
  print u"�G���[�ł�!"
  print traceback.format_exc(sys.exc_info()[2])
