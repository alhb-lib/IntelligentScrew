Imports System.Drawing.Drawing2D

Module Module_Utils

    Friend Sub InitPictureboxImage(ByVal pbox As PictureBox)
        With pbox
            If .ClientSize.Width < 1 Or .ClientSize.Height < 1 Then Return
            If .Image Is Nothing OrElse .Image.Width <> .ClientSize.Width _
                                 OrElse .Image.Height <> .ClientSize.Height Then
                .Image = New Bitmap(.ClientSize.Width, _
                                    .ClientSize.Height, _
                                    Imaging.PixelFormat.Format24bppRgb)
            End If
        End With
    End Sub

    Friend Function CreateFillBrush(ByVal pbox As PictureBox, _
                                    ByVal angle As Single, _
                                    ByVal blend As Int32) As LinearGradientBrush
        If pbox.ClientRectangle.Width < 1 Or _
           pbox.ClientRectangle.Height < 1 Then
            Return Nothing
        End If
        CreateFillBrush = New LinearGradientBrush(pbox.ClientRectangle, _
                                                  Color.Black, _
                                                  Color.Black, _
                                                  angle)
        Dim myBlend As ColorBlend = New ColorBlend()
        Select Case blend
            Case 1
                myBlend.Positions = New Single() {0.0F, 0.4F, 0.5F, 0.6F, 1.0F}
                myBlend.Colors = New Color() {Color.FromArgb(255, 0, 0), _
                                              Color.FromArgb(255, 230, 0), _
                                              Color.FromArgb(250, 250, 0), _
                                              Color.FromArgb(230, 230, 0), _
                                              Color.FromArgb(0, 100, 0)}

            Case 2
                myBlend.Positions = New Single() {0.0F, 0.4F, 0.5F, 0.9F, 1.0F}
                myBlend.Colors = New Color() {Color.FromArgb(200, 250, 150), _
                                              Color.FromArgb(80, 150, 100), _
                                              Color.FromArgb(80, 150, 0), _
                                              Color.FromArgb(80, 150, 0), _
                                              Color.FromArgb(250, 0, 0)}
            Case Else
                myBlend.Positions = New Single() {0.0F, 0.4F, 0.5F, 0.9F, 1.0F}
                myBlend.Colors = New Color() {Color.FromArgb(205, 205, 205), _
                                              Color.FromArgb(40, 150, 150), _
                                              Color.FromArgb(0, 150, 150), _
                                              Color.FromArgb(0, 120, 120), _
                                              Color.FromArgb(0, 80, 80)}

        End Select
        CreateFillBrush.InterpolationColors = myBlend
    End Function

    'Friend Function ExtractFirstWord(ByVal s As String) As String
    '    If s = Nothing Then Return ""
    '    s = s.Replace(vbTab, " ").Trim
    '    Dim i As Int32 = s.IndexOf(" ")
    '    If i < 0 Then Return s
    '    Return s.Substring(0, i)
    'End Function
    Friend Function RemoveComments(ByVal s As String) As String
        Dim i As Int32 = s.IndexOf("'")
        If i > 0 Then s = s.Remove(i).TrimEnd
        If i = 0 Then s = ""
        Return s
    End Function


    ' =========================================================================
    '   "SUSPEND REDRAW" HELPER
    ' =========================================================================
    Private Const WM_SETREDRAW As Int32 = 11
    Public Sub SuspendRedraw(ByVal cnt As Control)
        Dim msgSuspendUpdate As Message
        msgSuspendUpdate = Message.Create(cnt.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero)
        NativeWindow.FromHandle(cnt.Handle).DefWndProc(msgSuspendUpdate)
    End Sub
    Public Sub ResumeRedraw(ByVal cnt As Control)
        Dim msgResumeUpdate As Message
        msgResumeUpdate = Message.Create(cnt.Handle, WM_SETREDRAW, New IntPtr(1), IntPtr.Zero)
        NativeWindow.FromHandle(cnt.Handle).DefWndProc(msgResumeUpdate)
        cnt.Invalidate()
    End Sub


End Module
