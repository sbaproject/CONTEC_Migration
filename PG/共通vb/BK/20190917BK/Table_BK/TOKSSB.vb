Option Strict Off
Option Explicit On
Module TOKSSB_DBM
    '==========================================================================
    '   TOKSSB.DBM   �O�󐿋��T�}��                   UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_TOKSSB
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public TOKCD As String '���Ӑ�R�[�h          !@@@@@@@@@@         
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public SSADT As String '�����t                YYYY/MM/DD          
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public KESDT As String '���ϓ��t              YYYY/MM/DD          
    '       <VBFixedArray(9)> Dim SSAURIKN() As Decimal '����W�v���z          ###,###,###,###     
    '       Dim SSAUZEKN As Decimal '�������ŋ��z        ###,###,###,###     
    '       <VBFixedArray(2)> Dim SZAKZIKN() As Decimal '�����N�ʐō��ېŋ��z  ###,###,###,###     
    '       <VBFixedArray(2)> Dim SZAKZOKN() As Decimal '�����N�ʐŔ��ېŋ��z  ###,###,###,###     
    '       <VBFixedArray(2)> Dim SZBKZIKN() As Decimal '�����N�ʐō��ېŋ��z  ###,###,###,###     
    '       <VBFixedArray(2)> Dim SZBKZOKN() As Decimal '�����N�ʐŔ��ېŋ��z  ###,###,###,###     
    '       <VBFixedArray(9)> Dim SSANYUKN() As Decimal '�����W�v���z          ###,###,###,###     
    '       Dim KSKNYKKN As Decimal '���������z                                
    '       Dim KSKZANKN As Decimal '���������z�c          ###,###,###,###     
    '       Dim SSADENSU As Decimal '�`�[����              ###,###             
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public DATNO As String '�`�[�Ǘ�NO.           0000000000          
    '	'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM As String '��ѽ����(����)        9(06)               
    '       'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT As String '��ѽ����(���t)        YYYY/MM/DD          

    '	'UPGRADE_TODO: ���̍\���̂̃C���X�^���X������������ɂ́A"Initialize" ���Ăяo���Ȃ���΂Ȃ�܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' ���N���b�N���Ă��������B
    '	Public Sub Initialize()
    '		ReDim SSAURIKN(9)
    '		ReDim SZAKZIKN(2)
    '		ReDim SZAKZOKN(2)
    '		ReDim SZBKZIKN(2)
    '		ReDim SZBKZOKN(2)
    '		ReDim SSANYUKN(9)
    '	End Sub
    'End Structure
    ''UPGRADE_WARNING: �\���� DB_TOKSSB �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    'Public DB_TOKSSB As TYPE_DB_TOKSSB
    'Public DBN_TOKSSB As Short
    '20190611 del end
    
	' Index1( TOKCD + SSADT )
	' Index2( TOKCD + KESDT )
	' Index3( SSADT + TOKCD )
	
	Sub TOKSSB_RClear()
		Dim TmpStat As Object
		'UPGRADE_WARNING: �I�u�W�F�N�g G_LB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
		'UPGRADE_WARNING: �I�u�W�F�N�g TmpStat �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019/03/25�@��
        '      TmpStat = Dll_RClear(DBN_TOKSSB, G_LB)
        '      Call ResetBuf(DBN_TOKSSB)
        '2019/03/25�@��
    End Sub
End Module