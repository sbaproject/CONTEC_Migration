Attribute VB_Name = "AE_PROC"
Option Explicit
'Copyright 1994-2003 by AppliTech, Inc. All Rights Reserved.
'
'Common Library 1 V6.60 'レベルアップの際に変更。
'
Declare Function CspAddAltKeyCode Lib "AE_SUP32.DLL" (ByVal fhWnd As Long, ByVal hwnd As Long, ByVal ReqC As Long) As Long
Declare Function CspDelAltKeyCode Lib "AE_SUP32.DLL" (ByVal fhWnd As Long, ByVal hwnd As Long, ByVal ReqC As Long) As Long
Declare Function CspPurgeFilterReq Lib "AE_SUP32.DLL" (ByVal fhWnd As Long) As Long
Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, lParam As Long) As Long 'V4.33
Declare Function SetTabCapture Lib "TabCap.DLL" (ByVal hwnd As Long) As Long
Declare Function ReleaseTabCapture Lib "TabCap.DLL" (ByVal hwnd As Long) As Long
Declare Function ImmGetContext Lib "imm32.dll" (ByVal hwnd As Long) As Long
Declare Function ImmReleaseContext Lib "imm32.dll" (ByVal hwnd As Long, ByVal hIMC As Long) As Long
Declare Function ImmGetCompositionString Lib "imm32.dll" Alias "ImmGetCompositionStringA" (ByVal hIMC As Long, ByVal dw As Long, ByVal lpv As String, ByVal dw2 As Long) As Long
Declare Function CallWindowProc Lib "user32" Alias "CallWindowProcA" (ByVal lpPrevWndFunc As Long, ByVal hwnd As Long, ByVal Msg As Long, ByVal wParam As Long, ByVal lParam As Long) As Long 'V6.59Pop
Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hwnd As Long, ByVal nIndex As Long, ByVal dwNewLong As Long) As Long 'V6.59Pop
Private Declare Function GetClassName Lib "user32" Alias "GetClassNameA" (ByVal hwnd As Long, ByVal lpClassName As String, ByVal nMaxCount As Long) As Long 'V6.59Pop
Public Const GWL_WNDPROC = -4 'V6.59Pop

Public Function AE_BodyPx(PP As clsPP, ByVal pm_Px, ByVal pm_Index) As Integer 'V5.39
    AE_BodyPx = PP.BodyPx + ((pm_Px - PP.BodyPx + PP.BodyV) Mod PP.BodyV) + PP.BodyV * pm_Index
End Function

Public Function AE_Change(PP As clsPP, CP As clsCP, Ct As Object) As Boolean
'Non Static Sub
'pm_Value ----> PP.NewVal
'pm_TA$ ----> CP.TpStr
Dim wk_ItemFlag As Boolean 'データ項目の区切りなら True にする。
Dim wk_Tx As Integer
Dim wk_Ln As Long
Dim wk_LnB As Long
Dim wk_MaxLB As Long
Dim wk_AutoEnter As Integer
Dim wk_Ln2 As Long
Dim wk_Moji$
Dim wk_Pad As Integer
Dim wk_SaveMaskMode As Boolean
Dim wk_SSorg As Long
Dim wk_SS As Long
Dim wk_LastSS As Long 'V4.30
Dim wk_WkSS As Long
Dim wk_LenTxt As Long
Dim wk_BeepSw As Boolean
Dim wk_Txt$
Dim wk_CurTxt$
Dim wk_FractionC As Integer
Dim wk_NewTxt$
Dim wk_Pos As Integer
Dim wk_FracN  As Integer
Dim wk_FormatChr$ 'V4.31
'
   'PP.InitValStatus = Cn_ModeDataChanged 'AE_InitVal などの後に画面へのインプットあり。
   Call AE_SetInitValStatus(PP, CP) 'V6.56S
'
   wk_BeepSw = False
   wk_ItemFlag = False
   wk_CurTxt$ = Ct
   wk_Txt$ = wk_CurTxt$
   'LenWid を用いる。
   wk_LnB = LenWid(wk_Txt$)
'
'Auto Enter 指定の項目については、日本語のインプットの IME 変換された先頭部分
'の文字列で項目フルになると、後続の変換文字列を受けるときに PP.Tx の方が進ん
'でいるが、Ct.TabIndex の方は元のままなので、PP.Tx <> Ct.TabIndex となること
'がある。なお、このときにボディ部がスクロールするケースにおいては、スクロール
'後の Ct.TabIndex と PP.Tx が一致してしまう場合（例えば、ボディ部に項目が一つ
'しかない場合）には、この現象は緩和される。
   wk_Tx = PP.Tx
'
   If CP.CIn = Cn_NoInput Then '0: No Input
      If wk_Txt$ <> CP.TpStr Then
         If PP.Tx <> Ct.TabIndex Then 'V6.45
            Call AE_SystemError("AE_Change に", 104)
            Exit Function '--------------------
         ElseIf CP.KeyInOkClass = Asc("N") Then 'Or CP.KeyInOkClass = Asc("M") Then
            '半角空白への変換
            wk_SS = 1
            Do While wk_SS <= Len(wk_Txt$)
               If CP.KeyInOkClass = Asc("N") Then
                  If Mid$(wk_Txt$, wk_SS, 1) = "　" Then '２バイト文字のスペース。
                     wk_Txt$ = Left$(wk_Txt$, wk_SS - 1) & Space$(2) & Mid$(wk_Txt$, wk_SS + 1)
                     wk_SS = wk_SS + 1
                     GoTo AE_ChangeSet '---------->
                  End If
               End If
               wk_SS = wk_SS + 1
            Loop
            wk_SS = Ct.SelStart
            CP.TpStr = wk_Txt$
            GoTo AE_ChangeRet '---------->
         ElseIf CP.KeyInOkClass = Asc("M") Or CP.KeyInOkClass = Asc("V") Then
            wk_SS = Ct.SelStart
            CP.TpStr = wk_Txt$
            GoTo AE_ChangeRet '---------->
         Else
            wk_SS = 1
            Do While wk_SS <= Len(wk_Txt$)
               If LenWid(Mid$(wk_Txt$, wk_SS, 1)) = 2 Then
                  Beep
                  wk_BeepSw = True 'V4.24
                  wk_Txt$ = Left$(wk_Txt$, wk_SS - 1) & Mid$(CP.TpStr, wk_SS, 1) & Mid$(wk_Txt$, wk_SS + 1) 'V4.05
                  wk_SS = wk_SS - 1
                  GoTo AE_ChangeSet '---------->
               End If
               wk_SS = wk_SS + 1
            Loop
            wk_SS = Ct.SelStart
            CP.TpStr = wk_Txt$
            GoTo AE_ChangeRet '---------->
         End If
AE_ChangeSet:
         CP.TpStr = wk_Txt$
         wk_SaveMaskMode = PP.MaskMode
         PP.MaskMode = True
         Ct = wk_Txt$
         Ct.SelStart = wk_SS
         PP.MaskMode = wk_SaveMaskMode
      Else
         wk_SS = Ct.SelStart
      End If
AE_ChangeRet:
      AE_Change = True '(wk_ItemFlag)
      Ct.SelLength = PP.Override
      'V6.45 で、この上に移動。
      'If PP.Tx <> Ct.TabIndex Then Exit Function '--------------------
      GoTo AE_ChangeLabel1 '---------->
   End If
'V4.16
   If CP.KeyInOkClass = Asc("M") Then
      wk_SS = Ct.SelStart
      wk_NewTxt$ = ""
      wk_WkSS = 1
      wk_LenTxt = Len(RTrim$(wk_Txt$))
      Do While wk_WkSS <= wk_LenTxt
         If Mid$(wk_Txt$, wk_WkSS, 1) = Space$(1) Then
            wk_NewTxt$ = wk_NewTxt$ & "　" '２バイト文字のスペース。
         Else
            wk_NewTxt$ = wk_NewTxt$ & Mid$(wk_Txt$, wk_WkSS, 1)
         End If
         wk_WkSS = wk_WkSS + 1
      Loop
      If wk_LnB >= LenWid(wk_NewTxt$) Then
          wk_Txt$ = wk_NewTxt$ & Space$(wk_LnB - LenWid(wk_NewTxt$))
      Else
          wk_Txt$ = MidWid(wk_NewTxt$, 1, wk_LnB)
      End If
      CP.TpStr = wk_Txt$
      wk_SaveMaskMode = PP.MaskMode
      PP.MaskMode = True
      Ct = wk_Txt$
      Ct.SelStart = wk_SS
      PP.MaskMode = wk_SaveMaskMode
   End If
'
   '以下の整合性のチェックは、CP.CIn = Cn_NoInput のチェックの後にする。
   If wk_Tx < 0 Or wk_Tx >= PP.ControlsC Then
      Call AE_SystemError("AE_Change に", 100)
      AE_Change = False '(wk_ItemFlag)
      If CP.TypeA = Cn_NormalOrV Then Ct.SelLength = PP.Override
      Exit Function '--------------------
   End If
'
   wk_AutoEnter = (CP.AutoEnter And Cn_AutoEnter) And (CP.KeyInOkClass <> Asc("M")) And (CP.KeyInOkClass <> Asc("V")) And (CP.KeyInOkClass <> Asc("N")) And (CP.KeyInOkClass <> Asc("K"))  'V6.45 'V6.53
'
   If CP.TypeA = Cn_InputOnly Then
      wk_ItemFlag = Not PP.ComboUpDown And wk_AutoEnter = Cn_AutoEnter
      PP.ComboUpDown = False
      GoTo AE_ChangeReFormat '---------->
   End If
'
   'LenWid を用いる。
   wk_LnB = LenWid(wk_Txt$)
   wk_SSorg = Ct.SelStart 'V4.30
   wk_SS = wk_SSorg 'V4.30
   wk_MaxLB = CP.MaxLength ': If InStr(wk_Txt$, "-") = 0 Then wk_MaxLB = wk_MaxLB - 1 'V6.45
'バックスペースまたはデリートの場合。
   If CP.CIn = Cn_BSorDL Then '1: Back Space or Delete
      CP.CIn = Cn_NoInput '0: No Input
      If wk_MaxLB > 0 Then
         If CP.Alignment <> 1 Then '左詰め/(中央)
            wk_Txt$ = wk_Txt$ & Space$(wk_MaxLB - wk_LnB)
         Else                        '右詰め
            '通貨表示の場合に \ を消す処理。
            wk_Txt$ = Space$(wk_MaxLB - wk_LnB) & wk_Txt$
            If Right$(wk_Txt$, 1) = "\" Then 'V4.31
                If Left$(CP.FormatChr, 2) = "\\" Then wk_Txt$ = Space$(wk_MaxLB)
            End If 'V4.31
            wk_SS = wk_SS + (wk_MaxLB - wk_LnB)
         End If
      End If
      GoTo AE_ChangeReFormat '----------> 'Skip to AE_ChangeReFormat when Back Space or Delete
   End If
'
   CP.CIn = Cn_NoInput '0: No Input
'
   '内田洋行殿で発生した障害？を回避。'V6.48
   If (Not Ct.TabStop Or Not Ct.Enabled Or Not Ct.Visible) And Not AE_SSSWin Then 'V6.48
      'ここが実行されることはない？
      Call AE_SystemError("AE_Change に", 101)
      AE_Change = False '(wk_ItemFlag)
      If CP.TypeA = Cn_NormalOrV Then Ct.SelLength = PP.Override
      Exit Function '--------------------
   End If
   If wk_MaxLB > 0 Then
      wk_Ln = Len(wk_Txt$)
      If CP.FixedFormat <> 1 Then
      '文字列の長さのチェック。
         wk_NewTxt$ = AE_Format$(CP, AE_Val(CP, wk_Txt$, wk_FractionC), 0, True) '確定だと仮定して文字列を求める。
         wk_Ln2 = LenWid(Trim$(wk_NewTxt$))
         If wk_Ln2 > wk_MaxLB Or _
            wk_Ln2 > wk_MaxLB - 1 And (CP.FormatClass = Cn_Snum Or CP.FormatClass = Cn_Schn) And InStr(wk_NewTxt$, "-") = 0 Then 'V6.50N '符数類
            Beep
            If wk_SS > 0 And wk_SS + 1 <= wk_Ln Then
               If Mid$(CP.TpStr, wk_SS, 1) = "." Then
                  wk_Txt$ = Left$(wk_Txt$, wk_SS - 1) & "." & Mid$(wk_Txt$, wk_SS + 1, wk_Ln - wk_SS)
               Else
                  wk_Txt$ = Left$(wk_Txt$, wk_SS - 1) & Mid$(wk_Txt$, wk_SS + 1, wk_Ln - wk_SS)
               End If
            ElseIf wk_SS > 0 And wk_SS = wk_Ln Then
               wk_Txt$ = Left$(wk_Txt$, wk_SS - 1)
            End If
            GoTo AE_ChangeLabel1 '---------->
         End If
      ElseIf PP.Override = 0 Then 'And CP.FixedFormat = 1
      '固定カラムの処理。
         If wk_SS > 0 And wk_SS + 1 <= wk_Ln Then
            wk_Txt$ = Left$(wk_Txt$, wk_SS - 1) & Mid$(wk_Txt$, wk_SS + 1, wk_Ln - wk_SS)
         ElseIf wk_SS > 0 And wk_SS = wk_Ln Then
            wk_Txt$ = Left$(wk_Txt$, wk_SS - 1)
         End If
      End If
   End If
'２バイト文字のスペースを変更する。
   If wk_SS > 0 And CP.KeyInOkClass <> Asc("M") And CP.KeyInOkClass <> Asc("V") Then 'V4.19
      If Mid$(wk_Txt$, wk_SS, 1) = "　" Then '２バイト文字のスペース。
         wk_Txt$ = Left$(wk_Txt$, wk_SS - 1) & Space$(2) & Mid$(wk_Txt$, wk_SS + 1)
         wk_SS = wk_SS + 1
      End If
   End If
'
AE_ChangeLabel1:
   If wk_MaxLB > 0 And CP.Alignment <> 1 Then '左詰め/(中央)
      Do While LenWid(wk_Txt$) > wk_MaxLB 'Len ではダメ。
         If Right$(wk_Txt$, 1) <> Space$(1) Then
            Beep
            wk_BeepSw = True
            If PP.Override = 0 And Mid$(wk_Txt$, wk_SS + 1) <> "" Then
               wk_Txt$ = Left$(wk_Txt$, wk_SS - 1) & Mid$(wk_Txt$, wk_SS + 1)
            Else
               wk_Txt$ = Left$(wk_Txt$, Len(wk_Txt$) - 1)
            End If
         Else
            wk_Txt$ = Left$(wk_Txt$, Len(wk_Txt$) - 1)
         End If
      Loop
      wk_LnB = LenWid(wk_Txt$) 'Len ではダメ。
      If wk_LnB < wk_MaxLB Then wk_Txt$ = wk_Txt$ & Space$(wk_MaxLB - wk_LnB)
'
      wk_Ln = Len(wk_Txt$)
      Do While wk_SS < wk_Ln
         wk_Moji$ = Mid$(wk_Txt$, wk_SS + 1, 1)
         If wk_Moji$ = Space$(1) Or AE_KeyInOkChar(PP, wk_Moji$, CP.KeyInOkClass) Then Exit Do '----------
         wk_SS = wk_SS + 1
      Loop
      wk_LastSS = wk_SS
      Do While wk_LastSS < wk_Ln
         wk_Moji$ = Mid$(wk_Txt$, wk_LastSS + 1, 1)
         If wk_Moji$ = Space$(1) Then Exit Do '----------
         wk_LastSS = wk_LastSS + 1
      Loop
      'wk_ItemFlag = True にする最初のコード。
      If wk_AutoEnter = 1 And wk_BeepSw = False Then
         If PP.Override = 0 And LenWid(Left$(wk_Txt$, wk_LastSS)) >= wk_MaxLB And CP.FixedFormat <> 1 Then wk_ItemFlag = True
         If LenWid(Left$(wk_Txt$, wk_SS)) >= wk_MaxLB Then wk_ItemFlag = True
         wk_LnB = LenWid(Trim$(wk_Txt$)) 'Len ではダメ。'V4.30
         If CP.KeyInOkClass = Asc("1") And wk_LnB >= 1 Then wk_ItemFlag = True 'V4.18
         If CP.KeyInOkClass = Asc("2") And wk_LnB >= 2 And wk_SSorg >= 2 Then wk_ItemFlag = True 'V4.30
         If CP.KeyInOkClass = Asc("3") And wk_LnB >= 3 And wk_SSorg >= 3 Then wk_ItemFlag = True 'V4.30
      End If
   ElseIf wk_MaxLB > 0 And CP.Alignment = 1 Then '右詰め
      Do While wk_SS > 0 And LenWid(wk_Txt$) > wk_MaxLB 'Len ではダメ。
         If Left$(wk_Txt$, 1) <> Space$(1) Then
            Beep
            wk_BeepSw = True
            If PP.Override = 0 And Mid$(wk_Txt$, wk_SS + 1) <> "" Then
               wk_Txt$ = Left$(wk_Txt$, wk_SS - 1) & Mid$(wk_Txt$, wk_SS + 1)
            Else
               wk_Txt$ = Left$(wk_Txt$, Len(wk_Txt$) - 1) 'Right でない。
            End If
         Else
            wk_Txt$ = Right$(wk_Txt$, Len(wk_Txt$) - 1)
         End If
         wk_SS = wk_SS - 1
      Loop
      'LenWid を用いる。
      wk_Pad = wk_MaxLB - LenWid(RTrim$(wk_Txt$))
      'If wk_Pad > 0 Then wk_Txt$ = Space$(wk_Pad) & wk_Txt$: wk_SS = wk_SS + wk_Pad
      If wk_Pad > 0 Then 'V6.55
          wk_Txt$ = Space$(wk_Pad) & wk_Txt$ 'V6.55
          '置換え If AE_Numerical(CP.FormatClass) Or Not AE_KeyInOkChar(PP, Space$(1), CP.KeyInOkClass) Then wk_SS = wk_SS + wk_Pad 'V6.55
          wk_SS = wk_SS + wk_Pad 'V6.60
      End If 'V6.55
      wk_Ln = Len(wk_Txt$)
      Do While wk_SS < wk_Ln
         wk_Moji$ = Mid$(wk_Txt$, wk_SS + 1, 1)
         If Cn_ai21 And AE_Numerical(CP.FormatClass) Then 'V6.53
             If wk_Moji$ = Space$(1) Or (AE_KeyInOkChar(PP, wk_Moji$, CP.KeyInOkClass) And wk_Moji$ <> ".") Then GoTo AE_ChangeLabel2 '----------> 'V6.53
         Else 'V6.53
             If wk_Moji$ = Space$(1) Or AE_KeyInOkChar(PP, wk_Moji$, CP.KeyInOkClass) Then GoTo AE_ChangeLabel2 '---------->
         End If
         wk_SS = wk_SS + 1
      Loop
      'wk_SS = wk_Ln といえる。
      If wk_AutoEnter = 1 And wk_BeepSw = False Then
         If Left$(wk_Txt$, 1) <> Space$(1) Then
            wk_ItemFlag = True '右詰めで左端がスペースでない。
         'ElseIf Left$(wk_NewTxt$, 1) <> Space$(1) Then 'V4.32
         ElseIf Left$(wk_NewTxt$, 1) <> Space$(1) And Not (AE_SSSWin And Left$(CP.FormatChr, 1) = "0") And InStr(CP.FormatChr, ".") = 0 Then 'V4.33
            wk_ItemFlag = True '右詰めで左端がスペースでない。
         'ElseIf CP.FixedFormat <> 1 And LenWid(Trim$(wk_NewTxt$)) >= wk_MaxLB And wk_MaxLB > 0 Then
         ElseIf CP.FixedFormat <> 1 And (wk_Ln2 >= wk_MaxLB Or wk_Ln2 >= wk_MaxLB - 1 And (CP.FormatClass = Cn_Snum Or CP.FormatClass = Cn_Schn) And InStr(wk_NewTxt$, "-") = 0) And wk_MaxLB > 0 Then 'V6.48 'V6.50N '符数類
            If InStr(wk_NewTxt$, ".") > 0 Then
               If InStr(wk_Txt$, ".") = InStr(wk_NewTxt$, ".") Then wk_ItemFlag = True
            'Else 'V4.21
            ElseIf Not AE_SSSWin Then 'V4.24
               'wk_ItemFlag = True 'V4.21 #,##0 のように編集後、文字数が増加する場合。
               '符数 Or 符字数、２文字長、- 入力、AutoEnter 'V6.50
               If (CP.FormatClass <> Cn_Snum And CP.FormatClass <> Cn_Schn) Or wk_MaxLB <> 2 Or ((Ct) <> " -" And (Ct) <> "  -") Then wk_ItemFlag = True 'V6.48 'V6.50N '符数類
            End If
         ElseIf InStr(CP.FormatChr, ".") > 0 Then 'V4.31
         '小数点のある場合 (フル桁は上でチェック済み)。
            wk_Pos = InStr(CP.FormatChr, ";") 'V4.31
            If wk_Pos = 0 Then 'V4.31
               wk_FormatChr$ = CP.FormatChr 'V4.31
            Else 'V4.31
               wk_FormatChr$ = Left$(CP.FormatChr, wk_Pos - 1) 'V4.31
            End If 'V4.31
            wk_Pos = InStr(wk_FormatChr$, ".") 'V4.31
            If wk_Pos > 0 Then 'V4.31
                wk_FracN = Len(wk_FormatChr$) - wk_Pos 'V4.31
                '
                wk_Pos = InStr(wk_Txt$, ".") 'V4.31
                If wk_Pos > 0 Then 'V4.31
                    If wk_FracN = Len(wk_Txt$) - wk_Pos Then wk_ItemFlag = True 'V4.31
                End If 'V4.31
            End If 'V4.31
         End If
      End If
