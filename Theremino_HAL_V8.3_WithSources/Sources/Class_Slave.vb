
Imports System.Globalization
Imports System.Math
Imports System.Collections.Generic

' ==================================================================================================
'   CLASS SLAVE
' ==================================================================================================
Class Slave

    Enum SlaveTypes As Int32
        Custom = 0
        CapSensor = 1
        Servo = 2
        Generic = 3
        InOut = 4
        MasterPins = 5
        'RmsLogger = 6
        'Sniffer = 7
        MasterPinsV2 = 8
        MasterPinsV4 = 9
        Unknown = 255
    End Enum

    Friend MasterId As Int32
    Friend mSlaveId As Int32
    Friend SlaveType As SlaveTypes
    Friend Pins As List(Of Pin)
    Friend LoadCurrent_mA As Int32

    Friend Property SlaveId() As Int32
        Get
            Return mSlaveId
        End Get
        Set(ByVal value As Int32)
            ' test if mSlaveId ok
            mSlaveId = value
        End Set
    End Property

    Friend Function FirmwareVersion() As String
        Dim version As Int32 = Masters(MasterId).MasterFirmwareVersion
        Return (version \ 10).ToString & "." & (version - (version \ 10) * 10).ToString
    End Function

    Friend Function SlaveTypeString() As String
        Select Case SlaveType
            Case SlaveTypes.Custom : Return "Custom"
            Case SlaveTypes.CapSensor : Return "CapSensor"
            Case SlaveTypes.Servo : Return "Servo"
            Case SlaveTypes.Generic : Return "Generic"
            Case SlaveTypes.InOut : Return "InOut"
            Case SlaveTypes.MasterPins : Return "MasterPins"
            Case SlaveTypes.MasterPinsV2 : Return "MasterPins"
            Case SlaveTypes.MasterPinsV4 : Return "MasterPins"
            Case SlaveTypes.Unknown : Return "Unknown"
            Case Else : Return "Unknown"
        End Select
    End Function

    Friend Shared Function StringToSlaveType(ByVal s As String) As SlaveTypes
        Select Case s.Trim.ToLower
            Case "custom" : Return SlaveTypes.Custom
            Case "capsensor" : Return SlaveTypes.CapSensor
            Case "servo" : Return SlaveTypes.Servo
            Case "generic" : Return SlaveTypes.Generic
            Case "inout" : Return SlaveTypes.InOut
            Case "masterpins" : Return SlaveTypes.MasterPins
            Case Else : Return SlaveTypes.Unknown
        End Select
    End Function

    Friend Sub New(ByVal _slavetype As SlaveTypes, ByVal _masterid As Int32, ByVal _slaveid As Int32)
        SlaveType = _slavetype
        MasterId = _masterid
        SlaveId = _slaveid
        LoadCurrent_mA = 0
    End Sub

    Friend Function GetHostToMasterBytesCount() As Int32
        GetHostToMasterBytesCount = 0
        For Each p As Pin In Pins
            If p.Direction = Pin.Directions.HostToMaster Then
                GetHostToMasterBytesCount += p.UsbBytesCount
            End If
        Next
    End Function

    Friend Function GetMasterToHostBytesCount() As Int32
        GetMasterToHostBytesCount = 0
        For Each p As Pin In Pins
            If p.Direction = Pin.Directions.MasterToHost Then
                GetMasterToHostBytesCount += p.UsbBytesCount
            End If
        Next
    End Function

    Friend Function CalibrationNeeded() As Boolean
        For Each p As Pin In Pins
            Select Case p.GetPinType()
                Case Pin.PinTypes.CAP_SENSOR
                    If p.Area_cmq > 0 Then
                        Return True
                    End If
                Case Pin.PinTypes.CAP_8, Pin.PinTypes.CAP_16
                    If p.MinVariation > 0 Then
                        Return True
                    End If
            End Select
        Next
        Return False
    End Function

    Friend Overridable Sub Calibrate()
        For Each p As Pin In Pins
            p.Calibrate()
        Next
    End Sub

    Friend Overridable Sub CalibrateZero()
        For Each p As Pin In Pins
            p.CalibrateZero()
        Next
    End Sub

    Friend Overridable Function Get_CapSensor_Or_Cap_Delta() As UInt32
        Dim maxdelta As UInt32 = 0
        For Each p As Pin In Pins
            Select Case p.GetPinType()
                Case Pin.PinTypes.CAP_8, Pin.PinTypes.CAP_16
                    Dim n As UInt32 = AbsUint32Difference(p.Value_Uinteger_Max, p.Value_Uinteger_Min)
                    If n > maxdelta Then maxdelta = n
                    p.ResetPosMinMax()
            End Select
        Next
        Return maxdelta
    End Function

    Friend Overridable Sub ConfigurePin(ByVal npin As Int32, ByVal pinType As Pin.PinTypes)
        Select Case SlaveType
            Case SlaveTypes.Servo, SlaveTypes.Generic, SlaveTypes.InOut

                Select Case pinType

                    Case Pin.PinTypes.UNUSED, Pin.PinTypes.DIG_OUT, _
                                                Pin.PinTypes.PWM_8, _
                                                Pin.PinTypes.PWM_16, _
                                                Pin.PinTypes.SERVO_8, _
                                                Pin.PinTypes.SERVO_16, _
                                                Pin.PinTypes.DIG_IN, _
                                                Pin.PinTypes.DIG_IN_PU, _
                                                Pin.PinTypes.COUNTER, _
                                                Pin.PinTypes.COUNTER_PU
                        Pins(npin).SetPinType(pinType)

                    Case Pin.PinTypes.ADC_8, Pin.PinTypes.ADC_16, _
                         Pin.PinTypes.CAP_8, Pin.PinTypes.CAP_16, _
                         Pin.PinTypes.RES_8, Pin.PinTypes.RES_16
                        If npin < 8 Then Pins(npin).SetPinType(pinType)

                    Case Pin.PinTypes.FAST_COUNTER, Pin.PinTypes.FAST_COUNTER_PU
                        If npin = 7 Then Pins(npin).SetPinType(pinType)

                    Case Pin.PinTypes.USOUND_SENSOR, Pin.PinTypes.PERIOD, Pin.PinTypes.PERIOD_PU
                        If npin = 8 Then Pins(npin).SetPinType(pinType)
                End Select
        End Select
    End Sub

    Friend Overridable Sub FillTypeCombo(ByVal cmb As ComboBox, ByRef p As Pin)
        Select Case SlaveType

            Case SlaveTypes.Servo, SlaveTypes.Generic, SlaveTypes.InOut
                cmb.Items.Clear()
                '
                cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.UNUSED))
                '
                cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.DIG_OUT))
                cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PWM_8))
                cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PWM_16))
                cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.SERVO_8))
                cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.SERVO_16))
                '
                cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.DIG_IN))
                cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.DIG_IN_PU))
                '
                If p.PinId < 8 Then
                    cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ADC_8))
                    cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ADC_16))
                    cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.CAP_8))
                    cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.CAP_16))
                    cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.RES_8))
                    cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.RES_16))
                End If
                '
                cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.COUNTER))
                cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.COUNTER_PU))

                If p.PinId = 7 Then
                    cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.FAST_COUNTER))
                    cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.FAST_COUNTER_PU))
                End If

                If p.PinId = 8 Then
                    cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PERIOD))
                    cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PERIOD_PU))
                    cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.USOUND_SENSOR))
                End If

            Case Else
                cmb.Items.Clear()
                cmb.Items.Add(Pin.PinTypeToString(p.GetPinType))

        End Select
    End Sub

    Friend Function ValidLinkedToPrevious(ByVal pinSelected As Pin) As Boolean
        If Not pinSelected.GetPinType() = Pin.PinTypes.STEPPER Then Return False
        If pinSelected.PinId < 2 Then Return False
        If Pins(pinSelected.PinId - 2).GetPinType() <> Pin.PinTypes.STEPPER Then Return False
        Return False 'True  ' <<<<< TODO  
    End Function

