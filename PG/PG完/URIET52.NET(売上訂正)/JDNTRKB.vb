Option Strict Off
Option Explicit On
Module JDNTRKB_F51
	'
	' �X���b�g��        : �󒍎���敪�E��ʍ��ڃX���b�g
	' ���j�b�g��        : JDNTRKB.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/08/24
	' �g�p�v���O������  : URIET53
	'
	
	Function JDNTRKB_Slist(ByRef PP As clsPP) As Object
		WLS_MEI1.Text = "�󒍎���敪�ꗗ"
		CType(WLS_MEI1.Controls("LST"), Object).Items.Clear()
		Call DB_GetGrEq(DBN_MEIMTA, 3, "006", BtrNormal)
		Do While DBSTAT = 0 And DB_MEIMTA.KEYCD = "006"
			CType(WLS_MEI1.Controls("LST"), Object).Items.Add(LeftWid(DB_MEIMTA.MEICDA, 5) & " " & DB_MEIMTA.MEINMA)
			Call DB_GetNext(DBN_MEIMTA, BtrNormal)
		Loop 
		SSS_WLSLIST_KETA = 2
		WLS_MEI1.ShowDialog()
		'UPGRADE_WARNING: �I�u�W�F�N�g PP.SlistCom �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g JDNTRKB_Slist �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		JDNTRKB_Slist = PP.SlistCom
		
	End Function
End Module