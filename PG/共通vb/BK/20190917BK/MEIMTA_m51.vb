Option Strict Off
Option Explicit On
Module MEIMTA_M51
	'
	' スロット名        : メインファイル更新スロット
	' ユニット名        : MEIMTA.M51
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/08
	' 使用プログラム名  : MEIMT51
	'
	
	' === 20080916 === INSERT S - RISE)Izumi
	'更新時刻、更新日付、バッチ更新時刻、バッチ更新日付　退避用
	Structure M_TYPE_MEIMT
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '最終作業者コード
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char 'クライアントＩＤ
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UOPEID() As Char '最終作業者コード（バッチ）
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public UCLTID() As Char 'クライアントＩＤ（バッチ）
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
	End Structure
	Public M_MEIMT_inf As M_TYPE_MEIMT
	Public M_MEIMT_A_inf() As M_TYPE_MEIMT
    ' === 20080916 === INSERT E - RISE)Izumi

    '	Sub UPDMST()
    '		Dim I As Short
    '		Dim updkb As String
    '		Dim WRTTM, WRTDT As String

    '		'2007/12/18 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
    '		Dim bolRet As Boolean
    '		Dim intRet As Short

    '		' === 20080916 === INSERT S - RISE)Izumi チェック項目追加
    '		Dim strOPEID As String '最終作業者コード
    '		Dim strCLTID As String 'クライアントＩＤ
    '		Dim strUOPEID As String '最終作業者コード（バッチ）
    '		Dim strUCLTID As String 'クライアントＩＤ（バッチ）
    '		' === 20080916 === INSERT E - RISE)Izumi
    '		Dim strWRTDT As String '更新日付
    '		Dim strWRTTM As String '更新時刻
    '		Dim strUWRTDT As String 'バッチ更新日付
    '		Dim strUWRTTM As String 'バッチ更新時刻
    '		'2007/12/18 add-end T.KAWAMUKAI


    '		'更新権限チェック
    '		If gs_UPDAUTH = "9" Then
    '			Call MsgBox("更新権限がありません。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
    '			Exit Sub
    '		End If

    '		'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-57
    '		Call DB_BeginTransaction(CStr(BTR_Exclude))
    '		'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-57

    '		'2007/12/18 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
    '		'更新時間チェック（画面に表示されている明細分）
    '		I = 0
    '		Dim strSQL As String
    '		Do While I < PP_SSSMAIN.LastDe
    '			DB_MEIMTA.KEYCD = DB_MEIMTB.KEYCD
    '			DB_MEIMTA.MEIKMKNM = DB_MEIMTB.MEIKMKNM
    '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEICDA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			DB_MEIMTA.MEICDA = RD_SSSMAIN_MEICDA(I)
    '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEICDB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			DB_MEIMTA.MEICDB = RD_SSSMAIN_MEICDB(I)
    '			Call DB_GetEq(DBN_MEIMTA, 1, DB_MEIMTA.KEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB, BtrNormal)
    '			If DBSTAT = 0 Then
    '				' === 20080916 === INSERT S - RISE)Izumi チェック項目追加
    '				strOPEID = DB_MEIMTA.OPEID '最終作業者コード
    '				strCLTID = DB_MEIMTA.CLTID 'クライアントＩＤ
    '				strUOPEID = DB_MEIMTA.UOPEID '最終作業者コード（バッチ）
    '				strUCLTID = DB_MEIMTA.UCLTID 'クライアントＩＤ（バッチ）
    '				' === 20080916 === INSERT E - RISE)Izumi
    '				strWRTDT = DB_MEIMTA.WRTDT '更新日付
    '				strWRTTM = DB_MEIMTA.WRTTM '更新時刻
    '				strUWRTDT = DB_MEIMTA.UWRTDT 'バッチ更新日付
    '				strUWRTTM = DB_MEIMTA.UWRTTM 'バッチ更新時刻

    '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				updkb = RD_SSSMAIN_UPDKB(I)
    '				If updkb = "削除" Then

    '					'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-57
    '					HaitaUpdFlg = 0
    '					strSQL = ""
    '					' === 20080916 === UPDATE S - RISE)Izumi チェック項目追加
    '					'                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM MEIMTA"
    '					strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM MEIMTA"
    '					' === 20080916 === UPDATE E - RISE)Izumi
    '					strSQL = strSQL & " WHERE KEYCD = '" & DB_MEIMTB.KEYCD & "'"
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEICDA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					strSQL = strSQL & " AND MEICDA = '" + RD_SSSMAIN_MEICDA(I) + "'"
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEICDB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					strSQL = strSQL & " AND MEICDB = '" + RD_SSSMAIN_MEICDB(I) + "'"
    '					'ロックする
    '					strSQL = strSQL & "          FOR UPDATE"
    '					Call DB_GetSQL2(DBN_MEIMTA, strSQL)
    '					' === 20080916 === INSERT S - RISE)Izumi チェック項目追加
    '					strOPEID = DB_MEIMTA.OPEID '最終作業者コード
    '					strCLTID = DB_MEIMTA.CLTID 'クライアントＩＤ
    '					strUOPEID = DB_MEIMTA.UOPEID '最終作業者コード（バッチ）
    '					strUCLTID = DB_MEIMTA.UCLTID 'クライアントＩＤ（バッチ）
    '					' === 20080916 === INSERT E - RISE)Izumi
    '					strWRTDT = DB_MEIMTA.WRTDT '更新日付
    '					strWRTTM = DB_MEIMTA.WRTTM '更新時刻
    '					strUWRTDT = DB_MEIMTA.UWRTDT 'バッチ更新日付
    '					strUWRTTM = DB_MEIMTA.UWRTTM 'バッチ更新時刻
    '					'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-57

    '					'更新時間チェック
    '					' === 20080916 === UPDATE S - RISE)Izumi チェック項目追加
    '					'                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
    '					bolRet = MEIMT52_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
    '					' === 20080916 === UPDATE E - RISE)Izumi
    '					If bolRet = False Then
    '						intRet = MF_DspMsg(gc_strMsgMEIMT52_E_DEL)
    '						'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-57
    '						Call DB_Unlock(DBN_MEIMTA)
    '						Call DB_AbortTransaction()
    '						HaitaUpdFlg = 1
    '						'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-57
    '						Exit Sub
    '					End If

    '				Else
    '					If updkb = "追加" Then
    '						intRet = MF_DspMsg(gc_strMsgMEIMT52_E_UPD)
    '						'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-57
    '						Call DB_Unlock(DBN_MEIMTA)
    '						Call DB_AbortTransaction()
    '						'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-57
    '						Exit Sub
    '					Else
    '						'2007/12/21 add-str T.KAWAMUKAI
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DSPORD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DSPORD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEIKBC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEIKBB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEIKBA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEINMC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEINMC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEINMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEINMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEINMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEINMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '						If Trim(RD_SSSMAIN_MEINMA(I)) <> Trim(RD_SSSMAIN_V_MEINMA(I)) Or Trim(RD_SSSMAIN_MEINMB(I)) <> Trim(RD_SSSMAIN_V_MEINMB(I)) Or Trim(RD_SSSMAIN_MEINMC(I)) <> Trim(RD_SSSMAIN_V_MEINMC(I)) Or Trim(RD_SSSMAIN_MEISUA(I)) <> Trim(RD_SSSMAIN_V_MEISUA(I)) Or Trim(RD_SSSMAIN_MEISUB(I)) <> Trim(RD_SSSMAIN_V_MEISUB(I)) Or Trim(RD_SSSMAIN_MEISUC(I)) <> Trim(RD_SSSMAIN_V_MEISUC(I)) Or Trim(RD_SSSMAIN_MEIKBA(I)) <> Trim(RD_SSSMAIN_V_MEIKBA(I)) Or Trim(RD_SSSMAIN_MEIKBB(I)) <> Trim(RD_SSSMAIN_V_MEIKBB(I)) Or Trim(RD_SSSMAIN_MEIKBC(I)) <> Trim(RD_SSSMAIN_V_MEIKBC(I)) Or Trim(RD_SSSMAIN_DSPORD(I)) <> Trim(RD_SSSMAIN_V_DSPORD(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then
    '							'2007/12/21 add-end T.KAWAMUKAI
    '							'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-57
    '							HaitaUpdFlg = 0
    '							strSQL = ""
    '							' === 20080916 === UPDATE S - RISE)Izumi チェック項目追加
    '							'                       strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM MEIMTA"
    '							strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM MEIMTA"
    '							' === 20080916 === UPDATE E - RISE)Izumi
    '							strSQL = strSQL & " WHERE KEYCD = '" & DB_MEIMTB.KEYCD & "'"
    '							'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEICDA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '							strSQL = strSQL & " AND MEICDA = '" + RD_SSSMAIN_MEICDA(I) + "'"
    '							'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEICDB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '							strSQL = strSQL & " AND MEICDB = '" + RD_SSSMAIN_MEICDB(I) + "'"
    '							'ロックする
    '							strSQL = strSQL & "          FOR UPDATE"
    '							Call DB_GetSQL2(DBN_MEIMTA, strSQL)
    '							' === 20080916 === INSERT S - RISE)Izumi チェック項目追加
    '							strOPEID = DB_MEIMTA.OPEID '最終作業者コード
    '							strCLTID = DB_MEIMTA.CLTID 'クライアントＩＤ
    '							strUOPEID = DB_MEIMTA.UOPEID '最終作業者コード（バッチ）
    '							strUCLTID = DB_MEIMTA.UCLTID 'クライアントＩＤ（バッチ）
    '							' === 20080916 === INSERT E - RISE)Izumi
    '							strWRTDT = DB_MEIMTA.WRTDT '更新日付
    '							strWRTTM = DB_MEIMTA.WRTTM '更新時刻
    '							strUWRTDT = DB_MEIMTA.UWRTDT 'バッチ更新日付
    '							strUWRTTM = DB_MEIMTA.UWRTTM 'バッチ更新時刻
    '							'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-57

    '							'更新時間チェック
    '							' === 20080916 === UPDATE S - RISE)Izumi チェック項目追加
    '							'                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
    '							bolRet = MEIMT52_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
    '							' === 20080916 === UPDATE E - RISE)Izumi
    '							If bolRet = False Then
    '								intRet = MF_DspMsg(gc_strMsgMEIMT52_E_UPD)
    '								'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-57
    '								Call DB_Unlock(DBN_MEIMTA)
    '								Call DB_AbortTransaction()
    '								HaitaUpdFlg = 1
    '								'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-57
    '								Exit Sub
    '							End If
    '						End If
    '					End If
    '				End If
    '			End If
    '			I = I + 1
    '		Loop 
    '		'2007/12/18 add-end T.KAWAMUKAI

    '		'
    '		I = 0
    '		WRTTM = VB6.Format(Now, "hhmmss")
    '		WRTDT = VB6.Format(Now, "YYYYMMDD")

    '		'2008/07/11 START DEL FNAP)YAMANE 連絡票№：排他-57
    '		'上部のチェックのループの開始時に宣言するように変更
    '		'    Call DB_BeginTransaction(BTR_Exclude)
    '		'2008/07/11 E.N.D DEL FNAP)YAMANE 連絡票№：排他-57

    '		Do While I < PP_SSSMAIN.LastDe

    '			DB_MEIMTA.KEYCD = DB_MEIMTB.KEYCD
    '			DB_MEIMTA.MEIKMKNM = DB_MEIMTB.MEIKMKNM
    '			''''    DB_MEIMTA.MEICDA = Trim$(RD_SSSMAIN_MEICDA(I))
    '			''''    DB_MEIMTA.MEICDB = Trim$(RD_SSSMAIN_MEICDB(I))
    '			''''    Call DB_GetEq(DBN_MEIMTA, 1, DB_MEIMTA.KEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB, BtrLock)
    '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEICDA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			DB_MEIMTA.MEICDA = RD_SSSMAIN_MEICDA(I)
    '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEICDB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			DB_MEIMTA.MEICDB = RD_SSSMAIN_MEICDB(I)
    '			'2007/10/03 FKS)minamoto CHG START
    '			'Call DB_GetEq(DBN_MEIMTA, 2, DB_MEIMTA.KEYCD & DB_MEIMTA.MEICDA, BtrLock)
    '			Call DB_GetEq(DBN_MEIMTA, 1, DB_MEIMTA.KEYCD & DB_MEIMTA.MEICDA & DB_MEIMTA.MEICDB, BtrLock)
    '			'2007/10/03 FKS)minamoto CHG END
    '			If DBSTAT = 0 Then
    '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				updkb = RD_SSSMAIN_UPDKB(I)
    '				If updkb = "削除" Then
    '					DB_MEIMTA.DATKB = "9"
    '					DB_MEIMTA.RELFL = "1" '" "
    '					DB_MEIMTA.OPEID = SSS_OPEID.Value
    '					DB_MEIMTA.CLTID = SSS_CLTID.Value
    '					DB_MEIMTA.WRTTM = WRTTM
    '					DB_MEIMTA.WRTDT = WRTDT
    '					DB_MEIMTA.UOPEID = SSS_OPEID.Value
    '					DB_MEIMTA.UCLTID = SSS_CLTID.Value
    '					DB_MEIMTA.UWRTTM = WRTTM
    '					DB_MEIMTA.UWRTDT = WRTDT
    '					DB_MEIMTA.PGID = SSS_PrgId
    '					Call DB_Update(DBN_MEIMTA, 1)
    '				Else
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DSPORD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DSPORD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEIKBC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEIKBB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEIKBA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEIKBA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEISUA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEISUA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEINMC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEINMC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEINMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEINMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_MEINMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MEINMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '					If Trim(RD_SSSMAIN_MEINMA(I)) <> Trim(RD_SSSMAIN_V_MEINMA(I)) Or Trim(RD_SSSMAIN_MEINMB(I)) <> Trim(RD_SSSMAIN_V_MEINMB(I)) Or Trim(RD_SSSMAIN_MEINMC(I)) <> Trim(RD_SSSMAIN_V_MEINMC(I)) Or Trim(RD_SSSMAIN_MEISUA(I)) <> Trim(RD_SSSMAIN_V_MEISUA(I)) Or Trim(RD_SSSMAIN_MEISUB(I)) <> Trim(RD_SSSMAIN_V_MEISUB(I)) Or Trim(RD_SSSMAIN_MEISUC(I)) <> Trim(RD_SSSMAIN_V_MEISUC(I)) Or Trim(RD_SSSMAIN_MEIKBA(I)) <> Trim(RD_SSSMAIN_V_MEIKBA(I)) Or Trim(RD_SSSMAIN_MEIKBB(I)) <> Trim(RD_SSSMAIN_V_MEIKBB(I)) Or Trim(RD_SSSMAIN_MEIKBC(I)) <> Trim(RD_SSSMAIN_V_MEIKBC(I)) Or Trim(RD_SSSMAIN_DSPORD(I)) <> Trim(RD_SSSMAIN_V_DSPORD(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
    '						Call Mfil_FromSCR(I)
    '						DB_MEIMTA.DATKB = "1"
    '						DB_MEIMTA.RELFL = "1" '" "
    '						DB_MEIMTA.WRTTM = WRTTM
    '						DB_MEIMTA.WRTDT = WRTDT
    '						DB_MEIMTA.UOPEID = SSS_OPEID.Value
    '						DB_MEIMTA.UCLTID = SSS_CLTID.Value
    '						DB_MEIMTA.UWRTTM = WRTTM
    '						DB_MEIMTA.UWRTDT = WRTDT
    '						DB_MEIMTA.PGID = SSS_PrgId
    '						Call DB_Update(DBN_MEIMTA, 1)
    '					End If '2006.11.07
    '				End If
    '			Else
    '				Call Mfil_FromSCR(I)
    '				DB_MEIMTA.KEYCD = DB_MEIMTB.KEYCD
    '				DB_MEIMTA.MEIKMKNM = DB_MEIMTB.MEIKMKNM
    '				DB_MEIMTA.DATKB = "1"
    '				DB_MEIMTA.RELFL = "1" '" "
    '				DB_MEIMTA.WRTFSTTM = WRTTM
    '				DB_MEIMTA.WRTFSTDT = WRTDT
    '				DB_MEIMTA.FOPEID = SSS_OPEID.Value
    '				DB_MEIMTA.FCLTID = SSS_CLTID.Value
    '				DB_MEIMTA.WRTFSTTM = WRTTM
    '				DB_MEIMTA.WRTFSTDT = WRTDT
    '				DB_MEIMTA.WRTTM = WRTTM
    '				DB_MEIMTA.WRTDT = WRTDT
    '				DB_MEIMTA.UOPEID = SSS_OPEID.Value
    '				DB_MEIMTA.UCLTID = SSS_CLTID.Value
    '				DB_MEIMTA.UWRTTM = WRTTM
    '				DB_MEIMTA.UWRTDT = WRTDT
    '				DB_MEIMTA.PGID = SSS_PrgId
    '				Call DB_Insert(DBN_MEIMTA, 1)
    '			End If
    '			I = I + 1
    '		Loop 
    '		Call DB_Unlock(DBN_MEIMTA)
    '		Call DB_EndTransaction()
    '	End Sub

    '	' === 20080916 === INSERT S - RISE)Izumi
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   名称：  Function MEIMT52_MF_Chk_UWRTDTTM_T
    '	'   概要：  更新時間チェック処理
    '	'   引数：  pin_strOPEID    : 最終作業者コード
    '	'           pin_strCLTID    : クライアントＩＤ
    '	'           pin_strUOPEID   : 最終作業者コード（バッチ）
    '	'           pin_strUCLTID   : クライアントＩＤ（バッチ）
    '	'           pin_strWRTDT    : 更新日付
    '	'           pin_strWRTTM    : 更新時刻
    '	'           pin_strUWRTDT   : バッチ更新日付
    '	'           pin_strUWRTTM   : バッチ更新時刻
    '	'           pin_intIDX      : 多明細の場合　　　　明細行（0～）
    '	'   　　　　　　　　　　　　　得意先Ｍ登録の場合　0…得意先 1…仕入先
    '	'   戻値：　True：チェックOK　False：チェックNG
    '	'   備考：  多明細及び、得意先Ｍ登録用
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function MEIMT52_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean

    '		On Error GoTo MEIMT52_MF_Chk_UWRTDTTM_T_err

    '		MEIMT52_MF_Chk_UWRTDTTM_T = False

    '		If InStr(Trim(M_MEIMT_A_inf(pin_intIDX).OPEID) & Trim(M_MEIMT_A_inf(pin_intIDX).CLTID) & Trim(M_MEIMT_A_inf(pin_intIDX).UOPEID) & Trim(M_MEIMT_A_inf(pin_intIDX).UCLTID) & Trim(M_MEIMT_A_inf(pin_intIDX).WRTDT) & Trim(M_MEIMT_A_inf(pin_intIDX).WRTTM) & Trim(M_MEIMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_MEIMT_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then

    '			'更新時間チェック
    '			If Trim(pin_strOPEID) & Trim(pin_strCLTID) & Trim(pin_strUOPEID) & Trim(pin_strUCLTID) & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_MEIMT_A_inf(pin_intIDX).OPEID) & Trim(M_MEIMT_A_inf(pin_intIDX).CLTID) & Trim(M_MEIMT_A_inf(pin_intIDX).UOPEID) & Trim(M_MEIMT_A_inf(pin_intIDX).UCLTID) & Trim(M_MEIMT_A_inf(pin_intIDX).WRTDT) & Trim(M_MEIMT_A_inf(pin_intIDX).WRTTM) & Trim(M_MEIMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_MEIMT_A_inf(pin_intIDX).UWRTTM) Then
    '				GoTo MEIMT52_MF_Chk_UWRTDTTM_T_End
    '			End If
    '		End If

    '		MEIMT52_MF_Chk_UWRTDTTM_T = True

    'MEIMT52_MF_Chk_UWRTDTTM_T_End: 
    '		Exit Function

    'MEIMT52_MF_Chk_UWRTDTTM_T_err: 
    '		GoTo MEIMT52_MF_Chk_UWRTDTTM_T_End

    '	End Function
    '	' === 20080916 === INSERT E - RISE)Izumi

    '	'20080925 ADD START RISE)Tanimura '排他処理
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   名称：  Function MEIMT52_MF_UpDown_UWRTDTTM
    '	'   概要：  明細　削除・挿入処理
    '	'   引数：  pin_intIDX      : 対象行
    '	'           pin_intGYO      : 1…削除（行詰め）　-1…挿入（行下げ）
    '	'   戻値：　True：処理OK　False：処理NG
    '	'   備考：
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function MEIMT52_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean

    '		On Error GoTo MEIMT52_MF_UpDown_UWRTDTTM_err

    '		MEIMT52_MF_UpDown_UWRTDTTM = False

    '		' 更新時間　配列移動
    '		M_MEIMT_A_inf(pin_intIDX).OPEID = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).OPEID
    '		M_MEIMT_A_inf(pin_intIDX).CLTID = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).CLTID
    '		M_MEIMT_A_inf(pin_intIDX).UOPEID = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UOPEID
    '		M_MEIMT_A_inf(pin_intIDX).UCLTID = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UCLTID
    '		M_MEIMT_A_inf(pin_intIDX).WRTDT = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
    '		M_MEIMT_A_inf(pin_intIDX).WRTTM = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
    '		M_MEIMT_A_inf(pin_intIDX).UWRTDT = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT
    '		M_MEIMT_A_inf(pin_intIDX).UWRTTM = M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM

    '		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
    '		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
    '		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UOPEID = ""
    '		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UCLTID = ""
    '		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
    '		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
    '		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
    '		M_MEIMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""

    '		MEIMT52_MF_UpDown_UWRTDTTM = True

    'MEIMT52_MF_UpDown_UWRTDTTM_End: 
    '		Exit Function

    'MEIMT52_MF_UpDown_UWRTDTTM_err: 
    '		GoTo MEIMT52_MF_UpDown_UWRTDTTM_End

    '	End Function

    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	'   名称：  Function MEIMT52_MF_SaveRestore_UWRTDTTM
    '	'   概要：  明細　退避・復元処理
    '	'   引数：  pin_intIDX      : 対象行
    '	'           pin_intKBN      : 0…退避　1…復元
    '	'   戻値：　True：処理OK　False：処理NG
    '	'   備考：
    '	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '	Public Function MEIMT52_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean

    '		On Error GoTo MEIMT52_MF_SaveRestore_UWRTDTTM_err

    '		MEIMT52_MF_SaveRestore_UWRTDTTM = False

    '		If pin_intKBN = 0 Then
    '			' 退避・復元処理
    '			M_MEIMT_inf.OPEID = M_MEIMT_A_inf(pin_intIDX).OPEID
    '			M_MEIMT_inf.CLTID = M_MEIMT_A_inf(pin_intIDX).CLTID
    '			M_MEIMT_inf.UOPEID = M_MEIMT_A_inf(pin_intIDX).UOPEID
    '			M_MEIMT_inf.UCLTID = M_MEIMT_A_inf(pin_intIDX).UCLTID
    '			M_MEIMT_inf.WRTDT = M_MEIMT_A_inf(pin_intIDX).WRTDT
    '			M_MEIMT_inf.WRTTM = M_MEIMT_A_inf(pin_intIDX).WRTTM
    '			M_MEIMT_inf.UWRTDT = M_MEIMT_A_inf(pin_intIDX).UWRTDT
    '			M_MEIMT_inf.UWRTTM = M_MEIMT_A_inf(pin_intIDX).UWRTTM
    '		Else
    '			' 復元処理
    '			M_MEIMT_A_inf(pin_intIDX).OPEID = M_MEIMT_inf.OPEID
    '			M_MEIMT_A_inf(pin_intIDX).CLTID = M_MEIMT_inf.CLTID
    '			M_MEIMT_A_inf(pin_intIDX).UOPEID = M_MEIMT_inf.UOPEID
    '			M_MEIMT_A_inf(pin_intIDX).UCLTID = M_MEIMT_inf.UCLTID
    '			M_MEIMT_A_inf(pin_intIDX).WRTDT = M_MEIMT_inf.WRTDT
    '			M_MEIMT_A_inf(pin_intIDX).WRTTM = M_MEIMT_inf.WRTTM
    '			M_MEIMT_A_inf(pin_intIDX).UWRTDT = M_MEIMT_inf.UWRTDT
    '			M_MEIMT_A_inf(pin_intIDX).UWRTTM = M_MEIMT_inf.UWRTTM
    '		End If

    '		MEIMT52_MF_SaveRestore_UWRTDTTM = True

    'MEIMT52_MF_SaveRestore_UWRTDTTM_End: 
    '		Exit Function

    'MEIMT52_MF_SaveRestore_UWRTDTTM_err: 
    '		GoTo MEIMT52_MF_SaveRestore_UWRTDTTM_End

    '	End Function
    '20080925 ADD END   RISE)Tanimura
End Module