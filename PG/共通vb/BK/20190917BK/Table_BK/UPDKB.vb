Option Strict Off
Option Explicit On
Module UPDKB_FM1
    '
    ' スロット名        : 処理モード・画面項目スロット
    ' ユニット名        : UPDKB.FM1
    ' 記述者            : Standard Library
    ' 作成日付          : 1997/05/27
    ' 使用プログラム名  : TOKMT01 /SIRMT01 /NHSMT01 /TANMT01 /HINMT01 /BNKMT01/
    '                     UNTMT01 /SIZMT01 /COLMT01 /MAKMT01 /SOUMT01 /CLSMT01/
    '                     CLSMT02 /TOKMT03 /SIRMT03 /SYSMT02/RATMT51/FIXMT51

    'Function UPDKB_GetEvent() As Object
    '	Dim updkb As String
    '	'
    '	'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_UPDKB() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	updkb = RD_SSSMAIN_UPDKB(PP_SSSMAIN.De)
    '	If updkb = "更新" Then
    '		Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "削除")
    '	ElseIf updkb = "削除" Then 
    '		Call DP_SSSMAIN_UPDKB(PP_SSSMAIN.De, "更新")
    '	End If
    '	'1999/12/13 状態が変更されたことをｅｅｅに通知する
    '	PP_SSSMAIN.InitValStatus = 0
    'End Function
End Module