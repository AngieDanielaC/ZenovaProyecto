namespace wfZenova
{
    partial class frmVerCompetencias
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
            this.txtBuscarCompetencia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.dgvCompetencias = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblDeporte = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblNombreDeportista = new System.Windows.Forms.Label();
            this.lblTotalCompetencias = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDeporte = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetencias)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscarCompetencia
            // 
            this.txtBuscarCompetencia.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCompetencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(7)))), ((int)(((byte)(63)))));
            this.txtBuscarCompetencia.Location = new System.Drawing.Point(60, 222);
            this.txtBuscarCompetencia.Name = "txtBuscarCompetencia";
            this.txtBuscarCompetencia.Size = new System.Drawing.Size(416, 27);
            this.txtBuscarCompetencia.TabIndex = 30;
            this.txtBuscarCompetencia.TextChanged += new System.EventHandler(this.txtBuscarCompetencia_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(7)))), ((int)(((byte)(63)))));
            this.label2.Location = new System.Drawing.Point(89, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(356, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Consulta las competencias registradas del deportista.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(7)))), ((int)(((byte)(63)))));
            this.label1.Location = new System.Drawing.Point(87, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Historial de Competencias";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::wfZenova.Properties.Resources.comp5;
            this.pictureBox3.Location = new System.Drawing.Point(28, 177);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1177, 530);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::wfZenova.Properties.Resources.comp5;
            this.pictureBox2.Location = new System.Drawing.Point(25, 79);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1177, 95);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // dgvCompetencias
            // 
            this.dgvCompetencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompetencias.Location = new System.Drawing.Point(70, 274);
            this.dgvCompetencias.Name = "dgvCompetencias";
            this.dgvCompetencias.Size = new System.Drawing.Size(1083, 386);
            this.dgvCompetencias.TabIndex = 35;
            // 
            // btnVolver
            // 
            this.btnVolver.BackgroundImage = global::wfZenova.Properties.Resources.btnVolver;
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Location = new System.Drawing.Point(12, 32);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(56, 41);
            this.btnVolver.TabIndex = 36;
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblDeporte
            // 
            this.lblDeporte.AutoSize = true;
            this.lblDeporte.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(7)))), ((int)(((byte)(63)))));
            this.lblDeporte.Location = new System.Drawing.Point(74, 119);
            this.lblDeporte.Name = "lblDeporte";
            this.lblDeporte.Size = new System.Drawing.Size(104, 22);
            this.lblDeporte.TabIndex = 60;
            this.lblDeporte.Text = "- Atletismo";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(135)))), ((int)(((byte)(90)))));
            this.lblEstado.Location = new System.Drawing.Point(190, 91);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(70, 23);
            this.lblEstado.TabIndex = 59;
            this.lblEstado.Text = "Activo";
            // 
            // lblNombreDeportista
            // 
            this.lblNombreDeportista.AutoSize = true;
            this.lblNombreDeportista.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreDeportista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(7)))), ((int)(((byte)(63)))));
            this.lblNombreDeportista.Location = new System.Drawing.Point(55, 90);
            this.lblNombreDeportista.Name = "lblNombreDeportista";
            this.lblNombreDeportista.Size = new System.Drawing.Size(123, 25);
            this.lblNombreDeportista.TabIndex = 58;
            this.lblNombreDeportista.Text = "Juan Pérez";
            // 
            // lblTotalCompetencias
            // 
            this.lblTotalCompetencias.AutoSize = true;
            this.lblTotalCompetencias.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCompetencias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(7)))), ((int)(((byte)(63)))));
            this.lblTotalCompetencias.Location = new System.Drawing.Point(301, 122);
            this.lblTotalCompetencias.Name = "lblTotalCompetencias";
            this.lblTotalCompetencias.Size = new System.Drawing.Size(188, 19);
            this.lblTotalCompetencias.TabIndex = 61;
            this.lblTotalCompetencias.Text = "Total de Competencias";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(7)))), ((int)(((byte)(63)))));
            this.label3.Location = new System.Drawing.Point(74, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 19);
            this.label3.TabIndex = 62;
            this.label3.Text = "Buscar Competencia:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(7)))), ((int)(((byte)(63)))));
            this.label4.Location = new System.Drawing.Point(508, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 19);
            this.label4.TabIndex = 63;
            this.label4.Text = "Deporte:";
            // 
            // cmbDeporte
            // 
            this.cmbDeporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDeporte.FormattingEnabled = true;
            this.cmbDeporte.Location = new System.Drawing.Point(605, 215);
            this.cmbDeporte.Name = "cmbDeporte";
            this.cmbDeporte.Size = new System.Drawing.Size(278, 33);
            this.cmbDeporte.TabIndex = 151;
            this.cmbDeporte.SelectedIndexChanged += new System.EventHandler(this.cmbDeporte_SelectedIndexChanged);
            // 
            // frmVerCompetencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1234, 768);
            this.Controls.Add(this.cmbDeporte);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalCompetencias);
            this.Controls.Add(this.lblDeporte);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblNombreDeportista);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvCompetencias);
            this.Controls.Add(this.txtBuscarCompetencia);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVerCompetencias";
            this.Text = "frmVerCompetencias";
            this.Load += new System.EventHandler(this.frmVerCompetencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBuscarCompetencia;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCompetencias;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblDeporte;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblNombreDeportista;
        private System.Windows.Forms.Label lblTotalCompetencias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDeporte;
    }
}