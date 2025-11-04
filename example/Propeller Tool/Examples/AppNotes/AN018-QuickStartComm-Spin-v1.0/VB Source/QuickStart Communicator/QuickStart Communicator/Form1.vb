Public Class frmMain

#Region "Initialize, Open and Close Serial Port"


    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        For Each portName As String In My.Computer.Ports.SerialPortNames    ' Populate Port Names in Combo Box
            cboPortName.Items.Add(portName)
        Next

        cboBaudRate.Items.Add("1200")                                       ' Populate Baud Rates in Combo Box
        cboBaudRate.Items.Add("2400")
        cboBaudRate.Items.Add("4800")
        cboBaudRate.Items.Add("9600")
        cboBaudRate.Items.Add("19200")
        cboBaudRate.Items.Add("38400")
        cboBaudRate.Items.Add("57600")
        cboBaudRate.Items.Add("115200")

        If cboPortName.Items.Count = Nothing Then
            If MsgBox("No Serial Ports Found!", MessageBoxButtons.OK + MessageBoxIcon.Warning, "Error") = Windows.Forms.DialogResult.OK Then
                Me.Close()
            End If
        Else
            cboPortName.Text = SerialPort1.PortName                         ' Show default Port
            cboBaudRate.Text = SerialPort1.BaudRate                         ' Show default Baud Rate
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenClose.Click

        If Not SerialPort1.IsOpen Then                                      ' Be sure Serial Port is not already open
            Try
                SerialPort1.PortName = cboPortName.Text                     ' Set Port
                SerialPort1.BaudRate = cboBaudRate.Text                     ' Set Baud Rate
                SerialPort1.Open()                                          ' Open Serial Port
                btnOpenClose.Text = "Close Port"                            ' Change text on button
                cboPortName.Enabled = False                                 ' Disable Combo Boxes
                cboBaudRate.Enabled = False                                 ' To prevent changing settings while Port open
            Catch ex As Exception                                           ' Handle Exceptions
                MsgBox("Port Unavailable!", MessageBoxButtons.OK + MessageBoxIcon.Warning, "Error")
            End Try
        Else
            SerialPort1.Close()                                             ' Close Serial Port
            btnOpenClose.Text = "Open Port"                                 ' Change text on button
            cboPortName.Enabled = True                                      ' Re-enable Combo Boxes
            cboBaudRate.Enabled = True
            picPortStatus.BackColor = Color.Transparent                     ' Update 
            lblPortStatus.Text = "Idle"                                     ' Port Status
        End If

    End Sub

#End Region

#Region "Communication"

    Dim Data_In(16) As Byte                                                 ' 16 byte array for incoming data
    Dim Data_Out(16) As Byte                                                ' 16 byte array for outgoing data

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If SerialPort1.IsOpen Then                                          ' Ensure Serial Port is open
            SerialPort1.DiscardInBuffer()                                   ' Flush serial input buffer
            SerialPort1.WriteLine("!VB")                                    ' Send prefix to Propeller
            SerialPort1.Write(Data_Out, 0, 16)                              ' Send 16 byte array to Propeller

            Dim header As String
            Try
                SerialPort1.ReadTimeout = 50                                ' 50ms timeout @ 38.4Kbps
                header = SerialPort1.ReadLine()                             ' Wait for header from Propeller

                If header = "!P1" Then                                      ' Test for correct header
                    Threading.Thread.Sleep(10)                              ' Allow time for all 16 bytes to arrive in buffer
                    SerialPort1.Read(Data_In, 0, 16)                        ' Read 16 bytes into input array
                    TextOut(Data_In)                                        ' Call TextOut sub
                    picPortStatus.BackColor = Color.Green                   ' Update
                    lblPortStatus.Text = "Active"                           ' Port Status
                Else
                    picPortStatus.BackColor = Color.Red                     ' Update
                    lblPortStatus.Text = "Inactive"                         ' Port Status
                End If
            Catch ex As Exception
                picPortStatus.BackColor = Color.Yellow                      ' Update
                lblPortStatus.Text = "Waiting..."                           ' Port Status
                Threading.Thread.Sleep(100)                                 ' Prevent Lock-Up
            End Try
            header = ""                                                     ' Clear header variable for next test

        End If

    End Sub

    Private Sub TextOut(ByVal x() As Byte)

        ' This is the section where the user should define incoming and outgoing data
        ' Examples below show how to encode 8 Check Boxes into a single byte as well as
        ' how to decode bit data from the Propeller.  Byte data can be applied to directly
        ' to Text Boxes and other controls on the main form.  Form data such as TrackBar
        ' values can be send by assigning directly to array variables.


        ' VB.NET does not include direct bit testing so the following converts 8 Check Boxes into a single byte
        Data_Out(0) = 0                                                     ' Clear Variable
        Data_Out(0) = Data_Out(0) + chkLED0.CheckState                      ' Add 2^1
        Data_Out(0) = Data_Out(0) + chkLED1.CheckState * 2                  ' Add 2^2
        Data_Out(0) = Data_Out(0) + chkLED2.CheckState * 4                  ' Add 2^4
        Data_Out(0) = Data_Out(0) + chkLED3.CheckState * 8                  ' Add 2^8
        Data_Out(0) = Data_Out(0) + chkLED4.CheckState * 16                 ' Add 2^16
        Data_Out(0) = Data_Out(0) + chkLED5.CheckState * 32                 ' Add 2^32
        Data_Out(0) = Data_Out(0) + chkLED6.CheckState * 64                 ' Add 2^64
        Data_Out(0) = Data_Out(0) + chkLED7.CheckState * 128                ' Add 2^128

        ' The following decodes bit data from the Propeller to display blue picture boxes representing activation of
        ' the LEDs on the Propeller.  Note that the Checkbox control does not directly affect the Picture visible
        ' property...the data comes from the Propeller demonstrating an excellent way to get an acknowledgment from
        ' the Propeller for commands sent to it by the VB.NET application.
        picLED0.Visible = Data_In(0) And 1                                  ' Test bit in this position of the byte
        picLED1.Visible = Data_In(0) And 2
        picLED2.Visible = Data_In(0) And 4
        picLED3.Visible = Data_In(0) And 8
        picLED4.Visible = Data_In(0) And 16
        picLED5.Visible = Data_In(0) And 32
        picLED6.Visible = Data_In(0) And 64
        picLED7.Visible = Data_In(0) And 128

        ' The following decodes bit data from the Propeller to display peach picture boxes representing activation of
        ' the touch pads on the QuickStart board.
        picButton0.Visible = Data_In(1) And 1                               ' Test bit in this position of the byte
        picButton1.Visible = Data_In(1) And 2
        picButton2.Visible = Data_In(1) And 4
        picButton3.Visible = Data_In(1) And 8
        picButton4.Visible = Data_In(1) And 16
        picButton5.Visible = Data_In(1) And 32
        picButton6.Visible = Data_In(1) And 64
        picButton7.Visible = Data_In(1) And 128

    End Sub

#End Region


End Class
