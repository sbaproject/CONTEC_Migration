VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLS_TOK1 
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '�Œ��޲�۸�
   Caption         =   "�����挟��"
   ClientHeight    =   5220
   ClientLeft      =   1275
   ClientTop       =   3015
   ClientWidth     =   14310
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
   ScaleWidth      =   14310
   ShowInTaskbar   =   0   'False
   Begin VB.CommandButton COM_TOKCD 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      Caption         =   "���Ӑ� "
      Height          =   375
      Left            =   60
      TabIndex        =   7
      TabStop         =   0   'False
      Top             =   90
      Width           =   1470
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      Caption         =   "��ݾ�"
      Height          =   330
      Left            =   7215
      TabIndex        =   2
      Top             =   4740
      Width           =   1095
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   6000
      TabIndex        =   1
      Top             =   4740
      Width           =   1095
   End
   Begin VB.ListBox LST 
      Appearance      =   0  '�ׯ�
      Height          =   3630
      ItemData        =   "WLS_TOK1.frx":0000
      Left            =   60
      List            =   "WLS_TOK1.frx":0002
      TabIndex        =   0
      Top             =   960
      Width           =   14175
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
      Begin VB.TextBox HD_TEXT 
         Appearance      =   0  '�ׯ�
         Height          =   375
         IMEMode         =   2  '��
         Left            =   1500
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
   End
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   60
      TabIndex        =   8
      Top             =   600
      Width           =   14175
      _ExtentX        =   25003
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
      Caption         =   "�����溰�� �����旪�̖�                             ���Ӑ溰�� ���Ӑ旪�̖�"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   1
      Left            =   8100
      Picture         =   "WLS_TOK1.frx":0004
      Top             =   5340
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   1
      Left            =   9000
      Picture         =   "WLS_TOK1.frx":0656
      Top             =   5340
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   0
      Left            =   8595
      Picture         =   "WLS_TOK1.frx":0CA8
      Top             =   5340
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   0
      Left            =   7695
      Picture         =   "WLS_TOK1.frx":12FA
      Top             =   5340
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Left            =   8445
      Picture         =   "WLS_TOK1.frx":194C
      Top             =   4740
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Left            =   5505
      Picture         =   "WLS_TOK1.frx":1F9E
      Top             =   4740
      Width           =   360
   End
