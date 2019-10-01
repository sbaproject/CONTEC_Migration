Option Strict Off
Option Explicit On
Module SSSMAIN

    Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    Sub SSS_CLOSE()

        Call DB_RESET()
        Call DB_End()
        '
        System.Windows.Forms.Application.DoEvents()
        '
        On Error Resume Next
    End Sub

    'add start 20190820 kuwa
    '共通処理用DUMMY
    Public Structure Cls_Dsp_Body_Bus_Inf
        Dim Dummy As String
    End Structure

    'add end 20190820 kuwa

End Module
