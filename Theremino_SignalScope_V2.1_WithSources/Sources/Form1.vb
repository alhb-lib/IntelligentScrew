
' TODO - Main list
' -----------------------------------------------------------
' All done

' -----------------------------------------------------------
' Version 1.7 
'  - If cursors are enabled then 
'    only the area between the cursors will be saved
'  - Trigger greatly improved
'  - Removed random waveform instability
'  - Buffer limited to 1 hour 
'  - Save/load buffer time not more than 2 seconds
'  - Fast drag wavefom (DeltaTime) with CTRL and SHIFT keys
' -----------------------------------------------------------

Public Class Form1

    ' ===================================================================================
    '   Form
    ' ===================================================================================
    Private EventsAreEnabled As Boolean = False
    Private RefreshNeeded As Boolean

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Text = AppTitleAndVersion()
        Load_INI()
        LoadSlotNames()
        Refresh()
        LoadBufferFrom(Application.StartupPath + "\Buffers\LastBuffer.csv")
        InitGraphics(pbox_Scope)
        InitAll()
        ToolStrip1.Renderer = New ToolStripButtonRenderer
        pbox_Scope.Select()
    End Sub

    Friend Sub InitAll()
        EventsAreEnabled = True
        ModuleScope.InterpolateEnabled = btn_Interpolate.Checked
        ModuleScope.CursorsEnabled = btn_Cursors.Checked
        btn_Interpolate.Visible = Not btn_Cursors.Checked
        ModuleScope.SetDeltaTime(CSng(Val(txt_Delta.Text)))
        SetStopParams()
        SetSlotParams()
        SetScopeParams()
        UpdateTriggerButton()
        ShowHideControls()
        StartStopAcquisition(btn_Run.Checked)
        StartStopTimers()
        RefreshNeeded = True
    End Sub

    Private Sub Form1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged, _
                                                                                                  Me.SizeChanged
        StartStopTimers()
        ParamsChanged = True
    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Not EventsAreEnabled Then Return
        ShowHideControls()
        InitGraphics(pbox_Scope)
        ParamsChanged = True
        ScopeUpdate()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Timer_30Hz.Stop()
        Timer_10Hz.Stop()
        btn_Run.Checked = False
        StartStopAcquisition(btn_Run.Checked)
        SaveBufferTo(Application.StartupPath + "\Buffers\LastBuffer.csv", True)
        Save_INI()
    End Sub

    Private Sub Form1_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        LimitFormPosition(Me)
        ParamsChanged = True
    End Sub

    Private Sub btn_EditSlotNames_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_EditSlotNames.Click
        Me.Opacity = 0.7
        ProcessStartAndWait(PlatformAdjustedFileName(Application.StartupPath & "\SlotNames.txt"))
        Me.Opacity = 1
        LoadSlotNames()
        SetSlotParams()
    End Sub

    Private Sub ShowHideControls()
        gbox_SlotNames.Visible = Me.Size.Width >= 760
        'btn_Interpolate.Visible = Me.Size.Width >= 705
    End Sub


    ' ===================================================================================
    '  MenuStrip and ToolStrip accepting the first click
    '  If the form receives a WM_PARENTNOTIFY (528) message and is not focused 
    '  then the form is activated before to exec the message
    ' ===================================================================================
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = 528 AndAlso Not Me.Focused Then
            Me.Activate()
        End If
        MyBase.WndProc(m)
    End Sub

    ' ===================================================================================
    '   ToolStrip Gradients
    ' ===================================================================================
    Private Sub ToolStrip1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ToolStrip1.Paint
        Dim bounds As New Rectangle(0, 0, _
                                    ToolStrip1.Width, ToolStrip1.Height)
        Dim brush As New Drawing2D.LinearGradientBrush(bounds, _
                                                       Color.White, _
                                                       Color.FromArgb(200, 200, 200), _
                                                       Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRectangle(brush, bounds)
    End Sub

    ' ===================================================================================
    '   ToolStrip PressedButton color
    ' ===================================================================================
    Class ToolStripButtonRenderer
        Inherits System.Windows.Forms.ToolStripProfessionalRenderer

        Protected Overrides Sub OnRenderButtonBackground(ByVal e As ToolStripItemRenderEventArgs)
            Dim btn As ToolStripButton = CType(e.Item, ToolStripButton)
            If btn IsNot Nothing AndAlso btn.Checked Then
                Dim bounds As Rectangle = New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1)
                Dim brush As New Drawing2D.LinearGradientBrush(bounds, _
                                                               Color.Gold, _
                                                               Color.FromArgb(250, 250, 250), _
                                                               Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(brush, bounds)
                e.Graphics.DrawRectangle(Pens.Orange, bounds)
            Else
                MyBase.OnRenderButtonBackground(e)
            End If
        End Sub
    End Class


    ' ===================================================================================
    '   ToolStrip Buttons
    ' ===================================================================================
    Private Sub btn_LoadBuffer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_LoadBuffer.Click
        LoadBuffer()
        FlushMouseEvents(Me)
        TriggerCh = 0
        UpdateTriggerButton()
        RefreshNeeded = True
    End Sub

    Private Sub FlushMouseEvents(ByVal frm As Form)
        frm.Enabled = False
        Application.DoEvents()
        frm.Enabled = True
    End Sub

    Private Sub btn_SaveBuffer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SaveBuffer.Click
        SaveBuffer()
    End Sub
    Private Sub btn_SaveImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_SaveImage.Click
        btn_SaveImage.Visible = False
        btn_SaveImage.Visible = True
        Me.Refresh()
        SaveImage_("SignalScope_", Me)
    End Sub


    Private Sub btn_Interpolate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Interpolate.Click
        ModuleScope.InterpolateEnabled = btn_Interpolate.Checked
        RefreshNeeded = True
        ParamsChanged = True
    End Sub

    Private Sub btn_Cursors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cursors.Click
        ModuleScope.CursorsEnabled = btn_Cursors.Checked
        btn_Interpolate.Visible = Not btn_Cursors.Checked
        RefreshNeeded = True
        ParamsChanged = True
    End Sub

    Private Sub btn_Trigger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Trigger.Click
        TriggerCh = (TriggerCh + 1) Mod 3
        UpdateTriggerButton()
        ScopeUpdate()
        RefreshNeeded = True
    End Sub
    Private Sub UpdateTriggerButton()
        If TriggerCh = 0 Then
            btn_Trigger.Checked = False
            btn_Trigger.Text = "Trigger OFF"
        Else
            btn_Trigger.Checked = True
            btn_Trigger.Text = "Trigger CH" + TriggerCh.ToString
        End If
    End Sub

    Private Sub btn_Run_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Run.Click
        txt_Delta.NumericValue = 0
        ModuleScope.StartStopAcquisition(btn_Run.Checked)
        RefreshNeeded = True
        ParamsChanged = True
    End Sub


    ' ====================================================================================================
    '   TIMERS
    ' ====================================================================================================
    Private Sub StartStopTimers()
        If Visible And WindowState <> FormWindowState.Minimized Then
            Timer_30Hz.Interval = 33
            Timer_30Hz.Start()
            Timer_10Hz.Interval = 100
            Timer_10Hz.Start()
        Else
            Timer_30Hz.Stop()
            Timer_10Hz.Stop()
        End If
    End Sub

    Private Sub Timer_30Hz_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_30Hz.Tick
        If Not EventsAreEnabled Then Return
        If Not pbox_Scope.Visible Then Return
        If btn_Run.Checked OrElse RefreshNeeded Then
            RefreshNeeded = False
            ScopeUpdate()
        End If
        ' ------------------------------------------------- test stop flag
        If StopFlag Then
            btn_Run.Checked = False
            StartStopAcquisition(btn_Run.Checked)
            StartStopTimers()
            ScopeUpdate()
        End If
    End Sub

    Private Sub Timer_10Hz_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_10Hz.Tick
        If Not EventsAreEnabled Then Return
        If Not pbox_Scope.Visible Then Return
        If btn_Run.Checked OrElse RefreshNeeded Then
            ShowStatusBarValues()
        End If
        If ParamsChanged Then Save_INI()
    End Sub

    ' ====================================================================================================
    '  Set DeltaTime by MouseDown and MouseMove on the Pbox_Scope
    ' ====================================================================================================
    Private oldx As Int32
    Private EditDeltaTime As Boolean
    Private EditCursor1 As Boolean
    Private EditCursor2 As Boolean
    Private Sub pbox_Scope_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbox_Scope.MouseDown
        If e.Button = MouseButtons.Left Then
            ' ------------------------------------------------------------- init edit cursors
            If ModuleScope.CursorsEnabled Then
                Dim x As Single = (e.X - 1.0F) / (pbox_Scope.ClientSize.Width - 2.0F)
                If Math.Abs(x - Cursor1) < 0.05 Then
                    EditCursor1 = True
                ElseIf Math.Abs(x - Cursor2) < 0.05 Then
                    EditCursor2 = True
                Else
                    ' ------------------------------------------------------------- init for delta time
                    oldx = e.X
                    EditDeltaTime = True
                End If
            Else
                ' ------------------------------------------------------------- init for delta time
                oldx = e.X
                EditDeltaTime = True
            End If
        End If
    End Sub
    Private Sub pbox_Scope_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbox_Scope.MouseMove
        If e.Button = MouseButtons.Left Or e.Button = MouseButtons.Right Then
            If EditCursor1 Or EditCursor2 Then
                Dim x As Single = e.X
                If x > pbox_Scope.ClientSize.Width - 2 Then x = pbox_Scope.ClientSize.Width - 2
                If x < 2 Then x = 2
                x = (x - 1.0F) / (pbox_Scope.ClientSize.Width - 2.0F)
                If EditCursor1 Then Cursor1 = x
                If EditCursor2 Then Cursor2 = x
                ScopeUpdate()
                pbox_Scope.Refresh()
                ParamsChanged = True
            End If
            If EditDeltaTime Then
                Dim delta As Int32 = e.X - oldx
                If My.Computer.Keyboard.ShiftKeyDown Then delta *= 100
                If My.Computer.Keyboard.CtrlKeyDown Then delta *= 10
                ModuleScope.UpdateDeltaTimeBy(delta)
                oldx = e.X
                EventsAreEnabled = False
                txt_Delta.Text = ModuleScope.GetDeltaTime.ToString("0")
                EventsAreEnabled = True
                RefreshNeeded = True
            End If
        End If
    End Sub
    Private Sub txt_Delta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Delta.TextChanged
        If Not EventsAreEnabled Then Return
        ModuleScope.SetDeltaTime(CSng(Val(txt_Delta.Text)))
        SetScopeParams()
        ParamsChanged = True
    End Sub

    Private Sub pbox_Scope_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbox_Scope.MouseUp
        EditDeltaTime = False
        EditCursor1 = False
        EditCursor2 = False
    End Sub

    ' ====================================================================================================
    '   Set BaseTime by MouseWheel on the Pbox_Scope
    ' ====================================================================================================
    Private Sub pbox_Scope_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbox_Scope.MouseWheel
        SetComboByWheel(cmb_BaseTime, e.Delta)
    End Sub

    Friend Sub SetComboByWheel(ByRef cmb As ComboBox, ByVal delta As Single)
        Static acc As Single = -1
        If acc < 0 Then acc = cmb.SelectedIndex
        acc += delta / 120.0F
        If acc < 0 Then acc = 0
        If acc > cmb.Items.Count - 1 Then acc = cmb.Items.Count - 1
        Combo_SetIndex(cmb, CInt(acc))
    End Sub

    ' ====================================================================================================
    '   SET ZERO
    ' ====================================================================================================
    Private Sub btn_SetZero_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles btn_SetZero.Click
        SetCenterValue()
    End Sub

    ' ====================================================================================================
    '   COMBO Units1
    ' ====================================================================================================
    Private Sub cmb_Units1_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Units1.DropDown
        LimitComboDropDownHeight(cmb_Units1)
    End Sub
    Private Sub cmb_Units1_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Units1.DropDownClosed
        pbox_Scope.Focus()
    End Sub
    Private Sub cmb_Units1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Units1.SelectedIndexChanged
        SetScopeParams()
    End Sub

    ' ====================================================================================================
    '   COMBO Units2
    ' ====================================================================================================
    Private Sub cmb_Units2_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Units2.DropDown
        LimitComboDropDownHeight(cmb_Units2)
    End Sub
    Private Sub cmb_Units2_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Units2.DropDownClosed
        pbox_Scope.Focus()
    End Sub
    Private Sub cmb_Units2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Units2.SelectedIndexChanged
        SetScopeParams()
    End Sub

    ' ====================================================================================================
    '   COMBO BaseTime
    ' ====================================================================================================
    Private Sub cmb_BaseTime_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_BaseTime.DropDownClosed
        pbox_Scope.Focus()
    End Sub
    Private Sub cmb_BaseTime_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_BaseTime.SelectedIndexChanged
        SetScopeParams()
    End Sub

    ' ====================================================================================================
    '   COMBO cmb_StopIf
    ' ====================================================================================================
    Private Sub cmb_StopIf_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_StopIf.DropDownClosed
        pbox_Scope.Focus()
    End Sub
    Private Sub cmb_StopIf_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_StopIf.SelectedIndexChanged
        SetStopParams()
    End Sub

    ' ====================================================================================================
    '   TextBox StopTripPoint
    ' ====================================================================================================
    Private Sub txt_StopTripPoint_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_StopTripPoint.TextChanged
        If Not EventsAreEnabled Then Return
        SetStopParams()
    End Sub

    ' ====================================================================================================
    '   COMBO cmb_StopIf
    ' ====================================================================================================
    Private Sub cmb_StopAfterTimes_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_StopAfterTimes.DropDownClosed
        pbox_Scope.Focus()
    End Sub
    Private Sub cmb_StopAfterTimes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_StopAfterTimes.SelectedIndexChanged
        SetStopParams()
    End Sub


    ' ====================================================================================================
    '   Channel params
    ' ====================================================================================================
    Private Sub txt_Slot1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Slot1.TextChanged
        If Not EventsAreEnabled Then Return
        SetSlotParams()
    End Sub
    Private Sub txt_Slot2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Slot2.TextChanged
        If Not EventsAreEnabled Then Return
        SetSlotParams()
    End Sub
    Private Sub txt_Min1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Min1.TextChanged
        If Not EventsAreEnabled Then Return
        SetScopeParams()
    End Sub
    Private Sub txt_Min2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Min2.TextChanged
        If Not EventsAreEnabled Then Return
        SetScopeParams()
    End Sub
    Private Sub txt_Max1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Max1.TextChanged
        If Not EventsAreEnabled Then Return
        SetScopeParams()
    End Sub
    Private Sub txt_Max2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Max2.TextChanged
        If Not EventsAreEnabled Then Return
        SetScopeParams()
    End Sub
    Private Sub txt_Center1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Center1.TextChanged
        If Not EventsAreEnabled Then Return
        SetScopeParams()
    End Sub
    Private Sub txt_Center2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Center2.TextChanged
        If Not EventsAreEnabled Then Return
        SetScopeParams()
    End Sub
    Private Sub chk_AC1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_AC1.CheckedChanged
        If Not EventsAreEnabled Then Return
        SetScopeParams()
    End Sub
    Private Sub chk_AC2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_AC2.CheckedChanged
        If Not EventsAreEnabled Then Return
        SetScopeParams()
    End Sub

    Private Sub SetSlotParams()
        If Not EventsAreEnabled Then Return
        Dim n As Int32
        ' --------------------------------------- first slot
        If txt_Slot1.Text.Trim <> "" Then
            n = CInt(Val(txt_Slot1.Text))
        Else
            n = -1
        End If
        If n >= 0 Then
            If SlotNames(n) <> "" Then
                lbl_SlotName1.Text = "BLU = " + SlotNames(n)
            Else
                lbl_SlotName1.Text = "BLU = Slot " + n.ToString
            End If
        Else
            lbl_SlotName1.Text = "Blu trace is unused"
        End If
        ModuleScope.ch1.Slot = n
        ' --------------------------------------- second slot
        If txt_Slot2.Text.Trim <> "" Then
            n = CInt(Val(txt_Slot2.Text))
        Else
            n = -1
        End If
        If n >= 0 Then
            If SlotNames(n) <> "" Then
                lbl_SlotName2.Text = "RED = " + SlotNames(n)
            Else
                lbl_SlotName2.Text = "RED = Slot " + n.ToString
            End If
        Else
            lbl_SlotName2.Text = "Red trace is unused"
        End If
        ModuleScope.ch2.Slot = n
        ' -----------------------------------------
        ParamsChanged = True
        RefreshNeeded = True
        ShowStatusBarValues()
        SetScaleLabels()
    End Sub

    Private Sub SetScopeParams()
        If cmb_Units1.Text = "Min-Max" Then
            ModuleScope.ch1.Min = CInt(Val(txt_Min1.Text))
            ModuleScope.ch1.Max = CInt(Val(txt_Max1.Text))
            ModuleScope.ch1.vDiv = (ModuleScope.ch1.Max - ModuleScope.ch1.Min) / 10
            ch1.Value_Zero = (ch1.Max + ch1.Min) / 2.0F
            txt_Min1.Enabled = True
            txt_Max1.Enabled = True
            txt_Center1.Enabled = False
        Else
            ModuleScope.ch1.vDiv = CSng(Val(cmb_Units1.Text))
            ch1.Value_Zero = CSng(Val(txt_Center1.Text))
            txt_Min1.Enabled = False
            txt_Max1.Enabled = False
            txt_Center1.Enabled = True
        End If
        If cmb_Units2.Text = "Min-Max" Then
            ModuleScope.ch2.Min = CInt(Val(txt_Min2.Text))
            ModuleScope.ch2.Max = CInt(Val(txt_Max2.Text))
            ModuleScope.ch2.vDiv = (ModuleScope.ch2.Max - ModuleScope.ch2.Min) / 10
            ch2.Value_Zero = (ch2.Max + ch2.Min) / 2.0F
            txt_Min2.Enabled = True
            txt_Max2.Enabled = True
            txt_Center2.Enabled = False
        Else
            ModuleScope.ch2.vDiv = CSng(Val(cmb_Units2.Text))
            ch2.Value_Zero = CSng(Val(txt_Center2.Text))
            txt_Min2.Enabled = False
            txt_Max2.Enabled = False
            txt_Center2.Enabled = True
        End If
        '
        ModuleScope.SetBaseTime(cmb_BaseTime.Text)
        '
        ModuleScope.ch1.RemoveDC = chk_AC1.Checked
        ModuleScope.ch2.RemoveDC = chk_AC2.Checked
        '
        ParamsChanged = True
        '
        ScopeUpdate()
        pbox_Scope.Refresh()
        RefreshNeeded = False
        '
        ShowStatusBarValues()
        SetScaleLabels()
    End Sub

    Private Sub SetStopParams()
        If Not EventsAreEnabled Then Return
        ' -----------------------------------------
        ModuleScope.StopMethod = cmb_StopIf.SelectedIndex
        ModuleScope.StopTripPoint = CSng(Val(txt_StopTripPoint.Text))
        ModuleScope.StopNumEvents = Math.Max(CInt(Val(cmb_StopAfterTimes.Text)), 1)
        ' -----------------------------------------
        If ModuleScope.StopMethod > 0 Then
            txt_StopTripPoint.Visible = True
            lbl_Then.Visible = True
            cmb_StopAfterTimes.Visible = True
        Else
            txt_StopTripPoint.Visible = False
            lbl_Then.Visible = False
            cmb_StopAfterTimes.Visible = False
        End If
        ' -----------------------------------------
        ParamsChanged = True
        RefreshNeeded = True
        ShowStatusBarValues()
        SetScaleLabels()
    End Sub

    Private Sub SetCenterValue()
        If cmb_Units1.Text <> "Min-Max" Then
            ch1.Value_Zero = (ch1.ValueMax + ch1.ValueMin) / 2.0F
        End If
        If cmb_Units2.Text <> "Min-Max" Then
            ch2.Value_Zero = (ch2.ValueMax + ch2.ValueMin) / 2.0F
        End If
        SetScaleLabels()
        EventsAreEnabled = False
        txt_Center1.Text = Label_Scale1b.Text
        txt_Center2.Text = Label_Scale2b.Text
        EventsAreEnabled = True
        RefreshNeeded = True
    End Sub

    Private Sub SetScaleLabels()
        Dim FS1 As String = "0.#"
        Select Case cmb_Units1.Text
            Case "0.05", "0.02", "0.01" : FS1 = "0.##"
            Case "0.005", "0.002", "0.001" : FS1 = "0.###"
            Case "0.0005", "0.0002", "0.0001" : FS1 = "0.####"
        End Select
        Dim FS2 As String = "0.#"
        Select Case cmb_Units2.Text
            Case "0.05", "0.02", "0.01" : FS2 = "0.##"
            Case "0.005", "0.002", "0.001" : FS2 = "0.###"
            Case "0.0005", "0.0002", "0.0001" : FS2 = "0.####"
        End Select
        Label_Scale1a.Text = ""
        Label_Scale1b.Text = ""
        Label_Scale1c.Text = ""
        Label_Scale2a.Text = ""
        Label_Scale2b.Text = ""
        Label_Scale2c.Text = ""
        If ch1.Slot >= 0 Then
            Dim zv As Single = ch1.Value_Zero
            Label_Scale1a.Text = (zv + 5 * ch1.vDiv).ToString(FS1, GCI)
            Label_Scale1b.Text = zv.ToString(FS1, GCI)
            Label_Scale1c.Text = (zv - 5 * ch1.vDiv).ToString(FS1, GCI)
        End If
        If ch2.Slot >= 0 Then
            Dim zv As Single = ch2.Value_Zero
            Label_Scale2a.Text = (zv + 5 * ch2.vDiv).ToString(FS2, GCI)
            Label_Scale2b.Text = zv.ToString(FS2, GCI)
            Label_Scale2c.Text = (zv - 5 * ch2.vDiv).ToString(FS2, GCI)
        End If
        Label_Scale1a.Refresh()
        Label_Scale1b.Refresh()
        Label_Scale1c.Refresh()
        Label_Scale2a.Refresh()
        Label_Scale2b.Refresh()
        Label_Scale2c.Refresh()
    End Sub

    Private Sub ShowStatusBarValues()
        If ch1.Slot >= 0 Then
            With ch1
                lbl_Value1.Text = "Value = " + .Value.ToString(GCI)
                lbl_ValuePP1.Text = "Peak to peak = " + (.ValueMax - .ValueMin).ToString(GCI)
                .ValueMax = Single.MinValue
                .ValueMin = Single.MaxValue
            End With
        End If
        If ch2.Slot >= 0 Then
            With ch2
                lbl_Value2.Text = "Value = " + .Value.ToString(GCI)
                lbl_ValuePP2.Text = "Peak to peak = " + (.ValueMax - .ValueMin).ToString(GCI)
                .ValueMax = Single.MinValue
                .ValueMin = Single.MaxValue
            End With
        End If
    End Sub

    ' =============================================================
    '  LOAD BUFFER
    ' =============================================================
    Friend Sub LoadBuffer()
        Dim ofd As OpenFileDialog = New OpenFileDialog()
        ofd.InitialDirectory = Application.StartupPath + "\Buffers\"
        IO.Directory.CreateDirectory(ofd.InitialDirectory)
        ofd.Filter = "Buffer file (*.csv)|*.csv"
        ofd.DefaultExt = ".csv"
        ofd.Multiselect = True
        If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LoadBufferFrom(ofd.FileName)
        End If
    End Sub

    Friend Sub LoadBufferFrom(ByVal filename As String)
        If My.Computer.FileSystem.FileExists(filename) Then
            btn_Run.Checked = False
            StartStopAcquisition(False)
            fifo1.Flush()
            Dim buf() As FIFO.FifoEntry = fifo1.GetBuffer
            Dim f As System.IO.StreamReader
            f = IO.File.OpenText(filename)
            Dim i As Int32
            For i = 0 To buf.Length - 1
                If f.EndOfStream Then Exit For
                Dim p() As String = f.ReadLine.Split(","c)
                If p.Length = 2 Then
                    buf(i).Value1 = CSng(Val(p(0)))
                    buf(i).Value2 = CSng(Val(p(1)))
                End If
            Next
            fifo1.SetWriteIndex(i)
            fifo1.SetNumEntries(i)
            f.Close()
        End If
    End Sub

    ' =============================================================
    '  SAVE BUFFER
    ' =============================================================
    Friend Sub SaveBuffer()
        If btn_Cursors.Checked Then
            If MessageBox.Show("Warning: Cursors are enabled." + vbCrLf + _
                               "Only the area between the two cursors will be saved." + vbCrLf + vbCrLf + _
                               "OK to proceed and save?", _
                               "Message from Theremino SignalScope", _
                               MessageBoxButtons.OKCancel, _
                               MessageBoxIcon.Information) <> Windows.Forms.DialogResult.OK Then Return
        End If
        Dim sfd As SaveFileDialog = New SaveFileDialog()
        sfd.InitialDirectory = Application.StartupPath + "\Buffers\"
        IO.Directory.CreateDirectory(sfd.InitialDirectory)
        sfd.DefaultExt = ".csv"
        sfd.Filter = "Buffer file (*.csv)|*.csv"
        sfd.FileName = "Buffer_" & Date.Now.ToString("yyyy_MM_dd_HH_mm_ss")
        If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SaveBufferTo(sfd.FileName)
        End If
    End Sub

    Friend Sub SaveBufferTo(ByVal filename As String, Optional ByVal SaveAllBuffer As Boolean = False)
        Dim Buffer() As FIFO.FifoEntry = fifo1.GetBuffer
        IO.Directory.CreateDirectory(IO.Path.GetDirectoryName(filename))
        Dim FormatString As String = "+0.000000E+0;-0.000000E+0"
        Dim index As Int32
        Using sw As IO.StreamWriter = New IO.StreamWriter(filename)
            If btn_Cursors.Checked And Not SaveAllBuffer Then
                ' --------------------------------------------------- get cursor indexes and eventually swap
                Dim c1 As Int32 = GetCursor1_FifoIndex()
                Dim c2 As Int32 = GetCursor2_FifoIndex()
                If c1 > c2 Then Swap(c1, c2)
                ' --------------------------------------------------- save the cursor area
                For i As Int32 = c1 To c2
                    index = i
                    index = fifo1.CorrectIndex(index)
                    sw.WriteLine(Buffer(index).Value1.ToString(FormatString, GCI) + ", " + _
                                 Buffer(index).Value2.ToString(FormatString, GCI))
                Next
            Else
                ' --------------------------------------------------- save all the buffer
                Dim writeindex As Int32 = fifo1.GetWriteIndex
                For i As Int32 = writeindex - fifo1.GetNumEntries To writeindex - 1
                    index = i
                    index = fifo1.CorrectIndex(index)
                    sw.WriteLine(Buffer(index).Value1.ToString(FormatString, GCI) + ", " + _
                                 Buffer(index).Value2.ToString(FormatString, GCI))
                Next
            End If
        End Using
    End Sub

End Class