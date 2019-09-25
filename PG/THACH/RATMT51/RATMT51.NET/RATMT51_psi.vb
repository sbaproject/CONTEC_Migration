Option Strict Off
Option Explicit On
Module SSSMAIN0002
	'プログラム総括情報プロシジャ
	
	Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(8)
		AE_PSIC = 9
		AE_PSI(0) = "HD_OPEID 0000 code 6 - A L N 0 000000 - 1 -"
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N N - - 1 -"
		AE_PSI(2) = "BD_UPDKB 0000 code 4 - A L N N - - 1 -"
		AE_PSI(3) = "BD_TUKKB 3303 code 3 - A L N A !@@@ - 1 -"
		AE_PSI(4) = "BD_TUKNM 0000 name 20 - A L N N - - 1 -"
		AE_PSI(5) = "BD_TEKIDT 3303 date 10 - A L N A YYYY/MM/DD - 1 -"
		AE_PSI(6) = "BD_RATERT 3303 numb 12 - A R N C ###,##0.0000 - 1 -"
		AE_PSI(7) = "BV_V_DATKB 0000 code 1 - A L N N - - 1 -"
		AE_PSI(8) = "BV_V_RATERT 0000 numb 12 - A R N C ###,##0.0000 - 1 -"
	End Sub
End Module