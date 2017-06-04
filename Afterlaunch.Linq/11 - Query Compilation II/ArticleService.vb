Imports KnowledgeCenter.DataAccess
Imports WebFramework.DataServices
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
  Private Shared ReadOnly RecentArticlesQuery As Expression(Of Func(Of KnowledgeCenterDataContext, IOrderedQueryable(Of Article))) _
      = Function(dbx As KnowledgeCenterDataContext) _
        From x In dbx.Articles Where x.IsPublished = True _
        Order By x.DateCreated Descending

  ''' <summary>
  ''' Gibt eine Liste der letzten 5 Artikel zurück.
  ''' </summary>
  Public Function GetRecentArticles() As List(Of Article)
    ' Query Expression holen
    Dim query = RecentArticlesQuery

    ' Sorting anhängen
    Dim sortedQuery = query.AttachSort(Function(data As IOrderedQueryable(Of Article)) _
                                          data.ThenBy(Function(a) a.Title))

    ' Expression Tree kompilieren
    Dim executeableQuery = CompiledQuery.Compile(sortedQuery)

    ' Query ausführen
    Dim articles = executeableQuery(GetContext)

    ' Ergebnisse zurückgeben
    Return articles.ToList
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