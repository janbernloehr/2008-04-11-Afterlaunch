Imports System.Runtime.CompilerServices

Public Module StringExtensions
    ''' <summary>
    ''' Replaces the format item in a specified System.String with the text equivalent of the value of a corresponding 
    ''' System.Object instance in a specified array and additionally '\n' with System.Environment.NewLine.
    ''' </summary>
    <Extension()> _
    Public Function FN(ByVal format As String) As String
        Return format.Replace("\n", Environment.NewLine)
    End Function

    ''' <summary>
    ''' Replaces the format item in a specified System.String with the text equivalent of the value of a corresponding 
    ''' System.Object instance in a specified array and additionally '\n' with System.Environment.NewLine.
    ''' </summary>
    <Extension()> _
    Public Function FN(ByVal format As String, ByVal arg0 As Object) As String
        Return String.Format(format, arg0).Replace("\n", Environment.NewLine)
    End Function

    ''' <summary>
    ''' Replaces the format item in a specified System.String with the text equivalent of the value of a corresponding 
    ''' System.Object instance in a specified array and additionally '\n' with System.Environment.NewLine.
    ''' </summary>
    <Extension()> _
    Public Function FN(ByVal format As String, ByVal arg0 As Object, ByVal arg1 As Object) As String
        Return String.Format(format, arg0, arg1).Replace("\n", Environment.NewLine)
    End Function

    ''' <summary>
    ''' Replaces the format item in a specified System.String with the text equivalent of the value of a corresponding 
    ''' System.Object instance in a specified array and additionally '\n' with System.Environment.NewLine.
    ''' </summary>
    <Extension()> _
    Public Function FN(ByVal format As String, ByVal arg0 As Object, ByVal arg1 As Object, ByVal arg2 As Object) As String
        Return String.Format(format, arg0, arg1, arg2).Replace("\n", Environment.NewLine)
    End Function

    ''' <summary>
    ''' Replaces the format item in a specified System.String with the text equivalent of the value of a corresponding 
    ''' System.Object instance in a specified array and additionally '\n' with System.Environment.NewLine.
    ''' </summary>
    <Extension()> _
    Public Function FN(ByVal format As String, ByVal ParamArray args() As Object) As String
        Return String.Format(format, args).Replace("\n", Environment.NewLine)
    End Function

    ''' <summary>
    ''' Replaces the format item in a specified System.String with the text equivalent of the value of a corresponding System.Object instance in a specified array.
    ''' </summary>
    <Extension()> _
    Public Function F(ByVal format As String, ByVal arg0 As Object) As String
        Return String.Format(format, arg0)
    End Function

    ''' <summary>
    ''' Replaces the format item in a specified System.String with the text equivalent of the value of a corresponding System.Object instance in a specified array.
    ''' </summary>
    <Extension()> _
    Public Function F(ByVal format As String, ByVal arg0 As Object, ByVal arg1 As Object) As String
        Return String.Format(format, arg0, arg1)
    End Function

    ''' <summary>
    ''' Replaces the format item in a specified System.String with the text equivalent of the value of a corresponding System.Object instance in a specified array.
    ''' </summary>
    <Extension()> _
    Public Function F(ByVal format As String, ByVal arg0 As Object, ByVal arg1 As Object, ByVal arg2 As Object) As String
        Return String.Format(format, arg0, arg1, arg2)
    End Function

    ''' <summary>
    ''' Replaces the format item in a specified System.String with the text equivalent of the value of a corresponding System.Object instance in a specified array.
    ''' </summary>
    <Extension()> _
    Public Function F(ByVal format As String, ByVal ParamArray args() As Object) As String
        Return String.Format(format, args)
    End Function

    ''' <summary>
    ''' Replaces the format item in a specified System.String with the text equivalent of the value of a corresponding System.Object instance in a specified array.
    ''' </summary>
    <Extension()> _
    Public Function IsNullOrEmpty(ByVal value As String) As Boolean
        Return String.IsNullOrEmpty(value)
    End Function


    ''' <summary>
    ''' Replaces the format item in a specified System.String with the text equivalent of the value of a corresponding System.Object instance in a specified array.
    ''' </summary>
    <Extension()> _
    Public Function LimitTo(ByVal value As String, ByVal maxlenght As Integer) As String
        If value.IsNullOrEmpty Then Return String.Empty

        If value.Length > maxlenght Then
            Return value.Substring(0, maxlenght)
        Else
            Return value
        End If
    End Function
    ''' <summary>
    ''' Replaces the format item in a specified System.String with the text equivalent of the value of a corresponding System.Object instance in a specified array.
    ''' </summary>
    <Extension()> _
    Public Function ShrinkTo(ByVal value As String, ByVal maxlenght As Integer, ByVal fill As String) As String
        If value.IsNullOrEmpty Then Return String.Empty

        If value.Length > maxlenght Then
            Return value.Substring(0, maxlenght) & fill
        Else
            Return value
        End If
    End Function
End Module
