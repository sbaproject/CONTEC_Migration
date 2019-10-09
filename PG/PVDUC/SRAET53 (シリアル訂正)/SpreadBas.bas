Attribute VB_Name = "SpreadBas"
Option Explicit

'===========================================================================
'【使用用途】 スプレッドの任意のカラムにカーソルを移動させる。
'【関 数 名】 GP_SpActiveCell
'【引    数】 ByRef objSpread As Object：スプレッド
'             ByVal lngCol As Long：列
'             ByVal lngRow As Long：行
'【返    値】
'【更 新 日】
'【備    考】
'===========================================================================

Public Sub GP_SpActiveCell(ByRef objSpread As Object, _
                        ByVal lngCol As Long, _
                        ByVal lngRow As Long)
    With objSpread
        .SetFocus
        .Col = lngCol
        .Row = lngRow
        .Action = ActionActiveCell
        .EditMode = True
    End With

End Sub

'===========================================================================
'【使用用途】 スプレッドの単一選択モードの設定。
'【関 数 名】 GP_SpSingleMode
'【引    数】 ByRef objSpread As Object：スプレッド
'【返    値】
'【更 新 日】
'【備    考】
'===========================================================================

Public Sub GP_SpSingleMode(ByRef objSpread As Object)
    
    With objSpread
        .ReDraw = False
        'スプレッドのクリア
        .Action = ActionClearText
        '表示行=0
        .MaxRows = 0
        '入力不可。選択のみ。
        .OperationMode = OperationModeSingle
        '選択セルのセル色。
        .SelBackColor = &HFF8080
        '偶数行及び奇数行の背景色。
        Call .SetOddEvenRowColor(vbWhite, vbBlack, &H8000000F, vbBlack)
        .ReDraw = True
    End With

End Sub



