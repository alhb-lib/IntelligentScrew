
' ===============================================================================
'  HI ACCURACY TIMER
' ===============================================================================
'  Hi accuracy over long times: +/- 1mS
'  Precision on short time: +/- 1mS
'  Precise and Accurate SamplingTime down to 2 mS
'  Imprecise but accurate timings down to 0.5 mS and less
'  Fractional sampling times (for example 2.5 mS or 0.3 mS) are valid
'  Maximum run time before loosing precision = 3170 Years (double = 14 digits)
' ===============================================================================

Public Class AccurateTimer

    ' =========================================================================
    '  PUBLIC
    ' ========================================================================= 
    Friend Event Tick As TimerElapsedEventHandler
    Friend Delegate Sub TimerElapsedEventHandler(ByVal TotalMillisec As Double)

    Friend Sub [Stop]()
        StopTimerThreadFlag = True
        While TimerThread IsNot Nothing
            System.Threading.Thread.Sleep(10)
        End While
    End Sub
    Friend Sub Start()
        [Stop]()
        StopTimerThreadFlag = False
        TimerThread = New System.Threading.Thread(AddressOf TimerThread_Execute)
        TimerThread.IsBackground = True
        TimerThread.Priority = Threading.ThreadPriority.Highest
        TimerThread.Start()
    End Sub
    Public Property Interval() As Double
        Get
            Return SamplingTime_ms
        End Get
        Set(ByVal Interval As Double)
            If Interval < 0.1 Then Interval = 0.1
            SamplingTime_ms = Interval
            STW.Reset()
            STW.Start()
            ThisTime = 0
            NextTime = 0
        End Set
    End Property

    ' =========================================================================
    '  PRIVATE
    ' ========================================================================= 
    Private SamplingTime_ms As Double = 100
    Private TimerThread As System.Threading.Thread
    Private StopTimerThreadFlag As Boolean = False
    Private STW As Diagnostics.Stopwatch = New Diagnostics.Stopwatch()
    Private ThisTime As Double = 0
    Private NextTime As Double = 0

    Private Sub TimerThread_Execute()
        SchedulerMaxPrecision()
        STW.Reset()
        STW.Start()
        ThisTime = 0
        NextTime = 0
        Do
            NextTime += SamplingTime_ms
            While STW.Elapsed.TotalMilliseconds < NextTime
                Threading.Thread.Sleep(1)
                ThisTime = STW.Elapsed.TotalMilliseconds
            End While
            ' -------------------------------------------------------------------------
            RaiseEvent Tick(ThisTime)
            ' -------------------------------------------------------------------------
        Loop Until StopTimerThreadFlag
        TimerThread = Nothing
        SchedulerDefaultPrecision()
    End Sub

    ' =========================================================================
    '  WINDOWS SCHEDULER PRECISION
    ' ========================================================================= 
    Private Declare Function timeBeginPeriod Lib "winmm.dll" (ByVal uPeriod As Int32) As Int32
    Private Declare Function timeEndPeriod Lib "winmm.dll" (ByVal uPeriod As Int32) As Int32
    Private Sub SchedulerMaxPrecision()
        If OperatingSystemIsWindows Then
            timeBeginPeriod(1)
        End If
    End Sub
    Private Sub SchedulerDefaultPrecision()
        If OperatingSystemIsWindows Then
            timeEndPeriod(1)
        End If
    End Sub

End Class
