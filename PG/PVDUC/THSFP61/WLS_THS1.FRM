VERSION 5.00
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form WLS_THS1 
   Appearance      =   0  'ﾌﾗｯﾄ
   BackColor       =   &H00C0C0C0&
   BorderStyle     =   3  '固定ﾀﾞｲｱﾛｸﾞ
   Caption         =   "取引先検索"
   ClientHeight    =   5520
   ClientLeft      =   2760
   ClientTop       =   2370
   ClientWidth     =   11610
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
   ScaleHeight     =   5520
   ScaleWidth      =   11610
   Begin Threed5.SSPanel5 WLSLABEL 
      Height          =   375
      Left            =   45
      TabIndex        =   9
      Top             =   1200
      Width           =   11325
      _ExtentX        =   19976
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
      Caption         =   "WLSLABEL"
      OutLine         =   -1  'True
      RoundedCorners  =   0   'False
   End
   Begin VB.ListBox LST 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   3150
      Left            =   45
      TabIndex        =   0
      Top             =   1560
      Width           =   11325
   End
   Begin VB.CommandButton WLSOK 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "OK"
      Height          =   330
      Left            =   4140
      TabIndex        =   5
      Top             =   4980
      Width           =   915
   End
   Begin VB.CommandButton WLSCANCEL 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      Caption         =   "ｷｬﾝｾﾙ"
      Height          =   330
      Left            =   5085
      TabIndex        =   6
      Top             =   4980
      Width           =   915
   End
   Begin Threed5.SSPanel5 Panel3D1 
      Height          =   1155
      Left            =   0
      TabIndex        =   7
      Top             =   0
      Width           =   11325
      _ExtentX        =   19976
      _ExtentY        =   2037
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
      Begin VB.TextBox HD_BUNRUI 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   2160
         MaxLength       =   1
         TabIndex        =   1
         Text            =   "X"
         Top             =   120
         Width           =   285
      End
      Begin VB.ComboBox WLSKANA 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   360
         Left            =   10005
         Style           =   2  'ﾄﾞﾛｯﾌﾟﾀﾞｳﾝ ﾘｽﾄ
         TabIndex        =   4
         Top             =   600
         Width           =   1230
      End
      Begin VB.TextBox HD_Kana 
         Height          =   375
         IMEMode         =   6  '半角ｶﾀｶﾅ
         Left            =   9405
         TabIndex        =   11
         Text            =   "ｱｲｳｴｵ"
         Top             =   600
         Visible         =   0   'False
         Width           =   690
      End
      Begin VB.TextBox HD_RN 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   4320
         MaxLength       =   40
         TabIndex        =   3
         Text            =   "MMMMMMMMM1MMMMMMMMM2MMMMMMMMM3MMMMMMMMM4"
         Top             =   600
         Width           =   4020
      End
      Begin VB.TextBox HD_TEXT 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   375
         IMEMode         =   2  'ｵﾌ
         Left            =   1200
         MaxLength       =   13
         TabIndex        =   2
         Text            =   "XXXXX"
         Top             =   600
         Width           =   1005
      End
      Begin Threed5.SSPanel5 Panel3D4 
         Height          =   375
         Left            =   90
         TabIndex        =   8
         Top             =   600
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
         Left            =   2640
         TabIndex        =   10
         Top             =   600
         Width           =   1695
         _ExtentX        =   2990
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
         Caption         =   "得意先略称"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 PNL_USENM 
         Height          =   375
         Index           =   3
         Left            =   8760
         TabIndex        =   12
         Top             =   600
         Width           =   1230
         _ExtentX        =   2170
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
         Caption         =   "カナ検索"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 SSPanel52 
         Height          =   375
         Index           =   0
         Left            =   120
         TabIndex        =   13
         Top             =   120
         Width           =   2085
         _ExtentX        =   3678
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
         Caption         =   "*取引先分類"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
      Begin Threed5.SSPanel5 SSPanel52 
         Height          =   375
         Index           =   1
         Left            =   2430
         TabIndex        =   14
         Top             =   120
         Width           =   4125
         _ExtentX        =   7276
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
         Caption         =   "1:得意先 2:仕入先"
         OutLine         =   -1  'True
         RoundedCorners  =   0   'False
      End
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   3825
      Picture         =   "WLS_THS1.frx":0000
      Top             =   6120
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   0
      Left            =   4725
      Picture         =   "WLS_THS1.frx":0652
      Top             =   6120
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_ATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   5130
      Picture         =   "WLS_THS1.frx":0CA4
      Top             =   6120
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image IM_MAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Index           =   1
      Left            =   4230
      Picture         =   "WLS_THS1.frx":12F6
      Top             =   6120
      Visible         =   0   'False
      Width           =   360
   End
   Begin VB.Image WLSMAE 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   3645
      Picture         =   "WLS_THS1.frx":1948
      Top             =   4980
      Width           =   360
   End
   Begin VB.Image WLSATO 
      Appearance      =   0  'ﾌﾗｯﾄ
      Height          =   330
      Left            =   6120
      Picture         =   "WLS_THS1.frx":1F9A
      Top             =   4980
      Width           =   360
   End
