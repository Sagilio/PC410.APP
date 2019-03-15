<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.ButReadStop = New System.Windows.Forms.Button()
        Me.关于ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button_idle = New System.Windows.Forms.Button()
        Me.Button_hold = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.设置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PC串口设置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.温度曲线设置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.数据设置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.通讯设置ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button_start = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelProgessPoint = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ButClose = New System.Windows.Forms.Button()
        Me.ButOpen = New System.Windows.Forms.Button()
        Me.ButReadStart = New System.Windows.Forms.Button()
        Me.LabelPort = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboBoxCom = New System.Windows.Forms.ComboBox()
        Me.set_progess_number = New System.Windows.Forms.Button()
        Me.ButComArrdessTest = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboBoxName = New System.Windows.Forms.ComboBox()
        Me.NumericUpDown_progress_Number = New System.Windows.Forms.NumericUpDown()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ChartPicture = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TxtbufferShow = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LabelAddress = New System.Windows.Forms.Label()
        Me.LabelCycle = New System.Windows.Forms.Label()
        Me.LabelProgess = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ChartPictureSave = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown_progress_Number, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ChartPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButReadStop
        '
        Me.ButReadStop.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButReadStop.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButReadStop.Location = New System.Drawing.Point(125, 46)
        Me.ButReadStop.Margin = New System.Windows.Forms.Padding(4)
        Me.ButReadStop.Name = "ButReadStop"
        Me.ButReadStop.Size = New System.Drawing.Size(93, 38)
        Me.ButReadStop.TabIndex = 41
        Me.ButReadStop.Text = "停止读取"
        Me.ButReadStop.UseVisualStyleBackColor = True
        '
        '关于ToolStripMenuItem
        '
        Me.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem"
        Me.关于ToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.关于ToolStripMenuItem.Size = New System.Drawing.Size(51, 24)
        Me.关于ToolStripMenuItem.Text = "关于"
        '
        'Button_idle
        '
        Me.Button_idle.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_idle.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button_idle.Location = New System.Drawing.Point(240, 42)
        Me.Button_idle.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_idle.Name = "Button_idle"
        Me.Button_idle.Size = New System.Drawing.Size(95, 38)
        Me.Button_idle.TabIndex = 45
        Me.Button_idle.Text = "停止加热"
        Me.Button_idle.UseVisualStyleBackColor = True
        '
        'Button_hold
        '
        Me.Button_hold.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_hold.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button_hold.Location = New System.Drawing.Point(131, 42)
        Me.Button_hold.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_hold.Name = "Button_hold"
        Me.Button_hold.Size = New System.Drawing.Size(93, 38)
        Me.Button_hold.TabIndex = 44
        Me.Button_hold.Text = "暂停加热"
        Me.Button_hold.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Window
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.设置ToolStripMenuItem, Me.关于ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MenuStrip1.Size = New System.Drawing.Size(1021, 28)
        Me.MenuStrip1.TabIndex = 46
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '设置ToolStripMenuItem
        '
        Me.设置ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PC串口设置ToolStripMenuItem, Me.温度曲线设置ToolStripMenuItem, Me.数据设置ToolStripMenuItem, Me.通讯设置ToolStripMenuItem})
        Me.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem"
        Me.设置ToolStripMenuItem.Size = New System.Drawing.Size(51, 24)
        Me.设置ToolStripMenuItem.Text = "设置"
        '
        'PC串口设置ToolStripMenuItem
        '
        Me.PC串口设置ToolStripMenuItem.Name = "PC串口设置ToolStripMenuItem"
        Me.PC串口设置ToolStripMenuItem.Size = New System.Drawing.Size(174, 26)
        Me.PC串口设置ToolStripMenuItem.Text = "PC串口设置"
        '
        '温度曲线设置ToolStripMenuItem
        '
        Me.温度曲线设置ToolStripMenuItem.Name = "温度曲线设置ToolStripMenuItem"
        Me.温度曲线设置ToolStripMenuItem.Size = New System.Drawing.Size(174, 26)
        Me.温度曲线设置ToolStripMenuItem.Text = "温度曲线设置"
        '
        '数据设置ToolStripMenuItem
        '
        Me.数据设置ToolStripMenuItem.Name = "数据设置ToolStripMenuItem"
        Me.数据设置ToolStripMenuItem.Size = New System.Drawing.Size(174, 26)
        Me.数据设置ToolStripMenuItem.Text = "数据设置"
        '
        '通讯设置ToolStripMenuItem
        '
        Me.通讯设置ToolStripMenuItem.Name = "通讯设置ToolStripMenuItem"
        Me.通讯设置ToolStripMenuItem.Size = New System.Drawing.Size(174, 26)
        Me.通讯设置ToolStripMenuItem.Text = "通讯设置"
        '
        'Button_start
        '
        Me.Button_start.BackColor = System.Drawing.SystemColors.Window
        Me.Button_start.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Button_start.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button_start.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Button_start.Location = New System.Drawing.Point(23, 42)
        Me.Button_start.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_start.Name = "Button_start"
        Me.Button_start.Size = New System.Drawing.Size(93, 38)
        Me.Button_start.TabIndex = 43
        Me.Button_start.Text = "开始加热"
        Me.Button_start.UseVisualStyleBackColor = False
        '
        'SerialPort1
        '
        '
        'Timer1
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 45)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "端口名称："
        '
        'LabelProgessPoint
        '
        Me.LabelProgessPoint.AutoSize = True
        Me.LabelProgessPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelProgessPoint.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelProgessPoint.Location = New System.Drawing.Point(29, 80)
        Me.LabelProgessPoint.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelProgessPoint.Name = "LabelProgessPoint"
        Me.LabelProgessPoint.Size = New System.Drawing.Size(159, 20)
        Me.LabelProgessPoint.TabIndex = 2
        Me.LabelProgessPoint.Text = "当前程序段号：未运行"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ButClose)
        Me.GroupBox3.Controls.Add(Me.ButOpen)
        Me.GroupBox3.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 226)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(363, 105)
        Me.GroupBox3.TabIndex = 42
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "串口开关"
        '
        'ButClose
        '
        Me.ButClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButClose.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButClose.Location = New System.Drawing.Point(192, 39)
        Me.ButClose.Margin = New System.Windows.Forms.Padding(4)
        Me.ButClose.Name = "ButClose"
        Me.ButClose.Size = New System.Drawing.Size(133, 38)
        Me.ButClose.TabIndex = 19
        Me.ButClose.Text = "关闭串口"
        Me.ButClose.UseVisualStyleBackColor = True
        '
        'ButOpen
        '
        Me.ButOpen.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButOpen.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButOpen.Location = New System.Drawing.Point(21, 39)
        Me.ButOpen.Margin = New System.Windows.Forms.Padding(4)
        Me.ButOpen.Name = "ButOpen"
        Me.ButOpen.Size = New System.Drawing.Size(133, 38)
        Me.ButOpen.TabIndex = 18
        Me.ButOpen.Text = "打开串口"
        Me.ButOpen.UseVisualStyleBackColor = True
        '
        'ButReadStart
        '
        Me.ButReadStart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ButReadStart.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ButReadStart.Location = New System.Drawing.Point(19, 46)
        Me.ButReadStart.Margin = New System.Windows.Forms.Padding(4)
        Me.ButReadStart.Name = "ButReadStart"
        Me.ButReadStart.Size = New System.Drawing.Size(95, 38)
        Me.ButReadStart.TabIndex = 40
        Me.ButReadStart.Text = "开始读取"
        Me.ButReadStart.UseVisualStyleBackColor = True
        '
        'LabelPort
        '
        Me.LabelPort.AutoSize = True
        Me.LabelPort.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelPort.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelPort.Location = New System.Drawing.Point(29, 22)
        Me.LabelPort.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelPort.Name = "LabelPort"
        Me.LabelPort.Size = New System.Drawing.Size(159, 20)
        Me.LabelPort.TabIndex = 31
        Me.LabelPort.Text = "当前串口状态：未打开"
        Me.LabelPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBoxCom)
        Me.GroupBox1.Controls.Add(Me.set_progess_number)
        Me.GroupBox1.Controls.Add(Me.ButComArrdessTest)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.ComboBoxName)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown_progress_Number)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 32)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(363, 186)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PC串口设置"
        '
        'ComboBoxCom
        '
        Me.ComboBoxCom.FormattingEnabled = True
        Me.ComboBoxCom.Location = New System.Drawing.Point(99, 134)
        Me.ComboBoxCom.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ComboBoxCom.Name = "ComboBoxCom"
        Me.ComboBoxCom.Size = New System.Drawing.Size(107, 28)
        Me.ComboBoxCom.TabIndex = 38
        '
        'set_progess_number
        '
        Me.set_progess_number.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.set_progess_number.Location = New System.Drawing.Point(215, 86)
        Me.set_progess_number.Margin = New System.Windows.Forms.Padding(4)
        Me.set_progess_number.Name = "set_progess_number"
        Me.set_progess_number.Size = New System.Drawing.Size(111, 31)
        Me.set_progess_number.TabIndex = 28
        Me.set_progess_number.Text = "设置"
        Me.set_progess_number.UseVisualStyleBackColor = True
        '
        'ButComArrdessTest
        '
        Me.ButComArrdessTest.Location = New System.Drawing.Point(215, 134)
        Me.ButComArrdessTest.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ButComArrdessTest.Name = "ButComArrdessTest"
        Me.ButComArrdessTest.Size = New System.Drawing.Size(111, 31)
        Me.ButComArrdessTest.TabIndex = 29
        Me.ButComArrdessTest.Text = "检测"
        Me.ButComArrdessTest.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.Location = New System.Drawing.Point(19, 138)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 20)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "通讯地址："
        '
        'ComboBoxName
        '
        Me.ComboBoxName.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ComboBoxName.FormattingEnabled = True
        Me.ComboBoxName.Location = New System.Drawing.Point(99, 42)
        Me.ComboBoxName.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxName.Name = "ComboBoxName"
        Me.ComboBoxName.Size = New System.Drawing.Size(225, 28)
        Me.ComboBoxName.TabIndex = 12
        '
        'NumericUpDown_progress_Number
        '
        Me.NumericUpDown_progress_Number.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NumericUpDown_progress_Number.Location = New System.Drawing.Point(97, 89)
        Me.NumericUpDown_progress_Number.Margin = New System.Windows.Forms.Padding(4)
        Me.NumericUpDown_progress_Number.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
        Me.NumericUpDown_progress_Number.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown_progress_Number.Name = "NumericUpDown_progress_Number"
        Me.NumericUpDown_progress_Number.Size = New System.Drawing.Size(109, 27)
        Me.NumericUpDown_progress_Number.TabIndex = 27
        Me.NumericUpDown_progress_Number.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label18.Location = New System.Drawing.Point(19, 91)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 20)
        Me.Label18.TabIndex = 26
        Me.Label18.Text = "程序编号："
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ChartPicture)
        Me.GroupBox4.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(391, 32)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox4.Size = New System.Drawing.Size(623, 350)
        Me.GroupBox4.TabIndex = 47
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "数据分析"
        '
        'ChartPicture
        '
        ChartArea1.Name = "ChartArea1"
        Me.ChartPicture.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.ChartPicture.Legends.Add(Legend1)
        Me.ChartPicture.Location = New System.Drawing.Point(16, 28)
        Me.ChartPicture.Margin = New System.Windows.Forms.Padding(4)
        Me.ChartPicture.Name = "ChartPicture"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.ChartPicture.Series.Add(Series1)
        Me.ChartPicture.Size = New System.Drawing.Size(587, 306)
        Me.ChartPicture.TabIndex = 35
        Me.ChartPicture.Text = "Chart1"
        '
        'TxtbufferShow
        '
        Me.TxtbufferShow.Location = New System.Drawing.Point(8, 22)
        Me.TxtbufferShow.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtbufferShow.Multiline = True
        Me.TxtbufferShow.Name = "TxtbufferShow"
        Me.TxtbufferShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtbufferShow.Size = New System.Drawing.Size(371, 144)
        Me.TxtbufferShow.TabIndex = 34
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LabelAddress)
        Me.GroupBox2.Controls.Add(Me.LabelCycle)
        Me.GroupBox2.Controls.Add(Me.LabelProgess)
        Me.GroupBox2.Controls.Add(Me.LabelProgessPoint)
        Me.GroupBox2.Controls.Add(Me.LabelPort)
        Me.GroupBox2.Location = New System.Drawing.Point(787, 388)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(228, 174)
        Me.GroupBox2.TabIndex = 39
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "设备情况"
        '
        'LabelAddress
        '
        Me.LabelAddress.AutoSize = True
        Me.LabelAddress.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelAddress.Location = New System.Drawing.Point(29, 140)
        Me.LabelAddress.Name = "LabelAddress"
        Me.LabelAddress.Size = New System.Drawing.Size(159, 20)
        Me.LabelAddress.TabIndex = 34
        Me.LabelAddress.Text = "当前通讯地址：未设置"
        '
        'LabelCycle
        '
        Me.LabelCycle.AutoSize = True
        Me.LabelCycle.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelCycle.Location = New System.Drawing.Point(28, 110)
        Me.LabelCycle.Name = "LabelCycle"
        Me.LabelCycle.Size = New System.Drawing.Size(159, 20)
        Me.LabelCycle.TabIndex = 33
        Me.LabelCycle.Text = "当前发送周期：未设置"
        '
        'LabelProgess
        '
        Me.LabelProgess.AutoSize = True
        Me.LabelProgess.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LabelProgess.Location = New System.Drawing.Point(29, 51)
        Me.LabelProgess.Name = "LabelProgess"
        Me.LabelProgess.Size = New System.Drawing.Size(159, 20)
        Me.LabelProgess.TabIndex = 32
        Me.LabelProgess.Text = "当前程序编号：未运行"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button_start)
        Me.GroupBox5.Controls.Add(Me.Button_hold)
        Me.GroupBox5.Controls.Add(Me.Button_idle)
        Me.GroupBox5.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(11, 338)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox5.Size = New System.Drawing.Size(364, 111)
        Me.GroupBox5.TabIndex = 48
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "加热开关"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.ChartPictureSave)
        Me.GroupBox6.Controls.Add(Me.ButReadStart)
        Me.GroupBox6.Controls.Add(Me.ButReadStop)
        Me.GroupBox6.Font = New System.Drawing.Font("微软雅黑", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(17, 452)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox6.Size = New System.Drawing.Size(359, 109)
        Me.GroupBox6.TabIndex = 49
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "数据读取开关"
        '
        'ChartPictureSave
        '
        Me.ChartPictureSave.Location = New System.Drawing.Point(236, 46)
        Me.ChartPictureSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChartPictureSave.Name = "ChartPictureSave"
        Me.ChartPictureSave.Size = New System.Drawing.Size(95, 38)
        Me.ChartPictureSave.TabIndex = 42
        Me.ChartPictureSave.Text = "保存曲线"
        Me.ChartPictureSave.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.TxtbufferShow)
        Me.GroupBox7.Location = New System.Drawing.Point(391, 388)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox7.Size = New System.Drawing.Size(387, 174)
        Me.GroupBox7.TabIndex = 50
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "实时数据"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.SystemColors.Window
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 564)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 13, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1021, 25)
        Me.StatusStrip1.TabIndex = 51
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(67, 20)
        Me.ToolStripStatusLabel1.Text = "   就绪 …"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.AutoSize = False
        Me.ToolStripProgressBar1.Maximum = 99
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(120, 19)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ToolStripProgressBar1.Visible = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1021, 589)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Main"
        Me.Text = "PC410串口加热程序 v0.2.0"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown_progress_Number, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.ChartPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButReadStop As Button
    Friend WithEvents 关于ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button_idle As Button
    Friend WithEvents Button_hold As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 设置ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button_start As Button
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelProgessPoint As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents ButReadStart As Button
    Friend WithEvents LabelPort As Label
    Friend WithEvents ButClose As Button
    Friend WithEvents ButOpen As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ChartPicture As DataVisualization.Charting.Chart
    Friend WithEvents TxtbufferShow As TextBox
    Friend WithEvents PC串口设置ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 温度曲线设置ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 数据设置ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComboBoxName As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents set_progess_number As Button
    Friend WithEvents NumericUpDown_progress_Number As NumericUpDown
    Friend WithEvents Label18 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents ChartPictureSave As Button
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents LabelProgess As Label
    Friend WithEvents LabelAddress As Label
    Friend WithEvents LabelCycle As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents ButComArrdessTest As Button
    Friend WithEvents ComboBoxCom As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents 通讯设置ToolStripMenuItem As ToolStripMenuItem
End Class
