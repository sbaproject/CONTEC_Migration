Option Strict Off
Option Explicit On
Module TUKMTA_M51
	'
	' スロット名        : メインファイル更新スロット
	' ユニット名        : TUKMTA.M01
	' 記述者            : Standard Library
	' 作成日付          : 2006/05/31
	' 使用プログラム名  : TUKMT51
	'
	'20081002 ADD START RISE)Tanimura '排他処理
	Structure M_TYPE_RATMT
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char ' 最終作業者コード
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char ' クライアントＩＤ
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char ' タイムスタンプ（時間）
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char ' タイムスタンプ（日付）
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UOPEID() As Char ' ユーザID（バッチ）
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public UCLTID() As Char ' クライアントＩＤ（バッチ）
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public UWRTTM() As Char ' タイムスタンプ（バッチ時間）
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public UWRTDT() As Char ' タイムスタンプ（バッチ日）
	End Structure
	Public M_RATMT_inf As M_TYPE_RATMT
	Public M_RATMT_A_inf() As M_TYPE_RATMT
	'20081002 ADD END   RISE)Tanimura
	
	Sub UPDMST()
		Dim I As Short
		Dim updkb As String
		Dim WRTTM, WRTDT As String
		
		'2007/12/14 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		Dim bolRet As Boolean
		Dim intRet As Short
		
		Dim strWRTDT As String '更新日付
		Dim strWRTTM As String '更新時刻
		Dim strUWRTDT As String 'バッチ更新日付
		Dim strUWRTTM As String 'バッチ更新時刻
		'2007/12/14 add-end T.KAWAMUKAI
		
		'20081002 ADD START RISE)Tanimura '排他処理
		Dim strOPEID As String ' 最終作業者コード
		Dim strCLTID As String ' クライアントＩＤ
		Dim strUOPEID As String ' ユーザID（バッチ）
		Dim strUCLTID As String ' クライアントＩＤ（バッチ）
		Dim strSQL As String
		'20081002 ADD END   RISE)Tanimura
		
		'更新権限チェック
		If gs_UPDAUTH = "9" Then
			Call MsgBox("更新権限がありません。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			Exit Sub
		End If
		
		'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-60
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-60
		
		'2007/12/14 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		'更新時間チェック（画面に表示されている明細分）
		I = 0
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TUKMTA.TUKKB = RD_SSSMAIN_TUKKB(I)
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TEKIDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TUKMTA.TEKIDT = RD_SSSMAIN_TEKIDT(I)
			Call DB_GetSQL2(DBN_TUKMTA, "select * from TUKMTA where TUKKB ='" & DB_TUKMTA.TUKKB & "' and TEKIDT='" & DB_TUKMTA.TEKIDT & "' order by TUKKB,TEKIDT")
			If DBSTAT = 0 Then
				'20081002 CHG START RISE)Tanimura '排他処理
				'            strWRTDT = DB_TUKMTA.WRTDT            '更新日付
				'            strWRTTM = DB_TUKMTA.WRTTM            '更新時刻
				'            strUWRTDT = DB_TUKMTA.UWRTDT          'バッチ更新日付
				'            strUWRTTM = DB_TUKMTA.UWRTTM          'バッチ更新時刻
				
				strOPEID = DB_TUKMTA.OPEID ' 最終作業者コード
				strCLTID = DB_TUKMTA.CLTID ' クライアントＩＤ
				strWRTTM = DB_TUKMTA.WRTTM ' タイムスタンプ（時間）
				strWRTDT = DB_TUKMTA.WRTDT ' タイムスタンプ（日付）
				strUOPEID = DB_TUKMTA.UOPEID ' ユーザID（バッチ）
				strUCLTID = DB_TUKMTA.UCLTID ' クライアントID（バッチ）
				strUWRTTM = DB_TUKMTA.UWRTTM ' タイムスタンプ（バッチ時間）
				strUWRTDT = DB_TUKMTA.UWRTDT ' タイムスタンプ（バッチ日）
				'20081002 CHG END   RISE)Tanimura
				
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "削除" Then
					'20081002 CHG START RISE)Tanimura '排他処理
					' '2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-60
					'                HaitaUpdFlg = 0
					'                Dim strSQL As String
					'                strSQL = ""
					'                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM TUKMTA"
					'                strSQL = strSQL + " WHERE TUKKB = '" + RD_SSSMAIN_TUKKB(I) + "'"
					'                strSQL = strSQL + " AND TEKIDT = '" + RD_SSSMAIN_TEKIDT(I) + "'"
					'                'ロックする
					'                strSQL = strSQL & "          FOR UPDATE"
					'                Call DB_GetSQL2(DBN_TUKMTA, strSQL)
					'                strWRTDT = DB_TUKMTA.WRTDT            '更新日付
					'                strWRTTM = DB_TUKMTA.WRTTM            '更新時刻
					'                strUWRTDT = DB_TUKMTA.UWRTDT          'バッチ更新日付
					'                strUWRTTM = DB_TUKMTA.UWRTTM          'バッチ更新時刻
					' '2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-60
					'
					'                '更新時間チェック
					'                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					
					HaitaUpdFlg = 0
					
					' レートマスタ
					strSQL = ""
					strSQL = strSQL & "SELECT"
					strSQL = strSQL & "  OPEID "
					strSQL = strSQL & ", CLTID "
					strSQL = strSQL & ", WRTTM "
					strSQL = strSQL & ", WRTDT "
					strSQL = strSQL & ", UOPEID "
					strSQL = strSQL & ", UCLTID "
					strSQL = strSQL & ", UWRTTM "
					strSQL = strSQL & ", UWRTDT "
					strSQL = strSQL & "FROM"
					strSQL = strSQL & "  TUKMTA "
					strSQL = strSQL & "WHERE"
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strSQL = strSQL & "  TUKKB  = '" + RD_SSSMAIN_TUKKB(I) + "' "
					strSQL = strSQL & "AND"
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TEKIDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strSQL = strSQL & "  TEKIDT = '" + RD_SSSMAIN_TEKIDT(I) + "' "
					strSQL = strSQL & "FOR UPDATE"
					
					Call DB_GetSQL2(DBN_TUKMTA, strSQL)
					
					strOPEID = DB_TUKMTA.OPEID ' 最終作業者コード
					strCLTID = DB_TUKMTA.CLTID ' クライアントＩＤ
					strWRTDT = DB_TUKMTA.WRTDT ' タイムスタンプ（時間）
					strWRTTM = DB_TUKMTA.WRTTM ' タイムスタンプ（日付）
					strUOPEID = DB_TUKMTA.UOPEID ' ユーザID（バッチ）
					strUCLTID = DB_TUKMTA.UCLTID ' クライアントID（バッチ）
					strUWRTTM = DB_TUKMTA.UWRTTM ' タイムスタンプ（バッチ時間）
					strUWRTDT = DB_TUKMTA.UWRTDT ' タイムスタンプ（バッチ日）
					
					' 更新時間チェック
					bolRet = RATMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strWRTTM, strWRTDT, strUOPEID, strUCLTID, strUWRTTM, strUWRTDT, I)
					'20081002 CHG END   RISE)Tanimura
					
					If bolRet = False Then
						intRet = MF_DspMsg(gc_strMsgRATMT51_E_DEL)
						'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-60
						Call DB_Unlock(DBN_TUKMTA)
						Call DB_AbortTransaction()
						HaitaUpdFlg = 1
						'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-60
						Exit Sub
					End If
					
				Else
					'2007/12/18 upd-str T.KAWAMUKAI
					If updkb = "追加" Then
						intRet = MF_DspMsg(gc_strMsgRATMT51_E_UPD)
						'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-60
						Call DB_Unlock(DBN_TUKMTA)
						Call DB_AbortTransaction()
						'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-60
						'2007/12/21 add-str T.KAWAMUKAI
						Exit Sub
						'2007/12/21 add-end T.KAWAMUKAI
					Else
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_RATERT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RATERT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If Trim(RD_SSSMAIN_RATERT(I)) <> Trim(RD_SSSMAIN_V_RATERT(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then
							'20081002 CHG START RISE)Tanimura '排他処理
							''2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-60
							'                        HaitaUpdFlg = 0
							'                        strSQL = ""
							'                        strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM TUKMTA"
							'                        strSQL = strSQL + " WHERE TUKKB = '" + RD_SSSMAIN_TUKKB(I) + "'"
							'                        strSQL = strSQL + " AND TEKIDT = '" + RD_SSSMAIN_TEKIDT(I) + "'"
							'                        'ロックする
							'                        strSQL = strSQL & "          FOR UPDATE"
							'                        Call DB_GetSQL2(DBN_TUKMTA, strSQL)
							'                        strWRTDT = DB_TUKMTA.WRTDT            '更新日付
							'                        strWRTTM = DB_TUKMTA.WRTTM            '更新時刻
							'                        strUWRTDT = DB_TUKMTA.UWRTDT          'バッチ更新日付
							'                        strUWRTTM = DB_TUKMTA.UWRTTM          'バッチ更新時刻
							''2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-60
							'                        '更新時間チェック
							'                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
							
							HaitaUpdFlg = 0
							
							' レートマスタ
							strSQL = ""
							strSQL = strSQL & "SELECT"
							strSQL = strSQL & "  OPEID "
							strSQL = strSQL & ", CLTID "
							strSQL = strSQL & ", WRTTM "
							strSQL = strSQL & ", WRTDT "
							strSQL = strSQL & ", UOPEID "
							strSQL = strSQL & ", UCLTID "
							strSQL = strSQL & ", UWRTTM "
							strSQL = strSQL & ", UWRTDT "
							strSQL = strSQL & "FROM"
							strSQL = strSQL & "  TUKMTA "
							strSQL = strSQL & "WHERE"
							'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							strSQL = strSQL & "  TUKKB  = '" + RD_SSSMAIN_TUKKB(I) + "' "
							strSQL = strSQL & "AND"
							'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TEKIDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							strSQL = strSQL & "  TEKIDT = '" + RD_SSSMAIN_TEKIDT(I) + "' "
							strSQL = strSQL & "FOR UPDATE"
							
							Call DB_GetSQL2(DBN_TUKMTA, strSQL)
							
							strOPEID = DB_TUKMTA.OPEID ' 最終作業者コード
							strCLTID = DB_TUKMTA.CLTID ' クライアントＩＤ
							strWRTDT = DB_TUKMTA.WRTDT ' タイムスタンプ（時間）
							strWRTTM = DB_TUKMTA.WRTTM ' タイムスタンプ（日付）
							strUOPEID = DB_TUKMTA.UOPEID ' ユーザID（バッチ）
							strUCLTID = DB_TUKMTA.UCLTID ' クライアントID（バッチ）
							strUWRTTM = DB_TUKMTA.UWRTTM ' タイムスタンプ（バッチ時間）
							strUWRTDT = DB_TUKMTA.UWRTDT ' タイムスタンプ（バッチ日）
							
							' 更新時間チェック
							bolRet = RATMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strWRTTM, strWRTDT, strUOPEID, strUCLTID, strUWRTTM, strUWRTDT, I)
							'20081002 CHG END   RISE)Tanimura
							
							If bolRet = False Then
								intRet = MF_DspMsg(gc_strMsgRATMT51_E_UPD)
								'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-60
								Call DB_Unlock(DBN_TUKMTA)
								Call DB_AbortTransaction()
								HaitaUpdFlg = 1
								'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-60
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
		
		'
		I = 0
		WRTTM = VB6.Format(Now, "hhmmss")
		WRTDT = VB6.Format(Now, "YYYYMMDD")
		
		'2008/07/11 START DEL FNAP)YAMANE 連絡票№：排他-60
		'上部のチェックのループの開始時に宣言するように変更
		'    Call DB_BeginTransaction(BTR_Exclude)
		'2008/07/11 E.N.D DEL FNAP)YAMANE 連絡票№：排他-60
		
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TUKMTA.TUKKB = RD_SSSMAIN_TUKKB(I)
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TEKIDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_TUKMTA.TEKIDT = RD_SSSMAIN_TEKIDT(I)
			'Call DB_GetEq(DBN_TUKMTA, 1, DB_TUKMTA.TUKKB, BtrLock)
			Call DB_GetSQL2(DBN_TUKMTA, "select * from TUKMTA where TUKKB ='" & DB_TUKMTA.TUKKB & "' and TEKIDT='" & DB_TUKMTA.TEKIDT & "' order by TUKKB,TEKIDT")
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "削除" Then
					DB_TUKMTA.DATKB = "9"
					DB_TUKMTA.RELFL = "1"
					DB_TUKMTA.OPEID = SSS_OPEID.Value
					DB_TUKMTA.CLTID = SSS_CLTID.Value
					DB_TUKMTA.WRTTM = WRTTM
					DB_TUKMTA.WRTDT = WRTDT
					DB_TUKMTA.UOPEID = SSS_OPEID.Value
					DB_TUKMTA.UCLTID = SSS_CLTID.Value
					DB_TUKMTA.UWRTTM = WRTTM
					DB_TUKMTA.UWRTDT = WRTDT
					DB_TUKMTA.PGID = SSS_PrgId
					Call DB_Update(DBN_TUKMTA, 1)
				Else
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_RATERT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RATERT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Trim(RD_SSSMAIN_RATERT(I)) <> Trim(RD_SSSMAIN_V_RATERT(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
						Call Mfil_FromSCR(I)
						DB_TUKMTA.DATKB = "1"
						DB_TUKMTA.RELFL = "1"
						DB_TUKMTA.WRTTM = WRTTM
						DB_TUKMTA.WRTDT = WRTDT
						DB_TUKMTA.UOPEID = SSS_OPEID.Value
						DB_TUKMTA.UCLTID = SSS_CLTID.Value
						DB_TUKMTA.UWRTTM = WRTTM
						DB_TUKMTA.UWRTDT = WRTDT
						DB_TUKMTA.PGID = SSS_PrgId
						Call DB_Update(DBN_TUKMTA, 1)
					End If
				End If
			Else
				'Call TUKMTA_RClear
				Call Mfil_FromSCR(I)
				DB_TUKMTA.DATKB = "1"
				DB_TUKMTA.RELFL = "1"
				DB_TUKMTA.WRTFSTTM = WRTTM
				DB_TUKMTA.WRTFSTDT = WRTDT
				DB_TUKMTA.FOPEID = SSS_OPEID.Value
				DB_TUKMTA.FCLTID = SSS_CLTID.Value
				DB_TUKMTA.WRTFSTTM = WRTTM
				DB_TUKMTA.WRTFSTDT = WRTDT
				DB_TUKMTA.WRTTM = WRTTM
				DB_TUKMTA.WRTDT = WRTDT
				DB_TUKMTA.UOPEID = SSS_OPEID.Value
				DB_TUKMTA.UCLTID = SSS_CLTID.Value
				DB_TUKMTA.UWRTTM = WRTTM
				DB_TUKMTA.UWRTDT = WRTDT
				DB_TUKMTA.PGID = SSS_PrgId
				Call DB_Insert(DBN_TUKMTA, 1)
			End If
			I = I + 1
		Loop 
		Call DB_Unlock(DBN_TUKMTA)
		Call DB_EndTransaction()
	End Sub
	
	'20081002 ADD START RISE)Tanimura '排他処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function RATMT51_MF_Chk_UWRTDTTM_T
	'   概要：  更新時間チェック処理
	'   引数：  pin_strOPEID    : 最終作業者コード
	'           pin_strCLTID    : クライアントＩＤ
	'           pin_strWRTTM    : タイムスタンプ（時間）
	'           pin_strWRTDT    : タイムスタンプ（日付）
	'           pin_strUOPEID   : ユーザID（バッチ）
	'           pin_strUCLTID   : クライアントID（バッチ）
	'           pin_strUWRTTM   : タイムスタンプ（バッチ時間）
	'           pin_strUWRTDT   : タイムスタンプ（バッチ日）
	'           pin_intIDX      : 多明細の場合　　　　明細行（0～）
	'   戻値：　True：チェックOK　False：チェックNG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function RATMT51_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strWRTTM As String, ByVal pin_strWRTDT As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strUWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo RATMT51_MF_Chk_UWRTDTTM_T_err
		
		RATMT51_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_RATMT_A_inf(pin_intIDX).OPEID) & Trim(M_RATMT_A_inf(pin_intIDX).CLTID) & Trim(M_RATMT_A_inf(pin_intIDX).WRTTM) & Trim(M_RATMT_A_inf(pin_intIDX).WRTDT) & Trim(M_RATMT_A_inf(pin_intIDX).UOPEID) & Trim(M_RATMT_A_inf(pin_intIDX).UCLTID) & Trim(M_RATMT_A_inf(pin_intIDX).UWRTTM) & Trim(M_RATMT_A_inf(pin_intIDX).UWRTDT), "0") <> 0 Then
			' 更新時間チェック
			If Trim(M_RATMT_A_inf(pin_intIDX).OPEID) <> Trim(pin_strOPEID) Or Trim(M_RATMT_A_inf(pin_intIDX).CLTID) <> Trim(pin_strCLTID) Or Trim(M_RATMT_A_inf(pin_intIDX).WRTTM) <> Trim(pin_strWRTTM) Or Trim(M_RATMT_A_inf(pin_intIDX).WRTDT) <> Trim(pin_strWRTDT) Or Trim(M_RATMT_A_inf(pin_intIDX).UOPEID) <> Trim(pin_strUOPEID) Or Trim(M_RATMT_A_inf(pin_intIDX).UCLTID) <> Trim(pin_strUCLTID) Or Trim(M_RATMT_A_inf(pin_intIDX).UWRTTM) <> Trim(pin_strUWRTTM) Or Trim(M_RATMT_A_inf(pin_intIDX).UWRTDT) <> Trim(pin_strUWRTDT) Then
				GoTo RATMT51_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		RATMT51_MF_Chk_UWRTDTTM_T = True
		
RATMT51_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
RATMT51_MF_Chk_UWRTDTTM_T_err: 
		GoTo RATMT51_MF_Chk_UWRTDTTM_T_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function RATMT51_MF_UpDown_UWRTDTTM
	'   概要：  明細　削除・挿入処理
	'   引数：  pin_intIDX      : 対象行
	'           pin_intGYO      : 1…削除（行詰め）　-1…挿入（行下げ）
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function RATMT51_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo RATMT51_MF_UpDown_UWRTDTTM_err
		
		RATMT51_MF_UpDown_UWRTDTTM = False
		
		'更新時間　配列移動
		M_RATMT_A_inf(pin_intIDX).OPEID = M_RATMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_RATMT_A_inf(pin_intIDX).CLTID = M_RATMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_RATMT_A_inf(pin_intIDX).WRTDT = M_RATMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_RATMT_A_inf(pin_intIDX).WRTTM = M_RATMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_RATMT_A_inf(pin_intIDX).UOPEID = M_RATMT_A_inf(pin_intIDX + pin_intGYO).UOPEID
		M_RATMT_A_inf(pin_intIDX).UCLTID = M_RATMT_A_inf(pin_intIDX + pin_intGYO).UCLTID
		M_RATMT_A_inf(pin_intIDX).UWRTDT = M_RATMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_RATMT_A_inf(pin_intIDX).UWRTTM = M_RATMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).UOPEID = ""
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).UCLTID = ""
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_RATMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		RATMT51_MF_UpDown_UWRTDTTM = True
		
