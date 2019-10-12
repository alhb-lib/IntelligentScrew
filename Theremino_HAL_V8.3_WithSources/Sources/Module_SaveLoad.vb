

Module Module_SaveLoad

    Friend EventsAreEnabled As Boolean = False
    'Friend Form1_VisibleAtStart As Boolean
    Friend Form2_VisibleAtStart As Boolean

    ' =======================================================================================================
    '   APP TITLE AND VERSION
    ' =======================================================================================================
    Friend Function AppTitleAndVersion(Optional ByVal Title As String = "") As String
        If Title = "" Then Title = Replace(My.Application.Info.AssemblyName, "_", " ")
        Dim s() As String = Split(My.Application.Info.Version.ToString, ".")
        Return Title & " - V" & s(0) & "." & s(1)
    End Function

    ' =======================================================================================================
    '   Files
    ' =======================================================================================================
    ' returns lower-case extension with initial dot
    Public Function GetExtension(ByVal str As String) As String
        On Error Resume Next
        Return LCase(IO.Path.GetExtension(str))
    End Function
    Public Function RemoveExtension(ByVal str As String) As String
        On Error Resume Next
        Return PlatformAdjustedFileName(IO.Path.GetDirectoryName(str) & "\" & IO.Path.GetFileNameWithoutExtension(str))
    End Function
    Public Function FileExists(ByVal fileName As String) As Boolean
        Return My.Computer.FileSystem.FileExists(fileName)
    End Function
    Public Function FolderExists(ByVal FolderName As String) As Boolean
        If FolderName.Length < 2 Then Return False
        If OperatingSystemIsWindows Then
            FolderName = LCase(FolderName)
            Select Case FolderName
                Case "a:\", "b:\", "c:\", "d:\", "e:\", "f:\", "g:\", "h:\", "i:\", "j:\", "k:\"
                    Return True
            End Select
        End If
        Return My.Computer.FileSystem.DirectoryExists(FolderName)
    End Function


    ' =======================================================================================
    '  FORM
    ' =======================================================================================
    Friend Sub LimitFormPosition(ByVal f As System.Windows.Forms.Form)
        If f.WindowState <> FormWindowState.Normal Then Return
        GetMaxScreenBounds()
        EnsureFormVisible(f)
        'EnsureFormCompletelyVisible(f)
    End Sub
    Private SB As Rectangle = New Rectangle(Integer.MaxValue, Integer.MaxValue, Integer.MinValue, Integer.MinValue)
    Private Sub GetMaxScreenBounds()
        For Each s As Screen In System.Windows.Forms.Screen.AllScreens
            SB = Rectangle.Union(SB, s.WorkingArea)
        Next
    End Sub
    Private Sub EnsureFormCompletelyVisible(ByVal frm As Form)
        With frm
            .Width = Math.Min(.Width, SB.Width)         ' not more than dimensions of a maximized window
            .Height = Math.Min(.Height, SB.Height)      ' not more than dimensions of a maximized window
            .Width = Math.Max(.Width, 32)               ' at least 32x24
            .Height = Math.Max(.Height, 24)             ' at least 32x24
            .Left = Math.Min(.Left, SB.Right - .Width)  ' not beyond the right border
            .Top = Math.Min(.Top, SB.Bottom - .Height)  ' not beyond the bottom border
            .Left = Math.Max(.Left, SB.Left)            ' at least at the left border
            .Top = Math.Max(.Top, SB.Top)               ' at least at the top border
        End With
    End Sub
    Private Sub EnsureFormVisible(ByVal frm As Form)
        With frm
            .Width = Math.Min(.Width, SB.Width)             ' not more than the VIRTUALSCREEN dimensions
            .Height = Math.Min(.Height, SB.Height)          ' not more than the VIRTUALSCREEN dimensions 
            .Width = Math.Max(.Width, 32)                   ' at least 32x24
            .Height = Math.Max(.Height, 24)                 ' at least 32x24
            .Left = Math.Min(.Left, SB.Right - 50)          ' not beyond the right border - 50 pixels
            .Top = Math.Min(.Top, SB.Bottom - 100)          ' not beyond the bottom border - 50 pixels
            .Left = Math.Max(.Left, SB.Left + 100 - .Width) ' at least at the left border + 50 pixels
            .Top = Math.Max(.Top, SB.Top - 10)              ' at least at the top border
        End With
    End Sub
    ' (The value of the RestoreBounds property is valid only 
    '   when the WindowState property of the Form class is not equal to Normal)
    Friend Function GetFormRectangle(ByVal frm As Form) As Rectangle
        Dim r As Rectangle
        If frm.WindowState = FormWindowState.Normal Then
            r = frm.Bounds
        Else
            r = frm.RestoreBounds
        End If
        Return r
    End Function

    Friend Sub LimitComboDropDownHeight(ByRef cmb As MyComboBox)
        ' ---------------------------------------------------- get screen height
        Dim screenHeight As Int32
        screenHeight = Screen.PrimaryScreen.Bounds.Height
        ' ---------------------------------------------------- get required height
        Dim h As Int32 = cmb.ItemHeight * cmb.Items.Count
        ' ---------------------------------------------------- get screen positions
        Dim yUp As Int32 = cmb.PointToScreen(cmb.ClientRectangle.Location).Y
        Dim yDown As Int32 = yUp + cmb.Height
        ' ---------------------------------------------------- set the combo height
        If yDown + h > screenHeight - 1 And yUp - h < 4 Then
            cmb.DropDownHeight = yUp - 4
        Else
            cmb.DropDownHeight = 999
        End If
    End Sub


    ' ================================================================================================
    '  Private Read-Write functions
    ' ================================================================================================
    Private Function TabString(ByVal Name As String, _
                              Optional ByVal Value As Double = Double.NaN, _
                              Optional ByVal fmt As String = "") As String

        Dim nTab As Int32 = Math.Max(0, 22 - Name.Length)
        If Double.IsNaN(Value) Then
            Return Name
        Else
            Return Name & "=" & Strings.StrDup(nTab, " ") & Value.ToString(fmt)
        End If
    End Function
    Private Function TabString(ByVal Name As String, _
                                  ByVal Value As Boolean) As String

        Dim nTab As Int32 = Math.Max(0, 22 - Name.Length)

        Return Name & "=" & Strings.StrDup(nTab, " ") & Value.ToString
    End Function
    Private Function TabString(ByVal Name As String, _
                                ByVal Value As String) As String

        Dim nTab As Int32 = Math.Max(0, 22 - Name.Length)

        Return Name & "=" & Strings.StrDup(nTab, " ") & Value
    End Function
    Private Function Val_Single(ByVal l As String) As Single
        Return CSng(Val(l.Replace(",", ".")))
    End Function
    Private Function Val_Double(ByVal l As String) As Double
        Return Val(l.Replace(",", "."))
    End Function
    Private Function Val_Int(ByVal l As String) As Int32
        Return CInt(Val(l))
    End Function
    Friend Function ExtractParamName(ByRef s As String) As String
        ' ------------------------- Returns the first field from begin to the first "=" symbol
        ' -------------------------  and removes it from the string
        Dim i As Integer
        i = InStr(s, "=")
        If i > 0 Then
            ExtractParamName = Trim(Strings.Left(s, i - 1))
            s = Trim(Mid(s, i + 1))
        Else
            ExtractParamName = Trim(s)
            s = ""
        End If
    End Function
    Private Function AssemblyName() As String
        Return System.Reflection.Assembly.GetExecutingAssembly.GetName.Name
    End Function


    ' ==================================================================================================
    '  SAVE LOAD -- Program INI
    ' ==================================================================================================
    Friend Sub Save_INI()
        Dim iniFileName As String = PlatformAdjustedFileName(Application.StartupPath & "\" & AssemblyName() & "_INI.txt")
        Dim f As System.IO.StreamWriter = Nothing
        Try
            f = IO.File.CreateText(iniFileName)
            '
            f.WriteLine("")
            f.WriteLine("===========================================")
            f.WriteLine(" Program Params")
            f.WriteLine("===========================================")
            ' ------------------------------------------------------------------------------ FORM BOUNDS
            Dim r As Rectangle
            r = GetFormRectangle(Form1)
            f.WriteLine(TabString("Form1_Top", r.Top))
            f.WriteLine(TabString("Form1_Left", r.Left))
            f.WriteLine(TabString("Form1_Width", r.Width))
            f.WriteLine(TabString("Form1_Height", r.Height))
            f.WriteLine(TabString("Form1_WindowState", Form1.WindowState))
            'f.WriteLine(TabString("Form1_VisibleAtStart", Form1.Visible And Form1.WindowState <> FormWindowState.Minimized))
            '
            r = GetFormRectangle(Form2)
            f.WriteLine(TabString("Form2_Top", r.Top))
            f.WriteLine(TabString("Form2_Left", r.Left))
            f.WriteLine(TabString("Form2_Width", r.Width))
            f.WriteLine(TabString("Form2_Height", r.Height))
            f.WriteLine(TabString("Form2_VisibleAtStart", Form2.Visible And Form2.WindowState <> FormWindowState.Minimized))
            '
            f.WriteLine("")
            f.WriteLine(TabString("Language", Language))
            f.WriteLine(TabString("Reconnect", Form1.btn_Reconnect.Checked))
            f.WriteLine(TabString("MinChange", Form1.txt_MinChange.NumericValueInteger))
            f.WriteLine(TabString("BeepOnErrors", Form1.ToolStripButton_BeepOnErrors.Checked))
            f.WriteLine(TabString("Lock", Form1.ToolStripButton_Lock.Checked))
            '
            f.WriteLine("")
            f.WriteLine(TabString("SelectedPinListLine", Form2.SelectedPinListLine))
            f.WriteLine(TabString("AlternatePinListLine", Form2.AlternatePinListLine))
            f.WriteLine(TabString("Scope_ShowRawCount", Form2.btn_ShowRawCount.Checked))
            f.WriteLine(TabString("Scope_UnitsPerDivision", Form2.cmb_UnitsPerDivision.SelectedIndex))
            f.WriteLine(TabString("Scope_ScrollSpeed", Form2.cmb_ScrollSpeed.SelectedIndex))
            f.WriteLine(TabString("Scope_ScaleMax", Form2.txt_ScaleMax.Text))
            f.WriteLine(TabString("Scope_ScaleMin", Form2.txt_ScaleMin.Text))
            '
            f.WriteLine("")
            For Each s As String In ValidMasterNames
                f.WriteLine(TabString("ValidMasterName", s))
            Next
            '
            f.WriteLine("")
            f.WriteLine(TabString("CommandSlot", CommandSlot))
        Catch
        End Try
        Try
            f.Close()
        Catch
        End Try
    End Sub

    Friend Sub Load_INI()
        ReDim ValidMasterNames(-1)
        ReDim ConfigDatabase(-1)
        Dim Config(-1) As String
        ' ------------------------------------------------------------- defaults
        'Form1_VisibleAtStart = True
        Form1.txt_MinChange.NumericValueInteger = 30
        Form2.cmb_ScrollSpeed.SelectedIndex = 1
        Form2.cmb_UnitsPerDivision.SelectedIndex = 0
        ' -------------------------------------------------------------
        ' ------------------------------------------------------------------------------- 
        ' With "Resume Next" subsequent parameters are loaded and f.Close() is executed
        ' -------------------------------------------------------------------------------
        On Error Resume Next  ' use Resume-Next instead of Try-Catch
        ' -------------------------------------------------------------------------------
        Dim l As String
        Dim iniFileName As String = PlatformAdjustedFileName(Application.StartupPath & "\" & AssemblyName() & "_INI.txt")
        If My.Computer.FileSystem.FileExists(iniFileName) Then
            '
            Dim f As System.IO.StreamReader
            f = IO.File.OpenText(iniFileName)
            '
            Do While Not f.EndOfStream
                l = f.ReadLine()
                Select Case ExtractParamName(l)
                    Case "Form1_Top" : Form1.Top = Val_Int(l)
                    Case "Form1_Left" : Form1.Left = Val_Int(l)
                    Case "Form1_Width" : Form1.Width = Val_Int(l)
                    Case "Form1_Height" : Form1.Height = Val_Int(l)
                    Case "Form1_WindowState" : Form1.WindowState = CType((Val(l)), FormWindowState) : Form1.Refresh()
                        'Case "Form1_VisibleAtStart" : Form1_VisibleAtStart = l = "True"
                        '
                    Case "Form2_Top" : Form2.Top = Val_Int(l)
                    Case "Form2_Left" : Form2.Left = Val_Int(l)
                    Case "Form2_Width" : Form2.Width = Val_Int(l)
                    Case "Form2_Height" : Form2.Height = Val_Int(l)
                    Case "Form2_VisibleAtStart" : Form2_VisibleAtStart = l = "True"
                        '
                    Case "Language" : Language = l
                    Case "Reconnect" : Form1.btn_Reconnect.Checked = l = "True"
                    Case "MinChange" : Form1.txt_MinChange.NumericValueInteger = Val_Int(l)
                    Case "BeepOnErrors" : Form1.ToolStripButton_BeepOnErrors.Checked = l = "True"
                    Case "Lock" : Form1.ToolStripButton_Lock.Checked = l = "True"
                        '
                    Case "SelectedPinListLine" : Form2.SelectedPinListLine = Val_Int(l)
                    Case "AlternatePinListLine" : Form2.AlternatePinListLine = Val_Int(l)
                    Case "Scope_ShowRawCount" : Form2.btn_ShowRawCount.Checked = l = "True"
                    Case "Scope_UnitsPerDivision" : Combo_SetIndex(Form2.cmb_UnitsPerDivision, Val_Int(l))
                    Case "Scope_ScrollSpeed" : Combo_SetIndex(Form2.cmb_ScrollSpeed, Val_Int(l))
                    Case "Scope_ScaleMax" : Form2.txt_ScaleMax.Text = l
                    Case "Scope_ScaleMin" : Form2.txt_ScaleMin.Text = l
                        '
                    Case "ValidMasterName"
                        ReDim Preserve ValidMasterNames(ValidMasterNames.Length)
                        ValidMasterNames(ValidMasterNames.Length - 1) = l
                        '
                    Case "CommandSlot" : CommandSlot = Val_Int(l)
                End Select
            Loop
            f.Close()
        End If
        '
        With Form1.txt_MinChange
            If .NumericValueInteger < 0 Then .NumericValueInteger = 0
            If .NumericValueInteger > 100 Then .NumericValueInteger = 100
        End With
        '
        LimitFormPosition(Form1)
        LimitFormPosition(Form2)
    End Sub


    ' ==================================================================================================
    '  Valid Master Names
    ' ==================================================================================================
    Friend ValidMasterNames(-1) As String
    Friend Sub ValidMasterNames_Reset()
        ReDim ValidMasterNames(-1)
    End Sub
    Friend Sub ValidMasterNames_Init()
        ReDim ValidMasterNames(-1)
        For Each m As Master In Masters
            ReDim Preserve ValidMasterNames(ValidMasterNames.Length)
            ValidMasterNames(ValidMasterNames.Length - 1) = m.GetName
        Next
    End Sub


    ' ==================================================================================================
    '  SAVE LOAD -- Configurations
    ' ==================================================================================================
    Private SaveLoadConfigLocker As Object = New Object

    Friend Sub Save_ConfigDatabase()
        SyncLock SaveLoadConfigLocker
            '
            Dim tempFileName As String = PlatformAdjustedFileName(Application.StartupPath & "\" & _
                                                                  AssemblyName() & "_ConfigTemp.txt")
            Dim iniFileName As String = PlatformAdjustedFileName(Application.StartupPath & "\" & _
                                                                 AssemblyName() & "_ConfigDatabase.txt")
            Dim f As System.IO.StreamWriter = Nothing
            f = IO.File.CreateText(tempFileName)
            '
            Try
                For c As Int32 = 0 To ConfigDatabase.Length - 1
                    Dim config As String() = TryCast(ConfigDatabase(c), String())
                    AlignConfigurationSpacing(config)
                    f.WriteLine("")
                    f.WriteLine("Component  Name                Param1    Param2    Param3    Param4    Param5    Param6    Param7    Param8")
                    f.WriteLine("-----------------------------------------------------------------------------------------------------------")
                    For i As Int32 = 0 To config.Length - 1
                        f.WriteLine(config(i))
                    Next
                    f.WriteLine("")
                Next
                f.Close()
                My.Computer.FileSystem.CopyFile(tempFileName, iniFileName, True)
                My.Computer.FileSystem.DeleteFile(tempFileName)
            Catch
            End Try
        End SyncLock
    End Sub

    Private SpacingTabs() As Int32 = New Int32() {10, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130}
    Private Sub AlignConfigurationSpacing(ByRef config As String())
        Dim sa() As String
        For i As Int32 = 0 To config.Length - 1
            sa = Split(config(i), ",")
            config(i) = sa(0).Trim
            For j As Int32 = 1 To sa.Length - 1
                config(i) &= "," & Strings.StrDup(Math.Max(0, SpacingTabs(j - 1) - config(i).Length), " ") & sa(j).Trim
            Next
        Next
    End Sub

    Friend Sub Load_ConfigDatabase()
        SyncLock SaveLoadConfigLocker
            ReDim ConfigDatabase(-1)
            Dim Config(-1) As String
            ' ------------------------------------------------------------- 
            Dim l As String
            Dim iniFileName As String = PlatformAdjustedFileName(Application.StartupPath & "\" & AssemblyName() & "_ConfigDatabase.txt")
            If My.Computer.FileSystem.FileExists(iniFileName) Then
                Dim f As System.IO.StreamReader
                f = IO.File.OpenText(iniFileName)
                Try
                    Do While Not f.EndOfStream
                        l = f.ReadLine()
                        If l <> "" Then
                            ' ------------------------------------- store the previous configuration
                            If l.StartsWith("Master,") Then
                                AddToConfigDatabase(Config)
                                ReDim Config(-1)
                            End If
                            If l.StartsWith("Master,") Or l.StartsWith("Slave,") Or l.StartsWith("Pin,") Then
                                ReDim Preserve Config(Config.Length)
                                Config(Config.Length - 1) = l
                            End If
                        End If
                    Loop
                    f.Close()
                    ' --------------------------------------------- store the last collected configuration
                    AddToConfigDatabase(Config)
                Catch
                End Try
            End If
        End SyncLock
    End Sub


    ' ==============================================================================================================
    '   Slot Names
    ' ==============================================================================================================
    Friend SlotNames(999) As String
    Friend Sub LoadSlotNames()
        Array.Clear(SlotNames, 0, 999)
        Try
            Dim l As String
            Dim slot As Int32
            Dim fname As String = PlatformAdjustedFileName(Application.StartupPath & "\SlotNames.txt")
            If My.Computer.FileSystem.FileExists(fname) Then
                Dim f As System.IO.StreamReader
                f = IO.File.OpenText(fname)
                Do While Not f.EndOfStream
                    l = RemoveComments(f.ReadLine())
                    l = l.Replace(vbTab, " ").Trim
                    Dim i As Int32 = l.IndexOf(" ")
                    If i > 0 Then
                        slot = CInt(Val(l.Substring(0, i)))
                        SlotNames(slot) = l.Substring(i).Trim
                    End If
                Loop
                f.Close()
            End If
        Catch
        End Try
    End Sub

    Friend Function RemoveComments(ByVal s As String) As String
        Dim i As Int32 = s.IndexOf("'")
        If i > 0 Then s = s.Remove(i).TrimEnd
        If i = 0 Then s = ""
        Return s
    End Function

End Module
