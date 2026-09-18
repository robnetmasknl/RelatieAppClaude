Imports System.DirectoryServices
Imports System.Windows.Forms
Imports System.DirectoryServices.ActiveDirectory

Public Class UserRights
    Private Shared _Instance As UserRights

    Protected Sub New()
    End Sub

    Public Shared Function Instance() As UserRights
        If _Instance Is Nothing Then
            _Instance = New UserRights()
        End If

        Return _Instance
    End Function

    Public UserADGroups As Collection

    Private _IsLoaded As Boolean = False
    Public Property IsLoaded() As Boolean
        Get
            Return _IsLoaded
        End Get
        Set(ByVal value As Boolean)
            _IsLoaded = value
        End Set
    End Property

    Private _UserName As String = ""
    Public Property UserName() As String
        Get
            If String.IsNullOrEmpty(_UserName) Then
                'Zet dit aan om NIET domein pc aan te kunnen melden
                'If Not String.IsNullOrEmpty(Settings.Instance.DomainUser) Then
                '    _UserName = ExtractUserName(Settings.Instance.DomainUser)
                'Else
                _UserName = ExtractUserName(My.User.Name)
                'End If

            End If
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property

    Public Function IsInGroup(ByVal group As String) As Boolean
        If UserADGroups Is Nothing Then
            UserADGroups = GetGroups(UserName)
        End If
        For Each grp In UserADGroups
            If grp = group.ToLower Then Return True
        Next
        Return False
    End Function
    Public Function IsMemberOfOne(ByVal groups() As Object) As Boolean
        If UserADGroups Is Nothing Then
            UserADGroups = GetGroups(UserName)
        End If

        For Each grp In UserADGroups
            For i As Integer = 0 To groups.Length - 1 'Step 2
                If grp = CType(groups(i), String).Trim.ToLower Then Return True
            Next
        Next

        Return False
    End Function
    Private Shared Function ExtractUserName(ByVal path As String) As String
        Dim userPath As String() = path.Split(New Char() {"\"c})
        Return userPath((userPath.Length - 1))
    End Function

    Public Function IsValidADLogin() As Boolean 'ByVal loginName As String
        Try
            If IsLoaded Then Return True

            'Zet dit aan om NIET domein pc aan te kunnen melden
            'Dim dirEntry As New DirectoryEntry("LDAP://10.2.1.10")'dit zou dan ook uit een config moeten komen
            'Dim search As New DirectorySearcher(dirEntry)
            Dim search As New DirectorySearcher()

            search.Filter = String.Format("(&(SAMAccountName={0}))", UserName)
            search.PropertiesToLoad.Add("cn")
            search.PropertiesToLoad.Add("SAMAccountName")

            Dim result As SearchResult = search.FindOne()

            If result Is Nothing Then
                Return False
            Else
                'user bestaat, nu de groepen ophalen.
                UserADGroups = GetGroups(UserName)
                IsLoaded = True
                For Each grp In UserADGroups
                    If grp.contains("rel_") Then Return True
                Next
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Active Directory Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Function
    Public Function IsExistingUser(ByVal checkname As String) As Boolean
        Try
            Dim search As New DirectorySearcher()

            search.Filter = String.Format("(&(SAMAccountName={0}))", checkname)
            search.PropertiesToLoad.Add("cn")
            search.PropertiesToLoad.Add("SAMAccountName")

            Dim result As SearchResult = search.FindOne()

            If result Is Nothing Then
                'user bestaat niet
                Return False
            Else
                'user bestaat
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Active Directory Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Function
    Private _domainname As String
    Public ReadOnly Property getDomainName() As String
        Get
            Return _domainname
        End Get
    End Property

    Private Function GetGroups(ByVal username As String) As Collection
        Dim Groups As New Collection

        'Zet dit aan om NIET domein pc aan te kunnen melden
        'Dim dirEntry As New DirectoryEntry("LDAP://10.2.1.10")
        'Dim dirSearcher As New DirectorySearcher(dirEntry)

        Dim dirSearcher As New DirectorySearcher()
        dirSearcher.Filter = String.Format("(sAMAccountName={0})", username)
        dirSearcher.PropertiesToLoad.Add("memberOf")
        Dim propCount As Integer
        Try
            'Dim Root As New DirectoryEntry 'Establishes a connection to current loged on users Active Directory
            'Dim fullDomain As String = Root.Name
            'Dim firstPart As Integer = fullDomain.Substring(fullDomain.IndexOf("DC="))
            _domainname = Environment.UserDomainName


            Dim dirSearchResults As SearchResult = dirSearcher.FindOne()
            propCount = dirSearchResults.Properties("memberOf").Count
            Dim dn As String
            Dim equalsIndex As String
            Dim commaIndex As String
            For i As Integer = 0 To propCount - 1
                dn = dirSearchResults.Properties("memberOf")(i)
                equalsIndex = dn.IndexOf("=", 1)
                commaIndex = dn.IndexOf(",", 1)
                If equalsIndex = -1 Then
                    Return Nothing
                End If
                If Not Groups.Contains(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1)) Then
                    Groups.Add(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1).ToLower)
                End If
            Next
        Catch ex As Exception
            If ex.GetType Is GetType(System.NullReferenceException) Then
                MessageBox.Show("Selected user isn't a member of any groups at this time.", "No groups listed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'they are still a good user just does not
                'have a "memberOf" attribute so it errors out.
                'code to do something else here if you want
            Else
                MessageBox.Show(ex.Message.ToString, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
        Return Groups
    End Function
    Function HaveAccess() As Boolean
        Try


            Return True
        Catch ex As Exception
            Return False
        End Try

        Return False
    End Function

End Class