AE_ChangeLabel2:
   'ElseIf wk_MaxLB = 0 And AE_Numerical(CP.FormatClass) Then 'V6.50
   End If
'
AE_ChangeReFormat:
   PP.NewVal = AE_Val(CP, wk_Txt$, wk_FractionC)
   If CP.KeyInOkClass = Asc("V") Then
      If CP.FormatChr = "" And CP.FormatClass <> Cn_Date And Not AE_Numerical(CP.FormatClass) Then
         wk_NewTxt$ = wk_Txt$
      Else
         wk_NewTxt$ = AE_Format$(CP, wk_Txt$, 0, False)
      End If
   Else
      wk_NewTxt$ = AE_Format$(CP, PP.NewVal, wk_FractionC, False)
   End If
'
   If LenWid(wk_NewTxt$) > wk_MaxLB And wk_MaxLB > 0 Then
      Beep
      If CP.Alignment <> 1 Then '左詰め/(中央)
         wk_NewTxt$ = LeftWid$(wk_NewTxt$, wk_MaxLB) '２バイト文字の途中。
      Else
         wk_NewTxt$ = RightWid$(wk_NewTxt$, wk_MaxLB)
      End If
   End If
'
   If CP.TypeA = Cn_NormalOrV Then
      If CP.Alignment <> 1 Then '左詰め/(中央)
         wk_SS = wk_SS + Len(RTrim$(wk_NewTxt$)) - Len(RTrim$(wk_Txt$))
         If wk_SS < 0 Then wk_SS = 0
      End If
'
      wk_SaveMaskMode = PP.MaskMode
      PP.MaskMode = True
      If wk_NewTxt$ <> wk_CurTxt$ Then
         Ct = wk_NewTxt$
         wk_CurTxt$ = wk_NewTxt$
      End If
      Ct.SelStart = wk_SS
      Ct.SelLength = PP.Override
      PP.MaskMode = wk_SaveMaskMode
   End If
'
   CP.TpStr = wk_NewTxt$
'
   CP.StatusC = Cn_Status1 'Incomplete
   Ct.ForeColor = AE_Color(Cn_Status1) 'Incomplete
   If CP.TypeA = Cn_NormalOrV Or CP.TypeA = Cn_InputOnly Then Ct.BackColor = PP.BrightOnOff
'
   If PP.Tx >= PP.BodyTx And PP.Tx < PP.EBodyTx Then
      If PP.ActiveDe = PP.De Then
         PP.ActiveDe = -1: Call AE_ScrlMax(PP)
      'ElseIf PP.ActiveDe < 0 And PP.DeApendable Then '即ち wk_DeC = 0
      ElseIf PP.ActiveDe < 0 And AE_GetDeApendable(PP) Then '即ち wk_DeC = 0 'V6.55I
         'If PP.De > PP.LastDe Then
         If Not PP.AllowNullDes And (PP.De > PP.LastDe) Then 'V6.47B
            Call AE_SystemError("AE_Change に", 102)
         End If
         If PP.De >= PP.LastDe Then
            PP.LastDe = PP.De + 1: Call AE_ScrlMax(PP)
            'LastReadDe の処理は不要。'V6.47(5)
            If PP.UniScrl Then PP.LastEDe = PP.De + 1: Call AE_EScrlMax(PP) 'V6.46
            'LastReadEDe の処理は不要。'V6.47(5)
         End If
      'ElseIf PP.ActiveDe >= 0 Or Not AE_GetDeApendable(PP) Then
         'No Operation
      End If
   ElseIf PP.Tx >= PP.EBodyTx And PP.Tx < PP.TailTx Then 'V4.26
      If PP.ActiveEDe = PP.De Then
         PP.ActiveEDe = -1: Call AE_EScrlMax(PP)
      'ElseIf PP.ActiveEDe < 0 And PP.EDeApendable Then '即ち wk_EDeC = 0
      ElseIf PP.ActiveEDe < 0 And AE_GetEDeApendable(PP) Then '即ち wk_EDeC = 0 'V6.55I
         'If PP.De > PP.LastEDe Then
         If Not PP.AllowNullDes And (PP.De > PP.LastEDe) Then 'V6.47B
            Call AE_SystemError("AE_Change に", 103)
         End If
         If PP.De >= PP.LastEDe Then
            PP.LastEDe = PP.De + 1: Call AE_EScrlMax(PP)
            'LastReadEDe の処理は不要。'V6.47(5)
            If PP.UniScrl Then PP.LastDe = PP.De + 1: Call AE_ScrlMax(PP) 'V6.46
            'LastReadDe の処理は不要。'V6.47(5)
         End If
      'ElseIf PP.ActiveEDe >= 0 Or Not AE_GetEDeApendable(PP) Then
         'No Operation
      End If
   End If
   AE_Change = wk_ItemFlag
End Function

'Direction の変更。
Public Function AE_ChangeDirection(ByVal pm_Direction As Integer) As Integer
    Select Case pm_Direction
        Case Cn_Direction3
            AE_ChangeDirection = Cn_Direction1
        Case Cn_Direction4
            AE_ChangeDirection = Cn_Direction2
        Case Else
            AE_ChangeDirection = pm_Direction
    End Select
End Function

'表示項目へのペーストを抑止する。
Public Function AE_ChangePre(PP As clsPP, CP As clsCP, Ct As Object) As Boolean
Dim wk_SaveMaskMode As Boolean 'V7.00
    If PP.Tx <> Ct.TabIndex Then
        wk_SaveMaskMode = PP.MaskMode
        PP.MaskMode = True
        Ct = CP.TpStr
        PP.MaskMode = wk_SaveMaskMode
        AE_ChangePre = True
    Else
        AE_ChangePre = False
    End If
End Function

'動作モード(Mode)を後刻変更する。Check 高級イベントルーチンの中以外からの呼び出しは禁止です。
Public Function AE_ChOprtLater(PP As clsPP, ByVal pm_Mode As Integer) As Boolean
   If PP.RecalcMode = True Then AE_ChOprtLater = True: Exit Function '--------------------
'
   If pm_Mode <> PP.Mode Then
      Select Case pm_Mode
         Case Cn_Mode1
            If AE_MsgLibrary(PP, "AppendC") Then AE_ChOprtLater = False: Exit Function '--------------------
         Case Cn_Mode15 'V4.28
            If PP.Mode <> Cn_Mode1 Then
               If AE_MsgLibrary(PP, "AppendC") Then AE_ChOprtLater = False: Exit Function '-------------------- 'V4.28
            End If
         Case Cn_Mode16 'V6.56
         Case Cn_Mode2
            If AE_MsgLibrary(PP, "SelectCm") Then AE_ChOprtLater = False: Exit Function '--------------------
         Case Cn_Mode25 'V6.59CL
            If AE_MsgLibrary(PP, "SelectCm") Then AE_ChOprtLater = False: Exit Function '--------------------
         Case Cn_Mode3
            If AE_MsgLibrary(PP, "Indicate") Then AE_ChOprtLater = False: Exit Function '--------------------
         Case Cn_Mode4
            If AE_MsgLibrary(PP, "UpdateC") Then AE_ChOprtLater = False: Exit Function '--------------------
         Case Else
            Call AE_SystemError("AE_ChOprtLater に", 110)
            Exit Function '--------------------
      End Select
   End If
'
   PP.ChOprtMode = pm_Mode
   AE_ChOprtLater = True
End Function

'AE_Controls の ForeColor, BackColor の設定。
Public Static Sub AE_ColorSub(PP As clsPP, CP As clsCP, ByVal pm_Ptr As Integer) 'V5.39
Dim wk_Tx As Integer
    wk_Tx = AE_Tx(PP, CP.CpPx) 'V5.39
    If wk_Tx >= 0 Then Call AE_ColorSub2(PP, CP, pm_Ptr, wk_Tx) 'V5.39
End Sub

'AE_Controls の ForeColor, BackColor の設定。
Public Static Sub AE_ColorSub2(PP As clsPP, CP As clsCP, ByVal pm_Ptr As Integer, ByVal pm_Tx As Integer) 'V5.39
    If CP.TypeA = Cn_NormalOrV Or CP.TypeA = Cn_InputOnly Then
        Select Case CP.StatusC
            Case Cn_Status2
                If Trim$((AE_Controls(PP.CtB + pm_Tx))) = "" Or PP.ErrorByBackColor Then
                    AE_Controls(PP.CtB + pm_Tx).ForeColor = AE_ForeColor(pm_Ptr \ 10)
                    AE_Controls(PP.CtB + pm_Tx).BackColor = AE_Color(CP.StatusC)
                Else
                    AE_Controls(PP.CtB + pm_Tx).ForeColor = AE_Color(CP.StatusC)
                    AE_Controls(PP.CtB + pm_Tx).BackColor = AE_BackColor(pm_Ptr Mod 10)
                End If
            Case Cn_Status3 To Cn_Status5
                If Trim$((AE_Controls(PP.CtB + pm_Tx))) = "" Or PP.ErrorByBackColor Then
                    AE_Controls(PP.CtB + pm_Tx).ForeColor = AE_ForeColor(pm_Ptr \ 10) 'V4.30
                    AE_Controls(PP.CtB + pm_Tx).BackColor = AE_Color(CP.StatusC)
                Else
                    AE_Controls(PP.CtB + pm_Tx).ForeColor = AE_Color(CP.StatusC)
                    AE_Controls(PP.CtB + pm_Tx).BackColor = AE_BackColor(pm_Ptr Mod 10)
                End If
            Case Cn_Status6 To Cn_Status8
                AE_Controls(PP.CtB + pm_Tx).ForeColor = AE_ForeColor(pm_Ptr \ 10)
                'If AE_GetInOutMode(CP.InOutMode, PP.Mode) < Cn_InOutMode2 And PP.ErrorByBackColor Then 'V4.30
                'If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 And Cn_ClIndicator <> Cn_ClNormalBack Then 'V5.44
                '(CP.AutoEnter And Cn_Enabled) = 0 という判定は不要。'V6.47X
                If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 And Cn_ClIndicator <> Cn_ClNormalBack And (pm_Ptr Mod 10) = 0 Then 'V6.47X
                    If Cn_ai21 And AE_BackColor(pm_Ptr Mod 10) = vbYellow Then 'V6.46
                        AE_Controls(PP.CtB + pm_Tx).BackColor = vbYellow 'V6.46
                    Else
                        AE_Controls(PP.CtB + pm_Tx).BackColor = Cn_ClIndicator
                    End If
                Else 'V4.30
                    AE_Controls(PP.CtB + pm_Tx).BackColor = AE_BackColor(pm_Ptr Mod 10)
                End If 'V4.30
            'Case Else
            '    'Stop '●
        End Select
    ElseIf CP.TypeA = Cn_OutputOnly Then
                AE_Controls(PP.CtB + pm_Tx).ForeColor = AE_ForeColor(pm_Ptr \ 10)
                If PP.ErrorByBackColor Then 'V4.30
                    AE_Controls(PP.CtB + pm_Tx).BackColor = Cn_ClIndicator
                Else 'V4.30
                    AE_Controls(PP.CtB + pm_Tx).BackColor = AE_BackColor(pm_Ptr Mod 10)
                End If 'V4.30
    End If
End Sub

Public Sub AE_CtSet(PP As clsPP, ByVal pm_Px As Integer, ByVal pm_Txt$, ByVal pm_TypeA As Integer, ByVal pm_DeSetSw As Boolean)
Dim wk_Tx As Integer
Dim wk_SS As Long
Dim wk_De As Integer
Dim wk_SaveMaskMode As Boolean
Dim wk_PxTx As Integer
Dim st_Work$
    wk_Tx = AE_Tx(PP, pm_Px)
    'If wk_Tx <> pm_Tx Then
    '    Call AE_SystemError("AE_CtSet に", 120)
    'End If
    If wk_Tx < 0 Then Exit Sub '-------------------- 'V4.17
'
    If pm_Px < 0 Or pm_Px >= PP.TailPx + PP.TailN Then
        Call AE_SystemError("AE_CtSet に", 121)
        Exit Sub '--------------------
    End If
'
    wk_SaveMaskMode = PP.MaskMode
    PP.MaskMode = True
    Select Case pm_TypeA
        Case Cn_NormalOrV
            wk_SS = AE_Controls(PP.CtB + wk_Tx).SelStart
            AE_Controls(PP.CtB + wk_Tx) = pm_Txt$
            AE_Controls(PP.CtB + wk_Tx).SelStart = wk_SS
        Case Cn_OutputOnly
            If TypeOf AE_Controls(PP.CtB + wk_Tx) Is Label Then AE_Controls(PP.CtB + wk_Tx) = pm_Txt$ 'V4.31
        Case Cn_OptionButtonH, Cn_OptionButtonC
            If Trim$(pm_Txt$) = "" Then
                st_Work$ = UCase$(AE_Controls(PP.CtB + wk_Tx).NAME)
                wk_PxTx = 0
                Do While wk_Tx + wk_PxTx < PP.ControlsC 'V4.18
                    If UCase$(AE_Controls(PP.CtB + wk_Tx + wk_PxTx).NAME) <> st_Work$ Then Exit Do '---------- 'V4.18
                    AE_Controls(PP.CtB + wk_Tx + wk_PxTx) = False
                    AE_Controls(PP.CtB + wk_Tx + wk_PxTx).TabStop = False
                    'Control.TabStop の設定あり。
                    'If PP.ActiveBlockNo > 0 Then 'V5.41
                    '    AE_Controls(PP.CtB + wk_Tx).Enabled = (CP.BlockNo = PP.ActiveBlockNo) 'V5.41
                    'End If 'V5.41
                    wk_PxTx = wk_PxTx + 1
                Loop
            Else
                AE_Controls(PP.CtB + wk_Tx + CInt(pm_Txt$)) = True
            End If
        Case Cn_CheckBox
            If Trim$(pm_Txt$) = "1" Then
                AE_Controls(PP.CtB + wk_Tx) = "1"
            Else
                AE_Controls(PP.CtB + wk_Tx) = "0"
            End If
        Case Else 'Cn_InputOnly, Cn_ListBox 'V4.18
            If Trim$(pm_Txt$) = "" Then
                AE_Controls(PP.CtB + wk_Tx).ListIndex = -1 'Null 値の場合の位置。
            Else
                wk_PxTx = 0
                Do While wk_PxTx < AE_Controls(PP.CtB + wk_Tx).ListCount
                    If Trim$(AE_Controls(PP.CtB + wk_Tx).List(wk_PxTx)) = Trim$(pm_Txt$) Then
                        AE_Controls(PP.CtB + wk_Tx).ListIndex = wk_PxTx
                        GoTo AE_CtSetLabel1 '---------->
                    End If
                    wk_PxTx = wk_PxTx + 1
                Loop
                AE_Controls(PP.CtB + wk_Tx).ListIndex = -1 'Null 値の場合の位置。
            End If
AE_CtSetLabel1:
    End Select
    PP.MaskMode = wk_SaveMaskMode
'
    If Not pm_DeSetSw Then Exit Sub '--------------------
'AE_Change 同じような処理。
    If wk_Tx >= PP.BodyTx And wk_Tx < PP.EBodyTx Then
        wk_De = (pm_Px - PP.BodyPx) \ PP.BodyV
        If PP.ActiveDe = wk_De Then
            PP.ActiveDe = -1: Call AE_ScrlMax(PP)
        'ElseIf PP.ActiveDe < 0 And PP.DeApendable Then '即ち wk_DeC = 0
        ElseIf PP.ActiveDe < 0 And AE_GetDeApendable(PP) Then '即ち wk_DeC = 0 'V6.55I
            If wk_De > PP.LastDe Then
                Call AE_SystemError("AE_CtSet に", 122)
            End If
            If wk_De >= PP.LastDe Then
                PP.LastDe = wk_De + 1: Call AE_ScrlMax(PP)
                'LastReadDe の処理は不要。'V6.47(5)
                If PP.UniScrl Then PP.LastEDe = wk_De + 1: Call AE_EScrlMax(PP) 'V6.46
                'LastReadEDe の処理は不要。'V6.47(5)
            End If
        'ElseIf PP.ActiveDe >= 0 Or Not AE_GetDeApendable(PP) Then
            'No Operation
        End If
    ElseIf wk_Tx >= PP.EBodyTx And wk_Tx < PP.TailTx Then
        wk_De = (pm_Px - PP.EBodyPx) \ PP.EBodyV
        If PP.ActiveEDe = wk_De Then
            PP.ActiveEDe = -1: Call AE_EScrlMax(PP)
        'ElseIf PP.ActiveEDe < 0 And PP.EDeApendable Then '即ち wk_EDeC = 0
        ElseIf PP.ActiveEDe < 0 And AE_GetEDeApendable(PP) Then '即ち wk_EDeC = 0 'V6.55I
            If wk_De > PP.LastEDe Then
                Call AE_SystemError("AE_CtSet に", 123)
            End If
            If wk_De >= PP.LastEDe Then
                PP.LastEDe = wk_De + 1: Call AE_EScrlMax(PP)
                'LastReadEDe の処理は不要。'V6.47(5)
                If PP.UniScrl Then PP.LastDe = wk_De + 1: Call AE_ScrlMax(PP) 'V6.46
                'LastReadDe の処理は不要。'V6.47(5)
            End If
        'ElseIf PP.ActiveDe >= 0 Or Not AE_GetEDeApendable(PP) Then
            'No Operation
        End If
    End If
End Sub

'ai21 システム向け
Public Sub AE_CtSet2(PP As clsPP, CP As clsCP) 'V5.42
Dim wk_Tx As Integer
    wk_Tx = AE_Tx(PP, CP.CpPx)
    If wk_Tx < 0 Then Exit Sub '--------------------
'
    Select Case CP.TypeA
        Case Cn_OutputOnly
            'If TypeOf AE_Controls(PP.CtB + wk_Tx) Is Label Then AE_Controls(PP.CtB + wk_Tx).Enabled = (CP.BlockNo = PP.ActiveBlockNo) 'V5.42
            'If TypeOf AE_Controls(PP.CtB + wk_Tx) Is Label Then 'V6.47E 'V6.47X で削除
            '    If CP.BlockNo = PP.ActiveBlockNo Then 'V6.47E 'V6.47X で削除
            '        CP.AutoEnter = CP.AutoEnter Or Cn_Enabled 'V6.47E 'V6.47X で削除
            '    Else 'V6.47E 'V6.47X で削除
            '        CP.AutoEnter = CP.AutoEnter And &HFFEF 'Cn_Enabled 'V6.47E 'V6.47X で削除
            '    End If 'V6.47E 'V6.47X で削除
            'End If 'V6.47E 'V6.47X で削除
            If PP.VisibleForItem And CP.CpPx >= PP.BodyPx And CP.CpPx < PP.TailPx Then AE_Controls(PP.CtB + wk_Tx).Visible = ((CP.AutoEnter And Cn_VisibleCur) = Cn_VisibleCur) 'V6.47V
        Case Cn_OptionButtonH, Cn_OptionButtonC
        Case Cn_CheckBox
        Case Else 'Cn_NormalOrV, Cn_InputOnly, Cn_ListBox 'V5.42
            'AE_Controls(PP.CtB + wk_Tx).Enabled = (CP.BlockNo = PP.ActiveBlockNo) 'V5.42
            'If CP.BlockNo = PP.ActiveBlockNo Then 'V6.47E 'V6.47X で削除
            '    CP.AutoEnter = CP.AutoEnter Or Cn_Enabled 'V6.47E 'V6.47X で削除
            'Else 'V6.47E 'V6.47X で削除
            '    CP.AutoEnter = CP.AutoEnter And &HFFEF 'Cn_Enabled 'V6.47E 'V6.47X で削除
            'End If 'V6.47E 'V6.47X で削除
            'AE_Controls(PP.CtB + wk_Tx).TabStop = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) And ((CP.AutoEnter And Cn_Enabled) = Cn_Enabled) 'V6.47E
            AE_Controls(PP.CtB + wk_Tx).TabStop = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) And AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) 'V6.47X
            If PP.VisibleForItem And CP.CpPx >= PP.BodyPx And CP.CpPx < PP.TailPx Then AE_Controls(PP.CtB + wk_Tx).Visible = ((CP.AutoEnter And Cn_VisibleCur) = Cn_VisibleCur) 'V6.47V
    End Select
End Sub

