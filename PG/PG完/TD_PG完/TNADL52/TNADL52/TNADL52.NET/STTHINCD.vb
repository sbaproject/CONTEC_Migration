Option Strict Off
Option Explicit On
Module STTHINCD_F81
	'
	' スロット名        : 開始商品コード・画面項目スロット
	' ユニット名        : STTHINCD.F01
	' 記述者            : Standard Library
	' 作成日付          : 1995/10/01
	' 使用プログラム名  : UODPR02 / SODPR02 / SODPR04 / SYKPR15
	'                     NYKPR15
	'                     TNAPR01 / TNAPR02 / TNAPR03 / TNAPR04 / TNAPR05 / TNAPR06
	'                     CSVPR01 / CSVPR02
	'
	
	Function STTHINCD_InitVal() As Object
		'
		'UPGRADE_WARNING: オブジェクト LenWid() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト FillVal() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		STTHINCD_InitVal = FillVal(" ", LenWid(DB_HINMTA.HINCD))
	End Function
	
	Function STTHINCD_Slist(ByRef PP As clsPP, ByVal STTHINCD As Object) As Object
        '
        '    If IsNull(STTHINCD) Then
        '        DB_PARA(DBN_HINMTA).KeyBuf = ""
        '     Else
        '        DB_PARA(DBN_HINMTA).KeyBuf = STTHINCD
        '    End If
        'UPGRADE_WARNING: オブジェクト STTHINCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '20190716 DELL START
        'DB_PARA(DBN_HINMTA).KeyBuf = STTHINCD
        '20190716 DELL END
        '20190712 CHG START
        '      WLSHIN.ShowDialog()
        'WLSHIN.Close()
        WLSHIN4.ShowDialog()
        WLSHIN4.Close()
        '20190712 CHG END
        'UPGRADE_WARNING: オブジェクト PP.SlistCom の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        'UPGRADE_WARNING: オブジェクト STTHINCD_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        STTHINCD_Slist = PP.SlistCom
	End Function
End Module