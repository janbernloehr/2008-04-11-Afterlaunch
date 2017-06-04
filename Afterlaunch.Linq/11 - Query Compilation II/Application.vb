Imports KnowledgeCenter.DataAccess

Public Class Application
  Public Shared Sub Main()
    Dim articles As List(Of Article)

    Using sv = New ArticleService
      ' Artikel abfragen
      articles = sv.GetRecentArticles()
    End Using

    For Each article In articles
      Console.WriteLine(article.Title)
    Next

    Console.ReadLine()
  End Sub
End Class