Option Strict Off
Option Explicit On
Module ENDTOKNM_F61
	'
	' �X���b�g��        : ���Ӑ於�́E��ʍ��ڃX���b�g
	' ���j�b�g��        : ENDTOKNM.F61
	' �L�q��            : Standard Library
	' �쐬���t          : 2011/02/21
	' �g�p�v���O������  : THSFP61
	'
	
	Function ENDTOKNM_Derived(ByVal ENDTOKNM As Object, ByVal ENDTOKCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ENDTOKNM_Derived = ""
        'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(ENDTOKCD) = "" Then
            DB_TOKMTA.TOKRN = " "
        Else
            '2019/10/15 DEL START
            'Call TOKMTA_RClear()
            'Call DB_GetEq(DBN_TOKMTA, 1, ENDTOKCD, BtrNormal)
            '2019/10/15 DEL END
            If DBSTAT = 0 Then
                If DB_TOKMTA.DATKB = "9" Then
                    '2019/10/15 DEL START
                    'Call TOKMTA_RClear()
                    '2019/10/15 DEL END
                End If
                'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                ENDTOKNM_Derived = DB_TOKMTA.TOKRN
            Else
                '2019/10/15 DEL START
                'Call TOKMTA_RClear()
                'Call SIRMTA_RClear()                
                'Call DB_GetEq(DBN_SIRMTA, 1, ENDTOKCD, BtrNormal)
                '2019/10/15 DEL END
                If DBSTAT = 0 Then
                    If DB_SIRMTA.DATKB = "9" Then
                        '2019/10/15 DEL START
                        'Call SIRMTA_RClear()
                        '2019/10/15 DEL END
                    End If
                    'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKNM_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
                    ENDTOKNM_Derived = DB_SIRMTA.SIRRN
				Else
                    '2019/10/15 DEL START
                    'Call SIRMTA_RClear()
                    '2019/10/15 DEL END
                End If
			End If
		End If
	End Function
	
	Function ENDTOKNM_InitVal(ByVal ENDTOKNM As Object, ByVal ENDTOKCD As Object, ByVal De_Index As Object) As Object
		
		Select Case FR_SSSMAIN.HD_THSCD.Text
			Case "0", "1", "2", "3"
				'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(ENDTOKCD) = "" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g FillVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ENDTOKNM_InitVal = FillVal(" ", LenWid(DB_TOKMTA.TOKRN))
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKNM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ENDTOKNM_InitVal = DB_TOKMTA.TOKRN
				End If
			Case "4", "5"
				'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(ENDTOKCD) = "" Then
					'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g FillVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ENDTOKNM_InitVal = FillVal(" ", LenWid(DB_SIRMTA.SIRRN))
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g ENDTOKNM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ENDTOKNM_InitVal = DB_SIRMTA.SIRRN
				End If
		End Select
		
	End Function
End Module