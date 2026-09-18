Imports System.Data.SqlClient
Imports System.Reflection

Public Class Relaties
    Inherits tblRelaties
    Implements IComparable
    Private da As New DataAccess
    Private URights As UserRights = UserRights.Instance

    Enum Via
        ID
        LIDNR
    End Enum

    Public Sub New()

    End Sub

    Public Sub New(ByVal id As String, ByVal Via As Via)

        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf Via.ToString = "LIDNR" Then
            ohelper.FillObject(Me, GetByLidNr(id))
        End If

    End Sub
    Public Function ShallowCopy() As Relaties
        Return DirectCast(Me.MemberwiseClone(), Relaties)
    End Function
    Public Function IsChanged(ByVal obj As Object) As Boolean
        IsChanged = False
        Dim props() As PropertyInfo = Me.GetType().GetProperties()
        Dim pi As System.Reflection.PropertyInfo = Nothing
        For Each prop As PropertyInfo In props
            If prop.CanRead Then
                For Each attributeObject As Object In prop.GetCustomAttributes(False)
                    If attributeObject.GetType() Is GetType(MapperColumn) Then
                        pi = obj.GetType().GetProperty(prop.Name)
                        If (prop.GetValue(Me, Nothing)) = pi.GetValue(obj, Nothing) Then
                            ' Dim s As String = prop.GetValue(Me, Nothing) & "  - " & pi.GetValue(obj, Nothing)
                        Else
                            Return True
                            ' Dim s As String = prop.Name & "gewijzigd: " & prop.GetValue(Me, Nothing) & "  in  " & pi.GetValue(obj, Nothing)
                            ' Throw New Exception(s)
                        End If
                    End If
                Next
            End If
        Next

        Return IsChanged

    End Function
    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo

        '    Dim props() As PropertyInfo = Me.GetType().GetProperties()
        '    Dim pi As System.Reflection.PropertyInfo = Nothing
        '    For Each prop As PropertyInfo In props
        '        If prop.CanRead Then
        '            For Each attributeObject As Object In prop.GetCustomAttributes(False)
        '                If attributeObject.GetType() Is GetType(MapperColumn) Then
        '                    pi = obj.GetType().GetProperty(prop.Name)
        '                    If (prop.GetValue(Me, Nothing)) = pi.GetValue(obj, Nothing) Then
        '                        ' Dim s As String = prop.GetValue(Me, Nothing) & "  - " & pi.GetValue(obj, Nothing)
        '                    Else
        '                        ' Dim s As String = prop.Name & "gewijzigd: " & prop.GetValue(Me, Nothing) & "  in  " & pi.GetValue(obj, Nothing)
        '                        ' Throw New Exception(s)
        '                    End If
        '                End If
        '            Next
        '        End If
        '    Next
    End Function
    Public Function GetById(ByVal id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Relaties where id = @id"
            Dim param() As Object = {"@id", id.ToString}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr Is Nothing Then
                Found = False
            Else
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function
    Public Function GetByLidNr(ByVal lidnr As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM Relaties where lidnr = @lidnr"
            Dim param() As Object = {"@lidnr", lidnr}
            oDr = da.ExecuteDataRow(sql, param)

            If Not oDr Is Nothing Then
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function
    'Public Function GetByRegNr(ByVal lidnr As String) As Data.DataRow
    '    Dim oDr As Data.DataRow
    '    Try
    '        Dim sql As String = "SELECT * FROM Relaties where rnr = @lidnr"
    '        Dim param() As Object = {"@lidnr", lidnr}
    '        oDr = da.ExecuteDataRow(sql, param)

    '        If Not oDr Is Nothing Then
    '            Found = True
    '        End If

    '        Return oDr
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        oDr = Nothing
    '    End Try
    'End Function
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

    Public Function TimeStampChanged() As Boolean
        Dim lastTimeStamp As DateTime
        Dim param() As Object = {"@id", Id}
        If Not IsDBNull(da.ExecuteScalar("SELECT LastChangeDate FROM Relaties where Id = @id", param)) Then
            lastTimeStamp = da.ExecuteScalar("SELECT LastChangeDate FROM Relaties where Id = @id", param)
        End If
         If Me.LastChangeDate.ToString("yyyyMMddHHmmss") = lastTimeStamp.ToString("yyyyMMddHHmmss") Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub Save()
        Try
            'Dim da As New DataAccess

            _lastUpdate = Nothing
            If postcode.Length = 6 Then
                postcode = postcode.Replace(" ", "")
                postcode = postcode.Insert(4, " ")
            End If

            If Me.Id = Nothing Then
                Me.LastChangeDate = Now
                Id = da.InsertString(Me, "Relaties", "Id", True)
                Dim myHistory As New History
                myHistory.LidId = Id
                myHistory.TableName = "Relaties"
                myHistory.Veld = "Nieuw Relatie"
                myHistory.WaardeOud = ""
                myHistory.WaardeNieuw = "lidnr:" & lidnr
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                myHistory.Save()
            Else
                da.isChanged(Me, "Relaties", "Id", Id, Id)
                Me.LastChangeDate = Now
                da.UpdateString(Me, "Relaties", "Id")

            End If


            'If myLid_contributie IsNot Nothing Then
            '    _myLid_contributie.Save()
            'End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub SaveByNSK(Optional ByVal ByWhat As String = "NSK")
        Try
            Dim da As New DataAccess

            _lastUpdate = Nothing
            Me.LastChangeDate = Now

            If Me.Id = Nothing Then
                Id = da.InsertString(Me, "Relaties", "Id", True)
                Dim myHistory As New History
                myHistory.LidId = Id
                myHistory.TableName = "Relaties"
                myHistory.Veld = "Nieuw Relatie"
                myHistory.WaardeOud = ""
                myHistory.WaardeNieuw = "lidnr:" & lidnr
                myHistory.MutDate = Now
                myHistory.MutDoor = ByWhat
                myHistory.Save()
            Else
                da.isChanged(Me, "Relaties", "Id", Id, Id)
                da.UpdateString(Me, "Relaties", "Id")
                'End If
            End If


        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "Relaties")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private _Found As Boolean = False
    Public Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property
    Private _InitName As String = ""
    Public ReadOnly Property InitName() As String
        Get
            _InitName = achternaam
            If Not String.IsNullOrEmpty(tussenvoegsel) Then _InitName = tussenvoegsel & " " & _InitName
            If Not String.IsNullOrEmpty(init) Then _InitName = init & " " & _InitName

            Return _InitName
        End Get
    End Property
    Private _FullName As String = ""
    Public Property FullName() As String
        Get
            _FullName = achternaam
            If Not String.IsNullOrEmpty(tussenvoegsel) Then _FullName = tussenvoegsel & " " & _FullName
            If Not String.IsNullOrEmpty(init) Then _FullName = init & " " & _FullName

            Select Case geslacht.ToUpper
                Case "MAN"
                    _FullName = "Dhr. " & _FullName
                Case "VROUW"
                    _FullName = "Mvr. " & _FullName
                Case "ONBEKEND"
                    '_FullName = _FullName
            End Select

            Return _FullName
        End Get
        Set(ByVal value As String)
            _FullName = value
        End Set
    End Property
    Private _FullAddress As String
    Public Property FullAddress() As String
        Get
            _FullAddress = adres
            _FullAddress = _FullAddress & " " & huisnr
            If Not String.IsNullOrEmpty(huisnrtv) Then _FullAddress = _FullAddress & " " & huisnrtv
            Return _FullAddress
        End Get
        Set(ByVal value As String)
            _FullAddress = value
        End Set
    End Property
    ' LidFunctie
    Public _LidFuncties As List(Of LidFunctie)
    Public ReadOnly Property LidFuncties() As List(Of LidFunctie)
        Get
            If Me.Id = 0 Then Throw New Exception("De relatie heeft nog geen id nummer gekregen.")

            If _LidFuncties Is Nothing Then
                _LidFuncties = New List(Of LidFunctie)
                Dim _LidFunctie As New LidFunctie
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM functies WHERE lidId = @lidId ORDER BY datumin DESC"
                Dim param() As Object = {"@lidId", Id}
                _LidFuncties = ohelper.MapDataTableToList(Of LidFunctie)(_LidFunctie.GetList(sql, param))
            End If
            Return _LidFuncties
        End Get
    End Property

    Public _LidSoortPerioden As List(Of LidSoortPeriode)
    Public ReadOnly Property LidSoortPerioden() As List(Of LidSoortPeriode)
        Get
            If Me.Id = 0 Then Throw New Exception("De relatie heeft nog geen id nummer gekregen.")

            If _LidSoortPerioden Is Nothing Then
                _LidSoortPerioden = New List(Of LidSoortPeriode)
                Dim _LidSoortPeriode As New LidSoortPeriode
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM LidSoortPerioden WHERE lidId = @lidId ORDER BY datumin DESC"
                Dim param() As Object = {"@lidId", Id}
                _LidSoortPerioden = ohelper.MapDataTableToList(Of LidSoortPeriode)(_LidSoortPeriode.GetList(sql, param))
            End If
            Return _LidSoortPerioden
        End Get
    End Property

    Public _myContributies As List(Of Contributies)
    Public ReadOnly Property myContributies() As List(Of Contributies)
        Get
            If Me.Id = 0 Then Throw New Exception("De relatie heeft nog geen id nummer gekregen.")
            ' voortaan altijd een verse lijst ophalen.
            ' If _myContributies Is Nothing Then
            _myContributies = New List(Of Contributies)
            Dim _Contributies As New Contributies
            Dim ohelper As New Helper
            Dim sql As String = "SELECT * FROM Contributies WHERE lidId = @lidId ORDER BY jaar DESC"
            Dim param() As Object = {"@lidId", Id}
            _myContributies = ohelper.MapDataTableToList(Of Contributies)(_Contributies.GetList(sql, param))
            ' End If
            Return _myContributies
        End Get
    End Property
    Public _CurrentPeriode As LidSoortPeriode
    Public Property CurrentPeriode() As LidSoortPeriode
        Get
            If _CurrentPeriode Is Nothing Then
                _CurrentPeriode = New LidSoortPeriode(Id, Today)
            End If
            Return _CurrentPeriode
        End Get
        Set(ByVal value As LidSoortPeriode)
            _CurrentPeriode = value
        End Set
    End Property

    Public Function SelectedPeriode(ByVal periodedate As Date) As LidSoortPeriode
        Dim _SelectedPeriode As LidSoortPeriode
        _SelectedPeriode = New LidSoortPeriode(Id, periodedate)

        Return _SelectedPeriode
    End Function
    Private _lastUpdate As History
    Public ReadOnly Property lastUpdate() As History
        Get
            If _lastUpdate Is Nothing Then
                If Me.Id = 0 Then
                    _lastUpdate = New History
                    _lastUpdate.MutDate = Now
                Else
                    _lastUpdate = New History(Me.Id, History.Via.LASTMUT)
                End If

            End If

            Return _lastUpdate
        End Get
    End Property

    Public ReadOnly Property MutDate() As DateTime
        Get
            Return lastUpdate.MutDate
        End Get
    End Property
    Public ReadOnly Property MutDoor() As String
        Get
            Return lastUpdate.MutDoor
        End Get
    End Property
    Public Function ExportRow() As DataRow
        Dim da As New DataAccess
        Dim sql As String
        sql = "SELECT * , '' as AanmaakDatum , '' as DocNaam FROM relaties  " & _
                "WHERE lidnr = @lidnr"
        Dim param() As Object = {"@lidnr", lidnr}
        Dim dr As DataRow = da.ExecuteDataRow(sql, param)
        dr.Item("AanmaakDatum") = Format(Now, "dd MMMM yyyy")

        If dr.Table.Columns.Contains("Notities") Then
            dr.Table.Columns.Remove("Notities")
        End If

        'bugid: 1147: Als iemand een ; in zijn wachtwoord zet werkt de mailmerge niet meer.
        '        wachtwoord Is nergens nodig voor export, dus beter te verwijderen.
        If dr.Table.Columns.Contains("wachtwoord") Then
            dr.Table.Columns.Remove("wachtwoord")
        End If


        Return dr
    End Function

    Private _Age As Double = 0
    Public ReadOnly Property Age() As Double
        Get

            If Not String.IsNullOrEmpty(geboortedatum) Then
                Dim DOB As Date = CDate(geboortedatum)
                If eindereden = 5 And Not String.IsNullOrEmpty(eindedatum) Then
                    Dim RIP As Date = CDate(eindedatum)
                    _Age = DateDiff("yyyy", DOB, RIP) + (RIP < DateSerial(Year(RIP), Month(DOB), Day(DOB)))
                Else
                    _Age = DateDiff("yyyy", DOB, DateTime.Now) + (DateTime.Now < DateSerial(Year(DateTime.Now), Month(DOB), Day(DOB)))
                End If
            End If

            Return _Age
        End Get
    End Property
    Private _myStorneringen As Storneringen
    Public Property myStorneringen() As Storneringen
        Get
            If _myStorneringen Is Nothing Then
                _myStorneringen = New Storneringen(Id)
            End If
            Return _myStorneringen
        End Get
        Set(ByVal value As Storneringen)
            _myStorneringen = value
        End Set
    End Property
    Private _AfdelingNaam As String
    Public ReadOnly Property AfdelingNaam() As String
        Get
            If _AfdelingNaam Is Nothing Then
                Dim param() As Object = {"@Id", afdeling}
                _AfdelingNaam = da.ExecuteScalar("SELECT left(CAST(id as varchar) + SPACE(5),5) + ' | ' + omschrijving as id_omsch  FROM Afdelingen where Id = @id", param)
            End If
            Return _AfdelingNaam
        End Get
    End Property
    Private _KrijgsmachtNaam As String
    Public ReadOnly Property KrijgsmachtNaam() As String
        Get
            If _KrijgsmachtNaam Is Nothing Then
                Dim param() As Object = {"@Id", kmond}
                _KrijgsmachtNaam = da.ExecuteScalar("SELECT left(CAST(id as varchar) + SPACE(5),5) + ' | ' + kmonderdeel as id_omsch FROM kmonderdelen where Id = @id", param)
            End If
            Return _KrijgsmachtNaam
        End Get
    End Property
    Private _DienstVakNaam As String
    Public ReadOnly Property DienstVakNaam() As String
        Get
            If _DienstVakNaam Is Nothing Then
                Dim param() As Object = {"@Id", dienstvak}
                _DienstVakNaam = da.ExecuteScalar("SELECT left(CAST(dienstvak as varchar) + SPACE(5),5) + ' | ' + omschrijving as id_omsch FROM Dienstvakken where id = @id", param)
            End If
            Return _DienstVakNaam
        End Get
    End Property
    Private _DienstVakNaamKort As String
    Public ReadOnly Property DienstVakNaamKort() As String
        Get
            If _DienstVakNaamKort Is Nothing Then
                Dim param() As Object = {"@Id", dienstvak}
                _DienstVakNaamKort = da.ExecuteScalar("SELECT omschrijving FROM Dienstvakken where id = @id", param)
            End If
            Return _DienstVakNaamKort
        End Get
    End Property
    Private _PlaatsingNaam As String
    Public ReadOnly Property PlaatsingNaam() As String
        Get
            If _PlaatsingNaam Is Nothing Then
                Dim param() As Object = {"@P_Id", plaatsing}
                _PlaatsingNaam = da.ExecuteScalar("SELECT left(CAST(code as varchar) + SPACE(5),5) + ' | ' + Plaatsing as code_plaatsing FROM Plaatsingen where P_Id = @P_Id", param)
            End If
            Return _PlaatsingNaam
        End Get
    End Property
    Private _RangNaam As String
    Public ReadOnly Property RangNaam() As String
        Get
            If _RangNaam Is Nothing Then
                Dim param() As Object = {"@Id", rang}
                _RangNaam = da.ExecuteScalar("SELECT left(CAST(id as varchar) + SPACE(5),5) + ' | ' + rang as id_omsch FROM Rangen where id = @id", param)
            End If
            Return _RangNaam
        End Get
    End Property
    Private _RangNaamOnly As String = String.Empty
    Public ReadOnly Property RangNaamOnly() As String
        Get
            If String.IsNullOrEmpty(_RangNaamOnly) Then
                Dim param() As Object = {"@Id", rang}
                _RangNaamOnly = da.ExecuteScalar("SELECT rang FROM Rangen where id = @id", param)

                If _RangNaamOnly = "ONBEKEND" Or String.IsNullOrEmpty(_RangNaamOnly) Then
                    _RangNaamOnly = String.Empty
                ElseIf _RangNaamOnly.ToUpper.Contains("SCHAAL") Then
                    _RangNaamOnly = String.Empty
                End If

            End If
            Return _RangNaamOnly
        End Get
    End Property
    Private _MyRang As Rangen
    Public ReadOnly Property MyRang() As Rangen
        Get
            If _MyRang Is Nothing Then
                _MyRang = New Rangen(Me.rang, Rangen.Via.ID)
            End If
            Return _MyRang
        End Get
    End Property

    Private _myNazorg As Nazorg
    Public ReadOnly Property myNazorg() As Nazorg
        Get
            _myNazorg = New Nazorg(Id, BusinessObjects.Nazorg.Via.LIDID)
            Return _myNazorg
        End Get
    End Property


    Public _Helpdesk As Helpdesk
    Public Property Helpdesk() As Helpdesk
        Get
            If _Helpdesk Is Nothing Then
                Dim sql As String = "SELECT * FROM Helpdesk where LidId = @LidId"
                Dim param() As Object = {"@LidId", Id}
                _Helpdesk = New Helpdesk(Id, BusinessObjects.Helpdesk.VIA.LIDID)
            End If
            Return _Helpdesk
        End Get
        Set(ByVal value As Helpdesk)
            _Helpdesk = value
        End Set
    End Property

    Public Function EmailBerichten() As List(Of Berichten)
        Try
            'bmo:1510: bij maken van nieuwe relatie laat het alle mail berichten zien op tabblad helpdesk. 
            'als er geen relatieid is dan een lege list geven
            If Id = 0 Then Return New List(Of Berichten)

            Dim ohelper As New Helper
            Dim sql As String = "SELECT * FROM Berichten where RelatieId = @RelatieId"
            Dim param() As Object = {"@RelatieId", Id}

            EmailBerichten = ohelper.MapDataTableToList(Of Berichten)(GetList(sql, param))

            Return EmailBerichten
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Private _MyIBBdossiers As List(Of IBBDossier)
    Public ReadOnly Property MyIBBdossiers As List(Of IBBDossier)
        Get

            If _MyIBBdossiers Is Nothing Then
                _MyIBBdossiers = New List(Of IBBDossier)
                Dim _dossier As New IBBDossier
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM IBBDossiers where LidId = @lidId"
                Dim params As New ArrayList
                params.Add("@lidId")
                params.Add(Me.Id)
                _MyIBBdossiers = ohelper.MapDataTableToList(Of IBBDossier)(_dossier.GetList(sql, params.ToArray))
            End If

            Return _MyIBBdossiers
        End Get
    End Property
    Public Function HasOpenDossiers() As Boolean
        Dim result As Boolean = False
        For Each dos As IBBDossier In MyIBBdossiers
            If dos.Afgehandeld = False Then
                result = True
                Exit For
            End If
        Next
        Return result
    End Function
    Public Function ListOpenDossiers() As List(Of String)
        Dim result As New List(Of String)
        For Each dos As IBBDossier In MyIBBdossiers
            If dos.Afgehandeld = False Then
                result.Add("Dossier: " & dos.DossierNr & ", behandelaar: " & dos.myBehandelaar.Naam)
            End If
        Next
        Return result
    End Function

    Private _MyCorrespondentieList As List(Of Documents)
    Public ReadOnly Property CorrespondentieList As List(Of Documents)
        Get

            If _MyCorrespondentieList Is Nothing Then
                _MyCorrespondentieList = New List(Of Documents)
                Dim _dossier As New IBBDossier
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM Documents WHERE lidId = @lidid AND (BerichtenId is NULL or BerichtenId = 0) ORDER BY CreateDate DESC"
                Dim params As New ArrayList
                params.Add("@lidId")
                params.Add(Me.Id)
                _MyCorrespondentieList = ohelper.MapDataTableToList(Of Documents)(_dossier.GetList(sql, params.ToArray))
            End If

            Return _MyCorrespondentieList
        End Get
    End Property

    Public _MyVerzekeringen As List(Of Verzekering)
    Public ReadOnly Property MyVerzekeringen() As List(Of Verzekering)
        Get
            'If Me.Id = 0 Then Exit 'Throw New Exception("De relatie heeft nog geen id nummer gekregen.")

            If _MyVerzekeringen Is Nothing Then
                _MyVerzekeringen = New List(Of Verzekering)
                Dim _MyVerzekering As New Verzekering
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM Verzekeringen WHERE lidId = @lidId ORDER BY id DESC"
                Dim param() As Object = {"@lidId", Id}
                _MyVerzekeringen = ohelper.MapDataTableToList(Of Verzekering)(_MyVerzekering.GetList(sql, param))
            End If
            Return _MyVerzekeringen
        End Get
    End Property
End Class
