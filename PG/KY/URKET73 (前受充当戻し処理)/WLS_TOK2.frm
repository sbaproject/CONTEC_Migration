VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLS_TOK2 
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '�Œ��޲�۸�
   Caption         =   "���Ӑ挟��"
   ClientHeight    =   5220
   ClientLeft      =   2280
   ClientTop       =   4530
   ClientWidth     =   13050
   BeginProperty Font 
      Name            =   "�l�r �S�V�b�N"
      Size            =   12
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   LockControls    =   -1  'True
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5220
   ScaleWidth      =   13050
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      Caption         =   "��ݾ�"
      Height          =   330
      Left            =   6570
      TabIndex        =   2
      Top             =   4740
      Width           =   1095
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   5355
      TabIndex        =   1
      Top             =   4740
      Width           =   1095
   End
   Begin VB.ListBox LST 
      Appearance      =   0  '�ׯ�
      Height          =   3630
      ItemData        =   "WLS_TOK2.frx":0000
      Left            =   45
      List            =   "WLS_TOK2.frx":0007
      TabIndex        =   0
      Top             =   960
      Width           =   12915
   End
   Begin Threed5.SSPanel5 Panel3D1 
      Height          =   555
      Left            =   0
      TabIndex        =   5
      Top             =   0
      Width           =   14310
      _ExtentX        =   25241
      _ExtentY        =   979
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin VB.ComboBox WLSKANA 
         Appearance      =   0  '�ׯ�
         Height          =   360
         Left            =   11760
         Style           =   2  '��ۯ���޳� ؽ�
         TabIndex        =   8
         Top             =   75
         Width           =   1185
      End
      Begin VB.TextBox HD_TEXT 
         Appearance      =   0  '�ׯ�
         Height          =   375
         IMEMode         =   2  '��
         Left            =   1200
         MaxLength       =   5
         TabIndex        =   3
         Text            =   "XXXXX"
         Top             =   75
         Width           =   885
      End
      Begin VB.TextBox HD_RN 
         Appearance      =   0  '�ׯ�
         Height          =   375
         IMEMode         =   4  '�S�p�Ђ炪��
         Left            =   3975
         MaxLength       =   40
         TabIndex        =   4
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
         Top             =   80
         Width           =   5100
      End
      Begin Threed5.SSPanel5 SSPanel51 
         Height          =   375
         Left            =   2355
         TabIndex        =   6
         Top             =   80
         Width           =   1635
         _ExtentX        =   2884
         _ExtentY        =   661
         BackColor       =   12632256
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "���Ӑ旪��"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 PNL_USENM 
         Height          =   375
         Index           =   3
         Left            =   10530
         TabIndex        =   9
         Top             =   75
         Width           =   1230
         _ExtentX        =   2170
         _ExtentY        =   661
         BackColor       =   12632256
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "�J�i����"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 SSPanel52 
         Height          =   375
         Left            =   105
         TabIndex        =   10
         Top             =   75
         Width           =   1110
         _ExtentX        =   1958
         _ExtentY        =   661
         BackColor       =   12632256
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "�l�r �S�V�b�N"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "�J�n����"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
   End
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   60
      TabIndex        =   7
      Top             =   600
      Width           =   12915
      _ExtentX        =   22781
      _ExtentY        =   661
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "�l�r �S�V�b�N"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   1
      BevelOuter      =   1
      Caption         =   " ����     ���Ӑ於                                 ��  ��      �������      �ŋ�    �d�b�ԍ�      ������"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   1
      Left            =   8100
      Picture         =   "WLS_TOK2.frx":0010
      Top             =   5340
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   1
      Left            =   9000
      Picture         =   "WLS_TOK2.frx":0662
      Top             =   5340
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   0
      Left            =   8595
      Picture         =   "WLS_TOK2.frx":0CB4
      Top             =   5340
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   0
      Left            =   7695
      Picture         =   "WLS_TOK2.frx":1306
      Top             =   5340
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Left            =   7800
      Picture         =   "WLS_TOK2.frx":1958
      Top             =   4740
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Left            =   4860
      Picture         =   "WLS_TOK2.frx":1FAA
      Top             =   4740
      Width           =   360
   End
