Imports System.Web.Security
Imports System.Web.Profile
Imports WebFramework.Extensions

Public Class Author
    Private _Name As String
    Private _User As MembershipUser
    Private _Profile As ProfileBase

    Public Sub New(ByVal name As String)
        _User = Membership.GetUser(name)
        _Profile = ProfileBase.Create(name)
    End Sub

    Public ReadOnly Property Username() As String
        Get
            Return _User.UserName
        End Get
    End Property

    Public ReadOnly Property EmailAddress() As String
        Get
            Return _User.Email
        End Get
    End Property

    Public Property Biography() As String
        Get
            Return CStr(_Profile.GetPropertyValue("bio"))
        End Get
        Set(ByVal value As String)
            _Profile.SetPropertyValue("bio", value)
        End Set
    End Property

    Public Property WebAddress() As String
        Get
            Return CStr(_Profile.GetPropertyValue("webAddress"))
        End Get
        Set(ByVal value As String)
            _Profile.SetPropertyValue("webAddress", value)
        End Set
    End Property

    Public Property WeblogAddress() As String
        Get
            Return CStr(_Profile.GetPropertyValue("webLog"))
        End Get
        Set(ByVal value As String)
            _Profile.SetPropertyValue("webLog", value)
        End Set
    End Property

    Public Property ShowEmail() As Boolean
        Get
            Return CBool(_Profile.GetPropertyValue("showEmail"))
        End Get
        Set(ByVal value As Boolean)
            _Profile.SetPropertyValue("showEmail", value)
        End Set
    End Property

    Public Property Location() As String
        Get
            Return CStr(_Profile.GetPropertyValue("location"))
        End Get
        Set(ByVal value As String)
            _Profile.SetPropertyValue("location", value)
        End Set
    End Property

    Public Property Interests() As String
        Get
            Return CStr(_Profile.GetPropertyValue("interests"))
        End Get
        Set(ByVal value As String)
            _Profile.SetPropertyValue("interests", value)
        End Set
    End Property

    Public Property MsnIm() As String
        Get
            Return CStr(_Profile.GetPropertyValue("msnIM"))
        End Get
        Set(ByVal value As String)
            _Profile.SetPropertyValue("msnIM", value)
        End Set
    End Property

    Public Property YahooIM() As String
        Get
            Return CStr(_Profile.GetPropertyValue("yahooIM"))
        End Get
        Set(ByVal value As String)
            _Profile.SetPropertyValue("yahooIM", value)
        End Set
    End Property

    Public Property AolIM() As String
        Get
            Return CStr(_Profile.GetPropertyValue("aolIM"))
        End Get
        Set(ByVal value As String)
            _Profile.SetPropertyValue("aolIM", value)
        End Set
    End Property

    Public Property IcqIM() As String
        Get
            Return CStr(_Profile.GetPropertyValue("icqIM"))
        End Get
        Set(ByVal value As String)
            _Profile.SetPropertyValue("icqIM", value)
        End Set
    End Property

    Public Sub SaveChanges()
        _Profile.Save()
    End Sub

    Public ReadOnly Property ViewUrl() As String
        Get
            If _User Is Nothing Then Return Nothing

            Return "~/writers/{0}.aspx".F(Username)
        End Get
    End Property

    Public ReadOnly Property RssUrl() As String
        Get
            If _User Is Nothing Then Return Nothing

            Return "~/feed/writers/{0}.aspx".F(Username)
        End Get
    End Property
End Class
