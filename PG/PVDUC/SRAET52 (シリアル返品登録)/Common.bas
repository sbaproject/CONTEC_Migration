Attribute VB_Name = "Common"
    Option Explicit

Public G_strKojoName    As String

'���b�Z�[�W�{�b�N�X
Public Enum enmMsg
    Insert
    DoPrint
    Exclamation
    Critical
    Infomation
    Execute
    Delete
End Enum

'===========================================================================
'�y�� �� ���z GP_MsgBox
'�y�g�p�p�r�z ���b�Z�[�W�{�b�N�X�̕W�����B
'�y��    ���z
'�y��    �l�z
'�y�X �V ���z
'�y��    �l�z
'===========================================================================
Public Function GP_MsgBox(ByVal enmStyle As enmMsg, _
                        Optional strMsg As String = vbNullString, _
                        Optional strTitle As String = vbNullString) As VbMsgBoxResult

Dim msgRet      As VbMsgBoxResult

    If strMsg <> vbNullString Then
        strMsg = Trim(strMsg)
    End If
    If strTitle <> vbNullString Then
        strTitle = Trim(strTitle)
    End If

    Select Case True
        Case enmStyle = Insert
            If strMsg = vbNullString Then
                msgRet = MsgBox("�o�^���܂��B��낵���ł����B", vbYesNo + vbInformation, Trim$(strTitle))
            Else
                msgRet = MsgBox(strMsg, vbYesNo + vbInformation, Trim$(strTitle))
            End If
        Case enmStyle = Delete
            If strMsg = vbNullString Then
                msgRet = MsgBox("�폜���܂��B��낵���ł����B", vbYesNo + vbInformation, Trim$(strTitle))
            Else
                msgRet = MsgBox(strMsg, vbYesNo + vbInformation, Trim$(strTitle))
            End If
        Case enmStyle = DoPrint
            If strMsg = vbNullString Then
                msgRet = MsgBox("������܂��B��낵���ł����B", vbYesNo + vbInformation, Trim$(strTitle))
            Else
                msgRet = MsgBox(strMsg, vbYesNo + vbInformation, Trim$(strTitle))
            End If
        Case enmStyle = Critical
                msgRet = MsgBox(strMsg, vbOKOnly + vbCritical, Trim$(strTitle))
        Case enmStyle = Exclamation
                msgRet = MsgBox(strMsg, vbOKOnly + vbExclamation, Trim$(strTitle))
        Case enmStyle = Infomation
                msgRet = MsgBox(strMsg, vbOKOnly + vbInformation, Trim$(strTitle))
        Case enmStyle = Execute
            If strMsg = vbNullString Then
                msgRet = MsgBox("�������s���܂��B��낵���ł����B", vbYesNo + vbInformation, Trim$(strTitle))
            Else
                msgRet = MsgBox(strMsg, vbYesNo + vbExclamation, Trim$(strTitle))
            End If
    End Select

    GP_MsgBox = msgRet
End Function

