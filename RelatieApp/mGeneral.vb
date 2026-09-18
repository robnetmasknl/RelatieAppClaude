Imports System.Globalization

Module mGeneral
    Private _HaveSMSApplication As Boolean = False
    Public Property HaveSMSApplication() As Boolean
        Get
            Return _HaveSMSApplication
        End Get
        Set(ByVal value As Boolean)
            _HaveSMSApplication = value
        End Set
    End Property

    Private m_NLCulture As CultureInfo = Nothing
    Private m_CurrentCulture As CultureInfo = Nothing


    Public ReadOnly Property CurrentCulture() As CultureInfo
        Get
            If m_CurrentCulture Is Nothing Then SetCultureNL()
            Return m_CurrentCulture
        End Get
    End Property
    Public ReadOnly Property NLCulture() As CultureInfo
        Get
            If m_NLCulture Is Nothing Then SetCultureNL()
            Return m_NLCulture
        End Get
    End Property

    Public Sub SetCultureNL()

        m_CurrentCulture = System.Threading.Thread.CurrentThread.CurrentCulture

        m_NLCulture = New CultureInfo("nl-NL", True)
        m_NLCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy"
        m_NLCulture.DateTimeFormat.DateSeparator = "-"
        m_NLCulture.NumberFormat.CurrencyDecimalSeparator = ","
        m_NLCulture.NumberFormat.CurrencyGroupSeparator = "."


    End Sub

    Private _NLCultureShort As CultureInfo = Nothing
    Public ReadOnly Property NLCultureShort() As CultureInfo
        Get
            _NLCultureShort = New CultureInfo("nl-NL", True)
            _NLCultureShort.DateTimeFormat.ShortDatePattern = "d-M-yyyy"
            _NLCultureShort.DateTimeFormat.DateSeparator = "-"
            '_NLCultureShort.NumberFormat.CurrencyDecimalSeparator = ","
            '_NLCultureShort.NumberFormat.CurrencyGroupSeparator = "."

            Return _NLCultureShort
        End Get
    End Property

End Module
