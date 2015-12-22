Public Class clsCourse

    Dim strCourseID As String
    Dim strDescription As String
    Dim strUnits As String
    Dim validate As New clsValidator()
    Property courseID As String
        Get
            Return strCourseID
        End Get
        Set(value As String)
            If (validate.isValidString(value)) Then
                strCourseID = value
            End If
        End Set
    End Property

    Property description As String
        Get
            Return strDescription
        End Get
        Set(value As String)
            If (validate.isValidString(value)) Then
                strDescription = value
            End If
        End Set
    End Property

    Property units As String
        Get
            Return strUnits
        End Get
        Set(value As String)
            If (validate.isValidString(value)) Then
                strUnits = value
            End If
        End Set
    End Property


End Class
