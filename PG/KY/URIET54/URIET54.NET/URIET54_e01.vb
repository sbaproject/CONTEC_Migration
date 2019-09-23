Option Strict Off
Option Explicit On
Module URIET54_E01
	'
	' スロット名        : 画面処理スロット
	' ユニット名        : URIET54.E01
	' 記述者            : Standard Library
	' 作成日付          : 1998/05/21
	' 使用プログラム名  : URIET54
	'
	Public WG_DSPKB As Short '1:シリアル№　2:受注番号（+行番号）
	Public Const WG_DKBSB As String = "040"
	Public SetFirst As Boolean
	Public svSRANO As String
	Public WG_JDNINKB As String '1:入力2:通販3:VAN4:WEB
	Public WG_SYSTEM As String 'M:MEIKBA(受注取引区分用）システム
	Public WG_JKESIKN As Decimal '入金消込（邦貨）
	Public WG_FKESIKN As Decimal '入金消込（外貨）
	'2007/11/28 FKS)minamoto ADD START
	Structure TYPE_HAITA_UPDDT
		Dim DATNO As String '伝票管理NO.
		Dim LINNO As String '行番号
		'2007/12/06 FKS)minamoto ADD START
		Dim WRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		Dim WRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		'2007/12/06 FKS)minamoto ADD END
		Dim UWRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)
		Dim UWRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)
		'20080910 ADD START RISE)Tanimura '排他処理
		Dim OPEID As String ' 最終作業者コード
		Dim CLTID As String ' クライアントＩＤ
		Dim UOPEID As String ' ユーザID（バッチ）
		Dim UCLTID As String ' クライアントＩＤ（バッチ）
		'20080910 ADD END   RISE)Tanimura
	End Structure
	'20080910 ADD START RISE)Tanimura '排他処理
	Private HAITA_JDNTHA As TYPE_HAITA_UPDDT
	'20080910 ADD END   RISE)Tanimura
	Private HAITA_UDNTRA() As TYPE_HAITA_UPDDT
	Private HAITA_JDNTRA() As TYPE_HAITA_UPDDT
	'2007/11/28 FKS)minamoto ADD END
	
	'20080910 ADD START RISE)Tanimura '排他処理
	'シリアル№登録ワーク
	Structure M_TYPE_SRAET52_MOTO
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(13),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=13)> Public SRANO() As Char ' シリアルNo.
	End Structure
	
	'シリアル管理テーブル（キー、更新時刻、更新日付、バッチ更新時刻、バッチ更新日付）　退避用
	Structure M_TYPE_SRACNTTB_MOTO
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(13),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=13)> Public SRANO() As Char ' シリアルNo.
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public JDNNO() As Char ' 受注番号
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public LINNO() As Char ' 行番号
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
	
	Public M_SRACNTTB_MOTO_inf() As M_TYPE_SRACNTTB_MOTO
	'20080910 ADD END   RISE)Tanimura
	
	'2008/1/22 FKS)ichihara ADD START
	Public UDEN_ZAIKB As String '読み込んだ時の在庫管理区分退避用
	'2008/1/22 FKS)ichihara ADD END
	
	Function DSPTRN() As Object
		Dim I As Short
		Dim wkJDNNO As String
		Dim WL_DATNO As String
		Dim wkJDNTRKB As String
		
		Dim strSQL As String
		Dim wkDATNO As String
		
		' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の追加
		Dim rResult As Short ' 処理チェック関数戻り値
		Dim Rtn As Short
		' === 20130708 === INSERT E
		
		' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の解除
		Call SSSWIN_Unlock_EXCTBZ()
		' === 20130708 === INSERT E -
		
		'シリアル№登録ワークの削除
		Call DB_BeginTransaction(CStr(BTR_Exclude))
		Call DB_GetGrEq(DBN_SRAET52, 1, SSS_CLTID.Value, BtrNormal)
		Do While (DBSTAT = 0) And (Trim(DB_SRAET52.RPTCLTID) = Trim(SSS_CLTID.Value))
			Call DB_Delete(DBN_SRAET52)
			Call DB_GetNext(DBN_SRAET52, BtrNormal)
		Loop 
		Call DB_EndTransaction()
		
		'返品倉庫
		Call FIXMTA_RClear()
		Call DB_GetEq(DBN_FIXMTA, 1, "513", BtrNormal)
		Call SOUMTA_RClear()
		Call DB_GetEq(DBN_SOUMTA, 1, Left(DB_FIXMTA.FIXVAL, Len(DB_SOUMTA.SOUCD)), BtrNormal)
		'2007/11/28 FKS)minamoto ADD START
		' 排他更新日付クリア
		
		ReDim HAITA_UDNTRA(0)
		ReDim HAITA_JDNTRA(0)
		'2007/11/28 FKS)minamoto ADD END
		
		'20080910 ADD START RISE)Tanimura '排他処理
		With HAITA_JDNTHA
			.DATNO = ""
			.OPEID = ""
			.CLTID = ""
			.WRTTM = ""
			.WRTDT = ""
			.UOPEID = ""
			.UCLTID = ""
			.UWRTTM = ""
			.UWRTDT = ""
		End With
		
		
		Erase M_SRACNTTB_MOTO_inf
		
		' ダミー作成
		ReDim M_SRACNTTB_MOTO_inf(0)
		'20080910 ADD END   RISE)Tanimura
		
		I = 0
		Call DP_SSSMAIN_SRANO(I, svSRANO)
		svSRANO = "" '2007/06/18 ADD
		
		WL_DATNO = Left(SSS_LASTKEY.Value, 10)
		
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		' 売上済の場合
		If g_strURIKB = "1" Then
			'20090115 ADD END   RISE)Tanimura
			Call DB_GetEq(DBN_UDNTHA, 1, WL_DATNO, BtrNormal)
			
			If DBSTAT = 0 Then
				Call SCR_FromUDNTHA(-1)
				Call DP_SSSMAIN_SOUCD(-1, Left(DB_FIXMTA.FIXVAL, 3))
				Call DP_SSSMAIN_SOUNM(-1, DB_SOUMTA.SOUNM)
				Call DB_GetGrEq(DBN_UDNTRA, 1, SSS_LASTKEY.Value, BtrNormal)
				
				'2008/04/07 FKS)ASANO ADD START
				Call JDNTRA_RClear()
				strSQL = ""
				strSQL = strSQL & "SELECT MAX(DATNO) FROM JDNTRA"
				strSQL = strSQL & " WHERE JDNNO = '" & DB_UDNTRA.JDNNO & "'"
				strSQL = strSQL & "   AND LINNO = '" & DB_UDNTRA.JDNLINNO & "'"
				Call DB_GetSQL2(DBN_JDNTRA, strSQL)
				wkDATNO = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
				
				Call JDNTRA_RClear()
				Call DB_GetEq(DBN_JDNTRA, 1, wkDATNO & DB_UDNTRA.JDNLINNO, BtrNormal)
				
				'Do While (DBSTAT = 0) And (Left(SSS_LASTKEY, 13) = DB_UDNTRA.DATNO & DB_UDNTRA.LINNO)
				'20090122 CHG START RISE)Tanimura '連絡票No.FC09012201
				'        Do While (DBSTAT = 0) And (Left(SSS_LASTKEY, 13) = DB_UDNTRA.DATNO & DB_UDNTRA.LINNO) And (DB_JDNTRA.DATKB = "1") And (DB_JDNTRA.AKAKROKB = "1")
				If (DBSTAT = 0) And (Left(SSS_LASTKEY.Value, 13) = DB_UDNTRA.DATNO & DB_UDNTRA.LINNO) And (DB_JDNTRA.DATKB = "1") And (DB_JDNTRA.AKAKROKB = "1") Then
					'20090122 CHG END   RISE)Tanimura
					'2008/04/07 FKS)ASANO ADD END
					Call SCR_FromMfil(I)
					'            Call ODNTRA_RClear
					'            Call DB_GetEq(DBN_ODNTRA, 2, "1" & "1" & DB_UDNTRA.ODNNO & DB_UDNTRA.ODNLINNO, BtrNormal)
					'            Call DP_SSSMAIN_ODNDT(-1, DB_ODNTRA.ODNDT)
					Call DB_GetEq(DBN_HINMTA, 1, DB_UDNTRA.HINCD, BtrNormal)
					Call DP_SSSMAIN_SERIKB(I, DB_HINMTA.SERIKB)
					Call DP_SSSMAIN_HINID(I, DB_HINMTA.HINID)
					wkJDNNO = Trim(DB_UDNTRA.JDNNO) & Mid(DB_UDNTRA.JDNLINNO, 2, 2)
					Call DP_SSSMAIN_JDNNO(I, wkJDNNO)
					
					' === 20130708 === INSERT S - FWEST)Koroyasu 排他制御の追加
					If Trim(DB_UDNTRA.JDNNO) <> "" Then
						'排他チェック
						rResult = SSSWIN_EXCTBZ_CHECK2(Left(DB_UDNTRA.JDNNO, 6))
						Select Case rResult
							'正常
							Case 0
								
								'排他処理中
							Case 1
								Rtn = DSP_MsgBox(SSS_ERROR, "_EXCADD", 0) '他のプログラムで更新中のため、登録できません。
								'UPGRADE_WARNING: オブジェクト DSPTRN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								DSPTRN = -1
								Exit Function
								
								'異常終了
							Case 9
								Rtn = DSP_MsgBox(SSS_ERROR, "_DBACCESSERR    ", 0) '更新異常
								'UPGRADE_WARNING: オブジェクト DSPTRN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
								DSPTRN = -1
								Exit Function
						End Select
					End If
					' === 20130708 === INSERT E -
					
					Call DP_SSSMAIN_URISU(I, " ")
					Call DP_SSSMAIN_SURYO(I, DB_UDNTRA.URISU)
					Call DP_SSSMAIN_SBNSU(I, DB_UDNTRA.URISU)
					'2007/03/21 ADD-START
					Call DP_SSSMAIN_CASSU(I, DB_UDNTRA.CASSU)
					'2007/03/21 ADD-END
					WG_JKESIKN = DB_UDNTRA.JKESIKN
					WG_FKESIKN = DB_UDNTRA.FKESIKN
					'2007/11/28 FKS)minamoto ADD START
					'売上トラン：排他更新日付取得
					
					ReDim Preserve HAITA_UDNTRA(I)
					HAITA_UDNTRA(I).DATNO = DB_UDNTRA.DATNO
					HAITA_UDNTRA(I).LINNO = DB_UDNTRA.LINNO
					'2007/12/06 FKS)minamoto ADD START
					HAITA_UDNTRA(I).WRTDT = DB_UDNTRA.WRTDT
					HAITA_UDNTRA(I).WRTTM = DB_UDNTRA.WRTTM
					'2007/12/06 FKS)minamoto ADD END
					HAITA_UDNTRA(I).UWRTDT = DB_UDNTRA.UWRTDT
					HAITA_UDNTRA(I).UWRTTM = DB_UDNTRA.UWRTTM
					'2007/11/28 FKS)minamoto ADD END
					'20080910 ADD START RISE)Tanimura '排他処理
					HAITA_UDNTRA(I).OPEID = DB_UDNTRA.OPEID
					HAITA_UDNTRA(I).CLTID = DB_UDNTRA.CLTID
					HAITA_UDNTRA(I).UOPEID = DB_UDNTRA.UOPEID
					HAITA_UDNTRA(I).UCLTID = DB_UDNTRA.UCLTID
					'20080910 ADD END   RISE)Tanimura
					'ADD START FKS)INABA 2008/3/18 ******************************
					UDEN_ZAIKB = Trim(CStr(DB_UDNTRA.ZAIKB & ""))
					'ADD  END  FKS)INABA 2008/3/18 ******************************
					'
					'2008/04/07 FKS)ASANO ADD START
					'            Call JDNTRA_RClear
					'            strSQL = ""
					'            strSQL = strSQL & "SELECT MAX(DATNO) FROM JDNTRA"
					'            strSQL = strSQL & " WHERE JDNNO = '" & DB_UDNTRA.JDNNO & "'"
					'            strSQL = strSQL & "   AND LINNO = '" & DB_UDNTRA.JDNLINNO & "'"
					'            Call DB_GetSQL2(DBN_JDNTRA, strSQL)
					'            wkDATNO = Format(DB_ExtNum.ExtNum(0), "0000000000")
					
					'            Call JDNTRA_RClear
					'            Call DB_GetEq(DBN_JDNTRA, 1, wkDATNO & DB_UDNTRA.JDNLINNO, BtrNormal)
					
					
					'If (DBSTAT = 0) And (DB_JDNTRA.DATKB = "1") And (DB_JDNTRA.AKAKROKB = "1") Then
					'2008/04/07 FKS)ASANO ADD END
					
					Call DP_SSSMAIN_JDNDT(I, DB_JDNTRA.JDNDT)
					Call JDNTHA_RClear()
					Call DB_GetEq(DBN_JDNTHA, 1, DB_JDNTRA.DATNO, BtrNormal)
					WG_JDNINKB = DB_JDNTHA.JDNINKB
					Call MEIMTA_RClear()
					wkJDNTRKB = DB_JDNTHA.JDNTRKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_JDNTHA.JDNTRKB))
					
					'20080910 ADD START RISE)Tanimura '排他処理
					With HAITA_JDNTHA
						.DATNO = DB_JDNTHA.DATNO
						.OPEID = DB_JDNTHA.OPEID
						.CLTID = DB_JDNTHA.CLTID
						.WRTTM = DB_JDNTHA.WRTTM
						.WRTDT = DB_JDNTHA.WRTDT
						.UOPEID = DB_JDNTHA.UOPEID
						.UCLTID = DB_JDNTHA.UCLTID
						.UWRTTM = DB_JDNTHA.UWRTTM
						.UWRTDT = DB_JDNTHA.UWRTDT
					End With
					'20080910 ADD END   RISE)Tanimura
					
					Call DB_GetEq(DBN_MEIMTA, 2, "006" & wkJDNTRKB, BtrNormal)
					WG_SYSTEM = DB_MEIMTA.MEIKBA
					'2007/11/28 FKS)minamoto ADD START
					'受注トラン：排他更新日付取得
					
					ReDim Preserve HAITA_JDNTRA(I)
					HAITA_JDNTRA(I).DATNO = DB_JDNTRA.DATNO
					HAITA_JDNTRA(I).LINNO = DB_JDNTRA.LINNO
					'2007/12/06 FKS)minamoto ADD START
					HAITA_JDNTRA(I).WRTDT = DB_JDNTRA.WRTDT
					HAITA_JDNTRA(I).WRTTM = DB_JDNTRA.WRTTM
					'2007/12/06 FKS)minamoto ADD END
					HAITA_JDNTRA(I).UWRTDT = DB_JDNTRA.UWRTDT
					HAITA_JDNTRA(I).UWRTTM = DB_JDNTRA.UWRTTM
					'2007/11/28 FKS)minamoto ADD END
					'20080910 ADD START RISE)Tanimura '排他処理
					HAITA_JDNTRA(I).OPEID = DB_JDNTRA.OPEID
					HAITA_JDNTRA(I).CLTID = DB_JDNTRA.CLTID
					HAITA_JDNTRA(I).UOPEID = DB_JDNTRA.UOPEID
					HAITA_JDNTRA(I).UCLTID = DB_JDNTRA.UCLTID
					'20080910 ADD END   RISE)Tanimura
					
					'2008/04/07 FKS)ASANO ADD START
					'End If
					'2008/04/07 FKS)ASANO ADD END
					I = I + 1
					Call DB_GetNext(DBN_UDNTRA, BtrNormal)
					
					'2008/04/07 FKS)ASANO ADD START
					Call JDNTRA_RClear()
					strSQL = ""
					strSQL = strSQL & "SELECT MAX(DATNO) FROM JDNTRA"
					strSQL = strSQL & " WHERE JDNNO = '" & DB_UDNTRA.JDNNO & "'"
					strSQL = strSQL & "   AND LINNO = '" & DB_UDNTRA.JDNLINNO & "'"
					Call DB_GetSQL2(DBN_JDNTRA, strSQL)
					wkDATNO = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
					
					Call JDNTRA_RClear()
					Call DB_GetEq(DBN_JDNTRA, 1, wkDATNO & DB_UDNTRA.JDNLINNO, BtrNormal)
					'2008/04/07 FKS)ASANO ADD END
					'20090122 CHG START RISE)Tanimura '連絡票No.FC09012201
					'        Loop
				End If
				'20090122 CHG END   RISE)Tanimura
			End If
			Call DP_SSSMAIN_UDNDT(-1, DB_UNYMTA.UNYDT)
			Call DP_SSSMAIN_ODNDT(-1, DB_UDNTHA.UDNDT)
			'20090115 ADD START RISE)Tanimura '連絡票No.523
			' 未売上の場合
		Else
			Call DB_GetEq(DBN_ODNTHA, 1, WL_DATNO, BtrNormal)
			
			If DBSTAT = 0 Then
				Call SCR_FromODNTHA(-1)
				Call DP_SSSMAIN_SOUCD(-1, Left(DB_FIXMTA.FIXVAL, 3))
				Call DP_SSSMAIN_SOUNM(-1, DB_SOUMTA.SOUNM)
				
				Call SOUMTA_RClear()
				Call DB_GetEq(DBN_SOUMTA, 1, DB_ODNTHA.OUTSOUCD, BtrNormal)
				Call DP_SSSMAIN_OUTSOUNM(-1, DB_SOUMTA.SOUNM)
				
				Call DB_GetGrEq(DBN_ODNTRA, 1, SSS_LASTKEY.Value, BtrNormal)
				
				Call JDNTRA_RClear()
				strSQL = ""
				strSQL = strSQL & "SELECT MAX(DATNO) FROM JDNTRA"
				strSQL = strSQL & " WHERE JDNNO = '" & DB_ODNTRA.JDNNO & "'"
				strSQL = strSQL & "   AND LINNO = '" & DB_ODNTRA.JDNLINNO & "'"
				Call DB_GetSQL2(DBN_JDNTRA, strSQL)
				wkDATNO = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
				
				Call JDNTRA_RClear()
				Call DB_GetEq(DBN_JDNTRA, 1, wkDATNO & DB_ODNTRA.JDNLINNO, BtrNormal)
				
				If (DBSTAT = 0) And (Left(SSS_LASTKEY.Value, 13) = DB_ODNTRA.DATNO & DB_ODNTRA.LINNO) And (DB_JDNTRA.DATKB = "1") And (DB_JDNTRA.AKAKROKB = "1") Then
					Call SCR_FromJDNTRA(I)
					Call SCR_FromODNTRA(I)
					Call DB_GetEq(DBN_HINMTA, 1, DB_ODNTRA.HINCD, BtrNormal)
					Call DP_SSSMAIN_SERIKB(I, DB_HINMTA.SERIKB)
					Call DP_SSSMAIN_HINID(I, DB_HINMTA.HINID)
					wkJDNNO = Trim(DB_ODNTRA.JDNNO) & Mid(DB_ODNTRA.JDNLINNO, 2, 2)
					Call DP_SSSMAIN_JDNNO(I, wkJDNNO)
					Call DP_SSSMAIN_URISU(I, " ")
					Call DP_SSSMAIN_SURYO(I, DB_JDNTRA.OTPSU - DB_JDNTRA.URISU)
					Call DP_SSSMAIN_SBNSU(I, DB_JDNTRA.OTPSU - DB_JDNTRA.URISU)
					UDEN_ZAIKB = Trim(CStr(DB_JDNTRA.ZAIKB & ""))
					
					Call DP_SSSMAIN_JDNDT(I, DB_JDNTRA.JDNDT)
					Call JDNTHA_RClear()
					Call DB_GetEq(DBN_JDNTHA, 1, DB_JDNTRA.DATNO, BtrNormal)
					Call SCR_FromJDNTHA(-1)
					WG_JDNINKB = DB_JDNTHA.JDNINKB
					Call MEIMTA_RClear()
					wkJDNTRKB = DB_JDNTHA.JDNTRKB & Space(Len(DB_MEIMTA.MEICDA) - Len(DB_JDNTHA.JDNTRKB))
					
					With HAITA_JDNTHA
						.DATNO = DB_JDNTHA.DATNO
						.OPEID = DB_JDNTHA.OPEID
						.CLTID = DB_JDNTHA.CLTID
						.WRTTM = DB_JDNTHA.WRTTM
						.WRTDT = DB_JDNTHA.WRTDT
						.UOPEID = DB_JDNTHA.UOPEID
						.UCLTID = DB_JDNTHA.UCLTID
						.UWRTTM = DB_JDNTHA.UWRTTM
						.UWRTDT = DB_JDNTHA.UWRTDT
					End With
					
					Call DB_GetEq(DBN_MEIMTA, 2, "006" & wkJDNTRKB, BtrNormal)
					WG_SYSTEM = DB_MEIMTA.MEIKBA
					
					ReDim Preserve HAITA_JDNTRA(I)
					HAITA_JDNTRA(I).DATNO = DB_JDNTRA.DATNO
					HAITA_JDNTRA(I).LINNO = DB_JDNTRA.LINNO
					HAITA_JDNTRA(I).WRTDT = DB_JDNTRA.WRTDT
					HAITA_JDNTRA(I).WRTTM = DB_JDNTRA.WRTTM
					HAITA_JDNTRA(I).UWRTDT = DB_JDNTRA.UWRTDT
					HAITA_JDNTRA(I).UWRTTM = DB_JDNTRA.UWRTTM
					HAITA_JDNTRA(I).OPEID = DB_JDNTRA.OPEID
					HAITA_JDNTRA(I).CLTID = DB_JDNTRA.CLTID
					HAITA_JDNTRA(I).UOPEID = DB_JDNTRA.UOPEID
					HAITA_JDNTRA(I).UCLTID = DB_JDNTRA.UCLTID
					
					I = I + 1
					Call DB_GetNext(DBN_ODNTRA, BtrNormal)
					
					Call JDNTRA_RClear()
					strSQL = ""
					strSQL = strSQL & "SELECT MAX(DATNO) FROM JDNTRA"
					strSQL = strSQL & " WHERE JDNNO = '" & DB_ODNTRA.JDNNO & "'"
					strSQL = strSQL & "   AND LINNO = '" & DB_ODNTRA.JDNLINNO & "'"
					Call DB_GetSQL2(DBN_JDNTRA, strSQL)
					wkDATNO = VB6.Format(DB_ExtNum.ExtNum(0), "0000000000")
					
					Call JDNTRA_RClear()
					Call DB_GetEq(DBN_JDNTRA, 1, wkDATNO & DB_ODNTRA.JDNLINNO, BtrNormal)
				End If
			End If
			
			Call DP_SSSMAIN_UDNDT(-1, DB_UNYMTA.UNYDT)
			Call DP_SSSMAIN_ODNDT(-1, DB_ODNTHA.ODNDT)
		End If
		'20090115 ADD END   RISE)Tanimura
		
		'UPGRADE_WARNING: オブジェクト DSPTRN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DSPTRN = I
		
	End Function
	
	Sub INITDSP()
		'背景色の設定
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(2) = 1 '受注番号
		CL_SSSMAIN(5) = 1 '返品理由名
		CL_SSSMAIN(7) = 1 '返品状態名
		CL_SSSMAIN(9) = 1 '出荷元倉庫名
		CL_SSSMAIN(10) = 1 '入庫倉庫
		CL_SSSMAIN(11) = 1 '入庫倉庫名
		CL_SSSMAIN(12) = 1 '受注日
		CL_SSSMAIN(13) = 1 '出荷日
		CL_SSSMAIN(14) = 1 '得意先名
		CL_SSSMAIN(15) = 1 '納品先名
		CL_SSSMAIN(16) = 1 '入力担当者コード
		CL_SSSMAIN(17) = 1 '入力担当者名
		CL_SSSMAIN(38) = 1 '製品ｺｰﾄﾞ
		CL_SSSMAIN(39) = 1 '元製番
		CL_SSSMAIN(40) = 1 '型式
		CL_SSSMAIN(41) = 1 '品名
		CL_SSSMAIN(43) = 1 '単位
		
		Call DB_GetEq(DBN_SYSTBA, 1, "001", BtrNormal)
		Call DB_GetFirst(DBN_UNYMTA, 1, BtrNormal)
		
		SetFirst = False
		svSRANO = ""
		
		
	End Sub
	
	Function INQ_UPDATE() As Object
		Dim Rtn As Short
		'ADD START FKS)INABA 2008/3/18 ******************************
		Dim rtn2 As New VB6.FixedLengthString(1)
		'ADD  END  FKS)INABA 2008/3/18 ******************************
		'
		'UPGRADE_WARNING: オブジェクト INQ_UPDATE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		INQ_UPDATE = 5
		
		'
		'20080910 DEL START RISE)Tanimura '排他処理
		'    '2007/11/28 FKS)minamoto ADD START
		'    '排他更新時間チェック
		'
		'    Rtn = CHK_HAITA_UPD
		'    If Rtn = 0 Then
		'        'エラー
		''2008/2/28 FKS)ichihara ADD START
		'        'タイムスタンプチェックでエラーの場合ロック解除
		'        Call DB_Execute(DBN_UDNTRA, "ROLLBACK")
		'        Call DB_Execute(DBN_JDNTRA, "ROLLBACK")
		''2008/2/28 FKS)ichihara ADD END
		'        Rtn = DSP_MsgBox(SSS_ERROR, "URIET54_001", 0) '他のプログラムで更新されたため、削除できません。
		'        INQ_UPDATE = 0
		'        Exit Function
		'    End If
		'    '2007/11/28 FKS)minamoto ADD END
		'20080910 DEL END   RISE)Tanimura
		
		'2008/1/22 FKS)ichihara ADD START
		'在庫管理区分が9の商品の場合エラー
		'CHG START FKS)INABA 2008/3/18 ******************************
		rtn2.Value = CHK_ZAIKOKB(Trim(CStr(DB_HINMTA.HINCD & "")))
		If Trim(rtn2.Value) = "9" And Trim(UDEN_ZAIKB) = "1" Then
			'    rtn = CHK_ZAIKOKB(Trim(CStr(DB_HINMTA.HINCD & "")))
			'    If rtn = "9" And UDEN_ZAIKB = 1 Then
			'CHG  END  FKS)INABA 2008/3/18 ******************************
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54_004", 0) '在庫管理しないに変更されています。
			'UPGRADE_WARNING: オブジェクト INQ_UPDATE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			INQ_UPDATE = 0
			Exit Function
		End If
		'2008/1/22 FKS)ichihara ADD END
		
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		' 未売上で初期不良はエラー
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HENRSNCD(0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If g_strURIKB = "2" And RD_SSSMAIN_HENRSNCD(0) = "15" Then
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54_005", 0) '未売上のため、返品理由に初期不良は選択できません。
			'UPGRADE_WARNING: オブジェクト INQ_UPDATE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			INQ_UPDATE = 0
			Exit Function
		End If
		'20090115 ADD END   RISE)Tanimura
		'ADD START FKS)INABA 2009/09/03 **************************************************
		'新入金対応
		If (WG_JKESIKN = 0) And (WG_FKESIKN = 0) Then
		Else
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HENRSNCD(0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If DB_UDNTHA.URIKJN <> "02" And RD_SSSMAIN_HENRSNCD(0) <> "15" Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 2) '入金済みの為エラー
				'UPGRADE_WARNING: オブジェクト INQ_UPDATE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				INQ_UPDATE = 0
				Exit Function
			End If
		End If
		'ADD  END FKS)INABA 2009/09/03 **************************************************
		Select Case SSS_BILFL
			Case 1 ' 伝票発行有り
				' 伝票発行の場合はメッセージ確認をしないのでここでウィンドウを表示する
				DLGLST3.ShowDialog()
				Select Case SSSVal(SSS_RTNWIN)
					Case 0 ' 計上＋発行
						Rtn = DELTRN()
						Rtn = WRTTRN()
						'1999/12/01 更新エラーの場合には伝票発行しない
						If Rtn = True Then Call PRNBIL()
						'Call PRNBIL
					Case 1 ' 計上のみ
						Rtn = DELTRN()
						Rtn = WRTTRN()
					Case 2 ' 発行のみ
						Call PRNBIL()
					Case Else ' 戻る
						'UPGRADE_WARNING: オブジェクト INQ_UPDATE の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						INQ_UPDATE = 0
				End Select
			Case 9 ' 計上のみ
				Rtn = DELTRN()
				Rtn = WRTTRN()
		End Select
	End Function
	
	' プリンタ切り替え機能を有効にする場合は以下のコメントアウト部分を有効にする。
	' 次にＳＦＤまたはＰＤＢで画面の”CM_LCONFIG”イメージを非表示から表示へ変更する。
	Function LCONFIG_GetEvent() As Short
		'   ' プリンター設定
		'    LCONFIG_GetEvent = True
		'    DB_SYSTBI.PRGID = SSS_PrgId
		'    DB_SYSTBI.LSTID = RD_SSSMAIN_LSTID(0)
		'    Call DB_GetEq(DBN_SYSTBI, 1, DB_SYSTBI.PRGID & DB_SYSTBI.LSTID, BtrNormal)
		'    If DBSTAT = 0 Then
		'        SSS_RPTID = Trim$(DB_SYSTBI.RPTID)
		'    Else
		'        SSS_RPTID = ""
		'    End If
		'    WLS_PRN.Show 1
	End Function
	'2007/11/28 FKS)minamoto ADD START
	Function CHK_HAITA_UPD() As Object
		Dim I As Short
		Dim strSQL As String
		
		'UPGRADE_WARNING: オブジェクト CHK_HAITA_UPD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CHK_HAITA_UPD = 1
		
		'20080910 ADD START RISE)Tanimura '排他処理
		'受注見出トラン
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
		strSQL = strSQL & "  JDNTHA "
		strSQL = strSQL & "WHERE"
		strSQL = strSQL & "  DATNO = '" & HAITA_JDNTHA.DATNO & "' "
		
		strSQL = strSQL & "FOR UPDATE"
		
		Call DB_GetSQL2(DBN_JDNTHA, strSQL)
		
		If Trim(DB_JDNTHA.OPEID) <> Trim(HAITA_JDNTHA.OPEID) Or Trim(DB_JDNTHA.CLTID) <> Trim(HAITA_JDNTHA.CLTID) Or Trim(DB_JDNTHA.WRTDT) <> Trim(HAITA_JDNTHA.WRTDT) Or Trim(DB_JDNTHA.WRTTM) <> Trim(HAITA_JDNTHA.WRTTM) Or Trim(DB_JDNTHA.UOPEID) <> Trim(HAITA_JDNTHA.UOPEID) Or Trim(DB_JDNTHA.UCLTID) <> Trim(HAITA_JDNTHA.UCLTID) Or Trim(DB_JDNTHA.UWRTDT) <> Trim(HAITA_JDNTHA.UWRTDT) Or Trim(DB_JDNTHA.UWRTTM) <> Trim(HAITA_JDNTHA.UWRTTM) Then
			'エラー
			'UPGRADE_WARNING: オブジェクト CHK_HAITA_UPD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CHK_HAITA_UPD = 0
			Exit Function
		End If
		'20080910 ADD END   RISE)Tanimura
		
		I = 0
		Do While I < PP_SSSMAIN.LastDe
			'20090115 ADD START RISE)Tanimura '連絡票No.523
			' 売上済の場合
			If g_strURIKB = "1" Then
				'20090115 ADD END   RISE)Tanimura
				'売上トラン
				
				strSQL = ""
				'2008/2/28 FKS)ichihara ADD START
				'        '2007/12/06 FKS)minamoto CHG START
				'        'strSQL = "SELECT MAX(UWRTDT),MAX(UWRTTM) FROM UDNTRA"
				'        strSQL = "SELECT MAX(WRTDT),MAX(WRTTM),MAX(UWRTDT),MAX(UWRTTM) FROM UDNTRA"
				'        '2007/12/06 FKS)minamoto CHG END
				'20080910 CHG START RISE)Tanimura '排他処理
				'        strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM UDNTRA"
				strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM,OPEID,CLTID,UOPEID,UCLTID FROM UDNTRA"
				'20080910 CHG END   RISE)Tanimura
				'2008/2/28 FKS)ichihara ADD END
				strSQL = strSQL & " WHERE DATNO = '" & HAITA_UDNTRA(I).DATNO & "'"
				strSQL = strSQL & "  AND LINNO = '" & HAITA_UDNTRA(I).LINNO & "'"
				'2008/2/28 FKS)ichihara ADD START
				'ロックする
				strSQL = strSQL & "          FOR UPDATE"
				'2008/2/28 FKS)ichihara ADD END
				Call DB_GetSQL2(DBN_UDNTRA, strSQL)
				'2008/2/28 FKS)ichihara ADD START
				'        '2007/12/04 FKS)minamoto CHG START
				'        'If HAITA_UDNTRA(I).UWRTDT <> CStr(DB_ExtNum.ExtNum(0)) Or HAITA_UDNTRA(I).UWRTTM <> CStr(DB_ExtNum.ExtNum(1)) Then
				'        '2007/12/06 FKS)minamoto CHG START
				'        'If Val(HAITA_UDNTRA(I).UWRTDT) <> Val(CStr(DB_ExtNum.ExtNum(0))) Or Val(HAITA_UDNTRA(I).UWRTTM) <> Val(CStr(DB_ExtNum.ExtNum(1))) Then
				'        If Val(HAITA_UDNTRA(I).WRTDT) <> Val(CStr(DB_ExtNum.ExtNum(0))) Or Val(HAITA_UDNTRA(I).WRTTM) <> Val(CStr(DB_ExtNum.ExtNum(1))) Or _
				''            Val(HAITA_UDNTRA(I).UWRTDT) <> Val(CStr(DB_ExtNum.ExtNum(2))) Or Val(HAITA_UDNTRA(I).UWRTTM) <> Val(CStr(DB_ExtNum.ExtNum(3))) Then
				'        '2007/12/06 FKS)minamoto CHG END
				'        '2007/12/04 FKS)minamoto CHG END
				'20080910 CHG START RISE)Tanimura '排他処理
				'        If Val(HAITA_UDNTRA(I).WRTDT) <> Val(CStr(DB_UDNTRA.WRTDT)) Or Val(HAITA_UDNTRA(I).WRTTM) <> Val(CStr(DB_UDNTRA.WRTTM)) Or _
				''            Val(HAITA_UDNTRA(I).UWRTDT) <> Val(CStr(DB_UDNTRA.UWRTDT)) Or Val(HAITA_UDNTRA(I).UWRTTM) <> Val(CStr(DB_UDNTRA.UWRTTM)) Then
				If Trim(DB_UDNTRA.OPEID) <> Trim(HAITA_UDNTRA(I).OPEID) Or Trim(DB_UDNTRA.CLTID) <> Trim(HAITA_UDNTRA(I).CLTID) Or Trim(DB_UDNTRA.WRTDT) <> Trim(HAITA_UDNTRA(I).WRTDT) Or Trim(DB_UDNTRA.WRTTM) <> Trim(HAITA_UDNTRA(I).WRTTM) Or Trim(DB_UDNTRA.UOPEID) <> Trim(HAITA_UDNTRA(I).UOPEID) Or Trim(DB_UDNTRA.UCLTID) <> Trim(HAITA_UDNTRA(I).UCLTID) Or Trim(DB_UDNTRA.UWRTDT) <> Trim(HAITA_UDNTRA(I).UWRTDT) Or Trim(DB_UDNTRA.UWRTTM) <> Trim(HAITA_UDNTRA(I).UWRTTM) Then
					'20080910 CHG END   RISE)Tanimura
					'2008/2/28 FKS)ichihara ADD END
					'エラー
					'UPGRADE_WARNING: オブジェクト CHK_HAITA_UPD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					CHK_HAITA_UPD = 0
					Exit Function
				End If
				'20090115 ADD START RISE)Tanimura '連絡票No.523
			End If
			'20090115 ADD END   RISE)Tanimura
			'受注トラン
			
			strSQL = ""
			'2008/2/28 FKS)ichihara ADD START
			'        '2007/12/06 FKS)minamoto CHG START
			'        'strSQL = "SELECT MAX(UWRTDT),MAX(UWRTTM) FROM JDNTRA"
			'        strSQL = "SELECT MAX(WRTDT),MAX(WRTTM),MAX(UWRTDT),MAX(UWRTTM) FROM JDNTRA"
			'        '2007/12/06 FKS)minamoto CHG END
			'20080910 CHG START RISE)Tanimura '排他処理
			'        strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM FROM JDNTRA"
			strSQL = "SELECT WRTDT,WRTTM,UWRTDT,UWRTTM,OPEID,CLTID,UOPEID,UCLTID FROM JDNTRA"
			'20080910 CHG END   RISE)Tanimura
			'2008/2/28 FKS)ichihara ADD END
			strSQL = strSQL & " WHERE DATNO = '" & HAITA_JDNTRA(I).DATNO & "'"
			strSQL = strSQL & "  AND LINNO = '" & HAITA_JDNTRA(I).LINNO & "'"
			'2008/2/28 FKS)ichihara ADD START
			'ロックする
			strSQL = strSQL & "          FOR UPDATE"
			'2008/2/28 FKS)ichihara ADD END
			Call DB_GetSQL2(DBN_JDNTRA, strSQL)
			'2008/2/28 FKS)ichihara ADD START
			'        '2007/12/04 FKS)minamoto CHG START
			'        'If HAITA_JDNTRA(I).UWRTDT <> CStr(DB_ExtNum.ExtNum(0)) Or HAITA_JDNTRA(I).UWRTTM <> CStr(DB_ExtNum.ExtNum(1)) Then
			'        '2007/12/06 FKS)minamoto CHG START
			'        'If Val(HAITA_JDNTRA(I).UWRTDT) <> Val(CStr(DB_ExtNum.ExtNum(0))) Or Val(HAITA_JDNTRA(I).UWRTTM) <> Val(CStr(DB_ExtNum.ExtNum(1))) Then
			'        If Val(HAITA_JDNTRA(I).WRTDT) <> Val(CStr(DB_ExtNum.ExtNum(0))) Or Val(HAITA_JDNTRA(I).WRTTM) <> Val(CStr(DB_ExtNum.ExtNum(1))) Or _
			''            Val(HAITA_JDNTRA(I).UWRTDT) <> Val(CStr(DB_ExtNum.ExtNum(2))) Or Val(HAITA_JDNTRA(I).UWRTTM) <> Val(CStr(DB_ExtNum.ExtNum(3))) Then
			'        '2007/12/06 FKS)minamoto CHG END
			'        '2007/12/04 FKS)minamoto CHG END
			'20080910 CHG START RISE)Tanimura '排他処理
			'        If Val(HAITA_JDNTRA(I).WRTDT) <> Val(CStr(DB_JDNTRA.WRTDT)) Or Val(HAITA_JDNTRA(I).WRTTM) <> Val(CStr(DB_JDNTRA.WRTTM)) Or _
			''            Val(HAITA_JDNTRA(I).UWRTDT) <> Val(CStr(DB_JDNTRA.UWRTDT)) Or Val(HAITA_JDNTRA(I).UWRTTM) <> Val(CStr(DB_JDNTRA.UWRTTM)) Then
			If Trim(DB_JDNTRA.OPEID) <> Trim(HAITA_JDNTRA(I).OPEID) Or Trim(DB_JDNTRA.CLTID) <> Trim(HAITA_JDNTRA(I).CLTID) Or Trim(DB_JDNTRA.WRTDT) <> Trim(HAITA_JDNTRA(I).WRTDT) Or Trim(DB_JDNTRA.WRTTM) <> Trim(HAITA_JDNTRA(I).WRTTM) Or Trim(DB_JDNTRA.UOPEID) <> Trim(HAITA_JDNTRA(I).UOPEID) Or Trim(DB_JDNTRA.UCLTID) <> Trim(HAITA_JDNTRA(I).UCLTID) Or Trim(DB_JDNTRA.UWRTDT) <> Trim(HAITA_JDNTRA(I).UWRTDT) Or Trim(DB_JDNTRA.UWRTTM) <> Trim(HAITA_JDNTRA(I).UWRTTM) Then
				'20080910 CHG END   RISE)Tanimura
				'2008/2/28 FKS)ichihara ADD END
				'エラー
				'UPGRADE_WARNING: オブジェクト CHK_HAITA_UPD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CHK_HAITA_UPD = 0
				Exit Function
			End If
			
			I = I + 1
		Loop 
		
		'20080910 ADD START RISE)Tanimura '排他処理
		Dim J As Short
		
		For J = 1 To UBound(M_SRACNTTB_MOTO_inf)
			strSQL = ""
			strSQL = strSQL & "SELECT"
			strSQL = strSQL & "  SRANO "
			strSQL = strSQL & ", OPEID "
			strSQL = strSQL & ", CLTID "
			strSQL = strSQL & ", WRTTM "
			strSQL = strSQL & ", WRTDT "
			strSQL = strSQL & ", UOPEID "
			strSQL = strSQL & ", UCLTID "
			strSQL = strSQL & ", UWRTTM "
			strSQL = strSQL & ", UWRTDT "
			strSQL = strSQL & "FROM"
			strSQL = strSQL & "  SRACNTTB "
			strSQL = strSQL & "WHERE"
			strSQL = strSQL & "  SRANO = " & "'" & M_SRACNTTB_MOTO_inf(J).SRANO & "' "
			
			strSQL = strSQL & "FOR UPDATE"
			
			Call DB_GetSQL2(DBN_SRACNTTB, strSQL)
			
			If Trim(DB_SRACNTTB.OPEID) <> Trim(M_SRACNTTB_MOTO_inf(J).OPEID) Or Trim(DB_SRACNTTB.CLTID) <> Trim(M_SRACNTTB_MOTO_inf(J).CLTID) Or Trim(DB_SRACNTTB.WRTDT) <> Trim(M_SRACNTTB_MOTO_inf(J).WRTDT) Or Trim(DB_SRACNTTB.WRTTM) <> Trim(M_SRACNTTB_MOTO_inf(J).WRTTM) Or Trim(DB_SRACNTTB.UOPEID) <> Trim(M_SRACNTTB_MOTO_inf(J).UOPEID) Or Trim(DB_SRACNTTB.UCLTID) <> Trim(M_SRACNTTB_MOTO_inf(J).UCLTID) Or Trim(DB_SRACNTTB.UWRTDT) <> Trim(M_SRACNTTB_MOTO_inf(J).UWRTDT) Or Trim(DB_SRACNTTB.UWRTTM) <> Trim(M_SRACNTTB_MOTO_inf(J).UWRTTM) Then
				'エラー
				'UPGRADE_WARNING: オブジェクト CHK_HAITA_UPD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				CHK_HAITA_UPD = 0
				Exit Function
			End If
		Next J
		'20080910 ADD END   RISE)Tanimura
		
	End Function
	'2007/11/28 FKS)minamoto ADD END
	
	'2008/1/22 FKS)ichihara ADD START
	'商品マスタより在庫管理区分の取得を行う
	Function CHK_ZAIKOKB(ByVal pstrHinCd As String) As String
		
		Dim strSQL As String
		
		On Error GoTo CHK_ZAIKOKB_Err
		
		CHK_ZAIKOKB = ""
		
		strSQL = "SELECT ZAIKB"
		strSQL = strSQL & " FROM HINMTA"
		strSQL = strSQL & " WHERE HINCD = '" & pstrHinCd & "'"
		
		Call DB_GetSQL2(DBN_HINMTA, strSQL)
		
		If DBSTAT = 0 Then
			CHK_ZAIKOKB = Trim(CStr(DB_HINMTA.ZAIKB & ""))
		End If
		
CHK_ZAIKOKB_END: 
		Exit Function
		
CHK_ZAIKOKB_Err: 
		GoTo CHK_ZAIKOKB_END
	End Function
	'2008/1/22 FKS)ichihara ADD END
End Module