Option Strict Off
Option Explicit On
Module SBAURIKN_F52
	'
	' スロット名        : 伝票合計売上金額項目・画面項目スロット
	' ユニット名        : SBAURIKN.F52
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/22
	' 使用プログラム名  : URIET52
	
	'売上合計金額を計算して表示する。
	Function SBAURIKN_CheckC(ByVal SBAURIKN As Object, ByVal URIKN As Object, ByRef PP As clsPP, ByRef CP_SBAURIKN As clsCP) As Object
		Dim Rtn As Short
		Dim NullSw, I As Short
		Dim Sum As Decimal
		Dim Valu As Decimal
		'
		NullSw = True
		Sum = 0
		I = 0
		Do While I < PP.LastDe
			Valu = 0
			If IsNumeric(RD_SSSMAIN_URIKN(I)) Then
				'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_URIKN() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				Valu = RD_SSSMAIN_URIKN(I)
				Sum = Sum + Valu
				NullSw = False
			End If
			I = I + 1
		Loop 
		If NullSw = False Then
			'UPGRADE_WARNING: オブジェクト SBAURIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If SBAURIKN <> Sum Then
				Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 6) '合計値と入力が不一致エラー
				'UPGRADE_WARNING: オブジェクト SBAURIKN_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				SBAURIKN_CheckC = -1
			End If
		Else
			Rtn = DSP_MsgBox(SSS_CONFRM, "URIET52", 6) '合計値と入力が不一致エラー
			'UPGRADE_WARNING: オブジェクト SBAURIKN_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SBAURIKN_CheckC = -1
		End If
		
	End Function
End Module