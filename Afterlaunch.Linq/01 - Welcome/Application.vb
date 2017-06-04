Imports KnowledgeCenter.DataAccess

Public Class Application

  Public Shared Sub Main()
    ' DataContext erstellen
    Using dbx = New KnowledgeCenterDataContext

      ' Artikel abfragen
      Dim articles = From x In dbx.Articles Where x.IsPublished _
                     Order By x.DateCreated Descending Take 5

      ' Ergebnis ausgeben
      For Each a In articles
        Console.WriteLine(a.Title)
      Next
    End Using

    Console.ReadLine()
  End Sub
End Class