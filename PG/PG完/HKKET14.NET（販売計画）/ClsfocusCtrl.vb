Option Strict Off
Option Explicit On
Friend Class ClsFocusCtrl
	'//****************************************************************************************
	'//*
	'//*＜名称＞
	'//*    ClsFocusCtrl
	'//*
	'//*＜バージョン＞
	'//*    1.00
	'//*＜作成者＞
	'//*    RISE
	'//*＜説明＞
	'//*    改行キー入力時の時フォーカスコントロールの制御モジュール
	'//*****************************************************************************************
	'//* CHANGE HISTORY
	'//* Version  |YYYYMMDD|Programmer     |Description
	'//* ---------|--------|---------------|---------------------------------------------------*
	'//* 1.00     |20040401|Rise)          |新規
	'//*****************************************************************************************
	'//-----------------------------------------------------------------------------------------
	'// エラーメッセージ用
	'//-----------------------------------------------------------------------------------------
	Private Const cst_異常 As String = "実行時エラーです。システム担当者に連絡して下さい。"
	Private Const cst_詳細 As String = vbCrLf & vbCrLf & "[ 詳細 ]" & vbCrLf
	Private Const cst_参考 As String = vbCrLf & vbCrLf & "[ 参考 ]" & vbCrLf
	
	'//*****************************************************************************************
	'// 定数　　定義
	'//*****************************************************************************************
	Private Const gvcst_OBJMax件数 As Short = 500
	
	'//*****************************************************************************************
	'// 変数   宣言
	'//*****************************************************************************************
	Private gvint_MaxEnterCtrl As Short '//移動コントロールの数
	Private gvobj_EnterCtrl() As Object '//移動コントロールのオブジェクトを溜込む配列
	
	'//****************************************************************************************
	'//イニシャライズ
	'//****************************************************************************************
	'UPGRADE_NOTE: Class_Initialize は Class_Initialize_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Private Sub Class_Initialize_Renamed()
		gvint_MaxEnterCtrl = -1
		Erase gvobj_EnterCtrl
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	'//****************************************************************************************
	'//ターミネイト
	'//****************************************************************************************
	'UPGRADE_NOTE: Class_Terminate は Class_Terminate_Renamed にアップグレードされました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"' をクリックしてください。
	Private Sub Class_Terminate_Renamed()
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub

    '//*****************************************************************************************
    '//*
    '//* <メソッド>
    '//*    SetFocusCtrl
    '//*
    '//* <戻り値>
    '//*              True    :成功
    '//*              False   :失敗
    '//*
    '//* <引  数>     項目名                I/O    内容
    '//*              pmo_FmObj    　       I     Form
    '//*
    '//* <説  明>
    '//*    フォームのフォーカス可能コントロールの抽出
    '//*****************************************************************************************
    Function SetFocusCtrl(ByRef pmo_FmObj As Object) As Boolean

        Dim o_CTRL(gvcst_OBJMax件数) As Object
        Dim i_TabIDX(gvcst_OBJMax件数) As Short

        Dim i_COUNT As Short
        Dim i As Short
        Dim j As Short

        Dim i_wkobj As Object
        Dim i_wkidx As Short

        SetFocusCtrl = False

        '//現在の移動可能コントロールを取得
        i_COUNT = 0
        'add start 20190930 test kuwa

        'add end 20190930 kuwa
        'UPGRADE_WARNING: オブジェクト pmo_FmObj.Controls の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        For i = 0 To pmo_FmObj.Controls.Count - 1
            'UPGRADE_WARNING: オブジェクト pmo_FmObj.Controls の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            'UPGRADE_WARNING: TypeName に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            Select Case TypeName(pmo_FmObj.Controls(i))
                Case "Label"

                Case "Frame"

                    '//オブジェクトが対象
                Case "TextBox" '//ﾃｷｽﾄﾎﾞｯｸｽ
                    'UPGRADE_ISSUE: GoSub ステートメントはサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' をクリックしてください。
                    '2019/04/11 CHG START
                    'GoSub GET_CONTROL
                    'change start 20190930 kuwa
                    'GoTo GET_CONTROL
                    GET_CONTROL(pmo_FmObj, o_CTRL, i_TabIDX, i, i_COUNT)
                    'change end 20190930 kuwa
                    '2019/04/11 CHG E N D
                Case "ComboBox" '//ｺﾝﾎﾞﾎﾞｯｸｽ
                    'UPGRADE_ISSUE: GoSub ステートメントはサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' をクリックしてください。
                    '2019/04/11 CHG START
                    'GoSub GET_CONTROL
                    'change start 20190930 kuwa
                    'GoTo GET_CONTROL
                    GET_CONTROL(pmo_FmObj, o_CTRL, i_TabIDX, i, i_COUNT)
                    'change end 20190930 kuwa
                    '2019/04/11 CHG E N D
                Case "CommandButton" '//ｺﾏﾝﾄﾞﾎﾞﾀﾝ
                    'UPGRADE_ISSUE: GoSub ステートメントはサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' をクリックしてください。
                    '2019/04/11 CHG START
                    'GoSub GET_CONTROL
                    'change start 20190930 kuwa
                    'GoTo GET_CONTROL
                    GET_CONTROL(pmo_FmObj, o_CTRL, i_TabIDX, i, i_COUNT)
                    'change end 20190930 kuwa
                    '2019/04/11 CHG E N D
                Case "CheckBox" '//ﾁｪｯｸﾎﾞｯｸｽ
                    'UPGRADE_ISSUE: GoSub ステートメントはサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' をクリックしてください。
                    '2019/04/11 CHG START
                    'GoSub GET_CONTROL
                    'change start 20190930 kuwa
                    'GoTo GET_CONTROL
                    GET_CONTROL(pmo_FmObj, o_CTRL, i_TabIDX, i, i_COUNT)
                    'change end 20190930 kuwa
                    '2019/04/11 CHG E N D
                Case "OptionButton" '//ｵﾌﾟｼｮﾝﾎﾞﾀﾝ
                    'UPGRADE_ISSUE: GoSub ステートメントはサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' をクリックしてください。
                    '2019/04/11 CHG START
                    'GoSub GET_CONTROL
                    'change start 20190930 kuwa
                    'GoTo GET_CONTROL
                    GET_CONTROL(pmo_FmObj, o_CTRL, i_TabIDX, i, i_COUNT)
                    'change end 20190930 kuwa
                    '2019/04/11 CHG E N D
                Case "ListView" '//ﾘｽﾄﾋﾞｭｰ
                    'UPGRADE_ISSUE: GoSub ステートメントはサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' をクリックしてください。
                    '2019/04/11 CHG START
                    'GoSub GET_CONTROL
                    'change start 20190930 kuwa
                    'GoTo GET_CONTROL
                    GET_CONTROL(pmo_FmObj, o_CTRL, i_TabIDX, i, i_COUNT)
                    'change end 20190930 kuwa
                    '2019/04/11 CHG E N D
                Case "MSFlexGrid" '//MSFlexGrid
                    'UPGRADE_ISSUE: GoSub ステートメントはサポートされていません。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C5A1A479-AB8B-4D40-AAF4-DB19A2E5E77F"' をクリックしてください。
                    '2019/04/11 CHG START
                    'GoSub GET_CONTROL
                    'change start 20190930 kuwa
                    'GoTo GET_CONTROL
                    GET_CONTROL(pmo_FmObj, o_CTRL, i_TabIDX, i, i_COUNT)
                    'change end 20190930 kuwa
                    '2019/04/11 CHG E N D
                Case Else
            End Select

        Next i

        '//移動可能コントロールが存在しない場合は終了する
        If (i_COUNT = 0) Then
            Exit Function
        End If

        '//移動可能コントロールが存在する場合は移動可能コントロールを設定する
        For i = 1 To i_COUNT - 1 'sort処理 (単純交換法)
            For j = i + 1 To i_COUNT
                If (i_TabIDX(i) > i_TabIDX(j)) Then
                    i_wkidx = i_TabIDX(j)
                    i_wkobj = o_CTRL(j)
                    i_TabIDX(j) = i_TabIDX(i)
                    o_CTRL(j) = o_CTRL(i)
                    i_TabIDX(i) = i_wkidx
                    o_CTRL(i) = i_wkobj
                End If
            Next j
        Next i

        '//移動したいコントロール数を設定
        gvint_MaxEnterCtrl = i_COUNT
        ReDim gvobj_EnterCtrl(gvint_MaxEnterCtrl)

        For i = 1 To i_COUNT
            gvobj_EnterCtrl(i) = o_CTRL(i)
        Next i

        SetFocusCtrl = True

        Exit Function

        'delete start 20190930 kuwa GET_CONTROLをメソッド化したため、削除する。
        '        '//入力可能コントロールの配列取込--------------------------------
        'GET_CONTROL:

        '        '//TabStop、Enabled、VisibleがすべてTrueのものが対象
        '        'UPGRADE_WARNING: オブジェクト pmo_FmObj.Controls の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        If (pmo_FmObj.Controls(i).TabStop = True And pmo_FmObj.Controls(i).Enabled = True And pmo_FmObj.Controls(i).Visible = True) Then

        '            '//対象オブジェクトセット
        '            i_COUNT = i_COUNT + 1
        '            'UPGRADE_WARNING: オブジェクト pmo_FmObj.Controls の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            o_CTRL(i_COUNT) = pmo_FmObj.Controls(i)
        '            'UPGRADE_WARNING: オブジェクト pmo_FmObj.Controls の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '            i_TabIDX(i_COUNT) = Val(pmo_FmObj.Controls(i).TabIndex)
        '        End If

        '        'UPGRADE_WARNING: Return に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        '        '2019/04/11 CHG START
        '        'Return
        '        Return Nothing   '20190930 週明けはここから。EnterPress時にFor文が回数に満たないまま抜けてしまう。GoSubとReturnの役割がVB6と.Netで異なるため。　ブックマークのサイトを参照して作り変える。
        '        '2019/04/11 CHG E N D
        'delete end 20190930 kuwa

    End Function

    'add start 20190930 kuwa GET_CONTROLの代わりにメソッドを作成。GO_Subを使わない。
    '//*****************************************************************************************
    '//*
    '//* <メソッド>
    '//*    GET_CONTRL
    '//*
    '//* <戻り値>
    '//*              なし
    '//*
    '//* <引  数>     項目名              I/O    内容
    '//*              
    '//*
    '//* <説  明>
    '//*    入力可能コントロールの配列取込--------------------------------
    '//*****************************************************************************************
    Sub GET_CONTROL(ByRef pmo_FmObj As Object, ByRef o_CTRL() As Object, ByRef i_TabIDX() As Short, ByRef i As Short, ByRef i_COUNT As Short)
        '//TabStop、Enabled、VisibleがすべてTrueのものが対象
        'UPGRADE_WARNING: オブジェクト pmo_FmObj.Controls の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If (pmo_FmObj.Controls(i).TabStop = True And pmo_FmObj.Controls(i).Enabled = True And pmo_FmObj.Controls(i).Visible = True) Then

            '//対象オブジェクトセット
            i_COUNT = i_COUNT + 1
            'UPGRADE_WARNING: オブジェクト pmo_FmObj.Controls の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            o_CTRL(i_COUNT) = pmo_FmObj.Controls(i)
            'UPGRADE_WARNING: オブジェクト pmo_FmObj.Controls の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            i_TabIDX(i_COUNT) = Val(pmo_FmObj.Controls(i).TabIndex)
        End If

    End Sub
    'add end 20190930 kuwa

    'add
    Sub GET_CONTROL2(ByRef paramc As Control, ByRef o_CTRL() As Object, ByRef i_TabIDX() As Short, ByRef i_COUNT As Integer)
        '//TabStop、Enabled、VisibleがすべてTrueのものが対象
        'UPGRADE_WARNING: オブジェクト pmo_FmObj.Controls の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        If (paramc.TabStop = True And paramc.Enabled = True And paramc.Visible = True) Then

            '//対象オブジェクトセット
            i_COUNT = i_COUNT + 1
            'UPGRADE_WARNING: オブジェクト pmo_FmObj.Controls の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            o_CTRL(i_COUNT) = paramc
            'UPGRADE_WARNING: オブジェクト pmo_FmObj.Controls の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            i_TabIDX(i_COUNT) = Val(paramc.TabIndex)        End If    End Sub    Function SetFocusCtrl2(ByRef pmo_FmObj As Object) As Boolean        Dim o_CTRL(gvcst_OBJMax件数) As Object        Dim i_TabIDX(gvcst_OBJMax件数) As Short        Dim i_COUNT As Short        Dim i As Short        Dim j As Short        Dim i_wkobj As Object        Dim i_wkidx As Short        SetFocusCtrl2 = False
        '//現在の移動可能コントロールを取得
        i_COUNT = 0        For Each topc As Control In pmo_FmObj.controls            For Each c As Control In topc.Controls                Select Case TypeName(c)                    Case "Label"                    Case "Frame"

                    '//オブジェクトが対象
                    Case "TextBox" '//ﾃｷｽﾄﾎﾞｯｸｽ

                        GET_CONTROL2(c, o_CTRL, i_TabIDX, i_COUNT)                    Case "ComboBox" '//ｺﾝﾎﾞﾎﾞｯｸｽ

                        GET_CONTROL2(c, o_CTRL, i_TabIDX, i_COUNT)                    Case "CommandButton" '//ｺﾏﾝﾄﾞﾎﾞﾀﾝ

                        GET_CONTROL2(c, o_CTRL, i_TabIDX, i_COUNT)                    Case "CheckBox" '//ﾁｪｯｸﾎﾞｯｸｽ

                        GET_CONTROL2(c, o_CTRL, i_TabIDX, i_COUNT)                    Case "OptionButton" '//ｵﾌﾟｼｮﾝﾎﾞﾀﾝ

                        GET_CONTROL2(c, o_CTRL, i_TabIDX, i_COUNT)                    Case "ListView" '//ﾘｽﾄﾋﾞｭｰ

                        GET_CONTROL2(c, o_CTRL, i_TabIDX, i_COUNT)                    Case "MSFlexGrid" '//MSFlexGrid
                        '
                        GET_CONTROL2(c, o_CTRL, i_TabIDX, i_COUNT)                    Case Else                End Select            Next        Next        If (i_COUNT = 0) Then            Exit Function        End If

        '//移動可能コントロールが存在する場合は移動可能コントロールを設定する
        For i = 1 To i_COUNT - 1 'sort処理 (単純交換法)
            For j = i + 1 To i_COUNT                If (i_TabIDX(i) > i_TabIDX(j)) Then                    i_wkidx = i_TabIDX(j)                    i_wkobj = o_CTRL(j)                    i_TabIDX(j) = i_TabIDX(i)                    o_CTRL(j) = o_CTRL(i)                    i_TabIDX(i) = i_wkidx                    o_CTRL(i) = i_wkobj                End If            Next j        Next i

        '//移動したいコントロール数を設定
        gvint_MaxEnterCtrl = i_COUNT        ReDim gvobj_EnterCtrl(gvint_MaxEnterCtrl)        For i = 1 To i_COUNT            gvobj_EnterCtrl(i) = o_CTRL(i)        Next i        SetFocusCtrl2 = True        Exit Function    End Function
    'add


    '//*****************************************************************************************
    '//*
    '//* <メソッド>
    '//*    EnterNext
    '//*
    '//* <戻り値>
    '//*              True    :成功
    '//*              False   :失敗
    '//*
    '//* <引  数>     項目名              I/O    内容
    '//*              pmf_BackKey         I      フォーカスバック（既定値 = False:バックしない）
    '//*
    '//* <説  明>
    '//*    改行キーが入力された時に、次コントロールへフォーカスを移動させる
    '//*****************************************************************************************
    'change start 20190930 kuwa
    '   Function EnterNext(Optional ByVal pmf_BackKey As Boolean = False) As Boolean

    '	Dim i_SETIDX As Short
    '	Dim i_NOWIDX As Short
    '	Dim i As Short

    '       EnterNext = False

    '	'//移動するカーソルの位置を求める
    '	i_NOWIDX = 0
    '	For i = 1 To gvint_MaxEnterCtrl
    '           'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
    '           If Not IsNothing(gvobj_EnterCtrl(i)) Then
    '               'change start test 20190930 kuwa
    '               'If (gvobj_EnterCtrl(i) Is VB6.GetActiveControl()) Then
    '               If (gvobj_EnterCtrl(i) Is VB6.GetActiveControl()) Then
    '                   'change test end 20190930 kuwa
    '                   i_NOWIDX = i
    '                   Exit For
    '               End If
    '           End If
    '       Next i

    '       '//カーソルの位置が見つからない場合
    '       If i_NOWIDX = 0 Then
    '		Exit Function
    '	End If

    '	'//カーソルの位置が見つかった場合
    '	For i = 1 To gvint_MaxEnterCtrl
    '		'//バックキーの使用判定
    '		If pmf_BackKey Then
    '			i_SETIDX = i_NOWIDX - 1
    '			If i_SETIDX = 0 Then
    '				i_SETIDX = gvint_MaxEnterCtrl
    '			End If
    '		Else
    '			i_SETIDX = Int(i_NOWIDX Mod gvint_MaxEnterCtrl) + 1
    '		End If

    '		'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
    '		If IsNothing(gvobj_EnterCtrl(i_SETIDX)) Then
    '			i_NOWIDX = i_SETIDX
    '		Else
    '			'UPGRADE_WARNING: オブジェクト gvobj_EnterCtrl(i_SETIDX).Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			'UPGRADE_WARNING: オブジェクト gvobj_EnterCtrl(i_SETIDX).Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '			If gvobj_EnterCtrl(i_SETIDX).Enabled = True And gvobj_EnterCtrl(i_SETIDX).Visible = True Then
    '				Exit For
    '			End If
    '		End If
    '	Next i

    '	'//カーソルを次のコントロールへ移動&&
    '	On Error Resume Next
    '	'UPGRADE_WARNING: オブジェクト gvobj_EnterCtrl().SetFocus の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '	gvobj_EnterCtrl(i_SETIDX).SetFocus()
    '	On Error GoTo 0

    '	EnterNext = True

    'End Function

    Function EnterNext(Optional ByVal pmf_BackKey As Boolean = False, Optional ByVal prmName As String = "") As Boolean        Dim i_SETIDX As Short        Dim i_NOWIDX As Short        Dim i As Short        EnterNext = False

        '//移動するカーソルの位置を求める
        i_NOWIDX = 0        For i = 1 To gvint_MaxEnterCtrl
            'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            If Not IsNothing(gvobj_EnterCtrl(i)) Then

                'If (gvobj_EnterCtrl(i) Is VB6.GetActiveControl()) Then
                If DirectCast(gvobj_EnterCtrl(i), System.Windows.Forms.Control).Name = prmName Then                    i_NOWIDX = i                    Exit For                End If            End If        Next i

        '//カーソルの位置が見つからない場合
        If i_NOWIDX = 0 Then            Exit Function        End If

        '//カーソルの位置が見つかった場合
        For i = 1 To gvint_MaxEnterCtrl
            '//バックキーの使用判定
            If pmf_BackKey Then                i_SETIDX = i_NOWIDX - 1                If i_SETIDX = 0 Then                    i_SETIDX = gvint_MaxEnterCtrl                End If            Else                i_SETIDX = Int(i_NOWIDX Mod gvint_MaxEnterCtrl) + 1            End If

            'UPGRADE_WARNING: IsEmpty は、IsNothing にアップグレードされ、新しい動作が指定されました。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
            If IsNothing(gvobj_EnterCtrl(i_SETIDX)) Then                i_NOWIDX = i_SETIDX            Else
                'UPGRADE_WARNING: オブジェクト gvobj_EnterCtrl(i_SETIDX).Visible の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                'UPGRADE_WARNING: オブジェクト gvobj_EnterCtrl(i_SETIDX).Enabled の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
                If gvobj_EnterCtrl(i_SETIDX).Enabled = True And gvobj_EnterCtrl(i_SETIDX).Visible = True Then                    Exit For                End If            End If        Next i

        '//カーソルを次のコントロールへ移動&&
        On Error Resume Next
        'UPGRADE_WARNING: オブジェクト gvobj_EnterCtrl().SetFocus の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        gvobj_EnterCtrl(i_SETIDX).Focus()        On Error GoTo 0        EnterNext = True    End Function
    'change end 20190930 kuwa

    '//*****************************************************************************************
    '//*
    '//* <名  称>
    '//*    GetKeyDown
    '//*
    '//* <戻り値>
    '//*              ｷｰNO
    '//*
    '//* <引  数>     項目名              I/O      内容
    '//*              KeyCode            I       キーコード
    '//*
    '//* <説  明>
    '//*    キーダウン処理
    '//*****************************************************************************************
    Function GetKeyDown(ByRef KeyCode As Short) As Short
		
		Dim Int_PFKEY As Short
		
		GetKeyDown = 0
		
		'UPGRADE_WARNING: TypeName に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
		If TypeName(VB6.GetActiveControl()) = "CommandButton" And KeyCode = System.Windows.Forms.Keys.Space Then
			KeyCode = 0
			Exit Function
		End If
		
		Select Case KeyCode
			
			Case System.Windows.Forms.Keys.Return
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F1
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F2
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F3
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F4
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F5
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F6
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F7
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F8
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F9
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F10
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F11
				Int_PFKEY = KeyCode
			Case System.Windows.Forms.Keys.F12
				Int_PFKEY = KeyCode
		End Select
		
		GetKeyDown = Int_PFKEY
		
	End Function
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    SetSelCursor
	'//*
	'//* <戻り値>
	'//*              ｷｰNO
	'//*
	'//* <引  数>     項目名              I/O      内容
	'//*              Ctl                  I       対象コントロール
	'//*
	'//* <説  明>
	'//*    カーソル反転処理
	'//*****************************************************************************************
	Public Sub SetSelCursor(ByRef Ctl As System.Windows.Forms.Control)
		
		On Error GoTo ErrorTrap
		
        '2019/04/11 CHG START
        'With Ctl
        '    'UPGRADE_WARNING: TypeOf に新しい動作が指定されています。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"' をクリックしてください。
        '    If TypeOf Ctl Is System.Windows.Forms.TextBox Then
        '        'UPGRADE_WARNING: オブジェクト Ctl.SelStart の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SelStart = 0
        '        'UPGRADE_WARNING: オブジェクト Ctl.SelLength の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
        '        .SelLength = Len(.Text)
        '    End If
        'End With
         If TypeOf Ctl Is System.Windows.Forms.TextBox Then
            With DirectCast(Ctl, TextBox)
                .SelectionStart = 0
                .SelectionLength = Len(.Text)
            End With
        End If
        '2019/04/11 CHG E N D

        On Error GoTo 0
        Exit Sub

ErrorTrap:
        Err.Clear()
        On Error GoTo 0
        Exit Sub
		
	End Sub
End Class