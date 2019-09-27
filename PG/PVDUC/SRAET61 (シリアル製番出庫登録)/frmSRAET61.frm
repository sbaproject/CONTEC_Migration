VERSION 5.00
Object = "{B02F3647-766B-11CE-AF28-C3A2FBE76A13}#3.0#0"; "SPR32X30.ocx"
Object = "{0D181820-63E5-11D1-8959-E995CE93D831}#2.3#0"; "Threed5.ocx"
Begin VB.Form FR_SSSMAIN 
   BorderStyle     =   1  '固定(実線)
   Caption         =   "シリアル№登録"
   ClientHeight    =   5880
   ClientLeft      =   150
   ClientTop       =   735
   ClientWidth     =   5625
   Icon            =   "frmSRAET61.frx":0000
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5880
   ScaleWidth      =   5625
   StartUpPosition =   3  'Windows の既定値
   Begin VB.TextBox txtDummy 
      Appearance      =   0  'ﾌﾗｯﾄ
      BorderStyle     =   0  'なし
      Height          =   270
      Left            =   4800
      TabIndex        =   15
      Top             =   4800
      Width           =   15
   End
   Begin Threed5.SSPanel5 SSPanel53 
      Height          =   615
      Left            =   0
      TabIndex        =   13
      Top             =   0
      Width           =   5655
      _ExtentX        =   9975
      _ExtentY        =   1085
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "ＭＳ Ｐゴシック"
         Size            =   9
         Charset         =   128
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      OutLine         =   -1  'True
      Begin VB.Image CM_Execute 
         Height          =   330
         Left            =   480
         Picture         =   "frmSRAET61.frx":030A
         Top             =   120
         Width           =   360
      End
      Begin VB.Image CM_EndCm 
         Height          =   330
         Left            =   120
         Picture         =   "frmSRAET61.frx":095C
         Top             =   120
         Width           =   360
      End
      Begin VB.Image Image1 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   555
         Left            =   0
         Top             =   0
         Width           =   3075
      End
   End
   Begin VB.Frame Frame1 
      Height          =   735
      Left            =   240
      TabIndex        =   9
      Top             =   6000
      Width           =   4095
      Begin VB.Image IM_Denkyu 
         Height          =   330
         Index           =   2
         Left            =   2400
         Picture         =   "frmSRAET61.frx":0AE6
         Top             =   240
         Width           =   300
      End
      Begin VB.Image IM_Denkyu 
         Height          =   330
         Index           =   1
         Left            =   1920
         Picture         =   "frmSRAET61.frx":0C70
         Top             =   240
         Width           =   300
      End
      Begin VB.Image IM_Execute 
         Height          =   330
         Index           =   2
         Left            =   1440
         Picture         =   "frmSRAET61.frx":0DFA
         Top             =   240
         Width           =   360
      End
      Begin VB.Image IM_Execute 
         Height          =   330
         Index           =   1
         Left            =   1080
         Picture         =   "frmSRAET61.frx":144C
         Top             =   240
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Height          =   330
         Index           =   2
         Left            =   600
         Picture         =   "frmSRAET61.frx":1A9E
         Top             =   240
         Width           =   360
      End
      Begin VB.Image IM_EndCm 
         Height          =   330
         Index           =   1
         Left            =   240
         Picture         =   "frmSRAET61.frx":1C28
         Top             =   240
         Width           =   360
      End
   End
   Begin Threed5.SSPanel5 SSPanel52 
      Height          =   330
      Left            =   720
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
      Left            =   720
      TabIndex        =   7
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
   Begin FPSpread.vaSpread vaData 
      Height          =   3150
      Left            =   720
      TabIndex        =   0
      Top             =   1935
      Width           =   4200
      _Version        =   196608
      _ExtentX        =   7408
      _ExtentY        =   5556
      _StockProps     =   64
      AllowMultiBlocks=   -1  'True
      ArrowsExitEditMode=   -1  'True
      BackColorStyle  =   1
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
      Position        =   3
      ProcessTab      =   -1  'True
      Protect         =   0   'False
      ScrollBars      =   2
      SelectBlockOptions=   0
      SpreadDesigner  =   "frmSRAET61.frx":1DB2
      UserResize      =   0
      VisibleCols     =   3
      VisibleRows     =   1
   End
   Begin Threed5.SSPanel5 FM_Panel3D15 
      Height          =   645
      Index           =   0
      Left            =   0
      TabIndex        =   10
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
         TabIndex        =   11
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
            TabIndex        =   12
            Text            =   "frmSRAET61.frx":2107
            Top             =   70
            Width           =   5955
         End
      End
      Begin VB.Image IM_Denkyu 
         Appearance      =   0  'ﾌﾗｯﾄ
         Height          =   330
         Index           =   0
         Left            =   180
         Picture         =   "frmSRAET61.frx":213E
         Top             =   135
         Width           =   300
      End
   End
   Begin VB.Image Image2 
      Height          =   3375
      Left            =   600
      Top             =   1800
      Width           =   4455
   End
   Begin VB.Label lblDUMMY 
      Height          =   375
      Left            =   0
      TabIndex        =   14
      Top             =   0
      Width           =   135
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
      Left            =   1755
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
      Left            =   1695
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
      Left            =   1680
      TabIndex        =   1
      Top             =   825
      Width           =   930
   End
   Begin VB.Label Label8 
      Alignment       =   2  '中央揃え
      Appearance      =   0  'ﾌﾗｯﾄ
      BackColor       =   &H80000005&
      BackStyle       =   0  '透明
      BorderStyle     =   1  '実線
      ForeColor       =   &H80000008&
      Height          =   330
      Left            =   1605
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
      Left            =   1605
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
      Left            =   1605
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
'*  【作 成 日】2006/08/31  SYSTEM CREATE CO,.Ltd.
'*  【更 新 日】2006/11/09
'*  【備    考】パラメータ(PGID)を追加
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
Private L_strPGID                       As String   '2006.11.09
Private L_strSBNNO                      As String
Private L_strHINCD                      As String
Private L_strURISU                      As String

