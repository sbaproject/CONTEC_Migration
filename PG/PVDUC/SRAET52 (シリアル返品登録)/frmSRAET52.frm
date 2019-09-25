VERSION 5.00
Object = "{B02F3647-766B-11CE-AF28-C3A2FBE76A13}#3.0#0"; "SPR32X30.ocx"
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   BorderStyle     =   1  '固定(実線)
   Caption         =   "シリアル№登録"
   ClientHeight    =   5925
   ClientLeft      =   150
   ClientTop       =   720
   ClientWidth     =   5625
   Icon            =   "frmSRAET52.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5925
   ScaleWidth      =   5625
   StartUpPosition =   3  'Windows の既定値
   Begin VB.TextBox txtDummy 
      Appearance      =   0  'ﾌﾗｯﾄ
      BorderStyle     =   0  'なし
      Height          =   270
      Left            =   4080
      TabIndex        =   14
      Top             =   4800
      Width           =   15
   End
   Begin VB.Frame Frame1 
      Appearance      =   0  'ﾌﾗｯﾄ
      ForeColor       =   &H80000008&
      Height          =   660
      Left            =   0
      TabIndex        =   10
      Top             =   6000
      Width           =   4440
      Begin VB.Image IM_Denkyu 
         Height          =   330
         Index           =   2
         Left            =   2760
         Picture         =   "frmSRAET52.frx":030A
         Top             =   240
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Height          =   330
         Index           =   1
         Left            =   2280
         Picture         =   "frmSRAET52.frx":0494
         Top             =   240
         Width           =   300
      End
      Begin VB.Image IM_Execute 
         Height          =   330
         Index           =   2
         Left            =   1560
         Picture         =   "frmSRAET52.frx":061E
         Top             =   240
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Height          =   330
         Index           =   1
         Left            =   1200
         Picture         =   "frmSRAET52.frx":0C70
         Top             =   240
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Height          =   330
         Index           =   2
         Left            =   600
         Picture         =   "frmSRAET52.frx":12C2
         Top             =   240
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Height          =   330
         Index           =   1
         Left            =   240
         Picture         =   "frmSRAET52.frx":144C
         Top             =   240
         Width           =   360
      End
   End
   Begin FPSpread.vaSpread vaData 
      Height          =   3180
      Left            =   1080
      TabIndex        =   0
      Top             =   1935
      Width           =   3135
      _Version        =   196608
      _ExtentX        =   5530
      _ExtentY        =   5609
      _StockProps     =   64
      AllowCellOverflow=   -1  'True
      AllowMultiBlocks=   -1  'True
      ArrowsExitEditMode=   -1  'True
      BackColorStyle  =   1
      ColHeaderDisplay=   1
      DisplayRowHeaders=   0   'False
      EditEnterAction =   5
      EditModePermanent=   -1  'True
      EditModeReplace =   -1  'True
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   12
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      MaxCols         =   3
      MaxRows         =   10
      ProcessTab      =   -1  'True
      Protect         =   0   'False
      RetainSelBlock  =   0   'False
      ScrollBars      =   2
      SelectBlockOptions=   0
      SpreadDesigner  =   "frmSRAET52.frx":15D6
      UserResize      =   0
      VisibleCols     =   3
      VisibleRows     =   1
   End
   Begin VB.Frame Box 
      Appearance      =   0  'ﾌﾗｯﾄ
      ForeColor       =   &H80000008&
      Height          =   660
      Left            =   0
      TabIndex        =   7
      Top             =   0
      Width           =   5640
      Begin VB.Image CM_Execute 
         Height          =   330
         Left            =   600
         Picture         =   "frmSRAET52.frx":1D9C
         Top             =   240
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Height          =   330
         Left            =   240
         Picture         =   "frmSRAET52.frx":23EE
         Top             =   240
         Width           =   360
      End
      Begin VB.Image Image1 
         Height          =   615
         Left            =   0
         Top             =   120
         Width           =   3615
      End
   End
   Begin Threed5.SSPanel5 SSPanel52 
      Height          =   330
      Left            =   600
      TabIndex        =   8
      Top             =   1485
      Width           =   900
      _ExtentX        =   1588
      _ExtentY        =   582
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "数 量"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 SSPanel51 
      Height          =   645
      Left            =   600
      TabIndex        =   9
      Top             =   750
      Width           =   900
      _ExtentX        =   1588
      _ExtentY        =   1138
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Caption         =   "製 品"
      OutLine         =   -1  'True
   End
   Begin Threed5.SSPanel5 FM_Panel3D15 
      Height          =   645
      Index           =   0
      Left            =   0
      TabIndex        =   11
      Top             =   5280
      Width           =   5655
      _ExtentX        =   9975
      _ExtentY        =   1138
      ForeColor       =   0
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ ゴシック"
         Size            =   9.75
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin Threed5.SSPanel5 FM_Panel3D2 
         Height          =   375
         Index           =   2
         Left            =   585
         TabIndex        =   12
         Top             =   135
         Width           =   4950
         _ExtentX        =   8731
         _ExtentY        =   661
         ForeColor       =   0
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "ＭＳ ゴシック"
            Size            =   9.75
            Charset         =   128
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BevelOuter      =   1
         Begin VB.TextBox TX_Message 
            Appearance      =   0  'ﾌﾗｯﾄ
            BackColor       =   &H8000000F&
            BorderStyle     =   0  'なし
            ForeColor       =   &H00000000&
            Height          =   285
            Left            =   120
            MultiLine       =   -1  'True
            TabIndex        =   13
            Text            =   "frmSRAET52.frx":2578
            Top             =   70
            Width           =   5955
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "frmSRAET52.frx":25AF
         Top             =   135
         Width           =   300
      End
   End
   Begin VB.Image Image2 
      Height          =   3495
      Left            =   960
      Top             =   1800
      Width           =   3375
   End
   Begin VB.Label lblURISU 
      Alignment       =   1  '右揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      BackStyle       =   0  '透明
      Caption         =   "-999,999"
      BeginProperty Font 
         Name            =   "ＭＳ ゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   225
      Left            =   1635
      TabIndex        =   3
      Top             =   1560
      Width           =   765
   End
   Begin VB.Label lblHIN2 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      BackStyle       =   0  '透明
      Caption         =   "XXXXXXXXX1XXXXXXXXX2XXXXXXXXX3"
      BeginProperty Font 
         Name            =   "ＭＳ ゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   240
      Left            =   1575
      TabIndex        =   2
      Top             =   1140
      Width           =   3180
   End
   Begin VB.Label lblHIN1 
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      BackStyle       =   0  '透明
      Caption         =   "XXXXXXXX"
      BeginProperty Font 
         Name            =   "ＭＳ ゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H80000008&
      Height          =   225
      Left            =   1575
      TabIndex        =   1
      Top             =   825
      Width           =   930
   End
   Begin VB.Label Label8 
      Alignment       =   1  '右揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      BackStyle       =   0  '透明
      BorderStyle     =   1  '実線
      ForeColor       =   &H80000008&
      Height          =   330
      Left            =   1485
      TabIndex        =   6
      Top             =   1485
      Width           =   1020
   End
   Begin VB.Label Label6 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      BackStyle       =   0  '透明
      BorderStyle     =   1  '実線
      ForeColor       =   &H80000008&
      Height          =   330
      Left            =   1485
      TabIndex        =   4
      Top             =   750
      Width           =   1065
   End
   Begin VB.Label Label7 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      BackStyle       =   0  '透明
      BorderStyle     =   1  '実線
      ForeColor       =   &H80000008&
      Height          =   330
      Left            =   1485
      TabIndex        =   5
      Top             =   1065
      Width           =   3285
   End
   Begin VB.Menu MN_Ctrl 
      Caption         =   "処理（&1）"
      Begin VB.Menu MN_Execute 
         Caption         =   "登録（&R）"
         Shortcut        =   ^R
      End
      Begin VB.Menu bar11 
         Caption         =   "-"
      End
      Begin VB.Menu MN_EndCm 
         Caption         =   "終了（&X）"
      End
   End
   Begin VB.Menu MN_EditMn 
      Caption         =   "編集（&2）"
      Begin VB.Menu MN_APPENDC 
         Caption         =   "画面初期化（&S）"
         Shortcut        =   ^S
      End
   End
