
Partial Friend Class Master

    Private TimerEnabled As Boolean = False
    Private ThreadStop As Boolean = False
    Private objThread As Threading.Thread

    Private Sub DataExchangeThread()
        Do
            If Not TimerEnabled Then Exit Do
            If ThreadStop Then Exit Do
            DataExchange()
        Loop
    End Sub

    Private Sub DataExchangeThread_Start()
        If Not TimerEnabled Then Return
        SyncLock mActionLock
            If objThread Is Nothing Then
                objThread = New Threading.Thread(AddressOf DataExchangeThread)
                ' --------------------------------------------------------- a Background Thread closes automatically with the application
                objThread.IsBackground = True
                ' --------------------------------------------------------- set the Priority of the thread.
                objThread.Priority = Threading.ThreadPriority.Highest
                ' --------------------------------------------------------- start the thread.
                ThreadStop = False
                objThread.Start()
            End If
            System.Threading.Thread.Sleep(0)
        End SyncLock
    End Sub

    Private Sub DataExchangeThread_Stop()
        ' --------------------------------------- stop the thread
        ThreadStop = True
        ' --------------------------------------- wait the thread to stop
        If objThread IsNot Nothing Then
            objThread.Join(2000)
        End If
        ' ---------------------------------------
        objThread = Nothing
    End Sub

    Friend Sub StartTimedOperations()
        If Not Me.ConfigValid Then Return
        TimerEnabled = True
        DataExchangeThread_Start()
        SyncLock mActionLock
        End SyncLock
    End Sub

    Friend Sub StopTimedOperations()
        TimerEnabled = False
        DataExchangeThread_Stop()
        SyncLock mActionLock
        End SyncLock
    End Sub

End Class
