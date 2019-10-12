
Imports System.Globalization
Imports System.Math
Imports System.Collections.Generic


' ==================================================================================================
'   CLASS PIN
' ==================================================================================================
Class Pin

    Friend Enum Directions As Int32
        Unused = 0
        HostToMaster = 1
        MasterToHost = 2
    End Enum

    Friend Enum PinTypes As Int32
        UNUSED = 0

        DIG_OUT = 1
        PWM_8 = 2
        PWM_16 = 3
        SERVO_8 = 4
        SERVO_16 = 5
        STEPPER = 6
        PWM_FAST = 7

        DIG_IN = 129
        DIG_IN_PU = 130

        ADC_8 = 131
        ADC_16 = 132
        CAP_8 = 133
        CAP_16 = 134
        RES_8 = 135
        RES_16 = 136

        COUNTER = 140
        COUNTER_PU = 141

        FAST_COUNTER = 142
        FAST_COUNTER_PU = 143

        PERIOD = 144
        PERIOD_PU = 145

        SLOW_PERIOD = 146
        SLOW_PERIOD_PU = 147

        USOUND_SENSOR = 150

        CAP_SENSOR = 160

        STEPPER_DIR = 165 ' STEPPER_DIR is an hardware output but it sends steps-from-destination to USB

        'I2C_SDA = 170
        'I2C_SCL = 171

        ADC_24 = 173
        ADC_24_DIN = 174
        ADC_24_DOUT = 175
        ADC_24_CH = 176
        ADC_24_CH_B = 177

        ENCODER_A = 180
        ENCODER_A_PU = 181
        ENCODER_B = 182
        ENCODER_B_PU = 183

        'SNIFFER = 190
    End Enum


    Friend Shared Function StringToPinType(ByVal PinTypeString As String) As PinTypes
        Select Case UCase(PinTypeString.Trim)
            Case "UNUSED" : Return PinTypes.UNUSED

            Case "DIG_OUT" : Return PinTypes.DIG_OUT
            Case "PWM_8" : Return PinTypes.PWM_8
            Case "PWM_16" : Return PinTypes.PWM_16
            Case "SERVO_8" : Return PinTypes.SERVO_8
            Case "SERVO_16" : Return PinTypes.SERVO_16
            Case "STEPPER" : Return PinTypes.STEPPER
            Case "STEPPER_DIR" : Return PinTypes.STEPPER_DIR  ' This is an input but also an hardware output
            Case "PWM_FAST" : Return PinTypes.PWM_FAST

            Case "DIG_IN" : Return PinTypes.DIG_IN
            Case "DIG_IN_PU" : Return PinTypes.DIG_IN_PU

            Case "CAP_8" : Return PinTypes.CAP_8
            Case "CAP_16" : Return PinTypes.CAP_16
            Case "RES_8" : Return PinTypes.RES_8
            Case "RES_16" : Return PinTypes.RES_16

            Case "ADC_8" : Return PinTypes.ADC_8
            Case "ADC_16" : Return PinTypes.ADC_16
            Case "ADC_24" : Return PinTypes.ADC_24
            Case "ADC_24_DIN" : Return PinTypes.ADC_24_DIN
            Case "ADC_24_DOUT" : Return PinTypes.ADC_24_DOUT
            Case "ADC_24_CH" : Return PinTypes.ADC_24_CH
            Case "ADC_24_CH_B" : Return PinTypes.ADC_24_CH_B

            Case "COUNTER" : Return PinTypes.COUNTER
            Case "COUNTER_PU" : Return PinTypes.COUNTER_PU

            Case "FAST_COUNTER" : Return PinTypes.FAST_COUNTER
            Case "FAST_COUNTER_PU" : Return PinTypes.FAST_COUNTER_PU

            Case "PERIOD" : Return PinTypes.PERIOD
            Case "PERIOD_PU" : Return PinTypes.PERIOD_PU

            Case "SLOW_PERIOD" : Return PinTypes.SLOW_PERIOD
            Case "SLOW_PERIOD_PU" : Return PinTypes.SLOW_PERIOD_PU

            Case "USOUND_SENSOR" : Return PinTypes.USOUND_SENSOR

            Case "CAP_SENSOR" : Return PinTypes.CAP_SENSOR

            Case "ENCODER_A" : Return PinTypes.ENCODER_A
            Case "ENCODER_A_PU" : Return PinTypes.ENCODER_A_PU
            Case "ENCODER_B" : Return PinTypes.ENCODER_B
            Case "ENCODER_B_PU" : Return PinTypes.ENCODER_B_PU
        End Select
        Return Nothing
    End Function

    Friend Shared Function PinTypeToString(ByVal pintype As PinTypes) As String
        Dim s As String = ""
        Select Case pintype
            Case PinTypes.UNUSED : s = "UNUSED"

            Case PinTypes.DIG_OUT : s = "DIG_OUT"
            Case PinTypes.PWM_8 : s = "PWM_8"
            Case PinTypes.PWM_16 : s = "PWM_16"
            Case PinTypes.SERVO_8 : s = "SERVO_8"
            Case PinTypes.SERVO_16 : s = "SERVO_16"
            Case PinTypes.STEPPER : s = "STEPPER"
            Case PinTypes.STEPPER_DIR : s = "STEPPER_DIR" ' This is an input but also an hardware output
            Case PinTypes.PWM_FAST : s = "PWM_FAST"

            Case PinTypes.DIG_IN : s = "DIG_IN"
            Case PinTypes.DIG_IN_PU : s = "DIG_IN_PU"

            Case PinTypes.CAP_8 : s = "CAP_8"
            Case PinTypes.CAP_16 : s = "CAP_16"
            Case PinTypes.RES_8 : s = "RES_8"
            Case PinTypes.RES_16 : s = "RES_16"

            Case PinTypes.ADC_8 : s = "ADC_8"
            Case PinTypes.ADC_16 : s = "ADC_16"
            Case PinTypes.ADC_24 : s = "ADC_24"
            Case PinTypes.ADC_24_DIN : s = "ADC_24_DIN"
            Case PinTypes.ADC_24_DOUT : s = "ADC_24_DOUT"
            Case PinTypes.ADC_24_CH : s = "ADC_24_CH"
            Case PinTypes.ADC_24_CH_B : s = "ADC_24_CH_B"

            Case PinTypes.COUNTER : s = "COUNTER"
            Case PinTypes.COUNTER_PU : s = "COUNTER_PU"

            Case PinTypes.FAST_COUNTER : s = "FAST_COUNTER"
            Case PinTypes.FAST_COUNTER_PU : s = "FAST_COUNTER_PU"

            Case PinTypes.PERIOD : s = "PERIOD"
            Case PinTypes.PERIOD_PU : s = "PERIOD_PU"

            Case PinTypes.SLOW_PERIOD : s = "SLOW_PERIOD"
            Case PinTypes.SLOW_PERIOD_PU : s = "SLOW_PERIOD_PU"

            Case PinTypes.USOUND_SENSOR : s = "USOUND_SENSOR"

            Case PinTypes.CAP_SENSOR : s = "CAP_SENSOR"

            Case PinTypes.ENCODER_A : s = "ENCODER_A"
            Case PinTypes.ENCODER_A_PU : s = "ENCODER_A_PU"
            Case PinTypes.ENCODER_B : s = "ENCODER_B"
            Case PinTypes.ENCODER_B_PU : s = "ENCODER_B_PU"
        End Select

        Return CamelCaseString(s)
    End Function



    Friend MasterId As Int32
    Friend SlaveId As Int32
    Friend PinId As Int32
    Private PinType As PinTypes
    Friend Direction As Directions
    ' ------------------------------------------- slot 0 to 999 starting from the pin near to master
    Friend Slot As Int32
    ' ------------------------------------------- byte index in the USB buffer ( HostToMaster or MasterToHost )
    Friend UsbByteIndex As Int32
    ' ------------------------------------------- bytes used by this pin in the USB(Host-Master) communications
    Friend UsbBytesCount As Int32
    ' ------------------------------------------- bytes used by this pin in the COM(Master-Slave) communications
    Friend ComBytesCount As Int32

    ' ------------------------------------------- all pins
    Friend Value_RawInteger As Int32
    Friend Value_RawUinteger As UInt32
    Friend Value_RawUinteger_Old As UInt32
    Friend Value_RawUinteger_Zero As UInt32
    Friend Value_RawSmoothed As Single
    Friend Value_Uinteger_Max As UInt32
    Friend Value_Uinteger_Min As UInt32
    Friend Value As Single
    Friend Value_Max As Single
    Friend Value_Min As Single
    Friend Value_Parking As Single
    Friend Value_Normalized As Single = 0
    Friend Value_Normalized_New As Single
    Friend Value_Zero As Single
    Friend AdaptiveSpeed As Boolean
    Friend ResponseSpeed As Int32
    Friend RepTime As Int32
    Private OldTimeMilliseconds As Double
    Private NewTimeMilliseconds As Double
    ' ------------------------------------------ Servo and Pwm specific
    Friend MaxTime As Single
    Friend MinTime As Single
    Friend LogResponse As Boolean
    ' ------------------------------------------ Stepper specific
    Friend MaxSpeed As Single
    Friend MaxAcc As Single
    Friend StepsPerMillimeter As Single
    Friend StepperSpeed_Hz As Int32
    Friend StepperAcc_Hz_per_mS As Int32
    ' ------------------------------------------ Stepper interpolate specific
    Friend LinkedToPrevious As Boolean
    Friend StartPosMM As Single
    Friend DestPosMM As Single
    ' ------------------------------------------ Pwm Fast specific
    Friend PwmFastFrequency As Single
    Friend PwmFastDutyCycle As Single
    Friend FrequencyFromSlot As Boolean
    Friend DutyCycleFromSlot As Boolean
    ' ------------------------------------------ Counter and Period specific
    Friend ConvertToFreq As Boolean
    Friend MaxFreq As Single
    Friend MinFreq As Single
    ' ------------------------------------------ Usound_sensor and Cap_sensor specific
    Friend RemoveErrors As Boolean
    Friend Dist_mm As Single
    Friend MaxDist_mm As Single
    Friend MinDist_mm As Single
    ' ------------------------------------------ Touch specific
    Friend MinVariation As Single
    Friend ProportionalArea As Single
    Friend MeanValue As Single
    Private oldDelta1 As Single
    Private oldDelta2 As Single
    Private oldDelta3 As Single
    Private Velocity As Single

    ' ------------------------------------------ Adc_24 specific
    Friend Adc24Npins As Int32                ' Number of desired adc24 pins
    Friend Adc24Sps As Int32                  ' Samples per second
    Friend Adc24Filter As Int32               ' Filters 0 to 7

    ' ------------------------------------------ Adc_24_channel specific
    Friend Adc24ChType As Int32               ' (0 to 2) Diff / Pseudo / Single ended
    Friend Adc24ChGain As Int32               ' (0 to 7) 1,2,4,8,16,32,64,128
    Friend Adc24ChBias As Boolean             ' Bias on off  

    ' ------------------------------------------ Cap_sensor specific
    Friend ErrorCounter As Int32
    Friend TimerDivision As Int32
    Friend TimerFrequencyKhz As Int32
    Friend Inductor_uh As Single
    Friend Area_cmq As Single
    '
    Friend Millisec As Single
    Friend Freq As Single
    '
    Private IntegratedFreqString As String = ""
    Private IntegratedFreq As Double
    Private IntegratedlFreqCounter As Int32
    '
    Friend Cap_serial As Double
    Friend Cap_total As Single
    Friend Cap_zero As Single
    Friend Cap_input As Single

    Friend Sub New(ByVal _pintype As PinTypes, _
                   ByVal _masterid As Int32, _
                   ByVal _slaveid As Int32, _
                   ByVal _pinid As Int32)

        MasterId = _masterid
        SlaveId = _slaveid
        PinId = _pinid
        RepTime = 1
        SetPinType(_pintype)
    End Sub

    Friend Function GetPinType() As PinTypes
        Return PinType
    End Function

    ' ==================================================================================================
    '   DEFAULTS
    ' ==================================================================================================
    Friend Sub SetPinType(ByVal _pintype As PinTypes)
        If PinType = _pintype Then Return
        PinType = _pintype
        '
        Value_Parking = 0
        Value_Max = 1000
        Value_Min = 0
        MaxFreq = 1000
        MinFreq = 0
        AdaptiveSpeed = False
        ResponseSpeed = 100
        LogResponse = False
        ' --------------------------------------------------------- defaults
        Select Case PinType

            ' ----------------------------------------------------- outputs
            Case PinTypes.DIG_OUT
                UsbBytesCount = 1
                ComBytesCount = 1

            Case PinTypes.PWM_8
                Value_Parking = NAN_Sleep
                MaxTime = 4000
                MinTime = 0
                UsbBytesCount = 1
                ComBytesCount = 1

            Case PinTypes.PWM_16
                Value_Parking = NAN_Sleep
                MaxTime = 4000
                MinTime = 0
                UsbBytesCount = 2
                ComBytesCount = 2

            Case PinTypes.SERVO_8
                Value_Parking = NAN_Sleep
                MaxTime = 2500
                MinTime = 500
                UsbBytesCount = 1
                ComBytesCount = 1

            Case PinTypes.SERVO_16
                Value_Parking = NAN_Sleep
                MaxTime = 2500
                MinTime = 500
                UsbBytesCount = 2
                ComBytesCount = 2

            Case PinTypes.STEPPER
                MaxSpeed = 200
                MaxAcc = 50
                LinkedToPrevious = False
                StepsPerMillimeter = 200
                UsbBytesCount = 4
                ComBytesCount = 4

            Case PinTypes.PWM_FAST
                Value_Parking = NAN_Sleep
                PwmFastFrequency = 1000
                PwmFastDutyCycle = 500
                FrequencyFromSlot = False
                DutyCycleFromSlot = False
                UsbBytesCount = 5
                ComBytesCount = 5

                ' ------------------------------------------------- inputs
            Case PinTypes.DIG_IN, PinTypes.DIG_IN_PU
                Value_Parking = 0
                UsbBytesCount = 1
                ComBytesCount = 1

            Case PinTypes.CAP_8
                MinVariation = 20
                ProportionalArea = 0
                MeanValue = 0
                ResponseSpeed = 30
                UsbBytesCount = 1
                ComBytesCount = 1

            Case PinTypes.CAP_16
                MinVariation = 20
                ProportionalArea = 0
                MeanValue = 0
                ResponseSpeed = 30
                UsbBytesCount = 2
                ComBytesCount = 2

            Case PinTypes.RES_8
                ResponseSpeed = 30
                UsbBytesCount = 1
                ComBytesCount = 1

            Case PinTypes.RES_16
                ResponseSpeed = 30
                UsbBytesCount = 2
                ComBytesCount = 2

            Case PinTypes.ADC_8
                ResponseSpeed = 30
                UsbBytesCount = 1
                ComBytesCount = 1

            Case PinTypes.ADC_16
                ResponseSpeed = 30
                UsbBytesCount = 2
                ComBytesCount = 2

            Case PinTypes.ADC_24
                Adc24Npins = 16
                Adc24Sps = 100
                Adc24Filter = 0
                UsbBytesCount = 0
                ComBytesCount = 0

            Case PinTypes.ADC_24_DIN
                UsbBytesCount = 0
                ComBytesCount = 0

            Case PinTypes.ADC_24_DOUT
                UsbBytesCount = 1
                ComBytesCount = 1

            Case PinTypes.ADC_24_CH
                Adc24ChType = 0
                Adc24ChGain = 0
                Adc24ChBias = False
                UsbBytesCount = 3
                ComBytesCount = 3

            Case PinTypes.ADC_24_CH_B
                Adc24ChType = 0
                Adc24ChGain = 0
                Adc24ChBias = False
                UsbBytesCount = 0
                ComBytesCount = 0

            Case PinTypes.COUNTER, PinTypes.COUNTER_PU
                UsbBytesCount = 2
                ComBytesCount = 2

            Case PinTypes.FAST_COUNTER, PinTypes.FAST_COUNTER_PU
                UsbBytesCount = 2
                ComBytesCount = 2

            Case PinTypes.PERIOD, PinTypes.PERIOD_PU
                ResponseSpeed = 30
                UsbBytesCount = 4
                ComBytesCount = 4

            Case PinTypes.SLOW_PERIOD, PinTypes.SLOW_PERIOD_PU
                ResponseSpeed = 30
                UsbBytesCount = 4
                ComBytesCount = 4

            Case PinTypes.USOUND_SENSOR
                MaxDist_mm = 1000
                MinDist_mm = 0
                ResponseSpeed = 30
                RemoveErrors = True
                UsbBytesCount = 2
                ComBytesCount = 2

            Case PinTypes.CAP_SENSOR
                TimerDivision = 65536
                TimerFrequencyKhz = 16000
                Inductor_uh = 330
                Cap_serial = 16 '11.5       ' 0 = infinite  ( normally 16 pF )
                MaxDist_mm = 500
                MinDist_mm = 50
                ResponseSpeed = 30
                Area_cmq = 50
                UsbBytesCount = 3
                ComBytesCount = 3

            Case PinTypes.STEPPER_DIR
                UsbBytesCount = 4
                ComBytesCount = 4

            Case PinTypes.ENCODER_A, PinTypes.ENCODER_A_PU
                UsbBytesCount = 2
                ComBytesCount = 2

            Case PinTypes.ENCODER_B, PinTypes.ENCODER_B_PU
                UsbBytesCount = 0
                ComBytesCount = 0

            Case PinTypes.UNUSED
                MaxTime = 1
                MinTime = 0
                Value_Parking = 0
                UsbBytesCount = 0
                ComBytesCount = 0

            Case Else
                PinType = PinTypes.UNUSED
                MaxTime = 1
                MinTime = 0
                Value_Parking = 0
                UsbBytesCount = 0
                ComBytesCount = 0
        End Select

        ' --------------------------------------------------------- direction
        If UsbBytesCount = 0 Then
            Direction = Directions.Unused
        ElseIf PinType < 128 Then
            Direction = Directions.HostToMaster
        Else
            Direction = Directions.MasterToHost
        End If

    End Sub



    ' ==================================================================================================
    '  OUTPUTS  ( from SLOT to HARDWARE )
    ' ==================================================================================================
    Friend Sub ReadValueFromMMF()
        Value = Slots.ReadSlot(Slot)
    End Sub

    Friend Sub ConvertValueToHardwareFormat()
        Select Case PinType
            Case PinTypes.DIG_OUT, PinTypes.PWM_8, PinTypes.PWM_16, PinTypes.SERVO_8, PinTypes.SERVO_16
                ' -------------------------------------------------------------- min and max
                If Value_Max <> Value_Min Then
                    Value_Normalized_New = (Value - Value_Min) / (Value_Max - Value_Min)
                Else
                    Value_Normalized_New = Value
                End If
                ' -------------------------------------------------------------- limit to 0..1
                If Value_Normalized_New < 0 Then Value_Normalized_New = 0
                If Value_Normalized_New > 1 Then Value_Normalized_New = 1
                ' -------------------------------------------------------------- exponential passing by 0 and 1
                '                                                                a little less that the log base ( 2.7182 ) 
                If LogResponse AndAlso _
                   (PinType = PinTypes.PWM_8 Or PinType = PinTypes.PWM_16) Then
                    Value_Normalized_New = CSng(Value_Normalized_New ^ 2)
                End If
                ' -------------------------------------------------------------- speed 
                Masters(MasterId).SmoothValue(Value_Normalized, _
                                              Value_Normalized_New, _
                                              ResponseSpeed, _
                                              AdaptiveSpeed)

            Case PinTypes.PWM_FAST
                ' -------------------------------------------------------------- min and max
                If Value_Max <> Value_Min Then
                    Value_Normalized_New = (Value - Value_Min) / (Value_Max - Value_Min)
                Else
                    Value_Normalized_New = Value
                End If
                ' -------------------------------------------------------------- limit to 0..1
                If DutyCycleFromSlot Then
                    If Value_Normalized_New < 0 Then Value_Normalized_New = 0
                    If Value_Normalized_New > 1 Then Value_Normalized_New = 1
                End If
                ' -------------------------------------------------------------- speed 
                Masters(MasterId).SmoothValue(Value_Normalized, _
                                              Value_Normalized_New, _
                                              ResponseSpeed, _
                                              AdaptiveSpeed)

            Case PinTypes.STEPPER
                If Single.IsNaN(Value) Then
                    Value_Normalized = Value
                Else
                    ' ----------------------------------------------------------- normalize to 0..1
                    Value_Normalized_New = Value / 1000
                    ' ----------------------------------------------------------- scaling to 0 .. 1000 mm 
                    Value_Normalized_New = (Value_Normalized_New * (Value_Max - Value_Min) + Value_Min) / 1000

                    ' ----------------------------------------------------------- with speed = 100 smoothing is excluded 
                    Masters(MasterId).SmoothValue(Value_Normalized, _
                                                  Value_Normalized_New, _
                                                  ResponseSpeed, _
                                                  AdaptiveSpeed)
                End If
        End Select

        Select Case PinType
            Case PinTypes.DIG_OUT
                If Single.IsNaN(Value_Normalized) Then
                    Value_Normalized = 0
                End If
                If Value_Normalized > 0.5 Then
                    Value_RawUinteger = 1
                Else
                    Value_RawUinteger = 0
                End If

            Case PinTypes.PWM_8, PinTypes.SERVO_8
                If Single.IsNaN(Value_Normalized) Then
                    Value_Normalized = If(Value_Max > Value_Min, 0, 1)
                    Value_RawUinteger = 0
                Else
                    Value_RawUinteger = CUInt(16.0F * (Value_Normalized * (MaxTime - MinTime) + MinTime))
                End If
                If Value_RawUinteger < 0 Then Value_RawUinteger = 0
                If Value_RawUinteger > 64000 Then Value_RawUinteger = 64000

            Case PinTypes.PWM_16, PinTypes.SERVO_16
                If Single.IsNaN(Value_Normalized) Then
                    Value_Normalized = If(Value_Max > Value_Min, 0, 1)
                    Value_RawUinteger = 0
                Else
                    Value_RawUinteger = CUInt(16.0F * (Value_Normalized * (MaxTime - MinTime) + MinTime))
                End If
                If Value_RawUinteger < 0 Then Value_RawUinteger = 0
                If Value_RawUinteger > 64000 Then Value_RawUinteger = 64000

            Case PinTypes.STEPPER
                If IsNanReset(Value_Normalized) Then
                    Value_RawUinteger = &HFFFFFFFFUI
                Else
                    If Single.IsNaN(Value_Normalized) Then Value_Normalized = 0
                    Value_RawUinteger = Convert.ToUInt32( _
                                       (Convert.ToInt64(Value_Normalized * 1000 * StepsPerMillimeter) + _
                                        &H80000000UI))
                End If

            Case PinTypes.PWM_FAST
                If Single.IsNaN(Value_Normalized) Then Value_Normalized = 0
                If FrequencyFromSlot Then PwmFastFrequency = Value_Normalized * 1000
                If DutyCycleFromSlot Then PwmFastDutyCycle = Value_Normalized * 1000
                If PwmFastFrequency < 0 Then PwmFastFrequency = 0
                If PwmFastFrequency > 8000000 Then PwmFastFrequency = 8000000
                If PwmFastDutyCycle < 0 Then PwmFastDutyCycle = 0
                If PwmFastDutyCycle > 1000 Then PwmFastDutyCycle = 1000
        End Select
    End Sub

    'Friend Sub ConvertStepperValuesToHardwareFormat()
    '    Value_Normalized_New = Value / 1000
    '    ' -------------------------------------------------------------- scaling to 0 .. 1000 mm 
    '    Value_Normalized_New = (Value_Normalized_New * (Value_Max - Value_Min) + Value_Min) / 1000

    '    ' -------------------------------------------------------------- smoothing excluded 
    '    Value_Normalized = Value_Normalized_New
    '    Value_RawUinteger = Convert.ToUInt32( _
    '                                       (Convert.ToInt64(Value_Normalized * 1000 * StepsPerMillimeter) + _
    '                                        &H80000000UI))
    'End Sub

    Friend Sub WriteValueToUsbBuffer()
        Dim bytes() As Byte
        Select Case PinType
            Case PinTypes.DIG_OUT
                Masters(MasterId).Hid.USB_TxData(UsbByteIndex) = CByte(Value_RawUinteger)
            Case PinTypes.PWM_8, PinTypes.SERVO_8
                Masters(MasterId).Hid.USB_TxData(UsbByteIndex) = CByte(Value_RawUinteger / 256)
            Case PinTypes.PWM_16, PinTypes.SERVO_16
                bytes = ByteArrayFromUint16(CUShort(Value_RawUinteger))
                Masters(MasterId).Hid.USB_TxData(UsbByteIndex) = bytes(0)
                Masters(MasterId).Hid.USB_TxData(UsbByteIndex + 1) = bytes(1)
            Case PinTypes.STEPPER
                bytes = StepperByteArray_FromUint32(Value_RawUinteger)
                Masters(MasterId).Hid.USB_TxData(UsbByteIndex) = bytes(0)
                Masters(MasterId).Hid.USB_TxData(UsbByteIndex + 1) = bytes(1)
                Masters(MasterId).Hid.USB_TxData(UsbByteIndex + 2) = bytes(2)
                Masters(MasterId).Hid.USB_TxData(UsbByteIndex + 3) = bytes(3)
            Case PinTypes.PWM_FAST
                bytes = ByteArrayFromUint24(CUInt(PwmFastFrequency))
                Masters(MasterId).Hid.USB_TxData(UsbByteIndex) = bytes(0)
                Masters(MasterId).Hid.USB_TxData(UsbByteIndex + 1) = bytes(1)
                Masters(MasterId).Hid.USB_TxData(UsbByteIndex + 2) = bytes(2)
                ' ----------------------------------------------------------------------
                ' This 65534 (instead of 65535) removes a random glitch
                ' when setting PwmFastDutyCycle around 999...1000
                ' (maybe the bug could be in the Master firmware)
                ' ----------------------------------------------------------------------
                bytes = ByteArrayFromUint16(CUShort(PwmFastDutyCycle * 65.534))
                ' ----------------------------------------------------------------------
                Masters(MasterId).Hid.USB_TxData(UsbByteIndex + 3) = bytes(0)
                Masters(MasterId).Hid.USB_TxData(UsbByteIndex + 4) = bytes(1)
        End Select
    End Sub

    Friend Sub WriteValueToByteArray(ByRef b() As Byte, ByRef ix As Int32)
        Dim bytes() As Byte
        Select Case GetPinType()
            Case Pin.PinTypes.DIG_OUT
                b(ix) = CByte(Value_RawUinteger)
                ix += 1
            Case Pin.PinTypes.PWM_8, Pin.PinTypes.SERVO_8
                b(ix) = CByte(Value_RawUinteger / 256)
                ix += 1
            Case Pin.PinTypes.PWM_16, Pin.PinTypes.SERVO_16
                bytes = ByteArrayFromUint16(CUShort(Value_RawUinteger))
                b(ix) = bytes(0)
                ix += 1
                b(ix) = bytes(1)
                ix += 1
            Case Pin.PinTypes.STEPPER
                bytes = StepperByteArray_FromUint32(Value_RawUinteger)
                b(ix) = bytes(0)
                ix += 1
                b(ix) = bytes(1)
                ix += 1
                b(ix) = bytes(2)
                ix += 1
                b(ix) = bytes(3)
                ix += 1
            Case Pin.PinTypes.PWM_FAST
                bytes = ByteArrayFromUint24(CUInt(PwmFastFrequency))
                b(ix) = bytes(0)
                ix += 1
                b(ix) = bytes(1)
                ix += 1
                b(ix) = bytes(2)
                ix += 1
                ' ----------------------------------------------------------------------
                ' This 65534 (instead of 65535) removes a random glitch
                ' when setting PwmFastDutyCycle around 999...1000
                ' (maybe the bug could be in the Master firmware)
                ' ----------------------------------------------------------------------
                bytes = ByteArrayFromUint16(CUShort(PwmFastDutyCycle * 65.534))
                ' ----------------------------------------------------------------------
                b(ix) = bytes(0)
                ix += 1
                b(ix) = bytes(1)
                ix += 1
        End Select
    End Sub




    ' ==================================================================================================
    '  INPUTS  ( from HARDWARE to SLOT )
    ' ==================================================================================================
    Friend Sub ReadValueFromUsbBuffer()
        With Masters(MasterId).Hid
            Select Case UsbBytesCount
                Case 1
                    Value_RawUinteger = .USB_RxData(UsbByteIndex + 0)
                Case 2
                    Value_RawUinteger = .USB_RxData(UsbByteIndex + 0) * 256UI + _
                                        .USB_RxData(UsbByteIndex + 1)
                Case 3
                    Value_RawUinteger = .USB_RxData(UsbByteIndex + 0) * 65536UI + _
                    .USB_RxData(UsbByteIndex + 1) * 256UI + _
                    .USB_RxData(UsbByteIndex + 2)
                Case 4
                    Value_RawUinteger = .USB_RxData(UsbByteIndex + 0) * 256UI * 65536UI + _
                    .USB_RxData(UsbByteIndex + 1) * 65536UI + _
                    .USB_RxData(UsbByteIndex + 2) * 256UI + _
                    .USB_RxData(UsbByteIndex + 3)
            End Select
        End With
    End Sub

    Friend Sub SetValueFromByteArray(ByVal b() As Byte, ByRef ix As Int32)
        Select Case UsbBytesCount
            Case 1
                Value_RawUinteger = b(ix)
                ix += 1
            Case 2
                Value_RawUinteger = b(ix) * 256UI + b(ix + 1)
                ix += 2
            Case 3
                Value_RawUinteger = b(ix) * 65536UI + b(ix + 1) * 256UI + b(ix + 2)
                ix += 3
            Case 4
                Value_RawUinteger = b(ix) * 256UI * 65536UI + b(ix + 1) * 65536UI + _
                                                              b(ix + 2) * 256UI + b(ix + 3)
                ix += 4
        End Select
    End Sub


    Friend Sub ConvertValueFromHardwareFormat()

        Select Case PinType

            Case PinTypes.DIG_IN, PinTypes.DIG_IN_PU
                If Value_RawUinteger <> 0 Then Value_RawUinteger = 1
                Value_Normalized_New = Value_RawUinteger

            Case PinTypes.CAP_8
                Value_RawUinteger *= 3UI ' correction for (PIC24)Master and Servo values (0 to 60 instead of 0 to 255)
            Case PinTypes.CAP_16
                Value_RawUinteger *= 3UI ' correction for (PIC24)Master and Servo values (0 to 16000 instead of 0 to 65535)

            Case PinTypes.RES_8
                Value_Normalized_New = Value_RawUinteger / 255.0F
            Case PinTypes.RES_16
                Value_Normalized_New = Value_RawUinteger / 65535.0F

            Case PinTypes.ADC_8
                Value_Normalized_New = Value_RawUinteger / 255.0F
            Case PinTypes.ADC_16
                Value_Normalized_New = Value_RawUinteger / 65535.0F

            Case PinTypes.ADC_24
                '
            Case PinTypes.ADC_24_DIN
                '
            Case PinTypes.ADC_24_DOUT
                Value_Normalized_New = Value_RawUinteger / 255.0F
            Case PinTypes.ADC_24_CH
                Value_Normalized_New = Value_RawUinteger / 16777215.0F
            Case PinTypes.ADC_24_CH_B
                '

            Case PinTypes.COUNTER, PinTypes.COUNTER_PU, _
                 PinTypes.FAST_COUNTER, PinTypes.FAST_COUNTER_PU

            Case PinTypes.PERIOD, PinTypes.PERIOD_PU

            Case PinTypes.SLOW_PERIOD, PinTypes.SLOW_PERIOD_PU

            Case PinTypes.STEPPER_DIR
                If Value_RawUinteger > 0 Then
                    Value_RawInteger = CInt(CLng(Value_RawUinteger) - &H80000000UI)
                End If

            Case PinTypes.USOUND_SENSOR
                If RemoveErrors Then UsoundSensor_RemoveErrors()
                UsoundSensor_CalculatePosition()

            Case PinTypes.CAP_SENSOR
                CapSensor_CalculateAll()

            Case PinTypes.ENCODER_A, PinTypes.ENCODER_A_PU
            Case PinTypes.ENCODER_B, PinTypes.ENCODER_B_PU
        End Select



        Select Case PinType

            Case PinTypes.DIG_IN, PinTypes.DIG_IN_PU, _
                 PinTypes.ADC_8, PinTypes.ADC_16, _
                 PinTypes.RES_8, PinTypes.RES_16, _
                 PinTypes.USOUND_SENSOR, _
                 PinTypes.CAP_SENSOR
                ' ------------------------------------------------------------------ limit to 0..1
                If Value_Normalized_New < 0 Then Value_Normalized_New = 0
                If Value_Normalized_New > 1 Then Value_Normalized_New = 1
                ' -------------------------------------------------------------- speed 
                Masters(MasterId).SmoothValue(Value_Normalized, _
                                              Value_Normalized_New, _
                                              ResponseSpeed, _
                                              AdaptiveSpeed)
                ' ------------------------------------------------------------------ min and max
                Value = Value_Normalized * (Value_Max - Value_Min) + Value_Min

            Case PinTypes.ADC_24, PinTypes.ADC_24_DIN
                '
            Case PinTypes.ADC_24_DOUT
                Value = Value_Normalized_New * 1000.0F
                Value_Normalized = Value_Normalized_New

            Case PinTypes.ADC_24_CH
                ' -------------------------------------------------------------- speed 
                Masters(MasterId).SmoothValue(Value_Normalized, _
                                              Value_Normalized_New, _
                                              ResponseSpeed, _
                                              AdaptiveSpeed)
                ' -------------------------------------------------------------- min and max
                Value = Value_Normalized * (Value_Max - Value_Min) + Value_Min
            Case PinTypes.ADC_24_CH_B
                '

            Case PinTypes.CAP_8, PinTypes.CAP_16
                ' -------------------------------------------------------------- speed before trigger
                If PinType = PinTypes.CAP_8 Then
                    Masters(MasterId).SmoothValue(Value_RawSmoothed, _
                                                      Value_RawUinteger * (1000.0F / 255.0F), _
                                                      ResponseSpeed, _
                                                      AdaptiveSpeed)
                Else
                    Masters(MasterId).SmoothValue(Value_RawSmoothed, _
                                                      Value_RawUinteger * (1000.0F / 65535.0F), _
                                                      ResponseSpeed, _
                                                      AdaptiveSpeed)
                End If

                If MinVariation > 0 Then
                    ' -------------------------------------------
                    '   CAP TOUCH KEYS
                    ' -------------------------------------------

                    ' ------------------------------------------------------------------ calculate delta
                    Dim delta As Single = MeanValue - Value_RawSmoothed

                    ' ------------------------------------------------------------------ increase min value
                    If delta < 0 Then
                        MeanValue += (Value_RawSmoothed - MeanValue) * 0.01F
                        delta = 0
                    End If
                    ' ------------------------------------------------------------------ MinVariation reduced for sliders
                    If ProportionalArea > 0 Then
                        delta -= MinVariation / 100
                    Else
                        delta -= MinVariation
                    End If
                    ' ------------------------------------------------------------------
                    If ProportionalArea > 0 Then
                        ' -------------------------------------------------------------- proportional limited to 0..1
                        Value_Normalized = delta / ProportionalArea
                        If Value_Normalized < 0 Then Value_Normalized = 0
                        If Value_Normalized > 1 Then Value_Normalized = 1
                    ElseIf ProportionalArea = 0 Then
                        ' -------------------------------------------------------------- on/off (0 or 1)
                        Value_Normalized = If(delta > 0, 1, 0)
                    Else
                        ' -------------------------------------------------------------- with velocity
                        If delta > 0 Then
                            If Velocity = 0 Then
                                Velocity = (delta - oldDelta3) / -ProportionalArea
                                If Velocity > 1 Then Velocity = 1
                                Velocity = Velocity * Velocity
                            End If
                        Else
                            Velocity = 0
                        End If
                        oldDelta3 = oldDelta2
                        oldDelta2 = oldDelta1
                        oldDelta1 = delta
                        Value_Normalized = Velocity
                    End If

                Else
                    ' -------------------------------------------
                    '   RAW CAPACITIVE SENSORS
                    ' -------------------------------------------
                    Value_Normalized = (-MinVariation - Value_RawSmoothed) / ProportionalArea
                    If Value_Normalized < 0 Then Value_Normalized = 0
                    If Value_Normalized > 1 Then Value_Normalized = 1

                End If
                ' ---------------------------------------------------------------------- min and max
                Value = Value_Normalized * (Value_Max - Value_Min) + Value_Min
                ' ---------------------------------------------------------------------- values min and max for calibrate Inhibit
                If Value_RawSmoothed > Value_Uinteger_Max Then Value_Uinteger_Max = CUInt(Value_RawSmoothed * 10)
                If Value_RawSmoothed < Value_Uinteger_Min Then Value_Uinteger_Min = CUInt(Value_RawSmoothed * 10)


            Case PinTypes.COUNTER, PinTypes.COUNTER_PU, _
                 PinTypes.FAST_COUNTER, PinTypes.FAST_COUNTER_PU
                If ConvertToFreq Then
                    ' ------------------------------------------------------------------ delta time
                    NewTimeMilliseconds = FreeRunningTimer.Elapsed.TotalMilliseconds
                    Dim dt As Double = NewTimeMilliseconds - OldTimeMilliseconds
                    ' ------------------------------------------------------------------ update every 100 mS
                    Dim SamplingTimeMs As Double = 100000 / MaxFreq
                    If SamplingTimeMs > 1000 Then SamplingTimeMs = 1000
                    If SamplingTimeMs < 10 Then SamplingTimeMs = 10
                    If dt >= SamplingTimeMs Then
                        ' -------------------------------------------------------------- delta counts
                        Dim diff As UInt32
                        If Value_RawUinteger >= Value_RawUinteger_Old Then
                            diff = Value_RawUinteger - Value_RawUinteger_Old
                        Else
                            diff = (&HFFFFUI - Value_RawUinteger_Old) + Value_RawUinteger + 1UI
                        End If
                        Value_RawUinteger_Old = Value_RawUinteger
                        ' -------------------------------------------------------------- frequency
                        If Value_RawUinteger > 0 AndAlso dt > 0 Then
                            Freq = CSng(1000 * diff / dt)
                        Else
                            Freq = 0
                        End If
                        OldTimeMilliseconds = NewTimeMilliseconds
                    End If
                    ' ------------------------------------------------------------------ range
                    Dim range As Double = MaxFreq - MinFreq
                    If range < 0.1 Then range = 0.1
                    Value_Normalized_New = CSng((Freq - MinFreq) / range)
                    ' ------------------------------------------------------------------ speed
                    Masters(MasterId).SmoothValue(Value_Normalized, _
                                                  Value_Normalized_New, _
                                                  ResponseSpeed, _
                                                  AdaptiveSpeed)
                    ' ------------------------------------------------------------------ min and max
                    Value = Value_Normalized * (Value_Max - Value_Min) + Value_Min
                Else
                    Value_Normalized_New = Value_RawUinteger / 65535.0F
                    Value_Normalized = Value_Normalized_New
                    Value = Value_RawUinteger
                End If

            Case PinTypes.PERIOD, PinTypes.PERIOD_PU, _
                 PinTypes.SLOW_PERIOD, PinTypes.SLOW_PERIOD_PU
                ' ---------------------------------------------------- Value_RawUinteger = 0.0625 uSec ( 16 MHz )
                If ConvertToFreq Then
                    ' -------------------------------------------------------------- range
                    If Value_RawUinteger > 0 Then
                        Freq = 1.6E+7F / Value_RawUinteger
                    Else
                        Freq = 0
                    End If
                    Dim range As Double = MaxFreq - MinFreq
                    If range < 0.1 Then range = 0.1
                    Value_Normalized_New = CSng((Freq - MinFreq) / range)
                    ' -------------------------------------------------------------- speed 
                    Masters(MasterId).SmoothValue(Value_Normalized, _
                                                  Value_Normalized_New, _
                                                  ResponseSpeed, _
                                                  AdaptiveSpeed)
                    ' -------------------------------------------------------------- min and max
                    Value = Value_Normalized * (Value_Max - Value_Min) + Value_Min
                Else
                    Value_Normalized_New = Value_RawUinteger / 16777215.0F / 2.0F
                    Value_Normalized = Value_Normalized_New
                    Value = Value_RawUinteger
                End If

            Case PinTypes.STEPPER_DIR
                If PinId > 0 Then
                    Value = Value_RawInteger / Masters(MasterId).Slaves(SlaveId).Pins(PinId - 1).StepsPerMillimeter
                End If
                Value_Normalized_New = Value / 1000
                Value_Normalized = Value_Normalized_New

            Case PinTypes.ENCODER_A, PinTypes.ENCODER_A_PU
                Value_Normalized_New = Value_RawUinteger / 65535.0F
                Value_Normalized = Value_Normalized_New
                Value = Value_RawUinteger

            Case PinTypes.ENCODER_B, PinTypes.ENCODER_B_PU
                Value_Normalized_New = Value_RawUinteger / 65535.0F
                Value_Normalized = Value_Normalized_New
                Value = Value_RawUinteger
        End Select
    End Sub

    Friend Sub WriteValueToMMF()
        Slots.WriteSlot(Slot, CSng(Value))
    End Sub


    ' ==================================================================================================
    '   STEPPER PIN CONFIGURATION - BY ASYNChronous SendBytesToSlave - 
    ' ==================================================================================================
    Friend Sub SendStepperParamsToHardware()
        StepperSpeed_Hz = CInt(MaxSpeed * StepsPerMillimeter / 60)
        StepperAcc_Hz_per_mS = CInt(MaxAcc * StepsPerMillimeter / 1000)
        If StepperSpeed_Hz > 65535 Then StepperSpeed_Hz = 65535
        If StepperAcc_Hz_per_mS > 65535 Then StepperAcc_Hz_per_mS = 65535
        Dim b(5) As Byte
        b(0) = CByte(Master.CommandsToHardware.SendStepperParams)
        b(1) = CByte(PinId)
        b(2) = CByte(StepperSpeed_Hz >> 8)
        b(3) = CByte(StepperSpeed_Hz And 255)
        b(4) = CByte(StepperAcc_Hz_per_mS >> 8)
        b(5) = CByte(StepperAcc_Hz_per_mS And 255)
        Masters(MasterId).SendBytesToSlave(0, b)
    End Sub

    ' ==================================================================================================
    '   HELPER FUNCTIONS
    ' ==================================================================================================
    Friend Sub ResetPosMinMax()
        Value_Uinteger_Min = 99999999
        Value_Uinteger_Max = 0
    End Sub

    Friend Sub Calibrate()
        Select Case PinType
            Case PinTypes.CAP_SENSOR
                ' ----------------------------------------------- calibrate cap input
                Cap_zero = Cap_total
                ' ----------------------------------------------- calculate immediately the new position
                CapSensor_CalculatePosition()

            Case PinTypes.CAP_8, PinTypes.CAP_16
                ' ----------------------------------------------- calibrate cap input
                MeanValue = Value_RawSmoothed
        End Select
    End Sub

    Friend Sub CalibrateZero()
        Value_RawUinteger_Zero = Value_RawUinteger
        Value_Zero = Value
    End Sub

    Friend Function GetValueString() As String
        Dim ci As CultureInfo = New CultureInfo("en-GB")
        Select Case PinType

            ' ------------------------------------------------------------------------- OUTPUTS
            Case PinTypes.DIG_OUT
                Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        " Slot: " & Value.ToString("0") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("0")

            Case PinTypes.SERVO_8, PinTypes.SERVO_16
                If Single.IsNaN(Value) Then
                    Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        " Slot: " & "Sleep" & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("0")
                Else
                    Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        " Slot: " & Value.ToString("0") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("0")
                End If

            Case PinTypes.PWM_8, PinTypes.PWM_16
                If Single.IsNaN(Value) Then
                    Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        " Slot: " & "Sleep" & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("0")
                Else
                    Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        " Slot: " & Value.ToString("0") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("0")
                End If
            Case PinTypes.STEPPER
                Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        " Slot: " & Value.ToString("0") & vbCrLf & _
                        " Filt: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        " Step: " & (Convert.ToInt64(Value_RawUinteger) - &H80000000UI).ToString("0") & vbCrLf & _
                        "   Hz: " & StepperSpeed_Hz.ToString("0") & vbCrLf & _
                        "Hz/mS: " & StepperAcc_Hz_per_mS.ToString("0")

            Case PinTypes.PWM_FAST
                If Single.IsNaN(Value) Then
                    Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        " Slot: " & "Sleep" & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("0")
                Else
                    Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        " Slot: " & Value.ToString("0") & vbCrLf & _
                        " Filt: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        "   Hz: " & PwmFastFrequency.ToString("0") & vbCrLf & _
                        " Duty: " & PwmFastDutyCycle.ToString("0")
                End If

                ' --------------------------------------------------------------------- INPUTS 
            Case PinTypes.DIG_IN, PinTypes.DIG_IN_PU
                Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("0") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        " Slot: " & Value.ToString("0.00", ci)

            Case PinTypes.CAP_8, PinTypes.CAP_16
                If MinVariation > 0 Then
                    Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        "   Raw: " & Value_RawUinteger.ToString("000") & vbCrLf & _
                        " Smoot: " & Value_RawSmoothed.ToString("0.00") & vbCrLf & _
                        "  Mean: " & MeanValue.ToString("0.00") & vbCrLf & _
                        "  Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        "  Slot: " & Value.ToString("0.00", ci)
                Else
                    Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        "   Raw: " & Value_RawUinteger.ToString("000") & vbCrLf & _
                        " Smoot: " & Value_RawSmoothed.ToString("0.00") & vbCrLf & _
                        "  Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        "  Slot: " & Value.ToString("0.00", ci)
                End If

            Case PinTypes.RES_8
                Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("000") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        " Slot: " & Value.ToString("0.00", ci)
            Case PinTypes.RES_16
                Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("00000") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        " Slot: " & Value.ToString("0.00", ci)


            Case PinTypes.ADC_8
                Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("000") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        " Slot: " & Value.ToString("0.00", ci)

            Case PinTypes.ADC_16
                Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("00000") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        " Slot: " & Value.ToString("0.00", ci)

            Case PinTypes.ADC_24_DOUT
                Return PinTypeToString(PinType) & vbCrLf & _
                       "--------------" & vbCrLf & _
                       "  Raw: " & Value_RawUinteger.ToString("000") & vbCrLf & _
                       " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                       " Slot: " & Value.ToString("0.00", ci)

            Case PinTypes.ADC_24_CH
                Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("00000000") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        " Slot: " & Value.ToString("0.000", ci)

            Case PinTypes.COUNTER, PinTypes.COUNTER_PU, _
                 PinTypes.FAST_COUNTER, PinTypes.FAST_COUNTER_PU, _
                 PinTypes.PERIOD, PinTypes.PERIOD_PU, _
                 PinTypes.SLOW_PERIOD, PinTypes.SLOW_PERIOD_PU
                If ConvertToFreq Then
                    Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("00000") & vbCrLf & _
                        " Freq: " & Freq.ToString("00000") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        " Slot: " & Value.ToString("0.00", ci)
                Else
                    Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("00000") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        " Slot: " & Value.ToString("00000")
                End If

            Case PinTypes.STEPPER_DIR
                Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        "  Raw: " & Value_RawInteger.ToString("00000") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & vbCrLf & _
                        " Error" & vbCrLf & " (mm): " & Value.ToString("0.00", ci)

            Case PinTypes.USOUND_SENSOR
                Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("00000") & vbCrLf & _
                        "   mm: " & Dist_mm.ToString("0000") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        " Slot: " & Value.ToString("0.00", ci)

            Case PinTypes.CAP_SENSOR
                If Value_RawUinteger < 999999 Then
                    '
                    Return "  Raw: " & Value_RawUinteger.ToString("00000") & vbCrLf & _
                           "   mS: " & Millisec.ToString("0.0000", ci) & vbCrLf & _
                           "  MHz: " & IntegratedFreqString & vbCrLf & _
                           "C_tot: " & Cap_total.ToString("00.000", ci) & vbCrLf & _
                           " C_in: " & Cap_input.ToString("00.000", ci) & vbCrLf & _
                           "   mm: " & Dist_mm.ToString("0000") & vbCrLf & _
                           " Norm: " & Value_Normalized.ToString("0.00", ci)
                End If

            Case PinTypes.ENCODER_A, PinTypes.ENCODER_A_PU
                Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("00000") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        " Slot: " & Value.ToString("00000")

            Case PinTypes.ENCODER_B, PinTypes.ENCODER_B_PU
                Return PinTypeToString(PinType) & vbCrLf & _
                        "--------------" & vbCrLf & _
                        "  Raw: " & Value_RawUinteger.ToString("00000") & vbCrLf & _
                        " Norm: " & Value_Normalized.ToString("0.00", ci) & vbCrLf & _
                        " Slot: " & Value.ToString("00000")

                ' --------------------------------------------------------------------- 
            Case Else
                Return PinTypeToString(PinType)

        End Select
        Return ""
    End Function



    ' ==================================================================================================
    '   USOUND SENSORS SPECIFIC
    ' ==================================================================================================
    Private Sub UsoundSensor_RemoveErrors()
        Dim diff As UInt32 = AbsUint32Difference(Value_RawUinteger, Value_RawUinteger_Old)
        Dim maxErrorCount As Int32 = 2 * (1 + 30 \ RepTime)
        '
        If diff > 1000 And ErrorCounter < maxErrorCount Then
            Value_RawUinteger = Value_RawUinteger_Old
            ErrorCounter += 1
        Else
            ' ---------------------------------------------------------- use the new value
            Value_RawUinteger_Old = Value_RawUinteger
            ErrorCounter = 0
        End If
    End Sub

    Private Sub UsoundSensor_CalculatePosition()
        ' -------------------------------------------------------------- distance in mm 
        Dist_mm = (Value_RawUinteger - 900.0F) * 0.173F
        ' -------------------------------------------------------------- distance limits
        If Dist_mm < MinDist_mm Then Dist_mm = MinDist_mm
        If Dist_mm > MaxDist_mm Then Dist_mm = MaxDist_mm
        ' -------------------------------------------------------------- range
        Dim range As Double = MaxDist_mm - MinDist_mm
        If range < 0.1 Then range = 0.1
        Value_Normalized_New = 1 - CSng((Dist_mm - MinDist_mm) / range)
    End Sub



    ' ==================================================================================================
    '   CAP SENSORS SPECIFIC
    ' ==================================================================================================
    Private Sub CapSensor_CalculateAll()
        CapSensor_LatencyBitsExtractor()
        'CapSensor_RemoveErrors()
        CapSensor_UpdateMinMaxValues()
        CapSensor_CalculateTimeAndFreq()
        CapSensor_CalculateTotalCap()
        CapSensor_CalculatePosition()
    End Sub

    Dim LatencySelector As Int32 = 0
    Private Sub CapSensor_LatencyBitsExtractor()
        LatencySelector = CType(Value_RawUinteger >> 20, Int32)
        Value_RawUinteger = Value_RawUinteger And &HFFFFFUI
    End Sub


    'Private Sub CapSensor_RemoveErrors()
    '    Dim MinCount As Int32 = 200000
    '    Dim MinDiff As Int32 = 35000
    '    Dim MaxDiff As Int32 = 95000
    '    Dim maxErrorCount As Int32 = 5 * (1 + 30 \ RepTime)
    '    '
    '    Dim diff As UInt32 = AbsUint32Difference(Value_RawUinteger, Value_RawUinteger_Old)
    '    '
    '    If (Value_RawUinteger < MinCount OrElse (diff > MinDiff And diff < MaxDiff)) And ErrorCounter < 5 Then
    '        ' ------------------------------------------------------ show the error
    '        'frmMain.txt_Reports.Text &= "Invalid sample  " & _
    '        '                            "  OLD=" & _slave.CountOld.ToString & _
    '        '                            "  NEW=" & _slave.CountNew.ToString & _
    '        '                            "  DIFF=" & diff.ToString & vbCrLf
    '        Value_RawUinteger = Value_RawUinteger_Old
    '        ErrorCounter += 1
    '    Else
    '        ' ------------------------------------------------------ use the new value
    '        Value_RawUinteger_Old = Value_RawUinteger
    '        ErrorCounter = 0
    '    End If
    'End Sub

    ' ------------------------------------------------- RawInteger min and max for AutoCalibrate
    Private Sub CapSensor_UpdateMinMaxValues()
        If Value_RawUinteger > Value_Uinteger_Max Then Value_Uinteger_Max = Value_RawUinteger
        If Value_RawUinteger < Value_Uinteger_Min Then Value_Uinteger_Min = Value_RawUinteger
    End Sub

    Private Sub CapSensor_CalculateTimeAndFreq()
        ' ---------------------------------------------------------- time total
        Dim mS As Single = CSng(Value_RawUinteger / TimerFrequencyKhz)
        ' ---------------------------------------------------------- frequency
        Freq = TimerDivision * 1000 / mS
        ' ---------------------------------------------------------- millisec corrected by latencyselector
        Millisec = mS / CSng(2 ^ LatencySelector)
        ' ---------------------------------------------------------- integrated frequency (only visual info)
        IntegratedFreq += Freq
        IntegratedlFreqCounter += 1
        If IntegratedlFreqCounter >= 50 Then
            IntegratedFreqString = (IntegratedFreq / (1000000 * 50)).ToString("0.00000", CultureInfo.InvariantCulture)
            If IntegratedFreqString = "Infinity" Then IntegratedFreqString = "---"
            IntegratedFreq = 0
            IntegratedlFreqCounter = 0
        End If
    End Sub

    Private Sub CapSensor_CalculateTotalCap()
        ' ----------------------------------------------------------- total capacitance ( in parallel to inductor )
        Cap_total = CSng(2.53302955E+16 / (Inductor_uh * Freq ^ 2))
    End Sub

    'Private Sub CapSensor_CalculatePosition()
    '    ' ----------------------------------------------------------- input capacitance ( after serial capacitor )
    '    If Cap_serial > 0 Then
    '        Cap_input = CSng(ELEC_C2_FromSerial(Cap_total - Cap_zero, Cap_serial))
    '    Else
    '        Cap_input = Cap_total - Cap_zero
    '    End If
    '    If Cap_input < 0 Then Cap_input = 0
    '    If Cap_input > 999.999 Then Cap_input = 999.999
    '    ' ----------------------------------------------------------- K area 
    '    ' Teoric K_Area is: 88 * 100 * Area_cmq
    '    ' from: 0.885F(cap. to dist. coeff.) * 100(cmq to mmq) * Area_cmq
    '    ' ---------
    '    ' A High coefficient ( 80 .. 160 ) expands the "Near" zone
    '    ' A Low coefficient  ( 40 .. 80 ) expands the "Far" zone
    '    ' ---------
    '    ' The user can change this Near-Far linearity 
    '    ' increasing or decreasing the parameter "Area_cmq" 
    '    ' ---------
    '    Dim K_Area As Single = 88 * Area_cmq
    '    ' ----------------------------------------------------------- distance in mm 
    '    Dist_mm = K_Area * MaxDist_mm / _
    '              (K_Area + Cap_input * MaxDist_mm * MaxDist_mm)
    '    ' ----------------------------------------------------------- distance limits
    '    If Dist_mm < 0 Then Dist_mm = 0
    '    If Dist_mm > MaxDist_mm Then Dist_mm = MaxDist_mm
    '    ' ----------------------------------------------------------- range
    '    Dim range As Double = MaxDist_mm - MinDist_mm
    '    If range < 0.1 Then range = 0.1
    '    Value_Normalized_New = 1 - CSng((Dist_mm - MinDist_mm) / range)
    'End Sub


    Private Sub CapSensor_CalculatePosition()

        If Area_cmq > 0 Then
            ' ----------------------------------------------------------- input capacitance ( after serial capacitor )
            If Cap_serial > 0 Then
                Cap_input = CSng(ELEC_C2_FromSerial(Cap_total - Cap_zero, Cap_serial))
            Else
                Cap_input = Cap_total - Cap_zero
            End If
            If Cap_input < 0 Then Cap_input = 0
            If Cap_input > 999.999 Then Cap_input = 999.999

            ' ----------------------------------------------------------- K area 
            ' Teoric K_Area is: 88 * 100 * Area_cmq
            ' from: 0.885F(cap. to dist. coeff.) * 100(cmq to mmq) * Area_cmq
            ' ---------
            ' A High coefficient ( 80 .. 160 ) expands the "Near" zone
            ' A Low coefficient  ( 40 .. 80 ) expands the "Far" zone
            ' ---------
            ' The user can change this Near-Far linearity 
            ' increasing or decreasing the parameter "Area_cmq" 
            ' ---------
            Dim K_Area As Single = 88 * Area_cmq
            ' ----------------------------------------------------------- MaxDist and MinDist correction for area
            Dim K2 As Single = Area_cmq / 100.0F
            Dim MinD As Single = MinDist_mm * K2
            Dim MaxD As Single = MaxDist_mm * K2
            ' ----------------------------------------------------------- distance in mm 
            Dist_mm = K_Area * MaxD / _
                     (K_Area + Cap_input * MaxD * MaxD)
            ' ----------------------------------------------------------- distance limits
            If Dist_mm < 0 Then Dist_mm = 0
            If Dist_mm > MaxD Then Dist_mm = MaxD
            ' ----------------------------------------------------------- range
            Dim range As Double = MaxD - MinD
            If range < 0.1 Then range = 0.1
            Value_Normalized_New = 1 - CSng((Dist_mm - MinD) / range)
        Else
            Cap_input = 0
            Dist_mm = 0
            Value_Normalized_New = Cap_total / 1000
        End If

    End Sub

End Class


