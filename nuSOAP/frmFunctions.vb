Public Class frmFunctions
    Private nm As nuSOAP_Method

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
                nm.params = Split(strItems, "*")

                Dim i As Integer = ComboBoxEdit3.Properties.Items.Add(TextEdit2.Text)
                Dim doSelectID As Boolean = False
                Select Case LCase(TextEdit2.Text)
                    Case "id"
                        doSelectID = True
                    Case "unique"
                        doSelectID = True
                    Case "clientid"
                        doSelectID = True
                    Case "customerid"
                        doSelectID = True
                    Case "uniqueid"
                        doSelectID = True
                    Case "customer_id"
                        doSelectID = True
                    Case "client_id"
                        doSelectID = True
                    Case "recordid"
                        doSelectID = True
                    Case "record_id"
                        doSelectID = True
                End Select
                If doSelectID Then
                    If ComboBoxEdit3.SelectedIndex < 0 Then
                        ComboBoxEdit3.SelectedIndex = i
                    End If
                End If
                MakeSQL()
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
        nm.sql = ""
        If CheckBox2.Checked Then
            nm.sql = FastColoredTextBox1.Text
            nm.authlevel = NumericUpDown2.Value
        End If
        MakeFunction(nm)
        Me.Dispose()
    End Sub

    Private Sub frmFunctions_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmFunctions_Load(sender As Object, e As EventArgs) Handles Me.Load
        nm = New nuSOAP_Method
        nm.db = True
        nm.wsdl = True

        Me.Icon = alpha.Icon

        ComboBoxEdit1.Properties.Items.Clear()
        ComboBoxEdit1.Properties.Items.Add("int")
        ComboBoxEdit1.Properties.Items.Add("string")
        ComboBoxEdit1.Properties.Items.Add("boolean")
        ComboBoxEdit1.Properties.Items.Add("long")
        ComboBoxEdit1.Properties.Items.Add("double")
        ComboBoxEdit1.Properties.Items.Add("date")
        ComboBoxEdit1.Properties.Items.Add("dateTime")


        ComboBoxEdit2.Properties.Items.Clear()
        ComboBoxEdit2.Properties.Items.Add("int")
        ComboBoxEdit2.Properties.Items.Add("string")
        ComboBoxEdit2.Properties.Items.Add("boolean")
        ComboBoxEdit2.Properties.Items.Add("long")
        ComboBoxEdit2.Properties.Items.Add("double")
        ComboBoxEdit2.Properties.Items.Add("date")
        ComboBoxEdit2.Properties.Items.Add("dateTime")

        For Each itm As nuSOAP_Type In nuSOAP_Types
            ComboBoxEdit1.Properties.Items.Add(itm.name)
            ComboBoxEdit2.Properties.Items.Add(itm.name)
            If itm.hasarray Then
                ComboBoxEdit1.Properties.Items.Add(itm.name & "s")
                ComboBoxEdit2.Properties.Items.Add(itm.name & "s")
            End If
        Next
    End Sub

    Private Sub ComboBoxEdit2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit2.SelectedIndexChanged
        nm.returns = ComboBoxEdit2.Text
        MakeSQL()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If Not IsNothing(nm) Then nm.db = CheckBox2.Checked
        SQLEnable()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Not IsNothing(nm) Then nm.wsdl = CheckBox1.Checked
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit1.EditValueChanged
        If Not IsNothing(nm) Then nm.name = TextEdit1.Text
    End Sub

    Private Sub TextEdit3_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit3.EditValueChanged
        If Not IsNothing(nm) Then nm.description = TextEdit3.Text
    End Sub

    Private Sub RadioSQL_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles RadRadioButton1.ToggleStateChanged, RadRadioButton2.ToggleStateChanged, RadRadioButton3.ToggleStateChanged
        SQLEnable()
        MakeSQL()
    End Sub

    Private Sub MakeSQL()
        Dim sql As String = "$sql = '"
        If RadRadioButton2.IsChecked Or RadRadioButton3.IsChecked Then
            If RadRadioButton2.IsChecked Then
                sql = sql & "DELETE"
            ElseIf RadRadioButton3.IsChecked Then
                Select ComboBoxEdit2.Text
                    Case "int"
                        sql = sql & "SELECT *"
                    Case "string"
                        sql = sql & "SELECT *"
                    Case "boolean"
                        sql = sql & "SELECT *"
                    Case "long"
                        sql = sql & "SELECT *"
                    Case "double"
                        sql = sql & "SELECT *"
                    Case "date"
                        sql = sql & "SELECT *"
                    Case "dateTime"
                        sql = sql & "SELECT *"
                    Case Else
                        If ComboBoxEdit2.Text <> "" Then
                            Dim f As nuSOAP_Type
                            f = GetTypeByName(ComboBoxEdit2.Text)
                            If Not IsNothing(f) Then
                                Dim tmpParam As String()
                                Dim tmpParams As String = ""
                                For Each s As String In f.params
                                    If s <> "" Then
                                        tmpParam = Split(s, "|")
                                        If tmpParams <> "" Then tmpParams = tmpParams & ", "
                                        tmpParams = tmpParams & "`" & LCase(tmpParam(0)) & "` `" & tmpParam(0) & "`"
                                    End If
                                Next
                                sql = sql & "SELECT " & tmpParams
                            Else
                                sql = sql & "SELECT *"
                            End If
                        Else
                            sql = sql & "SELECT *"
                        End If
                End Select
            End If
            sql = sql & " FROM `' . DB_PREFIX . '" & TextEdit4.Text & "` WHERE `' . DB_PREFIX . '" & TextEdit4.Text & "`.`" & ComboBoxEdit3.Text & "` = :" & ComboBoxEdit3.Text
            If RadCheckBox1.Checked Then
                sql = sql & " LIMIT " & NumericUpDown1.Text
            End If
            sql = sql & "';"
        ElseIf RadRadioButton1.IsChecked Then
            ' BUILD INSERT COMMAND
            Dim params As String = ""
            Dim values As String = ""
            For Each lvw As ListViewItem In ListView1.Items
                If params <> "" Then params = params & ", "
                If values <> "" Then values = values & ", "
                params = params & "`" & lvw.Text & "`"
                values = values & ":" & lvw.Text
            Next
            sql = sql & "INSERT INTO `' . DB_PREFIX . '" & TextEdit4.Text & "` ( " & params & ") VALUES( " & values & " )';"
        ElseIf RadRadioButton4.IsChecked Then
            ' BUILD UPDATE COMMAND
            Dim params As String = ""
            For Each lvw As ListViewItem In ListView1.Items
                If params <> "" Then params = params & ", "
                If lvw.Text <> ComboBoxEdit3.Text Then
                    params = params & "`" & lvw.Text & "` = :" & lvw.Text
                End If
            Next
            sql = sql & "UPDATE `' . DB_PREFIX . '" & TextEdit4.Text & "` SET " & params & " WHERE `" & ComboBoxEdit3.Text & "` = :" & ComboBoxEdit3.Text
            If RadCheckBox1.Checked Then
                sql = sql & " LIMIT " & NumericUpDown1.Text
            End If
            sql = sql & "';"
        End If
        FastColoredTextBox1.Text = sql
    End Sub

    Private Sub SQLEnable()
        RadRadioButton1.Enabled = CheckBox2.Checked
        RadRadioButton2.Enabled = CheckBox2.Checked
        RadRadioButton3.Enabled = CheckBox2.Checked
        RadRadioButton4.Enabled = CheckBox2.Checked
        FastColoredTextBox1.Enabled = CheckBox2.Checked
        TextEdit4.Enabled = CheckBox2.Checked
        ComboBoxEdit3.Enabled = CheckBox2.Checked
        If CheckBox2.Checked = False Then
            RadCheckBox1.Enabled = False
            RadCheckBox2.Enabled = False
            NumericUpDown1.Enabled = False
        Else
            If RadRadioButton1.IsChecked Then
                RadCheckBox2.Enabled = True
                RadCheckBox1.Enabled = False
                NumericUpDown1.Enabled = False
            Else
                RadCheckBox2.Enabled = False
                RadCheckBox1.Enabled = True
                NumericUpDown1.Enabled = True
            End If
        End If
    End Sub

    Private Sub TextEdit4_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit4.EditValueChanged
        MakeSQL()
    End Sub

    Private Sub ComboBoxEdit3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEdit3.SelectedIndexChanged
        MakeSQL()
    End Sub

    Private Sub RadCheckBox2_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles RadCheckBox2.ToggleStateChanged
        MakeSQL()
    End Sub

    Private Sub RadCheckBox1_ToggleStateChanged(sender As Object, args As Telerik.WinControls.UI.StateChangedEventArgs) Handles RadCheckBox1.ToggleStateChanged
        MakeSQL()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        MakeSQL()
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If ListView1.SelectedItems.Count > 0 Then
                If MsgBox("Are you sure you want to remove the selected items?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    For Each l As ListViewItem In ListView1.SelectedItems
                        ListView1.Items.Remove(l)
                    Next
                    MakeSQL()
                End If
            End If
        End If
    End Sub

End Class