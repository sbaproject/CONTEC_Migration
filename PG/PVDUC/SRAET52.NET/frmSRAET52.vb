Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	'***************************************************************************************
	'*  【使用用途】シリアル№登録
	'*  【作 成 日】2006/09/04  SYSTEM CREATE CO,.Ltd.
	'*  【更 新 日】2008/08/05  FKS)NAKATA
	'*  【備    考】 シリアル管理テーブルの検索条件から実績日を外し、該当するSBNNOとHIMCDが
	'*               あれば全て出力させる
	'***************************************************************************************
	
	'-【 変数宣言 】-------------------------------------------------------------------------
	'AppPath退避用
	Private L_strAppPath As String
	
	'データ登録用
	Private L_strWRTTM As String
	Private L_strWRTDT As String
	
	'パラメータ取得用
	Private L_strRPTCLTID As String
	'2008/08/06 CHG START FKS)NAKATA
	'Private L_strRSTDT                      As String
	Private L_strJDNNO As String
	'2008/08/06 CHG E.N.D FKS)NAKATA
	Private L_strHINCD As String
	Private L_strSBNNO As String
	Private L_strURISU As String
	
	' プロパティ値格納用変数
	Dim mstrRPTCLTID As String
	Dim mstrRSTDT As String
	Dim mstrHINCD As String
	Dim mstrSBNNO As String
	Dim mstrURISU As String
	
	'* 最大入力桁数
	'2008/08/06 CHG START FKS)NAKATA
	''Private Const C_lngSERIAL_Len           As Long = 13        'シリアル№
	Private Const C_lngSERIAL_Len As Integer = 22 'シリアル№ & 実績日
	'2008/08/06 CHG E.N.D FKS)NAKATA
	
	Private LC_lngDataMAX_ROW As Integer
	Private LC_lngCurrent As Integer
	
	'更新確認メッセージキャンセル時のActiveCellセット用
	Private L_LastCol As Integer '列
	Private L_LastRow As Integer '行
	'-------------------------------------------------------------------------【 変数宣言 】-
	
	'-【 定数宣言 】-------------------------------------------------------------------------
	'タイトル
	Private Const LC_strPG_ID As String = "SRAET52"
	Private Const LC_strTitle As String = "シリアル№登録"
	
	' パラメータ スイッチ定義
	Private Const mcPARAM_RPTCLTID As String = "/RPTCLTID:"
	'2008/08/06 CHG START FKS)NAKATA
	''実績日から受注番号に変更
	'Private Const mcPARAM_RSTDT             As String = "/RSTDT:"
	Private Const mcPARAM_JDNNO As String = "/JDNNO:"
	'2008/08/06 CHG E.N.D FKS)NAKATA
	Private Const mcPARAM_HINCD As String = "/HINCD:"
	Private Const mcPARAM_SBNNO As String = "/SBNNO:"
	Private Const mcPARAM_URISU As String = "/URISU:"
	
	'スプレッド背景色
	Private Const LC_lng_va_Edit_Color As Integer = &HFFFF
	Private Const LC_lng_va_UnEdit_Color As Integer = &HFFFFFF
	Private Const LC_lng_va_Lock_Color As Integer = &HC0C0C0
	
	'スプレッドの行
	Private Const LC_lngMAX_ROW As Integer = 999999 '* 最大行数
	Private Const LC_lngDEFAULT_ROW As Integer = 1 '* デフォルトセット行

    'スプレッドの項目    
    Private Const LC_lngCol_CHECK As Integer = 0 '* 返品チェック
    Private Const LC_lngCol_NO As Integer = 1 '* 行№
    Private Const LC_lngCol_SERIAL As Integer = 2 '* シリアル№    

    '出荷済み区分
    Private Const LC_strSYUKA As String = "02"
	
	'SQL文生成時のモード
	Private Enum enumCREATE_MODE
		Ins
		Del
	End Enum
	
	'メッセージ名
	Private Const LC_strAPPEND As String = "_APPEND        " '* 共通メッセージ
	Private Const LC_strCURSOR As String = "_CURSOR        " '* 共通メッセージ
	
	'メッセージＩＤ
	Private Const CommonMSGSQ As String = "0" '* 共通メッセージＩＤ
	Private Const Entry As String = "0" '* 登録確認メッセージ
	Private Const EntryFinal As String = "1" '* 登録後メッセージ
	Private Const NotHINCD As String = "2" '* %CDという商品コードは存在しません。
	Private Const NoData As String = "3" '* 該当データが存在しません。
	Private Const NotSerial As String = "4" '* 返品済のシリアル№が入力されました。よろしいですか。
	Private Const NoCheck As String = "5" '* 登録対象のデータがありません。
    Private Const InfLineOver As String = "6" '* 入力行数が数量と合いません。

    '2019/09/23 ADD START
    'API関数の宣言
    Private Const WM_KEYDOWN As Short = &H100S
    Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" (ByVal hWnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    '2019/09/23 ADD END
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
		Call FR_SSSMAIN_Load(Me, New System.EventArgs())
	End Sub
	'-----------------------------------------------------------------------【ﾌﾟﾙﾀﾞｳﾝﾒﾆｭｰ】-
	
	'===========================================================================
	'【使用用途】 [終了]ボタンクリック時
	'【関 数 名】 CM_EndCm_Click
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Sub CM_EndCm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CM_EndCm.Click
        '2019/10/01 DEL START
        ''* セル背景色を解除
        'With vaData
        '    'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '    '2019/09/23 CHG START
        '    'Call GP_Va_Col_EditColor(vaData, LC_lngCol_NO, 1, False, LC_lngCol_NO, .MaxRows)
        '    Call GP_Va_Col_EditColor(vaData, LC_lngCol_NO, 1, False, LC_lngCol_NO, .RowCount - 1)
        '    '2019/09/23 CHG END
        'End With
        'Me.Close()
        '2019/10/01 DEL END
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

        '2019/10/01 DEL START

        '        Dim msgMsgBox As MsgBoxResult
        '		Dim lngRow As Integer
        '		'UPGRADE_ISSUE: TYPE_DB_SYSTBH オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        '		Dim Mst_Inf As TYPE_DB_SYSTBH
        '		Dim intRet As Short
        '		Dim strMSGKBN As String
        '		Dim strMSGNM As String
        '		Dim lngChkRow As Integer
        '		Dim blnInsFlg As Boolean

        '		strMSGKBN = "1"
        '		lngChkRow = 0
        '		blnInsFlg = False

        '		'* セル背景色を解除
        '		With vaData
        '			Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False)
        '		End With

        '		'スプレッドの入力チェック
        '		If P_EntryCheck(lngRow) = False Then
        '			Exit Sub
        '		Else
        '			'''        '明細にチェックが入っていないときは処理終了
        '			'''        If lngRow = 0 Then
        '			'''            strMSGKBN = "1"
        '			'''            intRet = DSPMSGCM_SEARCH(strMSGKBN, LC_strPG_ID, NoCheck, Mst_Inf)
        '			'''            If intRet <> 0 Then
        '			'''                Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", vbOKOnly + vbExclamation, LC_strTitle)
        '			'''                Exit Sub
        '			'''            End If
        '			'''            Call GP_MsgBox(Exclamation, Mst_Inf.MSGCM, LC_strTitle)
        '			'''            If L_LastCol > 0 And L_LastRow > 0 Then
        '			'''                Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
        '			'''                Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
        '			'''            Else
        '			'''                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, vaData.MaxRows, True)
        '			'''                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, vaData.MaxRows)
        '			'''            End If
        '			'''            Exit Sub
        '			'''        End If
        '			'選択行数が数量と等しくないときはエラー
        '			If lngRow <> CInt(Me.lblURISU.Text) Then
        '				'UPGRADE_WARNING: CM_Execute_Click に変換されていないステートメントがあります。ソース コードを確認してください。
        '				If intRet <> 0 Then
        '					Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
        '					Exit Sub
        '				End If
        '				'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
        '				Exit Sub
        '			End If

        '			'シリアル№チェック
        '			With vaData
        '                'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                '2019/09/23 CHG START
        '                'For lngChkRow = 1 To .MaxRows
        '                For lngChkRow = 1 To .RowCount - 1
        '                    '2019/09/23 CHG END
        '                    If P_EntryCheckSerial(lngChkRow) = False Then
        '                        strMSGKBN = "1"
        '                        'UPGRADE_WARNING: CM_Execute_Click に変換されていないステートメントがあります。ソース コードを確認してください。
        '                        If intRet <> 0 Then
        '                            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, LC_strTitle)
        '                            Exit Sub
        '                        End If
        '                        'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '                        msgMsgBox = GP_MsgBox(COMMON.enmMsg.Insert, Mst_Inf.MSGCM, LC_strTitle)
        '                        If msgMsgBox <> MsgBoxResult.Yes Then
        '                            If lngChkRow > 0 Then
        '                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, lngChkRow, True)
        '                                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, lngChkRow)
        '                            Else
        '                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
        '                                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
        '                            End If
        '                            Exit Sub
        '                        Else
        '                            blnInsFlg = True
        '                        End If
        '                    End If
        '                Next
        '            End With
        '		End If

        '		If blnInsFlg = False Then
        '			'UPGRADE_WARNING: CM_Execute_Click に変換されていないステートメントがあります。ソース コードを確認してください。
        '			If intRet <> 0 Then
        '				Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
        '				Exit Sub
        '			End If
        '			'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			msgMsgBox = GP_MsgBox(Common.enmMsg.Insert, Mst_Inf.MSGCM, LC_strTitle)
        '			If msgMsgBox <> MsgBoxResult.Yes Then
        '				Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
        '				Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
        '				'        If L_LastCol > 0 And L_LastRow > 0 Then
        '				'            Call GP_Va_Col_EditColor(vaData, L_LastCol, L_LastRow, True)
        '				'            Call GP_SpActiveCell(vaData, L_LastCol, L_LastRow)
        '				'        Else
        '				'            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, vaData.MaxRows, True)
        '				'            Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, vaData.MaxRows)
        '				'        End If
        '				Exit Sub
        '			End If
        '		End If

        '		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        '		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        '		'登録処理
        '		If P_Main() = True Then
        '			'* データ登録後は画面を閉じる
        '			Call CM_EndCm_Click(CM_EndCm, New System.EventArgs())
        '			Exit Sub
        '		End If

        'EndLabel: 
        '		'* セル背景色を設定
        '		Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)

        '		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        '		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        '2019/10/01 DEL END

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
        '2019/09/23 DEL START
        'If App.PrevInstance Then
        '    Call GP_MsgBox(COMMON.enmMsg.Critical, "既に起動しています。", LC_strTitle)
        '    End
        'End If
        '2019/09/23 DEL END
        'フォームの位置をセット
        Me.Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Me.Height)) / 2)
		Me.Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Me.Width)) / 2)
		
		'AppPathの退避
		L_strAppPath = My.Application.Info.DirectoryPath
		
		'パラメータ取得
		strArry = Split(Replace(VB.Command(), """", ""), " ")
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
			Call GP_MsgBox(Common.enmMsg.Critical, "ワークステーションＩＤが設定されていません。", LC_strTitle)
			End
		End If
		
		'2008/08/06 CHG START FKS)NAKATA
		'' 実績日から受注番号に変更
		''    If L_strRSTDT = "" Then
		''        Call GP_MsgBox(Critical, "実績日が設定されていません。", LC_strTitle)
		''        End
		''    End If
		If L_strJDNNO = "" Then
			Call GP_MsgBox(Common.enmMsg.Critical, "受注番号が設定されていません。", LC_strTitle)
			End
		End If
		'2008/08/06 CHG E.N.D FKS)NAKATA
		
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
		
		'スプレッドの初期化
		Call P_vaData_Init()
		
		'DB接続
		Call CF_Ora_USR1_Open()
        Call CF_Ora_USR9_Open()

        '受け取ったパラメータを画面にセット
        lblHIN1.Text = L_strHINCD
		If P_GET_HINNMA(L_strHINCD, strHINNM) = True Then
			lblHIN2.Text = strHINNM
		Else
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
        LC_lngCurrent = 1

        '2019/10/01 ADD START
        SetBar(Me)
        '2019/10/01 ADD END

        '画面の初期表示
        If P_Show_Data = False Then
			'データがないとき
			strMSGKBN = "1"
			'UPGRADE_WARNING: Form_Load に変換されていないステートメントがあります。ソース コードを確認してください。
			If intRet <> 0 Then
				Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, LC_strTitle)
				End
			End If
			'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call GP_MsgBox(Common.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
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
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        'DB接続解除
        '2019/09/23 CHG START        
        'Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
        Call DB_CLOSE(CON)
        '2019/09/23 CHG END
        '2019/09/23 ADD START
        DB_CLOSE(CON_USR9)
        Call SSSWIN_LOGWRT("プログラム終了")
        '2019/09/23 ADD END
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
	'【備    考】
	'===========================================================================
	Private Sub vaData_EditChange(ByVal Col As Integer, ByVal Row As Integer)

        With vaData
            '2019/10/01 DEL START
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
            '        .Col2 = LC_lngCol_SERIAL
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
            '    End If
            'End If
            '2019/10/01 DEL END
        End With

    End Sub
	
	Private Sub vaData_KeyPress(ByRef KeyAscii As Short)
		
		Dim msgMsgBox As MsgBoxResult
		Dim strMSGKBN As String
		Dim strMSGNM As String
		'UPGRADE_ISSUE: TYPE_DB_SYSTBH オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim Mst_Inf As TYPE_DB_SYSTBH
		Dim intRet As Short

        'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/10/01 CHG START
        'If LC_lngCurrent = vaData.MaxRows Then
        If LC_lngCurrent = vaData.RowCount - 1 Then
            '2019/10/01 CHG END
            L_LastCol = LC_lngCol_CHECK
            'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/10/01 CHG START
            'L_LastRow = vaData.MaxRows
            L_LastRow = vaData.RowCount - 1
            '2019/10/01 CHG END
            '2019/10/01 CHG START
            'Call CM_Execute_Click(CM_Execute, New System.EventArgs())
            btnF1.PerformClick()
            '2019/10/01 CHG END
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
	Private Sub vaData_LeaveCell(ByVal Col As Integer, ByVal Row As Integer, ByVal NewCol As Integer, ByVal NewRow As Integer, ByRef Cancel As Boolean)
		
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
        '2019/09/23 DEL START
        'カーソル制御。
        '      With vaData
        '	'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	If .ActiveRow > 0 Then
        '		'UPGRADE_WARNING: オブジェクト vaData.ActiveCol の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		If .ActiveCol = 1 Then
        '			'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, .ActiveRow)
        '		Else
        '			'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト vaData.ActiveCol の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			Call GP_SpActiveCell(vaData, .ActiveCol, .ActiveRow)
        '		End If
        '		''''    Else                '2006.09.28
        '		''''        cmdExe.SetFocus '2006.09.28
        '	Else
        '		txtDummy.Focus()
        '	End If
        '	'UPGRADE_WARNING: オブジェクト vaData.ActiveRow の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, .ActiveRow, True)
        'End With
        '2019/09/23 DEL END
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
            '2019/09/23 CHG START
            ''UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row = 1
            ''UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row2 = .MaxRows
            ''UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col = LC_lngCol_NO
            ''UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col2 = LC_lngCol_SERIAL
            ''UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BlockMode = True
            ''UPGRADE_WARNING: オブジェクト vaData.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BackColor = System.Drawing.ColorTranslator.ToOle(Me.BackColor)
            ''UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BlockMode = False

            For i As Integer = 0 To .RowCount - 1
                .Rows(i).Cells(LC_lngCol_NO).Style.BackColor = Me.BackColor
                .Rows(i).Cells(LC_lngCol_SERIAL).Style.BackColor = Me.BackColor
            Next

            '2019/09/23 CHG END
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
            ''2019/09/23 CHG START
            ''UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row = 1
            ''UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col = LC_lngCol_NO
            ''UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row2 = .MaxRows
            ''UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col2 = LC_lngCol_SERIAL
            ''UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BlockMode = True
            ''UPGRADE_WARNING: オブジェクト vaData.Protect の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Protect = True
            ''UPGRADE_WARNING: オブジェクト vaData.Lock の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Lock = True
            ''UPGRADE_WARNING: オブジェクト vaData.BlockMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.BlockMode = False

            For i As Integer = 0 To .RowCount - 1
                .Rows(i).Cells(LC_lngCol_NO).Enabled = False
                .Rows(i).Cells(LC_lngCol_SERIAL).Enabled = False
            Next

            '2019/09/23 CHG END
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
		
		P_Show_Data = False
		
		'スプレッドのクリア
		Call P_vaData_Init()
		
		'データの取得。
		If P_Get_Data(Usr_Ody_LC) = True Then
			'データを画面に表示する。
			Call P_Set_Data(Usr_Ody_LC)
			'スプレッドの入力制限。
			Call P_Va_Lock()
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
		
		Dim lngI As Integer
		Dim lngJ As Integer
		Dim blnFLG As Boolean
		Dim intLen As Short
		
		'2008/08/06 ADD START FKS)NAKATA
		Dim wkSRANO As String 'シリアル№ワーク
		Dim wkRSTDT As String '実績日ワーク
		'2008/08/06 ADD E.N.D FKS)NAKATA
		
		
		On Error GoTo ErrLbl
		
		P_Set_Data = False
		
		lngI = 0
		blnFLG = False

        intLen = Len(CStr(LC_lngMAX_ROW))

        '2019/09/23 ADD START
        Dim dt As DataTable = Usr_Ody_LC.dt
        '2019/09/23 ADD END        

        With vaData

            '2019/09/23 CHG START

            ''スプレッドの行数の設定
            ''UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。            
            ''.ReDraw = False
            '''UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。            
            ''.MaxRows = 0
            ''スプレッドにデータを表示する。
            'Do Until CF_Ora_EOF(Usr_Ody_LC) = True
            '    lngI = lngI + 1

            '    '2008/08/06 ADD START FKS)NAKATA
            '    'DBより取得したシリアル№と実績日を格納
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    wkSRANO = CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", "")
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    wkRSTDT = CF_Ora_GetDyn(Usr_Ody_LC, "RSTDT", "")
            '    '2008/08/06 ADD E.N.D FKS)NAKATA


            '    'LC_lngMAX_ROW行を超えたときは強制的にLOOP処理を抜ける
            '    If lngI > LC_lngMAX_ROW Then
            '        GoTo LBL_LOOP_END
            '    End If
            '    'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    .MaxRows = .MaxRows + 1
            '    Call SetCheckBox(vaData, LC_lngCol_CHECK, lngI)
            '    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody_LC, KBN, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    If CF_Ora_GetDyn(Usr_Ody_LC, "KBN", "") = "C" Then
            '        'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。                    
            '        Call .SetText(LC_lngCol_CHECK, lngI, "1")
            '    End If
            '    'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。                
            '    Call .SetText(LC_lngCol_NO, lngI, VB.Right(Space(intLen) & CStr(lngI), intLen))

            '    '2008/08/06 ADD START FKS)NAKATA
            '    ''スプレッドにシリアル№と実績日をスペースを1つ入れ格納
            '    ''            Call .SetText(LC_lngCol_SERIAL, lngI, CF_Ora_GetDyn(Usr_Ody_LC, "SRANO", ""))
            '    'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。                
            '    Call .SetText(LC_lngCol_SERIAL, lngI, wkSRANO & " " & wkRSTDT)

            '    '2008/08/06 ADD E.N.D FKS)NAKATA

            '    Call CF_Ora_MoveNext(Usr_Ody_LC)
            'Loop

            '.Template = Me.Template31

            .SuspendLayout()

            If dt Is Nothing OrElse dt.Rows.Count > 0 Then

                If dt.Rows.Count > LC_lngMAX_ROW Then
                    .RowCount = LC_lngMAX_ROW
                Else
                    .RowCount = dt.Rows.Count
                End If

                For cnt As Integer = 0 To dt.Rows.Count - 1

                    lngI = lngI + 1

                    wkSRANO = Trim(DB_NullReplace(dt.Rows(cnt)("SRANO"), ""))

                    wkRSTDT = Trim(DB_NullReplace(dt.Rows(cnt)("RSTDT"), ""))

                    If lngI > LC_lngMAX_ROW Then
                        GoTo LBL_LOOP_END
                    End If

                    '.RowCount = cnt + 1

                    Call SetCheckBox(vaData, LC_lngCol_CHECK, lngI)

                    If Trim(DB_NullReplace(dt.Rows(cnt)("KBN"), "")) = "C" Then
                        .SetValue(cnt, LC_lngCol_CHECK, False)
                    End If

                    .SetValue(cnt, LC_lngCol_NO, VB.Right(Space(intLen) & CStr(lngI), intLen))

                    .SetValue(cnt, LC_lngCol_SERIAL, wkSRANO & " " & wkRSTDT)

                Next

            End If

            '2019/09/23 CHG END            

LBL_LOOP_END:
            'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Usr_Ody_LC.Obj_Ody.RecordCount の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/09/23 CHG START
            '.MaxRows = Usr_Ody_LC.Obj_Ody.RecordCount
            '''UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'LC_lngDataMAX_ROW = .MaxRows

            ''背景色の設定
            'Call P_Va_BackColor()

            ''UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。           
            '.ReDraw = True            

            LC_lngDataMAX_ROW = .RowCount

            '背景色の設定
            Call P_Va_BackColor()

            .ResumeLayout()

            '2019/09/23 CHG END
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
	'【更 新 日】 2008/08/06 FKS)NAKATA
	'【備    考】 実績日の取得を追加
	'===========================================================================
	Private Function P_Get_Data(ByRef Usr_Ody_LC As U_Ody) As Boolean
		
		Dim strSQL As String
		Dim strWKRSTDT As String
		Dim strWKRPTCLTID As String
		Dim strDB As String
		
		'2008/08/06 ADD START FKS)NAKATA
		Dim strPUDLNO As String
		'2008/08/06 ADD E.N.D FKS)NAKATA
		
		
		On Error GoTo Errlabel
		
		
		'2008/08/06 ADD START FKS)NAKATA
		''JDNTRAよりPUDLNOの取得
		If P_GET_PUDLNO(L_strJDNNO, strPUDLNO) = False Then
			strPUDLNO = ""
		End If
		'2008/08/06 ADD E.N.D FKS)NAKATA
		
		
		P_Get_Data = False
		
		'strWKRSTDT = Left(L_strRSTDT & Space(8), 8)
		strWKRPTCLTID = VB.Left(L_strRPTCLTID & Space(5), 5)

        '2019/09/24 CHG START
        'strDB = Get_DBHEAD() & "_" & ORA_MAX_USR9
        strDB = "CNT_USR9"
        '2019/09/24 CHG END

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
        '    strSQL = strSQL & vbCrLf & " Where   SRA.RSTDT     = " & "'" & strWKRSTDT & "'"
        '    strSQL = strSQL & vbCrLf & "   And   SRA.SBNNO     = " & "'" & L_strSBNNO & "'"
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

        'strSQL = strSQL & vbCrLf & " Order By SRA.SRANO FETCH FIRST 10 ROWS ONLY"


        'DBアクセス
        Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_LC, strSQL)


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
		Dim intLen As Short
		
		lngI = 0
		intLen = Len(CStr(LC_lngMAX_ROW))

        With vaData
            '2019/09/23 CHG START
            ''スプレッドのクリア
            ''UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ReDraw = False
            ''UPGRADE_WARNING: オブジェクト vaData.Action の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト ActionClearText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Action = ActionClearText
            ''UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.MaxRows = LC_lngDEFAULT_ROW
            ''UPGRADE_WARNING: オブジェクト vaData.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col = LC_lngCol_CHECK
            ''UPGRADE_WARNING: オブジェクト vaData.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col2 = LC_lngCol_CHECK
            ''UPGRADE_WARNING: オブジェクト vaData.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row = 1
            ''UPGRADE_WARNING: オブジェクト vaData.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row2 = .MaxRows
            ''UPGRADE_WARNING: オブジェクト vaData.CellType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト CellTypeCheckBox の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.CellType = CellTypeCheckBox
            ''UPGRADE_WARNING: オブジェクト vaData.GridColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.GridColor = &H0
            ''UPGRADE_WARNING: オブジェクト vaData.GridSolid の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.GridSolid = True
            ''UPGRADE_WARNING: オブジェクト vaData.TypeCheckType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト TypeCheckTypeNormal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TypeCheckType = TypeCheckTypeNormal
            ''UPGRADE_WARNING: オブジェクト vaData.TypeCheckCenter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TypeCheckCenter = True
            ''UPGRADE_WARNING: オブジェクト vaData.TypeCheckText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TypeCheckText = ""
            'Call SetEdit(vaData, LC_lngCol_NO, 1)
            'Call SetEdit(vaData, LC_lngCol_SERIAL, 1)
            ''行番号をセット
            ''UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'For lngI = 0 To vaData.MaxRows
            '    lngI = lngI + 1
            '    'UPGRADE_WARNING: オブジェクト vaData.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    Call .SetText(LC_lngCol_NO, lngI, VB.Right(Space(intLen) & CStr(lngI), intLen))
            'Next
            ''UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ReDraw = True

            .SuspendLayout()

            .RowCount = LC_lngDEFAULT_ROW

            '行番号をセット
            For lngI = 0 To vaData.RowCount - 1
                Call .SetValue(lngI, LC_lngCol_NO, VB.Right(Space(intLen) & CStr(lngI + 1), intLen))
            Next

            .ResumeLayout()

            '2019/09/23 CHG END

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
	'【使用用途】 スプレッド入力チェック（メイン）
	'【関 数 名】 P_EntryCheck
	'【引    数】 ByRef lngEntryLine As Long  :有効行数
	'【返    値】 Boolean
	'【更 新 日】
	'【備    考】
	'===========================================================================
	Private Function P_EntryCheck(ByRef lngEntryLine As Integer) As Boolean
		
		Dim lngI As Integer
		Dim varCHECK As Object
		Dim lngCount As Integer
		
		P_EntryCheck = False
		
		With vaData
            'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/09/23 CHG START
            'For lngI = 1 To .MaxRows
            For lngI = 0 To .RowCount - 1
                'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Call .GetText(LC_lngCol_CHECK, lngI, varCHECK)
                varCHECK = .GetValue(lngI, LC_lngCol_CHECK)
                '2019/09/23 CHG END
                'UPGRADE_WARNING: オブジェクト Nz(varCHECK) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
	Private Function P_EXECUTE_SQL(ByVal strMode As enumCREATE_MODE, ByVal strSRANO As String, ByVal strWRTTM As String, ByVal strWRTDT As String) As Boolean
		Dim strSQL As String
		
		'2008/08/06 ADD START FKS)NAKATA
		Dim wkSRANO As String
		Dim wkRSTDT As String
		'2008/08/06 ADD E.N.D FKS)NAKATA
		
		
		P_EXECUTE_SQL = False
		
		strSQL = vbNullString
		
		'2008/08/06 ADD START FKS)NAKATA
		''パラメータをシリアル№と実績日に分ける
		wkSRANO = VB.Left(Trim(strSRANO), 13)
		wkRSTDT = VB.Right(Trim(strSRANO), 8)
		'2008/08/06 ADD E.N.D FKS)NAKATA
		
		Select Case strMode
            Case enumCREATE_MODE.Ins
                '2019/10/01 CHG START
                'strSQL = strSQL & " INSERT INTO SRAET52 (" & vbCrLf
                strSQL = strSQL & " INSERT INTO CNT_USR9.SRAET52 (" & vbCrLf
                '2019/10/01 CHG END
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
                '2019/10/01 CHG START
                'strSQL = strSQL & " DELETE FROM SRAET52" & vbCrLf
                strSQL = strSQL & " DELETE FROM CNT_USR9.SRAET52" & vbCrLf
                '2019/10/01 CHG END
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
		
		Dim lngI As Integer
		Dim lngLineNo As Integer
		Dim strSQL As String
		Dim varCHECK As Object
		Dim varNO As Object
		Dim varSERIAL As Object
		Dim varSBNNO As Object
		Dim datNOW As Date
		Dim intCnt As Short
		Dim intMaxKeta As Short
		Dim strZero As String
		
		P_Main = False

        'BEGIN TRAN
        '2019/09/23 CHG START
        'If CF_Ora_BeginTrans(gv_Oss_USR9) = False Then
        If DB_BeginTrans(CON) = False Then
            '2019/09/23 CHG END
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
		If P_EXECUTE_SQL(enumCREATE_MODE.Del, "", "", "") = False Then
			GoTo EndLbl
		End If
		
		'INSERT
		lngI = 0
		lngLineNo = 0
		With vaData
            'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/09/23 CHG START
            'For lngI = 1 To .MaxRows
            '    'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    Call .GetText(LC_lngCol_CHECK, lngI, varCHECK)
            '    'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    Call .GetText(LC_lngCol_NO, lngI, varNO)
            '    'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '    Call .GetText(LC_lngCol_SERIAL, lngI, varSERIAL)
            For lngI = 0 To .RowCount - 1
                varCHECK = .GetValue(lngI, LC_lngCol_CHECK)
                varNO = .GetValue(lngI, LC_lngCol_NO)
                varSERIAL = .GetValue(lngI, LC_lngCol_SERIAL)
                '2019/09/23 CHG END
                'UPGRADE_WARNING: オブジェクト Nz(varCHECK) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If Nz(varCHECK) = "1" Then
                    lngLineNo = lngLineNo + 1
                    'UPGRADE_WARNING: オブジェクト varSERIAL の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If P_EXECUTE_SQL(enumCREATE_MODE.Ins, CStr(varSERIAL), L_strWRTTM, L_strWRTDT) = False Then
                        GoTo EndLbl
                    End If
                End If
            Next lngI
        End With
		
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

            '2019/10/01 CHG START

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


            Dim row2 As Integer
            Dim col2 As Integer

            If lngRow2 <> 0 Then
                row2 = lngRow2
                col2 = lngCol2
            Else
                row2 = lngRow
                col2 = lngCol
            End If

            Dim backColor As Color

            If bolEdit Then
                backColor = Color.FromArgb(LC_lng_va_Edit_Color)
            Else
                backColor = Color.FromArgb(LC_lng_va_UnEdit_Color)
            End If

            For i As Integer = lngRow To row2
                For j As Integer = lngCol To col2
                    .Rows(i).Cells(j).Style.BackColor = backColor
                Next
            Next

            '2019/10/01 CHG END

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
    Private Sub SetCheckBox(ByRef objSpread As Object, ByVal lngCol As Integer, ByVal lngRow As Integer)
        Dim TypeVAlignCenter As Object
        Dim TypeHAlignCenter As Object
        Dim TypeCheckTextAlignRight As Object
        Dim TypeCheckTypeNormal As Object
        Dim CellTypeCheckBox As Object


        With objSpread
            '2019/09/23 DEL START
            ''UPGRADE_WARNING: オブジェクト objSpread.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col = lngCol
            ''UPGRADE_WARNING: オブジェクト objSpread.Col2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col2 = lngCol
            ''UPGRADE_WARNING: オブジェクト objSpread.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row = lngRow
            ''UPGRADE_WARNING: オブジェクト objSpread.Row2 の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row2 = lngRow
            ''UPGRADE_WARNING: オブジェクト objSpread.CellType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト CellTypeCheckBox の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.CellType = CellTypeCheckBox ' ｾﾙﾀｲﾌﾟの設定
            ''UPGRADE_WARNING: オブジェクト objSpread.TypeCheckText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TypeCheckText = "" ' ﾁｪｯｸﾎﾞｯｸｽ ｷｬﾌﾟｼｮﾝ
            ''UPGRADE_WARNING: オブジェクト objSpread.TypeCheckType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト TypeCheckTypeNormal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TypeCheckType = TypeCheckTypeNormal ' ﾁｪｯｸﾎﾞｯｸｽ ﾀｲﾌﾟ
            ''UPGRADE_WARNING: オブジェクト objSpread.TypeCheckTextAlign の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト TypeCheckTextAlignRight の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TypeCheckTextAlign = TypeCheckTextAlignRight ' ﾃｷｽﾄ配置
            ''UPGRADE_WARNING: オブジェクト objSpread.TypeHAlign の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト TypeHAlignCenter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TypeHAlign = TypeHAlignCenter ' 水平配置
            ''UPGRADE_WARNING: オブジェクト objSpread.TypeVAlign の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト TypeVAlignCenter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TypeVAlign = TypeVAlignCenter ' 垂直配置
            ''UPGRADE_WARNING: オブジェクト objSpread.TypeCheckCenter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.TypeCheckCenter = True ' 中央配置            
            '2019/09/23 DEL END
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
    Private Function P_EntryCheckSerial(ByVal lngLineNo As Integer) As Boolean
		
		Dim varCHECK As Object
		Dim varSERIAL As Object
		Dim strKBN As String
		
		P_EntryCheckSerial = False
		
		With vaData
            'UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/09/23 CHG START
            'Call .GetText(LC_lngCol_CHECK, lngLineNo, varCHECK)
            ''UPGRADE_WARNING: オブジェクト vaData.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Call .GetText(LC_lngCol_SERIAL, lngLineNo, varSERIAL)
            varCHECK = .GetValue(lngLineNo, LC_lngCol_CHECK)
            varSERIAL = .GetValue(lngLineNo, LC_lngCol_SERIAL)
            '2019/09/23 CHG END
            'UPGRADE_WARNING: オブジェクト Nz(varCHECK) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            If Nz(varCHECK) = "1" Then
				'UPGRADE_WARNING: オブジェクト Nz() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
		
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		Dim strWKRPTCLTID As String
		Dim strWKSRANO As String
		
		P_SRANOCheckWK = False
		
		strWKRPTCLTID = VB.Left(L_strRPTCLTID & Space(5), 5)
		strWKSRANO = VB.Left(strSRANO & Space(13), 13)
		
		'SQL文作成
		strSQL = vbNullString
        strSQL = strSQL & " SELECT  * "
        '2019/10/01 CHG START
        'strSQL = strSQL & " FROM    SRAET52"
        strSQL = strSQL & " FROM    CNT_USR9.SRAET52"
        '2019/10/01 CHG END
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
		Call GP_MsgBox(Common.enmMsg.Critical, "データ取得時にエラーが発生しました。(P_SRANOCheck)" & vbCrLf & Err.Number & ":" & Err.Description, CStr(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly))
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
    Private Sub SetEdit(ByRef objSpread As Object, ByVal lngCol As Integer, ByVal lngRow As Integer)
        Dim PositionCenterLeft As Object
        Dim TypeEditCharSetAlphanumeric As Object
        Dim CellTypeEdit As Object
        With vaData
            '2019/09/23 DEL START
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
            'End Select
            ''UPGRADE_WARNING: オブジェクト vaData.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.ReDraw = True
            '2019/09/23 DEL END
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
    Private Function P_GET_PUDLNO(ByVal strJdnNo As String, ByRef strPUDLNO As String) As Boolean
		
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody_LC の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_LC As U_Ody
		Dim wkJDNNO As String
		Dim wkLINNO As String
		
		P_GET_PUDLNO = False
		strPUDLNO = ""
		
		wkJDNNO = VB.Left(strJdnNo, 6)
		wkLINNO = VB.Right(strJdnNo, 3)
		
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
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strPUDLNO = CF_Ora_GetDyn(Usr_Ody_LC, "PUDLNO", "")
			P_GET_PUDLNO = True
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody_LC)
		
		Exit Function
Errlabel: 
		Call GP_MsgBox(Common.enmMsg.Critical, "データ取得時にエラーが発生しました。(P_GET_PUDLNO)" & vbCrLf & Err.Number & ":" & Err.Description, CStr(MsgBoxStyle.Critical + MsgBoxStyle.OKOnly))
	End Function

    ''2008/08/06 ADD E.N.D FKS)NAKATA

    '2019/09/23 ADD START
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

    'Public Sub SetBar(ByRef pForm As Form)
    '    Try
    '        DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel1").Text = DB_NullReplace(CNV_DATE(DB_UNYMTA.UNYDT), Format(Now(), "yyyy/MM/dd"))
    '        DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel2").Text = DB_NullReplace(DB_UNYMTA.TERMNO, "")
    '        DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel3").Text = DB_NullReplace(SSS_OPEID.Value, "")
    '        DirectCast(pForm.Controls("StatusStrip1"), StatusStrip).Items("ToolStripStatusLabel4").Text = My.Application.Info.AssemblyName
    '    Catch ex As Exception
    '        MsgBox("ﾀｲﾄﾙﾊﾞｰ,ｽﾃｰﾀｽﾊﾞｰ設定関数エラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
    '    End Try

    'End Sub

    Private Sub FR_SSSMAIN_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim li_MsgRtn As Integer

        Try
            Select Case e.KeyCode
                Case Keys.F1
                    '更新
                    Me.btnF1.PerformClick()

                Case Keys.F9
                    'クリア
                    Me.btnF9.PerformClick()

                Case Keys.F12
                    '終了
                    Me.btnF12.PerformClick()

            End Select

        Catch ex As Exception
            li_MsgRtn = MsgBox("フォームKeyDownエラー" & Constants.vbCrLf & ex.Message.ToString, MsgBoxStyle.Critical, "エラー")
        End Try
    End Sub

    Private Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click

        '2019/10/01 ADD START

        Dim msgMsgBox As MsgBoxResult
        Dim lngRow As Integer
        'UPGRADE_ISSUE: TYPE_DB_SYSTBH オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
        Dim Mst_Inf As TYPE_DB_SYSTBH
        Dim intRet As Short
        Dim strMSGKBN As String
        Dim strMSGNM As String
        Dim lngChkRow As Integer
        Dim blnInsFlg As Boolean

        strMSGKBN = "1"
        lngChkRow = 0
        blnInsFlg = False

        '* セル背景色を解除
        With vaData
            '2019/10/01 CHG START
            'Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, False)
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 0, False)
            '2019/10/01 CHG END
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
            If lngRow <> CInt(Me.lblURISU.Text) Then
                'UPGRADE_WARNING: CM_Execute_Click に変換されていないステートメントがあります。ソース コードを確認してください。
                If intRet <> 0 Then
                    Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, LC_strTitle)
                    Exit Sub
                End If
                'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call GP_MsgBox(COMMON.enmMsg.Exclamation, Mst_Inf.MSGCM, LC_strTitle)
                Exit Sub
            End If

            'シリアル№チェック
            With vaData
                'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '2019/09/23 CHG START
                'For lngChkRow = 1 To .MaxRows
                For lngChkRow = 0 To .RowCount - 1
                    '2019/09/23 CHG END
                    If P_EntryCheckSerial(lngChkRow) = False Then
                        strMSGKBN = "1"
                        'UPGRADE_WARNING: CM_Execute_Click に変換されていないステートメントがあります。ソース コードを確認してください。
                        If intRet <> 0 Then
                            Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, LC_strTitle)
                            Exit Sub
                        End If
                        'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        msgMsgBox = GP_MsgBox(COMMON.enmMsg.Insert, Mst_Inf.MSGCM, LC_strTitle)
                        If msgMsgBox <> MsgBoxResult.Yes Then
                            If lngChkRow > 0 Then
                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, lngChkRow, True)
                                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, lngChkRow)
                            Else
                                '2019/10/01 CHG START
                                'Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
                                'Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
                                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 0, True)
                                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 0)
                                '2019/10/01 CHG END
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
            'UPGRADE_WARNING: CM_Execute_Click に変換されていないステートメントがあります。ソース コードを確認してください。
            If intRet <> 0 Then
                Call MsgBox("エラーが発生しました。システムメッセージテーブルを確認してください。", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, LC_strTitle)
                Exit Sub
            End If
            'UPGRADE_WARNING: オブジェクト Mst_Inf.MSGCM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            msgMsgBox = GP_MsgBox(COMMON.enmMsg.Insert, Mst_Inf.MSGCM, LC_strTitle)
            If msgMsgBox <> MsgBoxResult.Yes Then
                '2019/10/01 CHG START
                'Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
                'Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 1)
                Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 0, True)
                Call GP_SpActiveCell(vaData, LC_lngCol_CHECK, 0)
                '2019/10/01 CHG END
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

        'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

        '登録処理
        If P_Main() = True Then
            '* データ登録後は画面を閉じる
            '2019/10/01 CHG START
            'Call CM_EndCm_Click(CM_EndCm, New System.EventArgs())
            btnF12.PerformClick()
            '2019/10/01 CHG END
            Exit Sub
        End If

EndLabel:
        '* セル背景色を設定
        '2019/10/01 CHG START
        'Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 1, True)
        Call GP_Va_Col_EditColor(vaData, LC_lngCol_CHECK, 0, True)
        '2019/10/01 CHG END
        'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        '2019/10/01 ADD END

    End Sub

    Private Sub btnF12_Click(sender As Object, e As EventArgs) Handles btnF12.Click
        '2019/10/01 ADD START
        '* セル背景色を解除
        With vaData
            'UPGRADE_WARNING: オブジェクト vaData.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/09/23 CHG START
            'Call GP_Va_Col_EditColor(vaData, LC_lngCol_NO, 1, False, LC_lngCol_NO, .MaxRows)
            Call GP_Va_Col_EditColor(vaData, LC_lngCol_NO, 0, False, LC_lngCol_NO, .RowCount - 1)
            '2019/09/23 CHG END
        End With
        Me.Close()
        '2019/10/01 ADD END
    End Sub

    Private Sub btnF9_Click(sender As Object, e As EventArgs) Handles btnF9.Click
        Call FR_SSSMAIN_Load(Me, New System.EventArgs())
    End Sub

    '2019/09/23 ADD END
End Class