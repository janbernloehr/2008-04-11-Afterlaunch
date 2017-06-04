Imports KnowledgeCenter.DataAccess

Public Class Application

  ''' <summary>
  ''' Gibt eine Liste der letzten 5 Artikel zurück.
  ''' </summary>
  Public Shared Function GetRecentArticles() As List(Of Article)
    Dim daten As List(Of Article)

    Using dbx = New KnowledgeCenterDataContext
      ' Logging aktivieren
      dbx.Log = Console.Out

      Console.WriteLine("Query erstellen")

      ' Abfrage erstellen
      Dim articles = From x In dbx.Articles Where x.IsPublished

      Console.WriteLine("Query erweitern")

      ' Abfrage nach Datum sortieren
      articles = From x In articles _
                 Order By x.DateCreated Descending

      ' Abfrage auf 5 Ergebnisse beschränken
      articles = From x In articles Take 5

      Console.WriteLine("Query ausführen")


      ' Abfrage ausführen
      daten = articles.ToList
    End Using

    Return daten
  End Function

  Public Shared Sub Main()
    ' Artikel abfragen
    Dim articles = GetRecentArticles()

    ' Ergebnis ausgeben
    For Each a In articles
      Console.WriteLine(a.Title)
    Next

    Console.ReadLine()
  End Sub
End Class
