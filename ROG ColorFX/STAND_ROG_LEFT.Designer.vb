<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class STAND_ROG_LEFT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(STAND_ROG_LEFT))
        Me.TIMER_1 = New System.Windows.Forms.Timer(Me.components)
        Me.TIMER_2 = New System.Windows.Forms.Timer(Me.components)
        Me.TIMER_3 = New System.Windows.Forms.Timer(Me.components)
        Me.TIMER_4 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'TIMER_1
        '
        Me.TIMER_1.Interval = 1
        '
        'TIMER_2
        '
        Me.TIMER_2.Interval = 1
        '
        'TIMER_3
        '
        Me.TIMER_3.Interval = 1
        '
        'TIMER_4
        '
        Me.TIMER_4.Interval = 1
        '
        'STAND_ROG_LEFT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(150, 150)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "STAND_ROG_LEFT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TIMER_1 As System.Windows.Forms.Timer
    Friend WithEvents TIMER_2 As System.Windows.Forms.Timer
    Friend WithEvents TIMER_3 As System.Windows.Forms.Timer
    Friend WithEvents TIMER_4 As System.Windows.Forms.Timer
End Class