End
Attribute VB_Name = "WLS_THS1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
    '以下の ３行の設定を行うこと
    Const WM_WLS_MSTKB = "1"            'マスタ区分（1:得意先 2:納品先 3:担当者 4:仕入先 5:商品 "":分類なし）
    Const WM_WLSKEY_ZOKUSEI = "X"       '開始コード入力属性 [0,X]
    Const WM_WLS_KanaINPUT = False      'カナ直接入力使用（True:直接入力 False:カナコンボ）

    '検索キーNo（使用しない場合は-1を設定）
    Const WM_WLS_TextKey = 1            '開始コードのソートキーNo
    Const WM_WLS_KanaKey = 2            'カナ検索のソートキーNo+第一キー
    Const WM_WLS_RNKey = 3              '得意先略称検索のソートキーNo+第一キー

    'ウィンドﾕｰｻﾞｰ設定変数
    Dim WM_WLS_MFIL As Integer          'ウィンド表示ﾒｲﾝﾌｧｲﾙ
    Dim WM_WLS_LEN As Integer           '開始ｺｰﾄﾞ入力文字数
    Dim WM_WLS_KANALEN As Integer       'カナ入力文字数
    Dim WM_WLS_RNLEN As Integer         '得意先略称入力文字数
    
    Dim WM_WLS_MM1 As Integer       'ウィンド表示ﾌｧｲﾙ1
    Dim WM_WLS_MM2 As Integer       'ウィンド表示ﾌｧｲﾙ2
    
    'ウィンド内部使用変数
    Dim WM_WLS_MAX As Integer           '１画面の表示件数
    Dim WM_WLS_STTKEY                   '開始キー
    Dim WM_WLS_ENDKEY                   '終了キー
    Dim WM_WLS_KeyNo As Integer         'ﾒｲﾝﾌｧｲﾙ読み込みキーNo
    Dim WM_WLS_Pagecnt As Integer       'ウィンド表示ページカウンタ
    Dim WM_WLS_LastPage As Integer      'ウィンド最終ページ
    Dim WM_WLS_LastFL As Boolean        'ウィンド最終データ到達フラグ
    Dim WM_WLS_DSPArray() As String     'ウィンド表示データ
    Dim WM_WLS_Dspflg As Integer        'ウィンド表示ﾌﾗｸﾞ(True or False)

    Dim WlsSelList$
    
    Dim WlsSelList1$
    Dim WlsSelList2$
    Dim WlsHint$
    Dim WlsOrderBy$
    Dim WlsFromWhere$
    
        

    Dim DblClickFl As Boolean  'DblClickイベント障害対応  97/04/07

Private Sub WLS_FORM_INIT()
    '=== WINDOW 表示ファイル設定 ===
    WM_WLS_MFIL = DBN_TOKMTA
    
    WM_WLS_MM1 = DBN_TOKMTA
    WM_WLS_MM2 = DBN_SIRMTA
    
    HD_BUNRUI = "1"
    

    '=== 表示開始コード桁数設定 ===
    WM_WLS_LEN = Len(DB_TOKMTA.TOKCD)     'LenWid はダメ
    WM_WLS_KANALEN = Len(DB_TOKMTA.TOKNK) 'LenWid はダメ
    WM_WLS_RNLEN = Len(DB_TOKMTA.TOKRN)   'LenWid はダメ
    WlsSelList = "TOKNMA, TOKNMB, DATKB, TOKZEIKB, TOKSMEKB, TOKSMEDD, TOKKESCC, TOKKESDD, TOKNK, TOKKDWKB, TOKCD, TOKRN, TOKTL, TOKSEICD"

  WlsSelList1 = "TOKNMA, TOKNMB, DATKB, TOKZEIKB, TOKSMEKB, TOKSMEDD, TOKKESCC, TOKKESDD, TOKNK, TOKKDWKB, TOKCD, TOKRN, TOKTL, TOKSEICD"
  WlsSelList2 = "SIRNMA, SIRNMB, DATKB, SIRZEIKB, SIRSMEKB, SIRSMEDD, SIRKESCC, SIRKESDD, SIRNK, SIRSDWKB, SIRCD, SIRRN, SIRTL, SIRSHACD"


    '=== ＬＡＢＥＬ設定 ===
