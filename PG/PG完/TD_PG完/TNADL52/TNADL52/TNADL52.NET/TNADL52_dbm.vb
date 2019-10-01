Option Strict Off
Option Explicit On
Module TNADL52_DBM
	'==========================================================================
	'   TNADL52.DBM  在庫照会（倉庫別）ワーク         UPD.EXE Ver 3, 0, 1, 2  =
	'==========================================================================
	Structure TYPE_DB_TNADL52
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(10),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=10)> Public HINCD() As Char '製品コード            !@@@@@@@@@@         
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(50),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=50)> Public HINNMA() As Char '型式                                      
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(50),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=50)> Public HINNMB() As Char '商品名１                                  
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(4),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=4)> Public UNTNM() As Char '単位名                                    
		Dim SMZZAISU As Decimal '棚卸数量              ##,###,##0.00;;#    
		Dim SMAINPSU As Decimal '入荷集計数量          ##,###,##0.00;;#    
		Dim SMAOUTSU As Decimal '棚卸数量              ##,###,##0.00;;#    
		Dim ZAISAISU As Decimal '棚卸差異数量          ###,##0.00;;#       
		Dim SMAZAISU As Decimal '当月在庫数            ##,###,##0.00;;#    
		Dim RELZAISU As Decimal '現在在庫数            #,###,##0.00;;#     
	End Structure
	Public DB_TNADL52 As TYPE_DB_TNADL52
	Public DBN_TNADL52 As Short
	' Index1( HINCD )
	
	Sub TNADL52_RClear()
		Dim TmpStat As Object
        'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト TmpStat の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190712 DELL START
        'TmpStat = Dll_RClear(DBN_TNADL52, G_LB)
        'Call ResetBuf(DBN_TNADL52)
        '20190712 DELL END
    End Sub
End Module