Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Friend Class FR_SSSMAIN
	Inherits System.Windows.Forms.Form
	'//* All Right Reserved Copy Right (C)  株式会社富士通関西システムズ
	'//***************************************************************************************
	'//*
	'//*＜名称＞
	'//* URKET73 前受充当戻し
	'//*
	'//*＜バージョン＞
	'//* 1.00
	'//*
	'//*＜作成者＞
	'//* FKS)
	'//*
	'//*＜説明＞
	'//* 前受充当の戻し処理画面
	'//*
	'//**************************************************************************************
	'//*変更履歴
	'//* ﾊﾞｰｼﾞｮﾝ  |  日付    | 更新者        |内容
	'//* ---------|----------|---------------|-----------------------------------------------
	'//* 1.00     |2009/06/13|FKS)中田       |新規作成(URKET53 入金消込より流用作成)
	'//* 1.01     |2009/07/06|FKS)中田       |消込可能金額取得ロジックの追加
	'//* 1.02     |2009/08/28|FKS)中田       |消込可能金額取得ロジックの変更(getUdntraNyukn)
	'//* 1.03     |2009/09/03|FKS)中田       |振込期日に関する処理を変更(戻し画面からの入力をできなくする)
	'//*          |          |               |　振込期日(cmd_fridt/txt_fridt)のVisibleを
	'//* 　　　　 |          |               |　「Ture」から「False」へ変更
	'//* 　　　　 |          |               |　振込期日(txt_fridt)のTabStopを「Ture」から「False」へ変更
	'//* 1.04     |2009/09/07|FKS)中田       |請求締日以前の日付を入力不可とする。
	'//* 　　　　 |          |               |請求先の担当者が営業担当で無い場合、エラーとする。
	'//* 2.00     |2009/09/16|FKS)中田       |・入金消込サマリーの本入金項目に対して何も更新しないようにする
	'//*          |          |               |・前月解除時の入金消込サマリーの戻し先変更（入金→消込）
	'//*          |          |               |・手数料・消費は自身の持っている入金区分にて消込トランを作成する
	'//*          |          |               |・分納対応のため、金額チェック・伝票単位チェックを外す
	'//**************************************************************************************
	
	
	
	Private Declare Function ReleaseTabCapture Lib "TabCap.DLL" (ByVal hwnd As Integer) As Integer
	Private Declare Function SetTabCapture Lib "TabCap.DLL" (ByVal hwnd As Integer) As Integer
	
	Dim intUrigoukei As Decimal '売上金額の合計を格納（明細表示時にセット）
	Dim intBfkesiknkei As Decimal '消込済額(締日前)の合計額を格納（明細表示時にセット）
	
	
	Dim blnFriEnabled As Boolean '振込期日を入力できるかどうかのフラグ(判定は「手形」「振込期日（ファクタリング）」が存在する時）
	
	Dim blnUsableSpread As Boolean 'ｽﾌﾟﾚｯﾄﾞのｲﾍﾞﾝﾄを実行するかどうかのﾌﾗｸﾞ
	Dim intMaxRow As Short 'ｽﾌﾟﾚｯﾄﾞの表示最大行数を格納
	
	Dim blnUsableButton As Boolean '手数料、消費税差額、全消込、全解除、再表示、振込期日(明細部)のｲﾍﾞﾝﾄを実行するかどうかのﾌﾗｸﾞ
	Dim intChkKb As Short 'チェック区分(1:チェック 2:チェック(前回から変更時のみ)
	Dim blnUsableEvent As Boolean 'ｲﾍﾞﾝﾄを実行するかどうかのﾌﾗｸﾞ(汎用)
	Dim blnINIT_FLG As Boolean
	
	
	Dim intInputMode As Short '入力状態(1:ヘッダー 2:明細 9:画面クリアー処理)
	
	
	''赤黒チェック用構造体
	Private Structure TYPE_AKAKRO_CHK
		Dim idx As Integer '行番号
		Dim CHKMK As Short 'チェックマーク
		Dim UDNDT As String '売上日
		Dim JDNNO As String '受注№
		Dim KESIKN As Decimal '消込金額
	End Structure
	
	Private AKAKRO_CHK() As TYPE_AKAKRO_CHK
	
	
	''伝票単位チェック用構造体
	Private Structure TYPE_JDNTRKB_CHK
		Dim idx As Integer '行番号
		Dim JDNNO As String '受注№
		Dim HYJDNNO As String '表示用受注番号
		Dim KOMIKN As Decimal '税込売上金額
	End Structure
	
	Private JDNTRKB_CHK() As TYPE_JDNTRKB_CHK
	
	
	
	'フォームロードイベント
	Private Sub FR_SSSMAIN_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		'WINDOW 位置設定
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		'ローカル変数初期化
		intUrigoukei = 0
		intBfkesiknkei = 0
		intMaxRow = 0
		intChkKb = 2
		
		blnFriEnabled = False
		blnUsableSpread = False
		blnUsableButton = False
		blnUsableEvent = True
		
		'★DBへの接続
		If CF_Ora_USR1_Open = False Then
			MsgBox("DBの接続に失敗しました。", MsgBoxStyle.Critical, "接続エラー")
		End If
		
		'PG初期化
		Call CF_Init()
		
		'画面初期化
		initForm()
		initCondition()
		initHead()
		initBody()
		
		
		intInputMode = 1
		
		'システム共通処理
		Call CF_System_Process(Me)
		
		
		'★ログの書き出し
		Call SSSWIN_LOGWRT("プログラム起動")
	End Sub
	
	'フォームアンロードイベント
	Private Sub FR_SSSMAIN_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		Dim Cancel As Boolean = eventArgs.Cancel
		Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		'●終了確認のMSG
		
		If ChkInputChange() = True Then
			If showMsg("0", "_ENDCK", CStr(0)) = MsgBoxResult.No Then
				Cancel = MsgBoxResult.Cancel
				Exit Sub
			End If
		Else
			If showMsg("0", "_ENDCM", CStr(0)) = MsgBoxResult.No Then
				Cancel = MsgBoxResult.Cancel
				Exit Sub
			End If
		End If
		
		
		'排他テーブル削除
		Call SSSEXC_EXCTBZ_CLOSE()
		
		' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
		Call SSSWIN_Unlock_EXCTBZ()
		' === 20130708 === INSERT E -
		
		'DBの接続を切断
		Call CF_Ora_DisConnect(gv_Oss_USR1, gv_Odb_USR1)
		
		Call CF_Ora_DisConnect(gv_Oss_USR_SAIBAN, gv_Oss_USR_SAIBAN)
		
		
		'★ログの書き出し
		Call SSSWIN_LOGWRT("プログラム終了")
		
		End '●PG終了
		eventArgs.Cancel = Cancel
	End Sub
	
	'フォームの初期化
	Private Sub initForm()
		Dim ssBevelNone As Object
		Dim i As Short
		'''' ADD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
		Dim strRet As String
		'''' ADD 2009/11/26  FKS) T.Yamamoto    End
		
		'フォームキャプションセット
		Me.Text = SSS_PrgNm
		
		'運用日の取得
		gstrUnydt.Value = getUnydt
		'前回経理締実行日の取得
		Call getSYSTBA()
		'''' UPD 2009/11/26  FKS) T.Yamamoto    Start    連絡票№702
		'    '権限の取得
		'    Call Get_Authority(gstrUnydt)
		'権限の取得
		strRet = Get_Authority(gstrUnydt.Value)
		If strRet = "9" Then
			'起動権限なしの場合、処理終了
			Call showMsg("2", "RUNAUTH", CStr(0))
			End
		End If
		'''' UPD 2009/11/26  FKS) T.Yamamoto    End
		
		'画面右上の項目に運用日をセット
		'UPGRADE_WARNING: オブジェクト pnl_unydt.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pnl_unydt.Caption = CNV_DATE(gstrUnydt.Value)
		
		'入力担当者をセット
		txt_opeid.Text = SSS_OPEID.Value
		txt_openm.Text = getTannm(SSS_OPEID.Value)
		
		txt_message.Text = ""
		
		'条件固定用パネルを隠す
		'UPGRADE_WARNING: オブジェクト pnl_condition1.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pnl_condition1.Caption = ""
		'UPGRADE_WARNING: オブジェクト pnl_condition1.BevelOuter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ssBevelNone の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pnl_condition1.BevelOuter = ssBevelNone
		'UPGRADE_WARNING: オブジェクト pnl_condition2.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pnl_condition2.Caption = ""
		'UPGRADE_WARNING: オブジェクト pnl_condition2.BevelOuter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ssBevelNone の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pnl_condition2.BevelOuter = ssBevelNone
		
		'表示限定テキストボックス設定用パネルを隠す
		'UPGRADE_WARNING: オブジェクト pnl_hihyoji.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pnl_hihyoji.Caption = ""
		'UPGRADE_WARNING: オブジェクト pnl_hihyoji.BevelOuter の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト ssBevelNone の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pnl_hihyoji.BevelOuter = ssBevelNone
		
		
		'ｽﾌﾟﾚｯﾄﾞ隠し項目を非表示にする
		If SHOW_HIDE_COLUMN_FLAG = False Then
			With spd_body
				'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Row = -1
				For i = COL_BFKESIKN To COL_HENPI
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = i
					'UPGRADE_WARNING: オブジェクト spd_body.ColHidden の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ColHidden = True
				Next i
			End With
		End If
		
		
	End Sub
	
	'入力条件の初期化
	Private Sub initCondition()
		
		Call initVal() 'ｸﾞﾛｰﾊﾞﾙ変数の初期化
		
		txt_kesidt.Text = CNV_DATE(gstrUnydt.Value) '運用日をセット
		txt_kesidt.ForeColor = System.Drawing.Color.Black
		txt_kesidt.BackColor = System.Drawing.Color.White
		
		txt_tokseicd.Text = Space(5) '5byte space
		txt_tokseicd.ForeColor = System.Drawing.Color.Black
		txt_tokseicd.BackColor = System.Drawing.Color.White
		
		txt_tokseinma.Text = ""
		
		txt_kaidt_From.Text = Space(10) '10byte space
		txt_kaidt_From.ForeColor = System.Drawing.Color.Black
		txt_kaidt_From.BackColor = System.Drawing.Color.White
		
		txt_kaidt_To.Text = CNV_DATE(gstrUnydt.Value) '運用日をセット
		txt_kaidt_To.ForeColor = System.Drawing.Color.Black
		txt_kaidt_To.BackColor = System.Drawing.Color.White
		
		
		
		'前受充当は初期値を「９」とする。
		'txt_kesikb.Text = 1
		txt_kesikb.Text = CStr(9)
		
		blnFriEnabled = False
		txt_fridt.Text = Space(10) '10byte space
		txt_fridt.ForeColor = System.Drawing.Color.Black
		txt_fridt.BackColor = System.Drawing.Color.White
		txt_fridt.Enabled = blnFriEnabled
		
		blnUsableButton = False
		blnUsableEvent = True
		
		'オプション項目の制御
		frm_opt1.Visible = OPTION_SHOW_FLAG
		opt_sort(0).Checked = True
		lbl_shakbnm(0).Visible = OPTION_SHOW_FLAG
		lbl_shakbnm(1).Visible = OPTION_SHOW_FLAG
		lbl_shakbnm(1).Text = ""
		lbl_hytokkesdd(0).Visible = OPTION_SHOW_FLAG
		lbl_hytokkesdd(1).Visible = OPTION_SHOW_FLAG
		lbl_hytokkesdd(1).Text = ""
		bar21.Visible = OPTION_SHOW_FLAG
		mnu_zenkesi.Visible = OPTION_SHOW_FLAG
		mnu_zenkaijo.Visible = OPTION_SHOW_FLAG
		mnu_zenkesi.Enabled = blnUsableButton
		mnu_zenkaijo.Enabled = blnUsableButton
	End Sub
	
	'ヘッダ部(消込情報)の初期化
	Private Sub initHead()
		txt_urigoukei.Text = CStr(0)
		txt_nyukin.Text = CStr(0)
		txt_tesuryo.Text = CStr(0)
		txt_syohi.Text = CStr(0)
		txt_nyugoukei.Text = CStr(0)
		txt_kesizan.Text = CStr(0)
		intUrigoukei = 0
		intBfkesiknkei = 0
	End Sub
	
	'明細部の初期化
	Private Sub initBody()
		Dim ActionSelectBlock As Object
		Dim ActionClearText As Object
		'処理中はｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄを実行させない
		blnUsableSpread = False
		
		With spd_body
			'UPGRADE_WARNING: オブジェクト spd_body.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = False
			
			'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col = -1
			'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row = -1
			'UPGRADE_WARNING: オブジェクト spd_body.Action の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト ActionClearText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Action = ActionClearText
			
			'カーソル位置を先頭に戻す
			'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Col = 1
			'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Row = 1
			'UPGRADE_WARNING: オブジェクト spd_body.Action の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト ActionSelectBlock の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Action = ActionSelectBlock
			
			'UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MaxRows = 9999
			'UPGRADE_WARNING: オブジェクト spd_body.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = True
		End With
		
		intMaxRow = 0
		
		'ｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄの許可
		blnUsableSpread = True
	End Sub
	
	'明細部の情報を表示
	Private Sub showBody()
		Dim strSql As Object
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim tmp As Object
		Dim intRet As Short
		Dim lw_sort As Short
		Dim bleNextFlg As Boolean
		Dim idxRow As Integer
		Dim strHyjdnno As String
		Dim strTEGDT As String
		
		' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の追加
		Dim rResult As Short ' 処理チェック関数戻り値
		Dim strUDNDT As String
		' === 20130708 === INSERT E
		
		' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
		Call SSSWIN_Unlock_EXCTBZ()
		' === 20130708 === INSERT E -
		
		'処理中はｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄを実行させない
		blnUsableSpread = False
		
		'排他用配列の初期化
		ReDim ARY_UDNTRA_HAITA(0)
		ReDim ARY_JDNTRA_HAITA(0)
		ReDim ARY_UDNTRA_NYU_HAITA(0)
		
		ReDim ARY_NYUKN_KS(0)
		
		ARY_NYUKN_KS_CNT = 0
		
		'マウスカーソルを砂時計にする
		Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
		
		'明細データ取得用SQLを作成
		Select Case True
			Case opt_sort(0).Checked
				lw_sort = 0
			Case opt_sort(1).Checked
				lw_sort = 1
			Case opt_sort(2).Checked
				lw_sort = 2
		End Select
		
		
		'明細部表示データ取得SQLを作成する
		'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = getSQLforBody(DB_SYSTBA.SMAUPDDT, gstrTokseicd.Value, gstrKaidt_Fr.Value, gstrKaidt_To.Value, (txt_kesikb.Text), lw_sort)
		'ﾃﾞｰﾀ取得
		'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'表示項目初期化
		initHead()
		initBody()
		
		
		'処理中はｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄを実行させない
		blnUsableSpread = False
		
		
		With spd_body
			'UPGRADE_WARNING: オブジェクト spd_body.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = False
			
			Do While CF_Ora_EOF(Usr_Ody) = False
				
				'貼り付けるデータが返品データの場合､黒データを検索
				bleNextFlg = True
				
				'返品の赤黒チェック
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If chkHenpin(Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "RECNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTDT", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTTM", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "URITK", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = False Then
					
					
					'データの表示を行わない
					bleNextFlg = False
				Else
					bleNextFlg = True
				End If
				
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")) = "" Then
					'返品後、受注訂正処理の赤黒チェック
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If chkHenpinTeisei(Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "LINNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTDT", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNWRTFSTTM", ""))) = False Then
						
						'データの表示を行わない
						bleNextFlg = False
					Else
						bleNextFlg = True
					End If
				End If
				
				
				''入力された消込日以降の売上データを出さない
				If bleNextFlg = False Then
					bleNextFlg = False
					
				Else
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Trim(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) > 0 Then
						
						'黒データで入力された消込日より後の売上は表示しない
						bleNextFlg = False
						
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ElseIf Trim(CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")) > DeCNV_DATE(Trim(txt_kesidt.Text)) And CDbl(Trim(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) < 0 Then 
						'返品の場合は、既に画面上に同じ受注番号が存在するかを確認する。
						With spd_body
							For idxRow = intMaxRow To 1 Step -1
								'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								Call .GetText(COL_HYJDNNO, idxRow, tmp)
								'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strHyjdnno = CStr(tmp)
								
								'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								If Trim(strHyjdnno) = Trim(CF_Ora_GetDyn(Usr_Ody, "HY_JDNNO", "")) Then
									'画面上に黒がいれば出力
									bleNextFlg = True
									Exit For
								Else
									bleNextFlg = False
								End If
							Next idxRow
						End With
					Else
						bleNextFlg = True
						
					End If
				End If
				
				
				
				'//表示判断チェック
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If chkHenpin2(Trim(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")), Trim(CF_Ora_GetDyn(Usr_Ody, "UDNDT", ""))) = False Then
					bleNextFlg = False
				End If
				
				
				If bleNextFlg = True Then
					
					intMaxRow = intMaxRow + 1
					
					'スプレッドに取得したデータを表示
					'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Row = intMaxRow
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_NO 'No.
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = intMaxRow
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_NXTKB '帳端
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "nxtkb", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_HYUDNDT '売上日
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "hy_udndt", "")
					' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の追加
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strUDNDT = .Text
					' === 20130708 === INSERT E -
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_HYJDNNO '受注番号
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "hy_jdnno", "")
					' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の追加
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If .Text <> "" Then
						'排他チェック
						'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						rResult = SSSWIN_EXCTBZ_CHECK2(VB.Left(.Text, 6))
						Select Case rResult
							'正常
							Case 0
								
								'排他処理中
							Case 1
								'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								MsgBox("他のプログラムで更新中のため、登録できません。" & vbCrLf & vbCrLf & "行No:" & vbTab & intMaxRow & vbCrLf & "売上日: " & vbTab & strUDNDT & vbCrLf & "受注番号: " & vbTab & .Text)
								Call SSSWIN_Unlock_EXCTBZ()
								initBody()
								GoTo STEP10_ShowBody
								
								'異常終了
							Case 9
								Call showMsg("2", "URKET73_034", CStr(0)) '更新異常
								Call SSSWIN_Unlock_EXCTBZ()
								initBody()
								GoTo STEP10_ShowBody
						End Select
					End If
					' === 20130708 === INSERT E -
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_HYKAIDT '回収予定日
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "hy_kaidt", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_TOKJDNNO '客先注文番号
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "tokjdnno", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_TANNM '営業担当者
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "tannm", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_URIKN '税抜売上金額
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "urikn", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_UZEKN '消費税額
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "uzekn", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_KOMIKN '税込売上金額
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "komikn", "")
					'合計金額を計算
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					intUrigoukei = intUrigoukei + SSSVal(.Text)
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_KESIKN '入金済額
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "kesikn", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_MINYUKN '未入金額(非表示)
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "kesikn", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_HYFRIDT '振込期日
					strTEGDT = Get_NKSTRA_TEGDT(CF_Ora_GetDyn(Usr_Ody, "datno", ""), CF_Ora_GetDyn(Usr_Ody, "linno", ""))
					If Trim(strTEGDT) <> "" Then
						'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Text = CNV_DATE(strTEGDT)
					Else
						'*** 2009/09/03 ADD START FKS)NAKATA V1.03
						'入金レコードより振込期日を取得する
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, jdnlinno, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						strTEGDT = Get_NYUKN_TEGDT(CF_Ora_GetDyn(Usr_Ody, "jdnno", ""), CF_Ora_GetDyn(Usr_Ody, "jdnlinno", ""))
						'*** 2009/09/03 ADD E.N.D FKS)NAKATA
						If Trim(strTEGDT) <> "" Then
							'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							.Text = CNV_DATE(strTEGDT)
						End If
					End If
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_BFHYFRIDT '振込期日(変更前)
					If Trim(strTEGDT) <> "" Then
						'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Text = CNV_DATE(strTEGDT)
						
						'*** 2009/09/03 DEL START FKS)NAKATA V1.03
						'        Else
						'            .Text = CNV_DATE(gstrFridt)                 'ﾍｯﾀﾞで指定した振込期日を初期表示
						'*** 2009/09/03 DEL START FKS)NAKATA V1.03
					End If
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_HYFRIDT '振込期日
					
					'ヘッダ部と同じく、明細部の入力も制限
					
					'UPGRADE_WARNING: オブジェクト spd_body.Lock の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Lock = Not blnFriEnabled
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_BFKESIKN '消込済額(締日前)
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "bfkesikn", "")
					'合計金額を計算
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					intBfkesiknkei = intBfkesiknkei + SSSVal(.Text)
					
					'●入金済額(KESIKN) - 消込済額(締日前) > 0 のときﾁｪｯｸﾎﾞｯｸｽにﾁｪｯｸを付ける
					'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.GetText(COL_KESIKN, .Row, tmp)
					
					'UPGRADE_WARNING: オブジェクト SSSVal(tmp) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If SSSVal(tmp) <> 0 Then
						
						'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Col = COL_CHK
						'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Value = 1
						
						'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Col = COL_BFCHECK
						'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Value = 1
						
					End If
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_AFKESIKN '消込済額(締日後)
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "afkesikn", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_JDNNO '受注番号(6桁)
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "jdnno", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_JDNLINNO '受注行番号
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "jdnlinno", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_UDNDT '売上日(スラッシュなし)
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "udndt", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_KESDT '回収予定日(スラッシュなし）
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "kesdt", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_TOKCD '得意先ｺｰﾄﾞ
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "tokcd", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_TOKSEICD '請求先ｺｰﾄﾞ
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "tokseicd", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_TANCD '担当者ｺｰﾄﾞ
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "tancd", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_JDNDT '受注日
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "jdndt", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_TUKKB '通貨区分
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "tukkb", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_INVNO 'ｲﾝﾎﾞｲｽ番号
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "invno", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_FURIKN '海外売上金額
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "furikn", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_FRNKB '海外取引区分
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "frnkb", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_UDNDATNO '売上DATNO
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "datno", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_UDNLINNO '売上行番号
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "linno", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_MAEUKKB '前受区分
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "maeukkb", "")
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_JDNDATNO '受注DATNO
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = CF_Ora_GetDyn(Usr_Ody, "jdndatno", "")
					
					
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_KESIKN_MAE '消込金額前
					'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, afkesikn, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = SSSVal(CF_Ora_GetDyn(Usr_Ody, "bfkesikn", "")) + SSSVal(CF_Ora_GetDyn(Usr_Ody, "afkesikn", ""))
					
					
					'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, kesikn, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, komikn, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If SSSVal(CF_Ora_GetDyn(Usr_Ody, "komikn", "")) - SSSVal(CF_Ora_GetDyn(Usr_Ody, "kesikn", "")) < 0 Then
						'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Col = COL_HENPI
						'UPGRADE_WARNING: オブジェクト spd_body.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Text = "1"
					End If
					
					
					'売上トランの排他情報取得
					ReDim Preserve ARY_UDNTRA_HAITA(intMaxRow)
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_UDNTRA_HAITA(intMaxRow).DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "DATNO", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_UDNTRA_HAITA(intMaxRow).LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "LINNO", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_UDNTRA_HAITA(intMaxRow).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNOPEID", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_UDNTRA_HAITA(intMaxRow).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNCLTID", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_UDNTRA_HAITA(intMaxRow).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNWRTDT", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_UDNTRA_HAITA(intMaxRow).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNWRTTM", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_UDNTRA_HAITA(intMaxRow).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUOPEID", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_UDNTRA_HAITA(intMaxRow).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUCLTID", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_UDNTRA_HAITA(intMaxRow).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUWRTDT", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_UDNTRA_HAITA(intMaxRow).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNUWRTTM", ""))
					
					'受注トランの排他情報取得
					ReDim Preserve ARY_JDNTRA_HAITA(intMaxRow)
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_JDNTRA_HAITA(intMaxRow).DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNDATNO", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_JDNTRA_HAITA(intMaxRow).JDNNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNNO", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_JDNTRA_HAITA(intMaxRow).LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_JDNTRA_HAITA(intMaxRow).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNOPEID", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_JDNTRA_HAITA(intMaxRow).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNCLTID", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_JDNTRA_HAITA(intMaxRow).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNWRTDT", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_JDNTRA_HAITA(intMaxRow).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNWRTTM", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_JDNTRA_HAITA(intMaxRow).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUOPEID", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_JDNTRA_HAITA(intMaxRow).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUCLTID", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_JDNTRA_HAITA(intMaxRow).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUWRTDT", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_JDNTRA_HAITA(intMaxRow).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "JDNUWRTTM", ""))
					
					
					'売上トラン入金レコードの排他情報取得
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call getUdntraNyukn(CStr(CF_Ora_GetDyn(Usr_Ody, "JDNNO", "")), CStr(CF_Ora_GetDyn(Usr_Ody, "JDNLINNO", "")))
					
				End If
				
				'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Usr_Ody.Obj_Ody.MoveNext()
			Loop 
			
		End With
		
		Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
		
		'消込対象がなければメッセージを表示
		If intMaxRow = 0 Then
			Call showMsg("2", "RNOTFOUND", "0") '●該当データなし
			txt_kesidt.Focus()
			
			'対象がある時
		Else
			
			'入金消込トランの排他情報取得
			Call Get_NKSTRA_HAITA_INF()
			
			'表示行数が16行以上のとき、ｽﾌﾟﾚｯﾄﾞ行数を設定
			If intMaxRow > 16 Then
				'UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				spd_body.MaxRows = intMaxRow
			Else
				'UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				spd_body.MaxRows = 16
			End If
			
			showHead() 'ﾍｯﾀﾞ部の表示
			
			'spd_body.SetFocus
			blnUsableButton = True '●ﾎﾞﾀﾝ使用の許可
			mnu_zenkesi.Enabled = blnUsableButton
			mnu_zenkaijo.Enabled = blnUsableButton
			'条件パネルのロック
			'UPGRADE_WARNING: オブジェクト pnl_condition1.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pnl_condition1.Enabled = False
			'UPGRADE_WARNING: オブジェクト pnl_condition2.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pnl_condition2.Enabled = False
			
			
			'*** 2009/09/16 ADD START FKS)NAKATA
			'返品金額の考慮
			getHenpinKingaku()
			'*** 2009/09/16 ADD E.N.D FKS)NAKATA
			
			
		End If
		' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の追加
