Imports System.Drawing.Drawing2D

Public Class SlotBar

    Private WithEvents pbox As PictureBox = New PictureBox()
    Private m_graphics As Graphics
    Private m_fillbrush As LinearGradientBrush
    Private m_backbrush As Brush
    Private m_width As Int32
    Private m_height As Int32
    Private m_max As Int32
    Private m_min As Int32
    Private m_colors As Int32
    Private m_vertical As Boolean
    Private m_slot As Int32
    Private m_text As String
    Private m_format As String
    Private m_value As Single
    Private m_stepmin As Single
    Private m_MousePressed As Boolean
    Private m_RightMousePressed As Boolean
    Private m_eventsenabled As Boolean = False
    Private Shared m_textfontV As Font = New Font("Arial", 7, FontStyle.Bold, GraphicsUnit.Point)
    Private Shared m_textfontH As Font = New Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point)
    Private Shared m_textfontFixed As Font = New Font("Courier New", 10, FontStyle.Bold, GraphicsUnit.Point)
    'Private Shared m_textfontFixed As Font = New Font("Lucida Console", 10, FontStyle.Bold, GraphicsUnit.Point)

    Friend Sub New(ByRef f As Form)
        pbox.Parent = f
        pbox.BackColor = Color.FromArgb(50, 60, 70)
        pbox.Anchor = AnchorStyles.Left Or AnchorStyles.Top
        f.Controls.Add(pbox)
    End Sub

    Friend Sub Destroy()
        pbox.Parent.Controls.Remove(pbox)
    End Sub

    Friend Sub SetAspectParams(ByVal x As Int32, _
                               ByVal y As Int32, _
                               ByVal w As Int32, _
                               ByVal h As Int32, _
                               ByVal vertical As Boolean, _
                               ByVal max As Int32, _
                               ByVal min As Int32, _
                               ByVal colors As Int32, _
                               ByVal nDecimals As Int32)
        m_eventsenabled = False
        m_vertical = vertical
        m_max = max
        m_min = min
        m_stepmin = Math.Abs(CInt((m_max - m_min) / 10.0F) / 100.0F)
        If m_stepmin = 0 Then m_stepmin = 0.1
        m_colors = colors
        m_format = "0." + StrDup(nDecimals, "0")
        pbox.Location = New Point(x, y)
        pbox.Width = w
        pbox.Height = h
        m_width = pbox.ClientSize.Width
        m_height = pbox.ClientSize.Height
        SetAspect()
        m_eventsenabled = True
    End Sub

    Friend Sub SetSlotIndex(ByVal slot As Int32)
        m_slot = slot
    End Sub

    Friend Sub SetText(ByVal s As String)
        m_text = s
    End Sub

    Private Sub pbox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbox.Resize
        If Not m_eventsenabled Then Return
        SetAspect()
    End Sub

    Private Sub SetAspect()
        InitPictureboxImage(pbox)
        If pbox.Image Is Nothing Then Return
        m_graphics = Graphics.FromImage(pbox.Image)
        m_backbrush = New SolidBrush(pbox.BackColor)
        If m_vertical Then
            Select Case m_colors
                Case 1 : m_fillbrush = CreateFillBrush(pbox, 90, 1)
                Case 2 : m_fillbrush = CreateFillBrush(pbox, 0, 2)
                Case Else : m_fillbrush = CreateFillBrush(pbox, 0, 3)
            End Select
            m_graphics.DrawLine(New Pen(pbox.Parent.BackColor), 0, 0, 0, m_height)
            m_graphics.FillRectangle(m_backbrush, 2, 1, m_width - 3, m_height - 2)
        Else
            Select Case m_colors
                Case 1 : m_fillbrush = CreateFillBrush(pbox, 180, 1)
                Case 2 : m_fillbrush = CreateFillBrush(pbox, 90, 2)
                Case Else : m_fillbrush = CreateFillBrush(pbox, 90, 3)
            End Select
            m_graphics.DrawLine(New Pen(pbox.Parent.BackColor), 0, 0, m_width, 0)
            m_graphics.FillRectangle(m_backbrush, 1, 2, m_width - 2, m_height - 3)
        End If
    End Sub

    Friend Sub SetFontSizes()
        Dim FontSizeV As Single
        Dim FontSizeH As Single
        Dim FontSizeF As Single
        '
        If m_vertical Then
            FontSizeV = pbox.Width * 0.32F + 2 '0.32F
            FontSizeH = pbox.Width * 0.43F + 2
            FontSizeF = pbox.Width * 0.46F + 2
        Else
            FontSizeV = pbox.Height * 0.32F + 2
            FontSizeH = pbox.Height * 0.43F + 2
            FontSizeF = pbox.Height * 0.46F + 2
        End If
        '
        If FontSizeV <> m_textfontV.Size Then
            m_textfontV = New Font("Arial", FontSizeV, FontStyle.Bold)
        End If
        If FontSizeH <> m_textfontH.Size Then
            m_textfontH = New Font("Tahoma", FontSizeH, FontStyle.Bold)
        End If
        If FontSizeF <> m_textfontFixed.Size Then
            m_textfontFixed = New Font("Courier New", FontSizeF, FontStyle.Bold)
        End If
    End Sub

    Friend Sub ShowValue()
        ' ------------------------------------------------------------ font sizes
        SetFontSizes()
        ' ------------------------------------------------------------ 
        Dim s As String
        Dim sz As SizeF
        Dim norm As Single
        If m_graphics Is Nothing Then Return
        If m_fillbrush Is Nothing Then Return
        ' ------------------------------------------------------------ prepare value as string
        If Single.IsNaN(m_value) Then
            norm = 0
            s = NAN_GetName(m_value)
        Else
            norm = (m_value - m_min) / (m_max - m_min)
            If norm > 1 Then norm = 1
            If norm < 0 Then norm = 0
            s = m_value.ToString(m_format, Globalization.CultureInfo.InvariantCulture)
        End If
        ' ------------------------------------------------------------ draw all
        If m_vertical Then
            Dim x As Single = m_width * 0.1F
            Dim y As Single = m_height * (1 - norm) + 1
            m_graphics.ResetTransform()
            m_graphics.FillRectangle(m_backbrush, 2, 1, m_width - 3, y - 1)
            m_graphics.FillRectangle(m_fillbrush, 2, y, m_width - 3, m_height - 1)
            m_graphics.DrawString(m_slot.ToString, m_textfontV, Brushes.Yellow, x, m_height - 6 - 5 * x)
            m_graphics.RotateTransform(-90)
            sz = TextRenderer.MeasureText(s, m_textfontH)
            m_graphics.DrawString(s, m_textfontH, Brushes.Yellow, -sz.Width + 3, x)
            If m_text IsNot Nothing Then
                m_graphics.DrawString(m_text, m_textfontFixed, Brushes.Yellow, -m_height + 6 + 5 * x, x)
            End If
        Else
            Dim x As Single = m_width * norm + 1
            Dim y As Single = m_height * 0.08F
            m_graphics.FillRectangle(m_fillbrush, 1, 2, x - 1, m_height - 3)
            m_graphics.FillRectangle(m_backbrush, x, 2, m_width - 1, m_height - 3)
            m_graphics.DrawString(m_slot.ToString, m_textfontH, Brushes.Yellow, 2, y)
            If m_text IsNot Nothing Then
                m_graphics.DrawString(m_text, m_textfontFixed, Brushes.Yellow, 12 * y + 8, y * 3.2F - 4)
            End If
            sz = TextRenderer.MeasureText(s, m_textfontH)
            m_graphics.DrawString(s, m_textfontH, Brushes.Yellow, m_width - sz.Width, y)
        End If
        pbox.Refresh()
    End Sub

    Friend Sub SetValue(ByVal value As Single)
        If Single.IsNaN(value) AndAlso Single.IsNaN(m_value) Then Return
        If value <> m_value Then
            m_value = value
            ShowValue()
        End If
    End Sub

    Friend Sub DeltaValue(ByVal delta As Single)
        Dim v As Single = m_value + delta * m_stepmin
        If v < m_min Then v = m_min
        If v > m_max Then v = m_max
        Slots.WriteSlot(m_slot, v)
    End Sub

    Private Sub pbox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbox.MouseDown
        Cursor.Clip = pbox.RectangleToScreen(pbox.ClientRectangle)
        m_MousePressed = True
        m_RightMousePressed = e.Button = MouseButtons.Right
        FollowCursor(e.Location)
    End Sub
    Private Sub pbox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbox.MouseMove
        If m_MousePressed Then
            FollowCursor(e.Location)
        End If
    End Sub
    Private Sub pbox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbox.MouseUp
        m_MousePressed = False
        Cursor.Clip = Nothing
        Form1.SetSelectedSlotBar(Me)
    End Sub
    Private Sub FollowCursor(ByVal p As Point)
        Dim n As Single
        If m_vertical Then
            n = m_min + (m_max - m_min) * (1 - p.Y / (m_height - 1.0F))
        Else
            n = m_min + (m_max - m_min) * p.X / (m_width - 1.0F)
        End If
        If n < m_min Then n = m_min
        If n > m_max Then n = m_max
        ' -------------------------------- right mouse button rounds to 1000 / 10 / 100
        If m_RightMousePressed Then
            n /= m_stepmin
            If My.Computer.Keyboard.AltKeyDown Then
                n = CInt(n)
            ElseIf My.Computer.Keyboard.CtrlKeyDown Then
                n = CInt(n / 10) * 10
            Else
                n = CInt(n / 100) * 100
            End If
            n *= m_stepmin
        End If
        Slots.WriteSlot(m_slot, n)
    End Sub

End Class
