Public Class LOADING
    Dim VAL_LOAD = 0
    Private Sub LOADING_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ROG_FORM.Show()
        TIMER_LOADING.Start()
    End Sub


    Private Sub TIMER_LOADING_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIMER_LOADING.Tick
        VAL_LOAD = VAL_LOAD + 10
        LOADER.Size = New Size(VAL_LOAD, 50)
        If VAL_LOAD >= 1366 Then
            VAL_LOAD = 0
            TIMER_LOADING.Stop()

            Me.Close()
        End If
    End Sub
End Class