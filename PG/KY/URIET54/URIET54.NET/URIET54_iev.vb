Option Strict Off
Option Explicit On
Module URIET54_IEV
	'20090115 CHG START RISE)Tanimura '連絡票No.523
	'Global Const SSS_MAX_DB% = 32
	Public Const SSS_MAX_DB As Short = 33
	'20090115 CHG END   RISE)Tanimura
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "URIET54"
	Public Const SSS_PrgNm As String = "返品登録                      "
	Public Const SSS_FraId As String = "ET1"
	
	Sub PRNBIL() 'Generated.
		
	End Sub
	
	
	Sub Init_Fil() 'Generated.
		'
		DBN_UDNTRA = 0
		DB_PARA(DBN_UDNTRA).tblid = "UDNTRA"
		DB_PARA(DBN_UDNTRA).DBID = "USR1"
		SSS_MFIL = DBN_UDNTRA
		'
		DBN_UDNTHA = 1
		DB_PARA(DBN_UDNTHA).tblid = "UDNTHA"
		DB_PARA(DBN_UDNTHA).DBID = "USR1"
		'
		DBN_JDNTRA = 2
		DB_PARA(DBN_JDNTRA).tblid = "JDNTRA"
		DB_PARA(DBN_JDNTRA).DBID = "USR1"
		'
		DBN_JDNTHA = 3
		DB_PARA(DBN_JDNTHA).tblid = "JDNTHA"
		DB_PARA(DBN_JDNTHA).DBID = "USR1"
		'
		DBN_TOKMTA = 4
		DB_PARA(DBN_TOKMTA).tblid = "TOKMTA"
		DB_PARA(DBN_TOKMTA).DBID = "USR1"
		'
		DBN_BMNMTA = 5
		DB_PARA(DBN_BMNMTA).tblid = "BMNMTA"
		DB_PARA(DBN_BMNMTA).DBID = "USR1"
		'
		DBN_MEIMTA = 6
		DB_PARA(DBN_MEIMTA).tblid = "MEIMTA"
		DB_PARA(DBN_MEIMTA).DBID = "USR1"
		'
		DBN_TANMTA = 7
		DB_PARA(DBN_TANMTA).tblid = "TANMTA"
		DB_PARA(DBN_TANMTA).DBID = "USR1"
		'
		DBN_SOUMTA = 8
		DB_PARA(DBN_SOUMTA).tblid = "SOUMTA"
		DB_PARA(DBN_SOUMTA).DBID = "USR1"
		'
		DBN_NHSMTA = 9
		DB_PARA(DBN_NHSMTA).tblid = "NHSMTA"
		DB_PARA(DBN_NHSMTA).DBID = "USR1"
		'
		DBN_HINMTA = 10
		DB_PARA(DBN_HINMTA).tblid = "HINMTA"
		DB_PARA(DBN_HINMTA).DBID = "USR1"
		'
		DBN_SYSTBA = 11
		DB_PARA(DBN_SYSTBA).tblid = "SYSTBA"
		DB_PARA(DBN_SYSTBA).DBID = "USR1"
		'
		DBN_SYSTBB = 12
		DB_PARA(DBN_SYSTBB).tblid = "SYSTBB"
		DB_PARA(DBN_SYSTBB).DBID = "USR1"
		'
		DBN_SYSTBC = 13
		DB_PARA(DBN_SYSTBC).tblid = "SYSTBC"
		DB_PARA(DBN_SYSTBC).DBID = "USR1"
		'
		DBN_SYSTBD = 14
		DB_PARA(DBN_SYSTBD).tblid = "SYSTBD"
		DB_PARA(DBN_SYSTBD).DBID = "USR1"
		'
		DBN_SYSTBF = 15
		DB_PARA(DBN_SYSTBF).tblid = "SYSTBF"
		DB_PARA(DBN_SYSTBF).DBID = "USR1"
		'
		DBN_SYSTBG = 16
		DB_PARA(DBN_SYSTBG).tblid = "SYSTBG"
		DB_PARA(DBN_SYSTBG).DBID = "USR1"
		'
		DBN_SYSTBH = 17
		DB_PARA(DBN_SYSTBH).tblid = "SYSTBH"
		DB_PARA(DBN_SYSTBH).DBID = "USR1"
		'
		DBN_UNYMTA = 18
		DB_PARA(DBN_UNYMTA).tblid = "UNYMTA"
		DB_PARA(DBN_UNYMTA).DBID = "USR1"
		'
		DBN_CLSMTA = 19
		DB_PARA(DBN_CLSMTA).tblid = "CLSMTA"
		DB_PARA(DBN_CLSMTA).DBID = "USR1"
		'
		DBN_CLSMTB = 20
		DB_PARA(DBN_CLSMTB).tblid = "CLSMTB"
		DB_PARA(DBN_CLSMTB).DBID = "USR1"
		'
		DBN_SYSTBI = 21
		DB_PARA(DBN_SYSTBI).tblid = "SYSTBI"
		DB_PARA(DBN_SYSTBI).DBID = "USR1"
		'
		DBN_TOKSME = 22
		DB_PARA(DBN_TOKSME).tblid = "TOKSME"
		DB_PARA(DBN_TOKSME).DBID = "USR1"
		'
		DBN_TOKSMD = 23
		DB_PARA(DBN_TOKSMD).tblid = "TOKSMD"
		DB_PARA(DBN_TOKSMD).DBID = "USR1"
		'
		DBN_HINSMA = 24
		DB_PARA(DBN_HINSMA).tblid = "HINSMA"
		DB_PARA(DBN_HINSMA).DBID = "USR1"
		'
		DBN_SRACNTTB = 25
		DB_PARA(DBN_SRACNTTB).tblid = "SRACNTTB"
		DB_PARA(DBN_SRACNTTB).DBID = "USR1"
		'
		DBN_SRAET52 = 26
		DB_PARA(DBN_SRAET52).tblid = "SRAET52"
		DB_PARA(DBN_SRAET52).DBID = "USR9"
		'
		DBN_ODNTRA = 27
		DB_PARA(DBN_ODNTRA).tblid = "ODNTRA"
		DB_PARA(DBN_ODNTRA).DBID = "USR1"
		'
		DBN_EXCTBZ = 28
		DB_PARA(DBN_EXCTBZ).tblid = "EXCTBZ"
		DB_PARA(DBN_EXCTBZ).DBID = "USR1"
		'
		DBN_GYMTBZ = 29
		DB_PARA(DBN_GYMTBZ).tblid = "GYMTBZ"
		DB_PARA(DBN_GYMTBZ).DBID = "USR1"
		'
		DBN_FIXMTA = 30
		DB_PARA(DBN_FIXMTA).tblid = "FIXMTA"
		DB_PARA(DBN_FIXMTA).DBID = "USR1"
		'
		DBN_KNGMTB = 31
		DB_PARA(DBN_KNGMTB).tblid = "KNGMTB"
		DB_PARA(DBN_KNGMTB).DBID = "USR1"
		'20090115 ADD START RISE)Tanimura '連絡票No.523
		'
		DBN_ODNTHA = 32
		DB_PARA(DBN_ODNTHA).tblid = "ODNTHA"
		DB_PARA(DBN_ODNTHA).DBID = "USR1"
		'20090115 ADD END   RISE)Tanimura
		'
		DBN_FDNTRA = -1
		'
		DBN_FDNTHA = -2
		'
		DBN_TOKSMA = -3
		'
		DBN_TOKSSA = -4
		'
		DBN_TOKSSC = -5
		'
		DBN_SRJTRA = -6
		'
		DBN_SRARSTTB = -7
		'
		DBN_TOKSSB = -8
		'
		DBN_SKFTHA = -9
		'
		DBN_SKFTRA = -10
		
		SSS_BILFL = 9
	End Sub
	
	Sub SCR_FromSOUMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_OUTSOUCD(De, DB_SOUMTA.SOUCD)
		Call DP_SSSMAIN_OUTSOUNM(De, DB_SOUMTA.SOUNM)
	End Sub
	
	Sub SOUMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OUTSOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SOUMTA.SOUCD = RD_SSSMAIN_OUTSOUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OUTSOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SOUMTA.SOUNM = RD_SSSMAIN_OUTSOUNM(De)
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
		Call DP_SSSMAIN_UDNDKBID(De, DB_SYSTBD.DKBID)
		Call DP_SSSMAIN_UDNDKBNM(De, DB_SYSTBD.DKBNM)
		Call DP_SSSMAIN_UPDID(De, DB_SYSTBD.UPDID)
	End Sub
	
	Sub SYSTBD_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDKBID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SYSTBD.DKBID = RD_SSSMAIN_UDNDKBID(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDKBNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_SYSTBD.DKBNM = RD_SSSMAIN_UDNDKBNM(De)
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
	End Sub
	
	Sub SCR_FromUDNTHA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_DATNO(De, DB_UDNTHA.DATNO)
		Call DP_SSSMAIN_DENDT(De, DB_UDNTHA.DENDT)
		Call DP_SSSMAIN_FRNKB(De, DB_UDNTHA.FRNKB)
		Call DP_SSSMAIN_NHSCD(De, DB_UDNTHA.NHSCD)
		Call DP_SSSMAIN_NHSRN(De, DB_UDNTHA.NHSRN)
		Call DP_SSSMAIN_OUTSOUCD(De, DB_UDNTHA.SOUCD)
		Call DP_SSSMAIN_OUTSOUNM(De, DB_UDNTHA.SOUNM)
		Call DP_SSSMAIN_SBAFRUKN(De, DB_UDNTHA.SBAFRUKN)
		Call DP_SSSMAIN_SBAURIKN(De, DB_UDNTHA.SBAURIKN)
		Call DP_SSSMAIN_SBAUZEKN(De, DB_UDNTHA.SBAUZEKN)
		Call DP_SSSMAIN_SBAUZKKN(De, DB_UDNTHA.SBAUZKKN)
		Call DP_SSSMAIN_TKNRPSKB(De, DB_UDNTHA.TKNRPSKB)
		Call DP_SSSMAIN_TKNZRNKB(De, DB_UDNTHA.TKNZRNKB)
		Call DP_SSSMAIN_TOKCD(De, DB_UDNTHA.TOKCD)
		Call DP_SSSMAIN_TOKRN(De, DB_UDNTHA.TOKRN)
		Call DP_SSSMAIN_TOKRPSKB(De, DB_UDNTHA.TOKRPSKB)
		Call DP_SSSMAIN_TOKSEICD(De, DB_UDNTHA.TOKSEICD)
		Call DP_SSSMAIN_TOKZCLKB(De, DB_UDNTHA.TOKZCLKB)
		Call DP_SSSMAIN_TOKZEIKB(De, DB_UDNTHA.TOKZEIKB)
		Call DP_SSSMAIN_TOKZRNKB(De, DB_UDNTHA.TOKZRNKB)
		Call DP_SSSMAIN_TUKKB(De, DB_UDNTHA.TUKKB)
		Call DP_SSSMAIN_UDNCM(De, DB_UDNTHA.DENCM)
		Call DP_SSSMAIN_UDNDT(De, DB_UDNTHA.REGDT)
		Call DP_SSSMAIN_UDNDT(De, DB_UDNTHA.UDNDT)
		Call DP_SSSMAIN_UDNNO(De, DB_UDNTHA.UDNNO)
	End Sub
	
	Sub UDNTHA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.DATNO = RD_SSSMAIN_DATNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.DENDT = RD_SSSMAIN_DENDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FRNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.FRNKB = RD_SSSMAIN_FRNKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.NHSCD = RD_SSSMAIN_NHSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.NHSRN = RD_SSSMAIN_NHSRN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OUTSOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SOUCD = RD_SSSMAIN_OUTSOUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OUTSOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SOUNM = RD_SSSMAIN_OUTSOUNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAFRUKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SBAFRUKN = RD_SSSMAIN_SBAFRUKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAURIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SBAURIKN = RD_SSSMAIN_SBAURIKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAUZEKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SBAUZEKN = RD_SSSMAIN_SBAUZEKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAUZKKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SBAUZKKN = RD_SSSMAIN_SBAUZKKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TKNRPSKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TKNRPSKB = RD_SSSMAIN_TKNRPSKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TKNZRNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TKNZRNKB = RD_SSSMAIN_TKNZRNKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKCD = RD_SSSMAIN_TOKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKRN = RD_SSSMAIN_TOKRN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKRPSKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKRPSKB = RD_SSSMAIN_TOKRPSKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKSEICD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKSEICD = RD_SSSMAIN_TOKSEICD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZCLKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKZCLKB = RD_SSSMAIN_TOKZCLKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKZEIKB = RD_SSSMAIN_TOKZEIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZRNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TOKZRNKB = RD_SSSMAIN_TOKZRNKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.TUKKB = RD_SSSMAIN_TUKKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNCM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.DENCM = RD_SSSMAIN_UDNCM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.REGDT = RD_SSSMAIN_UDNDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.UDNDT = RD_SSSMAIN_UDNDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.UDNNO = RD_SSSMAIN_UDNNO(De)
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
		Call DP_SSSMAIN_FURIKN(De, DB_UDNTRA.FURIKN)
		Call DP_SSSMAIN_FURITK(De, DB_UDNTRA.FURITK)
		Call DP_SSSMAIN_GNKKN(De, DB_UDNTRA.GNKKN)
		Call DP_SSSMAIN_GNKTK(De, DB_UDNTRA.GNKTK)
		Call DP_SSSMAIN_HINCD(De, DB_UDNTRA.HINCD)
		Call DP_SSSMAIN_HINNMA(De, DB_UDNTRA.HINNMA)
		Call DP_SSSMAIN_HINNMB(De, DB_UDNTRA.HINNMB)
		Call DP_SSSMAIN_HINZEIKB(De, DB_UDNTRA.HINZEIKB)
		Call DP_SSSMAIN_JDNLINNO(De, DB_UDNTRA.JDNLINNO)
		Call DP_SSSMAIN_JDNNO(De, DB_UDNTRA.JDNNO)
		Call DP_SSSMAIN_LINNO(De, DB_UDNTRA.LINNO)
		Call DP_SSSMAIN_NHSCD(De, DB_UDNTRA.NHSCD)
		Call DP_SSSMAIN_RECNO(De, DB_UDNTRA.RECNO)
		Call DP_SSSMAIN_SBNNO(De, DB_UDNTRA.SBNNO)
		Call DP_SSSMAIN_SIKKN(De, DB_UDNTRA.SIKKN)
		Call DP_SSSMAIN_SIKTK(De, DB_UDNTRA.SIKTK)
		Call DP_SSSMAIN_TOKCD(De, DB_UDNTRA.TOKCD)
		Call DP_SSSMAIN_TOKSEICD(De, DB_UDNTRA.TOKSEICD)
		Call DP_SSSMAIN_UDNDKBID(De, DB_UDNTRA.DKBID)
		Call DP_SSSMAIN_UDNDKBNM(De, DB_UDNTRA.DKBNM)
		Call DP_SSSMAIN_UDNDT(De, DB_UDNTRA.UDNDT)
		Call DP_SSSMAIN_UNTNM(De, DB_UDNTRA.UNTNM)
		Call DP_SSSMAIN_UPDID(De, DB_UDNTRA.UPDID)
		Call DP_SSSMAIN_URIKN(De, DB_UDNTRA.URIKN)
		Call DP_SSSMAIN_URISU(De, DB_UDNTRA.URISU)
		Call DP_SSSMAIN_URITK(De, DB_UDNTRA.URITK)
		Call DP_SSSMAIN_UZEKN(De, DB_UDNTRA.UZEKN)
		Call DP_SSSMAIN_ZEIRNKKB(De, DB_UDNTRA.ZEIRNKKB)
		Call DP_SSSMAIN_ZKMURIKN(De, DB_UDNTRA.ZKMURIKN)
		Call DP_SSSMAIN_ZKMUZEKN(De, DB_UDNTRA.ZKMUZEKN)
		Call DP_SSSMAIN_ZNKURIKN(De, DB_UDNTRA.ZNKURIKN)
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FURIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.FURIKN = RD_SSSMAIN_FURIKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FURITK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.FURITK = RD_SSSMAIN_FURITK(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_GNKKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.GNKKN = RD_SSSMAIN_GNKKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_GNKTK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.GNKTK = RD_SSSMAIN_GNKTK(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HINCD = RD_SSSMAIN_HINCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HINNMA = RD_SSSMAIN_HINNMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HINNMB = RD_SSSMAIN_HINNMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINZEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.HINZEIKB = RD_SSSMAIN_HINZEIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNLINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.JDNLINNO = RD_SSSMAIN_JDNLINNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.JDNNO = RD_SSSMAIN_JDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.LINNO = RD_SSSMAIN_LINNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.NHSCD = RD_SSSMAIN_NHSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RECNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.RECNO = RD_SSSMAIN_RECNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.SBNNO = RD_SSSMAIN_SBNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SIKKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.SIKKN = RD_SSSMAIN_SIKKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SIKTK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.SIKTK = RD_SSSMAIN_SIKTK(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TOKCD = RD_SSSMAIN_TOKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKSEICD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TOKSEICD = RD_SSSMAIN_TOKSEICD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDKBID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBID = RD_SSSMAIN_UDNDKBID(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDKBNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBNM = RD_SSSMAIN_UDNDKBNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.UDNDT = RD_SSSMAIN_UDNDT(De)
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
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UZEKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.UZEKN = RD_SSSMAIN_UZEKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZEIRNKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.ZEIRNKKB = RD_SSSMAIN_ZEIRNKKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZKMURIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.ZKMURIKN = RD_SSSMAIN_ZKMURIKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZKMUZEKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.ZKMUZEKN = RD_SSSMAIN_ZKMUZEKN(De)
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
	
	'20090115 ADD START RISE)Tanimura '連絡票No.523
	Sub SCR_FromODNTHA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_DATNO(De, DB_ODNTHA.DATNO)
		Call DP_SSSMAIN_NHSCD(De, DB_ODNTHA.NHSCD)
		Call DP_SSSMAIN_NHSRN(De, DB_ODNTHA.NHSNMA)
		Call DP_SSSMAIN_OUTSOUCD(De, DB_ODNTHA.OUTSOUCD)
		Call DP_SSSMAIN_TOKCD(De, DB_ODNTHA.TOKCD)
		Call DP_SSSMAIN_UDNCM(De, DB_ODNTHA.DENCM)
		Call DP_SSSMAIN_UDNDT(De, DB_ODNTHA.ODNDT)
		Call DP_SSSMAIN_UDNNO(De, DB_ODNTHA.ODNNO)
	End Sub
	
	Sub SCR_FromJDNTHA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_FRNKB(De, DB_JDNTHA.FRNKB)
		Call DP_SSSMAIN_TKNRPSKB(De, DB_JDNTHA.TKNRPSKB)
		Call DP_SSSMAIN_TKNZRNKB(De, DB_JDNTHA.TKNZRNKB)
		Call DP_SSSMAIN_TOKRN(De, DB_JDNTHA.TOKRN)
		Call DP_SSSMAIN_TOKRPSKB(De, DB_JDNTHA.TOKRPSKB)
		Call DP_SSSMAIN_TOKSEICD(De, DB_JDNTHA.TOKSEICD)
		Call DP_SSSMAIN_TOKZCLKB(De, DB_JDNTHA.TOKZCLKB)
		Call DP_SSSMAIN_TOKZEIKB(De, DB_JDNTHA.TOKZEIKB)
		Call DP_SSSMAIN_TOKZRNKB(De, DB_JDNTHA.TOKZRNKB)
		Call DP_SSSMAIN_TUKKB(De, DB_JDNTHA.TUKKB)
	End Sub
	
	Sub SCR_FromODNTRA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_HINCD(De, DB_ODNTRA.HINCD)
		Call DP_SSSMAIN_HINNMA(De, DB_ODNTRA.HINNMA)
		Call DP_SSSMAIN_HINNMB(De, DB_ODNTRA.HINNMB)
		Call DP_SSSMAIN_JDNLINNO(De, DB_ODNTRA.JDNLINNO)
		Call DP_SSSMAIN_JDNNO(De, DB_ODNTRA.JDNNO)
		Call DP_SSSMAIN_LINNO(De, DB_ODNTRA.LINNO)
		Call DP_SSSMAIN_NHSCD(De, DB_ODNTRA.NHSCD)
		Call DP_SSSMAIN_RECNO(De, DB_ODNTRA.RECNO)
		Call DP_SSSMAIN_SBNNO(De, DB_ODNTRA.SBNNO)
		Call DP_SSSMAIN_TOKCD(De, DB_ODNTRA.TOKCD)
		Call DP_SSSMAIN_UDNDT(De, DB_ODNTRA.ODNDT)
		Call DP_SSSMAIN_UNTNM(De, DB_ODNTRA.UNTNM)
		Call DP_SSSMAIN_UZEKN(De, DB_ODNTRA.UZEKN)
	End Sub
	
	Sub SCR_FromJDNTRA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_FURIKN(De, DB_JDNTRA.FURIKN)
		Call DP_SSSMAIN_HINZEIKB(De, DB_JDNTRA.HINZEIKB)
		Call DP_SSSMAIN_SIKKN(De, DB_JDNTRA.SIKKN)
		Call DP_SSSMAIN_SIKTK(De, DB_JDNTRA.SIKTK)
		Call DP_SSSMAIN_TOKSEICD(De, DB_JDNTRA.TOKSEICD)
		Call DP_SSSMAIN_URISU(De, DB_JDNTRA.OTPSU - DB_JDNTRA.URISU)
		Call DP_SSSMAIN_URITK(De, DB_JDNTRA.UODTK)
		Call DP_SSSMAIN_URIKN(De, DB_JDNTRA.URIKN)
		Call DP_SSSMAIN_ZEIRNKKB(De, DB_JDNTRA.ZEIRNKKB)
	End Sub
	'20090115 ADD END   RISE)Tanimura
	
	Sub TOKSMD_FromUDNTRA() 'Generated.
		Dim I As Short
		
		DB_TOKSMD.SMADT = DB_UDNTRA.SMADT
		DB_TOKSMD.SMDURIKN(SSS_ACNT) = DB_TOKSMD.SMDURIKN(SSS_ACNT) + DB_UDNTRA.FURIKN * SSS_SMFKB
		DB_TOKSMD.TOKCD = DB_UDNTRA.TOKCD
		DB_TOKSMD.TUKKB = DB_UDNTRA.TUKKB
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_TOKSMD.WRTTM = VB6.Format(Now, "hhmmss")
			DB_TOKSMD.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_TOKSMD.WRTTM = DB_ORATM
			DB_TOKSMD.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub TOKSME_FromUDNTRA() 'Generated.
		Dim I As Short
		
		DB_TOKSME.SMADT = DB_UDNTRA.SMADT
		DB_TOKSME.SMAGNKKN(SSS_ACNT) = DB_TOKSME.SMAGNKKN(SSS_ACNT) + DB_UDNTRA.GNKTK * SSS_SMFKB
		DB_TOKSME.SMAURIKN(SSS_ACNT) = DB_TOKSME.SMAURIKN(SSS_ACNT) + DB_UDNTRA.URIKN * SSS_SMFKB
		DB_TOKSME.SMAUZEKN = DB_TOKSME.SMAUZEKN + DB_UDNTRA.UZEKN * SSS_SMFKB
		DB_TOKSME.TOKCD = DB_UDNTRA.TOKSEICD
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_TOKSME.WRTTM = VB6.Format(Now, "hhmmss")
			DB_TOKSME.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_TOKSME.WRTTM = DB_ORATM
			DB_TOKSME.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub UDNTRA_FromUDNTHA() 'Generated.
		Dim I As Short
		
		DB_UDNTRA.KESDT = DB_UDNTHA.KESDT
		DB_UDNTRA.NHSCD = DB_UDNTHA.NHSCD
		DB_UDNTRA.SMADT = DB_UDNTHA.SMADT
		DB_UDNTRA.SOUCD = DB_UDNTHA.SOUCD
		DB_UDNTRA.SSADT = DB_UDNTHA.SSADT
		DB_UDNTRA.TANCD = DB_UDNTHA.TANCD
		DB_UDNTRA.TOKCD = DB_UDNTHA.TOKCD
		DB_UDNTRA.TOKSEICD = DB_UDNTHA.TOKSEICD
		DB_UDNTRA.UDNDT = DB_UDNTHA.UDNDT
		DB_UDNTRA.UDNNO = DB_UDNTHA.UDNNO
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
	
	Sub SetBuf(ByVal Fno As Short) 'Generated.
		Select Case Fno
			Case DBN_UDNTRA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_UDNTRA)
			Case DBN_UDNTHA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_UDNTHA)
			Case DBN_JDNTRA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_JDNTRA)
			Case DBN_JDNTHA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_JDNTHA)
			Case DBN_TOKMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_TOKMTA)
			Case DBN_BMNMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_BMNMTA)
			Case DBN_MEIMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_MEIMTA)
			Case DBN_TANMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_TANMTA)
			Case DBN_SOUMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SOUMTA)
			Case DBN_NHSMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_NHSMTA)
			Case DBN_HINMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_HINMTA)
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
			Case DBN_UNYMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_UNYMTA)
			Case DBN_CLSMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_CLSMTA)
			Case DBN_CLSMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_CLSMTB)
			Case DBN_SYSTBI
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SYSTBI)
			Case DBN_TOKSME
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_TOKSME)
			Case DBN_TOKSMD
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_TOKSMD)
			Case DBN_HINSMA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_HINSMA)
			Case DBN_SRACNTTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SRACNTTB)
			Case DBN_SRAET52
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SRAET52)
			Case DBN_ODNTRA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_ODNTRA)
			Case DBN_EXCTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_EXCTBZ)
			Case DBN_GYMTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_GYMTBZ)
			Case DBN_FIXMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_FIXMTA)
			Case DBN_KNGMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_KNGMTB)
				'20090115 ADD START RISE)Tanimura '連絡票No.523
			Case DBN_ODNTHA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_ODNTHA)
				'20090115 ADD END   RISE)Tanimura
		End Select
	End Sub
	
	Sub ResetBuf(ByVal Fno As Short) 'Generated.
		Select Case Fno
			Case DBN_UDNTRA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_UDNTRA = LSet(G_LB)
			Case DBN_UDNTHA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_UDNTHA = LSet(G_LB)
			Case DBN_JDNTRA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_JDNTRA = LSet(G_LB)
			Case DBN_JDNTHA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_JDNTHA = LSet(G_LB)
			Case DBN_TOKMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_TOKMTA = LSet(G_LB)
			Case DBN_BMNMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_BMNMTA = LSet(G_LB)
			Case DBN_MEIMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_MEIMTA = LSet(G_LB)
			Case DBN_TANMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_TANMTA = LSet(G_LB)
			Case DBN_SOUMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SOUMTA = LSet(G_LB)
			Case DBN_NHSMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_NHSMTA = LSet(G_LB)
			Case DBN_HINMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_HINMTA = LSet(G_LB)
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
			Case DBN_UNYMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_UNYMTA = LSet(G_LB)
			Case DBN_CLSMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_CLSMTA = LSet(G_LB)
			Case DBN_CLSMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_CLSMTB = LSet(G_LB)
			Case DBN_SYSTBI
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SYSTBI = LSet(G_LB)
			Case DBN_TOKSME
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_TOKSME = LSet(G_LB)
			Case DBN_TOKSMD
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_TOKSMD = LSet(G_LB)
			Case DBN_HINSMA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_HINSMA = LSet(G_LB)
			Case DBN_SRACNTTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SRACNTTB = LSet(G_LB)
			Case DBN_SRAET52
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SRAET52 = LSet(G_LB)
			Case DBN_ODNTRA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_ODNTRA = LSet(G_LB)
			Case DBN_EXCTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_EXCTBZ = LSet(G_LB)
			Case DBN_GYMTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_GYMTBZ = LSet(G_LB)
			Case DBN_FIXMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_FIXMTA = LSet(G_LB)
			Case DBN_KNGMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_KNGMTB = LSet(G_LB)
				'20090115 ADD START RISE)Tanimura '連絡票No.523
			Case DBN_ODNTHA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_ODNTHA = LSet(G_LB)
				'20090115 ADD END   RISE)Tanimura
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