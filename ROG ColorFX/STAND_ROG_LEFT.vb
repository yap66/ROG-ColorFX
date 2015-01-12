Imports System.IO
Imports System.IO.Ports
Imports System.Threading

Public Class STAND_ROG_LEFT
    Dim VAL_LED_LEFT_RED = 0, VAL_LED_LEFT_GREEN = 0, VAL_LED_LEFT_BLUE = 0

    Private Sub STAND_ROG_LEFT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ROG_FORM.ARDUINO_CONNECT.Write("2,0,0,0,")
        Me.WindowState = FormWindowState.Minimized
        ShowInTaskbar = False
        TIMER_1.Start()
    End Sub

    Private Sub TIMER_1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIMER_1.Tick
        VAL_LED_LEFT_RED = VAL_LED_LEFT_RED + 1
        ROG_FORM.ARDUINO_CONNECT.Write("2," & VAL_LED_LEFT_RED & "," & VAL_LED_LEFT_GREEN & "," & VAL_LED_LEFT_BLUE & ",")
        If VAL_LED_LEFT_RED = 255 Then
            TIMER_1.Stop()
            TIMER_2.Start()
        End If
    End Sub

    Private Sub TIMER_2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIMER_2.Tick
        VAL_LED_LEFT_RED = VAL_LED_LEFT_RED - 1
        VAL_LED_LEFT_GREEN = VAL_LED_LEFT_GREEN + 1
        ROG_FORM.ARDUINO_CONNECT.Write("2," & VAL_LED_LEFT_RED & "," & VAL_LED_LEFT_GREEN & "," & VAL_LED_LEFT_BLUE & ",")
        If VAL_LED_LEFT_GREEN = 255 Then
            TIMER_2.Stop()
            TIMER_3.Start()
        End If
    End Sub

    Private Sub TIMER_3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIMER_3.Tick
        VAL_LED_LEFT_GREEN = VAL_LED_LEFT_GREEN - 1
        VAL_LED_LEFT_BLUE = VAL_LED_LEFT_BLUE + 1
        ROG_FORM.ARDUINO_CONNECT.Write("2," & VAL_LED_LEFT_RED & "," & VAL_LED_LEFT_GREEN & "," & VAL_LED_LEFT_BLUE & ",")
        If VAL_LED_LEFT_BLUE = 255 Then
            TIMER_3.Stop()
            TIMER_4.Start()
        End If
    End Sub

    Private Sub TIMER_4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIMER_4.Tick
        VAL_LED_LEFT_BLUE = VAL_LED_LEFT_BLUE - 1
        VAL_LED_LEFT_RED = VAL_LED_LEFT_RED + 1
        ROG_FORM.ARDUINO_CONNECT.Write("2," & VAL_LED_LEFT_RED & "," & VAL_LED_LEFT_GREEN & "," & VAL_LED_LEFT_BLUE & ",")
        If VAL_LED_LEFT_RED = 255 Then
            TIMER_4.Stop()
            TIMER_2.Start()
        End If
    End Sub


End Class