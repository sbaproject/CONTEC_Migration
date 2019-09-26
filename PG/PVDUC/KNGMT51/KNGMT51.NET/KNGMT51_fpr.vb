Option Strict Off
Option Explicit On
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	
	'単プロジェクトごとの共通ライブラリ
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(92 + 6 + 0 + 1) As clsCP
	Public CL_SSSMAIN(92) As Short
	Public CQ_SSSMAIN(8) As String
	
	'□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
	'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
	'初期処理時チェック実行フラグ
	Public gv_bolInit As Boolean '初期処理時はTrue(チェックなし）　それ以外はFalse
	Public gv_bolKNGMT51_INIT As Boolean '画面初期化フラグ（True:変更あり）
	' === 20060801 === INSERT S - エンターキー連打による不具合修正・検索W表示時の不具合対応
	Public gv_bolKNGMT51_LF_Enable As Boolean 'LF処理実行フラグ(False：実行しない)
	Public gv_bolKeyFlg As Boolean
	' === 20060801 === INSERT E
	' === 20060808 === INSERT S - エンターキー連打による不具合修正２
	Public gv_bolUpdFlg As Boolean
	' === 20060808 === INSERT E
	Public gv_bolMeiErrFlg As Boolean '名称マスタと結びつくデータがないエラー
	
	Public Structure KNGMT51_TYPE_KNGMTB
		Dim UPDKB As String 'モード
		Dim DATKB As String '削除区分
		Dim KNGGRCD As String '権限グループ
		Dim PGID As String 'プログラムＩＤ
		Dim MEINMA As String 'プログラム名
		Dim UPDFLG As String '更新権限変更可能フラグ
		Dim UPDAUTH As String '更新権限
		Dim PRTFLG As String '印刷権限変更可能フラグ
		Dim PRTAUTH As String '印刷権限
		Dim FILEFLG As String 'ファイル出力権限変更可能フラグ
		Dim FILEAUTH As String 'ファイル出力権限
		Dim SALTFLG As String '販売単価変更権限変更可能フラグ
		Dim SALTAUTH As String '販売単価変更権限
		Dim HDNTFLG As String '発注単価変更権限変更可能フラグ
		Dim HDNTAUTH As String '発注単価変更権限
		Dim SAPMFLG As String '販売計画年初計画修正権限変更可能フラグ
		Dim SAPMAUTH As String '販売計画年初計画修正権限
		' 2006/11/15  ADD START  KUMEDA
		Dim UPDATE As String '更新フラグ
		' 2006/11/15  ADD END
	End Structure
	'権限マスタ情報
	Public KNGMT51_KNGMTB_Inf As KNGMT51_TYPE_KNGMTB
	
	'ページ情報
	Public MaxPageNum As Short '明細の最大ページ数
	Public NowPageNum As Short '明細の現在のページ数
	Public MinPageNum As Short '明細の最小ページ数
	
	'権限グループ
	Public pv_KNGMT51_KNGGRCD As String
	
	'入力者権限
	Public pv_InpTan_KNG As Boolean 'True:権限あり False:権限なし
	
	'モード
	Public Const UPDKB_INS As String = "追加"
	Public Const UPDKB_UPD As String = "更新"
	Public Const UPDKB_DEL As String = "削除"
	
	'列番号
	Private Const pc_COL_UPDKB As Short = 1 'モード
	Private Const pc_COL_PGID As Short = 2 'プログラムＩＤ
	Private Const pc_COL_MEINMA As Short = 3 'プログラム名
	' 2006/11/21  CHG START  KUMEDA
	'Private Const pc_COL_UPDAUTH        As Integer = 4      '更新
	'Private Const pc_COL_PRTAUTH        As Integer = 5      '印刷
	'Private Const pc_COL_FILEAUTH       As Integer = 6      'ファイル出力
	'Private Const pc_COL_SALTAUTH       As Integer = 7      '販売単価変更
	'Private Const pc_COL_HDNTAUTH       As Integer = 8      '発注単価変更
	'Private Const pc_COL_SAPMAUTH       As Integer = 9      '販売計画年初計画修正
	'Private Const pc_COL_UPDATE         As Integer = 10     '更新フラグ
	Private Const pc_COL_DATKB As Short = 4 '起動
	Private Const pc_COL_UPDAUTH As Short = 5 '更新
	Private Const pc_COL_PRTAUTH As Short = 6 '印刷
	Private Const pc_COL_FILEAUTH As Short = 7 'ファイル出力
	Private Const pc_COL_SALTAUTH As Short = 8 '販売単価変更
	Private Const pc_COL_HDNTAUTH As Short = 9 '発注単価変更
	Private Const pc_COL_SAPMAUTH As Short = 10 '販売計画年初計画修正
	Private Const pc_COL_UPDATE As Short = 11 '更新フラグ
	' 2006/11/21  CHG END
	'
	Private pv_bolMEISAI_INPUT As Boolean '明細入力フラグ(True:入力あり）
	Private pv_intMeisaiCnt As Short '入力明細数（更新時使用）
	Private pv_bolInput_Bef_Row As Boolean '前行入力フラグ（True:入力済）
	
	'入力値
	Private Const pv_POS As String = "1" '可
	Private Const pv_INPOS As String = "9" '不可
	
	'
	Private Const pv_Pgid_Keycode As String = "068" '名称マスタのプログラムIDコード
	'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
	
	''**ﾁｪｯｸ関数関連 Start **
	'//戻値
	Public Const CHK_OK As Short = 0 '正常
	Public Const CHK_WARN As Short = 1 '警告
	Public Const CHK_ERR_NOT_INPUT As Short = 10 '未入力エラー
	Public Const CHK_ERR_ELSE As Short = 11 'その他エラー
	
	'F_Chk_Jge_Action関数用
	Public Const CHK_KEEP As Short = 0 'チェック続行
	Public Const CHK_STOP As Short = 1 'チェック中断
	
	'**ﾁｪｯｸ関数関連 End  **
	
	'//F_Set_Next_Focus処理モード
	Public Const NEXT_FOCUS_MODE_KEYRETURN As Short = 1 'KEYRETURNと同様の制御
	Public Const NEXT_FOCUS_MODE_KEYRIGHT As Short = 2 'KEYRIGHTと同様の制御
	'======================= 変更部分 2006.07.02 Start =================================
	Public Const NEXT_FOCUS_MODE_KEYDOWN As Short = 3 'KEYDOWNと同様の制御
	'======================= 変更部分 2006.07.02 End =================================
	'//F_Set_Befe_Focus処理モード
	Public Const BEFE_FOCUS_MODE_KEYLEFT As Short = 4 'KEYLEFTと同様の制御
	Public Const BEFE_FOCUS_MODE_KEYUP As Short = 5 'KEYUPと同様の制御
	'//F_Dsp_Item_Detail処理モード
	Public Const DSP_SET As Short = 0 '表示
	Public Const DSP_CLR As Short = 1 'クリア
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_KNG_SQL
	'   概要：  データ取得ＳＱＬ生成
	'   引数：　なし
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_KNG_SQL() As String
		
		Dim strSQL As String
		
		'検索ＳＱＬ発行
		strSQL = ""
		'CHG START FKS)INABA 2009/10/08 *************************************************************
		'連絡票№FC09101403
		strSQL = strSQL & " Select "
		strSQL = strSQL & "     NVL(KNG.DATKB,9) DATKB " '伝表削除区分
		strSQL = strSQL & "    ,KNG.KNGGRCD " '権限グループ
		strSQL = strSQL & "    ,NVL(KNG.PGID,MEI.MEICDA) PGID" 'プログラムＩＤ
		strSQL = strSQL & "    ,MEI.MEINMA " 'プログラム名
		strSQL = strSQL & "    ,DECODE(MEI.MEISUA,1,'1','9') UPDFLG" '更新権限変更可能フラグ
		strSQL = strSQL & "    ,NVL(KNG.UPDAUTH,'9') UPDAUTH" '更新権限
		strSQL = strSQL & "    ,DECODE(MEI.MEISUB,1,'1','9') PRTFLG" '印刷権限変更可能フラグ
		strSQL = strSQL & "    ,NVL(KNG.PRTAUTH,'9') PRTAUTH" '印刷権限
		strSQL = strSQL & "    ,DECODE(MEI.MEISUC,1,'1','9') FILEFLG " 'ファイル出力権限変更可能フラグ
		strSQL = strSQL & "    ,NVL(KNG.FILEAUTH,'9') FILEAUTH" 'ファイル出力権限
		strSQL = strSQL & "    ,DECODE(MEI.MEIKBA,'1','1','9') SALTFLG " '販売単価変更権限変更可能フラグ
		strSQL = strSQL & "    ,NVL(KNG.SALTAUTH,'9') SALTAUTH" '販売単価変更権限
		strSQL = strSQL & "    ,DECODE(MEI.MEIKBB,'1','1','9') HDNTFLG " '発注単価変更権限変更可能フラグ
		strSQL = strSQL & "    ,NVL(KNG.HDNTAUTH,'9') HDNTAUTH" '発注単価変更権限
		strSQL = strSQL & "    ,DECODE(MEI.MEIKBC,'1','1','9') SAPMFLG " '販売計画年初計画修正権限変更可能フラグ
		strSQL = strSQL & "    ,NVL(KNG.SAPMAUTH,'9') SAPMAUTH" '販売計画年初計画修正権限
		strSQL = strSQL & "    ,KNG.WRTDT " '更新日付
		strSQL = strSQL & "    ,KNG.WRTTM " '更新時間
		strSQL = strSQL & "    ,KNG.UWRTDT " 'バッチ更新日付
		strSQL = strSQL & "    ,KNG.UWRTTM " 'バッチ更新時間
		strSQL = strSQL & "    ,KNG.OPEID " '最終作業者コード
		strSQL = strSQL & "    ,KNG.CLTID " 'クライアントＩＤ
		strSQL = strSQL & "    ,KNG.UOPEID " '最終作業者コード（バッチ）
		strSQL = strSQL & "    ,KNG.UCLTID " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & " From "
		strSQL = strSQL & "     KNGMTB KNG "
		strSQL = strSQL & "    ,MEIMTA MEI "
		strSQL = strSQL & " Where "
		strSQL = strSQL & "     KNG.KNGGRCD(+) = '" & CF_Ora_String(pv_KNGMT51_KNGGRCD, 3) & "' "
		strSQL = strSQL & " And MEI.KEYCD   = '" & pv_Pgid_Keycode & "' "
		strSQL = strSQL & " And MEI.MEICDA  = KNG.PGID(+) "
		strSQL = strSQL & " And MEI.MEICDA  <> '0000000             '"
		strSQL = strSQL & " Order By "
		strSQL = strSQL & "     MEI.DSPORD "
		
		'    strSQL = strSQL & " Select "
		'    strSQL = strSQL & "     KNG.DATKB "             '伝表削除区分
		'    strSQL = strSQL & "    ,KNG.KNGGRCD "           '権限グループ
		'    strSQL = strSQL & "    ,KNG.PGID "              'プログラムＩＤ
		'    strSQL = strSQL & "    ,MEI.MEINMA "            'プログラム名
		'    strSQL = strSQL & "    ,KNG.UPDFLG "            '更新権限変更可能フラグ
		'    strSQL = strSQL & "    ,KNG.UPDAUTH "           '更新権限
		'    strSQL = strSQL & "    ,KNG.PRTFLG "            '印刷権限変更可能フラグ
		'    strSQL = strSQL & "    ,KNG.PRTAUTH "           '印刷権限
		'    strSQL = strSQL & "    ,KNG.FILEFLG "           'ファイル出力権限変更可能フラグ
		'    strSQL = strSQL & "    ,KNG.FILEAUTH "          'ファイル出力権限
		'    strSQL = strSQL & "    ,KNG.SALTFLG "           '販売単価変更権限変更可能フラグ
		'    strSQL = strSQL & "    ,KNG.SALTAUTH "          '販売単価変更権限
		'    strSQL = strSQL & "    ,KNG.HDNTFLG "           '発注単価変更権限変更可能フラグ
		'    strSQL = strSQL & "    ,KNG.HDNTAUTH "          '発注単価変更権限
		'    strSQL = strSQL & "    ,KNG.SAPMFLG "           '販売計画年初計画修正権限変更可能フラグ
		'    strSQL = strSQL & "    ,KNG.SAPMAUTH "          '販売計画年初計画修正権限
		'
		''2007/12/27 add-str T.KAWAMUKAI
		'    strSQL = strSQL & "    ,KNG.WRTDT "             '更新日付
		'    strSQL = strSQL & "    ,KNG.WRTTM "             '更新時間
		'    strSQL = strSQL & "    ,KNG.UWRTDT "            'バッチ更新日付
		'    strSQL = strSQL & "    ,KNG.UWRTTM "            'バッチ更新時間
		''2007/12/27 add-end T.KAWAMUKAI
		'
		'' === 20080902 === INSERT S - RISE)Izumi
		'    strSQL = strSQL & "    ,KNG.OPEID "             '最終作業者コード
		'    strSQL = strSQL & "    ,KNG.CLTID "             'クライアントＩＤ
		'    strSQL = strSQL & "    ,KNG.UOPEID "            '最終作業者コード（バッチ）
		'    strSQL = strSQL & "    ,KNG.UCLTID "            'クライアントＩＤ（バッチ）
		'' === 20080902 === INSERT E - RISE)Izumi
		'
		'    strSQL = strSQL & " From "
		'    strSQL = strSQL & "     KNGMTB KNG "
		'    strSQL = strSQL & "    ,MEIMTA MEI "
		'    strSQL = strSQL & " Where "
		'    strSQL = strSQL & "     KNG.KNGGRCD = '" & CF_Ora_String(pv_KNGMT51_KNGGRCD, 3) & "' "
		'    strSQL = strSQL & " And MEI.KEYCD   = '" & pv_Pgid_Keycode & "' "
		'    strSQL = strSQL & " And MEI.MEICDA  = KNG.PGID "
		'    strSQL = strSQL & " Order By "
		'    strSQL = strSQL & "     MEI.DSPORD "
		'CHG  END  FKS)INABA 2009/10/08 *************************************************************
		
		F_GET_KNG_SQL = strSQL
		
	End Function
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Del_Process
	'   概要：  削除メインルーチン
	'   引数：　pm_All        : 全構造体
	'   戻値：　処理結果ステータス
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Del_Process(ByRef pm_All As Cls_All) As Short
		
		Dim intRet As Short
		Dim intErrIdx As Short
		' === 20061031 === INSERT S - ACE)Nagasawa 排他制御の追加
		Dim strMsg As String
		' === 20061031 === INSERT E -
		' === 20070115 === INSERT S - ACE)Nagasawa 訂正前に更新時間チェックを入れる
		Dim bolRet As Boolean
		' === 20070115 === INSERT E -
		
		'20080821 ADD START RISE)Tanimura '排他処理
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim ls_sql As String
		Dim intCnt As Short
		Dim intLoop As Short
		Dim intIndex As Short
		Dim bolTran As Boolean
		
		bolTran = False
		'20080821 ADD END   RISE)Tanimura
		
		On Error GoTo F_Ctl_Del_Process_Err
		
		intRet = CHK_ERR_ELSE
		
		'砂時計にする
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'Windowsに処理を返す
		System.Windows.Forms.Application.DoEvents()
		
		'削除確認
		If AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_021, pm_All) = MsgBoxResult.No Then
			intRet = CHK_ERR_ELSE
			GoTo F_Ctl_Del_Process_End
		End If
		
		'    '排他チェックを行う
		'    Select Case CF_Chk_Lock_EXCTBZ(gv_strUpdLockMsg)
		'        '正常
		'        Case 0
		'
		'        '排他処理中
		'        Case 1
		'            gv_bolUPDLock = True
		'            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODET52_E_080, pm_All, "", gv_strUpdLockMsg)
		'            GoTo F_Ctl_Del_Process_Err
		'
		'        '異常終了
		'        Case 9
		'            Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODET52_E_042, pm_All)
		'            GoTo F_Ctl_Del_Process_Err
		'
		'    End Select
		'' === 20061031 === INSERT E -
		
		'20080821 ADD START RISE)Tanimura '排他処理
		'トランザクションの開始
		Call CF_Ora_BeginTrans(gv_Oss_USR1)
		bolTran = True
		
		'ボタン非表示
		FR_SSSMAIN.CM_Execute.Visible = False
		
		'削除処理
		intRet = F_Delete_Main(pm_All)
		Select Case intRet
			Case CHK_OK
				'正常
				'コミット
				Call CF_Ora_CommitTrans(gv_Oss_USR1)
				bolTran = False
				
			Case Else
				GoTo F_Ctl_Del_Process_Err
		End Select
		
		'完了メッセージ
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_009, pm_All)
		
F_Ctl_Del_Process_End: 
		If bolTran Then
			'ロールバック
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		End If
		
		' 排他制御の追加
		Call CF_Unlock_EXCTBZ(strMsg)
		'  INSERT E -
		
		'マウスポインタを戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'ボタン表示
		FR_SSSMAIN.CM_Execute.Visible = True
		
		F_Ctl_Del_Process = intRet
		Exit Function
		
F_Ctl_Del_Process_Err: 
		
		intRet = CHK_ERR_ELSE
		GoTo F_Ctl_Del_Process_End
		
	End Function
	
	'
	'ADD START FKS)INABA 2009/10/08 **********************************
	Public Function F_Delete_Main(ByRef pm_All As Cls_All) As Short
		Dim ls_sql As String
		Dim bolRet As Boolean
		On Error GoTo F_Delete_Main_ERR
		
		F_Delete_Main = -1
		ls_sql = ""
		ls_sql = ls_sql & " DELETE FROM KNGMTB "
		ls_sql = ls_sql & " WHERE KNGGRCD = '" & Trim(CF_Ora_String(pv_KNGMT51_KNGGRCD, 3)) & "' "
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, ls_sql)
		If bolRet = False Then
			GoTo F_Delete_Main_ERR
		End If
		
		F_Delete_Main = 0
		
		Exit Function
		