RATMT51_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
RATMT51_MF_UpDown_UWRTDTTM_err: 
		GoTo RATMT51_MF_UpDown_UWRTDTTM_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function RATMT51_MF_SaveRestore_UWRTDTTM
	'   概要：  明細　退避・復元処理
	'   引数：  pin_intIDX      : 対象行
	'           pin_intKBN      : 0…退避　1…復元
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function RATMT51_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo RATMT51_MF_SaveRestore_UWRTDTTM_err
		
		RATMT51_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			' 退避・復元処理
			M_RATMT_inf.OPEID = M_RATMT_A_inf(pin_intIDX).OPEID
			M_RATMT_inf.CLTID = M_RATMT_A_inf(pin_intIDX).CLTID
			M_RATMT_inf.WRTDT = M_RATMT_A_inf(pin_intIDX).WRTDT
			M_RATMT_inf.WRTTM = M_RATMT_A_inf(pin_intIDX).WRTTM
			M_RATMT_inf.UOPEID = M_RATMT_A_inf(pin_intIDX).UOPEID
			M_RATMT_inf.UCLTID = M_RATMT_A_inf(pin_intIDX).UCLTID
			M_RATMT_inf.UWRTDT = M_RATMT_A_inf(pin_intIDX).UWRTDT
			M_RATMT_inf.UWRTTM = M_RATMT_A_inf(pin_intIDX).UWRTTM
		Else
			' 復元処理
			M_RATMT_A_inf(pin_intIDX).OPEID = M_RATMT_inf.OPEID
			M_RATMT_A_inf(pin_intIDX).CLTID = M_RATMT_inf.CLTID
			M_RATMT_A_inf(pin_intIDX).WRTDT = M_RATMT_inf.WRTDT
			M_RATMT_A_inf(pin_intIDX).WRTTM = M_RATMT_inf.WRTTM
			M_RATMT_A_inf(pin_intIDX).UOPEID = M_RATMT_inf.UOPEID
			M_RATMT_A_inf(pin_intIDX).UCLTID = M_RATMT_inf.UCLTID
			M_RATMT_A_inf(pin_intIDX).UWRTDT = M_RATMT_inf.UWRTDT
			M_RATMT_A_inf(pin_intIDX).UWRTTM = M_RATMT_inf.UWRTTM
		End If
		
		RATMT51_MF_SaveRestore_UWRTDTTM = True
		
