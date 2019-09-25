Attribute VB_Name = "Functions"
' @(h) Common Module

' @(s)
'
Option Explicit

' �E�B���h�E�Ƀ��b�Z�[�W�𑗂�֐��̐錾
Declare Function SendMessage Lib "user32.dll" _
    Alias "SendMessageA" _
   (ByVal hWnd As Long, _
    ByVal Msg As Long, _
    ByVal wParam As Long, _
    lParam As Any) As Long

'API�֐��̐錾
Private Const WM_KEYDOWN = &H100
Private Declare Function PostMessage Lib "user32" Alias "PostMessageA" _
   (ByVal hWnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long

'�R���s���[�^���̒����������萔�̐錾
Private Const MAX_COMPUTERNAME_LENGTH = 15 + 1

' �R���s���[�^�����擾����֐��̐錾
Declare Function GetComputerName Lib "kernel32.dll" Alias "GetComputerNameA" _
    (ByVal lpBuffer As String, nSize As Long) As Long

'***Win32 API��SHFileOperation()�֐��B�t�@�C���V�X�e���I�u�W�F�N�g���R�s�[���܂��B
'�v���O���X�o�[�t�B
'�t�@�C������Ɋւ�������`����\����
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

'�ǂ̑�����s�����������萔�̐錾
Public Const FO_COPY = &H2&
Public Const FOF_SIMPLEPROGRESS = &H100&
Public Const FOF_NOCONFIRMATION = &H10

' ����ʒu����ʂ̈ʒu�Ƀ������u���b�N���ړ�����֐��̐錾
Declare Sub MoveMemory Lib "kernel32.dll" _
    Alias "RtlMoveMemory" _
    (Destination As Any, _
    Source As Any, _
    ByVal Length As Long)

' SHFILEOPSTRUCT��lpszProgressTitle�܂ł̃T�C�Y
Public Const FILEOP_SIZE_ABORTED_TO_PROGRESSTITLE = 12

' �t�@�C���𑀍삷��֐��̐錾
Declare Function SHFileOperation Lib "shell32.dll" _
    Alias "SHFileOperationA" _
    (lpFileOp As Any) As Long

'API�֐���ShowCursor=�}�E�X�|�C���^������
Public Declare Function ShowCursor Lib "user32" (ByVal bShow As Long) As Long
'***
    
' AnsiInstrB �� 2�̕���������� Ansi ������ƁAAnsi �޲Ĉʒu��n���܂��B
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
' AnsiLeftB�ŏ�������O�ɁAANSI ������֕ϊ����A�������ʂ� Unicode �ɖ߂��܂��B

' MidB �ŏ�������O�ɁAANSI ������֕ϊ����A�������ʂ� Unicode �ɖ߂��܂��B

' �ȗ��\�Ȉ������������Ă��������ݒ肵�܂��B
Function AnsiMidB(ByVal StrArg As String, ByVal arg1 As Long, Optional arg2) As String
    If IsMissing(arg2) Then
    AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(StrArg, vbFromUnicode) _
            , arg1), vbUnicode)
    Else
    AnsiMidB = AnsiStrConv(MidB(AnsiStrConv(StrArg, vbFromUnicode) _
            , arg1, arg2), vbUnicode)
    End If
End Function
' 16 �ޯĊ��ł́AUnicode <-> Ansi �ϊ��͕s�K�v�Ȃ̂ŁA32 �ޯĂ̎�����

Function AnsiLeftB(ByVal StrArg As String, ByVal arg1 As Long) As String
    AnsiLeftB = AnsiStrConv(LeftB(AnsiStrConv(StrArg, vbFromUnicode) _
            , arg1), vbUnicode)
End Function

' AnsiLenB �ŏ�������O�ɁAANSI ������֕ϊ����A�������ʂ� Unicode �ɖ߂��܂��B
Function AnsiLenB(ByVal StrArg As String) As Long
    AnsiLenB = LenB(AnsiStrConv(StrArg, vbFromUnicode))
End Function

' AnsiRightB�ŏ�������O�ɁAANSI ������֕ϊ����A�������ʂ� Unicode �ɖ߂��܂��B
Function AnsiRightB(ByVal StrArg As String, ByVal arg1 As Long) As String
    AnsiRightB = AnsiStrConv(RightB(AnsiStrConv(StrArg, vbFromUnicode) _
            , arg1), vbUnicode)
End Function

' StrConv ���Ăяo���܂��B
Function AnsiStrConv(StrArg, flag)
#If Win32 Then
    AnsiStrConv = StrConv(StrArg, flag)
#Else
    AnsiStrConv = StrArg
#End If

End Function

Public Function AnsiTrimStringByByteCount(SrcStr As String, DstCount As Long, _
                                        Optional ByRef strRemainString As String) As String
'�T�v�F�S�p���p�܂����Unicode��������A����������Ȃ��悤�Ɏw�肳�ꂽ
'    : �������Ɋۂ߂��������Ԃ�
'�����FSrcStr,Input,String,���̕�����
'�@�@�FDstCount,Input,Long,�ۂ߂�o�C�g��
'�����F�S�p���p�܂����Unicode��������A����������Ȃ��悤�Ɏw�肳�ꂽ
'    : �������Ɋۂ߂��������Ԃ�
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

' Api�֐����g�p���R���s���[�^�����擾����B
Public Function GP_GetCmpName() As String
    
Dim strComputerNameBuffer   As String * MAX_COMPUTERNAME_LENGTH
Dim lngComputerNameLength   As Long
Dim lngResult               As Long

    ' �R���s���[�^���̒�����ݒ�
    lngComputerNameLength = Len(strComputerNameBuffer)
    ' �R���s���[�^�����擾
    lngResult = GetComputerName(strComputerNameBuffer, lngComputerNameLength)
    ' �R���s���[�^����\��
    GP_GetCmpName = Left(strComputerNameBuffer, InStr(strComputerNameBuffer, vbNullChar) - 1)

