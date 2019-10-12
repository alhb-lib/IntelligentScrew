Module Module_Utils

    ' =======================================================================================================
    '   APP TITLE AND VERSION
    ' =======================================================================================================
    Friend Function AppTitleAndVersion(Optional ByVal Title As String = "") As String
        If Title = "" Then Title = Replace(My.Application.Info.AssemblyName, "_", " ")
        Dim s() As String = Split(My.Application.Info.Version.ToString, ".")
        Return Title & " - V" & s(0) & "." & s(1)
    End Function

    Friend Function AppVersion() As String
        Dim s() As String = Split(My.Application.Info.Version.ToString, ".")
        Return s(0) & "." & Val(s(1)).ToString("00")
    End Function

    ' =======================================================================================================
    '   CULTURE INFO FOR STRING CONVERSIONS
    ' =======================================================================================================
    Friend GCI As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture

    ' =======================================================================================================
    '   MIXED FUNCTIONS
    ' =======================================================================================================
    'Friend Function ReplaceMultipleSpacesAndTrim(ByVal s As String) As String
    '    s = s.Replace(vbTab, " ")
    '    While s.Contains("  ")
    '        s = s.Replace("  ", " ")
    '    End While
    '    Return s.Trim
    'End Function
    'Friend Function RemoveComments(ByVal s As String) As String
    '    Dim i As Int32 = s.IndexOf("'")
    '    If i > 0 Then s = s.Remove(i).TrimEnd
    '    If i = 0 Then s = ""
    '    Return s
    'End Function



    '' =========================================================================
    ''  WINDOWS SCHEDULER PRECISION
    '' ========================================================================= 
    'Private Declare Function timeBeginPeriod Lib "winmm.dll" (ByVal uPeriod As Int32) As Int32
    'Private Declare Function timeEndPeriod Lib "winmm.dll" (ByVal uPeriod As Int32) As Int32
    'Friend Sub SchedulerMaxPrecision()
    '    If OperatingSystemIsWindows Then
    '        timeBeginPeriod(1)
    '    End If
    'End Sub
    'Friend Sub SchedulerDefaultPrecision()
    '    If OperatingSystemIsWindows Then
    '        timeEndPeriod(1)
    '    End If
    'End Sub

    Friend Sub InitPictureboxImage(ByVal pbox As PictureBox)
        With pbox
            If .ClientSize.Width < 1 Or .ClientSize.Height < 1 Then Return
            .Image = New Bitmap(.ClientSize.Width, .ClientSize.Height)
        End With
    End Sub

    'Friend Sub InitBitmap(ByRef bmp As Bitmap, ByVal w As Int32, ByVal h As Int32)
    '    If w < 1 Or h < 1 Then Return
    '    bmp = New Bitmap(w, h)
    'End Sub

    Friend Sub Combo_SetIndex(ByVal combo As ComboBox, ByVal index As Int32)
        If combo.Items.Count < 1 Then Exit Sub
        If index < 0 Then index = 0
        If index > combo.Items.Count - 1 Then index = combo.Items.Count - 1
        combo.SelectedIndex = index
    End Sub


    'Friend Function SecondsToMinSec(ByVal seconds As Double) As String
    '    Dim t As TimeSpan = TimeSpan.FromSeconds(seconds)
    '    Return t.Minutes.ToString("00") + ":" + t.Seconds.ToString("00")
    'End Function

    Friend Function RemoveComments(ByVal s As String) As String
        Dim i As Int32 = s.IndexOf("'")
        If i > 0 Then s = s.Remove(i).TrimEnd
        If i = 0 Then s = ""
        Return s
    End Function

    ' ========================================================
    '   PROCESS START AND WAIT
    ' ========================================================
    Friend Sub ProcessStartAndWait(ByVal fname As String)
        If Not My.Computer.FileSystem.FileExists(fname) Then Return
        Dim p As Process = Process.Start(fname)
        Do
            System.Threading.Thread.Sleep(100)
        Loop Until p.HasExited
    End Sub

    ' ========================================================
    '   SWAP
    ' ========================================================
    Public Sub Swap(Of T)(ByRef a As T, ByRef b As T)
        Dim temp As T
        temp = a
        a = b
        b = temp
    End Sub

End Module
