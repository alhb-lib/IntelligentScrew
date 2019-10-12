Module Module_ElectronicFormula

    ' --------------------------------------------------------------------------------------- CAPACITORS
    '                       1     
    ' CapSerial = ------------------------          S = 1/(1/a + 1/b)
    '                  1            1  
    '              --------- + ---------- 
    '                 Cap1        Cap2

    '              Cap1 * CapSerial  
    '     Cap2 = ------------------                 b = a · S / (a - S)   
    '              Cap1 - CapSerial

    Friend Function ELEC_Cserial(ByVal Cap1 As Double, ByVal Cap2 As Double) As Double
        Return 1 / (1 / Cap1 + 1 / Cap2)
    End Function
    Friend Function ELEC_C2_FromSerial(ByVal Cserial As Double, ByVal C1 As Double) As Double
        Return (C1 * Cserial) / (C1 - Cserial)
    End Function

    ' --------------------------------------------------------------------------------------- INDUCTORS
    Friend Function ELEC_Lserial(ByVal L1 As Double, ByVal L2 As Double) As Double
        Return 1 / (1 / L1 + 1 / L2)
    End Function
    Friend Function ELEC_L2_from_Lserial(ByVal L_serial As Double, ByVal L1 As Double) As Double
        Return (L1 * L_serial) / (L1 - L_serial)
    End Function

    ' --------------------------------------------------------------------------------------- RESISTORS
    Friend Function ELEC_Rparallel(ByVal R1 As Double, ByVal R2 As Double) As Double
        Return 1 / (1 / R1 + 1 / R2)
    End Function
    Friend Function ELEC_R2_FromParallel(ByVal Rparallel As Double, ByVal R1 As Double) As Double
        Return (R1 * Rparallel) / (R1 - Rparallel)
    End Function

End Module
