Public Class clsController

    'This class is the controller and manages connection between 
    'the logic of the program and the user interface classes

    'CIS 338 - Project 2
    'Author: Alejandro Krasovsky
    'Due Date: Nov. 16, 2015

    'Collection to hold our orders
    Private colOrders As New Hashtable
    Private anOrder As clsOrder
    Private strError As String

    Public Sub Save(ByVal OrderInfoList As ArrayList)
        'Check to see if order is already saved
        'If that's the case ask to duplicate order

        Dim duplicate As Boolean = False
        If colOrders.Contains(OrderInfoList(0)) Then

            Dim tmp As Integer
            'get button clicked 6 is yes 7 is no
            tmp = MsgBox("Order already exists. Do you want to override order?", MsgBoxStyle.YesNo, "Duplicate Order")

            If (tmp = 6) Then
                'If user clicks yes remove current order from hash table and then continue to create new one
                colOrders.Remove(OrderInfoList(0))
                duplicate = True

            ElseIf (tmp = 7) Then
                addError("ID: Dupplicate Order ID (Order exists already!)")
                Exit Sub
            End If

        End If

        'Create an order object an Order
        Dim order As New clsOrder

        'Clear the Class error variable
        strError = ""

        Try

            'Store the Order
            order.ID = OrderInfoList(0)                     '0
            order.CustomerName = OrderInfoList(1)           '1
            order.PhoneNumber = OrderInfoList(2)            '2
            order.aDate = OrderInfoList(3)                  '3

            'Store the detail
            order.AddDetail(OrderInfoList(4))               '4

            'Check for errors
            If order.getError = "" Then
                colOrders.Add(order.ID, order)
            Else
                addError(order.getError)
            End If

        Catch ex As Exception
            'Add anything we haven't handeled to our
            'Class error message
            addError(ex.Message)
        End Try
    End Sub

    Public Sub Delete(ByVal anID As String)
        'Delete an Order
        If colOrders.Contains(anID) = False Then
            Throw New ApplicationException("Item not found (ID:" & anID & ")")
        Else
            colOrders.Remove(anID)


        End If

    End Sub



    Public Function getLineTotal(ByVal anID As String, ByVal iLine As Integer) As Decimal
        'Check to see if the collection hold the order by using the order id
        If colOrders.Contains(anID) Then

            'Load the order into a myOrder object
            Dim myOrder As clsOrder = CType(colOrders.Item(anID), clsOrder)

            'execute the getLineTotal method of the Order
            Return myOrder.getLineTotal(iLine)
        Else
            addError("ID: Cannot Retrieve Detail for Order")
            Return -1
        End If
    End Function

    Public Function getSubTotal(anID As String) As Decimal
        'return the order sub total
        Dim order As New clsOrder
        order = colOrders.Item(anID)
        Return order.getSubTotal()
    End Function
    Public Function getTax(anID As String) As Decimal
        'return the order tax
        Dim order As New clsOrder
        order = colOrders.Item(anID)
        Return order.getTax()
    End Function
    Public Function getTotal(ByVal anID As String) As Decimal
        'return the order total
        Dim order As New clsOrder
        order = colOrders.Item(anID)
        Return order.getTotal()
    End Function

    Public Function Retrieve(ByVal anID As String) As ArrayList
        'Retrieve an Order
        Dim order As New clsOrder
        Dim orderInfo As New ArrayList
        Try
            'get the order object
            order = colOrders.Item(anID)

            'retrieve the order header info
            orderInfo.Add(order.ID)
            orderInfo.Add(order.CustomerName)
            orderInfo.Add(order.PhoneNumber)
            orderInfo.Add(order.aDate)


            'retrieve the order detail info
            orderInfo.Add(order.GetDetail())

            'retrieves the order total
            orderInfo.Add(order.getTotal())



        Catch ex As Exception
            'If there is not matching order
            'return an error
            If IsNothing(order) Then
                Throw New ApplicationException("Item not found, ID: " & anID)
            Else
                'Any other error push back up the stack
                Throw
            End If
        End Try

        Return orderInfo
    End Function

    Public Function getMenu() As String()
        'return the menu
        Dim menu() As String = {"Ghost", "Hornet", "Chopper", "Banshee"}

        Return menu
    End Function

    Public Function getPrices() As String()
        'return the prices
        Dim prices() As String = {"3000.33", "2000.99", "1000.99", "4000.99"}

        Return prices
    End Function

    Private Sub addError(ByVal s As String)
        'Add an error to the error list
        If strError = "" Then
            strError = s
        Else
            strError += vbCrLf & s
        End If
    End Sub

    Public Function getError() As String
        'return all errors for this object
        Return strError
    End Function
End Class
