Option Strict Off
Option Explicit On
Module UNTMT51_IEV
	Public Const SSS_MAX_DB As Short = 13
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "UNTMT51"
	'20081003 CHG START RISE)Tanimura '名称変更
	'Global Const SSS_PrgNm = "単位登録                      "
	Public Const SSS_PrgNm As String = "単位マスタ登録／訂正          "
	'20081003 CHG END   RISE)Tanimura
	Public Const SSS_FraId As String = "MT1"
	
	Sub Init_Fil() 'Generated.
		'
		DBN_UNTMTA = 0
		DB_PARA(DBN_UNTMTA).tblid = "UNTMTA"
		DB_PARA(DBN_UNTMTA).DBID = "USR1"
		SSS_MFIL = DBN_UNTMTA
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
		DBN_TANMTA = 8
		DB_PARA(DBN_TANMTA).tblid = "TANMTA"
		DB_PARA(DBN_TANMTA).DBID = "USR1"
		'
		DBN_UNYMTA = 9
		DB_PARA(DBN_UNYMTA).tblid = "UNYMTA"
		DB_PARA(DBN_UNYMTA).DBID = "USR1"
		'
		DBN_EXCTBZ = 10
		DB_PARA(DBN_EXCTBZ).tblid = "EXCTBZ"
		DB_PARA(DBN_EXCTBZ).DBID = "USR1"
		'
		DBN_GYMTBZ = 11
		DB_PARA(DBN_GYMTBZ).tblid = "GYMTBZ"
		DB_PARA(DBN_GYMTBZ).DBID = "USR1"
		'
		DBN_KNGMTB = 12
		DB_PARA(DBN_KNGMTB).tblid = "KNGMTB"
		DB_PARA(DBN_KNGMTB).DBID = "USR1"
		
		SSS_BILFL = 9
	End Sub
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_UNTCD(De, DB_UNTMTA.UNTCD)
		Call DP_SSSMAIN_UNTNM(De, DB_UNTMTA.UNTNM)
		
		'20080929 CHG START RISE)Tanimura '排他処理
		''2007/12/14 add-str T.KAWAMUKAI 元データのタイムスタンプ退避
		''   [引数Deは画面上の行数(0～)]
		'    M_MOTO_A_inf(De).WRTDT = DB_UNTMTA.WRTDT            '更新日付
		'    M_MOTO_A_inf(De).WRTTM = DB_UNTMTA.WRTTM            '更新時刻
		'    M_MOTO_A_inf(De).UWRTDT = ""
		'    M_MOTO_A_inf(De).UWRTTM = ""
		''2007/12/14 add-end T.KAWAMUKAI
		
		' [引数Deは画面上の行数(0～)]
		M_UNTMT_A_inf(De).OPEID = DB_UNTMTA.OPEID ' 最終作業者コード
		M_UNTMT_A_inf(De).CLTID = DB_UNTMTA.CLTID ' クライアントＩＤ
		M_UNTMT_A_inf(De).WRTDT = DB_UNTMTA.WRTDT ' タイムスタンプ（時間）
		M_UNTMT_A_inf(De).WRTTM = DB_UNTMTA.WRTTM ' タイムスタンプ（日付）
		'20080929 CHG END   RISE)Tanimura
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UNTMTA.UNTCD = RD_SSSMAIN_UNTCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UNTNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_UNTMTA.UNTNM = RD_SSSMAIN_UNTNM(De)
		DB_UNTMTA.OPEID = SSS_OPEID.Value
		DB_UNTMTA.CLTID = SSS_CLTID.Value
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
			DB_UNTMTA.WRTTM = VB6.Format(Now, "hhmmss")
			DB_UNTMTA.WRTDT = VB6.Format(Now, "YYYYMMDD")
		Else
			DB_UNTMTA.WRTTM = DB_ORATM
			DB_UNTMTA.WRTDT = DB_ORADT
		End If
	End Sub
	
	Sub UpdSmf() 'Generated.
	End Sub

    '2019/09/25 DEL START
    'Sub SetBuf(ByVal Fno As Short) 'Generated.
    '    Select Case Fno
    '        Case DBN_UNTMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            G_LB = LSet(DB_UNTMTA)
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
    '    End Select
    'End Sub
    '2019/09/25 DEL E N D

    '2019/09/25 DEL START
    'Sub ResetBuf(ByVal Fno As Short) 'Generated.
    '    Select Case Fno
    '        Case DBN_UNTMTA
    '            'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
    '            DB_UNTMTA = LSet(G_LB)
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
    '    End Select
    'End Sub
    '2019/09/25 DEL E N D

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