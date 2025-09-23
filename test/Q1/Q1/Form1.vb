Public Class Form1
    Dim a, r(8), g(16), rr, gg As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        a = 1 : gg = 0
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        a = 2 : rr = 0
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SerialPort1.Close() : End
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If SerialPort1.IsOpen Then
            ledoff()
            Button4.Text = "connect bluetooth"
            SerialPort1.Close()
        Else
            SerialPort1.Open()
            ledoff()
            Button4.Text = "disconnect bluetooth"
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim s = ShapeContainer1.Shapes
        Label1.Text = "current time:" + TimeString
        r = {&H1, &H2, &H4, &H8, &H10, &H20, &H40, &H80, 0}
        g = {&H1, &H2, &H4, &H8, &H10, &H20, &H40, &H80, &H40, &H20, &H10, &H8, &H4, &H2, &H1, 0}
        If SerialPort1.IsOpen Then
            For i = 0 To 7
                s(i).fillcolor = Color.DarkRed
                s(i + 8).fillcolor = Color.DarkGreen
            Next
            ledoff()
            For i = 0 To 10 ^ 7
            Next
            If a = 1 And g(gg) > 0 Then
                SerialPort1.Write("G" & g(gg))
                Display(8, g(gg))
                gg += 1
            End If
            If a = 2 And r(rr) > 0 Then
                SerialPort1.Write("R" & r(rr))
                display(0, r(rr))
                rr += 1
            End If
        Else
            For i = 0 To 15
                s(i).fillcolor = Color.Transparent
            Next
        End If
    End Sub
    Private Sub ledoff()
        SerialPort1.Write("R0")
        SerialPort1.Write("G0")
    End Sub
    Private Sub display(ByVal p, ByVal no)
        Dim s = ShapeContainer1.Shapes
        For i = p To p + 7
            If no Mod 2 = 1 And a = 1 Then s(i).fillcolor = Color.GreenYellow
            If no Mod 2 = 1 And a = 2 Then s(i).fillcolor = Color.Red
            no = no \ 2
        Next
    End Sub
End Class
