Option Strict Off
Option Explicit On
Module URIKN_F52
	'
	' スロット名        : 売上金額・画面項目スロット
	' ユニット名        : URIKN.F52
	' 記述者            :
	' 作成日付          : 2006/09/22
	' 使用プログラム名  : URIET52
	'
	
	'売上単価＊売上数量
	Function URIKN_Derived(ByVal URIKN As Object, ByVal URITK As Object, ByVal URISU As Object, ByVal HINID As Object, ByRef CP_URIKN As clsCP, ByVal TKNRPSKB As Object, ByVal TKNZRNKB As Object) As Object
		Dim WL_TKNRPSKB, WL_TKNZRNKB As Object
		Dim WL_URISU As Double
		Dim WL_URITK As Double
		WL_URISU = 0
		WL_URITK = 0
		
		'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_URISU = URISU
		'UPGRADE_WARNING: オブジェクト URITK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_URITK = URITK
		'UPGRADE_WARNING: オブジェクト TKNRPSKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト WL_TKNRPSKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_TKNRPSKB = TKNRPSKB
		
		'UPGRADE_WARNING: オブジェクト SSSVal(TKNZRNKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(TKNZRNKB) = 0 Then
			'UPGRADE_WARNING: オブジェクト WL_TKNZRNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WL_TKNZRNKB = 0
			'UPGRADE_WARNING: オブジェクト SSSVal(TKNZRNKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf SSSVal(TKNZRNKB) = 1 Then 
			'UPGRADE_WARNING: オブジェクト WL_TKNZRNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WL_TKNZRNKB = 5
			'UPGRADE_WARNING: オブジェクト SSSVal(TKNZRNKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf SSSVal(TKNZRNKB) = 9 Then 
			'UPGRADE_WARNING: オブジェクト WL_TKNZRNKB の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			WL_TKNZRNKB = 9
		End If
		
		'
		'UPGRADE_WARNING: オブジェクト URIKN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト URIKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		URIKN_Derived = URIKN
		
		'【通販】及び【システムで諸口商品】時、算出処理回避
		'UPGRADE_WARNING: オブジェクト HINID の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If (Trim(WG_JDNINKB) = "2") Or (Trim(WG_SYSTEM) = "M" And Trim(HINID) = "06") Then Exit Function
		
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
			'        URIKN_Derived = DCMFRC(URITK * URISU, 0, 0)     '1996/08/26 Insert
			
			' 得意先マスタの金額端数処理桁数(TKNRPSKB)、金額端数処理区分(TKNZRNKB)より計算
			' TKNRPSKB 1：小数第1位、2：小数第2位、3：小数第3位、4: 小数第4位､5: 小数第5位
			' TKNZRNKB 0：切り捨て、1：四捨五入、9：切り上げ
			
			'UPGRADE_WARNING: オブジェクト SSSVal(WL_TKNRPSKB) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト SSSVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URIKN_Derived = DCMFRC2(WL_URITK * WL_URISU, SSSVal(WL_TKNZRNKB), (SSSVal(WL_TKNRPSKB) * -1) + 1)
			
		End If
		Exit Function
OverFlow: 
		CP_URIKN.StatusC = Cn_StatusError
		'UPGRADE_WARNING: オブジェクト URIKN_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		URIKN_Derived = "??????????????????"
	End Function
	
	'最初はカーソルを留めない。
	Function URIKN_Skip(ByVal HINCD As Object, ByVal URITK As Object, ByVal URISU As Object) As Object
		'UPGRADE_WARNING: オブジェクト URIKN_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		URIKN_Skip = False
		'UPGRADE_WARNING: オブジェクト HINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(HINCD) = "" Then
			'UPGRADE_WARNING: オブジェクト URIKN_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URIKN_Skip = True
			'' 2003/08/28 金額か単価のいずれかが 0 でない場合
			'UPGRADE_WARNING: オブジェクト URISU の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト URITK の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf URITK <> 0 Or URISU <> 0 Then 
			''ElseIf URITK <> 0 And URISU <> 0 Then
			'UPGRADE_WARNING: オブジェクト URIKN_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			URIKN_Skip = True
		End If
	End Function
	
	' 標準DCMFRC 第一引数IN_SU AS CURRENCY ⇒ DCMFRC2 第一引数IN_SU AS DOUBLEに変更
	Function DCMFRC2(ByRef IN_SU As Double, ByRef MARUME As Decimal, ByRef KETA As Decimal) As Decimal
		'  IN_SU:被編集数値, MARUME:まるめパラメータ
		'  KETA:まるめる桁位置(少数第1位が0 少数第2位が-1 整数1の位が1 整数2の位が2)
		Dim WL_MARUME, WL_KETA, WL_SU As Decimal
		WL_KETA = 10 ^ KETA
		WL_MARUME = MARUME / 10
		If IN_SU < 0 Then
			WL_SU = IN_SU / WL_KETA - WL_MARUME
			DCMFRC2 = Fix(WL_SU) * WL_KETA
		Else
			WL_SU = IN_SU / WL_KETA + WL_MARUME
			DCMFRC2 = Int(WL_SU) * WL_KETA
		End If
	End Function
End Module