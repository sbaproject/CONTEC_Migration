Option Strict Off
Option Explicit On
Module SSSMAIN0002
	'プログラム総括情報プロシジャ
	
	Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(29)
		AE_PSIC = 30
		AE_PSI(0) = "HD_FRKEYCD 3303 code 3 - A R N A 000 - 1 -"
		AE_PSI(1) = "HD_FRMEINM 0000 name 20 - A L N N - - 1 -"
		AE_PSI(2) = "HD_OPEID 0000 code 6 - A L N 0 !@@@@@@@@ - 1 -"
		AE_PSI(3) = "HD_OPENM 0000 name 20 - A L N N - - 1 -"
		AE_PSI(4) = "BD_UPDKB 0000 code 4 - A L N N !@@@@ - 1 -"
		'2007/10/11 FKS)minamoto CHG START
		'AE_PSI$(5) = "BD_MEICDA 3303 code 20 - A L N A !@@@@@@@@@@@@@@@@@@@@ - 1 -"
		AE_PSI(5) = "BD_MEICDA 3303 code 20 - A L N N !@@@@@@@@@@@@@@@@@@@@ - 1 -"
		'2007/10/11 FKS)minamoto CHG END
		AE_PSI(6) = "BD_MEICDB 2202 code 5 - A L N A !@@@@@ - 1 -"
		AE_PSI(7) = "BD_DSPORD 2202 code 3 - A R N 0 000 - 1 -"
		AE_PSI(8) = "BD_MEINMA 2202 name 40 - A L N N - - 1 -"
		AE_PSI(9) = "BD_MEINMB 2202 name 20 - A L N N - - 1 -"
		AE_PSI(10) = "BD_MEINMC 2202 name 20 - A L N N - - 1 -"
		AE_PSI(11) = "BD_MEISUA 2202 numb 16 - A R N C ###,###,##0.0000;;# - 1 -"
		AE_PSI(12) = "BD_MEISUB 2202 numb 12 - A R N C ###,##0.0000;;# - 1 -"
		AE_PSI(13) = "BD_MEISUC 2202 numb 12 - A R N C ###,##0.0000;;# - 1 -"
		AE_PSI(14) = "BD_MEIKBA 2202 code 1 - A L N U - - 1 -"
		AE_PSI(15) = "BD_MEIKBB 2202 code 1 - A L N U - - 1 -"
		AE_PSI(16) = "BD_MEIKBC 2202 code 1 - A L N U - - 1 -"
		AE_PSI(17) = "BV_KEYCD 0000 code 3 - A L N A - - 1 -"
		AE_PSI(18) = "BV_MEIKMKNM 0000 name 20 - A L N N - - 1 -"
		AE_PSI(19) = "BV_V_DATKB 0000 code 1 - A L N N - - 1 -"
		AE_PSI(20) = "BV_V_MEIKBA 0000 code 1 - A L N U - - 1 -"
		AE_PSI(21) = "BV_V_MEIKBB 0000 code 1 - A L N U - - 1 -"
		AE_PSI(22) = "BV_V_MEIKBC 0000 code 1 - A L N U - - 1 -"
		AE_PSI(23) = "BV_V_MEINMA 0000 name 40 - A L N N - - 1 -"
		AE_PSI(24) = "BV_V_MEINMB 0000 name 20 - A L N N - - 1 -"
		AE_PSI(25) = "BV_V_MEINMC 0000 name 20 - A L N N - - 1 -"
		AE_PSI(26) = "BV_V_MEISUA 0000 numb 16 - A R N C ###,###,##0.0000;;# - 1 -"
		AE_PSI(27) = "BV_V_MEISUB 0000 numb 12 - A R N C ###,##0.0000;;# - 1 -"
		AE_PSI(28) = "BV_V_MEISUC 0000 numb 12 - A R N C ###,##0.0000;;# - 1 -"
		AE_PSI(29) = "BV_V_DSPORD 0000 code 3 - A R N 0 000 - 1 -"
	End Sub
End Module