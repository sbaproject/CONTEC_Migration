Option Strict Off
Option Explicit On
Module IDOPR53_IEV
	Public Const SSS_MAX_DB As Short = 18
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "IDOPR53"
	Public Const SSS_PrgNm As String = "製番出庫日記帳                "
	Public Const SSS_FraId As String = "PR2"
	Public WG_OPEID As String
	Public WG_OPENM As String
	Public WG_INPTANCD As String
	Public WG_INPTANNM As String
	Public WG_STTWRTDT As String
	Public WG_ENDWRTDT As String
	Public WG_STTWRTTM As String
	Public WG_ENDWRTTM As String
	Public WG_STTOUTDT As String
	Public WG_ENDOUTDT As String
	
	Sub Init_Fil() 'Generated.
        '
        'DBN_IDOPR53 = 0
        'DB_PARA(DBN_IDOPR53).TBLID = "IDOPR53"
        'DB_PARA(DBN_IDOPR53).DBID = "USR9"
        'SSS_MFIL = DBN_IDOPR53
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
        'DBN_UNYMTA = 12
        'DB_PARA(DBN_UNYMTA).TBLID = "UNYMTA"
        'DB_PARA(DBN_UNYMTA).DBID = "USR1"
        ''
        'DBN_EXCTBZ = 13
        'DB_PARA(DBN_EXCTBZ).TBLID = "EXCTBZ"
        'DB_PARA(DBN_EXCTBZ).DBID = "USR1"
        ''
        'DBN_GYMTBZ = 14
        'DB_PARA(DBN_GYMTBZ).TBLID = "GYMTBZ"
        'DB_PARA(DBN_GYMTBZ).DBID = "USR1"
        '
        'DBN_KNGMTB = 15
        'DB_PARA(DBN_KNGMTB).TBLID = "KNGMTB"
        'DB_PARA(DBN_KNGMTB).DBID = "USR1"
        ''
        'DBN_SBNTRA = 16
        'DB_PARA(DBN_SBNTRA).TBLID = "SBNTRA"
        'DB_PARA(DBN_SBNTRA).DBID = "USR1"
        ''
        'DBN_BMNMTA = 17
        'DB_PARA(DBN_BMNMTA).TBLID = "BMNMTA"
        'DB_PARA(DBN_BMNMTA).DBID = "USR1"

        SSS_LSTMFIL = DBN_IDOPR53
	End Sub
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_ENDOUTDT(De, DB_IDOPR53.ENDOUTDT)
		Call DP_SSSMAIN_ENDWRTDT(De, DB_IDOPR53.ENDWRTDT)
		Call DP_SSSMAIN_ENDWRTTM(De, DB_IDOPR53.ENDWRTTM)
		Call DP_SSSMAIN_INPTANCD(De, DB_IDOPR53.INPTANCD)
		Call DP_SSSMAIN_INPTANNM(De, DB_IDOPR53.INPTANNM)
		Call DP_SSSMAIN_STTOUTDT(De, DB_IDOPR53.STTOUTDT)
		Call DP_SSSMAIN_STTWRTDT(De, DB_IDOPR53.STTWRTDT)
		Call DP_SSSMAIN_STTWRTTM(De, DB_IDOPR53.STTWRTTM)
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDOUTDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_IDOPR53.ENDOUTDT = RD_SSSMAIN_ENDOUTDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDWRTDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_IDOPR53.ENDWRTDT = RD_SSSMAIN_ENDWRTDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDWRTTM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_IDOPR53.ENDWRTTM = RD_SSSMAIN_ENDWRTTM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPTANCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_IDOPR53.INPTANCD = RD_SSSMAIN_INPTANCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPTANNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_IDOPR53.INPTANNM = RD_SSSMAIN_INPTANNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTOUTDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_IDOPR53.STTOUTDT = RD_SSSMAIN_STTOUTDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTWRTDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_IDOPR53.STTWRTDT = RD_SSSMAIN_STTWRTDT(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTWRTTM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_IDOPR53.STTWRTTM = RD_SSSMAIN_STTWRTTM(De)
		DB_IDOPR53.OPEID = SSS_OPEID.Value
		DB_IDOPR53.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_IDOPR53.WRTTM = VB6.Format(Now, "hhmmss")
			DB_IDOPR53.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_IDOPR53.WRTTM = DB_ORATM
			DB_IDOPR53.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub SCR_FromTANMTA(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_INPTANNM(De, DB_TANMTA.TANNM)
	End Sub
	
	Sub TANMTA_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_INPTANNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_TANMTA.TANNM = RD_SSSMAIN_INPTANNM(De)
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
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTOUTDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_STTOUTDT = RD_SSSMAIN_STTOUTDT(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDOUTDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_ENDOUTDT = RD_SSSMAIN_ENDOUTDT(0)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(WG_ENDOUTDT)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(WG_ENDOUTDT)) = 0 Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_ENDOUTDT = HighValue(LenWid(WG_ENDOUTDT))
		End If
	End Sub

    '2019/10/11 DEL START
    'Sub SetBuf(ByVal Fno As Short) 'Generated.
    '    Select Case Fno
    '        Case DBN_IDOPR53
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_IDOPR53)
    '        Case DBN_SYSTBA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_SYSTBA)
    '        Case DBN_SYSTBB
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_SYSTBB)
    '        Case DBN_SYSTBC
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_SYSTBC)
    '        Case DBN_SYSTBD
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_SYSTBD)
    '        Case DBN_SYSTBF
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_SYSTBF)
    '        Case DBN_SYSTBG
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_SYSTBG)
    '        Case DBN_SYSTBH
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_SYSTBH)
    '        Case DBN_CLSMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_CLSMTA)
    '        Case DBN_CLSMTB
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_CLSMTB)
    '        Case DBN_MEIMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_MEIMTA)
    '        Case DBN_TANMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_TANMTA)
    '        Case DBN_UNYMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_UNYMTA)
    '        Case DBN_EXCTBZ
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_EXCTBZ)
    '        Case DBN_GYMTBZ
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_GYMTBZ)
    '        Case DBN_KNGMTB
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_KNGMTB)
    '        Case DBN_SBNTRA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_SBNTRA)
    '        Case DBN_BMNMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_BMNMTA)
    '    End Select
    'End Sub
    '2019/10/11 DEL E N D

    '2019/10/11 DEL START
    'Sub ResetBuf(ByVal Fno As Short) 'Generated.
    '    Select Case Fno
    '        Case DBN_IDOPR53
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_IDOPR53 = LSet(G_LB)
    '        Case DBN_SYSTBA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_SYSTBA = LSet(G_LB)
    '        Case DBN_SYSTBB
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_SYSTBB = LSet(G_LB)
    '        Case DBN_SYSTBC
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_SYSTBC = LSet(G_LB)
    '        Case DBN_SYSTBD
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_SYSTBD = LSet(G_LB)
    '        Case DBN_SYSTBF
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_SYSTBF = LSet(G_LB)
    '        Case DBN_SYSTBG
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_SYSTBG = LSet(G_LB)
    '        Case DBN_SYSTBH
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_SYSTBH = LSet(G_LB)
    '        Case DBN_CLSMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_CLSMTA = LSet(G_LB)
    '        Case DBN_CLSMTB
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_CLSMTB = LSet(G_LB)
    '        Case DBN_MEIMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_MEIMTA = LSet(G_LB)
    '        Case DBN_TANMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_TANMTA = LSet(G_LB)
    '        Case DBN_UNYMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_UNYMTA = LSet(G_LB)
    '        Case DBN_EXCTBZ
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_EXCTBZ = LSet(G_LB)
    '        Case DBN_GYMTBZ
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_GYMTBZ = LSet(G_LB)
    '        Case DBN_KNGMTB
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_KNGMTB = LSet(G_LB)
    '        Case DBN_SBNTRA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_SBNTRA = LSet(G_LB)
    '        Case DBN_BMNMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_BMNMTA = LSet(G_LB)
    '    End Select
    'End Sub
    '2019/10/11 DEL E N D

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