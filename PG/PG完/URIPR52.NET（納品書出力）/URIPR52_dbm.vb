Option Strict Off
Option Explicit On
Module URIPR52_DBM
    '==========================================================================
    '   URIPR52.DBM  納品書ワーク                     UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    Structure TYPE_DB_URIPR52
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(5), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=5)> Public RPTCLTID() As Char 'RPT用CLIENTID                             
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public UDNNO() As Char '売上伝票番号          0000000000          
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(3), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=3)> Public LINNO() As Char '行番号                000                 
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public DENDT() As Char '伝票日付              YYYY/MM/DD          
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public TOKCD() As Char '得意先コード          !@@@@@@@@@@         
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(40), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=40)> Public NHSRN() As Char '納入先略称                                
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public NHSNMA() As Char '納入先名称１                              
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public NHSNMB() As Char '納入先名称２                              
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public NHSZP() As Char '納入先郵便番号        X(08)               
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public NHSADA() As Char '納入先住所１                              
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public NHSADB() As Char '納入先住所２                              
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public NHSADC() As Char '納入先住所３                              
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public NHSTL() As Char '納入先電話番号        X(12)               
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public NHSFX() As Char '納入先ＦＡＸ番号      X(12)               
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public NHSCD() As Char '納入先コード          !@@@@@@@@@@         
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public FDNNO() As Char '伝票管理NO.           0000000000          
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public PRTDT() As Char '出力日                YYYY/MM/DD          
        Dim PRTPAGE As Decimal 'ページ数                                  
        Dim MAXPAGE As Decimal 'MAXページ数                               
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public BUMCD() As Char '部門コード            000000              
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(40), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=40)> Public BUMNM() As Char '部門名                                    
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public BMNZP() As Char '出荷元郵便番号                            
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public BMNADA() As Char '出荷元住所１                              
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public BMNADB() As Char '出荷元住所２                              
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(60), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=60)> Public BMNADC() As Char '出荷元住所３                              
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public BMNTL() As Char '出荷元電話番号                            
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public BMNFX() As Char '出荷元ＦＡＸ番号                          
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(50), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=50)> Public BMNURL() As Char '出荷元ＵＲＬ                              
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(40), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=40)> Public EBUMNM() As Char '営業部門名                                
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public TANCD() As Char '担当者コード          000000              
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(40), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=40)> Public TANNM() As Char '担当者名                                  
        '2019.04.08 chg START
        'UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim TOKJDNNO(21) As String*23 '客先注文番号       
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim HINCD(21) As String*10 '製品コード            !@@@@@@@@@@         
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim HINNMA(21) As String*50 '型式                                      
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim HINNMB(21) As String*50 '商品名１                                  
        '<VBFixedArray(21)> Dim URISU() As Decimal '売上数量              #,###,##0.00;;#     
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim UNTNM(21) As String*4 '単位名
        '客先注文番号   
        <VBFixedStringAttribute(23)> Dim TOKJDNNO As String()
        '製品コード 
        <VBFixedStringAttribute(10)> Dim HINCD As String()
        '型式  
        <VBFixedStringAttribute(50)> Dim HINNMA As String()
        '商品名１
        <VBFixedStringAttribute(50)> Dim HINNMB As String()
        '売上数量
        <VBFixedArray(21)> Dim URISU() As Decimal
        '単位名
        <VBFixedStringAttribute(4)> Dim UNTNM As String()
        '2019.04.08 chg END
        <VBFixedArray(21)> Dim URITK() As Decimal '単価                  ###,###,##0.0000;;# 
        <VBFixedArray(21)> Dim URIKN() As Decimal '売上金額              ###,###,##0.0000;;# 
        <VBFixedArray(21)> Dim UZEKN() As Decimal '消費税金額            ##,###,###,###      
        '2019.04.08 chg START仮
        'UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim PRTJDNNO(21) As String*15 '印刷受注番号                              
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim PRTLINNO(21) As String*3 '印刷行番号                                
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim LINCMA(21) As String*20 '明細備考１                                
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim LINCMB(21) As String*20 '明細備考２                                
        ''UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
        'Dim TOKJDNBC(21) As String*26 '客先注文番号  
        '印刷受注番号   
        <VBFixedStringAttribute(15)> Dim PRTJDNNO As String()
        '印刷行番号 
        <VBFixedStringAttribute(3)> Dim PRTLINNO As String()
        '明細備考１  
        <VBFixedStringAttribute(20)> Dim LINCMA As String()
        '明細備考２
        <VBFixedStringAttribute(20)> Dim LINCMB As String()
        '客先注文番号
        <VBFixedStringAttribute(26)> Dim TOKJDNBC As String()
        '2019.04.08 chg END
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(40), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=40)> Public DENCM() As Char '備考                                      
        Dim SBAURIKN As Decimal '売上金額(本体合計)    ###,###,##0.0000;;# 
        Dim SBAUZEKN As Decimal '売上金額(消費税額)    #,###,###,###       
        Dim SBAUZKKN As Decimal '売上金額(伝票計)      ###,###,##0.0000;;# 
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public PRTKBNM() As Char '再発行                                    
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public SIPPAI() As Char '発行失敗              !@                  
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public PRTPATN() As Char '印刷パターン          0                   
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(20), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=20)> Public SORTCD() As Char '整列コード                                
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public HDHAKKOU() As Char '発行区分              0                   
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public HDKINKYU() As Char '緊急出荷              0                   
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public HDTANCD() As Char '担当者コード          000000              
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public HDBUMCD() As Char '部門コード            000000              
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public HDDENDT() As Char '伝票日付              YYYY/MM/DD          
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public HDJDNNO() As Char '受注番号              0000000000          
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(10), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=10)> Public HDTOKCD() As Char '得意先コード          !@@@@@@@@@@         
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(2), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=2)> Public HDJDNTKB() As Char '受注取引区分          00                  
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(1), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=1)> Public HDPRTKB() As Char '印刷区分              0                   
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)               
        'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
        <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD          

        'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
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
    'UPGRADE_WARNING: 構造体 DB_URIPR52 の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    Public DB_URIPR52 As TYPE_DB_URIPR52
    Public DBN_URIPR52 As Short
    ' Index1( RPTCLTID + UDNNO + LINNO + SORTCD )

    Sub URIPR52_RClear()
        Dim TmpStat As Object
        'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト TmpStat の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
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