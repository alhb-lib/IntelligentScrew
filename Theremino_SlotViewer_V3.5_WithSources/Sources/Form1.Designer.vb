<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DesignerRectTracker1 As Theremino_SlotViewer.DesignerRectTracker = New Theremino_SlotViewer.DesignerRectTracker
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim CBlendItems1 As Theremino_SlotViewer.cBlendItems = New Theremino_SlotViewer.cBlendItems
        Dim CBlendItems2 As Theremino_SlotViewer.cBlendItems = New Theremino_SlotViewer.cBlendItems
        Dim DesignerRectTracker2 As Theremino_SlotViewer.DesignerRectTracker = New Theremino_SlotViewer.DesignerRectTracker
        Dim DesignerRectTracker3 As Theremino_SlotViewer.DesignerRectTracker = New Theremino_SlotViewer.DesignerRectTracker
        Dim CBlendItems3 As Theremino_SlotViewer.cBlendItems = New Theremino_SlotViewer.cBlendItems
        Dim CBlendItems4 As Theremino_SlotViewer.cBlendItems = New Theremino_SlotViewer.cBlendItems
        Dim DesignerRectTracker4 As Theremino_SlotViewer.DesignerRectTracker = New Theremino_SlotViewer.DesignerRectTracker
        Me.Label_NumSlots = New System.Windows.Forms.Label
        Me.Label_FirstSlot = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel_Controls = New System.Windows.Forms.Panel
        Me.lbl_Decimals = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PanelDummy = New System.Windows.Forms.Panel
        Me.txt_Decimals = New Theremino_SlotViewer.MyTextBox
        Me.txt_Zoom = New Theremino_SlotViewer.MyTextBox
        Me.chk_Colors = New Theremino_SlotViewer.MyButton
        Me.txt_MinValue = New Theremino_SlotViewer.MyTextBox
        Me.chk_Vertical = New Theremino_SlotViewer.MyButton
        Me.txt_FirstSlot = New Theremino_SlotViewer.MyTextBox
        Me.txt_MaxValue = New Theremino_SlotViewer.MyTextBox
        Me.txt_NumSlots = New Theremino_SlotViewer.MyTextBox
        Me.Panel_Controls.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label_NumSlots
        '
        Me.Label_NumSlots.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_NumSlots.Location = New System.Drawing.Point(1, 34)
        Me.Label_NumSlots.Name = "Label_NumSlots"
        Me.Label_NumSlots.Size = New System.Drawing.Size(54, 14)
        Me.Label_NumSlots.TabIndex = 189
        Me.Label_NumSlots.Text = "Num slots"
        Me.Label_NumSlots.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_FirstSlot
        '
        Me.Label_FirstSlot.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_FirstSlot.Location = New System.Drawing.Point(1, 1)
        Me.Label_FirstSlot.Name = "Label_FirstSlot"
        Me.Label_FirstSlot.Size = New System.Drawing.Size(56, 14)
        Me.Label_FirstSlot.TabIndex = 187
        Me.Label_FirstSlot.Text = "First slot"
        Me.Label_FirstSlot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 14)
        Me.Label1.TabIndex = 192
        Me.Label1.Text = "MaxValue"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel_Controls
        '
        Me.Panel_Controls.Controls.Add(Me.txt_Decimals)
        Me.Panel_Controls.Controls.Add(Me.lbl_Decimals)
        Me.Panel_Controls.Controls.Add(Me.txt_Zoom)
        Me.Panel_Controls.Controls.Add(Me.Label3)
        Me.Panel_Controls.Controls.Add(Me.chk_Colors)
        Me.Panel_Controls.Controls.Add(Me.Label2)
        Me.Panel_Controls.Controls.Add(Me.txt_MinValue)
        Me.Panel_Controls.Controls.Add(Me.chk_Vertical)
        Me.Panel_Controls.Controls.Add(Me.Label_FirstSlot)
        Me.Panel_Controls.Controls.Add(Me.Label1)
        Me.Panel_Controls.Controls.Add(Me.txt_FirstSlot)
        Me.Panel_Controls.Controls.Add(Me.txt_MaxValue)
        Me.Panel_Controls.Controls.Add(Me.txt_NumSlots)
        Me.Panel_Controls.Controls.Add(Me.Label_NumSlots)
        Me.Panel_Controls.Location = New System.Drawing.Point(4, 2)
        Me.Panel_Controls.Name = "Panel_Controls"
        Me.Panel_Controls.Size = New System.Drawing.Size(58, 249)
        Me.Panel_Controls.TabIndex = 193
        '
        'lbl_Decimals
        '
        Me.lbl_Decimals.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Decimals.Location = New System.Drawing.Point(1, 184)
        Me.lbl_Decimals.Name = "lbl_Decimals"
        Me.lbl_Decimals.Size = New System.Drawing.Size(52, 12)
        Me.lbl_Decimals.TabIndex = 198
        Me.lbl_Decimals.Text = "Decimals"
        Me.lbl_Decimals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 14)
        Me.Label3.TabIndex = 196
        Me.Label3.Text = "Zoom"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 14)
        Me.Label2.TabIndex = 194
        Me.Label2.Text = "MinValue"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        '
        'PanelDummy
        '
        Me.PanelDummy.Location = New System.Drawing.Point(66, 6)
        Me.PanelDummy.Name = "PanelDummy"
        Me.PanelDummy.Size = New System.Drawing.Size(31, 18)
        Me.PanelDummy.TabIndex = 99
        '
        'txt_Decimals
        '
        Me.txt_Decimals.ArrowsIncrement = 1
        Me.txt_Decimals.BackColor = System.Drawing.Color.MintCream
        Me.txt_Decimals.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_Decimals.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_Decimals.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Decimals.ForeColor = System.Drawing.Color.Black
        Me.txt_Decimals.Increment = 0.1
        Me.txt_Decimals.Location = New System.Drawing.Point(2, 199)
        Me.txt_Decimals.MaxValue = 9
        Me.txt_Decimals.MinValue = 0
        Me.txt_Decimals.Multiline = True
        Me.txt_Decimals.Name = "txt_Decimals"
        Me.txt_Decimals.NumericValue = 1
        Me.txt_Decimals.NumericValueInteger = 1
        Me.txt_Decimals.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_Decimals.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_Decimals.RoundingStep = 0
        Me.txt_Decimals.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_Decimals.Size = New System.Drawing.Size(50, 15)
        Me.txt_Decimals.SuppressZeros = True
        Me.txt_Decimals.TabIndex = 199
        Me.txt_Decimals.TabStop = False
        Me.txt_Decimals.Text = "1"
        Me.txt_Decimals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_Zoom
        '
        Me.txt_Zoom.ArrowsIncrement = 1
        Me.txt_Zoom.BackColor = System.Drawing.Color.MintCream
        Me.txt_Zoom.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_Zoom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_Zoom.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Zoom.ForeColor = System.Drawing.Color.Black
        Me.txt_Zoom.Increment = 0.1
        Me.txt_Zoom.Location = New System.Drawing.Point(2, 231)
        Me.txt_Zoom.MaxValue = 100
        Me.txt_Zoom.MinValue = 1
        Me.txt_Zoom.Multiline = True
        Me.txt_Zoom.Name = "txt_Zoom"
        Me.txt_Zoom.NumericValue = 10
        Me.txt_Zoom.NumericValueInteger = 10
        Me.txt_Zoom.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_Zoom.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_Zoom.RoundingStep = 0
        Me.txt_Zoom.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_Zoom.Size = New System.Drawing.Size(50, 15)
        Me.txt_Zoom.SuppressZeros = True
        Me.txt_Zoom.TabIndex = 197
        Me.txt_Zoom.TabStop = False
        Me.txt_Zoom.Text = "10"
        Me.txt_Zoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chk_Colors
        '
        Me.chk_Colors.BorderColor = System.Drawing.Color.DarkGray
        DesignerRectTracker1.IsActive = True
        DesignerRectTracker1.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker1.TrackerRectangle"), System.Drawing.RectangleF)
        Me.chk_Colors.CenterPtTracker = DesignerRectTracker1
        Me.chk_Colors.CheckButton = True
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))}
        CBlendItems1.iPoint = New Single() {0.0!, 0.8683274!, 1.0!}
        Me.chk_Colors.ColorFillBlend = CBlendItems1
        CBlendItems2.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))}
        CBlendItems2.iPoint = New Single() {0.0!, 0.2491103!, 1.0!}
        Me.chk_Colors.ColorFillBlendChecked = CBlendItems2
        Me.chk_Colors.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.chk_Colors.ColorFillSolidChecked = System.Drawing.SystemColors.Control
        Me.chk_Colors.Corners.All = CType(4, Short)
        Me.chk_Colors.Corners.LowerLeft = CType(4, Short)
        Me.chk_Colors.Corners.LowerRight = CType(4, Short)
        Me.chk_Colors.Corners.UpperLeft = CType(4, Short)
        Me.chk_Colors.Corners.UpperRight = CType(4, Short)
        Me.chk_Colors.DimFactorOver = 30
        Me.chk_Colors.FillType = Theremino_SlotViewer.MyButton.eFillType.LinearVertical
        Me.chk_Colors.FillTypeChecked = Theremino_SlotViewer.MyButton.eFillType.LinearVertical
        Me.chk_Colors.FocalPoints.CenterPtX = 1.0!
        Me.chk_Colors.FocalPoints.CenterPtY = 1.0!
        Me.chk_Colors.FocalPoints.FocusPtX = 0.0!
        Me.chk_Colors.FocalPoints.FocusPtY = 0.0!
        Me.chk_Colors.FocalPointsChecked.CenterPtX = 0.0!
        Me.chk_Colors.FocalPointsChecked.CenterPtY = 0.0!
        Me.chk_Colors.FocalPointsChecked.FocusPtX = 0.0!
        Me.chk_Colors.FocalPointsChecked.FocusPtY = 0.0!
        DesignerRectTracker2.IsActive = False
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.chk_Colors.FocusPtTracker = DesignerRectTracker2
        Me.chk_Colors.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Colors.Image = Nothing
        Me.chk_Colors.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk_Colors.ImageIndex = 0
        Me.chk_Colors.ImageSize = New System.Drawing.Size(16, 16)
        Me.chk_Colors.Location = New System.Drawing.Point(2, 139)
        Me.chk_Colors.Name = "chk_Colors"
        Me.chk_Colors.Shape = Theremino_SlotViewer.MyButton.eShape.Rectangle
        Me.chk_Colors.SideImage = Nothing
        Me.chk_Colors.SideImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk_Colors.SideImageSize = New System.Drawing.Size(32, 32)
        Me.chk_Colors.Size = New System.Drawing.Size(50, 17)
        Me.chk_Colors.TabIndex = 195
        Me.chk_Colors.Text = "Colors"
        Me.chk_Colors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk_Colors.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.chk_Colors.TextMargin = New System.Windows.Forms.Padding(0)
        Me.chk_Colors.TextShadow = System.Drawing.Color.Transparent
        '
        'txt_MinValue
        '
        Me.txt_MinValue.ArrowsIncrement = 1
        Me.txt_MinValue.BackColor = System.Drawing.Color.MintCream
        Me.txt_MinValue.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_MinValue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_MinValue.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MinValue.ForeColor = System.Drawing.Color.Black
        Me.txt_MinValue.Increment = 0.1
        Me.txt_MinValue.Location = New System.Drawing.Point(2, 116)
        Me.txt_MinValue.MaxValue = 1000000
        Me.txt_MinValue.MinValue = -1000000
        Me.txt_MinValue.Multiline = True
        Me.txt_MinValue.Name = "txt_MinValue"
        Me.txt_MinValue.NumericValue = 0
        Me.txt_MinValue.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_MinValue.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_MinValue.RoundingStep = 0
        Me.txt_MinValue.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_MinValue.Size = New System.Drawing.Size(50, 15)
        Me.txt_MinValue.SuppressZeros = True
        Me.txt_MinValue.TabIndex = 193
        Me.txt_MinValue.TabStop = False
        Me.txt_MinValue.Text = "0"
        Me.txt_MinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chk_Vertical
        '
        Me.chk_Vertical.BorderColor = System.Drawing.Color.DarkGray
        DesignerRectTracker3.IsActive = False
        DesignerRectTracker3.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker3.TrackerRectangle"), System.Drawing.RectangleF)
        Me.chk_Vertical.CenterPtTracker = DesignerRectTracker3
        Me.chk_Vertical.CheckButton = True
        Me.chk_Vertical.Checked = True
        CBlendItems3.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))}
        CBlendItems3.iPoint = New Single() {0.0!, 0.8683274!, 1.0!}
        Me.chk_Vertical.ColorFillBlend = CBlendItems3
        CBlendItems4.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))}
        CBlendItems4.iPoint = New Single() {0.0!, 0.2491103!, 1.0!}
        Me.chk_Vertical.ColorFillBlendChecked = CBlendItems4
        Me.chk_Vertical.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.chk_Vertical.ColorFillSolidChecked = System.Drawing.SystemColors.Control
        Me.chk_Vertical.Corners.All = CType(4, Short)
        Me.chk_Vertical.Corners.LowerLeft = CType(4, Short)
        Me.chk_Vertical.Corners.LowerRight = CType(4, Short)
        Me.chk_Vertical.Corners.UpperLeft = CType(4, Short)
        Me.chk_Vertical.Corners.UpperRight = CType(4, Short)
        Me.chk_Vertical.DimFactorOver = 30
        Me.chk_Vertical.FillType = Theremino_SlotViewer.MyButton.eFillType.LinearVertical
        Me.chk_Vertical.FillTypeChecked = Theremino_SlotViewer.MyButton.eFillType.LinearVertical
        Me.chk_Vertical.FocalPoints.CenterPtX = 1.0!
        Me.chk_Vertical.FocalPoints.CenterPtY = 1.0!
        Me.chk_Vertical.FocalPoints.FocusPtX = 0.0!
        Me.chk_Vertical.FocalPoints.FocusPtY = 0.0!
        Me.chk_Vertical.FocalPointsChecked.CenterPtX = 0.0!
        Me.chk_Vertical.FocalPointsChecked.CenterPtY = 0.0!
        Me.chk_Vertical.FocalPointsChecked.FocusPtX = 0.0!
        Me.chk_Vertical.FocalPointsChecked.FocusPtY = 0.0!
        DesignerRectTracker4.IsActive = False
        DesignerRectTracker4.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker4.TrackerRectangle"), System.Drawing.RectangleF)
        Me.chk_Vertical.FocusPtTracker = DesignerRectTracker4
        Me.chk_Vertical.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Vertical.Image = Nothing
        Me.chk_Vertical.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk_Vertical.ImageIndex = 0
        Me.chk_Vertical.ImageSize = New System.Drawing.Size(16, 16)
        Me.chk_Vertical.Location = New System.Drawing.Point(2, 161)
        Me.chk_Vertical.Name = "chk_Vertical"
        Me.chk_Vertical.Shape = Theremino_SlotViewer.MyButton.eShape.Rectangle
        Me.chk_Vertical.SideImage = Nothing
        Me.chk_Vertical.SideImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk_Vertical.SideImageSize = New System.Drawing.Size(32, 32)
        Me.chk_Vertical.Size = New System.Drawing.Size(50, 17)
        Me.chk_Vertical.TabIndex = 190
        Me.chk_Vertical.Text = "Vertical"
        Me.chk_Vertical.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chk_Vertical.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.chk_Vertical.TextMargin = New System.Windows.Forms.Padding(0)
        Me.chk_Vertical.TextShadow = System.Drawing.Color.Transparent
        '
        'txt_FirstSlot
        '
        Me.txt_FirstSlot.ArrowsIncrement = 1
        Me.txt_FirstSlot.BackColor = System.Drawing.Color.MintCream
        Me.txt_FirstSlot.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_FirstSlot.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_FirstSlot.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_FirstSlot.ForeColor = System.Drawing.Color.Black
        Me.txt_FirstSlot.Increment = 0.1
        Me.txt_FirstSlot.Location = New System.Drawing.Point(2, 16)
        Me.txt_FirstSlot.MaxValue = 990
        Me.txt_FirstSlot.MinValue = 0
        Me.txt_FirstSlot.Multiline = True
        Me.txt_FirstSlot.Name = "txt_FirstSlot"
        Me.txt_FirstSlot.NumericValue = 0
        Me.txt_FirstSlot.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_FirstSlot.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_FirstSlot.RoundingStep = 0
        Me.txt_FirstSlot.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_FirstSlot.Size = New System.Drawing.Size(50, 15)
        Me.txt_FirstSlot.SuppressZeros = True
        Me.txt_FirstSlot.TabIndex = 1
        Me.txt_FirstSlot.TabStop = False
        Me.txt_FirstSlot.Text = "0"
        Me.txt_FirstSlot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_MaxValue
        '
        Me.txt_MaxValue.ArrowsIncrement = 1
        Me.txt_MaxValue.BackColor = System.Drawing.Color.MintCream
        Me.txt_MaxValue.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_MaxValue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_MaxValue.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MaxValue.ForeColor = System.Drawing.Color.Black
        Me.txt_MaxValue.Increment = 0.1
        Me.txt_MaxValue.Location = New System.Drawing.Point(2, 83)
        Me.txt_MaxValue.MaxValue = 1000000
        Me.txt_MaxValue.MinValue = -1000000
        Me.txt_MaxValue.Multiline = True
        Me.txt_MaxValue.Name = "txt_MaxValue"
        Me.txt_MaxValue.NumericValue = 1000
        Me.txt_MaxValue.NumericValueInteger = 1000
        Me.txt_MaxValue.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_MaxValue.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_MaxValue.RoundingStep = 0
        Me.txt_MaxValue.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_MaxValue.Size = New System.Drawing.Size(50, 15)
        Me.txt_MaxValue.SuppressZeros = True
        Me.txt_MaxValue.TabIndex = 191
        Me.txt_MaxValue.TabStop = False
        Me.txt_MaxValue.Text = "1000"
        Me.txt_MaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_NumSlots
        '
        Me.txt_NumSlots.ArrowsIncrement = 1
        Me.txt_NumSlots.BackColor = System.Drawing.Color.MintCream
        Me.txt_NumSlots.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_NumSlots.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_NumSlots.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NumSlots.ForeColor = System.Drawing.Color.Black
        Me.txt_NumSlots.Increment = 0.1
        Me.txt_NumSlots.Location = New System.Drawing.Point(2, 49)
        Me.txt_NumSlots.MaxValue = 255
        Me.txt_NumSlots.MinValue = 1
        Me.txt_NumSlots.Multiline = True
        Me.txt_NumSlots.Name = "txt_NumSlots"
        Me.txt_NumSlots.NumericValue = 10
        Me.txt_NumSlots.NumericValueInteger = 10
        Me.txt_NumSlots.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_NumSlots.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_NumSlots.RoundingStep = 0
        Me.txt_NumSlots.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_NumSlots.Size = New System.Drawing.Size(50, 15)
        Me.txt_NumSlots.SuppressZeros = True
        Me.txt_NumSlots.TabIndex = 2
        Me.txt_NumSlots.TabStop = False
        Me.txt_NumSlots.Text = "10"
        Me.txt_NumSlots.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightYellow
        Me.ClientSize = New System.Drawing.Size(282, 255)
        Me.Controls.Add(Me.Panel_Controls)
        Me.Controls.Add(Me.PanelDummy)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(290, 180)
        Me.Name = "Form1"
        Me.Opacity = 0
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Theremino Slot Viewer"
        Me.Panel_Controls.ResumeLayout(False)
        Me.Panel_Controls.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label_NumSlots As System.Windows.Forms.Label
    Friend WithEvents txt_NumSlots As MyTextBox
    Friend WithEvents Label_FirstSlot As System.Windows.Forms.Label
    Friend WithEvents txt_FirstSlot As MyTextBox
    Friend WithEvents chk_Vertical As MyButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_MaxValue As MyTextBox
    Friend WithEvents Panel_Controls As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents chk_Colors As MyButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_MinValue As MyTextBox
    Friend WithEvents txt_Zoom As Theremino_SlotViewer.MyTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PanelDummy As System.Windows.Forms.Panel
    Friend WithEvents txt_Decimals As Theremino_SlotViewer.MyTextBox
    Friend WithEvents lbl_Decimals As System.Windows.Forms.Label
End Class
