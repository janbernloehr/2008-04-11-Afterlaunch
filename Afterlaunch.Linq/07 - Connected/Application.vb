Imports KnowledgeCenter.DataAccess

Public Class Application

  Public Shared Sub Main()
    Dim articleTitle As String

    ' Neuen Title holen (z.B. aus TextBox)
    articleTitle = String.Format("Connected objects beim Afterlaunch {0}", _
                                  Date.Now.ToShortTimeString)
    Dim article As Article

    Using sv = New ArticleService

      ' Artikel aus der Datenbank laden
      article = sv.GetArticleById(218)

      Console.WriteLine("Vorher: {0}", article.Title)

      ' Artikel ändern
      article.Title = articleTitle

      ' Änderungen speichern
      sv.SubmitChanges()

      Console.WriteLine("Nachher: {0}", article.Title)
    End Using

    Console.ReadLine()
  End Sub

End Class
