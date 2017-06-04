Imports KnowledgeCenter.DataAccess

Public Class Application
  Public Shared Sub Main()

    ' ================= Schritt 1 =================

    Using sv = New ArticleService
      ' Artikel abfragen
      Dim article1 = sv.GetArticleById(218)

      ' Artikel ändern
      article1.DateEdit = DateTime.Now

      ' Änderungen speichern
      sv.SubmitChanges()
    End Using

    ' ================= Schritt 2 =================

    Using sv = New ArticleService
      ' Artikel abfragen
      Dim article2 = sv.GetArticleById(218)

      Console.WriteLine("Letzte Änderung: {0}", article2.DateEdit)
    End Using

    Console.ReadLine()
  End Sub
End Class