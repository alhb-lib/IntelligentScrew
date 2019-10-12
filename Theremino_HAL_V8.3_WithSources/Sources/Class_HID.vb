
Imports System.Runtime.InteropServices

' Althought ReadFile and WriteFile parameters are all pinned 
' ------------------------------------------------------------------------------------------
' - there is one slave-servo with some active pin: servo_16 / Adc_16 ...  
' - rep time 66
' - speed 2
' - try with the component-details window visible or not visible
' - the program is compiled with: Project-properties / Advanced / Generate-debug-info = NONE
'
' Open the program and immediately traverse the listbox up and down 
'  with keyboard up/down arrows about 5 to 10 times and the program crashes
' ------------------------------------------------------------------------------------------

' SOLUTION >>>> SET: Project-properties / "Release" / Advanced / Generate-debug-info = Full


' Overlapped I/O
' =====================================================================================
' Reading HID Input reports is done with the API function ReadFile.
'
' Non-overlapped ReadFile is a blocking call. If the device doesn't return the
' expected amount of data, the application hangs and waits endlessly.
'
' With overlapped I/O, the call to ReadFile returns immediately.
' The application uses WaitForSingleObject to be notified either that
' the data has arrived or that a timeout has occurred.
'
' WaitForSingleObject blocks the application thread but specifies a timeout value
' so the application's thread isn't blocked forever.
' ======================================================================================


' #################################################################################################
'  PARTIAL THEREMINO_HID CLASS
' #################################################################################################

