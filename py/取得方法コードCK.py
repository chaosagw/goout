#############
import arcpy, os, sys, traceback,datetime

# ���̓t�B�[�`�����C��
inFLs = arcpy.GetParameterAsText(0)
inOutPath = arcpy.GetParameterAsText(1)

# ���O�t�@�C��
LogPath = 'UR_CD_CK_' + datetime.datetime.now().strftime('%Y%m%d%H%M%S') + '.log'
LogPath = os.path.join(inOutPath,LogPath)

LogFile = open(LogPath,'w')


def output(txt):
	arcpy.AddMessage(txt)
	LogFile.writelines(txt + '\n')

def outputW(txt):
	arcpy.AddWarning(txt)
	LogFile.writelines(txt.replace('\t\t','\t') + '\n')
	
# ���͂��ꂽ�t�B�[�`�����C�������Ԃɏ�������
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
		#�}�`�F�擾���@�R�[�h04
		arcpy.SelectLayerByAttribute_management("tmpLayer","NEW_SELECTION","Attr12 = '04'")
		cnt = int(arcpy.GetCount_management("tmpLayer")[0])
		#arcpy.AddMessage(type(cnt))
		if cnt > 0:
		    messtxt = layname.encode('utf-8') + ' �}�`�F�擾���@�R�[�h04' + ' : ' + str(cnt)
		    output(messtxt)
		arcpy.SelectLayerByAttribute_management("tmpLayer","CLEAR_SELECTION")

		#���ށF�擾���@�R�[�h05
		arcpy.SelectLayerByAttribute_management("tmpLayer","NEW_SELECTION","Attr11 = '05'")
		cnt = int(arcpy.GetCount_management("tmpLayer")[0])
		if cnt > 0:
		    messtxt = layname.encode('utf-8') + ' ���ށF�擾���@�R�[�h05' + ' : ' + str(cnt)
		    output(messtxt)
		arcpy.SelectLayerByAttribute_management("tmpLayer","CLEAR_SELECTION")

		
		#���ށF�擾���@�R�[�h06
		arcpy.SelectLayerByAttribute_management("tmpLayer","NEW_SELECTION","Attr11 = '06'")
		cnt = int(arcpy.GetCount_management("tmpLayer")[0])
		if cnt > 0:
		    messtxt = layname.encode('utf-8') + ' ���ށF�擾���@�R�[�h06' + ' : ' + str(cnt)
		    output(messtxt)
		arcpy.SelectLayerByAttribute_management("tmpLayer","CLEAR_SELECTION")

		#�}�`�F�擾���@�R�[�h06
		arcpy.SelectLayerByAttribute_management("tmpLayer","NEW_SELECTION","Attr12 = '06'")
		cnt = int(arcpy.GetCount_management("tmpLayer")[0])
		if cnt > 0:
		    messtxt = layname.encode('utf-8') + ' �}�`�F�擾���@�R�[�h06' + ' : ' + str(cnt)
		    output(messtxt)
		arcpy.SelectLayerByAttribute_management("tmpLayer","CLEAR_SELECTION")

		#���ʁF�擾���@�R�[�h08
		arcpy.SelectLayerByAttribute_management("tmpLayer","NEW_SELECTION","Attr13 = '08'")
		cnt = int(arcpy.GetCount_management("tmpLayer")[0])
		if cnt > 0:
		    messtxt = layname.encode('utf-8') + ' ���ʁF�擾���@�R�[�h08' + ' : ' + str(cnt)
		    output(messtxt)
		arcpy.SelectLayerByAttribute_management("tmpLayer","CLEAR_SELECTION")

		arcpy.Delete_management('tmpLayer')

	# ��O��ߑ�����
	except:
		arcpy.AddWarning(fl)
		arcpy.AddWarning(traceback.format_exc(sys.exc_info()[2]))
				
LogFile.close()

arcpy.AddMessage(u'�����I��')



