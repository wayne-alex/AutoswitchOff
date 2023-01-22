Public Class Form1

    Dim checked As Boolean = False
    Dim clicked As Boolean = False
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        ListBox1.Items.Clear()

        For Each proc As Process In Process.GetProcesses
            ListBox1.Items.Add(proc.ProcessName)
        Next
        ListBox1.Visible = True
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.Visible = False
        For Each proc As Process In Process.GetProcesses
            ListBox1.Items.Add(proc.ProcessName)
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim pName As String
        pName = ListBox1.SelectedItem
        ListBox1.Visible = False
        Guna2TextBox1.Text = pName
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        If clicked = False Then
            clicked = True
            Guna2Button1.Enabled = False
            Guna2TextBox1.Enabled = False
            Guna2Button2.FillColor = Color.Red
            Guna2Button2.Text = "stop"
            Timer1.Start()
        Else
            clicked = False
            Guna2Button1.Enabled = True
            Guna2TextBox1.Enabled = True
            Guna2Button2.FillColor = Color.Blue
            Guna2Button2.Text = "set Event"
            Timer1.Stop()

        End If


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Guna2ProgressBar1.Value += 1
        If Guna2ProgressBar1.Value = 2 Then
            Guna2ProgressBar1.Value = 0

            Dim p() As Process
            p = Process.GetProcessesByName(Guna2TextBox1.Text)
            If p.Count > 0 Then
                ToolStripStatusLabel1.Text = "process still running"

            Else
                ToolStripStatusLabel1.Text = "process not running"
                If checked = True Then
                    Process.Start("shutdown", "-s -t 00")
                End If
            End If

        End If

    End Sub

    Private Sub Guna2CircleButton1_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton1.Click
        Me.Close()
    End Sub

    Private Sub Guna2CircleButton2_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton2.Click
        MsgBox("operation not allowed")
    End Sub

    Private Sub Guna2CircleButton3_Click(sender As Object, e As EventArgs) Handles Guna2CircleButton3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Guna2CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox1.CheckedChanged
        If Guna2CheckBox1.Checked = True Then
        Else

        End If
    End Sub
End Class
