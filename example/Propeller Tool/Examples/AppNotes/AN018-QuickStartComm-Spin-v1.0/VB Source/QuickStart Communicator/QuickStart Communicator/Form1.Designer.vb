<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.cboPortName = New System.Windows.Forms.ComboBox
        Me.cboBaudRate = New System.Windows.Forms.ComboBox
        Me.btnOpenClose = New System.Windows.Forms.Button
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.grbPortSettings = New System.Windows.Forms.GroupBox
        Me.grbPortStatus = New System.Windows.Forms.GroupBox
        Me.lblPortStatus = New System.Windows.Forms.Label
        Me.picPortStatus = New System.Windows.Forms.PictureBox
        Me.grbIOData = New System.Windows.Forms.GroupBox
        Me.picLED7 = New System.Windows.Forms.PictureBox
        Me.picLED6 = New System.Windows.Forms.PictureBox
        Me.picLED5 = New System.Windows.Forms.PictureBox
        Me.picLED4 = New System.Windows.Forms.PictureBox
        Me.picLED3 = New System.Windows.Forms.PictureBox
        Me.picLED2 = New System.Windows.Forms.PictureBox
        Me.picLED1 = New System.Windows.Forms.PictureBox
        Me.picLED0 = New System.Windows.Forms.PictureBox
        Me.picButton7 = New System.Windows.Forms.PictureBox
        Me.picButton6 = New System.Windows.Forms.PictureBox
        Me.picButton5 = New System.Windows.Forms.PictureBox
        Me.picButton4 = New System.Windows.Forms.PictureBox
        Me.picButton3 = New System.Windows.Forms.PictureBox
        Me.picButton2 = New System.Windows.Forms.PictureBox
        Me.picButton1 = New System.Windows.Forms.PictureBox
        Me.picButton0 = New System.Windows.Forms.PictureBox
        Me.picQSBoard = New System.Windows.Forms.PictureBox
        Me.chkLED7 = New System.Windows.Forms.CheckBox
        Me.chkLED6 = New System.Windows.Forms.CheckBox
        Me.chkLED5 = New System.Windows.Forms.CheckBox
        Me.chkLED4 = New System.Windows.Forms.CheckBox
        Me.chkLED3 = New System.Windows.Forms.CheckBox
        Me.chkLED2 = New System.Windows.Forms.CheckBox
        Me.chkLED1 = New System.Windows.Forms.CheckBox
        Me.chkLED0 = New System.Windows.Forms.CheckBox
        Me.grbPortSettings.SuspendLayout()
        Me.grbPortStatus.SuspendLayout()
        CType(Me.picPortStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbIOData.SuspendLayout()
        CType(Me.picLED7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLED6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLED5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLED4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLED3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLED2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLED1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLED0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picButton7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picButton6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picButton5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picButton4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picButton3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picButton2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picButton1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picButton0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picQSBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboPortName
        '
        Me.cboPortName.FormattingEnabled = True
        Me.cboPortName.Location = New System.Drawing.Point(6, 32)
        Me.cboPortName.Name = "cboPortName"
        Me.cboPortName.Size = New System.Drawing.Size(108, 21)
        Me.cboPortName.TabIndex = 0
        '
        'cboBaudRate
        '
        Me.cboBaudRate.FormattingEnabled = True
        Me.cboBaudRate.Location = New System.Drawing.Point(6, 59)
        Me.cboBaudRate.Name = "cboBaudRate"
        Me.cboBaudRate.Size = New System.Drawing.Size(108, 21)
        Me.cboBaudRate.TabIndex = 1
        '
        'btnOpenClose
        '
        Me.btnOpenClose.Location = New System.Drawing.Point(6, 86)
        Me.btnOpenClose.Name = "btnOpenClose"
        Me.btnOpenClose.Size = New System.Drawing.Size(108, 23)
        Me.btnOpenClose.TabIndex = 2
        Me.btnOpenClose.Text = "Open Port"
        Me.btnOpenClose.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 50
        '
        'grbPortSettings
        '
        Me.grbPortSettings.Controls.Add(Me.cboPortName)
        Me.grbPortSettings.Controls.Add(Me.btnOpenClose)
        Me.grbPortSettings.Controls.Add(Me.cboBaudRate)
        Me.grbPortSettings.Location = New System.Drawing.Point(380, 12)
        Me.grbPortSettings.Name = "grbPortSettings"
        Me.grbPortSettings.Size = New System.Drawing.Size(120, 128)
        Me.grbPortSettings.TabIndex = 4
        Me.grbPortSettings.TabStop = False
        Me.grbPortSettings.Text = "Port Settings"
        '
        'grbPortStatus
        '
        Me.grbPortStatus.Controls.Add(Me.lblPortStatus)
        Me.grbPortStatus.Controls.Add(Me.picPortStatus)
        Me.grbPortStatus.Location = New System.Drawing.Point(380, 167)
        Me.grbPortStatus.Name = "grbPortStatus"
        Me.grbPortStatus.Size = New System.Drawing.Size(120, 77)
        Me.grbPortStatus.TabIndex = 5
        Me.grbPortStatus.TabStop = False
        Me.grbPortStatus.Text = "Port Status"
        '
        'lblPortStatus
        '
        Me.lblPortStatus.AutoSize = True
        Me.lblPortStatus.BackColor = System.Drawing.SystemColors.Window
        Me.lblPortStatus.Location = New System.Drawing.Point(18, 37)
        Me.lblPortStatus.Name = "lblPortStatus"
        Me.lblPortStatus.Size = New System.Drawing.Size(24, 13)
        Me.lblPortStatus.TabIndex = 6
        Me.lblPortStatus.Text = "Idle"
        Me.lblPortStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'picPortStatus
        '
        Me.picPortStatus.BackColor = System.Drawing.SystemColors.Control
        Me.picPortStatus.Location = New System.Drawing.Point(6, 19)
        Me.picPortStatus.Name = "picPortStatus"
        Me.picPortStatus.Size = New System.Drawing.Size(108, 52)
        Me.picPortStatus.TabIndex = 6
        Me.picPortStatus.TabStop = False
        '
        'grbIOData
        '
        Me.grbIOData.Controls.Add(Me.picLED7)
        Me.grbIOData.Controls.Add(Me.picLED6)
        Me.grbIOData.Controls.Add(Me.picLED5)
        Me.grbIOData.Controls.Add(Me.picLED4)
        Me.grbIOData.Controls.Add(Me.picLED3)
        Me.grbIOData.Controls.Add(Me.picLED2)
        Me.grbIOData.Controls.Add(Me.picLED1)
        Me.grbIOData.Controls.Add(Me.picLED0)
        Me.grbIOData.Controls.Add(Me.picButton7)
        Me.grbIOData.Controls.Add(Me.picButton6)
        Me.grbIOData.Controls.Add(Me.picButton5)
        Me.grbIOData.Controls.Add(Me.picButton4)
        Me.grbIOData.Controls.Add(Me.picButton3)
        Me.grbIOData.Controls.Add(Me.picButton2)
        Me.grbIOData.Controls.Add(Me.picButton1)
        Me.grbIOData.Controls.Add(Me.picButton0)
        Me.grbIOData.Controls.Add(Me.picQSBoard)
        Me.grbIOData.Controls.Add(Me.chkLED7)
        Me.grbIOData.Controls.Add(Me.chkLED6)
        Me.grbIOData.Controls.Add(Me.chkLED5)
        Me.grbIOData.Controls.Add(Me.chkLED4)
        Me.grbIOData.Controls.Add(Me.chkLED3)
        Me.grbIOData.Controls.Add(Me.chkLED2)
        Me.grbIOData.Controls.Add(Me.chkLED1)
        Me.grbIOData.Controls.Add(Me.chkLED0)
        Me.grbIOData.Location = New System.Drawing.Point(12, 12)
        Me.grbIOData.Name = "grbIOData"
        Me.grbIOData.Size = New System.Drawing.Size(362, 232)
        Me.grbIOData.TabIndex = 6
        Me.grbIOData.TabStop = False
        Me.grbIOData.Text = "I/O Data"
        '
        'picLED7
        '
        Me.picLED7.BackColor = System.Drawing.Color.Blue
        Me.picLED7.Location = New System.Drawing.Point(250, 167)
        Me.picLED7.Name = "picLED7"
        Me.picLED7.Size = New System.Drawing.Size(10, 10)
        Me.picLED7.TabIndex = 22
        Me.picLED7.TabStop = False
        Me.picLED7.Visible = False
        '
        'picLED6
        '
        Me.picLED6.BackColor = System.Drawing.Color.Blue
        Me.picLED6.Location = New System.Drawing.Point(220, 167)
        Me.picLED6.Name = "picLED6"
        Me.picLED6.Size = New System.Drawing.Size(10, 10)
        Me.picLED6.TabIndex = 21
        Me.picLED6.TabStop = False
        Me.picLED6.Visible = False
        '
        'picLED5
        '
        Me.picLED5.BackColor = System.Drawing.Color.Blue
        Me.picLED5.Location = New System.Drawing.Point(190, 167)
        Me.picLED5.Name = "picLED5"
        Me.picLED5.Size = New System.Drawing.Size(10, 10)
        Me.picLED5.TabIndex = 20
        Me.picLED5.TabStop = False
        Me.picLED5.Visible = False
        '
        'picLED4
        '
        Me.picLED4.BackColor = System.Drawing.Color.Blue
        Me.picLED4.Location = New System.Drawing.Point(160, 167)
        Me.picLED4.Name = "picLED4"
        Me.picLED4.Size = New System.Drawing.Size(10, 10)
        Me.picLED4.TabIndex = 19
        Me.picLED4.TabStop = False
        Me.picLED4.Visible = False
        '
        'picLED3
        '
        Me.picLED3.BackColor = System.Drawing.Color.Blue
        Me.picLED3.Location = New System.Drawing.Point(130, 167)
        Me.picLED3.Name = "picLED3"
        Me.picLED3.Size = New System.Drawing.Size(10, 10)
        Me.picLED3.TabIndex = 18
        Me.picLED3.TabStop = False
        Me.picLED3.Visible = False
        '
        'picLED2
        '
        Me.picLED2.BackColor = System.Drawing.Color.Blue
        Me.picLED2.Location = New System.Drawing.Point(100, 167)
        Me.picLED2.Name = "picLED2"
        Me.picLED2.Size = New System.Drawing.Size(10, 10)
        Me.picLED2.TabIndex = 17
        Me.picLED2.TabStop = False
        Me.picLED2.Visible = False
        '
        'picLED1
        '
        Me.picLED1.BackColor = System.Drawing.Color.Blue
        Me.picLED1.Location = New System.Drawing.Point(71, 167)
        Me.picLED1.Name = "picLED1"
        Me.picLED1.Size = New System.Drawing.Size(10, 10)
        Me.picLED1.TabIndex = 16
        Me.picLED1.TabStop = False
        Me.picLED1.Visible = False
        '
        'picLED0
        '
        Me.picLED0.BackColor = System.Drawing.Color.Blue
        Me.picLED0.Location = New System.Drawing.Point(42, 167)
        Me.picLED0.Name = "picLED0"
        Me.picLED0.Size = New System.Drawing.Size(10, 10)
        Me.picLED0.TabIndex = 7
        Me.picLED0.TabStop = False
        Me.picLED0.Visible = False
        '
        'picButton7
        '
        Me.picButton7.BackColor = System.Drawing.Color.PeachPuff
        Me.picButton7.Location = New System.Drawing.Point(242, 180)
        Me.picButton7.Name = "picButton7"
        Me.picButton7.Size = New System.Drawing.Size(25, 25)
        Me.picButton7.TabIndex = 15
        Me.picButton7.TabStop = False
        Me.picButton7.Visible = False
        '
        'picButton6
        '
        Me.picButton6.BackColor = System.Drawing.Color.PeachPuff
        Me.picButton6.Location = New System.Drawing.Point(212, 180)
        Me.picButton6.Name = "picButton6"
        Me.picButton6.Size = New System.Drawing.Size(25, 25)
        Me.picButton6.TabIndex = 14
        Me.picButton6.TabStop = False
        Me.picButton6.Visible = False
        '
        'picButton5
        '
        Me.picButton5.BackColor = System.Drawing.Color.PeachPuff
        Me.picButton5.Location = New System.Drawing.Point(183, 180)
        Me.picButton5.Name = "picButton5"
        Me.picButton5.Size = New System.Drawing.Size(25, 25)
        Me.picButton5.TabIndex = 13
        Me.picButton5.TabStop = False
        Me.picButton5.Visible = False
        '
        'picButton4
        '
        Me.picButton4.BackColor = System.Drawing.Color.PeachPuff
        Me.picButton4.Location = New System.Drawing.Point(153, 180)
        Me.picButton4.Name = "picButton4"
        Me.picButton4.Size = New System.Drawing.Size(25, 25)
        Me.picButton4.TabIndex = 12
        Me.picButton4.TabStop = False
        Me.picButton4.Visible = False
        '
        'picButton3
        '
        Me.picButton3.BackColor = System.Drawing.Color.PeachPuff
        Me.picButton3.Location = New System.Drawing.Point(123, 180)
        Me.picButton3.Name = "picButton3"
        Me.picButton3.Size = New System.Drawing.Size(25, 25)
        Me.picButton3.TabIndex = 11
        Me.picButton3.TabStop = False
        Me.picButton3.Visible = False
        '
        'picButton2
        '
        Me.picButton2.BackColor = System.Drawing.Color.PeachPuff
        Me.picButton2.Location = New System.Drawing.Point(93, 180)
        Me.picButton2.Name = "picButton2"
        Me.picButton2.Size = New System.Drawing.Size(25, 25)
        Me.picButton2.TabIndex = 10
        Me.picButton2.TabStop = False
        Me.picButton2.Visible = False
        '
        'picButton1
        '
        Me.picButton1.BackColor = System.Drawing.Color.PeachPuff
        Me.picButton1.Location = New System.Drawing.Point(64, 180)
        Me.picButton1.Name = "picButton1"
        Me.picButton1.Size = New System.Drawing.Size(25, 25)
        Me.picButton1.TabIndex = 9
        Me.picButton1.TabStop = False
        Me.picButton1.Visible = False
        '
        'picButton0
        '
        Me.picButton0.BackColor = System.Drawing.Color.PeachPuff
        Me.picButton0.Location = New System.Drawing.Point(34, 180)
        Me.picButton0.Name = "picButton0"
        Me.picButton0.Size = New System.Drawing.Size(25, 25)
        Me.picButton0.TabIndex = 8
        Me.picButton0.TabStop = False
        Me.picButton0.Visible = False
        '
        'picQSBoard
        '
        Me.picQSBoard.BackgroundImage = CType(resources.GetObject("picQSBoard.BackgroundImage"), System.Drawing.Image)
        Me.picQSBoard.Location = New System.Drawing.Point(6, 19)
        Me.picQSBoard.Name = "picQSBoard"
        Me.picQSBoard.Size = New System.Drawing.Size(289, 193)
        Me.picQSBoard.TabIndex = 8
        Me.picQSBoard.TabStop = False
        '
        'chkLED7
        '
        Me.chkLED7.AutoSize = True
        Me.chkLED7.Location = New System.Drawing.Point(301, 189)
        Me.chkLED7.Name = "chkLED7"
        Me.chkLED7.Size = New System.Drawing.Size(56, 17)
        Me.chkLED7.TabIndex = 7
        Me.chkLED7.Text = "LED 7"
        Me.chkLED7.UseVisualStyleBackColor = True
        '
        'chkLED6
        '
        Me.chkLED6.AutoSize = True
        Me.chkLED6.Location = New System.Drawing.Point(301, 166)
        Me.chkLED6.Name = "chkLED6"
        Me.chkLED6.Size = New System.Drawing.Size(56, 17)
        Me.chkLED6.TabIndex = 6
        Me.chkLED6.Text = "LED 6"
        Me.chkLED6.UseVisualStyleBackColor = True
        '
        'chkLED5
        '
        Me.chkLED5.AutoSize = True
        Me.chkLED5.Location = New System.Drawing.Point(301, 143)
        Me.chkLED5.Name = "chkLED5"
        Me.chkLED5.Size = New System.Drawing.Size(56, 17)
        Me.chkLED5.TabIndex = 5
        Me.chkLED5.Text = "LED 5"
        Me.chkLED5.UseVisualStyleBackColor = True
        '
        'chkLED4
        '
        Me.chkLED4.AutoSize = True
        Me.chkLED4.Location = New System.Drawing.Point(301, 120)
        Me.chkLED4.Name = "chkLED4"
        Me.chkLED4.Size = New System.Drawing.Size(56, 17)
        Me.chkLED4.TabIndex = 4
        Me.chkLED4.Text = "LED 4"
        Me.chkLED4.UseVisualStyleBackColor = True
        '
        'chkLED3
        '
        Me.chkLED3.AutoSize = True
        Me.chkLED3.Location = New System.Drawing.Point(301, 97)
        Me.chkLED3.Name = "chkLED3"
        Me.chkLED3.Size = New System.Drawing.Size(56, 17)
        Me.chkLED3.TabIndex = 3
        Me.chkLED3.Text = "LED 3"
        Me.chkLED3.UseVisualStyleBackColor = True
        '
        'chkLED2
        '
        Me.chkLED2.AutoSize = True
        Me.chkLED2.Location = New System.Drawing.Point(301, 74)
        Me.chkLED2.Name = "chkLED2"
        Me.chkLED2.Size = New System.Drawing.Size(56, 17)
        Me.chkLED2.TabIndex = 2
        Me.chkLED2.Text = "LED 2"
        Me.chkLED2.UseVisualStyleBackColor = True
        '
        'chkLED1
        '
        Me.chkLED1.AutoSize = True
        Me.chkLED1.Location = New System.Drawing.Point(301, 51)
        Me.chkLED1.Name = "chkLED1"
        Me.chkLED1.Size = New System.Drawing.Size(56, 17)
        Me.chkLED1.TabIndex = 1
        Me.chkLED1.Text = "LED 1"
        Me.chkLED1.UseVisualStyleBackColor = True
        '
        'chkLED0
        '
        Me.chkLED0.AutoSize = True
        Me.chkLED0.Location = New System.Drawing.Point(301, 28)
        Me.chkLED0.Name = "chkLED0"
        Me.chkLED0.Size = New System.Drawing.Size(56, 17)
        Me.chkLED0.TabIndex = 0
        Me.chkLED0.Text = "LED 0"
        Me.chkLED0.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 258)
        Me.Controls.Add(Me.grbIOData)
        Me.Controls.Add(Me.grbPortStatus)
        Me.Controls.Add(Me.grbPortSettings)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "QuickStart Communicator"
        Me.grbPortSettings.ResumeLayout(False)
        Me.grbPortStatus.ResumeLayout(False)
        Me.grbPortStatus.PerformLayout()
        CType(Me.picPortStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbIOData.ResumeLayout(False)
        Me.grbIOData.PerformLayout()
        CType(Me.picLED7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLED6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLED5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLED4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLED3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLED2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLED1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLED0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picButton7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picButton6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picButton5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picButton4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picButton3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picButton2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picButton1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picButton0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picQSBoard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboPortName As System.Windows.Forms.ComboBox
    Friend WithEvents cboBaudRate As System.Windows.Forms.ComboBox
    Friend WithEvents btnOpenClose As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents grbPortSettings As System.Windows.Forms.GroupBox
    Friend WithEvents grbPortStatus As System.Windows.Forms.GroupBox
    Friend WithEvents lblPortStatus As System.Windows.Forms.Label
    Friend WithEvents picPortStatus As System.Windows.Forms.PictureBox
    Friend WithEvents grbIOData As System.Windows.Forms.GroupBox
    Friend WithEvents chkLED7 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLED6 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLED5 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLED4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLED3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLED2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLED1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkLED0 As System.Windows.Forms.CheckBox
    Friend WithEvents picQSBoard As System.Windows.Forms.PictureBox
    Friend WithEvents picButton0 As System.Windows.Forms.PictureBox
    Friend WithEvents picButton7 As System.Windows.Forms.PictureBox
    Friend WithEvents picButton6 As System.Windows.Forms.PictureBox
    Friend WithEvents picButton5 As System.Windows.Forms.PictureBox
    Friend WithEvents picButton4 As System.Windows.Forms.PictureBox
    Friend WithEvents picButton3 As System.Windows.Forms.PictureBox
    Friend WithEvents picButton2 As System.Windows.Forms.PictureBox
    Friend WithEvents picButton1 As System.Windows.Forms.PictureBox
    Friend WithEvents picLED0 As System.Windows.Forms.PictureBox
    Friend WithEvents picLED7 As System.Windows.Forms.PictureBox
    Friend WithEvents picLED6 As System.Windows.Forms.PictureBox
    Friend WithEvents picLED5 As System.Windows.Forms.PictureBox
    Friend WithEvents picLED4 As System.Windows.Forms.PictureBox
    Friend WithEvents picLED3 As System.Windows.Forms.PictureBox
    Friend WithEvents picLED2 As System.Windows.Forms.PictureBox
    Friend WithEvents picLED1 As System.Windows.Forms.PictureBox

End Class
