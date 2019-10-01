Option Strict Off
Option Explicit On
Module FIXMTA_M51
	'
	' スロット名        : 固定値登録・メインファイル更新スロット
	' ユニット名        : FIXMTA_M51
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/10
	' 使用プログラム名  : FIXMT51
	'
	
	' === 20081002 === INSERT S - RISE)Izumi
	'更新時刻、更新日付、バッチ更新時刻、バッチ更新日付　退避用
	Structure M_TYPE_FIXMT
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
	Public M_FIXMT_inf As M_TYPE_FIXMT
	Public M_FIXMT_A_inf() As M_TYPE_FIXMT
	' === 20081002 === INSERT E - RISE)Izumi
	
	Sub UPDMST()
		Dim I, J As Short
		Dim updkb As String
		Dim wkWRTTM, wkWRTDT As String
		
		'2007/12/13 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		Dim bolRet As Boolean
		Dim intRet As Short
		
		' === 20081002 === INSERT S - RISE)Izumi チェック項目追加
		Dim strOPEID As String '最終作業者コード
		Dim strCLTID As String 'クライアントＩＤ
		Dim strUOPEID As String '最終作業者コード（バッチ）
		Dim strUCLTID As String 'クライアントＩＤ（バッチ）
		' === 20081002 === INSERT E - RISE)Izumi
		Dim strWRTDT As String '更新日付
		Dim strWRTTM As String '更新時刻
		Dim strUWRTDT As String 'バッチ更新日付
		Dim strUWRTTM As String 'バッチ更新時刻
		'2007/12/13 add-end T.KAWAMUKAI
		
		'
		wkWRTTM = VB6.Format(Now, "hhmmss")
		wkWRTDT = VB6.Format(Now, "YYYYMMDD")
		'
		If gs_UPDAUTH = "9" Then
			Call MsgBox("更新権限がありません", MsgBoxStyle.OKOnly)
			Exit Sub
		End If
		
		'2008/07/10 START ADD FNAP)YAMANE 連絡票№：排他-56
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		'2008/07/10 E.N.D ADD FNAP)YAMANE 連絡票№：排他-56
		
		'2007/12/13 add-str T.KAWAMUKAI 訂正前に更新時間チェックを入れる
		'更新時間チェック（画面に表示されている明細分）
		I = 0
		Dim strSQL As String
		Do While I < PP_SSSMAIN.LastDe
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CTLCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190801 chg start
            'DB_FIXMTA.CTLCD = RD_SSSMAIN_CTLCD(I)
            DB_FIXMTA2.CTLCD = RD_SSSMAIN_CTLCD(I)

            '2007/12/14 add-str T.KAWAMUKAI
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CTLNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'DB_FIXMTA.CTLNM = RD_SSSMAIN_CTLNM(I)
            DB_FIXMTA2.CTLNM = RD_SSSMAIN_CTLNM(I)
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FIXVAL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'DB_FIXMTA.FIXVAL = RD_SSSMAIN_FIXVAL(I)
            DB_FIXMTA2.FIXVAL = RD_SSSMAIN_FIXVAL(I)
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_REMARK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'DB_FIXMTA.REMARK = RD_SSSMAIN_REMARK(I)
            DB_FIXMTA2.REMARK = RD_SSSMAIN_REMARK(I)
            '2007/12/14 add-end T.KAWAMUKAI

            'Call DB_GetEq(DBN_FIXMTA, 1, DB_FIXMTA.CTLCD, BtrNormal)
            Call DB_GetEq(DBN_FIXMTA, 1, DB_FIXMTA2.CTLCD, BtrNormal)
            If DBSTAT = 0 Then
                ' === 20081002 === INSERT S - RISE)Izumi チェック項目追加
                'strOPEID = DB_FIXMTA.OPEID '最終作業者コード
                'strCLTID = DB_FIXMTA.CLTID 'クライアントＩＤ
                'strUOPEID = DB_FIXMTA.UOPEID '最終作業者コード（バッチ）
                'strUCLTID = DB_FIXMTA.UCLTID 'クライアントＩＤ（バッチ）
                '' === 20081002 === INSERT E - RISE)Izumi
                'strWRTDT = DB_FIXMTA.WRTDT '更新日付
                'strWRTTM = DB_FIXMTA.WRTTM '更新時刻
                'strUWRTDT = DB_FIXMTA.UWRTDT 'バッチ更新日付
                'strUWRTTM = DB_FIXMTA.UWRTTM 'バッチ更新時刻
                strOPEID = DB_FIXMTA2.OPEID '最終作業者コード
                strCLTID = DB_FIXMTA2.CLTID 'クライアントＩＤ
                strUOPEID = DB_FIXMTA2.UOPEID '最終作業者コード（バッチ）
                strUCLTID = DB_FIXMTA2.UCLTID 'クライアントＩＤ（バッチ）
                ' === 20081002 === INSERT E - RISE)Izumi
                strWRTDT = DB_FIXMTA2.WRTDT '更新日付
                strWRTTM = DB_FIXMTA2.WRTTM '更新時刻
                strUWRTDT = DB_FIXMTA2.UWRTDT 'バッチ更新日付
                strUWRTTM = DB_FIXMTA2.UWRTTM 'バッチ更新時刻
                '20190801 chg end

                'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                updkb = RD_SSSMAIN_UPDKB(I)
				If updkb = "削除" Then
					'2008/07/10 START ADD FNAP)YAMANE 連絡票№：排他-56
					HaitaUpdFlg = 0
					strSQL = ""
					' === 20081002 === UPDATE S - RISE)Izumi チェック項目追加
					'                strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM FIXMTA"
					strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM FIXMTA"
					' === 20081002 === UPDATE E - RISE)Izumi
					'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CTLCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					strSQL = strSQL & " WHERE CTLCD = '" + RD_SSSMAIN_CTLCD(I) + "'"
					'ロックする
					strSQL = strSQL & "          FOR UPDATE"
					Call DB_GetSQL2(DBN_FIXMTA, strSQL)
					'2008/07/10 E.N.D ADD FNAP)YAMANE 連絡票№：排他-56
					
					'更新時間チェック
					' === 20081002 === UPDATE S - RISE)Izumi チェック項目追加
					'                bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					bolRet = FIXMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
					' === 20081002 === UPDATE E - RISE)Izumi
					If bolRet = False Then
						' === 20081002 === INSERT S - RISE)Izumi  メッセージを表示する前にロールバックを行う
						Call DB_Unlock(DBN_FIXMTA)
						Call DB_AbortTransaction()
						' === 20081002 === INSERT E - RISE)Izumi
						intRet = MF_DspMsg(gc_strMsgFIXMT51_E_DEL)
						'2008/07/10 START ADD FNAP)YAMANE 連絡票№：排他-56
						' === 20081002 === DELETE S - RISE)Izumi  メッセージを表示する前にロールバックを行う
						'                            Call DB_Unlock(DBN_FIXMTA)
						'                            Call DB_AbortTransaction
						' === 20081002 === DELETE E - RISE)Izumi
						HaitaUpdFlg = 1
						'2008/07/10 E.N.D ADD FNAP)YAMANE 連絡票№：排他-56
						Exit Sub
					End If
					
				Else
					'2007/12/18 upd-str T.KAWAMUKAI
					If updkb = "追加" Then
						' === 20081002 === INSERT S - RISE)Izumi  メッセージを表示する前にロールバックを行う
						Call DB_Unlock(DBN_FIXMTA)
						Call DB_AbortTransaction()
						' === 20081002 === INSERT E - RISE)Izumi
						intRet = MF_DspMsg(gc_strMsgFIXMT51_E_UPD)
						' === 20081002 === DELETE S - RISE)Izumi  メッセージを表示する前にロールバックを行う
						''2008/07/10 START ADD FNAP)YAMANE 連絡票№：排他-56
						'                            Call DB_Unlock(DBN_FIXMTA)
						'                            Call DB_AbortTransaction
						''2008/07/10 E.N.D ADD FNAP)YAMANE 連絡票№：排他-56
						' === 20081002 === DELETE E - RISE)Izumi
						'2007/12/21 add-str T.KAWAMUKAI
						Exit Sub
						'2007/12/21 add-end T.KAWAMUKAI
					Else
						'2008/07/10 START ADD FNAP)YAMANE 連絡票№：排他-56
						HaitaUpdFlg = 0
						strSQL = ""
						' === 20081002 === UPDATE S - RISE)Izumi チェック項目追加
						'                       strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM FIXMTA"
						strSQL = "SELECT OPEID,CLTID,WRTDT,WRTTM,UOPEID,UCLTID,UWRTDT,UWRTTM FROM FIXMTA"
						' === 20081002 === UPDATE E - RISE)Izumi
						'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CTLCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						strSQL = strSQL & " WHERE CTLCD = '" + RD_SSSMAIN_CTLCD(I) + "'"
						'ロックする
						strSQL = strSQL & "          FOR UPDATE"
						Call DB_GetSQL2(DBN_FIXMTA, strSQL)
						'2008/07/10 E.N.D ADD FNAP)YAMANE 連絡票№：排他-56
						'更新時間チェック
						' === 20081002 === UPDATE S - RISE)Izumi チェック項目追加
						'                    bolRet = MF_Chk_UWRTDTTM_T(strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
						bolRet = FIXMT51_MF_Chk_UWRTDTTM_T(strOPEID, strCLTID, strUOPEID, strUCLTID, strWRTDT, strWRTTM, strUWRTDT, strUWRTTM, I)
						' === 20081002 === UPDATE E - RISE)Izumi
						If bolRet = False Then
							' === 20081002 === INSERT S - RISE)Izumi  メッセージを表示する前にロールバックを行う
							Call DB_Unlock(DBN_FIXMTA)
							Call DB_AbortTransaction()
							' === 20081002 === INSERT E - RISE)Izumi
							intRet = MF_DspMsg(gc_strMsgFIXMT51_E_UPD)
							'2008/07/10 START ADD FNAP)YAMANE 連絡票№：排他-56
							' === 20081002 === DELETE S - RISE)Izumi  メッセージを表示する前にロールバックを行う
							'                            Call DB_Unlock(DBN_FIXMTA)
							'                            Call DB_AbortTransaction
							' === 20081002 === DELETE E - RISE)Izumi
							HaitaUpdFlg = 1
							'2008/07/10 E.N.D ADD FNAP)YAMANE 連絡票№：排他-56
							Exit Sub
						End If
					End If
					'2007/12/18 upd-end T.KAWAMUKAI
				End If
			End If
			I = I + 1
		Loop 
		'2007/12/13 add-end T.KAWAMUKAI
		
		'2008/07/10 START DEL FNAP)YAMANE 連絡票№：排他-56
		'上のチェックループの開始時点で宣言するように変更
		'    Call DB_BeginTransaction(BTR_Exclude)
		'2008/07/10 E.N.D DEL FNAP)YAMANE 連絡票№：排他-56
		I = 0
		Do While I < PP_SSSMAIN.LastDe
            'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CTLCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190801 chg start
            '         DB_FIXMTA.CTLCD = RD_SSSMAIN_CTLCD(I)
            '         'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CTLNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '         DB_FIXMTA.CTLNM = RD_SSSMAIN_CTLNM(I)
            ''UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FIXVAL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'DB_FIXMTA.FIXVAL = RD_SSSMAIN_FIXVAL(I)
            ''UPGRADE_WARNING: オブジェクト RD_SSSMAIN_REMARK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'DB_FIXMTA.REMARK = RD_SSSMAIN_REMARK(I)
            '         Call DB_GetEq(DBN_FIXMTA, 1, DB_FIXMTA.CTLCD, BtrLock)

            DB_FIXMTA2.CTLCD = RD_SSSMAIN_CTLCD(I)
            DB_FIXMTA2.CTLNM = RD_SSSMAIN_CTLNM(I)
            DB_FIXMTA2.FIXVAL = RD_SSSMAIN_FIXVAL(I)
            DB_FIXMTA2.REMARK = RD_SSSMAIN_REMARK(I)
            Call DB_GetEq(DBN_FIXMTA, 1, DB_FIXMTA2.CTLCD, BtrLock)
            '20190801 chg end
            If DBSTAT = 0 Then
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				updkb = RD_SSSMAIN_UPDKB(I)
                If updkb = "削除" Then
                    '20190801 chg start
                    'DB_FIXMTA.DATKB = "9"
                    'DB_FIXMTA.WRTTM = wkWRTTM
                    'DB_FIXMTA.WRTDT = wkWRTDT
                    'DB_FIXMTA.UOPEID = SSS_OPEID.Value
                    'DB_FIXMTA.UCLTID = SSS_CLTID.Value
                    'DB_FIXMTA.UWRTTM = wkWRTTM
                    'DB_FIXMTA.UWRTDT = wkWRTDT
                    'DB_FIXMTA.PGID = "FIXMT51"
                    DB_FIXMTA2.DATKB = "9"
                    DB_FIXMTA2.WRTTM = wkWRTTM
                    DB_FIXMTA2.WRTDT = wkWRTDT
                    DB_FIXMTA2.UOPEID = SSS_OPEID.Value
                    DB_FIXMTA2.UCLTID = SSS_CLTID.Value
                    DB_FIXMTA2.UWRTTM = wkWRTTM
                    DB_FIXMTA2.UWRTDT = wkWRTDT
                    DB_FIXMTA2.PGID = "FIXMT51"
                    Call DB_Update(DBN_FIXMTA, 1)
                Else
                    Call Mfil_FromSCR(I)
                    'DB_FIXMTA.DATKB = "1"
                    'DB_FIXMTA.WRTTM = wkWRTTM
                    'DB_FIXMTA.WRTDT = wkWRTDT
                    'DB_FIXMTA.UOPEID = SSS_OPEID.Value
                    'DB_FIXMTA.UCLTID = SSS_CLTID.Value
                    'DB_FIXMTA.UWRTTM = wkWRTTM
                    'DB_FIXMTA.UWRTDT = wkWRTDT
                    'DB_FIXMTA.PGID = "FIXMT51"
                    DB_FIXMTA2.DATKB = "1"
                    DB_FIXMTA2.WRTTM = wkWRTTM
                    DB_FIXMTA2.WRTDT = wkWRTDT
                    DB_FIXMTA2.UOPEID = SSS_OPEID.Value
                    DB_FIXMTA2.UCLTID = SSS_CLTID.Value
                    DB_FIXMTA2.UWRTTM = wkWRTTM
                    DB_FIXMTA2.UWRTDT = wkWRTDT
                    DB_FIXMTA2.PGID = "FIXMT51"
                    Call DB_Update(DBN_FIXMTA, 1)
				End If
			Else
				Call FIXMTA_RClear()
				Call Mfil_FromSCR(I)
                'DB_FIXMTA.DATKB = "1"
                'DB_FIXMTA.WRTFSTTM = wkWRTTM
                'DB_FIXMTA.WRTFSTDT = wkWRTDT
                'DB_FIXMTA.FOPEID = SSS_OPEID.Value
                'DB_FIXMTA.FCLTID = SSS_CLTID.Value
                'DB_FIXMTA.WRTTM = wkWRTTM
                'DB_FIXMTA.WRTDT = wkWRTDT
                'DB_FIXMTA.UOPEID = SSS_OPEID.Value
                'DB_FIXMTA.UCLTID = SSS_CLTID.Value
                'DB_FIXMTA.UWRTTM = wkWRTTM
                'DB_FIXMTA.UWRTDT = wkWRTDT
                'DB_FIXMTA.PGID = "FIXMT51"
                DB_FIXMTA2.DATKB = "1"
                DB_FIXMTA2.WRTFSTTM = wkWRTTM
                DB_FIXMTA2.WRTFSTDT = wkWRTDT
                DB_FIXMTA2.FOPEID = SSS_OPEID.Value
                DB_FIXMTA2.FCLTID = SSS_CLTID.Value
                DB_FIXMTA2.WRTTM = wkWRTTM
                DB_FIXMTA2.WRTDT = wkWRTDT
                DB_FIXMTA2.UOPEID = SSS_OPEID.Value
                DB_FIXMTA2.UCLTID = SSS_CLTID.Value
                DB_FIXMTA2.UWRTTM = wkWRTTM
                DB_FIXMTA2.UWRTDT = wkWRTDT
                DB_FIXMTA2.PGID = "FIXMT51"
                '20190801 chg end
                Call DB_Insert(DBN_FIXMTA, 1)
			End If
			I = I + 1
		Loop 
		Call DB_Unlock(DBN_FIXMTA)
		Call DB_EndTransaction()
	End Sub
	
	' === 20081002 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function FIXMT51_MF_Chk_UWRTDTTM_T
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
	'   備考：  多明細及び、固定値マスタ登録用
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function FIXMT51_MF_Chk_UWRTDTTM_T(ByVal pin_strOPEID As String, ByVal pin_strCLTID As String, ByVal pin_strUOPEID As String, ByVal pin_strUCLTID As String, ByVal pin_strWRTDT As String, ByVal pin_strWRTTM As String, ByVal pin_strUWRTDT As String, ByVal pin_strUWRTTM As String, ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo FIXMT51_MF_Chk_UWRTDTTM_T_err
		
		FIXMT51_MF_Chk_UWRTDTTM_T = False
		
		If InStr(Trim(M_FIXMT_A_inf(pin_intIDX).OPEID) & Trim(M_FIXMT_A_inf(pin_intIDX).CLTID) & Trim(M_FIXMT_A_inf(pin_intIDX).UOPEID) & Trim(M_FIXMT_A_inf(pin_intIDX).UCLTID) & Trim(M_FIXMT_A_inf(pin_intIDX).WRTDT) & Trim(M_FIXMT_A_inf(pin_intIDX).WRTTM) & Trim(M_FIXMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_FIXMT_A_inf(pin_intIDX).UWRTTM), "0") <> 0 Then
			
			'更新時間チェック
			If Trim(pin_strOPEID) & Trim(pin_strCLTID) & Trim(pin_strUOPEID) & Trim(pin_strUCLTID) & Trim(pin_strWRTDT) & Trim(pin_strWRTTM) & Trim(pin_strUWRTDT) & Trim(pin_strUWRTTM) <> Trim(M_FIXMT_A_inf(pin_intIDX).OPEID) & Trim(M_FIXMT_A_inf(pin_intIDX).CLTID) & Trim(M_FIXMT_A_inf(pin_intIDX).UOPEID) & Trim(M_FIXMT_A_inf(pin_intIDX).UCLTID) & Trim(M_FIXMT_A_inf(pin_intIDX).WRTDT) & Trim(M_FIXMT_A_inf(pin_intIDX).WRTTM) & Trim(M_FIXMT_A_inf(pin_intIDX).UWRTDT) & Trim(M_FIXMT_A_inf(pin_intIDX).UWRTTM) Then
				GoTo FIXMT51_MF_Chk_UWRTDTTM_T_End
			End If
		End If
		
		FIXMT51_MF_Chk_UWRTDTTM_T = True
		
FIXMT51_MF_Chk_UWRTDTTM_T_End: 
		Exit Function
		
FIXMT51_MF_Chk_UWRTDTTM_T_err: 
		GoTo FIXMT51_MF_Chk_UWRTDTTM_T_End
		
	End Function
	' === 20081002 === INSERT E - RISE)Izumi
	
	' === 20081002 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function FIXMT51_MF_UpDown_UWRTDTTM
	'   概要：  明細　削除・挿入処理
	'   引数：  pin_intIDX      : 対象行
	'           pin_intGYO      : 1…削除（行詰め）　-1…挿入（行下げ）
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function FIXMT51_MF_UpDown_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intGYO As Short) As Boolean
		
		On Error GoTo FIXMT51_MF_UpDown_UWRTDTTM_err
		
		FIXMT51_MF_UpDown_UWRTDTTM = False
		
		'更新時間　配列移動
		M_FIXMT_A_inf(pin_intIDX).OPEID = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).OPEID
		M_FIXMT_A_inf(pin_intIDX).CLTID = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).CLTID
		M_FIXMT_A_inf(pin_intIDX).UOPEID = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UOPEID
		M_FIXMT_A_inf(pin_intIDX).UCLTID = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UCLTID
		M_FIXMT_A_inf(pin_intIDX).WRTDT = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).WRTDT
		M_FIXMT_A_inf(pin_intIDX).WRTTM = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).WRTTM
		M_FIXMT_A_inf(pin_intIDX).UWRTDT = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT
		M_FIXMT_A_inf(pin_intIDX).UWRTTM = M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM
		
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).OPEID = ""
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).CLTID = ""
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UOPEID = ""
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UCLTID = ""
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).WRTDT = ""
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).WRTTM = ""
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UWRTDT = ""
		M_FIXMT_A_inf(pin_intIDX + pin_intGYO).UWRTTM = ""
		
		FIXMT51_MF_UpDown_UWRTDTTM = True
		
