Option Strict Off
Option Explicit On
'20190809 CHG START
Imports Oracle.DataAccess.Client
Imports PronesDbAccess
'20190809 CHG END
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'
	'単プロジェクトごとの共通ライブラリ
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(92 + 6 + 0 + 1) As clsCP
	Public CL_SSSMAIN(92) As Short
    Public CQ_SSSMAIN(8) As String


    '20190809  ADD START
    Public D0 = New ClsComn
    Public LV_Col_Order() As Integer
    '20190809 ADD END

    '2008/07/09 START ADD FNAP)YAMANE 連絡票�ａF排他-54
    Public HAITA_FLG As String
	'2008/07/09 E.N.D ADD FNAP)YAMANE 連絡票�ａF排他-54
	
	'□□□□□□□□ プログラム単位の共通処理 Start □□□□□□□□□□□□□□□□
	'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
	'初期処理時チェック実行フラグ
	Public gv_bolInit As Boolean '初期処理時はTrue(チェックなし）　それ以外はFalse
	Public gv_bolCLDMT51_INIT As Boolean '画面初期化フラグ（True:変更あり）
	' === 20060801 === INSERT S - エンターキー連打による不具合修正・検索W表示時の不具合対応
	Public gv_bolCLDMT51_LF_Enable As Boolean 'LF処理実行フラグ(False：実行しない)
	Public gv_bolKeyFlg As Boolean
	' === 20060801 === INSERT E
	' === 20060808 === INSERT S - エンターキー連打による不具合修正２
	Public gv_bolUpdFlg As Boolean
	' === 20060808 === INSERT E
	
	Public Structure CLDMT51_TYPE_CLDMTA
		Dim DATKB As String '伝票削除区分
		Dim CLDDT As String '日付
		Dim CLDWKKB As String '曜日
		Dim CLDHLKB As String '祝日
		Dim SLSMDD As String '営業通算日数
		Dim PRDKDDD As String '生産稼働日数
		Dim DTBKDDD As String '物流稼働日数
		Dim CLDSMDD As String '暦日通算日数
		Dim SLDKB As String '営業日区分
		Dim BNKKDKB As String '銀行稼動区分
		Dim PRDKDKB As String '生産稼動区分
		Dim DTBKDKB As String '物流稼動区分
	End Structure
	'カレンダマスタ情報
	Public CLDMT51_CLDMTA_Inf As CLDMT51_TYPE_CLDMTA
	'カレンダマスタ情報（更新用）
	Public CLDMT51_CLDMTA_Update_Inf() As CLDMT51_TYPE_CLDMTA
	
	'ページ情報
	Public MaxPageNum As Short '明細の最大ページ数
	Public NowPageNum As Short '明細の現在のページ数
	Public MinPageNum As Short '明細の最小ページ数
	
	'モード
	'Public Const UPDKB_INS              As String = "追加"
	Public Const UPDKB_UPD As String = "更新"
	'Public Const UPDKB_DEL              As String = "削除"
	
	'
	Private pv_bolMEISAI_INPUT As Boolean '明細入力フラグ(True:入力あり）
	Private pv_intMeisaiCnt As Short '入力明細数（更新時使用）
	Private pv_bolInput_Bef_Row As Boolean '前行入力フラグ（True:入力済）
	
	'LLLLL 20060913 INSERT S LLLLLLLLLLLLLLL
	'ページ遷移ボタン押下時の不具合対応。（フォーカスの奪い合いを回避）
	Public gb_pageChange As Boolean 'ページ遷移判定フラグ
	Public gb_txtChange As Boolean 'ページ遷移判定フラグ
	Public gb_dateYM As String '前月／次月
	'LLLLL 20060913 INSERT E LLLLLLLLLLLLLLL
	
	'LLLLL 20060913 INSERT S LLLLLLLLLLLLLLL
	Public gb_CldUpdFlg As Boolean 'カレンダー更新フラグ（True:更新可）
	'LLLLL 20060913 INSERT E LLLLLLLLLLLLLLL
	
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
	'//F_Dsp_Item_Detail処理モード
	Public Const DSP_SET As Short = 0 '表示
	Public Const DSP_CLR As Short = 1 'クリア
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_CLD_SQL
	'   概要：  データ取得ＳＱＬ生成
	'   引数：　pm_clddt    :登録年月（条件）
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_GET_CLD_SQL(ByRef pm_clddt As String) As String
		
		Dim strSQL As String
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "     DATKB " '伝票削除区分
		strSQL = strSQL & "    ,CLDDT " '日付
		strSQL = strSQL & "    ,CLDWKKB " '曜日
		strSQL = strSQL & "    ,CLDHLKB " '祝日
		strSQL = strSQL & "    ,SLSMDD " '営業通算日数
		strSQL = strSQL & "    ,PRDKDDD " '生産稼働日数
		strSQL = strSQL & "    ,DTBKDDD " '物流稼働日数
		strSQL = strSQL & "    ,CLDSMDD " '暦日通算日数
		strSQL = strSQL & "    ,SLDKB " '営業日区分
		strSQL = strSQL & "    ,BNKKDKB " '銀行稼動区分
		strSQL = strSQL & "    ,PRDKDKB " '生産稼動区分
		strSQL = strSQL & "    ,DTBKDKB " '物流稼動区分
		' === 20081001 === UPDATE S - RISE)Izumi
		''2007/12/27 add-str M.SUEZAWA
		'    strSQL = strSQL & "    ,WRTTM "         '更新時間
		'    strSQL = strSQL & "    ,WRTDT "         '更新日付
		'    strSQL = strSQL & "    ,UWRTTM "        'バッチ更新時間
		'    strSQL = strSQL & "    ,UWRTDT "        'バッチ更新日付
		''2007/12/27 add-end M.SUEZAWA
		strSQL = strSQL & "    ,OPEID " '最終作業者コード
		strSQL = strSQL & "    ,CLTID " 'クライアントＩＤ
		strSQL = strSQL & "    ,WRTTM " '更新時間
		strSQL = strSQL & "    ,WRTDT " '更新日付
		strSQL = strSQL & "    ,UOPEID " '最終作業者コード（バッチ）
		strSQL = strSQL & "    ,UCLTID " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "    ,UWRTTM " 'バッチ更新時間
		strSQL = strSQL & "    ,UWRTDT " 'バッチ更新日付
		' === 20081001 === UPDATE E - RISE)Izumi
		
		strSQL = strSQL & " FROM "
		strSQL = strSQL & "     CLDMTA "
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     CLDDT LIKE '" & pm_clddt & "%' "
		strSQL = strSQL & " AND "
		strSQL = strSQL & "     DATKB = '1' "
		strSQL = strSQL & " ORDER BY "
		strSQL = strSQL & "     CLDDT "
		
		F_GET_CLD_SQL = strSQL
		
	End Function
	
	'LLLLL 20060913 INSERT S LLLLLLLLLLLLLLL
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Get_CLDUPDKB_SQL
	'   概要：  データ取得ＳＱＬ生成
	'   引数：　pm_tancd    :担当者コード（条件）
	'   戻値：　生成SQL
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_CLDUPDKB_SQL(ByRef pm_TANCD As String) As String
		
		Dim strSQL As String
		
		'検索ＳＱＬ発行
		strSQL = ""
		strSQL = strSQL & " SELECT  "
		strSQL = strSQL & "     A.CLDUPDKB  "
		strSQL = strSQL & " FROM  "
		strSQL = strSQL & "     KNGMTA A "
		strSQL = strSQL & "   , TANMTA B "
		strSQL = strSQL & " WHERE "
		strSQL = strSQL & "     A.KNGGRCD = B.KNGGRCD "
		strSQL = strSQL & " AND "
		strSQL = strSQL & "     B.TANCD = '" & pm_TANCD & "' "
		
		F_Get_CLDUPDKB_SQL = strSQL
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_KNGMTA_CLDUPDKB
	'   概要：  カレンダーマスタ更新権限チェック
	'   引数：  pm_All      :全構造体
	'   戻値：　Integer
	'   備考：  カレンダーマスタの更新権限有無をチェック
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_KNGMTA_CLDUPDKB(ByRef pm_All As Cls_All) As Short
		
		'権限情報取得（カレンダ更新権限）
		F_Chk_KNGMTA_CLDUPDKB = F_Get_CLDUpdKB()
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Get_CLDUPdKB_Inf
	'   概要：  権限情報取得
	'   引数：　なし
	'   戻値：　カレンダ更新権限
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Get_CLDUpdKB() As Short
		
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strSQL As String
		Dim strKNGGRCD As String
		
		On Error GoTo ERR_F_Get_CLDUpdKB
		
		F_Get_CLDUpdKB = -1
		
		'いったん、権限なしとする
		strKNGGRCD = gc_strTKCHGKB_NG
		
		' 2006/10/31  CHG START  KUMEDA
		'    '権限グループ取得ＳＱＬ作成
		'    strSQL = F_Get_CLDUPDKB_SQL(Inp_Inf.InpTanCd)
		'
		'    'DBアクセス
		'    Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
		'
		'    If CF_Ora_EOF(Usr_Ody) = True Then
		'        '取得データなし
		'        GoTo END_F_Get_CLDUpdKB
		'    Else
		'        strKNGGRCD = CF_Ora_GetDyn(Usr_Ody, "CLDUPDKB", "")          'カレンダー更新区分
		'
		'        If Trim(strKNGGRCD) = gc_strTKCHGKB_OK Then
		'            F_Get_CLDUpdKB = CHK_OK
		'        End If
		'
		'    End If
		'' 2006/11/13  CHG START  KUMEDA
		''    gs_userid = Inp_Inf.InpTanCd
		''    gs_pgid = SSS_PrgId
		''
		''    gs_kengen = Get_Authority(GV_UNYDate)
		''
		''    strKNGGRCD = gs_UPDAUTH
		''
		''    If Trim(strKNGGRCD) = gc_strTKCHGKB_OK Then
		''        F_Get_CLDUpdKB = CHK_OK
		''    End If
		If Inp_Inf.InpJDNUPDKB = "1" Then
			F_Get_CLDUpdKB = CHK_OK
		End If
		'' 2006/11/13  CHG END
		' 2006/10/31  CHG END
		
		
