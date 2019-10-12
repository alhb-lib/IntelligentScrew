


' ==================================================================================================
'   CLASS MASTER
' ==================================================================================================

Partial Friend Class Master

    Private mActionLock As Object = New Object
    Private mName As String
    Private mSlaveCount As Int32
    Private mMaxFps As Int32

    Friend Hid As Theremino_HID
    Friend ConfigId As Int32
    Friend ConfigValid As Boolean
    Friend Slaves As List(Of Slave)
    Friend MasterId As Int32
    Friend MasterFirmwareVersion As Int32

    Friend CommSpeed As Int32
    Friend FastComm As Boolean
    Friend CommMillisec As Single
    Friend CommFps As Single
    Friend ErrorRate As Single
    Friend HasPhysicalSlaves As Boolean

    Friend ReadOnly Property SlaveCount() As Int32
        Get
            Return mSlaveCount
        End Get
    End Property

    Friend Sub SetCommSpeed(ByVal _speed As Int32)
        CommSpeed = _speed
        Select Case CommSpeed
            Case 1 : mMaxFps = 10
            Case 2 : mMaxFps = 20
            Case 3 : mMaxFps = 30
            Case 4 : mMaxFps = 50
            Case 5 : mMaxFps = 60
            Case 6 : mMaxFps = 100
            Case 7 : mMaxFps = 150
            Case 8 : mMaxFps = 200
            Case 9 : mMaxFps = 300
            Case 10 : mMaxFps = 400
            Case 11 : mMaxFps = 500
            Case Else : mMaxFps = 9999
        End Select
    End Sub

    Friend Sub SetName(ByVal _name As String)
        mName = _name
    End Sub

    Friend Function GetName() As String
        Return mName
    End Function

    Friend Sub New(ByVal _masterid As Int32)
        mName = "NoName"
        MasterId = _masterid
        MasterFirmwareVersion = 10 ' Initial Master firmware version
        mSlaveCount = 0
        SetCommSpeed(7)
        FastComm = False
        CommFps = 100
        Slaves = New List(Of Slave)
    End Sub

    'Protected Overrides Sub Finalize()
    '    If CanUseWindowsDlls() Then
    '        '
    '    Else
    '        '    If Hid.HidDevice_Unix.IsHidOpen() Then
    '        '        Hid.HidDevice_Unix.HidClose()
    '        '    End If
    '    End If
    'End Sub



    ' ==========================================================================================
    '   HOST TO MASTER COMMANDS
    ' ==========================================================================================

    Friend Enum Cmd As Byte
        ' --------------------------------------- commands that master expands for the slaves
        RECOG_START = 254
        'CMD_RECOG 						= 253 ( Master to Slaves only )
        FAST_DATA_EXCHANGE = 251
        '
        ' --------------------------------------- commands that master repeats to slaves
        SETUP_SLAVE_PINS = 249
        SET_MASTER_NAME = 248
        GET_MASTER_NAME = 247
        SEND_VALUES = 246
        GET_VALUES = 245
        SEND_BYTES = 244
        GET_BYTES = 243
        '
        ' --------------------------------------- commands to master only  ( < 200 )
        SPEED = 199
        NOCMD = 0
    End Enum

    Friend Enum CommandsToHardware As Int32
        SendStepperParams = 100
        GetMasterFirmwareVersion = 101
        SendAdc24Config = 102
    End Enum


    ' ==========================================================================================
    '   PUBLIC COMMANDS
    ' ==========================================================================================
    Friend Sub Calibrate()
        If Not CalibrationNeeded Then Exit Sub
        DataExchangeThread_Stop()
        SyncLock mActionLock
            System.Threading.Thread.Sleep(10)
            DataExchange()
            System.Threading.Thread.Sleep(10)
            For i As Int32 = 0 To SlaveCount - 1
                Slaves(i).Calibrate()
            Next
        End SyncLock
        DataExchangeThread_Start()
    End Sub

    Friend Sub CalibrateZero()
        For i As Int32 = 0 To SlaveCount - 1
            Slaves(i).CalibrateZero()
        Next
    End Sub

    Friend Function CalibrationNeeded() As Boolean
        For i As Int32 = 0 To SlaveCount - 1
            If Slaves(i).CalibrationNeeded Then
                Return True
            End If
        Next
        Return False
    End Function

    Friend Sub SetSpeed()
        DataExchangeThread_Stop()
        SyncLock mActionLock
            SendSpeedToSlaves()
        End SyncLock
        DataExchangeThread_Start()
    End Sub

    Friend Sub SetSpeed(ByVal _Speed As Int32)
        DataExchangeThread_Stop()
        SyncLock mActionLock
            SetCommSpeed(_Speed)
            SendSpeedToSlaves()
        End SyncLock
        DataExchangeThread_Start()
    End Sub


    Friend Sub Recognize()
        '' ------------------------------------------------- try to unlock slaves
        'Dim b(60) As Byte
        'SendBytesToSlave(255, b)
        'SleepMyThread(100)
        '' -------------------------------------------------

        DataExchangeThread_Stop()
        SyncLock mActionLock
            Slaves.Clear()
            ' --------------------------------------------- SPEED - TODO test with a great number of slaves
            SendSpeedToSlaves()
            SendSpeedToSlaves()
            'SendSpeedToSlaves()
            'SendSpeedToSlaves()
            'SendSpeedToSlaves()
            'SendSpeedToSlaves()
            ' --------------------------------------------- DETECT
            Hid.USB_TxData(0) = Cmd.RECOG_START
            Hid.USB_TxData(1) = 0
            ' --------------------------------------------- WRITE-READ
            Hid.USB_Write_Read()
            Hid.USB_TxData(0) = Cmd.NOCMD
            mSlaveCount = Hid.USB_RxData(1)
            Dim slave_types(mSlaveCount - 1) As Slave.SlaveTypes
            For i As Int32 = 0 To mSlaveCount - 1
                slave_types(i) = CType(Hid.USB_RxData(i + 2), Slave.SlaveTypes)
            Next
            ' --------------------------------------------- ERROR ?
            If Hid.USB_RxData(0) <> 0 Then
                Execution_Error("Recognize")
            Else
                Execution_OK()
            End If
            ' --------------------------------------------- Master firmware version
            GetMasterFirmwareVersion()
            ' --------------------------------------------- INIT
            HasPhysicalSlaves = False

            For i As Int32 = 0 To mSlaveCount - 1
                Dim s As Slave.SlaveTypes = slave_types(i)
                Select Case s
                    Case Slave.SlaveTypes.CapSensor
                        Slaves.Add(New Slave_CapSensor(MasterId, i))
                        HasPhysicalSlaves = True
                    Case Slave.SlaveTypes.Servo
                        Slaves.Add(New Slave_Servo(MasterId, i))
                        HasPhysicalSlaves = True
                    Case Slave.SlaveTypes.Generic
                        Slaves.Add(New Slave_Generic(MasterId, i))
                        HasPhysicalSlaves = True
                    Case Slave.SlaveTypes.InOut
                        Slaves.Add(New Slave_InOut(MasterId, i))
                        HasPhysicalSlaves = True
                    Case Slave.SlaveTypes.MasterPins
                        Slaves.Add(New Slave_MasterPins(MasterId, i))
                    Case Slave.SlaveTypes.MasterPinsV2
                        Slaves.Add(New Slave_MasterPinsV2(MasterId, i))
                    Case Slave.SlaveTypes.MasterPinsV4
                        Slaves.Add(New Slave_MasterPinsV4(MasterId, i))
                    Case Else
                        mSlaveCount = 0
                        Slaves.Clear()
                        Exit For
                End Select
            Next
        End SyncLock
        DataExchangeThread_Start()
    End Sub

    Friend Sub GetMasterFirmwareVersion()
        Dim slavesCount As Int32 = Hid.USB_RxData(1)
        Dim virtualSlaveType As Slave.SlaveTypes = CType(Hid.USB_RxData(2), Slave.SlaveTypes)
        If slavesCount > 0 Then
            Select Case virtualSlaveType
                Case Slave.SlaveTypes.MasterPins
                    MasterFirmwareVersion = 20                      ' Version 2.0 - six Master Pins
                Case Slave.SlaveTypes.MasterPinsV2
                    MasterFirmwareVersion = 32                      ' Version 3.2 - ten Master Pins with Stepper and PwmFast management
                Case Slave.SlaveTypes.MasterPinsV4
                    MasterFirmwareVersion = 40                      ' by now Version 4.0 - twelve Master Pins with Encoder management
                    ReadFirmwareVersionFromHardware()
                    If MasterFirmwareVersion < 41 Then
                        MasterFirmwareVersion = 40                  ' Version 4.0 - twelve Master Pins with Encoder management
                    End If
            End Select
        End If
    End Sub

    Friend Sub ReadFirmwareVersionFromHardware()
        ' ---------------------------------------------------- send CMD / SlaveId / Nbytes
        Hid.USB_TxData(0) = Cmd.SEND_BYTES
        Hid.USB_TxData(1) = 0 'unused SlaveId
        Hid.USB_TxData(2) = 1 'bytes.Length
        Hid.USB_TxData(3) = CByte(CommandsToHardware.GetMasterFirmwareVersion)

        Hid.USB_Write_Read()
        Hid.USB_TxData(0) = Cmd.NOCMD
        ' --------------------------------------------- if not error
        If Hid.USB_RxData(0) = 0 Then
            MasterFirmwareVersion = Hid.USB_RxData(1)   ' Version 4.1 and following - twelve Master Pins with Adc24 management
        End If
    End Sub


    Friend Sub SetupSlavePins(ByVal slaveID As Int32)
        DataExchangeThread_Stop()
        SyncLock mActionLock
            Dim s As Slave = Slaves(slaveID)
            Hid.USB_TxData(0) = Cmd.SETUP_SLAVE_PINS
            Hid.USB_TxData(1) = CByte(slaveID)
            Hid.USB_TxData(2) = CByte(s.Pins.Count)
            For i As Int32 = 0 To s.Pins.Count - 1
                Hid.USB_TxData(i + 3) = CByte(s.Pins(i).GetPinType)
            Next
            Hid.USB_Write_Read()
            Hid.USB_TxData(0) = Cmd.NOCMD
            ' --------------------------------------------- error ?
            If Hid.USB_RxData(0) <> 0 Then
                Execution_Error("SetupSlavePins")
            Else
                Execution_OK()
            End If
            ' ---------------------------------------------
            SetCommunicationIndexesToPins()
        End SyncLock
        DataExchangeThread_Start()
    End Sub

    Friend Sub WriteNameToHardware()
        DataExchangeThread_Stop()
        SyncLock mActionLock
            Hid.USB_TxData(0) = Cmd.SET_MASTER_NAME
            Dim i As Int32
            For i = 1 To mName.Length
                Hid.USB_TxData(i) = CByte(Asc(Mid(mName, i, 1)))
            Next
            Hid.USB_TxData(i) = CByte(0)
            Hid.USB_Write_Read()
            Hid.USB_TxData(0) = Cmd.NOCMD
            ' --------------------------------------------- error ?
            If Hid.USB_RxData(0) <> 0 Then
                Execution_Error("WriteNameToHardware")
            Else
                Execution_OK()
            End If
        End SyncLock
        DataExchangeThread_Start()
    End Sub

    Friend Sub ReadNameFromHardware()
        DataExchangeThread_Stop()
        SyncLock mActionLock
            mName = ""
            Hid.USB_TxData(0) = Cmd.GET_MASTER_NAME
            Hid.USB_Write_Read()
            Hid.USB_TxData(0) = Cmd.NOCMD
            ' --------------------------------------------- error ?
            If Hid.USB_RxData(0) = 0 Then
                Dim i As Int32 = 1
                Do
                    If Hid.USB_RxData(i) = 0 Then Exit Do
                    mName += Chr(Hid.USB_RxData(i))
                    i += 1
                Loop
                mName = mName.Trim
                Execution_OK()
            Else
                Execution_Error("ReadNameToHardware")
            End If
        End SyncLock
        DataExchangeThread_Start()
    End Sub


    Friend Sub SetOutputPinsToParkingPosition()
        DataExchangeThread_Stop()
        SyncLock mActionLock
            For Each s As Slave In Slaves
                For Each p As Pin In s.Pins
                    If p.Direction = Pin.Directions.HostToMaster Then
                        ' ------------------------------------------------------
                        '  Steppers excluded to avoid problems
                        ' ------------------------------------------------------
                        If p.GetPinType = Pin.PinTypes.STEPPER Then Continue For
                        ' ------------------------------------------------------
                        p.Value = p.Value_Parking
                        If Single.IsNaN(p.Value) Then
                            Slots.WriteSlot(p.Slot, p.Value)
                        Else
                            p.ConvertValueToHardwareFormat()
                            Slots.WriteSlot(p.Slot, p.Value_RawUinteger)
                        End If
                    End If
                Next
            Next
            ' ------------------------------------------------- USB <> Master <> Slaves
            DataExchange()
            System.Threading.Thread.Sleep(32)
        End SyncLock
        DataExchangeThread_Start()
    End Sub

    Friend Sub SetCommunicationIndexesToPins()
        ' ---------------------------------------------------- byte 0 is the command
        Dim UsbByteIndex_HostToHardware As Int32 = 1
        ' ---------------------------------------------------- byte 0 is the response
        Dim UsbByteIndex_HardwareToHost As Int32 = 1
        '
        For Each s As Slave In Slaves
            For Each p As Pin In s.Pins
                ' --------------------------------------------------- USB communication byte index
                Select Case p.Direction
                    Case Pin.Directions.HostToMaster
                        p.UsbByteIndex = UsbByteIndex_HostToHardware
                        UsbByteIndex_HostToHardware += p.UsbBytesCount
                    Case Pin.Directions.MasterToHost
                        p.UsbByteIndex = UsbByteIndex_HardwareToHost
                        UsbByteIndex_HardwareToHost += p.UsbBytesCount
                End Select
                'Debug.Print(p.PinId.ToString & "  " & Pin.PinTypeToString(p.GetPinType) & "  " & p.UsbByteIndex)
            Next
        Next
    End Sub



    ' ==========================================================================================
    '   INTERNAL COMMANDS
    ' ==========================================================================================
    Private Sub SendSpeedToSlaves()
        '
        Hid.USB_TxData(0) = Cmd.SPEED
        Hid.USB_TxData(1) = CByte(CommSpeed)
        '
        Hid.USB_Write_Read()
        Hid.USB_TxData(0) = Cmd.NOCMD
        ' --------------------------------------------- error ?
        If Hid.USB_RxData(0) <> 0 Then
            Execution_Error("SendSpeedToSlaves")
        Else
            Execution_OK()
        End If
    End Sub

    ' ==========================================================================================
    '   GET/SEND - VALUES/BYTES - FROM/TO SLAVES
    ' ==========================================================================================
    Friend Function GetValuesFromSlave(ByVal SlaveId As Int32, ByRef ByteArray() As Byte) As Boolean
        ' ----------------------------------------------------
        ' SyncLock not needed because called from timer
        ' ---------------------------------------------------- send CMD / SlaveId / Nbytes
        Hid.USB_TxData(0) = Cmd.GET_VALUES
        Hid.USB_TxData(1) = CByte(SlaveId)
        Hid.USB_TxData(2) = CByte(ByteArray.Length)
        ' ---------------------------------------------------- send and receive
        Hid.USB_Write_Read()
        Hid.USB_TxData(0) = Cmd.NOCMD
        ' ---------------------------------------------------- get bytes
        For i As Int32 = 0 To ByteArray.Length - 1
            ByteArray(i) = Hid.USB_RxData(i + 1)
        Next
        ' ---------------------------------------------------- manage errors
        If Hid.USB_RxData(0) <> 0 Then
            Execution_Error("GetValuesFromSlave")
            Return False
        Else
            Execution_OK()
        End If
        Return True
    End Function

    Friend Sub SendValuesToSlave(ByVal SlaveId As Int32, ByRef bytes() As Byte)
        ' ----------------------------------------------------
        ' SyncLock not needed because called from timer
        ' ---------------------------------------------------- send CMD / SlaveId / Nbytes
        Hid.USB_TxData(0) = Cmd.SEND_VALUES
        Hid.USB_TxData(1) = CByte(SlaveId)
        Hid.USB_TxData(2) = CByte(bytes.Length)
        ' ---------------------------------------------------- send bytes
        For i As Int32 = 0 To bytes.Length - 1
            Hid.USB_TxData(3 + i) = bytes(i)
        Next
        ' ---------------------------------------------------- send and receive
        Hid.USB_Write_Read()
        Hid.USB_TxData(0) = Cmd.NOCMD
        ' ---------------------------------------------------- manage errors
        If Hid.USB_RxData(0) <> 0 Then
            Execution_Error("SendValuesToSlave")
        Else
            Execution_OK()
        End If
    End Sub

    Friend Sub GetBytesFromSlave(ByVal SlaveId As Int32, ByRef ByteArray() As Byte)
        DataExchangeThread_Stop()
        SyncLock mActionLock
            ' ---------------------------------------------------- send CMD / SlaveId / Nbytes
            Hid.USB_TxData(0) = Cmd.GET_BYTES
            Hid.USB_TxData(1) = CByte(SlaveId)
            Hid.USB_TxData(2) = CByte(ByteArray.Length)
            ' ---------------------------------------------------- send and receive
            Hid.USB_Write_Read()
            Hid.USB_TxData(0) = Cmd.NOCMD
            ' ---------------------------------------------------- get bytes
            For i As Int32 = 0 To ByteArray.Length - 1
                ByteArray(i) = Hid.USB_RxData(i + 1)
            Next
            ' ---------------------------------------------------- manage errors
            If Hid.USB_RxData(0) <> 0 Then
                Execution_Error("GetBytesFromSlave")
            Else
                Execution_OK()
            End If
        End SyncLock
        DataExchangeThread_Start()
    End Sub

    Friend Sub SendBytesToSlave(ByVal SlaveId As Int32, ByRef bytes() As Byte)
        DataExchangeThread_Stop()
        SyncLock mActionLock
            ' ---------------------------------------------------- send CMD / SlaveId / Nbytes
            Hid.USB_TxData(0) = Cmd.SEND_BYTES
            Hid.USB_TxData(1) = CByte(SlaveId)
            Hid.USB_TxData(2) = CByte(bytes.Length)
            ' ---------------------------------------------------- send bytes
            For i As Int32 = 0 To bytes.Length - 1
                Hid.USB_TxData(3 + i) = bytes(i)
            Next
            ' ---------------------------------------------------- send and receive
            Hid.USB_Write_Read()
            Hid.USB_TxData(0) = Cmd.NOCMD
            ' ---------------------------------------------------- manage errors
            If Hid.USB_RxData(0) <> 0 Then
                Execution_Error("SendBytesToSlave")
            Else
                Execution_OK()
            End If
        End SyncLock
        DataExchangeThread_Start()
    End Sub

    Private Sub Execution_Error(ByVal ErrorString As String)
        ErrorRate += 0.01F
        Debug.Print("ERROR - " & ErrorString)
    End Sub

    Private Sub Execution_OK()
        ErrorRate *= 0.95F
    End Sub


    ' ==========================================================================================
    '   SMOOTHING FUNCTIONS
    ' ==========================================================================================
    Friend Sub SmoothValue(ByRef value As Single, _
                           ByVal new_value As Single, _
                           ByVal speed As Single, _
                           ByVal pow_speed As Boolean)
        '
        If speed = 100 OrElse Single.IsNaN(value) OrElse Single.IsNaN(new_value) Then
            value = new_value
            Return
        End If
        ' --------------------------------------------------- exclude gradually the smoothing 
        Select Case speed
            Case 98 : speed = 150
            Case 99 : speed = 200
        End Select
        '
        If pow_speed Then
            ' ------------------------------------------------ correction to have a similar response
            speed *= 10 '27
            '
            Dim delta As Single = new_value - value
            Dim delta_sgn As Single = Math.Sign(delta)
            Dim delta_abs As Single = Math.Abs(delta)

            Dim delta_pow As Single = CSng(delta_abs ^ 2) * speed / CommFps
            If value <> 0 Then delta_pow /= Math.Abs(value)

            If delta_pow >= delta_abs Then
                value = new_value
            Else
                value += delta_sgn * delta_pow
            End If
        Else
            Dim delta As Single = new_value - value
            Dim delta_sgn As Single = Math.Sign(delta)
            Dim delta_abs As Single = Math.Abs(delta)
            Dim delta_pow As Single = CSng(speed / CommFps * delta_abs)
            If delta_pow >= delta_abs Then
                value = new_value
            Else
                value += delta_sgn * delta_pow
            End If
        End If
    End Sub


    ' ==========================================================================================
    '   LOOPS AND COMMUNICATIONS
    ' ==========================================================================================
    Private sw1 As Diagnostics.Stopwatch = New Diagnostics.Stopwatch
    Private rawMs As Single
    Private delayMs As Int32
    Private Sub DataExchange()
        ' ---------------------------------------------------------- if disconnected return
        If Not Hid.MyDeviceDetected Then
            CommFps = 0
            ErrorRate = 100
            Threading.Thread.Sleep(10)
            Return
        End If
        ' ---------------------------------------------------------- 
        'CommMillisec = CSng(sw1.Elapsed.TotalMilliseconds - 0.1)
        'CommMillisec = CSng(sw1.Elapsed.TotalMilliseconds)
        CommMillisec = CSng(sw1.ElapsedMilliseconds)
        rawMs = 1000.0F / CommMillisec
        sw1.Reset()
        sw1.Start()
        If CommMillisec >= 1 Then
            SmoothValue(CommFps, rawMs, 1, True)
        End If
        Try
            If FastComm Then
                FastDataExchange()
            Else
                SlowDataExchange()
            End If
            ' -------------------------------------------------------- adaptive FPS
            If mMaxFps < 9999 Then
                If Not HasPhysicalSlaves Then
                    delayMs += Math.Sign(rawMs - mMaxFps)
                    If delayMs > 100 Then delayMs = 100
                    If delayMs <= 0 Then
                        delayMs = 0
                    Else
                        System.Threading.Thread.Sleep(delayMs)
                    End If
                End If
            End If
        Catch
