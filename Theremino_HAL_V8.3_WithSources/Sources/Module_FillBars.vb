Imports System.Drawing.Drawing2D

Module Module_FillBars

    ' =======================================================================================
    '  FILL PICTURE BOX - WITH SINGLE COLOR
    ' =======================================================================================
    Friend Sub FillPictureBox(ByVal pbox As PictureBox, _
                              ByVal value As Double, _
                              ByVal c1 As Color, _
                              ByVal c2 As Color)
        ' ------------------------------------------------------- using a bitmap for best performance
        If pbox.Image Is Nothing Then
            InitPictureboxImage(pbox)
        End If
        ' -------------------------------------------------------
        If Double.IsNaN(value) Then value = 0
        If value < 0 Then value = 0
        If value > 1 Then value = 1
        Dim v As Int32 = CInt(value * pbox.ClientSize.Width)
        ' ------------------------------------------------------- using "Graphics.FromImage" for best performance
        Dim g As Graphics = Graphics.FromImage(pbox.Image)
        g.FillRectangle(New SolidBrush(c1), 0, 0, v, pbox.ClientSize.Height)
        g.FillRectangle(New SolidBrush(c2), v, 0, pbox.ClientSize.Width - v, pbox.ClientSize.Height)
        ' ------------------------------------------------------- final refresh - no flickering
        pbox.Invalidate()
    End Sub

    Friend Sub FillPictureBox_Horizontal(ByVal pbox As PictureBox, _
                                          ByVal value As Double, _
                                          ByVal c1 As Color, _
                                          ByVal c2 As Color)
        ' ------------------------------------------------------- using a bitmap for best performance
        If pbox.Image Is Nothing Then
            InitPictureboxImage(pbox)
        End If
        ' -------------------------------------------------------
        If Double.IsNaN(value) Then value = 0
        If value < 0 Then value = 0
        If value > 1 Then value = 1
        Dim v As Int32 = CInt(value * pbox.ClientSize.Width)
        ' ------------------------------------------------------- using "Graphics.FromImage" for best performance
        Dim g As Graphics = Graphics.FromImage(pbox.Image)
        g.FillRectangle(New SolidBrush(c1), 0, 0, v, pbox.ClientSize.Height)
        g.FillRectangle(New SolidBrush(c2), v, 0, pbox.ClientSize.Width - v, pbox.ClientSize.Height)
        '
        ' ------------------------------------------------------- final refresh - no flickering
        pbox.Refresh()
    End Sub

End Module
