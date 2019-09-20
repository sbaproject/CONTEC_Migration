Option Strict Off
Option Explicit On
Module BNKMTA_M51
	'
	' スロット名        : 銀行マスタ・メインファイル更新スロット
	' ユニット名        : BNKMTA.M51
	' 記述者            : Standard Library
	' 作成日付          : 2006/05/29
	' 使用プログラム名  : BNKMT51
	'
	
	' === 20080930 === INSERT S - RISE)Izumi
	'更新時刻、更新日付、バッチ更新時刻、バッチ更新日付　退避用
	Structure M_TYPE_BNKMT
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
	Public M_BNKMT_inf As M_TYPE_BNKMT
	Public M_BNKMT_A_inf() As M_TYPE_BNKMT
	' === 20080930 === INSERT E - RISE)Izumi
	
	Sub UPDMST()
		Dim I As Short
		Dim wkWRTTM, updkb, wkWRTDT As String
		
		'2007/12/12 add-str M.SUEZAWA 訂正前に更新時間チェックを入れる
		Dim bolRet As Boolean
		Dim intRet As Short
		
		' === 20080930 === INSERT S - RISE)Izumi チェック項目追加
		Dim strOPEID As String '最終作業者コード
		Dim strCLTID As String 'クライアントＩＤ
		Dim strUOPEID As String '最終作業者コード（バッチ）
		Dim strUCLTID As String 'クライアントＩＤ（バッチ）
		' === 20080930 === INSERT E - RISE)Izumi
		Dim strWRTDT As String '更新日付
		Dim strWRTTM As String '更新時刻
		Dim strUWRTDT As String 'バッチ更新日付
		Dim strUWRTTM As String 'バッチ更新時刻
		'2007/12/12 add-end M.SUEZAWA
		
		wkWRTTM = VB6.Format(Now, "hhmmss")
		wkWRTDT = VB6.Format(Now, "YYYYMMDD")
		
		'更新権限チェック
		If gs_UPDAUTH = "9" Then
			Call MsgBox("更新権限がありません。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			Exit Sub
		End If
		
		'2008/07/07 START ADD FNAP)YAMANE 連絡票№：排他-53
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'2008/07/07 E.N.D ADD FNAP)YAMANE 連絡票№：排他-53
		
		'2007/12/12 add-str M.SUEZAWA 訂正前に更新時間チェックを入れる
		'更新時間チェック（画面に表示されている明細分）
		I = 0
		Dim strSQL As String
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BNKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_BNKMTA.BNKCD = RD_SSSMAIN_BNKCD(I)
			Call DB_GetEq(DBN_BNKMTA, 1, DB_BNKMTA.BNKCD, BtrNormal)
			If DBSTAT = 0 Then
				' === 20080930 === INSERT S - RISE)Izumi チェック項目追加
				strOPEID = DB_BNKMTA.OPEID '最終作業者コード
				strCLTID = DB_BNKMTA.CLTID 'クライアントＩＤ
				strUOPEID = DB_BNKMTA.UOPEID '最終作業者コード（バッチ）
				strUCLTID = DB_BNKMTA.UCLTID 'クライアントＩＤ（バッチ）
				' === 20080930 === INSERT E - RISE)Izumi
				strWRTDT = DB_BNKMTA.WRTDT '更新日付
				strWRTTM = DB_BNKMTA.WRTTM '更新時刻
				strUWRTDT = DB_BNKMTA.UWRTDT 'バッチ更新日付
				strUWRTTM = DB_BNKMTA.UWRTTM 'バッチ更新時刻
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "削除" Then
					
					'2008/07/07 START ADD FNAP)YAMANE 連絡票№：排他-53
					HaitaUpdFlg = 0
					strSQL = ""
					' === 20080930 === UPDATE S - RISE)Izumi チェック項目追加
					'                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM BNKMTA"
					strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM BNKMTA"
					' === 20080930 === UPDATE E - RISE)Izumi
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BNKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strSQL = strSQL & " WHERE BNKCD = '" + RD_SSSMAIN_BNKCD(I) + "'"
					'ロックする
					strSQL = strSQL & "          FOR UPDATE"
					Call DB_GetSQL2(DBN_BNKMTA, strSQL)
					' === 20080930 === INSERT S - RISE)Izumi チェック項目追加
					strOPEID = DB_BNKMTA.OPEID '最終作業者コード
					strCLTID = DB_BNKMTA.CLTID 'クライアントＩＤ
					strUOPEID = DB_BNKMTA.UOPEID '最終作業者コード（バッチ）
					strUCLTID = DB_BNKMTA.UCLTID 'クライアントＩＤ（バッチ）
					' === 20080930 === INSERT E - RISE)Izumi
					strWRTDT = DB_BNKMTA.WRTDT '更新日付
					strWRTTM = DB_BNKMTA.WRTTM '更新時刻
					strUWRTDT = DB_BNKMTA.UWRTDT 'バッチ更新日付
					strUWRTTM = DB_BNKMTA.UWRTTM 'バッチ更新時刻
					'2008/07/07 E.N.D ADD FNAP)YAMANE 連絡票№：排他-53
					
					'更新時間チェック
					' === 20080930 === UPDATE S - RISE)Izumi チェック項目追加
					'                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					bolRet = BNKMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					' === 20080930 === UPDATE E - RISE)Izumi
					If bolRet = False Then
						' === 20080930 === INSERT S - RISE)Izumi
						Call DB_Unlock(DBN_BNKMTA)
						Call DB_AbortTransaction()
						' === 20080930 === INSERT E - RISE)Izumi
						intRet = MF_DspMsg(gc_strMsgBNKMT51_E_DEL)
						'2008/07/07 START ADD FNAP)YAMANE 連絡票№：排他-53
						' === 20080930 === DELETE S - RISE)Izumi
						'                    Call DB_Unlock(DBN_BNKMTA)
						'                    Call DB_AbortTransaction
						' === 20080930 === DELETE E - RISE)Izumi
						HaitaUpdFlg = 1
						'2008/07/07 E.N.D ADD FNAP)YAMANE 連絡票№：排他-53
						Exit Sub
					End If
					
				Else
					'2007/12/18 upd-str T.KAWAMUKAI
					If updkb = "追加" Then
						' === 20080930 === INSERT S - RISE)Izumi
						Call DB_Unlock(DBN_BNKMTA)
						Call DB_AbortTransaction()
						' === 20080930 === INSERT E - RISE)Izumi
						intRet = MF_DspMsg(gc_strMsgBNKMT51_E_UPD)
						' === 20080930 === DELETE S - RISE)Izumi
						''2008/07/07 START ADD FNAP)YAMANE 連絡票№：排他-53
						'                    Call DB_Unlock(DBN_BNKMTA)
						'                    Call DB_AbortTransaction
						''2008/07/07 E.N.D ADD FNAP)YAMANE 連絡票№：排他-53
						' === 20080930 === DELETE E - RISE)Izumi
						'2007/12/21 add-str T.KAWAMUKAI
						Exit Sub
						'2007/12/21 add-end T.KAWAMUKAI
					Else
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_STNNK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STNNK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_BNKNK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BNKNK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_STNNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STNNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_BNKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BNKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If Trim(RD_SSSMAIN_BNKNM(I)) <> Trim(RD_SSSMAIN_V_BNKNM(I)) Or Trim(RD_SSSMAIN_STNNM(I)) <> Trim(RD_SSSMAIN_V_STNNM(I)) Or Trim(RD_SSSMAIN_BNKNK(I)) <> Trim(RD_SSSMAIN_V_BNKNK(I)) Or Trim(RD_SSSMAIN_STNNK(I)) <> Trim(RD_SSSMAIN_V_STNNK(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then
							
							'2008/07/07 START ADD FNAP)YAMANE 連絡票№：排他-53
							HaitaUpdFlg = 0
							strSQL = ""
							' === 20080930 === UPDATE S - RISE)Izumi チェック項目追加
							'                       strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM BNKMTA"
							strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM BNKMTA"
							' === 20080930 === UPDATE E - RISE)Izumi
							'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BNKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							strSQL = strSQL & " WHERE BNKCD = '" + RD_SSSMAIN_BNKCD(I) + "'"
							'ロックする
							strSQL = strSQL & "          FOR UPDATE"
							Call DB_GetSQL2(DBN_BNKMTA, strSQL)
							' === 20080930 === INSERT S - RISE)Izumi チェック項目追加
							strOPEID = DB_BNKMTA.OPEID '最終作業者コード
							strCLTID = DB_BNKMTA.CLTID 'クライアントＩＤ
							strUOPEID = DB_BNKMTA.UOPEID '最終作業者コード（バッチ）
							strUCLTID = DB_BNKMTA.UCLTID 'クライアントＩＤ（バッチ）
							' === 20080930 === INSERT E - RISE)Izumi
							strWRTDT = DB_BNKMTA.WRTDT '更新日付
							strWRTTM = DB_BNKMTA.WRTTM '更新時刻
							strUWRTDT = DB_BNKMTA.UWRTDT 'バッチ更新日付
							strUWRTTM = DB_BNKMTA.UWRTTM 'バッチ更新時刻
							'2008/07/07 E.N.D ADD FNAP)YAMANE 連絡票№：排他-53
							
							'更新時間チェック
							' === 20080930 === UPDATE S - RISE)Izumi チェック項目追加
							'                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
							bolRet = BNKMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
							' === 20080930 === UPDATE E - RISE)Izumi
							If bolRet = False Then
								' === 20080930 === INSERT S - RISE)Izumi
								Call DB_Unlock(DBN_BNKMTA)
								Call DB_AbortTransaction()
								' === 20080930 === INSERT E - RISE)Izumi
								intRet = MF_DspMsg(gc_strMsgBNKMT51_E_UPD)
								'2008/07/07 START ADD FNAP)YAMANE 連絡票№：排他-53
								' === 20080930 === DELETE S - RISE)Izumi
								'                            Call DB_Unlock(DBN_BNKMTA)
								'                            Call DB_AbortTransaction
								' === 20080930 === DELETE E - RISE)Izumi
								HaitaUpdFlg = 1
								'2008/07/07 E.N.D ADD FNAP)YAMANE 連絡票№：排他-53
								Exit Sub
							End If
						End If
					End If
					'2007/12/18 upd-end T.KAWAMUKAI
				End If
			End If
			I = I + 1
		Loop 
		'2007/12/12 add-end M.SUEZAWA
		'
		I = 0
		'2008/07/07 START DEL FNAP)YAMANE 連絡票№：排他-53
		'上部のチェックのループの開始時に宣言するように変更
		'    Call DB_BeginTransaction(BTR_Exclude)
		'2008/07/07 E.N.D DEL FNAP)YAMANE 連絡票№：排他-53
		
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BNKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_BNKMTA.BNKCD = RD_SSSMAIN_BNKCD(I)
			Call DB_GetEq(DBN_BNKMTA, 1, DB_BNKMTA.BNKCD, BtrLock)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "削除" Then
					
					DB_BNKMTA.DATKB = "9"
					DB_BNKMTA.RELFL = "1"
					DB_BNKMTA.OPEID = SSS_OPEID.Value
					DB_BNKMTA.CLTID = SSS_CLTID.Value
					DB_BNKMTA.WRTTM = wkWRTTM ' Format(Now, "hhmmss")
					DB_BNKMTA.WRTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
					DB_BNKMTA.UOPEID = SSS_OPEID.Value
					DB_BNKMTA.UCLTID = SSS_CLTID.Value
					DB_BNKMTA.UWRTTM = wkWRTTM ' Format(Now, "hhmmss")
					DB_BNKMTA.UWRTDT = wkWRTDT ' Format(Now, "YYYYMMDD")
					DB_BNKMTA.PGID = SSS_PrgId
					Call DB_Update(DBN_BNKMTA, 1)
				Else
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_STNNK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STNNK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_BNKNK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BNKNK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_STNNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STNNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_BNKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BNKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Trim(RD_SSSMAIN_BNKNM(I)) <> Trim(RD_SSSMAIN_V_BNKNM(I)) Or Trim(RD_SSSMAIN_STNNM(I)) <> Trim(RD_SSSMAIN_V_STNNM(I)) Or Trim(RD_SSSMAIN_BNKNK(I)) <> Trim(RD_SSSMAIN_V_BNKNK(I)) Or Trim(RD_SSSMAIN_STNNK(I)) <> Trim(RD_SSSMAIN_V_STNNK(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
						Call Mfil_FromSCR(I)
						DB_BNKMTA.DATKB = "1"
						DB_BNKMTA.RELFL = "1"
						DB_BNKMTA.WRTTM = wkWRTTM 'Format(Now, "hhmmss")
						DB_BNKMTA.WRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
						DB_BNKMTA.UOPEID = SSS_OPEID.Value
						DB_BNKMTA.UCLTID = SSS_CLTID.Value
						DB_BNKMTA.UWRTTM = wkWRTTM 'Format(Now, "hhmmss")
						DB_BNKMTA.UWRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
						DB_BNKMTA.PGID = SSS_PrgId
						Call DB_Update(DBN_BNKMTA, 1)
					End If '2006.11.07
				End If
			Else
				Call BNKMTA_RClear()
				Call Mfil_FromSCR(I)
				DB_BNKMTA.DATKB = "1"
				DB_BNKMTA.RELFL = "1"
				
				DB_BNKMTA.FOPEID = SSS_OPEID.Value
				DB_BNKMTA.FCLTID = SSS_CLTID.Value
				DB_BNKMTA.WRTFSTTM = wkWRTTM 'Format(Now, "hhmmss")
				DB_BNKMTA.WRTFSTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
				DB_BNKMTA.WRTTM = wkWRTTM 'Format(Now, "hhmmss")
				DB_BNKMTA.WRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
				DB_BNKMTA.UOPEID = SSS_OPEID.Value
				DB_BNKMTA.UCLTID = SSS_CLTID.Value
				DB_BNKMTA.UWRTTM = wkWRTTM 'Format(Now, "hhmmss")
				DB_BNKMTA.UWRTDT = wkWRTDT 'Format(Now, "YYYYMMDD")
				DB_BNKMTA.PGID = SSS_PrgId
				
				Call DB_Insert(DBN_BNKMTA, 1)
			End If
			I = I + 1
		Loop 
		Call DB_Unlock(DBN_BNKMTA)
		Call DB_EndTransaction()
	End Sub
	
	' === 20080930 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function BNKMT51_MF_Chk_UWRTDTTM_T
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
	Public Function BNKMT51_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo BNKMT51_MF_Chk_UWRTDTTM_T_err
		
		BNKMT51_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_BNKMT_A_inf(pin_intIDX).OPEID) & Trim(M_BNKMT_A_inf(pin_intIDX).CLTID) & Trim(M_BNKMT_A_inf(pin_intIDX).UOPEID) & Trim(M_BNKMT_A_inf(pin_intIDX).UCLTID) & Trim(M_BNKMT_A_inf(pin_intIDX).WRTDT) & Trim(M_BNKMT_A_inf(pin_intIDX).WRTTM) & Trim(M_BNKMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_BNKMT_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then
			
			'更新時間チェック
			If Trim(pin_strOPEID) & Trim(pin_strCLTID) & Trim(pin_strUOPEID) & Trim(pin_strUCLTID) & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_BNKMT_A_inf(pin_intIDX).OPEID) & Trim(M_BNKMT_A_inf(pin_intIDX).CLTID) & Trim(M_BNKMT_A_inf(pin_intIDX).UOPEID) & Trim(M_BNKMT_A_inf(pin_intIDX).UCLTID) & Trim(M_BNKMT_A_inf(pin_intIDX).WRTDT) & Trim(M_BNKMT_A_inf(pin_intIDX).WRTTM) & Trim(M_BNKMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_BNKMT_A_inf(pin_intIDX).UWRTTM) Then
				GoTo BNKMT51_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		BNKMT51_MF_Chk_UWRTDTTM_T = True
		
BNKMT51_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
BNKMT51_MF_Chk_UWRTDTTM_T_err: 
		GoTo BNKMT51_MF_Chk_UWRTDTTM_T_End
		
	End Function
	' === 20080930 === INSERT E - RISE)Izumi
	
	' === 20080930 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function BNKMT51_MF_UpDown_UWRTDTTM
	'   概要：  明細　削除・挿入処理
	'   引数：  pin_intIDX      : 対象行
	'           pin_intGYO      : 1…削除（行詰め）　-1…挿入（行下げ）
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function BNKMT51_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo BNKMT51_MF_UpDown_UWRTDTTM_err
		
		BNKMT51_MF_UpDown_UWRTDTTM = False
		
		'更新時間　配列移動
		M_BNKMT_A_inf(pin_intIDX).OPEID = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_BNKMT_A_inf(pin_intIDX).CLTID = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_BNKMT_A_inf(pin_intIDX).UOPEID = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UOPEID
		M_BNKMT_A_inf(pin_intIDX).UCLTID = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UCLTID
		M_BNKMT_A_inf(pin_intIDX).WRTDT = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_BNKMT_A_inf(pin_intIDX).WRTTM = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_BNKMT_A_inf(pin_intIDX).UWRTDT = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_BNKMT_A_inf(pin_intIDX).UWRTTM = M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UOPEID = ""
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UCLTID = ""
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_BNKMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		BNKMT51_MF_UpDown_UWRTDTTM = True
		
BNKMT51_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
BNKMT51_MF_UpDown_UWRTDTTM_err: 
		GoTo BNKMT51_MF_UpDown_UWRTDTTM_End
		
	End Function
	' === 20080930 === INSERT E - RISE)Izumi
	
	' === 20080930 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function BNKMT51_MF_SaveRestore_UWRTDTTM
	'   概要：  明細　退避・復元処理
	'   引数：  pin_intIDX      : 対象行
	'           pin_intKBN      : 0…退避　1…復元
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function BNKMT51_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo BNKMT51_MF_SaveRestore_UWRTDTTM_err
		
		BNKMT51_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			'退避・復元処理
			M_BNKMT_inf.OPEID = M_BNKMT_A_inf(pin_intIDX).OPEID
			M_BNKMT_inf.CLTID = M_BNKMT_A_inf(pin_intIDX).CLTID
			M_BNKMT_inf.UOPEID = M_BNKMT_A_inf(pin_intIDX).UOPEID
			M_BNKMT_inf.UCLTID = M_BNKMT_A_inf(pin_intIDX).UCLTID
			M_BNKMT_inf.WRTDT = M_BNKMT_A_inf(pin_intIDX).WRTDT
			M_BNKMT_inf.WRTTM = M_BNKMT_A_inf(pin_intIDX).WRTTM
			M_BNKMT_inf.UWRTDT = M_BNKMT_A_inf(pin_intIDX).UWRTDT
			M_BNKMT_inf.UWRTTM = M_BNKMT_A_inf(pin_intIDX).UWRTTM
		Else
			'復元処理
			M_BNKMT_A_inf(pin_intIDX).OPEID = M_BNKMT_inf.OPEID
			M_BNKMT_A_inf(pin_intIDX).CLTID = M_BNKMT_inf.CLTID
			M_BNKMT_A_inf(pin_intIDX).UOPEID = M_BNKMT_inf.UOPEID
			M_BNKMT_A_inf(pin_intIDX).UCLTID = M_BNKMT_inf.UCLTID
			M_BNKMT_A_inf(pin_intIDX).WRTDT = M_BNKMT_inf.WRTDT
			M_BNKMT_A_inf(pin_intIDX).WRTTM = M_BNKMT_inf.WRTTM
			M_BNKMT_A_inf(pin_intIDX).UWRTDT = M_BNKMT_inf.UWRTDT
			M_BNKMT_A_inf(pin_intIDX).UWRTTM = M_BNKMT_inf.UWRTTM
		End If
		
		BNKMT51_MF_SaveRestore_UWRTDTTM = True
		
BNKMT51_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
BNKMT51_MF_SaveRestore_UWRTDTTM_err: 
		GoTo BNKMT51_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	' === 20080930 === INSERT E - RISE)Izumi
	
	' === 20080930 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function BNKMT51_MF_Clear_UWRTDTTM
	'   概要：  明細　対象行クリア処理
	'   引数：  pin_intIDX      : 対象行
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function BNKMT51_MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo BNKMT51_MF_Clear_UWRTDTTM_err
		
		BNKMT51_MF_Clear_UWRTDTTM = False
		'更新時間　配列クリア
		M_BNKMT_A_inf(pin_intIDX).OPEID = ""
		M_BNKMT_A_inf(pin_intIDX).CLTID = ""
		M_BNKMT_A_inf(pin_intIDX).UOPEID = ""
		M_BNKMT_A_inf(pin_intIDX).UCLTID = ""
		M_BNKMT_A_inf(pin_intIDX).WRTDT = ""
		M_BNKMT_A_inf(pin_intIDX).WRTTM = ""
		M_BNKMT_A_inf(pin_intIDX).UWRTDT = ""
		M_BNKMT_A_inf(pin_intIDX).UWRTTM = ""
		
		BNKMT51_MF_Clear_UWRTDTTM = True
		
BNKMT51_MF_Clear_UWRTDTTM_End: 
		Exit Function
		
BNKMT51_MF_Clear_UWRTDTTM_err: 
		GoTo BNKMT51_MF_Clear_UWRTDTTM_End
		
	End Function
	' === 20080930 === INSERT E - RISE)Izumi
End Module