Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Module AE_CMN
	'********************************************************************************
	'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
	'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
	'*  �@�\�@�@�@�@�@�@�F�@����
	'*  ���W���[�����@�@�F�@�Ɩ����ʏ���
	'*  �쐬�ҁ@�@�@�@�@�F�@ACE)���V
	'*  �쐬���@�@�@�@�@�F  2006.05.24
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD�@�F�@�C�����
	'*     �C����
	'********************************************************************************
	
	'************************************************************************************
	'   �\����
	'************************************************************************************
	Public Structure Cmn_Inp_Inf
		Dim InpTanCd As String '���͒S���҂h�c
		Dim InpTanNm As String '���͒S���Җ�
		Dim InpTKCHGKB As String '�P���ύX����
		Dim InpCLIID As String '�N���C�A���g�h�c
		' === 20060828 === INSERT S - ACE)Sejima
		Dim InpJDNUPDKB As String '�󒍍X�V����
		' === 20060828 === INSERT E
		' === 20061030 === INSERT S - ACE)Nagasawa �����̓ǂݕ��̕ύX
		Dim InpPRTAUTH As String '�������
		Dim InpFILEAUTH As String '�t�@�C���o�͌���
		' === 20061030 === INSERT E -
	End Structure
	
	' === 20061014 === INSERT S - ACE)Nagasawa �󒍒������̍��ڂ̓��͉ې���̕ύX
	Public Structure Cmn_JDNUPDATE_Enable
		Dim bolJHD As Boolean '�Z�b�g�A�b�v����
		Dim bolFRD As Boolean '�o�׎w��
		' === 20070715 === INSERT S - ACE)Nagasawa �o�׎w�����ł��o�׎w������Ă��Ȃ����ׂ͒����Ƃ���
		Dim bolFRD_TAN As Boolean '�o�׎w��(�P�i)
		Dim bolSSZ_TAN As Boolean '�o�׎w�}�i�P�i�j
		' === 20070715 === INSERT E -
		' === 20061123 === INSERT S - ACE)Nagasawa ���[�J�[�R�[�h�ɂ͏o�׎w�}����ҏW
		Dim bolSSZ As Boolean '�o�׎w�}
		' === 20061123 === INSERT E -
		Dim bolODN As Boolean '�o�׎���
		' === 20061127 === INSERT S - ACE)Nagasawa �C�O�q�ɂ���̏o�׎��эl���ǉ�
		Dim bolFRNMOV As Boolean '�C�O�q�Ɉړ�
		' === 20061127 === INSERT E -
		Dim bolURI As Boolean '����
		Dim bolSSA As Boolean '����
		Dim bolNYU As Boolean '����
		Dim bolJDN_End As Boolean '�󒍊���
	End Structure
	' === 20061014 === INSERT E -
	
	' === 20061217 === INSERT S - ACE)Nagasawa ��������t�@�C���̍X�V���s��
	'��������t�@�C���X�V���
	Public Structure Cmn_DTLTRA_Upd
		Dim Moto_TRANO As String '�X�V�O�g�����ԍ�
		Dim MOTO_MITNOV As String '�X�V�O�Ő�
		Dim Moto_LINNO As String '�X�V�O�s�ԍ�
		Dim TRANO As String '�g�����ԍ�
		Dim MITNOV As String '�Ő�
		Dim LINNO As String '�s�ԍ�
		Dim TRADT As String '�o�ח\���
	End Structure
	' === 20061217 === INSERT E -
	
	' === 20071213 === INSERT S - ACE)Nagasawa �������o�͋敪�̒ǉ�
	'����g�����������敪�X�V�p
	Public Structure Cmn_JDNTRA_UDNUpdate
		Dim JDNNO As String '�󒍔ԍ�
		Dim LINNO As String '�s�ԍ�
		Dim RECNO As String '���R�[�h�Ǘ��ԍ�
		Dim SBNNO As String '����
		Dim MRPKB As String '�������o�͋敪
	End Structure
	' === 20071213 === INSERT E -
	
	' === 20070307 === INSERT S - ACE)Nagasawa
	'���㌩�o���g�����X�V���e
	Public Structure Cmn_UDNTHA_Upd
		Dim DATNO() As String '�`�[�Ǘ��ԍ��i�X�V�Ώہj
		Dim DATNO_KRO() As String '�`�[�Ǘ��ԍ��i�V/���`�[�p�j
		Dim DATNO_AKA() As String '�`�[�Ǘ��ԍ��i�V/�ԓ`�[�p�j
		Dim ODNNO() As String '�o�ד`�[�ԍ��i�ԕi�L��̏ꍇ�̂ݍ̔ԁj
		Dim ODNNO_GetSu As Decimal '�o�ד`�[�ԍ��̔Ԑ�
		Dim UDNNO_KRO() As String '����`�[�ԍ��i�V/���`�[�p�j
		Dim UDNNO_AKA() As String '����`�[�ԍ��i�V/�ԓ`�[�p�j
		' === 20070331 === INSERT S - ACE)Nagasawa ��������ԕi�Ή�
		Dim FDNNO_KRO() As String '�[�i���ԍ��i�V/���`�[�p�j
		Dim FDNNO_AKA() As String '�[�i���ԍ��i�V/�ԓ`�[�p�j
		' === 20070331 === INSERT E -
		Dim UDNNO_GetSu As Decimal '�o�ד`�[�ԍ��̔Ԑ�
		Dim JDNNO As String '�󒍔ԍ�
		Dim FDNNO() As String '�[�i���ԍ�
		Dim TOKCD As String '���Ӑ�R�[�h
		Dim TOKSEICD As String '������R�[�h
		Dim UDNDT As String '����`�[���t�i�󒍒�����)
		Dim JDNTRKB As String '�󒍎���敪
		Dim URIKJN As String '����
		Dim TANCD As String '�c�ƒS���҃R�[�h
		Dim TANNM As String '�c�ƒS���Җ�
		Dim BUMCD As String '�c�ƕ���R�[�h
		Dim BUMNM As String '�c�ƕ��喼
		Dim CLMDL As String '���ތ^��
		Dim SMADT As String '�o�������t
		Dim SSADT() As String '�����t
		Dim KESDT() As String '���Z���t
		Dim SSADT_Chk As String '�ő�����t�i�󒍒���������p�j
		Dim UDNDENDT_Chk As String '�ő唄����t�i�󒍒���������p�j
		Dim SMADT_Chk As String '�ő�o�������t�i�󒍒���������p�j
		Dim MAEUKKB As String '�O��敪
		Dim FRNKB As String '�C�O����敪
		Dim TUKKB As String '�ʉ݋敪
		Dim SSAKBN As String '���Z���t�v�Z�敪
		Dim TOKZEIKB As String '����ŋ敪�i���Ӑ�j
		Dim TOKRPSKB As String '����Œ[����������
		Dim TOKZRNKB As String '����Œ[�������敪
		Dim curUrikn_Old() As Decimal '�X�V�O������z    �i�`�[�v�j
		Dim curFUrikn_Old() As Decimal '�X�V�O�O�ݔ�����z�i�`�[�v�j
		Dim curUzeikn_Old() As Decimal '�X�V�O����ō��v  �i�`�[�v�j
		Dim curUrikn_New() As Decimal '�X�V�㔄����z    �i�`�[�v�j
		Dim curFUrikn_New() As Decimal '�X�V��O�ݔ�����z�i�`�[�v�j
		Dim curUzeikn_New() As Decimal '�X�V�����ō��v  �i�`�[�v�j
		Dim curSUrikn_Old As Decimal '�X�V�O������z    �i�����v�j
		Dim curSFUrikn_Old As Decimal '�X�V�O�O�ݔ�����z�i�����v�j
		Dim curSUzeikn_Old As Decimal '�X�V�O����ō��v�@�i�����v�j
		Dim curSUrikn_New As Decimal '�X�V�㔄����z    �i�����v�j
		Dim curSFUrikn_New As Decimal '�X�V��O�ݔ�����z�i�����v�j
		Dim curSUzeikn_New As Decimal '�X�V�����ō��v  �i�����v�j
		Dim bolAKAKRO() As Boolean '�ԍ��쐬�t���O
		Dim bolUpd As Boolean '�X�V�t���O(True�@: �X�V�j
		Dim strErr As String '�G���[�ӏ�
		' === 20071213 === INSERT S - ACE)Nagasawa �������o�͋敪�̒ǉ�
		Dim usrBodyInf() As Cmn_JDNTRA_UDNUpdate '���׏��
		' === 20071213 === INSERT E -
	End Structure
	
	'����g�����X�V���e
	Public Structure Cmn_UDNTRA_Upd
		Dim JDNNO As String '�󒍔ԍ�
		Dim LINNO As String '�s�ԍ�
		Dim URILINNO As String '�s�ԍ�(����g�����j
		Dim RECNO As String '���R�[�h�Ǘ��ԍ�
		Dim SBNNO As String '����
		Dim HINCD As String '���i�R�[�h
		Dim TOKJDNNO As String '�q�撍���ԍ�
		Dim BIKO As String '���l
		Dim URISU As Decimal '���㐔��
		Dim URITK As Decimal '�P��
		Dim FURITK As Decimal '�O�ݒP��
		Dim SIKTK As String '�d�ؒP��
		Dim URIKN As Decimal '������z
		Dim FURIKN As Decimal '�O�ݔ�����z
		Dim SIKKN As Decimal '�d�؋��z
		Dim UZEKN As Decimal '����Ŋz
		Dim HNURIKN As Decimal '�ԕi��������z
		Dim HNFURIKN As Decimal '�ԕi���O�ݔ���Ŋz
		Dim HNUZEKN As Decimal '�ԕi������Ŋz
		Dim HINZEIKB As String '���i����ŋ敪
		Dim ZEIRT As String '�ŗ�
		Dim bolHNPN As Boolean '�ԕi�t���O�iTrue : �ԕi�L��j
		Dim bolUpd As Boolean '�X�V�t���O�iTrue : �X�V�j
		Dim Bd_Index As Short '�󒍒�����ʂ̊Y���s
		' === 20071213 === INSERT S - ACE)Nagasawa �������o�͋敪�̒ǉ�
		Dim MRPKB As String '�������o�͋敪
		' === 20071213 === INSERT E -
	End Structure
	' === 20070307 === INSERT E -
	'************************************************************************************
	'   Public�萔
	'************************************************************************************
	'�[���v�Z����
	Public Const gc_strRPSKB_D1 As String = "1" '��������
	Public Const gc_strRPSKB_D2 As String = "2" '��������
	Public Const gc_strRPSKB_D3 As String = "3" '������O��
	Public Const gc_strRPSKB_D4 As String = "4" '������l��
	Public Const gc_strRPSKB_D5 As String = "5" '������܈�
	Public Const gc_strRPSKB_I1 As String = "10" '�P
	Public Const gc_strRPSKB_I2 As String = "11" '�P�O
	Public Const gc_strRPSKB_I3 As String = "12" '�P�O�O
	
	' === 20070908 === INSERT S - ACE)Nagasawa �󒍔ԍ�"RA000T"��"RA001T"�͍s�ǉ��s��Ȃ��悤�ɏC��(�󒍔ԍ��̔ԃ~�X)
	Public Const gc_strJDNNO_RA000T As String = "RA000T"
	Public Const gc_strJDNNO_RA001T As String = "RA001T"
	' === 20070908 === INSERT E -
	'************************************************************************************
	'   Public�ϐ�
	'************************************************************************************
	Public Inp_Inf As Cmn_Inp_Inf '���͎ҏ��
	Public GV_SysDate As String '�c�a�T�[�o�[���t
	Public GV_SysTime As String '�c�a�T�[�o�[����
	Public GV_UNYDate As String '�^�p���t
	' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
	Public GV_bolMsgFlg As Boolean '���b�Z�[�W�o�̓t���O
	' === 20060920 === INSERT E
	' === 20140129 === INSERT S - ����)Shikichi
	Public NonRaisedMsg As Boolean '���b�Z�[�W�{�b�N�X���グ�邩�ǂ����̃t���O(False���́A���b�Z�[�W�{�b�N�X�̑���ɁAEVTTBL�e�[�u���ɏ�������)
	' === 20140129 === INSERT E - ����)Shikichi
	' === 20140211 === INSERT S - ����)Shikichi
	Public EvJdnno As String '�C�x���g�������ݗp�󒍔ԍ�
	' === 20140211 === INSERT E - ����)Shikichi
	
	'************************************************************************************
	'   Private�萔
	'************************************************************************************
	' === 20060828 === INSERT S - ACE)Sejima
	'�����O���[�v����p
	Private Const mc_intCD As Short = 1 '�����O���[�v�ݒ肠��
	Private Const mc_intOLDCD As Short = 2 '�������O���[�v�ݒ肠��
	Private Const mc_intTKDT As Short = 4 '�K�p���ݒ肠��
	' === 20060828 === INSERT E
	'************************************************************************************
	'   Private�ϐ�
	'************************************************************************************
	Dim strINIDATNM(4) As String '�h�m�h�̃V���{��
	
	' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
	'************************************************************************************
	'   �L�[�o�b�t�@�N���A�pAPI
	'************************************************************************************
	Private Structure POINTAPI
		Dim X As Integer
		Dim Y As Integer
	End Structure
	Private Structure Msg
		Dim hwnd As Integer
		Dim message As Integer
		Dim wParam As Integer
		Dim lParam As Integer
		Dim time As Integer
		Dim pt As POINTAPI
	End Structure
	'UPGRADE_WARNING: �\���� Msg �ɁA���� Declare �X�e�[�g�����g�̈����Ƃ��ă}�[�V�������O������n���K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"' ���N���b�N���Ă��������B
	Private Declare Function PeekMessage Lib "user32"  Alias "PeekMessageA"(ByRef lpMsg As Msg, ByVal hwnd As Integer, ByVal wMsgFilterMin As Integer, ByVal wMsgFilterMax As Integer, ByVal wRemoveMsg As Integer) As Integer
	Private Const WM_KEYFIRST As Short = &H100s
	Private Const WM_KEYLAST As Short = &H108s
	Private Const PM_REMOVE As Short = &H1s
	' === 20060920 === INSERT E
	
	'''' ADD 2009/03/04  FKS) S.Nakajima    Start
	Public Const gc_strMsgEIGYOSHO_E_001 As String = "2EIGYOSHO_01" '�Ώۂ̉c�Ə����p�~����Ă��܂��B
	'''' ADD 2009/03/04  FKS) S.Nakajima    End
	
	
	' === 20140129 === INSERT S - ����)Shikichi
	'�C�x���g���O�쐬�p�����[�^
	Structure M_TYPE_EVTTBL_PARA
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public IVWRDT() As Char '�C�x���g������
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public IVWRTM() As Char '�C�x���g�J�n����
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public PGID() As Char '�v���O�����h�c
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char '�N���C�A���g�h�c
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public IVCLASS() As Char '�C�x���g���
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public IVCODE() As Char '�C�x���g�R�[�h
		Dim IVMSG As String '�C�x���g���e
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(30),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=30)> Public IVPOINT() As Char '�C�x���g�����ӏ�
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public SNDPROFLG() As Char '���M�ۃt���O
	End Structure
	' === 20140129 === INSERT E - ����)Shikichi
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Init
	'   �T�v�F  �v���O�����N������������
	'   �����F  �Ȃ�
	'   �ߒl�F  �Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Sub CF_Init()
		
		Dim datDT As Date
		Dim DB_TANMTA As TYPE_DB_TANMTA
		Dim DB_UNYMTA As TYPE_DB_UNYMTA
		Dim strYMD As String
		Dim intLenCommand As String
		Dim intRet As Short
		'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    �A���[��702
		Dim strRet As String
		'''' ADD 2009/11/26  FKS) T.Yamamoto    End
		
		'��d�N������
		'UPGRADE_ISSUE: App �v���p�e�B App.PrevInstance �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' ���N���b�N���Ă��������B
		If App.PrevInstance Then
			MsgBox("�y" & Trim(SSS_PrgNm) & "�z�͊��ɋN�����ł��B�d�����ċN�����鎖�͂ł��܂���B", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
			End
		End If
		
		' "���΂炭���҂���������" �E�B���h�E�\��
		'UPGRADE_ISSUE: Load �X�e�[�g�����g �̓T�|�[�g����Ă��܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B530EFF2-3132-48F8-B8BC-D88AF543D321"' ���N���b�N���Ă��������B
		Load(ICN_ICON)
		
		'   ���t�`���`�F�b�N
		datDT = Today
		strYMD = VB6.Format(Year(datDT), "0000") & "/" & VB6.Format(Month(datDT), "00") & "/" & VB6.Format(VB.Day(datDT), "00")
		
		If CStr(datDT) <> strYMD Then
			MsgBox("���t�̌`�� '" & CStr(datDT) & "' ���Ⴂ�܂��B" & vbCrLf & "�R���g���[���p�l���̒n��i�n���̊G�j�̓��t" & vbCrLf & "�̒Z���`���� yyyy/MM/dd �ɕύX���ĉ������B", MsgBoxStyle.Critical)
			Call Error_Exit("���t�̌`�����Ⴂ�܂��B")
		End If
		
		'---------------------
		' �N���p�����[�^�ݒ�
		'---------------------
		'UPGRADE_WARNING: �I�u�W�F�N�g LenWid() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		intLenCommand = LenWid(Trim(VB.Command()))
		If CDbl(intLenCommand) < 15 Then
			MsgBox("���j���[������s���Ă��������B", MsgBoxStyle.OKOnly, SSS_PrgNm)
			Call Error_Exit("���j���[������s���Ă��������B")
		End If
		
		SSS_CLTID.Value = MidWid(VB.Command(), 2, 5)
		SSS_OPEID.Value = MidWid(VB.Command(), 7, 8)
		
		'���[�h�I�����[���[�h�ݒ�
		If Left(VB.Command(), 1) = "'" Then SSS_ReadOnly = True
		
		' === 20060828 === INSERT S - ACE)Sejima �P���ύX�����擾�ɕK�v�Ȃ��߁A������ړ�
		'�^�p���t�擾
		Call CF_Get_UnyDt()
		' === 20060828 === INSERT E
		
		'���͒S���Җ��擾
		Inp_Inf.InpTanCd = SSS_OPEID.Value
		Inp_Inf.InpCLIID = SSS_CLTID.Value
		
		'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    �A���[��702
		'���͒S���ҏ��ݒ�
		gs_userid = SSS_OPEID.Value
		gs_pgid = SSS_PrgId
		
		'�����擾
		strRet = Get_Authority(GV_UNYDate)
		If strRet = "9" Then
			'�N�������Ȃ��̏ꍇ�A�����I��
			Call AE_CmnMsgLibrary_2(SSS_PrgNm, "2RUNAUTH")
			End
		End If
		'''' ADD 2009/11/26  FKS) T.Yamamoto    End
		
		' === 20060830 === UPDATE S - ACE)Nagasawa �����̍l���̏C��
		'    Call DB_TANMTA_Clear(DB_TANMTA)
		'    intRet = DSPTANCD_SEARCH(Inp_Inf.InpTanCd, DB_TANMTA)
		'    If intRet = 0 Then
		'        Inp_Inf.InpTanNm = DB_TANMTA.TANNM              '���͒S���Җ�
		'' === 20060828 === UPDATE S - ACE)Sejima
		''D        Inp_Inf.InpTKCHGKB = DB_TANMTA.TKCHGKB          '�P���ύX����
		'' === 20060828 === UPDATE ��
		'        '�������擾�i�P���ύX�����A�󒍍X�V�����Aetc...�j
		'        Call F_Get_KNG_Inf(DB_TANMTA, GV_UNYDate, Inp_Inf)
		'' === 20060828 === UPDATE E
		'    End If
		
		'���͒S���ҏ��擾
		Call F_Get_INPTANCD_Inf(Inp_Inf.InpTanCd, Inp_Inf)
		' === 20060830 === UPDATE E -
		
		'---------------------
		' SSSWIN.INI �e�[�u���ݒ�
		'---------------------
		strINIDATNM(0) = "USR_PATH"
		strINIDATNM(1) = "DAT_PATH"
		strINIDATNM(2) = "PRG_PATH"
		strINIDATNM(3) = "WRK_PATH"
		strINIDATNM(4) = "IMG_PATH"
		SSS_INICnt = 4
		'Ini�t�@�C���Ǎ���
		Call CF_INIT_GETINI()
		
		' === 20060828 === DELETE S - ACE)Sejima �P���ύX�����擾�ɕK�v�Ȃ��߁A��Ɉړ�
		'D    '�^�p���t�擾
		'D    Call CF_Get_UnyDt
		' === 20060828 === DELETE E
		
		' === 20061102 === INSERT S - ACE)Yano ۸�̧�ُ����݁i�v���O�����N���j
		Call SSSWIN_LOGWRT("�v���O�����N��")
		' === 20061102 === INSERT E
		
		' "���΂炭���҂���������" �E�B���h�E����
		ICN_ICON.Close()
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_INIT_GETINI
	'   �T�v�F  INI�t�@�C���Ǎ��݁i���ʁj
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Sub CF_INIT_GETINI()
		Dim WL_WinDir As String
		Dim I, LENGTH As Short
		Dim rtnPara As New VB6.FixedLengthString(MAX_PATH)
		'---------------------
		' SSSWIN.INI �Ǎ���
		'---------------------
		For I = 0 To SSS_INICnt
			rtnPara.Value = ""
			LENGTH = GetPrivateProfileString("SSSWIN", strINIDATNM(I), "", rtnPara.Value, Len(rtnPara.Value), "SSSWIN.INI")
			If LENGTH = 0 Then
				MsgBox("SSSWIN.INI ���m�F���Ă��������B" & Chr(13) & "[" & strINIDATNM(I) & "]")
				Call Error_Exit("SSSUSR.INI ���m�F���Ă��������B[" & strINIDATNM(I) & "]")
			Else
				SSS_INIDAT(I) = LeftWid(rtnPara.Value, LENGTH)
			End If
			If Right(SSS_INIDAT(I), 1) <> "\" And Right(SSS_INIDAT(I), 1) <> ":" Then SSS_INIDAT(I) = SSS_INIDAT(I) & "\"
		Next I
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_DspLineNo
	'   �T�v�F  �\���p�s�ԍ��擾
	'   �����F�@pm_Def_LineNo
	'           pm_HIKET51_DSP_DATA    :��ʋƖ����\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Get_DspLineNo(ByRef pm_Def_LineNo As String, ByRef pm_JdnTrKb As String) As String
		
		Dim Ret_Value As String
		
		Select Case pm_JdnTrKb
			Case gc_strJDNTRKB_SET
				'�Z�b�g�A�b�v�͓��Q��
				Ret_Value = Mid(pm_Def_LineNo, 1, 2)
				
			Case Else
				'�ȊO�͌�Q��
				Ret_Value = Mid(pm_Def_LineNo, 2, 2)
				
		End Select
		
		F_Get_DspLineNo = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_TANNM
	'   �T�v�F  �S���Җ��̎擾
	'   �����F�@pm_Def_LineNo
	'           pm_HIKET51_DSP_DATA    :��ʋƖ����\����
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_TANNM(ByRef pm_TANCD As String) As String
		
		Dim Ret_Value As String
		Dim DB_TANMTA As TYPE_DB_TANMTA
		Dim intRet As Short
		
		Ret_Value = ""
		
		'�S���҃}�X�^����
		Call DB_TANMTA_Clear(DB_TANMTA)
		intRet = DSPTANCD_SEARCH(pm_TANCD, DB_TANMTA)
		If intRet = 0 Then
			Ret_Value = DB_TANMTA.TANNM
		End If
		
		CF_Get_TANNM = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Frm_Location
	'   �T�v�F  �����\���ʒu�ݒ�
	'   �����F�@pm_Form        :�t�H�[��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Frm_Location(ByRef pm_Form As System.Windows.Forms.Form) As Short
		
		With pm_Form
			.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(.Width)) / 2)
			.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(.Height)) / 2)
		End With
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Set_Frm_IN_TANCD
	'   �T�v�F  ���͒S���ҕҏW
	'   �����F�@pm_Form        :�t�H�[��
	'   �ߒl�F�@�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Set_Frm_IN_TANCD(ByRef pm_Form As System.Windows.Forms.Form, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		
		With pm_Form
			'���͒S���҃R�[�h
			'UPGRADE_ISSUE: Control HD_IN_TANCD �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Trg_Index = CShort(.HD_IN_TANCD.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanCd, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
			
			'���͒S���Җ�
			'UPGRADE_ISSUE: Control HD_IN_TANNM �́A�ėp���O��� Form ���ɂ��邽�߁A�����ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' ���N���b�N���Ă��������B
			Trg_Index = CShort(.HD_IN_TANNM.Tag)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Cnv_Dsp_Item() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g Dsp_Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanNm, pm_All.Dsp_Sub_Inf(Trg_Index), False)
			Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
		End With
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_SYSTBASaiban
	'   �T�v�F  �`�[�Ǘ�NO�̔ԏ���
	'   �����F�@Pm_strDATNO()  :�`�[�Ǘ�No
	'           Pm_strRECNO()  :���R�[�h�Ǘ�No
	'   �ߒl�F  0:����  1:�f�[�^����  2:Lock��  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_SYSTBASaiban(ByRef pot_strDatNo() As String, ByRef pot_strRECNO() As String) As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDatNo As Decimal
		Static curRecNo As Decimal
		Static intCnt As Short
		Static strDATNO As String
		Static strRecNo As String
		
		On Error GoTo ERR_AE_SYSTBASaiban
		
		AE_SYSTBASaiban = 9
		
		bolTran = False
		
		'�g�����U�N�V�����J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'���[�U�[���Ǘ��e�[�u���擾
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBA        "
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    strSQL = strSQL & "    for Update NoWait "
		strSQL = strSQL & "    for Update  "
		' === 20061108 === UPDATE E -
		
		'SQL���s
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
		' === 20061108 === UPDATE E -
		If bolRet = False Then
			GoTo ERR_AE_SYSTBASaiban
		End If
		
		'EOF����
		If CF_Ora_EOF(usrOdy) = True Then
			AE_SYSTBASaiban = 1
			GoTo ERR_AE_SYSTBASaiban
		End If
		
		'�`�[�Ǘ�No�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		curDatNo = CDec(CF_Ora_GetDyn(usrOdy, "DATNO", "0")) + 1
		If curDatNo > 9999999999# Then
			'9999999999�𒴂����ꍇ�͖߂�
			curDatNo = 1
		End If
		For intCnt = 1 To UBound(pot_strDatNo)
			pot_strDatNo(intCnt) = VB6.Format(CStr(curDatNo), "0000000000")
			curDatNo = curDatNo + 1
			If curDatNo > 9999999999# Then
				'9999999999�𒴂����ꍇ�͖߂�
				curDatNo = 1
			End If
		Next intCnt
		
		'���R�[�h�Ǘ�No�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		curRecNo = CDec(CF_Ora_GetDyn(usrOdy, "RECNO", "0")) + 1
		If curRecNo > 9999999999# Then
			'9999999999�𒴂����ꍇ�͖߂�
			curRecNo = 1
		End If
		
		For intCnt = 1 To UBound(pot_strRECNO)
			pot_strRECNO(intCnt) = VB6.Format(CStr(curRecNo), "0000000000")
			curRecNo = curRecNo + 1
			If curRecNo > 9999999999# Then
				'9999999999�𒴂����ꍇ�͖߂�
				curRecNo = 1
			End If
		Next intCnt
		
		'���[�U�[���Ǘ��e�[�u���X�V
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    usrOdy.Obj_Ody.Edit
		'    usrOdy.Obj_Ody.Fields("DATNO").Value = pot_strDatNo(UBound(pot_strDatNo))
		'    If UBound(Pot_strRECNO) > 0 Then
		'        usrOdy.Obj_Ody.Fields("RECNO").Value = Pot_strRECNO(UBound(Pot_strRECNO))
		'    End If
		'    If Trim(GV_SysTime) <> "" Then
		'        usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
		'    End If
		'    If Trim(GV_SysDate) <> "" Then
		'        usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
		'    End If
		'    usrOdy.Obj_Ody.Update
		
		If Trim(pot_strDatNo(UBound(pot_strDatNo))) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strDATNO = CF_Ora_GetDyn(usrOdy, "DATNO", "")
		Else
			strDATNO = pot_strDatNo(UBound(pot_strDatNo))
		End If
		
		If Trim(pot_strRECNO(UBound(pot_strRECNO))) = "" Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strRecNo = CF_Ora_GetDyn(usrOdy, "RECNO", "")
		Else
			strRecNo = pot_strRECNO(UBound(pot_strRECNO))
		End If
		
		strSQL = ""
		strSQL = strSQL & " UPDATE SYSTBA "
		strSQL = strSQL & "    SET DATNO = '" & strDATNO & "' "
		strSQL = strSQL & "      , RECNO = '" & strRecNo & "' "
		
		'�r�p�k���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBASaiban
		End If
		' === 20061108 === UPDATE E -
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBASaiban
		End If
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		AE_SYSTBASaiban = 0
		
EXIT_AE_SYSTBASaiban: 
		Exit Function
		
ERR_AE_SYSTBASaiban: 
		
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    If gv_Int_OraErr = 54 Then
		If gv_Int_OraErr = 2049 Then
			' === 20061108 === UPDATE E -
			'���Ŏg�p��
			AE_SYSTBASaiban = 2
		End If
		
		If bolTran = True Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBASaiban
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_SYSTBCSaiban
	'   �T�v�F  �`�[NO�̔ԏ���
	'   �����F�@Pin_strDKBSB     :�̔ԑΏۂ̓`�[����敪���
	'           Pot_strDENNO     :�擾���ꂽ�`�[��
	'           Pin_strADDDENCD  :���ϔԍ��̍̔Ԃ̏ꍇ�A�����N��(�����U���j
	'           Pin_strKbn       :�󒍔ԍ��̏ꍇ����敪
	'   �ߒl�F  0:����  1:�f�[�^����  2:Lock��  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'2017/03/02 CHG START CIS <�ۋ��V�X�e���Ή�>
	'Public Static Function AE_SYSTBCSaiban(ByVal Pin_strDKBSB As String, _
	''                                       ByRef Pot_strDENNO As String, _
	''                                       Optional ByVal Pin_strADDDENCD As String, _
	''                                       Optional ByVal Pin_strKbn As String) As Integer
	Public Function AE_SYSTBCSaiban(ByVal Pin_strDKBSB As String, ByRef Pot_strDENNO As String, Optional ByVal Pin_strADDDENCD As String = "", Optional ByVal Pin_strKbn As String = "", Optional ByVal Pin_bolService As Boolean = False) As Short
		'2017/03/02 CHG E N D CIS <�ۋ��V�X�e���Ή�>
		
		Static strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDENNO As Decimal
		Static strDenNo As String
		Static intCnt As Short
		Static strRtn As String
		Static strFixCd As String
		' === 20060814 === INSERT S - ACE)Nagasawa
		Static intRet As Short
		' === 20060814 === INSERT E -
		' === 20061119 === INSERT S - ACE)Nagasawa
		Static strDate As String
		Static strTime As String
		' === 20061119 === INSERT E -
		' === 20070909 === INSERT S - ACE)Nagasawa �󒍔ԍ������Ɏ󒍌��o���g�����ɑ��݂���ꍇ�͂Ƃ΂�("RA000T"��"RA001T"�͎g�p�s��)
		Static bolJDNNO_OK As Boolean
		'UPGRADE_WARNING: �\���� usrOdy_JDN �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Static usrOdy_JDN As U_Ody
		' === 20070909 === INSERT E -
		
		On Error GoTo ERR_AE_SYSTBCSaiban
		
		AE_SYSTBCSaiban = 9
		
		bolTran = False
		Pot_strDENNO = ""
		strFixCd = ""
		
		'UPGRADE_NOTE: IsMissing() �� IsNothing() �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="8AE1CB93-37AB-439A-A4FF-BE3B6760BB23"' ���N���b�N���Ă��������B
		If IsNothing(Pin_strADDDENCD) = True And Pin_strDKBSB = gc_strDKBSB_MIT Then
			GoTo EXIT_AE_SYSTBCSaiban
		End If
		
		'�g�����U�N�V�����J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		Select Case Pin_strDKBSB
			'���ϔԍ��̍̔�
			Case gc_strDKBSB_MIT
				
				' === 20060814 === UPDATE S - ACE)Nagasawa
				'            '���[�U�[�`�[No�e�[�u���擾
				'            strSQL = ""
				'            strSQL = strSQL & " Select *             "
				'            strSQL = strSQL & "   from SYSTBC        "
				'            strSQL = strSQL & "  Where DKBSB    = '" & Pin_strDKBSB & "' "
				'            strSQL = strSQL & "    and ADDDENCD = '" & Pin_strADDDENCD & "' "
				'            strSQL = strSQL & "    for Update NoWait "
				'
				'            'SQL���s
				'            bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
				'            If bolRet = False Then
				'                GoTo ERR_AE_SYSTBCSaiban
				'            End If
				'
				'            'EOF����
				'            If CF_Ora_EOF(usrOdy) = True Then
				'                Pot_strDENNO = "00000001"
				'                '���[�U�[�`�[No�e�[�u���ǉ�
				'                usrOdy.Obj_Ody.AddNew
				'                usrOdy.Obj_Ody.Fields("DKBSB").Value = gc_strDKBSB_MIT              '�`�[����敪���
				'                usrOdy.Obj_Ody.Fields("ADDDENCD").Value = Pin_strADDDENCD           '�`�[�t������
				'                usrOdy.Obj_Ody.Fields("DENNM").Value = gc_strDENNM_MIT              '�`�[����
				'                usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO                 '�`�[No
				'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '�ŏI��ƎҺ���
				'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    '�N���C�A���gID
				'                If Trim(GV_SysTime) <> "" Then
				'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime               '�^�C���X�^���v�i���ԁj
				'                Else
				'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
				'                End If
				'                If Trim(GV_SysDate) <> "" Then
				'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate               '�^�C���X�^���v�i���t�j
				'                Else
				'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
				'                End If
				'                usrOdy.Obj_Ody.Update
				'            Else
				'                curDenNo = CCur(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
				'
				'                '���ϔԍ��͂S��
				'                If curDenNo > 9999 Then
				'                    curDenNo = 1
				'                End If
				'                strDenNo = Format(CStr(curDenNo), "00000000")
				'
				'                Pot_strDENNO = strDenNo
				'
				'                '���[�U�[�`�[No�e�[�u���X�V
				'                usrOdy.Obj_Ody.Edit
				'                usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO                     '�`�[No
				'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '�ŏI��ƎҺ���
				'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    '�N���C�A���gID
				'                If Trim(GV_SysTime) <> "" Then
				'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
				'                Else
				'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
				'                End If
				'                If Trim(GV_SysDate) <> "" Then
				'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
				'                Else
				'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
				'                End If
				'                usrOdy.Obj_Ody.Update
				'            End If
				'
				'            bolRet = CF_Ora_CloseDyn(usrOdy)
				'            If bolRet = False Then
				'                    GoTo ERR_AE_SYSTBCSaiban
				'            End If
				
				'���ϔԍ��̔ԏ���
				intRet = F_SYSTBC_Update(Pin_strADDDENCD, Pot_strDENNO)
				If intRet <> 0 Then
					AE_SYSTBCSaiban = intRet
					GoTo ERR_AE_SYSTBCSaiban
				End If
				' === 20060814 === UPDATE E -
				
				'�󒍔ԍ��̍̔�
			Case gc_strDKBSB_UOD
				'�̔ԃ}�X�^�擾
				strSQL = ""
				strSQL = strSQL & " Select *             "
				strSQL = strSQL & "   from SAIMTA        "
				strSQL = strSQL & "  Where SDKBSB   = '" & gc_strSDKBSB_UOD & "' "
				' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
				'            strSQL = strSQL & "    for Update NoWait "
				strSQL = strSQL & "    for Update "
				' === 20061108 === UPDATE E -
				
				'SQL���s
				' === 20061119 === UPDATE S - ACE)Nagasawa
				'            bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
				bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
				' === 20061119 === UPDATE E -
				If bolRet = False Then
					GoTo ERR_AE_SYSTBCSaiban
				End If
				
				' === 20061119 === INSERT S - ACE)Nagasawa
				'�^�C���X�^���v����
				strDate = ""
				strTime = ""
				If Trim(GV_SysTime) <> "" Then
					'                strDate = GV_SysTime
					strDate = GV_SysDate
					strTime = GV_SysTime
				Else
					strDate = CStr(VB6.Format(Now, "yyyymmdd"))
					strTime = CStr(VB6.Format(Now, "hhmmss"))
				End If
				' === 20061119 === INSERT E -
				
				'EOF����
				If CF_Ora_EOF(usrOdy) = True Then
					' === 20060927 === UPDATE S - ACE)Nagasawa
					'                Pot_strDENNO = "00001"
					Pot_strDENNO = "0001"
					' === 20060927 === UPDATE E -
					
					' === 20070909 === INSERT S - ACE)Nagasawa
					strFixCd = "R"
					' === 20070909 === INSERT E - ACE)Nagasawa
					
					'���[�U�[�`�[No�e�[�u���ǉ�
					' === 20061119 === UPDATE S - ACE)Nagasawa
					'                usrOdy.Obj_Ody.AddNew
					'                usrOdy.Obj_Ody.Fields("SDKBSB").Value = gc_strSDKBSB_UOD            '�`�[���
					'                usrOdy.Obj_Ody.Fields("FIXCD").Value = "R"                          '�Œ�l
					'                strFixCd = "R"
					'                usrOdy.Obj_Ody.Fields("SDENNO").Value = Pot_strDENNO                '�A��
					'                usrOdy.Obj_Ody.Fields("SAIKBA").Value = Space(1)                    '�敪�P
					'                usrOdy.Obj_Ody.Fields("SAIKBB").Value = Space(1)                    '�敪�Q
					'                usrOdy.Obj_Ody.Fields("SAIKBC").Value = Space(1)                    '�敪�R
					'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '�ŏI��ƎҺ���
					'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    '�N���C�A���gID
					'                If Trim(GV_SysTime) <> "" Then
					'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime               '�^�C���X�^���v�i���ԁj
					'                    usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = GV_SysTime            '�^�C���X�^���v�i�o�^���ԁj
					'                End If
					'                If Trim(GV_SysDate) <> "" Then
					'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate               '�^�C���X�^���v�i���t�j
					'                    usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = GV_SysDate            '�^�C���X�^���v�i�o�^���t�j
					'                End If
					'                usrOdy.Obj_Ody.Update
					
					strSQL = ""
					' === 20070909 === UPDATE S - ACE)Nagasawa
					'                strSQL = strSQL & " INSERT INTO SYSTBC "
					strSQL = strSQL & " INSERT INTO SAIMTA "
					strSQL = strSQL & " ( "
					' === 20070909 === UPDATE E -
					strSQL = strSQL & "     SDKBSB    "
					strSQL = strSQL & "   , FIXCD     "
					strSQL = strSQL & "   , SDENNO    "
					strSQL = strSQL & "   , SAIKBA    "
					strSQL = strSQL & "   , SAIKBB    "
					strSQL = strSQL & "   , SAIKBC    "
					strSQL = strSQL & "   , FOPEID    "
					strSQL = strSQL & "   , FCLTID    "
					strSQL = strSQL & "   , WRTFSTTM  "
					strSQL = strSQL & "   , WRTFSTDT  "
					strSQL = strSQL & "   , OPEID     "
					strSQL = strSQL & "   , CLTID     "
					strSQL = strSQL & "   , WRTTM     "
					strSQL = strSQL & "   , WRTDT     "
					strSQL = strSQL & "   , UOPEID    "
					strSQL = strSQL & "   , UCLTID    "
					strSQL = strSQL & "   , UWRTTM    "
					strSQL = strSQL & "   , UWRTDT    "
					strSQL = strSQL & "   , PGID      "
					' === 20070909 === INSERT S - ACE)Nagasawa
					strSQL = strSQL & " ) "
					' === 20070909 === INSERT E -
					strSQL = strSQL & " VALUES  "
					strSQL = strSQL & "   ( '" & gc_strSDKBSB_UOD & "' "
					strSQL = strSQL & "   , '" & "R" & "' "
					strSQL = strSQL & "   , '" & Pot_strDENNO & "' "
					' === 20070909 === UPDATE S - ACE)Nagasawa
					'                strSQL = strSQL & "   , '" & "Space(1) & " ' "
					'                strSQL = strSQL & "   , '" & "Space(1) & " ' "
					'                strSQL = strSQL & "   , '" & "Space(1) & " ' "
					strSQL = strSQL & "   , '" & Space(1) & "' "
					strSQL = strSQL & "   , '" & Space(1) & "' "
					strSQL = strSQL & "   , '" & Space(1) & "' "
					' === 20070909 === UPDATE E -
					strSQL = strSQL & "   , '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , '" & strTime & "' "
					strSQL = strSQL & "   , '" & strDate & "' "
					strSQL = strSQL & "   , '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , '" & strTime & "' "
					strSQL = strSQL & "   , '" & strDate & "' "
					strSQL = strSQL & "   , '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , '" & strTime & "' "
					strSQL = strSQL & "   , '" & strDate & "' "
					strSQL = strSQL & "   , '" & SSS_PrgId & "') "
					' === 20061119 === UPDATE E -
				Else
					'�A�Ԏ擾
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strDenNo = CF_Ora_GetDyn(usrOdy, "SDENNO", "")
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strFixCd = CF_Ora_GetDyn(usrOdy, "FIXCD", "")
					
					If strDenNo = "" Then
						GoTo ERR_AE_SYSTBCSaiban
					End If
					
					' === 20070909 === INSERT S - ACE)Nagasawa �󒍔ԍ������Ɏ󒍌��o���g�����ɑ��݂���ꍇ�͂Ƃ΂�("RA000T"��"RA001T"�͎g�p�s��)
					bolJDNNO_OK = False
					Do Until bolJDNNO_OK = True
						' === 20070909 === INSERT E -
						
						'�󒍔ԍ�
						For intCnt = 4 To 1 Step -1
							'CHG START FKS)INABA 2007/09/07 *************************************************************************
							bolRet = JDNNO_CntUp(Mid(strDenNo, intCnt, 1), strRtn)
							strDenNo = Left(strDenNo, intCnt - 1) & strRtn & Mid(strDenNo, intCnt + 1)
							'                    bolRet = JDNNO_CntUp(Mid(strDenNo, 1 + intCnt, 1), strRtn)
							'                    strDenNo = Left(strDenNo, 1 + intCnt - 1) & strRtn & Mid(strDenNo, 1 + intCnt + 1)
							'CHG  END  FKS)INABA 2007/09/07 *************************************************************************
							If bolRet = False Then
								Exit For
							End If
						Next intCnt
						
						' === 20060927 === INSERT S - ACE)Nagasawa
						'                If strDenNo = "00000" Then
						'                   strDenNo = "00001"
						'                End If
						If Trim(strDenNo) = "0000" Then
							strDenNo = "0001 "
						End If
						' === 20060927 === INSERT E -
						
						' === 20070909 === INSERT S - ACE)Nagasawa �󒍔ԍ������Ɏ󒍌��o���g�����ɑ��݂���ꍇ�͂Ƃ΂�("RA000T"��"RA001T"�͎g�p�s��)
						'"RA000T"��"RA001T"�͏��O
						If Mid(strDenNo, 1, 4) <> Mid(gc_strJDNNO_RA000T, 3, 4) And Mid(strDenNo, 1, 4) <> Mid(gc_strJDNNO_RA001T, 3, 4) Then
							'�󒍃}�X�^����
							strSQL = ""
							strSQL = strSQL & " Select JDNNO         "
							strSQL = strSQL & "   from JDNTHA        "
							'2017/04/06 CHG START CIS <�ۋ��V�X�e���Ή�>
							'                        strSQL = strSQL & "  Where JDNNO IN ('" & strFixCd & "A" & Mid(strDenNo, 1, 4) & "' "
							'                        strSQL = strSQL & "                , '" & strFixCd & "B" & Mid(strDenNo, 1, 4) & "' "
							'                        strSQL = strSQL & "                , '" & strFixCd & "S" & Mid(strDenNo, 1, 4) & "')"
							strSQL = strSQL & "  Where JDNNO IN ('" & strFixCd & "A" & Mid(strDenNo, 1, 4) & "' "
							strSQL = strSQL & "                , '" & strFixCd & "B" & Mid(strDenNo, 1, 4) & "' "
							strSQL = strSQL & "                , '" & strFixCd & "S" & Mid(strDenNo, 1, 4) & "' "
							strSQL = strSQL & "                , '" & strFixCd & "T" & Mid(strDenNo, 1, 4) & "' "
							strSQL = strSQL & "                , '" & strFixCd & "U" & Mid(strDenNo, 1, 4) & "')"
							'2017/04/06 CHG E N D CIS <�ۋ��V�X�e���Ή�>
							
							'SQL���s
							bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_JDN, strSQL)
							If bolRet = False Then
								GoTo ERR_AE_SYSTBCSaiban
							End If
							
							'EOF����
							If CF_Ora_EOF(usrOdy_JDN) = True Then
								bolJDNNO_OK = True
							End If
							
							bolRet = CF_Ora_CloseDyn(usrOdy_JDN)
							If bolRet = False Then
								GoTo ERR_AE_SYSTBCSaiban
							End If
						End If
						
					Loop 
					' === 20070909 === INSERT E -
					
					Pot_strDENNO = strDenNo
					
					'���[�U�[�`�[No�e�[�u���X�V
					' === 20061119 === UPDATE S - ACE)Nagasawa
					'                usrOdy.Obj_Ody.Edit
					'                usrOdy.Obj_Ody.Fields("SDENNO").Value = Pot_strDENNO                '�`�[No
					'                usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID                    '�ŏI��ƎҺ���
					'                usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID                    '�N���C�A���gID
					'                If Trim(GV_SysTime) <> "" Then
					'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
					'                Else
					'                    usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
					'                End If
					'                If Trim(GV_SysDate) <> "" Then
					'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
					'                Else
					'                    usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
					'                End If
					'                usrOdy.Obj_Ody.Update
					
					strSQL = ""
					strSQL = strSQL & " UPDATE SAIMTA "
					strSQL = strSQL & " SET "
					strSQL = strSQL & "     SDENNO = '" & Pot_strDENNO & "' "
					strSQL = strSQL & "   , OPEID  = '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , CLTID  = '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , WRTTM  = '" & strTime & "' "
					strSQL = strSQL & "   , WRTDT  = '" & strDate & "' "
					strSQL = strSQL & "   , UOPEID = '" & SSS_OPEID.Value & "' "
					strSQL = strSQL & "   , UCLTID = '" & SSS_CLTID.Value & "' "
					strSQL = strSQL & "   , UWRTTM = '" & strTime & "' "
					strSQL = strSQL & "   , UWRTDT = '" & strDate & "' "
					strSQL = strSQL & "   , PGID   = '" & SSS_PrgId & "' "
					strSQL = strSQL & "  WHERE SDKBSB   = '" & gc_strSDKBSB_UOD & "' "
					' === 20061119 === UPDATE E -
				End If
				
				' === 20061119 === INSERT S - ACE)Nagasawa
				'SQL���s
				bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
				If bolRet = False Then
					GoTo ERR_AE_SYSTBCSaiban
				End If
				' === 20061119 === INSERT E -
				
				bolRet = CF_Ora_CloseDyn(usrOdy)
				If bolRet = False Then
					GoTo ERR_AE_SYSTBCSaiban
				End If
				
		End Select
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		'�̔�
		Select Case Pin_strDKBSB
			'���ϔԍ�
			Case gc_strDKBSB_MIT
				Pot_strDENNO = Mid(Pin_strADDDENCD, 3, 4) & Mid(Pot_strDENNO, 5, 4)
				
				'�󒍔ԍ�
			Case gc_strDKBSB_UOD
				Select Case Pin_strKbn
					' === 20060927 === UPDATE S - ACE)Nagasawa
					'                Case gc_strJDNTRKB_TAN                     '�P�i
					'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_SET                     '�Z�b�g�A�b�v
					'                    Pot_strDENNO = strFixCd & "B" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_SYS                     '�V�X�e��
					'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_SYR                     '�C��
					'                    Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_HSY                     '�ێ�
					'                    Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_KAS                     '�ݏo
					'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					'                Case gc_strJDNTRKB_ELS                     '���̑�
					'                    Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 2, 4)
					Case gc_strJDNTRKB_TAN '�P�i
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
					Case gc_strJDNTRKB_SET '�Z�b�g�A�b�v
						Pot_strDENNO = strFixCd & "B" & Mid(Pot_strDENNO, 1, 4)
					Case gc_strJDNTRKB_SYS '�V�X�e��
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
					Case gc_strJDNTRKB_SYR '�C��
						'2017/03/02 CHG START CIS <�ۋ��V�X�e���Ή�>
						'Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 1, 4)
						Pot_strDENNO = strFixCd & "T" & Mid(Pot_strDENNO, 1, 4)
						'2017/03/02 CHG E N D CIS <�ۋ��V�X�e���Ή�>
					Case gc_strJDNTRKB_HSY '�ێ�
						'2017/03/02 CHG START CIS <�ۋ��V�X�e���Ή�>
						'Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 1, 4)
						If Pin_bolService = True Then
							'�T�[�r�X�i�Ԃ̏ꍇ
							Pot_strDENNO = strFixCd & "U" & Mid(Pot_strDENNO, 1, 4)
						Else
							Pot_strDENNO = strFixCd & "S" & Mid(Pot_strDENNO, 1, 4)
						End If
						'2017/03/02 CHG E N D CIS <�ۋ��V�X�e���Ή�>
					Case gc_strJDNTRKB_KAS '�ݏo
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
					Case gc_strJDNTRKB_ELS '���̑�
						Pot_strDENNO = strFixCd & "A" & Mid(Pot_strDENNO, 1, 4)
						' === 20060927 === UPDATE E -
					Case Else
				End Select
			Case Else
				
		End Select
		
		AE_SYSTBCSaiban = 0
		
EXIT_AE_SYSTBCSaiban: 
		Exit Function
		
ERR_AE_SYSTBCSaiban: 
		
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    If gv_Int_OraErr = 54 Then
		If gv_Int_OraErr = 51 Then
			' === 20061108 === UPDATE E -
			'���Ŏg�p��
			AE_SYSTBCSaiban = 2
		End If
		
		If bolTran = True Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBCSaiban
		
	End Function
	
	' === 20060814 === INSERT S - ACE)Nagasawa
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_SYSTBC_Update
	'   �T�v�F  SYSTBC�X�V����
	'   �����F�@Pin_strADDDENCD  :�����N��(�����U���j
	' �@�@�@�@�@Pot_strDENNO     :�擾���ꂽ�`�[��
	'   �ߒl�F  0:����  1:�f�[�^����  2:Lock��  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SYSTBC_Update(ByVal Pin_strADDDENCD As String, ByRef Pot_strDENNO As String) As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static curDENNO As Decimal
		Static strDenNo As String
		Static strSTTNO As String
		Static strENDNO As String
		
		On Error GoTo ERR_F_SYSTBC_Update
		
		F_SYSTBC_Update = 9
		
		Pot_strDENNO = ""
		strSTTNO = ""
		strENDNO = ""
		
		'���[�U�[�`�[No�e�[�u���擾
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBC        "
		strSQL = strSQL & "  Where DKBSB    = '" & gc_strDKBSB_MIT & "' "
		strSQL = strSQL & "    and ADDDENCD = '" & Pin_strADDDENCD & "' "
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    strSQL = strSQL & "    for Update NoWait "
		strSQL = strSQL & "    for Update "
		' === 20061108 === UPDATE E -
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
		If bolRet = False Then
			GoTo ERR_F_SYSTBC_Update
		End If
		
		'EOF����
		If CF_Ora_EOF(usrOdy) = True Then
			strSTTNO = "00000001"
			strENDNO = "00009999"
			Pot_strDENNO = strSTTNO
			'���[�U�[�`�[No�e�[�u���ǉ�
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.AddNew �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.AddNew()
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("DKBSB").Value = gc_strDKBSB_MIT '�`�[����敪���
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("ADDDENCD").Value = Pin_strADDDENCD '�`�[�t������
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("DENNM").Value = gc_strDENNM_MIT '�`�[����
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO '�`�[No
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("STTNO").Value = strSTTNO '�J�n�`�[NO.
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("ENDNO").Value = strENDNO '�I���`�[NO.
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO '�`�[No
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID.Value '�ŏI��ƎҺ���
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID.Value '�N���C�A���gID
			If Trim(GV_SysTime) <> "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime '�^�C���X�^���v�i���ԁj
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = GV_SysTime '�^�C���X�^���v�i�o�^���ԁj
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(VB6.Format(Now, "hhmmss"))
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTFSTTM").Value = CStr(VB6.Format(Now, "hhmmss"))
			End If
			If Trim(GV_SysDate) <> "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate '�^�C���X�^���v�i���t�j
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = GV_SysDate '�^�C���X�^���v�i�o�^���t�j
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(VB6.Format(Now, "yyyymmdd"))
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTFSTDT").Value = CStr(VB6.Format(Now, "yyyymmdd"))
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Update �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Update()
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curDENNO = CDec(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSTTNO = CF_Ora_GetDyn(usrOdy, "STTNO", "0")
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strENDNO = CF_Ora_GetDyn(usrOdy, "ENDNO", "")
			If IsNumeric(strENDNO) = False Then
				strENDNO = "00009999"
			End If
			
			'���ϔԍ��͂S��
			If curDENNO > CF_Get_CCurString(strENDNO) Then
				curDENNO = CF_Get_CCurString(strSTTNO)
			End If
			strDenNo = VB6.Format(CStr(curDENNO), New String("0", 8))
			
			Pot_strDENNO = strDenNo
			
			'���[�U�[�`�[No�e�[�u���X�V
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Edit �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Edit()
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("DENNO").Value = Pot_strDENNO '�`�[No
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("OPEID").Value = SSS_OPEID.Value '�ŏI��ƎҺ���
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Fields("CLTID").Value = SSS_CLTID.Value '�N���C�A���gID
			If Trim(GV_SysTime) <> "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(VB6.Format(Now, "hhmmss"))
			End If
			If Trim(GV_SysDate) <> "" Then
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
			Else
				'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Fields �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(VB6.Format(Now, "yyyymmdd"))
			End If
			'UPGRADE_WARNING: �I�u�W�F�N�g usrOdy.Obj_Ody.Update �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			usrOdy.Obj_Ody.Update()
		End If
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_F_SYSTBC_Update
		End If
		
		F_SYSTBC_Update = 0
		
EXIT_F_SYSTBC_Update: 
		Exit Function
		
ERR_F_SYSTBC_Update: 
		
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    If gv_Int_OraErr = 54 Then
		If gv_Int_OraErr = 51 Then
			' === 20061108 === UPDATE E -
			'���Ŏg�p��
			F_SYSTBC_Update = 2
		End If
		
		GoTo EXIT_F_SYSTBC_Update
		
	End Function
	' === 20060814 === INSERT E -
	
	' === 20060815 === INSERT S - ACE)Nagasawa
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_SYSTBCSaiban_PUDLNO
	'   �T�v�F  ���o�ɔԍ��̔ԏ���
	'   �����F�@Pm_strJDNTRKB   :�󒍎���敪
	'           Pm_strPUDLNO()  :���o�ɔԍ�
	'           Pm_intEntryKb   :�o�^�����敪�i1:�o�^�@2:�����j
	'   �ߒl�F  0:����  1:�f�[�^����  2:Lock��  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20060822 === UPDATE S - ACE)Sejima ���o�ɔԍ��̔ԏ���
	'DPublic Static Function AE_SYSTBCSaiban_PUDLNO(ByVal Pm_strJDNTRKB As String, _
	''D                                              ByRef Pm_strPUDLNO() As String) As Integer
	' === 20060822 === UPDATE ��
	Public Function AE_SYSTBCSaiban_PUDLNO(ByVal Pm_strJDNTRKB As String, ByRef Pm_strPUDLNO() As String, Optional ByVal Pm_intEntryKb As Short = 1) As Short
		' === 20060822 === UPDATE E
		
		Static strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDENNO As Decimal
		Static curSTTNO As Decimal
		Static curENDNO As Decimal
		Static strADDDENCD As String
		Static intCnt As Short
		Static intGetData As Short
		' === 20060822 === INSERT S - ACE)Sejima
		Static strNewPUDLNO As String 'SYSTBC�X�V�p
		' === 20060822 === INSERT E
		
		On Error GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		
		AE_SYSTBCSaiban_PUDLNO = 9
		
		bolTran = False
		
		intGetData = 0
		'�󒍎���敪�ɂ�蔻��
		Select Case Pm_strJDNTRKB
			'�P�i�A�V�X�e���A���̑�
			Case gc_strJDNTRKB_TAN, gc_strJDNTRKB_SYS, gc_strJDNTRKB_ELS
				intGetData = UBound(Pm_strPUDLNO)
				
				'�Z�b�g�A�b�v
			Case gc_strJDNTRKB_SET
				' === 20070312 === UPDATE S - ACE)Nagasawa �Z�b�g�A�b�v�����o�ɔԍ��͑S���擾
				'' === 20060822 === UPDATE S - ACE)Sejima ���o�ɔԍ��̔ԏ���
				''D            intGetData = 1
				'' === 20060822 === UPDATE ��
				'            Select Case Pm_intEntryKb
				'                Case 1
				'                    '�o�^�̏ꍇ
				'                    intGetData = 1
				'                Case Else
				'                    '�����̏ꍇ
				'                    intGetData = 0
				'
				'            End Select
				'' === 20060822 === UPDATE E
				intGetData = UBound(Pm_strPUDLNO)
				' === 20070312 === UPDATE E -
				
				'�C���A�ێ�A�ݏo
			Case gc_strJDNTRKB_SYR, gc_strJDNTRKB_HSY, gc_strJDNTRKB_KAS
				intGetData = 0
				
			Case Else
		End Select
		
		'�g�����U�N�V�����J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'���[�U�[�`�[���e�[�u���擾
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBC        "
		strSQL = strSQL & "  Where DKBSB    = '" & gc_strDKBSB_PUDL & "' "
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    strSQL = strSQL & "    for Update NoWait "
		strSQL = strSQL & "    for Update "
		' === 20061108 === UPDATE E -
		
		'SQL���s
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL, ORADYN_DEFAULT)
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
		' === 20061108 === UPDATE E -
		If bolRet = False Then
			GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		End If
		
		'EOF����
		If CF_Ora_EOF(usrOdy) = True Then
			AE_SYSTBCSaiban_PUDLNO = 1
			GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		End If
		
		'�`�[�t���R�[�h�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strADDDENCD = Trim(CF_Ora_GetDyn(usrOdy, "ADDDENCD", ""))
		
		'�J�n�`�[No�擾
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "STTNO", "")) = False Then
			curSTTNO = 1
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curSTTNO = CDec(CF_Ora_GetDyn(usrOdy, "STTNO", 0))
		End If
		
		'�I���`�[No�擾
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "ENDNO", "")) = False Then
			curENDNO = 1
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curENDNO = CDec(CF_Ora_GetDyn(usrOdy, "ENDNO", 0))
		End If
		
		'�`�[NO.�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		curDENNO = CDec(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
		If curDENNO > curENDNO Then
			'�I���`�[NO�𒴂����ꍇ�͖߂�
			curDENNO = curSTTNO
		End If
		
		For intCnt = 1 To intGetData
			' === 20060822 === UPDATE S - ACE)Sejima
			'D        Pm_strPUDLNO(intCnt) = strADDDENCD & Format(curDENNO, String(8, "0"))
			' === 20060822 === UPDATE ��
			strNewPUDLNO = VB6.Format(curDENNO, New String("0", 8))
			Pm_strPUDLNO(intCnt) = strADDDENCD & strNewPUDLNO
			' === 20060822 === UPDATE E
			curDENNO = curDENNO + 1
			If curDENNO > curENDNO Then
				'�I���`�[No�𒴂����ꍇ�͖߂�
				curDENNO = curSTTNO
			End If
		Next intCnt
		
		'���[�U�[�`�[���e�[�u���X�V
		If intGetData > 0 Then
			' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
			'        usrOdy.Obj_Ody.Edit
			'' === 20060822 === UPDATE S - ACE)Sejima
			''D        usrOdy.Obj_Ody.Fields("DENNO").Value = Right(Pm_strPUDLNO(UBound(Pm_strPUDLNO)), 8)
			'' === 20060822 === UPDATE ��
			'        usrOdy.Obj_Ody.Fields("DENNO").Value = strNewPUDLNO
			'' === 20060822 === UPDATE E
			'        If Trim(GV_SysTime) <> "" Then
			'            usrOdy.Obj_Ody.Fields("WRTTM").Value = GV_SysTime
			'        Else
			'            usrOdy.Obj_Ody.Fields("WRTTM").Value = CStr(Format(Now, "hhmmss"))
			'        End If
			'        If Trim(GV_SysDate) <> "" Then
			'            usrOdy.Obj_Ody.Fields("WRTDT").Value = GV_SysDate
			'        Else
			'            usrOdy.Obj_Ody.Fields("WRTDT").Value = CStr(Format(Now, "yyyymmdd"))
			'        End If
			'        usrOdy.Obj_Ody.Update
			
			strSQL = ""
			strSQL = strSQL & " UPDATE SYSTBC "
			strSQL = strSQL & "    SET DENNO      = '" & CF_Ora_String(strNewPUDLNO, 8) & "' "
			
			If Trim(GV_SysTime) <> "" Then
				strSQL = strSQL & "      , WRTTM      = '" & CF_Ora_String(GV_SysTime, 6) & "' "
			Else
				strSQL = strSQL & "      , WRTTM      = '" & CStr(VB6.Format(Now, "hhmmss")) & "' "
			End If
			
			If Trim(GV_SysDate) <> "" Then
				strSQL = strSQL & "      , WRTDT      = '" & CF_Ora_String(GV_SysDate, 8) & "' "
			Else
				strSQL = strSQL & "      , WRTDT      = '" & CStr(VB6.Format(Now, "yyyymmdd")) & "' "
			End If
			
			strSQL = strSQL & "  WHERE "
			strSQL = strSQL & "        DKBSB    = '" & gc_strDKBSB_PUDL & "' "
			
			'�r�p�k���s
			bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
			If bolRet = False Then
				GoTo ERR_AE_SYSTBCSaiban_PUDLNO
			End If
			' === 20061108 === UPDATE E -
		End If
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBCSaiban_PUDLNO
		End If
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		AE_SYSTBCSaiban_PUDLNO = 0
		
EXIT_AE_SYSTBCSaiban_PUDLNO: 
		Exit Function
		
ERR_AE_SYSTBCSaiban_PUDLNO: 
		
		' === 20061108 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'    If gv_Int_OraErr = 54 Then
		If gv_Int_OraErr = 51 Then
			' === 20061108 === UPDATE E -
			'���Ŏg�p��
			AE_SYSTBCSaiban_PUDLNO = 2
		End If
		
		If bolTran = True Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBCSaiban_PUDLNO
		
	End Function
	' === 20060815 === INSERT E -
	
	' === 20130719 === INSERT S - FWEST)Koroyasu ����հ�ޑΉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_SYSTBCSaiban_ENDUSRCD
	'   �T�v�F  �G���h���[�U�R�[�h�̔ԏ���
	'   �����F  Pm_strEndUsrCd  :�G���h���[�U�R�[�h
	'   �ߒl�F  0:����  1:�f�[�^����  2:Lock��  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_SYSTBCSaiban_ENDUSRCD(ByRef Pm_strEndUsrCd As String) As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDENNO As Decimal
		Static curSTTNO As Decimal
		Static curENDNO As Decimal
		Static strADDDENCD As String
		Static strNewENDUSRCD As String 'SYSTBC�X�V�p
		
		On Error GoTo ERR_AE_SYSTBCSaiban_ENDUSRCD
		
		AE_SYSTBCSaiban_ENDUSRCD = 9
		
		bolTran = False
		
		'�g�����U�N�V�����J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'���[�U�[�`�[���e�[�u���擾
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBC        "
		strSQL = strSQL & "  Where DKBSB    = '" & gc_strDKBSB_ENDUSRCD & "' "
		strSQL = strSQL & "    for Update "
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBCSaiban_ENDUSRCD
		End If
		
		'EOF����
		If CF_Ora_EOF(usrOdy) = True Then
			AE_SYSTBCSaiban_ENDUSRCD = 1
			GoTo ERR_AE_SYSTBCSaiban_ENDUSRCD
		End If
		
		'�`�[�t���R�[�h�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strADDDENCD = Trim(CF_Ora_GetDyn(usrOdy, "ADDDENCD", ""))
		
		'�J�n�`�[No�擾
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "STTNO", "")) = False Then
			curSTTNO = 1
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curSTTNO = CDec(CF_Ora_GetDyn(usrOdy, "STTNO", 0))
		End If
		
		'�I���`�[No�擾
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "ENDNO", "")) = False Then
			curENDNO = 1
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curENDNO = CDec(CF_Ora_GetDyn(usrOdy, "ENDNO", 0))
		End If
		
		'�`�[NO.�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		curDENNO = CDec(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
		If curDENNO > curENDNO Then
			'�I���`�[NO�𒴂����ꍇ�͖߂�
			curDENNO = curSTTNO
		End If
		
		strNewENDUSRCD = VB6.Format(curDENNO, New String("0", 8))
		Pm_strEndUsrCd = strADDDENCD & VB6.Format(strNewENDUSRCD, New String("0", 5))
		curDENNO = curDENNO + 1
		If curDENNO > curENDNO Then
			'�I���`�[No�𒴂����ꍇ�͖߂�
			curDENNO = curSTTNO
		End If
		
		'���[�U�[�`�[���e�[�u���X�V
		strSQL = ""
		strSQL = strSQL & " UPDATE SYSTBC "
		strSQL = strSQL & "    SET DENNO      = '" & CF_Ora_String(strNewENDUSRCD, 8) & "' "
		
		If Trim(GV_SysTime) <> "" Then
			strSQL = strSQL & "      , WRTTM      = '" & CF_Ora_String(GV_SysTime, 6) & "' "
		Else
			strSQL = strSQL & "      , WRTTM      = '" & CStr(VB6.Format(Now, "hhmmss")) & "' "
		End If
		
		If Trim(GV_SysDate) <> "" Then
			strSQL = strSQL & "      , WRTDT      = '" & CF_Ora_String(GV_SysDate, 8) & "' "
		Else
			strSQL = strSQL & "      , WRTDT      = '" & CStr(VB6.Format(Now, "yyyymmdd")) & "' "
		End If
		
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        DKBSB    = '" & gc_strDKBSB_ENDUSRCD & "' "
		
		'�r�p�k���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBCSaiban_ENDUSRCD
		End If
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_AE_SYSTBCSaiban_ENDUSRCD
		End If
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		AE_SYSTBCSaiban_ENDUSRCD = 0
		
EXIT_AE_SYSTBCSaiban_ENDUSRCD: 
		Exit Function
		
ERR_AE_SYSTBCSaiban_ENDUSRCD: 
		
		If gv_Int_OraErr = 51 Then
			'���Ŏg�p��
			AE_SYSTBCSaiban_ENDUSRCD = 2
		End If
		
		If bolTran = True Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_SYSTBCSaiban_ENDUSRCD
		
	End Function
	' === 20130719 === INSERT E -
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function JDNNO_CntUp
	'   �T�v�F  �󒍔ԍ��J�E���g�A�b�v����
	'   �����F�@pin_strJDNNO     :�J�E���g�A�b�v�Ώە���
	'           pot_strRtn     :�J�E���g�A�b�v�㕶��
	'   �ߒl�F  True:���オ�肠��  False:���オ��Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function JDNNO_CntUp(ByVal pin_strJDNNO As String, ByRef pot_strRtn As String) As Boolean
		
		Dim intJDNNO As Short
		Dim strJdnNo As String
		
		JDNNO_CntUp = False
		
		' === 20060927 === UPDATE S - ACE)Nagasawa
		'    Select Case pin_strJDNNO
		Select Case Trim(pin_strJDNNO)
			' === 20060927 === UPDATE E -
			Case "9"
				pot_strRtn = "A"
				Exit Function
				
			Case "Z"
				pot_strRtn = "0"
				JDNNO_CntUp = True
				Exit Function
				
				' === 20060927 === INSERT S - ACE)Nagasawa
			Case ""
				pot_strRtn = " "
				JDNNO_CntUp = True
				Exit Function
				' === 20060927 === INSERT E -
		End Select
		
		intJDNNO = Asc(pin_strJDNNO)
		pot_strRtn = Chr(intJDNNO + 1)
		
		Select Case pot_strRtn
			Case "I", "O"
				intJDNNO = Asc(pot_strRtn)
				pot_strRtn = Chr(intJDNNO + 1)
			Case Else
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CalcTAX_Meisai
	'   �T�v�F  ����Ōv�Z����
	'   �����F�@Pin_strHINZEIKB    :���i����ŋ敪
	'           Pin_curZEIRT       :����ŗ�
	'           Pin_curTANKA       :�P��(�Ŕ����P��)
	'           Pin_curSURYO       :����
	'           Pin_strTOKZEIKB    :���Ӑ����ŋ敪
	'           Pin_strTOKRPSKB    :����Œ[����������
	'           Pin_strTOKZRNKB    :����Œ[�������敪
	'           Pot_curUZEKN       :����Ŋz
	'   �ߒl�F  True : ����  False : �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061116 === UPDATE S - ACE)Nagasawa �V�X�e���̏ꍇ�͒P�� * ����<>���z���\�Ƃ���
	'Public Static Function AE_CalcTAX_Meisai(ByVal Pin_strHINZEIKB As String, _
	''                                         ByVal Pin_curZEIRT As Currency, _
	''                                         ByVal Pin_curTANKA As Currency, _
	''                                         ByVal Pin_curSURYO As Currency, _
	''                                         ByVal Pin_strTOKZEIKB As String, _
	''                                         ByVal Pin_strTOKRPSKB As String, _
	''                                         ByVal Pin_strTOKZRNKB As String, _
	''                                         ByRef Pot_curUZEKN As Currency) As Integer
	
	Public Function AE_CalcTAX_Meisai(ByVal Pin_strHINZEIKB As String, ByVal Pin_curZEIRT As Decimal, ByVal Pin_curTANKA As Decimal, ByVal Pin_curSURYO As Decimal, ByVal Pin_strTOKZEIKB As String, ByVal Pin_strTOKRPSKB As String, ByVal Pin_strTOKZRNKB As String, ByRef Pot_curUZEKN As Decimal, Optional ByVal Pin_curKingk As Decimal = 0) As Boolean
		' === 20061116 === UPDATE E -
		
		Static curZeigk As Decimal
		Static strRPSKB As String
		
		On Error GoTo ERR_AE_CalcTAX_Meisai
		
		AE_CalcTAX_Meisai = False
		
		Pot_curUZEKN = 0
		
		strRPSKB = ""
		Select Case Pin_strTOKRPSKB
			'�~����
			Case gc_strTOKRPSKB_0
				strRPSKB = gc_strRPSKB_I1
				'�\�~����
			Case gc_strTOKRPSKB_10
				strRPSKB = gc_strRPSKB_I2
				'�S�~����
			Case gc_strTOKRPSKB_100
				strRPSKB = gc_strRPSKB_I3
				
		End Select
		
		Select Case Pin_strHINZEIKB '���i����ŋ敪
			'�����敪�ǂ���
			Case gc_strHINZEIKB_TOK
				Select Case Pin_strTOKZEIKB '���Ӑ����ŋ敪
					'�Ŕ����A�ō���
					Case gc_strTOKZEIKB_KOM, gc_strTOKZEIKB_NUK
						' === 20061116 === UPDATE S - ACE)Nagasawa �V�X�e���̏ꍇ�͒P�� * ����<>���z���\�Ƃ���
						'                    curZeigk = CCur(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
						If Pin_curKingk = 0 Then
							curZeigk = CDec(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
						Else
							curZeigk = Pin_curKingk * Pin_curZEIRT / 100
						End If
						' === 20061116 === UPDATE E -
						Call AE_CalcRoundKingk(curZeigk, strRPSKB, Pin_strTOKZRNKB)
						Pot_curUZEKN = curZeigk
						
						'��ې�
					Case gc_strTOKZEIKB_HIK
						
				End Select
				
				'�Ŕ���,�ō���
			Case gc_strHINZEIKB_KOM, gc_strHINZEIKB_NUK
				' === 20061116 === UPDATE S - ACE)Nagasawa �V�X�e���̏ꍇ�͒P�� * ����<>���z���\�Ƃ���
				'            curZeigk = CCur(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
				If Pin_curKingk = 0 Then
					curZeigk = CDec(Pin_curTANKA * Pin_curSURYO) * Pin_curZEIRT / 100
				Else
					curZeigk = Pin_curKingk * Pin_curZEIRT / 100
				End If
				' === 20061116 === UPDATE E -
				Call AE_CalcRoundKingk(curZeigk, strRPSKB, Pin_strTOKZRNKB)
				Pot_curUZEKN = curZeigk
				'��ې�
			Case gc_strHINZEIKB_HIK
			Case Else
		End Select
		
		AE_CalcTAX_Meisai = True
		
EXIT_AE_CalcTAX_Meisai: 
		
		Exit Function
		
ERR_AE_CalcTAX_Meisai: 
		
		GoTo EXIT_AE_CalcTAX_Meisai
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CalcRoundKingk
	'   �T�v�F  ���z�܂�ߌv�Z����
	'   �����F�@Pio_curKingk       :�܂�ߋ��z
	'           Pin_strRPSKB    :���z�[�����������i����Œ[�����������̏ꍇ
	'           Pin_strZRNKB    :���z�[�������敪
	'   �ߒl�F  �Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Sub AE_CalcRoundKingk(ByRef Pio_curKingk As Decimal, ByVal pin_strRPSKB As String, ByVal pin_strZRNKB As String)
		
		Dim curKingk As Decimal
		Dim curKingk_wk As Decimal
		
		curKingk = 0
		
		Select Case pin_strRPSKB '���z�[����������
			'�P
			Case gc_strRPSKB_I1
				curKingk = Pio_curKingk
				'�P�O
			Case gc_strRPSKB_I2
				curKingk = Pio_curKingk / 10
				'�P�O�O
			Case gc_strRPSKB_I3
				curKingk = Pio_curKingk / 100
				'��������
			Case gc_strRPSKB_D1
				curKingk = Pio_curKingk
				'��������
			Case gc_strRPSKB_D2
				curKingk = Pio_curKingk * 10
				'������O��
			Case gc_strRPSKB_D3
				curKingk = Pio_curKingk * 100
				'������l��
			Case gc_strRPSKB_D4
				curKingk = Pio_curKingk * 1000
				'������܈�
			Case gc_strRPSKB_D5
				curKingk = Pio_curKingk * 10000
		End Select
		
		Select Case pin_strZRNKB '���z�[�������敪
			'�؎̂�
			Case gc_strTOKZRNKB_DWN
				curKingk = Fix(curKingk)
				'�l�̌ܓ�
			Case gc_strTOKZRNKB_RND
				' === 20061115 === UPDATE S - ACE)Nagasawa
				'            curKingk = Round(curKingk)
				If curKingk >= 0 Then
					curKingk = Fix(curKingk + 0.5)
				Else
					curKingk = Fix(curKingk - 0.5)
				End If
				' === 20061115 === UPDATE E -
				'�؂�グ
			Case gc_strTOKZRNKB_UP
				curKingk_wk = Fix(curKingk)
				If curKingk_wk < curKingk Then
					curKingk = curKingk_wk + 1
				Else
					curKingk = curKingk_wk
				End If
		End Select
		
		Select Case pin_strRPSKB '���z�[����������
			'�P
			Case gc_strRPSKB_I1
				curKingk = curKingk
				'�P�O
			Case gc_strRPSKB_I2
				curKingk = curKingk * 10
				'�P�O�O
			Case gc_strRPSKB_I3
				curKingk = curKingk * 100
				'��������
			Case gc_strRPSKB_D1
				curKingk = curKingk
				'��������
			Case gc_strRPSKB_D2
				curKingk = curKingk / 10
				'������O��
			Case gc_strRPSKB_D3
				curKingk = curKingk / 100
				'������l��
			Case gc_strRPSKB_D4
				curKingk = curKingk / 1000
				'������܈�
			Case gc_strRPSKB_D5
				curKingk = curKingk / 10000
		End Select
		
		Pio_curKingk = curKingk
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Calc_SIKRT
	'   �T�v�F  �d�ؗ��v�Z����
	'   �����F�@Pin_curTANKA       :�P��
	'           Pin_curTEIKATK     :�艿
	'           Pin_strTKNZRNKB    :���z�[�������敪
	'   �ߒl�F  �d�ؗ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Calc_SIKRT(ByVal Pin_curTANKA As Decimal, ByVal Pin_curTEIKATK As Decimal, ByVal Pin_strTKNZRNKB As String) As Decimal
		
		Static curSIKRT As Decimal
		Static strZRNKB As String
		
		AE_Calc_SIKRT = 0
		If Pin_curTEIKATK = 0 Then
			curSIKRT = 0
		Else
			curSIKRT = Pin_curTANKA / Pin_curTEIKATK * 100
		End If
		
		Select Case Pin_strTKNZRNKB '���z�[�������敪
			'�؎̂�
			Case gc_strTOKZRNKB_DWN
				strZRNKB = gc_strTOKZRNKB_UP
				'�l�̌ܓ�
			Case gc_strTOKZRNKB_RND
				strZRNKB = gc_strTOKZRNKB_RND
				'�؂�グ
			Case gc_strTOKZRNKB_UP
				strZRNKB = gc_strTOKZRNKB_DWN
		End Select
		
		'���z�ۂߏ���
		' === 20061020 === UPDATE S - ACE)Nagasawa �I�[�o�[�t���[�Ή�
		'    Call AE_CalcRoundKingk(curSIKRT, gc_strRPSKB_D1, strZRNKB)
		Call AE_CalcRoundKingk(curSIKRT, gc_strRPSKB_D2, strZRNKB)
		' === 20061020 === UPDATE E -
		
		AE_Calc_SIKRT = curSIKRT
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Calc_TANKA
	'   �T�v�F  �P���v�Z�����i�d�ؗ����j
	'   �����F�@Pin_curSIKRT       :�d�ؗ�
	'           Pin_curTEIKATK     :�艿
	'           Pin_strTKNRPSKB    :���z�[����������
	'           Pin_strTKNZRNKB    :���z�[�������敪
	'   �ߒl�F  �P��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Calc_TANKA(ByVal Pin_curSIKRT As Decimal, ByVal Pin_curTEIKATK As Decimal, ByVal Pin_strTKNRPSKB As String, ByVal Pin_strTKNZRNKB As String) As Decimal
		
		Static curTanka As Decimal
		
		AE_Calc_TANKA = 0
		curTanka = Pin_curTEIKATK * Pin_curSIKRT / 100
		
		'���z�ۂߏ���
		Call AE_CalcRoundKingk(curTanka, Pin_strTKNRPSKB, Pin_strTKNZRNKB)
		
		AE_Calc_TANKA = curTanka
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Calc_BSART
	'   �T�v�F  �������v�Z����
	'   �����F�@Pin_curTANKA       :�P��
	'           Pin_curSIKTK       :�d�ؒP��
	'           Pin_strTKNRPSKB    :���z�[����������
	'           Pin_strTKNZRNKB    :���z�[�������敪
	'   �ߒl�F  �d�ؗ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Calc_BSART(ByVal Pin_curTANKA As Decimal, ByVal Pin_curSIKTK As Decimal, ByVal Pin_strTKNRPSKB As String, ByVal Pin_strTKNZRNKB As String) As Decimal
		
		Static curBSART As Decimal
		
		AE_Calc_BSART = 0
		
		If Pin_curTANKA = 0 Then
			curBSART = 0
		Else
			curBSART = (Pin_curTANKA - Pin_curSIKTK) / Pin_curTANKA * 100
		End If
		
		'���z�ۂߏ���
		' === 20061025 === UPDATE S - ACE)Nagasawa �K���������ʂŊۂ߂�
		'    Call AE_CalcRoundKingk(curBSART, Pin_strTKNRPSKB, Pin_strTKNZRNKB)
		Call AE_CalcRoundKingk(curBSART, gc_strRPSKB_D2, Pin_strTKNZRNKB)
		' === 20061025 === UPDATE E -
		
		AE_Calc_BSART = curBSART
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CalcDateAdd
	'   �T�v�F  ���t�v�Z����
	'   �����F�@Pio_strDate     :�v�Z�Ώۓ�(�����W���A�܂���yyyy/mm/dd�̌`���j
	'           Pin_intAddDate  :���Z�Ώۓ����i�}�C�i�X�l�͌��Z�j
	'           Pin_strKind     :�c�Ɠ����("1":�c�Ɠ� "2":��s�ғ����@"3":�����ғ����j
	'                            �ȗ����͉c�Ɠ��ɂ��l������
	'   �ߒl�F  0 : ���� 9 : �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CalcDateAdd(ByRef Pio_strDate As String, ByVal Pin_intAddDate As Short, Optional ByVal Pin_strKind As String = "0") As Short
		
		Dim strDate As String
		Dim Mst_Inf As TYPE_DB_CLDMTA
		Dim intAddDate As Short '���t�v�Z�p
		
		AE_CalcDateAdd = 9
		
		strDate = ""
		
		'���t�������`�F�b�N
		If IsDate(Pio_strDate) = True Then
			strDate = Pio_strDate
		End If
		
		'���t�l���ɕϊ�
		If IsDate(VB6.Format(Pio_strDate, "@@@@/@@/@@")) = True Then
			strDate = VB6.Format(Pio_strDate, "@@@@/@@/@@")
		End If
		
		If Trim(strDate) = "" Then
			Exit Function
		End If
		
		'���t���Z
		strDate = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, Pin_intAddDate, CDate(strDate)))
		
		'�J�����_�}�X�^����
		If DSPCLDDT_SEARCH(VB6.Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
			Exit Function
		End If
		
		If Pin_intAddDate >= 0 Then
			intAddDate = 1
		Else
			intAddDate = -1
		End If
		
		Select Case Pin_strKind
			'�c�Ɠ��v�Z
			Case "1"
				Do Until Mst_Inf.SLDKB = "1"
					strDate = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, intAddDate, CDate(strDate)))
					'�J�����_�}�X�^����
					If DSPCLDDT_SEARCH(VB6.Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
						Exit Function
					End If
				Loop 
				
				'��s�ғ����v�Z
			Case "2"
				Do Until Mst_Inf.BNKKDKB = "1"
					strDate = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, intAddDate, CDate(strDate)))
					'�J�����_�}�X�^����
					If DSPCLDDT_SEARCH(VB6.Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
						Exit Function
					End If
				Loop 
				
				'�����ғ����v�Z
			Case "3"
				Do Until Mst_Inf.DTBKDKB = "1"
					strDate = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, intAddDate, CDate(strDate)))
					'�J�����_�}�X�^����
					If DSPCLDDT_SEARCH(VB6.Format(strDate, "yyyymmdd"), Mst_Inf) <> 0 Then
						Exit Function
					End If
				Loop 
				
			Case Else
				
		End Select
		
		Pio_strDate = strDate
		AE_CalcDateAdd = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CmnMsgLibrary
	'   �T�v�F  �W�����b�Z�[�W�\������
	'   �����F  Pin_strPgNm     : �v���O������
	'           Pin_strMsgCode  : ���b�Z�[�W�R�[�h�iDB�����p�j
	'           pm_All  �@�@�@  : ��ʏ��
	'           pin_strMsg      : �ǉ����b�Z�[�W
	'           pin_strHeadMsg  : ���b�Z�[�W�擪�ւ̒ǉ����b�Z�[�W
	'   �ߒl�F  �I���{�^��
	'   ���l�F  �A�v���̎��s���ɏo�͂����W�����b�Z�[�W�B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061031 === UPDATE S - ACE)Nagasawa
	'Public Function AE_CmnMsgLibrary(ByVal Pin_strPgNm As String, _
	''                                 ByVal Pin_strMsgCode As String, _
	''                                 ByRef pm_All As Cls_All, _
	''                                 Optional ByVal pin_strMsg As String = "") As Integer
	Public Function AE_CmnMsgLibrary(ByVal Pin_strPgNm As String, ByVal Pin_strMsgCode As String, ByRef pm_All As Cls_All, Optional ByVal pin_strMsg As String = "", Optional ByVal pin_strHeadMsg As String = "") As Short
		' === 20061031 === UPDATE E -
		
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		Dim strMSGKBN As String
		Dim strMSGNM As String
		Dim strMsg_add As String
		
		' === 20060914 === INSERT S - ACE)Nagasawa
		On Error Resume Next
		' === 20060914 === INSERT E -
		
		AE_CmnMsgLibrary = False
		
		If pm_All.Dsp_IM_Denkyu Is Nothing Then
		Else
			'�v�����v�g���b�Z�[�W�̃N���A
			Call CF_Clr_Prompt(pm_All)
		End If
		
		strMSGKBN = CF_Ctr_AnsiLeftB(Pin_strMsgCode, 1) '���b�Z�[�W���
		strMSGNM = CF_Ctr_AnsiMidB(Pin_strMsgCode, 2) '���b�Z�[�W�A�C�e��
		
		' === 20060810 === INSERT S - ACE)Nagasawa
		Beep()
		' === 20060810 === INSERT E -
		
		'���b�Z�[�W�}�X�^����
		intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "0", Mst_Inf)
		If intRet <> 0 Then
			intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "9", Mst_Inf)
			If intRet <> 0 Then
				Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, Pin_strPgNm)
				Exit Function
			End If
		End If
		
		'�ǉ����b�Z�[�W�̕ҏW
		strMsg_add = ""
		If Mst_Inf.MSGSQ = "9" Then
			'�c�a�A�N�Z�X�n�G���[�Ƃ���
			' === 20061026 === UPDATE S - ACE)Nagasawa ���b�Z�[�W�\���̕ύX�i�����ӏ���\�����Ȃ��ꍇ����j
			'        strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText & "�����ӏ�   : " & pin_strMsg
			
			strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText
			
			'�ǉ����b�Z�[�W������ꍇ�A�����ӏ��Ƃ��ĕ\������
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = strMsg_add & "�����ӏ�   : " & pin_strMsg
			End If
			' === 20061026 === UPDATE E -
		Else
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = vbCrLf & pin_strMsg
			End If
		End If
		
		' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
		'���b�Z�[�W�t���OTrue
		GV_bolMsgFlg = True
		'�L�[�o�b�t�@�̃N���A
		Call ClearKeyBuffers(pm_All)
		' === 20060920 === INSERT E
		
		'Windows�ɐ����߂�
		System.Windows.Forms.Application.DoEvents()
		
		' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
		'���b�Z�[�W�o�͏I������܂ł͔�����
		If GV_bolMsgFlg = False Then
			Exit Function
		End If
		' === 20060920 === INSERT E
		
		' === 20140129 === INSERT S - ����)Shikichi
		If AE_CMN.NonRaisedMsg Then
			
			' �C�x���g�e�[�u����������
			Call EVTLOG_OUT(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, "WRTTRN")
			
			' �u�͂��v�{�^���������Ɠ����ɂ���
			AE_CmnMsgLibrary = MsgBoxResult.Yes
			
			GV_bolMsgFlg = False
			Exit Function
		End If
		' === 20140129 === INSERT E - ����)Shikichi
		
		'���b�Z�[�W�\��
		Select Case Mst_Inf.BTNKB
			'OK
			Case gc_strBTNKB_OKOnly
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbOKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'OK/�L�����Z��
			Case gc_strBTNKB_OKCancel
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbOKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'���~/�Ď��s/����
			Case gc_strBTNKB_AbortRetryIgnore
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbAbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.AbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'�͂�/������/�L�����Z��
			Case gc_strBTNKB_YesNoCancel
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbYesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'�͂�/������
			Case gc_strBTNKB_YesNo
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbYesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
				'�Ď��s/�L�����Z��
			Case gc_strBTNKB_RetryCancel
				' === 20061031 === UPDATE S - ACE)Nagasawa
				'            AE_CmnMsgLibrary = MsgBox(Trim(Mst_Inf.MSGCM) & strMsg_add, vbRetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				AE_CmnMsgLibrary = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.RetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				' === 20061031 === UPDATE E -
				
			Case Else
				
		End Select
		' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
		'���b�Z�[�W�t���OFalse
		GV_bolMsgFlg = False
		' === 20060920 === INSERT E
		
	End Function
	' === 20060920 === INSERT S - ACE)Hashiri  MsgBox��DoEvents�Ή�
	
	'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    �A���[��702
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CmnMsgLibrary_2
	'   �T�v�F  �W�����b�Z�[�W�\�������i��ʏ��Ȃ��Łj
	'   �����F  Pin_strPgNm     : �v���O������
	'           Pin_strMsgCode  : ���b�Z�[�W�R�[�h�iDB�����p�j
	'           pin_strMsg      : �ǉ����b�Z�[�W
	'           pin_strHeadMsg  : ���b�Z�[�W�擪�ւ̒ǉ����b�Z�[�W
	'   �ߒl�F  �I���{�^��
	'   ���l�F  �A�v���̎��s���ɏo�͂����W�����b�Z�[�W�B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CmnMsgLibrary_2(ByVal Pin_strPgNm As String, ByVal Pin_strMsgCode As String, Optional ByVal pin_strMsg As String = "", Optional ByVal pin_strHeadMsg As String = "") As Short
		
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		Dim strMSGKBN As String
		Dim strMSGNM As String
		Dim strMsg_add As String
		
		On Error Resume Next
		
		AE_CmnMsgLibrary_2 = False
		
		strMSGKBN = CF_Ctr_AnsiLeftB(Pin_strMsgCode, 1) '���b�Z�[�W���
		strMSGNM = CF_Ctr_AnsiMidB(Pin_strMsgCode, 2) '���b�Z�[�W�A�C�e��
		
		Beep()
		
		'���b�Z�[�W�}�X�^����
		intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "0", Mst_Inf)
		If intRet <> 0 Then
			intRet = DSPMSGCM_SEARCH(strMSGKBN, strMSGNM, "9", Mst_Inf)
			If intRet <> 0 Then
				Call MsgBox("�G���[���������܂����B�V�X�e�����b�Z�[�W�e�[�u�����m�F���Ă��������B", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, Pin_strPgNm)
				Exit Function
			End If
		End If
		
		'�ǉ����b�Z�[�W�̕ҏW
		strMsg_add = ""
		If Mst_Inf.MSGSQ = "9" Then
			'�c�a�A�N�Z�X�n�G���[�Ƃ���
			strMsg_add = vbCrLf & vbCrLf & gv_Str_OraErrText
			
			'�ǉ����b�Z�[�W������ꍇ�A�����ӏ��Ƃ��ĕ\������
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = strMsg_add & "�����ӏ�   : " & pin_strMsg
			End If
		Else
			If Trim(pin_strMsg) <> "" Then
				strMsg_add = vbCrLf & pin_strMsg
			End If
		End If
		
		'���b�Z�[�W�t���OTrue
		GV_bolMsgFlg = True
		
		'Windows�ɐ����߂�
		System.Windows.Forms.Application.DoEvents()
		
		'���b�Z�[�W�o�͏I������܂ł͔�����
		If GV_bolMsgFlg = False Then
			Exit Function
		End If
		
		'���b�Z�[�W�\��
		Select Case Mst_Inf.BTNKB
			'OK
			Case gc_strBTNKB_OKOnly
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKOnly + Mst_Inf.ICNKB, Pin_strPgNm)
				
				'OK/�L�����Z��
			Case gc_strBTNKB_OKCancel
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.OKCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'���~/�Ď��s/����
			Case gc_strBTNKB_AbortRetryIgnore
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.AbortRetryIgnore + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�͂�/������/�L�����Z��
			Case gc_strBTNKB_YesNoCancel
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNoCancel + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�͂�/������
			Case gc_strBTNKB_YesNo
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.YesNo + Mst_Inf.ICNKB + Mst_Inf.BTNON, Pin_strPgNm)
				
				'�Ď��s/�L�����Z��
			Case gc_strBTNKB_RetryCancel
				AE_CmnMsgLibrary_2 = MsgBox(Trim(pin_strHeadMsg) & Trim(Mst_Inf.MSGCM) & strMsg_add, MsgBoxStyle.RetryCancel + Mst_Inf.ICNKB, Pin_strPgNm)
				
			Case Else
				
		End Select
		
		'���b�Z�[�W�t���OFalse
		GV_bolMsgFlg = False
		
	End Function
	'''' ADD 2009/11/26  FKS) T.Yamamoto    End
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Sub ClearKeyBuffers
	'   �T�v�F  �L�[�o�b�t�@�N���A����
	'   �����F  pm_All  �@�@�@  : ��ʏ��
	'   �ߒl�F  �Ȃ�
	'   ���l�F  API�ɂ��L�[�o�b�t�@�̃N���A
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub ClearKeyBuffers(ByRef pm_All As Cls_All)
		Dim tMsg As Msg
		Dim lngRet As Integer
		
		Do 
			lngRet = PeekMessage(tMsg, pm_All.Dsp_Base.FormCtl.Handle.ToInt32, WM_KEYFIRST, WM_KEYLAST, PM_REMOVE)
		Loop Until lngRet = 0
	End Sub
	' === 20060920 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_GetSMEDT
	'   �T�v�F  �����v�Z����
	'   �����F  Pin_strDate     : �v�Z�Ώۓ��t(�W���̐��lOr���t�j
	'           Pin_strTOKSMEKB : ���敪
	'           Pin_strTOKSMEDD : ���������t�i����j
	'           Pin_strTOKSMECC : ���T�C�N���i����j
	'           Pin_strTOKSDWKB : ���ߗj��
	'           Pin_intCHTNKB   : ���[�敪(�v�Z�Ώۓ����牽��ڂ̒��������w��)
	'           Pot_strSMEDT    : �v�Z���ʒ���
	'   �ߒl�F  0�F����@9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_GetSMEDT(ByVal pin_strDate As String, ByVal Pin_strTOKSMEKB As String, ByVal Pin_strTOKSMEDD As String, ByVal Pin_strTOKSMECC As String, ByVal Pin_strTOKSDWKB As String, ByVal Pin_intCHTNKB As Short, ByRef Pot_strSMEDT As String) As Short
		
		Dim strDate As String
		Dim yy As Short
		Dim mm As Short
		Dim dd As Short
		Dim Cnt As Short
		Dim I As Short
		Dim setidx As Short
		Dim idx As Short
		Dim addMM As Short
		Dim smeday(15) As Short
		Dim intTOKSMECC As Short
		Dim intTOKSMEDD As Short
		Dim intTOKSDWKB As Short
		
		AE_GetSMEDT = 9
		Pot_strSMEDT = ""
		
		'���t�`�F�b�N
		If IsDate(pin_strDate) = True Then
			strDate = VB6.Format(pin_strDate, "yyyy/mm/dd")
		Else
			If IsDate(VB6.Format(pin_strDate, "@@@@/@@/@@")) = True Then
				strDate = VB6.Format(pin_strDate, "@@@@/@@/@@")
			Else
				Exit Function
			End If
		End If
		
		yy = Year(CDate(strDate))
		mm = Month(CDate(strDate))
		dd = VB.Day(CDate(strDate))
		
		If Pin_strTOKSMEKB = gc_strSMEKB_DAY Then
			'���������t�擾
			If IsNumeric(Pin_strTOKSMEDD) = True Then
				intTOKSMEDD = CShort(Pin_strTOKSMEDD)
			Else
				Exit Function
			End If
			
			'���T�C�N���擾
			If IsNumeric(Pin_strTOKSMECC) = True Then
				intTOKSMECC = CShort(Pin_strTOKSMECC)
			Else
				Exit Function
			End If
			
			'���敪��"��"�̏ꍇ
			If intTOKSMECC = 1 Then '��������
				Pot_strSMEDT = CStr(DateSerial(yy, mm, dd + Pin_intCHTNKB))
				Exit Function
			End If
			'
			If intTOKSMECC <= 0 Or intTOKSMECC > 15 Then intTOKSMECC = 30
			Cnt = Int(30 / intTOKSMECC) '���񐔁^��
			setidx = False
			For I = 0 To Cnt - 1
				smeday(I) = intTOKSMEDD + intTOKSMECC * I
				If smeday(I) > 27 Then smeday(I) = 99
				If dd <= smeday(I) And setidx = False Then
					idx = I + Pin_intCHTNKB '�Y�����t�̒����z��Y��
					setidx = True
				End If
			Next I
			If setidx = False Then idx = Cnt + Pin_intCHTNKB
			addMM = Int(idx / Cnt)
			idx = idx Mod Cnt
			If idx < 0 Then idx = idx + Cnt
			'
			If smeday(idx) = 99 Then
				Pot_strSMEDT = CStr(DateSerial(yy, mm + addMM + 1, 0))
			Else
				Pot_strSMEDT = CStr(DateSerial(yy, mm + addMM, smeday(idx)))
			End If
			
		Else
			'���j���擾
			If IsNumeric(Pin_strTOKSDWKB) = True Then
				intTOKSDWKB = CShort(Pin_strTOKSDWKB)
			Else
				Exit Function
			End If
			
			'�����敪��"�j��"�̏ꍇ
			If WeekDay(CDate(strDate)) > intTOKSDWKB Then
				Pot_strSMEDT = CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)), VB.Day(CDate(strDate)) + (7 - WeekDay(CDate(strDate)) + intTOKSDWKB) + (7 * Pin_intCHTNKB)))
			Else
				Pot_strSMEDT = CStr(DateSerial(Year(CDate(strDate)), Month(CDate(strDate)), VB.Day(CDate(strDate)) + (intTOKSDWKB - WeekDay(CDate(strDate))) + (7 * Pin_intCHTNKB)))
			End If
		End If
		
		Pot_strSMEDT = VB6.Format(Pot_strSMEDT, "yyyymmdd")
		
		AE_GetSMEDT = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_GetUDNYTDT
	'   �T�v�F  ����\����v�Z����
	'   �����F  Pin_strDEFNOKDT : �[��(�W���̐��lOr���t�j
	'           Pin_strODNYTDT  : �o�ח\���
	'           Pin_strUDNYTDT  : ����\����i��ʓ��͍���)
	'           Pin_strTOKSMEKB : ���敪
	'           Pin_strTOKSMEDD : ���������t�i����j
	'           Pin_strTOKSMECC : ���T�C�N���i����j
	'           Pin_strTOKSDWKB : ���ߗj��
	'           Pin_strURIKJN   : ����
	'           Pot_strUDNYTDT  : �v�Z���ʔ���\���(yyyymmdd�̌`���j
	'   �ߒl�F  0�F����@9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_GetUDNYTDT(ByVal Pin_strDEFNOKDT As String, ByVal pin_strODNYTDT As String, ByVal Pin_strUDNYTDT As String, ByVal Pin_strTOKSMEKB As String, ByVal Pin_strTOKSMEDD As String, ByVal Pin_strTOKSMECC As String, ByVal Pin_strTOKSDWKB As String, ByVal pin_strURIKJN As String, ByRef Pot_strUDNYTDT As String) As Short
		
		Dim strDate As String
		Dim strDate2 As String
		Dim intRet As Short
		Dim strSMEDT As String
		
		AE_GetUDNYTDT = 9
		Pot_strUDNYTDT = ""
		
		Select Case pin_strURIKJN
			'�o�׊
			Case gc_strURIKJN_SYK
				'���t�`�F�b�N
				If IsDate(pin_strODNYTDT) = True Then
					strDate = VB6.Format(pin_strODNYTDT, "yyyymmdd")
				Else
					If IsDate(VB6.Format(pin_strODNYTDT, "@@@@/@@/@@")) = True Then
						strDate = pin_strODNYTDT
					Else
						Exit Function
					End If
				End If
				
				'�c�Ɠ��擾
				intRet = DSPCLDDT_SEARCH_KDKB(strDate, "1", "1", Pot_strUDNYTDT)
				If intRet <> 0 Then
					Exit Function
				End If
				
				'������A�H�������
			Case gc_strURIKJN_KNS, gc_strURIKJN_KOJ
				'���t�`�F�b�N
				
				' === 20060726 === INSERT S - ACE)Nagasawa
				If Trim(Pin_strUDNYTDT) <> "" Then
					' === 20060726 === INSERT E -
					If IsDate(Pin_strUDNYTDT) = True Then
						strDate = VB6.Format(Pin_strUDNYTDT, "yyyymmdd")
					Else
						If IsDate(VB6.Format(Pin_strUDNYTDT, "@@@@/@@/@@")) = True Then
							strDate = Pin_strUDNYTDT
						Else
							Exit Function
						End If
					End If
					' === 20060726 === INSERT S - ACE)Nagasawa
				Else
					If IsDate(pin_strODNYTDT) = True Then
						strDate = VB6.Format(pin_strODNYTDT, "yyyymmdd")
					Else
						If IsDate(VB6.Format(pin_strODNYTDT, "@@@@/@@/@@")) = True Then
							strDate = pin_strODNYTDT
						Else
							Exit Function
						End If
					End If
				End If
				' === 20060726 === INSERT E -
				
				Pot_strUDNYTDT = strDate
				
				'�𖱊����
			Case gc_strURIKJN_EKM
				' === 20060830 === UPDATE S - ACE)Nagasawa
				'            '���t�`�F�b�N
				'            If IsDate(Pin_strDEFNOKDT) = True Then
				'                strDate = Format(Pin_strDEFNOKDT, "yyyymmdd")
				'            Else
				'                If IsDate(Format(Pin_strDEFNOKDT, "@@@@/@@/@@")) = True Then
				'                    strDate = Pin_strDEFNOKDT
				'                Else
				'                    Exit Function
				'                End If
				'            End If
				'
				'            '����\������v�Z
				'            intRet = AE_GetSMEDT(strDate, _
				''                                 Pin_strTOKSMEKB, _
				''                                 Pin_strTOKSMEDD, _
				''                                 Pin_strTOKSMECC, _
				''                                 Pin_strTOKSDWKB, _
				''                                 1, _
				''                                 strDate2)
				
				'���t�`�F�b�N
				If IsDate(pin_strODNYTDT) = True Then
					strDate2 = VB6.Format(pin_strODNYTDT, "yyyymmdd")
				Else
					If IsDate(VB6.Format(pin_strODNYTDT, "@@@@/@@/@@")) = True Then
						strDate2 = pin_strODNYTDT
					Else
						Exit Function
					End If
				End If
				' === 20060830 === UPDATE E -
				
				If intRet = 9 Then
					Exit Function
				End If
				
				'�c�Ɠ��擾
				intRet = DSPCLDDT_SEARCH_KDKB(strDate2, "1", "2", Pot_strUDNYTDT)
				If intRet <> 0 Then
					Exit Function
				End If
				
		End Select
		
		
		AE_GetUDNYTDT = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_GetKRSMADT
	'   �T�v�F  �o�������v�Z����
	'   �����F  Pin_strKJNDT    : ���
	'           Pot_strSMADT  �@: �v�Z���ʌo������(yyyymmdd�̌`���j
	'   �ߒl�F  0�F����@9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_GetKRSMADT(ByVal pin_strKJNDT As String, ByRef Pot_strSMADT As String) As Short
		
		Dim strSMEDT As String
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Mst_Inf_SYSTBA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Mst_Inf_SYSTBA As TYPE_DB_SYSTBA
		Dim intRet As Short
		
		AE_GetKRSMADT = 9
		Pot_strSMADT = ""
		
		Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
		
		'���[�U�[���Ǘ��e�[�u������
		If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
			Exit Function
		End If
		
		'�o�������v�Z
		intRet = AE_GetSMEDT(pin_strKJNDT, gc_strSMEKB_DAY, Mst_Inf_SYSTBA.SMEDD, "99", "", 0, strSMEDT)
		If intRet <> 0 Then
			Exit Function
		End If
		
		Pot_strSMADT = strSMEDT
		
		AE_GetKRSMADT = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Execute_PLSQL_GetTanka
	'   �T�v�F  PL/SQL���s����(�P���擾����)
	'   �����F�@Pin_strHINCD  : ���i�R�[�h
	'           Pin_strTOKCD  : ���Ӑ�R�[�h
	'           Pin_strDATE   : �K�p��
	'           Pin_strTUKKB  : �ʉ݋敪
	'           Pin_lngSU     : ����
	'           Pot_curTanka  : �擾�P��
	'           Pot_curSIKRT  : �擾�d�ؗ�
	'           Pin_strJDNKB  : �󒍋敪�i"1"�C�O�@����ȊO�͋󔒁j
	'           Pot_curTEITK  : �艿
	'   �ߒl�F�@0 : ���� 9: �ُ�
	'   ���l�F  �P���擾�pPL/SQL(PRC_CMNPL90_01)�����s����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_GetTanka(ByVal pin_strHINCD As String, ByVal pin_strTOKCD As String, ByVal pin_strDate As String, ByVal pin_strTUKKB As String, ByVal Pin_lngSU As Integer, ByRef Pot_curTANKA As Decimal, ByRef Pot_curSIKRT As Decimal, Optional ByRef Pin_strJDNKB As String = "", Optional ByRef Pot_curTEITK As Decimal = 0) As Short
		
		Dim strSQL As String 'SQL��
		Dim strPara1 As String '���Ұ�1(���i�R�[�h)
		Dim strPara2 As String '���Ұ�2(���Ӑ�R�[�h)
		Dim strPara3 As String '���Ұ�3(�K�p��)
		Dim strPara4 As String '���Ұ�4(�ʉ݋敪)
		Dim lngPara5 As Integer '���Ұ�5(����)
		Dim strPara6 As String '���Ұ�6(�󒍋敪)
		Dim lngPara7 As Integer '���Ұ�7(���A����)
		Dim lngPara8 As Integer '���Ұ�8(�װ����)
		Dim strPara9 As String '���Ұ�9(�װ���e)
		' === 20060920 === UPDATE S - ACE)Nagasawa
		'    Dim lngPara10   As Long             '���Ұ�10(�̔��P��)
		Dim lngPara10 As Decimal '���Ұ�10(�̔��P��)
		' === 20060920 === UPDATE E -
		Dim lngPara11 As Integer '���Ұ�11(�d�ؗ�)
		Dim lngPara12 As Integer '���Ұ�12(�艿)
		'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim param(13) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
		Dim bolRet As Boolean
		
		AE_Execute_PLSQL_GetTanka = 9
		
		'��n���ϐ������ݒ�
		strPara1 = pin_strHINCD
		strPara2 = pin_strTOKCD
		strPara3 = pin_strDate
		strPara4 = pin_strTUKKB
		lngPara5 = Pin_lngSU
		strPara6 = Pin_strJDNKB
		lngPara7 = 0
		lngPara8 = 0
		strPara9 = ""
		lngPara10 = 0
		lngPara11 = 0
		lngPara12 = 0
		
		'�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P5", lngPara5, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P6", strPara6, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P7", lngPara7, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P8", lngPara8, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P9", strPara9, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P10", lngPara10, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P11", lngPara11, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P12", lngPara12, ORAPARM_OUTPUT)
		
		'�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7) = gv_Odb_USR1.Parameters("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8) = gv_Odb_USR1.Parameters("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9) = gv_Odb_USR1.Parameters("P9")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(10) = gv_Odb_USR1.Parameters("P10")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(11) = gv_Odb_USR1.Parameters("P11")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(12) = gv_Odb_USR1.Parameters("P12")
		
		'�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(10).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(11).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(12).serverType = ORATYPE_NUMBER
		
		'PL/SQL�Ăяo��SQL
		strSQL = "BEGIN PRC_CMNPL90_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12); End;"
		
		'DB�A�N�Z�X
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_Execute_PLSQL_GetTanka_END
		End If
		
		'** �߂�l�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara7 = param(7).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara8 = param(8).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(param(9).Value) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strPara9 = param(9).Value
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(param(10).Value) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			lngPara10 = param(10).Value
		Else
			lngPara10 = 0
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(param(11).Value) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			lngPara11 = param(11).Value
		Else
			lngPara11 = 0
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(param(12).Value) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			lngPara12 = param(12).Value
		Else
			lngPara12 = 0
		End If
		
		Pot_curTANKA = CDec(lngPara10)
		Pot_curSIKRT = CDec(lngPara11)
		Pot_curTEITK = CDec(lngPara12)
		
		'�G���[���ݒ�
		gv_Int_OraErr = lngPara8
		gv_Str_OraErrText = strPara9 & vbCrLf
		
		AE_Execute_PLSQL_GetTanka = lngPara7
		
AE_Execute_PLSQL_GetTanka_END: 
		'** �p�����^����
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P9")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P10")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P11")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P12")
		
		
	End Function
	
	' === 20060829 === DELETE S - ACE)Nagasawa �g�p����Ă��Ȃ����ߍ폜
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   ���́F  Function AE_Get_TANKA
	''   �T�v�F  �P���A�d�ؗ��擾����
	''   �����F�@Pin_strHINCD       :���i�R�[�h
	''           Pin_strTOKCD       :���Ӑ�R�[�h
	''           Pin_strDATE        :���
	''           Pot_curSIKRT       :�d�ؗ�
	''           Pot_curTANKA       :�擾�P��
	''   �ߒl�F  0 : ����@9 : �ُ�
	''   ���l�F
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Static Function AE_Get_TANKA(ByVal pin_strHINCD As String, _
	''                                    ByVal pin_strTOKCD As String, _
	''                                    ByVal pin_strDate As String, _
	''                                    ByRef Pot_curSIKRT As Currency, _
	''                                    ByRef Pot_curTANKA As Currency) As Integer
	'
	'    Dim Mst_Inf_HINMTA      As TYPE_DB_HINMTA       '���i�}�X�^��������
	''    Dim Mst_Inf_RNKMTA      As TYPE_DB_RNKMTA       '�����N�ʎd�؂藦�}�X�^��������
	'    Dim Mst_Inf_TOKMTA      As TYPE_DB_TOKMTA       '���Ӑ�}�X�^��������
	''    Dim Mst_Inf_TRKMTA      As type_db_trkmta       '���Ӑ�ʏ��i�����N�}�X�^��������
	'
	'    AE_Get_TANKA = 9
	'
	'    Pot_curSIKRT = 100
	'    Pot_curTANKA = 0
	'
	'    '���i�}�X�^����
	'    If DSPHINCD_SEARCH(pin_strHINCD, Mst_Inf_HINMTA) <> 0 Then
	'        GoTo AE_Get_TANKA_ERR
	'    End If
	'
	'    If Mst_Inf_HINMTA.DATKB <> gc_strDATKB_USE Then
	'        GoTo AE_Get_TANKA_ERR
	'    End If
	'
	''**********************����������
	'    Pot_curSIKRT = 90
	'    Pot_curTANKA = Mst_Inf_HINMTA.ZNKURITK
	''**********************����������
	''    '���Ӑ�}�X�^����
	''    If DSPTOKCD_SEARCH(Pin_strTOKCD, Mst_Inf_TOKMTA) <> 0 Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    If Mst_Inf_TOKMTA.DATKB <> gc_strDATKB_USE Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    '���Ӑ�ʏ��i�����N�}�X�^����
	''    If DSPTRKRNK_SEARCH(Pin_strTOKCD, Mst_Inf_HINMTA.HINGRP, Pin_strDATE, Mst_Inf_TRKMTA) <> 0 Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    If Mst_Inf_TOKMTA.DATKB <> gc_strDATKB_USE Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    '�d�ؗ��擾
	''    If DSPRNKM_SEARCH(Mst_Inf_HINMTA.HINGRP, "", Pin_strDATE, Mst_Inf_RNKMTA) <> 0 Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    If Mst_Inf_RNKMTA.DATKB <> gc_strDATKB_USE Then
	''        GoTo AE_Get_TANKA_ERR
	''    End If
	''
	''    '�d�ؗ��擾
	''    Pot_curSIKRT = Mst_Inf_RNKMTA.SIKRT
	''
	''    '�P���擾
	''    Pot_curTANKA = AE_Calc_TANKA(Pot_curSIKRT, _
	'''                                 Mst_Inf_HINMTA.TEIKATK, _
	'''                                 Mst_Inf_TOKMTA.TKNRPSKB, _
	'''                                 Mst_Inf_TOKMTA.TKNZRNKB)
	'
	'    AE_Get_TANKA = 0
	'
	'    Exit Function
	'
	'AE_Get_TANKA_ERR:
	'
	'End Function
	' === 20060829 === DELETE E -
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Get_SysDt
	'//*
	'//* <�߂�l>     �^          ����
	'//*              Boolean     True:���� / False:�ُ�
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*
	'//* <��  ��>
	'//*    DB�T�[�o�[�̓��t(����)���擾����B
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20041016|ACE)Moriga     |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Get_SysDt() As Boolean
		
		On Error GoTo ERR_HANDLE
		
		Dim Str_Sql As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim Str_Val As String
		Dim Lng_Cnt As Integer
		Dim Lng_Idx As Integer
		Dim Str_SysDt As String
		
		CF_Get_SysDt = False
		
		'// ������
		GV_SysDate = ""
		GV_SysTime = ""
		Str_SysDt = ""
		
		Str_Sql = ""
		Str_Sql = Str_Sql & "SELECT"
		Str_Sql = Str_Sql & "       To_Char(sysdate,'YYYYMMDDHH24MISS') AAA "
		Str_Sql = Str_Sql & "FROM"
		Str_Sql = Str_Sql & "       Dual "
		
		If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
			GoTo ERR_HANDLE
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Str_SysDt = Trim(CF_Ora_GetDyn(Usr_Ody, "AAA"))
		
		GV_SysDate = Mid(Str_SysDt, 1, 8)
		GV_SysTime = Mid(Str_SysDt, 9, 6)
		
		CF_Get_SysDt = True
		
EXIT_HANDLE: 
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	
	'//***************************************************************************************
	'//*
	'//* <��  ��>
	'//*    CF_Get_UnyDt
	'//*
	'//* <�߂�l>     �^          ����
	'//*              Boolean     True:���� / False:�ُ�
	'//*
	'//* <��  ��>     ���ږ�             �^              I/O           ���e
	'//*
	'//* <��  ��>
	'//*    �^�p���t(����)���擾����B
	'//**************************************************************************************
	'//*�ύX����
	'//* �ް�ޮ�  |  ���t  | �X�V��        |���e
	'//* ---------|--------|---------------|------------------------------------------------*
	'//* 1.00     |20060706|ACE)Nagasawa   |�V�K�쐬
	'//**************************************************************************************
	Public Function CF_Get_UnyDt() As Boolean
		
		Dim intRet As Short
		Dim Mst_Inf As TYPE_DB_UNYMTA
		
		CF_Get_UnyDt = False
		
		'������
		GV_UNYDate = ""
		
		'�T�[�o�[�̃V�X�e�����t�擾
		Call CF_Get_SysDt()
		
		'�^�p���t���擾
		intRet = DSPUNYDT_SEARCH(Mst_Inf)
		If intRet = 0 Then
			GV_UNYDate = Mst_Inf.UNYDT
		Else
			GV_UNYDate = GV_SysDate
		End If
		
		CF_Get_UnyDt = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Execute_PLSQL_PRC_UODFP53
	'   �T�v�F  PL/SQL���s����(������������)
	'   �����F�@Pin_strPRCCASE  : �����P�[�X�i"1":�o�^ "2":���� "3": �폜�j
	'           Pin_strJDNNO    : �󒍔ԍ�
	'           Pin_strLINNO    : �s�ԍ�
	'           Pin_strSBNNO    : ����
	'           Pin_strHINCD    : ���i�R�[�h
	'           Pin_lngBFRSU    : �ύX�O�󒍐��ʁi�o�^�̏ꍇ�̓[���j
	'           Pin_lngAFTSU    : �ύX��󒍐��ʁi�폜�̏ꍇ�̓[���j
	'           Pin_strZAIRNK   : �݌Ƀ����N
	'           Pin_lngBFRSU    : �ύX�O�o�ח\����i�o�^�A�폜�̏ꍇ�͐ݒ�Ȃ��j
	'           Pin_lngAFTSU    : �ύX��o�ח\����i�o�^�A�폜�̏ꍇ�͐ݒ�Ȃ��j
	'   �ߒl�F�@0 : ����  1 : �x��  9 : �ُ�
	'   ���l�F  ������������PL/SQL(PRC_UODFP53_01)�����s����
	'           �������A�ύX�O�󒍐��ʁ��ύX��󒍐��ʂ̏ꍇ�͎��s���Ȃ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061102 === UPDATE S - ACE)Nagasawa �������������̌Ăяo�������̒ǉ�
	'Public Function AE_Execute_PLSQL_PRC_UODFP53(ByVal Pin_strPRCCASE As String _
	''                                           , ByVal pin_strJDNNO As String _
	''                                           , ByVal pin_strLINNO As String _
	''                                           , ByVal pin_strSBNNO As String _
	''                                           , ByVal pin_strHINCD As String _
	''                                           , ByVal Pin_lngBFRSU As Currency _
	''                                           , ByVal Pin_lngAFTSU As Currency _
	''                                           , Optional ByVal Pin_strBFRSYK As String = "" _
	''                                           , Optional ByVal Pin_strAFTSYK As String = "") As Integer
	Public Function AE_Execute_PLSQL_PRC_UODFP53(ByVal Pin_strPRCCASE As String, ByVal pin_strJDNNO As String, ByVal pin_strLINNO As String, ByVal pin_strSBNNO As String, ByVal pin_strHINCD As String, ByVal Pin_lngBFRSU As Decimal, ByVal Pin_lngAFTSU As Decimal, ByVal Pin_strZAIRNK As String, Optional ByVal Pin_strBFRSYK As String = "", Optional ByVal Pin_strAFTSYK As String = "") As Short
		' === 20061102 === UPDATE E -
		
		Dim strSQL As String 'SQL��
		Dim strPara1 As String '���Ұ�1(�S���҃R�[�h)
		Dim strPara2 As String '���Ұ�2(�N���C�A���gID)
		Dim strPara3 As String '���Ұ�3(�����P�[�X)
		Dim strPara4 As String '���Ұ�4(�󒍔ԍ�)
		Dim strPara5 As String '���Ұ�5(�s�ԍ�)
		Dim strPara6 As String '���Ұ�6(����)
		Dim strPara7 As String '���Ұ�7(���i�R�[�h)
		Dim lngPara8 As Integer '���Ұ�8(�ύX�O�󒍐���)
		Dim lngPara9 As Integer '���Ұ�9(�ύX��󒍐���)
		Dim lngPara10 As Integer '���Ұ�10(���A����)
		Dim lngPara11 As Integer '���Ұ�11(�װ����)
		Dim strPara12 As New VB6.FixedLengthString(1000) '���Ұ�12(�װ���e)
		Dim lngPara13 As Integer '���Ұ�13(�Ǎ�����)
		Dim lngPara14 As Integer '���Ұ�14(�o�^����)
		'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim param(15) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
		Dim bolRet As Boolean
		' === 20061102 === INSERT S - ACE)Nagasawa �������������̌Ăяo�������̒ǉ�
		Dim Mst_Inf As TYPE_DB_MEIMTA
		Dim bolExit As Boolean
		' === 20061102 === INSERT E -
		
		AE_Execute_PLSQL_PRC_UODFP53 = 9
		
		'''' DEL 2009/09/16  FKS) T.Yamamoto    Start    �A���[��385
		'�󒍐��ʁA�o�ח\����ɕύX���Ȃ��Ă����������������Ăяo��
		'' === 20060824 === UPDATE S - ACE)Nagasawa �[���ύX�������������������Ăяo��
		''    '�ύX�O�󒍐��ʁ��ύX��󒍐��ʂ̏ꍇ�͏����I��
		''    If Pin_lngBFRSU = Pin_lngAFTSU Then
		''        AE_Execute_PLSQL_PRC_UODFP53 = 0
		''        Exit Function
		''    End If
		'
		'    '�ύX�O�󒍐��ʁ��ύX��󒍐��ʁA�ύX�O�o�ח\������ύX��o�ח\����̏ꍇ�͏����I��
		'    If Pin_lngBFRSU = Pin_lngAFTSU _
		''    And Pin_strBFRSYK = Pin_strAFTSYK Then
		'        AE_Execute_PLSQL_PRC_UODFP53 = 0
		'        Exit Function
		'    End If
		'' === 20060824 === UPDATE E -
		'''' DEL 2009/09/16  FKS) T.Yamamoto    End
		
		' === 20061102 === INSERT S - ACE)Nagasawa �������������̌Ăяo�������̒ǉ�
		bolExit = True
		Call DB_MEIMTA_Clear(Mst_Inf)
		If DSPMEIM_SEARCH(gc_strKEYCD_ZAIRNK, Pin_strZAIRNK, Mst_Inf) = 0 Then
			If Mst_Inf.DATKB = gc_strDATKB_USE Then
				If Mst_Inf.MEIKBA = gc_strJDNSEISAN_OK Then
					bolExit = False
				End If
			End If
		End If
		
		'�󒍐��Y�Ώەi�ȊO�͏������s��Ȃ�
		If bolExit = True Then
			AE_Execute_PLSQL_PRC_UODFP53 = 0
			Exit Function
		End If
		' === 20061102 === INSERT E -
		
		'��n���ϐ������ݒ�
		strPara1 = SSS_OPEID.Value
		strPara2 = SSS_CLTID.Value
		strPara3 = Pin_strPRCCASE
		strPara4 = pin_strJDNNO
		strPara5 = pin_strLINNO
		strPara6 = pin_strSBNNO
		strPara7 = pin_strHINCD
		lngPara8 = Pin_lngBFRSU
		lngPara9 = Pin_lngAFTSU
		lngPara10 = 0
		lngPara11 = 0
		strPara12.Value = ""
		lngPara13 = 0
		lngPara14 = 0
		
		'�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P5", strPara5, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P6", strPara6, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P7", strPara7, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P8", lngPara8, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P9", lngPara9, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P10", lngPara10, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P11", lngPara11, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P12", strPara12.Value, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P13", lngPara13, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P14", lngPara14, ORAPARM_OUTPUT)
		
		'�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7) = gv_Odb_USR1.Parameters("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8) = gv_Odb_USR1.Parameters("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9) = gv_Odb_USR1.Parameters("P9")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(10) = gv_Odb_USR1.Parameters("P10")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(11) = gv_Odb_USR1.Parameters("P11")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(12) = gv_Odb_USR1.Parameters("P12")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(13) = gv_Odb_USR1.Parameters("P13")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(14) = gv_Odb_USR1.Parameters("P14")
		
		'�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(10).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(11).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(12).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(13).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(14).serverType = ORATYPE_NUMBER
		
		'PL/SQL�Ăяo��SQL
		strSQL = "BEGIN PRC_UODFP53_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11,:P12,:P13,:P14); End;"
		
		'DB�A�N�Z�X
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_Execute_PLSQL_PRC_UODFP53_END
		End If
		
		'** �߂�l�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara10 = param(10).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara11 = param(11).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(param(12).Value) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strPara12.Value = param(12).Value
		End If
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara13 = param(13).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara14 = param(14).Value
		
		'�G���[���ݒ�
		gv_Int_OraErr = lngPara11
		gv_Str_OraErrText = Trim(strPara12.Value) & vbCrLf
		
		AE_Execute_PLSQL_PRC_UODFP53 = lngPara10
		
AE_Execute_PLSQL_PRC_UODFP53_END: 
		'** �p�����^����
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P9")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P10")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P11")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P12")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P13")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P14")
		
	End Function
	
	' === 20060828 === INSERT S - ACE)Sejima
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_TKCHGKB
	'   �T�v�F  �������擾
	'   �����F�@pin_DB_TANMTA  : �S���҃}�X�^���
	'           pin_strUnyDate : �^�p���t
	'   �ߒl�F�@�����O���[�v
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_KNG_Inf(ByRef pin_DB_TANMTA As TYPE_DB_TANMTA, ByVal pin_strUnyDate As String, ByRef Inp_Inf As Cmn_Inp_Inf) As Short
		
		Dim Mst_Inf_KNGMTA As TYPE_DB_KNGMTA
		Dim strKNGGRCD As String
		
		'������
		With Inp_Inf
			'��������A�����Ȃ��Ƃ���
			.InpTKCHGKB = gc_strTKCHGKB_NG
			.InpJDNUPDKB = gc_strJDNUPDKB_NG
		End With
		
		'�����O���[�v�擾
		strKNGGRCD = F_Get_KNGGRCD(pin_DB_TANMTA, pin_strUnyDate)
		
		If Trim(strKNGGRCD) <> "" Then
			'�����O���[�v���擾�ł����ꍇ�A�����}�X�^������
			Call DB_KNGMTA_Clear(Mst_Inf_KNGMTA)
			If KNGMTA_SEARCH(strKNGGRCD, Mst_Inf_KNGMTA) = 0 Then
				With Inp_Inf
					'�P���ύX����
					.InpTKCHGKB = Mst_Inf_KNGMTA.SALTKKB
					'�󒍍X�V����
					.InpJDNUPDKB = Mst_Inf_KNGMTA.JDNUPDKB
				End With
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_KNGGRCD
	'   �T�v�F  �����O���[�v�擾
	'   �����F�@pin_DB_TANMTA  : �S���҃}�X�^���
	'           pin_strDate    : �^�p���t
	'   �ߒl�F�@�����O���[�v
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_KNGGRCD(ByRef pin_DB_TANMTA As TYPE_DB_TANMTA, ByRef pin_strDate As String) As String
		
		Dim bolTANTKDT As Boolean '�K�p������t���O�iTrue�F�K�p�������^�p���j
		Dim intWk As Short
		Dim Ret_Value As String
		
		'������
		bolTANTKDT = False
		Ret_Value = ""
		intWk = 0
		
		With pin_DB_TANMTA
			
			'�����O���[�v�ݒ肠��
			If Trim(.KNGGRCD) <> "" Then
				intWk = intWk + mc_intCD
			End If
			
			'�������O���[�v�ݒ肠��
			If Trim(.OLDGRCD) <> "" Then
				intWk = intWk + mc_intOLDCD
			End If
			
			'�K�p���ݒ肠��
			If Trim(.TANTKDT) <> "" Then
				intWk = intWk + mc_intTKDT
				'�K�p������
				If Trim(.TANTKDT) <= pin_strDate Then
					bolTANTKDT = True
				End If
			End If
			
			'�����O���[�v�A�������O���[�v�A�K�p���̐ݒ�L���ɉ����Ĕ�����s���B
			'�i2^3��8����݁j
			Select Case intWk
				Case mc_intCD + mc_intOLDCD + mc_intTKDT
					'�@�����O���[�v�A�������O���[�v�A�K�p���̐ݒ肠��
					If bolTANTKDT = True Then
						Ret_Value = Trim(.KNGGRCD)
					Else
						Ret_Value = Trim(.OLDGRCD)
					End If
					
				Case mc_intCD + mc_intOLDCD
					'�A�����O���[�v�A�������O���[�v�̐ݒ肠��
					Ret_Value = Trim(.KNGGRCD)
					
				Case mc_intCD + mc_intTKDT
					'�B�����O���[�v�A�K�p���̐ݒ肠��
					If bolTANTKDT = True Then
						Ret_Value = Trim(.KNGGRCD)
					Else
						Ret_Value = Trim(.OLDGRCD)
					End If
					
				Case mc_intOLDCD + mc_intTKDT
					'�C�������O���[�v�A�K�p���̐ݒ肠��
					If bolTANTKDT = True Then
						Ret_Value = Trim(.KNGGRCD)
					Else
						Ret_Value = Trim(.OLDGRCD)
					End If
					
				Case mc_intCD
					'�D�����O���[�v�̐ݒ肠��
					Ret_Value = Trim(.KNGGRCD)
					
				Case mc_intOLDCD
					'�E�������O���[�v�̐ݒ肠��
					
				Case mc_intTKDT
					'�F�K�p���̐ݒ肠��
					
				Case Else
					'�G��������ݒ�Ȃ�
					
			End Select
			
		End With
		
		F_Get_KNGGRCD = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_TANBMNCD
	'   �T�v�F  ��������R�[�h�擾
	'   �����F�@pin_DB_TANMTA  : �S���҃}�X�^���
	'           pin_strDate : �^�p���t
	'   �ߒl�F�@��������R�[�h
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_TANBMNCD(ByRef pin_DB_TANMTA As TYPE_DB_TANMTA, ByRef pin_strDate As String) As String
		
		Dim bolTANTKDT As Boolean '�K�p������t���O�iTrue�F�K�p����������j
		Dim intWk As Short
		Dim Ret_Value As String
		
		'������
		bolTANTKDT = False
		Ret_Value = ""
		intWk = 0
		
		With pin_DB_TANMTA
			'��������R�[�h�ݒ肠��
			If Trim(.TANBMNCD) <> "" Then
				intWk = intWk + mc_intCD
			End If
			'����������R�[�h�ݒ肠��
			If Trim(.OLDBMNCD) <> "" Then
				intWk = intWk + mc_intOLDCD
			End If
			
			'�K�p���ݒ肠��
			If Trim(.TANTKDT) <> "" Then
				intWk = intWk + mc_intTKDT
				'�K�p������
				If Trim(.TANTKDT) <= pin_strDate Then
					bolTANTKDT = True
				End If
			End If
			
			'��������R�[�h�A����������R�[�h�A�K�p���̐ݒ�L���ɉ����Ĕ�����s���B
			'�i2^3��8����݁j
			Select Case intWk
				Case mc_intCD + mc_intOLDCD + mc_intTKDT
					'�@��������R�[�h�A����������R�[�h�A�K�p���̐ݒ肠��
					If bolTANTKDT = True Then
						Ret_Value = Trim(.TANBMNCD)
					Else
						Ret_Value = Trim(.OLDBMNCD)
					End If
					
				Case mc_intCD + mc_intOLDCD
					'�A��������R�[�h�A����������R�[�h�̐ݒ肠��
					Ret_Value = Trim(.TANBMNCD)
					
				Case mc_intCD + mc_intTKDT
					'�B��������R�[�h�A�K�p���̐ݒ肠��
					If bolTANTKDT = True Then
						Ret_Value = Trim(.TANBMNCD)
					Else
						Ret_Value = Trim(.OLDBMNCD)
					End If
					
				Case mc_intOLDCD + mc_intTKDT
					'�C����������R�[�h�A�K�p���̐ݒ肠��
					If bolTANTKDT = True Then
						Ret_Value = Trim(.TANBMNCD)
					Else
						Ret_Value = Trim(.OLDBMNCD)
					End If
					
				Case mc_intCD
					'�D��������R�[�h�̐ݒ肠��
					Ret_Value = Trim(.TANBMNCD)
					
				Case mc_intOLDCD
					'�E����������R�[�h�̐ݒ肠��
					
				Case mc_intTKDT
					'�F�K�p���̐ݒ肠��
					
				Case Else
					'�G��������ݒ�Ȃ�
					
			End Select
			
		End With
		
		CF_Get_TANBMNCD = Ret_Value
		
	End Function
	' === 20060828 === INSERT E
	
	' === 20060829 === INSERT S - ACE)Nagasawa �ԍ��`�[����������ꍇ�͌x����\������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_UpdateJDN_Chk
	'   �T�v�F  �󒍒����`�F�b�N
	'   �����F  pin_strKJNDT    : �������i�󒍓��j
	'           pin_strTOKCD  �@: ���Ӑ�R�[�h
	'   �ߒl�F  0�F����@1: �����������߂��@2: ���������߂��@9: �ُ�
	'   ���l�F  ���Ӑ�}�X�^.���������A���[�U�[���Ǘ��e�[�u��.����������������
	'�@�@�@�@�@ �󒍒������\���ǂ����̔��f���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_UpdateJDN_Chk(ByVal pin_strKJNDT As String, ByVal pin_strTOKCD As String) As Short
		
		Dim strSMEDT As String
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Mst_Inf_SYSTBA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Mst_Inf_SYSTBA As TYPE_DB_SYSTBA
		Dim Mst_Inf_TOKMTA As TYPE_DB_TOKMTA
		Dim intRet As Short
		
		AE_UpdateJDN_Chk = 9
		
		Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
		
		'���[�U�[���Ǘ��e�[�u������
		If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
			Exit Function
		End If
		
		'����ƌ����������̔�r
		If Trim(Mst_Inf_SYSTBA.UKSMEDT) <> "" Then
			If CF_Ora_Date(pin_strKJNDT) <= Mst_Inf_SYSTBA.UKSMEDT Then
				AE_UpdateJDN_Chk = 1
				Exit Function
			End If
		End If
		
		Call DB_TOKMTA_Clear(Mst_Inf_TOKMTA)
		
		' === 20061026 === DELETE S - ACE)Nagasawa �������̃`�F�b�N�͍s��Ȃ�
		'    '���Ӑ�}�X�^����
		'    If DSPTOKCD_SEARCH(pin_strTOKCD, Mst_Inf_TOKMTA) <> 0 Then
		'        Exit Function
		'    End If
		'
		'    '����Ɛ��������̔�r
		'    If Trim(Mst_Inf_TOKMTA.TOKSMEDT) <> "" Then
		'        If CF_Ora_Date(pin_strKJNDT) <= Mst_Inf_TOKMTA.TOKSMEDT Then
		'            AE_UpdateJDN_Chk = 2
		'            Exit Function
		'        End If
		'    End If
		' === 20061026 === DELETE E -
		
		AE_UpdateJDN_Chk = 0
		
	End Function
	' === 20060829 === INSERT E -
	
	' === 20060830 === INSERT S - ACE)Nagasawa �����̎擾�͉�ʂ̓��t����ɍs��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_Get_INPTANCD_Inf
	'   �T�v�F  ���͒S���ҏ��擾����
	'   �����F  pin_strTANCD    : �S���҃R�[�h
	'           pot_Inp_Inf     : �擾���ʓ��͒S���ҏ��
	'           pin_strKJNDT    : �������i�ȗ����ꂽ�ꍇ�͉^�p���Ƃ���j
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function F_Get_INPTANCD_Inf(ByVal pin_strTANCD As String, ByRef pot_Inp_Inf As Cmn_Inp_Inf, Optional ByVal pin_strKJNDT As String = "") As Short
		
		Dim Mst_Inf_TANMTA As TYPE_DB_TANMTA
		Dim intRet As Short
		Dim strKJNDT As String
		' === 20061030 === INSERT S - ACE)Nagasawa �����̓ǂݕ��̕ύX
		Dim strRet As String
		' === 20061030 === INSERT E -
		
		F_Get_INPTANCD_Inf = 9
		
		'������ȗ����ꂽ�ꍇ�͉^�p�����g�p����
		If Trim(pin_strKJNDT) = "" Then
			strKJNDT = GV_UNYDate
		Else
			strKJNDT = CF_Ora_Date(pin_strKJNDT)
		End If
		
		'�S���҃}�X�^����
		Call DB_TANMTA_Clear(Mst_Inf_TANMTA)
		intRet = DSPTANCD_SEARCH(pin_strTANCD, Mst_Inf_TANMTA)
		If intRet = 0 Then
			pot_Inp_Inf.InpTanNm = Mst_Inf_TANMTA.TANNM '���͒S���Җ�
			' === 20061030 === UPDATE S - ACE)Nagasawa �����̓ǂݕ��̕ύX
			'        '�������擾�i�P���ύX�����A�󒍍X�V�����Aetc...�j
			'        Call F_Get_KNG_Inf(Mst_Inf_TANMTA, strKJNDT, pot_Inp_Inf)
			'    End If
		End If
		
		'������
		With Inp_Inf
			'��������A�����Ȃ��Ƃ���
			.InpTKCHGKB = gc_strTKCHGKB_NG '�̔��P���ύX����
			.InpJDNUPDKB = gc_strJDNUPDKB_NG '�X�V����
			.InpPRTAUTH = gc_strJDNUPDKB_NG '�������
			.InpFILEAUTH = gc_strJDNUPDKB_NG '�t�@�C���o�͌���
		End With
		
		'�����擾���W�b�N�ւ̈����Z�b�g
		gs_userid = pin_strTANCD '���͒S����ID
		gs_pgid = SSS_PrgId '�v���O����ID
		
		'�����擾
		strRet = Get_Authority(strKJNDT)
		
		'�擾���ꂽ�����Z�b�g
		With Inp_Inf
			.InpTKCHGKB = gs_SALTAUTH '�̔��P���ύX����
			.InpJDNUPDKB = gs_UPDAUTH '�X�V����
			.InpPRTAUTH = gs_PRTAUTH '�������
			.InpFILEAUTH = gs_FILEAUTH '�t�@�C���o�͌���
		End With
		' === 20061030 === UPDATE E -
		
		F_Get_INPTANCD_Inf = 0
		
	End Function
	' === 20060830 === INSERT E -
	
	' === 20060905 === INSERT S - ACE)Hashiri �ԓ`�[���쐬
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_AKADEN_INSERT
	'   �T�v�F  �ԓ`�[�쐬����
	'   �����F  pin_strDATNO        : �`�[�Ǘ���
	'           pin_strMOTODATNO  �@: ���`�[�Ǘ���
	'           pin_strOPEID  �@    : �ŏI��Ǝ҃R�[�h
	'           pin_strCLTID      �@: �N���C�A���g�h�c
	'           pin_strJODCNKB    �@: �󒍃L�����Z�����R�敪
	'           pin_strJDNDT      �@: �󒍓`�[���t(�ȗ����ꂽ�ꍇ�A�^�p��)
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  �p�����[�^�̒l�����ɐԓ`�[���쐬����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061108 === UPDATE S - ACE)Nagasawa
	'Public Function AE_AKADEN_INSERT(ByVal pin_strDATNO As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String, _
	''                          ByVal pin_strJODCNKB As String) As Integer
	Public Function AE_AKADEN_INSERT(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strJODCNKB As String, Optional ByVal pin_strJDNDT As String = "") As Short
		' === 200611018 === UPDATE E -
		
		Dim strSQL As String
		Dim bolRet As Boolean
		' === 20061119 === INSERT S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		Dim strDLFLG As String
		' === 20061119 === INSERT E -
		
		On Error GoTo AE_AKADEN_INSERT_err
		
		AE_AKADEN_INSERT = 9
		
		If Trim(pin_strJDNDT) = "" Then
			pin_strJDNDT = GV_UNYDate
		End If
		
		' === 20061119 === INSERT S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		'�폜�t���O�ҏW
		strDLFLG = ""
		If Trim(pin_strJODCNKB) <> "" Then
			strDLFLG = gc_strDLFLG_DEL
		Else
			strDLFLG = gc_strDLFLG_UPD
		End If
		' === 20061119 === INSERT E -
		
		'�󒍌��o���g�����ǉ��r�p�k
		' === 20061108 === UPDATE S - ACE)Nagasawa
		'    strSQL = AE_AKADEN_JDNTHA_SQL(pin_strDATNO, pin_strMOTODATNO, pin_strOPEID, pin_strCLTID, pin_strJODCNKB)
		' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		'    strSQL = AE_AKADEN_JDNTHA_SQL(pin_strDatNo, pin_strMOTODATNO, pin_strOPEID, pin_strCLTID, pin_strJODCNKB, pin_strJDNDT)
		strSQL = AE_AKADEN_JDNTHA_SQL(pin_strDatNo, pin_strMotoDatNo, pin_strOPEID, pin_strCLTID, pin_strJODCNKB, strDLFLG, pin_strJDNDT)
		' === 20061119 === UPDATE E -
		' === 20061108 === UPDATE E -
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_AKADEN_INSERT_err
		End If
		
		'�󒍃g�����ǉ��r�p�k
		' === 20061108 === UPDATE S - ACE)Nagasawa
		'    strSQL = AE_AKADEN_JDNTRA_SQL(pin_strDATNO, pin_strMOTODATNO, pin_strOPEID, pin_strCLTID)
		' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		'    strSQL = AE_AKADEN_JDNTRA_SQL(pin_strDatNo, pin_strMOTODATNO, pin_strOPEID, pin_strCLTID, pin_strJDNDT)
		strSQL = AE_AKADEN_JDNTRA_SQL(pin_strDatNo, pin_strMotoDatNo, pin_strOPEID, pin_strCLTID, strDLFLG, pin_strJDNDT)
		' === 20061119 === UPDATE E -
		' === 20061108 === UPDATE E -
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_AKADEN_INSERT_err
		End If
		
		AE_AKADEN_INSERT = 0
		
AE_AKADEN_INSERT_err: 
		Exit Function
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_AKADEN_JDNTHA_SQL
	'   �T�v�F  �ԓ`�[�쐬����_�󒍌��o���g����SQL���쐬
	'   �����F  pin_strDATNO        : �`�[�Ǘ���
	'           pin_strMOTODATNO  �@: ���`�[�Ǘ���
	'           pin_strOPEID  �@    : �ŏI��Ǝ҃R�[�h
	'           pin_strCLTID      �@: �N���C�A���g�h�c
	'           pin_strJODCNKB    �@: �󒍃L�����Z�����R�敪
	'           pin_strDLFLG        : �폜�t���O
	'           pin_strJDNDT        : �󒍓`�[���t
	'   �ߒl�F  SQL������
	'   ���l�F  �󒍃g����INSERT���̍쐬
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061108 === UPDATE S - ACE)Nagasawa
	'Private Function AE_AKADEN_JDNTHA_SQL(ByVal pin_strDATNO As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String, _
	''                          ByVal pin_strJODCNKB As String) As String
	' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
	'Private Function AE_AKADEN_JDNTHA_SQL(ByVal pin_strDatNo As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String, _
	''                          ByVal pin_strJODCNKB As String, _
	''                          ByVal pin_strJDNDT As String) As String
	Private Function AE_AKADEN_JDNTHA_SQL(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strJODCNKB As String, ByVal pin_strDLFLG As String, ByVal pin_strJDNDT As String) As String
		' === 20061119 === UPDATE E -
		' === 20061108 === UPDATE E -
		
		Dim strSQL As String
		' === 20070325 === INSERT S - ACE)Nagasawa �ԓ`�[�������t�X�V
		Dim strSMADT As String
		
		'�o�������t�Z�o
		Call AE_GetKRSMADT(pin_strJDNDT, strSMADT)
		' === 20070325 === INSERT E -
		
		strSQL = ""
		strSQL = strSQL & " Insert into JDNTHA "
		strSQL = strSQL & "        ( DATNO " '�`�[�Ǘ���
		strSQL = strSQL & "        , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "        , AKAKROKB " '�ԍ��敪
		strSQL = strSQL & "        , DENKB " '�`�[�敪
		strSQL = strSQL & "        , JDNNO " '�󒍔ԍ�
		strSQL = strSQL & "        , JHDNO " '�󔭒���
		strSQL = strSQL & "        , JDNDT " '�󒍓`�[���t
		strSQL = strSQL & "        , DENDT " '�󒍓��t
		strSQL = strSQL & "        , REGDT " '����`�[���t
		strSQL = strSQL & "        , DEFNOKDT " '�[��
		strSQL = strSQL & "        , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , TOKRN " '���Ӑ旪��
		strSQL = strSQL & "        , NHSCD " '�[����R�[�h
		strSQL = strSQL & "        , NHSNMA " '�[���於�̂P
		strSQL = strSQL & "        , NHSNMB " '�[���於�̂Q
		strSQL = strSQL & "        , TANCD " '�S���҃R�[�h
		strSQL = strSQL & "        , TANNM " '�S���Җ�
		strSQL = strSQL & "        , BUMCD " '����R�[�h
		strSQL = strSQL & "        , BUMNM " '���喼
		strSQL = strSQL & "        , TOKSEICD " '������R�[�h
		strSQL = strSQL & "        , SOUCD " '�q�ɃR�[�h
		strSQL = strSQL & "        , SOUNM " '�q�ɖ�
		strSQL = strSQL & "        , ZKTKB " '����敪
		strSQL = strSQL & "        , ZKTNM " '����敪��
		strSQL = strSQL & "        , SMADT " '�o�������t
		strSQL = strSQL & "        , JDNENDKB " '�󒍊����敪
		strSQL = strSQL & "        , SBAUODKN " '�󒍋��z�i�{�̍��v�j
		strSQL = strSQL & "        , SBAUZEKN " '�󒍋��z�i����Ŋz�j
		strSQL = strSQL & "        , SBAUZKKN " '�󒍋��z�i�`�[�v�j
		strSQL = strSQL & "        , DENCM " '���l
		strSQL = strSQL & "        , TOKSMEKB " '���敪
		strSQL = strSQL & "        , TOKSMEDD " '���������t�i����j
		strSQL = strSQL & "        , TOKSMECC " '���T�C�N���i����j
		strSQL = strSQL & "        , TOKSDWKB " '���ߗj��
		strSQL = strSQL & "        , TOKKESCC " '����T�C�N��
		strSQL = strSQL & "        , TOKKESDD " '������t
		strSQL = strSQL & "        , TOKKDWKB " '����j��
		strSQL = strSQL & "        , LSTID " '�`�[���
		strSQL = strSQL & "        , TKNRPSKB " '���z�[����������
		strSQL = strSQL & "        , TKNZRNKB " '���z�[�������敪
		strSQL = strSQL & "        , TOKZEIKB " '����ŋ敪
		strSQL = strSQL & "        , TOKZCLKB " '����ŎZ�o�敪
		strSQL = strSQL & "        , TOKRPSKB " '����Œ[����������
		strSQL = strSQL & "        , TOKZRNKB " '����Œ[�������敪
		strSQL = strSQL & "        , TOKNMMKB " '�����ƭ�ً敪�i���j
		strSQL = strSQL & "        , NHSNMMKB " '�����ƭ�ً敪�i�[�j
		strSQL = strSQL & "        , TOKMSTKB " '�}�X�^�敪�i���Ӑ�j
		strSQL = strSQL & "        , NHSMSTKB " '�}�X�^�敪�i�[����j
		strSQL = strSQL & "        , TANMSTKB " '�}�X�^�敪�i�S���ҁj
		strSQL = strSQL & "        , MITNO " '���ϔԍ�
		strSQL = strSQL & "        , MITNOV " '�Ő�
		strSQL = strSQL & "        , AKNID " '�Č��h�c
		strSQL = strSQL & "        , CLMDL " '���ތ^��
		strSQL = strSQL & "        , URIKJN " '����
		strSQL = strSQL & "        , BINCD " '�֖��R�[�h
		strSQL = strSQL & "        , KENNMA " '�����P
		strSQL = strSQL & "        , KENNMB " '�����Q
		strSQL = strSQL & "        , BKTHKKB " '�����s�敪
		strSQL = strSQL & "        , MAEUKKB " '�O��敪
		strSQL = strSQL & "        , SEIKB " '�����敪
		strSQL = strSQL & "        , JDNTRKB " '�󒍎���敪
		strSQL = strSQL & "        , NHSADA " '�[����Z���P
		strSQL = strSQL & "        , NHSADB " '�[����Z���Q
		strSQL = strSQL & "        , NHSADC " '�[����Z���R
		strSQL = strSQL & "        , JDNINKB " '�󒍎捞���
		strSQL = strSQL & "        , DFKJDNNO " '�_�C�t�N�󒍔ԍ�
		strSQL = strSQL & "        , TOKJDNNO " '�q�撍��No.
		strSQL = strSQL & "        , HDKEIKN " '�n�[�h�_����z
		strSQL = strSQL & "        , HDSIKKN " '�n�[�h�d�؋��z
		strSQL = strSQL & "        , SFKEIKN " '�\�t�g�_����z
		strSQL = strSQL & "        , SFSIKKN " '�\�t�g�d�؋��z
		strSQL = strSQL & "        , CMPKTCD " '�R���s���[�^�^���R�[�h
		strSQL = strSQL & "        , CMPKTNM " '�R���s���[�^�^����
		strSQL = strSQL & "        , PRDTBMCD " '���Y�S������R�[�h
		strSQL = strSQL & "        , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "        , SBAFRCKN " '�O�ݎ󒍋��z�i�`�[�v�j
		strSQL = strSQL & "        , JODRSNKB " '�󒍗��R�敪
		strSQL = strSQL & "        , JODCNKB " '�󒍃L�����Z�����R�敪
		strSQL = strSQL & "        , FRNKB " '�C�O����敪
		strSQL = strSQL & "        , SIMUKE " '�d���n
		strSQL = strSQL & "        , JDNPRKB " '���s�敪
		strSQL = strSQL & "        , DENCMIN " '�Г����l
		strSQL = strSQL & "        , SETUPKB " '�Z�b�g�A�b�v�V�[�g�捞�敪
		strSQL = strSQL & "        , MOTDATNO " '���`�[�Ǘ��ԍ�
		' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		'    strSQL = strSQL & "        , OPEID "           '�ŏI��Ǝ҃R�[�h
		'    strSQL = strSQL & "        , CLTID "           '�N���C�A���g�h�c
		'    strSQL = strSQL & "        , WRTTM "           '�^�C���X�^���v�i���ԁj
		'    strSQL = strSQL & "        , WRTDT "           '�^�C���X�^���v�i���t�j
		'    strSQL = strSQL & "        , WRTFSTTM "        '�^�C���X�^���v�i�o�^���ԁj
		'    strSQL = strSQL & "        , WRTFSTDT "        '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "        , FOPEID " '����o�^���[�U�[�h�c
		strSQL = strSQL & "        , FCLTID " '����o�^�N���C�A���g�h�c
		strSQL = strSQL & "        , WRTFSTTM " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "        , WRTFSTDT " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "        , OPEID " '���[�U�[�h�c�i�����j
		strSQL = strSQL & "        , CLTID " '�N���C�A���g�h�c�i�����j
		strSQL = strSQL & "        , WRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "        , WRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "        , UOPEID " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "        , UCLTID " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "        , UWRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "        , UWRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "        , PGID " '�o�f�h�c
		strSQL = strSQL & "        , DLFLG " '�폜�t���O
		' === 20061119 === UPDATE E -
		strSQL = strSQL & "        , JDNENDNM " '�󒍊����敪��
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " Select "
		strSQL = strSQL & "           '" & CF_Ora_String(pin_strDatNo, 10) & "'"
		strSQL = strSQL & "        ,  DATKB "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "'"
		strSQL = strSQL & "        ,  DENKB "
		strSQL = strSQL & "        ,  JDNNO "
		strSQL = strSQL & "        ,  JHDNO "
		' === 20061108 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  JDNDT "
		strSQL = strSQL & "        ,  '" & CF_Ora_Date(pin_strJDNDT) & "'"
		' === 20061108 === UPDATE E -
		strSQL = strSQL & "        ,  DENDT "
		strSQL = strSQL & "        ,  REGDT "
		strSQL = strSQL & "        ,  DEFNOKDT "
		strSQL = strSQL & "        ,  TOKCD "
		strSQL = strSQL & "        ,  TOKRN "
		strSQL = strSQL & "        ,  NHSCD "
		strSQL = strSQL & "        ,  NHSNMA "
		strSQL = strSQL & "        ,  NHSNMB "
		strSQL = strSQL & "        ,  TANCD "
		strSQL = strSQL & "        ,  TANNM "
		strSQL = strSQL & "        ,  BUMCD "
		strSQL = strSQL & "        ,  BUMNM "
		strSQL = strSQL & "        ,  TOKSEICD "
		strSQL = strSQL & "        ,  SOUCD "
		strSQL = strSQL & "        ,  SOUNM "
		strSQL = strSQL & "        ,  ZKTKB "
		strSQL = strSQL & "        ,  ZKTNM "
		' === 20070325 === UPDATE S - ACE)Nagasawa �ԓ`�[�������t�X�V
		'    strSQL = strSQL & "        ,  SMADT "
		strSQL = strSQL & "        ,  '" & CF_Ora_Date(strSMADT) & "' "
		' === 20070325 === UPDATE E -
		strSQL = strSQL & "        ,  JDNENDKB "
		strSQL = strSQL & "        ,  SBAUODKN * (-1) "
		strSQL = strSQL & "        ,  SBAUZEKN * (-1) "
		strSQL = strSQL & "        ,  SBAUZKKN * (-1) "
		strSQL = strSQL & "        ,  DENCM "
		strSQL = strSQL & "        ,  TOKSMEKB "
		strSQL = strSQL & "        ,  TOKSMEDD "
		strSQL = strSQL & "        ,  TOKSMECC "
		strSQL = strSQL & "        ,  TOKSDWKB "
		strSQL = strSQL & "        ,  TOKKESCC "
		strSQL = strSQL & "        ,  TOKKESDD "
		strSQL = strSQL & "        ,  TOKKDWKB "
		strSQL = strSQL & "        ,  LSTID "
		strSQL = strSQL & "        ,  TKNRPSKB "
		strSQL = strSQL & "        ,  TKNZRNKB "
		strSQL = strSQL & "        ,  TOKZEIKB "
		strSQL = strSQL & "        ,  TOKZCLKB "
		strSQL = strSQL & "        ,  TOKRPSKB "
		strSQL = strSQL & "        ,  TOKZRNKB "
		strSQL = strSQL & "        ,  TOKNMMKB "
		strSQL = strSQL & "        ,  NHSNMMKB "
		strSQL = strSQL & "        ,  TOKMSTKB "
		strSQL = strSQL & "        ,  NHSMSTKB "
		strSQL = strSQL & "        ,  TANMSTKB "
		strSQL = strSQL & "        ,  MITNO "
		strSQL = strSQL & "        ,  MITNOV "
		strSQL = strSQL & "        ,  AKNID "
		strSQL = strSQL & "        ,  CLMDL "
		strSQL = strSQL & "        ,  URIKJN "
		strSQL = strSQL & "        ,  BINCD "
		strSQL = strSQL & "        ,  KENNMA "
		strSQL = strSQL & "        ,  KENNMB "
		strSQL = strSQL & "        ,  BKTHKKB "
		strSQL = strSQL & "        ,  MAEUKKB "
		strSQL = strSQL & "        ,  SEIKB "
		strSQL = strSQL & "        ,  JDNTRKB "
		strSQL = strSQL & "        ,  NHSADA "
		strSQL = strSQL & "        ,  NHSADB "
		strSQL = strSQL & "        ,  NHSADC "
		strSQL = strSQL & "        ,  JDNINKB "
		strSQL = strSQL & "        ,  DFKJDNNO "
		strSQL = strSQL & "        ,  TOKJDNNO "
		strSQL = strSQL & "        ,  HDKEIKN * (-1) "
		strSQL = strSQL & "        ,  HDSIKKN * (-1) "
		strSQL = strSQL & "        ,  SFKEIKN * (-1) "
		strSQL = strSQL & "        ,  SFSIKKN * (-1) "
		strSQL = strSQL & "        ,  CMPKTCD "
		strSQL = strSQL & "        ,  CMPKTNM "
		strSQL = strSQL & "        ,  PRDTBMCD "
		strSQL = strSQL & "        ,  TUKKB "
		' === 20060107 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  SBAFRCKN "
		strSQL = strSQL & "        ,  SBAFRCKN * (-1) "
		' === 20060107 === UPDATE E -
		strSQL = strSQL & "        ,  JODRSNKB "
		'�폜�̏ꍇ�͎󒍷�ݾً敪��ҏW
		If Trim(pin_strJODCNKB) = "" Then
			strSQL = strSQL & "        ,  JODCNKB "
		Else
			strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strJODCNKB, 3) & "' "
		End If
		strSQL = strSQL & "        ,  FRNKB "
		strSQL = strSQL & "        ,  SIMUKE "
		' === 20061219 === UPDATE S - ACE)Nagasawa ���s�敪�́u�����s�v�ɖ߂�
		'    strSQL = strSQL & "        ,  JDNPRKB "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(gc_strHAKKB_MI, 1) & "' "
		' === 20061219 === UPDATE E -
		strSQL = strSQL & "        ,  DENCMIN "
		strSQL = strSQL & "        ,  SETUPKB "
		strSQL = strSQL & "        ,  DATNO "
		' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		'    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		'    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		'    strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		'    strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		'    strSQL = strSQL & "        ,  WRTFSTTM "
		'    strSQL = strSQL & "        ,  WRTFSTDT "
		
		' === 20061205 === UPDATE S - ACE)Nagasawa ����o�^���ڂ̍X�V�d�l�̕ύX
		'    strSQL = strSQL & "        ,  FOPEID "
		'    strSQL = strSQL & "        ,  FCLTID "
		'    strSQL = strSQL & "        ,  WRTFSTTM "
		'    strSQL = strSQL & "        ,  WRTFSTDT "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		' === 20061205 === UPDATE E -
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strDLFLG, 1) & "' "
		' === 20061119 === UPDATE E -
		strSQL = strSQL & "        ,  JDNENDNM "
		strSQL = strSQL & " From  "
		strSQL = strSQL & "     JDNTHA  "
		strSQL = strSQL & " Where  "
		strSQL = strSQL & "     DATNO =  '" & CF_Ora_String(pin_strMotoDatNo, 10) & "'"
		
		AE_AKADEN_JDNTHA_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_AKADEN_JDNTRA_SQL
	'   �T�v�F  �ԓ`�[�쐬����_�󒍃g����SQL���쐬
	'   �����F  pin_strDATNO        : �`�[�Ǘ���
	'           pin_strMOTODATNO  �@: ���`�[�Ǘ���
	'           pin_strOPEID  �@    : �ŏI��Ǝ҃R�[�h
	'           pin_strCLTID      �@: �N���C�A���g�h�c
	'           pin_strJODCNKB    �@: �󒍃L�����Z�����R�敪
	'           pin_strDLFLG        : �폜�t���O
	'           pin_strJDNDT        : �󒍓`�[���t
	'   �ߒl�F  SQL������
	'   ���l�F  �󒍃g����INSERT���̍쐬
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20061108 === UPDATE S - ACE)Nagasawa
	'Private Function AE_AKADEN_JDNTRA_SQL(ByVal pin_strDATNO As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String) As String
	' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
	'Private Function AE_AKADEN_JDNTRA_SQL(ByVal pin_strDatNo As String, _
	''                          ByVal pin_strMOTODATNO As String, _
	''                          ByVal pin_strOPEID As String, _
	''                          ByVal pin_strCLTID As String, _
	''                          ByVal pin_strJDNDT As String) As String
	Private Function AE_AKADEN_JDNTRA_SQL(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strDLFLG As String, ByVal pin_strJDNDT As String) As String
		' === 20061119 === UPDATE E -
		' === 20061108 === UPDATE E -
		
		Dim strSQL As String
		' === 20070325 === INSERT S - ACE)Nagasawa �ԓ`�[�������t�X�V
		Dim strSMADT As String
		
		'�o�������t�Z�o
		Call AE_GetKRSMADT(pin_strJDNDT, strSMADT)
		' === 20070325 === INSERT E -
		
		strSQL = ""
		strSQL = strSQL & " Insert into JDNTRA "
		strSQL = strSQL & "        ( DATNO " '�`�[�Ǘ���
		strSQL = strSQL & "        , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "        , AKAKROKB " '�ԍ��敪
		strSQL = strSQL & "        , DENKB " '�`�[�敪
		strSQL = strSQL & "        , JDNNO " '�󒍔ԍ�
		strSQL = strSQL & "        , LINNO " '�s�ԍ�
		strSQL = strSQL & "        , RECNO " '���R�[�h�Ǘ���
		strSQL = strSQL & "        , JDNKB " '�󒍓`�[�敪
		strSQL = strSQL & "        , JHDNO " '�����ԍ�
		strSQL = strSQL & "        , JDNDT " '�󒍓`�[���t
		strSQL = strSQL & "        , DENDT " '�󒍓��t
		strSQL = strSQL & "        , DEFNOKDT " '�[��
		strSQL = strSQL & "        , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "        , NHSCD " '�[����R�[�h
		strSQL = strSQL & "        , TANCD " '�S���҃R�[�h
		strSQL = strSQL & "        , BUMCD " '����R�[�h
		strSQL = strSQL & "        , TOKSEICD " '������R�[�h
		strSQL = strSQL & "        , SOUCD " '�q�ɃR�[�h
		strSQL = strSQL & "        , ZKTKB " '����敪
		strSQL = strSQL & "        , SMADT " '�o�������t
		strSQL = strSQL & "        , HINCD " '���i�R�[�h
		strSQL = strSQL & "        , HINNMA " '�^��
		strSQL = strSQL & "        , HINNMB " '���i���P
		strSQL = strSQL & "        , UODSU " '�󒍐���
		strSQL = strSQL & "        , UNTCD " '�P�ʃR�[�h
		strSQL = strSQL & "        , UNTNM " '�P�ʖ�
		strSQL = strSQL & "        , UODTK " '�󒍒P��
		strSQL = strSQL & "        , UODKN " '�󒍋��z
		strSQL = strSQL & "        , SIKTK " '�c�Ǝd�ؒP��
		strSQL = strSQL & "        , SIKKN " '�c�Ǝd�؋��z
		strSQL = strSQL & "        , TEIKATK " '�艿
		strSQL = strSQL & "        , SIKRT " '�d�ؗ�
		strSQL = strSQL & "        , KONSIKRT " '����d�ؗ�
		strSQL = strSQL & "        , ZAIKB " '�݌ɊǗ��敪
		strSQL = strSQL & "        , LINCMA " '���ה��l�P
		strSQL = strSQL & "        , LINCMB " '���ה��l�Q
		strSQL = strSQL & "        , LSTID " '�`�[���
		strSQL = strSQL & "        , HINZEIKB " '���i����ŋ敪
		strSQL = strSQL & "        , ZEIRT " '����ŗ�
		strSQL = strSQL & "        , UZEKN " '����Ŋz
		strSQL = strSQL & "        , ZEIRNKKB " '����Ń����N
		strSQL = strSQL & "        , HINNMMKB " '�����ƭ�ً敪�i���i�j
		strSQL = strSQL & "        , MAKCD " '���[�J�[�R�[�h
		strSQL = strSQL & "        , HINKB " '���i�敪
		strSQL = strSQL & "        , HRTDD " '�������[�h�^�C��
		strSQL = strSQL & "        , ORTDD " '�o�׃��[�h�^�C��
		strSQL = strSQL & "        , TOKMSTKB " '�}�X�^�敪�i���Ӑ�j
		strSQL = strSQL & "        , NHSMSTKB " '�}�X�^�敪�i�[����j
		strSQL = strSQL & "        , TANMSTKB " '�}�X�^�敪�i�S���ҁj
		strSQL = strSQL & "        , HINMSTKB " '�}�X�^�敪�i���i�j
		strSQL = strSQL & "        , ODNYTDT " '�o�ח\���
		strSQL = strSQL & "        , UDNYTDT " '����\���
		strSQL = strSQL & "        , TNKKB " '�P�����
		strSQL = strSQL & "        , GNKCD " '�����Ǘ��R�[�h
		strSQL = strSQL & "        , CLMDL " '���ތ^��
		strSQL = strSQL & "        , HINGRP " '���i�Q
		strSQL = strSQL & "        , ATZHIKSU " '�����݌Ɉ�����
		strSQL = strSQL & "        , ATNHIKSU " '�������ɗ\�������
		strSQL = strSQL & "        , MNZHIKSU " '�蓮�݌Ɉ�����
		strSQL = strSQL & "        , MNNHIKSU " '�蓮���ɗ\�������
		strSQL = strSQL & "        , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "        , RATERT " '�בփ��[�g
		strSQL = strSQL & "        , FRCTK " '�O�ݒP��
		strSQL = strSQL & "        , FRCKN " '�O�݋��z
		strSQL = strSQL & "        , FRCTEITK " '�O�ݒ艿
		strSQL = strSQL & "        , HSTJDNNO " '�z�X�g�󒍔ԍ�
		strSQL = strSQL & "        , TOKJDNNO " '�q�撍��No.
		strSQL = strSQL & "        , TOKJDNED " '�q�撍��No.�}��
		strSQL = strSQL & "        , MAKNM " '���[�J�[��
		strSQL = strSQL & "        , SBNNO " '����
		strSQL = strSQL & "        , JDNDELDT " '�󒍎����
		strSQL = strSQL & "        , FDNDT " '�o�׎w����
		strSQL = strSQL & "        , FRDSU " '�o�׎w������
		strSQL = strSQL & "        , ODNDT " '�o�׎��ѓ�
		strSQL = strSQL & "        , OTPSU " '�o�׎��ѐ���
		strSQL = strSQL & "        , UDNDT " '�����
		strSQL = strSQL & "        , URISU " '���㐔��
		strSQL = strSQL & "        , URIKN " '������z
		strSQL = strSQL & "        , FURIKN " '�O�ݔ�����z
		strSQL = strSQL & "        , URISIKKN " '���㕪�d�؋��z
		strSQL = strSQL & "        , NYUDT " '������
		strSQL = strSQL & "        , NYUKN " '�����z
		strSQL = strSQL & "        , FNYUKN " '�O�ݓ����z
		strSQL = strSQL & "        , NYUKB " '�������
		strSQL = strSQL & "        , INVNO " '�C���{�C�X��
		strSQL = strSQL & "        , FRNMOVSU " '�C�O�q�Ɉړ���
		strSQL = strSQL & "        , TOKDNKB " '�q��`�[�w��敪
		strSQL = strSQL & "        , ZAIRNK " '�݌Ƀ����N
		strSQL = strSQL & "        , PUDLNO " '���o�ɔԍ�
		strSQL = strSQL & "        , MOTDATNO " '���`�[�Ǘ��ԍ�
		' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		'    strSQL = strSQL & "        , OPEID "           '�ŏI��Ǝ҃R�[�h
		'    strSQL = strSQL & "        , CLTID "           '�N���C�A���g�h�c
		'    strSQL = strSQL & "        , WRTTM "           '�^�C���X�^���v�i���ԁj
		'    strSQL = strSQL & "        , WRTDT "           '�^�C���X�^���v�i���t�j
		'    strSQL = strSQL & "        , WRTFSTTM "        '�^�C���X�^���v�i�o�^���ԁj
		'    strSQL = strSQL & "        , WRTFSTDT "        '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "        , FOPEID " '����o�^���[�U�[�h�c
		strSQL = strSQL & "        , FCLTID " '����o�^�N���C�A���g�h�c
		strSQL = strSQL & "        , WRTFSTTM " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "        , WRTFSTDT " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "        , OPEID " '���[�U�[�h�c�i�����j
		strSQL = strSQL & "        , CLTID " '�N���C�A���g�h�c�i�����j
		strSQL = strSQL & "        , WRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "        , WRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "        , UOPEID " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "        , UCLTID " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "        , UWRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "        , UWRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "        , PGID " '�o�f�h�c
		strSQL = strSQL & "        , DLFLG " '�폜�t���O
		' === 20061119 === UPDATE E -
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " Select "
		strSQL = strSQL & "           '" & CF_Ora_String(pin_strDatNo, 10) & "'"
		strSQL = strSQL & "        ,  DATKB "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "'"
		strSQL = strSQL & "        ,  DENKB "
		strSQL = strSQL & "        ,  JDNNO "
		strSQL = strSQL & "        ,  LINNO "
		strSQL = strSQL & "        ,  RECNO "
		strSQL = strSQL & "        ,  JDNKB "
		strSQL = strSQL & "        ,  JHDNO "
		' === 20061108 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  JDNDT "
		strSQL = strSQL & "        ,  '" & CF_Ora_Date(pin_strJDNDT) & "'"
		' === 20061108 === UPDATE E -
		strSQL = strSQL & "        ,  DENDT "
		strSQL = strSQL & "        ,  DEFNOKDT "
		strSQL = strSQL & "        ,  TOKCD "
		strSQL = strSQL & "        ,  NHSCD "
		strSQL = strSQL & "        ,  TANCD "
		strSQL = strSQL & "        ,  BUMCD "
		strSQL = strSQL & "        ,  TOKSEICD "
		strSQL = strSQL & "        ,  SOUCD "
		strSQL = strSQL & "        ,  ZKTKB "
		' === 20070325 === UPDATE S - ACE)Nagasawa �ԓ`�[���o�������t�X�V
		'    strSQL = strSQL & "        ,  SMADT "
		strSQL = strSQL & "        ,  '" & CF_Ora_Date(strSMADT) & "' "
		' === 20070325 === UPDATE E -
		strSQL = strSQL & "        ,  HINCD "
		strSQL = strSQL & "        ,  HINNMA "
		strSQL = strSQL & "        ,  HINNMB "
		strSQL = strSQL & "        ,  UODSU * (-1) "
		strSQL = strSQL & "        ,  UNTCD "
		strSQL = strSQL & "        ,  UNTNM "
		strSQL = strSQL & "        ,  UODTK "
		strSQL = strSQL & "        ,  UODKN * (-1) "
		strSQL = strSQL & "        ,  SIKTK "
		strSQL = strSQL & "        ,  SIKKN * (-1) "
		strSQL = strSQL & "        ,  TEIKATK "
		strSQL = strSQL & "        ,  SIKRT "
		strSQL = strSQL & "        ,  KONSIKRT "
		strSQL = strSQL & "        ,  ZAIKB "
		strSQL = strSQL & "        ,  LINCMA "
		strSQL = strSQL & "        ,  LINCMB "
		strSQL = strSQL & "        ,  LSTID "
		strSQL = strSQL & "        ,  HINZEIKB "
		strSQL = strSQL & "        ,  ZEIRT "
		strSQL = strSQL & "        ,  UZEKN * (-1) "
		strSQL = strSQL & "        ,  ZEIRNKKB "
		strSQL = strSQL & "        ,  HINNMMKB "
		strSQL = strSQL & "        ,  MAKCD "
		strSQL = strSQL & "        ,  HINKB "
		strSQL = strSQL & "        ,  HRTDD "
		strSQL = strSQL & "        ,  ORTDD "
		strSQL = strSQL & "        ,  TOKMSTKB "
		strSQL = strSQL & "        ,  NHSMSTKB "
		strSQL = strSQL & "        ,  TANMSTKB "
		strSQL = strSQL & "        ,  HINMSTKB "
		strSQL = strSQL & "        ,  ODNYTDT "
		strSQL = strSQL & "        ,  UDNYTDT "
		strSQL = strSQL & "        ,  TNKKB "
		strSQL = strSQL & "        ,  GNKCD "
		strSQL = strSQL & "        ,  CLMDL "
		strSQL = strSQL & "        ,  HINGRP "
		strSQL = strSQL & "        ,  ATZHIKSU "
		strSQL = strSQL & "        ,  ATNHIKSU "
		strSQL = strSQL & "        ,  MNZHIKSU "
		strSQL = strSQL & "        ,  MNNHIKSU "
		strSQL = strSQL & "        ,  TUKKB "
		strSQL = strSQL & "        ,  RATERT "
		strSQL = strSQL & "        ,  FRCTK "
		strSQL = strSQL & "        ,  FRCKN * (-1) "
		strSQL = strSQL & "        ,  FRCTEITK "
		strSQL = strSQL & "        ,  HSTJDNNO "
		strSQL = strSQL & "        ,  TOKJDNNO "
		strSQL = strSQL & "        ,  TOKJDNED "
		strSQL = strSQL & "        ,  MAKNM "
		strSQL = strSQL & "        ,  SBNNO "
		' === 20061223 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  JDNDELDT "
		If Trim(pin_strDLFLG) = gc_strDLFLG_DEL Then
			' === 20060112 === UPDATE S - ACE)Nagasawa �󒍎�������󒍓`�[���ɂȂ�悤�ύX
			'        strSQL = strSQL & "        ,  '" & GV_UNYDate & "' "
			strSQL = strSQL & "        ,  '" & CF_Ora_Date(pin_strJDNDT) & "'"
			' === 20060112 === UPDATE E -
		Else
			strSQL = strSQL & "        ,  JDNDELDT "
		End If
		' === 20061223 === UPDATE E -
		strSQL = strSQL & "        ,  FDNDT "
		strSQL = strSQL & "        ,  FRDSU "
		strSQL = strSQL & "        ,  ODNDT "
		strSQL = strSQL & "        ,  OTPSU "
		strSQL = strSQL & "        ,  UDNDT "
		strSQL = strSQL & "        ,  URISU * (-1) "
		strSQL = strSQL & "        ,  URIKN * (-1) "
		' === 20060107 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  FURIKN "
		strSQL = strSQL & "        ,  FURIKN * (-1) "
		' === 20060107 === UPDATE E -
		' === 20070329 === UPDATE S - ACE)Nagasawa ��������ԕi�Ή�
		'    strSQL = strSQL & "        ,  URISIKKN "
		strSQL = strSQL & "        ,  URISIKKN * (-1) "
		' === 20070329 === UPDATE E -
		strSQL = strSQL & "        ,  NYUDT "
		strSQL = strSQL & "        ,  NYUKN * (-1) "
		' === 20060107 === UPDATE S - ACE)Nagasawa
		'    strSQL = strSQL & "        ,  FNYUKN "
		strSQL = strSQL & "        ,  FNYUKN * (-1) "
		' === 20060107 === UPDATE E -
		strSQL = strSQL & "        ,  NYUKB "
		strSQL = strSQL & "        ,  INVNO "
		strSQL = strSQL & "        ,  FRNMOVSU "
		strSQL = strSQL & "        ,  TOKDNKB "
		strSQL = strSQL & "        ,  ZAIRNK "
		strSQL = strSQL & "        ,  PUDLNO "
		strSQL = strSQL & "        ,  DATNO "
		' === 20061119 === UPDATE S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
		'    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		'    strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		'    strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		'    strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		'    strSQL = strSQL & "        ,  WRTFSTTM "
		'    strSQL = strSQL & "        ,  WRTFSTDT "
		' === 20061205 === UPDATE S - ACE)Nagasawa ����o�^���ڂ̍X�V�d�l�̕ύX
		'    strSQL = strSQL & "        ,  FOPEID "
		'    strSQL = strSQL & "        ,  FCLTID "
		'    strSQL = strSQL & "        ,  WRTFSTTM "
		'    strSQL = strSQL & "        ,  WRTFSTDT "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		' === 20061205 === UPDATE E -
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strDLFLG, 1) & "' "
		' === 20061119 === UPDATE E -
		strSQL = strSQL & " From  "
		strSQL = strSQL & "     JDNTRA  "
		strSQL = strSQL & " Where  "
		strSQL = strSQL & "     DATNO =  '" & CF_Ora_String(pin_strMotoDatNo, 10) & "'"
		
		AE_AKADEN_JDNTRA_SQL = strSQL
		
	End Function
	' === 20060905 === INSERT E -
	
	' === 20061223 === INSERT S - ACE)Nagasawa �X�֔ԍ�/�d�b�ԍ�/FAX�ԍ��̒ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_AKADEN_INSERT_JDNTHB
	'   �T�v�F  �ԓ`�[�쐬����
	'   �����F  pin_strDATNO        : �`�[�Ǘ���
	'           pin_strMotoDatNo  �@: ���`�[�Ǘ���
	'           pin_strOPEID  �@    : �ŏI��Ǝ҃R�[�h
	'           pin_strCLTID      �@: �N���C�A���g�h�c
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  �p�����[�^�̒l�����ɐԓ`�[���쐬����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_AKADEN_INSERT_JDNTHB(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo AE_AKADEN_INSERT_JDNTHB_err
		
		AE_AKADEN_INSERT_JDNTHB = 9
		
		'�󒍔[����g�����ǉ��r�p�k
		strSQL = AE_AKADEN_JDNTHB_SQL(pin_strDatNo, pin_strMotoDatNo, pin_strOPEID, pin_strCLTID)
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_AKADEN_INSERT_JDNTHB_err
		End If
		
		AE_AKADEN_INSERT_JDNTHB = 0
		
AE_AKADEN_INSERT_JDNTHB_err: 
		Exit Function
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_AKADEN_JDNTHB_SQL
	'   �T�v�F  �ԓ`�[�쐬����_�󒍔[����g����SQL���쐬
	'   �����F  pin_strDATNO        : �`�[�Ǘ���
	'           pin_strMotoDatNo  �@: ���`�[�Ǘ���
	'           pin_strOPEID  �@    : �ŏI��Ǝ҃R�[�h
	'           pin_strCLTID      �@: �N���C�A���g�h�c
	'   �ߒl�F  SQL������
	'   ���l�F  �󒍔[����g����INSERT���̍쐬
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_AKADEN_JDNTHB_SQL(ByVal pin_strDatNo As String, ByVal pin_strMotoDatNo As String, ByVal pin_strOPEID As String, ByVal pin_strCLTID As String) As String
		
		Dim strSQL As String
		
		strSQL = ""
		strSQL = strSQL & " Insert into JDNTHB "
		strSQL = strSQL & "        ( DATNO " '�`�[�Ǘ���
		strSQL = strSQL & "        , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "        , AKAKROKB " '�ԍ��敪
		strSQL = strSQL & "        , JDNNO " '�󒍔ԍ�
		strSQL = strSQL & "        , NHSZP " '�[����X�֔ԍ�
		strSQL = strSQL & "        , NHSTL " '�[����d�b�ԍ�
		strSQL = strSQL & "        , NHSFX " '�[����FAX�ԍ�
		' === 20070220 === INSERT S - ACE)Nagasawa ���Ӑ於�̕ێ��Ή�
		strSQL = strSQL & "        , TOKNMA " '���Ӑ於�̂P
		strSQL = strSQL & "        , TOKNMB " '���Ӑ於�̂Q
		' === 20070220 === INSERT E -
		' === 20070307 === INSERT S - ACE)Nagasawa EDI���l�Ή��i40�o�C�g��100�o�C�g�j
		strSQL = strSQL & "        , DENCMEDI " '�d�c�h���l
		' === 20070307 === INSERT E -
		strSQL = strSQL & "        , FOPEID " '����o�^���[�UID
		strSQL = strSQL & "        , FCLTID " '����o�^�N���C�A���gID
		strSQL = strSQL & "        , WRTFSTTM " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "        , WRTFSTDT " '�^�C���X�^���v�i�o�^���t�j
		strSQL = strSQL & "        , OPEID " '���[�UID�i�����j
		strSQL = strSQL & "        , CLTID " '�N���C�A���gID�i�����j
		strSQL = strSQL & "        , WRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "        , WRTDT " '�^�C���X�^���v�i�������j
		strSQL = strSQL & "        , UOPEID " '���[�UID�i�o�b�`�j
		strSQL = strSQL & "        , UCLTID " '�N���C�A���gID�i�o�b�`�j
		strSQL = strSQL & "        , UWRTTM " '�^�C���X�^���v�i�o�b�`���ԁj
		strSQL = strSQL & "        , UWRTDT " '�^�C���X�^���v�i�o�b�`���j
		strSQL = strSQL & "        , PGID " '�X�VPGID
		strSQL = strSQL & "        ) "
		strSQL = strSQL & " Select "
		strSQL = strSQL & "           '" & CF_Ora_String(pin_strDatNo, 10) & "'"
		strSQL = strSQL & "        ,  DATKB "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "'"
		strSQL = strSQL & "        ,  JDNNO "
		strSQL = strSQL & "        ,  NHSZP "
		strSQL = strSQL & "        ,  NHSTL "
		strSQL = strSQL & "        ,  NHSFX "
		' === 20070220 === INSERT S - ACE)Nagasawa ���Ӑ於�̕ێ��Ή�
		strSQL = strSQL & "        ,  TOKNMA "
		strSQL = strSQL & "        ,  TOKNMB "
		' === 20070220 === INSERT E -
		' === 20070307 === INSERT S - ACE)Nagasawa EDI���l�Ή��i40�o�C�g��100�o�C�g�j
		strSQL = strSQL & "        ,  DENCMEDI "
		' === 20070307 === INSERT E -
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strOPEID, 8) & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(pin_strCLTID, 5) & "' "
		strSQL = strSQL & "        ,  '" & GV_SysTime & "' "
		strSQL = strSQL & "        ,  '" & GV_SysDate & "' "
		strSQL = strSQL & "        ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' "
		strSQL = strSQL & " From  "
		strSQL = strSQL & "     JDNTHB  "
		strSQL = strSQL & " Where  "
		strSQL = strSQL & "     DATNO =  '" & CF_Ora_String(pin_strMotoDatNo, 10) & "'"
		
		AE_AKADEN_JDNTHB_SQL = strSQL
		
	End Function
	' === 20061223 === INSERT E -
	
	' === 20060912 === INSERT S - ACE)Sejima CRM�A�gCSV�r���Ή�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_INI_CRM
	'   �T�v�F  CRM�֘AINI�t�@�C�����擾
	'   �����F  pin_strFileName     : INI̧�ٖ���
	'           pot_strCSVFilePath�@: CSV̧���߽
	'           pot_curRetry  �@    : ��ײ��
	'           pot_curWait       �@: ��ײ�Ԋu
	'           pot_strAddMsg     �@: �ǋL�װү����
	'   �ߒl�F  0:����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_INI_CRM(ByVal pin_strFileName As String, ByRef pot_strCSVFilePath As String, ByRef pot_curRetry As Decimal, ByRef pot_curWait As Decimal) As Short
		
		Dim Ret_Value As Short
		Dim lRet As Integer
		Dim strRet As New VB6.FixedLengthString(256)
		Dim strWk As String
		Dim intRet As Short
		
		CF_Get_INI_CRM = 9
		
		'�������񐳏툵��
		Ret_Value = 0
		
		'ini�t�@�C�����A
		'�@�@CSV�Ǎ����g���C�Ԋu
		strRet.Value = ""
		' === 20061102 === UPDATE S - ACE)Nagasawa INI�t�@�C���Ǎ��ݕύX
		'    lRet = GetPrivateProfileString("CRM", "Wait", "", strRet, Len(strRet), pin_strFileName)
		'    If lRet > 0 Then
		'        If IsNumeric(strRet) = True Then
		'            'ini�t�@�C������擾�ł��āA�����l�Ƃ��Đ�����
		'            pot_curWait = LeftWid(strRet, lRet)
		'
		'        Else
		'            'ini�t�@�C������擾�ł������A���l�Ƃ��Đ������Ȃ�
		'            Ret_Value = 9
		'
		'        End If
		'
		'    Else
		'        'ini�t�@�C������擾�ł��Ȃ�
		'        Ret_Value = 9
		'
		'    End If
		
		intRet = CF_Get_IniInf("CRM", "Wait", strRet.Value)
		If intRet = 0 Then
			If IsNumeric(strRet.Value) = True Then
				'ini�t�@�C������擾�ł��āA�����l�Ƃ��Đ�����
				pot_curWait = CF_Get_CCurString(strRet.Value)
			Else
				'ini�t�@�C������擾�ł������A���l�Ƃ��Đ������Ȃ�
				Ret_Value = 9
				
			End If
			
		Else
			'ini�t�@�C������擾�ł��Ȃ�
			Ret_Value = 9
			
		End If
		' === 20061102 === UPDATE E -
		
		'�@�@�i�ǂݍ��߂Ȃ��ꍇ�� AE_CONST.bas �̌Œ�l���g�p���A�G���[�Ƃ��Ȃ��j
		If Ret_Value = 9 Then
			pot_curWait = CRM_RETRY_WAIT
			Ret_Value = 0
		End If
		
		
		'�@�ACSV�Ǎ����g���C��
		strRet.Value = ""
		' === 20061102 === UPDATE S - ACE)Nagasawa INI�t�@�C���Ǎ��ݕύX
		'    lRet = GetPrivateProfileString("CRM", "Retry", "", strRet, Len(strRet), pin_strFileName)
		'    If lRet > 0 Then
		'        If IsNumeric(strRet) = True Then
		'            'ini�t�@�C������擾�ł��āA�����l�Ƃ��Đ�����
		'            pot_curRetry = LeftWid(strRet, lRet)
		'
		'        Else
		'            'ini�t�@�C������擾�ł������A���l�Ƃ��Đ������Ȃ�
		'            Ret_Value = 9
		'
		'        End If
		'
		'    Else
		'        'ini�t�@�C������擾�ł��Ȃ�
		'        Ret_Value = 9
		'
		'    End If
		
		intRet = CF_Get_IniInf("CRM", "Retry", strRet.Value)
		If intRet = 0 Then
			If IsNumeric(strRet.Value) = True Then
				'ini�t�@�C������擾�ł��āA�����l�Ƃ��Đ�����
				pot_curRetry = CF_Get_CCurString(strRet.Value)
			Else
				'ini�t�@�C������擾�ł������A���l�Ƃ��Đ������Ȃ�
				Ret_Value = 9
				
			End If
			
		Else
			'ini�t�@�C������擾�ł��Ȃ�
			Ret_Value = 9
			
		End If
		' === 20061102 === UPDATE E -
		
		'�@�@�i�ǂݍ��߂Ȃ��ꍇ�� AE_CONST.bas �̌Œ�l���g�p���A�G���[�Ƃ��Ȃ��j
		If Ret_Value = 9 Then
			pot_curRetry = CRM_RETRY_MAX
			Ret_Value = 0
		End If
		
		
		'�@�BCSV�t�@�C���p�X
		strRet.Value = ""
		' === 20061102 === UPDATE S - ACE)Nagasawa INI�t�@�C���Ǎ��ݕύX
		'    lRet = GetPrivateProfileString("CRM", "CSVPath", "", strRet, Len(strRet), pin_strFileName)
		'    If lRet > 0 Then
		'        pot_strCSVFilePath = LeftWid(strRet, lRet)
		'    Else
		'        'ini�t�@�C������擾�ł��Ȃ�
		'        Ret_Value = 9
		'    End If
		
		'�@�BCSV�t�@�C���p�X
		intRet = CF_Get_IniInf("CRM", "CSVPath", strRet.Value)
		If intRet = 0 Then
			pot_strCSVFilePath = strRet.Value
		Else
			'ini�t�@�C������擾�ł��Ȃ�
			Ret_Value = 9
		End If
		' === 20061102 === UPDATE E -
		
		CF_Get_INI_CRM = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Ctl_OpenCRMCsv
	'   �T�v�F  CRM�֘AINI�t�@�C���I�[�v������
	'   �����F  pin_intFileNo       : �t�@�C���ԍ�
	'           pin_strCSVFilePath�@: CSV̧���߽
	'           pin_curRetry  �@    : ��ײ��
	'           pin_curWait       �@: ��ײ�Ԋu
	'   �ߒl�F  0:����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_OpenCRMCsv(ByVal pin_intFileNo As Short, ByVal pin_strCSVFilePath As String, ByVal pin_curRetry As Decimal, ByVal pin_curWait As Decimal) As Boolean
		
		Dim bolOpen As Boolean
		Dim curRetryCnt As Decimal
		Dim curRetryMax As Decimal
		
		CF_Ctl_OpenCRMCsv = False
		
		'���g���C�񐔂̏����ݒ�
		curRetryMax = pin_curRetry
		'    If curRetryMax >= 10 Then
		'        curRetryMax = 10
		'    End If
		
		curRetryCnt = 0
		bolOpen = False
		'�t�@�C�����J�����A�ő�񐔂𒴂��ă��g���C����܂Ń��[�v
		Do Until bolOpen = True Or curRetryCnt > curRetryMax
			
			System.Windows.Forms.Application.DoEvents()
			
			'�㏑���֎~�A�ǋL���[�h�ŃI�[�v��
			On Error Resume Next
			FileOpen(pin_intFileNo, pin_strCSVFilePath, OpenMode.Append, , OpenShare.LockWrite)
			Select Case Err.Number
				Case 70
					'���Ƀt�@�C�����J����Ă���ꍇ�A���g���C
					'�i���g���C�Ԋu���̎��ԁA�ꎞ��~�B�������ŏI��������j
					If curRetryCnt < curRetryMax Then
						Call SSSMAIN0002.Sleep(pin_curWait * 1000)
					End If
					
				Case 0
					'����ɃI�[�v��
					bolOpen = True
					
				Case Else
					
			End Select
			
			curRetryCnt = curRetryCnt + 1
			
		Loop 
		
		CF_Ctl_OpenCRMCsv = bolOpen
		
	End Function
	' === 20060912 === INSERT E
	
	' === 20061013 === INSERT S - ACE)Nagasawa �����̓��͐����ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_URIKJN_Input
	'   �T�v�F  ���͔����`�F�b�N����
	'   �����F  pin_strJDNTRKB      : �󒍎���敪
	'           pin_strURIKJN     �@: ����
	'   �ߒl�F  0:����I��(�`�F�b�N�n�j�j�@1:�`�F�b�N�m�f  9:�ُ�I��
	'   ���l�F  �󒍎���敪�����͂��ꂽ���������͉\�l���ǂ������肵�܂�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_URIKJN_Input(ByVal pin_strJDNTRKB As String, ByVal pin_strURIKJN As String) As Short
		
		' === 20061030 === INSERT S - ACE)Nagasawa �����̃`�F�b�N�ύX
		Dim Mst_Inf As TYPE_DB_MEIMTA
		Dim intRet As Short
		' === 20061030 === INSERT E -
		
		CF_Chk_URIKJN_Input = 9
		
		' === 20061030 === UPDATE S - ACE)Nagasawa �����̃`�F�b�N�ύX
		'    Select Case pin_strJDNTRKB
		'        '�P�i�̏ꍇ
		'        Case gc_strJDNTRKB_TAN
		'            '�o�׊�ȊO�̓G���[
		'            If pin_strURIKJN <> gc_strURIKJN_SYK Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '�Z�b�g�A�b�v�̏ꍇ
		'        Case gc_strJDNTRKB_SET
		'            '�o�׊�ȊO�̓G���[
		'            If pin_strURIKJN <> gc_strURIKJN_SYK Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '�V�X�e���̏ꍇ
		'        Case gc_strJDNTRKB_SYS
		'            '�o�׊�A������A�H��������ȊO�̓G���[
		'            If pin_strURIKJN <> gc_strURIKJN_SYK _
		''            And pin_strURIKJN <> gc_strURIKJN_KNS _
		''            And pin_strURIKJN <> gc_strURIKJN_KOJ Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '�C���̏ꍇ
		'        Case gc_strJDNTRKB_SYR
		'            '������ȊO�̓G���[
		'            If pin_strURIKJN <> gc_strURIKJN_KNS Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '�ێ�̏ꍇ
		'        Case gc_strJDNTRKB_HSY
		'            '�𖱊�����ȊO�̓G���[
		'            If pin_strURIKJN <> gc_strURIKJN_EKM Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '�ݏo�̏ꍇ
		'        Case gc_strJDNTRKB_KAS
		'            '����������ȊO�̓G���[
		'            If pin_strURIKJN <> gc_strURIKJN_KNS Then
		'                CF_Chk_URIKJN_Input = 1
		'                Exit Function
		'            End If
		'
		'        '��L�ȊO
		'        Case Else
		'            CF_Chk_URIKJN_Input = 1
		'            Exit Function
		'
		'    End Select
		'
		'    CF_Chk_URIKJN_Input = 0
		
		Call DB_MEIMTA_Clear(Mst_Inf)
		
		'���̃}�X�^����
		CF_Chk_URIKJN_Input = 1
		intRet = DSPMEIM_SEARCH(gc_strKEYCD_URIKJN_Chk, pin_strJDNTRKB, Mst_Inf, pin_strURIKJN)
		If intRet = 0 Then
			If Mst_Inf.DATKB = gc_strDATKB_USE Then
				CF_Chk_URIKJN_Input = 0
			End If
		End If
		' === 20061030 === UPDATE E -
		
	End Function
	' === 20061013 === INSERT E -
	
	' === 20061026 === INSERT S - ACE)Nagasawa �q��`�[�w��敪�ύX
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_DspTOKDNKB
	'   �T�v�F  ��ʕ\���p�q��`�[�w��敪�擾����
	'   �����F  pin_strTOKDNKB      : �q��`�[�w��敪
	'   �ߒl�F  ��ʕ\���p�q��`�[�w��敪(vbChecked/vbUnchecked)
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_DspTOKDNKB(ByVal pin_strTOKDNKB As String) As Short
		
		If pin_strTOKDNKB = gc_strTOKDNKB_NML Then
			'"�ʏ�"�̏ꍇ�A�`�F�b�NOFF
			CF_Get_DspTOKDNKB = System.Windows.Forms.CheckState.Unchecked
		Else
			'"�ʏ�"�ȊO�̏ꍇ�A�`�F�b�NON
			CF_Get_DspTOKDNKB = System.Windows.Forms.CheckState.Checked
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_UpdTOKDNKB
	'   �T�v�F  �󒍃g�����X�V�p�q��`�[�w��敪�擾����
	'   �����F  pin_intTOKDNKB              : ��ʂ̋q��`�[�w��敪
	'   �����F  pin_strTOKDNKB_TOKMTA       : ���Ӑ�}�X�^�̋q��`�[�w��敪
	'   �ߒl�F  �󒍃g�����s�i�p�q��`�[�w��敪
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_UpdTOKDNKB(ByVal pin_intTOKDNKB As Short, ByVal pin_strTOKDNKB_TOKMTA As String) As String
		
		If pin_intTOKDNKB = System.Windows.Forms.CheckState.Unchecked Then
			'�`�F�b�NOFF�̏ꍇ�A"�ʏ�"
			CF_Get_UpdTOKDNKB = gc_strTOKDNKB_NML
		Else
			'�`�F�b�NON�̏ꍇ
			If pin_strTOKDNKB_TOKMTA = gc_strTOKDNKB_NML Then
				'���Ӑ�}�X�^�̋q��w��`�[�敪��"�ʏ�"�̏ꍇ�͎w��
				CF_Get_UpdTOKDNKB = gc_strTOKDNKB_STI
			Else
				'���Ӑ�}�X�^�̋q��`�[�w��敪�g�p
				CF_Get_UpdTOKDNKB = pin_strTOKDNKB_TOKMTA
			End If
		End If
		
	End Function
	' === 20061026 === INSERT E -
	
	' === 20061028 === INSERT S - ACE)Nagasawa FAX�ԍ��`�F�b�N�̒ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_FAXNO
	'   �T�v�F  FAX�ԍ��`�F�b�N����
	'   �����F  pin_strFAXNO       : �`�F�b�N�Ώ�FAX�ԍ�
	'           pin_intKETA        : FAX�ԍ����͉\����
	'           pin_intFAX_HAIHUN  : FAX�ԍ��n�C�t����
	'           pin_intFAX_LSTNUM  : FAX�ԍ��ŏI���l��������
	'           pin_strFRNKB       : �C�O����敪
	'   �ߒl�F  0 : �`�F�b�NOK   9 : �`�F�b�NNG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_FAXNO(ByVal pin_strFAXNO As String, ByVal pin_intKETA As Short, ByVal pin_intFAX_HAIHUN As Short, ByVal pin_intFAX_LSTNUM As Short, ByVal pin_strFRNKB As String) As Short
		
		Dim intHaihun As Short
		Dim intCnt As Short
		Dim intLstHaihun As Short '�Ō�̃n�C�t���ʒu
		
		CF_Chk_FAXNO = 9
		
		'�t�@�b�N�X�ԍ��̏����`�F�b�N��ǉ�
		If pin_strFRNKB <> gc_strFRNKB_FRN Then
			
			'�󔒂�OK�Ƃ���
			If Trim(pin_strFAXNO) = "" Then
				CF_Chk_FAXNO = 0
				Exit Function
			End If
			
			'�n�C�t�����擪�̏ꍇ�̓G���[
			If Mid(pin_strFAXNO, 1, 1) = "-" Then
				CF_Chk_FAXNO = 10
				Exit Function
			End If
			
			'�n�C�t�����Ō�̏ꍇ�̓G���[
			If Right(pin_strFAXNO, 1) = "-" Then
				CF_Chk_FAXNO = 30
				Exit Function
			End If
			
			'�n�C�t�����A�����đ��݂���ꍇ�G���[
			If InStr(pin_strFAXNO, "--") > 0 Then
				CF_Chk_FAXNO = 20
				Exit Function
			End If
			
			'�����`�F�b�N
			If Len(pin_strFAXNO) > pin_intKETA Then
				CF_Chk_FAXNO = 40
				Exit Function
			End If
			
			'�n�C�t�����`�F�b�N
			intHaihun = 0
			intLstHaihun = 0
			For intCnt = 1 To Len(pin_strFAXNO)
				If Mid(pin_strFAXNO, intCnt, 1) = "-" Then
					intHaihun = intHaihun + 1
					intLstHaihun = intCnt
				End If
			Next 
			
			If intHaihun <> pin_intFAX_HAIHUN Then
				CF_Chk_FAXNO = 50
				Exit Function
			End If
			
			'�ŏI���̌����`�F�b�N
			'''' UPD 2012/03/07  FKS) T.Yamamoto    Start    �A���[��FC12030701
			'        If Len(Mid(Trim(pin_strFAXNO), intLstHaihun + 1)) <> pin_intFAX_LSTNUM Then
			If Len(Mid(Trim(pin_strFAXNO), intLstHaihun + 1)) > pin_intFAX_LSTNUM Then
				'''' UPD 2012/03/07  FKS) T.Yamamoto    End
				CF_Chk_FAXNO = 60
				Exit Function
			End If
			
		End If
		
		CF_Chk_FAXNO = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_CLMDL_FRN
	'   �T�v�F  ���ތ^���擾�����i�C�O�j
	'   �����F  pin_strJDNTRKB     : �󒍎���敪
	'           pin_strMDLCL       : ���i�}�X�^.�W�v���ށi�󒍃g����.���ތ^���j
	'           pin_strCLMDL_DSP   : ���.���ތ^��
	'   �ߒl�F  �擾���ꂽ���ތ^��
	'   ���l�F�@�󒍎���敪�ɂ��󒍃g�����ɕҏW���镪�ތ^���̒l�����肵�܂�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_CLMDL_FRN(ByVal pin_strJDNTRKB As String, ByVal pin_strMDLCL As String, ByVal pin_strCLMDL_DSP As String) As String
		
		Dim Rtn_Value As String
		
		CF_Get_CLMDL_FRN = ""
		Rtn_Value = ""
		
		Select Case pin_strJDNTRKB
			'�P�i
			Case gc_strJDNTRKB_TAN
				Rtn_Value = pin_strMDLCL
				
				'�Z�b�g�A�b�v
			Case gc_strJDNTRKB_SET
				
				'�V�X�e��
			Case gc_strJDNTRKB_SYS
				
				'�C��
			Case gc_strJDNTRKB_SYR
				' === 20061119 === INSERT S - ACE)Nagasawa
				'            Rtn_Value = pin_strCLMDL_DSP
				Rtn_Value = pin_strMDLCL
				' === 20061119 === INSERT E -
				
				'�ێ�
			Case gc_strJDNTRKB_HSY
				' === 20061119 === INSERT S - ACE)Nagasawa
				'            Rtn_Value = pin_strCLMDL_DSP
				Rtn_Value = pin_strMDLCL
				' === 20061119 === INSERT E -
				
				'�ݏo
			Case gc_strJDNTRKB_KAS
				Rtn_Value = pin_strMDLCL
				
			Case Else
		End Select
		
		CF_Get_CLMDL_FRN = Rtn_Value
		
	End Function
	' === 20061028 === INSERT E -
	
	' === 20061031 === INSERT S - ACE)Nagasawa �r������̒ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Execute_PLSQL_EXCTBZ
	'   �T�v�F  PL/SQL���s����(�r�����䏈��)
	'   �����F�@Pin_strPRCCASE   : �����P�[�X(C:�`�F�b�N W:�������� D:�폜����)
	'           Pot_strMsg       : �G���[���e
	'   �ߒl�F�@0 : ���� 1 : �r���Ɩ����� 9 : �ُ�
	'   ���l�F  �r������pPL/SQL(PRC_EXCTBZ)�����s����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_EXCTBZ(ByVal Pin_strPRCCASE As String, ByRef pot_strMsg As String) As Short
		
		Dim strSQL As String 'SQL��
		Dim strPara1 As String '���Ұ�1(�S���҃R�[�h)
		Dim strPara2 As String '���Ұ�2(�N���C�A���gID)
		Dim strPara3 As String '���Ұ�3(�����P�[�X)
		Dim strPara4 As String '���Ұ�4(�Ɩ��R�[�h(PGID))
		Dim lngPara5 As Integer '���Ұ�5(���A����)
		Dim lngPara6 As Integer '���Ұ�6(�װ����)
		Dim strPara7 As String '���Ұ�7(�װ���e)
		'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim param(7) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
		Dim bolRet As Boolean
		
		AE_Execute_PLSQL_EXCTBZ = 9
		
		'��n���ϐ������ݒ�
		strPara1 = Inp_Inf.InpTanCd
		strPara2 = SSS_CLTID.Value
		strPara3 = Pin_strPRCCASE
		strPara4 = SSS_PrgId
		lngPara5 = 0
		lngPara6 = 0
		strPara7 = ""
		
		pot_strMsg = ""
		
		'�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P5", lngPara5, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P6", lngPara6, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P7", strPara7, ORAPARM_OUTPUT)
		
		'�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7) = gv_Odb_USR1.Parameters("P7")
		
		'�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7).serverType = ORATYPE_VARCHAR2
		
		'PL/SQL�Ăяo��SQL
		strSQL = "BEGIN PRC_EXCTBZ(:P1,:P2,:P3,:P4,:P5,:P6,:P7); End;"
		
		'DB�A�N�Z�X
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_Execute_PLSQL_EXCTBZ_END
		End If
		
		'** �߂�l�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara5 = param(5).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara6 = param(6).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: Null/IsNull() �̎g�p��������܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' ���N���b�N���Ă��������B
		If IsDbNull(param(7).Value) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strPara7 = param(7).Value
			pot_strMsg = strPara7
		End If
		
		'�G���[���ݒ�
		gv_Int_OraErr = lngPara6
		gv_Str_OraErrText = strPara7
		
		AE_Execute_PLSQL_EXCTBZ = lngPara5
		
AE_Execute_PLSQL_EXCTBZ_END: 
		'** �p�����^����
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P7")
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_Lock_EXCTBZ
	'   �T�v�F�@�r�����䏈��
	'   �����F�@Pot_strMsg       : �G���[���e
	'   �ߒl�F�@0 : ���� 1 : �r���Ɩ����� 9 : �ُ�
	'   ���l�F  �r������i�r���`�F�b�N���r���e�[�u���ւ̏������݁j���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_Lock_EXCTBZ(ByRef pot_strMsg As String) As Short
		
		Dim intRet As Short
		Dim strMsg As String
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Chk_Lock_EXCTBZ_Err
		
		CF_Chk_Lock_EXCTBZ = 9
		pot_strMsg = ""
		bolTrn = False
		
		'�r���`�F�b�N
		intRet = AE_Execute_PLSQL_EXCTBZ("C", strMsg)
		If intRet <> 0 Then
			'�r���G���[
			pot_strMsg = strMsg
			CF_Chk_Lock_EXCTBZ = intRet
			GoTo CF_Chk_Lock_EXCTBZ_Err
		End If
		
		'�g�����U�N�V�����̊J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTrn = True
		
		'�r������
		intRet = AE_Execute_PLSQL_EXCTBZ("W", strMsg)
		If intRet <> 0 Then
			'�r���G���[
			pot_strMsg = strMsg
			CF_Chk_Lock_EXCTBZ = intRet
			GoTo CF_Chk_Lock_EXCTBZ_Err
		End If
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTrn = False
		
		CF_Chk_Lock_EXCTBZ = 0
		
		Exit Function
		
CF_Chk_Lock_EXCTBZ_Err: 
		
		'���[���o�b�N
		If bolTrn = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Unlock_EXCTBZ
	'   �T�v�F�@�r�������������
	'   �����F�@Pot_strMsg       : �G���[���e
	'   �ߒl�F�@0 : ����  9 : �ُ�
	'   ���l�F  �r������i�r���e�[�u������̍폜�j���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Unlock_EXCTBZ(ByRef pot_strMsg As String) As Short
		
		Dim intRet As Short
		Dim strMsg As String
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Unlock_EXCTBZ_Err
		
		CF_Unlock_EXCTBZ = 9
		pot_strMsg = ""
		bolTrn = False
		
		'�g�����U�N�V�����̊J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTrn = True
		
		'�r���������
		intRet = AE_Execute_PLSQL_EXCTBZ("D", strMsg)
		If intRet <> 0 Then
			'�r���G���[
			pot_strMsg = strMsg
			CF_Unlock_EXCTBZ = intRet
			GoTo CF_Unlock_EXCTBZ_Err
		End If
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTrn = False
		
		CF_Unlock_EXCTBZ = 0
		
		Exit Function
		
CF_Unlock_EXCTBZ_Err: 
		
		'���[���o�b�N
		If bolTrn = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_IniInf
	'   �T�v�F  Ini�t�@�C���Ǎ��ݏ����i�v���O�����ŗL�j
	'   �����F  pin_strSection :
	'   �ߒl�F  0 : ���� 9 : �ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_IniInf(ByRef pin_strSection As String, ByRef pin_strKey As String, ByRef pot_strValue As String) As Short
		
		Dim Wk As New VB6.FixedLengthString(256)
		Dim lngRet As Integer
		
		CF_Get_IniInf = 9
		
		pot_strValue = ""
		
		'Ini�t�@�C���Ǎ���
		lngRet = GetPrivateProfileString(pin_strSection, pin_strKey, "", Wk.Value, Len(Wk.Value), My.Application.Info.DirectoryPath & "\" & SSS_PrgId & ".ini")
		If lngRet > 0 Then
			pot_strValue = CF_Ctr_AnsiLeftB(Wk.Value, lngRet)
			pot_strValue = Trim(pot_strValue)
		Else
			Exit Function
		End If
		
		CF_Get_IniInf = 0
		
	End Function
	' === 20061031 === INSERT E -
	
	' === 20130416 === INSERT S - FWEST)Koroyasu �r������̒ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_EXCTBZ
	'   �T�v�F�@�r���`�F�b�N����
	'   �����F  pm_All  �F��ʏ��
	'       �F�@pin_strJDNNO    �F�Ɩ��R�[�h
	'   �ߒl�F�@0 : ���� 1 : �r���Ɩ����� 9 : �ُ�
	'   ���l�F  �r������i�r���`�F�b�N�j���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20130530 === UPDATE S - FWEST)Koroyasu
	'Public Function CF_Chk_EXCTBZ(pm_All As Cls_All) As Integer
	Public Function CF_Chk_EXCTBZ(ByRef pm_All As Cls_All, ByRef pin_strGYMCD As String) As Short
		' === 20130530 === UPDATE E
		
		Dim strSQL As String
		Dim bolRet As Boolean
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		
		On Error GoTo CF_Chk_EXCTBZ_Err
		
		CF_Chk_EXCTBZ = 9
		
		'�r���`�F�b�N
		'SQL�ҏW
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "  FROM "
		strSQL = strSQL & "        EXCTBZ " '�r���e�[�u��
		strSQL = strSQL & "  WHERE "
		' === 20130530 === UPDATE S - FWEST)Koroyasu
		'    strSQL = strSQL & "        GYMCD   = '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_JDNNO.Tag).Detail.Dsp_Value, 6) & "'"    '�󒍔ԍ�
		strSQL = strSQL & "        GYMCD   = '" & pin_strGYMCD & "'" '�Ɩ��R�[�h
		' === 20130530 === UPDATE E
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		If bolRet = False Then
			GoTo CF_Chk_EXCTBZ_Err
		End If
		
		'�������ʂ�0���̏ꍇ
		If CF_Ora_RecordCount(Usr_Ody) = 0 Then
			'�r������i�r���e�[�u���֏������݁j
			' === 20130530 === UPDATE S - FWEST)Koroyasu
			'        bolRet = CF_Execute_EXCTBZ(pm_All)
			bolRet = CF_Execute_EXCTBZ(pm_All, pin_strGYMCD)
			' === 20130530 === UPDATE E
			If bolRet = False Then
				GoTo CF_Chk_EXCTBZ_Err
			End If
			CF_Chk_EXCTBZ = 0
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(CF_Ora_GetDyn(Usr_Ody, "CLTID", "")) = Inp_Inf.InpCLIID And Trim(CF_Ora_GetDyn(Usr_Ody, "INTLCD", "")) = SSS_PrgId Then
				CF_Chk_EXCTBZ = 0
			Else
				'�������ʂ����݂����ꍇ
				CF_Chk_EXCTBZ = 1
				'�����I��
				Exit Function
			End If
		End If
		
CF_Chk_EXCTBZ_Err: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Execute_EXCTBZ
	'   �T�v�F  �r�����䏈��
	'   �����F  pm_All : ��ʏ��
	'       �F�@pin_strGYMCD�F�Ɩ��R�[�h
	'   �ߒl�F�@True : ���� False : �ُ�
	'   ���l�F  �r����������s����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20130530 === UPDATE S - FWEST)Koroyasu
	'Public Function CF_Execute_EXCTBZ(pm_All As Cls_All) As Boolean
	Public Function CF_Execute_EXCTBZ(ByRef pm_All As Cls_All, ByRef pin_strGYMCD As String) As Boolean
		' === 20130530 === UPDATE E
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Execute_EXCTBZ_Err
		
		CF_Execute_EXCTBZ = False
		
		'�g�����U�N�V�����̊J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTrn = True
		
		'�r������
		'SQL�ҏW
		strSQL = ""
		strSQL = strSQL & " INSERT INTO "
		strSQL = strSQL & "        EXCTBZ " '�r���e�[�u��
		strSQL = strSQL & "      ( CLTID " '�N���C�A���gID
		strSQL = strSQL & "      , GYMCD " '�󒍔ԍ�
		strSQL = strSQL & "      , LCKTM " '�^�C���X�^���v
		strSQL = strSQL & "      , INTLCD " '�v���O����ID
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & Inp_Inf.InpCLIID & "' " '�N���C�A���gID
		' === 20130530 === UPDATE S - FWEST)Koroyasu
		'    strSQL = strSQL & "      , '" & CF_Ora_String(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_JDNNO.Tag).Detail.Dsp_Value, 6) & "' "   '�󒍔ԍ�
		strSQL = strSQL & "      , '" & pin_strGYMCD & "' " '�Ɩ��R�[�h
		' === 20130530 === UPDATE E
		strSQL = strSQL & "      , '" & GV_SysTime & "' " '�^�C���X�^���v
		strSQL = strSQL & "      , '" & SSS_PrgId & "'" '�v���O����ID
		strSQL = strSQL & "      ) "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_Execute_EXCTBZ_Err
		End If
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTrn = False
		
		CF_Execute_EXCTBZ = True
		
CF_Execute_EXCTBZ_Err: 
		
		'���[���o�b�N
		If bolTrn = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Unlock_EXCTBZ2
	'   �T�v�F�@�r�������������
	'   �����F  pm_All : ��ʏ��
	'   �ߒl�F�@True : ����  False : �ُ�
	'   ���l�F  �r������i�r���e�[�u������̍폜�j���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Unlock_EXCTBZ2() As Boolean
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim bolTrn As Boolean
		
		On Error GoTo CF_Unlock_EXCTBZ2_Err
		
		CF_Unlock_EXCTBZ2 = False
		
		'�g�����U�N�V�����̊J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTrn = True
		
		'�r���������
		'SQL�ҏW
		strSQL = ""
		strSQL = strSQL & " DELETE FROM "
		strSQL = strSQL & "        EXCTBZ " '�r���e�[�u��
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        CLTID    = '" & Inp_Inf.InpCLIID & "' " '�N���C�A���gID
		strSQL = strSQL & "    AND INTLCD   = '" & SSS_PrgId & "' " '�v���O����ID
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_Unlock_EXCTBZ2_Err
		End If
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTrn = False
		
		CF_Unlock_EXCTBZ2 = True
		
		Exit Function
		
CF_Unlock_EXCTBZ2_Err: 
		
		'���[���o�b�N
		If bolTrn = True Then
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
	End Function
	' === 20130416 === INSERT E -
	
	' === 20061206 === INSERT S - ACE)Nagasawa ���i��ԃ`�F�b�N�̕ύX
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_HINCD
	'   �T�v�F  ���i�R�[�h��ԃ`�F�b�N����
	'   �����F  pm_Mst_Inf : ���i�}�X�^�p�\����
	'   �ߒl�F  0  : ����
	'           10 : �󒍒�~
	'           20 : ���Y�I��(��z�I��)
	'           30 : �o�ג�~
	'           40 : �o�׏�����
	'   ���l�F�@���͂��ꂽ���i�R�[�h�̏�Ԃ̃`�F�b�N���s���܂�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_HINCD(ByRef pm_Mst_Inf As TYPE_DB_HINMTA) As Short
		
		CF_Chk_HINCD = 0
		
		'�o�׏������`�F�b�N
		If pm_Mst_Inf.ORTSTPKB = gc_strORTSTPKB_PRE Then
			CF_Chk_HINCD = 40
		End If
		
		'�o�ג�~�i�`�F�b�N
		If pm_Mst_Inf.ORTSTPKB = gc_strORTSTPKB_STOP Then
			CF_Chk_HINCD = 30
		End If
		
		'���Y�I���i�`�F�b�N
		If pm_Mst_Inf.PRDENDKB = gc_strPRDENDKB_END Then
			CF_Chk_HINCD = 20
		End If
		
		'�󒍒�~�i�`�F�b�N
		If pm_Mst_Inf.JODSTPKB = gc_strJODSTPKB_STOP Then
			CF_Chk_HINCD = 10
		End If
		
	End Function
	' === 20061206 === INSERT E -
	
	' === 20061216 === INSERT S - ACE)Nagasawa ���i�R�[�h�̓��͐����ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_HINCD2
	'   �T�v�F  ���i�R�[�h���i�敪�`�F�b�N����
	'   �����F  pin_strHINKB   : ���i�敪
	'           pin_strJDNTRKB : �󒍎���敪
	'   �ߒl�F  0 : ����@9 : �G���[
	'   ���l�F�@���͂��ꂽ���i�R�[�h�̏�Ԃ̃`�F�b�N���s���܂�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_HINCD2(ByRef pin_strHINKB As String, ByRef pin_strJDNTRKB As String) As Short
		
		CF_Chk_HINCD2 = 9
		
		'�󒍎���敪�ɂ�蔻��
		Select Case Trim(pin_strJDNTRKB)
			'�P�i�̏ꍇ
			Case gc_strJDNTRKB_TAN
				
				'���i�敪�ɂ�蔻�f
				Select Case Trim(pin_strHINKB)
					'���i�̏ꍇ
					Case gc_strHINKB_SEIHIN
						CF_Chk_HINCD2 = 0
						'���i�̏ꍇ
					Case gc_strHINKB_SYOHIN
						CF_Chk_HINCD2 = 0
						
					Case Else
				End Select
				
				'�Z�b�g�A�b�v�̏ꍇ
			Case gc_strJDNTRKB_SET
				'�S�Ăn�j
				CF_Chk_HINCD2 = 0
				
				'�V�X�e���̏ꍇ
			Case gc_strJDNTRKB_SYS
				'�S�Ăn�j
				CF_Chk_HINCD2 = 0
				
				'�C���̏ꍇ
			Case gc_strJDNTRKB_SYR
				'MOD 20141219 START
				'            '�S�Ăn�j
				'            CF_Chk_HINCD2 = 0
				
				'���i�敪�ɂ�蔻�f
				Select Case Trim(pin_strHINKB)
					'���̑��̏ꍇ
					Case gc_strHINKB_ELSE
						CF_Chk_HINCD2 = 0
						
					Case Else
				End Select
				'MOD 20141219 END
				
				'�ێ�̏ꍇ
			Case gc_strJDNTRKB_HSY
				'�S�Ăn�j
				CF_Chk_HINCD2 = 0
				
				'�ݏo�̏ꍇ
			Case gc_strJDNTRKB_KAS
				' === 20060112 === UPDATE S - ACE)Nagasawa ���i�R�[�h�̓��͐����ǉ�
				'            '�S�Ăn�j
				'            CF_Chk_HINCD2 = 0
				
				'���i�敪�ɂ�蔻�f
				Select Case Trim(pin_strHINKB)
					'���i�̏ꍇ
					Case gc_strHINKB_SEIHIN
						CF_Chk_HINCD2 = 0
						'���i�̏ꍇ
					Case gc_strHINKB_SYOHIN
						CF_Chk_HINCD2 = 0
						
					Case Else
				End Select
				' === 20060112 === UPDATE E -
				
		End Select
		
	End Function
	' === 20061216 === INSERT E -
	
	
	' === 20061208 === INSERT S - ACE)Nagasawa �[���񓚂̔��f�͑�\��ЃR�[�h��EDI�敪����s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_EDIKBN
	'   �T�v�F  �[���񓚎��s���菈��
	'   �����F  pin_strTGRPCD   : ��\��ЃR�[�h
	'           pin_strROKCD    : ���Ӑ�R�[�h
	'   �ߒl�F  True : �[���񓚂���@False : �[���񓚂��Ȃ�
	'   ���l�F�@�[���񓚂����s���邩�ǂ����̔�����s���܂��B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_EDIKBN(ByRef pin_strTGRPCD As String, ByRef pin_strTOKCD As String) As Boolean
		
		Dim strTGRPCD As String
		Dim Mst_Inf_TOK As TYPE_DB_TOKMTA
		Dim Mst_Inf_TGRP As TYPE_DB_TOKMTA
		Dim intRet_TOK As Short
		Dim intRet_TGRP As Short
		
		CF_Chk_EDIKBN = False
		
		'��\��ЃR�[�h���Ȃ��ꍇ�͓��Ӑ�R�[�h�Ŕ���
		If Trim(pin_strTGRPCD) = "" Then
			strTGRPCD = pin_strTOKCD
		Else
			strTGRPCD = pin_strTGRPCD
		End If
		
		'�\���̃N���A
		Call DB_TOKMTA_Clear(Mst_Inf_TGRP)
		Call DB_TOKMTA_Clear(Mst_Inf_TOK)
		
		'���Ӑ�}�X�^����
		intRet_TGRP = DSPTOKCD_SEARCH(strTGRPCD, Mst_Inf_TGRP)
		intRet_TOK = DSPTOKCD_SEARCH(pin_strTOKCD, Mst_Inf_TOK)
		
		'EDI�敪��"VAN"�ŁAEDI�敪�i�[�����j��"����"�̏ꍇ�A�[���񓚏������s
		If intRet_TGRP = 0 And Mst_Inf_TGRP.DATKB = gc_strDATKB_USE Then
			If Mst_Inf_TGRP.EDIKB = gc_strEDIKB_VAN And Mst_Inf_TGRP.EDIKBN = gc_strEDIKB_OK Then
				CF_Chk_EDIKBN = True
			End If
		Else
			If intRet_TOK = 0 And Mst_Inf_TOK.DATKB = gc_strDATKB_USE Then
				If Mst_Inf_TOK.EDIKB = gc_strEDIKB_VAN And Mst_Inf_TOK.EDIKBN = gc_strEDIKB_OK Then
					CF_Chk_EDIKBN = True
				End If
			End If
		End If
		
	End Function
	' === 20061208 === INSERT E -
	
	' === 20061213 === INSERT S - ACE)Nagasawa ���ތ^���̃`�F�b�N�ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_CLMDL
	'   �T�v�F  ���ތ^���`�F�b�N����
	'   �����F  pin_strCLMDL    : �`�F�b�N�Ώۋ@�핪��
	'           pin_strJDNDT    : ����i���.�󒍓��j
	'           pin_strJDNTRKB  : �󒍎���敪
	'           pin_strCMPKTCD  : �R���s���[�^�^��
	'   �ߒl�F  0 : �`�F�b�NOK�@9 : �`�F�b�NNG
	'   ���l�F�@����Ɏg�p�ł���@�핪�ނ��ǂ����𔻒肵�܂�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20070207 === UPDATE S - ACE)Nagasawa �V�X�e���󒍂ŋ@��󒍂���͉Ƃ���
	' === 20061228 === UPDATE S - ACE)Nagasawa ���ތ^���̃`�F�b�N�ύX
	'Public Function CF_Chk_CLMDL(pin_strCLMDL As String, _
	''                             pin_strJDNDT As String) As Integer
	'Public Function CF_Chk_CLMDL(pin_strCLMDL As String, _
	''                             pin_strJDNDT As String, _
	''                             pin_strJDNTRKB As String) As Integer
	'' === 20061228 === UPDATE E -
	Public Function CF_Chk_CLMDL(ByRef pin_strCLMDL As String, ByRef pin_strJDNDT As String, ByRef pin_strJDNTRKB As String, Optional ByRef pin_strCMPKTCD As String = " ") As Short
		' === 20070207 === UPDATE E -
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody_KATA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody_KATA As U_Ody
		Dim strRtn As String
		
		On Error GoTo Err_CF_Chk_CLMDL
		
		CF_Chk_CLMDL = 9
		strRtn = ""
		
		' === 20061228 === UPDATE S - ACE)Nagasawa ���ތ^���̃`�F�b�N�ύX
		'    If Trim(pin_strCLMDL) = "" Or Trim(pin_strJDNDT) = "" Then
		If Trim(pin_strCLMDL) = "" Or Trim(pin_strJDNDT) = "" Or Trim(pin_strJDNTRKB) = "" Then
			' === 20061228 === UPDATE E -
			CF_Chk_CLMDL = 0
			Exit Function
		End If
		
		'���ތ^���`�F�b�N�֐��Ăяo��
		' === 20070207 === UPDATE S - ACE)Nagasawa �V�X�e���󒍂ŋ@��󒍂���͉Ƃ���
		'    strSQL = ""
		'    strSQL = strSQL & " SELECT "
		'' === 20061228 === UPDATE S - ACE)Nagasawa ���ތ^���̃`�F�b�N�ύX
		''    strSQL = strSQL & "        GET_PCODE_KATA('" & CF_Ora_Sgl(pin_strCLMDL) & "' "
		''    strSQL = strSQL & "                      ,'" & CF_Ora_Sgl(pin_strJDNDT) & "') AS RTN "
		'    strSQL = strSQL & "        CHECK_KATA('" & CF_Ora_Sgl(pin_strCLMDL) & "' "
		'    strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNDT) & "' "
		'    strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNTRKB) & "') AS RTN "
		'' === 20061228 === UPDATE E -
		'    strSQL = strSQL & "   FROM DUAL "
		
		If Trim(pin_strJDNTRKB) = gc_strJDNTRKB_SYS Then
			'�V�X�e���󒍂̏ꍇ�V�X�e���p���ތ^���`�F�b�N
			strSQL = ""
			strSQL = strSQL & " SELECT "
			strSQL = strSQL & "        CHECK_KATA_SYS('" & CF_Ora_Sgl(pin_strCLMDL) & "' "
			strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNDT) & "' "
			strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNTRKB) & "'"
			strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strCMPKTCD) & "') AS RTN "
			strSQL = strSQL & "   FROM DUAL "
		Else
			'�V�X�e���󒍈ȊO�̏ꍇ�͒ʏ�̕��ތ^���`�F�b�N
			strSQL = ""
			strSQL = strSQL & " SELECT "
			strSQL = strSQL & "        CHECK_KATA('" & CF_Ora_Sgl(pin_strCLMDL) & "' "
			strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNDT) & "' "
			strSQL = strSQL & "                  ,'" & CF_Ora_Sgl(pin_strJDNTRKB) & "') AS RTN "
			strSQL = strSQL & "   FROM DUAL "
		End If
		' === 20070207 === UPDATE E -
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_KATA, strSQL)
		
		'���e�擾
		If CF_Ora_EOF(Usr_Ody_KATA) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strRtn = CF_Ora_GetDyn(Usr_Ody_KATA, "RTN", "")
		End If
		
		If Trim(strRtn) <> "" Then
			CF_Chk_CLMDL = 0
		End If
		
End_CF_Chk_CLMDL: 
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody_KATA)
		
		Exit Function
		
Err_CF_Chk_CLMDL: 
		GoTo End_CF_Chk_CLMDL
		
	End Function
	' === 20061213 === INSERT E -
	
	' === 20061217 === INSERT S - ACE)Nagasawa ��������t�@�C���̍X�V���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_DTLTRA_Update_MainJDN
	'   �T�v�F  ��������t�@�C���X�V(���C������)
	'   �����F�@pm_strMotoDatNo  : �`�[�Ǘ��ԍ�(��)
	'           pm_strDatNo      : �`�[�Ǘ��ԍ�(�V)
	'           pm_strErrCd      : �X�V�ُ�G���[�R�[�h
	'           pm_All            : ��ʏ��
	'   �ߒl�F�@0:����  9:�ُ�
	'   ���l�F  �󒍗p
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_DTLTRA_Update_MainJDN(ByVal pm_strMotoDatNo As String, ByVal pm_strDATNO As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		
		Dim intCnt As Short
		Dim intRet As Short
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim strJDNNO_NEW As String
		Dim strLINNO_NEW As String
		Dim strODNYTDT_NEW As String
		Dim strJDNNO_OLD As String
		Dim strLINNO_OLD As String
		Dim strODNYTDT_OLD As String
		
		On Error GoTo CF_DTLTRA_Update_MainJDN_Err
		CF_DTLTRA_Update_MainJDN = 9
		
		'�r�p�k�ҏW
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        NEW.JDNNO             AS JDNNO_NEW " '�󒍔ԍ��i�V�j
		strSQL = strSQL & "      , NVL(NEW.LINNO, '000') AS LINNO_NEW " '�s�ԍ��i�V�j
		strSQL = strSQL & "      , NEW.ODNYTDT           AS ODNYTDT_NEW " '�o�ח\����i�V�j
		strSQL = strSQL & "      , OLD.JDNNO             AS JDNNO_OLD " '�󒍔ԍ��i���j
		strSQL = strSQL & "      , OLD.LINNO             AS LINNO_OLD " '�s�ԍ��i���j
		strSQL = strSQL & "      , OLD.ODNYTDT           AS ODNYTDT_OLD " '�o�ח\����i���j
		strSQL = strSQL & "   FROM "
		strSQL = strSQL & "        JDNTRA NEW "
		strSQL = strSQL & "      , JDNTRA OLD "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        OLD.JDNNO     = NEW.JDNNO (+) "
		strSQL = strSQL & "    AND OLD.RECNO     = NEW.RECNO (+) "
		strSQL = strSQL & "    AND OLD.DATNO     = '" & CF_Ora_String(pm_strMotoDatNo, 10) & "' "
		strSQL = strSQL & "    AND NEW.DATNO (+) = '" & CF_Ora_String(pm_strDATNO, 10) & "' "
		strSQL = strSQL & "  ORDER BY "
		strSQL = strSQL & "        LINNO_NEW ASC "
		strSQL = strSQL & "      , LINNO_OLD ASC "
		
		'DB�A�N�Z�X
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		'�擾�f�[�^����������t�@�C���̍X�V���s��
		Do Until CF_Ora_EOF(Usr_Ody) = True
			'�f�[�^�擾
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strJDNNO_NEW = Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO_NEW", "")) '�󒍔ԍ��i�V�j
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strLINNO_NEW = Trim(CF_Ora_GetDyn(Usr_Ody, "LINNO_NEW", "")) '�s�ԍ��i�V�j
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strODNYTDT_NEW = Trim(CF_Ora_GetDyn(Usr_Ody, "ODNYTDT_NEW", "")) '�o�ח\����i�V�j
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strJDNNO_OLD = Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO_OLD", "")) '�󒍔ԍ��i���j
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strLINNO_OLD = Trim(CF_Ora_GetDyn(Usr_Ody, "LINNO_OLD", "")) '�s�ԍ��i���j
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strODNYTDT_OLD = Trim(CF_Ora_GetDyn(Usr_Ody, "ODNYTDT_OLD", "")) '�o�ח\����i���j
			
			Select Case True
				'�폜���ꂽ����
				Case strLINNO_NEW = "000"
					'��������t�@�C���폜
					' === 20070126 === UPDATE S - ACE)Nagasawa
					'                intRet = CF_DTLTRA_Delete(strJDNNO_OLD, _
					''                                          "", _
					''                                          strLINNO_OLD, _
					''                                          pm_strErrCd, _
					''                                          pm_All)
					intRet = CF_DTLTRA_Delete(gc_strDTLTRA_TRAKB_JDN, strJDNNO_OLD, "", strLINNO_OLD, pm_strErrCd, pm_All)
					' === 20070126 === UPDATE E -
					
					'�o�ח\����A�܂��͍s�ԍ����ς�����ꍇ
				Case (strLINNO_NEW <> strLINNO_OLD Or strODNYTDT_NEW <> strODNYTDT_OLD)
					'��������t�@�C���X�V
					' === 20070126 === UPDATE S - ACE)Nagasawa
					'                intRet = CF_DTLTRA_Update(strJDNNO_OLD, _
					''                                          "", _
					''                                          strLINNO_OLD, _
					''                                          strLINNO_NEW, _
					''                                          strODNYTDT_NEW, _
					''                                          pm_strErrCd, _
					''                                          pm_All)
					intRet = CF_DTLTRA_Update(gc_strDTLTRA_TRAKB_JDN, strJDNNO_OLD, "", strLINNO_OLD, strLINNO_NEW, strODNYTDT_NEW, pm_strErrCd, pm_All)
					' === 20070126 === UPDATE E -
					
				Case Else
			End Select
			
			'���f�[�^�Ǎ�
			Call CF_Ora_MoveNext(Usr_Ody)
		Loop 
		
		CF_DTLTRA_Update_MainJDN = 0
		
CF_DTLTRA_Update_MainJDN_End: 
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
CF_DTLTRA_Update_MainJDN_Err: 
		GoTo CF_DTLTRA_Update_MainJDN_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_DTLTRA_Update
	'   �T�v�F  ��������t�@�C���X�V����
	'   �����F�@pm_strTRAKB     : �g�������
	'           pm_strTRANO     : �g�����ԍ�
	'           pm_strMITNOV    : �Ő�
	'           pm_strLINNO_OLD : �s�ԍ�(�X�V�O)
	'           pm_strLINNO_NEW : �s�ԍ�(�X�V��)
	'           pm_strODNYTDT   : �o�ח\���
	'           pm_strErrCd     : �X�V�ُ�G���[�R�[�h
	'  �@     �@pm_All       �@ : ��ʏ��
	'   �ߒl�F�@0:����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20070126 === UPDATE S - ACE)Nagasawa
	'Public Function CF_DTLTRA_Update(ByVal pm_strTRANO As String, _
	''                                 ByVal pm_strMITNOV As String, _
	''                                 ByVal pm_strLINNO_OLD As String, _
	''                                 ByVal pm_strLINNO_NEW As String, _
	''                                 ByVal pm_strODNYTDT As String, _
	''                                 ByVal pm_strErrCd As String, _
	''                                 ByRef pm_All As Cls_All) As Integer
	Public Function CF_DTLTRA_Update(ByVal pm_strTRAKB As String, ByVal pm_strTRANO As String, ByVal pm_strMITNOV As String, ByVal pm_strLINNO_OLD As String, ByVal pm_strLINNO_NEW As String, ByVal pm_strODNYTDT As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		' === 20070126 === UPDATE E -
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo CF_DTLTRA_Update_Err
		
		CF_DTLTRA_Update = 9
		
		'SQL�ҏW
		strSQL = ""
		strSQL = strSQL & " UPDATE "
		strSQL = strSQL & "        DTLTRA "
		strSQL = strSQL & "    SET "
		strSQL = strSQL & "        LINNO   = '" & CF_Ora_String(pm_strLINNO_NEW, 3) & "' "
		strSQL = strSQL & "      , TRADT   = '" & CF_Ora_Date(pm_strODNYTDT) & "' "
		' === 20070126 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "      , OPEID   = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' "
		strSQL = strSQL & "      , CLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' "
		strSQL = strSQL & "      , WRTTM   = '" & GV_SysTime & "' "
		strSQL = strSQL & "      , WRTDT   = '" & GV_SysDate & "' "
		' === 20070126 === INSERT E -
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO, 20) & "' "
		strSQL = strSQL & "    AND MITNOV  = '" & CF_Ora_String(pm_strMITNOV, 2) & "' "
		strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO_OLD, 3) & "' "
		' === 20070126 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "    AND TRAKB   = '" & CF_Ora_String(pm_strTRAKB, 1) & "' "
		' === 20070126 === INSERT E -
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_DTLTRA_Update_Err
		End If
		
		CF_DTLTRA_Update = 0
		
CF_DTLTRA_Update_End: 
		Exit Function
		
CF_DTLTRA_Update_Err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Update")
		GoTo CF_DTLTRA_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_DTLTRA_Delete
	'   �T�v�F  ��������t�@�C���폜����
	'   �����F�@pm_strTRAKB     : �g�������
	'           pm_strTRANO     : ���ϔԍ�
	'           pm_strMITNOV    : ���ϔԍ��Ő�
	'           pm_strLINNO     : �s�ԍ�(�X�V�O)
	'           pm_strErrCd     : �X�V�ُ�G���[�R�[�h
	'  �@     �@pm_All          : ��ʏ��
	'   �ߒl�F�@0:����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20070126 === UPDATE S - ACE)Nagasawa
	'Public Function CF_DTLTRA_Delete(ByVal pm_strTRANO As String, _
	''                                 ByVal pm_strMITNOV As String, _
	''                                 ByVal pm_strLINNO As String, _
	''                                 ByVal pm_strErrCd As String, _
	''                                 ByRef pm_All As Cls_All) As Integer
	Public Function CF_DTLTRA_Delete(ByVal pm_strTRAKB As String, ByVal pm_strTRANO As String, ByVal pm_strMITNOV As String, ByVal pm_strLINNO As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		' === 20070126 === UPDATE E -
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo CF_DTLTRA_Delete_Err
		
		CF_DTLTRA_Delete = 9
		
		'SQL�ҏW
		strSQL = ""
		strSQL = strSQL & " DELETE FROM "
		strSQL = strSQL & "        DTLTRA "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO, 20) & "' "
		strSQL = strSQL & "    AND MITNOV   = '" & CF_Ora_String(pm_strMITNOV, 2) & "' "
		strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO, 3) & "' "
		' === 20070126 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "    AND TRAKB   = '" & CF_Ora_String(pm_strTRAKB, 1) & "' "
		' === 20070126 === INSERT E -
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_DTLTRA_Delete_Err
		End If
		
		CF_DTLTRA_Delete = 0
		
CF_DTLTRA_Delete_End: 
		Exit Function
		
CF_DTLTRA_Delete_Err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Delete")
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_DTLTRA_Update_Ins
	'   �T�v�F  ��������t�@�C���X�V����
	'   �����F�@pm_strTRANO_NEW   : �g�����ԍ�(�V)
	'  �@     �@pm_strMITNOV_NEW  : �Ő�(�V)
	'  �@     �@pm_strLINNO_NEW   : �s�ԍ�(�V)
	'  �@     �@pm_strTRADT       : �o�ח\���(�V)
	'   �@      pm_strTRANO_NEW   : �g�����ԍ�(��)
	'  �@     �@pm_strMITNOV_NEW  : �Ő�(��)
	'  �@     �@pm_strLINNO_NEW   : �s�ԍ�(��)
	'  �@     �@Pm_strPUDLNO      : ���o�ɔԍ�
	'  �@     �@pm_strErrCd   �@�@: �X�V�ُ�G���[�R�[�h
	'  �@     �@pm_All        : ��ʏ��
	'   �ߒl�F�@0:����  9:�ُ�
	'   ���l�F  �󒍓o�^���̍X�V����(���ς̉��������󒍂ɕt���ւ��鏈���j
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20070126 === UPDATE S - ACE)Nagasawa
	'Public Function CF_DTLTRA_Update_Ins(ByVal pm_strTRANO_NEW As String, _
	''                                      ByVal pm_strMITNOV_NEW As String, _
	''                                      ByVal pm_strLINNO_NEW As String, _
	''                                      ByVal pm_strTRADT As String, _
	''                                      ByVal pm_strTRANO_OLD As String, _
	''                                      ByVal pm_strMITNOV_OLD As String, _
	''                                      ByVal pm_strLINNO_OLD As String, _
	''                                      ByVal pm_strErrCd As String, _
	''                                      ByRef pm_All As Cls_All) As Integer
	Public Function CF_DTLTRA_Update_Ins(ByVal pm_strTRANO_NEW As String, ByVal pm_strMITNOV_NEW As String, ByVal pm_strLINNO_NEW As String, ByVal pm_strTRADT As String, ByVal pm_strTRANO_OLD As String, ByVal pm_strMITNOV_OLD As String, ByVal pm_strLINNO_OLD As String, ByVal Pm_strPUDLNO As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		' === 20070126 === UPDATE E -
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo CF_DTLTRA_Update_Ins_Err
		
		CF_DTLTRA_Update_Ins = 9
		
		'SQL�ҏW
		strSQL = ""
		strSQL = strSQL & " UPDATE "
		strSQL = strSQL & "        DTLTRA "
		strSQL = strSQL & "    SET "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO_NEW, 20) & "' "
		strSQL = strSQL & "      , MITNOV  = '" & CF_Ora_String(pm_strMITNOV_NEW, 2) & "' "
		strSQL = strSQL & "      , LINNO   = '" & CF_Ora_String(pm_strLINNO_NEW, 3) & "' "
		strSQL = strSQL & "      , TRADT   = '" & CF_Ora_Date(pm_strTRADT) & "' "
		' === 20070126 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "      , TRAKB   = '" & CF_Ora_String(gc_strDTLTRA_TRAKB_JDN, 1) & "' "
		strSQL = strSQL & "      , PUDLNO  = '" & CF_Ora_String(Pm_strPUDLNO, 10) & "' "
		strSQL = strSQL & "      , OPEID   = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' "
		strSQL = strSQL & "      , CLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' "
		strSQL = strSQL & "      , WRTTM   = '" & GV_SysTime & "' "
		strSQL = strSQL & "      , WRTDT   = '" & GV_SysDate & "' "
		' === 20070126 === INSERT E -
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO_OLD, 20) & "' "
		strSQL = strSQL & "    AND MITNOV   = '" & CF_Ora_String(pm_strMITNOV_OLD, 2) & "' "
		strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO_OLD, 3) & "' "
		' === 20070126 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "    AND TRAKB   = '" & CF_Ora_String(gc_strDTLTRA_TRAKB_MIT, 1) & "' "
		' === 20070126 === INSERT E -
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_DTLTRA_Update_Ins_Err
		End If
		
		CF_DTLTRA_Update_Ins = 0
		
CF_DTLTRA_Update_Ins_End: 
		Exit Function
		
CF_DTLTRA_Update_Ins_Err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Update_Ins")
		GoTo CF_DTLTRA_Update_Ins_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_DTLTRA_Delete_Ins
	'   �T�v�F  ��������t�@�C���폜����
	'   �����F  pm_strTRAKB   : �g�������
	'  �@     �@pm_strTRANO   : �g�����ԍ�
	'  �@     �@pm_strMITNOV  : �Ő�
	'  �@     �@pm_strLINNO   : �s�ԍ�
	'  �@     �@pm_strErrCd   : �X�V�ُ�G���[�R�[�h
	'  �@     �@pm_All        : ��ʏ��
	'   �ߒl�F�@0:����  9:�ُ�
	'   ���l�F  �󒍓o�^���̍폜����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	' === 20070126 === UPDATE S - ACE)Nagasawa
	'Public Function CF_DTLTRA_Delete_Ins(ByVal pm_strTRANO As String, _
	''                                      ByVal pm_strMITNOV As String, _
	''                                      ByVal pm_strLINNO As String, _
	''                                      ByVal pm_strErrCd As String, _
	''                                      ByRef pm_All As Cls_All) As Integer
	Public Function CF_DTLTRA_Delete_Ins(ByVal pm_strTRAKB As String, ByVal pm_strTRANO As String, ByVal pm_strMITNOV As String, ByVal pm_strLINNO As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		' === 20070126 === UPDATE E -
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo CF_DTLTRA_Delete_Ins_Err
		
		CF_DTLTRA_Delete_Ins = 9
		
		'SQL�ҏW
		strSQL = ""
		strSQL = strSQL & " DELETE FROM "
		strSQL = strSQL & "        DTLTRA "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        TRANO   = '" & CF_Ora_String(pm_strTRANO, 20) & "' "
		strSQL = strSQL & "    AND MITNOV   = '" & CF_Ora_String(pm_strMITNOV, 2) & "' "
		strSQL = strSQL & "    AND LINNO   = '" & CF_Ora_String(pm_strLINNO, 3) & "' "
		' === 20070126 === INSERT S - ACE)Nagasawa
		strSQL = strSQL & "    AND TRAKB   = '" & CF_Ora_String(pm_strTRAKB, 1) & "' "
		' === 20070126 === INSERT E -
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_DTLTRA_Delete_Ins_Err
		End If
		
		CF_DTLTRA_Delete_Ins = 0
		
CF_DTLTRA_Delete_Ins_End: 
		Exit Function
		
CF_DTLTRA_Delete_Ins_Err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_DTLTRA_Delete_Ins")
		
	End Function
	' === 20061217 === INSERT E -
	
	' === 20061217 === INSERT S - ACE)Nagasawa
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Execute_PLSQL_TNADL53
	'   �T�v�F  ����݌ɏƉ�pPL/SQL���s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�߂�l
	'   ���l�F  PL/SQL�����s����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_TNADL53(ByRef pin_strHINCD As String, ByRef pin_strSOUCD As String, ByRef pin_curRELZAISU As Decimal) As Short
		
		Dim strSQL As String 'SQL��
		Dim strPara1 As String '���Ұ�1
		Dim strPara2 As String '���Ұ�2
		Dim strPara3 As String '���Ұ�3
		Dim strPara4 As String '���Ұ�4
		Dim lngPara5 As Integer '���Ұ�5
		Dim strPara6 As String '���Ұ�6
		Dim lngPara7 As Integer '���Ұ�7
		Dim lngPara8 As Integer '���Ұ�8
		Dim strPara9 As String '���Ұ�9
		Dim lngPara10 As Integer '���Ұ�10
		Dim lngPara11 As Integer '���Ұ�11
		'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim param(12) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
		
		'��n���ϐ������ݒ�
		strPara1 = Inp_Inf.InpTanCd '���͒S���҃R�[�h
		strPara2 = Inp_Inf.InpCLIID '�N���C�A���gID
		strPara3 = CF_Ora_String(pin_strHINCD, 10) '���i�R�[�h
		strPara4 = CF_Ora_String(pin_strSOUCD, 3) '�q�ɃR�[�h
		lngPara5 = pin_curRELZAISU '���ݍ݌ɐ�
		strPara6 = CF_Ora_String(SSS_PrgId, 10)
		lngPara7 = 0
		lngPara8 = 0
		strPara9 = ""
		lngPara10 = 0
		lngPara10 = 0
		
		'�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P5", lngPara5, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P6", strPara6, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P7", lngPara7, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P8", lngPara8, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P9", strPara9, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P10", lngPara10, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P11", lngPara11, ORAPARM_OUTPUT)
		
		'�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7) = gv_Odb_USR1.Parameters("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8) = gv_Odb_USR1.Parameters("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9) = gv_Odb_USR1.Parameters("P9")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(10) = gv_Odb_USR1.Parameters("P10")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(11) = gv_Odb_USR1.Parameters("P11")
		
		'�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(10).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(11).serverType = ORATYPE_NUMBER
		
		'PL/SQL�Ăяo��SQL
		strSQL = "BEGIN PRC_TNADL53_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11); End;"
		
		'DB�A�N�Z�X
		Call CF_Ora_Execute(gv_Odb_USR1, strSQL)
		
		'** �߂�l�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara7 = param(7).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara8 = param(8).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strPara9 = param(9).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara10 = param(10).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara11 = param(11).Value
		
		'�߂�l�ݒ�
		AE_Execute_PLSQL_TNADL53 = lngPara7
		
		'** �p�����^����
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P9")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P10")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P11")
		
	End Function
	' === 20061217 === INSERT E -
	
	' === 20061219 === INSERT S - ACE)Nagasawa �݌ɐ��`�F�b�N�̕ύX
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_INPSU_ZAISU
	'   �T�v�F  �݌ɐ��`�F�b�N����
	'   �����F  pm_strHINCD    : ���i�R�[�h
	'  �@     �@pm_curUODSU    : �`�F�b�N�Ώې���(�o�׎��ѐ��{�o�׎w������ϲŽ���Ă���)
	'  �@     �@pm_strJDNINKB  : �󒍎捞���
	'  �@     �@pm_All         : ��ʏ��
	'           pm_strTHNSOUCD : �ʔ̑q�ɃR�[�h
	'   �ߒl�F�@0:����OK 1:���݌�����NG 2:�L���݌�����NG 3:���S�݌�����NG 9:�ُ�
	'   ���l�F�@�`�F�b�N�Ώې��ʂɑ΂��āA�݌ɂ�����Ă��邩���`�F�b�N����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_INPSU_ZAISU(ByVal pm_strHINCD As String, ByVal pm_curCHKSU As Decimal, ByVal pm_strJDNINKB As String, ByRef pm_All As Cls_All, Optional ByVal pm_strTHNSOUCD As String = "") As Short
		
		Dim strSQL As String
		Dim strSOUCD As String
		Dim bolRet As Boolean
		Dim Mst_Inf_HINMTA As TYPE_DB_HINMTA
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim curRELZAISU As Decimal
		Dim curHIKSU As Decimal
		Dim bolDyn_Open As Boolean
		
		On Error GoTo CF_Chk_INPSU_ZAISU_Err
		
		CF_Chk_INPSU_ZAISU = 9
		
		curRELZAISU = 0
		curHIKSU = 0
		bolDyn_Open = False
		
		If Trim(pm_strHINCD) = "" Then
			CF_Chk_INPSU_ZAISU = 0
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'���i�R�[�h��菤�i�}�X�^����
		Call DB_HINMTA_Clear(Mst_Inf_HINMTA)
		If DSPHINCD_SEARCH(pm_strHINCD, Mst_Inf_HINMTA) = 9 Then
			Exit Function
		End If
		
		'�݌ɊǗ����Ȃ����̂̓`�F�b�N���Ȃ�
		If Mst_Inf_HINMTA.ZAIKB = gc_strZAIKB_NG Then
			CF_Chk_INPSU_ZAISU = 0
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'�q�ɃR�[�h����
		If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
			strSOUCD = Trim(pm_strTHNSOUCD)
		Else
			strSOUCD = Trim(Mst_Inf_HINMTA.TNACM)
		End If
		
		'�q�ɕʍ݌Ƀ}�X�^����
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        RELZAISU "
		strSQL = strSQL & "      , HIKSU "
		strSQL = strSQL & "   FROM "
		strSQL = strSQL & "        HINMTB "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        SOUCD = '" & CF_Ora_String(strSOUCD, 3) & "' "
		strSQL = strSQL & "    AND HINCD = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
		strSQL = strSQL & "    AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		
		'SQL���s
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		bolDyn_Open = True
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curRELZAISU = CF_Ora_GetDyn(Usr_Ody, "RELZAISU", 0)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curHIKSU = CF_Ora_GetDyn(Usr_Ody, "HIKSU", 0)
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		bolDyn_Open = False
		
		'���݌Ƀ`�F�b�N
		If (curRELZAISU) - pm_curCHKSU < 0 Then
			CF_Chk_INPSU_ZAISU = 1
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'�L���݌Ƀ`�F�b�N
		If (curRELZAISU - curHIKSU) - pm_curCHKSU < 0 Then
			CF_Chk_INPSU_ZAISU = 2
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'�ʔ͈̂��S�݌ɐ��`�F�b�N�͍s��Ȃ�
		If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
			CF_Chk_INPSU_ZAISU = 0
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		'���S�݌ɐ��`�F�b�N
		If ((curRELZAISU) - curHIKSU - pm_curCHKSU) - Mst_Inf_HINMTA.ANZZAISU < 0 Then
			CF_Chk_INPSU_ZAISU = 3
			GoTo CF_Chk_INPSU_ZAISU_End
		End If
		
		CF_Chk_INPSU_ZAISU = 0
		
CF_Chk_INPSU_ZAISU_End: 
		
		If bolDyn_Open = True Then
			'�N���[�Y
			Call CF_Ora_CloseDyn(Usr_Ody)
		End If
		
		Exit Function
		
CF_Chk_INPSU_ZAISU_Err: 
		GoTo CF_Chk_INPSU_ZAISU_End
		
	End Function
	' === 20061219 === INSERT E -
	
	' === 20070208 === INSERT S - ACE)Nagasawa �݌ɐ��`�F�b�N�̕ύXVer2
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_INPSU_ZAISU_2
	'   �T�v�F  �݌ɐ��`�F�b�N����
	'   �����F  pm_strHINCD    : ���i�R�[�h
	'  �@     �@pm_curUODSU    : �`�F�b�N�Ώې���(�o�׎��ѐ���ϲŽ���Ă���)
	'  �@     �@pm_curMNSSU    : �T������(���ϓo�^�̏ꍇ�͎Q�ƌ����ϐ���
	'  �@     �@�@�@�@�@�@�@�@�@ �@�@�@�@ ���ϒ����̏ꍇ�͌����ϐ���
	'  �@     �@�@�@�@�@�@�@�@�@ �@�@�@�@ �󒍓o�^�̏ꍇ�͉�������
	'  �@     �@�@�@�@�@�@�@�@�@ �@�@�@�@ �󒍒����̏ꍇ�͌����ʁ|�i�o�׎��ѐ��j)
	'  �@     �@pm_strJDNINKB  : �󒍎捞��ʁi���ς̃`�F�b�N�̍ۂ�"0"�j
	'  �@     �@pm_All         : ��ʏ��
	'           pm_strTHNSOUCD : �ʔ̑q�ɃR�[�h
	'   �ߒl�F�@0:����OK 1:���݌�����NG 2:�L���݌�����NG 3:���S�݌�����NG 9:�ُ�
	'   ���l�F�@�`�F�b�N�Ώې��ʂɑ΂��āA�݌ɂ�����Ă��邩���`�F�b�N����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_INPSU_ZAISU_2(ByVal pm_strHINCD As String, ByVal pm_curCHKSU As Decimal, ByVal pm_curMNSSU As Decimal, ByVal pm_strJDNINKB As String, ByRef pm_All As Cls_All, Optional ByVal pm_strTHNSOUCD As String = "") As Short
		
		Dim strSQL As String
		Dim strSOUCD As String
		Dim strTHNSOUCD As String
		Dim bolRet As Boolean
		Dim Mst_Inf_HINMTA As TYPE_DB_HINMTA
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim curRELZAISU As Decimal
		Dim curHIKSU As Decimal
		Dim bolDyn_Open As Boolean
		
		On Error GoTo CF_Chk_INPSU_ZAISU_2_Err
		
		CF_Chk_INPSU_ZAISU_2 = 9
		
		curRELZAISU = 0
		curHIKSU = 0
		bolDyn_Open = False
		
		If Trim(pm_strHINCD) = "" Then
			CF_Chk_INPSU_ZAISU_2 = 0
			GoTo CF_Chk_INPSU_ZAISU_2_End
		End If
		
		'//////////////////////////////////////////////////
		'/ �}�X�^�n�̃`�F�b�N
		'//////////////////////////////////////////////////
		
		'���i�R�[�h��菤�i�}�X�^����
		Call DB_HINMTA_Clear(Mst_Inf_HINMTA)
		If DSPHINCD_SEARCH(pm_strHINCD, Mst_Inf_HINMTA) = 9 Then
			Exit Function
		End If
		
		'�݌ɊǗ����Ȃ����̂̓`�F�b�N���Ȃ�
		If Mst_Inf_HINMTA.ZAIKB = gc_strZAIKB_NG Then
			CF_Chk_INPSU_ZAISU_2 = 0
			GoTo CF_Chk_INPSU_ZAISU_2_End
		End If
		
		'�q�ɃR�[�h����
		If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
			strSOUCD = Trim(pm_strTHNSOUCD)
			strTHNSOUCD = Trim(pm_strTHNSOUCD)
		Else
			strSOUCD = Trim(Mst_Inf_HINMTA.TNACM)
			
			strSQL = ""
			strSQL = strSQL & " SELECT "
			strSQL = strSQL & "        SOUCD "
			strSQL = strSQL & "   FROM "
			strSQL = strSQL & "        SOUMTA "
			strSQL = strSQL & "  WHERE "
			strSQL = strSQL & "        SOUKOKB = '02' "
			'SQL���s
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
			bolDyn_Open = True
			If CF_Ora_EOF(Usr_Ody) = False Then
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strTHNSOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")
			End If
			'�N���[�Y
			Call CF_Ora_CloseDyn(Usr_Ody)
			bolDyn_Open = False
		End If
		
		'�q�ɕʍ݌Ƀ}�X�^����
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        RELZAISU "
		strSQL = strSQL & "   FROM "
		strSQL = strSQL & "        HINMTB "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        SOUCD = '" & CF_Ora_String(strSOUCD, 3) & "' "
		strSQL = strSQL & "    AND HINCD = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
		strSQL = strSQL & "    AND DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		
		'SQL���s
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		bolDyn_Open = True
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curRELZAISU = CF_Ora_GetDyn(Usr_Ody, "RELZAISU", 0)
		End If
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		bolDyn_Open = False
		
		'//////////////////////////////////////////////////
		'/ ���ρi�������j���̌��ϐ��̍��v
		'//////////////////////////////////////////////////
		'�ʔ̈ȊO�̂Ƃ��̂�
		If Trim(pm_strJDNINKB) <> gc_strJDNINKB_ML Then
			'���ό���
			strSQL = ""
			strSQL = strSQL & " SELECT "
			strSQL = strSQL & "        SUM(TRA.MITSU) YTSU "
			strSQL = strSQL & "   FROM "
			strSQL = strSQL & "        MITTHA THA "
			strSQL = strSQL & "       ,MITTRA TRA "
			strSQL = strSQL & "  WHERE "
			strSQL = strSQL & "        THA.DATNO = TRA.DATNO "
			strSQL = strSQL & "    AND THA.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			strSQL = strSQL & "    AND THA.JDNNO = '          ' "
			strSQL = strSQL & "    AND TRA.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			strSQL = strSQL & "    AND TRA.HINCD = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
			strSQL = strSQL & "    AND TRA.KHIKKB = '1' "
			'SQL���s
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
			bolDyn_Open = True
			If CF_Ora_EOF(Usr_Ody) = False Then
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				curHIKSU = curHIKSU + CF_Ora_GetDyn(Usr_Ody, "YTSU", 0)
			End If
			'�N���[�Y
			Call CF_Ora_CloseDyn(Usr_Ody)
			bolDyn_Open = False
		End If
		
		'//////////////////////////////////////////////////
		'/ �󒍕��́i�󒍐� - ���ѐ��j�̍��v
		'//////////////////////////////////////////////////
		'�󒍌���
		strSQL = ""
		' === 20081210 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'D    strSQL = strSQL & " SELECT "
		'D    strSQL = strSQL & "        SUM(TRA.UODSU - TRA.OTPSU) YTSU "
		'D    strSQL = strSQL & "   FROM "
		'D    strSQL = strSQL & "        JDNTHA THA "
		'D    strSQL = strSQL & "       ,JDNTRA TRA "
		'D    strSQL = strSQL & "       ,( SELECT MAX(DATNO) As DATNO "
		'D    strSQL = strSQL & "                ,JDNNO "
		'D    strSQL = strSQL & "          FROM   JDNTHA "
		'D    strSQL = strSQL & "          WHERE  JDNENDKB = '0' "
		'D    strSQL = strSQL & "          GROUP BY JDNNO "
		'D    strSQL = strSQL & "        ) THB "
		'D    strSQL = strSQL & "       ,( SELECT MAX(DATNO) As DATNO "
		'D    strSQL = strSQL & "                ,JDNNO "
		'D    strSQL = strSQL & "                ,LINNO "
		'D    strSQL = strSQL & "          FROM   JDNTRA "
		'D    strSQL = strSQL & "          WHERE  DATKB  = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		'D    strSQL = strSQL & "            AND  HINCD  = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
		'D    strSQL = strSQL & "            AND  UODSU > OTPSU "
		'D    strSQL = strSQL & "          GROUP BY JDNNO "
		'D    strSQL = strSQL & "                  ,LINNO "
		'D    strSQL = strSQL & "        ) TRB "
		'D    strSQL = strSQL & "  WHERE "
		'D    strSQL = strSQL & "        THA.DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		'D    strSQL = strSQL & "    AND THA.AKAKROKB = '1' "
		'D    strSQL = strSQL & "    AND THA.DATNO    = THB.DATNO "
		'D    strSQL = strSQL & "    AND THA.JDNNO    = THB.JDNNO "
		'D    strSQL = strSQL & "    AND TRA.DATKB    = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		'D    strSQL = strSQL & "    AND TRA.AKAKROKB = '1' "
		'D    strSQL = strSQL & "    AND TRA.DATNO    = TRB.DATNO "
		'D    strSQL = strSQL & "    AND TRA.JDNNO    = TRB.JDNNO "
		'D    strSQL = strSQL & "    AND TRA.LINNO    = TRB.LINNO "
		'D    strSQL = strSQL & "    AND THA.DATNO    = TRA.DATNO "
		'D    strSQL = strSQL & "    AND THA.JDNTRKB  IN ( '01', '11', '21' ) "
		'D    strSQL = strSQL & "    AND TRA.HINCD    = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
		'D    strSQL = strSQL & "    AND TRA.JDNKB    IN ( '1', '2' ) "
		'D    '�ʔ̎��͒ʔ̑q��
		'D    If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
		'D        strSQL = strSQL & " AND TRA.SOUCD = '" & CF_Ora_String(strTHNSOUCD, 3) & "' "
		'D    Else
		'D        strSQL = strSQL & " AND TRA.SOUCD <> '" & CF_Ora_String(strTHNSOUCD, 3) & "' "
		'D    End If
		
		strSQL = ""
		strSQL = strSQL & " SELECT TRA.JDNKB               JDNKB "
		strSQL = strSQL & "      , (TRA.UODSU - TRA.OTPSU) YTSU  "
		strSQL = strSQL & " FROM  "
		strSQL = strSQL & "      (SELECT THB.DATNO "
		strSQL = strSQL & "            , THB.JDNNO "
		strSQL = strSQL & "            , THB.JDNENDKB "
		strSQL = strSQL & "            , THB.JDNTRKB  "
		strSQL = strSQL & "         FROM JDNTHA THB  "
		strSQL = strSQL & "        WHERE EXISTS (SELECT DATNO  "
		strSQL = strSQL & "                        FROM JDNTHC THC  "
		strSQL = strSQL & "                       WHERE THB.DATNO = THC.DATNO  "
		strSQL = strSQL & "                         AND THB.JDNNO = THC.JDNNO)  "
		strSQL = strSQL & "          AND THB.JDNENDKB = '0'  "
		strSQL = strSQL & "          AND THB.JDNTRKB IN ('01' "
		strSQL = strSQL & "                           ,  '11' "
		strSQL = strSQL & "                           ,  '21') "
		strSQL = strSQL & "      ) THA, "
		'''' UPD 2009/02/27  FKS) S.Nakajima    Start
		'    strSQL = strSQL & "      (SELECT TRB.DATNO "
		strSQL = strSQL & "      (SELECT /*+ INDEX (TRB X_JDNTRA94) */ TRB.DATNO "
		'''' UPD 2009/02/27  FKS) S.Nakajima    End
		strSQL = strSQL & "            , TRB.JDNNO "
		strSQL = strSQL & "            , TRB.LINNO "
		strSQL = strSQL & "            , TRB.DATKB "
		strSQL = strSQL & "            , TRB.AKAKROKB "
		strSQL = strSQL & "            , TRB.JDNKB "
		strSQL = strSQL & "            , TRB.HINKB "
		strSQL = strSQL & "            , TRB.HINCD "
		strSQL = strSQL & "            , TRB.SOUCD "
		strSQL = strSQL & "            , TRB.UODSU "
		strSQL = strSQL & "            , TRB.OTPSU  "
		strSQL = strSQL & "         FROM JDNTRA TRB  "
		strSQL = strSQL & "        WHERE EXISTS (SELECT TRC.DATNO  "
		strSQL = strSQL & "                        FROM JDNTHC TRC  "
		strSQL = strSQL & "                       WHERE TRC.DATNO = TRB.DATNO  "
		strSQL = strSQL & "                         AND TRC.JDNNO = TRB.JDNNO) "
		strSQL = strSQL & "          AND TRB.DATKB = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "          AND TRB.HINCD = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
		'''' UPD 2009/02/27  FKS) S.Nakajima    Start
		'    strSQL = strSQL & "          AND TRB.UODSU > TRB.OTPSU  "
		strSQL = strSQL & "          AND TRB.UODSU - TRB.OTPSU > 0  "
		'''' UPD 2009/02/27  FKS) S.Nakajima    End
		
		'�ʔ̎��͒ʔ̑q��
		If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
			strSQL = strSQL & "          AND TRB.SOUCD = '" & CF_Ora_String(strTHNSOUCD, 3) & "' "
		Else
			strSQL = strSQL & "          AND TRB.SOUCD <> '" & CF_Ora_String(strTHNSOUCD, 3) & "' "
		End If
		
		strSQL = strSQL & "      ) TRA  "
		strSQL = strSQL & " WHERE     THA.DATNO = TRA.DATNO  "
		' === 20081210 === UPDATE E -
		
		'SQL���s
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		bolDyn_Open = True
		' === 20081210 === UPDATE S - ACE)Nagasawa ���X�|���X�Ή�
		'D    If CF_Ora_EOF(Usr_Ody) = False Then
		'D        curHIKSU = curHIKSU + CF_Ora_GetDyn(Usr_Ody, "YTSU", 0)
		'D    End If
		
		Do Until CF_Ora_EOF(Usr_Ody) = True
			
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			If Trim(CF_Ora_GetDyn(Usr_Ody, "JDNKB", "")) = "1" Or Trim(CF_Ora_GetDyn(Usr_Ody, "JDNKB", "")) = "2" Then
				
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				curHIKSU = curHIKSU + CF_Ora_GetDyn(Usr_Ody, "YTSU", 0)
			End If
			
			Call CF_Ora_MoveNext(Usr_Ody)
		Loop 
		' === 20081210 === UPDATE E -
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		bolDyn_Open = False
		
		'//////////////////////////////////////////////////
		'/ �x���i���́i�\�萔 - ���ѐ��j�̍��v
		'//////////////////////////////////////////////////
		'�ʔ̈ȊO�̂Ƃ��̂�
		If Trim(pm_strJDNINKB) <> gc_strJDNINKB_ML Then
			'�x���i����
			strSQL = ""
			strSQL = strSQL & " SELECT "
			strSQL = strSQL & "        SUM(OUTYOTSU - OUTZMISU) YTSU "
			strSQL = strSQL & "   FROM "
			strSQL = strSQL & "        SKYTBL "
			strSQL = strSQL & "  WHERE "
			strSQL = strSQL & "        DATKB  = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			strSQL = strSQL & "    AND HINCD  = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
			strSQL = strSQL & "    AND PLANKB = ' ' "
			'SQL���s
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
			bolDyn_Open = True
			If CF_Ora_EOF(Usr_Ody) = False Then
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				curHIKSU = curHIKSU + CF_Ora_GetDyn(Usr_Ody, "YTSU", 0)
			End If
			'�N���[�Y
			Call CF_Ora_CloseDyn(Usr_Ody)
			bolDyn_Open = False
		End If
		
		'//////////////////////////////////////////////////
		'/ ���ԏo�ɂ́i�\�萔 - ���ѐ��j�̍��v
		'//////////////////////////////////////////////////
		'�ʔ̈ȊO�̂Ƃ��̂�
		If Trim(pm_strJDNINKB) <> gc_strJDNINKB_ML Then
			'���ԏo�Ɍ���
			strSQL = ""
			strSQL = strSQL & " SELECT "
			strSQL = strSQL & "        SUM(FRDYTSU - OUTSMSU) YTSU "
			strSQL = strSQL & "   FROM "
			strSQL = strSQL & "        SBNTRA "
			strSQL = strSQL & "  WHERE "
			strSQL = strSQL & "        DATKB  = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
			strSQL = strSQL & "    AND HINCD  = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
			strSQL = strSQL & "    AND OUTSOUCD = '" & CF_Ora_String(strSOUCD, 3) & "' "
			'SQL���s
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
			bolDyn_Open = True
			If CF_Ora_EOF(Usr_Ody) = False Then
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				curHIKSU = curHIKSU + CF_Ora_GetDyn(Usr_Ody, "YTSU", 0)
			End If
			'�N���[�Y
			Call CF_Ora_CloseDyn(Usr_Ody)
			bolDyn_Open = False
		End If
		
		'�o�ח\�萔�̕␳
		curHIKSU = curHIKSU - pm_curMNSSU
		
		
		'//////////////////////////////////////////////////
		'/ �e��`�F�b�N
		'//////////////////////////////////////////////////
		'���݌Ƀ`�F�b�N
		If (curRELZAISU) - pm_curCHKSU < 0 Then
			CF_Chk_INPSU_ZAISU_2 = 1
			GoTo CF_Chk_INPSU_ZAISU_2_End
		End If
		
		'�L���݌Ƀ`�F�b�N
		If (curRELZAISU - curHIKSU) - pm_curCHKSU < 0 Then
			CF_Chk_INPSU_ZAISU_2 = 2
			GoTo CF_Chk_INPSU_ZAISU_2_End
		End If
		
		'�ʔ͈̂��S�݌ɐ��`�F�b�N�͍s��Ȃ�
		If Trim(pm_strJDNINKB) = gc_strJDNINKB_ML Then
			CF_Chk_INPSU_ZAISU_2 = 0
			GoTo CF_Chk_INPSU_ZAISU_2_End
		End If
		
		'���S�݌ɐ��`�F�b�N
		If ((curRELZAISU) - curHIKSU - pm_curCHKSU) - Mst_Inf_HINMTA.ANZZAISU < 0 Then
			CF_Chk_INPSU_ZAISU_2 = 3
			GoTo CF_Chk_INPSU_ZAISU_2_End
		End If
		
		CF_Chk_INPSU_ZAISU_2 = 0
		
CF_Chk_INPSU_ZAISU_2_End: 
		
		If bolDyn_Open = True Then
			'�N���[�Y
			Call CF_Ora_CloseDyn(Usr_Ody)
		End If
		
		Exit Function
		
CF_Chk_INPSU_ZAISU_2_Err: 
		GoTo CF_Chk_INPSU_ZAISU_2_End
		
	End Function
	' === 20070208 === INSERT E -
	
	'ADD START FKS)INABA 2009/09/04
	'�V�����Ή�
	'�����@�@ps_JDNNO�@   �󒍇�
	'        ps_JDNLINNO  �󒍍s��
	'�@�@�@�@pv_ChkKIN�@�@�`�F�b�N���z(�󒍋��z)
	'�߂�l�@1:�`�F�b�N���z(�󒍋��z)���������z�ȏ�
	'�@�@�@�@2:�O�������
	Public Function CF_NYUKN_MAEUKE_CHK(ByRef ps_JDNNO As String, ByRef ps_JDNLINNO As String, Optional ByRef pv_ChkKIN As Object = Nothing) As Short
		Dim ls_sql As String
		Dim bolRet As Boolean
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim bolDyn_Open As Boolean
		'Dim lv_JKESIKN          As Variant
		Dim lv_NYUKN As Object
		On Error GoTo ERR_HANDLE
		'    lv_JKESIKN = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g lv_NYUKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lv_NYUKN = 0
		''�����σ`�F�b�N
		'    ls_sql = " SELECT SUM(NVL(JKESIKN,0)) JKESIKN_SUM "
		'    ls_sql = ls_sql & " FROM UDNTRA "
		'    ls_sql = ls_sql & " WHERE DATKB = '1' "
		'    ls_sql = ls_sql & "   AND DENKB = '1' "
		'    ls_sql = ls_sql & "   AND JDNNO= '" & Trim$(ps_JDNNO) & "' "
		'    ls_sql = ls_sql & "   AND JDNLINNO= '" & Trim$(ps_JDNLINNO) & "' "
		'    ls_sql = ls_sql & " GROUP BY JDNNO ,JDNLINNO"
		'    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
		'    bolDyn_Open = True
		'    If CF_Ora_EOF(Usr_Ody) = False Then
		'        lv_JKESIKN = CF_Ora_GetDyn(Usr_Ody, "JKESIKN_SUM", "")
		'    Else
		'        lv_JKESIKN = 0
		'    End If
		'    '�N���[�Y
		'    Call CF_Ora_CloseDyn(Usr_Ody)
		'    bolDyn_Open = False
		'    If lv_JKESIKN >= pv_ChkKIN Then
		'        CF_NYUKN_MAEUKE_CHK = 1
		'    Else
		'        CF_NYUKN_MAEUKE_CHK = 0
		'    End If
		CF_NYUKN_MAEUKE_CHK = 0
		'�O����`�F�b�N
		ls_sql = " SELECT SUM(NVL(NYUKN,0)) NYUKN_SUM "
		ls_sql = ls_sql & " FROM UDNTRA "
		ls_sql = ls_sql & " WHERE DATKB = '1' "
		ls_sql = ls_sql & "   AND DENKB = '8' "
		ls_sql = ls_sql & "   AND OKRJONO = '" & Trim(ps_JDNNO) & Trim(ps_JDNLINNO) & "' "
		ls_sql = ls_sql & " GROUP BY OKRJONO "
		'SQL���s
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, ls_sql)
		bolDyn_Open = True
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			'UPGRADE_WARNING: �I�u�W�F�N�g lv_NYUKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			lv_NYUKN = CF_Ora_GetDyn(Usr_Ody, "NYUKN_SUM", "")
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g lv_NYUKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			lv_NYUKN = 0
		End If
		'�N���[�Y
		Call CF_Ora_CloseDyn(Usr_Ody)
		bolDyn_Open = False
		'UPGRADE_WARNING: �I�u�W�F�N�g lv_NYUKN �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If lv_NYUKN <> 0 Then
			CF_NYUKN_MAEUKE_CHK = 2
		End If
		
EXIT_HANDLE: 
		On Error GoTo 0
		Exit Function
		
ERR_HANDLE: 
		CF_NYUKN_MAEUKE_CHK = -1
		GoTo EXIT_HANDLE
		
	End Function
	
	
	
	' === 20061223 === INSERT S - ACE)Nagasawa �X�֔ԍ�/�d�b�ԍ�/FAX�ԍ��̒ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_ZIPCD
	'   �T�v�F  �X�֔ԍ��`�F�b�N����
	'   �����F  pin_strZIPCD            : �`�F�b�N�ΏۗX�֔ԍ�
	'           pin_intKETA             : �X�֔ԍ����͉\����
	'           pin_intZIP_HAIHUN       : �n�C�t���ʒu�i�����j
	'           pin_strFRNKB            : �C�O����敪
	'   �ߒl�F  0 : �`�F�b�NOK   9 : �`�F�b�NNG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_ZIPCD(ByVal pin_strZIPCD As String, ByVal pin_intKETA As Short, ByVal pin_intZIP_HAIHUN As Short, ByVal pin_strFRNKB As String) As Short
		
		Dim intHaihun As Short
		Dim intCnt As Short
		Dim intLstHaihun As Short '�Ō�̃n�C�t���ʒu
		
		CF_Chk_ZIPCD = 9
		
		'����悪�����̏ꍇ�̂݃`�F�b�N���s��
		If pin_strFRNKB <> gc_strFRNKB_FRN Then
			
			'�󔒂�OK�Ƃ���
			If Trim(pin_strZIPCD) = "" Then
				CF_Chk_ZIPCD = 0
				Exit Function
			End If
			
			'�����`�F�b�N
			If Len(pin_strZIPCD) <> pin_intKETA Then
				CF_Chk_ZIPCD = 10
				Exit Function
			End If
			
			'�n�C�t���ʒu�`�F�b�N
			For intCnt = 1 To pin_intKETA
				If intCnt = pin_intZIP_HAIHUN Then
					If MidWid(pin_strZIPCD, intCnt, 1) <> "-" Then
						CF_Chk_ZIPCD = 20
						Exit Function
					End If
				Else
					If IsNumeric(MidWid(pin_strZIPCD, intCnt, 1)) = False Then
						CF_Chk_ZIPCD = 20
						Exit Function
					End If
				End If
			Next 
		End If
		
		CF_Chk_ZIPCD = 0
		
	End Function
	' === 20061223 === INSERT E -
	
	' === 20070115 === INSERT S - ACE)Nagasawa �����O�ɍX�V���ԃ`�F�b�N������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_UWRTDTTM
	'   �T�v�F  �o�b�`�X�V���t���Ԏ擾����
	'   �����F  pin_strTBLNM            : �����Ώۃe�[�u����
	'           pin_strDATNO            : �`�[�Ǘ��ԍ��i�ȗ��������Ɋ܂߂Ȃ��j
	'           pin_strRECNO            : ���R�[�h�Ǘ��ԍ��i�ȗ��������Ɋ܂߂Ȃ��j
	'           pot_strUWRTDT           : �o�b�`�X�V���t
	'           pot_strUWRTTM           : �o�b�`�X�V����
	'   �ߒl�F  0 : ����I��  9 : �ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_UWRTDTTM(ByVal pin_strTBLNM As String, ByRef pot_strUWRTDT As String, ByRef pot_strUWRTTM As String, Optional ByVal pin_strDatNo As String = "", Optional ByVal pin_strRECNO As String = "", Optional ByVal pin_strELSE As String = "") As Short
		
		On Error GoTo CF_Get_UWRTDTTM_ERR
		
		Dim Str_Sql As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		Dim Str_Where As String
		
		CF_Get_UWRTDTTM = 9
		
		'// ������
		pot_strUWRTDT = ""
		pot_strUWRTTM = ""
		
		'�����`�F�b�N
		If Trim(pin_strDatNo) = "" And Trim(pin_strRECNO) = "" And Trim(pin_strELSE) = "" Then
			GoTo CF_Get_UWRTDTTM_END
		End If
		
		Str_Sql = ""
		Str_Sql = Str_Sql & " SELECT "
		Str_Sql = Str_Sql & "        UWRTDT "
		Str_Sql = Str_Sql & "      , UWRTTM "
		Str_Sql = Str_Sql & "   FROM "
		Str_Sql = Str_Sql & "        " & Trim(pin_strTBLNM)
		
		'���������ҏW
		Str_Where = ""
		'�`�[�Ǘ��ԍ�
		If Trim(pin_strDatNo) <> "" Then
			Str_Where = Str_Where & "        DATNO = '" & CF_Ora_String(pin_strDatNo, 10) & "' "
		End If
		
		'���R�[�h�Ǘ��ԍ�
		If Trim(pin_strRECNO) <> "" Then
			If Trim(Str_Where) <> "" Then
				Str_Where = Str_Where & " AND "
			End If
			
			Str_Where = Str_Where & "        RECNO = '" & CF_Ora_String(pin_strRECNO, 10) & "' "
		End If
		
		'����ȊO
		If Trim(pin_strELSE) <> "" Then
			If Trim(Str_Where) <> "" Then
				Str_Where = Str_Where & " AND "
			End If
			
			Str_Where = Str_Where & pin_strELSE
		End If
		
		If Trim(Str_Where) <> "" Then
			Str_Sql = Str_Sql & "  WHERE " & Str_Where
		End If
		
		' === 20080209 === INSERT S - ACE)Nagasawa �s���b�N�ǉ�
		Str_Sql = Str_Sql & "  For Update "
		' === 20080209 === INSERT E -
		
		If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
			GoTo CF_Get_UWRTDTTM_ERR
		End If
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_strUWRTDT = Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTDT"))
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_strUWRTTM = Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTTM"))
		End If
		
		CF_Get_UWRTDTTM = 0
		
CF_Get_UWRTDTTM_END: 
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
CF_Get_UWRTDTTM_ERR: 
		GoTo CF_Get_UWRTDTTM_END
		
	End Function
	' === 20070115 === INSERT E -
	
	' === 20070207 === INSERT S - ACE)Nagasawa �V�X�e���󒍂ŋ@��󒍂���͉Ƃ���
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_PRDTBMCD
	'   �T�v�F  ���Y�S���R�[�h�`�F�b�N����
	'   �����F  pm_strPRDTBMCD : ���Y�S���R�[�h
	'           pm_strCMPKTCD�@: �R���s���[�^�^���R�[�h
	'   �ߒl�F  0  : ����
	'           1  : �@��󒍗p�̐��Y�S���ł͂Ȃ�
	'           2  : �@��󒍗p�ȊO�̐��Y�S���ł͂Ȃ�
	'   ���l�F�@���͂��ꂽ���Y�S���R�[�h���g�p�\���ǂ����`�F�b�N���܂�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_PRDTBMCD(ByRef pm_strPRDTBMCD As String, ByRef pm_strCMPKTCD As String) As Short
		
		Dim Mst_Inf_PRDTBMCD As TYPE_DB_MEIMTA
		Dim Mst_Inf_CMPKTCD As TYPE_DB_MEIMTA
		Dim strKiki_PRDTBMCD As String
		Dim strKiki_CMPKTCD As String
		
		CF_Chk_PRDTBMCD = 0
		
		If Trim(pm_strPRDTBMCD) = "" And Trim(pm_strCMPKTCD) = "" Then
			Exit Function
		End If
		
		'���̃}�X�^�����i���Y�S���R�[�h�j
		strKiki_PRDTBMCD = gc_strPRDTBMCD_KIKI_Else
		If DSPMEIM_SEARCH(gc_strKEYCD_STANCD, pm_strPRDTBMCD, Mst_Inf_PRDTBMCD) = 0 Then
			If Mst_Inf_PRDTBMCD.DATKB = gc_strDATKB_USE Then
				strKiki_PRDTBMCD = Mst_Inf_PRDTBMCD.MEIKBB
			End If
		End If
		
		'���̃}�X�^�����i�R���s���[�^�^���R�[�h�j
		strKiki_CMPKTCD = gc_strCMPKTCD_KIKI_Else
		If Trim(pm_strCMPKTCD) <> "" Then
			If DSPMEIM_SEARCH(gc_strKEYCD_CMPKTCD, pm_strCMPKTCD, Mst_Inf_CMPKTCD) = 0 Then
				If Mst_Inf_CMPKTCD.DATKB = gc_strDATKB_USE Then
					strKiki_CMPKTCD = Mst_Inf_CMPKTCD.MEIKBA
				End If
			End If
		End If
		
		'�@��󒍗p�̐��Y�S���ł͂Ȃ�
		If strKiki_CMPKTCD = gc_strCMPKTCD_KIKI And strKiki_PRDTBMCD = gc_strPRDTBMCD_KIKI_Else Then
			CF_Chk_PRDTBMCD = 1
			Exit Function
		End If
		
		'�@��󒍗p�ȊO�̐��Y�S���ł͂Ȃ�
		If strKiki_CMPKTCD = gc_strCMPKTCD_KIKI_Else And strKiki_PRDTBMCD = gc_strPRDTBMCD_KIKI Then
			CF_Chk_PRDTBMCD = 2
			Exit Function
		End If
		
	End Function
	' === 20070207 === INSERT E -
	
	' === 20070301 === INSERT S - ACE)Nagasawa ����ł��Z�o�ł��Ȃ������ꍇ�Ƀ��b�Z�[�W�\��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_TAXKBN_TOK
	'   �T�v�F  ����Ŏ擾�p�̋敪�`�F�b�N�����i���Ӑ�j
	'   �����F  Pin_strTOKZEIKB�@: ���Ӑ����ŋ敪
	'           Pin_strTOKRPSKB�@: ����Œ[����������
	'           Pin_strTOKZRNKB�@: ����Œ[�������敪
	'           Pot_strErrMsg�@�@: �G���[���b�Z�[�W
	'   �ߒl�F  True : �`�F�b�NOK  False : �`�F�b�NNG
	'   ���l�F�@����ł��擾�ł��邩�ǂ����̃`�F�b�N���s���܂�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_TAXKBN_TOK(ByVal Pin_strTOKZEIKB As String, ByVal Pin_strTOKRPSKB As String, ByVal Pin_strTOKZRNKB As String, ByRef Pot_strErrMsg As String) As Boolean
		
		Dim strErrMsg As String
		
		CF_Chk_TAXKBN_TOK = True
		Pot_strErrMsg = ""
		strErrMsg = ""
		
		'���Ӑ����ŋ敪�`�F�b�N
		Select Case Trim(Pin_strTOKZEIKB)
			Case gc_strTOKZEIKB_NUK, gc_strTOKZEIKB_KOM, gc_strTOKZEIKB_HIK
			Case Else
				strErrMsg = "����ŋ敪"
		End Select
		
		'����Œ[�����������`�F�b�N
		Select Case Trim(Pin_strTOKRPSKB)
			Case gc_strTOKRPSKB_0, gc_strTOKRPSKB_10, gc_strTOKRPSKB_100
			Case Else
				If Trim(strErrMsg) <> "" Then
					strErrMsg = strErrMsg & "�A"
				End If
				strErrMsg = strErrMsg & "���Ӑ����Œ[������"
		End Select
		
		'����Œ[�������敪�`�F�b�N
		Select Case Trim(Pin_strTOKZRNKB)
			Case gc_strTOKZRNKB_DWN, gc_strTOKZRNKB_RND, gc_strTOKZRNKB_UP
			Case Else
				If InStr(1, strErrMsg, "���Ӑ����Œ[������") = 0 Then
					If Trim(strErrMsg) <> "" Then
						strErrMsg = strErrMsg & "�A"
					End If
					strErrMsg = strErrMsg & "���Ӑ����Œ[������"
				End If
		End Select
		
		If Trim(strErrMsg) <> "" Then
			Pot_strErrMsg = vbCrLf & "�����ڍדo�^��ʂ�" & strErrMsg & "���m�F���Ă��������B"
			CF_Chk_TAXKBN_TOK = False
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Chk_TAXKBN_HIN
	'   �T�v�F  ����Ŏ擾�p�̋敪�`�F�b�N�����i���i�j
	'   �����F  Pin_strHINZEIKB�@: ���i����ŋ敪
	'           Pin_strZEIRNKKB�@: ����Ń����N
	'           Pot_strErrMsg�@�@: �G���[���b�Z�[�W
	'   �ߒl�F  True : �`�F�b�NOK  False : �`�F�b�NNG
	'   ���l�F�@����ł��擾�ł��邩�ǂ����̃`�F�b�N���s���܂�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Chk_TAXKBN_HIN(ByVal Pin_strHINZEIKB As String, ByVal pin_strZEIRNKKB As String, ByRef Pot_strErrMsg As String) As Boolean
		
		Dim strErrMsg As String
		
		CF_Chk_TAXKBN_HIN = True
		Pot_strErrMsg = ""
		strErrMsg = ""
		
		'���i����ŋ敪�`�F�b�N
		Select Case Trim(Pin_strHINZEIKB)
			Case gc_strHINZEIKB_TOK, gc_strHINZEIKB_NUK, gc_strHINZEIKB_KOM, gc_strHINZEIKB_HIK
			Case Else
				strErrMsg = "����ŋ敪"
		End Select
		
		'����Ń����N
		If Trim(pin_strZEIRNKKB) = "" Then
			If Trim(strErrMsg) <> "" Then
				strErrMsg = strErrMsg & "�A"
			End If
			strErrMsg = strErrMsg & "����ŗ�"
		End If
		
		If Trim(strErrMsg) <> "" Then
			Pot_strErrMsg = vbCrLf & "���i�ڍדo�^��ʂ�" & strErrMsg & "���m�F���Ă��������B"
			CF_Chk_TAXKBN_HIN = False
		End If
		
	End Function
	' === 20070301 === INSERT E -
	
	' === 20070307 === INSERT S - ACE)Nagasawa �����̓��͉ې���̕ύX
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_GET_URIInf_DATNO
	'   �T�v�F  �X�V�Ώ۔�����̓`�[�Ǘ��ԍ��擾
	'   �����F  pin_strJDNNO      : �󒍔ԍ�
	'   �@�@�@  pin_strTOKCD      : ���Ӑ�R�[�h
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  �X�V�Ώ۔�����̓`�[�Ǘ��ԍ��A�ԍ��쐬�t���O���擾����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_GET_URIInf_DATNO(ByRef pin_usrUDNTHA As Cmn_UDNTHA_Upd, ByRef pin_usrUDNTRA() As Cmn_UDNTRA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim intCnt2 As Short
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy_UDNTHA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_UDNTHA As U_Ody
		'UPGRADE_WARNING: �\���� usrOdy_UDNTRA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_UDNTRA As U_Ody
		Dim bolTran As Boolean
		Dim intRet As Short
		Dim strDATNO() As String
		Dim strFDNNO() As String
		Dim bolAKAKRO() As Boolean
		Dim strSSADT() As String
		Dim strKESDT() As String
		Dim strKEYDATNO As String
		Dim curKensu As Decimal
		Dim strNXTKB As String
		Dim strSMADT As String
		Dim strSSADT_Chk As String
		Dim strKESDT_Chk As String
		Dim strUDNDT As String
		Dim strDENDT As String
		Dim strTOKSMEKB As String
		Dim strTOKSMEDD As String
		Dim strTOKSMECC As String
		Dim strTOKSDWKB As String
		Dim strTOKKESCC As String
		Dim strTOKKESDD As String
		Dim strTOKKDWKB As String
		Dim strDate As String
		Dim strJdnNo As String
		Dim strDATNO_Esc As String
		Dim strSSADT_MAX As String
		Dim strSMADT_MAX As String
		Dim strDENDT_MAX As String
		Dim strSSADT_Chk_Calc As String
		Dim strRet_HNPN As String
		Dim strODNNO_Get() As String
		Dim strUDNNO_KRO() As String
		Dim strUDNNO_AKA() As String
		' === 20070331 === INSERT S - ACE)Nagasawa ��������ԕi�Ή�
		Dim strFDNNO_KRO() As String
		Dim strFDNNO_AKA() As String
		' === 20070331 === INSERT E -
		Dim intODNNO_GetSu As Short
		Dim intUDNNO_GetSu As Short
		
		On Error GoTo AE_GET_URIInf_DATNO_Err
		
		AE_GET_URIInf_DATNO = 9
		
		bolTran = False
		ReDim strDATNO(0)
		ReDim strFDNNO(0)
		ReDim bolAKAKRO(0)
		ReDim strSSADT(0)
		ReDim strKESDT(0)
		ReDim strODNNO_Get(0)
		ReDim strUDNNO_KRO(0)
		ReDim strUDNNO_AKA(0)
		' === 20070331 === INSERT S - ACE)Nagasawa ��������ԕi�Ή�
		ReDim strFDNNO_KRO(0)
		ReDim strFDNNO_AKA(0)
		' === 20070331 === INSERT E -
		intODNNO_GetSu = 0
		intUDNNO_GetSu = 0
		
		strKEYDATNO = ""
		strJdnNo = pin_usrUDNTHA.JDNNO
		
		strSMADT_MAX = "00000000"
		strSSADT_MAX = "00000000"
		strDENDT_MAX = "00000000"
		pin_usrUDNTHA.strErr = ""
		
		'���㌩�o���g�����擾
		strSQL = ""
		strSQL = strSQL & " SELECT DATNO "
		strSQL = strSQL & "      , UDNNO "
		strSQL = strSQL & "      , FDNNO "
		strSQL = strSQL & "      , UDNDT "
		strSQL = strSQL & "      , DENDT "
		strSQL = strSQL & "      , NXTKB "
		strSQL = strSQL & "      , SMADT "
		strSQL = strSQL & "      , SSADT "
		strSQL = strSQL & "      , KESDT "
		strSQL = strSQL & "      , TOKSMEKB "
		strSQL = strSQL & "      , TOKSMEDD "
		strSQL = strSQL & "      , TOKSMECC "
		strSQL = strSQL & "      , TOKSDWKB "
		strSQL = strSQL & "      , TOKKESCC "
		strSQL = strSQL & "      , TOKKESDD "
		strSQL = strSQL & "      , TOKKDWKB "
		strSQL = strSQL & "   FROM UDNTHA "
		strSQL = strSQL & "  WHERE UDNTHA.DATNO NOT IN "
		'CHG START FKS)INABA 2009/08/07 *******************************************************************************
		'�A���[��FC09080601(�A���[��747)
		strSQL = strSQL & "                     (SELECT  DECODE(TRIM(UDNTRA.DKBSB) || TRIM(UDNTRA.DKBID),'04002','          ','04006','          ',UDNTHA.MOTDATNO) MOTDATNO "
		strSQL = strSQL & "                        FROM UDNTHA ,UDNTRA "
		strSQL = strSQL & "                       WHERE UDNTHA.JDNNO = '" & CF_Ora_String(strJdnNo, 10) & "' "
		strSQL = strSQL & "                         AND UDNTHA.DATNO = UDNTRA.DATNO "
		strSQL = strSQL & "                       GROUP BY DECODE(TRIM(UDNTRA.DKBSB) || TRIM(UDNTRA.DKBID),'04002','          ','04006','          ',UDNTHA.MOTDATNO) )"
		'    strSQL = strSQL & "                     (SELECT UDNTHA.MOTDATNO "
		'    strSQL = strSQL & "                        FROM UDNTHA "
		'    strSQL = strSQL & "                       WHERE UDNTHA.JDNNO = '" & CF_Ora_String(strJdnNo, 10) & "' "
		'    strSQL = strSQL & "                       GROUP BY MOTDATNO)"
		'CHG  END  FKS)INABA 2009/08/07 *******************************************************************************
		strSQL = strSQL & "    AND UDNTHA.DATKB = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "    AND UDNTHA.AKAKROKB  = '" & gc_strAKAKROKB_KURO & "' "
		strSQL = strSQL & "    AND UDNTHA.JDNNO = '" & CF_Ora_String(strJdnNo, 10) & "' "
		strSQL = strSQL & "    AND UDNTHA.DATKB = '" & gc_strDATKB_USE & "' "
		strSQL = strSQL & "    AND UDNTHA.AKAKROKB  = '" & gc_strAKAKROKB_KURO & "' "
		strSQL = strSQL & "  ORDER BY DATNO, JDNNO "
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTHA, strSQL)
		If bolRet = False Then
			GoTo AE_GET_URIInf_DATNO_Err
		End If
		
		bolTran = True
		
		intCnt = 1
		Do Until CF_Ora_EOF(usrOdy_UDNTHA)
			'�`�[�Ǘ��ԍ��ޔ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strDATNO_Esc = CF_Ora_GetDyn(usrOdy_UDNTHA, "DATNO", "")
			
			For intCnt2 = 1 To UBound(pin_usrUDNTRA)
				'����g�����擾
				strSQL = ""
				strSQL = strSQL & " SELECT COUNT(*)   AS CNT "
				strSQL = strSQL & "   FROM UDNTRA "
				strSQL = strSQL & "  WHERE UDNTRA.DATNO = '" & CF_Ora_String(strDATNO_Esc, 10) & "' "
				
				'�󒍎���敪�ɂ�茟�������ύX
				Select Case True
					'�V�X�e���󒍂ŏo�׊�̂��́A�܂��̓Z�b�g�A�b�v��
					Case (pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SYS And pin_usrUDNTHA.URIKJN = gc_strURIKJN_SYK) Or pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SET
						strSQL = strSQL & "    AND JDNLINNO = '" & CF_Ora_String(pin_usrUDNTRA(intCnt2).LINNO, 10) & "' "
						
						'�V�X�e���󒍂ŏo�׊�ȊO�̂���
					Case pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SYS
						strSQL = strSQL & "    AND RECNO    = '" & CF_Ora_String(pin_usrUDNTRA(intCnt2).RECNO, 10) & "' "
						
						'��L�ȊO
					Case Else
						strSQL = strSQL & "    AND SBNNO    = '" & CF_Ora_String(pin_usrUDNTRA(intCnt2).SBNNO, 20) & "' "
				End Select
				
				'SQL���s
				bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTRA, strSQL)
				If bolRet = False Then
					GoTo AE_GET_URIInf_DATNO_Err
				End If
				
				'�������ʎ擾
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				curKensu = CF_Ora_GetDyn(usrOdy_UDNTRA, "CNT", 0)
				
				'�N���[�Y
				Call CF_Ora_CloseDyn(usrOdy_UDNTRA)
				
				If curKensu <> 0 Then
					'�X�V�Ώۂ����݂���`�[�ɕԕi�����݂��邩�`�F�b�N
					strRet_HNPN = AE_CHK_URIInf_HNPN(strDATNO_Esc, pin_usrUDNTHA, pin_usrUDNTRA)
					If Mid(strRet_HNPN, 2, 1) = "0" Then
						'�X�V�ΏۊO�Ƃ���
						curKensu = 0
					End If
				End If
				
				'�X�V�Ώۂ̖��ׂ����݂��Ă���ꍇ
				If curKensu > 0 Then
					
					ReDim Preserve strDATNO(intCnt)
					ReDim Preserve strFDNNO(intCnt)
					ReDim Preserve bolAKAKRO(intCnt)
					ReDim Preserve strSSADT(intCnt)
					ReDim Preserve strKESDT(intCnt)
					ReDim Preserve strODNNO_Get(intCnt)
					ReDim Preserve strUDNNO_KRO(intCnt)
					ReDim Preserve strUDNNO_AKA(intCnt)
					' === 20070331 === INSERT S - ACE)Nagasawa ��������ԕi�Ή�
					ReDim Preserve strFDNNO_KRO(intCnt)
					ReDim Preserve strFDNNO_AKA(intCnt)
					' === 20070331 === INSERT E -
					
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strDATNO(intCnt) = CF_Ora_GetDyn(usrOdy_UDNTHA, "DATNO", "") '�`�[�Ǘ��ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strFDNNO(intCnt) = CF_Ora_GetDyn(usrOdy_UDNTHA, "FDNNO", "") '�[�i���ԍ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strNXTKB = CF_Ora_GetDyn(usrOdy_UDNTHA, "NXTKB", "") '���[�敪
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strUDNDT = CF_Ora_GetDyn(usrOdy_UDNTHA, "UDNDT", "") '�`�[���t
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strDENDT = CF_Ora_GetDyn(usrOdy_UDNTHA, "DENDT", "") '������t
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSMADT = CF_Ora_GetDyn(usrOdy_UDNTHA, "SMADT", "") '�o������
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strSSADT_Chk = CF_Ora_GetDyn(usrOdy_UDNTHA, "SSADT", "") '����
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strKESDT_Chk = CF_Ora_GetDyn(usrOdy_UDNTHA, "KESDT", "") '���ϓ�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strTOKSMEKB = CF_Ora_GetDyn(usrOdy_UDNTHA, "TOKSMEKB", "") '���敪
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strTOKSMEDD = CF_Ora_GetDyn(usrOdy_UDNTHA, "TOKSMEDD", "") '���������t(����)
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strTOKSMECC = CF_Ora_GetDyn(usrOdy_UDNTHA, "TOKSMECC", "") '���T�C�N��(����)
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strTOKSDWKB = CF_Ora_GetDyn(usrOdy_UDNTHA, "TOKSDWKB", "") '���ߗj��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strTOKKESCC = CF_Ora_GetDyn(usrOdy_UDNTHA, "TOKKESCC", "") '����T�C�N��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strTOKKESDD = CF_Ora_GetDyn(usrOdy_UDNTHA, "TOKKESDD", "") '������t
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strTOKKDWKB = CF_Ora_GetDyn(usrOdy_UDNTHA, "TOKKDWKB", "") '����j��
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strUDNNO_KRO(intCnt) = CF_Ora_GetDyn(usrOdy_UDNTHA, "UDNNO", "") '����`�[�ԍ�
					' === 20070331 === INSERT S - ACE)Nagasawa ��������ԕi�Ή�
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					strFDNNO_KRO(intCnt) = CF_Ora_GetDyn(usrOdy_UDNTHA, "FDNNO", "") '�[�i���ԍ�
					' === 20070331 === INSERT E -
					
					'�ԕi���������Ă���ꍇ�͐ԍ��쐬
					If Mid(strRet_HNPN, 1, 1) = "1" Then
						bolAKAKRO(intCnt) = True
						intODNNO_GetSu = intODNNO_GetSu + 1
						intUDNNO_GetSu = intUDNNO_GetSu + 2
						strUDNNO_KRO(intCnt) = "" '����`�[�ԍ�(�̔ԑΏۂƂ���)
						' === 20070331 === INSERT S - ACE)Nagasawa ��������ԕi�Ή�
						strFDNNO_KRO(intCnt) = "" '�[�i���ԍ�(�̔ԑΏۂƂ���)
						' === 20070331 === INSERT E -
					Else
						'���܂������ǂ������f����
						intRet = AE_UpdateURI_Chk_AkaKro(pin_usrUDNTHA.UDNDT, strSMADT, strSSADT_Chk)
						If intRet = 0 Then
							bolAKAKRO(intCnt) = False
						Else
							bolAKAKRO(intCnt) = True
						End If
					End If
					
					'�����v�Z(�`�[���t�������������z����ꍇ�̂݁j
					If strSSADT_Chk < CF_Ora_Date(pin_usrUDNTHA.UDNDT) Then
						intRet = AE_GetSMEDT(pin_usrUDNTHA.UDNDT, strTOKSMEKB, strTOKSMEDD, strTOKSMECC, strTOKSDWKB, CShort(strNXTKB), strDate)
						If intRet = 0 Then
							strSSADT(intCnt) = strDate
							strSSADT_Chk_Calc = strDate
						Else
							GoTo AE_GET_URIInf_DATNO_Err
						End If
						
						'���Z���t�v�Z
						intRet = AE_GetKESDT(strSSADT(intCnt), strTOKSMEKB, strTOKKESCC, strTOKKESDD, strTOKKDWKB, pin_usrUDNTHA.SSAKBN, strDate)
						If intRet = 0 Then
							strKESDT(intCnt) = strDate
						Else
							GoTo AE_GET_URIInf_DATNO_Err
						End If
					Else
						strSSADT(intCnt) = strSSADT_Chk
						strKESDT(intCnt) = strKESDT_Chk
						
						'���������Z�o�i�`�F�b�N�p)
						intRet = AE_GetSMEDT(pin_usrUDNTHA.UDNDT, strTOKSMEKB, strTOKSMEDD, strTOKSMECC, strTOKSDWKB, CShort(strNXTKB), strSSADT_Chk_Calc)
					End If
					
					If bolAKAKRO(intCnt) = True Then
						'�ő�o�������i�[
						If strSMADT < CF_Ora_Date(pin_usrUDNTHA.UDNDT) Then
							If strSMADT_MAX < strSMADT Then
								strSMADT_MAX = strSMADT
							End If
						End If
						
						'�ő吿�������i�[
						If strSSADT_Chk < CF_Ora_Date(pin_usrUDNTHA.UDNDT) Then
							If strSSADT_MAX < strSSADT_Chk Then
								strSSADT_MAX = strSSADT_Chk
							End If
						End If
					End If
					
					'�ő�`�[���t�i�[
					If strDENDT_MAX < strDENDT Then
						strDENDT_MAX = strDENDT
					End If
					
					'�������ߓ��`�F�b�N
					If strSSADT_Chk_Calc < strSSADT_Chk Then
						pin_usrUDNTHA.strErr = "SSADT_ERR"
					End If
					
					intCnt = intCnt + 1
					Exit For
				End If
			Next 
			
			Call CF_Ora_MoveNext(usrOdy_UDNTHA)
		Loop 
		
		'�擾�������e��߂�l�Ɋi�[
		pin_usrUDNTHA.DATNO = VB6.CopyArray(strDATNO) '�`�[�Ǘ��ԍ�
		pin_usrUDNTHA.FDNNO = VB6.CopyArray(strFDNNO) '�[�i���ԍ�
		pin_usrUDNTHA.bolAKAKRO = VB6.CopyArray(bolAKAKRO) '�ԍ��敪
		pin_usrUDNTHA.SSADT = VB6.CopyArray(strSSADT) '��������
		pin_usrUDNTHA.KESDT = VB6.CopyArray(strKESDT) '���ϓ�
		pin_usrUDNTHA.UDNDENDT_Chk = strDENDT_MAX '������t�i�󒍒������`�F�b�N�p�j
		pin_usrUDNTHA.SMADT_Chk = strSMADT_MAX '�o�������i�󒍒������`�F�b�N�p�j
		pin_usrUDNTHA.SSADT_Chk = strSSADT_MAX '���������i�󒍒������`�F�b�N�p�j
		pin_usrUDNTHA.ODNNO = VB6.CopyArray(strODNNO_Get) '�o�ד`�[�ԍ�
		pin_usrUDNTHA.UDNNO_KRO = VB6.CopyArray(strUDNNO_KRO) '����`�[�ԍ�
		pin_usrUDNTHA.UDNNO_AKA = VB6.CopyArray(strUDNNO_AKA) '����`�[�ԍ�
		' === 20070331 === INSERT S - ACE)Nagasawa ��������ԕi�Ή�
		pin_usrUDNTHA.FDNNO_KRO = VB6.CopyArray(strFDNNO_KRO) '�[�i���ԍ�
		pin_usrUDNTHA.FDNNO_AKA = VB6.CopyArray(strFDNNO_AKA) '�[�i���ԍ�
		' === 20070331 === INSERT E -
		pin_usrUDNTHA.ODNNO_GetSu = intODNNO_GetSu '�o�ד`�[�ԍ��̔Ԑ�
		pin_usrUDNTHA.UDNNO_GetSu = intUDNNO_GetSu '����`�[�ԍ��̔Ԑ�
		
		AE_GET_URIInf_DATNO = 0
		
AE_GET_URIInf_DATNO_End: 
		If bolTran = True Then
			'���R�[�h�Z�b�g�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_UDNTHA)
		End If
		
		Exit Function
		
AE_GET_URIInf_DATNO_Err: 
		GoTo AE_GET_URIInf_DATNO_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_UpdateURI_Chk
	'   �T�v�F  ��������`�F�b�N
	'   �����F  pin_strKJNDT    : �������i���͂����������j
	'           pin_strDENDT  �@: ������t�i�����`�[�̏ꍇ�͍ő�̂��́j
	'           pin_strSMADT  �@: �o�������i�����`�[�̏ꍇ�͍ő�̂��́j
	'           pin_strSSADT  �@: ���������i�����`�[�̏ꍇ�͍ő�̂��́j
	'           pin_strTOKCD  �@: ���Ӑ�R�[�h
	'   �ߒl�F  0�F����@1: �����������߂��@2: ���������߂� 3:������t�ȑO�@9: �ُ�
	'   ���l�F  ����`�[�̌o�����ߓ��A�������݂āA������ԍ�������������t���ǂ���
	'�@�@�@�@�@ ���f����i���߂��s���Ă�����t�͓��͕s�j
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_UpdateURI_Chk(ByVal pin_strKJNDT As String, ByVal pin_strDENDT As String, ByVal pin_strSMADT As String, ByVal pin_strSSADT As String, ByVal pin_strTOKCD As String) As Short
		
		Dim strSMEDT As String
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� Mst_Inf_SYSTBA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Mst_Inf_SYSTBA As TYPE_DB_SYSTBA
		Dim Mst_Inf_TOKMTA As TYPE_DB_TOKMTA
		Dim intRet As Short
		
		AE_UpdateURI_Chk = 9
		
		Call DB_SYSTBA_Clear(Mst_Inf_SYSTBA)
		
		'���[�U�[���Ǘ��e�[�u������
		If SYSTBA_SEARCH(Mst_Inf_SYSTBA) <> 0 Then
			Exit Function
		End If
		
		'����`�[���t���ȑO�̓��t�̓G���[
		If CF_Ora_Date(pin_strKJNDT) < pin_strDENDT Then
			AE_UpdateURI_Chk = 3
			Exit Function
		End If
		
		'���������߂��s���Ă���ꍇ����ƌo�������̔�r
		If Trim(Mst_Inf_SYSTBA.UKSMEDT) <> "" Then
			If CF_Ora_Date(pin_strSMADT) <= Mst_Inf_SYSTBA.UKSMEDT Then
				If CF_Ora_Date(pin_strKJNDT) <= CF_Ora_Date(pin_strSMADT) Then
					AE_UpdateURI_Chk = 1
					Exit Function
				End If
			End If
		End If
		
		Call DB_TOKMTA_Clear(Mst_Inf_TOKMTA)
		
		'���Ӑ�}�X�^����
		If DSPTOKCD_SEARCH(pin_strTOKCD, Mst_Inf_TOKMTA) <> 0 Then
			Exit Function
		End If
		
		'�������߂��s���Ă���ꍇ����Ɛ��������̔�r
		If Trim(Mst_Inf_TOKMTA.TOKSMEDT) <> "" Then
			If CF_Ora_Date(pin_strSSADT) <= Mst_Inf_TOKMTA.TOKSMEDT Then
				If CF_Ora_Date(pin_strKJNDT) <= CF_Ora_Date(pin_strSSADT) Then
					AE_UpdateURI_Chk = 2
					Exit Function
				End If
			End If
		End If
		
		'�ԍ��`�[����������ꍇ�x��
		If CF_Get_CCurString(pin_strSSADT) <> 0 Then
			If CF_Ora_Date(pin_strKJNDT) > pin_strSSADT Then
				AE_UpdateURI_Chk = 4
				Exit Function
			End If
		End If
		If CF_Get_CCurString(pin_strSMADT) <> 0 Then
			If CF_Ora_Date(pin_strKJNDT) > pin_strSMADT Then
				AE_UpdateURI_Chk = 4
				Exit Function
			End If
		End If
		
		AE_UpdateURI_Chk = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_UpdateURI_Chk_AkaKro
	'   �T�v�F  ��������`�F�b�N(�ԍ�����)
	'   �����F  pin_strKJNDT    : �������i�`�[���t�j
	'           pin_strSMADT  �@: �o������
	'           pin_strSSADT  �@: ��������
	'   �ߒl�F  0�F����@1: �����������߂��@2: ���������߂� 9: �ُ�
	'   ���l�F  ����`�[�̌o�������A�����������݂āA������ԍ�������������t���ǂ���
	'�@�@�@�@�@ ���f����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_UpdateURI_Chk_AkaKro(ByVal pin_strKJNDT As String, ByVal pin_strSMADT As String, ByVal pin_strSSADT As String) As Short
		
		Dim strSMEDT As String
		Dim strSQL As String
		Dim intRet As Short
		
		AE_UpdateURI_Chk_AkaKro = 9
		
		'�o�������`�F�b�N
		If CF_Ora_Date(pin_strKJNDT) > pin_strSMADT Then
			AE_UpdateURI_Chk_AkaKro = 1
			Exit Function
		End If
		
		'������̒����`�F�b�N
		If CF_Ora_Date(pin_strKJNDT) > pin_strSSADT Then
			AE_UpdateURI_Chk_AkaKro = 2
			Exit Function
		End If
		
		AE_UpdateURI_Chk_AkaKro = 0
		
	End Function
	
	'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    �A���[��768
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   ���́F  Function AE_URIinf_UPDATE
	''   �T�v�F  ������X�V����
	''   �����F  pin_usrURITHA     : ���㌩�o�����
	''   �@�@�@  pin_usrURITRA     : ������
	''   �ߒl�F  0�F����@9: �ُ�
	''   ���l�F  �p�����[�^�̒l�����ɔ�������X�V����
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function AE_URIinf_UPDATE(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, _
	''                                 ByRef pin_usrURITRA() As Cmn_UDNTRA_Upd) As Integer
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_URIinf_UPDATE
	'   �T�v�F  ������X�V����
	'   �����F  pin_usrURITHA     : ���㌩�o�����
	'   �@�@�@  pin_usrURITRA     : ������
	'   �@�@�@  pin_Upd_Inf       : �󒍒������̍��ڂ̓��͉ې���
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  �p�����[�^�̒l�����ɔ�������X�V����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_URIinf_UPDATE(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA() As Cmn_UDNTRA_Upd, ByRef pin_Upd_Inf As Cmn_JDNUPDATE_Enable) As Short
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		
		Dim intCnt As Short
		Dim intRet As Short
		
		On Error GoTo AE_URIinf_UPDATE_Err
		
		AE_URIinf_UPDATE = 9
		
		'����g�����X�V
		'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    �A���[��768
		'    intRet = AE_URIINF_UDNTRA_UPD_Main(pin_usrURITHA, pin_usrURITRA)
		intRet = AE_URIINF_UDNTRA_UPD_Main(pin_usrURITHA, pin_usrURITRA, pin_Upd_Inf)
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		If intRet <> 0 Then
			GoTo AE_URIinf_UPDATE_Err
		End If
		
		'����f�[�^�̍X�V�ΏۑS�Ăɑ΂��X�V���s��
		For intCnt = 1 To UBound(pin_usrURITHA.DATNO)
			
			'���㌩�o���g�����X�V
			intRet = AE_URIINF_UDNTHA_UPD_Main(pin_usrURITHA, intCnt)
			If intRet <> 0 Then
				GoTo AE_URIinf_UPDATE_Err
			End If
			
			'���z�̏W�v
			pin_usrURITHA.curSUrikn_New = pin_usrURITHA.curSUrikn_New + pin_usrURITHA.curUrikn_New(intCnt)
			pin_usrURITHA.curSUrikn_Old = pin_usrURITHA.curSUrikn_Old + pin_usrURITHA.curUrikn_Old(intCnt)
			pin_usrURITHA.curSFUrikn_New = pin_usrURITHA.curSFUrikn_New + pin_usrURITHA.curFUrikn_New(intCnt)
			pin_usrURITHA.curSFUrikn_Old = pin_usrURITHA.curSFUrikn_Old + pin_usrURITHA.curFUrikn_Old(intCnt)
			pin_usrURITHA.curSUzeikn_New = pin_usrURITHA.curSUzeikn_New + pin_usrURITHA.curUzeikn_New(intCnt)
			pin_usrURITHA.curSUzeikn_Old = pin_usrURITHA.curSUzeikn_Old + pin_usrURITHA.curUzeikn_Old(intCnt)
		Next 
		
		'���|�T�}���X�V
		intRet = AE_TOKSINF_UPDATE(pin_usrURITHA)
		If intRet <> 0 Then
			GoTo AE_URIinf_UPDATE_Err
		End If
		
		'�̔��P�������}�X�^�̍X�V
		intRet = AE_TOKMTB_UPD_Main(pin_usrURITHA, pin_usrURITRA)
		If intRet <> 0 Then
			GoTo AE_URIinf_UPDATE_Err
		End If
		
		AE_URIinf_UPDATE = 0
		
AE_URIinf_UPDATE_End: 
		Exit Function
		
AE_URIinf_UPDATE_Err: 
		GoTo AE_URIinf_UPDATE_End
		
	End Function
	
	'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    �A���[��768
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   ���́F  Function AE_URIINF_UDNTRA_UPD_Main
	''   �T�v�F  ����g�����X�V
	''   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	''   �@�@�@  pin_usrURITRA     : ����g�����X�V���
	''   �ߒl�F  0�F����@9: �ُ�
	''   ���l�F  ����g�����̒ǉ��A�X�V���s��
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Private Function AE_URIINF_UDNTRA_UPD_Main(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, _
	''                                           ByRef pin_usrURITRA() As Cmn_UDNTRA_Upd) As Integer
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_URIINF_UDNTRA_UPD_Main
	'   �T�v�F  ����g�����X�V
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �@�@�@  pin_usrURITRA     : ����g�����X�V���
	'   �@�@�@  pin_Upd_Inf       : �󒍒������̍��ڂ̓��͉ې���
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  ����g�����̒ǉ��A�X�V���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTRA_UPD_Main(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA() As Cmn_UDNTRA_Upd, ByRef pin_Upd_Inf As Cmn_JDNUPDATE_Enable) As Short
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		
		Dim bolRet As Boolean
		Dim intCntH As Short
		Dim intCntR As Short
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy_UDNTRA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_UDNTRA As U_Ody
		Dim bolTran As Boolean
		Dim curURISU As Decimal
		Dim curUZEIKN As Decimal
		Dim bolUpd As Boolean
		Dim usrUDNTRA As Cmn_UDNTRA_Upd
		Dim Init_TRA As Cmn_UDNTRA_Upd
		Dim strODNNO As String
		Dim strRecNo As String
		Dim curHNPNSU As Decimal
		Dim curHNPNKN As Decimal
		Dim curHNPNZKN As Decimal
		Dim curHNPNFKN As Decimal
		' === 20071213 === INSERT S - ACE)Nagasawa �������o�͋敪�̒ǉ�
		Dim strMRPKB As String
		Dim strMRPKB_BFR As String
		Dim strSSADT_BFR As String
		' === 20071213 === INSERT E -
		
		On Error GoTo AE_URIINF_UDNTRA_UPD_Main_Err
		
		AE_URIINF_UDNTRA_UPD_Main = 9
		
		bolTran = False
		
		'�`�[���v���z������
		With pin_usrURITHA
			ReDim .curUrikn_Old(UBound(.DATNO))
			ReDim .curFUrikn_Old(UBound(.DATNO))
			ReDim .curUzeikn_Old(UBound(.DATNO))
			ReDim .curUrikn_New(UBound(.DATNO))
			ReDim .curFUrikn_New(UBound(.DATNO))
			ReDim .curUzeikn_New(UBound(.DATNO))
		End With
		
		Dim intRet As Short
		For intCntH = 1 To UBound(pin_usrURITHA.DATNO)
			'����g�����擾
			strSQL = ""
			strSQL = strSQL & " SELECT * "
			strSQL = strSQL & "   FROM UDNTRA "
			strSQL = strSQL & "  WHERE DATNO    = '" & CF_Ora_String(pin_usrURITHA.DATNO(intCntH), 10) & "' "
			strSQL = strSQL & "    AND JDNNO    = '" & CF_Ora_String(pin_usrURITHA.JDNNO, 10) & "' "
			strSQL = strSQL & "  ORDER BY DATNO, JDNNO, JDNLINNO "
			
			'SQL���s
			bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTRA, strSQL)
			If bolRet = False Then
				GoTo AE_URIINF_UDNTRA_UPD_Main_Err
			End If
			
			bolTran = True
			
			Do Until CF_Ora_EOF(usrOdy_UDNTRA) = True
				
				'����g�����̒l���擾
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				curURISU = CF_Ora_GetDyn(usrOdy_UDNTRA, "URISU", 0) '���㐔��
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				usrUDNTRA.URILINNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "LINNO", "") '�s�ԍ��i����g�����j
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strODNNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "ODNNO", "") '�o�ד`�[�ԍ�
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strRecNo = CF_Ora_GetDyn(usrOdy_UDNTRA, "RECNO", "") '���R�[�h�Ǘ��ԍ�
				
				'�ԕi���擾
				Call AE_GET_URIInf_HNPN(pin_usrURITHA.FDNNO(intCntH), strODNNO, strRecNo, curHNPNSU, curHNPNKN, curHNPNZKN, curHNPNFKN)
				
				'�`�[���v���z
				With pin_usrURITHA
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(usrOdy_UDNTRA, URIKN, 0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.curUrikn_Old(intCntH) = .curUrikn_Old(intCntH) - curHNPNKN + CF_Ora_GetDyn(usrOdy_UDNTRA, "URIKN", 0) '������z
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(usrOdy_UDNTRA, FURIKN, 0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.curFUrikn_Old(intCntH) = .curFUrikn_Old(intCntH) - curHNPNFKN + CF_Ora_GetDyn(usrOdy_UDNTRA, "FURIKN", 0) '�O�ݔ�����z
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(usrOdy_UDNTRA, UZEKN, 0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					.curUzeikn_Old(intCntH) = .curUzeikn_Old(intCntH) - curHNPNZKN + CF_Ora_GetDyn(usrOdy_UDNTRA, "UZEKN", 0) '����ŋ��z
				End With
				
				'�X�V�Ώۍs���ǂ����𔻒f����
				bolUpd = False
				
				For intCntR = 1 To UBound(pin_usrURITRA)
					
					'UPGRADE_WARNING: �I�u�W�F�N�g usrUDNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					usrUDNTRA = pin_usrURITRA(intCntR)
					
					'�X�V�Ώۍs�𔻒f�i�󒍎���敪�ɂ�茟�������ύX�j
					Select Case True
						'�V�X�e���󒍂ŏo�׊�̂���
						Case (pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SYS And pin_usrURITHA.URIKJN = gc_strURIKJN_SYK) Or pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SET
							'�s�ԍ���v
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Trim(CF_Ora_GetDyn(usrOdy_UDNTRA, "JDNLINNO", "")) = Trim(usrUDNTRA.LINNO) Then
								bolUpd = True
							End If
							
							'�V�X�e���󒍂ŏo�׊�ȊO�̂���
						Case pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SYS
							'���R�[�h�Ǘ��ԍ���v
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Trim(CF_Ora_GetDyn(usrOdy_UDNTRA, "RECNO", "")) = Trim(usrUDNTRA.RECNO) Then
								bolUpd = True
							End If
							
							'��L�ȊO
						Case Else
							'���Ԉ�v
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Trim(CF_Ora_GetDyn(usrOdy_UDNTRA, "SBNNO", "")) = Trim(usrUDNTRA.SBNNO) Then
								bolUpd = True
							End If
					End Select
					
					If bolUpd = True Then
						Exit For
					End If
				Next 
				
				' === 20071213 === INSERT S - ACE)Nagasawa �������o�͋敪�̒ǉ�
				'�X�V�O����g�������e�擾
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strMRPKB_BFR = CF_Ora_GetDyn(usrOdy_UDNTRA, "MRPKB", "") '���������s�敪
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strSSADT_BFR = CF_Ora_GetDyn(usrOdy_UDNTRA, "SSADT", "") '�����t
				
				strMRPKB = ""
				For intCntR = 1 To UBound(pin_usrURITHA.usrBodyInf)
					'�X�V�Ώۍs�𔻒f�i�󒍎���敪�ɂ�茟�������ύX�j
					Select Case True
						'�V�X�e���󒍂ŏo�׊�̂���
						Case (pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SYS And pin_usrURITHA.URIKJN = gc_strURIKJN_SYK) Or pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SET
							'�s�ԍ���v
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Trim(CF_Ora_GetDyn(usrOdy_UDNTRA, "JDNLINNO", "")) = Trim(pin_usrURITHA.usrBodyInf(intCntR).LINNO) Then
								strMRPKB = pin_usrURITHA.usrBodyInf(intCntR).MRPKB
								Exit For
							End If
							
							'�V�X�e���󒍂ŏo�׊�ȊO�̂���
						Case pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SYS
							'���R�[�h�Ǘ��ԍ���v
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Trim(CF_Ora_GetDyn(usrOdy_UDNTRA, "RECNO", "")) = Trim(pin_usrURITHA.usrBodyInf(intCntR).RECNO) Then
								strMRPKB = pin_usrURITHA.usrBodyInf(intCntR).MRPKB
								Exit For
							End If
							
							'��L�ȊO
						Case Else
							'���Ԉ�v
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							If Trim(CF_Ora_GetDyn(usrOdy_UDNTRA, "SBNNO", "")) = Trim(pin_usrURITHA.usrBodyInf(intCntR).SBNNO) Then
								strMRPKB = pin_usrURITHA.usrBodyInf(intCntR).MRPKB
								Exit For
							End If
					End Select
				Next 
				
				'�������o�͋敪�̔���E�ꍇ�ɂ���Ă͈ȑO�̃f�[�^���X�V
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(usrOdy_UDNTRA, LINNO, ) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				bolRet = AE_Get_MRPKB(strMRPKB_BFR, pin_usrURITHA.bolAKAKRO(intCntH), pin_usrURITHA.DATNO(intCntH), CF_Ora_GetDyn(usrOdy_UDNTRA, "LINNO", ""), strSSADT_BFR, pin_usrURITHA.SSADT(intCntH), strMRPKB)
				If bolRet = False Then
					GoTo AE_URIINF_UDNTRA_UPD_Main_Err
				End If
				' === 20071213 === INSERT E -
				
				If bolUpd = True Then
					'�X�V�Ώۍs�̏ꍇ�Čv�Z
					
					With usrUDNTRA
						'������z�ɒl���Ȃ��ꍇ�i�V�X�e���̏����A�ʔ̎󒍈ȊO�̏ꍇ�j�͍Čv�Z
						'(�ʔ̎󒍂̏ꍇ�̕ԕi�ɂ��Čv�Z���W�b�N���Ȃ��̂͒ʔ̎󒍂͑S���ԕi�̂ݍs������)
						If .URIKN = 0 Then
							'������z�Čv�Z
							.URIKN = .URITK * (curURISU - curHNPNSU)
							'�O�ݔ�����z�Čv�Z
							.FURIKN = .FURITK * (curURISU - curHNPNSU)
							'����Ŋz�Čv�Z
							If .FURITK <> 0 Then
								.UZEKN = 0
							Else
								bolRet = AE_CalcTAX_Meisai(.HINZEIKB, CDec(.ZEIRT), .URITK, curURISU - curHNPNSU, pin_usrURITHA.TOKZEIKB, pin_usrURITHA.TOKRPSKB, pin_usrURITHA.TOKZRNKB, curUZEIKN)
								If bolRet = True Then
									.UZEKN = curUZEIKN
								Else
									GoTo AE_URIINF_UDNTRA_UPD_Main_Err
								End If
							End If
						Else
							If curHNPNSU > 0 Then
								'������z
								.URIKN = 0
								'�O�ݔ�����z
								.FURIKN = 0
								'����Ŋz
								.UZEKN = 0
							End If
						End If
						
						'�d�؋��z�擾
						If Trim(.SIKTK) <> "" Then
							.SIKKN = (curURISU - curHNPNSU) * CF_Get_CCurString(.SIKTK)
						Else
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.SIKTK = CF_Ora_GetDyn(usrOdy_UDNTRA, "SIKTK", 0)
							'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
							.SIKKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "SIKKN", 0)
							
							If curHNPNSU > 0 Then
								'�ԕi������ꍇ�͍Čv�Z
								'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
								.SIKKN = CDec(CF_Ora_GetDyn(usrOdy_UDNTRA, "SIKTK", 0)) * (curURISU - curHNPNSU)
							End If
						End If
						
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.URILINNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "LINNO", "")
						.URISU = (curURISU - curHNPNSU) '���㐔��
						
						' === 20071213 === INSERT S - ACE)Nagasawa �������o�͋敪�̒ǉ�
						.MRPKB = strMRPKB '�������o�͋敪
						' === 20071213 === INSERT E -
						
					End With
				Else
					'����g�����̒l�����̂܂܊i�[
					'UPGRADE_WARNING: �I�u�W�F�N�g usrUDNTRA �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					usrUDNTRA = Init_TRA
					With usrUDNTRA
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.JDNNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "JDNNO", "") '�󒍔ԍ�
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.LINNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "JDNLINNO", "") '�s�ԍ�
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.URILINNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "LINNO", "") '�s�ԍ�(����g�����j
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.RECNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "RECNO", "") '���R�[�h�Ǘ��ԍ�
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SBNNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "SBNNO", "") '����
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.HINCD = CF_Ora_GetDyn(usrOdy_UDNTRA, "HINCD", "") '���i�R�[�h
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.TOKJDNNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "TOKJDNNO", "") '�q�撍���ԍ�
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.BIKO = CF_Ora_GetDyn(usrOdy_UDNTRA, "LINCMA", "") '���l
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.URISU = CF_Ora_GetDyn(usrOdy_UDNTRA, "URISU", 0) '���㐔��
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.URITK = CF_Ora_GetDyn(usrOdy_UDNTRA, "URITK", 0) '�P��
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.FURITK = CF_Ora_GetDyn(usrOdy_UDNTRA, "FURITK", 0) '�O�ݒP��
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SIKTK = CF_Ora_GetDyn(usrOdy_UDNTRA, "SIKTK", 0) '�d�ؒP��
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.URIKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "URIKN", 0) '������z
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.FURIKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "FURIKN", 0) '�O�ݔ�����z
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.SIKKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "SIKKN", 0) '�d�؋��z
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.UZEKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "UZEKN", 0) '����Ŋz
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.HINZEIKB = CF_Ora_GetDyn(usrOdy_UDNTRA, "HINZEIKB", "") '���i����ŋ敪
						'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
						.ZEIRT = CF_Ora_GetDyn(usrOdy_UDNTRA, "ZEIRT", 0) '�ŗ�
						' === 20071213 === INSERT S - ACE)Nagasawa �������o�͋敪�̒ǉ�
						.MRPKB = strMRPKB '�������o�͋敪
						' === 20071213 === INSERT E -
						
						'�ԕi������ꍇ�͋��z�Čv�Z
						If curHNPNSU > 0 Then
							.URISU = .URISU - curHNPNSU '���㐔��
							.URIKN = .URITK * .URISU '������z
							.FURIKN = .FURITK * .URISU '�O�ݔ�����z
							.SIKKN = CDbl(.SIKTK) * .URISU '�d�؋��z
							'����Ŋz
							bolRet = AE_CalcTAX_Meisai(.HINZEIKB, CDec(.ZEIRT), .URITK, .URISU, pin_usrURITHA.TOKZEIKB, pin_usrURITHA.TOKRPSKB, pin_usrURITHA.TOKZRNKB, curUZEIKN)
							If bolRet = True Then
								.UZEKN = curUZEIKN
							Else
								GoTo AE_URIINF_UDNTRA_UPD_Main_Err
							End If
						End If
					End With
					
				End If
				
				'�ԕi�t���O
				If curHNPNSU > 0 Then
					usrUDNTRA.bolHNPN = True
					usrUDNTRA.HNURIKN = curHNPNKN '�ԕi��������z
					usrUDNTRA.HNFURIKN = curHNPNFKN '�ԕi���O�ݔ�����z
					usrUDNTRA.HNUZEKN = curHNPNZKN '�ԕi������ŋ��z
				Else
					usrUDNTRA.bolHNPN = False
					usrUDNTRA.HNURIKN = 0 '�ԕi��������z
					usrUDNTRA.HNFURIKN = 0 '�ԕi���O�ݔ�����z
					usrUDNTRA.HNUZEKN = 0 '�ԕi������ŋ��z
				End If
				
				'�`�[���v���z
				With pin_usrURITHA
					.curUrikn_New(intCntH) = .curUrikn_New(intCntH) + usrUDNTRA.URIKN '������z
					.curFUrikn_New(intCntH) = .curFUrikn_New(intCntH) + usrUDNTRA.FURIKN '�O�ݔ�����z
					.curUzeikn_New(intCntH) = .curUzeikn_New(intCntH) + usrUDNTRA.UZEKN '����ŋ��z
				End With
				
				Call CF_Ora_MoveNext(usrOdy_UDNTRA)
				
				If curURISU - curHNPNSU > 0 Then
					'���`�[�̍쐬
					strSQL = AE_URIINF_UDNTRA_INS_KRO_SQL(pin_usrURITHA, usrUDNTRA, CStr(intCntH))
					
					'�r�p�k���s
					bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
					If bolRet = False Then
						GoTo AE_URIINF_UDNTRA_UPD_Main_Err
					End If
					
					'''' ADD 2009/12/23  FKS) T.Yamamoto    Start    �A���[��768
					'�V�����Ή�
					If pin_Upd_Inf.bolNYU = True Then
						intRet = F_GRKBP98_RunStored(CF_Ora_String(SSS_CLTID.Value, 5), CF_Ora_String(SSS_OPEID.Value, 8), pin_usrURITHA.DATNO(intCntH), usrUDNTRA.URILINNO)
						If intRet <> 0 Then
							GoTo AE_URIINF_UDNTRA_UPD_Main_Err
						End If
					End If
					'''' ADD 2009/12/23  FKS) T.Yamamoto    End
				End If
				
				'�ԓ`�[�̍쐬
				If pin_usrURITHA.bolAKAKRO(intCntH) = True Then
					If curURISU - curHNPNSU > 0 Then
						'�ԓ`�[INSERT
						strSQL = AE_URIINF_UDNTRA_INS_AKA_SQL(pin_usrURITHA, usrUDNTRA, CStr(intCntH))
					Else
						strSQL = ""
					End If
				Else
					'���f�[�^�̓`�[�Ǘ��ԍ���"�폜"�ɂ���
					strSQL = AE_URIINF_UDNTRA_UPD_SQL(pin_usrURITHA, usrUDNTRA, CStr(intCntH))
				End If
				
				'�r�p�k���s
				If Trim(strSQL) <> "" Then
					bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
					If bolRet = False Then
						GoTo AE_URIINF_UDNTRA_UPD_Main_Err
					End If
				End If
				
			Loop 
			
			'�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_UDNTRA)
			bolTran = False
			
		Next 
		
		AE_URIINF_UDNTRA_UPD_Main = 0
		bolTran = False
		
AE_URIINF_UDNTRA_UPD_Main_End: 
		If bolTran = True Then
			'���R�[�h�Z�b�g�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_UDNTRA)
		End If
		
		Exit Function
		
AE_URIINF_UDNTRA_UPD_Main_Err: 
		'�G���[�ӏ��ҏW
		pin_usrURITHA.strErr = "AE_URIINF_UDNTRA_UPD_Main"
		GoTo AE_URIINF_UDNTRA_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_URIINF_UDNTHA_UPD_Main
	'   �T�v�F  ���㌩�o���g�����X�V
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �@�@�@  pin_intCnt�@      : �ԍ�
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  ���㌩�o���g�����ɒǉ��A�X�V���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTHA_UPD_Main(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByVal pin_intCnt As Short) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		
		On Error GoTo AE_URIINF_UDNTHA_UPD_Main_Err
		
		AE_URIINF_UDNTHA_UPD_Main = 9
		
		'���`�[�̍쐬
		strSQL = AE_URIINF_UDNTHA_INS_KRO_SQL(pin_usrURITHA, CStr(pin_intCnt))
		
		'�r�p�k���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_URIINF_UDNTHA_UPD_Main_Err
		End If
		
		'�ԓ`�[�̍쐬
		If pin_usrURITHA.bolAKAKRO(pin_intCnt) = True Then
			'�ԓ`�[INSERT
			strSQL = AE_URIINF_UDNTHA_INS_AKA_SQL(pin_usrURITHA, CStr(pin_intCnt))
		Else
			'���f�[�^�̓`�[�Ǘ��ԍ���"�폜"�ɂ���
			strSQL = AE_URIINF_UDNTHA_UPD_SQL(pin_usrURITHA, CStr(pin_intCnt))
		End If
		
		'�r�p�k���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_URIINF_UDNTHA_UPD_Main_Err
		End If
		
		AE_URIINF_UDNTHA_UPD_Main = 0
		
AE_URIINF_UDNTHA_UPD_Main_End: 
		
		Exit Function
		
AE_URIINF_UDNTHA_UPD_Main_Err: 
		'�G���[�ӏ��ҏW
		pin_usrURITHA.strErr = "AE_URIINF_UDNTHA_UPD_Main"
		GoTo AE_URIINF_UDNTHA_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_URIINF_UDNTHA_INS_KRO_SQL
	'   �T�v�F  ���㌩�o���g�������`�[�쐬SQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �@�@�@  pin_intCnt�@      : �ԍ�
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTHA_INS_KRO_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByVal pin_intCnt As String) As String
		
		Dim strSQL As String
		
		AE_URIINF_UDNTHA_INS_KRO_SQL = ""
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO UDNTHA "
		strSQL = strSQL & "      ( DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "      , AKAKROKB " '�ԍ��敪
		strSQL = strSQL & "      , DENKB " '�`�[�敪
		strSQL = strSQL & "      , UDNNO " '����`�[�ԍ�
		strSQL = strSQL & "      , FDNNO " '�[�i����
		strSQL = strSQL & "      , JDNNO " '�󒍓`�[�ԍ�
		strSQL = strSQL & "      , USDNO " '�����`�[NO
		strSQL = strSQL & "      , UDNDT " '����`�[���t
		strSQL = strSQL & "      , DENDT " '������t
		strSQL = strSQL & "      , REGDT " '����`�[���t
		strSQL = strSQL & "      , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , TOKRN " '���Ӑ旪��
		strSQL = strSQL & "      , NHSCD " '�[����R�[�h
		strSQL = strSQL & "      , NHSRN " '�[���旪��
		strSQL = strSQL & "      , NHSNMA " '�[���於�̂P
		strSQL = strSQL & "      , NHSNMB " '�[���於�̂Q
		strSQL = strSQL & "      , TANCD " '�S���҃R�[�h
		strSQL = strSQL & "      , TANNM " '�S���Җ�
		strSQL = strSQL & "      , BUMCD " '����R�[�h
		strSQL = strSQL & "      , BUMNM " '���喼
		strSQL = strSQL & "      , TOKSEICD " '������R�[�h
		strSQL = strSQL & "      , SOUCD " '�q�ɃR�[�h
		strSQL = strSQL & "      , SOUNM " '�q�ɖ�
		strSQL = strSQL & "      , NXTKB " '���[�敪
		strSQL = strSQL & "      , NXTNM " '���[����
		strSQL = strSQL & "      , EMGODNKB " '�ً}�o�׋敪
		strSQL = strSQL & "      , OKRJONO " '�����
		strSQL = strSQL & "      , INVNO " '�C���{�C�X��
		strSQL = strSQL & "      , SMADT " '�o�������t
		strSQL = strSQL & "      , SSADT " '�����t
		strSQL = strSQL & "      , KESDT " '���ϓ��t
		strSQL = strSQL & "      , NYUCD " '�����敪
		strSQL = strSQL & "      , ZKTKB " '����敪
		strSQL = strSQL & "      , ZKTNM " '����敪��
		strSQL = strSQL & "      , KENNMA " '�����P
		strSQL = strSQL & "      , KENNMB " '�����Q
		strSQL = strSQL & "      , NHSADA " '�[����Z���P
		strSQL = strSQL & "      , NHSADB " '�[����Z���Q
		strSQL = strSQL & "      , NHSADC " '�[����Z���R
		strSQL = strSQL & "      , MAEUKNM " '�O��敪����
		strSQL = strSQL & "      , KEIBUMCD " '�o������R�[�h
		strSQL = strSQL & "      , UPFKB " '���㓯���o�׋敪
		strSQL = strSQL & "      , SBAURIKN " '������z(�{�̍��v)
		strSQL = strSQL & "      , SBAUZEKN " '������z(����Ŋz)
		strSQL = strSQL & "      , SBAUZKKN " '������z(�`�[�v)
		strSQL = strSQL & "      , SBAFRUKN " '�O�ݔ�����z(�`�[�v)
		strSQL = strSQL & "      , SBANYUKN " '�������z(�`�[�v)
		strSQL = strSQL & "      , SBAFRNKN " '�O�ݓ����z(�`�[�v)
		strSQL = strSQL & "      , DENCM " '���l
		strSQL = strSQL & "      , DENCMIN " '�Г����l
		strSQL = strSQL & "      , TOKSMEKB " '���敪
		strSQL = strSQL & "      , TOKSMEDD " '���������t(����)
		strSQL = strSQL & "      , TOKSMECC " '���T�C�N��(����)
		strSQL = strSQL & "      , TOKSDWKB " '���ߗj��
		strSQL = strSQL & "      , TOKKESCC " '����T�C�N��
		strSQL = strSQL & "      , TOKKESDD " '������t
		strSQL = strSQL & "      , TOKKDWKB " '����j��
		strSQL = strSQL & "      , LSTID " '�`�[���
		strSQL = strSQL & "      , TOKJUNKB " '���ʕ\�o�͋敪
		strSQL = strSQL & "      , TOKMSTKB " '�}�X�^�敪(���Ӑ�)
		strSQL = strSQL & "      , TKNRPSKB " '���z�[����������
		strSQL = strSQL & "      , TKNZRNKB " '���z�[�������敪
		strSQL = strSQL & "      , TOKZEIKB " '����ŋ敪
		strSQL = strSQL & "      , TOKZCLKB " '����ŎZ�o�敪
		strSQL = strSQL & "      , TOKRPSKB " '����Œ[����������
		strSQL = strSQL & "      , TOKZRNKB " '����Œ[�������敪
		strSQL = strSQL & "      , TOKNMMKB " '�����ƭ�ً敪
		strSQL = strSQL & "      , NHSMSTKB " '�}�X�^�敪(�[����)
		strSQL = strSQL & "      , NHSNMMKB " '�����ƭ�ً敪
		strSQL = strSQL & "      , TANMSTKB " '�}�X�^�敪(�S����)
		strSQL = strSQL & "      , URIKJN " '����
		strSQL = strSQL & "      , MAEUKKB " '�O��敪
		strSQL = strSQL & "      , SEIKB " '�����敪
		strSQL = strSQL & "      , JDNTRKB " '�󒍎���敪
		strSQL = strSQL & "      , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "      , FRNKB " '�C�O����敪
		strSQL = strSQL & "      , UDNPRAKB " '�[�i�����s�敪
		strSQL = strSQL & "      , UDNPRBKB " '�ʐ������s�敪
		strSQL = strSQL & "      , MOTDATNO " '���`�[�Ǘ��ԍ�
		strSQL = strSQL & "      , FOPEID " '����o�^���[�U�[�h�c
		strSQL = strSQL & "      , FCLTID " '����o�^�N���C�A���g�h�c
		strSQL = strSQL & "      , WRTFSTTM " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "      , WRTFSTDT " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "      , OPEID " '���[�U�[�h�c�i�����j
		strSQL = strSQL & "      , CLTID " '�N���C�A���g�h�c�i�����j
		strSQL = strSQL & "      , WRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      , WRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      , UOPEID " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UCLTID " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UWRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      , UWRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      , PGID " '�o�f�h�c
		strSQL = strSQL & "      , DLFLG " '�폜�t���O
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        '" & CF_Ora_String(pin_usrURITHA.DATNO_KRO(CInt(pin_intCnt)), 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "      , AKAKROKB " '�ԍ��敪
		strSQL = strSQL & "      , DENKB " '�`�[�敪
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.UDNNO_KRO(CInt(pin_intCnt)), 8) & "' " '����`�[�ԍ�
		' === 20070331 === INSERT S - ACE)Nagasawa ��������ԕi�Ή�
		'    strSQL = strSQL & "      , FDNNO "          '�[�i����
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.FDNNO_KRO(CInt(pin_intCnt)), 8) & "' " '�[�i���ԍ�
		' === 20070331 === INSERT E -
		strSQL = strSQL & "      , JDNNO " '�󒍓`�[�ԍ�
		strSQL = strSQL & "      , USDNO " '�����`�[NO
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.UDNDT) & "' " '����`�[���t
		strSQL = strSQL & "      , DENDT " '������t
		strSQL = strSQL & "      , REGDT " '����`�[���t
		strSQL = strSQL & "      , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , TOKRN " '���Ӑ旪��
		strSQL = strSQL & "      , NHSCD " '�[����R�[�h
		strSQL = strSQL & "      , NHSRN " '�[���旪��
		strSQL = strSQL & "      , NHSNMA " '�[���於�̂P
		strSQL = strSQL & "      , NHSNMB " '�[���於�̂Q
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.TANCD, 6) & "' " '�S���҃R�[�h
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.TANNM, 40) & "' " '�S���Җ�
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.BUMCD, 6) & "' " '����R�[�h
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.BUMNM, 40) & "' " '���喼
		strSQL = strSQL & "      , TOKSEICD " '������R�[�h
		strSQL = strSQL & "      , SOUCD " '�q�ɃR�[�h
		strSQL = strSQL & "      , SOUNM " '�q�ɖ�
		strSQL = strSQL & "      , NXTKB " '���[�敪
		strSQL = strSQL & "      , NXTNM " '���[����
		strSQL = strSQL & "      , EMGODNKB " '�ً}�o�׋敪
		strSQL = strSQL & "      , OKRJONO " '�����
		strSQL = strSQL & "      , INVNO " '�C���{�C�X��
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' " '�o�������t
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SSADT(CInt(pin_intCnt))) & "' " '�����t
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.KESDT(CInt(pin_intCnt))) & "' " '���ϓ��t
		strSQL = strSQL & "      , NYUCD " '�����敪
		strSQL = strSQL & "      , ZKTKB " '����敪
		strSQL = strSQL & "      , ZKTNM " '����敪��
		strSQL = strSQL & "      , KENNMA " '�����P
		strSQL = strSQL & "      , KENNMB " '�����Q
		strSQL = strSQL & "      , NHSADA " '�[����Z���P
		strSQL = strSQL & "      , NHSADB " '�[����Z���Q
		strSQL = strSQL & "      , NHSADC " '�[����Z���R
		strSQL = strSQL & "      , MAEUKNM " '�O��敪����
		strSQL = strSQL & "      , KEIBUMCD " '�o������R�[�h
		strSQL = strSQL & "      , UPFKB " '���㓯���o�׋敪
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curUrikn_New(CInt(pin_intCnt)))) '������z(�{�̍��v)
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curUzeikn_New(CInt(pin_intCnt)))) '������z(����Ŋz)
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curUrikn_New(CInt(pin_intCnt)) + pin_usrURITHA.curUzeikn_New(CInt(pin_intCnt)))) '������z(�`�[�v)
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curFUrikn_New(CInt(pin_intCnt)))) '�O�ݔ�����z(�`�[�v)
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , SBANYUKN " '�������z(�`�[�v)
			strSQL = strSQL & "      , SBAFRNKN " '�O�ݓ����z(�`�[�v)
		Else
			strSQL = strSQL & "      , 0 " '�������z(�`�[�v)
			strSQL = strSQL & "      , 0 " '�O�ݓ����z(�`�[�v)
		End If
		
		strSQL = strSQL & "      , DENCM " '���l
		strSQL = strSQL & "      , DENCMIN " '�Г����l
		strSQL = strSQL & "      , TOKSMEKB " '���敪
		strSQL = strSQL & "      , TOKSMEDD " '���������t(����)
		strSQL = strSQL & "      , TOKSMECC " '���T�C�N��(����)
		strSQL = strSQL & "      , TOKSDWKB " '���ߗj��
		strSQL = strSQL & "      , TOKKESCC " '����T�C�N��
		strSQL = strSQL & "      , TOKKESDD " '������t
		strSQL = strSQL & "      , TOKKDWKB " '����j��
		strSQL = strSQL & "      , LSTID " '�`�[���
		strSQL = strSQL & "      , TOKJUNKB " '���ʕ\�o�͋敪
		strSQL = strSQL & "      , TOKMSTKB " '�}�X�^�敪(���Ӑ�)
		strSQL = strSQL & "      , TKNRPSKB " '���z�[����������
		strSQL = strSQL & "      , TKNZRNKB " '���z�[�������敪
		strSQL = strSQL & "      , TOKZEIKB " '����ŋ敪
		strSQL = strSQL & "      , TOKZCLKB " '����ŎZ�o�敪
		strSQL = strSQL & "      , TOKRPSKB " '����Œ[����������
		strSQL = strSQL & "      , TOKZRNKB " '����Œ[�������敪
		strSQL = strSQL & "      , TOKNMMKB " '�����ƭ�ً敪
		strSQL = strSQL & "      , NHSMSTKB " '�}�X�^�敪(�[����)
		strSQL = strSQL & "      , NHSNMMKB " '�����ƭ�ً敪
		strSQL = strSQL & "      , TANMSTKB " '�}�X�^�敪(�S����)
		strSQL = strSQL & "      , URIKJN " '����
		strSQL = strSQL & "      , MAEUKKB " '�O��敪
		strSQL = strSQL & "      , SEIKB " '�����敪
		strSQL = strSQL & "      , JDNTRKB " '�󒍎���敪
		strSQL = strSQL & "      , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "      , FRNKB " '�C�O����敪
		strSQL = strSQL & "      , UDNPRAKB " '�[�i�����s�敪
		strSQL = strSQL & "      , UDNPRBKB " '�ʐ������s�敪
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' " '���`�[�Ǘ��ԍ�
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '����o�^���[�U�[�h�c
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '����o�^�N���C�A���g�h�c
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c�i�����j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�����j
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' " '�o�f�h�c
		strSQL = strSQL & "      ,  '" & CF_Ora_String(gc_strDLFLG_UPD, 1) & "' " '�폜�t���O
		strSQL = strSQL & "   FROM UDNTHA "
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' "
		
		AE_URIINF_UDNTHA_INS_KRO_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_URIINF_UDNTHA_INS_AKA_SQL
	'   �T�v�F  ���㌩�o���g�����ԓ`�[�쐬SQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �@�@�@  pin_intCnt�@      : �ԍ�
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTHA_INS_AKA_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByVal pin_intCnt As String) As String
		
		Dim strSQL As String
		
		AE_URIINF_UDNTHA_INS_AKA_SQL = ""
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO UDNTHA "
		strSQL = strSQL & "      ( DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "      , AKAKROKB " '�ԍ��敪
		strSQL = strSQL & "      , DENKB " '�`�[�敪
		strSQL = strSQL & "      , UDNNO " '����`�[�ԍ�
		strSQL = strSQL & "      , FDNNO " '�[�i����
		strSQL = strSQL & "      , JDNNO " '�󒍓`�[�ԍ�
		strSQL = strSQL & "      , USDNO " '�����`�[NO
		strSQL = strSQL & "      , UDNDT " '����`�[���t
		strSQL = strSQL & "      , DENDT " '������t
		strSQL = strSQL & "      , REGDT " '����`�[���t
		strSQL = strSQL & "      , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , TOKRN " '���Ӑ旪��
		strSQL = strSQL & "      , NHSCD " '�[����R�[�h
		strSQL = strSQL & "      , NHSRN " '�[���旪��
		strSQL = strSQL & "      , NHSNMA " '�[���於�̂P
		strSQL = strSQL & "      , NHSNMB " '�[���於�̂Q
		strSQL = strSQL & "      , TANCD " '�S���҃R�[�h
		strSQL = strSQL & "      , TANNM " '�S���Җ�
		strSQL = strSQL & "      , BUMCD " '����R�[�h
		strSQL = strSQL & "      , BUMNM " '���喼
		strSQL = strSQL & "      , TOKSEICD " '������R�[�h
		strSQL = strSQL & "      , SOUCD " '�q�ɃR�[�h
		strSQL = strSQL & "      , SOUNM " '�q�ɖ�
		strSQL = strSQL & "      , NXTKB " '���[�敪
		strSQL = strSQL & "      , NXTNM " '���[����
		strSQL = strSQL & "      , EMGODNKB " '�ً}�o�׋敪
		strSQL = strSQL & "      , OKRJONO " '�����
		strSQL = strSQL & "      , INVNO " '�C���{�C�X��
		strSQL = strSQL & "      , SMADT " '�o�������t
		strSQL = strSQL & "      , SSADT " '�����t
		strSQL = strSQL & "      , KESDT " '���ϓ��t
		strSQL = strSQL & "      , NYUCD " '�����敪
		strSQL = strSQL & "      , ZKTKB " '����敪
		strSQL = strSQL & "      , ZKTNM " '����敪��
		strSQL = strSQL & "      , KENNMA " '�����P
		strSQL = strSQL & "      , KENNMB " '�����Q
		strSQL = strSQL & "      , NHSADA " '�[����Z���P
		strSQL = strSQL & "      , NHSADB " '�[����Z���Q
		strSQL = strSQL & "      , NHSADC " '�[����Z���R
		strSQL = strSQL & "      , MAEUKNM " '�O��敪����
		strSQL = strSQL & "      , KEIBUMCD " '�o������R�[�h
		strSQL = strSQL & "      , UPFKB " '���㓯���o�׋敪
		strSQL = strSQL & "      , SBAURIKN " '������z(�{�̍��v)
		strSQL = strSQL & "      , SBAUZEKN " '������z(����Ŋz)
		strSQL = strSQL & "      , SBAUZKKN " '������z(�`�[�v)
		strSQL = strSQL & "      , SBAFRUKN " '�O�ݔ�����z(�`�[�v)
		strSQL = strSQL & "      , SBANYUKN " '�������z(�`�[�v)
		strSQL = strSQL & "      , SBAFRNKN " '�O�ݓ����z(�`�[�v)
		strSQL = strSQL & "      , DENCM " '���l
		strSQL = strSQL & "      , DENCMIN " '�Г����l
		strSQL = strSQL & "      , TOKSMEKB " '���敪
		strSQL = strSQL & "      , TOKSMEDD " '���������t(����)
		strSQL = strSQL & "      , TOKSMECC " '���T�C�N��(����)
		strSQL = strSQL & "      , TOKSDWKB " '���ߗj��
		strSQL = strSQL & "      , TOKKESCC " '����T�C�N��
		strSQL = strSQL & "      , TOKKESDD " '������t
		strSQL = strSQL & "      , TOKKDWKB " '����j��
		strSQL = strSQL & "      , LSTID " '�`�[���
		strSQL = strSQL & "      , TOKJUNKB " '���ʕ\�o�͋敪
		strSQL = strSQL & "      , TOKMSTKB " '�}�X�^�敪(���Ӑ�)
		strSQL = strSQL & "      , TKNRPSKB " '���z�[����������
		strSQL = strSQL & "      , TKNZRNKB " '���z�[�������敪
		strSQL = strSQL & "      , TOKZEIKB " '����ŋ敪
		strSQL = strSQL & "      , TOKZCLKB " '����ŎZ�o�敪
		strSQL = strSQL & "      , TOKRPSKB " '����Œ[����������
		strSQL = strSQL & "      , TOKZRNKB " '����Œ[�������敪
		strSQL = strSQL & "      , TOKNMMKB " '�����ƭ�ً敪
		strSQL = strSQL & "      , NHSMSTKB " '�}�X�^�敪(�[����)
		strSQL = strSQL & "      , NHSNMMKB " '�����ƭ�ً敪
		strSQL = strSQL & "      , TANMSTKB " '�}�X�^�敪(�S����)
		strSQL = strSQL & "      , URIKJN " '����
		strSQL = strSQL & "      , MAEUKKB " '�O��敪
		strSQL = strSQL & "      , SEIKB " '�����敪
		strSQL = strSQL & "      , JDNTRKB " '�󒍎���敪
		strSQL = strSQL & "      , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "      , FRNKB " '�C�O����敪
		strSQL = strSQL & "      , UDNPRAKB " '�[�i�����s�敪
		strSQL = strSQL & "      , UDNPRBKB " '�ʐ������s�敪
		strSQL = strSQL & "      , MOTDATNO " '���`�[�Ǘ��ԍ�
		strSQL = strSQL & "      , FOPEID " '����o�^���[�U�[�h�c
		strSQL = strSQL & "      , FCLTID " '����o�^�N���C�A���g�h�c
		strSQL = strSQL & "      , WRTFSTTM " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "      , WRTFSTDT " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "      , OPEID " '���[�U�[�h�c�i�����j
		strSQL = strSQL & "      , CLTID " '�N���C�A���g�h�c�i�����j
		strSQL = strSQL & "      , WRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      , WRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      , UOPEID " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UCLTID " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UWRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      , UWRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      , PGID " '�o�f�h�c
		strSQL = strSQL & "      , DLFLG " '�폜�t���O
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        '" & CF_Ora_String(pin_usrURITHA.DATNO_AKA(CInt(pin_intCnt)), 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "      , '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "' " '�ԍ��敪
		strSQL = strSQL & "      , DENKB " '�`�[�敪
		
		'����`�[�ԍ�
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , UDNNO "
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt)), 8) & "' "
		End If
		
		' === 20070331 === UPDATE S - ACE)Nagasawa ��������ԕi�Ή�
		'    strSQL = strSQL & "      , FDNNO "          '�[�i����
		
		'�[�i����
		If Trim(pin_usrURITHA.FDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , FDNNO "
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.FDNNO_AKA(CInt(pin_intCnt)), 8) & "' "
		End If
		' === 20070331 === UPDATE E -
		strSQL = strSQL & "      , JDNNO " '�󒍓`�[�ԍ�
		strSQL = strSQL & "      , USDNO " '�����`�[NO
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.UDNDT) & "' " '����`�[���t
		strSQL = strSQL & "      , DENDT " '������t
		strSQL = strSQL & "      , REGDT " '����`�[���t
		strSQL = strSQL & "      , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , TOKRN " '���Ӑ旪��
		strSQL = strSQL & "      , NHSCD " '�[����R�[�h
		strSQL = strSQL & "      , NHSRN " '�[���旪��
		strSQL = strSQL & "      , NHSNMA " '�[���於�̂P
		strSQL = strSQL & "      , NHSNMB " '�[���於�̂Q
		strSQL = strSQL & "      , TANCD " '�S���҃R�[�h
		strSQL = strSQL & "      , TANNM " '�S���Җ�
		strSQL = strSQL & "      , BUMCD " '����R�[�h
		strSQL = strSQL & "      , BUMNM " '���喼
		strSQL = strSQL & "      , TOKSEICD " '������R�[�h
		strSQL = strSQL & "      , SOUCD " '�q�ɃR�[�h
		strSQL = strSQL & "      , SOUNM " '�q�ɖ�
		strSQL = strSQL & "      , NXTKB " '���[�敪
		strSQL = strSQL & "      , NXTNM " '���[����
		strSQL = strSQL & "      , EMGODNKB " '�ً}�o�׋敪
		strSQL = strSQL & "      , OKRJONO " '�����
		strSQL = strSQL & "      , INVNO " '�C���{�C�X��
		' === 20070325 === UPDATE S - ACE)Nagasawa �ԓ`�[�������t�X�V
		'    strSQL = strSQL & "      , SMADT "          '�o�������t
		'    strSQL = strSQL & "      , SSADT "          '�����t
		'    strSQL = strSQL & "      , KESDT "          '���ϓ��t
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' " '�o�������t
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SSADT(CInt(pin_intCnt))) & "' " '�����t
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.KESDT(CInt(pin_intCnt))) & "' " '���ϓ��t
		' === 20070325 === UPDATE E -
		strSQL = strSQL & "      , NYUCD " '�����敪
		strSQL = strSQL & "      , ZKTKB " '����敪
		strSQL = strSQL & "      , ZKTNM " '����敪��
		strSQL = strSQL & "      , KENNMA " '�����P
		strSQL = strSQL & "      , KENNMB " '�����Q
		strSQL = strSQL & "      , NHSADA " '�[����Z���P
		strSQL = strSQL & "      , NHSADB " '�[����Z���Q
		strSQL = strSQL & "      , NHSADC " '�[����Z���R
		strSQL = strSQL & "      , MAEUKNM " '�O��敪����
		strSQL = strSQL & "      , KEIBUMCD " '�o������R�[�h
		strSQL = strSQL & "      , UPFKB " '���㓯���o�׋敪
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			'�ԕi���Ȃ��ꍇ
			strSQL = strSQL & "      , SBAURIKN * (-1) " '������z(�{�̍��v)
			strSQL = strSQL & "      , SBAUZEKN * (-1) " '������z(����Ŋz)
			strSQL = strSQL & "      , SBAUZKKN * (-1) " '������z(�`�[�v)
			strSQL = strSQL & "      , SBAFRUKN * (-1) " '�O�ݔ�����z(�`�[�v)
			strSQL = strSQL & "      , SBANYUKN * (-1) " '�������z(�`�[�v)
			strSQL = strSQL & "      , SBAFRNKN * (-1) " '�O�ݓ����z(�`�[�v)
		Else
			'�ԕi�����݂���ꍇ
			'������z(�{�̍��v)
			strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curUrikn_Old(CInt(pin_intCnt)) * (-1)))
			'������z(����Ŋz)
			strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curUzeikn_Old(CInt(pin_intCnt)) * (-1)))
			'������z(�`�[�v)
			strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curUrikn_Old(CInt(pin_intCnt)) * (-1) + pin_usrURITHA.curUzeikn_Old(CInt(pin_intCnt)) * (-1)))
			'�O�ݔ�����z(�`�[�v)
			strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITHA.curFUrikn_Old(CInt(pin_intCnt)) * (-1)))
			strSQL = strSQL & "      , 0 " '�������z(�`�[�v)
			strSQL = strSQL & "      , 0 " '�O�ݓ����z(�`�[�v)
		End If
		strSQL = strSQL & "      , DENCM " '���l
		strSQL = strSQL & "      , DENCMIN " '�Г����l
		strSQL = strSQL & "      , TOKSMEKB " '���敪
		strSQL = strSQL & "      , TOKSMEDD " '���������t(����)
		strSQL = strSQL & "      , TOKSMECC " '���T�C�N��(����)
		strSQL = strSQL & "      , TOKSDWKB " '���ߗj��
		strSQL = strSQL & "      , TOKKESCC " '����T�C�N��
		strSQL = strSQL & "      , TOKKESDD " '������t
		strSQL = strSQL & "      , TOKKDWKB " '����j��
		strSQL = strSQL & "      , LSTID " '�`�[���
		strSQL = strSQL & "      , TOKJUNKB " '���ʕ\�o�͋敪
		strSQL = strSQL & "      , TOKMSTKB " '�}�X�^�敪(���Ӑ�)
		strSQL = strSQL & "      , TKNRPSKB " '���z�[����������
		strSQL = strSQL & "      , TKNZRNKB " '���z�[�������敪
		strSQL = strSQL & "      , TOKZEIKB " '����ŋ敪
		strSQL = strSQL & "      , TOKZCLKB " '����ŎZ�o�敪
		strSQL = strSQL & "      , TOKRPSKB " '����Œ[����������
		strSQL = strSQL & "      , TOKZRNKB " '����Œ[�������敪
		strSQL = strSQL & "      , TOKNMMKB " '�����ƭ�ً敪
		strSQL = strSQL & "      , NHSMSTKB " '�}�X�^�敪(�[����)
		strSQL = strSQL & "      , NHSNMMKB " '�����ƭ�ً敪
		strSQL = strSQL & "      , TANMSTKB " '�}�X�^�敪(�S����)
		strSQL = strSQL & "      , URIKJN " '����
		strSQL = strSQL & "      , MAEUKKB " '�O��敪
		strSQL = strSQL & "      , SEIKB " '�����敪
		strSQL = strSQL & "      , JDNTRKB " '�󒍎���敪
		strSQL = strSQL & "      , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "      , FRNKB " '�C�O����敪
		strSQL = strSQL & "      , UDNPRAKB " '�[�i�����s�敪
		strSQL = strSQL & "      , UDNPRBKB " '�ʐ������s�敪
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' " '���`�[�Ǘ��ԍ�
		strSQL = strSQL & "      , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '����o�^���[�U�[�h�c
		strSQL = strSQL & "      , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '����o�^�N���C�A���g�h�c
		strSQL = strSQL & "      , '" & GV_SysTime & "' " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "      , '" & GV_SysDate & "' " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c�i�����j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�����j
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' " '�o�f�h�c
		strSQL = strSQL & "      ,  '" & CF_Ora_String(gc_strDLFLG_UPD, 1) & "' " '�폜�t���O
		strSQL = strSQL & "   FROM UDNTHA "
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' "
		
		AE_URIINF_UDNTHA_INS_AKA_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_URIINF_UDNTHA_UPD_SQL
	'   �T�v�F  ���㌩�o���g�����X�VSQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �@�@�@  pin_intCnt�@      : �ԍ�
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTHA_UPD_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByVal pin_intCnt As String) As String
		
		Dim strSQL As String
		
		AE_URIINF_UDNTHA_UPD_SQL = ""
		
		strSQL = ""
		strSQL = strSQL & " UPDATE UDNTHA SET "
		strSQL = strSQL & "        DATKB    = '" & CF_Ora_String(gc_strDATKB_DEL, 1) & "' " '�`�[�폜�敪
		strSQL = strSQL & "      , OPEID    = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c�i�����j
		strSQL = strSQL & "      , CLTID    = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�����j
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      , UOPEID   = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UCLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UWRTTM   = '" & GV_SysTime & "' " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      , UWRTDT   = '" & GV_SysDate & "' " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      , PGID     = '" & CF_Ora_String(SSS_PrgId, 7) & "' " '�o�f�h�c
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' "
		
		AE_URIINF_UDNTHA_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_URIINF_UDNTRA_INS_KRO_SQL
	'   �T�v�F  ����g�������`�[�쐬SQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �@�@�@  pin_usrURITRA     : ����g�����X�V���
	'   �@�@�@  pin_intCnt�@      : �ԍ�
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTRA_INS_KRO_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA As Cmn_UDNTRA_Upd, ByVal pin_intCnt As String) As String
		
		Dim strSQL As String
		
		AE_URIINF_UDNTRA_INS_KRO_SQL = ""
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO UDNTRA "
		strSQL = strSQL & "      ( DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "      , AKAKROKB " '�ԍ��敪
		strSQL = strSQL & "      , DENKB " '�`�[�敪
		strSQL = strSQL & "      , UDNNO " '����`�[�ԍ�
		strSQL = strSQL & "      , LINNO " '�s�ԍ�
		strSQL = strSQL & "      , ZKTKB " '����敪
		strSQL = strSQL & "      , ODNNO " '�o�ד`�[�ԍ�
		strSQL = strSQL & "      , ODNLINNO " '�s�ԍ�
		strSQL = strSQL & "      , JDNNO " '�󒍓`�[�ԍ�
		strSQL = strSQL & "      , JDNLINNO " '�󒍓`�[�s�ԍ�
		strSQL = strSQL & "      , RECNO " '���R�[�h�Ǘ�NO.
		strSQL = strSQL & "      , USDNO " '�����`�[NO
		strSQL = strSQL & "      , UDNDT " '����`�[���t
		strSQL = strSQL & "      , DKBSB " '�`�[����敪���
		strSQL = strSQL & "      , DKBID " '����敪�R�[�h
		strSQL = strSQL & "      , DKBNM " '����敪����
		strSQL = strSQL & "      , HENRSNCD " '�ԕi���R
		strSQL = strSQL & "      , HENSTTCD " '�ԕi���
		strSQL = strSQL & "      , SMADT " '�o�������t
		strSQL = strSQL & "      , SSADT " '�����t
		strSQL = strSQL & "      , KESDT " '���ϓ��t
		strSQL = strSQL & "      , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , TANCD " '�S���҃R�[�h
		strSQL = strSQL & "      , NHSCD " '�[����R�[�h
		strSQL = strSQL & "      , TOKSEICD " '������R�[�h
		strSQL = strSQL & "      , SOUCD " '�q�ɃR�[�h
		strSQL = strSQL & "      , SBNNO " '����
		strSQL = strSQL & "      , HINCD " '���i�R�[�h
		strSQL = strSQL & "      , TOKJDNNO " '�q�撍���ԍ�
		strSQL = strSQL & "      , HINNMA " '�^��
		strSQL = strSQL & "      , HINNMB " '���i���P
		strSQL = strSQL & "      , UNTCD " '�P�ʃR�[�h
		strSQL = strSQL & "      , UNTNM " '�P�ʖ�
		strSQL = strSQL & "      , IRISU " '����
		strSQL = strSQL & "      , CASSU " '�P�[�X��
		strSQL = strSQL & "      , URISU " '���㐔��
		strSQL = strSQL & "      , URITK " '�P��
		strSQL = strSQL & "      , GNKTK " '�����P��
		strSQL = strSQL & "      , SIKTK " '�c�Ǝd�ؒP��
		strSQL = strSQL & "      , FURITK " '�O�ݒP��
		strSQL = strSQL & "      , URIKN " '������z
		strSQL = strSQL & "      , FURIKN " '�O�ݔ�����z
		strSQL = strSQL & "      , SIKKN " '�c�Ǝd�؋��z
		strSQL = strSQL & "      , UZEKN " '����ŋ��z
		strSQL = strSQL & "      , NYUDT " '������
		strSQL = strSQL & "      , NYUKN " '�����z
		strSQL = strSQL & "      , FNYUKN " '�O�ݓ����z
		strSQL = strSQL & "      , GNKKN " '�������z
		strSQL = strSQL & "      , JKESIKN " '�������z
		strSQL = strSQL & "      , FKESIKN " '�O�ݏ������z
		strSQL = strSQL & "      , KESIKB " '�����敪
		strSQL = strSQL & "      , NYUKB " '�������
		strSQL = strSQL & "      , TNKID " '���
		strSQL = strSQL & "      , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "      , RATERT " '�בփ��[�g
		strSQL = strSQL & "      , EMGODNKB " '�ً}�o�׋敪
		strSQL = strSQL & "      , OKRJONO " '�����
		strSQL = strSQL & "      , INVNO " '�C���{�C�X��
		strSQL = strSQL & "      , LINCMA " '���ה��l�P
		strSQL = strSQL & "      , LINCMB " '���ה��l�Q
		strSQL = strSQL & "      , BNKCD " '��s�R�[�h
		strSQL = strSQL & "      , BNKNM " '��s����
		strSQL = strSQL & "      , TEGNO " '��`�ԍ�
		strSQL = strSQL & "      , TEGDT " '��`����
		strSQL = strSQL & "      , UPDID " '�X�V�p���ޯ��(ACNT)
		strSQL = strSQL & "      , DFLDKBCD " '�f�t�H���g�R�[�h
		strSQL = strSQL & "      , DKBZAIFL " '�݌Ɋ֘A�t���O
		strSQL = strSQL & "      , DKBTEGFL " '��`�����t���O
		strSQL = strSQL & "      , DKBFLA " '�_�~�[�t���O�P
		strSQL = strSQL & "      , DKBFLB " '�_�~�[�t���O�Q
		strSQL = strSQL & "      , DKBFLC " '�_�~�[�t���O�R
		strSQL = strSQL & "      , LSTID " '�`�[���
		strSQL = strSQL & "      , HINZEIKB " '���i����ŋ敪
		strSQL = strSQL & "      , HINMSTKB " '�}�X�^�敪(���i)
		strSQL = strSQL & "      , TOKMSTKB " '�}�X�^�敪(���Ӑ�)
		strSQL = strSQL & "      , NHSMSTKB " '�}�X�^�敪(�[����)
		strSQL = strSQL & "      , TANMSTKB " '�}�X�^�敪(�S����)
		strSQL = strSQL & "      , ZEIRNKKB " '����Ń����N
		strSQL = strSQL & "      , HINKB " '���i�敪
		strSQL = strSQL & "      , ZEIRT " '����ŗ�
		strSQL = strSQL & "      , ZAIKB " '�݌ɊǗ��敪
		strSQL = strSQL & "      , MRPKB " '�W�J�敪
		strSQL = strSQL & "      , HINJUNKB " '���ʕ\�o�͋敪
		strSQL = strSQL & "      , MAKCD " '���[�J�[�R�[�h
		strSQL = strSQL & "      , HINSIRCD " '���i�d����R�[�h
		strSQL = strSQL & "      , HINNMMKB " '�����ƭ�ً敪(���i)
		strSQL = strSQL & "      , HRTDD " '�������[�h�^�C��
		strSQL = strSQL & "      , ORTDD " '�o�׃��[�h�^�C��
		strSQL = strSQL & "      , ZNKURIKN " '�Ŕ��ېőΏۊz
		strSQL = strSQL & "      , ZKMURIKN " '�ō��ېőΏۊz
		strSQL = strSQL & "      , ZKMUZEKN " '�ō������
		strSQL = strSQL & "      , MOTDATNO " '���`�[�Ǘ��ԍ�
		strSQL = strSQL & "      , FOPEID " '����o�^���[�U�[�h�c
		strSQL = strSQL & "      , FCLTID " '����o�^�N���C�A���g�h�c
		strSQL = strSQL & "      , WRTFSTTM " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "      , WRTFSTDT " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "      , OPEID " '���[�U�[�h�c�i�����j
		strSQL = strSQL & "      , CLTID " '�N���C�A���g�h�c�i�����j
		strSQL = strSQL & "      , WRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      , WRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      , UOPEID " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UCLTID " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UWRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      , UWRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      , PGID " '�o�f�h�c
		strSQL = strSQL & "      , DLFLG " '�폜�t���O
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        '" & CF_Ora_String(pin_usrURITHA.DATNO_KRO(CInt(pin_intCnt)), 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "      , AKAKROKB " '�ԍ��敪
		strSQL = strSQL & "      , DENKB " '�`�[�敪
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.UDNNO_KRO(CInt(pin_intCnt)), 8) & "' " '����`�[�ԍ�
		strSQL = strSQL & "      , LINNO " '�s�ԍ�
		strSQL = strSQL & "      , ZKTKB " '����敪
		
		'�o�ד`�[�ԍ�
		If Trim(pin_usrURITHA.ODNNO(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , ODNNO "
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.ODNNO(CInt(pin_intCnt)), 8) & "' "
		End If
		
		strSQL = strSQL & "      , ODNLINNO " '�s�ԍ�
		strSQL = strSQL & "      , JDNNO " '�󒍓`�[�ԍ�
		strSQL = strSQL & "      , JDNLINNO " '�󒍓`�[�s�ԍ�
		strSQL = strSQL & "      , RECNO " '���R�[�h�Ǘ�NO.
		strSQL = strSQL & "      , USDNO " '�����`�[NO
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.UDNDT) & "' " '����`�[���t
		strSQL = strSQL & "      , DKBSB " '�`�[����敪���
		strSQL = strSQL & "      , DKBID " '����敪�R�[�h
		strSQL = strSQL & "      , DKBNM " '����敪����
		strSQL = strSQL & "      , HENRSNCD " '�ԕi���R
		strSQL = strSQL & "      , HENSTTCD " '�ԕi���
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' " '�o�������t
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SSADT(CInt(pin_intCnt))) & "' " '�����t
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.KESDT(CInt(pin_intCnt))) & "' " '���ϓ��t
		strSQL = strSQL & "      , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.TANCD, 6) & "' " '�S���҃R�[�h
		strSQL = strSQL & "      , NHSCD " '�[����R�[�h
		strSQL = strSQL & "      , TOKSEICD " '������R�[�h
		strSQL = strSQL & "      , SOUCD " '�q�ɃR�[�h
		strSQL = strSQL & "      , SBNNO " '����
		strSQL = strSQL & "      , HINCD " '���i�R�[�h
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITRA.TOKJDNNO, 23) & "' " '�q�撍���ԍ�
		strSQL = strSQL & "      , HINNMA " '�^��
		strSQL = strSQL & "      , HINNMB " '���i���P
		strSQL = strSQL & "      , UNTCD " '�P�ʃR�[�h
		strSQL = strSQL & "      , UNTNM " '�P�ʖ�
		strSQL = strSQL & "      , IRISU " '����
		strSQL = strSQL & "      , CASSU " '�P�[�X��
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.URISU)) '���㐔��
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.URITK)) '�P��
		'�Z�b�g�A�b�v�̏ꍇ�̂ݍX�V
		If pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SET Then
			strSQL = strSQL & "      , " & CF_Ora_Number(pin_usrURITRA.SIKTK) '�����P��
		Else
			strSQL = strSQL & "      , GNKTK " '�����P��
		End If
		
		strSQL = strSQL & "      , " & CF_Ora_Number(pin_usrURITRA.SIKTK) '�c�Ǝd�ؒP��
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.FURITK)) '�O�ݒP��
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.URIKN)) '������z
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.FURIKN)) '�O�ݔ�����z
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.SIKKN)) '�c�Ǝd�؋��z
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.UZEKN)) '����ŋ��z
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , NYUDT " '������
			strSQL = strSQL & "      , NYUKN " '�����z
			strSQL = strSQL & "      , FNYUKN " '�O�ݓ����z
		Else
			strSQL = strSQL & "      , '" & CF_Ora_Date("") & "' " '������
			strSQL = strSQL & "      , 0 " '�����z
			strSQL = strSQL & "      , 0 " '�O�ݓ����z
		End If
		
		'�Z�b�g�A�b�v�̏ꍇ�̂ݍX�V
		If pin_usrURITHA.JDNTRKB = gc_strJDNTRKB_SET Then
			strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.SIKKN)) '�������z
		Else
			If pin_usrURITRA.bolHNPN = True Then
				'�ԕi�������͍Čv�Z
				strSQL = strSQL & "      , GNKTK * " & CF_Ora_Number(CStr(pin_usrURITRA.URISU)) '�������z
			Else
				strSQL = strSQL & "      , GNKKN " '�������z
			End If
		End If
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , JKESIKN " '�������z
			strSQL = strSQL & "      , FKESIKN " '�O�ݏ������z
			strSQL = strSQL & "      , KESIKB " '�����敪
			strSQL = strSQL & "      , NYUKB " '�������
		Else
			strSQL = strSQL & "      , 0 " '�������z
			strSQL = strSQL & "      , 0 " '�O�ݏ������z
			strSQL = strSQL & "      , '" & CF_Ora_String(gc_strKESIKB_NOT, 1) & "' " '�����敪
			strSQL = strSQL & "      , '" & CF_Ora_String("", 1) & "' " '�������
		End If
		
		strSQL = strSQL & "      , TNKID " '���
		strSQL = strSQL & "      , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "      , RATERT " '�בփ��[�g
		strSQL = strSQL & "      , EMGODNKB " '�ً}�o�׋敪
		strSQL = strSQL & "      , OKRJONO " '�����
		strSQL = strSQL & "      , INVNO " '�C���{�C�X��
		strSQL = strSQL & "      , LINCMA " '���ה��l�P
		strSQL = strSQL & "      , LINCMB " '���ה��l�Q
		strSQL = strSQL & "      , BNKCD " '��s�R�[�h
		strSQL = strSQL & "      , BNKNM " '��s����
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , TEGNO " '��`�ԍ�
			strSQL = strSQL & "      , TEGDT " '��`����
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String("", 10) & "' " '��`�ԍ�
			strSQL = strSQL & "      , '" & CF_Ora_Date("") & "' " '��`����
		End If
		
		strSQL = strSQL & "      , UPDID " '�X�V�p���ޯ��(ACNT)
		strSQL = strSQL & "      , DFLDKBCD " '�f�t�H���g�R�[�h
		strSQL = strSQL & "      , DKBZAIFL " '�݌Ɋ֘A�t���O
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , DKBTEGFL " '��`�����t���O
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String("", 1) & "' " '��`�����t���O
		End If
		
		strSQL = strSQL & "      , DKBFLA " '�_�~�[�t���O�P
		strSQL = strSQL & "      , DKBFLB " '�_�~�[�t���O�Q
		strSQL = strSQL & "      , DKBFLC " '�_�~�[�t���O�R
		strSQL = strSQL & "      , LSTID " '�`�[���
		strSQL = strSQL & "      , HINZEIKB " '���i����ŋ敪
		strSQL = strSQL & "      , HINMSTKB " '�}�X�^�敪(���i)
		strSQL = strSQL & "      , TOKMSTKB " '�}�X�^�敪(���Ӑ�)
		strSQL = strSQL & "      , NHSMSTKB " '�}�X�^�敪(�[����)
		strSQL = strSQL & "      , TANMSTKB " '�}�X�^�敪(�S����)
		strSQL = strSQL & "      , ZEIRNKKB " '����Ń����N
		strSQL = strSQL & "      , HINKB " '���i�敪
		
		' === 20131226 === UPDATE S - RS)Ishida ����Ŗ@�����Ή�
		'�󒍒������̐ŗ��i��ʂōČv�Z����ŗ��j��ݒ肷��
		'strSQL = strSQL & "      , ZEIRT "          '����ŗ�
		strSQL = strSQL & "      , " & CF_Ora_Number(pin_usrURITRA.ZEIRT) '����ŗ�
		' === 20131226 === UPDATE E -
		
		strSQL = strSQL & "      , ZAIKB " '�݌ɊǗ��敪
		' === 20071213 === UPDATE S - ACE)Nagasawa �������o�͋敪�̒ǉ�
		'strSQL = strSQL & "      , MRPKB "          '�W�J�敪
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITRA.MRPKB, 1) & "' " '�������o�͋敪
		' === 20071213 === UPDATE E -
		strSQL = strSQL & "      , HINJUNKB " '���ʕ\�o�͋敪
		strSQL = strSQL & "      , MAKCD " '���[�J�[�R�[�h
		strSQL = strSQL & "      , HINSIRCD " '���i�d����R�[�h
		strSQL = strSQL & "      , HINNMMKB " '�����ƭ�ً敪(���i)
		strSQL = strSQL & "      , HRTDD " '�������[�h�^�C��
		strSQL = strSQL & "      , ORTDD " '�o�׃��[�h�^�C��
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.URIKN)) '�Ŕ��ېőΏۊz
		' === 20070331 === UPDATE S - ACE)Nagasawa ��������ԕi�Ή�
		'    strSQL = strSQL & "      , " & CF_Ora_Number(pin_usrURITRA.URIKN + pin_usrURITRA.UZEKN) '�ō��ېőΏۊz
		'    strSQL = strSQL & "      , " & CF_Ora_Number(pin_usrURITRA.UZEKN)               '�ō������
		strSQL = strSQL & "      , 0 " '�ō��ېőΏۊz
		strSQL = strSQL & "      , 0 " '�ō������
		' === 20070331 === UPDATE E -
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' " '���`�[�Ǘ��ԍ�
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '����o�^���[�U�[�h�c
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '����o�^�N���C�A���g�h�c
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c�i�����j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�����j
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' " '�o�f�h�c
		strSQL = strSQL & "      ,  '" & CF_Ora_String(gc_strDLFLG_UPD, 1) & "' " '�폜�t���O
		strSQL = strSQL & "   FROM UDNTRA "
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' "
		strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_usrURITRA.URILINNO, 3) & "' "
		
		AE_URIINF_UDNTRA_INS_KRO_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_URIINF_UDNTRA_INS_AKA_SQL
	'   �T�v�F  ����g�����ԓ`�[�쐬SQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �@�@�@  pin_usrURITRA     : ����g�����X�V���
	'   �@�@�@  pin_intCnt�@      : �ԍ�
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTRA_INS_AKA_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA As Cmn_UDNTRA_Upd, ByVal pin_intCnt As String) As String
		
		Dim strSQL As String
		
		AE_URIINF_UDNTRA_INS_AKA_SQL = ""
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO UDNTRA "
		strSQL = strSQL & "      ( DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "      , AKAKROKB " '�ԍ��敪
		strSQL = strSQL & "      , DENKB " '�`�[�敪
		strSQL = strSQL & "      , UDNNO " '����`�[�ԍ�
		strSQL = strSQL & "      , LINNO " '�s�ԍ�
		strSQL = strSQL & "      , ZKTKB " '����敪
		strSQL = strSQL & "      , ODNNO " '�o�ד`�[�ԍ�
		strSQL = strSQL & "      , ODNLINNO " '�s�ԍ�
		strSQL = strSQL & "      , JDNNO " '�󒍓`�[�ԍ�
		strSQL = strSQL & "      , JDNLINNO " '�󒍓`�[�s�ԍ�
		strSQL = strSQL & "      , RECNO " '���R�[�h�Ǘ�NO.
		strSQL = strSQL & "      , USDNO " '�����`�[NO
		strSQL = strSQL & "      , UDNDT " '����`�[���t
		strSQL = strSQL & "      , DKBSB " '�`�[����敪���
		strSQL = strSQL & "      , DKBID " '����敪�R�[�h
		strSQL = strSQL & "      , DKBNM " '����敪����
		strSQL = strSQL & "      , HENRSNCD " '�ԕi���R
		strSQL = strSQL & "      , HENSTTCD " '�ԕi���
		strSQL = strSQL & "      , SMADT " '�o�������t
		strSQL = strSQL & "      , SSADT " '�����t
		strSQL = strSQL & "      , KESDT " '���ϓ��t
		strSQL = strSQL & "      , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , TANCD " '�S���҃R�[�h
		strSQL = strSQL & "      , NHSCD " '�[����R�[�h
		strSQL = strSQL & "      , TOKSEICD " '������R�[�h
		strSQL = strSQL & "      , SOUCD " '�q�ɃR�[�h
		strSQL = strSQL & "      , SBNNO " '����
		strSQL = strSQL & "      , HINCD " '���i�R�[�h
		strSQL = strSQL & "      , TOKJDNNO " '�q�撍���ԍ�
		strSQL = strSQL & "      , HINNMA " '�^��
		strSQL = strSQL & "      , HINNMB " '���i���P
		strSQL = strSQL & "      , UNTCD " '�P�ʃR�[�h
		strSQL = strSQL & "      , UNTNM " '�P�ʖ�
		strSQL = strSQL & "      , IRISU " '����
		strSQL = strSQL & "      , CASSU " '�P�[�X��
		strSQL = strSQL & "      , URISU " '���㐔��
		strSQL = strSQL & "      , URITK " '�P��
		strSQL = strSQL & "      , GNKTK " '�����P��
		strSQL = strSQL & "      , SIKTK " '�c�Ǝd�ؒP��
		strSQL = strSQL & "      , FURITK " '�O�ݒP��
		strSQL = strSQL & "      , URIKN " '������z
		strSQL = strSQL & "      , FURIKN " '�O�ݔ�����z
		strSQL = strSQL & "      , SIKKN " '�c�Ǝd�؋��z
		strSQL = strSQL & "      , UZEKN " '����ŋ��z
		strSQL = strSQL & "      , NYUDT " '������
		strSQL = strSQL & "      , NYUKN " '�����z
		strSQL = strSQL & "      , FNYUKN " '�O�ݓ����z
		strSQL = strSQL & "      , GNKKN " '�������z
		strSQL = strSQL & "      , JKESIKN " '�������z
		strSQL = strSQL & "      , FKESIKN " '�O�ݏ������z
		strSQL = strSQL & "      , KESIKB " '�����敪
		strSQL = strSQL & "      , NYUKB " '�������
		strSQL = strSQL & "      , TNKID " '���
		strSQL = strSQL & "      , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "      , RATERT " '�בփ��[�g
		strSQL = strSQL & "      , EMGODNKB " '�ً}�o�׋敪
		strSQL = strSQL & "      , OKRJONO " '�����
		strSQL = strSQL & "      , INVNO " '�C���{�C�X��
		strSQL = strSQL & "      , LINCMA " '���ה��l�P
		strSQL = strSQL & "      , LINCMB " '���ה��l�Q
		strSQL = strSQL & "      , BNKCD " '��s�R�[�h
		strSQL = strSQL & "      , BNKNM " '��s����
		strSQL = strSQL & "      , TEGNO " '��`�ԍ�
		strSQL = strSQL & "      , TEGDT " '��`����
		strSQL = strSQL & "      , UPDID " '�X�V�p���ޯ��(ACNT)
		strSQL = strSQL & "      , DFLDKBCD " '�f�t�H���g�R�[�h
		strSQL = strSQL & "      , DKBZAIFL " '�݌Ɋ֘A�t���O
		strSQL = strSQL & "      , DKBTEGFL " '��`�����t���O
		strSQL = strSQL & "      , DKBFLA " '�_�~�[�t���O�P
		strSQL = strSQL & "      , DKBFLB " '�_�~�[�t���O�Q
		strSQL = strSQL & "      , DKBFLC " '�_�~�[�t���O�R
		strSQL = strSQL & "      , LSTID " '�`�[���
		strSQL = strSQL & "      , HINZEIKB " '���i����ŋ敪
		strSQL = strSQL & "      , HINMSTKB " '�}�X�^�敪(���i)
		strSQL = strSQL & "      , TOKMSTKB " '�}�X�^�敪(���Ӑ�)
		strSQL = strSQL & "      , NHSMSTKB " '�}�X�^�敪(�[����)
		strSQL = strSQL & "      , TANMSTKB " '�}�X�^�敪(�S����)
		strSQL = strSQL & "      , ZEIRNKKB " '����Ń����N
		strSQL = strSQL & "      , HINKB " '���i�敪
		strSQL = strSQL & "      , ZEIRT " '����ŗ�
		strSQL = strSQL & "      , ZAIKB " '�݌ɊǗ��敪
		strSQL = strSQL & "      , MRPKB " '�W�J�敪
		strSQL = strSQL & "      , HINJUNKB " '���ʕ\�o�͋敪
		strSQL = strSQL & "      , MAKCD " '���[�J�[�R�[�h
		strSQL = strSQL & "      , HINSIRCD " '���i�d����R�[�h
		strSQL = strSQL & "      , HINNMMKB " '�����ƭ�ً敪(���i)
		strSQL = strSQL & "      , HRTDD " '�������[�h�^�C��
		strSQL = strSQL & "      , ORTDD " '�o�׃��[�h�^�C��
		strSQL = strSQL & "      , ZNKURIKN " '�Ŕ��ېőΏۊz
		strSQL = strSQL & "      , ZKMURIKN " '�ō��ېőΏۊz
		strSQL = strSQL & "      , ZKMUZEKN " '�ō������
		strSQL = strSQL & "      , MOTDATNO " '���`�[�Ǘ��ԍ�
		strSQL = strSQL & "      , FOPEID " '����o�^���[�U�[�h�c
		strSQL = strSQL & "      , FCLTID " '����o�^�N���C�A���g�h�c
		strSQL = strSQL & "      , WRTFSTTM " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "      , WRTFSTDT " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "      , OPEID " '���[�U�[�h�c�i�����j
		strSQL = strSQL & "      , CLTID " '�N���C�A���g�h�c�i�����j
		strSQL = strSQL & "      , WRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      , WRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      , UOPEID " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UCLTID " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UWRTTM " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      , UWRTDT " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      , PGID " '�o�f�h�c
		strSQL = strSQL & "      , DLFLG " '�폜�t���O
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        '" & CF_Ora_String(pin_usrURITHA.DATNO_AKA(CInt(pin_intCnt)), 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , DATKB " '�`�[�폜�敪
		strSQL = strSQL & "      , '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "' " '�ԍ��敪
		strSQL = strSQL & "      , DENKB " '�`�[�敪
		
		'����`�[�ԍ�
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , UDNNO "
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt)), 8) & "' "
		End If
		
		strSQL = strSQL & "      , LINNO " '�s�ԍ�
		strSQL = strSQL & "      , ZKTKB " '����敪
		
		'�o�ד`�[�ԍ�
		If Trim(pin_usrURITHA.ODNNO(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , ODNNO "
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.ODNNO(CInt(pin_intCnt)), 8) & "' "
		End If
		
		strSQL = strSQL & "      , ODNLINNO " '�s�ԍ�
		strSQL = strSQL & "      , JDNNO " '�󒍓`�[�ԍ�
		strSQL = strSQL & "      , JDNLINNO " '�󒍓`�[�s�ԍ�
		strSQL = strSQL & "      , RECNO " '���R�[�h�Ǘ�NO.
		strSQL = strSQL & "      , USDNO " '�����`�[NO
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.UDNDT) & "' " '����`�[���t
		strSQL = strSQL & "      , DKBSB " '�`�[����敪���
		strSQL = strSQL & "      , DKBID " '����敪�R�[�h
		strSQL = strSQL & "      , DKBNM " '����敪����
		strSQL = strSQL & "      , HENRSNCD " '�ԕi���R
		strSQL = strSQL & "      , HENSTTCD " '�ԕi���
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' " '�o�������t
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SSADT(CInt(pin_intCnt))) & "' " '�����t
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.KESDT(CInt(pin_intCnt))) & "' " '���ϓ��t
		strSQL = strSQL & "      , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , TANCD " '�S���҃R�[�h
		strSQL = strSQL & "      , NHSCD " '�[����R�[�h
		strSQL = strSQL & "      , TOKSEICD " '������R�[�h
		strSQL = strSQL & "      , SOUCD " '�q�ɃR�[�h
		strSQL = strSQL & "      , SBNNO " '����
		strSQL = strSQL & "      , HINCD " '���i�R�[�h
		strSQL = strSQL & "      , TOKJDNNO " '�q�撍���ԍ�
		strSQL = strSQL & "      , HINNMA " '�^��
		strSQL = strSQL & "      , HINNMB " '���i���P
		strSQL = strSQL & "      , UNTCD " '�P�ʃR�[�h
		strSQL = strSQL & "      , UNTNM " '�P�ʖ�
		strSQL = strSQL & "      , IRISU " '����
		strSQL = strSQL & "      , CASSU * (-1) " '�P�[�X��
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.URISU)) * (-1) '���㐔��
		strSQL = strSQL & "      , URITK " '�P��
		strSQL = strSQL & "      , GNKTK " '�����P��
		strSQL = strSQL & "      , SIKTK " '�c�Ǝd�ؒP��
		strSQL = strSQL & "      , FURITK " '�O�ݒP��
		
		If pin_usrURITRA.bolHNPN = False Then
			'�ԕi�Ȃ��̏ꍇ
			strSQL = strSQL & "      , URIKN  * (-1) " '������z
			strSQL = strSQL & "      , FURIKN  * (-1) " '�O�ݔ�����z
			strSQL = strSQL & "      , SIKKN  * (-1) " '�c�Ǝd�؋��z
			strSQL = strSQL & "      , UZEKN  * (-1) " '����ŋ��z
		Else
			'�ԕi������ꍇ
			'������z
			strSQL = strSQL & "      , URIKN * (-1) + " & CF_Ora_Number(CStr(pin_usrURITRA.HNURIKN))
			'�O�ݔ�����z
			strSQL = strSQL & "      , FURIKN  * (-1) + " & CF_Ora_Number(CStr(pin_usrURITRA.HNFURIKN))
			'�c�Ǝd�؋��z
			strSQL = strSQL & "      , SIKTK  * (-1) * " & CF_Ora_Number(CStr(pin_usrURITRA.URISU))
			'����ŋ��z
			strSQL = strSQL & "      , UZEKN * (-1) + " & CF_Ora_Number(CStr(pin_usrURITRA.HNUZEKN))
		End If
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , NYUDT " '������
			strSQL = strSQL & "      , NYUKN  * (-1) " '�����z
			strSQL = strSQL & "      , FNYUKN  * (-1) " '�O�ݓ����z
		Else
			strSQL = strSQL & "      , '" & CF_Ora_Date("") & "' " '������
			strSQL = strSQL & "      , 0 " '�����z
			strSQL = strSQL & "      , 0 " '�O�ݓ����z
		End If
		
		If pin_usrURITRA.bolHNPN = False Then
			'�ԕi�Ȃ��̏ꍇ
			strSQL = strSQL & "      , GNKKN  * (-1) " '�������z
		Else
			'�ԕi������ꍇ
			'�������z
			strSQL = strSQL & "      , GNKTK  * (-1) * " & CF_Ora_Number(CStr(pin_usrURITRA.URISU))
		End If
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , JKESIKN  * (-1) " '�������z
			strSQL = strSQL & "      , FKESIKN  * (-1) " '�O�ݏ������z
			strSQL = strSQL & "      , KESIKB " '�����敪
			strSQL = strSQL & "      , NYUKB " '�������
		Else
			strSQL = strSQL & "      , 0 " '�������z
			strSQL = strSQL & "      , 0 " '�O�ݏ������z
			strSQL = strSQL & "      , '" & CF_Ora_String(gc_strKESIKB_NOT, 1) & "' " '�����敪
			strSQL = strSQL & "      , '" & CF_Ora_String("", 1) & "' " '�������
		End If
		
		strSQL = strSQL & "      , TNKID " '���
		strSQL = strSQL & "      , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "      , RATERT " '�בփ��[�g
		strSQL = strSQL & "      , EMGODNKB " '�ً}�o�׋敪
		strSQL = strSQL & "      , OKRJONO " '�����
		strSQL = strSQL & "      , INVNO " '�C���{�C�X��
		strSQL = strSQL & "      , LINCMA " '���ה��l�P
		strSQL = strSQL & "      , LINCMB " '���ה��l�Q
		strSQL = strSQL & "      , BNKCD " '��s�R�[�h
		strSQL = strSQL & "      , BNKNM " '��s����
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , TEGNO " '��`�ԍ�
			strSQL = strSQL & "      , TEGDT " '��`����
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String("", 10) & "' " '��`�ԍ�
			strSQL = strSQL & "      , '" & CF_Ora_Date("") & "' " '��`����
		End If
		
		strSQL = strSQL & "      , UPDID " '�X�V�p���ޯ��(ACNT)
		strSQL = strSQL & "      , DFLDKBCD " '�f�t�H���g�R�[�h
		strSQL = strSQL & "      , DKBZAIFL " '�݌Ɋ֘A�t���O
		
		If Trim(pin_usrURITHA.UDNNO_AKA(CInt(pin_intCnt))) = "" Then
			strSQL = strSQL & "      , DKBTEGFL " '��`�����t���O
		Else
			strSQL = strSQL & "      , '" & CF_Ora_String("", 1) & "' " '��`�����t���O
		End If
		
		strSQL = strSQL & "      , DKBFLA " '�_�~�[�t���O�P
		strSQL = strSQL & "      , DKBFLB " '�_�~�[�t���O�Q
		strSQL = strSQL & "      , DKBFLC " '�_�~�[�t���O�R
		strSQL = strSQL & "      , LSTID " '�`�[���
		strSQL = strSQL & "      , HINZEIKB " '���i����ŋ敪
		strSQL = strSQL & "      , HINMSTKB " '�}�X�^�敪(���i)
		strSQL = strSQL & "      , TOKMSTKB " '�}�X�^�敪(���Ӑ�)
		strSQL = strSQL & "      , NHSMSTKB " '�}�X�^�敪(�[����)
		strSQL = strSQL & "      , TANMSTKB " '�}�X�^�敪(�S����)
		strSQL = strSQL & "      , ZEIRNKKB " '����Ń����N
		strSQL = strSQL & "      , HINKB " '���i�敪
		strSQL = strSQL & "      , ZEIRT " '����ŗ�
		strSQL = strSQL & "      , ZAIKB " '�݌ɊǗ��敪
		' === 20071213 === UPDATE S - ACE)Nagasawa �������o�͋敪�̒ǉ�
		'strSQL = strSQL & "      , MRPKB "          '�W�J�敪
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITRA.MRPKB, 1) & "' " '�������o�͋敪
		' === 20071213 === UPDATE E -
		strSQL = strSQL & "      , HINJUNKB " '���ʕ\�o�͋敪
		strSQL = strSQL & "      , MAKCD " '���[�J�[�R�[�h
		strSQL = strSQL & "      , HINSIRCD " '���i�d����R�[�h
		strSQL = strSQL & "      , HINNMMKB " '�����ƭ�ً敪(���i)
		strSQL = strSQL & "      , HRTDD " '�������[�h�^�C��
		strSQL = strSQL & "      , ORTDD " '�o�׃��[�h�^�C��
		
		If pin_usrURITRA.bolHNPN = False Then
			'�ԕi�Ȃ��̏ꍇ
			strSQL = strSQL & "      , ZNKURIKN  * (-1) " '�Ŕ��ېőΏۊz
			strSQL = strSQL & "      , ZKMURIKN  * (-1) " '�ō��ېőΏۊz
			strSQL = strSQL & "      , ZKMUZEKN  * (-1) " '�ō������
		Else
			'�ԕi������ꍇ
			'�Ŕ��ېőΏۊz
			strSQL = strSQL & "      , ZNKURIKN  * (-1) + " & CF_Ora_Number(CStr(pin_usrURITRA.HNURIKN))
			' === 20070331 === UPDATE S - ACE)Nagasawa ��������ԕi�Ή�
			'        '�ō��ېőΏۊz
			'        strSQL = strSQL & "      , ZKMURIKN  * (-1) + " & CF_Ora_Number(pin_usrURITRA.HNURIKN + pin_usrURITRA.HNUZEKN)
			'        '�ō������
			'        strSQL = strSQL & "      , ZKMUZEKN  * (-1) + " & CF_Ora_Number(pin_usrURITRA.HNUZEKN)
			strSQL = strSQL & "      , 0 " '�ō��ېőΏۊz
			strSQL = strSQL & "      , 0 " '�ō������
			' === 20070331 === UPDATE E -
		End If
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' " '���`�[�Ǘ��ԍ�
		strSQL = strSQL & "      , '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '����o�^���[�U�[�h�c
		strSQL = strSQL & "      , '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '����o�^�N���C�A���g�h�c
		strSQL = strSQL & "      , '" & GV_SysTime & "' " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "      , '" & GV_SysDate & "' " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c�i�����j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�����j
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "      ,  '" & GV_SysTime & "' " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      ,  '" & GV_SysDate & "' " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_PrgId, 7) & "' " '�o�f�h�c
		strSQL = strSQL & "      ,  '" & CF_Ora_String(gc_strDLFLG_UPD, 1) & "' " '�폜�t���O
		strSQL = strSQL & "   FROM UDNTRA "
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' "
		strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_usrURITRA.URILINNO, 3) & "' "
		
		AE_URIINF_UDNTRA_INS_AKA_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_URIINF_UDNTRA_UPD_SQL
	'   �T�v�F  ����g�����X�VSQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �@�@�@  pin_usrURITRA     : ����g�����X�V���
	'   �@�@�@  pin_intCnt�@      : �ԍ�
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_URIINF_UDNTRA_UPD_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA As Cmn_UDNTRA_Upd, ByVal pin_intCnt As String) As String
		
		Dim strSQL As String
		
		AE_URIINF_UDNTRA_UPD_SQL = ""
		
		strSQL = ""
		strSQL = strSQL & " UPDATE UDNTRA SET "
		strSQL = strSQL & "        DATKB    = '" & CF_Ora_String(gc_strDATKB_DEL, 1) & "' " '�`�[�폜�敪
		strSQL = strSQL & "      , OPEID    = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c�i�����j
		strSQL = strSQL & "      , CLTID    = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�����j
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      , UOPEID   = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UCLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UWRTTM   = '" & GV_SysTime & "' " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      , UWRTDT   = '" & GV_SysDate & "' " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      , PGID     = '" & CF_Ora_String(SSS_PrgId, 7) & "' " '�o�f�h�c
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_usrURITHA.DATNO(CInt(pin_intCnt)), 10) & "' "
		strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_usrURITRA.URILINNO, 3) & "' "
		
		AE_URIINF_UDNTRA_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSINF_UPDATE
	'   �T�v�F  ���|�A�����T�}�����X�V����
	'   �����F  pin_usrURITHA     : ���㌩�o�����
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  �p�����[�^�̒l�����ɔ��|�A�����T�}�������X�V����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSINF_UPDATE(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As Short
		
		Dim intRet As Short
		Dim intCnt As Short
		
		On Error GoTo AE_TOKSINF_UPDATE_Err
		
		AE_TOKSINF_UPDATE = 9
		
		'�T�}���X�V
		Select Case True
			'�����A�O��Ȃ�
			Case pin_usrURITHA.FRNKB = gc_strFRNKB_DMS And pin_usrURITHA.MAEUKKB = gc_strMAEUKKB_NML
				
				'���|�T�}���X�V
				intRet = AE_TOKSMA_UPD_Main(pin_usrURITHA)
				If intRet <> 0 Then
					GoTo AE_TOKSINF_UPDATE_Err
				End If
				
				'���|�T�}�������X�V
				intRet = AE_TOKSME_UPD_Main(pin_usrURITHA)
				If intRet <> 0 Then
					GoTo AE_TOKSINF_UPDATE_Err
				End If
				
				For intCnt = 1 To UBound(pin_usrURITHA.SSADT)
					
					'�����T�}���X�V
					intRet = AE_TOKSSA_UPD_Main(intCnt, pin_usrURITHA)
					If intRet <> 0 Then
						GoTo AE_TOKSINF_UPDATE_Err
					End If
				Next 
				
				'�����A�O��
			Case pin_usrURITHA.FRNKB = gc_strFRNKB_DMS And pin_usrURITHA.MAEUKKB = gc_strMAEUKKB_MAE
				
				'���|�T�}���X�V
				intRet = AE_TOKSMA_UPD_Main(pin_usrURITHA)
				If intRet <> 0 Then
					GoTo AE_TOKSINF_UPDATE_Err
				End If
				
				'���|�T�}�������X�V
				intRet = AE_TOKSME_UPD_Main(pin_usrURITHA)
				If intRet <> 0 Then
					GoTo AE_TOKSINF_UPDATE_Err
				End If
				
				For intCnt = 1 To UBound(pin_usrURITHA.SSADT)
					
					'�O�󐿋��T�}���X�V
					intRet = AE_TOKSSB_UPD_Main(intCnt, pin_usrURITHA)
					If intRet <> 0 Then
						GoTo AE_TOKSINF_UPDATE_Err
					End If
				Next 
				
				'�C�O
			Case pin_usrURITHA.FRNKB = gc_strFRNKB_FRN
				'���|�T�}���X�V
				intRet = AE_TOKSMA_UPD_Main(pin_usrURITHA)
				If intRet <> 0 Then
					GoTo AE_TOKSINF_UPDATE_Err
				End If
				
				'���|�T�}���O�ݍX�V
				intRet = AE_TOKSMD_UPD_Main(pin_usrURITHA)
				If intRet <> 0 Then
					GoTo AE_TOKSINF_UPDATE_Err
				End If
				
				'���|�T�}�������X�V
				intRet = AE_TOKSME_UPD_Main(pin_usrURITHA)
				If intRet <> 0 Then
					GoTo AE_TOKSINF_UPDATE_Err
				End If
				
				For intCnt = 1 To UBound(pin_usrURITHA.SSADT)
					'�����T�}���X�V
					intRet = AE_TOKSSA_UPD_Main(intCnt, pin_usrURITHA)
					If intRet <> 0 Then
						GoTo AE_TOKSINF_UPDATE_Err
					End If
					
					'�����T�}���O�ݍX�V
					intRet = AE_TOKSSC_UPD_Main(intCnt, pin_usrURITHA)
					If intRet <> 0 Then
						GoTo AE_TOKSINF_UPDATE_Err
					End If
				Next 
				
			Case Else
		End Select
		
		AE_TOKSINF_UPDATE = 0
		
AE_TOKSINF_UPDATE_End: 
		Exit Function
		
AE_TOKSINF_UPDATE_Err: 
		GoTo AE_TOKSINF_UPDATE_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSMA_UPD_Main
	'   �T�v�F  ���|�T�}���X�V
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  ���|�T�}���ɒǉ��A�X�V���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSMA_UPD_Main(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		Dim bolTran As Boolean
		'UPGRADE_WARNING: �\���� usrOdy_TOKSMA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_TOKSMA As U_Ody
		
		On Error GoTo AE_TOKSMA_UPD_Main_Err
		
		AE_TOKSMA_UPD_Main = 9
		bolTran = False
		
		'���|�T�}������
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(*) AS CNT"
		strSQL = strSQL & "   FROM TOKSMA "
		strSQL = strSQL & "  WHERE TOKCD  = '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' "
		strSQL = strSQL & "    AND SMADT  = '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' "
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_TOKSMA, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSMA_UPD_Main_Err
		End If
		
		bolTran = True
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(usrOdy_TOKSMA, CNT, 0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Ora_GetDyn(usrOdy_TOKSMA, "CNT", 0) = 0 Then
			'���|�T�}���̍쐬
			strSQL = AE_TOKSMA_INS_SQL(pin_usrURITHA)
		Else
			'���|�T�}���̍X�V
			strSQL = AE_TOKSMA_UPD_SQL(pin_usrURITHA)
		End If
		
		'�r�p�k���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSMA_UPD_Main_Err
		End If
		
		AE_TOKSMA_UPD_Main = 0
		
AE_TOKSMA_UPD_Main_End: 
		If bolTran = True Then
			'���R�[�h�Z�b�g�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_TOKSMA)
		End If
		
		Exit Function
		
AE_TOKSMA_UPD_Main_Err: 
		'�G���[�ӏ��ҏW
		pin_usrURITHA.strErr = "AE_TOKSMA_UPD_Main"
		GoTo AE_TOKSMA_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSMA_INS_SQL
	'   �T�v�F  ���|�T�}���쐬SQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSMA_INS_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSMAURIKN As Decimal
		Dim curSMAUZEKN As Decimal
		
		AE_TOKSMA_INS_SQL = ""
		
		'������z�̍����Z�o
		curSMAURIKN = pin_usrURITHA.curSUrikn_New - pin_usrURITHA.curSUrikn_Old
		'����Ŋz�̍����Z�o
		curSMAUZEKN = pin_usrURITHA.curSUzeikn_New - pin_usrURITHA.curSUzeikn_Old
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSMA "
		strSQL = strSQL & "      ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , SMADT " '�o�������t
		strSQL = strSQL & "      , SMAURIKN00 " '����W�v���z00
		strSQL = strSQL & "      , SMAURIKN01 " '����W�v���z01
		strSQL = strSQL & "      , SMAURIKN02 " '����W�v���z02
		strSQL = strSQL & "      , SMAURIKN03 " '����W�v���z03
		strSQL = strSQL & "      , SMAURIKN04 " '����W�v���z04
		strSQL = strSQL & "      , SMAURIKN05 " '����W�v���z05
		strSQL = strSQL & "      , SMAURIKN06 " '����W�v���z06
		strSQL = strSQL & "      , SMAURIKN07 " '����W�v���z07
		strSQL = strSQL & "      , SMAURIKN08 " '����W�v���z08
		strSQL = strSQL & "      , SMAURIKN09 " '����W�v���z09
		strSQL = strSQL & "      , SMAUZEKN " '�������ŋ��z
		strSQL = strSQL & "      , SZAKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , SZAKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , SZAKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , SZAKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , SZAKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , SZAKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , SZBKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , SZBKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , SZBKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , SZBKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , SZBKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , SZBKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , SMAGNKKN00 " '�����W�v���z00
		strSQL = strSQL & "      , SMAGNKKN01 " '�����W�v���z01
		strSQL = strSQL & "      , SMAGNKKN02 " '�����W�v���z02
		strSQL = strSQL & "      , SMAGNKKN03 " '�����W�v���z03
		strSQL = strSQL & "      , SMAGNKKN04 " '�����W�v���z04
		strSQL = strSQL & "      , SMAGNKKN05 " '�����W�v���z05
		strSQL = strSQL & "      , SMAGNKKN06 " '�����W�v���z06
		strSQL = strSQL & "      , SMAGNKKN07 " '�����W�v���z07
		strSQL = strSQL & "      , SMAGNKKN08 " '�����W�v���z08
		strSQL = strSQL & "      , SMAGNKKN09 " '�����W�v���z09
		strSQL = strSQL & "      , SMANYUKN00 " '�����W�v���z00
		strSQL = strSQL & "      , SMANYUKN01 " '�����W�v���z01
		strSQL = strSQL & "      , SMANYUKN02 " '�����W�v���z02
		strSQL = strSQL & "      , SMANYUKN03 " '�����W�v���z03
		strSQL = strSQL & "      , SMANYUKN04 " '�����W�v���z04
		strSQL = strSQL & "      , SMANYUKN05 " '�����W�v���z05
		strSQL = strSQL & "      , SMANYUKN06 " '�����W�v���z06
		strSQL = strSQL & "      , SMANYUKN07 " '�����W�v���z07
		strSQL = strSQL & "      , SMANYUKN08 " '�����W�v���z08
		strSQL = strSQL & "      , SMANYUKN09 " '�����W�v���z09
		strSQL = strSQL & "      , DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' " '�o�������t
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSMAURIKN)) '����W�v���z00
		strSQL = strSQL & "      , 0 " '����W�v���z01
		strSQL = strSQL & "      , 0 " '����W�v���z02
		strSQL = strSQL & "      , 0 " '����W�v���z03
		strSQL = strSQL & "      , 0 " '����W�v���z04
		strSQL = strSQL & "      , 0 " '����W�v���z05
		strSQL = strSQL & "      , 0 " '����W�v���z06
		strSQL = strSQL & "      , 0 " '����W�v���z07
		strSQL = strSQL & "      , 0 " '����W�v���z08
		strSQL = strSQL & "      , 0 " '����W�v���z09
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSMAUZEKN)) '�������ŋ��z
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����W�v���z00
		strSQL = strSQL & "      , 0 " '�����W�v���z01
		strSQL = strSQL & "      , 0 " '�����W�v���z02
		strSQL = strSQL & "      , 0 " '�����W�v���z03
		strSQL = strSQL & "      , 0 " '�����W�v���z04
		strSQL = strSQL & "      , 0 " '�����W�v���z05
		strSQL = strSQL & "      , 0 " '�����W�v���z06
		strSQL = strSQL & "      , 0 " '�����W�v���z07
		strSQL = strSQL & "      , 0 " '�����W�v���z08
		strSQL = strSQL & "      , 0 " '�����W�v���z09
		strSQL = strSQL & "      , 0 " '�����W�v���z00
		strSQL = strSQL & "      , 0 " '�����W�v���z01
		strSQL = strSQL & "      , 0 " '�����W�v���z02
		strSQL = strSQL & "      , 0 " '�����W�v���z03
		strSQL = strSQL & "      , 0 " '�����W�v���z04
		strSQL = strSQL & "      , 0 " '�����W�v���z05
		strSQL = strSQL & "      , 0 " '�����W�v���z06
		strSQL = strSQL & "      , 0 " '�����W�v���z07
		strSQL = strSQL & "      , 0 " '�����W�v���z08
		strSQL = strSQL & "      , 0 " '�����W�v���z09
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "      ) "
		
		AE_TOKSMA_INS_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSMA_UPD_SQL
	'   �T�v�F  ���|�T�}���X�VSQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSMA_UPD_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSMAURIKN As Decimal
		Dim curSMAUZEKN As Decimal
		
		AE_TOKSMA_UPD_SQL = ""
		
		'������z�̍����Z�o
		curSMAURIKN = pin_usrURITHA.curSUrikn_New - pin_usrURITHA.curSUrikn_Old
		'����Ŋz�̍����Z�o
		curSMAUZEKN = pin_usrURITHA.curSUzeikn_New - pin_usrURITHA.curSUzeikn_Old
		
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSMA SET "
		strSQL = strSQL & "        SMAURIKN00 = SMAURIKN00 + " & CF_Ora_Number(CStr(curSMAURIKN)) '����W�v���z00
		strSQL = strSQL & "      , SMAUZEKN   = SMAUZEKN   + " & CF_Ora_Number(CStr(curSMAUZEKN)) '�������ŋ��z
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' "
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' "
		
		AE_TOKSMA_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSMD_UPD_Main
	'   �T�v�F  ���|�T�}���O�ݍX�V
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  ���|�T�}���O�݂ɒǉ��A�X�V���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSMD_UPD_Main(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		Dim bolTran As Boolean
		'UPGRADE_WARNING: �\���� usrOdy_TOKSMD �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_TOKSMD As U_Ody
		
		On Error GoTo AE_TOKSMD_UPD_Main_Err
		
		AE_TOKSMD_UPD_Main = 9
		bolTran = False
		
		'���|�T�}���O�݌���
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(*) AS CNT"
		strSQL = strSQL & "   FROM TOKSMD "
		strSQL = strSQL & "  WHERE TOKCD  = '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' "
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_usrURITHA.TUKKB, 3) & "' "
		strSQL = strSQL & "    AND SMADT  = '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' "
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_TOKSMD, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSMD_UPD_Main_Err
		End If
		
		bolTran = True
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(usrOdy_TOKSMD, CNT, 0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Ora_GetDyn(usrOdy_TOKSMD, "CNT", 0) = 0 Then
			'���|�T�}���O�݂̍쐬
			strSQL = AE_TOKSMD_INS_SQL(pin_usrURITHA)
		Else
			'���|�T�}���O�݂̍X�V
			strSQL = AE_TOKSMD_UPD_SQL(pin_usrURITHA)
		End If
		
		'�r�p�k���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSMD_UPD_Main_Err
		End If
		
		AE_TOKSMD_UPD_Main = 0
		
AE_TOKSMD_UPD_Main_End: 
		If bolTran = True Then
			'���R�[�h�Z�b�g�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_TOKSMD)
		End If
		
		Exit Function
		
AE_TOKSMD_UPD_Main_Err: 
		'�G���[�ӏ��ҏW
		pin_usrURITHA.strErr = "AE_TOKSMD_UPD_Main"
		GoTo AE_TOKSMD_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSMD_INS_SQL
	'   �T�v�F  ���|�T�}���O�ݍ쐬SQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSMD_INS_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSMDURIKN As Decimal
		Dim curSMDUZEKN As Decimal
		
		AE_TOKSMD_INS_SQL = ""
		
		'������z�̍����Z�o
		curSMDURIKN = pin_usrURITHA.curSFUrikn_New - pin_usrURITHA.curSFUrikn_Old
		'����Ŋz�̎Z�o
		curSMDUZEKN = 0
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSMD "
		strSQL = strSQL & "      ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "      , SMADT " '�o�������t
		strSQL = strSQL & "      , SMDURIKN00 " '����W�v���z00
		strSQL = strSQL & "      , SMDURIKN01 " '����W�v���z01
		strSQL = strSQL & "      , SMDURIKN02 " '����W�v���z02
		strSQL = strSQL & "      , SMDURIKN03 " '����W�v���z03
		strSQL = strSQL & "      , SMDURIKN04 " '����W�v���z04
		strSQL = strSQL & "      , SMDURIKN05 " '����W�v���z05
		strSQL = strSQL & "      , SMDURIKN06 " '����W�v���z06
		strSQL = strSQL & "      , SMDURIKN07 " '����W�v���z07
		strSQL = strSQL & "      , SMDURIKN08 " '����W�v���z08
		strSQL = strSQL & "      , SMDURIKN09 " '����W�v���z09
		strSQL = strSQL & "      , SMDUZEKN " '�������ŋ��z
		strSQL = strSQL & "      , FAKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , FAKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , FAKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , FAKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , FAKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , FAKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , FBKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , FBKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , FBKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , FBKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , FBKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , FBKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , SMDGNKKN00 " '�����W�v���z00
		strSQL = strSQL & "      , SMDGNKKN01 " '�����W�v���z01
		strSQL = strSQL & "      , SMDGNKKN02 " '�����W�v���z02
		strSQL = strSQL & "      , SMDGNKKN03 " '�����W�v���z03
		strSQL = strSQL & "      , SMDGNKKN04 " '�����W�v���z04
		strSQL = strSQL & "      , SMDGNKKN05 " '�����W�v���z05
		strSQL = strSQL & "      , SMDGNKKN06 " '�����W�v���z06
		strSQL = strSQL & "      , SMDGNKKN07 " '�����W�v���z07
		strSQL = strSQL & "      , SMDGNKKN08 " '�����W�v���z08
		strSQL = strSQL & "      , SMDGNKKN09 " '�����W�v���z09
		strSQL = strSQL & "      , SMDNYUKN00 " '�����W�v���z00
		strSQL = strSQL & "      , SMDNYUKN01 " '�����W�v���z01
		strSQL = strSQL & "      , SMDNYUKN02 " '�����W�v���z02
		strSQL = strSQL & "      , SMDNYUKN03 " '�����W�v���z03
		strSQL = strSQL & "      , SMDNYUKN04 " '�����W�v���z04
		strSQL = strSQL & "      , SMDNYUKN05 " '�����W�v���z05
		strSQL = strSQL & "      , SMDNYUKN06 " '�����W�v���z06
		strSQL = strSQL & "      , SMDNYUKN07 " '�����W�v���z07
		strSQL = strSQL & "      , SMDNYUKN08 " '�����W�v���z08
		strSQL = strSQL & "      , SMDNYUKN09 " '�����W�v���z09
		strSQL = strSQL & "      , DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.TUKKB, 3) & "' " '�ʉ݋敪
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' " '�o�������t
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSMDURIKN)) '����W�v���z00
		strSQL = strSQL & "      , 0 " '����W�v���z01
		strSQL = strSQL & "      , 0 " '����W�v���z02
		strSQL = strSQL & "      , 0 " '����W�v���z03
		strSQL = strSQL & "      , 0 " '����W�v���z04
		strSQL = strSQL & "      , 0 " '����W�v���z05
		strSQL = strSQL & "      , 0 " '����W�v���z06
		strSQL = strSQL & "      , 0 " '����W�v���z07
		strSQL = strSQL & "      , 0 " '����W�v���z08
		strSQL = strSQL & "      , 0 " '����W�v���z09
		strSQL = strSQL & "      , 0 " '�������ŋ��z
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����W�v���z00
		strSQL = strSQL & "      , 0 " '�����W�v���z01
		strSQL = strSQL & "      , 0 " '�����W�v���z02
		strSQL = strSQL & "      , 0 " '�����W�v���z03
		strSQL = strSQL & "      , 0 " '�����W�v���z04
		strSQL = strSQL & "      , 0 " '�����W�v���z05
		strSQL = strSQL & "      , 0 " '�����W�v���z06
		strSQL = strSQL & "      , 0 " '�����W�v���z07
		strSQL = strSQL & "      , 0 " '�����W�v���z08
		strSQL = strSQL & "      , 0 " '�����W�v���z09
		strSQL = strSQL & "      , 0 " '�����W�v���z00
		strSQL = strSQL & "      , 0 " '�����W�v���z01
		strSQL = strSQL & "      , 0 " '�����W�v���z02
		strSQL = strSQL & "      , 0 " '�����W�v���z03
		strSQL = strSQL & "      , 0 " '�����W�v���z04
		strSQL = strSQL & "      , 0 " '�����W�v���z05
		strSQL = strSQL & "      , 0 " '�����W�v���z06
		strSQL = strSQL & "      , 0 " '�����W�v���z07
		strSQL = strSQL & "      , 0 " '�����W�v���z08
		strSQL = strSQL & "      , 0 " '�����W�v���z09
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "      ) "
		
		AE_TOKSMD_INS_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSMD_UPD_SQL
	'   �T�v�F  ���|�T�}���O�ݍX�VSQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSMD_UPD_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSMDURIKN As Decimal
		
		AE_TOKSMD_UPD_SQL = ""
		
		'������z�̍����Z�o
		curSMDURIKN = pin_usrURITHA.curSFUrikn_New - pin_usrURITHA.curSFUrikn_Old
		
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSMD SET "
		strSQL = strSQL & "        SMDURIKN00 = SMDURIKN00 + " & CF_Ora_Number(CStr(curSMDURIKN)) '����W�v���z00
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' "
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_usrURITHA.TUKKB, 3) & "' "
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' "
		
		AE_TOKSMD_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSME_UPD_Main
	'   �T�v�F  ���|�T�}�������X�V
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  ���|�T�}�������ɒǉ��A�X�V���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSME_UPD_Main(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		Dim bolTran As Boolean
		'UPGRADE_WARNING: �\���� usrOdy_TOKSME �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_TOKSME As U_Ody
		
		On Error GoTo AE_TOKSME_UPD_Main_Err
		
		AE_TOKSME_UPD_Main = 9
		bolTran = False
		
		'���|�T�}����������
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(*) AS CNT"
		strSQL = strSQL & "   FROM TOKSME "
		strSQL = strSQL & "  WHERE TOKCD  = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND SMADT  = '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' "
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_TOKSME, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSME_UPD_Main_Err
		End If
		
		bolTran = True
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(usrOdy_TOKSME, CNT, 0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Ora_GetDyn(usrOdy_TOKSME, "CNT", 0) = 0 Then
			'���|�T�}�������̍쐬
			strSQL = AE_TOKSME_INS_SQL(pin_usrURITHA)
		Else
			'���|�T�}�������̍X�V
			strSQL = AE_TOKSME_UPD_SQL(pin_usrURITHA)
		End If
		
		'�r�p�k���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSME_UPD_Main_Err
		End If
		
		AE_TOKSME_UPD_Main = 0
		
AE_TOKSME_UPD_Main_End: 
		If bolTran = True Then
			'���R�[�h�Z�b�g�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_TOKSME)
		End If
		
		Exit Function
		
AE_TOKSME_UPD_Main_Err: 
		'�G���[�ӏ��ҏW
		pin_usrURITHA.strErr = "AE_TOKSME_UPD_Main"
		GoTo AE_TOKSME_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSME_INS_SQL
	'   �T�v�F  ���|�T�}�������쐬SQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSME_INS_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSMAURIKN As Decimal
		Dim curSMAUZEKN As Decimal
		
		AE_TOKSME_INS_SQL = ""
		
		'������z�̍����Z�o
		curSMAURIKN = pin_usrURITHA.curSUrikn_New - pin_usrURITHA.curSUrikn_Old
		'����Ŋz�̍����Z�o
		curSMAUZEKN = pin_usrURITHA.curSUzeikn_New - pin_usrURITHA.curSUzeikn_Old
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSME "
		strSQL = strSQL & "      ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , SMADT " '�o�������t
		strSQL = strSQL & "      , SMAURIKN00 " '����W�v���z00
		strSQL = strSQL & "      , SMAURIKN01 " '����W�v���z01
		strSQL = strSQL & "      , SMAURIKN02 " '����W�v���z02
		strSQL = strSQL & "      , SMAURIKN03 " '����W�v���z03
		strSQL = strSQL & "      , SMAURIKN04 " '����W�v���z04
		strSQL = strSQL & "      , SMAURIKN05 " '����W�v���z05
		strSQL = strSQL & "      , SMAURIKN06 " '����W�v���z06
		strSQL = strSQL & "      , SMAURIKN07 " '����W�v���z07
		strSQL = strSQL & "      , SMAURIKN08 " '����W�v���z08
		strSQL = strSQL & "      , SMAURIKN09 " '����W�v���z09
		strSQL = strSQL & "      , SMAUZEKN " '�������ŋ��z
		strSQL = strSQL & "      , SZAKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , SZAKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , SZAKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , SZAKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , SZAKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , SZAKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , SZBKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , SZBKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , SZBKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , SZBKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , SZBKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , SZBKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , SMAGNKKN00 " '�����W�v���z00
		strSQL = strSQL & "      , SMAGNKKN01 " '�����W�v���z01
		strSQL = strSQL & "      , SMAGNKKN02 " '�����W�v���z02
		strSQL = strSQL & "      , SMAGNKKN03 " '�����W�v���z03
		strSQL = strSQL & "      , SMAGNKKN04 " '�����W�v���z04
		strSQL = strSQL & "      , SMAGNKKN05 " '�����W�v���z05
		strSQL = strSQL & "      , SMAGNKKN06 " '�����W�v���z06
		strSQL = strSQL & "      , SMAGNKKN07 " '�����W�v���z07
		strSQL = strSQL & "      , SMAGNKKN08 " '�����W�v���z08
		strSQL = strSQL & "      , SMAGNKKN09 " '�����W�v���z09
		strSQL = strSQL & "      , SMANYUKN00 " '�����W�v���z00
		strSQL = strSQL & "      , SMANYUKN01 " '�����W�v���z01
		strSQL = strSQL & "      , SMANYUKN02 " '�����W�v���z02
		strSQL = strSQL & "      , SMANYUKN03 " '�����W�v���z03
		strSQL = strSQL & "      , SMANYUKN04 " '�����W�v���z04
		strSQL = strSQL & "      , SMANYUKN05 " '�����W�v���z05
		strSQL = strSQL & "      , SMANYUKN06 " '�����W�v���z06
		strSQL = strSQL & "      , SMANYUKN07 " '�����W�v���z07
		strSQL = strSQL & "      , SMANYUKN08 " '�����W�v���z08
		strSQL = strSQL & "      , SMANYUKN09 " '�����W�v���z09
		strSQL = strSQL & "      , DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' " '�o�������t
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSMAURIKN)) '����W�v���z00
		strSQL = strSQL & "      , 0 " '����W�v���z01
		strSQL = strSQL & "      , 0 " '����W�v���z02
		strSQL = strSQL & "      , 0 " '����W�v���z03
		strSQL = strSQL & "      , 0 " '����W�v���z04
		strSQL = strSQL & "      , 0 " '����W�v���z05
		strSQL = strSQL & "      , 0 " '����W�v���z06
		strSQL = strSQL & "      , 0 " '����W�v���z07
		strSQL = strSQL & "      , 0 " '����W�v���z08
		strSQL = strSQL & "      , 0 " '����W�v���z09
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSMAUZEKN)) '�������ŋ��z
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����W�v���z00
		strSQL = strSQL & "      , 0 " '�����W�v���z01
		strSQL = strSQL & "      , 0 " '�����W�v���z02
		strSQL = strSQL & "      , 0 " '�����W�v���z03
		strSQL = strSQL & "      , 0 " '�����W�v���z04
		strSQL = strSQL & "      , 0 " '�����W�v���z05
		strSQL = strSQL & "      , 0 " '�����W�v���z06
		strSQL = strSQL & "      , 0 " '�����W�v���z07
		strSQL = strSQL & "      , 0 " '�����W�v���z08
		strSQL = strSQL & "      , 0 " '�����W�v���z09
		strSQL = strSQL & "      , 0 " '�����W�v���z00
		strSQL = strSQL & "      , 0 " '�����W�v���z01
		strSQL = strSQL & "      , 0 " '�����W�v���z02
		strSQL = strSQL & "      , 0 " '�����W�v���z03
		strSQL = strSQL & "      , 0 " '�����W�v���z04
		strSQL = strSQL & "      , 0 " '�����W�v���z05
		strSQL = strSQL & "      , 0 " '�����W�v���z06
		strSQL = strSQL & "      , 0 " '�����W�v���z07
		strSQL = strSQL & "      , 0 " '�����W�v���z08
		strSQL = strSQL & "      , 0 " '�����W�v���z09
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "      ) "
		
		AE_TOKSME_INS_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSME_UPD_SQL
	'   �T�v�F  ���|�T�}�������X�VSQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSME_UPD_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSMAURIKN As Decimal
		Dim curSMAUZEKN As Decimal
		
		AE_TOKSME_UPD_SQL = ""
		
		'������z�̍����Z�o
		curSMAURIKN = pin_usrURITHA.curSUrikn_New - pin_usrURITHA.curSUrikn_Old
		'����Ŋz�̍����Z�o
		curSMAUZEKN = pin_usrURITHA.curSUzeikn_New - pin_usrURITHA.curSUzeikn_Old
		
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSME SET "
		strSQL = strSQL & "        SMAURIKN00 = SMAURIKN00 + " & CF_Ora_Number(CStr(curSMAURIKN)) '����W�v���z00
		strSQL = strSQL & "      , SMAUZEKN   = SMAUZEKN   + " & CF_Ora_Number(CStr(curSMAUZEKN)) '�������ŋ��z
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND SMADT = '" & CF_Ora_Date(pin_usrURITHA.SMADT) & "' "
		
		AE_TOKSME_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSSA_UPD_Main
	'   �T�v�F  �����T�}���X�V
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  �����T�}���ɒǉ��A�X�V���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSA_UPD_Main(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		Dim bolTran As Boolean
		'UPGRADE_WARNING: �\���� usrOdy_TOKSSA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_TOKSSA As U_Ody
		
		On Error GoTo AE_TOKSSA_UPD_Main_Err
		
		AE_TOKSSA_UPD_Main = 9
		bolTran = False
		
		'�����T�}������
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(*) AS CNT"
		strSQL = strSQL & "   FROM TOKSSA "
		strSQL = strSQL & "  WHERE TOKCD  = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND SSADT  = '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' "
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_TOKSSA, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSSA_UPD_Main_Err
		End If
		
		bolTran = True
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(usrOdy_TOKSSA, CNT, 0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Ora_GetDyn(usrOdy_TOKSSA, "CNT", 0) = 0 Then
			'�����T�}���̍쐬
			strSQL = AE_TOKSSA_INS_SQL(pin_intCnt, pin_usrURITHA)
		Else
			'�����T�}���̍X�V
			strSQL = AE_TOKSSA_UPD_SQL(pin_intCnt, pin_usrURITHA)
		End If
		
		'�r�p�k���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSSA_UPD_Main_Err
		End If
		
		AE_TOKSSA_UPD_Main = 0
		
AE_TOKSSA_UPD_Main_End: 
		If bolTran = True Then
			'���R�[�h�Z�b�g�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_TOKSSA)
		End If
		
		Exit Function
		
AE_TOKSSA_UPD_Main_Err: 
		'�G���[�ӏ��ҏW
		pin_usrURITHA.strErr = "AE_TOKSSA_UPD_Main"
		GoTo AE_TOKSSA_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSSA_INS_SQL
	'   �T�v�F  �����T�}���쐬SQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSA_INS_SQL(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSSAURIKN As Decimal
		Dim curSSAUZEKN As Decimal
		
		AE_TOKSSA_INS_SQL = ""
		
		'������z�̍����Z�o
		curSSAURIKN = pin_usrURITHA.curUrikn_New(pin_intCnt) - pin_usrURITHA.curUrikn_Old(pin_intCnt)
		'����Ŋz�̍����Z�o
		curSSAUZEKN = pin_usrURITHA.curUzeikn_New(pin_intCnt) - pin_usrURITHA.curUzeikn_Old(pin_intCnt)
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSSA "
		strSQL = strSQL & "      ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , SSADT " '�����t
		strSQL = strSQL & "      , KESDT " '���ϓ��t
		strSQL = strSQL & "      , SSAURIKN00 " '����W�v���z00
		strSQL = strSQL & "      , SSAURIKN01 " '����W�v���z01
		strSQL = strSQL & "      , SSAURIKN02 " '����W�v���z02
		strSQL = strSQL & "      , SSAURIKN03 " '����W�v���z03
		strSQL = strSQL & "      , SSAURIKN04 " '����W�v���z04
		strSQL = strSQL & "      , SSAURIKN05 " '����W�v���z05
		strSQL = strSQL & "      , SSAURIKN06 " '����W�v���z06
		strSQL = strSQL & "      , SSAURIKN07 " '����W�v���z07
		strSQL = strSQL & "      , SSAURIKN08 " '����W�v���z08
		strSQL = strSQL & "      , SSAURIKN09 " '����W�v���z09
		strSQL = strSQL & "      , SSAUZEKN " '�������ŋ��z
		strSQL = strSQL & "      , SZAKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , SZAKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , SZAKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , SZAKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , SZAKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , SZAKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , SZBKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , SZBKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , SZBKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , SZBKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , SZBKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , SZBKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , SSANYUKN00 " '�����W�v���z00
		strSQL = strSQL & "      , SSANYUKN01 " '�����W�v���z01
		strSQL = strSQL & "      , SSANYUKN02 " '�����W�v���z02
		strSQL = strSQL & "      , SSANYUKN03 " '�����W�v���z03
		strSQL = strSQL & "      , SSANYUKN04 " '�����W�v���z04
		strSQL = strSQL & "      , SSANYUKN05 " '�����W�v���z05
		strSQL = strSQL & "      , SSANYUKN06 " '�����W�v���z06
		strSQL = strSQL & "      , SSANYUKN07 " '�����W�v���z07
		strSQL = strSQL & "      , SSANYUKN08 " '�����W�v���z08
		strSQL = strSQL & "      , SSANYUKN09 " '�����W�v���z09
		strSQL = strSQL & "      , KSKNYKKN " '���������z
		strSQL = strSQL & "      , KSKZANKN " '���������z�c
		strSQL = strSQL & "      , SSADENSU " '�`�[����
		strSQL = strSQL & "      , DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' " '�����t
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.KESDT(pin_intCnt)) & "' " '���ϓ��t
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSSAURIKN)) '����W�v���z00
		strSQL = strSQL & "      , 0 " '����W�v���z01
		strSQL = strSQL & "      , 0 " '����W�v���z02
		strSQL = strSQL & "      , 0 " '����W�v���z03
		strSQL = strSQL & "      , 0 " '����W�v���z04
		strSQL = strSQL & "      , 0 " '����W�v���z05
		strSQL = strSQL & "      , 0 " '����W�v���z06
		strSQL = strSQL & "      , 0 " '����W�v���z07
		strSQL = strSQL & "      , 0 " '����W�v���z08
		strSQL = strSQL & "      , 0 " '����W�v���z09
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSSAUZEKN)) '�������ŋ��z
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����W�v���z00
		strSQL = strSQL & "      , 0 " '�����W�v���z01
		strSQL = strSQL & "      , 0 " '�����W�v���z02
		strSQL = strSQL & "      , 0 " '�����W�v���z03
		strSQL = strSQL & "      , 0 " '�����W�v���z04
		strSQL = strSQL & "      , 0 " '�����W�v���z05
		strSQL = strSQL & "      , 0 " '�����W�v���z06
		strSQL = strSQL & "      , 0 " '�����W�v���z07
		strSQL = strSQL & "      , 0 " '�����W�v���z08
		strSQL = strSQL & "      , 0 " '�����W�v���z09
		strSQL = strSQL & "      , 0 " '���������z
		strSQL = strSQL & "      , 0 " '���������z�c
		strSQL = strSQL & "      , 0 " '�`�[����
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "      ) "
		
		AE_TOKSSA_INS_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSSA_UPD_SQL
	'   �T�v�F  �����T�}���X�VSQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSA_UPD_SQL(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSSAURIKN As Decimal
		Dim curSSAUZEKN As Decimal
		
		AE_TOKSSA_UPD_SQL = ""
		
		'������z�̍����Z�o
		curSSAURIKN = pin_usrURITHA.curUrikn_New(pin_intCnt) - pin_usrURITHA.curUrikn_Old(pin_intCnt)
		'����Ŋz�̍����Z�o
		curSSAUZEKN = pin_usrURITHA.curUzeikn_New(pin_intCnt) - pin_usrURITHA.curUzeikn_Old(pin_intCnt)
		
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSA SET "
		strSQL = strSQL & "        SSAURIKN00 = SSAURIKN00 + " & CF_Ora_Number(CStr(curSSAURIKN)) '����W�v���z00
		strSQL = strSQL & "      , SSAUZEKN   = SSAUZEKN   + " & CF_Ora_Number(CStr(curSSAUZEKN)) '�������ŋ��z
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND SSADT = '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' "
		
		AE_TOKSSA_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSSB_UPD_Main
	'   �T�v�F  �O�󐿋��T�}���X�V
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  �O�󐿋��T�}���ɒǉ��A�X�V���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSB_UPD_Main(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		Dim bolTran As Boolean
		'UPGRADE_WARNING: �\���� usrOdy_TOKSSB �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_TOKSSB As U_Ody
		
		On Error GoTo AE_TOKSSB_UPD_Main_Err
		
		AE_TOKSSB_UPD_Main = 9
		bolTran = False
		
		'�O�󐿋��T�}������
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(*) AS CNT"
		strSQL = strSQL & "   FROM TOKSSB "
		strSQL = strSQL & "  WHERE TOKCD  = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND SSADT  = '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' "
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_TOKSSB, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSSB_UPD_Main_Err
		End If
		
		bolTran = True
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(usrOdy_TOKSSB, CNT, 0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Ora_GetDyn(usrOdy_TOKSSB, "CNT", 0) = 0 Then
			'�O�󐿋��T�}���̍쐬
			strSQL = AE_TOKSSB_INS_SQL(pin_intCnt, pin_usrURITHA)
		Else
			'�O�󐿋��T�}���̍X�V
			strSQL = AE_TOKSSB_UPD_SQL(pin_intCnt, pin_usrURITHA)
		End If
		
		'�r�p�k���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSSB_UPD_Main_Err
		End If
		
		AE_TOKSSB_UPD_Main = 0
		
AE_TOKSSB_UPD_Main_End: 
		If bolTran = True Then
			'���R�[�h�Z�b�g�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_TOKSSB)
		End If
		
		Exit Function
		
AE_TOKSSB_UPD_Main_Err: 
		'�G���[�ӏ��ҏW
		pin_usrURITHA.strErr = "AE_TOKSSB_UPD_Main"
		GoTo AE_TOKSSB_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSSB_INS_SQL
	'   �T�v�F  �O�󐿋��T�}���쐬SQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSB_INS_SQL(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSSAURIKN As Decimal
		Dim curSSAUZEKN As Decimal
		
		AE_TOKSSB_INS_SQL = ""
		
		'������z�̍����Z�o
		curSSAURIKN = pin_usrURITHA.curUrikn_New(pin_intCnt) - pin_usrURITHA.curUrikn_Old(pin_intCnt)
		'����Ŋz�̍����Z�o
		curSSAUZEKN = pin_usrURITHA.curUzeikn_New(pin_intCnt) - pin_usrURITHA.curUzeikn_Old(pin_intCnt)
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSSB "
		strSQL = strSQL & "      ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , SSADT " '�����t
		strSQL = strSQL & "      , KESDT " '���ϓ��t
		strSQL = strSQL & "      , SSAURIKN00 " '����W�v���z00
		strSQL = strSQL & "      , SSAURIKN01 " '����W�v���z01
		strSQL = strSQL & "      , SSAURIKN02 " '����W�v���z02
		strSQL = strSQL & "      , SSAURIKN03 " '����W�v���z03
		strSQL = strSQL & "      , SSAURIKN04 " '����W�v���z04
		strSQL = strSQL & "      , SSAURIKN05 " '����W�v���z05
		strSQL = strSQL & "      , SSAURIKN06 " '����W�v���z06
		strSQL = strSQL & "      , SSAURIKN07 " '����W�v���z07
		strSQL = strSQL & "      , SSAURIKN08 " '����W�v���z08
		strSQL = strSQL & "      , SSAURIKN09 " '����W�v���z09
		strSQL = strSQL & "      , SSAUZEKN " '�������ŋ��z
		strSQL = strSQL & "      , SZAKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , SZAKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , SZAKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , SZAKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , SZAKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , SZAKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , SZBKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , SZBKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , SZBKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , SZBKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , SZBKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , SZBKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , SSANYUKN00 " '�����W�v���z00
		strSQL = strSQL & "      , SSANYUKN01 " '�����W�v���z01
		strSQL = strSQL & "      , SSANYUKN02 " '�����W�v���z02
		strSQL = strSQL & "      , SSANYUKN03 " '�����W�v���z03
		strSQL = strSQL & "      , SSANYUKN04 " '�����W�v���z04
		strSQL = strSQL & "      , SSANYUKN05 " '�����W�v���z05
		strSQL = strSQL & "      , SSANYUKN06 " '�����W�v���z06
		strSQL = strSQL & "      , SSANYUKN07 " '�����W�v���z07
		strSQL = strSQL & "      , SSANYUKN08 " '�����W�v���z08
		strSQL = strSQL & "      , SSANYUKN09 " '�����W�v���z09
		strSQL = strSQL & "      , KSKNYKKN " '���������z
		strSQL = strSQL & "      , KSKZANKN " '���������z�c
		strSQL = strSQL & "      , SSADENSU " '�`�[����
		strSQL = strSQL & "      , DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' " '�����t
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.KESDT(pin_intCnt)) & "' " '���ϓ��t
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSSAURIKN)) '����W�v���z00
		strSQL = strSQL & "      , 0 " '����W�v���z01
		strSQL = strSQL & "      , 0 " '����W�v���z02
		strSQL = strSQL & "      , 0 " '����W�v���z03
		strSQL = strSQL & "      , 0 " '����W�v���z04
		strSQL = strSQL & "      , 0 " '����W�v���z05
		strSQL = strSQL & "      , 0 " '����W�v���z06
		strSQL = strSQL & "      , 0 " '����W�v���z07
		strSQL = strSQL & "      , 0 " '����W�v���z08
		strSQL = strSQL & "      , 0 " '����W�v���z09
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSSAUZEKN)) '�������ŋ��z
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����W�v���z00
		strSQL = strSQL & "      , 0 " '�����W�v���z01
		strSQL = strSQL & "      , 0 " '�����W�v���z02
		strSQL = strSQL & "      , 0 " '�����W�v���z03
		strSQL = strSQL & "      , 0 " '�����W�v���z04
		strSQL = strSQL & "      , 0 " '�����W�v���z05
		strSQL = strSQL & "      , 0 " '�����W�v���z06
		strSQL = strSQL & "      , 0 " '�����W�v���z07
		strSQL = strSQL & "      , 0 " '�����W�v���z08
		strSQL = strSQL & "      , 0 " '�����W�v���z09
		strSQL = strSQL & "      , 0 " '���������z
		strSQL = strSQL & "      , 0 " '���������z�c
		strSQL = strSQL & "      , 0 " '�`�[����
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "      ) "
		
		AE_TOKSSB_INS_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSSB_UPD_SQL
	'   �T�v�F  �O�󐿋��T�}���X�VSQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSB_UPD_SQL(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSSAURIKN As Decimal
		Dim curSSAUZEKN As Decimal
		
		AE_TOKSSB_UPD_SQL = ""
		
		'������z�̍����Z�o
		curSSAURIKN = pin_usrURITHA.curSUrikn_New - pin_usrURITHA.curSUrikn_Old
		'����Ŋz�̍����Z�o
		curSSAUZEKN = pin_usrURITHA.curSUzeikn_New - pin_usrURITHA.curSUzeikn_Old
		
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSB SET "
		strSQL = strSQL & "        SSAURIKN00 = SSAURIKN00 + " & CF_Ora_Number(CStr(curSSAURIKN)) '����W�v���z00
		strSQL = strSQL & "      , SSAUZEKN   = SSAUZEKN   + " & CF_Ora_Number(CStr(curSSAUZEKN)) '�������ŋ��z
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND SSADT = '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' "
		
		AE_TOKSSB_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSSC_UPD_Main
	'   �T�v�F  �����T�}���O�ݍX�V
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  �����T�}���O�݂ɒǉ��A�X�V���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSC_UPD_Main(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		Dim bolTran As Boolean
		'UPGRADE_WARNING: �\���� usrOdy_TOKSSC �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_TOKSSC As U_Ody
		
		On Error GoTo AE_TOKSSC_UPD_Main_Err
		
		AE_TOKSSC_UPD_Main = 9
		bolTran = False
		
		'�����T�}���O�݌���
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(*) AS CNT"
		strSQL = strSQL & "   FROM TOKSSC "
		strSQL = strSQL & "  WHERE TOKCD  = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_usrURITHA.TUKKB, 3) & "' "
		strSQL = strSQL & "    AND SSADT  = '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' "
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_TOKSSC, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSSC_UPD_Main_Err
		End If
		
		bolTran = True
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(usrOdy_TOKSSC, CNT, 0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If CF_Ora_GetDyn(usrOdy_TOKSSC, "CNT", 0) = 0 Then
			'�����T�}���O�݂̍쐬
			strSQL = AE_TOKSSC_INS_SQL(pin_intCnt, pin_usrURITHA)
		Else
			'�����T�}���O�݂̍X�V
			strSQL = AE_TOKSSC_UPD_SQL(pin_intCnt, pin_usrURITHA)
		End If
		
		'�r�p�k���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_TOKSSC_UPD_Main_Err
		End If
		
		AE_TOKSSC_UPD_Main = 0
		
AE_TOKSSC_UPD_Main_End: 
		If bolTran = True Then
			'���R�[�h�Z�b�g�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_TOKSSC)
		End If
		
		Exit Function
		
AE_TOKSSC_UPD_Main_Err: 
		'�G���[�ӏ��ҏW
		pin_usrURITHA.strErr = "AE_TOKSSC_UPD_Main"
		GoTo AE_TOKSSC_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSSC_INS_SQL
	'   �T�v�F  �����T�}���O�ݍ쐬SQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSC_INS_SQL(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSSCURIKN As Decimal
		Dim curSSCUZEKN As Decimal
		
		AE_TOKSSC_INS_SQL = ""
		
		'������z�̍����Z�o
		curSSCURIKN = pin_usrURITHA.curFUrikn_New(pin_intCnt) - pin_usrURITHA.curFUrikn_Old(pin_intCnt)
		'����Ŋz�̍����Z�o
		curSSCUZEKN = pin_usrURITHA.curUzeikn_New(pin_intCnt) - pin_usrURITHA.curUzeikn_Old(pin_intCnt)
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKSSC "
		strSQL = strSQL & "      ( TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , TUKKB " '�ʉ݋敪
		strSQL = strSQL & "      , SSADT " '�����t
		strSQL = strSQL & "      , KESDT " '���ϓ��t
		strSQL = strSQL & "      , SSCURIKN00 " '����W�v���z00
		strSQL = strSQL & "      , SSCURIKN01 " '����W�v���z01
		strSQL = strSQL & "      , SSCURIKN02 " '����W�v���z02
		strSQL = strSQL & "      , SSCURIKN03 " '����W�v���z03
		strSQL = strSQL & "      , SSCURIKN04 " '����W�v���z04
		strSQL = strSQL & "      , SSCURIKN05 " '����W�v���z05
		strSQL = strSQL & "      , SSCURIKN06 " '����W�v���z06
		strSQL = strSQL & "      , SSCURIKN07 " '����W�v���z07
		strSQL = strSQL & "      , SSCURIKN08 " '����W�v���z08
		strSQL = strSQL & "      , SSCURIKN09 " '����W�v���z09
		strSQL = strSQL & "      , SSCUZEKN " '�������ŋ��z
		strSQL = strSQL & "      , FAKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , FAKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , FAKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , FAKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , FAKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , FAKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , FBKZIKN00 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , FBKZIKN01 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , FBKZIKN02 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , FBKZOKN00 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , FBKZOKN01 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , FBKZOKN02 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , SSCNYUKN00 " '�����W�v���z00
		strSQL = strSQL & "      , SSCNYUKN01 " '�����W�v���z01
		strSQL = strSQL & "      , SSCNYUKN02 " '�����W�v���z02
		strSQL = strSQL & "      , SSCNYUKN03 " '�����W�v���z03
		strSQL = strSQL & "      , SSCNYUKN04 " '�����W�v���z04
		strSQL = strSQL & "      , SSCNYUKN05 " '�����W�v���z05
		strSQL = strSQL & "      , SSCNYUKN06 " '�����W�v���z06
		strSQL = strSQL & "      , SSCNYUKN07 " '�����W�v���z07
		strSQL = strSQL & "      , SSCNYUKN08 " '�����W�v���z08
		strSQL = strSQL & "      , SSCNYUKN09 " '�����W�v���z09
		strSQL = strSQL & "      , FKSNYKKN " '���������z
		strSQL = strSQL & "      , FKSZANKN " '���������z�c
		strSQL = strSQL & "      , SSCDENSU " '�`�[����
		strSQL = strSQL & "      , DATNO " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , WRTTM " '��ѽ����(����)
		strSQL = strSQL & "      , WRTDT " '��ѽ����(���t)
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.TUKKB, 3) & "' " '�ʉ݋敪
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' " '�����t
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.KESDT(pin_intCnt)) & "' " '���ϓ��t
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSSCURIKN)) '����W�v���z00
		strSQL = strSQL & "      , 0 " '����W�v���z01
		strSQL = strSQL & "      , 0 " '����W�v���z02
		strSQL = strSQL & "      , 0 " '����W�v���z03
		strSQL = strSQL & "      , 0 " '����W�v���z04
		strSQL = strSQL & "      , 0 " '����W�v���z05
		strSQL = strSQL & "      , 0 " '����W�v���z06
		strSQL = strSQL & "      , 0 " '����W�v���z07
		strSQL = strSQL & "      , 0 " '����W�v���z08
		strSQL = strSQL & "      , 0 " '����W�v���z09
		strSQL = strSQL & "      , " & CF_Ora_Number(CStr(curSSCUZEKN)) '�������ŋ��z
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐō��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z00
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z01
		strSQL = strSQL & "      , 0 " '�����N�ʐŔ��ېŋ��z02
		strSQL = strSQL & "      , 0 " '�����W�v���z00
		strSQL = strSQL & "      , 0 " '�����W�v���z01
		strSQL = strSQL & "      , 0 " '�����W�v���z02
		strSQL = strSQL & "      , 0 " '�����W�v���z03
		strSQL = strSQL & "      , 0 " '�����W�v���z04
		strSQL = strSQL & "      , 0 " '�����W�v���z05
		strSQL = strSQL & "      , 0 " '�����W�v���z06
		strSQL = strSQL & "      , 0 " '�����W�v���z07
		strSQL = strSQL & "      , 0 " '�����W�v���z08
		strSQL = strSQL & "      , 0 " '�����W�v���z09
		strSQL = strSQL & "      , 0 " '���������z
		strSQL = strSQL & "      , 0 " '���������z�c
		strSQL = strSQL & "      , 0 " '�`�[����
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 10) & "' " '�`�[�Ǘ�NO.
		strSQL = strSQL & "      , '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "      ) "
		
		AE_TOKSSC_INS_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKSSC_UPD_SQL
	'   �T�v�F  �����T�}���O�ݍX�VSQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKSSC_UPD_SQL(ByVal pin_intCnt As Short, ByRef pin_usrURITHA As Cmn_UDNTHA_Upd) As String
		
		Dim strSQL As String
		Dim curSSCURIKN As Decimal
		Dim curSSCUZEKN As Decimal
		
		AE_TOKSSC_UPD_SQL = ""
		
		'������z�̍����Z�o
		curSSCURIKN = pin_usrURITHA.curFUrikn_New(pin_intCnt) - pin_usrURITHA.curFUrikn_Old(pin_intCnt)
		
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKSSC SET "
		strSQL = strSQL & "        SSCURIKN00 = SSCURIKN00 + " & CF_Ora_Number(CStr(curSSCURIKN)) '����W�v���z00
		strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_usrURITHA.TOKSEICD, 10) & "' "
		strSQL = strSQL & "    AND TUKKB = '" & CF_Ora_String(pin_usrURITHA.TUKKB, 3) & "' "
		strSQL = strSQL & "    AND SSADT = '" & CF_Ora_Date(pin_usrURITHA.SSADT(pin_intCnt)) & "' "
		
		AE_TOKSSC_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKMTB_UPD_Main
	'   �T�v�F  �̔��P�������}�X�^�X�V
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  0�F����@9: �ُ�
	'   ���l�F  �̔��P�������}�X�^�ɒǉ��A�X�V���s��
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKMTB_UPD_Main(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA() As Cmn_UDNTRA_Upd) As Short
		
		Dim bolRet As Boolean
		Dim intCnt As Short
		Dim strSQL As String
		Dim bolTran As Boolean
		'UPGRADE_WARNING: �\���� usrOdy_TOKMTB �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_TOKMTB As U_Ody
		
		On Error GoTo AE_TOKMTB_UPD_Main_Err
		
		AE_TOKMTB_UPD_Main = 9
		bolTran = False
		
		For intCnt = 1 To UBound(pin_usrURITRA)
			
			'�̔��P�������}�X�^����
			strSQL = ""
			strSQL = strSQL & " SELECT * "
			strSQL = strSQL & "   FROM TOKMTB "
			strSQL = strSQL & "  WHERE TOKCD  = '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' "
			strSQL = strSQL & "    AND HINCD  = '" & CF_Ora_String(pin_usrURITRA(intCnt).HINCD, 10) & "' "
			
			'SQL���s
			bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_TOKMTB, strSQL)
			If bolRet = False Then
				GoTo AE_TOKMTB_UPD_Main_Err
			End If
			
			bolTran = True
			
			If CF_Ora_EOF(usrOdy_TOKMTB) = True Then
				'�̔��P�������}�X�^�̍쐬
				strSQL = AE_TOKMTB_INS_SQL(pin_usrURITHA, pin_usrURITRA(intCnt))
				
				'�r�p�k���s
				bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
				If bolRet = False Then
					GoTo AE_TOKMTB_UPD_Main_Err
				End If
			Else
				If pin_usrURITHA.FRNKB = gc_strFRNKB_DMS Then
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(usrOdy_TOKMTB, HISURITK00, 0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If CF_Ora_GetDyn(usrOdy_TOKMTB, "HISURITK00", 0) <> pin_usrURITRA(intCnt).URITK Then
						'�̔��P�������}�X�^�̍X�V
						strSQL = AE_TOKMTB_UPD_SQL(pin_usrURITHA, pin_usrURITRA(intCnt), usrOdy_TOKMTB)
						
						'�r�p�k���s
						bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
						If bolRet = False Then
							GoTo AE_TOKMTB_UPD_Main_Err
						End If
					End If
				Else
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn(usrOdy_TOKMTB, HISURITK00, 0) �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					If CF_Ora_GetDyn(usrOdy_TOKMTB, "HISURITK00", 0) <> pin_usrURITRA(intCnt).FURITK Then
						'�̔��P�������}�X�^�̍X�V
						strSQL = AE_TOKMTB_UPD_SQL(pin_usrURITHA, pin_usrURITRA(intCnt), usrOdy_TOKMTB)
						
						'�r�p�k���s
						bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
						If bolRet = False Then
							GoTo AE_TOKMTB_UPD_Main_Err
						End If
					End If
				End If
			End If
			
			'���R�[�h�Z�b�g�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_TOKMTB)
			
		Next 
		
		AE_TOKMTB_UPD_Main = 0
		
AE_TOKMTB_UPD_Main_End: 
		If bolTran = True Then
			'���R�[�h�Z�b�g�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_TOKMTB)
		End If
		
		Exit Function
		
AE_TOKMTB_UPD_Main_Err: 
		'�G���[�ӏ��ҏW
		pin_usrURITHA.strErr = "AE_TOKMTB_UPD_Main"
		GoTo AE_TOKMTB_UPD_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKMTB_INS_SQL
	'   �T�v�F  �̔��P�������}�X�^�쐬SQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKMTB_INS_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA As Cmn_UDNTRA_Upd) As String
		
		Dim strSQL As String
		
		AE_TOKMTB_INS_SQL = ""
		
		strSQL = ""
		strSQL = strSQL & " INSERT INTO TOKMTB "
		strSQL = strSQL & "      ( DATKB " '�`�[�폜�敪
		strSQL = strSQL & "      , TOKCD " '���Ӑ�R�[�h
		strSQL = strSQL & "      , HINCD " '���i�R�[�h
		strSQL = strSQL & "      , URITKDT00 " '�K�p��
		strSQL = strSQL & "      , URITKDT01 " '�K�p��
		strSQL = strSQL & "      , URITKDT02 " '�K�p��
		strSQL = strSQL & "      , URITKDT03 " '�K�p��
		strSQL = strSQL & "      , URITKDT04 " '�K�p��
		strSQL = strSQL & "      , URITKDT05 " '�K�p��
		strSQL = strSQL & "      , UDNNO00 " '����`�[�ԍ�
		strSQL = strSQL & "      , UDNNO01 " '����`�[�ԍ�
		strSQL = strSQL & "      , UDNNO02 " '����`�[�ԍ�
		strSQL = strSQL & "      , UDNNO03 " '����`�[�ԍ�
		strSQL = strSQL & "      , UDNNO04 " '����`�[�ԍ�
		strSQL = strSQL & "      , UDNNO05 " '����`�[�ԍ�
		strSQL = strSQL & "      , UDNDT00 " '����`�[���t
		strSQL = strSQL & "      , UDNDT01 " '����`�[���t
		strSQL = strSQL & "      , UDNDT02 " '����`�[���t
		strSQL = strSQL & "      , UDNDT03 " '����`�[���t
		strSQL = strSQL & "      , UDNDT04 " '����`�[���t
		strSQL = strSQL & "      , UDNDT05 " '����`�[���t
		strSQL = strSQL & "      , HISURITK00 " '�̔�����P��
		strSQL = strSQL & "      , HISURITK01 " '�̔�����P��
		strSQL = strSQL & "      , HISURITK02 " '�̔�����P��
		strSQL = strSQL & "      , HISURITK03 " '�̔�����P��
		strSQL = strSQL & "      , HISURITK04 " '�̔�����P��
		strSQL = strSQL & "      , HISURITK05 " '�̔�����P��
		strSQL = strSQL & "      , BIKO00 " '���l
		strSQL = strSQL & "      , BIKO01 " '���l
		strSQL = strSQL & "      , BIKO02 " '���l
		strSQL = strSQL & "      , BIKO03 " '���l
		strSQL = strSQL & "      , BIKO04 " '���l
		strSQL = strSQL & "      , BIKO05 " '���l
		strSQL = strSQL & "      , RELFL " '�A�g�t���O
		strSQL = strSQL & "      , OPEID " '�ŏI��Ǝ҃R�[�h
		strSQL = strSQL & "      , CLTID " '�N���C�A���g�h�c
		strSQL = strSQL & "      , WRTTM " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , WRTDT " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "      , WRTFSTTM " '�^�C���X�^���v�i�o�^���ԁj
		strSQL = strSQL & "      , WRTFSTDT " '�^�C���X�^���v�i�o�^���j
		strSQL = strSQL & "      ) "
		strSQL = strSQL & " VALUES "
		strSQL = strSQL & "      ( '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' " '�`�[�폜�敪
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' " '���Ӑ�R�[�h
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITRA.HINCD, 10) & "' " '���i�R�[�h
		strSQL = strSQL & "      , '" & CF_Ora_Date(pin_usrURITHA.UDNDT) & "' " '�K�p��
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '�K�p��
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '�K�p��
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '�K�p��
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '�K�p��
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '�K�p��
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 8) & "' " '����`�[�ԍ�
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 8) & "' " '����`�[�ԍ�
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 8) & "' " '����`�[�ԍ�
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 8) & "' " '����`�[�ԍ�
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 8) & "' " '����`�[�ԍ�
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 8) & "' " '����`�[�ԍ�
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '����`�[���t
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '����`�[���t
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '����`�[���t
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '����`�[���t
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '����`�[���t
		strSQL = strSQL & "      , '" & CF_Ora_Date(Space(1)) & "' " '����`�[���t
		
		If pin_usrURITHA.FRNKB = gc_strFRNKB_DMS Then
			strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.URITK)) '�̔�����P��
		Else
			strSQL = strSQL & "      , " & CF_Ora_Number(CStr(pin_usrURITRA.FURITK)) '�̔�����P��
		End If
		
		strSQL = strSQL & "      , 0 " '�̔�����P��
		strSQL = strSQL & "      , 0 " '�̔�����P��
		strSQL = strSQL & "      , 0 " '�̔�����P��
		strSQL = strSQL & "      , 0 " '�̔�����P��
		strSQL = strSQL & "      , 0 " '�̔�����P��
		strSQL = strSQL & "      , '" & CF_Ora_String(pin_usrURITRA.BIKO, 20) & "' " '���l
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 20) & "' " '���l
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 20) & "' " '���l
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 20) & "' " '���l
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 20) & "' " '���l
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 20) & "' " '���l
		strSQL = strSQL & "      , '" & CF_Ora_String(Space(1), 1) & "' " '�A�g�t���O
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c
		strSQL = strSQL & "      ,  '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c
		strSQL = strSQL & "      , '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "      , '" & GV_SysTime & "' " '�^�C���X�^���v�i���ԁj
		strSQL = strSQL & "      , '" & GV_SysDate & "' " '�^�C���X�^���v�i���t�j
		strSQL = strSQL & "      ) "
		
		AE_TOKMTB_INS_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_TOKMTB_UPD_SQL
	'   �T�v�F  �̔��P�������}�X�^�X�VSQL�ҏW
	'   �����F  pin_usrURITHA     : ���㌩�o���g�����X�V���
	'   �ߒl�F  SQL
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function AE_TOKMTB_UPD_SQL(ByRef pin_usrURITHA As Cmn_UDNTHA_Upd, ByRef pin_usrURITRA As Cmn_UDNTRA_Upd, ByRef pin_usrOdy As U_Ody) As String
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy_UDNTRA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_UDNTRA As U_Ody
		Dim bolOpen As Boolean
		
		AE_TOKMTB_UPD_SQL = ""
		
		'�̔��P�������}�X�^�̍X�V
		strSQL = ""
		strSQL = strSQL & " UPDATE TOKMTB SET "
		strSQL = strSQL & "        URITKDT00  = '" & CF_Ora_Date(pin_usrURITHA.UDNDT) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , URITKDT01  = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "URITKDT00", "")) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , URITKDT02  = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "URITKDT01", "")) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , URITKDT03  = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "URITKDT02", "")) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , URITKDT04  = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "URITKDT03", "")) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , URITKDT05  = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "URITKDT04", "")) & "' "
		strSQL = strSQL & "      , UDNNO00    = '" & CF_Ora_String(Space(1), 8) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , UDNNO01    = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "UDNNO00", ""), 8) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , UDNNO02    = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "UDNNO01", ""), 8) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , UDNNO03    = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "UDNNO02", ""), 8) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , UDNNO04    = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "UDNNO03", ""), 8) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , UDNNO05    = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "UDNNO04", ""), 8) & "' "
		strSQL = strSQL & "      , UDNDT00    = '" & CF_Ora_Date(Space(1)) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , UDNDT01    = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "UDNDT00", "")) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , UDNDT02    = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "UDNDT01", "")) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , UDNDT03    = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "UDNDT02", "")) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , UDNDT04    = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "UDNDT03", "")) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , UDNDT05    = '" & CF_Ora_Date(CF_Ora_GetDyn(pin_usrOdy, "UDNDT04", "")) & "' "
		
		If pin_usrURITHA.FRNKB = gc_strFRNKB_DMS Then
			strSQL = strSQL & "      , HISURITK00 = " & CF_Ora_Number(CStr(pin_usrURITRA.URITK))
		Else
			strSQL = strSQL & "      , HISURITK00 = " & CF_Ora_Number(CStr(pin_usrURITRA.FURITK))
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , HISURITK01 = " & CF_Ora_Number(CF_Ora_GetDyn(pin_usrOdy, "HISURITK00", ""))
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , HISURITK02 = " & CF_Ora_Number(CF_Ora_GetDyn(pin_usrOdy, "HISURITK01", ""))
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , HISURITK03 = " & CF_Ora_Number(CF_Ora_GetDyn(pin_usrOdy, "HISURITK02", ""))
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , HISURITK04 = " & CF_Ora_Number(CF_Ora_GetDyn(pin_usrOdy, "HISURITK03", ""))
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , HISURITK05 = " & CF_Ora_Number(CF_Ora_GetDyn(pin_usrOdy, "HISURITK04", ""))
		strSQL = strSQL & "      , BIKO00     = '" & CF_Ora_String(pin_usrURITRA.BIKO, 20) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , BIKO01     = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "BIKO00", ""), 20) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , BIKO02     = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "BIKO01", ""), 20) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , BIKO03     = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "BIKO02", ""), 20) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , BIKO04     = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "BIKO03", ""), 20) & "' "
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strSQL = strSQL & "      , BIKO05     = '" & CF_Ora_String(CF_Ora_GetDyn(pin_usrOdy, "BIKO04", ""), 20) & "' "
		strSQL = strSQL & "      , OPEID      = '" & SSS_OPEID.Value & "' "
		strSQL = strSQL & "      , CLTID      = '" & SSS_CLTID.Value & "' "
		strSQL = strSQL & "      , WRTTM      = '" & GV_SysTime & "' "
		strSQL = strSQL & "      , WRTDT      = '" & GV_SysDate & "' "
		strSQL = strSQL & "  WHERE TOKCD = '" & CF_Ora_String(pin_usrURITHA.TOKCD, 10) & "' "
		strSQL = strSQL & "    AND HINCD = '" & CF_Ora_String(pin_usrURITRA.HINCD, 10) & "' "
		
		AE_TOKMTB_UPD_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_GetKESDT
	'   �T�v�F  ���ϓ��v�Z����
	'   �����F  Pin_strSSADT    : �v�Z�Ώے����t(�W���̐��lOr���t�j
	'           Pin_strTOKSMEKB : ���ߋ敪
	'           Pin_strTOKKESCC : ����T�C�N��
	'           Pin_strTOKKESDD : ������t
	'           Pin_strTOKKDWKB : ����j��
	'           Pin_strSSAKBN   : �x���������̏����敪�i1�F�O�|���A2�F��|���j
	'           Pot_strKESDT    : �v�Z���ʌ��Z��
	'   �ߒl�F  0�F����@9:�ُ�
	'   ���l�F�@���敪��"��"�̏ꍇ�̌��Z���Z�o
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_GetKESDT(ByVal pin_strSSADT As String, ByVal Pin_strTOKSMEKB As String, ByVal Pin_strTOKKESCC As String, ByVal Pin_strTOKKESDD As String, ByVal Pin_strTOKKDWKB As String, ByVal Pin_strSSAKBN As String, ByRef Pot_strKESDT As String) As Short
		
		Dim strDate As String
		Dim strWKDate As String
		Dim yy As Short
		Dim mm As Short
		Dim dd As Short
		Dim intTOKKESCC As Short '����T�C�N��
		Dim intTOKKESDD As Short
		Dim intTOKSDWKB As Short
		Dim Mst_Inf_Dt As TYPE_DB_CLDMTA
		
		AE_GetKESDT = 9
		Pot_strKESDT = ""
		
		'���t�`�F�b�N
		If IsDate(pin_strSSADT) = True Then
			strDate = VB6.Format(pin_strSSADT, "yyyy/mm/dd")
		Else
			If IsDate(VB6.Format(pin_strSSADT, "@@@@/@@/@@")) = True Then
				strDate = VB6.Format(pin_strSSADT, "@@@@/@@/@@")
			Else
				Exit Function
			End If
		End If
		
		yy = Year(CDate(strDate))
		mm = Month(CDate(strDate))
		dd = VB.Day(CDate(strDate))
		
		'����T�C�N���擾
		intTOKKESCC = CShort(CF_Get_CCurString(Pin_strTOKKESCC))
		
		If Pin_strTOKSMEKB = gc_strSMEKB_DAY Then
			'����T�C�N���̉��Z
			strDate = CStr(DateSerial(yy, mm + intTOKKESCC, CInt("01")))
			
			yy = Year(CDate(strDate))
			mm = Month(CDate(strDate))
			
			'������t�̍l��
			intTOKKESDD = CShort(CF_Get_CCurString(Pin_strTOKKESDD))
			If intTOKKESDD > 31 Then intTOKKESDD = 99
			If intTOKKESDD = 99 Then
				Pot_strKESDT = CStr(DateSerial(yy, mm + 1, 0))
			Else
				Pot_strKESDT = CStr(DateSerial(yy, mm, intTOKKESDD))
				If Month(CDate(Pot_strKESDT)) <> mm Then
					Pot_strKESDT = CStr(DateSerial(yy, mm + 1, 0))
				End If
			End If
			
			strDate = VB6.Format(Pot_strKESDT, "yyyymmdd")
		Else
			'�v�Z�Ώے��ߓ��̏T�̓��j���擾
			Call DSPCLDDT_SEARCH_WK(VB6.Format(yy, "0000") & VB6.Format(mm, "00") & VB6.Format(dd, "00"), gc_strCLDWKKB_SUN, "1", strWKDate)
			
			yy = CShort(MidWid(strWKDate, 1, 4))
			mm = CShort(MidWid(strWKDate, 5, 2))
			dd = CShort(MidWid(strWKDate, 7, 2))
			
			'����T�C�N���̉��Z
			strDate = CStr(DateSerial(yy, mm, dd + intTOKKESCC * 7))
			
			'�v�Z���ʓ��t�̏T�̉���j���ɂ�������t�擾
			Call DSPCLDDT_SEARCH_WK(CF_Ora_Date(strDate), Pin_strTOKKDWKB, "1", strDate)
		End If
		
		'�c�Ɠ��A��s�ғ����`�F�b�N
		Pot_strKESDT = ""
		If DSPCLDDT_SEARCH(strDate, Mst_Inf_Dt) = 0 Then
			If Mst_Inf_Dt.DATKB = gc_strDATKB_USE And Mst_Inf_Dt.SLDKB = KDKB_WORK And Mst_Inf_Dt.BNKKDKB = KDKB_WORK Then
				Pot_strKESDT = strDate
			Else
				If Pin_strSSAKBN = "1" Then
					'�O�|��
					Call DSPCLDDT_SEARCH_KDKB(strDate, "12", "2", Pot_strKESDT)
				Else
					'��|��
					Call DSPCLDDT_SEARCH_KDKB(strDate, "12", "1", Pot_strKESDT)
				End If
			End If
		End If
		
		AE_GetKESDT = 0
		
	End Function
	' === 20070307 === INSERT E -
	
	' === 20070327 === INSERT S - ACE)Nagasawa ��������ԕi�Ή�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CHK_URIInf_HNPN
	'   �T�v�F  ����ԕi�`�F�b�N����
	'   �����F  pin_strDATNO    : �`�[�Ǘ��ԍ�
	'           pin_usrUDNTHA   : �X�V�Ώ۔��㌩�o���g�������
	'           pin_usrUDNTRA   : �X�V�Ώ۔���g�������
	'   �ߒl�F  00 : �ԕi�Ȃ��A����X�V�Ȃ�
	'           01 : �ԕi�Ȃ��A����X�V����
	'           10 : �ԕi���������A����X�V�Ȃ�
	'           11 : �ԕi���������A����X�V����
	'           99 : �ُ�
	'   ���l�F�@����ɑ΂��ĕԕi�f�[�^���������Ă��邩�ǂ������������A�`�F�b�N����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_CHK_URIInf_HNPN(ByVal pin_strDatNo As String, ByRef pin_usrUDNTHA As Cmn_UDNTHA_Upd, ByRef pin_usrUDNTRA() As Cmn_UDNTRA_Upd) As String
		
		Dim curHNPNSU As Decimal
		Dim strSQL As String
		Dim strFDNNO As String
		Dim strODNNO As String
		Dim strJDNLINNO As String
		Dim strSBNNO As String
		Dim strRecNo As String
		Dim curURISU As String
		'UPGRADE_WARNING: �\���� usrOdy_UDNTRA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_UDNTRA As U_Ody
		Dim bolOpen As Boolean
		Dim intCnt As Short
		Dim bolUpd As Boolean
		Dim bolHNPN As Boolean
		Dim bolFind As Boolean
		Dim bolRet As Boolean
		
		On Error GoTo AE_CHK_URIInf_HNPN_Err
		
		AE_CHK_URIInf_HNPN = "99"
		
		bolOpen = False
		bolUpd = False
		bolHNPN = False
		
		'�X�V�Ώہi�Ǝv����)����`�[�̖��ׂ�S�Ď擾
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        UDNTHA.FDNNO "
		strSQL = strSQL & "      , UDNTRA.ODNNO "
		strSQL = strSQL & "      , UDNTRA.JDNLINNO "
		strSQL = strSQL & "      , UDNTRA.SBNNO "
		strSQL = strSQL & "      , UDNTRA.RECNO "
		strSQL = strSQL & "      , UDNTRA.URISU "
		strSQL = strSQL & "   FROM "
		strSQL = strSQL & "        UDNTHA "
		strSQL = strSQL & "      , UDNTRA "
		strSQL = strSQL & "  WHERE "
		strSQL = strSQL & "        UDNTHA.DATNO  = '" & CF_Ora_String(pin_strDatNo, 10) & "' "
		strSQL = strSQL & "    AND UDNTHA.DATNO  = UDNTRA.DATNO "
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTRA, strSQL)
		If bolRet = False Then
			GoTo AE_CHK_URIInf_HNPN_Err
		End If
		
		bolOpen = True
		
		Do Until CF_Ora_EOF(usrOdy_UDNTRA)
			
			'�擾�f�[�^�ޔ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strFDNNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "FDNNO", "") '�[�i���ԍ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strODNNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "ODNNO", "") '�o�ד`�[�ԍ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strJDNLINNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "JDNLINNO", "") '�󒍍s�ԍ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSBNNO = CF_Ora_GetDyn(usrOdy_UDNTRA, "SBNNO", "") '�o�ד`�[�ԍ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strRecNo = CF_Ora_GetDyn(usrOdy_UDNTRA, "RECNO", "") '���R�[�h�Ǘ��ԍ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curURISU = CF_Ora_GetDyn(usrOdy_UDNTRA, "URISU", 0) '���㐔
			
			'�ԕi�f�[�^����
			Call AE_GET_URIInf_HNPN(strFDNNO, strODNNO, strRecNo, curHNPNSU)
			
			If curHNPNSU > 0 Then
				'�ԕi�t���OON
				bolHNPN = True
			End If
			
			bolFind = False
			
			'�X�V�Ώۃf�[�^���ǂ����𒲂ׂ�
			For intCnt = 1 To UBound(pin_usrUDNTRA)
				
				'�󒍎���敪�ɂ�茟�������ύX
				Select Case True
					'�V�X�e���󒍂ŏo�׊�̂��́A�܂��̓Z�b�g�A�b�v��
					Case (pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SYS And pin_usrUDNTHA.URIKJN = gc_strURIKJN_SYK) Or pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SET
						If Trim(pin_usrUDNTRA(intCnt).LINNO) = Trim(strJDNLINNO) Then
							bolFind = True
						End If
						
						'�V�X�e���󒍂ŏo�׊�ȊO�̂���
					Case pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SYS
						If Trim(pin_usrUDNTRA(intCnt).RECNO) = Trim(strRecNo) Then
							bolFind = True
						End If
						
						'��L�ȊO
					Case Else
						If Trim(pin_usrUDNTRA(intCnt).SBNNO) = Trim(strSBNNO) Then
							bolFind = True
						End If
				End Select
				
				If bolFind = True Then
					Exit For
				End If
			Next 
			
			If bolFind = True Then
				'���㐔�|�ԕi�����[���͍X�V�Ώۃf�[�^
				If CDbl(curURISU) - curHNPNSU > 0 Then
					bolUpd = True
				End If
			End If
			
			'���f�[�^��
			Call CF_Ora_MoveNext(usrOdy_UDNTRA)
		Loop 
		
		'�`�F�b�N
		Select Case True
			'�ԕi�Ȃ��A����X�V�Ȃ�
			Case bolUpd = False And bolHNPN = False
				AE_CHK_URIInf_HNPN = "00"
				
				'�ԕi�Ȃ��A����X�V����
			Case bolUpd = True And bolHNPN = False
				AE_CHK_URIInf_HNPN = "01"
				
				'�ԕi���������A����X�V�Ȃ�
			Case bolUpd = False And bolHNPN = True
				AE_CHK_URIInf_HNPN = "10"
				
				'�ԕi���������A����X�V����
			Case bolUpd = True And bolHNPN = True
				AE_CHK_URIInf_HNPN = "11"
				
			Case Else
		End Select
		
AE_CHK_URIInf_HNPN_End: 
		
		If bolOpen = True Then
			'�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_UDNTRA)
		End If
		
		Exit Function
		
AE_CHK_URIInf_HNPN_Err: 
		GoTo AE_CHK_URIInf_HNPN_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_GET_URIInf_HNPN
	'   �T�v�F  ����ԕi���擾����
	'   �����F  pin_strFDNNO    : �[�i���ԍ�
	'           pin_strODNNO    : �o�ד`�[�ԍ�
	'           pin_strRECNO    : ���R�[�h�Ǘ��ԍ�
	'           pot_curHNPNSU   : �ԕi����
	'           pot_strHNPNKN   : �ԕi���z
	'           pot_strHNPNZKN  : �ԕi����ŋ��z
	'           pot_strHNPNFKN  : �ԕi�O�݋��z
	'   �ߒl�F  True : ����I��  False : �ُ�
	'   ���l�F�@����ɑ΂��Ĕ������Ă���ԕi�����擾����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function AE_GET_URIInf_HNPN(ByVal pin_strFDNNO As String, ByVal pin_strODNNO As String, ByVal pin_strRECNO As String, ByRef pot_curHNPNSU As Decimal, Optional ByRef pot_strHNPNKN As Decimal = 0, Optional ByRef pot_strHNPNZKN As Decimal = 0, Optional ByRef pot_strHNPNFKN As Decimal = 0) As Boolean
		
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy_UDNTRA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_UDNTRA As U_Ody
		Dim bolRet As Boolean
		Dim curHNPNSU As Decimal
		Dim bolOpen As Boolean
		
		On Error GoTo AE_GET_URIInf_HNPN_Err
		
		AE_GET_URIInf_HNPN = False
		
		bolOpen = False
		
		pot_curHNPNSU = 0
		pot_strHNPNKN = 0
		pot_strHNPNZKN = 0
		pot_strHNPNFKN = 0
		
		'�ԕi�f�[�^����
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "        SUM(UDNTRA.URISU) AS HNPNSU"
		strSQL = strSQL & "      , SUM(UDNTRA.URIKN) AS HNPNKN"
		strSQL = strSQL & "      , SUM(UDNTRA.UZEKN) AS HNPNZKN"
		strSQL = strSQL & "      , SUM(UDNTRA.FURIKN) AS HNPNFKN"
		strSQL = strSQL & "   FROM "
		' === 20070331 === UPDATE S - ACE)Nagasawa ��������ԕi�Ή�
		'    strSQL = strSQL & "        UDNTRA "
		'    strSQL = strSQL & "      , UDNTRA "
		strSQL = strSQL & "        UDNTRA "
		' === 20070331 === UPDATE E -
		strSQL = strSQL & "  WHERE "
		' === 20070331 === UPDATE S - ACE)Nagasawa ��������ԕi�Ή�
		'    strSQL = strSQL & "        UDNTHA.FDNNO     = '" & CF_Ora_String(pin_strFDNNO, 8) & "' "
		'    strSQL = strSQL & "    AND UDNTHA.DATNO     = UDNTRA.DATNO "
		'    strSQL = strSQL & "    AND UDNTRA.ODNNO     = '" & CF_Ora_String(pin_strODNNO, 8) & "' "
		strSQL = strSQL & "        UDNTRA.USDNO     = '" & CF_Ora_String(pin_strFDNNO, 8) & "' "
		' === 20070331 === UPDATE E -
		strSQL = strSQL & "    AND UDNTRA.RECNO     = '" & CF_Ora_String(pin_strRECNO, 10) & "' "
		strSQL = strSQL & "    AND UDNTRA.DKBID     IN ('" & CF_Ora_String(gc_strDKBID_HP, 2) & "' "
		strSQL = strSQL & "                          ,  '" & CF_Ora_String(gc_strDKBID_JHP, 2) & "') "
		strSQL = strSQL & "    AND UDNTRA.AKAKROKB  = '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "' "
		strSQL = strSQL & "    AND UDNTRA.DATKB     = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		strSQL = strSQL & "    AND UDNTRA.DATNO     NOT IN "
		' === 20070331 === UPDATE S - ACE)Nagasawa ��������ԕi�Ή�
		'    strSQL = strSQL & "                              (SELECT UDNTHA.MOTDATNO "
		'    strSQL = strSQL & "                               FROM UDNTHA,UDNTRA "
		'    strSQL = strSQL & "                              WHERE UDNTHA.FDNNO     = '" & CF_Ora_String(pin_strFDNNO, 8) & "' "
		'    strSQL = strSQL & "                                AND UDNTHA.DATNO     = UDNTRA.DATNO "
		'    strSQL = strSQL & "                                AND UDNTRA.ODNNO     = '" & CF_Ora_String(pin_strODNNO, 8) & "' "
		strSQL = strSQL & "                              (SELECT UDNTRA.MOTDATNO "
		strSQL = strSQL & "                               FROM UDNTRA "
		strSQL = strSQL & "                              WHERE UDNTRA.USDNO     = '" & CF_Ora_String(pin_strFDNNO, 8) & "' "
		' === 20070331 === UPDATE E -
		strSQL = strSQL & "                                AND UDNTRA.RECNO     = '" & CF_Ora_String(pin_strRECNO, 10) & "' "
		strSQL = strSQL & "                                AND UDNTRA.DKBID     IN ('" & CF_Ora_String(gc_strDKBID_HP, 2) & "' "
		strSQL = strSQL & "                                               ,  '" & CF_Ora_String(gc_strDKBID_JHP, 2) & "') "
		' === 20070331 === UPDATE S - ACE)Nagasawa ��������ԕi�Ή�
		'    strSQL = strSQL & "                        GROUP BY UDNTHA.MOTDATNO)"
		strSQL = strSQL & "                        GROUP BY UDNTRA.MOTDATNO)"
		' === 20070331 === UPDATE E -
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTRA, strSQL)
		If bolRet = False Then
			GoTo AE_GET_URIInf_HNPN_Err
		End If
		
		bolOpen = True
		
		'�ԕi���擾
		If CF_Ora_EOF(usrOdy_UDNTRA) = False Then
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_curHNPNSU = CF_Ora_GetDyn(usrOdy_UDNTRA, "HNPNSU", 0) * (-1)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_strHNPNKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "HNPNKN", 0) * (-1)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_strHNPNZKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "HNPNZKN", 0) * (-1)
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			pot_strHNPNFKN = CF_Ora_GetDyn(usrOdy_UDNTRA, "HNPNFKN", 0) * (-1)
		End If
		
		AE_GET_URIInf_HNPN = True
		
AE_GET_URIInf_HNPN_End: 
		
		If bolOpen = True Then
			'�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_UDNTRA)
		End If
		
		Exit Function
		
AE_GET_URIInf_HNPN_Err: 
		
		GoTo AE_GET_URIInf_HNPN_End
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CmnSYSTBCSaiban
	'   �T�v�F  SYSTBC���`�[�ԍ��̔ԏ���
	'   �����F�@Pm_strJDNTRKB      :�`�[����敪���
	'           Pm_strADDDENCD     :�`�[�t���R�[�h("":�󕶎��̏ꍇ�͌��������Ɋ܂߂Ȃ�)
	'           Pm_strDENNO()      :�̔Ԃ��ꂽ�`�[�ԍ�
	'           Pm_strGetADDDENCD  :�`�[�t���R�[�h
	'   �ߒl�F  0:����  1:�f�[�^����  2:Lock��  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CmnSYSTBCSaiban(ByVal Pm_strDKBSB As String, ByVal Pm_strADDDENCD As String, ByRef Pm_strDENNO() As String, Optional ByRef Pm_strGetADDDENCD As String = "") As Short
		
		Static strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Static usrOdy As U_Ody
		Static bolRet As Boolean
		Static bolTran As Boolean
		Static curDENNO As Decimal
		Static curSTTNO As Decimal
		Static curENDNO As Decimal
		Static strADDDENCD As String
		Static intCnt As Short
		Static strNewNO As String
		
		On Error GoTo ERR_AE_CmnSYSTBCSaiban
		
		AE_CmnSYSTBCSaiban = 9
		
		bolTran = False
		
		Pm_strGetADDDENCD = ""
		
		'�g�����U�N�V�����J�n
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'���[�U�[�`�[���e�[�u���擾
		strSQL = ""
		strSQL = strSQL & " Select *             "
		strSQL = strSQL & "   from SYSTBC        "
		strSQL = strSQL & "  Where DKBSB    = '" & CF_Ora_String(Pm_strDKBSB, 3) & "' "
		If Pm_strADDDENCD <> "" Then
			strSQL = strSQL & "    And ADDDENCD = '" & CF_Ora_String(Pm_strADDDENCD, 13) & "' "
		End If
		strSQL = strSQL & "    for Update "
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
		If bolRet = False Then
			GoTo ERR_AE_CmnSYSTBCSaiban
		End If
		
		'EOF����
		If CF_Ora_EOF(usrOdy) = True Then
			AE_CmnSYSTBCSaiban = 1
			GoTo ERR_AE_CmnSYSTBCSaiban
		End If
		
		'�`�[�t���R�[�h�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		Pm_strGetADDDENCD = CF_Ora_GetDyn(usrOdy, "ADDDENCD", "")
		
		'�J�n�`�[No�擾
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "STTNO", "")) = False Then
			curSTTNO = 1
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curSTTNO = CDec(CF_Ora_GetDyn(usrOdy, "STTNO", 0))
		End If
		
		'�I���`�[No�擾
		If IsNumeric(CF_Ora_GetDyn(usrOdy, "ENDNO", "")) = False Then
			curENDNO = 1
		Else
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			curENDNO = CDec(CF_Ora_GetDyn(usrOdy, "ENDNO", 0))
		End If
		
		'�`�[NO.�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		curDENNO = CDec(CF_Ora_GetDyn(usrOdy, "DENNO", "0")) + 1
		If curDENNO > curENDNO Then
			'�I���`�[NO�𒴂����ꍇ�͖߂�
			curDENNO = curSTTNO
		End If
		
		For intCnt = 1 To UBound(Pm_strDENNO)
			strNewNO = VB6.Format(curDENNO, New String("0", 8))
			Pm_strDENNO(intCnt) = strNewNO
			curDENNO = curDENNO + 1
			If curDENNO > curENDNO Then
				'�I���`�[No�𒴂����ꍇ�͖߂�
				curDENNO = curSTTNO
			End If
		Next intCnt
		
		'���[�U�[�`�[���e�[�u���X�V
		If UBound(Pm_strDENNO) > 0 Then
			
			strSQL = ""
			strSQL = strSQL & " UPDATE SYSTBC "
			strSQL = strSQL & "    SET DENNO      = '" & CF_Ora_String(strNewNO, 8) & "' "
			
			If Trim(GV_SysTime) <> "" Then
				strSQL = strSQL & "      , WRTTM      = '" & CF_Ora_String(GV_SysTime, 6) & "' "
			Else
				strSQL = strSQL & "      , WRTTM      = '" & CStr(VB6.Format(Now, "hhmmss")) & "' "
			End If
			
			If Trim(GV_SysDate) <> "" Then
				strSQL = strSQL & "      , WRTDT      = '" & CF_Ora_String(GV_SysDate, 8) & "' "
			Else
				strSQL = strSQL & "      , WRTDT      = '" & CStr(VB6.Format(Now, "yyyymmdd")) & "' "
			End If
			
			strSQL = strSQL & "  WHERE "
			strSQL = strSQL & "        DKBSB    = '" & CF_Ora_String(Pm_strDKBSB, 3) & "' "
			
			'�r�p�k���s
			bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
			If bolRet = False Then
				GoTo ERR_AE_CmnSYSTBCSaiban
			End If
		End If
		
		bolRet = CF_Ora_CloseDyn(usrOdy)
		If bolRet = False Then
			GoTo ERR_AE_CmnSYSTBCSaiban
		End If
		
		'�R�~�b�g
		Call CF_Ora_CommitTrans(gv_Oss_USR1)
		bolTran = False
		
		AE_CmnSYSTBCSaiban = 0
		
EXIT_AE_CmnSYSTBCSaiban: 
		Exit Function
		
ERR_AE_CmnSYSTBCSaiban: 
		
		If gv_Int_OraErr = 51 Then
			'���Ŏg�p��
			AE_CmnSYSTBCSaiban = 2
		End If
		
		If bolTran = True Then
			'���[���o�b�N
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		GoTo EXIT_AE_CmnSYSTBCSaiban
		
	End Function
	' === 20070327 === INSERT E -
	
	' === 20060729 === INSERT S - ACE)Nagasawa �o�׎w���g�����̏o�ח\��Ǘ��ԍ�������������
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_FDNTRA_Update
	'   �T�v�F  �o�׎w���g�����X�V����
	'   �����F�@pm_strJDNNO     : �󒍔ԍ�
	'           pm_strLINNO     : �s�ԍ�
	'           pm_strHINCD     : ���i�R�[�h
	'           pm_strNewDATNO  : �`�[�Ǘ��ԍ�(�X�V��)
	'           pm_strErrCd     : �X�V�ُ�G���[�R�[�h
	'  �@     �@pm_All          : ��ʏ��
	'   �ߒl�F�@0:����  9:�ُ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_FDNTRA_Update(ByVal pm_strJDNNO As String, ByVal pm_strLINNO As String, ByVal pm_strHINCD As String, ByVal pm_strNewDATNO As String, ByVal pm_strErrCd As String, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim strWhere As String
		Dim bolRet As Boolean
		
		On Error GoTo CF_FDNTRA_Update_Err
		
		CF_FDNTRA_Update = 9
		
		'SQL�ҏW(WHERE����(����))
		strWhere = ""
		strWhere = strWhere & "  WHERE "
		strWhere = strWhere & "        JDNNO      = '" & CF_Ora_String(pm_strJDNNO, 10) & "' "
		strWhere = strWhere & "    AND JDNLINNO   = '" & CF_Ora_String(pm_strLINNO, 3) & "' "
		strWhere = strWhere & "    AND HINCD      = '" & CF_Ora_String(pm_strHINCD, 10) & "' "
		strWhere = strWhere & "    AND DATKB      = '" & CF_Ora_String(gc_strDATKB_USE, 1) & "' "
		
		'SQL�ҏW
		strSQL = ""
		strSQL = strSQL & " UPDATE "
		strSQL = strSQL & "        FDNTRA "
		strSQL = strSQL & "    SET SYKDATNO   = '" & CF_Ora_String(pm_strNewDATNO, 10) & "' "
		strSQL = strSQL & "      , UOPEID   = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UCLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UWRTTM   = '" & GV_SysTime & "' " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      , UWRTDT   = '" & GV_SysDate & "' " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      , PGID     = '" & CF_Ora_String(SSS_PrgId, 7) & "' " '�o�f�h�c
		strSQL = strSQL & strWhere
		strSQL = strSQL & "    AND DATNO      = (SELECT MAX(DATNO) FROM FDNTRA "
		strSQL = strSQL & strWhere & ") "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo CF_FDNTRA_Update_Err
		End If
		
		CF_FDNTRA_Update = 0
		
CF_FDNTRA_Update_End: 
		Exit Function
		
CF_FDNTRA_Update_Err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, pm_strErrCd, pm_All, "CF_FDNTRA_Update")
		
	End Function
	' === 20060729 === INSERT E
	
	' === 20071213 === INSERT S - ACE)Nagasawa �������o�͋敪�̒ǉ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CHK_MRPKB_PRT
	'   �T�v�F  �������o�͑Ώۖ��׃`�F�b�N
	'   �����F  pin_strJDNNO      : �󒍔ԍ�
	'   �@�@�@  pin_strTOKCD      : ���Ӑ�R�[�h
	'   �ߒl�F  True : �`�F�b�NOK�@False : �`�F�b�NNG�i���������o�͂���Ȃ��̂�"�v"�ƂȂ��Ă���)
	'   ���l�F  �������o�́�"�v"�ƂȂ��Ă��閾�ׂɂ��Ĕ�����̍X�V���s���邩��
	'           �`�F�b�N����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CHK_MRPKB_PRT(ByRef pin_usrUDNTHA As Cmn_UDNTHA_Upd, ByRef pot_strLinno As String) As Boolean
		
		Dim bolRet As Boolean
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy_UDNTRA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_UDNTRA As U_Ody
		Dim bolTran As Boolean
		Dim strDATNO As String
		Dim intCnt As Short
		Dim curKensu As Decimal
		
		On Error GoTo AE_CHK_MRPKB_PRT_Err
		
		AE_CHK_MRPKB_PRT = False
		
		pot_strLinno = ""
		
		bolTran = False
		
		strDATNO = ""
		For intCnt = 1 To UBound(pin_usrUDNTHA.DATNO)
			If Trim(strDATNO) <> "" Then
				strDATNO = strDATNO & ", "
			End If
			strDATNO = strDATNO & "'" & CF_Ora_String(pin_usrUDNTHA.DATNO(intCnt), 10) & "'"
		Next 
		
		For intCnt = 1 To UBound(pin_usrUDNTHA.usrBodyInf)
			'�������o�͋敪="�v"�̖��ׂ̂݃`�F�b�N
			If Trim(pin_usrUDNTHA.usrBodyInf(intCnt).MRPKB) = gc_strMRPKB_PRT Then
				'����g�����擾
				strSQL = ""
				strSQL = strSQL & " SELECT COUNT(*)   AS CNT "
				strSQL = strSQL & "   FROM UDNTRA "
				strSQL = strSQL & "  WHERE UDNTRA.DATNO in (" & strDATNO & ") "
				
				'�󒍎���敪�ɂ�茟�������ύX
				Select Case True
					'�V�X�e���󒍂ŏo�׊�̂��́A�܂��̓Z�b�g�A�b�v��
					Case (pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SYS And pin_usrUDNTHA.URIKJN = gc_strURIKJN_SYK) Or pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SET
						strSQL = strSQL & "    AND JDNLINNO = '" & CF_Ora_String(pin_usrUDNTHA.usrBodyInf(intCnt).LINNO, 10) & "' "
						
						'�V�X�e���󒍂ŏo�׊�ȊO�̂���
					Case pin_usrUDNTHA.JDNTRKB = gc_strJDNTRKB_SYS
						strSQL = strSQL & "    AND RECNO    = '" & CF_Ora_String(pin_usrUDNTHA.usrBodyInf(intCnt).RECNO, 10) & "' "
						
						'��L�ȊO
					Case Else
						strSQL = strSQL & "    AND SBNNO    = '" & CF_Ora_String(pin_usrUDNTHA.usrBodyInf(intCnt).SBNNO, 20) & "' "
				End Select
				
				'SQL���s
				bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTRA, strSQL)
				If bolRet = False Then
					GoTo AE_CHK_MRPKB_PRT_Err
				End If
				bolTran = True
				
				'�������ʎ擾
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				curKensu = CF_Ora_GetDyn(usrOdy_UDNTRA, "CNT", 0)
				
				'�N���[�Y
				Call CF_Ora_CloseDyn(usrOdy_UDNTRA)
				bolTran = False
				
				If curKensu <= 0 Then
					
					If Trim(pot_strLinno) = "" Then
						pot_strLinno = pot_strLinno & "�sNo "
					Else
						pot_strLinno = pot_strLinno & ", "
					End If
					
					'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ctr_AnsiRightB() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
					pot_strLinno = pot_strLinno & CF_Ctr_AnsiRightB(pin_usrUDNTHA.usrBodyInf(intCnt).LINNO, 2)
				End If
			End If
		Next 
		
		If Trim(pot_strLinno) = "" Then
			AE_CHK_MRPKB_PRT = True
		End If
		
AE_CHK_MRPKB_PRT_End: 
		If bolTran = True Then
			'���R�[�h�Z�b�g�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_UDNTRA)
		End If
		
		Exit Function
		
AE_CHK_MRPKB_PRT_Err: 
		GoTo AE_CHK_MRPKB_PRT_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Get_MRPKB
	'   �T�v�F  �������o�͋敪�擾
	'   �����F  pin_strMRPKB_BFR  : �������o�͋敪(�X�V�O�f�[�^)
	'   �@�@�@  pin_bolAKAKRO     : �ԍ������敪(True�F�ԍ������L��)
	'   �@�@�@  pin_strDATNO      : �`�[�Ǘ��ԍ�(�X�V�O�f�[�^)
	'   �@�@�@  pin_strURILINNO   : ����s�ԍ�(�X�V�O�f�[�^)
	'   �@�@�@  pin_strSSADT_BFR  : �����t(�X�V�O�f�[�^)
	'   �@�@�@  pin_strSSADT_AFT  : �����t(�X�V��f�[�^)
	'   �@�@�@  pio_strMRPKB�@�@  : �������o�͋敪(IN:��ʂ̒l OUT�F�X�V�l)
	'   �ߒl�F  True : ����I���@False : �ُ�I��
	'   ���l�F  ��ʂœ��͂��ꂽ�������o�͋敪��������蔻�肵�A�X�V�l�Ƃ��Ė߂��B
	'�@�@�@�@�@ �K�v�ȏꍇ�͉ߋ��f�[�^�̐������o�͋敪���X�V����B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Get_MRPKB(ByVal pin_strMRPKB_BFR As String, ByVal pin_bolAKAKRO As Boolean, ByVal pin_strDatNo As String, ByVal pin_strURILINNO As String, ByVal pin_strSSADT_BFR As String, ByVal pin_strSSADT_AFT As String, ByRef pio_strMRPKB As String) As Boolean
		
		Dim bolRet As Boolean
		Dim strDatNo_Upd As String
		
		On Error GoTo AE_Get_MRPKB_Err
		
		AE_Get_MRPKB = False
		
		If Trim(pio_strMRPKB) = gc_strMRPKB_PRT Then
			'���.�������o�͋敪="�v"�̏ꍇ
			If pin_bolAKAKRO = True Then
				
				'�ԍ��`�[����������ꍇ�A���͒l�̂܂܂ŏI��(�v)
				GoTo AE_Get_MRPKB_NormalEnd
				
			Else
				
				'�ԍ��`�[���������Ȃ��ꍇ
				If Trim(pin_strMRPKB_BFR) = gc_strMRPKB_NOPRT Then
					'���f�[�^�̐��������s�敪��"�s�v"�̏ꍇ
					
					'�f�[�^�������̂ڂ�ŏ��ɔ������ꂽ�ԓ`�[�̐������o�͋敪��"�v"�Ƃ���
					strDatNo_Upd = AE_Get_DATNO_MRPKBUpd(pin_strDatNo, pin_strSSADT_BFR)
					If Trim(strDatNo_Upd) = "" Then
						GoTo AE_Get_MRPKB_Err
					End If
					
					bolRet = AE_Upd_MRPKB_BfrUDNTRAData(strDatNo_Upd, pin_strURILINNO, gc_strMRPKB_PRT)
					If bolRet = False Then
						GoTo AE_Get_MRPKB_Err
					End If
					
					'���͒l�̂܂܂ŏI��(�v)
					GoTo AE_Get_MRPKB_NormalEnd
					
				Else
					'���f�[�^�̐��������s�敪<>"�s�v"�̏ꍇ�A���͒l�̂܂܂ŏI��(�v)
					GoTo AE_Get_MRPKB_NormalEnd
					
				End If
				
			End If
		Else
			'���.�������o�͋敪="�s�v"�̏ꍇ
			If pin_bolAKAKRO = True Then
				'�ԍ��`�[����������ꍇ
				
				If AE_CHK_URIInf_HNPN_Exist(pin_strDatNo) = True Then
					'�ԕi���������Ă���`�[�ꍇ�A���͒l�̂܂܂ŏI���i�s�v)
					GoTo AE_Get_MRPKB_NormalEnd
				End If
				
				If Trim(pin_strSSADT_BFR) <> Trim(pin_strSSADT_AFT) Then
					'�����������ύX�ɂȂ�ꍇ�A���͒l�̂܂܂ŏI���i�s�v)
					GoTo AE_Get_MRPKB_NormalEnd
				End If
				
				'�����������ύX�ɂȂ�Ȃ��ԍ��̏ꍇ�́A���f�[�^�̒l�������p��
				pio_strMRPKB = pin_strMRPKB_BFR
				GoTo AE_Get_MRPKB_NormalEnd
			Else
				'�ԍ��`�[���������Ȃ��ꍇ
				
				If Trim(pin_strMRPKB_BFR) = gc_strMRPKB_NOPRT Then
					'���f�[�^�̐��������s�敪��"�s�v"�̏ꍇ�A���͒l�̂܂܂ŏI��(�s�v)
					GoTo AE_Get_MRPKB_NormalEnd
				Else
					'���f�[�^�̐��������s�敪���p������(�v or ��)
					pio_strMRPKB = pin_strMRPKB_BFR
					GoTo AE_Get_MRPKB_NormalEnd
				End If
			End If
		End If
		
AE_Get_MRPKB_NormalEnd: 
		AE_Get_MRPKB = True
		
AE_Get_MRPKB_End: 
		Exit Function
		
AE_Get_MRPKB_Err: 
		GoTo AE_Get_MRPKB_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Get_DATNO_MRPKBUpd
	'   �T�v�F  ���ꐿ�������ōX�V�Ώۂ̐ԓ`�[����g�����̓`�[�Ǘ��ԍ����擾����
	'   �����F  pin_strDATNO      : �����Ώۓ`�[�Ǘ�No
	'   �@      pin_strDATNO      : ��������
	'   �ߒl�F  �`�[�Ǘ�No�i��������)
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Get_DATNO_MRPKBUpd(ByVal pin_strDatNo As String, ByVal pin_strSSADT As String) As String
		
		Dim bolRet As Boolean
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy_UDNTHA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_UDNTHA As U_Ody
		Dim bolTran As Boolean
		Dim strDATNO As String
		Dim strDatNo_Sel As String '�`�[�Ǘ�No(���`�[��������)
		Dim strMotoDatNo As String
		Dim strSSADT As String
		Dim bolLoopEnd As Boolean
		
		On Error GoTo AE_Get_DATNO_MRPKBUpd_Err
		
		AE_Get_DATNO_MRPKBUpd = ""
		
		strDatNo_Sel = pin_strDatNo
		bolLoopEnd = False
		bolTran = False
		
		Do Until bolLoopEnd = True
			'���㌩�o���g�����擾�i���`�[�Ǘ�No)
			strSQL = ""
			strSQL = strSQL & " SELECT UDNTHA.MOTDATNO "
			strSQL = strSQL & "      , UDNTHA.SSADT "
			strSQL = strSQL & "   FROM UDNTHA "
			strSQL = strSQL & "  WHERE UDNTHA.DATNO = '" & CF_Ora_String(strDatNo_Sel, 10) & "'"
			
			'SQL���s
			bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTHA, strSQL)
			If bolRet = False Then
				GoTo AE_Get_DATNO_MRPKBUpd_Err
			End If
			bolTran = True
			
			'EOF����
			If CF_Ora_EOF(usrOdy_UDNTHA) = True Then
				bolLoopEnd = True
				Exit Do
			End If
			
			'�������ʎ擾
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strMotoDatNo = CF_Ora_GetDyn(usrOdy_UDNTHA, "MOTDATNO", "")
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strSSADT = CF_Ora_GetDyn(usrOdy_UDNTHA, "SSADT", "")
			
			'�����������ς��ꍇ�A�����ŏ����I��
			If Trim(pin_strSSADT) <> Trim(strSSADT) Then
				bolLoopEnd = True
				Exit Do
			End If
			
			'���`�[�Ǘ�No���󔒂̏ꍇ�A�����ŏ����I��
			If Trim(strMotoDatNo) = "" Then
				bolLoopEnd = True
				Exit Do
			End If
			
			'�ԕi���������Ă���`�[�̏ꍇ�͏����I��
			If AE_CHK_URIInf_HNPN_Exist(strDatNo_Sel) = True Then
				bolLoopEnd = True
				Exit Do
			End If
			
			'�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_UDNTHA)
			bolTran = False
			
			'���㌩�o���g�����擾�i���`�[�Ǘ�No���ԓ`�[���擾)
			strSQL = ""
			strSQL = strSQL & " SELECT DATNO "
			strSQL = strSQL & "      , MOTDATNO "
			strSQL = strSQL & "   FROM UDNTHA "
			strSQL = strSQL & "  WHERE UDNTHA.MOTDATNO  = '" & CF_Ora_String(strMotoDatNo, 10) & "'"
			strSQL = strSQL & "    AND UDNTHA.AKAKROKB  = '" & CF_Ora_String(gc_strAKAKROKB_AKA, 1) & "'"
			
			'SQL���s
			bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTHA, strSQL)
			If bolRet = False Then
				GoTo AE_Get_DATNO_MRPKBUpd_Err
			End If
			bolTran = True
			
			'EOF����
			If CF_Ora_EOF(usrOdy_UDNTHA) = False Then
				'�������ʎ擾
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strDATNO = CF_Ora_GetDyn(usrOdy_UDNTHA, "DATNO", "")
				'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
				strDatNo_Sel = CF_Ora_GetDyn(usrOdy_UDNTHA, "MOTDATNO", "")
			Else
				strDATNO = ""
				strDatNo_Sel = strMotoDatNo
			End If
			
			'�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_UDNTHA)
			bolTran = False
		Loop 
		
		AE_Get_DATNO_MRPKBUpd = strDATNO
		
AE_Get_DATNO_MRPKBUpd_End: 
		If bolTran = True Then
			'���R�[�h�Z�b�g�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_UDNTHA)
		End If
		
		Exit Function
		
AE_Get_DATNO_MRPKBUpd_Err: 
		GoTo AE_Get_DATNO_MRPKBUpd_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_CHK_URIInf_HNPN_Exist
	'   �T�v�F  �����Ώ۔���`�[�ɕԕi���������Ă��邩���`�F�b�N����
	'   �����F  pin_strDATNO      : �����Ώۓ`�[�Ǘ�No
	'   �ߒl�F  True�F�ԕi����@False�F�ԕi�Ȃ�
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_CHK_URIInf_HNPN_Exist(ByVal pin_strDatNo As String) As Boolean
		
		Dim bolRet As Boolean
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy_UDNTHA �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy_UDNTHA As U_Ody
		Dim bolTran As Boolean
		Dim strFDNNO As String
		Dim strODNNO As String
		Dim strRecNo As String
		Dim curHNPNSU As Decimal
		
		On Error GoTo AE_CHK_URIInf_HNPN_Exist_Err
		
		AE_CHK_URIInf_HNPN_Exist = False
		
		bolTran = False
		
		'���㌩�o���g�����擾
		strSQL = ""
		strSQL = strSQL & " SELECT UDNTHA.FDNNO "
		strSQL = strSQL & "      , UDNTRA.ODNNO "
		strSQL = strSQL & "      , UDNTRA.RECNO "
		strSQL = strSQL & "   FROM UDNTRA "
		strSQL = strSQL & "      , UDNTHA "
		strSQL = strSQL & "  WHERE UDNTRA.DATNO = '" & CF_Ora_String(pin_strDatNo, 10) & "'"
		strSQL = strSQL & "    AND UDNTRA.DATNO = UDNTHA.DATNO "
		
		'SQL���s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy_UDNTHA, strSQL)
		If bolRet = False Then
			GoTo AE_CHK_URIInf_HNPN_Exist_Err
		End If
		bolTran = True
		
		Do Until CF_Ora_EOF(usrOdy_UDNTHA) = True
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strFDNNO = CF_Ora_GetDyn(usrOdy_UDNTHA, "FDNNO", "") '�[�i���ԍ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strODNNO = CF_Ora_GetDyn(usrOdy_UDNTHA, "ODNNO", "") '�o�ד`�[�ԍ�
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strRecNo = CF_Ora_GetDyn(usrOdy_UDNTHA, "RECNO", "") '���R�[�h�Ǘ��ԍ�
			
			'�ԕi�f�[�^����
			Call AE_GET_URIInf_HNPN(strFDNNO, strODNNO, strRecNo, curHNPNSU)
			
			'�ԕi���������Ă��邩���`�F�b�N(�ԕi�������͏����I��)
			If curHNPNSU <> 0 Then
				AE_CHK_URIInf_HNPN_Exist = True
				GoTo AE_CHK_URIInf_HNPN_Exist_End
			End If
			
			'���f�[�^�Ǎ�
			Call CF_Ora_MoveNext(usrOdy_UDNTHA)
		Loop 
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(usrOdy_UDNTHA)
		bolTran = False
		
AE_CHK_URIInf_HNPN_Exist_End: 
		If bolTran = True Then
			'���R�[�h�Z�b�g�N���[�Y
			Call CF_Ora_CloseDyn(usrOdy_UDNTHA)
		End If
		
		Exit Function
		
AE_CHK_URIInf_HNPN_Exist_Err: 
		GoTo AE_CHK_URIInf_HNPN_Exist_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Upd_MRPKB_BfrUDNTRAData
	'   �T�v�F  �O�f�[�^����g�����������o�͋敪�X�V����
	'   �����F�@pin_strDATNO    : �`�[�Ǘ��ԍ�
	'           pin_strMRPKB    : ���������s�敪
	'   �ߒl�F�@True:����  False:�ُ�
	'   ���l�F�@����.�`�[�Ǘ��ԍ��A����s�ԍ��������ɔ���g�����̐��������s�敪���X�V����B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Upd_MRPKB_BfrUDNTRAData(ByVal pin_strDatNo As String, ByVal pin_strUDNLINNO As String, ByVal pin_strMRPKB As String) As Boolean
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo AE_Upd_MRPKB_BfrUDNTRAData_Err
		
		AE_Upd_MRPKB_BfrUDNTRAData = False
		
		'SQL�ҏW
		strSQL = ""
		strSQL = strSQL & " UPDATE UDNTRA SET "
		strSQL = strSQL & "        MRPKB    = '" & CF_Ora_String(pin_strMRPKB, 1) & "' " '���������s�敪
		'''' DEL 2012/06/14  FWEST) T.Yamamoto    Start    �A���[��FC12061401
		'    strSQL = strSQL & "      , OPEID    = '" & CF_Ora_String(SSS_OPEID, 8) & "' "       '���[�U�[�h�c�i�����j
		'    strSQL = strSQL & "      , CLTID    = '" & CF_Ora_String(SSS_CLTID, 5) & "' "       '�N���C�A���g�h�c�i�����j
		'    strSQL = strSQL & "      , WRTTM    = '" & GV_SysTime & "' "                        '�^�C���X�^���v�i�������ԁj
		'    strSQL = strSQL & "      , WRTDT    = '" & GV_SysDate & "' "                        '�^�C���X�^���v�i�������t�j
		'''' DEL 2012/06/14  FWEST) T.Yamamoto    End
		strSQL = strSQL & "      , UOPEID   = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '���[�U�[�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UCLTID   = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '�N���C�A���g�h�c�i�o�b�`�j
		strSQL = strSQL & "      , UWRTTM   = '" & GV_SysTime & "' " '�^�C���X�^���v�i�������ԁj
		strSQL = strSQL & "      , UWRTDT   = '" & GV_SysDate & "' " '�^�C���X�^���v�i�������t�j
		strSQL = strSQL & "      , PGID     = '" & CF_Ora_String(SSS_PrgId, 7) & "' " '�o�f�h�c
		strSQL = strSQL & "  WHERE DATNO = '" & CF_Ora_String(pin_strDatNo, 10) & "' "
		strSQL = strSQL & "    AND LINNO = '" & CF_Ora_String(pin_strUDNLINNO, 3) & "' "
		
		'SQL���s
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_Upd_MRPKB_BfrUDNTRAData_Err
		End If
		
		AE_Upd_MRPKB_BfrUDNTRAData = True
		
AE_Upd_MRPKB_BfrUDNTRAData_End: 
		Exit Function
		
AE_Upd_MRPKB_BfrUDNTRAData_Err: 
		GoTo AE_Upd_MRPKB_BfrUDNTRAData_End
		
	End Function
	' === 20071213 === INSERT E -
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function AE_Execute_PLSQL_TNADL71
	'   �T�v�F  ����݌ɏƉ�pPL/SQL���s����
	'   �����F�@�Ȃ�
	'   �ߒl�F�@�߂�l
	'   ���l�F  PL/SQL�����s����
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_TNADL71(ByRef pin_strHINCD As String, ByRef pin_strSOUCD As String, ByRef pin_curRELZAISU As Decimal) As Short
		
		Dim strSQL As String 'SQL��
		Dim strPara1 As String '���Ұ�1
		Dim strPara2 As String '���Ұ�2
		Dim strPara3 As String '���Ұ�3
		Dim strPara4 As String '���Ұ�4
		Dim lngPara5 As Integer '���Ұ�5
		Dim strPara6 As String '���Ұ�6
		Dim lngPara7 As Integer '���Ұ�7
		Dim lngPara8 As Integer '���Ұ�8
		Dim strPara9 As String '���Ұ�9
		Dim lngPara10 As Integer '���Ұ�10
		Dim lngPara11 As Integer '���Ұ�11
		'UPGRADE_ISSUE: OraParameter �I�u�W�F�N�g �̓A�b�v�O���[�h����܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' ���N���b�N���Ă��������B
		Dim param(12) As OraParameter 'PL/SQL�̃o�C���h�ϐ�
		
		'��n���ϐ������ݒ�
		strPara1 = Inp_Inf.InpTanCd '���͒S���҃R�[�h
		strPara2 = Inp_Inf.InpCLIID '�N���C�A���gID
		strPara3 = CF_Ora_String(pin_strHINCD, 10) '���i�R�[�h
		strPara4 = CF_Ora_String(pin_strSOUCD, 3) '�q�ɃR�[�h
		lngPara5 = pin_curRELZAISU '���ݍ݌ɐ�
		strPara6 = CF_Ora_String(SSS_PrgId, 10)
		lngPara7 = 0
		lngPara8 = 0
		strPara9 = ""
		lngPara10 = 0
		lngPara10 = 0
		
		'�p�����[�^�̏����ݒ���s���i�o�C���h�ϐ��j
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P4", strPara4, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P5", lngPara5, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P6", strPara6, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P7", lngPara7, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P8", lngPara8, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P9", strPara9, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P10", lngPara10, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("P11", lngPara11, ORAPARM_OUTPUT)
		
		'�f�[�^�^���I�u�W�F�N�g�ɃZ�b�g
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3) = gv_Odb_USR1.Parameters("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4) = gv_Odb_USR1.Parameters("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5) = gv_Odb_USR1.Parameters("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6) = gv_Odb_USR1.Parameters("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7) = gv_Odb_USR1.Parameters("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8) = gv_Odb_USR1.Parameters("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9) = gv_Odb_USR1.Parameters("P9")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(10) = gv_Odb_USR1.Parameters("P10")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(11) = gv_Odb_USR1.Parameters("P11")
		
		'�e�I�u�W�F�N�g�̃f�[�^�^��ݒ�
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(3).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(4).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(5).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(6).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(7).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(8).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(9).serverType = ORATYPE_VARCHAR2
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(10).serverType = ORATYPE_NUMBER
		'UPGRADE_WARNING: �I�u�W�F�N�g param().serverType �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		param(11).serverType = ORATYPE_NUMBER
		
		'PL/SQL�Ăяo��SQL
		strSQL = "BEGIN PRC_TNADL71_01(:P1,:P2,:P3,:P4,:P5,:P6,:P7,:P8,:P9,:P10,:P11); End;"
		
		'DB�A�N�Z�X
		Call CF_Ora_Execute(gv_Odb_USR1, strSQL)
		
		'** �߂�l�擾
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara7 = param(7).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara8 = param(8).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		strPara9 = param(9).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara10 = param(10).Value
		'UPGRADE_WARNING: �I�u�W�F�N�g param().Value �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		lngPara11 = param(11).Value
		
		'�߂�l�ݒ�
		AE_Execute_PLSQL_TNADL71 = lngPara7
		
		'** �p�����^����
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P3")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P4")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P5")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P6")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P7")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P8")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P9")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P10")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("P11")
		
	End Function
	' === 20061217 === INSERT E -
	
	'''' ADD 2009/03/04  FKS) S.Nakajima    Start
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function funcEigyoshoHaishi
	'   �T�v�F  �P�v�Ή��`�F�b�N
	'   �����F�@strUNYDT_ : �Ώۓ��t   strBMNCD_ : ����R�[�h  strSTTTKDT_ : �K�p�J�n��
	'   �ߒl�F�@�߂�l TRUE : ����OK  FALSE : ����NG
	'   ���l�F  �P�v�Ή��i�c�Ə��p�~�j�̃`�F�b�N���s���B
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function funcEigyoshoHaishi(ByVal strUNYDT_ As String, ByVal strBMNCD_ As String, ByVal strSTTTKDT_ As String) As Boolean
		
		Dim bolRet As Boolean
		Dim strSQL As String
		'UPGRADE_WARNING: �\���� usrOdy �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim usrOdy As U_Ody
		Dim strENDTKDT As String
		
		On Error GoTo Err_Run
		
		funcEigyoshoHaishi = False
		
		' �K�p�����̃}�X�^�����p�r�p�k���쐬
		strSQL = ""
		strSQL = strSQL & " SELECT * " & vbCrLf
		strSQL = strSQL & "   FROM MEIMTC " & vbCrLf
		strSQL = strSQL & "  WHERE KEYCD   = '102' " & vbCrLf
		strSQL = strSQL & "    AND MEICDA  = '" & strBMNCD_ & "'" & vbCrLf
		strSQL = strSQL & "    AND STTTKDT = '" & strSTTTKDT_ & "'" & vbCrLf
		
		' �r�p�k�����s
		bolRet = CF_Ora_CreateDyn(gv_Odb_USR1, usrOdy, strSQL)
		If bolRet = False Then
			GoTo Exit_Run
		End If
		
		' �f�[�^�����݂����ꍇ
		If Not CF_Ora_EOF(usrOdy) Then
			
			' ��~���̎擾
			'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			strENDTKDT = Trim(CStr(CF_Ora_GetDyn(usrOdy, "ENDTKDT", ""))) '��~��
			
			' �^�p������~���ȍ~�̏ꍇ�̓G���[
			If strENDTKDT < strUNYDT_ Then
				GoTo Exit_Run
			End If
			
		End If
		
		funcEigyoshoHaishi = True
		
Exit_Run: 
		
		'�N���[�Y
		Call CF_Ora_CloseDyn(usrOdy)
		
		Exit Function
		
Err_Run: 
		
		GoTo Exit_Run
		
	End Function
	
	'''' ADD 2009/03/04  FKS) S.Nakajima    End
	
	'''' ADD 2009/12/25  FKS) T.Yamamoto    Start    �A���[��768
	'''' ADD 2009/01/27  RISE) K.Miyajima    Start �A���[��630
	'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    �A���[��768
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'    '   ���́F  Function F_GRKBP98_RunStored
	'    '   �T�v�F  ���������f�[�^�̕ύX�����̎��s�����i�X�g�A�h�����̌ďo���j
	'    '   �����F  pmstrCLTID    : �[���ԍ�
	'    '           pmstrOPEID    : ���O�C�����[�U�[�h�c
	'    '           pmstrJdnNo    : �󒍔ԍ�
	'    '           pmstrNewDatNo : �`�[�Ǘ���
	'    '           pm_All        : ��ʏ��
	'    '   �ߒl�F�@0�F����I���@9:�ُ�I��
	'    '   ���l�F
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function F_GRKBP98_RunStored( _
	''                                    ByVal pmstrCLTID As String, _
	''                                    ByVal pmstrOPEID As String, _
	''                                    ByVal pmstrJdnNo As String, _
	''                                    ByVal pmstrNewDatNo As String, _
	''                                    ByRef pm_All As Cls_All) As Integer
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function F_GRKBP98_RunStored
	'   �T�v�F  ���������f�[�^�̕ύX�����̎��s�����i�X�g�A�h�����̌ďo���j
	'   �����F  pmstrCLTID    : �[���ԍ�
	'           pmstrOPEID    : ���O�C�����[�U�[�h�c
	'           pmstrUdnDatNo : ����`�[�Ǘ��ԍ�
	'           pmstrUdnLinNo : ����s�ԍ�
	'   �ߒl�F�@0�F����I���@9:�ُ�I��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GRKBP98_RunStored(ByVal pmstrCLTID As String, ByVal pmstrOPEID As String, ByVal pmstrUdnDatNo As String, ByVal pmstrUdnLinNo As String) As Short
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		
		Dim bolRet As Boolean
		Dim intRtnCd As Short '�߂�l
		Dim strExecuteSQL As String
		
		F_GRKBP98_RunStored = 9
		
		On Error GoTo F_GRKBP98_RunStored_err
		
		'// -- ���Ұ��̸ر --
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("RTNCD")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("PARA_OPEID")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("PARA_CLTID")
		'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    �A���[��768
		'    gv_Odb_USR1.Parameters.Remove "PARA_JDNNO"
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("PARA_UDNDATNO")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("PARA_UDNLINNO")
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		
		'// -- ���Ұ��̐ݒ� --
		
		'//�߂�l
		intRtnCd = 0
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("RTNCD", intRtnCd, ORAPARM_OUTPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters("RTNCD").serverType = ORATYPE_NUMBER
		
		'//���O�C�����[�U�[�h�c
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("PARA_OPEID", pmstrOPEID, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters("PARA_OPEID").serverType = ORATYPE_CHAR
		
		'//�[���ԍ�
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("PARA_CLTID", pmstrCLTID, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters("PARA_CLTID").serverType = ORATYPE_CHAR
		
		'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    �A���[��768
		'    '//�󒍔ԍ�
		'    gv_Odb_USR1.Parameters.Add "PARA_JDNNO", pmstrJdnNo, ORAPARM_INPUT
		'    gv_Odb_USR1.Parameters("PARA_JDNNO").serverType = ORATYPE_CHAR
		'
		'    '//�`�[�Ǘ���
		'    gv_Odb_USR1.Parameters.Add "PARA_JDATNO", pmstrNewDatNo, ORAPARM_INPUT
		'    gv_Odb_USR1.Parameters("PARA_JDATNO").serverType = ORATYPE_CHAR
		
		'//����`�[�Ǘ��ԍ�
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("PARA_UDNDATNO", pmstrUdnDatNo, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters("PARA_UDNDATNO").serverType = ORATYPE_CHAR
		
		'//����s�ԍ�
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Add("PARA_UDNLINNO", pmstrUdnLinNo, ORAPARM_INPUT)
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters("PARA_UDNLINNO").serverType = ORATYPE_CHAR
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		
		'//PL/SQL���ĂԁiMAIN�j
		strExecuteSQL = ""
		strExecuteSQL = strExecuteSQL & "BEGIN"
		strExecuteSQL = strExecuteSQL & " :RTNCD := GRKBP98.GRKBP98B ( "
		strExecuteSQL = strExecuteSQL & " :PARA_OPEID "
		strExecuteSQL = strExecuteSQL & ",:PARA_CLTID "
		'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    �A���[��768
		'    strExecuteSQL = strExecuteSQL & ",:PARA_JDNNO "
		'    strExecuteSQL = strExecuteSQL & ",:PARA_JDATNO "
		strExecuteSQL = strExecuteSQL & ",:PARA_UDNDATNO "
		strExecuteSQL = strExecuteSQL & ",:PARA_UDNLINNO "
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		strExecuteSQL = strExecuteSQL & " );"
		strExecuteSQL = strExecuteSQL & "END;"
		
		'DB�A�N�Z�X
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strExecuteSQL)
		If bolRet = False Then
			'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    �A���[��768
			'        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODET52_E_042, pm_All)
			Call AE_CmnMsgLibrary_2(SSS_PrgNm, "2UODET52_042") '�c�a�G���[���������܂����B
			'''' UPD 2009/12/23  FKS) T.Yamamoto    End
			GoTo F_GRKBP98_RunStored_End
		End If
		
		'//�߂�l�m�F
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		If gv_Odb_USR1.Parameters("RTNCD").Value <> 0 Then
			'//(�ُ�)
			'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
			F_GRKBP98_RunStored = gv_Odb_USR1.Parameters("RTNCD").Value
			GoTo F_GRKBP98_RunStored_End
		End If
		
		F_GRKBP98_RunStored = 0
		
F_GRKBP98_RunStored_End: 
		'//���Ұ��̸ر
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("RTNCD")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("PARA_OPEID")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("PARA_CLTID")
		'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    �A���[��768
		'    gv_Odb_USR1.Parameters.Remove "PARA_JDNNO"
		'    gv_Odb_USR1.Parameters.Remove "PARA_JDATNO"
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("PARA_UDNDATNO")
		'UPGRADE_WARNING: �I�u�W�F�N�g gv_Odb_USR1.Parameters �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		gv_Odb_USR1.Parameters.Remove("PARA_UDNLINNO")
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		Exit Function
		
F_GRKBP98_RunStored_err: 
		'''' UPD 2009/12/23  FKS) T.Yamamoto    Start    �A���[��768
		'    Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODET52_E_042, pm_All, "F_GRKBP98_RunStored")
		Call AE_CmnMsgLibrary_2(SSS_PrgNm, "2UODET52_042", "F_GRKBP98_RunStored") '�c�a�G���[���������܂����B
		'''' UPD 2009/12/23  FKS) T.Yamamoto    End
		GoTo F_GRKBP98_RunStored_End
		
	End Function
	'''' ADD 2009/01/27  RISE) K.Miyajima    End   �A���[��630
	'''' ADD 2009/12/25  FKS) T.Yamamoto    End
	
	'20130701 ADD START �V�ʔ̘A�g�Ή�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function CF_Get_Seq_STSTRA
	'   �T�v�F  STSTRA�V�[�P���X�ԍ��擾
	'   �����F�@�Ȃ�
	'   �ߒl�F�@��������R�[�h
	'   ���l�F  �V�[�P���X�ԍ�
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Get_Seq_STSTRA() As String
		
		On Error GoTo ERR_HANDLE
		
		Dim Str_Sql As String
		'UPGRADE_WARNING: �\���� Usr_Ody �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
		Dim Usr_Ody As U_Ody
		
		CF_Get_Seq_STSTRA = ""
		
		Str_Sql = ""
		Str_Sql = Str_Sql & "SELECT"
		Str_Sql = Str_Sql & "       STSSEQ.nextval as VAL "
		Str_Sql = Str_Sql & "FROM"
		Str_Sql = Str_Sql & "       Dual "
		
		If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
			GoTo ERR_HANDLE
		End If
		
		'UPGRADE_WARNING: �I�u�W�F�N�g CF_Ora_GetDyn() �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		CF_Get_Seq_STSTRA = Trim(CF_Ora_GetDyn(Usr_Ody, "VAL"))
		
EXIT_HANDLE: 
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
ERR_HANDLE: 
		GoTo EXIT_HANDLE
		
	End Function
	'20130701 ADD END
	
	' === 20140129 === INSERT S - ����)Shikichi
	Sub EVTLOG_OUT(ByRef PS_Msg_Txt As String, Optional ByRef PS_ProcName As String = "")
		'�p�����[�^�\���̂̐錾
		Dim M_EVTTBL_PARA As M_TYPE_EVTTBL_PARA
		Dim strExePath As String
		Dim dblRet As Double
		'�R�}���h���C�������̐ݒ�
		With M_EVTTBL_PARA
			.IVWRDT = VB6.Format(Now, "YYYYMMDD") '�C�x���g������
			.IVWRTM = VB6.Format(Now, "HHNNSS") '�C�x���g�J�n����
			.PGID = SSS_PrgId '�v���O�����h�c
			.CLTID = SSS_CLTID.Value '�N���C�A���g�h�c
			.IVCLASS = "ERR" '�C�x���g���
			.IVMSG = PS_Msg_Txt '�C�x���g���e
			.IVPOINT = PS_ProcName '�C�x���g�����ӏ�
			.SNDPROFLG = "1" '���M�ۃt���O
			
			If EvJdnno = "" Then
				.IVCODE = "0"
			Else
				.IVCODE = EvJdnno
			End If
			
			
			'EXE�p�X�ƃR�}���h���C���̐ݒ�
			strExePath = SSS_INIDAT(2) & "EXE\EVTLG01.EXE " & Chr(34) & .IVWRDT & .IVWRTM & .PGID & .CLTID & .IVCLASS & .IVCODE & .IVPOINT & .SNDPROFLG & .IVMSG & Chr(34)
		End With
		'�C�x���g���O�쐬�v���O�����N��
		dblRet = Shell(strExePath)
	End Sub
	' === 20140129 === INSERT E - ����)Shikichi
End Module