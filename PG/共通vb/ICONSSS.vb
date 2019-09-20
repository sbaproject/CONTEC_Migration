Option Strict Off
Option Explicit On
Friend Class ICN_ICON
	Inherits System.Windows.Forms.Form
	
	Private Sub ICN_ICON_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
#Disable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
		Top = VB6.TwipsToPixelsY((VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) - VB6.PixelsToTwipsY(Height)) / 2)
#Enable Warning BC40000 ' Type or member is obsolete
#Enable Warning BC40000 ' Type or member is obsolete
#Enable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
#Disable Warning BC40000 ' Type or member is obsolete
		Left = VB6.TwipsToPixelsX((VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) - VB6.PixelsToTwipsX(Width)) / 2)
#Enable Warning BC40000 ' Type or member is obsolete
#Enable Warning BC40000 ' Type or member is obsolete
#Enable Warning BC40000 ' Type or member is obsolete
		Show()
		System.Windows.Forms.Application.DoEvents()
	End Sub
End Class