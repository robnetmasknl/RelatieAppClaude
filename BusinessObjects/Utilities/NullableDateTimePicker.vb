Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Forms

'Namespace ProjectMentor.Windows.Controls
'    ''' <summary>
'    ''' Represents a Windows date time picker control. It enhances the .NET standard <b>DateTimePicker</b>
'    ''' control with a ReadOnly mode as well as with the possibility to show empty values (null values).
'    ''' </summary>
'    <ComVisible(False)> _
Public Class NullableDateTimePicker
    Inherits System.Windows.Forms.DateTimePicker
#Region "Member variables"
    ' true, when no date shall be displayed (empty DateTimePicker)
    Private _isNull As Boolean

    ' If _isNull = true, this value is shown in the DTP
    Private _nullValue As String

    ' The format of the DateTimePicker control
    Private _format As DateTimePickerFormat = DateTimePickerFormat.[Long]

    ' The custom format of the DateTimePicker control
    Private _customFormat As String

    ' The format of the DateTimePicker control as string
    Private _formatAsString As String
#End Region

#Region "Constructor"
    ''' <summary>
    ''' Default Constructor
    ''' </summary>
    Public Sub New()
        MyBase.New()
        MyBase.Format = DateTimePickerFormat.[Custom]
        NullValue = " "
        Format = DateTimePickerFormat.[Long]
    End Sub
#End Region

#Region "Public properties"

    ''' <summary>
    ''' Gets or sets the date/time value assigned to the control.
    ''' </summary>
    ''' <value>The DateTime value assigned to the control
    ''' </value>
    ''' <remarks>
    ''' <p>If the <b>Value</b> property has not been changed in code or by the user, it is set
    ''' to the current date and time (<see cref="DateTime.Now"/>).</p>
    ''' <p>If <b>Value</b> is <b>null</b>, the DateTimePicker shows 
    ''' <see cref="NullValue"/>.</p>
    ''' </remarks>
    Public Shadows Property Value() As [Object]
        Get
            If _isNull Then
                Return Nothing
            Else
                Return MyBase.Value
            End If
        End Get
        Set(ByVal value As [Object])
            '  If value = String.Empty OrElse value Is Nothing OrElse value Is DBNull.Value Then 'OrElse value = New Date(1900, 1, 1, 0, 0, 0, 0) 
            If Not IsDate(value) Then
                SetToNullValue()
            Else
                SetToDateTimeValue()
                MyBase.Value = CType(value, DateTime)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the format of the date and time displayed in the control.
    ''' </summary>
    ''' <value>One of the <see cref="DateTimePickerFormat"/> values. The default is 
    ''' <see cref="DateTimePickerFormat.Long"/>.</value>
    <Browsable(True)> _
    <DefaultValue(DateTimePickerFormat.[Long]), TypeConverter(GetType([Enum]))> _
    Public Shadows Property Format() As DateTimePickerFormat
        Get
            Return _format
        End Get
        Set(ByVal value As DateTimePickerFormat)
            _format = value
            SetFormat()
            OnFormatChanged(EventArgs.Empty)
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the custom date/time format string.
    ''' <value>A string that represents the custom date/time format. The default is a null
    ''' reference (<b>Nothing</b> in Visual Basic).</value>
    ''' </summary>
    Public Shadows Property CustomFormat() As [String]
        Get
            Return _customFormat
        End Get
        Set(ByVal value As [String])
            _customFormat = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the string value that is assigned to the control as null value. 
    ''' </summary>
    ''' <value>The string value assigned to the control as null value.</value>
    ''' <remarks>
    ''' If the <see cref="Value"/> is <b>null</b>, <b>NullValue</b> is
    ''' shown in the <b>DateTimePicker</b> control.
    ''' </remarks>
    <Browsable(True)> _
    <Category("Behavior")> _
    <Description("The string used to display null values in the control")> _
    <DefaultValue(" ")> _
    Public Property NullValue() As [String]
        Get
            Return _nullValue
        End Get
        Set(ByVal value As [String])
            _nullValue = value
        End Set
    End Property
#End Region

#Region "Private methods/properties"
    ''' <summary>
    ''' Stores the current format of the DateTimePicker as string. 
    ''' </summary>
    Private Property FormatAsString() As String
        Get
            Return _formatAsString
        End Get
        Set(ByVal value As String)
            _formatAsString = value
            MyBase.CustomFormat = value
        End Set
    End Property

    ''' <summary>
    ''' Sets the format according to the current DateTimePickerFormat.
    ''' </summary>
    Private Sub SetFormat()
        Dim ci As CultureInfo = Thread.CurrentThread.CurrentCulture
        Dim dtf As DateTimeFormatInfo = ci.DateTimeFormat
        Select Case _format
            Case DateTimePickerFormat.[Long]
                FormatAsString = dtf.LongDatePattern
                Exit Select
            Case DateTimePickerFormat.[Short]
                FormatAsString = dtf.ShortDatePattern
                Exit Select
            Case DateTimePickerFormat.Time
                FormatAsString = dtf.ShortTimePattern
                Exit Select
            Case DateTimePickerFormat.[Custom]
                FormatAsString = Me.CustomFormat
                Exit Select
        End Select
    End Sub

    ''' <summary>
    ''' Sets the <b>DateTimePicker</b> to the value of the <see cref="NullValue"/> property.
    ''' </summary>
    Private Sub SetToNullValue()
        ' If MyBase.Value = DateTime.Now OrElse MyBase.Value = New Date(1900, 1, 1, 0, 0, 0, 0) Then
        _isNull = True
        MyBase.CustomFormat = If((_nullValue Is Nothing OrElse _nullValue = [String].Empty), " ", "'" & _nullValue & "'")
        ' End If

    End Sub

    ''' <summary>
    ''' Sets the <b>DateTimePicker</b> back to a non null value.
    ''' </summary>
    Private Sub SetToDateTimeValue()
        If _isNull Then
            SetFormat()
            _isNull = False
            MyBase.OnValueChanged(New EventArgs())
        End If
    End Sub
#End Region

#Region "OnXXXX()"

    ''' <summary>
    ''' This member overrides <see cref="DateTimePicker.OnCloseUp"/>.
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnCloseUp(ByVal e As EventArgs)
        If Control.MouseButtons = MouseButtons.None Then
            If _isNull Then
                SetToDateTimeValue()
                _isNull = False
            End If
        End If
        MyBase.OnCloseUp(e)
    End Sub

    ''' <summary>
    ''' This member overrides <see cref="Control.OnKeyDown"/>.
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnKeyUp(ByVal e As KeyEventArgs)
        If e.KeyCode = Keys.Delete Then
            Me.Value = Nothing
            OnValueChanged(EventArgs.Empty)
        End If
        MyBase.OnKeyUp(e)
    End Sub
#End Region

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'NullableDateTimePicker
        '
        Me.CustomFormat = "dd-MM-yyyy"
        Me.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Value = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.ResumeLayout(False)

    End Sub
End Class
'End Namespace