Option Strict Off
Option Explicit On
Module Common
	
	Public G_strKojoName As String
	
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
	Public Function GP_MsgBox(ByVal enmStyle As enmMsg, Optional ByRef strMsg As String = vbNullString, Optional ByRef strTitle As String = vbNullString) As MsgBoxResult
		
		Dim msgRet As MsgBoxResult
		
		If strMsg <> vbNullString Then
			strMsg = Trim(strMsg)
		End If
		If strTitle <> vbNullString Then
			strTitle = Trim(strTitle)
		End If
		
		Select Case True
			Case enmStyle = enmMsg.Insert
				If strMsg = vbNullString Then
					msgRet = MsgBox("登録します。よろしいですか。", MsgBoxStyle.YesNo + MsgBoxStyle.Information, Trim(strTitle))
				Else
					msgRet = MsgBox(strMsg, MsgBoxStyle.YesNo + MsgBoxStyle.Information, Trim(strTitle))
				End If
			Case enmStyle = enmMsg.Delete
				If strMsg = vbNullString Then
					msgRet = MsgBox("削除します。よろしいですか。", MsgBoxStyle.YesNo + MsgBoxStyle.Information, Trim(strTitle))
				Else
					msgRet = MsgBox(strMsg, MsgBoxStyle.YesNo + MsgBoxStyle.Information, Trim(strTitle))
				End If
			Case enmStyle = enmMsg.DoPrint
				If strMsg = vbNullString Then
					msgRet = MsgBox("印刷します。よろしいですか。", MsgBoxStyle.YesNo + MsgBoxStyle.Information, Trim(strTitle))
				Else
					msgRet = MsgBox(strMsg, MsgBoxStyle.YesNo + MsgBoxStyle.Information, Trim(strTitle))
				End If
			Case enmStyle = enmMsg.Critical
				msgRet = MsgBox(strMsg, MsgBoxStyle.OKOnly + MsgBoxStyle.Critical, Trim(strTitle))
			Case enmStyle = enmMsg.Exclamation
				msgRet = MsgBox(strMsg, MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, Trim(strTitle))
			Case enmStyle = enmMsg.Infomation
				msgRet = MsgBox(strMsg, MsgBoxStyle.OKOnly + MsgBoxStyle.Information, Trim(strTitle))
			Case enmStyle = enmMsg.Execute
				If strMsg = vbNullString Then
					msgRet = MsgBox("処理を行います。よろしいですか。", MsgBoxStyle.YesNo + MsgBoxStyle.Information, Trim(strTitle))
				Else
					msgRet = MsgBox(strMsg, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, Trim(strTitle))
				End If
		End Select
		
		GP_MsgBox = msgRet
	End Function
End Module