	Option Explicit
'==========================================================================
'   JDNTRA.DBM   óg                       UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_JDNTRA
    DATNO          As String * 10    '`[ÇNO.           0000000000          
    DATKB          As String * 1     '`[íæª          0                   
    DENKB          As String * 1     '`[æª              0                   
    JDNNO          As String * 8     'ó`[Ô          00000000            
    LINNO          As String * 3     'sÔ                000                 
    RECNO          As String * 10    'R[hÇNO.       0000000000          
    JDNDT          As String * 8     'ó`[út          YYYY/MM/DD          
    NOKDT          As String * 8     '[ú                  YYYY/MM/DD          
    JHDNO          As String * 8     'ó­NO              000000              
    ZKTKB          As String * 1     'æøæª              0                   
    SMADT          As String * 8     'o÷út            YYYY/MM/DD          
    TOKCD          As String * 6     '¾ÓæR[h          000000              
    NHSCD          As String * 6     '[iæR[h          !@@@@@@             
    TANCD          As String * 4     'SÒR[h          0000                
    TOKSEICD       As String * 6     '¿æR[h          000000              
    SOUCD          As String * 3     'qÉR[h            000                 
    HINCD          As String * 13    '¤iR[h            !@@@@@@@@@@@@@      
    HINNMA         As String * 20    '¤i¼P                                  
    HINNMB         As String * 20    '¤i¼Q                                  
    UNTCD          As String * 2     'PÊR[h            00                  
    UNTNM          As String * 4     'PÊ¼                                    
    IRISU          As Currency       'ü                  ###,###             
    CASSU          As Currency       'P[X              ###,###             
    UODSU          As Currency       'óÊ              ###,##0.00;;#       
    UODTK          As Currency       'óP¿              ##,###,##0.00;;#    
    GNKTK          As Currency       '´¿P¿              ##,###,##0.00;;#    
    GNKKN          As Currency       '´¿àz              #,###,###,###,###   
    UODKN          As Currency       'óàz              #,###,###,###       
    ZAIKB          As String * 1     'ÝÉÇæª          0                   
    LINCMA         As String * 20    '¾×õlP                                
    LINCMB         As String * 20    '¾×õlQ                                
    HINZEIKB       As String * 1     '¤iÁïÅæª        0                   
    ZEIRT          As Currency       'ÁïÅ¦              ##0.00;;#           
    HINNMMKB       As String * 1     '¼Ì}jAæª    0                   
    ZEIRNKKB       As String * 1     'ÁïÅN          0                   
    MAKCD          As String * 6     '[J[R[h        000000              
    HINKB          As String * 1     '¤iæª              0                   
    MRPKB          As String * 1     'WJæª              0                   
    HRTDD          As String * 2     '­[h^C      99                  
    ORTDD          As String * 2     'o×[h^C      99                  
    LSTID          As String * 7     '`[íÊ              !@@@@@@             
    TOKMSTKB       As String * 1     '}X^æª(¾Óæ)    0                   
    NHSMSTKB       As String * 1     '}X^æª([iæ)    0                   
    TANMSTKB       As String * 1     '}X^æª(SÒ)    0                   
    HINMSTKB       As String * 1     '}X^æª(¤i)      0                   
    EDIJANCD       As String * 13    'dchi`mR[h                        
    EDIHNNMA       As String * 25    'dch¤i¼P                            
    EDIHNNMB       As String * 25    'dch¤i¼Q                            
    EDIUNTNM       As String * 1     'dchPÊ                                
    EDIURITK       As Currency       'dchÌP¿        #,###,##0           
    EDIHINCD       As String * 8     'dchè¤iR[h                      
    JDNKB          As String * 1     'óæª              0                   
    OPEID          As String * 8     'ÅIìÆÒR[h      !@@@@@@@@           
    CLTID          As String * 5     'NCAghc      !@@@@@              
    WRTTM          As String * 6     'À²Ñ½ÀÝÌß(Ô)        9(06)               
    WRTDT          As String * 8     'À²Ñ½ÀÝÌß(út)        YYYY/MM/DD          
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
