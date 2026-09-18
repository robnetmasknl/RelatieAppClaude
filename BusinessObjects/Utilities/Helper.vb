Option Strict On
Option Explicit On

Imports System.Collections.Generic
Imports System.Data
Imports System.Reflection

Public Class Helper
    Private Class NameType
        Private _Name As String = String.Empty
        Private _TypeName As String = String.Empty
        Private _ColumnIndex As Integer
        Private _SqlType As SqlDbType = Nothing

        Public ReadOnly Property SqlType() As SqlDbType
            Get
                Return _SqlType
            End Get
        End Property

        Public ReadOnly Property TypeName() As String
            Get
                Return _TypeName
            End Get
        End Property

        Public ReadOnly Property ColumnIndex() As Integer
            Get
                Return _ColumnIndex
            End Get
        End Property

        Public Sub New(ByVal sqlType As SqlDbType, ByVal typeName As String, ByVal columnIndex As Integer)
            _SqlType = sqlType
            _TypeName = typeName
            _ColumnIndex = columnIndex
        End Sub
    End Class

    Private Class NameTypeDictionary
        Inherits Dictionary(Of String, NameType)

    End Class

    Private Shared _TableDictionary As New Dictionary(Of String, NameTypeDictionary)

    Private Function GetNameTypeDictionary(ByVal obj As Object, ByVal properties() As Reflection.PropertyInfo) As NameTypeDictionary
        Dim objectTable As MapperTable = CType(Attribute.GetCustomAttribute(obj.GetType(), GetType(MapperTable)), MapperTable)

        Dim nameTypeDictionary As NameTypeDictionary = Nothing
        If objectTable Is Nothing OrElse Not _TableDictionary.ContainsKey(objectTable.TableName) Then
            nameTypeDictionary = New NameTypeDictionary()

            If Not objectTable Is Nothing Then
                _TableDictionary.Add(objectTable.TableName, nameTypeDictionary)
            End If

            If (properties.Length > 0) Then
                Dim indexer As Integer = 0

                For Each propertyObject As Reflection.PropertyInfo In properties
                    Dim columnFound As Boolean = False
                    For Each attributeObject As Object In propertyObject.GetCustomAttributes(False)
                        If attributeObject.GetType() Is GetType(MapperColumn) Then
                            Dim columnAttributeObject As MapperColumn = CType(attributeObject, MapperColumn)
                            If (columnAttributeObject.ColumnName <> String.Empty) Then
                                nameTypeDictionary.Add(columnAttributeObject.ColumnName, New NameType(columnAttributeObject.DBType, propertyObject.PropertyType.Name, indexer))
                            End If

                            columnFound = True
                        End If
                    Next

                    If Not columnFound Then
                        nameTypeDictionary.Add(propertyObject.Name, New NameType(SqlDbType.Variant, propertyObject.PropertyType.Name, indexer))
                    End If

                    indexer += 1
                Next
            End If
        Else
            nameTypeDictionary = _TableDictionary(objectTable.TableName)
        End If

        Return nameTypeDictionary
    End Function

    Public Sub FillObject(ByVal obj As Object, ByVal dr As DataRow)
        Try
            If dr Is Nothing Then
                Exit Sub
            End If

            Dim properties() As Reflection.PropertyInfo = obj.GetType().GetProperties()

            Dim nameTypeDictionary As NameTypeDictionary = GetNameTypeDictionary(obj, properties)

            For Each column As DataColumn In dr.Table.Columns
                Dim valueSet As Boolean = False
                If nameTypeDictionary.ContainsKey(column.ColumnName) Then
                    Dim nameType As NameType = nameTypeDictionary(column.ColumnName)
                    Dim indexer As Integer = nameType.ColumnIndex

                    If Not dr(column.ColumnName) Is DBNull.Value Then
                        If dr(column.ColumnName).GetType.Name = "DateTime" And nameTypeDictionary(column.ColumnName).TypeName = "String" Then
                            'properties(indexer).SetValue(obj, Format(dr(column.ColumnName), "dd-MM-yyyy hh:mm:ss"), Nothing)
                            properties(indexer).SetValue(obj, Format(dr(column.ColumnName), "dd-MM-yyyy"), Nothing)
                        ElseIf nameType.SqlType = SqlDbType.NVarChar Then
                            properties(indexer).SetValue(obj, dr(column.ColumnName).ToString.Trim, Nothing)
                        Else
                            properties(indexer).SetValue(obj, dr(column.ColumnName), Nothing)
                        End If

                        valueSet = True
                    End If


                    If Not valueSet Then
                        If Not dr(column.ColumnName) Is DBNull.Value Then
                            properties(indexer).SetValue(obj, dr(column.ColumnName), Nothing)
                        End If
                    End If
                End If
            Next

            'If (properties.Length > 0) Then
            '    For Each propertyObject As Reflection.PropertyInfo In properties
            '        Dim valueSet As Boolean = False
            '        For Each attributeObject As Object In propertyObject.GetCustomAttributes(False)
            '            If attributeObject.GetType() Is GetType(MapperColumn) Then
            '                Dim columnAttributeObject As MapperColumn = CType(attributeObject, MapperColumn)
            '                If (columnAttributeObject.ColumnName <> String.Empty) Then
            '                    If dr.Table.Columns.Contains(columnAttributeObject.ColumnName) AndAlso Not dr(columnAttributeObject.ColumnName) Is DBNull.Value Then
            '                        If dr(columnAttributeObject.ColumnName).GetType.Name = "DateTime" And propertyObject.PropertyType.Name = "String" Then
            '                            propertyObject.SetValue(obj, Format(dr(columnAttributeObject.ColumnName), "dd-MM-yyyy"), Nothing)
            '                        Else
            '                            propertyObject.SetValue(obj, dr(columnAttributeObject.ColumnName), Nothing)
            '                        End If

            '                        valueSet = True
            '                    End If
            '                End If
            '            End If
            '        Next

            '        If Not valueSet Then
            '            If dr.Table.Columns.Contains(propertyObject.Name) AndAlso Not dr(propertyObject.Name) Is DBNull.Value Then
            '                propertyObject.SetValue(obj, dr(propertyObject.Name), Nothing)
            '            End If
            '        End If

            '    Next
            'End If


        Catch ex As Exception
            Throw (ex)
        End Try
    End Sub
    Public Function MapDatarowToObject(Of T)(ByVal dr As DataRow) As T
        Try

            If dr Is Nothing Then
                Return (Nothing)
            End If

            Dim instance As T = Activator.CreateInstance(Of T)()

            FillObject(instance, dr)

            'Dim properties() As Reflection.PropertyInfo = instance.GetType().GetProperties()

            'If (properties.Length > 0) Then
            '    For Each propertyObject As Reflection.PropertyInfo In properties

            '        Dim valueSet As Boolean = False

            '        For Each attributeObject As Object In propertyObject.GetCustomAttributes(False)

            '            If attributeObject.GetType() Is GetType(MapperColumn) Then
            '                Dim columnAttributeObject As MapperColumn = CType(attributeObject, MapperColumn)

            '                If (columnAttributeObject.ColumnName <> String.Empty) Then

            '                    If dr.Table.Columns.Contains(columnAttributeObject.ColumnName) AndAlso Not dr(columnAttributeObject.ColumnName) Is DBNull.Value Then
            '                        If dr(columnAttributeObject.ColumnName).GetType.Name = "DateTime" And propertyObject.PropertyType.Name = "String" Then
            '                            propertyObject.SetValue(instance, Format(dr(columnAttributeObject.ColumnName), "dd-MM-yyyy"), Nothing)
            '                        ElseIf columnAttributeObject.DBType = SqlDbType.NVarChar Then
            '                            propertyObject.SetValue(instance, dr(columnAttributeObject.ColumnName).ToString.Trim, Nothing)
            '                        Else
            '                            propertyObject.SetValue(instance, dr(columnAttributeObject.ColumnName), Nothing)
            '                        End If
            '                        ' propertyObject.SetValue(instance, dr(columnAttributeObject.ColumnName), Nothing)
            '                        valueSet = True

            '                    End If

            '                End If
            '            End If
            '        Next

            '        If Not valueSet Then
            '            If dr.Table.Columns.Contains(propertyObject.Name) AndAlso Not dr(propertyObject.Name) Is DBNull.Value Then
            '                propertyObject.SetValue(instance, dr(propertyObject.Name), Nothing)
            '            End If
            '        End If

            '    Next
            'End If

            Return (instance)
        Catch ex As Exception
            Throw (ex)
        End Try
    End Function

    Public Function MapDataTableToList(Of T)(ByVal dt As DataTable) As IList(Of T)
        If dt Is Nothing Then
            Return (Nothing)
        End If

        Dim list As IList(Of T) = New List(Of T)

        For Each dr As DataRow In dt.Rows
            list.Add(MapDatarowToObject(Of T)(dr))
        Next

        Return (list)
    End Function
    Public Function MapDataTableToListObject(Of T)(ByVal list As List(Of T), ByVal dt As DataTable) As List(Of T)
        If dt Is Nothing Then
            Return (Nothing)
        End If

        For Each dr As DataRow In dt.Rows
            list.Add(MapDatarowToObject(Of T)(dr))
        Next

        Return (list)
    End Function


