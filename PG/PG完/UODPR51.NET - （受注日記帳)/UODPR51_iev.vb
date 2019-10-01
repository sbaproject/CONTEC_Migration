Option Strict Off
Option Explicit On
Module UODPR51_IEV
	Public Const SSS_MAX_DB As Short = 22
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "UODPR51"
	Public Const SSS_PrgNm As String = "受注日記帳                    "
	Public Const SSS_FraId As String = "PR2"
	Public WG_OPEID As String
	Public WG_OPENM As String
	Public WG_INPTANCD As String
	Public WG_INPTANNM As String
	Public WG_STTWRTDT As String
	Public WG_ENDWRTDT As String
	Public WG_STTWRTTM As String
	Public WG_ENDWRTTM As String
	Public WG_STTJDNNO As String
	Public WG_ENDJDNNO As String
	Public WG_STTTOKCD As String
	Public WG_STTTOKRN As String
	Public WG_SJDNINKB As String
	
	Sub Init_Fil() 'Generated.
		'
		DBN_UODPR51 = 0
		DB_PARA(DBN_UODPR51).TBLID = "UODPR51"
		DB_PARA(DBN_UODPR51).DBID = "USR9"
		SSS_MFIL = DBN_UODPR51
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
		DBN_TOKMTA = 10
		DB_PARA(DBN_TOKMTA).TBLID = "TOKMTA"
		DB_PARA(DBN_TOKMTA).DBID = "USR1"
		'
		DBN_JDNTRA = 11
		DB_PARA(DBN_JDNTRA).TBLID = "JDNTRA"
		DB_PARA(DBN_JDNTRA).DBID = "USR1"
		'
		DBN_JDNTHA = 12
		DB_PARA(DBN_JDNTHA).TBLID = "JDNTHA"
		DB_PARA(DBN_JDNTHA).DBID = "USR1"
		'
		DBN_MEIMTA = 13
		DB_PARA(DBN_MEIMTA).TBLID = "MEIMTA"
		DB_PARA(DBN_MEIMTA).DBID = "USR1"
		'
		DBN_TANMTA = 14
		DB_PARA(DBN_TANMTA).TBLID = "TANMTA"
		DB_PARA(DBN_TANMTA).DBID = "USR1"
		'
		DBN_NHSMTA = 15
		DB_PARA(DBN_NHSMTA).TBLID = "NHSMTA"
		DB_PARA(DBN_NHSMTA).DBID = "USR1"
		'
		DBN_BMNMTA = 16
		DB_PARA(DBN_BMNMTA).TBLID = "BMNMTA"
		DB_PARA(DBN_BMNMTA).DBID = "USR1"
		'
		DBN_UNYMTA = 17
		DB_PARA(DBN_UNYMTA).TBLID = "UNYMTA"
		DB_PARA(DBN_UNYMTA).DBID = "USR1"
		'
		DBN_EXCTBZ = 18
		DB_PARA(DBN_EXCTBZ).TBLID = "EXCTBZ"
		DB_PARA(DBN_EXCTBZ).DBID = "USR1"
		'
		DBN_GYMTBZ = 19
		DB_PARA(DBN_GYMTBZ).TBLID = "GYMTBZ"
		DB_PARA(DBN_GYMTBZ).DBID = "USR1"
		'
		DBN_KNGMTB = 20
		DB_PARA(DBN_KNGMTB).TBLID = "KNGMTB"
		DB_PARA(DBN_KNGMTB).DBID = "USR1"
		'
		DBN_TANWTA = 21
		DB_PARA(DBN_TANWTA).TBLID = "TANWTA"
		DB_PARA(DBN_TANWTA).DBID = "USR1"
		
		SSS_LSTMFIL = DBN_UODPR51
	End Sub
	
	Sub SCR_FromTOKMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_STTTOKCD(De, DB_TOKMTA.TOKCD)
		Call DP_SSSMAIN_STTTOKRN(De, DB_TOKMTA.TOKRN)
	End Sub
	
	Sub TOKMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKMTA.TOKCD = RD_SSSMAIN_STTTOKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTOKRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKMTA.TOKRN = RD_SSSMAIN_STTTOKRN(De)
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
		Call DP_SSSMAIN_ENDJDNNO(De, DB_UODPR51.ENDJDNNO)
		Call DP_SSSMAIN_ENDWRTDT(De, DB_UODPR51.ENDWRTDT)
		Call DP_SSSMAIN_ENDWRTTM(De, DB_UODPR51.ENDWRTTM)
		Call DP_SSSMAIN_INPTANCD(De, DB_UODPR51.INPTANCD)
		Call DP_SSSMAIN_INPTANNM(De, DB_UODPR51.INPTANNM)
		Call DP_SSSMAIN_SJDNINKB(De, DB_UODPR51.SJDNINKB)
		Call DP_SSSMAIN_STTJDNNO(De, DB_UODPR51.STTJDNNO)
		Call DP_SSSMAIN_STTTOKCD(De, DB_UODPR51.STTTOKCD)
		Call DP_SSSMAIN_STTTOKRN(De, DB_UODPR51.STTTOKRN)
		Call DP_SSSMAIN_STTWRTDT(De, DB_UODPR51.STTWRTDT)
		Call DP_SSSMAIN_STTWRTTM(De, DB_UODPR51.STTWRTTM)
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDJDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UODPR51.ENDJDNNO = RD_SSSMAIN_ENDJDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDWRTDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UODPR51.ENDWRTDT = RD_SSSMAIN_ENDWRTDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDWRTTM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UODPR51.ENDWRTTM = RD_SSSMAIN_ENDWRTTM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPTANCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UODPR51.INPTANCD = RD_SSSMAIN_INPTANCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPTANNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UODPR51.INPTANNM = RD_SSSMAIN_INPTANNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SJDNINKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UODPR51.SJDNINKB = RD_SSSMAIN_SJDNINKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTJDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UODPR51.STTJDNNO = RD_SSSMAIN_STTJDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UODPR51.STTTOKCD = RD_SSSMAIN_STTTOKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTOKRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UODPR51.STTTOKRN = RD_SSSMAIN_STTTOKRN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTWRTDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UODPR51.STTWRTDT = RD_SSSMAIN_STTWRTDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTWRTTM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UODPR51.STTWRTTM = RD_SSSMAIN_STTWRTTM(De)
		DB_UODPR51.OPEID = SSS_OPEID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_UODPR51.WRTTM = VB6.Format(Now, "hhmmss")
			DB_UODPR51.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_UODPR51.WRTTM = DB_ORATM
			DB_UODPR51.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub UODPR51_FromJDNTHA() 'Generated.
		Dim i As Short
		
		DB_UODPR51.AKNID = DB_JDNTHA.AKNID
		DB_UODPR51.BKTHKKB = DB_JDNTHA.BKTHKKB
		DB_UODPR51.BUMCD = DB_JDNTHA.BUMCD
		DB_UODPR51.BUNNM = DB_JDNTHA.BUMNM
		DB_UODPR51.CLMDL = DB_JDNTHA.CLMDL
		DB_UODPR51.DATNO = DB_JDNTHA.DATNO
		DB_UODPR51.DEFNOKDT = DB_JDNTHA.DEFNOKDT
		DB_UODPR51.DENCM = DB_JDNTHA.DENCM
		DB_UODPR51.DENCMIN = DB_JDNTHA.DENCMIN
		DB_UODPR51.JDNDT = DB_JDNTHA.JDNDT
		DB_UODPR51.JDNINKB = DB_JDNTHA.JDNINKB
		DB_UODPR51.JDNNO = DB_JDNTHA.JDNNO
		DB_UODPR51.JDNTRKB = DB_JDNTHA.JDNTRKB
		DB_UODPR51.JODRSNKB = DB_JDNTHA.JODRSNKB
		DB_UODPR51.KENNMA = DB_JDNTHA.KENNMA
		DB_UODPR51.KENNMB = DB_JDNTHA.KENNMB
		DB_UODPR51.MAEUKKB = DB_JDNTHA.MAEUKKB
		DB_UODPR51.MITNO = DB_JDNTHA.MITNO
		DB_UODPR51.MITNOV = DB_JDNTHA.MITNOV
		DB_UODPR51.NHSNMA = DB_JDNTHA.NHSNMA
		DB_UODPR51.NHSNMB = DB_JDNTHA.NHSNMB
		DB_UODPR51.PRDTBMCD = DB_JDNTHA.PRDTBMCD
		DB_UODPR51.RPTOPEID = DB_JDNTHA.OPEID
		DB_UODPR51.SEIKB = DB_JDNTHA.SEIKB
		DB_UODPR51.SOUCD = DB_JDNTHA.SOUCD
		DB_UODPR51.SOUNM = DB_JDNTHA.SOUNM
		DB_UODPR51.TANCD = DB_JDNTHA.TANCD
		DB_UODPR51.TANNM = DB_JDNTHA.TANNM
		DB_UODPR51.TOKCD = DB_JDNTHA.TOKCD
		DB_UODPR51.TOKJDNNO = DB_JDNTHA.TOKJDNNO
		DB_UODPR51.TOKRN = DB_JDNTHA.TOKRN
		DB_UODPR51.URIKJN = DB_JDNTHA.URIKJN
		DB_UODPR51.WRTDT = DB_JDNTHA.WRTDT
		DB_UODPR51.WRTTM = DB_JDNTHA.WRTTM
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
		Else
		End If
	End Sub
	
	Sub UODPR51_FromJDNTRA() 'Generated.
		Dim i As Short
		
		DB_UODPR51.DATKB = DB_JDNTRA.DATKB
		DB_UODPR51.DATNO = DB_JDNTRA.DATNO
		DB_UODPR51.DLFLG = DB_JDNTRA.DLFLG
		DB_UODPR51.GNKCD = DB_JDNTRA.GNKCD
		DB_UODPR51.HINCD = DB_JDNTRA.HINCD
		DB_UODPR51.HINNMA = DB_JDNTRA.HINNMA
		DB_UODPR51.HINNMB = DB_JDNTRA.HINNMB
		DB_UODPR51.JDNKB = DB_JDNTRA.JDNKB
		DB_UODPR51.LINCMA = DB_JDNTRA.LINCMA
		DB_UODPR51.LINCMB = DB_JDNTRA.LINCMB
		DB_UODPR51.LINNO = DB_JDNTRA.LINNO
		DB_UODPR51.ODNYTDT = DB_JDNTRA.ODNYTDT
		DB_UODPR51.TOKJDNNB = DB_JDNTRA.TOKJDNNO
		DB_UODPR51.UNTNM = DB_JDNTRA.UNTNM
		DB_UODPR51.UODKN = DB_JDNTRA.UODKN
		DB_UODPR51.UODSU = DB_JDNTRA.UODSU
		DB_UODPR51.UODTK = DB_JDNTRA.UODTK
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
		Else
		End If
	End Sub
	
	Sub UODPR51_FromMEIMTA() 'Generated.
		Dim i As Short
		
		DB_UODPR51.JDNTRNM = DB_MEIMTA.MEINMA
		DB_UODPR51.JODRSNKB = DB_MEIMTA.MEICDA
		DB_UODPR51.JODRSNNM = DB_MEIMTA.MEINMA
		DB_UODPR51.MAEUKKB = DB_MEIMTA.MEICDA
		DB_UODPR51.MEICDA = DB_MEIMTA.MEICDA
		DB_UODPR51.MEINMA = DB_MEIMTA.MEINMA
		DB_UODPR51.PRDTBMCD = DB_MEIMTA.MEICDA
		DB_UODPR51.PRDTBMNM = DB_MEIMTA.MEINMA
		DB_UODPR51.SEIKB = DB_MEIMTA.MEICDA
		DB_UODPR51.SEINM = DB_MEIMTA.MEINMA
		DB_UODPR51.SJDNINKB = DB_MEIMTA.MEICDA
		DB_UODPR51.URIKJN = DB_MEIMTA.MEICDA
		DB_UODPR51.URIKNM = DB_MEIMTA.MEINMA
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
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPTANCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_INPTANCD = RD_SSSMAIN_INPTANCD(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPTANNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_INPTANNM = RD_SSSMAIN_INPTANNM(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTWRTDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_STTWRTDT = RD_SSSMAIN_STTWRTDT(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDWRTDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_ENDWRTDT = RD_SSSMAIN_ENDWRTDT(0)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(WG_ENDWRTDT)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(WG_ENDWRTDT)) = 0 Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_ENDWRTDT = HighValue(LenWid(WG_ENDWRTDT))
		End If
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTWRTTM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_STTWRTTM = RD_SSSMAIN_STTWRTTM(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDWRTTM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_ENDWRTTM = RD_SSSMAIN_ENDWRTTM(0)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(WG_ENDWRTTM)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(WG_ENDWRTTM)) = 0 Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_ENDWRTTM = HighValue(LenWid(WG_ENDWRTTM))
		End If
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTJDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_STTJDNNO = RD_SSSMAIN_STTJDNNO(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDJDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_ENDJDNNO = RD_SSSMAIN_ENDJDNNO(0)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(WG_ENDJDNNO)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(WG_ENDJDNNO)) = 0 Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_ENDJDNNO = HighValue(LenWid(WG_ENDJDNNO))
		End If
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_STTTOKCD = RD_SSSMAIN_STTTOKCD(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTTOKRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_STTTOKRN = RD_SSSMAIN_STTTOKRN(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SJDNINKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_SJDNINKB = RD_SSSMAIN_SJDNINKB(0)
	End Sub
	
	Sub SetBuf(ByVal Fno As Short) 'Generated.
		Select Case Fno
			Case DBN_UODPR51
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_UODPR51)
                '2019.03.26 DEL END
            Case DBN_SYSTBA
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_SYSTBA)
                '2019.03.26 DEL END
			Case DBN_SYSTBB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_SYSTBB)
                '2019.03.26 DEL END
			Case DBN_SYSTBC
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_SYSTBC)
                '2019.03.26 DEL END
			Case DBN_SYSTBD
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_SYSTBD)
                '2019.03.26 DEL END
			Case DBN_SYSTBF
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_SYSTBF)
                '2019.03.26 DEL END
			Case DBN_SYSTBG
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_SYSTBG)
                '2019.03.26 DEL END
			Case DBN_SYSTBH
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_SYSTBH)
                '2019.03.26 DEL END
			Case DBN_CLSMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_CLSMTA)
                '2019.03.26 DEL END
			Case DBN_CLSMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_CLSMTB)
                '2019.03.26 DEL END
			Case DBN_TOKMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_TOKMTA)
                '2019.03.26 DEL END
			Case DBN_JDNTRA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_JDNTRA)
                '2019.03.26 DEL END
            Case DBN_JDNTHA
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_JDNTHA)
                '2019.03.26 DEL END
			Case DBN_MEIMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_MEIMTA)
                '2019.03.26 DEL END
			Case DBN_TANMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_TANMTA)
                '2019.03.26 DEL END
			Case DBN_NHSMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_NHSMTA)
                '2019.03.26 DEL END
			Case DBN_BMNMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_BMNMTA)
                '2019.03.26 DEL END
			Case DBN_UNYMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_UNYMTA)
                '2019.03.26 DEL END
            Case DBN_EXCTBZ
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_EXCTBZ)
                '2019.03.26 DEL END
            Case DBN_GYMTBZ
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_GYMTBZ)
                '2019.03.26 DEL END
            Case DBN_KNGMTB
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_KNGMTB)
                '2019.03.26 DEL END
            Case DBN_TANWTA
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'G_LB = LSet(DB_TANWTA)
                '2019.03.26 DEL END
        End Select
	End Sub
	
	Sub ResetBuf(ByVal Fno As Short) 'Generated.
		Select Case Fno
			Case DBN_UODPR51
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_UODPR51 = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_SYSTBA
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_SYSTBA = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_SYSTBB
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_SYSTBB = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_SYSTBC
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_SYSTBC = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_SYSTBD
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_SYSTBD = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_SYSTBF
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_SYSTBF = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_SYSTBG
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_SYSTBG = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_SYSTBH
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_SYSTBH = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_CLSMTA
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_CLSMTA = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_CLSMTB
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_CLSMTB = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_TOKMTA
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_TOKMTA = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_JDNTRA
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_JDNTRA = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_JDNTHA
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_JDNTHA = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_MEIMTA
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_MEIMTA = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_TANMTA
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START 
                'DB_TANMTA = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_NHSMTA
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_NHSMTA = LSet(G_LB)
                '2019.03.26 DEL END
			Case DBN_BMNMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_BMNMTA = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_UNYMTA
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_UNYMTA = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_EXCTBZ
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_EXCTBZ = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_GYMTBZ
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_GYMTBZ = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_KNGMTB
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_KNGMTB = LSet(G_LB)
                '2019.03.26 DEL END
            Case DBN_TANWTA
                'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
                '2019.03.26 DEL START
                'DB_TANWTA = LSet(G_LB)
                '2019.03.26 DEL END
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