Imports System.Data.SqlClient
Public Class CPP_DB
    Private Shared cn As SqlConnection
    Private Shared strError As String

    Public Shared Function loadStudents() As List(Of clsStudent)
        'List of students that will be returned
        Dim studentList As New List(Of clsStudent)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From STUDENTS"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                'Add basic student information
                Dim aStudent As New clsStudent
                aStudent.broncoID = rdr("BRONCO_ID")
                aStudent.firstName = rdr("FIRST_NAME")
                aStudent.lastName = rdr("LAST_NAME")
                aStudent.email = rdr("EMAIL")
                aStudent.phone = rdr("PHONE")

                studentList.Add(aStudent)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return studentList
    End Function

    Public Shared Function loadCourses() As List(Of clsCourse)
        'List of courses that will be returned
        Dim coursesList As New List(Of clsCourse)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From COURSES"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                'Add basic course information
                Dim aCourse As New clsCourse
                aCourse.courseID = rdr("COURSE_ID")
                aCourse.description = rdr("DESCRIPTION")
                aCourse.units = rdr("UNITS")


                coursesList.Add(aCourse)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return coursesList
    End Function

    Public Shared Function loadInstructors() As List(Of clsInstructor)


        'List of courses that will be returned
        Dim instructorsList As New List(Of clsInstructor)

        'DB variables
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader

        'clear the errors
        strError = ""

        Try
            strSQL = "Select * From INSTRUCTORS"

            dbConnect()
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text
            rdr = cmd.ExecuteReader()

            Do While rdr.Read()
                'Add basic course information
                Dim aInstructor As New clsInstructor
                aInstructor.profID = rdr("PROF_ID")
                aInstructor.firstName = rdr("FIRST_NAME")
                aInstructor.lastName = rdr("LAST_NAME")
                aInstructor.phone = rdr("PHONE")
                aInstructor.department = rdr("DEPARTMENT")


                instructorsList.Add(aInstructor)
            Loop
        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try
        Return instructorsList
    End Function

    Public Shared Function deleteCourse(aCourseID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from COURSES where COURSE_ID = '" & aCourseID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            intResult = cmd.ExecuteNonQuery()

            If (intResult < 1) Then
                dbAddError("DELETE Failed, Student id " & aCourseID & " was not found!")
            End If

            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function


    Public Shared Function deleteStudent(strStudentID As String) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strSQL As String

        'Clear errors
        strError = ""

        'Delete from database
        Try
            strSQL = "Delete from STUDENTS where BRONCO_ID = '" & strStudentID & "'"

            dbConnect()
            cmd.Connection = cn
            cmd.CommandText = strSQL

            intResult = cmd.ExecuteNonQuery()

            If (intResult < 1) Then
                dbAddError("DELETE Failed, Student id " & strStudentID & " was not found!")
            End If

            dbClose()
        Catch ex As Exception
            dbAddError("DELETE Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Sub updateStudent(aStudent As clsStudent)
        strError = ""

        'To update we remove old student and add new student
        'there are other ways to do this as well using the update statement
        deleteStudent(aStudent.broncoID)
        insertStudent(aStudent)

        If strError <> "" Then
            strError = "Could not Update student " & aStudent.broncoID & vbCrLf & vbCrLf & strError
        End If
    End Sub

    Public Shared Function insertStudent(aStudent As clsStudent) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strStudentSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strStudentSQL = "INSERT INTO STUDENTS (BRONCO_ID, FIRST_NAME, LAST_NAME, PHONE, EMAIL) " &
                            "values('" & aStudent.broncoID & "','" & aStudent.firstName & "','" & aStudent.lastName & "','" & aStudent.phone & "', '" &
                            aStudent.email & "')"

            cmd.Connection = cn
            cmd.CommandText = strStudentSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function addInstructor(aInstructor As clsInstructor) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strInstructorSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strInstructorSQL = "INSERT INTO INSTRUCTORS (PROF_ID, FIRST_NAME, LAST_NAME, PHONE, DEPARTMENT) " &
                            "values('" & aInstructor.profID & "','" & aInstructor.firstName & "','" & aInstructor.lastName & "','" & aInstructor.phone & "', '" &
                            aInstructor.department & "')"

            cmd.Connection = cn
            cmd.CommandText = strInstructorSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function


    Public Shared Function addCourse(aCourse As clsCourse) As Integer
        'Result that will be returned
        Dim intResult As Integer = 0

        'DB variables
        Dim cmd As New SqlCommand
        Dim strCourseSQL As String

        'clear the errors
        strError = ""

        'insert into database
        Try
            dbConnect()
            strCourseSQL = "INSERT INTO COURSES (COURSE_ID, DESCRIPTION, UNITS) " &
                            "values('" & aCourse.courseID & "','" & aCourse.description & "','" & aCourse.units & "')"

            cmd.Connection = cn
            cmd.CommandText = strCourseSQL
            cmd.ExecuteNonQuery()

            dbClose()
        Catch ex As Exception
            dbAddError("Insert Failed " & vbCrLf & ex.Message)
        Finally
            cmd.Dispose()
        End Try

        Return intResult
    End Function

    Public Shared Function findStudent(strStudentID As String) As clsStudent
        'student that will be returned
        Dim aStudent As clsStudent = New clsStudent

        'db variables
        Dim cmd As SqlCommand
        Dim rdr As SqlDataReader
        Dim strSQL As String

        'clear error
        strError = ""

        Try
            Dim MyData As New ArrayList

            strSQL = "Select * From STUDENTS Where BRONCO_ID = '" & strStudentID & "'"
            cmd = New SqlCommand(strSQL, cn)
            cmd.CommandType = CommandType.Text

            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                aStudent.broncoID = rdr("BRONCO_ID")
                aStudent.firstName = rdr("FIRST_NAME")
                aStudent.lastName = rdr("LAST_NAME")
                aStudent.email = rdr("EMAIL")
                aStudent.phone = rdr("PHONE")
            Else
                dbAddError("Student not found")
            End If

        Catch ex As SqlException
            dbAddError(ex.Message)
        Catch ex As Exception
            dbAddError(ex.Message)
        End Try

        Return aStudent
    End Function

    Public Shared Sub dbOpen()
        'Only assign one reference to the connection
        If IsNothing(cn) Then
            cn = New SqlConnection
            ' "DESKTOP-STAF2AL\SQLEXPRESS"
            cn.ConnectionString = "Data Source=DESKTOP-STAF2AL\SQLEXPRESS;Initial Catalog=CPP;Integrated Security=True"
        End If
    End Sub

    Public Shared Sub dbConnect()
        'Only open if connection is closed
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
    End Sub

    Public Shared Sub dbClose()
        'Only close if open
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

    Private Shared Sub dbAddError(ByVal s As String)
        'build error
        If strError = "" Then
            strError = s
        Else
            strError += vbCrLf & s
        End If
    End Sub

    Public Shared Function dbGetError() As String
        'return error
        Return strError
    End Function
End Class