Public Function AE_EBodyPx(PP As clsPP, ByVal pm_Px, ByVal pm_Index) As Integer 'V5.39
    AE_EBodyPx = PP.EBodyPx + ((pm_Px - PP.EBodyPx + PP.EBodyV) Mod PP.EBodyV) + PP.EBodyV * pm_Index
End Function

'Error Code Check Routine
Function AE_ErrorToInteger(ByVal Ck_Error) As Integer
    Select Case VarType(Ck_Error)
        Case vbEmpty, vbNull '0, 1
            AE_ErrorToInteger = 0
        Case vbInteger To vbCurrency '2 To 6
            'If Ck_Error = 0 Then
            '    AE_ErrorToInteger = 0
            'ElseIf Ck_Error < 0 Then
            '    AE_ErrorToInteger = -1
            'Else
            '    AE_ErrorToInteger = 1
            'End If
            AE_ErrorToInteger = Ck_Error
        Case Else
            AE_ErrorToInteger = 1
    End Select
End Function

Public Static Function AE_EScrlDisp(PP As clsPP, ByVal pm_DeNo As Integer) As Integer
Dim wk_EDeC As Integer
Dim wk_Displacement As Integer
Dim wk_MaxEDe As Integer 'V4.28
Dim wk_Limit As Integer 'V6.46S
   'If PP.No2Scroll And Not PP.EDeApendable And PP.Mode >= Cn_Mode3 Then 'V6.46S
   If PP.No2Scroll And Not AE_GetEDeApendable(PP) And PP.Mode >= Cn_Mode3 Then 'V6.55I
       wk_Limit = PP.LastEDe - 1 'V6.46S
   Else 'V6.46S
       wk_Limit = PP.MaxEDe 'V6.46S
   End If 'V6.46S
'
   'wk_EDeC = 0: If PP.ActiveEDe >= 0 Or Not PP.EDeApendable Then wk_EDeC = 1
   wk_EDeC = 0: If PP.ActiveEDe >= 0 Or Not AE_GetEDeApendable(PP) Then wk_EDeC = 1 'V6.55I
   '論理的な条件によって wk_Displacement を算出する。
   If PP.AllowNullDes Then 'V6.47B
      wk_Displacement = pm_DeNo - PP.TopEDe 'V6.47B
   ElseIf PP.MaxEDspC = 0 Then 'ボディ部が 1 行の場合。
      If PP.LastEDe - wk_EDeC <= 0 Then
         wk_Displacement = 0
      ElseIf pm_DeNo > PP.LastEDe - wk_EDeC Then
         wk_Displacement = 0
      Else
         wk_Displacement = pm_DeNo - PP.TopEDe
      End If
   Else
      If PP.MaxEDspC >= PP.MaxEDe Then 'PP.MaxEDe - PP.MaxEDspC = 0 'V6.48
         wk_Displacement = 0 'V6.48
      'If PP.LastEDe - wk_EDeC <= PP.MaxEDspC And PP.ReadableMaxEDe <= PP.MaxEDspC Then 'V4.29
      ElseIf PP.TopEDe = 0 And PP.LastEDe - wk_EDeC <= PP.MaxEDspC And PP.ReadableMaxEDe <= PP.MaxEDspC Then 'V4.32
         wk_Displacement = 0 'V4.29
      ElseIf pm_DeNo < PP.ReadableMaxEDe - PP.MaxEDspC And PP.ReadableMaxEDe >= wk_Limit Then 'V6.46S
         wk_Displacement = pm_DeNo - PP.TopEDe 'V4.28
      ElseIf pm_DeNo >= PP.ReadableMaxEDe - PP.MaxEDspC And PP.ReadableMaxEDe > PP.LastEDe Then 'V4.28
         wk_Displacement = PP.ReadableMaxEDe - PP.MaxEDspC - PP.TopEDe 'V4.28
      ElseIf pm_DeNo >= PP.LastEDe - wk_EDeC And pm_DeNo >= PP.ReadableMaxEDe - PP.MaxEDspC Then 'V4.28
         wk_Displacement = PP.LastEDe - wk_EDeC - 1 - PP.TopEDe 'V4.28
      'ElseIf PP.TopEDe + PP.LastEDe - wk_EDeC <= PP.MaxEDspC Then
      'ElseIf PP.LastEDe - wk_EDeC <= PP.MaxEDspC Then 'V4.28
      ElseIf PP.TopEDe = 0 And PP.LastEDe - wk_EDeC <= PP.MaxEDspC Then 'V4.32
         wk_Displacement = 0
      Else
         wk_Displacement = pm_DeNo - PP.TopEDe
      End If
   End If
   '物理的な制約のチェック。
   If wk_Limit > PP.ReadableMaxEDe Then 'V6.46S
       wk_MaxEDe = wk_Limit 'V6.46S
   Else 'V4.28
       wk_MaxEDe = PP.ReadableMaxEDe 'V4.28
   End If 'V4.28
   If PP.TopEDe + wk_Displacement < 0 Then
      AE_EScrlDisp = -PP.TopEDe
   'ElseIf PP.TopEDe + wk_Displacement > wk_MaxEDe - PP.MaxEDspC Then 'V4.28
   ElseIf PP.TopEDe + wk_Displacement > wk_MaxEDe - PP.MaxEDspC And wk_MaxEDe - PP.MaxEDspC > 0 Then 'V6.46S 'V6.47(4)
      AE_EScrlDisp = wk_MaxEDe - PP.MaxEDspC - PP.TopEDe 'V4.28
   Else
      AE_EScrlDisp = wk_Displacement
   End If
End Function

Public Static Sub AE_EScrlMax(PP As clsPP)
Dim wk_EDeC As Integer
Dim wk_Max As Integer 'V4.28
Dim wk_Limit As Integer 'V6.46S
   'If PP.No2Scroll And Not PP.EDeApendable And PP.Mode >= Cn_Mode3 Then 'V6.46S
   If PP.No2Scroll And Not AE_GetEDeApendable(PP) And PP.Mode >= Cn_Mode3 Then 'V6.55I
       wk_Limit = PP.LastEDe - 1 'V6.46S
   Else 'V6.46S
       wk_Limit = PP.MaxEDe 'V6.46S
   End If 'V6.46S
'
   'wk_EDeC = 0: If PP.ActiveEDe >= 0 Or Not PP.EDeApendable Then wk_EDeC = 1
   wk_EDeC = 0: If PP.ActiveEDe >= 0 Or Not AE_GetEDeApendable(PP) Then wk_EDeC = 1 'V6.55I
   If PP.MaxEDspC = 0 Then 'ボディ部が 1 行の場合。
      wk_Max = PP.LastEDe - wk_EDeC 'V4.28
   'ElseIf PP.TopEDe + PP.LastEDe - wk_EDeC <= PP.MaxEDspC Then
   ElseIf PP.TopEDe = 0 And PP.LastEDe - wk_EDeC <= PP.MaxEDspC Then 'V4.32
      wk_Max = 0 'V4.28
   ElseIf PP.LastEDe - wk_EDeC > wk_Limit - PP.MaxEDspC Then 'V6.46S
      wk_Max = wk_Limit - PP.MaxEDspC 'V6.46S
   Else
      wk_Max = PP.LastEDe - wk_EDeC - 1 'V4.28
   End If
'
   If PP.AllowNullDes Then 'V6.47B
      AE_EScrlBar(PP.ScX).Max = wk_Limit - PP.MaxEDspC 'V6.47B, 'V6.46S
   ElseIf wk_Max > PP.ReadableMaxEDe - PP.MaxEDspC Then 'V4.28
      AE_EScrlBar(PP.ScX).Max = wk_Max 'V4.28
   Else 'V4.28
      AE_EScrlBar(PP.ScX).Max = PP.ReadableMaxEDe - PP.MaxEDspC 'V4.28
   End If 'V4.28
End Sub

Public Function AE_Format$(CP As clsCP, ByVal pm_Value As Variant, ByRef pm_FractionC As Integer, ByVal pm_Final As Integer)
'Non Static Public Functin（AE_Change から呼出されるため）
'pm_FractionC パラメタは本来 ByVal を付けるべき。しかし、パラメタの計算順に左右されないように ByRef とする。
'pm_Final パラメタ  False: 文字のインプット途中 (AE_KeyPress, AE_KeyDown, AE_Change の途中)
'         　　　　  True:  確定 (AE_InitVal, AE_Check, AE_Derived, DD_ , AE_Change)
'         　　　　  True の場合には、FractionC は意味をもたない。
Dim wk_Txt$
Dim st_Work$
Dim wk_MaxLB As Long
Dim wk_Ln As Long
Dim wk_Pos As Integer
Dim wk_FracN As Integer
Dim wk_FracN2 As Integer 'V4.31
Dim wk_FormatDate As Date 'Variant
Dim wk_FormatChr$ 'V4.31
'
   wk_MaxLB = CP.MaxLength
   'wk_FmtLn = Len(CP.FormatChr) 'V6.50 で削除。
'
   If IsNull(pm_Value) Then
      If wk_MaxLB = 0 And pm_FractionC > 0 And Not pm_Final Then
         wk_Txt$ = Space$(pm_FractionC)
      Else
         wk_Txt$ = Space$(wk_MaxLB)
      End If
      'If CP.FixedFormat = 1 Then
      '   Call AE_SystemError("FixedFormat の指定がされている項目の値は Null にできないという", 130)
      'End If
   ElseIf CP.FormatClass = Cn_Date Then '日付。
   '日付の場合。
      'If InStr(pm_Value, Space$(1)) Then
      If InStr(pm_Value, Space$(1)) > 0 Then 'V7.00
         wk_Txt$ = pm_Value 'インプット途中なので。
      Else
         If Cn_ai21 Then 'V5.42
             st_Work$ = pm_Value
         'ElseIf VarType(pm_Value) = vbDate Then
         ElseIf IsDate(pm_Value) Then 'V4.16
            'st_Work$ = Format$(pm_Value, CP.FormatChr)
            st_Work$ = Format$(pm_Value, CP.FormatChr) 'V6.50F
            If VarType(pm_Value) <> vbDate And Len(st_Work$) > Len(pm_Value) Then 'V4.16
                st_Work$ = pm_Value 'V4.16
            ElseIf CP.FixedFormat = 1 And Left$(st_Work$, 1) >= "1" And Left$(st_Work$, 1) <= "9" Then 'V4.15
               If LCase$(Left$(CP.FormatChr, 4)) = "ggee" Then 'V4.15
                  st_Work$ = "明01" & Mid$(pm_Value, 5) 'V4.15
               ElseIf LCase$(Left$(CP.FormatChr, 4)) = "gggee" Then 'V4.15
                  st_Work$ = "明治01" & Mid$(pm_Value, 7) 'V4.15
               Else 'V4.22
                  wk_FormatDate = CVDate(st_Work$) 'V4.22
                  If wk_FormatDate < #1/1/1000# Then 'V4.22
                      st_Work$ = "0" & st_Work$ 'V4.22
                  Else 'V4.22
                      st_Work$ = st_Work$ 'V4.22
                  End If 'V4.22
               End If 'V4.15
            End If 'V4.15
         '日付とみなせない値のときに、ここでエラーにしてもよいが、部品でのエラーメッセージが出なくなってしまう。
         Else
            st_Work$ = pm_Value
         End If
         If CP.Alignment = 1 Then '右詰め。
            wk_Txt$ = RightWid$(st_Work$, wk_MaxLB)
            wk_Ln = LenWid(wk_Txt$) 'V4.15
            If wk_Ln < wk_MaxLB Then wk_Txt$ = Space$(wk_MaxLB - wk_Ln) & wk_Txt$ 'V4.15
         Else
            wk_Txt$ = LeftWid$(st_Work$, wk_MaxLB)
            wk_Ln = LenWid(wk_Txt$) 'V4.15
            If wk_Ln < wk_MaxLB Then wk_Txt$ = wk_Txt$ & Space$(wk_MaxLB - wk_Ln) 'V4.15
         End If
      End If
   'ElseIf CP.FormatClass = Cn_Time Then '時刻。
   ElseIf Not AE_Numerical(CP.FormatClass) Then '数値、字数値、符数、符字数、以外。'V6.50
   '日付と数値 (字数値、符数、符字数) 以外の場合。(コード、メモ、名称、時刻)
      'If wk_FmtLn = 0 Or Not pm_Final Then
      If CP.FormatChr = "" Or Not pm_Final Then 'V6.50
         st_Work$ = pm_Value
         If Not pm_Final Then st_Work$ = pm_Value & Space$(pm_FractionC)
      Else
         'st_Work$ = Format$(pm_Value, CP.FormatChr)
         st_Work$ = Format$(pm_Value, CP.FormatChr) 'V6.50F
      End If
      wk_Ln = LenWid(st_Work$)
      If wk_Ln < wk_MaxLB Then
         If CP.Alignment = 1 Then '右詰め。
            wk_Txt$ = Space$(wk_MaxLB - wk_Ln) & st_Work$
         Else
            wk_Txt$ = st_Work$ & Space$(wk_MaxLB - wk_Ln)
         End If
      ElseIf wk_Ln > wk_MaxLB And wk_MaxLB > 0 Then
         If CP.Alignment = 1 Then '右詰め。
            wk_Txt$ = RightWid$(st_Work$, wk_MaxLB)
         Else
            wk_Txt$ = LeftWid$(st_Work$, wk_MaxLB)
         End If
      Else
         wk_Txt$ = st_Work$
      End If
   Else 'If AE_Numerical(CP.FormatClass) Then '数値、字数値、符数、符字数。'V6.50
   '数値 (字数値、符数、符字数) の場合。
      If CP.Alignment = 1 Then '右詰め数値。
         'If wk_FmtLn = 0 Then
         If CP.FormatChr = "" Then 'V6.50
            wk_Txt$ = CStr(pm_Value)
            If pm_Final Then 'V5.41
            ElseIf pm_FractionC = -1000 Then 'V5.41
               wk_Txt$ = "-" 'V5.41
            ElseIf pm_FractionC = -1001 Then 'V5.41
               wk_Txt$ = "-0" 'V5.41
            ElseIf pm_FractionC < 0 And pm_Value = 0 Then 'V5.41
               wk_Txt$ = "-0." & String$(-pm_FractionC - 1, "0") 'V5.41
            'ElseIf Abs(pm_FractionC) = 1 And Right$(wk_Txt$, 1) <> "." Then
            ''Abs(pm_FractionC) = 1 の場合。
            '   wk_Txt$ = wk_Txt$ & "."
            ElseIf Abs(pm_FractionC) >= 1 Then
               'wk_Txt$ = CStr(pm_Value) 'V5.41
               wk_Pos = InStr(wk_Txt$, ".") 'V5.41
               If wk_Pos = 0 Then 'V5.41
                  wk_FracN = 0 'V5.41
                  wk_Txt$ = wk_Txt$ & "."
               Else 'V5.41
                  wk_FracN = Len(wk_Txt$) - wk_Pos 'V5.41
               End If 'V5.41
               '
               If Abs(pm_FractionC) - 1 > wk_FracN Then '小数の 0 をインプット途中。
                  wk_Txt$ = wk_Txt$ & String(Abs(pm_FractionC) - wk_FracN - 1, "0") 'V5.41
               End If 'V5.41
            End If
         Else
            'wk_Pos = InStr(CP.FormatChr, ".")
            wk_Pos = InStr(CP.FormatChr, ";") 'V4.31
            If wk_Pos = 0 Then 'V4.31
               wk_FormatChr$ = AE_FormatNorm$(CP.FormatChr) 'V4.31 'V6.50
            Else 'V4.31
               wk_FormatChr$ = AE_FormatNorm$(Left$(CP.FormatChr, wk_Pos - 1)) 'V4.31 'V6.50
            End If 'V4.31
            wk_Pos = InStr(wk_FormatChr$, ".") 'V4.31
            If wk_Pos = 0 Then 'V4.31
                wk_FracN = 0 'V4.31
            Else 'V4.31
                wk_FracN = Len(wk_FormatChr$) - wk_Pos 'V4.31
            End If 'V4.31
            '
            'wk_Txt$ = Format$(CStr(pm_Value), CP.FormatChr)
            wk_Txt$ = FormatAndRound$(CStr(pm_Value), AE_FormatNorm$(CP.FormatChr)) 'V6.50F
            If pm_Final Then
            ElseIf pm_FractionC = -1000 Then
               wk_Txt$ = "-"
            ElseIf pm_FractionC = -1001 Then
               wk_Txt$ = "-0"
            ElseIf pm_FractionC < 0 Then
               wk_Txt$ = "-0." & String$(-pm_FractionC - 1, "0")
            'ElseIf wk_FracN = 0 Then 'V4.31
            '   wk_Txt$ = Format$(CStr(pm_Value), CP.FormatChr)
            ElseIf wk_FracN <> 0 Then
               'pm_FractionC は有効数字なので、321.0 のような場合に使えない。
               wk_Txt$ = CStr(pm_Value) 'V4.31
               wk_FracN2 = InStr(wk_Txt$, ".") 'V4.31
               If wk_FracN2 > 0 Then wk_FracN2 = Len(wk_Txt$) - wk_FracN2 'V4.31
               '
               If Abs(pm_FractionC) <= wk_FracN Then '小数点の途中インプット。
                  wk_Txt$ = Format$(wk_Txt$, Left$(wk_FormatChr$, wk_Pos - 1 + Abs(pm_FractionC))) 'V4.31
               ElseIf wk_FracN2 > wk_FracN Then '有効小数点オーバ。
                  wk_Txt$ = FormatAndRound$(Left$(wk_Txt$, Len(wk_Txt$) - wk_FracN2 + wk_FracN), wk_FormatChr$) 'V4.31
               Else '有効小数点ピッタリ。
                  wk_Txt$ = FormatAndRound$(wk_Txt$, wk_FormatChr$) 'V4.31
               End If 'V4.31
            End If
         End If
         'LenWid を用いる。
         wk_Ln = LenWid(wk_Txt$)
         If wk_Ln < wk_MaxLB Then
            wk_Txt$ = Space$(wk_MaxLB - wk_Ln) & wk_Txt$
         '以下の２行は存在してはいけない｡
         'ElseIf wk_Ln > wk_MaxLB And wk_MaxLB > 0 Then
         '   wk_Txt$ = Right$(wk_Txt$, wk_MaxLB)
         End If
      Else 'If wk_Txt$ <> "" And CP.Alignment <> 1 Then '左詰め数値。
         wk_Txt$ = CStr(pm_Value)
         If pm_Final Then 'V5.41
         ElseIf pm_FractionC = -1000 Then 'V5.41
            wk_Txt$ = "-" 'V5.41
         ElseIf pm_FractionC = -1001 Then 'V5.41
            wk_Txt$ = "-0" 'V5.41
         ElseIf pm_FractionC < 0 And pm_Value = 0 Then 'V5.41
            wk_Txt$ = "-0." & String$(-pm_FractionC - 1, "0") 'V5.41
         'ElseIf Abs(pm_FractionC) = 1 And Right$(wk_Txt$, 1) <> "." Then
         ''Abs(pm_FractionC) = 1 の場合。
         '   wk_Txt$ = wk_Txt$ & "."
         ElseIf Abs(pm_FractionC) >= 1 Then
            'wk_Txt$ = CStr(pm_Value) 'V5.41
            wk_Pos = InStr(wk_Txt$, ".") 'V5.41
            If wk_Pos = 0 Then 'V5.41
               wk_FracN = 0 'V5.41
               wk_Txt$ = wk_Txt$ & "."
            Else 'V5.41
               wk_FracN = Len(wk_Txt$) - wk_Pos 'V5.41
            End If 'V5.41
            '
            If Abs(pm_FractionC) - 1 > wk_FracN Then '小数の 0 をインプット途中。
               wk_Txt$ = wk_Txt$ & String(Abs(pm_FractionC) - wk_FracN - 1, "0") 'V5.41
            End If 'V5.41
         End If
         '
         wk_Ln = LenWid(wk_Txt$)
         If wk_Ln < wk_MaxLB Then
            st_Work$ = wk_Txt$ & String$(wk_MaxLB - wk_Ln, Space$(1))
         ElseIf wk_Ln > wk_MaxLB And wk_MaxLB > 0 Then
            'LeftWid$ を用いる。
            st_Work$ = LeftWid$(wk_Txt$, wk_MaxLB)
         Else
            st_Work$ = wk_Txt$
         End If
         'If wk_FmtLn > 0 Then
         If CP.FormatChr <> "" Then 'V6.50
            'wk_Txt$ = Format$(st_Work$, CP.FormatChr)
            wk_Txt$ = FormatAndRound$(st_Work$, AE_FormatNorm$(CP.FormatChr)) 'V6.50F
            'LenWid を用いる。
            wk_Ln = LenWid(wk_Txt$)
            If wk_Ln < wk_MaxLB Then
               wk_Txt$ = wk_Txt$ & Space$(wk_MaxLB - wk_Ln)
            ElseIf wk_Ln > wk_MaxLB And wk_MaxLB > 0 Then
               'LeftWid$ を用いる。
               wk_Txt$ = LeftWid$(wk_Txt$, wk_MaxLB)
            End If
         Else
            wk_Txt$ = st_Work$
         End If
      End If
   End If
