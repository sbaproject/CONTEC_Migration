Option Strict Off
Option Explicit On
Module DSPYM_F01
	'
	' �X���b�g��        : �\�����t�i�N���j�E��ʍ��ڃX���b�g
	' ���j�b�g��        : DSPYM.F01
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : TNADL01 / TNADL02 / TNADL03 / TNADL06 / TNADL07 / TNADL08
	'
	Dim NotFirst As Short
	
	'���t�����͂��ꂽ�ꍇ�ɁA���̃`�F�b�N���s���B
	Function DSPYM_CheckC(ByVal DSPYM As Object) As Object
		Dim WL_Formatdate, WL_SMAUPDDT As String
		Dim WL_DSPYM As String
		''2001/05/10 '���t�͈̓`�F�b�N��ǉ�
		Dim Rtn As Short
		'
		If Not CHECK_DATE(DSPYM) Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g DSPYM_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DSPYM_CheckC = -1
			Exit Function
		End If
		''
		'UPGRADE_WARNING: �I�u�W�F�N�g DSPYM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		WL_DSPYM = DSPYM & "01��"
		WL_Formatdate = Space(10)
		If IsDate(WL_DSPYM) Then
			WL_Formatdate = VB6.Format(WL_DSPYM, "YYYY�NMM��DD��")
			WL_SMAUPDDT = (Left(DB_SYSTBA.SMAUPDDT, 4) & "�N" & Mid(DB_SYSTBA.SMAUPDDT, 5, 2) & "��" & Right(DB_SYSTBA.SMAUPDDT, 2)) & "��"
		End If
		If RightWid(WL_DSPYM, 2) <> RightWid(WL_Formatdate, 2) Then
			'UPGRADE_WARNING: �I�u�W�F�N�g DSPYM_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DSPYM_CheckC = 11
			'UPGRADE_WARNING: �I�u�W�F�N�g DSPYM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		ElseIf DSPYM < WL_SMAUPDDT Then 
			'UPGRADE_WARNING: �I�u�W�F�N�g DSPYM_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DSPYM_CheckC = 12
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g DSPYM_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DSPYM_CheckC = 0 '����I���B
		End If
	End Function
	
	'���t�̏����l��ݒ肷��B
	Function DSPYM_InitVal(ByVal DSPYM As Object, ByRef PP As clsPP) As Object
		If NotFirst = False Or Not IsDate(DSPYM) Then
			NotFirst = True
			'UPGRADE_WARNING: �I�u�W�F�N�g DSPYM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			DSPYM = VB6.Format(Today, "YYYY�NMM��") '�{���̓��t�B
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g DSPYM �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g DSPYM_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DSPYM_InitVal = DSPYM '�O�̓��t�B
	End Function
	
	'�J�[�\����N�̂Ƃ���ł͂Ȃ����̂Ƃ���ɐi�܂���B
	Function DSPYM_Skip(ByRef CT_DSPYM As System.Windows.Forms.Control) As Object
        'UPGRADE_WARNING: �I�u�W�F�N�g CT_DSPYM.SelStart �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '20190711 CHG START
        'CT_DSPYM.SelStart = 6 'yyyy-mm-dd �� dd �̂Ƃ���B
        DirectCast(CT_DSPYM, TextBox).SelectionStart = 6 'yyyy-mm-dd �� dd �̂Ƃ���B
        '20190711 CHG END
        'UPGRADE_WARNING: �I�u�W�F�N�g DSPYM_Skip �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        DSPYM_Skip = False
	End Function
End Module