STEP10_ShowBody: 
		' === 20130708 === INSERT E
		
		
		
		'UPGRADE_WARNING: オブジェクト spd_body.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		spd_body.ReDraw = True
		
		
		'ｽﾌﾟﾚｯﾄﾞｲﾍﾞﾝﾄの許可
		blnUsableSpread = True
		
		'マウスカーソルを標準に戻す
		'UPGRADE_ISSUE: vbNormal をアップグレードする定数を決定できません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B3B44E51-B5F1-4FD7-AA29-CAD31B71F487"' をクリックしてください。
		'UPGRADE_ISSUE: Form プロパティ FR_SSSMAIN.MousePointer はカスタム マウスポインタをサポートしません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="45116EAB-7060-405E-8ABE-9DBB40DC2E86"' をクリックしてください。
		Me.Cursor = vbNormal
	End Sub
	
	'ヘッダ部(消込情報)の表示
	Public Sub showHead()
		
		Dim intZankn As Decimal '消込日月度までの消込残額計
		Dim intKesikn As Decimal '経理締日以降の消込額
		Dim intTesuryo As Decimal '消込日月度の手数料額を格納
		Dim intSyohi As Decimal '消込日月度の消費税額を格納
		
		Dim tmp As Decimal
		Dim i As Short
		
		
		intZankn = 0
		intKesikn = 0
		intTesuryo = 0
		intSyohi = 0
		
		
		'排他情報と消込金額情報を取得
		Call getHaitaAndKnSum(DB_TOKMTA.TOKSEICD, Get_Acedt(gstrKesidt.Value), DB_TOKMTA.SHAKB)
		
		
		'消込日月度までの消込残額計
		For i = 0 To 9
			intZankn = intZankn + ARY_NKSSMB_KS(i).KSKZANKN
		Next i
		
		'経理締日以降の消込額
		For i = 0 To 9
			intKesikn = intKesikn + ARY_NKSSMB_KS(i).SSANYUKN - ARY_NKSSMB_KS(i).KSKNYKKN
		Next i
		
		'消込日月度の手数料・消費税額を格納
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		i = SSSVal(TesuryoID)
		intTesuryo = ARY_NKSSMB_KS(i).KSKZANKN + ARY_NKSSMB_KS(i).SSANYUKN - ARY_NKSSMB_KS(i).KSKNYKKN 'SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & TesuryoID, ""))
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		i = SSSVal(SyohiID)
		intSyohi = ARY_NKSSMB_KS(i).KSKZANKN + ARY_NKSSMB_KS(i).SSANYUKN - ARY_NKSSMB_KS(i).KSKNYKKN 'SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & TesuryoID, ""))
		
		
		'売上合計金額の表示
		txt_urigoukei.Text = VB6.Format(intUrigoukei, "###,###,##0")
		
		'入金額・手数料額・消費税額の表示
		tmp = intZankn + intKesikn
		If tmp - (intTesuryo + intSyohi) > 0 Then
			txt_nyukin.Text = VB6.Format(tmp - (intTesuryo + intSyohi), "#,###,##0")
			txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
			txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
			'残がプラスのとき
		ElseIf tmp > 0 Then 
			If intTesuryo > 0 Then
				If intSyohi > 0 Then
					'残額がプラスで、手数料も、消費税差額もプラスの時
					If tmp - intTesuryo > 0 Then
						txt_nyukin.Text = VB6.Format(0, "#,###,##0")
						txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
						txt_syohi.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
					Else
						txt_nyukin.Text = VB6.Format(0, "#,###,##0")
						txt_tesuryo.Text = VB6.Format(tmp, "#,###,##0")
						txt_syohi.Text = VB6.Format(0, "#,###,##0")
					End If
					
				ElseIf intSyohi <= 0 Then 
					'残額がプラスで、手数料がプラス、消費税差額がマイナスの時
					txt_nyukin.Text = VB6.Format(0, "#,###,##0")
					txt_tesuryo.Text = VB6.Format(tmp - intSyohi, "#,###,##0")
					txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
				End If
				
			ElseIf intTesuryo <= 0 Then 
				If intSyohi > 0 Then
					'残額がプラスで、手数量がマイナス、消費税差額がプラスの時
					txt_nyukin.Text = VB6.Format(0, "#,###,##0")
					txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
					txt_syohi.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
				ElseIf intSyohi <= 0 Then 
					'残額がプラスで、手数料も、消費税差額もマイナスの時
					'tmp - (intTesuryo + intSyohi) は絶対に正なので、ここに処理は不要
				End If
			End If
			
			'残が負の時
		ElseIf tmp <= 0 Then 
			If intTesuryo > 0 Then
				If intSyohi > 0 Then
					'残額がマイナスで、手数料も、消費税差額もプラスの時
					txt_nyukin.Text = VB6.Format(tmp, "#,###,##0")
					txt_tesuryo.Text = VB6.Format(0, "#,###,##0")
					txt_syohi.Text = VB6.Format(0, "#,###,##0")
				ElseIf intSyohi <= 0 Then 
					'残額がマイナスで、手数料がプラス、消費税差額がマイナスの時
					If tmp + intTesuryo + intSyohi > 0 Then
						txt_nyukin.Text = VB6.Format(0, "#,###,##0")
						txt_tesuryo.Text = VB6.Format(tmp - intSyohi, "#,###,##0")
						txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
					Else
						txt_nyukin.Text = VB6.Format(tmp - intSyohi, "#,###,##0")
						txt_tesuryo.Text = VB6.Format(0, "#,###,##0")
						txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
					End If
				End If
			ElseIf intTesuryo <= 0 Then 
				If intSyohi > 0 Then
					'残額がマイナスで、手数量がマイナス、消費税差額がプラスの時
					If tmp + intTesuryo + intSyohi > 0 Then
						txt_nyukin.Text = VB6.Format(0, "#,###,##0")
						txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
						txt_syohi.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
					Else
						txt_nyukin.Text = VB6.Format(tmp - intTesuryo, "#,###,##0")
						txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
						txt_syohi.Text = VB6.Format(0, "#,###,##0")
					End If
				ElseIf intSyohi <= 0 Then 
					'残額がマイナスで、手数料も、消費税差額もマイナスの時
					txt_nyukin.Text = VB6.Format(tmp - (intTesuryo + intSyohi), "#,###,##0")
					txt_tesuryo.Text = VB6.Format(intTesuryo, "#,###,##0")
					txt_syohi.Text = VB6.Format(intSyohi, "#,###,##0")
				End If
			End If
		End If
		
		'入金合計額の表示
		'UPGRADE_WARNING: オブジェクト SSSVal(txt_syohi.Text) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal(txt_tesuryo.Text) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		tmp = SSSVal((txt_nyukin.Text)) + SSSVal((txt_tesuryo.Text)) + SSSVal((txt_syohi.Text))
		txt_nyugoukei.Text = VB6.Format(tmp, "###,###,##0")
		
		'入金残額の表示
		txt_kesizan.Text = VB6.Format(intZankn + intKesikn, "###,###,##0")
		
	End Sub
	
	'明細部合計金額の取得
	Private Function getBodyKesikei(ByRef strColName As String) As Decimal
		Dim i As Short
		Dim intKesikei As Decimal
		Dim tmp As Object
		
		intKesikei = 0
		blnUsableSpread = False
		With spd_body
			For i = 1 To intMaxRow
				'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.GetText(strColName, i, tmp)
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				intKesikei = intKesikei + SSSVal(tmp)
			Next i
		End With
		blnUsableSpread = True
		
		getBodyKesikei = intKesikei
	End Function
	
	
	'排他情報と消込金額情報を取得、グローバル変数に格納
	Private Sub getHaitaAndKnSum(ByVal pin_strTOKCD As String, ByVal pin_strSMADT As String, ByVal pin_strSHAKB As String)
		Dim strSql As Object
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim i As Short
		
		'消込日月度の消込状態を取得
		
		'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = ""
		'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & " SELECT * "
		'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "   FROM NKSSMB "
		'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "  WHERE TOKCD = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
		'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "    AND SMADT = '" & CF_Ora_Sgl(DeCNV_DATE(pin_strSMADT)) & "' "
		
		'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'入金消込サマリーの排他情報取得
		ReDim ARY_NKSSMB_HAITA(1)
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ARY_NKSSMB_HAITA(1).TOKCD = CStr(CF_Ora_GetDyn(Usr_Ody, "TOKCD", ""))
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ARY_NKSSMB_HAITA(1).SMADT = CStr(CF_Ora_GetDyn(Usr_Ody, "SMADT", ""))
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ARY_NKSSMB_HAITA(1).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ARY_NKSSMB_HAITA(1).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ARY_NKSSMB_HAITA(1).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ARY_NKSSMB_HAITA(1).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))
		
		'入金消込サマリの情報を構造体配列へ取得
		ReDim ARY_NKSSMB_KS(9)
		For i = 0 To 9
			With ARY_NKSSMB_KS(i)
				.UPDID = VB6.Format(i, "00")
				
				If i <> 8 Then
					If CF_Ora_EOF(Usr_Ody) = False Then
						'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SSANYUKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN" & .UPDID, ""))
						'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.KSKNYKKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN" & .UPDID, ""))
						'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.KSKZANKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN" & .UPDID, ""))
					End If
				Else
					'09：本入金 は、相手にしない
					.SSANYUKN = 0
					.KSKNYKKN = 0
					.KSKZANKN = 0
				End If
				
				'取引区分の設定
				Select Case i
					Case 0 : .DATKB = "01" '01：現金
					Case 1 : .DATKB = "02" '02：振込
					Case 2 : .DATKB = "03" '03：手形
					Case 3 : .DATKB = "04" '04：相殺
					Case 4 : .DATKB = "05" '05：値引
					Case 5 : .DATKB = "06" '06：手数
					Case 6 : .DATKB = "07" '07：他
					Case 7 : .DATKB = "08" '08：振込仮
					Case 8 : .DATKB = "09" '09：本入金
					Case 9 : .DATKB = "99" '99：消費
				End Select
				
				
				'消込順序の設定（-1 は消込なし）
				' ①相殺→②消費税→③手数料→④現金→⑤振込→⑥手形→⑦振込仮→⑧値引き→⑨他
				Select Case i
					Case 0 : .SEQ = 4 '取引区分＝01：現金
					Case 1 : .SEQ = 5 '取引区分＝02：振込
					Case 2 : .SEQ = 6 '取引区分＝03：手形
					Case 3 : .SEQ = 1 '取引区分＝04：相殺
					Case 4 : .SEQ = 8 '取引区分＝05：値引
					Case 5 : .SEQ = 3 '取引区分＝06：手数
					Case 6 : .SEQ = 9 '取引区分＝07：他
					Case 7 : .SEQ = 7 '取引区分＝08：振込仮
					Case 8 : .SEQ = -1 '取引区分＝09：本入金
					Case 9 : .SEQ = 2 '取引区分＝99：消費
				End Select
				
			End With
		Next i
		
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		
		For i = 0 To 9
			'残金を計算する
			With ARY_NKSSMB_KS(i)
				.ZAN_KIN = .SSANYUKN - .KSKNYKKN + .KSKZANKN
			End With
		Next i
	End Sub
	
	
	'全解除メニュークリック時
	Public Sub mnu_zenkaijo_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_zenkaijo.Click
		cmd_zenkaijo_Click()
	End Sub
	
	'全選択メニュークリック時
	Public Sub mnu_zenkesi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_zenkesi.Click
		cmd_zenkesi_Click()
	End Sub
	
	Private Sub opt_sort_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles opt_sort.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		Dim Index As Short = opt_sort.GetIndex(eventSender)
		
		
		'ファンクションキー押下時
		If KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then
			'ファンクションキー共通処理
			Call CF_FuncKey_Execute(KeyCode, Shift)
		End If
		
		
	End Sub
	
	'ヘッダパネルマウスムーブ時
	Private Sub pnl_head_MouseMove(ByRef Button As Short, ByRef Shift As Short, ByRef X As Single, ByRef Y As Single)
		'ヒントの表示を初期化する
		img_light.Image = img_bklight(0).Image
		txt_message.Text = ""
	End Sub
	
	'アイコン[終了]クリック時
	Private Sub img_exit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles img_exit.Click
		Me.Close()
	End Sub
	'アイコン[終了]マウスダウン時
	Private Sub img_exit_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_exit.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_exit.Image = img_bkexit(1).Image
	End Sub
	'アイコン[終了]マウスムーブ時
	Private Sub img_exit_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_exit.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_light.Image = img_bklight(1).Image
		txt_message.Text = "メニューに戻ります。"
	End Sub
	'アイコン[終了]マウスアップ時
	Private Sub img_exit_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_exit.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_exit.Image = img_bkexit(0).Image
	End Sub
	
	'アイコン[登録]クリック時
	Private Sub img_resist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles img_resist.Click
		mnu_regist_Click(mnu_regist, New System.EventArgs())
	End Sub
	'アイコン[登録]マウスダウン時
	Private Sub img_resist_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_resist.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_resist.Image = img_bkresist(1).Image
	End Sub
	'アイコン[登録]マウスムーブ時
	Private Sub img_resist_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_resist.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_light.Image = img_bklight(1).Image
		txt_message.Text = "登録します。"
	End Sub
	'アイコン[登録]マウスアップ時
	Private Sub img_resist_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_resist.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_resist.Image = img_bkresist(0).Image
	End Sub
	
	'アイコン[検索]クリック時
	Private Sub img_showwnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles img_showwnd.Click
		mnu_showwnd_Click(mnu_showwnd, New System.EventArgs())
	End Sub
	'アイコン[検索]マウスダウン時
	Private Sub img_showwnd_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_showwnd.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_showwnd.Image = img_bkshowwnd(1).Image
	End Sub
	'アイコン[検索]マウスムーブ時
	Private Sub img_showwnd_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_showwnd.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_light.Image = img_bklight(1).Image
		txt_message.Text = "ウィンドウを表示します。"
	End Sub
	'アイコン[検索]マウスアップ時
	Private Sub img_showwnd_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_showwnd.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_showwnd.Image = img_bkshowwnd(0).Image
	End Sub
	
	'アイコン[解除]クリック時
	Private Sub img_unlock_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles img_unlock.Click
		
		If blnUsableButton = True Then
			blnUsableButton = False
			'UPGRADE_WARNING: オブジェクト pnl_condition1.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pnl_condition1.Enabled = True
			'UPGRADE_WARNING: オブジェクト pnl_condition2.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pnl_condition2.Enabled = True
			initHead()
			initBody()
			txt_kesidt.Focus()
			intInputMode = 1
			' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
			Call SSSWIN_Unlock_EXCTBZ()
			' === 20130708 === INSERT E -
		End If
		
	End Sub
	'アイコン[解除]マウスダウン時
	Private Sub img_unlock_MouseDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_unlock.MouseDown
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_unlock.Image = img_bkunlock(1).Image
	End Sub
	'アイコン[解除]マウスムーブ時
	Private Sub img_unlock_MouseMove(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_unlock.MouseMove
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_light.Image = img_bklight(1).Image
		txt_message.Text = "画面をクリアしてコードの入力を待ちます。"
	End Sub
	'アイコン[解除]マウスアップ時
	Private Sub img_unlock_MouseUp(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.MouseEventArgs) Handles img_unlock.MouseUp
		Dim Button As Short = eventArgs.Button \ &H100000
		Dim Shift As Short = System.Windows.Forms.Control.ModifierKeys \ &H10000
		Dim X As Single = VB6.PixelsToTwipsX(eventArgs.X)
		Dim Y As Single = VB6.PixelsToTwipsY(eventArgs.Y)
		img_unlock.Image = img_bkunlock(0).Image
	End Sub
	
	'メニュー[処理]－[終了]選択時
	Public Sub mnu_exit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_exit.Click
		Me.Close()
	End Sub
	
	'メニュー[処理]－[登録]選択時
	Public Sub mnu_regist_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_regist.Click
		
		Dim intRtn As Short
		
		
		'ヘッダ部の入力チェック
		If chkCondition = False Then Exit Sub
		'明細部の入力チェック
		If blnUsableButton = False Then
			showMsg("0", "_UPDATE", "2") '●明細部未入力のMSG
			Exit Sub
		End If
		
		
		'返品処理のなき分かれチェック
		If chkAkaKro = False Then
			Exit Sub
		End If
		
		'**** 2009/09/16 DEL START FKS)NAKATA
		'分納対応のためチェックを外す
		''    '売上金額と充当金額のチェック
		''    If chkUrikn = False Then
		''        Exit Sub
		''    End If
		''
		''
		''    '伝票単位での充当チェック
		''    If chkJdntrkb = False Then
		''        Exit Sub
		''    End If
		'**** 2009/09/16 DEL E.N.D FKS)NAKATA
		
		
		'入金が登録されているかのチェック
		If chkNyukn = False Then
			Exit Sub
		End If
		
		
		'手形が入っている場合は振込期日の入力チェック
		If chkFurikomiDT = False Then
			Exit Sub
		End If
		
		
		
		'●登録確認のMSG
		If showMsg("0", "_UPDATE", CStr(0)) = MsgBoxResult.Yes Then
			'★権限の判断
			If gs_UPDAUTH = "9" And AUTHORITY_ENABLE = True Then
				showMsg("2", "UPDAUTH", "0")
				Exit Sub
			End If
			
			'排他チェック
			If VB.Left(SSSEXC_EXCTBZ_CHECK, 1) = "9" Then
				MsgBox("【" & Trim(Mid(SSSEXC_EXCTBZ_CHECK, 2, 30)) & "】が起動中です。" & Trim(SSS_PrgNm) & "を入力する事はできません。", MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, SSS_PrgNm)
				'            Call HD_CLEAR
				'            Call P_vaData_Init
				Exit Sub
			Else
				Call SSSEXC_EXCTBZ_OPEN()
			End If
			
			
			Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
			
			'更新処理
			'UPGRADE_WARNING: mnu_regist_Click に変換されていないステートメントがあります。ソース コードを確認してください。
			
			Me.Cursor = System.Windows.Forms.Cursors.Default
			
			
		End If
		
	End Sub
	
	'メニュー[編集]－[画面初期化]選択時
	Public Sub mnu_initdsp_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_initdsp.Click
		
		intInputMode = 9
		'UPGRADE_WARNING: オブジェクト pnl_condition1.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pnl_condition1.Enabled = True
		'UPGRADE_WARNING: オブジェクト pnl_condition2.Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pnl_condition2.Enabled = True
		'画面の初期化
		initCondition()
		initHead()
		initBody()
		'消込日にフォーカスを移動
		txt_kesidt.Focus()
		txt_kesidt.BackColor = System.Drawing.Color.Yellow
		blnINIT_FLG = True
		' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
		Call SSSWIN_Unlock_EXCTBZ()
		' === 20130708 === INSERT E -
		
	End Sub
	
	
	'メニュー[操作]－[候補の一覧]
	Public Sub mnu_showwnd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnu_showwnd.Click
		'消込日にフォーカスがあるとき
		'UPGRADE_ISSUE: Control Name は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		If Me.ActiveControl.Name = txt_kesidt.Name Then
			cmd_kesidt_Click()
			
			'請求先ｺｰﾄﾞにフォーカスがあるとき
			'UPGRADE_ISSUE: Control Name は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		ElseIf Me.ActiveControl.Name = txt_tokseicd.Name Then 
			cmd_tokseicd_Click()
			
			
			'回収予定日にフォーカスがあるとき
			'UPGRADE_ISSUE: Control Name は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		ElseIf Me.ActiveControl.Name = txt_kaidt_From.Name Then 
			Call cmd_kaidt_From_Click()
			
			'回収予定日にフォーカスがあるとき
			'UPGRADE_ISSUE: Control Name は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		ElseIf Me.ActiveControl.Name = txt_kaidt_To.Name Then 
			Call cmd_kaidt_To_Click()
			
			
			'振込期日にフォーカスがあるとき
			'UPGRADE_ISSUE: Control Name は、汎用名前空間 ActiveControl 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
		ElseIf Me.ActiveControl.Name = txt_fridt.Name Then 
			cmd_fridt_Click()
		End If
	End Sub
	
	
	
	Private Sub spd_body_Change(ByVal Col As Integer, ByVal Row As Integer)
		Dim spd_fridt As String
		Dim spd_fridt_val As Object
		Dim ret As Boolean
		Dim lw_col As Integer
		Dim lw_row As Integer
		
		If Col = 14 Then '期日振込日のチェック
			
			lw_col = Col
			lw_row = Row
			'経理締日以前の日付の時はエラー
			'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			ret = spd_body.GetText(Col, Row, spd_fridt_val)
			If ret = True Then
				'UPGRADE_WARNING: オブジェクト spd_fridt_val の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				spd_fridt = VB6.Format(spd_fridt_val, "yyyy/mm/dd")
				If Trim(spd_fridt) = "" Then
					blnUsableButton = True
				End If
				If DeCNV_DATE(spd_fridt) <= DB_SYSTBA.SMAUPDDT Then
					Call showMsg("1", "URKET73_010", CStr(0)) '●経理締め済みのMSG
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					spd_body.Col = lw_col
					'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					spd_body.Row = lw_row
					'UPGRADE_WARNING: オブジェクト spd_body.ForeColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					spd_body.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
					'UPGRADE_WARNING: オブジェクト spd_body.Action の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					spd_body.Action = 0
					blnUsableButton = False
				Else
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					spd_body.Col = Col
					'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					spd_body.Row = Row
					'UPGRADE_WARNING: オブジェクト spd_body.ForeColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					spd_body.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
					'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					spd_body.Row = Row + 1
					'UPGRADE_WARNING: オブジェクト spd_body.Action の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					spd_body.Action = 0
					blnUsableButton = True
				End If
			End If
		End If
	End Sub
	
	Private Sub spd_body_KeyDown(ByRef KeyCode As Short, ByRef Shift As Short)
		
		
		'ファンクションキー押下時
		If KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then
			'ファンクションキー共通処理
			Call CF_FuncKey_Execute(KeyCode, Shift)
		End If
		
		
	End Sub
	
	Private Sub txt_fridt_Validating(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles txt_fridt.Validating
		Dim Cancel As Boolean = eventArgs.Cancel
		
		'入力チェック
		chkFridt()
		
		'背景色を白に戻す
		txt_fridt.BackColor = System.Drawing.Color.White
		
		eventArgs.Cancel = Cancel
	End Sub
	
	
	'請求先ｺｰﾄﾞ項目を変更した時
	'UPGRADE_WARNING: イベント txt_tokseicd.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub txt_tokseicd_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_tokseicd.TextChanged
		Dim p As Short
		
		'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
		If blnUsableEvent = False Then Exit Sub
		
		blnUsableEvent = False
		p = txt_tokseicd.SelectionStart
		
		'全角を削除する
		txt_tokseicd.Text = delZenkaku((txt_tokseicd.Text))
		'入力値が5byteで無い時は空白埋め
		txt_tokseicd.Text = txt_tokseicd.Text & Space(5 - Len(txt_tokseicd.Text))
		
		txt_tokseicd.SelectionStart = p
		blnUsableEvent = True
		
		'カーソルが右端に移動した時は、次の項目へ移動
		If txt_tokseicd.SelectionStart = 5 Then
			intChkKb = 1 '★請求先ｺｰﾄﾞの入力チェック
			
			'入力チェック
			If chkTokseicd = True Then
				'次項目
				txt_kaidt_From.Focus()
			End If
			
		End If
		txt_tokseicd.SelectionLength = 1
		
	End Sub
	
	'請求先ｺｰﾄﾞ項目にフォーカスが移った時
	Private Sub txt_tokseicd_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_tokseicd.Enter
		'先頭位置を選択状態にする
		txt_tokseicd.SelectionStart = 0
		txt_tokseicd.SelectionLength = 1
		'背景色を黄色にする
		txt_tokseicd.BackColor = System.Drawing.Color.Yellow
		'検索処理を実行可能とする
		mnu_showwnd.Enabled = True
	End Sub
	
	
	'請求先ｺｰﾄﾞ項目でキーを押した時
	Private Sub txt_tokseicd_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_tokseicd.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		'キー入力制御
		Select Case Ctl_tokseicd_KeyDown(KeyCode, Shift, txt_tokseicd)
			Case 0
				'何もしない
			Case 1
				'入力チェック
				If chkTokseicd = True Then
					'次項目
					txt_kaidt_From.Focus()
				End If
			Case 2
				'入力チェック
				If chkTokseicd = True Then
					'前項目
					txt_kesidt.Focus()
				End If
		End Select
		
		KeyCode = 0
		
	End Sub
	
	
	'請求先ｺｰﾄﾞ項目でキーを押した時
	Private Sub txt_tokseicd_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_tokseicd.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'アルファベット小文字を大文字に変換する
		If Chr(KeyAscii) Like "[a-z]" Then
			KeyAscii = KeyAscii - 32
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'請求先ｺｰﾄﾞ項目からフォーカスが移った時
	Private Sub txt_tokseicd_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_tokseicd.Leave
		
		'背景色を白に戻す
		txt_tokseicd.BackColor = System.Drawing.Color.White
		
	End Sub
	
	
	'消込済みﾃﾞｰﾀ表示項目を変更した時
	'UPGRADE_WARNING: イベント txt_kesikb.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub txt_kesikb_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesikb.TextChanged
		If CDbl(txt_kesikb.Text) <> 9 Then
			txt_kesikb.Text = CStr(1)
		End If
		txt_kesikb.SelectionStart = 0
		txt_kesikb.SelectionLength = 1
		
		If CDbl(txt_kesikb.Text) = 1 Then
			'UPGRADE_WARNING: オブジェクト cmd_kaidt_From.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			cmd_kaidt_From.Caption = " 売上日(開始)"
		Else
			'UPGRADE_WARNING: オブジェクト cmd_kaidt_From.Caption の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			cmd_kaidt_From.Caption = " *売上日(開始)"
		End If
		
	End Sub
	
	'消込済みﾃﾞｰﾀ表示項目にフォーカスが移った時
	Private Sub txt_kesikb_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesikb.Enter
		'選択状態にする
		txt_kesikb.SelectionStart = 0
		txt_kesikb.SelectionLength = 1
		'背景色を黄色にする
		txt_kesikb.BackColor = System.Drawing.Color.Yellow
		'検索処理を実行不可とする
		mnu_showwnd.Enabled = False
	End Sub
	
	'消込済みﾃﾞｰﾀ表示項目でキーを押した時
	Private Sub txt_kesikb_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kesikb.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		'ファンクションキー押下時
		If KeyCode >= System.Windows.Forms.Keys.F1 And KeyCode <= System.Windows.Forms.Keys.F12 Then
			'ファンクションキー共通処理
			Call CF_FuncKey_Execute(KeyCode, Shift)
		End If
		
		
		'上矢印 or 左矢印押下時
		If KeyCode = System.Windows.Forms.Keys.Up Or KeyCode = System.Windows.Forms.Keys.Left Then
			txt_kaidt_To.Focus()
			
			'Enter or 下矢印 or 右矢印押下時
		ElseIf KeyCode = System.Windows.Forms.Keys.Return Or KeyCode = System.Windows.Forms.Keys.Down Or KeyCode = System.Windows.Forms.Keys.Right Then 
			'請求先の支払条件が振込期日、ﾌｧｸﾀﾘﾝｸﾞの時は振込期日に項目移動
			'それ以外は消込対象を検索
			If blnFriEnabled = True Then
				txt_fridt.Focus()
			Else
				'UPGRADE_WARNING: オブジェクト spd_body.SetFocus の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				spd_body.SetFocus()
			End If
			
			'TAB押
		ElseIf KeyCode = System.Windows.Forms.Keys.F16 Then 
			'請求先の支払条件が振込期日、ﾌｧｸﾀﾘﾝｸﾞの時は振込期日に項目移動
			'それ以外は消込対象を検索
			If blnFriEnabled = True Then
				txt_fridt.Focus()
			Else
				'UPGRADE_WARNING: オブジェクト spd_body.SetFocus の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				spd_body.SetFocus()
			End If
			
			
			
			'TAB押
		ElseIf KeyCode = System.Windows.Forms.Keys.F15 Then 
			txt_kaidt_To.Focus()
			
			
		End If
		
		KeyCode = 0
	End Sub
	
	'消込済みﾃﾞｰﾀ表示項目でキーを押した時
	Private Sub txt_kesikb_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kesikb.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		'数値のみ入力可とする
		If Not Chr(KeyAscii) Like "[0-9]" Then
			KeyAscii = 0
		End If
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'消込済みﾃﾞｰﾀ表示項目からフォーカスが移った時
	Private Sub txt_kesikb_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesikb.Leave
		'背景色を白に戻す
		txt_kesikb.BackColor = System.Drawing.Color.White
	End Sub
	
	'=======================================================明細部(スプレッド)=======================================================
	
	'フォーカス取得時
	Private Sub spd_body_GotFocus()
		
		If intInputMode <> 1 Then
			Exit Sub
		End If
		
		'ﾎﾞﾀﾝが使用可能(明細ﾃﾞｰﾀあり)の時は実行しない
		If blnUsableButton = True Then Exit Sub
		
		'ヘッダが入力されていたらデータを検索・表示する
		If chkCondition = True Then
			
			intInputMode = 2
			
			showBody() '★ﾃﾞｰﾀ表示
			
			'返品を消込し、ロック
			'前受では、自動チェック機能を使用しない。(有効にする場合はコメントを外してください)
			'lockHenpin
			
		End If
	End Sub
	
	'明細ﾎﾞﾀﾝｸﾘｯｸ時
	Private Sub spd_body_ButtonClicked(ByVal Col As Integer, ByVal Row As Integer, ByVal ButtonDown As Short)
		
		Dim intKesizan As Decimal 'ヘッダ部消込残額
		Dim intKomikn As Decimal '税込売上額
		Dim intKesikn As Decimal '消込額
		Dim intBfKesikn As Decimal '消込額(締日前)
		Dim tmp As Object
		
		Dim LS_HYFRIDT As Object
		Dim sumHenpin As Decimal
		Dim intJDNNOKesikn As Decimal
		Dim intHenkn As Decimal
		Dim strHyjdnno As String
		Dim str_theHYJDNNO As String
		Dim intchk As Short
		Dim idxRowJDNNO As Integer
		
		'*** 2009/09/03 ADD START FKS)NAKATA V1.03
		Dim strBfHYFRIDT As String
		'*** 2009/09/03 ADD E.N.D FKS)NAKATA
		
		
		
		'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
		If blnUsableSpread = False Then
			Exit Sub
		End If
		
		
		On Error Resume Next
		
		With spd_body
			'ﾁｪｯｸﾎﾞｯｸｽｸﾘｯｸ時、明細の金額、ヘッダの残金額に応じてチェックのON、OFFを行う
			If Col = 1 Then
				'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Col = Col
				'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Row = Row
				
				'表示行以上の行をクリックした時はチェックはつけない
				If Row > intMaxRow Then
					'ﾁｪｯｸ解除しない
					blnUsableSpread = False
					'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Value = 0
					blnUsableSpread = True
					Exit Sub
				End If
				
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				intKesizan = SSSVal((txt_kesizan.Text))
				
				'税込売上額を取得
				'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(COL_KOMIKN, .Row, tmp)
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				intKomikn = SSSVal(tmp)
				
				'明細部消込額
				'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(COL_KESIKN, .Row, tmp)
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				intKesikn = SSSVal(tmp)
				
				'ﾁｪｯｸが付いていて、解除した時
				If ButtonDown = 0 Then
					
					'解除額がプラスであれば、無条件にヘッダ部に加算
					If intKesikn - intBfKesikn > 0 Then
						txt_kesizan.Text = VB6.Format(intKesizan + (intKesikn - intBfKesikn), "###,###,##0")
						'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SetText(COL_KESIKN, .Row, intBfKesikn)
						
						
						If DB_TOKMTA.SHAKB Like "[256]" Then
							'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
							'UPGRADE_WARNING: オブジェクト LS_HYFRIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Trim(LS_HYFRIDT) <> "" Then
								'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								.SetText(COL_HYFRIDT, .Row, "")
							End If
						End If
						
						
					ElseIf intKesizan >= intBfKesikn - intKesikn Then 
						txt_kesizan.Text = VB6.Format(intKesizan + (intKesikn - intBfKesikn), "###,###,##0")
						'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SetText(COL_KESIKN, .Row, intBfKesikn)
						
						
						If DB_TOKMTA.SHAKB Like "[256]" Then
							'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
							'UPGRADE_WARNING: オブジェクト LS_HYFRIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Trim(LS_HYFRIDT) <> "" Then
								'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								.SetText(COL_HYFRIDT, .Row, "")
							End If
						End If
						
					Else
						'ﾁｪｯｸ解除しない
						blnUsableSpread = False
						'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Value = 1
						blnUsableSpread = True
					End If
					
					
					'ﾁｪｯｸが付いていなくて、チェックを入れた時
				ElseIf ButtonDown = 1 Then 
					
					'消込額がマイナスであれば､無条件にヘッダ部に加算
					If intKomikn - intKesikn < 0 Then
						txt_kesizan.Text = VB6.Format(intKesizan - (intKomikn - intKesikn), "###,###,##0")
						'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SetText(COL_KESIKN, .Row, intKomikn)
						
						If DB_TOKMTA.SHAKB Like "[256]" Then
							'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
							
							'UPGRADE_WARNING: オブジェクト LS_HYFRIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Trim(LS_HYFRIDT) = "" Then
								'*** 2009/09/03 CHG START FKS)NAKATA V1.03
								'.SetText COL_HYFRIDT, .Row, txt_fridt.Text
								'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								Call .GetText(COL_BFHYFRIDT, .Row, tmp)
								'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strBfHYFRIDT = tmp
								'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								.SetText(COL_HYFRIDT, .Row, strBfHYFRIDT)
								'*** 2009/09/03 CHG START FKS)NAKATA
							End If
						End If
						'ヘッダ消込残が負の時はチェックをつけない
					ElseIf intKesizan <= 0 Then 
						
						
						blnUsableSpread = False
						'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Value = 0
						blnUsableSpread = True
						
					ElseIf intKesizan >= intKomikn - intKesikn Then 
						txt_kesizan.Text = VB6.Format(intKesizan - (intKomikn - intKesikn), "###,###,##0")
						'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SetText(COL_KESIKN, .Row, intKomikn)
						
						If DB_TOKMTA.SHAKB Like "[256]" Then
							'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							.GetText(COL_HYFRIDT, .Row, LS_HYFRIDT)
							'UPGRADE_WARNING: オブジェクト LS_HYFRIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Trim(LS_HYFRIDT) = "" Then
								'*** 2009/09/03 CHG START FKS)NAKATA V1.03
								'.SetText COL_HYFRIDT, .Row, txt_fridt.Text
								'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								Call .GetText(COL_BFHYFRIDT, .Row, tmp)
								'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								strBfHYFRIDT = tmp
								'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								.SetText(COL_HYFRIDT, .Row, strBfHYFRIDT)
								'*** 2009/09/03 CHG START FKS)NAKATA
							End If
						End If
					Else
						
						'一部充当の禁止 (税込売上金額 <> 充当金額の場合)
						Call showMsg("1", "URKET73_041", CStr(0)) '一部充当はできません。
						blnUsableSpread = False
						'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Value = 0
						blnUsableSpread = True
						
						''一部充当を許す場合は、以下のコメントを外す
						''DEL START (↓)
						'                        txt_kesizan.Text = Format(0, "###,###,##0")
						''                        .SetText COL_KESIKN, .Row, intKesikn + intKesizan
						''
						''                        If DB_TOKMTA.SHAKB Like "[256]" Then
						''                            .GetText COL_HYFRIDT, .Row, LS_HYFRIDT
						''                            If Trim$(LS_HYFRIDT) = "" Then
						''                                .SetText COL_HYFRIDT, .Row, txt_fridt.Text
						''                            End If
						''                        End If
						''DEL START (↑)
						
					End If
				End If
			End If
		End With
	End Sub
	
	'================================================================
	'2009/06/12 DEL START FKS)NAKATA
	
	'手数用・消費税額の登録は、本処理では行わない。
	'本処理を使用する場合は、コメントアウトを外し
	'「pnl_tesuryo」「pnl_syohizei」をフォームから削除してください。
	'パネルの下にボタンを隠しています。
	
	
	''手数料ﾎﾞﾀﾝ実行時
	'Private Sub cmd_tesuryo_Click()
	'
	'    Dim tmp             As Variant
	'    Dim intchk          As Long
	'    Dim idxRow          As Long
	'    Dim idxRowJDNNO     As Long
	'
	'    Dim kesizan         As Currency 'ヘッダ部消込残額
	'    Dim kesikn          As Currency '明細行の入金済額
	'
	'
	'    'ﾌﾗｸﾞがたっていなければ実行しない
	'    If blnUsableButton = False Then Exit Sub
	'
	'    '●差額入金画面の表示
	''    FR_SSSSUB.Show (vbModal)
	'
	'
	'    'ヘッダ情報の再表示
	'    showHead
	
	'    'ヘッダ部消込残額の退避
	'    kesizan = txt_kesizan.Text
	'
	'    With spd_body
	'        For idxRow = 1 To intMaxRow
	'            'チェックが入っているかを確認
	'            .GetText COL_CHK, idxRow, tmp
	'            intchk = SSSVal(tmp)
	'
	'            'チェックが入っている場合
	'            If intchk = 1 Then
	'                '消込額の取得
	'                Call .GetText(COL_KESIKN, idxRow, tmp)
	'                kesikn = kesikn + CCur(tmp)
	'            End If
	'
	'       Next idxRow
	'    End With
	'
	'    txt_kesizan.Text = Format(kesizan - kesikn, "###,###,##0")
	'
	'End Sub
	'
	''消費税額ﾎﾞﾀﾝ実行時
	'Private Sub cmd_syohi_Click()
	'
	'
	'    Dim tmp             As Variant
	'    Dim intchk          As Long
	'    Dim idxRow          As Long
	'    Dim idxRowJDNNO     As Long
	'
	'    Dim kesizan         As Currency 'ヘッダ部消込残額
	'    Dim kesikn          As Currency '明細行の入金済額
	'
	'
	'    'ﾌﾗｸﾞがたっていなければ実行しない
	'    If blnUsableButton = False Then Exit Sub
	'
	'    '●差額入金画面の表示
	'    FR_SSSSUB.Show (vbModal)
	'
	'
	'    'ヘッダ情報の再表示
	'    showHead
	'
	'    'ヘッダ部消込残額の退避
	'    kesizan = txt_kesizan.Text
	'
	'    With spd_body
	'        For idxRow = 1 To intMaxRow
	'            'チェックが入っているかを確認
	'            .GetText COL_CHK, idxRow, tmp
	'            intchk = SSSVal(tmp)
	'
	'            'チェックが入っている場合
	'            If intchk = 1 Then
	'                '消込額の取得
	'                Call .GetText(COL_KESIKN, idxRow, tmp)
	'                kesikn = kesikn + CCur(tmp)
	'            End If
	'
	'       Next idxRow
	'    End With
	'
	'    txt_kesizan.Text = Format(kesizan - kesikn, "###,###,##0")
	'
	'
	'End Sub
	'2009/06/12 DEL E.N.D FKS)NAKATA
	'================================================================
	
	
	'全消込ﾎﾞﾀﾝ実行時
	Private Sub cmd_zenkesi_Click()
		Dim i As Short
		Dim varKesikn As Object
		
		'ﾌﾗｸﾞがたっていなければ実行しない
		If blnUsableButton = False Then Exit Sub
		
		
		'全消込ボタンを押下時は、初期表示時と同じ消込対象にチェックを入れる。
		'前受では、自動チェック機能を使用しない。(有効にする場合はコメントを外してください)
		'    lockHenpin
		
		
		'全行に対し、ﾁｪｯｸﾎﾞｯｸｽのﾁｪｯｸ
		For i = 1 To intMaxRow
			With spd_body
				'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Col = COL_CHK
				'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Row = i
				'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If .Value = 0 Then
					'全消込時にチェックが入らない不具合を修正 2007/02/28 Saito
					spd_body_ButtonClicked(COL_CHK, i, 1)
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.GetText(COL_KESIKN, i, varKesikn)
					'UPGRADE_WARNING: オブジェクト SSSVal(varKesikn) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If SSSVal(varKesikn) <> 0 Then
						blnUsableSpread = False
						'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Value = 1
						blnUsableSpread = True
					End If
				End If
			End With
		Next i
		
	End Sub
	
	'全解除ﾎﾞﾀﾝ実行時
	Private Sub cmd_zenkaijo_Click()
		Dim i As Short
		Dim varKesikn As Object
		Dim varBfKesikn As Object
		
		'ﾌﾗｸﾞがたっていなければ実行しない
		If blnUsableButton = False Then Exit Sub
		
		'全行に対し、ﾁｪｯｸﾎﾞｯｸｽの解除
		For i = 1 To intMaxRow
			With spd_body
				'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Col = COL_CHK
				'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Row = i
				'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If .Value = 1 Then
					'解除時にチェックが外れない不具合を修正 2007/02/28 Saito
					spd_body_ButtonClicked(COL_CHK, i, 0)
					
					
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.GetText(COL_KESIKN, i, varKesikn)
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.GetText(COL_BFKESIKN, i, varBfKesikn)
					
					'UPGRADE_WARNING: オブジェクト SSSVal(varKesikn) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If SSSVal(varKesikn) = 0 Then
						
						blnUsableSpread = False
						'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Value = 0
						blnUsableSpread = True
					End If
					
				End If
			End With
		Next i
	End Sub
	
	'再表示ﾎﾞﾀﾝ実行時
	Private Sub cmd_saihyoji_Click()
		'ﾌﾗｸﾞがたっていなければ実行しない
		If blnUsableButton = False Then Exit Sub
		
		
		If ChkInputChange() = True Then
			If showMsg("1", "URKET73_040", CStr(0)) = MsgBoxResult.No Then
				Exit Sub
			End If
		End If
		
		
		'ヘッダが入力されていたらデータを検索・表示する
		If chkCondition = True Then
			
			intInputMode = 2
			
			showBody() '★ﾃﾞｰﾀ表示
			
			'前受では、自動チェック機能を使用しない。(有効にする場合はコメントを外してください)
			'返品を消込し、ロック
			'lockHenpin
			
		End If
		
	End Sub
	
	'消込日ﾎﾞﾀﾝｸﾘｯｸ時
	Private Sub cmd_kesidt_Click()
		If txt_kesidt.Enabled = False Then Exit Sub
		
		If Trim(txt_kesidt.Text) <> "" Then
			Set_date.Value = txt_kesidt.Text
		Else
			Set_date.Value = CNV_DATE(gstrUnydt.Value)
		End If
		
		WLSDATE_RTNCODE = ""
		
		'カレンダーウィンドウを表示
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		
		txt_kesidt.Focus()
		If WLSDATE_RTNCODE <> "" Then
			txt_kesidt.Text = WLSDATE_RTNCODE
			intChkKb = 1 '★日付の入力チェック
			txt_tokseicd.Focus()
		End If
	End Sub
	
	'請求先ｺｰﾄﾞﾎﾞﾀﾝｸﾘｯｸ時
	Private Sub cmd_tokseicd_Click()
		If txt_tokseicd.Enabled = False Then Exit Sub
		WLS_TOK1.ShowDialog()
		WLS_TOK1.Close()
		
		txt_tokseicd.Focus()
		If WLSTOKSUB_RTNCODE <> "" Then
			txt_tokseicd.Text = WLSTOKSUB_RTNCODE
			intChkKb = 1
			chkTokseicd()
			txt_kaidt_From.Focus()
			
		End If
	End Sub
	
	'回収日ﾎﾞﾀﾝｸﾘｯｸ時
	Private Sub cmd_kaidt_From_Click()
		
		If txt_kaidt_From.Enabled = False Then Exit Sub
		
		If Trim(txt_kaidt_From.Text) <> "" Then
			Set_date.Value = txt_kaidt_From.Text
		Else
			Set_date.Value = CNV_DATE(gstrUnydt.Value)
		End If
		
		WLSDATE_RTNCODE = ""
		
		'カレンダーウィンドウを表示
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		
		txt_kaidt_From.Focus()
		If WLSDATE_RTNCODE <> "" Then
			txt_kaidt_From.Text = WLSDATE_RTNCODE
			intChkKb = 1 '★日付の入力チェック
			txt_kaidt_To.Focus()
		End If
		
	End Sub
	
	
	'回収日ﾎﾞﾀﾝｸﾘｯｸ時
	Private Sub cmd_kaidt_To_Click()
		If txt_kaidt_To.Enabled = False Then Exit Sub
		
		If Trim(txt_kaidt_To.Text) <> "" Then
			Set_date.Value = txt_kaidt_To.Text
		Else
			Set_date.Value = CNV_DATE(gstrUnydt.Value)
		End If
		
		WLSDATE_RTNCODE = ""
		
		'カレンダーウィンドウを表示
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		
		txt_kaidt_To.Focus()
		If WLSDATE_RTNCODE <> "" Then
			txt_kaidt_To.Text = WLSDATE_RTNCODE
			intChkKb = 1 '★日付の入力チェック
			txt_kesikb.Focus()
		End If
	End Sub
	
	
	'振込期日ﾎﾞﾀﾝｸﾘｯｸ時
	Private Sub cmd_fridt_Click()
		'振込期日が入力できない時はｲﾍﾞﾝﾄは実行しない
		If blnFriEnabled = False Then Exit Sub
		If txt_fridt.Enabled = False Then Exit Sub
		
		If Trim(txt_fridt.Text) <> "" Then
			If IsDate(txt_fridt.Text) = True Then
				Set_date.Value = txt_fridt.Text
			Else
				Set_date.Value = CNV_DATE(gstrUnydt.Value)
				txt_fridt.Text = ""
			End If
		Else
			Set_date.Value = CNV_DATE(gstrUnydt.Value)
		End If
		
		WLSDATE_RTNCODE = ""
		
		'カレンダーウィンドウを表示
		WLS_DATE.ShowDialog()
		WLS_DATE.Close()
		
		txt_fridt.Focus()
		If WLSDATE_RTNCODE <> "" Then
			txt_fridt.Text = WLSDATE_RTNCODE
			intChkKb = 1 '★日付の入力チェック
			'UPGRADE_WARNING: オブジェクト spd_body.SetFocus の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			spd_body.SetFocus()
		End If
	End Sub
	
	'**** 2009/09/19 ADD START FKS)NAKATA
	'分納対応
	Private Sub getHenpinKingaku()
		
		
		Dim idxRow As Integer
		Dim tmp As Object
		
		
		Dim i As Integer
		Dim strHenpin As String
		Dim strJdnno As String
		Dim strJdnlinno As String
		Dim strOkrjono As String
		Dim curKomikn As Decimal
		Dim maxSeq As Short
		
		On Error Resume Next
		
		With spd_body
			
			For idxRow = 1 To intMaxRow
				
				strHenpin = ""
				
				'返品フラグの取得
				'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(COL_HENPI, idxRow, tmp)
				'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strHenpin = CStr(tmp)
				
				
				'返品であれば、金額調整を行う
				If strHenpin = "1" Then
					
					'受注番号の取得
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .GetText(COL_JDNNO, idxRow, tmp)
					'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strJdnno = CStr(tmp)
					
					'受注行番号の取得
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .GetText(COL_JDNLINNO, idxRow, tmp)
					'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strJdnlinno = CStr(tmp)
					
					'税込売上金額の取得
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .GetText(COL_KOMIKN, idxRow, tmp)
					'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					curKomikn = CDec(tmp)
					
					'送り状№の取得
					strOkrjono = getOKRJONO(strJdnno, strJdnlinno)
					
					
					For i = 0 To UBound(ARY_NYUKN_KS)
						
						'受注番号
						If ARY_NYUKN_KS(i).OKRJONO = strOkrjono Then
							maxSeq = i
						End If
						
					Next i
					
					'返品の金額を残金へ加算する
					ARY_NYUKN_KS(maxSeq).ZANKN = ARY_NYUKN_KS(maxSeq).ZANKN + curKomikn * (-1)
					
				End If
				
			Next idxRow
			
		End With
		
	End Sub
	'**** 2009/09/19 ADD E.N.D FKS)NAKATA
	
	
	'返品消込
	Private Sub lockHenpin()
		Dim intKesizan As Decimal 'ヘッダ部消込残額
		Dim intKomikn As Decimal '税込売上額
		Dim intKesikn As Decimal '消込額
		Dim intBfKesikn As Decimal '消込額(締日前)
		Dim tmp As Object
		Dim LS_HYFRIDT As Object
		Dim idxRow As Integer
		Dim idxRowJDNNO As Integer
		Dim strFRIDT As String
		Dim strHyjdnno As String
		Dim str_theHYJDNNO As String
		Dim intchk As Short
		
		On Error Resume Next
		'振込期日を取得
		
		strFRIDT = txt_fridt.Text
		'消込残額を取得
		
		'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		intKesizan = SSSVal((txt_kesizan.Text))
		'返品を検索
		
		With spd_body
			
			For idxRow = 1 To intMaxRow
				'税込売上額を取得
				
				'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(COL_KOMIKN, idxRow, tmp)
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				intKomikn = SSSVal(tmp)
				'入金済額を取得
				
				'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(COL_KESIKN, idxRow, tmp)
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				intKesikn = SSSVal(tmp)
				'締日以前消込額
				
				
				'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				intBfKesikn = SSSVal(tmp)
				
				
				'消込額がマイナスであれば同一受注番号で相殺
				If intKomikn - intKesikn < 0 Then
					
					'消込額を消込残額へ追加
					intKesizan = intKesizan - (intKomikn - intKesikn)
					
					'入金済額設定
					'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.SetText(COL_KESIKN, idxRow, intKomikn)
					
					'チェックボックス設定
					blnUsableSpread = False
					'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Row = idxRow
					'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Col = COL_CHK
					'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Value = 1
					blnUsableSpread = True
					
					
					'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .SetText(COL_HENPI, idxRow, "1")
					
					
					'受注番号取得
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .GetText(COL_HYJDNNO, idxRow, tmp)
					'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strHyjdnno = CStr(tmp)
					
					'同一受注番号を検索
					For idxRowJDNNO = intMaxRow To 1 Step -1
						'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.GetText(COL_HYJDNNO, idxRowJDNNO, tmp)
						'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						str_theHYJDNNO = CStr(tmp)
						
						'受注番号一致すれば相殺
						If strHyjdnno <> str_theHYJDNNO Then
						Else
							'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							.GetText(COL_CHK, idxRowJDNNO, tmp)
							'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							intchk = SSSVal(tmp)
							
							'自分自身でない、またはチェックされていない
							If idxRowJDNNO <> idxRow And intchk = 1 Then
							Else
								
								'税込売上額を取得
								'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								Call .GetText(COL_KOMIKN, idxRowJDNNO, tmp)
								'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								intKomikn = SSSVal(tmp)
								
								'入金済額を取得
								'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								Call .GetText(COL_KESIKN, idxRowJDNNO, tmp)
								'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								intKesikn = SSSVal(tmp)
								
								'締日以前消込額
								
								'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
								'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								intBfKesikn = SSSVal(tmp)
								
								'税込売上金額全額相殺
								If intKesizan >= intKomikn - intKesikn Then
									
									'入金済額設定
									'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									.SetText(COL_KESIKN, idxRowJDNNO, intKomikn)
									
									'チェックボックス設定
									blnUsableSpread = False
									'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									.Row = idxRowJDNNO
									'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									.Col = COL_CHK
									'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									.Value = 1
									blnUsableSpread = True
									
									'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									Call .SetText(COL_HENPI, idxRowJDNNO, "1")
									
									'消込残額設定
									intKesizan = intKesizan - (intKomikn - intKesikn)
									
									'振込期日設定
									If DB_TOKMTA.SHAKB Like "[256]" Then
										'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										.GetText(COL_HYFRIDT, idxRowJDNNO, LS_HYFRIDT)
										'UPGRADE_WARNING: オブジェクト LS_HYFRIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										If Trim(LS_HYFRIDT) = "" Then
											'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
											.SetText(COL_HYFRIDT, idxRowJDNNO, strFRIDT)
										End If
									End If
									'税込売上金額一部相殺
									'入金済額設定
									
								Else
									
									'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									.SetText(COL_KESIKN, idxRowJDNNO, intKesikn + intKesizan)
									'チェックボックス設定
									
									
									''消込残額がゼロの場合、チェックをつけない
									If intKesizan > 0 Then
										
										
										blnUsableSpread = False
										'UPGRADE_WARNING: オブジェクト spd_body.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										.Row = idxRowJDNNO
										'UPGRADE_WARNING: オブジェクト spd_body.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										.Col = COL_CHK
										'UPGRADE_WARNING: オブジェクト spd_body.Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										.Value = 1
										blnUsableSpread = True
										
										
										'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										Call .SetText(COL_HENPI, idxRowJDNNO, "1")
										
										
									End If
									
									'消込残額ゼロ
									intKesizan = 0
									
									'振込期日設定
									If DB_TOKMTA.SHAKB Like "[256]" Then
										'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										.GetText(COL_HYFRIDT, idxRowJDNNO, LS_HYFRIDT)
										'UPGRADE_WARNING: オブジェクト LS_HYFRIDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										If Trim(LS_HYFRIDT) = "" Then
											'UPGRADE_WARNING: オブジェクト spd_body.SetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
											.SetText(COL_HYFRIDT, idxRowJDNNO, strFRIDT)
											'消込残額を設定
											
										End If
									End If
								End If
							End If
						End If
					Next idxRowJDNNO
				End If
			Next idxRow
		End With
		
		txt_kesizan.Text = VB6.Format(intKesizan, "###,###,##0")
		
	End Sub
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Function chk_HENPIN
	'   概要： 締日をまたいで返品登録、受注訂正を行った際
	'          赤黒にて相殺される受注を表示しない
	'   引数： strJdnNo   : 受注伝票番号
	'   　　： strJdnlinNo: 受注伝票行番号
	'       :  strUrikn   : 売上金額
	'   戻値： チェック結果
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	
	Function chkHenpin(ByVal strJdnno As String, ByVal strJdnlinno As String, ByVal strRECNO As String, ByVal strWrtFstDt As String, ByVal strWrtFstTm As String, ByVal strUritk As String, ByVal strUrikn As String) As Boolean
		
		
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		'UPGRADE_WARNING: 構造体 Usr_Ody2 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody2 As U_Ody
		Dim strSql As String
		
		On Error GoTo ERR_chkHENPIN
		
		chkHenpin = False
		
		strSql = " "
		strSql = " SELECT *"
		strSql = strSql & " FROM    UDNTRA"
		strSql = strSql & " WHERE   JDNNO    =  '" & Trim(strJdnno) & "'"
		strSql = strSql & " AND     JDNLINNO =  '" & Trim(strJdnlinno) & "'"
		strSql = strSql & " AND     DATKB =  '1'"
		strSql = strSql & " AND     AKAKROKB =  '9'"
		strSql = strSql & " AND     DKBID    =  '01'"
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'データが存在した場合
		Do While CF_Ora_EOF(Usr_Ody) = False
			
			'消込されていない場合、処理を行う
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) <> "1" Then
				
				'返品理由に値が格納されている売上を対象とする
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, DKBID, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If Trim(CF_Ora_GetDyn(Usr_Ody, "HENRSNCD", "")) <> "" And CF_Ora_GetDyn(Usr_Ody, "DKBID", "") = "01" Then
					
					
					'黒と赤のURIKNの差額が「0」になるのなら表示しない
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If CInt(strUrikn) = CInt(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) * (-1) Then
						chkHenpin = False
						GoTo END_chkHENPIN
					Else
						
						
						'返品登録を行った受注に対し単価訂正を行った場合、旧単価とその時の返品レコードを出力しないよう修正
						
						strSql = " "
						strSql = " SELECT COUNT(*) AS CNT"
						strSql = strSql & " FROM    UDNTRA"
						strSql = strSql & " WHERE   JDNNO       =  '" & Trim(strJdnno) & "'"
						strSql = strSql & " AND     JDNLINNO    =  '" & Trim(strJdnlinno) & "'"
						strSql = strSql & " AND     DATKB       =  '1'"
						strSql = strSql & " AND     AKAKROKB    =  '1'"
						strSql = strSql & " AND     DKBID       =  '01'"
						strSql = strSql & " AND     RECNO       =  '" & Trim(strRECNO) & "'"
						strSql = strSql & " AND     URITK       !=   " & strUritk & " "
						strSql = strSql & " AND     (WRTFSTDT || WRTFSTTM)  >  '" & strWrtFstDt & strWrtFstTm & "'"
						
						'DBアクセス
						Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody2, strSql)
						
						'データが存在した場合
						Do While CF_Ora_EOF(Usr_Ody2) = False
							
							'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If CInt(CF_Ora_GetDyn(Usr_Ody2, "CNT", 0)) >= 1 Then
								chkHenpin = False
								Call CF_Ora_CloseDyn(Usr_Ody2)
								GoTo END_chkHENPIN
							Else
								chkHenpin = True
								Call CF_Ora_CloseDyn(Usr_Ody2)
								GoTo END_chkHENPIN
							End If
							'UPGRADE_WARNING: オブジェクト Usr_Ody2.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Usr_Ody2.Obj_Ody.MoveNext()
						Loop 
						
					End If
				End If
				
			End If
			
			'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Usr_Ody.Obj_Ody.MoveNext()
		Loop 
		
		chkHenpin = True
		
