Option Strict Off
Option Explicit On
Module URITK_F81
	'
	'スロット名      :単価・画面項目スロット
	'ユニット名      :URITK.F81
	'記述者          :Standard Library
	'作成日付        :1997/07/03
	'使用プログラム  :TOKMT52
	
	Function URITK_CheckC(ByVal URITK As Object) As Object
		Dim Rtn As Short
		'
		'UPGRADE_WARNING: オブジェクト URITK_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		URITK_CheckC = 0
		
		If gs_SALTAUTH = "9" Then
			Call MsgBox("販売単価変更権限がありません", MsgBoxStyle.OKOnly)
			'UPGRADE_WARNING: オブジェクト URITK_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URITK_CheckC = -1
			Exit Function
		End If
		
		'UPGRADE_WARNING: オブジェクト SSSVal(URITK) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(URITK) = 0 Then
			Rtn = DSP_MsgBox(SSS_CONFRM, "TOKMT52", 1)
			'UPGRADE_WARNING: オブジェクト URITK_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URITK_CheckC = -1
		End If
		
		
	End Function
End Module