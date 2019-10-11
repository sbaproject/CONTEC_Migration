Option Strict Off
Option Explicit On
Module BNKPR51_IEV
	Public Const SSS_MAX_DB As Short = 16
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "BNKPR51"
	'''' UPD 2009/12/25  FKS) T.Yamamoto    Start    連絡票№FC09122501
	'Global Const SSS_PrgNm = "銀行一覧マスタリスト          "
	Public Const SSS_PrgNm As String = "銀行マスタ一覧リスト"
	'''' UPD 2009/12/25  FKS) T.Yamamoto    End
	Public Const SSS_FraId As String = "PR2"
	Public WG_OPEID As String
	Public WG_OPENM As String
	Public WG_STTBNKCD As String
	Public WG_STTBNKNM As String
	Public WG_ENDBNKCD As String
	Public WG_ENDBNKNM As String
	
	Sub Init_Fil() 'Generated.
        '
        '2019/09/19 DEL START
        'DBN_BNKPR51 = 0
        'DB_PARA(DBN_BNKPR51).TBLID = "BNKPR51"
        'DB_PARA(DBN_BNKPR51).DBID = "USR9"
        'SSS_MFIL = DBN_BNKPR51
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
        'DBN_TANMTA = 10
        'DB_PARA(DBN_TANMTA).TBLID = "TANMTA"
        'DB_PARA(DBN_TANMTA).DBID = "USR1"
        ''
        'DBN_UNYMTA = 11
        'DB_PARA(DBN_UNYMTA).TBLID = "UNYMTA"
        'DB_PARA(DBN_UNYMTA).DBID = "USR1"
        ''
        'DBN_BNKMTA = 12
        'DB_PARA(DBN_BNKMTA).TBLID = "BNKMTA"
        'DB_PARA(DBN_BNKMTA).DBID = "USR1"
        ''
        'DBN_EXCTBZ = 13
        'DB_PARA(DBN_EXCTBZ).TBLID = "EXCTBZ"
        'DB_PARA(DBN_EXCTBZ).DBID = "USR1"
        ''
        'DBN_GYMTBZ = 14
        'DB_PARA(DBN_GYMTBZ).TBLID = "GYMTBZ"
        'DB_PARA(DBN_GYMTBZ).DBID = "USR1"
        ''
        'DBN_KNGMTB = 15
        'DB_PARA(DBN_KNGMTB).TBLID = "KNGMTB"
        '      DB_PARA(DBN_KNGMTB).DBID = "USR1"

        '2019/09/19 DEL E N D

        SSS_LSTMFIL = 0
	End Sub

    Sub SCR_FromMfil(ByVal De As Short) 'Generated.      
        '2019/10/03 CHG START
        'Call DP_SSSMAIN_ENDBNKCD(De, DB_BNKPR51.ENDBNKCD)
        'Call DP_SSSMAIN_ENDBNKNM(De, DB_BNKPR51.ENDBNKNM)
        'Call DP_SSSMAIN_STTBNKCD(De, DB_BNKPR51.STTBNKCD)
        'Call DP_SSSMAIN_STTBNKNM(De, DB_BNKPR51.STTBNKNM)
        Call DP_SSSMAIN_STTBNKCD(De, DB_BNKMTA.BNKCD)
        Call DP_SSSMAIN_STTBNKNM(De, DB_BNKMTA.BNKNM)
        '2019/10/03 CHG END
    End Sub
    '2019/10/03 ADD START
    Sub SCR_FromMfilENDBNKCD(ByVal De As Short) 'Generated.
        Call DP_SSSMAIN_ENDBNKCD(De, DB_BNKMTA.BNKCD)
        Call DP_SSSMAIN_ENDBNKNM(De, DB_BNKMTA.BNKNM)
    End Sub
    '2019/10/03 END START

    Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDBNKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_BNKPR51.ENDBNKCD = RD_SSSMAIN_ENDBNKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDBNKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_BNKPR51.ENDBNKNM = RD_SSSMAIN_ENDBNKNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTBNKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_BNKPR51.STTBNKCD = RD_SSSMAIN_STTBNKCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTBNKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_BNKPR51.STTBNKNM = RD_SSSMAIN_STTBNKNM(De)
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_BNKPR51.WRTTM = VB6.Format(Now, "hhmmss")
			DB_BNKPR51.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_BNKPR51.WRTTM = DB_ORATM
			DB_BNKPR51.WRTDT = DB_ORADT
		End If
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
	
	Sub BNKPR51_FromBNKMTA() 'Generated.
		Dim i As Short
		
		DB_BNKPR51.BNKCD = DB_BNKMTA.BNKCD
		DB_BNKPR51.BNKKMKCD = DB_BNKMTA.BNKKMKCD
		DB_BNKPR51.BNKNK = DB_BNKMTA.BNKNK
		DB_BNKPR51.BNKNM = DB_BNKMTA.BNKNM
		DB_BNKPR51.BNKUTICD = DB_BNKMTA.BNKUTICD
		DB_BNKPR51.STNNK = DB_BNKMTA.STNNK
		DB_BNKPR51.STNNM = DB_BNKMTA.STNNM
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
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTBNKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WG_STTBNKCD = RD_SSSMAIN_STTBNKCD(0)
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTBNKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WG_STTBNKNM = RD_SSSMAIN_STTBNKNM(0)
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDBNKCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WG_ENDBNKCD = RD_SSSMAIN_ENDBNKCD(0)
        'UPGRADE_WARNING: オブジェクト LenWid(Trim$(WG_ENDBNKCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If LenWid(Trim(WG_ENDBNKCD)) = 0 Then
            'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WG_ENDBNKCD = HighValue(LenWid(WG_ENDBNKCD))
        End If
        'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDBNKNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        WG_ENDBNKNM = RD_SSSMAIN_ENDBNKNM(0)
        'UPGRADE_WARNING: オブジェクト LenWid(Trim$(WG_ENDBNKNM)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If LenWid(Trim(WG_ENDBNKNM)) = 0 Then
            'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            WG_ENDBNKNM = HighValue(LenWid(WG_ENDBNKNM))
        End If
    End Sub

    '2019/09/20 DEL START
    '   Sub SetBuf(ByVal Fno As Short) 'Generated.
    '	Select Case Fno
    '		Case DBN_BNKPR51
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_BNKPR51)
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
    '		Case DBN_BNKMTA
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_BNKMTA)
    '		Case DBN_EXCTBZ
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_EXCTBZ)
    '		Case DBN_GYMTBZ
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_GYMTBZ)
    '		Case DBN_KNGMTB
    '			'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '			G_LB = LSet(DB_KNGMTB)
    '	End Select
    'End Sub

    '   Sub ResetBuf(ByVal Fno As Short) 'Generated.
    '       Select Case Fno
    '           Case DBN_BNKPR51
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_BNKPR51 = LSet(G_LB)
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
    '           Case DBN_TANMTA
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_TANMTA = LSet(G_LB)
    '           Case DBN_UNYMTA
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_UNYMTA = LSet(G_LB)
    '           Case DBN_BNKMTA
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_BNKMTA = LSet(G_LB)
    '           Case DBN_EXCTBZ
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_EXCTBZ = LSet(G_LB)
    '           Case DBN_GYMTBZ
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_GYMTBZ = LSet(G_LB)
    '           Case DBN_KNGMTB
    '               'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '               DB_KNGMTB = LSet(G_LB)
    '       End Select
    '   End Sub
    '2019/09/20 DEL E N D

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