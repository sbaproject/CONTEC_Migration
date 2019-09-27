Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	'***************************************************************************************
	'*  【使用用途】シリアル№登録
	'*  【作 成 日】2006/08/31  SYSTEM CREATE CO,.Ltd.
	'*  【更 新 日】2006/11/09
	'*  【備    考】パラメータ(PGID)を追加
	'***************************************************************************************
	
	'-【 変数宣言 】-------------------------------------------------------------------------
	'AppPath退避用
	Private L_strAppPath As String
	
	'データ登録用
	Private L_strWRTTM As String
	Private L_strWRTDT As String
	
	'パラメータ取得用
	Private L_strRPTCLTID As String
	Private L_strPGID As String '2006.11.09
	Private L_strSBNNO As String
	Private L_strHINCD As String
	Private L_strURISU As String
	
	' プロパティ値格納用変数
	Dim mstrRPTCLTID As String
	Dim mstrPGID As String
	Dim mstrSBNNO As String '2006.11.09
	Dim mstrHINCD As String
	Dim mstrURISU As String
	
	'スプレッド編集行の最大値
	Private L_lngMAX_EditRow As Integer
	
	'LeaveCellイベント判定フラグ
	Private L_blnLeaveCell As Boolean 'True:イベント発生, False:イベント未発生
	'ADD START FKS)INABA 2008/01/28 *************************************************************
	Private L_blnLeaveCell2 As Boolean 'True:イベント発生, False:イベント未発生
	'ADD  END  FKS)INABA 2008/01/28 *************************************************************
	
	'更新確認メッセージキャンセル時のActiveCellセット用
	Private L_LastCol As Integer '列
	Private L_LastRow As Integer '行
	'-------------------------------------------------------------------------【 変数宣言 】-
	
	'-【 定数宣言 】-------------------------------------------------------------------------
	'タイトル
	Private Const LC_strPG_ID As String = "SRAET61        "
	Private Const LC_strTitle As String = "シリアル№登録"
	
	' パラメータ スイッチ定義
	Private Const mcPARAM_RPTCLTID As String = "/RPTCLTID:"
	Private Const mcPARAM_PGID As String = "/PGID:" '2006.11.09
	Private Const mcPARAM_SBNNO As String = "/SBNNO:"
	Private Const mcPARAM_HINCD As String = "/HINCD:"
	Private Const mcPARAM_URISU As String = "/URISU:"
	
	'スプレッド背景色
	Private Const LC_lng_va_Edit_Color As Integer = &HFFFF
	Private Const LC_lng_va_UnEdit_Color As Integer = &HFFFFFF
	Private Const LC_lng_va_Lock_Color As Integer = &HC0C0C0
	
	'スプレッドの行
	Private Const LC_lngMAX_ROW As Integer = 999999 '最大行数
	Private Const LC_lngDEFAULT_ROW As Integer = 9999 'デフォルトセット行
	
	'スプレッドの項目
	Private Const LC_lngCol_NO As Integer = 1 '行№
	Private Const LC_lngCol_SERIAL As Integer = 2 'シリアル№
	Private Const LC_lngCol_TNANO As Integer = 3 '棚番
	
	'* 最大入力桁数
	Private Const C_lngSERIAL_Len As Integer = 13 'シリアル№
	Private Const C_lngTNANO_Len As Integer = 9 '棚番
	
	'出荷済み区分
	Private Const LC_strSYUKA As String = "02"
	
	'SQL文生成時のモード
	Private Enum enumCREATE_MODE
		Insert
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
	Private Const InfLineLittle2 As String = "C" '* 入力行数が数量を下回っています。
    '-------------------------------------------------------------------------【 定数宣言 】-
    '2019/09/26 ADD START
    'API関数の宣言
    Private Const WM_KEYDOWN As Short = &H100S
    Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hWnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    '2019/09/26 ADD END
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
		Call FR_SSSMAIN_Load(Me, New System.EventArgs())
	End Sub
	
	'===========================================================================
	'【使用用途】 [終了]ボタンクリック時
	'【関 数 名】 CM_EndCm_Click
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
		'* セル背景色を解除
		With vaData
            'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/09/26 CHG START
            'Call GP_Va_Col_EditColor(vaData, LC_lngCol_NO, 1, False, LC_lngCol_TNANO, .MaxRows)
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_NO, 1, False, LC_lngCol_TNANO, .RowCount - 1)
            '2019/09/26 CHG END
        End With
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
		
		L_blnLeaveCell2 = False
		'スプレッドの入力チェック
		If P_EntryCheck(lngRow) = False Then
			'ADD START FKS)INABA 2007/12/15 *******************************
			'        intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, SerialNoNull, Mst_Inf)
			'        msgMsgBox = GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
			'ADD  END  FKS)INABA 2007/12/15 *******************************
			L_blnLeaveCell = False
			L_blnLeaveCell2 = True
			CM_Execute.Image = IM_Execute(1).Image
			Exit Sub
		End If
		L_blnLeaveCell2 = True
		strMSGKBN = "1"
		'DEL START FKS)INABA 2007/12/15 ***********************
		msgMsgBox = GP_MsgBox(enumCREATE_MODE.Insert, "", LC_strTitle)
		If msgMsgBox = MsgBoxResult.No Then Exit Sub
		'DEL  END  FKS)INABA 2007/12/15 ***********************
		
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
                '2019/09/26 CHG START
                'Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, False, LC_lngCol_TNANO, .MaxRows)
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, False, LC_lngCol_TNANO, .RowCount - 1)
                '2019/09/26 CHG END
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
				'ADD START FKS)INABA 2007/12/18 ****************************************
			Else
				'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				msgMsgBox = GP_MsgBox(Common.enmMsg.Execute, Mst_Inf.MSGCM, LC_strTitle)
				'ADD  END  FKS)INABA 2007/12/18 ****************************************
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
		'DEL START FKS)INABA 2007/12/18 *************************************
		'    msgMsgBox = GP_MsgBox(Execute, Mst_Inf.MSGCM, LC_strTitle)
		'DEL  END  FKS)INABA 2007/12/18 *************************************
		If msgMsgBox <> MsgBoxResult.Yes Then
			CM_Execute.Image = IM_Execute(1).Image
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
		
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
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
        '2019/09/26 CHG START
        'If App.PrevInstance Then
        If PrevInstance() Then
            '2019/09/26 CHG END
            Call GP_MsgBox(COMMON.enmMsg.Critical, "既に起動しています。", LC_strTitle)
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
		L_strPGID = Replace(strArry(1), mcPARAM_PGID, "") '2006.11.09
		L_strSBNNO = Replace(strArry(2), mcPARAM_SBNNO, "")
		L_strHINCD = Replace(strArry(3), mcPARAM_HINCD, "")
		L_strURISU = Replace(strArry(4), mcPARAM_URISU, "")
		
		'パラメータで不備があれば本画面は起動させない
		If L_strRPTCLTID = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "ワークステーションＩＤが設定されていません。", LC_strTitle)
			End
		End If
		'2006.11.09 ADD - [STRAT]
		If L_strPGID = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "プログラムＩＤが設定されていません。", LC_strTitle)
			End
		End If
		'2006.11.09 ADD - [E N D]
		If L_strSBNNO = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "製番が設定されていません。", LC_strTitle)
			End
		End If
		If L_strHINCD = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "製品コードが設定されていません。", LC_strTitle)
			End
		End If
		If L_strURISU = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "数量が設定されていません。", LC_strTitle)
			End
		Else
			If IsNumeric(L_strURISU) = False Then
				Call GP_MsgBox(Common.enmMsg.Critical, "数量が数値ではありません。", LC_strTitle)
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
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        'DB接続解除
        '2019/09/26 CHG START
        'Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
        DB_CLOSE(CON)
        '2019/09/26 CHG END
        '2019/09/26 ADD START
        Call SSSWIN_LOGWRT("プログラム終了")
        '2019/09/26 ADD END
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
            '2019/09/26 CHG START
            ''UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'If LC_lngMAX_ROW <> .MaxRows Then
            '    'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    If .MaxRows = Row Then
            '        'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .MaxRows = .MaxRows + 1
            '        'UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Row = 1
            '        'UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Row2 = .MaxRows
            '        'UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Col = LC_lngCol_NO
            '        'UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Col2 = LC_lngCol_NO
            '        'UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BlockMode = True
            '        'UPGRADE_WARNING: オブジェクト vaData.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
            '        'UPGRADE_WARNING: オブジェクト vaData.Protect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Protect = True
            '        'UPGRADE_WARNING: オブジェクト vaData.Lock の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Lock = True
            '        'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        Call .SetText(LC_lngCol_NO, Row + 1, Row + 1)
            '        Call SetEdit(vaData, LC_lngCol_SERIAL, Row + 1)
            '        Call SetEdit(vaData, LC_lngCol_TNANO, Row + 1)
            '    End If
            'End If

            Dim maxRows As Integer = .RowCount - 1

            If LC_lngMAX_ROW <> maxRows Then

                If maxRows = Row Then

                    .RowCount = maxRows + 1

                    .Rows(1).Cells(LC_lngCol_NO).Style.BackColor = Me.BackColor
                    .Rows(1).Cells(LC_lngCol_NO).Enabled = False

                    .Rows(maxRows).Cells(LC_lngCol_NO).Style.BackColor = Me.BackColor
                    .Rows(maxRows).Cells(LC_lngCol_NO).Enabled = False

                    Call .SetValue(Row + 1, LC_lngCol_NO, Row + 1)
                    Call SetEdit(vaData, LC_lngCol_SERIAL, Row + 1)
                    Call SetEdit(vaData, LC_lngCol_TNANO, Row + 1)

                End If

            End If

            '2019/09/26 CHG END

        End With

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
		'ADD START FKS)INABA 2008/01/28 *************************************************************
		If L_blnLeaveCell2 = False Then Exit Sub
		'ADD  END  FKS)INABA 2008/01/28 *************************************************************
		
		L_blnLeaveCell = True
		
		'* セル背景色を解除
		With vaData
            'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/09/26 CHG START
            'Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, False, LC_lngCol_TNANO, .MaxRows)
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, False, LC_lngCol_TNANO, .RowCount - 1)
            '2019/09/26 CHG END
        End With
		
		'データ入力最大行を取得
		L_lngMAX_EditRow = P_Get_EditMaxRow()

        '入力文字を大文字に変換してセルに再セット
        Select Case Col
            '2019/09/26 CHG START
            'Case LC_lngCol_SERIAL
            '	'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	Call vaData.GetText(LC_lngCol_SERIAL, Row, varSERIAL)
            '	'UPGRADE_WARNING: オブジェクト Nz() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	Call vaData.SetText(LC_lngCol_SERIAL, Row, StrConv(Nz(varSERIAL), VbStrConv.UpperCase))
            'Case LC_lngCol_TNANO
            '	'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	Call vaData.GetText(LC_lngCol_TNANO, Row, varTNANO)
           ''UPGRADE_WARNING: オブジェクト Nz() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
           ''UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
           'Call vaData.SetText(LC_lngCol_TNANO, Row, StrConv(RTrim(Nz(varTNANO)), VbStrConv.Uppercase))

            Case LC_lngCol_SERIAL

                varSERIAL = vaData.GetValue(Row, LC_lngCol_SERIAL)

                vaData.SetValue(Row, LC_lngCol_SERIAL, StrConv(Nz(varSERIAL), VbStrConv.Uppercase))

            Case LC_lngCol_TNANO

                varTNANO = vaData.GetValue(Row, LC_lngCol_TNANO)

                vaData.SetValue(Row, LC_lngCol_TNANO, StrConv(RTrim(Nz(varTNANO)), VbStrConv.Uppercase))

                '2019/09/26 CHG END
        End Select

        'セルの値を取得
        '2019/09/26 CHG START
        ''UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Call vaData.GetText(LC_lngCol_SERIAL, Row, varSERIAL)
        ''UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Call vaData.GetText(LC_lngCol_TNANO, Row, varTNANO)

        varSERIAL = vaData.GetValue(Row, LC_lngCol_SERIAL)

        varTNANO = vaData.GetValue(Row, LC_lngCol_TNANO)

        '2019/09/26 CHG END

        'シリアル番号のとき
        Select Case Col
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
								'UPGRADE_WARNING: オブジェクト varSERIAL_C の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								varSERIAL_C = ""
								If Row <> lngJ Then
                                    'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    '2019/09/26 CHG START
                                    'Call .GetText(LC_lngCol_SERIAL, lngJ, varSERIAL_C)
                                    varSERIAL_C = .GetValue(lngJ, LC_lngCol_SERIAL)
                                    '2019/09/26 CHG END
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
					'UPGRADE_WARNING: オブジェクト Nz(varTNANO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト Nz(varSERIAL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Nz(varSERIAL) <> "" And Nz(varTNANO) = "" And NewRow <> Row Then
						'                If Nz(varSERIAL) <> "" And Nz(varTNANO) = ""  Then
						'CHG  END  FKS)INABA 2008/01/29 **************************************************
						strMSGKBN = "1"
						'UPGRADE_WARNING: vaData_LeaveCell に変換されていないステートメントがあります。ソース コードを確認してください。
						If intRet <> 0 Then
							Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
							Exit Sub
						End If
						'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
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
            'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/09/26 CHG START
            'Call vaData.GetText(LC_lngCol_SERIAL, NewRow - 1, varSERIAL)
            ''UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Call vaData.GetText(LC_lngCol_TNANO, NewRow - 1, varTNANO)
            varSERIAL = vaData.GetValue(NewRow - 1, LC_lngCol_SERIAL)
            varTNANO = vaData.GetValue(NewRow - 1, LC_lngCol_TNANO)
            '2019/09/26 CHG END
            'CHG START FKS)INABA 2007/12/18 *********************************************************
            'UPGRADE_WARNING: オブジェクト Nz(varTNANO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If Nz(varTNANO) = "" Then
				'        If Nz(varSERIAL) = "" Then
				'CHG START FKS)INABA 2007/12/18 *********************************************************
				strMSGKBN = "0"
				'UPGRADE_WARNING: vaData_LeaveCell に変換されていないステートメントがあります。ソース コードを確認してください。
				If intRet <> 0 Then
					Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
					Exit Sub
				End If
				'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call GP_MsgBox(Common.enmMsg.Critical, Mst_Inf.MSGCM, LC_strTitle)
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
        '2019/09/26 DEL START
        '      'カーソル制御。
        '      With vaData
        '	'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	If .ActiveRow > 0 Then
        '		'UPGRADE_WARNING: オブジェクト vaData.ActiveCol の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		If .ActiveCol = 1 Then
        '			'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			Call GP_SpActiveCell(vaData, LC_lngCol_SERIAL, .ActiveRow)
        '		Else
        '			'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト vaData.ActiveCol の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			Call GP_SpActiveCell(vaData, .ActiveCol, .ActiveRow)
        '		End If
        '		''''    Else                            '2006.09.28
        '		''''        CM_Execute.SetFocus         '2006.09.28
        '	Else
        '		txtDummy.Focus()
        '	End If
        '	'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, .ActiveRow, True)
        'End With
        '2019/09/26 DEL END
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
		
		Dim lngRow As Integer

        With vaData
            '2019/09/26 CHG START

            ''UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row = 1
            ''UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row2 = .MaxRows
            ''UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col = LC_lngCol_NO
            ''UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col2 = LC_lngCol_NO
            ''UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BlockMode = True
            ''UPGRADE_WARNING: オブジェクト vaData.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
            '         'UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '         .BlockMode = False

            For cnt As Integer = 0 To .RowCount - 1
                .Rows(cnt).Cells(LC_lngCol_NO).Style.BackColor = Me.BackColor
            Next

            '2019/09/26 CHG END
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
            '2019/09/26 CHG START

            ''UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row = 1
            ''UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col = LC_lngCol_NO
            ''UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row2 = .MaxRows
            ''UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col2 = LC_lngCol_NO
            ''UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BlockMode = True
            ''UPGRADE_WARNING: オブジェクト vaData.Protect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Protect = True
            ''UPGRADE_WARNING: オブジェクト vaData.Lock の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Lock = True
            ''UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BlockMode = False

            For cnt As Integer = 0 To .RowCount - 1
                .Rows(cnt).Cells(LC_lngCol_NO).Enabled = False
            Next

            '2019/09/26 CHG END
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
		
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		Dim lngI As Integer
		Dim intLen As Short
		
		'スプレッドのクリア
		Call P_vaData_Init()
		
		'データの取得。
		If P_Get_Data(Usr_Ody_LC) = True Then
			'データを画面に表示する。
			Call P_Set_Data(Usr_Ody_LC)
		Else
			intLen = Len(CStr(LC_lngMAX_ROW))
            'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

            '2019/09/26 CHG START
            'For lngI = 1 To vaData.MaxRows
            '    'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    Call vaData.SetText(LC_lngCol_NO, lngI, VB.Right(Space(intLen) & CStr(lngI), intLen))
            'Next

            For lngI = 1 To vaData.RowCount - 1
                vaData.SetValue(lngI, LC_lngCol_NO, VB.Right(Space(intLen) & CStr(lngI), intLen))
            Next

            '2019/09/26 CHG END
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
		
		Dim lngI As Integer
		Dim lngJ As Integer
		Dim blnFLG As Boolean
		Dim intLen As Short
		Dim lngRecCount As Integer
		
		On Error GoTo ErrLbl
		
		P_Set_Data = False
		
		lngI = 0
		blnFLG = False

        intLen = Len(CStr(LC_lngMAX_ROW))

        '2019/09/26 ADD START
        Dim dt As DataTable = Usr_Ody_LC.dt
        '2019/09/26 ADD END

        With vaData

            '2019/09/26 CHG START

            ''UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ReDraw = False
            ''スプレッドの行数の設定
            ''UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MaxRows = 0
            ''スプレッドにデータを表示する。
            'Do Until CF_Ora_EOF(Usr_Ody_LC) = True
            '    'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .MaxRows = .MaxRows + 1
            '    lngI = lngI + 1
            '    'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    Call .SetText(LC_lngCol_NO, lngI, VB.Right(Space(intLen) & CStr(lngI), intLen))
            '    Call SetEdit(vaData, LC_lngCol_SERIAL, lngI)
            '    'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    Call .SetText(LC_lngCol_SERIAL, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", ""))
            '    Call SetEdit(vaData, LC_lngCol_TNANO, lngI)
            '    'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    Call .SetText(LC_lngCol_TNANO, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "LOCATION", ""))
            '    Call CF_Ora_MoveNext(Usr_Ody_LC)
            '    'UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .Col = LC_lngCol_NO
            '    'UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .Col2 = LC_lngCol_NO
            '    'UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .Row = .MaxRows
            '    'UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .Row2 = .MaxRows
            '    'UPGRADE_WARNING: オブジェクト vaData.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
            'Loop

            ''初期表示するスプレッド行数は最低LC_lngDEFAULT_ROW行とする
            ''UPGRADE_WARNING: オブジェクト Usr_Ody_LC.Obj_Ody.RecordCount の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'lngRecCount = Usr_Ody_LC.Obj_Ody.RecordCount
            'L_lngMAX_EditRow = lngRecCount
            'If lngRecCount > LC_lngDEFAULT_ROW Then
            '    'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .MaxRows = lngRecCount
            'Else
            '    'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .MaxRows = LC_lngDEFAULT_ROW
            '    blnFLG = True
            'End If

            'If blnFLG = True Then
            '    'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    For lngJ = lngI To vaData.MaxRows
            '        'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        Call .SetText(LC_lngCol_NO, lngJ, VB.Right(Space(intLen) & CStr(lngJ), intLen))
            '        Call SetEdit(vaData, LC_lngCol_SERIAL, lngJ)
            '        Call SetEdit(vaData, LC_lngCol_TNANO, lngJ)
            '        'UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Col = LC_lngCol_NO
            '        'UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Col2 = LC_lngCol_NO
            '        'UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Row = .MaxRows
            '        'UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .Row2 = .MaxRows
            '        'UPGRADE_WARNING: オブジェクト vaData.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
            '    Next
            'End If

            ''背景色の設定
            'Call P_Va_BackColor()
            'Call P_Va_Lock()

            ''UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ReDraw = True


            .SuspendLayout()


            If dt Is Nothing OrElse dt.Rows.Count > 0 Then

                For cnt As Integer = 0 To dt.Rows.Count - 1

                    .RowCount = cnt + 1

                    .SetValue(cnt, LC_lngCol_NO, VB.Right(Space(intLen) & CStr(lngI + 1), intLen))
                    Call SetEdit(vaData, LC_lngCol_SERIAL, cnt)

                    .SetValue(cnt, LC_lngCol_SERIAL, Trim(DB_NullReplace(dt.Rows(cnt)("SRANO"), "")))
                    Call SetEdit(vaData, LC_lngCol_TNANO, cnt)

                    .SetValue(cnt, LC_lngCol_SERIAL, Trim(DB_NullReplace(dt.Rows(cnt)("LOCATION"), "")))

                    .Rows(cnt).Cells(LC_lngCol_NO).Style.BackColor = Me.BackColor

                Next

                lngRecCount = Usr_Ody_LC.Obj_Ody.RecordCount

                L_lngMAX_EditRow = lngRecCount

                If lngRecCount > LC_lngDEFAULT_ROW Then

                    .RowCount = lngRecCount
                Else

                    .RowCount = LC_lngDEFAULT_ROW

                    blnFLG = True

                End If

                If blnFLG = True Then

                    For lngJ = dt.Rows.Count - 1 To .RowCount - 1

                        .SetValue(lngJ, LC_lngCol_NO, VB.Right(Space(intLen) & CStr(lngJ + 1), intLen))
                        Call SetEdit(vaData, LC_lngCol_SERIAL, lngJ)
                        Call SetEdit(vaData, LC_lngCol_TNANO, lngJ)

                        .Rows(lngJ).Cells(LC_lngCol_NO).Style.BackColor = Me.BackColor

                    Next

                End If

                '背景色の設定
                Call P_Va_BackColor()
                Call P_Va_Lock()

                .ResumeLayout()

            End If

            '2019/09/26 CHG END

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
		Dim strWKPGID As String
		Dim strWKSBNNO As String
		
		On Error GoTo Errlabel
		
		P_Get_Data = False
		
		strWKRPTCLTID = VB.Left(L_strRPTCLTID & Space(5), 5)
		strWKPGID = VB.Left(L_strPGID & Space(7), 7)
		strWKSBNNO = VB.Left(L_strSBNNO & Space(20), 20)
		
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
        '2019/09/26 CHG START
        'strSQL = strSQL & vbCrLf & " From   SRAET61"
        strSQL = strSQL & vbCrLf & " From   CNT_USR9.SRAET61"
        '2019/09/26 CHG END
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
		Dim ActionClearText As Object
		
		Dim lngI As Integer
		Dim lngLine As Integer
		Dim intLen As Short
		
		lngI = 0
		lngLine = 0
		intLen = Len(CStr(LC_lngMAX_ROW))

        With vaData
            '2019/09/26 CHG START

            ''スプレッドのクリア
            ''UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ReDraw = False
            ''UPGRADE_WARNING: オブジェクト vaData.Action の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト ActionClearText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Action = ActionClearText
            ''UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MaxRows = LC_lngDEFAULT_ROW
            'Call SetEdit(vaData, LC_lngCol_NO, 1)
            'Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
            'Call SetEdit(vaData, LC_lngCol_TNANO, 1)
            ''行番号をセット
            ''UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'For lngI = 0 To vaData.MaxRows
            '	lngLine = lngLine + 1
            '	'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '	Call .SetText(LC_lngCol_NO, lngLine, VB.Right(Space(intLen) & CStr(lngLine), intLen))
            '	Call SetEdit(vaData, LC_lngCol_NO, lngLine)
            '	Call SetEdit(vaData, LC_lngCol_SERIAL, lngLine)
            '	Call SetEdit(vaData, LC_lngCol_TNANO, lngLine)
            'Next
            '         'UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '         .ReDraw = True

            .SuspendLayout()

            .RowCount = LC_lngDEFAULT_ROW

            Call SetEdit(vaData, LC_lngCol_NO, 0)
            Call SetEdit(vaData, LC_lngCol_SERIAL, 0)
            Call SetEdit(vaData, LC_lngCol_TNANO, 0)

            For lngI = 0 To .RowCount - 1

                .SetValue(lngLine, LC_lngCol_NO, VB.Right(Space(intLen) & CStr(lngLine + 1), intLen))

                Call SetEdit(vaData, LC_lngCol_NO, lngLine)
                Call SetEdit(vaData, LC_lngCol_SERIAL, lngLine)
                Call SetEdit(vaData, LC_lngCol_TNANO, lngLine)

            Next

            ResumeLayout()

            '2019/09/26 CHG END

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
		Dim strWKPGID As String
		Dim strWKSRANO As String
		
		P_SRANOCheckWK = False
		
		strWKRPTCLTID = VB.Left(L_strRPTCLTID & Space(5), 5)
		strWKPGID = VB.Left(L_strPGID & Space(7), 7)
		strWKSRANO = VB.Left(strSRANO & Space(13), 13)
		
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
		
		'* セル背景色を解除
		With vaData
            'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。

            'Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, False, LC_lngCol_TNANO, .MaxRows)
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, False, LC_lngCol_TNANO, .RowCount - 1)

        End With
		
		'データ入力最大行を取得
		L_lngMAX_EditRow = P_Get_EditMaxRow
		'ADD START FKS)INABA 2007/12/15 ******************
		If L_lngMAX_EditRow = 0 Then
			Exit Function
			'ADD START FKS)INABA 2008/01/23 ******************
		ElseIf Val(lblURISU.Text) < L_lngMAX_EditRow Then 
			'UPGRADE_WARNING: P_NULLCheck に変換されていないステートメントがあります。ソース コードを確認してください。
			'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
			Exit Function
		ElseIf Val(lblURISU.Text) > L_lngMAX_EditRow Then 
			'UPGRADE_WARNING: P_NULLCheck に変換されていないステートメントがあります。ソース コードを確認してください。
			'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
			Exit Function
			'ADD  END  FKS)INABA 2008/01/23 ******************
		End If
		'ADD  END  FKS)INABA 2007/12/15 ******************
		For lngI = 1 To L_lngMAX_EditRow
			With vaData
                'スプレッドデータを取得
                'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/09/26 CHG START
                'Call .GetText(LC_lngCol_NO, lngI, varNO)
                ''UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Call .GetText(LC_lngCol_SERIAL, lngI, varSERIAL)
                ''UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Call .GetText(LC_lngCol_TNANO, lngI, varTNANO)

                varNO = .GetValue(lngI, LC_lngCol_NO)
                varSERIAL = .GetValue(lngI, LC_lngCol_SERIAL)
                varTNANO = .GetValue(lngI, LC_lngCol_TNANO)

                '2019/09/26 CHG END

                'UPGRADE_WARNING: オブジェクト varSERIAL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If varSERIAL <> vbNullString Then
					'* シリアル№重複チェック
					lngJ = 1
					For lngJ = 1 To L_lngMAX_EditRow
						'UPGRADE_WARNING: オブジェクト varSERIAL_C の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						varSERIAL_C = ""
						If lngI <> lngJ Then
                            'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '2019/09/26 CHG START
                            'Call .GetText(LC_lngCol_SERIAL, lngJ, varSERIAL_C)
                            varSERIAL_C = .GetValue(lngJ, LC_lngCol_SERIAL)
                            '2019/09/26 CHG END
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
					
					'棚番NULLチェック
					'UPGRADE_WARNING: オブジェクト varTNANO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If varTNANO = vbNullString Then
						'UPGRADE_WARNING: P_NULLCheck に変換されていないステートメントがあります。ソース コードを確認してください。
						If intRet <> 0 Then
							Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
							Exit Function
						End If
						'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
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
					'UPGRADE_WARNING: オブジェクト varTNANO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If varTNANO = "" Then
						'* セル背景色を解除
						'UPGRADE_WARNING: P_NULLCheck に変換されていないステートメントがあります。ソース コードを確認してください。
						If intRet <> 0 Then
							Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
							Exit Function
						End If
						With vaData
                            'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            Call GP_Va_Col_EditColor(vaData, LC_lngCol_SERIAL, 1, False, LC_lngCol_TNANO, .RowCount - 1)
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
	Private Function P_Get_EditMaxRow() As Integer
		
		Dim lngI As Integer
		Dim lngLine As Integer
		Dim varSERIAL As Object
		Dim varTNANO As Object
		
		P_Get_EditMaxRow = 0
		
		lngI = 1
        With vaData

            '2019/09/26 CHG START

            ''UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'For lngI = 1 To .MaxRows
            '    'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    lngLine = .MaxRows - lngI
            '    'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    Call .GetText(LC_lngCol_SERIAL, lngLine, varSERIAL)
            '    'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    Call .GetText(LC_lngCol_TNANO, lngLine, varTNANO)
            '    'UPGRADE_WARNING: オブジェクト Nz(varTNANO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    'UPGRADE_WARNING: オブジェクト Nz(varSERIAL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    If Nz(varSERIAL) <> "" Or Nz(varTNANO) <> "" Then
            '        P_Get_EditMaxRow = lngLine
            '        Exit For
            '    End If
            'Next

            Dim maxRows As Integer = .RowCount - 1

            For lngI = 0 To maxRows

                lngLine = maxRows - lngI

                varSERIAL = .GetValue(lngLine, LC_lngCol_SERIAL)

                varTNANO = .GetValue(lngLine, LC_lngCol_TNANO)

                If Nz(varSERIAL) <> "" Or Nz(varTNANO) <> "" Then
                    P_Get_EditMaxRow = lngLine
                    Exit For
                End If
            Next

            '2019/09/26 CHG END

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
	Private Function P_EXECUTE_SQL(ByVal strMode As enumCREATE_MODE, ByVal strSRALINNO As String, ByVal strSRANO As String, ByVal strLOCATION As String, ByVal strWRTTM As String, ByVal strWRTDT As String) As Boolean
		Dim strSQL As String
		
		P_EXECUTE_SQL = False
		
		strSQL = vbNullString
		
		Select Case strMode
			Case enumCREATE_MODE.Insert
				strSQL = strSQL & " INSERT INTO SRAET61 (" & vbCrLf
				strSQL = strSQL & "                      RPTCLTID," & vbCrLf
				strSQL = strSQL & "                      PGID," & vbCrLf '2006.11.09
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
				strSQL = strSQL & "          '" & StChk(L_strPGID) & "'," & vbCrLf '2006.11.09
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
				strSQL = strSQL & "   AND  PGID     = '" & StChk(L_strPGID) & "'" & vbCrLf '2006.11.09
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
		
		Dim lngI As Integer
		Dim lngLineNo As Integer
		Dim strSQL As String
		Dim varNO As Object
		Dim varSERIAL As Object
		Dim varTNANO As Object
		Dim datNOW As Date
		Dim intCnt As Short
		Dim intMaxKeta As Short
		Dim strZero As String
		
		P_Main = False

        'BEGIN TRAN
        '2019/09/26 CHG START
        'If CF_Ora_BeginTrans(gv_Oss_USR9) = False Then
        If DB_BeginTrans(CON) = False Then
            '2019/09/26 CHG END
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
		
		'DELETE
		'UPGRADE_WARNING: オブジェクト varNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If P_EXECUTE_SQL(enumCREATE_MODE.Delete, VB6.Format(CInt(varNO), strZero), "", "", "", "") = False Then
			GoTo EndLbl
		End If
		
		'INSERT
		lngI = 0
		lngLineNo = 0
		For lngI = 1 To L_lngMAX_EditRow
			With vaData
                '2019/09/26 CHG START
                '            'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            Call .GetText(LC_lngCol_NO, lngI, varNO)
                ''UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Call .GetText(LC_lngCol_SERIAL, lngI, varSERIAL)
                '            'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            Call .GetText(LC_lngCol_TNANO, lngI, varTNANO)

                varNO = .GetValue(lngI, LC_lngCol_NO)
                varSERIAL = .GetValue(lngI, LC_lngCol_SERIAL)
                varTNANO = .GetValue(lngI, LC_lngCol_TNANO)

                '2019/09/26 CHG END

                'CHG START FKS)INABA 2007/12/18 *********************************
                'UPGRADE_WARNING: オブジェクト Nz(varTNANO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Nz(varTNANO) <> "" Then
					'            If Nz(varSERIAL) <> "" And Nz(varTNANO) <> "" Then
					'UPGRADE_WARNING: オブジェクト Nz(varSERIAL) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト varSERIAL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Nz(varSERIAL) = "" Then varSERIAL = " "
					'CHG  END  FKS)INABA 2007/12/18 *********************************
					lngLineNo = lngLineNo + 1
					'UPGRADE_WARNING: オブジェクト varTNANO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト varSERIAL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If P_EXECUTE_SQL(enumCREATE_MODE.Insert, VB6.Format(lngLineNo, strZero), CStr(varSERIAL), CStr(varTNANO), L_strWRTTM, L_strWRTDT) = False Then
						GoTo EndLbl
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
    Public Sub GP_Va_Col_EditColor(ByRef objSpread As GrapeCity.Win.MultiRow.GcMultiRow, ByVal lngCol As Integer, ByVal lngRow As Integer, ByVal bolEdit As Boolean, Optional ByVal lngCol2 As Integer = 0, Optional ByVal lngRow2 As Integer = 0)

        'スプレッドの背景色の設定。
        With objSpread
            '2019/09/26 CHG START
            ''UPGRADE_WARNING: オブジェクト objSpread.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ReDraw = False
            ''UPGRADE_WARNING: オブジェクト objSpread.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row = lngRow
            ''UPGRADE_WARNING: オブジェクト objSpread.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col = lngCol
            'If lngRow2 <> 0 Then
            '    'UPGRADE_WARNING: オブジェクト objSpread.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .Row2 = lngRow2
            'Else
            '    'UPGRADE_WARNING: オブジェクト objSpread.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .Row2 = lngRow
            'End If
            'If lngRow2 <> 0 Then
            '    'UPGRADE_WARNING: オブジェクト objSpread.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .Col2 = lngCol2
            'Else
            '    'UPGRADE_WARNING: オブジェクト objSpread.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .Col2 = lngCol
            'End If
            ''UPGRADE_WARNING: オブジェクト objSpread.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BlockMode = True
            'If bolEdit Then
            '    'UPGRADE_WARNING: オブジェクト objSpread.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .BackColor = LC_lng_va_Edit_Color
            'Else
            '    'UPGRADE_WARNING: オブジェクト objSpread.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .BackColor = LC_lng_va_UnEdit_Color
            'End If
            ''UPGRADE_WARNING: オブジェクト objSpread.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BlockMode = False
            ''UPGRADE_WARNING: オブジェクト objSpread.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ReDraw = True

            .SuspendLayout()

            Dim row2 As Integer
            Dim col2 As Integer

            If lngRow2 <> 0 Then
                row2 = lngRow2
                col2 = lngCol2
            Else
                row2 = lngRow
                col2 = lngCol
            End If

            Dim color As Color

            If bolEdit Then
                color = Color.FromArgb(LC_lng_va_Edit_Color)
            Else
                color = Color.FromArgb(LC_lng_va_UnEdit_Color)
            End If

            For i As Integer = lngRow To row2
                For j As Integer = lngCol To col2
                    .Rows(i).Cells(j).Style.BackColor = color
                Next
            Next

            .ResumeLayout()

            '2019/09/26 CHG END
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
        With vaData
            '2019/09/26 DEL START
            ''UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ReDraw = False
            ''UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col = lngCol
            ''UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col2 = lngCol
            ''UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row = lngRow
            ''UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row2 = lngRow
            ''UPGRADE_WARNING: オブジェクト vaData.CellType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト CellTypeEdit の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.CellType = CellTypeEdit '文字入力
            ''UPGRADE_WARNING: オブジェクト vaData.TypeEditCharSet の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト TypeEditCharSetAlphanumeric の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TypeEditCharSet = TypeEditCharSetAlphanumeric '半角英数字
            ''UPGRADE_WARNING: オブジェクト vaData.GridSolid の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.GridSolid = True
            ''UPGRADE_WARNING: オブジェクト vaData.GridColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.GridColor = &H0
            ''UPGRADE_WARNING: オブジェクト vaData.Position の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト PositionCenterLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Position = PositionCenterLeft
            ''入力桁数をセット
            'Select Case lngCol
            '    Case LC_lngCol_SERIAL
            '        'UPGRADE_WARNING: オブジェクト vaData.TypeMaxEditLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TypeMaxEditLen = C_lngSERIAL_Len
            '    Case LC_lngCol_TNANO
            '        'UPGRADE_WARNING: オブジェクト vaData.TypeMaxEditLen の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '        .TypeMaxEditLen = C_lngTNANO_Len
            'End Select
            ''UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ReDraw = True
            '2019/09/26 DEL END
        End With
    End Sub

    Private Sub vaData_Validate(ByRef Cancel As Boolean)
		L_lngMAX_EditRow = P_Get_EditMaxRow
	End Sub
    '=========================================================================【 メソッド 】=
    '2019/09/26 ADD START
    Public Function PrevInstance() As Boolean
        If Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    '********************************************************************************
    ' @(f)      : Ctrl_send
    '
    ' 機能      : コントロール移動を移動する。
    '
    ' 返り値    :
    '
    ' 引き数    : KeyAscii As Integer
    '
    ' 備考      :

    Function GP_CtrlSend(ByRef KeyAscii As Short, ByRef frm As System.Windows.Forms.Form) As Object
        If KeyAscii = System.Windows.Forms.Keys.Return Then
            PostMessage(frm.Handle.ToInt32, WM_KEYDOWN, System.Windows.Forms.Keys.Tab, &HF021S)
            KeyAscii = 0
        End If
    End Function

    Public Function Nz(ByVal var As Object, Optional ByVal str_Renamed As String = "") As Object

        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(var) = True Then
            If str_Renamed = "" Then
                'UPGRADE_WARNING: オブジェクト Nz の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Nz = ""
            Else
                'UPGRADE_WARNING: オブジェクト Nz の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Nz = str_Renamed
            End If

        ElseIf Len(var) < 1 Then
            If str_Renamed = "" Then
                'UPGRADE_WARNING: オブジェクト Nz の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Nz = ""
            Else
                'UPGRADE_WARNING: オブジェクト Nz の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Nz = str_Renamed
            End If
        Else
            'UPGRADE_WARNING: オブジェクト var の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Nz の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Nz = var
        End If

    End Function

    Public Function StChk(ByVal strVar As String) As String

        Dim strWK As String
        Dim strWk2 As String
        Dim lngIndex As Integer
        Const C_strQut As String = "'"

        'シングルコーテーション1個を2個に置き換える。
        'オラクルのINSERT及び、UPDATE文に使用してください。
        strWK = vbNullString
        If Len(strVar) > 0 Then

            'VB5以下で使用する。
            '        For lngIndex = 1 To Len(strVar)
            '            strWk2 = Mid(strVar, lngIndex, 1)
            '            If strWk2 = C_strQut Then
            '                strWK = strWK & strWk2 & C_strQut
            '            Else
            '                strWK = strWK & strWk2
            '            End If
            '        Next lngIndex

            'VB6以上で使用する。
            strWK = Replace(strVar, "'", "''")
        End If

        StChk = strWK

    End Function

    '2019/09/26 ADD END
End Class