'
   AE_Format$ = wk_Txt$
End Function

Public Function AE_FormatC$(CP As clsCP, ByVal pm_NewVal As Variant) 'V6.56
    Dim sr_Work As String
    sr_Work = FormatAndRound$(pm_NewVal, CP.FormatChr)
    If CP.Alignment = 1 And LenWid(sr_Work) < CP.MaxLength Then '右詰め
        AE_FormatC$ = Space$(CP.MaxLength - LenWid(sr_Work)) & sr_Work
    Else
        AE_FormatC$ = sr_Work
    End If
End Function

Public Function AE_FormatNorm$(ByVal pm_FormatChr$) 'V6.50F
Dim wk_Pos As Long
Dim wk_FormatNorm$
Dim wk_FormatChr$
Dim wk_FormatLeft$
Dim wk_FormatRight$
    pm_FormatChr$ = ";" & pm_FormatChr$ '先頭に ";" を付加する。
    wk_FormatNorm$ = ""
'
    Do While pm_FormatChr$ <> ""
        wk_Pos = InStr(2, pm_FormatChr$, ";")
        If wk_Pos = 0 Then
           wk_FormatChr$ = pm_FormatChr$
           pm_FormatChr$ = ""
        Else
           wk_FormatChr$ = Left$(pm_FormatChr$, wk_Pos - 1)
           pm_FormatChr$ = Mid$(pm_FormatChr$, wk_Pos)
        End If
'
        wk_Pos = InStr(wk_FormatChr$, ".")
        If wk_Pos > 0 Then
            wk_FormatLeft$ = Left$(wk_FormatChr$, wk_Pos)
            wk_FormatRight$ = Mid$(wk_FormatChr$, wk_Pos + 1)
            Do While wk_FormatRight$ <> "" And Left$(wk_FormatRight$, 1) = "0"
                wk_FormatLeft$ = wk_FormatLeft$ & "0"
                wk_FormatRight$ = Mid$(wk_FormatRight$, 2)
            Loop
            If wk_FormatRight$ = String$(Len(wk_FormatRight$), "#") Then
                wk_FormatChr$ = wk_FormatLeft$ & String$(Len(wk_FormatRight$), "0")
            End If
        End If
'
        wk_FormatNorm$ = wk_FormatNorm$ & wk_FormatChr$
    Loop
'
    AE_FormatNorm$ = Mid$(wk_FormatNorm$, 2) '先頭の ";" を取り除く。
End Function

Public Function AE_FormatRZS$(ByVal pm_TpStr$, ByVal pm_MaxLength As Integer, ByVal pm_FracN As Long) 'Right Zero Suppress 'V6.50
Dim wk_N As Integer
    wk_N = 0
    Do While Mid$(pm_TpStr$, pm_MaxLength - wk_N, 1) = "0" And wk_N < pm_FracN
        wk_N = wk_N + 1
    Loop
    AE_FormatRZS$ = Left$(pm_TpStr$, pm_MaxLength - wk_N) & Space$(wk_N)
End Function

Public Static Function AE_FormInit$(PP As clsPP, pm_Form As Form, ByVal pm_Title$, ByVal pm_IColor As Long, ByVal pm_EColor As Long, ByVal pm_RColor As Long, ByVal pm_CColor As Long) 'V4.07
'パラメタ pm_Title$ は使用していない。
'
    DoEvents
'
    AE_FormInit$ = "V6.60" 'レベルアップの際に変更。
'
    AE_AppPath$ = App.Path & "\"
'
    AE_Color(Cn_Status1) = pm_IColor
    AE_Color(Cn_Status2) = pm_EColor
    AE_Color(Cn_Status3) = pm_RColor
    AE_Color(Cn_Status4) = pm_RColor
    AE_Color(Cn_Status5) = pm_RColor
    AE_Color(Cn_Status6) = pm_CColor
    AE_Color(Cn_Status7) = pm_CColor
    AE_Color(Cn_Status8) = pm_CColor
'
    AE_ForeColor(0) = pm_CColor
    AE_BackColor(0) = Cn_ClNormalBack
'
'    PP.HeadTx = 0
    PP.BodyTx = PP.HeadN
    PP.EBodyTx = PP.BodyTx + PP.BodyN * (PP.MaxDsp + 1)
    PP.TailTx = PP.EBodyTx + PP.EBodyN * (PP.MaxEDsp + 1)
    PP.TailPx = PP.EBodyPx + PP.EBodyV * (PP.MaxEDe + 1)
    PP.ControlsC = PP.TailTx + PP.TailN
'
    PP.MaxDspC = PP.MaxDsp
    PP.MaxEDspC = PP.MaxEDsp
    PP.TopDe = 0
    PP.TopEDe = 0
    PP.LastDe = 0
    PP.LastEDe = 0
    PP.LastReadDe = 0 'V6.47(5)
    PP.LastReadEDe = 0 'V6.47(5)
    PP.ActiveDe = -1
    PP.ActiveEDe = -1
    PP.DeApendable = True
    PP.EDeApendable = True
'
    PP.MaskMode = True          '初期設定中は、マスクしておく。
    PP.RecalcMode = False
'
    PP.CursorDirection = Cn_Direction1 '1: Next
    PP.CursorDest = Cn_Dest0 'V6.45 'V6.51X
'
    PP.SlistCom = Null
    PP.JustAfterSList = False 'V4.24 で削除したが、V4.27 で復活。
'
    PP.Tx = 0
    PP.NextTx = Cn_NextTxCleared 'Clear PP.NextTx
    PP.CursorSet = False
'FormInit と GotFocus において設定。
    PP.Override = 1
'
    PP.CloseCode = -1 'V4.17
'
    PP.DateSaveFormat = "YYYY/MM/DD" 'V4.24
'
    PP.NeglectLostFocusCheck = False 'V4.24
'
    PP.AlreadyCDe = False 'V4.38
    PP.AlreadyCEDe = False 'V4.38
'
    PP.SSCommand5Ajst = False 'V4.38
'
    PP.SlistPx = -1 'V5.44
'
    PP.MouseDownTx = -1 'V6.44
'
    PP.ScrollObject = 3 'V6.44
'
    'PP.RightButtonTx = -1 'V6.49
    PP.SuppressKeyPress = -1 'V6.53
'
    PP.ExplicitExec = False 'V6.45
    PP.Executing = False
    PP.OnFocus = False
    PP.Operable = False
    PP.SlistCall = False
    PP.SuppressGotLostFocus = 0
    PP.LostFocusCheck = False
    PP.ServerCheck = 0
    PP.Activated = 0
'
    PP.UnderFurigana = False 'Furigana 補正 'V6.57
    PP.MaskFurigana = False 'Furigana 補正 'V6.57
'
    Dim nName As String 'V6.59Pop
    nName = String(250, Chr(0)) 'V6.59Pop
    Dim nLeng As Long 'V6.59Pop
    nLeng = Len(nName) 'V6.59Pop
    If (GetClassName(pm_Form.hwnd, nName, nLeng) <> 0) Then 'V6.59Pop
        Cn_DebugMode = ((Left(nName, 13) = "ThunderFormDC")) 'V6.59Pop
    End If 'V6.59Pop
    'テスト用 Cn_DebugMode = False 'テスト用
End Function

Public Static Function AE_GetDeApendable(PP As clsPP) As Boolean 'V6.55I
    AE_GetDeApendable = PP.DeApendable 'V6.55I
    If PP.Mode = Cn_Mode3 Then AE_GetDeApendable = False 'V6.55I
End Function 'V6.55I

Public Static Function AE_GetEDeApendable(PP As clsPP) As Boolean 'V6.55I
    AE_GetEDeApendable = PP.EDeApendable 'V6.55I
    If PP.Mode = Cn_Mode3 Then AE_GetEDeApendable = False 'V6.55I
End Function 'V6.55I

Public Static Function AE_GetInOutMode(ByVal pm_InOutMode As Long, ByVal pm_Mode As Integer) As Integer
Dim wk_PowerOfFour As Integer
    Select Case pm_Mode
        Case 1
            wk_PowerOfFour = 64
        Case 2
            wk_PowerOfFour = 16
        Case 3
            wk_PowerOfFour = 4
        Case 4
            wk_PowerOfFour = 1
    End Select
    AE_GetInOutMode = (pm_InOutMode \ wk_PowerOfFour) Mod 4
End Function
        
Public Function AE_IsNullZero(PP As clsPP, CP As clsCP) As Boolean
    If AE_SSSWin Then
        AE_IsNullZero = (PP.NullZero And CP.BlockNo = 1)
    Else
        AE_IsNullZero = PP.NullZero
    End If
End Function 'AE_IsNullZero

Public Function AE_IsWritableInOutMode(PP As clsPP, CP As clsCP) As Boolean 'V6.59IsWritable
    If PP.Mode <> Cn_Mode3 And CP.KeyInOkClass <> Asc("-") And AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2 Then
        AE_IsWritableInOutMode = True '----------
    Else
        AE_IsWritableInOutMode = False '----------
    End If
End Function

Public Static Function AE_GotFocus(PP As clsPP, CP As clsCP, Ct As Object) As Integer
Dim wk_Ln As Long
Dim wk_MaxLB As Long
Dim wk_P As Long
Dim wk_DeC As Integer
Dim wk_EDeC As Integer
Dim wk_ww As Integer
Dim wk_FractionC As Integer 'V6.50
   PP.OnFocus = True
   PP.CursorSet = False
'FormInit と GotFocus において設定。
   PP.Override = 1
   If AE_SSSWin Then
       PP.SelValid = (AE_Numerical(CP.FormatClass) Or CP.KeyInOkClass = Asc("0") Or CP.KeyInOkClass = Asc("C")) 'V6.60
   ElseIf Cn_ai21 Then 'V6.52
       PP.SelValid = AE_Numerical(CP.FormatClass) 'V6.52
   ElseIf PP.SpecSubID = "sdy" Then
       PP.SelValid = AE_Numerical(CP.FormatClass) And CP.Alignment = 1 '右詰め 'V6.50
   End If
'整合性のチェック。
   If PP.Px < PP.BodyTx Then
      If PP.Px <> Ct.TabIndex Then
         If CP.TypeA <> Cn_OptionButtonH And CP.TypeA <> Cn_OptionButtonC Then 'V4.15
            Call AE_SystemError("AE_GotFocus に", 140)
         End If 'V4.15
      End If
   ElseIf PP.Px < PP.EBodyPx Then
      wk_ww = Ct.TabIndex - PP.BodyTx
      If PP.Px <> PP.BodyPx + wk_ww Mod PP.BodyN + (wk_ww \ PP.BodyN + PP.TopDe) * PP.BodyV Then
         Call AE_SystemError("AE_GotFocus に", 141)
      End If
   ElseIf PP.Px < PP.TailPx Then
      wk_ww = Ct.TabIndex - PP.EBodyTx
      If PP.Px <> PP.EBodyPx + wk_ww Mod PP.EBodyN + (wk_ww \ PP.EBodyN + PP.TopEDe) * PP.EBodyV Then
         Call AE_SystemError("AE_GotFocus に", 142)
      End If
   Else
      If PP.Px - PP.TailPx + PP.TailTx >= PP.ControlsC Then
         Call AE_SystemError("AE_GotFocus に", 143)
      End If
   End If
'
   If PP.SuppressGotLostFocus = 1 Then PP.SuppressGotLostFocus = 2: PP.JustAfterSList = False: AE_GotFocus = Cn_CuNop100: Exit Function 'V4.27 で復活。'--------------------
'
   If TypeOf Ct Is TextBox Then
      'Locked のままになる障害の修正。
      Ct.Locked = False 'V6.49
   End If
   PP.MultiLineF = 0 'V6.50
'
   If Cn_ai21 And AE_Numerical(CP.FormatClass) And CP.Alignment = 1 And Right$(CP.TpStr, 1) = Space$(1) Then 'V6.50
      Ct = AE_Format$(CP, AE_Val(CP, CP.TpStr, wk_FractionC), wk_FractionC, False) 'V6.50
      PP.ChangeAtGotFocus = True 'V6.50
   Else 'V6.50
      PP.ChangeAtGotFocus = False 'V6.50
   End If 'V6.50
'
'   TX_Message = ""
   wk_Ln = LenWid(Ct) 'Len ではだめ。
   wk_MaxLB = CP.MaxLength 'Field Length
   Select Case CP.TypeA
      'Case Cn_NormalOrV, Cn_OutputOnly
      Case Cn_NormalOrV 'V4.31
         If PP.SelValid And PP.Override = 1 Then
            Ct.SelStart = 0
         ElseIf CP.Alignment <> 1 Then '左詰め
            Ct.SelStart = 0
         Else 'If CP.Alignment = 1 Then '右詰め
            If wk_MaxLB > wk_Ln Then Ct = Space$(wk_MaxLB - wk_Ln) & Ct
            'If wk_Ln > 0 Then Ct.SelStart = Len((Ct)) - PP.Override
            If wk_Ln > 0 Then
               'If AE_Numerical(CP.FormatClass) And CP.Alignment = 1 And PP.SpecSubID = "sdy" Then 'V6.46 'V6.50
               '   Ct.SelStart = 0
               'ElseIf Cn_ai21 Then 'V6.45
               If Cn_ai21 Then 'V6.45
                  If PP.ClickPosition = -1 Then 'And CP.Alignment = 1 Then 'V5.46
                     Ct.SelStart = Len(LeftWid$((Ct), CP.MaxLength)) - PP.Override 'V6.45
                  Else 'V5.46
                     'If PP.ClickPosition = -1 Then PP.ClickPosition = 0 'V5.46
                     Do While PP.ClickPosition < Len(LeftWid$((Ct), CP.MaxLength)) 'V6.45
                        If AE_KeyInOkChar(PP, Mid$((Ct), PP.ClickPosition + 1, 1), CP.KeyInOkClass) Then
                           If Not (AE_Numerical(CP.FormatClass)) Or Mid$((Ct), PP.ClickPosition + 1, 1) <> Space$(1) Then Exit Do '----------'V6.50
                        End If
                        PP.ClickPosition = PP.ClickPosition + 1 'V6.45
                     Loop 'V6.45
                     If PP.ClickPosition >= Len(LeftWid$((Ct), CP.MaxLength)) Then PP.ClickPosition = Len(LeftWid$((Ct), CP.MaxLength)) - 1 'V6.45
                     Ct.SelStart = PP.ClickPosition 'V6.45
                     'PP.ClickPosition = -1 'V6.46
                  End If
               ElseIf PP.SetCursorRR = False Then 'V6.46
                  wk_P = 0
                  Do While wk_P < Len(LeftWid$((Ct), CP.MaxLength)) 'V6.45
                     If AE_KeyInOkChar(PP, Mid$((Ct), wk_P + 1, 1), CP.KeyInOkClass) Then Exit Do '----------
                     wk_P = wk_P + 1 'V6.45
                  Loop 'V6.45
                  If wk_P >= Len(LeftWid$((Ct), CP.MaxLength)) Then wk_P = Len(LeftWid$((Ct), CP.MaxLength)) - 1 'V6.45
                  Ct.SelStart = wk_P 'V6.45
               Else
                  Ct.SelStart = Len(LeftWid$((Ct), CP.MaxLength)) - PP.Override 'V6.45
               End If
            End If
         End If
      'Case Else 'Cn_InputOnly, Cn_OptionButtonH, Cn_OptionButtonC, Cn_CheckBox, Cn_ListBox, Cn_OutputOnly
   End Select
'
   If PP.NextTx = PP.Tx Or Not IsNull(PP.SlistCom) Then
      PP.NextTx = Cn_NextTxCleared 'Clear PP.NextTx
      PP.JustAfterSList = False 'V4.27 で復活。
      'AE_GotFocus = Cn_CuNop '-1
      If Cn_ai21 And Not AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) Then 'V6.51C
          AE_GotFocus = Cn_CuCursorRest 'Cn_CuCursorRest '2 'V6.51C
      Else 'V6.51C
          AE_GotFocus = Cn_CuNop '-1
      End If 'V6.51C
   ElseIf PP.JustAfterSList Then 'V4.27 で復活。
      PP.JustAfterSList = False 'V4.27 で復活。
      AE_GotFocus = Cn_CuNop '-1 'V4.27 で復活。
   Else
   '以下は Tab キーや Mouse で無理にフォーカスを移動した場合。
      'V6.49 で以下の４行を削除。
      'If PP.RightButtonTx = PP.Tx Then 'V6.49
      '    Ct.Enabled = False 'V6.49
      '    'Debug.Print "Ct.Enabled = False " & CStr(Ct.TabIndex)
      'End If 'V6.49
      '
      PP.CursorDirection = Cn_Direction0 '0: Mouse
      'wk_DeC = 0: If PP.ActiveDe >= 0 Or Not PP.DeApendable Then wk_DeC = 1
      wk_DeC = 0: If PP.ActiveDe >= 0 Or Not AE_GetDeApendable(PP) Then wk_DeC = 1 'V6.55I
      'wk_EDeC = 0: If PP.ActiveEDe >= 0 Or Not PP.EDeApendable Then wk_EDeC = 1
      wk_EDeC = 0: If PP.ActiveEDe >= 0 Or Not AE_GetEDeApendable(PP) Then wk_EDeC = 1 'V6.55I
      If CP.TypeA <> Cn_OptionButtonH And CP.TypeA <> Cn_OptionButtonC And CP.TypeA <> Cn_CheckBox And (Not Ct.TabStop Or Not Ct.Enabled Or Not Ct.Visible) Then
         If PP.Mode = Cn_Mode3 And PP.Mode <> PP.ExMode Then
            PP.ExMode = PP.Mode
            AE_GotFocus = Cn_CuExTx '以前の項目にカーソルを戻す。
         ElseIf PP.Mode = PP.ExMode Then
            'Beep 'V6.46 で削除。
            AE_GotFocus = Cn_CuExTx '以前の項目にカーソルを戻す。
         Else
            PP.ExMode = PP.Mode
            AE_GotFocus = Cn_CuInit '先頭項目にカーソルを移動。
         End If
         Exit Function '--------------------
      ElseIf PP.AllowNullDes Then 'V6.47B
         AE_GotFocus = Cn_CuNop '-1
      ElseIf PP.Px >= PP.BodyTx And PP.Px < PP.EBodyPx And PP.De > PP.LastDe - wk_DeC Then
         Beep
         '"この上に空白の明細行があるので、ここにデータをインプットすることはできません。"
         If PP.Mode = PP.ExMode Then wk_Bool = AE_MsgLibrary(PP, "Cursor")
         AE_GotFocus = Cn_CuExTx: Exit Function '-------------------- '以前の項目にカーソルを戻す。
      ElseIf PP.Px >= PP.EBodyPx And PP.Px < PP.TailPx And PP.De > PP.LastEDe - wk_EDeC Then
         Beep
         '"この上に空白の明細行があるので、ここにデータをインプットすることはできません。"
         If PP.Mode = PP.ExMode Then wk_Bool = AE_MsgLibrary(PP, "Cursor")
         AE_GotFocus = Cn_CuExTx: Exit Function '-------------------- '以前の項目にカーソルを戻す。
      Else
         AE_GotFocus = Cn_CuNop '-1
      End If
   End If
'モードの切り換え直後を判定するための ExMode を更新する。
   PP.ExMode = PP.Mode
End Function

Sub AE_InitValSub(CP As clsCP, ByVal pm_Value, ByVal pm_Status As Integer)
    CP.ExVal = CP.CuVal
    If IsNull(pm_Value) Then 'V4.27
        CP.CuVal = Null 'V4.27
    Else 'V4.27
        CP.CuVal = AE_Val5(CP, pm_Value) 'V4.27
    End If 'V4.27
    If IsEmpty(pm_Value) Then CP.CuVal = Null
    CP.ExStatus = pm_Status
    CP.TpStr = AE_Format$(CP, CP.CuVal, 0, True)
    CP.StatusC = Cn_Status8
    CP.StatusF = Cn_Status8
    CP.RelCheckStatus = "" 'V4.29
    'CP.ErrorFlg = False 'V6.53
    CP.CheckRtnCode = 0 'V6.54
End Sub

Sub AE_InitValSubNorm(CP As clsCP, ByVal pm_Value, ByVal pm_Status As Integer) 'V6.59NData
    Call AE_InitValSub(CP, AE_NormData(CP, pm_Value), pm_Status) 'V6.59NData
End Sub

'●重要：この代わりに、AE_InOutMode2 を使用してください。この AE_InOutMode は互換性のために残してあるものです。
Public Static Sub AE_InOutMode(PP As clsPP, CP As clsCP, ByVal pm_Tx As Integer, ByVal pm_Mode$)
   If Len(pm_Mode$) <> 4 Then
      Call AE_SystemError("AE_InOutMode のパラメタ pm_Mode$ に", 150)
      Exit Sub '--------------------
   End If
   Call AE_InOutMode2(PP, CP, pm_Mode$)
End Sub

