Option Strict Off
Option Explicit On
Module UNTMTA_M51
	'
	' スロット名        : 単位マスタ・メインファイル更新スロット
	' ユニット名        : UNTMTA.M51
	' 記述者            : Standard Library
	' 作成日付          : 2006/05/29
	' 使用プログラム名  : UNTMT51
	'
	'20080929 ADD START RISE)Tanimura '排他処理
	Structure M_TYPE_UNTMT
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char ' 最終作業者コード
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char ' クライアントＩＤ
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char ' タイムスタンプ（時間）
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char ' タイムスタンプ（日付）
	End Structure
	Public M_UNTMT_inf As M_TYPE_UNTMT
	Public M_UNTMT_A_inf() As M_TYPE_UNTMT
	'20080929 ADD END   RISE)Tanimura
	
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
		
		'20080929 ADD START RISE)Tanimura '排他処理
		Dim strOPEID As String ' 最終作業者コード
		Dim strCLTID As String ' クライアントＩＤ
		Dim strSQL As String
		'20080929 ADD END   RISE)Tanimura
		
		'更新権限チェック
		If gs_UPDAUTH = "9" Then
			Call MsgBox("更新権限がありません。", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, SSS_PrgNm)
			Exit Sub
		End If
		
		'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-71
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-71
		
		'2007/12/14 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		'更新時間チェック（画面に表示されている明細分）
		I = 0
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_UNTMTA.UNTCD = RD_SSSMAIN_UNTCD(I)
			Call DB_GetEq(DBN_UNTMTA, 1, DB_UNTMTA.UNTCD, BtrNormal)
			If DBSTAT = 0 Then
				'20080929 CHG START RISE)Tanimura '排他処理
				'            strWRTDT = DB_UNTMTA.WRTDT            '更新日付
				'            strWRTTM = DB_UNTMTA.WRTTM            '更新時刻
				'            strUWRTDT = ""
				'            strUWRTTM = ""
				
				strOPEID = DB_UNTMTA.OPEID ' 最終作業者コード
				strCLTID = DB_UNTMTA.CLTID ' クライアントＩＤ
				strWRTDT = DB_UNTMTA.WRTDT ' タイムスタンプ（時間）
				strWRTTM = DB_UNTMTA.WRTTM ' タイムスタンプ（日付）
				'20080929 CHG END   RISE)Tanimura
				
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "削除" Then
					'20080929 CHG START RISE)Tanimura '排他処理
					''2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-71
					'                HaitaUpdFlg = 0
					'                Dim strSQL As String
					'                strSQL = ""
					'                strSQL = "SELECT WRTDT,WRTTM,WRTFSTDT,WRTFSTTM FROM UNTMTA"
					'                strSQL = strSQL + " WHERE UNTCD = '" + RD_SSSMAIN_UNTCD(I) + "'"
					'                'ロックする
					'                strSQL = strSQL & "          FOR UPDATE"
					'                Call DB_GetSQL2(DBN_UNTMTA, strSQL)
					'                strWRTDT = DB_UNTMTA.WRTDT            '更新日付
					'                strWRTTM = DB_UNTMTA.WRTTM            '更新時刻
					'                strUWRTDT = ""                        'バッチ更新日付
					'                strUWRTTM = ""                        'バッチ更新時刻
					''2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-71
					'
					'                '更新時間チェック
					'                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					
					HaitaUpdFlg = 0
					
					' 単位マスタ
					strSQL = ""
					strSQL = strSQL & "SELECT"
					strSQL = strSQL & "  OPEID "
					strSQL = strSQL & ", CLTID "
					strSQL = strSQL & ", WRTTM "
					strSQL = strSQL & ", WRTDT "
					strSQL = strSQL & "FROM"
					strSQL = strSQL & "  UNTMTA "
					strSQL = strSQL & "WHERE"
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strSQL = strSQL & "  UNTCD = '" + RD_SSSMAIN_UNTCD(I) + "' "
					strSQL = strSQL & "FOR UPDATE"
					
					Call DB_GetSQL2(DBN_UNTMTA, strSQL)
					
					strOPEID = DB_UNTMTA.OPEID ' 最終作業者コード
					strCLTID = DB_UNTMTA.CLTID ' クライアントＩＤ
					strWRTDT = DB_UNTMTA.WRTDT ' タイムスタンプ（時間）
					strWRTTM = DB_UNTMTA.WRTTM ' タイムスタンプ（日付）
					
					' 更新時間チェック
					bolRet = UNTMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strWRTTM, strWRTDT, I)
					'20080929 CHG END   RISE)Tanimura
					
					If bolRet = False Then
						intRet = MF_DspMsg(gc_strMsgUNTMT51_E_DEL)
						'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-71
						Call DB_Unlock(DBN_UNTMTA)
						Call DB_AbortTransaction()
						HaitaUpdFlg = 1
						'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-71
						Exit Sub
					End If
				Else
					'2007/12/18 upd-str T.KAWAMUKAI
					If updkb = "追加" Then
						intRet = MF_DspMsg(gc_strMsgUNTMT51_E_UPD)
						'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-71
						Call DB_Unlock(DBN_UNTMTA)
						Call DB_AbortTransaction()
						'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-71
						'2007/12/21 add-str T.KAWAMUKAI
						Exit Sub
						'2007/12/21 add-end T.KAWAMUKAI
					Else
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_UNTNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						If Trim(RD_SSSMAIN_UNTNM(I)) <> Trim(RD_SSSMAIN_V_UNTNM(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then
							'20080929 CHG START RISE)Tanimura '排他処理
							''2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-71
							'                       HaitaUpdFlg = 0
							'                       strSQL = ""
							'                       strSQL = "SELECT WRTDT,WRTTM,WRTFSTDT,WRTFSTTM FROM UNTMTA"
							'                       strSQL = strSQL + " WHERE UNTCD = '" + RD_SSSMAIN_UNTCD(I) + "'"
							'                       'ロックする
							'                       strSQL = strSQL & "          FOR UPDATE"
							'                       Call DB_GetSQL2(DBN_UNTMTA, strSQL)
							'                       strWRTDT = DB_UNTMTA.WRTDT            '更新日付
							'                       strWRTTM = DB_UNTMTA.WRTTM            '更新時刻
							'                       strUWRTDT = ""                        'バッチ更新日付
							'                       strUWRTTM = ""                        'バッチ更新時刻
							''2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-71
							'
							'                        '更新時間チェック
							'                        bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
							
							HaitaUpdFlg = 0
							
							' 単位マスタ
							strSQL = ""
							strSQL = strSQL & "SELECT"
							strSQL = strSQL & "  OPEID "
							strSQL = strSQL & ", CLTID "
							strSQL = strSQL & ", WRTTM "
							strSQL = strSQL & ", WRTDT "
							strSQL = strSQL & "FROM"
							strSQL = strSQL & "  UNTMTA "
							strSQL = strSQL & "WHERE"
							'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
							strSQL = strSQL & "  UNTCD = '" + RD_SSSMAIN_UNTCD(I) + "' "
							strSQL = strSQL & "FOR UPDATE"
							
							Call DB_GetSQL2(DBN_UNTMTA, strSQL)
							
							strOPEID = DB_UNTMTA.OPEID ' 最終作業者コード
							strCLTID = DB_UNTMTA.CLTID ' クライアントＩＤ
							strWRTDT = DB_UNTMTA.WRTDT ' タイムスタンプ（時間）
							strWRTTM = DB_UNTMTA.WRTTM ' タイムスタンプ（日付）
							
							' 更新時間チェック
							bolRet = UNTMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strWRTTM, strWRTDT, I)
							'20080929 CHG END   RISE)Tanimura
							
							If bolRet = False Then
								intRet = MF_DspMsg(gc_strMsgUNTMT51_E_UPD)
								'2008/07/11 START ADD FNAP)YAMANE 連絡票№：排他-71
								Call DB_Unlock(DBN_UNTMTA)
								Call DB_AbortTransaction()
								HaitaUpdFlg = 1
								'2008/07/11 E.N.D ADD FNAP)YAMANE 連絡票№：排他-71
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
		
		'2008/07/11 START DEL FNAP)YAMANE 連絡票№：排他-71
		'上部のチェックのループの開始時に宣言するように変更
		'    Call DB_BeginTransaction(BTR_Exclude)
		'2008/07/11 E.N.D DEL FNAP)YAMANE 連絡票№：排他-71
		
		Do While I < PP_SSSMAIN.LastDe
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DB_UNTMTA.UNTCD = RD_SSSMAIN_UNTCD(I)
			Call DB_GetEq(DBN_UNTMTA, 1, DB_UNTMTA.UNTCD, BtrLock)
			If DBSTAT = 0 Then
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "削除" Then
					'削除
					DB_UNTMTA.DATKB = "9"
					DB_UNTMTA.RELFL = "1"
					DB_UNTMTA.OPEID = SSS_OPEID.Value
					DB_UNTMTA.CLTID = SSS_CLTID.Value
					DB_UNTMTA.WRTTM = WRTTM
					DB_UNTMTA.WRTDT = WRTDT
					'                DB_UNTMTA.UOPEID = SSS_OPEID
					'                DB_UNTMTA.UCLTID = SSS_CLTID
					'                DB_UNTMTA.UWRTTM = WRTTM
					'                DB_UNTMTA.UWRTDT = WRTDT
					'                DB_UNTMTA.PGID = SSS_PrgId
					Call DB_Update(DBN_UNTMTA, 1)
				Else
					'更新
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_DATKB(I) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_V_UNTNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					If Trim(RD_SSSMAIN_UNTNM(I)) <> Trim(RD_SSSMAIN_V_UNTNM(I)) Or RD_SSSMAIN_V_DATKB(I) = "9" Then '2006.11.07
						Call Mfil_FromSCR(I)
						DB_UNTMTA.DATKB = "1"
						DB_UNTMTA.RELFL = "1"
						DB_UNTMTA.WRTTM = WRTTM
						DB_UNTMTA.WRTDT = WRTDT
						'                    DB_UNTMTA.UOPEID = SSS_OPEID
						'                    DB_UNTMTA.UCLTID = SSS_CLTID
						'                    DB_UNTMTA.UWRTTM = WRTTM
						'                    DB_UNTMTA.UWRTDT = WRTDT
						'                    DB_UNTMTA.PGID = SSS_PrgId
						Call DB_Update(DBN_UNTMTA, 1)
					End If '2006.11.07
				End If
			Else
                '追加
                '2019/09/25 DEL START
                'Call UNTMTA_RClear()
                '2019/09/25 DEL E N D
                Call Mfil_FromSCR(I)
				DB_UNTMTA.DATKB = "1"
				DB_UNTMTA.RELFL = "1"
				'            DB_UNTMTA.FOPEID = SSS_OPEID
				'            DB_UNTMTA.FCLTID = SSS_CLTID
				DB_UNTMTA.WRTFSTTM = WRTTM
				DB_UNTMTA.WRTFSTDT = WRTDT
				DB_UNTMTA.WRTTM = WRTTM
				DB_UNTMTA.WRTDT = WRTDT
				'            DB_UNTMTA.UOPEID = SSS_OPEID
				'            DB_UNTMTA.UCLTID = SSS_CLTID
				'            DB_UNTMTA.UWRTTM = WRTTM
				'            DB_UNTMTA.UWRTDT = WRTDT
				'            DB_UNTMTA.PGID = SSS_PrgId
				Call DB_Insert(DBN_UNTMTA, 1)
			End If
			I = I + 1
		Loop 
		Call DB_Unlock(DBN_UNTMTA)
		Call DB_EndTransaction()
	End Sub
	
	'20080929 ADD START RISE)Tanimura '排他処理
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function UNTMT51_MF_Chk_UWRTDTTM_T
	'   概要：  更新時間チェック処理
	'   引数：  pin_strOPEID    : 最終作業者コード
	'           pin_strCLTID    : クライアントＩＤ
	'           pin_strWRTTM    : タイムスタンプ（時間）
	'           pin_strWRTDT    : タイムスタンプ（日付）
	'           pin_intIDX      : 多明細の場合　　　　明細行（0～）
	'   戻値：　True：チェックOK　False：チェックNG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function UNTMT51_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strWRTTM As String, ByVal pin_strWRTDT As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo UNTMT51_MF_Chk_UWRTDTTM_T_err
		
		UNTMT51_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_UNTMT_A_inf(pin_intIDX).OPEID) & Trim(M_UNTMT_A_inf(pin_intIDX).CLTID) & Trim(M_UNTMT_A_inf(pin_intIDX).WRTTM) & Trim(M_UNTMT_A_inf(pin_intIDX).WRTDT), "0") <> 0 Then
			' 更新時間チェック
			If Trim(M_UNTMT_A_inf(pin_intIDX).OPEID) <> Trim(pin_strOPEID) Or Trim(M_UNTMT_A_inf(pin_intIDX).CLTID) <> Trim(pin_strCLTID) Or Trim(M_UNTMT_A_inf(pin_intIDX).WRTTM) <> Trim(pin_strWRTTM) Or Trim(M_UNTMT_A_inf(pin_intIDX).WRTDT) <> Trim(pin_strWRTDT) Then
				GoTo UNTMT51_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		UNTMT51_MF_Chk_UWRTDTTM_T = True
		