END_chkHENPIN: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_chkHENPIN: 
		GoTo END_chkHENPIN
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Function chkHenpinTeisei
	'   概要： 締日をまたいで返品登録、受注訂正を行った際
	'          赤黒にて相殺される受注を表示しない
	'   引数： strJdnNo   : 受注伝票番号
	'   　　： strJdnlinNo: 受注伝票行番号
	'   　　： strUrikn   : 売上金額
	'   　　： strUdnno   : 売上伝票番号
	'   　　： strLinno   : 行番号
	'   　　： strUriDt   : 売上日
	'   戻値： チェック結果
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function chkHenpinTeisei(ByVal strJdnno As String, ByVal strJdnlinno As String, ByVal strUrikn As String, ByVal strUDNNO As String, ByVal strLINNO As String, ByVal strURIDT As String, ByVal strWrtFstDt As String, ByVal strWrtFstTm As String) As Boolean
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo ERR_chkHenpinTeisei
		
		chkHenpinTeisei = False
		
		strSql = " "
		
		strSql = " SELECT *"
		strSql = strSql & " FROM    UDNTRA"
		strSql = strSql & " WHERE   JDNNO    =  '" & strJdnno & "'"
		strSql = strSql & " AND     JDNLINNO =  '" & strJdnlinno & "'"
		strSql = strSql & " AND     DATKB =  '1'"
		strSql = strSql & " AND     AKAKROKB =  '9'"
		strSql = strSql & " AND     DKBID =  '01'"
		strSql = strSql & " AND     UDNNO  <>  '" & strUDNNO & "'"
		strSql = strSql & " AND     LINNO  =  '" & strLINNO & "'"
		'  strSql = strSql & " AND     UDNDT <>  '" & strURIDT & "'"
		strSql = strSql & " AND     (WRTFSTDT || WRTFSTTM)  <>  '" & strWrtFstDt & strWrtFstTm & "'"
		
		
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'データが存在した場合
		Do While CF_Ora_EOF(Usr_Ody) = False
			
			'消込されていない場合、処理を行う
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) <> "1" Then
				
				'黒と赤のURIKNの差額が「0」になるのなら表示しない
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If (CInt(strUrikn) + CInt(CF_Ora_GetDyn(Usr_Ody, "URIKN", ""))) = 0 Then
					chkHenpinTeisei = False
					GoTo END_chkHenpinTeisei
				Else
					chkHenpinTeisei = True
					GoTo END_chkHenpinTeisei
				End If
				
			End If
			
			'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Usr_Ody.Obj_Ody.MoveNext()
		Loop 
		
		chkHenpinTeisei = True
		
