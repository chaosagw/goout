#############
import arcpy, os, sys, traceback,datetime

# ���̓t�B�[�`�����C��
inFLs = arcpy.GetParameterAsText(0)
inOutPath = arcpy.GetParameterAsText(1)

# ���O�t�@�C��
LogPath = 'UR_FC_Count_' + datetime.datetime.now().strftime('%Y%m%d%H%M%S') + '.log'
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
		fields = arcpy.ListFields("tmpLayer")
		flds_list = []
		for fld in fields:
			flds_list.append(fld.name)
		#arcpy.AddMessage(flds_list)
		if 'Attr25' in flds_list:

			#���m��t���O00
			arcpy.SelectLayerByAttribute_management("tmpLayer","NEW_SELECTION","Attr25 = '00'")
			cnt = arcpy.GetCount_management("tmpLayer")
			messtxt = layname.encode('utf-8') + ' ���m��t���O00' + ' : ' + cnt[0].encode('utf-8')
			output(messtxt)
			arcpy.SelectLayerByAttribute_management("tmpLayer","CLEAR_SELECTION")

			#���m��t���O01
			arcpy.SelectLayerByAttribute_management("tmpLayer","NEW_SELECTION","Attr25 = '01'")
			cnt = arcpy.GetCount_management("tmpLayer")
			messtxt = layname.encode('utf-8') + ' ���m��t���O01' + ' : ' + cnt[0].encode('utf-8')
			output(messtxt)
			arcpy.SelectLayerByAttribute_management("tmpLayer","CLEAR_SELECTION")

			#���m��t���O02
			arcpy.SelectLayerByAttribute_management("tmpLayer","NEW_SELECTION","Attr25 = '02'")
			cnt = arcpy.GetCount_management("tmpLayer")
			messtxt = layname.encode('utf-8') + ' ���m��t���O02' + ' : ' + cnt[0].encode('utf-8')
			output(messtxt)
			arcpy.SelectLayerByAttribute_management("tmpLayer","CLEAR_SELECTION")


		else:
			messtxt = layname.encode('utf-8') + ' : ' + result[0].encode('utf-8')
			output(messtxt)
		
		arcpy.Delete_management('tmpLayer')

	# ��O��ߑ�����
	except:
		arcpy.AddWarning(fl)
		arcpy.AddWarning(traceback.format_exc(sys.exc_info()[2]))
				
LogFile.close()

arcpy.AddMessage(u'�����I��')

