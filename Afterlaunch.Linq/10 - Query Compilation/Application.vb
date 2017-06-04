Imports KnowledgeCenter.DataAccess

Public Class Application
  Public Shared Sub Main()
    Dim articles As List(Of Article)

    Using sv = New ArticleService
      ' Artikel abfragen
      Dim article = sv.GetRecentArticles()

      Console.WriteLine(article.Title)
    End Using

    Console.ReadLine()
  End Sub
End Class