'    WLSLABEL = "ｺｰﾄﾞ  得意先名                 　　　  締  日  　回収条件     税区  　電話番号      請求先"
               '12345 123456789012345678901234567890 1234567890 1234567890123 123456  1234567890123 12345
     WLSLABEL = "ｺｰﾄﾞ  取引先名                 　　　  締  日   　税区  　電話番号     "
   '=== WINDOW 画面サイズ設定 ===
    'Me.Width = LenWid(WLSLABEL) + 200?
     Me.Width = 11490
    WM_WLS_MAX = CInt((LST.Height - 15) / 240)
    'HD_TEXT.Height = 330
    HD_TEXT.MaxLength = WM_WLS_LEN
    HD_TEXT.Width = (WM_WLS_LEN + 1) * 120

End Sub

Private Function WLS_DSP_CHECK()
    If DB_TOKMTA.DATKB = "9" Then
        WLS_DSP_CHECK = SSS_NEXT
    Else
        WLS_DSP_CHECK = SSS_OK
    End If
End Function

Private Sub WLS_SetArray(ByVal ArrayCnt%)
    '====================================
    '   WINDOW 明細設定
    '====================================

    Dim WK_KESNM As String, WK_ZEINM As String, WK_TK As String * 13, WK_SMENM As String
    Dim WK_KESDD As String
    
 If HD_BUNRUI <> "2" Then
    '
    Select Case SSSVal(DB_TOKMTA.TOKZEIKB)
        Case 1
            WK_ZEINM = " 税抜 "
        Case 2
            WK_ZEINM = " 税込 "
        Case 9
            WK_ZEINM = "非課税"
    End Select
    '
    Select Case SSSVal(DB_TOKMTA.TOKSMEKB)
        Case 1
            WK_SMENM = "  " & DB_TOKMTA.TOKSMEDD & "日締 "
            Select Case SSSVal(DB_TOKMTA.TOKKESCC)
                Case 0
                    WK_KESNM = "  当月"
                Case 1
                    WK_KESNM = "  翌月"
                Case 2
                    WK_KESNM = "翌々月"
                Case Else
                    WK_KESNM = "その他"
            End Select
            WK_KESNM = WK_KESNM & DB_TOKMTA.TOKKESDD & "日回収"
        Case 2
            WK_SMENM = SSS_WEEKNM(SSSVal(DB_TOKMTA.TOKSDWKB)) & "締     " & SSS_WEEKNM(SSSVal(DB_TOKMTA.TOKKDWKB)) & "回収"
    End Select
    '
    '   WM_WLS_DSPArray(ArrayCnt) = LeftWid$(Right(Trim$(DB_TOKMTA.TOKCD), 5), 5) & " " & LeftWid$(DB_TOKMTA.TOKRN, 30) & " " & LeftWid$((WK_SMENM), 10) & " " & LeftWid$((WK_KESNM), 12) & "  " & LeftWid$((WK_ZEINM), 6) & " " & LeftWid$((DB_TOKMTA.TOKTL), 13) & "   " & RightWid$((DB_TOKMTA.TOKSEICD), 5)
        WM_WLS_DSPArray(ArrayCnt) = LeftWid$(Left(Trim$(DB_TOKMTA.TOKCD) & "     ", 5), 5) & " " & LeftWid$(DB_TOKMTA.TOKRN, 30) & " " & LeftWid$((WK_SMENM), 10) & " " & "  " & LeftWid$((WK_ZEINM), 6) & " " & LeftWid$((DB_TOKMTA.TOKTL), 13)
 End If

 If HD_BUNRUI = "2" Then
    '
    Select Case SSSVal(DB_SIRMTA.SIRZEIKB)
        Case 1
            WK_ZEINM = " 税抜 "
        Case 2
            WK_ZEINM = " 税込 "
        Case 9
            WK_ZEINM = "非課税"
    End Select
    '
    Select Case SSSVal(DB_SIRMTA.SIRSMEKB)
        Case 1
            WK_SMENM = "  " & DB_SIRMTA.SIRSMEDD & "日締 "
            Select Case SSSVal(DB_SIRMTA.SIRKESCC)
                Case 0
                    WK_KESNM = "  当月"
                Case 1
                    WK_KESNM = "  翌月"
                Case 2
                    WK_KESNM = "翌々月"
                Case Else
                    WK_KESNM = "その他"
            End Select
            WK_KESNM = WK_KESNM & DB_SIRMTA.SIRKESDD & "日回収"
        Case 2
            WK_SMENM = SSS_WEEKNM(SSSVal(DB_SIRMTA.SIRSDWKB)) & "締     " & SSS_WEEKNM(SSSVal(DB_SIRMTA.SIRSDWKB)) & "回収"
    End Select
    '
    WM_WLS_DSPArray(ArrayCnt) = LeftWid$(Left(Trim$(DB_SIRMTA.SIRCD) & "     ", 5), 5) & " " & LeftWid$(DB_SIRMTA.SIRRN, 30) & " " & LeftWid$((WK_SMENM), 10) & " " & "  " & LeftWid$((WK_ZEINM), 6) & " " & LeftWid$((DB_SIRMTA.SIRTL), 13)
