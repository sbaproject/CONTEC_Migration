	Option Explicit
'==========================================================================
'   JDNTRA.DBM   �󒍃g����                       UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_JDNTRA
    DATNO          As String * 10    '�`�[�Ǘ�NO.           0000000000          
    DATKB          As String * 1     '�`�[�폜�敪          0                   
    DENKB          As String * 1     '�`�[�敪              0                   
    JDNNO          As String * 8     '�󒍓`�[�ԍ�          00000000            
    LINNO          As String * 3     '�s�ԍ�                000                 
    RECNO          As String * 10    '���R�[�h�Ǘ�NO.       0000000000          
    JDNDT          As String * 8     '�󒍓`�[���t          YYYY/MM/DD          
    NOKDT          As String * 8     '�[��                  YYYY/MM/DD          
    JHDNO          As String * 8     '�󔭒�NO              000000              
    ZKTKB          As String * 1     '����敪              0                   
    SMADT          As String * 8     '�o�������t            YYYY/MM/DD          
    TOKCD          As String * 6     '���Ӑ�R�[�h          000000              
    NHSCD          As String * 6     '�[�i��R�[�h          !@@@@@@             
    TANCD          As String * 4     '�S���҃R�[�h          0000                
    TOKSEICD       As String * 6     '������R�[�h          000000              
    SOUCD          As String * 3     '�q�ɃR�[�h            000                 
    HINCD          As String * 13    '���i�R�[�h            !@@@@@@@@@@@@@      
    HINNMA         As String * 20    '���i���P                                  
    HINNMB         As String * 20    '���i���Q                                  
    UNTCD          As String * 2     '�P�ʃR�[�h            00                  
    UNTNM          As String * 4     '�P�ʖ�                                    
    IRISU          As Currency       '����                  ###,###             
    CASSU          As Currency       '�P�[�X��              ###,###             
    UODSU          As Currency       '�󒍐���              ###,##0.00;;#       
    UODTK          As Currency       '�󒍒P��              ##,###,##0.00;;#    
    GNKTK          As Currency       '�����P��              ##,###,##0.00;;#    
    GNKKN          As Currency       '�������z              #,###,###,###,###   
    UODKN          As Currency       '�󒍋��z              #,###,###,###       
    ZAIKB          As String * 1     '�݌ɊǗ��敪          0                   
    LINCMA         As String * 20    '���ה��l�P                                
    LINCMB         As String * 20    '���ה��l�Q                                
    HINZEIKB       As String * 1     '���i����ŋ敪        0                   
    ZEIRT          As Currency       '����ŗ�              ##0.00;;#           
    HINNMMKB       As String * 1     '���̃}�j���A���敪    0                   
    ZEIRNKKB       As String * 1     '����Ń����N          0                   
    MAKCD          As String * 6     '���[�J�[�R�[�h        000000              
    HINKB          As String * 1     '���i�敪              0                   
    MRPKB          As String * 1     '�W�J�敪              0                   
    HRTDD          As String * 2     '�������[�h�^�C��      99                  
    ORTDD          As String * 2     '�o�׃��[�h�^�C��      99                  
    LSTID          As String * 7     '�`�[���              !@@@@@@             
    TOKMSTKB       As String * 1     '�}�X�^�敪(���Ӑ�)    0                   
    NHSMSTKB       As String * 1     '�}�X�^�敪(�[�i��)    0                   
    TANMSTKB       As String * 1     '�}�X�^�敪(�S����)    0                   
    HINMSTKB       As String * 1     '�}�X�^�敪(���i)      0                   
    EDIJANCD       As String * 13    '�d�c�h�i�`�m�R�[�h                        
    EDIHNNMA       As String * 25    '�d�c�h���i���P                            
    EDIHNNMB       As String * 25    '�d�c�h���i���Q                            
    EDIUNTNM       As String * 1     '�d�c�h�P��                                
    EDIURITK       As Currency       '�d�c�h�̔��P��        #,###,##0           
    EDIHINCD       As String * 8     '�d�c�h���菤�i�R�[�h                      
    JDNKB          As String * 1     '�󒍋敪              0                   
    OPEID          As String * 8     '�ŏI��Ǝ҃R�[�h      !@@@@@@@@           
    CLTID          As String * 5     '�N���C�A���g�h�c      !@@@@@              
    WRTTM          As String * 6     '��ѽ����(����)        9(06)               
    WRTDT          As String * 8     '��ѽ����(���t)        YYYY/MM/DD          
End Type
Global DB_JDNTRA As TYPE_DB_JDNTRA
Global DBN_JDNTRA As Integer
' Index1( DATNO + LINNO )
' Index2( DATKB + DENKB + JDNNO + LINNO )
' Index3( SMADT )
' Index4( DATKB + TOKCD + NOKDT + JDNDT + JDNNO + LINNO )
' Index5( DATKB + HINCD + NOKDT + JDNDT + JDNNO + LINNO )

Sub JDNTRA_RClear()
DIM TmpStat
    TmpStat = Dll_RClear(DBN_JDNTRA, G_LB)
    Call ResetBuf(DBN_JDNTRA)
End Sub