FIXMT51_MF_UpDown_UWRTDTTM_End: 
		Exit Function
		
FIXMT51_MF_UpDown_UWRTDTTM_err: 
		GoTo FIXMT51_MF_UpDown_UWRTDTTM_End
		
	End Function
	' === 20081002 === INSERT E - RISE)Izumi
	
	' === 20081002 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function FIXMT51_MF_SaveRestore_UWRTDTTM
	'   概要：  明細　退避・復元処理
	'   引数：  pin_intIDX      : 対象行
	'           pin_intKBN      : 0…退避　1…復元
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function FIXMT51_MF_SaveRestore_UWRTDTTM(ByVal pin_intIDX As Short, ByVal pin_intKBN As Short) As Boolean
		
		On Error GoTo FIXMT51_MF_SaveRestore_UWRTDTTM_err
		
		FIXMT51_MF_SaveRestore_UWRTDTTM = False
		
		If pin_intKBN = 0 Then
			'退避・復元処理
			M_FIXMT_inf.OPEID = M_FIXMT_A_inf(pin_intIDX).OPEID
			M_FIXMT_inf.CLTID = M_FIXMT_A_inf(pin_intIDX).CLTID
			M_FIXMT_inf.UOPEID = M_FIXMT_A_inf(pin_intIDX).UOPEID
			M_FIXMT_inf.UCLTID = M_FIXMT_A_inf(pin_intIDX).UCLTID
			M_FIXMT_inf.WRTDT = M_FIXMT_A_inf(pin_intIDX).WRTDT
			M_FIXMT_inf.WRTTM = M_FIXMT_A_inf(pin_intIDX).WRTTM
			M_FIXMT_inf.UWRTDT = M_FIXMT_A_inf(pin_intIDX).UWRTDT
			M_FIXMT_inf.UWRTTM = M_FIXMT_A_inf(pin_intIDX).UWRTTM
		Else
			'復元処理
			M_FIXMT_A_inf(pin_intIDX).OPEID = M_FIXMT_inf.OPEID
			M_FIXMT_A_inf(pin_intIDX).CLTID = M_FIXMT_inf.CLTID
			M_FIXMT_A_inf(pin_intIDX).UOPEID = M_FIXMT_inf.UOPEID
			M_FIXMT_A_inf(pin_intIDX).UCLTID = M_FIXMT_inf.UCLTID
			M_FIXMT_A_inf(pin_intIDX).WRTDT = M_FIXMT_inf.WRTDT
			M_FIXMT_A_inf(pin_intIDX).WRTTM = M_FIXMT_inf.WRTTM
			M_FIXMT_A_inf(pin_intIDX).UWRTDT = M_FIXMT_inf.UWRTDT
			M_FIXMT_A_inf(pin_intIDX).UWRTTM = M_FIXMT_inf.UWRTTM
		End If
		
		FIXMT51_MF_SaveRestore_UWRTDTTM = True
		