End If

End Sub

Sub WLS_TextSQL()
 Dim wkaa As String
 
    WM_WLS_KeyNo = WM_WLS_TextKey
    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
    
    If HD_BUNRUI = "1" Then
        WM_WLS_MFIL = WM_WLS_MM1
        WlsSelList = WlsSelList1
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'        WlsFromWhere = "From TOKMTA Where TOKCD >= '" & WM_WLS_STTKEY & "'"
        WlsFromWhere = "From TOKMTA Where TOKCD >= '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
        WlsOrderBy = "Order By TOKCD"
    End If
    
    If HD_BUNRUI = "2" Then
        WM_WLS_MFIL = WM_WLS_MM2
        WlsSelList = WlsSelList2
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'        WlsFromWhere = "From SIRMTA Where SIRCD >= '" & WM_WLS_STTKEY & "'"
        WlsFromWhere = "From SIRMTA Where SIRCD >= '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
        WlsOrderBy = "Order By SIRCD"
    End If
       
    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    
'''' DEL 2014/12/03  RS) Y.Ishida  Start  C2プロジェクト
'    If HD_BUNRUI = "3" Then
'        WM_WLS_MFIL = WM_WLS_MM1
'        WlsSelList = WlsSelList1
''''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'        WlsFromWhere = "From TOKMTA Where TOKCD >= '" & WM_WLS_STTKEY & "'"
'        WlsFromWhere = "From TOKMTA Where TOKCD >= '" & AE_EditSQLText(WM_WLS_STTKEY) & "'"
''''' UPD 2009/12/03  FKS) T.Yamamoto    End
'        WlsOrderBy = "Order By TOKCD"
'
'        wkaa = "Select " & WlsSelList & " " & WlsFromWhere & " and exists "
'
'        DB_SQLBUFF = wkaa & "( Select * from sirmta where tokcd = sircd )"
'
'    End If
'''' DEL 2014/12/03  RS) Y.Ishida  End
    
    Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
    
End Sub

Sub WLS_KanaSQL()
    WM_WLS_KeyNo = WM_WLS_KanaKey
    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
    
    If HD_BUNRUI <> "2" Then
       WM_WLS_MFIL = WM_WLS_MM1
       WlsSelList = WlsSelList1
       WlsFromWhere = "From TOKMTA Where TOKNK >= '" & WM_WLS_STTKEY & "' And TOKNK < '" & WM_WLS_ENDKEY & "'"
       WlsOrderBy = "Order By TOKNK, TOKCD"
    End If
    If HD_BUNRUI = "2" Then
       WM_WLS_MFIL = WM_WLS_MM2
       WlsSelList = WlsSelList2
       WlsFromWhere = "From SIRMTA Where SIRNK >= '" & WM_WLS_STTKEY & "' And SIRNK < '" & WM_WLS_ENDKEY & "'"
       WlsOrderBy = "Order By SIRNK, SIRCD"
    End If
    
    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
End Sub