END_F_Get_CLDUpdKB: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
ERR_F_Get_CLDUpdKB: 
		GoTo END_F_Get_CLDUpdKB
		
	End Function
	
	'LLLLL 20060913 INSERT E LLLLLLLLLLLLLLL
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_GET_BD_DATA
	'   概要：  ボディ部データ取得
	'   引数：  pm_All      :全構造体
	'   戻値：　取得行数
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_GET_BD_DATA(ByRef pm_All As Cls_All) As Short
		Dim strSQL As String
		Dim intData As Short
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim intMode As Short
		Dim intCnt As Short
		Dim intDCnt As Short
		Dim Wk_Index As Short
		Dim Err_Cd As String
		Dim Rtn_Str_Value As String
		Dim I As Short
		Dim strWKKBNM As String
		Dim Dsp_Value As Object
		
		On Error GoTo ERR_F_GET_BD_DATA
		
		F_GET_BD_DATA = -1
		
		'初期化
		strSQL = ""
		Err_Cd = ""
		
		'検索ＳＱＬ生成
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Rtn_Str_Value = CF_Get_Input_Ok_Item(CStr(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_CLDDT.Tag)))), pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_CLDDT.Tag)))
		
		If Trim(Rtn_Str_Value) = "" Then
			'取得データなし
			F_GET_BD_DATA = 0
			
			GoTo END_F_GET_BD_DATA
		End If
		
		strSQL = F_GET_CLD_SQL(Rtn_Str_Value)

        'DBアクセス
        '20190814 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)

        'If CF_Ora_EOF(Usr_Ody) = True Then
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            '20190814 CHG END
            '取得データなし
            F_GET_BD_DATA = 0
            'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            pm_All.Dsp_Sub_Inf(CShort(FR_SSSMAIN.HD_CLDDT.Tag)).Detail.Err_Status = ERR_ELSE
            Err_Cd = gc_strMsgCLDMT51_E_002
            Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)

            GoTo END_F_GET_BD_DATA
        Else

            ' === 20081001 === DELETE S - RISE)Izumi
            ''2007/12/27 del-str T.KAWAMUKAI 2007/12/27 元に戻す　M.SUEZAWA
            '''2007/12/13 add-str T.KAWAMUKAI 元データのタイムスタンプ退避
            '        M_MOTO_inf.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")      '更新時刻
            '        M_MOTO_inf.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")      '更新日付
            '        M_MOTO_inf.UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")    'バッチ更新時刻
            '        M_MOTO_inf.UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")    'バッチ更新日付
            '''2007/12/13 add-end T.KAWAMUKAI
            ''2007/12/27 del-end T.KAWAMUKAI
            ' === 20081001 === DELETE E - RISE)Izumi

            '初期化
            For intCnt = 0 To 30 Step 1
				With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
					.Bus_Inf.Selected = CStr(False) '選択/非選択
					.Bus_Inf.DATKB = "" '伝票削除区分
					.Bus_Inf.CLDDT = "" '日付
					.Bus_Inf.CLDWKKB = "" '曜日
					.Bus_Inf.CLDHLKB = "" '祝日
					.Bus_Inf.SLSMDD = "" '営業通算日数
					.Bus_Inf.PRDKDDD = "" '生産稼働日数
					.Bus_Inf.DTBKDDD = "" '物流稼働日数
					.Bus_Inf.CLDSMDD = "" '暦日通算日数
					.Bus_Inf.SLDKB = "" '営業日区分
					.Bus_Inf.BNKKDKB = "" '銀行稼動区分
					.Bus_Inf.PRDKDKB = "" '生産稼動区分
					.Bus_Inf.DTBKDKB = "" '物流稼動区分
				End With
			Next intCnt
			
			'モード設定（更新：UPDKB_UPD）のみ
			Wk_Index = CShort(FR_SSSMAIN.HD_UPDKB.Tag)
			Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(UPDKB_UPD, pm_All.Dsp_Sub_Inf(Wk_Index), False), pm_All.Dsp_Sub_Inf(Wk_Index), pm_All, SET_FLG_DEF)
			
			intCnt = 0
            'Do Until CF_Ora_EOF(Usr_Ody) = True
            For j As Integer = 0 To dt.Rows.Count - 1
                '取得全レコードよりボディ情報退避
                With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
                    .Bus_Inf.Selected = CStr(False) '選択/非選択
                    '20190819 CHG START
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '               .Bus_Inf.DATKB = CF_Ora_GetDyn(Usr_Ody, "DATKB", "") '伝票削除区分
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.CLDDT = CF_Ora_GetDyn(Usr_Ody, "CLDDT", "") '日付
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.CLDWKKB = CF_Ora_GetDyn(Usr_Ody, "CLDWKKB", "") '曜日
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.CLDHLKB = CF_Ora_GetDyn(Usr_Ody, "CLDHLKB", "") '祝日
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.SLSMDD = CF_Ora_GetDyn(Usr_Ody, "SLSMDD", "") '営業通算日数
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.PRDKDDD = CF_Ora_GetDyn(Usr_Ody, "PRDKDDD", "") '生産稼働日数
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.DTBKDDD = CF_Ora_GetDyn(Usr_Ody, "DTBKDDD", "") '物流稼働日数
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.CLDSMDD = CF_Ora_GetDyn(Usr_Ody, "CLDSMDD", "") '暦日通算日数
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.SLDKB = CF_Ora_GetDyn(Usr_Ody, "SLDKB", "") '営業日区分
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.BNKKDKB = CF_Ora_GetDyn(Usr_Ody, "BNKKDKB", "") '銀行稼動区分
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.PRDKDKB = CF_Ora_GetDyn(Usr_Ody, "PRDKDKB", "") '生産稼動区分
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.DTBKDKB = CF_Ora_GetDyn(Usr_Ody, "DTBKDKB", "") '物流稼動区分

                    .Bus_Inf.DATKB = DB_NullReplace(dt.Rows(j)("DATKB"), "")
                    .Bus_Inf.CLDDT = DB_NullReplace(dt.Rows(j)("CLDDT"), "")
                    .Bus_Inf.CLDWKKB = DB_NullReplace(dt.Rows(j)("CLDWKKB"), "")
                    .Bus_Inf.CLDHLKB = DB_NullReplace(dt.Rows(j)("CLDHLKB"), "")
                    .Bus_Inf.SLSMDD = DB_NullReplace(dt.Rows(j)("SLSMDD"), "")
                    .Bus_Inf.PRDKDDD = DB_NullReplace(dt.Rows(j)("PRDKDDD"), "")
                    .Bus_Inf.DTBKDDD = DB_NullReplace(dt.Rows(j)("DTBKDDD"), "")
                    .Bus_Inf.CLDSMDD = DB_NullReplace(dt.Rows(j)("CLDSMDD"), "")
                    .Bus_Inf.SLDKB = DB_NullReplace(dt.Rows(j)("SLDKB"), "")
                    .Bus_Inf.BNKKDKB = DB_NullReplace(dt.Rows(j)("BNKKDKB"), "")
                    .Bus_Inf.PRDKDKB = DB_NullReplace(dt.Rows(j)("PRDKDKB"), "")
                    .Bus_Inf.DTBKDKB = DB_NullReplace(dt.Rows(j)("DTBKDKB"), "")

                    '2007/12/27 add-str T.KAWAMUKAI  2007/12/27 del M.SUEZAWA
                    '''                .Bus_Inf.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")            '更新日付
                    '''                .Bus_Inf.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")            '更新時間
                    '''                .Bus_Inf.UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")          'バッチ日付
                    '''                .Bus_Inf.UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")          'バッチ時間
                    '2007/12/27 add-end T.KAWAMUKAI
                    ' === 20081001 === INSERT S - RISE)Izumi
                    'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '               .Bus_Inf.OPEID = CF_Ora_GetDyn(Usr_Ody, "OPEID", "") '最終作業者コード
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.CLTID = CF_Ora_GetDyn(Usr_Ody, "CLTID", "") 'クライアントＩＤ
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.WRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '更新日付
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.WRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '更新時間
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.UOPEID = CF_Ora_GetDyn(Usr_Ody, "UOPEID", "") '最終作業者コード（バッチ）
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.UCLTID = CF_Ora_GetDyn(Usr_Ody, "UCLTID", "") 'クライアントＩＤ（バッチ）
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.UWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") 'バッチ日付
                    ''UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '.Bus_Inf.UWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") 'バッチ時間

                    .Bus_Inf.OPEID = DB_NullReplace(dt.Rows(j)("OPEID"), "")
                    .Bus_Inf.CLTID = DB_NullReplace(dt.Rows(j)("CLTID"), "")
                    .Bus_Inf.WRTDT = DB_NullReplace(dt.Rows(j)("WRTDT"), "")
                    .Bus_Inf.WRTTM = DB_NullReplace(dt.Rows(j)("WRTTM"), "")
                    .Bus_Inf.UOPEID = DB_NullReplace(dt.Rows(j)("UOPEID"), "")
                    .Bus_Inf.UCLTID = DB_NullReplace(dt.Rows(j)("UCLTID"), "")
                    .Bus_Inf.UWRTDT = DB_NullReplace(dt.Rows(j)("UWRTDT"), "")
                    .Bus_Inf.UWRTTM = DB_NullReplace(dt.Rows(j)("UWRTTM"), "")
                    '20190819 CHG END
                    ' === 20081001 === INSERT E - RISE)Izumi

                    '対象行の状態
                    pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Status = BODY_ROW_STATE_DEFAULT

                End With

                intCnt = intCnt + 1

                If intCnt > 31 Then
                    Exit For
                End If

                '次レコード
                'Call CF_Ora_MoveNext(Usr_Ody)
            Next

            intDCnt = intCnt - 1
			
			For intCnt = 0 To 30 Step 1
				With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
					
					'曜日（名称）の設定
					Select Case .Bus_Inf.CLDWKKB
						Case CStr(1)
							strWKKBNM = "日"
						Case CStr(2)
							strWKKBNM = "月"
						Case CStr(3)
							strWKKBNM = "火"
						Case CStr(4)
							strWKKBNM = "水"
						Case CStr(5)
							strWKKBNM = "木"
						Case CStr(6)
							strWKKBNM = "金"
						Case CStr(7)
							strWKKBNM = "土"
					End Select
					
					'画面ボディ情報(PM_ALL.Dsp_Body_Inf)に編集
					'日付
					Wk_Index = CShort(FR_SSSMAIN.BD_CLDT(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(Right(.Bus_Inf.CLDDT, 2), pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'曜日（コード）
					Wk_Index = CShort(FR_SSSMAIN.BD_WKKB(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.CLDWKKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'曜日（名称）
					Wk_Index = CShort(FR_SSSMAIN.BD_WKKBNM(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(strWKKBNM, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'祝祭日
					Wk_Index = CShort(FR_SSSMAIN.BD_CLDHLKB(1).Tag)
					'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Dsp_Value = CF_Edi_Dsp_Body_Inf(.Bus_Inf.CLDHLKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Wk_Index), pm_All, SET_FLG_DB)
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(4).Focus_Ctl = True
					'営業日区分
					Wk_Index = CShort(FR_SSSMAIN.BD_SLDKB(1).Tag)
					'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Dsp_Value = CF_Edi_Dsp_Body_Inf(.Bus_Inf.SLDKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Wk_Index), pm_All, SET_FLG_DB)
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(5).Focus_Ctl = True
					'物流稼動区分
					Wk_Index = CShort(FR_SSSMAIN.BD_DTBKDKB(1).Tag)
					'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Dsp_Value = CF_Edi_Dsp_Body_Inf(.Bus_Inf.DTBKDKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Wk_Index), pm_All, SET_FLG_DB)
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(6).Focus_Ctl = True
					'生産稼動区分
					Wk_Index = CShort(FR_SSSMAIN.BD_PRDKDKB(1).Tag)
					'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Dsp_Value = CF_Edi_Dsp_Body_Inf(.Bus_Inf.PRDKDKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Wk_Index), pm_All, SET_FLG_DB)
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(7).Focus_Ctl = True
					'銀行稼動区分
					Wk_Index = CShort(FR_SSSMAIN.BD_BNKKDKB(1).Tag)
					'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Dsp_Value = CF_Edi_Dsp_Body_Inf(.Bus_Inf.BNKKDKB, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Wk_Index), pm_All, SET_FLG_DB)
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Item_Detail(8).Focus_Ctl = True
					'営業通算稼働日数
					Wk_Index = CShort(FR_SSSMAIN.BD_SLSMDD(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.SLSMDD, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'物流通算稼働日数
					Wk_Index = CShort(FR_SSSMAIN.BD_DTBKDDD(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.DTBKDDD, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'生産通算稼働日数
					Wk_Index = CShort(FR_SSSMAIN.BD_PRDKDDD(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.PRDKDDD, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'暦日通算日数
					Wk_Index = CShort(FR_SSSMAIN.BD_CLDSMDD(1).Tag)
					Call CF_Edi_Dsp_Body_Inf(.Bus_Inf.CLDSMDD, pm_All.Dsp_Sub_Inf(Wk_Index), intCnt, pm_All, SET_FLG_DB)
					'対象行の状態
					pm_All.Dsp_Body_Inf.Row_Inf(intCnt).Status = BODY_ROW_STATE_INPUT
				End With
				
				strWKKBNM = ""
				
			Next intCnt
			
			'        'データ最終行の状態
			'        For I = intDCnt To 30 Step 1
			'            pm_All.Dsp_Body_Inf.Row_Inf(I).Status = BODY_ROW_STATE_LST_ROW
			'        Next I
			
			'行情報構造体配列の Redim
			MaxPageNum = 1
		End If
		
END_F_GET_BD_DATA: 
		'クローズ
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		F_GET_BD_DATA = intCnt
		
		Exit Function
		
ERR_F_GET_BD_DATA: 
		GoTo END_F_GET_BD_DATA
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
	'
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
		Dim Last_Data_Index As Short
		Dim Fcs_Flg As Boolean
		Dim Index_Of_Window As Short
		
		If pm_All.Dsp_Base.Dsp_Body_Cnt > 0 Then
			'明細表示の画面
			
			'ボディ部内で処理
			Bd_Index = 0
			Bd_Index_Bk = 0
			
			For Index_Wk = pm_All.Dsp_Base.Body_Fst_Idx To pm_All.Dsp_Base.Foot_Fst_Idx - 1
				
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Call CF_Set_Item_Not_Change(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Dsp_Value, pm_All.Dsp_Sub_Inf(Index_Wk), pm_All)
					
					'エラーフラグを落とす
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_DEF
					'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
					Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Index_Wk), ITEM_NORMAL_STATUS, pm_All)
					
					'フォーカス有無の判定
					Fcs_Flg = F_Jge_Focus(Index_Wk, pm_All)
					'フォーカスの制御
					Call CF_Set_Item_Focus_Ctl(Fcs_Flg, pm_All.Dsp_Sub_Inf(Index_Wk))
					
					'データ有行ＮＯの退避
					If Fcs_Flg = True Then
						Last_Data_Index = Bd_Index
					End If
				End If
				
			Next 
			
			'明細上のｲﾝﾃﾞｯｸｽを取得
			If Last_Data_Index <> 0 Then
				Index_Of_Window = Last_Data_Index - (pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1)) + ((pm_All.Dsp_Base.Dsp_Body_Cnt * (NowPageNum - 1) + 1) - pm_All.Dsp_Body_Inf.Cur_Top_Index)
			Else
				Index_Of_Window = Last_Data_Index
			End If
		End If
		
	End Function
	' === 20060825 === INSERT E
	
	' === 20060908 === INSERT S
	'
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Jge_Focus
	'   概要：  フォーカス有無の判定
	'   引数：　pm_All      :全構造体
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Private Function F_Jge_Focus(ByRef pm_Index_Tag As Short, ByRef pm_All As Cls_All) As Boolean
		
		Dim Index_Wk As Short
		Dim Tgt_Index As Short
		Dim intCnt As Short
		
		'初期化
		F_Jge_Focus = False
		
		'明細行番号の取得
		'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Index_Wk = pm_All.Dsp_Sub_Inf(pm_Index_Tag).Detail.Body_Index
		
		'「区分」項目の場合
		For intCnt = 0 To 30
			'データ無し行の場合、処理を抜ける
			If Trim(FR_SSSMAIN.BD_CLDT(intCnt).Text) = "" Then
				Exit For
			End If
			
			Select Case pm_Index_Tag
				Case CShort(FR_SSSMAIN.BD_CLDHLKB(intCnt).Tag), CShort(FR_SSSMAIN.BD_SLDKB(intCnt).Tag), CShort(FR_SSSMAIN.BD_DTBKDKB(intCnt).Tag), CShort(FR_SSSMAIN.BD_PRDKDKB(intCnt).Tag), CShort(FR_SSSMAIN.BD_BNKKDKB(intCnt).Tag)
					F_Jge_Focus = True
			End Select
		Next intCnt
		
	End Function
	' === 20060908 === INSERT E
	
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
				
				' === 20060825 === INSERT S
				If intIdx = intBfrUBound + 1 Then
					'追加１行目の状態を最終準備行に設定
					pm_All.Dsp_Body_Inf.Row_Inf(intIdx).Status = BODY_ROW_STATE_LST_ROW
					'管理コードをフォーカスありにする
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					pm_All.Dsp_Body_Inf.Row_Inf(intIdx).Item_Detail(2).Focus_Ctl = True
				End If
				' === 20060825 === INSERT E
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
		'    Call CF_Edi_Dsp_Body_Inf(pm_Bd_Index _
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
		gv_bolCLDMT51_INIT = True
		
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
	Public Function F_Set_Befe_Focus(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Move_Flg As Boolean, ByRef pm_All As Cls_All, Optional ByRef pm_Run_Flg As Boolean = True) As Short
		Dim Trg_Index As Short
		Dim Index_Wk As Short
		Dim Focus_Ctl_Ok_Fst_Idx As Short
		Dim Cur_Top_Index As Short
		Dim Focus_Ctl_Ok_Lst_Idx As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		'次の項目を検索
		For Index_Wk = Trg_Index - 1 To 1 Step -1
			
			'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_TL And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'フッタ部からボディ部へ移動する場合
				'入力可能な最初のインデックスを取得
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index, pm_All)
				If Focus_Ctl_Ok_Fst_Idx > 0 Then
					Index_Wk = Focus_Ctl_Ok_Fst_Idx
				End If
				
			End If
			
			'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_HD Then
				'ボディ部からヘッダ部へ移動する場合
				If CF_Jdg_Row_Up_Focus(Cur_Top_Index, pm_All) = True Then
					'｢上移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
					
					'画面の内容を退避
					Call CF_Body_Bkup(pm_All)
					'移動可能行を一番上に表示した場合の最上明細インデックスを設定
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
					
					'入力可能な最後のインデックスを取得
					Focus_Ctl_Ok_Lst_Idx = CF_Get_Body_Focus_Ctl_Lst_Idx(1, pm_All)
					If Focus_Ctl_Ok_Lst_Idx > 0 Then
						Index_Wk = Focus_Ctl_Ok_Lst_Idx
					End If
					
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
		Dim SubRow As Short
		
		bolDsp = False
		bolAllChk = False
		RtnCode = -1
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'ボディ部
			'Dsp_Body_Infの行ＮＯを取得
			Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
			
			If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index).Status = BODY_ROW_STATE_LST_ROW Then
				'最終準備行の場合
				'入力可能な最初のインデックスを取得
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If pm_Dsp_Sub_Inf.Detail.Body_Index = pm_All.Dsp_Base.Dsp_Body_Cnt Then
					'表示されている最終行の場合
					'入力可能な最後のインデックスを取得
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
								Sta_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag) - pm_All.Dsp_Base.Body_Col_Cnt + 1
								
						End Select
						' === 20060825 === INSERT E
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
			
			'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_HD And pm_All.Dsp_Sub_Inf(Index_Wk).Detail.In_Area = IN_AREA_DSP_BD Then
				'ヘッダ部からボディ部へ移動する場合
				
				''' === 20060824 === INSERT S
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'ﾍｯﾀﾞ部ﾁｪｯｸ
				Rtn_Chk = F_Ctl_Head_Chk(pm_All)
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				If Rtn_Chk <> CHK_OK Then
					'チェックＮＧの場合
					'キーフラグを元に戻す
					gv_bolKeyFlg = False
					Exit For
				End If
				''' === 20060824 === INSERT E
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
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
            '現在のﾃｷｽﾄ上の選択状態を取得
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190813 CHG START
            'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '20190813 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '詰文字が左詰の場合
                    '１文字目を選択する
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190813 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 0
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(0, 1)
                    '20190813 CHG END
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
                        '20190813 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190813 CHG END
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
		Dim Rtn_Chk As Short
		Dim Chk_Move_Flg As Boolean
		Dim Dsp_Mode As Short
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの場合
		'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		Dim SubRow As Short
		If TypeOf pm_Dsp_Sub_Inf.Ctl Is System.Windows.Forms.TextBox Then
            '現在のﾃｷｽﾄ上の選択状態を取得
            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190813 CHG START
            '         Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            '         'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '         Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '20190813 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                    '詰文字が左詰の場合
                    '最終文字を選択する
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190813 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) - 1, 1)
                    '20190813 CHG END
                Else
                    '詰文字が左詰以外の場合
                    '１桁目を選択する
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    '20190813 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = 1
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(1, 1)
                    '20190813 CHG END
                End If
			Else
				If Act_SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) Then
					'選択開始位置が一番右の場合
					
					'ENTキー押下と同様に次の項目へ
					Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
					
					If pm_Move_Flg = False Then
						If pm_Dsp_Sub_Inf.Ctl.Name <> pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_CLDDT.Tag)).Ctl.Name Then
							'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							SubRow = pm_All.Dsp_Base.Dsp_Body_Cnt - pm_All.Dsp_Sub_Inf(CShort(pm_Dsp_Sub_Inf.Ctl.Tag)).Detail.Body_Index + 1
							'ENTキー押下と同様に次の項目へ
							Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - (pm_All.Dsp_Base.Body_Col_Cnt * SubRow) - 5), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
						End If
					End If
				Else
					'選択開始位置が一番右でない場合
					
					'１つ右の１桁を取得
					'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Str_Wk = Mid(CF_Get_Item_Value(pm_Dsp_Sub_Inf), Act_SelStart + 1 + 1, 1)
					
					If Str_Wk = "" Then
						'次の１桁がない場合
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
                            '詰文字が左詰の場合
                            '一番右へ移動し選択なし状態に
                            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '20190813 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                            '20190813 CHG END
                        Else
							'詰文字が左詰以外の場合
							If Act_SelLength = 0 Then
                                '移動前の選択文字数がない場合
                                '一番右へ移動し選択なし状態に
                                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '20190813 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf))
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(CF_Get_Item_Value(pm_Dsp_Sub_Inf)), 0)
                                '20190813 CHG END
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
							
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
                            '20190813 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Next_SelStart
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Next_SelStart, Wk_SelLength)
                            '20190813 CHG END
                        End If
					End If
				End If
				
			End If
		Else
			'現在のｺﾝﾄﾛｰﾙがﾃｷｽﾄﾎﾞｯｸｽの以外場合
			'ENTキー押下と同様に次の項目へ
			Call F_Set_Next_Focus(pm_Dsp_Sub_Inf, NEXT_FOCUS_MODE_KEYRIGHT, pm_Move_Flg, pm_All, pm_Run_Flg)
		End If
		
		F_Set_Right_Next_Focus = Rtn_Chk
		
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
		Dim SubRow As Short
		
		
		'移動フラグ初期化
		pm_Move_Flg = False
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If pm_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And CShort(pm_Dsp_Sub_Inf.Ctl.Tag) >= pm_All.Dsp_Base.Body_Fst_Idx Then
			'明細部の場合
			Wk_Cnt = 0
			Do 
				Wk_Cnt = Wk_Cnt + 1
				'現在の項目に列分だけ下に移動したｲﾝﾃﾞｯｸｽを求める
				Next_Index = Trg_Index + (pm_All.Dsp_Base.Body_Col_Cnt * Wk_Cnt)
				
				'            If Next_Index > pm_All.Dsp_Base.Foot_Fst_Idx - 1 Then
				If Next_Index > pm_All.Dsp_Base.Foot_Fst_Idx - 5 Then
					'項目数を超えた場合
					'最終行の先頭項目以外の場合
					If Trg_Index <> pm_All.Dsp_Base.Foot_Fst_Idx - pm_All.Dsp_Base.Body_Col_Cnt + 3 Then
						'ENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - 5), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
						
					End If
					Exit Do
				End If
				
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(Trg_Index + pm_All.Dsp_Base.Body_Col_Cnt).Detail.Focus_Ctl の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If pm_All.Dsp_Sub_Inf(Trg_Index + pm_All.Dsp_Base.Body_Col_Cnt).Detail.Focus_Ctl = False Then
					'最終データ行の場合
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					SubRow = pm_All.Dsp_Base.Dsp_Body_Cnt - pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Body_Index + 1
					If Trg_Index <> pm_All.Dsp_Base.Foot_Fst_Idx - (pm_All.Dsp_Base.Body_Col_Cnt * SubRow) + 3 Then
						'ENTキー押下と同様に次の項目へ
						Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Foot_Fst_Idx - (pm_All.Dsp_Base.Body_Col_Cnt * SubRow) - 5), NEXT_FOCUS_MODE_KEYDOWN, pm_Move_Flg, pm_All)
					End If
					Exit Do
				End If
				
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
		
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
					Call F_Set_Befe_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All)
					Exit Do
				End If
				
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(Next_Index).Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
						'｢上移動した場合、ﾌｫｰｶｽ移動可能な行がある｣場合
						'画面の内容を退避
						Call CF_Body_Bkup(pm_All)
						'移動可能行を一番上に表示した場合の最上明細インデックスを設定
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
						'明細の一番上の同一項目のｲﾝﾃﾞｯｸｽを取得
						Next_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, 1, pm_All)
						If Next_Index > 0 Then
							If Next_Index = Trg_Index Then
								'同一ｺﾝﾄﾛｰﾙの場合
								'移動無しで終了
								pm_Move_Flg = False
								Exit Do
							Else
								'同一ｺﾝﾄﾛｰﾙでない場合
								'同一項目の１つ後ろから
								'１つ前の項目へ
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Next_Index + 1), pm_Move_Flg, pm_All)
								Exit Do
							End If
						Else
							'入力可能な最初のインデックスを取得
							Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_All.Dsp_Base.Dsp_Body_Cnt, pm_All)
							If Focus_Ctl_Ok_Fst_Idx > 0 Then
								'入力可能な最初の項目の１つ後ろから
								'１つ前の項目へ
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx + 1), pm_Move_Flg, pm_All)
								Exit Do
							Else
								'ヘッダ部の最後の項目の１つ後ろから
								'１つ前の項目へ
								Call F_Set_Befe_Focus(pm_All.Dsp_Sub_Inf(pm_All.Dsp_Base.Head_Lst_Idx + 1), pm_Move_Flg, pm_All)
								Exit Do
								
							End If
						End If
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
		
		'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
			Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
				
			Case CHK_FROM_KEYPRESS
				'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
					'前回と同じチェック内容の場合
					'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
			'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
			'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
		Else
			
			'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Select Case pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process
				Case CHK_FROM_LOSTFOCUS, CHK_FROM_KEYRIGHT, CHK_FROM_KEYDOWN, CHK_FROM_KEYLEFT, CHK_FROM_KEYUP, CHK_FROM_BACK_PROCESS
					Select Case pm_Err_Rtn
						Case CHK_ERR_NOT_INPUT
							'必須入力で未入力
							'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								'チェックＯＫとする
								'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
									'前回と同じチェック内容の場合
									'チェックエラーとする
									'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
									'メッセージ出力なし
									pm_Msg_Flg = False
									'移動ＯＫ
									pm_Move = True
								Else
									'前回と異なるチェック内容の場合
									'チェックエラーとする
									'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
							If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) = pm_Chk_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
								'前回と同じチェック内容の場合
								'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'前回と異なるチェック内容の場合
								'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
							'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								'チェックＯＫとする
								'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								'チェックエラーとする
								'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							End If
						Case CHK_ERR_ELSE
							'その他エラー時
							'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
							'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = False Then
								'１度も未入力以外チェックをしていない場合
								'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT
								pm_Err_Rtn = CHK_OK
								'メッセージ出力なし
								pm_Msg_Flg = False
								'移動ＯＫ
								pm_Move = True
							Else
								'１度でも未入力チェックをしている場合
								'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
								'メッセージ出力あり
								pm_Msg_Flg = True
								'移動ＮＧ
								pm_Move = False
							End If
							
						Case CHK_ERR_ELSE
							'その他エラー時
							'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
							'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_NOT_INPUT
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
						Case CHK_ERR_ELSE
							'その他エラー時
							'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							pm_Chk_Dsp_Sub_Inf.Detail.Err_Status = ERR_ELSE
							'メッセージ出力あり
							pm_Msg_Flg = True
							'移動ＮＧ
							pm_Move = False
							
					End Select
					
			End Select
			
		End If
		
		'チェック関数呼出元処理をクリア
		'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Chk_Dsp_Sub_Inf.Detail.Chk_From_Process = CHK_FROM_ALL_DEFAULT
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_HD_CLDDT
	'   概要：  登録年月のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :画面項目情報
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_HD_CLDDT(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_CLDMTA
		Dim Mst_Inf_Clr As TYPE_DB_CLDMTA
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		Dim Trg_Index As Short
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_HD_CLDDT = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		Call DB_CLDMTA_Clear(Mst_Inf)
		Rtn_Cd = F_GET_BD_DATA(pm_All)
		
		If Rtn_Cd = 0 Then
			'出力できる明細データが無い
			
			'ﾁｪｯｸ後移動なし
			Call CF_Set_Item_SetFocus(pm_Chk_Dsp_Sub_Inf, pm_All)
			'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
			Call CF_Set_Item_Color(pm_Chk_Dsp_Sub_Inf, ITEM_NORMAL_STATUS, pm_All)
			
			Retn_Code = CHK_ERR_ELSE
			F_Chk_HD_CLDDT = Retn_Code
			
			Exit Function
		Else
			'入力コントロールの使用可否制御
			Call F_Set_Inp_Item_Focus_Ctl(False, pm_All)
			'明細を画面に編集
			Trg_Index = CShort(FR_SSSMAIN.HD_CLDDT.Tag)
			Call F_DSP_BD_Inf(pm_All.Dsp_Sub_Inf(Trg_Index), DSP_SET, pm_All)
			
			'明細部にフォーカスセット
			'現在ﾌｫｰｶｽ位置から右へ移動
			Call F_Set_Right_Next_Focus(pm_All.Dsp_Sub_Inf(Trg_Index), True, pm_All, True)
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
		
		F_Chk_HD_CLDDT = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_BD_CLDDT
	'   概要：  明細部のﾁｪｯｸ
	'   引数：　pm_Chk_Dsp_Sub_Inf    :画面項目情報
	'           pm_Chk_Move　　　　　 :チェック後移動フラグ（T：移動OK、F：移動NG）
	'           pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_BD_CLDDT(ByRef pm_Chk_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Chk_Move As Boolean, ByRef pm_All As Cls_All) As Short
		
		Dim Input_Value As String
		Dim Mst_Inf As TYPE_DB_CLDMTA
		Dim Mst_Inf_Clr As TYPE_DB_CLDMTA
		Dim Retn_Code As Short
		Dim Msg_Flg As Boolean
		Dim Rtn_Cd As Short
		Dim Err_Cd As String
		
		'チェック実行判定
		Rtn_Cd = F_Chk_Jge_Action(pm_Chk_Dsp_Sub_Inf, Retn_Code, Msg_Flg, pm_Chk_Move)
		If Rtn_Cd = CHK_STOP Then
			'中断の場合
			F_Chk_BD_CLDDT = Retn_Code
			Exit Function
		End If
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'初期化
		Retn_Code = CHK_OK
		Err_Cd = ""
		Msg_Flg = False
		pm_Chk_Move = True
		
		Call DB_CLDMTA_Clear(Mst_Inf)
		
		'未入力チェック
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If CF_Trim_Item(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf) = "" Then
			Retn_Code = CHK_ERR_ELSE
			Err_Cd = gc_strMsgCLDMT51_E_006
			
		Else
			'未入力以外のチェック済
			'UPGRADE_WARNING: オブジェクト pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			pm_Chk_Dsp_Sub_Inf.Detail.Not_Input_Chk_Fin_Flg = True
			
			'基礎チェック
			If CF_Chk_Item_Base(CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf), pm_Chk_Dsp_Sub_Inf, Input_Value) <> CHK_BASE_OK Then
				Retn_Code = CHK_ERR_ELSE
				Err_Cd = gc_strMsgCLDMT51_E_001
			Else
				'入力されたコードが   1，9以外の場合はエラー
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) <> 1 And CF_Get_Item_Value(pm_Chk_Dsp_Sub_Inf) <> 9 Then
					Retn_Code = CHK_ERR_ELSE
					Err_Cd = gc_strMsgCLDMT51_E_001
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
		
		F_Chk_BD_CLDDT = Retn_Code
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_CM_Execute
	'   概要：  実行前ﾁｪｯｸ
	'   引数：  pm_All　　　　　      :全構造体
	'　　　　　 pm_intErr             :エラー発生項目
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_CM_Execute(ByRef pm_All As Cls_All) As Boolean
		
		Dim bolChk As Boolean
		
		'初期化
		bolChk = False
		
		'入力必須項目（登録年月）が未入力でないかチェック
		If F_Chk_Input_CTLCD(pm_All) Then
			bolChk = True
			'明細行に未入力項目があるかチェック
		ElseIf F_Chk_All_Input(pm_All) Then 
			bolChk = True
		End If
		
		F_Chk_CM_Execute = bolChk
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_Input_CTLCD
	'   概要：  入力必須項目（登録年月）が未入力でないかﾁｪｯｸ
	'   引数：  pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_Input_CTLCD(ByRef pm_All As Cls_All) As Boolean
		Dim bolAll As Boolean
		Dim Err_Cd As String
		Dim Dsp_Value As Object
		
		'初期化
		bolAll = False
		Err_Cd = ""
		
		With FR_SSSMAIN
			'入力必須項目（登録年月）が未入力ならエラー
			If Trim(.HD_CLDDT.Text) = "" Then
				
				Err_Cd = gc_strMsgCLDMT51_E_006
				'メッセージ出力
				Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
				bolAll = True
				
			End If
			
			'登録年月が変更されていた場合エラー
			'現在内容
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Dsp_Value = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(CInt(.HD_CLDDT.Tag)))
			'前回内容と比較
			'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_CLDDT.Tag).Detail.Bef_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If pm_All.Dsp_Sub_Inf(CInt(.HD_CLDDT.Tag)).Detail.Bef_Value <> Dsp_Value Then
				
				Err_Cd = gc_strMsgCLDMT51_E_010
				'メッセージ出力
				Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
				bolAll = True
				
			End If
			
		End With
		
		F_Chk_Input_CTLCD = bolAll
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Chk_All_Input
	'   概要：  明細行に未入力項目があるかﾁｪｯｸ
	'   引数：  pm_All　　　　　      :全構造体
	'   戻値：　チェック結果
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Chk_All_Input(ByRef pm_All As Cls_All) As Boolean
		
		Dim bolAll As Boolean
		Dim Err_Cd As String
		Dim I As Short
		Dim Trg_Index As Short
		
		'初期化
		bolAll = False
		Err_Cd = ""
		
		If Trim(FR_SSSMAIN.HD_UPDKB.Text) = "" Then
			'明細行が存在しない場合エラー
			Err_Cd = gc_strMsgCLDMT51_E_008
			'メッセージ出力
			Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
			bolAll = True
		Else
			'明細行に未入力項目がある場合エラー
			With FR_SSSMAIN
				For I = 0 To 30 Step 1
					If Trim(.BD_CLDT(I).Text) = "" Then
					ElseIf Trim(.BD_CLDHLKB(I).Text) = "" Or Trim(.BD_SLDKB(I).Text) = "" Or Trim(.BD_DTBKDKB(I).Text) = "" Or Trim(.BD_PRDKDKB(I).Text) = "" Or Trim(.BD_BNKKDKB(I).Text) = "" Then 
						
						Err_Cd = gc_strMsgCLDMT51_E_006
						'メッセージ出力
						Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
						
						Select Case True
							Case Trim(.BD_CLDHLKB(I).Text) = ""
								'「祝祭日」にフォーカス設定
								'割当ｲﾝﾃﾞｯｸｽ取得
								Trg_Index = CShort(.BD_CLDHLKB(I).Tag)
							Case Trim(.BD_SLDKB(I).Text) = ""
								'「営業日区分」にフォーカス設定
								'割当ｲﾝﾃﾞｯｸｽ取得
								Trg_Index = CShort(.BD_SLDKB(I).Tag)
							Case Trim(.BD_DTBKDKB(I).Text) = ""
								'「物流稼動区分」にフォーカス設定
								'割当ｲﾝﾃﾞｯｸｽ取得
								Trg_Index = CShort(.BD_DTBKDKB(I).Tag)
							Case Trim(.BD_PRDKDKB(I).Text) = ""
								'「生産稼動区分」にフォーカス設定
								'割当ｲﾝﾃﾞｯｸｽ取得
								Trg_Index = CShort(.BD_PRDKDKB(I).Tag)
							Case Trim(.BD_BNKKDKB(I).Text) = ""
								'「銀行稼動区分」にフォーカス設定
								'割当ｲﾝﾃﾞｯｸｽ取得
								Trg_Index = CShort(.BD_BNKKDKB(I).Tag)
						End Select
						
						'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Err_Status = ERR_NOT_INPUT
						
						'ﾁｪｯｸ後移動なし
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
						'選択状態の設定（初期選択）
						Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
						'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
						Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, pm_All)
						
						bolAll = True
						Exit For
						
					End If
				Next I
				
				If bolAll = True Then
					F_Chk_All_Input = bolAll
					Exit Function
				End If
				
				'不正なコードが入力された場合エラー
				For I = 0 To 30 Step 1
					If Trim(.BD_CLDT(I).Text) = "" Then
					ElseIf (Trim(.BD_CLDHLKB(I).Text) <> "1" And Trim(.BD_CLDHLKB(I).Text) <> "9") Or (Trim(.BD_SLDKB(I).Text) <> "1" And Trim(.BD_SLDKB(I).Text) <> "9") Or (Trim(.BD_DTBKDKB(I).Text) <> "1" And Trim(.BD_DTBKDKB(I).Text) <> "9") Or (Trim(.BD_PRDKDKB(I).Text) <> "1" And Trim(.BD_PRDKDKB(I).Text) <> "9") Or (Trim(.BD_BNKKDKB(I).Text) <> "1" And Trim(.BD_BNKKDKB(I).Text) <> "9") Then 
						
						Err_Cd = gc_strMsgCLDMT51_E_001
						'メッセージ出力
						Call AE_CmnMsgLibrary(SSS_PrgNm, Err_Cd, pm_All)
						
						Select Case True
							Case (Trim(.BD_CLDHLKB(I).Text) <> "1" And Trim(.BD_CLDHLKB(I).Text) <> "9")
								'「祝祭日」にフォーカス設定
								'割当ｲﾝﾃﾞｯｸｽ取得
								Trg_Index = CShort(.BD_CLDHLKB(I).Tag)
							Case (Trim(.BD_SLDKB(I).Text) <> "1" And Trim(.BD_SLDKB(I).Text) <> "9")
								'「営業日区分」にフォーカス設定
								'割当ｲﾝﾃﾞｯｸｽ取得
								Trg_Index = CShort(.BD_SLDKB(I).Tag)
							Case (Trim(.BD_DTBKDKB(I).Text) <> "1" And Trim(.BD_DTBKDKB(I).Text) <> "9")
								'「物流稼動区分」にフォーカス設定
								'割当ｲﾝﾃﾞｯｸｽ取得
								Trg_Index = CShort(.BD_DTBKDKB(I).Tag)
							Case (Trim(.BD_PRDKDKB(I).Text) <> "1" And Trim(.BD_PRDKDKB(I).Text) <> "9")
								'「生産稼動区分」にフォーカス設定
								'割当ｲﾝﾃﾞｯｸｽ取得
								Trg_Index = CShort(.BD_PRDKDKB(I).Tag)
							Case (Trim(.BD_BNKKDKB(I).Text) <> "1" And Trim(.BD_BNKKDKB(I).Text) <> "9")
								'「銀行稼動区分」にフォーカス設定
								'割当ｲﾝﾃﾞｯｸｽ取得
								Trg_Index = CShort(.BD_BNKKDKB(I).Tag)
						End Select
						
						'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						pm_All.Dsp_Sub_Inf(Trg_Index).Detail.Err_Status = ERR_NOT_INPUT
						
						'ﾁｪｯｸ後移動なし
						Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
						'選択状態の設定（初期選択）
						Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
						'項目色設定(エラー時はﾌｫｰｶｽなしの色設定！！)
						Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_NORMAL_STATUS, pm_All)
						
						bolAll = True
						Exit For
						
					End If
				Next I
			End With
		End If
		
		F_Chk_All_Input = bolAll
	End Function
	
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
		
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(pm_Dsp_Sub_Inf.Ctl.Tag)
		
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			Case FR_SSSMAIN.HD_CLDDT.Name
				'登録年月による画面表示
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Call F_Dsp_HD_CLDDT_Inf(pm_Dsp_Sub_Inf, pm_Mode, pm_All, pm_Dsp_Sub_Inf.Detail.Body_Index)
				
				'        Case Else
				'            '明細行による画面表示
				'            '復元内容、前回内容を退避
				'            Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
				
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
			Call F_Init_Cursor_Set(pm_All)
		End If
		
		'復元内容、前回内容を退避
		Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Dsp_HD_CLDDT_Inf
	'   概要：  登録年月による画面表示
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_Mode             :モード
	'           pm_all              :全構造体
	'           pm_Index            :配列要素番号
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Dsp_HD_CLDDT_Inf(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_Mode As Short, ByRef pm_All As Cls_All, ByRef pm_Index As Short) As Short
		
		Dim Trg_Index As Short
		Dim Dsp_Value As Object
		Dim RtnCode As Short
		
		If pm_Mode = DSP_SET Then
			'表示
			'登録年月が変更された場合
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If CF_Get_Item_Value(pm_Dsp_Sub_Inf) <> pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value Then
				
				'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
				'===== 20060908 INSERT S ========
				'フォーカス制御
				Call F_Set_Focus_Ctl(pm_Dsp_Sub_Inf, pm_All, pm_Index)
				gv_bolCLDMT51_INIT = False
				
				'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
				
				'復元内容、前回内容を退避
				Call CF_Set_Bef_Rest_Value(pm_Dsp_Sub_Inf)
			End If
		Else
			'クリア
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			
			'画面ボディ部初期化
			'        Call F_Init_Clr_Dsp_Body(-1, pm_Dsp_Sub_Inf)
			
			'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		End If
		
		'前回チェック内容に退避
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Bef_Chk_Value = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Set_Focus_Ctl
	'   概要：  登録年月による画面表示後のフォーカス制御
	'   引数：  pm_Dsp_Sub_Inf      :画面情報
	'           pm_all              :全構造体
	'           pm_Index            :配列要素番号
	'   戻値：
	'   備考：  プログラム単位の共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Set_Focus_Ctl(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All, ByRef pm_Index As Short) As Short
		
		Dim Trg_Index As Short
		Dim Fcs_Flg As Boolean
		
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(CF_Get_Item_Value(pm_Dsp_Sub_Inf)) <> "" Then
			'登録年月が空でない場合
			Fcs_Flg = True
		Else
			'登録年月が空の場合
			Fcs_Flg = False
		End If
		
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
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_OK
		pm_Chk_Move_Flg = True
		
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'    'フォーカス移動可の項目のみチェック
		'    If pm_Dsp_Sub_Inf.Detail.Focus_Ctl = True Then
		'�@基本入力内容のチェック
		Select Case pm_Dsp_Sub_Inf.Ctl.Name
			Case FR_SSSMAIN.HD_CLDDT.Name
				'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'登録年月のﾁｪｯｸ
				Rtn_Chk = F_Chk_HD_CLDDT(pm_Dsp_Sub_Inf, pm_Chk_Move_Flg, pm_All)
				
				'            Case Else
				'                '明細部のチェックを一括して行う
				'                'ﾁｪｯｸ前処理(ﾁｪｯｸ関数の前で必須処理)
				'                Call CF_Set_Chk_From_Process(pm_Dsp_Sub_Inf, pm_Process, pm_All)
				'                '明細部のﾁｪｯｸ
				'                Rtn_Chk = F_Chk_BD_CLDDT(pm_Dsp_Sub_Inf _
				''                                       , pm_Chk_Move_Flg _
				''                                       , pm_All)
				
		End Select
		'    End If
		
		If Rtn_Chk = CHK_OK Then
			pm_Chk_Move_Flg = True
		Else
			pm_Chk_Move_Flg = False
		End If
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
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
		
		'登録年月ﾁｪｯｸ呼出
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
		
		'関連ﾁｪｯｸ
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
		If Rtn_Chk = CHK_OK And pm_All.Dsp_Base.Head_Ok_Flg = False Then
			'チェックＯＫでかつ
			'ヘッダ部のチェックが初めての場合
			'１行目のボディ部を準備最終行として開放する
			'        pm_All.Dsp_Body_Inf.Row_Inf(1).Status = BODY_ROW_STATE_LST_ROW
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
		Dim intCnt As Short
		Dim intMoveFocus As Short
		Dim intErrRow As Short
		
		'2007/12/13 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		Dim bolRet As Boolean
		' === 20081001 === INSERT S - RISE)Izumi
		Dim bolTrn As Boolean
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		Dim strHD_CLDDT As String '日付
		Dim strOPEID As String '最終作業者コード
		Dim strCLTID As String 'クライアントＩＤ
		Dim strUOPEID As String '最終作業者コード（バッチ）
		Dim strUCLTID As String 'クライアントＩＤ（バッチ）
		' === 20081001 === INSERT E - RISE)Izumi
		Dim strWRTDT As String '更新日付
		Dim strWRTTM As String '更新時刻
		Dim strUWRTDT As String 'バッチ更新日付
		Dim strUWRTTM As String 'バッチ更新時刻
		'2007/12/13 add-end T.KAWAMUKAI
		
		F_Ctl_Upd_Process = 9
		
		' === 20060808 === INSERT S - エンターキー連打による不具合修正２
		If gv_bolUpdFlg = True Then
			Exit Function
		End If
		
		gv_bolUpdFlg = True
		' === 20060808 === INSERT E
		
		'砂時計にする
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		pv_intMeisaiCnt = 0
		
		'ボディ部の最終項目まで各項目のﾁｪｯｸを行う
		'    For intCnt = 0 To UBound(pm_All.Dsp_Body_Inf.Row_Inf)
		For intCnt = 0 To 30
			
			'関連ﾁｪｯｸ
			intRet = F_Ctl_Body_RelChk(intCnt, pm_All, intMoveFocus, intErrRow)
			'チェックＮＧ
			If intRet <> CHK_OK Then
				F_Ctl_Upd_Process = intRet
			End If
			
		Next intCnt
		
		
		'マウスポインタを戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'Windowsに処理を返す
		'    DoEvents
		
		If gb_pageChange = True Then
			intRet = MsgBoxResult.Yes
		Else
			'確認メッセージ表示
			intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_A_004, pm_All)
		End If
		
		'砂時計にする
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
		
		Select Case intRet
			Case MsgBoxResult.Yes
				' 2007/01/11  ADD START  KUMEDA   *** 権限チェック場所の変更
				If gb_CldUpdFlg = False Then
					gv_bolUpdFlg = False
					Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_E_012, pm_All)
					GoTo End_F_Ctl_Upd_Process
				End If
                ' 2007/01/11  ADD END
                '            'ボタン非表示
                '            FR_SSSMAIN.CM_Execute.Visible = False

                '2008/07/08 START ADD FNAP)YAMANE 連絡票�ａF排他-54
                '20190813 CHG START
                'Call CF_Ora_BeginTrans(gv_Oss_USR1)
                Call DB_BeginTrans(CON)
                '20190813 CHG END
                '2008/07/08 E.N.D ADD FNAP)YAMANE 連絡票�ａF排他-54
                ' === 20081001 === INSERT S - RISE)Izumi
                bolTrn = True
				' === 20081001 === INSERT E - RISE)Izumi
				
				' === 20081001 === DELETE S - RISE)Izumi
				''2007/12/13 add-str T.KAWAMUKAI 各プログラムのモジュールで処理するように変更
				'            '更新時間取得
				'            Call PF_Get_UWRTDTTM(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM)
				'
				'            '更新時間チェック
				'            bolRet = MF_Chk_UWRTDTTM(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM)
				'
				'            If bolRet = False Then
				''2007/12/27 upd-str M.SUEZAWA
				'''                intRet = MF_DspMsg(gc_strMsgCLDMT51_E_UPD)
				'                intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_E_UPD, pm_All)
				''2007/12/27 upd-end M.SUEZAWA
				'
				''2008/07/08 START ADD FNAP)YAMANE 連絡票�ａF排他-54
				''   [FOR UPDATE]命令を解除する。（ABORTが無いため代用する）
				'                Call CF_Ora_RollbackTrans(gv_Oss_USR1)
				'                HAITA_FLG = 1
				''2008/07/08 E.N.D ADD FNAP)YAMANE 連絡票�ａF排他-54
				'                GoTo End_F_Ctl_Upd_Process
				'            End If
				''2007/12/13 add-end T.KAWAMUKAI
				' === 20081001 === DELETE E - RISE)Izumi
				
				' === 20081001 === INSERT S - RISE)Izumi 排他処理
				'更新データの日付を取得
				strHD_CLDDT = FR_SSSMAIN.HD_CLDDT.Text
				strHD_CLDDT = CF_Get_Input_Ok_Item(CStr(strHD_CLDDT), pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_CLDDT.Tag)))
				
				For intCnt = 0 To pv_intMeisaiCnt - 1
					With pm_All.Dsp_Body_Inf.Row_Inf(intCnt)
						'タイムスタンプ取得SQL作成
						strSQL = ""
						strSQL = strSQL & " SELECT "
						strSQL = strSQL & "     OPEID " '最終作業者コード
						strSQL = strSQL & "    ,CLTID " 'クライアントＩＤ
						strSQL = strSQL & "    ,WRTTM " '更新時間
						strSQL = strSQL & "    ,WRTDT " '更新日付
						strSQL = strSQL & "    ,UOPEID " '最終作業者コード（バッチ）
						strSQL = strSQL & "    ,UCLTID " 'クライアントＩＤ（バッチ）
						strSQL = strSQL & "    ,UWRTTM " 'バッチ更新時間
						strSQL = strSQL & "    ,UWRTDT " 'バッチ更新日付
						strSQL = strSQL & " FROM "
						strSQL = strSQL & "     CLDMTA "
						strSQL = strSQL & " WHERE "
						strSQL = strSQL & "CLDDT       = '" & CF_Ora_String(strHD_CLDDT & CLDMT51_CLDMTA_Update_Inf(intCnt + 1).CLDDT, 10) & "' " '日付
						strSQL = strSQL & " AND "
						strSQL = strSQL & "     DATKB = '1' "
						strSQL = strSQL & " FOR UPDATE "

                        'DBアクセス
                        '20190814 CHG START
                        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
                        Dim dt As DataTable = DB_GetTable(strSQL)
                        '20190814 CHG END
                        If CF_Ora_EOF(Usr_Ody) = True Then
                            'ロールバック
                            '20190813 CHG START
                            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
                            Call DB_Rollback()
                            '20190813 CHG END
                            HAITA_FLG = CStr(1)
							bolTrn = False
							intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_E_UPD, pm_All)
							GoTo End_F_Ctl_Upd_Process
						End If
						
						'更新時間チェック
						'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If Trim(.Bus_Inf.OPEID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "OPEID", "")) Or Trim(.Bus_Inf.CLTID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "CLTID", "")) Or Trim(.Bus_Inf.WRTTM) <> Trim(CF_Ora_GetDyn(Usr_Ody, "WRTTM", "")) Or Trim(.Bus_Inf.WRTDT) <> Trim(CF_Ora_GetDyn(Usr_Ody, "WRTDT", "")) Or Trim(.Bus_Inf.UOPEID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UOPEID", "")) Or Trim(.Bus_Inf.UCLTID) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UCLTID", "")) Or Trim(.Bus_Inf.UWRTTM) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "")) Or Trim(.Bus_Inf.UWRTDT) <> Trim(CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "")) Then
                            'ロールバック
                            '20190813 CHG START
                            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
                            Call DB_Rollback()
                            '20190813 CHG END
                            HAITA_FLG = CStr(1)
							bolTrn = False
							intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_E_UPD, pm_All)
							GoTo End_F_Ctl_Upd_Process
						End If
					End With
				Next intCnt
				' === INSERT === UPDATE E - RISE)Izumi
				
				'登録処理
				intRet = F_Update_Main(pm_All)
				If intRet <> 0 Then
					GoTo Err_F_Ctl_Upd_Process
				End If

                ' === 20081001 === INSERT S - RISE)Izumi
                'コミット
                '20190816 CHG START
                'Call CF_Ora_CommitTrans(gv_Oss_USR1)
                Call DB_Commit()
                '20190816 CHG END
                bolTrn = False
				' === 20081001 === INSERT E - RISE)Izumi
				
			Case Else ' 戻る
				GoTo End_F_Ctl_Upd_Process
		End Select
		
		'正常メッセージ表示
		intRet = AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_E_005, pm_All)
		
		F_Ctl_Upd_Process = 0
		
End_F_Ctl_Upd_Process: 
		
		' === 20081001 === INSERT S - RISE)Izumi
		If bolTrn = True Then
            'ロールバック
            '20190813 CHG START
            'Call CF_Ora_RollbackTrans(gv_Oss_USR1)
            Call DB_Rollback()
            '20190813 CHG END
            bolTrn = False
		End If
		' === 20081001 === INSERT E - RISE)Izumi
		
		'マウスポインタを戻す
		'UPGRADE_WARNING: Screen プロパティ Screen.MousePointer には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
		System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
		
		'    'ボタン表示
		'    FR_SSSMAIN.CM_Execute.Visible = True
		
		' === 20060808 === INSERT S - エンターキー連打による不具合修正２
		gv_bolUpdFlg = False
		
		'キーフラグを元に戻す
		gv_bolKeyFlg = False
		' === 20060808 === INSERT E
		
		Exit Function
		
Err_F_Ctl_Upd_Process: 
		
		GoTo End_F_Ctl_Upd_Process
		
	End Function
	
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
		ReDim CLDMT51_CLDMTA_Update_Inf(0)
		
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
						'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Item_Nm の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Trg_Index = CF_Get_Idex_Same_Bd_Ctl_Hide_Row(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Item_Nm, pm_All)
						
						'ワークの｢画面項目情報｣に隠行ｺﾝﾄﾛｰﾙを割当
						Dsp_Sub_Inf_Wk.Ctl = pm_All.Dsp_Sub_Inf(Trg_Index).Ctl
						
						'ワークの｢画面項目情報｣に｢画面ボディ情報｣を編集
						'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail().Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Call CF_Set_Item_Direct(pm_All.Dsp_Body_Inf.Row_Inf(Index_Wk_Row).Item_Detail(Index_Wk_Col).Dsp_Value, Dsp_Sub_Inf_Wk, pm_All)
						'画面項目詳細情報を設定
						'UPGRADE_WARNING: オブジェクト Dsp_Sub_Inf_Wk.Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Body_Inf.Row_Inf().Item_Detail(Index_Wk_Col) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
								'UPGRADE_WARNING: オブジェクト Dsp_Sub_Inf_Wk.Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
						'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
		Dim intCLDDT As Short
		Dim intCLDWKKB As Short
		Dim intCLDHLKB As Short
		Dim intSLDKB As Short
		Dim intBNKKDKB As Short
		Dim intPRDKDKB As Short
		Dim intDTBKDKB As Short
		Dim bolCheck As Boolean
		Dim bolNotInput As Boolean
		Dim strKbn As String
		
		'各ﾁｪｯｸ関数と同じ戻値
		Rtn_Chk = CHK_ERR_ELSE
		Err_Cd = ""
		pm_ErrRow = pm_intRow
		pm_ErrIdx = CShort(FR_SSSMAIN.BD_CLDHLKB(pv_intMeisaiCnt).Tag)
		'    pm_ErrIdx = CInt(FR_SSSMAIN.BD_CLDHLKB(0).Tag)
		bolNotInput = False
		
		'１行チェック
		intCLDDT = CShort(FR_SSSMAIN.BD_CLDT(pv_intMeisaiCnt).Tag)
		intCLDWKKB = CShort(FR_SSSMAIN.BD_WKKB(pv_intMeisaiCnt).Tag)
		intCLDHLKB = CShort(FR_SSSMAIN.BD_CLDHLKB(pv_intMeisaiCnt).Tag)
		intSLDKB = CShort(FR_SSSMAIN.BD_SLDKB(pv_intMeisaiCnt).Tag)
		intBNKKDKB = CShort(FR_SSSMAIN.BD_BNKKDKB(pv_intMeisaiCnt).Tag)
		intPRDKDKB = CShort(FR_SSSMAIN.BD_PRDKDKB(pv_intMeisaiCnt).Tag)
		intDTBKDKB = CShort(FR_SSSMAIN.BD_DTBKDKB(pv_intMeisaiCnt).Tag)
		'    intCLDDT = CInt(FR_SSSMAIN.BD_CLDT(0).Tag)
		'    intCLDWKKB = CInt(FR_SSSMAIN.BD_WKKB(0).Tag)
		'    intCLDHLKB = CInt(FR_SSSMAIN.BD_CLDHLKB(0).Tag)
		'    intSLDKB = CInt(FR_SSSMAIN.BD_SLDKB(0).Tag)
		'    intBNKKDKB = CInt(FR_SSSMAIN.BD_BNKKDKB(0).Tag)
		'    intPRDKDKB = CInt(FR_SSSMAIN.BD_PRDKDKB(0).Tag)
		'    intDTBKDKB = CInt(FR_SSSMAIN.BD_DTBKDKB(pm_intRow).Tag)
		
		bolCheck = False
		'１行に必要な情報が入力されている場合、OK
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDDT))) <> "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDWKKB))) <> "" Then
			bolCheck = True
			pv_bolMEISAI_INPUT = True
			pv_intMeisaiCnt = pv_intMeisaiCnt + 1
			
			'カレンダマスタ情報（更新用）にデータを代入
			ReDim Preserve CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt)
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt).CLDDT = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDDT)) '日付
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt).CLDWKKB = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDWKKB)) '曜日
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt).CLDHLKB = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDHLKB)) '祝日
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt).SLDKB = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSLDKB)) '営業日区分
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt).BNKKDKB = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intBNKKDKB)) '銀行稼動区分
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt).PRDKDKB = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intPRDKDKB)) '生産稼動区分
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CLDMT51_CLDMTA_Update_Inf(pv_intMeisaiCnt).DTBKDKB = CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intDTBKDKB)) '物流稼動区分
			
			'    Else
			'        Select Case True
			'            Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) = "" _
			''             And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCTLCD))) <> ""
			'                pm_ErrIdx = CInt(FR_SSSMAIN.BD_CTLCD(1).Tag)
			'            Case Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intUPDKB))) <> "" _
			''             And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCTLCD))) = ""
			'                pm_ErrIdx = CInt(FR_SSSMAIN.BD_CTLCD(1).Tag)
			'        End Select
		End If
		
		'１行全部未入力の場合OK
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If bolCheck = False And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDDT))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDWKKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intCLDHLKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intSLDKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intBNKKDKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intPRDKDKB))) = "" And Trim(CF_Get_Item_Value(pm_All.Dsp_Sub_Inf(intDTBKDKB))) = "" Then
			
			bolCheck = True
			bolNotInput = True
		End If
		
		If bolCheck = False Then
			Err_Cd = gc_strMsgCLDMT51_E_006
			GoTo F_Ctl_Body_RelChk_END
		End If
		
		'未入力の場合、後のチェックは無し
		If bolNotInput = True Then
			pv_bolInput_Bef_Row = False
			Rtn_Chk = CHK_OK
			GoTo F_Ctl_Body_RelChk_END
			'    Else
			'        '未入力以外で前の行が未入力の場合エラー
			'        If pv_bolInput_Bef_Row = False Then
			'            Err_Cd = gc_strMsgCLDMT51_E_006
			'            pm_ErrRow = pm_intRow - 1
			'            GoTo F_Ctl_Body_RelChk_END
			'        End If
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
				
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Body_Index > 0 Then
					
					'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf().Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
		Dim strCLDDT As String
		Dim Trg_Index As Short
		
		On Error GoTo F_Update_Main_Err
		
		intRet = CHK_ERR_ELSE
		bolTrn = False
		
		'更新時刻取得
		Call CF_Get_SysDt()
		
		' === 20081001 === DELETE S - RISE)Izumi
		'    'トランザクションの開始
		'    Call CF_Ora_BeginTrans(gv_Oss_USR1)
		'    bolTrn = True
		' === 20081001 === DELETE E - RISE)Izumi
		
		For intCnt = 1 To pv_intMeisaiCnt Step 1
			'カレンダマスタ更新
			intRet = F_CLDMTA_Update(intCnt, pm_All)
			
			If intRet <> 0 Then
				GoTo F_Update_Main_Err
			End If
			
		Next intCnt
		
		'通算稼働日数算出（カレンダマスタ更新）
		strCLDDT = FR_SSSMAIN.HD_CLDDT.Text
		strCLDDT = CF_Get_Input_Ok_Item(CStr(strCLDDT), pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_CLDDT.Tag))) & "01"
		'ストアドキック
		intRet = AE_Execute_PLSQL_CLC_SLSMDD(strCLDDT)
		
		If intRet <> 0 Then
			GoTo F_Update_Main_Err
		End If
		
		' === 20081001 === DELETE S - RISE)Izumi
		'    'コミット
		'    Call CF_Ora_CommitTrans(gv_Oss_USR1)
		'    bolTrn = False
		' === 20081001 === DELETE E - RISE)Izumi
		
		intRet = CHK_OK
		
F_Update_Main_End: 
		
		' === 20081001 === DELETE S - RISE)Izumi
		'    If bolTrn = True Then
		'        'ロールバック
		'        Call CF_Ora_RollbackTrans(gv_Oss_USR1)
		'        bolTrn = False
		'    End If
		' === 20081001 === DELETE E - RISE)Izumi
		
		F_Update_Main = intRet
		Exit Function
		
F_Update_Main_Err: 
		
		intRet = CHK_ERR_ELSE
		GoTo F_Update_Main_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_CLDMTA_Update
	'   概要：  カレンダマスタ更新処理
	'   引数：  pm_intCnt   : 配列番号
	'           pm_All      : 全構造体
	'   戻値：　0：正常終了　9:異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_CLDMTA_Update(ByRef pm_intCnt As Short, ByRef pm_All As Cls_All) As Short
		
		Dim strSQL As String
		Dim bolRet As Boolean
		Dim strHD_CLDDT As String
		
		On Error GoTo F_CLDMTA_Update_err
		
		F_CLDMTA_Update = 9
		
		strHD_CLDDT = FR_SSSMAIN.HD_CLDDT.Text
		strHD_CLDDT = CF_Get_Input_Ok_Item(CStr(strHD_CLDDT), pm_All.Dsp_Sub_Inf(CInt(FR_SSSMAIN.HD_CLDDT.Tag)))
		
		'カレンダマスタ更新
		strSQL = ""
		strSQL = strSQL & " UPDATE CLDMTA"
		strSQL = strSQL & "    SET CLDHLKB     = '" & CF_Ora_String(CLDMT51_CLDMTA_Update_Inf(pm_intCnt).CLDHLKB, 1) & "' " '祝日
		strSQL = strSQL & "      , SLDKB       = '" & CF_Ora_String(CLDMT51_CLDMTA_Update_Inf(pm_intCnt).SLDKB, 1) & "' " '営業日区分
		strSQL = strSQL & "      , BNKKDKB     = '" & CF_Ora_String(CLDMT51_CLDMTA_Update_Inf(pm_intCnt).BNKKDKB, 1) & "' " '銀行稼動区分
		strSQL = strSQL & "      , PRDKDKB     = '" & CF_Ora_String(CLDMT51_CLDMTA_Update_Inf(pm_intCnt).PRDKDKB, 1) & "' " '生産稼動区分
		strSQL = strSQL & "      , DTBKDKB     = '" & CF_Ora_String(CLDMT51_CLDMTA_Update_Inf(pm_intCnt).DTBKDKB, 1) & "' " '物流稼動区分
		strSQL = strSQL & "      , OPEID       = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード
		strSQL = strSQL & "      , CLTID       = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ
		strSQL = strSQL & "      , WRTTM       = '" & GV_SysTime & "' " 'タイムスタンプ（時間）
		strSQL = strSQL & "      , WRTDT       = '" & GV_SysDate & "' " 'タイムスタンプ（日付）
		' 2006/11/19  ADD START  KUMEDA
		strSQL = strSQL & "      , UOPEID      = '" & CF_Ora_String(SSS_OPEID.Value, 8) & "' " '最終作業者コード（バッチ）
		strSQL = strSQL & "      , UCLTID      = '" & CF_Ora_String(SSS_CLTID.Value, 5) & "' " 'クライアントＩＤ（バッチ）
		strSQL = strSQL & "      , UWRTTM      = '" & GV_SysTime & "' " 'タイムスタンプ（バッチ時間）
		strSQL = strSQL & "      , UWRTDT      = '" & GV_SysDate & "' " 'タイムスタンプ（バッチ日付）
		strSQL = strSQL & "      , PGID        = '" & SSS_PrgId & "' " 'プログラムＩＤ
		' 2006/11/19  ADD END
		strSQL = strSQL & "  WHERE CLDDT       = '" & CF_Ora_String(strHD_CLDDT & CLDMT51_CLDMTA_Update_Inf(pm_intCnt).CLDDT, 10) & "' " '日付
		strSQL = strSQL & "    AND DATKB      = '1' " '削除区分：1（使用中）
		
		'SQL実行
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo F_CLDMTA_Update_err
		End If
		
		F_CLDMTA_Update = 0
		
F_CLDMTA_Update_End: 
		Exit Function
		
F_CLDMTA_Update_err: 
		Call AE_CmnMsgLibrary(SSS_PrgNm, gc_strMsgCLDMT51_E_007, pm_All, "F_CLDMTA_Update")
		GoTo F_CLDMTA_Update_End
		
	End Function
	
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function AE_Execute_PLSQL_GetTanka
	'   概要：  PL/SQL実行処理(単価取得処理)
	'   引数：　Pin_strHINCD  : 算出開始日
	'   戻値：　0 : 正常 9: 異常
	'   備考：  営業通算日数算出用PL/SQL(CLC_SLSMDD)を実行する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function AE_Execute_PLSQL_CLC_SLSMDD(ByVal pin_strCLDDT_S As String) As Short
		
		Dim strSQL As String 'SQL文
		Dim strPara1 As String 'ﾊﾟﾗﾒｰﾀ1(算出開始日)
		Dim strPara2 As String 'ﾊﾟﾗﾒｰﾀ2(最終作業者コード)
		Dim strPara3 As String 'ﾊﾟﾗﾒｰﾀ3(クライアントＩＤ)
		'UPGRADE_ISSUE: OraParameter オブジェクト はアップグレードされませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"' をクリックしてください。
		Dim param(4) As OraParameter 'PL/SQLのバインド変数
		Dim bolRet As Boolean
		
		AE_Execute_PLSQL_CLC_SLSMDD = 9
		
		'受渡し変数初期設定
		strPara1 = pin_strCLDDT_S
		strPara2 = CF_Ora_String(SSS_OPEID.Value, 8)
		strPara3 = CF_Ora_String(SSS_CLTID.Value, 5)
		
		'パラメータの初期設定を行う（バインド変数）
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P1", strPara1, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P2", strPara2, ORAPARM_INPUT)
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Add("P3", strPara3, ORAPARM_INPUT)
		
		'データ型をオブジェクトにセット
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1) = gv_Odb_USR1.Parameters("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2) = gv_Odb_USR1.Parameters("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3) = gv_Odb_USR1.Parameters("P3")
		
		'各オブジェクトのデータ型を設定
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(1).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(2).serverType = ORATYPE_CHAR
		'UPGRADE_WARNING: オブジェクト param().serverType の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		param(3).serverType = ORATYPE_CHAR
		
		'PL/SQL呼び出しSQL
		strSQL = ""
		strSQL = strSQL & " DECLARE FC_STA NUMBER; "
		strSQL = strSQL & " BEGIN FC_STA := "
		strSQL = strSQL & " EDT_CLDMTA.CLC_SLSMDD(:P1,:P2,:P3); End; "
		'    strSQL = "BEGIN EDT_CLDMTA.CLC_SLSMDD(:P1,:P2,:P3); End;"
		
		'DBアクセス
		bolRet = CF_Ora_Execute(gv_Odb_USR1, strSQL)
		If bolRet = False Then
			GoTo AE_Execute_PLSQL_CLC_SLSMDD_END
		End If
		AE_Execute_PLSQL_CLC_SLSMDD = CHK_OK
		
AE_Execute_PLSQL_CLC_SLSMDD_END: 
		'** パラメタ解消
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P1")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P2")
		'UPGRADE_WARNING: オブジェクト gv_Odb_USR1.Parameters の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gv_Odb_USR1.Parameters.Remove("P3")
		
		
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
			'        Case CInt(FR_SSSMAIN.TX_Dummy.Tag)
			'            '登録
			'            Trg_Index = CInt(FR_SSSMAIN.MN_Execute.Tag)
			'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
			'            '画面印刷
			'            Trg_Index = CInt(FR_SSSMAIN.MN_HARDCOPY.Tag)
			'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
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
			
			Case Else
				'登録
				Trg_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
				pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
				'            '画面印刷
				'            Trg_Index = CInt(FR_SSSMAIN.MN_HARDCOPY.Tag)
				'            pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
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
		Wk_Index = CShort(FR_SSSMAIN.MN_Execute.Tag)
		pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
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
	'
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'    '   名称：  Function F_Ctl_PageButton_Enabled
	'    '   概要：  前ページ・次ページ使用可否制御
	'    '   引数：　pm_All           : 全構造体
	'    '   戻値：　なし
	'    '   備考：
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function F_Ctl_PageButton_Enabled(pm_All As Cls_All) As Integer
	'
	'    Dim Trg_Index        As Integer
	'    Dim Wk_Index         As Integer
	'
	'    F_Ctl_PageButton_Enabled = 9
	'
	'    '前頁
	'    Trg_Index = CInt(FR_SSSMAIN.MN_Prev.Tag)
	''    If NowPageNum > MinPageNum Then
	'        pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
	''    Else
	''        pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
	''    End If
	'    '次頁
	'    Trg_Index = CInt(FR_SSSMAIN.MN_NextCm.Tag)
	''    If NowPageNum < MaxPageNum Then
	'        pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = True
	''    Else
	''        pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Enabled = False
	''    End If
	'
	'    '前頁ボタン
	'    Trg_Index = CInt(FR_SSSMAIN.CM_PREV.Tag)
	'    Wk_Index = CInt(FR_SSSMAIN.MN_Prev.Tag)
	'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
	'    '次頁ボタン
	'    Trg_Index = CInt(FR_SSSMAIN.CM_NEXTCm.Tag)
	'    Wk_Index = CInt(FR_SSSMAIN.MN_NextCm.Tag)
	'    pm_All.Dsp_Sub_Inf(Trg_Index).Ctl.Visible = pm_All.Dsp_Sub_Inf(Wk_Index).Ctl.Enabled
	'
	'    F_Ctl_PageButton_Enabled = 0
	'
	'End Function
	
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
			'LLLLL 20060912 INSERT S LLLLLLLLLLLLLLL
		ElseIf pm_Index = -2 Then 
			Wk_Index_S = 1
			Wk_Index_E = pm_All.Dsp_Base.Item_Cnt
			pm_All.Dsp_Base.Head_Ok_Flg = False
			Wk_Mode = ITM_ALL_CLR
			
			'LLLLL 20060912 INSERT E LLLLLLLLLLLLLLL
		Else
			Wk_Index_S = pm_Index
			Wk_Index_E = pm_Index
			Wk_Mode = ITM_ALL_ONLY
		End If
		
		For Index_Wk = Wk_Index_S To Wk_Index_E
			
			With pm_All.Dsp_Sub_Inf(Index_Wk).Detail
				'UPGRADE_WARNING: オブジェクト pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Item_Nm の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If pm_Index = -2 And (.Item_Nm = "SYSDT" Or .Item_Nm = "HD_IN_TANCD" Or .Item_Nm = "HD_IN_TANNM") Then
				Else
					'共通初期化
					Call CF_Init_Clr_Dsp(pm_All.Dsp_Sub_Inf(Index_Wk), Wk_Mode, pm_All)
					
					'全体初期化の場合
					If Wk_Mode = ITM_ALL_CLR Then
						'ボディ部以降の項目を全ﾌｫｰｶｽなしとする
						If Index_Wk > pm_All.Dsp_Base.Head_Lst_Idx Then
							Call CF_Set_Item_Focus_Ctl(False, pm_All.Dsp_Sub_Inf(Index_Wk))
						End If
					End If
				End If
			End With
			
			'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
			'        '個別初期化
			'        Select Case Index_Wk
			'            '登録年月
			'            Case CInt(FR_SSSMAIN.HD_CLDDT.Tag)
			'                Call CF_Set_Item_Direct(CF_Cnv_Dsp_Item(gb_dateYM, pm_All.Dsp_Sub_Inf(Index_Wk), False), pm_All.Dsp_Sub_Inf(Index_Wk), pm_All, SET_FLG_DEF)
			''                If pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value <> "0000/00" Then
			'                If Trim(pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Bef_Value) <> "" Then
			'                    pm_All.Dsp_Sub_Inf(Index_Wk).Detail.Err_Status = ERR_NOT
			'                End If
			'
			'        End Select
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
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'各画面個別設定(必ずDSP_SUB_INF.Detail.Focus_Ctl=Trueの項目！！)
		'登録年月にフォーカス設定
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(FR_SSSMAIN.HD_CLDDT.Tag)
		
		'登録年月をフォーカスありにする
		Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Trg_Index))
		
		'ﾌｫｰｶｽ移動
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'選択状態の設定（初期選択）
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'項目色設定
		Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Init_Cursor_Set
	'   概要：  明細１行目へのフォーカス位置設定
	'   引数：　なし
	'   戻値：　なし
	'   備考：  全画面ローカル共通処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Meisai_Cursor_Set(ByRef pm_All As Cls_All) As Short
		
		Dim Trg_Index As Short
		
		'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'各画面個別設定(必ずDSP_SUB_INF.Detail.Focus_Ctl=Trueの項目！！)
		'１行目の「祝祭日」にフォーカス設定
		'割当ｲﾝﾃﾞｯｸｽ取得
		Trg_Index = CShort(FR_SSSMAIN.BD_CLDHLKB(0).Tag)
		
		'    '祝祭日をフォーカスありにする
		'    Call CF_Set_Item_Focus_Ctl(True, pm_All.Dsp_Sub_Inf(Trg_Index))
		
		'ﾌｫｰｶｽ移動
		Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index), pm_All)
		'選択状態の設定（初期選択）
		Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
		'項目色設定
		Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
		
		'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		
	End Function
	
	'
	'' === 20060825 === INSERT S
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'    '   名称：  Function F_Set_NextRow_Status
	'    '   概要：  最終行の次行の状態を最終準備行に設定
	'    '   引数：　pm_Dsp_Sub_Inf      :画面項目情報
	'    '           pm_all              :全構造体
	'    '   戻値：　なし
	'    '   備考：
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function F_Set_NextRow_Status(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_All As Cls_All) As Boolean
	'
	'    Dim Bd_Index            As Integer
	'
	'    'pm_All.Dsp_Body_Infの行ＮＯを取得
	'    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
	'
	'    If Bd_Index < pm_All.Dsp_Base.Dsp_Body_Cnt Then
	'        '次行の画面ボディ行状態を最終準備行に設定
	'        If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index + 1).Status = BODY_ROW_STATE_DEFAULT Then
	'            pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index + 1).Status = BODY_ROW_STATE_LST_ROW
	'        End If
	'    End If
	'
	'End Function
	'' === 20060825 === INSERT E
	
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
                '20190813 CHG START
                '            Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
                '            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                '            Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
                Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
                Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
                Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
                '20190813 CHG END
                Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
				
				'現在の値を取得
				'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
				
				Wk_EditMoji = ""
				
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Str_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
		Dim retCode As Short
		
		intRet = CHK_OK
		
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
            '20190813 CHG START
            '         Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
            '         'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '         Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
            Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
            Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
            Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
            '20190813 CHG END
            Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
			
			'現在の値を取得
			'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Wk_CurMoji = CF_Get_Item_Value(pm_Dsp_Sub_Inf)
			
			All_Sel_Flg = False
			'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If Act_SelStart = 0 And Act_SelStrB = pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
				'全選択の場合（選択文字が最大バイト数と一致）
				All_Sel_Flg = True
			End If
			
			'入力コード判定
			If CF_Jge_Input_Str(pm_Dsp_Sub_Inf, wk_Moji) = 1 Then
				'入力可能文字の場合
				
				'入力可能な文字の場合、入力後処理、明細部再作成を行う
				Input_Flg = True
				Re_Body_Crt = True
				
				'CF_Jge_Input_Str関数の文字変更を考慮
				pm_KeyAscii = Asc(wk_Moji)
				
				'日付/年月/時刻でかつ選択状態が１つ以外の場合、入力不可
				'表示形式が決まっているため一つずつ入力させる
				'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
					
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
						'詰文字が左詰の場合
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & wk_Moji
						
					Else
						'詰文字が左詰以外の場合
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						Wk_EditMoji = wk_Moji & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
						
					End If
					
					'編集後の文字を表示形式に変換
					'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					Wk_DspMoji = CF_Cnv_Dsp_Item(Wk_EditMoji, pm_Dsp_Sub_Inf, True)
					
					'編集後のSelStartを決定
					'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
                    '20190813 CHG START
                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                    ''編集後のSelLengthを決定
                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                    '20190813 CHG END

                    ' === 20060801 === INSERT S - １桁項目で入力後にフォーカス移動しないことへの対応
                    '数値項目特別処理
                    'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
						
						'小数部があり小数桁数と設定値が同じ場合
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
							'現在ﾌｫｰｶｽ位置から右へ移動
							Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
						Else
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
								'編集後の文字がMAXの場合
								'現在ﾌｫｰｶｽ位置から右へ移動
								Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
							End If
						End If
						
					Else
						'数値項目以外
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                            '編集後の文字がMAXの場合
                            'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            '20190813 CHG START
                            'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                            ''編集後のSelLengthを決定
                            ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            'pm_Dsp_Sub_Inf.Ctl.SelLength = 0
                            DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 0)
                            '20190813 CHG END

                            '現在ﾌｫｰｶｽ位置から右へ移動
                            '                        Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
                            intRet = F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
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
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
									'｢−｣入力時
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
						
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_CurMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
							'空白除去後の現在の文字がMAXの場合、オーバーフロー
							
							'数値項目特別処理
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
                                    '20190813 CHG START
                                    'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                    ''編集後のSelLengthを決定
                                    ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                    'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                    DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                    '20190813 CHG END
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
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'整数部で整数桁数より多く入力されている場合
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'小数部があり小数桁数と設定値が同じ場合
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
                        '20190813 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''編集後のSelLengthを決定
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190813 CHG END

                        '編集後の移動先を判定
                        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If pm_Dsp_Sub_Inf.Detail.Fil_Point = FIL_POINT_LEFT Then
							'詰文字が左詰の場合
							
							If Wk_SelStart >= Len(Wk_DspMoji) Then
								'編集後の開始位置が一番右の場合
								'数値項目特別処理
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
									'小数部があり小数桁数と設定値が同じ場合
									'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									Else
										'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
										If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
											'編集後の文字がMAXの場合
											'現在ﾌｫｰｶｽ位置から右へ移動
											Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
										End If
									End If
								Else
									'数値項目以外
									'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'編集後の文字がMAXの場合
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
							End If
						Else
							'詰文字が左詰以外の場合
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
                                '編集後の文字がMAXの場合

                                '編集後のSelStartを決定
                                'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                '20190813 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Len(Wk_DspMoji)
                                ''編集後のSelLengthを決定
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = 1
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Len(Wk_DspMoji), 1)
                                '20190813 CHG END

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
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
									'｢−｣入力時
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
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
							'整数部無しの場合
							'整数部ありで整数桁数より多く入力されている場合
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If Len(CF_Get_Num_Int_Part(Wk_DspMoji)) > pm_Dsp_Sub_Inf.Detail.Num_Int_Fig Then
								'入力不可
								pm_KeyAscii = 0
								Exit Function
							End If
							
							'小数部があり小数桁数と設定値が同じ場合
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
                        '20190813 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''編集後のSelLengthを決定
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190813 CHG END

                        '編集後の移動先を判定
                        If Wk_SelStart >= Len(Wk_DspMoji) - 1 Then
							'編集後の開始位置が最後の文字以降の場合
							'数値項目特別処理
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								
								'小数部があり小数桁数と設定値が同じ場合
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								If pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig > 0 And Len(CF_Get_Num_Fra_Part(Wk_DspMoji)) >= pm_Dsp_Sub_Inf.Detail.Num_Fra_Fig Then
									'現在ﾌｫｰｶｽ位置から右へ移動
									Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								Else
									'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
										'編集後の文字がMAXの場合
										'現在ﾌｫｰｶｽ位置から右へ移動
										Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									End If
								End If
								
							Else
								'数値項目以外
								'                            If CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf)) >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
								'                                CF_Ctl_Item_KeyPress = F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
								retCode = CF_Ctr_AnsiLenB(CF_Trim_Item(Wk_DspMoji, pm_Dsp_Sub_Inf))
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								If retCode >= pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB Then
									'編集後の文字がMAXの場合
									'現在ﾌｫｰｶｽ位置から右へ移動
									'                                Call F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
									intRet = F_Set_Right_Next_Focus(pm_Dsp_Sub_Inf, pm_Move_Flg, pm_All, pm_Run_Flg)
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
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
                                '20190813 CHG START
                                'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                                ''編集後のSelLengthを決定
                                ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                                'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                                DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                                '20190813 CHG END

                                '削除不可
                                Exit Function
							Case Else
								
						End Select
						
						'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							If pm_Dsp_Sub_Inf.Detail.In_Typ = IN_TYP_NUM Then
								If Wk_DelMoji = "." Then
									'削除対象の文字が小数点の場合
									'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Num_Int_Fig の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
									'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB) & Left(Wk_CurMoji, Act_SelStart - 1) & Mid(Wk_CurMoji, Act_SelStart + 1)
								Else
									'削除対象がない為、空白を編集
									'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
							'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
									'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									Wk_EditMoji = Right(Wk_CurMoji, Len(Wk_CurMoji) - 1) & Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								Else
									'削除対象がない為、空白を編集
									'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
									Wk_EditMoji = Space(pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB)
								End If
								
								'削除後のSelStartを決定
								Wk_SelStart = Act_SelStart
							Else
								'文字編集
								'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Dsp_MaxLengthB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
                        '20190813 CHG START
                        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
                        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
                        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
                        '20190813 CHG END

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
		
		CF_Ctl_Item_KeyPress = intRet
		
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
		
		If pm_Button = VB6.MouseButtonConstants.RightButton Then
			'右クリック
			
			If CShort(pm_Trg_Dsp_Sub_Inf.Ctl.Tag) = CShort(pm_Act_Dsp_Sub_Inf.Ctl.Tag) Then
				'右クリックしたコントロールがアクティブなコントロールと一致
				'カーソル制御用テキストにフォーカスを一時的に退避
				Wk_Index = CShort(FR_SSSMAIN.TX_CursorRest.Tag)
				Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Wk_Index), pm_All)
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
                '20190813 DEL START
                'FR_SSSMAIN.PopupMenu(FR_SSSMAIN.SM_ShortCut, vbPopupMenuLeftButton)
                FR_SSSMAIN.SM_ShortCut.Show()
                '20190813 DEL END
                'ﾛｽﾄﾌｫｰｶｽｲﾍﾞﾝﾄの抑制解除
                pm_All.Dsp_Base.LostFocus_Flg = False
				' === 20060817 === DELETE S
				'あると不具合が発生するので、はずす
				'（例：ﾎﾟｯﾌﾟｱｯﾌﾟﾒﾆｭｰ表示状態で×ﾎﾞﾀﾝ押下により、実行時ｴﾗｰ発生）
				'D            DoEvents
				' === 20060817 === DELETE E
			End If
			
			'対象コントロールの使用可
			pm_Trg_Dsp_Sub_Inf.Ctl.Enabled = True
			'フォーカスを移動を元に戻す
			Call CF_Set_Item_SetFocus(pm_Trg_Dsp_Sub_Inf, pm_All)
			
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
		Call CF_Body_Dsp(pm_All)
		
		'ｱｸﾃｨﾌﾞｺﾝﾄﾛｰﾙが明細部のみ制御
		'UPGRADE_WARNING: オブジェクト pm_Act_Dsp_Sub_Inf.Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト pm_Act_Dsp_Sub_Inf.Detail.In_Area の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If pm_Act_Dsp_Sub_Inf.Detail.In_Area = IN_AREA_DSP_BD And pm_Act_Dsp_Sub_Inf.Detail.Body_Index > 0 Then
			
			'現在の行を取得
			'UPGRADE_WARNING: オブジェクト pm_Act_Dsp_Sub_Inf.Detail.Body_Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
	
	''======================= 変更部分 2006.06.26 Start =================================
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'    '   名称：  Function CF_Ctl_MN_Cmn_DE_Focus
	'    '   概要：  メニューの明細初期化／明細削除／明細復元時のフォーカス制御
	'    '   引数：　なし
	'    '   戻値：　なし
	'    '   備考：
	'    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'Public Function CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, pm_Row As Integer, pm_All As Cls_All) As Boolean
	'
	'    Dim Trg_Index               As Integer
	'    Dim Move_Flg                As Boolean
	'    Dim Focus_Ctl_Ok_Fst_Idx    As Integer
	'    Dim Trg_Index_Same_Row      As Integer
	'
	'    '画面明細の行と同一の明細をインデックスを取得
	'    Trg_Index = CF_Get_Idex_Same_Bd_Ctl(pm_Dsp_Sub_Inf, pm_Row, pm_All)
	'
	'     If Trg_Index > 0 Then
	'        If Trg_Index = CInt(pm_Dsp_Sub_Inf.Ctl.Tag) Then
	'        '移動先が同じ場合
	'            If pm_Dsp_Sub_Inf.Ctl.TabStop = True Then
	'                '選択状態の設定（初期選択）
	'                Call CF_Set_Sel_Ini(pm_All.Dsp_Sub_Inf(Trg_Index), SEL_INI_MODE_2)
	'                '項目色設定
	'                Call CF_Set_Item_Color(pm_All.Dsp_Sub_Inf(Trg_Index), ITEM_SELECT_STATUS, pm_All)
	'
	'            Else
	'                '状態が最終準備行の場合
	'                If pm_All.Dsp_Body_Inf.Row_Inf(pm_Row).Status = BODY_ROW_STATE_LST_ROW Then
	'                    '同行の管理コードのｲﾝﾃﾞｯｸｽ取得
	'                    Trg_Index_Same_Row = CInt(FR_SSSMAIN.BD_CTLCD(pm_Row).Tag)
	'                    'ﾌｫｰｶｽ移動
	'                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index_Same_Row), pm_All)
	'                Else
	'                    'ﾌｫｰｶｽ移動
	'                    Call CF_Set_Item_SetFocus(pm_All.Dsp_Sub_Inf(Trg_Index - pm_All.Dsp_Base.Body_Col_Cnt), pm_All)
	'                End If
	'            End If
	'
	'        Else
	'            '同一項目の１つ前からENTキー押下と同様に次の項目へ
	'            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Trg_Index - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
	'        End If
	'
	'    Else
	'        '入力可能な最初のインデックスを取得
	'        Focus_Ctl_Ok_Fst_Idx = CF_Get_Body_Focus_Ctl_Fst_Idx(pm_Row, pm_All)
	'        If Focus_Ctl_Ok_Fst_Idx > 0 Then
	'            '同一項目の１つ前からENTキー押下と同様に次の項目へ
	'            Call F_Set_Next_Focus(pm_All.Dsp_Sub_Inf(Focus_Ctl_Ok_Fst_Idx - 1), NEXT_FOCUS_MODE_KEYRETURN, Move_Flg, pm_All)
	'        End If
	'    End If
	'
	'End Function
	''======================= 変更部分 2006.06.26 End =================================
	'
	'======================= 変更部分 2006.06.26 Start =================================
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CF_Ctl_MN_ClearDE
	'   概要：  メニューの明細初期化の制御
	'   引数：　なし
	'   戻値：　なし
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function CF_Ctl_MN_ClearDE(ByRef pm_Dsp_Sub_Inf As Cls_Dsp_Sub_Inf, ByRef pm_All As Cls_All) As Short
		'
		'    Dim Bd_Index            As Integer
		'    Dim Row_Wk              As Integer
		'
		'    '画面の内容を退避
		'    Call CF_Body_Bkup(pm_All)
		'
		'    'Dsp_Body_Infの行ＮＯを取得
		'    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		'
		'    '共通の明細初期化
		'    If CF_Cmn_Ctl_MN_ClearDE(Bd_Index, pm_All) = True Then
		''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'        '業務の初期値を編集
		'        Call F_Init_Dsp_Body(Bd_Index, pm_All)
		'
		'        '行Ｎｏ採番処理
		'        Call F_Edi_Saiban_No(pm_All)
		''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		'
		'        '画面表示
		'        'Call CF_Body_Dsp(pm_All)
		'        Call F_Body_Dsp(pm_All)
		'
		'        '元の画面の行に移動
		'        Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
		'
		'        'フォーカス決定
		'        Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
		'
		'    End If
		'
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
		'
		'    Dim Bd_Index            As Integer
		'    Dim Row_Inf_Max_S       As Integer
		'    Dim Row_Inf_Max_E       As Integer
		'    Dim Bd_Index_Wk         As Integer
		'    Dim Row_Wk              As Integer
		'    Dim Max_Row             As Integer
		'
		'    '画面の内容を退避
		'    Call CF_Body_Bkup(pm_All)
		'
		'    'Dsp_Body_Infの行ＮＯを取得
		'    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		'
		'    '共通の明細削除
		'    Call CF_Cmn_Ctl_MN_DeleteDE(Bd_Index, pm_All, Row_Inf_Max_S, Row_Inf_Max_E)
		'
		''Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'    'ページの再設定
		'    If (UBound(pm_All.Dsp_Body_Inf.Row_Inf) Mod pm_All.Dsp_Base.Dsp_Body_Cnt) = 0 Then
		'        MaxPageNum = UBound(pm_All.Dsp_Body_Inf.Row_Inf) / pm_All.Dsp_Base.Dsp_Body_Cnt
		'
		'        If MaxPageNum < NowPageNum Then
		'            NowPageNum = MaxPageNum
		'        End If
		'    End If
		'
		'    '画面ボディ情報の再設定
		'    If UBound(pm_All.Dsp_Body_Inf.Row_Inf) < pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum Then
		'        Max_Row = pm_All.Dsp_Base.Dsp_Body_Cnt * MaxPageNum
		'        ReDim Preserve pm_All.Dsp_Body_Inf.Row_Inf(Max_Row)
		'
		'        pm_All.Dsp_Body_Inf.Row_Inf(Max_Row).Item_Detail = pm_All.Dsp_Body_Inf.Row_Inf(0).Item_Detail
		'    End If
		'
		'    '対象行の状態を再設定
		'    For Bd_Index_Wk = 0 To pm_All.Dsp_Base.Dsp_Body_Cnt - 1
		'        If pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index_Wk).Status = BODY_ROW_STATE_LST_ROW Then
		''            pm_All.Dsp_Body_Inf.Row_Inf(Bd_Index_Wk).Status = BODY_ROW_STATE_INPUT_WAIT
		'        End If
		'    Next
		''Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		'
		'    '画面表示
		''    Call CF_Body_Dsp(pm_All)
		'    Call F_Body_Dsp(pm_All)
		'
		'    '元の画面の行に移動
		'    Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
		'
		'    'フォーカス決定
		'    Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
		'
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
		'
		'    Dim Bd_Index            As Integer
		'    Dim Bd_Index_Wk         As Integer
		'    Dim Ins_Bd_Index        As Integer
		'    Dim Row_Wk              As Integer
		'
		'    '画面の内容を退避
		'    Call CF_Body_Bkup(pm_All)
		'
		'    'Dsp_Body_Infの行ＮＯを取得
		'    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		'
		'    '共通の明細挿入
		'    If CF_Cmn_Ctl_MN_InsertDE(Bd_Index, Ins_Bd_Index, pm_All) = True Then
		'    'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'        '業務の初期値を編集
		'        Call F_Init_Dsp_Body(Ins_Bd_Index, pm_All)
		'
		'        '行Ｎｏ採番処理
		'        Call F_Edi_Saiban_No(pm_All)
		'    'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		'
		'        '対象行を画面に表示
		'        Call CF_Body_Dsp_Trg_Row(pm_All, Ins_Bd_Index)
		'
		'        '追加行に移動
		'        Row_Wk = CF_Idx_To_Bd_Idx(Ins_Bd_Index, pm_All)
		'
		'        'フォーカス決定
		'        Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
		'
		'    End If
		'
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
		'
		'    Dim Bd_Index            As Integer
		'    Dim Row_Inf_Max_S       As Integer
		'    Dim Row_Inf_Max_E       As Integer
		'    Dim Bd_Index_Wk         As Integer
		'    Dim Row_Wk              As Integer
		'
		'    '画面の内容を退避
		'    Call CF_Body_Bkup(pm_All)
		'
		'    'Dsp_Body_Infの行ＮＯを取得
		'    Bd_Index = CF_Bd_Idx_To_Idx(pm_Dsp_Sub_Inf, pm_All)
		'
		'    '共通の明細復元
		'    If CF_Cmn_Ctl_MN_UnDoDe(pm_All, Row_Inf_Max_S, Row_Inf_Max_E) = True Then
		'    'Ｓ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｓ
		'        '行を追加された後に
		'        '初期値を追加した行に対してループ内で１行ずつ行う
		'        'ここでの行は、Dsp_Body_Infの行！！
		'        For Bd_Index_Wk = Row_Inf_Max_S To Row_Inf_Max_E
		'            Call F_Init_Dsp_Body(Bd_Index_Wk, pm_All)
		'        Next
		'
		'        '行Ｎｏ採番処理
		'        Call F_Edi_Saiban_No(pm_All)
		'    'Ｅ★★★★★★★★★★★★★★★★★★★★★★★★★★★★Ｅ
		'
		'        '画面表示
		'        'Call CF_Body_Dsp(pm_All)
		'        Call F_Body_Dsp(pm_All)
		'
		'        '元の画面の行に移動
		'        Row_Wk = pm_Dsp_Sub_Inf.Detail.Body_Index
		'
		'        'フォーカス決定
		'        Call CF_Ctl_MN_Cmn_DE_Focus(pm_Dsp_Sub_Inf, Row_Wk, pm_All)
		'
		'    End If
		'
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
        '20190813 CHG START
        'Act_SelStart = pm_Dsp_Sub_Inf.Ctl.SelStart
        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Act_SelLength = pm_Dsp_Sub_Inf.Ctl.SelLength
        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'Act_SelStr = pm_Dsp_Sub_Inf.Ctl.SelText
        Act_SelStart = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionStart
        Act_SelLength = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectionLength
        Act_SelStr = DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).SelectedText
        '20190813 CHG END
        Act_SelStrB = CF_Ctr_AnsiLenB(Act_SelStr)
		'現在の値を取得
		'UPGRADE_WARNING: オブジェクト CF_Get_Item_Value() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Wk_CurMoji = CF_Get_Input_Ok_Item(CF_Get_Item_Value(pm_Dsp_Sub_Inf), pm_Dsp_Sub_Inf)
		
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Fil_Point の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
		
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.In_Typ の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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
		
		'エラーフラグを落とす
		'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Detail.Err_Status の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pm_Dsp_Sub_Inf.Detail.Err_Status = ERR_DEF
		
		'ﾁｪﾝｼﾞｲﾍﾞﾝﾄを起こさずに編集
		Call CF_Set_Item_Not_Change(Wk_DspMoji, pm_Dsp_Sub_Inf, pm_All)

        '編集後のSelStartを決定
        'UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190813 CHG START
        'pm_Dsp_Sub_Inf.Ctl.SelStart = Wk_SelStart
        ''編集後のSelLengthを決定
        ''UPGRADE_WARNING: オブジェクト pm_Dsp_Sub_Inf.Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'pm_Dsp_Sub_Inf.Ctl.SelLength = Wk_SelLength
        DirectCast(pm_Dsp_Sub_Inf.Ctl, TextBox).Select(Wk_SelStart, Wk_SelLength)
        '20190813 CHG END

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
        '20190813 DEL START
        'FR_SSSMAIN.PrintForm()
        '20190813 CHG END
        FR_SSSMAIN.Cursor = System.Windows.Forms.Cursors.Arrow
		If Err.Number <> 0 Then
			If AE_MsgLibrary(PP_SSSMAIN, "HardcopyError") Then AE_Hardcopy_SSSMAIN = Cn_CuCurrent : Exit Function
		End If
		On Error GoTo 0
		AE_Hardcopy_SSSMAIN = Cn_CuCurrent
	End Function
	
	'2007/12/13 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function PF_Get_UWRTDTTM
	'   概要：  更新日付時間取得処理
	'   引数：  pot_strWRTDT            : 更新日付
	'           pot_strWRTTM            : 更新時刻
	'           pot_strUWRTDT           : バッチ更新日付
	'           pot_strUWRTTM           : バッチ更新時刻
	'           pin_intIDX              : 使用しない
	'   戻値：  0 : 正常終了  9 : 異常終了
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function PF_Get_UWRTDTTM(ByRef pot_strWRTDT As String, ByRef pot_strWRTTM As String, ByRef pot_strUWRTDT As String, ByRef pot_strUWRTTM As String, Optional ByRef pin_intIDX As Short = 0) As Short
		Dim strSQL As String
		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
		Dim Usr_Ody As U_Ody
		
		'2007/12/27 upd-str M.SUEZAWA
		'''2007/12/19 add-str T.KAWAMUKAI
		''    Dim strHD_CLDDT    As String
		''    Dim strHD_BD_CLDT    As String
		'''2007/12/19 add-end T.KAWAMUKAI
		Dim strHD_DT As String
		'2007/12/27 upd-end M.SUEZAWA
		
		On Error GoTo PF_Get_UWRTDTTM_ERR
		
		PF_Get_UWRTDTTM = 9
		
		'2007/12/27 upd-str M.SUEZAWA
		'''    strHD_CLDDT = Trim(FR_SSSMAIN.HD_CLDDT.Text)
		'''    strHD_BD_CLDT = Trim(FR_SSSMAIN.BD_CLDT(0).Text)
		''''2007/12/27 upd-str T.KAWAMUKAI
		'''    strHD_BD_CLDT = "/" & strHD_BD_CLDT
		''''2007/12/27 upd-end T.KAWAMUKAI
		''''''''    strHD_CLDDT = CF_Get_Input_Ok_Item(CStr(strHD_CLDDT), pm_All.Dsp_Sub_Inf(FR_SSSMAIN.HD_CLDDT.Tag))
		''''''    strHD_CLDDT = CF_Get_Input_Ok_Item(CStr(strHD_CLDDT), CStr(strHD_BD_CLDT))
		
		strHD_DT = Replace(Trim(FR_SSSMAIN.HD_CLDDT.Text), "/", "") & "01"
		'2007/12/27 upd-end M.SUEZAWA
		
		strSQL = ""
		strSQL = strSQL & " SELECT "
		strSQL = strSQL & "   WRTDT, "
		strSQL = strSQL & "   WRTTM, "
		strSQL = strSQL & "   UWRTDT, "
		strSQL = strSQL & "   UWRTTM "
		strSQL = strSQL & " FROM "
		strSQL = strSQL & "   CLDMTA "
		strSQL = strSQL & " WHERE "
		'2007/12/27 upd-str M.SUEZAWA
		'''    strSQL = strSQL & "   CLDDT = '"
		''''2007/12/19 upd-str T.KAWAMUKAI
		''''''    strSQL = strSQL & FR_SSSMAIN.BD_CLDT(0).Text
		''''''    strSQL = strSQL & CF_Ora_String(strHD_CLDDT & CLDMT51_CLDMTA_Update_Inf(0).CLDDT, 10)
		'''    strSQL = strSQL & strHD_CLDDT & strHD_BD_CLDT & "'"
		''''2007/12/19 upd-end T.KAWAMUKAI
		strSQL = strSQL & "   CLDDT = '" & strHD_DT & "'"
		'2007/12/27 upd-end M.SUEZAWA
		
		'2008/07/08 START ADD FNAP)YAMANE 連絡票�ａF排他-54
		'ロックする
		strSQL = strSQL & "          FOR UPDATE"
		'2008/07/08 E.N.D ADD FNAP)YAMANE 連絡票�ａF排他-54
		
		'// 初期化
		pot_strWRTDT = ""
		pot_strWRTTM = ""
		pot_strUWRTDT = ""
		pot_strUWRTTM = ""

        '20190814 CHG START
        'Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)
        Dim dt As DataTable = DB_GetTable(strSQL)
        '20190814 CHG END

        If CF_Ora_EOF(Usr_Ody) = True Then
			GoTo PF_Get_UWRTDTTM_END
		End If
		
		'データのタイムスタンプ退避
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pot_strWRTDT = CF_Ora_GetDyn(Usr_Ody, "WRTDT", "") '更新日付
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pot_strWRTTM = CF_Ora_GetDyn(Usr_Ody, "WRTTM", "") '更新時刻
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pot_strUWRTDT = CF_Ora_GetDyn(Usr_Ody, "UWRTDT", "") 'バッチ更新日付
		'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		pot_strUWRTTM = CF_Ora_GetDyn(Usr_Ody, "UWRTTM", "") 'バッチ更新時刻
		
		PF_Get_UWRTDTTM = 0
		
		
