Option Strict Off
Option Explicit On
Friend Class DLGLST02_ACE
	Inherits System.Windows.Forms.Form
	
	Private Sub CMD_SELECT_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CMD_SELECT.Click
		Dim Index As Short = CMD_SELECT.GetIndex(eventSender)
		'UPGRADE_WARNING: オブジェクト SSS_RTNWIN の既定プロパティを解決できませんでした。 詳細については、'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"' をクリックしてください。
		SSS_RTNWIN = Index
		Me.Close()
	End Sub
	
	Private Sub DLGLST02_ACE_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Text = FR_SSSMAIN.Text
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		
		'' === 20061120 === INSERT S - ACE)Nagasawa 権限の読み方の変更
		'    If Inp_Inf.InpPRTAUTH = gc_strPRTAUTH_OK Then
		'        '印刷権限あり
		'        CMD_SELECT(0).Enabled = True
		'    ElseIf Inp_Inf.InpPRTAUTH = gc_strPRTAUTH_NG Then
		'        '印刷権限なし
		'        CMD_SELECT(0).Enabled = False
		'    End If
		'' === 20061120 === INSERT E -
		
	End Sub
End Class