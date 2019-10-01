Option Strict Off
Option Explicit On
Module SSSMAIN0002
	'プログラム総括情報プロシジャ
	
	Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(6)
		AE_PSIC = 7
		AE_PSI(0) = "HD_OPEID 0000 code 8 - A L N U - - 1 -"
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N N - - 1 -"
        AE_PSI(2) = "BD_UPDKB 0000 name 4 - A L N N - - 1 -"
        AE_PSI(3) = "BD_CTLCD 3303 code 10 - A L N U - - 1 -"
        AE_PSI(4) = "BD_CTLNM 2202 name 50 - A L N N - - 1 -"
		AE_PSI(5) = "BD_FIXVAL 2202 name 20 - A L N S - - 1 -"
		AE_PSI(6) = "BD_REMARK 2202 name 128 - A L N N - - 1 -"
	End Sub
End Module