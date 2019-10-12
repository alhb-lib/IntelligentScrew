
' TODO -- MAIN LIST 
' -------------------------------------------------------------
' Add class CounterReader for encoders (from folder "_Docs and examples")
' Detect disconnection and restart (show button auto reconect)
' Debug stepper with adc24 conflict


' DONE - MAIN LIST
' -------------------------------------------------------------
' 7.5
' Calibrate zero all'avvio
' Corrette label MinValue MaxValue e altre al cambio lingua
' Eliminato errore dei Pins Adc24 in mancanza di configurazione
' If trying to edit a not-existant SlotNames file then create it
' Slot names on 7 and 8 when adc not ok 
' Error when load-configuration and "annulla" (abort) 
' Not working add remove adc24 pins
' SlotName (if exists) in the scope details 
' Trim value clicking everywhere on a Pinline
' 7.3
' Setting "Speed = 100" the Smoothing function is completely excluded
' Patched a glitch in the PwmFast when setting DutyCycle around 999...1000 
' 7.2
' Backup configs
' Scope updates
' 7.0
' Corrected error when changing PinType
' 6.9
' Menu buttons for Config and SlotNames editing, with reload.
' Improved Save-Params with MouseLeave instead of LostFocus
' 6.8
' Warn the user if some input channels have the same Slot
' When closing Servo are disabled with Sleep 
' Adc24 minimum Pin number limited by active pins
' MinValue and MaxValue with 3 decimals
' MaxSpeed and MaxAcc with 1 decimal
' StepsPerMM with 3 decimals
' Improved stability for adc24 combos
' Improved stability changing master names
' Updated Help
' Form2 LabelDetails.Width = 124
' 6.7
' Corrected FastPwm granularity 
' Improved LimitComboDropDownHeight

'  Message for Adc24 and Steppers
'  Language strings

'  Now Adc_24_ch_b direction is Unused (to not write to slots)
'  Direction = Unused also for:  Adc24, ADc24_din and Encoder_b

'  --- Adc_24_din Adc_24_ch_b and Encoder_b --- 
'  - showing PinProps panel reduced to PinType only
'  - and not opening the oscilloscope

'  Channels 15,13,11,9,7,5,3 damaged changing (Diff/Pseudo/Biased)
'  of any precedent channel (14,12,10,8,6,4,2)
'  After a Recognize the error is corrected

'  Master are loaded in alphabetic order

' -------------------------------------
'  Slot zero commands
' -------------------------------------
' Send 333, wait 50mS, send 666, wait 50 mS, send command
' Command 1 = Recognize
' Command 2 = Calibrate

