Option Strict Off
Option Explicit On
'20190718 CHG START
'Module URISETDT_F51
'	'
'	' �X���b�g��        : �̔��P���ݒ���t�E��ʍ��ڃX���b�g
'	' ���j�b�g��        : URISETDT.F51
'	' �L�q��            : Standard Library
'	' �쐬���t          : 2006/06/14
'	' �g�p�v���O������  : HINMT51
'	'
'	Function URISETDT_Check(ByVal URISETDT As Object, ByVal SKHINGRP As Object, ByVal RNKCD As Object, ByVal De_INDEX As Object) As Object
'		Dim rtn As Short
'		'
'		'UPGRADE_WARNING: �I�u�W�F�N�g SKHINGRP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'		If Trim(SKHINGRP) = "" Then Exit Function

'		'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'		URISETDT_Check = 0
'		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
'		If IsDbNull(URISETDT) Then
'			rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' ���t�Ɍ�肪����܂�
'			'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'			URISETDT_Check = -1

'		Else
'			If Not IsDate(URISETDT) Then
'				rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' ���t�Ɍ�肪����܂�
'				'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'				URISETDT_Check = -1
'				'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'				URISETDT = ""
'			Else
'				'�ŐV�f�[�^��������
'				'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'				If CInt(VB6.Format(URISETDT, "YYYYMMDD")) < CInt(DB_UNYMTA.UNYDT) Then
'					'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'					'UPGRADE_WARNING: �I�u�W�F�N�g RNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'					'UPGRADE_WARNING: �I�u�W�F�N�g SKHINGRP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'					Call DB_GetGrEq(DBN_RNKMTA, 1, SKHINGRP & RNKCD & VB6.Format(URISETDT, "YYYYMMDD"), BtrNormal)
'					'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'					'UPGRADE_WARNING: �I�u�W�F�N�g RNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'					'UPGRADE_WARNING: �I�u�W�F�N�g SKHINGRP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'					If (DBSTAT = 0) And (DB_RNKMTA.SKHINGRP = SKHINGRP) And (DB_RNKMTA.RNKCD = RNKCD) And (DB_RNKMTA.URISETDT > VB6.Format(URISETDT, "YYYYMMDD")) Then
'						rtn = DSP_MsgBox(SSS_CONFRM, "TOKMT55", 0) '���ɐV�������t�œo�^�ς̈׃G���[
'						'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'						URISETDT_Check = -1
'					End If
'				End If
'			End If
'		End If

'		'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'		If URISETDT_Check = 0 Then
'			'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'			'UPGRADE_WARNING: �I�u�W�F�N�g RNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'			'UPGRADE_WARNING: �I�u�W�F�N�g SKHINGRP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'			Call DB_GetEq(DBN_RNKMTA, 1, SKHINGRP & RNKCD & VB6.Format(URISETDT, "YYYYMMDD"), BtrNormal)
'			If DBSTAT = 0 Then
'				'UPGRADE_WARNING: �I�u�W�F�N�g De_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'				Call SCR_FromMfil(De_INDEX)
'				If DB_RNKMTA.DATKB = "9" Then
'					'UPGRADE_WARNING: �I�u�W�F�N�g De_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'					Call DP_SSSMAIN_UPDKB(De_INDEX, "�폜")
'				Else
'					'UPGRADE_WARNING: �I�u�W�F�N�g De_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'					Call DP_SSSMAIN_UPDKB(De_INDEX, "�X�V")
'				End If
'			Else
'				'UPGRADE_WARNING: �I�u�W�F�N�g De_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'				Call DP_SSSMAIN_UPDKB(De_INDEX, "�ǉ�")
'			End If
'		End If

'	End Function

'	Function URISETDT_Skip(ByRef CT_URISETDT As System.Windows.Forms.Control, ByVal URISETDT As Object) As Object
'		'
'		'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'		If Trim(URISETDT) <> "" Then
'            'UPGRADE_WARNING: �I�u�W�F�N�g CT_URISETDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'            '20190718 CHG START
'            'CT_URISETDT.SelStart = 8 'yyyy-mm-dd �� dd �ɃJ�[�\�����ړ�����B
'            DirectCast(CT_URISETDT, TextBox).SelectionStart = 8 'yyyy-mm-dd �� dd �ɃJ�[�\�����ړ�����B
'            '20190718 CHG END
'        End If
'		'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'		URISETDT_Skip = False
'	End Function

'	Function URISETDT_Slist(ByVal URISETDT As Object, ByRef PP As clsPP) As Object
'		'
'		'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'		Set_date.Value = URISETDT
'		WLS_DATE.ShowDialog()
'		WLS_DATE.Close()
'		'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
'		URISETDT_Slist = Set_date.Value
'	End Function
'End Module
Module URISETDT_F51
    '
    ' �X���b�g��        : �̔��P���ݒ���t�E��ʍ��ڃX���b�g
    ' ���j�b�g��        : URISETDT.F51
    ' �L�q��            : Standard Library
    ' �쐬���t          : 2006/06/14
    ' �g�p�v���O������  : HINMT51
    '
    Function URISETDT_Check(ByVal URISETDT As Object, ByVal SKHINGRP As Object, ByVal RNKCD As Object, ByVal De_INDEX As Object) As Object
        Dim rtn As Short
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g SKHINGRP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(SKHINGRP) = "" Then Exit Function

        'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        URISETDT_Check = 0
        'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
        If IsDBNull(URISETDT) Then
            rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' ���t�Ɍ�肪����܂�
            'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            URISETDT_Check = -1

        Else
            If Not IsDate(URISETDT) Then
                rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' ���t�Ɍ�肪����܂�
                'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                URISETDT_Check = -1
                'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                URISETDT = ""
            Else
                '�ŐV�f�[�^��������
                'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If CInt(VB6.Format(URISETDT, "YYYYMMDD")) < CInt(DB_UNYMTA.UNYDT) Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g SKHINGRP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    Call DB_GetGrEq(DBN_RNKMTA2, 1, SKHINGRP & RNKCD & VB6.Format(URISETDT, "YYYYMMDD"), BtrNormal)
                    'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g RNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    'UPGRADE_WARNING: �I�u�W�F�N�g SKHINGRP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    If (DBSTAT = 0) And (DB_RNKMTA2.SKHINGRP = SKHINGRP) And (DB_RNKMTA2.RNKCD = RNKCD) And (DB_RNKMTA2.URISETDT > VB6.Format(URISETDT, "YYYYMMDD")) Then
                        rtn = DSP_MsgBox(SSS_CONFRM, "TOKMT55", 0) '���ɐV�������t�œo�^�ς̈׃G���[
                        'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                        URISETDT_Check = -1
                    End If
                End If
            End If
        End If

        'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If URISETDT_Check = 0 Then
            'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g RNKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            'UPGRADE_WARNING: �I�u�W�F�N�g SKHINGRP �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Call DB_GetEq(DBN_RNKMTA2, 1, SKHINGRP & RNKCD & VB6.Format(URISETDT, "YYYYMMDD"), BtrNormal)
            If DBSTAT = 0 Then
                'UPGRADE_WARNING: �I�u�W�F�N�g De_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Call SCR_FromMfil(De_INDEX)
                If DB_RNKMTA2.DATKB = "9" Then
                    'UPGRADE_WARNING: �I�u�W�F�N�g De_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    Call DP_SSSMAIN_UPDKB(De_INDEX, "�폜")
                Else
                    'UPGRADE_WARNING: �I�u�W�F�N�g De_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    Call DP_SSSMAIN_UPDKB(De_INDEX, "�X�V")
                End If
            Else
                'UPGRADE_WARNING: �I�u�W�F�N�g De_INDEX �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                Call DP_SSSMAIN_UPDKB(De_INDEX, "�ǉ�")
            End If
        End If

    End Function

    Function URISETDT_Skip(ByRef CT_URISETDT As System.Windows.Forms.Control, ByVal URISETDT As Object) As Object
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(URISETDT) <> "" Then
            'UPGRADE_WARNING: �I�u�W�F�N�g CT_URISETDT.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '20190718 CHG START
            'CT_URISETDT.SelStart = 8 'yyyy-mm-dd �� dd �ɃJ�[�\�����ړ�����B
            DirectCast(CT_URISETDT, TextBox).SelectionStart = 8 'yyyy-mm-dd �� dd �ɃJ�[�\�����ړ�����B
            '20190718 CHG END
        End If
        'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        URISETDT_Skip = False
    End Function

    Function URISETDT_Slist(ByVal URISETDT As Object, ByRef PP As clsPP) As Object
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        Set_date.Value = URISETDT
        WLS_DATE.ShowDialog()
        WLS_DATE.Close()
        'UPGRADE_WARNING: �I�u�W�F�N�g URISETDT_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        URISETDT_Slist = Set_date.Value
    End Function
End Module
'20190718 CHG END