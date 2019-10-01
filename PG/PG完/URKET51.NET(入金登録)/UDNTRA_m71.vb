Option Strict Off
Option Explicit On
Module UDNTRA_M71
	'
	' スロット名        : 売上トラン・メインファイル更新スロット(PL/SQL対応)
	' ユニット名        : UDNTRA.M23
	' 記述者            : Standard Library
	' 作成日付          : 1997/01/16
	' 使用プログラム名  : URKET01
	'
	
	Function DELTRN() As Short
		'Dim PlStat As Long
		'Dim I%
		'    '
		'    ' PL/SQL 対応ﾊﾟﾗﾒｰﾀ G_PlCnd.nJobMode は SSSMAIN.ET1 で設定される
		'    If G_PlCnd.nJobMode <> 2 Then Exit Function  'Delete以外
		'    FR_SSSMAIN.Enabled = False
		'
		'    For I = 0 To MAX_CNDARR - 1
		'        G_PlCnd.sCndStr(I) = String$(20, Chr$(Asc("A") + I))
		'        G_PlCnd.nCndNum(I) = I + 1
		'    Next I
		'
		'    G_PlCnd.sOpeID = SSS_OPEID
		'    G_PlCnd.sCltID = SSS_CLTID
		'
		'    G_PlInfo.FCnt = 2
		'    G_PlInfo.Fno(1) = DBN_UDNTHA
		'    G_PlInfo.RCnt(1) = 1
		'    G_PlInfo.ArrayFlg(1) = 0
		'    G_PlInfo.Fno(0) = DBN_UDNTRA
		'    G_PlInfo.RCnt(0) = 1
		'    G_PlInfo.ArrayFlg(0) = 1
		'
		'   ' DB_UDNTHA.UDNNO = RD_SSSMAIN_NDNNO(-1)
		'
		'    PlStat = DB_PlStart
		'    PlStat = DB_PlCndSet
		'    PlStat = DB_PlSet(DBN_UDNTHA, 0)
		'    PlStat = DB_PlSet(DBN_UDNTRA, 0)
		'
		'    Call DB_BeginTransaction(BTR_Exclude)
		'    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_UDNTRA")
		'    If PlStat <> 0 And PlStat <> 1485 Then
		'        MsgBox "PL/SQL Error：" & PlStat
		'        DELTRN = False
		'        Call DB_AbortTransaction
		'    Else
		'        DELTRN = True
		'        Call DB_EndTransaction
		'    End If
		'
		'    PlStat = DB_PlFree
		'
		'    FR_SSSMAIN.Enabled = True
	End Function
	
	Function WRTTRN() As Short
		'Dim I As Integer
		'Dim PlStat As Long
		'    '
		'    FR_SSSMAIN.Enabled = False
		'
		'    ' PL/SQL 対応ﾊﾟﾗﾒｰﾀ G_PlCnd.nJobMode は SSSMAIN.ET1 で設定される
		'
		'    For I = 0 To MAX_CNDARR - 1
		'        G_PlCnd.sCndStr(I) = String$(20, Chr$(Asc("A") + I))
		'        G_PlCnd.nCndNum(I) = I + 1
		'    Next I
		'
		'    G_PlCnd.sOpeID = SSS_OPEID
		'    G_PlCnd.sCltID = SSS_CLTID
		'
		'    'Modified on 1997/02/07  Fno(0)<--UDNTRA, Fno(1)<--UDNTHA
		'    G_PlInfo.FCnt = 2
		'    G_PlInfo.Fno(1) = DBN_UDNTHA
		'    G_PlInfo.RCnt(1) = 1
		'    G_PlInfo.ArrayFlg(1) = 0
		'    G_PlInfo.Fno(0) = DBN_UDNTRA
		'    G_PlInfo.RCnt(0) = PP_SSSMAIN.LastDe
		'    G_PlInfo.ArrayFlg(0) = 1
		'    '
		'    Call UDNTHA_RClear
		'    Call UDNTHA_FromSCR(-1)
		'    DB_UDNTHA.DATKB = "1"
		'    DB_UDNTHA.DENKB = WG_DENKB
		'    DB_UDNTHA.SMADT = SSS_SMADT
		'    DB_UDNTHA.SSADT = SSS_SSADT
		'    DB_UDNTHA.KESDT = SSS_KESDT
		'    DB_UDNTHA.UPFKB = "1"
		'    DB_UDNTHA.DENDT = DB_UNYMTA.UNYDT                       '2007.02.07
		'
		'    G_PlCnd.sCndStr(0) = RD_SSSMAIN_FBRFNO(0)
		'    '
		'    PlStat = DB_PlStart
		'    PlStat = DB_PlCndSet
		'    PlStat = DB_PlSet(DBN_UDNTHA, 0)
		'    I = 0
		'    Do While I < PP_SSSMAIN.LastDe
		'        Call UDNTRA_RClear
		'        Call Mfil_FromSCR(I)
		'        DB_UDNTRA.DATKB = "1"
		'        DB_UDNTRA.DENKB = WG_DENKB
		'        DB_UDNTRA.SMADT = SSS_SMADT
		'        DB_UDNTRA.SSADT = SSS_SSADT
		'        DB_UDNTRA.KESDT = SSS_KESDT
		'        DB_UDNTRA.DKBSB = WG_DKBSB
		'        PlStat = DB_PlSet(DBN_UDNTRA, I)
		'        I = I + 1
		'    Loop
		'
		'    Call DB_BeginTransaction(BTR_Exclude)
		'    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_UDNTRA")
		'    If PlStat <> 0 And PlStat <> 1485 Then
		'        MsgBox "PL/SQL Error：" & PlStat
		'        WRTTRN = False
		'        Call DB_AbortTransaction
		'    Else
		'        WRTTRN = True
		'        Call DB_EndTransaction
		'    End If
		'
		'    PlStat = DB_PlFree
		'
		'    FR_SSSMAIN.Enabled = True
	End Function
End Module