End Class

<AttributeUsage(AttributeTargets.Property)> _
Public Class MapperColumn
    Inherits Attribute

    Private mColumnName As String
    Private mDBType As SqlDbType

    Public Sub New(ByVal columnName As String, Optional ByVal dbtype As SqlDbType = SqlDbType.VarChar)
        mColumnName = columnName
        mDBType = dbtype
    End Sub

    Public Property ColumnName() As String
        Get
            Return (mColumnName)
        End Get
        Set(ByVal value As String)
            mColumnName = value
        End Set
    End Property

    Public ReadOnly Property DBType() As SqlDbType
        Get
            Return mDBType
        End Get
    End Property

End Class
<AttributeUsage(AttributeTargets.Property)> _
Public Class MapperExport
    Inherits Attribute

    Private mColumnName As String

    Public Sub New(ByVal columnName As String)
        mColumnName = columnName
    End Sub

    Public Property ColumnName() As String
        Get
            Return (mColumnName)
        End Get
        Set(ByVal value As String)
            mColumnName = value
        End Set
    End Property
End Class
<AttributeUsage(AttributeTargets.Class)> _
Public Class MapperTable
    Inherits Attribute

    Private _TableName As String
    Private _PrimaryKeyName As String

    Public ReadOnly Property TableName() As String
        Get
            Return _TableName
        End Get
    End Property

    Public ReadOnly Property PrimaryKeyName() As String
        Get
            Return _PrimaryKeyName
        End Get
    End Property

    Public Sub New(ByVal tableName As String, ByVal primaryKeyName As String)
        _TableName = tableName
        _PrimaryKeyName = primaryKeyName
    End Sub
End Class


