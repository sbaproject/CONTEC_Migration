Option Strict Off
Option Explicit On
Module SOUMTA_M51
	'
	' スロット名        : メインファイル更新スロット
	' ユニット名        : SOUMTA.M51
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/09
	' 使用プログラム名  : SOUMT51
	'
	
	' === 20080901 === INSERT S - RISE)Izumi
	'更新時刻、更新日付、バッチ更新時刻、バッチ更新日付　退避用
	Structure M_TYPE_SOUMT
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
	Public M_SOUMT_inf As M_TYPE_SOUMT
	Public M_SOUMT_A_inf() As M_TYPE_SOUMT
	' === 20080901 === INSERT E - RISE)Izumi
	
	Sub UPDMST()
		Dim I As Short
		Dim updkb As String
		Dim WRTTM, WRTDT As String
		
		'2007/12/14 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		Dim bolRet As Boolean
		Dim intRet As Short
		
		' === 20080829 === INSERT S - RISE)Izumi チェック項目追加
		Dim strOPEID As String '最終作業者コード
		Dim strCLTID As String 'クライアントＩＤ
		Dim strUOPEID As String '最終作業者コード（バッチ）
		Dim strUCLTID As String 'クライアントＩＤ（バッチ）
		' === 20080829 === INSERT E - RISE)Izumi
		Dim strWRTDT As String '更新日付
		Dim strWRTTM As String '更新時刻
		Dim strUWRTDT As String 'バッチ更新日付
		Dim strUWRTTM As String 'バッチ更新時刻
		'2007/12/14 add-end T.KAWAMUKAI
		
		'更新権限チェック
		If gs_UPDAUTH = "9" Then
			Call MsgBox("更新権限がありません。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			Exit Sub
		End If
		
		'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-63
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-63
		
		'2007/12/14 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		'更新時間チェック（画面に表示されている明細分）
		I = 0
        Dim strSQL As String
        '20190819 CHG START
        '      Do While I < PP_SSSMAIN.LastDe
        '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_SOUMTA.SOUCD = RD_SSSMAIN_SOUCD(I)
        '	Call DB_GetEq(DBN_SOUMTA, 1, DB_SOUMTA.SOUCD, BtrNormal)
        '	If DBSTAT = 0 Then
        '		' === 20080829 === INSERT S - RISE)Izumi チェック項目追加
        '		strOPEID = DB_SOUMTA.OPEID '最終作業者コード
        '		strCLTID = DB_SOUMTA.CLTID 'クライアントＩＤ
        '		strUOPEID = DB_SOUMTA.UOPEID '最終作業者コード（バッチ）
        '		strUCLTID = DB_SOUMTA.UCLTID 'クライアントＩＤ（バッチ）
        '		' === 20080829 === INSERT E - RISE)Izumi
        '		strWRTDT = DB_SOUMTA.WRTDT '更新日付
        '		strWRTTM = DB_SOUMTA.WRTTM '更新時刻
        '		strUWRTDT = DB_SOUMTA.UWRTDT 'バッチ更新日付
        '		strUWRTTM = DB_SOUMTA.UWRTTM 'バッチ更新時刻

        '		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		updkb = RD_SSSMAIN_UPDKB(I)
        '		If updkb = "削除" Then

        '			'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-63
        '			HaitaUpdFlg = 0
        '			strSQL = ""
        '			' === 20080829 === UPDATE S - RISE)Izumi チェック項目追加
        '			'                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM SOUMTA"
        '			strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM SOUMTA"
        '			' === 20080829 === UPDATE E - RISE)Izumi
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			strSQL = strSQL & " WHERE SOUCD = '" + RD_SSSMAIN_SOUCD(I) + "'"
        '			'ロックする
        '			strSQL = strSQL & "          FOR UPDATE"
        '			Call DB_GetSQL2(DBN_SOUMTA, strSQL)
        '			' === 20080829 === INSERT S - RISE)Izumi チェック項目追加
        '			strOPEID = DB_SOUMTA.OPEID '最終作業者コード
        '			strCLTID = DB_SOUMTA.CLTID 'クライアントＩＤ
        '			strUOPEID = DB_SOUMTA.UOPEID '最終作業者コード（バッチ）
        '			strUCLTID = DB_SOUMTA.UCLTID 'クライアントＩＤ（バッチ）
        '			' === 20080829 === INSERT E - RISE)Izumi
        '			strWRTDT = DB_SOUMTA.WRTDT '更新日付
        '			strWRTTM = DB_SOUMTA.WRTTM '更新時刻
        '                  strUWRTDT = DB_SOUMTA.UWRTDT 'バッチ更新日付
        '                  strUWRTTM = DB_SOUMTA.UWRTTM 'バッチ更新時刻
        '			'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-63

        '			'更新時間チェック
        '			' === 20080829 === UPDATE S - RISE)Izumi チェック項目追加
        '			'                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
        '			bolRet = SOUMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
        '			' === 20080829 === UPDATE E - RISE)Izumi
        '			If bolRet = False Then
        '				intRet = MF_DspMsg(gc_strMsgSOUMT51_E_DEL)
        '				'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-63
        '				Call DB_Unlock(DBN_SOUMTA)
        '				Call DB_AbortTransaction()
        '				HaitaUpdFlg = 1
        '				'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-63
        '				Exit Sub
        '			End If

        '		Else
        '			'2007/12/18 upd-str T.KAWAMUKAI
        '			If updkb = "追加" Then
        '				intRet = MF_DspMsg(gc_strMsgSOUMT51_E_UPD)
        '				'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-63
        '				Call DB_Unlock(DBN_SOUMTA)
        '				Call DB_AbortTransaction()
        '				'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-63
        '				'2007/12/21 add-str T.KAWAMUKAI
        '				Exit Sub
        '				'2007/12/21 add-end T.KAWAMUKAI
        '			Else
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SALPAL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SALPALKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_HIKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HIKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUKOK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUKOKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUTRI() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUTRICD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SISNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SISNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SRSCNK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SRSCNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUBSC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUBSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUFX() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUFX() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUTL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUTL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUADC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUADC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUADB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUADB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUADA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUADA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUZP() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUZP() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '				If Trim(RD_SSSMAIN_SOUNM(I)) <> Trim(RD_SSSMAIN_V_SOUNM(I)) Or Trim(RD_SSSMAIN_SOUZP(I)) <> Trim(RD_SSSMAIN_V_SOUZP(I)) Or Trim(RD_SSSMAIN_SOUADA(I)) <> Trim(RD_SSSMAIN_V_SOUADA(I)) Or Trim(RD_SSSMAIN_SOUADB(I)) <> Trim(RD_SSSMAIN_V_SOUADB(I)) Or Trim(RD_SSSMAIN_SOUADC(I)) <> Trim(RD_SSSMAIN_V_SOUADC(I)) Or Trim(RD_SSSMAIN_SOUTL(I)) <> Trim(RD_SSSMAIN_V_SOUTL(I)) Or Trim(RD_SSSMAIN_SOUFX(I)) <> Trim(RD_SSSMAIN_V_SOUFX(I)) Or Trim(RD_SSSMAIN_SOUBSCD(I)) <> Trim(RD_SSSMAIN_V_SOUBSC(I)) Or Trim(RD_SSSMAIN_SOUKB(I)) <> Trim(RD_SSSMAIN_V_SOUKB(I)) Or Trim(RD_SSSMAIN_SRSCNKB(I)) <> Trim(RD_SSSMAIN_V_SRSCNK(I)) Or Trim(RD_SSSMAIN_SISNKB(I)) <> Trim(RD_SSSMAIN_V_SISNKB(I)) Or Trim(RD_SSSMAIN_SOUTRICD(I)) <> Trim(RD_SSSMAIN_V_SOUTRI(I)) Or Trim(RD_SSSMAIN_SOUKOKB(I)) <> Trim(RD_SSSMAIN_V_SOUKOK(I)) Or Trim(RD_SSSMAIN_HIKKB(I)) <> Trim(RD_SSSMAIN_V_HIKKB(I)) Or Trim(RD_SSSMAIN_SALPALKB(I)) <> Trim(RD_SSSMAIN_V_SALPAL(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then

        '					'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-63
        '					HaitaUpdFlg = 0
        '					strSQL = ""
        '					' === 20080829 === UPDATE S - RISE)Izumi チェック項目追加
        '					'                       strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM SOUMTA"
        '					strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM SOUMTA"
        '					' === 20080829 === UPDATE E - RISE)Izumi                       strSQL = strSQL + " WHERE SOUCD = '" + RD_SSSMAIN_SOUCD(I) + "'"
        '					strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM SOUMTA"
        '					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '					strSQL = strSQL & " WHERE SOUCD = '" + RD_SSSMAIN_SOUCD(I) + "'"
        '					'ロックする
        '					strSQL = strSQL & "          FOR UPDATE"
        '					Call DB_GetSQL2(DBN_SOUMTA, strSQL)
        '					' === 20080829 === INSERT S - RISE)Izumi チェック項目追加
        '					strOPEID = DB_SOUMTA.OPEID '最終作業者コード
        '					strCLTID = DB_SOUMTA.CLTID 'クライアントＩＤ
        '					strUOPEID = DB_SOUMTA.UOPEID '最終作業者コード（バッチ）
        '					strUCLTID = DB_SOUMTA.UCLTID 'クライアントＩＤ（バッチ）
        '					' === 20080829 === INSERT E - RISE)Izumi
        '					strWRTDT = DB_SOUMTA.WRTDT '更新日付
        '					strWRTTM = DB_SOUMTA.WRTTM '更新時刻
        '					strUWRTDT = DB_SOUMTA.UWRTDT 'バッチ更新日付
        '					strUWRTTM = DB_SOUMTA.UWRTTM 'バッチ更新時刻
        '					'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-63

        '					'更新時間チェック
        '					' === 20080901 === UPDATE S - RISE)Izumi チェック項目追加
        '					'                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
        '					bolRet = SOUMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
        '					' === 20080901 === UPDATE E - RISE)Izumi
        '					If bolRet = False Then
        '						intRet = MF_DspMsg(gc_strMsgSOUMT51_E_UPD)
        '						'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-63
        '						Call DB_Unlock(DBN_SOUMTA)
        '						Call DB_AbortTransaction()
        '						HaitaUpdFlg = 1
        '						'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-63
        '						Exit Sub
        '					End If
        '				End If
        '			End If
        '			'2007/12/18 upd-end T.KAWAMUKAI
        '		End If
        '	End If
        '	I = I + 1
        'Loop 
        Do While I < PP_SSSMAIN.LastDe
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            DB_SOUMTA2.SOUCD = RD_SSSMAIN_SOUCD(I)
            Call DB_GetEq(DBN_SOUMTA, 1, DB_SOUMTA2.SOUCD, BtrNormal)
            If DBSTAT = 0 Then
                ' === 20080829 === INSERT S - RISE)Izumi チェック項目追加
                strOPEID = DB_SOUMTA2.OPEID '最終作業者コード
                strCLTID = DB_SOUMTA2.CLTID 'クライアントＩＤ
                strUOPEID = DB_SOUMTA2.UOPEID '最終作業者コード（バッチ）
                strUCLTID = DB_SOUMTA2.UCLTID 'クライアントＩＤ（バッチ）
                ' === 20080829 === INSERT E - RISE)Izumi
                strWRTDT = DB_SOUMTA2.WRTDT '更新日付
                strWRTTM = DB_SOUMTA2.WRTTM '更新時刻
                strUWRTDT = DB_SOUMTA2.UWRTDT 'バッチ更新日付
                strUWRTTM = DB_SOUMTA2.UWRTTM 'バッチ更新時刻

                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                updkb = RD_SSSMAIN_UPDKB(I)
                If updkb = "削除" Then

                    '2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-63
                    HaitaUpdFlg = 0
                    strSQL = ""
                    ' === 20080829 === UPDATE S - RISE)Izumi チェック項目追加
                    '                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM SOUMTA"
                    strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM SOUMTA"
                    ' === 20080829 === UPDATE E - RISE)Izumi
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    strSQL = strSQL & " WHERE SOUCD = '" + RD_SSSMAIN_SOUCD(I) + "'"
                    'ロックする
                    strSQL = strSQL & "          FOR UPDATE"
                    Call DB_GetSQL2(DBN_SOUMTA, strSQL)
                    ' === 20080829 === INSERT S - RISE)Izumi チェック項目追加
                    strOPEID = DB_SOUMTA2.OPEID '最終作業者コード
                    strCLTID = DB_SOUMTA2.CLTID 'クライアントＩＤ
                    strUOPEID = DB_SOUMTA2.UOPEID '最終作業者コード（バッチ）
                    strUCLTID = DB_SOUMTA2.UCLTID 'クライアントＩＤ（バッチ）
                    ' === 20080829 === INSERT E - RISE)Izumi
                    strWRTDT = DB_SOUMTA2.WRTDT '更新日付
                    strWRTTM = DB_SOUMTA2.WRTTM '更新時刻
                    strUWRTDT = DB_SOUMTA2.UWRTDT 'バッチ更新日付
                    strUWRTTM = DB_SOUMTA2.UWRTTM 'バッチ更新時刻
                    '2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-63

                    '更新時間チェック
                    ' === 20080829 === UPDATE S - RISE)Izumi チェック項目追加
                    '                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
                    bolRet = SOUMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
                    ' === 20080829 === UPDATE E - RISE)Izumi
                    If bolRet = False Then
                        intRet = MF_DspMsg(gc_strMsgSOUMT51_E_DEL)
                        '2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-63
                        Call DB_Unlock(DBN_SOUMTA)
                        Call DB_AbortTransaction()
                        HaitaUpdFlg = 1
                        '2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-63
                        Exit Sub
                    End If

                Else
                    '2007/12/18 upd-str T.KAWAMUKAI
                    If updkb = "追加" Then
                        intRet = MF_DspMsg(gc_strMsgSOUMT51_E_UPD)
                        '2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-63
                        Call DB_Unlock(DBN_SOUMTA)
                        Call DB_AbortTransaction()
                        '2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-63
                        '2007/12/21 add-str T.KAWAMUKAI
                        Exit Sub
                        '2007/12/21 add-end T.KAWAMUKAI
                    Else
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SALPAL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SALPALKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_HIKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HIKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUKOK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUKOKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUTRI() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUTRICD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SISNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SISNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SRSCNK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SRSCNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUBSC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUBSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUFX() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUFX() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUTL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUTL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUADC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUADC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUADB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUADB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUADA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUADA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUZP() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUZP() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        If Trim(RD_SSSMAIN_SOUNM(I)) <> Trim(RD_SSSMAIN_V_SOUNM(I)) Or Trim(RD_SSSMAIN_SOUZP(I)) <> Trim(RD_SSSMAIN_V_SOUZP(I)) Or Trim(RD_SSSMAIN_SOUADA(I)) <> Trim(RD_SSSMAIN_V_SOUADA(I)) Or Trim(RD_SSSMAIN_SOUADB(I)) <> Trim(RD_SSSMAIN_V_SOUADB(I)) Or Trim(RD_SSSMAIN_SOUADC(I)) <> Trim(RD_SSSMAIN_V_SOUADC(I)) Or Trim(RD_SSSMAIN_SOUTL(I)) <> Trim(RD_SSSMAIN_V_SOUTL(I)) Or Trim(RD_SSSMAIN_SOUFX(I)) <> Trim(RD_SSSMAIN_V_SOUFX(I)) Or Trim(RD_SSSMAIN_SOUBSCD(I)) <> Trim(RD_SSSMAIN_V_SOUBSC(I)) Or Trim(RD_SSSMAIN_SOUKB(I)) <> Trim(RD_SSSMAIN_V_SOUKB(I)) Or Trim(RD_SSSMAIN_SRSCNKB(I)) <> Trim(RD_SSSMAIN_V_SRSCNK(I)) Or Trim(RD_SSSMAIN_SISNKB(I)) <> Trim(RD_SSSMAIN_V_SISNKB(I)) Or Trim(RD_SSSMAIN_SOUTRICD(I)) <> Trim(RD_SSSMAIN_V_SOUTRI(I)) Or Trim(RD_SSSMAIN_SOUKOKB(I)) <> Trim(RD_SSSMAIN_V_SOUKOK(I)) Or Trim(RD_SSSMAIN_HIKKB(I)) <> Trim(RD_SSSMAIN_V_HIKKB(I)) Or Trim(RD_SSSMAIN_SALPALKB(I)) <> Trim(RD_SSSMAIN_V_SALPAL(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then

                            '2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-63
                            HaitaUpdFlg = 0
                            strSQL = ""
                            ' === 20080829 === UPDATE S - RISE)Izumi チェック項目追加
                            '                       strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM SOUMTA"
                            strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM SOUMTA"
                            ' === 20080829 === UPDATE E - RISE)Izumi                       strSQL = strSQL + " WHERE SOUCD = '" + RD_SSSMAIN_SOUCD(I) + "'"
                            strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM SOUMTA"
                            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                            strSQL = strSQL & " WHERE SOUCD = '" + RD_SSSMAIN_SOUCD(I) + "'"
                            'ロックする
                            strSQL = strSQL & "          FOR UPDATE"
                            Call DB_GetSQL2(DBN_SOUMTA, strSQL)
                            ' === 20080829 === INSERT S - RISE)Izumi チェック項目追加
                            strOPEID = DB_SOUMTA2.OPEID '最終作業者コード
                            strCLTID = DB_SOUMTA2.CLTID 'クライアントＩＤ
                            strUOPEID = DB_SOUMTA2.UOPEID '最終作業者コード（バッチ）
                            strUCLTID = DB_SOUMTA2.UCLTID 'クライアントＩＤ（バッチ）
                            ' === 20080829 === INSERT E - RISE)Izumi
                            strWRTDT = DB_SOUMTA2.WRTDT '更新日付
                            strWRTTM = DB_SOUMTA2.WRTTM '更新時刻
                            strUWRTDT = DB_SOUMTA2.UWRTDT 'バッチ更新日付
                            strUWRTTM = DB_SOUMTA2.UWRTTM 'バッチ更新時刻
                            '2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-63

                            '更新時間チェック
                            ' === 20080901 === UPDATE S - RISE)Izumi チェック項目追加
                            '                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
                            bolRet = SOUMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
                            ' === 20080901 === UPDATE E - RISE)Izumi
                            If bolRet = False Then
                                intRet = MF_DspMsg(gc_strMsgSOUMT51_E_UPD)
                                '2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-63
                                Call DB_Unlock(DBN_SOUMTA)
                                Call DB_AbortTransaction()
                                HaitaUpdFlg = 1
                                '2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-63
                                Exit Sub
                            End If
                        End If
                    End If
                    '2007/12/18 upd-end T.KAWAMUKAI
                End If
            End If
            I = I + 1
        Loop
        '20190819 CHG END
        '2007/12/14 add-end T.KAWAMUKAI

        '
        I = 0
		WRTTM = VB6.Format(Now, "hhmmss")
		WRTDT = VB6.Format(Now, "YYYYMMDD")

        '2008/07/11 START DEL FNAP)YAMANE 連絡票№：排他-63
        '上部のチェックのループの開始時に宣言するように変更
        '    Call DB_BeginTransaction(BTR_Exclude)
        '2008/07/11 E.N.D DEL FNAP)YAMANE 連絡票№：排他-63
        '20190819 CHG START
        '      Do While I < PP_SSSMAIN.LastDe
        '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '	DB_SOUMTA.SOUCD = RD_SSSMAIN_SOUCD(I)
        '	Call DB_GetEq(DBN_SOUMTA, 1, DB_SOUMTA.SOUCD, BtrLock)
        '	If DBSTAT = 0 Then
        '		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '		updkb = RD_SSSMAIN_UPDKB(I)
        '		If updkb = "削除" Then
        '			DB_SOUMTA.DATKB = "9"
        '			DB_SOUMTA.RELFL = "1"
        '			DB_SOUMTA.OPEID = SSS_OPEID.Value
        '			DB_SOUMTA.CLTID = SSS_CLTID.Value
        '			DB_SOUMTA.WRTTM = WRTTM
        '			DB_SOUMTA.WRTDT = WRTDT
        '                  DB_SOUMTA.UOPEID = SSS_OPEID.Value
        '                  DB_SOUMTA.UCLTID = SSS_CLTID.Value
        '			DB_SOUMTA.UWRTTM = WRTTM
        '			DB_SOUMTA.UWRTDT = WRTDT
        '			DB_SOUMTA.PGID = SSS_PrgId
        '			Call DB_Update(DBN_SOUMTA, 1)
        '		Else
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SALPAL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SALPALKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_HIKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HIKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUKOK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUKOKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUTRI() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUTRICD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SISNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SISNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SRSCNK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SRSCNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUBSC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUBSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUFX() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUFX() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUTL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUTL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUADC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUADC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUADB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUADB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUADA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUADA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUZP() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUZP() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '			If Trim(RD_SSSMAIN_SOUNM(I)) <> Trim(RD_SSSMAIN_V_SOUNM(I)) Or Trim(RD_SSSMAIN_SOUZP(I)) <> Trim(RD_SSSMAIN_V_SOUZP(I)) Or Trim(RD_SSSMAIN_SOUADA(I)) <> Trim(RD_SSSMAIN_V_SOUADA(I)) Or Trim(RD_SSSMAIN_SOUADB(I)) <> Trim(RD_SSSMAIN_V_SOUADB(I)) Or Trim(RD_SSSMAIN_SOUADC(I)) <> Trim(RD_SSSMAIN_V_SOUADC(I)) Or Trim(RD_SSSMAIN_SOUTL(I)) <> Trim(RD_SSSMAIN_V_SOUTL(I)) Or Trim(RD_SSSMAIN_SOUFX(I)) <> Trim(RD_SSSMAIN_V_SOUFX(I)) Or Trim(RD_SSSMAIN_SOUBSCD(I)) <> Trim(RD_SSSMAIN_V_SOUBSC(I)) Or Trim(RD_SSSMAIN_SOUKB(I)) <> Trim(RD_SSSMAIN_V_SOUKB(I)) Or Trim(RD_SSSMAIN_SRSCNKB(I)) <> Trim(RD_SSSMAIN_V_SRSCNK(I)) Or Trim(RD_SSSMAIN_SISNKB(I)) <> Trim(RD_SSSMAIN_V_SISNKB(I)) Or Trim(RD_SSSMAIN_SOUTRICD(I)) <> Trim(RD_SSSMAIN_V_SOUTRI(I)) Or Trim(RD_SSSMAIN_SOUKOKB(I)) <> Trim(RD_SSSMAIN_V_SOUKOK(I)) Or Trim(RD_SSSMAIN_HIKKB(I)) <> Trim(RD_SSSMAIN_V_HIKKB(I)) Or Trim(RD_SSSMAIN_SALPALKB(I)) <> Trim(RD_SSSMAIN_V_SALPAL(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
        '				Call Mfil_FromSCR(I)
        '				DB_SOUMTA.DATKB = "1"
        '				DB_SOUMTA.RELFL = "1"
        '				DB_SOUMTA.WRTTM = WRTTM
        '				DB_SOUMTA.WRTDT = WRTDT
        '				DB_SOUMTA.UOPEID = SSS_OPEID.Value
        '				DB_SOUMTA.UCLTID = SSS_CLTID.Value
        '				DB_SOUMTA.UWRTTM = WRTTM
        '				DB_SOUMTA.UWRTDT = WRTDT
        '				DB_SOUMTA.PGID = SSS_PrgId
        '				Call DB_Update(DBN_SOUMTA, 1)
        '			End If '2006.11.07
        '		End If
        '	Else
        '		Call SOUMTA_RClear()
        '		Call Mfil_FromSCR(I)
        '		DB_SOUMTA.DATKB = "1"
        '		DB_SOUMTA.RELFL = "1"
        '		DB_SOUMTA.FOPEID = SSS_OPEID.Value
        '		DB_SOUMTA.FCLTID = SSS_CLTID.Value
        '		DB_SOUMTA.WRTFSTTM = WRTTM
        '		DB_SOUMTA.WRTFSTDT = WRTDT
        '		DB_SOUMTA.WRTTM = WRTTM
        '		DB_SOUMTA.WRTDT = WRTDT
        '		DB_SOUMTA.UOPEID = SSS_OPEID.Value
        '		DB_SOUMTA.UCLTID = SSS_CLTID.Value
        '		DB_SOUMTA.UWRTTM = WRTTM
        '		DB_SOUMTA.UWRTDT = WRTDT
        '		DB_SOUMTA.PGID = SSS_PrgId
        '		Call DB_Insert(DBN_SOUMTA, 1)
        '	End If
        '	I = I + 1
        'Loop 
        Do While I < PP_SSSMAIN.LastDe
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            DB_SOUMTA2.SOUCD = RD_SSSMAIN_SOUCD(I)
            Call DB_GetEq(DBN_SOUMTA, 1, DB_SOUMTA2.SOUCD, BtrLock)
            If DBSTAT = 0 Then
                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                updkb = RD_SSSMAIN_UPDKB(I)
                If updkb = "削除" Then
                    DB_SOUMTA2.DATKB = "9"
                    DB_SOUMTA2.RELFL = "1"
                    DB_SOUMTA2.OPEID = SSS_OPEID.Value
                    DB_SOUMTA2.CLTID = SSS_CLTID.Value
                    DB_SOUMTA2.WRTTM = WRTTM
                    DB_SOUMTA2.WRTDT = WRTDT
                    DB_SOUMTA2.UOPEID = SSS_OPEID.Value
                    DB_SOUMTA2.UCLTID = SSS_CLTID.Value
                    DB_SOUMTA2.UWRTTM = WRTTM
                    DB_SOUMTA2.UWRTDT = WRTDT
                    DB_SOUMTA2.PGID = SSS_PrgId
                    Call DB_Update(DBN_SOUMTA, 1)
                Else
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SALPAL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SALPALKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_HIKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HIKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUKOK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUKOKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUTRI() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUTRICD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SISNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SISNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SRSCNK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SRSCNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUBSC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUBSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUFX() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUFX() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUTL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUTL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUADC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUADC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUADB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUADB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUADA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUADA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUZP() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUZP() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_SOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If Trim(RD_SSSMAIN_SOUNM(I)) <> Trim(RD_SSSMAIN_V_SOUNM(I)) Or Trim(RD_SSSMAIN_SOUZP(I)) <> Trim(RD_SSSMAIN_V_SOUZP(I)) Or Trim(RD_SSSMAIN_SOUADA(I)) <> Trim(RD_SSSMAIN_V_SOUADA(I)) Or Trim(RD_SSSMAIN_SOUADB(I)) <> Trim(RD_SSSMAIN_V_SOUADB(I)) Or Trim(RD_SSSMAIN_SOUADC(I)) <> Trim(RD_SSSMAIN_V_SOUADC(I)) Or Trim(RD_SSSMAIN_SOUTL(I)) <> Trim(RD_SSSMAIN_V_SOUTL(I)) Or Trim(RD_SSSMAIN_SOUFX(I)) <> Trim(RD_SSSMAIN_V_SOUFX(I)) Or Trim(RD_SSSMAIN_SOUBSCD(I)) <> Trim(RD_SSSMAIN_V_SOUBSC(I)) Or Trim(RD_SSSMAIN_SOUKB(I)) <> Trim(RD_SSSMAIN_V_SOUKB(I)) Or Trim(RD_SSSMAIN_SRSCNKB(I)) <> Trim(RD_SSSMAIN_V_SRSCNK(I)) Or Trim(RD_SSSMAIN_SISNKB(I)) <> Trim(RD_SSSMAIN_V_SISNKB(I)) Or Trim(RD_SSSMAIN_SOUTRICD(I)) <> Trim(RD_SSSMAIN_V_SOUTRI(I)) Or Trim(RD_SSSMAIN_SOUKOKB(I)) <> Trim(RD_SSSMAIN_V_SOUKOK(I)) Or Trim(RD_SSSMAIN_HIKKB(I)) <> Trim(RD_SSSMAIN_V_HIKKB(I)) Or Trim(RD_SSSMAIN_SALPALKB(I)) <> Trim(RD_SSSMAIN_V_SALPAL(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
                        Call Mfil_FromSCR(I)
                        DB_SOUMTA2.DATKB = "1"
                        DB_SOUMTA2.RELFL = "1"
                        DB_SOUMTA2.WRTTM = WRTTM
                        DB_SOUMTA2.WRTDT = WRTDT
                        DB_SOUMTA2.UOPEID = SSS_OPEID.Value
                        DB_SOUMTA2.UCLTID = SSS_CLTID.Value
                        DB_SOUMTA2.UWRTTM = WRTTM
                        DB_SOUMTA2.UWRTDT = WRTDT
                        DB_SOUMTA2.PGID = SSS_PrgId
                        Call DB_Update(DBN_SOUMTA, 1)
                    End If '2006.11.07
                End If
            Else
                Call SOUMTA_RClear()
                Call Mfil_FromSCR(I)
                DB_SOUMTA2.DATKB = "1"
                DB_SOUMTA2.RELFL = "1"
                DB_SOUMTA2.FOPEID = SSS_OPEID.Value
                DB_SOUMTA2.FCLTID = SSS_CLTID.Value
                DB_SOUMTA2.WRTFSTTM = WRTTM
                DB_SOUMTA2.WRTFSTDT = WRTDT
                DB_SOUMTA2.WRTTM = WRTTM
                DB_SOUMTA2.WRTDT = WRTDT
                DB_SOUMTA2.UOPEID = SSS_OPEID.Value
                DB_SOUMTA2.UCLTID = SSS_CLTID.Value
                DB_SOUMTA2.UWRTTM = WRTTM
                DB_SOUMTA2.UWRTDT = WRTDT
                DB_SOUMTA2.PGID = SSS_PrgId
                Call DB_Insert(DBN_SOUMTA, 1)
            End If
            I = I + 1
        Loop
        '20190819 CHG END
        Call DB_Unlock(DBN_SOUMTA)
		Call DB_EndTransaction()
	End Sub
	
	' === 20080901 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SOUMT51_MF_Chk_UWRTDTTM_T
	'   概要：  更新時間チェック処理
	'   引数：  pin_strOPEID    : 最終作業者コード
	'           pin_strCLTID    : クライアントＩＤ
	'           pin_strUOPEID   : 最終作業者コード（バッチ）
	'           pin_strUCLTID   : クライアントＩＤ（バッチ）
	'           pin_strWRTDT    : 更新日付
	'           pin_strWRTTM    : 更新時刻
	'           pin_strUWRTDT   : バッチ更新日付
	'           pin_strUWRTTM   : バッチ更新時刻
	'           pin_intIDX      : 多明細の場合　　　　明細行（0～）
	'   　　　　　　　　　　　　　得意先Ｍ登録の場合　0…得意先 1…仕入先
	'   戻値：　True：チェックOK　False：チェックNG
	'   備考：  多明細及び、得意先Ｍ登録用
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function SOUMT51_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo SOUMT51_MF_Chk_UWRTDTTM_T_err
		
		SOUMT51_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_SOUMT_A_inf(pin_intIDX).OPEID) & Trim(M_SOUMT_A_inf(pin_intIDX).CLTID) & Trim(M_SOUMT_A_inf(pin_intIDX).UOPEID) & Trim(M_SOUMT_A_inf(pin_intIDX).UCLTID) & Trim(M_SOUMT_A_inf(pin_intIDX).WRTDT) & Trim(M_SOUMT_A_inf(pin_intIDX).WRTTM) & Trim(M_SOUMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_SOUMT_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then
			
			'更新時間チェック
			If Trim(pin_strOPEID) & Trim(pin_strCLTID) & Trim(pin_strUOPEID) & Trim(pin_strUCLTID) & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_SOUMT_A_inf(pin_intIDX).OPEID) & Trim(M_SOUMT_A_inf(pin_intIDX).CLTID) & Trim(M_SOUMT_A_inf(pin_intIDX).UOPEID) & Trim(M_SOUMT_A_inf(pin_intIDX).UCLTID) & Trim(M_SOUMT_A_inf(pin_intIDX).WRTDT) & Trim(M_SOUMT_A_inf(pin_intIDX).WRTTM) & Trim(M_SOUMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_SOUMT_A_inf(pin_intIDX).UWRTTM) Then
				GoTo SOUMT51_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		SOUMT51_MF_Chk_UWRTDTTM_T = True
		
SOUMT51_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
SOUMT51_MF_Chk_UWRTDTTM_T_err: 
		GoTo SOUMT51_MF_Chk_UWRTDTTM_T_End
		
	End Function
	' === 20080901 === INSERT E - RISE)Izumi
	
	' === 20080901 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SOUMT51_MF_UpDown_UWRTDTTM
	'   概要：  明細　削除・挿入処理
	'   引数：  pin_intIDX      : 対象行
	'           pin_intGYO      : 1…削除（行詰め）　-1…挿入（行下げ）
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function SOUMT51_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo SOUMT51_MF_UpDown_UWRTDTTM_err
		
		SOUMT51_MF_UpDown_UWRTDTTM = False
		
		'更新時間　配列移動
		M_SOUMT_A_inf(pin_intIDX).OPEID = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_SOUMT_A_inf(pin_intIDX).CLTID = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_SOUMT_A_inf(pin_intIDX).UOPEID = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UOPEID
		M_SOUMT_A_inf(pin_intIDX).UCLTID = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UCLTID
		M_SOUMT_A_inf(pin_intIDX).WRTDT = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_SOUMT_A_inf(pin_intIDX).WRTTM = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_SOUMT_A_inf(pin_intIDX).UWRTDT = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_SOUMT_A_inf(pin_intIDX).UWRTTM = M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UOPEID = ""
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UCLTID = ""
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_SOUMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		SOUMT51_MF_UpDown_UWRTDTTM = True
		
SOUMT51_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
SOUMT51_MF_UpDown_UWRTDTTM_err: 
		GoTo SOUMT51_MF_UpDown_UWRTDTTM_End
		
	End Function
	' === 20080901 === INSERT E - RISE)Izumi
	
	' === 20080901 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SOUMT51_MF_SaveRestore_UWRTDTTM
	'   概要：  明細　退避・復元処理
	'   引数：  pin_intIDX      : 対象行
	'           pin_intKBN      : 0…退避　1…復元
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function SOUMT51_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo SOUMT51_MF_SaveRestore_UWRTDTTM_err
		
		SOUMT51_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			'退避・復元処理
			M_SOUMT_inf.OPEID = M_SOUMT_A_inf(pin_intIDX).OPEID
			M_SOUMT_inf.CLTID = M_SOUMT_A_inf(pin_intIDX).CLTID
			M_SOUMT_inf.UOPEID = M_SOUMT_A_inf(pin_intIDX).UOPEID
			M_SOUMT_inf.UCLTID = M_SOUMT_A_inf(pin_intIDX).UCLTID
			M_SOUMT_inf.WRTDT = M_SOUMT_A_inf(pin_intIDX).WRTDT
			M_SOUMT_inf.WRTTM = M_SOUMT_A_inf(pin_intIDX).WRTTM
			M_SOUMT_inf.UWRTDT = M_SOUMT_A_inf(pin_intIDX).UWRTDT
			M_SOUMT_inf.UWRTTM = M_SOUMT_A_inf(pin_intIDX).UWRTTM
		Else
			'復元処理
			M_SOUMT_A_inf(pin_intIDX).OPEID = M_SOUMT_inf.OPEID
			M_SOUMT_A_inf(pin_intIDX).CLTID = M_SOUMT_inf.CLTID
			M_SOUMT_A_inf(pin_intIDX).UOPEID = M_SOUMT_inf.UOPEID
			M_SOUMT_A_inf(pin_intIDX).UCLTID = M_SOUMT_inf.UCLTID
			M_SOUMT_A_inf(pin_intIDX).WRTDT = M_SOUMT_inf.WRTDT
			M_SOUMT_A_inf(pin_intIDX).WRTTM = M_SOUMT_inf.WRTTM
			M_SOUMT_A_inf(pin_intIDX).UWRTDT = M_SOUMT_inf.UWRTDT
			M_SOUMT_A_inf(pin_intIDX).UWRTTM = M_SOUMT_inf.UWRTTM
		End If
		
		SOUMT51_MF_SaveRestore_UWRTDTTM = True
		
SOUMT51_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
SOUMT51_MF_SaveRestore_UWRTDTTM_err: 
		GoTo SOUMT51_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	' === 20080901 === INSERT E - RISE)Izumi
	
	' === 20080901 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function SOUMT51_MF_Clear_UWRTDTTM
	'   概要：  明細　対象行クリア処理
	'   引数：  pin_intIDX      : 対象行
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function SOUMT51_MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo SOUMT51_MF_Clear_UWRTDTTM_err
		
		SOUMT51_MF_Clear_UWRTDTTM = False
		'更新時間　配列クリア
		M_SOUMT_A_inf(pin_intIDX).OPEID = ""
		M_SOUMT_A_inf(pin_intIDX).CLTID = ""
		M_SOUMT_A_inf(pin_intIDX).UOPEID = ""
		M_SOUMT_A_inf(pin_intIDX).UCLTID = ""
		M_SOUMT_A_inf(pin_intIDX).WRTDT = ""
		M_SOUMT_A_inf(pin_intIDX).WRTTM = ""
		M_SOUMT_A_inf(pin_intIDX).UWRTDT = ""
		M_SOUMT_A_inf(pin_intIDX).UWRTTM = ""
		
		SOUMT51_MF_Clear_UWRTDTTM = True
		
SOUMT51_MF_Clear_UWRTDTTM_End: 
		Exit Function
		
SOUMT51_MF_Clear_UWRTDTTM_err: 
		GoTo SOUMT51_MF_Clear_UWRTDTTM_End
		
	End Function
	' === 20080901 === INSERT E - RISE)Izumi
End Module