End Function

'********************'********************'********************'
'***  �z��̏����\�[�g�i�N�C�b�N�\�[�g�j                      ***
'********************'********************'********************'
'*�y�֐����z
'*   SortAsc
'*�y�����z
'*   ByRef varData() As Variant = �y���o�́z�z��
'*   ByVal lngSort_S As Long   = �\�[�g�J�n�Y��
'*   ByVal lngSort_E As Long   = �\�[�g�I���Y��
'*�y�߂�l�z
'*  �Ȃ�
'*�y�����z
'*  �N�C�b�N�\�[�g����B
'********************'********************'********************'
Public Sub SortAsc(ByRef varData() As Variant, _
                    ByVal lngSort_S As Long, _
                    ByVal lngSort_E As Long)
Dim lngI    As Long
Dim lngJ    As Long
Dim varX    As Variant
Dim varW    As Variant

'** �N�C�b�N�\�[�g
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
'***  �z��̍~���\�[�g�i�N�C�b�N�\�[�g�j                      ***
'********************'********************'********************'
'*�y�֐����z
'*   SortAsc
'*�y�����z
'*   ByRef varData() As Variant = �y���o�́z�z��
'*   ByVal lngSort_S As Long   = �\�[�g�J�n�Y��
'*   ByVal lngSort_E As Long   = �\�[�g�I���Y��
'*�y�߂�l�z
'*  �Ȃ�
'*�y�����z
'*  �N�C�b�N�\�[�g����B
'********************'********************'********************'
Public Sub SortDesc(ByRef varData() As Variant, _
                    ByVal lngSort_S As Long, _
                    ByVal lngSort_E As Long)
Dim lngI    As Long
Dim lngJ    As Long
Dim varX    As Variant
Dim varW    As Variant

'** �N�C�b�N�\�[�g
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
    
    '�V���O���R�[�e�[�V����1��2�ɒu��������B
    '�I���N����INSERT�y�сAUPDATE���Ɏg�p���Ă��������B
    strWK = vbNullString
    If Len(strVar) > 0 Then
        
        'VB5�ȉ��Ŏg�p����B
'        For lngIndex = 1 To Len(strVar)
'            strWk2 = Mid(strVar, lngIndex, 1)
'            If strWk2 = C_strQut Then
'                strWK = strWK & strWk2 & C_strQut
'            Else
'                strWK = strWK & strWk2
'            End If
'        Next lngIndex
        
        'VB6�ȏ�Ŏg�p����B
        strWK = Replace(strVar, "'", "''")
    End If

    StChk = strWK

End Function

Public Function DblCChk(ByVal strVar As String) As String

Dim strWK As String
    
    '�_�u���R�[�e�[�V����1��2�ɒu��������B
    'CSV�t�@�C���o�͎��Ɏg�p���Ă��������B
    strWK = vbNullString
    If Len(strVar) > 0 Then
        strWK = Replace(strVar, """", """""")
    End If

    DblCChk = strWK

End Function

Public Function NumNull(ByVal strVar As String) As String

    'strVar=Null�̏ꍇ�A''��Ԃ��B
    If Trim$(strVar) = vbNullString Then
        NumNull = "''"
    Else
        NumNull = strVar
    End If
    
End Function

'�Ώۓ��̌����̓��t�����߂�
Public Function MonthEnd(ByVal datDate As Date) As Date
    
Dim datWK   As Date
    
    '�Ώۓ��̍ŏ��̓������߂�B
    datWK = CDate(Format$(datDate, "yyyy/mm") & "/01")
    '�Ώی��̍ŏI�������߂�B
    MonthEnd = DateAdd("D", -1, DateAdd("M", 1, datWK))

End Function
 
Public Function GP_AddZero(ByVal dblData As Double, ByVal lngKETA As Long) As String

Dim strResult   As String
    
    '����0��t���Ďw�茅���f�[�^��Ԃ��B
    strResult = Right(String$(lngKETA, "0") & dblData, lngKETA)
    
    GP_AddZero = CStr(strResult)

End Function

Public Function GP_AddSpace(ByVal strData As String, ByVal lngKETA As Long) As String

Dim strResult   As String
    
    '���ɃX�y�[�X��t���Ďw�茅���f�[�^��Ԃ��B
    strResult = AnsiRightB(Space$(lngKETA) & strData, lngKETA)
    
    GP_AddSpace = strResult

End Function

Public Function GP_�ׂ���(ByVal dblData As Double, lngKETA As Long) As String

Dim dblWK       As Double
Dim lnbResult   As Long
    
    '�ׂ���v�Z�B
    dblWK = 10 ^ (lngKETA)
    lnbResult = dblData * dblWK
    
    GP_�ׂ��� = CStr(lnbResult)
    
End Function

'********************************************************************************
' @(f)      : Ctrl_send
'
' �@�\      : �R���g���[���ړ����ړ�����B
'
' �Ԃ�l    :
'
' ������    : KeyAscii As Integer
'
' ���l      :

Function GP_CtrlSend(KeyAscii As Integer, frm As Form)
    If KeyAscii = vbKeyReturn Then
        PostMessage frm.hWnd, WM_KEYDOWN, vbKeyTab, &HF021
        KeyAscii = 0
    End If
End Function

'********************************************************************************
' @(f)      : CtrlHanten
'
' �@�\      : �R���g���[���𔽓]�\������B
'
' �Ԃ�l    :
'
' ������    : Txt As TextBox : �e�L�X�g�{�b�N�X
'
' ���l      :

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

'���i���̂̕���
    
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

