Attribute VB_Name = "JDNTRA_M22"
Option Explicit
'
' スロット名        : 受注トラン・メインファイル更新スロット(PL/SQL対応)
' ユニット名        : JDNTRA.M22
' 記述者            : Standard Library
' 作成日付          : 1999/10/19
' 使用プログラム名  : UODET01
'

Function DELTRN() As Integer
Dim PlStat As Long
Dim I%
    '
    ' PL/SQL 対応ﾊﾟﾗﾒｰﾀ G_PlCnd.nJobMode は SSSMAIN.ET1 で設定される
    If G_PlCnd.nJobMode <> 2 Then Exit Function  'Delete以外
    FR_SSSMAIN.Enabled = False

    For I = 0 To MAX_CNDARR - 1
        G_PlCnd.sCndStr(I) = String$(20, Chr$(Asc("A") + I))
        G_PlCnd.nCndNum(I) = I + 1
    Next I

    G_PlCnd.sOpeID = SSS_OPEID
    G_PlCnd.sCltID = SSS_CLTID

    G_PlInfo.FCnt = 2
    G_PlInfo.Fno(0) = DBN_JDNTRA
    G_PlInfo.RCnt(0) = 1
    G_PlInfo.ArrayFlg(0) = 1
    G_PlInfo.Fno(1) = DBN_JDNTHA
    G_PlInfo.RCnt(1) = 1
    G_PlInfo.ArrayFlg(1) = 0

'    DB_JDNTHA.JDNNO = RD_SSSMAIN_JDNNO(-1)

    PlStat = DB_PlStart
    PlStat = DB_PlCndSet
    PlStat = DB_PlSet(DBN_JDNTHA, 0)
    PlStat = DB_PlSet(DBN_JDNTRA, 0)

    Call DB_BeginTransaction(BTR_Exclude)
    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_JDNTRA")
    If PlStat <> 0 And PlStat <> 1485 Then
        MsgBox "PL/SQL Error：" & PlStat
        DELTRN = False
        DB_AbortTransaction
    Else
        DELTRN = True
        Call DB_EndTransaction
    End If

    PlStat = DB_PlFree

    FR_SSSMAIN.Enabled = True
End Function

Function WRTTRN() As Integer
Dim I As Integer
Dim PlStat As Long
    '
    FR_SSSMAIN.Enabled = False

    ' PL/SQL 対応ﾊﾟﾗﾒｰﾀ G_PlCnd.nJobMode は SSSMAIN.ET1 で設定される

    For I = 0 To MAX_CNDARR - 1
        G_PlCnd.sCndStr(I) = String$(20, Chr$(Asc("A") + I))
        G_PlCnd.nCndNum(I) = I + 1
    Next I

    G_PlCnd.sOpeID = SSS_OPEID
    G_PlCnd.sCltID = SSS_CLTID

    G_PlInfo.FCnt = 2
    G_PlInfo.Fno(0) = DBN_JDNTRA
    G_PlInfo.RCnt(0) = PP_SSSMAIN.LastDe
    G_PlInfo.ArrayFlg(0) = 1
    G_PlInfo.Fno(1) = DBN_JDNTHA
    G_PlInfo.RCnt(1) = 1
    G_PlInfo.ArrayFlg(1) = 0

    '
    Call JDNTHA_RClear
    'Call JDNTHA_FromSCR(-1)
    DB_JDNTHA.DATKB = "1"
    DB_JDNTHA.DENKB = "1"
    DB_JDNTHA.JDNKB = "1"   '1999/10/19 Insert
    DB_JDNTHA.SMADT = SSS_SMADT
    '
    PlStat = DB_PlStart
    PlStat = DB_PlCndSet
    PlStat = DB_PlSet(DBN_JDNTHA, 0)
    I = 0
    Do While I < PP_SSSMAIN.LastDe
        Call JDNTRA_RClear
        Call Mfil_FromSCR(I)
        DB_JDNTRA.DATKB = "1"
        DB_JDNTRA.DENKB = "1"
        DB_JDNTRA.JDNKB = "1"   '1999/10/19 Insert
        DB_JDNTRA.SMADT = SSS_SMADT
        PlStat = DB_PlSet(DBN_JDNTRA, I)
        I = I + 1
    Loop

    Call DB_BeginTransaction(BTR_Exclude)
    PlStat = DB_PlExec(SSS_PrgId & "_PACK.M_JDNTRA")
    If PlStat <> 0 And PlStat <> 1485 Then
        MsgBox "PL/SQL Error：" & PlStat
        WRTTRN = False
        DB_AbortTransaction
    Else
        WRTTRN = True
        Call DB_EndTransaction
'1998/05/12  １行追加
        Call DP_SSSMAIN_JDNNO(-1, G_PlCnd2.sCndStr(1))
    End If

    PlStat = DB_PlFree

    FR_SSSMAIN.Enabled = True
End Function
