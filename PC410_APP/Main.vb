'材料类五班班技能实训课小组编写：
'编写人员：汤贤赫
'程序编译日期 2018.11.21-12.07（ver.0.2.0）
'兼容系统版本 Windows7/8/8.1/10

Imports System.IO.Ports
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Main
    Dim num As Short  '绘制图像专用
    Public count_time As Double = 0
    '运行正常判断
    Public GetSuccessIsTrue As Boolean
    Public GetparameterIsTrue As Boolean
    '用于绘图
    Public SeriesPV As New Series
    Public seriesSV As New Series
    Dim ChartAreas1 As New ChartArea
    '数据保存目录
    Public SaveFolder As String
    Public SaveImageFolder As String

    Private Sub SerialPort1_DataReceived() Handles SerialPort1.DataReceived
        SerialPort1_DataReceived()
    End Sub

    '打开窗体时，判断串口是否打开，如果处于打开状态就立即 关闭
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles Me.Load

        PC410AppOptions._ini_PC410AppOptions()
        _int_SaveModule()
        LoadNowState()

        '_ini_WriteTextExcel(PC410AppOptions.NowSaveTextType)
        'WriteTextExcel(PC410AppOptions.NowSaveTextType, "100", 1, 1)

        strPVD = ""
        strSVD = ""
        num = 0

        '获得计算机已经安装的串口，并将串口加载到combox项目，以供选择用。
        Dim portNames() As String = SerialPort.GetPortNames()
        If portNames.Length < 1 Then
            MsgBox（"无可用串口"）
        Else
            For i As Integer = 0 To portNames.Length - 1
                ComboBoxName.Items.Add(portNames(i).ToString)
            Next
        End If

        ComboBoxName.Text = SerialPort1.PortName  '显示默认设置的串口
        If SerialPort1.IsOpen = False Then
            ButClose.Enabled = False
        End If

        PC410AppOptions.DataSaveFolder.Text = Application.StartupPath
        SaveFolder = PC410AppOptions.DataSaveFolder.Text _
                     & "\" & Format(Now, "yyyy年MM月dd日 ") & Format(Now, "hh_mm_ss") & " 实验数据.txt"
        SaveImageFolder = PC410AppOptions.DataSaveFolder.Text _
                     & "\" & Format(Now, "yyyy年MM月dd日 ") & Format(Now, "hh_mm_ss") & " 实验数据.png"

        ChartPicture.ChartAreas.Clear()
        ChartPicture.Series.Clear()
        ChartPicture.ChartAreas.Add(ChartAreas1)
        ChartPicture.Series.Add(SeriesPV)
        ChartPicture.Series.Add(seriesSV)
        ChartPicture.ChartAreas(0).AxisX.Title = "时间(s)"
        ChartPicture.ChartAreas(0).AxisY.Title = "温度(℃)"
        SeriesPV.ChartType = SeriesChartType.Line
        SeriesPV.LegendText = "PV"
        SeriesPV.Color = Color.Black
        seriesSV.ChartType = SeriesChartType.Line
        seriesSV.LegendText = "SV"

        '设置可选择程序编号的值，最小为1最大为9，该仪器仅支持9段每段程序可支持16个点。
        NumericUpDown_progress_Number.Maximum = 9
        NumericUpDown_progress_Number.Minimum = 1
    End Sub
    '按钮控件
    '选择串口号
    Private Sub ComboBoxName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxName.SelectedIndexChanged
        If SerialPort1.IsOpen = True Then
            MsgBox("打开串口的状态下，不能切换端口")
            'ButClose_Click(Nothing, Nothing)
        Else
            SerialPort1.PortName = ComboBoxName.Text
        End If
    End Sub

    '打开串口(修复多次点打开串口报错的问题)
    Private Sub ButOpen_Click(sender As Object, e As EventArgs) Handles ButOpen.Click

        SerialPort1.ReceivedBytesThreshold = 10
        SerialPort1.Encoding = System.Text.Encoding.Default

        '打开串口后禁用打开按钮
        SerialPort1.Open()

        If SerialPort1.IsOpen = True Then
            ToolStripStatusLabel1.Text = "   就绪 ..."
        Else
            SerialPort1.Open()
        End If

        LoadNowState()

        'TestAllCommand()
    End Sub
    '关闭串口(修复关闭串口的显示需要多次点击的问题)
    Private Sub ButClose_Click(sender As Object, e As EventArgs) Handles ButClose.Click
        If SerialPort1.IsOpen = True Then
            SerialPort1.Close()
        End If

        LoadNowState()
    End Sub

    Private Sub Set_progess_number_Click(sender As Object, e As EventArgs) Handles set_progess_number.Click
        Set_Camand("ch", NumericUpDown_progress_Number.Value)
        PC410AppOptions.NowProgessNumber = NumericUpDown_progress_Number.Value

        LoadNowState()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PC410AppCommandModule.INi_num += 1
        bln_PVandSV = True
        PV_or_SV = PC410AppCommandModule.INi_num Mod 2
        If PV_or_SV = 1 Then
            SendOrderReadPV()
        Else
            SendOrderReadSV()
        End If
        SerialPort1.DiscardOutBuffer()
        SerialPort1.DiscardInBuffer()
        count_time += Timer1.Interval / 1000 '计时，以秒为单位
    End Sub

    Private Sub Button_hold_Click(sender As Object, e As EventArgs) Handles Button_hold.Click
        If SerialPort1.IsOpen = False Then
            MsgBox("请打开串口！")
        Else
            Set_Camand("#3", "0002")
            SetSuccess()
        End If
    End Sub

    Private Sub Button_idle_Click(sender As Object, e As EventArgs) Handles Button_idle.Click
        If SerialPort1.IsOpen = False Then
            MsgBox("请打开串口！")
        Else
            Set_Camand("#3", "0000")
            SetSuccess()
        End If
    End Sub

    Private Sub Button_start_Click(sender As Object, e As EventArgs) Handles Button_start.Click
        If SerialPort1.IsOpen = False Then
            MsgBox("请打开串口！")
        Else
            Set_Camand("#3", "0001")
            SetSuccess()
        End If
    End Sub

    Private Sub ButReadStart_Click(sender As Object, e As EventArgs) Handles ButReadStart.Click

        seriesSV.Points.Clear()
        bln_PVandSV = True  '程序值或测量值，主要由于绘图
        Timer1.Start()

    End Sub

    Private Sub ButReadStop_Click(sender As Object, e As EventArgs) Handles ButReadStop.Click
        bln_PVandSV = False  '程序值或测量值，主要用于绘图
        Timer1.Stop()
    End Sub

    '新加入功能
    Private Sub TxtbufferShow_TextChanged(sender As Object, e As EventArgs) Handles TxtbufferShow.TextChanged
        TxtbufferShow.SelectionStart = TxtbufferShow.Text.Length
        TxtbufferShow.ScrollToCaret()

        If PC410AppOptions.AutoBufferClear = True Then
            If TxtbufferShow.Lines.Length > TxtbufferShow.Height / TxtbufferShow.Font.Height * 3 Then
                TxtbufferShow.Text = ""
            End If
        End If
    End Sub

    Private Sub ChartPictureSave_Click(sender As Object, e As EventArgs) Handles ChartPictureSave.Click
        If PC410AppOptions.NowSaveImageType = PC410AppSaveModule.SaveImageType(0) Then
            CreateFolder(SaveImageType(0))
        End If
        If PC410AppOptions.NowSaveImageType = PC410AppSaveModule.SaveImageType(1) Then
            CreateFolder(SaveImageType(1))
        End If
        If PC410AppOptions.NowSaveImageType = PC410AppSaveModule.SaveImageType(2) Then
            CreateFolder(SaveImageType(2))
        End If
        If PC410AppOptions.NowSaveImageType = PC410AppSaveModule.SaveImageType(3) Then
            CreateFolder(SaveImageType(3))
        End If
    End Sub

    Private Sub PC串口设置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PC串口设置ToolStripMenuItem.Click
        PC410AppOptions.TabControl1.SelectedTab = PC410AppOptions.TabPage_ButOptions
        PC410AppOptions.Show()
    End Sub

    Private Sub 温度曲线设置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 温度曲线设置ToolStripMenuItem.Click
        PC410AppOptions.TabControl1.SelectedTab = PC410AppOptions.TabPage_PrOptions
        PC410AppOptions.Show()
    End Sub

    Private Sub 数据设置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 数据设置ToolStripMenuItem.Click
        PC410AppOptions.TabControl1.SelectedTab = PC410AppOptions.TabPage_DataOptions
        PC410AppOptions.Show()
    End Sub

    Private Sub 通讯设置ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 通讯设置ToolStripMenuItem.Click
        PC410AppOptions.TabControl1.SelectedTab = PC410AppOptions.TabPage_ComOptions
        PC410AppOptions.Show()
    End Sub

    Private Sub 关于ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 关于ToolStripMenuItem.Click
        PC410AppAbout.Show()
    End Sub

    Private Sub ButComArrdessTest_Click(sender As Object, e As EventArgs) Handles ButComArrdessTest.Click
        Dim ButComAdressNumber As Integer
        Dim ButComAdress As String
        Dim i As Integer = 0

        ToolStripProgressBar1.Visible = True

        For ButComAdressNumber = 1 To 99

            ButComAdress = ButComAdressNumber.ToString
            If Len(ButComAdress) = 1 Then
                ButComAdress = "0" & ButComAdress
            End If
            ToolStripStatusLabel1.Text = "当前正在检测通讯地址,请等候 ..."

            TxtbufferShow.AppendText("当前正在检测通讯地址" & ButComAdress & "/99" & " ..." & vbCrLf)

            If AutoSetButComAddress(ButComAdress) = True Then
                PC410AppOptions.NowButComAdress = ButComAdress
                i = i + 1
                Exit For
            End If
            ToolStripProgressBar1.Value = ButComAdressNumber
        Next
        ToolStripProgressBar1.Visible = False

        If i = 1 Then
            ToolStripStatusLabel1.Text = "已选定通讯地址 & PC410AppOptions.NowButComAdress ..."
            LoadNowState()
        Else
            ToolStripStatusLabel1.Text = "未找到可用的通讯地址，你可以尝试重新检测或者手动设置 ..."
        End If
    End Sub

    Public Sub LoadNowState()
        If SerialPort1.IsOpen = True Then
            LabelPort.Text = "当前串口状态：已打开"
            LabelPort.ForeColor = Color.Green
            set_progess_number.Enabled = True
            ButOpen.Enabled = False
            ButClose.Enabled = True
            PC410AppOptions.TabPage_PrOptions_Apply.Enabled = True
            PC410AppOptions.set_progess_number.Enabled = True
            Button_start.Enabled = True
            Button_hold.Enabled = True
            Button_idle.Enabled = True
            ButReadStart.Enabled = True
            ButReadStop.Enabled = True
            ButComArrdessTest.Enabled = True
            PC410AppOptions.TabPage_PrOptions_OK.Enabled = True
        Else
            LabelPort.Text = "当前串口状态：已关闭"
            LabelPort.ForeColor = Color.Red
            ButOpen.Enabled = True
            ButClose.Enabled = False
            PC410AppOptions.TabPage_PrOptions_Apply.Enabled = False
            PC410AppOptions.set_progess_number.Enabled = False
            set_progess_number.Enabled = False
            Button_start.Enabled = False
            Button_hold.Enabled = False
            Button_idle.Enabled = False
            ButReadStart.Enabled = False
            ButReadStop.Enabled = False
            ButComArrdessTest.Enabled = False
            PC410AppOptions.TabPage_PrOptions_OK.Enabled = False
        End If
        LabelProgess.Text = "当前程序编号：" & PC410AppOptions.NowProgessNumber
        LabelProgessPoint.Text = "当前程序段号：" & PC410AppOptions.NowProgessNumberPoint
        LabelAddress.Text = "当前通讯地址：" & PC410AppOptions.NowButComAdress
        LabelCycle.Text = "当前发送周期:" & PC410AppOptions.NowTxtSendCycle
    End Sub

    Private Sub 多页面窗口(sender As Object, e As EventArgs) '（未使用）
        '//定义变量，记录窗体是否已经打开
        Dim ls_open As Boolean = False
        '//遍历TabPage页，查看页面是否已经打开 	
        For Each a As TabPage In PC410AppOptions.TabControl1.TabPages
            If a.Name = "Tab_form2" Then
                ls_open = True                                              '如果查找到指定的页面
                PC410AppOptions.TabControl1.SelectedTab = a                              '设置选中当前页
            End If
        Next
        '//如果窗体没有打开，那么实例化并打开窗体	
        If ls_open = False Then
            Dim NewTabPage1 As New TabPage                                  '//实例化一个tabpage页
            NewTabPage1.Text = "form2窗体"                                  '//在tabpage页显示的页text内容
            NewTabPage1.Name = "Tab_form2"                                  '//TabPage页的name
            PC410AppOptions.TabControl1.TabPages.Add(NewTabPage1)           '//添加到当前的TabControl中

            Dim ls_frm As New Main                                          '//实例化一个窗体(窗体名称为form2)
            ls_frm.TopLevel = False                                         '//设置窗体不是顶级窗体
            ls_frm.Parent = NewTabPage1                                     '//设置窗体的父容器为新实例化的TabPage页
            ls_frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None     '//设置新窗体不显示边框
            ls_frm.Dock = System.Windows.Forms.DockStyle.Fill               '//设置窗体的大小随父容器大小变化而变化
            ls_frm.Show()                                                  '//装载窗体
            PC410AppOptions.TabControl1.SelectedTab = NewTabPage1           '//将此TabPage页显示为选中
        Else
            MessageBox.Show("窗体已经打开，不要重复打开此窗体！")
        End If
    End Sub

End Class

'程序v0.2.0项目于2018.12.07停止修改（目前问题与之后计划详见ReadMe.txt）



