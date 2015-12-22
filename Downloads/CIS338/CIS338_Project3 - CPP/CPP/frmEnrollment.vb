Public Class frmEnrollment

    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF EnrollmentS

        If strMode = "L" Then
            'MODE IS LIST

            Me.gbEnrollmentDetail.Hide()
            Me.gbEnrollmentList.Left = 0
            Me.gbEnrollmentList.Top = 0
            Me.Width = gbEnrollmentList.Width + 50
            Me.Height = gbEnrollmentList.Height + 50

            Me.gbEnrollmentList.Visible = True
        Else
            'MODE IS DETAIL

            Me.gbEnrollmentList.Hide()
            Me.gbEnrollmentDetail.Left = 0
            Me.gbEnrollmentDetail.Top = 0
            Me.Width = gbEnrollmentDetail.Width + 50
            Me.Height = gbEnrollmentDetail.Height + 50

            Me.gbEnrollmentDetail.Visible = True
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        setMode("D")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        setMode("L")
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        setMode("L")
    End Sub

    Private Sub BRONCO_IDComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles BRONCO_IDComboBox.SelectedIndexChanged

    End Sub
End Class