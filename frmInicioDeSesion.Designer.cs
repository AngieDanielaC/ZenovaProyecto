namespace wfZenova
{
    partial class frmInicioDeSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicioDeSesion));
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblIniciaSesionParaContinuar = new System.Windows.Forms.Label();
            this.lblBienvenidoDeNuevo = new System.Windows.Forms.Label();
            this.imlOjo = new System.Windows.Forms.ImageList(this.components);
            this.picVerContrasena = new System.Windows.Forms.PictureBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picVerContrasena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtContrasena
            // 
            this.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(209)))), ((int)(((byte)(239)))));
            this.txtContrasena.Location = new System.Drawing.Point(762, 344);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(221, 28);
            this.txtContrasena.TabIndex = 19;
            this.txtContrasena.Text = "Contraseña";
            this.txtContrasena.Enter += new System.EventHandler(this.txtContraseña_Enter);
            this.txtContrasena.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrasena_KeyDown);
            this.txtContrasena.Leave += new System.EventHandler(this.txtContraseña_Leave);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(209)))), ((int)(((byte)(239)))));
            this.txtUsuario.Location = new System.Drawing.Point(762, 290);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(221, 28);
            this.txtUsuario.TabIndex = 18;
            this.txtUsuario.Tag = "2";
            this.txtUsuario.Text = "Usuario";
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // lblIniciaSesionParaContinuar
            // 
            this.lblIniciaSesionParaContinuar.AutoSize = true;
            this.lblIniciaSesionParaContinuar.BackColor = System.Drawing.Color.White;
            this.lblIniciaSesionParaContinuar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIniciaSesionParaContinuar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(34)))), ((int)(((byte)(29)))));
            this.lblIniciaSesionParaContinuar.Location = new System.Drawing.Point(770, 248);
            this.lblIniciaSesionParaContinuar.Name = "lblIniciaSesionParaContinuar";
            this.lblIniciaSesionParaContinuar.Size = new System.Drawing.Size(238, 24);
            this.lblIniciaSesionParaContinuar.TabIndex = 1;
            this.lblIniciaSesionParaContinuar.Tag = "1";
            this.lblIniciaSesionParaContinuar.Text = "Inicia sesión para continuar";
            // 
            // lblBienvenidoDeNuevo
            // 
            this.lblBienvenidoDeNuevo.AutoSize = true;
            this.lblBienvenidoDeNuevo.BackColor = System.Drawing.Color.White;
            this.lblBienvenidoDeNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenidoDeNuevo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(103)))));
            this.lblBienvenidoDeNuevo.Location = new System.Drawing.Point(742, 223);
            this.lblBienvenidoDeNuevo.Name = "lblBienvenidoDeNuevo";
            this.lblBienvenidoDeNuevo.Size = new System.Drawing.Size(287, 25);
            this.lblBienvenidoDeNuevo.TabIndex = 16;
            this.lblBienvenidoDeNuevo.Tag = "1";
            this.lblBienvenidoDeNuevo.Text = "¡BIENVENIDO DE NUEVO!";
            // 
            // imlOjo
            // 
            this.imlOjo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlOjo.ImageStream")));
            this.imlOjo.TransparentColor = System.Drawing.Color.Transparent;
            this.imlOjo.Images.SetKeyName(0, "abierto.png");
            this.imlOjo.Images.SetKeyName(1, "cerrado.png");
            // 
            // picVerContrasena
            // 
            this.picVerContrasena.BackColor = System.Drawing.Color.White;
            this.picVerContrasena.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picVerContrasena.Location = new System.Drawing.Point(1000, 344);
            this.picVerContrasena.Name = "picVerContrasena";
            this.picVerContrasena.Size = new System.Drawing.Size(29, 28);
            this.picVerContrasena.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVerContrasena.TabIndex = 22;
            this.picVerContrasena.TabStop = false;
            this.picVerContrasena.Click += new System.EventHandler(this.picVerContrasena_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.White;
            this.btnRegistrar.BackgroundImage = global::wfZenova.Properties.Resources.btnRegistrar;
            this.btnRegistrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(73)))), ((int)(((byte)(103)))));
            this.btnRegistrar.Location = new System.Drawing.Point(714, 465);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(337, 79);
            this.btnRegistrar.TabIndex = 21;
            this.btnRegistrar.Text = "¿Nuevo por aqui?\r\nCrea tu cuenta y comienza hoy.\r\n";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.BackColor = System.Drawing.Color.White;
            this.btnIniciarSesion.BackgroundImage = global::wfZenova.Properties.Resources.btnLogin;
            this.btnIniciarSesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIniciarSesion.FlatAppearance.BorderSize = 0;
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.ForeColor = System.Drawing.Color.White;
            this.btnIniciarSesion.Location = new System.Drawing.Point(714, 398);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnIniciarSesion.Size = new System.Drawing.Size(337, 48);
            this.btnIniciarSesion.TabIndex = 20;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::wfZenova.Properties.Resources.RecuadroLogin;
            this.pictureBox3.Location = new System.Drawing.Point(630, 45);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(503, 548);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::wfZenova.Properties.Resources.InicioImagen2;
            this.pictureBox1.Location = new System.Drawing.Point(-105, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(770, 600);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::wfZenova.Properties.Resources.LOGO;
            this.pictureBox2.Location = new System.Drawing.Point(827, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(136, 59);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // frmInicioDeSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(198)))), ((int)(((byte)(228)))));
            this.ClientSize = new System.Drawing.Size(1136, 585);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.picVerContrasena);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblIniciaSesionParaContinuar);
            this.Controls.Add(this.lblBienvenidoDeNuevo);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmInicioDeSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInicioDeSesion";
            ((System.ComponentModel.ISupportInitialize)(this.picVerContrasena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblIniciaSesionParaContinuar;
        private System.Windows.Forms.Label lblBienvenidoDeNuevo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.ImageList imlOjo;
        private System.Windows.Forms.PictureBox picVerContrasena;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}