F_Delete_Main_ERR: 
		F_Delete_Main = -1
		Exit Function
	End Function
	'ADD  END  FKS)INABA 2009/10/08 **********************************
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_DATA
	'   概要：  ボディ部データ取得
	'   引数：  pm_All      :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'CHG START FKS)INABA 2009/10/08 ********************************
	'連絡票№FC09101403
	Public Function F_GET_BD_DATA(ByRef pm_All As Cls_All, Optional ByRef ps_Syori As String = "") As Short
		'Public Function F_GET_BD_DATA(pm_All As Cls_All) As Integer
		'CHG  END  FKS)INABA 2009/10/08 ********************************
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim Wk_Index As Short
		Dim Err_Cd As String
		'ADD START FKS)INABA 2009/10/08 **************************
		'連絡票№FC09101403
		Dim ls_syori As String
		ls_syori = ps_Syori
		'ADD  END  FKS)INABA 2009/10/08 **************************
		
		On Error GoTo ERR_F_GET_BD_DATA
		
		F_GET_BD_DATA = -1
		'初期化
		strSQL = ""
		Err_Cd = ""
		
		'検索ＳＱＬ生成
		strSQL = F_GET_KNG_SQL()
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'取得データなし
			F_GET_BD_DATA = 0
			Err_Cd = gc_strMsgKNGMT51_E_002
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			Exit Function
		Else
			'ADD START FKS)INABA 2009/10/08 **************************
			'連絡票№FC09101403
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn(Usr_Ody, KNGGRCD, ) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If ls_syori = "F_Set_Next_Focus" And CF_Ora_GetDyn(Usr_Ody, "KNGGRCD", "") = "" Then
				Err_Cd = gc_strMsgKNGMT51_E_020
				Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			End If
			Err_Cd = ""
			'ADD  END  FKS)INABA 2009/10/08 **************************
			intCnt = 0
			Do Until CF_Ora_EOF(Usr_Ody) = True
				'取得全レコードよりボディ情報退避
				intCnt = intCnt + 1
				'行追加
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
				'行項目情報コピー
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intCnt))
				
				With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
					
					.Bus_Inf.Selected = CStr(False) '選択/非選択
					.Bus_Inf.UPDKB = UPDKB_UPD 'モード
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '伝票削除区分
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.KNGGRCD = CF_Ora_GetDyn(Usr_Ody, "KNGGRCD", "") '権限グループ
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.PGID = CF_Ora_GetDyn(Usr_Ody, "PGID", "") 'プログラムＩＤ
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.MEINMA = CF_Ora_GetDyn(Usr_Ody, "MEINMA", "") 'プログラム名
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.UPDFLG = CF_Ora_GetDyn(Usr_Ody, "UPDFLG", "") '更新権限変更可能フラグ
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.UPDAUTH = CF_Ora_GetDyn(Usr_Ody, "UPDAUTH", "") '更新権限
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.PRTFLG = CF_Ora_GetDyn(Usr_Ody, "PRTFLG", "") '印刷権限変更可能フラグ
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.PRTAUTH = CF_Ora_GetDyn(Usr_Ody, "PRTAUTH", "") '印刷権限
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.FILEFLG = CF_Ora_GetDyn(Usr_Ody, "FILEFLG", "") 'ファイル出力権限変更可能フラグ
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.FILEAUTH = CF_Ora_GetDyn(Usr_Ody, "FILEAUTH", "") 'ファイル出力権限
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SALTFLG = CF_Ora_GetDyn(Usr_Ody, "SALTFLG", "") '販売単価変更権限変更可能フラグ
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SALTAUTH = CF_Ora_GetDyn(Usr_Ody, "SALTAUTH", "") '販売単価変更権限
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.HDNTFLG = CF_Ora_GetDyn(Usr_Ody, "HDNTFLG", "") '発注単価変更権限変更可能フラグ
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.HDNTAUTH = CF_Ora_GetDyn(Usr_Ody, "HDNTAUTH", "") '発注単価変更権限
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SAPMFLG = CF_Ora_GetDyn(Usr_Ody, "SAPMFLG", "") '販売計画年初計画修正権限変更可能フラグ
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.SAPMAUTH = CF_Ora_GetDyn(Usr_Ody, "SAPMAUTH", "") '販売計画年初計画修正権限
					
					'2007/12/18 add-str M.SUEZAWA 訂正前に更新時間チェックを入れる
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.MOTO_WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '更新日付
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.MOTO_WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '更新時刻
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.MOTO_UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") 'バッチ更新日付
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.MOTO_UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") 'バッチ更新時刻
					'2007/12/18 add-end M.SUEZAWA
					
					' === 20080902 === INSERT S - RISE)Izumi
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.MOTO_OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "")
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.MOTO_CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "")
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.MOTO_UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")
					'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					.Bus_Inf.MOTO_UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")
					' === 20080902 === INSERT E - RISE)Izumi
					
					'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
					'モード
					Wk_Index = CShort(FR_SSSMAIN.BD_UPDKB(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.UPDKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'プログラムＩＤ
					Wk_Index = CShort(FR_SSSMAIN.BD_PGID(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.PGID, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'プログラム名
					Wk_Index = CShort(FR_SSSMAIN.BD_MEINMA(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.MEINMA, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					' 2006/11/21  ADD START  KUMEDA
					'起動
					Wk_Index = CShort(FR_SSSMAIN.BD_DATKB(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.DATKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(3).Focus_Ctl = True
					' 2006/11/21  ADD END
					'更新
					Wk_Index = CShort(FR_SSSMAIN.BD_UPDAUTH(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.UPDAUTH, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(4).Focus_Ctl = True
					'印刷
					Wk_Index = CShort(FR_SSSMAIN.BD_PRTAUTH(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.PRTAUTH, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(5).Focus_Ctl = True
					'ファイル出力
					Wk_Index = CShort(FR_SSSMAIN.BD_FILEAUTH(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.FILEAUTH, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(6).Focus_Ctl = True
					'販売単価変更
					Wk_Index = CShort(FR_SSSMAIN.BD_SALTAUTH(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SALTAUTH, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(7).Focus_Ctl = True
					'発注単価変更
					Wk_Index = CShort(FR_SSSMAIN.BD_HDNTAUTH(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.HDNTAUTH, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(8).Focus_Ctl = True
					'販売計画年初計画修正
					Wk_Index = CShort(FR_SSSMAIN.BD_SAPMAUTH(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SAPMAUTH, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(9).Focus_Ctl = True
					' 2006/11/15  ADD START  KUMEDA
					'更新フラグ
					Wk_Index = CShort(FR_SSSMAIN.BD_UPDATE(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.UPDATE, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(10).Focus_Ctl = True
					' 2006/11/15  ADD END
					'対象行の状態
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Status = BODY_ROW_STATE_INPUT
				End With
				
				'次レコード
				Call CF_Ora_MoveNext(Usr_Ody)
			Loop 
			'行情報構造体配列の Redim
			MaxPageNum = F_Ctl_Add_BlankRow(pm_All)
		End If
		
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		F_GET_BD_DATA = intCnt
		
		Exit Function
		
ERR_F_GET_BD_DATA: 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SET_BD_DATA
	'   概要：  ボディ部データ取得
	'   引数：　pm_All      :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_SET_BD_DATA(ByRef pm_All As Cls_All) As Object
		'明細編集
		'    Call CF_Body_Dsp(pm_All)
		Call F_Body_Dsp(pm_All)
		
	End Function
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Body_Dsp
	'   概要：  ボディ情報を画面に編集する
	'   引数：　pm_All      :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Body_Dsp(ByRef pm_All As Cls_All) As Short
		Dim Index_Wk As Short
		Dim Bd_Index As Short
		Dim Bd_Index_Bk As Short
		Dim Bd_Col_Index As Short
		Dim Cur_Top_Index As Short
		Dim Fcs_Flg As Boolean
		Dim Index_Of_Window As Short
		Dim Index_Cnt As Short
		Dim Available_Flg As Boolean
		
		If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'明細表示の画面
			
			'============================================================================
			'最上明細ｲﾝﾃﾞｯｸｽの再設定
			If pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_All.Dsp_Base.Dsp_Body_Cnt - 1 > UBound(pm_All.Dsp_Body_Inf.Row_Inf) Then
				'現在の最上明細ｲﾝﾃﾞｯｸｽから画面表示した場合に
				'配列数が足りない場合
				'最上明細ｲﾝﾃﾞｯｸｽを表示可能な一番下の行に設定
				Cur_Top_Index = UBound(pm_All.Dsp_Body_Inf.Row_Inf) - pm_All.Dsp_Base.Dsp_Body_Cnt + 1
				If Cur_Top_Index <= 0 Then
					Cur_Top_Index = 1
				End If
				pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
				If pm_All.Bd_Vs_Scrl Is Nothing = False Then
					'縦スクロールバーを設定
					Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
				End If
			End If
			'============================================================================
			
			'ボディ部内で処理
			Bd_Index = 0
			Bd_Index_Bk = 0
			
			For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index >= 0 Then
					
					'pm_All.Dsp_Body_Infの行ＮＯを取得
					Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					If Bd_Index_Bk <> Bd_Index Then
						'明細行ブレイク
						Bd_Col_Index = 1
						Bd_Index_Bk = Bd_Index
					Else
						Bd_Col_Index = Bd_Col_Index + 1
					End If
					
					'画面項目詳細情報を設定
					'条件によって変更される項目のみ
					Call CF_Dsp_Body_Inf_To_Dsp_Sub_Inf(pm_All.Dsp_Sub_Inf(Index_Wk).Detail, pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Item_Detail(Bd_Col_Index))
					
					'項目の情報が変更される情報をコントロールに設定
					'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
					Call CF_Set_Item_Not_Change(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Value, pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					'フォーカス有無の判定
					Fcs_Flg = F_Jge_Focus(Index_Wk, pm_All, Available_Flg)
					'フォーカスの制御
					Call CF_Set_Item_Focus_Ctl(Fcs_Flg, pm_All.Dsp_Sub_Inf(Index_Wk))
					'ADD START FKS)INABA 2009/10/08 ************************************************
					'連絡票№FC09101403(ロックされている(移動できない)項目の色変更)
					If Fcs_Flg = False Then
						pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Locked = True
					Else
						pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Locked = False
					End If
					'項目色の初期設定
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Index_Wk), ITEM_INITIAL_STATUS, pm_All, ITEM_COLOR_DEF)
					'ADD  END  FKS)INABA 2009/10/08 ************************************************
					'データ有行ＮＯの退避
					If Available_Flg = True Then
						Index_Of_Window = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index
					End If
				End If
			Next 
		End If
		
	End Function
	' === 20060825 === INSERT E
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Jge_Focus
	'   概要：  フォーカス有無の判定
	'   引数：　pm_All      :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Jge_Focus(ByRef pm_Index_Tag As Short, ByRef pm_All As Cls_All, ByRef pm_Av_Flg As Boolean) As Boolean
		
		Dim Bd_Index As Short
		Dim Tgt_Index As Short
		Dim Flg_Value As String
		
		'初期化
		F_Jge_Focus = False
		pm_Av_Flg = False
		
		'pm_All.Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(pm_Index_Tag), pm_All)
		
		'項目が「モード」「プログラムＩＤ」「プログラム名」でない場合
		If (pm_All.Dsp_Sub_Inf(pm_Index_Tag).Ctl.Name <> FR_SSSMAIN.BD_UPDKB(1).Name) And (pm_All.Dsp_Sub_Inf(pm_Index_Tag).Ctl.Name <> FR_SSSMAIN.BD_PGID(1).Name) And (pm_All.Dsp_Sub_Inf(pm_Index_Tag).Ctl.Name <> FR_SSSMAIN.BD_MEINMA(1).Name) Then
			
			'フラグの値を取得
			Select Case pm_All.Dsp_Sub_Inf(pm_Index_Tag).Ctl.Name
				' 2006/11/21  ADD START  KUMEDA
				Case FR_SSSMAIN.BD_DATKB(1).Name
					'起動
					Flg_Value = "1"
					' 2006/11/21  ADD END
					
				Case FR_SSSMAIN.BD_UPDAUTH(1).Name
					'更新
					Flg_Value = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.UPDFLG
					
				Case FR_SSSMAIN.BD_PRTAUTH(1).Name
					'印刷
					Flg_Value = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.PRTFLG
					
				Case FR_SSSMAIN.BD_FILEAUTH(1).Name
					'ファイル出力
					Flg_Value = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.FILEFLG
					
				Case FR_SSSMAIN.BD_SALTAUTH(1).Name
					'販売単価変更
					Flg_Value = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.SALTFLG
					
				Case FR_SSSMAIN.BD_HDNTAUTH(1).Name
					'発注単価変更
					Flg_Value = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.HDNTFLG
					
				Case FR_SSSMAIN.BD_SAPMAUTH(1).Name
					'販売計画年初計画修正
					Flg_Value = pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Bus_Inf.SAPMFLG
					
			End Select
			
			
			'対象行の状態が初期状態以外の場合
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status <> BODY_ROW_STATE_DEFAULT Then
				If Flg_Value = pv_POS Then
					F_Jge_Focus = True
					pm_Av_Flg = True
				End If
				
				'対象行の状態が最終準備行の場合
				If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
					pm_Av_Flg = False
				End If
			End If
		End If
		
	End Function
	' === 20060825 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Add_BlankRow
	'   概要：  空白行情報追加
	'   引数：　pm_All                :全構造体
	'   戻値：　必要ページ数
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Add_BlankRow(ByRef pm_All As Cls_All) As Short
		
		Dim Ret_Value As Short
		Dim intPage As Short
		Dim bolFind As Boolean
		Dim intBfrUBound As Short
		Dim intAfrUBound As Short
		Dim intIdx As Short
		
		Ret_Value = 0
		
		'初期化
		intBfrUBound = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		intAfrUBound = 0
		intPage = 0
		bolFind = False
		
		'必要ページ数を取得
		'（ページ数に上限をもたせる場合は、ここに "Or intPage > NN" を追加？）
		Do Until bolFind = True
			'インクリメント
			intPage = intPage + 1
			'ページ数をもとに行情報配列の上限を算出
			intAfrUBound = pm_All.Dsp_Base.Dsp_Body_Cnt * intPage
			'行構造体の上限以上になったらページ数を退避し、ブレイク
			' === 20060825 === UPDATE S
			'        If intAfrUBound >= intBfrUBound Then
			If intAfrUBound > intBfrUBound Then
				' === 20060825 === UPDATE E
				Ret_Value = intPage
				bolFind = True
			End If
		Loop 
		
		'空白行情報を追加
		If intAfrUBound > intBfrUBound Then
			'行追加
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(intAfrUBound)
			For intIdx = intBfrUBound + 1 To intAfrUBound
				'行項目情報コピー
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(intIdx))
				
			Next intIdx
		End If
		
		F_Ctl_Add_BlankRow = Ret_Value
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Dsp_Body
	'   概要：  指定された明細の初期値を設定する
	'   引数：　pm_Bd_Index     :明細行インデックス
	'           pm_all          :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'    '画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
		'    Call CF_Edi_Dsp_Body_Inf("9" _
		''                           , pm_All.Dsp_Sub_Inf(Wk_Index) _
		''                           , pm_Bd_Index _
		''                           , pm_All)
		'
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Item_Input_Aft
	'   概要：  画面で項目入力された場合の後処理を行います
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Item_Input_Aft(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Boolean
		
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index As Short
		
		'明細の再作成を行う
		Call CF_Re_Crt_Body_Inf(pm_Dsp_Sub_Inf, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'    '行を追加された後に
		'    '初期値を追加した行に対してループ内で１行ずつ行う
		'    'ここでの行は、Dsp_Body_Infの行！！
		'    For Bd_Index = Row_Inf_Max_S To Row_Inf_Max_E
		'        Call F_Init_Dsp_Body(Bd_Index, pm_All)
		'    Next
		' === 20060825 === INSERT S
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD Then
			' 2006/11/15  CHG START  KUMEDA
			'        gv_bolKNGMT51_INIT = True
			Call F_SET_UPDFLG(pm_Dsp_Sub_Inf, pm_All)
			' 2006/11/15  CHG END
		End If
		' === 20060825 === INSERT E
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Befe_Focus
	'   概要：  前のフォーカス位置設定(LEFTなど)
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_Move_Flg         :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Befe_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True, Optional ByRef pm_Mode As Short = BEFE_FOCUS_MODE_KEYLEFT) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Lst_Idx As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		' === 20060825 === UPDATE S
		'割当ｲﾝﾃﾞｯｸｽ取得
		If pm_Mode = BEFE_FOCUS_MODE_KEYUP Then
			If (pm_Dsp_Sub_Inf.Detail.Body_Index = 1) And (pm_Dsp_Sub_Inf.Ctl.Tag <> FR_SSSMAIN.BD_UPDAUTH(1).Tag) Then
				Trg_Index = CShort(FR_SSSMAIN.BD_UPDAUTH(1).Tag) + 1
			Else
				Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
			End If
		Else
			Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		End If
		' === 20060825 === UPDATE E
		
		'次の項目を検索
		For Index_Wk = Trg_Index - 1 To 1 Step -1
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_TL And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'フッタ部からボディ部へ移動する場合
				'入力可能な最初のインデックスを取得
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					Index_Wk = Focus_Ctl_Ok_Fst_Idx
				End If
				
			End If
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD Then
				'ボディ部からヘッダ部へ移動する場合
				If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
					' === 20060825 === DELATE S
					'            '｢上移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
					'
					'                '画面の内容を退避
					'                Call CF_Body_Bkup(pm_All)
					'                '移動可能行を一番上に表示した場合の最上明細インデックスを設定
					'                pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
					'                If pm_All.Bd_Vs_Scrl Is Nothing = False Then
					'                    '縦スクロールバーを設定
					'                    Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
					'                End If
					'                '画面ボディ情報の配列を再設定
					'                Call CF_Dell_Refresh_Body_Inf(pm_All)
					'                '画面表示
					'                'Call CF_Body_Dsp(pm_All)
					'                Call F_Body_Dsp(pm_All)
					'
					'                '入力可能な最後のインデックスを取得
					'                Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(1, pm_All)
					'                If Focus_Ctl_Ok_Lst_Idx > 0 Then
					'                    Index_Wk = Focus_Ctl_Ok_Lst_Idx
					'                End If
					' === 20060825 === DELATE E
				End If
			End If
			
			'ﾌｫｰｶｽ移動がOK
			If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
				If pm_Run_Flg = True Then
					'実行指定がある場合(基本あり)
					'ﾌｫｰｶｽ移動
					Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				End If
				'移動フラグ決定
				pm_Move_Flg = True
				Exit For
			End If
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Next_Focus
	'   概要：  次のフォーカス位置設定(ENT、RIGHTなど)
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_Mode             :モード
	'           pm_all              :全構造体
	'           pm_Move_Flg         :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_Run_Flg          :実行指定フラグ（T：あり、F：なし）
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Sta_Index As Short
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Bd_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Focus_Ctl_Ok_Lst_Idx As Short
		Dim Focus_Ctl_Ok_Fst_Idx_Wk As Short
		Dim Cur_Top_Index As Short
		
		Dim bolDsp As Boolean
		Dim bolAllChk As Boolean
		Dim RtnCode As Short
		
		bolDsp = False
		bolAllChk = False
		RtnCode = -1
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'ボディ部
			'Dsp_Body_Infの行ＮＯを取得
			Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
			
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
				'最終準備行の場合
				'入力可能な最初のインデックスを取得
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
				
				If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Fst_Idx Then
					'入力可能な最初の項目の場合
					'モードにより検索開始位置を決定
					Select Case pm_Mode
						'======================= 変更部分 2006.07.02 Start =================================
						Case NEXT_FOCUS_MODE_KEYRETURN, NEXT_FOCUS_MODE_KEYDOWN
							'KEYRETURN、KEYDOWNの場合
							'======================= 変更部分 2006.07.02 End =================================
							'検索開始はフッタ部の最初の項目から
							Sta_Index = pm_All.Dsp_Base.Foot_Fst_Idx
							
						Case NEXT_FOCUS_MODE_KEYRIGHT
							'KEYRIGHTの場合
							'割当ｲﾝﾃﾞｯｸｽ取得
							'検索開始は対象の項目の次
							Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
							
					End Select
				Else
					'検索開始は対象の項目の次
					Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
				End If
				
			Else
				'最終準備行以外の場合
				If pm_Dsp_Sub_Inf.Detail.Body_Index = pm_All.Dsp_Base.Dsp_Body_Cnt Then
					'表示されている最終行の場合
					'入力可能な最後のインデックスを取得
					Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
					
					If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) = Focus_Ctl_Ok_Lst_Idx Then
						'入力可能な最後の項目の場合
						' === 20060825 === INSERT S
						Select Case pm_Mode
							Case NEXT_FOCUS_MODE_KEYRETURN
								'検索開始はフッタ部の最初の項目から
								Sta_Index = pm_All.Dsp_Base.Foot_Fst_Idx
								
							Case Else
								'検索開始は対象の項目の先頭
								Sta_Index = CShort(FR_SSSMAIN.BD_UPDAUTH(pm_All.Dsp_Base.Dsp_Body_Cnt).Tag)
								
						End Select
						' === 20060825 === INSERT E
						' === 20060825 === DELETE S
						'                    If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
						'                    '最終準備行以外＆画面上の最終行＆最終項目
						'                    '｢下移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
						'
						'                        '画面の内容を退避
						'                        Call CF_Body_Bkup(pm_All)
						'                        '移動可能行を一番下に表示した場合の最上明細インデックスを設定
						'                        pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
						'                        If pm_All.Bd_Vs_Scrl Is Nothing = False Then
						'                            '縦スクロールバーを設定
						'                            Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
						'                        End If
						''======================= 変更部分 2006.07.02 Start =================================
						'                        '画面ボディ情報の配列を再設定
						'                        Call CF_Dell_Refresh_Body_Inf(pm_All)
						''======================= 変更部分 2006.07.02 End =================================
						'                        '画面表示
						'                        'Call CF_Body_Dsp(pm_All)
						'                        Call F_Body_Dsp(pm_All)
						'
						'                        '明細１番下行の入力可能な最初のインデックスを取得
						'                        Focus_Ctl_Ok_Fst_Idx_Wk = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Dsp_Sub_Inf.Detail.Body_Index, pm_All)
						'                        If Focus_Ctl_Ok_Fst_Idx_Wk > 0 Then
						'                            '明細１番下行の最初の項目の一つ前から検索
						'                            Sta_Index = Focus_Ctl_Ok_Fst_Idx_Wk - 1
						'                        Else
						'                            '検索開始は対象の項目の次
						'                            Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
						'                        End If
						'
						'                     Else
						'                    '｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
						'                        '検索開始は対象の項目の次
						'                        Sta_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
						'                     End If
						' === 20060825 === DELETE E
					Else
						'入力可能な最後の項目以外の場合
						'検索開始は対象の項目の次
						Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
					End If
					
				Else
					'最終行以外場合
					'検索開始は対象の項目の次
					Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
				End If
			End If
			
		Else
			'ボディ部以外
			'検索開始は対象の項目の次
			Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) + 1
		End If
		
		'次の項目を検索
		For Index_Wk = Sta_Index To pm_All.Dsp_Base.Item_Cnt
			
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'ヘッダ部からボディ部へ移動する場合
				''' === 20060824 === INSERT S
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'権限グループが変更された場合
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Value Then
					'権限グループの取得
					pv_KNGMT51_KNGGRCD = Trim(FR_SSSMAIN.HD_KNGGRCD.Text)
					
					'画面ボディ部初期化
					Call F_Init_Clr_Dsp_Body(-1, pm_All)
					'CHG START FKS)INABA 2009/10/08 ********************************
					'連絡票№FC09101403
					RtnCode = F_GET_BD_DATA(pm_All, "F_Set_Next_Focus")
					'                RtnCode = F_GET_BD_DATA(pm_All)
					'CHG  END  FKS)INABA 2009/10/08 ********************************
					
					'現在のページ数初期化
					NowPageNum = 1
					
					'最上明細ｲﾝﾃﾞｯｸｽ初期化
					pm_All.Dsp_Body_Inf.Cur_Top_Index = 1
					
					If RtnCode = 0 Then
						'出力できる明細データが無い
						pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
						
						gv_bolMeiErrFlg = True
					Else
						pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
						
						gv_bolMeiErrFlg = False
					End If
					
					'明細を画面に編集
					Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(CShort(pm_Dsp_Sub_Inf.Ctl.Tag)), DSP_SET, pm_All)
					
					gv_bolKNGMT51_INIT = False
				End If
				
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				''' === 20060824 === INSERT E
			End If
			
			'現在対象以外
			If CShort(pm_Dsp_Sub_Inf.Ctl.Tag) <> Index_Wk Then
				'ﾌｫｰｶｽ移動がOK
				If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All) = True Then
					If pm_Run_Flg = True Then
						'実行指定がある場合(基本あり)
						'ﾌｫｰｶｽ移動
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					End If
					'移動フラグ決定
					pm_Move_Flg = True
					Exit For
				End If
			End If
			
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Left_Next_Focus
	'   概要：  Left押下時のフォーカス位置設定
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_Move_Flg         :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Left_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Wk_Point As Short
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			'現在のﾃｷｽﾄ上の選択状態を取得
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
					'詰文字が左詰の場合
					'１文字目を選択する
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelStart = 0
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelLength = 1
				Else
					'詰文字が左詰以外の場合
					'１つ前の項目へ
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
					
				End If
			Else
				If Act_SelStart = 0 Then
					'開始位置が一番左の場合
					'１つ前の項目へ
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
				Else
					
					'左に１桁ずつずらし入力可能な文字を検索
					Wk_SelStart = -1
					For Wk_Point = Act_SelStart - 1 To 0 Step -1
						'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)
						If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
							Wk_SelStart = Wk_Point
							Exit For
						End If
					Next 
					
					If Wk_SelStart = -1 Then
						'選択可能な文字がない場合
						'１つ前の項目へ
						Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
					Else
						'選択可能な文字がある場合
						If Act_SelStart < Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) And Act_SelLength = 0 Then
							'移動前の選択開始位置が一番右以外でかつ
							'選択文字数がない場合のみ、
							'同じ項目で移動する場合に選択文字数は継続する
							Wk_SelLength = 0
						Else
							Wk_SelLength = 1
						End If
						
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
					End If
					
				End If
			End If
		Else
			'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの以外場合
			'１つ前の項目へ
			Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Right_Next_Focus
	'   概要：  Right押下時のフォーカス位置設定
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_Move_Flg         :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_all              :全構造体
	'           pm_Run_Flg          :実行指定フラグ（T：あり、F：なし）
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Right_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, ByRef pm_Run_Flg As Boolean) As Short
		Dim Index_Wk As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Str_Wk As String
		Dim Next_SelStart As Short
		Dim Wk_Point As Short
		Dim Wk_SelLength As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			'現在のﾃｷｽﾄ上の選択状態を取得
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
					'詰文字が左詰の場合
					'最終文字を選択する
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelLength = 1
				Else
					'詰文字が左詰以外の場合
					'ENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
				End If
			Else
				If Act_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Then
					'選択開始位置が一番右の場合
					'ENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
				Else
					'選択開始位置が一番右でない場合
					
					'１つ右の１桁を取得
					'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Act_SelStart + 1 + 1, 1)
					
					If Str_Wk = "" Then
						'次の１桁がない場合
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'詰文字が左詰の場合
							'一番右へ移動し選択なし状態に
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelLength = 0
						Else
							'詰文字が左詰以外の場合
							If Act_SelLength = 0 Then
								'移動前の選択文字数がない場合
								'一番右へ移動し選択なし状態に
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelLength = 0
							Else
								'ENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
					Else
						
						'右に１桁ずつずらし入力可能な文字を検索
						Next_SelStart = -1
						For Wk_Point = Act_SelStart + 1 To Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Step 1
							
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Wk_Point + 1, 1)
							
							Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
								Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
									'日付/年月/時刻項目の場合
									'入力可能文字＆と空白も移動可能
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Or Str_Wk = Space(1) Then
										Next_SelStart = Wk_Point
										Exit For
									End If
								Case Else
									'日付/年月/時刻項目以外の場合
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Str_Wk) = 1 Then
										Next_SelStart = Wk_Point
										Exit For
									End If
									
							End Select
						Next 
						
						If Next_SelStart = -1 Then
							'選択可能な文字がない場合
							'ENTキー押下と同様に次の項目へ
							Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
						Else
							'選択可能な文字がある場合
							
							If Act_SelLength = 0 Then
								'移動前の選択文字数がない場合
								'同じ項目で移動する場合に選択文字数は継続する
								Wk_SelLength = 0
							Else
								Wk_SelLength = 1
							End If
							
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						End If
					End If
				End If
				
			End If
		Else
			'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの以外場合
			'ENTキー押下と同様に次の項目へ
			Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Down_Next_Focus
	'   概要：  Down押下時のフォーカス位置設定
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_Move_Flg         :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Down_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Next_Index As Short
		Dim Wk_Cnt As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'明細部の場合
			Wk_Cnt = 0
			Do 
				Wk_Cnt = Wk_Cnt + 1
				'現在の項目に列分だけ下に移動したｲﾝﾃﾞｯｸｽを求める
				Next_Index = Trg_Index + (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
				
				' === 20060825 === UPDATE S
				'            If Next_Index > pm_All.Dsp_Base.Item_Cnt Then
				If Next_Index > pm_All.Dsp_Base.Foot_Fst_Idx - 1 Then
					' === 20060825 === UPDATE E
					'項目数を超えた場合
					' === 20060825 === UPDATE S
					'最終行の先頭項目以外の場合
					If Trg_Index <> pm_All.Dsp_Base.Foot_Fst_Idx - pm_All.Dsp_Base.Body_Col_Cnt + 1 Then
						'ENTキー押下と同様に次の項目へ
						'                    Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
					End If
					' === 20060825 === UPDATE E
					Exit Do
				End If
				
				If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
					'移動先が明細部でかつ移動前と同じｺﾝﾄﾛｰﾙ名の場合
					If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
						'ﾌｫｰｶｽ受取ＯＫ
						'同一列に移動
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
						pm_Move_Flg = True
						Exit Do
					End If
				Else
					'次の項目名が明細部でない場合
					If CF_Jdg_Row_Down_Focus(Cur_Top_Index, pm_All) = True Then
						'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
						'画面の内容を退避
						Call CF_Body_Bkup(pm_All)
						'移動可能行を一番下に表示した場合の最上明細インデックスを設定
						pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
						If pm_All.Bd_Vs_Scrl Is Nothing = False Then
							'縦スクロールバーを設定
							Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CShort(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
						End If
						'画面ボディ情報の配列を再設定
						Call CF_Dell_Refresh_Body_Inf(pm_All)
						'画面表示
						'Call CF_Body_Dsp(pm_All)
						Call F_Body_Dsp(pm_All)
						'明細の一番下の同一項目のｲﾝﾃﾞｯｸｽを取得
						Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
						If Next_Index > 0 Then
							If Next_Index = Trg_Index Then
								'同一ｺﾝﾄﾛｰﾙの場合
								'移動無しで終了
								pm_Move_Flg = False
								Exit Do
							Else
								'同一ｺﾝﾄﾛｰﾙでない場合
								'同一項目の１つ前からENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'入力可能な最初のインデックスを取得
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'同一項目の１つ前からENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							Else
								'フッタ部の最初の項目の１つ前から
								'ENTキー押下と同様に次の項目へ
								Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
								Exit Do
							End If
						End If
						
					Else
						'｢下移動した場合、ﾌｫｰｶｽ移動可能な行がない｣場合
						'フッタ部の最初の項目の１つ前から
						'ENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
						Exit Do
					End If
				End If
			Loop 
			
		Else
			'明細部以外の場合
			'ENTキー押下と同様に次の項目へ
			Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Up_Next_Focus
	'   概要：  Up押下時のフォーカス位置設定
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_Move_Flg         :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Up_Next_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Next_Index As Short
		Dim Wk_Cnt As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'明細部の場合
			Wk_Cnt = 0
			Do 
				Wk_Cnt = Wk_Cnt + 1
				'現在の項目に列分だけ上に移動したｲﾝﾃﾞｯｸｽを求める
				Next_Index = Trg_Index - (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
				
				If Next_Index < 0 Then
					'マイナスの場合
					'１つ前の項目へ
					' === 20060825 === UPDATE S
					'Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All,  , BEFE_FOCUS_MODE_KEYUP)
					' === 20060825 === UPDATE E
					Exit Do
				End If
				
				If pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Next_Index).Ctl.Name = pm_Dsp_Sub_Inf.Ctl.Name Then
					'移動先が明細部でかつ移動前と同じｺﾝﾄﾛｰﾙ名の場合
					If CF_Set_Focus_Ctl(pm_All.Dsp_Sub_Inf(Next_Index), pm_All) = True Then
						'ﾌｫｰｶｽ受取ＯＫ
						'同一列に移動
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Next_Index), pm_All)
						pm_Move_Flg = True
						Exit Do
					End If
				Else
					'次の項目名が明細部でない場合
					If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
						' === 20060825 === DELATE S
						'                '｢上移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
						'                    '画面の内容を退避
						'                    Call CF_Body_Bkup(pm_All)
						'                    '移動可能行を一番上に表示した場合の最上明細インデックスを設定
						'                    pm_All.Dsp_Body_Inf.Cur_Top_Index = Cur_Top_Index
						'                    If pm_All.Bd_Vs_Scrl Is Nothing = False Then
						'                        '縦スクロールバーを設定
						'                        Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Cur_Top_Index, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
						'                    End If
						'                    '画面ボディ情報の配列を再設定
						'                    Call CF_Dell_Refresh_Body_Inf(pm_All)
						'                    '画面表示
						'                    'Call CF_Body_Dsp(pm_All)
						'                    Call F_Body_Dsp(pm_All)
						'                    '明細の一番上の同一項目のｲﾝﾃﾞｯｸｽを取得
						'                    Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, 1, pm_All)
						'                    If Next_Index > 0 Then
						'                        If Next_Index = Trg_Index Then
						'                        '同一ｺﾝﾄﾛｰﾙの場合
						'                            '移動無しで終了
						'                            pm_Move_Flg = False
						'                            Exit Do
						'                        Else
						'                        '同一ｺﾝﾄﾛｰﾙでない場合
						'                            '同一項目の１つ後ろから
						'                            '１つ前の項目へ
						'                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Next_Index + 1), pm_Move_Flg, pm_All)
						'                            Exit Do
						'                        End If
						'                    Else
						'                        '入力可能な最初のインデックスを取得
						'                        Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
						'                        If Focus_Ctl_Ok_Fst_Idx > 0 Then
						'                            '入力可能な最初の項目の１つ後ろから
						'                            '１つ前の項目へ
						'                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx + 1), pm_Move_Flg, pm_All)
						'                            Exit Do
						'                        Else
						'                            'ヘッダ部の最後の項目の１つ後ろから
						'                            '１つ前の項目へ
						'                            Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
						'                            Exit Do
						'
						'                        End If
						'                    End If
						' === 20060825 === DELATE E
					Else
						'ヘッダ部の最後の項目の１つ後ろから
						'１つ前の項目へ
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
						Exit Do
					End If
					
				End If
			Loop 
		Else
			'明細部以外の場合
			'１つ前の項目へ
			Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_Jge_Action
	'   概要：  各チェック関数のチェック前の
	'　　　　　 チェック続行を判定
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_From_Process　　　 :呼出元処理
	'           pm_Err_Rtn　　     　 :エラー戻値
	'           pm_Msg_Flg　　     　 :メッセージフラグ
	'           pm_Move　　　　　　　  :チェック後移動フラグ（T：移動OK、F：移動NG）
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_Jge_Action(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Err_Rtn As Short, ByRef pm_Msg_Flg As Boolean, ByRef pm_Move As Boolean) As Short
		Dim Rtn_Cd As Short
		
		'続行
		Rtn_Cd = CHK_KEEP
		
		Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
			Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status <= ERR_NOT Then
						'項目のステータスがエラーなし
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
				End If
				
			Case CHK_FROM_KEYPRESS
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'項目のステータスがエラーなし
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
			Case CHK_FROM_KEYRETURN
				'｢KEYRETURN｣
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT Then
						'項目のステータスがエラーなし
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
			Case CHK_FROM_ALL_CHK
				'一括チェックなど｣
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					If pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT And pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True Then
						'項目のステータスがエラーなしでかつ未入力以外のチェックを行っている場合
						'中断
						Rtn_Cd = CHK_STOP
						'メッセージ非表示
						pm_Msg_Flg = False
						'移動可
						pm_Move = True
						'チェックＯＫ
						pm_Err_Rtn = CHK_OK
					End If
					
				End If
				
		End Select
		
		If Rtn_Cd = CHK_STOP Then
			'チェックを中断
			'チェック関数呼出元処理をクリア
			pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		End If
		
		F_Chk_Jge_Action = Rtn_Cd
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_Jge_Msg_Move
	'   概要：  各チェック関数のチェック後の
	'　　　　　 メッセージ、ステータス、移動制御
	'   引数：　pm_Chk_Dsp_Sub_Inf    :チェック項目
	'           pm_From_Process　　　 :呼出元処理
	'           pm_Err_Rtn　　     　 :エラー戻値
	'           pm_Msg_Flg　　     　 :メッセージフラグ
	'           pm_Move　　　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_Jge_Msg_Move(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Err_Rtn As Short, ByRef pm_Msg_Flg As Boolean, ByRef pm_Move As Boolean) As Short
		
		'メッセージ表示なし
		pm_Msg_Flg = False
		'移動可
		pm_Move = True
		
		If pm_Err_Rtn = CHK_OK Then
			'チェックＯＫ
			pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
		Else
			
			Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
				Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								'チェックＯＫとする
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
									'前回と同じチェック内容の場合
									'チェックエラーとする
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'メッセージ出力なし
									pm_Msg_Flg = False
									'移動ＯＫ
									pm_Move = True
								Else
									'前回と異なるチェック内容の場合
									'チェックエラーとする
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'メッセージ出力なし
									pm_Msg_Flg = False
									'移動ＯＫ
									pm_Move = False
								End If
								
							End If
						Case CHK_ERR_ELSE
							'その他エラー時
							'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
								'前回と同じチェック内容の場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'前回と異なるチェック内容の場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'メッセージ出力あり
								pm_Msg_Flg = True
								'移動ＯＫ
								pm_Move = False
							End If
							
					End Select
					
				Case CHK_FROM_KEYPRESS
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								'チェックＯＫとする
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								'チェックエラーとする
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							End If
						Case CHK_ERR_ELSE
							'その他エラー時
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
					End Select
					
				Case CHK_FROM_KEYRETURN
					'｢KEYRETURN｣
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'メッセージ出力あり
								pm_Msg_Flg = True
								'移動ＮＧ
								pm_Move = False
							End If
							
						Case CHK_ERR_ELSE
							'その他エラー時
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
					End Select
				Case CHK_FROM_ALL_CHK
					
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
						Case CHK_ERR_ELSE
							'その他エラー時
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
					End Select
					
			End Select
			
		End If
		
		'チェック関数呼出元処理をクリア
		pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_KNGGRCD
	'   概要：  権限グループのﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :画面項目情報
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_KNGGRCD(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_KNGMTB
		Dim Mst_Inf_Clr As TYPE_DB_KNGMTB
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_KNGGRCD = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_NOT_INPUT
			
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'マスタチェック
				If KNGMTB_SEARCH_ALL(Input_Value, Mst_Inf) = 0 Then
					'該当データ有り
					Retn_Code = CHK_OK
					pm_Chk_Move = True
				Else
					'CHG START FKS)INABA 2009/10/08 *******************************************************
					'連絡票№FC09101403
					Retn_Code = CHK_OK
					pm_Chk_Move = True
					
					'                '該当データ無し
					'                Retn_Code = CHK_ERR_ELSE
					'
					'                If pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process <> CHK_FROM_LOSTFOCUS Then
					'                    Err_Cd = gc_strMsgKNGMT51_E_002
					'                End If
					'CHG  END  FKS)INABA 2009/10/08 *******************************************************
				End If
			End If
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		F_Chk_HD_KNGGRCD = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_DATKB
	'   概要：  起動のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :画面項目情報
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_DATKB(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_DATKB = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgKNGMT51_E_001
			
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'1 or 9以外の値が入力された場合はエラー
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case pv_POS, pv_INPOS
						'ＯＫ
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
					Case Else
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgKNGMT51_E_001
						
				End Select
			End If
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		F_Chk_BD_DATKB = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_UPDAUTH
	'   概要：  更新のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :画面項目情報
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_UPDAUTH(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_UPDAUTH = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgKNGMT51_E_001
			
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'1 or 9以外の値が入力された場合はエラー
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case pv_POS, pv_INPOS
						'ＯＫ
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
					Case Else
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgKNGMT51_E_001
						
				End Select
			End If
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		F_Chk_BD_UPDAUTH = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_PRTAUTH
	'   概要：  印刷のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :画面項目情報
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_PRTAUTH(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_PRTAUTH = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgKNGMT51_E_001
			
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'1 or 9以外の値が入力された場合はエラー
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case pv_POS, pv_INPOS
						'ＯＫ
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
					Case Else
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgKNGMT51_E_001
						
				End Select
			End If
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		F_Chk_BD_PRTAUTH = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_FILEAUTH
	'   概要：  ファイル出力のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :画面項目情報
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_FILEAUTH(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_FILEAUTH = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgKNGMT51_E_001
			
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'1 or 9以外の値が入力された場合はエラー
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case pv_POS, pv_INPOS
						'ＯＫ
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
					Case Else
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgKNGMT51_E_001
						
				End Select
			End If
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		F_Chk_BD_FILEAUTH = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_SALTAUTH
	'   概要：  販売単価変更のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :画面項目情報
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_SALTAUTH(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_SALTAUTH = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgKNGMT51_E_001
			
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'1 or 9以外の値が入力された場合はエラー
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case pv_POS, pv_INPOS
						'ＯＫ
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
					Case Else
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgKNGMT51_E_001
						
				End Select
			End If
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		F_Chk_BD_SALTAUTH = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_HDNTAUTH
	'   概要：  発注単価変更のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :画面項目情報
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_HDNTAUTH(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_HDNTAUTH = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgKNGMT51_E_001
			
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'1 or 9以外の値が入力された場合はエラー
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case pv_POS, pv_INPOS
						'ＯＫ
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
					Case Else
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgKNGMT51_E_001
						
				End Select
			End If
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		F_Chk_BD_HDNTAUTH = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_SAPMAUTH
	'   概要：  販売計画年初計画修正のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :画面項目情報
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_SAPMAUTH(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Bd_Index As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_SAPMAUTH = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgKNGMT51_E_001
			
		Else
			'未入力以外のチェック済
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgKNGMT51_E_001
			Else
				'1 or 9以外の値が入力された場合はエラー
				Select Case CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf)
					Case pv_POS, pv_INPOS
						'ＯＫ
						Retn_Code = CHK_OK
						pm_Chk_Move = True
						
					Case Else
						Retn_Code = CHK_ERR_ELSE
						Err_Cd = gc_strMsgKNGMT51_E_001
						
				End Select
			End If
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'戻値、メッセージ、ステータス、移動制御
		Call F_Chk_Jge_Msg_Move(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		If Msg_Flg = True And Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		F_Chk_BD_SAPMAUTH = Retn_Code
		
	End Function
	
	' 2006/11/15  ADD START  KUMEDA
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_SET_UPDFLG
	'   概要：  検索画面表示
	'   引数：　pm_All          :全構造体
	'   戻値：　なし
	'   備考：　テキストの内容が変更された明細の更新フラグを設定セットする
	'           テキストの内容変更、BackSpade、Delete、項目初期化、切取り
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_SET_UPDFLG(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Item_Detail(pc_COL_UPDATE).Dsp_Value = "1"
		FR_SSSMAIN.BD_UPDATE(pm_Dsp_Sub_Inf.Detail.Body_Index).Text = "1"
		
		gv_bolKNGMT51_INIT = True
		
	End Function
	' 2006/11/15  ADD END
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function KNGMTB_SEARCH_ALL
	'   概要：  権限マスタ検索
	'   引数：  pin_strKNGGRCD　 : 権限グループ
	'   　　　　pot_DB_KNGMTB  　: 検索結果
	'   戻値：　0:正常終了 1:対象データ無し 9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function KNGMTB_SEARCH_ALL(ByVal pin_strKNGGRCD As String, ByRef pot_DB_KNGMTB As TYPE_DB_KNGMTB) As Short
		
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strTGRPCD As String
		
		On Error GoTo ERR_KNGMTB_SEARCH_ALL
		
		KNGMTB_SEARCH_ALL = 9
		
		Call DB_KNGMTB_Clear(pot_DB_KNGMTB)
		'CHG START FKS)INABA 2009/10/08 *****************************************************
		'連絡票№FC09101403
		strSQL = ""
		strSQL = strSQL & " Select KNG.* "
		strSQL = strSQL & "   from KNGMTB KNG "
		strSQL = strSQL & "    ,MEIMTA MEI "
		strSQL = strSQL & "  WHERE KNG.KNGGRCD = '" & CF_Ora_String(pin_strKNGGRCD, 3) & "' "
		strSQL = strSQL & "    AND MEI.KEYCD   = '" & pv_Pgid_Keycode & "' "
		strSQL = strSQL & "    AND MEI.MEICDA  = KNG.PGID "
		strSQL = strSQL & " ORDER BY "
		strSQL = strSQL & "     MEI.DSPORD "
		
		'    strSQL = ""
		'    strSQL = strSQL & " Select * "
		'    strSQL = strSQL & "   from KNGMTB "
		'    strSQL = strSQL & "  Where KNGGRCD = '" & CF_Ora_String(pin_strKNGGRCD, 3) & "' "
		'CHG  END  FKS)INABA 2009/10/08 *****************************************************
		'DBアクセス
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		
		If CF_Ora_EOF(Usr_Ody) = True Then
			'取得データなし
			KNGMTB_SEARCH_ALL = 1
			GoTo END_KNGMTB_SEARCH_ALL
		End If
		
		KNGMTB_SEARCH_ALL = 0
		
END_KNGMTB_SEARCH_ALL: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_KNGMTB_SEARCH_ALL: 
		GoTo END_KNGMTB_SEARCH_ALL
		
	End Function
	' === 20060825 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_Item_Detail
	'   概要：  各項目の画面表示
	'   引数：　pm_Dsp_Sub_Inf      :画面情報
	'           pm_Mode             :モード
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_Item_Detail(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim RtnCode As Short
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			Case FR_SSSMAIN.HD_KNGGRCD.Name
				'権限グループによる画面表示
				
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End Select
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_DSP_BD_Inf
	'   概要：  ボディ部の画面表示
	'   引数：　pm_Dsp_Sub_Inf      :画面情報
	'           pm_Mode             :モード
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_DSP_BD_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All) As Short
		
		Dim intCnt As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'データ編集
			Call F_SET_BD_DATA(pm_All)
			
			'フォーカス位置設定
			Call F_Cursor_Set(pm_All)
		End If
		
		'復元内容、前回内容を退避
		Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Item_Chk
	'   概要：  各項目のﾁｪｯｸﾙｰﾁﾝ制御
	'   引数：　pm_Dsp_Sub_Inf      :画面情報
	'           pm_Process          :チェック関数呼出元
	'           pm_Chk_Move_Flg     :各項目のチェックフラグ
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Item_Chk(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Process As String, ByRef pm_Chk_Move_Flg As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Rtn_Chk As Short
		Dim Bd_Index As Short
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		pm_Chk_Move_Flg = True
		
		'①基本入力内容のチェック
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			Case FR_SSSMAIN.HD_KNGGRCD.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'権限グループのﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_KNGGRCD(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
				' 2006/11/21  ADD START  KUMEDA
			Case FR_SSSMAIN.BD_DATKB(1).Name
				If (pm_Process <> CHK_FROM_KEYRIGHT) And (pm_Process <> CHK_FROM_KEYLEFT) Then
					'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
					Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
					'起動のﾁｪｯｸ
					Rtn_Chk = F_Chk_BD_DATKB(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				End If
				' 2006/11/21  ADD END
				
			Case FR_SSSMAIN.BD_UPDAUTH(1).Name
				If (pm_Process <> CHK_FROM_KEYRIGHT) And (pm_Process <> CHK_FROM_KEYLEFT) Then
					'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
					Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
					'更新のﾁｪｯｸ
					Rtn_Chk = F_Chk_BD_UPDAUTH(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				End If
				
			Case FR_SSSMAIN.BD_PRTAUTH(1).Name
				If (pm_Process <> CHK_FROM_KEYRIGHT) And (pm_Process <> CHK_FROM_KEYLEFT) Then
					'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
					Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
					'印刷のﾁｪｯｸ
					Rtn_Chk = F_Chk_BD_PRTAUTH(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				End If
				
			Case FR_SSSMAIN.BD_FILEAUTH(1).Name
				If (pm_Process <> CHK_FROM_KEYRIGHT) And (pm_Process <> CHK_FROM_KEYLEFT) Then
					'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
					Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
					'ファイル出力のﾁｪｯｸ
					Rtn_Chk = F_Chk_BD_FILEAUTH(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				End If
				
			Case FR_SSSMAIN.BD_SALTAUTH(1).Name
				If (pm_Process <> CHK_FROM_KEYRIGHT) And (pm_Process <> CHK_FROM_KEYLEFT) Then
					'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
					Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
					'販売単価変更のﾁｪｯｸ
					Rtn_Chk = F_Chk_BD_SALTAUTH(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				End If
				
			Case FR_SSSMAIN.BD_HDNTAUTH(1).Name
				If (pm_Process <> CHK_FROM_KEYRIGHT) And (pm_Process <> CHK_FROM_KEYLEFT) Then
					'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
					Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
					'発注単価変更のﾁｪｯｸ
					Rtn_Chk = F_Chk_BD_HDNTAUTH(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				End If
				
			Case FR_SSSMAIN.BD_SAPMAUTH(1).Name
				If (pm_Process <> CHK_FROM_KEYRIGHT) And (pm_Process <> CHK_FROM_KEYLEFT) Then
					'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
					Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
					'販売計画年初計画修正のﾁｪｯｸ
					Rtn_Chk = F_Chk_BD_SAPMAUTH(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				End If
				
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End Select
		
		F_Ctl_Item_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Head_Chk
	'   概要：  ﾍｯﾀﾞ部のﾁｪｯｸﾙｰﾁﾝ制御
	'   引数：　pm_all      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Head_Chk(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		'======================= 変更部分 2006.06.12 Start =================================
		Dim Dsp_Mode As Short
		'======================= 変更部分 2006.06.12 End =================================
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		
		'ヘッダ部の最終項目まで各項目のﾁｪｯｸを行う
		For Index_Wk = 1 To pm_All.Dsp_Base.Head_Lst_Idx
			
			'各項目ﾁｪｯｸを全体ﾁｪｯｸとして呼出
			Rtn_Chk = F_Ctl_Item_Chk(pm_All.Dsp_Sub_Inf(Index_Wk), CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
			
			'======================= 変更部分 2006.06.12 Start =================================
			If Rtn_Chk = CHK_OK Then
				'チェックＯＫ時
				'取得内容表示
				Dsp_Mode = DSP_SET
			Else
				'チェックＮＧ時
				'取得内容クリア
				Dsp_Mode = DSP_CLR
			End If
			
			'取得内容表示/クリア
			Call F_Dsp_Item_Detail(pm_All.Dsp_Sub_Inf(Index_Wk), Dsp_Mode, pm_All)
			'======================= 変更部分 2006.06.12 End =================================
			
			'チェックＮＧ
			If Rtn_Chk <> CHK_OK Then
				
				'ﾁｪｯｸ後移動なし
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
				
				F_Ctl_Head_Chk = Rtn_Chk
				Exit Function
			End If
		Next 
		
		'関連ﾁｪｯｸ
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		If Rtn_Chk = CHK_OK And pm_All.Dsp_Base.Head_Ok_Flg = False Then
			'チェックＯＫでかつ
			'ヘッダ部のチェックが初めての場合
			'フッタ部を開放する
			Call F_Foot_In_Ready(pm_All)
			'チェックＯＫ
			pm_All.Dsp_Base.Head_Ok_Flg = True
		End If
		
		F_Ctl_Head_Chk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CS
	'   概要：  検索画面表示
	'   引数：　pm_All          :全構造体
	'   戻値：　なし
	'   備考：  検索画面表示イメージをクリックした際の処理
	'           フォーカスは入力コントロールにあるままの状態
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CS(ByRef pm_All As Cls_All) As Short
		
		Dim Cursor_Index As Short
		Dim Trg_Index As Short
		
		'現在のフォーカス取得コントロールのインデックス
		Cursor_Index = pm_All.Dsp_Base.Cursor_Idx
		
		Select Case Cursor_Index
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End Select
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_WLS_Close
	'   概要：  各検索画面クローズ処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_WLS_Close() As Short
		
		F_Ctl_WLS_Close = 9
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		F_Ctl_WLS_Close = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Upd_Process
	'   概要：  更新メインルーチン
	'   引数：　なし
	'   戻値：　0 :更新終了　9:更新なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Upd_Process(ByRef pm_All As Cls_All) As Short
		
		Dim intRet As Short
		Dim intErrIdx As Short
		Dim strJdnNo As String
		Dim Index_Cnt As Short
		Dim Trg_Index As Short
		'2007/12/18 add-str M.SUEZAWA 訂正前に更新時間チェックを入れる
		Dim bolRet As Boolean
		'2007/12/18 add-end M.SUEZAWA
		' === 20080902 === INSERT S - RISE)Izumi
		Dim bolTrn As Boolean
		' === 20080902 === INSERT E - RISE)Izumi
		
		F_Ctl_Upd_Process = 9
		
		' === 20060808 === INSERT S - エンターキー連打による不具合修正２
		If gv_bolUpdFlg = True Then
			Exit Function
		End If
		
		gv_bolUpdFlg = True
		' === 20060808 === INSERT E
		
		' 2007/01/11  DLT START  KUMEDA   *** 権限チェック場所の変更
		'    '登録権限が無い場合
		'    If pv_InpTan_KNG = False Then
		'        gv_bolUpdFlg = False
		'        Exit Function
		'    End If
		' 2007/01/11  DLT END
		
		'砂時計にする
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'ボディ部のチェック
		intRet = F_Ctl_Body_Chk(pm_All)
		If intRet <> CHK_OK Then
			'チェックＮＧの場合
			GoTo End_F_Ctl_Upd_Process
		End If
		
		'訂正独自関連ﾁｪｯｸ
		intRet = F_Update_RelChk(pm_All, intErrIdx)
		If intRet <> CHK_OK Then
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intErrIdx), pm_All)
			GoTo Err_F_Ctl_Upd_Process
		End If
		
		'マウスポインタを戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'Windowsに処理を返す
		'    DoEvents
		
		'確認メッセージ表示
		intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_A_008, pm_All)
		
		'砂時計にする
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		Select Case intRet
			Case MsgBoxResult.Yes
				' 2007/01/11  ADD START  KUMEDA   *** 権限チェック場所の変更
				If pv_InpTan_KNG = False Then
					gv_bolUpdFlg = False
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_016, pm_All)
					GoTo End_F_Ctl_Upd_Process
				End If
				' 2007/01/11  ADD END
				
				' === 20080902 === INSERT S - RISE)Izumi  FOR UPDATE対応によりトランザクション開始位置変更
				'トランザクションの開始
				Call CF_Ora_BeginTrans(gv_Oss_USR1)
				bolTrn = True
				' === 20080902 === INSERT E - RISE)Izumi
				
				'2007/12/18 add-str M.SUEZAWA 訂正前に更新時間チェックを入れる
				'更新時間チェック
				bolRet = F_Chk_UWRTDTTM(pm_All)
				If bolRet = False Then
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_017, pm_All)
					F_Ctl_Upd_Process = 0
					GoTo End_F_Ctl_Upd_Process
				End If
				'2007/12/18 add-end M.SUEZAWA
				
				'ボタン非表示
				FR_SSSMAIN.CM_Execute.Visible = False
				
				'登録処理
				intRet = F_Update_Main(pm_All)
				If intRet <> 0 Then
					GoTo Err_F_Ctl_Upd_Process
				End If
				
				' === 20080902 === INSERT S - RISE)Izumi  FOR UPDATE対応によりトランザクション開始位置変更
				'コミット
				Call CF_Ora_CommitTrans(gv_Oss_USR1)
				bolTrn = False
				' === 20080902 === INSERT E - RISE)Izumi
				
				'ボディ項目の初期化
				For Index_Cnt = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
					'各画面の項目を初期化
					With pm_All.Dsp_Sub_Inf(Index_Cnt).Detail
						'前回内容をクリア
						'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Bef_Value = System.DBNull.Value
						'前回内容フラグをクリア
						.Bef_Value_Flg = VALUE_FLG_DEF
						
						'復元内容をクリア
						'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Rest_Value = System.DBNull.Value
						'復元内容フラグをクリア
						.Rest_Value_Flg = VALUE_FLG_DEF
						
						'ﾕｰｻﾞｰ入力無
						.In_Value_Flg = False
						
						'項目復元フラグＮＧ
						.Item_Rest_Flg = BODY_ROW_REST_FLG_NOT
						
						'未入力以外のチェック済フラグ
						.Not_Input_Chk_Fin_Flg = False
					End With
					
					'復元内容、前回内容を退避
					Call CF_Set_Bef_Rest_Value(pm_All.Dsp_Sub_Inf(Index_Cnt))
				Next 
				
			Case Else ' 戻る
				GoTo End_F_Ctl_Upd_Process
		End Select
		
		'正常メッセージ表示
		intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_009, pm_All)
		
		F_Ctl_Upd_Process = 0
		
End_F_Ctl_Upd_Process: 
		
		' === 20080902 === INSERT S - RISE)Izumi  FOR UPDATE対応によりトランザクション開始位置変更
		If bolTrn = True Then
			'ロールバック
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
			bolTrn = False
		End If
		' === 20080902 === INSERT E - RISE)Izumi
		
		'マウスポインタを戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'ボタン表示
		FR_SSSMAIN.CM_Execute.Visible = True
		
		' === 20060808 === INSERT S - エンターキー連打による不具合修正２
		gv_bolUpdFlg = False
		
		'キーフラグを元に戻す
		gv_bolKeyFlg = False
		' === 20060808 === INSERT E
		
		Exit Function
		
Err_F_Ctl_Upd_Process: 
		
		GoTo End_F_Ctl_Upd_Process
		
	End Function
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Upd_Process2
	'   概要：  更新メインルーチン
	'   引数：　なし
	'   戻値：　0 :更新終了　9:更新なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Upd_Process2(ByRef pm_All As Cls_All) As Short
		
		Dim intRet As Short
		Dim intErrIdx As Short
		Dim strJdnNo As String
		Dim Index_Cnt As Short
		Dim Trg_Index As Short
		Dim Col_Index As Short
		'2007/12/18 add-str M.SUEZAWA 訂正前に更新時間チェックを入れる
		Dim bolRet As Boolean
		'2007/12/18 add-end M.SUEZAWA
		' === 20080902 === INSERT S - RISE)Izumi
		Dim bolTrn As Boolean
		' === 20080902 === INSERT E - RISE)Izumi
		
		F_Ctl_Upd_Process2 = 9
		
		' === 20060808 === INSERT S - エンターキー連打による不具合修正２
		If gv_bolUpdFlg = True Then
			Exit Function
		End If
		
		gv_bolUpdFlg = True
		' === 20060808 === INSERT E
		
		' 2007/01/11  DLT START  KUMEDA   *** 権限チェック場所の変更
		'    '登録権限が無い場合
		'    If pv_InpTan_KNG = False Then
		'        F_Ctl_Upd_Process2 = 0
		'        gv_bolUpdFlg = False
		'        Exit Function
		'    End If
		' 2007/01/11  DLT END
		
		'砂時計にする
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'ボディ部のチェック
		intRet = F_Ctl_Body_Chk(pm_All)
		If intRet <> CHK_OK Then
			'チェックＮＧの場合
			GoTo End_F_Ctl_Upd_Process2
		End If
		
		'訂正独自関連ﾁｪｯｸ
		intRet = F_Update_RelChk(pm_All, intErrIdx)
		If intRet <> CHK_OK Then
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(intErrIdx), pm_All)
			GoTo Err_F_Ctl_Upd_Process2
		End If
		
		'マウスポインタを戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'Windowsに処理を返す
		'    DoEvents
		
		If gv_bolKNGMT51_INIT = True Then
			'確認メッセージ表示
			intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_A_012, pm_All)
		End If
		
		'砂時計にする
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		Select Case intRet
			Case MsgBoxResult.Yes
				' 2007/01/11  ADD START  KUMEDA   *** 権限チェック場所の変更
				If pv_InpTan_KNG = False Then
					gv_bolUpdFlg = False
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_016, pm_All)
					GoTo End_F_Ctl_Upd_Process2
				End If
				' 2007/01/11  ADD END
				
				' === 20080902 === INSERT S - RISE)Izumi  FOR UPDATE対応によりトランザクション開始位置変更
				'トランザクションの開始
				Call CF_Ora_BeginTrans(gv_Oss_USR1)
				bolTrn = True
				' === 20080902 === INSERT E - RISE)Izumi
				
				'2007/12/18 add-str M.SUEZAWA 訂正前に更新時間チェックを入れる
				'更新時間チェック
				bolRet = F_Chk_UWRTDTTM(pm_All)
				If bolRet = False Then
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_017, pm_All)
					F_Ctl_Upd_Process2 = 0
					GoTo End_F_Ctl_Upd_Process2
				End If
				'2007/12/18 add-end M.SUEZAWA
				
				'ボタン非表示
				FR_SSSMAIN.CM_Execute.Visible = False
				
				'登録処理
				intRet = F_Update_Main(pm_All)
				If intRet <> 0 Then
					GoTo Err_F_Ctl_Upd_Process2
				End If
				
				' === 20080902 === INSERT S - RISE)Izumi  FOR UPDATE対応によりトランザクション開始位置変更
				'コミット
				Call CF_Ora_CommitTrans(gv_Oss_USR1)
				bolTrn = False
				' === 20080902 === INSERT E - RISE)Izumi
				
				'ボディ項目の初期化
				For Index_Cnt = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
					'各画面の項目を初期化
					With pm_All.Dsp_Sub_Inf(Index_Cnt).Detail
						'前回内容をクリア
						'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Bef_Value = System.DBNull.Value
						'前回内容フラグをクリア
						.Bef_Value_Flg = VALUE_FLG_DEF
						
						'復元内容をクリア
						'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Rest_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						.Rest_Value = System.DBNull.Value
						'復元内容フラグをクリア
						.Rest_Value_Flg = VALUE_FLG_DEF
						
						'ﾕｰｻﾞｰ入力無
						.In_Value_Flg = False
						
						'項目復元フラグＮＧ
						.Item_Rest_Flg = BODY_ROW_REST_FLG_NOT
						
						'未入力以外のチェック済フラグ
						.Not_Input_Chk_Fin_Flg = False
					End With
					
					'復元内容、前回内容を退避
					Call CF_Set_Bef_Rest_Value(pm_All.Dsp_Sub_Inf(Index_Cnt))
				Next 
				
				'正常メッセージ表示
				intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_009, pm_All)
				
			Case MsgBoxResult.No
				'登録せずに処理継続
				gv_bolKNGMT51_INIT = False
				
			Case MsgBoxResult.Cancel
				'処理中止
				GoTo End_F_Ctl_Upd_Process2
				
			Case Else
				'メッセージ表示なし
				
		End Select
		
		F_Ctl_Upd_Process2 = 0
		
End_F_Ctl_Upd_Process2: 
		
		' === 20080902 === INSERT S - RISE)Izumi  FOR UPDATE対応によりトランザクション開始位置変更
		If bolTrn = True Then
			'ロールバック
			Call CF_Ora_RollbackTrans(gv_Oss_USR1)
			bolTrn = False
		End If
		' === 20080902 === INSERT E - RISE)Izumi
		
		'マウスポインタを戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'ボタン表示
		FR_SSSMAIN.CM_Execute.Visible = True
		
		' === 20060808 === INSERT S - エンターキー連打による不具合修正２
		gv_bolUpdFlg = False
		
		'キーフラグを元に戻す
		gv_bolKeyFlg = False
		' === 20060808 === INSERT E
		
		Exit Function
		
Err_F_Ctl_Upd_Process2: 
		
		GoTo End_F_Ctl_Upd_Process2
		
	End Function
	' === 20060825 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Body_Chk
	'   概要：  ﾎﾞﾃﾞｨ部のﾁｪｯｸﾙｰﾁﾝ制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Body_Chk(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk_Col As Short
		Dim Index_Wk_Row As Short
		Dim Trg_Index As Short
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Sub_Inf_Wk As Cls_Dsp_Sub_Inf
		Dim Dsp_Mode As Short
		
		Dim Err_Row As Short
		Dim Err_Dsp_Sub_Inf_Wk As Cls_Dsp_Sub_Inf
		Dim Bd_Idx As Short
		Dim Err_Index As Short
		Dim Move_Flg As Boolean
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim intMoveFocus As Short
		Dim intErrRow As Short
		Dim curUodKn As Decimal
		Dim curZeiKn As Decimal
		'UPGRADE_WARNING: 構造体 Row_inf_Zero の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Row_inf_Zero As Cls_Dsp_Body_Row_Inf
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		
		pv_bolMEISAI_INPUT = False
		pv_intMeisaiCnt = 0
		pv_bolInput_Bef_Row = True
		
		'ゼロ行目情報退避
		'UPGRADE_WARNING: オブジェクト Row_inf_Zero の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Row_inf_Zero = pm_All.Dsp_Body_Inf.Row_Inf(0)
		
		'ボディ部の最終項目まで各項目のﾁｪｯｸを行う
		For Index_Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			
			Select Case pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Status
				'            Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT, BODY_ROW_STATE_LST_ROW
				'                '入力待状態、入力済状態、最終準備行を対象
				Case BODY_ROW_STATE_INPUT_WAIT, BODY_ROW_STATE_INPUT
					'入力待状態、入力済状態を対象
					
					'隠行に画面明細の対象行をコピー
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(0))
					
					For Index_Wk_Col = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail)
						
						'画面明細の隠行の項目のｲﾝﾃﾞｯｸｽを取得
						Trg_Index = CF_Get_Idex_Same_Bd_Ctl_Hide_Row(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Item_Nm, pm_All)
						
						'ワークの｢画面項目情報｣に隠行ｺﾝﾄﾛｰﾙを割当
						Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(Trg_Index).Ctl
						
						'ワークの｢画面項目情報｣に｢画面ボディ情報｣を編集
						Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Dsp_Value, Dsp_Sub_Inf_Wk, pm_All)
						'画面項目詳細情報を設定
						'UPGRADE_WARNING: オブジェクト Dsp_Sub_Inf_Wk.Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Dsp_Sub_Inf_Wk.Detail = pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col)
						
						'各項目ﾁｪｯｸを全体ﾁｪｯｸとして呼出
						Rtn_Chk = F_Ctl_Item_Chk(Dsp_Sub_Inf_Wk, CHK_FROM_ALL_CHK, Chk_Move_Flg, pm_All)
						
						If Rtn_Chk = CHK_OK Then
							'チェックＯＫ時
							'取得内容表示
							Dsp_Mode = DSP_SET
						Else
							'チェックＮＧ時
							'取得内容クリア
							Dsp_Mode = DSP_CLR
						End If
						
						'取得内容表示/クリア
						Call F_Dsp_Item_Detail(Dsp_Sub_Inf_Wk, Dsp_Mode, pm_All)
						
						'｢画面ボディ情報｣にワークの｢画面項目情報｣を編集
						'画面項目詳細情報を設定
						'条件によって変更される項目のみ
						Call CF_Dsp_Sub_Inf_To_Dsp_Body_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col), Dsp_Sub_Inf_Wk.Detail)
						
						'チェックＮＧ
						Select Case Rtn_Chk
							'OKの場合
							Case CHK_OK
								
								'未入力
							Case CHK_ERR_NOT_INPUT
								
							Case Else
								
								'エラーの場合、対象行を表示しﾌｫｰｶｽ移動する
								'エラー用変数格納
								'行情報
								Err_Row = Index_Wk_Row
								'対象ｺﾝﾄﾛｰﾙ情報
								Err_Dsp_Sub_Inf_Wk.Ctl = Dsp_Sub_Inf_Wk.Ctl
								'画面項目詳細情報を設定
								'UPGRADE_WARNING: オブジェクト Err_Dsp_Sub_Inf_Wk.Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								Err_Dsp_Sub_Inf_Wk.Detail = Dsp_Sub_Inf_Wk.Detail
								
								GoTo ERR_EXIT
						End Select
						
					Next 
					
					'関連ﾁｪｯｸ
					Rtn_Chk = F_Ctl_Body_RelChk(Index_Wk_Row, pm_All, intMoveFocus, intErrRow)
					'チェックＮＧ
					If Rtn_Chk <> CHK_OK Then
						
						F_Ctl_Body_Chk = Rtn_Chk
						'エラー用変数格納
						Err_Row = intErrRow
						'対象ｺﾝﾄﾛｰﾙ情報
						Err_Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(intMoveFocus).Ctl
						'画面項目詳細情報を設定
						'UPGRADE_WARNING: オブジェクト Err_Dsp_Sub_Inf_Wk.Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Err_Dsp_Sub_Inf_Wk.Detail = pm_All.Dsp_Sub_Inf(intMoveFocus).Detail
						
						GoTo ERR_EXIT
					End If
					
					'画面明細の対象行に隠行をコピー(元に戻す)
					Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(0), pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row))
			End Select
		Next 
		
		'    '明細行に入力がない場合、エラー
		'    If pv_bolMEISAI_INPUT = False Then
		'
		'        'エラーメッセージ表示
		'        Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgUODET52_E_046, pm_All)
		'
		'        'ﾁｪｯｸ後移動なし
		'        Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(FR_SSSMAIN.BD_HINCD(1).Tag), pm_All)
		'
		'        F_Ctl_Body_Chk = CHK_ERR_ELSE
		'        Exit Function
		'
		'    End If
		
		F_Ctl_Body_Chk = Rtn_Chk
		
		Exit Function
		
ERR_EXIT: 
		'エラー時、ﾌｫｰｶｽ移動
		'対象行を画面に表示
		Call CF_Body_Dsp_Trg_Row(pm_All, Err_Row)
		'コントロール制御
		Call F_Set_Body_Enable(pm_All)
		'対象行から画面明細の行を取得
		Bd_Idx = CF_Idx_To_Bd_Idx(Err_Row, pm_All)
		'画面明細の行と同一の明細をインデックスを取得
		Err_Index = CF_Get_Idex_Same_Bd_Ctl(Err_Dsp_Sub_Inf_Wk, Bd_Idx, pm_All)
		
		If Err_Index > 0 Then
			'同一項目の１つ前からENTキー押下と同様に次の項目へ
			Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Err_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			'選択状態の設定（初期選択）
			Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Err_Index - 1), SEL_INI_MODE_2)
			'項目色設定
			Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Err_Index - 1), ITEM_NORMAL_STATUS, pm_All)
			
		Else
			'入力可能な最初のインデックスを取得
			Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Err_Row, pm_All)
			If Focus_Ctl_Ok_Fst_Idx > 0 Then
				'同一項目の１つ前からENTキー押下と同様に次の項目へ
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
		End If
		
		F_Ctl_Body_Chk = Rtn_Chk
		Exit Function
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_Body_RelChk
	'   概要：  ﾎﾞﾃﾞｨ部の関連ﾁｪｯｸ
	'   引数：　pm_intRow : チェック対象明細行
	'         　pm_all    : 画面情報
	'   戻値：　CHK_OK:チェックOK　CHK_ERR_ELSE:その他エラー
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_Body_RelChk(ByRef pm_intRow As Short, ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short, ByRef pm_ErrRow As Short) As Short
		
		Dim Index_Wk As Short
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Trg_Index As Short
		Dim Err_Cd As String 'エラーコード
		Dim intUPDKB As Short
		Dim intUPDAUTH As Short
		Dim intPRTAUTH As Short
		Dim intFILEAUTH As Short
		Dim intSALTAUTH As Short
		Dim intHDNTAUTH As Short
		Dim intSAPMAUTH As Short
		Dim bolCheck As Boolean
		Dim bolNotInput As Boolean
		Dim strKbn As String
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_ERR_ELSE
		Err_Cd = ""
		pm_ErrRow = pm_intRow
		pm_ErrIdx = CShort(FR_SSSMAIN.BD_UPDAUTH(1).Tag)
		bolNotInput = False
		
		'１行チェック
		intUPDKB = CShort(FR_SSSMAIN.BD_UPDKB(0).Tag)
		intUPDAUTH = CShort(FR_SSSMAIN.BD_UPDAUTH(0).Tag)
		intPRTAUTH = CShort(FR_SSSMAIN.BD_PRTAUTH(0).Tag)
		intFILEAUTH = CShort(FR_SSSMAIN.BD_FILEAUTH(0).Tag)
		intSALTAUTH = CShort(FR_SSSMAIN.BD_SALTAUTH(0).Tag)
		intHDNTAUTH = CShort(FR_SSSMAIN.BD_HDNTAUTH(0).Tag)
		intSAPMAUTH = CShort(FR_SSSMAIN.BD_SAPMAUTH(0).Tag)
		
		bolCheck = False
		'１行に必要な情報が入力されている場合、OK
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDAUTH))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intPRTAUTH))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFILEAUTH))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSALTAUTH))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intHDNTAUTH))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSAPMAUTH))) <> "" Then
			bolCheck = True
			pv_bolMEISAI_INPUT = True
			pv_intMeisaiCnt = pv_intMeisaiCnt + 1
			
		Else
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Select Case True
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDAUTH))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_UPDAUTH(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intPRTAUTH))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_PRTAUTH(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFILEAUTH))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_FILEAUTH(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSALTAUTH))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_SALTAUTH(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intHDNTAUTH))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_HDNTAUTH(1).Tag)
				Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSAPMAUTH))) = ""
					pm_ErrIdx = CShort(FR_SSSMAIN.BD_SAPMAUTH(1).Tag)
			End Select
		End If
		
		'１行全部未入力の場合OK
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If bolCheck = False And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDAUTH))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intPRTAUTH))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intFILEAUTH))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSALTAUTH))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intHDNTAUTH))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSAPMAUTH))) = "" Then
			
			'かつ「入力済み状態」"でない"場合
			If pm_All.Dsp_Body_Inf.Row_Inf(pm_intRow).Status <> BODY_ROW_STATE_INPUT Then
				bolCheck = True
				bolNotInput = True
			End If
		End If
		
		If bolCheck = False Then
			Err_Cd = gc_strMsgKNGMT51_E_010
			GoTo F_Ctl_Body_RelChk_END
		End If
		
		'未入力の場合、後のチェックは無し
		If bolNotInput = True Then
			pv_bolInput_Bef_Row = False
			Rtn_Chk = CHK_OK
			GoTo F_Ctl_Body_RelChk_END
		Else
			'未入力以外で前の行が未入力の場合エラー
			If pv_bolInput_Bef_Row = False Then
				Err_Cd = gc_strMsgKNGMT51_E_010
				pm_ErrRow = pm_intRow - 1
				GoTo F_Ctl_Body_RelChk_END
			End If
		End If
		
		Rtn_Chk = CHK_OK
		