End
Attribute VB_Name = "WLS_TOK1"
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
    Private WM_WLS_MEINK_S      As String           '������ʌ����p(�J�n)
    Private WM_WLS_MEINK_E      As String           '������ʌ����p(�I��)
    Private WM_WLS_Pagecnt      As Integer          '�E�B���h�\���y�[�W�J�E���^
    Private WM_WLS_LastPage     As Integer          '�E�B���h�ŏI�y�[�W
    Private WM_WLS_LastFL       As Boolean          '�E�B���h�ŏI�f�[�^���B�t���O
    Private WM_WLS_DSPArray()   As String           '�E�B���h�\���f�[�^
    Private WM_WLS_Dspflg       As Integer          '�E�B���h�\���׸�(True or False)

    Private DblClickFl As Boolean
    
    Private Usr_Ody             As U_Ody            '�ް��ް����ð���
    
    Private Type TYPE_DB_TOKMTB

        TOKSEICD As String * 10
        TOKSEIRN As String * 40
        TOKCD As String * 10
        TOKRN As String * 40

    End Type
    Private DB_TOKMTA_W         As TYPE_DB_TOKMTB   '�������ʑޔ�
    
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
        WLSTOKSUB_RTNCODE = ""
        Call WLS_Clear
        
        '�������ڃN���A
        HD_TEXT.Text = ""
        HD_RN.Text = ""
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   ���́F  Sub WLS_SetArray
    '   �T�v�F  ���X�g�ҏW
    '   �����F�@ArrayCnt : ���X�g�ҏW�Ώ�INDEX
    '   �ߒl�F�@�Ȃ�
    '   ���l�F
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    Private Sub WLS_SetArray(ByVal ArrayCnt As Integer)
'        '====================================
'        '   WINDOW ���אݒ�
'        '====================================

        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(DB_TOKMTA_W.TOKSEICD, 10) & Space(1) _
                                  & LeftWid$(DB_TOKMTA_W.TOKSEIRN, 40) & Space(1) _
                                  & LeftWid$(DB_TOKMTA_W.TOKCD, 10) & Space(1) _
                                  & LeftWid$(DB_TOKMTA_W.TOKRN, 40)
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
            "SELECT tm1.tokseicd, tm1.tokrn tokseirn, tm2.tokcd, tm2.tokrn " _
            & "FROM ( " _
                 & "SELECT tokseicd, tokrn FROM tokmta " _
                  & "WHERE datkb = '1' AND frnkb = '0' " _
                   & " AND dspkb = '1' AND tokcd = tokseicd "
                    '������������A�����敪���P�̂ݕ\��
                    
        '���Ӑ溰�ނ����͂���Ă��鎞
        If Trim(HD_TEXT.Text) <> "" Then
            strSql = strSql & "AND tokcd >= '" & RTrim(HD_TEXT.Text) & "' "
        End If
        
        strSql = strSql & "ORDER BY 1 " _
                 & ") tm1, " _
                 & "tokmta tm2 " _
           & "WHERE tm2.datkb = '1' " _
             & "AND tm2.tokseicd in tm1.tokseicd "
        
        '���Ӑ溰�ނ����͂���Ă��鎞
        If Trim(HD_TEXT.Text) <> "" Then
            strSql = strSql & "AND tm2.tokcd >= '" & RTrim(HD_TEXT) & "' "
        End If
        
        '���Ӑ旪�̖������͂���Ă��鎞(�����܂������Ƃ���)
        If Trim(HD_RN.Text) <> "" Then
            strSql = strSql & "AND tm2.tokrn LIKE '%" & RTrim(HD_RN.Text) & "%' "
        End If
        
        '�������
        strSql = strSql & "ORDER BY tokseicd"

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
            DB_TOKMTA_W.TOKSEICD = CF_Ora_GetDyn(Usr_Ody, "tokseicd", "")
            DB_TOKMTA_W.TOKSEIRN = CF_Ora_GetDyn(Usr_Ody, "tokseirn", "")
            DB_TOKMTA_W.TOKCD = CF_Ora_GetDyn(Usr_Ody, "tokcd", "")
            DB_TOKMTA_W.TOKRN = CF_Ora_GetDyn(Usr_Ody, "tokrn", "")
            
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
        WM_WLS_MEINK_S = ""
        WM_WLS_MEINK_E = ""

        '��ʕ\���y�[�W
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False

        '�������ʕێ��z��
        ReDim WM_WLS_DSPArray(0)

    End Sub

'���Ӑ溰�ރ{�^���N���b�N��
Private Sub COM_TOKCD_Click()
    WLS_TOK2.Show vbModal
    Unload WLS_TOK2
    
    HD_TEXT.SetFocus
    If WLSTOK_RTNCODE <> "" Then
        HD_TEXT.Text = WLSTOK_RTNCODE
        '�������s
        Call WLS_Clear
        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

'
'�ȉ��͉�ʃC�x���g����
'
    Private Sub Form_Activate()


        DoEvents


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
Private Sub HD_RN_KeyDown(KeyCode As Integer, Shift As Integer)
    'Enter�������ɍČ��������s
    If KeyCode = vbKeyReturn Then
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
Private Sub HD_TEXT_KeyDown(KeyCode As Integer, Shift As Integer)
    'Enter�������ɍČ��������s
    If KeyCode = vbKeyReturn Then
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
    WLSTOKSUB_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
    
End Sub

Private Sub LST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)

    If DblClickFl Then Call WLSCANCEL_Click
    
End Sub

Private Sub LST_KeyDown(KeyCode As Integer, Shift As Integer)

    Select Case KeyCode
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
    WLSTOKSUB_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
    Call WLSCANCEL_Click
End Sub

Private Sub WLSCANCEL_Click()
    Hide
End Sub


