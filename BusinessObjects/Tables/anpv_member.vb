Public Class anpv_member
    Inherits tblanpv_member
    Private da As New DataAccess
#Region "Basic"
    Enum Via
        ID
    End Enum
    Public Sub New()

    End Sub
    Public Sub New(ByVal id As String, ByVal Via As Via)
        Dim ohelper As New Helper
        If Via.ToString = "ID" Then
            ohelper.FillObject(Me, GetById(id))
            'ElseIf Via.ToString = "SHORTDESC" Then
            'ohelper.FillObject(Me, GetByShortDesc(id))
        End If
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
    Public Function GetById(ByVal id As Int32) As Data.DataRow
        Dim oDr As Data.DataRow
        Try
            Dim sql As String = "SELECT * FROM  anpv_member where id = @id"
            Dim param() As Object = {"@id", id.ToString}
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
    Public Sub Save()
        Try
            If Me.Id = Nothing Then
                Id = da.InsertString(Me, "anpv_member", "Id", True)
            Else
                da.UpdateString(Me, "anpv_member", "Id")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Remove()
        Try
            Dim da As New DataAccess
            da.DeleteString(Me, "anpv_member")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

End Class
Public Class tblanpv_member
#Region "members"
    Private _id As Int32 = 0
    Private _region_id As Int32 = 0
    Private _role_id As Int32 = 0
    Private _board_member_id As Int32 = 0
    Private _oc_member_id As Int32 = 0
    Private _employee_number As Int32 = 0
    Private _contribution_id As Int32 = 0
    Private _member_type_id As Int32 = 0
    Private _title As String = String.Empty
    Private _initials As String = String.Empty
    Private _lastname As String = String.Empty
    Private _company_name As String = String.Empty
    Private _contact_name As String = String.Empty
    Private _phone_nr As String = String.Empty
    Private _mobile_phone_nr As String = String.Empty
    Private _work_phone_nr As String = String.Empty
    Private _email As String = String.Empty
    Private _date_of_birth As String = String.Empty
    Private _joined_date As String = String.Empty
    Private _membership_date As String = String.Empty
    Private _unjoined_date As String = String.Empty
    Private _mutation As String = String.Empty
    Private _or_member As Decimal
    Private _section_member As String = String.Empty
    Private _processed As String = String.Empty
    Private _removed As Decimal
    Private _note As String = String.Empty
    Private _is_extern As Decimal
    Private _is_active As Decimal
    Private _is_post_active As Decimal
    Private _removed_date As String = String.Empty
    Private _importid As Int32 = 0
    Private _imported_hb As String = String.Empty
    Private _imported_or As String = String.Empty
    Private _imported_oc As String = String.Empty
    Private _imported_rgo As String = String.Empty
    Private _imported_processed As String = String.Empty
    Private _address_street As String = String.Empty
    Private _address_number As Int32 = 0
    Private _address_addition As String = String.Empty
    Private _address_postcode As String = String.Empty
    Private _address_city As String = String.Empty
    Private _address_country As String = String.Empty
    Private _partner_id As Int32 = 0
    Private _has_partner As Decimal
    Private _welcome_gift As String = String.Empty
    Private _moved_info As String = String.Empty
    Private _membership_type As String = String.Empty
    Private _payment_info As String = String.Empty
    Private _widow_info As String = String.Empty
    Private _has_moved As Decimal
    Private _outstanding_payment As Decimal
    Private _benefits As String = String.Empty
    Private _old_member_info As String = String.Empty
    Private _is_checked As Int32 = 0
    Private _nr_of_magazines As Int32 = 0
    Private _governing_board As Decimal
    Private _members_council As Decimal
    Private _department_member_id As Int32 = 0
    Private _created_at As String = String.Empty
    Private _updated_at As String = String.Empty
    Private _work_email As String = String.Empty
    Private _vereniging_email As String = String.Empty
    Private _bank_account As String = String.Empty
    Private _locked_user_id As Int32 = 0
    Private _locked_date As String = String.Empty
    Private _inbetween As String = String.Empty
    Private _salary_number As Int32 = 0
    Private _firstname As String = String.Empty
    Private _regioold As String = String.Empty
    Private _geboorteplaats As String = String.Empty
    Private _contribution_amount As Single
