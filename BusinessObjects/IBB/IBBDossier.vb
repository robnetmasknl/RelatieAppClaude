Imports System.Security.AccessControl
Public Class IBBDossier
    Inherits tblIBBDossiers
    Private da As New DataAccess
    Private URights As UserRights = UserRights.Instance

    'Public List As IBBDossierList
    Enum VIA
        ID
        DOSSIERNR
    End Enum
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String, ByVal via As VIA)
        Dim ohelper As New Helper
        If via = IBBDossier.VIA.ID Then
            ohelper.FillObject(Me, GetById(id))
        ElseIf via = IBBDossier.VIA.DOSSIERNR Then
            ohelper.FillObject(Me, GetByDossierNr(id))
        End If

    End Sub

    Public Function GetById(ByVal Id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM IBBDossiers where id = @id"
            Dim param() As Object = {"@id", Id}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr IsNot Nothing Then
                Found = True
            End If

            Return oDr
        Catch ex As Exception
            Throw ex
        Finally
            oDr = Nothing
        End Try
    End Function

    Public Function GetByDossierNr(ByVal Id As String) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM IBBDossiers where dossiernr = @dossiernr"
            Dim param() As Object = {"@dossiernr", Id}
            oDr = da.ExecuteDataRow(sql, param)

            If oDr IsNot Nothing Then
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
    Private _Found As Boolean = False
    Public Property Found() As Boolean
        Get
            Return _Found
        End Get
        Set(ByVal value As Boolean)
            _Found = value
        End Set
    End Property

    'Public Function ListGriffieKosten() As List(Of IBBGriffieKosten)
    '    Try

    '        Dim ohelper As New Helper
    '        Dim sql As String = "SELECT * FROM IBBGriffieKosten where DossierId = @DossierId"
    '        Dim param() As Object = {"@DossierId", Id}
    '        ListGriffieKosten = ohelper.MapDataTableToList(Of IBBGriffieKosten)(GetList(sql, param))

    '        Return ListGriffieKosten
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Private _ListDocuments As List(Of IBBDocument)
    Public ReadOnly Property ListDocuments(Optional ByVal jdTypeId As Integer = 0, Optional ByVal bRenew As Boolean = False) As List(Of IBBDocument)
        '
        Get
            If bRenew = True Then _ListDocuments = Nothing

            If _ListDocuments Is Nothing Then
                _ListDocuments = New List(Of IBBDocument)
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM IBBDocuments where DossierId = @DossierId And Concept = 0 And (Locationtype <> 'Extern' or Locationtype is NULL)"
                Dim params As New ArrayList
                params.Add("@DossierId")
                params.Add(Id)
                'params.Add("@Concept")
                'params.Add(True)
                If jdTypeId > 0 Then
                    sql &= "AND jdTypeId = @jdTypeId"
                    params.Add("@jdTypeId")
                    params.Add(jdTypeId)
                End If

                _ListDocuments = ohelper.MapDataTableToList(Of IBBDocument)(GetList(sql, params.ToArray))
            End If

            Return _ListDocuments
        End Get
    End Property

    Private _ListDocumentsSearch As List(Of IBBDocument)
    Public ReadOnly Property ListDocumentsSearch(ByVal SearchValue As String, Optional ByVal bRenew As Boolean = False) As List(Of IBBDocument)
        '
        Get
            If bRenew = True Then _ListDocumentsSearch = Nothing

            If _ListDocumentsSearch Is Nothing Then
                _ListDocumentsSearch = New List(Of IBBDocument)
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM IBBDocuments inner join Berichten On IBBDocuments.BerichtenId = Berichten.id where IBBDocuments.DossierId = @DossierId And Concept = 0 And BodyText Like '%" & SearchValue & "%' And (Locationtype <> 'Extern' or Locationtype is NULL)"
                Dim params As New ArrayList
                params.Add("@DossierId")
                params.Add(Id)

                _ListDocumentsSearch = ohelper.MapDataTableToList(Of IBBDocument)(GetList(sql, params.ToArray))
            End If

            Return _ListDocumentsSearch
        End Get
    End Property

    Private _ews As EwsReader
    Public Property ews() As EwsReader
        Get
            If _ews Is Nothing Then
                _ews = New EwsReader(True)
            End If
            Return _ews
        End Get
        Set(ByVal value As EwsReader)
            _ews = value
        End Set
    End Property

    Private _ListEmails As List(Of IBBDocument)
    Public ReadOnly Property ListEmails(Optional ByVal jdTypeId As Integer = 0, Optional ByVal bRenew As Boolean = False) As List(Of IBBDocument)
        Get
            Try
                If bRenew = True Then _ListEmails = Nothing

                If _ListEmails Is Nothing Then
                    _ListEmails = New List(Of IBBDocument)
                    'zoek folderid dmv dossiernummer in foldernaam
                    'maak een lijst van de gevonden mail in die folder
                    'iets verzinnen voor opslag tijdelijke msg id voor openen mail
                    ews.completeListOfFolderIds = Nothing
                    ews.EwsFolder(Me.DossierNr)
                    Dim ibbMail As IBBDocument = Nothing

                    'Graph's mailFolders eindpunt geeft alleen echte mailfolders terug (geen search-/contacts-/tasks-/agendafolders
                    'zoals bij EWS' gemengde MsgFolderRoot-hierarchie), dus de vroegere type-check om die over te slaan is niet meer nodig.
                    For Each _folder As GraphMailFolder In ews.completeListOfFolderIds
                        ews.GetItems(_folder.Id)

                        For Each item As Berichten In ews.MailItems
                            ibbMail = New IBBDocument
                            With ibbMail
                                If String.IsNullOrEmpty(item.Subject) Then
                                    .Onderwerp = "geen onderwerp"
                                ElseIf item.Subject.Length > 99 Then
                                    .Onderwerp = item.Subject.Substring(0, 90)
                                Else
                                    .Onderwerp = item.Subject
                                End If
                                .CreateDate = item.ReceivedDate
                                .Location = "\" & item.FromName
                                .Template = "ewsmail"
                                .EmailId = item.Header
                                .EmailFolderId = _folder.Id
                                .Bericht.boCategory = item.boCategory
                                _ListEmails.Add(ibbMail)
                            End With
                        Next
                    Next

                End If
                Return _ListEmails
            Catch ex As Exception
                Throw ex
            End Try

            Return _ListEmails


        End Get
    End Property
    Private _ListDocumentsExt As List(Of IBBDocument)
    Public ReadOnly Property ListDocumentsExt(Optional ByVal jdTypeId As Integer = 0, Optional ByVal bRenew As Boolean = False) As List(Of IBBDocument)
        Get
            If bRenew = True Then _ListDocumentsExt = Nothing

            If _ListDocumentsExt Is Nothing Then
                _ListDocumentsExt = New List(Of IBBDocument)
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM IBBDocuments where DossierId = @DossierId And Locationtype = 'Extern'"
                Dim params As New ArrayList
                params.Add("@DossierId")
                params.Add(Id)

                _ListDocumentsExt = ohelper.MapDataTableToList(Of IBBDocument)(GetList(sql, params.ToArray))
            End If

            Return _ListDocumentsExt
        End Get
    End Property

    Private _ListGriffieKosten As List(Of IBBGriffieKosten)
    Public ReadOnly Property ListGriffieKosten(Optional ByVal bRenew As Boolean = False) As List(Of IBBGriffieKosten)
        Get
            If bRenew = True Then _ListGriffieKosten = Nothing
            If _ListGriffieKosten Is Nothing Then
                _ListGriffieKosten = New List(Of IBBGriffieKosten)
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM IBBGriffieKosten where DossierId = @DossierId"
                Dim param() As Object = {"@DossierId", Id}


                _ListGriffieKosten = ohelper.MapDataTableToList(Of IBBGriffieKosten)(GetList(sql, param))
            End If

            Return _ListGriffieKosten
        End Get
    End Property
    Private _ListProcessKosten As List(Of IBBProcessKosten)
    Public ReadOnly Property ListProcessKosten(Optional ByVal bRenew As Boolean = False) As List(Of IBBProcessKosten)
        Get
            If bRenew = True Then _ListProcessKosten = Nothing
            If _ListProcessKosten Is Nothing Then
                _ListProcessKosten = New List(Of IBBProcessKosten)
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM IBBProcessKosten where DossierId = @DossierId"
                Dim param() As Object = {"@DossierId", Id}
                _ListProcessKosten = ohelper.MapDataTableToList(Of IBBProcessKosten)(GetList(sql, param))
            End If

            Return _ListProcessKosten
        End Get
    End Property
    Private _ListExterneKosten As List(Of IBBExterneKosten)
    Public ReadOnly Property ListExterneKosten(Optional ByVal bRenew As Boolean = False) As List(Of IBBExterneKosten)
        Get
            If bRenew = True Then _ListExterneKosten = Nothing
            If _ListExterneKosten Is Nothing Then
                _ListExterneKosten = New List(Of IBBExterneKosten)
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM IBBExterneKosten where DossierId = @DossierId"
                Dim param() As Object = {"@DossierId", Id}
                _ListExterneKosten = ohelper.MapDataTableToList(Of IBBExterneKosten)(GetList(sql, param))
            End If

            Return _ListExterneKosten
        End Get
    End Property
    Private _ListIBBFases As List(Of IBBFase)
    Public ReadOnly Property ListIBBFases(Optional ByVal bRenew As Boolean = False) As List(Of IBBFase)
        Get
            If bRenew = True Then _ListIBBFases = Nothing
            If _ListIBBFases Is Nothing Then
                _ListIBBFases = New List(Of IBBFase)
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM IBBFases " & _
                                        "inner join jdTypes jd on IBBFases.TypeId = jd.Id " & _
                                        "where DossierId = @DossierId " & _
                                        "order by indiendatum, jd.seq "
                Dim param() As Object = {"@DossierId", Id}
                _ListIBBFases = ohelper.MapDataTableToList(Of IBBFase)(GetList(sql, param))
            End If

            Return _ListIBBFases
        End Get
    End Property
    Public Function EmailBerichten() As List(Of Berichten)
        Try
            Dim ohelper As New Helper
            Dim sql As String = "SELECT * FROM Berichten where DossierId = @DossierId"
            Dim param() As Object = {"@DossierId", Id}

            'EmailBerichten = New List(Of Berichten)
            EmailBerichten = ohelper.MapDataTableToList(Of Berichten)(GetList(sql, param))

            Return EmailBerichten
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private _MyRelatie As Relaties
    Public ReadOnly Property MyRelatie() As Relaties
        Get
            If _MyRelatie Is Nothing Then
                _MyRelatie = New Relaties(LidId, Relaties.Via.ID)
            End If
            Return _MyRelatie
        End Get
    End Property

    Public Sub Save()
        Try
            If LidId = 0 Then Throw New Exception("Het dossier heeft nog geen lidnummer")
            If String.IsNullOrEmpty(DossierNr) Then Throw New Exception("Het dossier heeft nog geen dossiernummer")
            If String.IsNullOrEmpty(Onderwerp) Then Throw New Exception("Het dossier heeft nog geen onderwerp")
            If MoederDossier <> "0" Then
                Dim checkMoederDossier As New IBBDossier(MoederDossier, IBBDossier.VIA.DOSSIERNR)
                If Not checkMoederDossier.Found Then
                    Throw New Exception("Moederdossiernr. " & MoederDossier & " is niet gevonden. Controleer uw invoer.")
                Else

                End If
            End If
            If Me.Id = Nothing Then
                Id = da.InsertString(Me, "IBBDossiers", "Id", True)
                da.UpdateMutDateDossier(Id)
                Dim myHistory As New History
                myHistory.LidId = Id
                myHistory.TableName = "IBBDossiers"
                myHistory.Veld = "Nieuw IBBDossier"
                myHistory.WaardeOud = ""
                myHistory.WaardeNieuw = "IBBDossier:" & Me.Id
                myHistory.MutDate = Now
                myHistory.MutDoor = URights.UserName
                myHistory.Save()
            Else
                If da.isChanged(Me, "IBBDossiers", "Id", Me.Id, Me.Id) Then
                    da.UpdateString(Me, "IBBDossiers", "Id")
                    da.UpdateMutDateDossier(Id)
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function ExportRow() As DataRow
        Dim da As New DataAccess
        Dim sql As String
        sql = "SELECT * FROM IBBDossiers  IBB " & _
                "INNER JOIN Relaties REL on IBB.lidid = REL.Id " & _
                "WHERE IBB.id = @id"
        Dim param() As Object = {"@id", Id}
        Return da.ExecuteDataRow(sql, param)
    End Function
    Public Sub Remove()
        Try
            'verwijder dan ook alle referenties

            'ibbgriffie kosten >> me.id = DossierId
            For Each griffie As IBBGriffieKosten In ListGriffieKosten()
                griffie.Remove()
            Next

            'agenda items?

            'ibb fases >> me.id = DossierId
            For Each fase As IBBFase In ListIBBFases()
                fase.Remove()
            Next

            'IBBDocuments >>me.id = DossierId
            Dim parameters As New List(Of Object)
            parameters.Add("DossierId")
            parameters.Add(Id)
            da.ExecuteNonQuery("DELETE FROM IBBDocuments WHERE DossierId = @DossierId", Nothing, parameters)

            Dim myHistory As New History
            myHistory.LidId = Me.LidId
            myHistory.TableName = "Dossiers"
            myHistory.Veld = "verwijderd IBBDossier"
            myHistory.WaardeOud = "IBBDossiernr:" & Me.DossierNr
            myHistory.WaardeNieuw = "IBBDossier:" & Me.Id
            myHistory.MutDate = Now
            myHistory.MutDoor = URights.UserName


            'en uiteindelijk het dossier zelf
            da.DeleteCommand(Me, "IBBDossiers", "Id")

            myHistory.Save()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function NewDossierNr() As String
        Try
            Dim result As String = String.Empty
            Dim da As New DataAccess
            Dim sql As String
            sql = "select max (CAST((RIGHT(DossierNr,len(DossierNr) - 4)) AS INT) ) AS maxnr " & _
                    "FROM IBBDossiers " & _
                    "WHERE LEFT(dossiernr,4) = @Year " & _
                    "order by maxnr"
            Dim param() As Object = {"@Year", Now.Year}
            Dim dr As DataRow = da.ExecuteDataRow(sql, param)
            Dim imax As Int32 = 0
            If Not IsDBNull(dr(0)) Then
                imax = dr(0)
            End If
            Dim smax As String = LI(imax + 1, 4)
            result = Now.Year & smax
            Return result
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private _Behandelaar As String = String.Empty
    Public ReadOnly Property Behandelaar() As String
        Get
            If String.IsNullOrEmpty(_Behandelaar) Then
                Dim Sql As String = "SELECT Naam FROM behandelaren WHERE Id = @Id"
                Dim param() As Object = {"@Id", Me.BehandelaarId}
                _Behandelaar = da.ExecuteScalar(Sql, param)
            End If
            Return _Behandelaar
        End Get
    End Property
    Private _BehandelaarExchangeAcc As String = String.Empty
    Public ReadOnly Property BehandelaarExchangeAcc() As String
        Get
            If String.IsNullOrEmpty(_BehandelaarExchangeAcc) Then
                Dim Sql As String = "SELECT ExchangeAccount FROM behandelaren WHERE Id = @Id"
                Dim param() As Object = {"@Id", Me.BehandelaarId}
                _BehandelaarExchangeAcc = da.ExecuteScalar(Sql, param).ToString
            End If
            Return _BehandelaarExchangeAcc
        End Get
    End Property
    Private _myBehandelaar As Behandelaar = Nothing
    Public ReadOnly Property myBehandelaar() As Behandelaar
        Get
            If _myBehandelaar Is Nothing Then
                _myBehandelaar = New Behandelaar(BehandelaarId, BusinessObjects.Behandelaar.Via.ID)
            End If
            Return _myBehandelaar
        End Get
    End Property
    Public Function CurrentFasesText() As String
        Try
            Dim sql As String = "SELECT jd.Description FROM IBBFases ibb " & _
                                "inner join jdTypes jd on jd.Id = TypeId  " & _
                                "where DossierId = @DossierId AND Besluit = @Besluit"
            Dim result As String = String.Empty
            Dim dt As DataTable
            Dim paramlist As New ArrayList
            paramlist.Add("@DossierId")
            paramlist.Add(Me.Id)
            paramlist.Add("@Besluit")
            paramlist.Add(0)
            dt = da.ExecuteDataTable(sql, paramlist.ToArray)
            If dt.Rows.Count = 0 Then
                'dan gewoon een lege
            Else
                For Each rw As DataRow In dt.Rows
                    result &= "," & rw.Item("Description")
                Next

                'Else
                '    Throw New Exception("Er staan meerdere fases in afwachting, corrigeer dit!!")
            End If
            Return result

            'Dim result As IBBFase
            'Dim AllClosed As Boolean = True
            'Dim dt As DataTable
            'Dim paramlist As New ArrayList
            'Dim sql As String = "SELECT * FROM IBBFases where DossierId = @DossierId AND Besluit = @Besluit"
            'paramlist.Add("@DossierId")
            'paramlist.Add(Me.Id)
            'paramlist.Add("@Besluit")
            'paramlist.Add(0)
            'dt = da.ExecuteDataTable(sql, paramlist.ToArray)
            'If dt.Rows.Count = 0 Then
            '    'dan gewoon een lege
            'ElseIf dt.Rows.Count = 1 Then
            '    result = New IBBFase(dt.Rows(0).Item("Id"), IBBFase.Via.ID)
            'ElseIf dt.Rows.Count > 1 Then
            '    For Each rw As DataRow In dt.Rows

            '    Next
            '    result = New IBBFase(dt.Rows(0).Item("Id"), IBBFase.Via.ID)
            'Else
            '    Throw New Exception("Er staan meerdere fases in afwachting, corrigeer dit!!")
            'End If

            'Return result

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function SelectByFaseTypeId(ByFaseTypeId As Integer) As IBBFase
        Try

            For Each IBBFase In ListIBBFases
                If IBBFase.TypeId = ByFaseTypeId Then
                    Return IBBFase
                End If
            Next

            Return Nothing

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AllPhasesClosed() As Boolean
        Try
            Dim AllClosed As Boolean = True
            Dim dt As DataTable
            Dim paramlist As New ArrayList
            Dim sql As String = "SELECT * FROM IBBFases where DossierId = @DossierId AND Besluit = @Besluit"
            paramlist.Add("@DossierId")
            paramlist.Add(Me.Id)
            paramlist.Add("@Besluit")
            paramlist.Add(0)
            dt = da.ExecuteDataTable(sql, paramlist.ToArray)
            AllClosed = dt.Rows.Count = 0

            Return AllClosed

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function TblFaseTypes() As Data.DataTable
        Dim oDS As Data.DataSet
        Try
            Dim sql As String = "SELECT distinct jd.Description, fs.TypeId ,jd.seq FROM IBBFases fs " & _
                                  "inner join jdTypes jd on fs.TypeId = jd.Id " & _
                                  "where DossierId = @DossierId " & _
                                  "order by jd.seq "
            Dim param() As Object = {"@DossierId", Id}
            Dim tblTypes As DataTable = da.ExecuteDataTable(sql, param)

            Dim dr2 As DataRow = tblTypes.NewRow
            dr2("TypeId") = 0
            dr2("Description") = "geen"
            tblTypes.Rows.InsertAt(dr2, 0)

            Return tblTypes
        Catch ex As Exception
            Throw ex
        Finally
            oDS = Nothing
        End Try
    End Function

    Public Function HasActiveCalendarAppointments() As Boolean
        Dim result As Boolean = False

        For Each f As IBBFase In ListIBBFases
            If f.HasFutureAppointments Then Return True

            'If Not String.IsNullOrEmpty(f.CalEntryObjectionId) Then Return True
            'If Not String.IsNullOrEmpty(f.CalEntryHerstelId) Then Return True
            'If Not String.IsNullOrEmpty(f.CalEntryHoorzittingId) Then Return True
            'If Not String.IsNullOrEmpty(f.CalEntry8) Then Return True
            'If Not String.IsNullOrEmpty(f.CalEntryBesluitId) Then Return True

            'If Not String.IsNullOrEmpty(f.CalEntryObjectionIdHandler) Then Return True
            'If Not String.IsNullOrEmpty(f.CalEntryHerstelIdHandler) Then Return True
            'If Not String.IsNullOrEmpty(f.CalEntryHoorzittingIdHandler) Then Return True
            'If Not String.IsNullOrEmpty(f.CalEntryHandler8) Then Return True
            'If Not String.IsNullOrEmpty(f.CalEntryBesluitIdHandler) Then Return True
        Next

        Return result
    End Function
    Public Sub ChangeDossierHandler(NewHandlerId As Integer)
        Try
            'verwijder alle toekomstige afspraken
            For Each f As IBBFase In ListIBBFases
                f.DeleteFutureAppointmentsEWS()
            Next


            Me.BehandelaarId = NewHandlerId
            Me.Save()

            'toevoegen alle toekomstige afspraken met nieuwe behandelaar
            For Each f As IBBFase In ListIBBFases(True)
                f.UpdateFutureAppointmentEWS()
            Next


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private _ChildDossiers As List(Of IBBDossier)
    Public ReadOnly Property ChildDossiers() As List(Of IBBDossier)
        Get
            If _ChildDossiers Is Nothing Then
                _ChildDossiers = New List(Of IBBDossier)
                Dim _dossier As New IBBDossier
                Dim ohelper As New Helper
                Dim sql As String = "SELECT * FROM IBBDossiers where MoederDossier = @md"
                Dim params As New ArrayList
                params.Add("@md")
                params.Add(DossierNr)
                _ChildDossiers = ohelper.MapDataTableToList(Of IBBDossier)(_dossier.GetList(sql, params.ToArray))
            End If

            Return _ChildDossiers
        End Get

    End Property
    Public ReadOnly Property GetMutDate() As Nullable(Of Date)
        Get
            Dim MyMutdate As New Nullable(Of Date)

            Dim sql As String = "SELECT mutdate FROM IBBDossiers where Id = @id"
            Dim params As New ArrayList
            params.Add("@id")
            params.Add(Id)
            Dim obj As Object = da.ExecuteScalar(sql, params.ToArray)
            If Not IsDBNull(obj) Then
                MyMutdate = obj
                'MyMutdate = MyMutdate.ToShortDateString
            End If


            Return MyMutdate

        End Get

    End Property
    Public Function LI(ByVal value As String, ByVal len As Int16) As String
        If value.Length >= len Then
            Return value.Substring(0, len)
        End If
        Return value.PadLeft(len, "0")
    End Function
    Public Sub CreateDossierDir()
        Try
            Dim SystemFolderPath As New Systeeminstellingen("IBBFiles", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)

            Dim slash As String = String.Empty
            If Not SystemFolderPath.Waarde.EndsWith("\") Then slash = "\"

            Dim FolderPath As String = SystemFolderPath.Waarde & slash & DossierNr

            Dim DossierDir As New IO.DirectoryInfo(FolderPath)
            If Not DossierDir.Exists Then DossierDir.Create()


        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub setDossierDirPermissions()
        Try
            Dim SetbPermissions As String = GetSysSettingOf("SetDossierDirPermissions", False)
            If SetbPermissions.ToLower <> "true" Then
                Exit Sub
            End If

            Dim SystemFolderPath As New Systeeminstellingen("IBBFiles", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)

            Dim slash As String = String.Empty
            If Not SystemFolderPath.Waarde.EndsWith("\") Then slash = "\"

            Dim FolderPath As String = SystemFolderPath.Waarde & slash & DossierNr
            Dim UserAccount As String = Me.myBehandelaar.ExchangeAccount

            If Not String.IsNullOrEmpty(UserAccount) Then
                Dim DossierDir As New IO.DirectoryInfo(FolderPath)
                If Not DossierDir.Exists Then DossierDir.Create()
                If URights.IsExistingUser(UserAccount) Then
                    Dim FolderInfo As IO.DirectoryInfo = New IO.DirectoryInfo(FolderPath)
                    Dim FolderAcl As New DirectorySecurity

                    FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.Modify, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
                    'FolderAcl.SetAccessRuleProtection(True, False) 'verwijderd alle andere rechten
                    FolderInfo.SetAccessControl(FolderAcl)
                End If

            End If


        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub ChangeDossierDirPermissions(DeletePermission As String, AddPermission As String)
        Try
            Dim SetbPermissions As String = GetSysSettingOf("SetDossierDirPermissions", False)
            If SetbPermissions.ToLower <> "true" Then
                Exit Sub
            End If

            Dim SystemFolderPath As New Systeeminstellingen("IBBFiles", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)

            Dim slash As String = String.Empty
            If Not SystemFolderPath.Waarde.EndsWith("\") Then slash = "\"

            Dim FolderPath As String = SystemFolderPath.Waarde & slash & DossierNr
            Dim FolderInfo As IO.DirectoryInfo = New IO.DirectoryInfo(FolderPath)
            Dim FolderAcl As New DirectorySecurity

            If Not String.IsNullOrEmpty(DeletePermission) Then
                If URights.IsExistingUser(DeletePermission) Then
                    FolderAcl.RemoveAccessRule(New FileSystemAccessRule(DeletePermission, FileSystemRights.ReadData, AccessControlType.Allow))
                End If
            End If

            If Not String.IsNullOrEmpty(AddPermission) Then
                If URights.IsExistingUser(AddPermission) Then
                    FolderAcl.AddAccessRule(New FileSystemAccessRule(AddPermission, FileSystemRights.Modify, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
                End If
            End If

            FolderInfo.SetAccessControl(FolderAcl)


        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
