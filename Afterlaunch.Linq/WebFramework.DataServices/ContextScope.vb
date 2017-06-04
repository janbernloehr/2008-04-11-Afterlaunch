Imports System.Diagnostics
Imports System.Data.Linq

''' <summary>
''' Provides access to a shared DataContext.
''' </summary>
''' <remarks>
''' The DataContext is instantiated when the Context property is requested.
''' </remarks>
Public MustInherit Class BaseContextScope(Of TContext As DataContext)
    Implements IDisposable

    Private _Context As TContext
    Private _ReferenceCount As Integer
    Private _Options As ContextDisposeOption

    Protected Sub New(ByVal options As ContextDisposeOption)
        _Options = options
    End Sub

    Protected MustOverride Function CreateContext(ByVal options As DataLoadOptions) As TContext

    ''' <summary>
    ''' Gets the DataContext associated with this ContextScope.
    ''' </summary>
    Friend ReadOnly Property Context() As TContext
        Get
            If _Context Is Nothing Then
                Debug.WriteLine("Creating DataContext ...", "DataServices")
                _Context = CreateContext(_LoadWithOptions)
            End If

            Return _Context
        End Get
    End Property

    ''' <summary>
    ''' Gets a value which indicates whether the DataContext managed by this Scope is 
    ''' referenced by one or more services.
    ''' </summary>
    Public ReadOnly Property IsReferenced() As Boolean
        Get
            Return _ReferenceCount > 0
        End Get
    End Property

    ''' <summary>
    ''' Gets a value indicating whether the DataContext has been created.
    ''' </summary>
    Public ReadOnly Property IsContextCreated() As Boolean
        Get
            Return _Context IsNot Nothing
        End Get
    End Property

    ''' <summary>
    ''' Increments the Reference Counter by one.
    ''' </summary>
    ''' <remarks>
    ''' Should be called by a Component which requires the DataContext managed by this Scope.
    ''' As long as the Reference Counter is greather than 0 the Scope ensures that the DataContext
    ''' won't be disposed.
    ''' As soon as the Reference Counter hits 0, the Context is disposed.
    ''' </remarks>
    Protected Friend Sub IncrementReferenceCounter()
        Debug.WriteLine("IncrementReferenceCounter", "DataServices")
        Threading.Interlocked.Increment(_ReferenceCount)
    End Sub

    ''' <summary>
    ''' Derements the Reference Counter by one.
    ''' </summary>
    ''' <remarks>
    ''' Should be called by a Component which called IncrementReferenceCounter after using the DataContext.
    ''' As long as the Reference Counter is greather than 0 the Scope ensures that the DataContext
    ''' won't be disposed.
    ''' As soon as the Reference Counter hits 0, the Context is disposed.</remarks>
    Protected Friend Sub DecrementReferenceCounter()
        Debug.WriteLine("DecrementReferenceCounter", "DataServices")
        If Threading.Interlocked.Decrement(_ReferenceCount) = 0 And _Options = ContextDisposeOption.ByReferenceCounter Then
            DisposeContext()
        End If
    End Sub

    Private _LoadWithOptions As DataLoadOptions

    ''' <summary>
    ''' Specifies which sub-objects to retrieve when a query is submitted for an object of type T.
    ''' </summary>
    Friend Sub AttachLoadWith(Of T)(ByVal expression As System.Linq.Expressions.Expression(Of System.Func(Of T, Object)))
        If IsContextCreated Then Throw New InvalidOperationException("LoadWithOptions cannot be attached to a created Context!")

        If _LoadWithOptions Is Nothing Then
            _LoadWithOptions = New System.Data.Linq.DataLoadOptions
        End If

        _LoadWithOptions.LoadWith(expression)
    End Sub

    Private Sub DisposeContext()
        If _Context IsNot Nothing Then
            Debug.WriteLine("Destroying DataContext ...", "DataServices")

            _Context.Dispose()
            _Context = Nothing
        End If
    End Sub

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not disposedValue And disposing Then
            Debug.WriteLine("Disposing Scope ...", "DataServices")
            DisposeContext()
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

Public Enum ContextDisposeOption
    ''' <summary>
    ''' ContextScope counts the Services referencing the DataContext.
    ''' As soon as the counter hits zero, the DataContext is disposed. When 
    ''' the next service requests a DataContext a new one is instantiated.
    ''' </summary>
    ByReferenceCounter

    ''' <summary>
    ''' ContextScope keeps the DataContext alive until the Scope is
    ''' disposed.
    ''' </summary>
    Explicit
End Enum