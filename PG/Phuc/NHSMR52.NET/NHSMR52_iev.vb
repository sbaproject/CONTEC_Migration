Option Strict Off
Option Explicit On
Module NHSMR52_IEV
	Public Const SSS_MAX_DB As Short = 18
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "NHSMR52"
	Public Const SSS_PrgNm As String = "納入先マスタ登録／訂正        "
	Public Const SSS_FraId As String = "MR1"
	
	Sub Init_Fil() 'Generated.
        '
        '2019/09/26 DEL START
        'DBN_NHSMTA = 0
        'DB_PARA(DBN_NHSMTA).TBLID = "NHSMTA"
        'DB_PARA(DBN_NHSMTA).DBID = "USR1"
        'SSS_MFIL = DBN_NHSMTA
        ''
        'DBN_SYSTBA = 1
        'DB_PARA(DBN_SYSTBA).TBLID = "SYSTBA"
        'DB_PARA(DBN_SYSTBA).DBID = "USR1"
        ''
        'DBN_SYSTBB = 2
        'DB_PARA(DBN_SYSTBB).TBLID = "SYSTBB"
        'DB_PARA(DBN_SYSTBB).DBID = "USR1"
        ''
        'DBN_SYSTBC = 3
        'DB_PARA(DBN_SYSTBC).TBLID = "SYSTBC"
        'DB_PARA(DBN_SYSTBC).DBID = "USR1"
        ''
        'DBN_SYSTBD = 4
        'DB_PARA(DBN_SYSTBD).TBLID = "SYSTBD"
        'DB_PARA(DBN_SYSTBD).DBID = "USR1"
        ''
        'DBN_SYSTBF = 5
        'DB_PARA(DBN_SYSTBF).TBLID = "SYSTBF"
        'DB_PARA(DBN_SYSTBF).DBID = "USR1"
        ''
        'DBN_SYSTBG = 6
        'DB_PARA(DBN_SYSTBG).TBLID = "SYSTBG"
        'DB_PARA(DBN_SYSTBG).DBID = "USR1"
        ''
        'DBN_SYSTBH = 7
        'DB_PARA(DBN_SYSTBH).TBLID = "SYSTBH"
        'DB_PARA(DBN_SYSTBH).DBID = "USR1"
        ''
        'DBN_CLSMTA = 8
        'DB_PARA(DBN_CLSMTA).TBLID = "CLSMTA"
        'DB_PARA(DBN_CLSMTA).DBID = "USR1"
        ''
        'DBN_CLSMTB = 9
        'DB_PARA(DBN_CLSMTB).TBLID = "CLSMTB"
        'DB_PARA(DBN_CLSMTB).DBID = "USR1"
        ''
        'DBN_MEIMTA = 10
        'DB_PARA(DBN_MEIMTA).TBLID = "MEIMTA"
        'DB_PARA(DBN_MEIMTA).DBID = "USR1"
        ''
        'DBN_TANMTA = 11
        'DB_PARA(DBN_TANMTA).TBLID = "TANMTA"
        'DB_PARA(DBN_TANMTA).DBID = "USR1"
        ''
        'DBN_FIXMTA = 12
        'DB_PARA(DBN_FIXMTA).TBLID = "FIXMTA"
        'DB_PARA(DBN_FIXMTA).DBID = "USR1"
        ''
        'DBN_UNYMTA = 13
        'DB_PARA(DBN_UNYMTA).TBLID = "UNYMTA"
        'DB_PARA(DBN_UNYMTA).DBID = "USR1"
        ''
        'DBN_EXCTBZ = 14
        'DB_PARA(DBN_EXCTBZ).TBLID = "EXCTBZ"
        'DB_PARA(DBN_EXCTBZ).DBID = "USR1"
        ''
        'DBN_GYMTBZ = 15
        'DB_PARA(DBN_GYMTBZ).TBLID = "GYMTBZ"
        'DB_PARA(DBN_GYMTBZ).DBID = "USR1"
        ''
        'DBN_KNGMTB = 16
        'DB_PARA(DBN_KNGMTB).TBLID = "KNGMTB"
        'DB_PARA(DBN_KNGMTB).DBID = "USR1"
        ''
        'DBN_SYSTBM = 17
        'DB_PARA(DBN_SYSTBM).TBLID = "SYSTBM"
        '      DB_PARA(DBN_SYSTBM).DBID = "USR1"
        '2019/09/26 DEL END

        SSS_BILFL = 9
	End Sub
	
	Sub SCR_FromMEIMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_BINCD(De, DB_MEIMTA.MEICDA)
		Call DP_SSSMAIN_BINRN(De, DB_MEIMTA.MEINMA)
		Call DP_SSSMAIN_CHIIKI(De, DB_MEIMTA.MEICDA)
		Call DP_SSSMAIN_CHIIKIRN(De, DB_MEIMTA.MEINMA)
		Call DP_SSSMAIN_GYOSHU(De, DB_MEIMTA.MEICDA)
		Call DP_SSSMAIN_GYOSHURN(De, DB_MEIMTA.MEINMA)
	End Sub
	
	Sub MEIMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_MEIMTA.MEICDA = RD_SSSMAIN_BINCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BINRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_MEIMTA.MEINMA = RD_SSSMAIN_BINRN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CHIIKI() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_MEIMTA.MEICDA = RD_SSSMAIN_CHIIKI(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CHIIKIRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_MEIMTA.MEINMA = RD_SSSMAIN_CHIIKIRN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_GYOSHU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_MEIMTA.MEICDA = RD_SSSMAIN_GYOSHU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_GYOSHURN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_MEIMTA.MEINMA = RD_SSSMAIN_GYOSHURN(De)
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
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_BINCD(De, DB_NHSMTA.BINCD)
		Call DP_SSSMAIN_CHIIKI(De, DB_NHSMTA.CHIIKI)
		Call DP_SSSMAIN_FRNKB(De, DB_NHSMTA.FRNKB)
		Call DP_SSSMAIN_GYOSHU(De, DB_NHSMTA.GYOSHU)
		Call DP_SSSMAIN_NGRPCD(De, DB_NHSMTA.NGRPCD)
		Call DP_SSSMAIN_NHSADA(De, DB_NHSMTA.NHSADA)
		Call DP_SSSMAIN_NHSADB(De, DB_NHSMTA.NHSADB)
		Call DP_SSSMAIN_NHSADC(De, DB_NHSMTA.NHSADC)
		Call DP_SSSMAIN_NHSBOSNM(De, DB_NHSMTA.NHSBOSNM)
		Call DP_SSSMAIN_NHSCD(De, DB_NHSMTA.NHSCD)
		Call DP_SSSMAIN_NHSCLAID(De, DB_NHSMTA.NHSCLAID)
		Call DP_SSSMAIN_NHSCLANM(De, DB_NHSMTA.NHSCLANM)
		Call DP_SSSMAIN_NHSCLBID(De, DB_NHSMTA.NHSCLBID)
		Call DP_SSSMAIN_NHSCLBNM(De, DB_NHSMTA.NHSCLBNM)
		Call DP_SSSMAIN_NHSCLCID(De, DB_NHSMTA.NHSCLCID)
		Call DP_SSSMAIN_NHSCLCNM(De, DB_NHSMTA.NHSCLCNM)
		Call DP_SSSMAIN_NHSCTANM(De, DB_NHSMTA.NHSCTANM)
		Call DP_SSSMAIN_NHSFX(De, DB_NHSMTA.NHSFX)
		Call DP_SSSMAIN_NHSMLAD(De, DB_NHSMTA.NHSMLAD)
		Call DP_SSSMAIN_NHSNK(De, DB_NHSMTA.NHSNK)
		Call DP_SSSMAIN_NHSNMA(De, DB_NHSMTA.NHSNMA)
		Call DP_SSSMAIN_NHSNMB(De, DB_NHSMTA.NHSNMB)
		Call DP_SSSMAIN_NHSNMMKB(De, DB_NHSMTA.NHSNMMKB)
		Call DP_SSSMAIN_NHSRN(De, DB_NHSMTA.NHSRN)
		Call DP_SSSMAIN_NHSRNNK(De, DB_NHSMTA.NHSRNNK)
		Call DP_SSSMAIN_NHSTL(De, DB_NHSMTA.NHSTL)
		Call DP_SSSMAIN_NHSZP(De, DB_NHSMTA.NHSZP)
		Call DP_SSSMAIN_OLDNHSCD(De, DB_NHSMTA.OLDNHSCD)
		Call DP_SSSMAIN_OLNGRPCD(De, DB_NHSMTA.OLNGRPCD)
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_BINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.BINCD = RD_SSSMAIN_BINCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_CHIIKI() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.CHIIKI = RD_SSSMAIN_CHIIKI(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_FRNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.FRNKB = RD_SSSMAIN_FRNKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_GYOSHU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.GYOSHU = RD_SSSMAIN_GYOSHU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NGRPCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NGRPCD = RD_SSSMAIN_NGRPCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSADA = RD_SSSMAIN_NHSADA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSADB = RD_SSSMAIN_NHSADB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSADC() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSADC = RD_SSSMAIN_NHSADC(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSBOSNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSBOSNM = RD_SSSMAIN_NHSBOSNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSCD = RD_SSSMAIN_NHSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCLAID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSCLAID = RD_SSSMAIN_NHSCLAID(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCLANM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSCLANM = RD_SSSMAIN_NHSCLANM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCLBID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSCLBID = RD_SSSMAIN_NHSCLBID(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCLBNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSCLBNM = RD_SSSMAIN_NHSCLBNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCLCID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSCLCID = RD_SSSMAIN_NHSCLCID(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCLCNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSCLCNM = RD_SSSMAIN_NHSCLCNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSCTANM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSCTANM = RD_SSSMAIN_NHSCTANM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSFX() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSFX = RD_SSSMAIN_NHSFX(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSMLAD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSMLAD = RD_SSSMAIN_NHSMLAD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSNK = RD_SSSMAIN_NHSNK(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSNMA = RD_SSSMAIN_NHSNMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSNMB = RD_SSSMAIN_NHSNMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSNMMKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSNMMKB = RD_SSSMAIN_NHSNMMKB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSRN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSRN = RD_SSSMAIN_NHSRN(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSRNNK() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSRNNK = RD_SSSMAIN_NHSRNNK(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSTL() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSTL = RD_SSSMAIN_NHSTL(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_NHSZP() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.NHSZP = RD_SSSMAIN_NHSZP(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OLDNHSCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.OLDNHSCD = RD_SSSMAIN_OLDNHSCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OLNGRPCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_NHSMTA.OLNGRPCD = RD_SSSMAIN_OLNGRPCD(De)
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
	
	Sub NHSMTA_FromSYSTBF() 'Generated.
		Dim i As Short
		
		DB_NHSMTA.NHSCLAKB = DB_SYSTBF.CLAKB
		DB_NHSMTA.NHSCLBKB = DB_SYSTBF.CLBKB
		DB_NHSMTA.NHSCLCKB = DB_SYSTBF.CLCKB
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
	
	Sub UpdSmf() 'Generated.
	End Sub

    '2019/09/26 DEL START
    '   Sub SetBuf(ByVal Fno As Short) 'Generated.
    '	Select Case Fno
    '		Case DBN_NHSMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_NHSMTA)
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
    '		Case DBN_MEIMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_MEIMTA)
    '		Case DBN_TANMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_TANMTA)
    '		Case DBN_FIXMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_FIXMTA)
    '		Case DBN_UNYMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_UNYMTA)
    '		Case DBN_EXCTBZ
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_EXCTBZ)
    '		Case DBN_GYMTBZ
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_GYMTBZ)
    '		Case DBN_KNGMTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_KNGMTB)
    '		Case DBN_SYSTBM
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_SYSTBM)
    '	End Select
    'End Sub

    '   Sub ResetBuf(ByVal Fno As Short) 'Generated.
    '       Select Case Fno
    '           Case DBN_NHSMTA
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_NHSMTA = LSet(G_LB)
    '           Case DBN_SYSTBA
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_SYSTBA = LSet(G_LB)
    '           Case DBN_SYSTBB
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_SYSTBB = LSet(G_LB)
    '           Case DBN_SYSTBC
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_SYSTBC = LSet(G_LB)
    '           Case DBN_SYSTBD
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_SYSTBD = LSet(G_LB)
    '           Case DBN_SYSTBF
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_SYSTBF = LSet(G_LB)
    '           Case DBN_SYSTBG
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_SYSTBG = LSet(G_LB)
    '           Case DBN_SYSTBH
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_SYSTBH = LSet(G_LB)
    '           Case DBN_CLSMTA
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_CLSMTA = LSet(G_LB)
    '           Case DBN_CLSMTB
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_CLSMTB = LSet(G_LB)
    '           Case DBN_MEIMTA
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_MEIMTA = LSet(G_LB)
    '           Case DBN_TANMTA
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_TANMTA = LSet(G_LB)
    '           Case DBN_FIXMTA
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_FIXMTA = LSet(G_LB)
    '           Case DBN_UNYMTA
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_UNYMTA = LSet(G_LB)
    '           Case DBN_EXCTBZ
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_EXCTBZ = LSet(G_LB)
    '           Case DBN_GYMTBZ
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_GYMTBZ = LSet(G_LB)
    '           Case DBN_KNGMTB
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_KNGMTB = LSet(G_LB)
    '           Case DBN_SYSTBM
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_SYSTBM = LSet(G_LB)
    '       End Select
    '   End Sub
    '2019/09/26 DEL END

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