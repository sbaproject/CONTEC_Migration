Option Strict Off
Option Explicit On
Module SBAUZEKN_F51
	'
	' �X���b�g��        : �`�[���v����ŋ��z(�Ŕ�)���ځE��ʍ��ڃX���b�g
	' ���j�b�g��        : SBAURIKN.F01
	' �L�q��            : Standard Library
	' �쐬���t          : 1997/06/11
	' �g�p�v���O������  : URIET01
	
	Dim WM_ZNKUZEKN(2) As Decimal
	Dim WM_ZKMUZEKN(2) As Decimal
	Dim WM_ZEIRT(2) As Decimal
	Dim WM_ZNKURIKN(2) As Decimal
	Dim WM_ZKMURIKN(2) As Decimal
	
	Function SBAUZEKN_Derived(ByVal UDNDT As Object, ByVal UZEKN As Object, ByVal ZNKURIKN As Object, ByRef PP As clsPP) As Object
		Dim NullSw, I As Short
		Dim WL_HINZEIKB, WL_TOKRPSKB, WL_TOKZEIKB, WL_TOKZCLKB, WL_TOKZRNKB, WL_ZEIRNKKB As Object
		Dim WL_SBAUZEKN As Decimal
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SBAUZEKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		SBAUZEKN_Derived = 0
		
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKZCLKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WL_TOKZCLKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WL_TOKZCLKB = RD_SSSMAIN_TOKZCLKB(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKZEIKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g WL_TOKZEIKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WL_TOKZEIKB = RD_SSSMAIN_TOKZEIKB(0)
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_TOKZCLKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (SSSVal(WL_TOKZCLKB) = 0) Or (SSSVal(WL_TOKZCLKB) = 9) Or (SSSVal(WL_TOKZCLKB) = 3) Then Exit Function
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_TOKZEIKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(WL_TOKZEIKB) = 9 Then Exit Function
		
		For I = 0 To 2
			WM_ZNKUZEKN(I) = 0
			WM_ZNKURIKN(I) = 0
		Next I
		WL_SBAUZEKN = 0
		
		I = 0
		Do While I < PP.LastDe
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_HINID() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_TOKZCLKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If (SSSVal(WL_TOKZCLKB) = 1) Or (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(RD_SSSMAIN_HINID(I)) = "06") Then '�y�ʔ́z�y�сy�V�X�e���ŏ������i�z���A�Z�o�������
				If IsNumeric(RD_SSSMAIN_UZEKN(I)) Then
					'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UZEKN() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WL_SBAUZEKN = WL_SBAUZEKN + RD_SSSMAIN_UZEKN(I)
				End If
				'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_TOKZCLKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			ElseIf SSSVal(WL_TOKZCLKB) = 2 Then 
				'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_ZEIRNKKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				'UPGRADE_WARNING: �I�u�W�F�N�g WL_ZEIRNKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WL_ZEIRNKKB = RD_SSSMAIN_ZEIRNKKB(I)
				'            If Not IsNull(WL_ZEIRNKKB) And IsNumeric(WL_ZEIRNKKB) Then
				'UPGRADE_WARNING: �I�u�W�F�N�g WL_ZEIRNKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If Trim(WL_ZEIRNKKB) <> "" And IsNumeric(WL_ZEIRNKKB) Then
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_ZEIRNKKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g WL_ZEIRNKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If SSSVal(WL_ZEIRNKKB) > 3 Or SSSVal(WL_ZEIRNKKB) < 1 Then WL_ZEIRNKKB = "1"
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_ZEIRNKKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(RD_SSSMAIN_ZNKURIKN(I)) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WM_ZNKURIKN(SSSVal(WL_ZEIRNKKB) - 1) = WM_ZNKURIKN(SSSVal(WL_ZEIRNKKB) - 1) + SSSVal(RD_SSSMAIN_ZNKURIKN(I))
				End If
			End If
			I = I + 1
		Loop 
		
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_TOKZCLKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If (SSSVal(WL_TOKZCLKB) = 1) Or (Trim(WG_JDNINKB) = "2") Then '�y�ʔ́z�|�C���g�l���Ή�
			'UPGRADE_WARNING: �I�u�W�F�N�g SBAUZEKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SBAUZEKN_Derived = WL_SBAUZEKN
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_TOKZCLKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf SSSVal(WL_TOKZCLKB) = 2 Then 
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKZEIKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g WL_TOKZEIKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WL_TOKZEIKB = RD_SSSMAIN_TOKZEIKB(0)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKRPSKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g WL_TOKRPSKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WL_TOKRPSKB = RD_SSSMAIN_TOKRPSKB(0)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_TOKZRNKB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g WL_TOKZRNKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			WL_TOKZRNKB = RD_SSSMAIN_TOKZRNKB(0)
			'UPGRADE_WARNING: �I�u�W�F�N�g RD_SSSMAIN_UDNDT() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SSS_WRKDT(0) = RD_SSSMAIN_UDNDT(0)
			
			For I = 0 To 2
				WM_ZNKUZEKN(I) = 0
				'UPGRADE_WARNING: �I�u�W�F�N�g WL_ZEIRNKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				WL_ZEIRNKKB = VB6.Format(I + 1, "0")
				'UPGRADE_WARNING: �I�u�W�F�N�g WL_ZEIRNKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				Call DB_GetLsEq(DBN_SYSTBB, 2, WL_ZEIRNKKB + SSS_WRKDT(0), BtrNormal)
				'UPGRADE_WARNING: �I�u�W�F�N�g WL_ZEIRNKKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				If (DBSTAT = 0) And (DB_SYSTBB.ZEIRNKKB = WL_ZEIRNKKB) Then
					If WM_ZNKURIKN(I) <> 0 Then WM_ZNKUZEKN(I) = WM_ZNKURIKN(I) * DB_SYSTBB.ZEIRT / 100
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_TOKRPSKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(WL_TOKZRNKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					WM_ZNKUZEKN(I) = DCMFRC(WM_ZNKUZEKN(I), SSSVal(WL_TOKZRNKB), SSSVal(WL_TOKRPSKB) - 1)
					WL_SBAUZEKN = WL_SBAUZEKN + WM_ZNKUZEKN(I)
				End If
			Next I
			'UPGRADE_WARNING: �I�u�W�F�N�g SBAUZEKN_Derived �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			SBAUZEKN_Derived = WL_SBAUZEKN
		End If
	End Function
End Module