End
Attribute VB_Name = "WLS_TOK2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'*************************************************************************************************
'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
'*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
'*  �v���O�������@�@�F�@����������� �� �����挟���ɉ��� 2007/03/05 Saito
'*  �v���O�����h�c�@�F  WLS_MEI
'*  �쐬�ҁ@�@�@�@�@�F�@SYSTEM CREATE Co.,Ltd.
'*  �쐬���@�@�@�@�@�F  2006.10.21
'*------------------------------------------------------------------------------------------------
'*<01> YYYY.MM.DD�@�F�@�C�����
'*     �C����
'*************************************************************************************************
    
'************************************************************************************
'   Private�萔
'************************************************************************************
    
    Private Const WM_WLSKEY_ZOKUSEI = "X"       '�J�n�R�[�h���͑��� [0,X]

'************************************************************************************
'   Private�ϐ�
'************************************************************************************
    '�E�B���hհ�ް�ݒ�ϐ�
    Private WM_WLS_MFIL         As Integer          '�E�B���h�\��Ҳ�̧��
    Private WM_WLS_CODELEN      As Integer          '�J�n���ޓ��͕�����
    Private WM_WLS_NAMELEN      As Integer          '���Ӑ旪�̓��͕�����

    '�E�B���h�����g�p�ϐ�
    Private WM_WLS_MAX          As Integer          '�P��ʂ̕\������
    Private WM_WLS_CODE         As String           '������ʃR�[�h�����p
    Private WM_WLS_MEIRN        As String           '������ʗ��̌����p
    Private WM_WLS_TOKNK_S      As String           '������ʌ����p(�J�n)
    Private WM_WLS_TOKNK_E      As String           '������ʌ����p(�I��)
    Private WM_WLS_Pagecnt      As Integer          '�E�B���h�\���y�[�W�J�E���^
    Private WM_WLS_LastPage     As Integer          '�E�B���h�ŏI�y�[�W
    Private WM_WLS_LastFL       As Boolean          '�E�B���h�ŏI�f�[�^���B�t���O
    Private WM_WLS_DSPArray()   As String           '�E�B���h�\���f�[�^
    Private WM_WLS_Dspflg       As Integer          '�E�B���h�\���׸�(True or False)

    Private DblClickFl As Boolean
    
    Private Usr_Ody             As U_Ody            '�ް��ް����ð���
    
    Private DB_TOKMTA_W         As TYPE_DB_TOKMTA   '�������ʑޔ�
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_FORM_INIT
    '   �T�v�F  ��ʏ�����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_FORM_INIT()
    
        '=== �\���J�n�R�[�h�����ݒ� ===
        WM_WLS_CODELEN = 10
        WM_WLS_MAX = 15                 '��ʕ\������
        '�ϐ�������
        WLSTOK_RTNCODE = ""
        Call WLS_Clear
        
        '�������ڃN���A
        HD_TEXT.Text = ""
        HD_RN.Text = ""
        '�R���{�{�b�N�X�Z�b�g
        WLS_Kana_Init
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_SetArray
    '   �T�v�F  ���X�g�ҏW
    '   �����F�@ArrayCnt : ���X�g�ҏW�Ώ�INDEX
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    Private Sub WLS_SetArray(ByVal ArrayCnt As Integer)
        '====================================
        '   WINDOW ���אݒ�
        '====================================

        Dim WK_KESNM As String, WK_ZEINM As String, WK_TK As String * 13, WK_SMENM As String
        Dim WK_KESDD As String
        '
        Select Case SSSVal(DB_TOKMTA_W.TOKZEIKB)
            Case 1
                WK_ZEINM = "�Ŕ�  "
            Case 2
                WK_ZEINM = "�ō�  "
            Case 9
                WK_ZEINM = "�ΏۊO"
            Case Else
                WK_ZEINM = "      "
        End Select
        '
        Select Case SSSVal(DB_TOKMTA_W.TOKSMEKB)
            Case 1
                WK_SMENM = DB_TOKMTA_W.TOKSMEDD & "����    "
                Select Case SSSVal(DB_TOKMTA_W.TOKKESCC)
                    Case 0
                        WK_KESNM = "  ����"
                    Case 1
                        WK_KESNM = "  ����"
                    Case 2
                        WK_KESNM = "���X��"
                    Case Else
                        WK_KESNM = "���̑�"
                End Select
                WK_KESNM = WK_KESNM & DB_TOKMTA_W.TOKKESDD & "�����"
            Case 2
                WK_SMENM = SSS_WEEKNM(SSSVal(DB_TOKMTA_W.TOKSDWKB)) & "��      " & SSS_WEEKNM(SSSVal(DB_TOKMTA_W.TOKKDWKB)) & "���"
            Case Else
                WK_SMENM = Space(8)
        End Select
        '
        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(DB_TOKMTA_W.TOKCD, 5) & Space(5) & _
                                    LeftWid$(DB_TOKMTA_W.TOKRN, 40) & Space(1) & _
                                    WK_SMENM & WK_KESNM & Space(2) & _
                                    WK_ZEINM & Space(2) & _
                                    LeftWid$(DB_TOKMTA_W.TOKTL, 13) & Space(1) & _
                                    LeftWid$(DB_TOKMTA_W.TOKSEICD, 5)
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_TextSQL
    '   �T�v�F  ����sql�쐬
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    Sub WLS_TextSQL()

        Dim strSql          As String
        Dim intData         As Integer

        strSql = _
            "SELECT * FROM tokmta " _
           & "WHERE datkb = '1' AND frnkb = '0' AND dspkb = '1' "
                 '������������A�����Ώۋ敪���P�̂ݕ\��
                    
        '�J�n���ނ����͂���Ă��鎞
        If Trim(HD_TEXT.Text) <> "" Then
            strSql = strSql & "AND tokcd >= '" & RTrim(HD_TEXT.Text) & "' "
        End If
        
        '���Ӑ旪�̖������͂���Ă��鎞(�����܂������Ƃ���)
        If Trim(HD_RN.Text) <> "" Then
            strSql = strSql & "AND tokrn LIKE '%" & RTrim(HD_RN.Text) & "%' "
        End If
        
        '���Ӑ�J�i����
        If Trim(WM_WLS_TOKNK_S) <> "" Then
            strSql = strSql & "AND TOKNK >= '" & WM_WLS_TOKNK_S & "' And TOKNK < '" & WM_WLS_TOKNK_E & "' "
        
        End If
        
        '�������
        If Trim(WM_WLS_TOKNK_S) <> "" Then
            strSql = strSql & "ORDER BY toknk, tokcd"
        Else
            strSql = strSql & "ORDER BY tokcd"
        End If
        
        'DB�A�N�Z�X
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
        
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_DspNew
    '   �T�v�F  ���X�g�ҏW����(�������)
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_DspNew()
        Dim Cnt             As Long
        Dim Wk_Pagecnt      As Integer
        
        Cnt = 0
        Wk_Pagecnt = -1
        Do Until CF_Ora_EOF(Usr_Ody) = True
            
            '�擾���e�ޔ�
            DB_TOKMTA_W.TOKCD = CF_Ora_GetDyn(Usr_Ody, "TOKCD", "")               '���Ӑ�R�[�h
            DB_TOKMTA_W.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")               '���Ӑ旪��
            DB_TOKMTA_W.TOKZEIKB = CF_Ora_GetDyn(Usr_Ody, "TOKZEIKB", "")         '����ŋ敪
            DB_TOKMTA_W.TOKSMEKB = CF_Ora_GetDyn(Usr_Ody, "TOKSMEKB", "")         '���敪
            DB_TOKMTA_W.TOKSMEDD = CF_Ora_GetDyn(Usr_Ody, "TOKSMEDD", "")         '���������t�i����j
            DB_TOKMTA_W.TOKKESCC = CF_Ora_GetDyn(Usr_Ody, "TOKKESCC", "")         '����T�C�N�����������t�i����j
            DB_TOKMTA_W.TOKKESDD = CF_Ora_GetDyn(Usr_Ody, "TOKKESDD", "")         '������t
            DB_TOKMTA_W.TOKSDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKSDWKB", "")         '����j��
            DB_TOKMTA_W.TOKKDWKB = CF_Ora_GetDyn(Usr_Ody, "TOKKDWKB", "")         '���ߗj��
            DB_TOKMTA_W.TOKTL = CF_Ora_GetDyn(Usr_Ody, "TOKTL", "")               '���Ӑ�d�b�ԍ�
            DB_TOKMTA_W.TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "TOKSEICD", "")         '������R�[�h
            
                
            '�\�����y�[�W
            If Cnt Mod WM_WLS_MAX = 0 Then
                Wk_Pagecnt = Wk_Pagecnt + 1
                '�ŏI�y�[�W�ޔ�
                WM_WLS_LastPage = Wk_Pagecnt
                ReDim Preserve WM_WLS_DSPArray((Wk_Pagecnt + 1) * WM_WLS_MAX)
                Cnt = 0
            End If
        
            '�\���������W�J
            Call WLS_SetArray(Wk_Pagecnt * WM_WLS_MAX + Cnt)
            
            Cnt = Cnt + 1
            
            Call CF_Ora_MoveNext(Usr_Ody)
        Loop
        
        '�擾�f�[�^�L���Ɋւ�炸�ŏI�f�[�^���B
        WM_WLS_LastFL = True
        
        If Cnt > 0 Then
            '�P�y�[�W��\��
            WM_WLS_Pagecnt = 0
            Call WLS_DspPage
        Else
            LST.Clear
        End If
    
    End Sub
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_DspPage
    '   �T�v�F  ���X�g�ҏW����
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_DspPage()
        Dim WL_Mode As Integer
        Dim intCnt     As Integer

        If UBound(WM_WLS_DSPArray) <= 0 Then
            Exit Sub
        End If

        LST.Clear
        intCnt = 0
        Do While intCnt < WM_WLS_MAX
            If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)) > "" Then
                LST.AddItem WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + intCnt)
            End If
            intCnt = intCnt + 1
        Loop
        If LST.ListCount > 0 Then
            LST.ListIndex = 0
            LST.SetFocus
        End If
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_Clear
    '   �T�v�F  �ϐ�������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_Clear()
        'Sub WLS_Clear

        '��������
        WM_WLS_CODE = ""
        WM_WLS_MEIRN = ""
        WM_WLS_TOKNK_S = ""
        WM_WLS_TOKNK_E = ""

        '��ʕ\���y�[�W
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False

        '�������ʕێ��z��
        ReDim WM_WLS_DSPArray(0)

    End Sub

