Option Strict Off
Option Explicit On
Module AE_RSMR
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'
	'Common Library 2 V6.60 '���x���A�b�v�̍ۂɕύX�B
	'
	Structure clsPP 'Project Form Property
		Dim MainFormFile As String '
		Dim MainFormObj As String '
		Dim MainForm As String 'MANDALA ̫�ї��́iUCase �ɕϊ�����Ă���j�B�����Ώۂ𔻒肷�邽�߂ɗp����B
		Dim ScX As Short '�e��� MANDALA �V�X�e���R���g���[�� (CursorRest�Ȃǂ�) �� global indeX�B
		Dim CtB As Short '�z�� AE_Controls �� global Base�B
		Dim ControlsC As Short 'MANDALA �R���g���[���̌��B
		Dim OnFocus As Boolean 'MANDALA �R���g���[����Ƀt�H�[�J�X�����邱�Ƃ������i�t���O�j�B'V4.32
		Dim NextTx As Short '���Ƀt�H�[�J�X�𓖂Ă� AE_Controls �� Tx�B
		Dim CursorDest As Short '0: CursorDirection�ɏ]��, 1: Loop, 2:Top, 3:Bottom, 4:Scroll Up , 5:Scroll Down, 9:Check
		Dim CursorDirection As Short '1: Next, 2: Prev, 3:Down, 4:Up, 0:Mouse
		Dim CursorSet As Boolean 'AE_SetFocus �ɂ���Ď��Ƀt�H�[�J�X���ڂ��ׂ��Ƃ��낪�ݒ�ρB
		Dim CursorSave As Short 'AE_CursorSave �ɂ���Ď��Ƀt�H�[�J�X���ڂ��ׂ��Ƃ��낪�ݒ�ρB
		Dim CursorToWhere As Short 'CursorRest �̎��Ƀt�H�[�J�X���ڂ��ׂ� AE_Controls �� Tx�B
		Dim SuppressGotLostFocus As Short '���j���[�̒��ő��̃t�H�[���̃��[�_���� Show �̂悤��
		'�t�H�[�J�X�̈ړ��𔺂�������������ŁA����R���g���[����
		'SetFocus ����ƁA��U�͌��R���g���[���Ƀt�H�[�J�X���ڂ���
		'��� SetFocus ���L���ɂȂ邱�� (�����ɗL���ɂȂ�Ȃ�����)
		'�̕␳�B
		Dim HeadN As Short '�w�b�h���ڂ̌��B(VirCtrl �͊܂܂Ȃ�)
		Dim BodyN As Short '�{�f�B���ڂ̌��B(VirCtrl �͊܂܂Ȃ�)
		Dim EBodyN As Short '�g���{�f�B���ڂ̌��B(VirCtrl �͊܂܂Ȃ�)
		Dim TailN As Short '�e�[�����ڂ̌��B(VirCtrl �͊܂܂Ȃ�)
		Dim BodyV As Short '�{�f�B���ڂ̌��B(VirCtrl ���܂�)
		Dim EBodyV As Short '�g���{�f�B���ڂ̌��B(VirCtrl ���܂�)
		'HeadTx As Integer                 '
		Dim BodyTx As Short '
		Dim EBodyTx As Short '
		Dim NrBodyTx As Short '�{�f�B���̏k�ނ��ď����������̐擪 BodyTx�B
		Dim NrEBodyTx As Short '�g���{�f�B���̏k�ނ��ď����������̐擪 EBodyTx�B
		Dim TailTx As Short '
		Dim BodyPx As Short '
		Dim EBodyPx As Short '
		Dim TailPx As Short '
		Dim PrpC As Short '
		Dim Tx As Short 'TabIndex�B
		Dim ExTx As Short 'Tx �̈ȑO�l�B
		Dim InCompletePx As Short '�C���v�b�g�s���S�� Tx �̒l�B
		Dim Px As Short '
		Dim De As Short '�{�f�B�� Current ����(De)�ԍ��i0 ����n�܂�j�B
		Dim De2 As Short '�{�f�B�� Current ����(De)�ԍ��i-1 �܂��� 0 ����n�܂�j�B
		Dim TopDe As Short '���݁A�\������Ă��閾�ׂ� Top �� ����(De)�ԍ��B
		Dim TopEDe As Short '���݁A�\������Ă��閾�ׂ� Top �� ����(Ee)�ԍ��B
		Dim MaxDe As Short '
		Dim MaxEDe As Short '
		Dim LastDe As Short '���݁A�l���ݒ肳��Ă��� (�����) ���ׂ̒��� Last ����(De)�ԍ��B
		Dim LastEDe As Short '���݁A�l���ݒ肳��Ă��� (�����) ���ׂ̒��� Last ����(De)�ԍ��B
		Dim LastReadDe As Short 'V6.47(5)
		Dim LastReadEDe As Short 'V6.47(5)
		Dim AlreadyCDe As Short '���ɁA���ׂ̑S�N���A������Ă���B
		Dim AlreadyCEDe As Short '���ɁA���ׂ̑S�N���A������Ă���B
		Dim ActiveDe As Short '�}���󔒖��׍s�̖���(De)�ԍ��B-1 �Ȃ�΁A�}���󔒖��׍s�Ȃ��B
		Dim ActiveEDe As Short '�}���󔒖��׍s�̖���(De)�ԍ��B-1 �Ȃ�΁A�}���󔒖��׍s�Ȃ��B
		Dim UnDoDeNo As Short '�������ׂ� De �̔ԍ��B
		Dim UnDoEDeNo As Short '�������ׂ� De �̔ԍ��B
		Dim UnDoDeOp As Short 'De �̕����B 1: �������A2: �폜�A3: �}���B
		Dim UnDoEDeOp As Short 'De �̕����B 1: �������A2: �폜�A3: �}���B
		Dim DeApendable As Boolean '
		Dim EDeApendable As Boolean '
		Dim ScrlMaxL As Short 'Page Up/Down ����� VS_Scrl �� Scroll ����s���B
		Dim EScrlMaxL As Short 'Page Up/Down ����� VS_EScrl �� Scroll ����s���B
		Dim ScrlFlag As Boolean 'LostFocus �ł� Check ��}�~����B
		Dim UpDownFlag As Boolean 'ScrlFlag �𗧂ĂȂ��B'V5.41
		Dim MaxDsp As Short '
		Dim MaxEDsp As Short '
		Dim MaxDspC As Short '����ł̃{�f�B���̍ő�\���s�ԍ��i0 ����n�܂�j�B
		Dim MaxEDspC As Short '����ł̊g���{�f�B���̍ő�\���s�ԍ��i0 ����n�܂�j�B
		Dim MaskMode As Boolean 'Change �C�x���g�̃}�X�N���[�h�B
		Dim InitValStatus As Short '�ύX�̗L���A�Ⴆ�� InitVal ���s�v�ȏ�Ԃ��ǂ����������B
		'InitVal Current First Last Next Prev UpdateC �Őݒ�B
		'Cancel �ŎQ�ƁB Chenge ClearItm ClearDe DeleteDe DeleteDR �ŃN���A�B
		Dim RecalcMode As Boolean '�Čv�Z���[�h�B
		Dim CheckErrNglct As Boolean '�������������ڂ� AE_Check �� Check �����C�x���g���[�`���ŃG���[�ɂȂ��Ă���������B
		Dim ErrorC As Short 'Body, EBody �Čv�Z���[�h�Ō��������G���[�̐��B
		'ErrorMsg As String                '�Ō�ɏo�����G���[���b�Z�[�W�B
		'Timer
		Dim TimerStartUp As Boolean 'Timer �� StartUp �p�ɗp����B
		Dim TimerWorkId As Short 'Timer �� �w��� Timer Work Id �ɗp����B
		': �\�����[�h�� Enter �L�[���������ꍇ�̏����B
		'
		Dim SlistCall As Boolean 'Slist �Ăяo���X�C�b�`�B
		Dim SlistCom As Object 'Slist �̒ʐM�̈�B
		Dim SlistPx As Short 'Slist ���ڂ� Px �l�B'V5.44
		Dim SlistSw As Boolean '���ڂւ̃C���v�b�g�r���� Slist �̎w�߂𔭂����ꍇ�ɁA�G���[�ɂȂ�Ȃ��悤�Ƀo�C�p�X���邽�߂̃X�C�b�`�B
		Dim Mode As Short ':Append, 2:Select, 3:Indicate, 4:Update
		Dim ExMode As Short 'Mode �ύX��F���ł���悤�ɈȑO�� Mode ���ݒ肳���B
		Dim KeyDownMode As Short 'KeyDown �C�x���g�������� Mode�B
		Dim ExMessage As String '
		Dim ChOprtMode As Short 'AE_ChOprtLater �� AE_ChOprt �̒ʐM�̈�B
		Dim Operable As Boolean '����\��Ԃ��ǂ����������t���O�B
		Dim Executing As Boolean '���s���B
		Dim PY_BTop As Single 'Top of Body
		Dim PY_EBTop As Single 'Top of EBody
		Dim PY_BHgt As Single 'Height of Body
		Dim PY_EBHgt As Single 'Height of EBody
		'PY_FHgtFst As Single              'Height of Form (First)
		'PY_FHgtCur As Single              'Height of Form (Current)
		Dim SelValid As Boolean 'GotFocus ���� Sel ��L���ɂ���B
		Dim ArrowLimit As Boolean 'Right �� Left �L�[�ō��ړ����������ړ��ł��Ȃ�����B
		Dim ExplicitExec As Boolean '���j���[�� PF �L�[��R�}���h�ɂ�� Execute�B
		Dim FormHeight As Short 'MANDALA ̫�ьnӼޭ�ق̍���(Form Height)
		Dim FormWidth As Single 'MANDALA ̫�ьnӼޭ�ق̕�(Form Width)
		Dim ButtonClick As Boolean 'Button ���N���b�N���ꂽ���Ƃ������t���O�B
		Dim Override As Short 'Insert ���[�h�� Override ���������t���O�B
		Dim ServerCheck As Short 'ServerCheck
		Dim ComboUpDown As Boolean '�㉺�̖��L�[�ɂ�� ComboBox �� Up Down ����B
		Dim SaveExStatus As Short 'Check �ł� ExStatus �� Save �̈�B
		Dim SaveXV As Object 'Check �ł� ExVal �� Save �̈�B
		Dim SaveCV As Object 'Check �ł� CuVal �� Save �̈�B
		Dim NewVal As Object 'Change �C�x���g�p�̍�Ɨ̈�B
		Dim Caption As String '
		Dim JustAfterSList As Boolean 'V4.21, V4.24 �ō폜�������AV4.27 �ŕ����B
		Dim DerivedOrigin As String '�h���̑匳�̍��ږ��B
		Dim DerivedFrom As String '�h�����̍��ږ��B
		Dim DateSaveFormat As String '���t���f�[�^�x�[�X�Ɋi�[����ۂ̃t�H�[�}�b�g�B
		Dim MultiLineF As Short '�}���`���C���t���O (Integer)�B V4.12
		Dim SuppressMultiTlDerived As Boolean 'Tail �ւ̕������ Derived ��}�~����B V4.12
		Dim NullZero As Boolean 'V4.14
		Dim AL As Boolean 'V4.15
		Dim BrightOnOff As Integer 'V4.15
		Dim CloseCode As Short 'Close Code 'V4.17
		Dim NeglectLostFocusCheck As Boolean 'Image �ɂ�� Slist �w���̖�������B
		Dim LostFocusCheck As Boolean 'V6.44
		Dim ErrorByBackColor As Boolean 'BackColor �ɂ��G���[�\���B
		Dim ReadTopDe As Short '�Ǎ��ݍς݂̐擪�̖��׃f�[�^�̖��׃C���f�b�N�X 'V4.28
		Dim ReadTopEDe As Short '�Ǎ��ݍς݂̐擪�̖��׃f�[�^�̖��׃C���f�b�N�X 'V4.28
		Dim ReadableMaxDe As Short '�ŏI�I�ȓǍ��݂̌��ʁA��ʂɕ\�������{�f�B���̖��׃C���f�b�N�X�̍ő�l (�ő�s�� - 1)�B'V4.28
		Dim ReadableMaxEDe As Short '�ŏI�I�ȓǍ��݂̌��ʁA��ʂɕ\�������g���{�f�B���̖��׃C���f�b�N�X�̍ő�l (�ő�s�� - 1)�B'V4.28
		'ForeColor As Long                 '�\�����ڂ� ForeColor ��F�ɂ��邽�߁B'V4.29 'V5.39 �ō폜�B
		Dim DspTopDe As Short '�\�����ׂ����ׂ� Top �� ����(De)�ԍ��B'V4.34
		Dim DspTopEDe As Short '�\�����ׂ����ׂ� Top �� ����(Ee)�ԍ��B'V4.34
		Dim SuppressCodeClear As Boolean 'Status Bar �� Code ���̃N���A��}�~�BV4.34
		Dim SSCommand5Ajst As Boolean 'SSCommand5 �� �␳�BV4.38
		Dim UnloadMode As Short 'V5.39
		Dim ActiveBlockNo As Short '�A�N�e�B�u�u���b�N�ԍ� 'V5.41
		Dim MaxBlockNo As Short '�ő�u���b�N�ԍ� 'V5.41
		Dim MouseDownTx As Short 'GotFocus ���m���ɂ��邽�߂̏�� 'V6.45
		Dim ShortCutTx As Short 'ShortCut Tx 'V6.55S
		Dim ModalFlag As Boolean 'Modal ��� GotFocus ���m���ɂ��邽�߂̃t���O'V6.45
		Dim ClickPosition As Short 'TextBox ���N���b�N���ꂽ�ʒu (OP_Toyota) 'V6.45
		Dim ScrollObject As Short '�X�N���[���Ώ� 1:Body  2:EBody  3:Both 'V6.45
		Dim Activated As Short 'Activate �ρB'V6.45
		Dim SetCursorRR As Boolean 'V6.46
		Dim SetCursorLF As Boolean 'V6.56F
		Dim hIMC As Integer 'IME �R���e�L�X�g�̃n���h��
		Dim hIMCHwnd As Integer 'IME �R���e�L�X�g���L�R���g���[���̃n���h��
		Dim EditText As Boolean '�e�L�X�g�ҏW�t���O (IME �g�p���ɃL�[���͂�����΃I���ɂ��� )
		Dim SpecSubID As String '
		Dim PageUpDownObject As Short 'PageUp/Down �̑Ώ� 1:Body  2:EBody
		Dim UniScrl As Boolean '
		Dim DoButtonClick As Boolean 'CommandButton �� Click �G�~�����[�g�̂��߂̃t���O�B'V6.47D
		Dim VisibleForItem As Boolean '���ڂ��Ƃ̕\��/��\������B'V6.47V
		Dim AllowNullDes As Boolean '��̖��׍s���������݂��Ă悢�B'V6.47B
		Dim No2Scroll As Boolean '�`���Q�̽�۰ّ���B'V6.47S
		Dim SuppressBeep As Boolean 'KeyPreView �ŃR�[�h��ύX�����ۂ� Beep ���̗}�~ 'V6.49
		Dim ChangeAtGotFocus As Boolean 'GotFocus ���ɓ��e�̕ύX���s�Ȃ����B'V6.50
		Dim SuppressVSScroll As Short 'VS_Scrl �̃X�N���[�����T�v���X����B'V6.53
		Dim SuppressKeyPress As Short 'KeyPress ���T�v���X����B'V6.53
		Dim ModelessForm As System.Windows.Forms.Form '�N�����ׂ����[�h���X�t�H�[�� 'V5.42
		Dim MaskFurigana As Boolean 'Furigana �␳ 'V6.57
		Dim UnderFurigana As Boolean 'Furigana �␳ 'V6.57
		Dim UnderFurigana22 As Boolean 'Furigana �␳ 'V6.59
		Dim PopupTx As Short 'PopUp �Ɋւ���␳ 'V6.59Pop
		Dim NeglectPopupFocus As Boolean 'V6.59Pop
		Dim lpPrevWndProc As Integer 'V6.59Pop
	End Structure
	'
	Structure clsCP 'Control Property
		Dim CpPx As Short 'Px
		Dim InOutMode As Integer '0: Output, 1: Mandatory Output, 2: Input, 3: Mandatory Input
		Dim MaxLength As Short 'Max Length (Byte)
		Dim AutoEnter As Short '0:not, 1:AutoEnter; 16:Enabled; 256:Visible
		Dim KeyInOkClass As Short '"0":Numeric, "A":Alphanumeric, "L":WithLowerCase,
		'"N":Nihon Go ,"C":2 Currency, "U": c
		Dim FixedFormat As Short '0:not, 1:Fixed (Neglect Delete/BackSpace)
		Dim Alignment As Short '0:Left, 1:Right, 2:Center
		'Height As Integer                 'Object Height
		Dim FormatClass As Short '���t, ���l �Ȃǂ̌^ (�ڍׂ́AFormatClass �̒l���Q��)�B
		Dim StatusC As Short '1:Incomplete, 2:Error, 3-5:RelCheck, 6:Checked, 7:Derived, 8:Initial, 100:Error
		Dim StatusF As Short '1:Incomplete, 2:Error, 3-5:RelCheck, 6:Checked, 7:Derived, 8:Initial
		Dim ExStatus As Short '
		Dim CIn As Short 'Character In �̏�� (CIn �̒l���Q��)�B
		Dim TypeA As Short '�R���g���[�̎�� (�ڍׂ́ATypeA �̒l���Q��)�B
		Dim FractionC As Short 'Fraction Count
		Dim TabTab As Short '���̃R���g���[�����܂܂�� Tab �� Tab �ԍ� (�Ȃ���� -1)�B
		Dim CuVal As Object 'Current Value
		Dim ExVal As Object 'Ex Value
		'ErrorFlg As Boolean               'Error Flag 'V4.24
		Dim CheckRtnCode As Short 'Error Return Code 'V6.54
		Dim LineCount As Short 'ListBox �� Line Count 'V4.24
		Dim FormatChr As String 'Format Character
		Dim TpStr As String 'Temporary String
		Dim IniStr As String 'InitVal String
		Dim RelCheckStatus As String 'RelCheck �ł̃G���[��� 'V4.29
		Dim BlockNo As Short '�u���b�N�ԍ� 'V5.40
		Dim Modified As Short '�ύX�̗L���AInitValStatus �̊e���ڔŁB
		Dim NZero As Boolean 'Null To Zero
	End Structure
	'
	Public Const Cn_AutoEnter As Short = 1 'AutoEnter�B
	Public Const Cn_VisibleInit As Short = 256 'Visible �̏����l�B
	Public Const Cn_VisibleCur As Short = 512 'Visible �̌���l�B
	'
	Public AE_Controls() As System.Windows.Forms.Control 'HD_, ED_, TL_ �ȂǁB
	Public AE_Timer() As System.Windows.Forms.Timer 'Timer
	Public AE_CursorRest() As System.Windows.Forms.TextBox '�J�[�\���̋x�e���B
	Public AE_ModeBar() As System.Windows.Forms.TextBox 'Mode �̕\����B
	Public AE_StatusBar() As System.Windows.Forms.Control 'Message �̕\����B
	Public AE_StatusCodeBar() As System.Windows.Forms.Control 'Message Code �̕\����B'V4.24
	Public AE_ScrlBar() As System.Windows.Forms.Control 'Body Scroll Bar�B
	Public AE_EScrlBar() As System.Windows.Forms.Control 'EBody Scroll Bar�B
	'
	Public Cn_DebugMode As Boolean
	'
	Public AE_PSI() As String '
	Public AE_PSIC As Short 'PSI �̌��B
	'
	Public AE_ScX As Short '�e��� AE_Controls �V�X�e���R���g���[���� index �̊�b�l�B
	Public AE_CtB As Short 'AE_Controls �� Base �̊�b�l�B
	'
	Public AE_SSSWin As Boolean '
	'
	Public Ck_Error As Object '
	'
	Public wk_Var As Object '�o���A���g�^�� Work �̈�B
	Public wk_Lng As Integer '�������^ �� Work �̈�B
	Public wk_Int As Short '�����^�� Work �̈�B
	Public wk_Bool As Boolean 'Boolean �^�� Work �̈�B
	Public wk_String As String 'String �^�� Work �̈�B
	'
	Public AE_AppPath As String 'App.Path & "\"
	'
	Public AE_BodyTop() As Single 'Body
	Public AE_EBodyTop() As Single 'EBody
	'
	Public AE_Color(8) As Integer '1:Incomplete, 2:Error, 3-5:RelCheck, 6:Checked, 7:Derived, 8:Initial
	Public AE_BackColor(9) As Integer '0-9
	Public AE_ForeColor(9) As Integer '0-9
	'
	'�����C�x���g���[�`���̃p�����^�� UnDefine �̏ꍇ�Ɏg�p�����B
	Public AE_UnDefine As Object 'Empty �l�����o���A���g�^�ϐ��B
	'
	'�e��̒萔�B-----------------------------------------------------
	'
	'NextTx �̒l�B
	Public Const Cn_NextTxCleared As Short = 10000 '�N���A����Ă��邱�Ƃ������B
	'
	'CursorToWhere �̒l�B
	Public Const Cn_CursorToHome As Short = 10000 '���� CursorHome �ɐݒ肷�邱�Ƃ������B
	Public Const Cn_CursorToRest As Short = -1 '���� CursorRest �ɐݒ肷�邱�Ƃ������B
	'
	'Cursor �̍s����̒l�B
	Public Const Cn_CuInCompletePx As Short = -2 'Cursor �� InCompletePx �Ɉړ��B
	Public Const Cn_CuNop As Short = -1 'Cursor �̈ړ��Ȃ��B
	Public Const Cn_CuCurrent As Short = 0 'Cursor �����ɖ߂��B
	Public Const Cn_CuInit As Short = 1 'Cursor ��������Ԃɂ���B
	Public Const Cn_CuCursorRest As Short = 2 'Cursor �� CursorRest �Ɉړ��B'V6.51C
	Public Const Cn_CuExTx As Short = 10 'Cursor �� ExTx �Ɉړ��B
	Public Const Cn_CuNop100 As Short = 100 'Cursor �ɑ΂��鏈�����s�Ȃ�Ȃ��B
	'
	'CursorDirection �̒l�B
	Public Const Cn_Direction0 As Short = 0 '0: Mouse
	Public Const Cn_Direction1 As Short = 1 '1: Next
	Public Const Cn_Direction2 As Short = 2 '2: Prev
	Public Const Cn_Direction3 As Short = 3 '3: Down
	Public Const Cn_Direction4 As Short = 4 '4: Up
	'
	'CursorDest �̒l�B'V6.51X
	Public Const Cn_Dest0 As Short = 0 '0: �����l
	Public Const Cn_Dest1 As Short = 1 '1: Tab ���ɂ��ٰ�ߏ�̶��وړ�
	Public Const Cn_Dest2 As Short = 2 '2: Top
	Public Const Cn_Dest3 As Short = 3 '3: Bottom
	Public Const Cn_Dest4 As Short = 4 '4: Scroll Up
	Public Const Cn_Dest5 As Short = 5 '5: Scroll Down
	Public Const Cn_Dest6 As Short = 6 '6: Next
	Public Const Cn_Dest7 As Short = 7 '7: Prev
	Public Const Cn_Dest9 As Short = 9 '9: SList
	Public Const Cn_DestBySkip As Short = 10 '9: Skip 'V6.59SkipReflection
	'
	'Mode �̒l�B
	Public Const Cn_Mode1 As Short = 1 '1: AppendC
	Public Const Cn_Mode15 As Short = 15 '15: Current & AppendC 'V4.28
	Public Const Cn_Mode16 As Short = 16 '16: InitValAll & AppendC 'V6.56
	Public Const Cn_Mode2 As Short = 2 '2: SelectCm
	Public Const Cn_Mode25 As Short = 25 '25: SelectCl 'V6.59CL
	Public Const Cn_Mode3 As Short = 3 '3: Indicate
	Public Const Cn_Mode4 As Short = 4 '4: UpdateC
	'
	Public Const Cn_ModeDataChanged As Short = 0 '0: DataChanged
	'
	Public Const Cn_EnabledCn As Short = 100 '100: Enabled / Disabled
	'
	'InOutMode �̒l�B
	Public Const Cn_InOutMode0 As Short = 0 '0: Input
	Public Const Cn_InOutMode1 As Short = 1 '1: Input (Mandatory)
	Public Const Cn_InOutMode2 As Short = 2 '2: Output
	Public Const Cn_InOutMode3 As Short = 3 '3: Output (Mandatory)
	'
	'Status �̒l (StatusC, StatusF, ExStatus)�B
	Public Const Cn_Error As Short = 2
	'
	Public Const Cn_Status0 As Short = 0 '0: Start
	Public Const Cn_Status1 As Short = 1 '1: Incomplete
	Public Const Cn_Status2 As Short = 2 '2: Error
	Public Const Cn_Status3 As Short = 3 '3-5: RelCheck
	Public Const Cn_Status4 As Short = 4
	Public Const Cn_Status5 As Short = 5
	Public Const Cn_Status6 As Short = 6 '6: Checked
	Public Const Cn_Status7 As Short = 7 '7: Derived
	Public Const Cn_Status8 As Short = 8 '8: Initial
	Public Const Cn_StatusError As Short = -1 '-1: Error
	'
	'FormatClass �̒l (���t, ���l �Ȃǂ̌^�̒l)
	Public Const Cn_Date As Short = 1 '���t
	Public Const Cn_Time As Short = 2 '����
	Public Const Cn_Code As Short = 5 '�R�[�h
	Public Const Cn_Memo As Short = 6 '����
	Public Const Cn_Name As Short = 7 '����
	Public Const Cn_Numb As Short = 3 '���l
	Public Const Cn_Snum As Short = 4 '����
	Public Const Cn_Chnu As Short = 8 '�����l 'V6.50
	Public Const Cn_Schn As Short = 9 '������ 'V6.50
	Public Const Cn_NonC As Short = 0 '���̑�
	'
	'TypeA �̒l�B
	Public Const Cn_NormalOrV As Short = 45 'Asc("-")      'Normal or Virtual Control,
	Public Const Cn_InputOnly As Short = 73 'Asc("I")      'Input Only (COMBOBOX2),
	Public Const Cn_OutputOnly As Short = 79 'Asc("O")     'Outout Only (Label),
	Public Const Cn_HandMadeC As Short = 111 'Asc("o")     'Hand Made Control,
	Public Const Cn_CheckBox As Short = 75 'Asc("K")       'Check Box,
	Public Const Cn_ListBox As Short = 76 'Asc("L")        'List Box,
	Public Const Cn_OptionButtonH As Short = 82 'Asc("R")  'Radio (Option) Button �̐擪
	Public Const Cn_OptionButtonC As Short = 114 'Asc("r") 'Radio (Option) Button �Ő擪�ł͂Ȃ�����
	'
	'CIn �̒l�B
	Public Const Cn_NoInput As Short = 0 '0: No Input
	Public Const Cn_BSorDL As Short = 1 '1: Back Space or Delete
	Public Const Cn_ChrInput As Short = 2 '2: Character Input
	Public Const Cn_ValueChanged As Short = 3 '3: Value Changed; ListBox �p�B
	'
	'AE_StatusClear �̃p�����^�B
	Public Const Cn_AllClear As Short = -1
	'
	'���̑�
	Public Const Cn_Surplus4 As Short = 4 'MaxLength �ւ̒ǉ����B
	'
	Public Const Cn_PrfxLen As Short = 3
	Public Const Cn_AfterPrfx As Short = 4 '= Cn_PrfxLen + 1
	'
	Public Const Cn_BS As String = "\" 'Back Slash or "\"
End Module