Attribute VB_Name = "SYSTBG_DBM"
        Option Explicit
'==========================================================================
'   SYSTBG.DBM   �g�p���ޖ���                     UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SYSTBG
    CLSKB          As String * 1     '���ދ敪              0
    USENM          As String * 20    '�g�p���ޖ���
    OPEID          As String * 8     '�ŏI��Ǝ҃R�[�h      !@@@@@@@@
    CLTID          As String * 5     '�N���C�A���g�h�c      !@@@@@
    WRTTM          As String * 6     '��ѽ����(����)        9(06)
    WRTDT          As String * 8     '��ѽ����(���t)        YYYY/MM/DD
End Type
Global DB_SYSTBG As TYPE_DB_SYSTBG
Global DBN_SYSTBG As Integer
' Index1( CLSKB )

Sub SYSTBG_RClear()
Dim TmpStat
    TmpStat = Dll_RClear(DBN_SYSTBG, G_LB)
    Call ResetBuf(DBN_SYSTBG)
End Sub
