Option Strict Off
Option Explicit On
Module URIET51_IEV
	Public Const SSS_MAX_DB As Short = 34
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "URIET51"
	Public Const SSS_PrgNm As String = "売上登録                      "
	Public Const SSS_FraId As String = "ET1"
	
	Sub PRNBIL() 'Generated.
		
	End Sub


    Sub Init_Fil() 'Generated.
        '20190731 DEL START
        '
        'DBN_UDNTRA = 0
        'DB_PARA(DBN_UDNTRA).tblid = "UDNTRA"
        'DB_PARA(DBN_UDNTRA).DBID = "USR1"
        'SSS_MFIL = DBN_UDNTRA
        ''
        'DBN_UDNTHA = 1
        'DB_PARA(DBN_UDNTHA).tblid = "UDNTHA"
        'DB_PARA(DBN_UDNTHA).DBID = "USR1"
        ''
        'DBN_JDNTRA = 2
        'DB_PARA(DBN_JDNTRA).tblid = "JDNTRA"
        'DB_PARA(DBN_JDNTRA).DBID = "USR1"
        ''
        'DBN_JDNTHA = 3
        'DB_PARA(DBN_JDNTHA).tblid = "JDNTHA"
        'DB_PARA(DBN_JDNTHA).DBID = "USR1"
        ''
        'DBN_TOKMTA = 4
        'DB_PARA(DBN_TOKMTA).tblid = "TOKMTA"
        'DB_PARA(DBN_TOKMTA).DBID = "USR1"
        ''
        'DBN_TANMTA = 5
        'DB_PARA(DBN_TANMTA).tblid = "TANMTA"
        'DB_PARA(DBN_TANMTA).DBID = "USR1"
        ''
        'DBN_SOUMTA = 6
        'DB_PARA(DBN_SOUMTA).tblid = "SOUMTA"
        'DB_PARA(DBN_SOUMTA).DBID = "USR1"
        ''
        'DBN_NHSMTA = 7
        'DB_PARA(DBN_NHSMTA).tblid = "NHSMTA"
        'DB_PARA(DBN_NHSMTA).DBID = "USR1"
        ''
        'DBN_HINMTA = 8
        'DB_PARA(DBN_HINMTA).tblid = "HINMTA"
        'DB_PARA(DBN_HINMTA).DBID = "USR1"
        ''
        'DBN_SYSTBA = 9
        'DB_PARA(DBN_SYSTBA).tblid = "SYSTBA"
        'DB_PARA(DBN_SYSTBA).DBID = "USR1"
        ''
        'DBN_SYSTBB = 10
        'DB_PARA(DBN_SYSTBB).tblid = "SYSTBB"
        'DB_PARA(DBN_SYSTBB).DBID = "USR1"
        ''
        'DBN_SYSTBC = 11
        'DB_PARA(DBN_SYSTBC).tblid = "SYSTBC"
        'DB_PARA(DBN_SYSTBC).DBID = "USR1"
        ''
        'DBN_SYSTBD = 12
        'DB_PARA(DBN_SYSTBD).tblid = "SYSTBD"
        'DB_PARA(DBN_SYSTBD).DBID = "USR1"
        ''
        'DBN_SYSTBF = 13
        'DB_PARA(DBN_SYSTBF).tblid = "SYSTBF"
        'DB_PARA(DBN_SYSTBF).DBID = "USR1"
        ''
        'DBN_SYSTBG = 14
        'DB_PARA(DBN_SYSTBG).tblid = "SYSTBG"
        'DB_PARA(DBN_SYSTBG).DBID = "USR1"
        ''
        'DBN_SYSTBH = 15
        'DB_PARA(DBN_SYSTBH).tblid = "SYSTBH"
        'DB_PARA(DBN_SYSTBH).DBID = "USR1"
        ''
        'DBN_CLSMTA = 16
        'DB_PARA(DBN_CLSMTA).tblid = "CLSMTA"
        'DB_PARA(DBN_CLSMTA).DBID = "USR1"
        ''
        'DBN_CLSMTB = 17
        'DB_PARA(DBN_CLSMTB).tblid = "CLSMTB"
        'DB_PARA(DBN_CLSMTB).DBID = "USR1"
        ''
        'DBN_TOKMTB = 18
        'DB_PARA(DBN_TOKMTB).tblid = "TOKMTB"
        'DB_PARA(DBN_TOKMTB).DBID = "USR1"
        ''
        'DBN_HINMTB = 19
        'DB_PARA(DBN_HINMTB).tblid = "HINMTB"
        'DB_PARA(DBN_HINMTB).DBID = "USR1"
        ''
        'DBN_SYSTBI = 20
        'DB_PARA(DBN_SYSTBI).tblid = "SYSTBI"
        'DB_PARA(DBN_SYSTBI).DBID = "USR1"
        ''
        'DBN_HINSMA = 21
        'DB_PARA(DBN_HINSMA).tblid = "HINSMA"
        'DB_PARA(DBN_HINSMA).DBID = "USR1"
        ''
        ''DBN_JDNDL01 = 22
        ''DB_PARA(DBN_JDNDL01).TBLID = "JDNDL01"
        ''DB_PARA(DBN_JDNDL01).DBID = "USR1"
        ''
        'DBN_MEIMTA = 23
        'DB_PARA(DBN_MEIMTA).tblid = "MEIMTA"
        'DB_PARA(DBN_MEIMTA).DBID = "USR1"
        ''
        'DBN_FDNTHA = 24
        'DB_PARA(DBN_FDNTHA).tblid = "FDNTHA"
        'DB_PARA(DBN_FDNTHA).DBID = "USR1"
        ''
        'DBN_FDNTRA = 25
        'DB_PARA(DBN_FDNTRA).tblid = "FDNTRA"
        'DB_PARA(DBN_FDNTRA).DBID = "USR1"
        ''
        'DBN_UNYMTA = 26
        'DB_PARA(DBN_UNYMTA).tblid = "UNYMTA"
        'DB_PARA(DBN_UNYMTA).DBID = "USR1"
        ''
        'DBN_USRET51 = 27
        'DB_PARA(DBN_USRET51).tblid = "USRET51"
        'DB_PARA(DBN_USRET51).DBID = "USR9"
        ''
        'DBN_BMNMTA = 28
        'DB_PARA(DBN_BMNMTA).tblid = "BMNMTA"
        'DB_PARA(DBN_BMNMTA).DBID = "USR1"
        ''
        'DBN_EXCTBZ = 29
        'DB_PARA(DBN_EXCTBZ).tblid = "EXCTBZ"
        'DB_PARA(DBN_EXCTBZ).DBID = "USR1"
        ''
        'DBN_GYMTBZ = 30
        'DB_PARA(DBN_GYMTBZ).tblid = "GYMTBZ"
        'DB_PARA(DBN_GYMTBZ).DBID = "USR1"
        ''
        'DBN_KNGMTB = 31
        'DB_PARA(DBN_KNGMTB).tblid = "KNGMTB"
        'DB_PARA(DBN_KNGMTB).DBID = "USR1"
        ''
        'DBN_TANWTA = 32
        'DB_PARA(DBN_TANWTA).tblid = "TANWTA"
        'DB_PARA(DBN_TANWTA).DBID = "USR1"
        ''
        'DBN_FIXMTA = 33
        'DB_PARA(DBN_FIXMTA).tblid = "FIXMTA"
        'DB_PARA(DBN_FIXMTA).DBID = "USR1"
        '20190731 DEL END

        '
        DBN_TANSMA = -1
        '
        DBN_TOKSMC = -2
        '
        DBN_TOKSMA = -3
        '
        DBN_TOKSSA = -4
        '
        DBN_TOKSSB = -5
        '
        DBN_TOKSMB = -6
        '
        DBN_TOKSME = -7
        '
        DBN_ZAISMA = -8
        '
        DBN_SRACNTTB = -9
        '
        DBN_SRARSTTB = -10

        SSS_BILFL = 9
    End Sub

    Sub SCR_FromFDNTHA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_NHSADA(De, DB_FDNTHA.NHSADA)
		Call DP_SSSMAIN_NHSADB(De, DB_FDNTHA.NHSADB)
		Call DP_SSSMAIN_NHSADC(De, DB_FDNTHA.NHSADC)
		Call DP_SSSMAIN_NHSCD(De, DB_FDNTHA.NHSCD)
		Call DP_SSSMAIN_NHSNMA(De, DB_FDNTHA.NHSNMA)
		Call DP_SSSMAIN_NHSNMB(De, DB_FDNTHA.NHSNMB)
		Call DP_SSSMAIN_RELFL(De, DB_FDNTHA.RELFL)
		Call DP_SSSMAIN_TOKCD(De, DB_FDNTHA.TOKCD)
	End Sub
	
	Sub FDNTHA_FromSCR(ByVal De As Short) 'Generated.
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
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RELFL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.RELFL = RD_SSSMAIN_RELFL(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTHA.TOKCD = RD_SSSMAIN_TOKCD(De)
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
		Call DP_SSSMAIN_URISU(De, DB_FDNTRA.FRDSU)
	End Sub
	
	Sub FDNTRA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_FDNTRA.FRDSU = RD_SSSMAIN_URISU(De)
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
	
	Sub SCR_FromJDNTHA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_BKTHKKB(De, DB_JDNTHA.BKTHKKB)
		Call DP_SSSMAIN_BUMCD(De, DB_JDNTHA.BUMCD)
		Call DP_SSSMAIN_BUNNM(De, DB_JDNTHA.BUMNM)
		Call DP_SSSMAIN_DATKB(De, DB_JDNTHA.DATKB)
		Call DP_SSSMAIN_DENCM(De, DB_JDNTHA.DENCM)
		Call DP_SSSMAIN_DENCMIN(De, DB_JDNTHA.DENCMIN)
		Call DP_SSSMAIN_FRNKB(De, DB_JDNTHA.FRNKB)
		Call DP_SSSMAIN_JDNNO(De, DB_JDNTHA.JDNNO)
		Call DP_SSSMAIN_JDNTRKB(De, DB_JDNTHA.JDNTRKB)
		Call DP_SSSMAIN_KENNMA(De, DB_JDNTHA.KENNMA)
		Call DP_SSSMAIN_KENNMB(De, DB_JDNTHA.KENNMB)
		Call DP_SSSMAIN_LSTID(De, DB_JDNTHA.LSTID)
		Call DP_SSSMAIN_MAEUKKB(De, DB_JDNTHA.MAEUKKB)
		Call DP_SSSMAIN_NHSADA(De, DB_JDNTHA.NHSADA)
		Call DP_SSSMAIN_NHSADB(De, DB_JDNTHA.NHSADB)
		Call DP_SSSMAIN_NHSADC(De, DB_JDNTHA.NHSADC)
		Call DP_SSSMAIN_NHSCD(De, DB_JDNTHA.NHSCD)
		Call DP_SSSMAIN_NHSMSTKB(De, DB_JDNTHA.NHSMSTKB)
		Call DP_SSSMAIN_NHSNMA(De, DB_JDNTHA.NHSNMA)
		Call DP_SSSMAIN_NHSNMB(De, DB_JDNTHA.NHSNMB)
		Call DP_SSSMAIN_NHSNMMKB(De, DB_JDNTHA.NHSNMMKB)
		Call DP_SSSMAIN_SBAUZEKN(De, DB_JDNTHA.SBAUZEKN)
		Call DP_SSSMAIN_SBAUZKKN(De, DB_JDNTHA.SBAUZKKN)
		Call DP_SSSMAIN_SEIKB(De, DB_JDNTHA.SEIKB)
		Call DP_SSSMAIN_SOUCD(De, DB_JDNTHA.SOUCD)
		Call DP_SSSMAIN_SOUNM(De, DB_JDNTHA.SOUNM)
		Call DP_SSSMAIN_TANCD(De, DB_JDNTHA.TANCD)
		Call DP_SSSMAIN_TANMSTKB(De, DB_JDNTHA.TANMSTKB)
		Call DP_SSSMAIN_TANNM(De, DB_JDNTHA.TANNM)
		Call DP_SSSMAIN_TKNRPSKB(De, DB_JDNTHA.TKNRPSKB)
		Call DP_SSSMAIN_TKNZRNKB(De, DB_JDNTHA.TKNZRNKB)
		Call DP_SSSMAIN_TOKCD(De, DB_JDNTHA.TOKCD)
		Call DP_SSSMAIN_TOKKDWKB(De, DB_JDNTHA.TOKKDWKB)
		Call DP_SSSMAIN_TOKKESCC(De, DB_JDNTHA.TOKKESCC)
		Call DP_SSSMAIN_TOKKESDD(De, DB_JDNTHA.TOKKESDD)
		Call DP_SSSMAIN_TOKMSTKB(De, DB_JDNTHA.TOKMSTKB)
		Call DP_SSSMAIN_TOKNMMKB(De, DB_JDNTHA.TOKNMMKB)
		Call DP_SSSMAIN_TOKRN(De, DB_JDNTHA.TOKRN)
		Call DP_SSSMAIN_TOKRPSKB(De, DB_JDNTHA.TOKRPSKB)
		Call DP_SSSMAIN_TOKSDWKB(De, DB_JDNTHA.TOKSDWKB)
		Call DP_SSSMAIN_TOKSEICD(De, DB_JDNTHA.TOKSEICD)
		Call DP_SSSMAIN_TOKSMECC(De, DB_JDNTHA.TOKSMECC)
		Call DP_SSSMAIN_TOKSMEDD(De, DB_JDNTHA.TOKSMEDD)
		Call DP_SSSMAIN_TOKSMEKB(De, DB_JDNTHA.TOKSMEKB)
		Call DP_SSSMAIN_TOKZCLKB(De, DB_JDNTHA.TOKZCLKB)
		Call DP_SSSMAIN_TOKZEIKB(De, DB_JDNTHA.TOKZEIKB)
		Call DP_SSSMAIN_TOKZRNKB(De, DB_JDNTHA.TOKZRNKB)
		Call DP_SSSMAIN_TUKKB(De, DB_JDNTHA.TUKKB)
		Call DP_SSSMAIN_URIKJN(De, DB_JDNTHA.URIKJN)
		Call DP_SSSMAIN_ZKTKB(De, DB_JDNTHA.ZKTKB)
		Call DP_SSSMAIN_ZKTNM(De, DB_JDNTHA.ZKTNM)
	End Sub
	
	Sub JDNTHA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BKTHKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.BKTHKKB = RD_SSSMAIN_BKTHKKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BUMCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.BUMCD = RD_SSSMAIN_BUMCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BUNNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.BUMNM = RD_SSSMAIN_BUNNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.DATKB = RD_SSSMAIN_DATKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENCM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.DENCM = RD_SSSMAIN_DENCM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENCMIN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.DENCMIN = RD_SSSMAIN_DENCMIN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FRNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.FRNKB = RD_SSSMAIN_FRNKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.JDNNO = RD_SSSMAIN_JDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNTRKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.JDNTRKB = RD_SSSMAIN_JDNTRKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_KENNMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.KENNMA = RD_SSSMAIN_KENNMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_KENNMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.KENNMB = RD_SSSMAIN_KENNMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LSTID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.LSTID = RD_SSSMAIN_LSTID(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MAEUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.MAEUKKB = RD_SSSMAIN_MAEUKKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.NHSADA = RD_SSSMAIN_NHSADA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.NHSADB = RD_SSSMAIN_NHSADB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.NHSADC = RD_SSSMAIN_NHSADC(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.NHSCD = RD_SSSMAIN_NHSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.NHSMSTKB = RD_SSSMAIN_NHSMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.NHSNMA = RD_SSSMAIN_NHSNMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.NHSNMB = RD_SSSMAIN_NHSNMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNMMKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.NHSNMMKB = RD_SSSMAIN_NHSNMMKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAUZEKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.SBAUZEKN = RD_SSSMAIN_SBAUZEKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAUZKKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.SBAUZKKN = RD_SSSMAIN_SBAUZKKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.SEIKB = RD_SSSMAIN_SEIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.SOUCD = RD_SSSMAIN_SOUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.SOUNM = RD_SSSMAIN_SOUNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TANCD = RD_SSSMAIN_TANCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TANMSTKB = RD_SSSMAIN_TANMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TANNM = RD_SSSMAIN_TANNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TKNRPSKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TKNRPSKB = RD_SSSMAIN_TKNRPSKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TKNZRNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TKNZRNKB = RD_SSSMAIN_TKNZRNKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKCD = RD_SSSMAIN_TOKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKKDWKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKKDWKB = RD_SSSMAIN_TOKKDWKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKKESCC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKKESCC = RD_SSSMAIN_TOKKESCC(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKKESDD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKKESDD = RD_SSSMAIN_TOKKESDD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKMSTKB = RD_SSSMAIN_TOKMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKNMMKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKNMMKB = RD_SSSMAIN_TOKNMMKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKRN = RD_SSSMAIN_TOKRN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKRPSKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKRPSKB = RD_SSSMAIN_TOKRPSKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKSDWKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKSDWKB = RD_SSSMAIN_TOKSDWKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKSEICD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKSEICD = RD_SSSMAIN_TOKSEICD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKSMECC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKSMECC = RD_SSSMAIN_TOKSMECC(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKSMEDD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKSMEDD = RD_SSSMAIN_TOKSMEDD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKSMEKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKSMEKB = RD_SSSMAIN_TOKSMEKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZCLKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKZCLKB = RD_SSSMAIN_TOKZCLKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKZEIKB = RD_SSSMAIN_TOKZEIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKZRNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TOKZRNKB = RD_SSSMAIN_TOKZRNKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TUKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.TUKKB = RD_SSSMAIN_TUKKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URIKJN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.URIKJN = RD_SSSMAIN_URIKJN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZKTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.ZKTKB = RD_SSSMAIN_ZKTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZKTNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTHA.ZKTNM = RD_SSSMAIN_ZKTNM(De)
		DB_JDNTHA.OPEID = SSS_OPEID.Value
		DB_JDNTHA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_JDNTHA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_JDNTHA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_JDNTHA.WRTTM = DB_ORATM
			DB_JDNTHA.WRTDT = DB_ORADT
		End If
	End Sub

    '2019/04/02 CHG START
    'Sub SCR_FromJDNTRA(ByVal De As Short) 'Generated.
    Sub SCR_FromJDNTRA(ByVal De As Short, ByVal pRow As DataRow) 'Generated.
        '2019/04/02 CHG E N D
        '2019/04/02 CHG START
        'Call DP_SSSMAIN_ATZHIKSU(De, DB_JDNTRA.URISU)
        'Call DP_SSSMAIN_DATKB(De, DB_JDNTRA.DATKB)
        'Call DP_SSSMAIN_FNYUKN(De, DB_JDNTRA.FNYUKN)
        'Call DP_SSSMAIN_FURIKN(De, DB_JDNTRA.FURIKN)
        'Call DP_SSSMAIN_HINCD(De, DB_JDNTRA.HINCD)
        'Call DP_SSSMAIN_HINKB(De, DB_JDNTRA.HINKB)
        'Call DP_SSSMAIN_HINMSTKB(De, DB_JDNTRA.HINMSTKB)
        'Call DP_SSSMAIN_HINNMA(De, DB_JDNTRA.HINNMA)
        'Call DP_SSSMAIN_HINNMB(De, DB_JDNTRA.HINNMB)
        'Call DP_SSSMAIN_HINNMMKB(De, DB_JDNTRA.HINNMMKB)
        'Call DP_SSSMAIN_HINZEIKB(De, DB_JDNTRA.HINZEIKB)
        'Call DP_SSSMAIN_HRTDD(De, DB_JDNTRA.HRTDD)
        'Call DP_SSSMAIN_INVNO(De, DB_JDNTRA.INVNO)
        'Call DP_SSSMAIN_JDNLINNO(De, DB_JDNTRA.LINNO)
        'Call DP_SSSMAIN_JDNNO(De, DB_JDNTRA.JDNNO)
        'Call DP_SSSMAIN_LINCMA(De, DB_JDNTRA.LINCMA)
        'Call DP_SSSMAIN_LINCMB(De, DB_JDNTRA.LINCMB)
        'Call DP_SSSMAIN_LSTID(De, DB_JDNTRA.LSTID)
        'Call DP_SSSMAIN_MAKCD(De, DB_JDNTRA.MAKCD)
        'Call DP_SSSMAIN_NHSCD(De, DB_JDNTRA.NHSCD)
        'Call DP_SSSMAIN_NHSMSTKB(De, DB_JDNTRA.NHSMSTKB)
        'Call DP_SSSMAIN_ORTDD(De, DB_JDNTRA.ORTDD)
        'Call DP_SSSMAIN_RATERT(De, DB_JDNTRA.RATERT)
        'Call DP_SSSMAIN_RECNO(De, DB_JDNTRA.RECNO)
        'Call DP_SSSMAIN_SBNNO(De, DB_JDNTRA.SBNNO)
        'Call DP_SSSMAIN_SIKKN(De, DB_JDNTRA.SIKKN)
        'Call DP_SSSMAIN_SIKTK(De, DB_JDNTRA.SIKTK)
        'Call DP_SSSMAIN_SOUCD(De, DB_JDNTRA.SOUCD)
        'Call DP_SSSMAIN_TANCD(De, DB_JDNTRA.TANCD)
        'Call DP_SSSMAIN_TANMSTKB(De, DB_JDNTRA.TANMSTKB)
        'Call DP_SSSMAIN_TEIKATK(De, DB_JDNTRA.TEIKATK)
        'Call DP_SSSMAIN_TNKKB(De, DB_JDNTRA.TNKKB)
        'Call DP_SSSMAIN_TOKCD(De, DB_JDNTRA.TOKCD)
        'Call DP_SSSMAIN_TOKJDNNO(De, DB_JDNTRA.TOKJDNNO)
        'Call DP_SSSMAIN_TOKMSTKB(De, DB_JDNTRA.TOKMSTKB)
        'Call DP_SSSMAIN_TOKSEICD(De, DB_JDNTRA.TOKSEICD)
        'Call DP_SSSMAIN_UNTCD(De, DB_JDNTRA.UNTCD)
        'Call DP_SSSMAIN_UNTNM(De, DB_JDNTRA.UNTNM)
        'Call DP_SSSMAIN_UODSU(De, DB_JDNTRA.UODSU)
        'Call DP_SSSMAIN_URIKN(De, DB_JDNTRA.UODKN)
        'Call DP_SSSMAIN_URISU(De, DB_JDNTRA.UODSU)
        'Call DP_SSSMAIN_URITK(De, DB_JDNTRA.UODTK)
        'Call DP_SSSMAIN_UZEKN(De, DB_JDNTRA.UZEKN)
        'Call DP_SSSMAIN_ZAIKB(De, DB_JDNTRA.ZAIKB)
        'Call DP_SSSMAIN_ZEIRNKKB(De, DB_JDNTRA.ZEIRNKKB)
        'Call DP_SSSMAIN_ZEIRT(De, DB_JDNTRA.ZEIRT)
        Call DP_SSSMAIN_ATZHIKSU(De, pRow("URISU"))
        Call DP_SSSMAIN_DATKB(De, pRow("DATKB"))
        Call DP_SSSMAIN_FNYUKN(De, pRow("FNYUKN"))
        Call DP_SSSMAIN_FURIKN(De, pRow("FURIKN"))
        Call DP_SSSMAIN_HINCD(De, pRow("HINCD"))
        Call DP_SSSMAIN_HINKB(De, pRow("HINKB"))
        Call DP_SSSMAIN_HINMSTKB(De, pRow("HINMSTKB"))
        Call DP_SSSMAIN_HINNMA(De, pRow("HINNMA"))
        Call DP_SSSMAIN_HINNMB(De, pRow("HINNMB"))
        Call DP_SSSMAIN_HINNMMKB(De, pRow("HINNMMKB"))
        Call DP_SSSMAIN_HINZEIKB(De, pRow("HINZEIKB"))
        Call DP_SSSMAIN_HRTDD(De, pRow("HRTDD"))
        Call DP_SSSMAIN_INVNO(De, pRow("INVNO"))
        Call DP_SSSMAIN_JDNLINNO(De, pRow("LINNO"))
        Call DP_SSSMAIN_JDNNO(De, pRow("JDNNO"))
        Call DP_SSSMAIN_LINCMA(De, pRow("LINCMA"))
        Call DP_SSSMAIN_LINCMB(De, pRow("LINCMB"))
        Call DP_SSSMAIN_LSTID(De, pRow("LSTID"))
        Call DP_SSSMAIN_MAKCD(De, pRow("MAKCD"))
        Call DP_SSSMAIN_NHSCD(De, pRow("NHSCD"))
        Call DP_SSSMAIN_NHSMSTKB(De, pRow("NHSMSTKB"))
        Call DP_SSSMAIN_ORTDD(De, pRow("ORTDD"))
        Call DP_SSSMAIN_RATERT(De, pRow("RATERT"))
        Call DP_SSSMAIN_RECNO(De, pRow("RECNO"))
        Call DP_SSSMAIN_SBNNO(De, pRow("SBNNO"))
        Call DP_SSSMAIN_SIKKN(De, pRow("SIKKN"))
        Call DP_SSSMAIN_SIKTK(De, pRow("SIKTK"))
        Call DP_SSSMAIN_SOUCD(De, pRow("SOUCD"))
        Call DP_SSSMAIN_TANCD(De, pRow("TANCD"))
        Call DP_SSSMAIN_TANMSTKB(De, pRow("TANMSTKB"))
        Call DP_SSSMAIN_TEIKATK(De, pRow("TEIKATK"))
        Call DP_SSSMAIN_TNKKB(De, pRow("TNKKB"))
        Call DP_SSSMAIN_TOKCD(De, pRow("TOKCD"))
        Call DP_SSSMAIN_TOKJDNNO(De, pRow("TOKJDNNO"))
        Call DP_SSSMAIN_TOKMSTKB(De, pRow("TOKMSTKB"))
        Call DP_SSSMAIN_TOKSEICD(De, pRow("TOKSEICD"))
        Call DP_SSSMAIN_UNTCD(De, pRow("UNTCD"))
        Call DP_SSSMAIN_UNTNM(De, pRow("UNTNM"))
        Call DP_SSSMAIN_UODSU(De, pRow("UODSU"))
        Call DP_SSSMAIN_URIKN(De, pRow("UODKN"))
        Call DP_SSSMAIN_URISU(De, pRow("UODSU"))
        Call DP_SSSMAIN_URITK(De, pRow("UODTK"))
        Call DP_SSSMAIN_UZEKN(De, pRow("UZEKN"))
        Call DP_SSSMAIN_ZAIKB(De, pRow("ZAIKB"))
        Call DP_SSSMAIN_ZEIRNKKB(De, pRow("ZEIRNKKB"))
        Call DP_SSSMAIN_ZEIRT(De, pRow("ZEIRT"))
        '2019/04/02 CHG E N D
    End Sub
	
	Sub JDNTRA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ATZHIKSU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.URISU = RD_SSSMAIN_ATZHIKSU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.DATKB = RD_SSSMAIN_DATKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FNYUKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.FNYUKN = RD_SSSMAIN_FNYUKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FURIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.FURIKN = RD_SSSMAIN_FURIKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.HINCD = RD_SSSMAIN_HINCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.HINKB = RD_SSSMAIN_HINKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.HINMSTKB = RD_SSSMAIN_HINMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.HINNMA = RD_SSSMAIN_HINNMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.HINNMB = RD_SSSMAIN_HINNMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMMKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.HINNMMKB = RD_SSSMAIN_HINNMMKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINZEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.HINZEIKB = RD_SSSMAIN_HINZEIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HRTDD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.HRTDD = RD_SSSMAIN_HRTDD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INVNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.INVNO = RD_SSSMAIN_INVNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNLINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.LINNO = RD_SSSMAIN_JDNLINNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.JDNNO = RD_SSSMAIN_JDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LINCMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.LINCMA = RD_SSSMAIN_LINCMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LINCMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.LINCMB = RD_SSSMAIN_LINCMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_LSTID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.LSTID = RD_SSSMAIN_LSTID(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_MAKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.MAKCD = RD_SSSMAIN_MAKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.NHSCD = RD_SSSMAIN_NHSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.NHSMSTKB = RD_SSSMAIN_NHSMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ORTDD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.ORTDD = RD_SSSMAIN_ORTDD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RATERT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.RATERT = RD_SSSMAIN_RATERT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RECNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.RECNO = RD_SSSMAIN_RECNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.SBNNO = RD_SSSMAIN_SBNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SIKKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.SIKKN = RD_SSSMAIN_SIKKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SIKTK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.SIKTK = RD_SSSMAIN_SIKTK(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.SOUCD = RD_SSSMAIN_SOUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.TANCD = RD_SSSMAIN_TANCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.TANMSTKB = RD_SSSMAIN_TANMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TEIKATK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.TEIKATK = RD_SSSMAIN_TEIKATK(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TNKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.TNKKB = RD_SSSMAIN_TNKKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.TOKCD = RD_SSSMAIN_TOKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKJDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.TOKJDNNO = RD_SSSMAIN_TOKJDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.TOKMSTKB = RD_SSSMAIN_TOKMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TOKSEICD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.TOKSEICD = RD_SSSMAIN_TOKSEICD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.UNTCD = RD_SSSMAIN_UNTCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.UNTNM = RD_SSSMAIN_UNTNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UODSU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.UODSU = RD_SSSMAIN_UODSU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.UODKN = RD_SSSMAIN_URIKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.UODSU = RD_SSSMAIN_URISU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URITK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.UODTK = RD_SSSMAIN_URITK(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UZEKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.UZEKN = RD_SSSMAIN_UZEKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZAIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.ZAIKB = RD_SSSMAIN_ZAIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZEIRNKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.ZEIRNKKB = RD_SSSMAIN_ZEIRNKKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZEIRT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_JDNTRA.ZEIRT = RD_SSSMAIN_ZEIRT(De)
		DB_JDNTRA.OPEID = SSS_OPEID.Value
		DB_JDNTRA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_JDNTRA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_JDNTRA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_JDNTRA.WRTTM = DB_ORATM
			DB_JDNTRA.WRTDT = DB_ORADT
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
		Call DP_SSSMAIN_NHSRN(De, DB_NHSMTA.NHSRN)
	End Sub
	
	Sub NHSMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSCD = RD_SSSMAIN_NHSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSMSTKB = RD_SSSMAIN_NHSMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSRN = RD_SSSMAIN_NHSRN(De)
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
		Call DP_SSSMAIN_BUMCD(De, DB_UDNTHA.BUMCD)
		Call DP_SSSMAIN_BUNNM(De, DB_UDNTHA.BUMNM)
		Call DP_SSSMAIN_DATKB(De, DB_UDNTHA.DATKB)
		Call DP_SSSMAIN_DENCM(De, DB_UDNTHA.DENCM)
		Call DP_SSSMAIN_DENCMIN(De, DB_UDNTHA.DENCMIN)
		Call DP_SSSMAIN_FRNKB(De, DB_UDNTHA.FRNKB)
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
		Call DP_SSSMAIN_OKRJONO(De, DB_UDNTHA.OKRJONO)
		Call DP_SSSMAIN_SBADENKN(De, DB_UDNTHA.SBAUZKKN)
		Call DP_SSSMAIN_SBAURIKN(De, DB_UDNTHA.SBAURIKN)
		Call DP_SSSMAIN_SBAUZEKN(De, DB_UDNTHA.SBAUZEKN)
		Call DP_SSSMAIN_SEIKB(De, DB_UDNTHA.SEIKB)
		Call DP_SSSMAIN_SOUCD(De, DB_UDNTHA.SOUCD)
		Call DP_SSSMAIN_SOUNM(De, DB_UDNTHA.SOUNM)
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
		Call DP_SSSMAIN_UDNDT(De, DB_UDNTHA.REGDT)
		Call DP_SSSMAIN_UDNDT(De, DB_UDNTHA.UDNDT)
		Call DP_SSSMAIN_UDNNO(De, DB_UDNTHA.UDNNO)
		Call DP_SSSMAIN_URIKJN(De, DB_UDNTHA.URIKJN)
		Call DP_SSSMAIN_ZKTKB(De, DB_UDNTHA.ZKTKB)
		Call DP_SSSMAIN_ZKTNM(De, DB_UDNTHA.ZKTNM)
	End Sub
	
	Sub UDNTHA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BUMCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.BUMCD = RD_SSSMAIN_BUMCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BUNNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.BUMNM = RD_SSSMAIN_BUNNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.DATKB = RD_SSSMAIN_DATKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENCM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.DENCM = RD_SSSMAIN_DENCM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DENCMIN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.DENCMIN = RD_SSSMAIN_DENCMIN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FRNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.FRNKB = RD_SSSMAIN_FRNKB(De)
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
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OKRJONO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.OKRJONO = RD_SSSMAIN_OKRJONO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBADENKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SBAUZKKN = RD_SSSMAIN_SBADENKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAURIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SBAURIKN = RD_SSSMAIN_SBAURIKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAUZEKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SBAUZEKN = RD_SSSMAIN_SBAUZEKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SEIKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SEIKB = RD_SSSMAIN_SEIKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SOUCD = RD_SSSMAIN_SOUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.SOUNM = RD_SSSMAIN_SOUNM(De)
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
		DB_UDNTHA.REGDT = RD_SSSMAIN_UDNDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.UDNDT = RD_SSSMAIN_UDNDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.UDNNO = RD_SSSMAIN_UDNNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URIKJN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTHA.URIKJN = RD_SSSMAIN_URIKJN(De)
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
		Call DP_SSSMAIN_DATKB(De, DB_UDNTRA.DATKB)
		Call DP_SSSMAIN_DFLDKBCD(De, DB_UDNTRA.DFLDKBCD)
		Call DP_SSSMAIN_DKBFLA(De, DB_UDNTRA.DKBFLA)
		Call DP_SSSMAIN_DKBFLB(De, DB_UDNTRA.DKBFLB)
		Call DP_SSSMAIN_DKBFLC(De, DB_UDNTRA.DKBFLC)
		Call DP_SSSMAIN_DKBTEGFL(De, DB_UDNTRA.DKBTEGFL)
		Call DP_SSSMAIN_DKBZAIFL(De, DB_UDNTRA.DKBZAIFL)
		Call DP_SSSMAIN_FNYUKN(De, DB_UDNTRA.FNYUKN)
		Call DP_SSSMAIN_FURIKN(De, DB_UDNTRA.FURIKN)
		Call DP_SSSMAIN_GNKKN(De, DB_UDNTRA.GNKKN)
		Call DP_SSSMAIN_GNKTK(De, DB_UDNTRA.GNKTK)
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
		Call DP_SSSMAIN_JDNLINNO(De, DB_UDNTRA.JDNLINNO)
		Call DP_SSSMAIN_JDNNO(De, DB_UDNTRA.JDNNO)
		Call DP_SSSMAIN_LINCMA(De, DB_UDNTRA.LINCMA)
		Call DP_SSSMAIN_LINCMB(De, DB_UDNTRA.LINCMB)
		Call DP_SSSMAIN_LINNO(De, DB_UDNTRA.LINNO)
		Call DP_SSSMAIN_LSTID(De, DB_UDNTRA.LSTID)
		Call DP_SSSMAIN_MAKCD(De, DB_UDNTRA.MAKCD)
		Call DP_SSSMAIN_MRPKB(De, DB_UDNTRA.MRPKB)
		Call DP_SSSMAIN_NHSCD(De, DB_UDNTRA.NHSCD)
		Call DP_SSSMAIN_NHSMSTKB(De, DB_UDNTRA.NHSMSTKB)
		Call DP_SSSMAIN_ODNLINNO(De, DB_UDNTRA.ODNLINNO)
		Call DP_SSSMAIN_OKRJONO(De, DB_UDNTRA.OKRJONO)
		Call DP_SSSMAIN_ORTDD(De, DB_UDNTRA.ORTDD)
		Call DP_SSSMAIN_RATERT(De, DB_UDNTRA.RATERT)
		Call DP_SSSMAIN_RECNO(De, DB_UDNTRA.RECNO)
		Call DP_SSSMAIN_SBNNO(De, DB_UDNTRA.SBNNO)
		Call DP_SSSMAIN_SIKKN(De, DB_UDNTRA.SIKKN)
		Call DP_SSSMAIN_SIKTK(De, DB_UDNTRA.SIKTK)
		Call DP_SSSMAIN_SOUCD(De, DB_UDNTRA.SOUCD)
		Call DP_SSSMAIN_TANCD(De, DB_UDNTRA.TANCD)
		Call DP_SSSMAIN_TANMSTKB(De, DB_UDNTRA.TANMSTKB)
		Call DP_SSSMAIN_TNKKB(De, DB_UDNTRA.TNKID)
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
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DATKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DATKB = RD_SSSMAIN_DATKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DFLDKBCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DFLDKBCD = RD_SSSMAIN_DFLDKBCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBFLA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBFLA = RD_SSSMAIN_DKBFLA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBFLB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBFLB = RD_SSSMAIN_DKBFLB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBFLC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBFLC = RD_SSSMAIN_DKBFLC(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBTEGFL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBTEGFL = RD_SSSMAIN_DKBTEGFL(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_DKBZAIFL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.DKBZAIFL = RD_SSSMAIN_DKBZAIFL(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FNYUKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.FNYUKN = RD_SSSMAIN_FNYUKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FURIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.FURIKN = RD_SSSMAIN_FURIKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_GNKKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.GNKKN = RD_SSSMAIN_GNKKN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_GNKTK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.GNKTK = RD_SSSMAIN_GNKTK(De)
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
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNLINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.JDNLINNO = RD_SSSMAIN_JDNLINNO(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.JDNNO = RD_SSSMAIN_JDNNO(De)
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
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ODNLINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.ODNLINNO = RD_SSSMAIN_ODNLINNO(De)
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
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.SOUCD = RD_SSSMAIN_SOUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TANCD = RD_SSSMAIN_TANCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TANMSTKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TANMSTKB = RD_SSSMAIN_TANMSTKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_TNKKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UDNTRA.TNKID = RD_SSSMAIN_TNKKB(De)
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
	
	Sub FDNTHA_FromJDNTHA() 'Generated.
		Dim i As Short
		
		DB_FDNTHA.BINCD = DB_JDNTHA.BINCD
		DB_FDNTHA.OUTSOUCD = DB_JDNTHA.SOUCD
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
	
	Sub FDNTHA_FromNHSMTA() 'Generated.
		Dim i As Short
		
		DB_FDNTHA.NHSADA = DB_NHSMTA.NHSADA
		DB_FDNTHA.NHSADB = DB_NHSMTA.NHSADB
		DB_FDNTHA.NHSADC = DB_NHSMTA.NHSADC
		DB_FDNTHA.NHSCD = DB_NHSMTA.NHSCD
		DB_FDNTHA.NHSFX = DB_NHSMTA.NHSFX
		DB_FDNTHA.NHSNMA = DB_NHSMTA.NHSNMA
		DB_FDNTHA.NHSNMB = DB_NHSMTA.NHSNMB
		DB_FDNTHA.NHSTL = DB_NHSMTA.NHSTL
		DB_FDNTHA.NHSZP = DB_NHSMTA.NHSZP
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
	
	Sub FDNTHA_FromTOKMTA() 'Generated.
		Dim i As Short
		
		DB_FDNTHA.TOKADA = DB_TOKMTA.TOKADA
		DB_FDNTHA.TOKADB = DB_TOKMTA.TOKADB
		DB_FDNTHA.TOKADC = DB_TOKMTA.TOKADC
		DB_FDNTHA.TOKCD = DB_TOKMTA.TOKCD
		DB_FDNTHA.TOKFX = DB_TOKMTA.TOKFX
		DB_FDNTHA.TOKNMA = DB_TOKMTA.TOKNMA
		DB_FDNTHA.TOKNMB = DB_TOKMTA.TOKNMB
		DB_FDNTHA.TOKTL = DB_TOKMTA.TOKTL
		DB_FDNTHA.TOKZP = DB_TOKMTA.TOKZP
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
	
	Sub FDNTHA_FromUDNTHA() 'Generated.
		Dim i As Short
		
		DB_FDNTHA.DATKB = DB_UDNTHA.DATKB
		DB_FDNTHA.DATNO = DB_UDNTHA.DATNO
		DB_FDNTHA.DENCM = DB_UDNTHA.DENCM
		DB_FDNTHA.FDNNO = DB_UDNTHA.FDNNO
		DB_FDNTHA.INVNO = DB_UDNTHA.INVNO
		DB_FDNTHA.NHSADA = DB_UDNTHA.NHSADA
		DB_FDNTHA.NHSADB = DB_UDNTHA.NHSADB
		DB_FDNTHA.NHSADC = DB_UDNTHA.NHSADC
		DB_FDNTHA.NHSCD = DB_UDNTHA.NHSCD
		DB_FDNTHA.NHSNMA = DB_UDNTHA.NHSNMA
		DB_FDNTHA.NHSNMB = DB_UDNTHA.NHSNMB
		DB_FDNTHA.OUTSOUCD = DB_UDNTHA.SOUCD
		DB_FDNTHA.TANNM = DB_UDNTHA.TANNM
		DB_FDNTHA.TOKCD = DB_UDNTHA.TOKCD
		DB_FDNTHA.WRTFSTDT = DB_UDNTHA.WRTFSTDT
		DB_FDNTHA.WRTFSTTM = DB_UDNTHA.WRTFSTTM
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
	
	Sub FDNTRA_FromHINMTA() 'Generated.
		Dim i As Short
		
		DB_FDNTRA.HINCD = DB_HINMTA.HINCD
		DB_FDNTRA.JANCD = DB_HINMTA.JANCD
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
	
	Sub FDNTRA_FromJDNTHA() 'Generated.
		Dim i As Short
		
		DB_FDNTRA.BINCD = DB_JDNTHA.BINCD
		DB_FDNTRA.DEFNOKDT = DB_JDNTHA.DEFNOKDT
		DB_FDNTRA.DENCM = DB_JDNTHA.DENCM
		DB_FDNTRA.JDNNO = DB_JDNTHA.JDNNO
		DB_FDNTRA.OUTSOUCD = DB_JDNTHA.SOUCD
		DB_FDNTRA.TANNM = DB_JDNTHA.TANNM
		DB_FDNTRA.TOKCD = DB_JDNTHA.TOKCD
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
	
	Sub FDNTRA_FromJDNTRA() 'Generated.
		Dim i As Short
		
		DB_FDNTRA.INVNO = DB_JDNTRA.INVNO
		DB_FDNTRA.ODNYTDT = DB_JDNTRA.ODNYTDT
		DB_FDNTRA.SBNNO = DB_JDNTRA.SBNNO
		DB_FDNTRA.TOKJDNED = DB_JDNTRA.TOKJDNED
		DB_FDNTRA.TOKJDNNO = DB_JDNTRA.TOKJDNNO
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
	
	Sub FDNTRA_FromNHSMTA() 'Generated.
		Dim i As Short
		
		DB_FDNTRA.NHSADA = DB_NHSMTA.NHSADA
		DB_FDNTRA.NHSADB = DB_NHSMTA.NHSADB
		DB_FDNTRA.NHSADC = DB_NHSMTA.NHSADC
		DB_FDNTRA.NHSCD = DB_NHSMTA.NHSCD
		DB_FDNTRA.NHSFX = DB_NHSMTA.NHSFX
		DB_FDNTRA.NHSNMA = DB_NHSMTA.NHSNMA
		DB_FDNTRA.NHSNMB = DB_NHSMTA.NHSNMB
		DB_FDNTRA.NHSTL = DB_NHSMTA.NHSTL
		DB_FDNTRA.NHSZP = DB_NHSMTA.NHSZP
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
	
	Sub FDNTRA_FromSOUMTA() 'Generated.
		Dim i As Short
		
		DB_FDNTRA.OUTBSCD = DB_SOUMTA.SOUBSCD
		DB_FDNTRA.OUTSOUCD = DB_SOUMTA.SOUCD
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
	
	Sub FDNTRA_FromTOKMTA() 'Generated.
		Dim i As Short
		
		DB_FDNTRA.TOKADA = DB_TOKMTA.TOKADA
		DB_FDNTRA.TOKADB = DB_TOKMTA.TOKADB
		DB_FDNTRA.TOKADC = DB_TOKMTA.TOKADC
		DB_FDNTRA.TOKCD = DB_TOKMTA.TOKCD
		DB_FDNTRA.TOKFX = DB_TOKMTA.TOKFX
		DB_FDNTRA.TOKNMA = DB_TOKMTA.TOKNMA
		DB_FDNTRA.TOKNMB = DB_TOKMTA.TOKNMB
		DB_FDNTRA.TOKTL = DB_TOKMTA.TOKTL
		DB_FDNTRA.TOKZP = DB_TOKMTA.TOKZP
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
	
	Sub FDNTRA_FromUDNTRA() 'Generated.
		Dim i As Short
		
		DB_FDNTRA.FRDKN = DB_UDNTRA.URIKN
		DB_FDNTRA.FRDSU = DB_UDNTRA.URISU
		DB_FDNTRA.FRDTK = DB_UDNTRA.URITK
		DB_FDNTRA.HINCD = DB_UDNTRA.HINCD
		DB_FDNTRA.HINNMA = DB_UDNTRA.HINNMA
		DB_FDNTRA.HINNMB = DB_UDNTRA.HINNMB
		DB_FDNTRA.JDNLINNO = DB_UDNTRA.JDNLINNO
		DB_FDNTRA.LINCMA = DB_UDNTRA.LINCMA
		DB_FDNTRA.LINCMB = DB_UDNTRA.LINCMB
		DB_FDNTRA.NHSCD = DB_UDNTRA.NHSCD
		DB_FDNTRA.UNTNM = DB_UDNTRA.UNTNM
		DB_FDNTRA.UZEKN = DB_UDNTRA.UZEKN
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

    '20190709 DEL START
    'Sub JDNDL01_FromJDNTHA() 'Generated.
    '    Dim i As Short

    '    DB_JDNDL01.JDNDT = DB_JDNTHA.JDNDT
    '    DB_JDNDL01.JDNNO = DB_JDNTHA.JDNNO
    '    DB_JDNDL01.TOKCD = DB_JDNTHA.TOKCD
    '    DB_JDNDL01.TOKRN = DB_JDNTHA.TOKRN
    '    If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
    '    Else
    '    End If
    'End Sub
    '20190709 DEL END

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

    '2019/03/26 DEL START
    'Sub SetBuf(ByVal Fno As Short) 'Generated.
    '	Select Case Fno
    '		Case DBN_UDNTRA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_UDNTRA)
    '		Case DBN_UDNTHA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_UDNTHA)
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
    '		Case DBN_FDNTHA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_FDNTHA)
    '		Case DBN_FDNTRA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_FDNTRA)
    '		Case DBN_UNYMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_UNYMTA)
    '		Case DBN_USRET51
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_USRET51)
    '		Case DBN_BMNMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_BMNMTA)
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
    '		Case DBN_FIXMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_FIXMTA)
    '	End Select
    '   End Sub
    '2019/03/26 DEL E N D

    '2019/03/26 DEL START
    'Sub ResetBuf(ByVal Fno As Short) 'Generated.
    '	Select Case Fno
    '		Case DBN_UDNTRA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_UDNTRA = LSet(G_LB)
    '		Case DBN_UDNTHA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_UDNTHA = LSet(G_LB)
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
    '		Case DBN_FDNTHA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_FDNTHA = LSet(G_LB)
    '		Case DBN_FDNTRA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_FDNTRA = LSet(G_LB)
    '		Case DBN_UNYMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_UNYMTA = LSet(G_LB)
    '		Case DBN_USRET51
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_USRET51 = LSet(G_LB)
    '		Case DBN_BMNMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_BMNMTA = LSet(G_LB)
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
    '		Case DBN_FIXMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_FIXMTA = LSet(G_LB)
    '	End Select
    '   End Sub
    '2019/03/26 DEL E N D
	
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