Partial Friend Class Theremino_HID

    ' ======================================================================================
    '   CONSTANTS
    ' ======================================================================================
    Private Const DIGCF_PRESENT As Integer = &H2
    Private Const DIGCF_DEVICEINTERFACE As Integer = &H10
    Private Const FILE_FLAG_OVERLAPPED As Integer = &H40000000
    Private Const FILE_SHARE_READ As Integer = &H1
    Private Const FILE_SHARE_WRITE As Integer = &H2
    Private Const FORMAT_MESSAGE_FROM_SYSTEM As Integer = &H1000
    Private Const GENERIC_READ As Integer = &H80000000
    Private Const GENERIC_WRITE As Integer = &H40000000

    ' ------------------------------ if possible declare as integers (16 bits)
    Private Const HidP_Input As Short = 0
    Private Const HidP_Output As Short = 1
    Private Const HidP_Feature As Short = 2

    Private Const OPEN_EXISTING As Short = 3
    Private Const WAIT_TIMEOUT As Integer = &H102
    Private Const WAIT_OBJECT_0 As Short = 0


    ' ======================================================================================
    '   TYPES
    ' ======================================================================================
    <StructLayout(LayoutKind.Sequential)> _
    Private Structure HIDD_ATTRIBUTES
        Dim Size As Integer
        Dim VendorID As Short
        Dim ProductID As Short
        Dim VersionNumber As Short
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure HIDP_CAPS
        Dim Usage As Short
        Dim UsagePage As Short
        Dim InputReportByteLength As Short
        Dim OutputReportByteLength As Short
        Dim FeatureReportByteLength As Short
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=17)> Dim Reserved() As Short
        Dim NumberLinkCollectionNodes As Short
        Dim NumberInputButtonCaps As Short
        Dim NumberInputValueCaps As Short
        Dim NumberInputDataIndices As Short
        Dim NumberOutputButtonCaps As Short
        Dim NumberOutputValueCaps As Short
        Dim NumberOutputDataIndices As Short
        Dim NumberFeatureButtonCaps As Short
        Dim NumberFeatureValueCaps As Short
        Dim NumberFeatureDataIndices As Short
    End Structure

    'If IsRange is false, UsageMin is the Usage and UsageMax is unused.
    'If IsStringRange is false, StringMin is the string index and StringMax is unused.
    'If IsDesignatorRange is false, DesignatorMin is the designator index and DesignatorMax is unused.

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure HidP_Value_Caps
        Dim UsagePage As Short
        Dim ReportID As Byte
        Dim IsAlias As Integer
        Dim BitField As Short
        Dim LinkCollection As Short
        Dim LinkUsage As Short
        Dim LinkUsagePage As Short
        Dim IsRange As Integer
        Dim IsStringRange As Integer
        Dim IsDesignatorRange As Integer
        Dim IsAbsolute As Integer
        Dim HasNull As Integer
        Dim Reserved As Byte
        Dim BitSize As Short
        Dim ReportCount As Short
        Dim Reserved2 As Short
        Dim Reserved3 As Short
        Dim Reserved4 As Short
        Dim Reserved5 As Short
        Dim Reserved6 As Short
        Dim LogicalMin As Integer
        Dim LogicalMax As Integer
        Dim PhysicalMin As Integer
        Dim PhysicalMax As Integer
        Dim UsageMin As Short
        Dim UsageMax As Short
        Dim StringMin As Short
        Dim StringMax As Short
        Dim DesignatorMin As Short
        Dim DesignatorMax As Short
        Dim DataIndexMin As Short
        Dim DataIndexMax As Short
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure OVERLAPPED
        Dim Internal As Integer
        Dim InternalHigh As Integer
        Dim Offset As Integer
        Dim OffsetHigh As Integer
        Dim hEvent As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure SECURITY_ATTRIBUTES
        Dim nLength As Integer
        Dim lpSecurityDescriptor As Integer
        Dim bInheritHandle As Boolean
    End Structure


    ' There are two declarations for the DEV_BROADCAST_DEVICEINTERFACE structure.
    '
    ' Use this in the call to RegisterDeviceNotification() and
    ' in checking dbch_devicetype in a DEV_BROADCAST_HDR structure.
    <StructLayout(LayoutKind.Sequential)> _
    Private Class DEV_BROADCAST_DEVICEINTERFACE
        Public dbcc_size As Integer
        Public dbcc_devicetype As Integer
        Public dbcc_reserved As Integer
        Public dbcc_classguid As Guid
        Public dbcc_name As Short
    End Class

    ' Use this to read the dbcc_name string and classguid.
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Class DEV_BROADCAST_DEVICEINTERFACE_1
        Public dbcc_size As Integer
        Public dbcc_devicetype As Integer
        Public dbcc_reserved As Integer
        <MarshalAs(UnmanagedType.ByValArray, ArraySubType:=UnmanagedType.U1, SizeConst:=16)> _
        Public dbcc_classguid() As Byte
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=255)> _
        Public dbcc_name() As Char
    End Class

    <StructLayout(LayoutKind.Sequential)> _
    Private Class DEV_BROADCAST_HANDLE
        Public dbch_size As Integer
        Public dbch_devicetype As Integer
        Public dbch_reserved As Integer
        Public dbch_handle As Integer
        Public dbch_hdevnotify As Integer
    End Class

    <StructLayout(LayoutKind.Sequential)> _
    Private Class DEV_BROADCAST_HDR
        Public dbch_size As Integer
        Public dbch_devicetype As Integer
        Public dbch_reserved As Integer
    End Class

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure SP_DEVICE_INTERFACE_DATA
        Dim cbSize As Integer
        Dim InterfaceClassGuid As System.Guid
        Dim Flags As Integer
        Dim Reserved As IntPtr 'Integer    ' TODO IntPtr is best for 64 bit ??????????????
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure SP_DEVICE_INTERFACE_DETAIL_DATA
        Dim cbSize As Integer
        Dim DevicePath As String
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure SP_DEVINFO_DATA
        Dim cbSize As Integer
        Dim ClassGuid As System.Guid
        Dim DevInst As Integer
        Dim Reserved As Integer
    End Structure


    ' ======================================================================================
    '   API FUNCTIONS
    ' ======================================================================================
    <DllImport("hid.dll")> _
    Private Shared Function HidD_FlushQueue(ByVal HidDeviceObject As Integer) As Boolean
    End Function

    <DllImport("hid.dll")> _
    Private Shared Function HidD_GetFeature(ByVal HidDeviceObject As Integer, _
                                            ByRef lpReportBuffer As Byte, _
                                            ByVal ReportBufferLength As Integer) _
                                            As Boolean
    End Function

    <DllImport("hid.dll")> _
    Private Shared Function HidD_GetInputReport(ByVal HidDeviceObject As Integer, _
                                                ByRef lpReportBuffer As Byte, _
                                                ByVal ReportBufferLength As Integer) _
                                                As Boolean
    End Function

    <DllImport("hid.dll")> _
    Private Shared Sub HidD_GetHidGuid(ByRef HidGuid As System.Guid)
    End Sub

    <DllImport("hid.dll")> _
    Private Shared Function HidD_GetNumInputBuffers(ByVal HidDeviceObject As Integer, _
                                                    ByRef NumberBuffers As Integer) _
                                                    As Boolean
    End Function

    <DllImport("hid.dll")> _
    Private Shared Function HidD_SetFeature(ByVal HidDeviceObject As Integer, _
                                            ByRef lpReportBuffer As Byte, _
                                            ByVal ReportBufferLength As Integer) _
                                            As Boolean
    End Function

    <DllImport("hid.dll")> _
    Private Shared Function HidD_SetNumInputBuffers(ByVal HidDeviceObject As Integer, _
                                                     ByVal NumberBuffers As Integer) _
                                                     As Boolean
    End Function

    <DllImport("hid.dll")> _
    Private Shared Function HidD_SetOutputReport(ByVal HidDeviceObject As Integer, _
                                                    ByRef lpReportBuffer As Byte, _
                                                    ByVal ReportBufferLength As Integer) _
                                                    As Boolean
    End Function

    <DllImport("hid.dll")> _
    Private Shared Function HidP_GetCaps(ByVal PreparsedData As IntPtr, _
                                            ByRef Capabilities As HIDP_CAPS) _
                                            As Integer
    End Function

    <DllImport("hid.dll")> _
    Private Shared Function HidP_GetValueCaps(ByVal ReportType As Short, _
                                                ByRef ValueCaps As Byte, _
                                                ByRef ValueCapsLength As Short, _
                                                ByVal PreparsedData As IntPtr) _
                                                As Integer
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function CreateEvent(ByRef SecurityAttributes As SECURITY_ATTRIBUTES, _
                                         ByVal bManualReset As Boolean, _
                                         ByVal bInitialState As Boolean, _
                                         ByVal lpName As String) _
                                         As Integer
    End Function

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function CreateFile(ByVal lpFileName As String, _
                                        ByVal dwDesiredAccess As Integer, _
                                        ByVal dwShareMode As Integer, _
                                        ByRef lpSecurityAttributes As SECURITY_ATTRIBUTES, _
                                        ByVal dwCreationDisposition As Integer, _
                                        ByVal dwFlagsAndAttributes As Integer, _
                                        ByVal hTemplateFile As Integer) _
                                        As Int32
    End Function

    <DllImport("kernel32.dll")> _
    Private Shared Function CloseHandle(ByVal hObject As Int32) As Boolean
    End Function

    <DllImport("hid.dll")> _
    Private Shared Function HidD_GetPreparsedData(ByVal HidDeviceObject As Int32, _
                                                    ByRef PreparsedData As IntPtr) _
                                                    As Boolean
    End Function

    <DllImport("hid.dll")> _
    Private Shared Function HidD_FreePreparsedData(ByRef PreparsedData As IntPtr) As Boolean
    End Function

    <DllImport("hid.dll")> _
    Private Shared Function HidD_GetAttributes(ByVal HidDeviceObject As Int32, _
                                                ByRef Attributes As HIDD_ATTRIBUTES) _
                                                As Boolean
    End Function

    <DllImport("kernel32.dll")> _
    Private Shared Function CancelIo(ByVal hFile As Int32) As Boolean
    End Function

    <DllImport("kernel32.dll")> _
    Private Shared Function ReadFile(ByVal hFile As Int32, _
                                     ByRef lpBuffer As Byte, _
                                     ByVal nNumberOfBytesToRead As Integer, _
                                     ByRef lpNumberOfBytesRead As Integer, _
                                     ByRef lpOverlapped As OVERLAPPED) _
                                     As Boolean
    End Function

    <DllImport("kernel32.dll")> _
    Private Shared Function WaitForSingleObject(ByVal hHandle As Integer, _
                                                ByVal dwMilliseconds As Integer) _
                                                As Integer
    End Function

    <DllImport("kernel32.dll")> _
    Private Shared Function WriteFile(ByVal hFile As Int32, _
                                        ByRef lpBuffer As Byte, _
                                        ByVal nNumberOfBytesToWrite As Integer, _
                                        ByRef lpNumberOfBytesWritten As Integer, _
                                        ByVal lpOverlapped As Integer) _
                                        As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function RegisterDeviceNotification(ByVal hRecipient As IntPtr, _
                                                        ByVal NotificationFilter As IntPtr, _
                                                        ByVal Flags As Int32) _
                                                        As IntPtr
    End Function

    <DllImport("setupapi.dll")> _
    Private Shared Function SetupDiCreateDeviceInfoList(ByRef ClassGuid As System.Guid, _
                                                         ByVal hwndParent As Integer) _
                                                         As Integer
    End Function

    <DllImport("setupapi.dll")> _
    Private Shared Function SetupDiDestroyDeviceInfoList(ByVal DeviceInfoSet As IntPtr) _
                                                         As Integer
    End Function

    <DllImport("setupapi.dll")> _
    Private Shared Function SetupDiEnumDeviceInterfaces(ByVal DeviceInfoSet As IntPtr, _
                                                         ByVal DeviceInfoData As Integer, _
                                                         ByRef InterfaceClassGuid As System.Guid, _
                                                         ByVal MemberIndex As Integer, _
                                                         ByRef DeviceInterfaceData As SP_DEVICE_INTERFACE_DATA) _
                                                         As Boolean
    End Function

    <DllImport("setupapi.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SetupDiGetClassDevs(ByRef ClassGuid As System.Guid, _
                                                 ByVal Enumerator As String, _
                                                 ByVal hwndParent As Integer, _
                                                 ByVal Flags As Integer) _
                                                 As IntPtr
    End Function

    <DllImport("setupapi.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function SetupDiGetDeviceInterfaceDetail(ByVal DeviceInfoSet As IntPtr, _
                                                             ByRef DeviceInterfaceData As SP_DEVICE_INTERFACE_DATA, _
                                                             ByVal DeviceInterfaceDetailData As IntPtr, _
                                                             ByVal DeviceInterfaceDetailDataSize As Integer, _
                                                             ByRef RequiredSize As Integer, _
                                                             ByVal DeviceInfoData As IntPtr) _
                                                             As Boolean
    End Function

    <DllImport("user32.dll")> _
    Private Shared Function UnregisterDeviceNotification(ByVal Handle As IntPtr) As Boolean
    End Function


    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function FormatMessage(ByVal dwFlags As Integer, _
                                            ByRef lpSource As Long, _
                                            ByVal dwMessageId As Integer, _
                                            ByVal dwLanguageZId As Integer, _
                                            ByVal lpBuffer As String, _
                                            ByVal nSize As Integer, _
                                            ByVal Arguments As Integer) _
                                            As Integer
    End Function



    ' =================================================================================================
    '  PRIVATE DATA
    ' =================================================================================================
    Friend MyDeviceDetected As Boolean

    Private USB_Timeout As Short
    Private DisplayResults As Boolean = False
    Private Capabilities As HIDP_CAPS
    Private DeviceAttributes As HIDD_ATTRIBUTES
    Private DevicePathName As String
    Private EventObject As Integer
    Private HIDHandle As Int32
    Private ReadHandle As Int32
    Private HIDOverlapped As OVERLAPPED
    Private Security As SECURITY_ATTRIBUTES
    Private MyDeviceInterfaceDetailData As SP_DEVICE_INTERFACE_DETAIL_DATA
    Private MyDeviceInterfaceData As SP_DEVICE_INTERFACE_DATA
    Private PreparsedData As IntPtr

    ' =================================================================================================
    '  PRIVATE FUNCTIONS  -  READ REPORT and WRITE REPORT
    ' =================================================================================================
    Private Function ReadReport() As Boolean
        Dim bResult As Boolean
        Dim iResult As Int32
        ReadReport = False

        ' -------------------------------------------- Read data from the device.
        Dim NumberOfBytesRead As Integer
        ' -------------------------------------------- Allocate a buffer for the report.
        ' -------------------------------------------- Byte 0 is the report ID
        ' -------------------------------------------- and the ReadBuffer array begins at 0,
        ' -------------------------------------------- so subtract 1 from the number of bytes.
        Dim ReadBuffer(Capabilities.InputReportByteLength - 1) As Byte

        ' -------------------------------------------- byref objects are to be pinned
        Dim pinnedReadBuffer As GCHandle
        pinnedReadBuffer = GCHandle.Alloc(ReadBuffer, GCHandleType.Pinned)
        Dim pinnedOverlappedStructure As GCHandle
        pinnedOverlappedStructure = GCHandle.Alloc(HIDOverlapped, GCHandleType.Pinned)
        Dim pinnedNumberOfBytesRead As GCHandle
        pinnedNumberOfBytesRead = GCHandle.Alloc(NumberOfBytesRead, GCHandleType.Pinned)


        '******************************************************************************
        'ReadFile
        'Returns: the report in ReadBuffer.
        'Requires: a device handle returned by CreateFile
        '(for overlapped I/O, CreateFile must be called with FILE_FLAG_OVERLAPPED),
        'the Input report length in bytes returned by HidP_GetCaps,
        'and an overlapped structure whose hEvent member is set to an event object.
        ' http://msdn.microsoft.com/en-us/library/aa365467(v=vs.85).aspx
        '******************************************************************************
        ' -------------------------------------------- Do an overlapped ReadFile.
        ' -------------------------------------------- The function returns immediately,
        ' -------------------------------------------- even if the data hasn't been received yet.
        bResult = ReadFile(ReadHandle, _
                             ReadBuffer(0), _
                             Capabilities.InputReportByteLength, _
                             NumberOfBytesRead, _
                             HIDOverlapped)


        If DisplayResults Then
            DisplayResultOfAPICall("ReadFile")
            DisplayResult("waiting for ReadFile")
        End If


        '******************************************************************************
        'WaitForSingleObject
        'Used with overlapped ReadFile.
        'Returns when ReadFile has received the requested amount of data or on timeout.
        'Requires an event object created with CreateEvent
        'and a timeout value in milliseconds.
        '******************************************************************************
        iResult = WaitForSingleObject(EventObject, USB_Timeout)
        If DisplayResults Then DisplayResultOfAPICall("WaitForSingleObject")


        ' -------------------------------------------------------------- find out if ReadFile completed or timeout
        Select Case iResult

            Case WAIT_OBJECT_0
                ' ------------------------------------------------------ readFile is completed
                If DisplayResults Then DisplayResult("ReadFile completed successfully.")

                ' ------------------------------------------------------ copy data to USB_RxData()
                For Count As Int32 = 1 To UBound(ReadBuffer)
                    USB_RxData(Count - 1) = ReadBuffer(Count)
                Next Count
                ReadReport = True

            Case WAIT_TIMEOUT
                ' ------------------------------------------------------ cancel the operation
                bResult = CancelIo(ReadHandle)
                If DisplayResults Then
                    DisplayResultOfAPICall("CancelIo")
                    DisplayResult("************ReadFile timeout*************")
                End If

                ' ------------------------------------ The timeout may have been because the device was removed,
                ' ------------------------------------ so close any open handles and
                ' ------------------------------------ set MyDeviceDetected=False to cause the application to
                ' ------------------------------------ look for the device on the next attempt.
                CloseHandle(HIDHandle)
                If DisplayResults Then DisplayResultOfAPICall("CloseHandle (HIDHandle)")
                CloseHandle(ReadHandle)
                If DisplayResults Then DisplayResultOfAPICall("CloseHandle (ReadHandle)")
                MyDeviceDetected = False

                'Beep_RepetitionLimited(150)
                'Debug.Print("timeout")

            Case Else

                'Beep_RepetitionLimited(150)
                'Debug.Print("undefined")

                If DisplayResults Then DisplayResult("Readfile undefined error")
                MyDeviceDetected = False

        End Select

        If DisplayResults Then
            DisplayResult(" Report ID: " & ReadBuffer(0))
            DisplayResult(" Report Data:")
            For Count As Int32 = 1 To UBound(ReadBuffer)
                DisplayResult(" " & Hex(ReadBuffer(Count)))
            Next Count
        End If

        ' -------------------------------------------- release the pinned objects
        pinnedReadBuffer.Free()
        pinnedOverlappedStructure.Free()
        pinnedNumberOfBytesRead.Free()
    End Function

    Private Sub WriteReport()
        Dim bResult As Boolean

        ' -------------------------------------------- Send data to the device.
        Dim Count As Int32
        Dim NumberOfBytesWritten As Integer

        ' -------------------------------------------- The SendBuffer array begins at 0,
        ' -------------------------------------------- so subtract 1 from the number of bytes.
        Dim SendBuffer(Capabilities.OutputReportByteLength - 1) As Byte

        ' -------------------------------------------- The first byte is the Report ID
        SendBuffer(0) = 0
        ' -------------------------------------------- The next bytes are data
        For Count = 1 To UBound(SendBuffer)
            SendBuffer(Count) = USB_TxData(Count - 1)
        Next Count

        ' --------------------------------------------  byref objects are to be pinned
        Dim pinnedSendBuffer As GCHandle
        pinnedSendBuffer = GCHandle.Alloc(SendBuffer, GCHandleType.Pinned)
        Dim pinnedNumberOfBytesWritten As GCHandle
        pinnedNumberOfBytesWritten = GCHandle.Alloc(NumberOfBytesWritten, GCHandleType.Pinned)

        '******************************************************************************
        'WriteFile
        'Sends a report to the device.
        'Returns: success or failure.
        'Requires: the handle returned by CreateFile and
        'The output report byte length returned by HidP_GetCaps
        '******************************************************************************
        bResult = WriteFile(HIDHandle, _
                            SendBuffer(0), _
                            Capabilities.OutputReportByteLength, _
                            NumberOfBytesWritten, _
                            0)

        ' -------------------------------------------- release the pinned objects
        pinnedSendBuffer.Free()
        pinnedNumberOfBytesWritten.Free()

        If DisplayResults Then
            DisplayResultOfAPICall("WriteFile")
            DisplayResult(" OutputReportByteLength = " & Capabilities.OutputReportByteLength)
            DisplayResult(" NumberOfBytesWritten = " & NumberOfBytesWritten)
            DisplayResult(" Report ID: " & SendBuffer(0))
            DisplayResult(" Report Data:")
            For Count = 1 To UBound(SendBuffer)
                DisplayResult(" " & Hex(SendBuffer(Count)))
            Next Count
        End If

    End Sub

    Private Sub PrepareForOverlappedTransfer()
        '******************************************************************************
        'CreateEvent
        'Creates an event object for the overlapped structure used with ReadFile.
        'Requires a security attributes structure or null,
        'Manual Reset = True (ResetEvent resets the manual reset object to nonsignaled),
        'Initial state = True (signaled),
        'and event object name (optional)
        'Returns a handle to the event object.
        '******************************************************************************
        If EventObject = 0 Then
            EventObject = CreateEvent(Security, False, True, "")
        End If
        If DisplayResults Then DisplayResultOfAPICall("CreateEvent")
        ' -------------------------------------------- Set the members of the overlapped structure.
        HIDOverlapped.Offset = 0
        HIDOverlapped.OffsetHigh = 0
        HIDOverlapped.hEvent = EventObject
    End Sub

    Private Sub GetDeviceCapabilities()
        Dim bResult As Boolean
        Dim iResult As Int32

        '******************************************************************************
        'HidD_GetPreparsedData
        'Returns: a pointer to a buffer containing information about the device's capabilities.
        'Requires: A handle returned by CreateFile.
        'There's no need to access the buffer directly,
        'but HidP_GetCaps and other API functions require a pointer to the buffer.
        '******************************************************************************

        ' -------------------------------------------- Preparsed Data is a pointer to a routine-allocated buffer.
        bResult = HidD_GetPreparsedData(HIDHandle, PreparsedData)
        If DisplayResults Then DisplayResultOfAPICall("HidD_GetPreparsedData")

        '******************************************************************************
        'HidP_GetCaps
        'Find out the device's capabilities.
        'For standard devices such as joysticks, you can find out the specific
        'capabilities of the device.
        'For a custom device, the software will probably know what the device is capable of,
        'so this call only verifies the information.
        'Requires: The pointer to a buffer containing the information.
        'The pointer is returned by HidD_GetPreparsedData.
        'Returns: a Capabilites structure containing the information.
        '******************************************************************************
        iResult = HidP_GetCaps(PreparsedData, Capabilities)

        If DisplayResults Then
            Dim ppData(29) As Byte
            Dim ppDataString As Object
            ppDataString = System.Convert.ToBase64String(ppData)
            '
            DisplayResult("  Usage: " & Hex(Capabilities.Usage))
            DisplayResult("  Usage Page: " & Hex(Capabilities.UsagePage))
            DisplayResult("  Input Report Byte Length: " & Capabilities.InputReportByteLength)
            DisplayResult("  Output Report Byte Length: " & Capabilities.OutputReportByteLength)
            DisplayResult("  Feature Report Byte Length: " & Capabilities.FeatureReportByteLength)
            DisplayResult("  Number of Link Collection Nodes: " & Capabilities.NumberLinkCollectionNodes)
            DisplayResult("  Number of Input Button Caps: " & Capabilities.NumberInputButtonCaps)
            DisplayResult("  Number of Input Value Caps: " & Capabilities.NumberInputValueCaps)
            DisplayResult("  Number of Input Data Indices: " & Capabilities.NumberInputDataIndices)
            DisplayResult("  Number of Output Button Caps: " & Capabilities.NumberOutputButtonCaps)
            DisplayResult("  Number of Output Value Caps: " & Capabilities.NumberOutputValueCaps)
            DisplayResult("  Number of Output Data Indices: " & Capabilities.NumberOutputDataIndices)
            DisplayResult("  Number of Feature Button Caps: " & Capabilities.NumberFeatureButtonCaps)
            DisplayResult("  Number of Feature Value Caps: " & Capabilities.NumberFeatureValueCaps)
            DisplayResult("  Number of Feature Data Indices: " & Capabilities.NumberFeatureDataIndices)

            ' ---------------------------------------------------------------------------------------
            ' HidP_GetValueCaps
            ' Returns a buffer containing an array of HidP_ValueCaps structures.
            ' Each structure defines the capabilities of one value.
            ' This application doesn't use this data.
            '
            ' -------------------------------------------- This is a guess. The byte array holds the structures.
            Dim ValueCaps(1023) As Byte
            iResult = HidP_GetValueCaps(HidP_Input, ValueCaps(0), Capabilities.NumberInputValueCaps, PreparsedData)
            DisplayResultOfAPICall("HidP_GetValueCaps")
            'lstResults.AddItem "ValueCaps= " & GetDataString((VarPtr(ValueCaps(0))), 180)
            ' --------------------------------------------  To use this data, copy the byte array into an array of structures
        End If

        ' ------------------------------------------------ Free the buffer reserved by HidD_GetPreparsedData
        bResult = HidD_FreePreparsedData(PreparsedData)
        If DisplayResults Then DisplayResultOfAPICall("HidD_FreePreparsedData")
    End Sub


    ' #################################################################################################
    '  PRIVATE - DISPLAY RESULTS FUNCTIONS
    ' #################################################################################################
    Private Shared USB_Results As TextBox

    Private Shared Function GetErrorString(ByVal LastError As Integer) As String
        ' ---------------------------------------- Returns the error message for the last error.
        Dim Bytes As Integer
        Dim ErrorString As String
        ErrorString = New String(Chr(0), 129)
        Bytes = Theremino_HID.FormatMessage(Theremino_HID.FORMAT_MESSAGE_FROM_SYSTEM, 0, LastError, 0, ErrorString, 128, 0)
        ' ---------------------------------------- Subtract two characters from the message to strip the CR and LF.
        If Bytes > 2 Then
            GetErrorString = Left(ErrorString, Bytes - 2)
        Else
            GetErrorString = ""
        End If
    End Function

    Private Shared Sub DisplayResultOfAPICall(ByRef FunctionName As String)
        Dim ErrorString As String
        If Not USB_Results Is Nothing Then
            ' -------------------------------------------- Avoid problems with very long lists
            If USB_Results.Text.Length > 32000 Then USB_Results.Clear()
            ' -------------------------------------------- Display the results of an API call.
            USB_Results.Text &= vbCrLf
            ErrorString = GetErrorString(Err.LastDllError)
            USB_Results.Text &= FunctionName & vbCrLf
            If ErrorString <> "Memoria insufficiente per eseguire il comando." Then
                USB_Results.Text &= "  Result = " & ErrorString & vbCrLf
            End If
            ' -------------------------------------------- Scroll to the bottom of the list box.
            'USB_Results.SelectedIndex = USB_Results.Items.Count - 1
        End If
    End Sub

    Private Shared Sub DisplayResult(ByRef Result As String)
        If Not USB_Results Is Nothing Then
            ' -------------------------------------------- Avoid problems with very long lists
            If USB_Results.Text.Length > 32000 Then USB_Results.Clear()
            ' -------------------------------------------- Display the results
            USB_Results.Text &= Result & vbCrLf
            ' -------------------------------------------- Scroll to the bottom of the list box.
            'USB_Results.SelectedIndex = USB_Results.Items.Count - 1
        End If
    End Sub

    Private Shared Sub DisplayGUID(ByRef g As Guid)
        If Not USB_Results Is Nothing Then
            DisplayResult("  GUID for system HIDs: " & g.ToString)
        End If
    End Sub



    ' =================================================================================================
    '  PUBLIC FUNCTIONS
    ' =================================================================================================
    Friend USB_TxData(8192) As Byte
    Friend USB_RxData(8192) As Byte

    Friend Sub New()
        USB_Timeout = 2000
        If Not OperatingSystemIsWindows Then
            New_Unix()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Dim bResult As Boolean
        ' -------------------------------------------- Actions that must execute when the program ends.
        ' -------------------------------------------- Close the open handles to the device.
        bResult = CloseHandle(HIDHandle)
        If DisplayResults Then DisplayResultOfAPICall("CloseHandle (HIDHandle)")
        ' --------------------------------------------
        bResult = CloseHandle(ReadHandle)
        If DisplayResults Then DisplayResultOfAPICall("CloseHandle (ReadHandle)")
        '
        Finalize_Unix()
    End Sub

    Friend Sub USB_Write_Read()
        ' ------------------------------------------------ do not charge the cpu if not detected
        If Not MyDeviceDetected Then
            System.Threading.Thread.Sleep(10)
            Return
        End If
        ' ------------------------------------------------ do the exchange
        If OperatingSystemIsWindows Then
            WriteReport()
            ReadReport()
        Else
            WriteReport_Unix()
            ReadReport_Unix()
        End If
    End Sub


    ' -----------------------------------------------------------------------------------------------------------
    '  GetUsbDeviceString is used to disable/enable the usb to master communication
    ' ----------------------------------------------------------------------------------------------------------- 
    '    "USB\ROOT_HUB&VID1002&PID438A" <<< HUB
    ' 
    '    "USB\Vid_04d8&Pid_3eff"        <<< HID
    '
    '    DevicePathName = "\\?\hid#vid_04d8&pid_3eff#6&26f3c096&1&0000#{4d1e55b2-f16f-11cf-88cb-001111000030}"
    ' -----------------------------------------------------------------------------------------------------------
    'Friend Function GetUsbDeviceString() As String
    '    Dim s As String
    '    s = DevicePathName
    '    Debug.Print(s)
    '    Return s
    'End Function


    ' =====================================================================================
    '  All the USB operations can be accessed using the following data and functions
    ' =====================================================================================
    ' USB_VendorID                  integer value (16bit)
    ' USB_ProductID                 integer value (16bit)
    ' USB_Timeout                   timeout (in mS) (if data are not received)
    ' USB_TxData(xxx)               Byte array with the output-data ( length is determined in the firmware )
    ' USB_RxData(xxx)               Byte array with the input-data ( length is determined in the firmware )
    ' USB_Results                   a ListBox useful to debug return values
    ' USB_ReadWrite()               call this function to perform the data exchange

    ' =====================================================================================
    ' USB_VendorID and USB_ProductID must match the device's firmware values
    ' 0925 = Lakeview Research's
    ' 04D8 = Microchip
    ' =====================================================================================


    ' #################################################################################################
    '  FIND and INITIALIZE THEREMINO HIDS
    ' #################################################################################################
    Friend Shared Sub FindThereminoHids(ByVal Reconnect As Boolean)

        Const USB_VendorID As Short = &H4D8    ' VendorID  = Microchip
        Const USB_ProductID As Short = &H3EFF  ' ProductID = Theremino

        Dim LastDevice As Boolean
        Dim bResult As Boolean
        Dim iResult As Int32
        Dim DeviceInfoSet As IntPtr

        '******************************************************************************
        'HidD_GetHidGuid
        'Get the GUID for all system HIDs.
        'Returns: the GUID in HidGuid.
        'The routine doesn't return a value in Result
        'but the routine is declared as a function for consistency with the other API calls.
        '******************************************************************************
        Dim HidGuid As System.Guid
        HidGuid = System.Guid.Empty
        HidD_GetHidGuid(HidGuid)
        DisplayGUID(HidGuid)

        '******************************************************************************
        'SetupDiGetClassDevs
        'Returns: a handle to a device information set for all installed devices.
        'Requires: the HidGuid returned in GetHidGuid.
        '******************************************************************************
        DeviceInfoSet = SetupDiGetClassDevs(HidGuid, _
                                            vbNullString, _
                                            0, _
                                            DIGCF_PRESENT Or DIGCF_DEVICEINTERFACE)

        DisplayResultOfAPICall("SetupDiClassDevs")

        '******************************************************************************
        'SetupDiEnumDeviceInterfaces
        'On return, MyDeviceInterfaceData contains the handle to a
        'SP_DEVICE_INTERFACE_DATA structure for a detected device.
        'Requires:
        'the DeviceInfoSet returned in SetupDiGetClassDevs.
        'the HidGuid returned in GetHidGuid.
        'An index to specify a device.
        '******************************************************************************

        ' ------------------------------------------- Begin with 0 and increment until no more devices are detected.
        Dim MemberIndex As Int32
        MemberIndex = 0
        LastDevice = False

        ' ------------------------------------------- 
        Dim masterID As Int32 = 0
        Dim _master As Master
        If Reconnect AndAlso masterID <= Masters.Count - 1 Then
            _master = Masters(masterID)
        Else
            _master = New Master(masterID)
        End If
        _master.Hid = New Theremino_HID

        Dim Detected As Boolean

        Do
            Detected = False

            ' ------------------------------------------- Values for SECURITY_ATTRIBUTES structure
            _master.Hid.Security.lpSecurityDescriptor = 0
            _master.Hid.Security.bInheritHandle = True
            _master.Hid.Security.nLength = Len(_master.Hid.Security)


            ' ------------------------------ The cbSize element of the MyDeviceInterfaceData structure
            ' ------------------------------ must be set to the structure's size in bytes. The size is 28 bytes.
            _master.Hid.MyDeviceInterfaceData.cbSize = Marshal.SizeOf(_master.Hid.MyDeviceInterfaceData)
            bResult = SetupDiEnumDeviceInterfaces(DeviceInfoSet, _
                                                  0, _
                                                  HidGuid, _
                                                  MemberIndex, _
                                                  _master.Hid.MyDeviceInterfaceData)

            DisplayResultOfAPICall("SetupDiEnumDeviceInterfaces")

            If Not bResult Then LastDevice = True

            ' ------------------------------------------- If a device exists, display the information returned.
            If bResult Then

                DisplayResult("  DeviceInfoSet for device #" & CStr(MemberIndex) & ": ")
                DisplayResult("  cbSize = " & CStr(_master.Hid.MyDeviceInterfaceData.cbSize))
                DisplayResult("  Flags = " & Hex(_master.Hid.MyDeviceInterfaceData.Flags))


                '******************************************************************************
                'SetupDiGetDeviceInterfaceDetail
                'Returns: an SP_DEVICE_INTERFACE_DETAIL_DATA structure
                'containing information about a device.
                'To retrieve the information, call this function twice.
                'The first time returns the size of the structure in Needed.
                'The second time returns a pointer to the data in DeviceInfoSet.
                'Requires:
                'A DeviceInfoSet returned by SetupDiGetClassDevs and
                'an SP_DEVICE_INTERFACE_DATA structure returned by SetupDiEnumDeviceInterfaces.
                '*******************************************************************************
                Dim BufferSize As Int32
                bResult = SetupDiGetDeviceInterfaceDetail(DeviceInfoSet, _
                                                          _master.Hid.MyDeviceInterfaceData, _
                                                          IntPtr.Zero, _
                                                          0, _
                                                          BufferSize, _
                                                          IntPtr.Zero)
                DisplayResultOfAPICall("SetupDiGetDeviceInterfaceDetail")
                DisplayResult("  (OK to say too small)")
                DisplayResult("  Required buffer size for the data: " & BufferSize)

                ' ------------------------------------------- Store the structure's size.
                _master.Hid.MyDeviceInterfaceDetailData.cbSize = Len(_master.Hid.MyDeviceInterfaceDetailData)

                ' ------------------------------------------- Allocate memory using the returned buffer size.
                Dim DetailDataBuffer As IntPtr = Marshal.AllocHGlobal(BufferSize)

                ' ------------------------------------------- Store cbSize in the first 4 bytes of the array
                Marshal.WriteInt32(DetailDataBuffer, 4 + Marshal.SystemDefaultCharSize)
                'Debug.WriteLine("cbsize = " & MyDeviceInterfaceDetailData.cbSize)

                ' ------------------------------------------- Call SetupDiGetDeviceInterfaceDetail again.
                ' ------------------------------------------- This time, pass a pointer to DetailDataBuffer
                ' ------------------------------------------- and the returned required buffer size.
                bResult = SetupDiGetDeviceInterfaceDetail(DeviceInfoSet, _
                                                            _master.Hid.MyDeviceInterfaceData, _
                                                            DetailDataBuffer, _
                                                            BufferSize, _
                                                            BufferSize, _
                                                            IntPtr.Zero)
                DisplayResultOfAPICall(" Result of second call: ")
                DisplayResult("  MyDeviceInterfaceDetailData.cbSize: " & CStr(_master.Hid.MyDeviceInterfaceDetailData.cbSize))

                ' ------------------------------------------- Convert the byte array to a string.
                ' ------------------------------------------- Skip over cbsize (4 bytes) to get the address of the devicePathName.
                Dim pdevicePathName As IntPtr = New IntPtr(DetailDataBuffer.ToInt32 + 4)
                _master.Hid.DevicePathName = Marshal.PtrToStringAuto(pdevicePathName)
                DisplayResult("  Device pathname: ")
                DisplayResult("    " & _master.Hid.DevicePathName)


                '******************************************************************************
                'CreateFile
                'Returns: a handle that enables reading and writing to the device.
                'Requires:
                'The DevicePathName returned by SetupDiGetDeviceInterfaceDetail.
                '******************************************************************************
                _master.Hid.HIDHandle = CreateFile(_master.Hid.DevicePathName, _
                                                   GENERIC_WRITE, _
                                                   FILE_SHARE_READ Or FILE_SHARE_WRITE, _
                                                   _master.Hid.Security, _
                                                   OPEN_EXISTING, _
                                                   0, _
                                                   0)
                DisplayResultOfAPICall("CreateFile")
                DisplayResult("  Returned handle: " & Hex(_master.Hid.HIDHandle) & "h")


                ' ------------------------------------------- Now we can find out if it's the device we're looking for.

                '******************************************************************************
                'HidD_GetAttributes
                'Requests information from the device.
                'Requires: The handle returned by CreateFile.
                'Returns: an HIDD_ATTRIBUTES structure containing
                'the Vendor ID, Product ID, and Product Version Number.
                'Use this information to determine if the detected device
                'is the one we're looking for.
                '******************************************************************************

                ' ---------------------------------------- Set the Size property to the number of bytes in the structure.
                'UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
                _master.Hid.DeviceAttributes.Size = Marshal.SizeOf(_master.Hid.DeviceAttributes)
                bResult = HidD_GetAttributes(_master.Hid.HIDHandle, _master.Hid.DeviceAttributes)

                If Not USB_Results Is Nothing Then
                    DisplayResultOfAPICall("HidD_GetAttributes")
                    If bResult Then
                        DisplayResult("  HIDD_ATTRIBUTES structure filled without error.")
                    Else
                        DisplayResult("  Error in filling HIDD_ATTRIBUTES structure.")
                    End If
                    DisplayResult("  Structure size: " & _master.Hid.DeviceAttributes.Size)
                    DisplayResult("  Vendor ID: " & Hex(_master.Hid.DeviceAttributes.VendorID))
                    DisplayResult("  Product ID: " & Hex(_master.Hid.DeviceAttributes.ProductID))
                    DisplayResult("  Version Number: " & Hex(_master.Hid.DeviceAttributes.VersionNumber))
                End If

                ' ---------------------------------------- Find out if the device matches the one we're looking for.
                If (_master.Hid.DeviceAttributes.VendorID = USB_VendorID) And (_master.Hid.DeviceAttributes.ProductID = USB_ProductID) Then
                    ' -------------------------------- It's the desired device.
                    DisplayResult("  My device detected")
                    Detected = True
                Else
                    ' -------------------------------- If it's not the one we want, close its handle.
                    bResult = CloseHandle(_master.Hid.HIDHandle)
                    DisplayResultOfAPICall("CloseHandle")
                End If
            End If
            ' -------------------------------------------- Keep looking until we find the device or there are no more left to examine.
            MemberIndex = MemberIndex + 1



            If Detected Then
                ' -------------------------------- Learn the capabilities of the device
                _master.Hid.GetDeviceCapabilities()
                ' -------------------------------- Get another handle for the overlapped ReadFiles.
                _master.Hid.ReadHandle = CreateFile(_master.Hid.DevicePathName, _
                                            GENERIC_READ, _
                                            FILE_SHARE_READ Or FILE_SHARE_WRITE, _
                                            _master.Hid.Security, _
                                            OPEN_EXISTING, _
                                            FILE_FLAG_OVERLAPPED, _
                                            0)

                DisplayResultOfAPICall("CreateFile, ReadHandle")
                DisplayResult("  Returned handle: " & Hex(_master.Hid.ReadHandle) & "h")


                _master.Hid.PrepareForOverlappedTransfer()

                ' ---------------------------------------- insert Master and Hid in the Masters list
                _master.Hid.MyDeviceDetected = True

                ' ---------------------------------------- reconnect or prepare a new Master
                If Reconnect Then
                    masterID += 1
                Else
                    Masters.Add(_master)
                    masterID += 1
                    ' ------------------------------------ prepare a new master
                    _master = New Master(masterID)
                    _master.Hid = New Theremino_HID
                End If

            End If

        Loop Until (LastDevice = True)

        ' ------------------------------------------------ Free the memory reserved for the
        ' ------------------------------------------------ DeviceInfoSet returned by SetupDiGetClassDevs.
        iResult = SetupDiDestroyDeviceInfoList(DeviceInfoSet)
        DisplayResultOfAPICall("DestroyDeviceInfoList")

    End Sub


End Class