END_chkHenpinTeisei: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_chkHenpinTeisei: 
		GoTo END_chkHenpinTeisei
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Sub chkAkaKro
	'   概要： 一部返品が存在する売上を消込する際、赤と黒を割り出し
	'　　　　  赤のみ消込される場合は、エラーメッセージを出す。
	'          黒のみ消込される場合は、赤の存在があることをメッセージする。
	'
	'   備考： 2008/08/13 分納された売上に対しての赤黒チェックの追加・修正
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkAkaKro() As Object
		
		Dim intKesizan As Decimal 'ヘッダ部消込残額
		Dim intKomikn As Decimal '税込売上額
		Dim intKesikn As Decimal '消込額
		Dim intBfKesikn As Decimal '消込額(締日前)
		Dim intAfKesikn As Decimal
		
		Dim intUrikn As Decimal '売上金額
		Dim wkKesikn As Decimal '赤黒チェック用消込金ワーク変数
		Dim sumKesikn As Decimal '赤黒チェック用消込金変数
		Dim Cnt As Short '赤黒チェック用カウント変数
		Dim i As Short '赤黒チェック用
		Dim wkRow As Integer '赤黒チェック用行番号
		
		Dim tmp As Object
		Dim LS_HYFRIDT As Object
		Dim idxRow As Integer
		Dim idxRowJDNNO As Integer
		Dim strFRIDT As String
		Dim strHyjdnno As String
		Dim str_theHYJDNNO As String
		Dim intchk As Short
		Dim strUDNDT As String
		
		
		'UPGRADE_WARNING: オブジェクト chkAkaKro の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		chkAkaKro = True
		
		'返品を検索
		With spd_body
			For idxRow = 1 To intMaxRow
				
				'チェックが入っているかを確認
				'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.GetText(COL_CHK, idxRow, tmp)
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				intchk = SSSVal(tmp)
				
				
				'チェックが入っている場合
				If intchk = 1 Then
					
					''赤黒チェック配列の初期化
					ReDim Preserve AKAKRO_CHK(0)
					Cnt = 1
					
					'画面入力値の消込日以降の日付されている場合エラーとする。
					'売上日の取得
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .GetText(COL_UDNDT, idxRow, tmp)
					'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strUDNDT = CStr(tmp)
					
					If strUDNDT > DeCNV_DATE(Trim(txt_kesidt.Text)) Then
						MsgBox("入力された消込日以降の売上が存在します。")
						'UPGRADE_WARNING: オブジェクト chkAkaKro の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						chkAkaKro = False
						Exit Function
					End If
					
					'入金済額(締日前)
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .GetText(COL_BFKESIKN, idxRow, tmp)
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					intBfKesikn = SSSVal(tmp)
					
					'入金済額(締日後)
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .GetText(COL_AFKESIKN, idxRow, tmp)
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					intAfKesikn = SSSVal(tmp)
					
					
					'入金済額を取得
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .GetText(COL_KESIKN, idxRow, tmp)
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					intKesikn = SSSVal(tmp)
					
					'以前に消込されているもの以外
					If intBfKesikn + intAfKesikn = 0 Then
						
						'消込額がマイナスであれば同一受注番号の黒を検索
						If intKesikn < 0 Then
							
							'受注番号取得
							'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Call .GetText(COL_HYJDNNO, idxRow, tmp)
							'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							strHyjdnno = CStr(tmp)
							
							
							'赤のデータを配列に格納
							AKAKRO_CHK(0).idx = idxRow
							AKAKRO_CHK(0).CHKMK = intchk
							AKAKRO_CHK(0).UDNDT = strUDNDT
							AKAKRO_CHK(0).JDNNO = strHyjdnno
							AKAKRO_CHK(0).KESIKN = intKesikn
							
							
							'同一受注番号を検索
							For idxRowJDNNO = intMaxRow To 1 Step -1
								'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								.GetText(COL_HYJDNNO, idxRowJDNNO, tmp)
								'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								str_theHYJDNNO = CStr(tmp)
								
								'受注番号一致すれば相殺
								If strHyjdnno <> str_theHYJDNNO Then
								Else
									'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									.GetText(COL_CHK, idxRowJDNNO, tmp)
									'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									intchk = SSSVal(tmp)
									
									
									
									If idxRowJDNNO <> idxRow Then
										
										''同一受注番号の黒の消込金額を取得
										'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										.GetText(COL_KESIKN, idxRowJDNNO, tmp)
										'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										wkKesikn = SSSVal(tmp)
										
										
										'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										.GetText(COL_UDNDT, idxRowJDNNO, tmp)
										'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										strUDNDT = CStr(tmp)
										
										''同一受注番号の黒を配列に格納
										ReDim Preserve AKAKRO_CHK(Cnt)
										
										AKAKRO_CHK(Cnt).idx = idxRowJDNNO
										AKAKRO_CHK(Cnt).CHKMK = intchk
										AKAKRO_CHK(Cnt).JDNNO = strHyjdnno
										AKAKRO_CHK(Cnt).UDNDT = strUDNDT
										AKAKRO_CHK(Cnt).KESIKN = wkKesikn
										
										Cnt = Cnt + 1
									End If
									
								End If
							Next idxRowJDNNO
							
							
							''返品の赤黒チェック
							'サマリの初期化
							sumKesikn = AKAKRO_CHK(0).KESIKN
							
							For i = 1 To Cnt - 1
								
								'チェックが入っていない場合
								If AKAKRO_CHK(i).CHKMK = 0 Then
									
									wkRow = AKAKRO_CHK(i).idx
									strUDNDT = AKAKRO_CHK(i).UDNDT
									
									'入っている場合
								Else
									'赤のマイナスの消込金以上に黒の消込がされている
									If sumKesikn + AKAKRO_CHK(i).KESIKN >= 0 Then
										sumKesikn = 0
										Exit For
									Else
										'
										wkRow = AKAKRO_CHK(i).idx
										sumKesikn = sumKesikn + AKAKRO_CHK(i).KESIKN
									End If
									
								End If
							Next i
							
							'サマリがマイナスになっている場合はエラーメッセージを表示
							If Cnt - 1 >= 1 And sumKesikn < 0 Then
								MsgBox("充当が必要な売上があります。" & vbCrLf & vbCrLf & "行No:" & vbTab & wkRow & vbCrLf & "売上日: " & vbTab & strUDNDT & vbCrLf & "受注番号: " & vbTab & strHyjdnno)
								'UPGRADE_WARNING: オブジェクト chkAkaKro の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								chkAkaKro = False
								Exit Function
							End If
							
						Else
							'黒データからの検索
							
							'受注番号取得
							'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Call .GetText(COL_HYJDNNO, idxRow, tmp)
							'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							strHyjdnno = CStr(tmp)
							
							'同一受注番号を検索
							For idxRowJDNNO = intMaxRow To 1 Step -1
								'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								.GetText(COL_HYJDNNO, idxRowJDNNO, tmp)
								'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								str_theHYJDNNO = CStr(tmp)
								
								'受注番号一致すれば相殺
								If strHyjdnno <> str_theHYJDNNO Then
								Else
									
									'チェック
									'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									.GetText(COL_CHK, idxRowJDNNO, tmp)
									'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									intchk = SSSVal(tmp)
									
									'売上金額
									'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									.GetText(COL_URIKN, idxRowJDNNO, tmp)
									'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									intUrikn = SSSVal(tmp)
									
									
									
									''分納されている黒データを検出しないよう修正
									'自分自身でない、かつチェックされていない、かつ黒データでない
									If idxRowJDNNO <> idxRow And intchk = 0 And intUrikn < 0 Then
										
										
										'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										.GetText(COL_UDNDT, idxRowJDNNO, tmp)
										'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										strUDNDT = CStr(tmp)
										
										If MsgBox("充当が必要な売上があります。" & vbCrLf & "更新しますか？" & vbCrLf & vbCrLf & "行No:" & vbTab & idxRowJDNNO & vbCrLf & "売上日: " & vbTab & strUDNDT & vbCrLf & "受注番号: " & vbTab & strHyjdnno, MsgBoxStyle.OKCancel) = MsgBoxResult.OK Then
											
											'UPGRADE_WARNING: オブジェクト chkAkaKro の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
											chkAkaKro = True
											
										Else
											'UPGRADE_WARNING: オブジェクト chkAkaKro の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
											chkAkaKro = False
											Exit Function
										End If
										
									End If
								End If
							Next idxRowJDNNO
							
						End If
					End If
				End If
			Next idxRow
		End With
		
	End Function
	
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   名称： Function chkNyukn
	''   概要： 入金されているかのチェック
	''   備考：
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkNyukn() As Object
		
		
		Dim tmp As Object
		Dim idxRow As Integer
		Dim intchk As Short
		Dim i As Short
		Dim BlnFlg As Boolean
		
		'*** 2009/10/09 ADD START FKS)NAKATA
		Dim BlnFlgDay As Boolean
		'*** 2009/10/09 ADD E.N.D FKS)NAKATA
		
		Dim strJdnno As String '受注番号
		Dim strJdnlinno As String '受注行番号
		Dim strHyjdnno As String
		Dim strOkrjono As String '送り状№
		Dim curKesikn As Decimal
		Dim curKesiknMae As Decimal
		
		
		On Error GoTo ERR_chkNYUKN
		
		'UPGRADE_WARNING: オブジェクト chkNyukn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		chkNyukn = True
		
		
		
		With spd_body
			For idxRow = 1 To intMaxRow
				
				'チェックが入っているかを確認
				'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.GetText(COL_CHK, idxRow, tmp)
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				intchk = SSSVal(tmp)
				
				
				'チェックが入っている場合
				If intchk = 1 Then
					
					BlnFlg = False
					'*** 2009/10/09 ADD START FKS)NAKATA
					BlnFlgDay = False
					'*** 2009/10/09 ADD E.N.D FKS)NAKATA
					
					
					'受注番号を取得
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .GetText(COL_JDNNO, idxRow, tmp)
					'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strJdnno = CStr(tmp)
					
					'受注行番号を取得
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .GetText(COL_JDNLINNO, idxRow, tmp)
					'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strJdnlinno = CStr(tmp)
					
					'表示用受注番号を取得
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .GetText(COL_HYJDNNO, idxRow, tmp)
					'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strHyjdnno = CStr(tmp)
					
					'送り状№の取得
					strOkrjono = getOKRJONO(strJdnno, strJdnlinno)
					
					'入金額
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .GetText(COL_KESIKN, idxRow, tmp)
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					curKesikn = SSSVal(tmp)
					
					'入金額
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .GetText(COL_KESIKN_MAE, idxRow, tmp)
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					curKesiknMae = SSSVal(tmp)
					
					
					If System.Math.Abs(curKesikn) > System.Math.Abs(curKesiknMae) Then
						
						For i = 0 To UBound(ARY_NYUKN_KS)
							
							'入金されているかの確認
							If strOkrjono = ARY_NYUKN_KS(i).OKRJONO Then
								
								BlnFlg = True
								
								'入金日と充当日のチェック
								If ARY_NYUKN_KS(i).UDNDT <= gstrKesidt.Value Then
									BlnFlgDay = True
								Else
									Exit For
								End If
								
								Exit For
								
							End If
						Next i
						
						
						'入金が行われていない場合、エラーとする。
						If BlnFlg = False Then
							If MsgBox("入金が登録されていません。" & vbCrLf & vbCrLf & "行No:" & vbTab & idxRow & vbCrLf & "受注番号: " & vbTab & strHyjdnno, MsgBoxStyle.OKOnly, "前受充当戻し処理") = MsgBoxResult.OK Then
								'UPGRADE_WARNING: オブジェクト chkNyukn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								chkNyukn = False
								GoTo END_chkNyukn
							End If
						End If
						
						'*** 2009/10/09 ADD START FKS)NAKATA
						'充当日より入金日が以前の場合、エラーとする。
						If BlnFlgDay = False Then
							If MsgBox("入金日以前では充当できません。" & vbCrLf & vbCrLf & "行No:" & vbTab & idxRow & vbCrLf & "受注番号: " & vbTab & strHyjdnno, MsgBoxStyle.OKOnly, "前受充当戻し処理") = MsgBoxResult.OK Then
								'UPGRADE_WARNING: オブジェクト chkNyukn の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								chkNyukn = False
								GoTo END_chkNyukn
							End If
						End If
						'*** 2009/10/09 ADD E.N.D FKS)NAKATA
						
						
						
					End If
					
				End If
				
			Next idxRow
		End With
		
		
