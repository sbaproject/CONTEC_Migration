Option Strict Off
Option Explicit On

Friend Class HKKET143F
	Inherits System.Windows.Forms.Form

    '2019/04/11 ADD START
    Private ClsMessage As New ClsMessage
    '2019/04/11 ADD E N D

    '2019/04/16 ADD START
    'ListViewItemSorterに指定するフィールド
    Public lvSorter143F As ListViewItemComparer
    '2019/04/16 ADD E N D

    '// 2007/02/24 ↓ ADD STR
    'UPGRADE_WARNING: Form イベント HKKET143F.Activate には新しい動作が含まれます。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"' をクリックしてください。
	Private Sub HKKET143F_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated
		Call SetFormInitOrg(Me, 1)
	End Sub
	'// 2007/02/24 ↑ ADD STR
	
	'//*****************************************************************************************
	'//*
	'//* <名  称>
	'//*    Form
	'//*
	'//* <戻り値>
	'//*
	'//* <引  数>     項目名              I/O      内容
	'//*
	'//* <説  明>
	'//*    Form EVENT
	'//*****************************************************************************************
	Private Sub HKKET143F_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		gvstrDisplayID = "E03"

        '2019/04/16 ADD START
        'ListViewItemComparerの作成と設定
        lvSorter143F = New ListViewItemComparer
        'listViewItemSorter.ColumnModes = _
        '    New ListViewItemComparer.ComparerMode() _
        '    {ListViewItemComparer.ComparerMode.String, _
        '    ListViewItemComparer.ComparerMode.Integer}
        lvSorter143F.Order = SortOrder.None
        'ListViewItemSorterを指定する
        lvwMEISAI.ListViewItemSorter = lvSorter143F
        '2019/04/16 ADD E N D

		'// 2007/02/24 ↓ ADD STR
		'UPGRADE_WARNING: オブジェクト gvvntTop の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Me.Top = VB6.TwipsToPixelsY(gvvntTop)
		'UPGRADE_WARNING: オブジェクト gvvntLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		Me.Left = VB6.TwipsToPixelsX(gvvntLeft)
        '// 2007/02/24 ↑ ADD STR

        '//画面初期化
        If Not HKKET143M.Set_Initialize() Then
            '//終了処理
            Me.Close()
        End If

        '2019/04/24 ADD START
        Call SetBar(Me)
        '2019/04/24 ADD E N D

    End Sub
	
	'// 2007/02/24 ↓ ADD STR
	Private Sub HKKET143F_Paint(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
		'UPGRADE_WARNING: オブジェクト gvvntLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'UPGRADE_WARNING: オブジェクト gvvntTop の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
	End Sub
	'// 2007/02/24 ↑ ADD STR
	
	Private Sub HKKET143F_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '2019/04/15 DEL START
        'Dim Cancel As Boolean = eventArgs.Cancel
        '2019/04/15 DEL E N D
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
		
		'// 2007/02/24 ↓ ADD STR
		'UPGRADE_WARNING: オブジェクト gvvntTop の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
		'UPGRADE_WARNING: オブジェクト gvvntLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'// 2007/02/24 ↑ ADD STR
		
		'//終了メッセージ
		If ClsMessage.MsgLibrary(gvcstJOB_Titl, "2" & gvcstJOB_ID & "_" & "301") = MsgBoxResult.Yes Then
			'//画面表示情報更新
			'UPGRADE_WARNING: オブジェクト HKKET143F.lvwMEISAI の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
            '2019/04/15　仮
            'Call SavLvFormat("E03", (Me.lvwMEISAI))
            '2019/04/15　仮
        Else
            '2019/04/15 CHG START
            'Cancel = True
            eventArgs.Cancel = True
            '2019/04/15 CHG E N D
            Exit Sub
		End If
        '//V1.10 2006/09/20  ADD START  RISE)
        HKKET142F.Visible = True
		'//V1.10 2006/09/20  ADD E N D  RISE)
        '2019/04/15 CHG START
        'eventArgs.Cancel = Cancel
        eventArgs.Cancel = False
        '2019/04/15 CHG E N D
    End Sub
	Private Sub cmdRETURN_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdRETURN.Click
		'// 2007/02/24 ↓ ADD STR
		'UPGRADE_WARNING: オブジェクト gvvntTop の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntTop = VB6.PixelsToTwipsY(Me.Top)
		'UPGRADE_WARNING: オブジェクト gvvntLeft の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		gvvntLeft = VB6.PixelsToTwipsX(Me.Left)
		'// 2007/02/24 ↑ ADD STR
		'//終了処理
		Me.Close()
		
	End Sub
    '2019/04/11 CHG START 
    'Private Sub lvwMEISAI_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)
    '    Dim MSComctlLib As Object
    '    Dim wIndex As Integer
    '    'UPGRADE_WARNING: オブジェクト ColumnHeader.Index の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    wIndex = ColumnHeader.Index - 1
    '    'UPGRADE_WARNING: オブジェクト Me.lvwMEISAI の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
    '    Call SortLv((Me.lvwMEISAI), wIndex)

    'End Sub
    Private Sub lvwMEISAI_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvwMEISAI.ColumnClick
        ''クリックされた列を設定
        'listViewItemSorter.Column = e.Column
        ''並び替える
        'lvwMEISAI.Sort()
        Call SortLv(lvwMEISAI, e.Column, lvSorter143F, False)
    End Sub
    '2019/04/11 CHG E N D 
End Class