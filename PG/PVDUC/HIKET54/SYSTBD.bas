Attribute VB_Name = "SYSTBD_DBM"
        Option Explicit
'==========================================================================
'   SYSTBD.DBM   ����敪�e�[�u��                 UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_SYSTBD
    DKBSB          As String * 3     '�`�[����敪���      000
    DKBID          As String * 2     '����敪�R�[�h        00
    DKBNM          As String * 6     '����敪����
    UPDID          As String * 2     '�X�V�p���ޯ��(ACNT)   00
    DFLDKBCD       As String * 13    '�f�t�H���g�R�[�h      !@@@@@@@@@@@@@
    DKBZAIFL       As String * 1     '�݌Ɋ֘A�t���O        0
    DKBTEGFL       As String * 1     '��`�����t���O        0
    DKBFLA         As String * 1     '�_�~�[�t���O�P        0
    DKBFLB         As String * 1     '�_�~�[�t���O�Q        0
    DKBFLC         As String * 1     '�_�~�[�t���O�R        0
    OPEID          As String * 8     '�ŏI��Ǝ҃R�[�h      !@@@@@@@@
    CLTID          As String * 5     '�N���C�A���g�h�c      !@@@@@
    WRTTM          As String * 6     '��ѽ����(����)        9(06)
    WRTDT          As String * 8     '��ѽ����(���t)        YYYY/MM/DD
End Type
Global DB_SYSTBD As TYPE_DB_SYSTBD
Global DBN_SYSTBD As Integer
' Index1( DKBSB + DKBID )

Sub SYSTBD_RClear()
Dim TmpStat
    TmpStat = Dll_RClear(DBN_SYSTBD, G_LB)
    Call ResetBuf(DBN_SYSTBD)
End Sub
