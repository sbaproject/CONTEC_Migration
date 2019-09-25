Attribute VB_Name = "Functions"
' @(h) Common Module

' @(s)
'
Option Explicit

' ウィンドウにメッセージを送る関数の宣言
Declare Function SendMessage Lib "user32.dll" _
    Alias "SendMessageA" _
   (ByVal hWnd As Long, _
    ByVal Msg As Long, _
    ByVal wParam As Long, _
    lParam As Any) As Long

'API関数の宣言
Private Const WM_KEYDOWN = &H100
Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" _
   (ByVal hWnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long

'コンピュータ名の長さを示す定数の宣言
Private Const MAX_COMPUTERNAME_LENGTH = 15 + 1

' コンピュータ名を取得する関数の宣言
Declare Function GetComputerName Lib "kernel32.dll" Alias "GetComputerNameA" _
    (ByVal lpBuffer As String, nSize As Long) As Long

'***Win32 APIのSHFileOperation()関数。ファイルシステムオブジェクトをコピーします。
'プログラスバー付。
'ファイル操作に関する情報を定義する構造体
Type SHFILEOPSTRUCT
    hWnd                  As Long
    wFunc                 As Long
    pFrom                 As String
    pTo                   As String
    fFlags                As Integer
    fAnyOperationsAborted As Long
    hNameMappings         As Long
    lpszProgressTitle     As String
End Type

'どの操作を行うかを示す定数の宣言
Public Const FO_COPY = &H2&
Public Const FOF_SIMPLEPROGRESS = &H100&
Public Const FOF_NOCONFIRMATION = &H10

' ある位置から別の位置にメモリブロックを移動する関数の宣言
Declare Sub MoveMemory Lib "kernel32.dll" _
    Alias "RtlMoveMemory" _
    (Destination As Any, _
    Source As Any, _
    ByVal Length As Long)

' SHFILEOPSTRUCTのlpszProgressTitleまでのサイズ
Public Const FILEOP_SIZE_ABORTED_TO_PROGRESSTITLE = 12

' ファイルを操作する関数の宣言
Declare Function SHFileOperation Lib "shell32.dll" _
    Alias "SHFileOperationA" _
    (lpFileOp As Any) As Long

'API関数のShowCursor=マウスポインタを消去
Public Declare Function ShowCursor Lib "user32" (ByVal bShow As Long) As Long
'***
    
' AnsiInstrB の 2つの文字列引数に Ansi 文字列と、Ansi ﾊﾞｲﾄ位置を渡します。
Function AnsiInstrB(arg1, arg2, Optional arg3) As Integer
    Dim pos
    If IsNumeric(arg1) Then
    pos = AnsiLenB(AnsiLeftB(arg2, arg1))
    AnsiInstrB = AnsiInstrB(arg1, AnsiStrConv(arg2, vbFromUnicode) _
            , AnsiStrConv(arg3, vbFromUnicode))
    Else
    AnsiInstrB = AnsiInstrB(AnsiStrConv(arg1, vbFromUnicode) _
            , AnsiStrConv(arg2, vbFromUnicode))
    End If
End Function
' AnsiLeftBで処理する前に、ANSI 文字列へ変換し、処理結果を Unicode に戻します。

' MidB で処理する前に、ANSI 文字列へ変換し、処理結果を Unicode に戻します。

' 省略可能な引数をﾁｪｯｸしてから引数を設定します。
Function AnsiMidB(ByVal StrArg As String, ByVal arg1 As Long, Optional arg2) As String
    If IsMissing(arg2) Then
    AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(StrArg, vbFromUnicode) _
            , arg1), vbUnicode)
    Else
    AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(StrArg, vbFromUnicode) _
            , arg1, arg2), vbUnicode)
    End If
End Function
' 16 ﾋﾞｯﾄ環境では、Unicode <-> Ansi 変換は不必要なので、32 ﾋﾞｯﾄの時だけ

Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Long) As String
    AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode) _
            , arg1), vbUnicode)
End Function

' AnsiLenB で処理する前に、ANSI 文字列へ変換し、処理結果を Unicode に戻します。
Function AnsiLenB(ByVal StrArg As String) As Long
    AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
End Function

' AnsiRightBで処理する前に、ANSI 文字列へ変換し、処理結果を Unicode に戻します。
Function AnsiRightB(ByVal StrArg As String, ByVal arg1 As Long) As String
    AnsiRightB = AnsiStrConv(RightB(AnsiStrConv(StrArg, vbFromUnicode) _
            , arg1), vbUnicode)
End Function

' StrConv を呼び出します。
Function AnsiStrConv(StrArg, flag)
#If Win32 Then
    AnsiStrConv = StrConv(StrArg, flag)
#Else
    AnsiStrConv = StrArg
#End If

End Function

Public Function AnsiTrimStringByByteCount(SrcStr As String, DstCount As Long, _
                                        Optional ByRef strRemainString As String) As String
