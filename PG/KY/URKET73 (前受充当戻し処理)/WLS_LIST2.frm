VERSION 5.00
Begin VB.Form WLS_LIST2 
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '�Œ��޲�۸�
   Caption         =   "��������ꗗ"
   ClientHeight    =   4380
   ClientLeft      =   3660
   ClientTop       =   3165
   ClientWidth     =   6195
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
   ScaleHeight     =   4380
   ScaleWidth      =   6195
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  '��ʂ̒���
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      Caption         =   "��ݾ�"
      Height          =   330
      Left            =   3120
      TabIndex        =   2
      Top             =   3870
      Width           =   915
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  '�ׯ�
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   2175
      TabIndex        =   1
      Top             =   3870
      Width           =   915
   End
   Begin VB.ListBox LST 
      Appearance      =   0  '�ׯ�
      Height          =   3630
      Left            =   0
      TabIndex        =   0
      Top             =   15
      Width           =   6195
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   1
      Left            =   2775
      Picture         =   "WLS_LIST2.frx":0000
      Top             =   4410
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   1
      Left            =   3675
      Picture         =   "WLS_LIST2.frx":0652
      Top             =   4410
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   0
      Left            =   3270
      Picture         =   "WLS_LIST2.frx":0CA4
      Top             =   4410
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Index           =   0
      Left            =   2370
      Picture         =   "WLS_LIST2.frx":12F6
      Top             =   4410
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Left            =   4155
      Picture         =   "WLS_LIST2.frx":1948
      Top             =   3870
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  '�ׯ�
      Height          =   330
      Left            =   1665
      Picture         =   "WLS_LIST2.frx":1F9A
      Top             =   3870
      Width           =   360
   End
End
Attribute VB_Name = "WLS_LIST2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
'*************************************************************************************************
'*  �V�X�e�����@�@�@�F  �V�������V�X�e��
'*  �T�u�V�X�e�����@�F�@�̔��V�X�e��
'*  �@�\�@�@�@�@�@�@�F�@�����E�B���h�E
'*  �v���O�������@�@�F�@�����������
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
    
    Private Type TYPE_DB_MEIMTA
        MEICDA As String * 9
        MEICDB As String * 1
        MEINMA As String * 40
    End Type
    Private DB_SYSMEI_W         As TYPE_DB_MEIMTA   '�������ʑޔ�
    
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
        WLSKOZ_RTNCODE = ""
        Call WLS_Clear
        
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

        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(DB_SYSMEI_W.MEICDB, 1) & _
                                    LeftWid$(DB_SYSMEI_W.MEICDA, 9) & Space(2) & _
                                    LeftWid$(DB_SYSMEI_W.MEINMA, 40)
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

        strSql = ""
        strSql = strSql & " Select MEICDB"
        strSql = strSql & "      , MEICDA "          '��������R�[�h"
        strSql = strSql & "      , MEINMA "          '���������
        strSql = strSql & "   from MEIMTA "
        strSql = strSql & "  Where DATKB    = '1' "
        strSql = strSql & "  And   KEYCD    = '062' "
''''''''strSQL = strSQL & "  And   MEIKBA   = '1'"                          '2006.10.24�d��
        
        '�\�[�g����
        strSql = strSql & "   order by MEICDB, MEICDA"
        
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
            DB_SYSMEI_W.MEICDB = CF_Ora_GetDyn(Usr_Ody, "MEICDB", "")       '��������R�[�h
            DB_SYSMEI_W.MEICDA = CF_Ora_GetDyn(Usr_Ody, "MEICDA", "")       '��������R�[�h
            DB_SYSMEI_W.MEINMA = CF_Ora_GetDyn(Usr_Ody, "MEINMA", "")       '���������
            
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
    WLSKOZ_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
    
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
    WLSKOZ_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
    Call WLSCANCEL_Click
End Sub

Private Sub WLSCANCEL_Click()
    Hide
End Sub


