Public Class alpha

    Private Sub TypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TypeToolStripMenuItem.Click
        frmTypes.ShowDialog()
    End Sub

    Private Sub alpha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nuSOAP_Methods = New List(Of nuSOAP_Method)
        nuSOAP_Types = New List(Of nuSOAP_Type)

        DocumentTabStrip1.ShowItemCloseButton = False
        DocumentWindow1.DocumentButtons = Telerik.WinControls.UI.Docking.DocumentStripButtons.None
        DocumentWindow2.DocumentButtons = Telerik.WinControls.UI.Docking.DocumentStripButtons.None
        DocumentWindow3.DocumentButtons = Telerik.WinControls.UI.Docking.DocumentStripButtons.None

        OpenFileDialog1.InitialDirectory = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "nuSOAP Projects")
        If Not System.IO.Directory.Exists(OpenFileDialog1.InitialDirectory) Then
            System.IO.Directory.CreateDirectory(OpenFileDialog1.InitialDirectory)
        End If

        GenerateSQLTable()
        LoadProject(ProjectPath(My.Settings.lastproject), True)
    End Sub

    Private Sub MethodToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MethodToolStripMenuItem.Click
        frmFunctions.ShowDialog()
    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        If ListView1.SelectedItems.Count > 0 Then
            RadPropertyGrid1.SelectedObject = FindType(ListView1.SelectedItems(0).Text)
        End If
    End Sub

    Private Sub ListView2_Click(sender As Object, e As EventArgs) Handles ListView2.Click
        If ListView2.SelectedItems.Count > 0 Then
            RadPropertyGrid1.SelectedObject = FindMethod(ListView2.SelectedItems(0).Text)
        End If
    End Sub

    Private Sub NewProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewProjectToolStripMenuItem.Click
        Dim response As String = InputBox("Type a name for the project", "New Project")
        response = Trim(response)
        If response <> "" Then
            LoadProject(ProjectPath(Replace(response, ".db", "")), True)
        End If
    End Sub

    Private Sub LoadExistingProjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadExistingProjectToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadProject(ProjectPath(Replace(OpenFileDialog1.FileName, ".db", "")), True)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        db.Vacuum()
        db.Disconnect()
        Application.Exit()
    End Sub

    Public Function ProjectPath(ByVal name As String) As String
        If Not System.IO.Directory.Exists(System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "nuSOAP Projects")) Then
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "nuSOAP Projects"))
        End If
        Return System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "nuSOAP Projects", name)
    End Function

    Private Sub ExportToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem1.Click
        If FolderBrowserDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ExportFiles(FolderBrowserDialog1.SelectedPath)
        End If
    End Sub

    Public Sub ExportFiles(ByVal path As String)
        Try
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(path, "lib"))
        Catch ex As Exception

        End Try

        SaveFile(System.IO.Path.Combine(path, "Structures.vb"), FastColoredTextBox4.Text, True)
        SaveFile(System.IO.Path.Combine(path, "ThreadQueue.vb"), FastColoredTextBox5.Text, False)
        SaveFile(System.IO.Path.Combine(path, "soap_types.php"), "<?php" & vbCrLf & FastColoredTextBox1.Text, False)
        SaveFile(System.IO.Path.Combine(path, "soap_methods.php"), "<?php" & vbCrLf & FastColoredTextBox2.Text, False)
        SaveFile(System.IO.Path.Combine(path, "soap_functions.php"), "<?php" & vbCrLf & FastColoredTextBox3.Text, True)
        SaveFile(System.IO.Path.Combine(path, "index.php"), My.Resources.index, False)
        SaveFile(System.IO.Path.Combine(path, "config.php"), GeneralModule.ConfigPHP(), True)
        SaveFile(System.IO.Path.Combine(path, "api_table.sql"), vbCrLf & FastColoredTextBox6.Text, True)
        SaveFile(System.IO.Path.Combine(path, "lib", "encryption.php"), My.Resources.encryption, False)
        SaveFile(System.IO.Path.Combine(path, "lib", "database.php"), My.Resources.database, False)
        SaveFile(System.IO.Path.Combine(path, "lib", "push.php"), My.Resources.push, False)
        SaveFile(System.IO.Path.Combine(path, "lib", "soap.php"), My.Resources.soap, False)

        With RadDesktopAlert1
            .CaptionText = "Files Exported"
            .ContentText = "All files have been exported successfuly."
            .SoundToPlay = Media.SystemSounds.Asterisk
            .Show()
        End With

    End Sub

    Public Sub SaveFile(ByVal filename As String, ByVal data As String, Optional ByVal overwritePrompt As Boolean = False)
        Dim bData As Byte()
        bData = System.Text.Encoding.Default.GetBytes(data)
        SaveFile(filename, bData, overwritePrompt)
    End Sub

    Public Sub SaveFile(ByVal filename As String, ByVal data() As Byte, Optional ByVal overwritePrompt As Boolean = False)
        Dim sw As System.IO.FileStream

        Dim doOverwrite As Boolean = False

        If overwritePrompt = False Then
            doOverwrite = True
        Else
            If System.IO.File.Exists(filename) Then
                If MsgBox("Would you like to overwrite the following file with new data ?" & vbCrLf & vbCrLf & filename, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "File Exists") = MsgBoxResult.Yes Then
                    doOverwrite = True
                End If
            Else
                doOverwrite = True
            End If
        End If
        If doOverwrite = True Then
            Try
                sw = System.IO.File.Open(filename, IO.FileMode.Create, IO.FileAccess.Write)
                sw.Write(data, 0, data.Count)
                sw.Close()
            Catch ex As Exception
                MsgBox("Error writing to : " & filename & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "IO Error")
            End Try
        End If
    End Sub


    Private Sub NewToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem1.Click
        Dim response As String = InputBox("Type a name for the project", "New Project")
        response = Trim(response)
        If response <> "" Then
            LoadProject(response, True)
        End If
    End Sub

    Private Sub ConfigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigToolStripMenuItem.Click
        frmConfig.ShowDialog()
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        ExportFiles(System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "nuSOAP Projects", SOAPName))
    End Sub

    Private Sub RadDock1_TransactionCommitted(sender As Object, e As Telerik.WinControls.UI.Docking.RadDockTransactionEventArgs) Handles RadDock1.TransactionCommitted
        For Each f As Telerik.WinControls.UI.Docking.DockWindow In e.Transaction.AssociatedWindows
            If Not IsNothing(f.FloatingParent) Then
                f.FloatingParent.ControlBox = False
                f.FloatingParent.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
                f.FloatingParent.MinimizeBox = True
                f.FloatingParent.MaximizeBox = True
            End If
        Next
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        SkinnedAboutBox.ShowDialog(Me)
    End Sub

    Private Sub ListView2_DoubleClick(sender As Object, e As EventArgs) Handles ListView2.DoubleClick
        If ListView2.SelectedItems.Count > 0 Then
            Dim f As New frmQueryBuilder
            f.ShowDialog(Me)
        End If
    End Sub

End Class
