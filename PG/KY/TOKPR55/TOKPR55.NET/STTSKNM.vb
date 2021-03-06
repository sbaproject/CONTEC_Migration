Option Strict Off
Option Explicit On
Module STTSKNM_F51
	'
	' スロット名        : 仕切用商品群名称・画面項目スロット
	' ユニット名        : SKNM.F51
	' 記述者            : Standard Library
	' 作成日付          : 2006/08/17
	' 使用プログラム名  : NYKPR52
	'
	
	Function STTSKNM_Derived(ByVal STTSKNM As Object, ByVal STTSKCD As Object, ByVal De_Index As Object) As Object
		
		'UPGRADE_WARNING: オブジェクト STTSKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(STTSKCD) = "" Then
			DB_MEIMTA.MEINMA = " "
		Else
			Call MEIMTA_RClear()
			'UPGRADE_WARNING: オブジェクト STTSKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			Call DB_GetEq(DBN_MEIMTA, 1, "043" & STTSKCD & Space(Len(DB_MEIMTA.MEICDA) - Len(STTSKCD)) & Space(Len(DB_MEIMTA.MEICDB)), BtrNormal)
		End If
		'UPGRADE_WARNING: オブジェクト STTSKNM_Derived の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTSKNM_Derived = DB_MEIMTA.MEINMA
		
	End Function
	Function STTSKNM_InitVal(ByVal STTSKNM As Object, ByVal STTSKCD As Object, ByVal De_Index As Object) As Object
		'If Trim(DB_MEIMTA.MEICDA) = "" Then
		'UPGRADE_WARNING: オブジェクト STTSKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If Trim(STTSKCD) = "" Then
			'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			'UPGRADE_WARNING: オブジェクト FillVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			STTSKNM_InitVal = FillVal(" ", LenWid(DB_MEIMTA.MEINMA))
		Else
			'UPGRADE_WARNING: オブジェクト STTSKNM_InitVal の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			STTSKNM_InitVal = DB_MEIMTA.MEINMA
		End If
	End Function
End Module