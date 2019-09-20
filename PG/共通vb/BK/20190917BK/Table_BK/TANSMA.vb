Option Strict Off
Option Explicit On
Module TANSMA_DBM
    '==========================================================================
    '   TANSMA.DBM   担当者サマリ                     UPD.EXE Ver 3, 0, 1, 2  =
    '==========================================================================
    '20190611 del start
    '   Structure TYPE_DB_TANSMA
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public TANCD As String '担当者コード          000000              
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public SMADT As String '経理締日付            YYYY/MM/DD          
    '	Dim SMAUODKN As Decimal '受注集計金額          ###,###,##0.0000;;# 
    '       <VBFixedArray(9)> Dim SMAURIKN As Decimal() '売上集計金額          ###,###,##0.0000;;# 
    '       Dim SMAUZEKN As Decimal '売上消費税金額        ###,###,##0.0000;;# 
    '       Dim SMAYSUKN As Decimal '売上予算金額          ###,###,##0.0000;;# 
    '       Dim SMAYSAKN As Decimal '粗利予算金額          ###,###,##0.0000;;# 
    '       <VBFixedArray(9)> Dim SMAGNKKN As Decimal() '原価集計金額          ###,###,##0.0000;;# 
    '	'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(6), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=6)> Public WRTTM As String 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)               
    '       'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
    '       <VBFixedString(8), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst:=8)> Public WRTDT As String 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD          

    '	'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
    '	Public Sub Initialize()
    '		ReDim SMAURIKN(9)
    '		ReDim SMAGNKKN(9)
    '	End Sub
    'End Structure
    ''UPGRADE_WARNING: 構造体 DB_TANSMA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    'Public DB_TANSMA As TYPE_DB_TANSMA
    'Public DBN_TANSMA As Short
    '20190611 del end
    
	' Index1( TANCD + SMADT )
	' Index2( SMADT + TANCD )
	
	Sub TANSMA_RClear()
		Dim TmpStat As Object
		'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト TmpStat の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/03/25　仮
        '      TmpStat = Dll_RClear(DBN_TANSMA, G_LB)
        '      Call ResetBuf(DBN_TANSMA)
        '2019/03/25　仮
    End Sub
End Module