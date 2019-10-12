Imports System.Runtime.InteropServices


Friend Class TheHidApi

    Private dev As IntPtr

    Public Sub New()
        dev = IntPtr.Zero
    End Sub

    Public Function IsHidOpen() As Boolean
        Return dev <> IntPtr.Zero
    End Function

    Public Sub HidOpen(ByVal vid As UShort, ByVal pid As UShort, ByVal serial As String)
        If dev <> IntPtr.Zero Then
            Throw New Exception("a device is already opened; close it first.")
        End If
        the_hid_init()
        Dim ret As IntPtr = the_hid_open(vid, pid, serial)
        dev = ret
    End Sub

    Public Function HidRead(ByVal buffer As Byte(), ByVal length As Integer) As Integer
        HidAssertValidDev()
        Dim ret As Integer = the_hid_read(dev, buffer, CUInt(length))
        If ret < 0 Then
            Throw New Exception("Failed to Read.")
        End If
        Return ret
    End Function

    Public Function HidWrite(ByVal buffer As Byte()) As Integer
        HidAssertValidDev()
        Dim ret As Integer = the_hid_write(dev, buffer, CUInt(buffer.Length))
        'if (ret < 0)
        '	throw new Exception ("failed to send feature report");
        Return ret
    End Function

    Public Sub HidClose()
        HidAssertValidDev()
        the_hid_close(dev)
        the_hid_exit()
        dev = IntPtr.Zero
    End Sub

    Private Sub HidAssertValidDev()
        If dev = IntPtr.Zero Then
            Throw New Exception("No device opened")
        End If
    End Sub


    <DllImport("ThereminoHidApi")> _
    Private Shared Function the_hid_init() As Integer
    End Function

    <DllImport("ThereminoHidApi")> _
    Private Shared Function the_hid_exit() As Integer
    End Function

    <DllImport("ThereminoHidApi")> _
    Private Shared Function the_hid_read(ByVal device As IntPtr, _
                                         <Out(), MarshalAs(UnmanagedType.LPArray)> ByVal data As Byte(), _
                                         ByVal length As UInteger) As Integer
    End Function

    <DllImport("ThereminoHidApi")> _
    Private Shared Function the_hid_open(ByVal vid As UShort, _
                                         ByVal pid As UShort, _
                                         <MarshalAs(UnmanagedType.LPWStr)> ByVal serial As String) As IntPtr
    End Function

    <DllImport("ThereminoHidApi")> _
    Private Shared Sub the_hid_close(ByVal device As IntPtr)
    End Sub

    <DllImport("ThereminoHidApi")> _
    Private Shared Function the_hid_write(ByVal device As IntPtr, _
                                          <[In](), MarshalAs(UnmanagedType.LPArray)> ByVal data As Byte(), _
                                          ByVal length As UInteger) As Integer
    End Function

    ' unused
    'public static extern void   hid_free_enumeration(struct hid_device_info *devs)
    'public static extern struct hid_device_info * hid_enumerate(unsigned short vendor_id, unsigned short product_id);
End Class



' #################################################################################################
'  PARTIAL THEREMINO_HID CLASS
' #################################################################################################
Partial Friend Class Theremino_HID

    Private HidDevice_Unix As TheHidApi

    ' =================================================================================================
    '  PRIVATE FUNCTIONS  -  READ REPORT and WRITE REPORT
    ' =================================================================================================
    Private Function ReadReport_Unix() As Boolean
        ReadReport_Unix = False

        ' -------------------------------------------- Read data from the device.
        Dim NumberOfBytesRead As Integer
        ' -------------------------------------------- Allocate a buffer for the report.
        ' -------------------------------------------- Byte 0 is the report ID
        ' -------------------------------------------- and the ReadBuffer array begins at 0,
        ' -------------------------------------------- so subtract 1 from the number of bytes.
        Dim ReadBuffer(64) As Byte

        ' -------------------------------------------- byref objects are to be pinned
        Dim pinnedReadBuffer As GCHandle
        pinnedReadBuffer = GCHandle.Alloc(ReadBuffer, GCHandleType.Pinned)

        NumberOfBytesRead = HidDevice_Unix.HidRead(ReadBuffer, 65)

        If NumberOfBytesRead > 0 Then
            ' ------------------------------------------------------ copy data to USB_RxData()
            For Count As Int32 = 0 To UBound(ReadBuffer)
                USB_RxData(Count) = ReadBuffer(Count)
            Next Count
            ReadReport_Unix = True
        End If

        ' -------------------------------------------- release the pinned objects
        pinnedReadBuffer.Free()
    End Function

    Private Sub WriteReport_Unix()
        ' -------------------------------------------- Send data to the device.
        Dim Count As Int32
        Dim NumberOfBytesWritten As Integer

        ' -------------------------------------------- The SendBuffer array begins at 0,
        ' -------------------------------------------- so subtract 1 from the number of bytes.
        Dim SendBuffer(64) As Byte

        ' -------------------------------------------- The first byte is the Report ID
        SendBuffer(0) = 0
        ' -------------------------------------------- The next bytes are data
        For Count = 1 To UBound(SendBuffer)
            SendBuffer(Count) = USB_TxData(Count - 1)
        Next Count

        NumberOfBytesWritten = HidDevice_Unix.HidWrite(SendBuffer)
    End Sub


    ' =================================================================================================
    '  "PUBLIC" FUNCTIONS
    ' =================================================================================================
    Private Sub New_Unix()
        Finalize_Unix()
        HidDevice_Unix = New TheHidApi
    End Sub

    Private Sub Finalize_Unix()
        If HidDevice_Unix IsNot Nothing AndAlso HidDevice_Unix.IsHidOpen Then
            HidDevice_Unix.HidClose()
        End If
        HidDevice_Unix = Nothing
    End Sub


    ' =================================================================================================
    '  Shared methods
    ' =================================================================================================
    Friend Shared Sub FindThereminoHids_Unix(ByVal Reconnect As Boolean)

        Const USB_VendorID As Short = &H4D8    ' VendorID  = Microchip
        Const USB_ProductID As Short = &H3EFF  ' ProductID = Theremino

        Dim LastDevice As Boolean
        Dim bResult As Boolean

        LastDevice = False

        ' ------------------------------------------- 
        Dim masterID As Int32 = 0
        Dim _master As Master
        _master = New Master(masterID)
        _master.Hid = New Theremino_HID

        Dim Detected As Boolean

        Do
            Detected = False

            bResult = True
            LastDevice = True

            ' ------------------------------------------- If a device exists, display the information returned.
            If bResult Then

                If Not _master.Hid.HidDevice_Unix.IsHidOpen() Then
                    _master.Hid.HidDevice_Unix.HidOpen(USB_VendorID, USB_ProductID, Nothing)
                End If

                If _master.Hid.HidDevice_Unix.IsHidOpen() Then
                    Detected = True
                End If

            End If

            ' -------------------------------------------- Keep looking until we find the device or there are no more left to examine.
            If Detected Then

                ' ---------------------------------------- insert Master and Hid in the Masters list
                _master.Hid.MyDeviceDetected = True
                Masters.Add(_master)
                masterID += 1

                ' ---------------------------------------- prepare a new master
                _master = New Master(masterID)
                _master.Hid = New Theremino_HID

            End If

        Loop Until (LastDevice = True)

    End Sub

End Class


