namespace wfZenova
{
    partial class frmEntrenadorAdm
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
            this.dgvEntrenadores = new System.Windows.Forms.DataGridView();
            this.txtBuscarComp = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnRegistrarEntrenador = new System.Windows.Forms.Button();
            this.btnVer = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnRemplazar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrenadores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEntrenadores
            // 
            this.dgvEntrenadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntrenadores.Location = new System.Drawing.Point(58, 249);
            this.dgvEntrenadores.Name = "dgvEntrenadores";
            this.dgvEntrenadores.ReadOnly = true;
            this.dgvEntrenadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntrenadores.Size = new System.Drawing.Size(1125, 396);
            this.dgvEntrenadores.TabIndex = 79;
            // 
            // txtBuscarComp
            // 
            this.txtBuscarComp.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarComp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.txtBuscarComp.Location = new System.Drawing.Point(98, 112);
            this.txtBuscarComp.Name = "txtBuscarComp";
            this.txtBuscarComp.Size = new System.Drawing.Size(251, 31);
            this.txtBuscarComp.TabIndex = 76;
            this.txtBuscarComp.Text = "Buscar entrenador";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.label13.Location = new System.Drawing.Point(98, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(296, 28);
            this.label13.TabIndex = 74;
            this.label13.Text = "Gestión de Entrenadores";
            // 
            // btnRegistrarEntrenador
            // 
            this.btnRegistrarEntrenador.BackgroundImage = global::wfZenova.Properties.Resources.btnCuadro;
            this.btnRegistrarEntrenador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegistrarEntrenador.FlatAppearance.BorderSize = 0;
            this.btnRegistrarEntrenador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarEntrenador.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarEntrenador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.btnRegistrarEntrenador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarEntrenador.Location = new System.Drawing.Point(58, 203);
            this.btnRegistrarEntrenador.Name = "btnRegistrarEntrenador";
            this.btnRegistrarEntrenador.Size = new System.Drawing.Size(177, 39);
            this.btnRegistrarEntrenador.TabIndex = 83;
            this.btnRegistrarEntrenador.Text = "Nuevo";
            this.btnRegistrarEntrenador.UseVisualStyleBackColor = true;
            this.btnRegistrarEntrenador.Click += new System.EventHandler(this.btnRegistrarEntrenador_Click);
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
            this.btnVer.Location = new System.Drawing.Point(749, 203);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(105, 39);
            this.btnVer.TabIndex = 82;
            this.btnVer.Text = "Ver";
            this.btnVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
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
            this.btnEditar.Location = new System.Drawing.Point(860, 204);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(140, 39);
            this.btnEditar.TabIndex = 81;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnRemplazar
            // 
            this.btnRemplazar.BackgroundImage = global::wfZenova.Properties.Resources.btnCuadro;
            this.btnRemplazar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemplazar.FlatAppearance.BorderSize = 0;
            this.btnRemplazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemplazar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemplazar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.btnRemplazar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemplazar.Location = new System.Drawing.Point(1006, 204);
            this.btnRemplazar.Name = "btnRemplazar";
            this.btnRemplazar.Size = new System.Drawing.Size(177, 39);
            this.btnRemplazar.TabIndex = 80;
            this.btnRemplazar.Text = "Remplazar";
            this.btnRemplazar.UseVisualStyleBackColor = true;
            this.btnRemplazar.Click += new System.EventHandler(this.btnRemplazar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::wfZenova.Properties.Resources.imgCuadroBlanco;
            this.pictureBox2.Location = new System.Drawing.Point(12, 81);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1225, 86);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 75;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::wfZenova.Properties.Resources.IcDEPORTISTAS;
            this.pictureBox1.Location = new System.Drawing.Point(12, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 72;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::wfZenova.Properties.Resources.CuadroBlanco;
            this.pictureBox3.Location = new System.Drawing.Point(-8, 173);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1245, 582);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 78;
            this.pictureBox3.TabStop = false;
            // 
            // frmEntrenadorAdm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1234, 768);
            this.Controls.Add(this.btnRegistrarEntrenador);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnRemplazar);
            this.Controls.Add(this.dgvEntrenadores);
            this.Controls.Add(this.txtBuscarComp);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEntrenadorAdm";
            this.Text = "frmEntrenadorAdm";
            this.Load += new System.EventHandler(this.frmEntrenadorAdm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrenadores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEntrenadores;
        private System.Windows.Forms.TextBox txtBuscarComp;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnRemplazar;
        private System.Windows.Forms.Button btnRegistrarEntrenador;
    }
}