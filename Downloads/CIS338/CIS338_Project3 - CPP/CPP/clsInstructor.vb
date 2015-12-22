Public Class clsInstructor
    Dim strProfID As String
    Dim strFirstName As String
    Dim strLastName As String
    Dim strPhone As String
    Dim strDepartment As String
    Dim validate As New clsValidator()

    Public Property profID As String
        Get
            Return strProfID
        End Get
        Set(value As String)
            If (validate.isValidString(value)) Then
                strProfID = value
            End If
        End Set
    End Property

    Public Property firstName As String
        Get
            Return strFirstName
        End Get
        Set(value As String)
            If (validate.isValidString(value)) Then
                strFirstName = value
            End If
        End Set
    End Property

    Public Property lastName As String
        Get
            Return strLastName
        End Get
        Set(value As String)
            If (validate.isValidString(value)) Then
                strLastName = value
            End If
        End Set
    End Property
    Public Property phone As String
        Get
            Return strPhone
        End Get
        Set(value As String)
            If (validate.isValidPhoneNumber(value)) Then
                strPhone = value
            End If
        End Set
    End Property
    Public Property department As String
        Get
            Return strDepartment
        End Get
        Set(value As String)
            If (validate.isValidString(value)) Then
                strDepartment = value
            End If
        End Set
    End Property


End Class