Sub WLS_RnSQL()
    WM_WLS_KeyNo = WM_WLS_RNKey
    ''Oracleは, 空文字列 "" を Nullと解釈するため, 空白 " " に置き換える
    If WM_WLS_STTKEY = "" Then WM_WLS_STTKEY = " "
    
    If HD_BUNRUI <> "2" Then
       WM_WLS_MFIL = WM_WLS_MM1
       WlsSelList = WlsSelList1
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'       WlsFromWhere = "From TOKMTA Where TOKRN Like " & "'%" & WM_WLS_STTKEY & "%'"
       WlsFromWhere = "From TOKMTA Where TOKRN Like " & "'%" & AE_EditSQLText(WM_WLS_STTKEY) & "%'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
       WlsOrderBy = "Order By TOKRN, TOKCD"
    End If
    If HD_BUNRUI = "2" Then
       WM_WLS_MFIL = WM_WLS_MM2
       WlsSelList = WlsSelList2
'''' UPD 2009/12/03  FKS) T.Yamamoto    Start    連絡票№661「'」対応修正
'       WlsFromWhere = "From SIRMTA Where SIRRN Like " & "'%" & WM_WLS_STTKEY & "%'"
       WlsFromWhere = "From SIRMTA Where SIRRN Like " & "'%" & AE_EditSQLText(WM_WLS_STTKEY) & "%'"
'''' UPD 2009/12/03  FKS) T.Yamamoto    End
       WlsOrderBy = "Order By SIRRN, SIRCD"
    End If
    
    DB_SQLBUFF = "Select " & WlsSelList & " " & WlsFromWhere & " " & WlsOrderBy
    Call DB_GetSQL2(WM_WLS_MFIL, DB_SQLBUFF)
End Sub

Private Sub WLS_DspNew()
    Dim WL_Mode As Integer
Dim cnt%

    WL_Mode = 0
    cnt = 0
    Do While (DBSTAT = 0) And (cnt < WM_WLS_MAX) And (WL_Mode <> SSS_END)
        WL_Mode = WLS_DSP_CHECK()
        If WL_Mode = SSS_OK Then
            If cnt = 0 Then
                WM_WLS_Pagecnt = WM_WLS_Pagecnt + 1
                WM_WLS_LastPage = WM_WLS_Pagecnt
                ReDim Preserve WM_WLS_DSPArray((WM_WLS_Pagecnt + 1) * WM_WLS_MAX)
            End If
            Call WLS_SetArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
            cnt = cnt + 1
        End If
        If (WL_Mode = SSS_OK) Or (WL_Mode = SSS_NEXT) Then
            Call DB_GetNext(WM_WLS_MFIL, BtrNormal)
        End If
    Loop
    If DBSTAT <> 0 Or WL_Mode = SSS_END Then WM_WLS_LastFL = True
    If cnt > 0 Then
        Call WLS_DspPage
    Else
        LST.Clear
    End If
End Sub

Private Sub WLS_DspPage()
Dim WL_Mode As Integer
Dim cnt%

    LST.Clear
    cnt = 0
    Do While cnt < WM_WLS_MAX
        If Trim(WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)) > "" Then
            LST.AddItem WM_WLS_DSPArray(WM_WLS_Pagecnt * WM_WLS_MAX + cnt)
        End If
        cnt = cnt + 1
    Loop
    If LST.ListCount > 0 Then
        LST.ListIndex = 0
        LST.SetFocus
    End If
End Sub

Sub WLS_Kana_Init()

    'カナ検索 Combo 初期化
    'この一行を実行しないと, WLSKANA.ListIndex = 0 でエラーになる
    WLSKANA.AddItem "コード"

    If WM_WLS_KanaKey < 1 Then
    'カナ検索をしない
        PNL_USENM(3).Visible = False
        WLSKANA.Visible = False
        HD_Kana.Visible = False
    ElseIf WM_WLS_KanaINPUT Then
    'カナ手入力項目の有効化
        WLSKANA.Visible = False
        HD_Kana.Visible = True
        HD_Kana.Width = WLSKANA.Width
        HD_Kana.Left = WLSKANA.Left
    Else
        WLSKANA.AddItem "ア　      ｱｵ"
        WLSKANA.AddItem "カ　      ｶｺ"
        WLSKANA.AddItem "サ　      ｻｿ"
        WLSKANA.AddItem "タ　      ﾀﾄ"
        WLSKANA.AddItem "ナ　      ﾅﾉ"
        WLSKANA.AddItem "ハ　      ﾊﾎ"
        WLSKANA.AddItem "マ　      ﾏﾓ"
        WLSKANA.AddItem "ヤ　      ﾔﾖ"
        WLSKANA.AddItem "ラ　      ﾗﾛ"
        WLSKANA.AddItem "ワ　      ﾜﾝ"
    End If
