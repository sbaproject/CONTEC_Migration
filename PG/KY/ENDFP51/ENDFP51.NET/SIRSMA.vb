Option Strict Off
Option Explicit On
Module SIRSMA_DBM
	'==========================================================================
	'   SIRSMA.DBM   買掛サマリ                       UPD.EXE Ver 3, 0, 1, 2  =
	'==========================================================================
	Structure TYPE_DB_SIRSMA
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public SIRCD() As Char '仕入先コード          !@@@@@@@@@@         
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public SMADT() As Char '経理締日付            YYYY/MM/DD          
		<VBFixedArray(9)> Dim SMASREKN() As Decimal '仕入集計金額          ###,###,##0.0000;;# 
		Dim SMASZEKN As Decimal '仕入消費税金額        #,###,###,###       
		<VBFixedArray(2)> Dim SZAKZIKN() As Decimal 'ランク別税込課税金額  ###,###,###,###     
		<VBFixedArray(2)> Dim SZAKZOKN() As Decimal 'ランク別税抜課税金額  ###,###,###,###     
		<VBFixedArray(2)> Dim SZBKZIKN() As Decimal 'ランク別税込課税金額  ###,###,###,###     
		<VBFixedArray(2)> Dim SZBKZOKN() As Decimal 'ランク別税抜課税金額  ###,###,###,###     
		<VBFixedArray(9)> Dim SMAPAYKN() As Decimal '支払集計金額          ###,###,###,###     
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public DATNO() As Char '伝票管理NO.           0000000000          
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)               
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD          
		
		'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
		Public Sub Initialize()
			ReDim SMASREKN(9)
			ReDim SZAKZIKN(2)
			ReDim SZAKZOKN(2)
			ReDim SZBKZIKN(2)
			ReDim SZBKZOKN(2)
			ReDim SMAPAYKN(9)
		End Sub
	End Structure
	'UPGRADE_WARNING: 構造体 DB_SIRSMA の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Public DB_SIRSMA As TYPE_DB_SIRSMA
	Public DBN_SIRSMA As Short
	' Index1( SIRCD + SMADT )
	' Index2( SMADT + SIRCD )
	
	Sub SIRSMA_RClear()
		Dim TmpStat As Object
        'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト TmpStat の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/10/31 DEL START
        'TmpStat = Dll_RClear(DBN_SIRSMA, G_LB)
        'Call ResetBuf(DBN_SIRSMA)
        '2019/10/31 DEL E N D
    End Sub
End Module