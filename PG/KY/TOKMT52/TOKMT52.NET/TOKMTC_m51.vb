Option Strict Off
Option Explicit On
Module TOKMTC_M51
	'
	' スロット名        : 販売単価マスタ・メインファイル更新スロット
	' ユニット名        : TOKMTC.M51
	' 記述者            : Standard Library
	' 作成日付          : 2006/06/20
	' 使用プログラム名  : TOKMT54
	'
	
	' === 20080903 === INSERT S - RISE)Izumi
	'更新時刻、更新日付、バッチ更新時刻、バッチ更新日付　退避用
	Structure M_TYPE_TOKMT
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
	Public M_TOKMT_inf As M_TYPE_TOKMT
	Public M_TOKMT_A_inf() As M_TYPE_TOKMT
	' === 20080903 === INSERT E - RISE)Izumi
	
	Sub UPDMST()
		Dim I, J As Short
		Dim wkWRTTM, updkb, wkWRTDT As String
		
		'2007/12/14 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		Dim bolRet As Boolean
		Dim intRet As Short
		
		' === 20080903 === INSERT S - RISE)Izumi
		Dim strOPEID As String '最終作業者コード
		Dim strCLTID As String 'クライアントＩＤ
		Dim strUOPEID As String '最終作業者コード（バッチ）
		Dim strUCLTID As String 'クライアントＩＤ（バッチ）
		' === 20080903 === INSERT E - RISE)Izumi
		Dim strWRTDT As String '更新日付
		Dim strWRTTM As String '更新時刻
		Dim strUWRTDT As String 'バッチ更新日付
		Dim strUWRTTM As String 'バッチ更新時刻
		'2007/12/14 add-end T.KAWAMUKAI
		
		wkWRTTM = VB6.Format(Now, "hhmmss")
		wkWRTDT = VB6.Format(Now, "YYYYMMDD")
		
		'更新権限チェック
		If gs_UPDAUTH = "9" Then
			Call MsgBox("更新権限がありません。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			Exit Sub
		End If
		
		'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-67
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-67
		
		'2007/12/14 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		'更新時間チェック（画面に表示されている明細分）
		I = 0
		Dim strSQL As String
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMTC.TOKCD = RD_SSSMAIN_TOKCD(I)
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMTC.HINCD = RD_SSSMAIN_HINCD(I)
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URITKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMTC.URITKDT = RD_SSSMAIN_URITKDT(I)
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMTC.TUKKB = RD_SSSMAIN_TUKKB(I)
			Call DB_GetEq(DBN_TOKMTC, 1, DB_TOKMTC.HINCD & DB_TOKMTC.TOKCD & DB_TOKMTC.URITKDT & DB_TOKMTC.TUKKB, BtrNormal)
			If DBSTAT = 0 Then
				' === 20080903 === INSERT S - RISE)Izumi チェック項目追加
				strOPEID = DB_TOKMTC.OPEID '最終作業者コード
				strCLTID = DB_TOKMTC.CLTID 'クライアントＩＤ
				strUOPEID = DB_TOKMTC.UOPEID '最終作業者コード（バッチ）
				strUCLTID = DB_TOKMTC.UCLTID 'クライアントＩＤ（バッチ）
				' === 20080903 === INSERT E - RISE)Izumi
				strWRTDT = DB_TOKMTC.WRTDT '更新日付
				strWRTTM = DB_TOKMTC.WRTTM '更新時刻
				strUWRTDT = DB_TOKMTC.UWRTDT 'バッチ更新日付
				strUWRTTM = DB_TOKMTC.UWRTTM 'バッチ更新時刻
				
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "削除" Then
					
					'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-67
					HaitaUpdFlg = 0
					strSQL = ""
					' === 20080903 === UPDATE S - RISE)Izumi チェック項目追加
					'                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM TOKMTC"
					strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM TOKMTC"
					' === 20080903 === UPDATE E - RISE)Izumi
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strSQL = strSQL & " WHERE HINCD = '" + RD_SSSMAIN_HINCD(I) + "'"
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strSQL = strSQL & " AND TOKCD = '" + RD_SSSMAIN_TOKCD(I) + "'"
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URITKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strSQL = strSQL & " AND URITKDT = '" + RD_SSSMAIN_URITKDT(I) + "'"
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strSQL = strSQL & " AND TUKKB = '" + RD_SSSMAIN_TUKKB(I) + "'"
					'ロックする
					strSQL = strSQL & "          FOR UPDATE"
					Call DB_GetSQL2(DBN_TOKMTC, strSQL)
					' === 20080903 === INSERT S - RISE)Izumi チェック項目追加
					strOPEID = DB_TOKMTC.OPEID '最終作業者コード
					strCLTID = DB_TOKMTC.CLTID 'クライアントＩＤ
					strUOPEID = DB_TOKMTC.UOPEID '最終作業者コード（バッチ）
					strUCLTID = DB_TOKMTC.UCLTID 'クライアントＩＤ（バッチ）
					' === 20080903 === INSERT E - RISE)Izumi
					strWRTDT = DB_TOKMTC.WRTDT '更新日付
					strWRTTM = DB_TOKMTC.WRTTM '更新時刻
					strUWRTDT = DB_TOKMTC.UWRTDT 'バッチ更新日付
					strUWRTTM = DB_TOKMTC.UWRTTM 'バッチ更新時刻
					'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-67
					
					'更新時間チェック
					' === 20080903 === UPDATE S - RISE)Izumi チェック項目追加
					'                    bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					bolRet = TOKMT52_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					' === 20080903 === UPDATE E - RISE)Izumi
					If bolRet = False Then
						intRet = MF_DspMsg(gc_strMsgTOKMT52_E_DEL)
						'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-67
						Call DB_Unlock(DBN_TOKMTC)
						Call DB_AbortTransaction()
						HaitaUpdFlg = 1
						'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-67
						Exit Sub
					End If
					
				Else
					'2007/12/18 upd-str T.KAWAMUKAI
					If updkb = "追加" Then
						intRet = MF_DspMsg(gc_strMsgTOKMT52_E_UPD)
						'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-67
						Call DB_Unlock(DBN_TOKMTC)
						Call DB_AbortTransaction()
						'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-67
						'2007/12/21 add-str T.KAWAMUKAI
						Exit Sub
						'2007/12/21 add-end T.KAWAMUKAI
					Else
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_ULTTKK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ULTTKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_URITK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URITK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If Trim(RD_SSSMAIN_URITK(I)) <> Trim(RD_SSSMAIN_V_URITK(I)) Or Trim(RD_SSSMAIN_ULTTKKB(I)) <> Trim(RD_SSSMAIN_V_ULTTKK(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then
							
							'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-67
							HaitaUpdFlg = 0
							strSQL = ""
							' === 20080903 === UPDATE S - RISE)Izumi チェック項目追加
							'                       strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM TOKMTC"
							strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM TOKMTC"
							' === 20080903 === UPDATE E - RISE)Izumi
							'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							strSQL = strSQL & " WHERE HINCD = '" + RD_SSSMAIN_HINCD(I) + "'"
							'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							strSQL = strSQL & " AND TOKCD = '" + RD_SSSMAIN_TOKCD(I) + "'"
							'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URITKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							strSQL = strSQL & " AND URITKDT = '" + RD_SSSMAIN_URITKDT(I) + "'"
							'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							strSQL = strSQL & " AND TUKKB = '" + RD_SSSMAIN_TUKKB(I) + "'"
							'ロックする
							strSQL = strSQL & "          FOR UPDATE"
							Call DB_GetSQL2(DBN_TOKMTC, strSQL)
							' === 20080903 === INSERT S - RISE)Izumi チェック項目追加
							strOPEID = DB_TOKMTC.OPEID '最終作業者コード
							strCLTID = DB_TOKMTC.CLTID 'クライアントＩＤ
							strUOPEID = DB_TOKMTC.UOPEID '最終作業者コード（バッチ）
							strUCLTID = DB_TOKMTC.UCLTID 'クライアントＩＤ（バッチ）
							' === 20080903 === INSERT E - RISE)Izumi
							strWRTDT = DB_TOKMTC.WRTDT '更新日付
							strWRTTM = DB_TOKMTC.WRTTM '更新時刻
							strUWRTDT = DB_TOKMTC.UWRTDT 'バッチ更新日付
							strUWRTTM = DB_TOKMTC.UWRTTM 'バッチ更新時刻
							'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-67
							
							'更新時間チェック
							' === 20080903 === UPDATE S - RISE)Izumi チェック項目追加
							'                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
							bolRet = TOKMT52_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
							' === 20080903 === UPDATE E - RISE)Izumi
							If bolRet = False Then
								intRet = MF_DspMsg(gc_strMsgTOKMT52_E_UPD)
								'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-67
								Call DB_Unlock(DBN_TOKMTC)
								Call DB_AbortTransaction()
								HaitaUpdFlg = 1
								'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-67
								Exit Sub
							End If
						End If
					End If
					'2007/12/18 upd-end T.KAWAMUKAI
				End If
			End If
			I = I + 1
		Loop 
		'2007/12/14 add-end T.KAWAMUKAI
		
		'2008/07/11 START DEL FNAP)YAMANE 連絡票№：排他-67
		'上部のチェックのループの開始時に宣言するように変更
		'    Call DB_BeginTransaction(BTR_Exclude)
		'2008/07/11 E.N.D DEL FNAP)YAMANE 連絡票№：排他-67
		
		I = 0
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMTC.TOKCD = RD_SSSMAIN_TOKCD(I)
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMTC.HINCD = RD_SSSMAIN_HINCD(I)
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URITKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMTC.URITKDT = RD_SSSMAIN_URITKDT(I)
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TOKMTC.TUKKB = RD_SSSMAIN_TUKKB(I)
			Call DB_GetEq(DBN_TOKMTC, 1, DB_TOKMTC.HINCD & DB_TOKMTC.TOKCD & DB_TOKMTC.URITKDT & DB_TOKMTC.TUKKB, BtrLock)
			
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "削除" Then
					DB_TOKMTC.DATKB = "9"
					DB_TOKMTC.WRTTM = wkWRTTM
					DB_TOKMTC.WRTDT = wkWRTDT
					DB_TOKMTC.UOPEID = SSS_OPEID.Value
					DB_TOKMTC.UCLTID = SSS_CLTID.Value
					DB_TOKMTC.UWRTTM = wkWRTTM
					DB_TOKMTC.UWRTDT = wkWRTDT
					DB_TOKMTC.PGID = SSS_PrgId
					Call DB_Update(DBN_TOKMTC, 1)
				Else
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_ULTTKK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ULTTKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_URITK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URITK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Trim(RD_SSSMAIN_URITK(I)) <> Trim(RD_SSSMAIN_V_URITK(I)) Or Trim(RD_SSSMAIN_ULTTKKB(I)) <> Trim(RD_SSSMAIN_V_ULTTKK(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
						Call Mfil_FromSCR(I)
						DB_TOKMTC.DATKB = "1"
						DB_TOKMTC.WRTTM = wkWRTTM
						DB_TOKMTC.WRTDT = wkWRTDT
						DB_TOKMTC.UOPEID = SSS_OPEID.Value
						DB_TOKMTC.UCLTID = SSS_CLTID.Value
						DB_TOKMTC.UWRTTM = wkWRTTM
						DB_TOKMTC.UWRTDT = wkWRTDT
						DB_TOKMTC.PGID = SSS_PrgId
						Call DB_Update(DBN_TOKMTC, 1)
					End If '2006.11.07
				End If
			Else
				Call TOKMTC_RClear()
				Call Mfil_FromSCR(I)
				DB_TOKMTC.DATKB = "1"
				DB_TOKMTC.FOPEID = SSS_OPEID.Value
				DB_TOKMTC.FCLTID = SSS_CLTID.Value
				DB_TOKMTC.WRTFSTTM = wkWRTTM
				DB_TOKMTC.WRTFSTDT = wkWRTDT
				DB_TOKMTC.WRTTM = wkWRTTM
				DB_TOKMTC.WRTDT = wkWRTDT
				DB_TOKMTC.UOPEID = SSS_OPEID.Value
				DB_TOKMTC.UCLTID = SSS_CLTID.Value
				DB_TOKMTC.UWRTTM = wkWRTTM
				DB_TOKMTC.UWRTDT = wkWRTDT
				DB_TOKMTC.PGID = SSS_PrgId
				Call DB_Insert(DBN_TOKMTC, 1)
			End If
			I = I + 1
		Loop 
		Call DB_EndTransaction()
	End Sub
	
	' === 20080903 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function TOKMT52_MF_Chk_UWRTDTTM_T
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
	Public Function TOKMT52_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo TOKMT52_MF_Chk_UWRTDTTM_T_err
		
		TOKMT52_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_TOKMT_A_inf(pin_intIDX).OPEID) & Trim(M_TOKMT_A_inf(pin_intIDX).CLTID) & Trim(M_TOKMT_A_inf(pin_intIDX).UOPEID) & Trim(M_TOKMT_A_inf(pin_intIDX).UCLTID) & Trim(M_TOKMT_A_inf(pin_intIDX).WRTDT) & Trim(M_TOKMT_A_inf(pin_intIDX).WRTTM) & Trim(M_TOKMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_TOKMT_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then
			
			'更新時間チェック
			If Trim(pin_strOPEID) & Trim(pin_strCLTID) & Trim(pin_strUOPEID) & Trim(pin_strUCLTID) & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_TOKMT_A_inf(pin_intIDX).OPEID) & Trim(M_TOKMT_A_inf(pin_intIDX).CLTID) & Trim(M_TOKMT_A_inf(pin_intIDX).UOPEID) & Trim(M_TOKMT_A_inf(pin_intIDX).UCLTID) & Trim(M_TOKMT_A_inf(pin_intIDX).WRTDT) & Trim(M_TOKMT_A_inf(pin_intIDX).WRTTM) & Trim(M_TOKMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_TOKMT_A_inf(pin_intIDX).UWRTTM) Then
				GoTo TOKMT52_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		TOKMT52_MF_Chk_UWRTDTTM_T = True
		
TOKMT52_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
TOKMT52_MF_Chk_UWRTDTTM_T_err: 
		GoTo TOKMT52_MF_Chk_UWRTDTTM_T_End
		
	End Function
	' === 20080903 === INSERT E - RISE)Izumi
	
	' === 20080903 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function TOKMT52_MF_UpDown_UWRTDTTM
	'   概要：  明細　削除・挿入処理
	'   引数：  pin_intIDX      : 対象行
	'           pin_intGYO      : 1…削除（行詰め）　-1…挿入（行下げ）
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function TOKMT52_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo TOKMT52_MF_UpDown_UWRTDTTM_err
		
		TOKMT52_MF_UpDown_UWRTDTTM = False
		
		'更新時間　配列移動
		M_TOKMT_A_inf(pin_intIDX).OPEID = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_TOKMT_A_inf(pin_intIDX).CLTID = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_TOKMT_A_inf(pin_intIDX).UOPEID = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UOPEID
		M_TOKMT_A_inf(pin_intIDX).UCLTID = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UCLTID
		M_TOKMT_A_inf(pin_intIDX).WRTDT = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_TOKMT_A_inf(pin_intIDX).WRTTM = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_TOKMT_A_inf(pin_intIDX).UWRTDT = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_TOKMT_A_inf(pin_intIDX).UWRTTM = M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UOPEID = ""
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UCLTID = ""
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_TOKMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		TOKMT52_MF_UpDown_UWRTDTTM = True
		
TOKMT52_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
TOKMT52_MF_UpDown_UWRTDTTM_err: 
		GoTo TOKMT52_MF_UpDown_UWRTDTTM_End
		
	End Function
	' === 20080903 === INSERT E - RISE)Izumi
	
	' === 20080903 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function TOKMT52_MF_SaveRestore_UWRTDTTM
	'   概要：  明細　退避・復元処理
	'   引数：  pin_intIDX      : 対象行
	'           pin_intKBN      : 0…退避　1…復元
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function TOKMT52_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo TOKMT52_MF_SaveRestore_UWRTDTTM_err
		
		TOKMT52_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			'退避・復元処理
			M_TOKMT_inf.OPEID = M_TOKMT_A_inf(pin_intIDX).OPEID
			M_TOKMT_inf.CLTID = M_TOKMT_A_inf(pin_intIDX).CLTID
			M_TOKMT_inf.UOPEID = M_TOKMT_A_inf(pin_intIDX).UOPEID
			M_TOKMT_inf.UCLTID = M_TOKMT_A_inf(pin_intIDX).UCLTID
			M_TOKMT_inf.WRTDT = M_TOKMT_A_inf(pin_intIDX).WRTDT
			M_TOKMT_inf.WRTTM = M_TOKMT_A_inf(pin_intIDX).WRTTM
			M_TOKMT_inf.UWRTDT = M_TOKMT_A_inf(pin_intIDX).UWRTDT
			M_TOKMT_inf.UWRTTM = M_TOKMT_A_inf(pin_intIDX).UWRTTM
		Else
			'復元処理
			M_TOKMT_A_inf(pin_intIDX).OPEID = M_TOKMT_inf.OPEID
			M_TOKMT_A_inf(pin_intIDX).CLTID = M_TOKMT_inf.CLTID
			M_TOKMT_A_inf(pin_intIDX).UOPEID = M_TOKMT_inf.UOPEID
			M_TOKMT_A_inf(pin_intIDX).UCLTID = M_TOKMT_inf.UCLTID
			M_TOKMT_A_inf(pin_intIDX).WRTDT = M_TOKMT_inf.WRTDT
			M_TOKMT_A_inf(pin_intIDX).WRTTM = M_TOKMT_inf.WRTTM
			M_TOKMT_A_inf(pin_intIDX).UWRTDT = M_TOKMT_inf.UWRTDT
			M_TOKMT_A_inf(pin_intIDX).UWRTTM = M_TOKMT_inf.UWRTTM
		End If
		
		TOKMT52_MF_SaveRestore_UWRTDTTM = True
		
TOKMT52_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
TOKMT52_MF_SaveRestore_UWRTDTTM_err: 
		GoTo TOKMT52_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	' === 20080903 === INSERT E - RISE)Izumi
	
	' === 20080903 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function TOKMT52_MF_Clear_UWRTDTTM
	'   概要：  明細　対象行クリア処理
	'   引数：  pin_intIDX      : 対象行
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function TOKMT52_MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo TOKMT52_MF_Clear_UWRTDTTM_err
		
		TOKMT52_MF_Clear_UWRTDTTM = False
		'更新時間　配列クリア
		M_TOKMT_A_inf(pin_intIDX).OPEID = ""
		M_TOKMT_A_inf(pin_intIDX).CLTID = ""
		M_TOKMT_A_inf(pin_intIDX).UOPEID = ""
		M_TOKMT_A_inf(pin_intIDX).UCLTID = ""
		M_TOKMT_A_inf(pin_intIDX).WRTDT = ""
		M_TOKMT_A_inf(pin_intIDX).WRTTM = ""
		M_TOKMT_A_inf(pin_intIDX).UWRTDT = ""
		M_TOKMT_A_inf(pin_intIDX).UWRTTM = ""
		
		TOKMT52_MF_Clear_UWRTDTTM = True
		
TOKMT52_MF_Clear_UWRTDTTM_End: 
		Exit Function
		
TOKMT52_MF_Clear_UWRTDTTM_err: 
		GoTo TOKMT52_MF_Clear_UWRTDTTM_End
		
	End Function
	' === 20080903 === INSERT E - RISE)Izumi
End Module