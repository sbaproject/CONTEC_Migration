Option Strict Off
Option Explicit On
Module TNADL51_IEV
	Public Const SSS_MAX_DB As Short = 17
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "TNADL51"
	Public Const SSS_PrgNm As String = "在庫照会（製品別）            "
	Public Const SSS_FraId As String = "DL4"
	
	Sub Init_Fil() 'Generated.
		'
		DBN_TNADL51 = 0
		DB_PARA(DBN_TNADL51).TBLID = "TNADL51"
		DB_PARA(DBN_TNADL51).DBID = "USR1"
		SSS_MFIL = DBN_TNADL51
		'
		DBN_HINMTA = 1
		DB_PARA(DBN_HINMTA).TBLID = "HINMTA"
		DB_PARA(DBN_HINMTA).DBID = "USR1"
		'
		DBN_SYSTBA = 2
		DB_PARA(DBN_SYSTBA).TBLID = "SYSTBA"
		DB_PARA(DBN_SYSTBA).DBID = "USR1"
		'
		DBN_SYSTBB = 3
		DB_PARA(DBN_SYSTBB).TBLID = "SYSTBB"
		DB_PARA(DBN_SYSTBB).DBID = "USR1"
		'
		DBN_SYSTBC = 4
		DB_PARA(DBN_SYSTBC).TBLID = "SYSTBC"
		DB_PARA(DBN_SYSTBC).DBID = "USR1"
		'
		DBN_SYSTBD = 5
		DB_PARA(DBN_SYSTBD).TBLID = "SYSTBD"
		DB_PARA(DBN_SYSTBD).DBID = "USR1"
		'
		DBN_SYSTBF = 6
		DB_PARA(DBN_SYSTBF).TBLID = "SYSTBF"
		DB_PARA(DBN_SYSTBF).DBID = "USR1"
		'
		DBN_SYSTBG = 7
		DB_PARA(DBN_SYSTBG).TBLID = "SYSTBG"
		DB_PARA(DBN_SYSTBG).DBID = "USR1"
		'
		DBN_SYSTBH = 8
		DB_PARA(DBN_SYSTBH).TBLID = "SYSTBH"
		DB_PARA(DBN_SYSTBH).DBID = "USR1"
		'
		DBN_CLSMTA = 9
		DB_PARA(DBN_CLSMTA).TBLID = "CLSMTA"
		DB_PARA(DBN_CLSMTA).DBID = "USR1"
		'
		DBN_CLSMTB = 10
		DB_PARA(DBN_CLSMTB).TBLID = "CLSMTB"
		DB_PARA(DBN_CLSMTB).DBID = "USR1"
		'
		DBN_TANMTA = 11
		DB_PARA(DBN_TANMTA).TBLID = "TANMTA"
		DB_PARA(DBN_TANMTA).DBID = "USR1"
		'
		DBN_UNYMTA = 12
		DB_PARA(DBN_UNYMTA).TBLID = "UNYMTA"
		DB_PARA(DBN_UNYMTA).DBID = "USR1"
		'
		DBN_EXCTBZ = 13
		DB_PARA(DBN_EXCTBZ).TBLID = "EXCTBZ"
		DB_PARA(DBN_EXCTBZ).DBID = "USR1"
		'
		DBN_GYMTBZ = 14
		DB_PARA(DBN_GYMTBZ).TBLID = "GYMTBZ"
		DB_PARA(DBN_GYMTBZ).DBID = "USR1"
		'
		DBN_KNGMTB = 15
		DB_PARA(DBN_KNGMTB).TBLID = "KNGMTB"
		DB_PARA(DBN_KNGMTB).DBID = "USR1"
		'
		DBN_MEIMTA = 16
		DB_PARA(DBN_MEIMTA).TBLID = "MEIMTA"
		DB_PARA(DBN_MEIMTA).DBID = "USR1"
		'
		DBN_SOUMTA = -1
		'
		DBN_HINMTB = -2
		'
		DBN_ZAISMA = -3
		
		SSS_BILFL = 9
	End Sub
	
	Sub SCR_FromHINMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_HINCD(De, DB_HINMTA.HINCD)
		Call DP_SSSMAIN_HINNMA(De, DB_HINMTA.HINNMA)
		Call DP_SSSMAIN_HINNMB(De, DB_HINMTA.HINNMB)
		Call DP_SSSMAIN_UNTNM(De, DB_HINMTA.UNTNM)
	End Sub
	
	Sub HINMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.HINCD = RD_SSSMAIN_HINCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMA() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.HINNMA = RD_SSSMAIN_HINNMA(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINNMB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.HINNMB = RD_SSSMAIN_HINNMB(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINMTA.UNTNM = RD_SSSMAIN_UNTNM(De)
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
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_RELZAISU(De, DB_TNADL51.RELZAISU)
		Call DP_SSSMAIN_SMAINPSU(De, DB_TNADL51.SMAINPSU)
		Call DP_SSSMAIN_SMAOUTSU(De, DB_TNADL51.SMAOUTSU)
		Call DP_SSSMAIN_SMAZAISU(De, DB_TNADL51.SMAZAISU)
		Call DP_SSSMAIN_SMZZAISU(De, DB_TNADL51.SMZZAISU)
		Call DP_SSSMAIN_SOUCD(De, DB_TNADL51.SOUCD)
		Call DP_SSSMAIN_SOUNM(De, DB_TNADL51.SOUNM)
		Call DP_SSSMAIN_ZAISAISU(De, DB_TNADL51.ZAISAISU)
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_RELZAISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TNADL51.RELZAISU = RD_SSSMAIN_RELZAISU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMAINPSU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TNADL51.SMAINPSU = RD_SSSMAIN_SMAINPSU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMAOUTSU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TNADL51.SMAOUTSU = RD_SSSMAIN_SMAOUTSU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMAZAISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TNADL51.SMAZAISU = RD_SSSMAIN_SMAZAISU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SMZZAISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TNADL51.SMZZAISU = RD_SSSMAIN_SMZZAISU(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TNADL51.SOUCD = RD_SSSMAIN_SOUCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TNADL51.SOUNM = RD_SSSMAIN_SOUNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ZAISAISU() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TNADL51.ZAISAISU = RD_SSSMAIN_ZAISAISU(De)
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
		Else
		End If
	End Sub
	
	Sub UpdSmf() 'Generated.
	End Sub
    '20190705 DELL START
    '   Sub SetBuf(ByVal Fno As Short) 'Generated.
    '	Select Case Fno
    '		Case DBN_TNADL51
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_TNADL51)
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
    '		Case DBN_TANMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_TANMTA)
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
    '		Case DBN_MEIMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_MEIMTA)
    '	End Select
    'End Sub
    '20190705 DELL END
    '20190705 DELL START
    '   Sub ResetBuf(ByVal Fno As Short) 'Generated.
    '	Select Case Fno
    '		Case DBN_TNADL51
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_TNADL51 = LSet(G_LB)
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
    '		Case DBN_TANMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_TANMTA = LSet(G_LB)
    '		Case DBN_UNYMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_UNYMTA = LSet(G_LB)
    '		Case DBN_EXCTBZ
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_EXCTBZ = LSet(G_LB)
    '		Case DBN_GYMTBZ
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_GYMTBZ = LSet(G_LB)
    '		Case DBN_KNGMTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_KNGMTB = LSet(G_LB)
    '		Case DBN_MEIMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			DB_MEIMTA = LSet(G_LB)
    '	End Select
    'End Sub
    '20190705 DELL END

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