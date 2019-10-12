<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim DesignerRectTracker1 As Theremino_HAL.DesignerRectTracker = New Theremino_HAL.DesignerRectTracker
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Dim CBlendItems1 As Theremino_HAL.cBlendItems = New Theremino_HAL.cBlendItems
        Dim CBlendItems2 As Theremino_HAL.cBlendItems = New Theremino_HAL.cBlendItems
        Dim DesignerRectTracker2 As Theremino_HAL.DesignerRectTracker = New Theremino_HAL.DesignerRectTracker
        Dim DesignerRectTracker3 As Theremino_HAL.DesignerRectTracker = New Theremino_HAL.DesignerRectTracker
        Dim CBlendItems3 As Theremino_HAL.cBlendItems = New Theremino_HAL.cBlendItems
        Dim CBlendItems4 As Theremino_HAL.cBlendItems = New Theremino_HAL.cBlendItems
        Dim DesignerRectTracker4 As Theremino_HAL.DesignerRectTracker = New Theremino_HAL.DesignerRectTracker
        Dim DesignerRectTracker5 As Theremino_HAL.DesignerRectTracker = New Theremino_HAL.DesignerRectTracker
        Dim CBlendItems5 As Theremino_HAL.cBlendItems = New Theremino_HAL.cBlendItems
        Dim CBlendItems6 As Theremino_HAL.cBlendItems = New Theremino_HAL.cBlendItems
        Dim DesignerRectTracker6 As Theremino_HAL.DesignerRectTracker = New Theremino_HAL.DesignerRectTracker
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label_ScaleMin = New System.Windows.Forms.Label
        Me.Label_ScaleMax = New System.Windows.Forms.Label
        Me.Label_VerticalScale = New System.Windows.Forms.Label
        Me.pbox_Details2 = New System.Windows.Forms.PictureBox
        Me.lbl_Details2 = New System.Windows.Forms.Label
        Me.LabelPin1 = New System.Windows.Forms.Label
        Me.LabelPin2 = New System.Windows.Forms.Label
        Me.Label_ScrollSpeed = New System.Windows.Forms.Label
        Me.pbox_Details1 = New System.Windows.Forms.PictureBox
        Me.lbl_Details1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.pbox_ScrollingScope = New System.Windows.Forms.PictureBox
        Me.Label_Scale1b = New System.Windows.Forms.Label
        Me.Label_Scale2b = New System.Windows.Forms.Label
        Me.Label_Scale3b = New System.Windows.Forms.Label
        Me.Label_Scale3 = New System.Windows.Forms.Label
        Me.Label_Scale2 = New System.Windows.Forms.Label
        Me.Label_Scale1 = New System.Windows.Forms.Label
        Me.Timer_60Hz = New System.Windows.Forms.Timer(Me.components)
        Me.txt_ScaleMin = New Theremino_HAL.MyTextBox
        Me.txt_ScaleMax = New Theremino_HAL.MyTextBox
        Me.cmb_ScrollSpeed = New Theremino_HAL.MyComboBox
        Me.btn_Run = New Theremino_HAL.MyButton
        Me.cmb_UnitsPerDivision = New Theremino_HAL.MyComboBox
        Me.btn_SetZero = New Theremino_HAL.MyButton
        Me.btn_ShowRawCount = New Theremino_HAL.MyButton
        Me.GroupBox3.SuspendLayout()
        CType(Me.pbox_Details2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbox_Details1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbox_ScrollingScope, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.GroupBox3.Controls.Add(Me.Label_ScaleMin)
        Me.GroupBox3.Controls.Add(Me.txt_ScaleMin)
        Me.GroupBox3.Controls.Add(Me.Label_ScaleMax)
        Me.GroupBox3.Controls.Add(Me.txt_ScaleMax)
        Me.GroupBox3.Controls.Add(Me.cmb_ScrollSpeed)
        Me.GroupBox3.Controls.Add(Me.btn_Run)
        Me.GroupBox3.Controls.Add(Me.cmb_UnitsPerDivision)
        Me.GroupBox3.Controls.Add(Me.Label_VerticalScale)
        Me.GroupBox3.Controls.Add(Me.btn_SetZero)
        Me.GroupBox3.Controls.Add(Me.pbox_Details2)
        Me.GroupBox3.Controls.Add(Me.lbl_Details2)
        Me.GroupBox3.Controls.Add(Me.LabelPin1)
        Me.GroupBox3.Controls.Add(Me.LabelPin2)
        Me.GroupBox3.Controls.Add(Me.btn_ShowRawCount)
        Me.GroupBox3.Controls.Add(Me.Label_ScrollSpeed)
        Me.GroupBox3.Controls.Add(Me.pbox_Details1)
        Me.GroupBox3.Controls.Add(Me.lbl_Details1)
        Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 9.75!)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 249)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(502, 168)
        Me.GroupBox3.TabIndex = 137
        Me.GroupBox3.TabStop = False
        '
        'Label_ScaleMin
        '
        Me.Label_ScaleMin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ScaleMin.Location = New System.Drawing.Point(395, 54)
        Me.Label_ScaleMin.Name = "Label_ScaleMin"
        Me.Label_ScaleMin.Size = New System.Drawing.Size(39, 13)
        Me.Label_ScaleMin.TabIndex = 178
        Me.Label_ScaleMin.Text = "Min"
        Me.Label_ScaleMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_ScaleMax
        '
        Me.Label_ScaleMax.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ScaleMax.Location = New System.Drawing.Point(395, 34)
        Me.Label_ScaleMax.Name = "Label_ScaleMax"
        Me.Label_ScaleMax.Size = New System.Drawing.Size(39, 13)
        Me.Label_ScaleMax.TabIndex = 176
        Me.Label_ScaleMax.Text = "Max"
        Me.Label_ScaleMax.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_VerticalScale
        '
        Me.Label_VerticalScale.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_VerticalScale.Location = New System.Drawing.Point(385, 79)
        Me.Label_VerticalScale.Name = "Label_VerticalScale"
        Me.Label_VerticalScale.Size = New System.Drawing.Size(112, 13)
        Me.Label_VerticalScale.TabIndex = 171
        Me.Label_VerticalScale.Text = "Vertical scale"
        Me.Label_VerticalScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbox_Details2
        '
        Me.pbox_Details2.BackColor = System.Drawing.Color.MintCream
        Me.pbox_Details2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbox_Details2.Location = New System.Drawing.Point(141, 144)
        Me.pbox_Details2.Name = "pbox_Details2"
        Me.pbox_Details2.Size = New System.Drawing.Size(124, 16)
        Me.pbox_Details2.TabIndex = 167
        Me.pbox_Details2.TabStop = False
        '
        'lbl_Details2
        '
        Me.lbl_Details2.BackColor = System.Drawing.Color.MintCream
        Me.lbl_Details2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Details2.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Details2.Location = New System.Drawing.Point(141, 32)
        Me.lbl_Details2.Name = "lbl_Details2"
        Me.lbl_Details2.Size = New System.Drawing.Size(124, 108)
        Me.lbl_Details2.TabIndex = 166
        '
        'LabelPin1
        '
        Me.LabelPin1.AutoSize = True
        Me.LabelPin1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPin1.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelPin1.Location = New System.Drawing.Point(11, 13)
        Me.LabelPin1.Name = "LabelPin1"
        Me.LabelPin1.Size = New System.Drawing.Size(33, 13)
        Me.LabelPin1.TabIndex = 165
        Me.LabelPin1.Text = "- - -"
        '
        'LabelPin2
        '
        Me.LabelPin2.AutoSize = True
        Me.LabelPin2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPin2.ForeColor = System.Drawing.Color.Maroon
        Me.LabelPin2.Location = New System.Drawing.Point(142, 13)
        Me.LabelPin2.Name = "LabelPin2"
        Me.LabelPin2.Size = New System.Drawing.Size(33, 13)
        Me.LabelPin2.TabIndex = 164
        Me.LabelPin2.Text = "- - -"
        '
        'Label_ScrollSpeed
        '
        Me.Label_ScrollSpeed.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ScrollSpeed.Location = New System.Drawing.Point(385, 122)
        Me.Label_ScrollSpeed.Name = "Label_ScrollSpeed"
        Me.Label_ScrollSpeed.Size = New System.Drawing.Size(112, 13)
        Me.Label_ScrollSpeed.TabIndex = 163
        Me.Label_ScrollSpeed.Text = "Scroll speed"
        Me.Label_ScrollSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbox_Details1
        '
        Me.pbox_Details1.BackColor = System.Drawing.Color.MintCream
        Me.pbox_Details1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbox_Details1.Location = New System.Drawing.Point(9, 144)
        Me.pbox_Details1.Name = "pbox_Details1"
        Me.pbox_Details1.Size = New System.Drawing.Size(124, 16)
        Me.pbox_Details1.TabIndex = 103
        Me.pbox_Details1.TabStop = False
        '
        'lbl_Details1
        '
        Me.lbl_Details1.BackColor = System.Drawing.Color.MintCream
        Me.lbl_Details1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_Details1.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Details1.Location = New System.Drawing.Point(9, 32)
        Me.lbl_Details1.Name = "lbl_Details1"
        Me.lbl_Details1.Size = New System.Drawing.Size(124, 108)
        Me.lbl_Details1.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.GroupBox1.Controls.Add(Me.pbox_ScrollingScope)
        Me.GroupBox1.Controls.Add(Me.Label_Scale1b)
        Me.GroupBox1.Controls.Add(Me.Label_Scale2b)
        Me.GroupBox1.Controls.Add(Me.Label_Scale3b)
        Me.GroupBox1.Controls.Add(Me.Label_Scale3)
        Me.GroupBox1.Controls.Add(Me.Label_Scale2)
        Me.GroupBox1.Controls.Add(Me.Label_Scale1)
        Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(502, 238)
        Me.GroupBox1.TabIndex = 146
        Me.GroupBox1.TabStop = False
        '
        'pbox_ScrollingScope
        '
        Me.pbox_ScrollingScope.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbox_ScrollingScope.BackColor = System.Drawing.Color.AliceBlue
        Me.pbox_ScrollingScope.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbox_ScrollingScope.Location = New System.Drawing.Point(10, 16)
        Me.pbox_ScrollingScope.Name = "pbox_ScrollingScope"
        Me.pbox_ScrollingScope.Size = New System.Drawing.Size(426, 213)
        Me.pbox_ScrollingScope.TabIndex = 153
        Me.pbox_ScrollingScope.TabStop = False
        '
        'Label_Scale1b
        '
        Me.Label_Scale1b.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_Scale1b.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scale1b.ForeColor = System.Drawing.Color.Maroon
        Me.Label_Scale1b.Location = New System.Drawing.Point(436, 205)
        Me.Label_Scale1b.Name = "Label_Scale1b"
        Me.Label_Scale1b.Size = New System.Drawing.Size(65, 13)
        Me.Label_Scale1b.TabIndex = 177
        Me.Label_Scale1b.Text = "0"
        Me.Label_Scale1b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Scale2b
        '
        Me.Label_Scale2b.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label_Scale2b.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scale2b.ForeColor = System.Drawing.Color.Maroon
        Me.Label_Scale2b.Location = New System.Drawing.Point(436, 129)
        Me.Label_Scale2b.Name = "Label_Scale2b"
        Me.Label_Scale2b.Size = New System.Drawing.Size(65, 13)
        Me.Label_Scale2b.TabIndex = 176
        Me.Label_Scale2b.Text = "500"
        Me.Label_Scale2b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Scale3b
        '
        Me.Label_Scale3b.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_Scale3b.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scale3b.ForeColor = System.Drawing.Color.Maroon
        Me.Label_Scale3b.Location = New System.Drawing.Point(436, 25)
        Me.Label_Scale3b.Name = "Label_Scale3b"
        Me.Label_Scale3b.Size = New System.Drawing.Size(65, 13)
        Me.Label_Scale3b.TabIndex = 175
        Me.Label_Scale3b.Text = "1000"
        Me.Label_Scale3b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Scale3
        '
        Me.Label_Scale3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_Scale3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scale3.ForeColor = System.Drawing.Color.Blue
        Me.Label_Scale3.Location = New System.Drawing.Point(436, 12)
        Me.Label_Scale3.Name = "Label_Scale3"
        Me.Label_Scale3.Size = New System.Drawing.Size(65, 13)
        Me.Label_Scale3.TabIndex = 174
        Me.Label_Scale3.Text = "1000"
        Me.Label_Scale3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Scale2
        '
        Me.Label_Scale2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label_Scale2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scale2.ForeColor = System.Drawing.Color.Blue
        Me.Label_Scale2.Location = New System.Drawing.Point(436, 116)
        Me.Label_Scale2.Name = "Label_Scale2"
        Me.Label_Scale2.Size = New System.Drawing.Size(65, 13)
        Me.Label_Scale2.TabIndex = 173
        Me.Label_Scale2.Text = "500"
        Me.Label_Scale2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Scale1
        '
        Me.Label_Scale1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_Scale1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scale1.ForeColor = System.Drawing.Color.Blue
        Me.Label_Scale1.Location = New System.Drawing.Point(436, 218)
        Me.Label_Scale1.Name = "Label_Scale1"
        Me.Label_Scale1.Size = New System.Drawing.Size(65, 13)
        Me.Label_Scale1.TabIndex = 172
        Me.Label_Scale1.Text = "0"
        Me.Label_Scale1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer_60Hz
        '
        '
        'txt_ScaleMin
        '
        Me.txt_ScaleMin.ArrowsIncrement = 1
        Me.txt_ScaleMin.BackColor = System.Drawing.Color.MintCream
        Me.txt_ScaleMin.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_ScaleMin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_ScaleMin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_ScaleMin.Decimals = 3
        Me.txt_ScaleMin.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ScaleMin.ForeColor = System.Drawing.Color.Black
        Me.txt_ScaleMin.Increment = 0.2
        Me.txt_ScaleMin.Location = New System.Drawing.Point(430, 53)
        Me.txt_ScaleMin.MaxValue = 9999999
        Me.txt_ScaleMin.MinValue = -999999
        Me.txt_ScaleMin.Name = "txt_ScaleMin"
        Me.txt_ScaleMin.NumericValue = 0
        Me.txt_ScaleMin.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_ScaleMin.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_ScaleMin.RoundingStep = 0
        Me.txt_ScaleMin.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_ScaleMin.Size = New System.Drawing.Size(56, 15)
        Me.txt_ScaleMin.SuppressZeros = True
        Me.txt_ScaleMin.TabIndex = 177
        Me.txt_ScaleMin.Text = "0"
        Me.txt_ScaleMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_ScaleMax
        '
        Me.txt_ScaleMax.ArrowsIncrement = 1
        Me.txt_ScaleMax.BackColor = System.Drawing.Color.MintCream
        Me.txt_ScaleMax.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_ScaleMax.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_ScaleMax.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_ScaleMax.Decimals = 3
        Me.txt_ScaleMax.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ScaleMax.ForeColor = System.Drawing.Color.Black
        Me.txt_ScaleMax.Increment = 0.2
        Me.txt_ScaleMax.Location = New System.Drawing.Point(430, 33)
        Me.txt_ScaleMax.MaxValue = 9999999
        Me.txt_ScaleMax.MinValue = -999999
        Me.txt_ScaleMax.Name = "txt_ScaleMax"
        Me.txt_ScaleMax.NumericValue = 1000
        Me.txt_ScaleMax.NumericValueInteger = 1000
        Me.txt_ScaleMax.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_ScaleMax.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_ScaleMax.RoundingStep = 0
        Me.txt_ScaleMax.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_ScaleMax.Size = New System.Drawing.Size(56, 15)
        Me.txt_ScaleMax.SuppressZeros = True
        Me.txt_ScaleMax.TabIndex = 175
        Me.txt_ScaleMax.Text = "1000"
        Me.txt_ScaleMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmb_ScrollSpeed
        '
        Me.cmb_ScrollSpeed.ArrowButtonColor = System.Drawing.Color.Transparent
        Me.cmb_ScrollSpeed.ArrowColor = System.Drawing.Color.Transparent
        Me.cmb_ScrollSpeed.BackColor = System.Drawing.Color.MintCream
        Me.cmb_ScrollSpeed.BackColor_Focused = System.Drawing.Color.MintCream
        Me.cmb_ScrollSpeed.BackColor_Over = System.Drawing.Color.Moccasin
        Me.cmb_ScrollSpeed.BorderColor = System.Drawing.Color.PowderBlue
        Me.cmb_ScrollSpeed.BorderSize = 1
        Me.cmb_ScrollSpeed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmb_ScrollSpeed.DropDown_BackColor = System.Drawing.Color.AliceBlue
        Me.cmb_ScrollSpeed.DropDown_BackSelected = System.Drawing.Color.LightBlue
        Me.cmb_ScrollSpeed.DropDown_BorderColor = System.Drawing.Color.Gainsboro
        Me.cmb_ScrollSpeed.DropDown_ForeColor = System.Drawing.Color.Black
        Me.cmb_ScrollSpeed.DropDown_ForeSelected = System.Drawing.Color.Black
        Me.cmb_ScrollSpeed.DropDownHeight = 500
        Me.cmb_ScrollSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_ScrollSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_ScrollSpeed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_ScrollSpeed.ForeColor = System.Drawing.Color.Black
        Me.cmb_ScrollSpeed.IntegralHeight = False
        Me.cmb_ScrollSpeed.ItemHeight = 12
        Me.cmb_ScrollSpeed.Items.AddRange(New Object() {" 60 pixel/sec", " 30 pixel/sec", " 20 pixel/sec", " 10 pixel/sec", "   5 pixel/sec", "   2 pixel/sec", "   1 pixel/sec", "0.5 pixel/sec", "0.2 pixel/sec", "0.1 pixel/sec"})
        Me.cmb_ScrollSpeed.Location = New System.Drawing.Point(398, 139)
        Me.cmb_ScrollSpeed.Name = "cmb_ScrollSpeed"
        Me.cmb_ScrollSpeed.ShadowColor = System.Drawing.Color.Transparent
        Me.cmb_ScrollSpeed.Size = New System.Drawing.Size(88, 18)
        Me.cmb_ScrollSpeed.TabIndex = 174
        Me.cmb_ScrollSpeed.TabStop = False
        Me.cmb_ScrollSpeed.TextPosition = 1
        '
        'btn_Run
        '
        Me.btn_Run.BorderColor = System.Drawing.Color.DimGray
        DesignerRectTracker1.IsActive = False
        DesignerRectTracker1.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker1.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btn_Run.CenterPtTracker = DesignerRectTracker1
        Me.btn_Run.CheckButton = True
        Me.btn_Run.Checked = True
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))}
        CBlendItems1.iPoint = New Single() {0.0!, 0.5017921!, 1.0!}
        Me.btn_Run.ColorFillBlend = CBlendItems1
        CBlendItems2.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems2.iPoint = New Single() {0.0!, 0.3309608!, 1.0!}
        Me.btn_Run.ColorFillBlendChecked = CBlendItems2
        Me.btn_Run.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btn_Run.ColorFillSolidChecked = System.Drawing.SystemColors.Control
        Me.btn_Run.Corners.All = CType(6, Short)
        Me.btn_Run.Corners.LowerLeft = CType(6, Short)
        Me.btn_Run.Corners.LowerRight = CType(6, Short)
        Me.btn_Run.Corners.UpperLeft = CType(6, Short)
        Me.btn_Run.Corners.UpperRight = CType(6, Short)
        Me.btn_Run.DimFactorGray = -10
        Me.btn_Run.DimFactorOver = 30
        Me.btn_Run.FillType = Theremino_HAL.MyButton.eFillType.LinearVertical
        Me.btn_Run.FillTypeChecked = Theremino_HAL.MyButton.eFillType.LinearVertical
        Me.btn_Run.FocalPoints.CenterPtX = 0.2727273!
        Me.btn_Run.FocalPoints.CenterPtY = 0.5!
        Me.btn_Run.FocalPoints.FocusPtX = 0.0!
        Me.btn_Run.FocalPoints.FocusPtY = 0.0!
        Me.btn_Run.FocalPointsChecked.CenterPtX = 0.5!
        Me.btn_Run.FocalPointsChecked.CenterPtY = 0.5!
        Me.btn_Run.FocalPointsChecked.FocusPtX = 0.0!
        Me.btn_Run.FocalPointsChecked.FocusPtY = 0.0!
        DesignerRectTracker2.IsActive = False
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btn_Run.FocusPtTracker = DesignerRectTracker2
        Me.btn_Run.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Run.Image = Nothing
        Me.btn_Run.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_Run.ImageIndex = 0
        Me.btn_Run.ImageSize = New System.Drawing.Size(16, 16)
        Me.btn_Run.Location = New System.Drawing.Point(283, 32)
        Me.btn_Run.Name = "btn_Run"
        Me.btn_Run.Shape = Theremino_HAL.MyButton.eShape.Rectangle
        Me.btn_Run.SideImage = Nothing
        Me.btn_Run.SideImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_Run.SideImageSize = New System.Drawing.Size(32, 32)
        Me.btn_Run.Size = New System.Drawing.Size(90, 36)
        Me.btn_Run.TabIndex = 173
        Me.btn_Run.Text = "RUN"
        Me.btn_Run.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_Run.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Run.TextMargin = New System.Windows.Forms.Padding(0)
        Me.btn_Run.TextShadow = System.Drawing.Color.Transparent
        '
        'cmb_UnitsPerDivision
        '
        Me.cmb_UnitsPerDivision.ArrowButtonColor = System.Drawing.Color.Transparent
        Me.cmb_UnitsPerDivision.ArrowColor = System.Drawing.Color.Transparent
        Me.cmb_UnitsPerDivision.BackColor = System.Drawing.Color.MintCream
        Me.cmb_UnitsPerDivision.BackColor_Focused = System.Drawing.Color.MintCream
        Me.cmb_UnitsPerDivision.BackColor_Over = System.Drawing.Color.Moccasin
        Me.cmb_UnitsPerDivision.BorderColor = System.Drawing.Color.PowderBlue
        Me.cmb_UnitsPerDivision.BorderSize = 1
        Me.cmb_UnitsPerDivision.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmb_UnitsPerDivision.DropDown_BackColor = System.Drawing.Color.AliceBlue
        Me.cmb_UnitsPerDivision.DropDown_BackSelected = System.Drawing.Color.LightBlue
        Me.cmb_UnitsPerDivision.DropDown_BorderColor = System.Drawing.Color.Gainsboro
        Me.cmb_UnitsPerDivision.DropDown_ForeColor = System.Drawing.Color.Black
        Me.cmb_UnitsPerDivision.DropDown_ForeSelected = System.Drawing.Color.Black
        Me.cmb_UnitsPerDivision.DropDownHeight = 500
        Me.cmb_UnitsPerDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_UnitsPerDivision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_UnitsPerDivision.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_UnitsPerDivision.ForeColor = System.Drawing.Color.Black
        Me.cmb_UnitsPerDivision.IntegralHeight = False
        Me.cmb_UnitsPerDivision.ItemHeight = 12
        Me.cmb_UnitsPerDivision.Items.AddRange(New Object() {"Scale Min-Max", "50000", "20000", "10000", "5000", "2000", "1000", "500", "200", "100", "50", "20", "10", "5", "2", "1", "0.5", "0.2", "0.1", "0.05", "0.02", "0.01", "0.005", "0.002", "0.001", "0.0005", "0.0002", "0.0001"})
        Me.cmb_UnitsPerDivision.Location = New System.Drawing.Point(398, 96)
        Me.cmb_UnitsPerDivision.Name = "cmb_UnitsPerDivision"
        Me.cmb_UnitsPerDivision.ShadowColor = System.Drawing.Color.Transparent
        Me.cmb_UnitsPerDivision.Size = New System.Drawing.Size(88, 18)
        Me.cmb_UnitsPerDivision.TabIndex = 172
        Me.cmb_UnitsPerDivision.TabStop = False
        Me.cmb_UnitsPerDivision.TextPosition = 1
        '
        'btn_SetZero
        '
        Me.btn_SetZero.BorderColor = System.Drawing.Color.DimGray
        DesignerRectTracker3.IsActive = False
        DesignerRectTracker3.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker3.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btn_SetZero.CenterPtTracker = DesignerRectTracker3
        CBlendItems3.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))}
        CBlendItems3.iPoint = New Single() {0.0!, 0.5017921!, 1.0!}
        Me.btn_SetZero.ColorFillBlend = CBlendItems3
        CBlendItems4.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems4.iPoint = New Single() {0.0!, 0.3309608!, 1.0!}
        Me.btn_SetZero.ColorFillBlendChecked = CBlendItems4
        Me.btn_SetZero.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btn_SetZero.ColorFillSolidChecked = System.Drawing.SystemColors.Control
        Me.btn_SetZero.Corners.All = CType(6, Short)
        Me.btn_SetZero.Corners.LowerLeft = CType(6, Short)
        Me.btn_SetZero.Corners.LowerRight = CType(6, Short)
        Me.btn_SetZero.Corners.UpperLeft = CType(6, Short)
        Me.btn_SetZero.Corners.UpperRight = CType(6, Short)
        Me.btn_SetZero.DimFactorGray = -10
        Me.btn_SetZero.DimFactorOver = 30
        Me.btn_SetZero.FillType = Theremino_HAL.MyButton.eFillType.LinearVertical
        Me.btn_SetZero.FillTypeChecked = Theremino_HAL.MyButton.eFillType.LinearVertical
        Me.btn_SetZero.FocalPoints.CenterPtX = 0.3222222!
        Me.btn_SetZero.FocalPoints.CenterPtY = 0.4!
        Me.btn_SetZero.FocalPoints.FocusPtX = 0.0!
        Me.btn_SetZero.FocalPoints.FocusPtY = 0.0!
        Me.btn_SetZero.FocalPointsChecked.CenterPtX = 0.5!
        Me.btn_SetZero.FocalPointsChecked.CenterPtY = 0.5!
        Me.btn_SetZero.FocalPointsChecked.FocusPtX = 0.0!
        Me.btn_SetZero.FocalPointsChecked.FocusPtY = 0.0!
        DesignerRectTracker4.IsActive = False
        DesignerRectTracker4.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker4.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btn_SetZero.FocusPtTracker = DesignerRectTracker4
        Me.btn_SetZero.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_SetZero.Image = Nothing
        Me.btn_SetZero.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_SetZero.ImageIndex = 0
        Me.btn_SetZero.ImageSize = New System.Drawing.Size(16, 16)
        Me.btn_SetZero.Location = New System.Drawing.Point(283, 76)
        Me.btn_SetZero.Name = "btn_SetZero"
        Me.btn_SetZero.Shape = Theremino_HAL.MyButton.eShape.Rectangle
        Me.btn_SetZero.SideImage = Nothing
        Me.btn_SetZero.SideImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_SetZero.SideImageSize = New System.Drawing.Size(32, 32)
        Me.btn_SetZero.Size = New System.Drawing.Size(90, 36)
        Me.btn_SetZero.TabIndex = 169
        Me.btn_SetZero.Text = "Reset  zero"
        Me.btn_SetZero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_SetZero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_SetZero.TextMargin = New System.Windows.Forms.Padding(0)
        Me.btn_SetZero.TextShadow = System.Drawing.Color.Transparent
        '
        'btn_ShowRawCount
        '
        Me.btn_ShowRawCount.BorderColor = System.Drawing.Color.DimGray
        DesignerRectTracker5.IsActive = False
        DesignerRectTracker5.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker5.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btn_ShowRawCount.CenterPtTracker = DesignerRectTracker5
        Me.btn_ShowRawCount.CheckButton = True
        CBlendItems5.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))}
        CBlendItems5.iPoint = New Single() {0.0!, 0.5017921!, 1.0!}
        Me.btn_ShowRawCount.ColorFillBlend = CBlendItems5
        CBlendItems6.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems6.iPoint = New Single() {0.0!, 0.3309608!, 1.0!}
        Me.btn_ShowRawCount.ColorFillBlendChecked = CBlendItems6
        Me.btn_ShowRawCount.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btn_ShowRawCount.ColorFillSolidChecked = System.Drawing.SystemColors.Control
        Me.btn_ShowRawCount.Corners.All = CType(6, Short)
        Me.btn_ShowRawCount.Corners.LowerLeft = CType(6, Short)
        Me.btn_ShowRawCount.Corners.LowerRight = CType(6, Short)
        Me.btn_ShowRawCount.Corners.UpperLeft = CType(6, Short)
        Me.btn_ShowRawCount.Corners.UpperRight = CType(6, Short)
        Me.btn_ShowRawCount.DimFactorGray = -10
        Me.btn_ShowRawCount.DimFactorOver = 30
        Me.btn_ShowRawCount.FillType = Theremino_HAL.MyButton.eFillType.LinearVertical
        Me.btn_ShowRawCount.FillTypeChecked = Theremino_HAL.MyButton.eFillType.LinearVertical
        Me.btn_ShowRawCount.FocalPoints.CenterPtX = 0.2727273!
        Me.btn_ShowRawCount.FocalPoints.CenterPtY = 0.5!
        Me.btn_ShowRawCount.FocalPoints.FocusPtX = 0.0!
        Me.btn_ShowRawCount.FocalPoints.FocusPtY = 0.0!
        Me.btn_ShowRawCount.FocalPointsChecked.CenterPtX = 0.5!
        Me.btn_ShowRawCount.FocalPointsChecked.CenterPtY = 0.5!
        Me.btn_ShowRawCount.FocalPointsChecked.FocusPtX = 0.0!
        Me.btn_ShowRawCount.FocalPointsChecked.FocusPtY = 0.0!
        DesignerRectTracker6.IsActive = False
        DesignerRectTracker6.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker6.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btn_ShowRawCount.FocusPtTracker = DesignerRectTracker6
        Me.btn_ShowRawCount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ShowRawCount.Image = Nothing
        Me.btn_ShowRawCount.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_ShowRawCount.ImageIndex = 0
        Me.btn_ShowRawCount.ImageSize = New System.Drawing.Size(16, 16)
        Me.btn_ShowRawCount.Location = New System.Drawing.Point(283, 121)
        Me.btn_ShowRawCount.Name = "btn_ShowRawCount"
        Me.btn_ShowRawCount.Shape = Theremino_HAL.MyButton.eShape.Rectangle
        Me.btn_ShowRawCount.SideImage = Nothing
        Me.btn_ShowRawCount.SideImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_ShowRawCount.SideImageSize = New System.Drawing.Size(32, 32)
        Me.btn_ShowRawCount.Size = New System.Drawing.Size(90, 36)
        Me.btn_ShowRawCount.TabIndex = 155
        Me.btn_ShowRawCount.Text = "Show raw count"
        Me.btn_ShowRawCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_ShowRawCount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_ShowRawCount.TextMargin = New System.Windows.Forms.Padding(0)
        Me.btn_ShowRawCount.TextShadow = System.Drawing.Color.Transparent
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 421)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(800, 540)
        Me.MinimumSize = New System.Drawing.Size(528, 460)
        Me.Name = "Form2"
        Me.Opacity = 0
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Theremino HAL - Pin details"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.pbox_Details2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbox_Details1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.pbox_ScrollingScope, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Details1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_ShowRawCount As MyButton
    Friend WithEvents pbox_ScrollingScope As System.Windows.Forms.PictureBox
    Friend WithEvents pbox_Details1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer_60Hz As System.Windows.Forms.Timer
    Friend WithEvents Label_ScrollSpeed As System.Windows.Forms.Label
    Friend WithEvents LabelPin2 As System.Windows.Forms.Label
    Friend WithEvents pbox_Details2 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_Details2 As System.Windows.Forms.Label
    Friend WithEvents LabelPin1 As System.Windows.Forms.Label
    Friend WithEvents btn_SetZero As MyButton
    Friend WithEvents Label_VerticalScale As System.Windows.Forms.Label
    Friend WithEvents Label_Scale3 As System.Windows.Forms.Label
    Friend WithEvents Label_Scale2 As System.Windows.Forms.Label
    Friend WithEvents Label_Scale1 As System.Windows.Forms.Label
    Friend WithEvents Label_Scale3b As System.Windows.Forms.Label
    Friend WithEvents Label_Scale1b As System.Windows.Forms.Label
    Friend WithEvents Label_Scale2b As System.Windows.Forms.Label
    Friend WithEvents cmb_UnitsPerDivision As Theremino_HAL.MyComboBox
    Friend WithEvents btn_Run As Theremino_HAL.MyButton
    Friend WithEvents cmb_ScrollSpeed As Theremino_HAL.MyComboBox
    Friend WithEvents Label_ScaleMin As System.Windows.Forms.Label
    Friend WithEvents txt_ScaleMin As Theremino_HAL.MyTextBox
    Friend WithEvents Label_ScaleMax As System.Windows.Forms.Label
    Friend WithEvents txt_ScaleMax As Theremino_HAL.MyTextBox
End Class
