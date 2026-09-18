
Imports System.Web.UI.WebControls.WebParts

Public Class Boeking
    Inherits tblBoekingen

    Private da As New DataAccess

    Enum Via
        ID
        'LIDNR
        RELID
        BLOKID
    End Enum
    Public Sub New()

    End Sub

    Public Sub New(ByVal id As String, ByVal Via As Via)
        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
            'ElseIf Via.ToString = "LIDNR" Then
            '      ohelper.FillObject(Me, GetByLIDNR(id))
        ElseIf Via.ToString = "RELID" Then
            ohelper.FillObject(Me, GetByRELID(id))
        ElseIf Via.ToString = "BLOKID" Then
            ohelper.FillObject(Me, GetByBLOKID(id))
        End If
    End Sub

    Public Function GetById(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM boekingen where id = @id ORDER BY tijdstip"
            Dim param() As Object = {"@id", GetId}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr Is Nothing Then
                Found = False
            Else
                Dim ohelper As New Helper
                ohelper.FillObject(Me, oDr)
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function
    'Public Function GetByLIDNR(ByVal GetId As String) As Data.DataRow
    '    Dim oDr As Data.DataRow
    '    Try
    '        Dim sql As String = "SELECT * FROM boekingen where lidnr = @LIDNR ORDER BY tijdstip"
    '        Dim param() As Object = {"@LIDNR", GetId}
    '        oDr = da.ExecuteDataRow(sql, param)

    '        If oDr Is Nothing Then
    '            Found = False
    '        Else
    '            Dim ohelper As New Helper
    '            ohelper.FillObject(Me, oDr)
    '            Found = True
    '        End If

    '        Return oDr
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        oDr = Nothing
    '    End Try
    'End Function
    Public Function GetByRELID(ByVal GetId As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM boekingen where relatieId = @LIDNR ORDER BY tijdstip"
            Dim param() As Object = {"@LIDNR", GetId}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr Is Nothing Then
                Found = False
            Else
                Dim ohelper As New Helper
                ohelper.FillObject(Me, oDr)
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function
    Public Function GetByBLOKID(ByVal GetId As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM boekingen where BlokId = @BLOKID ORDER BY tijdstip"
            Dim param() As Object = {"@BLOKID", GetId}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr Is Nothing Then
                Found = False
            Else
                Dim ohelper As New Helper
                ohelper.FillObject(Me, oDr)
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function
    Public Function GetList(ByVal sql As String, Optional ByVal parameters() As Object = Nothing) As Data.DataTable
        Dim oDS As Data.DataSet
        Try
            oDS = da.ExecuteDataset(sql, parameters)
            Return oDS.Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            oDS = Nothing
        End Try
    End Function
    Public Function GetBoekingByVM()
        Dim oDr As Data.DataRow
        Dim ohelper As New Helper
        Dim sql As String = "select top 1 b1.* from boekingen b1 inner join blokken b2 on b1.blokid = b2.id inner join BlokTypes b3 on b2.bloktypeid = b3.Id and b1.relatieid=0  and b3.Ismachtiging=1 order by b1.tijdstip"
        Try
            oDr = da.ExecuteDataRow(sql)
            ohelper.FillObject(Me, oDr)

        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function

    Private _Found As Boolean = False
    Public Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property

    Private _lidnr As String = "0"
    Public Property lidnr() As String
        Get

            If da.Settings.SettingEnvironment = enSettingEnviroment.Web Then
                If Not MyWebRelatie Is Nothing Then
                    _lidnr = MyWebRelatie.lidnr
                End If
            Else
                If Not MyRelatie Is Nothing Then
                    _lidnr = MyRelatie.lidnr
                End If
            End If

                Return _lidnr
        End Get
        Set(ByVal value As String)
            _lidnr = value
        End Set
    End Property



    Private _DummyValue As String
    Public ReadOnly Property DummyValue() As String
        Get
            If _DummyValue Is Nothing Then
                Dim sys As New Systeeminstellingen("DummyNr", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)
                _DummyValue = sys.Waarde
            End If

            Return _DummyValue
        End Get
    End Property

    Public Sub Save()
        Try
            If String.IsNullOrEmpty(LidNaam) And lidnr <> "0" Then Throw New Exception("Lidmaatschap nummer bestaat niet!")
            'If lidnr = 0 Then Throw New Exception("Lidmaatschap nummer niet ontvangen!")
            If Not String.IsNullOrEmpty(IfExistLidBoeking) Then Throw New Exception(IfExistLidBoeking)

            If Me.Id = Nothing Then
                Id = da.InsertString(Me, "boekingen", "Id", True)
            Else
                da.UpdateString(Me, "boekingen", "Id")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "boekingen")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function IfExistLidBoeking() As String
        Try
            If relatieId <> 0 And lidnr <> DummyValue Then

                Dim tryBoeking As New Boeking(relatieId, Boeking.Via.RELID)
                If tryBoeking.Found Then
                    If tryBoeking.tijdstip <> tijdstip Then
                        Dim _message As String = ""
                        Dim MyLocatie As New Locaties(tryBoeking.Blok.locatieid)
                        If MyLocatie.Offline = True Then
                            Return tryBoeking.LidNaam & " heeft al aangegeven vbm de aangifte te laten verzorgen. "
                        Else

                            Return tryBoeking.LidNaam & " heeft al een boeking op " &
                                                    tryBoeking.tijdstip.ToLongDateString & " om " &
                                                    tryBoeking.tijdstip.ToLongTimeString & " in " & tryBoeking.Blok.LocatieNaam
                        End If

                        Return _message
                    End If
                    tryBoeking = Nothing
                End If
            End If

            Return String.Empty

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private _Blok As Blok
    Public ReadOnly Property Blok() As Blok
        Get
            If _Blok Is Nothing Then
                _Blok = New Blok(Me.blokId, BusinessObjects.Blok.Via.ID)
            End If
            Return _Blok
        End Get
    End Property

    'Private _LocatieNaam As String = ""
    'Public ReadOnly Property LocatieNaam() As String
    '    Get
    '        If String.IsNullOrEmpty(_LocatieNaam) Then
    '            Dim _BlokLocatie As New Locaties(locatieId)
    '            _LocatieNaam = _BlokLocatie.Locatie
    '            _BlokLocatie = Nothing
    '        End If
    '        Return _LocatieNaam
    '    End Get
    'End Property
    Private _LidNaam As String
    Public ReadOnly Property LidNaam() As String
        Get
            If String.IsNullOrEmpty(_LidNaam) And relatieId > 0 Then

                If da.Settings.SettingEnvironment = enSettingEnviroment.Web Then
                    If Not MyWebRelatie Is Nothing Then
                        _LidNaam = MyWebRelatie.FullName
                    End If
                Else
                    If Not MyRelatie Is Nothing Then
                        _LidNaam = MyRelatie.FullName
                    End If
                End If

            End If
            Return _LidNaam
        End Get
    End Property

    Private _MyRelatie As Lidmaat
    Public ReadOnly Property MyRelatie() As Lidmaat
        Get
            If _MyRelatie Is Nothing Then
                _MyRelatie = New Lidmaat(relatieId, Lidmaat.Via.ID)
            End If
            Return _MyRelatie
        End Get
    End Property

    Private _MyWebRelatie As WebLid
    Public ReadOnly Property MyWebRelatie() As WebLid
        Get
            If _MyWebRelatie Is Nothing Then
                _MyWebRelatie = New WebLid(relatieId, WebLid.Via.ID)
            End If
            Return _MyWebRelatie
        End Get
    End Property
End Class
