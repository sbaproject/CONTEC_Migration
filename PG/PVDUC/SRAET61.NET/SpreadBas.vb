Option Strict Off
Option Explicit On
Module SpreadBas
	
	'===========================================================================
	'【使用用途】 スプレッドの任意のカラムにカーソルを移動させる。
	'【関 数 名】 GP_SpActiveCell
	'【引    数】 ByRef objSpread As Object：スプレッド
	'             ByVal lngCol As Long：列
	'             ByVal lngRow As Long：行
	'【返    値】
	'【更 新 日】
	'【備    考】
	'===========================================================================
	
	Public Sub GP_SpActiveCell(ByRef objSpread As Object, ByVal lngCol As Integer, ByVal lngRow As Integer)
		Dim ActionActiveCell As Object
		With objSpread
            '2019/10/03 DEL START
            '         'UPGRADE_WARNING: オブジェクト objSpread.SetFocus の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '         .SetFocus()
            ''UPGRADE_WARNING: オブジェクト objSpread.Col の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Col = lngCol
            ''UPGRADE_WARNING: オブジェクト objSpread.Row の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Row = lngRow
            ''UPGRADE_WARNING: オブジェクト objSpread.Action の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            ''UPGRADE_WARNING: オブジェクト ActionActiveCell の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '.Action = ActionActiveCell
            '         'UPGRADE_WARNING: オブジェクト objSpread.EditMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '         .EditMode = True
            '2019/10/03 DEL END
        End With
		
	End Sub
	
	'===========================================================================
	'【使用用途】 スプレッドの単一選択モードの設定。
	'【関 数 名】 GP_SpSingleMode
	'【引    数】 ByRef objSpread As Object：スプレッド
	'【返    値】
	'【更 新 日】
	'【備    考】
	'===========================================================================
	
	Public Sub GP_SpSingleMode(ByRef objSpread As Object)
		Dim OperationModeSingle As Object
		Dim ActionClearText As Object
		
		With objSpread
			'UPGRADE_WARNING: オブジェクト objSpread.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = False
			'スプレッドのクリア
			'UPGRADE_WARNING: オブジェクト objSpread.Action の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト ActionClearText の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.Action = ActionClearText
			'表示行=0
			'UPGRADE_WARNING: オブジェクト objSpread.MaxRows の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.MaxRows = 0
			'入力不可。選択のみ。
			'UPGRADE_WARNING: オブジェクト objSpread.OperationMode の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト OperationModeSingle の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.OperationMode = OperationModeSingle
			'選択セルのセル色。
			'UPGRADE_WARNING: オブジェクト objSpread.SelBackColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.SelBackColor = &HFF8080
			'偶数行及び奇数行の背景色。
			'UPGRADE_WARNING: オブジェクト objSpread.SetOddEvenRowColor の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call .SetOddEvenRowColor(System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White), System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black), &H8000000F, System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black))
			'UPGRADE_WARNING: オブジェクト objSpread.ReDraw の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			.ReDraw = True
		End With
		
	End Sub
End Module