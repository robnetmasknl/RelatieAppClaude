Imports System.Security.AccessControl
Public Class clsPermission

    Private URights As UserRights = UserRights.Instance

    Public Sub setIBBPermissions(dossiernr As String)
        Try
            Dim SystemFolderPath As New Systeeminstellingen("IBBFiles", Systeeminstellingen.Via.ZOEKNAAM, Systeeminstellingen.eBond.ALLEN)

            Dim slash As String = String.Empty
            If Not SystemFolderPath.Waarde.EndsWith("\") Then slash = "\"

            Dim FolderPath As String = SystemFolderPath.Waarde & slash & dossiernr
            Dim UserAccount As String = URights.UserName '"netmask\bert" 

            Dim DossierDir As New IO.DirectoryInfo(FolderPath)
            If Not DossierDir.Exists Then DossierDir.Create()


            Dim FolderInfo As IO.DirectoryInfo = New IO.DirectoryInfo(FolderPath)
            Dim FolderAcl As New DirectorySecurity

            FolderAcl.AddAccessRule(New FileSystemAccessRule(UserAccount, FileSystemRights.Modify, InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow))
            'FolderAcl.SetAccessRuleProtection(True, False) 'verwijderd alle andere rechten
            FolderInfo.SetAccessControl(FolderAcl)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub



End Class
'https://www.experts-exchange.com/questions/21022265/Programmatically-VB-NET-set-NTFS-folder-permission-help.html

'Imports ADSSECURITYLib
'Imports System.Diagnostics
'Imports Scripting
'Imports ActiveDs
'Public Class manage_ntfs
'    Inherits System.Windows.Forms.Form

'    Private components As System.ComponentModel.IContainer
'    Sub SetPermissions(ByRef vPath As String, ByVal UserName As String)

'        Dim objDAcl As AccessControlList
'        Dim objAce As Object
'        Dim objAce1 As AccessControlEntry
'        Dim objAce2 As AccessControlEntry
'        Dim objSId As ADsSID
'        Dim objSIdHex As Object
'        Dim right As ADS_RIGHTS_ENUM
'        Dim sid As ADS_SID_FORMAT
'        Dim ace As ADS_ACETYPE_ENUM
'        Dim acef As ADS_ACEFLAG_ENUM
'        Dim objSecDes
'        Dim objADsSec

'        objADsSec = New ADsSecurity()
'        objSecDes = CType(objADsSec.GetSecurityDescriptor(vPath), SecurityDescriptor)
'        objDAcl = CType(objSecDes.DiscretionaryAcl, AccessControlList)

'        objSId = New ADsSID()
'        objSId.SetAs(sid.ADS_SID_SAM, CStr(UserName))
'        objSIdHex = objSId.GetAs(sid.ADS_SID_SDDL)

'        ' Add a new objAce so that the User has Full Control on NTFS Files.
'        objAce1 = New AccessControlEntry()
'        objAce1.Trustee = CStr(objSIdHex)
'        objAce1.AccessMask = right.ADS_RIGHT_GENERIC_ALL
'        objAce1.AceType = ace.ADS_ACETYPE_ACCESS_ALLOWED
'        objAce1.AceFlags = acef.ADS_ACEFLAG_INHERIT_ACE Or acef.ADS_ACEFLAG_INHERIT_ONLY_ACE Or 1
'        objDAcl.AddAce(objAce1)

'        ' Add a new objAce so that the User has Full Control on NTFS Folders.
'        objAce2 = New AccessControlEntry()
'        objAce2.Trustee = CStr(objSIdHex)
'        objAce2.AccessMask = right.ADS_RIGHT_GENERIC_ALL
'        objAce2.AceType = ace.ADS_ACETYPE_ACCESS_ALLOWED
'        objAce2.AceFlags = acef.ADS_ACEFLAG_INHERIT_ACE Or 1
'        objDAcl.AddAce(objAce2)

'        objSecDes.DiscretionaryAcl = objDAcl
'        ' Set Permissions on the NTFS folder.
'        objADsSec.SetSecurityDescriptor(objSecDes)

'    End Sub
'End Class
