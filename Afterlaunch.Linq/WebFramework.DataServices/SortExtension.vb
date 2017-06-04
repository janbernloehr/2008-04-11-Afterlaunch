Imports System.Linq
Imports System.Linq.Expressions

Public Module SortExtension

  ' Okay, was passiert hier?
  ' Diese Extenion Methods erlauben es OrderBy, OrderByDescending, ThenBy oder ThenByDescending Queries
  ' an eine bestehende LINQ Query zu attachen.
  ' Die Grundlage dafür ist, dass sowohl die bestehende Query als auch die zu Attachende vom Typ
  ' Expression(Of Func(Of TSource, [T1, T2, T3,] TResult)) also einem Abgeleiteteten Typ von LambdaExpression sind.
  ' Die LambdaExpressions rufen direkt eine Methode (z.b. Select, OrderBy etc. auf) mittels einer MethodCallExpression auf.
  ' Darüberhinaus gibt die bestehende MethodCallExpression Daten von dem Typ zurück, den die Sort MethodCallExpression als
  ' Parameter erwartet. 
  ' Die AttachSort Methoden ersetzten nun den LambdaParameter in der Sort Expression durch die bestehende MethodCallExpression
  ' und erstellen aus den LambdaParametern der bestehenden Expression und dem neu geschaffenen Aufruf eine neue LambdaExpression.
  ' Diese wird dann noch gecastet und zurückgegeben.

  <System.Runtime.CompilerServices.Extension()> _
  Public Function AttachSort(Of TSource, TResult)(ByVal baseExpression As Expression(Of Func(Of TSource, IQueryable(Of TResult))), ByVal sortExpression As Expression(Of Func(Of IQueryable(Of TResult), IOrderedQueryable(Of TResult)))) As Expression(Of Func(Of TSource, IOrderedQueryable(Of TResult)))
    Dim baseBody As Expression = DirectCast(baseExpression.Body, Expression)
    Dim sortBody As MethodCallExpression = DirectCast(sortExpression.Body, MethodCallExpression)

    Return Expression.Lambda(Of Func(Of TSource, IOrderedQueryable(Of TResult)))(Expression.Call(sortBody.Method, baseBody, sortBody.Arguments(1)), baseExpression.Parameters.ToArray)
  End Function

  <System.Runtime.CompilerServices.Extension()> _
  Public Function AttachSort(Of TSource, TResult)(ByVal expression1 As Expression(Of Func(Of TSource, IOrderedQueryable(Of TResult))), ByVal expression2 As Expression(Of Func(Of IOrderedQueryable(Of TResult), IOrderedQueryable(Of TResult)))) As Expression(Of Func(Of TSource, IOrderedQueryable(Of TResult)))
    Dim m2 As MethodCallExpression = DirectCast(expression2.Body, MethodCallExpression)

    Return Expression.Lambda(Of Func(Of TSource, IOrderedQueryable(Of TResult)))(Expression.Call(m2.Method, expression1.Body, m2.Arguments(1)), expression1.Parameters.ToArray)
  End Function

  <System.Runtime.CompilerServices.Extension()> _
  Public Function AttachSort(Of TSource, T1, TResult)(ByVal expression1 As Expression(Of Func(Of TSource, T1, IQueryable(Of TResult))), ByVal expression2 As Expression(Of Func(Of IQueryable(Of TResult), IOrderedQueryable(Of TResult)))) As Expression(Of Func(Of TSource, T1, IOrderedQueryable(Of TResult)))
    Dim m2 As MethodCallExpression = DirectCast(expression2.Body, MethodCallExpression)

    Return Expression.Lambda(Of Func(Of TSource, T1, IOrderedQueryable(Of TResult)))(Expression.Call(m2.Method, expression1.Body, m2.Arguments(1)), expression1.Parameters.ToArray)
  End Function

  <System.Runtime.CompilerServices.Extension()> _
  Public Function AttachSort(Of TSource, T1, TResult)(ByVal expression1 As Expression(Of Func(Of TSource, T1, IOrderedQueryable(Of TResult))), ByVal expression2 As Expression(Of Func(Of IOrderedQueryable(Of TResult), IOrderedQueryable(Of TResult)))) As Expression(Of Func(Of TSource, T1, IOrderedQueryable(Of TResult)))
    Dim m2 As MethodCallExpression = DirectCast(expression2.Body, MethodCallExpression)

    Return Expression.Lambda(Of Func(Of TSource, T1, IOrderedQueryable(Of TResult)))(Expression.Call(m2.Method, expression1.Body, m2.Arguments(1)), expression1.Parameters.ToArray)
  End Function

  <System.Runtime.CompilerServices.Extension()> _
  Public Function AttachSort(Of TSource, T1, T2, TResult)(ByVal expression1 As Expression(Of Func(Of TSource, T1, T2, IQueryable(Of TResult))), ByVal expression2 As Expression(Of Func(Of IQueryable(Of TResult), IOrderedQueryable(Of TResult)))) As Expression(Of Func(Of TSource, T1, T2, IOrderedQueryable(Of TResult)))
    Dim m2 As MethodCallExpression = DirectCast(expression2.Body, MethodCallExpression)

    Return Expression.Lambda(Of Func(Of TSource, T1, T2, IOrderedQueryable(Of TResult)))(Expression.Call(m2.Method, expression1.Body, m2.Arguments(1)), expression1.Parameters.ToArray)
  End Function

  <System.Runtime.CompilerServices.Extension()> _
  Public Function AttachSort(Of TSource, T1, T2, TResult)(ByVal expression1 As Expression(Of Func(Of TSource, T1, T2, IOrderedQueryable(Of TResult))), ByVal expression2 As Expression(Of Func(Of IOrderedQueryable(Of TResult), IOrderedQueryable(Of TResult)))) As Expression(Of Func(Of TSource, T1, T2, IOrderedQueryable(Of TResult)))
    Dim m2 As MethodCallExpression = DirectCast(expression2.Body, MethodCallExpression)

    Return Expression.Lambda(Of Func(Of TSource, T1, T2, IOrderedQueryable(Of TResult)))(Expression.Call(m2.Method, expression1.Body, m2.Arguments(1)), expression1.Parameters.ToArray)
  End Function

  <System.Runtime.CompilerServices.Extension()> _
  Public Function AttachSort(Of TSource, T1, T2, T3, TResult)(ByVal expression1 As Expression(Of Func(Of TSource, T1, T2, T3, IQueryable(Of TResult))), ByVal expression2 As Expression(Of Func(Of IQueryable(Of TResult), IOrderedQueryable(Of TResult)))) As Expression(Of Func(Of TSource, T1, T2, T3, IOrderedQueryable(Of TResult)))
    Dim m2 As MethodCallExpression = DirectCast(expression2.Body, MethodCallExpression)

    Return Expression.Lambda(Of Func(Of TSource, T1, T2, T3, IOrderedQueryable(Of TResult)))(Expression.Call(m2.Method, expression1.Body, m2.Arguments(1)), expression1.Parameters.ToArray)
  End Function

  <System.Runtime.CompilerServices.Extension()> _
  Public Function AttachSort(Of TSource, T1, T2, T3, TResult)(ByVal expression1 As Expression(Of Func(Of TSource, T1, T2, T3, IOrderedQueryable(Of TResult))), ByVal expression2 As Expression(Of Func(Of IOrderedQueryable(Of TResult), IOrderedQueryable(Of TResult)))) As Expression(Of Func(Of TSource, T1, T2, T3, IOrderedQueryable(Of TResult)))
    Dim m2 As MethodCallExpression = DirectCast(expression2.Body, MethodCallExpression)

    Return Expression.Lambda(Of Func(Of TSource, T1, T2, T3, IOrderedQueryable(Of TResult)))(Expression.Call(m2.Method, expression1.Body, m2.Arguments(1)), expression1.Parameters.ToArray)
  End Function

End Module