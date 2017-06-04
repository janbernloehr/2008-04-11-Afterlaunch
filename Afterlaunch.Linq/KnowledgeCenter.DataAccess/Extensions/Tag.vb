Imports WebFramework.Extensions

Partial Public Class Tag
    Public ReadOnly Property Status() As TagStatus
        Get
            Select Case Score
                Case Is > 1 / 2
                    Return TagStatus.High
                Case Is > 1 / 4
                    Return TagStatus.Higher
                Case Is > 1 / 8
                    Return TagStatus.Normal
                Case Is > 1 / 16
                    Return TagStatus.Lower
                Case Is > 1 / 32
                    Return TagStatus.Low
            End Select
        End Get
    End Property

    Public ReadOnly Property FriendlyUrl() As String
        Get
            Return "{0}-{1}".F(Id, Name)
        End Get
    End Property

    Public ReadOnly Property ViewUrl() As String
        Get
            Return "~/tags/{0}.aspx".F(FriendlyUrl)
        End Get
    End Property

    Public ReadOnly Property RssUrl() As String
        Get
            Return "~/feed/tags/{0}.aspx".F(FriendlyUrl)
        End Get
    End Property
End Class

Public Enum TagStatus As Integer
    Low
    Lower
    Normal
    Higher
    High
End Enum