'
'�ȉ��͉�ʃC�x���g����
'
    Private Sub Form_Activate()


        WM_WLS_Dspflg = False

        '���ڏ�����
        'Call WLS_Kana_Init
        'HD_CODE.Text = ""
        'HD_NAME.Text = ""
        'WLSKANA.ListIndex = 0
        LST.Clear
        WM_WLS_Dspflg = True

        ReDim WM_WLS_DSPArray(0)

        '������ԑS���\��
        Call WLS_TextSQL
        Call WLS_DspNew
        
        DblClickFl = False
        
        Me.Refresh
        'HD_CODE.SetFocus
    End Sub

Private Sub Form_Load()
    'WINDOW �ʒu�ݒ�
    Left = (Screen.Width - Width) / 2
    Top = (Screen.Height - Height) / 2
    
    'Window�����ݒ�
    Call WLS_FORM_INIT
End Sub

'���Ӑ旪�̍��ڂŃL�[����������
Private Sub HD_RN_GotFocus()
    '�S�I����Ԃɂ���
    HD_RN.SelStart = 0
    HD_RN.SelLength = 40
End Sub

'���Ӑ旪�̍��ڂŃL�[����������
Private Sub HD_RN_KeyDown(KEYCODE As Integer, Shift As Integer)
    'Enter�������ɍČ��������s
    If KEYCODE = vbKeyReturn Then
        WLSKANA.ListIndex = -1
        Call WLS_Clear
        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

