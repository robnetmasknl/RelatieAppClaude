Imports System.ComponentModel
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace AdamTibi.Web.UI.Validators

    <AspNetHostingPermission(SecurityAction.LinkDemand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, Level:=AspNetHostingPermissionLevel.Minimal)> _
    <ToolboxData("<{0}:MultipleFieldsValidator runat=server></{0}:MultipleFieldsValidator>")> _
    Public Class MultipleFieldsValidator
        Inherits BaseValidator

#Region "Overriden Methods"

        Protected Overrides Sub AddAttributesToRender(ByVal writer As System.Web.UI.HtmlTextWriter)

            ' Setting SetFocusOnError before calling the base AddAttributesToRender because
            ' the AddAttributesToRender is going to check for "SetFocusOnError" value
            MyBase.SetFocusOnError = False
            ' Because we have many fields to check!
            MyBase.AddAttributesToRender(writer)

            If Me.RenderUplevel Then
                Dim clientID As String = Me.ClientID

                Page.ClientScript.RegisterExpandoAttribute(clientID, "evaluationfunction", "MultipleFieldsValidatorEvaluateIsValid")
                Page.ClientScript.RegisterExpandoAttribute(clientID, "controlstovalidate", Me.GenerateClientSideControlsToValidate())
                Page.ClientScript.RegisterExpandoAttribute(clientID, "condition", PropertyConverter.EnumToString(GetType(Conditions), Condition))
            End If
        End Sub

        Protected Overrides Function ControlPropertiesValid() As Boolean

            If Me.ControlsToValidate.Trim().Length = 0 Then
                Throw New HttpException(String.Format("The ControlsToValidate property of {0} cannot be blank.", Me.ID))
            End If

            Dim controlToValidateIDs As String() = Me.GetControlsToValidateIDs()
            If controlToValidateIDs.Length < 2 Then
                Throw New HttpException(String.Format("The ControlsToValidate property of {0} has less than two IDs.", Me.ID))
            End If

            For Each controlToValidateID As String In controlToValidateIDs
                MyBase.CheckControlValidationProperty(controlToValidateID, "ControlsToValidate")
            Next

            Return True
        End Function

        Protected Overrides Function EvaluateIsValid() As Boolean

            Dim controlToValidateIDs As String() = Me.GetControlsToValidateIDs()

            Select Case Condition
                Case Conditions.[OR]
                    For Each controlToValidateID As String In controlToValidateIDs
                        Dim controlToValidateValue As String = MyBase.GetControlValidationValue(controlToValidateID)
                        controlToValidateValue = If(controlToValidateValue Is Nothing, String.Empty, controlToValidateValue.Trim())
                        If controlToValidateValue <> String.Empty Then
                            Return True
                        End If
                    Next
                    Return False
                Case Conditions.[XOR]
                    ' Taking the initial values
                    Dim previousResult As Boolean = False
                    Dim passedFirstElement As Boolean = False
                    ' if one of the compared values is not like the other, then they are not all the same,
                    ' then they satisfy the XOR condition
                    For Each controlToValidateID As String In controlToValidateIDs
                        Dim controlToValidateValue As String = MyBase.GetControlValidationValue(controlToValidateID)
                        controlToValidateValue = If(controlToValidateValue Is Nothing, String.Empty, controlToValidateValue.Trim())
                        If Not passedFirstElement Then
                            previousResult = controlToValidateValue <> String.Empty
                            passedFirstElement = True
                            Continue For
                        End If
                        Dim currentResult As Boolean = controlToValidateValue <> String.Empty
                        If previousResult <> currentResult Then
                            Return True
                        End If
                        previousResult = currentResult
                    Next
                    Return False
                Case Conditions.[AND]
                    For Each controlToValidateID As String In controlToValidateIDs
                        Dim controlToValidateValue As String = MyBase.GetControlValidationValue(controlToValidateID)
                        controlToValidateValue = If(controlToValidateValue Is Nothing, String.Empty, controlToValidateValue.Trim())
                        If controlToValidateValue = String.Empty Then
                            Return False
                        End If
                    Next
                    Return True
                Case Else
                    ' This line shouldn't be reached
                    Throw New Exception("End of validation has been reached without a result!")
            End Select
        End Function

        Protected Overrides Sub OnPreRender(ByVal e As EventArgs)
            MyBase.OnPreRender(e)
            If MyBase.RenderUplevel Then
                Me.Page.ClientScript.RegisterClientScriptResource(GetType(MultipleFieldsValidator), "AdamTibi.Web.UI.Validators.WebUIValidationExtended.js")
            End If
        End Sub

