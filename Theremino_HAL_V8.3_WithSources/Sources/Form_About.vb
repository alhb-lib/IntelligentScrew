Public Class Form_About

    Private Sub Form_About_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label2.Text = AppTitleAndVersion()
    End Sub

    Private Sub Button_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_OK.Click
        Close()
    End Sub

    Private Sub Label_OpenSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_OpenSite.Click
        Process.Start("http://www.theremino.com")
    End Sub

    Private Sub Label_SendInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label_SendInfo.Click
        Send_Mail("development@theremino.com", "Info on Theremino Theremin", "Dear Theremino team,\n\n")
    End Sub

    Private Sub Send_Mail(ByVal sendto As String, ByVal subject As String, ByVal body As String)
        subject = subject.Replace(" ", "%20")
        body = body.Replace("\n", "%0d%0a")
        body = body.Replace(" ", "%20")
        Shell("Cmd /C START MAILTO:" & sendto & """?subject=" & subject & "&body=" & body & """")
    End Sub

    Private Sub Labels_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
                                                                                        Label_OpenSite.MouseEnter, _
                                                                                        Label_SendInfo.MouseEnter
        Dim lb As Label = DirectCast(sender, Label)
        lb.BackColor = Color.FromArgb(250, 240, 255)
    End Sub

    Private Sub Labels_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
                                                                                        Label_OpenSite.MouseLeave, _
                                                                                        Label_SendInfo.MouseLeave
        Dim lb As Label = DirectCast(sender, Label)
        lb.BackColor = Color.Transparent
    End Sub


End Class