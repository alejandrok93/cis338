Public Class frmCourse

    Dim courseList As New List(Of clsCourse)
    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF CourseS

        If strMode = "L" Then
            'MODE IS LIST

            Me.gbCourseDetail.Hide()
            Me.gbCourseList.Left = 0
            Me.gbCourseList.Top = 0
            Me.Width = gbCourseList.Width + 50
            Me.Height = gbCourseList.Height + 50

            Me.gbCourseList.Visible = True
        Else
            'MODE IS DETAIL

            Me.gbCourseList.Hide()
            Me.gbCourseDetail.Left = 0
            Me.gbCourseDetail.Top = 0
            Me.Width = gbCourseDetail.Width + 50
            Me.Height = gbCourseDetail.Height + 50

            Me.gbCourseDetail.Visible = True
        End If
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSave.Click



        'Create course object
        Dim aCourse As New clsCourse

        'populate course info
        aCourse.courseID = COURSE_IDTextBox.Text
        aCourse.description = DESCRIPTIONTextBox.Text
        aCourse.units = UNITSTextBox.Text

        'save course to db
        CPP_DB.dbOpen()
        CPP_DB.addCourse(aCourse)

        'CHECK FOR ERRORS
        If CPP_DB.dbGetError <> "" Then
            MessageBox.Show(CPP_DB.dbGetError)
        Else

            refreshDataGrid()                               'REFRESH GRID
            MessageBox.Show("Student Saved!")               'NOTIFY
            Me.setMode("L")                                 'SWITCH TO LIST MODE
        End If

    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        setMode("D")
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click



    End Sub

    Private Sub frmCourse_Load(sender As Object, e As EventArgs) Handles Me.Load

        'LOAD FROM DB
        CPP_DB.dbOpen()

        courseList = CPP_DB.loadCourses()
        CPP_DB.dbClose()

        'CHECK ERRORS
        If (CPP_DB.dbGetError = "") Then
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub

    Private Sub refreshDataGrid()
        'CREATE A BINDING SOURCE AND 
        ' Dim StudentBindingSource As New BindingSource
        Dim CourseBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE STUDENT LIST
        '  StudentBindingSource.DataSource = studentList
        CourseBindingSource.DataSource = courseList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        ' Me.CPP_STUDENTSDataGridView.DataSource = StudentBindingSource
        Me.CPP_COURSESDataGridView.DataSource = CourseBindingSource
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim row As DataGridViewRow = Me.CPP_COURSESDataGridView.CurrentRow

        'check to see if row is selected
        If IsNothing(row) Then
            MessageBox.Show("No row is selected")
            Exit Sub
        End If


        Dim aCourse As clsCourse = TryCast(row.DataBoundItem, clsCourse)

        'call methods do delete from db
        CPP_DB.dbOpen()
        CPP_DB.deleteCourse(aCourse.courseID)
        CPP_DB.dbClose()

        'check for errors
        If CPP_DB.dbGetError = "" Then
            MessageBox.Show("Course Deleted!")
            'remove course from list
            For Each course In courseList
                If course.courseID = aCourse.courseID Then
                    courseList.Remove(course)
                    Exit For
                End If
            Next
            'refresh grid
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub
End Class