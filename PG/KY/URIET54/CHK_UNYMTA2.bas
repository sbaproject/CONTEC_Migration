Attribute VB_Name = "CHK_UNYMTA2"
Option Explicit

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   名称：  Function CHK_UNYDT
'   概要：  運用日付チェック
'   引数：
'   戻値：　0:正常(運用日付が引数の日付と同一) -1:運用日マスタ無
'　　　　　 1:運用日付が引数の日付より大きい 2:運用日付が引数の日付より小さい
'   備考：連絡票№739
' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
Function CHK_UNYDT(CHK_DT As String)
Dim strSQL          As String
Dim ls_UNYDT        As String
Dim ls_CHK_DT       As String
Dim DB_UNYMTA_BK As TYPE_DB_UNYMTA

On Error GoTo ERR_CHK_UNYDT
    ls_CHK_DT = Trim$(CHK_DT)

    CHK_UNYDT = 9
    LSet DB_UNYMTA_BK = DB_UNYMTA
    strSQL = ""
    strSQL = strSQL & " SELECT * "
    strSQL = strSQL & "   FROM UNYMTA "
    'DBアクセス
    Call DB_GetSQL2(DBN_UNYMTA, strSQL)
    ls_UNYDT = Trim$(DB_UNYMTA.UNYDT)

    If ls_UNYDT = ls_CHK_DT Then
        CHK_UNYDT = 0
    ElseIf ls_UNYDT > ls_CHK_DT Then
        CHK_UNYDT = 1
    Else
        CHK_UNYDT = 2
    End If
                
END_CHK_UNYDT:
    LSet DB_UNYMTA = DB_UNYMTA_BK
    Exit Function

ERR_CHK_UNYDT:
    GoTo END_CHK_UNYDT
End Function



