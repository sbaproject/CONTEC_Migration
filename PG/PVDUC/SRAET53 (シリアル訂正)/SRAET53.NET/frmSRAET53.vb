Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	'***************************************************************************************
	'*  【使用用途】シリアル№登録
	'*  【作 成 日】2006/09/29  SYSTEM CREATE CO.,Ltd.
	'*  【更 新 日】
	'*  【備    考】
	'***************************************************************************************
	
	'-【 変数宣言 】-------------------------------------------------------------------------
	'AppPath退避用
	Private L_strAppPath As String
	
	'データ登録用
	Private L_strWRTTM As String
	Private L_strWRTDT As String
	
	'パラメータ取得用
	Private L_strRPTCLTID As String
	Private L_strPRGID As String
	Private L_strHINCD As String
	Private L_strSBNNO As String
	Private L_strURISU As String
	
	' プロパティ値格納用変数
	Dim mstrRPTCLTID As String
	Dim mstrPRGID As String
	Dim mstrHINCD As String
	Dim mstrSBNNO As String
	Dim mstrURISU As String
	
	'スプレッド編集行の最大値
	Private L_lngMAX_EditRow As Integer
	
	'LeaveCellイベント判定フラグ
	Private L_blnLeaveCell As Boolean 'True:イベント発生, False:イベント未発生
	
	'更新確認メッセージキャンセル時のActiveCellセット用
	Private L_LastCol As Integer '列
	Private L_LastRow As Integer '行
	'-------------------------------------------------------------------------【 変数宣言 】-
	
	'-【 定数宣言 】-------------------------------------------------------------------------
	'タイトル
	Private Const LC_strPG_ID As String = "SRAET53        "
	Private Const LC_strTitle As String = "シリアル№登録"
	
	' パラメータ スイッチ定義
	Private Const mcPARAM_RPTCLTID As String = "/RPTCLTID:"
	Private Const mcPARAM_PRGID As String = "/PRGID:"
	Private Const mcPARAM_HINCD As String = "/HINCD:"
	Private Const mcPARAM_SBNNO As String = "/SBNNO:"
	Private Const mcPARAM_URISU As String = "/URISU:"
	
	'スプレッド背景色
	Private Const LC_lng_va_Edit_Color As Integer = &HFFFF
	'Private Const LC_lng_va_UnEdit_Color    As Long = &HFFFFFF
	Private Const LC_lng_va_Lock_Color As Integer = &H8000000F
	
	'スプレッドの行
	Private Const LC_lngMAX_ROW As Integer = 999999 '最大行数
	Private Const LC_lngDEFAULT_ROW As Integer = 9999 'デフォルトセット行
	
	'スプレッドの項目
	Private Const LC_lngCol_CHECK As Integer = 1 'チェックボックス
	Private Const LC_lngCol_NO As Integer = 2 '行№
	Private Const LC_lngCol_SERIAL As Integer = 3 'シリアル№
	Private Const LC_lngCol_LOCKBN As Integer = 4 '行ﾛｯｸ区分
	Private Const LC_lngCol_ZAISYOBN As Integer = 5 '在庫処理区分
	Private Const LC_lngCol_SBN As Integer = 6 '製番コード
	Private Const LC_lngCol_HID_SERIAL As Integer = 7 '訂正前シリアル№
	
	'* 最大入力桁数
	Private Const C_lngSERIAL_Len As Integer = 13 'シリアル№
	Private Const C_lngTNANO_Len As Integer = 9 '棚番
	
	' チェックボックス
	Private Const C_strCHECKBOX_ON As String = "1" 'ON
	Private Const C_strCHECKBOX_OFF As String = "9" 'OFF
	
	'行ロック区分
	Private Const LC_strLINE_LOCK As String = "1" 'ﾛｯｸ
	Private Const LC_strLINE_NOT_LOCK As String = "9" 'ﾛｯｸ解除
	
	'出荷済み区分
	Private Const LC_strSYUKA As String = "02"
	Private Const LC_strNOT_SYUKA As String = "  "
	
	'SQL文生成時のモード
	Private Enum enumCREATE_MODE
		Insert
		Update
		Delete
	End Enum
	
	'メッセージ名
	Private Const LC_strAPPEND As String = "_APPEND        " '共通メッセージ
	Private Const LC_strCURSOR As String = "_CURSOR        " '共通メッセージ
	
	'メッセージＩＤ
	Private Const CommonMSGSQ As String = "0" '* 共通メッセージＩＤ
	Private Const Entry As String = "0" '* 登録確認メッセージ
	Private Const EntryFinal As String = "1" '* 登録後メッセージ
	Private Const SerialNoNull As String = "2" '* シリアル№NULL
	Private Const TnaNoNull As String = "3" '* 棚番NULL
	Private Const InfSyuka As String = "4" '* 出荷済みのシリアル№は入力されました。よろしいですか？
	Private Const InfLineLittle As String = "5" '* 入力行数が数量を下回っています。登録してよろしいですか？
	Private Const InfLineOver As String = "6" '* 入力行数が数量を超えています。
	Private Const SerialNoExists As String = "7" '* 入力しているシリアル№管理テーブルに存在しない為、使用できません。
	Private Const DoubleSerialNo As String = "8" '* シリアル№が重複しています。
	Private Const SerialKeta As String = "9" '* シリアル№は %N 桁まで入力可能です。
	Private Const TnaNoKeta As String = "A" '* 棚番は %N 桁まで入力可能です。
	Private Const NotHINCD As String = "B" '* %CDという商品コードは存在しません。
	'-------------------------------------------------------------------------【 定数宣言 】-
	
	'=【 イベント 】=========================================================================
	
	'-【ﾌﾟﾙﾀﾞｳﾝﾒﾆｭｰ】-----------------------------------------------------------------------
	'===========================================================================
	'【使用用途】 登録(R)選択時
	'【関 数 名】 MN_Execute_Click
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Public Sub MN_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_Execute.Click
		Call CM_Execute_Click(CM_Execute, New System.EventArgs())
	End Sub
	
	'===========================================================================
	'【使用用途】 終了(X)選択時
	'【関 数 名】 MN_EditMn_Click
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Public Sub MN_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_EndCm.Click
		Call CM_EndCm_Click(CM_EndCm, New System.EventArgs())
	End Sub
	
	'===========================================================================
	'【使用用途】 画面初期化(S)選択時
	'【関 数 名】 MN_APPENDC_Click
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Public Sub MN_APPENDC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MN_APPENDC.Click
		'スプレッドのクリア
		Call P_vaData_Init()
		'画面の初期表示
		Call P_Show_Data()
	End Sub
	
	'===========================================================================
	'【使用用途】 [終了]ボタンクリック時
	'【関 数 名】 CM_EndCm_Click
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
		Me.Close()
	End Sub
	
	'===========================================================================
	'【使用用途】 [終了]ボタンMouseDown時
	'【関 数 名】 CM_EndCm_MouseDown
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub CM_EndCm_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		CM_EndCm.Image = IM_EndCm(2).Image
	End Sub
	
	'===========================================================================
	'【使用用途】 [終了]ボタンMouseUp時
	'【関 数 名】 CM_EndCm_MouseUp
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub CM_EndCm_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		CM_EndCm.Image = IM_EndCm(1).Image
	End Sub
	
	'===========================================================================
	'【使用用途】 [終了]ボタンMouseMove時
	'【関 数 名】 CM_EndCm_MouseMove
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub CM_EndCm_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_EndCm.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "メニューに戻ります。"
	End Sub
	
	'===========================================================================
	'【使用用途】 Image2 MouseMove時
	'【関 数 名】 Image2_MouseMove
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub Image2_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image2.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
	End Sub
	
	'===========================================================================
	'【使用用途】 [登録]ボタンクリック時
	'【関 数 名】 CM_Execute_Click
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub CM_Execute_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_Execute.Click
		
		Dim msgMsgBox As MsgBoxResult
		Dim lngRow As Integer
		'UPGRADE_ISSUE: TYPE_DB_SYSTBH オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		Dim strMSGKBN As String
		Dim strMSGNM As String
		
		strMSGKBN = "1"
		
		'スプレッドの入力チェック
		If P_EntryCheck(lngRow) = False Then
			L_blnLeaveCell = False
			CM_Execute.Image = IM_Execute(1).Image
			Exit Sub
		End If
		
		'有効行数と数量を比較しメッセージを切り替える
		If lngRow > CInt(lblURISU.Text) Then
			'UPGRADE_WARNING: CM_Execute_Click に変換されていないステートメントがあります。ソース コードを確認してください。
			If intRet <> 0 Then
				L_blnLeaveCell = False
				Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
				Exit Sub
			End If
			'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
			'* セル背景色を解除
			With vaData
				'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_CHECK, .MaxRows)
				Call P_Va_BackColor_LINE_LOCK()
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
			CM_Execute.Image = IM_Execute(1).Image
			Exit Sub
		End If
		
		'有効行数と数量を比較しメッセージを切り替える
		If CInt(lblURISU.Text) > lngRow Then
			'UPGRADE_WARNING: CM_Execute_Click に変換されていないステートメントがあります。ソース コードを確認してください。
			If intRet <> 0 Then
				L_blnLeaveCell = False
				Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
				Exit Sub
			End If
		Else
			strMSGKBN = "0"
			'UPGRADE_WARNING: CM_Execute_Click に変換されていないステートメントがあります。ソース コードを確認してください。
			If intRet <> 0 Then
				Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
				L_blnLeaveCell = False
				CM_Execute.Image = IM_Execute(1).Image
				Exit Sub
			End If
		End If
		
		'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		msgMsgBox = GP_MsgBox(Common.enmMsg.Execute, Mst_Inf.MSGCM, LC_strTitle)
		If msgMsgBox <> MsgBoxResult.Yes Then
			CM_Execute.Image = IM_Execute(1).Image
			L_blnLeaveCell = False
			'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_SERIAL, vaData.MaxRows)
			Call P_Va_BackColor_LINE_LOCK()
			If L_LastCol > 0 And L_LastRow > 0 Then
				Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
				Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
			Else
				If L_lngMAX_EditRow + 1 > LC_lngMAX_ROW Then
					Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, LC_lngMAX_ROW, True)
					Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, LC_lngMAX_ROW)
				Else
					Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, L_lngMAX_EditRow + 1, True)
					Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, L_lngMAX_EditRow + 1)
				End If
			End If
			Exit Sub
		End If
		
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'登録処理
		If P_Main() = True Then
			Call CM_EndCm_Click(CM_EndCm, New System.EventArgs())
			Exit Sub
		End If
		
