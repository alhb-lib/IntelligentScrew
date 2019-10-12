Imports System.Drawing.Drawing2D

Class Class_DataScope

    Private m_pbox As PictureBox
    Private g1 As Graphics
    Private oldy1 As Single = 1000000
    Private oldy2 As Single = 1000000
    Private py1 As Single
    Private py2 As Single
    Private px As Single
    Private py As Single
    Private ymid As Single
    Private speedCounter As Single = 0
    Private p1 As Pen = New Pen(Color.FromArgb(140, 140, 140))
    Private p2 As Pen = New Pen(Color.FromArgb(210, 210, 210))
    Private p3 As Pen = New Pen(Color.DarkBlue, 2)
    Private p4 As Pen = New Pen(Color.DarkRed, 2)
    Private ScaleIndex As Int32
    Private ScaleY As Single
    Private ScaleDeltaY As Single

    Friend Sub New(ByVal pbox As PictureBox)
        m_pbox = pbox
        px = m_pbox.ClientSize.Width - 1
        py = m_pbox.ClientSize.Height
        ymid = py / 2.0F
        ScaleDeltaY = py / 10.1F / 2
        ' ------------------------------------------------ main pbox
        InitPictureboxImage(m_pbox)
        g1 = Graphics.FromImage(m_pbox.Image)
        g1.Clear(m_pbox.BackColor)
        g1.CompositingQuality = CompositingQuality.HighSpeed
        g1.SmoothingMode = SmoothingMode.AntiAlias
        g1.InterpolationMode = InterpolationMode.Low
    End Sub

    Private TimeCounter As Int32
    Friend Sub Display(ByVal V1 As Single, ByVal V2 As Single, ByVal speed As Single)
        ' ----------------------------------------------------------- time scale
        If speed >= 6 Then
            TimeCounter += 1
            If TimeCounter >= 60 Then
                TimeCounter = 0
                g1.DrawLine(p2, px, 0, px, ScaleY)
            End If
        End If
        ' ----------------------------------------------------------- speed
        speedCounter += speed
        If speedCounter < 60 Then Return
        speedCounter -= 60
        ' ----------------------------------------------------------- remove possible errors
        If Single.IsNaN(V1) Then V1 = 100000
        If Single.IsNaN(V2) Then V2 = 100000
        If V1 < -100000 Then V1 = -100000
        If V2 < -100000 Then V2 = -100000
        If V1 > 100000 Then V1 = 100000
        If V2 > 100000 Then V2 = 100000
        ' ----------------------------------------------------------- draw scale divisions
        ScaleY = 1
        For ScaleIndex As Int32 = 0 To 10
            g1.DrawLine(p1, px, ScaleY, px + 1, ScaleY)
            ScaleY += ScaleDeltaY
            g1.DrawLine(p2, px, ScaleY, px + 1, ScaleY)
            ScaleY += ScaleDeltaY
        Next
        ' ----------------------------------------------------------- draw indicators
        py1 = ymid + 2.0F * V1
        py2 = ymid + 2.0F * V2
        If Math.Abs(oldy1 - py1) > 1000 Then oldy1 = py1
        If Math.Abs(oldy2 - py2) > 1000 Then oldy2 = py2
        g1.DrawLine(p3, px - 1, oldy1, px, py1)
        g1.DrawLine(p4, px - 1, oldy2, px, py2)
        oldy1 = py1
        oldy2 = py2
        If OperatingSystemIs_XP_or_Vista Then
            ' ------------------------------------------------------- clone only if XP or Vista
            g1.DrawImage(CType(m_pbox.Image.Clone, Image), -1, 0)
        Else
            ' ------------------------------------------------------- Linux or Windows7/8
            g1.DrawImage(m_pbox.Image, -1, 0)
        End If
        g1.DrawLine(Pens.AliceBlue, px, 0, px, py)
        m_pbox.Invalidate()
    End Sub

End Class
