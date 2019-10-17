Option Strict Off
Option Explicit On
Module STTTOKCD_F67
	'
	'�X���b�g��      :���Ӑ�R�[�h�E��ʍ��ڃX���b�g
	'���j�b�g��      :STTTOKCD.F67
	'�L�q��          :Standard Library
	'�쐬���t        :2011/02/21
	'�g�p�v���O����  :THSFP61
	'
	'
	
	Function STTTOKCD_Check(ByVal STTTOKCD As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD_Check �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTOKCD_Check = 0
		Select Case FR_SSSMAIN.HD_THSCD.Text
			Case "0", "1", "2", "3"
                '2019/10/15 DEL START
                'Call TOKMTA_RClear()
                '2019/10/15 DEL START
                'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(STTTOKCD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If LenWid(STTTOKCD) = 0 Or Trim(STTTOKCD) = "" Then
                Else
                    '2019/10/15 DEL START
                    'Call DB_GetEq(DBN_TOKMTA, 1, STTTOKCD, BtrNormal)                    
                    '2019/10/15 DEL END
                    If DBSTAT = 0 Then
						If DB_TOKMTA.DATKB = "9" Then
                            '2019/10/15 DEL START
                            'Call TOKMTA_RClear()
                            '2019/10/15 DEL START
                        End If
					Else
                        '2019/10/15 DEL START
                        'Call TOKMTA_RClear()
                        '2019/10/15 DEL START
                    End If
				End If
			Case "4", "5"
                '2019/10/15 DEL START
                'Call SIRMTA_RClear()
                '2019/10/15 DEL END
                'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                'UPGRADE_WARNING: �I�u�W�F�N�g LenWid(STTTOKCD) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                If LenWid(STTTOKCD) = 0 Or Trim(STTTOKCD) = "" Then
                Else
                    '2019/10/15 DEL START
                    'Call DB_GetEq(DBN_SIRMTA, 1, STTTOKCD, BtrNormal)                    
                    '2019/10/15 DEL END
                    If DBSTAT = 0 Then
						If DB_SIRMTA.DATKB = "9" Then
                            '2019/10/15 DEL START
                            'Call SIRMTA_RClear()
                            '2019/10/15 DEL END
                        End If
					Else
                        '2019/10/15 DEL START
                        'Call SIRMTA_RClear()
                        '2019/10/15 DEL END
                    End If
				End If
		End Select
		
	End Function
	Function STTTOKCD_Slist(ByRef PP As clsPP, ByVal STTTOKCD As Object) As Object
		
		WGDENKB = FR_SSSMAIN.HD_THSCD.Text
		WGDENKB = IIf(WGDENKB = "9" Or WGDENKB = "0", "1", WGDENKB)
		WLS_THS1.ShowDialog()
		WLS_THS1.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTOKCD_Slist = PP.SlistCom
	End Function
	
	Function STTTOKCD_InitVal(ByVal STTTOKCD As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g STTTOKCD_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		STTTOKCD_InitVal = " "
	End Function
End Module