Imports System.Web

''' <summary>
''' Provides methods for extended virtual path operations.
''' </summary>
Public NotInheritable Class VirtualPathExtension
    Private Sub New()

    End Sub

    ''' <summary>
    ''' Converts a virtual path to an absolute path with host prefix.
    ''' E.g. ~/default.aspx --> http://www.yourhost.com/app1/default.aspx
    ''' </summary>
    Public Shared Function ToAbsoluteWithHost(ByVal path As String) As String
        Dim absolutePath As String
        Dim relativePath As String

        ' Absolute Uri (includes host)
        absolutePath = HttpContext.Current.Request.Url.AbsoluteUri
        ' Absolute Uri (without host)
        relativePath = HttpContext.Current.Request.Url.PathAndQuery

        Dim host As String

        ' Extract host
        host = absolutePath.Substring(0, absolutePath.Length - relativePath.Length)

        Return String.Format("{0}{1}", host, VirtualPathUtility.ToAbsolute(path))
    End Function
End Class