Public Class Form1

    Private EventsLock As Object = New Object

    Public Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SchedulerMaxPrecision()
        Load_INI()
        Load_ConfigDatabase()
        SetLocales()
        ToolTips_Init()
        ToolStrip1.Renderer = New ToolStripButtonRenderer
        ' ---------------------------------------------------------------- REAL-TIME
        System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Normal
        System.Diagnostics.Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime
        ' ---------------------------------------------------------------- USB - MASTERS - SLAVES
        CommandSlot_StartRecognizeMarker()
        TheSystem_InitMasters()
        TheSystem_RecognizeSlaves()
        TheSystem_SetParkingPositions()
        TheSystem_StartTimers()
        CommnandSlot_WriteMasterCount()
        ' ---------------------------------------------------------------- Timer_10Hz = 100mS = 10Hz 
        Timer_10Hz.Interval = 100  'reduced 5 Hz to lower CPU charge
        Timer_10Hz.Start()
        ' ---------------------------------------------------------------- Timer_1Hz = 1000mS = 1Hz
        Timer_1Hz.Interval = 1000
        Timer_1Hz.Start()
        ' ---------------------------------------------------------------- Timer_60Hz = 16.6mS = 60Hz
        Timer_60Hz.Interval = 10
        Timer_60Hz.Start()
        ' ---------------------------------------------------------------- WINDOW
        If Not OperatingSystemIsWindows Then
            Me.MinimumSize = New Size(650, 500)
        End If
        If Not ConfigurationIsValid Then
            WindowState = FormWindowState.Normal
        End If
        If Form2_VisibleAtStart Then
            Form2.Show()
        Else
            Form2.Visible = False
        End If
        Text = AppTitleAndVersion("Theremino HAL")
        ' ----------------------------------------------------------------
        EventsAreEnabled = True
        ' ----------------------------------------------------------------
        ListView_SelectLine(MyListView1, 0)
        ShowProps()
        EnableDisableLockedControls()
        Form2.RestoreSelectedPins()

        EventsAreEnabled = False
        MyListView1.Focus()
        ShowInTaskbar = False
        ShowInTaskbar = True
        EventsAreEnabled = True

        Refresh()
        Form2.Refresh()
        Me.Opacity = 1
        Form2.Opacity = 1

        ' ----------------------------------------------------------------
        ' Button "AutoReconnect" Disabled 
        ' (also commented in the "Timer_10Hz_Tick" function)
        ' ----------------------------------------------------------------
        btn_Reconnect.Enabled = False
        ' ----------------------------------------------------------------

        InvalidConfigMessage()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not EventsAreEnabled Then Return
        CloseAllAndExit()
    End Sub

    Private Sub Form1_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        If Not EventsAreEnabled Then Return
        LimitFormPosition(Me)
    End Sub

    Private Sub CloseAllAndExit()
        TheSystem_StopTimers()
        TheSystem_SetParkingPositions()
        TheSystem_UpdateAndSaveConfigDatabase()
        Save_INI()
        SchedulerDefaultPrecision()
    End Sub

    Private Sub InvalidConfigMessage()
        If ConfigurationIsValid = False Then
            If DuplicateNames Then
                MessageBox.Show(Msg_Warning + vbCrLf + vbCrLf +
                                Msg_Duplicate1 + vbCrLf + vbCrLf +
                                Msg_Duplicate2,
                                Msg_HalMessage,
                                MessageBoxButtons.OK)
            Else
                MessageBox.Show(Msg_Warning + vbCrLf + vbCrLf +
                    Msg_Validate2 + vbCrLf + vbCrLf +
                    Msg_Validate3 + vbCrLf + vbCrLf +
                    Msg_Validate4 + vbCrLf + vbCrLf +
                    Msg_Validate5,
                    Msg_HalMessage,
                    MessageBoxButtons.OK)
            End If
        End If
    End Sub

    ' =========================================================================
    '  WINDOWS SCHEDULER PRECISION
    ' ========================================================================= 
    Private Declare Function timeBeginPeriod Lib "winmm.dll" (ByVal uPeriod As Int32) As Int32
    Private Declare Function timeEndPeriod Lib "winmm.dll" (ByVal uPeriod As Int32) As Int32
    Private Sub SchedulerMaxPrecision()
        If OperatingSystemIsWindows Then
            timeBeginPeriod(1)
        End If
    End Sub
    Private Sub SchedulerDefaultPrecision()
        If OperatingSystemIsWindows Then
            timeEndPeriod(1)
        End If
    End Sub

    ' ===================================================================================
    '  MenuStrip and ToolStrip accepting the first click
    '  If the form receives a WM_PARENTNOTIFY (528) message and is not focused 
    '  then the form is activated before to exec the message
    ' ===================================================================================
    <DebuggerStepThrough()>
    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = 528 AndAlso Not Me.Focused Then
            Me.Activate()
        End If
        MyBase.WndProc(m)
    End Sub

    ' ===================================================================================
    '   MenuStrip and ToolStrip Gradients
    ' ===================================================================================
    Private Sub MenuStrip1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MenuStrip1.Paint
        Dim bounds As New Rectangle(0, 0,
                                    MenuStrip1.Width, MenuStrip1.Height)
        Dim brush As New Drawing2D.LinearGradientBrush(bounds,
                                                       Color.FromArgb(240, 240, 240),
                                                       Color.FromArgb(200, 200, 200),
                                                       Drawing2D.LinearGradientMode.Horizontal)
        e.Graphics.FillRectangle(brush, bounds)
    End Sub
    Private Sub ToolStrip1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ToolStrip1.Paint
        Dim bounds As New Rectangle(0, 0,
                                    ToolStrip1.Width, ToolStrip1.Height)
        Dim brush As New Drawing2D.LinearGradientBrush(bounds,
                                                       Color.White,
                                                       Color.FromArgb(200, 200, 200),
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
            If btn IsNot Nothing AndAlso btn.CheckOnClick AndAlso btn.Checked Then
                Dim bounds As Rectangle = New Rectangle(0, 0, e.Item.Width - 1, e.Item.Height - 1)
                Dim brush As New Drawing2D.LinearGradientBrush(bounds,
                                                               Color.Gold,
                                                               Color.FromArgb(250, 250, 250),
                                                               Drawing2D.LinearGradientMode.Vertical)
                e.Graphics.FillRectangle(brush, bounds)
                e.Graphics.DrawRectangle(Pens.Orange, bounds)
            Else
                MyBase.OnRenderButtonBackground(e)
            End If
        End Sub
    End Class


    ' =======================================================================================
    '   MENU FILE
    ' =======================================================================================
    Private Sub Menu_File_OpenProgramFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_File_OpenProgramFolder.Click
        Process.Start(Application.StartupPath)
    End Sub
    Private Sub Menu_File_EditSlotNames_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_File_EditSlotNames.Click
        Me.Opacity = 0.7
        Dim fname As String = Application.StartupPath & "\SlotNames.txt"
        If Not FileExists(fname) Then IO.File.Create(fname)
        ProcessStartAndWait(PlatformAdjustedFileName(fname))
        Me.Opacity = 1
        TheSystem_ListComponents()
        ListView_SetAllLineColors()
    End Sub
    Private Sub Menu_File_EditConfigurations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_File_EditConfigurations.Click
        Me.Opacity = 0.7
        ProcessStartAndWait(PlatformAdjustedFileName(Application.StartupPath & "\Theremino_HAL_ConfigDatabase.txt"))
        Cmd_Recognize()
        Me.Opacity = 1
    End Sub
    Private BackupFolder As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\Theremino\HAL_Backups\"
    Private HalFolder As String = Application.StartupPath + "\"
    Private Sub Menu_File_BackupConfigurations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_File_BackupConfigurations.Click
        Dim DestFolder As String = Date.Now.ToString("yyyy_MM_dd_HH_mm_ss")
        DestFolder = InputBox(vbCrLf + "Backup folder name?", "Theremino HAL - Save to backup folder", DestFolder)
        If DestFolder <> "" Then
            DestFolder = BackupFolder + DestFolder + "\"
            Try
                My.Computer.FileSystem.CreateDirectory(DestFolder)
                CopyFileIfExists(HalFolder, DestFolder, "Theremino_HAL_ConfigDatabase.txt")
                CopyFileIfExists(HalFolder, DestFolder, "SlotNames.txt")
                'CopyFileIfExists(HalFolder, DestFolder, "Theremino_HAL_INI.txt")
                'CopyFileIfExists(HalFolder, DestFolder, "Theremino_SlotViewer_INI.txt")
            Catch
            End Try
        End If
    End Sub
    Private Sub Menu_File_LoadConfigurations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_File_LoadConfigurations.Click
        Dim SourceFolder As String = SelectFolder(BackupFolder)
        If SourceFolder <> "" Then
            CopyFileIfExists(SourceFolder, HalFolder, "Theremino_HAL_ConfigDatabase.txt")
            CopyFileIfExists(SourceFolder, HalFolder, "SlotNames.txt")
            'CopyFileIfExists(SourceFolder, HalFolder, "Theremino_HAL_INI.txt")
            'CopyFileIfExists(SourceFolder, HalFolder, "Theremino_SlotViewer_INI.txt")
            Cmd_Recognize()
        End If
    End Sub
    Friend Sub CopyFileIfExists(ByVal srcFolder As String, ByVal destFolder As String, ByVal fileName As String)
        Dim src As String = srcFolder + fileName
        Dim dest As String = destFolder + fileName
        If IO.File.Exists(src) Then
            IO.File.Copy(src, dest, True)
        End If
    End Sub
    Friend Function SelectFolder(ByVal folder As String) As String
        Dim FBD As System.Windows.Forms.FolderBrowserDialog
        FBD = New System.Windows.Forms.FolderBrowserDialog()
        With FBD
            .Reset()
            .ShowNewFolderButton = False
            ' -- USE ROOTFOLDER TO LIMIT USER CHOOSE AREA -- ( No RootFolder NO limits )
            '.RootFolder = Environment.SpecialFolder.MyDocuments
            .RootFolder = Environment.SpecialFolder.MyComputer
            ' --------------------------------------------------------------------------
            .SelectedPath = folder
            .Description = vbCr & "Select the backup folder"
            SendKeys.Send("{TAB}{TAB}{RIGHT}")
            If .ShowDialog = DialogResult.OK Then
                Return .SelectedPath + "\"
            End If
        End With
        Return ""
    End Function

    Private Sub Menu_File_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_File_Exit.Click
        CloseAllAndExit()
        Me.Close()
    End Sub


    ' =======================================================================================
    '   MENU LANGUAGE
    ' =======================================================================================
    Private Sub Menu_Language_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_Language.DropDownOpening
        For Each item As ToolStripMenuItem In Menu_Language.DropDownItems
            If item.Name.EndsWith(Language, StringComparison.InvariantCultureIgnoreCase) Then
                item.Select()
            End If
        Next
    End Sub
    Private Sub Menu_Language_Deutsch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_Language_Deutsch.Click
        Language = "Deutsch"
        SetLocales()
        Save_INI()
        ToolTips_Init()
        ShowProps()
    End Sub
    Private Sub Menu_Language_English_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_Language_English.Click
        Language = "English"
        SetLocales()
        Save_INI()
        ToolTips_Init()
        ShowProps()
    End Sub
    Private Sub Menu_Language_Espanol_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_Language_Espanol.Click
        Language = "Espanol"
        SetLocales()
        Save_INI()
        ToolTips_Init()
        ShowProps()
    End Sub
    Private Sub Menu_Language_Portoguese_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_Language_Portoguese.Click
        Language = "Portoguese"
        SetLocales()
        Save_INI()
        ToolTips_Init()
        ShowProps()
    End Sub
    Private Sub Menu_Language_Francais_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_Language_Francais.Click
        Language = "Francais"
        SetLocales()
        Save_INI()
        ToolTips_Init()
        ShowProps()
    End Sub
    Private Sub Menu_Language_Italian_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Menu_Language_Italian.Click
        Language = "Italian"
        SetLocales()
        Save_INI()
        ToolTips_Init()
        ShowProps()
    End Sub
    Private Sub Menu_Language_Japanese_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Language_Japanese.Click
        Language = "Japanese"
        SetLocales()
        Save_INI()
        ToolTips_Init()
        ShowProps()
    End Sub
    Private Sub Menu_Language_Chinese_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Language_Chinese.Click
        Language = "Chinese"
        SetLocales()
        Save_INI()
        ToolTips_Init()
        ShowProps()
    End Sub

    ' =======================================================================================
    '   MENU HELP
    ' =======================================================================================
    Private Sub Menu_Help_ProgramHelp_ENG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Help_ProgramHelp.Click
        OpenLocalizedHelp("ThereminoHAL_Help", ".pdf")
    End Sub
    Private Sub OpenLocalizedHelp(ByVal name As String, Optional ByVal ext As String = ".rtf")
        Dim LangName As String = Strings.Left(Language, 3).ToUpper.Replace("JAP", "JPN")
        Dim fname As String = PlatformAdjustedFileName(Application.StartupPath & "\Docs\" & name & "_" & LangName & ext)
        If FileExists(fname) Then
            Process.Start(fname)
        Else
            fname = PlatformAdjustedFileName(Application.StartupPath & "\Docs\" & name & "_ENG" & ext)
            If FileExists(fname) Then
                Process.Start(fname)
            Else
                fname = PlatformAdjustedFileName(Application.StartupPath & "\Docs\" & name & "_ITA" & ext)
                If FileExists(fname) Then
                    Process.Start(fname)
                Else
                    fname = PlatformAdjustedFileName(Application.StartupPath & "\Docs\" & name & ext)
                    If FileExists(fname) Then
                        Process.Start(fname)
                    End If
                End If
            End If
        End If
    End Sub

    ' =======================================================================================
    '   MENU ABOUT
    ' =======================================================================================
    Private Sub Menu_About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_About.Click
        Form_About.ShowDialog()
    End Sub

    ' =======================================================================================
    '   TOOLBAR
    ' =======================================================================================
    Private Sub ToolStripButton_EditConfigurations_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Menu_File_EditConfigurations_Click(Nothing, Nothing)
    End Sub
    Private Sub ToolStripButton_EditSlotNames_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Menu_File_EditSlotNames_Click(Nothing, Nothing)
    End Sub
    Private Sub ToolStripButton_Recognize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Recognize.Click
        Cmd_Recognize()
        ToolStripButton_Recognize.Checked = False
    End Sub
    Private Sub ToolStripButton_Validate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Validate.Click
        Cmd_Validate()
        ToolStripButton_Validate.Checked = False
    End Sub
    Private Sub ToolStripButton_Lock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Lock.Click
        If ToolStripButton_Lock.Checked Then
            ValidMasterNames_Init()
        Else
            ValidMasterNames_Reset()
        End If
        Save_INI()
        EnableDisableLockedControls()
    End Sub
    Private Sub ToolStripButton_Disconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton_Disconnect.Click
        Cmd_DisconnectSelectedMaster()
        ToolStripButton_Disconnect.Checked = False
    End Sub
    Private Sub EnableDisableLockedControls()
        If ToolStripButton_Lock.Checked Then
            ToolStripButton_Disconnect.Enabled = False
            cmb_MasterNames.BackColor = Color.FromArgb(220, 220, 220)
            cmb_MasterNames.Enabled = False
            btn_MasterName.Enabled = False
        Else
            ToolStripButton_Disconnect.Enabled = True
            cmb_MasterNames.BackColor = Color.AliceBlue
            cmb_MasterNames.Enabled = True
            btn_MasterName.Enabled = True
        End If
    End Sub

    ' ===========================================================================================================
    '   Commands execution
    ' ===========================================================================================================
    'Friend Sub Cmd_Reconnect()
    '    EventsAreEnabled = False
    '    Timer_10Hz.Stop()
    '    TheSystem_StopTimers()
    '    TheSystem_ReconnectMasters()
    '    TheSystem_StartTimers()
    '    Timer_10Hz.Start()
    '    EventsAreEnabled = True
    '    ' --------------------------------------------------------- eventually show the message
    '    InvalidConfigMessage()
    '    ' --------------------------------------------------------- write master count
    '    CommnandSlot_WriteMasterCount()
    'End Sub
    Private Sub Cmd_Recognize()
        CommandSlot_StartRecognizeMarker()
        EventsAreEnabled = False
        Dim OldSelectedLine As Int32 = SelectedLine
        Load_ConfigDatabase()
        Timer_10Hz.Stop()
        TheSystem_StopTimers()
        TheSystem_InitMasters()
        TheSystem_RecognizeSlaves()
        ShowProps()
        TheSystem_StartTimers()
        Timer_10Hz.Start()
        EventsAreEnabled = True
        If OldSelectedLine < 0 Then OldSelectedLine = 0
        ListView_SelectLine(MyListView1, OldSelectedLine)
        Form2.RestoreSelectedPins()
        ' --------------------------------------------------------- eventually show the message
        InvalidConfigMessage()
        ' --------------------------------------------------------- write master count
        CommnandSlot_WriteMasterCount()
    End Sub

    Private Sub CommandSlot_StartRecognizeMarker()
        Slots.WriteSlot(CommandSlot, -1)
    End Sub
    Private Sub CommnandSlot_WriteMasterCount()
        Slots.WriteSlot(CommandSlot, Masters.Count)
    End Sub

    Private Sub Cmd_Validate()
        If Not EventsAreEnabled Then Return
        EventsAreEnabled = False
        Dim OldSelectedLine As Int32 = SelectedLine
        TheSystem_ValidateConfiguration()
        TheSystem_UpdateAndSaveConfigDatabase()
        TheSystem_StartTimers()
        EventsAreEnabled = True
        ListView_SelectLine(MyListView1, OldSelectedLine)
    End Sub
    Private Sub Cmd_DisconnectSelectedMaster()
        EventsAreEnabled = False
        Load_ConfigDatabase()
        Timer_10Hz.Stop()
        TheSystem_StopTimers()
        ' -----------------------------------------------------
        TheSystem_DisconnectMaster(FindMasterByListLine(SelectedLine))
        TheSystem_ListComponents()
        ListView_SetAllLineColors()
        SelectedLine = -1
        ' -----------------------------------------------------
        ShowProps()
        TheSystem_StartTimers()
        Timer_10Hz.Start()
        EventsAreEnabled = True
        ListView_SelectLine(MyListView1, 0)
    End Sub
    Private Sub btn_Calibrate_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles btn_Calibrate.ClickButtonArea
        If Not EventsAreEnabled Then Return
        EventsAreEnabled = False
        DoCalibrationAndResetTime()
        CalibrationTime = 0.8
        btn_Calibrate.Refresh()
        EventsAreEnabled = True
    End Sub


    ' ===========================================================================================================
    '   UPDATES
    ' ===========================================================================================================
    Private Sub Timer_10Hz_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_10Hz.Tick
        If Not EventsAreEnabled Then Return
        If Not ConfigurationIsValid Then Return
        ' ----------------------------------------------------------------- Test Master Error
        TheSystem_TestMasterError()
        ' ----------------------------------------------------------------- updates
        SyncLock EventsLock
            '
            If WindowState <> FormWindowState.Minimized Then
                ' ---------------------------------------------------------- UpdateListedValues
                TheSystem_UpdateListedValues()
                ' ---------------------------------------------------------- update RepeatFrequency
                Dim m As Master = FindMasterByListLine(SelectedLine)
                If m IsNot Nothing Then
                    lbl_RepeatFrequency.Text = m.CommFps.ToString("0")
                    If m.CommFps < 50 Then
                        lbl_RepeatFrequency.BackColor = Color.LightSalmon
                    Else
                        lbl_RepeatFrequency.BackColor = Color.Transparent
                    End If
                    lbl_ErrorRate.Text = m.ErrorRate.ToString("0.00", GCI)
                    If m.ErrorRate >= 0.1 Then
                        lbl_ErrorRate.BackColor = Color.LightSalmon
                        m.SetSpeed()
                    Else
                        lbl_ErrorRate.BackColor = Color.Transparent
                    End If
                    If m.ErrorRate >= 0.01 Then
                        If ToolStripButton_BeepOnErrors.Checked Then Beep_RepetitionLimited(150)
                    End If
                End If
            End If
            ' ---------------------------------------------------------- Auto Reconnect or Recognize
            ' NOT WORKING
            'If Slots.ReadSlot_NoNan(CommandSlot) = 0 Then
            '    'Slots.WriteSlot(CommandSlot, NAN_Recognize)
            '    Cmd_Reconnect()
            '    Threading.Thread.Sleep(500)       ' wait 0.5 seconds before next try
            'End If
            ' NOT WORKING
            'If btn_Reconnect.Checked Then
            '    For Each m As Master In Masters
            '        If Not m.Hid.MyDeviceDetected Then
            '            Cmd_Recognize()
            '            Threading.Thread.Sleep(500)
            '            Exit For
            '        End If
            '    Next
            'End If
            ' NOT WORKING
            'If btn_Reconnect.Checked Then
            '    For Each m As Master In Masters
            '        If Not m.Hid.MyDeviceDetected Then
            '            Cmd_Reconnect()
            '            Exit For
            '        End If
            '        If m.Hid.USB_RxData(0) = 0 AndAlso _
            '            (m.Hid.USB_RxData(1) = Slave.SlaveTypes.MasterPins Or _
            '             m.Hid.USB_RxData(1) = Slave.SlaveTypes.MasterPinsV2 Or _
            '             m.Hid.USB_RxData(1) = Slave.SlaveTypes.MasterPinsV4) Then
            '            Dim AllZero As Boolean = True
            '            For i As Int32 = 2 To 200
            '                If m.Hid.USB_RxData(i) <> 0 Then
            '                    AllZero = False
            '                    Exit For
            '                End If
            '            Next
            '            If AllZero Then
            '                Cmd_Recognize()
            '                Exit For
            '            End If
            '        End If
            '    Next
            'End If
            ' ---------------------------------------------------------- edit
            If EditValue_MouseEditFlag Then
                If LeftMousePressed() Then
                    EditValue_MouseMove()
                Else
                    ShowCursor()
                    EditValue_MouseEditFlag = False
                End If
            End If
            '
        End SyncLock
    End Sub

    ' ===========================================================================================================
    '   Command Slot
    ' ===========================================================================================================
    Private CommandStatus As Int32 = 0
    Private Sub Timer_60Hz_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_60Hz.Tick
        Dim n As Single = Slots.ReadSlot(CommandSlot)
        Select Case CommandStatus
            Case 0                                  ' Waiting NANs or 333
                If IsNanRecognize(n) Then
                    Cmd_Recognize()
                ElseIf IsNanCalibrate(n) Then
                    DoCalibrationAndResetTime()
                End If
                If n = 333 Then
                    CommandStatus = 1
                End If
            Case 1                                  ' Waiting 666
                Select Case n
                    Case 333
                        '
                    Case 666
                        CommandStatus = 2
                    Case Else
                        CommandStatus = 0
                End Select
            Case 2                                  ' Waiting commands "1" or "2"
                Select Case n
                    Case 666
                        '
                    Case Else
                        If n = 1 Then
                            Cmd_Recognize()
                        ElseIf n = 2 Then
                            DoCalibrationAndResetTime()
                        End If
                        CommandStatus = 0
                End Select
        End Select
    End Sub


    ' ===========================================================================================================
    '   EDIT VALUES
    ' ===========================================================================================================
    Private EditValue_MouseEditFlag As Boolean = False
    Private EditValue_Slot As Int32
    Private EditValue_Multiplier As Int32
    Private EditValue_StartCursorPos As Point
    Private EditValue_MaxValue As Single
    Private EditValue_MinValue As Single
    Private EditValue_IsServoPin As Boolean

    Private Sub MyListView1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyListView1.MouseDown
        If Not ConfigurationIsValid Then Return
        StartMouseEdit()
    End Sub

    Private Sub StartMouseEdit()
        If EditValue_MouseEditFlag Then Return
        Dim column As Int32 = ListView_GetColumnIndex(MyListView1)
        Dim line As Int32 = ListView_GetLineIndex(MyListView1)
        If line >= 0 Then
            Dim slotString As String = MyListView1.Items(line).SubItems(3).Text
            If slotString <> "" Then
                Dim p As Pin = FindPinByListLine(line)
                If p IsNot Nothing AndAlso p.Direction <> Pin.Directions.Unused Then
                    HideCursor()
                    EditValue_MouseEditFlag = True
                    EditValue_StartCursorPos = Cursor.Position
                    ' ----------------------------------------------------------------------
                    EditValue_Slot = p.Slot
                    EditValue_IsServoPin = False
                    If p.GetPinType() = Pin.PinTypes.SERVO_8 Then EditValue_IsServoPin = True
                    If p.GetPinType() = Pin.PinTypes.SERVO_16 Then EditValue_IsServoPin = True
                    If p.GetPinType() = Pin.PinTypes.STEPPER Then
                        EditValue_MaxValue = Single.MaxValue
                        EditValue_MinValue = Single.MinValue
                    Else
                        EditValue_MaxValue = CSng(Math.Max(p.Value_Max, p.Value_Min))
                        EditValue_MinValue = CSng(Math.Min(p.Value_Max, p.Value_Min))
                    End If
                    EditValue_Multiplier = 1
                    Dim range As Int32 = CInt(Math.Abs(p.Value_Max - p.Value_Min))
                    If range > 500 Then EditValue_Multiplier = 2
                    If range > 1000 Then EditValue_Multiplier = 5
                    If range > 2000 Then EditValue_Multiplier = 10
                    If range > 5000 Then EditValue_Multiplier = 20
                    If range > 10000 Then EditValue_Multiplier = 50
                End If
            End If
        End If
    End Sub

    Private Sub MyListView1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyListView1.MouseMove
        If Not EventsAreEnabled Then Return
        If EditValue_MouseEditFlag Then
            EditValue_MouseMove()
        End If
    End Sub

    Private Sub EditValue_MouseMove()
        Dim delta As Int32 = EditValue_StartCursorPos.Y - Cursor.Position.Y
        Cursor.Position = EditValue_StartCursorPos
        ChangeValueByDelta(delta)
    End Sub

    Private Sub ChangeValueByDelta(ByVal delta As Single)
        ' do not limit the value if not moving
        If delta = 0 Then Return

        'Form2.StopTimer()
        EventsAreEnabled = False

        Dim v As Single
        v = Slots.ReadSlot(EditValue_Slot)

        If Single.IsNaN(v) Then
            v = EditValue_MinValue - 9
        End If
        '
        v += delta * EditValue_Multiplier
        v = Math.Min(v, EditValue_MaxValue)
        '
        If v < EditValue_MinValue Then
            If v < -8 AndAlso EditValue_IsServoPin Then
                v = NAN_Sleep
            Else
                v = EditValue_MinValue
            End If
        End If
        '
        Slots.WriteSlot(EditValue_Slot, v)
        '
        Application.DoEvents()

        EventsAreEnabled = True
        'Form2.StartTimer()
    End Sub

    Private Sub MyListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyListView1.MouseDoubleClick
        Dim p As Pin = GetSelectedPin()
        If p Is Nothing Then Return
        If p.Direction = Pin.Directions.Unused Then Return
        Form2.Show()
    End Sub

    Private Sub MyListView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyListView1.MouseUp
        Dim p As Pin = GetSelectedPin()
        If p Is Nothing Then Return
        If p.Direction = Pin.Directions.Unused Then Return
        Form2.SetPinDetails()
    End Sub

    ' ------------------------------------------------------------------
    '  Call ListViewResize from Form.Resize (not from ListView.resize)
    '  (otherwise the listview scroll produces problems)
    ' ------------------------------------------------------------------
    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Not EventsAreEnabled Then Return
        TheSystem_ListViewResize()
    End Sub


    ' ---------------------------------------------------------------------------------------------------
    '  MyListView1.Activation = ItemActivation.Standard   <<<< USE THIS OR THE CURSOR CAN NOT BE CHANGED
    ' ---------------------------------------------------------------------------------------------------
    Private BlankCursor As Cursor = New Cursor(New IO.MemoryStream(My.Resources.Blank))
    Private Sub HideCursor()
        Cursor.Hide()
        MyListView1.Cursor = BlankCursor
    End Sub
    Private Sub ShowCursor()
        Cursor.Show()
        MyListView1.Cursor = Cursors.Hand
    End Sub



    ' ===========================================================================================================
    '   SET MASTER AND PIN PROPERTIES
    ' ===========================================================================================================
    Private Sub btn_MasterName_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles btn_MasterName.ClickButtonArea
        Dim newName As String
        newName = InputBox("New name for the selected master",
                           "Edit Master name",
                           cmb_MasterNames.Text,
                           Me.Right - 370,
                           Me.Top + 125)

        newName = newName.Trim
        If newName <> "" Then
            ' TODO copy in all the HAL
            ' ----------------------------------------- if the new name already exists
            If FindConfigByName(newName) >= 0 Then
                MessageBox.Show("The name """ + newName + """ already exists." + vbCrLf +
                                "the existing configuration will be used.")
            End If
            Change_SelectedMaster_Name(newName)
        End If
    End Sub

    Private Sub Change_SelectedMaster_Name(ByVal newName As String)
        Me.Cursor = Cursors.AppStarting
        ' --------------------------------------------------------------------- init master
        Dim m As Master
        m = FindMasterByListLine(SelectedLine)
        If m Is Nothing Then
            Me.Cursor = Cursors.Default
            Return
        End If
        '
        newName = Strings.Left(newName, 16)
        '
        Dim oldName As String = m.GetName
        ' ----------------------------------------------------- try to change the hardware name
        If newName <> oldName Then
            For i As Int32 = 1 To 3
                m.SetName(newName)
                m.WriteNameToHardware()
                m.ReadNameFromHardware()
                If m.GetName = newName Then
                    ' ----------------------------------------- if the new name is not in the database
                    If oldName <> "" And FindConfigByName(newName) < 0 Then
                        Dim configid As Int32 = FindConfigByName(oldName)
                        If configid >= 0 Then
                            Dim config As String() = CType(CType(ConfigDatabase(configid), String()).Clone, String())
                            config(0) = config(0).Replace(oldName, newName)
                            AddToConfigDatabase(config)
                            TheSystem_SaveConfigDatabase()
                        End If
                    End If
                    ' ----------------------------------------- 
                    Cmd_Recognize()
                    TheSystem_UpdateListedSubtypes()
                    TheSystem_UpdateConfigDatabase()
                    TheSystem_SaveConfigDatabase()
                    Me.Cursor = Cursors.Default
                    Return
                End If
            Next
            MessageBox.Show("Error writing the name """ + newName + """ to the Master module")
            m.SetName(oldName)
            m.WriteNameToHardware()
            cmb_MasterNames.Text = oldName
            cmb_MasterNames.Refresh()
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub CommSpeed_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_CommSpeed.TextChanged
        If Not EventsAreEnabled Then Return
        If SelectedLine < 0 Then Exit Sub
        Timer_10Hz.Stop()
        Dim m As Master = FindMasterByListLine(SelectedLine)
        If m IsNot Nothing Then
            m.SetSpeed(txt_CommSpeed.NumericValueInteger)
            txt_CommSpeed.Refresh()
            ChangedConfigParams = True
        End If
        Timer_10Hz.Start()
    End Sub

    Private Sub chk_FastDataExchange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_FastDataExchange.CheckedChanged
        If Not EventsAreEnabled Then Return
        If SelectedLine < 0 Then Exit Sub
        Dim m As Master = FindMasterByListLine(SelectedLine)
        If m IsNot Nothing Then
            m.FastComm = chk_FastDataExchange.Checked
            ChangedConfigParams = True
        End If
    End Sub

    Private Sub txt_MinChange_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_MinChange.TextChanged
        If Not EventsAreEnabled Then Return
        ChangedAppParams = True
    End Sub

    Private Sub txt_MinVariation_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_MinVariation.TextChanged
        If Not EventsAreEnabled Then Return
        If SelectedLine < 0 Then Exit Sub
        EnableCalibrateButton(TheSystem_CalibrationNeeded())
    End Sub

    Private Sub txt_CapArea_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_CapArea.TextChanged
        If Not EventsAreEnabled Then Return
        If SelectedLine < 0 Then Exit Sub
        EnableCalibrateButton(TheSystem_CalibrationNeeded())
    End Sub

    Private Sub PinProps_Changed(ByVal sender As System.Object,
                                 ByVal e As System.EventArgs) _
                                         Handles txt_Slot.TextChanged,
                                                 txt_MaxValue.TextChanged,
                                                 txt_MinValue.TextChanged,
                                                 txt_MaxSpeed.TextChanged,
                                                 txt_MaxAcc.TextChanged,
                                                 chk_LinkedToPrevious.CheckedChanged,
                                                 txt_StepsPerMillim.TextChanged,
                                                 txt_PwmFastFrequency.TextChanged,
                                                 txt_PwmFastDutyCycle.TextChanged,
                                                 Label_ResponseSpeed.CheckedChanged,
                                                 txt_ResponseSpeed.TextChanged,
                                                 txt_ServoMaxTime.TextChanged,
                                                 txt_ServoMinTime.TextChanged,
                                                 chk_LogResponse.CheckedChanged,
                                                 chk_RemoveErrors.CheckedChanged,
                                                 txt_CapMaxDist.TextChanged,
                                                 txt_CapMinDist.TextChanged,
                                                 txt_CapArea.TextChanged,
                                                 txt_MaxFreq.TextChanged,
                                                 txt_MinFreq.TextChanged,
                                                 txt_MinVariation.TextChanged,
                                                 txt_ProportionalArea.TextChanged,
                                                 txt_NumberOfPins.TextChanged,
                                                 chk_Adc24ChBiased.CheckedChanged
        If Not EventsAreEnabled Then Return
        If SelectedLine < 0 Then Exit Sub
        SetPinProps()
        ChangedConfigParams = True
    End Sub

    Private Sub SetPinProps()
        Select Case LineType(SelectedLine)
            Case "Pin", "Adc24"
                Dim p As Pin = FindPinByListLine(SelectedLine)
                Dim s As Slave = Masters(p.MasterId).Slaves(0)
                Dim n As Int32 = txt_Slot.NumericValueInteger
                Dim str As String
                With MyListView1.Items(SelectedLine)
                    If n <> p.Slot Then
                        p.Slot = n
                        str = p.Slot.ToString()
                        If str <> .SubItems(3).Text Then .SubItems(3).Text = str
                    End If
                    If p.GetPinType = Pin.PinTypes.UNUSED OrElse s.Pins.Count > 6 AndAlso
                         (s.Pins(6).GetPinType = Pin.PinTypes.ADC_24 And (p.PinId = 6 Or p.PinId = 7)) Then
                        str = ""
                    Else
                        str = SlotNames(p.Slot)
                    End If
                    If str <> .SubItems(5).Text Then .SubItems(5).Text = str
                End With
                '
                p.Value_Max = CSng(txt_MaxValue.NumericValue)
                p.Value_Min = CSng(txt_MinValue.NumericValue)
                p.AdaptiveSpeed = Label_ResponseSpeed.Checked
                p.ResponseSpeed = txt_ResponseSpeed.NumericValueInteger
                '
                Select Case p.GetPinType
                    Case Pin.PinTypes.PWM_8, Pin.PinTypes.PWM_16
                        p.MaxTime = CSng(txt_ServoMaxTime.NumericValue)
                        p.MinTime = CSng(txt_ServoMinTime.NumericValue)
                        p.LogResponse = chk_LogResponse.Checked
                    Case Pin.PinTypes.SERVO_8, Pin.PinTypes.SERVO_16
                        p.MaxTime = CSng(txt_ServoMaxTime.NumericValue)
                        p.MinTime = CSng(txt_ServoMinTime.NumericValue)
                    Case Pin.PinTypes.STEPPER
                        p.MaxSpeed = CSng(txt_MaxSpeed.NumericValue)
                        p.MaxAcc = CSng(txt_MaxAcc.NumericValue)
                        p.LinkedToPrevious = chk_LinkedToPrevious.Checked
                        p.StepsPerMillimeter = CSng(txt_StepsPerMillim.NumericValue)
                        ' ------------------------------------------------------------------
                        '  STEPPER PIN CONFIGURATION - BY ASYNChronous SendBytesToSlave
                        ' ------------------------------------------------------------------
                        p.SendStepperParamsToHardware()
                        ShowStepperErrors(p)
                        ' -----------------------------
                    Case Pin.PinTypes.PWM_FAST
                        p.PwmFastFrequency = CSng(txt_PwmFastFrequency.NumericValue)
                        p.PwmFastDutyCycle = CSng(txt_PwmFastDutyCycle.NumericValue)
                        p.FrequencyFromSlot = chk_FrequencyFromSlot.Checked
                        p.DutyCycleFromSlot = chk_DutyCycleFromSlot.Checked
                        ' ------------------------------------------------------------------
                    Case Pin.PinTypes.CAP_8, Pin.PinTypes.CAP_16
                        p.MinVariation = CSng(txt_MinVariation.NumericValue)
                        p.ProportionalArea = CSng(txt_ProportionalArea.NumericValue)
                    Case Pin.PinTypes.USOUND_SENSOR
                        p.MaxDist_mm = CSng(txt_CapMaxDist.NumericValue)
                        p.MinDist_mm = CSng(txt_CapMinDist.NumericValue)
                        p.RemoveErrors = chk_RemoveErrors.Checked
                    Case Pin.PinTypes.CAP_SENSOR
                        p.MaxDist_mm = CSng(txt_CapMaxDist.NumericValue)
                        p.MinDist_mm = CSng(txt_CapMinDist.NumericValue)
                        p.Area_cmq = CSng(txt_CapArea.NumericValue)
                        EnableDisableCapSensorProps(p)
                    Case Pin.PinTypes.COUNTER, Pin.PinTypes.COUNTER_PU,
                         Pin.PinTypes.FAST_COUNTER, Pin.PinTypes.FAST_COUNTER_PU,
                         Pin.PinTypes.PERIOD, Pin.PinTypes.PERIOD_PU,
                         Pin.PinTypes.SLOW_PERIOD, Pin.PinTypes.SLOW_PERIOD_PU
                        p.MaxFreq = CSng(txt_MaxFreq.NumericValue)
                        p.MinFreq = CSng(txt_MinFreq.NumericValue)
                        p.ConvertToFreq = chk_ConvertToFrequency.Checked
                    Case Pin.PinTypes.ADC_24
                        If p.Adc24Npins <> txt_NumberOfPins.NumericValueInteger Then
                            ' ---------------------------------- do not remove used Pins
                            If p.Adc24Npins > txt_NumberOfPins.NumericValueInteger Then
                                If Adc24_FindLastUsedPinIndex(p) >= txt_NumberOfPins.NumericValueInteger Then
                                    txt_NumberOfPins.NumericValueInteger = p.Adc24Npins
                                End If
                            End If
                            ' ---------------------------------- add remove Pins
                            p.Adc24Npins = txt_NumberOfPins.NumericValueInteger
                            Adc24_AddRemovePinsAndUpdateListView(p)
                        End If
                        p.Adc24Sps = CInt(Val(cmb_Adc24Sps.Text))
                        p.Adc24Filter = cmb_Adc24Filter.SelectedIndex
                    Case Pin.PinTypes.ADC_24_DIN,
                         Pin.PinTypes.ADC_24_DOUT
                        '
                    Case Pin.PinTypes.ADC_24_CH
                        p.Adc24ChBias = chk_Adc24ChBiased.Checked
                    Case Pin.PinTypes.ADC_24_CH_B
                        p.Adc24ChBias = chk_Adc24ChBiased.Checked
                        '
                    Case Pin.PinTypes.ENCODER_B, Pin.PinTypes.ENCODER_B_PU
                        '
                End Select
                'Dim s As Slave = Masters(p.MasterId).Slaves(0)
                If s.Pins.Count > 6 AndAlso s.Pins(6).GetPinType = Pin.PinTypes.ADC_24 Then
                    TryCast(s, Slave_MasterPinsV4).Adc24ConfigAndStart()
                End If
        End Select
        ' --------------------------------------------------------- show slot conflicts
        TestSlotConflicts()
    End Sub

    Friend Sub TestSlotConflicts()
        '
        If Not ConfigurationIsValid Then Return
        ' ------------------------------------------------------- remove old markers
        For ii As Int32 = 0 To MyListView1.Items.Count - 1
            Dim itm As ListViewItem = MyListView1.Items(ii)
            If itm.SubItems(5).Text = "SLOT CONFLICT" Then
                itm.SubItems(5).Text = SlotNames(FindPinByListLine(ii).Slot)
                ListView_SetLineColors(MyListView1, ii)
            End If
        Next
        ' ------------------------------------------------------- mark new conflicts
        Dim i As Int32 = 0
        Dim dic As Dictionary(Of Int32, Int32) = New Dictionary(Of Int32, Int32)
        For Each m As Master In Masters
            i += 1
            For Each s As Slave In m.Slaves
                i += 1
                For Each p As Pin In s.Pins
                    If p.Direction = Pin.Directions.MasterToHost Then
                        If dic.ContainsKey(p.Slot) Then
                            MarkSlotConflicts(i)
                            MarkSlotConflicts(dic(p.Slot))
                        End If
                        dic(p.Slot) = i
                    End If
                    i += 1
                Next
            Next
        Next
    End Sub

    Private Sub MarkSlotConflicts(ByVal LineNumber As Int32)
        With MyListView1.Items(LineNumber)
            .SubItems(5).Text = "SLOT CONFLICT"
            If .Selected Then
                .BackColor = Color.FromArgb(49, 106, 197)
                .ForeColor = Color.White
            Else
                .BackColor = Color.FromArgb(255, 150, 150)
                .ForeColor = Color.Black
            End If
        End With
    End Sub

    Friend Sub MarkAllLinesWithDuplicateName(ByVal m As Master)
        For i As Int32 = 0 To MyListView1.Items.Count - 1
            If FindMasterByListLine(i) Is m Then
                With MyListView1.Items(i)
                    .SubItems(5).Text = "Duplicate name"
                    .BackColor = Color.FromArgb(255, 150, 150)
                    .ForeColor = Color.Black
                End With
            End If
        Next
    End Sub


    Private Function Adc24_FindLastUsedPinIndex(ByVal p As Pin) As Int32
        Dim index As Int32 = 0
        Dim s As Slave
        s = TryCast(Masters(p.MasterId).Slaves(p.SlaveId), Slave_MasterPinsV4)
        For i As Int32 = 12 To s.Pins.Count - 1
            If s.Pins(i).GetPinType <> Pin.PinTypes.UNUSED Then
                index = i
            End If
        Next
        Return index - 12
    End Function

    Private Sub Adc24_AddRemovePinsAndUpdateListView(ByVal p As Pin)
        If p.SlaveId <> 0 Then Return ' only for virtual slave
        If Masters(p.MasterId).MasterFirmwareVersion < 50 Then Return
        If Masters(p.MasterId).Slaves(p.SlaveId).SlaveType <> Slave.SlaveTypes.MasterPinsV4 Then Return
        '
        TryCast(Masters(p.MasterId).Slaves(p.SlaveId), Slave_MasterPinsV4).Adc24_AddRemovePins()
        LockFormUpdate(Me)
        TheSystem_ListComponents()
        ListView_SetAllLineColors()
        If SelectedLine > MyListView1.Items.Count - 1 Then SelectedLine = -1
        UnlockFormUpdate()
    End Sub

    ' ====================================================================================================
    '   CONFIG PARAMS LOST FOCUS - SaveConfigDatabase 
    ' ====================================================================================================
    Private ChangedConfigParams As Boolean
    Private Sub ConfigParams_MouseLeave(ByVal sender As System.Object,
                                        ByVal e As System.EventArgs) _
                                        Handles _
                                        txt_CommSpeed.MouseLeave,
                                        chk_FastDataExchange.MouseLeave,
                                        txt_Slot.MouseLeave,
                                        txt_MaxValue.MouseLeave,
                                        txt_MinValue.MouseLeave,
                                        txt_MaxSpeed.MouseLeave,
                                        txt_MaxAcc.MouseLeave,
                                        chk_LinkedToPrevious.MouseLeave,
                                        txt_StepsPerMillim.MouseLeave,
                                        txt_PwmFastFrequency.MouseLeave,
                                        txt_PwmFastDutyCycle.MouseLeave,
                                        Label_ResponseSpeed.MouseLeave,
                                        txt_ResponseSpeed.MouseLeave,
                                        txt_CapMaxDist.MouseLeave,
                                        txt_CapMinDist.MouseLeave,
                                        txt_CapArea.MouseLeave,
                                        txt_ServoMaxTime.MouseLeave,
                                        txt_ServoMinTime.MouseLeave,
                                        chk_LogResponse.MouseLeave,
                                        chk_RemoveErrors.MouseLeave,
                                        txt_MaxFreq.MouseLeave,
                                        txt_MinFreq.MouseLeave,
                                        txt_MinVariation.MouseLeave,
                                        txt_ProportionalArea.MouseLeave,
                                        txt_NumberOfPins.MouseLeave,
                                        chk_Adc24ChBiased.MouseLeave
        If ChangedConfigParams Then
            ChangedConfigParams = False
            TheSystem_UpdateAndSaveConfigDatabase()
        End If
    End Sub

    Private ChangedAppParams As Boolean
    Private Sub txt_MinChange_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MinChange.MouseLeave
        If ChangedAppParams Then
            ChangedAppParams = False
            Save_INI()
        End If
    End Sub

    Private Sub Special_CheckBoxes_CheckedChanged(ByVal Sender As Object, ByVal e As System.EventArgs) Handles chk_ConvertToFrequency.CheckedChanged,
                                                                                                               chk_FrequencyFromSlot.CheckedChanged,
                                                                                                               chk_DutyCycleFromSlot.CheckedChanged
        If Not EventsAreEnabled Then Return
        If TryCast(Sender, CheckBox).Checked Then
            If Sender Is chk_FrequencyFromSlot Then chk_DutyCycleFromSlot.Checked = False
            If Sender Is chk_DutyCycleFromSlot Then chk_FrequencyFromSlot.Checked = False
        End If
        SetPinProps()
        TheSystem_UpdateAndSaveConfigDatabase()
        ShowProps()
    End Sub

    ' ====================================================================================================
    '   COMBO MASTER NAMES
    ' ====================================================================================================
    Private Sub cmb_MasterNames_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_MasterNames.DropDown
        Dim oldname As String = cmb_MasterNames.Items(0).ToString
        cmb_MasterNames.ItemHeight = 16
        cmb_MasterNames.Items.Clear()
        Load_ConfigDatabase()
        FillConfigNamesCombo(cmb_MasterNames)
        Combo_SetIndex_FromString(cmb_MasterNames, oldname)
    End Sub
    Private Sub cmb_MasterNames_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_MasterNames.DropDownClosed
        cmb_MasterNames.ItemHeight = 12
        Combo_Init(cmb_MasterNames, cmb_MasterNames.Text)
        MyListView1.Focus()
    End Sub
    Private Sub cmb_MasterNames_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_MasterNames.SelectionChangeCommitted
        Change_SelectedMaster_Name(cmb_MasterNames.Text)
    End Sub


    ' ====================================================================================================
    '   COMBO PIN TYPE
    ' ====================================================================================================
    Private Sub cmb_PinType_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_PinType.DropDown
        cmb_PinType.ItemHeight = 16
        Dim p As Pin = FindPinByListLine(SelectedLine)
        If p Is Nothing Then Return
        Masters(p.MasterId).Slaves(p.SlaveId).FillTypeCombo(cmb_PinType, p)
        Combo_SetIndex_FromString(cmb_PinType, Pin.PinTypeToString(p.GetPinType))
        LimitComboDropDownHeight(cmb_PinType)
    End Sub
    Private Sub cmb_PinType_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_PinType.DropDownClosed
        cmb_PinType.ItemHeight = 12
    End Sub
    Private Sub cmb_PinType_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_PinType.SelectionChangeCommitted
        Dim p As Pin = FindPinByListLine(SelectedLine)
        If p Is Nothing Then Return
        Dim s As Slave = Masters(p.MasterId).Slaves(p.SlaveId)

        ' -------------------------------------------------------------- critical section ? -----

        Dim str As String = cmb_PinType.Items(cmb_PinType.SelectedIndex).ToString
        If Masters(s.MasterId).MasterFirmwareVersion < 41 Then
            Select Case str
                Case "ADC_24", "ADC_24_DIN", "ADC_24_DOUT", "ADC_24_CH"
                    str = "UNUSED"
            End Select
        End If
        If Masters(s.MasterId).MasterFirmwareVersion < 40 Then
            Select Case str
                Case "ENCODER_A", "ENCODER_A_PU", "ENCODER_B", "ENCODER_B_PU"
                    str = "UNUSED"
            End Select
        End If
        p.SetPinType(Pin.StringToPinType(str))

        ' --------------------------------------------------------------
        If p.GetPinType = Pin.PinTypes.STEPPER Then
            Dim p2 As Pin
            p2 = s.Pins(p.PinId + 1)
            p2.SetPinType(Pin.PinTypes.STEPPER_DIR)
            SetListViewLineFields(MyListView1.Items(SelectedLine + 1), p2)
            If p.PinId < s.Pins.Count - 2 Then
                Dim p3 As Pin
                p3 = s.Pins(p.PinId + 2)
                If p3.GetPinType = Pin.PinTypes.ENCODER_B OrElse p3.GetPinType = Pin.PinTypes.ENCODER_B_PU Then
                    p3.SetPinType(Pin.PinTypes.UNUSED)
                End If
                SetListViewLineFields(MyListView1.Items(SelectedLine + 2), p3)
            End If
        End If

        If p.GetPinType <> Pin.PinTypes.STEPPER Then
            If p.PinId < s.Pins.Count - 1 Then
                Dim p2 As Pin
                p2 = s.Pins(p.PinId + 1)
                If p2.GetPinType = Pin.PinTypes.STEPPER_DIR Then
                    p2.SetPinType(Pin.PinTypes.UNUSED)
                End If
                SetListViewLineFields(MyListView1.Items(SelectedLine + 1), p2)
            End If
        End If

        ' --------------------------------------------------------------
        If p.GetPinType = Pin.PinTypes.ENCODER_A Or
           p.GetPinType = Pin.PinTypes.ENCODER_A_PU Then
            Dim p2 As Pin
            p2 = s.Pins(p.PinId + 1)
            If p.GetPinType = Pin.PinTypes.ENCODER_A Then
                p2.SetPinType(Pin.PinTypes.ENCODER_B)
            Else
                p2.SetPinType(Pin.PinTypes.ENCODER_B_PU)
            End If
            SetListViewLineFields(MyListView1.Items(SelectedLine + 1), p2)
        End If

        If p.GetPinType <> Pin.PinTypes.ENCODER_A And
           p.GetPinType <> Pin.PinTypes.ENCODER_A_PU Then
            If p.PinId < s.Pins.Count - 1 Then
                Dim p2 As Pin
                p2 = s.Pins(p.PinId + 1)
                If p2.GetPinType = Pin.PinTypes.ENCODER_B Or
                   p2.GetPinType = Pin.PinTypes.ENCODER_B_PU Then
                    p2.SetPinType(Pin.PinTypes.UNUSED)
                End If
                SetListViewLineFields(MyListView1.Items(SelectedLine + 1), p2)
            End If
        End If

        ' --------------------------------------------------------------
        If p.GetPinType = Pin.PinTypes.ADC_24 Then
            Dim p2 As Pin
            p2 = s.Pins(p.PinId + 1)
            p2.SetPinType(Pin.PinTypes.ADC_24_DIN)
            SetListViewLineFields(MyListView1.Items(SelectedLine + 1), p2)
            Dim p3 As Pin
            p3 = s.Pins(p.PinId + 2)
            p3.SetPinType(Pin.PinTypes.ADC_24_DOUT)
            SetListViewLineFields(MyListView1.Items(SelectedLine + 2), p3)
            Dim p4 As Pin
            p4 = s.Pins(p.PinId + 3)
            Select Case p4.GetPinType
                Case Pin.PinTypes.ENCODER_B, Pin.PinTypes.ENCODER_B_PU, Pin.PinTypes.STEPPER_DIR
                    p4.SetPinType(Pin.PinTypes.UNUSED)
                    SetListViewLineFields(MyListView1.Items(SelectedLine + 3), p4)
            End Select
            Adc24_AddRemovePinsAndUpdateListView(p)
        End If

        If p.PinId = 6 AndAlso p.GetPinType <> Pin.PinTypes.ADC_24 Then
            Dim p2 As Pin
            p2 = s.Pins(p.PinId + 1)
            If p2.GetPinType = Pin.PinTypes.ADC_24_DIN Then
                p2.SetPinType(Pin.PinTypes.UNUSED)
                SetListViewLineFields(MyListView1.Items(SelectedLine + 1), p2)
            End If
            Dim p3 As Pin
            p3 = s.Pins(p.PinId + 2)
            If p3.GetPinType = Pin.PinTypes.ADC_24_DOUT Then
                p3.SetPinType(Pin.PinTypes.UNUSED)
                SetListViewLineFields(MyListView1.Items(SelectedLine + 2), p3)
            End If
            Adc24_AddRemovePinsAndUpdateListView(p)
        End If

        Adc24_AlignCoupledPinParams(p)
        Adc24_TestSteppers(s)

        Masters(p.MasterId).SetupSlavePins(p.SlaveId)
        ' ---------------------------------------------------------------------------------------

        ' -------------------------------------------------------------------------- 
        Combo_Init(cmb_PinType, Pin.PinTypeToString(p.GetPinType))
        ' -------------------------------------------------------------------------- set PinType and Direction
        TheSystem_UpdateListedSubtypes()

        SetListViewLineFields(MyListView1.Items(SelectedLine), p)

        ' -------------------------------------------------------------------------- set Color
        ListView_SetAllLineColors()
        ' -------------------------------------------------------------------------- set pin props
        ShowProps()
        SetPinProps()
        TheSystem_UpdateAndSaveConfigDatabase()
        ' -------------------------------------------------------------------------- 
        EnableCalibrateButton(TheSystem_CalibrationNeeded())
        If btn_Calibrate.Enabled Then
            Select Case p.GetPinType
                Case Pin.PinTypes.CAP_SENSOR, Pin.PinTypes.CAP_8, Pin.PinTypes.CAP_16
                    DoCalibrationAndResetTime()
            End Select
        End If
    End Sub

    Private Sub SetListViewLineFields(ByVal l As ListViewItem, ByVal p As Pin)
        If SelectedLine < 0 Then Return
        With l
            .SubItems(2).Text = Pin.PinTypeToString(p.GetPinType)
            .SubItems(3).Text = If(p.Direction = Pin.Directions.Unused, "", p.Slot.ToString())
            .SubItems(4).Text = ""
        End With
    End Sub

    Private Sub Adc24_TestSteppers(ByVal s As Slave)
        If s.Pins.Count < 12 Then Return
        If s.Pins(6).GetPinType = Pin.PinTypes.ADC_24 Then
            For Each p As Pin In s.Pins
                If p.GetPinType = Pin.PinTypes.STEPPER Then
                    MessageBox.Show(Msg_Warning + vbCrLf + vbCrLf +
                                    Msg_StepperWithAdc24,
                                    Msg_HalMessage,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning)
                    Return
                End If
            Next
        End If
    End Sub

    ' ====================================================================================================
    '   COMBO Adc24Sps
    ' ====================================================================================================
    Private Sub cmb_Adc24Sps_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Adc24Sps.DropDown
        cmb_Adc24Sps.ItemHeight = 16
    End Sub
    Private Sub cmb_Adc24Sps_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Adc24Sps.DropDownClosed
        cmb_Adc24Sps.ItemHeight = 12
    End Sub
    Private Sub cmb_Adc24Sps_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Adc24Sps.SelectionChangeCommitted
        Dim p As Pin = FindPinByListLine(SelectedLine)
        If p Is Nothing Then Return
        p.Adc24Sps = CInt(Val(cmb_Adc24Sps.Text))
        SetPinProps()
        TheSystem_UpdateAndSaveConfigDatabase()
    End Sub

    ' ====================================================================================================
    '   COMBO Adc24Filter
    ' ====================================================================================================
    Private Sub cmb_Adc24Filter_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Adc24Filter.DropDown
        cmb_Adc24Filter.ItemHeight = 16
    End Sub
    Private Sub cmb_Adc24Filter_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Adc24Filter.DropDownClosed
        cmb_Adc24Filter.ItemHeight = 12
    End Sub
    Private Sub cmb_Adc24Filter_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Adc24Filter.SelectionChangeCommitted
        Dim p As Pin = FindPinByListLine(SelectedLine)
        If p Is Nothing Then Return
        p.Adc24Filter = cmb_Adc24Filter.SelectedIndex
        SetPinProps()
        TheSystem_UpdateAndSaveConfigDatabase()
    End Sub

    ' ====================================================================================================
    '   COMBO Adc24ChType
    ' ====================================================================================================
    Private Sub cmb_Adc24ChType_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Adc24ChType.DropDown
        cmb_Adc24ChType.ItemHeight = 16
    End Sub
    Private Sub cmb_Adc24ChType_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Adc24ChType.DropDownClosed
        cmb_Adc24ChType.ItemHeight = 12
    End Sub
    Private Sub cmb_Adc24ChType_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Adc24ChType.SelectionChangeCommitted
        Dim p As Pin = FindPinByListLine(SelectedLine)
        If p Is Nothing Then Return
        p.Adc24ChType = cmb_Adc24ChType.SelectedIndex
        Adc24_AlignCoupledPinParams(p)
        Masters(p.MasterId).SetupSlavePins(p.SlaveId)
        ShowProps()
        SetPinProps()
        TheSystem_UpdateAndSaveConfigDatabase()
    End Sub

    ' ====================================================================================================
    '   COMBO Adc24ChGain
    ' ====================================================================================================
    Private Sub cmb_Adc24ChGain_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Adc24ChGain.DropDown
        cmb_Adc24ChGain.ItemHeight = 16
    End Sub
    Private Sub cmb_Adc24ChGain_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Adc24ChGain.DropDownClosed
        cmb_Adc24ChGain.ItemHeight = 12
    End Sub
    Private Sub cmb_Adc24ChGain_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_Adc24ChGain.SelectionChangeCommitted
        Dim p As Pin = FindPinByListLine(SelectedLine)
        If p Is Nothing Then Return
        p.Adc24ChGain = cmb_Adc24ChGain.SelectedIndex
        Adc24_AlignCoupledPinParams(p)
        SetPinProps()
        TheSystem_UpdateAndSaveConfigDatabase()
    End Sub

    ' ====================================================================================================
    '   Adc24_AlignCoupledPinParams
    ' ====================================================================================================
    Private Sub Adc24_AlignCoupledPinParams(ByVal p As Pin)

        If p.PinId < 12 Then Return
        Dim s As Slave = Masters(p.MasterId).Slaves(p.SlaveId)

        ' ----------------------------------------------------- return if not coupled 
        If p.PinId Mod 2 = 0 Then
            If p.PinId >= s.Pins.Count - 1 Then Return
        End If

        ' ----------------------------------------------------- set CH and CH_B to coupled pin
        If p.PinId Mod 2 = 0 Then
            Dim p2 As Pin = s.Pins(p.PinId + 1)
            If p.Adc24ChType = 0 Then ' if differential
                If p2.GetPinType = Pin.PinTypes.ADC_24_CH Then
                    p2.SetPinType(Pin.PinTypes.ADC_24_CH_B)
                    SetListViewLineFields(MyListView1.Items(SelectedLine + 1), p2)
                End If
            Else
                If p2.GetPinType = Pin.PinTypes.ADC_24_CH_B Then
                    p2.SetPinType(Pin.PinTypes.ADC_24_CH)
                    SetListViewLineFields(MyListView1.Items(SelectedLine + 1), p2)
                End If
            End If
        End If

        ' ----------------------------------------------------- set CH and CH_B to selected pin
        If p.PinId Mod 2 = 1 Then
            If p.Adc24ChType = 0 Then ' if differential
                If p.GetPinType = Pin.PinTypes.ADC_24_CH Then
                    s.Pins(p.PinId).SetPinType(Pin.PinTypes.ADC_24_CH_B)
                    SetListViewLineFields(MyListView1.Items(SelectedLine), p)
                End If
            Else
                If p.GetPinType = Pin.PinTypes.ADC_24_CH_B Then
                    ' ------------------------------------- save and restore old values
                    Dim oldChType As Int32 = p.Adc24ChType
                    Dim oldChGain As Int32 = p.Adc24ChGain
                    s.Pins(p.PinId).SetPinType(Pin.PinTypes.ADC_24_CH)
                    p.Adc24ChType = oldChType
                    p.Adc24ChGain = oldChGain
                    SetListViewLineFields(MyListView1.Items(SelectedLine), p)
                End If
            End If
        End If

        ' ----------------------------------------------------- copy to coupled pin
        If p.PinId Mod 2 = 0 Then
            If p.PinId + 1 < s.Pins.Count Then
                s.Pins(p.PinId + 1).Adc24ChType = p.Adc24ChType
                s.Pins(p.PinId + 1).Adc24ChGain = p.Adc24ChGain
            End If
        Else
            s.Pins(p.PinId - 1).Adc24ChType = p.Adc24ChType
            s.Pins(p.PinId - 1).Adc24ChGain = p.Adc24ChGain
        End If

    End Sub


    ' ===========================================================================================================
    '   SHOW PROPS
    ' ===========================================================================================================
    Friend Sub ListView_SetAllLineColors()
        ' -------------------------------------------------------------------- select the listview "SelectedLine"
        If SelectedLine >= 0 And SelectedLine < MyListView1.Items.Count Then
            MyListView1.Items(SelectedLine).Selected = True
        End If
        ' -------------------------------------------------------------------- show listview colors
        For i As Int32 = 0 To MyListView1.Items.Count - 1
            ListView_SetLineColors(MyListView1, i)
        Next
    End Sub


    Private Sub ListView_SetLineColors(ByVal lv As ListView, ByVal line As Int32)
        If line < 0 Or line >= lv.Items.Count Then Return
        '
        Dim fc As Color
        Dim bc As Color
        If lv.Items(line).Selected Then
            ' ----------------------------------------------------------------- selected colors
            bc = Color.FromArgb(49, 106, 197)
            fc = Color.White
        Else
            ' ----------------------------------------------------------------- deselected colors
            If line >= 0 Then
                Select Case LineType(line)
                    Case "Master" : bc = Color.FromArgb(180, 205, 255) '(190, 215, 255)
                    Case "Slave" : bc = Color.FromArgb(255, 200, 160) '(245, 215, 185) '(255, 230, 200)
                    Case "Pin"
                        If LineSubType(line) <> "Unused" Then
                            If FindPinByListLine(line).Direction = Pin.Directions.HostToMaster Then
                                bc = Color.FromArgb(245, 245, 215) '(255, 255, 225)
                            Else
                                bc = Color.FromArgb(225, 245, 230) '(235, 255, 240)
                            End If
                        Else
                            bc = Color.FromArgb(255, 255, 255)
                        End If
                    Case "Adc24"
                        If LineSubType(line) <> "Unused" Then
                            bc = Color.FromArgb(200, 235, 180)
                        Else
                            bc = Color.FromArgb(255, 255, 255)
                        End If
                End Select
                fc = Color.Black
            End If
        End If
        lv.Items(line).ForeColor = fc
        lv.Items(line).BackColor = bc
    End Sub

    Private Function LineType(ByVal line As Int32) As String
        If line < 0 Then Return ""
        If line > MyListView1.Items.Count - 1 Then Return ""
        Return MyListView1.Items(line).SubItems(0).Text.Trim
    End Function
    Private Function LineSubType(ByVal line As Int32) As String
        Return MyListView1.Items(line).SubItems(2).Text.Trim
    End Function

    Friend SelectedLine As Int32 = -1
    Private Sub MyListView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyListView1.SelectedIndexChanged
        If Not EventsAreEnabled Then Return
        LockFormUpdate(Me)
        SyncLock EventsLock
            ' --------------------------------------------------------- change line colors and update "SelectedLine"
            If MyListView1.SelectedIndices.Count > 0 Then
                SelectedLine = MyListView1.SelectedIndices(0)
                If ConfigurationIsValid Then ListView_SetLineColors(MyListView1, SelectedLine)
            Else
                If ConfigurationIsValid Then ListView_SetLineColors(MyListView1, SelectedLine)
                SelectedLine = -1
            End If
            ' --------------------------------------------------------- show line props
            ShowProps()
            ' --------------------------------------------------------- show slot conflicts
            TestSlotConflicts()
        End SyncLock
        UnlockFormUpdate()
        If SelectedLine >= 0 Then Refresh()
    End Sub

    Private Sub ShowProps()
        '
        EventsAreEnabled = False
        '
        GroupBox_PinProps.Visible = False
        GroupBox_TouchProps.Visible = False
        GroupBox_CapSensorProps.Visible = False
        GroupBox_ServoPwmProps.Visible = False
        GroupBox_StepperProps.Visible = False
        GroupBox_PwmFastProps.Visible = False
        GroupBox_FrequencyProps.Visible = False
        GroupBox_Adc24Props.Visible = False
        GroupBox_Adc24ChProps.Visible = False
        '
        If SelectedLine < 0 Or SelectedLine > MyListView1.Items.Count - 1 Then
            GroupBox_MasterProps.Enabled = False
            txt_CommSpeed.Text = "-"
        Else
            GroupBox_MasterProps.Enabled = True
            '
            Dim m As Master = FindMasterByListLine(SelectedLine)
            Dim p As Pin = FindPinByListLine(SelectedLine)
            '
            If Not ConfigurationIsValid Then
                GroupBox_MasterProps.Height = cmb_MasterNames.Bottom + 6
                If m IsNot Nothing Then
                    Combo_Init(cmb_MasterNames, m.GetName)
                Else
                    Combo_Init(cmb_MasterNames, "")
                    GroupBox_MasterProps.Enabled = False
                    txt_CommSpeed.Text = "-"
                End If
            Else
                GroupBox_MasterProps.Height = chk_FastDataExchange.Bottom + 6 '130
                '
                Select Case LineType(SelectedLine)
                    Case "Master"
                        GroupBox_PinProps.Visible = False
                        GroupBox_CapSensorProps.Visible = False
                        GroupBox_ServoPwmProps.Visible = False
                    Case "Slave"
                        GroupBox_PinProps.Visible = False
                        GroupBox_CapSensorProps.Visible = False
                        GroupBox_ServoPwmProps.Visible = False
                    Case "Pin", "Adc24"
                        GroupBox_PinProps.Visible = True
                        GroupBox_PinProps.Left = GroupBox_MasterProps.Left
                        GroupBox_PinProps.Height = txt_ResponseSpeed.Bottom + 8
                End Select
                '
                If m IsNot Nothing Then
                    Combo_Init(cmb_MasterNames, m.GetName)
                    txt_CommSpeed.NumericValueInteger = m.CommSpeed
                    chk_FastDataExchange.Checked = m.FastComm
                    '
                    If m.HasPhysicalSlaves Then
                        chk_FastDataExchange.Enabled = True
                    Else
                        chk_FastDataExchange.Enabled = False
                    End If
                    ToolTips_Init()
                    '
                    If p IsNot Nothing Then
                        Label_MaxValue.Text = Msg_MaxValue
                        Label_MinValue.Text = Msg_MinValue
                        Combo_Init(cmb_PinType, Pin.PinTypeToString(p.GetPinType))
                        txt_Slot.NumericValue = p.Slot
                        txt_MaxValue.NumericValue = p.Value_Max
                        txt_MinValue.NumericValue = p.Value_Min
                        Label_ResponseSpeed.Checked = p.AdaptiveSpeed
                        txt_ResponseSpeed.NumericValueInteger = p.ResponseSpeed
                        txt_MaxValue.Visible = True
                        Select Case p.GetPinType
                            Case Pin.PinTypes.UNUSED
                                GroupBox_PinProps.Height = cmb_PinType.Bottom + 8
                                ' ------------------------------------------------------------------ OUT
                            Case Pin.PinTypes.PWM_8, Pin.PinTypes.PWM_16
                                GroupBox_ServoPwmProps.Text = Msg_PwmProps
                                txt_ServoMaxTime.NumericValue = p.MaxTime
                                txt_ServoMinTime.NumericValue = p.MinTime
                                chk_LogResponse.Checked = p.LogResponse
                                GroupBox_ServoPwmProps.Left = GroupBox_PinProps.Left
                                GroupBox_ServoPwmProps.Top = GroupBox_PinProps.Bottom + 6
                                GroupBox_ServoPwmProps.Height = chk_LogResponse.Bottom + 7
                                GroupBox_ServoPwmProps.Visible = True
                            Case Pin.PinTypes.SERVO_8, Pin.PinTypes.SERVO_16
                                GroupBox_ServoPwmProps.Text = Msg_ServoProps
                                txt_ServoMaxTime.NumericValue = p.MaxTime
                                txt_ServoMinTime.NumericValue = p.MinTime
                                GroupBox_ServoPwmProps.Left = GroupBox_PinProps.Left
                                GroupBox_ServoPwmProps.Top = GroupBox_PinProps.Bottom + 6
                                GroupBox_ServoPwmProps.Height = txt_ServoMinTime.Bottom + 8
                                GroupBox_ServoPwmProps.Visible = True
                            Case Pin.PinTypes.STEPPER
                                Label_MaxValue.Text = Msg_MaxValueStepper
                                Label_MinValue.Text = Msg_MinValueStepper
                                txt_MaxSpeed.NumericValue = p.MaxSpeed
                                txt_MaxAcc.NumericValue = p.MaxAcc
                                If m.Slaves(p.SlaveId).ValidLinkedToPrevious(p) Then
                                    chk_LinkedToPrevious.Checked = p.LinkedToPrevious
                                    chk_LinkedToPrevious.Enabled = True
                                Else
                                    chk_LinkedToPrevious.Checked = False
                                    chk_LinkedToPrevious.Enabled = False
                                End If
                                txt_StepsPerMillim.NumericValue = p.StepsPerMillimeter
                                GroupBox_StepperProps.Left = GroupBox_PinProps.Left
                                GroupBox_StepperProps.Top = GroupBox_PinProps.Bottom + 6
                                GroupBox_StepperProps.Height = chk_LinkedToPrevious.Bottom + 8
                                GroupBox_StepperProps.Visible = True
                                ShowStepperErrors(p)
                            Case Pin.PinTypes.PWM_FAST
                                txt_PwmFastFrequency.NumericValue = p.PwmFastFrequency
                                txt_PwmFastDutyCycle.NumericValue = p.PwmFastDutyCycle
                                chk_FrequencyFromSlot.Checked = p.FrequencyFromSlot
                                chk_DutyCycleFromSlot.Checked = p.DutyCycleFromSlot
                                If chk_FrequencyFromSlot.Checked Then
                                    txt_PwmFastFrequency.Enabled = False
                                    Label_PwmFastFrequency.Enabled = False
                                Else
                                    txt_PwmFastFrequency.Enabled = True
                                    Label_PwmFastFrequency.Enabled = True
                                End If
                                If chk_DutyCycleFromSlot.Checked Then
                                    txt_PwmFastDutyCycle.Enabled = False
                                    Label_PwmFastDutyCycle.Enabled = False
                                Else
                                    txt_PwmFastDutyCycle.Enabled = True
                                    Label_PwmFastDutyCycle.Enabled = True
                                End If
                                GroupBox_PwmFastProps.Left = GroupBox_PinProps.Left
                                GroupBox_PwmFastProps.Top = GroupBox_PinProps.Bottom + 6
                                GroupBox_PwmFastProps.Height = chk_LinkedToPrevious.Bottom + 8
                                GroupBox_PwmFastProps.Visible = True
                                ' ------------------------------------------------------------------ IN
                            Case Pin.PinTypes.CAP_8, Pin.PinTypes.CAP_16
                                txt_MinVariation.NumericValue = p.MinVariation
                                txt_ProportionalArea.NumericValue = p.ProportionalArea
                                GroupBox_TouchProps.Left = GroupBox_PinProps.Left
                                GroupBox_TouchProps.Top = GroupBox_PinProps.Bottom + 6
                                GroupBox_TouchProps.Visible = True
                            Case Pin.PinTypes.USOUND_SENSOR
                                GroupBox_CapSensorProps.Text = Msg_UsoundProps
                                txt_CapMaxDist.NumericValue = p.MaxDist_mm
                                txt_CapMinDist.NumericValue = p.MinDist_mm
                                GroupBox_CapSensorProps.Left = GroupBox_PinProps.Left
                                GroupBox_CapSensorProps.Top = GroupBox_PinProps.Bottom + 6
                                chk_RemoveErrors.Location = Label_Area.Location
                                chk_RemoveErrors.Visible = True
                                chk_RemoveErrors.Checked = p.RemoveErrors
                                Label_Area.Visible = False
                                txt_CapArea.Visible = False
                                GroupBox_CapSensorProps.Height = txt_CapArea.Bottom + 8
                                GroupBox_CapSensorProps.Visible = True
                            Case Pin.PinTypes.CAP_SENSOR
                                GroupBox_CapSensorProps.Text = Msg_CapSensorProps
                                txt_CapMaxDist.NumericValue = p.MaxDist_mm
                                txt_CapMinDist.NumericValue = p.MinDist_mm
                                GroupBox_CapSensorProps.Left = GroupBox_PinProps.Left
                                GroupBox_CapSensorProps.Top = GroupBox_PinProps.Bottom + 6
                                txt_CapArea.NumericValue = p.Area_cmq
                                chk_RemoveErrors.Visible = False
                                Label_Area.Visible = True
                                txt_CapArea.Visible = True
                                GroupBox_CapSensorProps.Height = txt_CapArea.Bottom + 8
                                GroupBox_CapSensorProps.Visible = True
                                EnableDisableCapSensorProps(p)
                            Case Pin.PinTypes.COUNTER, Pin.PinTypes.COUNTER_PU,
                                 Pin.PinTypes.FAST_COUNTER, Pin.PinTypes.FAST_COUNTER_PU,
                                 Pin.PinTypes.PERIOD, Pin.PinTypes.PERIOD_PU,
                                 Pin.PinTypes.SLOW_PERIOD, Pin.PinTypes.SLOW_PERIOD_PU
                                chk_ConvertToFrequency.Checked = p.ConvertToFreq
                                txt_MaxFreq.NumericValue = p.MaxFreq
                                txt_MinFreq.NumericValue = p.MinFreq
                                If chk_ConvertToFrequency.Checked Then
                                    GroupBox_PinProps.Height = txt_ResponseSpeed.Bottom + 10
                                    GroupBox_FrequencyProps.Height = txt_MinFreq.Bottom + 8
                                Else
                                    GroupBox_PinProps.Height = txt_Slot.Bottom + 7
                                    GroupBox_FrequencyProps.Height = chk_ConvertToFrequency.Bottom + 10
                                End If
                                GroupBox_FrequencyProps.Left = GroupBox_PinProps.Left
                                GroupBox_FrequencyProps.Top = GroupBox_PinProps.Bottom + 6
                                GroupBox_FrequencyProps.Visible = True
                            Case Pin.PinTypes.STEPPER_DIR
                                GroupBox_PinProps.Height = txt_Slot.Bottom + 7
                                txt_MaxValue.Visible = False
                            Case Pin.PinTypes.ADC_24
                                GroupBox_PinProps.Height = cmb_PinType.Bottom + 8
                                txt_NumberOfPins.NumericValueInteger = p.Adc24Npins
                                Combo_SetIndex_FromString(cmb_Adc24Sps, p.Adc24Sps.ToString)
                                If cmb_Adc24Sps.Text = "" Then cmb_Adc24Sps.SelectedIndex = 0
                                Combo_SetIndex(cmb_Adc24Filter, p.Adc24Filter)
                                GroupBox_Adc24Props.Left = GroupBox_PinProps.Left
                                GroupBox_Adc24Props.Top = GroupBox_PinProps.Bottom + 6
                                GroupBox_Adc24Props.Height = cmb_Adc24Filter.Bottom + 7
                                GroupBox_Adc24Props.Visible = True
                            Case Pin.PinTypes.ADC_24_DIN
                                GroupBox_PinProps.Height = cmb_PinType.Bottom + 8
                            Case Pin.PinTypes.ADC_24_DOUT
                                GroupBox_PinProps.Height = txt_Slot.Bottom + 7
                                txt_MaxValue.Visible = False
                            Case Pin.PinTypes.ADC_24_CH
                                Combo_SetIndex(cmb_Adc24ChType, p.Adc24ChType)
                                Combo_SetIndex(cmb_Adc24ChGain, p.Adc24ChGain)
                                chk_Adc24ChBiased.Checked = p.Adc24ChBias
                                GroupBox_Adc24ChProps.Left = GroupBox_PinProps.Left
                                GroupBox_Adc24ChProps.Top = GroupBox_PinProps.Bottom + 6
                                GroupBox_Adc24ChProps.Height = chk_Adc24ChBiased.Bottom + 7
                                GroupBox_Adc24ChProps.Visible = True
                            Case Pin.PinTypes.ADC_24_CH_B
                                GroupBox_PinProps.Height = cmb_PinType.Bottom + 8
                                Combo_SetIndex(cmb_Adc24ChType, p.Adc24ChType)
                                Combo_SetIndex(cmb_Adc24ChGain, p.Adc24ChGain)
                                chk_Adc24ChBiased.Checked = p.Adc24ChBias
                                GroupBox_Adc24ChProps.Left = GroupBox_PinProps.Left
                                GroupBox_Adc24ChProps.Top = GroupBox_PinProps.Bottom + 6
                                GroupBox_Adc24ChProps.Height = chk_Adc24ChBiased.Bottom + 7
                                GroupBox_Adc24ChProps.Visible = True
                            Case Pin.PinTypes.ENCODER_B, Pin.PinTypes.ENCODER_B_PU
                                GroupBox_PinProps.Height = cmb_PinType.Bottom + 8
                        End Select
                    End If
                End If
            End If
        End If
        '
        EventsAreEnabled = True
    End Sub

    Private Sub ShowStepperErrors(ByVal p As Pin)
        If p.MaxSpeed * p.StepsPerMillimeter / 60.0F > 65500 Then
            Label_MaxSpeed.BackColor = Color.Yellow
            Label_StepsPerMillim.BackColor = Color.Yellow
            Label_MaxSpeed.ForeColor = Color.Red
            Label_StepsPerMillim.ForeColor = Color.Red
        Else
            Label_MaxSpeed.BackColor = Label_MaxAcc.BackColor
            Label_StepsPerMillim.BackColor = Label_MaxAcc.BackColor
            Label_MaxSpeed.ForeColor = Label_MaxAcc.ForeColor
            Label_StepsPerMillim.ForeColor = Label_MaxAcc.ForeColor
        End If
    End Sub

    Private Sub EnableDisableCapSensorProps(ByVal p As Pin)
        If p.Area_cmq > 0 Then
            Label_MaxDist.Enabled = True
            Label_MinDist.Enabled = True
            txt_CapMaxDist.Enabled = True
            txt_CapMinDist.Enabled = True
        Else
            Label_MaxDist.Enabled = False
            Label_MinDist.Enabled = False
            txt_CapMaxDist.Enabled = False
            txt_CapMinDist.Enabled = False
        End If
    End Sub



    ' ==============================================================================================================
    '  AUTO CALIBRATION
    ' ==============================================================================================================
    Private Sub Timer_1Hz_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer_1Hz.Tick
        If Not EventsAreEnabled Then Return
        If btn_Calibrate.Enabled Then
            If txt_MinChange.NumericValueInteger > 0 Then
                TestDeltaToRestartCalibrationTime()
                TestCalibrationTime()
            Else
                CalibrationTime = 0
            End If
            ShowCalibrationRedLine()
        End If
    End Sub


    ' ==============================================================================================================
    '   AUTO CALIBRATION
    ' ==============================================================================================================
    Private CalibrationTime As Double

    Private Sub TestDeltaToRestartCalibrationTime()
        For Each m As Master In Masters
            For i As Int32 = 0 To m.SlaveCount - 1
                Dim rd As UInt32 = m.Slaves(i).Get_CapSensor_Or_Cap_Delta
                If rd > txt_MinChange.NumericValueInteger Then
                    CalibrationTime = 0
                    ShowCalibrationRedLine()
                End If
            Next
        Next
    End Sub

    Private Sub TestCalibrationTime()
        If Not EventsAreEnabled Then Return
        CalibrationTime += 0.033
        If CalibrationTime > 0.99 Then
            DoCalibrationAndResetTime()
        End If
    End Sub

    Private Sub DoCalibrationAndResetTime()
        CalibrationTime = 0
        btn_Calibrate.Checked = True
        btn_Calibrate.Refresh()
        TheSystem_Calibrate()
        System.Threading.Thread.Sleep(100)
        btn_Calibrate.Checked = False
    End Sub

    Private Sub ShowCalibrationRedLine()
        FillPictureBox_Horizontal(Pic_CalibrateTime, CalibrationTime, Color.FromArgb(255, 120, 0), Color.LightGray)
    End Sub

    Friend Sub EnableCalibrateButton(ByVal enable As Boolean)
        If enable Then
            CalibrationTime = 0.6 ' start with 10 seconds delay
        Else
            CalibrationTime = 0
        End If
        ShowCalibrationRedLine()
        btn_Calibrate.Enabled = enable
        txt_MinChange.Enabled = enable
    End Sub


    ' ==============================================================================================================
    '   ToolTips
    ' ==============================================================================================================
    Private WithEvents ttp1 As ToolTip = New ToolTip
    Private Sub ToolTips_Init()
        ttp1.ShowAlways = True
        ttp1.UseAnimation = True
        ttp1.UseFading = True
        ttp1.IsBalloon = True
        ttp1.AutoPopDelay = 32700
        ttp1.InitialDelay = 500
        ttp1.ReshowDelay = 500
        ' --------------------------------------------------------------- Add here Controls and ToolTip-Text
        Dim m As Master = FindMasterByListLine(SelectedLine)
        If m IsNot Nothing Then
            If m.HasPhysicalSlaves Then
                ttp1.SetToolTip(txt_CommSpeed,
                     Msg_CommSpeed1 & vbCrLf &
                     "- - - - - - - - - - - - - - -" & vbCrLf &
                     "  1  =     1  Kilo-Baud" & vbCrLf &
                     "  2  =     2  Kilo-Baud" & vbCrLf &
                     "  3  =     5  Kilo-Baud" & vbCrLf &
                     "  4  =   10  Kilo-Baud" & vbCrLf &
                     "  5  =   20  Kilo-Baud" & vbCrLf &
                     "  6  =   50  Kilo-Baud" & vbCrLf &
                     "  7  = 100  Kilo-Baud" & vbCrLf &
                     "  8  = 200  Kilo-Baud" & vbCrLf &
                     "  9  = 500  Kilo-Baud" & vbCrLf &
                     "10  =  1  Mega-Baud" & vbCrLf &
                     "11  =  2  Mega-Baud" & vbCrLf &
                     "12  =  4  Mega-Baud")
            Else
                ttp1.SetToolTip(txt_CommSpeed,
                     Msg_CommSpeed1 & vbCrLf &
                     "- - - - - - - - - - - - - - -" & vbCrLf &
                     "  1  =  10 fps" & vbCrLf &
                     "  2  =  20 fps" & vbCrLf &
                     "  3  =  30 fps" & vbCrLf &
                     "  4  =  50 fps" & vbCrLf &
                     "  5  =  60 fps" & vbCrLf &
                     "  6  = 100 fps" & vbCrLf &
                     "  7  = 150 fps" & vbCrLf &
                     "  8  = 200 fps" & vbCrLf &
                     "  9  = 300 fps" & vbCrLf &
                     "10  =  400 fps" & vbCrLf &
                     "11  =  500 fps" & vbCrLf &
                     "12  =  Max fps")
            End If
        End If

        ttp1.SetToolTip(txt_MinChange, Msg_MinChange1 & vbCrLf &
                                        Msg_MinChange2 & vbCrLf &
                                        Msg_MinChange3 & vbCrLf &
                                        Msg_MinChange4 & vbCrLf &
                                        Msg_MinChange5 & vbCrLf &
                                        Msg_MinChange6)

        ttp1.SetToolTip(txt_CapArea, Msg_CapArea1 & vbCrLf &
                                        Msg_CapArea2 & vbCrLf &
                                        Msg_CapArea3 & vbCrLf &
                                        Msg_CapArea4 & vbCrLf &
                                        Msg_CapArea5 & vbCrLf &
                                        Msg_CapArea6 & vbCrLf &
                                        Msg_CapArea7 & vbCrLf &
                                        Msg_CapArea8)

        ttp1.SetToolTip(Label_ResponseSpeed, Msg_Filter1 & vbCrLf &
                                        Msg_Filter2 & vbCrLf &
                                        Msg_Filter3 & vbCrLf &
                                        Msg_Filter4 & vbCrLf &
                                        Msg_Filter5)

        ToolStripButton_Recognize.ToolTipText = Msg_Recognize1
        ToolStripButton_Validate.ToolTipText = Msg_Validate1
        ToolStripButton_BeepOnErrors.ToolTipText = Msg_BeepOnErrors1
        ToolStripButton_Lock.ToolTipText = Msg_Lock1 & vbCrLf & Msg_Lock2
        ToolStripButton_Disconnect.ToolTipText = Msg_Disconnect1
    End Sub

    ' --------------------- this corrects the XP bug that causes tooltip disappearing for ever 
    Private Sub controls_MouseEnter(ByVal sender As Object,
                                   ByVal e As System.EventArgs) Handles txt_CommSpeed.MouseEnter,
                                                                        txt_MinChange.MouseEnter,
                                                                        txt_CapArea.MouseEnter
        ttp1.Active = False
        ttp1.Active = True
    End Sub

End Class


