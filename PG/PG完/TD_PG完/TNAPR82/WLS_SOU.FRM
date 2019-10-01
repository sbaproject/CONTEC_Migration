VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLSSOU 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "倉庫検索"
   ClientHeight    =   5400
   ClientLeft      =   1665
   ClientTop       =   3300
   ClientWidth     =   7500
   ClipControls    =   0   'False
   ControlBox      =   0   'False
   BeginProperty Font 
      Name            =   "ＭＳ ゴシック"
      Size            =   12
      Charset         =   128
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   ForeColor       =   &H80000008&
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'Z ｵｰﾀﾞｰ
   ScaleHeight     =   5400
   ScaleWidth      =   7500
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   45
      TabIndex        =   6
      Top             =   915
      Width           =   7440
      _ExtentX        =   13123
      _ExtentY        =   661
      BackColor       =   12632256
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Alignment       =   1
      BevelOuter      =   1
      Caption         =   "倉庫ｺｰﾄﾞ  倉庫名                   場所"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin VB.ListBox LST 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   3630
      ItemData        =   "WLS_SOU.frx":0000
      Left            =   45
      List            =   "WLS_SOU.frx":0007
      TabIndex        =   1
      Top             =   1275
      Width           =   7440
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   2813
      TabIndex        =   2
      Top             =   4950
      Width           =   915
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   3758
      TabIndex        =   3
      Top             =   4950
      Width           =   915
   End
   Begin Threed5.SSPanel5 Panel3D1 
      Height          =   615
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   10875
      _ExtentX        =   19182
      _ExtentY        =   1085
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
      Begin VB.TextBox HD_NAME 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   4  '全角ひらがな
         Left            =   2685
         MaxLength       =   20
         TabIndex        =   7
         Text            =   "MMMMMMMMM1MMMMMMMMM2"
         Top             =   90
         Width           =   2565
      End
      Begin VB.TextBox HD_CODE 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   1170
         MaxLength       =   3
         TabIndex        =   4
         Text            =   "XX3"
         Top             =   90
         Width           =   525
      End
      Begin Threed5.SSPanel5 Panel3D4 
         Height          =   375
         Left            =   90
         TabIndex        =   5
         Top             =   90
         Width           =   1095
         _ExtentX        =   1931
         _ExtentY        =   661
         BackColor       =   12632256
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "開始ｺｰﾄﾞ"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 SSPanel51 
         Height          =   375
         Left            =   1755
         TabIndex        =   8
         Top             =   90
         Width           =   945
         _ExtentX        =   1667
         _ExtentY        =   661
         BackColor       =   12632256
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ ゴシック"
            Size            =   12
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Caption         =   "倉庫名"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   3825
      Picture         =   "WLS_SOU.frx":0044
      Top             =   6165
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   4725
      Picture         =   "WLS_SOU.frx":0696
      Top             =   6165
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   5130
      Picture         =   "WLS_SOU.frx":0CE8
      Top             =   6165
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   4230
      Picture         =   "WLS_SOU.frx":133A
      Top             =   6165
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   2288
      Picture         =   "WLS_SOU.frx":198C
      Top             =   4950
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   4853
      Picture         =   "WLS_SOU.frx":1FDE
      Top             =   4950
      Width           =   360
   End
End
Attribute VB_Name = "WLSSOU"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
    '********************************************************************************
    '*  システム名　　　：  新総合情報システム
    '*  サブシステム名　：　販売システム
    '*  機能　　　　　　：　検索ウィンドウ
    '*  プログラム名　　：　倉庫検索
    '*  プログラムＩＤ　：  WLSSOU
    '*  作成者　　　　　：　ACE)長澤
    '*  作成日　　　　　：  2006.05.15
    '*-------------------------------------------------------------------------------
    '*<01> YYYY.MM.DD　：　修正情報
    '*     修正者
    '********************************************************************************
    
'************************************************************************************
'   構造体
'************************************************************************************
    Private Type TYPE_DB_SOUMTA_W
        WK_DB_SOUMTA        As TYPE_DB_SOUMTA
        TOKRN               As String               '取引先名
' === 20060828 === INSERT S - ACE)Nagasawa
        BASYO               As String               '場所名
' === 20060828 === INSERT E -
    End Type
'************************************************************************************
'   Public変数
'************************************************************************************
    '戻り値
    
'************************************************************************************
'   Private定数
'************************************************************************************
    
    Private Const WM_WLSKEY_ZOKUSEI = "0"       '開始コード入力属性 [0,X]

