Imports System.Data.Linq
Imports System.Linq.Expressions

Public Interface IDataService(Of TContext As DataContext)
    Inherits IDisposable

    ''' <summary>
    ''' Gets the current DataContext associated with this DataService.
    ''' </summary>
    ReadOnly Property Context() As TContext

    ''' <summary>
    ''' Specifies which sub-objects to retrieve when a query is submitted for an object of type T.
    ''' </summary>
    Sub AttachLoadWith(Of T)(ByVal expression As Expression(Of Func(Of T, Object)))

    ''' <summary>
    ''' Persists changes to the database.
    ''' </summary>
    Sub SaveChanges()
End Interface