Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Text

Public Class DataAccess
    Public Settings As Settings '= Settings.Instance
    Private _MyConnectionString As String
    Private URights As UserRights = UserRights.Instance

    Public Sub New()
        Try
            Settings = Settings.Instance
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub New(AlternativeConfig As String)
        Settings = Settings.Instance(AlternativeConfig)
    End Sub

    Public Function TestConnection() As Boolean
        Try
            Dim result As Boolean = False
            Dim conn As New SqlConnection(MyConnectionString)
            conn.Open()
            conn.Close()

            result = True
            Return result
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetConnection() As SqlConnection

        Dim conn As New SqlConnection(MyConnectionString)
        conn.Open()

        Return conn
    End Function
    Public Sub CloseAllPool()
        SqlConnection.ClearAllPools()
    End Sub
    Public Property MyConnectionString() As String
        Get
            If String.IsNullOrEmpty(_MyConnectionString) Then
                Dim password As String = ""
                If CryptoService.Decrypt(Settings.password).ToUpper = "DEFAULT" Then
                    password = ""
                Else
                    password = CryptoService.Decrypt(Settings.password)
                End If

                _MyConnectionString = "server=" & Settings.ServerIP & ";" _
                                   & "user id=" & Settings.Account & ";" _
                                   & "password=" & password & ";" _
                                   & "database= " & Settings.DataBase

            End If
            Return _MyConnectionString
        End Get
        Set(ByVal value As String)
            _MyConnectionString = value
        End Set
    End Property
    Public Function MaxLidNr(Optional ByVal sql As String = "") As String
        Dim result As String = 0
        Try
            If String.IsNullOrEmpty(sql) Then sql = "SELECT max(lidnr) FROM relaties"
            result = ExecuteScalar(sql).ToString

            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CheckPostcode_Afdeling(ByVal _pc As Int16) As String
        Dim result As String = 0
        Try
            Dim Sql As String = "SELECT afdeling FROM Afdeling_postcode WHERE (postcodeva <= @pc AND postcodetm >= @pc)"
            Dim param() As Object = {"@pc", _pc}
            result = ExecuteScalar(Sql, param)
            If result Is Nothing Then result = 0
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateMutDateDossier(DossierId As Int32)
        Try
            Dim sql As String = "UPDATE IBBDossiers SET MutDate = @now  where Id = @dossierId"
            Dim parameters As New List(Of Object)
            parameters.Add("DossierId")
            parameters.Add(DossierId)
            parameters.Add("now")
            parameters.Add(Now)
            ExecuteNonQuery(sql, Nothing, parameters)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function isChanged(ByVal obj As Object, ByVal DataTableName As String,
                              ByVal PrimaryKey As String, ByVal PrimaryKeyValue As String,
                              ByVal LidId As Integer, Optional ByVal bUpdateHistory As Boolean = True) As Boolean

        Dim myreader As SqlClient.SqlDataReader

        Try
            Using connection As SqlConnection = New SqlConnection(MyConnectionString)
                Dim sql As String = "SELECT * FROM " & DataTableName & " WHERE " & PrimaryKey & " = @" & PrimaryKey
                Dim parameters() As Object = {"@" & PrimaryKey, PrimaryKeyValue}

                Dim command As SqlCommand
                command = New SqlCommand(sql, connection)


                If Not parameters Is Nothing Then
                    For i As Integer = 0 To parameters.Length - 1 Step 2
                        command.Parameters.AddWithValue(CType(parameters(i), String), parameters(i + 1))
                    Next
                End If

                connection.Open()
                myreader = command.ExecuteReader()
                myreader.Read()

                Dim HistoryList As New List(Of History)
                Dim myHistory As History = Nothing

                If myreader.HasRows Then
                    For Each p As System.Reflection.PropertyInfo In obj.GetType().GetProperties()
                        If p.CanRead Then
                            For Each attributeObject As Object In p.GetCustomAttributes(False)
                                If attributeObject.GetType() Is GetType(MapperColumn) Then
                                    Dim columnAttributeObject As MapperColumn = CType(attributeObject, MapperColumn)
                                    Dim MyReaderValue As Object = myreader.Item(columnAttributeObject.ColumnName)
                                    If MyReaderValue Is System.DBNull.Value Then
                                        Select Case p.PropertyType.Name.ToLower
                                            Case "int32", "int64", "double", "int"
                                                MyReaderValue = 0
                                            Case "string"
                                                MyReaderValue = ""
                                            Case "datetime"
                                                MyReaderValue = DBNull.Value 'Data.SqlTypes.SqlDateTime.MinValue.Value
                                            Case "boolean"
                                                MyReaderValue = False
                                                'Case "nullable`1"
                                                '    MyReaderValue = DBNull.Value
                                        End Select
                                    End If

                                    Dim RowChanged As Boolean = False
                                    If columnAttributeObject.DBType = SqlDbType.DateTime Then
                                        If MyReaderValue Is System.DBNull.Value OrElse MyReaderValue.ToString = String.Empty Then
                                            RowChanged = MyReaderValue <> p.GetValue(obj, Nothing)
                                        ElseIf columnAttributeObject.ColumnName = "LastChangeDate" Then
                                            ' RowChanged = MyReaderValue <> p.GetValue(obj, Nothing)
                                        Else
                                            RowChanged = Format(MyReaderValue, "dd-MM-yyyy") <> p.GetValue(obj, Nothing).ToString
                                        End If
                                    Else
                                        RowChanged = MyReaderValue <> p.GetValue(obj, Nothing)
                                    End If

                                    If RowChanged Then
                                        myHistory = New History
                                        myHistory.LidId = LidId
                                        myHistory.TableName = DataTableName
                                        myHistory.Veld = columnAttributeObject.ColumnName
                                        myHistory.WaardeOud = MyReaderValue
                                        'If myHistory.WaardeOud.Length > 99 Then
                                        '    myHistory.WaardeOud = myHistory.WaardeOud.Substring(0, 99)
                                        'End If
                                        myHistory.WaardeNieuw = p.GetValue(obj, Nothing)
                                        'If myHistory.WaardeNieuw.Length > 99 Then
                                        '    myHistory.WaardeNieuw = myHistory.WaardeNieuw.Substring(0, 99)
                                        'End If
                                        myHistory.MutDate = Now
                                        myHistory.MutDoor = URights.UserName
                                        HistoryList.Add(myHistory)
                                    End If
                                End If
                            Next
                        End If
                    Next
                Else
                    'dan is er een nieuwe record togevoegd.
                    'in dat geval 1 record in history ipv alle velden
                    myHistory = New History
                    myHistory.LidId = LidId
                    myHistory.TableName = DataTableName
                    myHistory.Veld = "Nieuw record"
                    myHistory.WaardeOud = ""
                    myHistory.WaardeNieuw = ""
                    myHistory.MutDate = Now
                    myHistory.MutDoor = URights.UserName
                    HistoryList.Add(myHistory)
                End If

                connection.Close()
                connection.Dispose()

                If HistoryList.Count > 0 Then
                    If bUpdateHistory Then
                        For Each History In HistoryList
                            History.Save()
                        Next
                    End If
                    Return True
                End If


            End Using

            Return False

        Catch ex As Exception
            Throw ex
        Finally
            myreader = Nothing
        End Try
    End Function
    Public Function ExecuteReader(ByVal sql As String, Optional ByVal parameters() As Object = Nothing) As SqlDataReader


        Dim connection As SqlConnection = GetConnection()
        Dim command As SqlCommand
        command = New SqlCommand(sql, connection)
        Try

            If Not parameters Is Nothing Then
                For i As Integer = 0 To parameters.Length - 1 Step 2
                    command.Parameters.AddWithValue(CType(parameters(i), String), parameters(i + 1))
                Next
            End If

            Return command.ExecuteReader()
            connection.Close()


        Catch ex As Exception
            Throw ex
        Finally
            '    If Not command Is Nothing Then
            command.Dispose()
            '        command = Nothing
            'End If
        End Try
    End Function
    Public Function ExecuteDataTableStoredProcedure(ByVal StoredProcedureName As String, Optional ByVal parameters() As Object = Nothing) As DataTable
        Dim result As New DataTable()

        Try
            Using connection As SqlConnection = GetConnection()
                'Dim command As New SqlCommand(sql, connection)

                Dim Command As SqlCommand = New SqlCommand()
                Command.Connection = connection
                Command.CommandText = StoredProcedureName
                Command.CommandType = CommandType.StoredProcedure


                If Not parameters Is Nothing Then
                    For i As Integer = 0 To parameters.Length - 1 Step 2
                        Command.Parameters.AddWithValue(CType(parameters(i), String), parameters(i + 1))
                    Next
                End If

                Dim adapter As New SqlDataAdapter(Command)
                adapter.Fill(result)
            End Using

            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExecuteDataTable(ByVal sql As String, Optional ByVal parameters() As Object = Nothing) As DataTable
        Dim result As New DataTable()

        Try
            Using connection As SqlConnection = GetConnection()
                Dim command As New SqlCommand(sql, connection)

                If Not parameters Is Nothing Then
                    For i As Integer = 0 To parameters.Length - 1 Step 2
                        command.Parameters.AddWithValue(CType(parameters(i), String), parameters(i + 1))
                    Next
                End If

                Dim adapter As New SqlDataAdapter(command)
                adapter.Fill(result)
            End Using

            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExecuteDataRow(ByVal sql As String, Optional ByVal parameters() As Object = Nothing) As DataRow
        Try
            Dim result As DataRow = Nothing

            Using connection As SqlConnection = GetConnection()
                Dim command As New SqlCommand(sql, connection)
                If Not parameters Is Nothing Then
                    For i As Integer = 0 To parameters.Length - 1 Step 2
                        command.Parameters.AddWithValue(CType(parameters(i), String), parameters(i + 1))
                    Next
                End If

                Dim dt As New DataTable()
                Dim adapter As New SqlDataAdapter(command)
                adapter.Fill(dt)
                If dt.Rows.Count > 0 Then
                    If dt.Rows.Count > 1 Then
                        Throw New Exception("Er zijn " & dt.Rows.Count & " resultaten waar er maar 1 verwacht wordt!")
                    Else
                        result = dt.Rows(0)
                    End If
                End If
            End Using

            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExecuteDataset(ByVal sql As String, Optional ByVal parameters() As Object = Nothing) As DataSet
        Dim result As New DataSet
        Try
            'Using connection As SqlConnection = GetConnection()
            Using connection As SqlConnection = New SqlConnection(MyConnectionString)
                connection.Open()
                Dim command As New SqlCommand(sql, connection)

                If Not parameters Is Nothing Then
                    For i As Integer = 0 To parameters.Length - 1 Step 2
                        command.Parameters.AddWithValue(CType(parameters(i), String), parameters(i + 1))
                    Next
                End If

                Dim adapter As New SqlDataAdapter(command)
                adapter.Fill(result)
                connection.Close()
            End Using

            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExecuteScalar(ByVal sql As String, Optional ByVal parameters() As Object = Nothing) As Object
        Dim result As Object
        Try
            Using connection As SqlConnection = GetConnection()
                Dim command As SqlCommand
                command = New SqlCommand(sql, connection)

                If Not parameters Is Nothing Then
                    For i As Integer = 0 To parameters.Length - 1 Step 2
                        command.Parameters.AddWithValue(CType(parameters(i), String), parameters(i + 1))
                    Next
                End If
                result = command.ExecuteScalar()
            End Using

            Return result

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ExecuteNonQuery(ByVal sql As String, ByVal idName As String, Optional ByVal parameters As List(Of Object) = Nothing, Optional ByVal seed As Boolean = False) As Object

        Try
            Dim result As Object = Nothing
            ' Dim connection As SqlConnection = GetConnection()
            Using connection As SqlConnection = GetConnection()
                Dim command As New SqlCommand '(sql, connection)
                If Not parameters Is Nothing Then
                    For i As Integer = 0 To parameters.Count - 1 Step 2
                        If CType(parameters(i), String) = idName AndAlso (parameters(i + 1).ToString = "0" Or parameters(i + 1).ToString = "") Then Continue For
                        command.Parameters.AddWithValue("@" & CType(parameters(i), String), parameters(i + 1))
                        If CType(parameters(i), String) = idName Then result = parameters(i + 1)
                    Next
                End If
                If sql.Contains("INSERT ") Then
                    If Not idName Is Nothing Then
                        'If command.Parameters("@" & idName).Value.ToString = "" Or command.Parameters("@" & idName).Value.ToString = 0 Then
                        If seed Then
                            'command.Parameters.RemoveAt("@" & idName)

                            sql &= "SET @" & idName & " = SCOPE_IDENTITY()"
                            Dim idParam As SqlParameter = New SqlParameter(idName, SqlDbType.Int)
                            idParam.Direction = ParameterDirection.Output
                            command.Parameters.Add(idParam)
                            result = command.Parameters(idName).Value
                        Else
                            result = command.Parameters("@" & idName).Value
                        End If
                    End If
                End If

                command.CommandText = sql
                command.Connection = connection
                command.ExecuteNonQuery()

                connection.Close()
                connection.Dispose()

                If idName Is Nothing Then
                    Return result
                ElseIf seed Then
                    Return command.Parameters(idName).Value
                Else
                    Return command.Parameters("@" & idName).Value
                End If

            End Using

            'Return result 'command.Parameters(idName).Value
        Catch ex As Exception
            Throw ex

        End Try
    End Function

    Public Function GetListOfString(sql As String, Optional ByVal parameters() As Object = Nothing) As List(Of String)
        Try
            Dim result As New List(Of String)

            Dim dt As DataTable
            dt = ExecuteDataTable(sql, parameters)
            For Each dr As DataRow In dt.Rows
                result.Add(dr.Item(0))
            Next

            Return result

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function IsNetmask() As Boolean
        Try
            Dim localHost As String = System.Net.Dns.GetHostName()

            Dim IPHEntry As System.Net.IPHostEntry
            Dim IPAdd() As System.Net.IPAddress
            IPHEntry = System.Net.Dns.GetHostEntry(localHost)
            IPAdd = IPHEntry.AddressList


            Dim i As Integer
            For i = 0 To IPAdd.GetUpperBound(0)
                If IPAdd(i).ToString.StartsWith("10.2.1.") Then
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Sub DeleteCommand(ByVal obj As Object, ByVal DataTableName As String, Optional ByVal PrimaryKey As String = Nothing)

        If Not String.IsNullOrEmpty(PrimaryKey) Then
            Dim sql As String = "DELETE FROM " & DataTableName & " WHERE " & PrimaryKey & " = @" & PrimaryKey

            Dim parameters As New List(Of Object)
            For Each p As System.Reflection.PropertyInfo In obj.GetType().GetProperties()
                If p.CanRead Then
                    For Each attributeObject As Object In p.GetCustomAttributes(False)
                        If attributeObject.GetType() Is GetType(MapperColumn) Then
                            Dim columnAttributeObject As MapperColumn = CType(attributeObject, MapperColumn)
                            If p.Name = PrimaryKey Then
                                parameters.Add(columnAttributeObject.ColumnName)
                                parameters.Add(p.GetValue(obj, Nothing))
                            End If
                        End If
                    Next
                End If
            Next
            ExecuteNonQuery(sql, PrimaryKey, parameters)
        End If
    End Sub

    Private Class InsertSqlString
        Private _InsertMembersString As StringBuilder = Nothing
        Private _InsertValuesString As StringBuilder = Nothing
        Private _paramCount As Integer

        Public ReadOnly Property InsertMembersString() As StringBuilder
            Get
                Return _InsertMembersString
            End Get
        End Property
        Public ReadOnly Property InsertValuesString() As StringBuilder
            Get
                Return _InsertValuesString
            End Get
        End Property
        Public ReadOnly Property ParamCount() As Integer
            Get
                Return _paramCount
            End Get
        End Property

        Public Sub New(ByVal insertMembersString As StringBuilder, ByVal insertValuesString As StringBuilder, ByVal paramCount As Integer)
            _InsertMembersString = insertMembersString
            _InsertValuesString = insertValuesString
            _paramCount = paramCount
        End Sub
    End Class

    Private Shared _InsertStringDictionary As New Dictionary(Of String, InsertSqlString)

    Public Function InsertString(ByVal obj As Object, ByVal DataTableName As String, Optional ByVal PrimaryKey As String = Nothing, Optional ByVal seed As Boolean = False) As Object

        Dim strbuildMembers As New System.Text.StringBuilder
        Dim strbuildValues As New System.Text.StringBuilder
        Dim paramCount As Integer = 0

        Try
            If _InsertStringDictionary.ContainsKey(DataTableName) Then
                Dim insertSqlString As InsertSqlString = _InsertStringDictionary(DataTableName)

                strbuildMembers = insertSqlString.InsertMembersString
                strbuildValues = insertSqlString.InsertValuesString
                paramCount = insertSqlString.ParamCount
            Else
                strbuildMembers.Append("INSERT INTO " & DataTableName & "( ")
                strbuildValues.Append(") VALUES ( ")

                For Each p As System.Reflection.PropertyInfo In obj.GetType().GetProperties()
                    If p.CanRead Then
                        For Each attributeObject As Object In p.GetCustomAttributes(False)
                            If attributeObject.GetType() Is GetType(MapperColumn) Then
                                Dim columnAttributeObject As MapperColumn = CType(attributeObject, MapperColumn)
                                If columnAttributeObject.ColumnName = PrimaryKey And seed = True Then
                                    Continue For
                                End If

                                strbuildMembers.Append(columnAttributeObject.ColumnName & ", ")
                                strbuildValues.Append("@" & columnAttributeObject.ColumnName & ", ")
                                paramCount += 1
                            End If
                        Next
                    End If
                Next
                strbuildMembers.Remove(strbuildMembers.Length - 2, 2)
                strbuildValues.Remove(strbuildValues.Length - 2, 2)
                strbuildValues.Append(")")

                _InsertStringDictionary.Add(DataTableName, New InsertSqlString(strbuildMembers, strbuildValues, paramCount))
            End If

            Dim parameters As New List(Of Object)
            For Each p As System.Reflection.PropertyInfo In obj.GetType().GetProperties()
                If p.CanRead Then
                    For Each attributeObject As Object In p.GetCustomAttributes(False)
                        If attributeObject.GetType() Is GetType(MapperColumn) Then
                            Dim columnAttributeObject As MapperColumn = CType(attributeObject, MapperColumn)

                            If p.Name = PrimaryKey And seed = True Then
                                parameters.Add(columnAttributeObject.ColumnName)
                                'parameters.Add(p.GetValue(obj, Nothing))
                            ElseIf p.Name = PrimaryKey Then
                                Continue For
                                ' parameters.Add(columnAttributeObject.ColumnName)
                                ' parameters.Add(GetNewId(DataTableName, PrimaryKey))
                            Else
                                parameters.Add(columnAttributeObject.ColumnName)
                                'parameters.Add(p.GetValue(obj, Nothing))
                            End If

                            'datumvelden aanpassen omdat het van text naar datetime moet worden geconventeerd
                            If columnAttributeObject.DBType = SqlDbType.DateTime And Not columnAttributeObject.ColumnName = "LastChangeDate" Then
                                Dim NewObjValue As Object = p.GetValue(obj, Nothing)
                                If NewObjValue = String.Empty Then
                                    parameters.Add(DBNull.Value)
                                Else
                                    parameters.Add(CDate(p.GetValue(obj, Nothing)))
                                End If
                            Else
                                parameters.Add(p.GetValue(obj, Nothing))
                            End If

                            paramCount += 1
                        End If
                    Next
                End If
            Next

            Return ExecuteNonQuery(strbuildMembers.ToString & strbuildValues.ToString, PrimaryKey, parameters, seed)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetUpdateString(ByVal obj As Object, ByVal DataTableName As String, Optional ByVal PrimaryKey As String = Nothing) As String

        Dim strbuildMembers As New System.Text.StringBuilder
        Try
            strbuildMembers.Append("UPDATE " & DataTableName & " SET ")
            Dim PrimaryKeyValue As String = ""
            Dim paramCount As Integer = 0
            For Each p As System.Reflection.PropertyInfo In obj.GetType().GetProperties()
                If p.CanRead Then
                    For Each attributeObject As Object In p.GetCustomAttributes(False)
                        If attributeObject.GetType() Is GetType(MapperColumn) Then
                            Dim columnAttributeObject As MapperColumn = CType(attributeObject, MapperColumn)
                            If columnAttributeObject.ColumnName = PrimaryKey Then Continue For

                            strbuildMembers.Append(columnAttributeObject.ColumnName & " = @" & columnAttributeObject.ColumnName & ", ")
                            paramCount += 1
                        End If
                    Next

                End If
            Next
            strbuildMembers.Remove(strbuildMembers.Length - 2, 2)

            strbuildMembers.Append(" WHERE " & PrimaryKey & " = @" & PrimaryKey)

            Dim parameters As New List(Of Object)
            For Each p As System.Reflection.PropertyInfo In obj.GetType().GetProperties()
                If p.CanRead Then
                    For Each attributeObject As Object In p.GetCustomAttributes(False)
                        If attributeObject.GetType() Is GetType(MapperColumn) Then
                            Dim columnAttributeObject As MapperColumn = CType(attributeObject, MapperColumn)
                            parameters.Add(columnAttributeObject.ColumnName)
                            'datumvelden aanpassen omdat het van text naar datetime moet worden geconventeerd
                            If columnAttributeObject.DBType = SqlDbType.DateTime Or columnAttributeObject.DBType = SqlDbType.Date Then
                                Dim NewObjValue As Object = p.GetValue(obj, Nothing)
                                If NewObjValue = String.Empty Then
                                    parameters.Add(DBNull.Value)
                                Else
                                    parameters.Add(CDate(p.GetValue(obj, Nothing)))
                                End If
                            Else
                                parameters.Add(p.GetValue(obj, Nothing))
                            End If
                            paramCount += 1
                        End If
                    Next
                End If
            Next

            Return strbuildMembers.ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function UpdateString(ByVal obj As Object, ByVal DataTableName As String, Optional ByVal PrimaryKey As String = Nothing) As Object

        Dim strbuildMembers As New System.Text.StringBuilder
        Try
            strbuildMembers.Append("UPDATE " & DataTableName & " SET ")
            Dim PrimaryKeyValue As String = ""
            Dim paramCount As Integer = 0
            For Each p As System.Reflection.PropertyInfo In obj.GetType().GetProperties()
                If p.CanRead Then
                    For Each attributeObject As Object In p.GetCustomAttributes(False)
                        If attributeObject.GetType() Is GetType(MapperColumn) Then
                            Dim columnAttributeObject As MapperColumn = CType(attributeObject, MapperColumn)
                            If columnAttributeObject.ColumnName = PrimaryKey Then Continue For

                            strbuildMembers.Append(columnAttributeObject.ColumnName & " = @" & columnAttributeObject.ColumnName & ", ")
                            paramCount += 1
                        End If
                    Next

                End If
            Next
            strbuildMembers.Remove(strbuildMembers.Length - 2, 2)

            strbuildMembers.Append(" WHERE " & PrimaryKey & " = @" & PrimaryKey)

            Dim parameters As New List(Of Object)
            For Each p As System.Reflection.PropertyInfo In obj.GetType().GetProperties()
                If p.CanRead Then
                    For Each attributeObject As Object In p.GetCustomAttributes(False)
                        If attributeObject.GetType() Is GetType(MapperColumn) Then
                            Dim columnAttributeObject As MapperColumn = CType(attributeObject, MapperColumn)
                            parameters.Add(columnAttributeObject.ColumnName)
                            'datumvelden aanpassen omdat het van text naar datetime moet worden geconventeerd
                            If (columnAttributeObject.DBType = SqlDbType.DateTime Or columnAttributeObject.DBType = SqlDbType.Date) And Not columnAttributeObject.ColumnName = "LastChangeDate" Then
                                Dim NewObjValue As Object = p.GetValue(obj, Nothing)
                                If NewObjValue = String.Empty Then
                                    parameters.Add(DBNull.Value)
                                Else
                                    parameters.Add(CDate(p.GetValue(obj, Nothing)))
                                End If
                            Else
                                parameters.Add(p.GetValue(obj, Nothing))
                            End If
                            paramCount += 1
                        End If
                    Next
                End If
            Next

            Return ExecuteNonQuery(strbuildMembers.ToString, PrimaryKey, parameters)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function DeleteString(ByVal obj As Object, ByVal DataTableName As String, Optional ByVal PrimaryKey As String = Nothing) As Object

        Dim strbuildMembers As New System.Text.StringBuilder
        Try
            strbuildMembers.Append("DELETE FROM " & DataTableName)
            strbuildMembers.Append(" WHERE ")
            Dim PrimaryKeyValue As String = ""
            Dim paramCount As Integer = 0
            For Each p As System.Reflection.PropertyInfo In obj.GetType().GetProperties()
                If p.CanRead Then
                    For Each attributeObject As Object In p.GetCustomAttributes(False)
                        If attributeObject.GetType() Is GetType(MapperColumn) Then
                            Dim columnAttributeObject As MapperColumn = CType(attributeObject, MapperColumn)
                            strbuildMembers.Append(columnAttributeObject.ColumnName & " = @" & columnAttributeObject.ColumnName & " AND ")
                            paramCount += 1
                        End If
                    Next

                End If
            Next
            strbuildMembers.Remove(strbuildMembers.Length - 4, 4)
            Dim parameters As New List(Of Object)
            For Each p As System.Reflection.PropertyInfo In obj.GetType().GetProperties()
                If p.CanRead Then
                    For Each attributeObject As Object In p.GetCustomAttributes(False)
                        If attributeObject.GetType() Is GetType(MapperColumn) Then
                            Dim columnAttributeObject As MapperColumn = CType(attributeObject, MapperColumn)
                            parameters.Add(columnAttributeObject.ColumnName)
                            'datumvelden aanpassen omdat het van text naar datetime moet worden geconventeerd
                            If columnAttributeObject.DBType = SqlDbType.DateTime Then
                                Dim NewObjValue As Object = p.GetValue(obj, Nothing)
                                If NewObjValue = String.Empty Then
                                    parameters.Add(DBNull.Value)
                                Else
                                    parameters.Add(CDate(p.GetValue(obj, Nothing)))
                                End If
                            Else
                                parameters.Add(p.GetValue(obj, Nothing))
                            End If
                            paramCount += 1
                        End If
                    Next
                End If
            Next

            Return ExecuteNonQuery(strbuildMembers.ToString, PrimaryKey, parameters)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetTableNames(ByVal Procedure As String) As ArrayList

        Dim values As ArrayList = New ArrayList()
        Dim Reader As SqlDataReader
        Dim cmd As New SqlCommand
        Procedure = "Select Name FROM dbo.sysobjects WHERE xtype = 'U'"
        With cmd
            .Connection = GetConnection()
            '.CommandType = CommandType.StoredProcedure
            .CommandType = CommandType.Text
            .CommandText = Procedure
        End With

        Reader = cmd.ExecuteReader()
        While Reader.Read()
            values.Add(Reader.Item("Name").ToString())
        End While


        Reader.Close()
        Return values

    End Function
    Public Function GetColumnsNames(ByVal sTable As String) As ArrayList
        Dim values As ArrayList = New ArrayList()
        Dim sSQL As String = ""

        sSQL = "select TOP 1 * from " & sTable

        Dim adapter As New SqlClient.SqlDataAdapter(sSQL, MyConnectionString)
        Dim ds As New DataSet
        adapter.Fill(ds, sTable)
        For Each dc As DataColumn In ds.Tables(0).Columns
            'if dc.
            values.Add(dc.ColumnName)
        Next
        Return values

    End Function

End Class
