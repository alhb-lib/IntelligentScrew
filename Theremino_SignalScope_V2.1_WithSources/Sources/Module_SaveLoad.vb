Module Module_SaveLoad

    Friend ParamsChanged As Boolean = False

    ' =======================================================================================
    '  FORM FUNCTIONS
    ' =======================================================================================
    Friend Sub LimitFormPosition(ByVal f As System.Windows.Forms.Form)
        If f.WindowState <> FormWindowState.Normal Then Return
        GetMaxScreenBounds()
        EnsureFormVisible(f)
    End Sub

    Friend Sub LimitFormPosition_CompletelyVisible(ByVal f As System.Windows.Forms.Form)
        If f.WindowState <> FormWindowState.Normal Then Return
        GetMaxScreenBounds()
        EnsureFormCompletelyVisible(f)
    End Sub

    Private SB As Rectangle = New Rectangle(Integer.MaxValue, Integer.MaxValue, Integer.MinValue, Integer.MinValue)

    Private Sub GetMaxScreenBounds()
        For Each s As Screen In System.Windows.Forms.Screen.AllScreens
            SB = Rectangle.Union(SB, s.WorkingArea)
        Next
    End Sub


    Private Sub EnsureFormCompletelyVisible(ByVal frm As Form)
        With frm
            .Width = Math.Min(.Width, SB.Width)         ' not more than a maximized window
            .Height = Math.Min(.Height, SB.Height)      ' not more than a maximized window
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
            .Width = Math.Min(.Width, SB.Width)             ' not more than VIRTUALSCREEN dimensions
            .Height = Math.Min(.Height, SB.Height)          ' not more than VIRTUALSCREEN dimensions 
            .Width = Math.Max(.Width, 32)                   ' at least 32x24
            .Height = Math.Max(.Height, 24)                 ' at least 32x24
            .Left = Math.Min(.Left, SB.Right - 50)          ' not beyond right border - 50 pixels
            .Top = Math.Min(.Top, SB.Bottom - 100)          ' not beyond bottom border - 50 pixels
            .Left = Math.Max(.Left, SB.Left + 100 - .Width) ' at least at left border + 50 pixels
            .Top = Math.Max(.Top, SB.Top - 10)              ' at least at top border
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

    Friend Sub LimitComboDropDownHeight(ByRef cmb As ComboBox)
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
            ExtractParamName = s.Trim
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
        ParamsChanged = False
        Dim iniFileName As String = PlatformAdjustedFileName(Application.StartupPath & "\" & AssemblyName() & "_INI.txt")
        Dim f As System.IO.StreamWriter = Nothing
        Try
            f = IO.File.CreateText(iniFileName)
            '
            f.WriteLine(" Program Params")
            f.WriteLine("===========================================")
            ' ---------------------------------------------------------------------------------
            Dim r As Rectangle
            r = GetFormRectangle(Form1)
            f.WriteLine(TabString("Form1_Top", r.Top))
            f.WriteLine(TabString("Form1_Left", r.Left))
            f.WriteLine(TabString("Form1_Width", r.Width))
            f.WriteLine(TabString("Form1_Height", r.Height))
            f.WriteLine(TabString("Form1_WindowState", Form1.WindowState))
            f.WriteLine(TabString("Form1_Visible", Form1.Visible))
            ' ---------------------------------------------------------------------------------
            f.WriteLine(TabString("Scope_Interpolate", Form1.btn_Interpolate.Checked))
            f.WriteLine(TabString("Scope_Cursors", Form1.btn_Cursors.Checked))
            f.WriteLine(TabString("Scope_Cursor1", Cursor1))
            f.WriteLine(TabString("Scope_Cursor2", Cursor2))
            f.WriteLine(TabString("Scope_TriggerCh", ModuleScope.TriggerCh))
            f.WriteLine(TabString("Scope_Run", Form1.btn_Run.Checked))
            f.WriteLine(TabString("Scope_Slot1", Form1.txt_Slot1.Text))
            f.WriteLine(TabString("Scope_Slot2", Form1.txt_Slot2.Text))
            f.WriteLine(TabString("Scope_Min1", Form1.txt_Min1.Text))
            f.WriteLine(TabString("Scope_Min2", Form1.txt_Min2.Text))
            f.WriteLine(TabString("Scope_Max1", Form1.txt_Max1.Text))
            f.WriteLine(TabString("Scope_Max2", Form1.txt_Max2.Text))
            f.WriteLine(TabString("Scope_Center1", Form1.txt_Center1.Text))
            f.WriteLine(TabString("Scope_Center2", Form1.txt_Center2.Text))
            f.WriteLine(TabString("Scope_Units1", Form1.cmb_Units1.SelectedIndex))
            f.WriteLine(TabString("Scope_Units2", Form1.cmb_Units2.SelectedIndex))
            f.WriteLine(TabString("Scope_AC1", Form1.chk_AC1.Checked))
            f.WriteLine(TabString("Scope_AC2", Form1.chk_AC2.Checked))
            f.WriteLine(TabString("Scope_BaseTime", Form1.cmb_BaseTime.SelectedIndex))
            f.WriteLine(TabString("Scope_Delta", Form1.txt_Delta.Text))
            f.WriteLine(TabString("Scope_StopIf", Form1.cmb_StopIf.SelectedIndex))
            f.WriteLine(TabString("Scope_StopTripPoint", Form1.txt_StopTripPoint.Text))
            f.WriteLine(TabString("Scope_StopAfterTimes", Form1.cmb_StopAfterTimes.SelectedIndex))
        Catch
        End Try
        Try
            f.Close()
        Catch
        End Try
    End Sub

    Friend Sub Load_INI()
        ' ------------------------------------------------------------------------------- defaults
        Form1.cmb_Units1.SelectedIndex = 0
        Form1.cmb_Units2.SelectedIndex = 0
        Form1.cmb_BaseTime.SelectedIndex = 10
        Form1.cmb_StopIf.SelectedIndex = 0
        Form1.cmb_StopAfterTimes.SelectedIndex = 0
        ' -------------------------------------------------------------------------------
        ' ------------------------------------------------------------------------------- 
        ' With "Resume Next" subsequent parameters are loaded and f.Close() is executed
        ' -------------------------------------------------------------------------------
        On Error Resume Next  ' use Resume-Next instead of Try-Catch
        ' -------------------------------------------------------------------------------
        Dim l As String
        Dim iniFileName As String = PlatformAdjustedFileName(Application.StartupPath & "\" & AssemblyName() & "_INI.txt")

        If My.Computer.FileSystem.FileExists(iniFileName) Then

            Dim f As System.IO.StreamReader
            f = IO.File.OpenText(iniFileName)

            Do While Not f.EndOfStream
                l = f.ReadLine()
                Select Case ExtractParamName(l)
                    ' --------------------------------------------------------------------------- FORM
                    Case "Form1_Top" : Form1.Top = Val_Int(l)
                    Case "Form1_Left" : Form1.Left = Val_Int(l)
                    Case "Form1_Width" : Form1.Width = Val_Int(l)
                    Case "Form1_Height" : Form1.Height = Val_Int(l)
                    Case "Form1_WindowState" : Form1.WindowState = CType(Val(l), FormWindowState)
                    Case "Form1_Visible" : Form1.Visible = l = "True"
                        ' -----------------------------------------------------------------------
                    Case "Scope_Interpolate" : Form1.btn_Interpolate.Checked = l = "True"
                    Case "Scope_Cursors" : Form1.btn_Cursors.Checked = l = "True"
                    Case "Scope_Cursor1" : Cursor1 = Val_Single(l)
                    Case "Scope_Cursor2" : Cursor2 = Val_Single(l)
                    Case "Scope_TriggerCh" : ModuleScope.TriggerCh = Val_Int(l)
                    Case "Scope_Run" : Form1.btn_Run.Checked = l = "True"
                    Case "Scope_Slot1" : Form1.txt_Slot1.Text = l
                    Case "Scope_Slot2" : Form1.txt_Slot2.Text = l
                    Case "Scope_Min1" : Form1.txt_Min1.Text = l
                    Case "Scope_Min2" : Form1.txt_Min2.Text = l
                    Case "Scope_Max1" : Form1.txt_Max1.Text = l
                    Case "Scope_Max2" : Form1.txt_Max2.Text = l
                    Case "Scope_Center1" : Form1.txt_Center1.Text = l
                    Case "Scope_Center2" : Form1.txt_Center2.Text = l
                    Case "Scope_Units1" : Combo_SetIndex(Form1.cmb_Units1, Val_Int(l))
                    Case "Scope_Units2" : Combo_SetIndex(Form1.cmb_Units2, Val_Int(l))
                    Case "Scope_AC1" : Form1.chk_AC1.Checked = l = "True"
                    Case "Scope_AC2" : Form1.chk_AC2.Checked = l = "True"
                    Case "Scope_BaseTime" : Combo_SetIndex(Form1.cmb_BaseTime, Val_Int(l))
                    Case "Scope_Delta" : Form1.txt_Delta.Text = l
                    Case "Scope_StopIf" : Combo_SetIndex(Form1.cmb_StopIf, Val_Int(l))
                    Case "Scope_StopTripPoint" : Form1.txt_StopTripPoint.Text = l
                    Case "Scope_StopAfterTimes" : Combo_SetIndex(Form1.cmb_StopAfterTimes, Val_Int(l))
                End Select
            Loop
            f.Close()
        End If
        LimitFormPosition(Form1)
    End Sub

    ' ==============================================================================================================
    '   Slot Names
    ' ==============================================================================================================
    Friend SlotNames(999) As String
    Friend Sub LoadSlotNames()
        Array.Clear(SlotNames, 0, 999)
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
    End Sub

End Module
