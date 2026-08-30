namespace wfZenova
{
    partial class frmAsignacionesAdm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsignacionesAdm));
            this.label13 = new System.Windows.Forms.Label();
            this.cmbDeportista = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNombreDeportista = new System.Windows.Forms.Label();
            this.lblEdad = new System.Windows.Forms.Label();
            this.lblDeportes = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbEntrenador = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvAsignaciones = new System.Windows.Forms.DataGridView();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbTipoInscripcion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.btnCambiarEntrenador = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.picDeportista = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDeportista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.label13.Location = new System.Drawing.Point(26, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(296, 28);
            this.label13.TabIndex = 98;
            this.label13.Text = "Inscripciones Deportivas";
            // 
            // cmbDeportista
            // 
            this.cmbDeportista.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDeportista.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDeportista.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDeportista.FormattingEnabled = true;
            this.cmbDeportista.Location = new System.Drawing.Point(56, 115);
            this.cmbDeportista.Name = "cmbDeportista";
            this.cmbDeportista.Size = new System.Drawing.Size(247, 30);
            this.cmbDeportista.TabIndex = 125;
            this.cmbDeportista.SelectedIndexChanged += new System.EventHandler(this.cmbDeportista_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(85)))));
            this.label8.Location = new System.Drawing.Point(45, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 19);
            this.label8.TabIndex = 124;
            this.label8.Text = "Seleccionar deportista:";
            // 
            // lblNombreDeportista
            // 
            this.lblNombreDeportista.AutoSize = true;
            this.lblNombreDeportista.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreDeportista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(85)))));
            this.lblNombreDeportista.Location = new System.Drawing.Point(145, 160);
            this.lblNombreDeportista.Name = "lblNombreDeportista";
            this.lblNombreDeportista.Size = new System.Drawing.Size(30, 19);
            this.lblNombreDeportista.TabIndex = 128;
            this.lblNombreDeportista.Text = "---";
            this.lblNombreDeportista.Click += new System.EventHandler(this.lblNombreDeportista_Click);
            // 
            // lblEdad
            // 
            this.lblEdad.AutoSize = true;
            this.lblEdad.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(85)))));
            this.lblEdad.Location = new System.Drawing.Point(145, 180);
            this.lblEdad.Name = "lblEdad";
            this.lblEdad.Size = new System.Drawing.Size(29, 20);
            this.lblEdad.TabIndex = 129;
            this.lblEdad.Text = "----";
            // 
            // lblDeportes
            // 
            this.lblDeportes.AutoSize = true;
            this.lblDeportes.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(85)))));
            this.lblDeportes.Location = new System.Drawing.Point(145, 200);
            this.lblDeportes.Name = "lblDeportes";
            this.lblDeportes.Size = new System.Drawing.Size(24, 20);
            this.lblDeportes.TabIndex = 130;
            this.lblDeportes.Text = "---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(85)))));
            this.label4.Location = new System.Drawing.Point(373, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 19);
            this.label4.TabIndex = 131;
            this.label4.Text = "Nueva inscripción";
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisciplina.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Items.AddRange(new object[] {
            "Karate",
            "Judo",
            "Taewook",
            "Boxeo"});
            this.cmbDisciplina.Location = new System.Drawing.Point(401, 144);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(247, 30);
            this.cmbDisciplina.TabIndex = 133;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(85)))));
            this.label5.Location = new System.Drawing.Point(390, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 19);
            this.label5.TabIndex = 132;
            this.label5.Text = "Disciplina:";
            // 
            // cmbEntrenador
            // 
            this.cmbEntrenador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntrenador.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEntrenador.FormattingEnabled = true;
            this.cmbEntrenador.Location = new System.Drawing.Point(710, 142);
            this.cmbEntrenador.Name = "cmbEntrenador";
            this.cmbEntrenador.Size = new System.Drawing.Size(247, 30);
            this.cmbEntrenador.TabIndex = 135;
            this.cmbEntrenador.SelectedIndexChanged += new System.EventHandler(this.cmbEntrenador_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(85)))));
            this.label6.Location = new System.Drawing.Point(698, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 19);
            this.label6.TabIndex = 134;
            this.label6.Text = "Entrenador:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaInicio.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Location = new System.Drawing.Point(401, 203);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(247, 31);
            this.dtpFechaInicio.TabIndex = 137;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(85)))));
            this.label7.Location = new System.Drawing.Point(390, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 19);
            this.label7.TabIndex = 136;
            this.label7.Text = "Fecha de inicio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(36)))), ((int)(((byte)(96)))));
            this.label9.Location = new System.Drawing.Point(81, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(194, 19);
            this.label9.TabIndex = 139;
            this.label9.Text = "Inscripciones Deportivas";
            // 
            // dgvAsignaciones
            // 
            this.dgvAsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsignaciones.Location = new System.Drawing.Point(132, 385);
            this.dgvAsignaciones.Name = "dgvAsignaciones";
            this.dgvAsignaciones.Size = new System.Drawing.Size(1051, 277);
            this.dgvAsignaciones.TabIndex = 159;
            this.dgvAsignaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAsignaciones_CellContentClick);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFin.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(710, 202);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(247, 31);
            this.dtpFechaFin.TabIndex = 161;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(85)))));
            this.label22.Location = new System.Drawing.Point(698, 181);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(109, 19);
            this.label22.TabIndex = 160;
            this.label22.Text = "Fecha de fin:";
            // 
            // cmbTipoInscripcion
            // 
            this.cmbTipoInscripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoInscripcion.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoInscripcion.FormattingEnabled = true;
            this.cmbTipoInscripcion.Items.AddRange(new object[] {
            "Ordinaria",
            "Vacacional"});
            this.cmbTipoInscripcion.Location = new System.Drawing.Point(991, 142);
            this.cmbTipoInscripcion.Name = "cmbTipoInscripcion";
            this.cmbTipoInscripcion.Size = new System.Drawing.Size(205, 30);
            this.cmbTipoInscripcion.TabIndex = 163;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(85)))));
            this.label1.Location = new System.Drawing.Point(979, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 162;
            this.label1.Text = "Inscripición:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(449, 334);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(255, 31);
            this.txtFiltro.TabIndex = 164;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFiltrar.BackgroundImage")));
            this.btnFiltrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFiltrar.FlatAppearance.BorderSize = 0;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(711, 332);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(46, 35);
            this.btnFiltrar.TabIndex = 165;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFinalizar.BackgroundImage")));
            this.btnFinalizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFinalizar.FlatAppearance.BorderSize = 0;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(127)))), ((int)(((byte)(130)))));
            this.btnFinalizar.Location = new System.Drawing.Point(983, 332);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(178, 33);
            this.btnFinalizar.TabIndex = 157;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // btnCambiarEntrenador
            // 
            this.btnCambiarEntrenador.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCambiarEntrenador.BackgroundImage")));
            this.btnCambiarEntrenador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCambiarEntrenador.FlatAppearance.BorderSize = 0;
            this.btnCambiarEntrenador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarEntrenador.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarEntrenador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(130)))), ((int)(((byte)(216)))));
            this.btnCambiarEntrenador.Location = new System.Drawing.Point(787, 332);
            this.btnCambiarEntrenador.Name = "btnCambiarEntrenador";
            this.btnCambiarEntrenador.Size = new System.Drawing.Size(178, 33);
            this.btnCambiarEntrenador.TabIndex = 154;
            this.btnCambiarEntrenador.Text = "Cambiar entrenador";
            this.btnCambiarEntrenador.UseVisualStyleBackColor = true;
            this.btnCambiarEntrenador.Click += new System.EventHandler(this.btnCambiarEntrenador_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregar.BackgroundImage")));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(995, 204);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(201, 29);
            this.btnAgregar.TabIndex = 138;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // picDeportista
            // 
            this.picDeportista.Image = ((System.Drawing.Image)(resources.GetObject("picDeportista.Image")));
            this.picDeportista.Location = new System.Drawing.Point(56, 160);
            this.picDeportista.Name = "picDeportista";
            this.picDeportista.Size = new System.Drawing.Size(83, 69);
            this.picDeportista.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDeportista.TabIndex = 127;
            this.picDeportista.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(49, 151);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(260, 88);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 126;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(31, 273);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1203, 515);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 101;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(332, 62);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(902, 214);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 100;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(31, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(295, 214);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 99;
            this.pictureBox1.TabStop = false;
            // 
            // frmAsignacionesAdm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1234, 768);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.cmbTipoInscripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.dgvAsignaciones);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.btnCambiarEntrenador);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbEntrenador);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDeportes);
            this.Controls.Add(this.lblEdad);
            this.Controls.Add(this.lblNombreDeportista);
            this.Controls.Add(this.picDeportista);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.cmbDeportista);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAsignacionesAdm";
            this.Text = "frmAsignacionesAdm";
            this.Load += new System.EventHandler(this.frmAsignacionesAdm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsignaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDeportista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox cmbDeportista;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox picDeportista;
        private System.Windows.Forms.Label lblNombreDeportista;
        private System.Windows.Forms.Label lblEdad;
        private System.Windows.Forms.Label lblDeportes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEntrenador;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCambiarEntrenador;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.DataGridView dgvAsignaciones;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbTipoInscripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Button btnFiltrar;
    }
}