Attribute VB_Name = "SSSVALUE"
Option Explicit

'--------------------
'���ϐ���萔�̐錾��
'--------------------

'���p��
Public Const SSS_PrgId = "URKET73"
Public Const SSS_PrgNm = "�O��[���߂�����"

Public SSS_CLTID    As String * 5
Public SSS_OPEID    As String * 8
'���p��:END

Public Const SSS_SubWindowNm = "���z�����o�^"

Public Const OPTION_SHOW_FLAG       As Boolean = True       '���I�v�V�������ڂ�\�����邩�ǂ������׸�
Public Const SHOW_HIDE_COLUMN_FLAG  As Boolean = False      '���B�����ڂ�\�����邩�ǂ������׸�(DEBUG�p)
Public Const AUTHORITY_ENABLE       As Boolean = True       '��������L���Ƃ��邩�ǂ������׸�
Public Const UPDATE_MODE            As Integer = 2          '��NKSTRA�̍X�V���[�h�@1:�S�f�[�^���폜���A�ǉ�
                                                                                  '2:��ɒǉ�(�O�f�[�^�Ƃ̍��z)
                                                                            
Public GGG As String
                                                                            
Public gstrUnydt    As String * 8  '�^�p�����t���i�[

Public gstrKesidt   As String * 8  '��ʂœ��͂������������i�[
Public gstrTokseicd As String * 5  '��ʂœ��͂��������溰�ނ��i�[
Public gstrKaidt_Fr As String * 8  '��ʂœ��͂�������\���(�J�n)���i�[
Public gstrKaidt_To As String * 8  '��ʂœ��͂�������\���(�I��)���i�[
Public gstrFridt    As String * 8  '��ʂœ��͂����U���������i�[

Public Const TesuryoID  As String = "05"    '���萔���z�̻��ID
Public Const SyohiID    As String = "09"    '������Ŋz�̻��ID

'�X�v���b�h�̗񖼂Ɣԍ��̊֘A�t��
Public Const COL_CHK        As Integer = 1      '�����ޯ��
Public Const COL_NO         As Integer = 2      'No.
Public Const COL_NXTKB      As Integer = 3      '���[
Public Const COL_HYUDNDT    As Integer = 4      '�����(�X���b�V���t��)
Public Const COL_HYJDNNO    As Integer = 5      '�󒍓�(�s�ԍ��t��)
Public Const COL_HYKAIDT    As Integer = 6      '����\���(�X���b�V���t��)
Public Const COL_TOKJDNNO   As Integer = 7      '�q�撍���ԍ�
Public Const COL_TANNM      As Integer = 8      '�S���Җ�
Public Const COL_URIKN      As Integer = 9      '�Ŕ�������z
Public Const COL_UZEKN      As Integer = 10     '����Ŋz
Public Const COL_KOMIKN     As Integer = 11     '�ō�������z
Public Const COL_KESIKN     As Integer = 12     '�����z
Public Const COL_MINYUKN    As Integer = 13     '�������z
Public Const COL_HYFRIDT    As Integer = 14     '�U������(�X���b�V���t��)
Public Const COL_BFKESIKN   As Integer = 15     '�����z(�����O)
Public Const COL_AFKESIKN   As Integer = 16     '�����z(������)
Public Const COL_JDNNO      As Integer = 17     '�󒍔ԍ�
Public Const COL_JDNLINNO   As Integer = 18     '�󒍍s�ԍ�(3��)
Public Const COL_UDNDT      As Integer = 19     '�����
Public Const COL_KESDT      As Integer = 20     '���ϓ�
Public Const COL_TOKCD      As Integer = 21     '���Ӑ溰��
Public Const COL_TOKSEICD   As Integer = 22     '�����溰��
Public Const COL_TANCD      As Integer = 23     '�S���Һ���
Public Const COL_JDNDT      As Integer = 24     '�󒍓�
Public Const COL_TUKKB      As Integer = 25     '�ʉ݋敪
Public Const COL_INVNO      As Integer = 26     '���޲�No.
Public Const COL_FURIKN     As Integer = 27     '�C�O������z
Public Const COL_FRNKB      As Integer = 28     '�C�O����敪
Public Const COL_UDNDATNO   As Integer = 29     '����DATNO
Public Const COL_UDNLINNO   As Integer = 30     '����LINNO
Public Const COL_MAEUKKB    As Integer = 31     '�O��敪
Public Const COL_JDNDATNO   As Integer = 32     '��DATNO


