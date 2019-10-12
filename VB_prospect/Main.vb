Imports System.Windows
Imports Theremino_HAL

Public Class Main
    'Dim SingalFrom As Theremino_SignalScope.Form1
    'SingalFrom = New Theremino_SignalScope.Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim HALForm As Theremino_HAL.Form1
        HALForm = New Theremino_HAL.Form1
        HALForm.Show()
        'HALForm.Form1_Load(HALForm, e)


        'HALForm.


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim SingalFrom As Theremino_SignalScope.Form1
        SingalFrom = New Theremino_SignalScope.Form1
        SingalFrom.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Utils.SendMessage.sendText("hello")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim SlotFrom As Theremino_SlotViewer.Form1
        SlotFrom = New Theremino_SlotViewer.Form1
        SlotFrom.Show()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'SlotFrom.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim therrminoSlots As ThereminoSlots
        therrminoSlots = New ThereminoSlots
        Dim slotValue As Integer
        slotValue = Me.slotValue.Text
        therrminoSlots.WriteSlot(1, slotValue)
    End Sub
End Class
