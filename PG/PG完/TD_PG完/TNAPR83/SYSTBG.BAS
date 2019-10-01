Attribute VB_Name = "SYSTBG_DBM"
        Option Explicit
'==========================================================================
'   SYSTBG.DBM   使用分類名称                     UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SYSTBG
    CLSKB          As String * 1     '分類区分              0
    USENM          As String * 20    '使用分類名称
    OPEID          As String * 8     '最終作業者コード      !@@@@@@@@
    CLTID          As String * 5     'クライアントＩＤ      !@@@@@
    WRTTM          As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
    WRTDT          As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
End Type
Global DB_SYSTBG As TYPE_DB_SYSTBG
Global DBN_SYSTBG As Integer
' Index1( CLSKB )

Sub SYSTBG_RClear()
Dim TmpStat
    TmpStat = Dll_RClear(DBN_SYSTBG, G_LB)
    Call ResetBuf(DBN_SYSTBG)
End Sub
