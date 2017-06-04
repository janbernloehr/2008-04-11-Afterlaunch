Imports KnowledgeCenter.DataAccess

Public Class Application
  Public Shared Sub Main()
    Dim article As Article

    Using sv = New ArticleService
      ' Artikel abfragen
      article = sv.GetArticleById(218)
    End Using

    Dim changed As Article
    Dim original As Article

    ' ASP.NET Response / Postback simulieren
    original = CopyObject(article)
    changed = CopyObject(article)

    ' Artikel ändern
    changed.Title = String.Format("Disconnected objects beim Afterlaunch {0}", _
                                  Date.Now.ToShortTimeString)

    Using sv = New ArticleService
      ' Änderungen mitteilen
      sv.UpdateArticle(changed, original)

      ' Speichern
      sv.SubmitChanges()
    End Using

    Console.ReadLine()
  End Sub

  Private Shared Function CopyObject(Of T)(ByVal obj As T) As T
    Dim s As New System.Runtime.Serialization.NetDataContractSerializer

    Using ms As New System.IO.MemoryStream
      s.Serialize(ms, obj)

      ms.Position = 0

      Return DirectCast(s.Deserialize(ms), T)
    End Using
  End Function

End Class