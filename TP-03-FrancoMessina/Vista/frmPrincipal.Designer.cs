namespace Vista
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gpbRegistro = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnRegistarse = new System.Windows.Forms.Button();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnMostrarServicio = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.cmbProductos = new System.Windows.Forms.ComboBox();
            this.gpbProducto = new System.Windows.Forms.GroupBox();
            this.lblPrecioFinal = new System.Windows.Forms.Label();
            this.cmbEntrega = new System.Windows.Forms.ComboBox();
            this.lblTipoEntrega = new System.Windows.Forms.Label();
            this.btnCargarFalla = new System.Windows.Forms.Button();
            this.ckbFallaTres = new System.Windows.Forms.CheckBox();
            this.ckbFallaDos = new System.Windows.Forms.CheckBox();
            this.ckbFallaUno = new System.Windows.Forms.CheckBox();
            this.lblFallas = new System.Windows.Forms.Label();
            this.lblTipoControl = new System.Windows.Forms.Label();
            this.rdbAire = new System.Windows.Forms.RadioButton();
            this.rdbTv = new System.Windows.Forms.RadioButton();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbModelo = new System.Windows.Forms.ComboBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.btnGuardarClientes = new System.Windows.Forms.Button();
            this.timerHoraFecha = new System.Windows.Forms.Timer(this.components);
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.gpbRegistro.SuspendLayout();
            this.gpbProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbRegistro
            // 
            this.gpbRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gpbRegistro.Controls.Add(this.btnEliminar);
            this.gpbRegistro.Controls.Add(this.btnModificar);
            this.gpbRegistro.Controls.Add(this.txtTelefono);
            this.gpbRegistro.Controls.Add(this.txtDni);
            this.gpbRegistro.Controls.Add(this.btnRegistarse);
            this.gpbRegistro.Controls.Add(this.lblTelefono);
            this.gpbRegistro.Controls.Add(this.lblDni);
            this.gpbRegistro.Controls.Add(this.txtApellido);
            this.gpbRegistro.Controls.Add(this.lblApellido);
            this.gpbRegistro.Controls.Add(this.txtNombre);
            this.gpbRegistro.Controls.Add(this.lblNombre);
            this.gpbRegistro.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.gpbRegistro.Location = new System.Drawing.Point(12, 16);
            this.gpbRegistro.Name = "gpbRegistro";
            this.gpbRegistro.Size = new System.Drawing.Size(547, 213);
            this.gpbRegistro.TabIndex = 1;
            this.gpbRegistro.TabStop = false;
            this.gpbRegistro.Text = "Cliente";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(394, 163);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(118, 31);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(219, 163);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(118, 31);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(381, 103);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(131, 25);
            this.txtTelefono.TabIndex = 3;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(101, 95);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(131, 25);
            this.txtDni.TabIndex = 2;
            // 
            // btnRegistarse
            // 
            this.btnRegistarse.Location = new System.Drawing.Point(45, 161);
            this.btnRegistarse.Name = "btnRegistarse";
            this.btnRegistarse.Size = new System.Drawing.Size(108, 33);
            this.btnRegistarse.TabIndex = 4;
            this.btnRegistarse.Text = "Registrarse";
            this.btnRegistarse.UseVisualStyleBackColor = true;
            this.btnRegistarse.Click += new System.EventHandler(this.btnRegistarse_Click);
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(287, 106);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(78, 17);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Numero Tel";
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(6, 103);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(31, 17);
            this.lblDni.TabIndex = 1;
            this.lblDni.Text = "Dni";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(381, 42);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(131, 25);
            this.txtApellido.TabIndex = 1;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(286, 42);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(60, 17);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(101, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(131, 25);
            this.txtNombre.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 45);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 17);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre";
            // 
            // btnMostrarServicio
            // 
            this.btnMostrarServicio.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnMostrarServicio.Location = new System.Drawing.Point(785, 257);
            this.btnMostrarServicio.Name = "btnMostrarServicio";
            this.btnMostrarServicio.Size = new System.Drawing.Size(196, 47);
            this.btnMostrarServicio.TabIndex = 5;
            this.btnMostrarServicio.Text = "Mostrar Servicios";
            this.btnMostrarServicio.UseVisualStyleBackColor = true;
            this.btnMostrarServicio.Click += new System.EventHandler(this.btnMostrarServicio_Click);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblProducto.Location = new System.Drawing.Point(249, 281);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(168, 22);
            this.lblProducto.TabIndex = 8;
            this.lblProducto.Text = "Producto a reparar";
            // 
            // cmbProductos
            // 
            this.cmbProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductos.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.Location = new System.Drawing.Point(430, 281);
            this.cmbProductos.Name = "cmbProductos";
            this.cmbProductos.Size = new System.Drawing.Size(188, 25);
            this.cmbProductos.TabIndex = 7;
            this.cmbProductos.SelectedIndexChanged += new System.EventHandler(this.cmbProductos_SelectedIndexChanged);
            // 
            // gpbProducto
            // 
            this.gpbProducto.BackColor = System.Drawing.Color.Silver;
            this.gpbProducto.Controls.Add(this.lblPrecioFinal);
            this.gpbProducto.Controls.Add(this.cmbEntrega);
            this.gpbProducto.Controls.Add(this.lblTipoEntrega);
            this.gpbProducto.Controls.Add(this.btnCargarFalla);
            this.gpbProducto.Controls.Add(this.ckbFallaTres);
            this.gpbProducto.Controls.Add(this.ckbFallaDos);
            this.gpbProducto.Controls.Add(this.ckbFallaUno);
            this.gpbProducto.Controls.Add(this.lblFallas);
            this.gpbProducto.Controls.Add(this.lblTipoControl);
            this.gpbProducto.Controls.Add(this.rdbAire);
            this.gpbProducto.Controls.Add(this.rdbTv);
            this.gpbProducto.Controls.Add(this.cmbTipo);
            this.gpbProducto.Controls.Add(this.lblTipo);
            this.gpbProducto.Controls.Add(this.cmbModelo);
            this.gpbProducto.Controls.Add(this.lblModelo);
            this.gpbProducto.Controls.Add(this.cmbMarca);
            this.gpbProducto.Controls.Add(this.lblMarca);
            this.gpbProducto.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gpbProducto.Location = new System.Drawing.Point(246, 318);
            this.gpbProducto.Name = "gpbProducto";
            this.gpbProducto.Size = new System.Drawing.Size(735, 334);
            this.gpbProducto.TabIndex = 6;
            this.gpbProducto.TabStop = false;
            this.gpbProducto.Text = "Producto";
            // 
            // lblPrecioFinal
            // 
            this.lblPrecioFinal.AutoSize = true;
            this.lblPrecioFinal.Location = new System.Drawing.Point(31, 252);
            this.lblPrecioFinal.Name = "lblPrecioFinal";
            this.lblPrecioFinal.Size = new System.Drawing.Size(0, 19);
            this.lblPrecioFinal.TabIndex = 19;
            // 
            // cmbEntrega
            // 
            this.cmbEntrega.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntrega.FormattingEnabled = true;
            this.cmbEntrega.Location = new System.Drawing.Point(458, 141);
            this.cmbEntrega.Name = "cmbEntrega";
            this.cmbEntrega.Size = new System.Drawing.Size(194, 27);
            this.cmbEntrega.TabIndex = 13;
            // 
            // lblTipoEntrega
            // 
            this.lblTipoEntrega.AutoSize = true;
            this.lblTipoEntrega.Location = new System.Drawing.Point(356, 144);
            this.lblTipoEntrega.Name = "lblTipoEntrega";
            this.lblTipoEntrega.Size = new System.Drawing.Size(62, 19);
            this.lblTipoEntrega.TabIndex = 17;
            this.lblTipoEntrega.Text = "Entrega";
            // 
            // btnCargarFalla
            // 
            this.btnCargarFalla.Location = new System.Drawing.Point(304, 252);
            this.btnCargarFalla.Name = "btnCargarFalla";
            this.btnCargarFalla.Size = new System.Drawing.Size(129, 47);
            this.btnCargarFalla.TabIndex = 16;
            this.btnCargarFalla.Text = "Cargar Servicio";
            this.btnCargarFalla.UseVisualStyleBackColor = true;
            this.btnCargarFalla.Click += new System.EventHandler(this.btnCargarServicio_Click);
            // 
            // ckbFallaTres
            // 
            this.ckbFallaTres.AutoSize = true;
            this.ckbFallaTres.Location = new System.Drawing.Point(494, 208);
            this.ckbFallaTres.Name = "ckbFallaTres";
            this.ckbFallaTres.Size = new System.Drawing.Size(15, 14);
            this.ckbFallaTres.TabIndex = 15;
            this.ckbFallaTres.UseVisualStyleBackColor = true;
            // 
            // ckbFallaDos
            // 
            this.ckbFallaDos.AutoSize = true;
            this.ckbFallaDos.Location = new System.Drawing.Point(304, 206);
            this.ckbFallaDos.Name = "ckbFallaDos";
            this.ckbFallaDos.Size = new System.Drawing.Size(15, 14);
            this.ckbFallaDos.TabIndex = 14;
            this.ckbFallaDos.UseVisualStyleBackColor = true;
            // 
            // ckbFallaUno
            // 
            this.ckbFallaUno.AutoSize = true;
            this.ckbFallaUno.Location = new System.Drawing.Point(137, 203);
            this.ckbFallaUno.Name = "ckbFallaUno";
            this.ckbFallaUno.Size = new System.Drawing.Size(15, 14);
            this.ckbFallaUno.TabIndex = 13;
            this.ckbFallaUno.UseVisualStyleBackColor = true;
            // 
            // lblFallas
            // 
            this.lblFallas.AutoSize = true;
            this.lblFallas.Location = new System.Drawing.Point(31, 203);
            this.lblFallas.Name = "lblFallas";
            this.lblFallas.Size = new System.Drawing.Size(49, 19);
            this.lblFallas.TabIndex = 12;
            this.lblFallas.Text = "Fallas";
            // 
            // lblTipoControl
            // 
            this.lblTipoControl.AutoSize = true;
            this.lblTipoControl.Location = new System.Drawing.Point(31, 35);
            this.lblTipoControl.Name = "lblTipoControl";
            this.lblTipoControl.Size = new System.Drawing.Size(93, 19);
            this.lblTipoControl.TabIndex = 11;
            this.lblTipoControl.Text = "Tipo Control";
            // 
            // rdbAire
            // 
            this.rdbAire.AutoSize = true;
            this.rdbAire.Location = new System.Drawing.Point(242, 31);
            this.rdbAire.Name = "rdbAire";
            this.rdbAire.Size = new System.Drawing.Size(56, 23);
            this.rdbAire.TabIndex = 9;
            this.rdbAire.TabStop = true;
            this.rdbAire.Text = "Aire";
            this.rdbAire.UseVisualStyleBackColor = true;
            this.rdbAire.CheckedChanged += new System.EventHandler(this.rdbAire_CheckedChanged);
            // 
            // rdbTv
            // 
            this.rdbTv.AutoSize = true;
            this.rdbTv.Location = new System.Drawing.Point(142, 31);
            this.rdbTv.Name = "rdbTv";
            this.rdbTv.Size = new System.Drawing.Size(45, 23);
            this.rdbTv.TabIndex = 8;
            this.rdbTv.TabStop = true;
            this.rdbTv.Text = "Tv";
            this.rdbTv.UseVisualStyleBackColor = true;
            this.rdbTv.CheckedChanged += new System.EventHandler(this.rdbTv_CheckedChanged);
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(133, 141);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(194, 27);
            this.cmbTipo.TabIndex = 12;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(31, 144);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(39, 19);
            this.lblTipo.TabIndex = 7;
            this.lblTipo.Text = "Tipo";
            // 
            // cmbModelo
            // 
            this.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelo.FormattingEnabled = true;
            this.cmbModelo.Location = new System.Drawing.Point(458, 81);
            this.cmbModelo.Name = "cmbModelo";
            this.cmbModelo.Size = new System.Drawing.Size(194, 27);
            this.cmbModelo.TabIndex = 11;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(356, 84);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(61, 19);
            this.lblModelo.TabIndex = 5;
            this.lblModelo.Text = "Modelo";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(133, 81);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(194, 27);
            this.cmbMarca.TabIndex = 10;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(31, 84);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(54, 19);
            this.lblMarca.TabIndex = 3;
            this.lblMarca.Text = "Marca";
            // 
            // lstClientes
            // 
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.ItemHeight = 15;
            this.lstClientes.Location = new System.Drawing.Point(565, 16);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(470, 214);
            this.lstClientes.TabIndex = 1;
            this.lstClientes.SelectedIndexChanged += new System.EventHandler(this.lstClientes_SelectedIndexChanged);
            // 
            // btnGuardarClientes
            // 
            this.btnGuardarClientes.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardarClientes.Location = new System.Drawing.Point(12, 262);
            this.btnGuardarClientes.Name = "btnGuardarClientes";
            this.btnGuardarClientes.Size = new System.Drawing.Size(151, 47);
            this.btnGuardarClientes.TabIndex = 9;
            this.btnGuardarClientes.Text = "Exportar Lista";
            this.btnGuardarClientes.UseVisualStyleBackColor = true;
            this.btnGuardarClientes.Click += new System.EventHandler(this.btnGuardarClientes_Click);
            // 
            // timerHoraFecha
            // 
            this.timerHoraFecha.Enabled = true;
            this.timerHoraFecha.Tick += new System.EventHandler(this.timerHoraFecha_Tick);
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblHora.Location = new System.Drawing.Point(18, 630);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(0, 22);
            this.lblHora.TabIndex = 10;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lblFecha.Location = new System.Drawing.Point(18, 597);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 23);
            this.lblFecha.TabIndex = 11;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1065, 658);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.btnGuardarClientes);
            this.Controls.Add(this.lstClientes);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.cmbProductos);
            this.Controls.Add(this.gpbProducto);
            this.Controls.Add(this.btnMostrarServicio);
            this.Controls.Add(this.gpbRegistro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.gpbRegistro.ResumeLayout(false);
            this.gpbRegistro.PerformLayout();
            this.gpbProducto.ResumeLayout(false);
            this.gpbProducto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbRegistro;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Button btnRegistarse;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnMostrarServicio;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.ComboBox cmbProductos;
        private System.Windows.Forms.GroupBox gpbProducto;
        private System.Windows.Forms.Button btnCargarFalla;
        private System.Windows.Forms.CheckBox ckbFallaTres;
        private System.Windows.Forms.CheckBox ckbFallaDos;
        private System.Windows.Forms.CheckBox ckbFallaUno;
        private System.Windows.Forms.Label lblFallas;
        private System.Windows.Forms.Label lblTipoControl;
        private System.Windows.Forms.RadioButton rdbAire;
        private System.Windows.Forms.RadioButton rdbTv;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbModelo;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ListBox lstClientes;
        private System.Windows.Forms.ComboBox cmbEntrega;
        private System.Windows.Forms.Label lblTipoEntrega;
        private System.Windows.Forms.Label lblPrecioFinal;
        private System.Windows.Forms.Button btnGuardarClientes;
        private System.Windows.Forms.Timer timerHoraFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
    }
}