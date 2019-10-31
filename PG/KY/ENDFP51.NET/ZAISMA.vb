Option Strict Off
Option Explicit On
Module ZAISMA_DBM
    '==========================================================================
    '   ZAISMA.DBM   在庫月次サマリ                   UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    'Structure TYPE_DB_ZAISMA
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public SOUCD() As Char '倉庫コード            000                 
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public HINCD() As Char '製品コード            !@@@@@@@@@@         
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(1),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1)> Public SISNKB() As Char '資産元区分            0                   
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public SOUTRICD() As Char '取引先コード          !@@@@@@@@@@         
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public SMADT() As Char '経理締日付            YYYY/MM/DD          
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public LSTSREDT() As Char '最終仕入日付          YYYY/MM/DD          
    '	Dim LSTSRETK As Decimal '最終仕入単価          ###,###,##0.0000;;# 
    '	<VBFixedArray(9)> Dim SMAURISU() As Decimal '売上集計数量          ##,###,###,##0.00;;#
    '	<VBFixedArray(9)> Dim SMASRESU() As Decimal '仕入集計数量          ##,###,###,##0.00;;#
    '	<VBFixedArray(9)> Dim SMADLVSU() As Decimal '出庫集計数量          ##,###,###,##0.00;;#
    '	<VBFixedArray(9)> Dim SMASTKSU() As Decimal '入庫集計数量          ##,###,###,##0.00;;#
    '	Dim ADJSU As Decimal '調整数量              ##,###,###,##0.00;;#
    '	<VBFixedArray(9)> Dim SMAURIKN() As Decimal '売上集計金額          ###,###,##0.0000;;# 
    '	<VBFixedArray(9)> Dim SMAGNKKN() As Decimal '原価集計金額          ###,###,##0.0000;;# 
    '	<VBFixedArray(9)> Dim SMASREKN() As Decimal '仕入集計金額          ###,###,##0.0000;;# 
    '	<VBFixedArray(9)> Dim SMADLVKN() As Decimal '出庫集計金額          ###,###,##0.0000;;# 
    '	<VBFixedArray(9)> Dim SMASTKKN() As Decimal '入庫集計金額          ###,###,##0.0000;;# 
    '	Dim ADJKN As Decimal '調整金額              ###,###,##0.0000;;# 
    '       'UPGRADE_ISSUE: 宣言の型がサポートされていません: 固定長文字列の配列 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="934BD4FF-1FF9-47BD-888F-D411E47E78FA"' をクリックしてください。
    '       Dim TNADT() As String '棚卸日付              YYYY/MM/DD          
    '       <VBFixedArray(1)> Dim TNASU() As Decimal '棚卸数量              #,###,##0.00;;#     
    '	<VBFixedArray(1)> Dim TNATK() As Decimal '棚卸単価              ###,###,##0.00;;#   
    '	<VBFixedArray(1)> Dim TNAKN() As Decimal '棚卸金額              ##,###,###,###      
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public OPEID() As Char '最終作業者コード      !@@@@@@@@           
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(5),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=5)> Public CLTID() As Char 'クライアントＩＤ      !@@@@@              
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)               
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD          
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTFSTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(登録時間)    9(06)               
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '	<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTFSTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(登録日)      YYYY/MM/DD          

    '	'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
    '	Public Sub Initialize()
    '		ReDim SMAURISU(9)
    '		ReDim SMASRESU(9)
    '		ReDim SMADLVSU(9)
    '		ReDim SMASTKSU(9)
    '		ReDim SMAURIKN(9)
    '		ReDim SMAGNKKN(9)
    '		ReDim SMASREKN(9)
    '		ReDim SMADLVKN(9)
    '		ReDim SMASTKKN(9)
    '		ReDim TNASU(1)
    '		ReDim TNATK(1)
    '		ReDim TNAKN(1)
    '	End Sub
    'End Structure
    'UPGRADE_WARNING: 構造体 DB_ZAISMA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    'Public DB_ZAISMA As TYPE_DB_ZAISMA
    'Public DBN_ZAISMA As Short
    ' Index1( SOUCD + HINCD + SMADT )
    ' Index2( SMADT + SOUCD + HINCD )

    Sub ZAISMA_RClear()
		Dim TmpStat As Object
        'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト TmpStat の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/10/31 DEL START
        'TmpStat = Dll_RClear(DBN_ZAISMA, G_LB)
        'Call ResetBuf(DBN_ZAISMA)
        '2019/10/31 DEL E N D
    End Sub
End Module