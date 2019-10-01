Option Strict Off
Option Explicit On
Module CHK_UNYMTA
    '2019/06/21 DELL START
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    '   名称：  Function CHK_UNYDT
    '    '   概要：  運用日付チェック
    '    '   引数：
    '    '   戻値：　0:正常(運用日付が引数の日付と同一) -1:運用日マスタ無
    '    '　　　　　 1:運用日付が引数の日付より大きい 2:運用日付が引数の日付より小さい
    '    '   備考：連絡票№739
    '    ' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
    '    Function CHK_UNYDT(ByRef CHK_DT As String) As Object

    '		Dim strSQL As String
    '		'UPGRADE_WARNING: 構造体 Usr_Ody の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
    '		Dim Usr_Ody As U_Ody
    '		Dim ls_UNYDT As String
    '		Dim ls_CHK_DT As String

    '		On Error GoTo ERR_CHK_UNYDT
    '		ls_CHK_DT = Trim(CHK_DT)

    '		'UPGRADE_WARNING: オブジェクト CHK_UNYDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '		CHK_UNYDT = 9

    '		strSQL = ""
    '		strSQL = strSQL & " SELECT UNYDT "
    '		strSQL = strSQL & "   FROM UNYMTA "

    '		'DBアクセス
    '		Call CF_Ora_CreateDyn(gv_Odb_USR1, Usr_Ody, strSQL)

    '		If CF_Ora_EOF(Usr_Ody) = True Then
    '			'取得データなし
    '			'UPGRADE_WARNING: オブジェクト CHK_UNYDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			CHK_UNYDT = -1
    '			GoTo END_CHK_UNYDT
    '		Else
    '			'UPGRADE_WARNING: オブジェクト CF_Ora_GetDyn() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			ls_UNYDT = CF_Ora_GetDyn(Usr_Ody, "UNYDT", "") '運用日付
    '			If ls_UNYDT = ls_CHK_DT Then
    '				'UPGRADE_WARNING: オブジェクト CHK_UNYDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				CHK_UNYDT = 0
    '			ElseIf ls_UNYDT > ls_CHK_DT Then 
    '				'UPGRADE_WARNING: オブジェクト CHK_UNYDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				CHK_UNYDT = 1
    '			Else
    '				'UPGRADE_WARNING: オブジェクト CHK_UNYDT の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '				CHK_UNYDT = 2
    '			End If
    '		End If

    'END_CHK_UNYDT: 
    '		'クローズ
    '		Call CF_Ora_CloseDyn(Usr_Ody)
    '		Exit Function

    'ERR_CHK_UNYDT: 
    '		GoTo END_CHK_UNYDT
    '	End Function
    '2019/06/21 DELL END
End Module