Imports KnowledgeCenter.DataAccess

Public Class ArticleService
  Implements IDisposable

#Region " DataContext "

  Private _Context As KnowledgeCenterDataContext

  Private Function GetContext() As KnowledgeCenterDataContext
    If _Context Is Nothing Then _Context = New KnowledgeCenterDataContext : _Context.Log = Console.Out

    Return _Context
  End Function

#End Region

  ''' <summary>
  ''' Gibt den Artikel mit der angegebenen Id zurück.
  ''' </summary>
  Public Function GetArticleById(ByVal articleId As Integer) As Article
    ' Abfrage formulieren
    Dim articles = From x In GetContext.Articles Where x.Id = articleId

    ' Ersten Eintrag zurückgeben
    Return articles.FirstOrDefault
  End Function

  ''' <summary>
  ''' Änderungen an Datenbank senden.
  ''' </summary>
  Public Sub SubmitChanges()
    GetContext.SubmitChanges()
  End Sub

#Region " IDisposable Support "
  Private disposedValue As Boolean = False    ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(ByVal disposing As Boolean)
    If Not Me.disposedValue Then
      If disposing Then
        If _Context IsNot Nothing Then _Context.Dispose() : _Context = Nothing
      End If
    End If
    Me.disposedValue = True
  End Sub

  ' This code added by Visual Basic to correctly implement the disposable pattern.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub
#End Region

End Class
