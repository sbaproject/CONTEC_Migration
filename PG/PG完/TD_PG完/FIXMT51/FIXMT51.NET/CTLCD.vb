Option Strict Off
Option Explicit On
Module CTLCD_F51
	'
	'�X���b�g��      :�Ǘ��R�[�h�o�^�E��ʍ��ڃX���b�g
	'���j�b�g��      :CTLCD.F51
	'�L�q��          :Standard Library
	'�쐬���t        :2006/08/10
	'�g�p�v���O����  :FIXMT51
	'
	
	Function CTLCD_Check(ByVal CTLCD As Object, ByVal De_Index As Object) As Object
		Dim Rtn As Short
		Dim wkCTLCD As String
		Call FIXMTA_RClear()
		'UPGRADE_WARNING: �I�u�W�F�N�g CTLCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CTLCD_Check = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g CTLCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(CTLCD) = "" Then
			'CTLCD_Check = -1
		Else
            'UPGRADE_WARNING: �I�u�W�F�N�g CTLCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            '20190801 chg start
            'wkCTLCD = CTLCD & Space(Len(DB_FIXMTA.CTLCD) - Len(CTLCD))
            wkCTLCD = CTLCD & Space(Len(DB_FIXMTA2.CTLCD) - Len(CTLCD))
            '20190801 chg end
            Call DB_GetEq(DBN_FIXMTA, 1, wkCTLCD, BtrNormal)
			If DBSTAT = 0 Then
                '20190801 chg start
                'If DB_FIXMTA.DATKB = "9" Then
                If DB_FIXMTA2.DATKB = "9" Then
                    '20190801 chg end
                    Call Dsp_Prompt("RNOTFOUND", 1) ' �폜�σ��R�[�h�ł��B
                Else
                    '�v�����v�g���������F�ɖ߂��B
                    CType(FR_SSSMAIN.Controls("TX_Message"), Object).ForeColor = SSSMSG_BAS.Cn_BLACK
				End If
				'UPGRADE_WARNING: �I�u�W�F�N�g De_Index �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call SCR_FromMfil(De_Index)
			Else
				Call Dsp_Prompt("RNOTFOUND", 0)
			End If
		End If
	End Function
	
	Function CTLCD_Slist(ByRef PP As clsPP, ByVal CTLCD As Object) As Object
		'
		'    WLS_LIST.Caption = "�Œ�l�ꗗ"
		'    WLS_LIST!LST.Clear
		'    Call DB_GetFirst(DBN_FIXMTA, 1, BtrNormal)
		'    Do While DBSTAT = 0
		'        'If DB_FIXMTA.DATKB <> "9" Then WLS_LIST!LST.AddItem DB_FIXMTA.CTLCD & " " & DB_FIXMTA.CTLNM & " " & DB_FIXMTA.FIXVAL
		'        WLS_LIST!LST.AddItem DB_FIXMTA.CTLCD & " " & DB_FIXMTA.CTLNM & " " & DB_FIXMTA.FIXVAL
		'        Call DB_GetNext(DBN_FIXMTA, BtrNormal)
		'    Loop
		'    SSS_WLSLIST_KETA = LenWid(DB_FIXMTA.CTLCD)
		'    WLS_LIST.Show 1
		'    Unload WLS_LIST
		'    CTLCD_Slist = PP.SlistCom
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CTLCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(CTLCD_Slist) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CTLCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g CTLCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			CTLCD_Slist = CTLCD
		End If
	End Function
End Module