namespace Vista
{
    partial class frmServicios
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
            this.lstServicios = new System.Windows.Forms.ListBox();
            this.btnCrearTicket = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCalcularCosto = new System.Windows.Forms.Button();
            this.lblCostoFinal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstServicios
            // 
            this.lstServicios.BackColor = System.Drawing.Color.Silver;
            this.lstServicios.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lstServicios.ForeColor = System.Drawing.Color.Black;
            this.lstServicios.FormattingEnabled = true;
            this.lstServicios.ItemHeight = 15;
            this.lstServicios.Location = new System.Drawing.Point(27, 51);
            this.lstServicios.Name = "lstServicios";
            this.lstServicios.Size = new System.Drawing.Size(1198, 184);
            this.lstServicios.TabIndex = 3;
            // 
            // btnCrearTicket
            // 
            this.btnCrearTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCrearTicket.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnCrearTicket.Location = new System.Drawing.Point(394, 253);
            this.btnCrearTicket.Name = "btnCrearTicket";
            this.btnCrearTicket.Size = new System.Drawing.Size(144, 47);
            this.btnCrearTicket.TabIndex = 4;
            this.btnCrearTicket.Text = "Crear Ticket";
            this.btnCrearTicket.UseVisualStyleBackColor = false;
            this.btnCrearTicket.Click += new System.EventHandler(this.btnCrearTicket_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSalir.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnSalir.Location = new System.Drawing.Point(648, 253);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(144, 47);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnCalcularCosto
            // 
            this.btnCalcularCosto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCalcularCosto.Font = new System.Drawing.Font("Roboto Condensed", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnCalcularCosto.Location = new System.Drawing.Point(142, 253);
            this.btnCalcularCosto.Name = "btnCalcularCosto";
            this.btnCalcularCosto.Size = new System.Drawing.Size(144, 47);
            this.btnCalcularCosto.TabIndex = 6;
            this.btnCalcularCosto.Text = "Calcular Costo";
            this.btnCalcularCosto.UseVisualStyleBackColor = false;
            this.btnCalcularCosto.Click += new System.EventHandler(this.btnCalcularCosto_Click);
            // 
            // lblCostoFinal
            // 
            this.lblCostoFinal.AutoSize = true;
            this.lblCostoFinal.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblCostoFinal.Location = new System.Drawing.Point(76, 14);
            this.lblCostoFinal.Name = "lblCostoFinal";
            this.lblCostoFinal.Size = new System.Drawing.Size(0, 28);
            this.lblCostoFinal.TabIndex = 7;
            // 
            // frmServicios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1237, 331);
            this.Controls.Add(this.lblCostoFinal);
            this.Controls.Add(this.btnCalcularCosto);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCrearTicket);
            this.Controls.Add(this.lstServicios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmServicios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Servicios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmServicios_FormClosing);
            this.Load += new System.EventHandler(this.frmServicios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lstServicios;
        private System.Windows.Forms.Button btnCrearTicket;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCalcularCosto;
        private System.Windows.Forms.Label lblCostoFinal;
    }
}