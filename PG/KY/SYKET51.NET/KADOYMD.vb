Option Strict Off
Option Explicit On
Module KADOYMD_O51
	'
	'スロット名     ：物流稼働日チェック
	'ユニット名     ：KADOYMD.O51
	'記述者         ：Standard Libraly
	'作成日付       ：2006/07/13
	'使用プログラム ：
	'
	Function CHK_KADOYMD(ByVal pdate As String) As Boolean
		'---------------------------------------------------------------------------
		' チェック対象日付が許容された範囲(固定値マスタ)の物流稼働日かチェックする。
		'---------------------------------------------------------------------------
		' pDate : チェック対象日付 ( YYYY/MM/DD )
		'
		' 返り値: False ..... 許容された範囲の物流稼働日ではない。
		'         True  ..... 許容された範囲の物流稼働日である。
		'
		Dim lngFIXVAL As Integer
		Dim lngI As Integer
		
		CHK_KADOYMD = False
		
		If IsDate(pdate) = False Then
			Exit Function
		End If
		
		pdate = DeCNV_DATE(pdate) 'YYYY/MM/DD → YYYYMMDD
		
		'固定値マスタ取得
		Call DB_GetEq(DBN_FIXMTA, 1, "401", BtrNormal) '物流稼働日の許容範囲
		If DBSTAT <> 0 Then
			Exit Function
		End If
		If DB_FIXMTA.DATKB = "9" Then
			Exit Function
		End If
		lngFIXVAL = CInt(Trim(DB_FIXMTA.FIXVAL))
		
		'カレンダマスタ検索
		lngI = 0
		Call DB_GetGrEq(DBN_CLDMTA, 1, DB_UNYMTA.UNYDT, BtrNormal)
		Do While (DBSTAT = 0) And (lngI <= lngFIXVAL)
			If DB_CLDMTA.DTBKDKB = "1" Then '物流稼働日区分
				lngI = lngI + 1
				If pdate = DB_CLDMTA.CLDDT Then
					CHK_KADOYMD = True
					Exit Do
				End If
			End If
			Call DB_GetNext(DBN_CLDMTA, BtrNormal)
		Loop 
		
	End Function
End Module