FIXMT51_MF_SaveRestore_UWRTDTTM_End: 
		Exit Function
		
FIXMT51_MF_SaveRestore_UWRTDTTM_err: 
		GoTo FIXMT51_MF_SaveRestore_UWRTDTTM_End
		
	End Function
	' === 20081002 === INSERT E - RISE)Izumi
	
	' === 20081002 === INSERT S - RISE)Izumi
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function FIXMT51_MF_Clear_UWRTDTTM
	'   概要：  明細　対象行クリア処理
	'   引数：  pin_intIDX      : 対象行
	'   戻値：　True：処理OK　False：処理NG
	'   備考：
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function FIXMT51_MF_Clear_UWRTDTTM(ByVal pin_intIDX As Short) As Boolean
		
		On Error GoTo FIXMT51_MF_Clear_UWRTDTTM_err
		
		FIXMT51_MF_Clear_UWRTDTTM = False
		'更新時間　配列クリア
		M_FIXMT_A_inf(pin_intIDX).OPEID = ""
		M_FIXMT_A_inf(pin_intIDX).CLTID = ""
		M_FIXMT_A_inf(pin_intIDX).UOPEID = ""
		M_FIXMT_A_inf(pin_intIDX).UCLTID = ""
		M_FIXMT_A_inf(pin_intIDX).WRTDT = ""
		M_FIXMT_A_inf(pin_intIDX).WRTTM = ""
		M_FIXMT_A_inf(pin_intIDX).UWRTDT = ""
		M_FIXMT_A_inf(pin_intIDX).UWRTTM = ""
		
		FIXMT51_MF_Clear_UWRTDTTM = True
		
FIXMT51_MF_Clear_UWRTDTTM_End: 
		Exit Function
		
FIXMT51_MF_Clear_UWRTDTTM_err: 
		GoTo FIXMT51_MF_Clear_UWRTDTTM_End
		
	End Function
	' === 20081002 === INSERT E - RISE)Izumi
End Module