END_chkNyukn: 
		
		Exit Function
		
ERR_chkNYUKN: 
		GoTo END_chkNyukn
		
	End Function
	
	'**** 2009/09/16 DEL START FKS)NAKATA
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   名称： Function chkURIKN
	''   概要： 売上金額と充当金額のチェック
	''   備考：
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Private Function chkUrikn()
	'
	'    Dim tmp             As Variant
	'    Dim idxRow          As Long
	'    Dim intchk          As Integer
	'
	'    Dim strJdnno        As String    '受注番号
	'    Dim strJdnlinno     As String    '受注行番号
	'    Dim strHyjdnno      As String    '表示用受注番号
	'    Dim strOkrjono      As String    '送り状№
	'    Dim strJdntrkb      As String    '受注取引区分
	'
	'    Dim curBfKesikn     As Currency  '消込額(締日前)
	'    Dim curAfKesikn     As Currency  '消込額(締日後)
	'
	'    Dim curNYUKN        As Currency  '入金レコード入金額
	'    Dim curUrikn        As Currency  '売上レコード売上金額 + 税金
	'
	'    Dim Usr_Ody         As U_Ody
	'    Dim strSql          As String
	'
	'    On Error GoTo ERR_chkUrikn
	'
	'
	'
	'    chkUrikn = True
	'
	'    '返品を検索
	'    With spd_body
	'        For idxRow = 1 To intMaxRow
	'
	'            'チェックが入っているかを確認
	'            .GetText COL_CHK, idxRow, tmp
	'            intchk = SSSVal(tmp)
	'
	'
	'            'チェックが入っている場合
	'            If intchk = 1 Then
	'
	'
	'                '受注番号を取得
	'                Call .GetText(COL_JDNNO, idxRow, tmp)
	'                strJdnno = CStr(tmp)
	'
	'
	'                '受注行番号を取得
	'                Call .GetText(COL_JDNLINNO, idxRow, tmp)
	'                strJdnlinno = CStr(tmp)
	'
	'
	'                '表示用受注番号を取得
	'                Call .GetText(COL_HYJDNNO, idxRow, tmp)
	'                strHyjdnno = CStr(tmp)
	'
	'
	'                '入金済額(締日前)
	'                Call .GetText(COL_BFKESIKN, idxRow, tmp)
	'                curBfKesikn = SSSVal(tmp)
	'
	'
	'                '入金済額(締日後)
	'                Call .GetText(COL_AFKESIKN, idxRow, tmp)
	'                curAfKesikn = SSSVal(tmp)
	'
	'
	'                    '以前に消込されているもの以外を対象とする
	'                    If curBfKesikn + curAfKesikn = 0 Then
	'
	'
	'                            ''受注番号より受注取引区分を取得する。
	'                            strSql = " "
	'                            strSql = strSql & " SELECT  JDNTRKB"
	'                            strSql = strSql & "  FROM   JDNTHA"
	'                            strSql = strSql & " WHERE   DATNO IN"
	'                            strSql = strSql & " ("
	'                            strSql = strSql & "  SELECT  MAX(DATNO)"
	'                            strSql = strSql & "   FROM   JDNTHA"
	'                            strSql = strSql & "  WHERE   DATKB = '1'"
	'                            strSql = strSql & "    AND   JDNNO = '" & strJdnno & "'"
	'                            strSql = strSql & " )"
	'                            strSql = strSql & "    AND DATKB = '1'"
	'
	'
	'                            'DBアクセス
	'                            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
	'
	'                            If CF_Ora_EOF(Usr_Ody) = False Then
	'                                strJdntrkb = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")) '受注取引区分
	'                            End If
	'
	'                            Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
	'
	'
	'
	'                            ''受注番号・行番号より売上金額を取得する
	'                            strSql = ""
	'                            strSql = strSql & "SELECT SUM(URIKN) + SUM(UZEKN)   URIKN"
	'                            strSql = strSql & "  FROM UDNTRA"
	'                            strSql = strSql & " WHERE JDNNO     = '" & strJdnno & "'"
	'
	'                            'セットアップ・システム以外の受注は明細行全体で金額をサマリする。
	'                            If strJdntrkb = "11" Or strJdntrkb = "21" Then
	'                            Else
	'                                strSql = strSql & "   AND JDNLINNO  = '" & strJdnlinno & "'"
	'                            End If
	'
	'                            strSql = strSql & "   AND IRISU     <> 9"
	'                            strSql = strSql & "   AND DATKB     = '1'"
	'
	'
	'                            'DBアクセス
	'                            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
	'
	'                            If CF_Ora_EOF(Usr_Ody) = False Then
	'                                curUrikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) '売上金額
	'                            End If
	'
	'                            Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
	'
	'
	'
	'                            '受注番号 + 行番号を「送り状№」へ変更
	'                            'セットアップ・システムは、行番号を「001」固定
	'                            If strJdntrkb = "11" Or strJdntrkb = "21" Then
	'                                strOkrjono = Trim$(strJdnno) & "001"
	'                            Else
	'                                strOkrjono = Trim$(strJdnno) & Trim$(strJdnlinno)
	'                            End If
	'
	'
	'
	'                            ''入金レコードより入金額を取得する。
	'                            strSql = " "
	'                            strSql = strSql & " SELECT  SUM(TRA.NYUKN) AS NYUKN"
	'                            strSql = strSql & "  FROM    UDNTRA TRA ,"
	'                            strSql = strSql & "          UDNTHA THA"
	'                            strSql = strSql & " WHERE    TRA.DATNO = THA.DATNO"
	'                            strSql = strSql & "  AND     TRA.DATKB = '1'"
	'                            strSql = strSql & "  AND     TRA.DENKB = '8'"
	'                            strSql = strSql & "  AND     THA.NYUCD = '2'"
	'                            strSql = strSql & "  AND     THA.FRNKB = '0'"
	'                            strSql = strSql & "  AND     TRA.OKRJONO = '" & strOkrjono & "'"
	'
	'
	'
	'                            'DBアクセス
	'                            Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
	'
	'                            If CF_Ora_EOF(Usr_Ody) = False Then
	'                                curNYUKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "NYUKN", "")) '売上金額
	'                            End If
	'
	'                            Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
	'
	'
	'                            '売上金額と入金額が一致していない場合、エラー
	'                            If curUrikn <> curNYUKN Then
	'                                If MsgBox("売上金額と入金額が異なります。" & vbCrLf & vbCrLf _
	''                                            & "行No:" & vbTab & idxRow & vbCrLf _
	''                                            & "受注番号: " & vbTab & strHyjdnno, vbOKOnly, "前受充当戻し処理") = vbOK Then
	'                                    chkUrikn = False
	'                                    GoTo END_chkUrikn
	'                                End If
	'                            End If
	'
	'                    End If
	'            End If
	'       Next idxRow
	'    End With
	'
	'
	'END_chkUrikn:
	'    'クローズ
	'    Call CF_Ora_CloseDyn(Usr_Ody)
	'    Exit Function
	'
	'ERR_chkUrikn:
	'    GoTo END_chkUrikn
	'
	'
	'End Function
	'**** 2009/09/16 DEL E.N.D FKS)NAKATA
	
	'**** 2009/09/16 DEL START FKS)NAKATA
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   名称： Function chkJdntrkb
	''   概要： 伝票単位での充当チェック
	''   備考：
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Private Function chkJdntrkb()
	'
	'    Dim tmp             As Variant
	'    Dim idxRow          As Long
	'    Dim intchk          As Integer
	'
	'    Dim i               As Integer
	'    Dim Cnt             As Long
	'
	'    'スプレッド格納変数
	'    Dim strJdnno        As String    '受注番号
	'    Dim strJdnlinno     As String    '受注行番号
	'    Dim strHyjdnno      As String    '表示用受注番号
	'    Dim curKomikn       As Currency  '売上金額＋税金
	'
	'    '受注取引区分
	'    Dim strOkrjono      As String    '送り状№
	'    Dim strJdntrkb      As String    '受注取引区分
	'
	'
	'    'チェック用変数
	'    Dim wkIdx           As Integer
	'    Dim wkJdnno         As String
	'    Dim wkHyjdnno       As String
	'    Dim wkKomikn        As Currency
	'    Dim curUrikn        As Currency  '売上レコード売上金額 + 税金
	'
	'
	'    Dim Usr_Ody         As U_Ody
	'    Dim strSql          As String
	'
	'    On Error GoTo ERR_chkJdntrkb
	'
	'
	'    chkJdntrkb = True
	'
	'
	'    '配列の初期化
	'    ReDim Preserve JDNTRKB_CHK(0)
	'    Cnt = 0
	'
	'
	'        With spd_body
	'            For idxRow = 1 To intMaxRow
	'
	'                'チェックが入っているかを確認
	'                .GetText COL_CHK, idxRow, tmp
	'                intchk = SSSVal(tmp)
	'
	'
	'                'チェックが入っている場合
	'                If intchk = 1 Then
	'
	'
	'                    '受注番号を取得
	'                    Call .GetText(COL_JDNNO, idxRow, tmp)
	'                    strJdnno = CStr(tmp)
	'
	'
	'                    '受注行番号を取得
	'                    Call .GetText(COL_JDNLINNO, idxRow, tmp)
	'                    strJdnlinno = CStr(tmp)
	'
	'
	'                    '表示用受注番号を取得
	'                    Call .GetText(COL_HYJDNNO, idxRow, tmp)
	'                    strHyjdnno = CStr(tmp)
	'
	'
	'                    '税込売上金額を取得
	'                    Call .GetText(COL_KOMIKN, idxRow, tmp)
	'                    curKomikn = CCur(tmp)
	'
	'
	'                    '受注番号より受注取引区分を取得する。
	'                    strSql = " "
	'                    strSql = strSql & " SELECT  JDNTRKB"
	'                    strSql = strSql & "  FROM   JDNTHA"
	'                    strSql = strSql & " WHERE   DATNO IN"
	'                    strSql = strSql & " ("
	'                    strSql = strSql & "  SELECT  MAX(DATNO)"
	'                    strSql = strSql & "   FROM   JDNTHA"
	'                    strSql = strSql & "  WHERE   DATKB = '1'"
	'                    strSql = strSql & "    AND   JDNNO = '" & strJdnno & "'"
	'                    strSql = strSql & " )"
	'                    strSql = strSql & "    AND DATKB = '1'"
	'
	'
	'                    'DBアクセス
	'                    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
	'
	'                    If CF_Ora_EOF(Usr_Ody) = False Then
	'                        strJdntrkb = SSSVal(CF_Ora_GetDyn(Usr_Ody, "JDNTRKB", "")) '受注取引区分
	'                    End If
	'
	'                    Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
	'
	'
	'                    '受注取引区分がセットアップとシステムの時のみ配列に格納する
	'                    If strJdntrkb = "11" Or strJdntrkb = "21" Then
	'
	'                        ReDim Preserve JDNTRKB_CHK(Cnt)
	'                        With JDNTRKB_CHK(Cnt)
	'                            .idx = idxRow
	'                            .JDNNO = strJdnno
	'                            .HYJDNNO = strHyjdnno
	'                            .KOMIKN = curKomikn
	'                        End With
	'
	'                        Cnt = Cnt + 1
	'
	'                    End If
	'
	'                End If
	'            Next idxRow
	'        End With
	'
	'
	'        '配列1番目の受注番号を開始点としてセット
	'        wkIdx = JDNTRKB_CHK(0).idx
	'        wkJdnno = JDNTRKB_CHK(0).JDNNO
	'        wkHyjdnno = JDNTRKB_CHK(0).HYJDNNO
	'
	'            For i = 0 To UBound(JDNTRKB_CHK)
	'
	'
	'            If wkJdnno = JDNTRKB_CHK(i).JDNNO Then
	'
	'                '受注番号が同じ場合は、税込売上金額を加算する。
	'                wkIdx = JDNTRKB_CHK(i).idx
	'                wkHyjdnno = JDNTRKB_CHK(i).HYJDNNO
	'                wkKomikn = wkKomikn + JDNTRKB_CHK(i).KOMIKN
	'
	'            Else
	'
	'                ''受注番号・行番号より売上金額を取得する
	'                strSql = ""
	'                strSql = strSql & "SELECT SUM(URIKN) + SUM(UZEKN)   URIKN"
	'                strSql = strSql & "  FROM UDNTRA"
	'                strSql = strSql & " WHERE JDNNO     = '" & wkJdnno & "'"
	'                strSql = strSql & "   AND IRISU     <> 9"
	'                strSql = strSql & "   AND DATKB     = '1'"
	'
	'
	'                'DBアクセス
	'                Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
	'
	'                If CF_Ora_EOF(Usr_Ody) = False Then
	'                    curUrikn = SSSVal(CF_Ora_GetDyn(Usr_Ody, "URIKN", "")) '売上金額
	'                End If
	'
	'                Call CF_Ora_CloseDyn(Usr_Ody)   'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
	'
	'
	'                '取得した売上金額と画面でチェックされている売上金額を比較する。
	'                If wkKomikn <> curUrikn Then
	'
	'                    If MsgBox("伝票単位で充当/充当解除を行ってください。" & vbCrLf & vbCrLf _
	''                                & "行No:" & vbTab & wkIdx & vbCrLf _
	''                                & "受注番号: " & vbTab & wkHyjdnno, vbOKOnly, "前受充当戻し処理") = vbOK Then
	'                        chkJdntrkb = False
	'                        GoTo END_chkJdntrkb
	'                    End If
	'
	'                End If
	'
	'                '受注番号をセット
	'                wkIdx = JDNTRKB_CHK(i).idx
	'                wkJdnno = JDNTRKB_CHK(i).JDNNO
	'                wkKomikn = JDNTRKB_CHK(i).KOMIKN
	'
	'            End If
	'        Next i
	'
	'
	'
	'END_chkJdntrkb:
	'    'クローズ
	'    Call CF_Ora_CloseDyn(Usr_Ody)
	'    Exit Function
	'
	'ERR_chkJdntrkb:
	'    GoTo END_chkJdntrkb
	'
	'
	'End Function
	'**** 2009/09/16 DEL E.N.D FKS)NAKATA
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub ChkInputChange
	'   概要：  明細の入力内容の変更確認
	'   引数：  無し
	'   戻値：　True:変更有り  False:変更無し
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function ChkInputChange() As Boolean
		
		Dim i As Short
		Dim vnt_AFCHK As Object
		Dim vnt_BFCHK As Object
		
		ChkInputChange = False
		
		With spd_body
			'UPGRADE_WARNING: オブジェクト spd_body.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			For i = 1 To .MaxRows
				'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(COL_CHK, i, vnt_AFCHK)
				'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call .GetText(COL_BFCHECK, i, vnt_BFCHK)
				'UPGRADE_WARNING: オブジェクト SSSVal(vnt_BFCHK) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト SSSVal(vnt_AFCHK) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If SSSVal(vnt_AFCHK) <> SSSVal(vnt_BFCHK) Then
					ChkInputChange = True
					Exit For
				End If
			Next i
		End With
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Get_NKSTRA_HAITA_INF
	'   概要：  入金消込トランの排他情報取得
	'   引数：  無し
	'   戻値：　True:正常  False:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Get_NKSTRA_HAITA_INF() As Boolean
		
		Dim strSql As Object
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		'UPGRADE_WARNING: 構造体 Usr_Ody_1 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_1 As U_Ody
		Dim i As Integer
		Dim Lng_Cnt As Integer
		
		Get_NKSTRA_HAITA_INF = False
		
		ReDim ARY_NKSTRA_HAITA(0)
		
		For i = 1 To UBound(ARY_UDNTRA_HAITA)
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = ""
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "SELECT " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       KDNNO  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,OPEID  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,CLTID  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,WRTDT  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,WRTTM  " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UOPEID " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UCLTID " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UWRTDT " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "      ,UWRTTM " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "FROM " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       NKSTRA " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "WHERE " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "       UDNDATNO = '" & ARY_UDNTRA_HAITA(i).DATNO & "' " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "AND    UDNLINNO = '" & ARY_UDNTRA_HAITA(i).LINNO & "' " & vbCrLf
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
			
			'DBアクセス
			'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
			
			Do While CF_Ora_EOF(Usr_Ody) = False
				
				'取消データが存在するか確認し、いない場合は取り消しされていないので、取り消しレコード処理を実施する
				'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSql = ""
				'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSql = strSql & "SELECT " & vbCrLf
				'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSql = strSql & "       KDNNO " & vbCrLf
				'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSql = strSql & "FROM " & vbCrLf
				'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSql = strSql & "       NKSTRA " & vbCrLf
				'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSql = strSql & "WHERE " & vbCrLf
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSql = strSql & "       MOTKDNNO = '" & CF_Ora_GetDyn(Usr_Ody, "KDNNO", "") & "' " & vbCrLf
				
				'DBアクセス
				'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody_1, strSql)
				
				If CF_Ora_EOF(Usr_Ody_1) Then
					Lng_Cnt = Lng_Cnt + 1
					ReDim Preserve ARY_NKSTRA_HAITA(Lng_Cnt)
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_NKSTRA_HAITA(Lng_Cnt).KDNNO = CStr(CF_Ora_GetDyn(Usr_Ody, "KDNNO", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_NKSTRA_HAITA(Lng_Cnt).OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_NKSTRA_HAITA(Lng_Cnt).CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_NKSTRA_HAITA(Lng_Cnt).WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_NKSTRA_HAITA(Lng_Cnt).WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_NKSTRA_HAITA(Lng_Cnt).UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UOPEID", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_NKSTRA_HAITA(Lng_Cnt).UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UCLTID", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_NKSTRA_HAITA(Lng_Cnt).UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					ARY_NKSTRA_HAITA(Lng_Cnt).UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", ""))
				End If
				
				Call CF_Ora_CloseDyn(Usr_Ody_1) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
				'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Usr_Ody.Obj_Ody.MoveNext()
			Loop 
			Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
		Next i
		
		Get_NKSTRA_HAITA_INF = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Get_NKSTRA_TEGDT
	'   概要：  入金消込トランの期日振込日の取得
	'   引数：  無し
	'   戻値：　True:正常  False:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Get_NKSTRA_TEGDT(ByRef vnt_UDNDATNO As Object, ByRef vnt_UDNLINNO As Object) As String
		
		Dim strSql As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		'UPGRADE_WARNING: 構造体 Usr_Ody_1 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_1 As U_Ody
		Dim strTEGDT As String
		Dim blnExist As Boolean
		
		strTEGDT = ""
		
		blnExist = False
		
		
		strSql = ""
		strSql = strSql & "SELECT " & vbCrLf
		strSql = strSql & "       MAX(TEGDT) TEGDT " & vbCrLf
		strSql = strSql & "FROM " & vbCrLf
		strSql = strSql & "       NKSTRA " & vbCrLf
		strSql = strSql & "WHERE " & vbCrLf
		'UPGRADE_WARNING: オブジェクト vnt_UDNDATNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "       UDNDATNO = '" & vnt_UDNDATNO & "' " & vbCrLf
		'UPGRADE_WARNING: オブジェクト vnt_UDNLINNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "AND    UDNLINNO = '" & vnt_UDNLINNO & "' " & vbCrLf
		strSql = strSql & "AND    DATKB    = '1' " & vbCrLf
		strSql = strSql & "AND    AKAKROKB = '1' " & vbCrLf
		strSql = strSql & "AND    KDNNO NOT IN ( " & vbCrLf
		strSql = strSql & "       SELECT " & vbCrLf
		strSql = strSql & "              MOTKDNNO " & vbCrLf
		strSql = strSql & "       FROM " & vbCrLf
		strSql = strSql & "              NKSTRA " & vbCrLf
		strSql = strSql & "       WHERE " & vbCrLf
		'UPGRADE_WARNING: オブジェクト vnt_UDNDATNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "              UDNDATNO = '" & vnt_UDNDATNO & "' " & vbCrLf
		'UPGRADE_WARNING: オブジェクト vnt_UDNLINNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "       AND    UDNLINNO = '" & vnt_UDNLINNO & "' " & vbCrLf
		strSql = strSql & "       AND    TRIM(MOTKDNNO) IS NOT NULL " & vbCrLf
		strSql = strSql & "       ) " & vbCrLf
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		If Not CF_Ora_EOF(Usr_Ody) Then
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
		End If
		
		Get_NKSTRA_TEGDT = strTEGDT
		
	End Function
	'*** 2009/09/03 ADD START FKS)NAKATA V1.03
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Get_NYUKN_TEGDT
	'   概要：  売上トラン.入金レコードの期日振込日の取得
	'   引数：  無し
	'   戻値：　True:正常  False:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Get_NYUKN_TEGDT(ByRef vnt_JDNNO As String, ByRef vnt_JDNLINNO As String) As String
		
		Dim strSql As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		'UPGRADE_WARNING: 構造体 Usr_Ody_1 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody_1 As U_Ody
		Dim strTEGDT As String
		Dim strOkrjono As String
		Dim blnExist As Boolean
		
		strTEGDT = ""
		
		blnExist = False
		
		strOkrjono = getOKRJONO(vnt_JDNNO, vnt_JDNLINNO)
		
		
		strSql = " "
		strSql = strSql & " SELECT  " & vbCrLf
		strSql = strSql & "   MAX(TEGDT) AS TEGDT" & vbCrLf
		strSql = strSql & "  FROM  UDNTRA TRA" & vbCrLf
		strSql = strSql & " WHERE  TRA.DENKB     =   '8'" & vbCrLf
		strSql = strSql & "   AND  TRA.DATKB     =   '1'" & vbCrLf
		strSql = strSql & "   AND  TRA.AKAKROKB  =   '1'" & vbCrLf
		strSql = strSql & "   AND  TRA.KESIKB    =   '9'" & vbCrLf
		strSql = strSql & "   AND  TRA.OKRJONO   =   '" & strOkrjono & "'" & vbCrLf
		strSql = strSql & "   AND  TRA.DATNO IN" & vbCrLf
		strSql = strSql & "            ( SELECT MAX(DATNO)" & vbCrLf
		strSql = strSql & "                FROM  UDNTRA" & vbCrLf
		strSql = strSql & "               WHERE  DENKB    =  '8'" & vbCrLf
		strSql = strSql & "                 AND  DATKB    =  '1'" & vbCrLf
		strSql = strSql & "                 AND  DKBID   !=  '09'" & vbCrLf
		strSql = strSql & "                 AND  OKRJONO  =  '" & strOkrjono & "'" & vbCrLf
		strSql = strSql & "            )" & vbCrLf
		
		
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		If Not CF_Ora_EOF(Usr_Ody) Then
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strTEGDT = CF_Ora_GetDyn(Usr_Ody, "TEGDT", "")
		End If
		
		Get_NYUKN_TEGDT = strTEGDT
		
	End Function
	'*** 2009/09/03 ADD E.N.D FKS)NAKATA V1.03
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function chkCondition
	'   概要：  ヘッダ部の入力チェック
	'   引数：  無し
	'   戻値：　True:正常  False:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkCondition() As Boolean
		chkCondition = False
		
		'チェック：消込日
		With txt_kesidt
			If Trim(.Text) = "" Then
				'必須入力チェック
				Call showMsg("0", "_HEADCOMPLETEC", "0") '●見出未入力ｴﾗｰMSG
				.ForeColor = System.Drawing.Color.Red
				.Focus()
				Exit Function
			Else
				intChkKb = 1
				'チェック処理
				If chkKesidt(True) = False Then 'チェック処理を強制的に走らせる
					'エラー
					Call .Focus()
					Exit Function
				End If
			End If
		End With
		
		'チェック：請求先コード
		With txt_tokseicd
			If Trim(.Text) = "" Then
				'必須入力チェック
				Call showMsg("0", "_HEADCOMPLETEC", "0") '●見出未入力ｴﾗｰMSG
				.ForeColor = System.Drawing.Color.Red
				.Focus()
				Exit Function
			Else
				intChkKb = 1
				'チェック処理
				If chkTokseicd(True) = False Then 'チェック処理を強制的に走らせる
					'エラー
					Call .Focus()
					Exit Function
				End If
			End If
		End With
		
		'チェック：売上日(開始)
		With txt_kaidt_From
			If Trim(.Text) = "" Then
				If Trim(txt_kesikb.Text) = "9" Then
					'必須入力チェック
					Call showMsg("0", "_HEADCOMPLETEC", "0") '●見出未入力ｴﾗｰMSG
					.ForeColor = System.Drawing.Color.Red
					.Focus()
					Exit Function
				End If
			Else
				intChkKb = 1
				If chkKaidt_From(True) = False Then 'チェック処理を強制的に走らせる
					'エラー
					.Focus()
					Exit Function
				End If
			End If
		End With
		
		'チェック：売上日(終了)
		With txt_kaidt_To
			If Trim(.Text) = "" Then
				'必須入力チェック
				Call showMsg("0", "_HEADCOMPLETEC", "0") '●見出未入力ｴﾗｰMSG
				.ForeColor = System.Drawing.Color.Red
				.Focus()
				Exit Function
			Else
				intChkKb = 1
				'チェック処理
				If chkKaidt_To(True) = False Then 'チェック処理を強制的に走らせる
					'エラー
					.Focus()
					Exit Function
				End If
			End If
		End With
		
		With txt_fridt
			If Trim(.Text) = "" Then
				If blnFriEnabled = True Then
					'必須入力チェック
					Call showMsg("0", "_HEADCOMPLETEC", "0") '●見出未入力ｴﾗｰMSG
					
					.Enabled = True
					
					.ForeColor = System.Drawing.Color.Red
					.Focus()
					Exit Function
				End If
			Else
				intChkKb = 1
				'チェック処理
				If chkFridt(True) = False Then 'チェック処理を強制的に走らせる
					'エラー
					.Focus()
					Exit Function
				End If
			End If
		End With
		
		chkCondition = True
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function chkKesidt
	'   概要：  消込日付のチェック
	'   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
	'   戻値：　True:正常  False:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkKesidt(Optional ByVal pin_blnChk As Boolean = False) As Boolean
		Dim date1 As String
		Dim date2 As String
		Dim date3 As String
		
		chkKesidt = False
		
		With txt_kesidt
			If pin_blnChk = False Then
				'チェック区分が1のとき、あるいは変更されていたらチェックを行う
				If intChkKb <> 1 Then
					chkKesidt = True
					GoTo END_STEP
				End If
				If .Text = CNV_DATE(gstrKesidt.Value) Then
					chkKesidt = True
					GoTo END_STEP
				End If
			End If
			
			'空白入力時はチェックしない（chkConditionでチェック）
			If Trim(.Text) = "" Then
				chkKesidt = True
				Exit Function
			End If
			
			'日付形式のチェック
			If IsDate(.Text) = False Then
				Call showMsg("2", "DATE", CStr(0)) '●日付誤りのMSG
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			
			'2009/09/03 ADD START RISE)MIYAJIMA
			'入金日のチェック時、前回月次更新実行日だけでなく、前回請求締日とのチェックも必要
			If Trim(txt_tokseicd.Text) <> "" Then
				If DeCNV_DATE(.Text) <= DB_TOKMTA.TOKSMEDT Then
					Call showMsg("2", "URKET73_042", CStr(0)) '●請求締日以前です。この日付では入力できません。MSG
					.ForeColor = System.Drawing.Color.Red
					GoTo END_STEP
				End If
			End If
			'2009/09/03 ADD E.N.D RISE)MIYAJIMA
			
			
			'経理締日以前の日付の時はエラー
			If DeCNV_DATE(.Text) <= DB_SYSTBA.SMAUPDDT Then
				'If DeCNV_DATE(.Text) <= DB_SYSTBA.MONUPDDT Then '月次本締日の条件撤廃
				Call showMsg("1", "URKET73_010", CStr(0)) '●経理締め済みのMSG
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			'運用日より後日付の時はエラー
			If DeCNV_DATE(.Text) > gstrUnydt.Value Then
				Call showMsg("2", "DATE_1", CStr(3)) '●運用日後日付エラー
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			'締めを跨いでの日付はエラー
			date1 = VB6.Format(CNV_DATE(VB.Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
			date2 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, CDate(date1)))
			date3 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(date2)))
			If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
				Call showMsg("1", "URKET73_038", CStr(0)) '●締めを跨いでの日付は入力できません
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			.ForeColor = System.Drawing.Color.Black
		End With
		
		chkKesidt = True
		
