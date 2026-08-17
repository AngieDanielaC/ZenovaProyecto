namespace wfZenova
{
    partial class frmCompetencias
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRegistrarCompetencia = new System.Windows.Forms.Button();
            this.btnGestionarParticipantes = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtBuscarComp = new System.Windows.Forms.TextBox();
            this.dgvCompetencias = new System.Windows.Forms.DataGridView();
            this.btnEditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetencias)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.label1.Location = new System.Drawing.Point(88, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "GESTIÓN DE COMPETENCIAS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::wfZenova.Properties.Resources.icoComp;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnRegistrarCompetencia
            // 
            this.btnRegistrarCompetencia.BackgroundImage = global::wfZenova.Properties.Resources.BotonMas;
            this.btnRegistrarCompetencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegistrarCompetencia.FlatAppearance.BorderSize = 0;
            this.btnRegistrarCompetencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarCompetencia.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarCompetencia.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarCompetencia.Location = new System.Drawing.Point(942, 104);
            this.btnRegistrarCompetencia.Name = "btnRegistrarCompetencia";
            this.btnRegistrarCompetencia.Size = new System.Drawing.Size(241, 39);
            this.btnRegistrarCompetencia.TabIndex = 71;
            this.btnRegistrarCompetencia.Text = "Registrar competencia";
            this.btnRegistrarCompetencia.UseVisualStyleBackColor = true;
            this.btnRegistrarCompetencia.Click += new System.EventHandler(this.btnRegistrarCompetencia_Click);
            // 
            // btnGestionarParticipantes
            // 
            this.btnGestionarParticipantes.BackgroundImage = global::wfZenova.Properties.Resources.btnCuadro;
            this.btnGestionarParticipantes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGestionarParticipantes.FlatAppearance.BorderSize = 0;
            this.btnGestionarParticipantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionarParticipantes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarParticipantes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.btnGestionarParticipantes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionarParticipantes.Location = new System.Drawing.Point(1005, 196);
            this.btnGestionarParticipantes.Name = "btnGestionarParticipantes";
            this.btnGestionarParticipantes.Size = new System.Drawing.Size(197, 39);
            this.btnGestionarParticipantes.TabIndex = 76;
            this.btnGestionarParticipantes.Text = "Gestionar participantes";
            this.btnGestionarParticipantes.UseVisualStyleBackColor = true;
            this.btnGestionarParticipantes.Click += new System.EventHandler(this.btnGestionarParticipantes_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::wfZenova.Properties.Resources.CuadroBlanco;
            this.pictureBox2.Location = new System.Drawing.Point(12, 83);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1190, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 79;
            this.pictureBox2.TabStop = false;
            // 
            // txtBuscarComp
            // 
            this.txtBuscarComp.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarComp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.txtBuscarComp.Location = new System.Drawing.Point(54, 104);
            this.txtBuscarComp.Name = "txtBuscarComp";
            this.txtBuscarComp.Size = new System.Drawing.Size(419, 31);
            this.txtBuscarComp.TabIndex = 80;
            this.txtBuscarComp.Text = "Buscar";
            // 
            // dgvCompetencias
            // 
            this.dgvCompetencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompetencias.Location = new System.Drawing.Point(34, 253);
            this.dgvCompetencias.Name = "dgvCompetencias";
            this.dgvCompetencias.Size = new System.Drawing.Size(1168, 463);
            this.dgvCompetencias.TabIndex = 81;
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = global::wfZenova.Properties.Resources.btnCuadro;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.btnEditar.Image = global::wfZenova.Properties.Resources.icoEditar;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(859, 195);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(140, 39);
            this.btnEditar.TabIndex = 82;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // frmCompetencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1234, 768);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.dgvCompetencias);
            this.Controls.Add(this.txtBuscarComp);
            this.Controls.Add(this.btnGestionarParticipantes);
            this.Controls.Add(this.btnRegistrarCompetencia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCompetencias";
            this.Text = "frmCompetencias";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompetencias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistrarCompetencia;
        private System.Windows.Forms.Button btnGestionarParticipantes;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtBuscarComp;
        private System.Windows.Forms.DataGridView dgvCompetencias;
        private System.Windows.Forms.Button btnEditar;
    }
}