'���Ӑ溰�ލ��ڂɃt�H�[�J�X���ړ�������
Private Sub HD_TEXT_GotFocus()
    '�S�I����Ԃɂ���
    HD_TEXT.SelStart = 0
    HD_TEXT.SelLength = 5
End Sub

'���Ӑ溰�ލ��ڂŃL�[����������
Private Sub HD_TEXT_KeyDown(KEYCODE As Integer, Shift As Integer)
    'Enter�������ɍČ��������s
    If KEYCODE = vbKeyReturn Then
        WLSKANA.ListIndex = -1
        Call WLS_Clear
        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

'''Private Sub HD_CODE_GotFocus()
'''    If LenWid(HD_CODE.Text) > 0 Then
'''        HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.MaxLength, WM_WLSKEY_ZOKUSEI)
'''    Else
'''        HD_CODE.Text = Space$(HD_CODE.MaxLength)
'''    End If
'''    HD_CODE.SelStart = 0
'''    HD_CODE.SelLength = HD_CODE.MaxLength
'''End Sub
'''
'''Private Sub HD_CODE_KeyDown(KeyCode As Integer, Shift As Integer)
'''    If KeyCode = vbKeyReturn Then
'''        WM_WLS_Dspflg = False
'''        HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.MaxLength, WM_WLSKEY_ZOKUSEI)
'''
'''        '�����p�ϐ��Z�b�g
'''        Call WLS_Clear
'''        WM_WLS_CODE = HD_CODE.Text
'''
'''        '�����������N���A
'''        WM_WLS_Dspflg = True
'''
'''        Call WLS_TextSQL
'''        Call WLS_DspNew
'''    End If
'''End Sub

