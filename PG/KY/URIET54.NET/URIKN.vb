Option Strict Off
Option Explicit On
Module URIKN_F53
	'
	' スロット名        : 売上金額・画面項目スロット
	' ユニット名        : URIKN.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/09/12
	' 使用プログラム名  : URIET54
	'
	
	'売上単価＊売上数量
	Function URIKN_Derived(ByVal URIKN As Object, ByVal URITK As Object, ByVal URISU As Object, ByVal HINID As Object, ByRef CP_URIKN As clsCP) As Object
		'
		'''' UPD 2011/03/07  FKS) T.Yamamoto    Start    連絡票№CF11011701
		'    '【通販】及び【システムで諸口商品】時、算出処理回避
		'    If (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06") Then
		'システムで諸口商品の場合も売上金額を算出する（返品登録画面では諸口商品は入り口でエラーとなる）
		If Trim(WG_JDNINKB) = "2" Then
			'''' UPD 2011/03/07  FKS) T.Yamamoto    End
			'UPGRADE_WARNING: オブジェクト URIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト URIKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URIKN_Derived = URIKN
			Exit Function
		End If
		
		'UPGRADE_WARNING: オブジェクト URIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト URIKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		URIKN_Derived = URIKN
		'UPGRADE_WARNING: オブジェクト URITK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(URITK) = "" Or Not IsNumeric(URITK) Then Exit Function
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(URISU) = "" Or Not IsNumeric(URISU) Then Exit Function
		On Error GoTo OverFlow
		'' 2003/08/28 変更した単価 が 0 の場合前回の金額が残る
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト URITK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If URITK <> 0 Or URISU <> 0 Then
			''If URITK <> 0 And URISU <> 0 Then
			'        URIKN_Derived = URITK * URISU                  '1996/08/26 Delete
			'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト URITK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URIKN_Derived = DCMFRC(URITK * URISU, 0, 0) '1996/08/26 Insert
		End If
		Exit Function
OverFlow: 
		CP_URIKN.StatusC = Cn_StatusError
		'UPGRADE_WARNING: オブジェクト URIKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		URIKN_Derived = "??????????????????"
	End Function
End Module