F_Ctl_Body_RelChk_END: 
		
		If Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		
		F_Ctl_Body_RelChk = Rtn_Chk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Body_Enable
	'   概要：  最上明細ｲﾝﾃﾞｯｸｽ(pm_All.Dsp_Body_Inf.Cur_Top_Index)を基準に
	'   　　　　明細行のｺﾝﾄﾛｰﾙ制御を行う
	'   引数：　pm_All　: 画面情報
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Body_Enable(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Bd_Index As Short
		Dim Bd_Index_Bk As Short
		Dim Bd_Col_Index As Short
		Dim Bd_Row_Index As Short
		Dim Focus_Ctl As Boolean
		Dim Wk_Row As Short
		Dim Wk_Index As Short
		Dim InpRow As Short
		
		Bd_Row_Index = 0
		
		If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'明細表示の画面
			
			'ボディ部内で処理
			Bd_Index = 0
			Bd_Index_Bk = 0
			
			For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
					
					Wk_Row = pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index
					'pm_All.Dsp_Body_Infの行ＮＯを取得
					Bd_Index = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					If Bd_Index_Bk <> Bd_Index Then
						'明細行ブレイク
						Bd_Col_Index = 1
						Bd_Index_Bk = Bd_Index
						Bd_Row_Index = Bd_Row_Index + 1
					Else
						Bd_Col_Index = Bd_Col_Index + 1
					End If
					
					'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
					'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
					
				End If
			Next 
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Update_RelChk
	'   概要：  訂正独自関連ﾁｪｯｸ
	'   引数：　pm_all    : 画面情報
	'   戻値：　CHK_OK:チェックOK　CHK_ERR_ELSE:その他エラー
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Update_RelChk(ByRef pm_All As Cls_All, ByRef pm_ErrIdx As Short) As Short
		
		Dim intRet As Short
		Dim Trg_Index As Short
		Dim Err_Cd As String 'エラーコード
		
		On Error GoTo F_Update_RelChk_Err
		
		intRet = CHK_ERR_ELSE
		
		
		
		intRet = CHK_OK
		
F_Update_RelChk_End: 
		
		If Trim(Err_Cd) <> "" Then
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
		End If
		F_Update_RelChk = intRet
		Exit Function
		
F_Update_RelChk_Err: 
		
		intRet = CHK_ERR_ELSE
		GoTo F_Update_RelChk_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Update_Main
	'   概要：  更新メイン処理
	'   引数：  pm_All        : 画面情報
	'   戻値：　処理結果ステータス
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Update_Main(ByRef pm_All As Cls_All) As Short
		
		Dim intRet As Short
		Dim bolTrn As Boolean
		Dim intCnt As Short
		Dim strErrMsg As String
		Dim strCTLCD As String
		Dim Trg_Index As Short
		Dim Upd_Start As Short
		Dim Upd_End As Short
		Dim Mst_Inf As TYPE_DB_KNGMTB
		
		' On Error GoTo F_Update_Main_Err
		
		intRet = CHK_OK
		bolTrn = False
		
		'更新時刻取得
		Call CF_Get_SysDt()
		
		'ループ開始、終了の計算
		Upd_Start = pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1) + 1
		Upd_End = pm_All.Dsp_Base.Dsp_Body_Cnt * NowPageNum
		
		' === 20080902 === DELETE S - RISE)Izumi  FOR UPDATE対応によりトランザクション開始位置の変更
		'    'トランザクションの開始
		'    Call CF_Ora_BeginTrans(gv_Oss_USR1)
		'    bolTrn = True
		' === 20080902 === DELETE E - RISE)Izumi
		'ADD START FKS)INABA 2009/10/08 **************************
		'連絡票№FC09101403
		Upd_Start = 1
		Upd_End = pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum
		'ADD  END  FKS)INABA 2009/10/08 **************************
		For intCnt = Upd_Start To Upd_End
			If pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Status = BODY_ROW_STATE_INPUT Then
				'DEL START FKS)INABA 2009/10/08 **************************
				'連絡票№FC09101403
				'' 2006/11/15  ADD START  KUMEDA
				'            If pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(pc_COL_UPDATE).Dsp_Value = "1" Then
				'' 2006/11/15  ADD END
				'DEL  END  FKS)INABA 2009/10/08 **************************
				'権限マスタ更新
				intRet = F_KNGMTB_Update(intCnt, pm_All)
				
				If intRet <> 0 Then
					GoTo F_Update_Main_Err
				End If
				'DEL START FKS)INABA 2009/10/08 **************************
				'連絡票№FC09101403
				'' 2006/11/15  ADD START  KUMEDA
				'            End If
				'' 2006/11/15  ADD END
				'DEL  END  FKS)INABA 2009/10/08 **************************
			End If
			
		Next intCnt
		
		' === 20080902 === DELETE S - RISE)Izumi  FOR UPDATE対応によりトランザクション開始位置の変更
		'    'コミット
		'    Call CF_Ora_CommitTrans(gv_Oss_USR1)
		'    bolTrn = False
		' === 20080902 === DELETE E - RISE)Izumi
		
		intRet = CHK_OK
		