End Class


' ==================================================================================================
' SUBCLASS - Slave_CapSensor
' ==================================================================================================
Class Slave_CapSensor : Inherits Slave

    Friend Sub New(ByVal _masterid As Int32, ByVal _slaveid As Int32)
        MyBase.new(SlaveTypes.CapSensor, _masterid, _slaveid)
        InitDefaultPins()
        LoadCurrent_mA = 12
    End Sub

    Private Sub InitDefaultPins()
        Pins = New List(Of Pin)
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 0))
    End Sub

    Friend Overrides Function Get_CapSensor_Or_Cap_Delta() As UInt32
        With Pins(0)
            Dim n As UInt32 = AbsUint32Difference(.Value_Uinteger_Max, .Value_Uinteger_Min)
            If n < 0 Then n = 0
            If n > 400000 Then n = 0
            Get_CapSensor_Or_Cap_Delta = n
            .ResetPosMinMax()
        End With
    End Function

    Friend Overrides Sub ConfigurePin(ByVal npin As Int32, ByVal pinType As Pin.PinTypes)
        Select Case pinType
            Case Pin.PinTypes.UNUSED, Pin.PinTypes.CAP_SENSOR
                Pins(npin).SetPinType(pinType)
        End Select
    End Sub

    Friend Overrides Sub FillTypeCombo(ByVal cmb As ComboBox, ByRef p As Pin)
        cmb.Items.Clear()
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.UNUSED))
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.CAP_SENSOR))
    End Sub

End Class


' ==================================================================================================
'   SUBCLASS - Slave_Servo
' ==================================================================================================
Class Slave_Servo : Inherits Slave

    Friend Sub New(ByVal _masterid As Int32, ByVal _slaveid As Int32)
        MyBase.new(SlaveTypes.Servo, _masterid, _slaveid)
        InitDefaultPins()
        LoadCurrent_mA = 80
    End Sub

    Private Sub InitDefaultPins()
        Pins = New List(Of Pin)
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 0))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 1))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 2))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 3))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 4))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 5))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 6))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 7))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 8))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 9))
    End Sub

End Class


' ==================================================================================================
'   SUBCLASS - Slave_Generic
' ==================================================================================================
Class Slave_Generic : Inherits Slave

    Friend Sub New(ByVal _masterid As Int32, ByVal _slaveid As Int32)
        MyBase.new(SlaveTypes.Generic, _masterid, _slaveid)
        InitDefaultPins()
        LoadCurrent_mA = 80
    End Sub

    Private Sub InitDefaultPins()
        Pins = New List(Of Pin)
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 0))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 1))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 2))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 3))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 4))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 5))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 6))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 7))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 8))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 9))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 10))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 11))
    End Sub

End Class