' プロパティ値格納用変数
Dim mstrRPTCLTID                        As String
Dim mstrPGID                            As String
Dim mstrSBNNO                           As String   '2006.11.09
Dim mstrHINCD                           As String
Dim mstrURISU                           As String

'スプレッド編集行の最大値
Private L_lngMAX_EditRow                As Long

'LeaveCellイベント判定フラグ
Private L_blnLeaveCell                  As Boolean  'True:イベント発生, False:イベント未発生
'ADD START FKS)INABA 2008/01/28 *************************************************************
Private L_blnLeaveCell2                  As Boolean  'True:イベント発生, False:イベント未発生
'ADD  END  FKS)INABA 2008/01/28 *************************************************************

'更新確認メッセージキャンセル時のActiveCellセット用
Private L_LastCol                       As Long     '列
Private L_LastRow                       As Long     '行
'-------------------------------------------------------------------------【 変数宣言 】-

'-【 定数宣言 】-------------------------------------------------------------------------
'タイトル
Private Const LC_strPG_ID               As String = "SRAET61        "
Private Const LC_strTitle               As String = "シリアル№登録"

' パラメータ スイッチ定義
Private Const mcPARAM_RPTCLTID          As String = "/RPTCLTID:"
Private Const mcPARAM_PGID              As String = "/PGID:"        '2006.11.09
Private Const mcPARAM_SBNNO             As String = "/SBNNO:"
Private Const mcPARAM_HINCD             As String = "/HINCD:"
Private Const mcPARAM_URISU             As String = "/URISU:"

'スプレッド背景色
Private Const LC_lng_va_Edit_Color      As Long = &HFFFF&
Private Const LC_lng_va_UnEdit_Color    As Long = &HFFFFFF
Private Const LC_lng_va_Lock_Color      As Long = &HC0C0C0

'スプレッドの行
Private Const LC_lngMAX_ROW             As Long = 999999    '最大行数
Private Const LC_lngDEFAULT_ROW         As Long = 9999      'デフォルトセット行

'スプレッドの項目
Private Const LC_lngCol_NO              As Long = 1         '行№
Private Const LC_lngCol_SERIAL          As Long = 2         'シリアル№
Private Const LC_lngCol_TNANO           As Long = 3         '棚番

'* 最大入力桁数
Private Const C_lngSERIAL_Len           As Long = 13        'シリアル№
Private Const C_lngTNANO_Len            As Long = 9         '棚番

'出荷済み区分
Private Const LC_strSYUKA               As String = "02"

'SQL文生成時のモード
Private Enum enumCREATE_MODE
    Insert
    Delete
End Enum

'メッセージ名
Private Const LC_strAPPEND              As String = "_APPEND        "   '共通メッセージ
Private Const LC_strCURSOR              As String = "_CURSOR        "   '共通メッセージ

'メッセージＩＤ
Private Const CommonMSGSQ               As String = "0"     '* 共通メッセージＩＤ
Private Const Entry                     As String = "0"     '* 登録確認メッセージ
Private Const EntryFinal                As String = "1"     '* 登録後メッセージ
Private Const SerialNoNull              As String = "2"     '* シリアル№NULL
Private Const TnaNoNull                 As String = "3"     '* 棚番NULL
Private Const InfSyuka                  As String = "4"     '* 出荷済みのシリアル№は入力されました。よろしいですか？
Private Const InfLineLittle             As String = "5"     '* 入力行数が数量を下回っています。登録してよろしいですか？
Private Const InfLineOver               As String = "6"     '* 入力行数が数量を超えています。
Private Const SerialNoExists            As String = "7"     '* 入力しているシリアル№管理テーブルに存在しない為、使用できません。
Private Const DoubleSerialNo            As String = "8"     '* シリアル№が重複しています。
Private Const SerialKeta                As String = "9"     '* シリアル№は %N 桁まで入力可能です。
Private Const TnaNoKeta                 As String = "A"     '* 棚番は %N 桁まで入力可能です。
Private Const NotHINCD                  As String = "B"     '* %CDという商品コードは存在しません。
Private Const InfLineLittle2            As String = "C"     '* 入力行数が数量を下回っています。
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

'===========================================================================
'【使用用途】 [終了]ボタンクリック時
'【関 数 名】 CM_EndCm_Click
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub CM_EndCm_Click()
    '* セル背景色を解除
    With vaData
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_NO, 1, False, LC_lngCol_TNANO, .MaxRows)
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

    L_blnLeaveCell2 = False
    'スプレッドの入力チェック
    If P_EntryCheck(lngRow) = False Then
'ADD START FKS)INABA 2007/12/15 *******************************
'        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, SerialNoNull, Mst_Inf)
'        msgMsgBox = GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
'ADD  END  FKS)INABA 2007/12/15 *******************************
        L_blnLeaveCell = False
        L_blnLeaveCell2 = True
        CM_Execute.Picture = IM_Execute(1).Picture
        Exit Sub
    End If
    L_blnLeaveCell2 = True
    strMSGKBN = "1"
'DEL START FKS)INABA 2007/12/15 ***********************
    msgMsgBox = GP_MsgBox(Insert, "", LC_strTitle)
    If msgMsgBox = vbNo Then Exit Sub