F_Update_Main_End: 
		
		' === 20080902 === DELETE S - RISE)Izumi  FOR UPDATE対応によりトランザクション開始位置の変更
		'    If bolTrn = True Then
		'        'ロールバック
		'        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		'        bolTrn = False
		'    End If
		' === 20080902 === DELETE E - RISE)Izumi
		
		F_Update_Main = intRet
		Exit Function
		
F_Update_Main_Err: 
		
		intRet = CHK_ERR_ELSE
		GoTo F_Update_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_KNGMTB_Update
	'   概要：  権限マスタ更新処理
	'   引数：  pm_intCnt   : 配列番号
	'           pm_All      : 全構造体
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_KNGMTB_Update(ByRef pm_intCnt As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		On Error GoTo F_KNGMTB_Update_err
		
		F_KNGMTB_Update = 9
		'ADD START FKS)INABA 2009/10/08 *************************************
		'連絡票№FC09101403
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim ll_cnt As Short
		Dim ls_pgid As String
		'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ls_pgid = Trim(CF_Ora_String(pm_All.Dsp_Body_Inf.Row_Inf(pm_intCnt).Item_Detail(pc_COL_PGID).Dsp_Value, 8))
		If ls_pgid = "" Then
			F_KNGMTB_Update = 0
			Exit Function
		End If
		strSQL = ""
		strSQL = strSQL & " SELECT COUNT(*) CNT_1 "
		strSQL = strSQL & "   FROM  KNGMTB  "
		strSQL = strSQL & "  WHERE KNGGRCD = '" & CF_Ora_String(pv_KNGMT51_KNGGRCD, 3) & "' "
		'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "    AND PGID    = '" & Trim(CF_Ora_String(pm_All.Dsp_Body_Inf.Row_Inf(pm_intCnt).Item_Detail(pc_COL_PGID).Dsp_Value, 8)) & "' "
		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ll_cnt = CF_Ora_GetDyn(Usr_Ody, "CNT_1", 0)
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		If ll_cnt = 0 Then
			With pm_All.Dsp_Body_Inf.Row_Inf(pm_intCnt)
				strSQL = ""
				strSQL = strSQL & " INSERT INTO KNGMTB VALUES("
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & " '" & CF_Ora_String(.Item_Detail(pc_COL_DATKB).Dsp_Value, 1) & "' " '(01)起動
				strSQL = strSQL & ",'" & CF_Ora_String(pv_KNGMT51_KNGGRCD, 3) & "' " '(02)権限グループ
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & ",'" & Trim(CF_Ora_String(.Item_Detail(pc_COL_PGID).Dsp_Value, 8)) & "' " '(03)プログラムＩＤ
				strSQL = strSQL & ",'" & .Bus_Inf.UPDFLG & "' " '(04)更新権限変更可能フラグ
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & ",'" & CF_Ora_String(.Item_Detail(pc_COL_UPDAUTH).Dsp_Value, 1) & "' " '(05)更新権限
				strSQL = strSQL & ",'" & .Bus_Inf.PRTFLG & "'" '(06)印刷権限変更可能フラグ
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & ",'" & CF_Ora_String(.Item_Detail(pc_COL_PRTAUTH).Dsp_Value, 1) & "' " '(07)印刷
				strSQL = strSQL & ",'" & .Bus_Inf.FILEFLG & "'" '(08)ファイル出力権限変更可能フラグ
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & ",'" & CF_Ora_String(.Item_Detail(pc_COL_FILEAUTH).Dsp_Value, 1) & "' " '(09)ファイル出力
				strSQL = strSQL & ",'" & .Bus_Inf.SALTFLG & "'" '(10)販売単価変更権限変更可能フラグ
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & ",'" & CF_Ora_String(.Item_Detail(pc_COL_SALTAUTH).Dsp_Value, 1) & "' " '(11)販売単価変更
				strSQL = strSQL & ",'" & .Bus_Inf.HDNTFLG & "'" '(12)発注単価変更権限変更可能フラグ
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & ",'" & CF_Ora_String(.Item_Detail(pc_COL_HDNTAUTH).Dsp_Value, 1) & "' " '(13)発注単価変更
				strSQL = strSQL & ",'" & .Bus_Inf.SAPMFLG & "'" '(14)販売計画年初計画修正権限変更可能フラグ
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & ",'" & CF_Ora_String(.Item_Detail(pc_COL_SAPMAUTH).Dsp_Value, 1) & "' " '(15)販売計画年初計画修正
				strSQL = strSQL & ",'" & CF_Ora_String("", 1) & "' " '(16)連携フラグ
				strSQL = strSQL & ",'" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '(17)初回登録ユーザ
				strSQL = strSQL & ",'" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '(18)初回登録クライアントＩＤ
				strSQL = strSQL & ",'" & GV_SysTime & "' " '(19)タイムスタンプ（初回登録時間）
				strSQL = strSQL & ",'" & GV_SysDate & "' " '(20)タイムスタンプ（初回登録日付）
				strSQL = strSQL & ",'" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '(21)最終作業者コード
				strSQL = strSQL & ",'" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '(22)クライアントＩＤ
				strSQL = strSQL & ",'" & GV_SysTime & "' " '(23)タイムスタンプ（時間）
				strSQL = strSQL & ",'" & GV_SysDate & "' " '(24)タイムスタンプ（日付）
				strSQL = strSQL & ",'" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '(25)最終作業者コード（バッチ）
				strSQL = strSQL & ",'" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " '(26)クライアントＩＤ（バッチ）
				strSQL = strSQL & ",'" & GV_SysTime & "' " '(27)タイムスタンプ（バッチ時間）
				strSQL = strSQL & ",'" & GV_SysDate & "' " '(28)タイムスタンプ（バッチ日付）
				strSQL = strSQL & " )"
			End With
		Else
			'ADD  END  FKS)INABA 2009/10/08 *************************************
			'権限マスタ更新
			With pm_All.Dsp_Body_Inf.Row_Inf(pm_intCnt)
				strSQL = ""
				strSQL = strSQL & " Update KNGMTB "
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "    Set UPDAUTH     = '" & CF_Ora_String(.Item_Detail(pc_COL_UPDAUTH).Dsp_Value, 1) & "' " '更新
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "      , PRTAUTH     = '" & CF_Ora_String(.Item_Detail(pc_COL_PRTAUTH).Dsp_Value, 1) & "' " '印刷
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "      , FILEAUTH    = '" & CF_Ora_String(.Item_Detail(pc_COL_FILEAUTH).Dsp_Value, 1) & "' " 'ファイル出力
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "      , SALTAUTH    = '" & CF_Ora_String(.Item_Detail(pc_COL_SALTAUTH).Dsp_Value, 1) & "' " '販売単価変更
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "      , HDNTAUTH    = '" & CF_Ora_String(.Item_Detail(pc_COL_HDNTAUTH).Dsp_Value, 1) & "' " '発注単価変更
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "      , SAPMAUTH    = '" & CF_Ora_String(.Item_Detail(pc_COL_SAPMAUTH).Dsp_Value, 1) & "' " '販売計画年初計画修正
				' 2006/11/21  ADD START  KUMEDA
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "      , DATKB       = '" & CF_Ora_String(.Item_Detail(pc_COL_DATKB).Dsp_Value, 1) & "' " '起動
				' 2006/11/21  ADD END
				strSQL = strSQL & "      , RELFL       = '" & CF_Ora_String("", 1) & "' " '連携フラグ
				strSQL = strSQL & "      , OPEID       = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
				strSQL = strSQL & "      , CLTID       = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ
				strSQL = strSQL & "      , WRTTM       = '" & GV_SysTime & "' " 'タイムスタンプ（時間）
				strSQL = strSQL & "      , WRTDT       = '" & GV_SysDate & "' " 'タイムスタンプ（日付）
				' 2006/11/19  ADD START  KUMEDA
				strSQL = strSQL & "      , UOPEID      = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード（バッチ）
				strSQL = strSQL & "      , UCLTID      = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（バッチ）
				strSQL = strSQL & "      , UWRTTM      = '" & GV_SysTime & "' " 'タイムスタンプ（バッチ時間）
				strSQL = strSQL & "      , UWRTDT      = '" & GV_SysDate & "' " 'タイムスタンプ（バッチ日付）
				' 2006/11/19  ADD END
				'ADD START FKS)INABA 2009/10/08 *************************************
				'連絡票№FC09101403
				strSQL = strSQL & ",UPDFLG = '" & .Bus_Inf.UPDFLG & "' " '(04)更新権限変更可能フラグ
				strSQL = strSQL & ",PRTFLG = '" & .Bus_Inf.PRTFLG & "'" '(06)印刷権限変更可能フラグ
				strSQL = strSQL & ",FILEFLG ='" & .Bus_Inf.FILEFLG & "'" '(08)ファイル出力権限変更可能フラグ
				strSQL = strSQL & ",SALTFLG ='" & .Bus_Inf.SALTFLG & "'" '(10)販売単価変更権限変更可能フラグ
				strSQL = strSQL & ",HDNTFLG ='" & .Bus_Inf.HDNTFLG & "'" '(12)発注単価変更権限変更可能フラグ
				strSQL = strSQL & ",SAPMFLG ='" & .Bus_Inf.SAPMFLG & "'" '(14)販売計画年初計画修正権限変更可能フラグ
				'ADD  END  FKS)INABA 2009/10/08 *************************************
				strSQL = strSQL & "  Where KNGGRCD     = '" & CF_Ora_String(pv_KNGMT51_KNGGRCD, 3) & "' " '権限グループ
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "    And PGID        = '" & CF_Ora_String(.Item_Detail(pc_COL_PGID).Dsp_Value, 8) & "' " 'プログラムＩＤ
			End With
			'ADD START FKS)INABA 2009/10/08 *************************************
			'連絡票№FC09101403
		End If
		'ADD  END  FKS)INABA 2009/10/08 *************************************
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_KNGMTB_Update_err
		End If
		
		F_KNGMTB_Update = 0
		
F_KNGMTB_Update_End: 
		Exit Function
		
F_KNGMTB_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgKNGMT51_E_011, pm_All, "F_KNGMTB_Update")
		GoTo F_KNGMTB_Update_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Foot_In_Ready
	'   概要：  フッタ部の入力準備
	'   引数：　pm_All      : 全構造体
	'   戻値：　なし
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Foot_In_Ready(ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		
		'フッタ部内で処理
		For Index_Wk = pm_All.Dsp_Base.Foot_Fst_Idx To pm_All.Dsp_Base.Item_Cnt
			Select Case pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Name
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				' === 20060825 === DELETE S
				'            '初期状態で入力可能なｺﾝﾄﾛｰﾙ
				'                '入力可能
				'                Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Index_Wk))
				' === 20060825 === DELETE E
			End Select
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_MN_Enabled
	'   概要：  メニュー使用可否制御
	'   引数：　pm_All        : 全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_MN_Enabled(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Wk_Index As Short
		
		F_Ctl_MN_Enabled = 9
		
		'現在のフォーカス位置に応じて、各ｺﾝﾄﾛｰﾙの使用可否を制御
		Select Case pm_All.Dsp_Base.Cursor_Idx
			Case Else
				'登録
				Trg_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'            '終了
				'            Trg_Index = CInt(FR_SSSMAIN.MN_EndCm.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'            '画面初期化
				'            Trg_Index = CInt(FR_SSSMAIN.MN_APPENDC.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '項目初期化
				'            Trg_Index = CInt(FR_SSSMAIN.MN_ClearItm.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '項目復元
				'            Trg_Index = CInt(FR_SSSMAIN.MN_UnDoItem.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '明細行初期化
				'            Trg_Index = CInt(FR_SSSMAIN.MN_ClearDE.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '明細行削除
				'            Trg_Index = CInt(FR_SSSMAIN.MN_DeleteDE.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '明細行挿入
				'            Trg_Index = CInt(FR_SSSMAIN.MN_InsertDE.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '明細行復元
				'            Trg_Index = CInt(FR_SSSMAIN.MN_UnDoDe.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '切り取り
				'            Trg_Index = CInt(FR_SSSMAIN.MN_Cut.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            'コピー
				'            Trg_Index = CInt(FR_SSSMAIN.MN_Copy.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '貼り付け
				'            Trg_Index = CInt(FR_SSSMAIN.MN_Paste.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '前頁
				'            Trg_Index = CInt(FR_SSSMAIN.MN_Prev.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '次頁
				'            Trg_Index = CInt(FR_SSSMAIN.MN_NextCm.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            '一覧表示
				'            Trg_Index = CInt(FR_SSSMAIN.MN_SelectCm.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'            'ウインドウ表示
				'            Trg_Index = CInt(FR_SSSMAIN.MN_Slist.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				'            'モード変更
				'            Trg_Index = CInt(FR_SSSMAIN.MN_UPDKB.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
				
		End Select
		
		'メニューボタンイメージの可視制御
		'終了ボタン
		Trg_Index = CShort(FR_SSSMAIN.CM_EndCm.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_EndCm.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'登録ボタン
		Trg_Index = CShort(FR_SSSMAIN.CM_Execute.Tag)
		'    Wk_Index = CInt(FR_SSSMAIN.MN_Execute.Tag)
		'' 2007/01/11  START 元に戻す
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		''    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = pv_InpTan_KNG
		'' 2007/01/11  END
		'    '明細行挿入ボタン
		'    Trg_Index = CInt(FR_SSSMAIN.CM_INSERTDE.Tag)
		'    Wk_Index = CInt(FR_SSSMAIN.MN_InsertDE.Tag)
		'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'    '明細行削除ボタン
		'    Trg_Index = CInt(FR_SSSMAIN.CM_DELETEDE.Tag)
		'    Wk_Index = CInt(FR_SSSMAIN.MN_DeleteDE.Tag)
		'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'    '検索ボタン
		'    Trg_Index = CInt(FR_SSSMAIN.CM_SLIST.Tag)
		'    Wk_Index = CInt(FR_SSSMAIN.MN_Slist.Tag)
		'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'前頁ボタン
		Trg_Index = CShort(FR_SSSMAIN.CM_PREV.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Prev.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'次頁ボタン
		Trg_Index = CShort(FR_SSSMAIN.CM_NEXTCm.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_NextCm.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'    '一覧表示ボタン
		'    Trg_Index = CInt(FR_SSSMAIN.CM_SelectCm.Tag)
		'    Wk_Index = CInt(FR_SSSMAIN.MN_SelectCm.Tag)
		'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		
		F_Ctl_MN_Enabled = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_PageButton_Enabled
	'   概要：  前ページ・次ページ使用可否制御
	'   引数：　pm_All           : 全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_PageButton_Enabled(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Wk_Index As Short
		
		F_Ctl_PageButton_Enabled = 9
		
		'前頁
		Trg_Index = CShort(FR_SSSMAIN.MN_Prev.Tag)
		If NowPageNum > MinPageNum Then
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
		Else
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
		End If
		'次頁
		Trg_Index = CShort(FR_SSSMAIN.MN_NextCm.Tag)
		If NowPageNum < MaxPageNum Then
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
		Else
			pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
		End If
		
		'前頁ボタン
		Trg_Index = CShort(FR_SSSMAIN.CM_PREV.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_Prev.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		'次頁ボタン
		Trg_Index = CShort(FR_SSSMAIN.CM_NEXTCm.Tag)
		Wk_Index = CShort(FR_SSSMAIN.MN_NextCm.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
		
		F_Ctl_PageButton_Enabled = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Inp_Item_Focus_Ctl
	'   概要：  入力コントロールの使用可否制御
	'   引数：　pm_Value              :設定値
	'           pm_All                :全構造体
	'   戻値：　処理結果
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Inp_Item_Focus_Ctl(ByRef pm_Value As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		F_Set_Inp_Item_Focus_Ctl = 9
		
		If pm_Value = True Then
			'ページ情報（現在ページ、最大ページ等の退避変数）をクリア
			'明細ページ数初期化
			MaxPageNum = 1
			NowPageNum = 1
		End If
		
		F_Set_Inp_Item_Focus_Ctl = 0
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Clr_Dsp
	'   概要：  各画面の項目を初期化
	'   引数：　pm_Index    :オブジェクトのインデックス
	'   戻値：  なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp(ByRef pm_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Index_Wk As Short
		Dim Wk_Index_S As Short
		Dim Wk_Index_E As Short
		Dim Wk_Mode As Short
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		If pm_Index = -1 Then
			Wk_Index_S = 1
			Wk_Index_E = pm_All.Dsp_Base.Item_Cnt
			pm_All.Dsp_Base.Head_Ok_Flg = False
			Wk_Mode = ITM_ALL_CLR
		Else
			Wk_Index_S = pm_Index
			Wk_Index_E = pm_Index
			Wk_Mode = ITM_ALL_ONLY
		End If
		
		For Index_Wk = Wk_Index_S To Wk_Index_E
			
			'共通初期化
			Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Index_Wk), Wk_Mode, pm_All)
			
			'全体初期化の場合
			If Wk_Mode = ITM_ALL_CLR Then
				'ボディ部以降の項目を全ﾌｫｰｶｽなしとする
				If Index_Wk > pm_All.Dsp_Base.Head_Lst_Idx Then
					Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Index_Wk))
				End If
			End If
			
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
		Next 
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Clr_Dsp_Body
	'   概要：  各画面のボディ項目を初期化
	'   引数：　pm_Bd_Index     :明細行インデックス
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Clr_Dsp_Body(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All) As Short
		
		Dim Index_Bd_Wk As Short
		Dim Wk_Bd_Index_S As Short
		Dim Wk_Bd_Index_E As Short
		Dim Wk_Mode As Short
		Dim Wk_Index As Short
		Dim Wk_Row As Short
		
		If pm_Bd_Index = -1 Then
			Wk_Bd_Index_S = 0
			Wk_Bd_Index_E = pm_All.Dsp_Base.Dsp_Body_Cnt
			
			'画面ボディ情報
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(pm_All.Dsp_Base.Dsp_Body_Cnt)
			
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'        'スクロール初期化
			'        '最大値
			'        Call CF_Set_VScrl_Max(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'        '最小値
			'        Call CF_Set_VScrl_Min(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'        '最大ｽｸﾛｰﾙ量
			'        Call CF_Set_VScrl_LargeChange(pm_All.Dsp_Base.Dsp_Body_Cnt - 1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'        '最小ｽｸﾛｰﾙ量
			'        Call CF_Set_VScrl_SmallChange(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'        '初期値
			'        Call CF_Set_Item_Direct(1, pm_All.Dsp_Sub_Inf(CInt(pm_All.Bd_Vs_Scrl.Tag)), pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			Wk_Mode = BODY_ALL_CLR
		Else
			Wk_Bd_Index_S = pm_Bd_Index
			Wk_Bd_Index_E = pm_Bd_Index
			Wk_Mode = BODY_ALL_ONLY
		End If
		
		For Index_Bd_Wk = Wk_Bd_Index_S To Wk_Bd_Index_E
			
			'共通初期化
			Call CF_Init_Clr_Dsp_Body(Index_Bd_Wk, Wk_Mode, pm_All)
			
			'配列０の初期情報を対象行にコピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk))
			
			'全体初期化の場合
			If Wk_Mode = BODY_ALL_CLR Then
				'全行初期状態
				pm_All.Dsp_Body_Inf.Row_Inf(Index_Bd_Wk).Status = BODY_ROW_STATE_DEFAULT
			End If
			
			'個別初期化
			''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'        '以下のｺﾝﾄﾛｰﾙは明細部分のｺﾝﾄﾛｰﾙであればなんでもＯＫです
			'        '(対象の明細の番号情報だけが必要、)
			'        Wk_Index = CInt(FR_SSSMAIN.BD_CTLCD(Index_Bd_Wk).Tag)
			''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			'        'Dsp_Body_Infの行ＮＯに変換
			'        Wk_Row = CF_Bd_Idx_To_Idx(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
			''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'        'Dsp_Body_Infに値を初期値を設定
			'        Call F_Init_Dsp_Body(Wk_Row, pm_All)
			''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
		Next 
		
		gv_bolKNGMT51_INIT = False
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Cursor_Set
	'   概要：  画面初期状態時のフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Init_Cursor_Set(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Index_Cnt As Short
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'各画面個別設定(必ずDSP_SUB_INF.Detail.Focus_Ctl=Trueの項目！！)
		'権限グループにフォーカス設定
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(FR_SSSMAIN.HD_KNGGRCD.Tag)
		
		'ﾌｫｰｶｽ移動
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'選択状態の設定（初期選択）
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'項目色設定
		Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Cursor_Set
	'   概要：  フォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Cursor_Set(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		Dim Index_Cnt As Short
		Dim Index_Wk As Short
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'各画面個別設定(必ずDSP_SUB_INF.Detail.Focus_Ctl=Trueの項目！！)
		'フォーカスありを検索
		For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
			If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Focus_Ctl = True Then
				'割当ｲﾝﾃﾞｯｸｽ取得
				Trg_Index = CShort(pm_All.Dsp_Sub_Inf(Index_Wk).Ctl.Tag)
				
				Exit For
			End If
		Next 
		
		'ﾌｫｰｶｽ移動
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'選択状態の設定（初期選択）
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'項目色設定
		Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	' === 20060825 === INSERT E
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Cmn_Ctl_MN_InsertDE
	'   概要：  メニューの明細挿入の共通制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Cmn_Ctl_MN_InsertDE(ByRef pm_Bd_Index As Short, ByRef pm_Ins_Bd_Index As Short, ByRef pm_All As Cls_All) As Boolean
		
		'UPGRADE_WARNING: 構造体 WK_Dsp_Body_Inf の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim WK_Dsp_Body_Inf As Cls_Dsp_Body_Inf
		Dim Max_Row As Short
		Dim Wk_Row As Short
		Dim Wk_Row_New As Short
		Dim Iput_Cnt As Short
		Dim Input_Wait_Cnt As Short
		
		F_Cmn_Ctl_MN_InsertDE = False
		
		'初期化可能か判定
		'｢入力待状態｣の件数を取得
		Input_Wait_Cnt = 0
		For Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT_WAIT Then
				Input_Wait_Cnt = Input_Wait_Cnt + 1
				Exit For
			End If
		Next 
		
		If Input_Wait_Cnt > 0 Then
			'｢入力待状態｣が存在している場合、挿入不可！！
			MsgBox("空白の明細行を先に削除してください。")
			F_Cmn_Ctl_MN_InsertDE = False
			Exit Function
		End If
		
		'現在の最大行を取得
		Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		
		'一時退避
		ReDim WK_Dsp_Body_Inf.Row_Inf(Max_Row)
		Iput_Cnt = 0
		For Wk_Row = 1 To Max_Row
			'対象行にコピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row), WK_Dsp_Body_Inf.Row_Inf(Wk_Row))
			
			If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT Then
				'｢入力済状態｣
				Iput_Cnt = Iput_Cnt + 1
			End If
			
		Next 
		
		'増加チェック
		If pm_All.Dsp_Base.Max_Body_Cnt > 0 Then
			'最大入力明細数が設定されいる場合
			If Iput_Cnt >= pm_All.Dsp_Base.Max_Body_Cnt Then
				'｢入力状態｣の件数が最大入力明細数に到達する場合
				MsgBox("明細行はこれ以上挿入できません。")
				F_Cmn_Ctl_MN_InsertDE = False
				Exit Function
			End If
		End If
		
		Wk_Row_New = 0
		Iput_Cnt = 0
		For Wk_Row = 1 To Max_Row
			
			If Wk_Row = pm_Bd_Index Then
				'対象行の場合
				Wk_Row_New = Wk_Row_New + 1
				'増加
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New)
				'配列の初期情報を対象行にコピー
				Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
				
				'初期化後｢入力待状態｣
				pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New).Status = BODY_ROW_STATE_INPUT_WAIT
				
				'追加行を呼出元に通知
				pm_Ins_Bd_Index = Wk_Row_New
				
			End If
			
			Select Case WK_Dsp_Body_Inf.Row_Inf(Wk_Row).Status
				Case BODY_ROW_STATE_DEFAULT, BODY_ROW_STATE_INPUT
					'｢初期状態｣、｢入力済状態｣だけ退避
					Wk_Row_New = Wk_Row_New + 1
					'増加
					ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New)
					
					'対象行にコピー
					Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
					
			End Select
			
		Next 
		
		'明細情報の行状態を再設定
		Call CF_Set_Body_Row_Status(pm_All)
		
		F_Cmn_Ctl_MN_InsertDE = True
		
	End Function
	' === 20060825 === INSERT E
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Cmn_Ctl_MN_DeleteDE
	'   概要：  メニューの明細削除の共通制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Cmn_Ctl_MN_DeleteDE(ByRef pm_Bd_Index As Short, ByRef pm_All As Cls_All, ByRef pm_Row_Inf_Max_S As Short, ByRef pm_Row_Inf_Max_E As Short) As Short
		
		'UPGRADE_WARNING: 構造体 WK_Dsp_Body_Inf の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim WK_Dsp_Body_Inf As Cls_Dsp_Body_Inf
		Dim Max_Row As Short
		Dim Wk_Row As Short
		Dim Wk_Row_New As Short
		Dim Def_Cnt As Short
		Dim Iput_Cnt As Short
		Dim Copy_Flg As Boolean
		Dim Input_Wait_Row As Short
		Dim Wk_Col As Short
		
		'初期化可能か判定
		'｢入力待状態｣の行番号を取得
		Input_Wait_Row = 0
		For Wk_Row = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
			If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_INPUT_WAIT Then
				Input_Wait_Row = Wk_Row
				Exit For
			End If
		Next 
		
		If Input_Wait_Row > 0 Then
			'｢入力待状態｣が存在している場合、それより下の行の削除不可！！
			If pm_Bd_Index > Input_Wait_Row Then
				MsgBox("空白の明細行を先に削除してください。")
				F_Cmn_Ctl_MN_DeleteDE = False
				Exit Function
			End If
		End If
		
		'初期化、逆転させる！
		pm_Row_Inf_Max_S = 0
		pm_Row_Inf_Max_E = -1
		
		'現在の最大行を取得
		Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		
		'一時退避
		ReDim WK_Dsp_Body_Inf.Row_Inf(Max_Row)
		For Wk_Row = 1 To Max_Row
			'対象行にコピー
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row), WK_Dsp_Body_Inf.Row_Inf(Wk_Row))
		Next 
		
		Copy_Flg = True
		Wk_Row_New = pm_All.Dsp_Body_Inf.Cur_Top_Index - 1
		Def_Cnt = 1 '必ず１行は削除される為、｢初期状態｣の開始を１からとする
		Iput_Cnt = 0
		For Wk_Row = pm_All.Dsp_Body_Inf.Cur_Top_Index To pm_All.Dsp_Body_Inf.Cur_Top_Index + pm_All.Dsp_Base.Dsp_Body_Cnt - 1
			'最終準備行以降はコピーしない
			If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row).Status = BODY_ROW_STATE_LST_ROW Then
				Copy_Flg = False
			End If
			
			'行初期化
			Call CF_Copy_Dsp_Body_Row_Inf(pm_All.Dsp_Body_Inf.Init_Row_Inf, pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row))
			
			If Wk_Row = pm_Bd_Index Then
				'対象行の場合
				'削除行を復元情報に退避
				Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row_Inf)
				'復元行
				pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Row = Wk_Row
				'復元情報の有(明細削除の復元情報)
				pm_All.Dsp_Body_Inf.Rest_Inf.Rest_Flg = BODY_ROW_REST_FLG_DEL
				
				'エラー列の場合、項目色を戻す
				For Wk_Col = 2 To UBound(WK_Dsp_Body_Inf.Row_Inf(Wk_Row).Item_Detail)
					If WK_Dsp_Body_Inf.Row_Inf(Wk_Row).Item_Detail(Wk_Col).Err_Status > ERR_NOT Then
						Call F_Reset_Item_Color(Wk_Row, Wk_Col)
					End If
				Next 
			Else
				Wk_Row_New = Wk_Row_New + 1
				If Copy_Flg = True Then
					'対象行にコピー
					Call CF_Copy_Dsp_Body_Row_Inf(WK_Dsp_Body_Inf.Row_Inf(Wk_Row), pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New))
				End If
				
				If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New).Status = BODY_ROW_STATE_DEFAULT Then
					'｢初期状態｣
					Def_Cnt = Def_Cnt + 1
				End If
				
				If pm_All.Dsp_Body_Inf.Row_Inf(Wk_Row_New).Status = BODY_ROW_STATE_INPUT Then
					'｢入力済状態｣
					Iput_Cnt = Iput_Cnt + 1
				End If
				
			End If
		Next 
		
		'明細情報の行状態を再設定
		Call CF_Set_Body_Row_Status(pm_All)
		
		'配列数が変更がない場合は、最終行の初期化が必要
		If Max_Row = UBound(pm_All.Dsp_Body_Inf.Row_Inf) Then
			pm_Row_Inf_Max_S = Max_Row
			pm_Row_Inf_Max_E = Max_Row
		End If
		
	End Function
	' === 20060825 === INSERT E
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Reset_Item_Color
	'   概要：  元エラーのあった項目の色を戻す
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Reset_Item_Color(ByRef pm_Wk_Row As Short, ByRef pm_Wk_Col As Short) As Short
		
		Select Case pm_Wk_Col
			' 2006/11/21  ADD START  KUMEDA
			Case pc_COL_DATKB '起動
				FR_SSSMAIN.BD_UPDAUTH(pm_Wk_Row).ForeColor = ACE_CMN.COLOR_BLACK
				' 2006/11/21  ADD END
			Case pc_COL_UPDAUTH '更新
				FR_SSSMAIN.BD_UPDAUTH(pm_Wk_Row).ForeColor = ACE_CMN.COLOR_BLACK
			Case pc_COL_PRTAUTH '印刷
				FR_SSSMAIN.BD_PRTAUTH(pm_Wk_Row).ForeColor = ACE_CMN.COLOR_BLACK
			Case pc_COL_FILEAUTH 'ファイル出力
				FR_SSSMAIN.BD_FILEAUTH(pm_Wk_Row).ForeColor = ACE_CMN.COLOR_BLACK
			Case pc_COL_SALTAUTH '販売単価変更
				FR_SSSMAIN.BD_SALTAUTH(pm_Wk_Row).ForeColor = ACE_CMN.COLOR_BLACK
			Case pc_COL_HDNTAUTH '発注単価変更
				FR_SSSMAIN.BD_HDNTAUTH(pm_Wk_Row).ForeColor = ACE_CMN.COLOR_BLACK
			Case pc_COL_SAPMAUTH '販売計画年初計画修正
				FR_SSSMAIN.BD_SAPMAUTH(pm_Wk_Row).ForeColor = ACE_CMN.COLOR_BLACK
		End Select
	End Function
	' === 20060825 === INSERT E
	
	' === 20060825 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Jge_Input_Str
	'   概要：  入力文字を判定する
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Jge_Input_Str(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef Pm_Moji As String) As Short
		'初期化（入力不可）
		F_Jge_Input_Str = 0
		
		'入力文字タイプで制御
		Select Case pm_Dsp_Sub_Inf.Detail.In_Str_Typ
			Case IN_STR_TYP_X
				'半角英数のみ
				If (Pm_Moji >= "0" And Pm_Moji <= "9") Or (Pm_Moji >= "a" And Pm_Moji <= "z") Or (Pm_Moji >= "A" And Pm_Moji <= "Z") Or (Pm_Moji = " ") Then
					F_Jge_Input_Str = 1
				End If
				' 2006/12/01  ADD START  KUMEDA
				Pm_Moji = UCase(Pm_Moji)
				' 2006/12/01  ADD END
				
		End Select
		
	End Function
	' === 20060825 === INSERT E
	
	' === 20061031 === INSERT S
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Get_Inp_KNG
	'   概要：  入力担当者更新権限取得
	'   引数：　pm_Form        :フォーム
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Get_Inp_KNG(ByRef pm_All As Cls_All) As Short
		
		'初期化
		pv_InpTan_KNG = False
		
		'' 2006/11/13  CHG START  KUMEDA
		''    'ユーザーＩＤ代入
		''    gs_userid = Inp_Inf.InpTanCd
		''    'プログラムＩＤ代入
		''    gs_pgid = SSS_PrgId
		''
		''    '権限内容チェック
		''    gs_kengen = Get_Authority(GV_UNYDate)
		''' 2006/11/02  CHG START  KUMEDA
		'''    If gs_kengen = "1" Then
		'''        pv_InpTan_KNG = True
		'''    End If
		''    If gs_UPDAUTH = "1" Then
		''        pv_InpTan_KNG = True
		''    End If
		''' 2006/11/02  CHG END
		If Inp_Inf.InpJDNUPDKB = "1" Then
			pv_InpTan_KNG = True
		End If
		'' 2006/11/13  CHG END
		
	End Function
	' === 20061031 === INSERT E
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Item_Change
	'   概要：  対象項目のCHANGEの制御
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_Change(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Wk_CurMoji As String
		Dim Wk_Cnt As Short
		Dim Wk_EditMoji As String
		Dim Wk_DspMoji As String
		Dim Move_Flg As Boolean
		
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Select Case True
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox
				'ﾃｷｽﾄﾎﾞｯｸｽの場合
				'現在のﾃｷｽﾄ上の選択状態を取得
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
				Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
				
				'現在の値を取得
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
				
				Wk_EditMoji = ""
				
				Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
					Case IN_TYP_NUM
						'数値項目の場合
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
					Case IN_TYP_DATE
						'日付項目の場合
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
					Case IN_TYP_CODE, IN_TYP_STR
						'コード、文字項目
						Select Case pm_Dsp_Sub_Inf.Detail.In_Str_Typ
							'変更後の値変換
							Case IN_STR_TYP_N
								'全角の場合
								'半角空白⇒全角空白
								For Wk_Cnt = 1 To Len(Wk_CurMoji)
									If Mid(Wk_CurMoji, Wk_Cnt, 1) = Space(1) Then
										Wk_EditMoji = Wk_EditMoji & "　"
									Else
										Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
									End If
								Next 
								
							Case Else
								'全角以外
								'半角空白⇒全角空白
								For Wk_Cnt = 1 To Len(Wk_CurMoji)
									If Mid(Wk_CurMoji, Wk_Cnt, 1) = "　" Then
										Wk_EditMoji = Wk_EditMoji & Space(2)
									Else
										Wk_EditMoji = Wk_EditMoji & Mid(Wk_CurMoji, Wk_Cnt, 1)
									End If
								Next 
								
						End Select
					Case IN_TYP_YYYYMM
						'年月項目の場合
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
						
					Case IN_TYP_HHMM
						'時刻項目の場合
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_EditMoji = CF_Cnv_Dsp_Item(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf, False)
						
					Case Else
				End Select
				
				'編集後の文字を表示形式に変換
				'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
				
				'選択文字と入力文字の置き換え
				'文字設定
				Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
				
				'現在ﾌｫｰｶｽ位置から右へ移動
				Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, Move_Flg, pm_All, True)
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.CheckBox
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.RadioButton
				
			Case TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.PictureBox
				
		End Select
		
		'入力後処理
		Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
		'明細入力後の後処理
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	
	'======================= 変更部分 2006.06.12 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Item_GotFocus
	'   概要：  対象項目のGOTFOCUSの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_GotFocus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Move_Flg As Boolean
		
		If CF_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All) = False Then
			'ﾌｫｰｶｽを受け取れない場合
			'@'        '次の項目へﾌｫｰｶｽ移動
			'@'        If TypeOf pm_Dsp_Sub_Inf.Ctl Is SSCommand5 Then
			'@'            Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, Move_Flg, pm_All)
			'@'        Else
			'@'        '元の項目へﾌｫｰｶｽ移動
			'@'            Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
			'@'        End If
			
			'元の項目へﾌｫｰｶｽ移動
			Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Cursor_Idx), pm_All)
		Else
			
			'移動前と異なる場合のみ退避
			If pm_All.Dsp_Base.Cursor_Idx <> CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
				'前ﾌｫｰｶｽのｲﾝﾃﾞｯｸｽを退避
				pm_All.Dsp_Base.Bef_Cursor_Idx = pm_All.Dsp_Base.Cursor_Idx
				'移動後のｲﾝﾃﾞｯｸｽを退避
				pm_All.Dsp_Base.Cursor_Idx = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
			End If
			
			'選択状態の設定（初期選択）
			Call CF_Set_Sel_Ini(pm_Dsp_Sub_Inf, SEL_INI_MODE_2)
			'項目色設定
			Call CF_Set_Item_Color(pm_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
		End If
		
	End Function
	'======================= 変更部分 2006.06.12 End =================================
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Ctl_Item_KeyPress
	'   概要：  対象項目のKEYPRESSの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_KeyPress(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_KeyAscii As Short, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, ByRef pm_Run_Flg As Boolean) As Short
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim All_Sel_Flg As Boolean
		Dim wk_Moji As String
		Dim Wk_SelMoji As String
		Dim Wk_BefMoji As String
		Dim Wk_DelMoji As String
		Dim Wk_EditMoji As String
		Dim Wk_DspMoji As String
		Dim Wk_Cnt As Short
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		Dim Wk_CurMoji As String
		Dim Input_Flg As Boolean
		Dim Re_Body_Crt As Boolean
		Dim intRet As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'入力フラグ初期化
		Input_Flg = False
		'明細部再作成フラグ初期化
		Re_Body_Crt = False
		
		'以下の入力の場合、無視する
		Select Case pm_KeyAscii
			Case 1 To 7, 9 To 12, 14 To 29, 127
				Beep()
				pm_KeyAscii = 0
				Exit Function
		End Select
		
		'入力文字取得
		wk_Moji = Chr(pm_KeyAscii)
		
		'ﾃｷｽﾄﾎﾞｯｸｽのみ対象
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
			
			'現在のﾃｷｽﾄ上の選択状態を取得
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
			Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'現在の値を取得
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
			
			All_Sel_Flg = False
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				All_Sel_Flg = True
			End If
			
			' === 20060825 === UPDATE S
			'        '入力コード判定
			'        If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
			'入力コード判定
			If pm_Dsp_Sub_Inf.Ctl.Name = FR_SSSMAIN.HD_KNGGRCD.Name Then
				'判定項目が権限グループの場合
				intRet = F_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji)
			Else
				'判定項目が権限グループ以外の場合
				intRet = CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji)
			End If
			
			If intRet = 1 Then
				' === 20060825 === UPDATE E
				'入力可能文字の場合
				
				'入力可能な文字の場合、入力後処理、明細部再作成を行う
				Input_Flg = True
				Re_Body_Crt = True
				
				'CF_Jge_Input_Str関数の文字変更を考慮
				pm_KeyAscii = Asc(wk_Moji)
				
				'日付/年月/時刻でかつ選択状態が１つ以外の場合、入力不可
				'表示形式が決まっているため一つずつ入力させる
				Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
					Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
						If Act_SelLength <> 1 Then
							Beep()
							pm_KeyAscii = 0
							Exit Function
						End If
				End Select
				
				If All_Sel_Flg = True Then
					'全選択時
					
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'詰文字が左詰の場合
						Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & wk_Moji
						
					Else
						'詰文字が左詰以外の場合
						Wk_EditMoji = wk_Moji & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
						
					End If
					
					'編集後の文字を表示形式に変換
					'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
					
					'編集後のSelStartを決定
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'詰文字が左詰の場合
						'右端へ移動
						Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
						Wk_SelLength = 0
					Else
						'詰文字が左詰以外の場合
						Wk_SelStart = 0
						Wk_SelLength = 1
					End If
					
					'削除後の文字置き換え
					'文字設定
					Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
					pm_KeyAscii = 0
					
					'編集後のSelStartを決定
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
					'編集後のSelLengthを決定
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
					
					' === 20060801 === INSERT S - １桁項目で入力後にフォーカス移動しないことへの対応
					'数値項目特別処理
					If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
						
						'小数部があり小数桁数と設定値が同じ場合
						If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
							'現在ﾌｫｰｶｽ位置から右へ移動
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						Else
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
								'編集後の文字がMAXの場合
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
						
					Else
						'数値項目以外
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
							'編集後の文字がMAXの場合
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
							'編集後のSelLengthを決定
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Dsp_Sub_Inf.Ctl.SelLength = 0
							'現在ﾌｫｰｶｽ位置から右へ移動
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						End If
					End If
					' === 20060801 === INSERT E
					
				Else
					'部分選択もしくは、選択なし
					
					If Act_SelLength = 0 Then
						'選択なしの場合(挿入状態)
						'挿入部分の前の文字を取得
						Wk_BefMoji = Left(Wk_CurMoji, Act_SelStart)
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							Select Case wk_Moji
								Case "+"
									'｢＋｣入力時
									If Trim(Wk_BefMoji) <> "" Then
										'前文字が上記の文字以外は挿入できない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "-"
									'｢－｣入力時
									If Trim(Wk_BefMoji) <> "" Then
										'前文字が上記の文字以外は挿入できない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "."
									'｢．｣入力時
									If InStr(Wk_CurMoji, ".") > 1 Then
										'すでに｢．｣が入力されいる場合
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
							End Select
						End If
						
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
							'空白除去後の現在の文字がMAXの場合、オーバーフロー
							
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								'一番右でオーバーフローした場合、次の項目へ
								If Act_SelStart >= Len(Wk_CurMoji) Then
									'編集前の開始位置が一番右の場合
									'現在ﾌｫｰｶｽ位置から右へ移動
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									'入力不可
									Beep()
								End If
							Else
								
								'編集後の移動先を判定
								If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
									'詰文字が左詰の場合
								Else
									'編集後のSelStartを決定
									If Act_SelStart + 1 > Len(Wk_CurMoji) Then
										'１つ右の位置が右端の場合
										Wk_SelStart = Len(Wk_CurMoji)
									Else
										'１つ右へ
										Wk_SelStart = Act_SelStart + 1
									End If
									'編集後のSelLengthを決定
									Wk_SelLength = 0
									
									'編集後のSelStartを決定
									'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
									'編集後のSelLengthを決定
									'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
								End If
								
								'入力不可
								Beep()
							End If
							
							'入力不可
							pm_KeyAscii = 0
							Exit Function
						End If
						
						'文字編集
						Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Chr(pm_KeyAscii) & Mid(Wk_CurMoji, Act_SelStart + 1)
						
						'編集後の文字を表示形式に変換
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'整数部で整数桁数より多く入力されている場合
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'小数部があり小数桁数と設定値が同じ場合
							If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
						End If
						
						'編集後のSelStartを決定
						If Act_SelStart + 1 > Len(Wk_DspMoji) Then
							'１つ右の位置が右端の場合
							Wk_SelStart = Len(Wk_DspMoji)
						Else
							'１つ右へ
							Wk_SelStart = Act_SelStart + 1
						End If
						'編集後のSelLengthを決定
						Wk_SelLength = 0
						
						'削除後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						pm_KeyAscii = 0
						
						'編集後のSelStartを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'編集後のSelLengthを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
						'編集後の移動先を判定
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'詰文字が左詰の場合
							
							If Wk_SelStart >= Len(Wk_DspMoji) Then
								'編集後の開始位置が一番右の場合
								'数値項目特別処理
								If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
									'小数部があり小数桁数と設定値が同じ場合
									If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									Else
										If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
											'編集後の文字がMAXの場合
											'現在ﾌｫｰｶｽ位置から右へ移動
											Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
										End If
									End If
								Else
									'数値項目以外
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'編集後の文字がMAXの場合
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
							End If
						Else
							'詰文字が左詰以外の場合
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
								'編集後の文字がMAXの場合
								
								'編集後のSelStartを決定
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
								'編集後のSelLengthを決定
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelLength = 1
								
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
					Else
						'一部選択
						'現在選択されている文字の１桁を取得
						Wk_SelMoji = Mid(Wk_CurMoji, Act_SelStart + 1, 1)
						
						If Trim(Wk_SelMoji) <> "" And CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_SelMoji) <> 1 Then
							'選択文字が空文字以外でかつ入力対象の文字以外の場合
							
							'入力不可
							Beep()
							pm_KeyAscii = 0
							Exit Function
						End If
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							Select Case wk_Moji
								Case "+"
									'｢＋｣入力時
									If Wk_SelMoji <> "-" And Wk_SelMoji <> "." And Wk_SelMoji <> "%" And Trim(Wk_SelMoji) <> "" Then
										'選択文字が上記の文字以外は置き換えられない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "-"
									'｢－｣入力時
									If Wk_SelMoji <> "+" And Wk_SelMoji <> "." And Wk_SelMoji <> "%" And Trim(Wk_SelMoji) <> "" Then
										'選択文字が上記の文字以外は置き換えられない
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
									
								Case "."
									'｢．｣入力時
									If InStr(Wk_CurMoji, ".") > 0 Then
										'すでに｢．｣が入力されいる場合
										'入力不可
										Beep()
										pm_KeyAscii = 0
										Exit Function
									End If
							End Select
						End If
						
						'文字編集
						Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Chr(pm_KeyAscii) & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
						
						'編集後の文字を表示形式に変換
						'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'整数部無しの場合
							'整数部ありで整数桁数より多く入力されている場合
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'小数部があり小数桁数と設定値が同じ場合
							If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
						End If
						
						If Act_SelStart >= Len(Wk_DspMoji) - 1 Then
							'編集前の開始位置が最後の文字以降の場合
							'編集後のSelStartを決定
							Wk_SelStart = Len(Wk_DspMoji)
							'編集後のSelLengthを決定
							Wk_SelLength = 0
						Else
							'編集後のSelStartを決定
							Wk_SelStart = Act_SelStart
							'編集後のSelLengthを決定
							Wk_SelLength = 1
						End If
						
						'数値項目特別処理
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							If Len(CF_Get_Input_Ok_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) = 1 Then
								'入力可能な文字が１桁の場合
								'開始位置を一番右に設定
								'編集後のSelStartを決定
								Wk_SelStart = Len(Wk_DspMoji)
								'編集後のSelLengthを決定
								Wk_SelLength = 0
							End If
							
						End If
						
						'編集後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						pm_KeyAscii = 0
						
						'編集後のSelStartを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'編集後のSelLengthを決定
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
						'編集後の移動先を判定
						If Wk_SelStart >= Len(Wk_DspMoji) - 1 Then
							'編集後の開始位置が最後の文字以降の場合
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								
								'小数部があり小数桁数と設定値が同じ場合
								If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
									'現在ﾌｫｰｶｽ位置から右へ移動
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'編集後の文字がMAXの場合
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
								
							Else
								'数値項目以外
								If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
									'編集後の文字がMAXの場合
									'現在ﾌｫｰｶｽ位置から右へ移動
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								End If
							End If
						Else
							'現在ﾌｫｰｶｽ位置から右へ移動
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						End If
						
					End If
				End If
				
			Else
				'入力コード以外
				Select Case pm_KeyAscii
					Case System.Windows.Forms.Keys.Back
						'BackSpaceキー
						pm_KeyAscii = 0
						
						'日付/年月/時刻の場合
						Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
							Case IN_TYP_DATE, IN_TYP_YYYYMM, IN_TYP_HHMM
								'削除後のSelStartを決定
								Wk_SelStart = Act_SelStart
								For Wk_Cnt = Act_SelStart - 1 To 0 Step -1
									'削現在の開始位置から左へ移動し文字が入力対象かを判定
									If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Mid(Wk_CurMoji, Wk_Cnt + 1, 1)) = 1 Then
										'入力文字でない場合
										Wk_SelStart = Wk_Cnt
										Exit For
									End If
									
								Next 
								'編集後のSelLengthを決定
								Wk_SelLength = Act_SelLength
								
								'編集後のSelStartを決定
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
								'編集後のSelLengthを決定
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
								
								'削除不可
								Exit Function
							Case Else
								
						End Select
						
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'詰文字が左詰の場合
							'開始位置が左の場合、終了
							If Act_SelStart = 0 Then
								'削除不可
								Exit Function
							End If
							
							'削除対象の文字１桁を取得
							Wk_DelMoji = Mid(Wk_CurMoji, Act_SelStart, 1)
							
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								If Wk_DelMoji = "." Then
									'削除対象の文字が小数点の場合
									If Len(CF_Get_Num_Int_Part(Wk_CurMoji)) + Len(CF_Get_Num_Fra_Part(Wk_CurMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
										'削除後の桁数オーバーの場合
										'削除不可
										Exit Function
									End If
								End If
							End If
							
							'削除文字の判定
							If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Wk_DelMoji) = 1 Then
								'削除文字が入力対象の文字の場合
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'文字編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1)
								Else
									'削除対象がない為、空白を編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
							Else
								'削除文字が入力対象の文字の以外場合
								'そのまま
								Wk_EditMoji = Wk_CurMoji
							End If
							
							'削除後の文字を表示形式に変換
							'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
							
							'削除後のSelStartを決定
							Wk_SelStart = Act_SelStart
							For Wk_Cnt = Act_SelStart To Len(Wk_CurMoji) - 1
								'削除後に現在の開始位置からの文字が入力対象かを判定
								If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, Mid(Wk_DspMoji, Wk_Cnt + 1, 1)) = 1 Then
									Exit For
								End If
								'入力文字でない場合、右へ移動
								Wk_SelStart = Wk_SelStart + 1
							Next 
							'編集後のSelLengthを決定
							Wk_SelLength = Act_SelLength
							
							'数値項目特別処理
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								'数値項目で未入力の場合は、一番右を開始位置に設定
								If CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf) = "" Then
									Wk_SelStart = Len(Wk_DspMoji)
									'編集後のSelLengthを決定
									Wk_SelLength = 0
								End If
							End If
						Else
							'詰文字が左詰以外の場合
							If Act_SelStart = 0 Then
								'開始位置が一番左の場合
								If CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf) <> "" Then
									'文字編集
									Wk_EditMoji = Right(Wk_CurMoji, Len(Wk_CurMoji) - 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								Else
									'削除対象がない為、空白を編集
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
								
								'削除後のSelStartを決定
								Wk_SelStart = Act_SelStart
							Else
								'文字編集
								Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								
								'削除後のSelStartを決定
								Wk_SelStart = Act_SelStart - 1
							End If
							'編集後のSelLengthを決定
							Wk_SelLength = Act_SelLength
							
							'編集後の文字を表示形式に変換
							'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
						End If
						
						'削除後の文字置き換え
						'文字設定
						Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
						
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
						
					Case Else
						pm_KeyAscii = 0
						
				End Select
			End If
		End If
		
		If Input_Flg = True Then
			'入力後処理
			Call CF_Ctl_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		End If
		
		If Re_Body_Crt = True Then
			'明細入力後の後処理
			Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		End If
		
	End Function
	
	'======================= 変更部分 2006.07.02 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Item_MouseDown
	'   概要：  対象項目のMOUSEDOWNの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Item_MouseDown(ByRef pm_Trg_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Button As Short, ByRef pm_Shift As Short, ByRef pm_X As Single, ByRef pm_Y As Single) As Short
		Dim Wk_Index As Short
		Dim bolSameCtl As Boolean
		
		If pm_Button = VB6.MouseButtonConstants.RightButton Then
			'右クリック
			
			bolSameCtl = False
			If CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
				'右クリックしたコントロールがアクティブなコントロールと一致
				'カーソル制御用テキストにフォーカスを一時的に退避
				Wk_Index = CShort(FR_SSSMAIN.TX_CursorRest.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
				bolSameCtl = True
			End If
			
			'｢項目内容コピー｣判定
			FR_SSSMAIN.SM_AllCopy.Enabled = CF_Jge_Enabled_SM_AllCopy(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
			
			'｢項目内容に貼り付け｣判定
			FR_SSSMAIN.SM_FullPast.Enabled = CF_Jge_Enabled_SM_FullPast(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All)
			
			'対象コントロールの使用不可
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = False
			
			'｢ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ｣判定
			If CF_Jge_Enabled_PopupMenu(pm_Trg_Dsp_Sub_Inf, pm_Act_Dsp_Sub_Inf, pm_All) = True Then
				'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制
				pm_All.Dsp_Base.LostFocus_Flg = True
				'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示
				'UPGRADE_ISSUE: 定数 vbPopupMenuLeftButton はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="55B59875-9A95-4B71-9D6A-7C294BF7139D"' をクリックしてください。
				'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PopupMenu はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
				FR_SSSMAIN.PopupMenu(FR_SSSMAIN.SM_ShortCut, vbPopupMenuLeftButton)
				'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制解除
				pm_All.Dsp_Base.LostFocus_Flg = False
				System.Windows.Forms.Application.DoEvents()
			End If
			
			'ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示状態で画面の終了処理に入ってしまった場合は、
			'以降の処理は行わない。
			If pm_All.Dsp_Base.IsUnload = True Then
				Exit Function
			End If
			
			'対象コントロールの使用可
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = True
			'フォーカスを移動を元に戻す
			If bolSameCtl = True Then
				Call CF_Set_Item_SetFocus(pm_Trg_Dsp_Sub_Inf, pm_All)
			End If
			
		End If
		
	End Function
	'======================= 変更部分 2006.07.02 End =================================
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_VS_Scrl_CHANGE
	'   概要：  VS_ScrlのMOUSEDOWNの制御
	'   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_Act_Dsp_Sub_Inf  :画面項目情報
	'           pm_all              :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_VS_Scrl_Change(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Move_Flg As Boolean
		Dim Row_Move_Value As Short
		Dim Cur_Row As Short
		Dim Next_Row As Short
		Dim Next_Index As Short
		
		'最上明細ｲﾝﾃﾞｯｸｽを退避
		Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		'======================= 変更部分 2006.06.26 Start =================================
		'縦スクロールバーの値を最上明細ｲﾝﾃﾞｯｸｽに設定
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_All.Dsp_Body_Inf.Cur_Top_Index = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
		'画面ボディ情報の配列を再設定
		Call CF_Dell_Refresh_Body_Inf(pm_All)
		'======================= 変更部分 2006.06.26 End =================================
		'画面表示
		'Call CF_Body_Dsp(pm_All)
		Call F_Body_Dsp(pm_All)
		
		'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが明細部のみ制御
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			
			'現在の行を取得
			Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
			'ﾌｫｰｶｽ制御
			'移動量
			Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index
			
			'移動後の行
			Next_Row = Cur_Row + Row_Move_Value
			If Next_Row <= 0 Then
				Next_Row = 1
			End If
			If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
				Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
			End If
			
			'移動後の行のの同一項目のｲﾝﾃﾞｯｸｽを取得
			Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
			If Next_Index > 0 Then
				If Next_Index = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
					'同一ｺﾝﾄﾛｰﾙの場合
					'選択状態の設定（初期選択）
					Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
					'項目色設定
					Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
				Else
					'同一ｺﾝﾄﾛｰﾙでない場合
					'同一項目の１つ前からENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				End If
			Else
				'入力可能な最初のインデックスを取得
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					'同一項目の１つ前からENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					
					If Row_Move_Value > 0 Then
						'上へ移動
						'ヘッダ部の最後の項目の１つ後ろから
						'１つ前の項目へ
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
					Else
						'下へ移動
						'フッタ部の最初の項目の１つ前から
						'ENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
					End If
				End If
			End If
		End If
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_Dsp_Body_Page
	'   概要：  明細部分のページ制御
	'   引数：　pm_Page_Value       :明細のページ数
	'           pm_Dsp_Sub_Inf      :画面項目情報
	'           pm_all              :全構造体
	'           pm_Border_Body_Cnt  :
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_Dsp_Body_Page(ByRef pm_Page_Value As Short, ByRef pm_Act_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, Optional ByRef pm_Border_Body_Cnt As Short = 0) As Short
		
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Move_Flg As Boolean
		Dim Row_Move_Value As Short
		Dim Cur_Row As Short
		Dim Next_Row As Short
		Dim Next_Index As Short
		
		'    'ページボタン使用可否制御
		'    Call F_Ctl_PageButton_Enabled(pm_All)
		
		'最上明細ｲﾝﾃﾞｯｸｽを退避
		Cur_Top_Index = pm_All.Dsp_Body_Inf.Cur_Top_Index
		
		'    '画面の内容を退避
		'    Call CF_Body_Bkup(pm_All)
		'最上明細ｲﾝﾃﾞｯｸｽに設定
		'（画面表示明細数－境界明細数）×（ページ数－１）＋１　　⇒１、６、１１、１６となる
		pm_All.Dsp_Body_Inf.Cur_Top_Index = (pm_All.Dsp_Base.Dsp_Body_Cnt - pm_Border_Body_Cnt) * (pm_Page_Value - 1) + 1
		'画面表示
		'Call CF_Body_Dsp(pm_All)
		Call F_Body_Dsp(pm_All)
		
		'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが明細部のみ制御
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			
			'現在の行を取得
			Cur_Row = pm_Act_Dsp_Sub_Inf.Detail.Body_Index
			'ﾌｫｰｶｽ制御
			'移動量
			Row_Move_Value = Cur_Top_Index - pm_All.Dsp_Body_Inf.Cur_Top_Index
			
			'移動後の行
			Next_Row = Cur_Row + Row_Move_Value
			If Next_Row <= 0 Then
				Next_Row = 1
			End If
			If Next_Row > pm_All.Dsp_Base.Dsp_Body_Cnt Then
				Next_Row = pm_All.Dsp_Base.Dsp_Body_Cnt
			End If
			
			'移動後の行のの同一項目のｲﾝﾃﾞｯｸｽを取得
			Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Act_Dsp_Sub_Inf, Next_Row, pm_All)
			If Next_Index > 0 Then
				If Next_Index = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
					'同一ｺﾝﾄﾛｰﾙの場合
					'選択状態の設定（初期選択）
					Call CF_Set_Sel_Ini(pm_Act_Dsp_Sub_Inf, SEL_INI_MODE_2)
					'項目色設定
					Call CF_Set_Item_Color(pm_Act_Dsp_Sub_Inf, ITEM_SELECT_STATUS, pm_All)
				Else
					'同一ｺﾝﾄﾛｰﾙでない場合
					'同一項目の１つ前からENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Next_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				End If
			Else
				'入力可能な最初のインデックスを取得
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(Next_Row, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					'同一項目の１つ前からENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
				Else
					
					If Row_Move_Value > 0 Then
						'上へ移動
						'ヘッダ部の最後の項目の１つ後ろから
						'１つ前の項目へ
						Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), Move_Flg, pm_All)
					Else
						'下へ移動
						'フッタ部の最初の項目の１つ前から
						'ENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
					End If
				End If
			End If
		End If
		
	End Function
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_Cmn_DE_Focus
	'   概要：  メニューの明細初期化／明細削除／明細復元時のフォーカス制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_Cmn_DE_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Row As Short, ByRef pm_All As Cls_All) As Boolean
		
		Dim Trg_Index As Short
		Dim Move_Flg As Boolean
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Trg_Index_Same_Row As Short
		
		'画面明細の行と同一の明細をインデックスを取得
		Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
		
		If Trg_Index > 0 Then
			If Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) Then
				'移動先が同じ場合
				If pm_Dsp_Sub_Inf.Ctl.TabStop = True Then
					'選択状態の設定（初期選択）
					Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
					'項目色設定
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
					
				Else
					'状態が最終準備行の場合
					If pm_All.Dsp_Body_Inf.Row_Inf(pm_Row).Status = BODY_ROW_STATE_LST_ROW Then
						'                If pm_All.Dsp_Body_Inf.Row_Inf(pm_Row).Status = BODY_ROW_STATE_LST_ROW Or _
						''                   pm_All.Dsp_Body_Inf.Row_Inf(pm_Row).Status = BODY_ROW_STATE_INPUT_WAIT Then
						'同行の更新のｲﾝﾃﾞｯｸｽ取得
						Trg_Index_Same_Row = CShort(FR_SSSMAIN.BD_UPDAUTH(pm_Row).Tag)
						'ﾌｫｰｶｽ移動
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index_Same_Row), pm_All)
					Else
						'ﾌｫｰｶｽ移動
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index - pm_All.Dsp_Base.Body_Col_Cnt), pm_All)
					End If
				End If
				
			Else
				'同一項目の１つ前からENTキー押下と同様に次の項目へ
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Trg_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
			
		Else
			'入力可能な最初のインデックスを取得
			Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Row, pm_All)
			If Focus_Ctl_Ok_Fst_Idx > 0 Then
				'同一項目の１つ前からENTキー押下と同様に次の項目へ
				Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
			End If
		End If
		
	End Function
	'======================= 変更部分 2006.06.26 End =================================
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_ClearDE
	'   概要：  メニューの明細初期化の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_ClearDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Wk As Short
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細初期化
		If CF_Cmn_Ctl_MN_ClearDE(Bd_Index, pm_All) = True Then
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'業務の初期値を編集
			Call F_Init_Dsp_Body(Bd_Index, pm_All)
			
			'行Ｎｏ採番処理
			Call F_Edi_Saiban_No(pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
			'画面表示
			'Call CF_Body_Dsp(pm_All)
			Call F_Body_Dsp(pm_All)
			
			'元の画面の行に移動
			Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
			
			'フォーカス決定
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	'======================= 変更部分 2006.06.26 End =================================
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_DeleteDE
	'   概要：  メニューの明細削除の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_DeleteDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index_Wk As Short
		Dim Row_Wk As Short
		Dim Max_Row As Short
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細削除
		'Call CF_Cmn_Ctl_MN_DeleteDE(Bd_Index, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		Call F_Cmn_Ctl_MN_DeleteDE(Bd_Index, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'ページの再設定
		If (UBound(pm_All.Dsp_Body_Inf.Row_Inf) Mod pm_All.Dsp_Base.Dsp_Body_Cnt) = 0 Then
			MaxPageNum = UBound(pm_All.Dsp_Body_Inf.Row_Inf) / pm_All.Dsp_Base.Dsp_Body_Cnt
			
			If MaxPageNum < NowPageNum Then
				NowPageNum = MaxPageNum
			End If
		End If
		
		'画面ボディ情報の再設定
		If UBound(pm_All.Dsp_Body_Inf.Row_Inf) < pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum Then
			Max_Row = pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum
			ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Max_Row)
			
			pm_All.Dsp_Body_Inf.Row_Inf(Max_Row).Item_Detail = VB6.CopyArray(pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail)
		End If
		
		'対象行の状態を再設定
		For Bd_Index_Wk = 0 To pm_All.Dsp_Base.Dsp_Body_Cnt - 1
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index_Wk).Status = BODY_ROW_STATE_LST_ROW Then
				'            pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index_Wk).Status = BODY_ROW_STATE_INPUT_WAIT
			End If
		Next 
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		'画面表示
		'    Call CF_Body_Dsp(pm_All)
		Call F_Body_Dsp(pm_All)
		
		'編集済みとする
		gv_bolKNGMT51_INIT = True
		
		'元の画面の行に移動
		Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
		
		'フォーカス決定
		Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
		
	End Function
	'======================= 変更部分 2006.06.26 End =================================
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_InsertDE
	'   概要：  メニューの明細挿入の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_InsertDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Bd_Index_Wk As Short
		Dim Ins_Bd_Index As Short
		Dim Row_Wk As Short
		Dim Max_Row As Short
		Dim Clm_Cnt As Short
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細挿入
		'If CF_Cmn_Ctl_MN_InsertDE(Bd_Index, Ins_Bd_Index, pm_All) = True Then
		If F_Cmn_Ctl_MN_InsertDE(Bd_Index, Ins_Bd_Index, pm_All) = True Then
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'挿入した行のフォーカスをありにする
			For Clm_Cnt = 2 To 28
				pm_All.Dsp_Body_Inf.Row_Inf(Ins_Bd_Index).Item_Detail(Clm_Cnt).Focus_Ctl = True
			Next 
			
			'画面ボディ情報の再設定
			If UBound(pm_All.Dsp_Body_Inf.Row_Inf) < pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum Then
				Max_Row = pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum
				ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Max_Row)
				
				pm_All.Dsp_Body_Inf.Row_Inf(Max_Row).Item_Detail = VB6.CopyArray(pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail)
			End If
			
			'最終行の再設定
			For Bd_Index_Wk = 1 To pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum
				If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index_Wk).Status = BODY_ROW_STATE_DEFAULT Then
					'対象行の状態を最終準備行に設定
					pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index_Wk).Status = BODY_ROW_STATE_LST_ROW
					'フォーカスの制御
					For Clm_Cnt = 2 To 28
						pm_All.Dsp_Body_Inf.Row_Inf(Ins_Bd_Index).Item_Detail(Clm_Cnt).Focus_Ctl = True
					Next 
					
					Exit For
				End If
			Next 
			
			'業務の初期値を編集
			Call F_Init_Dsp_Body(Ins_Bd_Index, pm_All)
			
			'行Ｎｏ採番処理
			Call F_Edi_Saiban_No(pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
			'対象行を画面に表示
			Call CF_Body_Dsp_Trg_Row(pm_All, Ins_Bd_Index)
			
			'編集済みとする
			gv_bolKNGMT51_INIT = True
			
			'追加行に移動
			Row_Wk = CF_Idx_To_Bd_Idx(Ins_Bd_Index, pm_All)
			
			'フォーカス決定
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	'======================= 変更部分 2006.06.26 End =================================
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_UnDoDe
	'   概要：  メニューの明細復元の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_UnDoDe(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Bd_Index As Short
		Dim Row_Inf_Max_S As Short
		Dim Row_Inf_Max_E As Short
		Dim Bd_Index_Wk As Short
		Dim Row_Wk As Short
		
		'画面の内容を退避
		Call CF_Body_Bkup(pm_All)
		
		'Dsp_Body_Infの行ＮＯを取得
		Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		
		'共通の明細復元
		If CF_Cmn_Ctl_MN_UnDoDe(pm_All, Row_Inf_Max_S, Row_Inf_Max_E) = True Then
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'行を追加された後に
			'初期値を追加した行に対してループ内で１行ずつ行う
			'ここでの行は、Dsp_Body_Infの行！！
			For Bd_Index_Wk = Row_Inf_Max_S To Row_Inf_Max_E
				Call F_Init_Dsp_Body(Bd_Index_Wk, pm_All)
			Next 
			
			'行Ｎｏ採番処理
			Call F_Edi_Saiban_No(pm_All)
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
			
			'画面表示
			'Call CF_Body_Dsp(pm_All)
			Call F_Body_Dsp(pm_All)
			
			'元の画面の行に移動
			Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
			
			'フォーカス決定
			Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
			
		End If
		
	End Function
	'======================= 変更部分 2006.06.26 Start =================================
	
	'======================= 変更部分 2006.07.02 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_Paste
	'   概要：  メニューの貼り付けの制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_Paste(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		
		Dim Clip_Value As String
		Dim Paste_Value As String
		
		Dim Act_SelStart As Short
		Dim Act_SelLength As Short
		Dim Act_SelStr As String
		Dim Act_SelStrB As Integer
		Dim Wk_SelStart As Short
		Dim Wk_SelLength As Short
		Dim Wk_EditMoji As String
		Dim Wk_CurMoji As String
		Dim Wk_DspMoji As String
		
		'ｸﾘｯﾌﾟﾎﾞｰﾄﾞから内容取得
		'UPGRADE_ISSUE: Clipboard メソッド Clipboard.GetText はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="076C26E5-B7A9-4E77-B69C-B4448DF39E58"' をクリックしてください。
		Clip_Value = My.Computer.Clipboard.GetText()
		'入力文字可能を取り出す
		Paste_Value = CF_Get_Input_Ok_Item(Clip_Value, pm_Dsp_Sub_Inf)
		
		'貼り付け内容がない場合、処理中断
		If Paste_Value = "" Then
			Exit Function
		End If
		
		'現在のﾃｷｽﾄ上の選択状態を取得
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
		Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		'現在の値を取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Wk_CurMoji = CF_Get_Input_Ok_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)
		
		If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
			'詰文字が左詰の場合
			
			'文字編集
			'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Wk_EditMoji = CF_Cnv_Dsp_Item(Paste_Value, pm_Dsp_Sub_Inf, False)
			
			'編集後のSelStartを決定
			'右端へ移動
			Wk_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
			Wk_SelLength = 0
		Else
			'詰文字が左詰以外の場合
			
			If Act_SelLength = 0 Then
				'選択なしの場合(挿入状態)
				'文字編集
				Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value & Mid(Wk_CurMoji, Act_SelStart + 1)
			Else
				'一部選択
				If Act_SelLength >= 2 Then
					'２文字以上選択している場合は
					'選択文字より後ろの文字もつける
					'文字編集
					Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value & Mid(Wk_CurMoji, Act_SelStart + Act_SelLength + 1)
				Else
					'１文字以下選択している場合は
					'選択文字以降は入れ換え
					'文字編集
					Wk_EditMoji = Left(Wk_CurMoji, Act_SelStart) & Paste_Value
					
				End If
				
			End If
			
			'編集後のSelStartを決定
			'左端へ移動
			Wk_SelStart = 0
			Wk_SelLength = 1
			
		End If
		
		Select Case pm_Dsp_Sub_Inf.Detail.In_Typ
			Case IN_TYP_DATE
				'日付の場合、入力形式が決まっている場合
				'日付入力形式の桁数だけ取得
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_DATE))
			Case IN_TYP_YYYYMM
				'年月の場合、入力形式が決まっている場合
				'日付入力形式の桁数だけ取得
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_YYYMM))
			Case IN_TYP_HHMM
				'時刻の場合、入力形式が決まっている場合
				'日付入力形式の桁数だけ取得
				Wk_EditMoji = Left(Wk_EditMoji, Len(IN_FMT_HHMM))
			Case Else
				
		End Select
		
		'編集後の文字を表示形式に変換
		'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, False)
		
		'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
		Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)
		
		'編集後のSelStartを決定
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
		'編集後のSelLengthを決定
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
		
		'明細入力後の後処理
		Call F_Ctl_Item_Input_Aft(pm_Dsp_Sub_Inf, pm_All)
		
	End Function
	'======================= 変更部分 2006.07.02 End =================================
	
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Edi_Saiban_No
	'   概要：  全明細の行ＮＯを設定する
	'   引数：　なし
	'   戻値：　なし
	'   備考：  プログラム単位の処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Edi_Saiban_No(ByRef pm_All As Cls_All) As Short
		Dim Wk_Index As Short
		Dim Bd_Index As Short
		
		
	End Function
	'======================= 変更部分 2006.06.26 End =================================
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Hardcopy_SSSMAIN
	'   概要：  ハードコピー画面呼出し後処理
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Hardcopy_SSSMAIN() As Short 'Generated.
		If AE_MsgLibrary(PP_SSSMAIN, "Hardcopy") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		On Error Resume Next
		System.Windows.Forms.Application.DoEvents()
		FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.WaitCursor
		'UPGRADE_ISSUE: Form メソッド FR_SSSMAIN.PrintForm はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="CC4C7EC0-C903-48FC-ACCC-81861D12DA4A"' をクリックしてください。
		FR_SSSMAIN.PrintForm()
		FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.Arrow
		If Err.Number <> 0 Then
			If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		On Error GoTo 0
		AE_Hardcopy_SSSMAIN = Cn_CuCurrent
	End Function
	
	'2007/12/18 add-str M.SUEZAWA 訂正前に更新時間チェックを入れる
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_UWRTDTTM
	'   概要：  更新時間チェック処理
	'   引数：  pm_All        : 画面情報
	'   戻値：　True：チェックOK　False：チェックNG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_UWRTDTTM(ByRef pm_All As Cls_All) As Boolean
		
		Dim strSQL As String
		Dim bolRet As Boolean
		
		Dim strWRTDT As String
		Dim strWRTTM As String
		Dim strUWRTDT As String
		Dim strUWRTTM As String
		Dim strUWRT_MOTO As String
		' === 20080901 === INSERT S - RISE)Izumi
		Dim strOPEID As String
		Dim strCLTID As String
		Dim strUOPEID As String
		Dim strUCLTID As String
		' === 20080901 === INSERT E - RISE)Izumi
		
		Dim intCnt As Short
		Dim intRet As Short
		Dim strWhere As String
		
		'2007/12/27 add-str M.SUEZAWA
		Dim Upd_Start As Short
		Dim Upd_End As Short
		'2007/12/27 add-end M.SUEZAWA
		
		On Error GoTo F_Chk_UWRTDTTM_err
		
		F_Chk_UWRTDTTM = False
		
		'2007/12/27 add-str M.SUEZAWA
		'ループ開始、終了の計算
		Upd_Start = pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1) + 1
		Upd_End = pm_All.Dsp_Base.Dsp_Body_Cnt * NowPageNum
		'2007/12/27 add-end M.SUEZAWA
		
		'更新時間取得
		'2007/12/27 upd-str M.SUEZAWA
		''    For intCnt = 1 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		For intCnt = Upd_Start To Upd_End
			'2007/12/27 upd-end M.SUEZAWA
			
			'2007/12/27 add-str T.KAWAMUKAI
			'2007/12/27 upd-str M.SUEZAWA
			''        If Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.PGID) = "" Then
			'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(pc_COL_UPDKB).Dsp_Value) = "" Then
				'2007/12/27 upd-end M.SUEZAWA
				Exit For
			End If
			'2007/12/27 add-end T.KAWAMUKAI
			
			'2007/12/27 add-str M.SUEZAWA
			''        strUWRT_MOTO = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UWRTDT) _
			'''                     & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UWRTTM)
			' === 20080902 === UPDATE S - RISE)Izumi
			'        strUWRT_MOTO = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_WRTDT) _
			''                     & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_WRTTM) _
			''                     & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UWRTDT) _
			''                     & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UWRTTM)
			strUWRT_MOTO = Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_WRTDT) & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_WRTTM) & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UWRTDT) & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UWRTTM) & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_OPEID) & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_CLTID) & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UOPEID) & Trim(pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.MOTO_UCLTID)
			' === 20080902 === UPDATE E - RISE)Izumi
			'2007/12/27 add-end M.SUEZAWA
			If strUWRT_MOTO <> "" Then
				'更新時間取得
				'2007/12/27 upd-str T.KAWAMUKAI
				''            intRet = F_Get_UWRTDTTM("TRKMTA",
				' === 20080901 === UPDATE S - RISE)Izumi
				'            intRet = F_Get_UWRTDTTM("KNGMTB", _
				''                                    pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.KNGGRCD, _
				''                                    pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.PGID, _
				''                                    strWRTDT, _
				''                                    strWRTTM, _
				''                                    strUWRTDT, _
				''                                    strUWRTTM)
				intRet = F_Get_UWRTDTTM("KNGMTB", pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.KNGGRCD, pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Bus_Inf.PGID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, strOPEID, strCLTID, strUOPEID, strUCLTID)
				' === 20080901 === UPDATE E - RISE)Izumi
				'2007/12/27 upd-end T.KAWAMUKAI
				If intRet <> 0 Then
					GoTo F_Chk_UWRTDTTM_End
				End If
				
				'更新時間チェック
				' === 20080902 === UPDATE S - RISE)Izumi
				'            If Trim(strWRTDT) & Trim(strWRTTM) & Trim(strUWRTDT) & Trim(strUWRTTM) <> strUWRT_MOTO Then
				'                GoTo F_Chk_UWRTDTTM_End
				'            End If
				If Trim(strWRTDT) & Trim(strWRTTM) & Trim(strUWRTDT) & Trim(strUWRTTM) & Trim(strOPEID) & Trim(strCLTID) & Trim(strUOPEID) & Trim(strUCLTID) <> strUWRT_MOTO Then
					GoTo F_Chk_UWRTDTTM_End
				End If
				' === 20080902 === UPDATE E - RISE)Izumi
			End If
		Next 
		
		F_Chk_UWRTDTTM = True
		
