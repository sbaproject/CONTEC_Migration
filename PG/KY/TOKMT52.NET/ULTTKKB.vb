Option Strict Off
Option Explicit On
Module ULTTKKB_F51
	'
	' �X���b�g��        : ۯĒP���敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : ULTTKKB.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/06/21
	' �g�p�v���O������  : TOKMT54
	'
	
	Function ULTTKKB_CheckC(ByRef ULTTKKB As Object, ByVal HINCD As Object, ByVal De_Index As Short) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(HINCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ULTTKKB = ""
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ULTTKKB_CheckC = 0
			'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Select Case Trim(ULTTKKB)
				Case ""
					'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ULTTKKB = 9
				Case CStr(1)
					'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ULTTKKB = 1
				Case CStr(9)
					'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ULTTKKB = 9
				Case Else
					'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ULTTKKB = 9
			End Select
			
		End If
	End Function
	Function ULTTKKB_InitVal(ByVal HINCD As Object, ByVal ULTTKKB As Object, ByVal De_Index As Short) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(HINCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ULTTKKB_InitVal = " "
			Exit Function
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(ULTTKKB) = "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				ULTTKKB_InitVal = 9
			End If
		End If
		
	End Function
	Function ULTTKKB_DerivedC(ByVal HINCD As Object, ByVal ULTTKKB As Object, ByVal De_Index As Object) As Object
        '
        'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        If Trim(HINCD) = "" Then
            '2019/10/18 DEL START
            'Call HINMTA_RClear()
            'Call TOKMTA_RClear()
            '2019/10/18 DEL E N D
            Call TOKMTC_RClear()

        Else
            'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
            Select Case Trim(ULTTKKB)
				Case ""
					'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ULTTKKB_DerivedC = 9
				Case CStr(1)
					'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ULTTKKB_DerivedC = 1
				Case CStr(9)
					'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ULTTKKB_DerivedC = 9
				Case Else
					'UPGRADE_WARNING: �I�u�W�F�N�g ULTTKKB_DerivedC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					ULTTKKB_DerivedC = 9
			End Select
		End If
	End Function
End Module