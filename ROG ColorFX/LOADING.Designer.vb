<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LOADING
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LOADING))
        Me.LOADER = New System.Windows.Forms.Label()
        Me.TIMER_LOADING = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'LOADER
        '
        Me.LOADER.BackColor = System.Drawing.Color.Red
        Me.LOADER.Location = New System.Drawing.Point(0, 640)
        Me.LOADER.Name = "LOADER"
        Me.LOADER.Size = New System.Drawing.Size(0, 50)
        Me.LOADER.TabIndex = 0
        '
        'TIMER_LOADING
        '
        Me.TIMER_LOADING.Interval = 1
        '
        'LOADING
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ROG_ColorFX.My.Resources.Resources.loading
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.LOADER)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LOADING"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LOADING"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LOADER As System.Windows.Forms.Label
    Friend WithEvents TIMER_LOADING As System.Windows.Forms.Timer
End Class
