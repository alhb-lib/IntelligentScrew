
Public Class Form1

    Private oldVertical As Boolean
    Private oldzoom As Double

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        EventsAreEnabled = False
        '
        Text = AppTitleAndVersion("Slot Viewer")
        ToolTips_Init()
        '
        Load_INI()
        oldVertical = chk_Vertical.Checked
        oldzoom = txt_Zoom.NumericValue
        InitParams()
        ' ----------------------------------------------------------------
        Timer1.Interval = 15
        Timer1.Start()
        EventsAreEnabled = True
        ' ---------------------------------------------------------------- start UserInterface
        Refresh()
        Me.Opacity = 1
        PanelDummy.Focus()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        EventsAreEnabled = False
        Timer1.Stop()
        Save_INI()
    End Sub

    Private Sub Form_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        If Not EventsAreEnabled Then Return
        LimitFormPosition(Me)
        Save_INI()
    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If Not EventsAreEnabled Then Return
        If Me.WindowState = FormWindowState.Minimized Then Return
        InitParams()
        Save_INI()
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState <> FormWindowState.Minimized Then
            Timer1.Start()
        Else
            Timer1.Stop()
        End If
    End Sub


    ' ====================================================================================================
    '  Init SlotBars
    ' ====================================================================================================
    Friend SlotBarsWidth As Int32 = 22 - 4
    Private SlotBars(-1) As SlotBar
    Private Sub SlotBars_Show()
        ' ------------------------------------------------------------ 
        SuspendRedraw(Me)
        ' ------------------------------------------------------------ load slot names
        LoadSlotNames()
        ' ------------------------------------------------------------ add remove bars
        If SlotBars Is Nothing OrElse NumSlots > SlotBars.Length Then
            Dim oldlen As Int32 = SlotBars.Length
            ReDim Preserve SlotBars(NumSlots - 1)
            For i As Int32 = oldlen To SlotBars.Length - 1
                SlotBars(i) = New SlotBar(Me)
            Next
        ElseIf NumSlots < SlotBars.Length Then
            For i As Int32 = NumSlots To SlotBars.Length - 1
                SlotBars(i).Destroy()
            Next
            ReDim Preserve SlotBars(NumSlots - 1)
        End If
        ' ------------------------------------------------------------ prepare params
        Dim barsLeft As Int32 = Panel_Controls.Right
        For i As Int32 = 0 To SlotBars.Length - 1
            SlotBars(i).SetSlotIndex(FirstSlot + i)
            SlotBars(i).SetText(SlotNames(FirstSlot + i))
            If Vertical Then
                SlotBars(i).SetAspectParams(barsLeft + i * SlotBarsWidth, 5, _
                                            SlotBarsWidth, _
                                            Me.ClientSize.Height - 9, _
                                            True, MaxValue, MinValue, Colors, Decimals)
            Else
                SlotBars(i).SetAspectParams(barsLeft, 5 + i * SlotBarsWidth, _
                                            Me.ClientSize.Width - barsLeft - 4, _
                                            SlotBarsWidth, _
                                            False, MaxValue, MinValue, Colors, Decimals)
            End If
        Next
        ' ------------------------------------------------------------ draw bars
        For i As Int32 = 0 To SlotBars.Length - 1
            SlotBars(i).ShowValue()
        Next
        ' ------------------------------------------------------------ 
        ResumeRedraw(Me)
        Refresh()
    End Sub


    ' ====================================================================================================
    '  Params
    ' ====================================================================================================
    Private FirstSlot As Int32
    Private NumSlots As Int32
    Private MaxValue As Int32
    Private MinValue As Int32
    Friend Colors As Int32
    Private Vertical As Boolean
    Private Decimals As Int32
    Private RepeatDelay As Int32
    Private RepeatTime As Int32
    Private ClickEnabled As Boolean
    Private Sub Params_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
                                                            Handles txt_FirstSlot.LostFocus, _
                                                                    txt_NumSlots.LostFocus, _
                                                                    txt_MaxValue.LostFocus, _
                                                                    txt_MinValue.LostFocus, _
                                                                    chk_Vertical.LostFocus, _
                                                                    txt_Decimals.LostFocus, _
                                                                    txt_Zoom.LostFocus
        Save_INI()
    End Sub
    Private Sub txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                            Handles txt_FirstSlot.TextChanged, _
                                                                    txt_NumSlots.TextChanged, _
                                                                    txt_MaxValue.TextChanged, _
                                                                    txt_MinValue.TextChanged, _
                                                                    txt_Decimals.TextChanged
        If Not EventsAreEnabled Then Exit Sub
        InitParams()
    End Sub
    Private Sub chk_Colors_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.EventArgs) _
                                                            Handles chk_Colors.ClickButtonArea
        Colors += 1
        If Colors > 2 Then Colors = 0
        InitParams()
        Save_INI()
        chk_Colors.Checked = False
    End Sub
    Private Sub chk_Vertical_CheckedChanged(ByVal Sender As Object, ByVal e As System.EventArgs) _
                                                            Handles chk_Vertical.CheckedChanged
        If Not EventsAreEnabled Then Exit Sub
        InitParams()
        Save_INI()
    End Sub
    Private Sub txt_Zoom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                                        Handles txt_Zoom.TextChanged
        If Not EventsAreEnabled Then Exit Sub
        If Vertical Then
            Me.Height = CInt(Me.Height * (txt_Zoom.NumericValue + 21) / (oldzoom + 21))
        Else
            Me.Width = CInt(Me.Width * (txt_Zoom.NumericValue + 24) / (oldzoom + 24))
        End If
        oldzoom = txt_Zoom.NumericValue
        InitParams()
        Save_INI()
    End Sub

    Private Sub InitParams()
        ' ---------------------------------------------------------------------
        SlotBarsWidth = 22 + txt_Zoom.NumericValueInteger - 10
        ' --------------------------------------------------------------------- set params
        SelectedSlotBar = Nothing
        FirstSlot = txt_FirstSlot.NumericValueInteger
        NumSlots = txt_NumSlots.NumericValueInteger
        txt_FirstSlot.MaxValue = 1000 - NumSlots
        txt_NumSlots.MaxValue = Math.Min(1000 - FirstSlot, 100)
        ' --------------------------------------------------------------------- 
        MaxValue = txt_MaxValue.NumericValueInteger
        MinValue = txt_MinValue.NumericValueInteger
        Vertical = chk_Vertical.Checked
        Decimals = txt_Decimals.NumericValueInteger
        ' --------------------------------------------------------------------- allow any resize
        Dim MinWidth As Int32 = Panel_Controls.Right + 240
        Dim MinHeight As Int32 = Panel_Controls.Bottom + SystemInformation.CaptionHeight + 20
        Me.MaximumSize = New Size(9000, 9000)
        Me.MinimumSize = New Size(MinWidth, MinHeight)
        ' --------------------------------------------------------------------- resize and limit the form
        EventsAreEnabled = False
        Dim oldW As Int32 = Me.Size.Width
        Dim oldH As Int32 = Me.Size.Height
        If Vertical Then
            If Vertical <> oldVertical Then
                Me.Height = oldW - Panel_Controls.Right + 16
            End If
            Me.ClientSize = New Size(Panel_Controls.Right + 4 + NumSlots * SlotBarsWidth, Me.ClientSize.Height)
            Me.MaximumSize = New Size(Me.Size.Width, 9000)
            Me.MinimumSize = New Size(Me.Size.Width, MinHeight)
        Else
            If Vertical <> oldVertical Then
                Me.Width = oldH + Panel_Controls.Right - 16
            End If
            Me.ClientSize = New Size(Me.ClientSize.Width, 9 + NumSlots * SlotBarsWidth)
            Me.MaximumSize = New Size(9000, Me.Size.Height)
            Me.MinimumSize = New Size(MinWidth + 2, Me.Size.Height)
        End If
        oldVertical = Vertical
        EventsAreEnabled = True
        ' --------------------------------------------------------------------- to overcome Linux position error
        If Not OperatingSystemIsWindows Then Panel_Controls.Left = -2
        ' --------------------------------------------------------------------- show
        SlotBars_Show()
        PanelDummy.SendToBack()
    End Sub

    ' ====================================================================================================
    '  Timer
    ' ====================================================================================================
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        PollSlots()
    End Sub
    Friend Sub PollSlots()
        For i As Int32 = 0 To SlotBars.Length - 1
            SlotBars(i).SetValue(Slots.ReadSlot(FirstSlot + i))
        Next
    End Sub


    ' ====================================================================================================
    '  ArrowUp / ArrowDown / Pageup / PageDown and MouseWheel 
    ' ====================================================================================================
    Friend SelectedSlotBar As SlotBar
    Friend Sub SetSelectedSlotBar(ByRef slotbar As SlotBar)
        SelectedSlotBar = slotbar
        PanelDummy.Focus()
    End Sub
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim n As Single
        Select Case e.KeyCode
            Case Keys.Up, Keys.Right : n = 1
            Case Keys.Down, Keys.Left : n = -1
            Case Keys.PageUp : n = 10
            Case Keys.PageDown : n = -10
            Case Keys.Escape : SelectedSlotBar = Nothing
        End Select
        If e.Shift Then n *= 100
        If e.Control Then n *= 10
        If e.Alt Then n /= 10
        If SelectedSlotBar IsNot Nothing Then SelectedSlotBar.DeltaValue(n)
    End Sub
    Private Sub Form1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        Dim n As Single = CInt(e.Delta / 1.2)
        If SelectedSlotBar IsNot Nothing Then SelectedSlotBar.DeltaValue(n)
    End Sub


    ' ==============================================================================================================
    '   ToolTips
    ' ==============================================================================================================
    Private ttp1 As ToolTip
    Private Sub ToolTips_Init()
        ttp1 = New ToolTip
        ttp1.ShowAlways = True
        ttp1.UseAnimation = True
        ttp1.UseFading = True
        ttp1.IsBalloon = True
        ttp1.AutoPopDelay = 32700
        ttp1.InitialDelay = 700
        ttp1.ReshowDelay = 500
        ' --------------------------------------------------------------- Add here Controls and ToolTip-Text
        ttp1.SetToolTip(txt_FirstSlot, _
                        " First slot" & vbCrLf & _
                        " - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -" & vbCrLf & _
                        " The index of the first slot." & vbCrLf & vbCrLf & _
                        " Press the left mouse button and move mouse Up and Down" & vbCrLf & _
                        " or use the mouse wheel to trim this value.")

        ttp1.SetToolTip(txt_NumSlots, _
                        " Number of slots" & vbCrLf & _
                        " - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -" & vbCrLf & _
                        " The number of the consecutive slots." & vbCrLf & vbCrLf & _
                        " Press the left mouse button and move mouse Up and Down" & vbCrLf & _
                        " or use the mouse wheel to trim this value.")

    End Sub
    ' --------------------- this corrects the XP bug that causes tooltip disappearing for ever 
    Private Sub controls_MouseEnter(ByVal sender As Object, _
                                   ByVal e As System.EventArgs) Handles txt_FirstSlot.MouseEnter, _
                                                                        txt_NumSlots.MouseEnter
        ttp1.Active = False
        ttp1.Active = True
    End Sub

End Class