'CP で指定された項目を対象に InOutMode を変更する。
Public Static Sub AE_InOutMode2(PP As clsPP, CP As clsCP, ByVal pm_Mode$)
Dim wk_Px As Integer
Dim wk_Tx As Integer
    If Len(pm_Mode$) <> 4 Then
        Call AE_SystemError("AE_InOutMode2 のパラメタ pm_Mode$ に", 151)
        Exit Sub '--------------------
    End If
    If Cn_ai21 Then Stop 'AE_InOutMode2 の代わりに AE_InOutModeN_ﾌｫｰﾑ略称 を使用してください。
    'If PP.RecalcMode Then Exit Sub '--------------------
    wk_Px = CP.CpPx
    CP.InOutMode = (CP.InOutMode \ 256) * 256 + CLng(Mid$(pm_Mode$, 1, 1)) * 64 + CLng(Mid$(pm_Mode$, 2, 1)) * 16 + CLng(Mid$(pm_Mode$, 3, 1)) * 4 + CLng(Mid$(pm_Mode$, 4, 1)) 'InOutMode V4.33
    wk_Tx = AE_Tx(PP, wk_Px)
    If wk_Tx >= 0 Then
        Select Case CP.TypeA
            Case Cn_NormalOrV, Cn_InputOnly
                'AE_Controls(PP.CtB + wk_Tx).TabStop = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) 'V4.31
                'AE_Controls(PP.CtB + wk_Tx).TabStop = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) And ((CP.AutoEnter And Cn_Enabled) = Cn_Enabled) 'V6.47E
                AE_Controls(PP.CtB + wk_Tx).TabStop = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) And AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) 'V6.47X
                'Control.TabStop の設定あり。
            Case Cn_OptionButtonH, Cn_OptionButtonC, Cn_CheckBox 'V4.25
                'AE_Controls(PP.CtB + wk_Tx).Enabled = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) 'V4.31
                'このまま
                'AE_Controls(PP.CtB + wk_Tx).Enabled = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) And ((CP.AutoEnter And Cn_Enabled) = Cn_Enabled) 'V6.47E
                AE_Controls(PP.CtB + wk_Tx).Enabled = (AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2) And AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) 'V6.47X
            Case Else 'Cn_OutputOnly, Cn_ListBox
        End Select
    End If
End Sub

'●重要：この代わりに、AE_InOutModeM_ﾌｫｰﾑ略称 を使用してください。この AE_InOutModeM は互換性のために残してあるものです。
Public Static Sub AE_InOutModeM(PP As clsPP, CP As clsCP, ByVal pm_Mode$)
   If Len(pm_Mode$) <> 4 Then
      Call AE_SystemError("AE_InOutModeM のパラメタ pm_Mode$ に", 152)
      Exit Sub '--------------------
   End If
'
   Call AE_MsgBox("AE_InOutModeM_ﾌｫｰﾑ略称(""ｺﾝﾄﾛｰﾙ略称"", ""入出の値"") というルーチンに切替えてください。", vbExclamation, AE_Title$) 'V4.24
End Sub

Public Function AE_IsEnable(ByVal pm_BlockNo As Integer, ByVal pm_ActiveBlockNo As Integer) As Boolean 'V6.47X
    If pm_ActiveBlockNo = -1 Then
        AE_IsEnable = True
    ElseIf pm_BlockNo = pm_ActiveBlockNo Then
        AE_IsEnable = True
    Else
        AE_IsEnable = False
    End If
End Function

'KeyPress イベントの共通ルーチン。
Public Static Sub AE_KeyPress(PP As clsPP, CP As clsCP, Ct As Object, ByRef pm_KeyAscii As Integer)
'pm_TA$ ----> CP.TpStr
Dim wk_Tx As Integer
Dim wk_SL As Long
Dim wk_Ln As Long
Dim wk_SaveMaskMode As Boolean
Dim wk_Txt$
Dim wk_SS As Long
Dim wk_Moji$
Dim wk_Moji2$
Dim wk_Moji3$
Dim st_Work$
Dim wk_FractionC As Integer
Dim wk_DeC As Integer
Dim wk_EDeC As Integer
Dim wk_FlushInput As Boolean
'
'Auto Enter 指定の項目については、日本語のインプットの IME 変換された先頭部分
'の文字列で項目フルになると、後続の変換文字列を受けるときに PP.Tx の方が進ん
'でいるが、CT.TabIndex の方は元のままなので、PP.Tx <> CT.TabIndex となること
'がある。なお、ボディ部のスクロールが発生する場合、スクロール後の CT.TabIndex
'と PP.Tx が一致してしまう場合（例えば、ボディ部に項目が一つしかない場合）に
'は、この現象は緩和される。
    wk_Tx = PP.Tx
'
    If wk_Tx < 0 Or wk_Tx >= PP.ControlsC Then
        Call AE_SystemError("AE_KeyPress に", 160)
        Exit Sub '--------------------
    End If
    If wk_Tx = PP.SuppressKeyPress Then 'V6.53
        PP.SuppressKeyPress = -1 'V6.53
        pm_KeyAscii = 0 'V6.53
        Exit Sub '--------------------
    End If
'
    Select Case pm_KeyAscii 'V6.45
        'Case 3, 22, 24, 26 'Copy, Paste, Cut, UnDo
        '    Beep
        '    pm_KeyAscii = 0
        '    Exit Sub '--------------------
        Case 1 To 7, 9 To 12, 14 To 29, 127
            Beep
            pm_KeyAscii = 0
            Exit Sub '--------------------
    End Select
'
'VB MultiLine Bug の回避処置。'V4.12
    If TypeOf Ct Is TextBox Then
        If Ct.MultiLine Then
            PP.MultiLineF = 2
            st_Work$ = Mid$((Ct), Ct.SelStart + 1, 1)
            If st_Work$ <> "" Then
               'If Asc(st_Work$) = pm_KeyAscii Then PP.MultiLineF = 1
               If (Asc(st_Work$) = pm_KeyAscii And (pm_KeyAscii <> 32 Or CP.KeyInOkClass <> Asc("M"))) Or (st_Work$ = "　" And pm_KeyAscii = 32 And CP.KeyInOkClass = Asc("M")) Then '２バイト文字のスペース。'V6.52
                  PP.MultiLineF = 1 'V6.52
               End If 'V6.52
            End If
        End If
    End If
'
   PP.CursorDirection = Cn_Direction1 '1:Next
'
   If pm_KeyAscii = vbKeyEscape Then 'Esc 'V5.40
      pm_KeyAscii = 0
      Exit Sub '--------------------
   ElseIf CP.TypeA <> Cn_NormalOrV Then 'TypeA
      'If CP.TypeA <> Cn_InputOnly And pm_KeyAscii <> vbKeyEscape Then Beep 'ComboBox2 での ESCAPE。
      Beep
      pm_KeyAscii = 0
      Exit Sub '--------------------
   'ElseIf Not Ct.TabStop Or Not Ct.Enabled Or Not Ct.Visible Then
   'ElseIf AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 And pm_KeyAscii <> vbKeyReturn Then 'V5.39
   'ElseIf (AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Or (CP.AutoEnter And Cn_Enabled) = 0) And pm_KeyAscii <> vbKeyReturn Then 'V6.47E
   'ElseIf (AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Or Not AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo)) And pm_KeyAscii <> vbKeyReturn Then 'V6.47X
   ElseIf (Not AE_IsWritableInOutMode(PP, CP) Or Not AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo)) And pm_KeyAscii <> vbKeyReturn Then 'V6.59IsWritable
      '入力不可の項目からのインプット。
      Beep
      pm_KeyAscii = 0
      Exit Sub '--------------------
   End If
'
   wk_Txt$ = (Ct) 'V4.33
   wk_SL = Ct.SelLength 'If CP.TypeA = Cn_NormalOrV Then
   wk_SS = Ct.SelStart  'wk_SS + 1 文字目がカレント文字。
   wk_FlushInput = False
   If CP.KeyInOkClass = Asc("1") Then 'V4.18
      wk_FlushInput = True 'V4.18
   ElseIf CP.KeyInOkClass = Asc("2") Then 'V4.30
      If wk_SS = 0 And wk_SL >= Len(RTrim$(wk_Txt$)) Then wk_FlushInput = True 'V4.30
   ElseIf CP.KeyInOkClass = Asc("3") Then 'V4.30
      If wk_SS = 0 And wk_SL >= Len(RTrim$(wk_Txt$)) Then wk_FlushInput = True 'V4.30
   'ElseIf wk_SL = CP.MaxLength And wk_SL > 0 Then
   ElseIf wk_SS = 0 And LenWid(Left$(wk_Txt$, wk_SL)) = CP.MaxLength And wk_SL > 0 Then 'V6.45
      PP.Override = 1
      wk_FlushInput = True
   ElseIf wk_SL > 1 Then
      If (CP.FormatClass = Cn_Memo Or CP.FormatClass = Cn_Name) And AE_SSSWin Then 'V6.52
      Else 'V6.52
         Beep
      End If 'V6.52
      PP.Override = 1
'      pm_KeyAscii = 0
'      Exit Sub '--------------------
   ElseIf wk_SL = 1 Then
      PP.Override = 1
   ElseIf wk_SL = 0 And wk_SS < Len(wk_Txt$) Then
      PP.Override = 0
   End If
'
   If pm_KeyAscii = 32 And CP.KeyInOkClass = Asc("M") Then pm_KeyAscii = Asc("　") '２バイト文字のスペース。'V6.52
   wk_Moji$ = Chr$(pm_KeyAscii) 'インプット文字。
   If AE_KeyInOkChar(PP, wk_Moji$, CP.KeyInOkClass) Then
      'wk_DeC = 0: If PP.ActiveDe >= 0 Or Not PP.DeApendable Then wk_DeC = 1
      wk_DeC = 0: If PP.ActiveDe >= 0 Or Not AE_GetDeApendable(PP) Then wk_DeC = 1 'V6.55I
      'wk_EDeC = 0: If PP.ActiveEDe >= 0 Or Not PP.EDeApendable Then wk_EDeC = 1
      wk_EDeC = 0: If PP.ActiveEDe >= 0 Or Not AE_GetEDeApendable(PP) Then wk_EDeC = 1 'V6.55I
      'If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Then
      'If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Or (CP.AutoEnter And Cn_Enabled) = 0 Then 'V6.47E
      'If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Or Not AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) Then 'V6.47X
      If Not AE_IsWritableInOutMode(PP, CP) Or Not AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) Then 'V6.59IsWritable
         wk_Bool = AE_MsgLibrary(PP, "OutputOnly")
         pm_KeyAscii = 0: Exit Sub '--------------------
      'ElseIf PP.Px >= PP.BodyTx And PP.Px < PP.EBodyPx And PP.De > PP.LastDe - wk_DeC Then
      ElseIf Not PP.AllowNullDes And (PP.Px >= PP.BodyTx And PP.Px < PP.EBodyPx And PP.De > PP.LastDe - wk_DeC) Then 'V6.47B
         '"ここにデータをインプットすることはできません。"
         wk_Bool = AE_MsgLibrary(PP, "InActiveDe")
         pm_KeyAscii = 0: Exit Sub '--------------------
      'ElseIf PP.Px >= PP.EBodyPx And PP.Px < PP.TailPx And PP.De > PP.LastEDe - wk_EDeC Then
      ElseIf Not PP.AllowNullDes And (PP.Px >= PP.EBodyPx And PP.Px < PP.TailPx And PP.De > PP.LastEDe - wk_EDeC) Then 'V6.47B
         '"ここにデータをインプットすることはできません。"
         wk_Bool = AE_MsgLibrary(PP, "InActiveDe")
         pm_KeyAscii = 0: Exit Sub '--------------------
      Else
         '和暦のチェック処理。
         If CP.KeyInOkClass = Asc("W") Then
            If wk_SS = 0 And InStr("01234", wk_Moji$) > 0 Then 'V4.15
               wk_Moji$ = Mid$("平昭大明平", CInt(wk_Moji$) + 1, 1) 'V4.15
            ElseIf wk_SS = 0 Xor InStr("Mm明Tt大Ss昭Hh平", wk_Moji$) > 0 Then
               pm_KeyAscii = 0
               Beep
               Exit Sub '--------------------
            End If
         End If
         '固定フォーマットの項目のデータが乱れないようにチェック。
         If CP.FixedFormat = 1 Then
            wk_Moji2$ = Mid$(wk_Txt$, wk_SS + 1, 1)
            If PP.Override And wk_SL <> 1 Then
               'Beep 音は、上で鳴らしているので、ここでは行わない。
               pm_KeyAscii = 0: Exit Sub '--------------------
            'ElseIf Not AE_KeyInOkChar(PP, wk_Moji2$, CP.KeyInOkClass) Then
            ElseIf Not AE_KeyInOkChar(PP, wk_Moji2$, CP.KeyInOkClass) And wk_Moji2$ <> Space$(1) And wk_Moji2$ <> "　" Then '２バイト文字のスペース。'V4.15
               Beep
               pm_KeyAscii = 0: Exit Sub '--------------------
            'Else
               '共通処理
            End If
         End If
'
         pm_KeyAscii = Asc(wk_Moji$) 'AE_KeyInOkChar で文字が変更されることがあるための処置。
         If wk_FlushInput = True Then
            wk_Txt$ = Mid$(wk_Txt$, wk_SS + 1, 1)
            wk_SaveMaskMode = PP.MaskMode
            PP.MaskMode = True
               Ct = wk_Txt$ 'ここでも、Change イベントが発生するが無視。
               Ct.SelStart = wk_SS
               Ct.SelLength = PP.Override 'If CP.TypeA = Cn_NormalOrV Then
            PP.MaskMode = wk_SaveMaskMode
         ElseIf PP.Override >= 1 Then '実際には PP.Override = 1
            wk_Moji2$ = Mid$(wk_Txt$, wk_SS + 1, 1)
            If wk_Moji2$ = "" Or wk_Moji2$ = Space$(1) Or wk_Moji2$ = "\" Or wk_Moji2$ = "　" Then '２バイト文字のスペース。
            ElseIf Not AE_KeyInOkChar(PP, wk_Moji2$, CP.KeyInOkClass) Then
               If wk_SL <= 1 Then Beep
               pm_KeyAscii = 0: Exit Sub '--------------------
            End If
            '数値のチェック。'V5.41
            If AE_Numerical(CP.FormatClass) Then 'V6.50
               wk_Moji2$ = Mid$(wk_Txt$, wk_SS + 1, 1)
               If wk_Moji$ <> wk_Moji2$ And InStr("0123456789 ", wk_Moji$) = 0 Then 'V6.48
                  Select Case wk_Moji$
                     Case "+"
                        If wk_Moji2$ <> "-" And wk_Moji2$ <> "" And wk_Moji2$ <> Space$(1) Then
                           Beep
                           pm_KeyAscii = 0: Exit Sub '--------------------
                        End If
                     Case "-"
                        If wk_Moji2$ <> "" And wk_Moji2$ <> Space$(1) Then
                          Beep
                          pm_KeyAscii = 0: Exit Sub '--------------------
                       End If
                     Case "."
                        If InStr(wk_Txt$, ".") > 0 Or InStr(CP.FormatChr, ".") = 0 Then 'V6.48
                           'Beep
                           If PP.SuppressBeep Then 'V6.49
                              PP.SuppressBeep = False 'V6.49
                           Else 'V6.49
                              Beep
                           End If
                           pm_KeyAscii = 0: Exit Sub '--------------------
                        End If
                     Case Else 'V6.48
                        Beep 'V6.48
                        pm_KeyAscii = 0: Exit Sub '--------------------
                  End Select
               End If
            End If
'
            If wk_SL > 1 And (CP.FormatClass = Cn_Memo Or CP.FormatClass = Cn_Name) And AE_SSSWin Then 'V6.52
               If CP.Alignment <> 1 Then 'V6.52
                  wk_Txt$ = Left$(wk_Txt$, wk_SS) & Chr$(pm_KeyAscii) & Mid$(wk_Txt$, wk_SS + wk_SL + 1) & Space$(LenWid(Mid$((Ct), wk_SS + 1, wk_SL)) - LenWid(Chr$(pm_KeyAscii))) 'V6.52
               Else 'V6.52
                  wk_Txt$ = Space$(LenWid(Mid$((Ct), wk_SS + 1, wk_SL)) - LenWid(Chr$(pm_KeyAscii))) & Left$(wk_Txt$, wk_SS) & Chr$(pm_KeyAscii) & Mid$(wk_Txt$, wk_SS + wk_SL + 1) 'V6.52
                  pm_KeyAscii = 0 'V6.52
               End If 'V6.52
            ElseIf Len(wk_Txt$) >= wk_SS + 1 Then
               wk_Txt$ = Left$(wk_Txt$, wk_SS) & Chr$(pm_KeyAscii) & Mid$(wk_Txt$, wk_SS + 2) 'V4.05
               'If pm_KeyAscii = -32448 And Mid$(wk_Txt$, wk_SS + 1, 1) = Space$(1) And Mid$(wk_Txt$, wk_SS + 2, 1) = Space$(1) Then 'V6.52
               '    wk_Txt$ = Left$(wk_Txt$, wk_SS) & Chr$(pm_KeyAscii) & Mid$(wk_Txt$, wk_SS + 3) 'V6.52
               'Else 'V6.52
               '    wk_Txt$ = Left$(wk_Txt$, wk_SS) & Chr$(pm_KeyAscii) & Mid$(wk_Txt$, wk_SS + 2) 'V4.05
               'End If 'V6.52
            End If
            wk_SaveMaskMode = PP.MaskMode
            PP.MaskMode = True
               Ct = wk_Txt$ 'ここでも、Change イベントが発生するが無視。
               Ct.SelStart = wk_SS
               Ct.SelLength = PP.Override 'If CP.TypeA = Cn_NormalOrV Then
            PP.MaskMode = wk_SaveMaskMode
         Else 'If PP.Override = 0 Then
            '数値のチェック。'V5.41
            If AE_Numerical(CP.FormatClass) Then 'V6.50
               If InStr("0123456789 ", wk_Moji$) = 0 Then 'V6.48
                  wk_Moji2$ = "": If wk_SS > 0 Then wk_Moji2$ = Mid$(wk_Txt$, wk_SS, 1)
                  wk_Moji3$ = Trim$(Left$(wk_Txt$, wk_SS))
                  Select Case wk_Moji$
                     Case "+"
                        If wk_Moji3$ <> "" And wk_Moji2$ <> "\" Then 'V6.48
                           Beep
                           pm_KeyAscii = 0: Exit Sub '--------------------
                        End If 'V6.48
                     Case "-"
                        If wk_Moji3$ <> "" And wk_Moji2$ <> "\" Then 'V6.48
                           Beep
                           pm_KeyAscii = 0: Exit Sub '--------------------
                        End If 'V6.48
                     Case "."
                        If InStr(wk_Txt$, ".") > 0 Or InStr(CP.FormatChr, ".") = 0 Then 'V6.48
                           Beep
                           pm_KeyAscii = 0: Exit Sub '--------------------
                        End If
                     Case Else 'V6.48
                        Beep 'V6.48
                        pm_KeyAscii = 0: Exit Sub '--------------------
                  End Select
               End If
            End If
         End If
         CP.CIn = Cn_ChrInput '2: Character Input
'AE_EndOfCharacterCheck: 'V4.22
      End If
   Else 'If Not AE_KeyInOkChar(PP, wk_Moji$, CP.KeyInOkClass) Then
      Select Case pm_KeyAscii
         Case vbKeyReturn 'RETURN is caught and processed by KeyDown.
            'ここに制御が渡されることはない。
            pm_KeyAscii = 0
         Case vbKeyBack 'Back Space
            pm_KeyAscii = 0
            'If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Then
            'If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Or (CP.AutoEnter And Cn_Enabled) = 0 Then 'V6.47E
            'If AE_GetInOutMode(CP.InOutMode, PP.Mode) <= Cn_InOutMode1 Or Not AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) Then 'V6.47X
            If Not AE_IsWritableInOutMode(PP, CP) Or Not AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) Then 'V6.59IsWritable
               Exit Sub '--------------------
            ElseIf CP.KeyInOkClass = Asc("-") Then 'V5.39
               Exit Sub '--------------------
            ElseIf CP.FixedFormat = 1 Then
               If AE_KeyInOkChar(PP, Space$(1), CP.KeyInOkClass) Then
                   wk_Txt$ = Left$(wk_Txt$, wk_SS) & Space$(LenWid(Mid$(wk_Txt$, wk_SS + 1, 1))) & Mid$(wk_Txt$, wk_SS + 2)
               End If
               Do While wk_SS > 0  '表示されている文字 Moji2$ を調べ wk_SS を進める。
                  wk_Moji2$ = Mid$(wk_Txt$, wk_SS, 1)
                  wk_SS = wk_SS - 1
                  If AE_KeyInOkChar(PP, wk_Moji2$, CP.KeyInOkClass) Then GoTo AE_KeyPressSetCt1 '---------->
               Loop
               wk_SS = Ct.SelStart 'もとの SelStart のままにする。
