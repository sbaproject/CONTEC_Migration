Option Strict Off
Option Explicit On
Module SSSMAIN0002
    'プログラム総括情報プロシジャ
    '2019/10/31 ADD START
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim dummy
    End Structure
    '2019/10/31 ADD E N D
    Sub AE_PSIR_SSSMAIN() 'Generated.
		ReDim AE_PSI(2)
		AE_PSIC = 3
		AE_PSI(0) = "HD_OPEID 0000 code 6 - A L N U - - 1 -"
		AE_PSI(1) = "HD_OPENM 0000 name 20 - A L N U - - 1 -"
		AE_PSI(2) = "HD_MONUPDYM 3303 date 7 - M L Y 0 YYYY/MM - 1 -"
	End Sub
End Module