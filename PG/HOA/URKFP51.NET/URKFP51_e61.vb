Option Strict Off
Option Explicit On
Module URKFP51_E61
	'
	' スロット名        : 画面統合処理・画面処理スロット
	' ユニット名        : URKFP51.E61
	' 記述者            : Muratani
	' 作成日付          : 2006/09/28
	' 使用プログラム名  : URKFP51
	'
	
	Sub INITDSP()
		
		AE_BackColor(1) = &H8000000F
		
		CL_SSSMAIN(0) = 1
		CL_SSSMAIN(1) = 1
		
	End Sub
End Module