' ==================================================================================================
'   SUBCLASS - Slave_InOut
' ==================================================================================================
Class Slave_InOut : Inherits Slave

    Friend Sub New(ByVal _masterid As Int32, ByVal _slaveid As Int32)
        MyBase.new(SlaveTypes.InOut, _masterid, _slaveid)
        InitDefaultPins()
        LoadCurrent_mA = 80
    End Sub

    Private Sub InitDefaultPins()
        Pins = New List(Of Pin)
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 0))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 1))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 2))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 3))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 4))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 5))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 6))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 7))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 8))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 9))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 10))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 11))
    End Sub

End Class


' ==================================================================================================
'   SUBCLASS - Slave_MasterPins
' ==================================================================================================
Class Slave_MasterPins : Inherits Slave

    Friend Sub New(ByVal _masterid As Int32, ByVal _slaveid As Int32)
        MyBase.new(SlaveTypes.MasterPins, _masterid, _slaveid)
        InitDefaultPins()
        LoadCurrent_mA = 10
    End Sub

    Private Sub InitDefaultPins()
        Pins = New List(Of Pin)
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 0))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 1))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 2))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 3))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 4))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 5))
    End Sub

    Friend Overrides Sub ConfigurePin(ByVal npin As Int32, ByVal pinType As Pin.PinTypes)
        Select Case pinType

            Case Pin.PinTypes.UNUSED, Pin.PinTypes.DIG_OUT, Pin.PinTypes.PWM_8, _
                                                            Pin.PinTypes.PWM_16, _
                                                            Pin.PinTypes.SERVO_8, _
                                                            Pin.PinTypes.SERVO_16, _
                                                            Pin.PinTypes.DIG_IN, _
                                                            Pin.PinTypes.DIG_IN_PU, _
                                                            Pin.PinTypes.ADC_8, _
                                                            Pin.PinTypes.ADC_16, _
                                                            Pin.PinTypes.CAP_8, _
                                                            Pin.PinTypes.CAP_16, _
                                                            Pin.PinTypes.RES_8, _
                                                            Pin.PinTypes.RES_16, _
                                                            Pin.PinTypes.COUNTER, _
                                                            Pin.PinTypes.COUNTER_PU
                Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.FAST_COUNTER, Pin.PinTypes.FAST_COUNTER_PU
                If Not AlreadyUsed_FastCounter(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.USOUND_SENSOR, Pin.PinTypes.PERIOD, Pin.PinTypes.PERIOD_PU
                If Not AlreadyUsed_PeriodCounter(Pins(npin)) Then Pins(npin).SetPinType(pinType)
        End Select
    End Sub

    Friend Overrides Sub FillTypeCombo(ByVal cmb As ComboBox, ByRef p As Pin)
        cmb.Items.Clear()
        '
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.UNUSED))
        '
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.DIG_OUT))
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PWM_8))
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PWM_16))
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.SERVO_8))
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.SERVO_16))
        '
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.DIG_IN))
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.DIG_IN_PU))
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ADC_8))
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ADC_16))
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.CAP_8))
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.CAP_16))
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.RES_8))
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.RES_16))
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.COUNTER))
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.COUNTER_PU))

        If Not AlreadyUsed_FastCounter(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.FAST_COUNTER))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.FAST_COUNTER_PU))
        End If

        If Not AlreadyUsed_PeriodCounter(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PERIOD))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PERIOD_PU))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.USOUND_SENSOR))
        End If
    End Sub

    Private Function AlreadyUsed_FastCounter(ByVal pinSelected As Pin) As Boolean
        For Each p As Pin In Pins
            If p Is pinSelected Then Continue For
            If p.GetPinType = Pin.PinTypes.FAST_COUNTER OrElse p.GetPinType = Pin.PinTypes.FAST_COUNTER_PU Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function AlreadyUsed_PeriodCounter(ByVal pinSelected As Pin) As Boolean
        For Each p As Pin In Pins
            If p Is pinSelected Then Continue For
            If p.GetPinType = Pin.PinTypes.PERIOD OrElse p.GetPinType = Pin.PinTypes.PERIOD_PU _
                                                  OrElse p.GetPinType = Pin.PinTypes.USOUND_SENSOR Then
                Return True
            End If
        Next
        Return False
    End Function
End Class


