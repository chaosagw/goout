#############
import arcpy, os, sys, traceback,datetime

# 入力フィーチャレイヤ
inFLs = arcpy.GetParameterAsText(0)
inOutPath = arcpy.GetParameterAsText(1)

# ログファイル
LogPath = 'UR_CD_CK_' + datetime.datetime.now().strftime('%Y%m%d%H%M%S') + '.log'
LogPath = os.path.join(inOutPath,LogPath)

LogFile = open(LogPath,'w')


def output(txt):
	arcpy.AddMessage(txt)
	LogFile.writelines(txt + '\n')

def outputW(txt):
	arcpy.AddWarning(txt)
	LogFile.writelines(txt.replace('\t\t','\t') + '\n')
	
# 入力されたフィーチャレイヤを順番に処理する
for fl in inFLs.split(';'):
	try:
		layname = os.path.basename(fl)
		
		desc = arcpy.Describe(fl)
		ds = desc.catalogPath

#		arcpy.AddMessage(fl)
#		arcpy.AddMessage(desc.path)
		workspace,a_tl = os.path.split(desc.path)
#		arcpy.AddMessage(workspace)
		result = arcpy.GetCount_management(ds)
		
		arcpy.MakeFeatureLayer_management(ds,"tmpLayer")
		#図形：取得方法コード04
		arcpy.SelectLayerByAttribute_management("tmpLayer","NEW_SELECTION","Attr12 = '04'")
		cnt = int(arcpy.GetCount_management("tmpLayer")[0])
		#arcpy.AddMessage(type(cnt))
		if cnt > 0:
		    messtxt = layname.encode('utf-8') + ' 図形：取得方法コード04' + ' : ' + str(cnt)
		    output(messtxt)
		arcpy.SelectLayerByAttribute_management("tmpLayer","CLEAR_SELECTION")

		#分類：取得方法コード05
		arcpy.SelectLayerByAttribute_management("tmpLayer","NEW_SELECTION","Attr11 = '05'")
		cnt = int(arcpy.GetCount_management("tmpLayer")[0])
		if cnt > 0:
		    messtxt = layname.encode('utf-8') + ' 分類：取得方法コード05' + ' : ' + str(cnt)
		    output(messtxt)
		arcpy.SelectLayerByAttribute_management("tmpLayer","CLEAR_SELECTION")

		
		#分類：取得方法コード06
		arcpy.SelectLayerByAttribute_management("tmpLayer","NEW_SELECTION","Attr11 = '06'")
		cnt = int(arcpy.GetCount_management("tmpLayer")[0])
		if cnt > 0:
		    messtxt = layname.encode('utf-8') + ' 分類：取得方法コード06' + ' : ' + str(cnt)
		    output(messtxt)
		arcpy.SelectLayerByAttribute_management("tmpLayer","CLEAR_SELECTION")

		#図形：取得方法コード06
		arcpy.SelectLayerByAttribute_management("tmpLayer","NEW_SELECTION","Attr12 = '06'")
		cnt = int(arcpy.GetCount_management("tmpLayer")[0])
		if cnt > 0:
		    messtxt = layname.encode('utf-8') + ' 図形：取得方法コード06' + ' : ' + str(cnt)
		    output(messtxt)
		arcpy.SelectLayerByAttribute_management("tmpLayer","CLEAR_SELECTION")

		#数量：取得方法コード08
		arcpy.SelectLayerByAttribute_management("tmpLayer","NEW_SELECTION","Attr13 = '08'")
		cnt = int(arcpy.GetCount_management("tmpLayer")[0])
		if cnt > 0:
		    messtxt = layname.encode('utf-8') + ' 数量：取得方法コード08' + ' : ' + str(cnt)
		    output(messtxt)
		arcpy.SelectLayerByAttribute_management("tmpLayer","CLEAR_SELECTION")

		arcpy.Delete_management('tmpLayer')

	# 例外を捕捉する
	except:
		arcpy.AddWarning(fl)
		arcpy.AddWarning(traceback.format_exc(sys.exc_info()[2]))
				
LogFile.close()

arcpy.AddMessage(u'処理終了')



