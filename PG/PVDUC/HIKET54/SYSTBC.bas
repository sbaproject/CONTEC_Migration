Attribute VB_Name = "SYSTBC_DBM"
        Option Explicit
'==========================================================================
'   SYSTBC.DBM   ﾕｰｻﾞｰ伝票NOﾃｰﾌﾞﾙ                 UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SYSTBC
    DKBSB          As String * 3     '伝票取引区分種別      000
    ADDDENCD       As String * 13    '伝票付属コード        !@@@@@@@@@@@@@
    DENNM          As String * 20    '伝票名称
    DENNO          As String * 8     '伝票NO.               00000000
    OPEID          As String * 8     '最終作業者コード      !@@@@@@@@
    CLTID          As String * 5     'クライアントＩＤ      !@@@@@
    WRTTM          As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
    WRTDT          As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
End Type
Global DB_SYSTBC As TYPE_DB_SYSTBC
Global DBN_SYSTBC As Integer
' Index1( DKBSB + ADDDENCD )

Sub SYSTBC_RClear()
Dim TmpStat
    TmpStat = Dll_RClear(DBN_SYSTBC, G_LB)
    Call ResetBuf(DBN_SYSTBC)
End Sub