'************************************************************************************
'   Private変数
'************************************************************************************
    'ウィンドﾕｰｻﾞｰ設定変数
    Private WM_WLS_MFIL         As Integer          'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Private WM_WLS_CODELEN      As Integer          '開始ｺｰﾄﾞ入力文字数
    Private WM_WLS_NAMELEN      As Integer          '倉庫名入力文字数

    'ウィンド内部使用変数
    Private WM_WLS_MAX          As Integer          '１画面の表示件数
    Private WM_WLS_CODE         As String           '倉庫コード検索用
    Private WM_WLS_SOUNM        As String           '倉庫名検索用
    Private WM_WLS_Pagecnt      As Integer          'ウィンド表示ページカウンタ
    Private WM_WLS_LastPage     As Integer          'ウィンド最終ページ
    Private WM_WLS_LastFL       As Boolean          'ウィンド最終データ到達フラグ
    Private WM_WLS_DSPArray()   As String           'ウィンド表示データ
    Private WM_WLS_Dspflg       As Integer          'ウィンド表示ﾌﾗｸﾞ(True or False)

    Private DblClickFl As Boolean
    
    Private Usr_Ody             As U_Ody            'ﾃﾞｰﾀﾍﾞｰｽ情報ﾃｰﾌﾞﾙ
    Private DB_SOUMTA_W As TYPE_DB_SOUMTA_W
    Private Dyn_Open            As Boolean          'ダイナセット状態（True:Open False:Close)
    
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_FORM_INIT
    '   概要：  画面初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Private Sub WLS_FORM_INIT()
        WM_WLS_CODELEN = 3
        WM_WLS_NAMELEN = 20
        
        WM_WLS_MAX = 15                 '画面表示件数
        '変数初期化
        WLSSOU_RTNCODE = ""
        Call WLS_Clear
        Dyn_Open = False

    End Sub


    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_SetArray
    '   概要：  リスト編集
    '   引数：　ArrayCnt : リスト編集対象INDEX
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+

    Private Sub WLS_SetArray(ByVal ArrayCnt As Integer)
    
        Dim WK_SHUBETU          As String   '種別
        Dim WK_SHISAN           As String   '資産元
        
' === 20060828 === UPDATE S - ACE)Nagasawa
'        '種別編集
'        Select Case DB_SOUMTA_W.WK_DB_SOUMTA.SOUKB
'            Case "1"
'                WK_SHUBETU = "論理"
'            Case "2"
'                WK_SHUBETU = "物理"
'            Case Else
'                WK_SHUBETU = ""
'        End Select
'
'        '資産元編集
'        Select Case DB_SOUMTA_W.WK_DB_SOUMTA.SISNKB
'            Case "0"
'                WK_SHISAN = "自社"
'            Case "1"
'                WK_SHISAN = "他社"
'            Case Else
'                WK_SHISAN = ""
'        End Select
'
'        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(DB_SOUMTA_W.WK_DB_SOUMTA.SOUCD, WM_WLS_CODELEN) & "       " & _
'                                    LeftWid$(DB_SOUMTA_W.WK_DB_SOUMTA.SOUNM, WM_WLS_NAMELEN) & "  " & _
'                                    WK_SHUBETU & "  " & _
'                                    WK_SHISAN & "    " & _
'                                    LeftWid$(DB_SOUMTA_W.TOKRN, 40)
                                    
        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(DB_SOUMTA_W.WK_DB_SOUMTA.SOUCD, WM_WLS_CODELEN) & "       " & _
                                    LeftWid$(DB_SOUMTA_W.WK_DB_SOUMTA.SOUNM, WM_WLS_NAMELEN) & "     " & _
                                    LeftWid$(DB_SOUMTA_W.BASYO, 20)
' === 20060828 === UPDATE E -
        
                                    
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_TextSQL
    '   概要：  検索sql作成
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub WLS_TextSQL()

        Dim strSQL          As String
        Dim intData         As Integer

        strSQL = ""
' === 20060828 === UPDATE S - ACE)Nagasawa
'        strSQL = strSQL & " Select SOUCD "          '倉庫コード
'        strSQL = strSQL & "      , SOUNM "          '倉庫名
'        strSQL = strSQL & "      , SOUKB "          '倉庫種別
'        strSQL = strSQL & "      , SISNKB "         '資産元区分
'        strSQL = strSQL & "      , SOUTRICD "       '取引先コード
'        strSQL = strSQL & "      , TOKRN "          '得意先略称
'        strSQL = strSQL & "   from SOUMTA, TOKMTA "
'' === 20060814 === UPDATE S - ACE)Nagasawa
''        strSQL = strSQL & "  Where SOUMTA.DATKB = '1' "
'        strSQL = strSQL & "  Where SOUMTA.DATKB = '" & gc_strDATKB_USE & "' "
'' === 20060814 === UPDATE E -
'        strSQL = strSQL & "    and SOUMTA.SOUTRICD = TOKMTA.TOKCD (+) "
        
        strSQL = strSQL & " Select SOUCD "              '倉庫コード
        strSQL = strSQL & "      , SOUNM "              '倉庫名
        strSQL = strSQL & "      , MEINMA AS BASYO "    '場所名
        strSQL = strSQL & "   from SOUMTA, MEIMTA "
        strSQL = strSQL & "  Where SOUMTA.DATKB     = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and MEIMTA.DATKB (+) = '" & gc_strDATKB_USE & "' "
        strSQL = strSQL & "    and MEIMTA.KEYCD (+) = '" & gc_strKEYCD_BSCD & "' "
        strSQL = strSQL & "    and SOUMTA.SOUBSCD   = MEIMTA.MEICDA (+) "
