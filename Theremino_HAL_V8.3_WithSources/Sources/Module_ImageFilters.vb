
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D


Module Module_ImageFilters


    Friend Sub InitPictureboxImage(ByVal pbox As PictureBox)
        With pbox
            If .ClientSize.Width < 1 Or .ClientSize.Height < 1 Then Return
            .Image = New Bitmap(.ClientSize.Width, .ClientSize.Height)
        End With
    End Sub


    ' ================================================================================
    '  ROTATIONS
    ' ================================================================================

    Friend Function ImageRotate(ByRef img As Image, ByVal angle As Double) As Image
        Dim bmp As New Bitmap(img)
        Dim g As Graphics = Graphics.FromImage(bmp)
        ' --------------------------------------------------- rotate from the middle
        g.Clear(Color.White)
        g.ResetTransform()
        g.TranslateTransform(img.Width \ 2, img.Height \ 2)
        g.RotateTransform(CSng(angle))
        ' --------------------------------------------------- draw centered
        g.DrawImage(img, -bmp.Width \ 2, -bmp.Height \ 2)
        Return bmp
    End Function

    Friend Sub ImageRotateInPlace(ByRef img As Image, ByVal angle As Double)
        Dim bmp As New Bitmap(img)
        Dim g As Graphics = Graphics.FromImage(img)
        ' --------------------------------------------------- rotate from the middle
        g.Clear(Color.White)
        g.ResetTransform()
        g.TranslateTransform(bmp.Width \ 2, bmp.Height \ 2)
        g.RotateTransform(CSng(angle))
        ' --------------------------------------------------- draw centered
        g.DrawImage(bmp, -img.Width \ 2, -img.Height \ 2)
    End Sub



    Friend Sub ImageRotateWithPositions(ByRef img As Image, _
                                             ByRef DestImage As Image, _
                                             ByVal angle As Double, _
                                             ByVal RotX As Double, ByVal RotY As Double, _
                                             ByVal DrawX As Double, ByVal DrawY As Double)

        Dim g As Graphics = Graphics.FromImage(DestImage)
        SetQuality(g, 2)
        ' --------------------------------------------------- rotate point
        g.Clear(Color.White)
        g.ResetTransform()
        g.TranslateTransform(CSng(RotX), CSng(RotY))
        g.RotateTransform(CSng(angle))
        ' --------------------------------------------------- draw point
        g.DrawImage(img, -CSng(DrawX), -CSng(DrawY))
    End Sub


    Private Sub SetQuality(ByVal g As Graphics, ByVal nQuality As Int32)
        Select Case nQuality
            Case 1
                g.CompositingQuality = CompositingQuality.HighSpeed
                g.SmoothingMode = SmoothingMode.HighSpeed
                g.InterpolationMode = InterpolationMode.NearestNeighbor
            Case 2
                g.CompositingQuality = CompositingQuality.HighSpeed
                g.SmoothingMode = SmoothingMode.HighSpeed
                g.InterpolationMode = InterpolationMode.Low
            Case 3
                g.CompositingQuality = CompositingQuality.HighSpeed
                g.SmoothingMode = SmoothingMode.HighSpeed
                g.InterpolationMode = InterpolationMode.Bilinear
            Case 4
                g.CompositingQuality = CompositingQuality.HighSpeed
                g.SmoothingMode = SmoothingMode.HighSpeed
                g.InterpolationMode = InterpolationMode.HighQualityBilinear
            Case 5
                g.CompositingQuality = CompositingQuality.HighQuality
                g.SmoothingMode = SmoothingMode.HighQuality
                g.InterpolationMode = InterpolationMode.NearestNeighbor
            Case 6
                g.CompositingQuality = CompositingQuality.HighSpeed
                g.SmoothingMode = SmoothingMode.HighSpeed
                g.InterpolationMode = InterpolationMode.Bicubic
            Case 7
                g.CompositingQuality = CompositingQuality.HighQuality
                g.SmoothingMode = SmoothingMode.HighQuality
                g.InterpolationMode = InterpolationMode.Bicubic
            Case 8
                g.CompositingQuality = CompositingQuality.HighQuality
                g.SmoothingMode = SmoothingMode.HighQuality
                g.InterpolationMode = InterpolationMode.HighQualityBilinear
            Case 9
                g.CompositingQuality = CompositingQuality.HighQuality
                g.SmoothingMode = SmoothingMode.HighQuality
                g.InterpolationMode = InterpolationMode.HighQualityBicubic
                ' --------------------------------------------------------------- ( zero or > 9 ) 
            Case Else
                g.CompositingQuality = CompositingQuality.HighSpeed
                g.SmoothingMode = SmoothingMode.HighSpeed
                g.InterpolationMode = InterpolationMode.Low
        End Select
    End Sub

    Friend Function ImageResize(ByRef img As Image, ByVal w As Integer, ByVal h As Integer, ByVal quality As Int32) As Image
        Dim bmp As New Bitmap(w, h)
        Dim g As Graphics = Graphics.FromImage(bmp)
        SetQuality(g, quality)
        g.DrawImage(img, 0, 0, w + 1, h + 1)
        Return bmp
    End Function

    'Friend Sub ImageResizeInPlace(ByRef img As Image, ByVal w As Integer, ByVal h As Integer, ByVal quality As Int32)
    '    If img Is Nothing Then Exit Sub
    '    Dim bmp As New Bitmap(w, h)
    '    Dim g As Graphics = Graphics.FromImage(bmp)
    '    SetQuality(g, quality)
    '    g.DrawImage(img, 0, 0, w + 1, h + 1)
    '    img = bmp
    'End Sub

    Friend Sub ImageScrollInPlace(ByRef img As Image, ByVal dx As Integer, ByVal dy As Integer, ByVal quality As Int32)
        If img Is Nothing Then Exit Sub
        Dim bmp As New Bitmap(img.Width, img.Height)
        Dim g As Graphics = Graphics.FromImage(bmp)
        SetQuality(g, quality)
        g.DrawImage(img, dx, dy)
        img = bmp
    End Sub

End Module