Imports System.Data
Imports MySql.Data
Imports MySql.Data.MySqlClient


Public Class MySQL
    Public Class ConnectionStructure
        Public Property Server As String = "127.0.0.1"
        Public Property Username As String = "root"
        Public Property Password As String = ""
        Public Property Database As String = ""
        Public Property Port As Integer = 3306
    End Class

    Public Enum FieldKeyEnum
        None
        Primary
    End Enum

    Public Class FieldStructure
        Public Property Field As String
        Public Property Type As String
        Public Property Null As String
        Public Property Key As String
        Public Property [Default] As String
        Public Property Extra As String
    End Class

    Private Property cn As MySqlClient.MySqlConnection

    Public Property Connection As ConnectionStructure = New ConnectionStructure

    Public Property LastInsertID As Integer = -1

    Public Helpers As New SQLHelpers

    Public Function Connect(Optional ByVal c As ConnectionStructure = Nothing) As Boolean
        Try
            If Not IsNothing(cn) Then
                Disconnect()
            End If
            If Not IsNothing(c) Then
                Connection = c
            End If
            cn = New MySqlClient.MySqlConnection("server=" & Connection.Server & ";user id=" & Connection.Username & ";password=" & Connection.Password & ";database=" & Connection.Database)
            cn.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly, "SQL Error")
            Return False
        End Try
    End Function

    Public Function Disconnect() As Boolean
        Try
            If Not IsNothing(cn) Then
                cn.Close()
                cn = Nothing
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Optimize(ByVal table As String) As Boolean
        Return Exec("OPTIMIZE TABLE `" & table & "`")
    End Function

    Public Function ListTables() As List(Of String)
        Dim r As DataTable = Query("SHOW TABLES")
        Dim result As New List(Of String)

        If Not IsNothing(r) Then
            For Each row As DataRow In r.Rows
                Helpers.Row = row
                result.Add(Helpers.Varchar("Tables_in_" & My.Settings.DB_NAME))
            Next
        End If

        Return result
    End Function

    Public Function ListFields(ByVal table As String) As List(Of FieldStructure)
        Dim r As DataTable = Query("DESCRIBE `" & table & "`")
        Dim f As FieldStructure

        Dim result As New List(Of FieldStructure)

        If Not IsNothing(r) Then
            For Each row As DataRow In r.Rows
                f = New FieldStructure
                Helpers.Row = row
                f.Default = Helpers.Varchar("Default")
                f.Extra = Helpers.Varchar("Extra")
                f.Field = Helpers.Varchar("Field")
                f.Key = Helpers.Varchar("Key")
                f.Null = Helpers.Varchar("Null")
                f.Type = Helpers.Varchar("Type")
                result.Add(f)
            Next
        End If

        Return result
    End Function


    Public Function Count(ByVal table As String) As Integer

        Try
            Using cmd As New MySqlClient.MySqlCommand("SELECT COUNT(*) AS c FROM " & table)
                Dim obj As Object = cmd.ExecuteScalar()
                If (Not IsNothing(obj)) And (obj <> DBNull.Value) Then
                    Return Convert.ToInt32(obj)
                Else
                    Return 0
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly, "SQL Error")
            Return -1
        End Try
    End Function

    Public Function LastInsertIDX(ByVal table As String) As Long
        Try
            If IsNothing(cn) Then
                Connect()
            End If

            Using cmd As New MySqlClient.MySqlCommand("SELECT last_insert_rowid() AS id FROM " & table, cn)
                '                cmd.ExecuteNonQuery()
                Dim obj As System.Object = cmd.ExecuteScalar()
                If Not IsNothing(obj) Then
                    Return DirectCast(obj, Long)
                End If
                Return -1
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly, "SQL Error")
            Return -1
        End Try
    End Function

    Public Function Exec(ByVal sql As String) As Boolean
        Try
            If IsNothing(cn) Then
                Connect()
            End If

            LastInsertID = -1

            If sql.Substring(0, 6) = "INSERT" Then
                sql = sql & "; SELECT last_insert_rowid();"
                Using cmd As New MySqlClient.MySqlCommand(sql, cn)
                    LastInsertID = cmd.ExecuteScalar()
                End Using
            Else
                Using cmd As New MySqlClient.MySqlCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                End Using
            End If

            Return True
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & vbCrLf & sql, vbOKOnly, "SQL Error")
            Return False
        End Try
    End Function

    Public Function Query(ByVal sql As String) As DataTable
        Dim dt As DataTable = Nothing
        Dim ds As New DataSet
        Try
            If IsNothing(cn) Then
                Connect()
            End If

            Using cmd As New MySqlClient.MySqlCommand(sql, cn)
                Using da As New MySqlClient.MySqlDataAdapter(cmd)
                    da.Fill(ds)
                    dt = ds.Tables(0)
                End Using
            End Using
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & vbCrLf & sql, vbOKOnly, "SQL Error")
            Return Nothing
        End Try
    End Function

    Protected Overrides Sub Finalize()
        Disconnect()
        MyBase.Finalize()
    End Sub

    Public Class SQLHelpers

        Public Property Row As DataRow

        Public Function Bool(ByVal field As String, Optional ByVal defaultValue As Boolean = False) As Boolean
            Try
                If Not IsNothing(Row.Item(field)) Then
                    Return Convert.ToBoolean(Row.Item(field))
                Else
                    Return defaultValue
                End If
            Catch ex As Exception
                Return defaultValue
            End Try
        End Function

        Public Function Varchar(ByVal field As String, Optional ByVal defaultValue As String = "") As String
            Try
                If Not IsNothing(Row.Item(field)) Then
                    If Row.Item(field).GetType.Name = "Byte[]" Then
                        Return System.Text.Encoding.Default.GetString(Row.Item(field))
                    Else
                        Return Convert.ToString(Row.Item(field))
                    End If
                Else
                    Return defaultValue
                End If
            Catch ex As Exception
                Return defaultValue
            End Try
        End Function

        Public Function Int(ByVal field As String, Optional ByVal defaultValue As Integer = -1) As Integer
            Try
                If Not IsNothing(Row.Item(field)) Then
                    Return Convert.ToInt32(Row.Item(field))
                Else
                    Return defaultValue
                End If
            Catch ex As Exception
                Return defaultValue
            End Try
        End Function

    End Class

End Class
