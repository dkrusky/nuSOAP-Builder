Imports System.Data
Imports System.Data.SQLite

Public Class SQL
    Private Property cn As SQLite.SQLiteConnection

    Private Property DBFileName As String = "default"

    Public Property IsNewDB As Boolean

    Public Property LastInsertID As Integer = -1

    Public Helpers As New SQLHelpers

    Public Function Connect(Optional ByVal filename As String = "default") As Boolean
        Try
            If Not IsNothing(cn) Then
                Disconnect()
            End If
            DBFileName = filename
            If Not System.IO.File.Exists(filename & ".db") Then
                IsNewDB = True
                SQLite.SQLiteConnection.CreateFile(filename & ".db")
            End If
            cn = New SQLite.SQLiteConnection("Data Source=" & filename & ".db")
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

    Public Function Vacuum() As Boolean
        Return Exec("VACUUM")
    End Function

    Public Function Count(ByVal table As String) As Integer

        Try
            Using cmd As New SQLite.SQLiteCommand("SELECT COUNT(*) AS c FROM " & table)
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
                Connect(DBFileName)
            End If

            Using cmd As New SQLite.SQLiteCommand("SELECT last_insert_rowid() AS id FROM " & table, cn)
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
                Connect(DBFileName)
            End If

            LastInsertID = -1

            If sql.Substring(0, 6) = "INSERT" Then
                sql = sql & "; SELECT last_insert_rowid();"
                Using cmd As New SQLite.SQLiteCommand(sql, cn)
                    LastInsertID = cmd.ExecuteScalar()
                End Using
            Else
                Using cmd As New SQLite.SQLiteCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                End Using
            End If

            IsNewDB = False
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
                Connect(DBFileName)
            End If

            Using cmd As New SQLite.SQLiteCommand(sql, cn)
                Using da As New SQLite.SQLiteDataAdapter(cmd)
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