#End Region

#Region "Properties"

    <MapperColumn("id", SqlDbType.Int)>
    Public Property id() As Int32
        Get
            Return _id
        End Get
        Set(ByVal value As Int32)
            _id = value
        End Set
    End Property
    <MapperColumn("region_id", SqlDbType.Int)>
    Public Property region_id() As Int32
        Get
            Return _region_id
        End Get
        Set(ByVal value As Int32)
            _region_id = value
        End Set
    End Property
    <MapperColumn("role_id", SqlDbType.Int)>
    Public Property role_id() As Int32
        Get
            Return _role_id
        End Get
        Set(ByVal value As Int32)
            _role_id = value
        End Set
    End Property
    <MapperColumn("board_member_id", SqlDbType.Int)>
    Public Property board_member_id() As Int32
        Get
            Return _board_member_id
        End Get
        Set(ByVal value As Int32)
            _board_member_id = value
        End Set
    End Property
    <MapperColumn("oc_member_id", SqlDbType.Int)>
    Public Property oc_member_id() As Int32
        Get
            Return _oc_member_id
        End Get
        Set(ByVal value As Int32)
            _oc_member_id = value
        End Set
    End Property
    <MapperColumn("employee_number", SqlDbType.Int)>
    Public Property employee_number() As Int32
        Get
            Return _employee_number
        End Get
        Set(ByVal value As Int32)
            _employee_number = value
        End Set
    End Property
    <MapperColumn("contribution_id", SqlDbType.Int)>
    Public Property contribution_id() As Int32
        Get
            Return _contribution_id
        End Get
        Set(ByVal value As Int32)
            _contribution_id = value
        End Set
    End Property
    <MapperColumn("member_type_id", SqlDbType.Int)>
    Public Property member_type_id() As Int32
        Get
            Return _member_type_id
        End Get
        Set(ByVal value As Int32)
            _member_type_id = value
        End Set
    End Property
    <MapperColumn("title", SqlDbType.NVarChar)>
    Public Property title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property
    <MapperColumn("initials", SqlDbType.NVarChar)>
    Public Property initials() As String
        Get
            Return _initials
        End Get
        Set(ByVal value As String)
            _initials = value
        End Set
    End Property
    <MapperColumn("lastname", SqlDbType.NVarChar)>
    Public Property lastname() As String
        Get
            Return _lastname
        End Get
        Set(ByVal value As String)
            _lastname = value
        End Set
    End Property
    <MapperColumn("company_name", SqlDbType.NVarChar)>
    Public Property company_name() As String
        Get
            Return _company_name
        End Get
        Set(ByVal value As String)
            _company_name = value
        End Set
    End Property
    <MapperColumn("contact_name", SqlDbType.NVarChar)>
    Public Property contact_name() As String
        Get
            Return _contact_name
        End Get
        Set(ByVal value As String)
            _contact_name = value
        End Set
    End Property
    <MapperColumn("phone_nr", SqlDbType.NVarChar)>
    Public Property phone_nr() As String
        Get
            Return _phone_nr
        End Get
        Set(ByVal value As String)
            _phone_nr = value
        End Set
    End Property
    <MapperColumn("mobile_phone_nr", SqlDbType.NVarChar)>
    Public Property mobile_phone_nr() As String
        Get
            Return _mobile_phone_nr
        End Get
        Set(ByVal value As String)
            _mobile_phone_nr = value
        End Set
    End Property
    <MapperColumn("work_phone_nr", SqlDbType.NVarChar)>
    Public Property work_phone_nr() As String
        Get
            Return _work_phone_nr
        End Get
        Set(ByVal value As String)
            _work_phone_nr = value
        End Set
    End Property
    <MapperColumn("email", SqlDbType.NVarChar)>
    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property
    <MapperColumn("date_of_birth", SqlDbType.Date)>
    Public Property date_of_birth() As String
        Get
            Return _date_of_birth
        End Get
        Set(ByVal value As String)
            _date_of_birth = value
        End Set
    End Property
    <MapperColumn("joined_date", SqlDbType.Date)>
    Public Property joined_date() As String
        Get
            Return _joined_date
        End Get
        Set(ByVal value As String)
            _joined_date = value
        End Set
    End Property
    <MapperColumn("membership_date", SqlDbType.Date)>
    Public Property membership_date() As String
        Get
            Return _membership_date
        End Get
        Set(ByVal value As String)
            _membership_date = value
        End Set
    End Property
    <MapperColumn("unjoined_date", SqlDbType.Date)>
    Public Property unjoined_date() As String
        Get
            Return _unjoined_date
        End Get
        Set(ByVal value As String)
            _unjoined_date = value
        End Set
    End Property
    <MapperColumn("mutation", SqlDbType.NVarChar)>
    Public Property mutation() As String
        Get
            Return _mutation
        End Get
        Set(ByVal value As String)
            _mutation = value
        End Set
    End Property
    <MapperColumn("or_member", SqlDbType.Decimal)>
    Public Property or_member() As Decimal
        Get
            Return _or_member
        End Get
        Set(ByVal value As Decimal)
            _or_member = value
        End Set
    End Property
    <MapperColumn("section_member", SqlDbType.NVarChar)>
    Public Property section_member() As String
        Get
            Return _section_member
        End Get
        Set(ByVal value As String)
            _section_member = value
        End Set
    End Property
    <MapperColumn("processed", SqlDbType.Date)>
    Public Property processed() As String
        Get
            Return _processed
        End Get
        Set(ByVal value As String)
            _processed = value
        End Set
    End Property
    <MapperColumn("removed", SqlDbType.Decimal)>
    Public Property removed() As Decimal
        Get
            Return _removed
        End Get
        Set(ByVal value As Decimal)
            _removed = value
        End Set
    End Property
    <MapperColumn("note", SqlDbType.NText)>
    Public Property note() As String
        Get
            Return _note
        End Get
        Set(ByVal value As String)
            _note = value
        End Set
    End Property
    <MapperColumn("is_extern", SqlDbType.Decimal)>
    Public Property is_extern() As Decimal
        Get
            Return _is_extern
        End Get
        Set(ByVal value As Decimal)
            _is_extern = value
        End Set
    End Property
    <MapperColumn("is_active", SqlDbType.Decimal)>
    Public Property is_active() As Decimal
        Get
            Return _is_active
        End Get
        Set(ByVal value As Decimal)
            _is_active = value
        End Set
    End Property
    <MapperColumn("is_post_active", SqlDbType.Decimal)>
    Public Property is_post_active() As Decimal
        Get
            Return _is_post_active
        End Get
        Set(ByVal value As Decimal)
            _is_post_active = value
        End Set
    End Property
    <MapperColumn("removed_date", SqlDbType.Date)>
    Public Property removed_date() As String
        Get
            Return _removed_date
        End Get
        Set(ByVal value As String)
            _removed_date = value
        End Set
    End Property
    <MapperColumn("importid", SqlDbType.Int)>
    Public Property importid() As Int32
        Get
            Return _importid
        End Get
        Set(ByVal value As Int32)
            _importid = value
        End Set
    End Property
    <MapperColumn("imported_hb", SqlDbType.NVarChar)>
    Public Property imported_hb() As String
        Get
            Return _imported_hb
        End Get
        Set(ByVal value As String)
            _imported_hb = value
        End Set
    End Property
    <MapperColumn("imported_or", SqlDbType.NVarChar)>
    Public Property imported_or() As String
        Get
            Return _imported_or
        End Get
        Set(ByVal value As String)
            _imported_or = value
        End Set
    End Property
    <MapperColumn("imported_oc", SqlDbType.NVarChar)>
    Public Property imported_oc() As String
        Get
            Return _imported_oc
        End Get
        Set(ByVal value As String)
            _imported_oc = value
        End Set
    End Property
    <MapperColumn("imported_rgo", SqlDbType.NVarChar)>
    Public Property imported_rgo() As String
        Get
            Return _imported_rgo
        End Get
        Set(ByVal value As String)
            _imported_rgo = value
        End Set
    End Property
    <MapperColumn("imported_processed", SqlDbType.NVarChar)>
    Public Property imported_processed() As String
        Get
            Return _imported_processed
        End Get
        Set(ByVal value As String)
            _imported_processed = value
        End Set
    End Property
    <MapperColumn("address_street", SqlDbType.NVarChar)>
    Public Property address_street() As String
        Get
            Return _address_street
        End Get
        Set(ByVal value As String)
            _address_street = value
        End Set
    End Property
    <MapperColumn("address_number", SqlDbType.Int)>
    Public Property address_number() As Int32
        Get
            Return _address_number
        End Get
        Set(ByVal value As Int32)
            _address_number = value
        End Set
    End Property
    <MapperColumn("address_addition", SqlDbType.NVarChar)>
    Public Property address_addition() As String
        Get
            Return _address_addition
        End Get
        Set(ByVal value As String)
            _address_addition = value
        End Set
    End Property
    <MapperColumn("address_postcode", SqlDbType.NVarChar)>
    Public Property address_postcode() As String
        Get
            Return _address_postcode
        End Get
        Set(ByVal value As String)
            _address_postcode = value
        End Set
    End Property
    <MapperColumn("address_city", SqlDbType.NVarChar)>
    Public Property address_city() As String
        Get
            Return _address_city
        End Get
        Set(ByVal value As String)
            _address_city = value
        End Set
    End Property
    <MapperColumn("address_country", SqlDbType.NVarChar)>
    Public Property address_country() As String
        Get
            Return _address_country
        End Get
        Set(ByVal value As String)
            _address_country = value
        End Set
    End Property
    <MapperColumn("partner_id", SqlDbType.Int)>
    Public Property partner_id() As Int32
        Get
            Return _partner_id
        End Get
        Set(ByVal value As Int32)
            _partner_id = value
        End Set
    End Property
    <MapperColumn("has_partner", SqlDbType.Decimal)>
    Public Property has_partner() As Decimal
        Get
            Return _has_partner
        End Get
        Set(ByVal value As Decimal)
            _has_partner = value
        End Set
    End Property
    <MapperColumn("welcome_gift", SqlDbType.NVarChar)>
    Public Property welcome_gift() As String
        Get
            Return _welcome_gift
        End Get
        Set(ByVal value As String)
            _welcome_gift = value
        End Set
    End Property
    <MapperColumn("moved_info", SqlDbType.NText)>
    Public Property moved_info() As String
        Get
            Return _moved_info
        End Get
        Set(ByVal value As String)
            _moved_info = value
        End Set
    End Property
    <MapperColumn("membership_type", SqlDbType.NVarChar)>
    Public Property membership_type() As String
        Get
            Return _membership_type
        End Get
        Set(ByVal value As String)
            _membership_type = value
        End Set
    End Property
    <MapperColumn("payment_info", SqlDbType.NVarChar)>
    Public Property payment_info() As String
        Get
            Return _payment_info
        End Get
        Set(ByVal value As String)
            _payment_info = value
        End Set
    End Property
    <MapperColumn("widow_info", SqlDbType.NVarChar)>
    Public Property widow_info() As String
        Get
            Return _widow_info
        End Get
        Set(ByVal value As String)
            _widow_info = value
        End Set
    End Property
    <MapperColumn("has_moved", SqlDbType.Decimal)>
    Public Property has_moved() As Decimal
        Get
            Return _has_moved
        End Get
        Set(ByVal value As Decimal)
            _has_moved = value
        End Set
    End Property
    <MapperColumn("outstanding_payment", SqlDbType.Decimal)>
    Public Property outstanding_payment() As Decimal
        Get
            Return _outstanding_payment
        End Get
        Set(ByVal value As Decimal)
            _outstanding_payment = value
        End Set
    End Property
    <MapperColumn("benefits", SqlDbType.NText)>
    Public Property benefits() As String
        Get
            Return _benefits
        End Get
        Set(ByVal value As String)
            _benefits = value
        End Set
    End Property
    <MapperColumn("old_member_info", SqlDbType.NText)>
    Public Property old_member_info() As String
        Get
            Return _old_member_info
        End Get
        Set(ByVal value As String)
            _old_member_info = value
        End Set
    End Property
    <MapperColumn("is_checked", SqlDbType.Int)>
    Public Property is_checked() As Int32
        Get
            Return _is_checked
        End Get
        Set(ByVal value As Int32)
            _is_checked = value
        End Set
    End Property
    <MapperColumn("nr_of_magazines", SqlDbType.Int)>
    Public Property nr_of_magazines() As Int32
        Get
            Return _nr_of_magazines
        End Get
        Set(ByVal value As Int32)
            _nr_of_magazines = value
        End Set
    End Property
    <MapperColumn("governing_board", SqlDbType.Decimal)>
    Public Property governing_board() As Decimal
        Get
            Return _governing_board
        End Get
        Set(ByVal value As Decimal)
            _governing_board = value
        End Set
    End Property
    <MapperColumn("members_council", SqlDbType.Decimal)>
    Public Property members_council() As Decimal
        Get
            Return _members_council
        End Get
        Set(ByVal value As Decimal)
            _members_council = value
        End Set
    End Property
    <MapperColumn("department_member_id", SqlDbType.Int)>
    Public Property department_member_id() As Int32
        Get
            Return _department_member_id
        End Get
        Set(ByVal value As Int32)
            _department_member_id = value
        End Set
    End Property
    <MapperColumn("created_at", SqlDbType.DateTime2)>
    Public Property created_at() As String
        Get
            Return _created_at
        End Get
        Set(ByVal value As String)
            _created_at = value
        End Set
    End Property
    <MapperColumn("updated_at", SqlDbType.DateTime2)>
    Public Property updated_at() As String
        Get
            Return _updated_at
        End Get
        Set(ByVal value As String)
            _updated_at = value
        End Set
    End Property
    <MapperColumn("work_email", SqlDbType.NVarChar)>
    Public Property work_email() As String
        Get
            Return _work_email
        End Get
        Set(ByVal value As String)
            _work_email = value
        End Set
    End Property
    <MapperColumn("vereniging_email", SqlDbType.NVarChar)>
    Public Property vereniging_email() As String
        Get
            Return _vereniging_email
        End Get
        Set(ByVal value As String)
            _vereniging_email = value
        End Set
    End Property
    <MapperColumn("bank_account", SqlDbType.NVarChar)>
    Public Property bank_account() As String
        Get
            Return _bank_account
        End Get
        Set(ByVal value As String)
            _bank_account = value
        End Set
    End Property
    <MapperColumn("locked_user_id", SqlDbType.Int)>
    Public Property locked_user_id() As Int32
        Get
            Return _locked_user_id
        End Get
        Set(ByVal value As Int32)
            _locked_user_id = value
        End Set
    End Property
    <MapperColumn("locked_date", SqlDbType.DateTime2)>
    Public Property locked_date() As String
        Get
            Return _locked_date
        End Get
        Set(ByVal value As String)
            _locked_date = value
        End Set
    End Property
    <MapperColumn("inbetween", SqlDbType.NVarChar)>
    Public Property inbetween() As String
        Get
            Return _inbetween
        End Get
        Set(ByVal value As String)
            _inbetween = value
        End Set
    End Property
    <MapperColumn("salary_number", SqlDbType.Int)>
    Public Property salary_number() As Int32
        Get
            Return _salary_number
        End Get
        Set(ByVal value As Int32)
            _salary_number = value
        End Set
    End Property
    <MapperColumn("firstname", SqlDbType.NVarChar)>
    Public Property firstname() As String
        Get
            Return _firstname
        End Get
        Set(ByVal value As String)
            _firstname = value
        End Set
    End Property
    <MapperColumn("regioold", SqlDbType.NVarChar)>
    Public Property regioold() As String
        Get
            Return _regioold
        End Get
        Set(ByVal value As String)
            _regioold = value
        End Set
    End Property
    <MapperColumn("geboorteplaats", SqlDbType.NVarChar)>
    Public Property geboorteplaats() As String
        Get
            Return _geboorteplaats
        End Get
        Set(ByVal value As String)
            _geboorteplaats = value
        End Set
    End Property
    <MapperColumn("contribution_amount", SqlDbType.Real)>
    Public Property contribution_amount() As Single
        Get
            Return _contribution_amount
        End Get
        Set(ByVal value As Single)
            _contribution_amount = value
        End Set
    End Property

#End Region

End Class