END_STEP: 
		
		gstrKesidt.Value = DeCNV_DATE((txt_kesidt.Text))
		intChkKb = 2 '●基本は変更時にチェック
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function chkTokseicd
	'   概要：  請求先ｺｰﾄﾞのチェック
	'   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
	'   戻値：　True:正常  False:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkTokseicd(Optional ByVal pin_blnChk As Boolean = False) As Boolean
		
		
		'2009/09/07 ADD START FKS)NAKATA
		Dim strTANCLAKB As String
		'2009/09/07 ADD E.N.D FKS)NAKATA
		
		
		chkTokseicd = False
		
		With txt_tokseicd
			If pin_blnChk = False Then
				'チェック区分が1のとき、あるいは変更されていたらチェックを行う
				If intChkKb <> 1 Then
					chkTokseicd = True
					GoTo END_STEP
				End If
				If .Text = gstrTokseicd.Value Then
					chkTokseicd = True
					GoTo END_STEP
				End If
			End If
			
			'変更されていたら項目クリア
			If .Text <> gstrTokseicd.Value Then
				txt_tokseinma.Text = ""
				txt_fridt.Text = Space(8)
				txt_fridt.Enabled = False
				
				lbl_shakbnm(1).Text = ""
				lbl_hytokkesdd(1).Text = ""
				gstrFridt.Value = Space(8)
			End If
			
			'空白入力時はチェックしない（chkConditionでチェック）
			If Trim(.Text) = "" Then
				chkTokseicd = True
				Exit Function
			End If
			
			blnFriEnabled = False
			
			'得意先ﾏｽﾀから請求先名称を取得
			Select Case getTokseinm(DeCNV_DATE((txt_kesidt.Text)), .Text)
				'国内請求先のとき
				Case 0
					.ForeColor = System.Drawing.Color.Black
					txt_tokseinma.Text = DB_TOKMTA.TOKRN
					lbl_shakbnm(1).Text = DB_TOKMTA.SHAKBNM
					lbl_hytokkesdd(1).Text = DB_TOKMTA.HYTOKKESDD
					
					
					'2009/09/07 ADD START FKS)NAKATA V1.04
					'入金日のチェック時、前回月次更新実行日だけでなく、前回請求締日とのチェックも必要
					If DeCNV_DATE((txt_kesidt.Text)) <= DB_TOKMTA.TOKSMEDT Then
						Call showMsg("2", "URKET73_042", CStr(0)) '●請求締日以前です。この日付では入力できません。MSG
						txt_kesidt.ForeColor = System.Drawing.Color.Red
						txt_kesidt.Focus()
						GoTo END_STEP
					End If
					'2009/09/07 ADD E.N.D FKS)NAKATA
					'2009/09/07 ADD START FKS)NAKATA V1.04
					Call F_Util_GET_TANMTA_TANCLAKB(DB_TOKMTA.TANCD, strTANCLAKB)
					If strTANCLAKB <> "1" Then
						Call showMsg("2", "URKET73_043", CStr(0)) '●請求先担当者が営業でありません。
						.ForeColor = System.Drawing.Color.Red
						GoTo END_STEP
					End If
					'2009/09/07 ADD E.N.D FKS)NAKATA
					
					
					
					'*** 2009/09/03 CHG START FKS)NAKATA V1.03
					'振込期日は、消込トラン又は売上トラン.入金レコードより取得するため
					''                Call getInputHYFRIDT(DB_TOKMTA.TOKSEICD _
					'''                                    , Get_Acedt(DeCNV_DATE(txt_kesidt.Text)) _
					'''                                    , DB_TOKMTA.SHAKB)
					''
					''                txt_fridt.Enabled = blnFriEnabled
					blnFriEnabled = False
					'*** 2009/09/03 CHG E.N.D FKS)NAKATA V1.03
					
					chkTokseicd = True
					
					'海外請求先のとき
				Case 1
					Call showMsg("1", "URKET73_013", CStr(0)) '●国内の得意先ではありません。
					.ForeColor = System.Drawing.Color.Red
					GoTo END_STEP
					
					'請求先でない得意先のとき
				Case 8
					Call showMsg("2", "DONTSELECT", "2") '●請求先ではない
					.ForeColor = System.Drawing.Color.Red
					GoTo END_STEP
					
					'請求先が存在しない時
				Case 9
					Call showMsg("2", "RNOTFOUND", "0") '●該当データなし
					.ForeColor = System.Drawing.Color.Red
					GoTo END_STEP
			End Select
			
			.ForeColor = System.Drawing.Color.Black
		End With
		
		chkTokseicd = True
		
END_STEP: 
		
		gstrTokseicd.Value = txt_tokseicd.Text
		intChkKb = 2 '●基本は変更時にチェック
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function chkKaidt_From
	'   概要：  回収予定日付（開始）のチェック
	'   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
	'   戻値：　True:正常  False:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkKaidt_From(Optional ByVal pin_blnChk As Boolean = False) As Boolean
		Dim date1 As String
		Dim date2 As String
		Dim date3 As String
		
		chkKaidt_From = False
		
		With txt_kaidt_From
			If pin_blnChk = False Then
				'チェック区分が1のとき、あるいは変更されていたらチェックを行う
				If intChkKb <> 1 Then
					chkKaidt_From = True
					GoTo END_STEP
				End If
				If .Text = CNV_DATE(gstrKaidt_Fr.Value) Then
					chkKaidt_From = True
					GoTo END_STEP
				End If
			End If
			
			'空白入力時はチェックしない（chkConditionでチェック）
			If Trim(.Text) = "" Then
				gstrKaidt_Fr.Value = ""
				chkKaidt_From = True
				Exit Function
			End If
			
			'日付形式のチェック
			If IsDate(.Text) = False Then
				Call showMsg("2", "DATE", CStr(0)) '●日付誤りのMSG
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			'締めを跨いでの日付はエラー
			date1 = VB6.Format(CNV_DATE(VB.Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
			date2 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, CDate(date1)))
			date3 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(date2)))
			If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
				Call showMsg("1", "URKET73_038", CStr(0)) '●締めを跨いでの日付は入力できません
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			'入金消込画面で受注日(売上日)＞入金消込日はエラー
			If IsDate(.Text) And IsDate(txt_kesidt.Text) Then
				If VB6.Format(.Text, "0000/00/00") > VB6.Format(txt_kesidt.Text, "0000/00/00") Then
					Call showMsg("2", "DATE", CStr(0)) '●日付誤りのMSG
					.ForeColor = System.Drawing.Color.Red
					GoTo END_STEP
				End If
			End If
			
			.ForeColor = System.Drawing.Color.Black
		End With
		
		chkKaidt_From = True
		