EndLabel: 
		'* セル背景色を設定
		Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, True)
		Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, 1)
		
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		L_blnLeaveCell = False
		
		CM_Execute.Image = IM_Execute(1).Image
		
	End Sub
	
	'===========================================================================
	'【使用用途】 [登録]ボタンMouseDown時
	'【関 数 名】 CM_Execute_MouseDown
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub CM_Execute_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		L_blnLeaveCell = False
		CM_Execute.Image = IM_Execute(2).Image
	End Sub
	
	'===========================================================================
	'【使用用途】 [登録]ボタンMouseUp時
	'【関 数 名】 CM_Execute_MouseUp
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub CM_Execute_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		L_blnLeaveCell = False
		CM_Execute.Image = IM_Execute(1).Image
	End Sub
	
	'===========================================================================
	'【使用用途】 [登録]ボタンMouseMove時
	'【関 数 名】 CM_Execute_MouseMove
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub CM_Execute_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles CM_Execute.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		IM_Denkyu(0).Image = IM_Denkyu(2).Image
		TX_Message.Text = "登録します。"
	End Sub
	
	'===========================================================================
	'【使用用途】 [ダミー]イメージMouseMove時
	'【関 数 名】 Image1_MouseMove
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub Image1_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles Image1.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y) 'Hand Made
		Call Init_Prompt()
	End Sub
	
	'===========================================================================
	'【使用用途】 フォームロード時
	'【関 数 名】 Form_Load
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		Dim lngIndex As Integer
		Dim strHINNM As String
		Dim CommandLine As String
		Dim strArry() As String ' 引数取得配列
		Dim strRet As String ' 引数ワーク
		Dim strRetU As String ' 引数ワーク
		Dim intRet As Short
		Dim strMSGKBN As String
		'UPGRADE_ISSUE: TYPE_DB_SYSTBH オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim Mst_Inf As TYPE_DB_SYSTBH
		
		Me.KeyPreview = True
		
		'同一プログラムが起動していた場合は終了する
		'UPGRADE_ISSUE: App プロパティ App.PrevInstance はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
		If App.PrevInstance Then
			Call GP_MsgBox(Common.enmMsg.Critical, "既に起動しています。", LC_strTitle)
			End
		End If
		
		'フォームの位置をセット
		Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		
		'AppPathの退避
		L_strAppPath = My.Application.Info.DirectoryPath
		
		'パラメータ取得
		strArry = Split(Replace(VB.Command(), """", ""), " ")
		L_strRPTCLTID = Replace(strArry(0), mcPARAM_RPTCLTID, "")
		L_strPRGID = Replace(strArry(1), mcPARAM_PRGID, "")
		L_strHINCD = Replace(strArry(2), mcPARAM_HINCD, "")
		L_strSBNNO = Replace(strArry(3), mcPARAM_SBNNO, "")
		L_strURISU = Replace(strArry(4), mcPARAM_URISU, "")
		
		'パラメータで不備があれば本画面は起動させない
		If L_strRPTCLTID = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "ワークステーションＩＤが設定されていません。", LC_strTitle)
			End
		End If
		If L_strPRGID = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "プログラムＩＤが設定されていません。", LC_strTitle)
			End
		End If
		If L_strHINCD = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "製品コードが設定されていません。", LC_strTitle)
			End
		End If
		If L_strSBNNO = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "製番が設定されていません。", LC_strTitle)
			End
		End If
		If L_strURISU = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "売上数量が設定されていません。", LC_strTitle)
			End
		Else
			If IsNumeric(L_strURISU) = False Then
				Call GP_MsgBox(Common.enmMsg.Critical, "売上数量が数値ではありません。", LC_strTitle)
				End
			End If
		End If
		
		'フォームのクリア
		Call P_FromClear()
		
		'DB接続
		Call CF_Ora_USR1_Open() 'USR1
		Call CF_Ora_USR9_Open() 'USR9
		
		'受け取ったパラメータを画面にセット
		lblHIN1.Text = L_strHINCD
		If P_GET_HINNMA(L_strHINCD, strHINNM) = True Then
			lblHIN2.Text = strHINNM
		Else
			'存在しない商品コード
			strMSGKBN = "1"
			'UPGRADE_WARNING: Form_Load に変換されていないステートメントがあります。ソース コードを確認してください。
			If intRet <> 0 Then
				Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
				End
			End If
			'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call GP_MsgBox(Common.enmMsg.Exclamation, Replace(Mst_Inf.MSGCM, "%CD", L_strHINCD), LC_strTitle)
			End
		End If
		lblURISU.Text = L_strURISU
		
		'画面の初期表示
		Call P_Show_Data()
		
		L_LastCol = -1
		L_LastRow = -1
		
	End Sub
	
	'===========================================================================
	'【使用用途】 アンロード時
	'【関 数 名】 Form_QueryUnload
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		'DB接続解除
		Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
		eventArgs.Cancel = Cancel
	End Sub
	
	'===========================================================================
	'【使用用途】 キー押下時
	'【関 数 名】 Form_KeyPress
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub FR_SSSMAIN_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		If TypeOf Me.ActiveControl Is System.Windows.Forms.TextBox Or TypeOf Me.ActiveControl Is System.Windows.Forms.ComboBox Or TypeOf Me.ActiveControl Is System.Windows.Forms.RadioButton Then
			
			Call GP_CtrlSend(KeyAscii, Me)
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'===========================================================================
	'【使用用途】 スプレッドエディットモード変更時
	'【関 数 名】 vaData_EditChange
	'【更 新 日】
	'【備    考】スプレッドが最終行に達した時、新規入力行を生成
	'===========================================================================
	Private Sub vaData_EditChange(ByVal Col As Integer, ByVal Row As Integer)
		
		With vaData
			'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If LC_lngMAX_ROW <> .MaxRows Then
				'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If .MaxRows = Row Then
					'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.MaxRows = .MaxRows + 1
					'UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Row = 1
					'UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Row2 = .MaxRows
					'UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = LC_lngCol_NO
					'UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col2 = LC_lngCol_NO
					'UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.BlockMode = True
					'UPGRADE_WARNING: オブジェクト vaData.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
					'UPGRADE_WARNING: オブジェクト vaData.Protect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Protect = True
					'UPGRADE_WARNING: オブジェクト vaData.Lock の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Lock = True
					'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .SetText(LC_lngCol_NO, Row + 1, Row + 1)
					Call SetEdit(vaData, LC_lngCol_CHECK, Row + 1)
					Call SetEdit(vaData, LC_lngCol_SERIAL, Row + 1)
					Call SetEdit(vaData, LC_lngCol_LOCKBN, Row + 1)
					Call SetEdit(vaData, LC_lngCol_ZAISYOBN, Row + 1)
					Call SetEdit(vaData, LC_lngCol_SBN, Row + 1)
					Call SetEdit(vaData, LC_lngCol_HID_SERIAL, Row + 1)
				End If
			End If
		End With
		
	End Sub
	
	Private Sub vaData_KeyDown(ByRef KeyCode As Short, ByRef Shift As Short)
		Call F_SendKey(KeyCode)
	End Sub
	
	'===========================================================================
	'【使用用途】 セル移動時
	'【関 数 名】 vaData_LeaveCell
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub vaData_LeaveCell(ByVal Col As Integer, ByVal Row As Integer, ByVal NewCol As Integer, ByVal NewRow As Integer, ByRef Cancel As Boolean)
		
		Dim lngI As Integer
		Dim lngJ As Integer
		Dim varCHECK As Object
		Dim varNO As Object
		Dim varSERIAL As Object
		Dim varSERIAL_C As Object
		Dim varLOCKBN As Object
		Dim varNewRowLOCKBN As Object
		Dim varTNANO As Object
		Dim varZAISYOBN As Object
		Dim strKBN As String
		Dim msgMsgBox As MsgBoxResult
		Dim strMSGKBN As String
		Dim strMSGNM As String
		'UPGRADE_ISSUE: TYPE_DB_SYSTBH オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		
		L_blnLeaveCell = True
		
		'* セル背景色を解除
		With vaData
			'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_SERIAL, .MaxRows)
			Call P_Va_BackColor_LINE_LOCK()
		End With
		
		'データ入力最大行を取得
		L_lngMAX_EditRow = P_Get_EditMaxRow
		
		'セルの値を取得
		'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call vaData.GetText(LC_lngCol_ZAISYOBN, Row, varZAISYOBN)
		'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call vaData.GetText(LC_lngCol_CHECK, Row, varCHECK)
		'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call vaData.GetText(LC_lngCol_SERIAL, Row, varSERIAL)
		'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call vaData.GetText(LC_lngCol_LOCKBN, Row, varLOCKBN)
		If NewRow > 0 Then
			'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call vaData.GetText(LC_lngCol_LOCKBN, NewRow, varNewRowLOCKBN)
		End If
		
		'入力文字を大文字に変換してセルに再セット
		'UPGRADE_WARNING: オブジェクト Nz() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call vaData.SetText(LC_lngCol_SERIAL, Row, StrConv(Nz(varSERIAL), VbStrConv.UpperCase))
		
		Select Case Col
			'チェックボックスのとき
			Case LC_lngCol_CHECK
				With vaData
					'UPGRADE_WARNING: オブジェクト varLOCKBN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If varLOCKBN = LC_strLINE_LOCK Then
						If Row > 0 Then
							'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Row = .MaxRows Then
								Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row, True)
								Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row)
							Else
								If Row = NewRow Then
									Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row + 1, True)
									Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row + 1)
								Else
									If NewCol > 0 And NewRow > 0 Then
										If NewCol = LC_lngCol_NO Then
											Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
											Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
										ElseIf NewCol > LC_lngCol_SERIAL Then 
											'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
											If NewRow = .MaxRows Then
												'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
												Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .MaxRows, True)
												'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
												Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .MaxRows)
											Else
												Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
												Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
											End If
										Else
											'UPGRADE_WARNING: オブジェクト varNewRowLOCKBN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
											If varNewRowLOCKBN = LC_strLINE_LOCK Then
												Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
												Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
											Else
												Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, NewRow, True)
												Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, NewRow)
											End If
										End If
									End If
								End If
							End If
						Else
							Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
							Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
						End If
					Else
						If NewCol > 0 And NewRow > 0 Then
							If NewCol > LC_lngCol_SERIAL Then
								Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
								Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
							Else
								If NewCol = LC_lngCol_NO Then
									Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, NewRow, True)
									Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, NewRow)
								ElseIf NewCol > LC_lngCol_SERIAL Then 
									'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									If NewRow = .MaxRows Then
										'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .MaxRows, True)
										'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .MaxRows)
									Else
										Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
										Call GP_SpActiveCell(vaData, NewCol, NewRow)
									End If
								Else
									Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
									Call GP_SpActiveCell(vaData, NewCol, NewRow)
								End If
							End If
						End If
					End If
				End With
				
				'シリアル番号のとき
			Case LC_lngCol_SERIAL
				strMSGKBN = "1"
				With vaData
					'UPGRADE_WARNING: オブジェクト Nz(varSERIAL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Nz(varSERIAL) <> "" Then
						'存在チェック（管理テーブル）
						'UPGRADE_WARNING: オブジェクト varSERIAL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If P_SRANOCheck(CStr(varSERIAL), strKBN) = False Then
							'UPGRADE_WARNING: vaData_LeaveCell に変換されていないステートメントがあります。ソース コードを確認してください。
							If intRet <> 0 Then
								Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
								Exit Sub
							End If
							'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
							If Col > 0 And NewRow > 0 Then
								If Col > LC_lngCol_SERIAL Then
									'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									If Row = .MaxRows Then
										Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row, True)
										Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row)
									Else
										Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row + 1, True)
										Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row + 1)
									End If
								Else
									Call GP_Va_Col_EditColor(vaData, Col, Row, True)
									Call GP_SpActiveCell(vaData, Col, Row)
								End If
							Else
								Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
								Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
							End If
							Exit Sub
						Else
							'* シリアル№重複チェック
							lngJ = 1
							For lngJ = 1 To L_lngMAX_EditRow
								'UPGRADE_WARNING: オブジェクト varSERIAL_C の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								varSERIAL_C = ""
								If Row <> lngJ Then
									'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									Call .GetText(LC_lngCol_SERIAL, lngJ, varSERIAL_C)
									'UPGRADE_WARNING: オブジェクト Nz(varSERIAL_C) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									If Nz(varSERIAL_C) <> "" Then
										'UPGRADE_WARNING: オブジェクト varSERIAL_C の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										'UPGRADE_WARNING: オブジェクト varSERIAL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										If varSERIAL = varSERIAL_C Then
											'UPGRADE_WARNING: vaData_LeaveCell に変換されていないステートメントがあります。ソース コードを確認してください。
											If intRet <> 0 Then
												Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
												Exit Sub
											End If
											'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
											Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
											If Row > 0 Then
												Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, Row, True)
												Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, Row)
											Else
												Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
												Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
											End If
											Exit Sub
										End If
									End If
								End If
							Next 
							
							'* 取得した在庫区分を隠し項目にセット
							If Row > 0 Then
								'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								Call .SetText(LC_lngCol_ZAISYOBN, Row, strKBN)
							End If
							
							'* 在庫処理区分の出荷済み判定を行い、該当したとき警告メッセージを表示
							If strKBN = LC_strSYUKA Then
								'UPGRADE_WARNING: vaData_LeaveCell に変換されていないステートメントがあります。ソース コードを確認してください。
								If intRet <> 0 Then
									Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
									Exit Sub
								End If
								'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								msgMsgBox = GP_MsgBox(Common.enmMsg.Execute, Mst_Inf.MSGCM, LC_strTitle)
								If msgMsgBox <> MsgBoxResult.Yes Then
									If Col > 0 And Row > 0 Then
										Call GP_Va_Col_EditColor(vaData, Col, Row, True)
										Call GP_SpActiveCell(vaData, Col, Row)
									Else
										Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
										Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
									End If
									Exit Sub
								End If
							End If
						End If
						'シリアル№チェックがOKのときは自動でチェックボックスをONにする
						'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Call .SetText(LC_lngCol_CHECK, Row, C_strCHECKBOX_ON)
						
						If NewCol > LC_lngCol_SERIAL Then
							'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Row = .MaxRows Then
								Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row, True)
								Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row)
							Else
								Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row + 1, True)
								Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row + 1)
							End If
						ElseIf NewCol < 0 Then 
							'''                        Call GP_Va_Col_EditColor(vaData, LC_lngCol_HID_SERIAL, 1, True)
							'''                        Call GP_SpActiveCell(vaData, LC_lngCol_HID_SERIAL, 1)
						Else
							If NewRow < 0 Then
								'''                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_HID_SERIAL, 1, True)
								'''                            Call GP_SpActiveCell(vaData, LC_lngCol_HID_SERIAL, 1)
							Else
								If NewCol = LC_lngCol_NO Then
									Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
									Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
								Else
									Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
									Call GP_SpActiveCell(vaData, NewCol, NewRow)
								End If
							End If
						End If
					Else
						'UPGRADE_WARNING: オブジェクト varCHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If varCHECK = C_strCHECKBOX_ON Then
							'UPGRADE_WARNING: vaData_LeaveCell に変換されていないステートメントがあります。ソース コードを確認してください。
							If intRet <> 0 Then
								Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
								Exit Sub
							End If
							'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
							If Row > 0 Then
								Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, Row, True)
								Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, Row)
							Else
								'''                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
								'''                            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
							End If
							Exit Sub
						Else
							If NewCol > LC_lngCol_SERIAL Then
								'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								If Row = .MaxRows Then
									Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row, True)
									Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row)
								Else
									Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, Row + 1, True)
									Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, Row + 1)
								End If
							ElseIf NewCol < 0 Then 
								'''                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_HID_SERIAL, 1, True)
								'''                            Call GP_SpActiveCell(vaData, LC_lngCol_HID_SERIAL, 1)
							Else
								If NewRow < 0 Then
									'''                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_HID_SERIAL, 1, True)
									'''                                Call GP_SpActiveCell(vaData, LC_lngCol_HID_SERIAL, 1)
								Else
									If NewCol = LC_lngCol_NO Then
										Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
										Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
									Else
										'UPGRADE_WARNING: オブジェクト varNewRowLOCKBN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										If varNewRowLOCKBN = LC_strLINE_LOCK Then
											Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
											Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
										Else
											Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
											Call GP_SpActiveCell(vaData, NewCol, NewRow)
										End If
									End If
								End If
							End If
						End If
					End If
				End With
		End Select
		
		If NewRow - 1 > 0 Then
			'上から順番に入力する仕様である為、前行の値をNULLチェックしNULLならエラー
			'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call vaData.GetText(LC_lngCol_SERIAL, NewRow - 1, varSERIAL)
			'UPGRADE_WARNING: オブジェクト Nz(varSERIAL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Nz(varSERIAL) = "" Then
				strMSGKBN = "0"
				'UPGRADE_WARNING: vaData_LeaveCell に変換されていないステートメントがあります。ソース コードを確認してください。
				If intRet <> 0 Then
					Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
					Exit Sub
				End If
				'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call GP_MsgBox(Common.enmMsg.Critical, Mst_Inf.MSGCM, LC_strTitle)
				'* セル背景色を解除
				With vaData
					'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_SERIAL, .MaxRows)
					Call P_Va_BackColor_LINE_LOCK()
				End With
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
		'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If NewCol = LC_lngCol_LOCKBN And (NewRow > L_lngMAX_EditRow Or NewRow = vaData.MaxRows) Then
			'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call vaData.GetText(LC_lngCol_SERIAL, NewRow, varSERIAL)
			'UPGRADE_WARNING: オブジェクト Nz(varSERIAL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Nz(varSERIAL) = "" Then
				L_lngMAX_EditRow = P_Get_EditMaxRow
				L_blnLeaveCell = True
				L_LastCol = Col
				L_LastRow = Row
				Call CM_EndCm_Click(CM_EndCm, New System.EventArgs())
				L_LastCol = -1
				L_LastRow = -1
				L_blnLeaveCell = False
			End If
		End If
		
		If L_blnLeaveCell = True Then
			'* セル背景色を解除
			With vaData
				'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False, LC_lngCol_SERIAL, .MaxRows)
				Call P_Va_BackColor_LINE_LOCK()
			End With
			'* セル背景色を設定
			If NewCol <> -1 Or NewRow <> -1 Then
				'UPGRADE_WARNING: オブジェクト varNewRowLOCKBN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If NewCol > LC_lngCol_SERIAL Or varNewRowLOCKBN <> LC_strLINE_LOCK Then
					If NewCol = LC_lngCol_NO Then
						If Col = LC_lngCol_CHECK Then
							Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, NewRow, True)
							Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, NewRow)
						Else
							Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
							Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
						End If
					Else
						Call GP_Va_Col_EditColor(vaData, NewCol, NewRow, True)
						Call GP_SpActiveCell(vaData, NewCol, NewRow)
					End If
				Else
					Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, NewRow, True)
					Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, NewRow)
				End If
			Else
				Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
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
		
		Dim varLOCKBN As Object
		
		'カーソル制御。
		With vaData
			'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If .ActiveRow > 0 Then
				'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_LOCKBN, .ActiveRow, varLOCKBN)
				'UPGRADE_WARNING: オブジェクト varLOCKBN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If varLOCKBN = LC_strLINE_LOCK Then
					'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .ActiveRow, True)
					'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .ActiveRow)
				End If
			Else
				txtDummy.Focus()
			End If
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
		
		With vaData
			'UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row = 1
			'UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row2 = .MaxRows
			'UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col = LC_lngCol_NO
			'UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col2 = LC_lngCol_NO
			'UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BlockMode = True
			'UPGRADE_WARNING: オブジェクト vaData.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
			'UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BlockMode = False
		End With
		
	End Sub
	
	'===========================================================================
	'【使用用途】 スプレッド背景色設定(行ロック区分判定)
	'【関 数 名】 P_Va_BackColor_LINE_LOCK
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub P_Va_BackColor_LINE_LOCK()
		
		Dim lngRow As Integer
		Dim varLOCKBN As Object
		
		If IsNumeric(L_lngMAX_EditRow) = False Then
			Exit Sub
		Else
			If L_lngMAX_EditRow <= 0 Then
				Exit Sub
			End If
		End If
		
		With vaData
			lngRow = 1
			For lngRow = 1 To L_lngMAX_EditRow
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_LOCKBN, lngRow, varLOCKBN)
				'UPGRADE_WARNING: オブジェクト varLOCKBN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If varLOCKBN = LC_strLINE_LOCK Then
					Call GP_Va_Col_LockColor_Row(vaData, lngRow)
				End If
			Next 
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
			'UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row = 1
			'UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col = LC_lngCol_NO
			'UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row2 = .MaxRows
			'UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col2 = LC_lngCol_NO
			'UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BlockMode = True
			'UPGRADE_WARNING: オブジェクト vaData.Protect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Protect = True
			'UPGRADE_WARNING: オブジェクト vaData.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BackColor = LC_lng_va_Lock_Color
			'UPGRADE_WARNING: オブジェクト vaData.Lock の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Lock = True
			'UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BlockMode = False
		End With
		
	End Sub
	
	'===========================================================================
	'【使用用途】 スプレッド行ロック制御
	'【関 数 名】 P_Va_Lock_Row
	'【返    値】 Boolean
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub P_Va_Lock_Row(ByVal lngRow As Integer)
		
		With vaData
			'UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row = lngRow
			'UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col = LC_lngCol_NO
			'UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row2 = lngRow
			'UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col2 = LC_lngCol_SERIAL
			'UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BlockMode = True
			'UPGRADE_WARNING: オブジェクト vaData.Protect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Protect = True
			'UPGRADE_WARNING: オブジェクト vaData.Lock の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Lock = True
			'UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BlockMode = False
		End With
		
		Call GP_Va_Col_LockColor_Row(vaData, lngRow)
		
	End Sub
	
	'===========================================================================
	'【使用用途】 データ表示
	'【関 数 名】 P_Show_Data
	'【返    値】 Boolean
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Function P_Show_Data() As Boolean
		
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		Dim lngI As Integer
		Dim intLen As Short
		
		'データの取得。
		If P_Get_Data(Usr_Ody_LC) = True Then
			'データを画面に表示する。
			Call P_Set_Data(Usr_Ody_LC)
		Else
			Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
			Call SetEdit(vaData, LC_lngCol_LOCKBN, 1)
			Call SetEdit(vaData, LC_lngCol_ZAISYOBN, 1)
			Call SetEdit(vaData, LC_lngCol_SBN, 1)
			Call SetEdit(vaData, LC_lngCol_HID_SERIAL, 1)
			'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			vaData.MaxRows = LC_lngDEFAULT_ROW
			intLen = Len(CStr(LC_lngMAX_ROW))
			'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			For lngI = 1 To vaData.MaxRows
				Call SetEdit(vaData, LC_lngCol_CHECK, lngI)
				'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call vaData.SetText(LC_lngCol_NO, lngI, VB.Right(Space(intLen) & CStr(lngI), intLen))
			Next 
			Call P_Va_BackColor()
		End If
		
		Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
		Call GP_Va_Col_LockColor(vaData, LC_lngCol_NO)
		Call P_Va_Lock()
		
		
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
		
		Dim lngI As Integer
		Dim lngJ As Integer
		Dim blnFLG As Boolean
		Dim intLen As Short
		Dim lngRecCount As Integer
		Dim varLOCKBN As Object
		Dim varZAISYOBN As Object
		
		On Error GoTo ErrLbl
		
		P_Set_Data = False
		
		lngI = 0
		blnFLG = False
		
		intLen = Len(CStr(LC_lngMAX_ROW))
		
		With vaData
			Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
			Call SetEdit(vaData, LC_lngCol_LOCKBN, 1)
			Call SetEdit(vaData, LC_lngCol_ZAISYOBN, 1)
			Call SetEdit(vaData, LC_lngCol_SBN, 1)
			Call SetEdit(vaData, LC_lngCol_HID_SERIAL, 1)
			'UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = False
			'スプレッドの行数の設定
			'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MaxRows = 0
			'スプレッドにデータを表示する。
			Do Until CF_Ora_EOF(Usr_Ody_LC) = True
				'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.MaxRows = .MaxRows + 1
				lngI = lngI + 1
				Call SetEdit(vaData, LC_lngCol_CHECK, lngI)
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody_LC, CHKFLG, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Ora_GetDyn(Usr_Ody_LC, "CHKFLG", "") = C_strCHECKBOX_ON Then
					'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .SetText(LC_lngCol_CHECK, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "CHKFLG", ""))
				End If
				'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .SetText(LC_lngCol_NO, lngI, VB.Right(Space(intLen) & CStr(lngI), intLen))
				Call SetEdit(vaData, LC_lngCol_SERIAL, lngI)
				'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .SetText(LC_lngCol_SERIAL, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", ""))
				'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .SetText(LC_lngCol_HID_SERIAL, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", ""))
				'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .SetText(LC_lngCol_LOCKBN, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "LOCKBN", ""))
				'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .SetText(LC_lngCol_ZAISYOBN, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "ZAISYOBN", ""))
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_LOCKBN, lngI, varLOCKBN)
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_ZAISYOBN, lngI, varZAISYOBN)
				'UPGRADE_WARNING: オブジェクト varLOCKBN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If varLOCKBN = LC_strLINE_LOCK Then
					Call P_Va_Lock_Row(lngI)
				End If
				'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .SetText(LC_lngCol_SBN, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SBNNO", ""))
				Call CF_Ora_MoveNext(Usr_Ody_LC)
			Loop 
			
			'初期表示するスプレッド行数は最低LC_lngDEFAULT_ROW行とする
			'UPGRADE_WARNING: オブジェクト Usr_Ody_LC.Obj_Ody.RecordCount の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			lngRecCount = Usr_Ody_LC.Obj_Ody.RecordCount
			L_lngMAX_EditRow = lngRecCount
			If lngRecCount > LC_lngDEFAULT_ROW Then
				'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.MaxRows = lngRecCount
			Else
				'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.MaxRows = LC_lngDEFAULT_ROW
				blnFLG = True
			End If
			
			If blnFLG = True Then
				'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				For lngJ = lngI To vaData.MaxRows
					'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .SetText(LC_lngCol_NO, lngJ, VB.Right(Space(intLen) & CStr(lngJ), intLen))
					Call SetEdit(vaData, LC_lngCol_CHECK, lngJ)
					Call SetEdit(vaData, LC_lngCol_SERIAL, lngJ)
				Next 
			End If
			
			'UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = True
		End With
		
		P_Set_Data = True
		
		
		Exit Function
ErrLbl: 
		Call GP_MsgBox(Common.enmMsg.Critical, Err.Description)
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
		
		Dim strSQL As String
		Dim strWKRPTCLTID As String
		Dim strWKPRGID As String
		Dim strWKHINCD As String
		Dim strWKSBNNO As String
		
		On Error GoTo Errlabel
		
		P_Get_Data = False
		
		strWKRPTCLTID = VB.Left(L_strRPTCLTID & Space(5), 5)
		strWKPRGID = VB.Left(L_strPRGID & Space(7), 7)
		strWKHINCD = VB.Left(L_strHINCD & Space(10), 10)
		strWKSBNNO = VB.Left(L_strSBNNO & Space(20), 20)
		
		'SQL文作成
		strSQL = ""
		strSQL = strSQL & vbCrLf & "Select"
		strSQL = strSQL & vbCrLf & " RPTCLTID"
		strSQL = strSQL & vbCrLf & " PRGID"
		strSQL = strSQL & vbCrLf & ",HINCD"
		strSQL = strSQL & vbCrLf & ",SBNNO"
		strSQL = strSQL & vbCrLf & ",SRALINNO"
		strSQL = strSQL & vbCrLf & ",SRANO"
		strSQL = strSQL & vbCrLf & ",LOCKBN"
		strSQL = strSQL & vbCrLf & ",ZAISYOBN"
		strSQL = strSQL & vbCrLf & ",CHKFLG"
		strSQL = strSQL & vbCrLf & ",WRTTM"
		strSQL = strSQL & vbCrLf & ",WRTDT"
		strSQL = strSQL & vbCrLf & " From   SRAET53"
		strSQL = strSQL & vbCrLf & " Where  RPTCLTID = " & "'" & StChk(strWKRPTCLTID) & "'"
		strSQL = strSQL & vbCrLf & "   And  PRGID    = " & "'" & StChk(strWKPRGID) & "'"
		strSQL = strSQL & vbCrLf & "   And  HINCD    = " & "'" & StChk(strWKHINCD) & "'"
		strSQL = strSQL & vbCrLf & "   And  SBNNO    = " & "'" & StChk(strWKSBNNO) & "'" '2008/01/17 ADD
		strSQL = strSQL & vbCrLf & " Order By   SRALINNO"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = False Then
			'取得データ有
			P_Get_Data = True
		End If
		
		Exit Function
Errlabel: 
		Call GP_MsgBox(Common.enmMsg.Critical, "データ取得時にエラーが発生しました。(P_Get_Data)" & vbCrLf & Err.Number & ":" & Err.Description, CStr(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly))
	End Function
	
	'===========================================================================
	'【使用用途】 画面クリア
	'【関 数 名】 P_FromClear
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub P_FromClear()
		lblHIN1.Text = ""
		lblHIN2.Text = ""
		lblURISU.Text = ""
		CM_EndCm.Image = IM_EndCm(1).Image
		CM_Execute.Image = IM_Execute(1).Image
		TX_Message.Text = ""
	End Sub
	
	'===========================================================================
	'【使用用途】 スプレッド初期化
	'【関 数 名】 P_vaData_Init
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub P_vaData_Init()
		Dim TypeCheckTypeNormal As Object
		Dim CellTypeCheckBox As Object
		Dim ActionClearText As Object
		
		Dim lngI As Integer
		Dim lngLine As Integer
		Dim intLen As Short
		
		lngI = 0
		lngLine = 0
		intLen = Len(CStr(LC_lngMAX_ROW))
		
		With vaData
			'スプレッドのクリア
			'UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = False
			'UPGRADE_WARNING: オブジェクト vaData.Action の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト ActionClearText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Action = ActionClearText
			'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MaxRows = LC_lngDEFAULT_ROW
			'UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col = LC_lngCol_CHECK
			'UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col2 = LC_lngCol_CHECK
			'UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row = 1
			'UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row2 = .MaxRows
			'UPGRADE_WARNING: オブジェクト vaData.CellType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト CellTypeCheckBox の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.CellType = CellTypeCheckBox
			'UPGRADE_WARNING: オブジェクト vaData.GridColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.GridColor = &H0
			'UPGRADE_WARNING: オブジェクト vaData.GridSolid の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.GridSolid = True
			'UPGRADE_WARNING: オブジェクト vaData.TypeCheckType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト TypeCheckTypeNormal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.TypeCheckType = TypeCheckTypeNormal
			'UPGRADE_WARNING: オブジェクト vaData.TypeCheckCenter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.TypeCheckCenter = True
			'UPGRADE_WARNING: オブジェクト vaData.TypeCheckText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.TypeCheckText = ""
			Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
			Call SetEdit(vaData, LC_lngCol_LOCKBN, 1)
			Call SetEdit(vaData, LC_lngCol_ZAISYOBN, 1)
			Call SetEdit(vaData, LC_lngCol_SBN, 1)
			Call SetEdit(vaData, LC_lngCol_HID_SERIAL, 1)
			'行番号をセット
			'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			For lngI = 0 To vaData.MaxRows
				lngLine = lngLine + 1
				'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .SetText(LC_lngCol_NO, lngLine, VB.Right(Space(intLen) & CStr(lngLine), intLen))
				Call SetEdit(vaData, LC_lngCol_SERIAL, lngLine)
				Call SetEdit(vaData, LC_lngCol_LOCKBN, lngLine)
				Call SetEdit(vaData, LC_lngCol_ZAISYOBN, lngLine)
				Call SetEdit(vaData, LC_lngCol_SBN, lngLine)
				Call SetEdit(vaData, LC_lngCol_HID_SERIAL, lngLine)
			Next 
			'UPGRADE_WARNING: オブジェクト vaData.ColsFrozen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ColsFrozen = LC_lngCol_SERIAL
			'UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = True
		End With
		
		Call P_Va_BackColor()
		Call P_Va_Lock()
		
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
	Private Function P_GET_HINNMA(ByVal strHINCD As String, ByRef strHINNMA As String) As Boolean
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		Dim strWKHINCD As String
		
		P_GET_HINNMA = False
		
		'商品コードを10桁にする
		strWKHINCD = VB.Left(strHINCD & Space(10), 10)
		
		'SQL文作成
		strSQL = vbNullString
		strSQL = strSQL & " SELECT  HINNMA "
		strSQL = strSQL & " FROM    HINMTA"
		strSQL = strSQL & " WHERE   HINCD = '" & strWKHINCD & "'"
		
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = False Then
			'取得データ有
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strHINNMA = CF_Ora_GetDyn(Usr_Ody_LC, "HINNMA", "")
			P_GET_HINNMA = True
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
Errlabel: 
		Call GP_MsgBox(Common.enmMsg.Critical, "データ取得時にエラーが発生しました。(P_SRANOCheck)" & vbCrLf & Err.Number & ":" & Err.Description, CStr(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly))
	End Function
	
	'===========================================================================
	'【使用用途】 シリアル№存在チェック（管理テーブル）
	'【関 数 名】 P_SRANOCheck
	'【引    数】 ByVal strSRANO As String  :シリアル№
	'【返    値】 Boolean
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Function P_SRANOCheck(ByVal strSRANO As String, ByRef strZAISYOBN As String) As Boolean
		
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		Dim strWKSRANO As String
		Dim strWKHINCD As String
		
		P_SRANOCheck = False
		strZAISYOBN = ""
		
		strWKSRANO = VB.Left(strSRANO & Space(13), 13)
		strWKHINCD = VB.Left(L_strHINCD & Space(10), 10)
		
		'SQL文作成
		strSQL = vbNullString
		strSQL = strSQL & " SELECT  * " & vbCrLf
		strSQL = strSQL & " FROM    SRACNTTB" & vbCrLf
		strSQL = strSQL & " WHERE   SRANO    = '" & strWKSRANO & "'" & vbCrLf
		strSQL = strSQL & "   AND   HINCD    = '" & strWKHINCD & "'" & vbCrLf
		
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = False Then
			'取得データ有
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strZAISYOBN = CF_Ora_GetDyn(Usr_Ody_LC, "ZAISYOBN", "")
			
			P_SRANOCheck = True
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
Errlabel: 
		Call GP_MsgBox(Common.enmMsg.Critical, "データ取得時にエラーが発生しました。(P_SRANOCheck)" & vbCrLf & Err.Number & ":" & Err.Description, CStr(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly))
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
		
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		Dim strWKRPTCLTID As String
		Dim strWKPRGID As String
		Dim strWKHINCD As String
		Dim strWKSRANO As String
		Dim strWKSBNNO As String
		
		P_SRANOCheckWK = False
		
		strWKRPTCLTID = VB.Left(L_strRPTCLTID & Space(5), 5)
		strWKPRGID = VB.Left(L_strPRGID & Space(7), 7)
		strWKHINCD = VB.Left(L_strHINCD & Space(10), 10)
		strWKSRANO = VB.Left(strSRANO & Space(13), 13)
		strWKSBNNO = VB.Left(L_strSBNNO & Space(20), 20) '2008/01/17 ADD
		
		'SQL文作成
		strSQL = vbNullString
		strSQL = strSQL & " SELECT  * "
		strSQL = strSQL & " FROM    SRAET53"
		strSQL = strSQL & " WHERE   RPTCLTID = '" & strWKRPTCLTID & "'"
		strSQL = strSQL & "   AND   PRGID    = '" & strWKPRGID & "'"
		strSQL = strSQL & "   AND   HINCD    = '" & strWKHINCD & "'"
		strSQL = strSQL & "   AND   SRANO    = '" & strWKSRANO & "'"
		strSQL = strSQL & "   AND   SBNNO    = '" & strWKSBNNO & "'"
		
		Call CF_Ora_CreateDyn(gv_Odb_USR9, Usr_Ody_LC, strSQL)
		
		If CF_Ora_EOF(Usr_Ody_LC) = True Then
			'取得データ有
			P_SRANOCheckWK = True
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
Errlabel: 
		Call GP_MsgBox(Common.enmMsg.Critical, "データ取得時にエラーが発生しました。(P_SRANOCheck)" & vbCrLf & Err.Number & ":" & Err.Description, CStr(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly))
	End Function
	
	'===========================================================================
	'【使用用途】 スプレッド入力チェック（メイン）
	'【関 数 名】 P_EntryCheck
	'【引    数】 ByRef lngEntryLine As Long  :有効行数
	'【返    値】 Boolean
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Function P_EntryCheck(ByRef lngEntryLine As Integer) As Boolean
		
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
	Private Function P_NULLCheck(ByRef lngEntryLine As Integer) As Boolean
		
		Dim lngI As Integer
		Dim lngJ As Integer
		Dim varCHECK As Object
		Dim varNO As Object
		Dim varSERIAL As Object
		Dim varSERIAL_C As Object
		Dim varTNANO As Object
		Dim strKBN As String
		Dim msgMsgBox As MsgBoxResult
		Dim strMSGKBN As String
		Dim strMSGNM As String
		'UPGRADE_ISSUE: TYPE_DB_SYSTBH オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short
		
		strMSGKBN = "1"
		lngEntryLine = 0
		
		P_NULLCheck = False
		
		'データ入力最大行を取得
		L_lngMAX_EditRow = P_Get_EditMaxRow
		
		For lngI = 1 To L_lngMAX_EditRow
			With vaData
				'スプレッドデータを取得
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_CHECK, lngI, varCHECK)
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_NO, lngI, varNO)
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_SERIAL, lngI, varSERIAL)
				'UPGRADE_WARNING: オブジェクト varCHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If varCHECK = C_strCHECKBOX_ON Then
					'UPGRADE_WARNING: オブジェクト varSERIAL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If varSERIAL <> vbNullString Then
						'* シリアル№重複チェック
						lngJ = 1
						For lngJ = 1 To L_lngMAX_EditRow
							'UPGRADE_WARNING: オブジェクト varSERIAL_C の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							varSERIAL_C = ""
							If lngI <> lngJ Then
								'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								Call .GetText(LC_lngCol_SERIAL, lngJ, varSERIAL_C)
								'UPGRADE_WARNING: オブジェクト Nz(varSERIAL_C) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								If Nz(varSERIAL_C) <> "" Then
									'UPGRADE_WARNING: オブジェクト varSERIAL_C の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									'UPGRADE_WARNING: オブジェクト varSERIAL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									If varSERIAL = varSERIAL_C Then
										'UPGRADE_WARNING: P_NULLCheck に変換されていないステートメントがあります。ソース コードを確認してください。
										If intRet <> 0 Then
											Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
											Exit Function
										End If
										'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
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
						lngEntryLine = lngEntryLine + 1
					End If
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
	Private Function P_Get_EditMaxRow() As Integer
		
		Dim lngI As Integer
		Dim lngLine As Integer
		Dim varCHECK As Object
		Dim varSERIAL As Object
		Dim varHIDSERIAL As Object
		
		P_Get_EditMaxRow = 0
		
		lngI = 1
		With vaData
			'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			For lngI = 1 To .MaxRows
				'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				lngLine = .MaxRows - lngI
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_CHECK, lngLine, varCHECK)
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_SERIAL, lngLine, varSERIAL)
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_HID_SERIAL, lngLine, varHIDSERIAL)
				'UPGRADE_WARNING: オブジェクト Nz(varHIDSERIAL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト Nz(varSERIAL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Nz(varSERIAL) <> "" Or Nz(varHIDSERIAL) <> "" Then
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
	'【引    数】 ByVal strCHECK    As String           :チェックボックス
	'【引    数】 ByVal strSRANO    As String           :シリアル№
	'【引    数】 ByVal strLOCATION As String           :棚番
	'【引    数】 ByVal strZAISYOBN As String           :在庫処理区分
	'【引    数】 ByVal strSBN      As String           :製番コード
	'【引    数】 ByVal strWRTTM    As String           :データ作成時間
	'【引    数】 ByVal strWRTDT    As String           :データ作成日付
	'【返    値】 Boolean
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Function P_EXECUTE_SQL(ByVal strMode As enumCREATE_MODE, ByVal strSRALINNO As String, ByVal strCHECK As String, ByVal strSRANO As String, ByVal strZAISYOBN As String, ByVal strSBN As String, ByVal strWRTTM As String, ByVal strWRTDT As String) As Boolean
		Dim strSQL As String
		Dim strCHK As String
		Dim strKBN As String
		
		P_EXECUTE_SQL = False
		
		strSQL = vbNullString
		
		'チェックフラグ判定
		If strCHECK = C_strCHECKBOX_ON Then
			strCHECK = C_strCHECKBOX_ON
		Else
			strCHECK = C_strCHECKBOX_OFF
		End If
		
		'在庫処理区分判定
		If Trim(strZAISYOBN) <> "" Then
			strKBN = strZAISYOBN
		Else
			strKBN = LC_strNOT_SYUKA
		End If
		
		Select Case strMode
			Case enumCREATE_MODE.Insert
				strSQL = strSQL & " INSERT INTO SRAET53 (" & vbCrLf
				strSQL = strSQL & "                      RPTCLTID," & vbCrLf
				strSQL = strSQL & "                      PRGID," & vbCrLf
				strSQL = strSQL & "                      HINCD," & vbCrLf
				strSQL = strSQL & "                      SBNNO," & vbCrLf
				strSQL = strSQL & "                      SRALINNO," & vbCrLf
				strSQL = strSQL & "                      SRANO," & vbCrLf
				strSQL = strSQL & "                      LOCKBN," & vbCrLf
				strSQL = strSQL & "                      CHKFLG, " & vbCrLf
				strSQL = strSQL & "                      ZAISYOBN, " & vbCrLf
				strSQL = strSQL & "                      WRTTM," & vbCrLf
				strSQL = strSQL & "                      WRTDT" & vbCrLf
				strSQL = strSQL & "                     )" & vbCrLf
				strSQL = strSQL & " VALUES  (" & vbCrLf
				strSQL = strSQL & "          '" & StChk(L_strRPTCLTID) & "'," & vbCrLf
				strSQL = strSQL & "          '" & StChk(L_strPRGID) & "'," & vbCrLf
				strSQL = strSQL & "          '" & StChk(L_strHINCD) & "'," & vbCrLf
				''            strSQL = strSQL & "          '" & Space(20) & "'," & vbCrLf
				''            strSQL = strSQL & "          '" & StChk(strSBN) & "'," & vbCrLf       '2008/01/17 UPD-DEL
				strSQL = strSQL & "          '" & StChk(L_strSBNNO) & "'," & vbCrLf '2008/01/17 UPD-ADD
				strSQL = strSQL & "          '" & StChk(strSRALINNO) & "'," & vbCrLf
				strSQL = strSQL & "          '" & StChk(strSRANO) & "'," & vbCrLf
				strSQL = strSQL & "          '" & LC_strLINE_NOT_LOCK & "'," & vbCrLf
				strSQL = strSQL & "          '" & StChk(strCHECK) & "'," & vbCrLf
				strSQL = strSQL & "          '" & StChk(strKBN) & "'," & vbCrLf
				strSQL = strSQL & "          '" & StChk(strWRTTM) & "'," & vbCrLf
				strSQL = strSQL & "          '" & StChk(strWRTDT) & "'" & vbCrLf
				strSQL = strSQL & "         )" & vbCrLf
				
			Case enumCREATE_MODE.Update
				strSQL = strSQL & " UPDATE SRAET53" & vbCrLf
				strSQL = strSQL & "   SET  SRANO    = '" & StChk(strSRANO) & "'" & vbCrLf
				strSQL = strSQL & "       ,CHKFLG   = '" & StChk(strCHECK) & "'" & vbCrLf
				strSQL = strSQL & "       ,WRTTM    = '" & StChk(strWRTTM) & "'" & vbCrLf
				strSQL = strSQL & "       ,WRTDT    = '" & StChk(strWRTDT) & "'" & vbCrLf
				strSQL = strSQL & " WHERE  RPTCLTID = '" & StChk(L_strRPTCLTID) & "'" & vbCrLf
				strSQL = strSQL & "   AND  PRGID    = '" & StChk(L_strPRGID) & "'" & vbCrLf
				strSQL = strSQL & "   AND  HINCD    = '" & StChk(L_strHINCD) & "'" & vbCrLf
				strSQL = strSQL & "   AND  SBNNO    = '" & StChk(L_strSBNNO) & "'" & vbCrLf '2008/01/17 復活
				strSQL = strSQL & "   AND  SRALINNO = '" & VB6.Format(strSRALINNO, "000000") & "'" & vbCrLf
				
			Case enumCREATE_MODE.Delete
				strSQL = strSQL & " DELETE FROM SRAET53" & vbCrLf
				strSQL = strSQL & " WHERE  RPTCLTID = '" & StChk(L_strRPTCLTID) & "'" & vbCrLf
				strSQL = strSQL & "   AND  PRGID    = '" & StChk(L_strPRGID) & "'" & vbCrLf
				strSQL = strSQL & "   AND  HINCD    = '" & StChk(L_strHINCD) & "'" & vbCrLf
				strSQL = strSQL & "   AND  SBNNO    = '" & StChk(L_strSBNNO) & "'" & vbCrLf '2008/01/17 復活
				strSQL = strSQL & "   AND  SRALINNO = '" & VB6.Format(strSRALINNO, "000000") & "'" & vbCrLf
				
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
		
		Dim lngI As Integer
		Dim lngLineNo As Integer
		Dim strSQL As String
		Dim varCHECK As Object
		Dim varNO As Object
		Dim varSERIAL As Object
		Dim varLOCKBN As Object
		Dim varZAISYOBN As Object
		Dim varSBN As Object
		Dim varHIDSERIAL As Object
		Dim datNOW As Date
		Dim intCnt As Short
		Dim intMaxKeta As Short
		Dim strZero As String
		Dim strCREATE_MODE As enumCREATE_MODE
		
		P_Main = False
		
		'BEGIN TRAN
		If CF_Ora_BeginTrans(gv_Oss_USR9) = False Then
			GoTo EndLbl
		End If
		
		'登録日時を生成
		datNOW = Now
		L_strWRTTM = VB6.Format(datNOW, "HHMMSS")
		L_strWRTDT = VB6.Format(datNOW, "YYYYMMDD")
		
		'行番号用ZERO文字を設定
		intCnt = 0
		intMaxKeta = Len(CStr(LC_lngMAX_ROW))
		For intCnt = 0 To intMaxKeta - 1
			strZero = strZero & "0"
		Next 
		
		'データ登録
		lngI = 0
		lngLineNo = 0
		For lngI = 1 To L_lngMAX_EditRow
			With vaData
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_CHECK, lngI, varCHECK)
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_NO, lngI, varNO)
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_SERIAL, lngI, varSERIAL)
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_LOCKBN, lngI, varLOCKBN)
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_ZAISYOBN, lngI, varZAISYOBN)
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_SBN, lngI, varSBN)
				'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(LC_lngCol_HID_SERIAL, lngI, varHIDSERIAL)
				'UPGRADE_WARNING: オブジェクト Nz(varSERIAL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Nz(varSERIAL) <> "" Then
					lngLineNo = lngLineNo + 1
					' 処理区分判定する
					'UPGRADE_WARNING: オブジェクト varLOCKBN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If varLOCKBN = LC_strLINE_LOCK Then
						strCREATE_MODE = enumCREATE_MODE.Update
					Else
						'手入力行
						'UPGRADE_WARNING: オブジェクト varSERIAL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If P_SRANOCheckWK(CStr(varSERIAL)) = False Then
							strCREATE_MODE = enumCREATE_MODE.Update
						Else
							strCREATE_MODE = enumCREATE_MODE.Insert
						End If
					End If
					
					'UPGRADE_WARNING: オブジェクト varSBN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト varZAISYOBN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト varSERIAL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト varCHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If P_EXECUTE_SQL(strCREATE_MODE, VB6.Format(lngLineNo, strZero), CStr(varCHECK), CStr(varSERIAL), CStr(varZAISYOBN), CStr(varSBN), L_strWRTTM, L_strWRTDT) = False Then
						GoTo EndLbl
					End If
				Else
					lngLineNo = lngLineNo + 1
					'UPGRADE_WARNING: オブジェクト Nz(varHIDSERIAL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Nz(varHIDSERIAL) <> "" Then
						strCREATE_MODE = enumCREATE_MODE.Delete
						'UPGRADE_WARNING: オブジェクト varSBN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト varZAISYOBN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト varSERIAL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト varCHECK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If P_EXECUTE_SQL(strCREATE_MODE, VB6.Format(lngLineNo, strZero), CStr(varCHECK), CStr(varSERIAL), CStr(varZAISYOBN), CStr(varSBN), L_strWRTTM, L_strWRTDT) = False Then
							GoTo EndLbl
						End If
					End If
				End If
			End With
		Next lngI
		
		'COMMIT
		Call CF_Ora_CommitTrans(gv_Oss_USR9)
		
		P_Main = True
		
		Exit Function
		
		GoTo EndLbl
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
	Public Sub GP_Va_Col_LockColor(ByRef objSpread As Object, ByVal lngCol As Integer)
		
		'スプレッドの背景色の設定。
		With objSpread
			'UPGRADE_WARNING: オブジェクト objSpread.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = False
			'UPGRADE_WARNING: オブジェクト objSpread.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row = 1
			'UPGRADE_WARNING: オブジェクト objSpread.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col = lngCol
			'UPGRADE_WARNING: オブジェクト objSpread.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト objSpread.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row2 = .MaxRows
			'UPGRADE_WARNING: オブジェクト objSpread.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col2 = lngCol
			'UPGRADE_WARNING: オブジェクト objSpread.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BlockMode = True
			'UPGRADE_WARNING: オブジェクト objSpread.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BackColor = LC_lng_va_Lock_Color
			'UPGRADE_WARNING: オブジェクト objSpread.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BlockMode = False
			'UPGRADE_WARNING: オブジェクト objSpread.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = True
		End With
		
	End Sub
	
	'===========================================================================
	'【使用用途】 スプレッドの列のロック色設定。
	'【関 数 名】 GP_Va_Col_LockColor_Row
	'【引    数】 ByRef objSpread As Object：スプレッド
	'【引    数】 ByVal lngRow As Long：行番号
	'【返    値】
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Public Sub GP_Va_Col_LockColor_Row(ByRef objSpread As Object, ByVal lngRow As Integer)
		
		'スプレッドの背景色の設定。
		With objSpread
			'UPGRADE_WARNING: オブジェクト objSpread.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = False
			'UPGRADE_WARNING: オブジェクト objSpread.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row = lngRow
			'UPGRADE_WARNING: オブジェクト objSpread.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col = LC_lngCol_NO
			'UPGRADE_WARNING: オブジェクト objSpread.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row2 = lngRow
			'UPGRADE_WARNING: オブジェクト objSpread.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col2 = LC_lngCol_SERIAL
			'UPGRADE_WARNING: オブジェクト objSpread.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BlockMode = True
			'UPGRADE_WARNING: オブジェクト objSpread.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
			'UPGRADE_WARNING: オブジェクト objSpread.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BlockMode = False
			'UPGRADE_WARNING: オブジェクト objSpread.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
	Public Sub GP_Va_Col_EditColor(ByRef objSpread As Object, ByVal lngCol As Integer, ByVal lngRow As Integer, ByVal bolEdit As Boolean, Optional ByVal lngCol2 As Integer = 0, Optional ByVal lngRow2 As Integer = 0)
		
		Dim varZAISYOBN As Object
		Dim lngI As Integer
		
		'スプレッドの背景色の設定。
		With objSpread
			'UPGRADE_WARNING: オブジェクト objSpread.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = False
			'UPGRADE_WARNING: オブジェクト objSpread.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row = lngRow
			'UPGRADE_WARNING: オブジェクト objSpread.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col = lngCol
			'UPGRADE_WARNING: オブジェクト objSpread.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BlockMode = True
			If bolEdit Then
				'UPGRADE_WARNING: オブジェクト objSpread.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Row2 = lngRow
				'UPGRADE_WARNING: オブジェクト objSpread.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Col2 = lngCol
				'UPGRADE_WARNING: オブジェクト objSpread.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.BackColor = LC_lng_va_Edit_Color
			Else
				If lngRow2 <> 0 Then
					'UPGRADE_WARNING: オブジェクト objSpread.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Row2 = lngRow2
				Else
					'UPGRADE_WARNING: オブジェクト objSpread.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Row2 = lngRow
				End If
				If lngCol2 <> 0 Then
					'UPGRADE_WARNING: オブジェクト objSpread.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col2 = lngCol2
				Else
					'UPGRADE_WARNING: オブジェクト objSpread.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col2 = lngCol
				End If
				'UPGRADE_WARNING: オブジェクト objSpread.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.BackColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
			End If
			'UPGRADE_WARNING: オブジェクト objSpread.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BlockMode = False
			'UPGRADE_WARNING: オブジェクト objSpread.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = True
		End With
		
		With objSpread
			'UPGRADE_WARNING: オブジェクト objSpread.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = False
			'UPGRADE_WARNING: オブジェクト objSpread.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row = lngRow
			'UPGRADE_WARNING: オブジェクト objSpread.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col = LC_lngCol_NO
			If lngRow2 <> 0 Then
				'UPGRADE_WARNING: オブジェクト objSpread.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Row2 = lngRow2
			Else
				'UPGRADE_WARNING: オブジェクト objSpread.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Row2 = lngRow
			End If
			'UPGRADE_WARNING: オブジェクト objSpread.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col2 = LC_lngCol_NO
			'UPGRADE_WARNING: オブジェクト objSpread.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BlockMode = True
			'UPGRADE_WARNING: オブジェクト objSpread.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
			'UPGRADE_WARNING: オブジェクト objSpread.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BlockMode = False
			'UPGRADE_WARNING: オブジェクト objSpread.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
	Private Sub SetEdit(ByRef objSpread As Object, ByVal lngCol As Integer, ByVal lngRow As Integer)
		Dim PositionCenterLeft As Object
		Dim TypeEditCharSetAlphanumeric As Object
		Dim CellTypeEdit As Object
		Dim TypeCheckTypeNormal As Object
		Dim CellTypeCheckBox As Object
		With vaData
			'UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = False
			'UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col = lngCol
			'UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col2 = lngCol
			'UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row = lngRow
			'UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row2 = lngRow
			'UPGRADE_WARNING: オブジェクト vaData.GridSolid の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.GridSolid = True
			'UPGRADE_WARNING: オブジェクト vaData.GridColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.GridColor = &H0
			'UPGRADE_WARNING: オブジェクト vaData.FontSize の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.FontSize = 12
			If lngCol = LC_lngCol_CHECK Then
				'UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Col = LC_lngCol_CHECK
				'UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Col2 = LC_lngCol_CHECK
				'UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Row = lngRow
				'UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Row2 = lngRow
				'UPGRADE_WARNING: オブジェクト vaData.CellType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CellTypeCheckBox の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.CellType = CellTypeCheckBox
				'UPGRADE_WARNING: オブジェクト vaData.TypeCheckType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト TypeCheckTypeNormal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.TypeCheckType = TypeCheckTypeNormal
				'UPGRADE_WARNING: オブジェクト vaData.TypeCheckCenter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.TypeCheckCenter = True
				'UPGRADE_WARNING: オブジェクト vaData.TypeCheckText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.TypeCheckText = ""
			Else
				'UPGRADE_WARNING: オブジェクト vaData.CellType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CellTypeEdit の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.CellType = CellTypeEdit '文字入力
				'UPGRADE_WARNING: オブジェクト vaData.TypeEditCharSet の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト TypeEditCharSetAlphanumeric の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.TypeEditCharSet = TypeEditCharSetAlphanumeric '半角英数字
				'UPGRADE_WARNING: オブジェクト vaData.Position の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト PositionCenterLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Position = PositionCenterLeft
			End If
			'入力桁数をセット
			Select Case lngCol
				Case LC_lngCol_SERIAL
					'UPGRADE_WARNING: オブジェクト vaData.TypeMaxEditLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.TypeMaxEditLen = C_lngSERIAL_Len
			End Select
			'UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = True
		End With
	End Sub
	
	Private Sub vaData_MouseDown(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		
		Dim varLOCKBN As Object
		
		With vaData
			'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call .GetText(LC_lngCol_LOCKBN, .ActiveRow, varLOCKBN)
			
			'UPGRADE_WARNING: オブジェクト varLOCKBN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If varLOCKBN = LC_strLINE_NOT_LOCK Then
				'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .ActiveRow, True)
				'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .ActiveRow)
			End If
		End With
		
	End Sub
	
	Private Sub vaData_Validate(ByRef Cancel As Boolean)
		L_lngMAX_EditRow = P_Get_EditMaxRow
	End Sub
	
	Private Sub F_SendKey(ByVal KeyCode As Short)
		Select Case KeyCode
			Case System.Windows.Forms.Keys.F1 : System.Windows.Forms.SendKeys.Send("%1")
			Case System.Windows.Forms.Keys.F2 : System.Windows.Forms.SendKeys.Send("%2")
		End Select
	End Sub
	'=========================================================================【 メソッド 】=
End Class