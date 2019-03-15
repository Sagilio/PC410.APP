
Module PC410AppCommandModule
    Dim buffer As String
    Dim addr1 As String     '地址第一位数
    Dim addr2 As String     '地址第二位数
    Dim ComAdressIsWork As String
    Public strPVD As String     'PV值
    Public strSVD As String     'SV值
    Delegate Sub CallBack(ByVal strCallBack As String)  '定义委托
    Dim callback1 As New CallBack(AddressOf ShowString)
    '用来交换读取显示PV/SV（Timer1使用）
    Public INi_num As Integer
    Public PV_or_SV As Integer '=1 PV  如果=0 SV
    '为读取仪器当前信息需要定义布尔变量
    Public bln_PVandSV As Boolean = False '程序值或测量值，主要由于绘图

    Sub ShowString(ByVal ComData As String)  '显示结果(定义一个实例)
        If bln_PVandSV = True Then
            If PV_or_SV = 1 Then
                Main.TxtbufferShow.AppendText("测量值 " & vbTab & ComData & vbCrLf)
                Main.SeriesPV.Points.AddXY(Main.count_time, ComData)

                WriteTextTxt(Now, vbTab)
                    WriteTextTxt(ComData, vbTab)

                Else
                Main.TxtbufferShow.AppendText("运行目标值：" & vbTab & ComData & vbCrLf)
                Main.seriesSV.Points.AddXY(Main.count_time, ComData)

                WriteTextTxt(ComData, vbCrLf)

                End If
        End If
        bln_PVandSV = False
        If PC410AppOptions.bln_CH = True Then
            Main.TxtbufferShow.AppendText("程序编号：" & vbTab & ComData & vbCrLf)
        End If

        'bln_ch = False

        If PC410AppOptions.bln_OP = True Then
            Main.TxtbufferShow.AppendText("当前功率：" & vbTab & ComData & vbCrLf)
        End If

        'bln_OP = False

        If PC410AppOptions.bln_SE = True Then
            Main.TxtbufferShow.AppendText("当前运行程序段号：" & vbTab & ComData & vbCrLf)
        End If

        'bln_SE = False

    End Sub
    Public Sub DisPlayComData(ByVal strTemp As String)   '判断是否为跨线程
        If Main.TxtbufferShow.InvokeRequired Then
            Main.Invoke(callback1, New Object() {strTemp})
        Else
            Main.TxtbufferShow.AppendText(Now & strTemp & vbCrLf)
        End If
    End Sub
    '接收仪器应答命令帧
    Public Sub SerialPort1_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs)
        Dim i As Integer
        Dim ByteToRead As Integer
        Dim Inbyte() As Byte

        ByteToRead = Main.SerialPort1.BytesToRead
        buffer = ""
        ReDim Inbyte(ByteToRead)
        Main.SerialPort1.Read(Inbyte, 0, ByteToRead)   '读取接收缓冲区内的命令帧
        For i = LBound(Inbyte) To UBound(Inbyte)
            buffer = buffer & Chr("&H" & Hex(Inbyte(i)))
        Next i
        Dim datastring As String = Nothing
        For j As Integer = 1 To buffer.Length - 2
            If IsNumeric(Mid(buffer, j, 1)) = True Then
                datastring = datastring & Mid(buffer, j, 1)
            End If
        Next
        '文本框显示接收到的命令帧
        buffer = ""
        DisPlayComData(datastring)
        datastring = ""
    End Sub

    '发送读取PV命令
    Public Sub SendOrderReadPV()
        Dim OrderPV(8) As Byte
        OrderPV(0) = Val("&H" & "04")
        OrderPV(1) = Val("&H" & addr1)
        OrderPV(2) = Val("&H" & addr1)
        OrderPV(3) = Val("&H" & addr2)
        OrderPV(4) = Val("&H" & addr2)
        OrderPV(5) = Val("&H" & "50")
        OrderPV(6) = Val("&H" & "56")
        OrderPV(7) = Val("&H" & "05")
        Main.SerialPort1.Write(OrderPV, 0, 8) '请求PV值命令(16进制)

        'TxtCommandShow("发送读取PV命令", OrderPV, 7)
    End Sub
    '读取SP数据
    Public Sub SendOrderReadSV()
        Dim OrderSV(8) As Byte
        OrderSV(0) = Val("&H" & "04")
        OrderSV(1) = Val("&H" & addr1)
        OrderSV(2) = Val("&H" & addr1)
        OrderSV(3) = Val("&H" & addr2)
        OrderSV(4) = Val("&H" & addr2)
        OrderSV(5) = Val("&H" & "53")
        OrderSV(6) = Val("&H" & "50")
        OrderSV(7) = Val("&H" & "05")
        Main.SerialPort1.Write(OrderSV, 0, 8)   '读取SV值命令（16进制）

        'TxtCommandShow("读取SP数据", OrderSV, 7)
    End Sub
    '读取输出功率值
    Public Sub SendOrderReadOP()
        Dim OrderSV(8) As Byte
        OrderSV(0) = Val("&H" & "04")
        OrderSV(1) = Val("&H" & addr1)
        OrderSV(2) = Val("&H" & addr1)
        OrderSV(3) = Val("&H" & addr2)
        OrderSV(4) = Val("&H" & addr2)
        OrderSV(5) = Val("&H" & "4F")
        OrderSV(6) = Val("&H" & "50")
        OrderSV(7) = Val("&H" & "05")
        Main.SerialPort1.Write(OrderSV, 0, 8)   '读取SV值命令（16进制）

        'TxtCommandShow("读取输出功率值", OrderSV, 7)
    End Sub
    '读取程序编号
    Public Sub SendOrderReadch()
        Dim OrderSV(8) As Byte
        OrderSV(0) = Val("&H" & "04")
        OrderSV(1) = Val("&H" & addr1)
        OrderSV(2) = Val("&H" & addr1)
        OrderSV(3) = Val("&H" & addr2)
        OrderSV(4) = Val("&H" & addr2)
        OrderSV(5) = Val("&H" & "63")
        OrderSV(6) = Val("&H" & "68")
        OrderSV(7) = Val("&H" & "05")
        Main.SerialPort1.Write(OrderSV, 0, 8)   '读取SV值命令（16进制）

        'TxtCommandShow("读取程序编号", OrderSV, 7)
    End Sub
    '读取当前运行程序段号
    Public Sub SendOrderReadSE()
        Dim OrderSV(8) As Byte
        OrderSV(0) = Val("&H" & "04")
        OrderSV(1) = Val("&H" & addr1)
        OrderSV(2) = Val("&H" & addr1)
        OrderSV(3) = Val("&H" & addr2)
        OrderSV(4) = Val("&H" & addr2)
        OrderSV(5) = Val("&H" & "53")
        OrderSV(6) = Val("&H" & "45")
        OrderSV(7) = Val("&H" & "05")
        Main.SerialPort1.Write(OrderSV, 0, 8)   '读取SV值命令（16进制）

        'TxtCommandShow("读取当前运行程序段号", OrderSV, 7)
    End Sub
    '发送命令
    Public Sub Set_Camand(ByVal Comand_code As String, ByVal Setvalue As String)
        Dim comand_1 As String = Nothing
        Dim comand_2 As String = Nothing
        Dim set_data(6) As String
        If Len(Comand_code) = 2 Then '保证命令代码有效，有效值为2位ASCII
            '如果命令有效，提取字符并转为十六进制数
            comand_1 = Hex(Asc(Mid(Comand_code, 1, 1))) '提取命令值并转成可以用的十六进制数据
            comand_2 = Hex(Asc(Mid(Comand_code, 2, 1)))
        Else
            MsgBox("输入命令有误，请查正！")
        End If
        '判断输入的数据位，数据最长为7位。
        If IsNumeric(Setvalue) = True Then
            If Len(Setvalue) < 8 Then
                Setvalue = Setvalue.ToString.PadLeft(7, “0"c) '如果数据不足七位，以零补齐七位
                For i As Integer = 0 To Setvalue.Length - 1
                    set_data(i) = Hex(Asc(Mid(Setvalue, 1 + i, 1)))
                Next
            End If
            Dim OrderSet(17) As Byte
            Dim BCC, BCCTemp As String
            OrderSet(0) = Val("&H" & "04") '命令的开始位（EOT）
            OrderSet(1) = Val("&H" & addr1) '命令的地位开始位（十六进制）
            OrderSet(2) = Val("&H" & addr1) '命令的地位开始位（十六进制）
            OrderSet(3) = Val("&H" & addr2) '命令的地位第二位（十六进制）
            OrderSet(4) = Val("&H" & addr2) '命令的地位第二位（十六进制）
            OrderSet(5) = Val("&H" & "02") '命令的间隔位（STX）
            OrderSet(6) = Val("&H" & comand_1) '命令符
            OrderSet(7) = Val("&H" & comand_2) '命令符
            OrderSet(8) = Val("&H" & set_data(0)) '参数位1
            OrderSet(9) = Val("&H" & set_data(1)) '参数位2
            OrderSet(10) = Val("&H" & set_data(2)) '参数位3
            OrderSet(11) = Val("&H" & set_data(3)) '参数位4
            OrderSet(12) = Val("&H" & set_data(4)) '参数位5
            OrderSet(13) = Val("&H" & set_data(5)) '参数位6
            OrderSet(14) = Val("&H" & set_data(6)) '参数位7
            OrderSet(15) = Val("&H" & "03") '停止位（ETX)
            '计算命令的校验位
            BCCTemp = Convert.ToByte(comand_1, 16) Xor Convert.ToByte(comand_2, 16) Xor Convert.ToByte(set_data(0), 16) Xor Convert.ToByte(set_data(1), 16) Xor Convert.ToByte(set_data(2), 16) Xor Convert.ToByte(set_data(3), 16) Xor Convert.ToByte(set_data(4), 16) Xor Convert.ToByte(set_data(5), 16) Xor Convert.ToByte(set_data(6), 16) Xor Convert.ToByte("03", 16)  '计算BCC的值
            BCC = Hex(BCCTemp)
            OrderSet(16) = Val("&H" & BCC) '命令校验位
            '发送修改SV值的命令(16进制)
            Main.SerialPort1.Write(OrderSet, 0, 17)
            Main.GetparameterIsTrue = True
        Else
            MsgBox("输入参数不正确，请重新输入！")
            Main.GetparameterIsTrue = False
        End If
    End Sub

    Public Function AutoSetButComAddress(ByVal ButComAddress As String) As Boolean
        Dim t1, t2 As Char
        Dim i As Integer = 0
        t1 = Mid(ButComAddress, 1, 1)
        t2 = Mid(ButComAddress, 2, 1)
        addr1 = Hex(Asc(Val(t1)))
        addr2 = Hex(Asc(Val(t2)))

        '下面开始读取仪器的基本状态值 
        bln_PVandSV = True

        PV_or_SV = 1
        SendOrderReadPV()

        System.Threading.Thread.Sleep(500)

        If CommandIsWork() = True Then
            i = i + 1
        Else
            Return False
            Exit Function
        End If

        Main.SerialPort1.DiscardOutBuffer()
        Main.SerialPort1.DiscardInBuffer()

        PV_or_SV = 0
        SendOrderReadSV()

        System.Threading.Thread.Sleep(500)

        If CommandIsWork() = True Then
            i = i + 1
        Else
            Return False
            Exit Function
        End If

        Main.SerialPort1.DiscardOutBuffer()
        Main.SerialPort1.DiscardInBuffer()

        If PC410AppOptions.bln_CH = True Then
            SendOrderReadch()
        Else
            PC410AppOptions.bln_CH = True
            SendOrderReadch()
            PC410AppOptions.bln_CH = False
        End If
        If CommandIsWork() = True Then
            i = i + 1
        Else
            Return False
            Exit Function
        End If

        System.Threading.Thread.Sleep(500)
        Main.SerialPort1.DiscardOutBuffer()
        Main.SerialPort1.DiscardInBuffer()

        PC410AppOptions.bln_OP = True
        If PC410AppOptions.bln_OP = True Then
            SendOrderReadOP()
        Else
            PC410AppOptions.bln_OP = True
            SendOrderReadOP()
            PC410AppOptions.bln_OP = False
        End If
        If CommandIsWork() = True Then
            i = i + 1
        Else
            Return False
            Exit Function
        End If
        SendOrderReadOP()

        System.Threading.Thread.Sleep(300)
        Main.SerialPort1.DiscardOutBuffer()
        Main.SerialPort1.DiscardInBuffer()

        If PC410AppOptions.bln_SE = True Then
            SendOrderReadSE()
        Else
            PC410AppOptions.bln_SE = True
            SendOrderReadSE()
            PC410AppOptions.bln_SE = False
        End If
        If CommandIsWork() = True Then
            i = i + 1
        Else
            Return False
            Exit Function
        End If

        System.Threading.Thread.Sleep(300)
        Main.SerialPort1.DiscardOutBuffer()
        Main.SerialPort1.DiscardInBuffer()

        If i = 3 Then
            ComAdressIsWork = True
            Return True
        End If
        Return False
    End Function

    Public Sub SetButComAddress(ByVal ButComAddress As String)
        Dim t1, t2 As Char
        Dim i As Integer = 0
        t1 = Mid(PC410AppOptions.TxtAddress.Text, 1, 1)
        t2 = Mid(PC410AppOptions.TxtAddress.Text, 2, 1)
        addr1 = Hex(Asc(Val(t1)))
        addr2 = Hex(Asc(Val(t2)))

        '下面开始读取仪器的基本状态值 
        bln_PVandSV = True

        PV_or_SV = 1
        SendOrderReadPV()

        System.Threading.Thread.Sleep(300)

        Main.SerialPort1.DiscardOutBuffer()
        Main.SerialPort1.DiscardInBuffer()

        PV_or_SV = 0
        SendOrderReadSV()

        System.Threading.Thread.Sleep(300)

        Main.SerialPort1.DiscardOutBuffer()
        Main.SerialPort1.DiscardInBuffer()

        System.Threading.Thread.Sleep(300)
        Main.SerialPort1.DiscardOutBuffer()
        Main.SerialPort1.DiscardInBuffer()

        SendOrderReadOP()

        System.Threading.Thread.Sleep(300)
        Main.SerialPort1.DiscardOutBuffer()
        Main.SerialPort1.DiscardInBuffer()

        System.Threading.Thread.Sleep(300)
        Main.SerialPort1.DiscardOutBuffer()
        Main.SerialPort1.DiscardInBuffer()

    End Sub
    '判断返回值是否正确的，如果命令参数已经在仪器上修改成功，则返回6否则返回15
    Public Sub SetSuccess()
        Dim strRx As String
        If Main.SerialPort1.BytesToRead > 0 Then
            strRx = Main.SerialPort1.ReadExisting.ToString    '读取来自串口的接收缓冲区的全部数据
            If Hex(Asc(strRx)) = "6" Then
                Main.TxtbufferShow.AppendText("命令参数已经修改成功！" & vbCrLf)
            End If
            If Hex(Asc(strRx)) = "15" Then
                Main.TxtbufferShow.AppendText("命令参数修改出现问题，请重新修改！" & vbCrLf)
                MsgBox("命令参数修改出现问题，请重新修改！", MsgBoxStyle.Critical, "警告"）
            End If
            Main.SerialPort1.DiscardInBuffer()    '丢弃来自串口的接收缓冲区的数据
            Main.GetSuccessIsTrue = True
        Else
            Main.GetSuccessIsTrue = False
        End If
    End Sub

    Public Function CommandIsWork() As Boolean
        Dim strRx As String
        Dim SuccesIsTrue As Boolean = False

        If Main.SerialPort1.BytesToRead > 0 Then
            strRx = Main.SerialPort1.ReadExisting.ToString
            Hex(Asc(strRx))
            If Hex(Asc(strRx)) = "6" Then
                SuccesIsTrue = True
            End If
            If Hex(Asc(strRx)) = "15" Then
                SuccesIsTrue = False
            End If
        Else

        End If

        Return SuccesIsTrue
    End Function

    Private Sub TxtCommandShow(ByVal Content As String, ByVal CommandType As Byte(), ByVal Count As Integer)
        Dim i As Integer
        Main.TxtbufferShow.AppendText(Content & ":")
        For i = 0 To Count
            Main.TxtbufferShow.AppendText(CommandType(i) & " ")
        Next
        Main.TxtbufferShow.AppendText(vbCrLf)
    End Sub
    Public Sub TestAllCommand()
        SendOrderReadch()
        SendOrderReadOP()
        SendOrderReadPV()
        SendOrderReadSE()
        SendOrderReadSV()
    End Sub
End Module
