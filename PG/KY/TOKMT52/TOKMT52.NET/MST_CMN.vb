Option Strict Off
Option Explicit On
Module MST_CMN
	'
	' ���j�b�g��        : MST_CMN
	' �L�q��            : M.SUEZAWA
	' �쐬���t          : 2007/12/10
	'
	' ���l�@�@          : �}�X�^�����e�i���X�ł̔r������Ή��p�ɐV�K�쐬
	
	'�X�V�����A�X�V���t�A�o�b�`�X�V�����A�o�b�`�X�V���t�@�ޔ�p
	Structure M_TYPE_MOTO
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char '��ѽ����(����)        9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char '��ѽ����(����)        9(06)
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD
	End Structure
	Public M_MOTO_inf As M_TYPE_MOTO
	Public M_MOTO_A_inf() As M_TYPE_MOTO
	
	'�G���[���b�Z�[�W
	
	'����o�^
	Public Const gc_strMsgBMNMT51_E_UPD As String = "BMNMT51_001" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgBMNMT51_E_DEL As String = "BMNMT51_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'��s�o�^
	Public Const gc_strMsgBNKMT51_E_UPD As String = "BNKMT51_001" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgBNKMT51_E_DEL As String = "BNKMT51_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'�J�����_�[�o�^  2007/12/27 ���b�Z�[�W�\���֐����قȂ邽��
	Public Const gc_strMsgCLDMT51_E_UPD As String = "2CLDMT51_013" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgCLDMT51_E_DEL As String = "2CLDMT51_014" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	''''���i�l�o�^     ����@���g�p
	'''Public Const gc_strMsgHINMR51_E_UPD         As String = "HINMR51_001"  '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	'''Public Const gc_strMsgHINMR51_E_DEL         As String = "HINMR51_002"  '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	
	'�Œ�l�o�^
	Public Const gc_strMsgFIXMT51_E_UPD As String = "FIXMT51_017" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgFIXMT51_E_DEL As String = "FIXMT51_018" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'���̓o�^
	Public Const gc_strMsgMEIMT52_E_UPD As String = "MEIMT52_001" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgMEIMT52_E_DEL As String = "MEIMT52_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'�[����M�o�^
	Public Const gc_strMsgNHSMR52_E_UPD As String = "NHSMR52_001" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgNHSMR52_E_DEL As String = "NHSMR52_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'���[�g�}�X�^�o�^
	Public Const gc_strMsgRATMT51_E_UPD As String = "RATMT51_001" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgRATMT51_E_DEL As String = "RATMT51_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'���i�ʎd����P���o�^
	Public Const gc_strMsgSIRMT52_E_UPD As String = "SIRMT52_001" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgSIRMT52_E_DEL As String = "SIRMT52_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'���i�ʎd����ʃ��b�g�P���o�^
	Public Const gc_strMsgSIRMT53_E_UPD As String = "SIRMT53_001" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgSIRMT53_E_DEL As String = "SIRMT53_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���
	'�q�ɓo�^
	Public Const gc_strMsgSOUMT51_E_UPD As String = "SOUMT51_001" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgSOUMT51_E_DEL As String = "SOUMT51_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'�����o�^
	''Public Const gc_strMsgKNGMT51_E_UPD         As String = "KNGMT51_001"  '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	''Public Const gc_strMsgKNGMT51_E_DEL         As String = "KNGMT51_002"  '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'�S���ғo�^
	Public Const gc_strMsgTANMT51_E_UPD As String = "TANMT51_001" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgTANMT51_E_DEL As String = "TANMT51_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'�����l�o�^
	Public Const gc_strMsgTHSMR51_E_UPD As String = "THSMR51_001" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgTHSMR51_E_DEL As String = "THSMR51_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'���i�ʓ��Ӑ�P���o�^
	Public Const gc_strMsgTOKMT52_E_UPD As String = "TOKMT52_001" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgTOKMT52_E_DEL As String = "TOKMT52_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'���i�ʓ��Ӑ�ʃ��b�g�P���o�^
	Public Const gc_strMsgTOKMT53_E_UPD As String = "TOKMT53_001" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgTOKMT53_E_DEL As String = "TOKMT53_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'���Ԃl�o�^  2007/12/27 ���b�Z�[�W�\���֐����قȂ邽��
	Public Const gc_strMsgSBNMT51_E_UPD As String = "2SBNMT51_023" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgSBNMT51_E_DEL As String = "2SBNMT51_024" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'�����N�ʎd�ؗ��o�^
	Public Const gc_strMsgTOKMT55_E_UPD As String = "TOKMT55_001" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgTOKMT55_E_DEL As String = "TOKMT55_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'�P�ʓo�^
	Public Const gc_strMsgUNTMT51_E_UPD As String = "UNTMT51_001" '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	Public Const gc_strMsgUNTMT51_E_DEL As String = "UNTMT51_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'���Ӑ�ʏ��i�����N�o�^   ����@���g�p
	''Public Const gc_strMsgTOKMT54_E_UPD         As String = "TOKMT54_001"  '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	''Public Const gc_strMsgTOKMT54_E_DEL         As String = "TOKMT54_002"  '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'���Ӑ�ʎ戵���i�o�^     ����@���g�p
	''Public Const gc_strMsgTOKMT56_E_UPD         As String = "TOKMT56_001"  '���̃v���O�����ōX�V���ꂽ���߁A�����ł��܂���B
	''Public Const gc_strMsgTOKMT56_E_DEL         As String = "TOKMT56_002"  '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	
	'2008/04/03 add-str H.HONDA ���ʃ��b�Z�[�W��ǉ��B
	'���ʃG���[���b�Z�[�W
	Public Const gc_strMsgCMNER01_E_UPD As String = "CMNER01_001" '���̃v���O�����ōX�V���ꂽ���߁A�X�V�ł��܂���B
	Public Const gc_strMsgCMNER01_E_DEL As String = "CMNER01_002" '���̃v���O�����ōX�V���ꂽ���߁A�폜�ł��܂���B
	'2008/04/03 add-end H.HONDA ���ʃ��b�Z�[�W��ǉ��B
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function MF_Chk_UWRTDTTM
	'   �T�v�F  �X�V���ԃ`�F�b�N����
	'   �����F  pin_strWRTDT    : �X�V���t
	'           pin_strWRTTM    : �X�V����
	'           pin_strUWRTDT   : �o�b�`�X�V���t
	'           pin_strUWRTTM   : �o�b�`�X�V����
	'   �ߒl�F�@True�F�`�F�b�NOK�@False�F�`�F�b�NNG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MF_Chk_UWRTDTTM(ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String) As Boolean
		
		
		On Error GoTo MF_Chk_UWRTDTTM_err
		
		MF_Chk_UWRTDTTM = False
		
		
		'�X�V���ԃ`�F�b�N
		If Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_MOTO_inf.WRTDT) & Trim(M_MOTO_inf.WRTTM) & Trim(M_MOTO_inf.UWRTDT) & Trim(M_MOTO_inf.UWRTTM) Then
			GoTo MF_Chk_UWRTDTTM_End
		End If
		
		MF_Chk_UWRTDTTM = True
		