#End Region

#Region "Helper Methods"

        Private Function GetControlsToValidateIDs() As String()
            Dim controlsToValidate As String = Me.ControlsToValidate.Replace(" ", "")
            Dim controlToValidateIDs As String()
            Try
                controlToValidateIDs = controlsToValidate.Split(","c)
            Catch ex As ArgumentOutOfRangeException
                Throw New FormatException(String.Format("The ControlsToValidate property of {0} is not well-formatted.", Me.ID), ex)
            End Try
            Return controlToValidateIDs
        End Function

        Private Function GenerateClientSideControlsToValidate() As String
            Dim controlToValidateIDs As String() = Me.GetControlsToValidateIDs()
            Dim controlToValidateIDTrimmed As String
            Dim controlRenderIDs As String = String.Empty
            For Each controlToValidateID As String In controlToValidateIDs
                controlToValidateIDTrimmed = controlToValidateID.Trim()
                If controlToValidateIDTrimmed = String.Empty Then
                    Throw New FormatException(String.Format("The ControlsToValidate property of {0} is not well-formatted.", Me.ID))
                End If
                controlRenderIDs += "," & MyBase.GetControlRenderID(controlToValidateIDTrimmed)
            Next
            controlRenderIDs = controlRenderIDs.Remove(0, 1)
            ' Removing the first ","
            Return controlRenderIDs
        End Function

#End Region

#Region "Properties"

        <Browsable(False)> _
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows Property SetFocusOnError() As Boolean
            Get
                Return False
            End Get
            Set(ByVal value As Boolean)
                Throw New NotSupportedException("SetFocusOnError is not supported because you have multiple controls to validate")
            End Set
        End Property

        <Browsable(False)> _
        <EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows Property ControlToValidate() As String
            Get
                Return String.Empty
            End Get
            Set(ByVal value As String)
                Throw New NotSupportedException("ControlToValidate is not supported because you have multiple controls to validate")
            End Set
        End Property

        ''' <summary>
        ''' Comma separated list of control IDs that you want to check
        ''' </summary>
        <Browsable(True)> _
        <Category("Behavior")> _
        <Themeable(False)> _
        <DefaultValue("")> _
        <Description("Comma separated list of control IDs that you want to check")> _
        Public Property ControlsToValidate() As String
            Get
                Return DirectCast(If(ViewState("ControlsToValidate"), String.Empty), String)
            End Get
            Set(ByVal value As String)
                ViewState("ControlsToValidate") = value
            End Set
        End Property

        ''' <summary>
        ''' The condition used to compare the value of the fields, 
        ''' e.g. 'OR', will return true if at least one field is valid
        ''' </summary>
        <Browsable(True)> _
        <Themeable(False)> _
        <Category("Behavior")> _
        <DefaultValue(Conditions.[OR])> _
        <Description("The condition used to compare the value of the fields, e.g. 'OR', will return true if at least one field is valid")> _
        Public Property Condition() As Conditions
            Get
                Return CType(If(ViewState("Condition"), Conditions.[OR]), Conditions)
            End Get
            Set(ByVal value As Conditions)
                ViewState("Condition") = value
            End Set
        End Property

#End Region

#Region "Enum"

        Public Enum Conditions
            ''' <summary>
            ''' OR condition
            ''' </summary>
            [OR]
            ''' <summary>
            ''' XOR Condition
            ''' </summary>
            [XOR]
            ''' <summary>
            ''' AND Condition
            ''' </summary>
            [AND]
        End Enum
#End Region
    End Class

End Namespace
