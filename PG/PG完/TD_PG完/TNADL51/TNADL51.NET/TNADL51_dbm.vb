Option Strict Off
Option Explicit On
Module TNADL51_DBM
	'==========================================================================
	'   TNADL51.DBM  �݌ɏƉ�i���i�ʁj���[�N         UPD.EXE Ver 3, 0, 1, 2  =
	'==========================================================================
	Structure TYPE_DB_TNADL51
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public SOUCD() As Char '�q�ɃR�[�h            000                 
		'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public SOUNM() As Char '�q�ɖ�                                    
		Dim SMZZAISU As Decimal '�I������              ##,###,##0.00;;#    
		Dim SMAINPSU As Decimal '���׏W�v����          ##,###,##0.00;;#    
		Dim SMAOUTSU As Decimal '�I������              ##,###,##0.00;;#    
		Dim ZAISAISU As Decimal '�I�����ِ���          ###,##0.00;;#       
		Dim SMAZAISU As Decimal '�����݌ɐ�            ##,###,##0.00;;#    
		Dim RELZAISU As Decimal '���ݍ݌ɐ�            #,###,##0.00;;#     
	End Structure
	Public DB_TNADL51 As TYPE_DB_TNADL51
	Public DBN_TNADL51 As Short
	' Index1( SOUCD )
	
	Sub TNADL51_RClear()
		Dim TmpStat As Object
        'UPGRADE_WARNING: �I�u�W�F�N�g G_LB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g TmpStat �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '20190705 DELL START
        'TmpStat = Dll_RClear(DBN_TNADL51, G_LB)
        'Call ResetBuf(DBN_TNADL51)
        '20190705 DELL END
    End Sub
End Module