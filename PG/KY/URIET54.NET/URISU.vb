Option Strict Off
Option Explicit On
Module URISU_F52
	'
	' スロット名        : 返品数量・画面項目スロット
	' ユニット名        : URISU.F52
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/11
	' 使用プログラム名  : URIET54
	'
	Function URISU_Check(ByVal URISU As Object, ByVal SURYO As Object, ByVal SBNSU As Object, ByVal CASSU As Object, ByVal ODNDT As Object, ByVal HINCD As Object, ByVal HINID As Object, ByVal SBNNO As Object, ByVal SERIKB As Object, ByVal DE_INDEX As Object) As Object
		
		Dim Rtn As Short
		Dim strSQL As String
		'2007/11/28 FKS)minamoto ADD START
		Dim strJDNNO As String
		'2007/11/28 FKS)minamoto ADD END
		'2007/12/04 FKS)minamoto ADD START
		Dim lngOUTSMSU As Integer
		Dim lngHenpinSU As Integer
		'2007/12/04 FKS)minamoto ADD END
		'2007/12/20 FKS)minamoto ADD START
		Dim lngChgHINCD As Integer
		'2007/12/20 FKS)minamoto ADD END
		
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call DP_SSSMAIN_SBNSU(DE_INDEX, URISU)
		
		'UPGRADE_WARNING: オブジェクト URISU_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		URISU_Check = 0
		
		''''2007/03/21 UPD-START
		''''If URISU > RD_SSSMAIN_SURYO(DE_INDEX) Then
		''''    Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 3)  '返品数以上の為エラー
		''''    URISU_Check = -1
		''''    Exit Function
		''''End If
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal(RD_SSSMAIN_CASSU(DE_INDEX)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(RD_SSSMAIN_CASSU(DE_INDEX)) = 0 Then
			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SURYO(DE_INDEX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If URISU > RD_SSSMAIN_SURYO(DE_INDEX) Then
				'20090115 ADD START RISE)Tanimura '連絡票No.523
				' 売上済の場合
				If g_strURIKB = "1" Then
					'20090115 ADD END   RISE)Tanimura
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 8) '売上数以上の為エラー
					'20090115 ADD START RISE)Tanimura '連絡票No.523
				Else
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54_006", 0) '出荷数以上の返品数は入力できません
				End If
				'20090115 ADD END   RISE)Tanimura
				'UPGRADE_WARNING: オブジェクト URISU_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				URISU_Check = -1
				Exit Function
			End If
		Else
			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CASSU(DE_INDEX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If URISU > RD_SSSMAIN_CASSU(DE_INDEX) Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 8) '売上数以上の為エラー
				'UPGRADE_WARNING: オブジェクト URISU_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				URISU_Check = -1
				Exit Function
			End If
		End If
		''''2007/03/21 UPD-END
		
		'【通販】及び【システムで諸口商品】時、算出処理回避
		'''' UPD 2012/06/05  FWEST) T.Yamamoto    Start    連絡票№FC12060501
		'    If (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06") Then
		'通販で、初期不良の場合は一部返品可とする
		'UPGRADE_WARNING: オブジェクト HINID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HENRSNCD(DE_INDEX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (Trim(WG_JDNINKB) = "2" And RD_SSSMAIN_HENRSNCD(DE_INDEX) <> "15") Or (Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06") Then
			'''' UPD 2012/06/05  FWEST) T.Yamamoto    End
			'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If URISU <> 0 Then
				'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SURYO(DE_INDEX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If URISU <> RD_SSSMAIN_SURYO(DE_INDEX) Then
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 7) '返品数以上の為エラー
					'UPGRADE_WARNING: オブジェクト URISU_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					URISU_Check = -1
					Exit Function
				End If
			End If
		End If
		
		'UPGRADE_WARNING: オブジェクト SERIKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SERIKB = "1" Then
			strSQL = ""
			strSQL = strSQL & "SELECT COUNT(*) FROM SRAET52"
			strSQL = strSQL & " WHERE RPTCLTID = " & "'" & SSS_CLTID.Value & "'"
			'UPGRADE_WARNING: オブジェクト ODNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSQL = strSQL & "   AND RSTDT    = " & "'" & VB6.Format(ODNDT, "YYYYMMDD") & "'"
			'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSQL = strSQL & "   AND HINCD    = " & "'" & HINCD & "'"
			'UPGRADE_WARNING: オブジェクト SBNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			strSQL = strSQL & "   AND SBNNO    = " & "'" & SBNNO & "'"
			Call DB_GetSQL2(DBN_SRAET52, strSQL)
			
			'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If URISU < DB_ExtNum.ExtNum(0) Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 4) '返品数以上のｼﾘｱﾙが登録
				'UPGRADE_WARNING: オブジェクト URISU_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				URISU_Check = -1
			End If
		End If
		
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		' 売上済の場合
		If g_strURIKB = "1" Then
			'20090115 ADD END   RISE)Tanimura
			'2007/11/28 FKS)minamoto ADD START
			'初期不良なら代替出庫済数を超えない
			
			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HENRSNCD(DE_INDEX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If RD_SSSMAIN_HENRSNCD(DE_INDEX) = "15" Then
				'受注番号検索
				
				'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strJDNNO = RD_SSSMAIN_JDNNO(DE_INDEX)
				'2007/12/20 FKS)minamoto ADD START
				' 製番出庫ファイルの品番違い件数取得
				strSQL = ""
				strSQL = strSQL & "SELECT COUNT(*) FROM SBNTRA"
				strSQL = strSQL & " WHERE ORGSBNNO    = " & "'" & strJDNNO & "'"
				'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & "   AND HINCD    <> " & "'" & HINCD & "'"
				strSQL = strSQL & "   AND DATKB = '1'"
				Call DB_GetSQL2(DBN_SRAET52, strSQL)
				lngChgHINCD = DB_ExtNum.ExtNum(0)
				If lngChgHINCD > 0 Then
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54_003", 0) '製品コードが異なりますが、よろしいですか？
					If Rtn <> MsgBoxResult.Yes Then
						'UPGRADE_WARNING: オブジェクト URISU_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
						URISU_Check = -1
						Exit Function
					End If
				End If
				'2007/12/20 FKS)minamoto ADD END
				' 製番出庫ファイルから出庫済数を取得
				
				strSQL = ""
				strSQL = strSQL & "SELECT SUM(OUTSMSU) FROM SBNTRA"
				'2007/12/17 FKS)minamoto CHG START
				'strSQL = strSQL & " WHERE HINCD    = " & "'" & HINCD & "'"
				'2007/12/20 FKS)minamoto DEL START
				'strSQL = strSQL & " WHERE TOKCD    = " & "'" & RD_SSSMAIN_TOKCD(DE_INDEX) & "'"
				'2007/12/20 FKS)minamoto DEL END
				'2007/12/17 FKS)minamoto CHG END
				'2007/12/20 FKS)minamoto CHG START
				'strSQL = strSQL & "   AND ORGSBNNO    = " & "'" & strJDNNO & "'"
				strSQL = strSQL & " WHERE ORGSBNNO    = " & "'" & strJDNNO & "'"
				'2007/12/20 FKS)minamoto CHG END
				strSQL = strSQL & "   AND DATKB = '1'"
				Call DB_GetSQL2(DBN_SRAET52, strSQL)
				lngOUTSMSU = DB_ExtNum.ExtNum(0)
				'2007/12/04 FKS)minamoto ADD START
				' 初期不良テーブルから返品数を取得
				
				strSQL = ""
				strSQL = strSQL & "SELECT SUM(ABS(URISU)) FROM SKFTRA"
				'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				strSQL = strSQL & " WHERE HINCD    = " & "'" & HINCD & "'"
				strSQL = strSQL & "   AND SBNNO    = " & "'" & strJDNNO & "'"
				strSQL = strSQL & "   AND DATKB = '1'"
				Call DB_GetSQL2(DBN_SRAET52, strSQL)
				lngHenpinSU = DB_ExtNum.ExtNum(0)
				'2007/12/04 FKS)minamoto ADD END
				
				'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				If URISU > lngOUTSMSU - lngHenpinSU Then
					Rtn = DSP_MsgBox(SSS_CONFRM, "URIET54", 9) '代替出庫済数を超えています。
					'UPGRADE_WARNING: オブジェクト URISU_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
					URISU_Check = -1
				End If
			End If
			'2007/11/28 FKS)minamoto ADD END
			'20090115 ADD START RISE)Tanimura '連絡票No.523
		End If
		'20090115 ADD END   RISE)Tanimura
	End Function
	
	Function URISU_Slist(ByRef PP As clsPP, ByVal SBNSU As Object, ByVal ODNDT As Object, ByVal HINCD As Object, ByVal SBNNO As Object, ByVal SERIKB As Object, ByVal DE_INDEX As Object) As Object
		Dim I As Short
		Dim EXEPATH As String
		Dim strSQL As String
		
		
		'2008/08/06 ADD START FKS)NAKATA
		''シリアル№検索へのパラメータ(受注番号)
		Dim strJDNNO As String
		
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNLINNO(DE_INDEX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strJDNNO = Left(RD_SSSMAIN_JDNNO(DE_INDEX), 6) & RD_SSSMAIN_JDNLINNO(DE_INDEX)
		
		'2008/08/06 ADD E.N.D FKS)NAKATA
		
		'
		'UPGRADE_WARNING: オブジェクト SERIKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SERIKB = "9" Then
			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
			Exit Function
		End If
		
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call DP_SSSMAIN_URISU(DE_INDEX, RD_SSSMAIN_SBNSU(DE_INDEX))
		
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SSSVal(RD_SSSMAIN_URISU(DE_INDEX)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(RD_SSSMAIN_URISU(DE_INDEX)) = 0 Then
			'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
			Exit Function
		End If
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SURYO(DE_INDEX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU(DE_INDEX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If RD_SSSMAIN_URISU(DE_INDEX) > RD_SSSMAIN_SURYO(DE_INDEX) Then
			Exit Function
		End If
		
		'    Link_Index = Index
		'    mm_OPT2 = True
		'    FR_SSSMAIN.BD_URISU(Index).MousePointer = 11
		'    Call Link_Shell("BMNMT51")
		'    Shell (AE_AppPath$ & "\SRAET51.EXE /RPTCLTID:" & SSS_CLTID _
		''                & " /JDNNO:" & Trim(JDNNO) & " /JDNLINNO:" & JDNLINNO & " /HINCD:" & Trim(HINCD) & " /URISU:" & URISU)
		
		
		'2008/08/06 CHG START FKS)NAKATA
		''シリアル検索画面に渡すパラメータを受注番号に変更
		
		''    EXEPATH = AE_AppPath$ & "SRAET52.EXE /RPTCLTID:" & SSS_CLTID _
		'''            & " /RSTDT:" & Format(ODNDT, "YYYYMMDD") & " /HINCD:" & Trim(HINCD) _
		'''            & " /SBNNO:" & Trim(SBNNO) & " /URISU:" & RD_SSSMAIN_URISU(DE_INDEX)
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU(DE_INDEX) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SBNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		EXEPATH = AE_AppPath & "SRAET52.EXE /RPTCLTID:" & SSS_CLTID.Value & " /JDNNO:" & Trim(strJDNNO) & " /HINCD:" & Trim(HINCD) & " /SBNNO:" & Trim(SBNNO) & " /URISU:" & RD_SSSMAIN_URISU(DE_INDEX)
		'2008/08/06 CHG E.N.D FKS)NAKATA
		
		
		I = VBEXEC1(FR_SSSMAIN.Handle.ToInt32, 1, EXEPATH)
		'    FR_SSSMAIN.BD_URISU(Index).MousePointer = 2
		'    mm_OPT2 = False
		'
		
		'20080910 ADD START RISE)Tanimura '排他処理
		Dim M_SRAET52_inf() As M_TYPE_SRAET52_MOTO
		Dim intIndex As Short
		
		Erase M_SRAET52_inf
		
		strSQL = ""
		strSQL = strSQL & "SELECT"
		strSQL = strSQL & "  SRANO "
		strSQL = strSQL & "FROM"
		strSQL = strSQL & "  SRAET52 "
		strSQL = strSQL & "WHERE"
		strSQL = strSQL & "  RPTCLTID = " & "'" & SSS_CLTID.Value & "' "
		strSQL = strSQL & "AND"
		'UPGRADE_WARNING: オブジェクト ODNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "  RSTDT    = " & "'" & VB6.Format(ODNDT, "YYYYMMDD") & "' "
		strSQL = strSQL & "AND"
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "  HINCD    = " & "'" & HINCD & "' "
		strSQL = strSQL & "AND"
		'UPGRADE_WARNING: オブジェクト SBNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "  SBNNO    = " & "'" & SBNNO & "' "
		strSQL = strSQL & "ORDER BY"
		strSQL = strSQL & "  SRANO    ASC "
		
		Call DB_GetSQL2(DBN_SRAET52, strSQL)
		
		intIndex = 0
		
		' ダミー作成
		ReDim Preserve M_SRAET52_inf(intIndex)
		
		Do While (DBSTAT = 0)
			intIndex = intIndex + 1
			
			ReDim Preserve M_SRAET52_inf(intIndex)
			
			With M_SRAET52_inf(intIndex)
				.SRANO = DB_SRAET52.SRANO
			End With
			
			Call DB_GetNext(DBN_SRAET52, BtrNormal)
		Loop 
		
		
		intIndex = 0
		
		' 退避しているシリアル管理テーブルの内容を削除する
		Erase M_SRACNTTB_MOTO_inf
		
		' ダミー作成
		ReDim Preserve M_SRACNTTB_MOTO_inf(intIndex)
		
		For I = 1 To UBound(M_SRAET52_inf)
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
			strSQL = strSQL & "  SRANO = " & "'" & M_SRAET52_inf(I).SRANO & "' "
			
			Call DB_GetSQL2(DBN_SRACNTTB, strSQL)
			
			intIndex = intIndex + 1
			
			ReDim Preserve M_SRACNTTB_MOTO_inf(intIndex)
			
			With M_SRACNTTB_MOTO_inf(intIndex)
				.SRANO = M_SRAET52_inf(I).SRANO
				.OPEID = DB_SRACNTTB.OPEID
				.CLTID = DB_SRACNTTB.CLTID
				.WRTTM = DB_SRACNTTB.WRTTM
				.WRTDT = DB_SRACNTTB.WRTDT
				.UOPEID = DB_SRACNTTB.UOPEID
				.UCLTID = DB_SRACNTTB.UCLTID
				.UWRTTM = DB_SRACNTTB.UWRTTM
				.UWRTDT = DB_SRACNTTB.UWRTDT
			End With
		Next I
		'20080910 ADD END   RISE)Tanimura
		
		strSQL = ""
		strSQL = strSQL & "SELECT COUNT(*) FROM SRAET52"
		strSQL = strSQL & " WHERE RPTCLTID = " & "'" & SSS_CLTID.Value & "'"
		'UPGRADE_WARNING: オブジェクト ODNDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "   AND RSTDT    = " & "'" & VB6.Format(ODNDT, "YYYYMMDD") & "'"
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "   AND HINCD    = " & "'" & HINCD & "'"
		'UPGRADE_WARNING: オブジェクト SBNNO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		strSQL = strSQL & "   AND SBNNO    = " & "'" & SBNNO & "'"
		Call DB_GetSQL2(DBN_SRAET52, strSQL)
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call DP_SSSMAIN_SBNSU(DE_INDEX, DB_ExtNum.ExtNum(0))
		
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		URISU_Slist = RD_SSSMAIN_URISU(DE_INDEX)
		
	End Function
End Module