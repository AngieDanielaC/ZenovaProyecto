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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picResumen = new System.Windows.Forms.PictureBox();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.bttActualizar = new System.Windows.Forms.Button();
            this.cbmDeporte = new System.Windows.Forms.ComboBox();
            this.lblDeporte = new System.Windows.Forms.Label();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.flpIndicadores = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlEntrenadoresActivos = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTotaldeEntrenadores = new System.Windows.Forms.Label();
            this.lblTextoEntrenadores = new System.Windows.Forms.Label();
            this.pnlDeportistasSeguimiento = new System.Windows.Forms.Panel();
            this.lblTextoDeportistas = new System.Windows.Forms.Label();
            this.picDeportistas = new System.Windows.Forms.PictureBox();
            this.lblTotalDeportistas = new System.Windows.Forms.Label();
            this.pnlCumplimientoSesiones = new System.Windows.Forms.Panel();
            this.lblTextoCumplimiento = new System.Windows.Forms.Label();
            this.picCumplimiento = new System.Windows.Forms.PictureBox();
            this.lblCumplimiento = new System.Windows.Forms.Label();
            this.pnlAlertasPendientes = new System.Windows.Forms.Panel();
            this.lblTextoAlertas = new System.Windows.Forms.Label();
            this.picAlertas = new System.Windows.Forms.PictureBox();
            this.lblTotalAlertas = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTituloSsesiones = new System.Windows.Forms.Label();
            this.dgvResumenSesiones = new System.Windows.Forms.DataGridView();
            this.colPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProgramadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRealizadas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPendientes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCumplimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResumen)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.flpIndicadores.SuspendLayout();
            this.pnlEntrenadoresActivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlDeportistasSeguimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDeportistas)).BeginInit();
            this.pnlCumplimientoSesiones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCumplimiento)).BeginInit();
            this.pnlAlertasPendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenSesiones)).BeginInit();
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
            // picResumen
            // 
            this.picResumen.Location = new System.Drawing.Point(30, 15);
            this.picResumen.Name = "picResumen";
            this.picResumen.Size = new System.Drawing.Size(90, 90);
            this.picResumen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picResumen.TabIndex = 0;
            this.picResumen.TabStop = false;
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
            // lblDeporte
            // 
            this.lblDeporte.Location = new System.Drawing.Point(250, 24);
            this.lblDeporte.Name = "lblDeporte";
            this.lblDeporte.Size = new System.Drawing.Size(69, 17);
            this.lblDeporte.TabIndex = 2;
            this.lblDeporte.Text = "Deporte: ";
            this.lblDeporte.UseCompatibleTextRendering = true;
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
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(20, 24);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(66, 17);
            this.lblPeriodo.TabIndex = 0;
            this.lblPeriodo.Text = "Periodo: ";
            // 
            // flpIndicadores
            // 
            this.flpIndicadores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpIndicadores.Controls.Add(this.pnlEntrenadoresActivos);
            this.flpIndicadores.Controls.Add(this.pnlDeportistasSeguimiento);
            this.flpIndicadores.Controls.Add(this.pnlCumplimientoSesiones);
            this.flpIndicadores.Controls.Add(this.pnlAlertasPendientes);
            this.flpIndicadores.Location = new System.Drawing.Point(20, 210);
            this.flpIndicadores.Name = "flpIndicadores";
            this.flpIndicadores.Padding = new System.Windows.Forms.Padding(5);
            this.flpIndicadores.Size = new System.Drawing.Size(853, 115);
            this.flpIndicadores.TabIndex = 3;
            this.flpIndicadores.WrapContents = false;
            // 
            // pnlEntrenadoresActivos
            // 
            this.pnlEntrenadoresActivos.Controls.Add(this.lblTextoEntrenadores);
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
            // lblTextoEntrenadores
            // 
            this.lblTextoEntrenadores.AutoSize = true;
            this.lblTextoEntrenadores.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoEntrenadores.ForeColor = System.Drawing.Color.Navy;
            this.lblTextoEntrenadores.Location = new System.Drawing.Point(80, 53);
            this.lblTextoEntrenadores.MaximumSize = new System.Drawing.Size(110, 0);
            this.lblTextoEntrenadores.Name = "lblTextoEntrenadores";
            this.lblTextoEntrenadores.Size = new System.Drawing.Size(96, 34);
            this.lblTextoEntrenadores.TabIndex = 2;
            this.lblTextoEntrenadores.Text = "Entrenadores Activos";
            this.lblTextoEntrenadores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlDeportistasSeguimiento
            // 
            this.pnlDeportistasSeguimiento.Controls.Add(this.lblTextoDeportistas);
            this.pnlDeportistasSeguimiento.Controls.Add(this.picDeportistas);
            this.pnlDeportistasSeguimiento.Controls.Add(this.lblTotalDeportistas);
            this.pnlDeportistasSeguimiento.Location = new System.Drawing.Point(220, 10);
            this.pnlDeportistasSeguimiento.Margin = new System.Windows.Forms.Padding(5);
            this.pnlDeportistasSeguimiento.Name = "pnlDeportistasSeguimiento";
            this.pnlDeportistasSeguimiento.Size = new System.Drawing.Size(200, 100);
            this.pnlDeportistasSeguimiento.TabIndex = 3;
            // 
            // lblTextoDeportistas
            // 
            this.lblTextoDeportistas.AutoSize = true;
            this.lblTextoDeportistas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoDeportistas.ForeColor = System.Drawing.Color.Navy;
            this.lblTextoDeportistas.Location = new System.Drawing.Point(80, 53);
            this.lblTextoDeportistas.MaximumSize = new System.Drawing.Size(110, 0);
            this.lblTextoDeportistas.Name = "lblTextoDeportistas";
            this.lblTextoDeportistas.Size = new System.Drawing.Size(100, 34);
            this.lblTextoDeportistas.TabIndex = 2;
            this.lblTextoDeportistas.Text = "Deportistas en Seguimiento";
            this.lblTextoDeportistas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // picDeportistas
            // 
            this.picDeportistas.Location = new System.Drawing.Point(12, 20);
            this.picDeportistas.Name = "picDeportistas";
            this.picDeportistas.Size = new System.Drawing.Size(55, 55);
            this.picDeportistas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDeportistas.TabIndex = 1;
            this.picDeportistas.TabStop = false;
            // 
            // lblTotalDeportistas
            // 
            this.lblTotalDeportistas.AutoSize = true;
            this.lblTotalDeportistas.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDeportistas.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalDeportistas.Location = new System.Drawing.Point(80, 18);
            this.lblTotalDeportistas.Name = "lblTotalDeportistas";
            this.lblTotalDeportistas.Size = new System.Drawing.Size(26, 30);
            this.lblTotalDeportistas.TabIndex = 1;
            this.lblTotalDeportistas.Text = "0";
            // 
            // pnlCumplimientoSesiones
            // 
            this.pnlCumplimientoSesiones.Controls.Add(this.lblTextoCumplimiento);
            this.pnlCumplimientoSesiones.Controls.Add(this.picCumplimiento);
            this.pnlCumplimientoSesiones.Controls.Add(this.lblCumplimiento);
            this.pnlCumplimientoSesiones.Location = new System.Drawing.Point(430, 10);
            this.pnlCumplimientoSesiones.Margin = new System.Windows.Forms.Padding(5);
            this.pnlCumplimientoSesiones.Name = "pnlCumplimientoSesiones";
            this.pnlCumplimientoSesiones.Size = new System.Drawing.Size(200, 100);
            this.pnlCumplimientoSesiones.TabIndex = 3;
            // 
            // lblTextoCumplimiento
            // 
            this.lblTextoCumplimiento.AutoSize = true;
            this.lblTextoCumplimiento.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoCumplimiento.ForeColor = System.Drawing.Color.Navy;
            this.lblTextoCumplimiento.Location = new System.Drawing.Point(80, 53);
            this.lblTextoCumplimiento.MaximumSize = new System.Drawing.Size(110, 0);
            this.lblTextoCumplimiento.Name = "lblTextoCumplimiento";
            this.lblTextoCumplimiento.Size = new System.Drawing.Size(101, 34);
            this.lblTextoCumplimiento.TabIndex = 2;
            this.lblTextoCumplimiento.Text = "Cumplimiento de sesiones";
            this.lblTextoCumplimiento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // picCumplimiento
            // 
            this.picCumplimiento.Location = new System.Drawing.Point(12, 20);
            this.picCumplimiento.Name = "picCumplimiento";
            this.picCumplimiento.Size = new System.Drawing.Size(55, 55);
            this.picCumplimiento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCumplimiento.TabIndex = 1;
            this.picCumplimiento.TabStop = false;
            // 
            // lblCumplimiento
            // 
            this.lblCumplimiento.AutoSize = true;
            this.lblCumplimiento.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCumplimiento.ForeColor = System.Drawing.Color.Navy;
            this.lblCumplimiento.Location = new System.Drawing.Point(80, 18);
            this.lblCumplimiento.Name = "lblCumplimiento";
            this.lblCumplimiento.Size = new System.Drawing.Size(45, 30);
            this.lblCumplimiento.TabIndex = 1;
            this.lblCumplimiento.Text = "0%";
            // 
            // pnlAlertasPendientes
            // 
            this.pnlAlertasPendientes.Controls.Add(this.lblTextoAlertas);
            this.pnlAlertasPendientes.Controls.Add(this.picAlertas);
            this.pnlAlertasPendientes.Controls.Add(this.lblTotalAlertas);
            this.pnlAlertasPendientes.Location = new System.Drawing.Point(640, 10);
            this.pnlAlertasPendientes.Margin = new System.Windows.Forms.Padding(5);
            this.pnlAlertasPendientes.Name = "pnlAlertasPendientes";
            this.pnlAlertasPendientes.Size = new System.Drawing.Size(200, 100);
            this.pnlAlertasPendientes.TabIndex = 3;
            // 
            // lblTextoAlertas
            // 
            this.lblTextoAlertas.AutoSize = true;
            this.lblTextoAlertas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoAlertas.ForeColor = System.Drawing.Color.Navy;
            this.lblTextoAlertas.Location = new System.Drawing.Point(80, 53);
            this.lblTextoAlertas.MaximumSize = new System.Drawing.Size(110, 0);
            this.lblTextoAlertas.Name = "lblTextoAlertas";
            this.lblTextoAlertas.Size = new System.Drawing.Size(79, 34);
            this.lblTextoAlertas.TabIndex = 2;
            this.lblTextoAlertas.Text = "Alertas pendientes";
            this.lblTextoAlertas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // picAlertas
            // 
            this.picAlertas.Location = new System.Drawing.Point(12, 20);
            this.picAlertas.Name = "picAlertas";
            this.picAlertas.Size = new System.Drawing.Size(55, 55);
            this.picAlertas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAlertas.TabIndex = 1;
            this.picAlertas.TabStop = false;
            // 
            // lblTotalAlertas
            // 
            this.lblTotalAlertas.AutoSize = true;
            this.lblTotalAlertas.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAlertas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTotalAlertas.Location = new System.Drawing.Point(80, 18);
            this.lblTotalAlertas.Name = "lblTotalAlertas";
            this.lblTotalAlertas.Size = new System.Drawing.Size(26, 30);
            this.lblTotalAlertas.TabIndex = 1;
            this.lblTotalAlertas.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvResumenSesiones);
            this.panel1.Controls.Add(this.lblTituloSsesiones);
            this.panel1.Location = new System.Drawing.Point(20, 340);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 250);
            this.panel1.TabIndex = 4;
            // 
            // lblTituloSsesiones
            // 
            this.lblTituloSsesiones.AutoSize = true;
            this.lblTituloSsesiones.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloSsesiones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(43)))), ((int)(((byte)(105)))));
            this.lblTituloSsesiones.Location = new System.Drawing.Point(15, 15);
            this.lblTituloSsesiones.Name = "lblTituloSsesiones";
            this.lblTituloSsesiones.Size = new System.Drawing.Size(173, 19);
            this.lblTituloSsesiones.TabIndex = 0;
            this.lblTituloSsesiones.Text = "Resumen de Sesiones";
            // 
            // dgvResumenSesiones
            // 
            this.dgvResumenSesiones.AllowUserToAddRows = false;
            this.dgvResumenSesiones.AllowUserToDeleteRows = false;
            this.dgvResumenSesiones.AllowUserToResizeColumns = false;
            this.dgvResumenSesiones.AllowUserToResizeRows = false;
            this.dgvResumenSesiones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResumenSesiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResumenSesiones.BackgroundColor = System.Drawing.Color.White;
            this.dgvResumenSesiones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResumenSesiones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResumenSesiones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResumenSesiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumenSesiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPeriodo,
            this.colProgramadas,
            this.colRealizadas,
            this.colPendientes,
            this.colCumplimiento});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResumenSesiones.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResumenSesiones.EnableHeadersVisualStyles = false;
            this.dgvResumenSesiones.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dgvResumenSesiones.Location = new System.Drawing.Point(15, 50);
            this.dgvResumenSesiones.Name = "dgvResumenSesiones";
            this.dgvResumenSesiones.ReadOnly = true;
            this.dgvResumenSesiones.RowHeadersVisible = false;
            this.dgvResumenSesiones.RowHeadersWidth = 32;
            this.dgvResumenSesiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResumenSesiones.Size = new System.Drawing.Size(500, 180);
            this.dgvResumenSesiones.TabIndex = 1;
            // 
            // colPeriodo
            // 
            this.colPeriodo.DataPropertyName = "Periodo";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colPeriodo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPeriodo.HeaderText = "Periodo";
            this.colPeriodo.Name = "colPeriodo";
            this.colPeriodo.ReadOnly = true;
            // 
            // colProgramadas
            // 
            this.colProgramadas.DataPropertyName = "Programadas";
            this.colProgramadas.HeaderText = "Programadas";
            this.colProgramadas.Name = "colProgramadas";
            this.colProgramadas.ReadOnly = true;
            // 
            // colRealizadas
            // 
            this.colRealizadas.DataPropertyName = "Realizadas";
            this.colRealizadas.HeaderText = "Realizadas";
            this.colRealizadas.Name = "colRealizadas";
            this.colRealizadas.ReadOnly = true;
            // 
            // colPendientes
            // 
            this.colPendientes.DataPropertyName = "Pendientes";
            this.colPendientes.HeaderText = "Pendientes";
            this.colPendientes.Name = "colPendientes";
            this.colPendientes.ReadOnly = true;
            // 
            // colCumplimiento
            // 
            this.colCumplimiento.DataPropertyName = "Cumplimiento";
            this.colCumplimiento.HeaderText = "Cumplimiento";
            this.colCumplimiento.Name = "colCumplimiento";
            this.colCumplimiento.ReadOnly = true;
            // 
            // frmResumenMonitoreoAdm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1218, 729);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpIndicadores);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmResumenMonitoreoAdm";
            this.Text = "Resumen de Monitoreo";
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picResumen)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.flpIndicadores.ResumeLayout(false);
            this.pnlEntrenadoresActivos.ResumeLayout(false);
            this.pnlEntrenadoresActivos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlDeportistasSeguimiento.ResumeLayout(false);
            this.pnlDeportistasSeguimiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDeportistas)).EndInit();
            this.pnlCumplimientoSesiones.ResumeLayout(false);
            this.pnlCumplimientoSesiones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCumplimiento)).EndInit();
            this.pnlAlertasPendientes.ResumeLayout(false);
            this.pnlAlertasPendientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumenSesiones)).EndInit();
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
        private System.Windows.Forms.Label lblTextoEntrenadores;
        private System.Windows.Forms.Panel pnlDeportistasSeguimiento;
        private System.Windows.Forms.Label lblTextoDeportistas;
        private System.Windows.Forms.PictureBox picDeportistas;
        private System.Windows.Forms.Label lblTotalDeportistas;
        private System.Windows.Forms.Panel pnlCumplimientoSesiones;
        private System.Windows.Forms.Label lblTextoCumplimiento;
        private System.Windows.Forms.PictureBox picCumplimiento;
        private System.Windows.Forms.Label lblCumplimiento;
        private System.Windows.Forms.Panel pnlAlertasPendientes;
        private System.Windows.Forms.Label lblTextoAlertas;
        private System.Windows.Forms.PictureBox picAlertas;
        private System.Windows.Forms.Label lblTotalAlertas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTituloSsesiones;
        private System.Windows.Forms.DataGridView dgvResumenSesiones;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProgramadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRealizadas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPendientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCumplimiento;
    }
}