END_STEP: 
		
		gstrKaidt_Fr.Value = DeCNV_DATE((txt_kaidt_From.Text))
		intChkKb = 2 '●基本は変更時にチェック
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function chkKaidt_To
	'   概要：  回収予定日付（終了）のチェック
	'   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
	'   戻値：　True:正常  False:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkKaidt_To(Optional ByVal pin_blnChk As Boolean = False) As Boolean
		Dim date1 As String
		Dim date2 As String
		Dim date3 As String
		
		chkKaidt_To = False
		
		With txt_kaidt_To
			If pin_blnChk = False Then
				'チェック区分が1のとき、あるいは変更されていたらチェックを行う
				If intChkKb <> 1 Then
					chkKaidt_To = True
					GoTo END_STEP
				End If
				If .Text = CNV_DATE(gstrKaidt_To.Value) Then
					chkKaidt_To = True
					GoTo END_STEP
				End If
			End If
			
			'空白入力時はチェックしない（chkConditionでチェック）
			If Trim(.Text) = "" Then
				chkKaidt_To = True
				Exit Function
			End If
			
			'日付形式のチェック
			If IsDate(.Text) = False Then
				Call showMsg("2", "DATE", CStr(0)) '●日付誤りのMSG
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			'締めを跨いでの日付はエラー
			date1 = VB6.Format(CNV_DATE(VB.Left(DB_SYSTBA.SMAUPDDT, 6) & "01"), "YYYY/MM/DD")
			date2 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Month, 2, CDate(date1)))
			date3 = CStr(DateAdd(Microsoft.VisualBasic.DateInterval.Day, -1, CDate(date2)))
			If DeCNV_DATE(.Text) > DeCNV_DATE(date3) Then
				Call showMsg("1", "URKET73_038", CStr(0)) '●締めを跨いでの日付は入力できません
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			'入金消込画面で受注日(売上日)＞入金消込日はエラー
			If IsDate(.Text) And IsDate(txt_kesidt.Text) Then
				If VB6.Format(.Text, "0000/00/00") > VB6.Format(txt_kesidt.Text, "0000/00/00") Then
					Call showMsg("2", "DATE", CStr(0)) '●日付誤りのMSG
					.ForeColor = System.Drawing.Color.Red
					GoTo END_STEP
				End If
			End If
			
			'日付の大小比較
			If IsDate(txt_kaidt_From.Text) And IsDate(.Text) Then
				If VB6.Format(txt_kaidt_From.Text, "0000/00/00") > VB6.Format(.Text, "0000/00/00") Then
					Call showMsg("2", "DATE", CStr(0)) '●日付誤りのMSG
					.ForeColor = System.Drawing.Color.Red
					txt_kaidt_From.ForeColor = System.Drawing.Color.Red
					GoTo END_STEP
				Else
					'チェックエラーなし
					txt_kaidt_From.ForeColor = System.Drawing.Color.Black
				End If
			End If
			
			.ForeColor = System.Drawing.Color.Black
		End With
		
		chkKaidt_To = True
		
END_STEP: 
		
		gstrKaidt_To.Value = DeCNV_DATE((txt_kaidt_To.Text))
		intChkKb = 2 '●基本は変更時にチェック
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function chkFridt
	'   概要：  振込期日のチェック
	'   引数：  pin_blnChk : True=強制的にチェックをすべて走らせる
	'   戻値：　True:正常  False:異常
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkFridt(Optional ByVal pin_blnChk As Boolean = False) As Boolean
		chkFridt = False
		
		With txt_fridt
			If pin_blnChk = False Then
				'チェック区分が1のとき、あるいは変更されていたらチェックを行う
				If intChkKb <> 1 Then
					chkFridt = True
					GoTo END_STEP
				End If
				If .Text = CNV_DATE(gstrFridt.Value) Then
					chkFridt = True
					GoTo END_STEP
				End If
			End If
			
			'空白入力時はチェックしない（chkConditionでチェック）
			If Trim(.Text) = "" Then
				chkFridt = True
				Exit Function
			End If
			
			'日付形式のチェック
			If IsDate(.Text) = False Then
				Call showMsg("2", "DATE", CStr(0)) '●日付誤りのMSG
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			'経理締日以前の日付の時はエラー
			If DeCNV_DATE(.Text) <= DB_SYSTBA.SMAUPDDT Then
				'If DeCNV_DATE(.Text) <= DB_SYSTBA.MONUPDDT Then '月次本締日の条件撤廃
				Call showMsg("1", "URKET73_010", CStr(0)) '●経理締め済みのMSG
				.ForeColor = System.Drawing.Color.Red
				GoTo END_STEP
			End If
			
			.ForeColor = System.Drawing.Color.Black
		End With
		
		chkFridt = True
		
END_STEP: 
		
		gstrFridt.Value = DeCNV_DATE((txt_fridt.Text))
		intChkKb = 2 '●基本は変更時にチェック
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub Ctl_DTItem_Change
	'   概要：  日付項目日付変換
	'   引数：  pm_objDt      : 日付項目ｵﾌﾞｼﾞｪｸﾄ
	'   戻値：　無し
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub Ctl_DTItem_Change(ByRef pm_objDt As Object)
		
		With pm_objDt
			'スラッシュが存在しているときは、スラッシュを飛ばして次の項目へ
			'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Mid(.Text, .SelStart + 1, 1) = "/" Then
				'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.SelStart = .SelStart + 1
			End If
			'UPGRADE_WARNING: オブジェクト pm_objDt.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SelLength = 1
			
			'入力された値が８桁に到達したのでスラッシュ編集する
			'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Len(Trim(.Text)) = 8 Then
				'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.Text = VB6.Format(.Text, "0000/00/00")
				'日付の日の部分を選択状態にする
				'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.SelStart = 8
				'UPGRADE_WARNING: オブジェクト pm_objDt.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.SelLength = 1
			End If
		End With
		
	End Sub
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub Ctl_DTItem_GotFocus
	'   概要：  日付項目のカーソル位置付け
	'   引数：  pm_objDt      : 日付項目ｵﾌﾞｼﾞｪｸﾄ
	'   戻値：　無し
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Sub Ctl_DTItem_GotFocus(ByRef pm_objDt As Object)
		
		With pm_objDt
			'UPGRADE_WARNING: オブジェクト pm_objDt.ForeColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(.Text) = "" Or pm_objDt.ForeColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red) Then
				'なにも入っていないまたはエラーの時に先頭へ位置づけ
				'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.SelStart = 0
				'UPGRADE_WARNING: オブジェクト pm_objDt.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.SelLength = 1
			Else
				'なにか入っていたら日付の十の位を選択状態にする
				'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.SelStart = 8
				'UPGRADE_WARNING: オブジェクト pm_objDt.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.SelLength = 1
			End If
			'背景色を黄色にする
			'UPGRADE_WARNING: オブジェクト pm_objDt.BackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.BackColor = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
		End With
		
	End Sub
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub Ctl_DTItem_KeyDown
	'   概要：  請求先ｺｰﾄﾞキー入力制御
	'   引数：  pm_KeyCode    : キーコード
	'           pm_Shift      : シフト押下状態
	'           pm_objDt      : 請求先ｺｰﾄﾞｵﾌﾞｼﾞｪｸﾄ
	'   戻値：　0:移動無し 1:次項目 2:前項目
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_tokseicd_KeyDown(ByRef pm_KeyCode As Short, ByRef pm_Shift As Short, ByRef pm_objCD As Object) As Short
		
		Ctl_tokseicd_KeyDown = 0
		
		With pm_objCD
			
			Select Case pm_KeyCode
				
				'ファンクションキー押下時
				Case System.Windows.Forms.Keys.F1 To System.Windows.Forms.Keys.F12
					'ファンクションキー共通処理
					Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
					
					'右矢印押下時
				Case System.Windows.Forms.Keys.Right
					'UPGRADE_WARNING: オブジェクト pm_objCD.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If .SelStart < 4 Then
						'UPGRADE_WARNING: オブジェクト pm_objCD.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SelStart = .SelStart + 1
						'UPGRADE_WARNING: オブジェクト pm_objCD.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SelLength = 1
					Else
						intChkKb = 2 '★請求先ｺｰﾄﾞの入力チェック（変更時のみ）
						Ctl_tokseicd_KeyDown = 1
					End If
					
					'Backspace or 左矢印押下時
				Case System.Windows.Forms.Keys.Back, System.Windows.Forms.Keys.Left
					'UPGRADE_WARNING: オブジェクト pm_objCD.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If .SelStart > 0 Then
						'UPGRADE_WARNING: オブジェクト pm_objCD.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SelStart = .SelStart - 1
						'UPGRADE_WARNING: オブジェクト pm_objCD.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SelLength = 1
					Else
						'Backspaceの時は、入力値が空白の時、前項目へ移動
						'UPGRADE_WARNING: オブジェクト pm_objCD.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If Trim(.Text) <> "" And pm_KeyCode = System.Windows.Forms.Keys.Back Then
							Exit Function
						End If
						intChkKb = 2 '★請求先ｺｰﾄﾞの入力チェック（変更時のみ）
						Ctl_tokseicd_KeyDown = 2
					End If
					
					'上矢印押下時
				Case System.Windows.Forms.Keys.Up
					intChkKb = 2 '★請求先ｺｰﾄﾞの入力チェック（変更時のみ）
					Ctl_tokseicd_KeyDown = 2
					
					'下矢印押下時
				Case System.Windows.Forms.Keys.Down
					intChkKb = 2 '★請求先ｺｰﾄﾞの入力チェック（変更時のみ）
					Ctl_tokseicd_KeyDown = 1
					
					'Enter押下時
				Case System.Windows.Forms.Keys.Return
					intChkKb = 1 '★請求先ｺｰﾄﾞの入力チェック
					Ctl_tokseicd_KeyDown = 1
					
					'Delete押下時
				Case System.Windows.Forms.Keys.Delete
					Exit Function
					
					'TAB押
				Case System.Windows.Forms.Keys.F16
					intChkKb = 1 '★請求先ｺｰﾄﾞの入力チェック
					Ctl_tokseicd_KeyDown = 1
					
					'SHIFT+TAB押
				Case System.Windows.Forms.Keys.F15
					intChkKb = 2 '★請求先ｺｰﾄﾞの入力チェック
					Ctl_tokseicd_KeyDown = 2
					
				Case Else
					Exit Function
					
			End Select
			
		End With
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Sub Ctl_DTItem_KeyDown
	'   概要：  日付項目キー入力制御
	'   引数：  pm_KeyCode    : キーコード
	'           pm_Shift      : シフト押下状態
	'           pm_objDt      : 日付項目ｵﾌﾞｼﾞｪｸﾄ
	'   戻値：　0:移動無し 1:次項目 2:前項目
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function Ctl_DTItem_KeyDown(ByRef pm_KeyCode As Short, ByRef pm_Shift As Short, ByRef pm_objDt As Object) As Short
		
		Ctl_DTItem_KeyDown = 0
		
		'UPGRADE_NOTE: str は str_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
		Dim str_Renamed As String
		With pm_objDt
			
			Select Case pm_KeyCode
				
				'ファンクションキー押下時
				Case System.Windows.Forms.Keys.F1 To System.Windows.Forms.Keys.F12
					'ファンクションキー共通処理
					Call CF_FuncKey_Execute(pm_KeyCode, pm_Shift)
					
					'右矢印 or Space押下時
				Case System.Windows.Forms.Keys.Right, System.Windows.Forms.Keys.Space
					
					'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If .SelStart < 9 Then
						'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SelStart = .SelStart + 1
						'スラッシュにカーソルがきたら次の文字にカーソルを移動
						'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If .SelStart = 4 And Mid(.Text, .SelStart + 1, 1) = "/" Or .SelStart = 7 And Mid(.Text, .SelStart + 1, 1) = "/" Then
							'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							.SelStart = .SelStart + 1
						End If
						'カーソルが右端に来たら次の項目へ移動
					Else
						intChkKb = 2 '★日付の入力チェック（変更時のみ)
						Ctl_DTItem_KeyDown = 1
					End If
					'UPGRADE_WARNING: オブジェクト pm_objDt.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.SelLength = 1
					
					'Backspace or 左矢印押下時
				Case System.Windows.Forms.Keys.Back, System.Windows.Forms.Keys.Left
					
					'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If .SelStart > 0 Then
						'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SelStart = .SelStart - 1
						'スラッシュにカーソルがきたら前の文字にカーソルを移動
						'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If .SelStart = 4 And Mid(.Text, .SelStart + 1, 1) = "/" Or .SelStart = 7 And Mid(.Text, .SelStart + 1, 1) = "/" Then
							'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							.SelStart = .SelStart - 1
						End If
						
						'カーソルが左端に来たら前の項目へ移動
					Else
						intChkKb = 2 '★日付の入力チェック（変更時のみ)
						Ctl_DTItem_KeyDown = 2
					End If
					'UPGRADE_WARNING: オブジェクト pm_objDt.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.SelLength = 1
					
					'上矢印押下時
				Case System.Windows.Forms.Keys.Up
					intChkKb = 2 '★日付の入力チェック（変更時のみ)
					Ctl_DTItem_KeyDown = 2
					
					'下矢印押下時
				Case System.Windows.Forms.Keys.Down
					intChkKb = 2 '★日付の入力チェック（変更時のみ)
					Ctl_DTItem_KeyDown = 1
					
					'Enter押下時
				Case System.Windows.Forms.Keys.Return
					intChkKb = 1 '★日付の入力チェック
					Ctl_DTItem_KeyDown = 1
					
					'TAB押
				Case System.Windows.Forms.Keys.F16
					intChkKb = 1 '★日付の入力チェック
					Ctl_DTItem_KeyDown = 1
					
					'Shift+TAB押
				Case System.Windows.Forms.Keys.F15
					intChkKb = 2 '★日付の入力チェック（変更時のみ)
					Ctl_DTItem_KeyDown = 2
					
					'Shift+DELETE押
				Case System.Windows.Forms.Keys.Delete And pm_Shift = 1
					'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					str_Renamed = .Text
					'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Len(str_Renamed) > 0 And .SelStart < Len(str_Renamed) Then
						'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						str_Renamed = Mid(str_Renamed, 1, .SelStart) & Mid(str_Renamed, .SelStart + 2)
						str_Renamed = Replace(str_Renamed, "/", "")
						'UPGRADE_WARNING: オブジェクト pm_objDt.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.SelStart = 0
						If Len(str_Renamed) > 0 Then
							'UPGRADE_WARNING: オブジェクト pm_objDt.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							.SelLength = 1
						End If
					End If
					'UPGRADE_WARNING: オブジェクト pm_objDt.Text の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Text = str_Renamed
					
			End Select
			
		End With
		
	End Function
	
	
	'=======================================================回収予定日(開始)=======================================================
	
	'回収予定日クリック時
	Private Sub txt_kaidt_From_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.Click
		
		txt_kaidt_From.SelectionStart = 0
		txt_kaidt_From.SelectionLength = 1
		
	End Sub
	
	'回収予定日項目を変更した時
	'UPGRADE_WARNING: イベント txt_kaidt_From.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub txt_kaidt_From_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.TextChanged
		
		'日付変換処理
		Call Ctl_DTItem_Change(txt_kaidt_From)
		
	End Sub
	
	'回収予定日項目にフォーカスが移った時
	Private Sub txt_kaidt_From_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.Enter
		
		'カーソル位置付け
		Call Ctl_DTItem_GotFocus(txt_kaidt_From)
		
		'検索処理を実行可能とする
		mnu_showwnd.Enabled = True
		
	End Sub
	
	'回収予定日項目でキーを押した時
	Private Sub txt_kaidt_From_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kaidt_From.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		'キー入力制御
		Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kaidt_From)
			Case 0
				'何もしない
			Case 1
				'入力チェック
				If chkKaidt_From = True Then
					'次項目
					txt_kaidt_To.Focus()
				End If
			Case 2
				'入力チェック
				If chkKaidt_From = True Then
					'前項目
					txt_tokseicd.Focus()
				End If
		End Select
		
		KeyCode = 0
		
	End Sub
	
	'回収予定日項目でキーを押した時
	Private Sub txt_kaidt_From_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kaidt_From.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		'数値のみ入力可とする
		If Not Chr(KeyAscii) Like "[0-9]" Then
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'回収予定日項目からフォーカスが移った時
	Private Sub txt_kaidt_From_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_From.Leave
		
		'背景色を白に戻す
		txt_kaidt_From.BackColor = System.Drawing.Color.White
		
	End Sub
	
	'=======================================================回収予定日(終了)=======================================================
	
	'回収予定日クリック時
	Private Sub txt_kaidt_To_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.Click
		
		txt_kaidt_To.SelectionStart = 0
		txt_kaidt_To.SelectionLength = 1
		
	End Sub
	
	'回収予定日項目を変更した時
	'UPGRADE_WARNING: イベント txt_kaidt_To.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub txt_kaidt_To_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.TextChanged
		
		'日付変換処理
		Call Ctl_DTItem_Change(txt_kaidt_To)
		
	End Sub
	
	'回収予定日項目にフォーカスが移った時
	Private Sub txt_kaidt_To_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.Enter
		
		'カーソル位置付け
		Call Ctl_DTItem_GotFocus(txt_kaidt_To)
		
		'検索処理を実行可能とする
		mnu_showwnd.Enabled = True
		
	End Sub
	
	'回収予定日項目でキーを押した時
	Private Sub txt_kaidt_To_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kaidt_To.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		'キー入力制御
		Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kaidt_To)
			Case 0
				'何もしない
			Case 1
				'入力チェック
				If chkKaidt_To = True Then
					'次項目
					txt_kesikb.Focus()
				End If
			Case 2
				'入力チェック
				If chkKaidt_To = True Then
					'前項目
					txt_kaidt_From.Focus()
				End If
		End Select
		
		KeyCode = 0
		
	End Sub
	
	'回収予定日項目でキーを押した時
	Private Sub txt_kaidt_To_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kaidt_To.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		'数値のみ入力可とする
		If Not Chr(KeyAscii) Like "[0-9]" Then
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'回収予定日項目からフォーカスが移った時
	Private Sub txt_kaidt_To_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kaidt_To.Leave
		
		'背景色を白に戻す
		txt_kaidt_To.BackColor = System.Drawing.Color.White
		
	End Sub
	
	'=======================================================消込日=======================================================
	
	'消込日項目クリック時
	Private Sub txt_kesidt_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.Click
		
		txt_kesidt.SelectionStart = 0
		txt_kesidt.SelectionLength = 1
		
	End Sub
	
	'消込日項目を変更した時
	'UPGRADE_WARNING: イベント txt_kesidt.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub txt_kesidt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.TextChanged
		
		'日付変換処理
		Call Ctl_DTItem_Change(txt_kesidt)
		
	End Sub
	
	'消込日項目にフォーカスが移った時
	Private Sub txt_kesidt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.Enter
		
		intInputMode = 1
		
		'カーソル位置付け
		Call Ctl_DTItem_GotFocus(txt_kesidt)
		
		'検索処理を実行可能とする
		mnu_showwnd.Enabled = True
		
	End Sub
	
	'消込日項目でキーを押した時
	Private Sub txt_kesidt_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_kesidt.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		intChkKb = 0
		
		'キー入力制御
		Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_kesidt)
			Case 0
				'何もしない
			Case 1
				'入力チェック
				If chkKesidt = True Then
					'次項目
					txt_tokseicd.Focus()
				End If
			Case 2
				'入力チェック
				If chkKesidt = True Then
					'前項目
					txt_kesidt.Focus()
				End If
		End Select
		
		KeyCode = 0
		
	End Sub
	
	'消込日項目でキーを押した時
	Private Sub txt_kesidt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_kesidt.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		'数値のみ入力可とする
		If Not Chr(KeyAscii) Like "[0-9]" Then
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'消込日項目からフォーカスが移った時
	Private Sub txt_kesidt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_kesidt.Leave
		
		'背景色を白に戻す
		txt_kesidt.BackColor = System.Drawing.Color.White
		
	End Sub
	
	'=======================================================振込期日=======================================================
	
	'振込期日項目を変更した時
	'UPGRADE_WARNING: イベント txt_fridt.TextChanged は、フォームが初期化されたときに発生します。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"' をクリックしてください。
	Private Sub txt_fridt_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_fridt.TextChanged
		
		'ﾌﾗｸﾞがたっていない時はｲﾍﾞﾝﾄを実行させない
		If blnUsableEvent = False Then
			Exit Sub
		End If
		
		'日付変換処理
		Call Ctl_DTItem_Change(txt_fridt)
		
		blnUsableEvent = True
		
	End Sub
	
	'振込期日項目にフォーカスが移った時
	Private Sub txt_fridt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_fridt.Enter
		
		'カーソル位置付け
		Call Ctl_DTItem_GotFocus(txt_fridt)
		
		'検索処理を実行可能とする
		mnu_showwnd.Enabled = True
		
	End Sub
	
	'振込期日項目でキーを押した時
	Private Sub txt_fridt_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_fridt.KeyDown
		Dim KeyCode As Short = eventArgs.KeyCode
		Dim Shift As Short = eventArgs.KeyData \ &H10000
		
		'キー入力制御
		Select Case Ctl_DTItem_KeyDown(KeyCode, Shift, txt_fridt)
			Case 0
				'何もしない
			Case 1
				'入力チェック
				If chkFridt = True Then
					'次項目
					'UPGRADE_WARNING: オブジェクト spd_body.SetFocus の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					spd_body.SetFocus()
				End If
			Case 2
				'入力チェック
				If chkFridt = True Then
					'前項目
					txt_kesikb.Focus()
				End If
		End Select
		
		KeyCode = 0
		
	End Sub
	
	'振込期日項目でキーを押した時
	Private Sub txt_fridt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt_fridt.KeyPress
		Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
		
		'数値のみ入力可とする
		If Not Chr(KeyAscii) Like "[0-9]" Then
			KeyAscii = 0
		End If
		
		eventArgs.KeyChar = Chr(KeyAscii)
		If KeyAscii = 0 Then
			eventArgs.Handled = True
		End If
	End Sub
	
	'振込期日項目からフォーカスが移った時
	Private Sub txt_fridt_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt_fridt.Leave
		
		'背景色を白に戻す
		txt_fridt.BackColor = System.Drawing.Color.White
		
	End Sub
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_FuncKey_Execute
	'   概要：  システム共通処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function CF_FuncKey_Execute(ByVal pm_KeyCode As Short, ByVal pm_Shift As Short) As Short
		
		CF_FuncKey_Execute = 0
		
		Select Case True
			'F1キー押下
			Case pm_KeyCode = System.Windows.Forms.Keys.F1 And pm_Shift = 0
				System.Windows.Forms.SendKeys.Send("%1")
				
				'F2キー押下
			Case pm_KeyCode = System.Windows.Forms.Keys.F2 And pm_Shift = 0
				System.Windows.Forms.SendKeys.Send("%2")
				
				'F3キー押下
			Case pm_KeyCode = System.Windows.Forms.Keys.F3 And pm_Shift = 0
				System.Windows.Forms.SendKeys.Send("%3")
		End Select
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_System_Process
	'   概要：  システム共通処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function CF_System_Process(ByRef pm_Form As System.Windows.Forms.Form) As Short
		
		
		'パッケージ内のＤＬＬにて
		'｢ＴＡＢ｣＆｢ＴＡＢ＋ＳＨＩＦＴ｣をそれぞれ｢Ｆ１６｣＆｢Ｆ１５｣に割当
		ReleaseTabCapture(0)
		SetTabCapture(pm_Form.Handle.ToInt32)
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Sub chkFurikomiDT
	'   概要： TOKMTA.SHAKB（支払条件）に手形が入っている場合は振込期日が必須
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function chkFurikomiDT() As Boolean
		
		Dim idxRow As Integer
		Dim tmp As Object
		Dim intchk As Short
		Dim strHYFRIDT As String
		
		chkFurikomiDT = False
		
		If blnFriEnabled = False Then
			chkFurikomiDT = True
			Exit Function
		End If
		
		'返品を検索
		With spd_body
			For idxRow = 1 To intMaxRow
				'チェックが入っているかを確認
				'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.GetText(COL_CHK, idxRow, tmp)
				'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				intchk = SSSVal(tmp)
				
				'チェックが入っている場合
				If intchk = 1 Then
					'売上日の取得
					'UPGRADE_WARNING: オブジェクト spd_body.GetText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call .GetText(COL_HYFRIDT, idxRow, tmp)
					'UPGRADE_WARNING: オブジェクト tmp の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strHYFRIDT = CStr(tmp)
					
					If Trim(strHYFRIDT) = "" Then
						Call showMsg("0", "_COMPLETEC", CStr(0)) '●入力されていない項目があります。入力してください。
						Exit Function
					End If
				End If
			Next idxRow
		End With
		
		chkFurikomiDT = True
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称： Function chk_HENPIN
	'   概要： 未来に返品が発生しているかチェックする
	'   引数： strJdnNo   : 受注伝票番号
	'   　　： strJdnlinNo: 受注伝票行番号
	'       :  strUrikn   : 売上金額
	'   戻値： チェック結果
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function chkHenpin2(ByVal strJdnno As String, ByVal strJdnlinno As String, ByVal strUDNDT As String) As Boolean
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo ERR_chkHENPIN2
		
		'//表示します
		chkHenpin2 = True
		
		If Trim(gstrKaidt_Fr.Value) = "" Then
			'//表示します
			GoTo END_chkHENPIN2
		End If
		
		'//未来に返品データが存在しているか確認する
		strSql = " "
		strSql = " SELECT *"
		strSql = strSql & " FROM    UDNTRA"
		strSql = strSql & " WHERE   JDNNO    =  '" & strJdnno & "'"
		strSql = strSql & " AND     JDNLINNO =  '" & strJdnlinno & "'"
		strSql = strSql & " AND     DATKB =  '1'"
		strSql = strSql & " AND     AKAKROKB =  '9'"
		strSql = strSql & " AND     DKBID    =  '02'"
		strSql = strSql & " AND     UDNDT    >= '" & gstrKaidt_Fr.Value & "'"
		strSql = strSql & " AND     UDNDT    <= '" & gstrKaidt_To.Value & "'"
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'データが存在した場合
		If CF_Ora_EOF(Usr_Ody) = False Then
			
			Select Case txt_kesikb.Text
				Case CStr(1)
					'消込されていない場合、処理を行う
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Trim(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) = "9" Then
						'//表示します
						GoTo END_chkHENPIN2
					Else
						'//表示しません
						chkHenpin2 = False
						GoTo END_chkHENPIN2
					End If
				Case CStr(9)
					'消込されていない場合、処理を行う
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Trim(CF_Ora_GetDyn(Usr_Ody, "KESIKB", "")) = "1" Then
						'//表示します
						GoTo END_chkHENPIN2
					Else
						'//表示しません
						chkHenpin2 = False
						GoTo END_chkHENPIN2
					End If
			End Select
			
			'//表示します
			GoTo END_chkHENPIN2
			
		End If
		
		'データが存在しなかった場合
		If Trim(strUDNDT) < Trim(gstrKaidt_Fr.Value) Then
			'//表示しません
			chkHenpin2 = False
			GoTo END_chkHENPIN2
		End If
		
