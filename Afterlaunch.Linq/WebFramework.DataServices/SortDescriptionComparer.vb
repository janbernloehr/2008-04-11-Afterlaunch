Imports System.Collections.Generic
Imports System.Linq

Public Class SortDescriptionComparer(Of TColumn, TSource)
    Implements IEqualityComparer(Of SortDescription(Of TColumn, TSource)())

    Private Function EqualArrays(ByVal left As SortDescription(Of TColumn, TSource)(), ByVal right As SortDescription(Of TColumn, TSource)()) As Boolean
        If left.Count <> right.Count Then Return False
        If left.Count = 0 Then Return True

        For i As Integer = 0 To left.Count - 1
            If Not left(i) = right(i) Then Return False
        Next

        Return True
    End Function

    Public Function EqualityComparer_Equals(ByVal x() As SortDescription(Of TColumn, TSource), ByVal y() As SortDescription(Of TColumn, TSource)) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of SortDescription(Of TColumn, TSource)()).Equals
        Return EqualArrays(x, y)
    End Function

    Public Function EqualityComparer_GetHashCode(ByVal obj() As SortDescription(Of TColumn, TSource)) As Integer Implements System.Collections.Generic.IEqualityComparer(Of SortDescription(Of TColumn, TSource)()).GetHashCode
        Return String.Join("|", (From o In obj Select String.Format("{0}|{1}", o.Column, o.SortDescending)).ToArray).GetHashCode
    End Function
End Class