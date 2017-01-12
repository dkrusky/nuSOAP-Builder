Imports System.Runtime.InteropServices

Public NotInheritable Class SkinnedAboutBox
    <DllImportAttribute("user32.dll")> _
    Public Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    <DllImportAttribute("user32.dll")> _
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub _MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Label1.MouseDown, Label2.MouseDown, Label3.MouseDown, Label4.MouseDown, Label6.MouseDown
        Const WM_NCLBUTTONDOWN As Integer = &HA1
        Const HT_CAPTION As Integer = &H2

        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0)
        End If

    End Sub

    Private Sub _Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.AllowTransparency = True
        Me.TransparencyKey = Me.BackColor

        ' Set the title of the form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        Me.Label4.Text = My.Application.Info.ProductName & " " & My.Application.Info.Copyright & " " & My.Application.Info.CompanyName
        Label3.Text = String.Format("{0}", My.Application.Info.Version.ToString)
        Label6.Text = My.Application.Info.Description
    End Sub

    Private Sub HyperLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start(LinkLabel1.Text)
    End Sub

    Private Sub X_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Dispose()
    End Sub
End Class
