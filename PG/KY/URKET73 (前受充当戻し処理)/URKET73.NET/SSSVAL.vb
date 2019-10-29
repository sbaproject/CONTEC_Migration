Option Strict Off
Option Explicit On
Module SSSVALUE
	
	'--------------------
	'���ϐ���萔�̐錾��
	'--------------------
	
	'���p��
	Public Const SSS_PrgId As String = "URKET73"
	Public Const SSS_PrgNm As String = "�O��[���߂�����"
	
	Public SSS_CLTID As New VB6.FixedLengthString(5)
	Public SSS_OPEID As New VB6.FixedLengthString(8)
	'���p��:END
	
	Public Const SSS_SubWindowNm As String = "���z�����o�^"
	
	Public Const OPTION_SHOW_FLAG As Boolean = True '���I�v�V�������ڂ�\�����邩�ǂ������׸�
	Public Const SHOW_HIDE_COLUMN_FLAG As Boolean = False '���B�����ڂ�\�����邩�ǂ������׸�(DEBUG�p)
	Public Const AUTHORITY_ENABLE As Boolean = True '��������L���Ƃ��邩�ǂ������׸�
	Public Const UPDATE_MODE As Short = 2 '��NKSTRA�̍X�V���[�h�@1:�S�f�[�^���폜���A�ǉ�
	'2:��ɒǉ�(�O�f�[�^�Ƃ̍��z)
	
	Public GGG As String
	
	Public gstrUnydt As New VB6.FixedLengthString(8) '�^�p�����t���i�[
	
	Public gstrKesidt As New VB6.FixedLengthString(8) '��ʂœ��͂������������i�[
	Public gstrTokseicd As New VB6.FixedLengthString(5) '��ʂœ��͂��������溰�ނ��i�[
	Public gstrKaidt_Fr As New VB6.FixedLengthString(8) '��ʂœ��͂�������\���(�J�n)���i�[
	Public gstrKaidt_To As New VB6.FixedLengthString(8) '��ʂœ��͂�������\���(�I��)���i�[
	Public gstrFridt As New VB6.FixedLengthString(8) '��ʂœ��͂����U���������i�[
	
	Public Const TesuryoID As String = "05" '���萔���z�̻��ID
	Public Const SyohiID As String = "09" '������Ŋz�̻��ID
	
	'�X�v���b�h�̗񖼂Ɣԍ��̊֘A�t��
	Public Const COL_CHK As Short = 1 '�����ޯ��
	Public Const COL_NO As Short = 2 'No.
	Public Const COL_NXTKB As Short = 3 '���[
	Public Const COL_HYUDNDT As Short = 4 '�����(�X���b�V���t��)
	Public Const COL_HYJDNNO As Short = 5 '�󒍓�(�s�ԍ��t��)
	Public Const COL_HYKAIDT As Short = 6 '����\���(�X���b�V���t��)
	Public Const COL_TOKJDNNO As Short = 7 '�q�撍���ԍ�
	Public Const COL_TANNM As Short = 8 '�S���Җ�
	Public Const COL_URIKN As Short = 9 '�Ŕ�������z
	Public Const COL_UZEKN As Short = 10 '����Ŋz
	Public Const COL_KOMIKN As Short = 11 '�ō�������z
	Public Const COL_KESIKN As Short = 12 '�����z
	Public Const COL_MINYUKN As Short = 13 '�������z
	Public Const COL_HYFRIDT As Short = 14 '�U������(�X���b�V���t��)
	Public Const COL_BFKESIKN As Short = 15 '�����z(�����O)
	Public Const COL_AFKESIKN As Short = 16 '�����z(������)
	Public Const COL_JDNNO As Short = 17 '�󒍔ԍ�
	Public Const COL_JDNLINNO As Short = 18 '�󒍍s�ԍ�(3��)
	Public Const COL_UDNDT As Short = 19 '�����
	Public Const COL_KESDT As Short = 20 '���ϓ�
	Public Const COL_TOKCD As Short = 21 '���Ӑ溰��
	Public Const COL_TOKSEICD As Short = 22 '�����溰��
	Public Const COL_TANCD As Short = 23 '�S���Һ���
	Public Const COL_JDNDT As Short = 24 '�󒍓�
	Public Const COL_TUKKB As Short = 25 '�ʉ݋敪
	Public Const COL_INVNO As Short = 26 '���޲�No.
	Public Const COL_FURIKN As Short = 27 '�C�O������z
	Public Const COL_FRNKB As Short = 28 '�C�O����敪
	Public Const COL_UDNDATNO As Short = 29 '����DATNO
	Public Const COL_UDNLINNO As Short = 30 '����LINNO
	Public Const COL_MAEUKKB As Short = 31 '�O��敪
	Public Const COL_JDNDATNO As Short = 32 '��DATNO
	
	
	Public Const COL_BFHYFRIDT As Short = 33 '�ύX�O�U������(�X���b�V���t��)
	Public Const COL_BFCHECK As Short = 34 '�ύX�O��������
	Public Const COL_KESIKN_MAE As Short = 35 '�����O���z
	
	Public Const COL_HENPI As Short = 36 '�ԕi�t���O
	
	
	'���׊֘A���ڂ��i�[����\����
	Private Structure TYPE_FR_SSSSUB
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(2),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=2)> Public SUB_DKBID() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public SUB_DKBNM() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(2),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=2)> Public SUB_UPDID() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(13),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=13)> Public SUB_DFLDKBCD() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public SUB_DKBZAIFL() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public SUB_DKBTEGFL() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public SUB_DKBFLA() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public SUB_DKBFLB() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public SUB_DKBFLC() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public SUB_KOUZA() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(9),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=9)> Public SUB_NYUKN() As Char
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public SUB_LINCMA() As Char
	End Structure
	Public gtypeFR_SUB(2) As TYPE_FR_SSSSUB
	
	'���p��
	Public Const gc_DKBSB_NKN As String = "050"
	Public Const gc_DKBSB_KES As String = "056"
	Public strKDNNO As String
	Public strKDNNO_MIN As String
	Public strKDNNO_MAX As String
	
	'UPGRADE_ISSUE: �p�����[�^ 'As Any' �̐錾�̓T�|�[�g����܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="FAE78A8D-8978-4FD4-8208-5B7324A8F795"' ���N���b�N���Ă��������B
	Declare Function GetPrivateProfileString Lib "kernel32"  Alias "GetPrivateProfileStringA"(ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
	Declare Function CspPurgeFilterReq Lib "AE_SUP32.DLL" (ByVal fhWnd As Integer) As Integer
	'Declare Function Dll_RClear Lib "sssoraif" (ByVal Fno&, recBuf As Any) As Long
	
	Public Const SSS_ReTryCnt As Short = 100 '���O�t�@�C���I�[�v�����g���C�J�E���g
	
	Public strINIDATNM(4) As String '�h�m�h�̃V���{��
	Public SSS_INIDAT(4) As String '�h�m�h�̓��e
	Public Set_date As New VB6.FixedLengthString(10) '����ްWINDOW�p
	Public SSS_INICnt As Short 'INI �t�@�C���ŏI�C���f�b�N�X
	Public WLSDATE_RTNCODE As String '���t�iyyyy/mm/dd�j
	
	'#Start(2003.3.28) �����O�t�@�C���l�[�����ɑΉ�
	Public Const MAX_PATH As Short = 260
	'#End(2003.3.28)
	
	Public gs_UPDAUTH As String '�X�V����
	Public gs_PRTAUTH As String '�������
	Public gs_FILEAUTH As String '�t�@�C���o�͌���
	Public gs_SALTAUTH As String '�̔��P���ύX����
	Public gs_HDNTAUTH As String '�����P���ύX����
	Public gs_SAPMAUTH As String '�̔��v��N���v��C������
	
	Public WLSKOZ_RTNCODE As String '������������߂�l
	Public WLSTBD_RTNCODE As String '������ʌ����߂�l
	Public WLSTOKSUB_RTNCODE As String '�����挟���߂�l
	Public WLSTOK_RTNCODE As String '���Ӑ挟���߂�l
	
	Public GV_SysDate As String '�c�a�T�[�o�[���t
	Public GV_SysTime As String '�c�a�T�[�o�[����
	Public GV_UNYDate As String
	
	Structure T_G_LB
		<VBFixedArray(16 * 1024)> Dim tgLB1() As Byte
		<VBFixedArray(4 * 1024)> Dim tgLB2() As Byte 'Pre=16
		'tgLB3(4 * 1024) As Byte
		
		'UPGRADE_TODO: ���̍\���̂̃C���X�^���X������������ɂ́A"Initialize" ���Ăяo���Ȃ���΂Ȃ�܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' ���N���b�N���Ă��������B
		Public Sub Initialize()
			ReDim tgLB1(16 * 1024)
			ReDim tgLB2(4 * 1024)
		End Sub
	End Structure
	'UPGRADE_WARNING: �\���� G_LB �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
	Public G_LB As T_G_LB
	
	'�t�@�C���\���̏������p�f�[�^
	Structure DB_CLRDAT
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(2048),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=2048)> Public FILLER() As Char '�������f�[�^
	End Structure
	Public DB_CLRREC As DB_CLRDAT
	
	'==========================================================================
	'   SYSTBE       �^�p���O��`��                                           =
	'==========================================================================
	Structure TYPE_DB_SYSTBE
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public PRGID() As Char '�v���O����ID          X(8)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(60),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=60)> Public LOGNM() As Char '���l(�װ���E�^�p)   X(60)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '�ŏI��Ǝ҃R�[�h      X(8)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char '�N���C�A���g�h�c      X(05)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char '��ѽ���߁i���ԁj      9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char '��ѽ���߁i���t�j      9(08)
	End Structure
	Public DB_SYSTBE As TYPE_DB_SYSTBE
	
	Public Const gc_strMsgEXCTBZ_ERROR As String = "2URKET73_034" '�X�V�ُ�
	
	'���p��:END
End Module