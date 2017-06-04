Imports System.Data.Linq
Imports System.Linq.Expressions

''' <summary>
''' Provides a base set of functionality for classes which offer linq-to-sql data services.
''' </summary>
Public MustInherit Class BaseDataService(Of TContext As DataContext)
    Implements IDataService(Of TContext)

    ' The Scope whice provides access to a single DataContext across different services.
    Private _Scope As BaseContextScope(Of TContext)

    Protected Sub New(ByVal scope As BaseContextScope(Of TContext))
        _Scope = scope
        _Scope.IncrementReferenceCounter()
    End Sub

    ''' <summary>
    ''' Gets the DataContext provided by the associated ContextScope.
    ''' </summary>
    Public ReadOnly Property Context() As TContext Implements IDataService(Of TContext).Context
        Get
            Return _Scope.Context
        End Get
    End Property

    Protected disposedValue As Boolean = False        ' To detect redundant calls

    ''' <summary>
    ''' Specifies which sub-objects to retrieve when a query is submitted for an object of type T.
    ''' </summary>
    Public Overridable Sub AttachLoadWith(Of T)(ByVal expression As Expression(Of Func(Of T, Object))) Implements IDataService(Of TContext).AttachLoadWith
        _Scope.AttachLoadWith(Of T)(expression)
    End Sub

    ''' <summary>
    ''' Persists changes to the database.
    ''' </summary>
    Public Overridable Sub SaveChanges() Implements IDataService(Of TContext).SaveChanges
        Context.SubmitChanges()
    End Sub

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not disposedValue And disposing Then
            If Not _Scope Is Nothing Then _Scope.DecrementReferenceCounter()
        End If

        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class