'DEL  END  FKS)INABA 2007/12/15 ***********************
        
    '有効行数と数量を比較しメッセージを切り替える
    If lngRow > CLng(lblURISU.Caption) Then
        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, InfLineOver, Mst_Inf)
        If intRet <> 0 Then
            L_blnLeaveCell = False
            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
            Exit Sub
        End If
        Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
        '* セル背景色を解除
        With vaData
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, False, LC_lngCol_TNANO, .MaxRows)
        End With
        If L_LastCol > 0 And L_LastRow > 0 Then
            Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
            Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
        Else
            If L_lngMAX_EditRow + 1 > LC_lngMAX_ROW Then
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, LC_lngMAX_ROW, True)
                Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, LC_lngMAX_ROW)
            Else
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, L_lngMAX_EditRow + 1, True)
                Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, L_lngMAX_EditRow + 1)
            End If
        End If
        CM_Execute.Picture = IM_Execute(1).Picture
        Exit Sub
    End If
    
    '有効行数と数量を比較しメッセージを切り替える
    If CLng(lblURISU.Caption) > lngRow Then
        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, InfLineLittle, Mst_Inf)
        If intRet <> 0 Then
            L_blnLeaveCell = False
            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
            Exit Sub
'ADD START FKS)INABA 2007/12/18 ****************************************
        Else
            msgMsgBox = GP_MsgBox(Execute, Mst_Inf.MSGCM, LC_strTitle)
'ADD  END  FKS)INABA 2007/12/18 ****************************************
        End If
    Else
        strMSGKBN = "0"
        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strAPPEND, CommonMSGSQ, Mst_Inf)
        If intRet <> 0 Then
            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
            L_blnLeaveCell = False
            CM_Execute.Picture = IM_Execute(1).Picture
            Exit Sub
        End If
    End If
'DEL START FKS)INABA 2007/12/18 *************************************
'    msgMsgBox = GP_MsgBox(Execute, Mst_Inf.MSGCM, LC_strTitle)
'DEL  END  FKS)INABA 2007/12/18 *************************************
    If msgMsgBox <> vbYes Then
        CM_Execute.Picture = IM_Execute(1).Picture
        L_blnLeaveCell = False
        If L_LastCol > 0 And L_LastRow > 0 Then
            Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
            Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
        Else
            If L_lngMAX_EditRow + 1 > LC_lngMAX_ROW Then
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, LC_lngMAX_ROW, True)
                Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, LC_lngMAX_ROW)
            Else
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, L_lngMAX_EditRow + 1, True)
                Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, L_lngMAX_EditRow + 1)
            End If
        End If
        Exit Sub
    End If
    
    Screen.MousePointer = vbHourglass
    
    '登録処理
    If P_Main() = True Then
