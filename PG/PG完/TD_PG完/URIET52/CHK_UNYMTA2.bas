Attribute VB_Name = "CHK_UNYMTA2"
Option Explicit

' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
'   ���́F  Function CHK_UNYDT
'   �T�v�F  �^�p���t�`�F�b�N
'   �����F
'   �ߒl�F�@0:����(�^�p���t�������̓��t�Ɠ���) -1:�^�p���}�X�^��
'�@�@�@�@�@ 1:�^�p���t�������̓��t���傫�� 2:�^�p���t�������̓��t��菬����
'   ���l�F�A���[��739
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
    'DB�A�N�Z�X
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



