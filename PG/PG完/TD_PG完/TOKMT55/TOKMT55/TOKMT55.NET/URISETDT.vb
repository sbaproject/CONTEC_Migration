Option Strict Off
Option Explicit On
'20190718 CHG START
'Module URISETDT_F51
'	'
'	' スロット名        : 販売単価設定日付・画面項目スロット
'	' ユニット名        : URISETDT.F51
'	' 記述者            : Standard Library
'	' 作成日付          : 2006/06/14
'	' 使用プログラム名  : HINMT51
'	'
'	Function URISETDT_Check(ByVal URISETDT As Object, ByVal SKHINGRP As Object, ByVal RNKCD As Object, ByVal De_INDEX As Object) As Object
'		Dim rtn As Short
'		'
'		'UPGRADE_WARNING: オブジェクト SKHINGRP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'		If Trim(SKHINGRP) = "" Then Exit Function

'		'UPGRADE_WARNING: オブジェクト URISETDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'		URISETDT_Check = 0
'		'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
'		If IsDbNull(URISETDT) Then
'			rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' 日付に誤りがあります
'			'UPGRADE_WARNING: オブジェクト URISETDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'			URISETDT_Check = -1

'		Else
'			If Not IsDate(URISETDT) Then
'				rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' 日付に誤りがあります
'				'UPGRADE_WARNING: オブジェクト URISETDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'				URISETDT_Check = -1
'				'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'				URISETDT = ""
'			Else
'				'最新データ存在ﾁｪｯｸ
'				'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'				If CInt(VB6.Format(URISETDT, "YYYYMMDD")) < CInt(DB_UNYMTA.UNYDT) Then
'					'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'					'UPGRADE_WARNING: オブジェクト RNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'					'UPGRADE_WARNING: オブジェクト SKHINGRP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'					Call DB_GetGrEq(DBN_RNKMTA, 1, SKHINGRP & RNKCD & VB6.Format(URISETDT, "YYYYMMDD"), BtrNormal)
'					'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'					'UPGRADE_WARNING: オブジェクト RNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'					'UPGRADE_WARNING: オブジェクト SKHINGRP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'					If (DBSTAT = 0) And (DB_RNKMTA.SKHINGRP = SKHINGRP) And (DB_RNKMTA.RNKCD = RNKCD) And (DB_RNKMTA.URISETDT > VB6.Format(URISETDT, "YYYYMMDD")) Then
'						rtn = DSP_MsgBox(SSS_CONFRM, "TOKMT55", 0) '既に新しい日付で登録済の為エラー
'						'UPGRADE_WARNING: オブジェクト URISETDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'						URISETDT_Check = -1
'					End If
'				End If
'			End If
'		End If

'		'UPGRADE_WARNING: オブジェクト URISETDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'		If URISETDT_Check = 0 Then
'			'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'			'UPGRADE_WARNING: オブジェクト RNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'			'UPGRADE_WARNING: オブジェクト SKHINGRP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'			Call DB_GetEq(DBN_RNKMTA, 1, SKHINGRP & RNKCD & VB6.Format(URISETDT, "YYYYMMDD"), BtrNormal)
'			If DBSTAT = 0 Then
'				'UPGRADE_WARNING: オブジェクト De_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'				Call SCR_FromMfil(De_INDEX)
'				If DB_RNKMTA.DATKB = "9" Then
'					'UPGRADE_WARNING: オブジェクト De_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'					Call DP_SSSMAIN_UPDKB(De_INDEX, "削除")
'				Else
'					'UPGRADE_WARNING: オブジェクト De_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'					Call DP_SSSMAIN_UPDKB(De_INDEX, "更新")
'				End If
'			Else
'				'UPGRADE_WARNING: オブジェクト De_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'				Call DP_SSSMAIN_UPDKB(De_INDEX, "追加")
'			End If
'		End If

'	End Function

'	Function URISETDT_Skip(ByRef CT_URISETDT As System.Windows.Forms.Control, ByVal URISETDT As Object) As Object
'		'
'		'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'		If Trim(URISETDT) <> "" Then
'            'UPGRADE_WARNING: オブジェクト CT_URISETDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'            '20190718 CHG START
'            'CT_URISETDT.SelStart = 8 'yyyy-mm-dd の dd にカーソルを移動する。
'            DirectCast(CT_URISETDT, TextBox).SelectionStart = 8 'yyyy-mm-dd の dd にカーソルを移動する。
'            '20190718 CHG END
'        End If
'		'UPGRADE_WARNING: オブジェクト URISETDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'		URISETDT_Skip = False
'	End Function

