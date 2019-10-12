Public Class Form2

    Private Scope As Class_DataScope
    Private VerticalZoom As Single
    Private ScrollSpeed As Single

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Scope = New Class_DataScope(pbox_ScrollingScope)
        SetScrollSpeed()
        SetUnitsPerDivision()
        SleepMyThread(100)
        TheSystem_CalibrateZero()
        SetScaleLabels()
    End Sub

    Private Sub Form2_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged, _
                                                                                                  Me.SizeChanged
        StartTimer()
    End Sub

    Private Sub Form2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Scope = New Class_DataScope(pbox_ScrollingScope)
    End Sub

    Friend Sub StopTimer()
        Timer_60Hz.Stop()
    End Sub

    Friend Sub StartTimer()
        If Visible And WindowState <> FormWindowState.Minimized Then
            Timer_60Hz.Interval = 15
            Timer_60Hz.Start()
        Else
            Timer_60Hz.Stop()
        End If
    End Sub

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        GroupBox1.BackColor = Color.LightGoldenrodYellow
        Me.Hide()
        e.Cancel = True
    End Sub

    Private Sub Form2_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        If Not EventsAreEnabled Then Return
        LimitFormPosition(Me)
    End Sub

    Private Sub Timer_60Hz_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_60Hz.Tick
        If Not EventsAreEnabled Then Return
        ' --------------------------------------------------- 
        'TimerRepetition_TestMeter()
        ' --------------------------------------------------- 
        ShowDetails()
        If btn_Run.Checked Then UpdateScrollingScope()
    End Sub

    'Private Sub TimerRepetition_TestMeter()
    '    Static t As Stopwatch = New Stopwatch
    '    Static newt As Double
    '    Static oldt As Double
    '    Static meant As Double
    '    t.Start()
    '    newt = t.Elapsed.TotalMilliseconds
    '    meant = meant + 0.03 * ((newt - oldt) - meant)
    '    oldt = newt
    '    Text = meant.ToString("0.00 mS")
    'End Sub

    Private SelectedPin As Pin
    Private AlternatePin As Pin
    Friend SelectedPinListLine As Int32
    Friend AlternatePinListLine As Int32

    Friend Sub RestoreSelectedPins()
        SelectedPin = Nothing
        AlternatePin = Nothing
        pbox_ScrollingScope.Visible = True
        LabelPin1.Text = "- - -"
        lbl_Details1.Text = ""
        FillPictureBox(pbox_Details1, 0, Color.Orange, Color.AliceBlue)
        LabelPin2.Text = "- - -"
        lbl_Details2.Text = ""
        FillPictureBox(pbox_Details2, 0, Color.Orange, Color.AliceBlue)
        ' ----------------------------------------------------------------- recover selected pins from list lines
        SelectedPin = FindPinByListLine(SelectedPinListLine)
        AlternatePin = FindPinByListLine(AlternatePinListLine)
        InitializePinDetails()
    End Sub

    Friend Sub SetPinDetails()
        Dim p As Pin = GetSelectedPin()
        If p Is Nothing Then Return
        '
        Dim l As Int32 = GetSelectedListLine()
        '
        If p Is SelectedPin Then
            AlternatePin = Nothing
            AlternatePinListLine = 0
            SelectedPin = p
            SelectedPinListLine = l
        Else
            AlternatePin = SelectedPin
            AlternatePinListLine = SelectedPinListLine
            SelectedPin = p
            SelectedPinListLine = l
        End If
        InitializePinDetails()
    End Sub

    Private Sub InitializePinDetails()
        If SelectedPin IsNot Nothing Then
            LabelPin1.Text = ComposePinString(SelectedPin)
        End If
        If AlternatePin IsNot Nothing Then
            LabelPin2.Text = ComposePinString(AlternatePin)
        Else
            LabelPin2.Text = "- - -"
            lbl_Details2.Text = ""
            FillPictureBox(pbox_Details2, 0, Color.Orange, Color.AliceBlue)
        End If
        '
        'TheSystem_CalibrateZero()
        '
        SetScaleLabels()
    End Sub

    Private Function ComposePinString(ByVal p As Pin) As String
        ' ------------------------------------------------------- Slot name
        Dim s As String = SlotNames(p.Slot)
        If s <> "" Then Return s
        ' ------------------------------------------------------- Master / Slave / Pin
        Dim npin As Int32 = p.PinId + 1
        If npin <= 12 Then
            Return "M:" & (p.MasterId + 1).ToString & _
           " S:" & (p.SlaveId + 1).ToString & _
           " Pin:" & npin.ToString
        Else
            Return "M:" & (p.MasterId + 1).ToString & _
                   " Adc24" & _
                   " Pin:" & (npin - 12).ToString
        End If
    End Function
    ' ---------------------------------------------------------

    Private Sub ShowDetails()
        Static divisor As Int32
        divisor += 1
        If divisor >= 2 Then ' 2 = 30 executions per second (timer 60Hz divided by 2)
            divisor = 0
            If SelectedPin IsNot Nothing Then
                lbl_Details1.Text = SelectedPin.GetValueString()
                FillPictureBox(pbox_Details1, SelectedPin.Value_Normalized, Color.Orange, Color.AliceBlue)
            End If
            If AlternatePin IsNot Nothing Then
                lbl_Details2.Text = AlternatePin.GetValueString()
                FillPictureBox(pbox_Details2, AlternatePin.Value_Normalized, Color.Orange, Color.AliceBlue)
            End If
        End If
    End Sub

    Private Sub btn_SetZero_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles btn_SetZero.ClickButtonArea
        TheSystem_CalibrateZero()
        SetScaleLabels()
    End Sub

    Private Sub btn_ShowRawCount_ClickButtonArea(ByVal Sender As System.Object, ByVal e As System.EventArgs) Handles btn_ShowRawCount.ClickButtonArea
        TheSystem_CalibrateZero()
        SetScaleLabels()
    End Sub

    Private Sub UpdateScrollingScope()
        If Not pbox_ScrollingScope.Visible Then Return
        Dim v1 As Single = -999
        Dim v2 As Single = -999
        '
        If cmb_UnitsPerDivision.SelectedIndex = 0 Then
            If btn_ShowRawCount.Checked Then
                If SelectedPin IsNot Nothing Then
                    Dim v As Double = (SelectedPin.Value_RawUinteger - txt_ScaleMin.NumericValue) / (txt_ScaleMax.NumericValue - txt_ScaleMin.NumericValue)
                    v1 = pbox_ScrollingScope.Height * 0.49F * (0.5F - CSng(v))
                End If
                If AlternatePin IsNot Nothing Then
                    Dim v As Double = (AlternatePin.Value_RawUinteger - txt_ScaleMin.NumericValue) / (txt_ScaleMax.NumericValue - txt_ScaleMin.NumericValue)
                    v2 = pbox_ScrollingScope.Height * 0.49F * (0.5F - CSng(v))
                End If
            Else
                If SelectedPin IsNot Nothing Then
                    Dim v As Double = (SelectedPin.Value - txt_ScaleMin.NumericValue) / (txt_ScaleMax.NumericValue - txt_ScaleMin.NumericValue)
                    v1 = pbox_ScrollingScope.Height * 0.49F * (0.5F - CSng(v))
                End If
                If AlternatePin IsNot Nothing Then
                    Dim v As Double = (AlternatePin.Value - txt_ScaleMin.NumericValue) / (txt_ScaleMax.NumericValue - txt_ScaleMin.NumericValue)
                    v2 = pbox_ScrollingScope.Height * 0.49F * (0.5F - CSng(v))
                End If
            End If
        Else
            If btn_ShowRawCount.Checked Then
                If SelectedPin IsNot Nothing Then
                    v1 = (SelectedPin.Value_RawUinteger_Zero - CLng(SelectedPin.Value_RawUinteger)) * VerticalZoom / 100.0F
                End If
                If AlternatePin IsNot Nothing Then
                    v2 = (AlternatePin.Value_RawUinteger_Zero - CLng(AlternatePin.Value_RawUinteger)) * VerticalZoom / 100.0F
                End If
            Else
                If SelectedPin IsNot Nothing Then
                    v1 = pbox_ScrollingScope.Height * 0.49F * (SelectedPin.Value_Zero - SelectedPin.Value) * VerticalZoom / 1000
                End If
                If AlternatePin IsNot Nothing Then
                    v2 = pbox_ScrollingScope.Height * 0.49F * (AlternatePin.Value_Zero - AlternatePin.Value) * VerticalZoom / 1000
                End If
            End If
        End If
        Scope.Display(v1, v2, ScrollSpeed)
    End Sub


    Private Sub SetScaleLabels()
        '
        Dim FS As String = "0.#"
        Label_Scale3.Text = ""
        Label_Scale2.Text = ""
        Label_Scale1.Text = ""
        Label_Scale3b.Text = ""
        Label_Scale2b.Text = ""
        Label_Scale1b.Text = ""
        '
        If cmb_UnitsPerDivision.SelectedIndex = 0 Then
            Select Case Math.Abs(txt_ScaleMax.NumericValue - txt_ScaleMin.NumericValue)
                Case Is <= 0.0001 : FS = "0.#####"
                Case Is <= 0.001 : FS = "0.####"
                Case Is <= 0.01 : FS = "0.###"
                Case Is <= 0.1 : FS = "0.##"
            End Select
            If SelectedPin IsNot Nothing Or AlternatePin IsNot Nothing Then
                Label_Scale3.Text = txt_ScaleMax.NumericValue.ToString(FS, GCI)
                Label_Scale2.Text = ((txt_ScaleMin.NumericValue + txt_ScaleMax.NumericValue) / 2.0F).ToString(FS, GCI)
                Label_Scale1.Text = txt_ScaleMin.NumericValue.ToString(FS, GCI)
                Label_Scale3.Refresh()
                Label_Scale2.Refresh()
                Label_Scale1.Refresh()
            End If
        Else
            Select Case cmb_UnitsPerDivision.Text
                Case "0.05", "0.02", "0.01" : FS = "0.##"
                Case "0.005", "0.002", "0.001" : FS = "0.###"
                Case "0.0005", "0.0002", "0.0001" : FS = "0.####"
            End Select
            If btn_ShowRawCount.Checked Then
                If SelectedPin IsNot Nothing Then
                    Label_Scale3.Text = (SelectedPin.Value_RawUinteger_Zero + 6800 / VerticalZoom).ToString(FS, GCI)
                    Label_Scale2.Text = SelectedPin.Value_RawUinteger_Zero.ToString(FS, GCI)
                    Label_Scale1.Text = (SelectedPin.Value_RawUinteger_Zero - 6800 / VerticalZoom).ToString(FS, GCI)
                End If
                If AlternatePin IsNot Nothing Then
                    Label_Scale3b.Text = (AlternatePin.Value_RawUinteger_Zero + 6800 / VerticalZoom).ToString(FS, GCI)
                    Label_Scale2b.Text = AlternatePin.Value_RawUinteger_Zero.ToString(FS, GCI)
                    Label_Scale1b.Text = (AlternatePin.Value_RawUinteger_Zero - 6800 / VerticalZoom).ToString(FS, GCI)
                End If
            Else
                If SelectedPin IsNot Nothing Then
                    Dim zv As Single = SelectedPin.Value_Zero
                    Label_Scale3.Text = (zv + 500 / VerticalZoom).ToString(FS, GCI)
                    Label_Scale2.Text = zv.ToString(FS, GCI)
                    Label_Scale1.Text = (zv - 500 / VerticalZoom).ToString(FS, GCI)
                End If
                If AlternatePin IsNot Nothing Then
                    Dim zv As Single = AlternatePin.Value_Zero
                    Label_Scale3b.Text = (zv + 500 / VerticalZoom).ToString(FS, GCI)
                    Label_Scale2b.Text = zv.ToString(FS, GCI)
                    Label_Scale1b.Text = (zv - 500 / VerticalZoom).ToString(FS, GCI)
                End If
            End If
        End If
    End Sub

    ' ====================================================================================================
    '   Scale Min-Max
    ' ====================================================================================================
    Private Sub txt_ScaleMax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ScaleMax.TextChanged
        SetScaleLabels()
    End Sub
    Private Sub txt_ScaleMin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_ScaleMin.TextChanged
        SetScaleLabels()
    End Sub

    ' ====================================================================================================
    '   COMBO UnitsPerDivision
    ' ====================================================================================================
    Private Sub cmb_UnitsPerDivision_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_UnitsPerDivision.DropDown
        cmb_UnitsPerDivision.ItemHeight = 16
    End Sub
    Private Sub cmb_UnitsPerDivision_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_UnitsPerDivision.DropDownClosed
        cmb_UnitsPerDivision.ItemHeight = 12
    End Sub
    Private Sub cmb_UnitsPerDivision_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_UnitsPerDivision.SelectedIndexChanged
        SetUnitsPerDivision()
        cmb_UnitsPerDivision.Refresh()
    End Sub
    Private Sub SetUnitsPerDivision()
        VerticalZoom = CSng(Val(cmb_UnitsPerDivision.Text)) / 100
        If VerticalZoom = 0 Then VerticalZoom = 1
        VerticalZoom = 1 / VerticalZoom
        SetScaleLabels()
        If cmb_UnitsPerDivision.SelectedIndex = 0 Then
            btn_SetZero.Enabled = False
            txt_ScaleMax.Enabled = True
            txt_ScaleMin.Enabled = True
        Else
            btn_SetZero.Enabled = True
            txt_ScaleMax.Enabled = False
            txt_ScaleMin.Enabled = False
        End If
    End Sub

    ' ====================================================================================================
    '   COMBO ScrollSpeed
    ' ====================================================================================================
    Private Sub cmb_UScrollSpeed_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_ScrollSpeed.DropDown
        cmb_ScrollSpeed.ItemHeight = 16
    End Sub
    Private Sub cmb_ScrollSpeed_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_ScrollSpeed.DropDownClosed
        cmb_ScrollSpeed.ItemHeight = 12
    End Sub
    Private Sub cmb_ScrollSpeed_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmb_ScrollSpeed.SelectedIndexChanged
        SetScrollSpeed()
    End Sub
    Private Sub SetScrollSpeed()
        ScrollSpeed = CSng(Val(cmb_ScrollSpeed.Text))
    End Sub

End Class