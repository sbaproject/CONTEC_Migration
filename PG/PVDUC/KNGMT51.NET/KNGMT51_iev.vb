Option Strict Off
Option Explicit On
Module KNGMT51_IEV
	Public Const SSS_MAX_DB As Short = 9
	Public DB_PARA(SSS_MAX_DB) As TYPE_DB_PARA
	Public Const SSS_PrgId As String = "KNGMT51"
	Public Const SSS_PrgNm As String = "å†å¿É}ÉXÉ^ìoò^Å^í˘ê≥"
	Public Const SSS_FraId As String = "MT1"
	
	Sub Init_Fil() 'Generated.
		'    '
		'    DBN_BNKMTA = 0
		'    DB_PARA(DBN_BNKMTA).tblid = "BNKMTA"
		'    DB_PARA(DBN_BNKMTA).DBID = "USR1"
		'    SSS_MFIL = DBN_BNKMTA
		'    '
		'    DBN_SYSTBA = 1
		'    DB_PARA(DBN_SYSTBA).tblid = "SYSTBA"
		'    DB_PARA(DBN_SYSTBA).DBID = "USR1"
		'    '
		'    DBN_SYSTBB = 2
		'    DB_PARA(DBN_SYSTBB).tblid = "SYSTBB"
		'    DB_PARA(DBN_SYSTBB).DBID = "USR1"
		'    '
		'    DBN_SYSTBC = 3
		'    DB_PARA(DBN_SYSTBC).tblid = "SYSTBC"
		'    DB_PARA(DBN_SYSTBC).DBID = "USR1"
		'    '
		'    DBN_SYSTBD = 4
		'    DB_PARA(DBN_SYSTBD).tblid = "SYSTBD"
		'    DB_PARA(DBN_SYSTBD).DBID = "USR1"
		'    '
		'    DBN_SYSTBF = 5
		'    DB_PARA(DBN_SYSTBF).tblid = "SYSTBF"
		'    DB_PARA(DBN_SYSTBF).DBID = "USR1"
		'    '
		'    DBN_SYSTBG = 6
		'    DB_PARA(DBN_SYSTBG).tblid = "SYSTBG"
		'    DB_PARA(DBN_SYSTBG).DBID = "USR1"
		'    '
		'    DBN_SYSTBH = 7
		'    DB_PARA(DBN_SYSTBH).tblid = "SYSTBH"
		'    DB_PARA(DBN_SYSTBH).DBID = "USR1"
		'    '
		'    DBN_TANMTA = 8
		'    DB_PARA(DBN_TANMTA).tblid = "TANMTA"
		'    DB_PARA(DBN_TANMTA).DBID = "USR1"
		'
		'    SSS_BILFL = 9
	End Sub
	
	Sub SCR_FromMfil(ByVal De As Short) 'Generated.
		'    Call DP_SSSMAIN_BNKCD(De, DB_BNKMTA.BNKCD)
		'    Call DP_SSSMAIN_BNKNK(De, DB_BNKMTA.BNKNK)
		'    Call DP_SSSMAIN_BNKNM(De, DB_BNKMTA.BNKNM)
		'    Call DP_SSSMAIN_STNNK(De, DB_BNKMTA.STNNK)
		'    Call DP_SSSMAIN_STNNM(De, DB_BNKMTA.STNNM)
	End Sub
	
	Sub Mfil_FromSCR(ByVal De As Short) 'Generated.
		'    DB_BNKMTA.BNKCD = RD_SSSMAIN_BNKCD(De)
		'    DB_BNKMTA.BNKNK = RD_SSSMAIN_BNKNK(De)
		'    DB_BNKMTA.BNKNM = RD_SSSMAIN_BNKNM(De)
		'    DB_BNKMTA.STNNK = RD_SSSMAIN_STNNK(De)
		'    DB_BNKMTA.STNNM = RD_SSSMAIN_STNNM(De)
		'    DB_BNKMTA.OPEID = SSS_OPEID
		'    DB_BNKMTA.CLTID = SSS_CLTID
		'    If Trim$(DB_ORATM) = "" Or Trim$(DB_ORADT) = "" Then
		'        DB_BNKMTA.WRTTM = Format(Now, "hhmmss")
		'        DB_BNKMTA.WRTDT = Format(Now, "YYYYMMDD")
		'    Else
		'        DB_BNKMTA.WRTTM = DB_ORATM
		'        DB_BNKMTA.WRTDT = DB_ORADT
		'    End If
	End Sub
	
	Sub UpdSmf() 'Generated.
	End Sub
	
	Sub SetBuf(ByVal Fno As Short) 'Generated.
		'    Select Case Fno
		'        Case DBN_BNKMTA: LSet G_LB = DB_BNKMTA
		'        Case DBN_SYSTBA: LSet G_LB = DB_SYSTBA
		'        Case DBN_SYSTBB: LSet G_LB = DB_SYSTBB
		'        Case DBN_SYSTBC: LSet G_LB = DB_SYSTBC
		'        Case DBN_SYSTBD: LSet G_LB = DB_SYSTBD
		'        Case DBN_SYSTBF: LSet G_LB = DB_SYSTBF
		'        Case DBN_SYSTBG: LSet G_LB = DB_SYSTBG
		'        Case DBN_SYSTBH: LSet G_LB = DB_SYSTBH
		'        Case DBN_TANMTA: LSet G_LB = DB_TANMTA
		'    End Select
	End Sub
	
	Sub ResetBuf(ByVal Fno As Short) 'Generated.
		'    Select Case Fno
		'        Case DBN_BNKMTA: LSet DB_BNKMTA = G_LB
		'        Case DBN_SYSTBA: LSet DB_SYSTBA = G_LB
		'        Case DBN_SYSTBB: LSet DB_SYSTBB = G_LB
		'        Case DBN_SYSTBC: LSet DB_SYSTBC = G_LB
		'        Case DBN_SYSTBD: LSet DB_SYSTBD = G_LB
		'        Case DBN_SYSTBF: LSet DB_SYSTBF = G_LB
		'        Case DBN_SYSTBG: LSet DB_SYSTBG = G_LB
		'        Case DBN_SYSTBH: LSet DB_SYSTBH = G_LB
		'        Case DBN_TANMTA: LSet DB_TANMTA = G_LB
		'    End Select
	End Sub
	
	Function RecordFromObject(ByVal Fno As Short) As Short 'Generated.
		'Dim Rtc As Integer
		'    Select Case Fno
		'        Case Else:
		'    End Select
		'    RecordFromObject = Rtc
	End Function
	
	Function ObjectFromRecord(ByVal Fno As Short) As Short 'Generated.
		'Dim Rtc As Integer
		'    Select Case Fno
		'        Case Else:
		'    End Select
		'    ObjectFromRecord = Rtc
	End Function
End Module