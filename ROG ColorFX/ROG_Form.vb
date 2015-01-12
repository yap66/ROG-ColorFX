Imports LightFX
Imports System
Imports System.Text
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Xml
Imports CoreAudioApi

Public Class ROG_FORM

    Dim deviceCapture As MMDevice : Dim deviceRender As MMDevice : Dim DevEnum As New MMDeviceEnumerator(), _Channels As New Channels

    Dim lightFX = New LightFXController(), result = LightFX.LFX_Initialize()

    Dim COLOR2_RED, COLOR2_GREEN, COLOR2_BLUE
    Dim COLOR1_RED, COLOR1_GREEN, COLOR1_BLUE
    Dim CONFIG_COM, CONFIG_ALIENWARE

    '============================'
    ' CHANNELS VOLUME            '
    '============================'
    Structure Channels
        Public GET_IN_Master As Integer
        Public GET_IN_LeftChannel As Integer
        Public GET_IN_RightChannel As Integer

        Public GET_OUT_Master As Integer
        Public GET_OUT_LeftChannel As Integer
        Public GET_OUT_RightChannel As Integer

        Public SET_IN_MASTER As Integer
        Public SET_OUT_MASTER As Integer

        Public IN_MUTED As Boolean
        Public OUT_MUTED As Boolean
    End Structure



    '============================'
    ' LOADING FORM               '
    '============================'
    Private Sub ROG_FORM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Txt = Dir("configROG.xml")
        If Txt = "" Then
            WitterFileXML("configROG.xml", "0", "0", "0", "0", "0", "0", "COM3", "0")
        End If

        Dim document As XmlReader = New XmlTextReader("configROG.xml")

        While (document.Read())
            Dim type = document.NodeType
            If (type = XmlNodeType.Element) Then
                If (document.Name = "COLOR2_RED") Then
                    COLOR2_RED = document.ReadInnerXml.ToString()
                End If
                If (document.Name = "COLOR2_GREEN") Then
                    COLOR2_GREEN = document.ReadInnerXml.ToString()
                End If
                If (document.Name = "COLOR2_BLUE") Then
                    COLOR2_BLUE = document.ReadInnerXml.ToString()
                End If

                If (document.Name = "COLOR1_RED") Then
                    COLOR1_RED = document.ReadInnerXml.ToString()
                End If
                If (document.Name = "COLOR1_GREEN") Then
                    COLOR1_GREEN = document.ReadInnerXml.ToString()
                End If
                If (document.Name = "COLOR1_BLUE") Then
                    COLOR1_BLUE = document.ReadInnerXml.ToString()
                End If

                If (document.Name = "CONFIG_COM") Then
                    CONFIG_COM = document.ReadInnerXml.ToString()
                End If
                If (document.Name = "CONFIG_ALIENWARE") Then
                    CONFIG_ALIENWARE = document.ReadInnerXml.ToString()
                End If

            End If
        End While

        ARDUINO_CONNECT.PortName = CONFIG_COM
        ARDUINO_CONNECT.Open()

        deviceCapture = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eMultimedia)
        deviceRender = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia)

        ARDUINO_CONNECT.Write("2," & COLOR2_RED & "," & COLOR2_GREEN & "," & COLOR2_BLUE & ",")
        ARDUINO_CONNECT.Write("1," & COLOR1_RED & "," & COLOR1_GREEN & "," & COLOR1_BLUE & ",")
        MUSIC_LEFT.Size = New Size(61, 0)
        MUSIC_RIGHT.Size = New Size(61, 0)
    End Sub

    '============================'
    ' File XML                   '
    '============================'
    Function WitterFileXML(
        ByVal XMLFile As String,
        ByVal COLOR2_RED As String, ByVal COLOR2_GREEN As String, ByVal COLOR2_BLUE As String,
        ByVal COLOR1_RED As String, ByVal COLOR1_GREEN As String, ByVal COLOR1_BLUE As String,
        ByVal CONFIG_COM As String, ByVal CONFIG_ALIENWARE As String) As String

        Dim settings As New XmlWriterSettings()
        settings.Indent = True

        Dim XmlWrt As XmlWriter = XmlWriter.Create(XMLFile, settings)
        With XmlWrt

            ' Write the Xml declaration.
            .WriteStartDocument()

            ' Write a comment.
            .WriteComment("XML Database.")

            ' Write the root element.
            .WriteStartElement("DATA")

            ' Star color 2
            .WriteStartElement("COLOR2_RED")
            .WriteString(COLOR2_RED)
            .WriteEndElement()
            .WriteStartElement("COLOR2_GREEN")
            .WriteString(COLOR2_GREEN)
            .WriteEndElement()
            .WriteStartElement("COLOR2_BLUE")
            .WriteString(COLOR2_BLUE)
            .WriteEndElement()

            ' Star color 2
            .WriteStartElement("COLOR1_RED")
            .WriteString(COLOR1_RED)
            .WriteEndElement()
            .WriteStartElement("COLOR1_GREEN")
            .WriteString(COLOR1_GREEN)
            .WriteEndElement()
            .WriteStartElement("COLOR1_BLUE")
            .WriteString(COLOR1_BLUE)
            .WriteEndElement()

            'config
            .WriteStartElement("CONFIG_COM")
            .WriteString(CONFIG_COM)
            .WriteEndElement()
            .WriteStartElement("CONFIG_ALIENWARE")
            .WriteString(CONFIG_ALIENWARE)
            .WriteEndElement()

            ' The end of this person.
            .WriteEndElement()
            .WriteEndDocument()
            .Close()

        End With
        Return ""
    End Function

    Protected Overrides Sub OnLocationChanged(ByVal e As System.EventArgs)
        If WindowState = FormWindowState.Normal Then
            LOADING.ShowDialog()
        End If
        MyBase.OnLocationChanged(e)
    End Sub

    '============================'
    ' LAUNCHER TIMER             '
    '============================'
    Private Sub ROG_PLAY_MUSIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_PLAY_MUSIC.Click
        lightFX.LFX_Release()
        ROG_TIMER_MUSIC.Start()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        ROG_MODE.Text = "Music mod"
    End Sub
    Private Sub ROG_STANDBY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_STANDBY.Click
        Dim document As XmlReader = New XmlTextReader("configROG.xml")

        While (document.Read())
            Dim type = document.NodeType
            If (type = XmlNodeType.Element) Then

                If (document.Name = "CONFIG_COM") Then
                    CONFIG_COM = document.ReadInnerXml.ToString()
                End If
                If (document.Name = "CONFIG_ALIENWARE") Then
                    CONFIG_ALIENWARE = document.ReadInnerXml.ToString()
                End If

            End If
        End While
        Me.WindowState = FormWindowState.Minimized
        ShowInTaskbar = False
        ROG_TIMER_MUSIC.Stop()
        If CONFIG_ALIENWARE = 1 Then
            STAND_ALIENWARE.Show()
        End If
        STAND_ROG_LEFT.Show()
        STAND_ROG_RIGHT.Show()

        ROG_MODE.Text = "StandBy mod"
    End Sub
    Private Sub ROG_ABOUT_ME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_ABOUT_ME.Click
        lightFX.LFX_Release()
        ROG_TIMER_MUSIC.Stop()
        LOADING.Close()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        A.ShowDialog()
    End Sub
    Private Sub ROG_RETRACTED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_RETRACTED.Click
        Me.WindowState = FormWindowState.Minimized
        ShowInTaskbar = False
    End Sub
    Private Sub ROG_CLOSED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_CLOSED.Click, MENU_CLOSE.Click
        lightFX.LFX_Release()
        Thread.Sleep(5000)
        ROG_TIMER_MUSIC.Stop()
        LOADING.Close()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        Me.Close()
        End
    End Sub
    Private Sub ROG_RESET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_RESET.Click, MENU_RESET.Click
        Dim document As XmlReader = New XmlTextReader("configROG.xml")

        While (document.Read())
            Dim type = document.NodeType
            If (type = XmlNodeType.Element) Then

                If (document.Name = "CONFIG_COM") Then
                    CONFIG_COM = document.ReadInnerXml.ToString()
                End If
                If (document.Name = "CONFIG_ALIENWARE") Then
                    CONFIG_ALIENWARE = document.ReadInnerXml.ToString()
                End If

            End If
        End While
        document.Close()
        WitterFileXML("configROG.xml", COLOR2_RED, COLOR2_GREEN, COLOR2_BLUE, COLOR1_RED, COLOR1_GREEN, COLOR1_BLUE, CONFIG_COM, CONFIG_ALIENWARE)
        lightFX.LFX_Release()
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        ROG_MODE.Text = "Reset"
        ARDUINO_CONNECT.Write("2," & COLOR2_RED & "," & COLOR2_GREEN & "," & COLOR2_BLUE & ",")
        ARDUINO_CONNECT.Write("1," & COLOR1_RED & "," & COLOR1_GREEN & "," & COLOR1_BLUE & ",")
        MUSIC_LEFT.Size = New Size(61, 0)
        MUSIC_RIGHT.Size = New Size(61, 0)
    End Sub
    Private Sub ROG_NOTIF_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ROG_NOTIF.MouseDoubleClick
        ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    '============================'
    ' COLOR2 FX                  '
    '============================'
    Private Sub ROG_COLOR2_0_0_255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_0_0_255.Click
        ARDUINO_CONNECT.Write("2,0,0,255,")
        COLOR2_RED = 0
        COLOR2_GREEN = 0
        COLOR2_BLUE = 255
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_0_102_255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_0_102_255.Click
        ARDUINO_CONNECT.Write("2,0,102,255,")
        COLOR2_RED = 0
        COLOR2_GREEN = 102
        COLOR2_BLUE = 255
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_0_170_255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_0_170_255.Click
        ARDUINO_CONNECT.Write("2,0,170,255,")
        COLOR2_RED = 0
        COLOR2_GREEN = 170
        COLOR2_BLUE = 255
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_0_255_255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_0_255_255.Click
        ARDUINO_CONNECT.Write("2,0,255,255,")
        COLOR2_RED = 0
        COLOR2_GREEN = 255
        COLOR2_BLUE = 255
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_74_255_152_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_74_255_152.Click
        ARDUINO_CONNECT.Write("2,74,255,152,")
        COLOR2_RED = 74
        COLOR2_GREEN = 255
        COLOR2_BLUE = 152
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_0_255_93_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_0_255_93.Click
        ARDUINO_CONNECT.Write("2,0,255,93,")
        COLOR2_RED = 0
        COLOR2_GREEN = 255
        COLOR2_BLUE = 93
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_0_255_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_0_255_0.Click
        ARDUINO_CONNECT.Write("2,0,255,0,")
        COLOR2_RED = 0
        COLOR2_GREEN = 255
        COLOR2_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_107_255_38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_107_255_38.Click
        ARDUINO_CONNECT.Write("2,107,255,38,")
        COLOR2_RED = 107
        COLOR2_GREEN = 255
        COLOR2_BLUE = 38
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_170_255_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_170_255_0.Click
        ARDUINO_CONNECT.Write("2,170,255,0,")
        COLOR2_RED = 170
        COLOR2_GREEN = 255
        COLOR2_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_255_255_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_255_255_0.Click
        ARDUINO_CONNECT.Write("2,255,255,0,")
        COLOR2_RED = 255
        COLOR2_GREEN = 255
        COLOR2_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_255_238_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_255_238_0.Click
        ARDUINO_CONNECT.Write("2,255,238,0,")
        COLOR2_RED = 255
        COLOR2_GREEN = 238
        COLOR2_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_255_132_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_255_132_0.Click
        ARDUINO_CONNECT.Write("2,255,132,0,")
        COLOR2_RED = 255
        COLOR2_GREEN = 132
        COLOR2_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_255_85_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_255_85_0.Click
        ARDUINO_CONNECT.Write("2,255,85,0,")
        COLOR2_RED = 255
        COLOR2_GREEN = 85
        COLOR2_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_255_0_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_255_0_0.Click
        ARDUINO_CONNECT.Write("2,255,0,0,")
        COLOR2_RED = 255
        COLOR2_GREEN = 0
        COLOR2_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_255_0_119_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_255_0_119.Click
        ARDUINO_CONNECT.Write("2,255,0,119,")
        COLOR2_RED = 255
        COLOR2_GREEN = 0
        COLOR2_BLUE = 119
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_255_0_187_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_255_0_187.Click
        ARDUINO_CONNECT.Write("2,255,0,187,")
        COLOR2_RED = 255
        COLOR2_GREEN = 0
        COLOR2_BLUE = 187
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_255_0_255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_255_0_255.Click
        ARDUINO_CONNECT.Write("2,255,0,255,")
        COLOR2_RED = 255
        COLOR2_GREEN = 0
        COLOR2_BLUE = 255
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_153_0_255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_153_0_255.Click
        ARDUINO_CONNECT.Write("2,153,0,255,")
        COLOR2_RED = 153
        COLOR2_GREEN = 0
        COLOR2_BLUE = 255
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_106_0_255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_106_0_255.Click
        ARDUINO_CONNECT.Write("2,106,0,255,")
        COLOR2_RED = 106
        COLOR2_GREEN = 0
        COLOR2_BLUE = 255
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR2_0_0_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR2_0_0_0.Click
        ARDUINO_CONNECT.Write("2,0,0,0,")
        COLOR2_RED = 0
        COLOR2_GREEN = 0
        COLOR2_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub

    '============================'
    ' COLOR1 FX                  '
    '============================'
    Private Sub ROG_COLOR1_0_0_255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_0_0_255.Click
        ARDUINO_CONNECT.Write("1,0,0,255,")
        COLOR1_RED = 0
        COLOR1_GREEN = 0
        COLOR1_BLUE = 255
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_0_102_255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_0_102_255.Click
        ARDUINO_CONNECT.Write("1,0,102,255,")
        COLOR1_RED = 0
        COLOR1_GREEN = 102
        COLOR1_BLUE = 255
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_0_170_255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_0_170_255.Click
        ARDUINO_CONNECT.Write("1,0,170,255,")
        COLOR1_RED = 0
        COLOR1_GREEN = 170
        COLOR1_BLUE = 255
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_0_255_255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_0_255_255.Click
        ARDUINO_CONNECT.Write("1,0,255,255,")
        COLOR1_RED = 0
        COLOR1_GREEN = 255
        COLOR1_BLUE = 255
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_74_255_152_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_74_255_152.Click
        ARDUINO_CONNECT.Write("1,74,255,152,")
        COLOR1_RED = 74
        COLOR1_GREEN = 255
        COLOR1_BLUE = 152
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_0_255_93_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_0_255_93.Click
        ARDUINO_CONNECT.Write("1,0,255,93,")
        COLOR1_RED = 0
        COLOR1_GREEN = 255
        COLOR1_BLUE = 93
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_0_255_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_0_255_0.Click
        ARDUINO_CONNECT.Write("1,0,255,0,")
        COLOR1_RED = 0
        COLOR1_GREEN = 255
        COLOR1_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_107_255_38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_107_255_38.Click
        ARDUINO_CONNECT.Write("1,107,255,38,")
        COLOR1_RED = 107
        COLOR1_GREEN = 255
        COLOR1_BLUE = 38
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_170_255_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_170_255_0.Click
        ARDUINO_CONNECT.Write("1,170,255,0,")
        COLOR1_RED = 170
        COLOR1_GREEN = 255
        COLOR1_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_255_255_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_255_255_0.Click
        ARDUINO_CONNECT.Write("1,255,255,0,")
        COLOR1_RED = 255
        COLOR1_GREEN = 255
        COLOR1_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        lightFX.LFX_Release()
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_255_238_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_255_238_0.Click
        ARDUINO_CONNECT.Write("1,255,238,0,")
        COLOR1_RED = 255
        COLOR1_GREEN = 238
        COLOR1_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_255_132_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_255_132_0.Click
        ARDUINO_CONNECT.Write("1,255,132,0,")
        COLOR1_RED = 255
        COLOR1_GREEN = 132
        COLOR1_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_255_85_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_255_85_0.Click
        ARDUINO_CONNECT.Write("1,255,85,0,")
        COLOR1_RED = 255
        COLOR1_GREEN = 85
        COLOR1_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_255_0_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_255_0_0.Click
        ARDUINO_CONNECT.Write("1,255,0,0,")
        COLOR1_RED = 255
        COLOR1_GREEN = 0
        COLOR1_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_255_0_119_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_255_0_119.Click
        ARDUINO_CONNECT.Write("1,255,0,119,")
        COLOR1_RED = 255
        COLOR1_GREEN = 0
        COLOR1_BLUE = 119
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_255_0_187_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_255_0_187.Click
        ARDUINO_CONNECT.Write("1,255,0,187,")
        COLOR1_RED = 255
        COLOR1_GREEN = 0
        COLOR1_BLUE = 187
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_255_0_255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_255_0_255.Click
        ARDUINO_CONNECT.Write("1,255,0,255,")
        COLOR1_RED = 255
        COLOR1_GREEN = 0
        COLOR1_BLUE = 255
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_153_0_255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_153_0_255.Click
        ARDUINO_CONNECT.Write("1,153,0,255,")
        COLOR1_RED = 153
        COLOR1_GREEN = 0
        COLOR1_BLUE = 255
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_106_0_255_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_106_0_255.Click
        ARDUINO_CONNECT.Write("1,106,0,255,")
        COLOR1_RED = 106
        COLOR1_GREEN = 0
        COLOR1_BLUE = 255
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub
    Private Sub ROG_COLOR1_0_0_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_COLOR1_0_0_0.Click
        ARDUINO_CONNECT.Write("1,0,0,0,")
        COLOR1_RED = 0
        COLOR1_GREEN = 0
        COLOR1_BLUE = 0
        ROG_TIMER_MUSIC.Stop()
        STAND_ROG_LEFT.Close()
        STAND_ROG_RIGHT.Close()
        STAND_ALIENWARE.Close()
        If ROG_MODE.Text <> "Music mod" Then
            lightFX.LFX_Release()
        End If
        ROG_MODE.Text = "Color mod"
    End Sub

    '============================'
    ' TIMER                      '
    '============================'


    Private Sub ROG_TIMER_MUSIC_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ROG_TIMER_MUSIC.Tick
        _Channels.GET_OUT_LeftChannel = CInt(deviceRender.AudioMeterInformation.PeakValues(0) * 100)
        _Channels.GET_OUT_RightChannel = CInt(deviceRender.AudioMeterInformation.PeakValues(1) * 100)
        _Channels.GET_OUT_Master = CInt(deviceRender.AudioMeterInformation.MasterPeakValue * 100)
        MUSIC_LEFT.Size = New Size(61, _Channels.GET_OUT_LeftChannel * 101 / 100)
        MUSIC_RIGHT.Size = New Size(61, _Channels.GET_OUT_RightChannel * 101 / 100)
        If _Channels.GET_OUT_RightChannel = 2 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 4 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 6 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 8 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 10 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 12 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 14 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 16 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 18 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 20 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 22 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 24 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 26 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 28 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 30 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 32 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 34 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 36 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 38 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 40 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 42 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 44 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 46 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 48 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 50 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 52 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 54 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 56 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 58 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 60 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 62 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 64 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 66 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 68 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 70 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 72 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 74 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 76 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 78 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 80 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 82 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 84 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 86 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 88 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 90 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 92 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 94 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 96 Then
            ARDUINO_CONNECT.Write("1,255,0,0,")
        ElseIf _Channels.GET_OUT_RightChannel = 98 Then
            ARDUINO_CONNECT.Write("1,0,0,255,")
        ElseIf _Channels.GET_OUT_RightChannel = 100 Then
            ARDUINO_CONNECT.Write("1,0,255,0,")
        End If
        If _Channels.GET_OUT_LeftChannel = 2 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 4 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 6 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 8 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 10 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 12 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 14 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 16 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 18 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 20 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 22 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 24 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 26 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 28 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 30 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 32 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 34 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 36 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 38 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 40 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 42 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 44 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 46 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 48 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 50 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 52 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 54 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 56 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 58 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 60 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 62 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 64 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 66 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 68 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 70 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 72 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 74 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 76 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 78 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 80 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 82 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 84 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 86 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 88 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 90 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 92 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 94 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 96 Then
            ARDUINO_CONNECT.Write("2,255,0,0,")
        ElseIf _Channels.GET_OUT_LeftChannel = 98 Then
            ARDUINO_CONNECT.Write("2,0,0,255,")
        ElseIf _Channels.GET_OUT_LeftChannel = 100 Then
            ARDUINO_CONNECT.Write("2,0,255,0,")
        End If
    End Sub

End Class
