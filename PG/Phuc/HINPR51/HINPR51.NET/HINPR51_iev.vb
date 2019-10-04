Option Strict Off
Option Explicit On
Module HINPR51_IEV
	Public Const SSS_MAX_DB As Short = 18
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "HINPR51"
	Public Const SSS_PrgNm As String = "商品マスタ一覧リスト          "
	Public Const SSS_FraId As String = "PR2"
	Public WG_OPEID As String
	Public WG_OPENM As String
	Public WG_KHNKB As String
	Public WG_STTHINCD As String
	Public WG_STTHINNM As String
	Public WG_ENDHINCD As String
	Public WG_ENDHINNM As String
	Public WG_HINKB As String
	
	Sub Init_Fil() 'Generated.
		'
		DBN_HINPR51 = 0
		DB_PARA(DBN_HINPR51).tblid = "HINPR51"
		DB_PARA(DBN_HINPR51).DBID = "USR9"
		SSS_MFIL = DBN_HINPR51
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
		DBN_CLSMTA = 8
		DB_PARA(DBN_CLSMTA).tblid = "CLSMTA"
		DB_PARA(DBN_CLSMTA).DBID = "USR1"
		'
		DBN_CLSMTB = 9
		DB_PARA(DBN_CLSMTB).tblid = "CLSMTB"
		DB_PARA(DBN_CLSMTB).DBID = "USR1"
		'
		DBN_TANMTA = 10
		DB_PARA(DBN_TANMTA).tblid = "TANMTA"
		DB_PARA(DBN_TANMTA).DBID = "USR1"
		'
		DBN_UNYMTA = 11
		DB_PARA(DBN_UNYMTA).tblid = "UNYMTA"
		DB_PARA(DBN_UNYMTA).DBID = "USR1"
		'
		DBN_HINMTA = 12
		DB_PARA(DBN_HINMTA).tblid = "HINMTA"
		DB_PARA(DBN_HINMTA).DBID = "USR1"
		'
		DBN_SIRMTA = 13
		DB_PARA(DBN_SIRMTA).tblid = "SIRMTA"
		DB_PARA(DBN_SIRMTA).DBID = "USR1"
		'
		DBN_MEIMTA = 14
		DB_PARA(DBN_MEIMTA).tblid = "MEIMTA"
		DB_PARA(DBN_MEIMTA).DBID = "USR1"
		'
		DBN_EXCTBZ = 15
		DB_PARA(DBN_EXCTBZ).tblid = "EXCTBZ"
		DB_PARA(DBN_EXCTBZ).DBID = "USR1"
		'
		DBN_GYMTBZ = 16
		DB_PARA(DBN_GYMTBZ).tblid = "GYMTBZ"
		DB_PARA(DBN_GYMTBZ).DBID = "USR1"
		'
		DBN_KNGMTB = 17
		DB_PARA(DBN_KNGMTB).tblid = "KNGMTB"
		DB_PARA(DBN_KNGMTB).DBID = "USR1"
		
		SSS_LSTMFIL = DBN_HINPR51
	End Sub
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		Call DP_SSSMAIN_ENDHINCD(De, DB_HINPR51.ENDHINCD)
		Call DP_SSSMAIN_ENDHINNM(De, DB_HINPR51.ENDHINNM)
		Call DP_SSSMAIN_STTHINCD(De, DB_HINPR51.STTHINCD)
		Call DP_SSSMAIN_STTHINNM(De, DB_HINPR51.STTHINNM)
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDHINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINPR51.ENDHINCD = RD_SSSMAIN_ENDHINCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDHINNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINPR51.ENDHINNM = RD_SSSMAIN_ENDHINNM(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTHINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINPR51.STTHINCD = RD_SSSMAIN_STTHINCD(De)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTHINNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DB_HINPR51.STTHINNM = RD_SSSMAIN_STTHINNM(De)
		If Trim(DB_ORATM) = "" Or Trim(DB_ORADT) = "" Then
		Else
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
	
	Sub HINPR51_FromHINMTA() 'Generated.
		Dim I As Short
		
		DB_HINPR51.ABODT = DB_HINMTA.ABODT
		DB_HINPR51.ANZZAISU = DB_HINMTA.ANZZAISU
		DB_HINPR51.BTOKB = DB_HINMTA.BTOKB
		DB_HINPR51.CATSPCNM = DB_HINMTA.CATSPCNM
		DB_HINPR51.CHARANM = DB_HINMTA.CHARANM
		DB_HINPR51.CTLGKB = DB_HINMTA.CTLGKB
		DB_HINPR51.DSPKB = DB_HINMTA.DSPKB
		DB_HINPR51.EDIHINSY = DB_HINMTA.EDIHINSY
		DB_HINPR51.GNKCD = DB_HINMTA.GNKCD
		DB_HINPR51.GNKTK = DB_HINMTA.GNKTK
		DB_HINPR51.GNKTKDT = DB_HINMTA.GNKTKDT
		DB_HINPR51.HINCD = DB_HINMTA.HINCD
		DB_HINPR51.HINCLAID = DB_HINMTA.HINCLAID
		DB_HINPR51.HINCLAKB = DB_HINMTA.HINCLAKB
		DB_HINPR51.HINCLANM = DB_HINMTA.HINCLANM
		DB_HINPR51.HINCLBID = DB_HINMTA.HINCLBID
		DB_HINPR51.HINCLBKB = DB_HINMTA.HINCLBKB
		DB_HINPR51.HINCLBNM = DB_HINMTA.HINCLBNM
		DB_HINPR51.HINCLCID = DB_HINMTA.HINCLCID
		DB_HINPR51.HINCLCKB = DB_HINMTA.HINCLCKB
		DB_HINPR51.HINCLCNM = DB_HINMTA.HINCLCNM
		DB_HINPR51.HINCMA = DB_HINMTA.HINCMA
		DB_HINPR51.HINCMB = DB_HINMTA.HINCMB
		DB_HINPR51.HINCMC = DB_HINMTA.HINCMC
		DB_HINPR51.HINCMD = DB_HINMTA.HINCMD
		DB_HINPR51.HINCME = DB_HINMTA.HINCME
		DB_HINPR51.HINFRNNM = DB_HINMTA.HINFRNNM
		DB_HINPR51.HINGRP = DB_HINMTA.HINGRP
		DB_HINPR51.HINID = DB_HINMTA.HINID
		DB_HINPR51.HINJUNKB = DB_HINMTA.HINJUNKB
		DB_HINPR51.HINKB = DB_HINMTA.HINKB
		DB_HINPR51.HINMSTKB = DB_HINMTA.HINMSTKB
		DB_HINPR51.HINNK = DB_HINMTA.HINNK
		DB_HINPR51.HINNMA = DB_HINMTA.HINNMA
		DB_HINPR51.HINNMB = DB_HINMTA.HINNMB
		DB_HINPR51.HINNMC = DB_HINMTA.HINNMC
		DB_HINPR51.HINNMD = DB_HINMTA.HINNMD
		DB_HINPR51.HINNME = DB_HINMTA.HINNME
		DB_HINPR51.HINNMMKB = DB_HINMTA.HINNMMKB
		DB_HINPR51.HINSIRCD = DB_HINMTA.HINSIRCD
		DB_HINPR51.HINSIRRN = DB_HINMTA.HINSIRRN
		DB_HINPR51.HINURLNM = DB_HINMTA.HINURLNM
		DB_HINPR51.HINZEIKB = DB_HINMTA.HINZEIKB
		DB_HINPR51.HRTDD = DB_HINMTA.HRTDD
		DB_HINPR51.JANCD = DB_HINMTA.JANCD
		DB_HINPR51.JODHIKKB = DB_HINMTA.JODHIKKB
		DB_HINPR51.JODSTDT = DB_HINMTA.JODSTDT
		DB_HINPR51.JODSTPDT = DB_HINMTA.JODSTPDT
		DB_HINPR51.JODSTPKB = DB_HINMTA.JODSTPKB
		DB_HINPR51.KHNKB = DB_HINMTA.KHNKB
		DB_HINPR51.KONPOP = DB_HINMTA.KONPOP
		DB_HINPR51.KOUZA = DB_HINMTA.KOUZA
		DB_HINPR51.LOTSEQNO = DB_HINMTA.LOTSEQNO
		DB_HINPR51.MAKCD = DB_HINMTA.MAKCD
		DB_HINPR51.MAKNM = DB_HINMTA.MAKNM
		DB_HINPR51.MDLCL = DB_HINMTA.MDLCL
		DB_HINPR51.MINSODSU = DB_HINMTA.MINSODSU
		DB_HINPR51.MLOHINID = DB_HINMTA.MLOHINID
		DB_HINPR51.MLOIDORT = DB_HINMTA.MLOIDORT
		DB_HINPR51.MLOKB = DB_HINMTA.MLOKB
		DB_HINPR51.MLOLMTSU = DB_HINMTA.MLOLMTSU
		DB_HINPR51.MNFDD = DB_HINMTA.MNFDD
		DB_HINPR51.MNTENDDT = DB_HINMTA.MNTENDDT
		DB_HINPR51.MNTENDKB = DB_HINMTA.MNTENDKB
		DB_HINPR51.NXTMDL = DB_HINMTA.NXTMDL
		DB_HINPR51.OEMKB = DB_HINMTA.OEMKB
		DB_HINPR51.OEMTOKRN = DB_HINMTA.OEMTOKRN
		DB_HINPR51.OLDGNKTK = DB_HINMTA.OLDGNKTK
		DB_HINPR51.OLDMDLCL = DB_HINMTA.OLDMDLCL
		DB_HINPR51.OLDPLNTK = DB_HINMTA.OLDPLNTK
		DB_HINPR51.OPENKB = DB_HINMTA.OPENKB
		DB_HINPR51.ORTDD = DB_HINMTA.ORTDD
		DB_HINPR51.ORTKB = DB_HINMTA.ORTKB
		DB_HINPR51.ORTKJDT = DB_HINMTA.ORTKJDT
		DB_HINPR51.ORTSTDT = DB_HINMTA.ORTSTDT
		DB_HINPR51.ORTSTPDT = DB_HINMTA.ORTSTPDT
		DB_HINPR51.ORTSTPKB = DB_HINMTA.ORTSTPKB
		DB_HINPR51.ORTSTYDT = DB_HINMTA.ORTSTYDT
		DB_HINPR51.PLANTK = DB_HINMTA.PLANTK
		DB_HINPR51.PLNTKDT = DB_HINMTA.PLNTKDT
		DB_HINPR51.PRCDD = DB_HINMTA.PRCDD
		DB_HINPR51.PRDENDDT = DB_HINMTA.PRDENDDT
		DB_HINPR51.PRDENDKB = DB_HINMTA.PRDENDKB
		DB_HINPR51.SERIKB = DB_HINMTA.SERIKB
		DB_HINPR51.SKHINGRP = DB_HINMTA.SKHINGRP
		DB_HINPR51.SLENDDT = DB_HINMTA.SLENDDT
		DB_HINPR51.SLENDKB = DB_HINMTA.SLENDKB
		DB_HINPR51.SODADDSU = DB_HINMTA.SODADDSU
		DB_HINPR51.SODUNTSU = DB_HINMTA.SODUNTSU
		DB_HINPR51.STRMATKB = DB_HINMTA.STRMATKB
		DB_HINPR51.TEIKATK = DB_HINMTA.TEIKATK
		DB_HINPR51.TEKZAISU = DB_HINMTA.TEKZAISU
		DB_HINPR51.TITNM1 = DB_HINMTA.TITNM1
		DB_HINPR51.TITNM2 = DB_HINMTA.TITNM2
		DB_HINPR51.TITNM3 = DB_HINMTA.TITNM3
		DB_HINPR51.TNACM = DB_HINMTA.TNACM
		DB_HINPR51.UNTCD = DB_HINMTA.UNTCD
		DB_HINPR51.UNTNM = DB_HINMTA.UNTNM
		DB_HINPR51.VSNNM = DB_HINMTA.VSNNM
		DB_HINPR51.ZAIKB = DB_HINMTA.ZAIKB
		DB_HINPR51.ZAIRNK = DB_HINMTA.ZAIRNK
		DB_HINPR51.ZEIRNKKB = DB_HINMTA.ZEIRNKKB
		DB_HINPR51.ZEIRT = DB_HINMTA.ZEIRT
		DB_HINPR51.ZKMSRETK = DB_HINMTA.ZKMSRETK
		DB_HINPR51.ZKMURITK = DB_HINMTA.ZKMURITK
		DB_HINPR51.ZNKSRETK = DB_HINMTA.ZNKSRETK
		DB_HINPR51.ZNKURITK = DB_HINMTA.ZNKURITK
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
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_KHNKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_KHNKB = RD_SSSMAIN_KHNKB(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTHINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_STTHINCD = RD_SSSMAIN_STTHINCD(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_STTHINNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_STTHINNM = RD_SSSMAIN_STTHINNM(0)
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDHINCD() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_ENDHINCD = RD_SSSMAIN_ENDHINCD(0)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(WG_ENDHINCD)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(WG_ENDHINCD)) = 0 Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_ENDHINCD = HighValue(LenWid(WG_ENDHINCD))
		End If
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_ENDHINNM() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_ENDHINNM = RD_SSSMAIN_ENDHINNM(0)
		'UPGRADE_WARNING: オブジェクト LenWid(Trim$(WG_ENDHINNM)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If LenWid(Trim(WG_ENDHINNM)) = 0 Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WG_ENDHINNM = HighValue(LenWid(WG_ENDHINNM))
		End If
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_HINKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WG_HINKB = RD_SSSMAIN_HINKB(0)
	End Sub
	
	Sub SetBuf(ByVal Fno As Short) 'Generated.
		Select Case Fno
			Case DBN_HINPR51
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_HINPR51)
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
			Case DBN_CLSMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_CLSMTA)
			Case DBN_CLSMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_CLSMTB)
			Case DBN_TANMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_TANMTA)
			Case DBN_UNYMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_UNYMTA)
			Case DBN_HINMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_HINMTA)
			Case DBN_SIRMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_SIRMTA)
			Case DBN_MEIMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_MEIMTA)
			Case DBN_EXCTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_EXCTBZ)
			Case DBN_GYMTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_GYMTBZ)
			Case DBN_KNGMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				G_LB = LSet(DB_KNGMTB)
		End Select
	End Sub
	
	Sub ResetBuf(ByVal Fno As Short) 'Generated.
		Select Case Fno
			Case DBN_HINPR51
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_HINPR51 = LSet(G_LB)
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
			Case DBN_CLSMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_CLSMTA = LSet(G_LB)
			Case DBN_CLSMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_CLSMTB = LSet(G_LB)
			Case DBN_TANMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_TANMTA = LSet(G_LB)
			Case DBN_UNYMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_UNYMTA = LSet(G_LB)
			Case DBN_HINMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_HINMTA = LSet(G_LB)
			Case DBN_SIRMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_SIRMTA = LSet(G_LB)
			Case DBN_MEIMTA
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_MEIMTA = LSet(G_LB)
			Case DBN_EXCTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_EXCTBZ = LSet(G_LB)
			Case DBN_GYMTBZ
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_GYMTBZ = LSet(G_LB)
			Case DBN_KNGMTB
				'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
				DB_KNGMTB = LSet(G_LB)
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