End
Attribute VB_Name = "FR_SSSMAIN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'***************************************************************************************
'*  【使用用途】シリアル№登録
'*  【作 成 日】2006/09/04  SYSTEM CREATE CO,.Ltd.
'*  【更 新 日】2008/08/05  FKS)NAKATA
'*  【備    考】 シリアル管理テーブルの検索条件から実績日を外し、該当するSBNNOとHIMCDが
'*               あれば全て出力させる
'***************************************************************************************
Option Explicit

'-【 変数宣言 】-------------------------------------------------------------------------
'AppPath退避用
Private L_strAppPath                    As String

'データ登録用
Private L_strWRTTM                      As String
Private L_strWRTDT                      As String

'パラメータ取得用
Private L_strRPTCLTID                   As String
'2008/08/06 CHG START FKS)NAKATA
'Private L_strRSTDT                      As String
Private L_strJDNNO                      As String
'2008/08/06 CHG E.N.D FKS)NAKATA
Private L_strHINCD                      As String
Private L_strSBNNO                      As String
Private L_strURISU                      As String

' プロパティ値格納用変数
Dim mstrRPTCLTID                        As String
Dim mstrRSTDT                           As String
Dim mstrHINCD                           As String
Dim mstrSBNNO                           As String
Dim mstrURISU                           As String

'* 最大入力桁数
'2008/08/06 CHG START FKS)NAKATA
''Private Const C_lngSERIAL_Len           As Long = 13        'シリアル№
Private Const C_lngSERIAL_Len           As Long = 22        'シリアル№ & 実績日
'2008/08/06 CHG E.N.D FKS)NAKATA

Private LC_lngDataMAX_ROW               As Long
Private LC_lngCurrent                   As Long

'更新確認メッセージキャンセル時のActiveCellセット用
Private L_LastCol                       As Long     '列
Private L_LastRow                       As Long     '行
'-------------------------------------------------------------------------【 変数宣言 】-

'-【 定数宣言 】-------------------------------------------------------------------------
'タイトル
Private Const LC_strPG_ID               As String = "SRAET52"
Private Const LC_strTitle               As String = "シリアル№登録"

' パラメータ スイッチ定義
Private Const mcPARAM_RPTCLTID          As String = "/RPTCLTID:"
'2008/08/06 CHG START FKS)NAKATA
''実績日から受注番号に変更
'Private Const mcPARAM_RSTDT             As String = "/RSTDT:"
Private Const mcPARAM_JDNNO             As String = "/JDNNO:"
'2008/08/06 CHG E.N.D FKS)NAKATA
Private Const mcPARAM_HINCD             As String = "/HINCD:"
Private Const mcPARAM_SBNNO             As String = "/SBNNO:"
Private Const mcPARAM_URISU             As String = "/URISU:"

'スプレッド背景色
Private Const LC_lng_va_Edit_Color      As Long = &HFFFF&
Private Const LC_lng_va_UnEdit_Color    As Long = &HFFFFFF
Private Const LC_lng_va_Lock_Color      As Long = &HC0C0C0

'スプレッドの行
Private Const LC_lngMAX_ROW             As Long = 999999    '* 最大行数
Private Const LC_lngDEFAULT_ROW         As Long = 1         '* デフォルトセット行

'スプレッドの項目
Private Const LC_lngCol_CHECK           As Long = 1         '* 返品チェック
Private Const LC_lngCol_NO              As Long = 2         '* 行№
Private Const LC_lngCol_SERIAL          As Long = 3         '* シリアル№

'出荷済み区分
Private Const LC_strSYUKA               As String = "02"

'SQL文生成時のモード
Private Enum enumCREATE_MODE
    Ins
    Del
End Enum

'メッセージ名
Private Const LC_strAPPEND              As String = "_APPEND        "   '* 共通メッセージ
Private Const LC_strCURSOR              As String = "_CURSOR        "   '* 共通メッセージ

'メッセージＩＤ
Private Const CommonMSGSQ               As String = "0"     '* 共通メッセージＩＤ
Private Const Entry                     As String = "0"     '* 登録確認メッセージ
Private Const EntryFinal                As String = "1"     '* 登録後メッセージ
Private Const NotHINCD                  As String = "2"     '* %CDという商品コードは存在しません。
Private Const NoData                    As String = "3"     '* 該当データが存在しません。
Private Const NotSerial                 As String = "4"     '* 返品済のシリアル№が入力されました。よろしいですか。
Private Const NoCheck                   As String = "5"     '* 登録対象のデータがありません。
Private Const InfLineOver               As String = "6"     '* 入力行数が数量と合いません。
'-------------------------------------------------------------------------【 定数宣言 】-


'=【 イベント 】=========================================================================

'-【ﾌﾟﾙﾀﾞｳﾝﾒﾆｭｰ】-----------------------------------------------------------------------
'===========================================================================
'【使用用途】 登録(R)選択時
'【関 数 名】 MN_Execute_Click
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub MN_Execute_Click()
    Call CM_Execute_Click
End Sub

'===========================================================================
'【使用用途】 終了(X)選択時
'【関 数 名】 MN_EditMn_Click
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub MN_EndCm_Click()
    Call CM_EndCm_Click
End Sub

'===========================================================================
'【使用用途】 画面初期化(S)選択時
'【関 数 名】 MN_APPENDC_Click
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub MN_APPENDC_Click()
    Call Form_Load
End Sub
'-----------------------------------------------------------------------【ﾌﾟﾙﾀﾞｳﾝﾒﾆｭｰ】-

'===========================================================================
'【使用用途】 [終了]ボタンクリック時
'【関 数 名】 CM_EndCm_Click
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub CM_EndCm_Click()
    '* セル背景色を解除
    With vaData
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_NO, 1, False, LC_lngCol_NO, .MaxRows)
    End With
    Unload Me
End Sub

'===========================================================================
'【使用用途】 [終了]ボタンMouseDown時
'【関 数 名】 CM_EndCm_MouseDown
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub CM_EndCm_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
     CM_EndCm.Picture = IM_EndCm(2).Picture
End Sub

'===========================================================================
'【使用用途】 [終了]ボタンMouseUp時
'【関 数 名】 CM_EndCm_MouseUp
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub CM_EndCm_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
     CM_EndCm.Picture = IM_EndCm(1).Picture
