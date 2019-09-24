Option Strict Off
Option Explicit On
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'
	'�P�v���W�F�N�g���Ƃ̋��ʃ��C�u����
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(6 + 0 + 0 + 1) As clsCP
	Public CQ_SSSMAIN(6) As String
	
	'UPGRADE_WARNING: �\���� pm_All �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Public pm_All As Cls_All
	'INI�t�@�C���Ǎ��p�萔
	Public Const pc_strIni_OUTNAME As String = "OUT_NAME"
	Public Const pc_strIni_OUTTYPE As String = "OUT_TYPE"
	Public Const pc_strIni_TABCHAR As String = "TAB_CHAR"
	
	'INI�t�@�C���Ǎ����e�i�[�ϐ�
	Public gv_strOUT_NAME As String '�o�̓t�@�C����
	Public gv_strOUT_TYPE As String '�o�̓t�@�C���g���q
	Public gv_strTAB_CHAR As String '��؂蕶��
	
	Public Sub SSS_CLOSE()
		
	End Sub
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CopyFiles
	'   �T�v�F  �t�@�C���R�s�[����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@0 : ����I���@1 : �R�s�[�s��  8 : INI�t�@�C���G���[ 9 : �ُ�I��
	'   ���l�F�@��ʂɂĎw�肳�ꂽ�t�@�C����DB�T�[�o�[�̋K��̃t�H���_�Ɉړ�������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CopyFiles(ByVal strinfile As String, ByRef stroutfile As String) As Short
		
		'�t�@�C���I�u�W�F�N�g����
		Dim objfso As New Scripting.FileSystemObject
		Dim objoldFile As Scripting.File '���̃t�@�C���A�N�Z�X�p�I�u�W�F�N�g
		Dim strfile As String
		Dim strext As String
		Dim strSVfolder As String '�T�[�o�t�H���_��
		
		On Error GoTo F_Ctl_CopyFiles_Err
		
		'�T�[�o�̃t�H���_�����擾
		'strSVfolder = "\\ammfmtes\TES\"
		If Get_INIFile_String(My.Application.Info.DirectoryPath & IIf(Right(My.Application.Info.DirectoryPath, 1) = "\", "", "\") & SSS_PrgId & ".ini", "PATH", "ServerTXT", strSVfolder) Then
			If Len(strSVfolder) = 0 Then
				F_Ctl_CopyFiles = 8
				Exit Function
			End If
		Else
			F_Ctl_CopyFiles = 8
			Exit Function
		End If
		F_Ctl_CopyFiles = 9
		
		'�t�@�C�����擾
		objoldFile = objfso.GetFile(strinfile)
		stroutfile = strSVfolder & IIf(Right(strSVfolder, 1) = "\", "", "\") & objoldFile.NAME
		
		'�R�s�[��̃t�@�C�����݃`�F�b�N
		If objfso.FileExists(stroutfile) Then
			F_Ctl_CopyFiles = 1
			Exit Function
		End If
		
		
		'�t�@�C���R�s�[
		objoldFile.Copy(stroutfile, False)
		
		F_Ctl_CopyFiles = 0
		
F_Ctl_CopyFiles_End: 
		
		'UPGRADE_NOTE: �I�u�W�F�N�g objfso ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objfso = Nothing
		'UPGRADE_NOTE: �I�u�W�F�N�g objoldFile ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objoldFile = Nothing
		
		Exit Function
F_Ctl_CopyFiles_Err: 
		
		'UPGRADE_NOTE: �I�u�W�F�N�g objfso ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objfso = Nothing
		'UPGRADE_NOTE: �I�u�W�F�N�g objoldFile ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objoldFile = Nothing
		Exit Function
		
	End Function
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_CopyFiles2
	'   �T�v�F  �t�@�C���R�s�[����
	'   �����F  strinfile   �T�[�o�̃t�@�C����
	'           stroutFolder���[�J���̃t�H���_��
	'   �ߒl�F�@0 : ����I���@1 : �R�s�[�s��  8 : INI�t�@�C���G���[ 9 : �ُ�I��
	'   ���l�F�@DB�T�[�o�[�̋K��̃t�@�C������ʎw�肳�ꂽ�t�H���_�Ɉړ�������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CopyFiles2(ByRef strinfile As String, ByVal stroutFolder As String) As Short
		
		'�t�@�C���I�u�W�F�N�g����
		Dim objfso As New Scripting.FileSystemObject
		Dim objoldFile As Scripting.File '���̃t�@�C���A�N�Z�X�p�I�u�W�F�N�g
		Dim strfile As String
		Dim strext As String
		Dim strSVfolder As String '�T�[�o�t�H���_��
		Dim bolflg As Boolean
		
		On Error GoTo F_Ctl_CopyFiles_Err
		bolflg = False
		'�T�[�o�̃t�H���_�����擾
		'strSVfolder = "\\ammfmtes\TES\DAT\RCV"
		If Get_INIFile_String(My.Application.Info.DirectoryPath & IIf(Right(My.Application.Info.DirectoryPath, 1) = "\", "", "\") & SSS_PrgId & ".ini", "PATH", "ServerLOG", strSVfolder) Then
			If Len(strSVfolder) = 0 Then
				F_Ctl_CopyFiles2 = 8
				Exit Function
			End If
		Else
			F_Ctl_CopyFiles2 = 8
			Exit Function
		End If
		F_Ctl_CopyFiles2 = 9
		'�t�@�C�����擾
		strfile = Trim(strSVfolder & IIf(Right(strSVfolder, 1) = "\", "", "\") & strinfile)
		
		'�R�s�[���̃t�@�C�����݃`�F�b�N
		If objfso.FileExists(strfile) Then
			'�t�@�C���R�s�[
			objfso.CopyFile(strfile, stroutFolder & IIf(Right(stroutFolder, 1) = "\", "", "\") & Trim(strinfile))
			bolflg = True
		End If
		strinfile = strfile
		F_Ctl_CopyFiles2 = 0
		
F_Ctl_CopyFiles_End: 
		
		'UPGRADE_NOTE: �I�u�W�F�N�g objfso ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objfso = Nothing
		'UPGRADE_NOTE: �I�u�W�F�N�g objoldFile ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objoldFile = Nothing
		
		Exit Function
F_Ctl_CopyFiles_Err: 
		
		'UPGRADE_NOTE: �I�u�W�F�N�g objfso ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objfso = Nothing
		'UPGRADE_NOTE: �I�u�W�F�N�g objoldFile ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objoldFile = Nothing
		Exit Function
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Ctl_DeleteFiles
	'   �T�v�F  �t�@�C���폜����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@0 : ����I���@9 : �ُ�I��
	'   ���l�F�@DB�T�[�o�[�̋K��̃t�H���_����t�@�C�����폜����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_DeleteFiles(ByVal strfile As String) As Short
		
		Dim objfso As Scripting.FileSystemObject
		Dim objFile As Object '�w�b�_�t�@�C���A�N�Z�X�p�I�u�W�F�N�g
		
		On Error GoTo F_Ctl_DeleteFiles_Err
		
		F_Ctl_DeleteFiles = 9
		
		'�t�@�C���I�u�W�F�N�g����
		objfso = CreateObject("Scripting.FileSystemObject")
		
		'�w�b�_�t�@�C���폜
		If objfso.FileExists(strfile) Then
			objFile = objfso.GetFile(strfile)
			'UPGRADE_WARNING: �I�u�W�F�N�g objFile.Delete �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			objFile.Delete()
		End If
		
		
		F_Ctl_DeleteFiles = 0
		
F_Ctl_DeleteFiles_End: 
		
		'UPGRADE_NOTE: �I�u�W�F�N�g objfso ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objfso = Nothing
		'UPGRADE_NOTE: �I�u�W�F�N�g objFile ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objFile = Nothing
		
		Exit Function
		
F_Ctl_DeleteFiles_Err: 
		
		'UPGRADE_NOTE: �I�u�W�F�N�g objfso ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objfso = Nothing
		'UPGRADE_NOTE: �I�u�W�F�N�g objFile ���K�x�[�W �R���N�g����܂ł��̃I�u�W�F�N�g��j�����邱�Ƃ͂ł��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' ���N���b�N���Ă��������B
		objFile = Nothing
		
		Exit Function
		
	End Function
	'INI�t�@�C���̎擾
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function Get_INIFile_String
	'   �T�v�F  INI�t�@�C���̎擾
	'   �����F�@strFileName �t�@�C����
	'           strSection  �Z�N�V������
	'           strKey      �L�[��
	'           strValue    �擾�l
	'   �ߒl�F�@True : ����I���@False : �ُ�I��
	'   ���l�F�@�w��ini�t�@�C������w��̒l���擾����B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function Get_INIFile_String(ByVal strFileName As String, ByVal strSection As String, ByVal strKey As String, ByRef strValue As String) As Boolean
		'�o�b�t�@�������256�����ɐݒ�
		Dim strRetValue As New VB6.FixedLengthString(256)
		On Error GoTo err_Get_INIFile_String
		'INI�t�@�C������l���擾����B
		If GetPrivateProfileString(strSection, strKey, "", strRetValue.Value, Len(strRetValue.Value), strFileName) Then
			If InStr(strRetValue.Value, vbNullChar) > 0 Then
				strValue = Trim(Left(strRetValue.Value, InStr(strRetValue.Value, vbNullChar) - 1))
			Else
				strValue = Trim(strRetValue.Value)
			End If
			Get_INIFile_String = True
		Else
			Get_INIFile_String = False
		End If
		Exit Function
err_Get_INIFile_String: 
		Get_INIFile_String = False
	End Function
End Module