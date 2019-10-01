Option Strict Off
Option Explicit On
Friend Class DLGMSG01_ACE
	Inherits System.Windows.Forms.Form
	
	Private Sub CMD_OK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CMD_OK.Click
		Me.Close()
	End Sub
	
	Private Sub DLGMSG01_ACE_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		
		Text = FR_SSSMAIN.Text
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
		
		HD_DSPNO.Text = gv_strDLGMSG01_BNGNM & " : " & gv_strDLGMSG01_NO
		
	End Sub
End Class