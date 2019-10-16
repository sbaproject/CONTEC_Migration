	Option Explicit
'==========================================================================
'   CLSMTB.DBM   分類マスタ(親子関連)             UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_CLSMTB
    MSTKB          As String * 1     'マスタ区分            0                   
    CLSKEYKB       As String * 1     '分類使用区分          0                   
    CLAID          As String * 6     '分類コード１(納品先)  !@@@@@@             
    CLBID          As String * 6     '分類コード２(納品先)  !@@@@@@             
    CLCID          As String * 6     '分類コード３(納品先)  !@@@@@@             
    OPEID          As String * 8     '最終作業者コード      !@@@@@@@@           
    CLTID          As String * 5     'クライアントＩＤ      !@@@@@              
    WRTTM          As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)               
    WRTDT          As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD          
End Type
Global DB_CLSMTB As TYPE_DB_CLSMTB
Global DBN_CLSMTB As Integer
' Index1( MSTKB + CLSKEYKB + CLAID + CLBID + CLCID )

Sub CLSMTB_RClear()
DIM TmpStat
    TmpStat = Dll_RClear(DBN_CLSMTB, G_LB)
    Call ResetBuf(DBN_CLSMTB)
End Sub
