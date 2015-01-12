Imports LightFX
Imports System
Imports System.Text

Public Class STAND_ALIENWARE
    Dim lightFX = New LightFXController(), result = lightFX.LFX_Initialize()

    Dim color00 As New LFX_ColorStruct(255, 0, 0, 0)
    Dim color01 As New LFX_ColorStruct(255, 255, 255, 255)
    Dim color02 As New LFX_ColorStruct(255, 0, 255, 255)
    Dim color03 As New LFX_ColorStruct(255, 0, 255, 170)
    Dim color04 As New LFX_ColorStruct(255, 0, 255, 102)
    Dim color05 As New LFX_ColorStruct(255, 0, 255, 0)
    Dim color06 As New LFX_ColorStruct(255, 170, 255, 0)
    Dim color07 As New LFX_ColorStruct(255, 221, 255, 0)
    Dim color08 As New LFX_ColorStruct(255, 255, 238, 0)
    Dim color09 As New LFX_ColorStruct(255, 255, 136, 0)
    Dim color10 As New LFX_ColorStruct(255, 255, 85, 0)
    Dim color11 As New LFX_ColorStruct(255, 255, 0, 0)
    Dim color12 As New LFX_ColorStruct(255, 255, 0, 119)
    Dim color13 As New LFX_ColorStruct(255, 255, 0, 187)
    Dim color14 As New LFX_ColorStruct(255, 255, 0, 255)
    Dim color15 As New LFX_ColorStruct(255, 153, 0, 255)
    Dim color16 As New LFX_ColorStruct(255, 85, 0, 255)
    Dim color17 As New LFX_ColorStruct(255, 0, 0, 255)
    Dim color18 As New LFX_ColorStruct(255, 0, 102, 255)
    Dim color19 As New LFX_ColorStruct(255, 0, 170, 255)

    Dim color_val = 1

    Private Sub STAND_ALIENWARE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Minimized
        ShowInTaskbar = False
        If result = LFX_Result.LFX_Success Then
            lightFX.LFX_Reset()
            C1.Start()
        End If
    End Sub

    Private Sub C1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color01)
        lightFX.LFX_Update()
        C1.Stop()
        C2.Start()
    End Sub

    Private Sub C2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C2.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color02)
        lightFX.LFX_Update()
        C2.Stop()
        C3.Start()
    End Sub

    Private Sub C3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C3.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color03)
        lightFX.LFX_Update()
        C3.Stop()
        C4.Start()
    End Sub

    Private Sub C4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C4.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color04)
        lightFX.LFX_Update()
        C4.Stop()
        C5.Start()
    End Sub

    Private Sub C5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C5.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color05)
        lightFX.LFX_Update()
        C5.Stop()
        C6.Start()
    End Sub

    Private Sub C6_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C6.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color06)
        lightFX.LFX_Update()
        C6.Stop()
        C7.Start()
    End Sub

    Private Sub C7_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C7.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color07)
        lightFX.LFX_Update()
        C7.Stop()
        C8.Start()
    End Sub

    Private Sub C8_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C8.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color08)
        lightFX.LFX_Update()
        C8.Stop()
        C9.Start()
    End Sub

    Private Sub C9_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C9.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color09)
        lightFX.LFX_Update()
        C9.Stop()
        C10.Start()
    End Sub

    Private Sub C10_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C10.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color10)
        lightFX.LFX_Update()
        C10.Stop()
        C11.Start()
    End Sub

    Private Sub C11_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C11.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color11)
        lightFX.LFX_Update()
        C11.Stop()
        C12.Start()
    End Sub

    Private Sub C12_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C12.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color12)
        lightFX.LFX_Update()
        C12.Stop()
        C13.Start()
    End Sub

    Private Sub C13_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C13.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color13)
        lightFX.LFX_Update()
        C13.Stop()
        C14.Start()
    End Sub

    Private Sub C14_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C14.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color14)
        lightFX.LFX_Update()
        C14.Stop()
        C15.Start()
    End Sub

    Private Sub C15_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C15.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color15)
        lightFX.LFX_Update()
        C15.Stop()
        C16.Start()
    End Sub

    Private Sub C16_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C16.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color16)
        lightFX.LFX_Update()
        C16.Stop()
        C17.Start()
    End Sub

    Private Sub C17_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C17.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color17)
        lightFX.LFX_Update()
        C17.Stop()
        C18.Start()
    End Sub

    Private Sub C18_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C18.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color18)
        lightFX.LFX_Update()
        C18.Stop()
        C19.Start()
    End Sub

    Private Sub C19_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C19.Tick
        lightFX.LFX_Light(LFX_Position.LFX_All, color19)
        lightFX.LFX_Update()
        C19.Stop()
        C1.Start()
    End Sub
End Class