AE_KeyPressSetCt1:
               CP.TpStr = wk_Txt$
               PP.MaskMode = True 'Change イベントを無視するモード。
                  Ct = CP.TpStr 'ここで、Change イベントが発生する。
                  Ct.SelStart = wk_SS
                  Ct.SelLength = PP.Override 'If CP.TypeA = Cn_NormalOrV Then
               PP.MaskMode = wk_SaveMaskMode
               'PP.InitValStatus = Cn_ModeDataChanged
               Call AE_SetInitValStatus(PP, CP) 'V6.56S
               CP.StatusC = Cn_Status1 'Incomplete
               Ct.ForeColor = AE_Color(Cn_Status1) 'Incomplete
               If CP.TypeA = Cn_NormalOrV Or CP.TypeA = Cn_InputOnly Then Ct.BackColor = PP.BrightOnOff
               Exit Sub '--------------------
            ElseIf CP.MaxLength = 0 Then
               If wk_SS = 0 Then
                  If Len(wk_Txt$) > 0 Then wk_Txt$ = Right$(wk_Txt$, Len(wk_Txt$) - 1)
               Else
                  wk_Txt$ = Left$(wk_Txt$, wk_SS - 1) & Mid$(wk_Txt$, wk_SS + 1)
                  wk_SS = wk_SS - 1
               End If
               CP.TpStr = AE_Format$(CP, AE_Val(CP, wk_Txt$, wk_FractionC), wk_FractionC, False) 'V4.34
            ElseIf CP.Alignment = 1 Then '右詰め And CP.FixedFormat <> 1 And CP.MaxLength <> 0
               wk_Ln = Len(wk_Txt$)
               If AE_Numerical(CP.FormatClass) Then 'V6.50
                  'If Cn_ai21 Then 'V6.48
                  '    wk_Txt$ = Left$(wk_Txt$, wk_SS) 'V6.48
                  '    CP.TpStr = AE_Format$(CP, AE_Val(CP, wk_Txt$, wk_FractionC), wk_FractionC, False) 'V6.48
                  '    wk_SS = wk_Ln
                  '    GoTo AE_KeyPressSetCt2 '---------->
                  'Else
                  '小数点を Delete することで､ 欄をオーバする桁数にならないかチェックする。
                  If wk_SS = 0 Then 'V6.L45
                  ElseIf Mid(wk_Txt$, wk_SS, 1) = "." Then 'V6.L48
                     Dim wk_Ln2 As Integer
                     wk_Ln2 = Len(Trim(AE_Format$(CP, AE_Val(CP, Left(wk_Txt$, wk_SS - 1) & Mid(wk_Txt$, wk_SS + 1), wk_FractionC), wk_FractionC, True))) 'V6.L48
                     If wk_Ln2 > CP.MaxLength Or (wk_Ln2 > CP.MaxLength - 1 And (CP.FormatClass = Cn_Snum Or CP.FormatClass = Cn_Schn) And InStr(wk_Txt$, "-") = 0) Then 'V6.L48 'V6.L50N '符数類
                        Beep 'V6.L45
                        Exit Sub '--------------------
                     End If 'V6.L48
                  End If 'V6.L45
               End If
               '
               If wk_SS > 0 Then
                  If AE_KeyInOkChar(PP, Mid$(wk_Txt$, wk_SS, 1), CP.KeyInOkClass) Then
                     st_Work$ = Left$(wk_Txt$, wk_SS)
                     If RTrim$(wk_Txt$) <> "" Then
                        'LenWid を用いる。
                        wk_Txt$ = Space$(LenWid(Left$(st_Work$, 1))) & Left$(st_Work$, Len(st_Work$) - 1) & Right$(wk_Txt$, wk_Ln - wk_SS)
                     Else
                        wk_Txt$ = Space$(CP.MaxLength)
                     End If
                  ElseIf wk_SS > 1 Then
                     st_Work$ = Left$(wk_Txt$, wk_SS - 1)
                     If RTrim$(wk_Txt$) <> "" Then
                        'LenWid を用いる。
                        'wk_Txt$ = Space$(LenWid(Left$(st_Work$, 1))) & Left$(st_Work$, Len(st_Work$) - 1) & Right$(wk_Txt$, wk_Ln - wk_SS + 1)
                        wk_Txt$ = Space$(LenWid(Left$(st_Work$, 1))) & Left$(st_Work$, Len(st_Work$)) & Right$(wk_Txt$, wk_Ln - wk_SS) 'V6.57
                     Else
                        wk_Txt$ = Space$(CP.MaxLength)
                     End If
                  End If
               Else
                  Exit Sub '--------------------
               End If
               If AE_Numerical(CP.FormatClass) Then 'V6.50
                  If IsNull(AE_Val(CP, wk_Txt$, wk_FractionC)) Then 'V4.31
                     wk_SS = wk_Ln 'V6.48
                  ElseIf AE_Val(CP, wk_Txt$, wk_FractionC) = 0 Then 'V4.31
                     wk_Txt$ = "" 'V4.31
                     wk_SS = wk_Ln 'V6.48
                  End If 'V4.31
               End If 'V4.31
               CP.TpStr = AE_Format$(CP, AE_Val(CP, wk_Txt$, wk_FractionC), wk_FractionC, False) 'V4.34
               Do While wk_SS < wk_Ln 'V4.34
                  If AE_KeyInOkChar(PP, Mid$(CP.TpStr, wk_SS + 1, 1), CP.KeyInOkClass) Then Exit Do '---------- 'V4.34
                  wk_SS = wk_SS + 1 'V4.34
               Loop 'V4.34
            Else '左詰め And CP.FixedFormat <> 1 And CP.MaxLength <> 0
               If AE_Numerical(CP.FormatClass) Then 'V6.50
                  If Cn_ai21 Then 'V6.48
                      wk_Txt$ = Left$(wk_Txt$, wk_SS) 'V6.48
                      CP.TpStr = AE_Format$(CP, AE_Val(CP, wk_Txt$, wk_FractionC), wk_FractionC, False) 'V6.48
                      wk_SS = wk_Ln
                      GoTo AE_KeyPressSetCt2 '---------->
                  End If
               End If
               If wk_SS = 0 Then
                  If RTrim$(wk_Txt$) <> "" Then
                     'Len と LenWid を用いる。
                     wk_Txt$ = Right$(wk_Txt$, Len(wk_Txt$) - 1) & Space$(LenWid(Left$(wk_Txt$, 1)))
                  Else
                     wk_Txt$ = Space$(CP.MaxLength)
                  End If
               Else
                  wk_Txt$ = Left$(wk_Txt$, wk_SS - 1) & Mid$(wk_Txt$, wk_SS + 1) & Space$(LenWid(Mid$(wk_Txt$, wk_SS, 1)))
                  wk_SS = wk_SS - 1
               End If
               If AE_Numerical(CP.FormatClass) Then 'V6.50
                  If IsNull(AE_Val(CP, wk_Txt$, wk_FractionC)) Then 'V4.31
                  ElseIf AE_Val(CP, wk_Txt$, wk_FractionC) = 0 Then 'V4.31
                     wk_Txt$ = "" 'V4.31
                  End If 'V4.31
               End If 'V4.31
               CP.TpStr = AE_Format$(CP, AE_Val(CP, wk_Txt$, wk_FractionC), wk_FractionC, False) 'V4.34
            End If
AE_KeyPressSetCt2:
            wk_SaveMaskMode = PP.MaskMode
            PP.MaskMode = True 'Change イベントを無視するモード。
                Ct = CP.TpStr 'ここで、Change イベントが発生する。
                Ct.SelStart = wk_SS
                Ct.SelLength = PP.Override 'If CP.TypeA = Cn_NormalOrV Then
            PP.MaskMode = wk_SaveMaskMode
            'PP.InitValStatus = Cn_ModeDataChanged
            Call AE_SetInitValStatus(PP, CP) 'V6.56S
            CP.StatusC = Cn_Status1 'Incomplete
            Ct.ForeColor = AE_Color(Cn_Status1) 'Incomplete
            If CP.TypeA = Cn_NormalOrV Or CP.TypeA = Cn_InputOnly Then Ct.BackColor = PP.BrightOnOff
         Case vbKeyEscape 'Esc 'V5.40
         Case Else
            pm_KeyAscii = 0
            'Beep
            If PP.SuppressBeep Then 'V6.49
                PP.SuppressBeep = False 'V6.49
            Else 'V6.49
                Beep
            End If
      End Select
   End If
End Sub

Public Function AE_NormData(CP As clsCP, ByVal pm_Value As Variant) As Variant 'V6.59NData
    Dim wk_FractionC As Integer
    Dim wk_Txt$
    wk_Txt$ = AE_Format$(CP, pm_Value, wk_FractionC, True)
    AE_NormData = AE_Val(CP, wk_Txt$, wk_FractionC)
End Function

Public Function AE_Numerical(ByVal pm_FormatClass As Integer) As Boolean 'V6.50
    Select Case pm_FormatClass 'V6.50
        Case Cn_Numb, Cn_Snum, Cn_Chnu, Cn_Schn 'V6.50
            AE_Numerical = True
        Case Else
            AE_Numerical = False
    End Select
End Function

Public Sub AE_NotRelCheckError(ByRef CP_StatusC As Integer)
    If CP_StatusC >= Cn_Status6 Then
        CP_StatusC = CP_StatusC + 3
    ElseIf CP_StatusC >= Cn_Status3 Then
        CP_StatusC = CP_StatusC + 6
    End If
End Sub

Public Sub AE_Paste(PP As clsPP, CP As clsCP, Ct As TextBox) 'V6.55
Dim wk_Clip$
Dim wk_Moji$
Dim wk_Txt$
Dim st_Work1$
Dim st_Work2$
Dim wk_MaxLB As Integer
Dim wk_ii As Integer
Dim wk_Ln As Integer
Dim st_Work3$ 'V6.57
    wk_Clip$ = Clipboard.GetText()
    wk_Txt$ = ""
    Do While wk_Clip$ <> ""
        wk_Moji$ = Left$(wk_Clip$, 1)
        If AE_KeyInOkChar(PP, wk_Moji$, CP.KeyInOkClass) Then wk_Txt$ = wk_Txt$ & wk_Moji$
        wk_Clip$ = Mid$(wk_Clip$, 2)
    Loop
'
    wk_MaxLB = CP.MaxLength
    If wk_MaxLB = 0 Then wk_MaxLB = LenWid(wk_Txt$)
    If wk_MaxLB = 0 Then Exit Sub '---------->
'
    If CP.Alignment = 1 Then '右詰め。
        wk_Ln = wk_MaxLB
        Do
            st_Work2$ = RightWid$(wk_Txt$, wk_Ln)
            If CP.FormatChr <> "" Then
                On Error Resume Next
                st_Work2$ = FormatAndRound$(RightWid$(wk_Txt$, wk_Ln), CP.FormatChr)
            End If
            If LenWid(st_Work2$) <= wk_MaxLB Then Exit Do '---------->
            wk_Ln = wk_Ln - 1
        Loop
        '
        CP.CIn = Cn_ChrInput '2: Character Input
        Ct = st_Work2$
        Ct.SelStart = wk_MaxLB
        Ct.SelLength = PP.Override
    Else '左詰め。
        If CP.FormatChr <> "" And CP.FormatClass = Cn_Date Then
            wk_Ln = LenWid(AE_TrimS$(CP.FormatChr))
            wk_Txt$ = LeftWid$(wk_Txt$, wk_Ln)
        End If
        '
        st_Work3$ = "" 'V6.57
        If PP.SpecSubID = "sss" And (CP.FormatClass >= Cn_Code And CP.FormatClass <= Cn_Name) Then 'V6.57
            st_Work1$ = "" 'V6.57
            If Ct.SelLength >= 2 Then 'V6.57
                st_Work3$ = Mid(Ct.Text, Ct.SelStart + Ct.SelLength + 1) 'V6.57
            End If 'V6.57
        Else 'V6.57
            st_Work1$ = Ct.Text
        End If 'V6.57
        st_Work2$ = Left(Ct.Text, Ct.SelStart)
        wk_Ln = 0
        For wk_ii = Ct.SelStart + 1 To wk_MaxLB 'V6.57
            wk_Moji$ = Mid$(st_Work1$, wk_ii, 1)
            If wk_Txt$ = "" Then
            ElseIf wk_Moji$ = " " Or wk_Moji$ = "" Then
                wk_Moji$ = Left$(wk_Txt$, 1)
                wk_Txt$ = Mid$(wk_Txt$, 2)
            ElseIf AE_KeyInOkChar(PP, wk_Moji$, CP.KeyInOkClass) Then
                wk_Moji$ = Left$(wk_Txt$, 1)
                wk_Txt$ = Mid$(wk_Txt$, 2)
            End If
            wk_Ln = wk_Ln + LenWid(wk_Moji$)
            If wk_Ln > wk_MaxLB Then Exit For '---------->
            st_Work2$ = st_Work2$ & wk_Moji$
            If wk_Ln = wk_MaxLB Then Exit For '---------->
        Next wk_ii
        '
        CP.CIn = Cn_ChrInput '2: Character Input
        Ct = LeftWid(st_Work2$ & st_Work3$, wk_MaxLB) 'V6.57
        Ct.SelStart = 0
        Ct.SelLength = PP.Override
    End If
End Sub

Public Static Function AE_PopupMenu(PP As clsPP, CP As clsCP, Ct As Object) As Boolean 'V6.55S
    '置換え PP.CursorSave = -1 'V6.55S
    '置換え If PP.Tx = Ct.TabIndex Then Call AE_SaveFocus(PP) 'V6.55S
    If PP.Tx = Ct.TabIndex Then 'V6.59Pop
        PP.PopupTx = PP.Tx 'V6.59Pop
    Else
        PP.PopupTx = -1 'V6.59Pop
    End If
    PP.NeglectPopupFocus = True 'V6.59Pop
    Ct.Enabled = False 'V6.49
    PP.ShortCutTx = Ct.TabIndex 'V6.55S
    AE_PopupMenu = False 'V6.55S
    If TypeOf Ct Is TextBox Then
        Const CF_TEXT As Integer = 1
        If Clipboard.GetFormat(CF_TEXT) Then
            'If AE_GetInOutMode(CP.InOutMode, PP.Mode) >= Cn_InOutMode2 And AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) Then AE_PopupMenu = (PP.Tx = Ct.TabIndex) 'V6.47X
            If AE_IsWritableInOutMode(PP, CP) And AE_IsEnable(CP.BlockNo, PP.ActiveBlockNo) Then AE_PopupMenu = (PP.Tx = Ct.TabIndex) 'V6.59IsWritable
        End If
    End If
    'V6.57 If CP.FixedFormat = 1 Then AE_PopupMenu = False
    'PopupMenu SM_ShortCut, vbPopupMenuRightButton 'V6.49
    'If PP.CursorSave = CT.TabIndex Then Call AE_RestoreFocus(PP) 'V6.55S
    'CT.Enabled = True 'V6.49
 End Function

Public Static Function AE_Px(PP As clsPP, ByVal pm_Tx As Integer) As Integer
Dim wk_ww As Integer
    If pm_Tx < 0 Or pm_Tx >= PP.ControlsC Then
        Call AE_SystemError("AE_Px のパラメタに", 170)
        AE_Px = 0
    ElseIf pm_Tx < PP.BodyTx Then
        AE_Px = pm_Tx
    ElseIf pm_Tx < PP.EBodyTx Then
        wk_ww = pm_Tx - PP.BodyTx
        AE_Px = PP.BodyPx + wk_ww Mod PP.BodyN + (wk_ww \ PP.BodyN + PP.TopDe) * PP.BodyV
    ElseIf pm_Tx < PP.TailTx Then
        wk_ww = pm_Tx - PP.EBodyTx
        AE_Px = PP.EBodyPx + wk_ww Mod PP.EBodyN + (wk_ww \ PP.EBodyN + PP.TopEDe) * PP.EBodyV
    Else
        AE_Px = pm_Tx - PP.TailTx + PP.TailPx
    End If
End Function

Public Sub AE_Resize(PP As clsPP)
End Sub

'どのコントロールにフォーカスがあるかという位置を復元する。
Public Static Sub AE_RestoreFocus(PP As clsPP)
    If PP.CursorSave >= 0 Then
        PP.TimerWorkId = 8
        AE_Timer(PP.ScX).Interval = 10
        AE_Timer(PP.ScX) = True
    End If
End Sub

'どのコントロールにフォーカスがあるかという位置を保存する。
Public Sub AE_SaveFocus(PP As clsPP)
    PP.CursorSet = True
    PP.CursorSave = PP.Tx
    If PP.CursorSave >= 0 Then
        AE_CursorRest(PP.ScX).TabStop = True
        PP.CursorToWhere = Cn_CursorToRest
        PP.NextTx = Cn_NextTxCleared
        On Error Resume Next 'V4.32
        AE_CursorRest(PP.ScX).SetFocus
    End If
End Sub

Public Static Function AE_ScrlDisp(PP As clsPP, ByVal pm_DeNo As Integer) As Integer
Dim wk_DeC As Integer
Dim wk_Displacement As Integer
Dim wk_MaxDe As Integer 'V4.28
Dim wk_Limit As Integer 'V6.46S
   'If PP.No2Scroll And Not PP.DeApendable And PP.Mode >= Cn_Mode3 Then 'V6.46S
   If PP.No2Scroll And Not AE_GetDeApendable(PP) And PP.Mode >= Cn_Mode3 Then 'V6.55I
       wk_Limit = PP.LastDe - 1 'V6.46S
   Else 'V6.46S
       wk_Limit = PP.MaxDe 'V6.46S
   End If 'V6.46S
'
   'wk_DeC = 0: If PP.ActiveDe >= 0 Or Not PP.DeApendable Then wk_DeC = 1 'V6.52
   wk_DeC = 0: If PP.ActiveDe >= 0 Or Not AE_GetDeApendable(PP) Then wk_DeC = 1 'V6.55I
   '論理的な条件によって wk_Displacement を算出する。
   If PP.AllowNullDes Then 'V6.47B
      wk_Displacement = pm_DeNo - PP.TopDe 'V6.47B
   ElseIf PP.MaxDspC = 0 Then 'ボディ部が 1 行の場合。
      If PP.LastDe - wk_DeC <= 0 Then
         wk_Displacement = 0
      ElseIf pm_DeNo > PP.LastDe - wk_DeC Then
         wk_Displacement = 0
      Else
         wk_Displacement = pm_DeNo - PP.TopDe
      End If
   Else
      If PP.MaxDspC >= PP.MaxDe Then 'PP.MaxDe - PP.MaxDspC = 0 'V6.48
         wk_Displacement = 0 'V6.48
      'If PP.LastDe - wk_DeC <= PP.MaxDspC And PP.ReadableMaxDe <= PP.MaxDspC Then 'V4.29
      ElseIf PP.TopDe = 0 And PP.LastDe - wk_DeC <= PP.MaxDspC And PP.ReadableMaxDe <= PP.MaxDspC Then 'V4.32
         wk_Displacement = 0 'V4.29
      ElseIf pm_DeNo < PP.ReadableMaxDe - PP.MaxDspC And PP.ReadableMaxDe >= wk_Limit Then 'V6.46S
         wk_Displacement = pm_DeNo - PP.TopDe 'V4.28
      ElseIf pm_DeNo >= PP.ReadableMaxDe - PP.MaxDspC And PP.ReadableMaxDe > PP.LastDe Then 'V4.28
         wk_Displacement = PP.ReadableMaxDe - PP.MaxDspC - PP.TopDe 'V4.28
      ElseIf pm_DeNo >= PP.LastDe - wk_DeC And pm_DeNo >= PP.ReadableMaxDe - PP.MaxDspC Then 'V4.28
         wk_Displacement = PP.LastDe - wk_DeC - 1 - PP.TopDe 'V4.28
      'ElseIf PP.TopDe + PP.LastDe - wk_DeC <= PP.MaxDspC Then
      'ElseIf PP.LastDe - wk_DeC <= PP.MaxDspC Then 'V4.28
      ElseIf PP.TopDe = 0 And PP.LastDe - wk_DeC <= PP.MaxDspC Then 'V4.32
         wk_Displacement = 0
      Else
         wk_Displacement = pm_DeNo - PP.TopDe
      End If
   End If
   '物理的な制約のチェック。
   If wk_Limit > PP.ReadableMaxDe Then 'V6.46S
       wk_MaxDe = wk_Limit 'V6.46S
   Else 'V4.28
       wk_MaxDe = PP.ReadableMaxDe 'V4.28
   End If 'V4.28
   If PP.TopDe + wk_Displacement < 0 Then
      AE_ScrlDisp = -PP.TopDe
   'ElseIf PP.TopDe + wk_Displacement > wk_MaxDe - PP.MaxDspC Then 'V4.28
   ElseIf PP.TopDe + wk_Displacement > wk_MaxDe - PP.MaxDspC And wk_MaxDe - PP.MaxDspC > 0 Then 'V6.46S 'V6.47(4)
      AE_ScrlDisp = wk_MaxDe - PP.MaxDspC - PP.TopDe 'V4.28
   Else
      AE_ScrlDisp = wk_Displacement
   End If
End Function