' === 20060828 === UPDATE E -

        '倉庫コード検索
        If Trim(WM_WLS_CODE) <> "" Then
' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
'            strSQL = strSQL & "    and SOUCD >=   '" & WM_WLS_CODE & "'"
            strSQL = strSQL & "    and SOUCD >=   '" & CF_Ora_String(WM_WLS_CODE, CF_Ctr_AnsiLenB(WM_WLS_CODE)) & "'"
' === 20080929 === UPDATE E -
        End If

        '倉庫名検索(あいまい検索)
        If Trim(WM_WLS_SOUNM) <> "" Then
' === 20080929 === UPDATE S - ACE)Nagasawa シングルクォーテーション対応
'            strSQL = strSQL & "    and SOUNM LIKE '%" & WM_WLS_SOUNM & "%'"
            strSQL = strSQL & "    and SOUNM LIKE '%" & CF_Ora_String(WM_WLS_SOUNM, CF_Ctr_AnsiLenB(WM_WLS_SOUNM)) & "%'"
' === 20080929 === UPDATE E -
        End If

        'ソート条件
        strSQL = strSQL & "   order by "
        strSQL = strSQL & "   SOUCD "
        
        If Dyn_Open = True Then
            'クローズ
            Call CF_Ora_CloseDyn(Usr_Ody)
            Dyn_Open = False
        End If
        
        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dyn_Open = True
' === 20060728 === INSERT S - ACE)Furukawa
        LST.Clear
' === 20060728 === INSERT E
        
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_DspNew
    '   概要：  リスト編集処理
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Private Sub WLS_DspNew()
    Dim Cnt             As Long
    
    Cnt = 0
    Do Until CF_Ora_EOF(Usr_Ody) = True
        
        '取得内容退避
        DB_SOUMTA_W.WK_DB_SOUMTA.SOUCD = CF_Ora_GetDyn(Usr_Ody, "SOUCD", "")            '倉庫コード
        DB_SOUMTA_W.WK_DB_SOUMTA.SOUNM = CF_Ora_GetDyn(Usr_Ody, "SOUNM", "")            '倉庫名
' === 20060828 === UPDATE S - ACE)Nagasawa
'        DB_SOUMTA_W.WK_DB_SOUMTA.SOUKB = CF_Ora_GetDyn(Usr_Ody, "SOUKB", "")            '倉庫種別
'        DB_SOUMTA_W.WK_DB_SOUMTA.SISNKB = CF_Ora_GetDyn(Usr_Ody, "SISNKB", "")          '資産元区分
'        DB_SOUMTA_W.WK_DB_SOUMTA.SOUTRICD = CF_Ora_GetDyn(Usr_Ody, "SOUTRICD", "")      '取引先コード
'        DB_SOUMTA_W.TOKRN = CF_Ora_GetDyn(Usr_Ody, "TOKRN", "")                         '得意先略称
        DB_SOUMTA_W.BASYO = CF_Ora_GetDyn(Usr_Ody, "BASYO", "")                         '場所名
' === 20060828 === UPDATE E -
        
        '表示改ページ
        If Cnt Mod WM_WLS_MAX = 0 Then
            WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
            ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
            Cnt = 0
            '最終ページ退避
            WM_WLS_LastPage = WM_WLS_Pagecnt
        End If
    
        '表示メモリ展開
        Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + Cnt)
        
        Cnt = Cnt + 1
        
        Call CF_Ora_MoveNext(Usr_Ody)
        
        If Cnt >= WM_WLS_MAX Then
            Exit Do
        End If
    Loop
    
    '最終データ到達
    If CF_Ora_EOF(Usr_Ody) = True Then
        WM_WLS_LastFL = True
    End If
    
    If Cnt > 0 Then
        'ページを表示
        Call WLS_DspPage
    End If

End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_DspPage
    '   概要：  リスト編集処理
    '   引数：　なし
    '   戻値：　なし
    '   備考：
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
' === 20061228 === INSERT S - ACE)Nagasawa
                        On Error Resume Next
