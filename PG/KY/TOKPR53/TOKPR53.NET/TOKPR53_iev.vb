Option Strict Off
Option Explicit On
Module TOKPR53_IEV
	Public Const SSS_MAX_DB As Short = 19
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "TOKPR53"
	'''' UPD 2009/12/25  FKS) T.Yamamoto    Start    連絡票№FC09122501
	'Global Const SSS_PrgNm = "製品別得意先別ﾛｯﾄ単価一覧ﾘｽﾄ  "
	Public Const SSS_PrgNm As String = "得意先別ﾛｯﾄ単価マスタ一覧リスト"
	'''' UPD 2009/12/25  FKS) T.Yamamoto    End
	Public Const SSS_FraId As String = "PR2"
	Public WG_OPEID As String
	Public WG_OPENM As String
	Public WG_STTHINCD As String
	Public WG_STTHINNM As String
	Public WG_ENDHINCD As String
	Public WG_ENDHINNM As String
	Public WG_STTTOKCD As String
	Public WG_STTTOKNM As String
	Public WG_ENDTOKCD As String
	Public WG_ENDTOKNM As String
	
	Sub Init_Fil() 'Generated.
		'
		DBN_TOKPR53 = 0
		DB_PARA(DBN_TOKPR53).TBLID = "TOKPR53"
		DB_PARA(DBN_TOKPR53).DBID = "USR9"
		SSS_MFIL = DBN_TOKPR53
		'
		DBN_SYSTBA = 1
		DB_PARA(DBN_SYSTBA).TBLID = "SYSTBA"
		DB_PARA(DBN_SYSTBA).DBID = "USR1"
		'
		DBN_SYSTBB = 2
		DB_PARA(DBN_SYSTBB).TBLID = "SYSTBB"
		DB_PARA(DBN_SYSTBB).DBID = "USR1"
		'
		DBN_SYSTBC = 3
		DB_PARA(DBN_SYSTBC).TBLID = "SYSTBC"
		DB_PARA(DBN_SYSTBC).DBID = "USR1"
		'
		DBN_SYSTBD = 4
		DB_PARA(DBN_SYSTBD).TBLID = "SYSTBD"
		DB_PARA(DBN_SYSTBD).DBID = "USR1"
		'
		DBN_SYSTBF = 5
		DB_PARA(DBN_SYSTBF).TBLID = "SYSTBF"
		DB_PARA(DBN_SYSTBF).DBID = "USR1"
		'
		DBN_SYSTBG = 6
		DB_PARA(DBN_SYSTBG).TBLID = "SYSTBG"
		DB_PARA(DBN_SYSTBG).DBID = "USR1"
		'
		DBN_SYSTBH = 7
		DB_PARA(DBN_SYSTBH).TBLID = "SYSTBH"
		DB_PARA(DBN_SYSTBH).DBID = "USR1"
		'
		DBN_CLSMTA = 8
		DB_PARA(DBN_CLSMTA).TBLID = "CLSMTA"
		DB_PARA(DBN_CLSMTA).DBID = "USR1"
		'
		DBN_CLSMTB = 9
		DB_PARA(DBN_CLSMTB).TBLID = "CLSMTB"
		DB_PARA(DBN_CLSMTB).DBID = "USR1"
		'
		DBN_TANMTA = 10
		DB_PARA(DBN_TANMTA).TBLID = "TANMTA"
		DB_PARA(DBN_TANMTA).DBID = "USR1"
		'
		DBN_UNYMTA = 11
		DB_PARA(DBN_UNYMTA).TBLID = "UNYMTA"
		DB_PARA(DBN_UNYMTA).DBID = "USR1"
		'
		DBN_TOKMTD = 12
		DB_PARA(DBN_TOKMTD).TBLID = "TOKMTD"
		DB_PARA(DBN_TOKMTD).DBID = "USR1"
		'
		DBN_TOKMTA = 13
		DB_PARA(DBN_TOKMTA).TBLID = "TOKMTA"
		DB_PARA(DBN_TOKMTA).DBID = "USR1"
		'
		DBN_HINMTA = 14
		DB_PARA(DBN_HINMTA).TBLID = "HINMTA"
		DB_PARA(DBN_HINMTA).DBID = "USR1"
		'
		DBN_MEIMTA = 15
		DB_PARA(DBN_MEIMTA).TBLID = "MEIMTA"
		DB_PARA(DBN_MEIMTA).DBID = "USR1"
		'
		DBN_EXCTBZ = 16
		DB_PARA(DBN_EXCTBZ).TBLID = "EXCTBZ"
		DB_PARA(DBN_EXCTBZ).DBID = "USR1"
		'
		DBN_GYMTBZ = 17
		DB_PARA(DBN_GYMTBZ).TBLID = "GYMTBZ"
		DB_PARA(DBN_GYMTBZ).DBID = "USR1"
		'
		DBN_KNGMTB = 18
		DB_PARA(DBN_KNGMTB).TBLID = "KNGMTB"
		DB_PARA(DBN_KNGMTB).DBID = "USR1"
		
		SSS_LSTMFIL = DBN_TOKPR53
	End Sub
	
	Sub SCR_FromTANMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_OPENM(De, DB_TANMTA.TANNM)
	End Sub
	
	Sub TANMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPENM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TANMTA.TANNM = RD_SSSMAIN_OPENM(De)
		DB_TANMTA.OPEID = SSS_OPEID.Value
		DB_TANMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_TANMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_TANMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_TANMTA.WRTTM = DB_ORATM
			DB_TANMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_ENDHINCD(De, DB_TOKPR53.ENDHINCD)
		Call DP_SSSMAIN_ENDHINNM(De, DB_TOKPR53.ENDHINNM)
		Call DP_SSSMAIN_ENDTOKCD(De, DB_TOKPR53.ENDTOKCD)
		Call DP_SSSMAIN_ENDTOKNM(De, DB_TOKPR53.ENDTOKNM)
		Call DP_SSSMAIN_STTHINCD(De, DB_TOKPR53.STTHINCD)
		Call DP_SSSMAIN_STTHINNM(De, DB_TOKPR53.STTHINNM)
		Call DP_SSSMAIN_STTTOKCD(De, DB_TOKPR53.STTTOKCD)
		Call DP_SSSMAIN_STTTOKNM(De, DB_TOKPR53.STTTOKNM)
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDHINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKPR53.ENDHINCD = RD_SSSMAIN_ENDHINCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDHINNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKPR53.ENDHINNM = RD_SSSMAIN_ENDHINNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKPR53.ENDTOKCD = RD_SSSMAIN_ENDTOKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTOKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKPR53.ENDTOKNM = RD_SSSMAIN_ENDTOKNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTHINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKPR53.STTHINCD = RD_SSSMAIN_STTHINCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTHINNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKPR53.STTHINNM = RD_SSSMAIN_STTHINNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKPR53.STTTOKCD = RD_SSSMAIN_STTTOKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTOKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKPR53.STTTOKNM = RD_SSSMAIN_STTTOKNM(De)
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
		Else
		End If
	End Sub
	
	Sub TOKPR53_FromTOKMTD() 'Generated.
		Dim i As Short
		
		DB_TOKPR53.HINCD = DB_TOKMTD.HINCD
		DB_TOKPR53.TOKCD = DB_TOKMTD.TOKCD
		DB_TOKPR53.TUKKB = DB_TOKMTD.TUKKB
		DB_TOKPR53.URILTPK = DB_TOKMTD.URILTPK
		DB_TOKPR53.URILTSUB = DB_TOKMTD.URILTSUB
		DB_TOKPR53.URILTTKB = DB_TOKMTD.URILTTKB
		DB_TOKPR53.URITKDT = DB_TOKMTD.URITKDT
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
		Else
		End If
	End Sub
	
	Sub UpdSmf() 'Generated.
	End Sub
	
	Sub WK_FromScr(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPEID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_OPEID = RD_SSSMAIN_OPEID(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPENM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_OPENM = RD_SSSMAIN_OPENM(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTHINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_STTHINCD = RD_SSSMAIN_STTHINCD(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTHINNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_STTHINNM = RD_SSSMAIN_STTHINNM(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDHINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_ENDHINCD = RD_SSSMAIN_ENDHINCD(0)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(WG_ENDHINCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(WG_ENDHINCD)) = 0 Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_ENDHINCD = HighValue(LenWid(WG_ENDHINCD))
		End If
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDHINNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_ENDHINNM = RD_SSSMAIN_ENDHINNM(0)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(WG_ENDHINNM)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(WG_ENDHINNM)) = 0 Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_ENDHINNM = HighValue(LenWid(WG_ENDHINNM))
		End If
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_STTTOKCD = RD_SSSMAIN_STTTOKCD(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTOKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_STTTOKNM = RD_SSSMAIN_STTTOKNM(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_ENDTOKCD = RD_SSSMAIN_ENDTOKCD(0)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(WG_ENDTOKCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(WG_ENDTOKCD)) = 0 Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_ENDTOKCD = HighValue(LenWid(WG_ENDTOKCD))
		End If
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDTOKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_ENDTOKNM = RD_SSSMAIN_ENDTOKNM(0)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(WG_ENDTOKNM)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(WG_ENDTOKNM)) = 0 Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_ENDTOKNM = HighValue(LenWid(WG_ENDTOKNM))
		End If
	End Sub
	
	Sub SetBuf(ByVal Fno As Short) 'Generated.
		Select Case Fno
			Case DBN_TOKPR53
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_TOKPR53)
			Case DBN_SYSTBA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBA)
			Case DBN_SYSTBB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBB)
			Case DBN_SYSTBC
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBC)
			Case DBN_SYSTBD
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBD)
			Case DBN_SYSTBF
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBF)
			Case DBN_SYSTBG
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBG)
			Case DBN_SYSTBH
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBH)
			Case DBN_CLSMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_CLSMTA)
			Case DBN_CLSMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_CLSMTB)
			Case DBN_TANMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_TANMTA)
			Case DBN_UNYMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_UNYMTA)
			Case DBN_TOKMTD
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_TOKMTD)
			Case DBN_TOKMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_TOKMTA)
			Case DBN_HINMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_HINMTA)
			Case DBN_MEIMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_MEIMTA)
			Case DBN_EXCTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_EXCTBZ)
			Case DBN_GYMTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_GYMTBZ)
			Case DBN_KNGMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_KNGMTB)
		End Select
	End Sub
	
	Sub ResetBuf(ByVal Fno As Short) 'Generated.
		Select Case Fno
			Case DBN_TOKPR53
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_TOKPR53 = LSet(G_LB)
			Case DBN_SYSTBA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBA = LSet(G_LB)
			Case DBN_SYSTBB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBB = LSet(G_LB)
			Case DBN_SYSTBC
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBC = LSet(G_LB)
			Case DBN_SYSTBD
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBD = LSet(G_LB)
			Case DBN_SYSTBF
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBF = LSet(G_LB)
			Case DBN_SYSTBG
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBG = LSet(G_LB)
			Case DBN_SYSTBH
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBH = LSet(G_LB)
			Case DBN_CLSMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_CLSMTA = LSet(G_LB)
			Case DBN_CLSMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_CLSMTB = LSet(G_LB)
			Case DBN_TANMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_TANMTA = LSet(G_LB)
			Case DBN_UNYMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_UNYMTA = LSet(G_LB)
			Case DBN_TOKMTD
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_TOKMTD = LSet(G_LB)
			Case DBN_TOKMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_TOKMTA = LSet(G_LB)
			Case DBN_HINMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_HINMTA = LSet(G_LB)
			Case DBN_MEIMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_MEIMTA = LSet(G_LB)
			Case DBN_EXCTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_EXCTBZ = LSet(G_LB)
			Case DBN_GYMTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_GYMTBZ = LSet(G_LB)
			Case DBN_KNGMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_KNGMTB = LSet(G_LB)
		End Select
	End Sub
	
	Function RecordFromObject(ByVal Fno As Short) As Short 'Generated.
		Dim Rtc As Short
		Select Case Fno
			Case Else
		End Select
		RecordFromObject = Rtc
	End Function
	
	Function ObjectFromRecord(ByVal Fno As Short) As Short 'Generated.
		Dim Rtc As Short
		Select Case Fno
			Case Else
		End Select
		ObjectFromRecord = Rtc
	End Function
End Module