Option Strict Off
Option Explicit On
Module DENDT_F51
	'
	' �X���b�g��        : ���͓��E��ʍ��ڃX���b�g
	' ���j�b�g��        : DENDT.F51
	' �L�q��            : Standard Library
	' �쐬���t          : 2006/07/24
	' �g�p�v���O������  : SODET53
	'
	Function DENDT_InitVal(ByVal DENDT As Object) As Object
		'
		'UPGRADE_WARNING: �I�u�W�F�N�g DENDT_InitVal �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		DENDT_InitVal = DB_UNYMTA.UNYDT '�{���̓��t�B
	End Function
End Module