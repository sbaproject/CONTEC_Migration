Option Strict Off
Option Explicit On
Module SSSMAIN0002
	'プログラム総括情報プロシジャ
	
	Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(23)
		AE_PSIC = 24
		AE_PSI(0) = "HD_WRKKB 3303 code 1 - A R N 0 0 - 1 -"
		AE_PSI(1) = "HD_FDNDT 3303 date 10 - A L Y 0 YYYY/MM/DD - 1 -"
		AE_PSI(2) = "HD_JDNNO 3303 code 10 - A L N U !@@@@@@@@@@ - 1 -"
		AE_PSI(3) = "HD_SOUCD 0000 code 3 - A R N 0 000 - 1 -"
		AE_PSI(4) = "HD_SOUNM 0000 name 20 - A L N N - - 1 -"
		'''' UPD 2014/04/01  FWEST)Yamamoto    Start    連絡票№HAN20140401-01
		'   AE_PSI$(5) = "HD_TOKCD 0000 code 5 - A L N U !@@@@@@@@@@ - 1 -"
		AE_PSI(5) = "HD_TOKCD 0000 code 10 - A L N U !@@@@@@@@@@ - 1 -"
		'''' UPD 2014/04/01  FWEST)Yamamoto    End
		AE_PSI(6) = "HD_TOKRN 0000 name 40 - A L N N - - 1 -"
		AE_PSI(7) = "HD_OPEID 0000 code 6 - A L N U - - 1 -"
		AE_PSI(8) = "HD_OPENM 0000 code 20 - A L N U - - 1 -"
		AE_PSI(9) = "BD_LINNO 0000 code 3 - A R N 0 000 - 1 -"
		AE_PSI(10) = "BD_SBNNO 0000 code 10 - A L N U - - 1 -"
		AE_PSI(11) = "BD_ODNYTDT 0000 date 10 - A L Y 0 YYYY/MM/DD - 1 -"
		AE_PSI(12) = "BD_HINCD 0000 code 13 - A L N U !@@@@@@@@@@@@@ - 1 -"
		AE_PSI(13) = "BD_HINNMA 0000 name 20 - A L N N - - 1 -"
		AE_PSI(14) = "BD_BKTHKNM 0000 code 4 - A L N N - - 1 -"
		AE_PSI(15) = "BD_HIKSU 0000 numb 7 - A R N 0 ###,##0 - 1 -"
		AE_PSI(16) = "BD_FRDYZSU 0000 numb 7 - A R N 0 ###,##0 - 1 -"
		AE_PSI(17) = "BD_FRDKNSU 0000 numb 7 - A R N 0 ###,##0 - 1 -"
		AE_PSI(18) = "BD_OTPSU 0000 numb 7 - A R N 0 ###,##0 - 1 -"
		AE_PSI(19) = "BD_FRDSU 2202 numb 7 - A R N C ###,### - 1 -"
		AE_PSI(20) = "BV_JDNLINNO 0000 code 3 - A R N 0 - - 1 -"
		AE_PSI(21) = "BV_BKTHKKB 0000 code 1 - A L N 0 - - 1 -"
		AE_PSI(22) = "BV_SYKDATNO 0000 code 10 - A L N N - - 1 -"
		AE_PSI(23) = "BV_DATNO 0000 code 10 - A L N N - - 1 -"
	End Sub
End Module