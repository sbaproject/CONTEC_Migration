Option Strict Off
Option Explicit On
Module CHK_UNYMTA2
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function CHK_UNYDT
	'   概要：  運用日付チェック
	'   引数：
	'   戻値：　0:正常(運用日付が引数の日付と同一) -1:運用日マスタ無
	'　　　　　 1:運用日付が引数の日付より大きい 2:運用日付が引数の日付より小さい
	'   備考：連絡票№739
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Function CHK_UNYDT(ByRef CHK_DT As String) As Object
		Dim strSQL As String
		Dim ls_UNYDT As String
		Dim ls_CHK_DT As String
		Dim DB_UNYMTA_BK As TYPE_DB_UNYMTA
		
		On Error GoTo ERR_CHK_UNYDT
		ls_CHK_DT = Trim(CHK_DT)
		
		'UPGRADE_WARNING: オブジェクト CHK_UNYDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		CHK_UNYDT = 9
		'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
		DB_UNYMTA_BK = LSet(DB_UNYMTA)
		strSQL = ""
		strSQL = strSQL & " SELECT * "
		strSQL = strSQL & "   FROM UNYMTA "
		'DBアクセス
		Call DB_GetSQL2(DBN_UNYMTA, strSQL)
		ls_UNYDT = Trim(DB_UNYMTA.UNYDT)
		
		If ls_UNYDT = ls_CHK_DT Then
			'UPGRADE_WARNING: オブジェクト CHK_UNYDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CHK_UNYDT = 0
		ElseIf ls_UNYDT > ls_CHK_DT Then 
			'UPGRADE_WARNING: オブジェクト CHK_UNYDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CHK_UNYDT = 1
		Else
			'UPGRADE_WARNING: オブジェクト CHK_UNYDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			CHK_UNYDT = 2
		End If
		
END_CHK_UNYDT: 
		'UPGRADE_ISSUE: LSet は 1 つの型から別の型に割り当てることはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="899FA812-8F71-4014-BAEE-E5AF348BA5AA"' をクリックしてください。
		DB_UNYMTA = LSet(DB_UNYMTA_BK)
		Exit Function
		
ERR_CHK_UNYDT: 
		GoTo END_CHK_UNYDT
	End Function
End Module