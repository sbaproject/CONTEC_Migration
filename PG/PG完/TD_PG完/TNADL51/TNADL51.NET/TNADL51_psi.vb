Option Strict Off
Option Explicit On
Module SSSMAIN0002
	'プログラム総括情報プロシジャ
	
	Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(15)
		AE_PSIC = 16
		AE_PSI(0) = "HD_DSPYM 0000 date 10 - A L Y 0 YYYY年MM月 - 1 -"
		'''' UPD 2009/02/25  FKS) S.Nakajima    Start
		'   AE_PSI$(1) = "HD_HINCD 3303 code 8 - A L N U - - 1 -"
		AE_PSI(1) = "HD_HINCD 3303 code 10 - A L N U - - 1 -"
		'''' UPD 2009/02/25  FKS) S.Nakajima    End
		AE_PSI(2) = "HD_HINNMA 0000 name 30 - A L N N - - 1 -"
		AE_PSI(3) = "HD_HINNMB 0000 name 30 - A L N N - - 1 -"
		AE_PSI(4) = "HD_IRISU 0000 numb 7 - A R N C ###,### - 1 -"
		AE_PSI(5) = "HD_UNTNM 0000 name 9 - A L N A - - 1 -"
		AE_PSI(6) = "HD_OPEID 0000 code 6 - A L N U - - 1 -"
		AE_PSI(7) = "HD_OPENM 0000 code 20 - A L N U - - 1 -"
		AE_PSI(8) = "BD_SOUCD 0000 code 3 - A R N 0 000 - 1 -"
		AE_PSI(9) = "BD_SOUNM 0000 name 20 - A L N A - - 1 -"
		AE_PSI(10) = "BD_SMZZAISU 0000 numb 9 - A R N C #,###,### - 1 -"
		AE_PSI(11) = "BD_SMAINPSU 0000 numb 9 - A R N C #,###,### - 1 -"
		AE_PSI(12) = "BD_SMAOUTSU 0000 numb 9 - A R N C #,###,### - 1 -"
		AE_PSI(13) = "BD_ZAISAISU 0000 numb 9 - A R N C #,###,### - 1 -"
		AE_PSI(14) = "BD_SMAZAISU 0000 numb 9 - A R N C #,###,### - 1 -"
		AE_PSI(15) = "BD_RELZAISU 0000 numb 9 - A R N C #,###,### - 1 -"
	End Sub
End Module