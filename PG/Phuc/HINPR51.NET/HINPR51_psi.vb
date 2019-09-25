Option Strict Off
Option Explicit On
Module SSSMAIN0002
    'プログラム総括情報プロシジャ
    '2019/09/24 ADD START
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim dummy
    End Structure
    '2019/09/24 ADD E N D
    Sub AE_PSIR_SSSMAIN()
		Dim AE_PSIC As Object 'Generated.
		Dim AE_PSI(7) As Object
		'UPGRADE_WARNING: オブジェクト AE_PSIC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AE_PSIC = 8
		'UPGRADE_WARNING: オブジェクト AE_PSI$(0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AE_PSI(0) = "HD_OPEID 0000 code 6 - A L N U - - 1 -"
		'UPGRADE_WARNING: オブジェクト AE_PSI$(1) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N U - - 1 -"
		'UPGRADE_WARNING: オブジェクト AE_PSI$(2) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AE_PSI(2) = "HD_KHNKB 2202 code 1 - A R N U - - 1 -"
		'UPGRADE_WARNING: オブジェクト AE_PSI$(3) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AE_PSI(3) = "HD_STTHINCD 2202 code 8 - A L N U - - 1 -"
		'UPGRADE_WARNING: オブジェクト AE_PSI$(4) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AE_PSI(4) = "HD_STTHINNM 0000 name 30 - A L N U - - 1 -"
		'UPGRADE_WARNING: オブジェクト AE_PSI$(5) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AE_PSI(5) = "HD_ENDHINCD 2202 code 8 - A L N U - - 1 -"
		'UPGRADE_WARNING: オブジェクト AE_PSI$(6) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AE_PSI(6) = "HD_ENDHINNM 0000 name 30 - A L N U - - 1 -"
		'UPGRADE_WARNING: オブジェクト AE_PSI$(7) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		AE_PSI(7) = "HD_HINKB 2202 code 1 - A R N U - - 1 -"
	End Sub
End Module