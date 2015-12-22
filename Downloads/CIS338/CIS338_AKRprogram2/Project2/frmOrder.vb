Public Class frmChild

    'This class handles the order form UI and its events. It connects
    'to the controller class and gets data from there.

    'CIS 338 - Project 2
    'Author: Alejandro Krasovsky
    'Due Date: Nov. 16, 2015

    Private controller As clsController
    Private itemsMenu() As String
    Private itemsPrices() As String

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Save the order
        'We are going to use a combination of ArrayLists and Arrays to pass
        'All the order information to the business logic layer
        'By using this approach we use simple data structure to 
        'communicate between our objects

        'Create an Arraylist to hold all the order Info
        Dim orderList As New ArrayList

        Try
            orderList.Add(txtID.Text)   'Add Order ID
            orderList.Add(txtName.Text) 'Add Customer Name
            orderList.Add(txtphone.Text) 'Add phone number
            orderList.Add(txtDate.Text) ' Add date

            'Create an ArrayList to hold all the order detail info
            'for the first 3 lines
            Dim detailList As New ArrayList
            For i As Integer = 0 To 2
                'Create an Array to hold the information for each line item
                'Line Number, Item Description, Qty, Price
                Dim arrDetailItems(3) As String
                arrDetailItems(0) = Me.Panel1.Controls("lblLine" & (i + 1)).Text
                arrDetailItems(1) = Me.Panel1.Controls("cboItem" & (i + 1)).Text
                arrDetailItems(2) = Me.Panel1.Controls("txtQty" & (i + 1)).Text
                arrDetailItems(3) = Me.Panel1.Controls("txtPrice" & (i + 1)).Text

                'Add the array to our Detail arraylist
                detailList.Add(arrDetailItems)
            Next

            'Add the detail arraylist to the order arraylist
            orderList.Add(detailList)

            'Save the order
            controller.Save(orderList)

            'Check for errors
            If controller.getError <> "" Then

                'Display the list of all errors
                MessageBox.Show(controller.getError, "Error saving order", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else

                'Loop through each detail line
                'and retrieve the total for that line
                'use the order ID and the line ID to identify
                'the order and the line item
                For i As Integer = 0 To 2
                    Me.Panel1.Controls("lblTotal" & (i + 1)).Text = FormatCurrency(controller.getLineTotal(txtID.Text, i + 1))
                Next



                '=== Add code below here to display totals
                txtsTotal.Text = FormatCurrency(controller.getSubTotal(txtID.Text))
                txtTax.Text = FormatCurrency(controller.getTax(txtID.Text))
                txtTotal.Text = FormatCurrency(controller.getTotal(txtID.Text))


            End If

        Catch ex As Exception
            'Anything else
            MessageBox.Show(ex.Message, "Error Saving Item", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnRetrieve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click, btnOpen.Click
        'Retrieve the order
        Dim orderinfo As ArrayList
        Dim orderDetailList As ArrayList
        Try
            orderinfo = controller.Retrieve(txtID.Text)
            txtID.Text = orderinfo(0)
            txtName.Text = orderinfo(1)
            txtphone.Text = orderinfo(2)
            txtDate.Text = orderinfo(3)

            orderDetailList = orderinfo(4)

            Dim arrDetail As String()
            For i As Integer = 0 To orderDetailList.Count - 1
                arrDetail = orderDetailList.Item(i)
                Me.Panel1.Controls("cboItem" & (i + 1)).Text = arrDetail(1)
                Me.Panel1.Controls("txtQty" & (i + 1)).Text = arrDetail(2)
                Me.Panel1.Controls("txtPrice" & (i + 1)).Text = FormatCurrency(arrDetail(3))
                Me.Panel1.Controls("lblTotal" & (i + 1)).Text = FormatCurrency(arrDetail(4))
            Next

            txtsTotal.Text = FormatCurrency(controller.getSubTotal(txtID.Text))
            txtTax.Text = FormatCurrency(controller.getTax(txtID.Text))

            txtTotal.Text = FormatCurrency(orderinfo(5))


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub frmChild_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Connect to the parent controller object
        'Child object doesn't create a new controller object
        'but instead uses the instace available in the parent form
        controller = CType(Me.ParentForm, frmMain).controller

        'Load menu into comboboxes

        itemsMenu = controller.getMenu()
        itemsPrices = controller.getPrices()

        cboItem1.Items.AddRange(itemsMenu)
        cboItem2.Items.AddRange(itemsMenu)
        cboItem3.Items.AddRange(itemsMenu)


    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'Delete order using an ID
        'You can also clear all the data from the form
        'TODO: clear all the controls on the form

        Try
            controller.Delete(txtID.Text)
            MsgBox("Deleted Order #" & txtID.Text & vbCrLf, , "Order Deleted")
            Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Deleting Item")
        End Try
    End Sub

    Private Sub Clear()

        'Clear all controls
        txtID.Clear()
        txtName.Clear()
        txtphone.Clear()
        txtDate.Clear()


        cboItem1.SelectedIndex = -1
        txtQty1.Clear()
        txtPrice1.Clear()
        lblTotal1.ResetText()

        cboItem2.SelectedIndex = -1
        txtQty2.Clear()
        txtPrice2.Clear()
        lblTotal2.ResetText()

        cboItem3.SelectedIndex = -1
        txtQty3.Clear()
        txtPrice3.Clear()
        lblTotal3.ResetText()

        txtTotal.Clear()
        txtsTotal.Clear()
        txtTax.Clear()
        txtdelivery.Clear()

        txtbCity.Clear()
        txtbStreet.Clear()
        txtbState.Clear()
        txtbZip.Clear()
        txtsCity.Clear()
        txtsStreet.Clear()
        txtsState.Clear()
        txtsZip.Clear()

    End Sub

    Private Sub cboItem1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItem1.SelectedIndexChanged
        If cboItem1.SelectedIndex <> -1 Then
            txtPrice1.Text = itemsPrices(cboItem1.SelectedIndex)
        End If
    End Sub

    Private Sub cboItem2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItem2.SelectedIndexChanged
        If cboItem2.SelectedIndex <> -1 Then
            txtPrice2.Text = itemsPrices(cboItem2.SelectedIndex)
        End If
    End Sub

    Private Sub cboItem3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItem3.SelectedIndexChanged
        If cboItem3.SelectedIndex <> -1 Then
            txtPrice3.Text = itemsPrices(cboItem3.SelectedIndex)
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Clear()
    End Sub


    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtbZip.TextChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        txtsStreet.Text = txtbStreet.Text
        txtsCity.Text = txtbCity.Text
        txtsState.Text = txtbState.Text
        txtsZip.Text = txtbZip.Text
    End Sub

End Class
