

Imports System.Math

Module Module_MathFunctions

    Friend Function AbsUint32Difference(ByVal n1 As UInt32, ByVal n2 As UInt32) As UInt32
        If n1 > n2 Then
            Return n1 - n2
        Else
            Return n2 - n1
        End If
    End Function


    ' -------------------------------------------------------------------------------------------
    '  TransferFunction in the range 0 to 1 for both input and output values
    '  Completely simmetric - With Gain and Gamma
    ' -------------------------------------------------------------------------------------------
    Private Function TransferFunction(ByVal x As Double, _
                                      ByVal Gain As Double, _
                                      ByVal Shift As Double, _
                                      ByVal Slope As Double, _
                                      ByVal ActivationGain As Double) As Double
        '
        x = 0.5 + (x - 0.5) * Gain
        '
        x += (Shift - 0.5) * (0.1 * (Slope - 1) + (Gain - 1))
        '
        x = TransferFunction_MidtoneCompress(x, Slope)
        '
        x *= ActivationGain
        '
        If x > 1 Then x = 1
        If x < 0 Then x = 0
        '
        Return x
    End Function

    ' -------------------------------------------------------------------------------------------
    '  Midtone compress in the range 0 to 1 for both input and output values
    '  Completely simmetric and precise
    ' -------------------------------------------------------------------------------------------
    Private Function TransferFunction_MidtoneCompress(ByVal x As Double, ByVal slope As Double) As Double
        If slope <= 0 Then slope = 0.0000001
        If x <= 0 Then x = 0.0000001
        If x >= 1 Then x = 0.9999999
        If x < 0.5 Then
            Return 0.5 * Math.Exp(-slope * Math.Log(0.5 / x))
        Else
            Return 1 - 0.5 * Math.Exp(-slope * Math.Log(0.5 / (1 - x)))
        End If
    End Function

    ' ------------------------------------------------------------------------------------------- 
    '   soft saturation ( variable with k ( k = 100 ? ) )
    ' -------------------------------------------------------------------------------------------
    Private Function TransferFunction_SoftSaturation(ByVal x As Double, ByVal k As Double) As Double
        Return 1 / (1 + k ^ (1 - 2 * x))
    End Function

End Module