PF_Get_UWRTDTTM_END: 
		
		Call CF_Ora_CloseDyn(Usr_Ody)
		
		Exit Function
		
PF_Get_UWRTDTTM_ERR: 
		
		GoTo PF_Get_UWRTDTTM_END
		
	End Function
    '2007/12/13 add-end T.KAWAMUKAI

    '□□□□□□□□ プログラム単位の共通処理 End □□□□□□□□□□□□□□□□

    '20190813 ADD START
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '   名称：  Function CF_Set_Frm_IN_TANCD
    '   概要：  入力担当者編集
    '   引数：　pm_Form        :フォーム
    '   戻値：　なし
    '   備考：
    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    Public Function CF_Set_Frm_IN_TANCD(ByRef pm_Form As FR_SSSMAIN, ByRef pm_All As Cls_All) As Short

        Dim Trg_Index As Short
        Dim Dsp_Value As Object

        With pm_Form
            '入力担当者コード
            'UPGRADE_ISSUE: Control HD_IN_TANCD は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Trg_Index = CShort(.HD_IN_TANCD.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanCd, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)

            '入力担当者名
            'UPGRADE_ISSUE: Control HD_IN_TANNM は、汎用名前空間 Form 内にあるため、解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="084D22AD-ECB1-400F-B4C7-418ECEC5E36E"' をクリックしてください。
            Trg_Index = CShort(.HD_IN_TANNM.Tag)
            'UPGRADE_WARNING: オブジェクト CF_Cnv_Dsp_Item() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト Dsp_Value の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Dsp_Value = CF_Cnv_Dsp_Item(Inp_Inf.InpTanNm, pm_All.Dsp_Sub_Inf(Trg_Index), False)
            Call CF_Set_Item_Direct(Dsp_Value, pm_All.Dsp_Sub_Inf(Trg_Index), pm_All, SET_FLG_DB)
        End With

    End Function
    '20190813 ADD END
End Module