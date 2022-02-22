<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnCuenta = New System.Windows.Forms.Button()
        Me.txtSalida = New System.Windows.Forms.TextBox()
        Me.btnCedears = New System.Windows.Forms.Button()
        Me.btnPanelMerval = New System.Windows.Forms.Button()
        Me.btnOpciones = New System.Windows.Forms.Button()
        Me.btnCotizacion = New System.Windows.Forms.Button()
        Me.txtTicker = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtDesde = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtHasta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnHistoricos = New System.Windows.Forms.Button()
        Me.btnPrecios = New System.Windows.Forms.Button()
        Me.btnPuntas = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCuenta
        '
        Me.btnCuenta.Location = New System.Drawing.Point(13, 23)
        Me.btnCuenta.Name = "btnCuenta"
        Me.btnCuenta.Size = New System.Drawing.Size(95, 23)
        Me.btnCuenta.TabIndex = 0
        Me.btnCuenta.Text = "Estado Cuenta"
        Me.btnCuenta.UseVisualStyleBackColor = True
        '
        'txtSalida
        '
        Me.txtSalida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSalida.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalida.Location = New System.Drawing.Point(163, 26)
        Me.txtSalida.Multiline = True
        Me.txtSalida.Name = "txtSalida"
        Me.txtSalida.Size = New System.Drawing.Size(625, 412)
        Me.txtSalida.TabIndex = 1
        '
        'btnCedears
        '
        Me.btnCedears.Location = New System.Drawing.Point(13, 172)
        Me.btnCedears.Name = "btnCedears"
        Me.btnCedears.Size = New System.Drawing.Size(75, 23)
        Me.btnCedears.TabIndex = 15
        Me.btnCedears.Text = "CEDEARs"
        Me.btnCedears.UseVisualStyleBackColor = True
        '
        'btnPanelMerval
        '
        Me.btnPanelMerval.Location = New System.Drawing.Point(13, 143)
        Me.btnPanelMerval.Name = "btnPanelMerval"
        Me.btnPanelMerval.Size = New System.Drawing.Size(75, 23)
        Me.btnPanelMerval.TabIndex = 14
        Me.btnPanelMerval.Text = "Merval"
        Me.btnPanelMerval.UseVisualStyleBackColor = True
        '
        'btnOpciones
        '
        Me.btnOpciones.Location = New System.Drawing.Point(54, 114)
        Me.btnOpciones.Name = "btnOpciones"
        Me.btnOpciones.Size = New System.Drawing.Size(75, 23)
        Me.btnOpciones.TabIndex = 13
        Me.btnOpciones.Text = "Opciones"
        Me.btnOpciones.UseVisualStyleBackColor = True
        '
        'btnCotizacion
        '
        Me.btnCotizacion.Location = New System.Drawing.Point(54, 85)
        Me.btnCotizacion.Name = "btnCotizacion"
        Me.btnCotizacion.Size = New System.Drawing.Size(75, 23)
        Me.btnCotizacion.TabIndex = 12
        Me.btnCotizacion.Text = "Cotizacion"
        Me.btnCotizacion.UseVisualStyleBackColor = True
        '
        'txtTicker
        '
        Me.txtTicker.Location = New System.Drawing.Point(54, 59)
        Me.txtTicker.Name = "txtTicker"
        Me.txtTicker.Size = New System.Drawing.Size(75, 20)
        Me.txtTicker.TabIndex = 11
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(10, 59)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(37, 13)
        Me.label1.TabIndex = 10
        Me.label1.Text = "Ticker"
        '
        'txtDesde
        '
        Me.txtDesde.Location = New System.Drawing.Point(54, 222)
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.Size = New System.Drawing.Size(75, 20)
        Me.txtDesde.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 222)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "desde:"
        '
        'txtHasta
        '
        Me.txtHasta.Location = New System.Drawing.Point(54, 248)
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.Size = New System.Drawing.Size(75, 20)
        Me.txtHasta.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 248)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "hasta:"
        '
        'btnHistoricos
        '
        Me.btnHistoricos.Location = New System.Drawing.Point(54, 274)
        Me.btnHistoricos.Name = "btnHistoricos"
        Me.btnHistoricos.Size = New System.Drawing.Size(75, 23)
        Me.btnHistoricos.TabIndex = 20
        Me.btnHistoricos.Text = "Historico"
        Me.btnHistoricos.UseVisualStyleBackColor = True
        '
        'btnPrecios
        '
        Me.btnPrecios.Location = New System.Drawing.Point(54, 331)
        Me.btnPrecios.Name = "btnPrecios"
        Me.btnPrecios.Size = New System.Drawing.Size(75, 23)
        Me.btnPrecios.TabIndex = 21
        Me.btnPrecios.Text = "Precios"
        Me.btnPrecios.UseVisualStyleBackColor = True
        '
        'btnPuntas
        '
        Me.btnPuntas.Location = New System.Drawing.Point(54, 360)
        Me.btnPuntas.Name = "btnPuntas"
        Me.btnPuntas.Size = New System.Drawing.Size(75, 23)
        Me.btnPuntas.TabIndex = 22
        Me.btnPuntas.Text = "Puntas"
        Me.btnPuntas.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnPuntas)
        Me.Controls.Add(Me.btnPrecios)
        Me.Controls.Add(Me.btnHistoricos)
        Me.Controls.Add(Me.txtHasta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDesde)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCedears)
        Me.Controls.Add(Me.btnPanelMerval)
        Me.Controls.Add(Me.btnOpciones)
        Me.Controls.Add(Me.btnCotizacion)
        Me.Controls.Add(Me.txtTicker)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.txtSalida)
        Me.Controls.Add(Me.btnCuenta)
        Me.Name = "Form1"
        Me.Text = "Prueba VB"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCuenta As Button
    Friend WithEvents txtSalida As TextBox
    Private WithEvents btnCedears As Button
    Private WithEvents btnPanelMerval As Button
    Private WithEvents btnOpciones As Button
    Private WithEvents btnCotizacion As Button
    Private WithEvents txtTicker As TextBox
    Private WithEvents label1 As Label
    Private WithEvents txtDesde As TextBox
    Private WithEvents Label2 As Label
    Private WithEvents txtHasta As TextBox
    Private WithEvents Label3 As Label
    Private WithEvents btnHistoricos As Button
    Private WithEvents btnPrecios As Button
    Private WithEvents btnPuntas As Button
End Class
