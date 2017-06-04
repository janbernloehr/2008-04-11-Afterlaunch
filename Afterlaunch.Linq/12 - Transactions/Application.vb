Imports System.Configuration
Imports KnowledgeCenter.DataAccess

Public Class Application
  Public Shared Sub Main()
    Dim article As KnowledgeCenter.DataAccess.Article

    Using tcx = New System.Transactions.TransactionScope

      Using connection = New SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("AppDatabase").ConnectionString)
        ' Verbindung herstellen und halten
        connection.Open()

        Using dbx = New KnowledgeCenterDataContext(connection)
          ' Artikel mit Id 218 holen
          Article = (From x In dbx.Articles Where x.Id = 218).FirstOrDefault

          ' Titel anzeigen
          Console.WriteLine(" OldTitle: {0}", Article.Title)

          ' Title aktualisieren
          Article.Title = "Transaction 1"

          Console.WriteLine(" NewTitle: {0}", Article.Title)

          ' Änderungen speichern
          dbx.SubmitChanges()

          Article.Title = "Transaction 2"

          dbx.SubmitChanges()
        End Using
      End Using

      tcx.Complete()
    End Using

    Console.ReadLine()
  End Sub
End Class