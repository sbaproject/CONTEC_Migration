Option Strict Off
Option Explicit On
Module URIKN_F52
	'
	' �X���b�g��        : ������z�E��ʍ��ڃX���b�g
	' ���j�b�g��        : URIKN.F52
	' �L�q��            :
	' �쐬���t          : 2006/09/22
	' �g�p�v���O������  : URIET52
	'
	
	'����P�������㐔��
	Function URIKN_Derived(ByVal URIKN As Object, ByVal URITK As Object, ByVal URISU As Object, ByVal HINID As Object, ByRef CP_URIKN As clsCP, ByVal TKNRPSKB As Object, ByVal TKNZRNKB As Object) As Object
		Dim WL_TKNRPSKB, WL_TKNZRNKB As Object
		Dim WL_URISU As Double
		Dim WL_URITK As Double
		WL_URISU = 0
		WL_URITK = 0
		
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WL_URISU = URISU
		'UPGRADE_WARNING: �I�u�W�F�N�g URITK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WL_URITK = URITK
		'UPGRADE_WARNING: �I�u�W�F�N�g TKNRPSKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WL_TKNRPSKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WL_TKNRPSKB = TKNRPSKB
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(TKNZRNKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(TKNZRNKB) = 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g WL_TKNZRNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WL_TKNZRNKB = 0
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(TKNZRNKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf SSSVal(TKNZRNKB) = 1 Then 
			'UPGRADE_WARNING: �I�u�W�F�N�g WL_TKNZRNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WL_TKNZRNKB = 5
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(TKNZRNKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf SSSVal(TKNZRNKB) = 9 Then 
			'UPGRADE_WARNING: �I�u�W�F�N�g WL_TKNZRNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WL_TKNZRNKB = 9
		End If
		
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g URIKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g URIKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		URIKN_Derived = URIKN
		
		'�y�ʔ́z�y�сy�V�X�e���ŏ������i�z���A�Z�o�������
		'UPGRADE_WARNING: �I�u�W�F�N�g HINID �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06") Then Exit Function
		
		'UPGRADE_WARNING: �I�u�W�F�N�g URITK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(URITK) = "" Or Not IsNumeric(URITK) Then Exit Function
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(URISU) = "" Or Not IsNumeric(URISU) Then Exit Function
		On Error GoTo OverFlow
		'' 2003/08/28 �ύX�����P�� �� 0 �̏ꍇ�O��̋��z���c��
		'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g URITK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If URITK <> 0 Or URISU <> 0 Then
			''If URITK <> 0 And URISU <> 0 Then
			'        URIKN_Derived = URITK * URISU                  '1996/08/26 Delete
			'        URIKN_Derived = DCMFRC(URITK * URISU, 0, 0)     '1996/08/26 Insert
			
			' ���Ӑ�}�X�^�̋��z�[����������(TKNRPSKB)�A���z�[�������敪(TKNZRNKB)���v�Z
			' TKNRPSKB 1�F������1�ʁA2�F������2�ʁA3�F������3�ʁA4: ������4�ʤ5: ������5��
			' TKNZRNKB 0�F�؂�̂āA1�F�l�̌ܓ��A9�F�؂�グ
			
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_TKNRPSKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URIKN_Derived = DCMFRC2(WL_URITK * WL_URISU, SSSVal(WL_TKNZRNKB), (SSSVal(WL_TKNRPSKB) * -1) + 1)
			
		End If
		Exit Function
OverFlow: 
		CP_URIKN.StatusC = Cn_StatusError
		'UPGRADE_WARNING: �I�u�W�F�N�g URIKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		URIKN_Derived = "??????????????????"
	End Function
	
	'�ŏ��̓J�[�\���𗯂߂Ȃ��B
	Function URIKN_Skip(ByVal HINCD As Object, ByVal URITK As Object, ByVal URISU As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g URIKN_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		URIKN_Skip = False
		'UPGRADE_WARNING: �I�u�W�F�N�g HINCD �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(HINCD) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g URIKN_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URIKN_Skip = True
			'' 2003/08/28 ���z���P���̂����ꂩ�� 0 �łȂ��ꍇ
			'UPGRADE_WARNING: �I�u�W�F�N�g URISU �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g URITK �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf URITK <> 0 Or URISU <> 0 Then 
			''ElseIf URITK <> 0 And URISU <> 0 Then
			'UPGRADE_WARNING: �I�u�W�F�N�g URIKN_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			URIKN_Skip = True
		End If
	End Function
	
	' �W��DCMFRC ������IN_SU AS CURRENCY �� DCMFRC2 ������IN_SU AS DOUBLE�ɕύX
	Function DCMFRC2(ByRef IN_SU As Double, ByRef MARUME As Decimal, ByRef KETA As Decimal) As Decimal
		'  IN_SU:��ҏW���l, MARUME:�܂�߃p�����[�^
		'  KETA:�܂�߂錅�ʒu(������1�ʂ�0 ������2�ʂ�-1 ����1�̈ʂ�1 ����2�̈ʂ�2)
		Dim WL_MARUME, WL_KETA, WL_SU As Decimal
		WL_KETA = 10 ^ KETA
		WL_MARUME = MARUME / 10
		If IN_SU < 0 Then
			WL_SU = IN_SU / WL_KETA - WL_MARUME
			DCMFRC2 = Fix(WL_SU) * WL_KETA
		Else
			WL_SU = IN_SU / WL_KETA + WL_MARUME
			DCMFRC2 = Int(WL_SU) * WL_KETA
		End If
	End Function
End Module