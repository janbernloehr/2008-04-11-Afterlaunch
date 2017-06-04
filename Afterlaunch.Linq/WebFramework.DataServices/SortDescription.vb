Imports System.Linq
Imports System.Linq.Expressions

Public MustInherit Class SortDescription(Of TSource, TColumn)
    Private ReadOnly _Column As TColumn
    Private ReadOnly _SortDescending As Boolean
    Private ReadOnly _HashCode As Integer

    Private ReadOnly _OrderByExpression As Expression(Of Func(Of IQueryable(Of TSource), IOrderedQueryable(Of TSource)))
    Private ReadOnly _ThenByExpression As Expression(Of Func(Of IOrderedQueryable(Of TSource), IOrderedQueryable(Of TSource)))

    Protected Sub New(ByVal col As TColumn, ByVal descending As Boolean)
        _Column = col
        _SortDescending = descending

        _OrderByExpression = CreateOrderByExpression()
        _ThenByExpression = CreateThenByExpression()

        _HashCode = String.Format("{0}|{1}", _Column, _SortDescending).GetHashCode
    End Sub

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is SortDescription(Of TSource, TColumn) Then Return False

        Return GetHashCode() = obj.GetHashCode
    End Function

    Friend Function GetIdentifier() As Integer
        Return _HashCode
    End Function

    Public Overrides Function GetHashCode() As Integer
        System.Diagnostics.Debug.WriteLine(String.Format("{0}: {1}", ToString, _HashCode))
        Return _HashCode
    End Function

    Public Shared Operator =(ByVal left As SortDescription(Of TSource, TColumn), ByVal right As SortDescription(Of TSource, TColumn)) As Boolean
        Return left.GetHashCode = right.GetHashCode
    End Operator

    Public Shared Operator <>(ByVal left As SortDescription(Of TSource, TColumn), ByVal right As SortDescription(Of TSource, TColumn)) As Boolean
        Return left.GetHashCode <> right.GetHashCode
    End Operator

    ReadOnly Property Column() As TColumn
        Get
            Return _Column
        End Get
    End Property

    ReadOnly Property SortDescending() As Boolean
        Get
            Return _SortDescending
        End Get
    End Property

    ReadOnly Property OrderByExpression() As Expression(Of Func(Of IQueryable(Of TSource), IOrderedQueryable(Of TSource)))
        Get
            Return _OrderByExpression
        End Get
    End Property

    ReadOnly Property ThenByExpression() As Expression(Of Func(Of IOrderedQueryable(Of TSource), IOrderedQueryable(Of TSource)))
        Get
            Return _ThenByExpression
        End Get
    End Property

    Protected MustOverride Function CreateOrderByExpression() As Expression(Of Func(Of IQueryable(Of TSource), IOrderedQueryable(Of TSource)))

    Protected MustOverride Function CreateThenByExpression() As Expression(Of Func(Of IOrderedQueryable(Of TSource), IOrderedQueryable(Of TSource)))

End Class