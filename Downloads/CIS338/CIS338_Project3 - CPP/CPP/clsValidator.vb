Public Class clsValidator




    Public Function isValidString(s As String) As Boolean
        Dim result As Boolean = False

        If (s.Length > 0) Then
            result = True
        End If
        Return result

    End Function

    Public Function isValidNumber(s As String) As Boolean
        Dim i As Integer
        Dim result As Boolean = False
        If (Integer.TryParse(s, i) = True AndAlso i >= 0) Then
            result = True
        End If

        Return result

    End Function

    Public Function isValidPhoneNumber(s As String) As Boolean
        Dim bResult As Boolean
        Dim tmp As Integer
        Try
            Dim chars As Char() = s.ToCharArray()
            Dim count As Integer
            For count = 0 To chars.GetLength(0) - 1

                If (Integer.TryParse(chars(count), tmp)) Then
                    bResult = True
                Else
                    bResult = False
                End If
            Next

            If (chars.GetLength(0) = 10) Then
                bResult = True
            Else

                bResult = False
            End If
        Catch ex As Exception

            bResult = False
        End Try
        Return bResult
    End Function


End Class
