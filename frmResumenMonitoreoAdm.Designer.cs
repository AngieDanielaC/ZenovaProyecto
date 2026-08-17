namespace wfZenova
{
    partial class frmResumenMonitoreoAdm
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
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.lblDeporte = new System.Windows.Forms.Label();
            this.cbmDeporte = new System.Windows.Forms.ComboBox();
            this.bttActualizar = new System.Windows.Forms.Button();
            this.picResumen = new System.Windows.Forms.PictureBox();
            this.flpIndicadores = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlEntrenadoresActivos = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTotaldeEntrenadores = new System.Windows.Forms.Label();
            this.pnlEncabezado.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResumen)).BeginInit();
            this.flpIndicadores.SuspendLayout();
            this.pnlEntrenadoresActivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.picResumen);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1218, 120);
            this.pnlEncabezado.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(43)))), ((int)(((byte)(105)))));
            this.lblTitulo.Location = new System.Drawing.Point(140, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(429, 32);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Resumen General de Monitoreo";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(142, 71);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(451, 20);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Vista general del seguimiento de entrenadores y deportistas.";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.pnlFiltros.Controls.Add(this.bttActualizar);
            this.pnlFiltros.Controls.Add(this.cbmDeporte);
            this.pnlFiltros.Controls.Add(this.lblDeporte);
            this.pnlFiltros.Controls.Add(this.cmbPeriodo);
            this.pnlFiltros.Controls.Add(this.lblPeriodo);
            this.pnlFiltros.Location = new System.Drawing.Point(486, 135);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(620, 70);
            this.pnlFiltros.TabIndex = 2;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(20, 24);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(66, 17);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Periodo: ";
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Items.AddRange(new object[] {
            "Este mes",
            "",
            "Últimos 3 meses",
            "",
            "Este año"});
            this.cmbPeriodo.Location = new System.Drawing.Point(85, 20);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(145, 25);
            this.cmbPeriodo.TabIndex = 1;
            // 
            // lblDeporte
            // 
            this.lblDeporte.AutoSize = true;
            this.lblDeporte.Location = new System.Drawing.Point(250, 24);
            this.lblDeporte.Name = "lblDeporte";
            this.lblDeporte.Size = new System.Drawing.Size(69, 17);
            this.lblDeporte.TabIndex = 2;
            this.lblDeporte.Text = "Deporte: ";
            // 
            // cbmDeporte
            // 
            this.cbmDeporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmDeporte.FormattingEnabled = true;
            this.cbmDeporte.Items.AddRange(new object[] {
            "Este mes",
            "",
            "Últimos 3 meses",
            "",
            "Este año"});
            this.cbmDeporte.Location = new System.Drawing.Point(320, 20);
            this.cbmDeporte.Name = "cbmDeporte";
            this.cbmDeporte.Size = new System.Drawing.Size(140, 25);
            this.cbmDeporte.TabIndex = 3;
            // 
            // bttActualizar
            // 
            this.bttActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bttActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttActualizar.FlatAppearance.BorderSize = 0;
            this.bttActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttActualizar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttActualizar.ForeColor = System.Drawing.Color.White;
            this.bttActualizar.Image = global::wfZenova.Properties.Resources.converted_image__1_1;
            this.bttActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttActualizar.Location = new System.Drawing.Point(480, 14);
            this.bttActualizar.Name = "bttActualizar";
            this.bttActualizar.Size = new System.Drawing.Size(120, 40);
            this.bttActualizar.TabIndex = 4;
            this.bttActualizar.Text = "Actualizar";
            this.bttActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bttActualizar.UseVisualStyleBackColor = false;
            // 
            // picResumen
            // 
            this.picResumen.Location = new System.Drawing.Point(30, 15);
            this.picResumen.Name = "picResumen";
            this.picResumen.Size = new System.Drawing.Size(90, 90);
            this.picResumen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picResumen.TabIndex = 0;
            this.picResumen.TabStop = false;
            // 
            // flpIndicadores
            // 
            this.flpIndicadores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpIndicadores.Controls.Add(this.pnlEntrenadoresActivos);
            this.flpIndicadores.Location = new System.Drawing.Point(20, 210);
            this.flpIndicadores.Name = "flpIndicadores";
            this.flpIndicadores.Padding = new System.Windows.Forms.Padding(5);
            this.flpIndicadores.Size = new System.Drawing.Size(880, 115);
            this.flpIndicadores.TabIndex = 3;
            this.flpIndicadores.WrapContents = false;
            // 
            // pnlEntrenadoresActivos
            // 
            this.pnlEntrenadoresActivos.Controls.Add(this.pictureBox1);
            this.pnlEntrenadoresActivos.Controls.Add(this.lblTotaldeEntrenadores);
            this.pnlEntrenadoresActivos.Location = new System.Drawing.Point(10, 10);
            this.pnlEntrenadoresActivos.Margin = new System.Windows.Forms.Padding(5);
            this.pnlEntrenadoresActivos.Name = "pnlEntrenadoresActivos";
            this.pnlEntrenadoresActivos.Size = new System.Drawing.Size(200, 100);
            this.pnlEntrenadoresActivos.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblTotaldeEntrenadores
            // 
            this.lblTotaldeEntrenadores.AutoSize = true;
            this.lblTotaldeEntrenadores.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotaldeEntrenadores.ForeColor = System.Drawing.Color.Navy;
            this.lblTotaldeEntrenadores.Location = new System.Drawing.Point(80, 18);
            this.lblTotaldeEntrenadores.Name = "lblTotaldeEntrenadores";
            this.lblTotaldeEntrenadores.Size = new System.Drawing.Size(26, 30);
            this.lblTotaldeEntrenadores.TabIndex = 1;
            this.lblTotaldeEntrenadores.Text = "0";
            // 
            // frmResumenMonitoreoAdm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1218, 729);
            this.Controls.Add(this.flpIndicadores);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmResumenMonitoreoAdm";
            this.Text = "Resumen de Monitoreo";
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResumen)).EndInit();
            this.flpIndicadores.ResumeLayout(false);
            this.pnlEntrenadoresActivos.ResumeLayout(false);
            this.pnlEntrenadoresActivos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.PictureBox picResumen;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblDeporte;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Button bttActualizar;
        private System.Windows.Forms.ComboBox cbmDeporte;
        private System.Windows.Forms.FlowLayoutPanel flpIndicadores;
        private System.Windows.Forms.Panel pnlEntrenadoresActivos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTotaldeEntrenadores;
    }
}