' ==================================================================================================
'   SUBCLASS - Slave_MasterPinsV2
' ==================================================================================================
Class Slave_MasterPinsV2 : Inherits Slave

    Friend Sub New(ByVal _masterid As Int32, ByVal _slaveid As Int32)
        MyBase.new(SlaveTypes.MasterPinsV2, _masterid, _slaveid)
        InitDefaultPins()
        LoadCurrent_mA = 10
    End Sub

    Private Sub InitDefaultPins()
        Pins = New List(Of Pin)
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 0))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 1))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 2))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 3))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 4))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 5))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 6))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 7))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 8))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 9))
    End Sub

    Friend Overrides Sub ConfigurePin(ByVal npin As Int32, ByVal pinType As Pin.PinTypes)
        Select Case pinType
            Case Pin.PinTypes.UNUSED
                Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.DIG_OUT, _
                 Pin.PinTypes.PWM_8, _
                 Pin.PinTypes.PWM_16, _
                 Pin.PinTypes.SERVO_8, _
                 Pin.PinTypes.SERVO_16, _
                 Pin.PinTypes.DIG_IN, _
                 Pin.PinTypes.DIG_IN_PU, _
                 Pin.PinTypes.COUNTER, _
                 Pin.PinTypes.COUNTER_PU, _
                 Pin.PinTypes.SLOW_PERIOD, _
                 Pin.PinTypes.SLOW_PERIOD_PU
                If ValidGenericPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.ADC_8, _
                 Pin.PinTypes.ADC_16, _
                 Pin.PinTypes.CAP_8, _
                 Pin.PinTypes.CAP_16, _
                 Pin.PinTypes.RES_8, _
                 Pin.PinTypes.RES_16
                If ValidAdcPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.STEPPER
                If ValidStepperPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.STEPPER_DIR
                If ValidStepperDirPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.PWM_FAST
                If ValidPwmFastPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.FAST_COUNTER, Pin.PinTypes.FAST_COUNTER_PU
                If ValidFastCounterPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.USOUND_SENSOR, Pin.PinTypes.PERIOD, Pin.PinTypes.PERIOD_PU
                If ValidPeriodCounterPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)
        End Select
    End Sub

    Friend Overrides Sub FillTypeCombo(ByVal cmb As ComboBox, ByRef p As Pin)
        cmb.Items.Clear()
        '
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.UNUSED))
        '
        If ValidGenericPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.DIG_OUT))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PWM_8))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PWM_16))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.SERVO_8))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.SERVO_16))
        End If

        If ValidStepperPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.STEPPER))
        End If
        If ValidStepperDirPin(p) Then
            cmb.Items.Clear()
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.STEPPER_DIR))
        End If
        If ValidPwmFastPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PWM_FAST))
        End If

        If ValidGenericPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.DIG_IN))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.DIG_IN_PU))
        End If

        If ValidAdcPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ADC_8))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ADC_16))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.CAP_8))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.CAP_16))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.RES_8))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.RES_16))
        End If

        If ValidGenericPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.COUNTER))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.COUNTER_PU))
        End If

        If ValidFastCounterPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.FAST_COUNTER))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.FAST_COUNTER_PU))
        End If

        If ValidPeriodCounterPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PERIOD))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PERIOD_PU))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.USOUND_SENSOR))
        End If

        If ValidGenericPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.SLOW_PERIOD))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.SLOW_PERIOD_PU))
        End If
    End Sub

    Private Function ValidGenericPin(ByVal pinSelected As Pin) As Boolean
        If pinSelected.PinId > 0 Then
            If Pins(pinSelected.PinId - 1).GetPinType() = Pin.PinTypes.STEPPER Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Function ValidAdcPin(ByVal pinSelected As Pin) As Boolean
        If Not ValidGenericPin(pinSelected) Then Return False
        If pinSelected.PinId > 5 Then Return False
        Return True
    End Function

    Private Function ValidStepperPin(ByVal pinSelected As Pin) As Boolean
        If CountUsedPwmPins(pinSelected) > 4 Then Return False
        Select Case pinSelected.PinId
            Case 0, 2, 4, 6, 8 : Return True
        End Select
        Return False
    End Function

    Private Function ValidStepperDirPin(ByVal pinSelected As Pin) As Boolean
        If pinSelected.PinId < 1 Then Return False
        If Pins(pinSelected.PinId - 1).GetPinType() <> Pin.PinTypes.STEPPER Then Return False
        Return True
    End Function

    Private Function ValidPwmFastPin(ByVal pinSelected As Pin) As Boolean
        If Not ValidGenericPin(pinSelected) Then Return False
        If CountUsedPwmPins(pinSelected) > 4 Then Return False
        Return True
    End Function

    Private Function ValidFastCounterPin(ByVal pinSelected As Pin) As Boolean
        If Not ValidGenericPin(pinSelected) Then Return False
        For Each p As Pin In Pins
            If p Is pinSelected Then Continue For
            If p.GetPinType = Pin.PinTypes.FAST_COUNTER OrElse p.GetPinType = Pin.PinTypes.FAST_COUNTER_PU Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function ValidPeriodCounterPin(ByVal pinSelected As Pin) As Boolean
        If Not ValidGenericPin(pinSelected) Then Return False
        For Each p As Pin In Pins
            If p Is pinSelected Then Continue For
            If p.GetPinType = Pin.PinTypes.PERIOD OrElse p.GetPinType = Pin.PinTypes.PERIOD_PU _
                                                  OrElse p.GetPinType = Pin.PinTypes.USOUND_SENSOR Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function CountUsedPwmPins(ByVal pinSelected As Pin) As Int32
        Dim n As Int32 = 0
        For Each p As Pin In Pins
            If Object.ReferenceEquals(p, pinSelected) Then Continue For
            If p.GetPinType() = Pin.PinTypes.STEPPER OrElse p.GetPinType() = Pin.PinTypes.PWM_FAST Then
                n += 1
            End If
        Next
        Return n
    End Function

End Class