End Sub

'===========================================================================
'【使用用途】 [終了]ボタンMouseMove時
'【関 数 名】 CM_EndCm_MouseMove
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub CM_EndCm_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "メニューに戻ります。"
End Sub

'===========================================================================
'【使用用途】 Image2 MouseMove時
'【関 数 名】 Image2_MouseMove
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub Image2_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
    Screen.MousePointer = vbDefault
End Sub

'===========================================================================
'【使用用途】 [登録]ボタンクリック時
'【関 数 名】 CM_Execute_Click
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub CM_Execute_Click()

    Dim msgMsgBox       As VbMsgBoxResult
    Dim lngRow          As Long
    Dim Mst_Inf         As TYPE_DB_SYSTBH
    Dim intRet          As Integer
    Dim strMSGKBN       As String
    Dim strMSGNM        As String
    Dim lngChkRow       As Long
    Dim blnInsFlg       As Boolean

    strMSGKBN = "1"
    lngChkRow = 0
    blnInsFlg = False

    '* セル背景色を解除
    With vaData
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False)
    End With
    
    'スプレッドの入力チェック
    If P_EntryCheck(lngRow) = False Then
        Exit Sub
    Else
'''        '明細にチェックが入っていないときは処理終了
'''        If lngRow = 0 Then
'''            strMSGKBN = "1"
'''            intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, NoCheck, Mst_Inf)
'''            If intRet <> 0 Then
'''                Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
'''                Exit Sub
'''            End If
'''            Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
'''            If L_LastCol > 0 And L_LastRow > 0 Then
'''                Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
'''                Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
'''            Else
'''                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, vaData.MaxRows, True)
'''                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, vaData.MaxRows)
'''            End If
'''            Exit Sub
'''        End If
        '選択行数が数量と等しくないときはエラー
        If lngRow <> CLng(Me.lblURISU.Caption) Then
            intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, InfLineOver, Mst_Inf)
            If intRet <> 0 Then
                Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
                Exit Sub
            End If
            Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
            Exit Sub
        End If
        
        'シリアル№チェック
        With vaData
            For lngChkRow = 1 To .MaxRows
                If P_EntryCheckSerial(lngChkRow) = False Then
                    strMSGKBN = "1"
                    intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, NotSerial, Mst_Inf)
                    If intRet <> 0 Then
                        Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
                        Exit Sub
                    End If
                    msgMsgBox = GP_MsgBox(enmMsg.Insert, Mst_Inf.MSGCM, LC_strTitle)
                    If msgMsgBox <> vbYes Then
                        If lngChkRow > 0 Then
                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, lngChkRow, True)
                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, lngChkRow)
                        Else
                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
                        End If
                        Exit Sub
                    Else
                        blnInsFlg = True
                    End If
                End If
            Next
        End With
    End If

    If blnInsFlg = False Then
        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, Entry, Mst_Inf)
        If intRet <> 0 Then
            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
            Exit Sub
        End If
        msgMsgBox = GP_MsgBox(enmMsg.Insert, Mst_Inf.MSGCM, LC_strTitle)
        If msgMsgBox <> vbYes Then
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
    '        If L_LastCol > 0 And L_LastRow > 0 Then
    '            Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
    '            Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
    '        Else
    '            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, vaData.MaxRows, True)
    '            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, vaData.MaxRows)
    '        End If
            Exit Sub
        End If
    End If
    
    Screen.MousePointer = vbHourglass
    
    '登録処理
    If P_Main() = True Then
    '* データ登録後は画面を閉じる
        Call CM_EndCm_Click
        Exit Sub
    End If

EndLabel:
    '* セル背景色を設定
    Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
    
    Screen.MousePointer = vbDefault
    
End Sub

'===========================================================================
'【使用用途】 [登録]ボタンMouseDown時
'【関 数 名】 CM_Execute_MouseDown
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub CM_Execute_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    CM_Execute.Picture = IM_Execute(2).Picture
End Sub

'===========================================================================
'【使用用途】 [登録]ボタンMouseUp時
'【関 数 名】 CM_Execute_MouseUp
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub CM_Execute_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    CM_Execute.Picture = IM_Execute(1).Picture
End Sub

'===========================================================================
'【使用用途】 [登録]ボタンMouseMove時
'【関 数 名】 CM_Execute_MouseMove
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub CM_Execute_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    IM_Denkyu(0).Picture = IM_Denkyu(2).Picture
    TX_Message.Text = "登録します。"
End Sub

'===========================================================================
'【使用用途】 [ダミー]イメージMouseMove時
'【関 数 名】 Image1_MouseMove
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub Image1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single) 'Hand Made
    Call Init_Prompt
End Sub

