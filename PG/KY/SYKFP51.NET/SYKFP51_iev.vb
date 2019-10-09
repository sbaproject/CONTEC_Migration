Option Strict Off
Option Explicit On
Module SYKFP51_IEV
	Public Const SSS_MAX_DB As Short = 22
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "SYKFP51"
	Public Const SSS_PrgNm As String = "一括出荷指示処理              "
	Public Const SSS_FraId As String = "FP1"
	Public WG_ODNYTDT As String
	Public WG_SOUCD As String
	Public WG_SOUNM As String
	Public WG_OPEID As String
	Public WG_OPENM As String
	Public WG_WRTFSTDT As String
	Public WG_WRTFSTTM As String
	
	Sub Init_Fil() 'Generated.
        '
        'DBN_SYKTRA = 0
        'DB_PARA(DBN_SYKTRA).TBLID = "SYKTRA"
        'DB_PARA(DBN_SYKTRA).DBID = "USR1"
        'SSS_MFIL = DBN_SYKTRA
        ''
        'DBN_FDNTHA = 1
        'DB_PARA(DBN_FDNTHA).TBLID = "FDNTHA"
        'DB_PARA(DBN_FDNTHA).DBID = "USR1"
        ''
        'DBN_TOKMTA = 2
        'DB_PARA(DBN_TOKMTA).TBLID = "TOKMTA"
        'DB_PARA(DBN_TOKMTA).DBID = "USR1"
        ''
        'DBN_SOUMTA = 3
        'DB_PARA(DBN_SOUMTA).TBLID = "SOUMTA"
        'DB_PARA(DBN_SOUMTA).DBID = "USR1"
        ''
        'DBN_HINMTA = 4
        'DB_PARA(DBN_HINMTA).TBLID = "HINMTA"
        'DB_PARA(DBN_HINMTA).DBID = "USR1"
        ''
        'DBN_MEIMTA = 5
        'DB_PARA(DBN_MEIMTA).TBLID = "MEIMTA"
        'DB_PARA(DBN_MEIMTA).DBID = "USR1"
        ''
        'DBN_TANMTA = 6
        'DB_PARA(DBN_TANMTA).TBLID = "TANMTA"
        'DB_PARA(DBN_TANMTA).DBID = "USR1"
        ''
        'DBN_SYSTBA = 7
        'DB_PARA(DBN_SYSTBA).TBLID = "SYSTBA"
        'DB_PARA(DBN_SYSTBA).DBID = "USR1"
        ''
        'DBN_SYSTBB = 8
        'DB_PARA(DBN_SYSTBB).TBLID = "SYSTBB"
        'DB_PARA(DBN_SYSTBB).DBID = "USR1"
        ''
        'DBN_SYSTBC = 9
        'DB_PARA(DBN_SYSTBC).TBLID = "SYSTBC"
        'DB_PARA(DBN_SYSTBC).DBID = "USR1"
        ''
        'DBN_SYSTBD = 10
        'DB_PARA(DBN_SYSTBD).TBLID = "SYSTBD"
        'DB_PARA(DBN_SYSTBD).DBID = "USR1"
        '
        'DBN_SYSTBF = 11
        'DB_PARA(DBN_SYSTBF).TBLID = "SYSTBF"
        'DB_PARA(DBN_SYSTBF).DBID = "USR1"
        '
        'DBN_SYSTBG = 12
        'DB_PARA(DBN_SYSTBG).TBLID = "SYSTBG"
        'DB_PARA(DBN_SYSTBG).DBID = "USR1"
        '
        'DBN_SYSTBH = 13
        'DB_PARA(DBN_SYSTBH).TBLID = "SYSTBH"
        'DB_PARA(DBN_SYSTBH).DBID = "USR1"
        '
        'DBN_CLSMTA = 14
        'DB_PARA(DBN_CLSMTA).TBLID = "CLSMTA"
        'DB_PARA(DBN_CLSMTA).DBID = "USR1"
        '
        'DBN_CLSMTB = 15
        'DB_PARA(DBN_CLSMTB).TBLID = "CLSMTB"
        'DB_PARA(DBN_CLSMTB).DBID = "USR1"
        '
        'DBN_UNYMTA = 16
        'DB_PARA(DBN_UNYMTA).TBLID = "UNYMTA"
        'DB_PARA(DBN_UNYMTA).DBID = "USR1"
        '
        'DBN_FIXMTA = 17
        'DB_PARA(DBN_FIXMTA).TBLID = "FIXMTA"
        'DB_PARA(DBN_FIXMTA).DBID = "USR1"
        '
        'DBN_CLDMTA = 18
        'DB_PARA(DBN_CLDMTA).TBLID = "CLDMTA"
        'DB_PARA(DBN_CLDMTA).DBID = "USR1"
        '
        'DBN_GYMTBZ = 19
        'DB_PARA(DBN_GYMTBZ).TBLID = "GYMTBZ"
        'DB_PARA(DBN_GYMTBZ).DBID = "USR1"
        '
        'DBN_EXCTBZ = 20
        'DB_PARA(DBN_EXCTBZ).TBLID = "EXCTBZ"
        'DB_PARA(DBN_EXCTBZ).DBID = "USR1"
        '
        'DBN_KNGMTB = 21
        'DB_PARA(DBN_KNGMTB).TBLID = "KNGMTB"
        'DB_PARA(DBN_KNGMTB).DBID = "USR1"
        '
        DBN_FDNTRA = -1
		'
		DBN_JDNTRA = -2
		'
		DBN_SBNTRA = -3
		'
		DBN_SKYTBL = -4
		'
		DBN_SYKTRI = -5
		'
		DBN_STOTRA = -6
		'
		DBN_SYKFP51 = -7
		
		SSS_BILFL = 9
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
	
	Sub UpdSmf() 'Generated.
	End Sub

    Sub WK_FromScr(ByVal De As Short) 'Generated.
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ODNYTDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WG_ODNYTDT = RD_SSSMAIN_ODNYTDT(0)
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WG_SOUCD = RD_SSSMAIN_SOUCD(0)
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SOUNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WG_SOUNM = RD_SSSMAIN_SOUNM(0)
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPEID() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WG_OPEID = RD_SSSMAIN_OPEID(0)
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_OPENM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WG_OPENM = RD_SSSMAIN_OPENM(0)
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_WRTFSTDT() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WG_WRTFSTDT = RD_SSSMAIN_WRTFSTDT(0)
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_WRTFSTTM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WG_WRTFSTTM = RD_SSSMAIN_WRTFSTTM(0)
    End Sub

    '2019/09/23 DEL START
    'Sub SetBuf(ByVal Fno As Short) 'Generated.
    '    Select Case Fno
    '        Case DBN_SYKTRA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_SYKTRA)
    '        Case DBN_FDNTHA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_FDNTHA)
    '        Case DBN_TOKMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_TOKMTA)
    '        Case DBN_SOUMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_SOUMTA)
    '        Case DBN_HINMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_HINMTA)
    '        Case DBN_MEIMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_MEIMTA)
    '        Case DBN_TANMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_TANMTA)
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
    '        Case DBN_UNYMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_UNYMTA)
    '        Case DBN_FIXMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_FIXMTA)
    '        Case DBN_CLDMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_CLDMTA)
    '        Case DBN_GYMTBZ
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_GYMTBZ)
    '        Case DBN_EXCTBZ
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_EXCTBZ)
    '        Case DBN_KNGMTB
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_KNGMTB)
    '    End Select
    'End Sub
    '2019/09/23 DEL E N D


    '2019/09/23 DEL START
    'Sub ResetBuf(ByVal Fno As Short) 'Generated.
    '    Select Case Fno
    '        Case DBN_SYKTRA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_SYKTRA = LSet(G_LB)
    '        Case DBN_FDNTHA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_FDNTHA = LSet(G_LB)
    '        Case DBN_TOKMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_TOKMTA = LSet(G_LB)
    '        Case DBN_SOUMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_SOUMTA = LSet(G_LB)
    '        Case DBN_HINMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_HINMTA = LSet(G_LB)
    '        Case DBN_MEIMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_MEIMTA = LSet(G_LB)
    '        Case DBN_TANMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_TANMTA = LSet(G_LB)
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
    '        Case DBN_UNYMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_UNYMTA = LSet(G_LB)
    '        Case DBN_FIXMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_FIXMTA = LSet(G_LB)
    '        Case DBN_CLDMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_CLDMTA = LSet(G_LB)
    '        Case DBN_GYMTBZ
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_GYMTBZ = LSet(G_LB)
    '        Case DBN_EXCTBZ
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_EXCTBZ = LSet(G_LB)
    '        Case DBN_KNGMTB
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_KNGMTB = LSet(G_LB)
    '    End Select
    'End Sub
    '2019/09/23 DEL E N D

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