' ==================================================================================================
'   SUBCLASS - Slave_MasterPinsV4
' ==================================================================================================
Class Slave_MasterPinsV4 : Inherits Slave

    Friend Sub New(ByVal _masterid As Int32, ByVal _slaveid As Int32)
        MyBase.new(SlaveTypes.MasterPinsV4, _masterid, _slaveid)
        InitDefaultPins()
        LoadCurrent_mA = 10
    End Sub

    Private Sub InitDefaultPins()
        Pins = New List(Of Pin)
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 0))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 1))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 2))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 3))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 4))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 5))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 6))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 7))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 8))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 9))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 10))
        Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 11))
        ' ------------------------------------------------------------ Adc24 pins
        If Masters(MasterId).MasterFirmwareVersion >= 50 Then
            For i As Int32 = 0 To 15
                Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, 12 + i))
            Next
        End If
    End Sub

    Friend Overrides Sub ConfigurePin(ByVal npin As Int32, ByVal pinType As Pin.PinTypes)
        Select Case pinType
            Case Pin.PinTypes.UNUSED
                Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.DIG_OUT, _
                 Pin.PinTypes.PWM_8, _
                 Pin.PinTypes.PWM_16, _
                 Pin.PinTypes.SERVO_8, _
                 Pin.PinTypes.SERVO_16, _
                 Pin.PinTypes.DIG_IN, _
                 Pin.PinTypes.DIG_IN_PU, _
                 Pin.PinTypes.COUNTER, _
                 Pin.PinTypes.COUNTER_PU, _
                 Pin.PinTypes.SLOW_PERIOD, _
                 Pin.PinTypes.SLOW_PERIOD_PU
                If ValidGenericPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.ADC_8, _
                 Pin.PinTypes.ADC_16, _
                 Pin.PinTypes.CAP_8, _
                 Pin.PinTypes.CAP_16, _
                 Pin.PinTypes.RES_8, _
                 Pin.PinTypes.RES_16
                If ValidAdcPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.ADC_24
                If ValidAdc24Pin(Pins(npin)) Then Pins(npin).SetPinType(pinType)
            Case Pin.PinTypes.ADC_24_DIN
                If ValidAdc24DinPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)
            Case Pin.PinTypes.ADC_24_DOUT
                If ValidAdc24DoutPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)
            Case Pin.PinTypes.ADC_24_CH
                If ValidAdc24Channel_Pin(Pins(npin)) Then Pins(npin).SetPinType(pinType)
            Case Pin.PinTypes.ADC_24_CH_B
                If ValidAdc24ChannelB_Pin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.STEPPER
                If ValidStepperPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.STEPPER_DIR
                If ValidStepperDirPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.PWM_FAST
                If ValidPwmFastPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.FAST_COUNTER, Pin.PinTypes.FAST_COUNTER_PU
                If ValidFastCounterPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.USOUND_SENSOR, Pin.PinTypes.PERIOD, Pin.PinTypes.PERIOD_PU
                If ValidPeriodCounterPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.ENCODER_A, Pin.PinTypes.ENCODER_A_PU
                If ValidEncoderAPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)

            Case Pin.PinTypes.ENCODER_B, Pin.PinTypes.ENCODER_B_PU
                If ValidEncoderBPin(Pins(npin)) Then Pins(npin).SetPinType(pinType)
        End Select
    End Sub

    Friend Overrides Sub FillTypeCombo(ByVal cmb As ComboBox, ByRef p As Pin)
        cmb.Items.Clear()
        '
        cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.UNUSED))
        '
        If ValidGenericPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.DIG_OUT))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PWM_8))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PWM_16))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.SERVO_8))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.SERVO_16))
        End If

        If ValidStepperPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.STEPPER))
        End If
        If ValidStepperDirPin(p) Then
            cmb.Items.Clear()
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.STEPPER_DIR))
        End If
        If ValidPwmFastPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PWM_FAST))
        End If

        If ValidGenericPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.DIG_IN))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.DIG_IN_PU))
        End If

        If ValidAdcPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.CAP_8))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.CAP_16))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.RES_8))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.RES_16))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ADC_8))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ADC_16))
        End If

        If ValidAdc24Pin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ADC_24))
        End If
        If ValidAdc24DinPin(p) Then
            cmb.Items.Clear()
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ADC_24_DIN))
        End If
        If ValidAdc24DoutPin(p) Then
            cmb.Items.Clear()
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ADC_24_DOUT))
        End If
        If ValidAdc24Channel_Pin_ForComboList(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ADC_24_CH))
        End If
        If ValidAdc24ChannelB_Pin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ADC_24_CH_B))
        End If

        If ValidGenericPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.COUNTER))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.COUNTER_PU))
        End If

        If ValidFastCounterPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.FAST_COUNTER))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.FAST_COUNTER_PU))
        End If

        If ValidPeriodCounterPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PERIOD))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.PERIOD_PU))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.USOUND_SENSOR))
        End If

        If ValidEncoderAPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ENCODER_A))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ENCODER_A_PU))
        End If
        If ValidEncoderBPin(p) Then
            cmb.Items.Clear()
            If Pins(p.PinId - 1).GetPinType = Pin.PinTypes.ENCODER_A Then
                cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ENCODER_B))
            Else
                cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.ENCODER_B_PU))
            End If
        End If

        If ValidGenericPin(p) Then
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.SLOW_PERIOD))
            cmb.Items.Add(Pin.PinTypeToString(Pin.PinTypes.SLOW_PERIOD_PU))
        End If
    End Sub

    Private Function ValidGenericPin(ByVal pinSelected As Pin) As Boolean
        If pinSelected.PinId >= 12 Then Return False
        If pinSelected.PinId > 0 Then
            If Pins(pinSelected.PinId - 1).GetPinType() = Pin.PinTypes.STEPPER Then
                Return False
            End If
            If Pins(pinSelected.PinId - 1).GetPinType() = Pin.PinTypes.ENCODER_A Then
                Return False
            End If
            If Pins(pinSelected.PinId - 1).GetPinType() = Pin.PinTypes.ENCODER_A_PU Then
                Return False
            End If
        End If
        If pinSelected.PinId = 7 AndAlso Pins(6).GetPinType() = Pin.PinTypes.ADC_24 Then Return False
        If pinSelected.PinId = 8 AndAlso Pins(6).GetPinType() = Pin.PinTypes.ADC_24 Then Return False
        Return True
    End Function

    Private Function ValidAdcPin(ByVal pinSelected As Pin) As Boolean
        If Not ValidGenericPin(pinSelected) Then Return False
        If pinSelected.PinId > 5 Then Return False
        Return True
    End Function

    Private Function ValidStepperPin(ByVal pinSelected As Pin) As Boolean
        If CountUsedPwmPins(pinSelected) > 4 Then Return False
        If pinSelected.PinId = 8 AndAlso Pins(6).GetPinType() = Pin.PinTypes.ADC_24 Then Return False
        Select Case pinSelected.PinId
            Case 0, 2, 4, 6, 8 : Return True
        End Select
        Return False
    End Function

    Private Function ValidStepperDirPin(ByVal pinSelected As Pin) As Boolean
        If pinSelected.PinId < 1 Then Return False
        If Pins(pinSelected.PinId - 1).GetPinType() <> Pin.PinTypes.STEPPER Then Return False
        If pinSelected.PinId = 9 AndAlso Pins(6).GetPinType() = Pin.PinTypes.ADC_24 Then Return False
        Return True
    End Function

    Private Function ValidPwmFastPin(ByVal pinSelected As Pin) As Boolean
        If pinSelected.PinId > 9 Then Return False
        If Not ValidGenericPin(pinSelected) Then Return False
        If CountUsedPwmPins(pinSelected) > 4 Then Return False
        Return True
    End Function

    Private Function ValidFastCounterPin(ByVal pinSelected As Pin) As Boolean
        If pinSelected.PinId > 9 Then Return False
        If Not ValidGenericPin(pinSelected) Then Return False
        For Each p As Pin In Pins
            If p Is pinSelected Then Continue For
            If p.GetPinType = Pin.PinTypes.FAST_COUNTER OrElse p.GetPinType = Pin.PinTypes.FAST_COUNTER_PU Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function ValidPeriodCounterPin(ByVal pinSelected As Pin) As Boolean
        If pinSelected.PinId > 9 Then Return False
        If Not ValidGenericPin(pinSelected) Then Return False
        For Each p As Pin In Pins
            If p Is pinSelected Then Continue For
            If p.GetPinType = Pin.PinTypes.PERIOD OrElse p.GetPinType = Pin.PinTypes.PERIOD_PU _
                                                  OrElse p.GetPinType = Pin.PinTypes.USOUND_SENSOR Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function ValidAdc24Pin(ByVal pinSelected As Pin) As Boolean
        If Masters(MasterId).MasterFirmwareVersion < 41 Then Return False
        If Not ValidGenericPin(pinSelected) Then Return False
        If pinSelected.PinId <> 6 Then Return False
        Return True
    End Function

    Private Function ValidAdc24DinPin(ByVal pinSelected As Pin) As Boolean
        If pinSelected.PinId <> 7 Then Return False
        If Pins(6).GetPinType() <> Pin.PinTypes.ADC_24 Then Return False
        Return True
    End Function

    Private Function ValidAdc24DoutPin(ByVal pinSelected As Pin) As Boolean
        If pinSelected.PinId <> 8 Then Return False
        If Pins(6).GetPinType() <> Pin.PinTypes.ADC_24 Then Return False
        Return True
    End Function

    Private Function ValidAdc24Channel_Pin(ByVal pinSelected As Pin) As Boolean
        If Pins(6).GetPinType() <> Pin.PinTypes.ADC_24 Then Return False
        If pinSelected.PinId < 12 Then Return False
        Return True
    End Function

    Private Function ValidAdc24Channel_Pin_ForComboList(ByVal pinSelected As Pin) As Boolean
        If Pins(6).GetPinType() <> Pin.PinTypes.ADC_24 Then Return False
        If pinSelected.PinId < 12 Then Return False
        If pinSelected.PinId Mod 2 = 1 Then
            If pinSelected.Adc24ChType = 0 Then Return False ' if differential
        End If
        Return True
    End Function

    Private Function ValidAdc24ChannelB_Pin(ByVal pinSelected As Pin) As Boolean
        If Pins(6).GetPinType() <> Pin.PinTypes.ADC_24 Then Return False
        If pinSelected.PinId < 12 Then Return False
        If pinSelected.PinId Mod 2 = 0 Then Return False
        If pinSelected.Adc24ChType <> 0 Then Return False ' if not differential
        Return True
    End Function

    Private Function ValidEncoderAPin(ByVal pinSelected As Pin) As Boolean
        If pinSelected.PinId > 10 Then Return False
        Dim pt As Pin.PinTypes = Pins(pinSelected.PinId + 1).GetPinType()
        If pt = Pin.PinTypes.STEPPER Then Return False
        If pt = Pin.PinTypes.ENCODER_A Then Return False
        If pt = Pin.PinTypes.ENCODER_A_PU Then Return False
        If pinSelected.PinId > 0 Then
            pt = Pins(pinSelected.PinId - 1).GetPinType()
            If pt = Pin.PinTypes.STEPPER Then Return False
            If pt = Pin.PinTypes.ENCODER_A Then Return False
            If pt = Pin.PinTypes.ENCODER_A_PU Then Return False
        End If
        If pinSelected.PinId = 7 OrElse pinSelected.PinId = 8 Then
            pt = Pins(6).GetPinType()
            If pt = Pin.PinTypes.ADC_24 Then Return False
        End If
        Return True
    End Function

    Private Function ValidEncoderBPin(ByVal pinSelected As Pin) As Boolean
        If pinSelected.PinId < 1 Then Return False
        Dim pt As Pin.PinTypes = Pins(pinSelected.PinId - 1).GetPinType()
        If pt <> Pin.PinTypes.ENCODER_A And _
           pt <> Pin.PinTypes.ENCODER_A_PU Then Return False
        If pinSelected.PinId = 9 AndAlso Pins(6).GetPinType() = Pin.PinTypes.ADC_24 Then Return False
        Return True
    End Function

    Private Function CountUsedPwmPins(ByVal pinSelected As Pin) As Int32
        Dim n As Int32 = 0
        For Each p As Pin In Pins
            If Object.ReferenceEquals(p, pinSelected) Then Continue For
            If p.GetPinType() = Pin.PinTypes.STEPPER OrElse p.GetPinType() = Pin.PinTypes.PWM_FAST Then
                n += 1
            End If
        Next
        Return n
    End Function

    Friend Sub Adc24_AddRemovePins()
        If Pins(6).GetPinType = Pin.PinTypes.ADC_24 Then
            '
            Dim delta As Int32 = Pins(6).Adc24Npins + 12 - Pins.Count
            ' ------------------------------------ remove redundant pins
            If delta < 0 Then
                For i As Int32 = 1 To -delta
                    Pins.Remove(Pins(Pins.Count - 1))
                Next
            End If
            ' ------------------------------------ add lacking pins
            If delta > 0 Then
                For i As Int32 = 1 To delta
                    Pins.Add(New Pin(Pin.PinTypes.UNUSED, MasterId, mSlaveId, Pins.Count))
                    Dim p As Pin = Pins(Pins.Count - 1)
                    p.Slot = MasterId * 100 + p.PinId + 1
                Next
            End If
        Else
            For i As Int32 = 1 To Pins.Count - 12
                Pins.Remove(Pins(Pins.Count - 1))
            Next
        End If
    End Sub

    ' ==================================================================================================
    '   ADC_24 SEND CONFIGURATIONS and START
    ' ==================================================================================================
    'Private Adc24SpsArray() As Int32 = New Int32() {10, 20, 50, 100, 200, 500, 1000, 2000, _
    '                                                3200, 3840, 4800, 6400, 9600, 19200}

    'Adc24Fsck_KHz = 31,36,42,50,63,83,125,143,167,200,250,333,500,
    '                571,667,800,1000,1333,2000,2286,2667,3200,4000

    Friend Sub Adc24ConfigAndStart()
        Dim Sps As Int32                       ' Samples per second
        Dim Fsck_KHz As Int32                  ' SPI clock (comm from PIC to ADC24)
        Dim MultipleSetups As Boolean
        Dim FiltersSingleCycle As Boolean

        Dim Adc24PreFilterType As Int32        ' Pre filter type 0b000 to 0b111 
        Dim Adc24PostFilterType As Int32       ' Post filter type 0b000 to 0b111 
        Dim Adc24ActiveChannels As Int32       ' The channel is active (bit0 = ch0)
        Dim Adc24BiasedChannels As Int32       ' Channels biased with 1.65 Volt (vcc / 2) 
        Dim Adc24DiffChannels As Int32         ' Differential / SingleEnded channels
        Dim Adc24PseudoChannels As Int32       ' Pseudo channels referred to Input 15
        Dim Adc24ChannelsGains As Int32        ' Gain 1 to 128 (low 3 bits are for channel 0)

        Sps = Pins(6).Adc24Sps

        ' --------------------------------------------------------------------------
        ' at 19200 SPS each sample = 52 uS
        ' at 1000 KHz
        ' 5 bytes = 40 bit = 40 uS + 10 uS(worst case interrupt latency) = 50 uS
        ' --------------------------------------------------------------------------
        ' Select the appropriate Fsck from Sps
        ' valid sps are: 19200 9600 4800 3840 3200 2742.8 2400 2133.3 1920 .... 10
        If Sps > 9600 Then
            Fsck_KHz = 1000
        ElseIf Sps > 4800 Then
            Fsck_KHz = 500
        Else
            Fsck_KHz = 250
        End If
        ' --------------------------------------------------------------------------
        ' Override
        'Fsck_KHz = 10
        ' --------------------------------------------------------------------------
        ' Valid Fsck (KHz)
        ' 31,36,42,50,63,83,125,143,167,200,250,333,500,571,667,800,1000,1333,2000,2286,2667,3200,4000
        ' --------------------------------------------------------------------------

        MultipleSetups = True               ' Every channel's couple uses a different setup
        FiltersSingleCycle = False          ' All filters not using SingleCycle 

        ' ----------- FILTER LIST
        ' Max Speed
        ' Fast
        ' Medium
        ' Slow
        ' Post Max
        ' Post Fast 
        ' Post Medium
        ' Post Slow

        Select Case Pins(6).Adc24Filter
            Case 0 ' Sync3
                Adc24PreFilterType = Convert.ToInt32("010", 2)
                Adc24PostFilterType = Convert.ToInt32("011", 2) ' unused
            Case 1 ' Sync4
                Adc24PreFilterType = Convert.ToInt32("000", 2)
                Adc24PostFilterType = Convert.ToInt32("011", 2) ' unused
            Case 2 ' Sync3 FastSettling
                Adc24PreFilterType = Convert.ToInt32("101", 2)
                Adc24PostFilterType = Convert.ToInt32("011", 2) ' unused
            Case 3 ' Sync4 FastSettling
                Adc24PreFilterType = Convert.ToInt32("100", 2)
                Adc24PostFilterType = Convert.ToInt32("011", 2) ' unused
            Case 4 ' Post1
                Adc24PreFilterType = Convert.ToInt32("111", 2)
                Adc24PostFilterType = Convert.ToInt32("010", 2)
            Case 5 ' Post2
                Adc24PreFilterType = Convert.ToInt32("111", 2)
                Adc24PostFilterType = Convert.ToInt32("011", 2)
            Case 6 ' Post3
                Adc24PreFilterType = Convert.ToInt32("111", 2)
                Adc24PostFilterType = Convert.ToInt32("101", 2)
            Case 7 ' Post4
                Adc24PreFilterType = Convert.ToInt32("111", 2)
                Adc24PostFilterType = Convert.ToInt32("110", 2)
        End Select

        ' ------------------------------------------------------------- FILL MASKS
        Adc24ActiveChannels = 0
        Adc24DiffChannels = 0
        Adc24PseudoChannels = 0
        Adc24ChannelsGains = 0
        Adc24BiasedChannels = 0
        Dim pow2 As Int32 = 1
        Dim pow8 As Int32 = 1
        Dim p As Pin
        For i As Int32 = 0 To 15
            If i + 12 >= Pins.Count Then Exit For
            p = Pins(i + 12)
            If p.GetPinType = Pin.PinTypes.ADC_24_CH OrElse _
               p.GetPinType = Pin.PinTypes.ADC_24_CH_B Then
                ' ----------------------------------------------------- If differential couple, set only first pin
                If p.PinId Mod 2 = 0 Or p.Adc24ChType <> 0 Then
                    Adc24ActiveChannels += pow2
                End If
                ' ----------------------------------------------------- Pseudo
                If p.Adc24ChType = 0 Then Adc24DiffChannels += pow2
                If p.Adc24ChType = 1 Then Adc24PseudoChannels += pow2
                ' ----------------------------------------------------- Gains
                If p.GetPinType <> Pin.PinTypes.UNUSED Then
                    Adc24ChannelsGains = Adc24ChannelsGains Or (p.Adc24ChGain * pow8)
                End If
                ' ----------------------------------------------------- Biased
                If p.Adc24ChBias Then Adc24BiasedChannels += pow2
            End If
            pow2 *= 2
            If p.PinId Mod 2 = 1 Then
                pow8 *= 8
            End If
        Next

        If Adc24PseudoChannels <> 0 Then
            Adc24BiasedChannels = Adc24BiasedChannels Or Convert.ToInt32("1000000000000000", 2)
        End If

        ' ------------------------------------------------------------- OVERRIDE MASKS
        '' active
        'Adc24ActiveChannels = Convert.ToInt32("0000000000000001", 2)
        '' Combo - Diff Pseudo Single
        'Adc24DiffChannels = Convert.ToInt32("0000000000000001", 2)
        'Adc24PseudoChannels = Convert.ToInt32("0000000000000000", 2)
        '' Combo - Gain 1 2 4 8 16 32 64 128
        'Adc24ChannelsGains = Convert.ToInt32("111111111111111111111111", 2) ' 000=1 001=2 010=4 011=8 100=16 ... 110=64 111=128
        '' Check - Biased
        'Adc24BiasedChannels = Convert.ToInt32("0000000000000000", 2)

        ' --------------------------------------------------------------------------------
        '   ADC_24 CONFIG - BY ASYNChronous SendBytesToSlave - SendAdc24ConfigToHardware
        ' --------------------------------------------------------------------------------
        Dim b(19) As Byte
        b(0) = CByte(Master.CommandsToHardware.SendAdc24Config)
        b(1) = CByte((Sps >> 8) And 255)
        b(2) = CByte(Sps And 255)
        b(3) = CByte((Fsck_KHz >> 8) And 255)
        b(4) = CByte(Fsck_KHz And 255)
        b(5) = CByte(If(MultipleSetups, 1, 0))
        b(6) = CByte(If(FiltersSingleCycle, 1, 0))
        b(7) = CByte(Adc24PreFilterType And 255)
        b(8) = CByte(Adc24PostFilterType And 255)
        b(9) = CByte((Adc24ActiveChannels >> 8) And 255)
        b(10) = CByte(Adc24ActiveChannels And 255)
        b(11) = CByte((Adc24BiasedChannels >> 8) And 255)
        b(12) = CByte(Adc24BiasedChannels And 255)
        b(13) = CByte((Adc24DiffChannels >> 8) And 255)
        b(14) = CByte(Adc24DiffChannels And 255)
        b(15) = CByte((Adc24PseudoChannels >> 8) And 255)
        b(16) = CByte(Adc24PseudoChannels And 255)
        b(17) = CByte((Adc24ChannelsGains >> 16) And 255)
        b(18) = CByte((Adc24ChannelsGains >> 8) And 255)
        b(19) = CByte(Adc24ChannelsGains And 255)
        Masters(MasterId).SendBytesToSlave(0, b)
    End Sub

End Class







