<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.btnConectar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbAccess_Token = New System.Windows.Forms.Label()
        Me.lbRefresh_Token = New System.Windows.Forms.Label()
        Me.btnCopiar = New System.Windows.Forms.Button()
        Me.btnPruebaEstadoDeCuenta = New System.Windows.Forms.Button()
        Me.txtSalida = New System.Windows.Forms.TextBox()
        Me.btnPortafolio = New System.Windows.Forms.Button()
        Me.lvActivos = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnConsulta = New System.Windows.Forms.Button()
        Me.txtSimbolo = New System.Windows.Forms.TextBox()
        Me.btnPanel = New System.Windows.Forms.Button()
        Me.txtPanel = New System.Windows.Forms.TextBox()
        Me.txtInstrumento = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnVender = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.txtPrecioVenta = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lvPanel = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSimboloVenta = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario:"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(74, 5)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtUsuario.Size = New System.Drawing.Size(100, 20)
        Me.txtUsuario.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(196, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Clave"
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(242, 5)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(100, 20)
        Me.txtClave.TabIndex = 1
        '
        'btnConectar
        '
        Me.btnConectar.Location = New System.Drawing.Point(369, 5)
        Me.btnConectar.Name = "btnConectar"
        Me.btnConectar.Size = New System.Drawing.Size(75, 23)
        Me.btnConectar.TabIndex = 2
        Me.btnConectar.Text = "Conectar"
        Me.btnConectar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Access_Token"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Refresh_Token:"
        '
        'lbAccess_Token
        '
        Me.lbAccess_Token.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbAccess_Token.Location = New System.Drawing.Point(108, 38)
        Me.lbAccess_Token.Name = "lbAccess_Token"
        Me.lbAccess_Token.Size = New System.Drawing.Size(704, 20)
        Me.lbAccess_Token.TabIndex = 0
        '
        'lbRefresh_Token
        '
        Me.lbRefresh_Token.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbRefresh_Token.Location = New System.Drawing.Point(109, 60)
        Me.lbRefresh_Token.Name = "lbRefresh_Token"
        Me.lbRefresh_Token.Size = New System.Drawing.Size(704, 20)
        Me.lbRefresh_Token.TabIndex = 0
        '
        'btnCopiar
        '
        Me.btnCopiar.Location = New System.Drawing.Point(819, 36)
        Me.btnCopiar.Name = "btnCopiar"
        Me.btnCopiar.Size = New System.Drawing.Size(75, 23)
        Me.btnCopiar.TabIndex = 3
        Me.btnCopiar.Text = "Copiar"
        Me.btnCopiar.UseVisualStyleBackColor = True
        '
        'btnPruebaEstadoDeCuenta
        '
        Me.btnPruebaEstadoDeCuenta.Location = New System.Drawing.Point(1, 109)
        Me.btnPruebaEstadoDeCuenta.Name = "btnPruebaEstadoDeCuenta"
        Me.btnPruebaEstadoDeCuenta.Size = New System.Drawing.Size(187, 23)
        Me.btnPruebaEstadoDeCuenta.TabIndex = 4
        Me.btnPruebaEstadoDeCuenta.Text = "Estado de cuenta"
        Me.btnPruebaEstadoDeCuenta.UseVisualStyleBackColor = True
        '
        'txtSalida
        '
        Me.txtSalida.Location = New System.Drawing.Point(194, 109)
        Me.txtSalida.Multiline = True
        Me.txtSalida.Name = "txtSalida"
        Me.txtSalida.Size = New System.Drawing.Size(584, 78)
        Me.txtSalida.TabIndex = 5
        '
        'btnPortafolio
        '
        Me.btnPortafolio.Location = New System.Drawing.Point(4, 197)
        Me.btnPortafolio.Name = "btnPortafolio"
        Me.btnPortafolio.Size = New System.Drawing.Size(187, 23)
        Me.btnPortafolio.TabIndex = 6
        Me.btnPortafolio.Text = "Portafolio"
        Me.btnPortafolio.UseVisualStyleBackColor = True
        '
        'lvActivos
        '
        Me.lvActivos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvActivos.FullRowSelect = True
        Me.lvActivos.GridLines = True
        Me.lvActivos.HideSelection = False
        Me.lvActivos.Location = New System.Drawing.Point(197, 197)
        Me.lvActivos.Name = "lvActivos"
        Me.lvActivos.Size = New System.Drawing.Size(675, 98)
        Me.lvActivos.TabIndex = 7
        Me.lvActivos.UseCompatibleStateImageBehavior = False
        Me.lvActivos.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Simbolo"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Descripcion"
        Me.ColumnHeader2.Width = 198
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Cantidad"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Último"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "PPC"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader5.Width = 56
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Valorizado"
        Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader6.Width = 68
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Resultado %"
        Me.ColumnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader7.Width = 75
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Resultado $"
        Me.ColumnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader8.Width = 81
        '
        'btnConsulta
        '
        Me.btnConsulta.Location = New System.Drawing.Point(1, 138)
        Me.btnConsulta.Name = "btnConsulta"
        Me.btnConsulta.Size = New System.Drawing.Size(187, 23)
        Me.btnConsulta.TabIndex = 8
        Me.btnConsulta.Text = "Consultar"
        Me.btnConsulta.UseVisualStyleBackColor = True
        '
        'txtSimbolo
        '
        Me.txtSimbolo.Location = New System.Drawing.Point(88, 167)
        Me.txtSimbolo.Name = "txtSimbolo"
        Me.txtSimbolo.Size = New System.Drawing.Size(100, 20)
        Me.txtSimbolo.TabIndex = 9
        '
        'btnPanel
        '
        Me.btnPanel.Location = New System.Drawing.Point(1, 301)
        Me.btnPanel.Name = "btnPanel"
        Me.btnPanel.Size = New System.Drawing.Size(187, 23)
        Me.btnPanel.TabIndex = 10
        Me.btnPanel.Text = "Panel"
        Me.btnPanel.UseVisualStyleBackColor = True
        '
        'txtPanel
        '
        Me.txtPanel.Location = New System.Drawing.Point(88, 343)
        Me.txtPanel.Name = "txtPanel"
        Me.txtPanel.Size = New System.Drawing.Size(100, 20)
        Me.txtPanel.TabIndex = 9
        '
        'txtInstrumento
        '
        Me.txtInstrumento.Location = New System.Drawing.Point(88, 369)
        Me.txtInstrumento.Name = "txtInstrumento"
        Me.txtInstrumento.Size = New System.Drawing.Size(100, 20)
        Me.txtInstrumento.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 376)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Instrumento"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(48, 350)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Panel"
        '
        'btnVender
        '
        Me.btnVender.Location = New System.Drawing.Point(883, 197)
        Me.btnVender.Name = "btnVender"
        Me.btnVender.Size = New System.Drawing.Size(135, 23)
        Me.btnVender.TabIndex = 12
        Me.btnVender.Text = "Vender"
        Me.btnVender.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(880, 270)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Cantidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(935, 264)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(83, 20)
        Me.txtCantidad.TabIndex = 14
        '
        'txtPrecioVenta
        '
        Me.txtPrecioVenta.Location = New System.Drawing.Point(935, 290)
        Me.txtPrecioVenta.Name = "txtPrecioVenta"
        Me.txtPrecioVenta.Size = New System.Drawing.Size(83, 20)
        Me.txtPrecioVenta.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(882, 294)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Precio:"
        '
        'lvPanel
        '
        Me.lvPanel.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader15, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader16})
        Me.lvPanel.FullRowSelect = True
        Me.lvPanel.GridLines = True
        Me.lvPanel.HideSelection = False
        Me.lvPanel.Location = New System.Drawing.Point(194, 301)
        Me.lvPanel.Name = "lvPanel"
        Me.lvPanel.Size = New System.Drawing.Size(675, 228)
        Me.lvPanel.TabIndex = 17
        Me.lvPanel.UseCompatibleStateImageBehavior = False
        Me.lvPanel.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Simbolo"
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Último"
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Var %"
        Me.ColumnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader15.Width = 75
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Cant comp:"
        Me.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader11.Width = 70
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Comp"
        Me.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader12.Width = 70
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "Venta"
        Me.ColumnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader13.Width = 70
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Cant Vent"
        Me.ColumnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader14.Width = 68
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "Volumen"
        Me.ColumnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader16.Width = 81
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 174)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Simbolo:"
        '
        'txtSimboloVenta
        '
        Me.txtSimboloVenta.Location = New System.Drawing.Point(935, 238)
        Me.txtSimboloVenta.Name = "txtSimboloVenta"
        Me.txtSimboloVenta.Size = New System.Drawing.Size(83, 20)
        Me.txtSimboloVenta.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(880, 244)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Simbolo"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 580)
        Me.Controls.Add(Me.txtSimboloVenta)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lvPanel)
        Me.Controls.Add(Me.txtPrecioVenta)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnVender)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnPanel)
        Me.Controls.Add(Me.txtInstrumento)
        Me.Controls.Add(Me.txtPanel)
        Me.Controls.Add(Me.txtSimbolo)
        Me.Controls.Add(Me.btnConsulta)
        Me.Controls.Add(Me.lvActivos)
        Me.Controls.Add(Me.btnPortafolio)
        Me.Controls.Add(Me.txtSalida)
        Me.Controls.Add(Me.btnPruebaEstadoDeCuenta)
        Me.Controls.Add(Me.btnCopiar)
        Me.Controls.Add(Me.btnConectar)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbRefresh_Token)
        Me.Controls.Add(Me.lbAccess_Token)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtClave As TextBox
    Friend WithEvents btnConectar As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbAccess_Token As Label
    Friend WithEvents lbRefresh_Token As Label
    Friend WithEvents btnCopiar As Button
    Friend WithEvents btnPruebaEstadoDeCuenta As Button
    Friend WithEvents txtSalida As TextBox
    Friend WithEvents btnPortafolio As Button
    Friend WithEvents lvActivos As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents btnConsulta As Button
    Friend WithEvents txtSimbolo As TextBox
    Friend WithEvents btnPanel As Button
    Friend WithEvents txtPanel As TextBox
    Friend WithEvents txtInstrumento As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnVender As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents txtPrecioVenta As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lvPanel As ListView
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ColumnHeader11 As ColumnHeader
    Friend WithEvents ColumnHeader12 As ColumnHeader
    Friend WithEvents ColumnHeader13 As ColumnHeader
    Friend WithEvents ColumnHeader14 As ColumnHeader
    Friend WithEvents ColumnHeader15 As ColumnHeader
    Friend WithEvents ColumnHeader16 As ColumnHeader
    Friend WithEvents Label9 As Label
    Friend WithEvents txtSimboloVenta As TextBox
    Friend WithEvents Label10 As Label
End Class
