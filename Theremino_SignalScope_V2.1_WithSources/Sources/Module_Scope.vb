Module ModuleScope

    Public Class Channel
        Public Slot As Int32
        Public neg As Boolean
        Public Max As Single
        Public Min As Single
        Public ValueMax As Single
        Public ValueMin As Single
        Public Value_Normalized As Single
        Public Value_Zero As Single
        Public Value As Single
        Public vDiv As Single
        Public RemoveDC As Boolean
        Sub New()
            Slot = -1
            Max = 1000
            Min = 0
        End Sub
    End Class

    Friend ch1 As Channel = New Channel
    Friend ch2 As Channel = New Channel

    Friend InterpolateEnabled As Boolean
    Friend CursorsEnabled As Boolean
    Friend Cursor1 As Single = 0.33
    Friend Cursor2 As Single = 0.66
    Friend ScopeRun As Boolean
    Friend TriggerCh As Int32

    ' ------------------------------------     30'000 =                 60 sec * 500 sps (60 kilo bytes)
    ' ------------------------------------  1'800'000 =  1 h * 60 min * 60 sec * 500 sps ( 2 mega bytes)
    ' ------------------------------------  3'600'000 =  2 h * 60 min * 60 sec * 500 sps ( 4 mega bytes)
    ' ------------------------------------ 10'800'000 =  6 h * 60 min * 60 sec * 500 sps (22 mega bytes)
    ' ------------------------------------ 21'600'000 = 12 h * 60 min * 60 sec * 500 sps (43 mega bytes)
    ' ------------------------------------ 43'200'000 = 24 h * 60 min * 60 sec * 500 sps (86 mega bytes)

    Const FifoLen As Int32 = 1800000    ' <-- 1800000 (1 h) (60 k bytes ram) (49 mega bytes disk)
    Friend fifo1 As FIFO = New FIFO(FifoLen)

    Private m_pbox As PictureBox

    Private m_SampleFreq As Int32 = 500
    Private m_SampleMillisec As Int32 = 2

    Private m_msDiv As Single = 100
    Private m_DeltaTime As Single
    Private m_LeftFifoIndex As Int32

    Private hpix As Int32
    Private wpix As Int32

    Private vpp As Single

    Private g As Graphics

    Private BackColor As Color = Color.FromArgb(250, 242, 242)
    Private textFont As Font = New Font("Arial", 9, FontStyle.Bold)

    Private PenScale1 As Pen = New Pen(Color.FromArgb(140, 140, 140))
    Private PenScale2 As Pen = New Pen(Color.FromArgb(160, 160, 160))
    Private PenTrace1 As Pen = New Pen(Color.DarkBlue, 2)
    Private PenTrace2 As Pen = New Pen(Color.DarkRed, 2)
    Private PenCursor As Pen = New Pen(Color.FromArgb(0, 120, 0), 3)
    Private BrushCursor As Brush = New SolidBrush(Color.FromArgb(0, 60, 0))
    Private BrushText As Brush = New SolidBrush(Color.FromArgb(30, 0, 0))
    Private BrushText1 As Brush = New SolidBrush(Color.DarkBlue)
    Private BrushText2 As Brush = New SolidBrush(Color.DarkRed)
    Private BrushBack As Brush = New SolidBrush(Color.FromArgb(150, 250, 250, 180))
    Private BrushHiLight As Brush = New SolidBrush(Color.FromArgb(180, 250, 250, 0))
    Private BrushBack2 As Brush = New SolidBrush(Color.FromArgb(250, 250, 180))
    Private PenCircles As Pen = New Pen(Color.Black, 2)
    Private PenTriggerLine As Pen = New Pen(Color.Gold, 3)
    Private BrushCircles As Brush = New SolidBrush(Color.Red)

    Friend Sub InitGraphics(ByVal pbox As PictureBox, Optional ByVal HiQuality As Boolean = True)
        m_pbox = pbox
        InitPictureboxImage(m_pbox)
        If m_pbox.Image Is Nothing Then Return
        g = Graphics.FromImage(m_pbox.Image)
        If g Is Nothing Then Return
        If HiQuality Then
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            PenTrace1.Width = 2
            PenTrace2.Width = 2
        Else
            g.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
            PenTrace1.Width = 1
            PenTrace2.Width = 1
        End If
        hpix = m_pbox.Image.Height - 1
        wpix = m_pbox.Image.Width - 2
        PenCursor.DashStyle = Drawing2D.DashStyle.Dot
    End Sub

    Friend Sub SetBaseTime(ByVal basetime As String)
        m_msDiv = CSng(Val(basetime))
        If basetime.Contains("mS") Then
            '
        ElseIf basetime.Contains("Sec") Then
            m_msDiv *= 1000
        ElseIf basetime.Contains("Min") Then
            m_msDiv *= 60000
        End If
        LimitDeltaTime()
    End Sub

    Friend Sub UpdateDeltaTimeBy(ByVal DeltaPixels As Int32)
        m_DeltaTime += DeltaPixels * m_msDiv / wpix * 20
        LimitDeltaTime()
    End Sub

    Friend Sub SetDeltaTime(ByVal newDeltaTime As Single)
        m_DeltaTime = newDeltaTime
        LimitDeltaTime()
    End Sub

    Friend Sub ResetDeltaTime()
        m_DeltaTime = 0
    End Sub

    Friend Function GetDeltaTime() As Single
        Return m_DeltaTime
    End Function

    Private Sub LimitDeltaTime()
        If m_DeltaTime < 0 Then m_DeltaTime = 0
        Dim MaxDelta As Single = FifoLen * 2 - m_msDiv * 20
        If m_DeltaTime > MaxDelta Then m_DeltaTime = MaxDelta
    End Sub


    Friend Function GetCursor1_FifoIndex() As Int32
        Return CInt(m_LeftFifoIndex + (Cursor1 * m_msDiv * 20) / m_SampleMillisec)
    End Function

    Friend Function GetCursor2_FifoIndex() As Int32
        Return CInt(m_LeftFifoIndex + (Cursor2 * m_msDiv * 20) / m_SampleMillisec)
    End Function

    ' ================================================================================
    '  Aquisition with the AccurateTimer
    ' ================================================================================
    Private WithEvents m_Timer As AccurateTimer = New AccurateTimer

    Private Sub m_Timer_TimerTick(ByVal TotalMillisec As Double) Handles m_Timer.Tick
        Static z1, z2 As Single
        Static oldv1, oldv2 As Single
        Dim v1 As Single = Slots.ReadSlot_NoNan(ch1.Slot)
        Dim v2 As Single = Slots.ReadSlot_NoNan(ch2.Slot)
        ' -------------------------------------------------- DC remover
        If ch1.RemoveDC Then
            v1 -= z1
            z1 += v1 / 100.0F
        End If
        If ch2.RemoveDC Then
            v2 -= z2
            z2 += v2 / 100.0F
        End If
        ' -------------------------------------------------- Stop tester
        fifo1.AddElement(New FIFO.FifoEntry(v1, v2))
        Select Case StopMethod
            Case 1
                If TripStatus = 0 Then
                    If v1 >= StopTripPoint And oldv1 < StopTripPoint Then
                        TripStatus = 1
                        StopEventCounter += 1
                        If StopEventCounter >= StopNumEvents Then
                            StopFlag = True
                        End If
                    End If
                Else
                    If v1 < StopTripPoint Then
                        TripStatus = 0
                    End If
                End If
            Case 2
                If TripStatus = 0 Then
                    If v1 <= StopTripPoint And oldv1 > StopTripPoint Then
                        TripStatus = 1
                        StopEventCounter += 1
                        If StopEventCounter >= StopNumEvents Then
                            StopFlag = True
                        End If
                    End If
                Else
                    If v1 > StopTripPoint Then
                        TripStatus = 0
                    End If
                End If
            Case 3
                If TripStatus = 0 Then
                    If v2 >= StopTripPoint And oldv2 < StopTripPoint Then
                        TripStatus = 1
                        StopEventCounter += 1
                        If StopEventCounter >= StopNumEvents Then
                            StopFlag = True
                        End If
                    End If
                Else
                    If v2 < StopTripPoint Then
                        TripStatus = 0
                    End If
                End If
            Case 4
                If TripStatus = 0 Then
                    If v2 <= StopTripPoint And oldv2 > StopTripPoint Then
                        TripStatus = 1
                        StopEventCounter += 1
                        If StopEventCounter >= StopNumEvents Then
                            StopFlag = True
                        End If
                    End If
                Else
                    If v2 > StopTripPoint Then
                        TripStatus = 0
                    End If
                End If
        End Select
        oldv1 = v1
        oldv2 = v2
    End Sub
    Friend Sub StartStopAcquisition(ByVal run As Boolean)
        If run Then
            m_Timer.Interval = m_SampleMillisec
            m_Timer.Start()
            fifo1.Flush()
        Else
            m_Timer.Stop()
        End If
        ' ------------------------------------- reset stop vars
        StopEventCounter = 0
        StopFlag = False
    End Sub

    ' ================================================================================
    '  Stop by events
    ' ================================================================================
    Friend StopMethod As Int32 = 0
    Friend StopTripPoint As Single = 0
    Friend StopNumEvents As Int32 = 0
    Friend StopFlag As Boolean
    Private StopEventCounter As Int32 = 0
    Private TripStatus As Int32 = 0

    ' ================================================================================
    '  SCOPE UPDATE
    ' ================================================================================
    Friend Sub ScopeUpdate()

        If m_pbox Is Nothing Then Return
        If m_pbox.Image Is Nothing Then Return

        Dim sw1 As Diagnostics.Stopwatch = New Diagnostics.Stopwatch : sw1.Start()
        ' ------------------------------------------------------------------ 
        Dim i, ix As Int32
        Dim x As Single
        Dim oldx1 As Int32
        Dim oldx2 As Int32
        Dim oldy1 As Single
        Dim oldy2 As Single
        Dim h1, h2 As Single
        Dim preTrigSamples As Int32
        Dim FifoReadIndex As Int32
        Dim SyncStartIndex As Int32
        Dim TriggerMillisec As Single
        Dim v, v1, v2 As Single
        Dim v1min, v2min As Single
        Dim v1max, v2max As Single
        Dim y, y1, y2 As Single
        Dim kmv1 As Single = hpix / 10.0F / ch1.vDiv
        Dim kmv2 As Single = hpix / 10.0F / ch2.vDiv
        Dim kw As Single = m_SampleFreq / 50.0F * m_msDiv / wpix
        Dim kw2 As Single = m_msDiv * 20 / wpix
        Dim cursor1x As Int32 = CInt(Cursor1 * wpix)
        Dim cursor2x As Int32 = CInt(Cursor2 * wpix)
        If cursor1x > cursor2x Then
            Dim d As Int32 = cursor1x
            cursor1x = cursor2x
            cursor2x = d
        End If
        Static TrigMin As Single
        Static TrigMax As Single
        ' ------------------------------------------------------------------ clear
        g.Clear(BackColor)
        ' ------------------------------------------------------------------ draw scale
        For i = 0 To 20
            x = wpix * i \ 20
            Select Case i
                Case 0, 10, 20
                    g.DrawLine(PenScale2, x - 1, 0, x - 1, hpix)
                    g.DrawLine(PenScale1, x, 0, x, hpix)
                    g.DrawLine(PenScale2, x + 1, 0, x + 1, hpix)
                Case Else
                    g.DrawLine(PenScale1, x, 0, x, hpix)
            End Select
        Next
        For i = 0 To 10
            y = hpix * i \ 10
            Select Case i
                Case 0, 5, 10
                    g.DrawLine(PenScale2, 0, y - 1, wpix, y - 1)
                    g.DrawLine(PenScale1, 0, y, wpix, y)
                    g.DrawLine(PenScale2, 0, y + 1, wpix, y + 1)
                Case Else
                    g.DrawLine(PenScale1, 0, y, wpix, y)
            End Select
        Next

        ' -------------------------------------------------------------- prepare the FIFO read position
        FifoReadIndex = CInt(fifo1.GetWriteIndex - 1)
        ' -------------------------------------------------------------- subtract delta time 
        FifoReadIndex -= CInt(m_DeltaTime / 2)
        ' -------------------------------------------------------------- Adaptive-trigger or no-trigger
        If TriggerCh > 0 Then
            preTrigSamples = Math.Min(3 * CInt(kw * wpix), FifoLen \ 2)
            Dim min As Single = Single.MaxValue
            Dim max As Single = Single.MinValue
            Dim TrigState As Int32 = 0
            For ix = FifoReadIndex To FifoReadIndex - preTrigSamples Step -1
                If TriggerCh = 1 Then
                    v = fifo1.GetElement(ix).Value1
                    If ch1.neg Then v = -v
                Else
                    v = fifo1.GetElement(ix).Value2
                    If ch2.neg Then v = -v
                End If
                If v > max Then max = v
                If v < min Then min = v
                Select Case TrigState
                    Case 0
                        If v < TrigMin Then
                            TrigState = 1
                        End If
                    Case 1
                        If v > TrigMax Then
                            TrigState = 2
                            FifoReadIndex = ix
                            SyncStartIndex = ix
                        End If
                    Case 2
                        If v < TrigMin Then
                            TrigState = 3
                        End If
                    Case 3
                        If v > TrigMax Then
                            TrigState = 4
                            TriggerMillisec = (SyncStartIndex - ix) * m_SampleMillisec
                        End If
                End Select
            Next
            ' -------------------------------------------------------------- TrigMax and TrigMin
            Dim margin As Single = (max - min) * 0.25F
            TrigMax = max - margin
            TrigMin = min + margin
        End If
        ' ------------------------------------------------------------------ FifoIndex for the left of the window
        m_LeftFifoIndex = FifoReadIndex - CInt(wpix * kw)
        ' ------------------------------------------------------------------ value zero (CenterValue)
        h1 = hpix / 2.0F + kmv1 * ch1.Value_Zero
        h2 = hpix / 2.0F + kmv2 * ch2.Value_Zero
        ' ------------------------------------------------------------------ unused traces
        If ch1.Slot < 0 Then kmv1 = 0 : h1 = -10000
        If ch2.Slot < 0 Then kmv2 = 0 : h2 = -10000
        ' ------------------------------------------------------------------ wave
        oldx1 = -1
        oldx2 = -1
        oldy1 = 0
        oldy2 = 0
        v1min = Single.MaxValue
        v2min = Single.MaxValue
        v1max = Single.MinValue
        v2max = Single.MinValue
        Dim fe As FIFO.FifoEntry
        Dim DeltaIndex As Int32
        Dim oldDeltaIndex As Int32 = -1
        Dim curs1v1, curs1v2 As Single
        Dim curs2v1, curs2v2 As Single
        For ix = 0 To wpix - 1
            DeltaIndex = CInt(ix * kw)
            ' -------------------------------------------------------------- plot only if new sample or cursors and not interpolateenabled
            If DeltaIndex = oldDeltaIndex Then
                If Not CursorsEnabled AndAlso InterpolateEnabled Then
                    Continue For
                End If
            End If
            oldDeltaIndex = DeltaIndex
            ' -------------------------------------------------------------- plot traces
            fe = fifo1.GetElement(m_LeftFifoIndex + DeltaIndex)
            v1 = fe.Value1
            If ch1.neg Then v1 = -v1
            y1 = h1 - kmv1 * v1
            v2 = fe.Value2
            If ch2.neg Then v2 = -v2
            y2 = h2 - kmv2 * v2
            If v1 > v1max Then v1max = v1
            If v1 < v1min Then v1min = v1
            If v2 > v2max Then v2max = v2
            If v2 < v2min Then v2min = v2
            If Math.Abs(y1) > 100000 Then y1 = 0
            If Math.Abs(y2) > 100000 Then y2 = 0
            If Double.IsNaN(y1) Then y1 = 0
            If Double.IsNaN(y2) Then y2 = 0
            ' -------------------------------------------------------------- if cursors or not interpolate then plot every sample
            If CursorsEnabled OrElse Not InterpolateEnabled Then
                If oldx1 >= 0 Then
                    g.DrawLine(PenTrace1, oldx1, oldy1, ix, y1)
                    g.DrawLine(PenTrace2, oldx2, oldy2, ix, y2)
                End If
                oldy1 = y1
                oldy2 = y2
                oldx1 = ix
                oldx2 = ix
            Else
                ' ---------------------------------------------------------- else plot only when y changes
                Static counter1 As Int32 = 0
                counter1 += 1
                If oldy1 <> y1 Or counter1 > 1 Then
                    counter1 = 0
                    If oldx1 >= 0 Then
                        g.DrawLine(PenTrace1, oldx1, oldy1, ix, y1)
                    End If
                    oldy1 = y1
                    oldx1 = ix
                End If
                If oldy2 <> y2 Then
                    If oldx1 >= 0 Then
                        g.DrawLine(PenTrace2, oldx2, oldy2, ix, y2)
                    End If
                    oldy2 = y2
                    oldx2 = ix
                End If
            End If
            ' -------------------------------------------------------------- plot cursors
            If CursorsEnabled Then
                If ix = cursor1x Then
                    g.DrawLine(PenCursor, ix, 0, ix, hpix)
                    g.DrawEllipse(PenTrace1, ix - 4, y1 - 4, 8, 8)
                    PrintXY_Left(v1.ToString(GCI), BrushText1, BrushBack2, ix - 8, y1 - 6)
                    g.DrawEllipse(PenTrace2, ix - 4, y2 - 4, 8, 8)
                    PrintXY_Left(v2.ToString(GCI), BrushText2, BrushBack2, ix - 8, y2 - 6)
                    curs1v1 = v1
                    curs1v2 = v2
                End If
                If ix = cursor2x Then
                    g.DrawLine(PenCursor, ix, 0, ix, hpix)
                    g.DrawEllipse(PenTrace1, ix - 4, y1 - 4, 8, 8)
                    PrintXY_Left(v1.ToString(GCI), BrushText1, BrushBack2, ix - 8, y1 - 6)
                    g.DrawEllipse(PenTrace2, ix - 4, y2 - 4, 8, 8)
                    PrintXY_Left(v2.ToString(GCI), BrushText2, BrushBack2, ix - 8, y2 - 6)
                    curs2v1 = v1
                    curs2v2 = v2
                End If
            End If
        Next
        ' ------------------------------------------------------------------ trigger info
        If Math.Abs(oldy1) < 100000 Then g.DrawEllipse(PenCircles, oldx1 - 4, oldy1 - 4, 8, 8)
        If Math.Abs(oldy2) < 100000 Then g.DrawEllipse(PenCircles, oldx2 - 4, oldy2 - 4, 8, 8)
        If TriggerCh > 0 And TriggerMillisec > 0 Then
            If TriggerCh = 1 Then
                y = oldy1
                x = oldx1
            Else
                y = oldy2
                x = oldx2
            End If
            Dim x2 As Single = x - TriggerMillisec / kw / 2.0F
            If Math.Abs(y) < 100000 Then
                g.DrawEllipse(PenCircles, x2 - 4, y - 4, 8, 8)
                g.FillEllipse(BrushCircles, x - 3, y - 3, 6, 6)
                g.FillEllipse(BrushCircles, x2 - 3, y - 3, 6, 6)
                g.DrawLine(PenTriggerLine, x, y, x2, y)
            End If
            PrintXY_Left("Trigger = " + TriggerMillisec.ToString("0", GCI) + " mS  " + _
                        (1000 / TriggerMillisec).ToString("0.00", GCI) + " Hz", _
                        BrushText, BrushHiLight, wpix - 3, 3)
        End If
        ' ------------------------------------------------------------------ cursors info
        If CursorsEnabled Then
            PrintXY("Ch1 delta = " + Math.Abs(curs2v1 - curs1v1).ToString(GCI), BrushText1, BrushBack, 3, 3)
            PrintXY("Ch2 delta = " + Math.Abs(curs2v2 - curs1v2).ToString(GCI), BrushText2, BrushBack, 3, 20)
            Dim ms As Single = (cursor2x - cursor1x) * kw2
            PrintXY("mS = " + ms.ToString(GCI), BrushCursor, BrushBack, 3, 40)
            PrintXY("Hz = " + (1000 / ms).ToString(GCI), BrushCursor, BrushBack, 3, 57)
        End If
        ' ------------------------------------------------------------------ scale text - Vertical/div
        PrintBottom((ch1.vDiv).ToString(GCI) & " / div", BrushText1, BrushBack, 5)
        PrintBottom((ch2.vDiv).ToString(GCI) & " / div", BrushText2, BrushBack, 80)
        ' ------------------------------------------------------------------ scale text - TimeBase/div
        If m_msDiv >= 1000 Then
            PrintBottom((m_msDiv / 1000).ToString(GCI) & " Sec / div", BrushText, BrushBack, wpix - 80)
        Else
            PrintBottom(m_msDiv.ToString(GCI) & " mS / div", BrushText, BrushBack, wpix - 80)
        End If
        ' ------------------------------------------------------------------ scale text - TimeBase Delta
        If m_DeltaTime > 0 Then
            If m_DeltaTime >= 60000 Then
                PrintBottom("Delta time = " + (m_DeltaTime / 60000).ToString("0.000", GCI) + " min", _
                            BrushText, BrushHiLight, wpix - 240)
            ElseIf m_DeltaTime >= 1000 Then
                PrintBottom("Delta time = " + (m_DeltaTime / 1000).ToString("0.000", GCI) + " Sec", _
                            BrushText, BrushHiLight, wpix - 240)
            Else
                PrintBottom("Delta time = " + m_DeltaTime.ToString("0", GCI) + " mS", _
                            BrushText, BrushHiLight, wpix - 230)
            End If
        End If
        ' ------------------------------------------------------------------ value Min and Max
        ch1.Value = v1
        ch2.Value = v2
        ch1.ValueMax = v1max
        ch1.ValueMin = v1min
        ch2.ValueMax = v2max
        ch2.ValueMin = v2min
        ' ------------------------------------------------------------------ debug info with ALT key
        If My.Computer.Keyboard.AltKeyDown Then
            PrintTop("TrigMax: " & TrigMax.ToString("0.0"), BrushText, Brushes.Yellow, 200)
            PrintTop("TrigMin: " & TrigMin.ToString("0.0"), BrushText, Brushes.Yellow, 300)
            PrintTop("Scope time: " & (sw1.Elapsed.TotalMilliseconds).ToString("0.0") & " mS", _
                     BrushText, Brushes.Yellow, 8)
        End If
        ' ------------------------------------------------------------------ show
        m_pbox.Invalidate()
    End Sub

    Private Sub PrintXY(ByVal str As String, ByVal br1 As Brush, ByVal br2 As Brush, ByVal x As Single, ByVal y As Single)
        Dim sz As SizeF = g.MeasureString(str, textFont)
        g.FillRectangle(br2, x, y, sz.Width, sz.Height)
        g.DrawString(str, textFont, br1, x, y)
    End Sub

    Private Sub PrintXY_Left(ByVal str As String, ByVal br1 As Brush, ByVal br2 As Brush, ByVal x As Single, ByVal y As Single)
        Dim sz As SizeF = g.MeasureString(Str, textFont)
        x -= sz.Width
        g.FillRectangle(br2, x, y, sz.Width, sz.Height)
        g.DrawString(Str, textFont, br1, x, y)
    End Sub

    Private Sub PrintTop(ByVal str As String, ByVal br1 As Brush, ByVal br2 As Brush, ByVal x As Single)
        Dim sz As SizeF = g.MeasureString(str, textFont)
        g.FillRectangle(br2, x, 5, sz.Width, sz.Height)
        g.DrawString(str, textFont, br1, x, 5)
    End Sub

    Private Sub PrintBottom(ByVal str As String, ByVal br1 As Brush, ByVal br2 As Brush, ByVal x As Single)
        Dim sz As SizeF = g.MeasureString(str, textFont)
        g.FillRectangle(br2, x, hpix - 18, sz.Width, sz.Height)
        g.DrawString(str, textFont, br1, x, hpix - 18)
    End Sub

End Module

