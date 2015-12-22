Public Class frmCatalog

    Public Sub setMode(strMode As String)
        'CONTROL THE DISPLAY OF LIST VS DETAIL OF CatalogS

        If strMode = "L" Then
            'MODE IS LIST

            Me.gbCatalogDetail.Hide()
            Me.gbCatalogList.Left = 0
            Me.gbCatalogList.Top = 0
            Me.Width = gbCatalogList.Width + 50
            Me.Height = gbCatalogList.Height + 50

            Me.gbCatalogList.Visible = True
        Else
            'MODE IS DETAIL

            Me.gbCatalogList.Hide()
            Me.gbCatalogDetail.Left = 0
            Me.gbCatalogDetail.Top = 0
            Me.Width = gbCatalogDetail.Width + 50
            Me.Height = gbCatalogDetail.Height + 50

            Me.gbCatalogDetail.Visible = True
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        setMode("D")
    End Sub

    Private Sub gbCatalogDetail_Enter(sender As Object, e As EventArgs) Handles gbCatalogDetail.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CPP_DB.dbOpen()

    End Sub
End Class