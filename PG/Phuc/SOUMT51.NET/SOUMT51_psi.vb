Option Strict Off
Option Explicit On
Module SSSMAIN0002
    'プログラム総括情報プロシジャ
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim Dummy As String 'ダミー
    End Structure

    Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(37)
		AE_PSIC = 38
		AE_PSI(0) = "HD_OPEID 0000 code 6 - A L N U 000000 - 1 -"
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N U - - 1 -"
		AE_PSI(2) = "BD_UPDKB 0000 code 4 - A L N N - - 1 -"
		AE_PSI(3) = "BD_SOUCD 3303 code 3 - A R N 0 000 - 1 -"
		AE_PSI(4) = "BD_SOUNM 2202 name 20 - A L N N - - 1 -"
		AE_PSI(5) = "BD_SOUBSCD 3303 code 3 - A L N A !@@@ - 1 -"
		AE_PSI(6) = "BD_SOUBSNM 0000 name 20 - A L N N - - 1 -"
		AE_PSI(7) = "BD_SOUKOKB 3303 code 2 - A L N 0 00 - 1 -"
		AE_PSI(8) = "BD_SOUKONM 0000 code 10 - A L N N - - 1 -"
		AE_PSI(9) = "BD_SOUTRICD 2202 code 5 - A L N S !@@@@@@@@@@ - 1 -"
		AE_PSI(10) = "BD_SOUTRINM 0000 code 20 - A L N N - - 1 -"
		AE_PSI(11) = "BD_SOUKB 3303 code 1 - A L N 0 0 - 1 -"
		AE_PSI(12) = "BD_HIKKB 3303 code 1 - A L N 0 0 - 1 -"
		AE_PSI(13) = "BD_SRSCNKB 3303 code 1 - A L N 0 0 - 1 -"
		AE_PSI(14) = "BD_SISNKB 3303 code 1 - A L N 0 0 - 1 -"
		AE_PSI(15) = "BD_SALPALKB 3303 code 1 - A L N 0 0 - 1 -"
		AE_PSI(16) = "BD_SOUZP 2202 code 20 - A L N Z - - 1 -"
		AE_PSI(17) = "BD_SOUADA 2202 name 40 - A L N N - - 1 -"
		AE_PSI(18) = "BD_SOUADB 2202 name 40 - A L N N - - 1 -"
		AE_PSI(19) = "BD_SOUADC 2202 name 40 - A L N N - - 1 -"
		AE_PSI(20) = "BD_SOUTL 2202 code 20 - A L N T - - 1 -"
		AE_PSI(21) = "BD_SOUFX 2202 code 20 - A L N T - - 1 -"
		AE_PSI(22) = "BV_V_DATKB 0000 code 1 - A L N N - - 1 -"
		AE_PSI(23) = "BV_V_SOUNM 0000 code 20 - A L N N - - 1 -"
		AE_PSI(24) = "BV_V_SOUZP 0000 name 20 - A L N Z - - 1 -"
		AE_PSI(25) = "BV_V_SOUADA 0000 name 40 - A L N N - - 1 -"
		AE_PSI(26) = "BV_V_SOUADB 0000 name 40 - A L N N - - 1 -"
		AE_PSI(27) = "BV_V_SOUADC 0000 name 40 - A L N N - - 1 -"
		AE_PSI(28) = "BV_V_SOUTL 0000 code 20 - A L N T - - 1 -"
		AE_PSI(29) = "BV_V_SOUFX 0000 code 20 - A L N T - - 1 -"
		AE_PSI(30) = "BV_V_SOUBSC 0000 code 3 - A L N A !@@@ - 1 -"
		AE_PSI(31) = "BV_V_SOUKB 0000 code 1 - A L N 0 0 - 1 -"
		AE_PSI(32) = "BV_V_SRSCNK 0000 code 1 - A L N 0 0 - 1 -"
		AE_PSI(33) = "BV_V_SISNKB 0000 code 1 - A L N 0 0 - 1 -"
		AE_PSI(34) = "BV_V_SOUTRI 0000 code 5 - A L N S !@@@@@@@@@@ - 1 -"
		AE_PSI(35) = "BV_V_SOUKOK 0000 code 2 - A L N 0 00 - 1 -"
		AE_PSI(36) = "BV_V_HIKKB 0000 code 1 - A L N 0 0 - 1 -"
		AE_PSI(37) = "BV_V_SALPAL 0000 code 1 - A L N 0 0 - 1 -"
	End Sub
End Module