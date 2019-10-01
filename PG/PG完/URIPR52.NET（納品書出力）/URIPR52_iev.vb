Option Strict Off
Option Explicit On
Module URIPR52_IEV
	'***chg-S-tom***
	'Global Const SSS_MAX_DB% = 25
	Public Const SSS_MAX_DB As Short = 26
	'***chg-S-tom***
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "URIPR52"
	Public Const SSS_PrgNm As String = "納品書出力（直送）                  "
	Public Const SSS_FraId As String = "PR3"
	Public WG_OPEID As String
	Public WG_OPENM As String
	Public WG_HAKKOU As String
	Public WG_KINKYU As String
	Public WG_TANCD As String
	Public WG_TANNM As String
	Public WG_BMNCD As String
	Public WG_BMNNM As String
	Public WG_DENDT As String
	Public WG_JDNNO As String
	Public WG_TOKCD As String
	Public WG_TOKRN As String
	Public WG_JDNTRKB As String
	Public WG_JDNTRNM As String
	Public WG_PRTKB As String
	Public WG_FDNNO As String
	
	Sub Init_Fil() 'Generated.
		'
		DBN_URIPR52 = 0
		DB_PARA(DBN_URIPR52).tblid = "URIPR52"
		DB_PARA(DBN_URIPR52).DBID = "USR9"
		SSS_MFIL = DBN_URIPR52
		'
		DBN_SYSTBA = 1
		DB_PARA(DBN_SYSTBA).tblid = "SYSTBA"
		DB_PARA(DBN_SYSTBA).DBID = "USR1"
		'
		DBN_SYSTBB = 2
		DB_PARA(DBN_SYSTBB).tblid = "SYSTBB"
		DB_PARA(DBN_SYSTBB).DBID = "USR1"
		'
		DBN_SYSTBC = 3
		DB_PARA(DBN_SYSTBC).tblid = "SYSTBC"
		DB_PARA(DBN_SYSTBC).DBID = "USR1"
		'
		DBN_SYSTBD = 4
		DB_PARA(DBN_SYSTBD).tblid = "SYSTBD"
		DB_PARA(DBN_SYSTBD).DBID = "USR1"
		'
		DBN_SYSTBF = 5
		DB_PARA(DBN_SYSTBF).tblid = "SYSTBF"
		DB_PARA(DBN_SYSTBF).DBID = "USR1"
		'
		DBN_SYSTBG = 6
		DB_PARA(DBN_SYSTBG).tblid = "SYSTBG"
		DB_PARA(DBN_SYSTBG).DBID = "USR1"
		'
		DBN_SYSTBH = 7
		DB_PARA(DBN_SYSTBH).tblid = "SYSTBH"
		DB_PARA(DBN_SYSTBH).DBID = "USR1"
		'
		DBN_UDNTHA = 8
		DB_PARA(DBN_UDNTHA).tblid = "UDNTHA"
		DB_PARA(DBN_UDNTHA).DBID = "USR1"
		'
		DBN_UDNTRA = 9
		DB_PARA(DBN_UDNTRA).tblid = "UDNTRA"
		DB_PARA(DBN_UDNTRA).DBID = "USR1"
		'
		DBN_CLSMTA = 10
		DB_PARA(DBN_CLSMTA).tblid = "CLSMTA"
		DB_PARA(DBN_CLSMTA).DBID = "USR1"
		'
		DBN_CLSMTB = 11
		DB_PARA(DBN_CLSMTB).tblid = "CLSMTB"
		DB_PARA(DBN_CLSMTB).DBID = "USR1"
        '
        DBN_TOKMTA = 12
        DB_PARA(DBN_TOKMTA).tblid = "TOKMTA"
		DB_PARA(DBN_TOKMTA).DBID = "USR1"
		'
		DBN_NHSMTA = 13
		DB_PARA(DBN_NHSMTA).tblid = "NHSMTA"
		DB_PARA(DBN_NHSMTA).DBID = "USR1"
		'
		DBN_TANMTA = 14
		DB_PARA(DBN_TANMTA).tblid = "TANMTA"
		DB_PARA(DBN_TANMTA).DBID = "USR1"
		'
		DBN_BMNMTA = 15
		DB_PARA(DBN_BMNMTA).tblid = "BMNMTA"
		DB_PARA(DBN_BMNMTA).DBID = "USR1"
		'
		DBN_BMNMTB = 16
		DB_PARA(DBN_BMNMTB).tblid = "BMNMTB"
		DB_PARA(DBN_BMNMTB).DBID = "USR1"
		'
		DBN_MEIMTA = 17
		DB_PARA(DBN_MEIMTA).tblid = "MEIMTA"
		DB_PARA(DBN_MEIMTA).DBID = "USR1"
		'
		DBN_UNYMTA = 18
		DB_PARA(DBN_UNYMTA).tblid = "UNYMTA"
		DB_PARA(DBN_UNYMTA).DBID = "USR1"
		'
		DBN_JDNTHA = 19
		DB_PARA(DBN_JDNTHA).tblid = "JDNTHA"
		DB_PARA(DBN_JDNTHA).DBID = "USR1"
		'
		DBN_JDNTRA = 20
		DB_PARA(DBN_JDNTRA).tblid = "JDNTRA"
		DB_PARA(DBN_JDNTRA).DBID = "USR1"
		'
		DBN_EXCTBZ = 21
		DB_PARA(DBN_EXCTBZ).tblid = "EXCTBZ"
		DB_PARA(DBN_EXCTBZ).DBID = "USR1"
		'
		DBN_GYMTBZ = 22
		DB_PARA(DBN_GYMTBZ).tblid = "GYMTBZ"
		DB_PARA(DBN_GYMTBZ).DBID = "USR1"
		'
		DBN_KNGMTB = 23
		DB_PARA(DBN_KNGMTB).tblid = "KNGMTB"
		DB_PARA(DBN_KNGMTB).DBID = "USR1"
		'
		DBN_TANWTA = 24
		DB_PARA(DBN_TANWTA).tblid = "TANWTA"
		DB_PARA(DBN_TANWTA).DBID = "USR1"
		'***add-S-tom***
		DBN_MEIMTC = 25
		DB_PARA(DBN_MEIMTC).tblid = "MEIMTC"
		DB_PARA(DBN_MEIMTC).DBID = "USR1"
		'
		'***add-E-tom***
		SSS_LSTMFIL = DBN_URIPR52
	End Sub

    Sub SCR_FromBMNMTA(ByVal De As Short) 'Generated.
        Call DP_SSSMAIN_BMNNM(De, DB_BMNMTA.BMNNM)
    End Sub

    Sub BMNMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BMNNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_BMNMTA.BMNNM = RD_SSSMAIN_BMNNM(De)
		DB_BMNMTA.OPEID = SSS_OPEID.Value
		DB_BMNMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_BMNMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_BMNMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_BMNMTA.WRTTM = DB_ORATM
			DB_BMNMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromMEIMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_JDNTRNM(De, DB_MEIMTA.MEINMA)
	End Sub
	
	Sub MEIMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNTRNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_MEIMTA.MEINMA = RD_SSSMAIN_JDNTRNM(De)
		DB_MEIMTA.OPEID = SSS_OPEID.Value
		DB_MEIMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_MEIMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_MEIMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_MEIMTA.WRTTM = DB_ORATM
			DB_MEIMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromTANMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_TANNM(De, DB_TANMTA.TANNM)
	End Sub
	
	Sub TANMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TANMTA.TANNM = RD_SSSMAIN_TANNM(De)
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
	
	Sub SCR_FromTOKMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_TOKRN(De, DB_TOKMTA.TOKRN)
	End Sub
	
	Sub TOKMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKMTA.TOKRN = RD_SSSMAIN_TOKRN(De)
		DB_TOKMTA.OPEID = SSS_OPEID.Value
		DB_TOKMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_TOKMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_TOKMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_TOKMTA.WRTTM = DB_ORATM
			DB_TOKMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_BMNCD(De, DB_URIPR52.HDBUMCD)
		Call DP_SSSMAIN_DENDT(De, DB_URIPR52.HDDENDT)
		Call DP_SSSMAIN_HAKKOU(De, DB_URIPR52.HDHAKKOU)
		Call DP_SSSMAIN_JDNNO(De, DB_URIPR52.HDJDNNO)
		Call DP_SSSMAIN_JDNTRKB(De, DB_URIPR52.HDJDNTKB)
		Call DP_SSSMAIN_KINKYU(De, DB_URIPR52.HDKINKYU)
		Call DP_SSSMAIN_PRTKB(De, DB_URIPR52.HDPRTKB)
		Call DP_SSSMAIN_TANCD(De, DB_URIPR52.HDTANCD)
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BMNCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_URIPR52.HDBUMCD = RD_SSSMAIN_BMNCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_URIPR52.HDDENDT = RD_SSSMAIN_DENDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HAKKOU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_URIPR52.HDHAKKOU = RD_SSSMAIN_HAKKOU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_URIPR52.HDJDNNO = RD_SSSMAIN_JDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNTRKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_URIPR52.HDJDNTKB = RD_SSSMAIN_JDNTRKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_KINKYU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_URIPR52.HDKINKYU = RD_SSSMAIN_KINKYU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_PRTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_URIPR52.HDPRTKB = RD_SSSMAIN_PRTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_URIPR52.HDTANCD = RD_SSSMAIN_TANCD(De)
		DB_URIPR52.RPTCLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_URIPR52.WRTTM = VB6.Format(Now, "hhmmss")
			DB_URIPR52.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_URIPR52.WRTTM = DB_ORATM
			DB_URIPR52.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub URIPR52_FromBMNMTA() 'Generated.
		Dim I As Short
		
		DB_URIPR52.BMNADA = DB_BMNMTA.BMNADA
		DB_URIPR52.BMNADB = DB_BMNMTA.BMNADB
		DB_URIPR52.BMNADC = DB_BMNMTA.BMNADC
		DB_URIPR52.BMNFX = DB_BMNMTA.BMNFX
		DB_URIPR52.BMNTL = DB_BMNMTA.BMNTL
		DB_URIPR52.BMNURL = DB_BMNMTA.BMNURL
		DB_URIPR52.BMNZP = DB_BMNMTA.BMNZP
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
		Else
		End If
	End Sub
	
	Sub URIPR52_FromTANMTA() 'Generated.
		Dim I As Short
		
		DB_URIPR52.TANNM = DB_TANMTA.TANNM
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
		Else
		End If
	End Sub
	
	Sub URIPR52_FromUDNTHA() 'Generated.
		Dim I As Short
		
		DB_URIPR52.BUMCD = DB_UDNTHA.BUMCD
		DB_URIPR52.BUMNM = DB_UDNTHA.BUMNM
		DB_URIPR52.DENCM = DB_UDNTHA.DENCM
		DB_URIPR52.FDNNO = DB_UDNTHA.FDNNO
		DB_URIPR52.TANCD = DB_UDNTHA.TANCD
		DB_URIPR52.TANNM = DB_UDNTHA.TANNM
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
		Else
		End If
	End Sub
	
	Sub URIPR52_FromUDNTRA() 'Generated.
		Dim I As Short
		
		DB_URIPR52.DENDT = DB_UDNTRA.UDNDT
		DB_URIPR52.LINNO = DB_UDNTRA.LINNO
		DB_URIPR52.UDNNO = DB_UDNTRA.UDNNO
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
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HAKKOU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_HAKKOU = RD_SSSMAIN_HAKKOU(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_KINKYU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_KINKYU = RD_SSSMAIN_KINKYU(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_TANCD = RD_SSSMAIN_TANCD(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_TANNM = RD_SSSMAIN_TANNM(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BMNCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_BMNCD = RD_SSSMAIN_BMNCD(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BMNNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_BMNNM = RD_SSSMAIN_BMNNM(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_DENDT = RD_SSSMAIN_DENDT(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_JDNNO = RD_SSSMAIN_JDNNO(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_TOKCD = RD_SSSMAIN_TOKCD(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_TOKRN = RD_SSSMAIN_TOKRN(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNTRKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_JDNTRKB = RD_SSSMAIN_JDNTRKB(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNTRNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_JDNTRNM = RD_SSSMAIN_JDNTRNM(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_PRTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_PRTKB = RD_SSSMAIN_PRTKB(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_FDNNO = RD_SSSMAIN_FDNNO(0)
	End Sub
	
	Sub SetBuf(ByVal Fno As Short) 'Generated.
        Select Case Fno
            '2019.04.08 DEL START 仮
            'Case DBN_URIPR52
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_URIPR52)
            'Case DBN_SYSTBA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_SYSTBA)
            'Case DBN_SYSTBB
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_SYSTBB)
            'Case DBN_SYSTBC
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_SYSTBC)
            'Case DBN_SYSTBD
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_SYSTBD)
            'Case DBN_SYSTBF
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_SYSTBF)
            'Case DBN_SYSTBG
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_SYSTBG)
            'Case DBN_SYSTBH
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_SYSTBH)
            'Case DBN_UDNTHA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_UDNTHA)
            'Case DBN_UDNTRA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_UDNTRA)
            'Case DBN_CLSMTA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_CLSMTA)
            'Case DBN_CLSMTB
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_CLSMTB)
            Case DBN_TOKMTA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_TOKMTA)
            'Case DBN_NHSMTA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_NHSMTA)
            'Case DBN_TANMTA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    G_LB = LSet(DB_TANMTA)
            Case DBN_BMNMTA
                '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '    G_LB = LSet(DB_BMNMTA)
                'Case DBN_BMNMTB
                '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '    G_LB = LSet(DB_BMNMTB)
                'Case DBN_MEIMTA
                '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '    G_LB = LSet(DB_MEIMTA)
                'Case DBN_UNYMTA
                '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '    G_LB = LSet(DB_UNYMTA)
                'Case DBN_JDNTHA
                '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '    G_LB = LSet(DB_JDNTHA)
                'Case DBN_JDNTRA
                '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '    G_LB = LSet(DB_JDNTRA)
                'Case DBN_EXCTBZ
                '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '    G_LB = LSet(DB_EXCTBZ)
                'Case DBN_GYMTBZ
                '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '    G_LB = LSet(DB_GYMTBZ)
                'Case DBN_KNGMTB
                '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '    G_LB = LSet(DB_KNGMTB)
                'Case DBN_TANWTA
                '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '    G_LB = LSet(DB_TANWTA)
                '    '***add-S-tom***
                'Case DBN_MEIMTC
                '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '    G_LB = LSet(DB_MEIMTC)
                '    '***add-E-tom***
                '2019.04.08 DEL END
        End Select
	End Sub
	
	Sub ResetBuf(ByVal Fno As Short) 'Generated.
        Select Case Fno
            '2019.04.08 DEL START
            'Case DBN_URIPR52
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_URIPR52 = LSet(G_LB)
            'Case DBN_SYSTBA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_SYSTBA = LSet(G_LB)
            'Case DBN_SYSTBB
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_SYSTBB = LSet(G_LB)
            'Case DBN_SYSTBC
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_SYSTBC = LSet(G_LB)
            'Case DBN_SYSTBD
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_SYSTBD = LSet(G_LB)
            'Case DBN_SYSTBF
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_SYSTBF = LSet(G_LB)
            'Case DBN_SYSTBG
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_SYSTBG = LSet(G_LB)
            'Case DBN_SYSTBH
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_SYSTBH = LSet(G_LB)
            'Case DBN_UDNTHA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_UDNTHA = LSet(G_LB)
            'Case DBN_UDNTRA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_UDNTRA = LSet(G_LB)
            'Case DBN_CLSMTA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_CLSMTA = LSet(G_LB)
            'Case DBN_CLSMTB
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_CLSMTB = LSet(G_LB)
            'Case DBN_TOKMTA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_TOKMTA = LSet(G_LB)
            'Case DBN_NHSMTA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_NHSMTA = LSet(G_LB)
            'Case DBN_TANMTA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_TANMTA = LSet(G_LB)
            'Case DBN_BMNMTA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_BMNMTA = LSet(G_LB)
            'Case DBN_BMNMTB
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_BMNMTB = LSet(G_LB)
            'Case DBN_MEIMTA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_MEIMTA = LSet(G_LB)
            'Case DBN_UNYMTA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_UNYMTA = LSet(G_LB)
            'Case DBN_JDNTHA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_JDNTHA = LSet(G_LB)
            'Case DBN_JDNTRA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_JDNTRA = LSet(G_LB)
            'Case DBN_EXCTBZ
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_EXCTBZ = LSet(G_LB)
            'Case DBN_GYMTBZ
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_GYMTBZ = LSet(G_LB)
            'Case DBN_KNGMTB
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_KNGMTB = LSet(G_LB)
            'Case DBN_TANWTA
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_TANWTA = LSet(G_LB)
            '    '***add-S-tom***
            'Case DBN_MEIMTC
            '    'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
            '    DB_MEIMTC = LSet(G_LB)
            '***add-E-tom***
            '2019.04.08 DEL END
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