#If DEBUG Then
            Beep_RepetitionLimited(150)
            'MsgBox("Exception in ""DataExchange""")
            Debug.Print("Exception in ""DataExchange""")
#End If
        End Try
    End Sub


    ' ==========================================================================================
    '   SLOW DATA EXCHANGE
    ' ==========================================================================================
    Private Sub SlowDataExchange()
        Dim ix As Int32
        Dim b() As Byte
        Dim ExchangedFlag As Boolean = False
        ' -------------------------------------------------------- MMF to USB
        For Each s As Slave In Slaves
            Dim nbytes As Int32 = s.GetHostToMasterBytesCount
            If nbytes > 0 Then
                ' ------------------------------------------------
                For Each p As Pin In s.Pins
                    If p.Direction = Pin.Directions.HostToMaster Then
                        p.ReadValueFromMMF()
                        p.ConvertValueToHardwareFormat()
                    End If
                Next
                ' ------------------------------------------------ 
                StepperInterpolate(s)
                ' ------------------------------------------------ 
                ix = 0
                ReDim b(nbytes - 1)
                For Each p As Pin In s.Pins
                    If p.Direction = Pin.Directions.HostToMaster Then
                        p.WriteValueToByteArray(b, ix)
                    End If
                Next
                ' ------------------------------------------------ 
                SendValuesToSlave(s.mSlaveId, b)
                ExchangedFlag = True
            End If
        Next
        ' -------------------------------------------------------- USB to MMF
        For Each s As Slave In Slaves
            Dim nbytes As Int32 = s.GetMasterToHostBytesCount
            If nbytes > 0 Then
                ExchangedFlag = True
                ix = 0
                ReDim b(nbytes - 1)
                If GetValuesFromSlave(s.mSlaveId, b) Then
                    For Each p As Pin In s.Pins
                        If p.Direction = Pin.Directions.MasterToHost Then
                            p.SetValueFromByteArray(b, ix)
                            p.ConvertValueFromHardwareFormat()
                            p.WriteValueToMMF()
                        End If
                    Next
                End If
            End If
        Next
        ' --------------------------------------------------------  do not charge the cpu if not exchanged
        If Not ExchangedFlag Then
            Hid.USB_Write_Read()
        End If
    End Sub


    ' ==========================================================================================
    '   FAST DATA EXCHANGE
    ' ==========================================================================================
    Private Sub FastDataExchange()
        ' -------------------------------------------------------- fast data exchange
        Hid.USB_TxData(0) = Cmd.FAST_DATA_EXCHANGE
        ' -------------------------------------------------------- MMF to USB
        For Each s As Slave In Slaves
            ' ---------------------------------------------------- 
            For Each p As Pin In s.Pins
                If p.Direction = Pin.Directions.HostToMaster Then
                    p.ReadValueFromMMF()
                    p.ConvertValueToHardwareFormat()
                End If
            Next
            ' ---------------------------------------------------- 
            StepperInterpolate(s)
            ' ----------------------------------------------------
            For Each p As Pin In s.Pins
                If p.Direction = Pin.Directions.HostToMaster Then
                    p.WriteValueToUsbBuffer()
                End If
            Next
        Next
        ' -------------------------------------------------------- USB <> Master <> Slaves
        Hid.USB_Write_Read()
        Hid.USB_TxData(0) = Cmd.NOCMD

        ' -------------------------------------------------------- manage errors
        If Hid.USB_RxData(0) = 0 Then
            ' ---------------------------------------------------- USB to MMF
            For Each s As Slave In Slaves
                For Each p As Pin In s.Pins
                    If p.Direction = Pin.Directions.MasterToHost Then
                        p.ReadValueFromUsbBuffer()
                        p.ConvertValueFromHardwareFormat()
                        p.WriteValueToMMF()
                    End If
                Next
            Next
            Execution_OK()
        Else
            Execution_Error("FastDataExchange")
        End If
    End Sub

    '' ==========================================================================================
    ''   STEPPER INTERPOLATE
    '' ==========================================================================================
    'Private Sub StepperInterpolate(ByVal s As Slave)

    '    'Return

    '    Static ratio As Single
    '    Static DestChanged1 As Boolean = False
    '    Static DestChanged2 As Boolean = False
    '    ' --------------------------------------------------------------
    '    Dim p1 As Pin = s.Pins(0)
    '    Dim p1dir As Pin = s.Pins(1)
    '    Dim p2 As Pin = s.Pins(2)
    '    Dim p2dir As Pin = s.Pins(3)
    '    ' --------------------------------------------------------------

    '    If p1.Value_RawUinteger <> p1.Value_RawUinteger_Old Then
    '        p1.Value_RawUinteger_Old = p1.Value_RawUinteger
    '        DestChanged1 = True
    '    End If
    '    If p2.Value_RawUinteger <> p2.Value_RawUinteger_Old Then
    '        p2.Value_RawUinteger_Old = p2.Value_RawUinteger
    '        DestChanged2 = True
    '    End If

    '    If DestChanged1 And DestChanged2 Then
    '        'Beep()
    '        p1.StartPosMM = p1.DestPosMM
    '        p2.StartPosMM = p2.DestPosMM

    '        p1.DestPosMM = p1.Value_Normalized * 1000.0F
    '        p2.DestPosMM = p2.Value_Normalized * 1000.0F

    '        Dim maindist As Single = Math.Abs(p1.DestPosMM - p1.StartPosMM)
    '        If maindist > 0 Then
    '            ratio = Math.Abs((p2.DestPosMM - p2.StartPosMM) / (p1.DestPosMM - p1.StartPosMM))
    '        Else
    '            ratio = 0
    '        End If

    '        'Debug.Print("")
    '        'Debug.Print(p1.StartPosMM.ToString + "  " + p1.DestPosMM.ToString)
    '        'Debug.Print(p2.StartPosMM.ToString + "  " + p2.DestPosMM.ToString)
    '        'Debug.Print(ratio.ToString)

    '        DestChanged1 = False
    '        DestChanged2 = False

    '        'ratio = 0
    '    End If

    '    If ratio <> 0 Then

    '        Dim delta As Single
    '        delta = (p1.DestPosMM - p1.StartPosMM) - p1dir.Value_Normalized * 1000.0F
    '        p2.Value = p2.StartPosMM + delta * ratio
    '        p2.ConvertStepperValuesToHardwareFormat()

    '        If Math.Abs(p2.DestPosMM - p2.Value) < 0.001 Then ratio = 0

    '        'Static counter As Int32
    '        'counter += 1
    '        'If counter > 10 Then
    '        '    counter = 0
    '        '    If Math.Abs(delta) <> 10 Then Debug.Print(delta.ToString + "  " + (p1dir.Value_Normalized * 1000.0F).ToString)
    '        'End If

    '        'Static counter As Int32
    '        'counter += 1
    '        'If counter > 10 Then
    '        'counter = 0
    '        If Math.Abs(delta) <> 10 Then Debug.Print(p2.DestPosMM.ToString + "  " + p2.Value.ToString)
    '        'End If

    '    End If

    'End Sub


    ' ==========================================================================================
    '   STEPPER INTERPOLATE
    ' ==========================================================================================
    Private Sub StepperInterpolate(ByVal s As Slave)

        Return

        'Static ratio As Single
        'Static DestChanged1 As Boolean = False
        'Static DestChanged2 As Boolean = False
        '' --------------------------------------------------------------
        'Dim p1 As Pin = s.Pins(0)
        'Dim p1dir As Pin = s.Pins(1)
        'Dim p2 As Pin = s.Pins(2)
        'Dim p2dir As Pin = s.Pins(3)
        '' --------------------------------------------------------------

        'If p1.Value_RawUinteger <> p1.Value_RawUinteger_Old Then
        '    p1.Value_RawUinteger_Old = p1.Value_RawUinteger
        '    DestChanged1 = True
        'End If
        'If p2.Value_RawUinteger <> p2.Value_RawUinteger_Old Then
        '    p2.Value_RawUinteger_Old = p2.Value_RawUinteger
        '    DestChanged2 = True
        'End If

        'If DestChanged1 And DestChanged2 Then
        '    'Beep()
        '    p1.StartPosMM = p1.DestPosMM
        '    p2.StartPosMM = p2.DestPosMM

        '    p1.DestPosMM = p1.Value_Normalized * 1000.0F
        '    p2.DestPosMM = p2.Value_Normalized * 1000.0F

        '    Dim maindist As Single = Math.Abs(p1.DestPosMM - p1.StartPosMM)
        '    If maindist > 0 Then
        '        ratio = Math.Abs((p2.DestPosMM - p2.StartPosMM) / (p1.DestPosMM - p1.StartPosMM))
        '    Else
        '        ratio = 0
        '    End If

        '    Debug.Print("")
        '    Debug.Print(p1.StartPosMM.ToString + "  " + p1.DestPosMM.ToString)
        '    Debug.Print(p2.StartPosMM.ToString + "  " + p2.DestPosMM.ToString)
        '    Debug.Print(ratio.ToString)

        '    DestChanged1 = False
        '    DestChanged2 = False

        '    'ratio = 0
        'End If

        'If ratio <> 0 Then

        '    Dim delta As Single
        '    delta = (p1.DestPosMM - p1.StartPosMM) - p1dir.Value_Normalized * 1000.0F
        '    p2.Value = p2.StartPosMM + delta * ratio
        '    p2.ConvertStepperValuesToHardwareFormat()

        '    If Math.Abs(p2.DestPosMM - p2.Value) < 0.001 Then
        '        ratio = 0
        '    End If


        '    'Static counter As Int32
        '    'counter += 1
        '    'If counter > 10 Then
        '    '    counter = 0
        '    '    If Math.Abs(delta) <> 10 Then Debug.Print(delta.ToString + "  " + (p1dir.Value_Normalized * 1000.0F).ToString)
        '    'End If

        '    'Static counter As Int32
        '    'counter += 1
        '    'If counter > 10 Then
        '    'counter = 0
        '    'If Math.Abs(delta) <> 10 Then Debug.Print(p2.DestPosMM.ToString + "  " + p2.Value.ToString)
        '    'End If

        'End If

    End Sub

End Class