END_chkHENPIN2: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_chkHENPIN2: 
		GoTo END_chkHENPIN2
		
	End Function
	
	
	'振込期日の入力可能判断
	Private Sub getInputHYFRIDT(ByVal pin_strTOKCD As String, ByVal pin_strSMADT As String, ByVal pin_strSHAKB As String)
		
		Dim strSql As Object
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		
		Dim curNYUKIN1 As Short
		Dim curNYUKIN2 As Short
		
		'消込日月度の消込状態を取得
		'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = ""
		'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & " SELECT * "
		'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "   FROM NKSSMB "
		'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "  WHERE TOKCD = '" & CF_Ora_Sgl(pin_strTOKCD) & "' "
		'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSql = strSql & "    AND SMADT = '" & CF_Ora_Sgl(DeCNV_DATE(pin_strSMADT)) & "' "
		
		'UPGRADE_WARNING: オブジェクト strSql の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		'振込期日を入力できるかどうかのフラグを設定する
		blnFriEnabled = False
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKZANKN02, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN02", "")) <> 0 Then
				blnFriEnabled = True
				GoTo END_getInputHYFRIDT
			End If
			'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, SSANYUKN02, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN02", "")) <> 0 Then
				blnFriEnabled = True
				GoTo END_getInputHYFRIDT
			End If
			'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKNYKKN02, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN02", "")) <> 0 Then
				blnFriEnabled = True
				GoTo END_getInputHYFRIDT
			End If
			'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKZANKN07, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKZANKN07", "")) <> 0 Then
				blnFriEnabled = True
				GoTo END_getInputHYFRIDT
			End If
			'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, SSANYUKN07, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SSSVal(CF_Ora_GetDyn(Usr_Ody, "SSANYUKN07", "")) <> 0 Then
				blnFriEnabled = True
				GoTo END_getInputHYFRIDT
			End If
			'UPGRADE_WARNING: オブジェクト SSSVal(CF_Ora_GetDyn(Usr_Ody, KSKNYKKN07, )) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SSSVal(CF_Ora_GetDyn(Usr_Ody, "KSKNYKKN07", "")) <> 0 Then
				blnFriEnabled = True
				GoTo END_getInputHYFRIDT
			End If
		End If
		
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		
END_getInputHYFRIDT: 
		
		Call CF_Ora_CloseDyn(Usr_Ody)
		
	End Sub
	
	'売上トラン・入金レコード(DENKB=8)の排他用データ取得
	Private Sub getUdntraNyukn(ByVal strJdnno As String, ByVal strJdnlinno As String)
		
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		Dim intCnt As Short
		
		Dim strJdntrkb As String
		Dim strOkrjono As String '送り状№
		
		'*** 2009/08/26 ADD START FKS)NAKATA v1.02
		Dim i As Short
		Dim BlnFlg As Boolean '2度読み用フラグ
		'*** 2009/08/26 ADD E.N.D FKS)NAKATA v1.02
		
		
		On Error GoTo ERR_UdntraNyukn
		
		
		'二度読み用フラグ初期化
		BlnFlg = False
		
		
		''受注番号より送り状№を取得する。
		strOkrjono = getOKRJONO(strJdnno, strJdnlinno)
		
		
		'売上トランの最新の入金レコードを取得
		strSql = " "
		strSql = strSql & " SELECT   DATNO"
		strSql = strSql & "         ,LINNO"
		strSql = strSql & "         ,UDNNO"
		strSql = strSql & "         ,OKRJONO"
		strSql = strSql & "         ,NYUKN"
		strSql = strSql & "         ,DKBID"
		strSql = strSql & "         ,UPDID"
		strSql = strSql & "         ,OPEID"
		strSql = strSql & "         ,OPEID"
		strSql = strSql & "         ,CLTID"
		strSql = strSql & "         ,WRTDT"
		strSql = strSql & "         ,WRTTM"
		strSql = strSql & "         ,UOPEID"
		strSql = strSql & "         ,UCLTID"
		strSql = strSql & "         ,UWRTDT"
		strSql = strSql & "         ,UWRTTM"
		strSql = strSql & " FROM UDNTRA"
		strSql = strSql & "  WHERE (DATNO , UDNNO , UPDID) IN"
		strSql = strSql & " (   SELECT  MAX(DATNO)"
		strSql = strSql & "             ,UDNNO"
		strSql = strSql & "             ,UPDID"
		strSql = strSql & "      FROM   UDNTRA"
		strSql = strSql & "      WHERE  DATKB = '1'"
		strSql = strSql & "       AND   DENKB = '8'"
		strSql = strSql & "       AND   OKRJONO = '" & strOkrjono & "'"
		strSql = strSql & "      GROUP BY UDNNO, UPDID"
		strSql = strSql & " )"
		strSql = strSql & "   AND   DATKB   =   '1'"
		strSql = strSql & "   AND   AKAKROKB =   '1'"
		strSql = strSql & "   AND   DENKB = '8'"
		strSql = strSql & "   AND   OKRJONO = '" & strOkrjono & "'"
		
		
		'ﾃﾞｰﾀ取得
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		Do While CF_Ora_EOF(Usr_Ody) = False
			
			ReDim Preserve ARY_UDNTRA_NYU_HAITA(ARY_UDNTRA_NYU_CNT)
			
			With ARY_UDNTRA_NYU_HAITA(ARY_UDNTRA_NYU_CNT)
				
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.DATNO = CStr(CF_Ora_GetDyn(Usr_Ody, "DATNO", ""))
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.LINNO = CStr(CF_Ora_GetDyn(Usr_Ody, "LINNO", ""))
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.UDNNO = CStr(CF_Ora_GetDyn(Usr_Ody, "UDNNO", ""))
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.OKRJONO = CStr(CF_Ora_GetDyn(Usr_Ody, "OKRJONO", ""))
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.OPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "OPEID", ""))
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.CLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "CLTID", ""))
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.WRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTDT", ""))
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.WRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "WRTTM", ""))
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.UOPEID = CStr(CF_Ora_GetDyn(Usr_Ody, "UOPEID", ""))
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.UCLTID = CStr(CF_Ora_GetDyn(Usr_Ody, "UCLTID", ""))
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.UWRTDT = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", ""))
				'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				.UWRTTM = CStr(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", ""))
				
			End With
			
			ARY_UDNTRA_NYU_CNT = ARY_UDNTRA_NYU_CNT + 1
			
			'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Usr_Ody.Obj_Ody.MoveNext()
			
		Loop 
		Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
		
		
		
		For i = 0 To UBound(ARY_NYUKN_KS)
			'二度読み回避変数と送り状№が同じ場合は、データの取得を行わない。
			If strOkrjono = ARY_NYUKN_KS(i).OKRJONO Then
				BlnFlg = True
				Exit For
			End If
		Next i
		
		If BlnFlg = False Then
			
			
			'入金消込トラン・売上トラン．入金レコードより、入金額の残額を取得する。
			
			strSql = " " & vbCrLf
			strSql = strSql & " SELECT UDN.SEQ  AS SEQ" & vbCrLf
			strSql = strSql & "      , UDN.NYUKN - NVL(NKS.JKESIKN,0) AS ZANKN" & vbCrLf
			strSql = strSql & "      , UDN.DKBID AS DKBID" & vbCrLf
			strSql = strSql & "      , UDN.UPDID AS UPDID" & vbCrLf
			strSql = strSql & "      , UDN.NYUKB AS NYUKB" & vbCrLf
			'*** 2009/10/09 ADD START FKS)NAKATA
			strSql = strSql & "      , UDN.UDNDT AS UDNDT" & vbCrLf
			'*** 2009/10/09 ADD E.N.D FKS)NAKATA
			strSql = strSql & " FROM" & vbCrLf
			strSql = strSql & "    (" & vbCrLf
			strSql = strSql & "         SELECT  SUM(JKESIKN) AS JKESIKN" & vbCrLf
			strSql = strSql & "             ,   DKBID AS DKBID" & vbCrLf
			strSql = strSql & "             ,   UPDID AS UPDID" & vbCrLf
			strSql = strSql & "           FROM   NKSTRA" & vbCrLf
			strSql = strSql & "          WHERE   DATKB     = '1'" & vbCrLf
			strSql = strSql & "            AND   AKAKROKB  = '1'" & vbCrLf
			strSql = strSql & "            AND   JDNNO     = '" & Trim(strJdnno) & "'" & vbCrLf
			strSql = strSql & "            AND   JDNLINNO  = '" & Trim(strJdnlinno) & "'" & vbCrLf
			strSql = strSql & "            AND KDNNO NOT IN" & vbCrLf
			strSql = strSql & "                (" & vbCrLf
			strSql = strSql & "                 SELECT  MOTKDNNO" & vbCrLf
			strSql = strSql & "                   FROM  NKSTRA" & vbCrLf
			strSql = strSql & "                  WHERE  JDNNO     = '" & Trim(strJdnno) & "'" & vbCrLf
			strSql = strSql & "                    AND  JDNLINNO  = '" & Trim(strJdnlinno) & "'" & vbCrLf
			strSql = strSql & "                    AND  TRIM(MOTKDNNO) IS NOT NULL" & vbCrLf
			strSql = strSql & "                 )" & vbCrLf
			strSql = strSql & "         GROUP BY DKBID , UPDID" & vbCrLf
			strSql = strSql & "    ) NKS" & vbCrLf
			strSql = strSql & "    ," & vbCrLf
			strSql = strSql & "    (" & vbCrLf
			strSql = strSql & "          SELECT  SUM(NYUKN) AS NYUKN" & vbCrLf
			strSql = strSql & "          ,   CASE    WHEN   DKBID = '01' THEN  '4'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '02' THEN  '5'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '03' THEN  '6'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '04' THEN  '1'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '05' THEN  '8'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '06' THEN  '3'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '07' THEN  '9'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '08' THEN  '7'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '09' THEN  '-1'" & vbCrLf
			strSql = strSql & "                      WHEN   DKBID = '99' THEN  '2'" & vbCrLf
			strSql = strSql & "              END AS SEQ" & vbCrLf
			strSql = strSql & "          ,   DKBID" & vbCrLf
			strSql = strSql & "          ,   UPDID" & vbCrLf
			strSql = strSql & "          ,   MAX(TEGDT) AS TEGDT" & vbCrLf
			strSql = strSql & "          ,   NYUKB" & vbCrLf
			'*** 2009/10/09 ADD START FKS)NAKATA
			strSql = strSql & "          ,   MAX(TRA.UDNDT) AS UDNDT" & vbCrLf
			'*** 2009/10/09 ADD E.N.D FKS)NAKATA
			strSql = strSql & "        FROM  UDNTRA TRA" & vbCrLf
			strSql = strSql & "             ,UDNTHA THA" & vbCrLf
			strSql = strSql & "       WHERE  TRA.DENKB    =   '8'" & vbCrLf
			strSql = strSql & "         AND  TRA.DATKB    =   '1'" & vbCrLf
			strSql = strSql & "         AND  TRA.AKAKROKB =   '1'" & vbCrLf
			strSql = strSql & "         AND  TRA.KESIKB   =   '9'" & vbCrLf
			strSql = strSql & "         AND  TRA.DKBID   !=  '09'" & vbCrLf
			strSql = strSql & "         AND  TRA.OKRJONO  =   '" & strOkrjono & "'" & vbCrLf
			strSql = strSql & "         AND  TRA.DATNO    =   THA.DATNO" & vbCrLf
			strSql = strSql & "         AND  THA.NYUCD    = '2'" & vbCrLf
			strSql = strSql & "         AND  THA.FRNKB    = '0'" & vbCrLf
			strSql = strSql & "         AND  TRA.DATNO IN" & vbCrLf
			strSql = strSql & "            ( SELECT MAX(DATNO)" & vbCrLf
			strSql = strSql & "                FROM  UDNTRA" & vbCrLf
			strSql = strSql & "               WHERE  DENKB    =  '8'" & vbCrLf
			strSql = strSql & "                 AND  DATKB    =  '1'" & vbCrLf
			strSql = strSql & "                 AND  DKBID   !=  '09'" & vbCrLf
			strSql = strSql & "                 AND  OKRJONO  =  '" & strOkrjono & "'" & vbCrLf
			strSql = strSql & "            )" & vbCrLf
			strSql = strSql & "       GROUP BY DKBID ,UPDID ,TEGDT ,NYUKB" & vbCrLf
			strSql = strSql & "       ORDER BY SEQ" & vbCrLf
			strSql = strSql & "    )UDN" & vbCrLf
			strSql = strSql & " WHERE  NKS.UPDID(+) = UDN.UPDID" & vbCrLf
			strSql = strSql & "   AND    NKS.DKBID(+) = UDN.DKBID" & vbCrLf
			strSql = strSql & " ORDER BY UDN.SEQ"
			
			
			'ﾃﾞｰﾀ取得
			Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
			
			Do While CF_Ora_EOF(Usr_Ody) = False
				
				
				ReDim Preserve ARY_NYUKN_KS(ARY_NYUKN_KS_CNT)
				
				With ARY_NYUKN_KS(ARY_NYUKN_KS_CNT)
					
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.SEQ = SSSVal(CF_Ora_GetDyn(Usr_Ody, "SEQ", ""))
					'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.ZANKN = SSSVal(CF_Ora_GetDyn(Usr_Ody, "ZANKN", ""))
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.DKBID = VB6.Format(CStr(CF_Ora_GetDyn(Usr_Ody, "DKBID", "")), "00")
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.UPDID = VB6.Format(CStr(CF_Ora_GetDyn(Usr_Ody, "UPDID", "")), "00")
					'**** 2009/09/16 ADD START FKS)NAKATA
					'入金区分
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.NYUKB = CF_Ora_GetDyn(Usr_Ody, "NYUKB", "")
					'**** 2009/09/16 ADD E.N.D FKS)NAKATA
					'**** 2009/10/09 ADD START FKS)NAKATA
					'売上日(入金日)
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.UDNDT = CF_Ora_GetDyn(Usr_Ody, "UDNDT", "")
					'**** 2009/10/09 ADD E.N.D FKS)NAKATA
					.OKRJONO = strOkrjono
					
				End With
				
				ARY_NYUKN_KS_CNT = ARY_NYUKN_KS_CNT + 1
				
				'UPGRADE_WARNING: オブジェクト Usr_Ody.Obj_Ody.MoveNext の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Usr_Ody.Obj_Ody.MoveNext()
				
			Loop 
			Call CF_Ora_CloseDyn(Usr_Ody) 'ﾃﾞｰﾀｾｯﾄｸﾛｰｽﾞ
			
		End If
		
		
END_UdntraNyukn: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Sub
		
ERR_UdntraNyukn: 
		Call SSSWIN_LOGWRT("getUdntraNyukn_ERROR")
		GoTo END_UdntraNyukn
		
	End Sub
	
	'2009/09/07 ADD START FKS)NAKATA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Util_GET_TANMTA_TANCLAKB
	'   概要：  営業担当フラグを取得
	'   引数：　pot_strTANCD       : 担当者コード
	'       ：　pot_strKEIBMNCD    : 営業担当フラグ
	'   戻値：　0:正常終了 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Util_GET_TANMTA_TANCLAKB(ByRef pot_strTANCD As String, ByRef pot_strTANCLAKB As String) As Short
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSql As String
		
		On Error GoTo ERR_F_Util_GET_TANMTA_TANCLAKB
		
		F_Util_GET_TANMTA_TANCLAKB = 9
		
		pot_strTANCLAKB = ""
		
		'担当者Ｍ
		strSql = ""
		strSql = strSql & " SELECT TANCLAKB "
		strSql = strSql & " FROM TANMTA "
		strSql = strSql & " WHERE TANCD = '" & pot_strTANCD & "' "
		
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSql)
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_strTANCLAKB = CF_Ora_GetDyn(Usr_Ody, "TANCLAKB", "")
		Else
			GoTo END_F_Util_GET_TANMTA_TANCLAKB
		End If
		
		F_Util_GET_TANMTA_TANCLAKB = 0
		
END_F_Util_GET_TANMTA_TANCLAKB: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_F_Util_GET_TANMTA_TANCLAKB: 
		GoTo END_F_Util_GET_TANMTA_TANCLAKB
		
	End Function
	'2009/09/07 ADD E.N.D FKS)NAKATA
End Class