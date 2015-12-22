Public Class frmMain

    'This class handles the main form UI and its events. 

    'CIS 338 - Project 2
    'Author: Alejandro Krasovsky
    'Due Date: Nov. 16, 2015
    Private x As Integer = 0
    Public controller As New clsController

    Private Sub mnuFileNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileNew.Click
        'Open the form
        Dim frm As frmChild
        frm = New frmChild
        x += 1
        frm.Text = "Order Form " & x
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        'Close the parent form
        Me.Close()
    End Sub

    Private Sub mnuFileClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileClose.Click
        'Close the application
        If Not Me.ActiveMdiChild Is Nothing Then
            Me.ActiveMdiChild.Close()
        End If
    End Sub

    Private Sub mnuFile_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFile.DropDownOpening
        If Not Me.ActiveMdiChild Is Nothing Then
            mnuFileClose.Enabled = True
        Else
            mnuFileClose.Enabled = False
        End If
    End Sub

    Private Sub mnuEditCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEditCut.Click
        Clipboard.SetText(CType(Me.ActiveMdiChild.ActiveControl, TextBox).SelectedText)
        CType(Me.ActiveMdiChild.ActiveControl, TextBox).SelectedText = ""
    End Sub

    Private Sub mnuEditCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEditCopy.Click
        Clipboard.SetText(CType(Me.ActiveMdiChild.ActiveControl, TextBox).SelectedText)
    End Sub

    Private Sub mnuEditPaste_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEditPaste.Click
        CType(Me.ActiveMdiChild.ActiveControl, TextBox).SelectedText = Clipboard.GetText
    End Sub

    Private Sub mnuEdit_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEdit.DropDownOpening
        'Disable the menus
        mnuEditCut.Enabled = False
        mnuEditCopy.Enabled = False
        mnuEditPaste.Enabled = False

        'Re-enable the menus accordingly
        If Not Me.ActiveMdiChild Is Nothing Then
            If TypeOf Me.ActiveMdiChild.ActiveControl Is TextBox Then
                If CType(Me.ActiveMdiChild.ActiveControl, TextBox).SelectedText <> "" Then
                    mnuEditCut.Enabled = True
                    mnuEditCopy.Enabled = True
                End If
                If Clipboard.GetText <> "" Then
                    mnuEditPaste.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub mnuWindowCascade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuWindowCascade.Click
        'Arrange windows cascading
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub mnuWindowHorizontal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuWindowHorizontal.Click
        'Arrange windows tiled horizontally
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub mnuWindowVertical_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuWindowVertical.Click
        'Arrange windows tiled vertically
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        ' get order number from user
        Dim orderNumber As String = InputBox("Enter order number: ", "Open Order")
        'open new child order form and retrieve order
        Dim child As frmChild
        child = New frmChild
        child.MdiParent = Me
        child.Text = "Order Form #" & orderNumber
        child.Show()
        child.txtID.Text = orderNumber
        child.btnOpen.PerformClick()




    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

        If Not Me.ActiveMdiChild Is Nothing Then
            Dim child As frmChild
            child = Me.ActiveMdiChild
            child.btnSave.PerformClick()
        End If


    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If Not Me.ActiveMdiChild Is Nothing Then
            Dim child As frmChild
            child = Me.ActiveMdiChild
            child.btnDelete.PerformClick()

        End If
    End Sub
End Class