'===========================================================================
'【使用用途】 フォームロード時
'【関 数 名】 Form_Load
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub Form_Load()

    Dim lngIndex    As Long
    Dim strHINNM    As String
    Dim CommandLine As String
    Dim strArry()   As String     ' 引数取得配列
    Dim strRet      As String     ' 引数ワーク
    Dim strRetU     As String       ' 引数ワーク
    Dim intRet      As Integer
    Dim strMSGKBN   As String
    Dim Mst_Inf     As TYPE_DB_SYSTBH

    Me.KeyPreview = True
    
    '同一プログラムが起動していた場合は終了する
    If App.PrevInstance Then
        Call GP_MsgBox(Critical, "既に起動しています。", LC_strTitle)
        End
    End If
    
    'フォームの位置をセット
    Me.Top = (Screen.Height - Me.Height) / 2
    Me.Left = (Screen.Width - Me.Width) / 2
    
    'AppPathの退避
    L_strAppPath = App.Path
    
    'パラメータ取得
    strArry = Split(Replace(Command(), """", ""), " ")
    L_strRPTCLTID = Replace(strArry(0), mcPARAM_RPTCLTID, "")
'2008/08/07 CHG START FKS)NAKATA
''実績日から受注番号に変更
''    L_strRSTDT = Replace(strArry(1), mcPARAM_RSTDT, "")
    L_strJDNNO = Replace(strArry(1), mcPARAM_JDNNO, "")
'2008/08/07 CHG E.N.D FKS)NAKATA
    L_strHINCD = Replace(strArry(2), mcPARAM_HINCD, "")
    L_strSBNNO = Replace(strArry(3), mcPARAM_SBNNO, "")
    L_strURISU = Replace(strArry(4), mcPARAM_URISU, "")
    
    'パラメータで不備があれば本画面は起動させない
    If L_strRPTCLTID = "" Then
        Call GP_MsgBox(Critical, "ワークステーションＩＤが設定されていません。", LC_strTitle)
        End
    End If
    
'2008/08/06 CHG START FKS)NAKATA
'' 実績日から受注番号に変更
''    If L_strRSTDT = "" Then
''        Call GP_MsgBox(Critical, "実績日が設定されていません。", LC_strTitle)
''        End
''    End If
    If L_strJDNNO = "" Then
        Call GP_MsgBox(Critical, "受注番号が設定されていません。", LC_strTitle)
        End
    End If
'2008/08/06 CHG E.N.D FKS)NAKATA

    If L_strHINCD = "" Then
        Call GP_MsgBox(Critical, "製品コードが設定されていません。", LC_strTitle)
        End
    End If
    If L_strSBNNO = "" Then
        Call GP_MsgBox(Critical, "製番が設定されていません。", LC_strTitle)
        End
    End If
    If L_strURISU = "" Then
        Call GP_MsgBox(Critical, "売上数量が設定されていません。", LC_strTitle)
        End
    Else
        If IsNumeric(L_strURISU) = False Then
            Call GP_MsgBox(Critical, "売上数量が数値ではありません。", LC_strTitle)
            End
        End If
    End If
    
    'フォームのクリア
    Call P_FromClear
    
    'スプレッドの初期化
    Call P_vaData_Init
                
    'DB接続
    Call CF_Ora_USR1_Open
    Call CF_Ora_USR9_Open
    
    '受け取ったパラメータを画面にセット
    lblHIN1.Caption = L_strHINCD
    If P_GET_HINNMA(L_strHINCD, strHINNM) = True Then
        lblHIN2.Caption = strHINNM
    Else
        strMSGKBN = "1"
        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, NotHINCD, Mst_Inf)
        If intRet <> 0 Then
            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
            End
        End If
        Call GP_MsgBox(Exclamation, Replace(Mst_Inf.MSGCM, "%CD", L_strHINCD), LC_strTitle)
        End
    End If
    lblURISU.Caption = L_strURISU
    LC_lngCurrent = 1
    
    '画面の初期表示
    If P_Show_Data = False Then
        'データがないとき
        strMSGKBN = "1"
        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, NoData, Mst_Inf)
        If intRet <> 0 Then
            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
            End
        End If
        Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
        End
    End If
    
    L_LastCol = -1
    L_LastRow = -1
    
End Sub

'===========================================================================
'【使用用途】 アンロード時
'【関 数 名】 Form_QueryUnload
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
    'DB接続解除
    Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
End Sub

'===========================================================================
'【使用用途】 キー押下時
'【関 数 名】 Form_KeyPress
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub Form_KeyPress(KeyAscii As Integer)
    
    If TypeOf Me.ActiveControl Is TextBox Or _
        TypeOf Me.ActiveControl Is ComboBox Or _
        TypeOf Me.ActiveControl Is OptionButton Then
        
        Call GP_CtrlSend(KeyAscii, Me)
    End If
End Sub

'===========================================================================
'【使用用途】 スプレッドエディットモード変更時
'【関 数 名】 vaData_EditChange
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub vaData_EditChange(ByVal Col As Long, ByVal Row As Long)

    With vaData
        If LC_lngMAX_ROW <> .MaxRows Then
            If .MaxRows = Row Then
                .MaxRows = .MaxRows + 1
                .Row = 1
                .Row2 = .MaxRows
                .Col = LC_lngCol_NO
                .Col2 = LC_lngCol_SERIAL
                .BlockMode = True
                .BackColor = Me.BackColor
                .Protect = True
                .Lock = True
                Call .SetText(LC_lngCol_NO, Row + 1, Row + 1)
            End If
        End If
    End With

End Sub

Private Sub vaData_KeyPress(KeyAscii As Integer)
    
    Dim msgMsgBox       As VbMsgBoxResult
    Dim strMSGKBN       As String
    Dim strMSGNM        As String
    Dim Mst_Inf         As TYPE_DB_SYSTBH
    Dim intRet          As Integer
    
    If LC_lngCurrent = vaData.MaxRows Then
        L_LastCol = LC_lngCol_CHECK
        L_LastRow = vaData.MaxRows
        Call CM_Execute_Click
        L_LastCol = -1
        L_LastRow = -1
    End If

End Sub

'===========================================================================
'【使用用途】 セル移動時
'【関 数 名】 vaData_LeaveCell
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub vaData_LeaveCell(ByVal Col As Long, ByVal Row As Long, ByVal NewCol As Long, ByVal NewRow As Long, Cancel As Boolean)
    
    '* セル背景色を解除
    With vaData
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row, False)
    End With

    '* セル背景色を設定
    If NewCol <> -1 And NewRow <> -1 Then
        Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
    End If
    
    LC_lngCurrent = NewRow

End Sub

'===========================================================================
'【使用用途】 スプレッドフォーカス取得時
'【関 数 名】 vaData_GotFocus
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub vaData_GotFocus()

    'カーソル制御。
    With vaData
        If .ActiveRow > 0 Then
            If .ActiveCol = 1 Then
                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .ActiveRow)
            Else
                Call GP_SpActiveCell(vaData, .ActiveCol, .ActiveRow)
            End If
''''    Else                '2006.09.28
''''        cmdExe.SetFocus '2006.09.28
        Else
            txtDummy.SetFocus
        End If
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .ActiveRow, True)
    End With
    
End Sub
'=========================================================================【 イベント 】=

'=【 メソッド 】=========================================================================
'===========================================================================
'【使用用途】 スプレッド背景色設定
'【関 数 名】 P_Va_BackColor
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub P_Va_BackColor()

    Dim lngRow          As Long

    With vaData
        .Row = 1
        .Row2 = .MaxRows
        .Col = LC_lngCol_NO
        .Col2 = LC_lngCol_SERIAL
        .BlockMode = True
        .BackColor = Me.BackColor
        .BlockMode = False
    End With

End Sub

'===========================================================================
'【使用用途】 スプレッドロック制御
'【関 数 名】 P_Va_Lock
'【返    値】 Boolean
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub P_Va_Lock()

    With vaData
        .Row = 1
        .Col = LC_lngCol_NO
        .Row2 = .MaxRows
        .Col2 = LC_lngCol_SERIAL
        .BlockMode = True
        .Protect = True
        .Lock = True
        .BlockMode = False
    End With

End Sub

'===========================================================================
'【使用用途】 データ表示
'【関 数 名】 P_Show_Data
'【返    値】 Boolean
'【更 新 日】
'【備    考】
'===========================================================================
Private Function P_Show_Data() As Boolean

    Dim Usr_Ody_LC  As U_Ody
    Dim lngI        As Long
    Dim intLen      As Integer
    
    P_Show_Data = False
    
    'スプレッドのクリア
    Call P_vaData_Init

    'データの取得。
    If P_Get_Data(Usr_Ody_LC) = True Then
        'データを画面に表示する。
        Call P_Set_Data(Usr_Ody_LC)
        'スプレッドの入力制限。
        Call P_Va_Lock
    Else
        'クローズ
        Call CF_Ora_CloseDyn(Usr_Ody_LC)
        Exit Function
    End If

    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody_LC)
    
    P_Show_Data = True

End Function

'===========================================================================
'【使用用途】 データセット
'【関 数 名】 P_Set_Data
'【引    数】 ByRef Usr_Ody_LC As U_Ody   :ダイナセット情報構造体
'【返    値】 Boolean
'【更 新 日】 2008/08/06 FKS)NAKATA
'【備    考】 スプレッドのシリアル№欄に実績日を持たせる
'===========================================================================
Private Function P_Set_Data(ByRef Usr_Ody_LC As U_Ody) As Boolean

    Dim lngI        As Long
    Dim lngJ        As Long
    Dim blnFLG      As Boolean
    Dim intLen      As Integer
    
'2008/08/06 ADD START FKS)NAKATA
    Dim wkSRANO As String     'シリアル№ワーク
    Dim wkRSTDT As String     '実績日ワーク
'2008/08/06 ADD E.N.D FKS)NAKATA


    On Error GoTo ErrLbl:
    
    P_Set_Data = False
    
    lngI = 0
    blnFLG = False
    
    intLen = Len(CStr(LC_lngMAX_ROW))
    
    With vaData
        'スプレッドの行数の設定
        .ReDraw = False
        .MaxRows = 0

        
        'スプレッドにデータを表示する。
        Do Until CF_Ora_EOF(Usr_Ody_LC) = True
            lngI = lngI + 1
            
'2008/08/06 ADD START FKS)NAKATA
            'DBより取得したシリアル№と実績日を格納
            wkSRANO = CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", "")
            wkRSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "RSTDT", "")
'2008/08/06 ADD E.N.D FKS)NAKATA
            
            
            'LC_lngMAX_ROW行を超えたときは強制的にLOOP処理を抜ける
            If lngI > LC_lngMAX_ROW Then
                GoTo LBL_LOOP_END
            End If
            .MaxRows = .MaxRows + 1
            Call SetCheckBox(vaData, LC_lngCol_CHECK, lngI)
            If CF_Ora_GetDyn(Usr_Ody_LC, "KBN", "") = "C" Then
                Call .SetText(LC_lngCol_CHECK, lngI, "1")
            End If
            Call .SetText(LC_lngCol_NO, lngI, Right(Space(intLen) & CStr(lngI), intLen))
            
'2008/08/06 ADD START FKS)NAKATA
''スプレッドにシリアル№と実績日をスペースを1つ入れ格納
''            Call .SetText(LC_lngCol_SERIAL, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", ""))
            Call .SetText(LC_lngCol_SERIAL, lngI, wkSRANO & " " & wkRSTDT)
'2008/08/06 ADD E.N.D FKS)NAKATA

            Call CF_Ora_MoveNext(Usr_Ody_LC)
        Loop
        
LBL_LOOP_END:
        .MaxRows = Usr_Ody_LC.Obj_Ody.RecordCount
        LC_lngDataMAX_ROW = .MaxRows
                        
        '背景色の設定
        Call P_Va_BackColor
        
        .ReDraw = True
    End With
    
    P_Set_Data = True

    Exit Function
ErrLbl:
    Call GP_MsgBox(Critical, Err.Description)
End Function

'===========================================================================
'【使用用途】 データ取得
'【関 数 名】 P_Get_Data
'【引    数】 ByRef Usr_Ody_LC As U_Ody   :ダイナセット情報構造体
'【返    値】 Boolean
'【更 新 日】 2008/08/06 FKS)NAKATA
'【備    考】 実績日の取得を追加
'===========================================================================
Private Function P_Get_Data(ByRef Usr_Ody_LC As U_Ody) As Boolean

    Dim strSQL          As String
    Dim strWKRSTDT      As String
    Dim strWKRPTCLTID   As String
    Dim strDB           As String

'2008/08/06 ADD START FKS)NAKATA
    Dim strPUDLNO       As String
'2008/08/06 ADD E.N.D FKS)NAKATA
    
    
    On Error GoTo Errlabel:
    
    
'2008/08/06 ADD START FKS)NAKATA
''JDNTRAよりPUDLNOの取得
    If P_GET_PUDLNO(L_strJDNNO, strPUDLNO) = False Then
        strPUDLNO = ""
    End If
'2008/08/06 ADD E.N.D FKS)NAKATA
    
    
    P_Get_Data = False
    
    'strWKRSTDT = Left(L_strRSTDT & Space(8), 8)
    strWKRPTCLTID = Left(L_strRPTCLTID & Space(5), 5)
    
    strDB = Get_DBHEAD & "_" & ORA_MAX_USR9
    
    'SQL文作成
    strSQL = ""
    strSQL = strSQL & "Select"
    strSQL = strSQL & vbCrLf & " Case"
    strSQL = strSQL & vbCrLf & "     When WRK.SRANO Is Not Null Then 'C'"
    strSQL = strSQL & vbCrLf & "     Else ''"
    strSQL = strSQL & vbCrLf & " End As KBN"
    strSQL = strSQL & vbCrLf & ",SRA.SRANO"
'2008/08/05 ADD START FKS)NAKATA
    strSQL = strSQL & vbCrLf & ",SRA.RSTDT"
'2008/08/05 ADD E.N.D FKS)NAKATA
    strSQL = strSQL & vbCrLf & ",SRA.WRTTM"
    strSQL = strSQL & vbCrLf & ",SRA.WRTDT"
    strSQL = strSQL & vbCrLf & " From    SRACNTTB SRA"
    strSQL = strSQL & vbCrLf & "             Left Join " & strDB & ".SRAET52 WRK On SRA.SRANO    = WRK.SRANO"
    strSQL = strSQL & vbCrLf & "                                                And WRK.RPTCLTID = " & "'" & strWKRPTCLTID & "'"
'2008/08/05 CHG START FKS)NAKATA
''    strSQL = strSQL & vbCrLf & " Where   SRA.RSTDT     = " & "'" & strWKRSTDT & "'"
''    strSQL = strSQL & vbCrLf & "   And   SRA.SBNNO     = " & "'" & L_strSBNNO & "'"
    strSQL = strSQL & vbCrLf & "   Where   SRA.SBNNO     = " & "'" & L_strSBNNO & "'"
'2008/08/05 CHG E.N.D FKS)NAKATA

'2008/08/06 ADD START FKS)NAKATA
    strSQL = strSQL & vbCrLf & "   And   SRA.HINCD     = " & "'" & L_strHINCD & "'"
'2008/08/06 ADD E.N.E FKS)NAKATA

    strSQL = strSQL & vbCrLf & "   And   SRA.ZAISYOBN  = " & "'" & LC_strSYUKA & "'"

'2008/08/06 ADD START FKS)NAKATA
    If strPUDLNO <> "" Then
        strSQL = strSQL & vbCrLf & "   And   SRA.PUDLNO  = " & "'" & strPUDLNO & "'"
    End If
'2008/08/06 ADD E.N.D FKS)NAKATA
    strSQL = strSQL & vbCrLf & " Order By SRA.SRANO"
    
    
    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

    If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '取得データ有
        P_Get_Data = True
    End If
            
    Exit Function
    
Errlabel:
    Call GP_MsgBox(Critical, "データ取得時にエラーが発生しました。(P_Get_Data)" & vbCrLf & _
                Err.Number & ":" & Err.Description _
                , vbCritical + vbOKOnly)
End Function

'===========================================================================
'【使用用途】 画面クリア
'【関 数 名】 P_FromClear
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub P_FromClear()
    lblHIN1.Caption = ""
    lblHIN2.Caption = ""
    lblURISU.Caption = ""
    CM_EndCm.Picture = IM_EndCm(1).Picture
    CM_Execute.Picture = IM_Execute(1).Picture
    TX_Message = ""
End Sub

'===========================================================================
'【使用用途】 スプレッド初期化
'【関 数 名】 P_vaData_Init
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub P_vaData_Init()

    Dim lngI   As Long
    Dim intLen As Integer

    lngI = 0
    intLen = Len(CStr(LC_lngMAX_ROW))

    With vaData
        'スプレッドのクリア
        .ReDraw = False
        .Action = ActionClearText
        .MaxRows = LC_lngDEFAULT_ROW
        .Col = LC_lngCol_CHECK
        .Col2 = LC_lngCol_CHECK
        .Row = 1
        .Row2 = .MaxRows
        .CellType = CellTypeCheckBox
        .GridColor = &H0&
        .GridSolid = True
        .TypeCheckType = TypeCheckTypeNormal
        .TypeCheckCenter = True
        .TypeCheckText = ""
        Call SetEdit(vaData, LC_lngCol_NO, 1)
        Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
        '行番号をセット
        For lngI = 0 To vaData.MaxRows
            lngI = lngI + 1
            Call .SetText(LC_lngCol_NO, lngI, Right(Space(intLen) & CStr(lngI), intLen))
        Next
        .ReDraw = True
    End With

    Call P_Va_BackColor
    Call P_Va_Lock
    
End Sub

'===========================================================================
'【使用用途】 製品名取得
'【関 数 名】 P_GET_HINNMA
'【引    数】 ByVal strHINCD As String   :製品コード
'【引    数】 ByRef strHINNMA As String  :製品名
'【返    値】 Boolean
'【更 新 日】
'【備    考】
'===========================================================================
Private Function P_GET_HINNMA(ByVal strHINCD As String, _
                              ByRef strHINNMA As String) As Boolean
    Dim strSQL      As String
    Dim Usr_Ody_LC  As U_Ody
    Dim strWKHINCD  As String

    P_GET_HINNMA = False
    
    '商品コードを10桁にする
    strWKHINCD = Left(strHINCD & Space(10), 10)

    'SQL文作成
    strSQL = vbNullString
    strSQL = strSQL & " SELECT  HINNMA "
    strSQL = strSQL & " FROM    HINMTA"
    strSQL = strSQL & " WHERE   HINCD = '" & strWKHINCD & "'"

    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)

    If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '取得データ有
            strHINNMA = CF_Ora_GetDyn(Usr_Ody_LC, "HINNMA", "")
        P_GET_HINNMA = True
    End If

    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody_LC)

Exit Function
Errlabel:
    Call GP_MsgBox(Critical, "データ取得時にエラーが発生しました。(P_SRANOCheck)" & vbCrLf & _
                Err.Number & ":" & Err.Description _
                , vbCritical + vbOKOnly)
End Function

'===========================================================================
'【使用用途】 シリアル№存在チェック（管理テーブル）
'【関 数 名】 P_SRANOCheck
'【引    数】 ByVal strSRANO As String  :シリアル№
'【返    値】 Boolean
'【更 新 日】
'【備    考】
'===========================================================================
Private Function P_SRANOCheck(ByVal strSRANO As String, _
                              ByRef strZAISYOBN As String) As Boolean

    Dim strSQL      As String
    Dim Usr_Ody_LC  As U_Ody
    Dim strWKSRANO   As String
    Dim strWKHINCD   As String

    P_SRANOCheck = False
    strZAISYOBN = ""
    
    strWKSRANO = Left(strSRANO & Space(13), 13)
    strWKHINCD = Left(L_strHINCD & Space(10), 10)

    'SQL文作成
    strSQL = vbNullString
    strSQL = strSQL & " SELECT  * " & vbCrLf
    strSQL = strSQL & " FROM    SRACNTTB" & vbCrLf
    strSQL = strSQL & " WHERE   SRANO    = '" & strWKSRANO & "'" & vbCrLf
    
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    
    If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '取得データ有
        strZAISYOBN = CF_Ora_GetDyn(Usr_Ody_LC, "ZAISYOBN", "")
        P_SRANOCheck = True
    End If

    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody_LC)
    
Exit Function
Errlabel:
    Call GP_MsgBox(Critical, "データ取得時にエラーが発生しました。(P_SRANOCheck)" & vbCrLf & _
                Err.Number & ":" & Err.Description _
                , vbCritical + vbOKOnly)
End Function

'===========================================================================
'【使用用途】 スプレッド入力チェック（メイン）
'【関 数 名】 P_EntryCheck
'【引    数】 ByRef lngEntryLine As Long  :有効行数
'【返    値】 Boolean
'【更 新 日】
'【備    考】
'===========================================================================
Private Function P_EntryCheck(ByRef lngEntryLine As Long) As Boolean
    
    Dim lngI        As Long
    Dim varCHECK    As Variant
    Dim lngCount    As Long
    
    P_EntryCheck = False
    
    With vaData
        For lngI = 1 To .MaxRows
            Call .GetText(LC_lngCol_CHECK, lngI, varCHECK)
            If Nz(varCHECK) = "1" Then
                lngCount = lngCount + 1
            End If
        Next lngI
    End With
    
    lngEntryLine = lngCount
    
    P_EntryCheck = True

End Function

'===========================================================================
'【使用用途】 SQL文生成＆発行
'【関 数 名】 P_EXECUTE_SQL
'【引    数】 ByVal strMode     As enumCREATE_MODE  :SQL生成モード
'【引    数】 ByVal strSRALINNO As String           :画面行番号
'【引    数】 ByVal strSRANO    As String           :シリアル№
'【引    数】 ByVal strLOCATION As String           :棚番
'【引    数】 ByVal strWRTTM    As String           :データ作成時間
'【引    数】 ByVal strWRTDT    As String           :データ作成日付
'【返    値】 Boolean
'【更 新 日】 2008/08/06 FKS)NAKATA
'【備    考】
'===========================================================================
Private Function P_EXECUTE_SQL(ByVal strMode As enumCREATE_MODE, _
                               ByVal strSRANO As String, _
                               ByVal strWRTTM As String, _
                               ByVal strWRTDT As String) As Boolean
    Dim strSQL As String

'2008/08/06 ADD START FKS)NAKATA
    Dim wkSRANO As String
    Dim wkRSTDT As String
'2008/08/06 ADD E.N.D FKS)NAKATA
    
    
    P_EXECUTE_SQL = False
    
    strSQL = vbNullString
                                                  
'2008/08/06 ADD START FKS)NAKATA
''パラメータをシリアル№と実績日に分ける
    wkSRANO = Left(Trim(strSRANO), 13)
    wkRSTDT = Right(Trim(strSRANO), 8)
'2008/08/06 ADD E.N.D FKS)NAKATA
                             
    Select Case strMode
        Case enumCREATE_MODE.Ins
            strSQL = strSQL & " INSERT INTO SRAET52 (" & vbCrLf
            strSQL = strSQL & "                      RPTCLTID," & vbCrLf
            strSQL = strSQL & "                      RSTDT," & vbCrLf
            strSQL = strSQL & "                      HINCD," & vbCrLf
            strSQL = strSQL & "                      SBNNO," & vbCrLf
            strSQL = strSQL & "                      SRANO," & vbCrLf
            strSQL = strSQL & "                      WRTTM," & vbCrLf
            strSQL = strSQL & "                      WRTDT" & vbCrLf
            strSQL = strSQL & "                     )" & vbCrLf
            strSQL = strSQL & " VALUES  (" & vbCrLf
            strSQL = strSQL & "          '" & L_strRPTCLTID & "'," & vbCrLf
'2008/08/07 CHG START FKS)NAKATA
''           strSQL = strSQL & "          '" & L_strRSTDT & "'," & vbCrLf
            strSQL = strSQL & "          '" & wkRSTDT & "'," & vbCrLf
'2008/08/07 CHG E.N.D FKS)NAKATA
            strSQL = strSQL & "          '" & L_strHINCD & "'," & vbCrLf
            strSQL = strSQL & "          '" & L_strSBNNO & "'," & vbCrLf
'2008/08/07 CHG START FKS)NAKATA
 ''           strSQL = strSQL & "          '" & strSRANO & "'," & vbCrLf
            strSQL = strSQL & "          '" & wkSRANO & "'," & vbCrLf
'2008/08/07 CHG E.N.D FKS)NAKATA
            strSQL = strSQL & "          '" & strWRTTM & "'," & vbCrLf
            strSQL = strSQL & "          '" & strWRTDT & "'" & vbCrLf
            strSQL = strSQL & "         )" & vbCrLf
        
        Case enumCREATE_MODE.Del
            strSQL = strSQL & " DELETE FROM SRAET52" & vbCrLf
            strSQL = strSQL & " WHERE  RPTCLTID = '" & L_strRPTCLTID & "'" & vbCrLf
    
    End Select
    
    'SQLを発行する
    If CF_Ora_Execute(gv_Odb_USR9, strSQL) = False Then
        Exit Function
    End If
        
    P_EXECUTE_SQL = True

End Function

'=======================================================================================
'【使用用途】 データ登録処理（メイン）
'【関 数 名】 P_Main
'【更 新 日】
'【備    考】
'=======================================================================================
Private Function P_Main() As Boolean

    Dim lngI        As Long
    Dim lngLineNo   As Long
    Dim strSQL      As String
    Dim varCHECK    As Variant
    Dim varNO       As Variant
    Dim varSERIAL   As Variant
    Dim varSBNNO    As Variant
    Dim datNOW      As Date
    Dim intCnt      As Integer
    Dim intMaxKeta  As Integer
    Dim strZero     As String

    P_Main = False
        
    'BEGIN TRAN
    If CF_Ora_BeginTrans(gv_Oss_USR9) = False Then
        GoTo EndLbl:
    End If
    
    '登録日時を生成
    datNOW = Now
    L_strWRTTM = Format(datNOW, "HHMMSS")
    L_strWRTDT = Format(datNOW, "YYYYMMDD")
    
    '行番号用ZERO文字を設定
    intCnt = 0
    intMaxKeta = Len(CStr(LC_lngMAX_ROW))
    For intCnt = 0 To intMaxKeta - 1
        strZero = strZero & "0"
    Next

    'DELETE
    If P_EXECUTE_SQL(enumCREATE_MODE.Del, _
                     "", _
                     "", _
                     "") = False Then
        GoTo EndLbl:
    End If
    
    'INSERT
    lngI = 0
    lngLineNo = 0
    With vaData
        For lngI = 1 To .MaxRows
            Call .GetText(LC_lngCol_CHECK, lngI, varCHECK)
            Call .GetText(LC_lngCol_NO, lngI, varNO)
            Call .GetText(LC_lngCol_SERIAL, lngI, varSERIAL)
            If Nz(varCHECK) = "1" Then
                lngLineNo = lngLineNo + 1
                If P_EXECUTE_SQL(enumCREATE_MODE.Ins, _
                                 CStr(varSERIAL), _
                                 L_strWRTTM, _
                                 L_strWRTDT) = False Then
                    GoTo EndLbl:
                End If
            End If
        Next lngI
    End With

    'COMMIT
    Call CF_Ora_CommitTrans(gv_Oss_USR9)
    
    P_Main = True
    
    Exit Function
    
    GoTo EndLbl:
ErrLbl:
    'ロールバック
    Call CF_Ora_RollbackTrans(gv_Oss_USR9)
EndLbl:

End Function

'===========================================================================
'【使用用途】 スプレッドの列のロック色設定。
'【関 数 名】 GP_Va_Col_LockColor
'【引    数】 ByRef objSpread As Object：スプレッド
'【引    数】 ByVal lngCol As long：列番号
'【返    値】
'【更 新 日】
'【備    考】
'===========================================================================
Public Sub GP_Va_Col_LockColor(ByRef objSpread As Object, ByVal lngCol As Long)

    'スプレッドの背景色の設定。
    With objSpread
        .Row = 1
        .Col = lngCol
        .Row2 = .MaxRows
        .Col2 = lngCol
        .BlockMode = True
        .BackColor = LC_lng_va_Lock_Color
        .BlockMode = False
    End With

End Sub

'=======================================================================================
'【使用用途】 スプレッドの列の編集中色設定及び解除。
'【関 数 名】 GP_Va_Col_EditColor
'【引    数】 ByRef objSpread As Object：スプレッド
'【引    数】 ByVal lngCol As long：列番号
'【引    数】 ByVal lngRow As long：行番号
'【引    数】 ByVal bolEdit As Boolean：編集中の場合TRUE：編集中から抜けるときにはFalse
'【返    値】
'【更 新 日】
'【備    考】
'=======================================================================================
Public Sub GP_Va_Col_EditColor(ByRef objSpread As Object, _
                               ByVal lngCol As Long, _
                               ByVal lngRow As Long, _
                               ByVal bolEdit As Boolean, _
                               Optional ByVal lngCol2 As Long = 0, _
                               Optional ByVal lngRow2 As Long = 0)

    'スプレッドの背景色の設定。
    With objSpread
        .Row = lngRow
        .Col = lngCol
        If lngRow2 <> 0 Then
            .Row2 = lngRow2
        Else
            .Row2 = lngRow
        End If
        If lngRow2 <> 0 Then
            .Col2 = lngCol2
        Else
            .Col2 = lngCol
        End If
        .BlockMode = True
        If bolEdit Then
            .BackColor = LC_lng_va_Edit_Color
        Else
            .BackColor = LC_lng_va_UnEdit_Color
        End If
        .BlockMode = False
    End With

End Sub

'=======================================================================================
'【使用用途】 チェックボックスを設定
'【関 数 名】 SetCheckBox
'【引    数】 ByRef objSpread   As Object：スプレッド
'【引    数】 ByVal lngCol      As long  ：列番号
'【引    数】 ByVal lngRow      As long  ：行番号
'【返    値】
'【更 新 日】
'【備    考】
'=======================================================================================
Private Sub SetCheckBox(ByRef objSpread As Object, _
                        ByVal lngCol As Long, _
                        ByVal lngRow As Long)

    With objSpread
        .Col = lngCol
        .Col2 = lngCol
        .Row = lngRow
        .Row2 = lngRow
        .CellType = CellTypeCheckBox                        ' ｾﾙﾀｲﾌﾟの設定
        .TypeCheckText = ""                                 ' ﾁｪｯｸﾎﾞｯｸｽ ｷｬﾌﾟｼｮﾝ
        .TypeCheckType = TypeCheckTypeNormal                ' ﾁｪｯｸﾎﾞｯｸｽ ﾀｲﾌﾟ
        .TypeCheckTextAlign = TypeCheckTextAlignRight       ' ﾃｷｽﾄ配置
        .TypeHAlign = TypeHAlignCenter                      ' 水平配置
        .TypeVAlign = TypeVAlignCenter                      ' 垂直配置
        .TypeCheckCenter = True                             ' 中央配置
    End With

End Sub

'===========================================================================
'【使用用途】 入力チェック
'【関 数 名】 P_EntryCheck
'【引    数】
'【返    値】 Boolean
'【更 新 日】
'【備    考】
'===========================================================================
Private Function P_EntryCheckSerial(ByVal lngLineNo As Long) As Boolean

    Dim varCHECK    As Variant
    Dim varSERIAL   As Variant
    Dim strKBN      As String

    P_EntryCheckSerial = False

    With vaData
        Call .GetText(LC_lngCol_CHECK, lngLineNo, varCHECK)
        Call .GetText(LC_lngCol_SERIAL, lngLineNo, varSERIAL)
        If Nz(varCHECK) = "1" Then
            If P_SRANOCheck(CStr(Nz(varSERIAL)), strKBN) = True Then
                If strKBN <> LC_strSYUKA Then
                    Exit Function
                End If
            End If
        End If
    End With

    P_EntryCheckSerial = True

End Function

'===========================================================================
'【使用用途】 シリアル№存在チェック（ワークファイル）
'【関 数 名】 P_SRANOCheckWK
'【引    数】 ByVal strSRANO As String  :シリアル№
'【返    値】 Boolean
'【更 新 日】
'【備    考】
'===========================================================================
Private Function P_SRANOCheckWK(ByVal strSRANO As String) As Boolean

    Dim strSQL      As String
    Dim Usr_Ody_LC  As U_Ody
    Dim strWKRPTCLTID   As String
    Dim strWKSRANO   As String

    P_SRANOCheckWK = False

    strWKRPTCLTID = Left(L_strRPTCLTID & Space(5), 5)
    strWKSRANO = Left(strSRANO & Space(13), 13)

    'SQL文作成
    strSQL = vbNullString
    strSQL = strSQL & " SELECT  * "
    strSQL = strSQL & " FROM    SRAET52"
    strSQL = strSQL & " WHERE   RPTCLTID <> '" & strWKRPTCLTID & "'"
    strSQL = strSQL & "   AND   SRANO = '" & strWKSRANO & "'"

    Call CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody_LC, strSQL)

    If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '取得データ有
        P_SRANOCheckWK = True
    End If

    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody_LC)

Exit Function
Errlabel:
    Call GP_MsgBox(Critical, "データ取得時にエラーが発生しました。(P_SRANOCheck)" & vbCrLf & _
                Err.Number & ":" & Err.Description _
                , vbCritical + vbOKOnly)
End Function

'=======================================================================================
'【使用用途】 テキスト項目を設定
'【関 数 名】 SetEdit
'【引    数】 ByRef objSpread   As Object：スプレッド
'【引    数】 ByVal lngCol      As long  ：列番号
'【引    数】 ByVal lngRow      As long  ：行番号
'【返    値】
'【更 新 日】
'【備    考】
'=======================================================================================
Private Sub SetEdit(ByRef objSpread As Object, _
                    ByVal lngCol As Long, _
                    ByVal lngRow As Long)
    With vaData
        .ReDraw = False
        .Col = lngCol
        .Col2 = lngCol
        .Row = lngRow
        .Row2 = lngRow
        .CellType = CellTypeEdit                        '文字入力
        .TypeEditCharSet = TypeEditCharSetAlphanumeric  '半角英数字
        .GridSolid = True
        .GridColor = &H0&
        .Position = PositionCenterLeft
        '入力桁数をセット
        Select Case lngCol
            Case LC_lngCol_SERIAL: .TypeMaxEditLen = C_lngSERIAL_Len
        End Select
        .ReDraw = True
    End With
End Sub
'=========================================================================【 メソッド 】=

'2008/08/06 ADD START FKS)NAKATA
'===========================================================================
'【使用用途】 入出庫番号取得(受注トラン．PUDLNO)
'【関 数 名】 P_GET_PUDLNO
'【引    数】 ByVal strJDNNO As String  :受注番号
'【返    値】 Boolean
'【更 新 日】
'【備    考】 受注トランの入出庫番号を検索する
'===========================================================================
Private Function P_GET_PUDLNO(ByVal strJdnNo As String, _
                                ByRef strPUDLNO As String) As Boolean

    Dim strSQL      As String
    Dim Usr_Ody_LC  As U_Ody
    Dim wkJDNNO   As String
    Dim wkLINNO   As String

    P_GET_PUDLNO = False
    strPUDLNO = ""
    
    wkJDNNO = Left(strJdnNo, 6)
    wkLINNO = Right(strJdnNo, 3)

    'SQL文作成
    strSQL = vbNullString
'''' UPD 2010/10/21  FKS) T.Yamamoto    Start    連絡票№FC10102001
'    strSQL = strSQL & " SELECT  * " & vbCrLf
'    strSQL = strSQL & " FROM    JDNTRA" & vbCrLf
'    strSQL = strSQL & " WHERE   JDNNO    = '" & wkJDNNO & "'" & vbCrLf
'    strSQL = strSQL & " AND     LINNO    = '" & wkLINNO & "'" & vbCrLf
    '海外に出荷された場合、受注とシリアルの入出庫番号が異なるため、国内取引に限定
    strSQL = strSQL & " SELECT * " & vbCrLf
    strSQL = strSQL & " FROM   JDNTRA TRA " & vbCrLf
    strSQL = strSQL & " WHERE  JDNNO  = '" & wkJDNNO & "' " & vbCrLf
    strSQL = strSQL & " AND    LINNO  = '" & wkLINNO & "' " & vbCrLf
    strSQL = strSQL & " AND    EXISTS ( " & vbCrLf
    strSQL = strSQL & "                 SELECT * " & vbCrLf
    strSQL = strSQL & "                 FROM   JDNTHA THA " & vbCrLf
    strSQL = strSQL & "                 WHERE  THA.DATNO = TRA.DATNO " & vbCrLf
''''CHG START TOM)KATSUKAWA 2011/02/24 *** 受注取引区分の条件を追加
'   strSQL = strSQL & "                 AND    THA.FRNKB = '0' " & vbCrLf
    strSQL = strSQL & "                 AND   (THA.FRNKB = '0' OR THA.JDNTRKB = '21') " & vbCrLf
''''CHG END   TOM)KATSUKAWA 2011/02/24
    strSQL = strSQL & "               ) " & vbCrLf
'''' UPD 2010/10/21  FKS) T.Yamamoto    End
    
    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
    
    If CF_Ora_EOF(Usr_Ody_LC) = False Then
        '取得データ有
        strPUDLNO = CF_Ora_GetDyn(Usr_Ody_LC, "PUDLNO", "")
        P_GET_PUDLNO = True
    End If

    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody_LC)
    
Exit Function
Errlabel:
    Call GP_MsgBox(Critical, "データ取得時にエラーが発生しました。(P_GET_PUDLNO)" & vbCrLf & _
                Err.Number & ":" & Err.Description _
                , vbCritical + vbOKOnly)
End Function

''2008/08/06 ADD E.N.D FKS)NAKATA
