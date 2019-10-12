
Public Class ListViewFlickerFree
    Inherits System.Windows.Forms.ListView

    Public Sub New()
        MyBase.New()
    End Sub

    ' =====================================================================================
    '  Owner Drawn - ColumnHeaders
    ' =====================================================================================
    Public Header_BackColor1 As Color = Color.FromArgb(255, 255, 200)
    Public Header_BackColor2 As Color = Color.FromArgb(200, 200, 200)
    Public Header_ForeColor As Color = Color.FromArgb(50, 40, 0)
    Public Header_ShadowColor As Color = Color.FromArgb(0, 120, 120, 120)
    Public Header_Font As Font = New Font("Tahoma", 11, FontStyle.Regular)
    Public Header_TextVerticalPosition As Int32 = 0
    Public Header_TextAlignments(-1) As StringAlignment

    Private Sub MyDrawColumnHeader(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles Me.DrawColumnHeader
        '
        Dim g As Graphics = e.Graphics
        Dim x1 As Integer = e.Bounds.Left
        Dim x2 As Integer = e.Bounds.Right
        Dim y1 As Integer = e.Bounds.Top
        Dim y2 As Integer = e.Bounds.Bottom
        '
        If e.Bounds.Width > 0 Then
            g.FillRectangle(New System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, _
                                                                             Header_BackColor1, _
                                                                             Header_BackColor2, _
                                                                             Drawing2D.LinearGradientMode.Vertical), _
                                                                             e.Bounds)
            '
            ' ----------------------------------------------------------------- divisions
            g.DrawLine(Pens.Gold, x2 - 1, y1, x2 - 1, y2)
            g.DrawLine(Pens.Gold, x2, y1, x2, y2)
            g.DrawLine(Pens.DarkSlateBlue, x1, y2 - 1, x2, y2 - 1)
            ' ----------------------------------------------------------------- headers text horizzontal alignments
            Dim sf As StringFormat = New StringFormat
            sf.Alignment = StringAlignment.Near
            If e.ColumnIndex < Header_TextAlignments.Length Then
                sf.Alignment = Header_TextAlignments(e.ColumnIndex)
            End If
            ' ----------------------------------------------------------------- headers text vertical position
            Dim dy As Int32
            dy = (e.Bounds.Height - Header_Font.Height) \ 2 - 1 + Header_TextVerticalPosition
            Dim textrec As RectangleF = New RectangleF(e.Bounds.X - 2, _
                                                       e.Bounds.Y + dy, _
                                                       e.Bounds.Width + 2, _
                                                       e.Bounds.Height)
            ' ----------------------------------------------------------------- draw the Shadow
            If Header_ShadowColor.A <> 0 Then
                textrec.Offset(1, 1)
                g.DrawString(e.Header.Text, Header_Font, _
                                      New SolidBrush(Header_ShadowColor), textrec, sf)
                textrec.Offset(-1, -1)
            End If
            ' ----------------------------------------------------------------- draw the Text
            g.DrawString(e.Header.Text, _
                         Header_Font, _
                         New SolidBrush(Header_ForeColor), _
                         textrec, sf)
        End If
    End Sub

    ' =====================================================================================
    '  Owner Drawn - ITEMS and SUBITEMS
    ' =====================================================================================
    Private Sub MyDrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewItemEventArgs) Handles Me.DrawItem
        e.DrawDefault = True
    End Sub

    Private Sub MyDrawSubItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewSubItemEventArgs) Handles Me.DrawSubItem
        e.DrawDefault = True
    End Sub

    ' ===============================================================================================
    '  DISABLE ERASE BACKGROUND
    ' ===============================================================================================
    Const WM_ERASEBKGND As Int32 = &H14
    Const LVM_INSERTITEMA As Int32 = &H1007
    Const LVM_INSERTITEMW As Int32 = &H104D
    Const LVM_INSERTGROUP As Int32 = &H1091
    Const LVM_DELETEITEM As Int32 = &H1008
    Const LVM_DELETEALLITEMS As Int32 = &H1009

    Private EraseBkgEnabled As Boolean = True

    <DebuggerStepThrough()> _
    Protected Overrides Sub WndProc(ByRef m As Message)
        If Me.Items.Count = 0 Then EraseBkgEnabled = True
        Select Case m.Msg
            Case WM_ERASEBKGND
                If EraseBkgEnabled Then
                    EraseBkgEnabled = False
                    MyBase.WndProc(m)
                Else
                    m.Result = IntPtr.Zero
                End If
            Case LVM_INSERTGROUP, LVM_INSERTITEMA, LVM_INSERTITEMW, LVM_DELETEITEM, LVM_DELETEALLITEMS
                MyBase.WndProc(m)
                EraseBkgEnabled = True
            Case Else
                MyBase.WndProc(m)
        End Select
    End Sub

    ' =====================================================================================
    '  EVENTS
    ' =====================================================================================
    Private Sub ListViewFlickerFree_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectedIndexChanged
        EraseBkgEnabled = True
    End Sub
    Private Sub ListViewFlickerFree_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles Me.Layout
        EraseBkgEnabled = True
    End Sub
    Private Sub ListViewFlickerFree_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        EraseBkgEnabled = True
        Invalidate()
    End Sub


    ' ==============================================================================================
    '  THE FOLLOWING PARTS ARE USED ONLY FOR A LIST-VIEW WITH LABEL-EDIT ENABLED
    ' ==============================================================================================
    Private Sub ListViewFlickerFree_BeforeLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles Me.BeforeLabelEdit
        EraseBkgEnabled = True
    End Sub
    Private Sub ListViewFlickerFree_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles Me.AfterLabelEdit
        EraseBkgEnabled = True
    End Sub

    ' ==============================================================================================
    '  The following part is used to detect KeyDown, KeyUp and KeyPress while editing LABEL
    ' ==============================================================================================
    Private Declare Function SendMessage Lib "user32.dll" Alias "SendMessageW" _
                                                            (ByVal hWnd As IntPtr, _
                                                             ByVal msg As Integer, _
                                                             ByVal wp As IntPtr, _
                                                             ByVal lp As IntPtr) As IntPtr

    Private Label As LabelTextBox

    Protected Sub OnLabelKeyDown(ByVal e As KeyEventArgs)
        EraseBkgEnabled = True
    End Sub
    Protected Sub OnLabelKeyUp(ByVal e As KeyEventArgs)
        EraseBkgEnabled = True
    End Sub
    Protected Sub OnLabelKeyPress(ByVal e As KeyPressEventArgs)
        EraseBkgEnabled = True
    End Sub

    Private Sub BeforeLabelEdit_ForKeyEvents(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles Me.BeforeLabelEdit
        Label = New LabelTextBox(Me)
        Const LVM_GETEDITCONTROL As Integer = 4096 + 24
        Dim hdl As IntPtr = SendMessage(Me.Handle, LVM_GETEDITCONTROL, IntPtr.Zero, IntPtr.Zero)
        Me.Label.AssignHandle(hdl)
    End Sub
    Private Sub AfterLabelEdit_ForKeyEvents(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles Me.AfterLabelEdit
        Me.Label.ReleaseHandle()
    End Sub

    Private Class LabelTextBox
        Inherits NativeWindow

        Private Parent As ListViewFlickerFree

        Public Sub New(ByVal parent As ListViewFlickerFree)
            MyBase.New()
            Me.Parent = parent
        End Sub

        Protected Overrides Sub WndProc(ByRef m As Message)
            Select Case m.Msg
                Case 256
                    Dim args As KeyEventArgs = New KeyEventArgs(CType(m.WParam, Keys))
                    Me.Parent.OnLabelKeyDown(args)
                    If args.Handled Then Return
                Case 257
                    Dim args As KeyEventArgs = New KeyEventArgs(CType(m.WParam, Keys))
                    Me.Parent.OnLabelKeyUp(args)
                Case 258
                    Dim args As KeyPressEventArgs = New KeyPressEventArgs(ChrW(m.WParam.ToInt32))
                    Me.Parent.OnLabelKeyPress(args)
                    If args.Handled Then Return
            End Select
            MyBase.WndProc(m)
        End Sub
    End Class

End Class
