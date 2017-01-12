Public Class frmQueryBuilder
    Private mdb As MySQL

    Private m As nuSOAP_Method

    Private Sub frmQueryBuilder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdb = New MySQL
        mdb.Connection.Server = My.Settings.DB_HOST
        mdb.Connection.Username = My.Settings.DB_USER
        mdb.Connection.Password = My.Settings.DB_PASS
        mdb.Connection.Database = My.Settings.DB_NAME
        mdb.Connect()

        Dim l As List(Of String) = mdb.ListTables

        For Each s As String In l
            RadListControl1.Items.Add(s)
        Next

        Me.Text = Me.Text & " - " & alpha.ListView2.SelectedItems(0).Text
        m = FindMethod(alpha.ListView2.SelectedItems(0).Text)
        FastColoredTextBox4.Text = m.sql
    End Sub

    Private Sub RadListControl1_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles RadListControl1.SelectedIndexChanged
        If RadListControl1.SelectedIndex > 0 Then
            Dim f As List(Of MySQL.FieldStructure) = mdb.ListFields(RadListControl1.SelectedItems(0).Text)
            Dim l As ListViewItem
            ListView1.Items.Clear()
            For Each i As MySQL.FieldStructure In f
                l = ListView1.Items.Add(i.Field)
                l.SubItems.Add(i.Type)
            Next
        End If

    End Sub

    Private Sub RadButton3_Click(sender As Object, e As EventArgs) Handles RadButton3.Click
        Dim ds As DataTable = mdb.Query("SELECT * FROM `" & RadListControl1.SelectedItems(0).Text & "`")
        GridControl1.DataSource = Nothing
        GridControl1.DataSource = ds
    End Sub
End Class