Public Static Sub AE_ScrlMax(PP As clsPP)
Dim wk_DeC As Integer
Dim wk_Max As Integer 'V4.28
Dim wk_Limit As Integer 'V6.46S
   'If PP.No2Scroll And Not PP.DeApendable And PP.Mode >= Cn_Mode3 Then 'V6.46S
   If PP.No2Scroll And Not AE_GetDeApendable(PP) And PP.Mode >= Cn_Mode3 Then 'V6.55I
       wk_Limit = PP.LastDe - 1 'V6.46S
   Else 'V6.46S
       wk_Limit = PP.MaxDe 'V6.46S
   End If 'V6.46S
'
   'wk_DeC = 0: If PP.ActiveDe >= 0 Or Not PP.DeApendable Then wk_DeC = 1
   wk_DeC = 0: If PP.ActiveDe >= 0 Or Not AE_GetDeApendable(PP) Then wk_DeC = 1 'V6.55I
   If PP.MaxDspC = 0 Then 'ボディ部が 1 行の場合。
      wk_Max = PP.LastDe - wk_DeC 'V4.28
   'ElseIf PP.TopDe + PP.LastDe - wk_DeC <= PP.MaxDspC Then
   ElseIf PP.TopDe = 0 And PP.LastDe - wk_DeC <= PP.MaxDspC Then 'V4.32
      wk_Max = 0 'V4.28
   ElseIf PP.LastDe - wk_DeC > wk_Limit - PP.MaxDspC Then 'V6.46S
      wk_Max = wk_Limit - PP.MaxDspC 'V6.46S
   Else
      wk_Max = PP.LastDe - wk_DeC - 1 'V4.28
   End If
   '
   If PP.AllowNullDes Then 'V6.47B
      AE_ScrlBar(PP.ScX).Max = wk_Limit - PP.MaxDspC 'V6.47B, 'V6.46S
   ElseIf wk_Max > PP.ReadableMaxDe - PP.MaxDspC Then 'V4.28
      AE_ScrlBar(PP.ScX).Max = wk_Max 'V4.28
   Else 'V4.28
      AE_ScrlBar(PP.ScX).Max = PP.ReadableMaxDe - PP.MaxDspC 'V4.28
   End If 'V4.28
End Sub

Public Static Sub AE_SetCp(CP As clsCP, ByVal pm_Px, ByRef pm_SmrBuf$, ByRef pm_CQ$)
Dim wk_Item$
Dim wk_InOutMode As Long 'V4.29
Dim wk_HandMadeCtrl As Boolean 'V4.34
    Call AE_SmrGetPrm(wk_Item$, pm_SmrBuf$)
    pm_CQ$ = wk_Item$
'入出力区分
    Call AE_SmrGetPrm(wk_Item$, pm_SmrBuf$)
    '  Len を用いる。
    If Len(wk_Item$) <> 4 Then
        'AE_MsgBox を用いる。
        AE_MsgBox "Obj 文に誤り(入出力区分が4文字でない)。", vbExclamation, AE_Title$
        CP.InOutMode = 0
    Else
        wk_InOutMode = CLng(Mid$(wk_Item$, 1, 1)) * 64 + CLng(Mid$(wk_Item$, 2, 1)) * 16 + CLng(Mid$(wk_Item$, 3, 1)) * 4 + CLng(Mid$(wk_Item$, 4, 1)) 'InOutMode V4.29
        CP.InOutMode = wk_InOutMode * 256 + wk_InOutMode 'InOutMode V4.29
    End If
'日付, 数値 などの型 (FormatClass)
    Call AE_SmrGetPrm(wk_Item$, pm_SmrBuf$)
                         'AE_MsgBox を用いる。
    If wk_Item$ = "" Then AE_MsgBox "Obj 文に誤り(表示形式の指定が足りない)。", vbExclamation, AE_Title$
    If LCase$(Left$(wk_Item$, 4)) = "date" Or Left$(wk_Item$, 2) = "日付" Then
         CP.FormatClass = Cn_Date '日付。
    ElseIf LCase$(Left$(wk_Item$, 4)) = "time" Or Left$(wk_Item$, 2) = "時刻" Then 'V6.45
         CP.FormatClass = Cn_Time 'V6.45
    ElseIf LCase$(Left$(wk_Item$, 4)) = "numb" Or Left$(wk_Item$, 2) = "数値" Then
         CP.FormatClass = Cn_Numb
    ElseIf LCase$(Left$(wk_Item$, 4)) = "chnu" Or Left$(wk_Item$, 2) = "字数値" Then 'V6.50
         CP.FormatClass = Cn_Chnu 'V6.50
    ElseIf LCase$(Left$(wk_Item$, 4)) = "snum" Or Left$(wk_Item$, 3) = "符数" Then 'V6.45
         CP.FormatClass = Cn_Snum 'V6.45
    ElseIf LCase$(Left$(wk_Item$, 4)) = "schn" Or Left$(wk_Item$, 3) = "符字数" Then 'V6.50
         CP.FormatClass = Cn_Schn 'V6.50
    ElseIf LCase$(Left$(wk_Item$, 4)) = "code" Or Left$(wk_Item$, 3) = "コード" Then
         CP.FormatClass = Cn_Code
    ElseIf LCase$(Left$(wk_Item$, 4)) = "memo" Or Left$(wk_Item$, 2) = "メモ" Then
         CP.FormatClass = Cn_Memo
    ElseIf LCase$(Left$(wk_Item$, 4)) = "name" Or Left$(wk_Item$, 2) = "名称" Then
         CP.FormatClass = Cn_Name
    Else
         CP.FormatClass = Cn_NonC
    End If
'項目の長さ (MaxLength)
    Call AE_SmrGetPrm(wk_Item$, pm_SmrBuf$)
                         'AE_MsgBox を用いる。
    If wk_Item$ = "" Then AE_MsgBox "Obj 文に誤り(表示の長さの指定が足りない)。", vbExclamation, AE_Title$
    CP.MaxLength = CInt(wk_Item$)
'項目の桁数
    Call AE_SmrGetPrm(wk_Item$, pm_SmrBuf$)
                         'AE_MsgBox を用いる。
    If wk_Item$ = "" Then AE_MsgBox "Obj 文に誤り(桁数の指定が足りない)。", vbExclamation, AE_Title$
'自動エンターの指定(Auto Enter)
    Call AE_SmrGetPrm(wk_Item$, pm_SmrBuf$)
                         'AE_MsgBox を用いる。
    If wk_Item$ = "" Then AE_MsgBox "Obj 文に誤り(自動エンターの指定が足りない)。", vbExclamation, AE_Title$
    '  Len を用いる。          AE_MsgBox を用いる。
    If Len(wk_Item$) > 1 Then AE_MsgBox "Obj 文に誤り(自動エンターの指定が1文字でない)。", vbExclamation, AE_Title$
    If wk_Item$ = "-" Or wk_Item$ = "0" Or wk_Item$ = "M" Then
        'CP.AutoEnter = CP.AutoEnter And &HFFFE 'V6.45
        'CP.AutoEnter = Cn_Enabled '16 Or 0 'V6.47E
        CP.AutoEnter = 0 'V6.47X
    ElseIf wk_Item$ = "1" Or wk_Item$ = "A" Then
        'CP.AutoEnter = CP.AutoEnter Or 1 'V6.45
        'CP.AutoEnter = Cn_Enabled + Cn_AutoEnter '16 Or 1 'V6.47E
        CP.AutoEnter = Cn_AutoEnter '1 'V6.47X
    End If
'左揃え、右揃えの指定(Alignment)
    Call AE_SmrGetPrm(wk_Item$, pm_SmrBuf$)
                         'AE_MsgBox を用いる。
    If wk_Item$ = "" Then AE_MsgBox "Obj 文に誤り(左揃え、右揃えの指定が足りない)。", vbExclamation, AE_Title$
    '  Len を用いる。          AE_MsgBox を用いる。
    If Len(wk_Item$) > 1 Then AE_MsgBox "Obj 文に誤り(左揃え、右揃えの指定が1文字でない)。", vbExclamation, AE_Title$
    Select Case wk_Item$ 'V6.45
        Case "-", "0", "L", "M", "C", "N" 'MANDALA の Alignment 指定。'V6.45
            CP.Alignment = 0 '左詰め。
        Case "1", "R", "Q" 'MANDALA の Alignment 指定。'V6.45
            CP.Alignment = 1 '右詰め。
    End Select
'固定フォーマットの指定(Fixed Format)
    Call AE_SmrGetPrm(wk_Item$, pm_SmrBuf$)
                         'AE_MsgBox を用いる。
    If wk_Item$ = "" Then AE_MsgBox "Obj 文に誤り(固定フォーマットの指定が足りない)。", vbExclamation, AE_Title$
    '  Len を用いる。         AE_MsgBox を用いる。
    If Len(wk_Item$) > 1 Then AE_MsgBox "Obj 文に誤り(固定フォーマットの指定が1文字でない)。", vbExclamation, AE_Title$
    If wk_Item$ = "-" Or wk_Item$ = "0" Or wk_Item$ = "N" Then
        CP.FixedFormat = 0
    ElseIf wk_Item$ = "1" Or wk_Item$ = "Y" Then
        CP.FixedFormat = 1
    End If
'基本フォーマットの指定(Key In OK Character Set)
    Call AE_SmrGetPrm(wk_Item$, pm_SmrBuf$)
                         'AE_MsgBox を用いる。
    If wk_Item$ = "" Then AE_MsgBox "Obj 文に誤り(基本フォーマットの指定が指定が足りない)。", vbExclamation, AE_Title$
    '  Len を用いる。          AE_MsgBox を用いる。
    If Len(wk_Item$) > 1 Then AE_MsgBox "Obj 文に誤り(基本フォーマットの指定が1文字でない)。", vbExclamation, AE_Title$
'    If wk_Item$ = "-" Then 'V4.17 で削除
'        CP.KeyInOkClass = Asc("0") 'V4.17 で削除
'    Else 'V4.17 で削除
    CP.KeyInOkClass = Asc(wk_Item$)
'    End If 'V4.17 で削除
'フォーマットの指定(Format Characters)
    Call AE_SmrGetPrm(wk_Item$, pm_SmrBuf$)
                         'AE_MsgBox を用いる。
    If wk_Item$ = "" Then AE_MsgBox "Obj 文に誤り(フォーマットの指定が足りない)。", vbExclamation, AE_Title$
    If wk_Item$ = "-" Then
        CP.FormatChr = ""
    Else
        CP.FormatChr = wk_Item$
    End If
'Tab 番号の指定(SSTab Tab) 'V4.21
    Call AE_SmrGetPrm(wk_Item$, pm_SmrBuf$) 'V4.21
                         'AE_MsgBox を用いる。
    If wk_Item$ = "" Then AE_MsgBox "Obj 文に誤り(Tab 番号の指定が足りない)。", vbExclamation, AE_Title$
    If wk_Item$ = "-" Then
        CP.TabTab = -1
    Else
        CP.TabTab = CInt(wk_Item$)
    End If
'
'ブロック番号の指定(Block No) 'V5.40
    Call AE_SmrGetPrm(wk_Item$, pm_SmrBuf$) 'V5.40
                         'AE_MsgBox を用いる。
    If wk_Item$ = "" Then AE_MsgBox "Obj 文に誤り(ブロック番号の指定が足りない)。", vbExclamation, AE_Title$ 'V5.40
    '  Len を用いる。          AE_MsgBox を用いる。
    If Len(wk_Item$) > 1 Then AE_MsgBox "Obj 文に誤り(ブロック番号の指定が1文字でない)。", vbExclamation, AE_Title$ 'V5.40
    'CP.BlockNo = CInt(wk_Item$) 'V5.40
    CP.BlockNo = InStr("123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ", wk_Item$) 'V6.45
'
    'CP.NZero = InStr("123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ", wk_Item$) 'V6.45
'
'◎◎◎ PSI 情報を追加した場合には、この上にも追加が必要。
'
'オブジェクト省略タイプの指定(Object Type Abbr)
    Call AE_SmrGetPrm(wk_Item$, pm_SmrBuf$)
    '  Len を用いる。          AE_MsgBox を用いる。
    If Len(wk_Item$) > 1 Then AE_MsgBox "Obj 文に誤り(オブジェクトタイプの指定が1文字でない)。", vbExclamation, AE_Title$
    If wk_Item$ = "o" Then '小文字の "o" = Chr$(Cn_HandMadeC) は、Hand Made Control。'V4.34
        wk_HandMadeCtrl = True 'V4.34
        CP.TypeA = Cn_OutputOnly 'V4.34
    ElseIf wk_Item$ <> "" Then
        wk_HandMadeCtrl = False 'V4.34
        CP.TypeA = Asc(wk_Item$) 'V4.16 "R"(Cn_OptionButtonH) と "r"(Cn_OptionButtonC) を区別するため。
    Else
        wk_HandMadeCtrl = False 'V4.34
        CP.TypeA = Cn_NormalOrV
    End If
'
'CInSw の設定
    CP.CIn = Cn_NoInput '0: No Input
'
'Status を設定することで、ExStatus の初期設定を行う。InitVal で波及。
    CP.CpPx = pm_Px
    If wk_HandMadeCtrl Then 'V4.34
        CP.StatusC = Cn_Status8 'Space$(1)
        CP.StatusF = Cn_Status8 'Space$(1)
    Else
        CP.StatusC = Cn_Status0 'Space$(1)
        CP.StatusF = Cn_Status0 'Space$(1)
    End If
    CP.ExStatus = Cn_Status0 'Space$(1)
'
    'CP.ErrorFlg = False 'Error Flag 'V4.24
    CP.CheckRtnCode = 0 'Error Flag 'V6.54
'
    CP.LineCount = 1 'V4.24
End Sub

'指定のコントロールにフォーカスを移動する。
Public Static Function AE_SetFocus(PP As clsPP, ByVal pm_Tx As Integer) As Integer
   If pm_Tx < 0 Or pm_Tx >= PP.ControlsC Then '一般コントロール
      AE_SetFocus = 1
   ElseIf PP.Mode = Cn_Mode3 Then
      AE_SetFocus = 0
   ElseIf AE_Controls(PP.CtB + pm_Tx).TabStop And AE_Controls(PP.CtB + pm_Tx).Enabled And AE_Controls(PP.CtB + pm_Tx).Visible Then
      If pm_Tx = PP.Tx Then
         PP.CursorToWhere = pm_Tx
         If AE_CursorRest(PP.ScX).Visible And AE_CursorRest(PP.ScX).Enabled Then
            AE_CursorRest(PP.ScX).TabStop = True
            PP.NextTx = Cn_NextTxCleared
            On Error Resume Next 'V4.32
            AE_CursorRest(PP.ScX).SetFocus
            PP.CursorSet = True
         End If
      Else 'If pm_Tx <> PP.Tx Then
         AE_CursorRest(PP.ScX).TabStop = False
         PP.NextTx = pm_Tx
         On Error Resume Next 'V4.32
         AE_Controls(PP.CtB + pm_Tx).SetFocus
         PP.CursorSet = True
      End If
      AE_SetFocus = -1
   Else
      AE_SetFocus = 0
   End If
End Function

Sub AE_SetInitValStatus(PP As clsPP, CP As clsCP) 'V6.56S
    PP.InitValStatus = Cn_ModeDataChanged
    CP.Modified = Cn_ModeDataChanged
End Sub

'MouseUp の際に SelStart と SelLength をセットする。
Public Static Sub AE_SetSel(PP As clsPP, CP As clsCP, Ct As Object)
Dim wk_Ln As Long
Dim wk_MaxLB As Long
Dim wk_P As Long
   wk_Ln = LenWid(Ct) 'Len ではだめ。
   wk_MaxLB = CP.MaxLength 'Field Length
   Select Case CP.TypeA
      'Case Cn_NormalOrV, Cn_OutputOnly
      Case Cn_NormalOrV 'V4.31
         If PP.SelValid And PP.Override = 1 Then
            Ct.SelStart = 0
         ElseIf CP.Alignment <> 1 Then '左詰め
            'Ct.SelStart = 0
            If Cn_ai21 Then 'V6.45
               If PP.ClickPosition >= Len(LeftWid$((Ct), CP.MaxLength)) Then PP.ClickPosition = Len(LeftWid$((Ct), CP.MaxLength)) - 1 'V6.45
               If PP.ClickPosition < 0 Then PP.ClickPosition = 0 'V5.46
               Do While PP.ClickPosition > 0 'V6.45
                  If AE_KeyInOkChar(PP, Mid$((Ct), PP.ClickPosition + 1, 1), CP.KeyInOkClass) Then
                     If Not (AE_Numerical(CP.FormatClass)) Or Mid$((Ct), PP.ClickPosition + 1, 1) <> Space$(1) Then Exit Do '----------'V6.50
                  End If
                  PP.ClickPosition = PP.ClickPosition - 1 'V6.45
               Loop 'V6.45
               Ct.SelStart = PP.ClickPosition 'V6.45
               PP.ClickPosition = -1 'V6.46
            Else 'V6.45
               Ct.SelStart = 0
            End If 'V6.45
         Else 'If CP.Alignment = 1 Then '右詰め
            'If wk_Ln > 0 Then Ct.SelStart = Len((Ct)) - PP.Override
            If wk_Ln > 0 Then
               'If AE_Numerical(CP.FormatClass) And CP.Alignment = 1 And PP.SpecSubID = "sdy" Then 'V6.46 'V6.50
               '   Ct.SelStart = 0
               'ElseIf Cn_ai21 Then 'V6.45
               If Cn_ai21 Then 'V6.45
                  If PP.ClickPosition = -1 Then 'And CP.Alignment = 1 Then 'V5.46
                     Ct.SelStart = Len(LeftWid$((Ct), CP.MaxLength)) - PP.Override 'V6.46
                  Else 'V5.46
                     'If PP.ClickPosition = -1 Then PP.ClickPosition = 0 'V5.46
                     Do While PP.ClickPosition < Len(LeftWid$((Ct), CP.MaxLength)) 'V6.45
                        If AE_KeyInOkChar(PP, Mid$((Ct), PP.ClickPosition + 1, 1), CP.KeyInOkClass) Then
                           If Not (AE_Numerical(CP.FormatClass)) Or Mid$((Ct), PP.ClickPosition + 1, 1) <> Space$(1) Then Exit Do '----------'V6.50
                        End If
                        PP.ClickPosition = PP.ClickPosition + 1 'V6.45
                     Loop 'V6.45
                     If PP.ClickPosition >= Len(LeftWid$((Ct), CP.MaxLength)) Then PP.ClickPosition = Len(LeftWid$((Ct), CP.MaxLength)) - 1 'V6.45
                     Ct.SelStart = PP.ClickPosition 'V6.45
                     'PP.ClickPosition = -1 'V6.46
                  End If
               ElseIf PP.SetCursorRR = False Then 'V6.45
                  wk_P = 0
                  Do While wk_P < Len(LeftWid$((Ct), CP.MaxLength)) 'V6.45
                     If AE_KeyInOkChar(PP, Mid$((Ct), wk_P + 1, 1), CP.KeyInOkClass) Then Exit Do '----------
                     wk_P = wk_P + 1 'V6.45
                  Loop 'V6.45
                  If wk_P >= Len(LeftWid$((Ct), CP.MaxLength)) Then wk_P = Len(LeftWid$((Ct), CP.MaxLength)) - 1 'V6.45
                  Ct.SelStart = wk_P 'V6.45
               Else 'V6.45
                  'If wk_Ln > 0 Then Ct.SelStart = Len(LeftWid$((Ct), CP.MaxLength)) - PP.Override 'V6.45
                  Ct.SelStart = Len(LeftWid$((Ct), CP.MaxLength)) - PP.Override 'V6.46
               End If 'V6.45
            End If
         End If
'
         If CP.TypeA = Cn_NormalOrV Then
            If (PP.SelValid Or (PP.SetCursorLF And CP.Alignment <> 1)) And CP.FixedFormat <> 1 Then 'V6.56F
               Ct.SelLength = Len((Ct))
            Else
               Ct.SelLength = PP.Override
            End If
         End If
      'Case Else 'Cn_InputOnly, Cn_OptionButtonH, Cn_OptionButtonC, Cn_CheckBox, Cn_ListBox, Cn_OutputOnly
   End Select
End Sub

'カーソルの移動を目立たなくするために、この AE_SetSelLen で処理。
Public Static Sub AE_SetSelLen(PP As clsPP, CP As clsCP, ByRef Ct As Object, Optional ByVal pm_NeglectSetCursorLF)
   If CP.TypeA = Cn_NormalOrV Then
      If IsMissing(pm_NeglectSetCursorLF) Then pm_NeglectSetCursorLF = False 'V6.57
      'If (PP.SelValid Or (Not pm_NeglectSetCursorLF And PP.SetCursorLF And CP.Alignment <> 1)) And CP.FixedFormat <> 1 Then 'V6.56F, 'V6.57
      If Not pm_NeglectSetCursorLF And (PP.SelValid Or (PP.SetCursorLF And CP.Alignment <> 1)) And CP.FixedFormat <> 1 Then 'V6.56F, 'V6.57
         Ct.SelLength = Len((Ct))
      ElseIf AE_Numerical(CP.FormatClass) And CP.Alignment = 1 And PP.SpecSubID = "sdy" Then 'V6.50
         'Ct.SelLength = Len((Ct)) - Ct.SelStart
         Ct.SelLength = Len((Ct))
      ElseIf CP.KeyInOkClass = Asc("1") Then 'V4.18
         Ct.SelLength = Len((Ct)) 'V4.18
      ElseIf CP.KeyInOkClass = Asc("2") Then 'V4.18
         Ct.SelLength = Len((Ct)) 'V4.18
      ElseIf CP.KeyInOkClass = Asc("3") Then 'V4.18
         Ct.SelLength = Len((Ct)) 'V4.18
      Else
         Ct.SelLength = PP.Override
      End If
   End If
