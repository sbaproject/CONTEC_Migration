Option Strict Off
Option Explicit On
Module SSSMAIN0002
    'vOîñvVW
    '2019/09/19 ADD START
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim dummy
    End Structure
    '2019/09/19 ADD E N D

    Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(43)
		AE_PSIC = 44
		AE_PSI(0) = "HD_OPEID 0000 code 6 - A L N 0 000000 - 1 -"
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N N - - 1 -"
		AE_PSI(2) = "BD_UPDKB 0000 code 4 - A L N A - - 1 -"
		AE_PSI(3) = "BD_BMNCD 3303 code 6 - A L N U !@@@@@@ - 1 -"
		AE_PSI(4) = "BD_STTTKDT 3303 date 10 - A L N A YYYY/MM/DD - 1 -"
		AE_PSI(5) = "BD_ENDTKDT 3303 date 10 - A L N A YYYY/MM/DD - 1 -"
		AE_PSI(6) = "BD_BMNNM 3303 name 40 - A L N N - - 1 -"
		AE_PSI(7) = "BD_BMNPRNM 3303 name 40 - A L N N - - 1 -"
		AE_PSI(8) = "BD_ZMJGYCD 3303 code 1 - A L N U !@ - 1 -"
		AE_PSI(9) = "BD_ZMCD 3303 code 1 - A L N 0 0 - 1 -"
		AE_PSI(10) = "BD_ZMBMNCD 3303 code 3 - A L N U !@@@ - 1 -"
		AE_PSI(11) = "BD_HTANCD 2202 code 3 - A L N U !@@@ - 1 -"
		AE_PSI(12) = "BD_STANCD 2202 code 3 - A L N U !@@@ - 1 -"
		'''' UPD 2010/07/14  FKS) T.Yamamoto    Start    A[FC10071401
		'   AE_PSI$(13) = "BD_EIGYOCD 2202 code 1 - A L N U !@ - 1 -"
		AE_PSI(13) = "BD_EIGYOCD 2202 code 1 - A L N N !@ - 1 -"
		'''' UPD 2010/07/14  FKS) T.Yamamoto    End
		AE_PSI(14) = "BD_TIKKB 3303 code 2 - A R N 0 00 - 1 -"
		AE_PSI(15) = "BD_BMNZP 2202 code 20 - A L N Z - - 1 -"
		AE_PSI(16) = "BD_BMNADA 2202 name 60 - A L N N - - 1 -"
		AE_PSI(17) = "BD_BMNADB 2202 name 60 - A L N N - - 1 -"
		AE_PSI(18) = "BD_BMNADC 2202 name 60 - A L N N - - 1 -"
		AE_PSI(19) = "BD_BMNTL 2202 code 20 - A L N T - - 1 -"
		AE_PSI(20) = "BD_BMNFX 2202 code 20 - A L N T - - 1 -"
		AE_PSI(21) = "BD_BMNURL 2202 name 50 - A L N N - - 1 -"
		AE_PSI(22) = "BD_BMNCDUP 2202 code 6 - A L N U !@@@@@@ - 1 -"
		AE_PSI(23) = "BD_BMNNMUP 0000 name 20 - A L N N - - 1 -"
		AE_PSI(24) = "BD_BMNLV 0000 numb 2 - A R N 0 ## - 1 -"
		AE_PSI(25) = "BV_V_DATKB 0000 code 1 - A L N N - - 1 -"
		AE_PSI(26) = "BV_V_BMNADA 0000 name 60 - A L N N - - 1 -"
		AE_PSI(27) = "BV_V_BMNADB 0000 name 60 - A L N N - - 1 -"
		AE_PSI(28) = "BV_V_BMNADC 0000 name 60 - A L N N - - 1 -"
		AE_PSI(29) = "BV_V_BMNCDU 0000 code 6 - A L N U !@@@@@@ - 1 -"
		AE_PSI(30) = "BV_V_BMNFX 0000 code 20 - A L N T - - 1 -"
		AE_PSI(31) = "BV_V_BMNNM 0000 name 40 - A L N N - - 1 -"
		AE_PSI(32) = "BV_V_BMNPRN 0000 name 40 - A L N N - - 1 -"
		AE_PSI(33) = "BV_V_BMNTL 0000 code 20 - A L N T - - 1 -"
		AE_PSI(34) = "BV_V_BMNURL 0000 name 50 - A L N N - - 1 -"
		AE_PSI(35) = "BV_V_BMNZP 0000 code 20 - A L N Z - - 1 -"
		AE_PSI(36) = "BV_V_EIGYOC 0000 code 1 - A L N U !@ - 1 -"
		AE_PSI(37) = "BV_V_ENDTKD 0000 date 10 - A L N A YYYY/MM/DD - 1 -"
		AE_PSI(38) = "BV_V_HTANCD 0000 code 3 - A L N U !@@@ - 1 -"
		AE_PSI(39) = "BV_V_STANCD 0000 code 3 - A L N U !@@@ - 1 -"
		AE_PSI(40) = "BV_V_TIKKB 0000 code 2 - A R N 0 00 - 1 -"
		AE_PSI(41) = "BV_V_ZMBMNC 0000 code 3 - A L N U !@@@ - 1 -"
		AE_PSI(42) = "BV_V_ZMCD 0000 code 1 - A L N 0 0 - 1 -"
		AE_PSI(43) = "BV_V_ZMJGYC 0000 code 1 - A L N U !@ - 1 -"
	End Sub
End Module