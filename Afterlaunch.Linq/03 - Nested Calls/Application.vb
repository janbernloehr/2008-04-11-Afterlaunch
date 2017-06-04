Imports KnowledgeCenter.DataAccess

Public Class Application

  Public Shared Function GetArticleById(ByVal articleId As Integer) As Article
    Using dbx = New KnowledgeCenterDataContext
      ' Logging aktivieren
      dbx.Log = Console.Out

      ' Abfrage erstellen
      Dim articles = From x In dbx.Articles Where x.Id = articleId

      ' Ersten Eintrag zurückgeben
      Return articles.FirstOrDefault
    End Using
  End Function

  Public Shared Sub Main()
    Dim article As Article

    ' ================= Schritt 1 =================

    ' DataContext erstellen
    Using dbx = New KnowledgeCenterDataContext
      ' Logging aktivieren
      dbx.Log = Console.Out

      ' Artikel abfragen
      article = (From x In dbx.Articles Where x.Id = 218).FirstOrDefault

      ' Artikel ändern
      article.DateEdit = DateTime.Now

      ' Änderungen speichern
      dbx.SubmitChanges()
    End Using

    ' ================= Schritt 2 =================

    ' Artikel abfragen
    article = GetArticleById(218)

    ' DateEdit ausgeben
    Console.WriteLine("Letzte Änderung: {0}", article.DateEdit)

    Console.ReadLine()
  End Sub
End Class