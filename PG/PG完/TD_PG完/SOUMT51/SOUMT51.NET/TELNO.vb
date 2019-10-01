Option Strict Off
Option Explicit On
Module TELNO_O51
	'
	'スロット名     ：電話番号ハイフン個数チェック
	'ユニット名     ：TELNO.O51
	'記述者         ：Standard Libraly
	'作成日付       ：2006/08/28
	'使用プログラム ：
	'
	Function CHK_TELNO(ByVal pTELNO As String) As Boolean
		'---------------------------------------------------------------------------
		' 固定値マスタに登録されている（CTLCD = '507'）ハイフン個数と同一かチェックする。
		'---------------------------------------------------------------------------
		' pTELNO : チェック対象電話番号 ( XXXXXXXXX1XXXXXXXXX2 )
		' 返値   : ハイフン個数
		'
		Dim lngCount As Integer
		Dim lngPos As Integer
		
		CHK_TELNO = False
        '20190822 CHG START
        'Call DB_GetEq(DBN_FIXMTA, 1, "507", BtrNormal)
        GetRowsCommon("FIXMTA", "where CTLCD = '507'")
        '20190822 CHG END
        If DBSTAT = 0 Then
			lngCount = 0
			
			lngPos = InStr(1, Trim(pTELNO), "-")
			
			Do While lngPos <> 0
				lngCount = lngCount + 1
				If lngPos + 1 > Len(pTELNO) Then
					lngPos = 0
				Else
					lngPos = InStr(lngPos + 1, Trim(pTELNO), "-")
				End If
			Loop 
			'UPGRADE_WARNING: オブジェクト SSSVal(Trim(DB_FIXMTA.FIXVAL)) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			If lngCount <> SSSVal(Trim(DB_FIXMTA.FIXVAL)) Then
				Exit Function
			End If
		Else
			Exit Function
		End If
		
		CHK_TELNO = True
		
	End Function
End Module