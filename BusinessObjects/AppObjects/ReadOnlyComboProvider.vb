Option Explicit On
Option Strict On
Option Compare Text

Imports System.ComponentModel
Imports System.Windows.Forms


<Drawing.ToolboxBitmap(GetType(System.Windows.Forms.TextBox)), _
System.ComponentModel.DesignerCategoryAttribute("Code"), _
ProvideProperty("ReadOnly", GetType(Control)), _
ProvideProperty("OrigDropDownStyle", GetType(Control))> _
Public Class ReadOnlyComboProvider
    Inherits System.ComponentModel.Component
    Implements IExtenderProvider

    'This hash table stores all the controls extended by this extender provider
    Friend htProvidedProperties As New Hashtable

#Region "IExtenderProvider"

    ''' <summary>
    ''' The Property should be Extend / Not for the TextBox classes
    ''' </summary>
    ''' <param name="extendee"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CanExtend(ByVal extendee As Object) As Boolean Implements System.ComponentModel.IExtenderProvider.CanExtend
        If TypeOf extendee Is ComboBox Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

#Region "Extensible Properties"

    Private Class ComboBoxProperties
        Public IsReadOnly As Boolean = False
        Public OrigComboBoxStyle As ComboBoxStyle = ComboBoxStyle.DropDown
    End Class

    <Category("Read Only Combobox Provider")> _
    Sub SetReadOnly(ByVal ctrl As Control, ByVal value As Boolean)
        Dim cbo As ComboBox = CType(ctrl, ComboBox)
        If value = True Then
            cbo.DropDownStyle = ComboBoxStyle.DropDown
        Else
            cbo.DropDownStyle = GetControlFromHashtable(ctrl).OrigComboBoxStyle
        End If
        GetControlFromHashtable(ctrl).IsReadOnly = value
    End Sub

    <Category("Read Only Combobox Provider")> _
    Function GetReadOnly(ByVal ctrl As Control) As Boolean
        Return GetControlFromHashtable(ctrl).IsReadOnly
    End Function

    <Category("Read Only Combobox Provider")> _
    Sub SetOrigDropDownStyle(ByVal ctrl As Control, ByVal value As ComboBoxStyle)
        GetControlFromHashtable(ctrl).OrigComboBoxStyle = value
    End Sub

    <Category("Read Only Combobox Provider")> _
    Function GetOrigDropDownStyle(ByVal ctrl As Control) As ComboBoxStyle
        Return GetControlFromHashtable(ctrl).OrigComboBoxStyle
    End Function

#End Region

#Region "Behavior"

    Private Function GetControlFromHashtable(ByVal ctrl As Control) As ComboBoxProperties
        If htProvidedProperties.Contains(ctrl) Then
            Return DirectCast(htProvidedProperties(ctrl), ComboBoxProperties)
        Else
            Dim ProvidedProperties As New ComboBoxProperties

            'Add A KeyPress Event Handler as the control is added to hash table
            AddHandler ctrl.KeyPress, AddressOf KeyPressHandler

            htProvidedProperties.Add(ctrl, ProvidedProperties)
            Return ProvidedProperties
        End If
    End Function

    Private Sub KeyPressHandler(ByVal sender As Object, ByVal e As KeyPressEventArgs)

        Dim cboSender As ComboBox = CType(sender, ComboBox)

        If GetControlFromHashtable(cboSender).IsReadOnly = True Then
            e.Handled = True
        Else
            e.Handled = False
        End If

    End Sub

#End Region

End Class