UNTMT51_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
UNTMT51_MF_Chk_UWRTDTTM_T_err: 
		GoTo UNTMT51_MF_Chk_UWRTDTTM_T_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function UNTMT51_MF_UpDown_UWRTDTTM
	'   概要：  明細　削除・挿入処理
	'   引数：  pin_intIDX      : 対象行
	'           pin_intGYO      : 1…削除（行詰め）　-1…挿入（行下げ）
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function UNTMT51_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo UNTMT51_MF_UpDown_UWRTDTTM_err
		
		UNTMT51_MF_UpDown_UWRTDTTM = False
		
		'更新時間　配列移動
		M_UNTMT_A_inf(pin_intIDX).OPEID = M_UNTMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_UNTMT_A_inf(pin_intIDX).CLTID = M_UNTMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_UNTMT_A_inf(pin_intIDX).WRTDT = M_UNTMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_UNTMT_A_inf(pin_intIDX).WRTTM = M_UNTMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		
		M_UNTMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_UNTMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_UNTMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_UNTMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		
		UNTMT51_MF_UpDown_UWRTDTTM = True
		
UNTMT51_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
UNTMT51_MF_UpDown_UWRTDTTM_err: 
		GoTo UNTMT51_MF_UpDown_UWRTDTTM_End
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function UNTMT_MF_SaveRestore_UWRTDTTM
	'   概要：  明細　退避・復元処理
	'   引数：  pin_intIDX      : 対象行
	'           pin_intKBN      : 0…退避　1…復元
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function UNTMT_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo UNTMT_MF_SaveRestore_UWRTDTTM_err
		
		UNTMT_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			' 退避・復元処理
			M_UNTMT_inf.OPEID = M_UNTMT_A_inf(pin_intIDX).OPEID
			M_UNTMT_inf.CLTID = M_UNTMT_A_inf(pin_intIDX).CLTID
			M_UNTMT_inf.WRTDT = M_UNTMT_A_inf(pin_intIDX).WRTDT
			M_UNTMT_inf.WRTTM = M_UNTMT_A_inf(pin_intIDX).WRTTM
		Else
			' 復元処理
			M_UNTMT_A_inf(pin_intIDX).OPEID = M_UNTMT_inf.OPEID
			M_UNTMT_A_inf(pin_intIDX).CLTID = M_UNTMT_inf.CLTID
			M_UNTMT_A_inf(pin_intIDX).WRTDT = M_UNTMT_inf.WRTDT
			M_UNTMT_A_inf(pin_intIDX).WRTTM = M_UNTMT_inf.WRTTM
		End If
		
		UNTMT_MF_SaveRestore_UWRTDTTM = True
		
UNTMT_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
UNTMT_MF_SaveRestore_UWRTDTTM_err: 
		GoTo UNTMT_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	'20080929 ADD END   RISE)Tanimura
End Module