Public Const COL_BFHYFRIDT  As Integer = 33     '�ύX�O�U������(�X���b�V���t��)
Public Const COL_BFCHECK    As Integer = 34     '�ύX�O��������
Public Const COL_KESIKN_MAE As Integer = 35     '�����O���z

Public Const COL_HENPI      As Integer = 36     '�ԕi�t���O


'���׊֘A���ڂ��i�[����\����
Private Type TYPE_FR_SSSSUB
    SUB_DKBID       As String * 2
    SUB_DKBNM       As String * 6
    SUB_UPDID       As String * 2
    SUB_DFLDKBCD    As String * 13
    SUB_DKBZAIFL    As String * 1
    SUB_DKBTEGFL    As String * 1
    SUB_DKBFLA      As String * 1
    SUB_DKBFLB      As String * 1
    SUB_DKBFLC      As String * 1
    SUB_KOUZA       As String * 10
    SUB_NYUKN       As String * 9
    SUB_LINCMA      As String * 20
End Type
Public gtypeFR_SUB(2) As TYPE_FR_SSSSUB

'���p��
Public Const gc_DKBSB_NKN   As String = "050"
Public Const gc_DKBSB_KES   As String = "056"
Public strKDNNO             As String
Public strKDNNO_MIN         As String
Public strKDNNO_MAX         As String

Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As Any, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Long, ByVal lpFileName As String) As Long
Declare Function CspPurgeFilterReq Lib "AE_SUP32.DLL" (ByVal fhWnd As Long) As Long
'Declare Function Dll_RClear Lib "sssoraif" (ByVal Fno&, recBuf As Any) As Long

Global Const SSS_ReTryCnt% = 100             '���O�t�@�C���I�[�v�����g���C�J�E���g

Global strINIDATNM(4)       As String           '�h�m�h�̃V���{��
Global SSS_INIDAT(4)        As String           '�h�m�h�̓��e
Global Set_date             As String * 10      '����ްWINDOW�p
Global SSS_INICnt           As Integer          'INI �t�@�C���ŏI�C���f�b�N�X
Public WLSDATE_RTNCODE      As String           '���t�iyyyy/mm/dd�j

'#Start(2003.3.28) �����O�t�@�C���l�[�����ɑΉ�
Global Const MAX_PATH = 260
'#End(2003.3.28)

Public gs_UPDAUTH   As String   '�X�V����
Public gs_PRTAUTH   As String   '�������
Public gs_FILEAUTH  As String   '�t�@�C���o�͌���
Public gs_SALTAUTH  As String   '�̔��P���ύX����
Public gs_HDNTAUTH  As String   '�����P���ύX����
Public gs_SAPMAUTH  As String   '�̔��v��N���v��C������

Public WLSKOZ_RTNCODE As String '������������߂�l
Public WLSTBD_RTNCODE As String '������ʌ����߂�l
Public WLSTOKSUB_RTNCODE As String '�����挟���߂�l
Public WLSTOK_RTNCODE As String '���Ӑ挟���߂�l

Public GV_SysDate               As String               '�c�a�T�[�o�[���t
Public GV_SysTime               As String               '�c�a�T�[�o�[����
Public GV_UNYDate               As String

Type T_G_LB
    tgLB1(16 * 1024) As Byte
    tgLB2(4 * 1024) As Byte 'Pre=16
    'tgLB3(4 * 1024) As Byte
End Type
Global G_LB As T_G_LB

'�t�@�C���\���̏������p�f�[�^
Type DB_CLRDAT
    FILLER As String * 2048      '�������f�[�^
End Type
Global DB_CLRREC As DB_CLRDAT

'==========================================================================
'   SYSTBE       �^�p���O��`��                                           =
'==========================================================================
Type TYPE_DB_SYSTBE
    PRGID          As String * 8     '�v���O����ID          X(8)
    LOGNM          As String * 60    '���l(�װ���E�^�p)   X(60)
    OPEID          As String * 8     '�ŏI��Ǝ҃R�[�h      X(8)
    CLTID          As String * 5     '�N���C�A���g�h�c      X(05)
    WRTTM          As String * 6     '��ѽ���߁i���ԁj      9(06)
    WRTDT          As String * 8     '��ѽ���߁i���t�j      9(08)
End Type
Global DB_SYSTBE As TYPE_DB_SYSTBE

Public Const gc_strMsgEXCTBZ_ERROR          As String = "2URKET73_034"  '�X�V�ُ�

'���p��:END
