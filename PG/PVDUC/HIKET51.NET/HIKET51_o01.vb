Option Strict Off
Option Explicit On
Module HIKET51_O01
	'
	' スロット名        : 伝票発行・オプショナルスロット
	' ユニット名        : UODET01.O01
	' 記述者            : Standard Library
	' 作成日付          : 1996/10/01
	' 使用プログラム名  : UODET01
	'
	'
	
	Sub CREATE_WFIL(ByRef Fno As Short)
		'
		Call JB_DelAll(Fno)
	End Sub
	
	Sub PRNBIL()
		'Dim oldReportPath As String, newReportPath As String
		'Dim RPTID As String
		'    '
		'    DB_SYSTBI.PRGID = SSS_PrgId
		'    DB_SYSTBI.LSTID = RD_SSSMAIN_LSTID(0)
		'    Call DB_GetEq(DBN_SYSTBI, 1, DB_SYSTBI.PRGID & DB_SYSTBI.LSTID, BtrNormal)
		'    If DBSTAT = 0 Then
		'        RPTID = Trim$(DB_SYSTBI.RPTID)
		'    Else
		'        RPTID = SSS_PrgId
		'    End If
		'    If CRW_OPEN(SSS_INIDAT(2) & "RPT\" & RPTID & ".RPT") = False Then
		'        Call Error_Exit("ERROR PRNBUL CRW_OPEN")
		'    End If
		'    '
		'   'ＰＲ１帳票(JET＋ODBC)出力異常問題で、一行追加 1998/10/13
		'    Call JB_BeginTransaction(0)
		'   '追加終わり 1998/10/13
		'    Call CREATE_WFIL(DBN_UODET01)
		'    Call WRITE_WFIL(DBN_UODET01)
		'   'ＰＲ１帳票(JET＋ODBC)出力異常問題で、一行追加 1998/10/13
		'    Call JB_EndTransaction
		'   '追加終わり 1998/10/13
		'    oldReportPath = SSS_INIDAT(1) & "WRK\" & Trim$(DB_PARA(DBN_UODET01).DBID)
		'    'newReportPath = SSS_INIDAT(3) & Trim$(DB_PARA(DBN_UODET01).dbid)
		'    newReportPath = SSS_INIDAT(3) & Trim$(DB_PARA(DBN_UODET01).DBID) & ".MDB"
		'    If CRW_CHGLOCATION(oldReportPath, newReportPath) = False Then
		'        Call Error_Exit("Error!  PRNBIL CRW_CHGLOCATION")
		'    End If
		'    '
		'    Call CRW_SET_PRINTER    'プリンタ切り替え機能を有効にした場合のため
		'    '
		'    If CRW_PUTPRINTER() = False Then
		'        Call Error_Exit("Error!  PRNBIL CRW_PUTPRINTER")
		'    Else
		'        If CRW_PRINT() = False Then
		'            Call Error_Exit("Error!  PRNBIL CRW_PRINT")
		'        End If
		'    End If
		'    Call CRW_CLOSE
	End Sub
	
	Sub WRITE_WFIL(ByRef Fno As Short)
		'Dim I As Integer
		'    '
		'    Do While I < PP_SSSMAIN.LastDe
		'        Call UODET01_RClear
		'        Call UODET01_FromSCR(I)
		'        'Call TOKMTA_RClear
		'        Call DB_GetEq(DBN_TOKMTA, 1, RD_SSSMAIN_TOKCD(I), BtrNormal)
		'        If DBSTAT = 0 Then Call UODET01_FromTOKMTA
		'        If DB_TOKMTA.TOKNMMKB = "1" Then DB_UODET01.TOKNMA = DB_UODET01.TOKRN   '1999/05/20  Insert
		'        Call DB_Insert(Fno, NCCNo)
		'        I = I + 1
		'    Loop
	End Sub
End Module