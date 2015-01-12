<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class A
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(A))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MENU_VALEUR_ALIENWARE = New System.Windows.Forms.TextBox()
        Me.MENU_VALEUR_COM = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ACLOSE = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.MENU_VALEUR_ALIENWARE)
        Me.Panel1.Controls.Add(Me.MENU_VALEUR_COM)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ACLOSE)
        Me.Panel1.Location = New System.Drawing.Point(9, 9)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(425, 227)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 181)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Alienware :"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(189, 152)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 46)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Validate"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'MENU_VALEUR_ALIENWARE
        '
        Me.MENU_VALEUR_ALIENWARE.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MENU_VALEUR_ALIENWARE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MENU_VALEUR_ALIENWARE.ForeColor = System.Drawing.Color.Black
        Me.MENU_VALEUR_ALIENWARE.Location = New System.Drawing.Point(83, 178)
        Me.MENU_VALEUR_ALIENWARE.Name = "MENU_VALEUR_ALIENWARE"
        Me.MENU_VALEUR_ALIENWARE.Size = New System.Drawing.Size(100, 20)
        Me.MENU_VALEUR_ALIENWARE.TabIndex = 10
        Me.MENU_VALEUR_ALIENWARE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MENU_VALEUR_COM
        '
        Me.MENU_VALEUR_COM.BackColor = System.Drawing.Color.Gainsboro
        Me.MENU_VALEUR_COM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MENU_VALEUR_COM.ForeColor = System.Drawing.Color.Black
        Me.MENU_VALEUR_COM.Location = New System.Drawing.Point(83, 152)
        Me.MENU_VALEUR_COM.Name = "MENU_VALEUR_COM"
        Me.MENU_VALEUR_COM.Size = New System.Drawing.Size(100, 20)
        Me.MENU_VALEUR_COM.TabIndex = 9
        Me.MENU_VALEUR_COM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "SerialPort :"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(19, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(387, 84)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = resources.GetString("Label1.Text")
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ACLOSE
        '
        Me.ACLOSE.AutoSize = True
        Me.ACLOSE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ACLOSE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ACLOSE.Location = New System.Drawing.Point(401, 0)
        Me.ACLOSE.Name = "ACLOSE"
        Me.ACLOSE.Size = New System.Drawing.Size(21, 20)
        Me.ACLOSE.TabIndex = 6
        Me.ACLOSE.Text = "X"
        '
        'A
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Red
        Me.ClientSize = New System.Drawing.Size(443, 245)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.Red
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "A"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "A"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MENU_VALEUR_ALIENWARE As System.Windows.Forms.TextBox
    Friend WithEvents MENU_VALEUR_COM As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ACLOSE As System.Windows.Forms.Label
End Class
