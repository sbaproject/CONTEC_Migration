Option Strict Off
Option Explicit On
Module TOKSMD_DBM
	'==========================================================================
	'   TOKSMD.DBM   売掛サマリ外貨                   UPD.EXE Ver 3, 0, 1, 2  =
	'==========================================================================
	Structure TYPE_DB_TOKSMD
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public TOKCD() As Char '得意先コード          !@@@@@@@@@@         
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public TUKKB() As Char '通貨区分              !@@@                
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public SMADT() As Char '経理締日付            YYYY/MM/DD          
		<VBFixedArray(9)> Dim SMDURIKN() As Decimal '売上集計金額          ###,###,###,###     
		Dim SMDUZEKN As Decimal '売上消費税金額        ###,###,###,###     
		<VBFixedArray(2)> Dim FAKZIKN() As Decimal 'ランク別税込課税金額  ###,###,###,###     
		<VBFixedArray(2)> Dim FAKZOKN() As Decimal 'ランク別税抜課税金額  ###,###,###,###     
		<VBFixedArray(2)> Dim FBKZIKN() As Decimal 'ランク別税込課税金額  ###,###,###,###     
		<VBFixedArray(2)> Dim FBKZOKN() As Decimal 'ランク別税抜課税金額  ###,###,###,###     
		<VBFixedArray(9)> Dim SMDGNKKN() As Decimal '原価集計金額          ###,###,##0.0000;;# 
		<VBFixedArray(9)> Dim SMDNYUKN() As Decimal '入金集計金額          ###,###,###,###     
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public DATNO() As Char '伝票管理NO.           0000000000          
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(6),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=6)> Public WRTTM() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(時間)        9(06)               
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(8),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=8)> Public WRTDT() As Char 'ﾀｲﾑｽﾀﾝﾌﾟ(日付)        YYYY/MM/DD          
		
		'UPGRADE_TODO: この構造体のインスタンスを初期化するには、"Initialize" を呼び出さなければなりません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"' をクリックしてください。
		Public Sub Initialize()
			ReDim SMDURIKN(9)
			ReDim FAKZIKN(2)
			ReDim FAKZOKN(2)
			ReDim FBKZIKN(2)
			ReDim FBKZOKN(2)
			ReDim SMDGNKKN(9)
			ReDim SMDNYUKN(9)
		End Sub
	End Structure
	'UPGRADE_WARNING: 構造体 DB_TOKSMD の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Public DB_TOKSMD As TYPE_DB_TOKSMD
	Public DBN_TOKSMD As Short
	' Index1( TOKCD + TUKKB + SMADT )
	
	Sub TOKSMD_RClear()
		Dim TmpStat As Object
        'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト TmpStat の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '2019/09/19 DEL START
        'TmpStat = Dll_RClear(DBN_TOKSMD, G_LB)
        'Call ResetBuf(DBN_TOKSMD)
        '2019/09/19 DEL E N D
    End Sub
End Module