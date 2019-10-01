Option Strict Off
Option Explicit On
Module JDNLINNO_O01
	'
	' スロット名        : 受注伝票引当処理・オプショナルスロット
	' ユニット名        : JDNLINNO.O01
	' 記述者            : Standard Library
	' 作成日付          : 2001/12/19
	' 使用プログラム名  : URIET16
	'
	
	' 商品コード変更時に, 引当情報がクリアされてしまうことへの警告。
	' HINCD_CheckC から呼ばれる。
	Function Check_Link(ByVal DE_INDEX As Object) As Boolean
		Dim JDNLINNO As String
		Dim Msg As String
		
		Check_Link = True
		'引当行の変更を警告する
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		'UPGRADE_WARNING: オブジェクト RD_SSSMAIN_JDNLINNO() の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		JDNLINNO = RD_SSSMAIN_JDNLINNO(DE_INDEX)
		'UPGRADE_WARNING: オブジェクト SSSVal(JDNLINNO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(JDNLINNO) <> 0 Then
			Msg = "商品コードを変更すると受注伝票引当の対象外となります。" & vbCrLf
			Msg = Msg & "変更を中止しますか？"
			If MsgBox(Msg, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "警告") = MsgBoxResult.Yes Then
				Check_Link = False
			End If
		End If
	End Function
	
	' 商品コードが変更された場合に, 受注伝票行番号と RECNO をクリアする。
	' HINCD_CheckC から呼ばれる。
	Function Clear_Link(ByVal DE_INDEX As Object) As Object
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call DP_SSSMAIN_JDNLINNO(DE_INDEX, "")
		'UPGRADE_WARNING: オブジェクト DE_INDEX の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Call DP_SSSMAIN_RECNO(DE_INDEX, "")
	End Function
	
	' 行クリア時に, 引当情報がクリアされてしまうことへの警告。
	Function ClearDe_GetEvent(ByVal DE_INDEX As Object, ByVal JDNLINNO As Object) As Object
		
		Dim Msg As String
		
		'UPGRADE_WARNING: オブジェクト ClearDe_GetEvent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		ClearDe_GetEvent = True
		
		'引当行の初期化を警告する
		'UPGRADE_WARNING: オブジェクト SSSVal(JDNLINNO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(JDNLINNO) <> 0 Then
			Msg = "この行を初期化すると受注伝票引当の対象外となります。" & vbCrLf
			Msg = Msg & "行初期化を中止しますか？"
			If MsgBox(Msg, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "警告") = MsgBoxResult.Yes Then
				'UPGRADE_WARNING: オブジェクト ClearDe_GetEvent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				ClearDe_GetEvent = False
			End If
		End If
	End Function
	
	' 行削除時に, 引当情報がクリアされてしまうことへの警告。
	Function DeleteDe_GetEvent(ByVal DE_INDEX As Object, ByVal JDNLINNO As Object) As Object
		Dim Msg As String
		
		'UPGRADE_WARNING: オブジェクト DeleteDe_GetEvent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		DeleteDe_GetEvent = True
		
		'引当行の削除を警告する
		'UPGRADE_WARNING: オブジェクト SSSVal(JDNLINNO) の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		If SSSVal(JDNLINNO) <> 0 Then
			Msg = "この行を削除すると受注伝票引当の対象外となります。" & vbCrLf
			Msg = Msg & "行削除を中止しますか？"
			If MsgBox(Msg, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "警告") = MsgBoxResult.Yes Then
				'UPGRADE_WARNING: オブジェクト DeleteDe_GetEvent の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
				DeleteDe_GetEvent = False
			End If
		End If
	End Function
End Module