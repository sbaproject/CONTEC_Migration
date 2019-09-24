	Option Explicit
'==========================================================================
'   JDNTRA.DBM   受注トラン                       UPD.EXE Ver 3, 0, 1, 2  =
'==========================================================================
Type TYPE_DB_JDNTRA
    DATNO          As String * 10    '伝票管理NO.           0000000000          
    DATKB          As String * 1     '伝票削除区分          0                   
    DENKB          As String * 1     '伝票区分              0                   
    JDNNO          As String * 8     '受注伝票番号          00000000            
    LINNO          As String * 3     '行番号                000                 
    RECNO          As String * 10    'レコード管理NO.       0000000000          
    JDNDT          As String * 8     '受注伝票日付          YYYY/MM/DD          
    NOKDT          As String * 8     '納期                  YYYY/MM/DD          
    JHDNO          As String * 8     '受発注NO              000000              
    ZKTKB          As String * 1     '取引区分              0                   
    SMADT          As String * 8     '経理締日付            YYYY/MM/DD          
    TOKCD          As String * 6     '得意先コード          000000              
    NHSCD          As String * 6     '納品先コード          !@@@@@@             
    TANCD          As String * 4     '担当者コード          0000                
    TOKSEICD       As String * 6     '請求先コード          000000              
    SOUCD          As String * 3     '倉庫コード            000                 
    HINCD          As String * 13    '商品コード            !@@@@@@@@@@@@@      
    HINNMA         As String * 20    '商品名１                                  
    HINNMB         As String * 20    '商品名２                                  
    UNTCD          As String * 2     '単位コード            00                  
    UNTNM          As String * 4     '単位名                                    
    IRISU          As Currency       '入数                  ###,###             
    CASSU          As Currency       'ケース数              ###,###             
    UODSU          As Currency       '受注数量              ###,##0.00;;#       
    UODTK          As Currency       '受注単価              ##,###,##0.00;;#    
    GNKTK          As Currency       '原価単価              ##,###,##0.00;;#    
    GNKKN          As Currency       '原価金額              #,###,###,###,###   
    UODKN          As Currency       '受注金額              #,###,###,###       
    ZAIKB          As String * 1     '在庫管理区分          0                   
    LINCMA         As String * 20    '明細備考１                                
    LINCMB         As String * 20    '明細備考２                                
    HINZEIKB       As String * 1     '商品消費税区分        0                   
    ZEIRT          As Currency       '消費税率              ##0.00;;#           
    HINNMMKB       As String * 1     '名称マニュアル区分    0                   
    ZEIRNKKB       As String * 1     '消費税ランク          0                   
    MAKCD          As String * 6     'メーカーコード        000000              
    HINKB          As String * 1     '商品区分              0                   
    MRPKB          As String * 1     '展開区分              0                   
    HRTDD          As String * 2     '発注リードタイム      99                  
    ORTDD          As String * 2     '出荷リードタイム      99                  
    LSTID          As String * 7     '伝票種別              !@@@@@@             
    TOKMSTKB       As String * 1     'マスタ区分(得意先)    0                   
    NHSMSTKB       As String * 1     'マスタ区分(納品先)    0                   
    TANMSTKB       As String * 1     'マスタ区分(担当者)    0                   
    HINMSTKB       As String * 1     'マスタ区分(商品)      0                   
    EDIJANCD       As String * 13    'ＥＤＩＪＡＮコード                        
    EDIHNNMA       As String * 25    'ＥＤＩ商品名１                            
    EDIHNNMB       As String * 25    'ＥＤＩ商品名２                            
    EDIUNTNM       As String * 1     'ＥＤＩ単位                                
    EDIURITK       As Currency       'ＥＤＩ販売単価        #,###,##0           
    EDIHINCD       As String * 8     'ＥＤＩ相手商品コード                      
    JDNKB          As String * 1     '受注区分              0                   
    OPEID          As String * 8     '最終作業者コード      !@@@@@@@@           
    CLTID          As String * 5     'クライアントＩＤ      !@@@@@              
    WRTTM          As String * 6     'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)               
    WRTDT          As String * 8     'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD          
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
