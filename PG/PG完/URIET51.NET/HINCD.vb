Option Strict Off
Option Explicit On
Module HINCD_U01
	'
	' スロット名        : 商品コード・ファイル項目スロット
	' ユニット名        : HINCD.U01
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : URIET01
	
	Sub Scr_HINCD_FromSYSTBD(ByVal De As Short)
		If Trim(DB_SYSTBD.DFLDKBCD) <> "" Then
			Call DP_SSSMAIN_HINCD(De, DB_SYSTBD.DFLDKBCD)
		End If
	End Sub
	
	Sub SYSTBD_HINCD_FromScr(ByVal De As Short)
		
	End Sub
End Module