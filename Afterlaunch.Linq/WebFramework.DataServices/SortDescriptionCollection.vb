Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq

Public Class SortDescriptionCollection(Of TSource, TColumn)
    Inherits ReadOnlyCollection(Of SortDescription(Of TSource, TColumn))

    Private _HashCode As Integer

    Public Sub New(ByVal list As IList(Of SortDescription(Of TSource, TColumn)))
        MyBase.New(list)

        _HashCode = String.Join("|"c, (From item In Me Select Convert.ToString(item.GetIdentifier)).ToArray).GetHashCode()
    End Sub

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is SortDescriptionCollection(Of TSource, TColumn) Then Return False

        Return GetHashCode() = obj.GetHashCode
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return _HashCode
    End Function
End Class