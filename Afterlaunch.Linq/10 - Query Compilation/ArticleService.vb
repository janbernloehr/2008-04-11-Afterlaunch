Imports KnowledgeCenter.DataAccess
Imports System.Linq.Expressions
Imports System.Data.Linq

Public Class ArticleService
  Implements IDisposable

#Region " DataContext "

  Private _Context As KnowledgeCenterDataContext

  Private Function GetContext() As KnowledgeCenterDataContext
    If _Context Is Nothing Then _Context = New KnowledgeCenterDataContext : _Context.Log = Console.Out

    Return _Context
  End Function

#End Region

  ' Expression Tree generieren
  Private Shared ReadOnly RecentArticlesQuery As Expression(Of Func(Of KnowledgeCenterDataContext, Integer, IQueryable(Of Article))) _
      = Function(dbx As KnowledgeCenterDataContext, articleId As Integer) _
        From x In dbx.Articles Where x.Id = articleId

  ' Expression Tree nach Sql übersetzten
  Private Shared ReadOnly RecentArticlesCompiledQuery As Func(Of KnowledgeCenterDataContext, Integer, IQueryable(Of Article)) _
      = CompiledQuery.Compile(RecentArticlesQuery)

  ''' <summary>
  ''' Gibt eine Liste der letzten 5 Artikel zurück.
  ''' </summary>
  Public Function GetRecentArticles() As Article
    ' Abfrage formulieren

    Dim article = RecentArticlesCompiledQuery(GetContext, 218).FirstOrDefault


    ' Ergebnisse zurückgeben
    Return article
  End Function

  Public Function GetArticles(ByVal isDescending As Boolean) As List(Of Article)
    Dim articles = From x In GetContext.Articles

    If isDescending Then
      articles = From x In articles Order By x.Title Descending
    Else
      articles = From x In articles Order By x.Title
    End If
  End Function

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