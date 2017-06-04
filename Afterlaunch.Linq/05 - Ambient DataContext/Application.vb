Imports KnowledgeCenter.DataAccess

Public Class Application
  ' Gemeinsam genutzer DataContext
  <ThreadStatic()> _
  Private Shared SharedContext As KnowledgeCenterDataContext

  ''' <summary>
  ''' Ruft den thread-aktuellen DataContext ab.
  ''' </summary>
  Private Shared Function GetContext() As KnowledgeCenterDataContext
    If SharedContext Is Nothing Then SharedContext = New KnowledgeCenterDataContext

    Return SharedContext
  End Function

  ''' <summary>
  ''' Gibt den Artikel mit der angegebenen Id zurück.
  ''' </summary>
  Public Shared Function GetArticleById(ByVal articleId As Integer) As Article
    ' Abfrage formulieren
    Dim articles = From x In GetContext.Articles Where x.Id = articleId

    ' Ersten Eintrag zurückgeben
    Return articles.FirstOrDefault
  End Function

  Public Shared Sub Main()
    ' Artikel abfragen
    Dim article As Article

    ' ================= Schritt 1 =================

    article = GetArticleById(218)

    ' Artikel ändern
    article.DateEdit = DateTime.Now

    ' Änderungen speichern
    GetContext.SubmitChanges()

    ' ================= Schritt 2 =================

    ' Artikel abfragen
    article = GetArticleById(218)

    ' DateEdit ausgeben
    Console.WriteLine("Letzte Änderung: {0}", article.DateEdit)

    Console.ReadLine()
  End Sub
End Class