''''''* データ登録後は画面を閉じる
'''''        strMSGKBN = "1"
'''''        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, EntryFinal, Mst_Inf)
'''''        If intRet <> 0 Then
'''''            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
'''''            GoTo EndLabel
'''''        End If
'''''        Call GP_MsgBox(Infomation, Mst_Inf.MSGCM, LC_strTitle)
'''''        'データ初期表示
'''''        Call P_Show_Data
        Call CM_EndCm_Click
        Exit Sub
    End If

EndLabel:
    '* セル背景色を設定
    Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
    Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)
    
    Screen.MousePointer = vbDefault
    
    L_blnLeaveCell = False
    
    CM_Execute.Picture = IM_Execute(1).Picture
    
End Sub

'===========================================================================
'【使用用途】 [登録]ボタンMouseDown時
'【関 数 名】 CM_Execute_MouseDown
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub CM_Execute_MouseDown(Button As Integer, Shift As Integer, X As Single, Y As Single)
    L_blnLeaveCell = False
    CM_Execute.Picture = IM_Execute(2).Picture
End Sub

'===========================================================================
'【使用用途】 [登録]ボタンMouseUp時
'【関 数 名】 CM_Execute_MouseUp
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub CM_Execute_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)
    L_blnLeaveCell = False
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
    L_strPGID = Replace(strArry(1), mcPARAM_PGID, "")           '2006.11.09
    L_strSBNNO = Replace(strArry(2), mcPARAM_SBNNO, "")
    L_strHINCD = Replace(strArry(3), mcPARAM_HINCD, "")
    L_strURISU = Replace(strArry(4), mcPARAM_URISU, "")
    
    'パラメータで不備があれば本画面は起動させない
    If L_strRPTCLTID = "" Then
        Call GP_MsgBox(Critical, "ワークステーションＩＤが設定されていません。", LC_strTitle)
        End
    End If
'2006.11.09 ADD - [STRAT]
    If L_strPGID = "" Then
        Call GP_MsgBox(Critical, "プログラムＩＤが設定されていません。", LC_strTitle)
        End
    End If
'2006.11.09 ADD - [E N D]
    If L_strSBNNO = "" Then
        Call GP_MsgBox(Critical, "製番が設定されていません。", LC_strTitle)
        End
    End If
    If L_strHINCD = "" Then
        Call GP_MsgBox(Critical, "製品コードが設定されていません。", LC_strTitle)
        End
    End If
    If L_strURISU = "" Then
        Call GP_MsgBox(Critical, "数量が設定されていません。", LC_strTitle)
        End
    Else
        If IsNumeric(L_strURISU) = False Then
            Call GP_MsgBox(Critical, "数量が数値ではありません。", LC_strTitle)
            End
        End If
    End If
    
    'フォームのクリア
    Call P_FromClear
    
    'DB接続
    Call CF_Ora_USR1_Open   'USR1
    Call CF_Ora_USR9_Open   'USR9
    
    '受け取ったパラメータを画面にセット
    lblHIN1.Caption = L_strHINCD
    If P_GET_HINNMA(L_strHINCD, strHINNM) = True Then
        lblHIN2.Caption = strHINNM
    Else
        '存在しない商品コード
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
    
    '画面の初期表示
    Call P_Show_Data
    
    L_LastCol = -1
    L_LastRow = -1
'ADD START FKS)INABA 2008/01/28 *************************************************************
    L_blnLeaveCell2 = True
'ADD  END  FKS)INABA 2008/01/28 *************************************************************
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
'【備    考】スプレッドが最終行に達した時、新規入力行を生成
'===========================================================================
Private Sub vaData_EditChange(ByVal Col As Long, ByVal Row As Long)

    With vaData
        If LC_lngMAX_ROW <> .MaxRows Then
            If .MaxRows = Row Then
                .MaxRows = .MaxRows + 1
                .Row = 1
                .Row2 = .MaxRows
                .Col = LC_lngCol_NO
                .Col2 = LC_lngCol_NO
                .BlockMode = True
                .BackColor = Me.BackColor
                .Protect = True
                .Lock = True
                Call .SetText(LC_lngCol_NO, Row + 1, Row + 1)
                Call SetEdit(vaData, LC_lngCol_SERIAL, Row + 1)
                Call SetEdit(vaData, LC_lngCol_TNANO, Row + 1)
            End If
        End If
    End With

End Sub

'===========================================================================
'【使用用途】 セル移動時
'【関 数 名】 vaData_LeaveCell
'【更 新 日】
'【備    考】
'===========================================================================
Private Sub vaData_LeaveCell(ByVal Col As Long, ByVal Row As Long, ByVal NewCol As Long, ByVal NewRow As Long, Cancel As Boolean)
    
    Dim lngI            As Long
    Dim lngJ            As Long
    Dim varNO           As Variant
    Dim varSERIAL       As Variant
    Dim varSERIAL_C     As Variant
    Dim varTNANO        As Variant
    Dim strKBN          As String
    Dim msgMsgBox       As VbMsgBoxResult
    Dim strMSGKBN       As String
    Dim strMSGNM        As String
    Dim Mst_Inf         As TYPE_DB_SYSTBH
    Dim intRet          As Integer
'ADD START FKS)INABA 2008/01/28 *************************************************************
    If L_blnLeaveCell2 = False Then Exit Sub
'ADD  END  FKS)INABA 2008/01/28 *************************************************************
    
    L_blnLeaveCell = True

    '* セル背景色を解除
    With vaData
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, False, LC_lngCol_TNANO, .MaxRows)
    End With

    'データ入力最大行を取得
    L_lngMAX_EditRow = P_Get_EditMaxRow
    
    '入力文字を大文字に変換してセルに再セット
     Select Case Col
        Case LC_lngCol_SERIAL
            Call vaData.GetText(LC_lngCol_SERIAL, Row, varSERIAL)
            Call vaData.SetText(LC_lngCol_SERIAL, Row, StrConv(Nz(varSERIAL), vbUpperCase))
        Case LC_lngCol_TNANO
            Call vaData.GetText(LC_lngCol_TNANO, Row, varTNANO)
            Call vaData.SetText(LC_lngCol_TNANO, Row, StrConv(RTrim(Nz(varTNANO)), vbUpperCase))
    End Select
   
    'セルの値を取得
    Call vaData.GetText(LC_lngCol_SERIAL, Row, varSERIAL)
    Call vaData.GetText(LC_lngCol_TNANO, Row, varTNANO)
    
    'シリアル番号のとき
    Select Case Col
        Case LC_lngCol_SERIAL
            strMSGKBN = "1"
            With vaData
                If Nz(varSERIAL) <> "" Then
                    '存在チェック（管理テーブル）
                    If P_SRANOCheck(CStr(varSERIAL), strKBN) = False Then
                        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, SerialNoExists, Mst_Inf)
                        If intRet <> 0 Then
                            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
                            Exit Sub
                        End If
                        Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
                        If Col > 0 And NewRow > 0 Then
                            Call GP_Va_Col_EditColor(vaData, Col, Row, True)
                            Call GP_SpActiveCell(vaData, Col, Row)
                        Else
                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
                            Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)
                        End If
                        Exit Sub
                    Else
                        '* シリアル№重複チェック
                        lngJ = 1
                        For lngJ = 1 To L_lngMAX_EditRow
                            varSERIAL_C = ""
                            If Row <> lngJ Then
                                Call .GetText(LC_lngCol_SERIAL, lngJ, varSERIAL_C)
                                If Nz(varSERIAL_C) <> "" Then
                                    If varSERIAL = varSERIAL_C Then
                                        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, DoubleSerialNo, Mst_Inf)
                                        If intRet <> 0 Then
                                            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
                                            Exit Sub
                                        End If
                                        Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
                                        If Row > 0 Then
                                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, Row, True)
                                            Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, Row)
                                        Else
                                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
                                            Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)
                                        End If
                                        Exit Sub
                                    End If
                                End If
                            End If
                        Next
                    
                    '* 在庫処理区分の出荷済み判定を行い、該当したとき警告メッセージを表示
                        If strKBN = LC_strSYUKA Then
                            intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, InfSyuka, Mst_Inf)
                            If intRet <> 0 Then
                                Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
                                Exit Sub
                            End If
                            msgMsgBox = GP_MsgBox(Execute, Mst_Inf.MSGCM, LC_strTitle)
                            If msgMsgBox <> vbYes Then
                                If Col > 0 And Row > 0 Then
                                    Call GP_Va_Col_EditColor(vaData, Col, Row, True)
                                    Call GP_SpActiveCell(vaData, Col, Row)
                                Else
                                    Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
                                    Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)
                                End If
                                Exit Sub
                            End If
                        End If
                    End If
'''                    '存在チェック（ワークテーブル）
'''                        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, InfSyuka, Mst_Inf)
'''                        If intRet <> 0 Then
'''                            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
'''                            Exit Sub
'''                        End If
'''                        msgMsgBox = GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
'''                        If msgMsgBox <> vbYes Then
'''                            Exit Sub
'''                        End If
'''                    End If
                Else
'DEL START FKS)INABA 2007/12/18 *********************************************************************
'                    If Nz(varTNANO) <> "" Then
'                        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, SerialNoNull, Mst_Inf)
'                        If intRet <> 0 Then
'                            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
'                            Exit Sub
'                        End If
'                        msgMsgBox = GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
'                        If msgMsgBox <> vbYes Then
'                            If NewCol > 0 And NewRow > 0 Then
'                                Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
'                                Call GP_SpActiveCell(vaData, NewCol, NewRow)
'                            Else
'                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
'                                Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)
'                            End If
'                            Exit Sub
'                        End If
'                    End If
'DEL  END  FKS)INABA 2007/12/18 *********************************************************************
                End If
            End With
    '棚番のとき
        Case LC_lngCol_TNANO
            With vaData
