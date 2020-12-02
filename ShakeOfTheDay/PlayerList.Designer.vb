<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlayerList
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
        Me.lbxPatrons = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnEnter = New System.Windows.Forms.Button()
        Me.btnPatron = New System.Windows.Forms.Button()
        Me.btnSign = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.RichTextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lblHouse = New System.Windows.Forms.Label()
        Me.ptrAtm = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ptrBeer = New System.Windows.Forms.PictureBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblMoney = New System.Windows.Forms.Label()
        Me.lblMoneyText = New System.Windows.Forms.Label()
        CType(Me.ptrAtm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptrBeer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbxPatrons
        '
        Me.lbxPatrons.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lbxPatrons.Font = New System.Drawing.Font("Modern No. 20", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbxPatrons.ForeColor = System.Drawing.Color.Tomato
        Me.lbxPatrons.FormattingEnabled = True
        Me.lbxPatrons.ItemHeight = 21
        Me.lbxPatrons.Location = New System.Drawing.Point(75, 91)
        Me.lbxPatrons.Name = "lbxPatrons"
        Me.lbxPatrons.Size = New System.Drawing.Size(167, 193)
        Me.lbxPatrons.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Stencil", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Tomato
        Me.Label1.Location = New System.Drawing.Point(104, 38)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 29)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Patrons"
        '
        'btnEnter
        '
        Me.btnEnter.Enabled = False
        Me.btnEnter.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnter.Location = New System.Drawing.Point(265, 187)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(167, 31)
        Me.btnEnter.TabIndex = 20
        Me.btnEnter.Text = "Enter the Bar"
        Me.btnEnter.UseVisualStyleBackColor = True
        '
        'btnPatron
        '
        Me.btnPatron.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPatron.Location = New System.Drawing.Point(75, 296)
        Me.btnPatron.Name = "btnPatron"
        Me.btnPatron.Size = New System.Drawing.Size(167, 31)
        Me.btnPatron.TabIndex = 21
        Me.btnPatron.Text = "New Patron"
        Me.btnPatron.UseVisualStyleBackColor = True
        '
        'btnSign
        '
        Me.btnSign.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSign.Location = New System.Drawing.Point(98, 369)
        Me.btnSign.Name = "btnSign"
        Me.btnSign.Size = New System.Drawing.Size(120, 26)
        Me.btnSign.TabIndex = 22
        Me.btnSign.Text = "Sign Me Up!"
        Me.btnSign.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Impact", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.Color.Tomato
        Me.txtName.Location = New System.Drawing.Point(75, 333)
        Me.txtName.Multiline = False
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(167, 31)
        Me.txtName.TabIndex = 25
        Me.txtName.Text = ""
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(265, 296)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(167, 31)
        Me.btnDelete.TabIndex = 24
        Me.btnDelete.Text = "Remove Patron"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lblHouse
        '
        Me.lblHouse.AutoSize = True
        Me.lblHouse.Font = New System.Drawing.Font("Stencil", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHouse.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblHouse.Location = New System.Drawing.Point(329, 66)
        Me.lblHouse.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblHouse.Name = "lblHouse"
        Me.lblHouse.Size = New System.Drawing.Size(27, 29)
        Me.lblHouse.TabIndex = 26
        Me.lblHouse.Text = "0"
        '
        'ptrAtm
        '
        Me.ptrAtm.Location = New System.Drawing.Point(317, 225)
        Me.ptrAtm.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ptrAtm.Name = "ptrAtm"
        Me.ptrAtm.Size = New System.Drawing.Size(65, 65)
        Me.ptrAtm.TabIndex = 27
        Me.ptrAtm.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Stencil", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Tomato
        Me.Label9.Location = New System.Drawing.Point(260, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(173, 29)
        Me.Label9.TabIndex = 56
        Me.Label9.Text = "House Money"
        '
        'ptrBeer
        '
        Me.ptrBeer.Location = New System.Drawing.Point(311, 99)
        Me.ptrBeer.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.ptrBeer.Name = "ptrBeer"
        Me.ptrBeer.Size = New System.Drawing.Size(81, 81)
        Me.ptrBeer.TabIndex = 57
        Me.ptrBeer.TabStop = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Stencil", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Tomato
        Me.lblName.Location = New System.Drawing.Point(70, 337)
        Me.lblName.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(118, 29)
        Me.lblName.TabIndex = 58
        Me.lblName.Text = "Patrons"
        '
        'lblMoney
        '
        Me.lblMoney.AutoSize = True
        Me.lblMoney.Font = New System.Drawing.Font("Stencil", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoney.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblMoney.Location = New System.Drawing.Point(346, 337)
        Me.lblMoney.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblMoney.Name = "lblMoney"
        Me.lblMoney.Size = New System.Drawing.Size(27, 29)
        Me.lblMoney.TabIndex = 59
        Me.lblMoney.Text = "0"
        '
        'lblMoneyText
        '
        Me.lblMoneyText.AutoSize = True
        Me.lblMoneyText.Font = New System.Drawing.Font("Stencil", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoneyText.ForeColor = System.Drawing.Color.Tomato
        Me.lblMoneyText.Location = New System.Drawing.Point(260, 337)
        Me.lblMoneyText.Name = "lblMoneyText"
        Me.lblMoneyText.Size = New System.Drawing.Size(91, 29)
        Me.lblMoneyText.TabIndex = 60
        Me.lblMoneyText.Text = "Money"
        '
        'PlayerList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 432)
        Me.Controls.Add(Me.lblMoneyText)
        Me.Controls.Add(Me.lblMoney)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.ptrBeer)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ptrAtm)
        Me.Controls.Add(Me.lblHouse)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.btnSign)
        Me.Controls.Add(Me.btnPatron)
        Me.Controls.Add(Me.btnEnter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbxPatrons)
        Me.Name = "PlayerList"
        Me.Text = "PlayerList"
        CType(Me.ptrAtm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptrBeer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbxPatrons As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnEnter As Button
    Friend WithEvents btnPatron As Button
    Friend WithEvents btnSign As Button
    Friend WithEvents txtName As RichTextBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents lblHouse As Label
    Friend WithEvents ptrAtm As PictureBox
    Friend WithEvents Label9 As Label
    Friend WithEvents ptrBeer As PictureBox
    Friend WithEvents lblName As Label
    Friend WithEvents lblMoney As Label
    Friend WithEvents lblMoneyText As Label
End Class
