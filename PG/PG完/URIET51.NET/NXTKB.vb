Option Strict Off
Option Explicit On
Module NXTKB_F52
	'
	' �X���b�g��        : ���[�敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : NXTKB.F01
	' �L�q��            : Standard Library
	' �쐬���t          : 1995/10/01
	' �g�p�v���O������  : URIET01
	
	'���[�敪�����͂��ꂽ�ꍇ�ɁA���̃`�F�b�N���s���B
	Function NXTKB_CheckC(ByRef NXTKB As Object) As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g NXTKB_CheckC �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NXTKB_CheckC = 0 '����I���B
		'UPGRADE_WARNING: �I�u�W�F�N�g NXTKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If Trim(NXTKB) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g NXTKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			NXTKB = "0"
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(NXTKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g NXTKB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If SSSVal(NXTKB) > 2 Then NXTKB = "0"
		End If
	End Function
	
	Function NXTKB_InitVal() As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g NXTKB_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NXTKB_InitVal = "0"
	End Function
	
	Function NXTKB_Slist(ByRef PP As clsPP, ByVal TOKSMEKB As Object, ByVal TOKSMEDD As Object, ByVal TOKSMECC As Object, ByVal UDNDT As Object) As Object
		Dim wkSSADT0 As String
		Dim wkSSADT1 As String
		Dim wkSSADT2 As String
		
		'   === �������ߓ��t�擾 ===
		'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_TOKMTA.TOKSMEKB) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If SSSVal(DB_TOKMTA.TOKSMEKB) = 1 Then
			'       --- ��X����� ---
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_TOKMTA.TOKSMECC) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkSSADT0 = Get_SMEDT1(SSSVal(DB_TOKMTA.TOKSMEDD), SSSVal(DB_TOKMTA.TOKSMECC), VB6.Format(UDNDT, "YYYY/MM/DD"), SSSVal("0"))
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_TOKMTA.TOKSMECC) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkSSADT1 = Get_SMEDT1(SSSVal(DB_TOKMTA.TOKSMEDD), SSSVal(DB_TOKMTA.TOKSMECC), VB6.Format(UDNDT, "YYYY/MM/DD"), SSSVal("1"))
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(2) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(DB_TOKMTA.TOKSMECC) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkSSADT2 = Get_SMEDT1(SSSVal(DB_TOKMTA.TOKSMEDD), SSSVal(DB_TOKMTA.TOKSMECC), VB6.Format(UDNDT, "YYYY/MM/DD"), SSSVal("2"))
		Else
			'       --- �T���� ---
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkSSADT0 = Get_SMEDT2(SSSVal(DB_TOKMTA.TOKSDWKB), VB6.Format(UDNDT, "YYYY/MM/DD"), SSSVal("0"))
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(1) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkSSADT1 = Get_SMEDT2(SSSVal(DB_TOKMTA.TOKSDWKB), VB6.Format(UDNDT, "YYYY/MM/DD"), SSSVal("1"))
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal(2) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g UDNDT �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g SSSVal() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			wkSSADT2 = Get_SMEDT2(SSSVal(DB_TOKMTA.TOKSDWKB), VB6.Format(UDNDT, "YYYY/MM/DD"), SSSVal("2"))
		End If
		
		WLS_LIST.Text = "���[�敪"
		CType(WLS_LIST.Controls("LST"), Object).Items.Clear()
		'''''    WLS_LIST!LST.AddItem "0 ���񐿋�"
		'''''    WLS_LIST!LST.AddItem "1 ���񐿋�"
		'''''    WLS_LIST!LST.AddItem "2 ���X�񐿋�"
		
		CType(WLS_LIST.Controls("LST"), Object).Items.Add("0 " & Mid(wkSSADT0, 6, 5) & "����")
		CType(WLS_LIST.Controls("LST"), Object).Items.Add("1 " & Mid(wkSSADT1, 6, 5) & "����")
		CType(WLS_LIST.Controls("LST"), Object).Items.Add("2 " & Mid(wkSSADT2, 6, 5) & "����")
		SSS_WLSLIST_KETA = 1
		WLS_LIST.ShowDialog() '0:���͌��ꗗ�͓��͌�Ɏc���w��B
		WLS_LIST.Close()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g NXTKB_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		NXTKB_Slist = PP.SlistCom
	End Function
End Module