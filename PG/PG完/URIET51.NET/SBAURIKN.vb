Option Strict Off
Option Explicit On
Module SBAURIKN_F54
	'
	' スロット名        : 伝票売上合計金額・画面項目スロット
	' ユニット名        : SBAURIKN.F61
	' 記述者            : Muratani
	' 作成日付          : 2006/07/25
	' 使用プログラム名  : URIET51
	'
	
	'売上単価＊売上数量
	Function SBAURIKN_CHECKC(ByVal SBAURIKN As Object, ByRef PP As clsPP, ByRef CP_SBAURIKN As clsCP) As Object
		Dim Rtn As Object
		'
		'UPGRADE_WARNING: オブジェクト SBAURIKN_CHECKC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SBAURIKN_CHECKC = 0
		
		'UPGRADE_WARNING: オブジェクト SBAURIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(SBAURIKN) = "" Or Not IsNumeric(SBAURIKN) Then Exit Function
		On Error GoTo OverFlow
		
		' システム上の税抜き金額と、手入力税抜き金額が一致する場合、税金・税込金額を表示。
		' それ以外はエラーメッセージを表示
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_SBAUZEKN(0) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト SBAURIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (SBAURIKN + RD_SSSMAIN_SBAUZEKN(0)) <> RD_SSSMAIN_SBADENKN(0) Then
			'Rtn = DSP_MsgBox(SSS_ERROR, "???", 0)   '明細合計値と入力値が異なる旨のエラーメッセージ
            MsgBox("明細合計値と入力値が異なります。", MB_OK + MB_ICONEXCLAMATION, Trim(SSS_PrgNm))
			'UPGRADE_WARNING: オブジェクト SBAURIKN_CHECKC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			SBAURIKN_CHECKC = -1
		End If
		Exit Function
OverFlow: 
		CP_SBAURIKN.StatusC = Cn_StatusError
		'UPGRADE_WARNING: オブジェクト SBAURIKN_CHECKC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SBAURIKN_CHECKC = "??????????????????"
	End Function
End Module