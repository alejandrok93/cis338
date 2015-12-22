Public Class frmInstructor

    Dim instructorsList As New List(Of clsInstructor)
    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF InstructorS

        If strMode = "L" Then
            'MODE IS LIST

            Me.gbInstructorDetail.Hide()
            Me.gbInstructorList.Left = 0
            Me.gbInstructorList.Top = 0
            Me.Width = gbInstructorList.Width + 50
            Me.Height = gbInstructorList.Height + 50

            Me.gbInstructorList.Visible = True
        Else
            'MODE IS DETAIL

            Me.gbInstructorList.Hide()
            Me.gbInstructorDetail.Left = 0
            Me.gbInstructorDetail.Top = 0
            Me.Width = gbInstructorDetail.Width + 50
            Me.Height = gbInstructorDetail.Height + 50

            Me.gbInstructorDetail.Visible = True
        End If
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        setMode("D")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim aInstructor As New clsInstructor

        'Populate instructor object
        aInstructor.profID = PROF_IDTextBox.Text
        aInstructor.firstName = FIRST_NAMETextBox.Text
        aInstructor.lastName = LAST_NAMETextBox.Text
        aInstructor.phone = PHONETextBox.Text
        aInstructor.department = DEPARTMENTTextBox.Text


        'Add instructor to db
        CPP_DB.dbOpen()
        CPP_DB.addInstructor(aInstructor)

        'Check for errors
        If CPP_DB.dbGetError <> "" Then
            MessageBox.Show(CPP_DB.dbGetError)
        Else
            instructorsList.Add(aInstructor)                 'NO ERRORS ADD STUDENT TO LIST
            refreshDataGrid()                               'REFRESH GRID
            MessageBox.Show("Instructor Saved!")               'NOTIFY
            Me.setMode("L")                                 'SWITCH TO LIST MODE
        End If
    End Sub

    Private Sub refreshDataGrid()
        'CREATE A BINDING SOURCE AND 
        ' Dim StudentBindingSource As New BindingSource
        Dim InstructorBindingSource As New BindingSource

        'ASSIGN THE DATAROUCE TO THE STUDENT LIST
        'StudentBindingSource.DataSource = studentList
        InstructorBindingSource.DataSource = instructorsList

        'SET THE GRID DATASOURCE TO THE BINDING SOURCE
        ' Me.CPP_STUDENTSDataGridView.DataSource = StudentBindingSource
        Me.CPP_INSTRUCTORSDataGridView.DataSource = InstructorBindingSource
    End Sub

    Private Sub frmInstructor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'load from db
        CPP_DB.dbOpen()
        instructorsList = CPP_DB.loadInstructors()
        CPP_DB.dbClose()

        'CHECK ERRORS
        If (CPP_DB.dbGetError = "") Then
            refreshDataGrid()
        Else
            MessageBox.Show(CPP_DB.dbGetError)
        End If
    End Sub

    Private Sub CPP_INSTRUCTORSDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles CPP_INSTRUCTORSDataGridView.CellContentClick

    End Sub
End Class