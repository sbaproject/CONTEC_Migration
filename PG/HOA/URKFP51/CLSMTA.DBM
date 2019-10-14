	Option Explicit
'==========================================================================
'   CLSMTA.DBM   分類名称マスタ                   UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_CLSMTA
    CLSKB          As String * 1     '分類区分              0                   
    CLSID          As String * 6     '分類コード            !@@@@@@             
    CLSNM          As String * 20    '分類名称                                  
    OPEID          As String * 8     '最終作業者コード      !@@@@@@@@           
    CLTID          As String * 5     'クライアントＩＤ      !@@@@@              
    WRTTM          As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)               
    WRTDT          As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD          
End Type
Global DB_CLSMTA As TYPE_DB_CLSMTA
Global DBN_CLSMTA As Integer
' Index1( CLSKB + CLSID )

Sub CLSMTA_RClear()
DIM TmpStat
    TmpStat = Dll_RClear(DBN_CLSMTA, G_LB)
    Call ResetBuf(DBN_CLSMTA)
End Sub
