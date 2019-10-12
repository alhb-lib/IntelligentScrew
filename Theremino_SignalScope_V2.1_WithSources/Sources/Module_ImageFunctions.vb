Imports System.Drawing.Imaging

Module ImageFunctions

    ' =============================================================
    '  SAVE IMAGE
    ' =============================================================
    Friend Sub SaveImage_(ByVal Prefix As String, ByVal cnt As Control)
        Dim img As Image = GetImage(cnt)
        Dim sfd As SaveFileDialog = New SaveFileDialog()
        sfd.DefaultExt = ".jpg"
        sfd.InitialDirectory = Application.StartupPath + "\Images\"
        IO.Directory.CreateDirectory(sfd.InitialDirectory)
        sfd.Filter = "Portable network graphics (*.png)|*png|JPEG image (*.jpg)|*.jpg"
        sfd.FilterIndex = 2
        sfd.FileName = Prefix & Date.Now.ToString("yyyy_MM_dd_HH_mm_ss")
        If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
            SaveImage(img, sfd.FileName, If(sfd.FilterIndex = 2, "jpg", "png"), 100)
        End If
    End Sub

    Private Function GetImage(ByVal cnt As Control) As Bitmap
        Dim s As Size = cnt.Size
        Dim bmp As Bitmap = New Bitmap(s.Width, s.Height)
        cnt.DrawToBitmap(bmp, New Rectangle(0, 0, s.Width, s.Height))
        Return bmp
    End Function

    Private Sub SaveImage(ByVal img As Image, _
                         ByVal filename As String, _
                         ByVal extension As String, _
                         ByVal Quality As Int32)

        extension = LCase(extension)
        filename = RemoveExtension(filename)
        filename += "." & extension
        '
        If img Is Nothing Then Exit Sub
        Try
            File_Kill(filename)
            If extension = "jpg" Then
                Dim ImageEncoders() As ImageCodecInfo = ImageCodecInfo.GetImageEncoders()
                Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
                Dim myEncoderParameters As New EncoderParameters(1)
                Dim myEncoderParameter As New EncoderParameter(myEncoder, Quality)
                myEncoderParameters.Param(0) = myEncoderParameter
                img.Save(filename, ImageEncoders(1), myEncoderParameters)
            Else
                img.Save(filename, ImageFormatFromFileExtension(extension))
            End If
        Catch
            MsgBox("Image save error", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Function ImageFormatFromFileExtension(ByVal extension As String) As ImageFormat
        Select Case LCase(extension)
            Case "jpg" : Return ImageFormat.Jpeg
            Case "png" : Return ImageFormat.Png
            Case "tiff" : Return ImageFormat.Tiff
            Case "exif" : Return ImageFormat.Exif
            Case "emf" : Return ImageFormat.Emf
            Case "wmf" : Return ImageFormat.Wmf
            Case "gif" : Return ImageFormat.Gif
            Case "bmp" : Return ImageFormat.Bmp
                'Case "ico" : Return ImageFormat.Icon
            Case Else : Return ImageFormat.Jpeg
        End Select
    End Function

    Friend Sub File_Kill(ByVal filename As String)
        If My.Computer.FileSystem.FileExists(filename) Then
            My.Computer.FileSystem.DeleteFile(filename, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        End If
    End Sub

    Public Function RemoveExtension(ByVal str As String) As String
        On Error Resume Next
        Return IO.Path.GetDirectoryName(str) & "\" & IO.Path.GetFileNameWithoutExtension(str)
    End Function

End Module
