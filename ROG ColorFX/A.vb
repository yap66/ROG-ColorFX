Imports System
Imports System.Text
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Xml

Public Class A

    Dim COLOR2_RED, COLOR2_GREEN, COLOR2_BLUE
    Dim COLOR1_RED, COLOR1_GREEN, COLOR1_BLUE
    Dim CONFIG_COM, CONFIG_ALIENWARE


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        WitterFileXML("configROG.xml", COLOR2_RED, COLOR2_GREEN, COLOR2_BLUE, COLOR1_RED, COLOR1_GREEN, COLOR1_BLUE, MENU_VALEUR_COM.Text, MENU_VALEUR_ALIENWARE.Text)
        ROG_FORM.ARDUINO_CONNECT.Close()
        ROG_FORM.ARDUINO_CONNECT.PortName = MENU_VALEUR_COM.Text
        ROG_FORM.ARDUINO_CONNECT.Open()

        Me.Close()
    End Sub

    Private Sub A_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        document.Close()

        MENU_VALEUR_COM.Text = CONFIG_COM
        MENU_VALEUR_ALIENWARE.Text = CONFIG_ALIENWARE
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

    Private Sub ACLOSE_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACLOSE.Click
        Me.Close()
    End Sub
End Class