'CHG START FKS)INABA 2008/01/29 **************************************************
                If Nz(varSERIAL) <> "" And Nz(varTNANO) = "" And NewRow <> Row Then
'                If Nz(varSERIAL) <> "" And Nz(varTNANO) = ""  Then
'CHG  END  FKS)INABA 2008/01/29 **************************************************
                    strMSGKBN = "1"
                    intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, TnaNoNull, Mst_Inf)
                    If intRet <> 0 Then
                        Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
                        Exit Sub
                    End If
                    Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
                    If Row > 0 Then
                        Call GP_Va_Col_EditColor(vaData, Col, Row, True)
                        Call GP_SpActiveCell(vaData, Col, Row)
                    Else
                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
                        Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)
                    End If
                    Exit Sub
                End If
            End With
            
    End Select
    
    If NewRow - 1 > 0 Then
        '上から順番に入力する仕様である為、前行の値をNULLチェックしNULLならエラー
        Call vaData.GetText(LC_lngCol_SERIAL, NewRow - 1, varSERIAL)
        Call vaData.GetText(LC_lngCol_TNANO, NewRow - 1, varTNANO)
'CHG START FKS)INABA 2007/12/18 *********************************************************
        If Nz(varTNANO) = "" Then
'        If Nz(varSERIAL) = "" Then
'CHG START FKS)INABA 2007/12/18 *********************************************************
            strMSGKBN = "0"
            intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strCURSOR, CommonMSGSQ, Mst_Inf)
            If intRet <> 0 Then
                Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
                Exit Sub
            End If
            Call GP_MsgBox(Critical, Mst_Inf.MSGCM, LC_strTitle)
            If Row > 0 Then
                Call GP_Va_Col_EditColor(vaData, Col, Row, True)
                Call GP_SpActiveCell(vaData, Col, Row)
            Else
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
                Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)
            End If
            Exit Sub
        End If
    End If
    
    '最終入力行のときは[登録]ボタン押下時の処理呼出
