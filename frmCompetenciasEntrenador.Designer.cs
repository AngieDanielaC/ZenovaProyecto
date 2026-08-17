namespace wfZenova
{
    partial class frmCompetenciasEntrenador
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
            this.label13 = new System.Windows.Forms.Label();
            this.txtBuscarCompetencia = new System.Windows.Forms.TextBox();
            this.cmbFiltroDeporte = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvCompetencias = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAcDes = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.label13.Location = new System.Drawing.Point(12, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(184, 28);
            this.label13.TabIndex = 68;
            this.label13.Text = "Competencias";
            // 
            // txtBuscarCompetencia
            // 
            this.txtBuscarCompetencia.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCompetencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.txtBuscarCompetencia.Location = new System.Drawing.Point(46, 77);
            this.txtBuscarCompetencia.Name = "txtBuscarCompetencia";
            this.txtBuscarCompetencia.Size = new System.Drawing.Size(358, 31);
            this.txtBuscarCompetencia.TabIndex = 70;
            this.txtBuscarCompetencia.TextChanged += new System.EventHandler(this.txtBuscarCompetencia_TextChanged);
            // 
            // cmbFiltroDeporte
            // 
            this.cmbFiltroDeporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltroDeporte.FormattingEnabled = true;
            this.cmbFiltroDeporte.Location = new System.Drawing.Point(456, 75);
            this.cmbFiltroDeporte.Name = "cmbFiltroDeporte";
            this.cmbFiltroDeporte.Size = new System.Drawing.Size(278, 33);
            this.cmbFiltroDeporte.TabIndex = 150;
            this.cmbFiltroDeporte.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(85)))));
            this.label9.Location = new System.Drawing.Point(438, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 19);
            this.label9.TabIndex = 149;
            this.label9.Text = "Deporte:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvCompetencias
            // 
            this.dgvCompetencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompetencias.Location = new System.Drawing.Point(28, 173);
            this.dgvCompetencias.Name = "dgvCompetencias";
            this.dgvCompetencias.Size = new System.Drawing.Size(1184, 529);
            this.dgvCompetencias.TabIndex = 154;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::wfZenova.Properties.Resources.btnCuadro;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1035, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 39);
            this.button1.TabIndex = 152;
            this.button1.Text = "Registrar Resultados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAcDes
            // 
            this.btnAcDes.BackgroundImage = global::wfZenova.Properties.Resources.btnCuadro;
            this.btnAcDes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAcDes.FlatAppearance.BorderSize = 0;
            this.btnAcDes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcDes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcDes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.btnAcDes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcDes.Location = new System.Drawing.Point(852, 126);
            this.btnAcDes.Name = "btnAcDes";
            this.btnAcDes.Size = new System.Drawing.Size(177, 39);
            this.btnAcDes.TabIndex = 151;
            this.btnAcDes.Text = "Ver Participantes";
            this.btnAcDes.UseVisualStyleBackColor = true;
            this.btnAcDes.Click += new System.EventHandler(this.btnAcDes_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::wfZenova.Properties.Resources.CuadroBlanco;
            this.pictureBox2.Location = new System.Drawing.Point(-1, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1238, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 74;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(85)))));
            this.label1.Location = new System.Drawing.Point(24, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 19);
            this.label1.TabIndex = 155;
            this.label1.Text = "Buscar:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmCompetenciasEntrenador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1234, 768);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvCompetencias);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAcDes);
            this.Controls.Add(this.cmbFiltroDeporte);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBuscarCompetencia);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCompetenciasEntrenador";
            this.Text = "frmCompetenciasEntrenador";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBuscarCompetencia;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cmbFiltroDeporte;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAcDes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvCompetencias;
        private System.Windows.Forms.Label label1;
    }
}