Private Sub LST_DblClick()

    DblClickFl = True
    WLSTOK_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
    
End Sub

Private Sub LST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)

    If DblClickFl Then Call WLSCANCEL_Click
    
End Sub

Private Sub LST_KeyDown(KEYCODE As Integer, Shift As Integer)

    Select Case KEYCODE
        'Enter�L�[����
        Case vbKeyReturn
            Call WLSOK_Click
            
        'Escape�L�[����
        Case vbKeyEscape
            Call WLSCANCEL_Click
        
        '���L�[����
        Case vbKeyLeft
            Call WLSMAE_Click
            
        '���L�[����
        Case vbKeyRight
            Call WLSATO_Click
            If LST.ListCount > 0 Then
                LST.ListIndex = -1
            End If
    End Select
    
End Sub

Private Sub WLSATO_Click()

    If LST.ListCount <= 0 Then Exit Sub

    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
        If Not WM_WLS_LastFL Then Call WLS_DspPage
    Else
        WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
        Call WLS_DspPage
    End If
End Sub

Private Sub WLSATO_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSATO.Picture = IM_ATO(1).Picture
End Sub

Private Sub WLSATO_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSATO.Picture = IM_ATO(0).Picture
End Sub


Private Sub WLSKANA_Click()
    Dim W_BUF As String * 2
    
    Call WLS_Clear

    '�����p�ϐ��Z�b�g
    If WLSKANA.ListIndex > 0 Then
        W_BUF = Right$(WLSKANA.List(WLSKANA.ListIndex), 2)
        WM_WLS_TOKNK_S = Left$(W_BUF, 1)
        WM_WLS_TOKNK_E = Chr$(Asc(Right$(W_BUF, 1)) + 1)
        '�����������N���A
        HD_TEXT.Text = ""
        HD_RN.Text = ""
    
        Call WLS_TextSQL
        Call WLS_DspNew
    Else
'            W_BUF = ""
'            WM_WLS_TOKNK_S = ""
'            WM_WLS_TOKNK_E = ""
        '�����������N���A
        HD_TEXT.Text = ""
        HD_RN.Text = ""
    
        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

Private Sub WLSMAE_Click()
    If WM_WLS_Pagecnt > 0 Then
        WM_WLS_Pagecnt = WM_WLS_Pagecnt - 1
        Call WLS_DspPage
    End If
End Sub

Private Sub WLSMAE_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSMAE.Picture = IM_MAE(1).Picture
End Sub

Private Sub WLSMAE_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    WLSMAE.Picture = IM_MAE(0).Picture
End Sub

Private Sub WLSOK_Click()
    WLSTOK_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
    Call WLSCANCEL_Click
End Sub

Private Sub WLSCANCEL_Click()
    Hide
End Sub


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_Kana_Init
    '   �T�v�F  �J�i�R���{�{�b�N�X������
    '   �����F�@�Ȃ�
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub WLS_Kana_Init()

        '�J�i���� Combo ������
        WLSKANA.Clear
        WLSKANA.AddItem "�R�[�h"
        WLSKANA.AddItem "�A�s      ��"
        WLSKANA.AddItem "�J�s      ��"
        WLSKANA.AddItem "�T�s      ��"
        WLSKANA.AddItem "�^�s      ��"
        WLSKANA.AddItem "�i�s      ��"
        WLSKANA.AddItem "�n�s      ��"
        WLSKANA.AddItem "�}�s      ��"
        WLSKANA.AddItem "���s      ��"
        WLSKANA.AddItem "���s      ��"
        WLSKANA.AddItem "���s      ��"

    End Sub
