<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTextEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.rtbDocument = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'rtbDocument
        '
        Me.rtbDocument.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rtbDocument.Location = New System.Drawing.Point(0, 0)
        Me.rtbDocument.Name = "rtbDocument"
        Me.rtbDocument.Size = New System.Drawing.Size(615, 448)
        Me.rtbDocument.TabIndex = 0
        Me.rtbDocument.Text = ""
        '
        'frmTextEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 448)
        Me.Controls.Add(Me.rtbDocument)
        Me.Name = "frmTextEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Text Editor"
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents rtbDocument As RichTextBox
End Class
