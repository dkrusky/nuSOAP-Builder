Public Class frmTypes

    Private Property nt As nuSOAP_Type

    Private Sub TextEdit2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextEdit2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub ComboBoxEdit1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBoxEdit1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextEdit2.Text <> "" And ComboBoxEdit1.SelectedIndex >= 0 Then
            Dim ItemExists As Boolean = False
            Dim strItems As String = ""
            For Each l As ListViewItem In ListView1.Items
                If l.Text = TextEdit2.Text Then ItemExists = True
                If strItems <> "" Then
                    strItems = strItems & "*"
                End If
                strItems = strItems & l.Text & "|" & l.SubItems(1).Text
            Next

            If ItemExists = False Then
                Dim lvw As ListViewItem
                lvw = ListView1.Items.Add(TextEdit2.Text)
                lvw.SubItems.Add(ComboBoxEdit1.Text)
                If strItems <> "" Then
                    strItems = strItems & "*"
                End If
                strItems = strItems & TextEdit2.Text & "|" & ComboBoxEdit1.Text
                nt.params = Split(strItems, "*")
                'nt.params(nt.params.Count) = TextEdit1.Text & "|" & ComboBoxEdit1.Text

                TextEdit2.Text = ""
                TextEdit2.Focus()
            Else
                TextEdit2.SelectAll()
                TextEdit2.Focus()
                MsgBox("You can not have duplicates", MsgBoxStyle.OkOnly + MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Object exists")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextEdit1.Text <> "" And ListView1.Items.Count > 0 Then
            ' Generate and add code to Types tab on main form
            MakeType(nt)
            Me.Dispose()
        Else
            MsgBox("You must have a name and at least one parameter", MsgBoxStyle.OkOnly + MsgBoxStyle.ApplicationModal + MsgBoxStyle.Information, "Required information missing")
        End If
    End Sub

    Private Sub frmTypes_Load(sender As Object, e As EventArgs) Handles Me.Load
        nt = New nuSOAP_Type
        nt.hasarray = True

        Me.Icon = alpha.Icon

        ComboBoxEdit1.Properties.Items.Clear()
        ComboBoxEdit1.Properties.Items.Add("int")
        ComboBoxEdit1.Properties.Items.Add("string")
        ComboBoxEdit1.Properties.Items.Add("boolean")
        ComboBoxEdit1.Properties.Items.Add("long")
        ComboBoxEdit1.Properties.Items.Add("double")
        ComboBoxEdit1.Properties.Items.Add("date")
        ComboBoxEdit1.Properties.Items.Add("dateTime")

        For Each itm As nuSOAP_Type In nuSOAP_Types
            ComboBoxEdit1.Properties.Items.Add(itm.name)
            If itm.hasarray Then
                ComboBoxEdit1.Properties.Items.Add(itm.name & "s")
            End If
        Next

    End Sub

    Private Sub frmTypes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit1.EditValueChanged
        If Not IsNothing(nt) Then nt.name = TextEdit1.Text
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Not IsNothing(nt) Then nt.hasarray = CheckBox1.Checked
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If ListView1.SelectedItems.Count > 0 Then
                If MsgBox("Are you sure you want to remove the selected items?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    For Each l As ListViewItem In ListView1.SelectedItems
                        ListView1.Items.Remove(l)
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class