namespace Vista
{
    partial class frmHabilitarCliente
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
            this.lstClientes = new System.Windows.Forms.ListBox();
            this.btnHabilitarCliente = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstClientes
            // 
            this.lstClientes.FormattingEnabled = true;
            this.lstClientes.ItemHeight = 15;
            this.lstClientes.Location = new System.Drawing.Point(62, 39);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(605, 229);
            this.lstClientes.TabIndex = 2;
            // 
            // btnHabilitarCliente
            // 
            this.btnHabilitarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnHabilitarCliente.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnHabilitarCliente.Location = new System.Drawing.Point(146, 301);
            this.btnHabilitarCliente.Name = "btnHabilitarCliente";
            this.btnHabilitarCliente.Size = new System.Drawing.Size(170, 47);
            this.btnHabilitarCliente.TabIndex = 5;
            this.btnHabilitarCliente.Text = "Habilitar Cliente";
            this.btnHabilitarCliente.UseVisualStyleBackColor = false;
            this.btnHabilitarCliente.Click += new System.EventHandler(this.btnHabilitarCliente_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSalir.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnSalir.Location = new System.Drawing.Point(392, 301);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(170, 47);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmHabilitarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(750, 382);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnHabilitarCliente);
            this.Controls.Add(this.lstClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHabilitarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHabilitarCliente";
            this.Load += new System.EventHandler(this.frmHabilitarCliente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstClientes;
        private System.Windows.Forms.Button btnHabilitarCliente;
        private System.Windows.Forms.Button btnSalir;
    }
}