' === 20061228 === INSERT E -
            LST.SetFocus
        End If
    End Sub

    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Sub WLS_Clear
    '   概要：  変数初期化
    '   引数：　なし
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Sub WLS_Clear()

        '検索条件
        WM_WLS_CODE = ""
        WM_WLS_SOUNM = ""

        '画面表示ページ
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False

        '検索結果保持配列
        ReDim WM_WLS_DSPArray(0)

    End Sub
'
'以下は画面イベント処理
'
    Private Sub Form_Activate()

        'WINDOW 位置設定
        Left = (Screen.Width - Width) / 2
        Top = (Screen.Height - Height) / 2

        WM_WLS_Dspflg = False

        '項目初期化
        HD_CODE.Text = ""
        HD_NAME.Text = ""
        LST.Clear
        WM_WLS_Dspflg = True

        ReDim WM_WLS_DSPArray(0)
        
        '初期状態全件表示
        Call WLS_TextSQL
        Call WLS_DspNew
        
        DblClickFl = False
        
        Me.Refresh
' === 20060821 === UPDATE S - ACE)Nagasawa
'        HD_CODE.SetFocus
' === 20061228 === INSERT S - ACE)Nagasawa
                On Error Resume Next
' === 20061228 === INSERT E -
        LST.SetFocus
' === 20060821 === UPDATE E -
    End Sub

Private Sub Form_Load()
    'Window初期設定
    Call WLS_FORM_INIT
End Sub

Private Sub HD_CODE_GotFocus()
    If LenWid(HD_CODE.Text) > 0 Then
        HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.MaxLength, WM_WLSKEY_ZOKUSEI)
'---------- 20061019 ACE MENTE START ----------
'   Else
'       HD_CODE.Text = Space$(HD_CODE.MaxLength)
'---------- 20061019 ACE MENTE E N D ----------
    End If
    HD_CODE.SelStart = 0
    HD_CODE.SelLength = HD_CODE.MaxLength
End Sub

Private Sub HD_CODE_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = vbKeyReturn Then
        WM_WLS_Dspflg = False
        HD_CODE.Text = SSS_EDTITM_WLS(HD_CODE.Text, HD_CODE.MaxLength, WM_WLSKEY_ZOKUSEI)

        '検索用変数セット
        Call WLS_Clear
        WM_WLS_CODE = HD_CODE.Text

        '他検索条件クリア
        HD_NAME.Text = ""
        WM_WLS_Dspflg = True

        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

Private Sub HD_NAME_GotFocus()
'---------- 20061019 ACE MENTE START ----------
'   If LenWid(HD_NAME.Text) <= 0 Then
'       HD_NAME.Text = Space$(HD_NAME.MaxLength)
'   End If
'---------- 20061019 ACE MENTE E N D ----------
    HD_NAME.SelStart = 0
    HD_NAME.SelLength = HD_NAME.MaxLength
End Sub

Private Sub HD_NAME_KeyDown(KeyCode As Integer, Shift As Integer)
    If KeyCode = vbKeyReturn Then
        WM_WLS_Dspflg = False

        '検索用変数セット
        Call WLS_Clear
        WM_WLS_SOUNM = HD_NAME.Text

        '他検索条件クリア
        HD_CODE.Text = ""
        WM_WLS_Dspflg = True

        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

Private Sub LST_DblClick()

    DblClickFl = True
    WLSSOU_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
    
End Sub

Private Sub LST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)

    If DblClickFl Then Call WLSCANCEL_Click
    
End Sub

Private Sub LST_KeyDown(KeyCode As Integer, Shift As Integer)

    Select Case KeyCode
        'Enterキー押下
        Case vbKeyReturn
            Call WLSOK_Click
            
        'Escapeキー押下
        Case vbKeyEscape
            Call WLSCANCEL_Click
        
        '←キー押下
        Case vbKeyLeft
            Call WLSMAE_Click
            
        '→キー押下
        Case vbKeyRight
            Call WLSATO_Click
            If LST.ListCount > 0 Then
                LST.ListIndex = -1
            End If
    End Select
    
End Sub

Private Sub WLSATO_Click()

    If LST.ListCount <= 0 Then Exit Sub

' === 20060728 === DELETE S - ACE)Furukawa
'    Call WLS_DspNew
' === 20060728 === DELETE E

    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
' === 20060728 === UPDATE S - ACE)Furukawa
'D        If Not WM_WLS_LastFL Then Call WLS_DspPage
' === 20060728 === UPDATE ↓
        If Not WM_WLS_LastFL Then Call WLS_DspNew
' === 20060728 === UPDATE E
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
    WLSSOU_RTNCODE = LeftWid$(LST.List(LST.ListIndex), WM_WLS_CODELEN)
    Call WLSCANCEL_Click
End Sub

Private Sub WLSCANCEL_Click()

    If Dyn_Open = True Then
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody)
        Dyn_Open = False
    End If
        
    Hide
End Sub


