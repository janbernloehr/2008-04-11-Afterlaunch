Public Class Comment
    Private _Author As Author

    Public ReadOnly Property Author() As Author
        Get
            If _Author Is Nothing Then _Author = New Author(Me.AuthorName)

            Return _Author
        End Get
    End Property
End Class
