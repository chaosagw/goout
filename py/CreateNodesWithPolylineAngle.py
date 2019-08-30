#coding:shift_jis
####coded by agawa####

import arcpy, os, sys, time, traceback, atexit, codecs, math
from arcpy import env

def owari():
  print u"おわり"
  raw_input("終了するには Enter キーを押してください")

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
    
    #方位角に変換
    angle = (-(angle % 360) + 90 + 360) % 360
    return angle


try:
  # ワークスペースの設定
  env.workspace = sys.path[0]
  env.overwriteOutput = True

  inpath = sys.path[0]

  # パス内のフィーチャクラスリストを取得
  features = arcpy.ListFeatureClasses()

  # パス内のすべてのフィーチャクラスに対してループで実行
  for feature in features:
      print feature + u"を処理中"
      createNodes(feature)

except:
  print u"エラーです!"
  print traceback.format_exc(sys.exc_info()[2])