RATMT51_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
RATMT51_MF_SaveRestore_UWRTDTTM_err: 
		GoTo RATMT51_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function RATMT51_MF_Clear_UWRTDTTM
	'   概要：  明細　対象行クリア処理
	'   引数：  pin_intIDX      : 対象行
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function RATMT51_MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo RATMT51_MF_Clear_UWRTDTTM_err
		
		RATMT51_MF_Clear_UWRTDTTM = False
		
		' 更新時間　配列クリア
		M_RATMT_A_inf(pin_intIDX).OPEID = ""
		M_RATMT_A_inf(pin_intIDX).CLTID = ""
		M_RATMT_A_inf(pin_intIDX).WRTDT = ""
		M_RATMT_A_inf(pin_intIDX).WRTTM = ""
		M_RATMT_A_inf(pin_intIDX).UOPEID = ""
		M_RATMT_A_inf(pin_intIDX).UCLTID = ""
		M_RATMT_A_inf(pin_intIDX).UWRTDT = ""
		M_RATMT_A_inf(pin_intIDX).UWRTTM = ""
		
		RATMT51_MF_Clear_UWRTDTTM = True
		
RATMT51_MF_Clear_UWRTDTTM_End: 
		Exit Function
		
RATMT51_MF_Clear_UWRTDTTM_err: 
		GoTo RATMT51_MF_Clear_UWRTDTTM_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function RATMT51_MF_All_Clear_UWRTDTTM
	'   概要：  明細　対象行クリア処理
	'   引数：  pin_intIDX      : 対象行
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function RATMT51_MF_All_Clear_UWRTDTTM() As Boolean
		
		Dim I As Short
		
		On Error GoTo RATMT51_MF_All_Clear_UWRTDTTM_err
		
		RATMT51_MF_All_Clear_UWRTDTTM = False
		
		' 更新時間　配列クリア
		For I = 0 To UBound(M_RATMT_A_inf)
			M_RATMT_A_inf(I).OPEID = ""
			M_RATMT_A_inf(I).CLTID = ""
			M_RATMT_A_inf(I).WRTDT = ""
			M_RATMT_A_inf(I).WRTTM = ""
			M_RATMT_A_inf(I).UOPEID = ""
			M_RATMT_A_inf(I).UCLTID = ""
			M_RATMT_A_inf(I).UWRTDT = ""
			M_RATMT_A_inf(I).UWRTTM = ""
		Next I
		
		RATMT51_MF_All_Clear_UWRTDTTM = True
		
RATMT51_MF_All_Clear_UWRTDTTM_End: 
		Exit Function
		
RATMT51_MF_All_Clear_UWRTDTTM_err: 
		GoTo RATMT51_MF_All_Clear_UWRTDTTM_End
		
	End Function
	'20081002 ADD END   RISE)Tanimura
End Module