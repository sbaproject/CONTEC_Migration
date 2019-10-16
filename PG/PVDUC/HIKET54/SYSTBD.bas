Attribute VB_Name = "SYSTBD_DBM"
        Option Explicit
'==========================================================================
'   SYSTBD.DBM   取引区分テーブル                 UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SYSTBD
    DKBSB          As String * 3     '伝票取引区分種別      000
    DKBID          As String * 2     '取引区分コード        00
    DKBNM          As String * 6     '取引区分名称
    UPDID          As String * 2     '更新用ｲﾝﾃﾞｯｸｽ(ACNT)   00
    DFLDKBCD       As String * 13    'デフォルトコード      !@@@@@@@@@@@@@
    DKBZAIFL       As String * 1     '在庫関連フラグ        0
    DKBTEGFL       As String * 1     '手形発生フラグ        0
    DKBFLA         As String * 1     'ダミーフラグ１        0
    DKBFLB         As String * 1     'ダミーフラグ２        0
    DKBFLC         As String * 1     'ダミーフラグ３        0
    OPEID          As String * 8     '最終作業者コード      !@@@@@@@@
    CLTID          As String * 5     'クライアントＩＤ      !@@@@@
    WRTTM          As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)
    WRTDT          As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD
End Type
Global DB_SYSTBD As TYPE_DB_SYSTBD
Global DBN_SYSTBD As Integer
' Index1( DKBSB + DKBID )

Sub SYSTBD_RClear()
Dim TmpStat
    TmpStat = Dll_RClear(DBN_SYSTBD, G_LB)
    Call ResetBuf(DBN_SYSTBD)
End Sub