'概要：全角半角まじりのUnicode文字列を、文字をきらないように指定された
'    : 文字数に丸めた文字列を返す
'引数：SrcStr,Input,String,元の文字列
'　　：DstCount,Input,Long,丸めるバイト数
'説明：全角半角まじりのUnicode文字列を、文字をきらないように指定された
'    : 文字数に丸めた文字列を返す
    Dim DstStr      As String
    Dim TmpStr      As String
    Dim SrcStrCount As Long
    Dim i           As Long
    Dim CalcCount   As Long
    Dim TmpCount    As Long
    Dim fmt         As String
    
    DstStr = ""
    SrcStrCount = Len(SrcStr)
    CalcCount = 0
    For i = 1 To SrcStrCount
        TmpStr = Mid(SrcStr, i, 1)
        TmpCount = AnsiLenB(TmpStr)
        If CalcCount + TmpCount > DstCount Then
            GoTo AnsiTrimStringByByteCount_End
        Else
            CalcCount = CalcCount + TmpCount
            DstStr = DstStr & TmpStr
        End If
    Next i
AnsiTrimStringByByteCount_End:
    fmt = "!"
    For i = 1 To DstCount
        fmt = fmt & "@"
    Next
    DstStr = Format(DstStr, fmt)
    AnsiTrimStringByByteCount = Trim$(DstStr)
    strRemainString = AnsiMidB(SrcStr, CalcCount + 1)

End Function

' Api関数を使用しコンピュータ名を取得する。
Public Function GP_GetCmpName() As String
    
Dim strComputerNameBuffer   As String * MAX_COMPUTERNAME_LENGTH
Dim lngComputerNameLength   As Long
Dim lngResult               As Long

    ' コンピュータ名の長さを設定
    lngComputerNameLength = Len(strComputerNameBuffer)
    ' コンピュータ名を取得
    lngResult = GetComputerName(strComputerNameBuffer, lngComputerNameLength)
    ' コンピュータ名を表示
    GP_GetCmpName = Left(strComputerNameBuffer, InStr(strComputerNameBuffer, vbNullChar) - 1)

End Function

'********************'********************'********************'
'***  配列の昇順ソート（クイックソート）                      ***
'********************'********************'********************'
'*【関数名】
'*   SortAsc
'*【引数】
'*   ByRef varData() As Variant = 【入出力】配列
'*   ByVal lngSort_S As Long   = ソート開始添字
'*   ByVal lngSort_E As Long   = ソート終了添字
'*【戻り値】
'*  なし
'*【処理】
'*  クイックソートする。
'********************'********************'********************'
Public Sub SortAsc(ByRef varData() As Variant, _
                    ByVal lngSort_S As Long, _
                    ByVal lngSort_E As Long)
Dim lngI    As Long
Dim lngJ    As Long
Dim varX    As Variant
Dim varW    As Variant

'** クイックソート
    varX = varData((lngSort_S + lngSort_E) \ 2)
    lngI = lngSort_S
    lngJ = lngSort_E
  
    Do
        Do While varData(lngI) < varX
            lngI = lngI + 1
        Loop
        Do While varData(lngJ) > varX
            lngJ = lngJ - 1
        Loop
        If lngI >= lngJ Then
            Exit Do
        End If
        
        varW = varData(lngI)
        varData(lngI) = varData(lngJ)
        varData(lngJ) = varW
    
        lngI = lngI + 1
        lngJ = lngJ - 1
    Loop
    If (lngSort_S < lngI - 1) Then
        Call SortAsc(varData(), lngSort_S, lngI - 1)
    End If
    If (lngSort_E > lngJ + 1) Then
        Call SortAsc(varData(), lngJ + 1, lngSort_E)
    End If

End Sub

'********************'********************'********************'
'***  配列の降順ソート（クイックソート）                      ***
'********************'********************'********************'
'*【関数名】
'*   SortAsc
'*【引数】
'*   ByRef varData() As Variant = 【入出力】配列
'*   ByVal lngSort_S As Long   = ソート開始添字
'*   ByVal lngSort_E As Long   = ソート終了添字
'*【戻り値】
'*  なし
'*【処理】
'*  クイックソートする。
'********************'********************'********************'
Public Sub SortDesc(ByRef varData() As Variant, _
                    ByVal lngSort_S As Long, _
                    ByVal lngSort_E As Long)
Dim lngI    As Long
Dim lngJ    As Long
Dim varX    As Variant
Dim varW    As Variant

'** クイックソート
    varX = varData((lngSort_S + lngSort_E) \ 2)
    lngI = lngSort_S
    lngJ = lngSort_E
  
    Do
        Do While varData(lngI) > varX
            lngI = lngI + 1
        Loop
        Do While varData(lngJ) < varX
            lngJ = lngJ - 1
        Loop
        If lngI >= lngJ Then
            Exit Do
        End If
        
        varW = varData(lngI)
        varData(lngI) = varData(lngJ)
        varData(lngJ) = varW
        
        lngI = lngI + 1
        lngJ = lngJ - 1
    Loop
    
    If (lngSort_S < lngI - 1) Then
        Call SortDesc(varData(), lngSort_S, lngI - 1)
    End If
    If (lngSort_E > lngJ + 1) Then
        Call SortDesc(varData(), lngJ + 1, lngSort_E)
    End If

End Sub