MF_Chk_UWRTDTTM_End: 
		Exit Function
		
MF_Chk_UWRTDTTM_err: 
		GoTo MF_Chk_UWRTDTTM_End
		
	End Function
	
	'''
	'''' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''''   ���́F  Function MF_Chk_UWRTDTTM_A
	''''   �T�v�F  �X�V���ԃ`�F�b�N����
	''''   �����F  pin_strWRTDT    : �X�V���t
	''''           pin_strWRTTM    : �X�V����
	''''           pin_strUWRTDT   : �o�b�`�X�V���t
	''''           pin_strUWRTTM   : �o�b�`�X�V����
	''''           pin_intIDX      : ���׍s�i0�`�j
	''''   �ߒl�F�@True�F�`�F�b�NOK�@False�F�`�F�b�NNG
	''''   ���l�F  �������R�[�h�Ή�
	'''' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'''Public Function MF_Chk_UWRTDTTM_A(ByVal pin_strWRTDT As String, _
	''''                                  ByVal pin_strWRTTM As String, _
	''''                                  ByVal pin_strUWRTDT As String, _
	''''                                  ByVal pin_strUWRTTM As String, _
	''''                                  ByVal pin_intIDX As Integer) As Boolean
	'''
	'''    On Error GoTo MF_Chk_UWRTDTTM_A_err
	'''
	'''    MF_Chk_UWRTDTTM_A = False
	'''
	'''    '�X�V���ԃ`�F�b�N
	'''    If Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> _
	''''       Trim(M_MOTO_A_inf(pin_intIDX).WRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).WRTTM) & _
	''''       Trim(M_MOTO_A_inf(pin_intIDX).UWRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTTM) Then
	'''        GoTo MF_Chk_UWRTDTTM_A_End
	'''    End If
	'''
	'''    MF_Chk_UWRTDTTM_A = True
	'''
	'''MF_Chk_UWRTDTTM_A_End:
	'''    Exit Function
	'''
	'''MF_Chk_UWRTDTTM_A_err:
	'''    GoTo MF_Chk_UWRTDTTM_A_End
	'''
	'''End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function MF_Chk_UWRTDTTM_T
	'   �T�v�F  �X�V���ԃ`�F�b�N����
	'   �����F  pin_strWRTDT    : �X�V���t
	'           pin_strWRTTM    : �X�V����
	'           pin_strUWRTDT   : �o�b�`�X�V���t
	'           pin_strUWRTTM   : �o�b�`�X�V����
	'           pin_intIDX      : �����ׂ̏ꍇ�@�@�@�@���׍s�i0�`�j
	'   �@�@�@�@�@�@�@�@�@�@�@�@�@���Ӑ�l�o�^�̏ꍇ�@0�c���Ӑ� 1�c�d����
	'   �ߒl�F�@True�F�`�F�b�NOK�@False�F�`�F�b�NNG
	'   ���l�F  �����׋y�сA���Ӑ�l�o�^�p
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MF_Chk_UWRTDTTM_T(ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean
		
		
		On Error GoTo MF_Chk_UWRTDTTM_T_err
		
		MF_Chk_UWRTDTTM_T = False
		
		'''    MsgBox "A " & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM)
		'''    MsgBox "B " & Trim(M_MOTO_A_inf(pin_intIDX).WRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).WRTTM) & _
		'Trim(M_MOTO_A_inf(pin_intIDX).UWRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTTM)
		
		'CHG START FKS)ASANO 2008/03/18
		If InStr(Trim(M_MOTO_A_inf(pin_intIDX).WRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).WRTTM) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then
			
			'�X�V���ԃ`�F�b�N
			If Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_MOTO_A_inf(pin_intIDX).WRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).WRTTM) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTDT) & Trim(M_MOTO_A_inf(pin_intIDX).UWRTTM) Then
				GoTo MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		'CHG END FKS)ASANO 2008/03/18
		
		MF_Chk_UWRTDTTM_T = True
		
MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
MF_Chk_UWRTDTTM_T_err: 
		GoTo MF_Chk_UWRTDTTM_T_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function MF_CmnMsgLibrary
	'   �T�v�F  ���b�Z�[�W�\������
	'   �����F  pin_strMsgCode  : ���b�Z�[�W�R�[�h
	'   �ߒl�F  �I���{�^��
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MF_DspMsg(ByVal pin_strMsgCode As String) As Short
		
		Dim intRet As Short
		
		On Error Resume Next
		
		MF_DspMsg = False
		
		'���b�Z�[�W�\��
		intRet = DSP_MsgBox(SSS_ERROR, pin_strMsgCode, 0)
		
		MF_DspMsg = intRet
		
MF_DspMsg_End: 
		Exit Function
		
MF_DspMsg_err: 
		GoTo MF_DspMsg_End
		
	End Function
	
	'2007/12/24 add-str M.SUEZAWA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function MF_UpDown_UWRTDTTM
	'   �T�v�F  ���ׁ@�폜�E�}������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intGYO      : 1�c�폜�i�s�l�߁j�@-1�c�}���i�s�����j
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo MF_UpDown_UWRTDTTM_err
		
		MF_UpDown_UWRTDTTM = False
		
		'�X�V���ԁ@�z��ړ�
		M_MOTO_A_inf(pin_intIDX).WRTDT = M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_MOTO_A_inf(pin_intIDX).WRTTM = M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_MOTO_A_inf(pin_intIDX).UWRTDT = M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_MOTO_A_inf(pin_intIDX).UWRTTM = M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_MOTO_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_MOTO_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		MF_UpDown_UWRTDTTM = True
		
MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
MF_UpDown_UWRTDTTM_err: 
		GoTo MF_UpDown_UWRTDTTM_End
		
	End Function
	'2007/12/24 add-end M.SUEZAWA
	
	'2007/12/24 add-str M.SUEZAWA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function MF_SaveRestore_UWRTDTTM
	'   �T�v�F  ���ׁ@�ޔ��E��������
	'   �����F  pin_intIDX      : �Ώۍs
	'           pin_intKBN      : 0�c�ޔ��@1�c����
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo MF_SaveRestore_UWRTDTTM_err
		
		MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			'�ޔ��E��������
			M_MOTO_inf.WRTDT = M_MOTO_A_inf(pin_intIDX).WRTDT
			M_MOTO_inf.WRTTM = M_MOTO_A_inf(pin_intIDX).WRTTM
			M_MOTO_inf.UWRTDT = M_MOTO_A_inf(pin_intIDX).UWRTDT
			M_MOTO_inf.UWRTTM = M_MOTO_A_inf(pin_intIDX).UWRTTM
		Else
			'��������
			M_MOTO_A_inf(pin_intIDX).WRTDT = M_MOTO_inf.WRTDT
			M_MOTO_A_inf(pin_intIDX).WRTTM = M_MOTO_inf.WRTTM
			M_MOTO_A_inf(pin_intIDX).UWRTDT = M_MOTO_inf.UWRTDT
			M_MOTO_A_inf(pin_intIDX).UWRTTM = M_MOTO_inf.UWRTTM
		End If
		
		MF_SaveRestore_UWRTDTTM = True
		
MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
MF_SaveRestore_UWRTDTTM_err: 
		GoTo MF_SaveRestore_UWRTDTTM_End
		
	End Function
	'2007/12/24 add-end M.SUEZAWA
	
	'2007/12/24 add-str M.SUEZAWA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   ���́F  Function MF_Clear_UWRTDTTM
	'   �T�v�F  ���ׁ@�Ώۍs�N���A����
	'   �����F  pin_intIDX      : �Ώۍs
	'   �ߒl�F�@True�F����OK�@False�F����NG
	'   ���l�F
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo MF_Clear_UWRTDTTM_err
		
		MF_Clear_UWRTDTTM = False
		'�X�V���ԁ@�z��N���A
		M_MOTO_A_inf(pin_intIDX).WRTDT = ""
		M_MOTO_A_inf(pin_intIDX).WRTTM = ""
		M_MOTO_A_inf(pin_intIDX).UWRTDT = ""
		M_MOTO_A_inf(pin_intIDX).UWRTTM = ""
		
		MF_Clear_UWRTDTTM = True
		
MF_Clear_UWRTDTTM_End: 
		Exit Function
		
MF_Clear_UWRTDTTM_err: 
		GoTo MF_Clear_UWRTDTTM_End
		
	End Function
	'2007/12/24 add-end M.SUEZAWA
End Module