End Sub

'
'以下は画面イベント処理
'
Private Sub Form_Activate()
    WLSMAE.Left = (WLS_THS1.Width - (WLSMAE.Width + WLSOK.Width + WLSCANCEL.Width + WLSATO.Width + 60)) / 2
    WLSOK.Left = WLSMAE.Left + WLSMAE.Width + 60
    WLSCANCEL.Left = WLSOK.Left + WLSOK.Width + 60
    WLSATO.Left = WLSCANCEL.Left + WLSCANCEL.Width + 60

    '=== WINDOW 位置設定 ===
    Left = (Screen.Width - Width) / 2
    Top = (Screen.Height - Height) / 2

    WM_WLS_STTKEY = ""
    WM_WLS_ENDKEY = Null
    HD_TEXT.Text = ""
    WM_WLS_Dspflg = False
    WLSKANA.ListIndex = 0
    HD_Kana.Text = ""
    'WLSRN.ListIndex = 0
    HD_RN.Text = ""
    WM_WLS_Dspflg = True
    WM_WLS_Pagecnt = -1
    WM_WLS_LastPage = -1
    WM_WLS_LastFL = False
    
  '  WGDENKB = "1"
  WLS_THS1.HD_BUNRUI = WGDENKB
  
    
    ReDim WM_WLS_DSPArray(0)

    Call WLS_TextSQL
    Call WLS_DspNew

    'DblClickイベント障害対応  97/04/07
    DblClickFl = False
End Sub

Private Sub Form_Load()
    'Window初期設定
    Call WLS_FORM_INIT
    Call WLS_Kana_Init
End Sub

Private Sub HD_BUNRUI_GotFocus()
    HD_BUNRUI.SelStart = 0
    HD_BUNRUI.SelLength = LenWid(HD_BUNRUI.Text)
End Sub

Private Sub HD_BUNRUI_KeyDown(KEYCODE As Integer, Shift As Integer)
If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = False
        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
        WM_WLS_STTKEY = HD_TEXT.Text
        WM_WLS_ENDKEY = Null
        WLSKANA.ListIndex = 0
        HD_Kana.Text = ""
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)
        
        WGDENKB = HD_BUNRUI

        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

Private Sub HD_BUNRUI_LostFocus()
'''' UPD 2014/12/03  RS) Y.Ishida  Start  C2プロジェクト
'   If HD_BUNRUI <> "1" And HD_BUNRUI <> "2" And HD_BUNRUI <> "3" Then HD_BUNRUI = "1"
   If HD_BUNRUI <> "1" And HD_BUNRUI <> "2" Then HD_BUNRUI = "1"
'''' UPD 2014/12/03  RS) Y.Ishida  End
End Sub

Private Sub HD_RN_GotFocus()
'''    If LenWid(HD_RN.Text) > 0 Then
'''        HD_RN.Text = SSS_EDTITM_WLS(HD_RN.Text, HD_RN.MaxLength, WM_WLSKEY_ZOKUSEI)
'''    Else
'''        HD_RN.Text = Space$(HD_RN.MaxLength)
'''    End If
    HD_RN.SelStart = 0
    HD_RN.SelLength = HD_RN.MaxLength
End Sub

Private Sub HD_Rn_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = False
        HD_TEXT.Text = ""
        WM_WLS_STTKEY = HD_RN.Text
        WM_WLS_ENDKEY = HD_RN.Text
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        Call WLS_RnSQL
        Call WLS_DspNew
    End If
End Sub

Private Sub HD_Kana_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = False
        HD_TEXT.Text = ""
        WM_WLS_STTKEY = HD_Kana.Text
        WM_WLS_ENDKEY = Chr$(Asc("ﾝ") + 1)
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        Call WLS_KanaSQL
        Call WLS_DspNew
    End If
End Sub

Private Sub HD_Kana_KeyPress(KeyAscii As Integer)
    If KeyAscii < Asc(" ") Then Exit Sub
        ''2000/04/18 カナ入力文字範囲の誤りを修正
        ''If KeyAscii < Asc("ｱ") Or KeyAscii > Asc("ﾝ") Then
        If KeyAscii >= Asc("0") And KeyAscii <= Asc("9") Then Exit Sub
        If KeyAscii < Asc("｡") Or KeyAscii > Asc("ﾟ") Then
        KeyAscii = 0
    End If
End Sub

Private Sub HD_TEXT_GotFocus()
'''    If LenWid(HD_TEXT.Text) > 0 Then
'''        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
'''    Else
'''        HD_TEXT.Text = Space$(HD_TEXT.MaxLength)
'''    End If
    HD_TEXT.SelStart = 0
    HD_TEXT.SelLength = HD_TEXT.MaxLength
