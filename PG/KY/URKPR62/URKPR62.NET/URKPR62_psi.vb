Option Strict Off
Option Explicit On
Module SSSMAIN0002
	'プログラム総括情報プロシジャ
	
	Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(11)
		AE_PSIC = 12
		AE_PSI(0) = "HD_OPEID 0000 code 6 - A L N U 000000 - 1 -"
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N N - - 1 -"
		AE_PSI(2) = "HD_STTTOKCD 2202 code 5 - A L N S !@@@@@ - 1 -"
		AE_PSI(3) = "HD_STTTOKRN 0000 name 40 - A L N N - - 1 -"
		AE_PSI(4) = "HD_STTTANCD 2202 code 6 - A L N U !@@@@@@ - 1 -"
		AE_PSI(5) = "HD_STTTANNM 0000 name 20 - A L N N - - 1 -"
		AE_PSI(6) = "HD_STTWRTDT 2202 date 10 - A L Y 0 YYYY/MM/DD - 1 -"
		AE_PSI(7) = "HD_ENDWRTDT 2202 date 10 - A L Y 0 YYYY/MM/DD - 1 -"
		AE_PSI(8) = "HD_STTWRTTM 2202 code 8 - A L Y 0 HH:MM:SS - 1 -"
		AE_PSI(9) = "HD_ENDWRTTM 2202 code 8 - A L Y 0 HH:MM:SS - 1 -"
		AE_PSI(10) = "HD_STTKSIDT 2202 date 10 - A L Y 0 YYYY/MM/DD - 1 -"
		AE_PSI(11) = "HD_ENDKSIDT 2202 date 10 - A L Y 0 YYYY/MM/DD - 1 -"
	End Sub
End Module