Public Function Nz(ByVal var As Variant, Optional ByVal str As String = "") As Variant

    If IsNull(var) = True Then
        If str = "" Then
            Nz = ""
        Else
            Nz = str
        End If
    
    ElseIf Len(var) < 1 Then
        If str = "" Then
            Nz = ""
        Else
            Nz = str
        End If
    Else
        Nz = var
    End If

End Function

Public Function StChk(ByVal strVar As String) As String

    Dim strWK As String
    Dim strWk2 As String
    Dim lngIndex As Long
    Const C_strQut As String = "'"
    
    'シングルコーテーション1個を2個に置き換える。
    'オラクルのINSERT及び、UPDATE文に使用してください。
    strWK = vbNullString
    If Len(strVar) > 0 Then
        
        'VB5以下で使用する。
'        For lngIndex = 1 To Len(strVar)
'            strWk2 = Mid(strVar, lngIndex, 1)
'            If strWk2 = C_strQut Then
'                strWK = strWK & strWk2 & C_strQut
'            Else
'                strWK = strWK & strWk2
'            End If
'        Next lngIndex
        
        'VB6以上で使用する。
        strWK = Replace(strVar, "'", "''")
    End If

    StChk = strWK

End Function

Public Function DblCChk(ByVal strVar As String) As String

Dim strWK As String
    
    'ダブルコーテーション1個を2個に置き換える。
    'CSVファイル出力時に使用してください。
    strWK = vbNullString
    If Len(strVar) > 0 Then
        strWK = Replace(strVar, """", """""")
    End If

    DblCChk = strWK

End Function

Public Function NumNull(ByVal strVar As String) As String

    'strVar=Nullの場合、''を返す。
    If Trim$(strVar) = vbNullString Then
        NumNull = "''"
    Else
        NumNull = strVar
    End If
    
End Function

'対象日の月末の日付を求める
Public Function MonthEnd(ByVal datDate As Date) As Date
    
Dim datWK   As Date
    
    '対象日の最初の日を求める。
    datWK = CDate(Format$(datDate, "yyyy/mm") & "/01")
    '対象月の最終日を求める。
    MonthEnd = DateAdd("D", -1, DateAdd("M", 1, datWK))

End Function
 
Public Function GP_AddZero(ByVal dblData As Double, ByVal lngKETA As Long) As String

Dim strResult   As String
    
    '頭に0を付けて指定桁数データを返す。
    strResult = Right(String$(lngKETA, "0") & dblData, lngKETA)
    
    GP_AddZero = CStr(strResult)

End Function

Public Function GP_AddSpace(ByVal strData As String, ByVal lngKETA As Long) As String

Dim strResult   As String
    
    '頭にスペースを付けて指定桁数データを返す。
    strResult = AnsiRightB(Space$(lngKETA) & strData, lngKETA)
    
    GP_AddSpace = strResult

End Function

Public Function GP_べき乗(ByVal dblData As Double, lngKETA As Long) As String

Dim dblWK       As Double
Dim lnbResult   As Long
    
    'べき乗計算。
    dblWK = 10 ^ (lngKETA)
    lnbResult = dblData * dblWK
    
    GP_べき乗 = CStr(lnbResult)
    
End Function

'********************************************************************************
' @(f)      : Ctrl_send
'
' 機能      : コントロール移動を移動する。
'
' 返り値    :
'
' 引き数    : KeyAscii As Integer
'
' 備考      :

Function GP_CtrlSend(KeyAscii As Integer, frm As Form)
    If KeyAscii = vbKeyReturn Then
        PostMessage frm.hWnd, WM_KEYDOWN, vbKeyTab, &HF021
        KeyAscii = 0
    End If
End Function

'********************************************************************************
' @(f)      : CtrlHanten
'
' 機能      : コントロールを反転表示する。
'
' 返り値    :
'
' 引き数    : Txt As TextBox : テキストボックス
'
' 備考      :

Public Sub GP_CtrlHanten(Txt As TextBox)
    Txt.SelStart = 0
    Txt.SelLength = LenB(Txt)
End Sub

Public Function GP_StrLengthTrim(ByVal strValue As String, _
                                ByVal lngLen As Long) As Collection
Dim lngMOJI     As Long
Dim lngKETA     As Long
Dim colWK       As Collection
Dim strValue_WK As String

'商品名称の分割
    
    strValue_WK = strValue
    Set colWK = New Collection

    lngMOJI = 0
    lngKETA = 0
    
    Do Until lngKETA >= lngLen
        lngMOJI = lngMOJI + 1
        lngKETA = lngKETA + LenB(StrConv(Mid(strValue_WK, lngMOJI, 1), vbFromUnicode))
    Loop
    
    If lngKETA > lngLen Then
        colWK.Add Left(strValue_WK, lngMOJI - 1)
        colWK.Add Mid(strValue_WK, lngMOJI, AnsiLenB(strValue_WK) - (lngMOJI - 1))
    Else
        colWK.Add Left(strValue_WK, lngMOJI)
        colWK.Add Mid(strValue_WK, lngMOJI + 1, AnsiLenB(strValue_WK) - lngMOJI)
    End If

End Function