End Sub

Private Sub HD_TEXT_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = False
        HD_TEXT.Text = SSS_EDTITM_WLS(HD_TEXT.Text, HD_TEXT.MaxLength, WM_WLSKEY_ZOKUSEI)
        WM_WLS_STTKEY = HD_TEXT.Text
        WM_WLS_ENDKEY = Null
        WLSKANA.ListIndex = 0
        HD_Kana.Text = ""
        WM_WLS_Dspflg = True
        WM_WLS_Pagecnt = -1
        WM_WLS_LastPage = -1
        WM_WLS_LastFL = False
        ReDim WM_WLS_DSPArray(0)

        Call WLS_TextSQL
        Call WLS_DspNew
    End If
End Sub

Private Sub LST_DblClick()
    'DblClickイベント障害対応  97/04/07
    DblClickFl = True
    Call WLS_SLIST_MOVE(LST.List(LST.ListIndex), WM_WLS_LEN)
    WGDENKB = HD_BUNRUI

End Sub

Private Sub LST_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    'UnLoadイベント障害対応  97/04/07
    If DblClickFl Then Call WLSCANCEL_CLICK
End Sub

Private Sub LST_KeyDown(KEYCODE As Integer, Shift As Integer)
    Select Case KEYCODE
        Case vbKeyReturn
            Call WLSOK_Click
        Case vbKeyEscape
            Call WLSCANCEL_CLICK
        Case vbKeyLeft     '←キー
            Call WLSMAE_Click
        Case vbKeyRight    '→キー
            Call WLSATO_Click
            If LST.ListCount > 0 Then
                LST.ListIndex = -1
            End If
    End Select
End Sub

Private Sub WLSKANA_Click()
Dim W_BUF
    If WM_WLS_Dspflg = False Then Exit Sub
    WM_WLS_Dspflg = False
    WM_WLS_Dspflg = True
    WM_WLS_Pagecnt = -1
    WM_WLS_LastPage = -1
    WM_WLS_LastFL = False
    ReDim WM_WLS_DSPArray(0)

    If WLSKANA.ListIndex > 0 Then
        HD_TEXT.Text = ""
        HD_RN.Text = ""
        W_BUF = Right$(WLSKANA.List(WLSKANA.ListIndex), 2)
        WM_WLS_STTKEY = Left$(W_BUF, 1)
        WM_WLS_ENDKEY = Chr$(Asc(Right$(W_BUF, 1)) + 1)
        Call WLS_KanaSQL
    Else
        If HD_RN.Text <> "" Then
            WM_WLS_STTKEY = Format$(HD_RN.Text)
            Call WLS_RnSQL
        Else
            WM_WLS_STTKEY = Format$(HD_TEXT.Text)
            Call WLS_TextSQL
        End If
    End If
    Call WLS_DspNew
End Sub

Private Sub WLSKANA_KeyDown(KEYCODE As Integer, Shift As Integer)
    If KEYCODE = vbKeyReturn Then
        WM_WLS_Dspflg = True
        Call WLSKANA_Click
    Else
        WM_WLS_Dspflg = False
    End If
End Sub

Private Sub WLSATO_Click()

    If LST.ListCount <= 0 Then Exit Sub

    If WM_WLS_Pagecnt >= WM_WLS_LastPage Then
        If Not WM_WLS_LastFL Then Call WLS_DspNew
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
    Call WLS_SLIST_MOVE(LST.List(LST.ListIndex), WM_WLS_LEN)
    Call WLSCANCEL_CLICK
End Sub

Private Sub WLSCANCEL_CLICK()
    'UnLoadイベント障害対応  97/04/07
    'Unload Me
    Hide
End Sub
