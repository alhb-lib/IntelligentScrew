
Module Module_Utils

    ' ==============================================================================================================
    '   LIST VIEW LINE-INDEX and COLUMN-INDEX FROM CURSOR POSITION
    ' ==============================================================================================================

    ' --------------------------------------------------------------------------------------------
    '   0 = first line  /  -1 = no line
    ' --------------------------------------------------------------------------------------------
    Friend Function ListView_GetLineIndex(ByVal lv As ListView) As Int32
        Dim p As Point = lv.PointToClient(Cursor.Position)
        Dim item As ListViewItem = lv.GetItemAt(p.X, p.Y)
        If item Is Nothing Then
            Return -1
        Else
            Return item.Index
        End If
    End Function

    ' --------------------------------------------------------------------------------------------
    '   0 = first column  /  -1 = no columns
    ' --------------------------------------------------------------------------------------------
    Friend Function ListView_GetColumnIndex(ByVal lv As ListView) As Int32
        Dim colx As Int32 = 0
        Dim curx As Int32 = lv.PointToClient(Cursor.Position).X
        Dim index As Int32 = -1
        Do While index < lv.Columns.Count - 1
            index += 1
            colx += lv.Columns(index).Width
            If curx < colx Then Exit Do
        Loop
        Return index
    End Function

    Friend Sub ListView_SelectLine(ByVal lv As ListView, ByVal line As Int32)
        If line >= 0 And line < lv.Items.Count Then
            lv.Items(line).Selected = True
        End If
    End Sub


    ' =======================================================================================
    '  Utils
    ' =======================================================================================
    'Friend Function Shell_NormalFocus(ByVal path As String) As Int32
    '    Try
    '        Return Shell(path, AppWinStyle.NormalFocus)
    '    Catch
    '        MsgBox("Cannot open the path: " & vbCr & path, MsgBoxStyle.Information)
    '        Return 0
    '    End Try
    'End Function

    Friend Function CamelCaseString(ByVal s As String) As String
        Return Left(s, 1).ToUpper & Mid(s.ToLower, 2)
    End Function

    Friend GCI As Globalization.CultureInfo = New Globalization.CultureInfo("en-GB")


    ' =======================================================================================
    '  Beep with Repetition Limited
    ' =======================================================================================
    Friend Sub Beep_RepetitionLimited(ByVal ms As Int32)
        Static sw As Stopwatch
        If sw Is Nothing Then
            sw = New Stopwatch
            sw.Start()
        End If
        If sw.ElapsedMilliseconds < ms Then Return
        sw.Reset()
        sw.Start()
        Beep()
        'My.Computer.Audio.Play(My.Resources.Tick_close_7, AudioPlayMode.Background)
    End Sub


    ' ==============================================================================================================
    '   COMBO FUNCTIONS
    ' ==============================================================================================================
    Friend Sub Combo_Init(ByVal combo As ComboBox, ByVal str As String)
        Dim old As Boolean = EventsAreEnabled
        EventsAreEnabled = False
        If str = Nothing Then str = ""
        With combo
            .Items.Clear()
            .Items.Add(str)
            .SelectedIndex = 0
        End With
        EventsAreEnabled = old
    End Sub

    Friend Sub Combo_SetIndex_FromString(ByVal combo As ComboBox, ByVal str As String)
        Dim old As Boolean = EventsAreEnabled
        EventsAreEnabled = False
        If str = Nothing Then str = ""
        With combo
            For i As Int32 = 0 To .Items.Count - 1
                If .Items(i).ToString.Trim = str Then
                    .SelectedIndex = i
                    Exit For
                End If
            Next
        End With
        EventsAreEnabled = old
    End Sub

    Friend Function Combo_GetValue(ByVal combo As ComboBox) As String
        If combo.SelectedIndex < 0 Then Return ""
        Return combo.Items(combo.SelectedIndex).ToString()
    End Function

    Friend Sub Combo_SetIndex(ByVal combo As ComboBox, ByVal index As Int32)
        If combo.Items.Count < 1 Then Exit Sub
        If index < 0 Then index = 0
        If index > combo.Items.Count - 1 Then index = combo.Items.Count - 1
        combo.SelectedIndex = index
    End Sub


    ' =============================================================================================
    '  ASYNC MOUSE KEYS and MOUSE STATE
    ' =============================================================================================
    Friend Function LeftMousePressed() As Boolean
        Return (Control.MouseButtons And Windows.Forms.MouseButtons.Left) <> Windows.Forms.MouseButtons.None
    End Function


    ' =============================================================================================
    '  ByteArrays - for STEPPERS 
    '  UINT Destinations are from 0 to 4 gigabytes
    '  The higher value (4 gigabytes - 1) is a special value meaning "reset stepper destination"
    ' =============================================================================================
    Friend Function StepperByteArray_FromUint32(ByVal n As UInt32) As Byte()
        Dim n2 As Int64 = n
        n2 -= &H80000000UI
        Dim b() As Byte = BitConverter.GetBytes(CInt(n2))
        If BitConverter.IsLittleEndian Then
            Array.Reverse(b)
        End If
        Return b
    End Function

    ' =============================================================================================
    '  ByteArrays 
    ' =============================================================================================
    Friend Function ByteArrayFromUint24(ByVal n As UInt32) As Byte()
        Dim b(2) As Byte
        b(0) = CByte((n >> 16) And 255)
        b(1) = CByte((n >> 8) And 255)
        b(2) = CByte(n And 255)
        Return b
    End Function

    Friend Function ByteArrayFromUint16(ByVal n As UInt16) As Byte()
        Dim b(1) As Byte
        b(0) = CByte((n >> 8) And 255)
        b(1) = CByte(n And 255)
        Return b
    End Function

    'Friend Function ByteArray_From_Uint16Array(ByVal n() As UInt16) As Byte()
    '    Dim b(n.Length * 2 - 1) As Byte
    '    For i As Int32 = 0 To n.Length - 1
    '        b(i * 2) = CByte(n(i) \ 256)
    '        b(i * 2 + 1) = CByte(n(i) Mod 256)
    '    Next
    '    Return b
    'End Function

    ' =======================================================================================================
    '   REDIM PRESERVE BIDIMENSIONAL STRING ARRAY
    ' =======================================================================================================
    Friend Sub RedimPreserve_2D_Array(ByRef ar(,) As String, ByVal rowUpperIdx As Int32, ByVal colUpperIdx As Int32)
        Dim newArray(rowUpperIdx, colUpperIdx) As String
        Dim minRows As Integer = Math.Min(rowUpperIdx + 1, ar.GetLength(0))
        Dim minCols As Integer = Math.Min(colUpperIdx + 1, ar.GetLength(1))
        For i As Int32 = 0 To minRows - 1
            For j As Int32 = 0 To minCols - 1
                newArray(i, j) = ar(i, j)
            Next
        Next
        ar = newArray
    End Sub


    ' =======================================================================================================
    '   LOCK WINDOWS UPDATE
    ' =======================================================================================================
    Private Declare Function LockWindowUpdate Lib "User32" (ByVal hWnd As IntPtr) As Int32
    Private Declare Function GetDesktopWindow Lib "User32" Alias "GetDesktopWindow" () As IntPtr
    Friend Sub LockFormUpdate(ByVal frm As Form)
        If OperatingSystemIsWindows Then
            LockWindowUpdate(frm.Handle)
        End If
    End Sub
    Friend Sub UnlockFormUpdate()
        If OperatingSystemIsWindows Then
            LockWindowUpdate(Nothing)
        End If
    End Sub


    ' ========================================================
    '   PROCESS START AND WAIT
    ' ========================================================
    Friend Sub ProcessStartAndWait(ByVal fname As String)
        If Not FileExists(fname) Then Return
        Dim p As Process = Process.Start(fname)
        Do
            System.Threading.Thread.Sleep(100)
        Loop Until p.HasExited
    End Sub


    Friend Sub SleepMyThread(ByVal ms As Int32)
        System.Threading.Thread.Sleep(ms)
    End Sub

End Module



' =============================================================================================
'  CLASS ReverseIterator
' =============================================================================================
Friend Class ReverseIterator
    Implements IEnumerable
    ' ------------------------------------------ a low-overhead ArrayList to store references
    Dim items As New ArrayList()

    Sub New(ByVal collection As IEnumerable)
        ' -------------------------------------- load all the items in the ArrayList, but in reverse order
        Dim o As Object
        For Each o In collection
            items.Insert(0, o)
        Next
    End Sub
    '
    Public Function GetEnumerator() As System.Collections.IEnumerator _
        Implements System.Collections.IEnumerable.GetEnumerator
        ' ------------------------------------- return the enumerator of the inner ArrayList
        Return items.GetEnumerator()
    End Function
End Class



