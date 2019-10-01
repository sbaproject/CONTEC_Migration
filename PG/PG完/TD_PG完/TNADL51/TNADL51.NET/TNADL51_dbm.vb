Option Strict Off
Option Explicit On
Module TNADL51_DBM
	'==========================================================================
	'   TNADL51.DBM  在庫照会（製品別）ワーク         UPD.EXE Ver 3, 0, 1, 2  =
	'==========================================================================
	Structure TYPE_DB_TNADL51
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(3),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=3)> Public SOUCD() As Char '倉庫コード            000                 
		'UPGRADE_WARNING: 固定長文字列のサイズはバッファに合わせる必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"' をクリックしてください。
		<VBFixedString(20),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=20)> Public SOUNM() As Char '倉庫名                                    
		Dim SMZZAISU As Decimal '棚卸数量              ##,###,##0.00;;#    
		Dim SMAINPSU As Decimal '入荷集計数量          ##,###,##0.00;;#    
		Dim SMAOUTSU As Decimal '棚卸数量              ##,###,##0.00;;#    
		Dim ZAISAISU As Decimal '棚卸差異数量          ###,##0.00;;#       
		Dim SMAZAISU As Decimal '当月在庫数            ##,###,##0.00;;#    
		Dim RELZAISU As Decimal '現在在庫数            #,###,##0.00;;#     
	End Structure
	Public DB_TNADL51 As TYPE_DB_TNADL51
	Public DBN_TNADL51 As Short
	' Index1( SOUCD )
	
	Sub TNADL51_RClear()
		Dim TmpStat As Object
        'UPGRADE_WARNING: オブジェクト G_LB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト TmpStat の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190705 DELL START
        'TmpStat = Dll_RClear(DBN_TNADL51, G_LB)
        'Call ResetBuf(DBN_TNADL51)
        '20190705 DELL END
    End Sub
End Module