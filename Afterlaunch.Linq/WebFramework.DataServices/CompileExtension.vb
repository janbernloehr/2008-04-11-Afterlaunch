Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Data.Linq
Imports System.Linq
Imports System.Linq.Expressions
Imports WebFramework.Extensions

Public Interface IQueryLogger
    Sub ClearLog()

    Sub LogCompilation(ByVal query As Expression)
    Sub LogExecution(ByVal query As String)
End Interface

Public Module CompileExtension
    ' Warum die Überladungen?
    ' GetCompiledQuery unterstützt Queries mit max. 3 Parametern.
    ' Für 0, 1, 2 und 3 Parameter wird jedoch eine eigene Funktion benötigt.

    ' Was passiert hier?
    ' Ist das IQueryables nicht im Dictionary vorhanden, wird es mit den übergebenen SortDescriptions versehen 
    ' und anschließend kompiliert.

    Private _Logger As IQueryLogger

    Public Sub RegisterLogger(ByVal logger As IQueryLogger)
        _Logger = logger
    End Sub

    Private Sub LogCompilation(ByVal query As Expression)
        If _Logger IsNot Nothing Then _Logger.LogCompilation(query)
    End Sub

    <System.Runtime.CompilerServices.Extension()> _
    Public Function GetCompiledQuery(Of TSource, TContext As DataContext, TColumn)(ByVal expression As Expression(Of Func(Of TContext, IQueryable(Of TSource))), ByVal dictionary As Dictionary(Of SortDescriptionCollection(Of TSource, TColumn), Func(Of TContext, IOrderedQueryable(Of TSource))), ByVal sortings As SortDescriptionCollection(Of TSource, TColumn)) As Func(Of TContext, IOrderedQueryable(Of TSource))
        If sortings Is Nothing Then Throw New ArgumentNullException("sortings")

        If dictionary.ContainsKey(sortings) Then
            Return dictionary(sortings)
        Else
            Dim appending As Boolean

            Dim query As Expression(Of Func(Of TContext, IOrderedQueryable(Of TSource))) = Nothing

            For Each s In sortings
                If Not appending Then
                    query = expression.AttachSort(s.OrderByExpression)
                Else
                    query = query.AttachSort(s.ThenByExpression)
                End If

                appending = True
            Next

            Debug.WriteLine("Compiling query: {0}".F(query), "DataServices")

            Dim compiled = System.Data.Linq.CompiledQuery.Compile(query)

            dictionary.Add(sortings, compiled)

            LogCompilation(query)

            Return compiled
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function GetCompiledQuery(Of TSource, TContext As DataContext, T1, TColumn)(ByVal expression As Expression(Of Func(Of TContext, T1, IQueryable(Of TSource))), ByVal dictionary As Dictionary(Of SortDescriptionCollection(Of TSource, TColumn), Func(Of TContext, T1, IOrderedQueryable(Of TSource))), ByVal sortings As SortDescriptionCollection(Of TSource, TColumn)) As Func(Of TContext, T1, IOrderedQueryable(Of TSource))
        If sortings Is Nothing Then Throw New ArgumentNullException("sortings")

        If dictionary.ContainsKey(sortings) Then
            Return dictionary(sortings)
        Else
            Dim appending As Boolean

            Dim query As Expression(Of Func(Of TContext, T1, IOrderedQueryable(Of TSource))) = Nothing

            For Each s In sortings
                If Not appending Then
                    query = expression.AttachSort(s.OrderByExpression)
                Else
                    query = query.AttachSort(s.ThenByExpression)
                End If

                appending = True
            Next

            Debug.WriteLine("Compiling query: {0}".F(query), "DataServices")

            Dim compiled = System.Data.Linq.CompiledQuery.Compile(query)

            dictionary.Add(sortings, compiled)

            LogCompilation(query)

            Return compiled
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function GetCompiledQuery(Of TSource, TContext As DataContext, T1, T2, TColumn)(ByVal expression As Expression(Of Func(Of TContext, T1, T2, IQueryable(Of TSource))), ByVal dictionary As Dictionary(Of SortDescriptionCollection(Of TSource, TColumn), Func(Of TContext, T1, T2, IOrderedQueryable(Of TSource))), ByVal sortings As SortDescriptionCollection(Of TSource, TColumn)) As Func(Of TContext, T1, T2, IOrderedQueryable(Of TSource))
        If sortings Is Nothing Then Throw New ArgumentNullException("sortings")

        If dictionary.ContainsKey(sortings) Then
            Return dictionary(sortings)
        Else
            Dim appending As Boolean

            Dim query As Expression(Of Func(Of TContext, T1, T2, IOrderedQueryable(Of TSource))) = Nothing

            For Each s In sortings
                If Not appending Then
                    query = expression.AttachSort(s.OrderByExpression)
                Else
                    query = query.AttachSort(s.ThenByExpression)
                End If

                appending = True
            Next

            Debug.WriteLine("Compiling query: {0}".F(query), "DataServices")

            Dim compiled = System.Data.Linq.CompiledQuery.Compile(query)

            dictionary.Add(sortings, compiled)

            LogCompilation(query)

            Return compiled
        End If
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function GetCompiledQuery(Of TSource, TContext As DataContext, T1, T2, T3, TColumn)(ByVal expression As Expression(Of Func(Of TContext, T1, T2, T3, IQueryable(Of TSource))), ByVal dictionary As Dictionary(Of SortDescriptionCollection(Of TSource, TColumn), Func(Of TContext, T1, T2, T3, IOrderedQueryable(Of TSource))), ByVal sortings As SortDescriptionCollection(Of TSource, TColumn)) As Func(Of TContext, T1, T2, T3, IOrderedQueryable(Of TSource))
        If sortings Is Nothing Then Throw New ArgumentNullException("sortings")

        If dictionary.ContainsKey(sortings) Then
            Return dictionary(sortings)
        Else
            Dim appending As Boolean

            Dim query As Expression(Of Func(Of TContext, T1, T2, T3, IOrderedQueryable(Of TSource))) = Nothing

            For Each s In sortings
                If Not appending Then
                    query = expression.AttachSort(s.OrderByExpression)
                Else
                    query = query.AttachSort(s.ThenByExpression)
                End If

                appending = True
            Next

            Debug.WriteLine("Compiling query: {0}".F(query), "DataServices")

            Dim compiled = System.Data.Linq.CompiledQuery.Compile(query)

            dictionary.Add(sortings, compiled)

            LogCompilation(query)

            Return compiled
        End If
    End Function
End Module