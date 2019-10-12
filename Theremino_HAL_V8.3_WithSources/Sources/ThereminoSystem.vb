
Module ThereminoSystem

    Friend DuplicateNames As Boolean = False
    Friend ConfigurationIsValid As Boolean = False
    Friend Masters As List(Of Master)
    Friend FreeRunningTimer As Stopwatch = New Stopwatch
    Friend CommandSlot As Int32 = 0

    Friend Sub TheSystem_InitMasters()
        ' ------------------------------------------------
        FreeRunningTimer.Start()
        ' ------------------------------------------------
        If Masters IsNot Nothing Then
            'For Each m As Master In Masters
            '    'If m.Hid.HidDevice_Unix.IsHidOpen() Then
            '    '    m.Hid.HidDevice_Unix.HidClose()
            '    'End If
            '    m.Hid = Nothing
            'Next
            Masters.Clear()
        Else
            Masters = New List(Of Master)
        End If

        If OperatingSystemIsWindows Then
            Theremino_HID.FindThereminoHids(False)
        Else
            Theremino_HID.FindThereminoHids_Unix(False)
        End If


        ' ------------------------------------------------ test Master names
        Dim i As Int32 = 0
        While i >= 0 And i < Masters.Count
            ' -------------------------------------------- read name 3 times to detect if the Master is already used
            Masters(i).ReadNameFromHardware()
            Dim name1 As String = Masters(i).GetName
            Masters(i).ReadNameFromHardware()
            Dim name2 As String = Masters(i).GetName
            Masters(i).ReadNameFromHardware()
            Dim name3 As String = Masters(i).GetName
            ' -------------------------------------------- if there are ValidMasterNames then test the Master-name 
            If ValidMasterNames.Length > 0 Then
                ' ---------------------------------------- test the Master-name and eventually release it 
                If Array.IndexOf(ValidMasterNames, Masters(i).GetName()) < 0 Then
                    Masters.Remove(Masters(i))
                    i -= 1
                End If
            Else
                ' ---------------------------------------- if a Master is used by another HAL then release it 
                If name1 <> name2 Or name2 <> name3 Then
                    Masters.Remove(Masters(i))
                    i -= 1
                End If
            End If
            ' -------------------------------------------- increase the while index
            i += 1
        End While
        ' ------------------------------------------------ Sort Masters
        Masters.Sort(AddressOf MasterComparer)
        ' ------------------------------------------------
        SetAllMasterId()
    End Sub

    Private Function MasterComparer(ByVal m1 As Master, ByVal m2 As Master) As Integer
        Return String.Compare(m1.GetName(), m2.GetName(), True)
    End Function

    Friend Sub TheSystem_ReconnectMasters()
        If OperatingSystemIsWindows Then
            Theremino_HID.FindThereminoHids(True)
        Else
            Theremino_HID.FindThereminoHids_Unix(True)
        End If
        TheSystem_ListComponents()
        Form1.ListView_SetAllLineColors()
    End Sub

    Friend Sub TheSystem_DisconnectMaster(ByVal m As Master)
        Masters.Remove(m)
        SetAllMasterId()
    End Sub

    Private Sub SetAllMasterId()
        For i As Int32 = 0 To Masters.Count - 1
            Masters(i).MasterId = i
            For Each s As Slave In Masters(i).Slaves
                s.MasterId = i
                For Each p As Pin In s.Pins
                    p.MasterId = i
                Next
            Next
        Next
    End Sub

    Friend Sub TheSystem_StartTimers()
        If Not ConfigurationIsValid Then Exit Sub
        For Each m As Master In Masters
            m.StartTimedOperations()
        Next
    End Sub

    Friend Sub TheSystem_StopTimers()
        For Each m As Master In Masters
            m.StopTimedOperations()
        Next
    End Sub

    Friend Sub TheSystem_RecognizeSlaves()
        For Each m As Master In Masters
            m.Recognize()
        Next

        AssignDefaultSlotsToPins()
        AssignConfigurationsToMasters()
        SetConfigurationParamsToDevices()

        ' ------------------------------------- remove adc24 redundant pins
        For Each m As Master In Masters
            If m.Slaves.Count > 0 Then
                If m.MasterFirmwareVersion >= 50 AndAlso m.Slaves(0).SlaveType = Slave.SlaveTypes.MasterPinsV4 Then
                    TryCast(m.Slaves(0), Slave_MasterPinsV4).Adc24_AddRemovePins()
                End If
            End If
        Next

        TestConfigErrors()

        Form1.SelectedLine = -1
        TheSystem_ListComponents()
        Form1.ListView_SetAllLineColors()
        MarkErrorLines()
        Form1.ToolStripButton_Validate.Enabled = Not ConfigurationIsValid And Not DuplicateNames
        Form1.EnableCalibrateButton(TheSystem_CalibrationNeeded)

        TheSystem_Calibrate()
    End Sub

    Private Sub AssignDefaultSlotsToPins()
        Dim i As Int32 = 1
        For Each m As Master In Masters
            Dim j As Int32 = i
            i += 100
            For Each s As Slave In m.Slaves
                For Each p As Pin In s.Pins
                    p.Slot = j
                    j += 1
                Next
            Next
        Next
    End Sub

    Friend Function TheSystem_CalibrationNeeded() As Boolean
        For Each m As Master In Masters
            If m.CalibrationNeeded Then Return True
        Next
    End Function

    Friend Sub TheSystem_Calibrate()
        For Each m As Master In Masters
            m.Calibrate()
        Next
    End Sub

    Friend Sub TheSystem_CalibrateZero()
        For Each m As Master In Masters
            m.CalibrateZero()
        Next
    End Sub

    Friend Sub TheSystem_SetParkingPositions()
        For Each m As Master In Masters
            m.SetOutputPinsToParkingPosition()
        Next
    End Sub

    Friend Function TheSystem_GetSlaveCount() As Int32
        Dim sc As Int32 = 0
        For Each m As Master In Masters
            sc += m.SlaveCount
        Next
        Return sc
    End Function

    Friend Function FindMasterByListLine(ByVal line As Int32) As Master
        If Masters Is Nothing Then Return Nothing
        Dim n As Int32 = 0
        For Each m As Master In Masters
            If n = line Then Return m
            n += 1
            For Each s As Slave In m.Slaves
                If n = line Then Return m
                n += 1
                For Each p As Pin In s.Pins
                    If n = line Then Return m
                    n += 1
                Next
            Next
        Next
        Return Nothing
    End Function

    'Friend Function FindSlaveByListLine(ByVal line As Int32) As Slave
    '    Dim n As Int32 = 0
    '    For Each m As Master In Masters
    '        n += 1
    '        For Each s As Slave In m.Slaves
    '            If n = line Then Return s
    '            n += 1
    '            For Each p As Pin In s.Pins
    '                n += 1
    '            Next
    '        Next
    '    Next
    '    Return Nothing
    'End Function

    Friend Function FindPinByListLine(ByVal line As Int32) As Pin
        Dim n As Int32 = 0
        For Each m As Master In Masters
            n += 1
            For Each s As Slave In m.Slaves
                n += 1
                For Each p As Pin In s.Pins
                    If n = line Then Return p
                    n += 1
                Next
            Next
        Next
        Return Nothing
    End Function

    Friend Function GetSelectedPin() As Pin
        Return FindPinByListLine(Form1.SelectedLine)
    End Function

    Friend Function GetSelectedListLine() As Int32
        Return Form1.SelectedLine
    End Function



    ' ==================================================================================================
    '   LIST COMPONENTS
    ' ==================================================================================================
    Friend Sub TheSystem_ListComponents()
        '
        LoadSlotNames()
        '
        Dim item As ListViewItem
        With Form1.MyListView1
            .OwnerDraw = True
            .GridLines = True
            .FullRowSelect = True
            .View = View.Details
            .LabelEdit = False
            .Font = New Font("Courier new", 8)
            ' ----------------------------------------------------------------- column headers
            .Header_BackColor1 = Color.FromArgb(255, 255, 200)
            .Header_BackColor2 = Color.FromArgb(200, 200, 200)
            .Header_ForeColor = Color.FromArgb(20, 20, 20)
            .Header_ShadowColor = Color.FromArgb(0, 255, 255, 200)
            .Header_Font = New Font("Microsoft Sans Serif", 9, FontStyle.Regular)
            '
            ' -----------------------------------------------------------------
            .Clear()
            .Header_TextVerticalPosition = -1
            .Header_TextAlignments = New StringAlignment() {StringAlignment.Near, _
                                                            StringAlignment.Center, _
                                                            StringAlignment.Near, _
                                                            StringAlignment.Center, _
                                                            StringAlignment.Center, _
                                                            StringAlignment.Near}

            .Columns.Add(" Type", 56, HorizontalAlignment.Left)
            .Columns.Add("ID", 28, HorizontalAlignment.Center)
            .Columns.Add(" Subtype", 105, HorizontalAlignment.Left)
            .Columns.Add("Slot", 35, HorizontalAlignment.Center)
            .Columns.Add("Value", 62, HorizontalAlignment.Right)
            .Columns.Add("    Notes", 100, HorizontalAlignment.Left)
            .Refresh()
            ' -----------------------------------------------------------------
            For Each m As Master In Masters
                item = .Items.Add("Master")
                item.SubItems.Add((m.MasterId + 1).ToString)
                item.SubItems.Add(m.GetName)
                item.SubItems.Add("")
                item.SubItems.Add("")
                item.SubItems.Add("")
                For Each s As Slave In m.Slaves
                    item = .Items.Add(" Slave")
                    item.SubItems.Add((s.SlaveId + 1).ToString)
                    item.SubItems.Add(s.SlaveTypeString)
                    item.SubItems.Add("")
                    item.SubItems.Add("")
                    If s.SlaveId = 0 Then
                        item.SubItems.Add("Firmware V" + s.FirmwareVersion())
                    Else
                        item.SubItems.Add("")
                    End If
                    For Each p As Pin In s.Pins
                        If p.PinId < 12 Then
                            item = .Items.Add("  Pin")
                            item.SubItems.Add((p.PinId + 1).ToString)
                        Else
                            item = .Items.Add(" Adc24")
                            item.SubItems.Add((p.PinId - 11).ToString)
                        End If

                        item.SubItems.Add(Pin.PinTypeToString(p.GetPinType))

                        If p.Direction <> Pin.Directions.Unused Then
                            item.SubItems.Add(p.Slot.ToString)
                            item.SubItems.Add("0.0")
                        Else
                            item.SubItems.Add("")
                            item.SubItems.Add("")
                        End If

                        If p.GetPinType = Pin.PinTypes.UNUSED OrElse s.Pins.Count > 6 AndAlso _
                            (s.Pins(6).GetPinType = Pin.PinTypes.ADC_24 And (p.PinId = 6 Or p.PinId = 7)) Then
                            item.SubItems.Add("")
                        Else
                            item.SubItems.Add(SlotNames(p.Slot))
                        End If
                    Next
                Next
            Next
            TheSystem_ListViewResize()
        End With
    End Sub


    ' ------------------------------------------------------------------
    '  Call this function from Form.Resize (not from ListView.resize)
    '  (otherwise the listview scroll produces problems)
    ' ------------------------------------------------------------------
    Friend Sub TheSystem_ListViewResize()
        ' -------------------------------------------- ResizeLastColumn
        With Form1.MyListView1
            If .Columns.Count > 1 Then
                .Columns(.Columns.Count - 1).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
            End If
        End With
    End Sub


    ' ==================================================================================================
    '   LIST COMPONENTS - UPDATE VALUES
    ' ==================================================================================================
    Friend Sub TheSystem_UpdateListedSubtypes()
        Dim str As String
        With Form1.MyListView1
            Dim n As Int32 = 0
            For Each m As Master In Masters
                If m.GetName <> .Items(n).SubItems(2).Text Then .Items(n).SubItems(2).Text = m.GetName
                n += 1
                For Each s As Slave In m.Slaves
                    str = s.SlaveTypeString
                    If str <> .Items(n).SubItems(2).Text Then .Items(n).SubItems(2).Text = str
                    n += 1
                    For Each p As Pin In s.Pins
                        str = Pin.PinTypeToString(p.GetPinType)
                        If str <> .Items(n).SubItems(2).Text Then .Items(n).SubItems(2).Text = str
                        n += 1
                    Next
                Next
            Next
        End With
    End Sub

    Friend Sub TheSystem_TestMasterError()
        For Each m As Master In Masters
            If Not m.Hid.MyDeviceDetected Then
                Slots.WriteSlot(CommandSlot, NAN_MasterError)
            End If
        Next
    End Sub


    Friend Sub TheSystem_UpdateListedValues()
        Dim str As String
        With Form1.MyListView1
            Dim n As Int32 = 0
            For Each m As Master In Masters
                If Not m.Hid.MyDeviceDetected Then
                    .Items(n).SubItems(5).Text = "DISCONNECTED"
                    .Items(n).BackColor = Color.FromArgb(255, 150, 150)
                    .Items(n).ForeColor = Color.Black
                End If
                n += 1
                For Each s As Slave In m.Slaves
                    n += 1
                    For Each p As Pin In s.Pins
                        If p.Direction <> Pin.Directions.Unused Then
                            If Single.IsNaN(p.Value) Then
                                str = NAN_GetName(p.Value)
                            Else
                                str = p.Value.ToString("0.0", GCI)
                            End If
                            If str <> .Items(n).SubItems(4).Text Then .Items(n).SubItems(4).Text = str
                        End If
                        n += 1
                    Next
                Next
            Next
        End With
    End Sub


    ' ==================================================================================================
    '   CONFIGURATIONS
    ' ==================================================================================================
    Friend ConfigDatabase() As Object

    Private Sub MarkErrorLines()
        '
        Dim config(-1) As String
        Dim nline As Int32 = 0
        '
        DuplicateNames = False
        '
        For Each m As Master In Masters

            ' ------------------------------------------- Test if another master has the same name
            If AnotherMasterHasTheSameName(m) Then
                ConfigurationIsValid = False
                m.StopTimedOperations()
                m.ConfigValid = False
                DuplicateNames = True
                Form1.MarkAllLinesWithDuplicateName(m)
                Continue For
            End If

            Dim npin As Int32 = 0
            Dim sa() As String
            '
            If ConfigDatabase.Length > 0 Then
                config = TryCast(ConfigDatabase(m.ConfigId), String())
            End If

            If npin < config.Length Then
                sa = Split(config(npin), ",")
                If sa.Length < 2 OrElse sa(0).Trim <> "Master" OrElse sa(1).Trim <> m.GetName Then
                    MarkErrorLine(nline)
                End If
            Else
                MarkErrorLine(nline)
            End If
            npin += 1
            nline += 1
            For Each s As Slave In m.Slaves
                If npin < config.Length Then
                    sa = Split(config(npin), ",")
                    If sa.Length < 2 OrElse sa(0).Trim <> "Slave" OrElse sa(1).Trim <> s.SlaveTypeString Then
                        MarkErrorLine(nline)
                    End If
                Else
                    MarkErrorLine(nline)
                End If
                npin += 1
                nline += 1
                For Each p As Pin In s.Pins
                    If npin < config.Length Then
                        sa = Split(config(npin), ",")
                        If sa.Length < 2 OrElse sa(0).Trim <> "Pin" OrElse sa(1).Trim <> Pin.PinTypeToString(p.GetPinType) Then
                            MarkErrorLine(nline)
                        End If
                    Else
                        MarkErrorLine(nline)
                    End If
                    npin += 1
                    nline += 1
                Next
            Next
            '
            ' ---------------------------------------------------------------- ADD ERROR LINES
            Dim newSlaveIndex As Int32 = 0
            While (npin < config.Length)
                ' ------------------------------------------------------------ add slaves and pins to Master
                Dim s() As String = Split(config(npin), ",")
                If s(0) = "Slave" Then
                    newSlaveIndex += 1
                    Dim sl As Slave = New Slave(Slave.StringToSlaveType(s(1)), m.MasterId, newSlaveIndex)
                    sl.Pins = New List(Of Pin)
                    m.Slaves.Add(sl)
                Else
                    Dim p As Pin = New Pin(Pin.StringToPinType(s(1)), m.MasterId, newSlaveIndex, npin)
                    m.Slaves(m.Slaves.Count - 1).Pins.Add(p)
                End If
                ' ------------------------------------------------------------ add error line to ListView
                AddErrorLine(config, npin, nline)
                npin += 1
                nline += 1
            End While
        Next
    End Sub

    Private Sub MarkErrorLine(ByVal LineNumber As Int32)
        With Form1.MyListView1.Items(LineNumber)
            .SubItems(5).Text = "Not configured"
            .BackColor = Color.FromArgb(255, 150, 150)
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub AddErrorLine(ByVal config As String(), ByVal npin As Int32, ByVal nline As Int32)
        With Form1.MyListView1
            ' ------------------------------------------------------- prepare the item
            Dim itm As ListViewItem
            Dim s() As String = Split(config(npin), ",")
            If s(0) = "Slave" Then
                itm = New ListViewItem(" " + s(0))
            Else
                itm = New ListViewItem("  " + s(0))
            End If
            itm.SubItems.Add("")
            itm.SubItems.Add(s(1).Trim)
            itm.SubItems.Add("")
            itm.SubItems.Add("")
            itm.SubItems.Add("Not found")
            itm.BackColor = Color.FromArgb(255, 150, 150)
            itm.ForeColor = Color.Black
            ' ------------------------------------------------------- insert the item in position "nline"
            .Items.Insert(nline, itm)
        End With
    End Sub

    Private Function AnotherMasterHasTheSameName(ByVal m1 As Master) As Boolean
        For Each m2 As Master In Masters
            If m1 Is m2 Then Continue For
            If m1.GetName = m2.GetName Then Return True
        Next
        Return False
    End Function

    Private Function CountConfigErrors(ByVal m As Master, ByVal Config As String()) As Int32
        Dim Errors As Int32 = 0
        Dim n As Int32 = 0
        Dim sa() As String
        '
        If n < Config.Length Then
            sa = Split(Config(n), ",")
            If sa.Length < 2 OrElse sa(0).Trim <> "Master" Then 'OrElse sa(1).Trim <> m.Name Then
                Errors += 1
            End If
        Else
            Errors += 1
        End If
        n += 1
        For Each s As Slave In m.Slaves
            If n < Config.Length Then
                sa = Split(Config(n), ",")
                If sa.Length < 2 OrElse sa(0).Trim <> "Slave" OrElse sa(1).Trim <> s.SlaveTypeString Then
                    Errors += 1
                End If
            Else
                Errors += 1
            End If
            n += 1
            For Each p As Pin In s.Pins
                If n < Config.Length Then
                    sa = Split(Config(n), ",")
                    If sa.Length < 2 OrElse sa(0).Trim <> "Pin" Then
                        Errors += 1
                    End If
                Else
                    Errors += 1
                End If
                n += 1
            Next
        Next
        '
        If Config.Length > n Then
            Errors += (Config.Length - n)
        End If
        '
        Return Errors
    End Function

    Private Sub TestConfigErrors()
        For i As Int32 = 0 To Masters.Count - 1
            If CountConfigErrors(Masters(i), _
                                 TryCast(ConfigDatabase(Masters(i).ConfigId), String())) > 0 Then
                Masters(i).StopTimedOperations()
                Masters(i).ConfigValid = False
                ConfigurationIsValid = False
            End If
        Next
    End Sub


    Friend Function GetConfigName(ByVal config As String()) As String
        Dim sa() As String
        sa = Split(config(0), ",")
        If sa.Length > 1 Then
            Return sa(1).Trim
        Else
            Return ""
        End If
    End Function

    Friend Function FindConfigByName(ByVal name As String) As Int32
        For i As Int32 = 0 To ConfigDatabase.Length - 1
            If name.ToUpper = GetConfigName(TryCast(ConfigDatabase(i), String())).ToUpper Then
                Return i
            End If
        Next
        Return -1
    End Function

    Friend Sub FillConfigNamesCombo(ByVal cmb As ComboBox)
        For i As Int32 = 0 To ConfigDatabase.Length - 1
            cmb.Items.Add(GetConfigName(TryCast(ConfigDatabase(i), String())))
        Next
    End Sub

    Private Sub AssignConfigurationsToMasters()
        '
        ConfigurationIsValid = True
        '
        For i As Int32 = 0 To Masters.Count - 1
            Masters(i).ConfigValid = True
            ' ----------------------------------------------------------- find configuration by name
            Masters(i).ConfigId = FindConfigByName(Masters(i).GetName)
            ' ----------------------------------------------------------- if not found add a new configuration
            If Masters(i).ConfigId < 0 Then
                Masters(i).ConfigId = ConfigDatabase.Length
                ' ------------------------------------------------------- add a new config without Adc24Pins
                Dim config As String() = CreateConfig_AsStringArray(Masters(i), True)
                AddToConfigDatabase(config)
                TheSystem_SaveConfigDatabase()
            End If
        Next
    End Sub

    Private Sub SetConfigurationParamsToDevices()
        Dim sa() As String
        For Each m As Master In Masters
            If m.ConfigId >= ConfigDatabase.Length Then Continue For
            Dim config As String() = TryCast(ConfigDatabase(m.ConfigId), String())
            If config Is Nothing Then Continue For
            Dim nline As Int32 = 0
            If nline >= config.Length Then Continue For
            sa = Split(config(nline), ",")
            nline += 1
            If sa.Length = 4 Then
                m.SetSpeed(CInt(Val(sa(2).Trim)))
                If m.Slaves.Count > 1 Then
                    m.FastComm = sa(3).Trim = "True"
                Else
                    m.FastComm = True
                End If
            End If
            For Each s As Slave In m.Slaves
                If nline >= config.Length Then Continue For
                sa = Split(config(nline), ",")
                nline += 1
                For Each p As Pin In s.Pins
                    If nline >= config.Length Then Continue For
                    sa = Split(config(nline), ",")
                    ' -------------------------------------- if last pin, goto next slave
                    Dim ConfLineType As String = sa(0).Trim
                    If ConfLineType <> "Pin" Then Continue For
                    nline += 1

                    Dim ConfPinType As Pin.PinTypes = Pin.StringToPinType(sa(1))
                    If ConfPinType <> p.GetPinType Then
                        s.ConfigurePin(p.PinId, ConfPinType)
                    End If

                    If sa.Length >= 6 Then
                        p.Slot = CInt(Val(sa(2).Trim))
                        If p.Slot > 999 Then p.Slot = 999
                        p.Value_Max = CSng(Val(sa(3).Trim))
                        p.Value_Min = CSng(Val(sa(4).Trim))
                        '
                        Dim nn As Int32 = CInt(Val(sa(5).Trim))
                        p.AdaptiveSpeed = False
                        If nn >= 1000 Then
                            p.AdaptiveSpeed = True
                            nn -= 1000
                        End If
                        If nn > 100 Then nn = 100
                        If nn < 1 Then nn = 1
                        p.ResponseSpeed = nn
                        '
                        Select Case p.GetPinType
                            Case Pin.PinTypes.PWM_8, Pin.PinTypes.PWM_16
                                If sa.Length >= 9 Then
                                    p.MaxTime = CSng(Val(sa(6).Trim))
                                    p.MinTime = CSng(Val(sa(7).Trim))
                                    p.LogResponse = sa(8).Trim = "True"
                                End If
                            Case Pin.PinTypes.SERVO_8, Pin.PinTypes.SERVO_16
                                If sa.Length >= 8 Then
                                    p.MaxTime = CSng(Val(sa(6).Trim))
                                    p.MinTime = CSng(Val(sa(7).Trim))
                                End If
                            Case Pin.PinTypes.STEPPER
                                If sa.Length >= 10 Then
                                    p.MaxSpeed = CSng(Val(sa(6).Trim))
                                    p.MaxAcc = CSng(Val(sa(7).Trim))
                                    p.StepsPerMillimeter = CSng(Val(sa(8).Trim))
                                    p.LinkedToPrevious = sa(9).Trim = "True"
                                End If
                            Case Pin.PinTypes.PWM_FAST
                                If sa.Length >= 10 Then
                                    p.PwmFastFrequency = CSng(Val(sa(6).Trim))
                                    p.PwmFastDutyCycle = CSng(Val(sa(7).Trim))
                                    p.FrequencyFromSlot = sa(8).Trim = "True"
                                    p.DutyCycleFromSlot = sa(9).Trim = "True"
                                End If
                            Case Pin.PinTypes.CAP_8, Pin.PinTypes.CAP_16
                                If sa.Length >= 8 Then
                                    p.MinVariation = CSng(Val(sa(6).Trim))
                                    p.ProportionalArea = CSng(Val(sa(7).Trim))
                                End If
                            Case Pin.PinTypes.USOUND_SENSOR
                                If sa.Length >= 9 Then
                                    p.MaxDist_mm = CSng(Val(sa(6).Trim))
                                    p.MinDist_mm = CSng(Val(sa(7).Trim))
                                    p.RemoveErrors = sa(8).Trim = "True"
                                End If
                            Case Pin.PinTypes.CAP_SENSOR
                                If sa.Length >= 9 Then
                                    p.MaxDist_mm = CSng(Val(sa(6).Trim))
                                    p.MinDist_mm = CSng(Val(sa(7).Trim))
                                    p.Area_cmq = CSng(Val(sa(8).Trim))
                                End If
                            Case Pin.PinTypes.COUNTER, Pin.PinTypes.COUNTER_PU, _
                                 Pin.PinTypes.FAST_COUNTER, Pin.PinTypes.FAST_COUNTER_PU, _
                                 Pin.PinTypes.PERIOD, Pin.PinTypes.PERIOD_PU, _
                                 Pin.PinTypes.SLOW_PERIOD, Pin.PinTypes.SLOW_PERIOD_PU
                                If sa.Length >= 9 Then
                                    p.MaxFreq = CSng(Val(sa(6).Trim))
                                    p.MinFreq = CSng(Val(sa(7).Trim))
                                    p.ConvertToFreq = sa(8).Trim = "True"
                                End If
                            Case Pin.PinTypes.ADC_24
                                If sa.Length >= 9 Then
                                    p.Adc24Npins = CInt(Val(sa(6).Trim))
                                    p.Adc24Sps = CInt(Val(sa(7).Trim))
                                    p.Adc24Filter = CInt(Val(sa(8).Trim))
                                End If
                            Case Pin.PinTypes.ADC_24_DIN, _
                                 Pin.PinTypes.ADC_24_DOUT
                                '
                            Case Pin.PinTypes.ADC_24_CH, _
                                 Pin.PinTypes.ADC_24_CH_B
                                If sa.Length >= 9 Then
                                    p.Adc24ChType = CInt(Val(sa(6).Trim))
                                    p.Adc24ChGain = CInt(Val(sa(7).Trim))
                                    p.Adc24ChBias = sa(8).Trim = "True"
                                End If
                                '
                            Case Pin.PinTypes.ENCODER_B, Pin.PinTypes.ENCODER_B_PU
                                '
                        End Select
                    End If
                Next

                ' -------------------------------------- re-align all the pins 
                'If PinTypeChanged Then
                m.SetupSlavePins(s.mSlaveId)
                'End If
                '
                ' -------------------------------------- send special Pin configurations
                If s.SlaveId = 0 Then
                    ' ------------------------------------- special STEPPER parameters
                    For Each p As Pin In s.Pins
                        If p.GetPinType = Pin.PinTypes.STEPPER Then
                            ' ------------------------------------------------------------------
                            '  STEPPER PIN CONFIGURATION - BY SendBytesToSlave
                            ' ------------------------------------------------------------------
                            p.SendStepperParamsToHardware()
                            ' ------------------------------------------------------------------
                        End If
                    Next
                    ' ------------------------------------- special ADC_24 parameters
                    If m.MasterFirmwareVersion >= 50 AndAlso s.SlaveType = Slave.SlaveTypes.MasterPinsV4 Then
                        TryCast(s, Slave_MasterPinsV4).Adc24_AddRemovePins()
                        If s.Pins(6).GetPinType = Pin.PinTypes.ADC_24 Then
                            TryCast(s, Slave_MasterPinsV4).Adc24ConfigAndStart()
                        End If
                    End If
                End If
                '
            Next
            m.SetCommunicationIndexesToPins()
        Next
    End Sub

    Private Function CreateConfig_AsStringArray(ByVal m As Master, ByVal DoNotAddAdc24Pins As Boolean) As String()
        Dim i As Int32
        Dim config(0) As String
        config(0) = "Master"
        config(0) &= "," & m.GetName
        config(0) &= "," & m.CommSpeed.ToString
        config(0) &= "," & m.FastComm.ToString
        For Each s As Slave In m.Slaves
            i = config.Length
            ReDim Preserve config(i)
            config(i) = "Slave"
            config(i) &= "," & s.SlaveTypeString
            For Each p As Pin In s.Pins
                i = config.Length
                If DoNotAddAdc24Pins AndAlso i > 13 Then Exit For
                ReDim Preserve config(i)
                config(i) = "Pin"
                config(i) &= "," & Pin.PinTypeToString(p.GetPinType)
                config(i) &= "," & p.Slot.ToString
                config(i) &= "," & p.Value_Max.ToString(GCI)
                config(i) &= "," & p.Value_Min.ToString(GCI)
                Dim nn As Int32 = p.ResponseSpeed
                If p.AdaptiveSpeed Then nn += 1000
                config(i) &= "," & nn.ToString
                Select Case p.GetPinType
                    Case Pin.PinTypes.PWM_8, Pin.PinTypes.PWM_16
                        config(i) &= "," & p.MaxTime.ToString
                        config(i) &= "," & p.MinTime.ToString
                        config(i) &= "," & p.LogResponse.ToString
                    Case Pin.PinTypes.SERVO_8, Pin.PinTypes.SERVO_16
                        config(i) &= "," & p.MaxTime.ToString
                        config(i) &= "," & p.MinTime.ToString
                    Case Pin.PinTypes.STEPPER
                        config(i) &= "," & p.MaxSpeed.ToString(GCI)
                        config(i) &= "," & p.MaxAcc.ToString(GCI)
                        config(i) &= "," & p.StepsPerMillimeter.ToString(GCI)
                        config(i) &= "," & p.LinkedToPrevious.ToString
                    Case Pin.PinTypes.PWM_FAST
                        config(i) &= "," & p.PwmFastFrequency.ToString
                        config(i) &= "," & p.PwmFastDutyCycle.ToString
                        config(i) &= "," & p.FrequencyFromSlot.ToString
                        config(i) &= "," & p.DutyCycleFromSlot.ToString
                    Case Pin.PinTypes.CAP_8, Pin.PinTypes.CAP_16
                        config(i) &= "," & p.MinVariation.ToString
                        config(i) &= "," & p.ProportionalArea.ToString
                    Case Pin.PinTypes.USOUND_SENSOR
                        config(i) &= "," & p.MaxDist_mm.ToString
                        config(i) &= "," & p.MinDist_mm.ToString
                        config(i) &= "," & p.RemoveErrors.ToString
                    Case Pin.PinTypes.CAP_SENSOR
                        config(i) &= "," & p.MaxDist_mm.ToString
                        config(i) &= "," & p.MinDist_mm.ToString
                        config(i) &= "," & p.Area_cmq.ToString
                    Case Pin.PinTypes.COUNTER, Pin.PinTypes.COUNTER_PU, _
                         Pin.PinTypes.FAST_COUNTER, Pin.PinTypes.FAST_COUNTER_PU, _
                         Pin.PinTypes.PERIOD, Pin.PinTypes.PERIOD_PU, _
                         Pin.PinTypes.SLOW_PERIOD, Pin.PinTypes.SLOW_PERIOD_PU
                        config(i) &= "," & p.MaxFreq.ToString
                        config(i) &= "," & p.MinFreq.ToString
                        config(i) &= "," & p.ConvertToFreq.ToString
                    Case Pin.PinTypes.ADC_24
                        config(i) &= "," & p.Adc24Npins.ToString
                        config(i) &= "," & p.Adc24Sps.ToString
                        config(i) &= "," & p.Adc24Filter.ToString
                    Case Pin.PinTypes.ADC_24_DIN, _
                         Pin.PinTypes.ADC_24_DOUT
                        '
                    Case Pin.PinTypes.ADC_24_CH, Pin.PinTypes.ADC_24_CH_B
                        config(i) &= "," & p.Adc24ChType.ToString
                        config(i) &= "," & p.Adc24ChGain.ToString
                        config(i) &= "," & p.Adc24ChBias.ToString
                        '
                    Case Pin.PinTypes.ENCODER_B, Pin.PinTypes.ENCODER_B_PU
                        '
                End Select
            Next
        Next
        Return config
    End Function

    Friend Sub TheSystem_ValidateConfiguration()
        For Each m As Master In Masters
            m.ConfigValid = True
        Next
        ConfigurationIsValid = True
        TheSystem_ListComponents()
        Form1.ListView_SetAllLineColors()
        Form1.ToolStripButton_Validate.Enabled = Not ConfigurationIsValid And Not DuplicateNames
        Form1.EnableCalibrateButton(TheSystem_CalibrationNeeded)
    End Sub

    Friend Sub AddToConfigDatabase(ByVal config As String())
        If config.Length > 0 Then
            Dim count As Int32 = ConfigDatabase.Length
            ReDim Preserve ConfigDatabase(count)
            ConfigDatabase(count) = config
        End If
    End Sub

    Friend Sub TheSystem_UpdateAndSaveConfigDatabase()
        TheSystem_UpdateConfigDatabase()
        TheSystem_SaveConfigDatabase()
    End Sub

    Friend Sub TheSystem_UpdateConfigDatabase()
        If ConfigurationIsValid Then
            For Each m As Master In Masters
                If m.ConfigValid Then
                    If m.ConfigId <= ConfigDatabase.Length And ConfigDatabase.Length > 0 Then
                        ConfigDatabase(m.ConfigId) = CreateConfig_AsStringArray(m, False)
                    Else
                        m.StopTimedOperations()
                        m.ConfigValid = False
                        ConfigurationIsValid = False
                    End If
                End If
            Next
        End If
    End Sub

    Friend Sub TheSystem_SaveConfigDatabase()
        If ConfigurationIsValid Then
            Save_ConfigDatabase()
        Else
            'MsgBox("Invalid configuration - ""Config Database"" not saved.", MsgBoxStyle.Information)
        End If
    End Sub

End Module
