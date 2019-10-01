Option Strict Off
Option Explicit On
Imports System.Text
Imports System.IO
Module GET_DSPSTR
    'ADD START FKS)KAMATA 2004/04/29
    Public Sav_Font As String = Space(1)
    Public Sav_Font2 As String
    'ADD E N D FKS)KAMATA 2004/04/29
    'Function: To Get attributes about One Item.
    Public Function GETDSPSTR(ByRef Val1 As String, ByRef Capt As String, ByRef Font As String, ByRef FSize As Integer, ByRef FepMode As Integer, ByRef DefFPath As String) As Object
        '---------------------------------------------------------------
        Dim ret As Integer
        Dim FileNo As Integer
        Dim TextLine As String
        Dim TextLine2 As Object
        Dim PosTab, i, cnt As Integer
        Dim Buff(10) As String
        Dim ItemID As String
        Dim Reader As StreamReader
        'V10 ADD START FKS TAKAGI 2003/02/21
        Dim LangCodePath As String
        'V10 ADD E N D FKS TAKAGI 2003/02/21
        '---------------------------------------------------------------
        'Initiarizing...
        ret = 0
        'UPGRADE_NOTE: Erase は System.Array.Clear にアップグレードされました。 詳細については、'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1061"' をクリックしてください。
        System.Array.Clear(Buff, 0, Buff.Length)

        ItemID = UCase(Val1)

        'Open File
        On Error GoTo EndLabel2
        'FileNo = FreeFile()
        'FileOpen(FileNo, VB6.GetPath & "\" & DefFPath, OpenMode.Input)
        'V10 ADD START FKS TAKAGI 2003/02/21
        'If Len(Trim(User_Lang)) = 0 Then
        '    Call GetCOMMAND()
        'End If
        'LangCodePath = "LANG\" & User_Lang & "\" & DefFPath
        'V10 ADD E N D FKS TAKAGI 2003/02/21
        'V10 CHG START FKS TAKAGI 2003/02/21
        'Reader = New StreamReader(New FileStream(VB6.GetPath & "\" & DefFPath, _
        '          FileMode.Open, FileAccess.Read), _
        '          System.Text.Encoding.GetEncoding("Unicode"))
        Reader = New StreamReader(New FileStream(VB6.GetPath & "\" & LangCodePath, _
                  FileMode.Open, FileAccess.Read), _
                  System.Text.Encoding.GetEncoding("Unicode"))
        'V10 CHG E N D FKS TAKAGI 2003/02/21

        'Read File
        'Do While Not EOF(FileNo)
        Do
            'TextLine2 = ASCIIEncoding.GetEncoding(LineInput(FileNo))
            'TextLine = LineInput(FileNo)
            TextLine = Reader.ReadLine()
            If TextLine = Nothing Then Exit Do
            'First, getting ItemID...
            'TextLine = GetBytes(TextLine2)
            PosTab = InStr(1, TextLine, Chr(9), 1)
            If (PosTab = 0) Then
                'When TBA-code is not found, Read next TextLine.
                GoTo NextLoop
            Else
                'ItemID is got!
                If (UCase(ItemID) <> UCase(Mid(TextLine, 1, PosTab - 1))) Then
                    GoTo NextLoop
                End If
            End If


            'Adding TAB at the last Point of TextLine (Attention!!)
            TextLine = TextLine & Chr(9)


            'Analysing one TextLine...
            i = PosTab + 1 '<-- important!
            cnt = 0
            Do While (i <= Len(TextLine))

                'Getting the position of TAB-code.
                PosTab = InStr(i, TextLine, Chr(9), 1)
                If (PosTab <> 0) Then
                    'Setting attribute...
                    Buff(cnt) = Mid(TextLine, i, PosTab - i)
                    cnt = cnt + 1
                    i = PosTab + 1 '<-- progressing count...
                Else
                    'Exit all loop.
                    GoTo EndLabel
                End If

            Loop

NextLoop:
        Loop

EndLabel:
        'Close File
        'FileClose(FileNo)
        Reader.Close()

        'Setting Value
        Capt = Buff(0)
        'CHG START FKS)KAMATA 2004/04/29
        'Font = Buff(1)
        If Len(Trim(Buff(1))) = 0 Then
            Font = Buff(1)
        Else
            If Len(Trim(Sav_Font)) = 0 Or Trim(Sav_Font) <> Trim(Buff(1)) Then
                Dim ffs As FontFamily() = FontFamily.Families
                Dim ff As FontFamily
                Dim FONT_FLG As Boolean = False

                For Each ff In ffs
                    If Trim(Buff(1)) = Trim(ff.Name) Then
                        Font = Buff(1)
                        FONT_FLG = True
                        Exit For
                    End If
                Next ff

                'If FONT_FLG = False Then
                '    Select Case User_Lang
                '        Case "JA"
                '            Font = "MS UI Gothic"
                '        Case "US"
                '            Font = "Times New Roman"
                '        Case "CN"
                '            Font = "SimSun & NSimSun"
                '        Case "TW"
                '            Font = "SimSun & NSimSun"
                '        Case "KO"
                '            Font = "Batang & BatangChe & Gungsuh & GungsuhChe"
                '    End Select
                'End If

                Sav_Font = Trim(Buff(1))
                Sav_Font2 = Font
            Else
                Font = Sav_Font2
            End If
        End If
        'CHG E N D FKS)KAMATA 2004/04/29
        ' 20030226 Modify Start T.Nakano
        'FSize = CShort(Buff(2))
        'FepMode = CShort(Buff(3))
        If (Buff(2) = "") Then
            FSize = 0
        Else
            FSize = CInt(Buff(2))
        End If
        If (Buff(3) = "") Then
            FepMode = 0
        Else
            FepMode = CInt(Buff(3))
        End If
        ' 20030226 Modify End

        'Setting Return Code
        'UPGRADE_WARNING: オブジェクト GETDSPSTR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"' をクリックしてください。
        GETDSPSTR = ret
        'Succsessfully exit
        GoTo EndLabel99

EndLabel2:
        'Error occured at open file.
        MsgBox("Can not open file or Item definition is wrong." & vbCr & vbCr & "File Name :" & DefFPath & vbCr & "Path : " & VB6.GetPath & "\" & LangCodePath & vbCr & "ItemID :" & ItemID)

        'UPGRADE_WARNING: オブジェクト GETDSPSTR の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC/commoner/redir/redirect.htm?keyword="vbup1037"' をクリックしてください。
        GETDSPSTR = -2

EndLabel99:

	End Function
End Module
