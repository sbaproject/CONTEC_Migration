Option Strict Off
Option Explicit On
Module SSSMAIN0001
	'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
	'
	'単プロジェクトごとの共通ライブラリ
	Public PP_SSSMAIN As clsPP
	Public CP_SSSMAIN(6 + 0 + 0 + 1) As clsCP
	Public CQ_SSSMAIN(6) As String
	
	'UPGRADE_WARNING: 構造体 pm_All の配列は、使用する前に初期化する必要があります。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"' をクリックしてください。
	Public pm_All As Cls_All
	'INIファイル読込用定数
	Public Const pc_strIni_OUTNAME As String = "OUT_NAME"
	Public Const pc_strIni_OUTTYPE As String = "OUT_TYPE"
	Public Const pc_strIni_TABCHAR As String = "TAB_CHAR"
	
	'INIファイル読込内容格納変数
	Public gv_strOUT_NAME As String '出力ファイル名
	Public gv_strOUT_TYPE As String '出力ファイル拡張子
	Public gv_strTAB_CHAR As String '区切り文字
	
	Public Sub SSS_CLOSE()
		
	End Sub
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CopyFiles
	'   概要：  ファイルコピー処理
	'   引数：　なし
	'   戻値：　0 : 正常終了　1 : コピー不可  8 : INIファイルエラー 9 : 異常終了
	'   備考：　画面にて指定されたファイルをDBサーバーの規定のフォルダに移動させる
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CopyFiles(ByVal strinfile As String, ByRef stroutfile As String) As Short
		
		'ファイルオブジェクト生成
		Dim objfso As New Scripting.FileSystemObject
		Dim objoldFile As Scripting.File '元のファイルアクセス用オブジェクト
		Dim strfile As String
		Dim strext As String
		Dim strSVfolder As String 'サーバフォルダ名
		
		On Error GoTo F_Ctl_CopyFiles_Err
		
		'サーバのフォルダ名を取得
		'strSVfolder = "\\ammfmtes\TES\"
		If Get_INIFile_String(My.Application.Info.DirectoryPath & IIf(Right(My.Application.Info.DirectoryPath, 1) = "\", "", "\") & SSS_PrgId & ".ini", "PATH", "ServerTXT", strSVfolder) Then
			If Len(strSVfolder) = 0 Then
				F_Ctl_CopyFiles = 8
				Exit Function
			End If
		Else
			F_Ctl_CopyFiles = 8
			Exit Function
		End If
		F_Ctl_CopyFiles = 9
		
		'ファイル名取得
		objoldFile = objfso.GetFile(strinfile)
		stroutfile = strSVfolder & IIf(Right(strSVfolder, 1) = "\", "", "\") & objoldFile.NAME
		
		'コピー先のファイル存在チェック
		If objfso.FileExists(stroutfile) Then
			F_Ctl_CopyFiles = 1
			Exit Function
		End If
		
		
		'ファイルコピー
		objoldFile.Copy(stroutfile, False)
		
		F_Ctl_CopyFiles = 0
		
F_Ctl_CopyFiles_End: 
		
		'UPGRADE_NOTE: オブジェクト objfso をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objfso = Nothing
		'UPGRADE_NOTE: オブジェクト objoldFile をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objoldFile = Nothing
		
		Exit Function
F_Ctl_CopyFiles_Err: 
		
		'UPGRADE_NOTE: オブジェクト objfso をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objfso = Nothing
		'UPGRADE_NOTE: オブジェクト objoldFile をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objoldFile = Nothing
		Exit Function
		
	End Function
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_CopyFiles2
	'   概要：  ファイルコピー処理
	'   引数：  strinfile   サーバのファイル名
	'           stroutFolderローカルのフォルダ名
	'   戻値：　0 : 正常終了　1 : コピー不可  8 : INIファイルエラー 9 : 異常終了
	'   備考：　DBサーバーの規定のファイルを画面指定されたフォルダに移動させる
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_CopyFiles2(ByRef strinfile As String, ByVal stroutFolder As String) As Short
		
		'ファイルオブジェクト生成
		Dim objfso As New Scripting.FileSystemObject
		Dim objoldFile As Scripting.File '元のファイルアクセス用オブジェクト
		Dim strfile As String
		Dim strext As String
		Dim strSVfolder As String 'サーバフォルダ名
		Dim bolflg As Boolean
		
		On Error GoTo F_Ctl_CopyFiles_Err
		bolflg = False
		'サーバのフォルダ名を取得
		'strSVfolder = "\\ammfmtes\TES\DAT\RCV"
		If Get_INIFile_String(My.Application.Info.DirectoryPath & IIf(Right(My.Application.Info.DirectoryPath, 1) = "\", "", "\") & SSS_PrgId & ".ini", "PATH", "ServerLOG", strSVfolder) Then
			If Len(strSVfolder) = 0 Then
				F_Ctl_CopyFiles2 = 8
				Exit Function
			End If
		Else
			F_Ctl_CopyFiles2 = 8
			Exit Function
		End If
		F_Ctl_CopyFiles2 = 9
		'ファイル名取得
		strfile = Trim(strSVfolder & IIf(Right(strSVfolder, 1) = "\", "", "\") & strinfile)
		
		'コピー元のファイル存在チェック
		If objfso.FileExists(strfile) Then
			'ファイルコピー
			objfso.CopyFile(strfile, stroutFolder & IIf(Right(stroutFolder, 1) = "\", "", "\") & Trim(strinfile))
			bolflg = True
		End If
		strinfile = strfile
		F_Ctl_CopyFiles2 = 0
		
F_Ctl_CopyFiles_End: 
		
		'UPGRADE_NOTE: オブジェクト objfso をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objfso = Nothing
		'UPGRADE_NOTE: オブジェクト objoldFile をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objoldFile = Nothing
		
		Exit Function
F_Ctl_CopyFiles_Err: 
		
		'UPGRADE_NOTE: オブジェクト objfso をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objfso = Nothing
		'UPGRADE_NOTE: オブジェクト objoldFile をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objoldFile = Nothing
		Exit Function
		
	End Function
	
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function F_Ctl_DeleteFiles
	'   概要：  ファイル削除処理
	'   引数：　なし
	'   戻値：　0 : 正常終了　9 : 異常終了
	'   備考：　DBサーバーの規定のフォルダからファイルを削除する
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function F_Ctl_DeleteFiles(ByVal strfile As String) As Short
		
		Dim objfso As Scripting.FileSystemObject
		Dim objFile As Object 'ヘッダファイルアクセス用オブジェクト
		
		On Error GoTo F_Ctl_DeleteFiles_Err
		
		F_Ctl_DeleteFiles = 9
		
		'ファイルオブジェクト生成
		objfso = CreateObject("Scripting.FileSystemObject")
		
		'ヘッダファイル削除
		If objfso.FileExists(strfile) Then
			objFile = objfso.GetFile(strfile)
			'UPGRADE_WARNING: オブジェクト objFile.Delete の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
			objFile.Delete()
		End If
		
		
		F_Ctl_DeleteFiles = 0
		
F_Ctl_DeleteFiles_End: 
		
		'UPGRADE_NOTE: オブジェクト objfso をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objfso = Nothing
		'UPGRADE_NOTE: オブジェクト objFile をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objFile = Nothing
		
		Exit Function
		
F_Ctl_DeleteFiles_Err: 
		
		'UPGRADE_NOTE: オブジェクト objfso をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objfso = Nothing
		'UPGRADE_NOTE: オブジェクト objFile をガベージ コレクトするまでこのオブジェクトを破棄することはできません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"' をクリックしてください。
		objFile = Nothing
		
		Exit Function
		
	End Function
	'INIファイルの取得
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	'   名称：  Function Get_INIFile_String
	'   概要：  INIファイルの取得
	'   引数：　strFileName ファイル名
	'           strSection  セクション名
	'           strKey      キー名
	'           strValue    取得値
	'   戻値：　True : 正常終了　False : 異常終了
	'   備考：　指定iniファイルから指定の値を取得する。
	' ======+=======+=======+=======+=======+=======+=======+=======+=======+=======+
	Public Function Get_INIFile_String(ByVal strFileName As String, ByVal strSection As String, ByVal strKey As String, ByRef strValue As String) As Boolean
		'バッファ文字列を256文字に設定
		Dim strRetValue As New VB6.FixedLengthString(256)
		On Error GoTo err_Get_INIFile_String
		'INIファイルから値を取得する。
		If GetPrivateProfileString(strSection, strKey, "", strRetValue.Value, Len(strRetValue.Value), strFileName) Then
			If InStr(strRetValue.Value, vbNullChar) > 0 Then
				strValue = Trim(Left(strRetValue.Value, InStr(strRetValue.Value, vbNullChar) - 1))
			Else
				strValue = Trim(strRetValue.Value)
			End If
			Get_INIFile_String = True
		Else
			Get_INIFile_String = False
		End If
		Exit Function
err_Get_INIFile_String: 
		Get_INIFile_String = False
	End Function
End Module