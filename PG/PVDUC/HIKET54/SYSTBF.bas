Attribute VB_Name = "SYSTBF_DBM"
        Option Explicit
'==========================================================================
'   SYSTBF.DBM   ���ރ}�X�^(�g�p���ސݒ�)         UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SYSTBF
    MSTKB          As String * 1     '�}�X�^�敪            0
    MSTNM          As String * 20    '�}�X�^����
    CLAKB          As String * 1     '���ދ敪              0
    CLBKB          As String * 1     '���ދ敪              0
    CLCKB          As String * 1     '���ދ敪              0
    USENMA         As String * 20    '���ގg�p���̂`
    USENMB         As String * 20    '���ގg�p���̂a
    USENMC         As String * 20    '���ގg�p���̂b
    OYAKBB         As String * 1     '���ސe�q�敪�Q        0
    OYAKBC         As String * 1     '���ސe�q�敪�R        0
    OPEID          As String * 8     '�ŏI��Ǝ҃R�[�h      !@@@@@@@@
    CLTID          As String * 5     '�N���C�A���g�h�c      !@@@@@
    WRTTM          As String * 6     '��ѽ����(����)        9(06)
    WRTDT          As String * 8     '��ѽ����(���t)        YYYY/MM/DD
End Type
Global DB_SYSTBF As TYPE_DB_SYSTBF
Global DBN_SYSTBF As Integer
' Index1( MSTKB )

Sub SYSTBF_RClear()
Dim TmpStat
    TmpStat = Dll_RClear(DBN_SYSTBF, G_LB)
    Call ResetBuf(DBN_SYSTBF)
End Sub