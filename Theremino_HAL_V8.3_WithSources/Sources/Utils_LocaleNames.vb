Imports System.Windows.Forms

Module Utils_LocaleNames

    Friend Language As String = "English"
    Private ls(1, -1) As String

    Friend Sub SetLocales()
        ' ------------------------------------- read the file
        ReadLocaleFile()
        ' ------------------------------------- rename
        RenameControls(Form1)
        RenameControls(Form2)
        ' ------------------------------------- release the array
        RedimPreserve_2D_Array(ls, -1, -1)
    End Sub

    Private Sub ReadLocaleFile()
        Dim LangName As String = Strings.Left(Language, 3).ToUpper.Replace("JAP", "JPN")
        Dim locfilename As String = PlatformAdjustedFileName(Application.StartupPath & "\Docs\Language_" & LangName & ".txt")
        If Not FileExists(locfilename) Then
            locfilename = PlatformAdjustedFileName(Application.StartupPath & "\Docs\Language_ENG.txt")
        End If
        If FileExists(locfilename) Then
            Dim i As Int32 = -1
            Dim s0 As String
            Dim s1 As String
            '
            Dim f As IO.StreamReader
            f = New System.IO.StreamReader(locfilename, System.Text.Encoding.Default)
            '
            Do While Not f.EndOfStream
                s1 = f.ReadLine()
                s1 = Trim(s1.Replace(vbTab, " "))
                s0 = ExtractParamName(s1)
                If s0.Length > 1 And s1.Length > 1 Then
                    If s0.StartsWith("Msg_") Then
                        AddMessage(s0, s1)
                    Else
                        i += 1
                        RedimPreserve_2D_Array(ls, 1, i)
                        ls(0, i) = s0
                        ls(1, i) = s1
                    End If
                End If
            Loop
            f.Close()
        End If
    End Sub

    ' ===============================================================================================
    '  RENAME CONTROLS
    ' ===============================================================================================
    Private Sub RenameControls(ByVal container As Control)
        '
        For i As Int32 = 0 To ls.GetLength(1) - 1
            If container.Name = ls(0, i) Then
                container.Text = ls(1, i)
            End If
        Next
        '
        For Each ctrl As Control In container.Controls
            For i As Int32 = 0 To ls.GetLength(1) - 1

                If ctrl.Name = ls(0, i) Then
                    ctrl.Text = ls(1, i)
                End If

                If TypeOf ctrl Is ToolStrip Then
                    Dim ts As ToolStrip = DirectCast(ctrl, ToolStrip)
                    RenameToolStripItems(ts)
                End If

                If TypeOf ctrl Is MenuStrip Then
                    Dim ms As MenuStrip = DirectCast(ctrl, MenuStrip)
                    RenameMenuStripItems(ms)
                End If
            Next
            ' ---------------------------- Recursively call this function for any container controls.
            If container.HasChildren Then
                RenameControls(ctrl)
            End If
        Next
    End Sub

    Private Sub RenameToolStripItems(ByRef ts As ToolStrip)
        For i As Int32 = 0 To ls.GetLength(1) - 1
            For j As Int32 = 0 To ts.Items.Count - 1
                If ts.Items(j).Name = ls(0, i) Then
                    ts.Items(j).Text = " " & ls(1, i)
                End If
            Next
        Next
    End Sub

    Private Sub RenameMenuStripItems(ByRef ms As MenuStrip)
        For i As Int32 = 0 To ls.GetLength(1) - 1
            For j As Int32 = 0 To ms.Items.Count - 1
                If ms.Items(j).Name = ls(0, i) Then
                    ms.Items(j).Text = " " & ls(1, i)
                End If
                Dim tsmi As ToolStripMenuItem = DirectCast(ms.Items(j), ToolStripMenuItem)
                For k As Int32 = 0 To tsmi.DropDownItems.Count - 1
                    If tsmi.DropDownItems(k).Name = ls(0, i) Then
                        tsmi.DropDownItems(k).Text = " " & ls(1, i)
                    End If
                Next
            Next
        Next
    End Sub

    ' ===============================================================================================
    '  MESSAGES
    ' ===============================================================================================
    Friend Msg_CommSpeed1 As String = " Communication speed"

    Friend Msg_MinChange1 As String = " Sensitivity to movements"
    Friend Msg_MinChange2 As String = " - - - - - - - - - - - - - - - - -"
    Friend Msg_MinChange3 As String = " 100 = large movements"
    Friend Msg_MinChange4 As String = "   30 = normal"
    Friend Msg_MinChange5 As String = "   10 = little movements"
    Friend Msg_MinChange6 As String = "    0 = autocalibrate disabled"

    Friend Msg_CapArea1 As String = " Approximate area of the sensor"
    Friend Msg_CapArea2 As String = " - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -"
    Friend Msg_CapArea3 As String = " The linearity between zones 'Away' and 'Close' can be altered"
    Friend Msg_CapArea4 As String = " setting a value-area more or less than the real one."
    Friend Msg_CapArea5 As String = " - A greater value compresses the 'far' area."
    Friend Msg_CapArea6 As String = " - A smaller value expands the 'far' area."
    Friend Msg_CapArea7 As String = " - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -"
    Friend Msg_CapArea8 As String = " With ZERO the C_tot value is used, instead of calculated value."

    Friend Msg_Filter1 As String = " Pressing this button the IIR filter becomes adaptive"
    Friend Msg_Filter2 As String = " - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -"
    Friend Msg_Filter3 As String = " The IIR filter adapts itself to obtain a higher reactivity"
    Friend Msg_Filter4 As String = " for wide variations and greater damping for minor changes."
    Friend Msg_Filter5 As String = " This way you get a good digits stability, without sacrificing the settling time."

    Friend Msg_Recognize1 As String = " Recognizes Masters and Slaves connected to the USB"
    Friend Msg_Validate1 As String = " Validates a configuration after hardware changes"
    Friend Msg_BeepOnErrors1 As String = " Make a beep for each serial error"
    Friend Msg_Lock1 As String = " If pressed the HAL will connect only Masters with names actually listed"
    Friend Msg_Lock2 As String = " (refer to the last pages of the help)"
    Friend Msg_Disconnect1 As String = " Disconnect the selected Master"

    Friend Msg_Warning As String = " WARNING"
    Friend Msg_HalMessage As String = " Message from Theremino HAL"
    Friend Msg_StepperWithAdc24 As String = " The Adc24 module performs poorly if, in the same Master, you enable also Stepper channels."

    Friend Msg_Validate2 As String = " The configuration does not match the connected hardware."
    Friend Msg_Validate3 As String = " Check the hardware and connections and try again with the 'Validate' button."
    Friend Msg_Validate4 As String = " Or choose a valid configuration changing the 'Master Name'"
    Friend Msg_Validate5 As String = " Or replace the previous configuration with the current one, by pressing 'Valid'."

    Friend Msg_Duplicate1 As String = " There are two Master Modules with the same name."
    Friend Msg_Duplicate2 As String = " Please select the first Master and choose another name."

    Friend Msg_MaxValue As String = "Max value"
    Friend Msg_MinValue As String = "Min value"
    Friend Msg_MaxValueStepper As String = "1000 means mm"
    Friend Msg_MinValueStepper As String = "zero means mm"
    Friend Msg_PwmProps As String = "PWM properties"
    Friend Msg_ServoProps As String = "Servo properties"
    Friend Msg_UsoundProps As String = "UltraSound properties"
    Friend Msg_CapSensorProps As String = "Cap sensor properties"


    Private Sub AddMessage(ByVal s0 As String, ByVal s1 As String)
        Select Case s0
            Case "Msg_CommSpeed1" : Msg_CommSpeed1 = s1

            Case "Msg_MinChange1" : Msg_MinChange1 = s1
            Case "Msg_MinChange2" : Msg_MinChange2 = s1
            Case "Msg_MinChange3" : Msg_MinChange3 = s1
            Case "Msg_MinChange4" : Msg_MinChange4 = s1
            Case "Msg_MinChange5" : Msg_MinChange5 = s1
            Case "Msg_MinChange6" : Msg_MinChange6 = s1

            Case "Msg_CapArea1" : Msg_CapArea1 = s1
            Case "Msg_CapArea2" : Msg_CapArea2 = s1
            Case "Msg_CapArea3" : Msg_CapArea3 = s1
            Case "Msg_CapArea4" : Msg_CapArea4 = s1
            Case "Msg_CapArea5" : Msg_CapArea5 = s1
            Case "Msg_CapArea6" : Msg_CapArea6 = s1
            Case "Msg_CapArea7" : Msg_CapArea7 = s1
            Case "Msg_CapArea8" : Msg_CapArea8 = s1

            Case "Msg_Filter1" : Msg_Filter1 = s1
            Case "Msg_Filter2" : Msg_Filter2 = s1
            Case "Msg_Filter3" : Msg_Filter3 = s1
            Case "Msg_Filter4" : Msg_Filter4 = s1
            Case "Msg_Filter5" : Msg_Filter5 = s1

            Case "Msg_Recognize1" : Msg_Recognize1 = s1
            Case "Msg_Validate1" : Msg_Validate1 = s1
            Case "Msg_BeepOnErrors1" : Msg_BeepOnErrors1 = s1
            Case "Msg_Lock1" : Msg_Lock1 = s1
            Case "Msg_Lock2" : Msg_Lock2 = s1
            Case "Msg_Disconnect1" : Msg_Disconnect1 = s1

            Case "Msg_Warning" : Msg_Warning = s1
            Case "Msg_HalMessage" : Msg_HalMessage = s1
            Case "Msg_StepperWithAdc24" : Msg_StepperWithAdc24 = s1

            Case "Msg_Validate2" : Msg_Validate2 = s1
            Case "Msg_Validate3" : Msg_Validate3 = s1
            Case "Msg_Validate4" : Msg_Validate4 = s1
            Case "Msg_Validate5" : Msg_Validate5 = s1

            Case "Msg_Duplicate1" : Msg_Duplicate1 = s1
            Case "Msg_Duplicate2" : Msg_Duplicate2 = s1

            Case "Msg_MaxValue" : Msg_MaxValue = s1
            Case "Msg_MinValue" : Msg_MinValue = s1
            Case "Msg_MaxValueStepper" : Msg_MaxValueStepper = s1
            Case "Msg_MinValueStepper" : Msg_MinValueStepper = s1
            Case "Msg_PwmProps" : Msg_PwmProps = s1
            Case "Msg_ServoProps" : Msg_ServoProps = s1
            Case "Msg_UsoundProps" : Msg_UsoundProps = s1
            Case "Msg_CapSensorProps" : Msg_CapSensorProps = s1

        End Select
    End Sub

End Module
