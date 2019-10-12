Public Class FIFO

    Friend Structure FifoEntry
        Public Value1 As Single
        Public Value2 As Single
        Sub New(ByVal v1 As Single, ByVal v2 As Single)
            Value1 = v1
            Value2 = v2
        End Sub
    End Structure

    Private m_FifoLength As Int32
    Private m_WriteIndex As Int32
    'Private m_ReadIndex As Int32
    Private m_CircularBuffer() As FifoEntry
    Private m_NumEntries As Int32

    Friend Sub New(ByVal FifoLength As Int32)
        m_FifoLength = FifoLength
        ReDim m_CircularBuffer(m_FifoLength - 1)
        Flush()
    End Sub

    Friend Sub Flush()
        'm_ReadIndex = 0
        m_WriteIndex = 0
        m_NumEntries = 0
    End Sub

    Friend Function GetWriteIndex() As Int32
        Return m_WriteIndex
    End Function

    'Friend Sub SetReadIndex(ByVal position As Int32)
    '    m_ReadIndex = position
    '    While m_ReadIndex < 0
    '        m_ReadIndex += m_FifoLength
    '    End While
    'End Sub

    Friend Sub SetWriteIndex(ByVal position As Int32)
        m_WriteIndex = position
        While m_WriteIndex >= m_FifoLength
            m_WriteIndex -= m_FifoLength
        End While
    End Sub

    Friend Sub SetNumEntries(ByVal n As Int32)
        m_NumEntries = n
    End Sub

    Friend Function GetNumEntries() As Int32
        Return m_NumEntries
    End Function

    Friend Function GetBuffer() As FifoEntry()
        Return m_CircularBuffer
    End Function

    Friend Sub AddElement(ByVal Value As FifoEntry)
        m_CircularBuffer(m_WriteIndex) = Value
        m_WriteIndex += 1
        If m_WriteIndex >= m_FifoLength Then m_WriteIndex = 0
        m_NumEntries += 1
        If m_NumEntries > m_FifoLength Then
            m_NumEntries = m_FifoLength
        End If
    End Sub

    'Friend Function GetElement() As FifoEntry
    '    GetElement = m_CircularBuffer(m_ReadIndex)
    '    m_ReadIndex += 1
    '    If m_ReadIndex >= m_FifoLength Then m_ReadIndex = 0
    'End Function

    Friend Function GetElement(ByVal Index As Int32) As FifoEntry
        While Index < 0 : Index += m_FifoLength : End While
        While Index >= m_FifoLength : Index -= m_FifoLength : End While
        Return m_CircularBuffer(Index)
    End Function

    Friend Function CorrectIndex(ByVal Index As Int32) As Int32
        While Index < 0 : Index += m_FifoLength : End While
        While Index >= m_FifoLength : Index -= m_FifoLength : End While
        Return Index
    End Function

    'Friend Sub AddArray(ByVal Values() As FifoEntry)
    '    For i As Int32 = 0 To Values.Length - 1
    '        AddElement(Values(i))
    '    Next
    'End Sub

    'Friend Sub GetArray(ByRef Values() As FifoEntry)
    '    For i As Int32 = 0 To Values.Length - 1
    '        Values(i) = GetElement()
    '    Next
    'End Sub

End Class
