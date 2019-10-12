

Module Module_SaveLoad

    Friend EventsAreEnabled As Boolean = False

    ' =======================================================================================================
    '   APP TITLE AND VERSION
    ' =======================================================================================================
    Friend Function AppTitleAndVersion(Optional ByVal Title As String = "") As String
        If Title = "" Then Title = Replace(My.Application.Info.AssemblyName, "_", " ")
        Dim s() As String = Split(My.Application.Info.Version.ToString, ".")
        Return Title & " - V" & s(0) & "." & s(1)
    End Function


    ' =======================================================================================================
    '   Platform selection
    ' =======================================================================================================
    Friend Function PlatformAdjustedFileName(ByVal FileName As String, _
                                             Optional ByVal DefaultName As String = "") As String
        If OperatingSystemIsWindows Then
            FileName = Replace(FileName, "/", "\")
            Return FileName
        Else
            If FileName.Contains(":") Then FileName = DefaultName
            FileName = Replace(FileName, "\", "/")
            Return FileName
        End If
    End Function


    ' =======================================================================================
    '  FORM FUNCTIONS
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

    'Private Sub EnsureFormCompletelyVisible(ByVal frm As Form)
    '    With frm
    '        .Width = Math.Min(.Width, SB.Width)         ' not more than a maximized window
    '        .Height = Math.Min(.Height, SB.Height)      ' not more than a maximized window
    '        .Width = Math.Max(.Width, 32)               ' at least 32x24
    '        .Height = Math.Max(.Height, 24)             ' at least 32x24
    '        .Left = Math.Min(.Left, SB.Right - .Width)  ' not beyond the right border
    '        .Top = Math.Min(.Top, SB.Bottom - .Height)  ' not beyond the bottom border
    '        .Left = Math.Max(.Left, SB.Left)            ' at least at the left border
    '        .Top = Math.Max(.Top, SB.Top)               ' at least at the top border
    '    End With
    'End Sub

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

    Private Function ExtractParamName(ByRef s As String) As String
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
        '
        Dim iniFileName As String = PlatformAdjustedFileName(Application.StartupPath & "\" & AssemblyName() & "_INI.txt")
        Dim f As System.IO.StreamWriter = Nothing
        Try
            f = IO.File.CreateText(iniFileName)
            '
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
            '
            '
            f.WriteLine(TabString(""))
            f.WriteLine(TabString(" Slots"))
            f.WriteLine("===========================================")
            f.WriteLine(TabString("FirstSlot", Form1.txt_FirstSlot.NumericValueInteger))
            f.WriteLine(TabString("NumSlots", Form1.txt_NumSlots.NumericValueInteger))
            f.WriteLine(TabString("MaxValue", Form1.txt_MaxValue.NumericValueInteger))
            f.WriteLine(TabString("MinValue", Form1.txt_MinValue.NumericValueInteger))
            f.WriteLine(TabString("Colors", Form1.Colors))
            f.WriteLine(TabString("Vertical", Form1.chk_Vertical.Checked.ToString))
            f.WriteLine(TabString("Decimals", Form1.txt_Decimals.NumericValueInteger))
            f.WriteLine(TabString("Zoom", Form1.txt_Zoom.NumericValueInteger))
        Catch
        End Try
        Try
            f.Close()
        Catch
        End Try
    End Sub

    Friend Sub Load_INI()
        ' ------------------------------------------------------------------------------- defaults
        '
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
                    Case "Form1_Top" : Form1.Top = Val_Int(l)
                    Case "Form1_Left" : Form1.Left = Val_Int(l)
                    Case "Form1_Width" : Form1.Width = Val_Int(l)
                    Case "Form1_Height" : Form1.Height = Val_Int(l)
                    Case "Form1_WindowState" : Form1.WindowState = CType((Val(l)), FormWindowState)
                        ' --------------------------------------------------------------- Slots
                    Case "FirstSlot" : Form1.txt_FirstSlot.NumericValueInteger = Val_Int(l)
                    Case "NumSlots" : Form1.txt_NumSlots.NumericValueInteger = Val_Int(l)
                    Case "MaxValue" : Form1.txt_MaxValue.NumericValueInteger = Val_Int(l)
                    Case "MinValue" : Form1.txt_MinValue.NumericValueInteger = Val_Int(l)
                    Case "Colors" : Form1.Colors = Val_Int(l)
                    Case "Vertical" : Form1.chk_Vertical.Checked = l = "True"
                    Case "Decimals" : Form1.txt_Decimals.NumericValueInteger = Val_Int(l)
                    Case "Zoom" : Form1.txt_Zoom.NumericValueInteger = Val_Int(l)
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
                    SlotNames(slot) = Strings.RTrim(l.Substring(i))
                End If
            Loop
            f.Close()
        End If
    End Sub

End Module