F_Chk_UWRTDTTM_End: 
		Exit Function
		
F_Chk_UWRTDTTM_err: 
		GoTo F_Chk_UWRTDTTM_End
		
	End Function
	
	' === 20080902 === UPDATE S - RISE)Izumi
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	''   名称：  Function F_Get_UWRTDTTM
	''   概要：  更新日付時間取得処理
	''   引数：  pin_strTBLNM            : 検索対象テーブル名
	''           pin_strKNGGRCD          : 権限グループ
	''           pin_strPGID             : プログラムＩＤ
	''           pot_strWRTDT            : 更新日付
	''           pot_strWRTTM            : 更新時刻
	''           pot_strUWRTDT           : バッチ更新日付
	''           pot_strUWRTTM           : バッチ更新時刻
	''   戻値：  0 : 正常終了  9 : 異常終了
	''   備考：
	'' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function F_Get_UWRTDTTM(ByVal pin_strTBLNM As String, _
	''                                ByVal pin_strKNGGRCD As String, _
	''                                ByVal pin_strPGID As String, _
	''                                ByRef pot_strWRTDT As String, _
	''                                ByRef pot_strWRTTM As String, _
	''                                ByRef pot_strUWRTDT As String, _
	''                                ByRef pot_strUWRTTM As String) As Integer
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Get_UWRTDTTM
	'   概要：  更新日付時間取得処理
	'   引数：  pin_strTBLNM            : 検索対象テーブル名
	'           pin_strKNGGRCD          : 権限グループ
	'           pin_strPGID             : プログラムＩＤ
	'           pot_strWRTDT            : 更新日付
	'           pot_strWRTTM            : 更新時刻
	'           pot_strUWRTDT           : バッチ更新日付
	'           pot_strUWRTTM           : バッチ更新時刻
	'           pot_strOPEID            : 最終作業者コード
	'           pot_strCLTID            : クライアントＩＤ
	'           pot_strUOPEID           : 最終作業者コード（バッチ）
	'           pot_strUCLTID           : クライアントＩＤ（バッチ）
	'   戻値：  0 : 正常終了  9 : 異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Get_UWRTDTTM(ByVal pin_strTBLNM As String, ByVal pin_strKNGGRCD As String, ByVal pin_strPGID As String, ByRef pot_strWRTDT As String, ByRef pot_strWRTTM As String, ByRef pot_strUWRTDT As String, ByRef pot_strUWRTTM As String, ByRef pot_strOPEID As String, ByRef pot_strCLTID As String, ByRef pot_strUOPEID As String, ByRef pot_strUCLTID As String) As Short
		' === 20080902 === UPDATE E - RISE)Izumi
		
		On Error GoTo F_Get_UWRTDTTM_ERR
		
		Dim Str_Sql As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		
		F_Get_UWRTDTTM = 9
		
		'// 初期化
		pot_strWRTDT = ""
		pot_strWRTTM = ""
		pot_strUWRTDT = ""
		pot_strUWRTTM = ""
		' === 20080902 === INSERT S - RISE)Izumi
		pot_strOPEID = ""
		pot_strCLTID = ""
		pot_strUOPEID = ""
		pot_strUCLTID = ""
		' === 20080902 === INSERT E - RISE)Izumi
		
		'引数チェック
		If Trim(pin_strKNGGRCD) = "" Or Trim(pin_strPGID) = "" Then
			GoTo F_Get_UWRTDTTM_END
		End If
		
		Str_Sql = ""
		Str_Sql = Str_Sql & " SELECT "
		Str_Sql = Str_Sql & "        WRTDT  "
		Str_Sql = Str_Sql & "      , WRTTM  "
		Str_Sql = Str_Sql & "      , UWRTDT "
		Str_Sql = Str_Sql & "      , UWRTTM "
		' === 20080901 === INSERT S - RISE)Izumi
		Str_Sql = Str_Sql & "      , OPEID  "
		Str_Sql = Str_Sql & "      , CLTID "
		Str_Sql = Str_Sql & "      , UOPEID "
		Str_Sql = Str_Sql & "      , UCLTID "
		' === 20080901 === INSERT E - RISE)Izumi
		Str_Sql = Str_Sql & "   FROM "
		Str_Sql = Str_Sql & "        " & Trim(pin_strTBLNM)
		Str_Sql = Str_Sql & "   WHERE "
		Str_Sql = Str_Sql & "        KNGGRCD  = '" & Trim(pin_strKNGGRCD) & "'"
		Str_Sql = Str_Sql & "    AND PGID     = '" & Trim(pin_strPGID) & "'"
		' === 20080901 === INSERT S - RISE)Izumi
		Str_Sql = Str_Sql & "    FOR UPDATE"
		' === 20080901 === INSERT E - RISE)Izumi
		
		If CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, Str_Sql) = False Then
			GoTo F_Get_UWRTDTTM_ERR
		End If
		
		If CF_Ora_EOF(Usr_Ody) = False Then
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_strWRTDT = Trim(CF_Ora_GetDyn(Usr_Ody, "WRTDT"))
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_strWRTTM = Trim(CF_Ora_GetDyn(Usr_Ody, "WRTTM"))
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_strUWRTDT = Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTDT"))
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_strUWRTTM = Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTTM"))
			' === 20080902 === INSERT S - RISE)Izumi
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_strOPEID = Trim(CF_Ora_GetDyn(Usr_Ody, "OPEID"))
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_strCLTID = Trim(CF_Ora_GetDyn(Usr_Ody, "CLTID"))
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_strUOPEID = Trim(CF_Ora_GetDyn(Usr_Ody, "UOPEID"))
			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pot_strUCLTID = Trim(CF_Ora_GetDyn(Usr_Ody, "UCLTID"))
			' === 20080902 === INSERT E - RISE)Izumi
		End If
		
		F_Get_UWRTDTTM = 0
		
F_Get_UWRTDTTM_END: 
		Call CF_Ora_CloseDyn(Usr_Ody)
		Exit Function
		
F_Get_UWRTDTTM_ERR: 
		GoTo F_Get_UWRTDTTM_END
		
	End Function
	'2007/12/18 add-end M.SUEZAWA
	
	'□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□
End Module