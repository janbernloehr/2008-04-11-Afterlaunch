Imports System.Collections.Generic
Imports WebFramework.Extensions

Partial Public Class Category
    Public Sub CreateFriendlyUrl()
        Dim friendly As String

        friendly = System.Text.RegularExpressions.Regex.Replace(Title, "\W+", "-")
        friendly.Trim("-"c)

        friendly = "{0}-{1}".F(Id, friendly.ToLower)

        FriendlyUrl = friendly
    End Sub

    Private _ChildCategories As List(Of Category)
    Public ReadOnly Property ChildCategories() As List(Of Category)
        Get
            If _ChildCategories Is Nothing Then _ChildCategories = New List(Of Category)

            Return _ChildCategories
        End Get
    End Property

    Public ReadOnly Property ViewUrl() As String
        Get
            Return "~/categories/{0}.aspx".F(FriendlyUrl)
        End Get
    End Property

    Public ReadOnly Property RssUrl() As String
        Get
            Return "~/feed/categories/{0}.aspx".F(FriendlyUrl)
        End Get
    End Property
End Class
