namespace wfZenova
{
    partial class frmDeportistas
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
            this.txtBuscarDeportista = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDeportistas = new System.Windows.Forms.DataGridView();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbFiltroDeporte = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnVer = new System.Windows.Forms.Button();
            this.btnDatosDeportivos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeportistas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscarDeportista
            // 
            this.txtBuscarDeportista.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarDeportista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.txtBuscarDeportista.Location = new System.Drawing.Point(65, 122);
            this.txtBuscarDeportista.Name = "txtBuscarDeportista";
            this.txtBuscarDeportista.Size = new System.Drawing.Size(320, 27);
            this.txtBuscarDeportista.TabIndex = 55;
            this.txtBuscarDeportista.TextChanged += new System.EventHandler(this.txtBuscarDeportista_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.label13.Location = new System.Drawing.Point(101, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(141, 28);
            this.label13.TabIndex = 53;
            this.label13.Text = "Deportistas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.label2.Location = new System.Drawing.Point(97, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(523, 21);
            this.label2.TabIndex = 52;
            this.label2.Text = "Administra y consulta la informacion de los deportistas registrados.";
            // 
            // dgvDeportistas
            // 
            this.dgvDeportistas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeportistas.Location = new System.Drawing.Point(65, 289);
            this.dgvDeportistas.Name = "dgvDeportistas";
            this.dgvDeportistas.Size = new System.Drawing.Size(1106, 450);
            this.dgvDeportistas.TabIndex = 62;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.Color.White;
            this.lblEstado.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.lblEstado.Location = new System.Drawing.Point(448, 98);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(72, 18);
            this.lblEstado.TabIndex = 58;
            this.lblEstado.Text = "Deporte:";
            // 
            // cmbFiltroDeporte
            // 
            this.cmbFiltroDeporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroDeporte.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltroDeporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.cmbFiltroDeporte.FormattingEnabled = true;
            this.cmbFiltroDeporte.Items.AddRange(new object[] {
            "Todos",
            "Activos",
            "Inactivos"});
            this.cmbFiltroDeporte.Location = new System.Drawing.Point(451, 122);
            this.cmbFiltroDeporte.Name = "cmbFiltroDeporte";
            this.cmbFiltroDeporte.Size = new System.Drawing.Size(109, 29);
            this.cmbFiltroDeporte.TabIndex = 56;
            this.cmbFiltroDeporte.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroDeporte_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.label1.Location = new System.Drawing.Point(664, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 65;
            this.label1.Text = "Estado:";
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.cmbFiltroEstado.FormattingEnabled = true;
            this.cmbFiltroEstado.Items.AddRange(new object[] {
            "Todos",
            "Activos",
            "Inactivos"});
            this.cmbFiltroEstado.Location = new System.Drawing.Point(667, 122);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(109, 29);
            this.cmbFiltroEstado.TabIndex = 64;
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroEstado_SelectedIndexChanged);
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackgroundImage = global::wfZenova.Properties.Resources.btnCuadro;
            this.btnHistorial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHistorial.FlatAppearance.BorderSize = 0;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.btnHistorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorial.Location = new System.Drawing.Point(994, 234);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(177, 39);
            this.btnHistorial.TabIndex = 80;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // btnVer
            // 
            this.btnVer.BackgroundImage = global::wfZenova.Properties.Resources.btnCuadro;
            this.btnVer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVer.FlatAppearance.BorderSize = 0;
            this.btnVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVer.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.btnVer.Image = global::wfZenova.Properties.Resources.icoVer;
            this.btnVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(451, 234);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(354, 39);
            this.btnVer.TabIndex = 79;
            this.btnVer.Text = "Ver información personal";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnDatosDeportivos
            // 
            this.btnDatosDeportivos.BackgroundImage = global::wfZenova.Properties.Resources.btnCuadro;
            this.btnDatosDeportivos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDatosDeportivos.FlatAppearance.BorderSize = 0;
            this.btnDatosDeportivos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatosDeportivos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatosDeportivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.btnDatosDeportivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDatosDeportivos.Location = new System.Drawing.Point(811, 234);
            this.btnDatosDeportivos.Name = "btnDatosDeportivos";
            this.btnDatosDeportivos.Size = new System.Drawing.Size(177, 39);
            this.btnDatosDeportivos.TabIndex = 78;
            this.btnDatosDeportivos.Text = "Datos Deportivos";
            this.btnDatosDeportivos.UseVisualStyleBackColor = true;
            this.btnDatosDeportivos.Click += new System.EventHandler(this.btnDatosDeportivos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::wfZenova.Properties.Resources.IcDEPORTISTAS;
            this.pictureBox1.Location = new System.Drawing.Point(20, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 51;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::wfZenova.Properties.Resources.CuadroBlanco;
            this.pictureBox3.Location = new System.Drawing.Point(12, 180);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1202, 601);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 61;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::wfZenova.Properties.Resources.CuadroBlanco;
            this.pictureBox2.Location = new System.Drawing.Point(12, 84);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1202, 91);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 63;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.label3.Location = new System.Drawing.Point(51, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 18);
            this.label3.TabIndex = 81;
            this.label3.Text = "Buscar deportista:";
            // 
            // frmDeportistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1234, 768);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.btnDatosDeportivos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFiltroEstado);
            this.Controls.Add(this.dgvDeportistas);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbFiltroDeporte);
            this.Controls.Add(this.txtBuscarDeportista);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDeportistas";
            this.Text = "frmDeportistas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeportistas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBuscarDeportista;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.DataGridView dgvDeportistas;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbFiltroDeporte;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Button btnDatosDeportivos;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Label label3;
    }
}