<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.slotValue = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(79, 55)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(83, 30)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "showHAL"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(79, 145)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(83, 30)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "showSingal"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(221, 55)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(83, 30)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "sendText"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(79, 247)
        Me.Button4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(83, 30)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "showSlot"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(221, 247)
        Me.Button5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(83, 30)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "hideSlot"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(450, 55)
        Me.Button6.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(83, 30)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "writeSlot"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'slotValue
        '
        Me.slotValue.Location = New System.Drawing.Point(345, 61)
        Me.slotValue.Name = "slotValue"
        Me.slotValue.Size = New System.Drawing.Size(100, 20)
        Me.slotValue.TabIndex = 6
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 390)
        Me.Controls.Add(Me.slotValue)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "Main"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents slotValue As TextBox
End Class
