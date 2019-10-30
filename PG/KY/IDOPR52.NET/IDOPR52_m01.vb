Option Strict Off
Option Explicit On
Module IDOPR52_M01
	'
	' �X���b�g��        : �N���C�A���g�ʎ󒍓��L���E���C���t�@�C���X�V�X���b�g
	' ���j�b�g��        : IDOPR52.M01
	' �L�q��            : Standard Library
	' �쐬���t          : 1998/02/24
	' �g�p�v���O������  : IDOPR52
	'
	
	Function CHK_LCTL() As Short
	End Function
	
	Function ENDCHK() As Short
	End Function
	
	Sub Loop_Mfil()
		Dim PlStat As Short
		
		G_PlCnd.sCndStr(0) = SSS_CLTID.Value
		G_PlCnd.sCndStr(1) = DeCNV_DATE((FR_SSSMAIN.HD_DENDT).Text)
		G_PlCnd.sCndStr(2) = FR_SSSMAIN.HD_PRTKB.Text
		G_PlCnd.sCndStr(3) = FR_SSSMAIN.HD_PRTSB.Text '2006.11.10
		
		G_PlCnd.sCltID = SSS_CLTID.Value
		G_PlInfo.FCnt = 1
		G_PlInfo.Fno(0) = DBN_IDOPR52
		G_PlInfo.RCnt(0) = 1
		G_PlInfo.ArrayFlg(0) = 0
		'
		Call Mfil_FromSCR(-1)
		'
		PlStat = DB_PlStart
		PlStat = DB_PlCndSet
		PlStat = DB_PlSet(DBN_IDOPR52, 0)
		'
		'    PlStat = DB_PlExec(Get_EntryToPackage())
		PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_" & SSS_PrgId)
		If PlStat <> 0 And PlStat <> 1485 Then
			MsgBox("PL/SQL Error�F" & PlStat)
		Else
			SSS_LFILCNT = G_PlCnd2.nCndNum(0)
			If SSS_LFILCNT > 0 Then
				Call CNT_GAUGE()
			End If
			'����ɏI��܂����B
			'CRW�ŏo�͉�
		End If
		PlStat = DB_PlFree
	End Sub
	
	Function NEXTCHK() As Short
	End Function
	
	Function NPSNCHK() As Short
	End Function
	
	Function RPSNCHK() As Short
	End Function
	
	Function SEL_RECORD() As String
	End Function
	
	Sub Set_Value()
	End Sub
    '2019/10/25 DEL START
    '    Public Function AnsiTrimStringByByteCount(ByRef ArgSrc As String, ByRef ArgCnt As Integer) As String
    '        '�T�v�F�S�p���p�܂���̂t�����b��������������A   ��������
    '        '                   ����������Ȃ��悤�Ɏw�肳�ꂽ�o�C�g���Ɋۂ߂��������Ԃ��B
    '        '                                                 ��������
    '        '�����FArgSrc ,Input ,String ,���̕�����
    '        '�@�@�FArgCnt ,Input ,Long   ,�ۂ߂镶����

    '        Dim strResult As String
    '        Dim strTmpChr As String
    '        Dim lngLength As Integer
    '        Dim lngCalCnt As Integer
    '        Dim lngTmpCnt As Integer
    '        Dim lngI As Integer


    '        strResult = ""
    '        lngLength = Len(Trim(ArgSrc))
    '        lngCalCnt = 0
    '        For lngI = 1 To lngLength
    '            strTmpChr = Mid(ArgSrc, lngI, 1)
    '            lngTmpCnt = AnsiLenB(strTmpChr)
    '            If lngCalCnt + lngTmpCnt > ArgCnt Then
    '                GoTo AnsiTrimStringByByteCount_End
    '            Else
    '                lngCalCnt = lngCalCnt + lngTmpCnt
    '                strResult = strResult & strTmpChr
    '            End If
    '        Next

    'AnsiTrimStringByByteCount_End:

    '        If AnsiLenB(strResult) < ArgCnt Then
    '            AnsiTrimStringByByteCount = strResult & New String(" ", ArgCnt - AnsiLenB(strResult))
    '        Else
    '            AnsiTrimStringByByteCount = strResult
    '        End If

    '    End Function
    '2019/10/25 DEL START
    '2019/10/25 DEL START
    '    Public Function AnsiTrimStringByMojiCount(ByRef strSrc As String, ByRef lngDstCount As Integer) As String
    '        '�T�v�F�S�p���p�܂���̂t�����b��������������A   ������
    '        '                   ����������Ȃ��悤�Ɏw�肳�ꂽ�������i���o�C�g���j�Ɋۂ߂��������Ԃ��B
    '        '                                                 ������
    '        '�����FstrSrc     ,Input,String,���̕�����
    '        '�@�@�FlngDstCount,Input,Long,�ۂ߂镶����
    '        Dim strDst As String
    '        Dim strTmp As String
    '        Dim lngSrcCount As Integer
    '        Dim lngCalCount As Integer
    '        Dim lngTmpCount As Integer
    '        Dim strFmt As String
    '        Dim lngI As Integer

    '        strDst = ""
    '        lngSrcCount = Len(strSrc)
    '        lngCalCount = 0
    '        For lngI = 1 To lngSrcCount
    '            strTmp = Mid(strSrc, lngI, 1)
    '            lngTmpCount = AnsiLenB(strTmp)
    '            If lngCalCount + lngTmpCount > lngDstCount Then
    '                GoTo AnsiTrimStringByMojiCount_End
    '            Else
    '                lngCalCount = lngCalCount + lngTmpCount
    '                strDst = strDst & strTmp
    '            End If
    '        Next

    'AnsiTrimStringByMojiCount_End:

    '        strFmt = "!"
    '        For lngI = 1 To lngDstCount
    '            strFmt = strFmt & "@"
    '        Next
    '        strDst = VB6.Format(strDst, strFmt)
    '        AnsiTrimStringByMojiCount = strDst

    '    End Function
    '2019/10/25 DEL E N D
    '2019/10/25 DEL START
    '    Public Function AnsiInStrB(ByRef varArg1 As Object, ByRef varArg2 As Object, Optional ByRef varArg3 As Object = Nothing) As Integer
    '        '�T�v�F������ʒu�̌���
    '        '�����FvarArg1,Input,Variant,�����J�n�ʒu or �����Ώە�����
    '        '�@�@�FvarArg2,Input,Variant,����������
    '        '�@�@�FvarArg3,Input,Variant(Optional),����������(�ȗ��\)
    '        '�����`�������R�[�h�̃o�C�g�I�[�_�Ō���������̕����ʒu(������)��Ԃ�
    '        Dim lngPos As Integer

    '#If Win32 Then
    '        If IsNumeric(varArg1) Then
    '            'UPGRADE_WARNING: �I�u�W�F�N�g varArg1 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            'UPGRADE_WARNING: �I�u�W�F�N�g varArg2 �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '            lngPos = LenB(AnsiLeftB(varArg2, varArg1))
    '            'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '            'UPGRADE_ISSUE: InStrB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '            AnsiInStrB = InStrB(varArg1, AnsiStrConv(varArg2, vbFromUnicode), AnsiStrConv(varArg3, vbFromUnicode))
    '        Else
    '            'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '            'UPGRADE_ISSUE: InStrB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '            AnsiInStrB = InStrB(AnsiStrConv(varArg1, vbFromUnicode), AnsiStrConv(varArg2, vbFromUnicode))
    '        End If
    '#Else
    '		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
    '		If IsNumeric(varArg1) Then
    '		lngPos = LenB(LeftB(varArg2, varArg1))
    '		AnsiInStrB = InStrB(varArg1, varArg2, varArg3)
    '		Else
    '		AnsiInStrB = InStrB(varArg1, varArg2)
    '		End If
    '#End If

    '    End Function
    '2019/10/25 DEL E N D
    '2019/10/25 DEL START
    '    Public Function AnsiLeftB(ByVal strArg As String, ByVal lngArg As Integer) As String
    '        '�T�v�F���l�ߕ�����̒��o
    '        '�����FstrArg,Input,String,���o��������
    '        '�@�@�FlngArg,Input,Long,���o������
    '        '�����F�`�������R�[�h�̃o�C�g�I�[�_�ŕ�����̍��[���當�������̕������Ԃ�

    '#If Win32 Then
    '        'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '        'UPGRADE_ISSUE: LeftB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '        'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(strArg, vbFromUnicode), lngArg), vbUnicode)
    '#Else
    '		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
    '		AnsiLeftB = LeftB(strArg, lngArg)
    '#End If

    '    End Function
    '2019/10/25 DEL E N D
    '2019/10/25 DEL START
    '    Public Function AnsiLenB(ByVal strArg As String) As Integer
    '        '�T�v�F�������J�E���g
    '        '�����FstrArg,Input,String,�Ώە�����
    '        '�����F�`�������R�[�h�̃o�C�g�I�[�_�ŕ�������޲Đ���Ԃ�

    '#If Win32 Then
    '        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '        'UPGRADE_ISSUE: LenB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '        AnsiLenB = LenB(AnsiStrConv(strArg, vbFromUnicode))
    '#Else
    '		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
    '		AnsiLenB = LenB(strArg)
    '#End If

    '    End Function
    '2019/10/25 DEL E N D
    '2019/10/25 DEL START
    '    Public Function AnsiMidB(ByVal strArg As String, ByVal lngArg As Integer, Optional ByRef varArg As Object = Nothing) As String
    '        '�T�v�F������̒��o
    '        '�����FstrArg,Input,String,���o��������
    '        '�@�@�FlngArg,Input,Long,�擪����̒��o�J�n�ʒu
    '        '�@�@�FvarArg,Input,Variant(Optional),���o������(�ȗ��\)
    '        '�����F�`�������R�[�h�̃o�C�g�I�[�_�ŕ�����̒��o�J�n�ʒu���當�������̕������Ԃ�

    '#If Win32 Then
    '        'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
    '        If IsNothing(varArg) Then
    '            'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '            'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '            'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '            'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(strArg, vbFromUnicode), lngArg), vbUnicode)
    '        Else
    '            'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '            'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '            'UPGRADE_ISSUE: MidB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '            'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '            AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(strArg, vbFromUnicode), lngArg, varArg), vbUnicode)
    '        End If
    '#Else
    '		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
    '		If IsMissing(varArg) Then
    '		AnsiMidB = MidB(strArg, lngArg)
    '		Else
    '		AnsiMidB = MidB(strArg, lngArg, varArg)
    '		End If
    '#End If

    '    End Function
    '2019/10/25 DEL E N D
    '2019/10/25 DEL START
    '    Public Function AnsiRightB(ByVal strArg As String, ByVal lngArg As Integer) As String
    '        '�T�v�F�E�l�ߕ�����̒��o
    '        '�����FstrArg,Input,String,���o��������
    '        '�@�@�FlngArg,Input,Long,���o������
    '        '�����F�`�������R�[�h�̃o�C�g�I�[�_�ŕ�����̉E�[���當�������̕������Ԃ�

    '#If Win32 Then
    '        'UPGRADE_ISSUE: �萔 vbUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '        'UPGRADE_ISSUE: �萔 vbFromUnicode �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' ���N���b�N���Ă��������B
    '        'UPGRADE_ISSUE: RightB �֐��̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"' ���N���b�N���Ă��������B
    '        'UPGRADE_WARNING: �I�u�W�F�N�g AnsiStrConv() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
    '        AnsiRightB = AnsiStrConv(RightB(AnsiStrConv(strArg, vbFromUnicode), lngArg), vbUnicode)
    '#Else
    '		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
    '		AnsiRightB = RightB(strArg, lngArg)
    '#End If

    '    End Function
    '2019/10/25 DEL E N D

    Public Function AnsiStrConv(ByRef varArg As Object, ByRef varCnv As Object) As Object
		'�T�v�F������̺��ޕϊ�
		'�����FvarArg,Input,Variant,�ϊ���������
		'�@�@�FvarCnv,Input,Variant,conversion�萔(StrConv �֐��Q��)
		'�����F�`������ �� �t�����b�������ɕϊ������������Ԃ�
		
#If Win32 Then
		'UPGRADE_WARNING: �I�u�W�F�N�g varCnv �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g varArg �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		AnsiStrConv = StrConv(varArg, varCnv)
#Else
		'UPGRADE_NOTE: �� Else �� True �ɕ]������Ȃ��������A�܂��͂܂������]������Ȃ��������߁A#If #EndIf �u���b�N�̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"' ���N���b�N���Ă��������B
		AnsiStrConv = varArg
#End If
		
	End Function
End Module