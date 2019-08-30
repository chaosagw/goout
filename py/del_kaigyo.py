#############
import arcpy, os, sys, traceback,datetime

# ���̓t�B�[�`�����C��
inFLs = arcpy.GetParameterAsText(0)

# ���O�t�@�C��
# LogPath = 'UR_CD_CK_' + datetime.datetime.now().strftime('%Y%m%d%H%M%S') + '.log'
# LogPath = os.path.join(inOutPath,LogPath)
# 
# LogFile = open(LogPath,'w')
# 
# 
# def output(txt):
# 	arcpy.AddMessage(txt)
# 	LogFile.writelines(txt + '\n')
# 
# def outputW(txt):
# 	arcpy.AddWarning(txt)
# 	LogFile.writelines(txt.replace('\t\t','\t') + '\n')
	
# ���͂��ꂽ�t�B�[�`�����C�������Ԃɏ�������
for fl in inFLs.split(';'):
	try:
		layname = os.path.basename(fl)
		
		desc = arcpy.Describe(fl)
		ds = desc.catalogPath

		arcpy.AddMessage(fl)
		result = arcpy.GetCount_management(ds)
		
		arcpy.MakeFeatureLayer_management(ds,"tmpLayer")
		cnt = int(arcpy.GetCount_management("tmpLayer")[0])
		if cnt > 0:
			fields = arcpy.ListFields("tmpLayer")
			for i in range(2,len(fields),1):
				if fields[i].type == "String":
					exp = "!" + fields[i].name + "!.strip()"
					#arcpy.AddMessage(exp)
					arcpy.CalculateField_management("tmpLayer", fields[i].name, exp, "PYTHON_9.3")

		arcpy.Delete_management('tmpLayer')

	# ��O��ߑ�����
	except:
		arcpy.AddWarning(fl)
		arcpy.AddWarning(traceback.format_exc(sys.exc_info()[2]))
				

arcpy.AddMessage(u'�����I��')




