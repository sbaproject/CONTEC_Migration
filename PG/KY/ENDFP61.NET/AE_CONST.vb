Option Strict Off
Option Explicit On
Module AE_CONST
	'********************************************************************************
	'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
	'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
	'*  �@�\�@�@�@�@�@�@�F�@����
	'*  ���W���[�����@�@�F�@���ʒ萔�錾���W���[��
	'*  �쐬�ҁ@�@�@�@�@�F�@ACE)���V
	'*  �쐬���@�@�@�@�@�F  2006.05.25
	'*-------------------------------------------------------------------------------
	'*<01> YYYY.MM.DD�@�F�@�C�����
	'*     �C����
	'********************************************************************************
	
	'************************************************************************************
	'   Public�萔
	'************************************************************************************
	'���׍s�F�ݒ�
	' === 20060802 === UPDATE S - ACE)Nagasawa
	'    Public Const COLOR_GREEN = &HC000&          '�ΐF = &HC000&(�Z����)
	Public Const COLOR_GREEN As Integer = &H3DA826 '�ΐF = &H3DA826&(�Z����)
	' === 20060802 === UPDATE E -
	Public Const COLOR_BLUE As Integer = &HFFFFC0 '�F = &H00FFFFC0&(������)
	Public Const COLOR_PALEGRAY As Integer = &HF0F0F0 '�����D�F = &HE0E0E0&(�����D�F)
	Public Const COLOR_PALERED As Integer = &HC0C0FF '�����ԐF = &H00C0C0FF&
	'UPGRADE_NOTE: COLOR_PALEYELLOW �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public COLOR_PALEYELLOW As System.Drawing.Color = System.Drawing.Color.Yellow '�������F = &HD2FAFA&
	' === 20060804 === INSERT S - ACE)Nagasawa
	'UPGRADE_NOTE: COLOR_NAVY �� Constant ���� Variable �ɕύX����܂����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C54B49D7-5804-4D48-834B-B3D81E4C2F13"' ���N���b�N���Ă��������B
	Public COLOR_NAVY As System.Drawing.Color = System.Drawing.Color.Blue '�Z���F = &H800000&
	' === 20060804 === INSERT E -
	Public Const COLOR_PALEBLUE As Integer = &HFFFFDD '�������F = &H00FFFFDD&
	Public Const COLOR_PALEGREEN As Integer = &HC9FFCA '�����ΐF = &H00C9FFCA&
	
	'���[�U�[�`�[NO�Ǘ��e�[�u������p
	Public Const gc_strDKBSB_MIT As String = "300" '���ϔԍ��擾�p
	Public Const gc_strDKBSB_UOD As String = "010" '�󒍔ԍ��擾�p
	' === 20060815 === INSERT S - ACE)Nagasawa
	Public Const gc_strDKBSB_PUDL As String = "165" '���o�ɔԍ��擾�p
	' === 20060815 === INSERT E -
	Public Const gc_strDENNM_MIT As String = "����" '���ϔԍ��擾�p
	
	' === 20060912 === INSERT S - ACE)Sejima CRM�A�gCSV�r���Ή�
	'CRM�A�g�t�@�C���Ǎ��p�Œ�l
	'��Ini�t�@�C���ɐݒ肪����ꍇ�A�������D��
	Public Const CRM_RETRY_MAX As Decimal = 10 '��ײ��
	Public Const CRM_RETRY_WAIT As Decimal = 3 '��ײ�Ԋu
	' === 20060912 === INSERT E
	
	'�̔ԃ}�X�^�`�[���
	Public Const gc_strSDKBSB_UOD As String = "20" '�󒍔ԍ��擾�p
	
	'���i����ŋ敪
	Public Const gc_strHINZEIKB_TOK As String = "0" '�����敪�ǂ���
	Public Const gc_strHINZEIKB_NUK As String = "1" '�Ŕ���
	Public Const gc_strHINZEIKB_KOM As String = "2" '�ō���
	Public Const gc_strHINZEIKB_HIK As String = "9" '��ې�
	
	'���Ӑ����ŋ敪
	Public Const gc_strTOKZEIKB_NUK As String = "1" '�Ŕ���
	Public Const gc_strTOKZEIKB_KOM As String = "2" '�ō���
	Public Const gc_strTOKZEIKB_HIK As String = "9" '��ې�
	
	'����Œ[����������
	Public Const gc_strTOKRPSKB_0 As String = "1" '�~����
	Public Const gc_strTOKRPSKB_10 As String = "2" '�\�~����
	Public Const gc_strTOKRPSKB_100 As String = "3" '�S�~����
	
	'����Œ[����������
	Public Const gc_strTOKZRNKB_DWN As String = "0" '�؎̂�
	Public Const gc_strTOKZRNKB_RND As String = "5" '�l�̌ܓ�
	Public Const gc_strTOKZRNKB_UP As String = "9" '�؂�グ
	
	'�Č����X�e�[�^�X
	Public Const gc_strANSTS_OPEN As String = "10" '�I�[�v��
	Public Const gc_strANSTS_CLOSE As String = "20" '�N���[�Y
	Public Const gc_strANSTS_KZK_OPEN As String = "40" '�p���I�[�v��
	Public Const gc_strANSTS_KZK_CLOSE As String = "50" '�p���N���[�Y
	
	'�[�����p�[���Ǝ҃R�[�h
	Public Const gc_strKNNOUGYO_NO As String = "00" '����
	Public Const gc_strKNNOUGYO_SGW As String = "01" '����
	Public Const gc_strKNNOUGYO_SIN As String = "02" '���Z
	
	'��s���ԋ敪
	Public Const gc_strSNKSBN_NML As String = "1" '�ʏ�
	Public Const gc_strSNKSBN_SNK As String = "2" '��s����
	
	'�󒍎捞�G���[�敪
	Public Const gc_strTAKERRKB_OK As String = "0" '����
	Public Const gc_strTAKERRKB_ERR As String = "1" '�G���[
	
	'�󒍊����敪
	Public Const gc_strJDNENDKB_NML As String = "0" '�ʏ�
	Public Const gc_strJDNENDKB_NML2 As String = "1" '�ʏ�H
	Public Const gc_strJDNENDKB_HGI As String = "8" '�����ΏۊO
	
	' === 20061020 === INSERT S - ACE)Nagasawa �I�[�o�[�t���[�Ή�
	Public Const gc_curSIKRT_Max As Decimal = 999.9 '�ő�d�ؗ�
	' === 20061020 === INSERT E -
	
	' === 20061130 === INSERT S - ACE)Nagasawa ���ς͎󒍂Ɏ捞����g�p�Ƃ���
	Public Const gc_strKHIKFL_YES As String = "1" '�������Ώ�
	Public Const gc_strKHIKFL_NO As String = "9" '�������ΏۊO
	' === 20061130 === INSERT E -
	
	' === 20061204 === INSERT S - ACE)Nagasawa ����/�󒍂ł͉c�ƒS���҂̂ݕ\��
	'�c�ƒS���敪
	Public Const gc_strTANCLKB_EIGYO As String = "1" '�c��
	Public Const gc_strTANCLKB_ELSE As String = "9" '�c�ƈȊO
	' === 20061204 === INSERT E -
	
	' === 20061213 === INSERT S - ACE)Nagasawa ���i�̖��ׂ����݂���ꍇ�͍s�ԍ��ɋL���\��
	'���i�̖ڈ�
	' === 20061220 === UPDATE S - ACE)Nagasawa �݌ɐ��`�F�b�N�̕ύX
	'    Public Const gc_strKEPIN                     As String = "��"
	Public Const gc_strKEPIN_ZAI As String = "��"
	Public Const gc_strKEPIN_YZI As String = "�~"
	Public Const gc_strKEPIN_AZI As String = "��"
	' === 20061220 === UPDATE E -
	' === 20061213 === INSERT E -
	
	'���̃}�X�^�i�L�[�R�[�h�j
	Public Const gc_strKEYCD_TUKKB As String = "001" '�ʉ݋敪
	Public Const gc_strKEYCD_BINCD As String = "002" '�֖��R�[�h
	Public Const gc_strKEYCD_GYOSHU As String = "003" '�Ǝ�R�[�h
	Public Const gc_strKEYCD_CHIIKI As String = "004" '�n��R�[�h
	Public Const gc_strKEYCD_URIKJN As String = "005" '����
	Public Const gc_strKEYCD_JDNTRKB As String = "006" '�󒍎���敪
	Public Const gc_strKEYCD_HDNTRKB As String = "007" '��������敪
	Public Const gc_strKEYCD_TNKKB As String = "008" '�P�����
	Public Const gc_strKEYCD_SHAJKN As String = "012" '�x�������R�[�h
	Public Const gc_strKEYCD_YUKOKGN As String = "013" '�L�������R�[�h
	Public Const gc_strKEYCD_SIMUKE As String = "014" '�d���n�R�[�h
	Public Const gc_strKEYCD_BSCD As String = "015" '�ꏊ�R�[�h
	Public Const gc_strKEYCD_JODRSNKB As String = "016" '�󒍗��R�R�[�h
	Public Const gc_strKEYCD_JODCNKB As String = "017" '�󒍃L�����Z�����R�R�[�h
	Public Const gc_strKEYCD_CMPKTCD As String = "020" '�R���s���[�^�^��
	Public Const gc_strKEYCD_STANCD As String = "025" '���Y�S���R�[�h
	Public Const gc_strKEYCD_SOUKOKB As String = "026" '�q�ɋ敪
	Public Const gc_strKEYCD_MAEUKKB As String = "037" '�O��敪
	Public Const gc_strKEYCD_SEIKB As String = "038" '�����敪
	Public Const gc_strKEYCD_JDNINKB As String = "039" '�󒍎捞���
	Public Const gc_strKEYCD_ZAIRNK As String = "041" '�݌Ƀ����N
	Public Const gc_strKEYCD_BKTHKKB As String = "046" '�����s�敪
	Public Const gc_strKEYCD_MORDKB As String = "047" '�ʔ̏o�׋敪
	Public Const gc_strKEYCD_GNKCD As String = "048" '�����Ǘ��R�[�h
	Public Const gc_strKEYCD_ZKTKB As String = "065" '�����敪
	Public Const gc_strKEYCD_OUTRSNCD As String = "066" '���ԏo�ɗ��R�R�[�h
	Public Const gc_strKEYCD_WRKKB As String = "067" '�o�Ɏ�ʃR�[�h
	Public Const gc_strKEYCD_URIKJN_Chk As String = "070" '�������͐���
	Public Const gc_strKEYCD_NOKDTPRT As String = "071" '�q��[���i�󎚗p�j
	Public Const gc_strKEYCD_MITNHSCD As String = "072" '���ϗp�����[����R�[�h
	Public Const gc_strKEYCD_UCHIWAKE As String = "073" '���v�^�C�g������R�[�h
	Public Const gc_strKEYCD_GNKSKKB As String = "074" '�����W�v�敪
	Public Const gc_strKEYCD_HINKB As String = "077" '���i�敪
	Public Const gc_strKEYCD_HIKDT As String = "901" '�����J�n�A�I������
	
	'���̃}�X�^�i�R�[�h�j
	'�󒍎���敪
	Public Const gc_strJDNTRKB_TAN As String = "01" '�P�i
	Public Const gc_strJDNTRKB_SET As String = "11" '�Z�b�g�A�b�v
	Public Const gc_strJDNTRKB_SYS As String = "21" '�V�X�e��
	Public Const gc_strJDNTRKB_SYR As String = "31" '�C��
	Public Const gc_strJDNTRKB_HSY As String = "41" '�ێ�
	Public Const gc_strJDNTRKB_KAS As String = "51" '�ݏo
	Public Const gc_strJDNTRKB_ELS As String = "99" '���̑�
	
	'�P�����
	Public Const gc_strTNKKB_TOK As String = "1" '��
	Public Const gc_strTNKKB_CPN As String = "2" '�L�����y�[��
	Public Const gc_strTNKKB_TOK_NM As String = "��" '���i���j
	Public Const gc_strTNKKB_CPN_NM As String = "�L" '�L�����y�[���i���j
	
	'�I�[�v�����i�敪
	Public Const gc_strOPENKB_NML As String = "1" '�ʏ�
	Public Const gc_strOPENKB_OPN As String = "2" '�I�[�v�����i
	
	'���i���
	Public Const gc_strHINID_NML As String = "01" '�ʏ�݌ɕi
	Public Const gc_strHINID_SETUP As String = "02" '�Z�b�g�A�b�v���i
	' === 20060921 === INSERT S - ACE)Sejima
	Public Const gc_strHINID_SKCH As String = "06" '�����R�[�h
	' === 20060921 === INSERT E
	Public Const gc_strHINID_NEBIKI As String = "11" '�o���l��
	Public Const gc_strHINID_TITLE As String = "12" '���Ϗ��v�^�C�g��
	
	'�����s�敪
	Public Const gc_strBKTHKKB_KA As String = "1" '������
	Public Const gc_strBKTHKKB_FK As String = "9" '�����s��
	
	'�ʔ̏o�׋敪
	Public Const gc_strMORDKB_OK As String = "1" '�ʔ̊܂�
	Public Const gc_strMORDKB_NG As String = "9" '�ʔ̊܂܂Ȃ�
	
	'���̃}�j���A�����͋敪
	Public Const gc_strNMMKB_OK As String = "1" '����
	Public Const gc_strNMMKB_NG As String = "9" '���Ȃ�
	
	'�`�[�폜�敪
	Public Const gc_strDATKB_USE As String = "1" '�g�p��
	Public Const gc_strDATKB_DEL As String = "9" '�폜
	
	'���ԋ敪
	Public Const gc_strSBNNO_MIT As String = "H" '����
	
	'�����\���敪
	Public Const gc_strDSPKB_OK As String = "1" '����
	Public Const gc_strDSPKB_NG As String = "9" '���Ȃ�
	
	'�P���ύX����
	Public Const gc_strTKCHGKB_OK As String = "1" '��������
	Public Const gc_strTKCHGKB_NG As String = "9" '��������
	
	'�󒍍X�V����
	Public Const gc_strJDNUPDKB_OK As String = "1" '��
	Public Const gc_strJDNUPDKB_NG As String = "9" '�s��
	
	'�������
	Public Const gc_strPRTAUTH_OK As String = "1" '��
	Public Const gc_strPRTAUTH_NG As String = "9" '�s��
	
	'�t�@�C���o�͌���
	Public Const gc_strFILEAUTH_OK As String = "1" '��
	Public Const gc_strFILEAUTH_NG As String = "9" '�s��
	
	'�݌ɊǗ��敪
	Public Const gc_strZAIKB_OK As String = "1" '�Ώ�
	Public Const gc_strZAIKB_NG As String = "9" '�ΏۊO
	
	'EDI�����敪
	Public Const gc_strEDIKB_NO As String = "0" '�Ȃ�
	Public Const gc_strEDIKB_VAN As String = "1" 'VAN
	Public Const gc_strEDIKB_WEB As String = "2" 'WEB
	
	'EDI�����敪
	Public Const gc_strEDIKB_OK As String = "1" '����
	Public Const gc_strEDIKB_NG As String = "9" '���Ȃ�
	
	'�ʉ݋敪
	Public Const gc_strTUKKB_JPY As String = "JPY" '�~
	Public Const gc_strTUKKB_USD As String = "USD" '�A�����J���O���h��
	Public Const gc_strTUKKB_EUR As String = "EUR" '���[��
	Public Const gc_strTUKKB_CNY As String = "CNY" '�l����
	
	'�֖��R�[�h
	Public Const gc_strBINCD_SGW As String = "01" '����
	Public Const gc_strBINCD_SIB As String = "02" '����
	Public Const gc_strBINCD_SIN As String = "03" '���Z
	Public Const gc_strBINCD_YMT As String = "04" '���}�g
	
	'�q�ɋ敪
	Public Const gc_strSOUKOKB_HIN As String = "01" '���i�q��
	Public Const gc_strSOUKOKB_THN As String = "02" '�ʔ̑q��
	Public Const gc_strSOUKOKB_TORIOKI As String = "03" '������u�q��
	Public Const gc_strSOUKOKB_KAIGAI As String = "04" '�C�O�q��
	Public Const gc_strSOUKOKB_SERVICE As String = "05" '�T�[�r�X�p�[�c�q��
	Public Const gc_strSOUKOKB_TANASA As String = "06" '�I���q��
	Public Const gc_strSOUKOKB_HAIKI As String = "07" '�p���q��
	Public Const gc_strSOUKOKB_KENSA As String = "08" '�����q��
	Public Const gc_strSOUKOKB_FURYO As String = "09" '�s�Ǖi�q��
	Public Const gc_strSOUKOKB_KASIDASI As String = "10" '�ݏo�q��
	
	'�O��敪
	Public Const gc_strMAEUKKB_NML As String = "1" '�ʏ�
	Public Const gc_strMAEUKKB_MAE As String = "2" '�O��
	
	'�����敪
	Public Const gc_strSEIKB_IKT As String = "1" '�ꊇ
	Public Const gc_strSEIKB_KBT As String = "2" '��
	
	'���敪
	Public Const gc_strSMEKB_DAY As String = "1" '��
	Public Const gc_strSMEKB_WEK As String = "2" '�j��
	
	'����
	Public Const gc_strURIKJN_SYK As String = "01" '�o�׊
	Public Const gc_strURIKJN_KNS As String = "02" '�����
	Public Const gc_strURIKJN_EKM As String = "03" '�𖱊����
	Public Const gc_strURIKJN_KOJ As String = "04" '�H�������
	
	'���Y���敪
	Public Const gc_strSISNKB_JI As String = "0" '����
	Public Const gc_strSISNKB_TA As String = "1" '����
	
	'�������捞���
	Public Const gc_strPRCKB_VAN As String = "V0000" '�������iVAN�j
	Public Const gc_strPRCKB_WEB As String = "W0000" '�������iWEB�j
	Public Const gc_strPRCKB_TUHAN As String = "I0000" '�������i�C���^�[�l�b�g�ʔ́j
	
	'�󒍎捞���
	Public Const gc_strJDNINKB_INP As String = "1" '����
	Public Const gc_strJDNINKB_ML As String = "2" '�ʔ�
	Public Const gc_strJDNINKB_VAN As String = "3" 'VAN
	Public Const gc_strJDNINKB_WEB As String = "4" 'Web
	
	'�}�X�^�敪
	Public Const gc_strMSTKB_TOK As String = "1" '���Ӑ�
	Public Const gc_strMSTKB_NHS As String = "2" '�[����
	Public Const gc_strMSTKB_TAN As String = "3" '�S����
	Public Const gc_strMSTKB_SIR As String = "4" '�d����
	Public Const gc_strMSTKB_HIN As String = "5" '���i
	
	'���s�敪
	Public Const gc_strHAKKB_ZUMI As String = "1" '���s��
	Public Const gc_strHAKKB_SAI As String = "5" '�Ĕ��s
	Public Const gc_strHAKKB_MI As String = "9" '�����s
	
	'�o�ɋ敪
	Public Const gc_strOUTKB_NML As String = "1" '�ʏ�
	Public Const gc_strOUTKB_KKH As String = "2" '�����i�o��
	
	'�󒍓`�[�敪
	Public Const gc_strJDNKB_NML As String = "1" '�ʏ�
	Public Const gc_strJDNKB_SHD As String = "2" '�Z�b�g�A�b�v�w�b�_
	Public Const gc_strJDNKB_SBD As String = "3" '�Z�b�g�A�b�v����
	Public Const gc_strJDNKB_SSK As String = "4" '�Z�b�g�A�b�v���׎x���i
	
	'����敪
	Public Const gc_strZKTKB_NML As String = "1" '�ʏ�
	' === 20060919 === INSERT S - ACE)Sejima �����Ή�
	Public Const gc_strZKTKB_CHOK As String = "2" '����
	' === 20060919 === INSERT E
	
	' === 20060920 === DELETE S - ACE)Sejima �����Ή�
	'D    '����敪����
	'D    Public Const gc_strZKTNM_NML                As String = "�ʏ�"          '�ʏ�
	'D' === 20060919 === INSERT S - ACE)Sejima �����Ή�
	'D    Public Const gc_strZKTNM_CHOK               As String = "����"          '����
	'D' === 20060919 === INSERT E
	' === 20060920 === DELETE E
	
	'�`�[�敪
	Public Const gc_strDENKB_URIAGE As String = "1" '����
	Public Const gc_strDENKB_HENPIN As String = "2" '�ԕi
	Public Const gc_strDENKB_NEBIKI As String = "3" '�l��
	Public Const gc_strDENKB_UNCHIN As String = "4" '�^��
	Public Const gc_strDENKB_SONOTA As String = "5" '���̑�
	
	'�q��`�[�w��敪
	Public Const gc_strTOKDNKB_NML As String = "0" '�ʏ�
	Public Const gc_strTOKDNKB_STI As String = "1" '�w��
	Public Const gc_strTOKDNKB_OGI As String = "2" '����
	
	'�󒍎捞�敪
	Public Const gc_strORDSMKB_MI As String = "0" '���捞
	Public Const gc_strORDSMKB_OK As String = "1" '�捞�ς�
	
	'�P�ʋ敪
	Public Const gc_strUNTNM_KO As String = "��" '��
	
	'����Ń����N
	Public Const gc_strZEIRNKKB_NML As String = "1" '�W������Ń����N
	
	'���i�敪
	' === 20060922 === UPDATE S - ACE)Nagasawa ���i�敪�̃R�[�h�̕ύX
	'    Public Const gc_strHINKB_SYOHIN             As String = "1"             '���i
	'    Public Const gc_strHINKB_SEIHIN             As String = "2"             '���i
	'    Public Const gc_strHINKB_SHIKYU             As String = "4"             '�x���i(�󒍃g�����X�V���̂�)
	'    Public Const gc_strHINKB_BUHIN              As String = "9"             '���i
	Public Const gc_strHINKB_SEIHIN As String = "1" '���i
	Public Const gc_strHINKB_SYOHIN As String = "2" '���i
	' === 20061213 === UPDATE S - ACE)Nagasawa
	Public Const gc_strHINKB_SHIHNHN As String = "3" '�s�̕i
	Public Const gc_strHINKB_KKOHIN As String = "4" '���H�i
	Public Const gc_strHINKB_HNSHN As String = "5" '�����i
	' === 20061213 === UPDATE E -
	Public Const gc_strHINKB_ELSE As String = "9" '���̑�
	' === 20060922 === UPDATE E -
	
	'�C�O����敪
	Public Const gc_strFRNKB_DMS As String = "0" '����
	Public Const gc_strFRNKB_FRN As String = "1" '�C�O
	
	'�d���n
	Public Const pc_strSIMUKE_SANFRANSISCO As String = "00001" '�T���t�����V�X�R
	Public Const pc_strSIMUKE_SINGAPORE As String = "00002" '�V���K�|�[��
	Public Const pc_strSIMUKE_SHANGHAI As String = "00003" '��C
	
	'�󒍈����敪
	Public Const gc_strJODHIKKB_OK As String = "1" '�����Ώ�
	Public Const gc_strJODHIKKB_NG As String = "9" '�����ΏۊO
	
	'�o�ג�~�敪
	Public Const gc_strORTSTPKB_NML As String = "1" '�ʏ�
	Public Const gc_strORTSTPKB_PRE As String = "8" '�o�׏�����
	Public Const gc_strORTSTPKB_STOP As String = "9" '�o�ג�~
	
	'�J�^���O�i�Ώۋ敪
	Public Const gc_strCTLGKB_OK As String = "1" '�Ώ�
	Public Const gc_strCTLGKB_NG As String = "9" '�ΏۊO
	
	'�ʔ̑Ώۋ敪
	Public Const gc_strMLOKB_OK As String = "1" '�Ώ�
	Public Const gc_strMLOKB_NG As String = "9" '�ΏۊO
	
	'���Y�I���敪
	Public Const gc_strPRDENDKB_NML As String = "1" '�ʏ�
	Public Const gc_strPRDENDKB_END As String = "9" '�I��
	
	'�̔������敪
	Public Const gc_strSLENDKB_NML As String = "1" '�ʏ�
	Public Const gc_strSLENDKB_END As String = "9" '�I��
	
	'�󒍒�~�敪
	Public Const gc_strJODSTPKB_NML As String = "1" '�ʏ�
	Public Const gc_strJODSTPKB_STOP As String = "9" '�󒍒�~
	
	'�ێ�I���敪
	Public Const gc_strMNTENDKB_NML As String = "1" '�ʏ�
	Public Const gc_strMNTENDKB_END As String = "9" '�ێ�I��
	
	'�o�׋敪
	Public Const gc_strORTKB_NOW As String = "0" '���s
	Public Const gc_strORTKB_OLD As String = "1" '��
	Public Const gc_strORTKB_NEW As String = "2" '�V
	
	'�V���A���Ǘ��敪
	Public Const gc_strSERIKB_OK As String = "1" '����
	Public Const gc_strSERIKB_NG As String = "9" '���Ȃ�
	
	'�n�d�l
	Public Const gc_strOEMKB_OK As String = "1" '�Ώ�
	Public Const gc_strOEMKB_NG As String = "9" '�ΏۊO
	
	'�Z�b�g�A�b�v�V�[�g�捞�敪
	Public Const gc_strSETUPKB_READ As String = "1" '�捞����
	Public Const gc_strSETUPKB_NOT As String = "9" '�捞�Ȃ�
	
	'�����敪
	Public Const gc_strSKCHKB_NML As String = "1" '���
	Public Const gc_strSKCHKB_SKCH As String = "9" '����
	
	'���{�敪
	Public Const gc_strKHNKB_HON As String = "1" '�{
	Public Const gc_strKHNKB_KARI As String = "9" '��
	
	'�ԍ��敪
	Public Const gc_strAKAKROKB_KURO As String = "1" '���`�[
	Public Const gc_strAKAKROKB_AKA As String = "9" '�ԓ`�[
	
	'����敪��
	Public Const gc_strTHSCD_TOK As String = "1" '���Ӑ�
	Public Const gc_strTHSCD_SIR As String = "2" '�d����
	Public Const gc_strTHSCD_BOTH As String = "3" '���p
	
	'�a�s�n�敪
	Public Const gc_strBTOKB_NML As String = "0" '��ʏ��i
	Public Const gc_strBTOKB_BTO As String = "1" 'BTO���i
	
	'�����W�v�敪
	Public Const gc_strGNKSKKB_H As String = "H" '�����P���Ɋ܂ށE�v��P���Ɋ܂�
	Public Const gc_strGNKSKKB_S As String = "S" '�����P���Ɋ܂܂Ȃ��E�v��P���Ɋ܂�
	Public Const gc_strGNKSKKB_G As String = "G" '�����P���Ɋ܂܂Ȃ��E�v��P���Ɋ܂܂Ȃ�
	
	'���Ϗ����z�\���敪
	Public Const gc_strDSPKNGKKB_DSP As String = "1" '���Ϗ��ɋ��z�\�����s��
	Public Const gc_strDSPKNGKKB_NOT As String = "9" '���Ϗ��ɋ��z�\�����s��Ȃ�
	
	' === 20061119 === INSERT S - ACE)Nagasawa �e�[�u�����C�A�E�g�ύX�Ή��i�^�C���X�^���v�ǉ��j
	'�폜�t���O
	Public Const gc_strDLFLG_INS As String = "2" '�o�^
	Public Const gc_strDLFLG_UPD As String = "3" '����
	Public Const gc_strDLFLG_DEL As String = "1" '�폜
	' === 20061119 === INSERT E -
	
	'�Œ�l�}�X�^
	Public Const gc_strCTLCD_ODNYTDT As String = "206" '�o�ח\����Z�o�p���莞��
	Public Const gc_strCTLCD_HINCD_H As String = "207" '�������z�p�����R�[�h
	Public Const gc_strCTLCD_HINCD_J As String = "208" '�������z�O�p�����R�[�h
	Public Const gc_strCTLCD_HINCD_K As String = "209" '�w���i�p�����R�[�h
	Public Const gc_strCTLCD_NHSCD_EDI As String = "211" 'EDI�A�g�p�[����R�[�h
	Public Const gc_strCTLCD_TANCD_BAT As String = "212" '�o�b�`�N���S���҃R�[�h
	Public Const gc_strCTLCD_CLTID_BAT As String = "213" '�o�b�`�N���S���҃R�[�h
	Public Const gc_strCTLCD_DEFBINCD As String = "215" '�f�t�H���g�֖��R�[�h
	Public Const gc_strCTLCD_ODNYTLT As String = "501" '�^�����[�h�^�C��
	Public Const gc_strCTLCD_JDOSURT As String = "502" '����󒍂̔䗦
	Public Const gc_strCTLCD_ODNYTLT_ORD As String = "504" '�^�����[�h�^�C���i�������捞�p�j
	Public Const gc_strCTLCD_TELFAX_KETA As String = "506" '�d�b�ԍ�/FAX�ԍ�����
	Public Const gc_strCTLCD_TELFAX_HAIHUN As String = "507" '�d�b�ԍ�/FAX�ԍ��n�C�t����
	Public Const gc_strCTLCD_ZIPCD_KETA As String = "508" '�X�֔ԍ�����
	Public Const gc_strCTLCD_ZIPCD_HAIHUN As String = "509" '�X�֔ԍ��n�C�t���ʒu
	Public Const gc_strCTLCD_TELFAX_LSTKETA As String = "511" '�d�b�ԍ�/FAX�ԍ��ŏI���l��������
	
	'�����敪�i�������j
	Public Const gc_strCRRCTKB_INS As String = "1" '�o�^
	Public Const gc_strCRRCTKB_UPD As String = "2" '����
	Public Const gc_strCRRCTKB_DEL As String = "3" '�폜
	
	'�����敪���i�������j
	Public Const gc_strCRRCTKBNM_INS As String = "�V�K" '�V�K
	Public Const gc_strCRRCTKBNM_UPD As String = "�ύX" '�ύX
	Public Const gc_strCRRCTKBNM_DEL As String = "�폜" '�폜
	
	' === 20061004 === INSERT S - ACE)Nagasawa CRM�A�gCSV�o�͕ύX(�A���[ST-0013)
	'�b�q�l�A�g�b�r�u�p�Œ�l
	Public Const gc_strCRMCSV_DummyNo As String = "(TSUKEKAE)" '�Č�ID�t�֔���NO
	' === 20061004 === INSERT E -
	
	' === 20061102 === INSERT S - ACE)Nagasawa �������������̌Ăяo�������̒ǉ�
	'�󒍐��Y�i
	Public Const gc_strJDNSEISAN_OK As String = "1" '�󒍐��Y�Ώەi
	Public Const gc_strJDNSEISAN_NG As String = "9" '�󒍐��Y�ΏۊO
	' === 20061102 === INSERT E -
	
	' === 20061122 === INSERT S - ACE)Nagasawa
	'�o�׎��уg�����̏����敪
	Public Const gc_strWRKKB_NML As String = "1" '�ʏ�o��
	Public Const gc_strWRKKB_BSY As String = "2" '�ꏊ�ړ�
	Public Const gc_strWRKKB_SOK As String = "3" '�q�ɓ��ړ�
	Public Const gc_strWRKKB_THN As String = "4" '�ʔ�
	Public Const gc_strWRKKB_KNK As String = "5" '�ً}�o��
	Public Const gc_strWRKKB_HRY As String = "6" '�����s��
	Public Const gc_strWRKKB_SBN As String = "7" '���ԏo��
	Public Const gc_strWRKKB_SKY As String = "8" '�x��
	' === 20061122 === INSERT E -
	
	' === 20061124 === INSERT S - ACE)Nagasawa
	'�����Ώۋ敪
	Public Const gc_strHIKKB_OK As String = "1" '�Ώ�
	Public Const gc_strHIKKB_NG As String = "9" '�ΏۊO
	' === 20061124 === INSERT E -
	
	'�K�C�h���b�Z�[�W
	Public Const IMG_ENDCM_MSG_INF As String = "���j���[�ɖ߂�܂��B" '�I��
	Public Const IMG_ENDCM_SUB_MSG_INF As String = "�I�����܂��B" '�I���i�T�u��ʁj
	Public Const IMG_EXECUTE_MSG_INF As String = "�o�^���܂��B" '�o�^
	Public Const IMG_HARDCOPY_MSG_INF As String = "��ʂ�������܂��B" '���
	Public Const IMG_INSERTDE_MSG_INF As String = "���׍s��}�����܂��B" '�}��
	Public Const IMG_DELETEDE_MSG_INF As String = "���ׂ���s�폜���܂��B" '�폜
	Public Const IMG_SLIST_MSG_INF As String = "�E�B���h�E��\�����܂��B" '����
	Public Const IMG_PREV_MSG_INF As String = "�O�̃y�[�W��\�����܂��B" '�O�y�[�W
	Public Const IMG_NEXTCM_MSG_INF As String = "���̃y�[�W��\�����܂��B" '���y�[�W
	Public Const IMG_SELECTCM_MSG_INF As String = "��ʂ��N���A���ăR�[�h�̓��͂�҂��܂��B" '����
	Public Const IMG_EXECUTE2_MSG_INF As String = "���s���܂��B" '���s
	Public Const IMG_LSTART_MSG_INF As String = "������J�n���܂��B" '����i���[�j
	Public Const IMG_VSTART_MSG_INF As String = "����C���[�W��\�����܂��B" '��ʕ\��
	Public Const IMG_LCONFIG_MSG_INF As String = "�v�����^�[��I�����܂��B" '����ݒ�
	
	'���b�Z�[�W�o�^�l
	'�{�^�����
	Public Const gc_strBTNKB_OKOnly As Decimal = 0 'OK
	Public Const gc_strBTNKB_OKCancel As Decimal = 1 'OK/�L�����Z��
	Public Const gc_strBTNKB_AbortRetryIgnore As Decimal = 2 '���~/�Ď��s/����
	Public Const gc_strBTNKB_YesNoCancel As Decimal = 3 '�͂�/������/�L�����Z��
	Public Const gc_strBTNKB_YesNo As Decimal = 4 '�͂�/������
	Public Const gc_strBTNKB_RetryCancel As Decimal = 5 '�Ď��s/�L�����Z��
	
	'************************************************************************************
	'   Public�ϐ�
	'************************************************************************************
	
	Public gv_strDLGLST01_RTN As String '�o�^�m�F��ʕԂ�l(1:�o�^�����s 2:�o�^ 3:�߂�)
	
	Public gv_strDLGMSG01_BNGNM As String '�ԍ���
	Public gv_strDLGMSG01_NO As String '�\���ԍ�
End Module