End Sub

Private Sub AE_SmrGetPrm(ByRef pm_Item$, ByRef pm_SmrBuf$)
Dim wk_Pos As Integer
Dim wk_Ln As Long
    wk_Pos = InStr(pm_SmrBuf$, Space$(1))
    If wk_Pos = 0 Then
        pm_Item$ = ""
    ElseIf wk_Pos >= 2 Then
        pm_Item$ = Left$(pm_SmrBuf$, wk_Pos - 1)
        wk_Ln = Len(pm_SmrBuf$)
        If wk_Ln > wk_Pos Then
            pm_SmrBuf$ = LTrim$(Right$(pm_SmrBuf$, wk_Ln - wk_Pos))
        ElseIf wk_Ln = wk_Pos Then
            pm_SmrBuf$ = ""
        Else
            Call AE_SystemError("SmrGetPrm に", 180)
        End If
    Else
        Call AE_SystemError("SmrGetPrm に", 181)
    End If
End Sub

'Status Bar のメッセージをクリアする。ただし、指定の文字色の場合に限りクリア。
Public Static Sub AE_StatusClear(PP As clsPP, ByVal pm_ForeColor As Long)
    If pm_ForeColor < 0 Or AE_StatusBar(PP.ScX).ForeColor = pm_ForeColor Then
        AE_StatusCodeBar(PP.ScX) = "" 'V4.24
        AE_StatusBar(PP.ScX) = ""
    End If
End Sub

'Status Bar のメッセージを強制的にクリアする。
Public Static Sub AE_StatusClearForce(PP As clsPP)
    AE_StatusCodeBar(PP.ScX) = ""
    AE_StatusBar(PP.ScX) = ""
End Sub

'Status Bar にメッセージを出力する。
Public Static Sub AE_StatusOut(PP As clsPP, ByVal Pm_Msg$, ByVal pm_ForeColor As Long, Optional ByVal pm_Code)
    AE_StatusCodeBar(PP.ScX).ForeColor = pm_ForeColor 'V4.24
    AE_StatusBar(PP.ScX).ForeColor = pm_ForeColor
    If IsMissing(pm_Code) And Not PP.SuppressCodeClear Then 'V4.34
        AE_StatusCodeBar(PP.ScX) = "" 'V4.34
    ElseIf Not IsMissing(pm_Code) Then 'V4.34
        AE_StatusCodeBar(PP.ScX) = pm_Code 'V4.24
    End If
    AE_StatusBar(PP.ScX) = Space$(1) & Pm_Msg$
End Sub

'システムエラーメッセージを表示する。'V4.33
Public Sub AE_SystemError(ByVal Pm_Msg$, ByVal pm_ErrorId As Integer)
    If AE_MsgBox(Pm_Msg$ & "エラーがあります (System Error" & CStr(pm_ErrorId) & _
        ")。ご連絡をお願いいたします。", vbExclamation, AE_Title$) Then Call AE_Stop
End Sub

Public Function AE_Tpstr$(ByVal pm_Txt$, ByVal pm_TypeA As Integer) 'V4.35
    If pm_TypeA = Cn_CheckBox Then
        If Trim$(pm_Txt$) = "1" Then
            AE_Tpstr$ = "1"
        Else
            AE_Tpstr$ = "0"
        End If
    Else
        AE_Tpstr$ = pm_Txt$
    End If
End Function

Public Function AE_TrimS$(ByVal pm_Str$) 'V5.42
Dim st_Work$
Dim wk_Chr$
Dim Pos As Integer
Dim Ln As Integer
    st_Work$ = ""
    Ln = Len(pm_Str$)
    Pos = 1
    Do While Pos <= Ln
        wk_Chr$ = Mid$(pm_Str$, Pos, 1)
        Select Case wk_Chr$
             Case "/", "-", ".", ":" 'V6.45
             Case Else
                 st_Work$ = st_Work$ & wk_Chr$
        End Select
        Pos = Pos + 1
    Loop
    AE_TrimS$ = st_Work$
End Function

'Px を Tx に変換する。
Public Static Function AE_Tx(PP As clsPP, ByVal pm_Px As Integer) As Integer
Dim wk_ww As Integer
Dim wk_De As Integer
   AE_Tx = -1
   If pm_Px < PP.BodyPx Then
       If pm_Px < PP.BodyTx Then AE_Tx = pm_Px
   ElseIf pm_Px < PP.EBodyPx Then
      wk_ww = pm_Px - PP.BodyPx
      If wk_ww Mod PP.BodyV < PP.BodyN Then
          wk_De = wk_ww \ PP.BodyV - PP.TopDe
          If wk_De >= 0 And wk_De <= PP.MaxDsp Then AE_Tx = PP.BodyTx + wk_ww Mod PP.BodyV + wk_De * PP.BodyN
      End If
   ElseIf pm_Px < PP.TailPx Then
      wk_ww = pm_Px - PP.EBodyPx
      If wk_ww Mod PP.EBodyV < PP.EBodyN Then
          wk_De = wk_ww \ PP.EBodyV - PP.TopEDe
          If wk_De >= 0 And wk_De <= PP.MaxEDsp Then AE_Tx = PP.EBodyTx + wk_ww Mod PP.EBodyV + wk_De * PP.EBodyN
      End If
   Else 'If pm_Px >= PP.TailPx Then
      wk_ww = pm_Px - PP.TailPx + PP.TailTx
      If wk_ww < PP.ControlsC Then AE_Tx = wk_ww
   End If
End Function

Public Function AE_Val(CP As clsCP, ByVal pm_Txt$, ByRef pm_FractionC As Integer) As Variant
'Non Static Sub （AE_Change から呼出されるため）
Dim wk_Moji$
Dim wk_TrimTxt$
Dim wk_Presentation$
Dim wk_Fraction As Integer
Dim wk_ValidValue As Boolean
Dim Wx As Integer
Dim wk_Ln As Long
   wk_TrimTxt$ = Trim$(pm_Txt$)
'
   If CP.FormatClass = Cn_Date Then '日付。
      pm_FractionC = 0 'V4.32
      If wk_TrimTxt$ = "" Then AE_Val = Null: Exit Function '--------------------
      If Cn_ai21 Then AE_Val = pm_Txt$: Exit Function '--------------------'V5.42
      'If InStr(pm_Txt$, Space$(1)) And Not AE_SSSWin Then AE_Val = pm_Txt$: Exit Function '--------------------'V4.34
      'If InStr(wk_TrimTxt$, Space$(1)) And Not AE_SSSWin Then AE_Val = pm_Txt$: Exit Function '--------------------'V4.38
      If InStr(wk_TrimTxt$, Space$(1)) > 0 And Not AE_SSSWin Then AE_Val = pm_Txt$: Exit Function '--------------------'V7.00
      '左詰め日付。
      If CP.Alignment <> 1 And Left$(pm_Txt$, 1) = Space$(1) Then AE_Val = pm_Txt$: Exit Function '--------------------'V5.42
      Do
         If Len(wk_TrimTxt$) = 8 Then
            For Wx = 1 To 8 'V4.11
               wk_Moji$ = Mid$(wk_TrimTxt$, Wx, 1) 'V4.11
               If wk_Moji$ < "0" Or wk_Moji$ > "9" Then Exit Do '---------- 'V4.11
            Next Wx 'V4.11
            '区切られていない場合、区切り文字を付ける。
            wk_TrimTxt$ = Left$(wk_TrimTxt$, 4) & "/" & Mid$(wk_TrimTxt$, 5, 2) & "/" & Right$(wk_TrimTxt$, 2) 'V4.24
         'V4.37 (YYYYMM)
         'ElseIf Len(wk_TrimTxt$) = 6 Then 'V4.37 (YYYYMM)
         'ElseIf Len(wk_TrimTxt$) = 6 And AE_SSSWin Then 'V4.37 (YYYYMM)
         ElseIf Len(wk_TrimTxt$) = 6 And UCase$(Right$(CP.FormatChr, 2)) = "MM" And AE_SSSWin Then 'V4.38 (YYYYMM)
            For Wx = 1 To 6
               wk_Moji$ = Mid$(wk_TrimTxt$, Wx, 1)
               If wk_Moji$ < "0" Or wk_Moji$ > "9" Then Exit Do '----------
            Next Wx
            '区切られていない場合、区切り文字を付ける。
            wk_TrimTxt$ = Left$(wk_TrimTxt$, 4) & "/" & Mid$(wk_TrimTxt$, 5, 2)
         ElseIf Len(wk_TrimTxt$) = 9 Then 'V4.14
            ' "." で区切られている場合には日付とみなされないので、その補正をする。
            wk_TrimTxt$ = Left$(wk_TrimTxt$, 3) & "/" & Mid$(wk_TrimTxt$, 5, 2) & "/" & Right$(wk_TrimTxt$, 2) 'V4.24
         End If
      Loop Until True 'No Loop
      If IsDate(wk_TrimTxt$) Then 'V4.32
         'V4.37 (YYYYMM)
         If UCase$(Right$(CP.FormatChr, 2)) = "MM" And Right$(wk_TrimTxt$, 2) = Right$(Format$(wk_TrimTxt$, "YYYY/MM"), 2) And AE_SSSWin Then 'V4.37 (YYYYMM)
            AE_Val = RTrim$(wk_TrimTxt$) 'Trim$ ではダメ。
         ElseIf UCase$(Right$(CP.FormatChr, 2)) = "DD" And Right$(wk_TrimTxt$, 2) = Right$(Format$(wk_TrimTxt$, "YYYY/MM/DD"), 2) Then 'V4.11
            'Dim wk_FormatDate As Variant
            'wk_FormatDate = CVDate(wk_TrimTxt$)
            'If wk_FormatDate < CDate("1000/01/01") Then 'V4.22
            '    AE_Val = "0" & CStr(wk_FormatDate) 'V4.22
            'Else 'V4.22
            '    AE_Val = CStr(wk_FormatDate) 'V4.22
            'End If 'V4.22
            AE_Val = RTrim$(wk_TrimTxt$) 'Trim$ ではダメ。
         Else
            AE_Val = RTrim$(pm_Txt$) 'Trim$ ではダメ。
         End If
      Else
         AE_Val = RTrim$(pm_Txt$) 'Trim$ ではダメ。
      End If
   ElseIf CP.FormatClass = Cn_Time Then '時刻。
      'If Cn_ai21 Then AE_Val = pm_Txt$: Exit Function '--------------------'V6.45
      AE_Val = pm_Txt$: Exit Function '--------------------'V6.45
   ElseIf AE_Numerical(CP.FormatClass) Then '数値系。'V6.50
      If wk_TrimTxt$ = "" Then AE_Val = Null: pm_FractionC = 0: Exit Function '--------------------
      wk_ValidValue = False
      wk_Fraction = 0 '負のゼロ以外の整数。
      wk_Presentation$ = ""
      wk_Ln = Len(wk_TrimTxt$)
      For Wx = 1 To wk_Ln
         wk_Moji$ = Mid$(wk_TrimTxt$, Wx, 1)
         If wk_Moji$ >= "1" And wk_Moji$ <= "9" Then
            If wk_Fraction > 0 Then wk_Fraction = wk_Fraction + 1  '正または負の小数。
            If wk_Fraction <= -1000 Then wk_Fraction = 0 '負のゼロ以外の整数。
            If wk_Fraction < 0 Then wk_Fraction = -wk_Fraction + 1 '正または負の小数。
            wk_Presentation$ = wk_Presentation$ & wk_Moji$
            wk_ValidValue = True
         ElseIf wk_Moji$ = "0" Then
            If wk_Fraction > 0 Then
               wk_Fraction = wk_Fraction + 1 '正または負の小数。
               wk_Presentation$ = wk_Presentation$ & wk_Moji$
            ElseIf wk_Fraction <= -1000 Then
               wk_Fraction = -1001 '負のゼロ。
               wk_Presentation$ = "-0"
            ElseIf wk_Fraction < 0 Then
               wk_Fraction = wk_Fraction - 1 '負のゼロの小数。
               wk_Presentation$ = wk_Presentation$ & wk_Moji$
            Else
               wk_Presentation$ = wk_Presentation$ & wk_Moji$
            End If
            wk_ValidValue = True
         ElseIf wk_Moji$ = "." Then
            If wk_Fraction = 0 Then
               wk_Fraction = 1 '最終の文字が . の正の数。
               wk_Presentation$ = wk_Presentation$ & wk_Moji$
            ElseIf wk_Fraction <= -1000 Then
               wk_Fraction = -1 '最終の文字が . のゼロ。
               wk_Presentation$ = "-0."
            Else
               Beep
            End If
         ElseIf wk_Moji$ = "+" Or wk_Moji$ = "-" Then
            If Wx = 1 Then
            'If wk_Presentation$ = "" Then
               wk_Presentation$ = wk_Moji$
               If wk_Moji$ = "-" Then wk_Fraction = -1000 '負のゼロ。
            Else
               Beep
            End If
         ElseIf wk_Moji$ = "\" Or wk_Moji$ = "," Then
         Else
            'Beep
            If wk_Moji$ <> Space$(1) Then Beep 'V6.48
         End If
      Next Wx
      pm_FractionC = wk_Fraction
'
      If CP.FormatClass = Cn_Numb Or CP.FormatClass = Cn_Snum Then '数値、符数
         If wk_ValidValue Then
            '通貨型は、絶対値が 99999999999999.9999 以上の値を保証できません。
            Wx = 0: If Left$(wk_Presentation$, 1) = "-" Then Wx = 1
            If InStr(wk_Presentation$, ".") > 0 Then
               If InStr(wk_Presentation$, ".") > 15 + Wx Then
                  Beep
                  wk_Presentation$ = Left$(wk_Presentation$, 14 + Wx)
               Else
                  If Len(Mid$(wk_Presentation$, InStr(wk_Presentation$, ".") + 1)) > 4 Then
                     Beep
                     wk_Presentation$ = Left$(wk_Presentation$, InStr(wk_Presentation$, ".") + 4)
                  End If
               End If
            ElseIf Len(wk_Presentation$) >= 15 + Wx Then
               Beep
               wk_Presentation$ = Left$(wk_Presentation$, 14 + Wx)
            End If
            AE_Val = CCur(wk_Presentation$)
         Else
            AE_Val = 0@
         End If
      Else '字数値、符字数
         If wk_ValidValue Then 'V6.50
            AE_Val = wk_Presentation$ 'V6.50
         Else 'V6.50
            AE_Val = "0" 'V6.50
         End If 'V6.50
      End If
'
   Else '日付、数値以外。
      wk_Presentation$ = RTrim$(pm_Txt$) 'Trim$ ではダメ。
      If wk_Presentation$ = "" Then
         If CP.KeyInOkClass = Asc("M") Then
            '
            Wx = 0
            Do While Mid$(pm_Txt$, Wx + 1, 1) = "　" '２バイト文字のスペース。
               Wx = Wx + 1
            Loop
            If Wx = 0 Then
               AE_Val = Null
            Else
               AE_Val = Left$(pm_Txt$, Wx)
            End If
         Else
            AE_Val = Null
         End If
         pm_FractionC = 0 'V4.10
      ElseIf AE_SSSWin Then 'V4.10
         AE_Val = pm_Txt$ 'V4.10
         pm_FractionC = 0 'V4.10
      Else
         AE_Val = wk_Presentation$
         pm_FractionC = LenWid(pm_Txt$) - LenWid(wk_Presentation$)
      End If
   End If
End Function

Public Function AE_Val2(CP As clsCP) As Variant
    AE_Val2 = AE_Val(CP, CP.TpStr, CP.FractionC)
End Function

Public Function AE_Val3(CP As clsCP, ByVal pm_Txt$) As Variant
    AE_Val3 = AE_Val(CP, pm_Txt$, CP.FractionC)
End Function

Public Function AE_Val4(CP As clsCP) As Variant
Dim wk_FractionC As Integer
    wk_FractionC = 0
    AE_Val4 = AE_Val(CP, CP.TpStr, wk_FractionC)
End Function

Public Function AE_Val5(CP As clsCP, ByVal pm_Txt$) As Variant
Dim wk_FractionC As Integer
    wk_FractionC = 0
    AE_Val5 = AE_Val(CP, pm_Txt$, wk_FractionC)
End Function

Function AE_ValX(ByVal pm_Value) 'V6.50
    If IsNull(pm_Value) Then
        AE_ValX = Null
    Else
        AE_ValX = Val(pm_Value)
    End If
End Function

Sub AE_WindowProcReset(PP As clsPP)
   If Cn_DebugMode Then Exit Sub
Dim wk_Tx As Integer
   For wk_Tx = 0 To PP.ControlsC - 1
      wk_Lng = SetWindowLong(AE_Controls(PP.CtB + wk_Tx).hwnd, GWL_WNDPROC, PP.lpPrevWndProc)
   Next wk_Tx
   If TypeOf AE_StatusBar(PP.ScX) Is TextBox Then
      wk_Lng = SetWindowLong(AE_StatusBar(PP.ScX).hwnd, GWL_WNDPROC, PP.lpPrevWndProc)
   End If
   wk_Lng = SetWindowLong(AE_ModeBar(PP.ScX).hwnd, GWL_WNDPROC, PP.lpPrevWndProc)
End Sub

Public Function LeftWid$(ByVal pm_Characters$, ByVal pm_Wid As Long)
    LeftWid$ = StrConv(LeftB$(StrConv(pm_Characters$, vbFromUnicode), pm_Wid), vbUnicode)
End Function

Public Function LenWid(ByVal pm_Characters As Variant) As Variant
    If IsNull(pm_Characters) Then
        Call AE_SystemError("LenWid のパラメタに", 190)
        LenWid = Null
        Exit Function '--------------------
    End If
    LenWid = LenB(StrConv(pm_Characters, vbFromUnicode))
End Function

Public Function MidWid$(ByVal pm_Characters$, ByVal pm_Wid As Long, Optional ByVal pm_LnWid)
    If IsMissing(pm_LnWid) Then
        MidWid$ = StrConv(MidB$(StrConv(pm_Characters$, vbFromUnicode), pm_Wid), vbUnicode)
    Else
        MidWid$ = StrConv(MidB$(StrConv(pm_Characters$, vbFromUnicode), pm_Wid, pm_LnWid), vbUnicode)
    End If
End Function

Public Function RightWid$(ByVal pm_Characters$, ByVal pm_Wid As Long)
    RightWid$ = StrConv(RightB$(StrConv(pm_Characters$, vbFromUnicode), pm_Wid), vbUnicode)
End Function

Public Function FormatAndRound$(ByVal pm_Value As Variant, ByVal pm_FormatChr As String) 'V6.59
    If IsNull(pm_Value) Then
        FormatAndRound$ = ""
        Exit Function '----------
    End If
    Dim sg_Value As String
    sg_Value = CStr(pm_Value)
'
    Do
        Dim M As Long '小数点より下の桁
        M = InStr(sg_Value, ".")
        If M > 0 Then M = Len(sg_Value) - M
        '
        Dim Ln As Long '先頭のフォーマット文字項目の文字数
        Ln = InStr(pm_FormatChr, ";") - 1
        If Ln < 0 Then Ln = Len(pm_FormatChr)
        '
        Dim N As Long '小数点より下の桁
        N = InStr(pm_FormatChr, ".")
        If N > 0 Then N = Ln - N
        '
        If N >= 0 And N + 1 = M And Right(sg_Value, 1) = "5" Then
            Dim I As Long
            For I = 1 To Ln
                Dim OneChr$
                OneChr$ = Mid$(pm_FormatChr, I, 1)
                Select Case OneChr$
                    Case "#", ",", ".", "\", "+", "-"
                    Case Else
                        If OneChr$ >= "0" And OneChr$ <= "9" Then
                        Else
                            Exit Do '-----
                        End If
                End Select
            Next I
            FormatAndRound$ = Format$(sg_Value & "1", pm_FormatChr) 'V6.59
            Exit Function '----------
        Else
            Exit Do '-----
        End If
    Loop
    '
    FormatAndRound$ = Format$(sg_Value, pm_FormatChr) 'V6.59
End Function 'V6.59

' === 20081205 === INSERT S - ACE)Masaki 「'」対応
Public Function AE_EditSQLText(ByVal pin_strSQLText As String) As String

    AE_EditSQLText = ""
    
    pin_strSQLText = Replace(pin_strSQLText, "'", "''")
    
    AE_EditSQLText = pin_strSQLText
    
End Function
' === 20081205 === INSERT E