'''    If Col = LC_lngCol_TNANO And (Row > L_lngMAX_EditRow Or Row = vaData.MaxRows) Then
'''        Call vaData.GetText(LC_lngCol_SERIAL, NewRow, varSERIAL)
'''        If Nz(varSERIAL) = "" Then
'''            L_lngMAX_EditRow = P_Get_EditMaxRow
'''            L_blnLeaveCell = True
'''            L_LastCol = Col
'''            L_LastRow = Row
'''            Call CM_Execute_Click
'''            L_LastCol = -1
'''            L_LastRow = -1
'''            L_blnLeaveCell = False
'''        End If
'''    End If
    
    If L_blnLeaveCell = True Then
        '* セル背景色を設定
        If NewCol <> -1 And NewRow <> -1 Then
            Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
        End If
    End If
    
    L_blnLeaveCell = False

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
                Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, .ActiveRow)
            Else
                Call GP_SpActiveCell(vaData, .ActiveCol, .ActiveRow)
            End If
''''    Else                            '2006.09.28
''''        CM_Execute.SetFocus         '2006.09.28
        Else
            txtDummy.SetFocus
        End If
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, .ActiveRow, True)
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
        .Col2 = LC_lngCol_NO
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
        .Col2 = LC_lngCol_NO
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
    
    'スプレッドのクリア
    Call P_vaData_Init
        
    'データの取得。
    If P_Get_Data(Usr_Ody_LC) = True Then
        'データを画面に表示する。
        Call P_Set_Data(Usr_Ody_LC)
    Else
        intLen = Len(CStr(LC_lngMAX_ROW))
        For lngI = 1 To vaData.MaxRows
            Call vaData.SetText(LC_lngCol_NO, lngI, Right(Space(intLen) & CStr(lngI), intLen))
        Next
    End If

    'クローズ
    Call CF_Ora_CloseDyn(Usr_Ody_LC)
    
    L_blnLeaveCell = False
    
End Function

'===========================================================================
'【使用用途】 データセット
'【関 数 名】 P_Set_Data
'【引    数】 ByRef Usr_Ody_LC As U_Ody   :ダイナセット情報構造体
'【返    値】 Boolean
'【更 新 日】
'【備    考】
'===========================================================================
Private Function P_Set_Data(ByRef Usr_Ody_LC As U_Ody) As Boolean

    Dim lngI        As Long
    Dim lngJ        As Long
    Dim blnFLG      As Boolean
    Dim intLen      As Integer
    Dim lngRecCount As Long

On Error GoTo ErrLbl:
    
    P_Set_Data = False
    
    lngI = 0
    blnFLG = False
    
    intLen = Len(CStr(LC_lngMAX_ROW))
    
    With vaData
        .ReDraw = False
        'スプレッドの行数の設定
        .MaxRows = 0
        'スプレッドにデータを表示する。
        Do Until CF_Ora_EOF(Usr_Ody_LC) = True
            .MaxRows = .MaxRows + 1
            lngI = lngI + 1
            Call .SetText(LC_lngCol_NO, lngI, Right(Space(intLen) & CStr(lngI), intLen))
            Call SetEdit(vaData, LC_lngCol_SERIAL, lngI)
            Call .SetText(LC_lngCol_SERIAL, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", ""))
            Call SetEdit(vaData, LC_lngCol_TNANO, lngI)
            Call .SetText(LC_lngCol_TNANO, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "LOCATION", ""))
            Call CF_Ora_MoveNext(Usr_Ody_LC)
            .Col = LC_lngCol_NO
            .Col2 = LC_lngCol_NO
            .Row = .MaxRows
            .Row2 = .MaxRows
            .BackColor = Me.BackColor
        Loop
        
        '初期表示するスプレッド行数は最低LC_lngDEFAULT_ROW行とする
        lngRecCount = Usr_Ody_LC.Obj_Ody.RecordCount
        L_lngMAX_EditRow = lngRecCount
        If lngRecCount > LC_lngDEFAULT_ROW Then
            .MaxRows = lngRecCount
        Else
            .MaxRows = LC_lngDEFAULT_ROW
            blnFLG = True
        End If

        If blnFLG = True Then
            For lngJ = lngI To vaData.MaxRows
                Call .SetText(LC_lngCol_NO, lngJ, Right(Space(intLen) & CStr(lngJ), intLen))
                Call SetEdit(vaData, LC_lngCol_SERIAL, lngJ)
                Call SetEdit(vaData, LC_lngCol_TNANO, lngJ)
                .Col = LC_lngCol_NO
                .Col2 = LC_lngCol_NO
                .Row = .MaxRows
                .Row2 = .MaxRows
                .BackColor = Me.BackColor
            Next
        End If
        
        '背景色の設定
        Call P_Va_BackColor
        Call P_Va_Lock
        
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
'【更 新 日】
'【備    考】
'===========================================================================
Private Function P_Get_Data(ByRef Usr_Ody_LC As U_Ody) As Boolean

Dim strSQL          As String
Dim strWKRPTCLTID   As String
Dim strWKPGID       As String
Dim strWKSBNNO      As String

On Error GoTo Errlabel:
    
    P_Get_Data = False
    
    strWKRPTCLTID = Left(L_strRPTCLTID & Space(5), 5)
    strWKPGID = Left(L_strPGID & Space(7), 7)
    strWKSBNNO = Left(L_strSBNNO & Space(20), 20)
    
    'SQL文作成
    strSQL = ""
    strSQL = strSQL & vbCrLf & "Select"
    strSQL = strSQL & vbCrLf & " RPTCLTID"
    strSQL = strSQL & vbCrLf & " PGID"
    strSQL = strSQL & vbCrLf & ",SBNNO"
    strSQL = strSQL & vbCrLf & ",HINCD"
    strSQL = strSQL & vbCrLf & ",URISU"
    strSQL = strSQL & vbCrLf & ",SRALINNO"
    strSQL = strSQL & vbCrLf & ",SRANO"
    strSQL = strSQL & vbCrLf & ",LOCATION"
    strSQL = strSQL & vbCrLf & ",WRTTM"
    strSQL = strSQL & vbCrLf & ",WRTDT"
    strSQL = strSQL & vbCrLf & " From   SRAET61"
    strSQL = strSQL & vbCrLf & " Where  RPTCLTID = " & "'" & StChk(strWKRPTCLTID) & "'"
    strSQL = strSQL & vbCrLf & "   And  PGID     = " & "'" & StChk(strWKPGID) & "'"
    strSQL = strSQL & vbCrLf & "   And  SBNNO    = " & "'" & StChk(strWKSBNNO) & "'"
    strSQL = strSQL & vbCrLf & " Order By   SRALINNO"

    'DBアクセス
    Call CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody_LC, strSQL)

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

    Dim lngI    As Long
    Dim lngLine As Long
    Dim intLen  As Integer

    lngI = 0
    lngLine = 0
    intLen = Len(CStr(LC_lngMAX_ROW))

    With vaData
        'スプレッドのクリア
        .ReDraw = False
        .Action = ActionClearText
        .MaxRows = LC_lngDEFAULT_ROW
            Call SetEdit(vaData, LC_lngCol_NO, 1)
            Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
            Call SetEdit(vaData, LC_lngCol_TNANO, 1)
        '行番号をセット
        For lngI = 0 To vaData.MaxRows
            lngLine = lngLine + 1
            Call .SetText(LC_lngCol_NO, lngLine, Right(Space(intLen) & CStr(lngLine), intLen))
            Call SetEdit(vaData, LC_lngCol_NO, lngLine)
            Call SetEdit(vaData, LC_lngCol_SERIAL, lngLine)
            Call SetEdit(vaData, LC_lngCol_TNANO, lngLine)
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
    strSQL = strSQL & "   AND   HINCD    = '" & strWKHINCD & "'" & vbCrLf
    
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
'【使用用途】 シリアル№存在チェック（ワークファイル）
'【関 数 名】 P_SRANOCheckWK
'【引    数】 ByVal strSRANO As String  :シリアル№
'【返    値】 Boolean
'【更 新 日】
'【備    考】
'===========================================================================
Private Function P_SRANOCheckWK(ByVal strSRANO As String) As Boolean

    Dim strSQL          As String
    Dim Usr_Ody_LC      As U_Ody
    Dim strWKRPTCLTID   As String
    Dim strWKPGID       As String
    Dim strWKSRANO      As String

    P_SRANOCheckWK = False
    
    strWKRPTCLTID = Left(L_strRPTCLTID & Space(5), 5)
    strWKPGID = Left(L_strPGID & Space(7), 7)
    strWKSRANO = Left(strSRANO & Space(13), 13)

    'SQL文作成
    strSQL = vbNullString
    strSQL = strSQL & " SELECT  * "
    strSQL = strSQL & " FROM    SRAET61"
    strSQL = strSQL & " WHERE  ( RPTCLTID <> '" & strWKRPTCLTID & "'"
    strSQL = strSQL & "    OR   PGID <> '" & strWKPGID & "')"
    strSQL = strSQL & "   AND   SRANO = '" & strWKSRANO & "'"
    
    Call CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody_LC, strSQL)

    If CF_Ora_EOF(Usr_Ody_LC) = True Then
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

'===========================================================================
'【使用用途】 スプレッド入力チェック（メイン）
'【関 数 名】 P_EntryCheck
'【引    数】 ByRef lngEntryLine As Long  :有効行数
'【返    値】 Boolean
'【更 新 日】
'【備    考】
'===========================================================================
Private Function P_EntryCheck(ByRef lngEntryLine As Long) As Boolean
    
    P_EntryCheck = False
    
    'NULLチェック、シリアル№存在チェック、シリアル№重複チェック
    If P_NULLCheck(lngEntryLine) = False Then Exit Function
    
    P_EntryCheck = True

End Function

'===========================================================================
'【使用用途】 スプレッド入力チェック、シリアル№存在チェック
'【関 数 名】 P_NULLCheck
'【引    数】 ByRef lngEntryLine As Long  :有効行数
'【返    値】 Boolean
'【更 新 日】
'【備    考】
'===========================================================================
Private Function P_NULLCheck(ByRef lngEntryLine As Long) As Boolean

    Dim lngI        As Long
    Dim lngJ        As Long
    Dim varNO       As Variant
    Dim varSERIAL   As Variant
    Dim varSERIAL_C As Variant
    Dim varTNANO    As Variant
    Dim strKBN      As String
    Dim msgMsgBox   As VbMsgBoxResult
    Dim strMSGKBN   As String
    Dim strMSGNM    As String
    Dim Mst_Inf     As TYPE_DB_SYSTBH
    Dim intRet      As Integer
    
    strMSGKBN = "1"
    lngEntryLine = 0
    
    P_NULLCheck = False

    '* セル背景色を解除
    With vaData
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, False, LC_lngCol_TNANO, .MaxRows)
    End With
    
    'データ入力最大行を取得
    L_lngMAX_EditRow = P_Get_EditMaxRow
'ADD START FKS)INABA 2007/12/15 ******************
    If L_lngMAX_EditRow = 0 Then
        Exit Function
'ADD START FKS)INABA 2008/01/23 ******************
    ElseIf Val(lblURISU.Caption) < L_lngMAX_EditRow Then
        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, InfLineOver, Mst_Inf)
        Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
        Exit Function
    ElseIf Val(lblURISU.Caption) > L_lngMAX_EditRow Then
        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, InfLineLittle2, Mst_Inf)
        Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
        Exit Function
'ADD  END  FKS)INABA 2008/01/23 ******************
    End If
'ADD  END  FKS)INABA 2007/12/15 ******************
    For lngI = 1 To L_lngMAX_EditRow
        With vaData
            'スプレッドデータを取得
            Call .GetText(LC_lngCol_NO, lngI, varNO)
            Call .GetText(LC_lngCol_SERIAL, lngI, varSERIAL)
            Call .GetText(LC_lngCol_TNANO, lngI, varTNANO)
        
            If varSERIAL <> vbNullString Then
                    '* シリアル№重複チェック
                    lngJ = 1
                    For lngJ = 1 To L_lngMAX_EditRow
                        varSERIAL_C = ""
                        If lngI <> lngJ Then
                            Call .GetText(LC_lngCol_SERIAL, lngJ, varSERIAL_C)
                            If Nz(varSERIAL_C) <> "" Then
                                If varSERIAL = varSERIAL_C Then
                                    intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, DoubleSerialNo, Mst_Inf)
                                    If intRet <> 0 Then
                                        Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
                                        Exit Function
                                    End If
                                    Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
                                    If lngJ > 0 Then
                                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, lngJ, True)
                                        Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, lngJ)
                                    Else
                                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, lngI, True)
                                        Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, lngI)
                                    End If
                                    Exit Function
                                End If
                            End If
                        End If
                    Next

                '棚番NULLチェック
                If varTNANO = vbNullString Then
                    intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, TnaNoNull, Mst_Inf)
                    If intRet <> 0 Then
                        Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
                        Exit Function
                    End If
                    Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
                    If lngI > 0 Then
                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_TNANO, lngI, True)
                        Call GP_SpActiveCell(vaData, LC_lngCol_TNANO, lngI)
                    Else
                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
                        Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)
                    End If
                    Exit Function
'DEL START FKS)INABA 2007/12/18 ***************************
'                Else
'                    If Nz(varSERIAL) = "" Then
'                        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, SerialNoNull, Mst_Inf)
'                        If intRet <> 0 Then
'                            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
'                            Exit Function
'                        End If
'                        Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
'                        If lngI > 0 Then
'                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_TNANO, lngI, True)
'                            Call GP_SpActiveCell(vaData, LC_lngCol_TNANO, lngI)
'                        Else
'                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
'                            Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)
'                        End If
'                        Exit Function
'                    End If
'DEL  END  FKS)INABA 2007/12/18 ***************************
                End If
                lngEntryLine = lngEntryLine + 1
            Else
                If varTNANO = "" Then
                    '* セル背景色を解除
                    intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, TnaNoNull, Mst_Inf)
                    If intRet <> 0 Then
                        Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
                        Exit Function
                    End If
                    With vaData
                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, False, LC_lngCol_TNANO, .MaxRows)
                    End With
                    If lngI > 0 Then
                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_TNANO, lngI, True)
                        Call GP_SpActiveCell(vaData, LC_lngCol_TNANO, lngI)
                    Else
                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
                        Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)
                    End If
                    Exit Function
'DEL  END  FKS)INABA 2007/12/18 ***************************
'                Else
'DEL  END  FKS)INABA 2007/12/18 ***************************
                End If
'ADD START FKS)INABA 2007/12/18 ***************************
                lngEntryLine = lngEntryLine + 1
'ADD  END  FKS)INABA 2007/12/18 ***************************
            End If
            
        End With
    Next lngI
    
    P_NULLCheck = True

End Function

'===========================================================================
'【使用用途】 有効行の最大行数を取得
'【関 数 名】 P_Get_EditMaxRow
'【返    値】 Long
'【更 新 日】
'【備    考】
'===========================================================================
Private Function P_Get_EditMaxRow() As Long

    Dim lngI        As Long
    Dim lngLine     As Long
    Dim varSERIAL   As Variant
    Dim varTNANO    As Variant

    P_Get_EditMaxRow = 0
    
    lngI = 1
    With vaData
        For lngI = 1 To .MaxRows
            lngLine = .MaxRows - lngI
            Call .GetText(LC_lngCol_SERIAL, lngLine, varSERIAL)
            Call .GetText(LC_lngCol_TNANO, lngLine, varTNANO)
            If Nz(varSERIAL) <> "" Or Nz(varTNANO) <> "" Then
                P_Get_EditMaxRow = lngLine
                Exit For
            End If
        Next
    End With

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
'【更 新 日】
'【備    考】
'===========================================================================
Private Function P_EXECUTE_SQL(ByVal strMode As enumCREATE_MODE, _
                               ByVal strSRALINNO As String, _
                               ByVal strSRANO As String, _
                               ByVal strLOCATION As String, _
                               ByVal strWRTTM As String, _
                               ByVal strWRTDT As String) As Boolean
    Dim strSQL As String
    
    P_EXECUTE_SQL = False
    
    strSQL = vbNullString
                              
    Select Case strMode
        Case enumCREATE_MODE.Insert
            strSQL = strSQL & " INSERT INTO SRAET61 (" & vbCrLf
            strSQL = strSQL & "                      RPTCLTID," & vbCrLf
            strSQL = strSQL & "                      PGID," & vbCrLf                        '2006.11.09
            strSQL = strSQL & "                      SBNNO," & vbCrLf
            strSQL = strSQL & "                      HINCD," & vbCrLf
            strSQL = strSQL & "                      URISU," & vbCrLf
            strSQL = strSQL & "                      SRALINNO," & vbCrLf
            strSQL = strSQL & "                      SRANO," & vbCrLf
            strSQL = strSQL & "                      LOCATION, " & vbCrLf
            strSQL = strSQL & "                      WRTTM," & vbCrLf
            strSQL = strSQL & "                      WRTDT" & vbCrLf
            strSQL = strSQL & "                     )" & vbCrLf
            strSQL = strSQL & " VALUES  (" & vbCrLf
            strSQL = strSQL & "          '" & StChk(L_strRPTCLTID) & "'," & vbCrLf
            strSQL = strSQL & "          '" & StChk(L_strPGID) & "'," & vbCrLf              '2006.11.09
            strSQL = strSQL & "          '" & StChk(L_strSBNNO) & "'," & vbCrLf
            strSQL = strSQL & "          '" & StChk(L_strHINCD) & "'," & vbCrLf
'CHG START FKS)INABA 2007/12/18 *******************************************************
            strSQL = strSQL & "         1," & vbCrLf
'            strSQL = strSQL & "           " & StChk(L_strURISU) & "," & vbCrLf
'CHG  END  FKS)INABA 2007/12/18 *******************************************************
            strSQL = strSQL & "          '" & StChk(strSRALINNO) & "'," & vbCrLf
            strSQL = strSQL & "          '" & StChk(strSRANO) & "'," & vbCrLf
            strSQL = strSQL & "          '" & StChk(strLOCATION) & "'," & vbCrLf
            strSQL = strSQL & "          '" & StChk(strWRTTM) & "'," & vbCrLf
            strSQL = strSQL & "          '" & StChk(strWRTDT) & "'" & vbCrLf
            strSQL = strSQL & "         )" & vbCrLf
        
        Case enumCREATE_MODE.Delete
            strSQL = strSQL & " DELETE FROM SRAET61" & vbCrLf
            strSQL = strSQL & " WHERE  RPTCLTID = '" & StChk(L_strRPTCLTID) & "'" & vbCrLf
            strSQL = strSQL & "   AND  PGID     = '" & StChk(L_strPGID) & "'" & vbCrLf      '2006.11.09
            strSQL = strSQL & "   AND  SBNNO    = '" & StChk(L_strSBNNO) & "'" & vbCrLf
    
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
    Dim varNO       As Variant
    Dim varSERIAL   As Variant
    Dim varTNANO    As Variant
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
    If P_EXECUTE_SQL(Delete, _
                     Format(CLng(varNO), strZero), _
                     "", _
                     "", _
                     "", _
                     "") = False Then
        GoTo EndLbl:
    End If
    
    'INSERT
    lngI = 0
    lngLineNo = 0
    For lngI = 1 To L_lngMAX_EditRow
        With vaData
            Call .GetText(LC_lngCol_NO, lngI, varNO)
            Call .GetText(LC_lngCol_SERIAL, lngI, varSERIAL)
            Call .GetText(LC_lngCol_TNANO, lngI, varTNANO)
'CHG START FKS)INABA 2007/12/18 *********************************
            If Nz(varTNANO) <> "" Then
'            If Nz(varSERIAL) <> "" And Nz(varTNANO) <> "" Then
            If Nz(varSERIAL) = "" Then varSERIAL = " "
'CHG  END  FKS)INABA 2007/12/18 *********************************
                lngLineNo = lngLineNo + 1
                If P_EXECUTE_SQL(Insert, _
                                   Format(lngLineNo, strZero), _
                                   CStr(varSERIAL), _
                                   CStr(varTNANO), _
                                   L_strWRTTM, _
                                   L_strWRTDT) = False Then
                    GoTo EndLbl:
                End If
            End If
        End With
    Next lngI

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
        .ReDraw = False
        .Row = 1
        .Col = lngCol
        .Row2 = .MaxRows
        .Col2 = lngCol
        .BlockMode = True
        .BackColor = LC_lng_va_Lock_Color
        .BlockMode = False
        .ReDraw = True
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
        .ReDraw = False
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
        .ReDraw = True
    End With

End Sub

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
            Case LC_lngCol_TNANO: .TypeMaxEditLen = C_lngTNANO_Len
        End Select
        .ReDraw = True
    End With
End Sub

Private Sub vaData_Validate(Cancel As Boolean)
    L_lngMAX_EditRow = P_Get_EditMaxRow
End Sub
'=========================================================================【 メソッド 】=
