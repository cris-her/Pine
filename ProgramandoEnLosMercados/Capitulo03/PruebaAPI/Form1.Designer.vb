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
        Me.txtSalida.Size = New System.Drawing.Size(584, 100)
        Me.txtSalida.TabIndex = 5
        '
        'btnPortafolio
        '
        Me.btnPortafolio.Location = New System.Drawing.Point(1, 223)
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
        Me.lvActivos.Location = New System.Drawing.Point(199, 223)
        Me.lvActivos.Name = "lvActivos"
        Me.lvActivos.Size = New System.Drawing.Size(675, 253)
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(901, 488)
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
End Class