'	Function URISETDT_Slist(ByVal URISETDT As Object, ByRef PP As clsPP) As Object
'		'
'		'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'		Set_date.Value = URISETDT
'		WLS_DATE.ShowDialog()
'		WLS_DATE.Close()
'		'UPGRADE_WARNING: オブジェクト URISETDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
'		URISETDT_Slist = Set_date.Value
'	End Function
'End Module
Module URISETDT_F51
    '
    ' スロット名        : 販売単価設定日付・画面項目スロット
    ' ユニット名        : URISETDT.F51
    ' 記述者            : Standard Library
    ' 作成日付          : 2006/06/14
    ' 使用プログラム名  : HINMT51
    '
    Function URISETDT_Check(ByVal URISETDT As Object, ByVal SKHINGRP As Object, ByVal RNKCD As Object, ByVal De_INDEX As Object) As Object
        Dim rtn As Short
        '
        'UPGRADE_WARNING: オブジェクト SKHINGRP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(SKHINGRP) = "" Then Exit Function

        'UPGRADE_WARNING: オブジェクト URISETDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        URISETDT_Check = 0
        'UPGRADE_WARNING: Null/IsNull() の使用が見つかりました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"' をクリックしてください。
        If IsDBNull(URISETDT) Then
            rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' 日付に誤りがあります
            'UPGRADE_WARNING: オブジェクト URISETDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            URISETDT_Check = -1

        Else
            If Not IsDate(URISETDT) Then
                rtn = DSP_MsgBox(SSS_ERROR, "DATE", 0) ' 日付に誤りがあります
                'UPGRADE_WARNING: オブジェクト URISETDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                URISETDT_Check = -1
                'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                URISETDT = ""
            Else
                '最新データ存在ﾁｪｯｸ
                'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If CInt(VB6.Format(URISETDT, "YYYYMMDD")) < CInt(DB_UNYMTA.UNYDT) Then
                    'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト SKHINGRP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call DB_GetGrEq(DBN_RNKMTA2, 1, SKHINGRP & RNKCD & VB6.Format(URISETDT, "YYYYMMDD"), BtrNormal)
                    'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト RNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    'UPGRADE_WARNING: オブジェクト SKHINGRP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    If (DBSTAT = 0) And (DB_RNKMTA2.SKHINGRP = SKHINGRP) And (DB_RNKMTA2.RNKCD = RNKCD) And (DB_RNKMTA2.URISETDT > VB6.Format(URISETDT, "YYYYMMDD")) Then
                        rtn = DSP_MsgBox(SSS_CONFRM, "TOKMT55", 0) '既に新しい日付で登録済の為エラー
                        'UPGRADE_WARNING: オブジェクト URISETDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                        URISETDT_Check = -1
                    End If
                End If
            End If
        End If

        'UPGRADE_WARNING: オブジェクト URISETDT_Check の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If URISETDT_Check = 0 Then
            'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト RNKCD の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: オブジェクト SKHINGRP の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            Call DB_GetEq(DBN_RNKMTA2, 1, SKHINGRP & RNKCD & VB6.Format(URISETDT, "YYYYMMDD"), BtrNormal)
            If DBSTAT = 0 Then
                'UPGRADE_WARNING: オブジェクト De_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call SCR_FromMfil(De_INDEX)
                If DB_RNKMTA2.DATKB = "9" Then
                    'UPGRADE_WARNING: オブジェクト De_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call DP_SSSMAIN_UPDKB(De_INDEX, "削除")
                Else
                    'UPGRADE_WARNING: オブジェクト De_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                    Call DP_SSSMAIN_UPDKB(De_INDEX, "更新")
                End If
            Else
                'UPGRADE_WARNING: オブジェクト De_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                Call DP_SSSMAIN_UPDKB(De_INDEX, "追加")
            End If
        End If

    End Function

    Function URISETDT_Skip(ByRef CT_URISETDT As System.Windows.Forms.Control, ByVal URISETDT As Object) As Object
        '
        'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If Trim(URISETDT) <> "" Then
            'UPGRADE_WARNING: オブジェクト CT_URISETDT.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '20190718 CHG START
            'CT_URISETDT.SelStart = 8 'yyyy-mm-dd の dd にカーソルを移動する。
            DirectCast(CT_URISETDT, TextBox).SelectionStart = 8 'yyyy-mm-dd の dd にカーソルを移動する。
            '20190718 CHG END
        End If
        'UPGRADE_WARNING: オブジェクト URISETDT_Skip の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        URISETDT_Skip = False
    End Function

    Function URISETDT_Slist(ByVal URISETDT As Object, ByRef PP As clsPP) As Object
        '
        'UPGRADE_WARNING: オブジェクト URISETDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        Set_date.Value = URISETDT
        WLS_DATE.ShowDialog()
        WLS_DATE.Close()
        'UPGRADE_WARNING: オブジェクト URISETDT_Slist の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        URISETDT_Slist = Set_date.Value
    End Function
End Module
'20190718 CHG END