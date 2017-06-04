Imports System.Collections.Generic
Imports WebFramework.Extensions

Partial Public Class Article
    Private _Author As Author

    Public Shared ReadOnly LevelDescriptions As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)

    Shared Sub New()
        LevelDescriptions.Add(0, My.Resources.LevelBeginnerCaption)
        LevelDescriptions.Add(1, My.Resources.LevelIntermediateCaption)
        LevelDescriptions.Add(2, My.Resources.LevelAdvancedCaption)
    End Sub

    ''' <summary>
    ''' Gets the author of an Article.
    ''' </summary>
    Public Overridable ReadOnly Property Author() As Author
        Get
            If _Author Is Nothing Then _Author = New Author(Me.AuthorName)

            Return _Author
        End Get
    End Property

    ''' <summary>
    ''' Gets the spoken name of the Article's knowledge level.
    ''' </summary>
    Public ReadOnly Property LevelName() As String
        Get
            If LevelDescriptions.ContainsKey(Level) Then
                Return LevelDescriptions(Level)
            Else
                Return Nothing
            End If
        End Get
    End Property

    ''' <summary>
    ''' Gets the url where the article is localted.
    ''' </summary>
    Public ReadOnly Property ViewUrl() As String
        Get
            Return "~/articles/{0}.aspx".F(FriendlyUrl)
        End Get
    End Property

    ''' <summary>
    ''' Updates the FriendlyUrl property of an Article.
    ''' Schema: "yyyy/MM/dd/Id-EscapedTitle"
    ''' </summary>
    Public Sub CreateFriendlyUrl()
        Dim friendly As String

        friendly = System.Text.RegularExpressions.Regex.Replace(Title, "\W+", "-")
        friendly.Trim("-"c)

        friendly = "{0:0000}/{1:00}/{2:00}/{3}-{4}".F(DateCreated.Year, DateCreated.Month, DateCreated.Day, Id, friendly.ToLower)

        FriendlyUrl = friendly
    End Sub
End Class
