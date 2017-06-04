Imports KnowledgeCenter.DataAccess

Public Class Application
  ' Gemeinsam genutzer DataContext
  Private Shared SharedContext As KnowledgeCenterDataContext

  Public Shared Function GetArticleById(ByVal articleId As Integer) As Article
    ' Abfrage erstellen
    Dim articles = From x In SharedContext.Articles Where x.Id = articleId

    ' Ersten Eintrag zurückgeben
    Return articles.FirstOrDefault
  End Function

  Public Shared Sub Main()
    SharedContext = New KnowledgeCenterDataContext

    ' Artikel abfragen
    Dim article As Article

    ' ================= Schritt 1 =================

    article = GetArticleById(218)

    ' Artikel ändern
    article.DateEdit = DateTime.Now

    ' Änderungen speichern
    SharedContext.SubmitChanges()

    ' ================= Schritt 2 =================

    ' Artikel abfragen
    Article = GetArticleById(218)

    ' DateEdit ausgeben
    Console.WriteLine("Letzte Änderung: {0}", Article.DateEdit)

    Console.ReadLine()
  End Sub
End Class