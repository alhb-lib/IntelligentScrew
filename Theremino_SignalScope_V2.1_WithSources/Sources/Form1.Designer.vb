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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.gbox_Channels = New System.Windows.Forms.GroupBox
        Me.chk_AC2 = New System.Windows.Forms.CheckBox
        Me.chk_AC1 = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbl_Center = New System.Windows.Forms.Label
        Me.lbl_Max = New System.Windows.Forms.Label
        Me.lbl_Min = New System.Windows.Forms.Label
        Me.cmb_Units2 = New System.Windows.Forms.ComboBox
        Me.lbl_Slot = New System.Windows.Forms.Label
        Me.cmb_Units1 = New System.Windows.Forms.ComboBox
        Me.lbl_Units = New System.Windows.Forms.Label
        Me.lbl_SlotName2 = New System.Windows.Forms.Label
        Me.lbl_SlotName1 = New System.Windows.Forms.Label
        Me.btn_SetZero = New System.Windows.Forms.Button
        Me.gbox_Scope = New System.Windows.Forms.GroupBox
        Me.Label_Scale2c = New System.Windows.Forms.Label
        Me.Label_Scale2b = New System.Windows.Forms.Label
        Me.Label_Scale2a = New System.Windows.Forms.Label
        Me.Label_Scale1a = New System.Windows.Forms.Label
        Me.Label_Scale1b = New System.Windows.Forms.Label
        Me.Label_Scale1c = New System.Windows.Forms.Label
        Me.pbox_Scope = New System.Windows.Forms.PictureBox
        Me.Timer_30Hz = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.lbl_Value1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbl_ValuePP1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbl_Value2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lbl_ValuePP2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.Timer_10Hz = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_LoadBuffer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_SaveBuffer = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_SaveImage = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_Run = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_Trigger = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.btn_Cursors = New System.Windows.Forms.ToolStripButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmb_BaseTime = New System.Windows.Forms.ComboBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.lbl_Then = New System.Windows.Forms.Label
        Me.cmb_StopAfterTimes = New System.Windows.Forms.ComboBox
        Me.cmb_StopIf = New System.Windows.Forms.ComboBox
        Me.gbox_SlotNames = New System.Windows.Forms.GroupBox
        Me.btn_EditSlotNames = New System.Windows.Forms.Button
        Me.btn_Interpolate = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.txt_StopTripPoint = New Theremino_SignalScope.MyTextBox
        Me.txt_Delta = New Theremino_SignalScope.MyTextBox
        Me.txt_Center2 = New Theremino_SignalScope.MyTextBox
        Me.txt_Center1 = New Theremino_SignalScope.MyTextBox
        Me.txt_Max2 = New Theremino_SignalScope.MyTextBox
        Me.txt_Max1 = New Theremino_SignalScope.MyTextBox
        Me.txt_Min2 = New Theremino_SignalScope.MyTextBox
        Me.txt_Min1 = New Theremino_SignalScope.MyTextBox
        Me.txt_Slot2 = New Theremino_SignalScope.MyTextBox
        Me.txt_Slot1 = New Theremino_SignalScope.MyTextBox
        Me.gbox_Channels.SuspendLayout()
        Me.gbox_Scope.SuspendLayout()
        CType(Me.pbox_Scope, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.gbox_SlotNames.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbox_Channels
        '
        Me.gbox_Channels.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbox_Channels.BackColor = System.Drawing.Color.Cornsilk
        Me.gbox_Channels.Controls.Add(Me.chk_AC2)
        Me.gbox_Channels.Controls.Add(Me.chk_AC1)
        Me.gbox_Channels.Controls.Add(Me.Label3)
        Me.gbox_Channels.Controls.Add(Me.lbl_Center)
        Me.gbox_Channels.Controls.Add(Me.txt_Center2)
        Me.gbox_Channels.Controls.Add(Me.txt_Center1)
        Me.gbox_Channels.Controls.Add(Me.lbl_Max)
        Me.gbox_Channels.Controls.Add(Me.txt_Max2)
        Me.gbox_Channels.Controls.Add(Me.txt_Max1)
        Me.gbox_Channels.Controls.Add(Me.lbl_Min)
        Me.gbox_Channels.Controls.Add(Me.txt_Min2)
        Me.gbox_Channels.Controls.Add(Me.txt_Min1)
        Me.gbox_Channels.Controls.Add(Me.cmb_Units2)
        Me.gbox_Channels.Controls.Add(Me.lbl_Slot)
        Me.gbox_Channels.Controls.Add(Me.txt_Slot2)
        Me.gbox_Channels.Controls.Add(Me.txt_Slot1)
        Me.gbox_Channels.Controls.Add(Me.cmb_Units1)
        Me.gbox_Channels.Controls.Add(Me.lbl_Units)
        Me.gbox_Channels.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbox_Channels.Location = New System.Drawing.Point(5, 253)
        Me.gbox_Channels.Name = "gbox_Channels"
        Me.gbox_Channels.Size = New System.Drawing.Size(378, 99)
        Me.gbox_Channels.TabIndex = 1
        Me.gbox_Channels.TabStop = False
        Me.gbox_Channels.Text = "Channels"
        '
        'chk_AC2
        '
        Me.chk_AC2.AutoSize = True
        Me.chk_AC2.Location = New System.Drawing.Point(354, 70)
        Me.chk_AC2.Name = "chk_AC2"
        Me.chk_AC2.Size = New System.Drawing.Size(15, 14)
        Me.chk_AC2.TabIndex = 12
        Me.chk_AC2.UseVisualStyleBackColor = True
        '
        'chk_AC1
        '
        Me.chk_AC1.AutoSize = True
        Me.chk_AC1.Location = New System.Drawing.Point(354, 40)
        Me.chk_AC1.Name = "chk_AC1"
        Me.chk_AC1.Size = New System.Drawing.Size(15, 14)
        Me.chk_AC1.TabIndex = 11
        Me.chk_AC1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(349, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 14)
        Me.Label3.TabIndex = 191
        Me.Label3.Text = "AC"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Center
        '
        Me.lbl_Center.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Center.Location = New System.Drawing.Point(200, 18)
        Me.lbl_Center.Name = "lbl_Center"
        Me.lbl_Center.Size = New System.Drawing.Size(64, 14)
        Me.lbl_Center.TabIndex = 190
        Me.lbl_Center.Text = "Center"
        Me.lbl_Center.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Max
        '
        Me.lbl_Max.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Max.Location = New System.Drawing.Point(130, 18)
        Me.lbl_Max.Name = "lbl_Max"
        Me.lbl_Max.Size = New System.Drawing.Size(64, 14)
        Me.lbl_Max.TabIndex = 187
        Me.lbl_Max.Text = "Max"
        Me.lbl_Max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_Min
        '
        Me.lbl_Min.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Min.Location = New System.Drawing.Point(59, 18)
        Me.lbl_Min.Name = "lbl_Min"
        Me.lbl_Min.Size = New System.Drawing.Size(64, 14)
        Me.lbl_Min.TabIndex = 184
        Me.lbl_Min.Text = "Min"
        Me.lbl_Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmb_Units2
        '
        Me.cmb_Units2.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.cmb_Units2.DropDownHeight = 500
        Me.cmb_Units2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Units2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmb_Units2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Units2.ForeColor = System.Drawing.Color.Maroon
        Me.cmb_Units2.IntegralHeight = False
        Me.cmb_Units2.ItemHeight = 15
        Me.cmb_Units2.Items.AddRange(New Object() {"Min-Max", "50000", "20000", "10000", "5000", "2000", "1000", "500", "200", "100", "50", "20", "10", "5", "2", "1", "0.5", "0.2", "0.1", "0.05", "0.02", "0.01", "0.005", "0.002", "0.001", "0.0005", "0.0002", "0.0001"})
        Me.cmb_Units2.Location = New System.Drawing.Point(269, 65)
        Me.cmb_Units2.Name = "cmb_Units2"
        Me.cmb_Units2.Size = New System.Drawing.Size(75, 23)
        Me.cmb_Units2.TabIndex = 10
        '
        'lbl_Slot
        '
        Me.lbl_Slot.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Slot.Location = New System.Drawing.Point(10, 18)
        Me.lbl_Slot.Name = "lbl_Slot"
        Me.lbl_Slot.Size = New System.Drawing.Size(42, 14)
        Me.lbl_Slot.TabIndex = 180
        Me.lbl_Slot.Text = "Slot"
        Me.lbl_Slot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmb_Units1
        '
        Me.cmb_Units1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.cmb_Units1.DropDownHeight = 500
        Me.cmb_Units1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Units1.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmb_Units1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Units1.ForeColor = System.Drawing.Color.Blue
        Me.cmb_Units1.IntegralHeight = False
        Me.cmb_Units1.ItemHeight = 15
        Me.cmb_Units1.Items.AddRange(New Object() {"Min-Max", "50000", "20000", "10000", "5000", "2000", "1000", "500", "200", "100", "50", "20", "10", "5", "2", "1", "0.5", "0.2", "0.1", "0.05", "0.02", "0.01", "0.005", "0.002", "0.001", "0.0005", "0.0002", "0.0001"})
        Me.cmb_Units1.Location = New System.Drawing.Point(269, 35)
        Me.cmb_Units1.Name = "cmb_Units1"
        Me.cmb_Units1.Size = New System.Drawing.Size(75, 23)
        Me.cmb_Units1.TabIndex = 9
        '
        'lbl_Units
        '
        Me.lbl_Units.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Units.Location = New System.Drawing.Point(269, 18)
        Me.lbl_Units.Name = "lbl_Units"
        Me.lbl_Units.Size = New System.Drawing.Size(75, 14)
        Me.lbl_Units.TabIndex = 171
        Me.lbl_Units.Text = "Units / div."
        Me.lbl_Units.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_SlotName2
        '
        Me.lbl_SlotName2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_SlotName2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_SlotName2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_SlotName2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SlotName2.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_SlotName2.Location = New System.Drawing.Point(6, 66)
        Me.lbl_SlotName2.Name = "lbl_SlotName2"
        Me.lbl_SlotName2.Size = New System.Drawing.Size(127, 18)
        Me.lbl_SlotName2.TabIndex = 15
        Me.lbl_SlotName2.Text = "Slot name 2"
        Me.lbl_SlotName2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_SlotName1
        '
        Me.lbl_SlotName1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl_SlotName1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_SlotName1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_SlotName1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_SlotName1.ForeColor = System.Drawing.Color.Blue
        Me.lbl_SlotName1.Location = New System.Drawing.Point(6, 35)
        Me.lbl_SlotName1.Name = "lbl_SlotName1"
        Me.lbl_SlotName1.Size = New System.Drawing.Size(127, 18)
        Me.lbl_SlotName1.TabIndex = 14
        Me.lbl_SlotName1.Text = "Slot name 1"
        Me.lbl_SlotName1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_SetZero
        '
        Me.btn_SetZero.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_SetZero.BackColor = System.Drawing.Color.Transparent
        Me.btn_SetZero.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_SetZero.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btn_SetZero.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.btn_SetZero.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_SetZero.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_SetZero.ForeColor = System.Drawing.Color.Black
        Me.btn_SetZero.ImageIndex = 0
        Me.btn_SetZero.Location = New System.Drawing.Point(667, 135)
        Me.btn_SetZero.Name = "btn_SetZero"
        Me.btn_SetZero.Size = New System.Drawing.Size(67, 24)
        Me.btn_SetZero.TabIndex = 21
        Me.btn_SetZero.Text = "Set center"
        Me.btn_SetZero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_SetZero.UseVisualStyleBackColor = False
        '
        'gbox_Scope
        '
        Me.gbox_Scope.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbox_Scope.BackColor = System.Drawing.Color.Cornsilk
        Me.gbox_Scope.Controls.Add(Me.Label_Scale2c)
        Me.gbox_Scope.Controls.Add(Me.Label_Scale2b)
        Me.gbox_Scope.Controls.Add(Me.Label_Scale2a)
        Me.gbox_Scope.Controls.Add(Me.Label_Scale1a)
        Me.gbox_Scope.Controls.Add(Me.Label_Scale1b)
        Me.gbox_Scope.Controls.Add(Me.Label_Scale1c)
        Me.gbox_Scope.Controls.Add(Me.pbox_Scope)
        Me.gbox_Scope.Controls.Add(Me.btn_SetZero)
        Me.gbox_Scope.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbox_Scope.Location = New System.Drawing.Point(4, 28)
        Me.gbox_Scope.Name = "gbox_Scope"
        Me.gbox_Scope.Size = New System.Drawing.Size(744, 222)
        Me.gbox_Scope.TabIndex = 146
        Me.gbox_Scope.TabStop = False
        '
        'Label_Scale2c
        '
        Me.Label_Scale2c.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_Scale2c.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scale2c.ForeColor = System.Drawing.Color.Maroon
        Me.Label_Scale2c.Location = New System.Drawing.Point(661, 202)
        Me.Label_Scale2c.Name = "Label_Scale2c"
        Me.Label_Scale2c.Size = New System.Drawing.Size(65, 13)
        Me.Label_Scale2c.TabIndex = 177
        Me.Label_Scale2c.Text = "0"
        Me.Label_Scale2c.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Scale2b
        '
        Me.Label_Scale2b.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label_Scale2b.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scale2b.ForeColor = System.Drawing.Color.Maroon
        Me.Label_Scale2b.Location = New System.Drawing.Point(661, 115)
        Me.Label_Scale2b.Name = "Label_Scale2b"
        Me.Label_Scale2b.Size = New System.Drawing.Size(65, 13)
        Me.Label_Scale2b.TabIndex = 176
        Me.Label_Scale2b.Text = "500"
        Me.Label_Scale2b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Scale2a
        '
        Me.Label_Scale2a.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_Scale2a.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scale2a.ForeColor = System.Drawing.Color.Maroon
        Me.Label_Scale2a.Location = New System.Drawing.Point(661, 25)
        Me.Label_Scale2a.Name = "Label_Scale2a"
        Me.Label_Scale2a.Size = New System.Drawing.Size(65, 13)
        Me.Label_Scale2a.TabIndex = 175
        Me.Label_Scale2a.Text = "1000"
        Me.Label_Scale2a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Scale1a
        '
        Me.Label_Scale1a.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_Scale1a.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scale1a.ForeColor = System.Drawing.Color.Blue
        Me.Label_Scale1a.Location = New System.Drawing.Point(661, 12)
        Me.Label_Scale1a.Name = "Label_Scale1a"
        Me.Label_Scale1a.Size = New System.Drawing.Size(65, 13)
        Me.Label_Scale1a.TabIndex = 174
        Me.Label_Scale1a.Text = "1000"
        Me.Label_Scale1a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Scale1b
        '
        Me.Label_Scale1b.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label_Scale1b.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scale1b.ForeColor = System.Drawing.Color.Blue
        Me.Label_Scale1b.Location = New System.Drawing.Point(661, 102)
        Me.Label_Scale1b.Name = "Label_Scale1b"
        Me.Label_Scale1b.Size = New System.Drawing.Size(65, 13)
        Me.Label_Scale1b.TabIndex = 173
        Me.Label_Scale1b.Text = "500"
        Me.Label_Scale1b.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label_Scale1c
        '
        Me.Label_Scale1c.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label_Scale1c.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Scale1c.ForeColor = System.Drawing.Color.Blue
        Me.Label_Scale1c.Location = New System.Drawing.Point(661, 189)
        Me.Label_Scale1c.Name = "Label_Scale1c"
        Me.Label_Scale1c.Size = New System.Drawing.Size(65, 13)
        Me.Label_Scale1c.TabIndex = 172
        Me.Label_Scale1c.Text = "0"
        Me.Label_Scale1c.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbox_Scope
        '
        Me.pbox_Scope.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbox_Scope.BackColor = System.Drawing.Color.AliceBlue
        Me.pbox_Scope.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbox_Scope.Location = New System.Drawing.Point(10, 16)
        Me.pbox_Scope.Name = "pbox_Scope"
        Me.pbox_Scope.Size = New System.Drawing.Size(651, 197)
        Me.pbox_Scope.TabIndex = 153
        Me.pbox_Scope.TabStop = False
        '
        'Timer_30Hz
        '
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbl_Value1, Me.lbl_ValuePP1, Me.lbl_Value2, Me.lbl_ValuePP2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 358)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(754, 23)
        Me.StatusStrip1.TabIndex = 147
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbl_Value1
        '
        Me.lbl_Value1.AutoSize = False
        Me.lbl_Value1.BackColor = System.Drawing.Color.White
        Me.lbl_Value1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lbl_Value1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Value1.ForeColor = System.Drawing.Color.Blue
        Me.lbl_Value1.Margin = New System.Windows.Forms.Padding(5, 3, 0, 2)
        Me.lbl_Value1.Name = "lbl_Value1"
        Me.lbl_Value1.Size = New System.Drawing.Size(118, 18)
        Me.lbl_Value1.Text = "-"
        Me.lbl_Value1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_ValuePP1
        '
        Me.lbl_ValuePP1.AutoSize = False
        Me.lbl_ValuePP1.BackColor = System.Drawing.Color.White
        Me.lbl_ValuePP1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lbl_ValuePP1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ValuePP1.ForeColor = System.Drawing.Color.Blue
        Me.lbl_ValuePP1.Margin = New System.Windows.Forms.Padding(5, 3, 0, 2)
        Me.lbl_ValuePP1.Name = "lbl_ValuePP1"
        Me.lbl_ValuePP1.Size = New System.Drawing.Size(162, 18)
        Me.lbl_ValuePP1.Text = "-"
        Me.lbl_ValuePP1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_Value2
        '
        Me.lbl_Value2.AutoSize = False
        Me.lbl_Value2.BackColor = System.Drawing.Color.White
        Me.lbl_Value2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lbl_Value2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Value2.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_Value2.Margin = New System.Windows.Forms.Padding(5, 3, 0, 2)
        Me.lbl_Value2.Name = "lbl_Value2"
        Me.lbl_Value2.Size = New System.Drawing.Size(118, 18)
        Me.lbl_Value2.Text = "-"
        Me.lbl_Value2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_ValuePP2
        '
        Me.lbl_ValuePP2.AutoSize = False
        Me.lbl_ValuePP2.BackColor = System.Drawing.Color.White
        Me.lbl_ValuePP2.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
                    Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.lbl_ValuePP2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ValuePP2.ForeColor = System.Drawing.Color.Maroon
        Me.lbl_ValuePP2.Margin = New System.Windows.Forms.Padding(5, 3, 0, 2)
        Me.lbl_ValuePP2.Name = "lbl_ValuePP2"
        Me.lbl_ValuePP2.Size = New System.Drawing.Size(162, 18)
        Me.lbl_ValuePP2.Text = "-"
        Me.lbl_ValuePP2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer_10Hz
        '
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.btn_LoadBuffer, Me.ToolStripSeparator11, Me.btn_SaveBuffer, Me.ToolStripSeparator3, Me.btn_SaveImage, Me.ToolStripSeparator8, Me.ToolStripSeparator5, Me.btn_Run, Me.ToolStripSeparator1, Me.btn_Trigger, Me.ToolStripSeparator2, Me.btn_Cursors, Me.ToolStripSeparator6, Me.btn_Interpolate})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(754, 30)
        Me.ToolStrip1.TabIndex = 220
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.AutoSize = False
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 28)
        '
        'btn_LoadBuffer
        '
        Me.btn_LoadBuffer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_LoadBuffer.Image = CType(resources.GetObject("btn_LoadBuffer.Image"), System.Drawing.Image)
        Me.btn_LoadBuffer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_LoadBuffer.Name = "btn_LoadBuffer"
        Me.btn_LoadBuffer.Size = New System.Drawing.Size(91, 27)
        Me.btn_LoadBuffer.Text = "Load buffer"
        Me.btn_LoadBuffer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_LoadBuffer.ToolTipText = "Load the data buffer from file"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.AutoSize = False
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 28)
        '
        'btn_SaveBuffer
        '
        Me.btn_SaveBuffer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_SaveBuffer.Image = CType(resources.GetObject("btn_SaveBuffer.Image"), System.Drawing.Image)
        Me.btn_SaveBuffer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_SaveBuffer.Name = "btn_SaveBuffer"
        Me.btn_SaveBuffer.Size = New System.Drawing.Size(91, 27)
        Me.btn_SaveBuffer.Text = "Save buffer"
        Me.btn_SaveBuffer.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_SaveBuffer.ToolTipText = "Save the data buffer to file"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.AutoSize = False
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 28)
        '
        'btn_SaveImage
        '
        Me.btn_SaveImage.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_SaveImage.Image = CType(resources.GetObject("btn_SaveImage.Image"), System.Drawing.Image)
        Me.btn_SaveImage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_SaveImage.Name = "btn_SaveImage"
        Me.btn_SaveImage.Size = New System.Drawing.Size(95, 27)
        Me.btn_SaveImage.Text = "Save image"
        Me.btn_SaveImage.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_SaveImage.ToolTipText = "Save this window as image"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.AutoSize = False
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 28)
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 30)
        '
        'btn_Run
        '
        Me.btn_Run.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_Run.AutoSize = False
        Me.btn_Run.CheckOnClick = True
        Me.btn_Run.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Run.Image = CType(resources.GetObject("btn_Run.Image"), System.Drawing.Image)
        Me.btn_Run.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Run.Name = "btn_Run"
        Me.btn_Run.Size = New System.Drawing.Size(85, 27)
        Me.btn_Run.Text = " R U N"
        Me.btn_Run.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_Run.ToolTipText = "Sampling Run or Stop"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator1.AutoSize = False
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 28)
        '
        'btn_Trigger
        '
        Me.btn_Trigger.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_Trigger.AutoSize = False
        Me.btn_Trigger.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Trigger.Image = CType(resources.GetObject("btn_Trigger.Image"), System.Drawing.Image)
        Me.btn_Trigger.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Trigger.Name = "btn_Trigger"
        Me.btn_Trigger.Size = New System.Drawing.Size(100, 27)
        Me.btn_Trigger.Text = "Trigger OFF"
        Me.btn_Trigger.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_Trigger.ToolTipText = "Trigger for repetitive waves"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator2.AutoSize = False
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 28)
        '
        'btn_Cursors
        '
        Me.btn_Cursors.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_Cursors.AutoSize = False
        Me.btn_Cursors.CheckOnClick = True
        Me.btn_Cursors.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Cursors.Image = CType(resources.GetObject("btn_Cursors.Image"), System.Drawing.Image)
        Me.btn_Cursors.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Cursors.Name = "btn_Cursors"
        Me.btn_Cursors.Size = New System.Drawing.Size(80, 27)
        Me.btn_Cursors.Text = "Cursors"
        Me.btn_Cursors.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_Cursors.ToolTipText = "Enable measuring cursors"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Cornsilk
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txt_Delta)
        Me.GroupBox2.Controls.Add(Me.cmb_BaseTime)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(534, 253)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(105, 99)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Time base"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 14)
        Me.Label1.TabIndex = 190
        Me.Label1.Text = "delta (ms)"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmb_BaseTime
        '
        Me.cmb_BaseTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.cmb_BaseTime.DropDownHeight = 500
        Me.cmb_BaseTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_BaseTime.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmb_BaseTime.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_BaseTime.ForeColor = System.Drawing.Color.Black
        Me.cmb_BaseTime.IntegralHeight = False
        Me.cmb_BaseTime.ItemHeight = 15
        Me.cmb_BaseTime.Items.AddRange(New Object() {"2 Min/div ", "1 Min/div ", "30 Sec/div ", "10 Sec/div ", "5 Sec/div ", "2 Sec/div", "1 Sec/div ", "0.5 Sec/div ", "0.2 Sec/div ", "0.1 Sec/div", "50 mS/div", "20 mS/div", "10 mS/div"})
        Me.cmb_BaseTime.Location = New System.Drawing.Point(9, 21)
        Me.cmb_BaseTime.Name = "cmb_BaseTime"
        Me.cmb_BaseTime.Size = New System.Drawing.Size(87, 23)
        Me.cmb_BaseTime.TabIndex = 16
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.Color.Cornsilk
        Me.GroupBox4.Controls.Add(Me.lbl_Then)
        Me.GroupBox4.Controls.Add(Me.txt_StopTripPoint)
        Me.GroupBox4.Controls.Add(Me.cmb_StopAfterTimes)
        Me.GroupBox4.Controls.Add(Me.cmb_StopIf)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(645, 253)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(101, 99)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Stop if"
        '
        'lbl_Then
        '
        Me.lbl_Then.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Then.Location = New System.Drawing.Point(8, 47)
        Me.lbl_Then.Name = "lbl_Then"
        Me.lbl_Then.Size = New System.Drawing.Size(31, 14)
        Me.lbl_Then.TabIndex = 191
        Me.lbl_Then.Text = "then"
        Me.lbl_Then.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmb_StopAfterTimes
        '
        Me.cmb_StopAfterTimes.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.cmb_StopAfterTimes.DropDownHeight = 500
        Me.cmb_StopAfterTimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_StopAfterTimes.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmb_StopAfterTimes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_StopAfterTimes.ForeColor = System.Drawing.Color.Black
        Me.cmb_StopAfterTimes.IntegralHeight = False
        Me.cmb_StopAfterTimes.ItemHeight = 15
        Me.cmb_StopAfterTimes.Items.AddRange(New Object() {"First event", "2 times", "5 times", "10 times", "20 times", "50 times", "100 times", "200 times", "500 times"})
        Me.cmb_StopAfterTimes.Location = New System.Drawing.Point(13, 66)
        Me.cmb_StopAfterTimes.Name = "cmb_StopAfterTimes"
        Me.cmb_StopAfterTimes.Size = New System.Drawing.Size(80, 23)
        Me.cmb_StopAfterTimes.TabIndex = 20
        '
        'cmb_StopIf
        '
        Me.cmb_StopIf.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.cmb_StopIf.DropDownHeight = 500
        Me.cmb_StopIf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_StopIf.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmb_StopIf.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_StopIf.ForeColor = System.Drawing.Color.Black
        Me.cmb_StopIf.IntegralHeight = False
        Me.cmb_StopIf.ItemHeight = 15
        Me.cmb_StopIf.Items.AddRange(New Object() {"Disabled", "Ch1 more", "Ch1 less", "Ch2 more", "Ch2 less"})
        Me.cmb_StopIf.Location = New System.Drawing.Point(13, 19)
        Me.cmb_StopIf.Name = "cmb_StopIf"
        Me.cmb_StopIf.Size = New System.Drawing.Size(80, 23)
        Me.cmb_StopIf.TabIndex = 18
        '
        'gbox_SlotNames
        '
        Me.gbox_SlotNames.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbox_SlotNames.BackColor = System.Drawing.Color.Cornsilk
        Me.gbox_SlotNames.Controls.Add(Me.btn_EditSlotNames)
        Me.gbox_SlotNames.Controls.Add(Me.lbl_SlotName2)
        Me.gbox_SlotNames.Controls.Add(Me.lbl_SlotName1)
        Me.gbox_SlotNames.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbox_SlotNames.Location = New System.Drawing.Point(389, 254)
        Me.gbox_SlotNames.MaximumSize = New System.Drawing.Size(250, 99)
        Me.gbox_SlotNames.Name = "gbox_SlotNames"
        Me.gbox_SlotNames.Size = New System.Drawing.Size(139, 99)
        Me.gbox_SlotNames.TabIndex = 2
        Me.gbox_SlotNames.TabStop = False
        Me.gbox_SlotNames.Text = "Slot names"
        '
        'btn_EditSlotNames
        '
        Me.btn_EditSlotNames.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_EditSlotNames.BackColor = System.Drawing.Color.Transparent
        Me.btn_EditSlotNames.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.btn_EditSlotNames.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro
        Me.btn_EditSlotNames.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btn_EditSlotNames.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_EditSlotNames.ForeColor = System.Drawing.Color.Black
        Me.btn_EditSlotNames.ImageIndex = 0
        Me.btn_EditSlotNames.Location = New System.Drawing.Point(89, 8)
        Me.btn_EditSlotNames.Name = "btn_EditSlotNames"
        Me.btn_EditSlotNames.Size = New System.Drawing.Size(45, 19)
        Me.btn_EditSlotNames.TabIndex = 13
        Me.btn_EditSlotNames.Text = "Edit"
        Me.btn_EditSlotNames.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_EditSlotNames.UseVisualStyleBackColor = False
        '
        'btn_Interpolate
        '
        Me.btn_Interpolate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btn_Interpolate.AutoSize = False
        Me.btn_Interpolate.CheckOnClick = True
        Me.btn_Interpolate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Interpolate.Image = CType(resources.GetObject("btn_Interpolate.Image"), System.Drawing.Image)
        Me.btn_Interpolate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Interpolate.Name = "btn_Interpolate"
        Me.btn_Interpolate.Size = New System.Drawing.Size(88, 27)
        Me.btn_Interpolate.Text = "Interpolate"
        Me.btn_Interpolate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.btn_Interpolate.ToolTipText = "Interpolate adiacent samples"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator6.AutoSize = False
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 28)
        '
        'txt_StopTripPoint
        '
        Me.txt_StopTripPoint.ArrowsIncrement = 1
        Me.txt_StopTripPoint.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txt_StopTripPoint.BackColor_Over = System.Drawing.SystemColors.Window
        Me.txt_StopTripPoint.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_StopTripPoint.ForeColor = System.Drawing.Color.Black
        Me.txt_StopTripPoint.Increment = 1
        Me.txt_StopTripPoint.Location = New System.Drawing.Point(40, 43)
        Me.txt_StopTripPoint.MaxLength = 7
        Me.txt_StopTripPoint.MaxValue = 9999999
        Me.txt_StopTripPoint.MinValue = -9999999
        Me.txt_StopTripPoint.Name = "txt_StopTripPoint"
        Me.txt_StopTripPoint.NumericValue = 500
        Me.txt_StopTripPoint.NumericValueInteger = 500
        Me.txt_StopTripPoint.RectangleColor = System.Drawing.Color.Transparent
        Me.txt_StopTripPoint.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.None
        Me.txt_StopTripPoint.RoundingStep = 0
        Me.txt_StopTripPoint.ShadowColor = System.Drawing.Color.Transparent
        Me.txt_StopTripPoint.Size = New System.Drawing.Size(53, 22)
        Me.txt_StopTripPoint.TabIndex = 19
        Me.txt_StopTripPoint.Text = "500"
        Me.txt_StopTripPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_Delta
        '
        Me.txt_Delta.ArrowsIncrement = 1
        Me.txt_Delta.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txt_Delta.BackColor_Over = System.Drawing.SystemColors.Window
        Me.txt_Delta.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Delta.ForeColor = System.Drawing.Color.Black
        Me.txt_Delta.Increment = 1
        Me.txt_Delta.Location = New System.Drawing.Point(9, 66)
        Me.txt_Delta.MaxLength = 8
        Me.txt_Delta.MaxValue = 99999999
        Me.txt_Delta.MinValue = 0
        Me.txt_Delta.Name = "txt_Delta"
        Me.txt_Delta.NumericValue = 0
        Me.txt_Delta.RectangleColor = System.Drawing.Color.Transparent
        Me.txt_Delta.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.None
        Me.txt_Delta.RoundingStep = 0
        Me.txt_Delta.ShadowColor = System.Drawing.Color.Transparent
        Me.txt_Delta.Size = New System.Drawing.Size(87, 22)
        Me.txt_Delta.TabIndex = 17
        Me.txt_Delta.Text = "0"
        Me.txt_Delta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_Center2
        '
        Me.txt_Center2.ArrowsIncrement = 1
        Me.txt_Center2.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txt_Center2.BackColor_Over = System.Drawing.SystemColors.Window
        Me.txt_Center2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Center2.ForeColor = System.Drawing.Color.Maroon
        Me.txt_Center2.Increment = 0.4
        Me.txt_Center2.Location = New System.Drawing.Point(200, 66)
        Me.txt_Center2.MaxLength = 7
        Me.txt_Center2.MaxValue = 999999
        Me.txt_Center2.MinValue = -999999
        Me.txt_Center2.Name = "txt_Center2"
        Me.txt_Center2.NumericValue = 500
        Me.txt_Center2.NumericValueInteger = 500
        Me.txt_Center2.RectangleColor = System.Drawing.Color.Transparent
        Me.txt_Center2.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.None
        Me.txt_Center2.RoundingStep = 0
        Me.txt_Center2.ShadowColor = System.Drawing.Color.Transparent
        Me.txt_Center2.Size = New System.Drawing.Size(64, 22)
        Me.txt_Center2.TabIndex = 8
        Me.txt_Center2.Text = "500"
        Me.txt_Center2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_Center1
        '
        Me.txt_Center1.ArrowsIncrement = 1
        Me.txt_Center1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txt_Center1.BackColor_Over = System.Drawing.SystemColors.Window
        Me.txt_Center1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Center1.ForeColor = System.Drawing.Color.Blue
        Me.txt_Center1.Increment = 0.4
        Me.txt_Center1.Location = New System.Drawing.Point(200, 36)
        Me.txt_Center1.MaxLength = 7
        Me.txt_Center1.MaxValue = 999999
        Me.txt_Center1.MinValue = -999999
        Me.txt_Center1.Name = "txt_Center1"
        Me.txt_Center1.NumericValue = 500
        Me.txt_Center1.NumericValueInteger = 500
        Me.txt_Center1.RectangleColor = System.Drawing.Color.Transparent
        Me.txt_Center1.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.None
        Me.txt_Center1.RoundingStep = 0
        Me.txt_Center1.ShadowColor = System.Drawing.Color.Transparent
        Me.txt_Center1.Size = New System.Drawing.Size(64, 22)
        Me.txt_Center1.TabIndex = 7
        Me.txt_Center1.Text = "500"
        Me.txt_Center1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_Max2
        '
        Me.txt_Max2.ArrowsIncrement = 1
        Me.txt_Max2.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txt_Max2.BackColor_Over = System.Drawing.SystemColors.Window
        Me.txt_Max2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Max2.ForeColor = System.Drawing.Color.Maroon
        Me.txt_Max2.Increment = 0.4
        Me.txt_Max2.Location = New System.Drawing.Point(130, 66)
        Me.txt_Max2.MaxLength = 7
        Me.txt_Max2.MaxValue = 999999
        Me.txt_Max2.MinValue = -999999
        Me.txt_Max2.Name = "txt_Max2"
        Me.txt_Max2.NumericValue = 1000
        Me.txt_Max2.NumericValueInteger = 1000
        Me.txt_Max2.RectangleColor = System.Drawing.Color.Transparent
        Me.txt_Max2.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.None
        Me.txt_Max2.RoundingStep = 0
        Me.txt_Max2.ShadowColor = System.Drawing.Color.Transparent
        Me.txt_Max2.Size = New System.Drawing.Size(64, 22)
        Me.txt_Max2.TabIndex = 6
        Me.txt_Max2.Text = "1000"
        Me.txt_Max2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_Max1
        '
        Me.txt_Max1.ArrowsIncrement = 1
        Me.txt_Max1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txt_Max1.BackColor_Over = System.Drawing.SystemColors.Window
        Me.txt_Max1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Max1.ForeColor = System.Drawing.Color.Blue
        Me.txt_Max1.Increment = 0.4
        Me.txt_Max1.Location = New System.Drawing.Point(130, 36)
        Me.txt_Max1.MaxLength = 7
        Me.txt_Max1.MaxValue = 999999
        Me.txt_Max1.MinValue = -999999
        Me.txt_Max1.Name = "txt_Max1"
        Me.txt_Max1.NumericValue = 1000
        Me.txt_Max1.NumericValueInteger = 1000
        Me.txt_Max1.RectangleColor = System.Drawing.Color.Transparent
        Me.txt_Max1.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.None
        Me.txt_Max1.RoundingStep = 0
        Me.txt_Max1.ShadowColor = System.Drawing.Color.Transparent
        Me.txt_Max1.Size = New System.Drawing.Size(64, 22)
        Me.txt_Max1.TabIndex = 5
        Me.txt_Max1.Text = "1000"
        Me.txt_Max1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_Min2
        '
        Me.txt_Min2.ArrowsIncrement = 1
        Me.txt_Min2.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txt_Min2.BackColor_Over = System.Drawing.SystemColors.Window
        Me.txt_Min2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Min2.ForeColor = System.Drawing.Color.Maroon
        Me.txt_Min2.Increment = 0.4
        Me.txt_Min2.Location = New System.Drawing.Point(59, 66)
        Me.txt_Min2.MaxLength = 7
        Me.txt_Min2.MaxValue = 999999
        Me.txt_Min2.MinValue = -999999
        Me.txt_Min2.Name = "txt_Min2"
        Me.txt_Min2.NumericValue = 0
        Me.txt_Min2.RectangleColor = System.Drawing.Color.Transparent
        Me.txt_Min2.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.None
        Me.txt_Min2.RoundingStep = 0
        Me.txt_Min2.ShadowColor = System.Drawing.Color.Transparent
        Me.txt_Min2.Size = New System.Drawing.Size(64, 22)
        Me.txt_Min2.TabIndex = 4
        Me.txt_Min2.Text = "0"
        Me.txt_Min2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_Min1
        '
        Me.txt_Min1.ArrowsIncrement = 1
        Me.txt_Min1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txt_Min1.BackColor_Over = System.Drawing.SystemColors.Window
        Me.txt_Min1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Min1.ForeColor = System.Drawing.Color.Blue
        Me.txt_Min1.Increment = 0.4
        Me.txt_Min1.Location = New System.Drawing.Point(59, 36)
        Me.txt_Min1.MaxLength = 7
        Me.txt_Min1.MaxValue = 999999
        Me.txt_Min1.MinValue = -999999
        Me.txt_Min1.Name = "txt_Min1"
        Me.txt_Min1.NumericValue = 0
        Me.txt_Min1.RectangleColor = System.Drawing.Color.Transparent
        Me.txt_Min1.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.None
        Me.txt_Min1.RoundingStep = 0
        Me.txt_Min1.ShadowColor = System.Drawing.Color.Transparent
        Me.txt_Min1.Size = New System.Drawing.Size(64, 22)
        Me.txt_Min1.TabIndex = 3
        Me.txt_Min1.Text = "0"
        Me.txt_Min1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_Slot2
        '
        Me.txt_Slot2.ArrowsIncrement = 1
        Me.txt_Slot2.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txt_Slot2.BackColor_Over = System.Drawing.SystemColors.Window
        Me.txt_Slot2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Slot2.ForeColor = System.Drawing.Color.Maroon
        Me.txt_Slot2.Increment = 0.2
        Me.txt_Slot2.Location = New System.Drawing.Point(10, 66)
        Me.txt_Slot2.MaxLength = 3
        Me.txt_Slot2.MaxValue = 999
        Me.txt_Slot2.MinValue = -1
        Me.txt_Slot2.Name = "txt_Slot2"
        Me.txt_Slot2.NumericValue = 0
        Me.txt_Slot2.RectangleColor = System.Drawing.Color.Transparent
        Me.txt_Slot2.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.None
        Me.txt_Slot2.RoundingStep = 0
        Me.txt_Slot2.ShadowColor = System.Drawing.Color.Transparent
        Me.txt_Slot2.Size = New System.Drawing.Size(42, 22)
        Me.txt_Slot2.TabIndex = 2
        Me.txt_Slot2.Text = "0"
        Me.txt_Slot2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_Slot1
        '
        Me.txt_Slot1.ArrowsIncrement = 1
        Me.txt_Slot1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.txt_Slot1.BackColor_Over = System.Drawing.SystemColors.Window
        Me.txt_Slot1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Slot1.ForeColor = System.Drawing.Color.Blue
        Me.txt_Slot1.Increment = 0.2
        Me.txt_Slot1.Location = New System.Drawing.Point(10, 36)
        Me.txt_Slot1.MaxLength = 3
        Me.txt_Slot1.MaxValue = 999
        Me.txt_Slot1.MinValue = -1
        Me.txt_Slot1.Name = "txt_Slot1"
        Me.txt_Slot1.NumericValue = 0
        Me.txt_Slot1.RectangleColor = System.Drawing.Color.Transparent
        Me.txt_Slot1.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.None
        Me.txt_Slot1.RoundingStep = 0
        Me.txt_Slot1.ShadowColor = System.Drawing.Color.Transparent
        Me.txt_Slot1.Size = New System.Drawing.Size(42, 22)
        Me.txt_Slot1.TabIndex = 1
        Me.txt_Slot1.Text = "0"
        Me.txt_Slot1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(754, 381)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gbox_Scope)
        Me.Controls.Add(Me.gbox_Channels)
        Me.Controls.Add(Me.gbox_SlotNames)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(625, 420)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Theremino SignalScope"
        Me.gbox_Channels.ResumeLayout(False)
        Me.gbox_Channels.PerformLayout()
        Me.gbox_Scope.ResumeLayout(False)
        CType(Me.pbox_Scope, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.gbox_SlotNames.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbox_Channels As System.Windows.Forms.GroupBox
    Friend WithEvents gbox_Scope As System.Windows.Forms.GroupBox
    Friend WithEvents pbox_Scope As System.Windows.Forms.PictureBox
    Friend WithEvents Timer_30Hz As System.Windows.Forms.Timer
    Friend WithEvents btn_SetZero As Button
    Friend WithEvents lbl_Units As System.Windows.Forms.Label
    Friend WithEvents Label_Scale1a As System.Windows.Forms.Label
    Friend WithEvents Label_Scale1b As System.Windows.Forms.Label
    Friend WithEvents Label_Scale1c As System.Windows.Forms.Label
    Friend WithEvents Label_Scale2a As System.Windows.Forms.Label
    Friend WithEvents Label_Scale2c As System.Windows.Forms.Label
    Friend WithEvents Label_Scale2b As System.Windows.Forms.Label
    Friend WithEvents txt_Slot2 As MyTextBox
    Friend WithEvents txt_Slot1 As MyTextBox
    Friend WithEvents lbl_Slot As System.Windows.Forms.Label
    Friend WithEvents lbl_Max As System.Windows.Forms.Label
    Friend WithEvents txt_Max2 As MyTextBox
    Friend WithEvents txt_Max1 As MyTextBox
    Friend WithEvents lbl_Min As System.Windows.Forms.Label
    Friend WithEvents txt_Min2 As MyTextBox
    Friend WithEvents txt_Min1 As MyTextBox
    Friend WithEvents cmb_Units2 As ComboBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents lbl_Value1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbl_Value2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbl_ValuePP1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbl_ValuePP2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer_10Hz As System.Windows.Forms.Timer
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btn_LoadBuffer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_SaveBuffer As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_Run As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_SaveImage As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_Trigger As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_StopIf As ComboBox
    Friend WithEvents lbl_Center As System.Windows.Forms.Label
    Friend WithEvents txt_Center2 As MyTextBox
    Friend WithEvents txt_Center1 As MyTextBox
    Friend WithEvents txt_StopTripPoint As MyTextBox
    Friend WithEvents cmb_StopAfterTimes As ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_Delta As MyTextBox
    Friend WithEvents cmb_Units1 As ComboBox
    Friend WithEvents cmb_BaseTime As ComboBox
    Friend WithEvents lbl_Then As System.Windows.Forms.Label
    Friend WithEvents lbl_SlotName2 As System.Windows.Forms.Label
    Friend WithEvents lbl_SlotName1 As System.Windows.Forms.Label
    Friend WithEvents gbox_SlotNames As System.Windows.Forms.GroupBox
    Friend WithEvents btn_EditSlotNames As System.Windows.Forms.Button
    Friend WithEvents chk_AC2 As System.Windows.Forms.CheckBox
    Friend WithEvents chk_AC1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btn_Cursors As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_Interpolate As System.Windows.Forms.ToolStripButton
End Class
