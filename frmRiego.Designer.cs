namespace wfZenova
{
    partial class frmRiego
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbnBajo = new System.Windows.Forms.RadioButton();
            this.rbnMedio = new System.Windows.Forms.RadioButton();
            this.rbnAlto = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbhorasS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSelDeportista = new System.Windows.Forms.ComboBox();
            this.lblBRisk = new System.Windows.Forms.Label();
            this.pcbIE = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnRegisterSueño = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvRiesgo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pcbIE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiesgo)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(28)))), ((int)(((byte)(70)))));
            this.label2.Location = new System.Drawing.Point(147, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "/ Registro de Sueño";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(99)))), ((int)(((byte)(202)))));
            this.label1.Location = new System.Drawing.Point(23, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "BIENESTAR";
            // 
            // rbnBajo
            // 
            this.rbnBajo.AutoSize = true;
            this.rbnBajo.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnBajo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(28)))), ((int)(((byte)(70)))));
            this.rbnBajo.Location = new System.Drawing.Point(152, 503);
            this.rbnBajo.Margin = new System.Windows.Forms.Padding(2);
            this.rbnBajo.Name = "rbnBajo";
            this.rbnBajo.Size = new System.Drawing.Size(69, 27);
            this.rbnBajo.TabIndex = 15;
            this.rbnBajo.TabStop = true;
            this.rbnBajo.Text = "Bajo";
            this.rbnBajo.UseVisualStyleBackColor = true;
            // 
            // rbnMedio
            // 
            this.rbnMedio.AutoSize = true;
            this.rbnMedio.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnMedio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(28)))), ((int)(((byte)(70)))));
            this.rbnMedio.Location = new System.Drawing.Point(152, 445);
            this.rbnMedio.Margin = new System.Windows.Forms.Padding(2);
            this.rbnMedio.Name = "rbnMedio";
            this.rbnMedio.Size = new System.Drawing.Size(87, 27);
            this.rbnMedio.TabIndex = 14;
            this.rbnMedio.TabStop = true;
            this.rbnMedio.Text = "Medio";
            this.rbnMedio.UseVisualStyleBackColor = true;
            // 
            // rbnAlto
            // 
            this.rbnAlto.AutoSize = true;
            this.rbnAlto.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbnAlto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(28)))), ((int)(((byte)(70)))));
            this.rbnAlto.Location = new System.Drawing.Point(152, 387);
            this.rbnAlto.Margin = new System.Windows.Forms.Padding(2);
            this.rbnAlto.Name = "rbnAlto";
            this.rbnAlto.Size = new System.Drawing.Size(65, 27);
            this.rbnAlto.TabIndex = 13;
            this.rbnAlto.TabStop = true;
            this.rbnAlto.Text = "Alto";
            this.rbnAlto.UseVisualStyleBackColor = true;
            this.rbnAlto.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(28)))), ((int)(((byte)(70)))));
            this.label3.Location = new System.Drawing.Point(64, 347);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Intensidad de entrenamiento";
            // 
            // txtbhorasS
            // 
            this.txtbhorasS.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbhorasS.Location = new System.Drawing.Point(95, 298);
            this.txtbhorasS.Margin = new System.Windows.Forms.Padding(2);
            this.txtbhorasS.Name = "txtbhorasS";
            this.txtbhorasS.Size = new System.Drawing.Size(259, 27);
            this.txtbhorasS.TabIndex = 11;
            this.txtbhorasS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbhorasS_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(28)))), ((int)(((byte)(70)))));
            this.label4.Location = new System.Drawing.Point(90, 257);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(225, 23);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ingrese Horas de Sueño";
            // 
            // cmbSelDeportista
            // 
            this.cmbSelDeportista.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSelDeportista.FormattingEnabled = true;
            this.cmbSelDeportista.Location = new System.Drawing.Point(94, 200);
            this.cmbSelDeportista.Margin = new System.Windows.Forms.Padding(2);
            this.cmbSelDeportista.Name = "cmbSelDeportista";
            this.cmbSelDeportista.Size = new System.Drawing.Size(259, 27);
            this.cmbSelDeportista.TabIndex = 9;
            // 
            // lblBRisk
            // 
            this.lblBRisk.AutoSize = true;
            this.lblBRisk.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBRisk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(28)))), ((int)(((byte)(70)))));
            this.lblBRisk.Location = new System.Drawing.Point(89, 156);
            this.lblBRisk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBRisk.Name = "lblBRisk";
            this.lblBRisk.Size = new System.Drawing.Size(200, 23);
            this.lblBRisk.TabIndex = 8;
            this.lblBRisk.Text = "Seleccion deportista";
            // 
            // pcbIE
            // 
            this.pcbIE.Image = global::wfZenova.Properties.Resources.CuaColores;
            this.pcbIE.Location = new System.Drawing.Point(54, 373);
            this.pcbIE.Name = "pcbIE";
            this.pcbIE.Size = new System.Drawing.Size(287, 168);
            this.pcbIE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbIE.TabIndex = 64;
            this.pcbIE.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::wfZenova.Properties.Resources.CuBien;
            this.pictureBox3.Location = new System.Drawing.Point(28, 157);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(62, 168);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 63;
            this.pictureBox3.TabStop = false;
            // 
            // btnRegisterSueño
            // 
            this.btnRegisterSueño.BackgroundImage = global::wfZenova.Properties.Resources.BotonMas;
            this.btnRegisterSueño.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegisterSueño.FlatAppearance.BorderSize = 0;
            this.btnRegisterSueño.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterSueño.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterSueño.ForeColor = System.Drawing.Color.White;
            this.btnRegisterSueño.Location = new System.Drawing.Point(95, 557);
            this.btnRegisterSueño.Name = "btnRegisterSueño";
            this.btnRegisterSueño.Size = new System.Drawing.Size(213, 40);
            this.btnRegisterSueño.TabIndex = 62;
            this.btnRegisterSueño.Text = "Registrar";
            this.btnRegisterSueño.UseVisualStyleBackColor = true;
            this.btnRegisterSueño.Click += new System.EventHandler(this.btnRegisterSueño_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::wfZenova.Properties.Resources.raBlanco;
            this.pictureBox2.Location = new System.Drawing.Point(397, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(833, 776);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::wfZenova.Properties.Resources.raBlanco;
            this.pictureBox1.Location = new System.Drawing.Point(12, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(379, 684);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // dgvRiesgo
            // 
            this.dgvRiesgo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRiesgo.Location = new System.Drawing.Point(432, 107);
            this.dgvRiesgo.Name = "dgvRiesgo";
            this.dgvRiesgo.Size = new System.Drawing.Size(767, 592);
            this.dgvRiesgo.TabIndex = 65;
            // 
            // frmRiego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1234, 768);
            this.Controls.Add(this.dgvRiesgo);
            this.Controls.Add(this.rbnBajo);
            this.Controls.Add(this.rbnMedio);
            this.Controls.Add(this.rbnAlto);
            this.Controls.Add(this.pcbIE);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnRegisterSueño);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbhorasS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSelDeportista);
            this.Controls.Add(this.lblBRisk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRiego";
            this.Text = "frmRiego";
            this.Load += new System.EventHandler(this.frmRiego_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbIE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiesgo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rbnBajo;
        private System.Windows.Forms.RadioButton rbnMedio;
        private System.Windows.Forms.RadioButton rbnAlto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbhorasS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSelDeportista;
        private System.Windows.Forms.Label lblBRisk;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnRegisterSueño;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pcbIE;
        private System.Windows.Forms.DataGridView dgvRiesgo;
    }
}