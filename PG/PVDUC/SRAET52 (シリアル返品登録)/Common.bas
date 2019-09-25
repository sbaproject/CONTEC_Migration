Attribute VB_Name = "Common"
    Option Explicit

Public G_strKojoName    As String

'メッセージボックス
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
'【関 数 名】 GP_MsgBox
'【使用用途】 メッセージボックスの標準化。
'【引    数】
'【返    値】
'【更 新 日】
'【備    考】
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
                msgRet = MsgBox("登録します。よろしいですか。", vbYesNo + vbInformation, Trim$(strTitle))
            Else
                msgRet = MsgBox(strMsg, vbYesNo + vbInformation, Trim$(strTitle))
            End If
        Case enmStyle = Delete
            If strMsg = vbNullString Then
                msgRet = MsgBox("削除します。よろしいですか。", vbYesNo + vbInformation, Trim$(strTitle))
            Else
                msgRet = MsgBox(strMsg, vbYesNo + vbInformation, Trim$(strTitle))
            End If
        Case enmStyle = DoPrint
            If strMsg = vbNullString Then
                msgRet = MsgBox("印刷します。よろしいですか。", vbYesNo + vbInformation, Trim$(strTitle))
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
                msgRet = MsgBox("処理を行います。よろしいですか。", vbYesNo + vbInformation, Trim$(strTitle))
            Else
                msgRet = MsgBox(strMsg, vbYesNo + vbExclamation, Trim$(strTitle))
            End If
    End Select

    GP_MsgBox = msgRet
End Function

