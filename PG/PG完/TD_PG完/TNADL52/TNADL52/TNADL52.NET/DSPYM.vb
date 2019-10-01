Option Strict Off
Option Explicit On
Module DSPYM_F01
	'
	' スロット名        : 表示日付（年月）・画面項目スロット
	' ユニット名        : DSPYM.F01
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : TNADL01 / TNADL02 / TNADL03 / TNADL06 / TNADL07 / TNADL08
	'
	Dim NotFirst As Short
	
	'日付が入力された場合に、そのチェックを行う。
	Function DSPYM_CheckC(ByVal DSPYM As Object) As Object
		Dim WL_Formatdate, WL_SMAUPDDT As String
		Dim WL_DSPYM As String
		''2001/05/10 '日付範囲チェックを追加
		Dim Rtn As Short
		'
		If Not CHECK_DATE(DSPYM) Then
			Rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0)
			'UPGRADE_WARNING: オブジェクト DSPYM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DSPYM_CheckC = -1
			Exit Function
		End If
		''
		'UPGRADE_WARNING: オブジェクト DSPYM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		WL_DSPYM = DSPYM & "01日"
		WL_Formatdate = Space(10)
		If IsDate(WL_DSPYM) Then
			WL_Formatdate = VB6.Format(WL_DSPYM, "YYYY年MM月DD日")
			WL_SMAUPDDT = (Left(DB_SYSTBA.SMAUPDDT, 4) & "年" & Mid(DB_SYSTBA.SMAUPDDT, 5, 2) & "月" & Right(DB_SYSTBA.SMAUPDDT, 2)) & "日"
		End If
		If RightWid(WL_DSPYM, 2) <> RightWid(WL_Formatdate, 2) Then
			'UPGRADE_WARNING: オブジェクト DSPYM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DSPYM_CheckC = 11
			'UPGRADE_WARNING: オブジェクト DSPYM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ElseIf DSPYM < WL_SMAUPDDT Then 
			'UPGRADE_WARNING: オブジェクト DSPYM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DSPYM_CheckC = 12
		Else
			'UPGRADE_WARNING: オブジェクト DSPYM_CheckC の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DSPYM_CheckC = 0 '正常終了。
		End If
	End Function
	
	'日付の初期値を設定する。
	Function DSPYM_InitVal(ByVal DSPYM As Object, ByRef PP As clsPP) As Object
		If NotFirst = False Or Not IsDate(DSPYM) Then
			NotFirst = True
			'UPGRADE_WARNING: オブジェクト DSPYM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			DSPYM = VB6.Format(Today, "YYYY年MM月") '本日の日付。
		End If
		'UPGRADE_WARNING: オブジェクト DSPYM の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト DSPYM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DSPYM_InitVal = DSPYM '前の日付。
	End Function
	
	'カーソルを年のところではなく日のところに進ませる。
	Function DSPYM_Skip(ByRef CT_DSPYM As System.Windows.Forms.Control) As Object
        'UPGRADE_WARNING: オブジェクト CT_DSPYM.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190711 CHG START
        'CT_DSPYM.SelStart = 6 'yyyy-mm-dd の dd のところ。
        DirectCast(CT_DSPYM, TextBox).SelectionStart = 6 'yyyy-mm-dd の dd のところ。
        '20190711 CHG END
        'UPGRADE_WARNING: オブジェクト DSPYM_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        DSPYM_Skip = False
	End Function
End Module