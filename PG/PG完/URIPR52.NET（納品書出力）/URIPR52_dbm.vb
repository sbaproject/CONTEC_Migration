Option Strict Off
Option Explicit On
Module URIPR52_DBM
    '==========================================================================
    '   URIPR52.DBM  �[�i�����[�N                     UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    Structure TYPE_DB_URIPR52
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public RPTCLTID() As Char 'RPT�pCLIENTID                             
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public UDNNO() As Char '����`�[�ԍ�          0000000000          
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(3), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=3)> Public LINNO() As Char '�s�ԍ�                000                 
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public DENDT() As Char '�`�[���t              YYYY/MM/DD          
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public TOKCD() As Char '���Ӑ�R�[�h          !@@@@@@@@@@         
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(40), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=40)> Public NHSRN() As Char '�[���旪��                                
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public NHSNMA() As Char '�[���於�̂P                              
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public NHSNMB() As Char '�[���於�̂Q                              
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public NHSZP() As Char '�[����X�֔ԍ�        X(08)               
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public NHSADA() As Char '�[����Z���P                              
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public NHSADB() As Char '�[����Z���Q                              
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public NHSADC() As Char '�[����Z���R                              
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public NHSTL() As Char '�[����d�b�ԍ�        X(12)               
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public NHSFX() As Char '�[����e�`�w�ԍ�      X(12)               
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public NHSCD() As Char '�[����R�[�h          !@@@@@@@@@@         
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public FDNNO() As Char '�`�[�Ǘ�NO.           0000000000          
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public PRTDT() As Char '�o�͓�                YYYY/MM/DD          
        Dim PRTPAGE As Decimal '�y�[�W��                                  
        Dim MAXPAGE As Decimal 'MAX�y�[�W��                               
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public BUMCD() As Char '����R�[�h            000000              
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(40), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=40)> Public BUMNM() As Char '���喼                                    
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public BMNZP() As Char '�o�׌��X�֔ԍ�                            
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public BMNADA() As Char '�o�׌��Z���P                              
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public BMNADB() As Char '�o�׌��Z���Q                              
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public BMNADC() As Char '�o�׌��Z���R                              
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public BMNTL() As Char '�o�׌��d�b�ԍ�                            
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public BMNFX() As Char '�o�׌��e�`�w�ԍ�                          
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(50), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=50)> Public BMNURL() As Char '�o�׌��t�q�k                              
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(40), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=40)> Public EBUMNM() As Char '�c�ƕ��喼                                
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public TANCD() As Char '�S���҃R�[�h          000000              
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(40), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=40)> Public TANNM() As Char '�S���Җ�                                  
        '2019.04.08 chg START
        'UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim TOKJDNNO(21) As String*23 '�q�撍���ԍ�       
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim HINCD(21) As String*10 '���i�R�[�h            !@@@@@@@@@@         
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim HINNMA(21) As String*50 '�^��                                      
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim HINNMB(21) As String*50 '���i���P                                  
        '<VBFixedArray(21)> Dim URISU() As Decimal '���㐔��              #,###,##0.00;;#     
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim UNTNM(21) As String*4 '�P�ʖ�
        '�q�撍���ԍ�   
        <VBFixedStringAttribute(23)> Dim TOKJDNNO As String()
        '���i�R�[�h 
        <VBFixedStringAttribute(10)> Dim HINCD As String()
        '�^��  
        <VBFixedStringAttribute(50)> Dim HINNMA As String()
        '���i���P
        <VBFixedStringAttribute(50)> Dim HINNMB As String()
        '���㐔��
        <VBFixedArray(21)> Dim URISU() As Decimal
        '�P�ʖ�
        <VBFixedStringAttribute(4)> Dim UNTNM As String()
        '2019.04.08 chg END
        <VBFixedArray(21)> Dim URITK() As Decimal '�P��                  ###,###,##0.0000;;# 
        <VBFixedArray(21)> Dim URIKN() As Decimal '������z              ###,###,##0.0000;;# 
        <VBFixedArray(21)> Dim UZEKN() As Decimal '����ŋ��z            ##,###,###,###      
        '2019.04.08 chg START��
        'UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim PRTJDNNO(21) As String*15 '����󒍔ԍ�                              
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim PRTLINNO(21) As String*3 '����s�ԍ�                                
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim LINCMA(21) As String*20 '���ה��l�P                                
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim LINCMB(21) As String*20 '���ה��l�Q                                
        ''UPGRADE_ISSUE: �錾�̌^���T�|�[�g����Ă��܂���: �Œ蒷������̔z�� �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' ���N���b�N���Ă��������B
        'Dim TOKJDNBC(21) As String*26 '�q�撍���ԍ�  
        '����󒍔ԍ�   
        <VBFixedStringAttribute(15)> Dim PRTJDNNO As String()
        '����s�ԍ� 
        <VBFixedStringAttribute(3)> Dim PRTLINNO As String()
        '���ה��l�P  
        <VBFixedStringAttribute(20)> Dim LINCMA As String()
        '���ה��l�Q
        <VBFixedStringAttribute(20)> Dim LINCMB As String()
        '�q�撍���ԍ�
        <VBFixedStringAttribute(26)> Dim TOKJDNBC As String()
        '2019.04.08 chg END
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(40), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=40)> Public DENCM() As Char '���l                                      
        Dim SBAURIKN As Decimal '������z(�{�̍��v)    ###,###,##0.0000;;# 
        Dim SBAUZEKN As Decimal '������z(����Ŋz)    #,###,###,###       
        Dim SBAUZKKN As Decimal '������z(�`�[�v)      ###,###,##0.0000;;# 
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public PRTKBNM() As Char '�Ĕ��s                                    
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public SIPPAI() As Char '���s���s              !@                  
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public PRTPATN() As Char '����p�^�[��          0                   
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public SORTCD() As Char '����R�[�h                                
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public HDHAKKOU() As Char '���s�敪              0                   
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public HDKINKYU() As Char '�ً}�o��              0                   
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public HDTANCD() As Char '�S���҃R�[�h          000000              
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public HDBUMCD() As Char '����R�[�h            000000              
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public HDDENDT() As Char '�`�[���t              YYYY/MM/DD          
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public HDJDNNO() As Char '�󒍔ԍ�              0000000000          
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public HDTOKCD() As Char '���Ӑ�R�[�h          !@@@@@@@@@@         
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=2)> Public HDJDNTKB() As Char '�󒍎���敪          00                  
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public HDPRTKB() As Char '����敪              0                   
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM() As Char '��ѽ����(����)        9(06)               
        'UPGRADE_WARNING: �Œ蒷������̃T�C�Y�̓o�b�t�@�ɍ��킹��K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' ���N���b�N���Ă��������B
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT() As Char '��ѽ����(���t)        YYYY/MM/DD          

        'UPGRADE_TODO: ���̍\���̂̃C���X�^���X������������ɂ́A"Initialize" ���Ăяo���Ȃ���΂Ȃ�܂���B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' ���N���b�N���Ă��������B
        Public Sub Initialize()
            ReDim URISU(21)
            ReDim URITK(21)
            ReDim URIKN(21)
            ReDim UZEKN(21)
            '2019.04.15 add start
            ReDim TOKJDNNO(21)
            ReDim HINCD(21)
            ReDim HINNMA(21)
            ReDim HINNMB(21)
            ReDim UNTNM(21)
            ReDim PRTJDNNO(21)
            ReDim PRTLINNO(21)
            ReDim LINCMA(21)
            ReDim LINCMB(21)
            ReDim TOKJDNBC(21)
            '2019.04.15 add end
        End Sub
    End Structure
    'UPGRADE_WARNING: �\���� DB_URIPR52 �̔z��́A�g�p����O�ɏ���������K�v������܂��B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' ���N���b�N���Ă��������B
    Public DB_URIPR52 As TYPE_DB_URIPR52
    Public DBN_URIPR52 As Short
    ' Index1( RPTCLTID + UDNNO + LINNO + SORTCD )

    Sub URIPR52_RClear()
        Dim TmpStat As Object
        'UPGRADE_WARNING: �I�u�W�F�N�g G_LB �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        'UPGRADE_WARNING: �I�u�W�F�N�g TmpStat �̊���v���p�e�B�������ł��܂���ł����B �ڍׂɂ��ẮA'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' ���N���b�N���Ă��������B
        '2019.04.08 DEL START
        'TmpStat = Dll_RClear(DBN_URIPR52, G_LB)
        '2019.04.08 DEL END
        Call ResetBuf(DBN_URIPR52)
    End Sub

    '2019,04.17 add start
    Public Sub InsertURIPR52(ByVal pDB_URIPR52 As TYPE_DB_URIPR52)
        Dim strSQL As String
        Dim wCount As Integer
        strSQL = ""
        strSQL = strSQL & "insert into CNT_USR9.URIPR52 values("
        strSQL = strSQL & "'" & pDB_URIPR52.RPTCLTID & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.UDNNO & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.LINNO & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.DENDT & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.TOKCD & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.NHSRN & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.NHSNMA & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.NHSNMB & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.NHSZP & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.NHSADA & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.NHSADB & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.NHSADC & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.NHSTL & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.NHSFX & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.NHSCD & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.FDNNO & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.PRTDT & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.PRTPAGE & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.MAXPAGE & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.BUMCD & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.BUMNM & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.BMNZP & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.BMNADA & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.BMNADB & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.BMNADC & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.BMNTL & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.BMNFX & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.BMNURL & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.EBUMNM & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.TANCD & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.TANNM & "', "

        wCount = pDB_URIPR52.TOKJDNNO.Length
        For i As Integer = 0 To 21
            If i <= wCount - 1 Then
                strSQL = strSQL & "'" & pDB_URIPR52.TOKJDNNO(i) & "', "
            Else
                strSQL = strSQL & "' ', "
            End If
        Next
        For i As Integer = 0 To 21
            If i <= wCount - 1 Then
                strSQL = strSQL & "'" & pDB_URIPR52.HINCD(i) & "', "
            Else
                strSQL = strSQL & "' ', "
            End If
        Next
        For i As Integer = 0 To 21
            If i <= wCount - 1 Then
                strSQL = strSQL & "'" & pDB_URIPR52.HINNMA(i) & "', "
            Else
                strSQL = strSQL & "' ', "
            End If
        Next
        For i As Integer = 0 To 21
            If i <= wCount - 1 Then
                strSQL = strSQL & "'" & pDB_URIPR52.HINNMB(i) & "', "
            Else
                strSQL = strSQL & "' ', "
            End If
        Next
        For i As Integer = 0 To 21
            If i <= wCount - 1 Then
                strSQL = strSQL & pDB_URIPR52.URISU(i) & ", "
            Else
                strSQL = strSQL & "0, "
            End If
        Next
        For i As Integer = 0 To 21
            If i <= wCount - 1 Then
                strSQL = strSQL & "'" & pDB_URIPR52.UNTNM(i) & "', "
            Else
                strSQL = strSQL & "' ', "
            End If
        Next
        For i As Integer = 0 To 21
            If i <= wCount - 1 Then
                strSQL = strSQL & pDB_URIPR52.URITK(i) & ", "
            Else
                strSQL = strSQL & "0, "
            End If
        Next
        For i As Integer = 0 To 21
            If i <= wCount - 1 Then
                strSQL = strSQL & pDB_URIPR52.URIKN(i) & ", "
            Else
                strSQL = strSQL & "0, "
            End If
        Next
        For i As Integer = 0 To 21
            If i <= wCount - 1 Then
                strSQL = strSQL & pDB_URIPR52.UZEKN(i) & ", "
            Else
                strSQL = strSQL & "0, "
            End If
        Next
        For i As Integer = 0 To 21
            If i <= wCount - 1 Then
                strSQL = strSQL & "'" & pDB_URIPR52.PRTJDNNO(i) & "', "
            Else
                strSQL = strSQL & "' ', "
            End If
        Next
        For i As Integer = 0 To 21
            If i <= wCount - 1 Then
                strSQL = strSQL & "'" & pDB_URIPR52.PRTLINNO(i) & "', "
            Else
                strSQL = strSQL & "' ', "
            End If
        Next
        For i As Integer = 0 To 21
            If i <= wCount - 1 Then
                strSQL = strSQL & "'" & pDB_URIPR52.LINCMA(i) & "', "
            Else
                strSQL = strSQL & "' ', "
            End If
        Next
        For i As Integer = 0 To 21
            If i <= wCount - 1 Then
                strSQL = strSQL & "'" & pDB_URIPR52.LINCMB(i) & "', "
            Else
                strSQL = strSQL & "' ', "
            End If
        Next
        For i As Integer = 0 To 21
            If i <= wCount - 1 Then
                strSQL = strSQL & "'" & pDB_URIPR52.TOKJDNBC(i) & "', "
            Else
                strSQL = strSQL & "' ', "
            End If
        Next
        strSQL = strSQL & "'" & pDB_URIPR52.DENCM & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.SBAURIKN & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.SBAUZEKN & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.SBAUZKKN & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.PRTKBNM & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.SIPPAI & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.PRTPATN & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.SORTCD & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.HDHAKKOU & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.HDKINKYU & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.HDTANCD & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.HDBUMCD & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.HDDENDT & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.HDJDNNO & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.HDTOKCD & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.HDJDNTKB & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.HDPRTKB & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.WRTTM & "', "
        strSQL = strSQL & "'" & pDB_URIPR52.WRTDT & "')"
        DB_Execute(strSQL)
    End Sub
    '2019,04.17 add end
End Module