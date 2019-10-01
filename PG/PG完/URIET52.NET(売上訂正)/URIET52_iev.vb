Option Strict Off
Option Explicit On
Module URIET52_IEV
	Public Const SSS_MAX_DB As Short = 36
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "URIET52"
	Public Const SSS_PrgNm As String = "売上訂正                      "
	Public Const SSS_FraId As String = "ET1"
	
	Sub PRNBIL() 'Generated.
		
	End Sub
	
	
	Sub Init_Fil() 'Generated.
		'
		DBN_UDNTRA = 0
		DB_PARA(DBN_UDNTRA).TBLID = "UDNTRA"
		DB_PARA(DBN_UDNTRA).DBID = "USR1"
		SSS_MFIL = DBN_UDNTRA
		'
		DBN_UDNTHA = 1
		DB_PARA(DBN_UDNTHA).TBLID = "UDNTHA"
		DB_PARA(DBN_UDNTHA).DBID = "USR1"
		'
		DBN_FDNTRA = 2
		DB_PARA(DBN_FDNTRA).TBLID = "FDNTRA"
		DB_PARA(DBN_FDNTRA).DBID = "USR1"
		'
		DBN_FDNTHA = 3
		DB_PARA(DBN_FDNTHA).TBLID = "FDNTHA"
		DB_PARA(DBN_FDNTHA).DBID = "USR1"
		'
		DBN_JDNTRA = 4
		DB_PARA(DBN_JDNTRA).TBLID = "JDNTRA"
		DB_PARA(DBN_JDNTRA).DBID = "USR1"
		'
		DBN_JDNTHA = 5
		DB_PARA(DBN_JDNTHA).TBLID = "JDNTHA"
		DB_PARA(DBN_JDNTHA).DBID = "USR1"
		'
		DBN_TOKMTA = 6
		DB_PARA(DBN_TOKMTA).TBLID = "TOKMTA"
		DB_PARA(DBN_TOKMTA).DBID = "USR1"
		'
		DBN_TANMTA = 7
		DB_PARA(DBN_TANMTA).TBLID = "TANMTA"
		DB_PARA(DBN_TANMTA).DBID = "USR1"
		'
		DBN_SOUMTA = 8
		DB_PARA(DBN_SOUMTA).TBLID = "SOUMTA"
		DB_PARA(DBN_SOUMTA).DBID = "USR1"
		'
		DBN_NHSMTA = 9
		DB_PARA(DBN_NHSMTA).TBLID = "NHSMTA"
		DB_PARA(DBN_NHSMTA).DBID = "USR1"
		'
		DBN_HINMTA = 10
		DB_PARA(DBN_HINMTA).TBLID = "HINMTA"
		DB_PARA(DBN_HINMTA).DBID = "USR1"
		'
		DBN_SYSTBA = 11
		DB_PARA(DBN_SYSTBA).TBLID = "SYSTBA"
		DB_PARA(DBN_SYSTBA).DBID = "USR1"
		'
		DBN_SYSTBB = 12
		DB_PARA(DBN_SYSTBB).TBLID = "SYSTBB"
		DB_PARA(DBN_SYSTBB).DBID = "USR1"
		'
		DBN_SYSTBC = 13
		DB_PARA(DBN_SYSTBC).TBLID = "SYSTBC"
		DB_PARA(DBN_SYSTBC).DBID = "USR1"
		'
		DBN_SYSTBD = 14
		DB_PARA(DBN_SYSTBD).TBLID = "SYSTBD"
		DB_PARA(DBN_SYSTBD).DBID = "USR1"
		'
		DBN_SYSTBF = 15
		DB_PARA(DBN_SYSTBF).TBLID = "SYSTBF"
		DB_PARA(DBN_SYSTBF).DBID = "USR1"
		'
		DBN_SYSTBG = 16
		DB_PARA(DBN_SYSTBG).TBLID = "SYSTBG"
		DB_PARA(DBN_SYSTBG).DBID = "USR1"
		'
		DBN_SYSTBH = 17
		DB_PARA(DBN_SYSTBH).TBLID = "SYSTBH"
		DB_PARA(DBN_SYSTBH).DBID = "USR1"
		'
		DBN_CLSMTA = 18
		DB_PARA(DBN_CLSMTA).TBLID = "CLSMTA"
		DB_PARA(DBN_CLSMTA).DBID = "USR1"
		'
		DBN_CLSMTB = 19
		DB_PARA(DBN_CLSMTB).TBLID = "CLSMTB"
		DB_PARA(DBN_CLSMTB).DBID = "USR1"
		'
		DBN_TOKMTB = 20
		DB_PARA(DBN_TOKMTB).TBLID = "TOKMTB"
		DB_PARA(DBN_TOKMTB).DBID = "USR1"
		'
		DBN_HINMTB = 21
		DB_PARA(DBN_HINMTB).TBLID = "HINMTB"
		DB_PARA(DBN_HINMTB).DBID = "USR1"
		'
		DBN_SYSTBI = 22
		DB_PARA(DBN_SYSTBI).TBLID = "SYSTBI"
		DB_PARA(DBN_SYSTBI).DBID = "USR1"
		'
		DBN_HINSMA = 23
		DB_PARA(DBN_HINSMA).TBLID = "HINSMA"
		DB_PARA(DBN_HINSMA).DBID = "USR1"
		'
		DBN_JDNDL01 = 24
		DB_PARA(DBN_JDNDL01).TBLID = "JDNDL01"
		DB_PARA(DBN_JDNDL01).DBID = "USR1"
		'
		DBN_MEIMTA = 25
		DB_PARA(DBN_MEIMTA).TBLID = "MEIMTA"
		DB_PARA(DBN_MEIMTA).DBID = "USR1"
		'
		DBN_UNYMTA = 26
		DB_PARA(DBN_UNYMTA).TBLID = "UNYMTA"
		DB_PARA(DBN_UNYMTA).DBID = "USR1"
		'
		DBN_BMNMTA = 27
		DB_PARA(DBN_BMNMTA).TBLID = "BMNMTA"
		DB_PARA(DBN_BMNMTA).DBID = "USR1"
		'
		DBN_SRAET53 = 28
		DB_PARA(DBN_SRAET53).TBLID = "SRAET53"
		DB_PARA(DBN_SRAET53).DBID = "USR9"
		'
		DBN_SRACNTTB = 29
		DB_PARA(DBN_SRACNTTB).TBLID = "SRACNTTB"
		DB_PARA(DBN_SRACNTTB).DBID = "USR1"
		'
		DBN_SRARSTTB = 30
		DB_PARA(DBN_SRARSTTB).TBLID = "SRARSTTB"
		DB_PARA(DBN_SRARSTTB).DBID = "USR1"
		'
		DBN_SRLTRA = 31
		DB_PARA(DBN_SRLTRA).TBLID = "SRLTRA"
		DB_PARA(DBN_SRLTRA).DBID = "USR1"
		'
		DBN_EXCTBZ = 32
		DB_PARA(DBN_EXCTBZ).TBLID = "EXCTBZ"
		DB_PARA(DBN_EXCTBZ).DBID = "USR1"
		'
		DBN_GYMTBZ = 33
		DB_PARA(DBN_GYMTBZ).TBLID = "GYMTBZ"
		DB_PARA(DBN_GYMTBZ).DBID = "USR1"
		'
		DBN_KNGMTB = 34
		DB_PARA(DBN_KNGMTB).TBLID = "KNGMTB"
		DB_PARA(DBN_KNGMTB).DBID = "USR1"
		'
		DBN_TANWTA = 35
		DB_PARA(DBN_TANWTA).TBLID = "TANWTA"
		DB_PARA(DBN_TANWTA).DBID = "USR1"
		'
		DBN_TANSMA = -1
		'
		DBN_TOKSMC = -2
		'
		DBN_TOKSMA = -3
		'
		DBN_TOKSSA = -4
		'
		DBN_TOKSMB = -5
		'
		DBN_TOKSME = -6
		'
		DBN_ZAISMA = -7
		'
		DBN_TOKSSB = -8
		
		SSS_BILFL = 9
	End Sub
	
	Sub SCR_FromFDNTHA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_BINCD(De, DB_FDNTHA.BINCD)
		Call DP_SSSMAIN_BUNNM(De, DB_FDNTHA.BUMNM)
		Call DP_SSSMAIN_CANKB(De, DB_FDNTHA.CANKB)
		Call DP_SSSMAIN_CASEMKA(De, DB_FDNTHA.CASEMKA)
		Call DP_SSSMAIN_CASEMKB(De, DB_FDNTHA.CASEMKB)
		Call DP_SSSMAIN_CASEMKC(De, DB_FDNTHA.CASEMKC)
		Call DP_SSSMAIN_CASEMKD(De, DB_FDNTHA.CASEMKD)
		Call DP_SSSMAIN_CASEMKE(De, DB_FDNTHA.CASEMKE)
		Call DP_SSSMAIN_DATNO(De, DB_FDNTHA.DATNO)
		Call DP_SSSMAIN_DEFNOKDT(De, DB_FDNTHA.DEFNOKDT)
		Call DP_SSSMAIN_DENCM(De, DB_FDNTHA.DENCM)
		Call DP_SSSMAIN_FDNDT(De, DB_FDNTHA.FDNDT)
		Call DP_SSSMAIN_FDNNO(De, DB_FDNTHA.FDNNO)
		Call DP_SSSMAIN_INPBSCD(De, DB_FDNTHA.INPBSCD)
		Call DP_SSSMAIN_INPSOUCD(De, DB_FDNTHA.INPSOUCD)
		Call DP_SSSMAIN_INVNO(De, DB_FDNTHA.INVNO)
		Call DP_SSSMAIN_NHSADA(De, DB_FDNTHA.NHSADA)
		Call DP_SSSMAIN_NHSADB(De, DB_FDNTHA.NHSADB)
		Call DP_SSSMAIN_NHSADC(De, DB_FDNTHA.NHSADC)
		Call DP_SSSMAIN_NHSCD(De, DB_FDNTHA.NHSCD)
		Call DP_SSSMAIN_NHSNMA(De, DB_FDNTHA.NHSNMA)
		Call DP_SSSMAIN_NHSNMB(De, DB_FDNTHA.NHSNMB)
		Call DP_SSSMAIN_ODNYTDT(De, DB_FDNTHA.ODNYTDT)
		Call DP_SSSMAIN_OUTBSCD(De, DB_FDNTHA.OUTBSCD)
		Call DP_SSSMAIN_PUDLNO(De, DB_FDNTHA.PUDLNO)
		Call DP_SSSMAIN_SHFDNNO(De, DB_FDNTHA.SHFDNNO)
		Call DP_SSSMAIN_SIMUKE(De, DB_FDNTHA.SIMUKE)
		Call DP_SSSMAIN_SOUCD(De, DB_FDNTHA.OUTSOUCD)
		Call DP_SSSMAIN_TANNM(De, DB_FDNTHA.TANNM)
		Call DP_SSSMAIN_TOKCD(De, DB_FDNTHA.TOKCD)
		Call DP_SSSMAIN_WRKKB(De, DB_FDNTHA.WRKKB)
	End Sub
	
	Sub FDNTHA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.BINCD = RD_SSSMAIN_BINCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BUNNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.BUMNM = RD_SSSMAIN_BUNNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CANKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.CANKB = RD_SSSMAIN_CANKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CASEMKA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.CASEMKA = RD_SSSMAIN_CASEMKA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CASEMKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.CASEMKB = RD_SSSMAIN_CASEMKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CASEMKC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.CASEMKC = RD_SSSMAIN_CASEMKC(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CASEMKD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.CASEMKD = RD_SSSMAIN_CASEMKD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CASEMKE() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.CASEMKE = RD_SSSMAIN_CASEMKE(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.DATNO = RD_SSSMAIN_DATNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DEFNOKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.DEFNOKDT = RD_SSSMAIN_DEFNOKDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENCM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.DENCM = RD_SSSMAIN_DENCM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FDNDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.FDNDT = RD_SSSMAIN_FDNDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.FDNNO = RD_SSSMAIN_FDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPBSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.INPBSCD = RD_SSSMAIN_INPBSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPSOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.INPSOUCD = RD_SSSMAIN_INPSOUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INVNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.INVNO = RD_SSSMAIN_INVNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.NHSADA = RD_SSSMAIN_NHSADA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.NHSADB = RD_SSSMAIN_NHSADB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.NHSADC = RD_SSSMAIN_NHSADC(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.NHSCD = RD_SSSMAIN_NHSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.NHSNMA = RD_SSSMAIN_NHSNMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.NHSNMB = RD_SSSMAIN_NHSNMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ODNYTDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.ODNYTDT = RD_SSSMAIN_ODNYTDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OUTBSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.OUTBSCD = RD_SSSMAIN_OUTBSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_PUDLNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.PUDLNO = RD_SSSMAIN_PUDLNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SHFDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.SHFDNNO = RD_SSSMAIN_SHFDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SIMUKE() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.SIMUKE = RD_SSSMAIN_SIMUKE(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.OUTSOUCD = RD_SSSMAIN_SOUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.TANNM = RD_SSSMAIN_TANNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.TOKCD = RD_SSSMAIN_TOKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_WRKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.WRKKB = RD_SSSMAIN_WRKKB(De)
		DB_FDNTHA.OPEID = SSS_OPEID.Value
		DB_FDNTHA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_FDNTHA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_FDNTHA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_FDNTHA.WRTTM = DB_ORATM
			DB_FDNTHA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromFDNTRA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_BINCD(De, DB_FDNTRA.BINCD)
		Call DP_SSSMAIN_BKTHKKB(De, DB_FDNTRA.BKTHKKB)
		Call DP_SSSMAIN_BUNNM(De, DB_FDNTRA.BUMNM)
		Call DP_SSSMAIN_CANKB(De, DB_FDNTRA.CANKB)
		Call DP_SSSMAIN_DATNO(De, DB_FDNTRA.DATNO)
		Call DP_SSSMAIN_DEFNOKDT(De, DB_FDNTRA.DEFNOKDT)
		Call DP_SSSMAIN_DENCM(De, DB_FDNTRA.DENCM)
		Call DP_SSSMAIN_FDNDT(De, DB_FDNTRA.FDNDT)
		Call DP_SSSMAIN_FDNNO(De, DB_FDNTRA.FDNNO)
		Call DP_SSSMAIN_FDNZMIFL(De, DB_FDNTRA.FDNZMIFL)
		Call DP_SSSMAIN_FRDKN(De, DB_FDNTRA.FRDKN)
		Call DP_SSSMAIN_FRDSU(De, DB_FDNTRA.FRDSU)
		Call DP_SSSMAIN_FRDTK(De, DB_FDNTRA.FRDTK)
		Call DP_SSSMAIN_FRDYTSU(De, DB_FDNTRA.FRDYTSU)
		Call DP_SSSMAIN_HIKSU(De, DB_FDNTRA.HIKSU)
		Call DP_SSSMAIN_HINCD(De, DB_FDNTRA.HINCD)
		Call DP_SSSMAIN_HINNMA(De, DB_FDNTRA.HINNMA)
		Call DP_SSSMAIN_HINNMB(De, DB_FDNTRA.HINNMB)
		Call DP_SSSMAIN_INPBSCD(De, DB_FDNTRA.INPBSCD)
		Call DP_SSSMAIN_INPSOUCD(De, DB_FDNTRA.INPSOUCD)
		Call DP_SSSMAIN_INVNO(De, DB_FDNTRA.INVNO)
		Call DP_SSSMAIN_JANCD(De, DB_FDNTRA.JANCD)
		Call DP_SSSMAIN_JDNLINNO(De, DB_FDNTRA.JDNLINNO)
		Call DP_SSSMAIN_JDNNO(De, DB_FDNTRA.JDNNO)
		Call DP_SSSMAIN_LINCMA(De, DB_FDNTRA.LINCMA)
		Call DP_SSSMAIN_LINCMB(De, DB_FDNTRA.LINCMB)
		Call DP_SSSMAIN_LINNO(De, DB_FDNTRA.LINNO)
		Call DP_SSSMAIN_LOTNO(De, DB_FDNTRA.LOTNO)
		Call DP_SSSMAIN_NHSADA(De, DB_FDNTRA.NHSADA)
		Call DP_SSSMAIN_NHSADB(De, DB_FDNTRA.NHSADB)
		Call DP_SSSMAIN_NHSADC(De, DB_FDNTRA.NHSADC)
		Call DP_SSSMAIN_NHSCD(De, DB_FDNTRA.NHSCD)
		Call DP_SSSMAIN_NHSNMA(De, DB_FDNTRA.NHSNMA)
		Call DP_SSSMAIN_NHSNMB(De, DB_FDNTRA.NHSNMB)
		Call DP_SSSMAIN_ODNYTDT(De, DB_FDNTRA.ODNYTDT)
		Call DP_SSSMAIN_OTPSU(De, DB_FDNTRA.OTPSU)
		Call DP_SSSMAIN_OUTBSCD(De, DB_FDNTRA.OUTBSCD)
		Call DP_SSSMAIN_PUDLNO(De, DB_FDNTRA.PUDLNO)
		Call DP_SSSMAIN_RECNO(De, DB_FDNTRA.RECNO)
		Call DP_SSSMAIN_SBNNO(De, DB_FDNTRA.SBNNO)
		Call DP_SSSMAIN_SHFDNNO(De, DB_FDNTRA.SHFDNNO)
		Call DP_SSSMAIN_SOUCD(De, DB_FDNTRA.OUTSOUCD)
		Call DP_SSSMAIN_SYKDATNO(De, DB_FDNTRA.SYKDATNO)
		Call DP_SSSMAIN_TANNM(De, DB_FDNTRA.TANNM)
		Call DP_SSSMAIN_TOKCD(De, DB_FDNTRA.TOKCD)
		Call DP_SSSMAIN_TOKJDNED(De, DB_FDNTRA.TOKJDNED)
		Call DP_SSSMAIN_TOKJDNNO(De, DB_FDNTRA.TOKJDNNO)
		Call DP_SSSMAIN_URIKN(De, DB_FDNTRA.FRDKN)
		Call DP_SSSMAIN_URISU(De, DB_FDNTRA.FRDSU)
		Call DP_SSSMAIN_UZEKN(De, DB_FDNTRA.UZEKN)
		Call DP_SSSMAIN_WRKKB(De, DB_FDNTRA.WRKKB)
	End Sub
	
	Sub FDNTRA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.BINCD = RD_SSSMAIN_BINCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BKTHKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.BKTHKKB = RD_SSSMAIN_BKTHKKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BUNNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.BUMNM = RD_SSSMAIN_BUNNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CANKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.CANKB = RD_SSSMAIN_CANKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.DATNO = RD_SSSMAIN_DATNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DEFNOKDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.DEFNOKDT = RD_SSSMAIN_DEFNOKDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENCM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.DENCM = RD_SSSMAIN_DENCM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FDNDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.FDNDT = RD_SSSMAIN_FDNDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.FDNNO = RD_SSSMAIN_FDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FDNZMIFL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.FDNZMIFL = RD_SSSMAIN_FDNZMIFL(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FRDKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.FRDKN = RD_SSSMAIN_FRDKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FRDSU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.FRDSU = RD_SSSMAIN_FRDSU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FRDTK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.FRDTK = RD_SSSMAIN_FRDTK(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FRDYTSU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.FRDYTSU = RD_SSSMAIN_FRDYTSU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HIKSU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.HIKSU = RD_SSSMAIN_HIKSU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.HINCD = RD_SSSMAIN_HINCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.HINNMA = RD_SSSMAIN_HINNMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.HINNMB = RD_SSSMAIN_HINNMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPBSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.INPBSCD = RD_SSSMAIN_INPBSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPSOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.INPSOUCD = RD_SSSMAIN_INPSOUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INVNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.INVNO = RD_SSSMAIN_INVNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JANCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.JANCD = RD_SSSMAIN_JANCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNLINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.JDNLINNO = RD_SSSMAIN_JDNLINNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.JDNNO = RD_SSSMAIN_JDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LINCMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.LINCMA = RD_SSSMAIN_LINCMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LINCMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.LINCMB = RD_SSSMAIN_LINCMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.LINNO = RD_SSSMAIN_LINNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LOTNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.LOTNO = RD_SSSMAIN_LOTNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.NHSADA = RD_SSSMAIN_NHSADA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.NHSADB = RD_SSSMAIN_NHSADB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.NHSADC = RD_SSSMAIN_NHSADC(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.NHSCD = RD_SSSMAIN_NHSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.NHSNMA = RD_SSSMAIN_NHSNMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.NHSNMB = RD_SSSMAIN_NHSNMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ODNYTDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.ODNYTDT = RD_SSSMAIN_ODNYTDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OTPSU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.OTPSU = RD_SSSMAIN_OTPSU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OUTBSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.OUTBSCD = RD_SSSMAIN_OUTBSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_PUDLNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.PUDLNO = RD_SSSMAIN_PUDLNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RECNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.RECNO = RD_SSSMAIN_RECNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.SBNNO = RD_SSSMAIN_SBNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SHFDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.SHFDNNO = RD_SSSMAIN_SHFDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.OUTSOUCD = RD_SSSMAIN_SOUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SYKDATNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.SYKDATNO = RD_SSSMAIN_SYKDATNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.TANNM = RD_SSSMAIN_TANNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.TOKCD = RD_SSSMAIN_TOKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKJDNED() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.TOKJDNED = RD_SSSMAIN_TOKJDNED(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKJDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.TOKJDNNO = RD_SSSMAIN_TOKJDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.FRDKN = RD_SSSMAIN_URIKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.FRDSU = RD_SSSMAIN_URISU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UZEKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.UZEKN = RD_SSSMAIN_UZEKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_WRKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.WRKKB = RD_SSSMAIN_WRKKB(De)
		DB_FDNTRA.OPEID = SSS_OPEID.Value
		DB_FDNTRA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_FDNTRA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_FDNTRA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_FDNTRA.WRTTM = DB_ORATM
			DB_FDNTRA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromHINMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_GNKTK(De, DB_HINMTA.GNKTK)
		Call DP_SSSMAIN_HINCD(De, DB_HINMTA.HINCD)
		Call DP_SSSMAIN_HINID(De, DB_HINMTA.HINID)
		Call DP_SSSMAIN_HINJUNKB(De, DB_HINMTA.HINJUNKB)
		Call DP_SSSMAIN_HINKB(De, DB_HINMTA.HINKB)
		Call DP_SSSMAIN_HINMSTKB(De, DB_HINMTA.HINMSTKB)
		Call DP_SSSMAIN_HINNMA(De, DB_HINMTA.HINNMA)
		Call DP_SSSMAIN_HINNMB(De, DB_HINMTA.HINNMB)
		Call DP_SSSMAIN_HINNMMKB(De, DB_HINMTA.HINNMMKB)
		Call DP_SSSMAIN_HINSIRCD(De, DB_HINMTA.HINSIRCD)
		Call DP_SSSMAIN_HINZEIKB(De, DB_HINMTA.HINZEIKB)
		Call DP_SSSMAIN_HRTDD(De, DB_HINMTA.HRTDD)
		Call DP_SSSMAIN_MAKCD(De, DB_HINMTA.MAKCD)
		Call DP_SSSMAIN_ORTDD(De, DB_HINMTA.ORTDD)
		Call DP_SSSMAIN_RELFL(De, DB_HINMTA.RELFL)
		Call DP_SSSMAIN_SERIKB(De, DB_HINMTA.SERIKB)
		Call DP_SSSMAIN_UNTCD(De, DB_HINMTA.UNTCD)
		Call DP_SSSMAIN_UNTNM(De, DB_HINMTA.UNTNM)
		Call DP_SSSMAIN_ZAIKB(De, DB_HINMTA.ZAIKB)
		Call DP_SSSMAIN_ZEIRNKKB(De, DB_HINMTA.ZEIRNKKB)
	End Sub
	
	Sub HINMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_GNKTK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.GNKTK = RD_SSSMAIN_GNKTK(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.HINCD = RD_SSSMAIN_HINCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.HINID = RD_SSSMAIN_HINID(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINJUNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.HINJUNKB = RD_SSSMAIN_HINJUNKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.HINKB = RD_SSSMAIN_HINKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.HINMSTKB = RD_SSSMAIN_HINMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.HINNMA = RD_SSSMAIN_HINNMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.HINNMB = RD_SSSMAIN_HINNMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMMKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.HINNMMKB = RD_SSSMAIN_HINNMMKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINSIRCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.HINSIRCD = RD_SSSMAIN_HINSIRCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINZEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.HINZEIKB = RD_SSSMAIN_HINZEIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HRTDD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.HRTDD = RD_SSSMAIN_HRTDD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MAKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.MAKCD = RD_SSSMAIN_MAKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ORTDD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.ORTDD = RD_SSSMAIN_ORTDD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RELFL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.RELFL = RD_SSSMAIN_RELFL(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SERIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.SERIKB = RD_SSSMAIN_SERIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.UNTCD = RD_SSSMAIN_UNTCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.UNTNM = RD_SSSMAIN_UNTNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZAIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.ZAIKB = RD_SSSMAIN_ZAIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZEIRNKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.ZEIRNKKB = RD_SSSMAIN_ZEIRNKKB(De)
		DB_HINMTA.OPEID = SSS_OPEID.Value
		DB_HINMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_HINMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_HINMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_HINMTA.WRTTM = DB_ORATM
			DB_HINMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromMEIMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_JDNTRKB(De, DB_MEIMTA.MEICDA)
		Call DP_SSSMAIN_JDNTRNM(De, DB_MEIMTA.MEINMA)
	End Sub
	
	Sub MEIMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNTRKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_MEIMTA.MEICDA = RD_SSSMAIN_JDNTRKB(De)
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
	
	Sub SCR_FromNHSMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_NHSCD(De, DB_NHSMTA.NHSCD)
		Call DP_SSSMAIN_NHSMSTKB(De, DB_NHSMTA.NHSMSTKB)
		Call DP_SSSMAIN_NHSNMMKB(De, DB_NHSMTA.NHSNMMKB)
		Call DP_SSSMAIN_RELFL(De, DB_NHSMTA.RELFL)
	End Sub
	
	Sub NHSMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSCD = RD_SSSMAIN_NHSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSMSTKB = RD_SSSMAIN_NHSMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNMMKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSNMMKB = RD_SSSMAIN_NHSNMMKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RELFL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.RELFL = RD_SSSMAIN_RELFL(De)
		DB_NHSMTA.OPEID = SSS_OPEID.Value
		DB_NHSMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_NHSMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_NHSMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_NHSMTA.WRTTM = DB_ORATM
			DB_NHSMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromSOUMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_SOUCD(De, DB_SOUMTA.SOUCD)
		Call DP_SSSMAIN_SOUNM(De, DB_SOUMTA.SOUNM)
	End Sub
	
	Sub SOUMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SOUMTA.SOUCD = RD_SSSMAIN_SOUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SOUMTA.SOUNM = RD_SSSMAIN_SOUNM(De)
		DB_SOUMTA.OPEID = SSS_OPEID.Value
		DB_SOUMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_SOUMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_SOUMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_SOUMTA.WRTTM = DB_ORATM
			DB_SOUMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromSYSTBD(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_DFLDKBCD(De, DB_SYSTBD.DFLDKBCD)
		Call DP_SSSMAIN_DKBFLA(De, DB_SYSTBD.DKBFLA)
		Call DP_SSSMAIN_DKBFLB(De, DB_SYSTBD.DKBFLB)
		Call DP_SSSMAIN_DKBFLC(De, DB_SYSTBD.DKBFLC)
		Call DP_SSSMAIN_DKBTEGFL(De, DB_SYSTBD.DKBTEGFL)
		Call DP_SSSMAIN_DKBZAIFL(De, DB_SYSTBD.DKBZAIFL)
		Call DP_SSSMAIN_UDNDKBID(De, DB_SYSTBD.DKBID)
		Call DP_SSSMAIN_UPDID(De, DB_SYSTBD.UPDID)
		'
		Call Scr_HINCD_FromSYSTBD(De)
	End Sub
	
	Sub SYSTBD_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DFLDKBCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SYSTBD.DFLDKBCD = RD_SSSMAIN_DFLDKBCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBFLA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SYSTBD.DKBFLA = RD_SSSMAIN_DKBFLA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBFLB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SYSTBD.DKBFLB = RD_SSSMAIN_DKBFLB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBFLC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SYSTBD.DKBFLC = RD_SSSMAIN_DKBFLC(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBTEGFL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SYSTBD.DKBTEGFL = RD_SSSMAIN_DKBTEGFL(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBZAIFL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SYSTBD.DKBZAIFL = RD_SSSMAIN_DKBZAIFL(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDKBID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SYSTBD.DKBID = RD_SSSMAIN_UDNDKBID(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SYSTBD.UPDID = RD_SSSMAIN_UPDID(De)
		DB_SYSTBD.OPEID = SSS_OPEID.Value
		DB_SYSTBD.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_SYSTBD.WRTTM = VB6.Format(Now, "hhmmss")
			DB_SYSTBD.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_SYSTBD.WRTTM = DB_ORATM
			DB_SYSTBD.WRTDT = DB_ORADT
		End If
		'
		Call SYSTBD_HINCD_FromScr(De)
	End Sub
	
	Sub SCR_FromTANMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_RELFL(De, DB_TANMTA.RELFL)
		Call DP_SSSMAIN_TANMSTKB(De, DB_TANMTA.TANMSTKB)
	End Sub
	
	Sub TANMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RELFL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TANMTA.RELFL = RD_SSSMAIN_RELFL(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TANMTA.TANMSTKB = RD_SSSMAIN_TANMSTKB(De)
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
		Call DP_SSSMAIN_NHSADA(De, DB_TOKMTA.TOKADA)
		Call DP_SSSMAIN_NHSADB(De, DB_TOKMTA.TOKADB)
		Call DP_SSSMAIN_NHSADC(De, DB_TOKMTA.TOKADC)
		Call DP_SSSMAIN_TOKMSTKB(De, DB_TOKMTA.TOKMSTKB)
	End Sub
	
	Sub TOKMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKMTA.TOKADA = RD_SSSMAIN_NHSADA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKMTA.TOKADB = RD_SSSMAIN_NHSADB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKMTA.TOKADC = RD_SSSMAIN_NHSADC(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TOKMTA.TOKMSTKB = RD_SSSMAIN_TOKMSTKB(De)
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
	
	Sub SCR_FromTOKMTB(ByVal De As Short) 'Generated.
	End Sub
	
	Sub TOKMTB_FromSCR(ByVal De As Short) 'Generated.
		DB_TOKMTB.OPEID = SSS_OPEID.Value
		DB_TOKMTB.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_TOKMTB.WRTTM = VB6.Format(Now, "hhmmss")
			DB_TOKMTB.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_TOKMTB.WRTTM = DB_ORATM
			DB_TOKMTB.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromUDNTHA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_AKAKROKB(De, DB_UDNTHA.AKAKROKB)
		Call DP_SSSMAIN_BUMCD(De, DB_UDNTHA.BUMCD)
		Call DP_SSSMAIN_BUNNM(De, DB_UDNTHA.BUMNM)
		Call DP_SSSMAIN_DATKB(De, DB_UDNTHA.DATKB)
		Call DP_SSSMAIN_DATNO(De, DB_UDNTHA.DATNO)
		Call DP_SSSMAIN_DENCM(De, DB_UDNTHA.DENCM)
		Call DP_SSSMAIN_DENCMIN(De, DB_UDNTHA.DENCMIN)
		Call DP_SSSMAIN_DENDT(De, DB_UDNTHA.DENDT)
		Call DP_SSSMAIN_DENKB(De, DB_UDNTHA.DENKB)
		Call DP_SSSMAIN_FDNNO(De, DB_UDNTHA.FDNNO)
		Call DP_SSSMAIN_FRNKB(De, DB_UDNTHA.FRNKB)
		Call DP_SSSMAIN_INVNO(De, DB_UDNTHA.INVNO)
		Call DP_SSSMAIN_JDNNO(De, DB_UDNTHA.JDNNO)
		Call DP_SSSMAIN_JDNTRKB(De, DB_UDNTHA.JDNTRKB)
		Call DP_SSSMAIN_KEIBUMCD(De, DB_UDNTHA.KEIBUMCD)
		Call DP_SSSMAIN_KENNMA(De, DB_UDNTHA.KENNMA)
		Call DP_SSSMAIN_KENNMB(De, DB_UDNTHA.KENNMB)
		Call DP_SSSMAIN_LSTID(De, DB_UDNTHA.LSTID)
		Call DP_SSSMAIN_MAEUKKB(De, DB_UDNTHA.MAEUKKB)
		Call DP_SSSMAIN_MAEUKNM(De, DB_UDNTHA.MAEUKNM)
		Call DP_SSSMAIN_NHSADA(De, DB_UDNTHA.NHSADA)
		Call DP_SSSMAIN_NHSADB(De, DB_UDNTHA.NHSADB)
		Call DP_SSSMAIN_NHSADC(De, DB_UDNTHA.NHSADC)
		Call DP_SSSMAIN_NHSCD(De, DB_UDNTHA.NHSCD)
		Call DP_SSSMAIN_NHSMSTKB(De, DB_UDNTHA.NHSMSTKB)
		Call DP_SSSMAIN_NHSNMA(De, DB_UDNTHA.NHSNMA)
		Call DP_SSSMAIN_NHSNMB(De, DB_UDNTHA.NHSNMB)
		Call DP_SSSMAIN_NHSNMMKB(De, DB_UDNTHA.NHSNMMKB)
		Call DP_SSSMAIN_NHSRN(De, DB_UDNTHA.NHSRN)
		Call DP_SSSMAIN_NXTKB(De, DB_UDNTHA.NXTKB)
		Call DP_SSSMAIN_NXTNM(De, DB_UDNTHA.NXTNM)
		Call DP_SSSMAIN_NYUCD(De, DB_UDNTHA.NYUCD)
		Call DP_SSSMAIN_OKRJONO(De, DB_UDNTHA.OKRJONO)
		Call DP_SSSMAIN_REGDT(De, DB_UDNTHA.REGDT)
		Call DP_SSSMAIN_SBADENKN(De, DB_UDNTHA.SBAUZKKN)
		Call DP_SSSMAIN_SBAFRNKN(De, DB_UDNTHA.SBAFRNKN)
		Call DP_SSSMAIN_SBAFRUKN(De, DB_UDNTHA.SBAFRUKN)
		Call DP_SSSMAIN_SBANYUKN(De, DB_UDNTHA.SBANYUKN)
		Call DP_SSSMAIN_SBAURIKN(De, DB_UDNTHA.SBAURIKN)
		Call DP_SSSMAIN_SBAUZEKN(De, DB_UDNTHA.SBAUZEKN)
		Call DP_SSSMAIN_SEIKB(De, DB_UDNTHA.SEIKB)
		Call DP_SSSMAIN_SMADT(De, DB_UDNTHA.SMADT)
		Call DP_SSSMAIN_SOUCD(De, DB_UDNTHA.SOUCD)
		Call DP_SSSMAIN_SOUNM(De, DB_UDNTHA.SOUNM)
		Call DP_SSSMAIN_SSADT(De, DB_UDNTHA.SSADT)
		Call DP_SSSMAIN_TANCD(De, DB_UDNTHA.TANCD)
		Call DP_SSSMAIN_TANMSTKB(De, DB_UDNTHA.TANMSTKB)
		Call DP_SSSMAIN_TANNM(De, DB_UDNTHA.TANNM)
		Call DP_SSSMAIN_TKNRPSKB(De, DB_UDNTHA.TKNRPSKB)
		Call DP_SSSMAIN_TKNZRNKB(De, DB_UDNTHA.TKNZRNKB)
		Call DP_SSSMAIN_TOKCD(De, DB_UDNTHA.TOKCD)
		Call DP_SSSMAIN_TOKJUNKB(De, DB_UDNTHA.TOKJUNKB)
		Call DP_SSSMAIN_TOKKDWKB(De, DB_UDNTHA.TOKKDWKB)
		Call DP_SSSMAIN_TOKKESCC(De, DB_UDNTHA.TOKKESCC)
		Call DP_SSSMAIN_TOKKESDD(De, DB_UDNTHA.TOKKESDD)
		Call DP_SSSMAIN_TOKMSTKB(De, DB_UDNTHA.TOKMSTKB)
		Call DP_SSSMAIN_TOKNMMKB(De, DB_UDNTHA.TOKNMMKB)
		Call DP_SSSMAIN_TOKRN(De, DB_UDNTHA.TOKRN)
		Call DP_SSSMAIN_TOKRPSKB(De, DB_UDNTHA.TOKRPSKB)
		Call DP_SSSMAIN_TOKSDWKB(De, DB_UDNTHA.TOKSDWKB)
		Call DP_SSSMAIN_TOKSEICD(De, DB_UDNTHA.TOKSEICD)
		Call DP_SSSMAIN_TOKSMECC(De, DB_UDNTHA.TOKSMECC)
		Call DP_SSSMAIN_TOKSMEDD(De, DB_UDNTHA.TOKSMEDD)
		Call DP_SSSMAIN_TOKSMEKB(De, DB_UDNTHA.TOKSMEKB)
		Call DP_SSSMAIN_TOKZCLKB(De, DB_UDNTHA.TOKZCLKB)
		Call DP_SSSMAIN_TOKZEIKB(De, DB_UDNTHA.TOKZEIKB)
		Call DP_SSSMAIN_TOKZRNKB(De, DB_UDNTHA.TOKZRNKB)
		Call DP_SSSMAIN_TUKKB(De, DB_UDNTHA.TUKKB)
		Call DP_SSSMAIN_UDNDT(De, DB_UDNTHA.UDNDT)
		Call DP_SSSMAIN_UDNNO(De, DB_UDNTHA.UDNNO)
		Call DP_SSSMAIN_UPFKB(De, DB_UDNTHA.UPFKB)
		Call DP_SSSMAIN_URIKJN(De, DB_UDNTHA.URIKJN)
		Call DP_SSSMAIN_USDNO(De, DB_UDNTHA.USDNO)
		Call DP_SSSMAIN_ZKTKB(De, DB_UDNTHA.ZKTKB)
		Call DP_SSSMAIN_ZKTNM(De, DB_UDNTHA.ZKTNM)
	End Sub
	
	Sub UDNTHA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_AKAKROKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.AKAKROKB = RD_SSSMAIN_AKAKROKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BUMCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.BUMCD = RD_SSSMAIN_BUMCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BUNNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.BUMNM = RD_SSSMAIN_BUNNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.DATKB = RD_SSSMAIN_DATKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.DATNO = RD_SSSMAIN_DATNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENCM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.DENCM = RD_SSSMAIN_DENCM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENCMIN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.DENCMIN = RD_SSSMAIN_DENCMIN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.DENDT = RD_SSSMAIN_DENDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.DENKB = RD_SSSMAIN_DENKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.FDNNO = RD_SSSMAIN_FDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FRNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.FRNKB = RD_SSSMAIN_FRNKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INVNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.INVNO = RD_SSSMAIN_INVNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.JDNNO = RD_SSSMAIN_JDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNTRKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.JDNTRKB = RD_SSSMAIN_JDNTRKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_KEIBUMCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.KEIBUMCD = RD_SSSMAIN_KEIBUMCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_KENNMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.KENNMA = RD_SSSMAIN_KENNMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_KENNMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.KENNMB = RD_SSSMAIN_KENNMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LSTID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.LSTID = RD_SSSMAIN_LSTID(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MAEUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.MAEUKKB = RD_SSSMAIN_MAEUKKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MAEUKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.MAEUKNM = RD_SSSMAIN_MAEUKNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.NHSADA = RD_SSSMAIN_NHSADA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.NHSADB = RD_SSSMAIN_NHSADB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.NHSADC = RD_SSSMAIN_NHSADC(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.NHSCD = RD_SSSMAIN_NHSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.NHSMSTKB = RD_SSSMAIN_NHSMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.NHSNMA = RD_SSSMAIN_NHSNMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.NHSNMB = RD_SSSMAIN_NHSNMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNMMKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.NHSNMMKB = RD_SSSMAIN_NHSNMMKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.NHSRN = RD_SSSMAIN_NHSRN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NXTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.NXTKB = RD_SSSMAIN_NXTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NXTNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.NXTNM = RD_SSSMAIN_NXTNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NYUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.NYUCD = RD_SSSMAIN_NYUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OKRJONO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.OKRJONO = RD_SSSMAIN_OKRJONO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_REGDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.REGDT = RD_SSSMAIN_REGDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBADENKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SBAUZKKN = RD_SSSMAIN_SBADENKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAFRNKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SBAFRNKN = RD_SSSMAIN_SBAFRNKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAFRUKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SBAFRUKN = RD_SSSMAIN_SBAFRUKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBANYUKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SBANYUKN = RD_SSSMAIN_SBANYUKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAURIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SBAURIKN = RD_SSSMAIN_SBAURIKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAUZEKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SBAUZEKN = RD_SSSMAIN_SBAUZEKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SEIKB = RD_SSSMAIN_SEIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMADT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SMADT = RD_SSSMAIN_SMADT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SOUCD = RD_SSSMAIN_SOUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SOUNM = RD_SSSMAIN_SOUNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SSADT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SSADT = RD_SSSMAIN_SSADT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TANCD = RD_SSSMAIN_TANCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TANMSTKB = RD_SSSMAIN_TANMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TANNM = RD_SSSMAIN_TANNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TKNRPSKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TKNRPSKB = RD_SSSMAIN_TKNRPSKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TKNZRNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TKNZRNKB = RD_SSSMAIN_TKNZRNKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKCD = RD_SSSMAIN_TOKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKJUNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKJUNKB = RD_SSSMAIN_TOKJUNKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKKDWKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKKDWKB = RD_SSSMAIN_TOKKDWKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKKESCC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKKESCC = RD_SSSMAIN_TOKKESCC(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKKESDD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKKESDD = RD_SSSMAIN_TOKKESDD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKMSTKB = RD_SSSMAIN_TOKMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKNMMKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKNMMKB = RD_SSSMAIN_TOKNMMKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKRN = RD_SSSMAIN_TOKRN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKRPSKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKRPSKB = RD_SSSMAIN_TOKRPSKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKSDWKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKSDWKB = RD_SSSMAIN_TOKSDWKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKSEICD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKSEICD = RD_SSSMAIN_TOKSEICD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKSMECC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKSMECC = RD_SSSMAIN_TOKSMECC(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKSMEDD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKSMEDD = RD_SSSMAIN_TOKSMEDD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKSMEKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKSMEKB = RD_SSSMAIN_TOKSMEKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZCLKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKZCLKB = RD_SSSMAIN_TOKZCLKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKZEIKB = RD_SSSMAIN_TOKZEIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZRNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKZRNKB = RD_SSSMAIN_TOKZRNKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TUKKB = RD_SSSMAIN_TUKKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.UDNDT = RD_SSSMAIN_UDNDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.UDNNO = RD_SSSMAIN_UDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPFKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.UPFKB = RD_SSSMAIN_UPFKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URIKJN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.URIKJN = RD_SSSMAIN_URIKJN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_USDNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.USDNO = RD_SSSMAIN_USDNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZKTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.ZKTKB = RD_SSSMAIN_ZKTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZKTNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.ZKTNM = RD_SSSMAIN_ZKTNM(De)
		DB_UDNTHA.OPEID = SSS_OPEID.Value
		DB_UDNTHA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_UDNTHA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_UDNTHA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_UDNTHA.WRTTM = DB_ORATM
			DB_UDNTHA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_AKAKROKB(De, DB_UDNTRA.AKAKROKB)
		Call DP_SSSMAIN_BNKCD(De, DB_UDNTRA.BNKCD)
		Call DP_SSSMAIN_BNKNM(De, DB_UDNTRA.BNKNM)
		Call DP_SSSMAIN_CASSU(De, DB_UDNTRA.CASSU)
		Call DP_SSSMAIN_DATKB(De, DB_UDNTRA.DATKB)
		Call DP_SSSMAIN_DATNO(De, DB_UDNTRA.DATNO)
		Call DP_SSSMAIN_DENKB(De, DB_UDNTRA.DENKB)
		Call DP_SSSMAIN_DFLDKBCD(De, DB_UDNTRA.DFLDKBCD)
		Call DP_SSSMAIN_DKBFLA(De, DB_UDNTRA.DKBFLA)
		Call DP_SSSMAIN_DKBFLB(De, DB_UDNTRA.DKBFLB)
		Call DP_SSSMAIN_DKBFLC(De, DB_UDNTRA.DKBFLC)
		Call DP_SSSMAIN_DKBNM(De, DB_UDNTRA.DKBNM)
		Call DP_SSSMAIN_DKBSB(De, DB_UDNTRA.DKBSB)
		Call DP_SSSMAIN_DKBTEGFL(De, DB_UDNTRA.DKBTEGFL)
		Call DP_SSSMAIN_DKBZAIFL(De, DB_UDNTRA.DKBZAIFL)
		Call DP_SSSMAIN_FKESIKN(De, DB_UDNTRA.FKESIKN)
		Call DP_SSSMAIN_FNYUKN(De, DB_UDNTRA.FNYUKN)
		Call DP_SSSMAIN_FURIKN(De, DB_UDNTRA.FURIKN)
		Call DP_SSSMAIN_FURITK(De, DB_UDNTRA.FURITK)
		Call DP_SSSMAIN_GNKKN(De, DB_UDNTRA.GNKKN)
		Call DP_SSSMAIN_GNKTK(De, DB_UDNTRA.GNKTK)
		Call DP_SSSMAIN_HENRSNCD(De, DB_UDNTRA.HENRSNCD)
		Call DP_SSSMAIN_HENSTTCD(De, DB_UDNTRA.HENSTTCD)
		Call DP_SSSMAIN_HINCD(De, DB_UDNTRA.HINCD)
		Call DP_SSSMAIN_HINJUNKB(De, DB_UDNTRA.HINJUNKB)
		Call DP_SSSMAIN_HINKB(De, DB_UDNTRA.HINKB)
		Call DP_SSSMAIN_HINMSTKB(De, DB_UDNTRA.HINMSTKB)
		Call DP_SSSMAIN_HINNMA(De, DB_UDNTRA.HINNMA)
		Call DP_SSSMAIN_HINNMB(De, DB_UDNTRA.HINNMB)
		Call DP_SSSMAIN_HINNMMKB(De, DB_UDNTRA.HINNMMKB)
		Call DP_SSSMAIN_HINSIRCD(De, DB_UDNTRA.HINSIRCD)
		Call DP_SSSMAIN_HINZEIKB(De, DB_UDNTRA.HINZEIKB)
		Call DP_SSSMAIN_HRTDD(De, DB_UDNTRA.HRTDD)
		Call DP_SSSMAIN_INVNO(De, DB_UDNTRA.INVNO)
		Call DP_SSSMAIN_IRISU(De, DB_UDNTRA.IRISU)
		Call DP_SSSMAIN_JDNLINNO(De, DB_UDNTRA.JDNLINNO)
		Call DP_SSSMAIN_JDNNO(De, DB_UDNTRA.JDNNO)
		Call DP_SSSMAIN_JKESIKN(De, DB_UDNTRA.JKESIKN)
		Call DP_SSSMAIN_KESIKB(De, DB_UDNTRA.KESIKB)
		Call DP_SSSMAIN_LINCMA(De, DB_UDNTRA.LINCMA)
		Call DP_SSSMAIN_LINCMB(De, DB_UDNTRA.LINCMB)
		Call DP_SSSMAIN_LINNO(De, DB_UDNTRA.LINNO)
		Call DP_SSSMAIN_LSTID(De, DB_UDNTRA.LSTID)
		Call DP_SSSMAIN_MAKCD(De, DB_UDNTRA.MAKCD)
		Call DP_SSSMAIN_MRPKB(De, DB_UDNTRA.MRPKB)
		Call DP_SSSMAIN_NHSCD(De, DB_UDNTRA.NHSCD)
		Call DP_SSSMAIN_NHSMSTKB(De, DB_UDNTRA.NHSMSTKB)
		Call DP_SSSMAIN_NYUDT(De, DB_UDNTRA.NYUDT)
		Call DP_SSSMAIN_NYUKB(De, DB_UDNTRA.NYUKB)
		Call DP_SSSMAIN_NYUKN(De, DB_UDNTRA.NYUKN)
		Call DP_SSSMAIN_ODNLINNO(De, DB_UDNTRA.ODNLINNO)
		Call DP_SSSMAIN_ODNNO(De, DB_UDNTRA.ODNNO)
		Call DP_SSSMAIN_OKRJONO(De, DB_UDNTRA.OKRJONO)
		Call DP_SSSMAIN_ORTDD(De, DB_UDNTRA.ORTDD)
		Call DP_SSSMAIN_RATERT(De, DB_UDNTRA.RATERT)
		Call DP_SSSMAIN_RECNO(De, DB_UDNTRA.RECNO)
		Call DP_SSSMAIN_SBNNO(De, DB_UDNTRA.SBNNO)
		Call DP_SSSMAIN_SIKKN(De, DB_UDNTRA.SIKKN)
		Call DP_SSSMAIN_SIKTK(De, DB_UDNTRA.SIKTK)
		Call DP_SSSMAIN_SMADT(De, DB_UDNTRA.SMADT)
		Call DP_SSSMAIN_SOUCD(De, DB_UDNTRA.SOUCD)
		Call DP_SSSMAIN_SSADT(De, DB_UDNTRA.SSADT)
		Call DP_SSSMAIN_TANCD(De, DB_UDNTRA.TANCD)
		Call DP_SSSMAIN_TANMSTKB(De, DB_UDNTRA.TANMSTKB)
		Call DP_SSSMAIN_TEGDT(De, DB_UDNTRA.TEGDT)
		Call DP_SSSMAIN_TEGNO(De, DB_UDNTRA.TEGNO)
		Call DP_SSSMAIN_TNKID(De, DB_UDNTRA.TNKID)
		Call DP_SSSMAIN_TOKCD(De, DB_UDNTRA.TOKCD)
		Call DP_SSSMAIN_TOKJDNNO(De, DB_UDNTRA.TOKJDNNO)
		Call DP_SSSMAIN_TOKMSTKB(De, DB_UDNTRA.TOKMSTKB)
		Call DP_SSSMAIN_TOKSEICD(De, DB_UDNTRA.TOKSEICD)
		Call DP_SSSMAIN_TUKKB(De, DB_UDNTRA.TUKKB)
		Call DP_SSSMAIN_UDNDKBID(De, DB_UDNTRA.DKBID)
		Call DP_SSSMAIN_UDNDT(De, DB_UDNTRA.UDNDT)
		Call DP_SSSMAIN_UDNNO(De, DB_UDNTRA.UDNNO)
		Call DP_SSSMAIN_UNTCD(De, DB_UDNTRA.UNTCD)
		Call DP_SSSMAIN_UNTNM(De, DB_UDNTRA.UNTNM)
		Call DP_SSSMAIN_UPDID(De, DB_UDNTRA.UPDID)
		Call DP_SSSMAIN_URIKN(De, DB_UDNTRA.URIKN)
		Call DP_SSSMAIN_URISU(De, DB_UDNTRA.URISU)
		Call DP_SSSMAIN_URITK(De, DB_UDNTRA.URITK)
		Call DP_SSSMAIN_USDNO(De, DB_UDNTRA.USDNO)
		Call DP_SSSMAIN_UZEKN(De, DB_UDNTRA.UZEKN)
		Call DP_SSSMAIN_ZAIKB(De, DB_UDNTRA.ZAIKB)
		Call DP_SSSMAIN_ZEIRNKKB(De, DB_UDNTRA.ZEIRNKKB)
		Call DP_SSSMAIN_ZEIRT(De, DB_UDNTRA.ZEIRT)
		Call DP_SSSMAIN_ZKMURIKN(De, DB_UDNTRA.ZKMURIKN)
		Call DP_SSSMAIN_ZKMUZEKN(De, DB_UDNTRA.ZKMUZEKN)
		Call DP_SSSMAIN_ZKTKB(De, DB_UDNTRA.ZKTKB)
		Call DP_SSSMAIN_ZNKURIKN(De, DB_UDNTRA.ZNKURIKN)
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_AKAKROKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.AKAKROKB = RD_SSSMAIN_AKAKROKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BNKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.BNKCD = RD_SSSMAIN_BNKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BNKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.BNKNM = RD_SSSMAIN_BNKNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CASSU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.CASSU = RD_SSSMAIN_CASSU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DATKB = RD_SSSMAIN_DATKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DATNO = RD_SSSMAIN_DATNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DENKB = RD_SSSMAIN_DENKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DFLDKBCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DFLDKBCD = RD_SSSMAIN_DFLDKBCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBFLA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBFLA = RD_SSSMAIN_DKBFLA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBFLB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBFLB = RD_SSSMAIN_DKBFLB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBFLC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBFLC = RD_SSSMAIN_DKBFLC(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBNM = RD_SSSMAIN_DKBNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBSB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBSB = RD_SSSMAIN_DKBSB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBTEGFL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBTEGFL = RD_SSSMAIN_DKBTEGFL(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBZAIFL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBZAIFL = RD_SSSMAIN_DKBZAIFL(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FKESIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.FKESIKN = RD_SSSMAIN_FKESIKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FNYUKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.FNYUKN = RD_SSSMAIN_FNYUKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FURIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.FURIKN = RD_SSSMAIN_FURIKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FURITK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.FURITK = RD_SSSMAIN_FURITK(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_GNKKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.GNKKN = RD_SSSMAIN_GNKKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_GNKTK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.GNKTK = RD_SSSMAIN_GNKTK(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HENRSNCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HENRSNCD = RD_SSSMAIN_HENRSNCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HENSTTCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HENSTTCD = RD_SSSMAIN_HENSTTCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HINCD = RD_SSSMAIN_HINCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINJUNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HINJUNKB = RD_SSSMAIN_HINJUNKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HINKB = RD_SSSMAIN_HINKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HINMSTKB = RD_SSSMAIN_HINMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HINNMA = RD_SSSMAIN_HINNMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HINNMB = RD_SSSMAIN_HINNMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMMKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HINNMMKB = RD_SSSMAIN_HINNMMKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINSIRCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HINSIRCD = RD_SSSMAIN_HINSIRCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINZEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HINZEIKB = RD_SSSMAIN_HINZEIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HRTDD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HRTDD = RD_SSSMAIN_HRTDD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INVNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.INVNO = RD_SSSMAIN_INVNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_IRISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.IRISU = RD_SSSMAIN_IRISU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNLINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.JDNLINNO = RD_SSSMAIN_JDNLINNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.JDNNO = RD_SSSMAIN_JDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JKESIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.JKESIKN = RD_SSSMAIN_JKESIKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_KESIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.KESIKB = RD_SSSMAIN_KESIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LINCMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.LINCMA = RD_SSSMAIN_LINCMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LINCMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.LINCMB = RD_SSSMAIN_LINCMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.LINNO = RD_SSSMAIN_LINNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LSTID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.LSTID = RD_SSSMAIN_LSTID(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MAKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.MAKCD = RD_SSSMAIN_MAKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MRPKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.MRPKB = RD_SSSMAIN_MRPKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.NHSCD = RD_SSSMAIN_NHSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.NHSMSTKB = RD_SSSMAIN_NHSMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NYUDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.NYUDT = RD_SSSMAIN_NYUDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NYUKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.NYUKB = RD_SSSMAIN_NYUKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NYUKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.NYUKN = RD_SSSMAIN_NYUKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ODNLINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.ODNLINNO = RD_SSSMAIN_ODNLINNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ODNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.ODNNO = RD_SSSMAIN_ODNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OKRJONO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.OKRJONO = RD_SSSMAIN_OKRJONO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ORTDD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.ORTDD = RD_SSSMAIN_ORTDD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RATERT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.RATERT = RD_SSSMAIN_RATERT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RECNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.RECNO = RD_SSSMAIN_RECNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.SBNNO = RD_SSSMAIN_SBNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SIKKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.SIKKN = RD_SSSMAIN_SIKKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SIKTK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.SIKTK = RD_SSSMAIN_SIKTK(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMADT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.SMADT = RD_SSSMAIN_SMADT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.SOUCD = RD_SSSMAIN_SOUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SSADT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.SSADT = RD_SSSMAIN_SSADT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TANCD = RD_SSSMAIN_TANCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TANMSTKB = RD_SSSMAIN_TANMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TEGDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TEGDT = RD_SSSMAIN_TEGDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TEGNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TEGNO = RD_SSSMAIN_TEGNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TNKID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TNKID = RD_SSSMAIN_TNKID(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TOKCD = RD_SSSMAIN_TOKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKJDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TOKJDNNO = RD_SSSMAIN_TOKJDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TOKMSTKB = RD_SSSMAIN_TOKMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKSEICD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TOKSEICD = RD_SSSMAIN_TOKSEICD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TUKKB = RD_SSSMAIN_TUKKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDKBID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBID = RD_SSSMAIN_UDNDKBID(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.UDNDT = RD_SSSMAIN_UDNDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.UDNNO = RD_SSSMAIN_UDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.UNTCD = RD_SSSMAIN_UNTCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.UNTNM = RD_SSSMAIN_UNTNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.UPDID = RD_SSSMAIN_UPDID(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.URIKN = RD_SSSMAIN_URIKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.URISU = RD_SSSMAIN_URISU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URITK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.URITK = RD_SSSMAIN_URITK(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_USDNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.USDNO = RD_SSSMAIN_USDNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UZEKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.UZEKN = RD_SSSMAIN_UZEKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZAIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.ZAIKB = RD_SSSMAIN_ZAIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZEIRNKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.ZEIRNKKB = RD_SSSMAIN_ZEIRNKKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZEIRT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.ZEIRT = RD_SSSMAIN_ZEIRT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZKMURIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.ZKMURIKN = RD_SSSMAIN_ZKMURIKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZKMUZEKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.ZKMUZEKN = RD_SSSMAIN_ZKMUZEKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZKTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.ZKTKB = RD_SSSMAIN_ZKTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZNKURIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.ZNKURIKN = RD_SSSMAIN_ZNKURIKN(De)
		DB_UDNTRA.OPEID = SSS_OPEID.Value
		DB_UDNTRA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_UDNTRA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_UDNTRA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_UDNTRA.WRTTM = DB_ORATM
			DB_UDNTRA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub HINMTB_FromUDNTRA() 'Generated.
		Dim i As Short
		
		DB_HINMTB.HINCD = DB_UDNTRA.HINCD
		DB_HINMTB.HINMSTKB = DB_UDNTRA.HINMSTKB
		DB_HINMTB.SOUCD = DB_UDNTRA.SOUCD
		DB_HINMTB.OPEID = SSS_OPEID.Value
		DB_HINMTB.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_HINMTB.WRTTM = VB6.Format(Now, "hhmmss")
			DB_HINMTB.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_HINMTB.WRTTM = DB_ORATM
			DB_HINMTB.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub HINSMA_FromUDNTRA() 'Generated.
		Dim i As Short
		
		DB_HINSMA.HINCD = DB_UDNTRA.HINCD
		DB_HINSMA.SMADT = DB_UDNTRA.SMADT
		DB_HINSMA.SMAGNKKN(SSS_Acnt) = DB_HINSMA.SMAGNKKN(SSS_Acnt) + DB_UDNTRA.GNKKN * SSS_SmfKb
		DB_HINSMA.SMAURIKN(SSS_Acnt) = DB_HINSMA.SMAURIKN(SSS_Acnt) + DB_UDNTRA.URIKN * SSS_SmfKb
		DB_HINSMA.SMAURISU(SSS_Acnt) = DB_HINSMA.SMAURISU(SSS_Acnt) + DB_UDNTRA.URISU * SSS_SmfKb
		DB_HINSMA.OPEID = SSS_OPEID.Value
		DB_HINSMA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_HINSMA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_HINSMA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_HINSMA.WRTTM = DB_ORATM
			DB_HINSMA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub JDNDL01_FromJDNTHA() 'Generated.
		Dim i As Short
		
		DB_JDNDL01.JDNDT = DB_JDNTHA.JDNDT
		DB_JDNDL01.JDNNO = DB_JDNTHA.JDNNO
		DB_JDNDL01.TOKCD = DB_JDNTHA.TOKCD
		DB_JDNDL01.TOKRN = DB_JDNTHA.TOKRN
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
		Else
		End If
	End Sub
	
	Sub TOKMTB_FromUDNTRA() 'Generated.
		Dim i As Short
		
		DB_TOKMTB.HINCD = DB_UDNTRA.HINCD
		DB_TOKMTB.TOKCD = DB_UDNTRA.TOKCD
		DB_TOKMTB.OPEID = SSS_OPEID.Value
		DB_TOKMTB.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_TOKMTB.WRTTM = VB6.Format(Now, "hhmmss")
			DB_TOKMTB.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_TOKMTB.WRTTM = DB_ORATM
			DB_TOKMTB.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub UDNTRA_FromSYSTBD() 'Generated.
		Dim i As Short
		
		DB_UDNTRA.DKBFLA = DB_SYSTBD.DKBFLA
		DB_UDNTRA.DKBFLB = DB_SYSTBD.DKBFLB
		DB_UDNTRA.DKBFLC = DB_SYSTBD.DKBFLC
		DB_UDNTRA.DKBID = DB_SYSTBD.DKBID
		DB_UDNTRA.DKBNM = DB_SYSTBD.DKBNM
		DB_UDNTRA.DKBSB = DB_SYSTBD.DKBSB
		DB_UDNTRA.DKBTEGFL = DB_SYSTBD.DKBTEGFL
		DB_UDNTRA.DKBZAIFL = DB_SYSTBD.DKBZAIFL
		DB_UDNTRA.HINCD = DB_SYSTBD.DFLDKBCD
		DB_UDNTRA.UPDID = DB_SYSTBD.UPDID
		DB_UDNTRA.OPEID = SSS_OPEID.Value
		DB_UDNTRA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_UDNTRA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_UDNTRA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_UDNTRA.WRTTM = DB_ORATM
			DB_UDNTRA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub UDNTRA_FromUDNTHA() 'Generated.
		Dim i As Short
		
		DB_UDNTRA.DATKB = DB_UDNTHA.DATKB
		DB_UDNTRA.DATNO = DB_UDNTHA.DATNO
		DB_UDNTRA.DENKB = DB_UDNTHA.DENKB
		DB_UDNTRA.EMGODNKB = DB_UDNTHA.EMGODNKB
		DB_UDNTRA.INVNO = DB_UDNTHA.INVNO
		DB_UDNTRA.JDNNO = DB_UDNTHA.JDNNO
		DB_UDNTRA.KESDT = DB_UDNTHA.KESDT
		DB_UDNTRA.LSTID = DB_UDNTHA.LSTID
		DB_UDNTRA.NHSCD = DB_UDNTHA.NHSCD
		DB_UDNTRA.NHSMSTKB = DB_UDNTHA.NHSMSTKB
		DB_UDNTRA.OKRJONO = DB_UDNTHA.OKRJONO
		DB_UDNTRA.SMADT = DB_UDNTHA.SMADT
		DB_UDNTRA.SOUCD = DB_UDNTHA.SOUCD
		DB_UDNTRA.SSADT = DB_UDNTHA.SSADT
		DB_UDNTRA.TANCD = DB_UDNTHA.TANCD
		DB_UDNTRA.TANMSTKB = DB_UDNTHA.TANMSTKB
		DB_UDNTRA.TOKCD = DB_UDNTHA.TOKCD
		DB_UDNTRA.TOKMSTKB = DB_UDNTHA.TOKMSTKB
		DB_UDNTRA.TOKSEICD = DB_UDNTHA.TOKSEICD
		DB_UDNTRA.TUKKB = DB_UDNTHA.TUKKB
		DB_UDNTRA.UDNDT = DB_UDNTHA.UDNDT
		DB_UDNTRA.UDNNO = DB_UDNTHA.UDNNO
		DB_UDNTRA.USDNO = DB_UDNTHA.USDNO
		DB_UDNTRA.WRTFSTDT = DB_UDNTHA.WRTFSTDT
		DB_UDNTRA.WRTFSTTM = DB_UDNTHA.WRTFSTTM
		DB_UDNTRA.ZKTKB = DB_UDNTHA.ZKTKB
		DB_UDNTRA.OPEID = SSS_OPEID.Value
		DB_UDNTRA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_UDNTRA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_UDNTRA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_UDNTRA.WRTTM = DB_ORATM
			DB_UDNTRA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub UpdSmf() 'Generated.
	End Sub
    '2019/06/04 DELL START
    '   Sub SetBuf(ByVal Fno As Short) 'Generated.
    '	Select Case Fno
    '		Case DBN_UDNTRA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_UDNTRA)
    '		Case DBN_UDNTHA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_UDNTHA)
    '		Case DBN_FDNTRA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_FDNTRA)
    '		Case DBN_FDNTHA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_FDNTHA)
    '		Case DBN_JDNTRA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_JDNTRA)
    '		Case DBN_JDNTHA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_JDNTHA)
    '		Case DBN_TOKMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_TOKMTA)
    '		Case DBN_TANMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_TANMTA)
    '		Case DBN_SOUMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_SOUMTA)
    '		Case DBN_NHSMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_NHSMTA)
    '		Case DBN_HINMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_HINMTA)
    '		Case DBN_SYSTBA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_SYSTBA)
    '		Case DBN_SYSTBB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_SYSTBB)
    '		Case DBN_SYSTBC
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_SYSTBC)
    '		Case DBN_SYSTBD
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_SYSTBD)
    '		Case DBN_SYSTBF
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_SYSTBF)
    '		Case DBN_SYSTBG
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_SYSTBG)
    '		Case DBN_SYSTBH
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_SYSTBH)
    '		Case DBN_CLSMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_CLSMTA)
    '		Case DBN_CLSMTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_CLSMTB)
    '		Case DBN_TOKMTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_TOKMTB)
    '		Case DBN_HINMTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_HINMTB)
    '		Case DBN_SYSTBI
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_SYSTBI)
    '		Case DBN_HINSMA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_HINSMA)
    '		Case DBN_JDNDL01
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_JDNDL01)
    '		Case DBN_MEIMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_MEIMTA)
    '		Case DBN_UNYMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_UNYMTA)
    '		Case DBN_BMNMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_BMNMTA)
    '		Case DBN_SRAET53
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_SRAET53)
    '		Case DBN_SRACNTTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_SRACNTTB)
    '		Case DBN_SRARSTTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_SRARSTTB)
    '		Case DBN_SRLTRA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_SRLTRA)
    '		Case DBN_EXCTBZ
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_EXCTBZ)
    '		Case DBN_GYMTBZ
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_GYMTBZ)
    '		Case DBN_KNGMTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_KNGMTB)
    '		Case DBN_TANWTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_TANWTA)
    '	End Select
    'End Sub

    'Sub ResetBuf(ByVal Fno As Short) 'Generated.
    '	Select Case Fno
    '		Case DBN_UDNTRA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_UDNTRA = LSet(G_LB)
    '		Case DBN_UDNTHA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_UDNTHA = LSet(G_LB)
    '		Case DBN_FDNTRA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_FDNTRA = LSet(G_LB)
    '		Case DBN_FDNTHA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_FDNTHA = LSet(G_LB)
    '		Case DBN_JDNTRA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_JDNTRA = LSet(G_LB)
    '		Case DBN_JDNTHA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_JDNTHA = LSet(G_LB)
    '		Case DBN_TOKMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_TOKMTA = LSet(G_LB)
    '		Case DBN_TANMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_TANMTA = LSet(G_LB)
    '		Case DBN_SOUMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_SOUMTA = LSet(G_LB)
    '		Case DBN_NHSMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_NHSMTA = LSet(G_LB)
    '		Case DBN_HINMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_HINMTA = LSet(G_LB)
    '		Case DBN_SYSTBA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_SYSTBA = LSet(G_LB)
    '		Case DBN_SYSTBB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_SYSTBB = LSet(G_LB)
    '		Case DBN_SYSTBC
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_SYSTBC = LSet(G_LB)
    '		Case DBN_SYSTBD
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_SYSTBD = LSet(G_LB)
    '		Case DBN_SYSTBF
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_SYSTBF = LSet(G_LB)
    '		Case DBN_SYSTBG
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_SYSTBG = LSet(G_LB)
    '		Case DBN_SYSTBH
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_SYSTBH = LSet(G_LB)
    '		Case DBN_CLSMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_CLSMTA = LSet(G_LB)
    '		Case DBN_CLSMTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_CLSMTB = LSet(G_LB)
    '		Case DBN_TOKMTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_TOKMTB = LSet(G_LB)
    '		Case DBN_HINMTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_HINMTB = LSet(G_LB)
    '		Case DBN_SYSTBI
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_SYSTBI = LSet(G_LB)
    '		Case DBN_HINSMA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_HINSMA = LSet(G_LB)
    '		Case DBN_JDNDL01
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_JDNDL01 = LSet(G_LB)
    '		Case DBN_MEIMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_MEIMTA = LSet(G_LB)
    '		Case DBN_UNYMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_UNYMTA = LSet(G_LB)
    '		Case DBN_BMNMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_BMNMTA = LSet(G_LB)
    '		Case DBN_SRAET53
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_SRAET53 = LSet(G_LB)
    '		Case DBN_SRACNTTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_SRACNTTB = LSet(G_LB)
    '		Case DBN_SRARSTTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_SRARSTTB = LSet(G_LB)
    '		Case DBN_SRLTRA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_SRLTRA = LSet(G_LB)
    '		Case DBN_EXCTBZ
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_EXCTBZ = LSet(G_LB)
    '		Case DBN_GYMTBZ
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_GYMTBZ = LSet(G_LB)
    '		Case DBN_KNGMTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_KNGMTB = LSet(G_LB)
    '		Case DBN_TANWTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_TANWTA = LSet(G_LB)
    '	End Select
    'End Sub
    '2019/06/04 DELL END

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