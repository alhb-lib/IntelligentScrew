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
        Dim DesignerRectTracker1 As Theremino_HAL.DesignerRectTracker = New Theremino_HAL.DesignerRectTracker
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
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
        Dim DesignerRectTracker7 As Theremino_HAL.DesignerRectTracker = New Theremino_HAL.DesignerRectTracker
        Dim CBlendItems7 As Theremino_HAL.cBlendItems = New Theremino_HAL.cBlendItems
        Dim CBlendItems8 As Theremino_HAL.cBlendItems = New Theremino_HAL.cBlendItems
        Dim DesignerRectTracker8 As Theremino_HAL.DesignerRectTracker = New Theremino_HAL.DesignerRectTracker
        Me.Timer_10Hz = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox_MasterProps = New System.Windows.Forms.GroupBox
        Me.btn_MasterName = New Theremino_HAL.MyButton
        Me.cmb_MasterNames = New Theremino_HAL.MyComboBox
        Me.chk_FastDataExchange = New System.Windows.Forms.CheckBox
        Me.lbl_ErrorRate = New System.Windows.Forms.Label
        Me.Label_ErrorRate = New System.Windows.Forms.Label
        Me.lbl_RepeatFrequency = New System.Windows.Forms.Label
        Me.Label_RepFreq = New System.Windows.Forms.Label
        Me.txt_CommSpeed = New Theremino_HAL.MyTextBox
        Me.Label_CommSpeed = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label_MinValue = New System.Windows.Forms.Label
        Me.Label_MaxValue = New System.Windows.Forms.Label
        Me.Label_Area = New System.Windows.Forms.Label
        Me.Label_MinDist = New System.Windows.Forms.Label
        Me.Label_MaxDist = New System.Windows.Forms.Label
        Me.GroupBox_PinProps = New System.Windows.Forms.GroupBox
        Me.Label_ResponseSpeed = New Theremino_HAL.MyButton
        Me.txt_Slot = New Theremino_HAL.MyTextBox
        Me.cmb_PinType = New Theremino_HAL.MyComboBox
        Me.Label_PinType = New System.Windows.Forms.Label
        Me.txt_MaxValue = New Theremino_HAL.MyTextBox
        Me.txt_ResponseSpeed = New Theremino_HAL.MyTextBox
        Me.txt_MinValue = New Theremino_HAL.MyTextBox
        Me.GroupBox_CapSensorProps = New System.Windows.Forms.GroupBox
        Me.chk_RemoveErrors = New System.Windows.Forms.CheckBox
        Me.txt_CapMaxDist = New Theremino_HAL.MyTextBox
        Me.txt_CapMinDist = New Theremino_HAL.MyTextBox
        Me.txt_CapArea = New Theremino_HAL.MyTextBox
        Me.Pic_CalibrateTime = New System.Windows.Forms.PictureBox
        Me.Timer_1Hz = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox_ServoPwmProps = New System.Windows.Forms.GroupBox
        Me.chk_LogResponse = New System.Windows.Forms.CheckBox
        Me.txt_ServoMaxTime = New Theremino_HAL.MyTextBox
        Me.Label_MinTime = New System.Windows.Forms.Label
        Me.txt_ServoMinTime = New Theremino_HAL.MyTextBox
        Me.Label_MaxTime = New System.Windows.Forms.Label
        Me.GroupBox_FrequencyProps = New System.Windows.Forms.GroupBox
        Me.chk_ConvertToFrequency = New System.Windows.Forms.CheckBox
        Me.txt_MaxFreq = New Theremino_HAL.MyTextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_MinFreq = New Theremino_HAL.MyTextBox
        Me.Label_MaxFreq = New System.Windows.Forms.Label
        Me.GroupBox_TouchProps = New System.Windows.Forms.GroupBox
        Me.txt_MinVariation = New Theremino_HAL.MyTextBox
        Me.Label_ProportionalArea = New System.Windows.Forms.Label
        Me.txt_ProportionalArea = New Theremino_HAL.MyTextBox
        Me.Label_MinVariation = New System.Windows.Forms.Label
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton_Recognize = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton_Validate = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton_BeepOnErrors = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton_Lock = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton_Disconnect = New System.Windows.Forms.ToolStripButton
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.Menu_File = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_File_OpenProgramFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_File_EditSlotNames = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_File_EditConfigurations = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.Menu_File_BackupConfigurations = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_File_LoadConfigurations = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.Menu_File_Exit = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Tools = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Language = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Language_English = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Language_Italian = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Language_Francais = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Language_Espanol = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Language_Portoguese = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Language_Deutsch = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Language_Japanese = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Language_Chinese = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Help = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_Help_ProgramHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.Menu_About = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox_StepperProps = New System.Windows.Forms.GroupBox
        Me.chk_LinkedToPrevious = New System.Windows.Forms.CheckBox
        Me.Label_StepsPerMillim = New System.Windows.Forms.Label
        Me.txt_StepsPerMillim = New Theremino_HAL.MyTextBox
        Me.txt_MaxSpeed = New Theremino_HAL.MyTextBox
        Me.Label_MaxAcc = New System.Windows.Forms.Label
        Me.txt_MaxAcc = New Theremino_HAL.MyTextBox
        Me.Label_MaxSpeed = New System.Windows.Forms.Label
        Me.GroupBox_PwmFastProps = New System.Windows.Forms.GroupBox
        Me.chk_DutyCycleFromSlot = New System.Windows.Forms.CheckBox
        Me.chk_FrequencyFromSlot = New System.Windows.Forms.CheckBox
        Me.txt_PwmFastFrequency = New Theremino_HAL.MyTextBox
        Me.Label_PwmFastDutyCycle = New System.Windows.Forms.Label
        Me.txt_PwmFastDutyCycle = New Theremino_HAL.MyTextBox
        Me.Label_PwmFastFrequency = New System.Windows.Forms.Label
        Me.GroupBox_Adc24Props = New System.Windows.Forms.GroupBox
        Me.cmb_Adc24Sps = New Theremino_HAL.MyComboBox
        Me.cmb_Adc24Filter = New Theremino_HAL.MyComboBox
        Me.Label_Adc24Filter = New System.Windows.Forms.Label
        Me.txt_NumberOfPins = New Theremino_HAL.MyTextBox
        Me.Label_SamplesPerSec = New System.Windows.Forms.Label
        Me.Label_NumberOfPins = New System.Windows.Forms.Label
        Me.GroupBox_Adc24ChProps = New System.Windows.Forms.GroupBox
        Me.cmb_Adc24ChGain = New Theremino_HAL.MyComboBox
        Me.cmb_Adc24ChType = New Theremino_HAL.MyComboBox
        Me.chk_Adc24ChBiased = New System.Windows.Forms.CheckBox
        Me.Label_Adc24ChGain = New System.Windows.Forms.Label
        Me.Label_Adc24ChType = New System.Windows.Forms.Label
        Me.Timer_60Hz = New System.Windows.Forms.Timer(Me.components)
        Me.btn_Reconnect = New Theremino_HAL.MyButton
        Me.txt_MinChange = New Theremino_HAL.MyTextBox
        Me.btn_Calibrate = New Theremino_HAL.MyButton
        Me.MyListView1 = New Theremino_HAL.ListViewFlickerFree
        Me.GroupBox_MasterProps.SuspendLayout()
        Me.GroupBox_PinProps.SuspendLayout()
        Me.GroupBox_CapSensorProps.SuspendLayout()
        CType(Me.Pic_CalibrateTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox_ServoPwmProps.SuspendLayout()
        Me.GroupBox_FrequencyProps.SuspendLayout()
        Me.GroupBox_TouchProps.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox_StepperProps.SuspendLayout()
        Me.GroupBox_PwmFastProps.SuspendLayout()
        Me.GroupBox_Adc24Props.SuspendLayout()
        Me.GroupBox_Adc24ChProps.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer_10Hz
        '
        '
        'GroupBox_MasterProps
        '
        Me.GroupBox_MasterProps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_MasterProps.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.GroupBox_MasterProps.Controls.Add(Me.btn_MasterName)
        Me.GroupBox_MasterProps.Controls.Add(Me.cmb_MasterNames)
        Me.GroupBox_MasterProps.Controls.Add(Me.chk_FastDataExchange)
        Me.GroupBox_MasterProps.Controls.Add(Me.lbl_ErrorRate)
        Me.GroupBox_MasterProps.Controls.Add(Me.Label_ErrorRate)
        Me.GroupBox_MasterProps.Controls.Add(Me.lbl_RepeatFrequency)
        Me.GroupBox_MasterProps.Controls.Add(Me.Label_RepFreq)
        Me.GroupBox_MasterProps.Controls.Add(Me.txt_CommSpeed)
        Me.GroupBox_MasterProps.Controls.Add(Me.Label_CommSpeed)
        Me.GroupBox_MasterProps.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_MasterProps.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox_MasterProps.Location = New System.Drawing.Point(439, 53)
        Me.GroupBox_MasterProps.Name = "GroupBox_MasterProps"
        Me.GroupBox_MasterProps.Size = New System.Drawing.Size(180, 130)
        Me.GroupBox_MasterProps.TabIndex = 137
        Me.GroupBox_MasterProps.TabStop = False
        Me.GroupBox_MasterProps.Text = "Master properties"
        '
        'btn_MasterName
        '
        Me.btn_MasterName.BorderColor = System.Drawing.Color.DarkGray
        DesignerRectTracker1.IsActive = False
        DesignerRectTracker1.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker1.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btn_MasterName.CenterPtTracker = DesignerRectTracker1
        CBlendItems1.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(133, Byte), Integer))}
        CBlendItems1.iPoint = New Single() {0.0!, 0.5017921!, 1.0!}
        Me.btn_MasterName.ColorFillBlend = CBlendItems1
        CBlendItems2.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems2.iPoint = New Single() {0.0!, 0.3309608!, 1.0!}
        Me.btn_MasterName.ColorFillBlendChecked = CBlendItems2
        Me.btn_MasterName.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btn_MasterName.ColorFillSolidChecked = System.Drawing.SystemColors.Control
        Me.btn_MasterName.Corners.All = CType(2, Short)
        Me.btn_MasterName.Corners.LowerLeft = CType(2, Short)
        Me.btn_MasterName.Corners.LowerRight = CType(2, Short)
        Me.btn_MasterName.Corners.UpperLeft = CType(2, Short)
        Me.btn_MasterName.Corners.UpperRight = CType(2, Short)
        Me.btn_MasterName.DimFactorGray = -10
        Me.btn_MasterName.DimFactorOver = 40
        Me.btn_MasterName.FillType = Theremino_HAL.MyButton.eFillType.LinearVertical
        Me.btn_MasterName.FillTypeChecked = Theremino_HAL.MyButton.eFillType.LinearVertical
        Me.btn_MasterName.FocalPoints.CenterPtX = 0.4318182!
        Me.btn_MasterName.FocalPoints.CenterPtY = 0.2666667!
        Me.btn_MasterName.FocalPoints.FocusPtX = 0.0!
        Me.btn_MasterName.FocalPoints.FocusPtY = 0.0!
        Me.btn_MasterName.FocalPointsChecked.CenterPtX = 0.5!
        Me.btn_MasterName.FocalPointsChecked.CenterPtY = 0.5!
        Me.btn_MasterName.FocalPointsChecked.FocusPtX = 0.0!
        Me.btn_MasterName.FocalPointsChecked.FocusPtY = 0.0!
        DesignerRectTracker2.IsActive = False
        DesignerRectTracker2.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker2.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btn_MasterName.FocusPtTracker = DesignerRectTracker2
        Me.btn_MasterName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_MasterName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.btn_MasterName.Image = Nothing
        Me.btn_MasterName.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_MasterName.ImageIndex = 0
        Me.btn_MasterName.ImageSize = New System.Drawing.Size(16, 16)
        Me.btn_MasterName.Location = New System.Drawing.Point(13, 23)
        Me.btn_MasterName.Name = "btn_MasterName"
        Me.btn_MasterName.Shape = Theremino_HAL.MyButton.eShape.Rectangle
        Me.btn_MasterName.SideImage = Nothing
        Me.btn_MasterName.SideImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_MasterName.SideImageSize = New System.Drawing.Size(32, 32)
        Me.btn_MasterName.Size = New System.Drawing.Size(44, 15)
        Me.btn_MasterName.TabIndex = 179
        Me.btn_MasterName.Text = "Name"
        Me.btn_MasterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_MasterName.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_MasterName.TextMargin = New System.Windows.Forms.Padding(0)
        Me.btn_MasterName.TextShadow = System.Drawing.Color.Transparent
        '
        'cmb_MasterNames
        '
        Me.cmb_MasterNames.ArrowButtonColor = System.Drawing.Color.Transparent
        Me.cmb_MasterNames.ArrowColor = System.Drawing.Color.Transparent
        Me.cmb_MasterNames.BackColor = System.Drawing.Color.MintCream
        Me.cmb_MasterNames.BackColor_Focused = System.Drawing.Color.MintCream
        Me.cmb_MasterNames.BackColor_Over = System.Drawing.Color.Moccasin
        Me.cmb_MasterNames.BorderColor = System.Drawing.Color.PowderBlue
        Me.cmb_MasterNames.BorderSize = 1
        Me.cmb_MasterNames.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmb_MasterNames.DropDown_BackColor = System.Drawing.Color.AliceBlue
        Me.cmb_MasterNames.DropDown_BackSelected = System.Drawing.Color.LightBlue
        Me.cmb_MasterNames.DropDown_BorderColor = System.Drawing.Color.Gainsboro
        Me.cmb_MasterNames.DropDown_ForeColor = System.Drawing.Color.Black
        Me.cmb_MasterNames.DropDown_ForeSelected = System.Drawing.Color.Black
        Me.cmb_MasterNames.DropDownHeight = 500
        Me.cmb_MasterNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_MasterNames.DropDownWidth = 122
        Me.cmb_MasterNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_MasterNames.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_MasterNames.ForeColor = System.Drawing.Color.Black
        Me.cmb_MasterNames.IntegralHeight = False
        Me.cmb_MasterNames.ItemHeight = 10
        Me.cmb_MasterNames.Location = New System.Drawing.Point(61, 22)
        Me.cmb_MasterNames.MaxDropDownItems = 99
        Me.cmb_MasterNames.Name = "cmb_MasterNames"
        Me.cmb_MasterNames.ShadowColor = System.Drawing.Color.Transparent
        Me.cmb_MasterNames.Size = New System.Drawing.Size(109, 16)
        Me.cmb_MasterNames.TabIndex = 178
        Me.cmb_MasterNames.TabStop = False
        Me.cmb_MasterNames.TextPosition = 1
        '
        'chk_FastDataExchange
        '
        Me.chk_FastDataExchange.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_FastDataExchange.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_FastDataExchange.Location = New System.Drawing.Point(10, 107)
        Me.chk_FastDataExchange.Name = "chk_FastDataExchange"
        Me.chk_FastDataExchange.Size = New System.Drawing.Size(157, 17)
        Me.chk_FastDataExchange.TabIndex = 5
        Me.chk_FastDataExchange.Text = "Fast data exchange     "
        Me.chk_FastDataExchange.UseVisualStyleBackColor = True
        '
        'lbl_ErrorRate
        '
        Me.lbl_ErrorRate.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ErrorRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_ErrorRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ErrorRate.Location = New System.Drawing.Point(118, 65)
        Me.lbl_ErrorRate.Name = "lbl_ErrorRate"
        Me.lbl_ErrorRate.Size = New System.Drawing.Size(51, 17)
        Me.lbl_ErrorRate.TabIndex = 177
        Me.lbl_ErrorRate.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label_ErrorRate
        '
        Me.Label_ErrorRate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ErrorRate.Location = New System.Drawing.Point(10, 66)
        Me.Label_ErrorRate.Name = "Label_ErrorRate"
        Me.Label_ErrorRate.Size = New System.Drawing.Size(102, 13)
        Me.Label_ErrorRate.TabIndex = 176
        Me.Label_ErrorRate.Text = "Error rate (%)"
        Me.Label_ErrorRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbl_RepeatFrequency
        '
        Me.lbl_RepeatFrequency.BackColor = System.Drawing.Color.Transparent
        Me.lbl_RepeatFrequency.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl_RepeatFrequency.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_RepeatFrequency.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbl_RepeatFrequency.Location = New System.Drawing.Point(118, 46)
        Me.lbl_RepeatFrequency.Name = "lbl_RepeatFrequency"
        Me.lbl_RepeatFrequency.Size = New System.Drawing.Size(51, 17)
        Me.lbl_RepeatFrequency.TabIndex = 175
        Me.lbl_RepeatFrequency.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label_RepFreq
        '
        Me.Label_RepFreq.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_RepFreq.Location = New System.Drawing.Point(10, 45)
        Me.Label_RepFreq.Name = "Label_RepFreq"
        Me.Label_RepFreq.Size = New System.Drawing.Size(102, 13)
        Me.Label_RepFreq.TabIndex = 174
        Me.Label_RepFreq.Text = "Rep freq. (fps)"
        Me.Label_RepFreq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_CommSpeed
        '
        Me.txt_CommSpeed.ArrowsIncrement = 1
        Me.txt_CommSpeed.BackColor = System.Drawing.Color.MintCream
        Me.txt_CommSpeed.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_CommSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_CommSpeed.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_CommSpeed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CommSpeed.ForeColor = System.Drawing.Color.Black
        Me.txt_CommSpeed.Increment = 0.2
        Me.txt_CommSpeed.Location = New System.Drawing.Point(129, 87)
        Me.txt_CommSpeed.MaxValue = 12
        Me.txt_CommSpeed.MinValue = 1
        Me.txt_CommSpeed.Name = "txt_CommSpeed"
        Me.txt_CommSpeed.NumericValue = 7
        Me.txt_CommSpeed.NumericValueInteger = 7
        Me.txt_CommSpeed.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_CommSpeed.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_CommSpeed.RoundingStep = 0
        Me.txt_CommSpeed.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_CommSpeed.Size = New System.Drawing.Size(40, 15)
        Me.txt_CommSpeed.SuppressZeros = True
        Me.txt_CommSpeed.TabIndex = 2
        Me.txt_CommSpeed.Text = "7"
        Me.txt_CommSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_CommSpeed
        '
        Me.Label_CommSpeed.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_CommSpeed.Location = New System.Drawing.Point(10, 88)
        Me.Label_CommSpeed.Name = "Label_CommSpeed"
        Me.Label_CommSpeed.Size = New System.Drawing.Size(112, 13)
        Me.Label_CommSpeed.TabIndex = 162
        Me.Label_CommSpeed.Text = "Comm. speed"
        Me.Label_CommSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(108, 13)
        Me.Label13.TabIndex = 174
        Me.Label13.Text = "Slot"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_MinValue
        '
        Me.Label_MinValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MinValue.Location = New System.Drawing.Point(10, 92)
        Me.Label_MinValue.Name = "Label_MinValue"
        Me.Label_MinValue.Size = New System.Drawing.Size(102, 13)
        Me.Label_MinValue.TabIndex = 166
        Me.Label_MinValue.Text = "Min value"
        Me.Label_MinValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_MaxValue
        '
        Me.Label_MaxValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MaxValue.Location = New System.Drawing.Point(10, 71)
        Me.Label_MaxValue.Name = "Label_MaxValue"
        Me.Label_MaxValue.Size = New System.Drawing.Size(102, 13)
        Me.Label_MaxValue.TabIndex = 162
        Me.Label_MaxValue.Text = "Max value"
        Me.Label_MaxValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_Area
        '
        Me.Label_Area.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Area.Location = New System.Drawing.Point(10, 68)
        Me.Label_Area.Name = "Label_Area"
        Me.Label_Area.Size = New System.Drawing.Size(108, 13)
        Me.Label_Area.TabIndex = 168
        Me.Label_Area.Text = "Area      ( cmq )"
        Me.Label_Area.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_MinDist
        '
        Me.Label_MinDist.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MinDist.Location = New System.Drawing.Point(10, 47)
        Me.Label_MinDist.Name = "Label_MinDist"
        Me.Label_MinDist.Size = New System.Drawing.Size(108, 13)
        Me.Label_MinDist.TabIndex = 163
        Me.Label_MinDist.Text = "Min dist  ( mm )"
        Me.Label_MinDist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_MaxDist
        '
        Me.Label_MaxDist.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MaxDist.Location = New System.Drawing.Point(10, 26)
        Me.Label_MaxDist.Name = "Label_MaxDist"
        Me.Label_MaxDist.Size = New System.Drawing.Size(108, 13)
        Me.Label_MaxDist.TabIndex = 161
        Me.Label_MaxDist.Text = "Max dist ( mm )"
        Me.Label_MaxDist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox_PinProps
        '
        Me.GroupBox_PinProps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_PinProps.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.GroupBox_PinProps.Controls.Add(Me.Label_ResponseSpeed)
        Me.GroupBox_PinProps.Controls.Add(Me.txt_Slot)
        Me.GroupBox_PinProps.Controls.Add(Me.cmb_PinType)
        Me.GroupBox_PinProps.Controls.Add(Me.Label_PinType)
        Me.GroupBox_PinProps.Controls.Add(Me.Label_MaxValue)
        Me.GroupBox_PinProps.Controls.Add(Me.Label13)
        Me.GroupBox_PinProps.Controls.Add(Me.txt_MaxValue)
        Me.GroupBox_PinProps.Controls.Add(Me.txt_ResponseSpeed)
        Me.GroupBox_PinProps.Controls.Add(Me.txt_MinValue)
        Me.GroupBox_PinProps.Controls.Add(Me.Label_MinValue)
        Me.GroupBox_PinProps.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_PinProps.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox_PinProps.Location = New System.Drawing.Point(439, 188)
        Me.GroupBox_PinProps.Name = "GroupBox_PinProps"
        Me.GroupBox_PinProps.Size = New System.Drawing.Size(180, 136)
        Me.GroupBox_PinProps.TabIndex = 138
        Me.GroupBox_PinProps.TabStop = False
        Me.GroupBox_PinProps.Text = "Pin properties"
        Me.GroupBox_PinProps.Visible = False
        '
        'Label_ResponseSpeed
        '
        Me.Label_ResponseSpeed.BorderColor = System.Drawing.Color.Gray
        DesignerRectTracker3.IsActive = True
        DesignerRectTracker3.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker3.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Label_ResponseSpeed.CenterPtTracker = DesignerRectTracker3
        Me.Label_ResponseSpeed.CheckButton = True
        CBlendItems3.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(192, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))}
        CBlendItems3.iPoint = New Single() {0.0!, 0.5017921!, 1.0!}
        Me.Label_ResponseSpeed.ColorFillBlend = CBlendItems3
        CBlendItems4.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems4.iPoint = New Single() {0.0!, 0.3309608!, 1.0!}
        Me.Label_ResponseSpeed.ColorFillBlendChecked = CBlendItems4
        Me.Label_ResponseSpeed.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.Label_ResponseSpeed.ColorFillSolidChecked = System.Drawing.SystemColors.Control
        Me.Label_ResponseSpeed.Corners.All = CType(3, Short)
        Me.Label_ResponseSpeed.Corners.LowerLeft = CType(3, Short)
        Me.Label_ResponseSpeed.Corners.LowerRight = CType(3, Short)
        Me.Label_ResponseSpeed.Corners.UpperLeft = CType(3, Short)
        Me.Label_ResponseSpeed.Corners.UpperRight = CType(3, Short)
        Me.Label_ResponseSpeed.DimFactorGray = -10
        Me.Label_ResponseSpeed.DimFactorOver = 30
        Me.Label_ResponseSpeed.FillType = Theremino_HAL.MyButton.eFillType.LinearVertical
        Me.Label_ResponseSpeed.FillTypeChecked = Theremino_HAL.MyButton.eFillType.LinearVertical
        Me.Label_ResponseSpeed.FocalPoints.CenterPtX = 0.0!
        Me.Label_ResponseSpeed.FocalPoints.CenterPtY = 0.4074074!
        Me.Label_ResponseSpeed.FocalPoints.FocusPtX = 0.0!
        Me.Label_ResponseSpeed.FocalPoints.FocusPtY = 0.0!
        Me.Label_ResponseSpeed.FocalPointsChecked.CenterPtX = 0.5925926!
        Me.Label_ResponseSpeed.FocalPointsChecked.CenterPtY = 0.2352941!
        Me.Label_ResponseSpeed.FocalPointsChecked.FocusPtX = 0.0!
        Me.Label_ResponseSpeed.FocalPointsChecked.FocusPtY = 0.0!
        DesignerRectTracker4.IsActive = False
        DesignerRectTracker4.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker4.TrackerRectangle"), System.Drawing.RectangleF)
        Me.Label_ResponseSpeed.FocusPtTracker = DesignerRectTracker4
        Me.Label_ResponseSpeed.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ResponseSpeed.ForeColorChecked = System.Drawing.Color.Black
        Me.Label_ResponseSpeed.Image = Nothing
        Me.Label_ResponseSpeed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label_ResponseSpeed.ImageIndex = 0
        Me.Label_ResponseSpeed.ImageSize = New System.Drawing.Size(16, 16)
        Me.Label_ResponseSpeed.Location = New System.Drawing.Point(7, 112)
        Me.Label_ResponseSpeed.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Label_ResponseSpeed.Name = "Label_ResponseSpeed"
        Me.Label_ResponseSpeed.Shape = Theremino_HAL.MyButton.eShape.Rectangle
        Me.Label_ResponseSpeed.SideImage = Nothing
        Me.Label_ResponseSpeed.SideImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label_ResponseSpeed.SideImageSize = New System.Drawing.Size(32, 32)
        Me.Label_ResponseSpeed.Size = New System.Drawing.Size(108, 15)
        Me.Label_ResponseSpeed.TabIndex = 220
        Me.Label_ResponseSpeed.Text = "Response speed"
        Me.Label_ResponseSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label_ResponseSpeed.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.Label_ResponseSpeed.TextMargin = New System.Windows.Forms.Padding(0)
        Me.Label_ResponseSpeed.TextShadow = System.Drawing.Color.Transparent
        Me.Label_ResponseSpeed.TextShadowChecked = System.Drawing.Color.Empty
        '
        'txt_Slot
        '
        Me.txt_Slot.ArrowsIncrement = 1
        Me.txt_Slot.BackColor = System.Drawing.Color.MintCream
        Me.txt_Slot.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_Slot.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_Slot.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_Slot.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Slot.ForeColor = System.Drawing.Color.Black
        Me.txt_Slot.Increment = 0.2
        Me.txt_Slot.Location = New System.Drawing.Point(118, 49)
        Me.txt_Slot.MaxValue = 999
        Me.txt_Slot.MinValue = 1
        Me.txt_Slot.Name = "txt_Slot"
        Me.txt_Slot.NumericValue = 1
        Me.txt_Slot.NumericValueInteger = 1
        Me.txt_Slot.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_Slot.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_Slot.RoundingStep = 0
        Me.txt_Slot.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_Slot.Size = New System.Drawing.Size(51, 15)
        Me.txt_Slot.SuppressZeros = True
        Me.txt_Slot.TabIndex = 11
        Me.txt_Slot.Text = "0"
        Me.txt_Slot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmb_PinType
        '
        Me.cmb_PinType.ArrowButtonColor = System.Drawing.Color.Transparent
        Me.cmb_PinType.ArrowColor = System.Drawing.Color.Transparent
        Me.cmb_PinType.BackColor = System.Drawing.Color.MintCream
        Me.cmb_PinType.BackColor_Focused = System.Drawing.Color.MintCream
        Me.cmb_PinType.BackColor_Over = System.Drawing.Color.Moccasin
        Me.cmb_PinType.BorderColor = System.Drawing.Color.PowderBlue
        Me.cmb_PinType.BorderSize = 1
        Me.cmb_PinType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmb_PinType.DropDown_BackColor = System.Drawing.Color.AliceBlue
        Me.cmb_PinType.DropDown_BackSelected = System.Drawing.Color.LightBlue
        Me.cmb_PinType.DropDown_BorderColor = System.Drawing.Color.Gainsboro
        Me.cmb_PinType.DropDown_ForeColor = System.Drawing.Color.Black
        Me.cmb_PinType.DropDown_ForeSelected = System.Drawing.Color.Black
        Me.cmb_PinType.DropDownHeight = 500
        Me.cmb_PinType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_PinType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_PinType.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_PinType.ForeColor = System.Drawing.Color.Black
        Me.cmb_PinType.IntegralHeight = False
        Me.cmb_PinType.ItemHeight = 12
        Me.cmb_PinType.Location = New System.Drawing.Point(70, 22)
        Me.cmb_PinType.Name = "cmb_PinType"
        Me.cmb_PinType.ShadowColor = System.Drawing.Color.Transparent
        Me.cmb_PinType.Size = New System.Drawing.Size(99, 18)
        Me.cmb_PinType.TabIndex = 10
        Me.cmb_PinType.TabStop = False
        Me.cmb_PinType.TextPosition = 1
        '
        'Label_PinType
        '
        Me.Label_PinType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PinType.Location = New System.Drawing.Point(10, 24)
        Me.Label_PinType.Name = "Label_PinType"
        Me.Label_PinType.Size = New System.Drawing.Size(58, 13)
        Me.Label_PinType.TabIndex = 172
        Me.Label_PinType.Text = "Pin type"
        Me.Label_PinType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_MaxValue
        '
        Me.txt_MaxValue.ArrowsIncrement = 1
        Me.txt_MaxValue.BackColor = System.Drawing.Color.MintCream
        Me.txt_MaxValue.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_MaxValue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_MaxValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_MaxValue.Decimals = 3
        Me.txt_MaxValue.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MaxValue.ForeColor = System.Drawing.Color.Black
        Me.txt_MaxValue.Increment = 0.2
        Me.txt_MaxValue.Location = New System.Drawing.Point(113, 70)
        Me.txt_MaxValue.MaxValue = 9999999
        Me.txt_MaxValue.MinValue = -999999
        Me.txt_MaxValue.Name = "txt_MaxValue"
        Me.txt_MaxValue.NumericValue = 1000
        Me.txt_MaxValue.NumericValueInteger = 1000
        Me.txt_MaxValue.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_MaxValue.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_MaxValue.RoundingStep = 0
        Me.txt_MaxValue.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_MaxValue.Size = New System.Drawing.Size(56, 15)
        Me.txt_MaxValue.SuppressZeros = True
        Me.txt_MaxValue.TabIndex = 12
        Me.txt_MaxValue.Text = "1000"
        Me.txt_MaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_ResponseSpeed
        '
        Me.txt_ResponseSpeed.ArrowsIncrement = 1
        Me.txt_ResponseSpeed.BackColor = System.Drawing.Color.MintCream
        Me.txt_ResponseSpeed.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_ResponseSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_ResponseSpeed.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_ResponseSpeed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ResponseSpeed.ForeColor = System.Drawing.Color.Black
        Me.txt_ResponseSpeed.Increment = 0.2
        Me.txt_ResponseSpeed.Location = New System.Drawing.Point(118, 112)
        Me.txt_ResponseSpeed.MaxValue = 100
        Me.txt_ResponseSpeed.MinValue = 1
        Me.txt_ResponseSpeed.Name = "txt_ResponseSpeed"
        Me.txt_ResponseSpeed.NumericValue = 30
        Me.txt_ResponseSpeed.NumericValueInteger = 30
        Me.txt_ResponseSpeed.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_ResponseSpeed.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_ResponseSpeed.RoundingStep = 0
        Me.txt_ResponseSpeed.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_ResponseSpeed.Size = New System.Drawing.Size(51, 15)
        Me.txt_ResponseSpeed.SuppressZeros = True
        Me.txt_ResponseSpeed.TabIndex = 14
        Me.txt_ResponseSpeed.Text = "30"
        Me.txt_ResponseSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_MinValue
        '
        Me.txt_MinValue.ArrowsIncrement = 1
        Me.txt_MinValue.BackColor = System.Drawing.Color.MintCream
        Me.txt_MinValue.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_MinValue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_MinValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_MinValue.Decimals = 3
        Me.txt_MinValue.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MinValue.ForeColor = System.Drawing.Color.Black
        Me.txt_MinValue.Increment = 0.2
        Me.txt_MinValue.Location = New System.Drawing.Point(113, 91)
        Me.txt_MinValue.MaxValue = 9999999
        Me.txt_MinValue.MinValue = -999999
        Me.txt_MinValue.Name = "txt_MinValue"
        Me.txt_MinValue.NumericValue = 0
        Me.txt_MinValue.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_MinValue.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_MinValue.RoundingStep = 0
        Me.txt_MinValue.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_MinValue.Size = New System.Drawing.Size(56, 15)
        Me.txt_MinValue.SuppressZeros = True
        Me.txt_MinValue.TabIndex = 13
        Me.txt_MinValue.Text = "0"
        Me.txt_MinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox_CapSensorProps
        '
        Me.GroupBox_CapSensorProps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_CapSensorProps.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.GroupBox_CapSensorProps.Controls.Add(Me.chk_RemoveErrors)
        Me.GroupBox_CapSensorProps.Controls.Add(Me.txt_CapMaxDist)
        Me.GroupBox_CapSensorProps.Controls.Add(Me.Label_MinDist)
        Me.GroupBox_CapSensorProps.Controls.Add(Me.txt_CapMinDist)
        Me.GroupBox_CapSensorProps.Controls.Add(Me.txt_CapArea)
        Me.GroupBox_CapSensorProps.Controls.Add(Me.Label_Area)
        Me.GroupBox_CapSensorProps.Controls.Add(Me.Label_MaxDist)
        Me.GroupBox_CapSensorProps.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_CapSensorProps.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox_CapSensorProps.Location = New System.Drawing.Point(439, 329)
        Me.GroupBox_CapSensorProps.Name = "GroupBox_CapSensorProps"
        Me.GroupBox_CapSensorProps.Size = New System.Drawing.Size(180, 110)
        Me.GroupBox_CapSensorProps.TabIndex = 139
        Me.GroupBox_CapSensorProps.TabStop = False
        Me.GroupBox_CapSensorProps.Text = "Cap sensor properties"
        Me.GroupBox_CapSensorProps.Visible = False
        '
        'chk_RemoveErrors
        '
        Me.chk_RemoveErrors.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_RemoveErrors.Checked = True
        Me.chk_RemoveErrors.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_RemoveErrors.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_RemoveErrors.Location = New System.Drawing.Point(10, 88)
        Me.chk_RemoveErrors.Name = "chk_RemoveErrors"
        Me.chk_RemoveErrors.Size = New System.Drawing.Size(156, 17)
        Me.chk_RemoveErrors.TabIndex = 169
        Me.chk_RemoveErrors.Text = "Remove errors"
        Me.chk_RemoveErrors.UseVisualStyleBackColor = True
        '
        'txt_CapMaxDist
        '
        Me.txt_CapMaxDist.ArrowsIncrement = 1
        Me.txt_CapMaxDist.BackColor = System.Drawing.Color.MintCream
        Me.txt_CapMaxDist.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_CapMaxDist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_CapMaxDist.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_CapMaxDist.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CapMaxDist.ForeColor = System.Drawing.Color.Black
        Me.txt_CapMaxDist.Increment = 0.2
        Me.txt_CapMaxDist.Location = New System.Drawing.Point(118, 25)
        Me.txt_CapMaxDist.MaxValue = 9999
        Me.txt_CapMaxDist.MinValue = 50
        Me.txt_CapMaxDist.Name = "txt_CapMaxDist"
        Me.txt_CapMaxDist.NumericValue = 150
        Me.txt_CapMaxDist.NumericValueInteger = 150
        Me.txt_CapMaxDist.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_CapMaxDist.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_CapMaxDist.RoundingStep = 0
        Me.txt_CapMaxDist.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_CapMaxDist.Size = New System.Drawing.Size(51, 15)
        Me.txt_CapMaxDist.SuppressZeros = True
        Me.txt_CapMaxDist.TabIndex = 15
        Me.txt_CapMaxDist.Text = "150"
        Me.txt_CapMaxDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_CapMinDist
        '
        Me.txt_CapMinDist.ArrowsIncrement = 1
        Me.txt_CapMinDist.BackColor = System.Drawing.Color.MintCream
        Me.txt_CapMinDist.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_CapMinDist.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_CapMinDist.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_CapMinDist.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CapMinDist.ForeColor = System.Drawing.Color.Black
        Me.txt_CapMinDist.Increment = 0.2
        Me.txt_CapMinDist.Location = New System.Drawing.Point(118, 46)
        Me.txt_CapMinDist.MaxValue = 5000
        Me.txt_CapMinDist.MinValue = 0
        Me.txt_CapMinDist.Name = "txt_CapMinDist"
        Me.txt_CapMinDist.NumericValue = 30
        Me.txt_CapMinDist.NumericValueInteger = 30
        Me.txt_CapMinDist.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_CapMinDist.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_CapMinDist.RoundingStep = 0
        Me.txt_CapMinDist.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_CapMinDist.Size = New System.Drawing.Size(51, 15)
        Me.txt_CapMinDist.SuppressZeros = True
        Me.txt_CapMinDist.TabIndex = 16
        Me.txt_CapMinDist.Text = "30"
        Me.txt_CapMinDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_CapArea
        '
        Me.txt_CapArea.ArrowsIncrement = 1
        Me.txt_CapArea.BackColor = System.Drawing.Color.MintCream
        Me.txt_CapArea.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_CapArea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_CapArea.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_CapArea.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CapArea.ForeColor = System.Drawing.Color.Black
        Me.txt_CapArea.Increment = 0.2
        Me.txt_CapArea.Location = New System.Drawing.Point(118, 67)
        Me.txt_CapArea.MaxValue = 9999
        Me.txt_CapArea.MinValue = 0
        Me.txt_CapArea.Name = "txt_CapArea"
        Me.txt_CapArea.NumericValue = 10
        Me.txt_CapArea.NumericValueInteger = 10
        Me.txt_CapArea.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_CapArea.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_CapArea.RoundingStep = 0
        Me.txt_CapArea.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_CapArea.Size = New System.Drawing.Size(51, 15)
        Me.txt_CapArea.SuppressZeros = True
        Me.txt_CapArea.TabIndex = 12
        Me.txt_CapArea.Text = "10"
        Me.txt_CapArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Pic_CalibrateTime
        '
        Me.Pic_CalibrateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pic_CalibrateTime.BackColor = System.Drawing.Color.LightGray
        Me.Pic_CalibrateTime.Location = New System.Drawing.Point(525, 17)
        Me.Pic_CalibrateTime.Name = "Pic_CalibrateTime"
        Me.Pic_CalibrateTime.Size = New System.Drawing.Size(93, 3)
        Me.Pic_CalibrateTime.TabIndex = 176
        Me.Pic_CalibrateTime.TabStop = False
        '
        'Timer_1Hz
        '
        '
        'GroupBox_ServoPwmProps
        '
        Me.GroupBox_ServoPwmProps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_ServoPwmProps.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.GroupBox_ServoPwmProps.Controls.Add(Me.chk_LogResponse)
        Me.GroupBox_ServoPwmProps.Controls.Add(Me.txt_ServoMaxTime)
        Me.GroupBox_ServoPwmProps.Controls.Add(Me.Label_MinTime)
        Me.GroupBox_ServoPwmProps.Controls.Add(Me.txt_ServoMinTime)
        Me.GroupBox_ServoPwmProps.Controls.Add(Me.Label_MaxTime)
        Me.GroupBox_ServoPwmProps.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_ServoPwmProps.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox_ServoPwmProps.Location = New System.Drawing.Point(236, 241)
        Me.GroupBox_ServoPwmProps.Name = "GroupBox_ServoPwmProps"
        Me.GroupBox_ServoPwmProps.Size = New System.Drawing.Size(180, 92)
        Me.GroupBox_ServoPwmProps.TabIndex = 177
        Me.GroupBox_ServoPwmProps.TabStop = False
        Me.GroupBox_ServoPwmProps.Text = "Servo properties"
        Me.GroupBox_ServoPwmProps.Visible = False
        '
        'chk_LogResponse
        '
        Me.chk_LogResponse.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_LogResponse.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_LogResponse.Location = New System.Drawing.Point(10, 69)
        Me.chk_LogResponse.Name = "chk_LogResponse"
        Me.chk_LogResponse.Size = New System.Drawing.Size(156, 17)
        Me.chk_LogResponse.TabIndex = 165
        Me.chk_LogResponse.Text = "Logarithmic response  "
        Me.chk_LogResponse.UseVisualStyleBackColor = True
        '
        'txt_ServoMaxTime
        '
        Me.txt_ServoMaxTime.ArrowsIncrement = 1
        Me.txt_ServoMaxTime.BackColor = System.Drawing.Color.MintCream
        Me.txt_ServoMaxTime.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_ServoMaxTime.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_ServoMaxTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_ServoMaxTime.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ServoMaxTime.ForeColor = System.Drawing.Color.Black
        Me.txt_ServoMaxTime.Increment = 0.2
        Me.txt_ServoMaxTime.Location = New System.Drawing.Point(119, 25)
        Me.txt_ServoMaxTime.MaxValue = 4000
        Me.txt_ServoMaxTime.MinValue = 0
        Me.txt_ServoMaxTime.Name = "txt_ServoMaxTime"
        Me.txt_ServoMaxTime.NumericValue = 2500
        Me.txt_ServoMaxTime.NumericValueInteger = 2500
        Me.txt_ServoMaxTime.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_ServoMaxTime.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_ServoMaxTime.RoundingStep = 0
        Me.txt_ServoMaxTime.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_ServoMaxTime.Size = New System.Drawing.Size(51, 15)
        Me.txt_ServoMaxTime.SuppressZeros = True
        Me.txt_ServoMaxTime.TabIndex = 19
        Me.txt_ServoMaxTime.Text = "2500"
        Me.txt_ServoMaxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_MinTime
        '
        Me.Label_MinTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MinTime.Location = New System.Drawing.Point(10, 47)
        Me.Label_MinTime.Name = "Label_MinTime"
        Me.Label_MinTime.Size = New System.Drawing.Size(106, 13)
        Me.Label_MinTime.TabIndex = 163
        Me.Label_MinTime.Text = "Min time  ( uS )"
        Me.Label_MinTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_ServoMinTime
        '
        Me.txt_ServoMinTime.ArrowsIncrement = 1
        Me.txt_ServoMinTime.BackColor = System.Drawing.Color.MintCream
        Me.txt_ServoMinTime.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_ServoMinTime.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_ServoMinTime.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_ServoMinTime.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ServoMinTime.ForeColor = System.Drawing.Color.Black
        Me.txt_ServoMinTime.Increment = 0.2
        Me.txt_ServoMinTime.Location = New System.Drawing.Point(119, 46)
        Me.txt_ServoMinTime.MaxValue = 4000
        Me.txt_ServoMinTime.MinValue = 0
        Me.txt_ServoMinTime.Name = "txt_ServoMinTime"
        Me.txt_ServoMinTime.NumericValue = 500
        Me.txt_ServoMinTime.NumericValueInteger = 500
        Me.txt_ServoMinTime.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_ServoMinTime.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_ServoMinTime.RoundingStep = 0
        Me.txt_ServoMinTime.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_ServoMinTime.Size = New System.Drawing.Size(51, 15)
        Me.txt_ServoMinTime.SuppressZeros = True
        Me.txt_ServoMinTime.TabIndex = 20
        Me.txt_ServoMinTime.Text = "500"
        Me.txt_ServoMinTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_MaxTime
        '
        Me.Label_MaxTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MaxTime.Location = New System.Drawing.Point(10, 26)
        Me.Label_MaxTime.Name = "Label_MaxTime"
        Me.Label_MaxTime.Size = New System.Drawing.Size(106, 13)
        Me.Label_MaxTime.TabIndex = 161
        Me.Label_MaxTime.Text = "Max time ( uS )"
        Me.Label_MaxTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox_FrequencyProps
        '
        Me.GroupBox_FrequencyProps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_FrequencyProps.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.GroupBox_FrequencyProps.Controls.Add(Me.chk_ConvertToFrequency)
        Me.GroupBox_FrequencyProps.Controls.Add(Me.txt_MaxFreq)
        Me.GroupBox_FrequencyProps.Controls.Add(Me.Label14)
        Me.GroupBox_FrequencyProps.Controls.Add(Me.txt_MinFreq)
        Me.GroupBox_FrequencyProps.Controls.Add(Me.Label_MaxFreq)
        Me.GroupBox_FrequencyProps.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_FrequencyProps.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox_FrequencyProps.Location = New System.Drawing.Point(236, 340)
        Me.GroupBox_FrequencyProps.Name = "GroupBox_FrequencyProps"
        Me.GroupBox_FrequencyProps.Size = New System.Drawing.Size(180, 91)
        Me.GroupBox_FrequencyProps.TabIndex = 178
        Me.GroupBox_FrequencyProps.TabStop = False
        Me.GroupBox_FrequencyProps.Text = "Freq. properties"
        Me.GroupBox_FrequencyProps.Visible = False
        '
        'chk_ConvertToFrequency
        '
        Me.chk_ConvertToFrequency.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_ConvertToFrequency.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_ConvertToFrequency.Location = New System.Drawing.Point(10, 20)
        Me.chk_ConvertToFrequency.Name = "chk_ConvertToFrequency"
        Me.chk_ConvertToFrequency.Size = New System.Drawing.Size(156, 17)
        Me.chk_ConvertToFrequency.TabIndex = 164
        Me.chk_ConvertToFrequency.Text = "Convert to frequency  "
        Me.chk_ConvertToFrequency.UseVisualStyleBackColor = True
        '
        'txt_MaxFreq
        '
        Me.txt_MaxFreq.ArrowsIncrement = 1
        Me.txt_MaxFreq.BackColor = System.Drawing.Color.MintCream
        Me.txt_MaxFreq.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_MaxFreq.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_MaxFreq.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_MaxFreq.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MaxFreq.ForeColor = System.Drawing.Color.Black
        Me.txt_MaxFreq.Increment = 0.2
        Me.txt_MaxFreq.Location = New System.Drawing.Point(107, 48)
        Me.txt_MaxFreq.MaxValue = 50000000
        Me.txt_MaxFreq.MinValue = 1
        Me.txt_MaxFreq.Name = "txt_MaxFreq"
        Me.txt_MaxFreq.NumericValue = 1000
        Me.txt_MaxFreq.NumericValueInteger = 1000
        Me.txt_MaxFreq.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_MaxFreq.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_MaxFreq.RoundingStep = 0
        Me.txt_MaxFreq.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_MaxFreq.Size = New System.Drawing.Size(67, 15)
        Me.txt_MaxFreq.SuppressZeros = True
        Me.txt_MaxFreq.TabIndex = 22
        Me.txt_MaxFreq.Text = "1000"
        Me.txt_MaxFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(10, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 13)
        Me.Label14.TabIndex = 163
        Me.Label14.Text = "Min freq ( Hz )"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_MinFreq
        '
        Me.txt_MinFreq.ArrowsIncrement = 1
        Me.txt_MinFreq.BackColor = System.Drawing.Color.MintCream
        Me.txt_MinFreq.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_MinFreq.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_MinFreq.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_MinFreq.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MinFreq.ForeColor = System.Drawing.Color.Black
        Me.txt_MinFreq.Increment = 0.2
        Me.txt_MinFreq.Location = New System.Drawing.Point(107, 68)
        Me.txt_MinFreq.MaxValue = 50000000
        Me.txt_MinFreq.MinValue = 0
        Me.txt_MinFreq.Name = "txt_MinFreq"
        Me.txt_MinFreq.NumericValue = 0
        Me.txt_MinFreq.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_MinFreq.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_MinFreq.RoundingStep = 0
        Me.txt_MinFreq.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_MinFreq.Size = New System.Drawing.Size(67, 15)
        Me.txt_MinFreq.SuppressZeros = True
        Me.txt_MinFreq.TabIndex = 23
        Me.txt_MinFreq.Text = "0"
        Me.txt_MinFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_MaxFreq
        '
        Me.Label_MaxFreq.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MaxFreq.Location = New System.Drawing.Point(10, 49)
        Me.Label_MaxFreq.Name = "Label_MaxFreq"
        Me.Label_MaxFreq.Size = New System.Drawing.Size(96, 13)
        Me.Label_MaxFreq.TabIndex = 161
        Me.Label_MaxFreq.Text = "Max freq ( Hz )"
        Me.Label_MaxFreq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox_TouchProps
        '
        Me.GroupBox_TouchProps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_TouchProps.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.GroupBox_TouchProps.Controls.Add(Me.txt_MinVariation)
        Me.GroupBox_TouchProps.Controls.Add(Me.Label_ProportionalArea)
        Me.GroupBox_TouchProps.Controls.Add(Me.txt_ProportionalArea)
        Me.GroupBox_TouchProps.Controls.Add(Me.Label_MinVariation)
        Me.GroupBox_TouchProps.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_TouchProps.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox_TouchProps.Location = New System.Drawing.Point(236, 164)
        Me.GroupBox_TouchProps.Name = "GroupBox_TouchProps"
        Me.GroupBox_TouchProps.Size = New System.Drawing.Size(180, 71)
        Me.GroupBox_TouchProps.TabIndex = 179
        Me.GroupBox_TouchProps.TabStop = False
        Me.GroupBox_TouchProps.Text = "Touch properties"
        Me.GroupBox_TouchProps.Visible = False
        '
        'txt_MinVariation
        '
        Me.txt_MinVariation.ArrowsIncrement = 1
        Me.txt_MinVariation.BackColor = System.Drawing.Color.MintCream
        Me.txt_MinVariation.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_MinVariation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_MinVariation.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_MinVariation.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MinVariation.ForeColor = System.Drawing.Color.Black
        Me.txt_MinVariation.Increment = 0.2
        Me.txt_MinVariation.Location = New System.Drawing.Point(129, 25)
        Me.txt_MinVariation.MaxValue = 500
        Me.txt_MinVariation.MinValue = -1000
        Me.txt_MinVariation.Name = "txt_MinVariation"
        Me.txt_MinVariation.NumericValue = 10
        Me.txt_MinVariation.NumericValueInteger = 10
        Me.txt_MinVariation.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_MinVariation.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_MinVariation.RoundingStep = 0
        Me.txt_MinVariation.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_MinVariation.Size = New System.Drawing.Size(40, 15)
        Me.txt_MinVariation.SuppressZeros = True
        Me.txt_MinVariation.TabIndex = 17
        Me.txt_MinVariation.Text = "10"
        Me.txt_MinVariation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_ProportionalArea
        '
        Me.Label_ProportionalArea.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ProportionalArea.Location = New System.Drawing.Point(10, 47)
        Me.Label_ProportionalArea.Name = "Label_ProportionalArea"
        Me.Label_ProportionalArea.Size = New System.Drawing.Size(118, 13)
        Me.Label_ProportionalArea.TabIndex = 163
        Me.Label_ProportionalArea.Text = "Proportional area"
        Me.Label_ProportionalArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_ProportionalArea
        '
        Me.txt_ProportionalArea.ArrowsIncrement = 1
        Me.txt_ProportionalArea.BackColor = System.Drawing.Color.MintCream
        Me.txt_ProportionalArea.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_ProportionalArea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_ProportionalArea.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_ProportionalArea.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ProportionalArea.ForeColor = System.Drawing.Color.Black
        Me.txt_ProportionalArea.Increment = 0.2
        Me.txt_ProportionalArea.Location = New System.Drawing.Point(129, 46)
        Me.txt_ProportionalArea.MaxValue = 1000
        Me.txt_ProportionalArea.MinValue = -500
        Me.txt_ProportionalArea.Name = "txt_ProportionalArea"
        Me.txt_ProportionalArea.NumericValue = 0
        Me.txt_ProportionalArea.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_ProportionalArea.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_ProportionalArea.RoundingStep = 0
        Me.txt_ProportionalArea.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_ProportionalArea.Size = New System.Drawing.Size(40, 15)
        Me.txt_ProportionalArea.SuppressZeros = True
        Me.txt_ProportionalArea.TabIndex = 18
        Me.txt_ProportionalArea.Text = "0"
        Me.txt_ProportionalArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_MinVariation
        '
        Me.Label_MinVariation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MinVariation.Location = New System.Drawing.Point(10, 26)
        Me.Label_MinVariation.Name = "Label_MinVariation"
        Me.Label_MinVariation.Size = New System.Drawing.Size(118, 13)
        Me.Label_MinVariation.TabIndex = 161
        Me.Label_MinVariation.Text = "Min variation"
        Me.Label_MinVariation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton_Recognize, Me.ToolStripSeparator11, Me.ToolStripButton_Validate, Me.ToolStripSeparator3, Me.ToolStripButton_BeepOnErrors, Me.ToolStripSeparator8, Me.ToolStripButton_Lock, Me.ToolStripSeparator5, Me.ToolStripButton_Disconnect})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(624, 25)
        Me.ToolStrip1.TabIndex = 219
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton_Recognize
        '
        Me.ToolStripButton_Recognize.CheckOnClick = True
        Me.ToolStripButton_Recognize.Image = CType(resources.GetObject("ToolStripButton_Recognize.Image"), System.Drawing.Image)
        Me.ToolStripButton_Recognize.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Recognize.Name = "ToolStripButton_Recognize"
        Me.ToolStripButton_Recognize.Size = New System.Drawing.Size(81, 22)
        Me.ToolStripButton_Recognize.Text = "Recognize"
        Me.ToolStripButton_Recognize.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_Validate
        '
        Me.ToolStripButton_Validate.CheckOnClick = True
        Me.ToolStripButton_Validate.Image = CType(resources.GetObject("ToolStripButton_Validate.Image"), System.Drawing.Image)
        Me.ToolStripButton_Validate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Validate.Name = "ToolStripButton_Validate"
        Me.ToolStripButton_Validate.Size = New System.Drawing.Size(68, 22)
        Me.ToolStripButton_Validate.Text = "Validate"
        Me.ToolStripButton_Validate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_BeepOnErrors
        '
        Me.ToolStripButton_BeepOnErrors.CheckOnClick = True
        Me.ToolStripButton_BeepOnErrors.Image = CType(resources.GetObject("ToolStripButton_BeepOnErrors.Image"), System.Drawing.Image)
        Me.ToolStripButton_BeepOnErrors.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_BeepOnErrors.Name = "ToolStripButton_BeepOnErrors"
        Me.ToolStripButton_BeepOnErrors.Size = New System.Drawing.Size(81, 22)
        Me.ToolStripButton_BeepOnErrors.Text = "Error beep"
        Me.ToolStripButton_BeepOnErrors.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_Lock
        '
        Me.ToolStripButton_Lock.CheckOnClick = True
        Me.ToolStripButton_Lock.Image = CType(resources.GetObject("ToolStripButton_Lock.Image"), System.Drawing.Image)
        Me.ToolStripButton_Lock.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Lock.Name = "ToolStripButton_Lock"
        Me.ToolStripButton_Lock.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripButton_Lock.Text = "Lock Masters"
        Me.ToolStripButton_Lock.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton_Disconnect
        '
        Me.ToolStripButton_Disconnect.CheckOnClick = True
        Me.ToolStripButton_Disconnect.Image = CType(resources.GetObject("ToolStripButton_Disconnect.Image"), System.Drawing.Image)
        Me.ToolStripButton_Disconnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton_Disconnect.Name = "ToolStripButton_Disconnect"
        Me.ToolStripButton_Disconnect.Size = New System.Drawing.Size(125, 22)
        Me.ToolStripButton_Disconnect.Text = "Disconnect Master"
        Me.ToolStripButton_Disconnect.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_File, Me.Menu_Tools, Me.Menu_Language, Me.Menu_Help, Me.Menu_About})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(624, 24)
        Me.MenuStrip1.TabIndex = 218
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Menu_File
        '
        Me.Menu_File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_File_OpenProgramFolder, Me.Menu_File_EditSlotNames, Me.Menu_File_EditConfigurations, Me.ToolStripSeparator1, Me.Menu_File_BackupConfigurations, Me.Menu_File_LoadConfigurations, Me.ToolStripSeparator4, Me.Menu_File_Exit})
        Me.Menu_File.Name = "Menu_File"
        Me.Menu_File.Size = New System.Drawing.Size(37, 20)
        Me.Menu_File.Text = "File"
        '
        'Menu_File_OpenProgramFolder
        '
        Me.Menu_File_OpenProgramFolder.Image = CType(resources.GetObject("Menu_File_OpenProgramFolder.Image"), System.Drawing.Image)
        Me.Menu_File_OpenProgramFolder.Name = "Menu_File_OpenProgramFolder"
        Me.Menu_File_OpenProgramFolder.Size = New System.Drawing.Size(285, 22)
        Me.Menu_File_OpenProgramFolder.Text = "Open program folder"
        '
        'Menu_File_EditSlotNames
        '
        Me.Menu_File_EditSlotNames.Image = CType(resources.GetObject("Menu_File_EditSlotNames.Image"), System.Drawing.Image)
        Me.Menu_File_EditSlotNames.Name = "Menu_File_EditSlotNames"
        Me.Menu_File_EditSlotNames.Size = New System.Drawing.Size(285, 22)
        Me.Menu_File_EditSlotNames.Text = "Edit SlotNames"
        '
        'Menu_File_EditConfigurations
        '
        Me.Menu_File_EditConfigurations.Image = CType(resources.GetObject("Menu_File_EditConfigurations.Image"), System.Drawing.Image)
        Me.Menu_File_EditConfigurations.Name = "Menu_File_EditConfigurations"
        Me.Menu_File_EditConfigurations.Size = New System.Drawing.Size(285, 22)
        Me.Menu_File_EditConfigurations.Text = "Edit configurations"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(282, 6)
        '
        'Menu_File_BackupConfigurations
        '
        Me.Menu_File_BackupConfigurations.Image = CType(resources.GetObject("Menu_File_BackupConfigurations.Image"), System.Drawing.Image)
        Me.Menu_File_BackupConfigurations.Name = "Menu_File_BackupConfigurations"
        Me.Menu_File_BackupConfigurations.Size = New System.Drawing.Size(285, 22)
        Me.Menu_File_BackupConfigurations.Text = "Save configurations to backup folder"
        '
        'Menu_File_LoadConfigurations
        '
        Me.Menu_File_LoadConfigurations.Image = CType(resources.GetObject("Menu_File_LoadConfigurations.Image"), System.Drawing.Image)
        Me.Menu_File_LoadConfigurations.Name = "Menu_File_LoadConfigurations"
        Me.Menu_File_LoadConfigurations.Size = New System.Drawing.Size(285, 22)
        Me.Menu_File_LoadConfigurations.Text = "Load configurations from backup folder"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(282, 6)
        '
        'Menu_File_Exit
        '
        Me.Menu_File_Exit.Image = CType(resources.GetObject("Menu_File_Exit.Image"), System.Drawing.Image)
        Me.Menu_File_Exit.Name = "Menu_File_Exit"
        Me.Menu_File_Exit.Size = New System.Drawing.Size(285, 22)
        Me.Menu_File_Exit.Text = "Exit"
        '
        'Menu_Tools
        '
        Me.Menu_Tools.Enabled = False
        Me.Menu_Tools.Name = "Menu_Tools"
        Me.Menu_Tools.Size = New System.Drawing.Size(47, 20)
        Me.Menu_Tools.Text = "Tools"
        '
        'Menu_Language
        '
        Me.Menu_Language.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Language_English, Me.Menu_Language_Italian, Me.Menu_Language_Francais, Me.Menu_Language_Espanol, Me.Menu_Language_Portoguese, Me.Menu_Language_Deutsch, Me.Menu_Language_Japanese, Me.Menu_Language_Chinese})
        Me.Menu_Language.Name = "Menu_Language"
        Me.Menu_Language.Size = New System.Drawing.Size(71, 20)
        Me.Menu_Language.Text = "Language"
        '
        'Menu_Language_English
        '
        Me.Menu_Language_English.Image = CType(resources.GetObject("Menu_Language_English.Image"), System.Drawing.Image)
        Me.Menu_Language_English.Name = "Menu_Language_English"
        Me.Menu_Language_English.Size = New System.Drawing.Size(134, 22)
        Me.Menu_Language_English.Text = "English"
        '
        'Menu_Language_Italian
        '
        Me.Menu_Language_Italian.Image = CType(resources.GetObject("Menu_Language_Italian.Image"), System.Drawing.Image)
        Me.Menu_Language_Italian.Name = "Menu_Language_Italian"
        Me.Menu_Language_Italian.Size = New System.Drawing.Size(134, 22)
        Me.Menu_Language_Italian.Text = "Italiano"
        '
        'Menu_Language_Francais
        '
        Me.Menu_Language_Francais.Image = CType(resources.GetObject("Menu_Language_Francais.Image"), System.Drawing.Image)
        Me.Menu_Language_Francais.Name = "Menu_Language_Francais"
        Me.Menu_Language_Francais.Size = New System.Drawing.Size(134, 22)
        Me.Menu_Language_Francais.Text = "Francais"
        '
        'Menu_Language_Espanol
        '
        Me.Menu_Language_Espanol.Image = CType(resources.GetObject("Menu_Language_Espanol.Image"), System.Drawing.Image)
        Me.Menu_Language_Espanol.Name = "Menu_Language_Espanol"
        Me.Menu_Language_Espanol.Size = New System.Drawing.Size(134, 22)
        Me.Menu_Language_Espanol.Text = "Espanol"
        '
        'Menu_Language_Portoguese
        '
        Me.Menu_Language_Portoguese.Image = CType(resources.GetObject("Menu_Language_Portoguese.Image"), System.Drawing.Image)
        Me.Menu_Language_Portoguese.Name = "Menu_Language_Portoguese"
        Me.Menu_Language_Portoguese.Size = New System.Drawing.Size(134, 22)
        Me.Menu_Language_Portoguese.Text = "Portoguese"
        '
        'Menu_Language_Deutsch
        '
        Me.Menu_Language_Deutsch.Image = CType(resources.GetObject("Menu_Language_Deutsch.Image"), System.Drawing.Image)
        Me.Menu_Language_Deutsch.Name = "Menu_Language_Deutsch"
        Me.Menu_Language_Deutsch.Size = New System.Drawing.Size(134, 22)
        Me.Menu_Language_Deutsch.Text = "Deutsch"
        '
        'Menu_Language_Japanese
        '
        Me.Menu_Language_Japanese.Image = CType(resources.GetObject("Menu_Language_Japanese.Image"), System.Drawing.Image)
        Me.Menu_Language_Japanese.Name = "Menu_Language_Japanese"
        Me.Menu_Language_Japanese.Size = New System.Drawing.Size(134, 22)
        Me.Menu_Language_Japanese.Text = "Japanese"
        '
        'Menu_Language_Chinese
        '
        Me.Menu_Language_Chinese.Image = CType(resources.GetObject("Menu_Language_Chinese.Image"), System.Drawing.Image)
        Me.Menu_Language_Chinese.Name = "Menu_Language_Chinese"
        Me.Menu_Language_Chinese.Size = New System.Drawing.Size(134, 22)
        Me.Menu_Language_Chinese.Text = "Chinese"
        '
        'Menu_Help
        '
        Me.Menu_Help.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Menu_Help_ProgramHelp})
        Me.Menu_Help.Name = "Menu_Help"
        Me.Menu_Help.Size = New System.Drawing.Size(44, 20)
        Me.Menu_Help.Text = "Help"
        '
        'Menu_Help_ProgramHelp
        '
        Me.Menu_Help_ProgramHelp.Image = CType(resources.GetObject("Menu_Help_ProgramHelp.Image"), System.Drawing.Image)
        Me.Menu_Help_ProgramHelp.Name = "Menu_Help_ProgramHelp"
        Me.Menu_Help_ProgramHelp.Size = New System.Drawing.Size(146, 22)
        Me.Menu_Help_ProgramHelp.Text = "Program help"
        '
        'Menu_About
        '
        Me.Menu_About.Name = "Menu_About"
        Me.Menu_About.Size = New System.Drawing.Size(52, 20)
        Me.Menu_About.Text = "About"
        '
        'GroupBox_StepperProps
        '
        Me.GroupBox_StepperProps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_StepperProps.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.GroupBox_StepperProps.Controls.Add(Me.chk_LinkedToPrevious)
        Me.GroupBox_StepperProps.Controls.Add(Me.Label_StepsPerMillim)
        Me.GroupBox_StepperProps.Controls.Add(Me.txt_StepsPerMillim)
        Me.GroupBox_StepperProps.Controls.Add(Me.txt_MaxSpeed)
        Me.GroupBox_StepperProps.Controls.Add(Me.Label_MaxAcc)
        Me.GroupBox_StepperProps.Controls.Add(Me.txt_MaxAcc)
        Me.GroupBox_StepperProps.Controls.Add(Me.Label_MaxSpeed)
        Me.GroupBox_StepperProps.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_StepperProps.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox_StepperProps.Location = New System.Drawing.Point(28, 186)
        Me.GroupBox_StepperProps.Name = "GroupBox_StepperProps"
        Me.GroupBox_StepperProps.Size = New System.Drawing.Size(180, 106)
        Me.GroupBox_StepperProps.TabIndex = 220
        Me.GroupBox_StepperProps.TabStop = False
        Me.GroupBox_StepperProps.Text = "Stepper properties"
        Me.GroupBox_StepperProps.Visible = False
        '
        'chk_LinkedToPrevious
        '
        Me.chk_LinkedToPrevious.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_LinkedToPrevious.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_LinkedToPrevious.Location = New System.Drawing.Point(7, 85)
        Me.chk_LinkedToPrevious.Name = "chk_LinkedToPrevious"
        Me.chk_LinkedToPrevious.Size = New System.Drawing.Size(156, 17)
        Me.chk_LinkedToPrevious.TabIndex = 166
        Me.chk_LinkedToPrevious.Text = "Linked to previous"
        Me.chk_LinkedToPrevious.UseVisualStyleBackColor = True
        '
        'Label_StepsPerMillim
        '
        Me.Label_StepsPerMillim.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_StepsPerMillim.Location = New System.Drawing.Point(10, 66)
        Me.Label_StepsPerMillim.Name = "Label_StepsPerMillim"
        Me.Label_StepsPerMillim.Size = New System.Drawing.Size(101, 13)
        Me.Label_StepsPerMillim.TabIndex = 165
        Me.Label_StepsPerMillim.Text = "Steps per mm"
        Me.Label_StepsPerMillim.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_StepsPerMillim
        '
        Me.txt_StepsPerMillim.ArrowsIncrement = 1
        Me.txt_StepsPerMillim.BackColor = System.Drawing.Color.MintCream
        Me.txt_StepsPerMillim.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_StepsPerMillim.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_StepsPerMillim.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_StepsPerMillim.Decimals = 3
        Me.txt_StepsPerMillim.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_StepsPerMillim.ForeColor = System.Drawing.Color.Black
        Me.txt_StepsPerMillim.Increment = 0.002
        Me.txt_StepsPerMillim.Location = New System.Drawing.Point(111, 65)
        Me.txt_StepsPerMillim.MaxValue = 99999
        Me.txt_StepsPerMillim.MinValue = 0.01
        Me.txt_StepsPerMillim.Name = "txt_StepsPerMillim"
        Me.txt_StepsPerMillim.NumericValue = 400
        Me.txt_StepsPerMillim.NumericValueInteger = 400
        Me.txt_StepsPerMillim.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_StepsPerMillim.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_StepsPerMillim.RoundingStep = 0
        Me.txt_StepsPerMillim.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_StepsPerMillim.Size = New System.Drawing.Size(58, 15)
        Me.txt_StepsPerMillim.SuppressZeros = True
        Me.txt_StepsPerMillim.TabIndex = 164
        Me.txt_StepsPerMillim.Text = "400"
        Me.txt_StepsPerMillim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_MaxSpeed
        '
        Me.txt_MaxSpeed.ArrowsIncrement = 1
        Me.txt_MaxSpeed.BackColor = System.Drawing.Color.MintCream
        Me.txt_MaxSpeed.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_MaxSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_MaxSpeed.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_MaxSpeed.Decimals = 1
        Me.txt_MaxSpeed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MaxSpeed.ForeColor = System.Drawing.Color.Black
        Me.txt_MaxSpeed.Increment = 0.2
        Me.txt_MaxSpeed.Location = New System.Drawing.Point(129, 23)
        Me.txt_MaxSpeed.MaxValue = 99999
        Me.txt_MaxSpeed.MinValue = 1
        Me.txt_MaxSpeed.Name = "txt_MaxSpeed"
        Me.txt_MaxSpeed.NumericValue = 100
        Me.txt_MaxSpeed.NumericValueInteger = 100
        Me.txt_MaxSpeed.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_MaxSpeed.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_MaxSpeed.RoundingStep = 0
        Me.txt_MaxSpeed.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_MaxSpeed.Size = New System.Drawing.Size(40, 15)
        Me.txt_MaxSpeed.SuppressZeros = True
        Me.txt_MaxSpeed.TabIndex = 17
        Me.txt_MaxSpeed.Text = "100"
        Me.txt_MaxSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_MaxAcc
        '
        Me.Label_MaxAcc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MaxAcc.Location = New System.Drawing.Point(10, 45)
        Me.Label_MaxAcc.Name = "Label_MaxAcc"
        Me.Label_MaxAcc.Size = New System.Drawing.Size(118, 13)
        Me.Label_MaxAcc.TabIndex = 163
        Me.Label_MaxAcc.Text = "Max acc. (mm/s/s)"
        Me.Label_MaxAcc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_MaxAcc
        '
        Me.txt_MaxAcc.ArrowsIncrement = 1
        Me.txt_MaxAcc.BackColor = System.Drawing.Color.MintCream
        Me.txt_MaxAcc.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_MaxAcc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_MaxAcc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_MaxAcc.Decimals = 1
        Me.txt_MaxAcc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MaxAcc.ForeColor = System.Drawing.Color.Black
        Me.txt_MaxAcc.Increment = 0.2
        Me.txt_MaxAcc.Location = New System.Drawing.Point(129, 44)
        Me.txt_MaxAcc.MaxValue = 9999
        Me.txt_MaxAcc.MinValue = 5
        Me.txt_MaxAcc.Name = "txt_MaxAcc"
        Me.txt_MaxAcc.NumericValue = 10
        Me.txt_MaxAcc.NumericValueInteger = 10
        Me.txt_MaxAcc.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_MaxAcc.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_MaxAcc.RoundingStep = 0
        Me.txt_MaxAcc.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_MaxAcc.Size = New System.Drawing.Size(40, 15)
        Me.txt_MaxAcc.SuppressZeros = True
        Me.txt_MaxAcc.TabIndex = 18
        Me.txt_MaxAcc.Text = "10"
        Me.txt_MaxAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_MaxSpeed
        '
        Me.Label_MaxSpeed.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_MaxSpeed.Location = New System.Drawing.Point(10, 24)
        Me.Label_MaxSpeed.Name = "Label_MaxSpeed"
        Me.Label_MaxSpeed.Size = New System.Drawing.Size(118, 13)
        Me.Label_MaxSpeed.TabIndex = 161
        Me.Label_MaxSpeed.Text = "Max sp. (mm/min)"
        Me.Label_MaxSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox_PwmFastProps
        '
        Me.GroupBox_PwmFastProps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_PwmFastProps.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.GroupBox_PwmFastProps.Controls.Add(Me.chk_DutyCycleFromSlot)
        Me.GroupBox_PwmFastProps.Controls.Add(Me.chk_FrequencyFromSlot)
        Me.GroupBox_PwmFastProps.Controls.Add(Me.txt_PwmFastFrequency)
        Me.GroupBox_PwmFastProps.Controls.Add(Me.Label_PwmFastDutyCycle)
        Me.GroupBox_PwmFastProps.Controls.Add(Me.txt_PwmFastDutyCycle)
        Me.GroupBox_PwmFastProps.Controls.Add(Me.Label_PwmFastFrequency)
        Me.GroupBox_PwmFastProps.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_PwmFastProps.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox_PwmFastProps.Location = New System.Drawing.Point(28, 304)
        Me.GroupBox_PwmFastProps.Name = "GroupBox_PwmFastProps"
        Me.GroupBox_PwmFastProps.Size = New System.Drawing.Size(180, 106)
        Me.GroupBox_PwmFastProps.TabIndex = 221
        Me.GroupBox_PwmFastProps.TabStop = False
        Me.GroupBox_PwmFastProps.Text = "Pwm_Fast properties"
        Me.GroupBox_PwmFastProps.Visible = False
        '
        'chk_DutyCycleFromSlot
        '
        Me.chk_DutyCycleFromSlot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_DutyCycleFromSlot.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_DutyCycleFromSlot.Location = New System.Drawing.Point(9, 83)
        Me.chk_DutyCycleFromSlot.Name = "chk_DutyCycleFromSlot"
        Me.chk_DutyCycleFromSlot.Size = New System.Drawing.Size(156, 17)
        Me.chk_DutyCycleFromSlot.TabIndex = 167
        Me.chk_DutyCycleFromSlot.Text = "Duty cycle from slot"
        Me.chk_DutyCycleFromSlot.UseVisualStyleBackColor = True
        '
        'chk_FrequencyFromSlot
        '
        Me.chk_FrequencyFromSlot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_FrequencyFromSlot.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_FrequencyFromSlot.Location = New System.Drawing.Point(9, 65)
        Me.chk_FrequencyFromSlot.Name = "chk_FrequencyFromSlot"
        Me.chk_FrequencyFromSlot.Size = New System.Drawing.Size(156, 17)
        Me.chk_FrequencyFromSlot.TabIndex = 166
        Me.chk_FrequencyFromSlot.Text = "Frequency from slot"
        Me.chk_FrequencyFromSlot.UseVisualStyleBackColor = True
        '
        'txt_PwmFastFrequency
        '
        Me.txt_PwmFastFrequency.ArrowsIncrement = 1
        Me.txt_PwmFastFrequency.BackColor = System.Drawing.Color.MintCream
        Me.txt_PwmFastFrequency.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_PwmFastFrequency.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_PwmFastFrequency.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_PwmFastFrequency.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PwmFastFrequency.ForeColor = System.Drawing.Color.Black
        Me.txt_PwmFastFrequency.Increment = 0.2
        Me.txt_PwmFastFrequency.Location = New System.Drawing.Point(107, 23)
        Me.txt_PwmFastFrequency.MaxValue = 5300000
        Me.txt_PwmFastFrequency.MinValue = 245
        Me.txt_PwmFastFrequency.Name = "txt_PwmFastFrequency"
        Me.txt_PwmFastFrequency.NumericValue = 1000
        Me.txt_PwmFastFrequency.NumericValueInteger = 1000
        Me.txt_PwmFastFrequency.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_PwmFastFrequency.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_PwmFastFrequency.RoundingStep = 0
        Me.txt_PwmFastFrequency.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_PwmFastFrequency.Size = New System.Drawing.Size(62, 15)
        Me.txt_PwmFastFrequency.SuppressZeros = True
        Me.txt_PwmFastFrequency.TabIndex = 17
        Me.txt_PwmFastFrequency.Text = "1000"
        Me.txt_PwmFastFrequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_PwmFastDutyCycle
        '
        Me.Label_PwmFastDutyCycle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PwmFastDutyCycle.Location = New System.Drawing.Point(10, 45)
        Me.Label_PwmFastDutyCycle.Name = "Label_PwmFastDutyCycle"
        Me.Label_PwmFastDutyCycle.Size = New System.Drawing.Size(118, 13)
        Me.Label_PwmFastDutyCycle.TabIndex = 163
        Me.Label_PwmFastDutyCycle.Text = "Duty cycle 0-1000"
        Me.Label_PwmFastDutyCycle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_PwmFastDutyCycle
        '
        Me.txt_PwmFastDutyCycle.ArrowsIncrement = 1
        Me.txt_PwmFastDutyCycle.BackColor = System.Drawing.Color.MintCream
        Me.txt_PwmFastDutyCycle.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_PwmFastDutyCycle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_PwmFastDutyCycle.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_PwmFastDutyCycle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PwmFastDutyCycle.ForeColor = System.Drawing.Color.Black
        Me.txt_PwmFastDutyCycle.Increment = 0.2
        Me.txt_PwmFastDutyCycle.Location = New System.Drawing.Point(129, 44)
        Me.txt_PwmFastDutyCycle.MaxValue = 1000
        Me.txt_PwmFastDutyCycle.MinValue = 0
        Me.txt_PwmFastDutyCycle.Name = "txt_PwmFastDutyCycle"
        Me.txt_PwmFastDutyCycle.NumericValue = 500
        Me.txt_PwmFastDutyCycle.NumericValueInteger = 500
        Me.txt_PwmFastDutyCycle.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_PwmFastDutyCycle.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_PwmFastDutyCycle.RoundingStep = 0
        Me.txt_PwmFastDutyCycle.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_PwmFastDutyCycle.Size = New System.Drawing.Size(40, 15)
        Me.txt_PwmFastDutyCycle.SuppressZeros = True
        Me.txt_PwmFastDutyCycle.TabIndex = 18
        Me.txt_PwmFastDutyCycle.Text = "500"
        Me.txt_PwmFastDutyCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_PwmFastFrequency
        '
        Me.Label_PwmFastFrequency.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_PwmFastFrequency.Location = New System.Drawing.Point(10, 24)
        Me.Label_PwmFastFrequency.Name = "Label_PwmFastFrequency"
        Me.Label_PwmFastFrequency.Size = New System.Drawing.Size(94, 13)
        Me.Label_PwmFastFrequency.TabIndex = 161
        Me.Label_PwmFastFrequency.Text = "Frequency (Hz)"
        Me.Label_PwmFastFrequency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox_Adc24Props
        '
        Me.GroupBox_Adc24Props.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_Adc24Props.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.GroupBox_Adc24Props.Controls.Add(Me.cmb_Adc24Sps)
        Me.GroupBox_Adc24Props.Controls.Add(Me.cmb_Adc24Filter)
        Me.GroupBox_Adc24Props.Controls.Add(Me.Label_Adc24Filter)
        Me.GroupBox_Adc24Props.Controls.Add(Me.txt_NumberOfPins)
        Me.GroupBox_Adc24Props.Controls.Add(Me.Label_SamplesPerSec)
        Me.GroupBox_Adc24Props.Controls.Add(Me.Label_NumberOfPins)
        Me.GroupBox_Adc24Props.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_Adc24Props.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox_Adc24Props.Location = New System.Drawing.Point(29, 67)
        Me.GroupBox_Adc24Props.Name = "GroupBox_Adc24Props"
        Me.GroupBox_Adc24Props.Size = New System.Drawing.Size(180, 98)
        Me.GroupBox_Adc24Props.TabIndex = 223
        Me.GroupBox_Adc24Props.TabStop = False
        Me.GroupBox_Adc24Props.Text = "Adc24 properties"
        Me.GroupBox_Adc24Props.Visible = False
        '
        'cmb_Adc24Sps
        '
        Me.cmb_Adc24Sps.ArrowButtonColor = System.Drawing.Color.Transparent
        Me.cmb_Adc24Sps.ArrowColor = System.Drawing.Color.Transparent
        Me.cmb_Adc24Sps.BackColor = System.Drawing.Color.MintCream
        Me.cmb_Adc24Sps.BackColor_Focused = System.Drawing.Color.MintCream
        Me.cmb_Adc24Sps.BackColor_Over = System.Drawing.Color.Moccasin
        Me.cmb_Adc24Sps.BorderColor = System.Drawing.Color.PowderBlue
        Me.cmb_Adc24Sps.BorderSize = 1
        Me.cmb_Adc24Sps.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmb_Adc24Sps.DropDown_BackColor = System.Drawing.Color.AliceBlue
        Me.cmb_Adc24Sps.DropDown_BackSelected = System.Drawing.Color.LightBlue
        Me.cmb_Adc24Sps.DropDown_BorderColor = System.Drawing.Color.Gainsboro
        Me.cmb_Adc24Sps.DropDown_ForeColor = System.Drawing.Color.Black
        Me.cmb_Adc24Sps.DropDown_ForeSelected = System.Drawing.Color.Black
        Me.cmb_Adc24Sps.DropDownHeight = 500
        Me.cmb_Adc24Sps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Adc24Sps.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Adc24Sps.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Adc24Sps.ForeColor = System.Drawing.Color.Black
        Me.cmb_Adc24Sps.IntegralHeight = False
        Me.cmb_Adc24Sps.ItemHeight = 12
        Me.cmb_Adc24Sps.Items.AddRange(New Object() {"19200", "9600", "4800", "3840", "3200", "2400", "1600", "1200", "1000", "600", "500", "300", "200", "120", "100", "60", "50", "30", "20", "12", "10"})
        Me.cmb_Adc24Sps.Location = New System.Drawing.Point(114, 44)
        Me.cmb_Adc24Sps.Name = "cmb_Adc24Sps"
        Me.cmb_Adc24Sps.ShadowColor = System.Drawing.Color.Transparent
        Me.cmb_Adc24Sps.Size = New System.Drawing.Size(55, 18)
        Me.cmb_Adc24Sps.TabIndex = 169
        Me.cmb_Adc24Sps.TabStop = False
        Me.cmb_Adc24Sps.TextPosition = 1
        '
        'cmb_Adc24Filter
        '
        Me.cmb_Adc24Filter.ArrowButtonColor = System.Drawing.Color.Transparent
        Me.cmb_Adc24Filter.ArrowColor = System.Drawing.Color.Transparent
        Me.cmb_Adc24Filter.BackColor = System.Drawing.Color.MintCream
        Me.cmb_Adc24Filter.BackColor_Focused = System.Drawing.Color.MintCream
        Me.cmb_Adc24Filter.BackColor_Over = System.Drawing.Color.Moccasin
        Me.cmb_Adc24Filter.BorderColor = System.Drawing.Color.PowderBlue
        Me.cmb_Adc24Filter.BorderSize = 1
        Me.cmb_Adc24Filter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmb_Adc24Filter.DropDown_BackColor = System.Drawing.Color.AliceBlue
        Me.cmb_Adc24Filter.DropDown_BackSelected = System.Drawing.Color.LightBlue
        Me.cmb_Adc24Filter.DropDown_BorderColor = System.Drawing.Color.Gainsboro
        Me.cmb_Adc24Filter.DropDown_ForeColor = System.Drawing.Color.Black
        Me.cmb_Adc24Filter.DropDown_ForeSelected = System.Drawing.Color.Black
        Me.cmb_Adc24Filter.DropDownHeight = 500
        Me.cmb_Adc24Filter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Adc24Filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Adc24Filter.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Adc24Filter.ForeColor = System.Drawing.Color.Black
        Me.cmb_Adc24Filter.IntegralHeight = False
        Me.cmb_Adc24Filter.ItemHeight = 12
        Me.cmb_Adc24Filter.Items.AddRange(New Object() {"Max Speed", "Fast", "Medium", "Slow", "Post Max", "Post Fast", "Post Medium", "Post Slow"})
        Me.cmb_Adc24Filter.Location = New System.Drawing.Point(85, 68)
        Me.cmb_Adc24Filter.Name = "cmb_Adc24Filter"
        Me.cmb_Adc24Filter.ShadowColor = System.Drawing.Color.Transparent
        Me.cmb_Adc24Filter.Size = New System.Drawing.Size(84, 18)
        Me.cmb_Adc24Filter.TabIndex = 168
        Me.cmb_Adc24Filter.TabStop = False
        Me.cmb_Adc24Filter.TextPosition = 1
        '
        'Label_Adc24Filter
        '
        Me.Label_Adc24Filter.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Adc24Filter.Location = New System.Drawing.Point(11, 70)
        Me.Label_Adc24Filter.Name = "Label_Adc24Filter"
        Me.Label_Adc24Filter.Size = New System.Drawing.Size(55, 13)
        Me.Label_Adc24Filter.TabIndex = 167
        Me.Label_Adc24Filter.Text = "Filter"
        Me.Label_Adc24Filter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txt_NumberOfPins
        '
        Me.txt_NumberOfPins.ArrowsIncrement = 1
        Me.txt_NumberOfPins.BackColor = System.Drawing.Color.MintCream
        Me.txt_NumberOfPins.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_NumberOfPins.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_NumberOfPins.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_NumberOfPins.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NumberOfPins.ForeColor = System.Drawing.Color.Black
        Me.txt_NumberOfPins.Increment = 0.2
        Me.txt_NumberOfPins.Location = New System.Drawing.Point(128, 23)
        Me.txt_NumberOfPins.MaxValue = 16
        Me.txt_NumberOfPins.MinValue = 0
        Me.txt_NumberOfPins.Name = "txt_NumberOfPins"
        Me.txt_NumberOfPins.NumericValue = 16
        Me.txt_NumberOfPins.NumericValueInteger = 16
        Me.txt_NumberOfPins.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_NumberOfPins.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_NumberOfPins.RoundingStep = 0
        Me.txt_NumberOfPins.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_NumberOfPins.Size = New System.Drawing.Size(41, 15)
        Me.txt_NumberOfPins.SuppressZeros = True
        Me.txt_NumberOfPins.TabIndex = 17
        Me.txt_NumberOfPins.Text = "16"
        Me.txt_NumberOfPins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label_SamplesPerSec
        '
        Me.Label_SamplesPerSec.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_SamplesPerSec.Location = New System.Drawing.Point(10, 45)
        Me.Label_SamplesPerSec.Name = "Label_SamplesPerSec"
        Me.Label_SamplesPerSec.Size = New System.Drawing.Size(89, 13)
        Me.Label_SamplesPerSec.TabIndex = 163
        Me.Label_SamplesPerSec.Text = "Samples/sec."
        Me.Label_SamplesPerSec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_NumberOfPins
        '
        Me.Label_NumberOfPins.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_NumberOfPins.Location = New System.Drawing.Point(10, 24)
        Me.Label_NumberOfPins.Name = "Label_NumberOfPins"
        Me.Label_NumberOfPins.Size = New System.Drawing.Size(94, 13)
        Me.Label_NumberOfPins.TabIndex = 161
        Me.Label_NumberOfPins.Text = "Number of pins"
        Me.Label_NumberOfPins.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox_Adc24ChProps
        '
        Me.GroupBox_Adc24ChProps.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_Adc24ChProps.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.GroupBox_Adc24ChProps.Controls.Add(Me.cmb_Adc24ChGain)
        Me.GroupBox_Adc24ChProps.Controls.Add(Me.cmb_Adc24ChType)
        Me.GroupBox_Adc24ChProps.Controls.Add(Me.chk_Adc24ChBiased)
        Me.GroupBox_Adc24ChProps.Controls.Add(Me.Label_Adc24ChGain)
        Me.GroupBox_Adc24ChProps.Controls.Add(Me.Label_Adc24ChType)
        Me.GroupBox_Adc24ChProps.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_Adc24ChProps.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.GroupBox_Adc24ChProps.Location = New System.Drawing.Point(236, 65)
        Me.GroupBox_Adc24ChProps.Name = "GroupBox_Adc24ChProps"
        Me.GroupBox_Adc24ChProps.Size = New System.Drawing.Size(180, 92)
        Me.GroupBox_Adc24ChProps.TabIndex = 224
        Me.GroupBox_Adc24ChProps.TabStop = False
        Me.GroupBox_Adc24ChProps.Text = "Adc24_channel props"
        Me.GroupBox_Adc24ChProps.Visible = False
        '
        'cmb_Adc24ChGain
        '
        Me.cmb_Adc24ChGain.ArrowButtonColor = System.Drawing.Color.Transparent
        Me.cmb_Adc24ChGain.ArrowColor = System.Drawing.Color.Transparent
        Me.cmb_Adc24ChGain.BackColor = System.Drawing.Color.MintCream
        Me.cmb_Adc24ChGain.BackColor_Focused = System.Drawing.Color.MintCream
        Me.cmb_Adc24ChGain.BackColor_Over = System.Drawing.Color.Moccasin
        Me.cmb_Adc24ChGain.BorderColor = System.Drawing.Color.PowderBlue
        Me.cmb_Adc24ChGain.BorderSize = 1
        Me.cmb_Adc24ChGain.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmb_Adc24ChGain.DropDown_BackColor = System.Drawing.Color.AliceBlue
        Me.cmb_Adc24ChGain.DropDown_BackSelected = System.Drawing.Color.LightBlue
        Me.cmb_Adc24ChGain.DropDown_BorderColor = System.Drawing.Color.Gainsboro
        Me.cmb_Adc24ChGain.DropDown_ForeColor = System.Drawing.Color.Black
        Me.cmb_Adc24ChGain.DropDown_ForeSelected = System.Drawing.Color.Black
        Me.cmb_Adc24ChGain.DropDownHeight = 500
        Me.cmb_Adc24ChGain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Adc24ChGain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Adc24ChGain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Adc24ChGain.ForeColor = System.Drawing.Color.Black
        Me.cmb_Adc24ChGain.IntegralHeight = False
        Me.cmb_Adc24ChGain.ItemHeight = 12
        Me.cmb_Adc24ChGain.Items.AddRange(New Object() {"1", "2", "4", "8", "16", "32", "64", "128"})
        Me.cmb_Adc24ChGain.Location = New System.Drawing.Point(115, 46)
        Me.cmb_Adc24ChGain.Name = "cmb_Adc24ChGain"
        Me.cmb_Adc24ChGain.ShadowColor = System.Drawing.Color.Transparent
        Me.cmb_Adc24ChGain.Size = New System.Drawing.Size(59, 18)
        Me.cmb_Adc24ChGain.TabIndex = 167
        Me.cmb_Adc24ChGain.TabStop = False
        Me.cmb_Adc24ChGain.TextPosition = 1
        '
        'cmb_Adc24ChType
        '
        Me.cmb_Adc24ChType.ArrowButtonColor = System.Drawing.Color.Transparent
        Me.cmb_Adc24ChType.ArrowColor = System.Drawing.Color.Transparent
        Me.cmb_Adc24ChType.BackColor = System.Drawing.Color.MintCream
        Me.cmb_Adc24ChType.BackColor_Focused = System.Drawing.Color.MintCream
        Me.cmb_Adc24ChType.BackColor_Over = System.Drawing.Color.Moccasin
        Me.cmb_Adc24ChType.BorderColor = System.Drawing.Color.PowderBlue
        Me.cmb_Adc24ChType.BorderSize = 1
        Me.cmb_Adc24ChType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmb_Adc24ChType.DropDown_BackColor = System.Drawing.Color.AliceBlue
        Me.cmb_Adc24ChType.DropDown_BackSelected = System.Drawing.Color.LightBlue
        Me.cmb_Adc24ChType.DropDown_BorderColor = System.Drawing.Color.Gainsboro
        Me.cmb_Adc24ChType.DropDown_ForeColor = System.Drawing.Color.Black
        Me.cmb_Adc24ChType.DropDown_ForeSelected = System.Drawing.Color.Black
        Me.cmb_Adc24ChType.DropDownHeight = 500
        Me.cmb_Adc24ChType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Adc24ChType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmb_Adc24ChType.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmb_Adc24ChType.ForeColor = System.Drawing.Color.Black
        Me.cmb_Adc24ChType.IntegralHeight = False
        Me.cmb_Adc24ChType.ItemHeight = 12
        Me.cmb_Adc24ChType.Items.AddRange(New Object() {"Differential", "Pseudo Diff", "Single ended"})
        Me.cmb_Adc24ChType.Location = New System.Drawing.Point(88, 25)
        Me.cmb_Adc24ChType.Name = "cmb_Adc24ChType"
        Me.cmb_Adc24ChType.ShadowColor = System.Drawing.Color.Transparent
        Me.cmb_Adc24ChType.Size = New System.Drawing.Size(86, 18)
        Me.cmb_Adc24ChType.TabIndex = 166
        Me.cmb_Adc24ChType.TabStop = False
        Me.cmb_Adc24ChType.TextPosition = 1
        '
        'chk_Adc24ChBiased
        '
        Me.chk_Adc24ChBiased.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chk_Adc24ChBiased.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_Adc24ChBiased.Location = New System.Drawing.Point(10, 69)
        Me.chk_Adc24ChBiased.Name = "chk_Adc24ChBiased"
        Me.chk_Adc24ChBiased.Size = New System.Drawing.Size(156, 17)
        Me.chk_Adc24ChBiased.TabIndex = 165
        Me.chk_Adc24ChBiased.Text = "Biased to Vmax / 2"
        Me.chk_Adc24ChBiased.UseVisualStyleBackColor = True
        '
        'Label_Adc24ChGain
        '
        Me.Label_Adc24ChGain.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Adc24ChGain.Location = New System.Drawing.Point(10, 47)
        Me.Label_Adc24ChGain.Name = "Label_Adc24ChGain"
        Me.Label_Adc24ChGain.Size = New System.Drawing.Size(72, 13)
        Me.Label_Adc24ChGain.TabIndex = 163
        Me.Label_Adc24ChGain.Text = "Gain"
        Me.Label_Adc24ChGain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label_Adc24ChType
        '
        Me.Label_Adc24ChType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_Adc24ChType.Location = New System.Drawing.Point(10, 26)
        Me.Label_Adc24ChType.Name = "Label_Adc24ChType"
        Me.Label_Adc24ChType.Size = New System.Drawing.Size(72, 13)
        Me.Label_Adc24ChType.TabIndex = 161
        Me.Label_Adc24ChType.Text = "Type"
        Me.Label_Adc24ChType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer_60Hz
        '
        Me.Timer_60Hz.Interval = 10
        '
        'btn_Reconnect
        '
        Me.btn_Reconnect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Reconnect.BackColor = System.Drawing.Color.LightBlue
        Me.btn_Reconnect.BorderColor = System.Drawing.Color.DarkGray
        DesignerRectTracker5.IsActive = False
        DesignerRectTracker5.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker5.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btn_Reconnect.CenterPtTracker = DesignerRectTracker5
        Me.btn_Reconnect.CheckButton = True
        CBlendItems5.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(255, Byte), Integer))}
        CBlendItems5.iPoint = New Single() {0.0!, 1.0!}
        Me.btn_Reconnect.ColorFillBlend = CBlendItems5
        CBlendItems6.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(190, Byte), Integer))}
        CBlendItems6.iPoint = New Single() {0.0!, 0.3309608!, 1.0!}
        Me.btn_Reconnect.ColorFillBlendChecked = CBlendItems6
        Me.btn_Reconnect.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btn_Reconnect.ColorFillSolidChecked = System.Drawing.SystemColors.Control
        Me.btn_Reconnect.Corners.All = CType(0, Short)
        Me.btn_Reconnect.Corners.LowerLeft = CType(0, Short)
        Me.btn_Reconnect.Corners.LowerRight = CType(0, Short)
        Me.btn_Reconnect.Corners.UpperLeft = CType(0, Short)
        Me.btn_Reconnect.Corners.UpperRight = CType(0, Short)
        Me.btn_Reconnect.DimFactorGray = -10
        Me.btn_Reconnect.DimFactorOver = 30
        Me.btn_Reconnect.FillType = Theremino_HAL.MyButton.eFillType.LinearVertical
        Me.btn_Reconnect.FillTypeChecked = Theremino_HAL.MyButton.eFillType.LinearVertical
        Me.btn_Reconnect.FocalPoints.CenterPtX = 1.0!
        Me.btn_Reconnect.FocalPoints.CenterPtY = 0.2962963!
        Me.btn_Reconnect.FocalPoints.FocusPtX = 0.0!
        Me.btn_Reconnect.FocalPoints.FocusPtY = 0.0!
        Me.btn_Reconnect.FocalPointsChecked.CenterPtX = 0.5!
        Me.btn_Reconnect.FocalPointsChecked.CenterPtY = 0.5!
        Me.btn_Reconnect.FocalPointsChecked.FocusPtX = 0.0!
        Me.btn_Reconnect.FocalPointsChecked.FocusPtY = 0.0!
        DesignerRectTracker6.IsActive = False
        DesignerRectTracker6.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker6.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btn_Reconnect.FocusPtTracker = DesignerRectTracker6
        Me.btn_Reconnect.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Reconnect.ForeColorChecked = System.Drawing.Color.Black
        Me.btn_Reconnect.Image = Nothing
        Me.btn_Reconnect.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_Reconnect.ImageIndex = 0
        Me.btn_Reconnect.ImageSize = New System.Drawing.Size(16, 16)
        Me.btn_Reconnect.Location = New System.Drawing.Point(409, 0)
        Me.btn_Reconnect.Name = "btn_Reconnect"
        Me.btn_Reconnect.Shape = Theremino_HAL.MyButton.eShape.Rectangle
        Me.btn_Reconnect.SideImage = Nothing
        Me.btn_Reconnect.SideImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_Reconnect.SideImageSize = New System.Drawing.Size(32, 32)
        Me.btn_Reconnect.Size = New System.Drawing.Size(107, 22)
        Me.btn_Reconnect.TabIndex = 222
        Me.btn_Reconnect.TabStop = False
        Me.btn_Reconnect.Text = "Auto reconnect"
        Me.btn_Reconnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_Reconnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Reconnect.TextMargin = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.btn_Reconnect.TextShadow = System.Drawing.Color.Transparent
        Me.btn_Reconnect.TextShadowChecked = System.Drawing.Color.Transparent
        Me.btn_Reconnect.Visible = False
        '
        'txt_MinChange
        '
        Me.txt_MinChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_MinChange.ArrowsIncrement = 1
        Me.txt_MinChange.BackColor = System.Drawing.Color.OldLace
        Me.txt_MinChange.BackColor_Over = System.Drawing.Color.Moccasin
        Me.txt_MinChange.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_MinChange.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txt_MinChange.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MinChange.ForeColor = System.Drawing.Color.Black
        Me.txt_MinChange.Increment = 0.2
        Me.txt_MinChange.Location = New System.Drawing.Point(586, 2)
        Me.txt_MinChange.MaxValue = 100
        Me.txt_MinChange.MinValue = 0
        Me.txt_MinChange.Name = "txt_MinChange"
        Me.txt_MinChange.NumericValue = 30
        Me.txt_MinChange.NumericValueInteger = 30
        Me.txt_MinChange.RectangleColor = System.Drawing.Color.PowderBlue
        Me.txt_MinChange.RectangleStyle = System.Windows.Forms.ButtonBorderStyle.Dashed
        Me.txt_MinChange.RoundingStep = 0
        Me.txt_MinChange.ShadowColor = System.Drawing.Color.LightGray
        Me.txt_MinChange.Size = New System.Drawing.Size(33, 13)
        Me.txt_MinChange.SuppressZeros = True
        Me.txt_MinChange.TabIndex = 90
        Me.txt_MinChange.Text = "30"
        Me.txt_MinChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_Calibrate
        '
        Me.btn_Calibrate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_Calibrate.BackColor = System.Drawing.Color.LightBlue
        Me.btn_Calibrate.BorderColor = System.Drawing.Color.DarkGray
        DesignerRectTracker7.IsActive = False
        DesignerRectTracker7.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker7.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btn_Calibrate.CenterPtTracker = DesignerRectTracker7
        CBlendItems7.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(255, Byte), Integer))}
        CBlendItems7.iPoint = New Single() {0.0!, 1.0!}
        Me.btn_Calibrate.ColorFillBlend = CBlendItems7
        CBlendItems8.iColor = New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))}
        CBlendItems8.iPoint = New Single() {0.0!, 0.3309608!, 1.0!}
        Me.btn_Calibrate.ColorFillBlendChecked = CBlendItems8
        Me.btn_Calibrate.ColorFillSolid = System.Drawing.SystemColors.Control
        Me.btn_Calibrate.ColorFillSolidChecked = System.Drawing.SystemColors.Control
        Me.btn_Calibrate.Corners.All = CType(0, Short)
        Me.btn_Calibrate.Corners.LowerLeft = CType(0, Short)
        Me.btn_Calibrate.Corners.LowerRight = CType(0, Short)
        Me.btn_Calibrate.Corners.UpperLeft = CType(0, Short)
        Me.btn_Calibrate.Corners.UpperRight = CType(0, Short)
        Me.btn_Calibrate.DimFactorGray = -10
        Me.btn_Calibrate.DimFactorOver = 30
        Me.btn_Calibrate.FillType = Theremino_HAL.MyButton.eFillType.LinearVertical
        Me.btn_Calibrate.FillTypeChecked = Theremino_HAL.MyButton.eFillType.LinearVertical
        Me.btn_Calibrate.FocalPoints.CenterPtX = 1.0!
        Me.btn_Calibrate.FocalPoints.CenterPtY = 0.2962963!
        Me.btn_Calibrate.FocalPoints.FocusPtX = 0.0!
        Me.btn_Calibrate.FocalPoints.FocusPtY = 0.0!
        Me.btn_Calibrate.FocalPointsChecked.CenterPtX = 0.5!
        Me.btn_Calibrate.FocalPointsChecked.CenterPtY = 0.5!
        Me.btn_Calibrate.FocalPointsChecked.FocusPtX = 0.0!
        Me.btn_Calibrate.FocalPointsChecked.FocusPtY = 0.0!
        DesignerRectTracker8.IsActive = False
        DesignerRectTracker8.TrackerRectangle = CType(resources.GetObject("DesignerRectTracker8.TrackerRectangle"), System.Drawing.RectangleF)
        Me.btn_Calibrate.FocusPtTracker = DesignerRectTracker8
        Me.btn_Calibrate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Calibrate.Image = Nothing
        Me.btn_Calibrate.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_Calibrate.ImageIndex = 0
        Me.btn_Calibrate.ImageSize = New System.Drawing.Size(16, 16)
        Me.btn_Calibrate.Location = New System.Drawing.Point(518, 0)
        Me.btn_Calibrate.Name = "btn_Calibrate"
        Me.btn_Calibrate.Shape = Theremino_HAL.MyButton.eShape.Rectangle
        Me.btn_Calibrate.SideImage = Nothing
        Me.btn_Calibrate.SideImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_Calibrate.SideImageSize = New System.Drawing.Size(32, 32)
        Me.btn_Calibrate.Size = New System.Drawing.Size(106, 22)
        Me.btn_Calibrate.TabIndex = 32
        Me.btn_Calibrate.TabStop = False
        Me.btn_Calibrate.Text = "Calibrate"
        Me.btn_Calibrate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_Calibrate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btn_Calibrate.TextMargin = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btn_Calibrate.TextShadow = System.Drawing.Color.Transparent
        '
        'MyListView1
        '
        Me.MyListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MyListView1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MyListView1.Location = New System.Drawing.Point(4, 52)
        Me.MyListView1.MultiSelect = False
        Me.MyListView1.Name = "MyListView1"
        Me.MyListView1.ShowGroups = False
        Me.MyListView1.Size = New System.Drawing.Size(430, 386)
        Me.MyListView1.TabIndex = 100
        Me.MyListView1.TabStop = False
        Me.MyListView1.UseCompatibleStateImageBehavior = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(624, 441)
        Me.Controls.Add(Me.GroupBox_Adc24ChProps)
        Me.Controls.Add(Me.GroupBox_Adc24Props)
        Me.Controls.Add(Me.btn_Reconnect)
        Me.Controls.Add(Me.GroupBox_PwmFastProps)
        Me.Controls.Add(Me.GroupBox_StepperProps)
        Me.Controls.Add(Me.txt_MinChange)
        Me.Controls.Add(Me.Pic_CalibrateTime)
        Me.Controls.Add(Me.btn_Calibrate)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox_TouchProps)
        Me.Controls.Add(Me.GroupBox_FrequencyProps)
        Me.Controls.Add(Me.GroupBox_ServoPwmProps)
        Me.Controls.Add(Me.MyListView1)
        Me.Controls.Add(Me.GroupBox_CapSensorProps)
        Me.Controls.Add(Me.GroupBox_PinProps)
        Me.Controls.Add(Me.GroupBox_MasterProps)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "Form1"
        Me.Opacity = 0
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Theremino HAL"
        Me.GroupBox_MasterProps.ResumeLayout(False)
        Me.GroupBox_MasterProps.PerformLayout()
        Me.GroupBox_PinProps.ResumeLayout(False)
        Me.GroupBox_PinProps.PerformLayout()
        Me.GroupBox_CapSensorProps.ResumeLayout(False)
        Me.GroupBox_CapSensorProps.PerformLayout()
        CType(Me.Pic_CalibrateTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox_ServoPwmProps.ResumeLayout(False)
        Me.GroupBox_ServoPwmProps.PerformLayout()
        Me.GroupBox_FrequencyProps.ResumeLayout(False)
        Me.GroupBox_FrequencyProps.PerformLayout()
        Me.GroupBox_TouchProps.ResumeLayout(False)
        Me.GroupBox_TouchProps.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox_StepperProps.ResumeLayout(False)
        Me.GroupBox_StepperProps.PerformLayout()
        Me.GroupBox_PwmFastProps.ResumeLayout(False)
        Me.GroupBox_PwmFastProps.PerformLayout()
        Me.GroupBox_Adc24Props.ResumeLayout(False)
        Me.GroupBox_Adc24Props.PerformLayout()
        Me.GroupBox_Adc24ChProps.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer_10Hz As System.Windows.Forms.Timer
    Friend WithEvents GroupBox_MasterProps As System.Windows.Forms.GroupBox
    Friend WithEvents txt_CommSpeed As MyTextBox
    Friend WithEvents Label_CommSpeed As System.Windows.Forms.Label
    Friend WithEvents txt_CapMinDist As MyTextBox
    Friend WithEvents txt_ResponseSpeed As MyTextBox
    Friend WithEvents txt_CapMaxDist As MyTextBox
    Friend WithEvents Label_MinDist As System.Windows.Forms.Label
    Friend WithEvents Label_MaxDist As System.Windows.Forms.Label
    Friend WithEvents txt_MinValue As MyTextBox
    Friend WithEvents Label_MinValue As System.Windows.Forms.Label
    Friend WithEvents txt_MaxValue As MyTextBox
    Friend WithEvents Label_MaxValue As System.Windows.Forms.Label
    Friend WithEvents txt_CapArea As MyTextBox
    Friend WithEvents Label_Area As System.Windows.Forms.Label
    Friend WithEvents MyListView1 As ListViewFlickerFree
    Friend WithEvents GroupBox_PinProps As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_PinType As MyComboBox
    Friend WithEvents Label_PinType As System.Windows.Forms.Label
    Friend WithEvents GroupBox_CapSensorProps As System.Windows.Forms.GroupBox
    Friend WithEvents txt_Slot As MyTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Pic_CalibrateTime As System.Windows.Forms.PictureBox
    Friend WithEvents btn_Calibrate As MyButton
    Friend WithEvents Timer_1Hz As System.Windows.Forms.Timer
    Friend WithEvents GroupBox_ServoPwmProps As System.Windows.Forms.GroupBox
    Friend WithEvents txt_ServoMaxTime As MyTextBox
    Friend WithEvents Label_MinTime As System.Windows.Forms.Label
    Friend WithEvents txt_ServoMinTime As MyTextBox
    Friend WithEvents Label_MaxTime As System.Windows.Forms.Label
    Friend WithEvents txt_MinChange As MyTextBox
    Friend WithEvents GroupBox_FrequencyProps As System.Windows.Forms.GroupBox
    Friend WithEvents txt_MaxFreq As MyTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_MinFreq As MyTextBox
    Friend WithEvents Label_MaxFreq As System.Windows.Forms.Label
    Friend WithEvents GroupBox_TouchProps As System.Windows.Forms.GroupBox
    Friend WithEvents txt_MinVariation As MyTextBox
    Friend WithEvents Label_ProportionalArea As System.Windows.Forms.Label
    Friend WithEvents txt_ProportionalArea As MyTextBox
    Friend WithEvents Label_MinVariation As System.Windows.Forms.Label
    Friend WithEvents Label_RepFreq As System.Windows.Forms.Label
    Friend WithEvents lbl_ErrorRate As System.Windows.Forms.Label
    Friend WithEvents Label_ErrorRate As System.Windows.Forms.Label
    Friend WithEvents lbl_RepeatFrequency As System.Windows.Forms.Label
    Friend WithEvents chk_FastDataExchange As System.Windows.Forms.CheckBox
    Friend WithEvents chk_ConvertToFrequency As System.Windows.Forms.CheckBox
    Friend WithEvents chk_LogResponse As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton_Recognize As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_Validate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_BeepOnErrors As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Menu_File As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_File_EditConfigurations As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_File_Exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Tools As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Help As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Help_ProgramHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Menu_File_OpenProgramFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmb_MasterNames As MyComboBox
    Friend WithEvents btn_MasterName As MyButton
    Friend WithEvents Menu_Language As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Language_English As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Language_Italian As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Language_Francais As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Language_Espanol As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Language_Deutsch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Language_Japanese As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chk_RemoveErrors As System.Windows.Forms.CheckBox
    Friend WithEvents Label_ResponseSpeed As MyButton
    Friend WithEvents ToolStripButton_Lock As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton_Disconnect As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox_StepperProps As System.Windows.Forms.GroupBox
    Friend WithEvents txt_MaxSpeed As MyTextBox
    Friend WithEvents Label_MaxAcc As System.Windows.Forms.Label
    Friend WithEvents txt_MaxAcc As MyTextBox
    Friend WithEvents Label_MaxSpeed As System.Windows.Forms.Label
    Friend WithEvents Label_StepsPerMillim As System.Windows.Forms.Label
    Friend WithEvents txt_StepsPerMillim As MyTextBox
    Friend WithEvents chk_LinkedToPrevious As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox_PwmFastProps As System.Windows.Forms.GroupBox
    Friend WithEvents chk_DutyCycleFromSlot As System.Windows.Forms.CheckBox
    Friend WithEvents chk_FrequencyFromSlot As System.Windows.Forms.CheckBox
    Friend WithEvents txt_PwmFastFrequency As MyTextBox
    Friend WithEvents Label_PwmFastDutyCycle As System.Windows.Forms.Label
    Friend WithEvents txt_PwmFastDutyCycle As MyTextBox
    Friend WithEvents Label_PwmFastFrequency As System.Windows.Forms.Label
    Friend WithEvents btn_Reconnect As MyButton
    Friend WithEvents GroupBox_Adc24Props As System.Windows.Forms.GroupBox
    Friend WithEvents txt_NumberOfPins As MyTextBox
    Friend WithEvents Label_SamplesPerSec As System.Windows.Forms.Label
    Friend WithEvents Label_NumberOfPins As System.Windows.Forms.Label
    Friend WithEvents GroupBox_Adc24ChProps As System.Windows.Forms.GroupBox
    Friend WithEvents cmb_Adc24ChType As Theremino_HAL.MyComboBox
    Friend WithEvents chk_Adc24ChBiased As System.Windows.Forms.CheckBox
    Friend WithEvents Label_Adc24ChGain As System.Windows.Forms.Label
    Friend WithEvents Label_Adc24ChType As System.Windows.Forms.Label
    Friend WithEvents cmb_Adc24ChGain As Theremino_HAL.MyComboBox
    Friend WithEvents cmb_Adc24Filter As Theremino_HAL.MyComboBox
    Friend WithEvents Label_Adc24Filter As System.Windows.Forms.Label
    Friend WithEvents cmb_Adc24Sps As Theremino_HAL.MyComboBox
    Friend WithEvents Timer_60Hz As System.Windows.Forms.Timer
    Friend WithEvents Menu_File_EditSlotNames As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Menu_File_BackupConfigurations As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_File_LoadConfigurations As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Language_Chinese As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Menu_Language_Portoguese As System.Windows.Forms.ToolStripMenuItem
End Class
