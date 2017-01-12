Imports System.Text.RegularExpressions
Imports System

Module GeneralModule

    Public db As SQL = New SQL

    Public SOAPName As String = "default"

    Public Class nuSOAP_Method
        Public Property id As Integer
        Public Property name As String
        Public Property params As String()
        Public Property returns As String
        Public Property wsdl As Boolean
        Public Property description As String
        Public Property db As Boolean
        Public Property sql As String
        Public Property authlevel As Integer
    End Class

    Public Class nuSOAP_Type
        Public Property id As Integer
        Public Property name As String
        Public Property params As String()
        Public Property hasarray As Boolean
    End Class

    Public Property nuSOAP_Types As List(Of nuSOAP_Type)
    Public Property nuSOAP_Methods As List(Of nuSOAP_Method)

    Public Class nuSOAP_TypeDefinition
        Public Property xsl As String
        Public Property typeinfo As nuSOAP_Type
        Public Property type As String
        Public Property fullstring As String
    End Class

    Public Function FindType(ByVal name As String) As nuSOAP_Type
        Dim r As nuSOAP_Type = Nothing
        For Each n As nuSOAP_Type In nuSOAP_Types
            If n.name = name Then
                r = n
                Exit For
            End If
        Next
        Return r
    End Function

    Public Function FindMethod(ByVal name As String) As nuSOAP_Method
        Dim r As nuSOAP_Method = Nothing
        For Each n As nuSOAP_Method In nuSOAP_Methods
            If n.name = name Then
                r = n
                Exit For
            End If
        Next
        Return r
    End Function

    Public Sub AddType(ByVal id As Integer, ByVal name As String, ByVal params As String, ByVal hasarray As Boolean)
        Dim t As New nuSOAP_Type
        t.id = id
        t.name = name

        t.params = Split(params, "*")
        t.hasarray = hasarray

        nuSOAP_Types.Add(t)
    End Sub

    Public Function AddType(ByVal name As String, ByVal params As String, ByVal hasarray As Boolean) As Integer
        Dim t As New nuSOAP_Type
        t.name = name
        t.params = Split(params, "*")
        t.hasarray = hasarray

        nuSOAP_Types.Add(t)

        Return 1
    End Function

    Public Function GetTypeByName(ByVal name As String) As nuSOAP_Type
        For Each t In nuSOAP_Types
            If t.name = name Then
                Return t
            End If
        Next

        Dim n As String = name.Remove(name.Length - 1)
        For Each t In nuSOAP_Types
            If t.name = n Then
                Return t
            End If
        Next
        Return Nothing
    End Function

    Public Function GetTypeFromString(ByVal type As String) As nuSOAP_TypeDefinition
        Dim t As New nuSOAP_TypeDefinition

        Select Case type
            Case "int"
                t.xsl = "xsd"
            Case "string"
                t.xsl = "xsd"
            Case "boolean"
                t.xsl = "xsd"
            Case "long"
                t.xsl = "xsd"
            Case "double"
                t.xsl = "xsd"
            Case "date"
                t.xsl = "xsd"
            Case "dateTime"
                t.xsl = "xsd"
            Case Else
                t.xsl = "tns"
        End Select

        t.type = type
        t.fullstring = t.xsl & ":" & t.type

        If t.xsl = "tns" Then
            For Each n As nuSOAP_Type In nuSOAP_Types
                If n.name = type Then
                    t.typeinfo = n
                    Exit For
                End If
            Next
        End If

        Return t
    End Function



    Public Sub LoadProject(ByVal ProjectName As String, Optional ByVal Opening As Boolean = False)
        Dim connected As Boolean = False
        If db.Connect(ProjectName) Then
            connected = True
            ' Create tables if it's a new database
            If db.IsNewDB Then
                db.Exec("CREATE TABLE ""methods"" ( ""id""  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, ""name""  TEXT NOT NULL, ""params""  BLOB, ""returns""  TEXT NOT NULL, ""wsdl""  INTEGER NOT NULL DEFAULT 1, ""db""  INTEGER NOT NULL DEFAULT 1, ""description""  TEXT, ""sql""  TEXT, ""authlevel""  INTEGER );")
                db.Exec("CREATE TABLE ""types"" ( ""id""  INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, ""name""  TEXT NOT NULL, ""params""  BLOB, ""hasarray""  INTEGER NOT NULL DEFAULT 0 );")
            End If
        End If

        ' Reset internal data
        nuSOAP_Methods.Clear()
        nuSOAP_Types.Clear()

        alpha.ListView1.Items.Clear()
        alpha.ListView2.Items.Clear()

        alpha.RadPropertyGrid1.SelectedObject = Nothing

        ' PHP
        alpha.FastColoredTextBox1.Text = "" ' Types
        alpha.FastColoredTextBox2.Text = "" ' Methods
        alpha.FastColoredTextBox3.Text = "" ' Functions

        ' VB.NET
        alpha.FastColoredTextBox4.Text = "" ' Structures
        alpha.FastColoredTextBox5.Text = "" ' Threads

        If connected = True Then
            alpha.NewToolStripMenuItem.Enabled = True
            alpha.ProjectToolStripMenuItem.Enabled = True

            SOAPName = Regex.Replace(System.IO.Path.GetFileNameWithoutExtension(ProjectName), "[^a-zA-Z]", "")
            alpha.Text = "nuSOAP Builder - " & SOAPName

            My.Settings.lastproject = SOAPName
            My.Settings.Save()



            Dim dt As DataTable
            Dim m As nuSOAP_Method
            Dim f As nuSOAP_Type

            dt = db.Query("SELECT id, name, params, returns, wsdl, db, description, sql, authlevel FROM methods ORDER BY id ASC;")
            If Not IsNothing(dt) Then
                For Each row As DataRow In dt.Rows
                    m = New nuSOAP_Method
                    db.Helpers.Row = row
                    m.db = db.Helpers.Bool("db")
                    m.wsdl = db.Helpers.Bool("wsdl")
                    m.id = db.Helpers.Int("id")
                    m.name = db.Helpers.Varchar("name")
                    m.returns = db.Helpers.Varchar("returns")
                    m.params = Split(db.Helpers.Varchar("params"), "*")
                    m.description = db.Helpers.Varchar("description")
                    m.sql = db.Helpers.Varchar("sql")
                    m.authlevel = db.Helpers.Int("authlevel")

                    MakeFunction(m, Opening)
                Next
            End If

            dt = db.Query("SELECT id, name, params, hasarray FROM types ORDER BY id ASC;")
            If Not IsNothing(dt) Then
                For Each row As DataRow In dt.Rows
                    f = New nuSOAP_Type
                    db.Helpers.Row = row
                    f.id = db.Helpers.Int("id")
                    f.name = db.Helpers.Varchar("name")
                    f.params = Split(db.Helpers.Varchar("params"), "*")
                    f.hasarray = db.Helpers.Bool("hasarray")
                    MakeType(f, Opening)
                Next
            End If
        Else
            alpha.NewToolStripMenuItem.Enabled = False
            alpha.ProjectToolStripMenuItem.Enabled = False
        End If
    End Sub

    Public Sub GenerateSQLTable()
        Dim tc As String = ""
        tc = tc & "CREATE TABLE `" & My.Settings.DB_PREFIX & "api` (" & vbCrLf
        tc = tc & "  `id` int(11) NOT NULL AUTO_INCREMENT," & vbCrLf
        tc = tc & "  `API_PUBLIC_KEY` varchar(64) DEFAULT NULL," & vbCrLf
        tc = tc & "  `API_PRIVATE_KEY` varchar(64) DEFAULT NULL," & vbCrLf
        tc = tc & "  `AUTHLEVEL` int(11) DEFAULT '0'," & vbCrLf
        tc = tc & "  `enabled` int(11) DEFAULT '0'," & vbCrLf
        tc = tc & "  PRIMARY KEY (`id`)" & vbCrLf
        tc = tc & ") ENGINE=MyISAM DEFAULT CHARSET=latin1;" & vbCrLf
        alpha.FastColoredTextBox6.Text = tc
    End Sub

    Public Sub MakeType(ByRef type As nuSOAP_Type, Optional ByVal Opening As Boolean = False)
        Dim strType As String = ""
        Dim docBlock As String = ""
        Dim typeSplit As String()

        For Each lx As String In type.params
            If lx <> "" Then
                If strType <> "" Then
                    strType = strType & ", "
                End If
                If docBlock <> "" Then
                    docBlock = docBlock & vbCrLf
                End If

                typeSplit = Split(lx, "|")


                docBlock = docBlock & " * @param" & vbTab & GetTypeFromString(typeSplit(1)).type & vbTab & "$" & typeSplit(0)
                strType = strType & "'" & typeSplit(0) & "' => array('name'=>'" & typeSplit(0) & "','type'=>'" & GetTypeFromString(typeSplit(1)).fullstring & "')"
            End If
        Next
        strType = "   $server->wsdl->addComplexType( '" & type.name & "', 'complexType', 'struct', 'all', '', array( " & strType & " ) );"
        If docBlock = "" Then docBlock = " *"
        If type.hasarray Then
            strType = strType & vbCrLf & "   $server->wsdl->addComplexType( '" & type.name & "s', 'complexType', 'array', '', 'SOAP-ENC:Array', array(), array(array('ref'=>'SOAP-ENC:arrayType','wsdl:arrayType'=>'tns:" & type.name & "[]')), 'tns:" & type.name & "');"
            docBlock = "/**" & vbCrLf & " * " & type.name & " type structure" & vbCrLf & " * - Has Array" & vbCrLf & " *" & vbCrLf & docBlock & vbCrLf & " */"
        Else
            docBlock = "/**" & vbCrLf & " * " & type.name & " type structure" & vbCrLf & " *" & vbCrLf & docBlock & vbCrLf & " */"
        End If

        If alpha.FastColoredTextBox1.Text <> "" Then
            alpha.FastColoredTextBox1.AppendText(vbCrLf & vbCrLf & vbCrLf)
        End If
        alpha.FastColoredTextBox1.AppendText(docBlock & vbCrLf & strType)

        Dim lvw As ListViewItem = alpha.ListView1.Items.Add(type.name)
        lvw.SubItems.Add(type.hasarray)

        If Opening = False Then
            db.Exec("INSERT INTO types VALUES(null, '" & type.name & "','" & Join(type.params, "*") & "'," & Bool2Int(type.hasarray) & " )")
            type.id = db.LastInsertID
        End If

        nuSOAP_Types.Add(type)
    End Sub

    Public Sub MakeFunction(ByRef method As nuSOAP_Method, Optional ByVal Opening As Boolean = False)
        Dim strType As String = ""
        Dim docBlock As String = ""
        Dim typeSplit As String()
        Dim phpParams As String = ""
        Dim phpSQLbind As String = ""

        Dim returnMethod As String = ""
        Dim returnFunction As String = ""

        ' *************************
        '   UPDATE PHP CODE
        ' *************************
        If method.authlevel > 0 Then
            docBlock = docBlock & " * @param" & vbTab & "string" & vbTab & "$API_PUBLIC_KEY" & vbCrLf
            docBlock = docBlock & " * @param" & vbTab & "string" & vbTab & "$API_VERIFY"
            strType = strType & "'API_PUBLIC_KEY' => '" & GetTypeFromString("string").fullstring & "',"
            strType = strType & "'API_VERIFY' => '" & GetTypeFromString("string").fullstring & "'"
            phpParams = phpParams & "$API_PUBLIC_KEY, $API_VERIFY"
        End If

        If Not IsNothing(method.params) Then
            For Each lvw As String In method.params
                If lvw <> "" Then
                    If strType <> "" Then
                        strType = strType & ", "
                    End If
                    If docBlock <> "" Then
                        docBlock = docBlock & vbCrLf
                    End If

                    typeSplit = Split(lvw, "|")

                    ' Parameters for PHP function
                    If phpParams <> "" Then
                        phpParams = phpParams & ", "
                    End If
                    phpParams = phpParams & "$" & typeSplit(0)

                    ' Bind code for PDO
                    If phpSQLbind <> "" Then
                        phpSQLbind = phpSQLbind & vbCrLf
                    End If
                    If method.authlevel > 0 Then
                        phpSQLbind = phpSQLbind & Indent(4) & "$db->bind( "":" & typeSplit(0) & """, $" & typeSplit(0) & " );"
                    Else
                        phpSQLbind = phpSQLbind & Indent(3) & "$db->bind( "":" & typeSplit(0) & """, $" & typeSplit(0) & " );"
                    End If
                    ' docBlock comment formatting
                    docBlock = docBlock & " * @param" & vbTab & GetTypeFromString(typeSplit(1)).type & vbTab & "$" & typeSplit(0)

                    ' Param array for method registration
                    strType = strType & "'" & typeSplit(0) & "' => '" & GetTypeFromString(typeSplit(1)).fullstring & "'"
                End If
            Next
        End If

        Dim phpReturnDefault As String = "Array()"
        Select Case method.returns
            Case "int"
                phpReturnDefault = "-1"
            Case "string"
                phpReturnDefault = "''"
            Case "boolean"
                phpReturnDefault = "False"
            Case "long"
                phpReturnDefault = "-1"
            Case "double"
                phpReturnDefault = "-1"
            Case "date"
                phpReturnDefault = "0"
            Case "dateTime"
                phpReturnDefault = "0"
            Case Else
                phpReturnDefault = "Array()"
        End Select

        Dim inBase As Integer = 0

        If method.authlevel > 0 Then inBase = 1
        If method.wsdl Then
            returnMethod = "/**" & vbCrLf
            returnMethod = returnMethod & " * " & method.name & " method structure" & vbCrLf
            returnMethod = returnMethod & IIf(method.db, " * - Has Database" & vbCrLf, "")
            returnMethod = returnMethod & " *" & vbCrLf
            returnMethod = returnMethod & " * " & vbTab & method.description & vbCrLf
            returnMethod = returnMethod & " *" & vbCrLf & docBlock & vbCrLf & " */" & vbCrLf
            returnMethod = returnMethod & "   $server->register('" & method.name & "', array( " & strType & " ), array( 'return' => '" & GetTypeFromString(method.returns).fullstring & "'), $SERVICE_NAMESPACE, false, 'rpc', false, '" & Replace(method.description, "'", "\'") & "' );"
        End If
        returnFunction = "/**" & vbCrLf
        returnFunction = returnFunction & " * @function " & method.name & vbCrLf
        returnFunction = returnFunction & IIf(method.db, " * - Has Database" & vbCrLf, "")
        returnFunction = returnFunction & " *" & vbCrLf
        returnFunction = returnFunction & " * " & vbTab & method.description & vbCrLf
        returnFunction = returnFunction & " *" & vbCrLf & docBlock & vbCrLf
        returnFunction = returnFunction & " *" & vbCrLf
        returnFunction = returnFunction & " * @returns " & vbTab & method.returns & vbTab & "default[ " & phpReturnDefault & " ]" & vbCrLf
        returnFunction = returnFunction & " */" & vbCrLf
        returnFunction = returnFunction & vbTab & "function " & method.name & "(" & phpParams & ") {" & vbCrLf
        returnFunction = returnFunction & Indent(2) & "$result = " & phpReturnDefault & ";" & vbCrLf
        If method.db Then
            returnFunction = returnFunction & Indent(2) & IIf(method.sql <> "", method.sql, "$sql = '';") & vbCrLf & vbCrLf
        Else
            returnFunction = returnFunction & vbCrLf
        End If
        returnFunction = returnFunction & Indent(2) & "try {" & vbCrLf
        If method.authlevel > 0 Then
            returnFunction = returnFunction & Indent(3) & "If(API_VERIFY_AUTHLEVEL($API_PUBLIC_KEY, $API_VERIFY, " & method.authlevel & ")) {" & vbCrLf
        End If
        If method.db Then
            returnFunction = returnFunction & Indent(inBase + 3) & "$db = new Database();" & vbCrLf
            returnFunction = returnFunction & Indent(inBase + 3) & "$db->query($sql);" & vbCrLf
            returnFunction = returnFunction & phpSQLbind & vbCrLf
            If IsTypeAnArray(method.returns) Then
                returnFunction = returnFunction & Indent(inBase + 3) & "if($result = $db->resultset()) {" & vbCrLf
                returnFunction = returnFunction & Indent(inBase + 3) & "    // TODO : Manipulate Results if Needed" & vbCrLf
                returnFunction = returnFunction & Indent(inBase + 3) & "} else {" & vbCrLf
                returnFunction = returnFunction & Indent(inBase + 3) & "    $result = " & phpReturnDefault & ";" & vbCrLf
                returnFunction = returnFunction & Indent(inBase + 3) & "}" & vbCrLf
            Else
                returnFunction = returnFunction & Indent(inBase + 3) & "if($result = $db->single()) {" & vbCrLf
                returnFunction = returnFunction & Indent(inBase + 3) & "//if($exec = $db->execute()) {" & vbCrLf & vbCrLf
                returnFunction = returnFunction & Indent(inBase + 3) & "    // TODO : Manipulate Results if Needed" & vbCrLf
                returnFunction = returnFunction & Indent(inBase + 3) & "} else {" & vbCrLf
                returnFunction = returnFunction & Indent(inBase + 3) & "    $result = " & phpReturnDefault & vbCrLf & vbCrLf
                returnFunction = returnFunction & Indent(inBase + 3) & "}" & vbCrLf
            End If
            returnFunction = returnFunction & Indent(inBase + 3) & "// TODO: WRITE CODE HERE" & vbCrLf & vbCrLf
            returnFunction = returnFunction & Indent(inBase + 3) & "$db = null;" & vbCrLf
        End If

            If method.authlevel > 0 Then
                returnFunction = returnFunction & Indent(3) & "}" & vbCrLf
            End If
            returnFunction = returnFunction & Indent(2) & "} catch (Exception $e) {" & vbCrLf
            returnFunction = returnFunction & Indent(3) & "$result = " & phpReturnDefault & ";" & vbCrLf
            returnFunction = returnFunction & Indent(2) & "}" & vbCrLf
            returnFunction = returnFunction & Indent(2) & "return $result; // " & method.returns & vbTab & "default[ " & phpReturnDefault & " ]" & vbCrLf
            returnFunction = returnFunction & Indent(1) & "}"

            If method.wsdl Then
                If alpha.FastColoredTextBox2.Text <> "" Then
                    alpha.FastColoredTextBox2.AppendText(vbCrLf & vbCrLf & vbCrLf)
                End If
                alpha.FastColoredTextBox2.AppendText(returnMethod)
            End If

            If alpha.FastColoredTextBox3.Text <> "" Then
                alpha.FastColoredTextBox3.AppendText(vbCrLf & vbCrLf & vbCrLf)
            End If
            alpha.FastColoredTextBox3.AppendText(returnFunction)

            alpha.ListView2.Items.Add(method.name)

            ' *************************
            '   INSERT INTO DATABASE
            ' *************************
            If Opening = False Then
                Dim sqlcm As String = ""
                If method.authlevel > 0 Then
                    sqlcm = "INSERT INTO methods VALUES(null, '" & method.name & "','" & Join(method.params, "*") & "','" & method.returns & "'," & Bool2Int(method.wsdl) & "," & Bool2Int(method.db) & ",'" & method.description & "','" & Replace(method.sql, "'", "''") & "', " & method.authlevel & " )"
                Else
                    sqlcm = "INSERT INTO methods VALUES(null, '" & method.name & "','" & Join(method.params, "*") & "','" & method.returns & "'," & Bool2Int(method.wsdl) & "," & Bool2Int(method.db) & ",'" & method.description & "','" & Replace(method.sql, "'", "''") & "', null )"
                End If
                db.Exec(sqlcm)
                method.id = db.LastInsertID
            End If


            ' *************************
            '   UPDATE .NET CODE
            ' *************************
            Dim dotNetThreadParams As String = ""
            Dim dotNetThreadCase As String = ""
            Dim dotNetThreadFunction As String = ""

            nuSOAP_Methods.Add(method)

            Dim tc As String = ""
            Dim tmpParam As String()
            Dim tmpParams As String = ""

            tc = "Imports System" & vbCrLf
            tc = tc & "Imports System.Threading" & vbCrLf
            tc = tc & "Imports System.Text" & vbCrLf
            tc = tc & "Imports System.IO" & vbCrLf
            tc = tc & "Imports System.Security.Cryptography" & vbCrLf
            tc = tc & "Public Class ThreadQueue" & vbCrLf
            tc = tc & "    Public Property API_PUBLIC_KEY As String = """"" & vbCrLf
            tc = tc & "    Public Property API_PRIVATE_KEY As String = """"" & vbCrLf
            tc = tc & "    Public Property API_WSDL_URL As String = """"" & vbCrLf
        tc = tc & "    Public Property API_PING_URL As String = ""4.2.2.2""" & vbCrLf
            tc = tc & "    Public ReadOnly Property IsOnline As Boolean" & vbCrLf
            tc = tc & "        Get" & vbCrLf
            tc = tc & "            Dim _IsOnline As Boolean = False" & vbCrLf
        tc = tc & "            If My.Computer.Network.IsAvailable Then" & vbCrLf
            tc = tc & "                If My.Computer.Network.Ping(API_PING_URL) Then" & vbCrLf
            tc = tc & "                    _IsOnline = True" & vbCrLf
            tc = tc & "                End If" & vbCrLf
            tc = tc & "            End If" & vbCrLf
            tc = tc & "            Return _IsOnline" & vbCrLf
            tc = tc & "        End Get" & vbCrLf
            tc = tc & "    End Property" & vbCrLf
            tc = tc & "#Region ""Thread Function Names""" & vbCrLf
            tc = tc & Indent(1) & "Public Enum FunctionNames" & vbCrLf
            For Each m As nuSOAP_Method In nuSOAP_Methods
                tc = tc & Indent(2) & m.name & vbCrLf
            Next
            tc = tc & Indent(1) & "End Enum" & vbCrLf
            tc = tc & "#End Region" & vbCrLf & vbCrLf
            tc = tc & "#Region ""Thread Management""" & vbCrLf
            tc = tc & "    Private ThreadContext As SynchronizationContext = SynchronizationContext.Current" & vbCrLf
            tc = tc & "    Public Event ThreadComplete(ByVal sender As Object, ByVal e As ThreadResult)" & vbCrLf
            tc = tc & "    Private _Workers As Integer" & vbCrLf
            tc = tc & "    Public Class ThreadResult" & vbCrLf
            tc = tc & "        Inherits EventArgs" & vbCrLf
            tc = tc & "        Public Property ThreadID As Guid" & vbCrLf
            tc = tc & "        Public Property Worker As Integer" & vbCrLf
            tc = tc & "        Public Property Argument As Object" & vbCrLf
            tc = tc & "        Public Property Result As Object" & vbCrLf
            tc = tc & "        Public Property [Function] As FunctionNames" & vbCrLf
            tc = tc & "    End Class" & vbCrLf
            tc = tc & "    Public Class ThreadParams" & vbCrLf
            tc = tc & "        Inherits EventArgs" & vbCrLf
            tc = tc & "        Public Property Argument As Object" & vbCrLf
            tc = tc & "        Public Property [Function] As FunctionNames" & vbCrLf
            tc = tc & "    End Class" & vbCrLf
            tc = tc & "    Private Property MaxThreads As Integer" & vbCrLf
            tc = tc & "        Get" & vbCrLf
            tc = tc & "            Dim workers As Integer, completion As Integer" & vbCrLf
            tc = tc & "            ThreadPool.GetMaxThreads(workers, completion)" & vbCrLf
            tc = tc & "            Return workers" & vbCrLf
            tc = tc & "        End Get" & vbCrLf
            tc = tc & "        Set(value As Integer)" & vbCrLf
            tc = tc & "            ThreadPool.SetMaxThreads(value, 1000)" & vbCrLf
            tc = tc & "        End Set" & vbCrLf
            tc = tc & "    End Property" & vbCrLf
            tc = tc & "    Private Property MinThreads As Integer" & vbCrLf
            tc = tc & "        Get" & vbCrLf
            tc = tc & "            Dim workers As Integer, completion As Integer" & vbCrLf
            tc = tc & "            ThreadPool.GetMinThreads(workers, completion)" & vbCrLf
            tc = tc & "            Return workers" & vbCrLf
            tc = tc & "        End Get" & vbCrLf
            tc = tc & "        Set(value As Integer)" & vbCrLf
            tc = tc & "            ThreadPool.SetMinThreads(value, 1000)" & vbCrLf
            tc = tc & "        End Set" & vbCrLf
            tc = tc & "    End Property" & vbCrLf
            tc = tc & "    Public ReadOnly Property Workers As Integer" & vbCrLf
            tc = tc & "        Get" & vbCrLf
            tc = tc & "            Return _Workers" & vbCrLf
            tc = tc & "        End Get" & vbCrLf
            tc = tc & "    End Property" & vbCrLf
            tc = tc & "    Public ReadOnly Property ThreadsAvailable As Integer" & vbCrLf
            tc = tc & "        Get" & vbCrLf
            tc = tc & "            Dim workers As Integer, completion As Integer" & vbCrLf
            tc = tc & "            ThreadPool.GetAvailableThreads(workers, completion)" & vbCrLf
            tc = tc & "            Return workers" & vbCrLf
            tc = tc & "        End Get" & vbCrLf
            tc = tc & "    End Property" & vbCrLf
            tc = tc & "    Protected Overridable Sub OnThreadCompleted(ByVal e As ThreadResult)" & vbCrLf
            tc = tc & "        _Workers = _Workers - 1" & vbCrLf
            tc = tc & "        RaiseEvent ThreadComplete(Me, e)" & vbCrLf
            tc = tc & "    End Sub" & vbCrLf
            tc = tc & "#End Region" & vbCrLf
            tc = tc & "#Region ""Starting Thread""" & vbCrLf
        tc = tc & "    Public Function StartThread(e As ThreadParams, Optional ByVal ThreadID As Guid = Nothing) As Guid" & vbCrLf
            tc = tc & "        Dim f As New ThreadQueue.ThreadResult" & vbCrLf
            tc = tc & "        Dim queued As Boolean = False" & vbCrLf
            tc = tc & "        With f" & vbCrLf
        tc = tc & "            If Not IsNothing(ThreadID) Then" & vbCrLf
        tc = tc & "                .ThreadID = ThreadID" & vbCrLf
        tc = tc & "            Else" & vbCrLf
        tc = tc & "                .ThreadID = Guid.NewGuid" & vbCrLf
        tc = tc & "            End If" & vbCrLf
        tc = tc & "            .Argument = e.Argument" & vbCrLf
            tc = tc & "            .Function = e.Function" & vbCrLf
            tc = tc & "        End With" & vbCrLf
            tc = tc & "        Select Case e.Function" & vbCrLf
            For Each m As nuSOAP_Method In nuSOAP_Methods
                tc = tc & Indent(3) & "Case FunctionNames." & m.name & vbCrLf
                tc = tc & Indent(4) & "queued = ThreadPool.QueueUserWorkItem(AddressOf Me." & m.name & ", DirectCast(f, ThreadResult))" & vbCrLf
            Next
            tc = tc & "            Case Else" & vbCrLf
            tc = tc & "                Return Nothing" & vbCrLf
            tc = tc & "        End Select" & vbCrLf
            tc = tc & "        If queued = True Then" & vbCrLf
            tc = tc & "            _Workers = _Workers + 1" & vbCrLf
            tc = tc & "            Return f.ThreadID" & vbCrLf
            tc = tc & "        Else" & vbCrLf
            tc = tc & "            Return Nothing" & vbCrLf
            tc = tc & "        End If" & vbCrLf
            tc = tc & "" & vbCrLf
            tc = tc & "    End Function" & vbCrLf
            tc = tc & "#End Region" & vbCrLf

            tc = tc & "#Region ""Custom Thread Functions""" & vbCrLf
            For Each m As nuSOAP_Method In nuSOAP_Methods
                tc = tc & "    Private Sub " & m.name & "(ByVal e As ThreadQueue.ThreadResult)" & vbCrLf
                tc = tc & "        If Me.ThreadContext IsNot Nothing Then" & vbCrLf
                tc = tc & "            e.Worker = System.Threading.Thread.CurrentThread.ManagedThreadId" & vbCrLf
                tc = tc & "            Dim result As Object" & vbCrLf
            tc = tc & "            Dim soap As SOAP." & SOAPName & " = New SOAP." & SOAPName & vbCrLf

            tc = tc & "            If API_WSDL_URL <> "" Then" & vbCrLf
            tc = tc & "                soap.Url = API_WSDL_URL" & vbCrLf
            tc = tc & "            Else" & vbCrLf
            tc = tc & "                soap.Url = My.Settings." & SOAPName & "_SOAP_" & SOAPName & vbCrLf
            tc = tc & "            End If" & vbCrLf
            tmpParams = ""
            If Not IsNothing(m.params) Then
                For Each p As String In m.params
                    If p <> "" Then
                        tmpParam = Split(p, "|")
                        If tmpParams <> "" Then tmpParams = tmpParams & ", "
                        tmpParams = tmpParams & "o." & tmpParam(0)
                    End If
                Next
            End If
            If tmpParams <> "" Then
                tc = tc & "            Dim o As SOAPArguments." & m.name & " = DirectCast(e.Argument, SOAPArguments." & m.name & ")" & vbCrLf
            End If
            tc = tc & "            Try" & vbCrLf
            tc = tc & "                If IsOnline Then" & vbCrLf
            If tmpParams <> "" Then
                tc = tc & "                    result = soap." & m.name & "(" & IIf(method.authlevel > 0, "API_PUBLIC_KEY, API_VERIFY, ", "") & tmpParams & ")" & vbCrLf
            Else
                tc = tc & "                    result = soap." & m.name & "(" & IIf(method.authlevel > 0, "API_PUBLIC_KEY, API_VERIFY", "") & ")" & vbCrLf
            End If
            tc = tc & "                Else" & vbCrLf
            tc = tc & "                    result = Nothing" & vbCrLf
            tc = tc & "                End If" & vbCrLf
            tc = tc & "            Catch ex As Exception" & vbCrLf
            tc = tc & "                result = Nothing" & vbCrLf
            tc = tc & "            Finally" & vbCrLf
            tc = tc & "                soap = Nothing" & vbCrLf
            tc = tc & "            End Try" & vbCrLf
            tc = tc & "            e.Result = result" & vbCrLf
            tc = tc & "            Me.ThreadContext.Post(AddressOf OnThreadCompleted, DirectCast(e, ThreadQueue.ThreadResult))" & vbCrLf
            tc = tc & "        Else" & vbCrLf
            tc = tc & "            Me.OnThreadCompleted(DirectCast(ThreadResult.Empty, ThreadQueue.ThreadResult))" & vbCrLf
            tc = tc & "        End If" & vbCrLf
            tc = tc & "    End Sub" & vbCrLf
        Next
            tc = tc & vbCrLf & "#End Region" & vbCrLf
            tc = tc & "    Public ReadOnly Property API_VERIFY As String" & vbCrLf
            tc = tc & "        Get" & vbCrLf
            tc = tc & "            Dim tdes As TripleDES = New TripleDES(API_PRIVATE_KEY)" & vbCrLf
            tc = tc & "            Dim hash As String = """"" & vbCrLf
            tc = tc & "			   Dim r as Random = new Random" & vbCrLf
            tc = tc & "			   Dim s As String = ""ABCDEFGHIJKLMNOPQRSTUWXYZ0123456789""" & vbCrLf
            tc = tc & "			   hash = s.Substring(r.Next(0, 35), 1) & s.Substring(r.Next(0, 35), 1) & s.Substring(r.Next(0, 35), 1) & "":valid:"" & s.Substring(r.Next(0, 35), 1) & s.Substring(r.Next(0, 35), 1) & s.Substring(r.Next(0, 35), 1)" & vbCrLf
            tc = tc & "            Return tdes.Encrypt(hash)" & vbCrLf
            tc = tc & "        End Get" & vbCrLf
            tc = tc & "    End Property" & vbCrLf
            tc = tc & "End Class" & vbCrLf
            tc = tc & "" & vbCrLf

            ' Encryption Class
            tc = tc & "Public Class TripleDES" & vbCrLf
            tc = tc & "    Private bPassword As Byte()" & vbCrLf
            tc = tc & "    Private sPassword As String" & vbCrLf
            tc = tc & "    Public Sub New(Optional ByVal Password As String = ""password"")" & vbCrLf
            tc = tc & "        Me.Password = Password" & vbCrLf
            tc = tc & "    End Sub" & vbCrLf
            tc = tc & "    Public ReadOnly Property PasswordHash As String" & vbCrLf
            tc = tc & "        Get" & vbCrLf
            tc = tc & "            Dim UTF8 As System.Text.UTF8Encoding = New System.Text.UTF8Encoding" & vbCrLf
            tc = tc & "            Return UTF8.GetString(bPassword)" & vbCrLf
            tc = tc & "        End Get" & vbCrLf
            tc = tc & "    End Property" & vbCrLf
            tc = tc & "    Public Property Password() As String" & vbCrLf
            tc = tc & "        Get" & vbCrLf
            tc = tc & "            Dim UTF8 As System.Text.UTF8Encoding = New System.Text.UTF8Encoding" & vbCrLf
            tc = tc & "            Return sPassword" & vbCrLf
            tc = tc & "        End Get" & vbCrLf
            tc = tc & "        Set(value As String)" & vbCrLf
            tc = tc & "            Dim UTF8 As System.Text.UTF8Encoding = New System.Text.UTF8Encoding" & vbCrLf
            tc = tc & "            Dim HashProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()" & vbCrLf
            tc = tc & "            bPassword = HashProvider.ComputeHash(UTF8.GetBytes(value))" & vbCrLf
            tc = tc & "            sPassword = value" & vbCrLf
            tc = tc & "        End Set" & vbCrLf
            tc = tc & "    End Property" & vbCrLf
            tc = tc & "#Region ""Encrypt""" & vbCrLf
            tc = tc & "    Public Function Encrypt(ByVal Message As String) As String" & vbCrLf
            tc = tc & "        Dim Results() As Byte" & vbCrLf
            tc = tc & "        Dim UTF8 As System.Text.UTF8Encoding = New System.Text.UTF8Encoding" & vbCrLf
            tc = tc & "        Using HashProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()" & vbCrLf
            tc = tc & "            Dim TDESKey() As Byte = bPassword" & vbCrLf
            tc = tc & "            Using TDESAlgorithm As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider() With {.Key = TDESKey, .Mode = CipherMode.ECB, .Padding = PaddingMode.PKCS7}" & vbCrLf
            tc = tc & "                Dim DataToEncrypt() As Byte = UTF8.GetBytes(Message)" & vbCrLf
            tc = tc & "                Try" & vbCrLf
            tc = tc & "                    Dim Encryptor As ICryptoTransform = TDESAlgorithm.CreateEncryptor" & vbCrLf
            tc = tc & "                    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length)" & vbCrLf
            tc = tc & "                Finally" & vbCrLf
            tc = tc & "                    TDESAlgorithm.Clear()" & vbCrLf
            tc = tc & "                    HashProvider.Clear()" & vbCrLf
            tc = tc & "                End Try" & vbCrLf
            tc = tc & "            End Using" & vbCrLf
            tc = tc & "        End Using" & vbCrLf
            tc = tc & "        Return Convert.ToBase64String(Results)" & vbCrLf
            tc = tc & "    End Function" & vbCrLf
            tc = tc & "    Private Function Encrypt(ByVal Message As String, ByVal Password() As Byte) As String" & vbCrLf
            tc = tc & "        Dim Results() As Byte" & vbCrLf
            tc = tc & "        Dim UTF8 As System.Text.UTF8Encoding = New System.Text.UTF8Encoding" & vbCrLf
            tc = tc & "        Using HashProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()" & vbCrLf
            tc = tc & "            Dim TDESKey() As Byte = HashProvider.ComputeHash(UTF8.GetBytes(UTF8.GetString(Password)))" & vbCrLf
            tc = tc & "            Using TDESAlgorithm As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider() With {.Key = TDESKey, .Mode = CipherMode.ECB, .Padding = PaddingMode.PKCS7}" & vbCrLf
            tc = tc & "                Dim DataToEncrypt() As Byte = UTF8.GetBytes(Message)" & vbCrLf
            tc = tc & "                Try" & vbCrLf
            tc = tc & "                    Dim Encryptor As ICryptoTransform = TDESAlgorithm.CreateEncryptor" & vbCrLf
            tc = tc & "                    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length)" & vbCrLf
            tc = tc & "                Finally" & vbCrLf
            tc = tc & "                    TDESAlgorithm.Clear()" & vbCrLf
            tc = tc & "                    HashProvider.Clear()" & vbCrLf
            tc = tc & "                End Try" & vbCrLf
            tc = tc & "            End Using" & vbCrLf
            tc = tc & "        End Using" & vbCrLf
            tc = tc & "        Return Convert.ToBase64String(Results)" & vbCrLf
            tc = tc & "    End Function" & vbCrLf
            tc = tc & "    Public Function Encrypt(ByVal Message As String, ByVal Password As String) As String" & vbCrLf
            tc = tc & "        Dim Results() As Byte" & vbCrLf
            tc = tc & "        Dim UTF8 As System.Text.UTF8Encoding = New System.Text.UTF8Encoding" & vbCrLf
            tc = tc & "        Using HashProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()" & vbCrLf
            tc = tc & "            Dim TDESKey() As Byte = HashProvider.ComputeHash(UTF8.GetBytes(Password))" & vbCrLf
            tc = tc & "            Using TDESAlgorithm As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider() With {.Key = TDESKey, .Mode = CipherMode.ECB, .Padding = PaddingMode.PKCS7}" & vbCrLf
            tc = tc & "                Dim DataToEncrypt() As Byte = UTF8.GetBytes(Message)" & vbCrLf
            tc = tc & "                Try" & vbCrLf
            tc = tc & "                    Dim Encryptor As ICryptoTransform = TDESAlgorithm.CreateEncryptor" & vbCrLf
            tc = tc & "                    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length)" & vbCrLf
            tc = tc & "                Finally" & vbCrLf
            tc = tc & "                    TDESAlgorithm.Clear()" & vbCrLf
            tc = tc & "                    HashProvider.Clear()" & vbCrLf
            tc = tc & "                End Try" & vbCrLf
            tc = tc & "            End Using" & vbCrLf
            tc = tc & "        End Using" & vbCrLf
            tc = tc & "        Return Convert.ToBase64String(Results)" & vbCrLf
            tc = tc & "    End Function" & vbCrLf
            tc = tc & "#End Region" & vbCrLf
            tc = tc & "#Region ""Decrypt""" & vbCrLf
            tc = tc & "    Public Function Decrypt(ByVal Message As String) As String" & vbCrLf
            tc = tc & "        Dim Results() As Byte" & vbCrLf
            tc = tc & "        Dim UTF8 As System.Text.UTF8Encoding = New System.Text.UTF8Encoding" & vbCrLf
            tc = tc & "        Using HashProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()" & vbCrLf
            tc = tc & "            Dim TDESKey() As Byte = Me.bPassword" & vbCrLf
            tc = tc & "            Using TDESAlgorithm As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider() With {.Key = TDESKey, .Mode = CipherMode.ECB, .Padding = PaddingMode.PKCS7}" & vbCrLf
            tc = tc & "                Dim DataToDecrypt() As Byte = Convert.FromBase64String(Message)" & vbCrLf
            tc = tc & "                Try" & vbCrLf
            tc = tc & "                    Dim Decryptor As ICryptoTransform = TDESAlgorithm.CreateDecryptor" & vbCrLf
            tc = tc & "                    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length)" & vbCrLf
            tc = tc & "                Finally" & vbCrLf
            tc = tc & "                    TDESAlgorithm.Clear()" & vbCrLf
            tc = tc & "                    HashProvider.Clear()" & vbCrLf
            tc = tc & "                End Try" & vbCrLf
            tc = tc & "            End Using" & vbCrLf
            tc = tc & "        End Using" & vbCrLf
            tc = tc & "        Return UTF8.GetString(Results)" & vbCrLf
            tc = tc & "    End Function" & vbCrLf
            tc = tc & "    Public Function Decrypt(ByVal Message As String, ByVal Password() As Byte) As String" & vbCrLf
            tc = tc & "        Dim Results() As Byte" & vbCrLf
            tc = tc & "        Dim UTF8 As System.Text.UTF8Encoding = New System.Text.UTF8Encoding" & vbCrLf
            tc = tc & "        Using HashProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()" & vbCrLf
            tc = tc & "            Dim TDESKey() As Byte = HashProvider.ComputeHash(UTF8.GetBytes(UTF8.GetString(Password)))" & vbCrLf
            tc = tc & "            Using TDESAlgorithm As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider() With {.Key = TDESKey, .Mode = CipherMode.ECB, .Padding = PaddingMode.PKCS7}" & vbCrLf
            tc = tc & "                Dim DataToDecrypt() As Byte = Convert.FromBase64String(Message)" & vbCrLf
            tc = tc & "                Try" & vbCrLf
            tc = tc & "                    Dim Decryptor As ICryptoTransform = TDESAlgorithm.CreateDecryptor" & vbCrLf
            tc = tc & "                    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length)" & vbCrLf
            tc = tc & "                Finally" & vbCrLf
            tc = tc & "                    TDESAlgorithm.Clear()" & vbCrLf
            tc = tc & "                    HashProvider.Clear()" & vbCrLf
            tc = tc & "                End Try" & vbCrLf
            tc = tc & "            End Using" & vbCrLf
            tc = tc & "        End Using" & vbCrLf
            tc = tc & "        Return UTF8.GetString(Results)" & vbCrLf
            tc = tc & "    End Function" & vbCrLf
            tc = tc & "    Public Function Decrypt(ByVal Message As String, ByVal Password As String) As String" & vbCrLf
            tc = tc & "        Dim Results() As Byte" & vbCrLf
            tc = tc & "        Dim UTF8 As System.Text.UTF8Encoding = New System.Text.UTF8Encoding" & vbCrLf
            tc = tc & "        Using HashProvider As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()" & vbCrLf
            tc = tc & "            Dim TDESKey() As Byte = HashProvider.ComputeHash(UTF8.GetBytes(Password))" & vbCrLf
            tc = tc & "            Using TDESAlgorithm As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider() With {.Key = TDESKey, .Mode = CipherMode.ECB, .Padding = PaddingMode.PKCS7}" & vbCrLf
            tc = tc & "                Dim DataToDecrypt() As Byte = Convert.FromBase64String(Message)" & vbCrLf
            tc = tc & "                Try" & vbCrLf
            tc = tc & "                    Dim Decryptor As ICryptoTransform = TDESAlgorithm.CreateDecryptor" & vbCrLf
            tc = tc & "                    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length)" & vbCrLf
            tc = tc & "                Finally" & vbCrLf
            tc = tc & "                    TDESAlgorithm.Clear()" & vbCrLf
            tc = tc & "                    HashProvider.Clear()" & vbCrLf
            tc = tc & "                End Try" & vbCrLf
            tc = tc & "            End Using" & vbCrLf
            tc = tc & "        End Using" & vbCrLf
            tc = tc & "        Return UTF8.GetString(Results)" & vbCrLf
            tc = tc & "    End Function" & vbCrLf
            tc = tc & "#End Region" & vbCrLf
            tc = tc & "End Class" & vbCrLf

            ' Thread Arguments for SOAP calls
            tc = tc & "Public Class SOAPArguments" & vbCrLf
            For Each m As nuSOAP_Method In nuSOAP_Methods
                If Not IsNothing(m.params) Then
                    tc = tc & "    Public Class " & m.name & vbCrLf
                    tmpParams = ""
                    For Each s As String In m.params
                        If s <> "" Then
                            If tmpParams <> "" Then tmpParams = tmpParams & vbCrLf
                            tmpParam = Split(s, "|")
                            tmpParams = tmpParams & "        Public Property " & tmpParam(0) & " As " & GetDotNetType(tmpParam(1))
                        End If
                    Next
                    tc = tc & tmpParams & vbCrLf
                    tc = tc & "    End Class" & vbCrLf
                End If
            Next
            tc = tc & "End Class"
            alpha.FastColoredTextBox5.Text = tc
            tc = ""

            ' VB.NET Functions
            tc = tc & "Module F" & vbCrLf
            tc = tc & "    WithEvents Threads As New ThreadQueue" & vbCrLf
            tc = tc & "    Private Sub Threads_ThreadComplete(sender As Object, e As ThreadQueue.ThreadResult) Handles Threads.ThreadComplete" & vbCrLf
            tc = tc & "        Select Case e.Function" & vbCrLf
            For Each m As nuSOAP_Method In nuSOAP_Methods
                tc = tc & "            Case ThreadQueue.FunctionNames." & m.name & vbCrLf
            tc = tc & "                If Not IsNothing(e.Result) Then" & vbCrLf
            tc = tc & "                   Dim oResult As " & GetDotNetType(m.returns) & " = DirectCast(e.Result, " & GetDotNetType(m.returns) & ")" & vbCrLf
            tc = tc & "                   ' Dim oOriginalArguments As SOAPArguments." & m.name & " = DirectCast(e.Argument, SOAPArguments." & m.name & ")" & vbCrLf
                If IsTypeAnArray(m.returns) Then
                tc = tc & "				   If oResult.Count > 0 Then" & vbCrLf
                tc = tc & "					   For Each oResultItem As " & GetDotNetType(m.returns, True) & " In oResult" & vbCrLf & vbCrLf
                tc = tc & "					   Next" & vbCrLf
                tc = tc & "				   End If" & vbCrLf
                End If
            tc = tc & "                Else" & vbCrLf
            tc = tc & "                   Dim oThreadParams As New ThreadQueue.ThreadParams" & vbCrLf
            tc = tc & "                   oThreadParams.Argument = e.Argument" & vbCrLf
            tc = tc & "                   oThreadParams.Argument = ThreadQueue.FunctionNames." & m.name & vbCrLf
            tc = tc & "                   Threads.StartThread(oThreadParams, e.ThreadID)" & vbCrLf
            tc = tc & "                End If" & vbCrLf
            ' IsTypeAnArray
            Next
            tc = tc & "            Case Else" & vbCrLf
            tc = tc & "        End Select" & vbCrLf
            tc = tc & "    End Sub" & vbCrLf

        tc = tc & "    Public Sub SET_API_PUBLIC_KEY(ByVal value As String)" & vbCrLf
            tc = tc & "        Threads.API_PUBLIC_KEY = value" & vbCrLf
            tc = tc & "    End Sub" & vbCrLf
        tc = tc & "    Public Sub SET_API_PRIVATE_KEY(ByVal value As String)" & vbCrLf
            tc = tc & "        Threads.API_PRIVATE_KEY = value" & vbCrLf
            tc = tc & "    End Sub" & vbCrLf
        tc = tc & "    Public Sub SET_URL_WSDL(ByVal value As String)" & vbCrLf
            tc = tc & "        Threads.API_WSDL_URL = value" & vbCrLf
            tc = tc & "    End Sub" & vbCrLf
        tc = tc & "    Public Sub SET_URL_PING(ByVal value As String)" & vbCrLf
            tc = tc & "        Threads.API_PING_URL = value" & vbCrLf
            tc = tc & "    End Sub" & vbCrLf

            Dim tmpMethodParams As String = ""
            For Each m As nuSOAP_Method In nuSOAP_Methods
                tmpMethodParams = ""
                tc = tc & "    Function " & m.name & "("
                If Not IsNothing(m.params) Then
                    For Each tmpParams In m.params
                        If tmpParams <> "" Then
                            tmpParam = Split(tmpParams, "|")
                            If tmpMethodParams <> "" Then tmpMethodParams = tmpMethodParams & ", "
                            tmpMethodParams = tmpMethodParams & "ByVal " & tmpParam(0) & " As " & GetDotNetType(tmpParam(1))
                        End If
                    Next
                End If
                tc = tc & tmpMethodParams & ") As System.Guid" & vbCrLf
                tc = tc & "        Dim oThreadParams As New ThreadQueue.ThreadParams" & vbCrLf
            If Not IsNothing(m.params) Then
                tc = tc & "        Dim oArguments As New SOAPArguments." & m.name & vbCrLf
            Else
                tc = tc & "        Dim oArguments As New Object" & vbCrLf
                tc = tc & "        oArguments = Nothing" & vbCrLf
            End If
            If Not IsNothing(m.params) Then
                For Each tmpParams In m.params
                    If tmpParams <> "" Then
                        tmpParam = Split(tmpParams, "|")
                        tc = tc & "        oArguments." & tmpParam(0) & " = " & tmpParam(0) & vbCrLf
                    End If
                Next
            End If
                tc = tc & "        oThreadParams.Argument = oArguments" & vbCrLf
                tc = tc & "        oThreadParams.Function = ThreadQueue.FunctionNames." & m.name & vbCrLf
            tc = tc & "        Return Threads.StartThread(oThreadParams).ToString" & vbCrLf
                tc = tc & "    End Function" & vbCrLf
        Next

        tc = tc & "    Public Function UnixToLocal(ByVal t As Integer) As DateTime" & vbCrLf
        tc = tc & "        Return New DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(t).ToLocalTime()" & vbCrLf
        tc = tc & "    End Function" & vbCrLf
        tc = tc & "    Public Function UnixFromLocal(Optional ByVal t As DateTime = Nothing) As Integer" & vbCrLf
        tc = tc & "        If Not IsNothing(t) Then" & vbCrLf
        tc = tc & "            Return Convert.ToInt32(System.Math.Ceiling(DateDiff(DateInterval.Second, #1/1/1970#, t.ToUniversalTime)" & vbCrLf
        tc = tc & "        Else" & vbCrLf
        tc = tc & "            Return Convert.ToInt32(System.Math.Ceiling(DateDiff(DateInterval.Second, #1/1/1970#, DateTime.Now.ToUniversalTime)" & vbCrLf
        tc = tc & "        End If" & vbCrLf
        tc = tc & "    End Function" & vbCrLf
        tc = tc & "End Module" & vbCrLf
            alpha.FastColoredTextBox4.Text = tc

    End Sub

    Public Function GetDotNetType(ByVal type As String, Optional ByVal StripBraces As Boolean = False) As String
        Select Case type
            Case "int"
                Return "Integer"
            Case "string"
                Return "String"
            Case "boolean"
                Return "Boolean"
            Case "long"
                Return "Long"
            Case "double"
                Return "Double"
            Case "date"
                Return "Date"
            Case "dateTime"
                Return "Long"
            Case Else
                '                If ReturnArrays = True Then
                If IsTypeAnArray(type) Then
                    If StripBraces = True Then
                        Return "SOAP." & type.Remove(type.Length - 1)
                    End If
                    Return "SOAP." & type.Remove(type.Length - 1) & "()"
                End If
                'End If
                Return "SOAP." & type
        End Select
    End Function

    Public Function Indent(Optional ByVal tabs As Integer = 2) As String
        Return New String(vbTab, tabs)
    End Function

    Public Function Bool2Int(ByVal b As Boolean) As Integer
        If b = False Then
            Return 0
        Else
            Return 1
        End If
    End Function

    Public Function IsTypeAnArray(ByVal typeName As String) As Boolean
        Select typeName
            Case "int"
                Return False
            Case "string"
                Return False
            Case "boolean"
                Return False
            Case "long"
                Return False
            Case "double"
                Return False
            Case "date"
                Return False
            Case "dateTime"
                Return False
            Case Else
                For Each t As nuSOAP_Type In nuSOAP_Types
                    If t.name = typeName Then
                        Return False
                    End If
                Next
        End Select
        Return True
    End Function

    Public Function ConfigPHP() As String
        Dim s As String = ""
        s = s & "<?php" & vbCrLf
        s = s & "	define('DEBUG',									" & My.Settings.DEBUG.ToString & ");" & vbCrLf
        s = s & "" & vbCrLf
        s = s & "/*****************************" & vbCrLf
        s = s & "	SOAP" & vbCrLf
        s = s & "******************************/" & vbCrLf
        s = s & "	define('SOAP_SERVICE_NAME',						'" & SOAPName & "');" & vbCrLf
        s = s & "" & vbCrLf
        s = s & "/*****************************" & vbCrLf
        s = s & "	DATABASE" & vbCrLf
        s = s & "******************************/" & vbCrLf
        s = s & "	define('DB_HOST',								'" & My.Settings.DB_HOST & "');" & vbCrLf
        s = s & "	define('DB_NAME',								'" & My.Settings.DB_NAME & "');" & vbCrLf
        s = s & "	define('DB_PREFIX',								'" & My.Settings.DB_PREFIX & "');" & vbCrLf
        s = s & "	define('DB_USER',								'" & My.Settings.DB_USER & "');" & vbCrLf
        s = s & "	define('DB_PASS',								'" & My.Settings.DB_PASS & "');" & vbCrLf
        s = s & "" & vbCrLf
        s = s & "/*****************************" & vbCrLf
        s = s & "	URBAN AIRSHIP" & vbCrLf
        s = s & "	Push services (iOS, Android, Blackberry, Windows)" & vbCrLf
        s = s & "******************************/" & vbCrLf
        s = s & "	define('PUSH_UA_SERVER',						'https://go.urbanairship.com/api/push/');" & vbCrLf
        s = s & "	define('PUSH_UA_APP_KEY',						'" & My.Settings.PUSH_UA_APP_KEY & "');" & vbCrLf
        s = s & "	define('PUSH_UA_APP_SECRET',					'" & My.Settings.PUSH_UA_APP_SECRET & "');" & vbCrLf
        s = s & "	define('PUSH_UA_SOUND',							'" & My.Settings.PUSH_UA_SOUND & "');" & vbCrLf
        s = s & "	" & vbCrLf
        s = s & "/*****************************" & vbCrLf
        s = s & "	ANDROID PUSH" & vbCrLf
        s = s & "******************************/" & vbCrLf
        s = s & "	define('PUSH_GCM_SANDBOX',						" & My.Settings.PUSH_GCM_SANDBOX.ToString & ");" & vbCrLf
        s = s & "	if(PUSH_GCM_SANDBOX) {" & vbCrLf
        s = s & "		// Sandbox" & vbCrLf
        s = s & "		define('PUSH_GCM_KEY',						'" & My.Settings.PUSH_GCM_KEY & "');" & vbCrLf
        s = s & "		define('PUSH_GCM_SERVER',					'https://android.googleapis.com/gcm/send');" & vbCrLf
        s = s & "		define('PUSH_GCM_SOUND',					'" & My.Settings.PUSH_GCM_SOUND & "');" & vbCrLf
        s = s & "	} else {" & vbCrLf
        s = s & "		// Live" & vbCrLf
        s = s & "		define('PUSH_GCM_KEY',						'" & My.Settings.PUSH_GCM_KEY_LIVE & "');" & vbCrLf
        s = s & "		define('PUSH_GCM_SERVER',					'https://android.googleapis.com/gcm/send');" & vbCrLf
        s = s & "		define('PUSH_GCM_SOUND',					'" & My.Settings.PUSH_GCM_SOUND_LIVE & "');" & vbCrLf
        s = s & "	}" & vbCrLf
        s = s & "" & vbCrLf
        s = s & "/*****************************" & vbCrLf
        s = s & "	APPLE PUSH" & vbCrLf
        s = s & "******************************/" & vbCrLf
        s = s & "	define('PUSH_APNS_SANDBOX',						" & My.Settings.PUSH_APNS_SANDBOX & ");" & vbCrLf
        s = s & "	if(PUSH_APNS_SANDBOX) {" & vbCrLf
        s = s & "		// Sandbox" & vbCrLf
        s = s & "		define('PUSH_APNS_SERVER',					'ssl://gateway.sandbox.push.apple.com:2195');" & vbCrLf
        s = s & "		define('PUSH_APNS_CERTIFICATE',				'" & My.Settings.PUSH_APNS_CERTIFICATE & "');" & vbCrLf
        s = s & "		define('PUSH_APNS_CERTIFICATE_PASSPHRASE',	'" & My.Settings.PUSH_APNS_CERTIFICATE_PASSPHRASE & "');" & vbCrLf
        s = s & "		define('PUSH_APNS_SOUND',					'" & My.Settings.PUSH_APNS_SOUND & "');" & vbCrLf
        s = s & "	} else {" & vbCrLf
        s = s & "		// Live" & vbCrLf
        s = s & "		define('PUSH_APNS_SERVER',					'ssl://gateway.push.apple.com:2195');" & vbCrLf
        s = s & "		define('PUSH_APNS_CERTIFICATE',				'" & My.Settings.PUSH_APNS_CERTIFICATE_LIVE & "');" & vbCrLf
        s = s & "		define('PUSH_APNS_CERTIFICATE_PASSPHRASE',	'" & My.Settings.PUSH_APNS_CERTIFICATE_PASSPHRASE_LIVE & "');" & vbCrLf
        s = s & "		define('PUSH_APNS_SOUND',					'" & My.Settings.PUSH_APNS_SOUND_LIVE & "');" & vbCrLf
        s = s & "	}" & vbCrLf
        Return s
    End Function

End Module
