Attribute VB_Name = "SYSTBC_DBM"
        Option Explicit
'==========================================================================
'   SYSTBC.DBM   Õ°»Þ°`[NOÃ°ÌÞÙ                 UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SYSTBC
    DKBSB          As String * 3     '`[æøæªíÊ      000
    ADDDENCD       As String * 13    '`[t®R[h        !@@@@@@@@@@@@@
    DENNM          As String * 20    '`[¼Ì
    DENNO          As String * 8     '`[NO.               00000000
    OPEID          As String * 8     'ÅIìÆÒR[h      !@@@@@@@@
    CLTID          As String * 5     'NCAghc      !@@@@@
    WRTTM          As String * 6     'À²Ñ½ÀÝÌß(Ô)        9(06)
    WRTDT          As String * 8     'À²Ñ½ÀÝÌß(út)        YYYY/MM/DD
End Type
Global DB_SYSTBC As TYPE_DB_SYSTBC
Global DBN_SYSTBC As Integer
' Index1( DKBSB + ADDDENCD )

Sub SYSTBC_RClear()
Dim TmpStat
    TmpStat = Dll_RClear(DBN_SYSTBC, G_LB)
    Call ResetBuf(DBN_SYSTBC)
End Sub
