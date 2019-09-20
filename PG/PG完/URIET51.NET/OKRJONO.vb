Option Strict Off
Option Explicit On
Module OKRJONO_F61
	'
	' スロット名        : 受注伝票番号・画面項目スロット
	' ユニット名        : OKRJONO.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/07/25
	' 使用プログラム名  : URIET51
	'
	Public from_JDNNO_Unit As Boolean ' 受注番号入力時（MAX標準機能制御の為）
	
	Function OKRJONO_InitVal(ByVal OKRJONO As Object, ByRef PP As clsPP, ByRef CP_OKRJONO As clsCP) As Object
		Dim WK_OKRJONO As Object
		If from_JDNNO_Unit = True Then
			'UPGRADE_WARNING: オブジェクト OKRJONO の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト OKRJONO_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			OKRJONO_InitVal = OKRJONO
		Else
			'UPGRADE_WARNING: オブジェクト OKRJONO_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			OKRJONO_InitVal = ""
		End If
		from_JDNNO_Unit = False
	End Function
End Module