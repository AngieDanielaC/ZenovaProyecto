namespace wfZenova
{
    partial class frmMonitoreoDeportistas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.pnlLinea = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.cmbSeguimiento = new System.Windows.Forms.ComboBox();
            this.lblSeguimiento = new System.Windows.Forms.Label();
            this.cmbEntrenador = new System.Windows.Forms.ComboBox();
            this.lblEntrenador = new System.Windows.Forms.Label();
            this.cmbDeporte = new System.Windows.Forms.ComboBox();
            this.lblDeporte = new System.Windows.Forms.Label();
            this.txtBuscarDeportista = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.pnlTarjetas = new System.Windows.Forms.Panel();
            this.pnlSinRegistro = new System.Windows.Forms.Panel();
            this.lblTextoSinActividad = new System.Windows.Forms.Label();
            this.lblSinRegistro = new System.Windows.Forms.Label();
            this.pnlColorSinActividad = new System.Windows.Forms.Label();
            this.pnlDeportistasRevisar = new System.Windows.Forms.Panel();
            this.lblTextoPendientes = new System.Windows.Forms.Label();
            this.lblDeportistasRevisar = new System.Windows.Forms.Label();
            this.pnlColorPendientes = new System.Windows.Forms.Label();
            this.pnlTotalDeportistas = new System.Windows.Forms.Panel();
            this.lblTextoTotal = new System.Windows.Forms.Label();
            this.lblTotalDeportistas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDeportistasDia = new System.Windows.Forms.Panel();
            this.lblTextoDia = new System.Windows.Forms.Label();
            this.lblDeportistasDia = new System.Windows.Forms.Label();
            this.pnlColorDia = new System.Windows.Forms.Label();
            this.pnlDetalleDeportistas = new System.Windows.Forms.Panel();
            this.dgvDeportistasMonitoreo = new System.Windows.Forms.DataGridView();
            this.lblDetalleDeportistas = new System.Windows.Forms.Label();
            this.colIdDeportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeportista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEdad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntrenador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAsistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUltimaMedicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeguimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVerDetalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.picSinRegistro = new System.Windows.Forms.PictureBox();
            this.picDeportistasRevisar = new System.Windows.Forms.PictureBox();
            this.picTotalDeportistas = new System.Windows.Forms.PictureBox();
            this.picDeportistasDia = new System.Windows.Forms.PictureBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.picDeportistas = new System.Windows.Forms.PictureBox();
            this.pnlEncabezado.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlTarjetas.SuspendLayout();
            this.pnlSinRegistro.SuspendLayout();
            this.pnlDeportistasRevisar.SuspendLayout();
            this.pnlTotalDeportistas.SuspendLayout();
            this.pnlDeportistasDia.SuspendLayout();
            this.pnlDetalleDeportistas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeportistasMonitoreo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSinRegistro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDeportistasRevisar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTotalDeportistas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDeportistasDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDeportistas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.Controls.Add(this.pnlLinea);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.picDeportistas);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1234, 120);
            this.pnlEncabezado.TabIndex = 1;
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.pnlLinea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLinea.Location = new System.Drawing.Point(0, 119);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(1234, 1);
            this.pnlLinea.TabIndex = 3;
            this.pnlLinea.Text = "label1";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(63)))), ((int)(((byte)(105)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(137, 66);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(363, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Supervisa el seguimiento y la actividad de cada deportista.";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(107)))));
            this.lblTitulo.Location = new System.Drawing.Point(135, 27);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(303, 28);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Monitoreo de Deportistas\r\n";
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.pnlFiltros.Controls.Add(this.btnActualizar);
            this.pnlFiltros.Controls.Add(this.cmbSeguimiento);
            this.pnlFiltros.Controls.Add(this.lblSeguimiento);
            this.pnlFiltros.Controls.Add(this.cmbEntrenador);
            this.pnlFiltros.Controls.Add(this.lblEntrenador);
            this.pnlFiltros.Controls.Add(this.cmbDeporte);
            this.pnlFiltros.Controls.Add(this.lblDeporte);
            this.pnlFiltros.Controls.Add(this.txtBuscarDeportista);
            this.pnlFiltros.Controls.Add(this.lblBuscar);
            this.pnlFiltros.Location = new System.Drawing.Point(3, 126);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1154, 85);
            this.pnlFiltros.TabIndex = 2;
            // 
            // cmbSeguimiento
            // 
            this.cmbSeguimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeguimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSeguimiento.FormattingEnabled = true;
            this.cmbSeguimiento.Items.AddRange(new object[] {
            "Todos",
            "Al día",
            "Por revisar",
            "Sin registro reciente"});
            this.cmbSeguimiento.Location = new System.Drawing.Point(725, 35);
            this.cmbSeguimiento.Name = "cmbSeguimiento";
            this.cmbSeguimiento.Size = new System.Drawing.Size(180, 25);
            this.cmbSeguimiento.TabIndex = 7;
            // 
            // lblSeguimiento
            // 
            this.lblSeguimiento.AutoSize = true;
            this.lblSeguimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(105)))));
            this.lblSeguimiento.Location = new System.Drawing.Point(725, 10);
            this.lblSeguimiento.Name = "lblSeguimiento";
            this.lblSeguimiento.Size = new System.Drawing.Size(89, 17);
            this.lblSeguimiento.TabIndex = 6;
            this.lblSeguimiento.Text = "Seguimiento: ";
            // 
            // cmbEntrenador
            // 
            this.cmbEntrenador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEntrenador.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEntrenador.FormattingEnabled = true;
            this.cmbEntrenador.Items.AddRange(new object[] {
            "Todos"});
            this.cmbEntrenador.Location = new System.Drawing.Point(540, 35);
            this.cmbEntrenador.Name = "cmbEntrenador";
            this.cmbEntrenador.Size = new System.Drawing.Size(160, 25);
            this.cmbEntrenador.TabIndex = 5;
            // 
            // lblEntrenador
            // 
            this.lblEntrenador.AutoSize = true;
            this.lblEntrenador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(105)))));
            this.lblEntrenador.Location = new System.Drawing.Point(540, 10);
            this.lblEntrenador.Name = "lblEntrenador";
            this.lblEntrenador.Size = new System.Drawing.Size(73, 17);
            this.lblEntrenador.TabIndex = 4;
            this.lblEntrenador.Text = "Entrenador";
            // 
            // cmbDeporte
            // 
            this.cmbDeporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDeporte.FormattingEnabled = true;
            this.cmbDeporte.Items.AddRange(new object[] {
            "Todos"});
            this.cmbDeporte.Location = new System.Drawing.Point(335, 35);
            this.cmbDeporte.Name = "cmbDeporte";
            this.cmbDeporte.Size = new System.Drawing.Size(180, 25);
            this.cmbDeporte.TabIndex = 3;
            // 
            // lblDeporte
            // 
            this.lblDeporte.AutoSize = true;
            this.lblDeporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(105)))));
            this.lblDeporte.Location = new System.Drawing.Point(335, 10);
            this.lblDeporte.Name = "lblDeporte";
            this.lblDeporte.Size = new System.Drawing.Size(61, 17);
            this.lblDeporte.TabIndex = 2;
            this.lblDeporte.Text = "Deporte:";
            // 
            // txtBuscarDeportista
            // 
            this.txtBuscarDeportista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarDeportista.Location = new System.Drawing.Point(20, 35);
            this.txtBuscarDeportista.Name = "txtBuscarDeportista";
            this.txtBuscarDeportista.Size = new System.Drawing.Size(290, 22);
            this.txtBuscarDeportista.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(105)))));
            this.lblBuscar.Location = new System.Drawing.Point(20, 10);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(115, 17);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar deportista:";
            // 
            // pnlTarjetas
            // 
            this.pnlTarjetas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTarjetas.Controls.Add(this.pnlSinRegistro);
            this.pnlTarjetas.Controls.Add(this.pnlDeportistasRevisar);
            this.pnlTarjetas.Controls.Add(this.pnlTotalDeportistas);
            this.pnlTarjetas.Controls.Add(this.pnlDeportistasDia);
            this.pnlTarjetas.Location = new System.Drawing.Point(40, 235);
            this.pnlTarjetas.Name = "pnlTarjetas";
            this.pnlTarjetas.Size = new System.Drawing.Size(1142, 115);
            this.pnlTarjetas.TabIndex = 3;
            // 
            // pnlSinRegistro
            // 
            this.pnlSinRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSinRegistro.Controls.Add(this.lblTextoSinActividad);
            this.pnlSinRegistro.Controls.Add(this.lblSinRegistro);
            this.pnlSinRegistro.Controls.Add(this.pnlColorSinActividad);
            this.pnlSinRegistro.Controls.Add(this.picSinRegistro);
            this.pnlSinRegistro.Location = new System.Drawing.Point(861, 5);
            this.pnlSinRegistro.Name = "pnlSinRegistro";
            this.pnlSinRegistro.Size = new System.Drawing.Size(270, 100);
            this.pnlSinRegistro.TabIndex = 6;
            // 
            // lblTextoSinActividad
            // 
            this.lblTextoSinActividad.AutoSize = true;
            this.lblTextoSinActividad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(150)))));
            this.lblTextoSinActividad.Location = new System.Drawing.Point(92, 52);
            this.lblTextoSinActividad.Name = "lblTextoSinActividad";
            this.lblTextoSinActividad.Size = new System.Drawing.Size(127, 17);
            this.lblTextoSinActividad.TabIndex = 5;
            this.lblTextoSinActividad.Text = "Sin registro reciente";
            // 
            // lblSinRegistro
            // 
            this.lblSinRegistro.AutoSize = true;
            this.lblSinRegistro.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinRegistro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(37)))), ((int)(((byte)(42)))));
            this.lblSinRegistro.Location = new System.Drawing.Point(90, 17);
            this.lblSinRegistro.Name = "lblSinRegistro";
            this.lblSinRegistro.Size = new System.Drawing.Size(24, 25);
            this.lblSinRegistro.TabIndex = 4;
            this.lblSinRegistro.Text = "0";
            // 
            // pnlColorSinActividad
            // 
            this.pnlColorSinActividad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(37)))), ((int)(((byte)(42)))));
            this.pnlColorSinActividad.Location = new System.Drawing.Point(0, 0);
            this.pnlColorSinActividad.Name = "pnlColorSinActividad";
            this.pnlColorSinActividad.Size = new System.Drawing.Size(6, 98);
            this.pnlColorSinActividad.TabIndex = 0;
            this.pnlColorSinActividad.Text = "label1";
            // 
            // pnlDeportistasRevisar
            // 
            this.pnlDeportistasRevisar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDeportistasRevisar.Controls.Add(this.lblTextoPendientes);
            this.pnlDeportistasRevisar.Controls.Add(this.lblDeportistasRevisar);
            this.pnlDeportistasRevisar.Controls.Add(this.pnlColorPendientes);
            this.pnlDeportistasRevisar.Controls.Add(this.picDeportistasRevisar);
            this.pnlDeportistasRevisar.Location = new System.Drawing.Point(574, 5);
            this.pnlDeportistasRevisar.Name = "pnlDeportistasRevisar";
            this.pnlDeportistasRevisar.Size = new System.Drawing.Size(270, 100);
            this.pnlDeportistasRevisar.TabIndex = 6;
            // 
            // lblTextoPendientes
            // 
            this.lblTextoPendientes.AutoSize = true;
            this.lblTextoPendientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(150)))));
            this.lblTextoPendientes.Location = new System.Drawing.Point(90, 52);
            this.lblTextoPendientes.Name = "lblTextoPendientes";
            this.lblTextoPendientes.Size = new System.Drawing.Size(142, 17);
            this.lblTextoPendientes.TabIndex = 5;
            this.lblTextoPendientes.Text = "Deportistas por revisar";
            // 
            // lblDeportistasRevisar
            // 
            this.lblDeportistasRevisar.AutoSize = true;
            this.lblDeportistasRevisar.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeportistasRevisar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(107)))));
            this.lblDeportistasRevisar.Location = new System.Drawing.Point(90, 17);
            this.lblDeportistasRevisar.Name = "lblDeportistasRevisar";
            this.lblDeportistasRevisar.Size = new System.Drawing.Size(24, 25);
            this.lblDeportistasRevisar.TabIndex = 4;
            this.lblDeportistasRevisar.Text = "0";
            // 
            // pnlColorPendientes
            // 
            this.pnlColorPendientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.pnlColorPendientes.Location = new System.Drawing.Point(0, 0);
            this.pnlColorPendientes.Name = "pnlColorPendientes";
            this.pnlColorPendientes.Size = new System.Drawing.Size(6, 98);
            this.pnlColorPendientes.TabIndex = 0;
            this.pnlColorPendientes.Text = "label1";
            // 
            // pnlTotalDeportistas
            // 
            this.pnlTotalDeportistas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotalDeportistas.Controls.Add(this.lblTextoTotal);
            this.pnlTotalDeportistas.Controls.Add(this.lblTotalDeportistas);
            this.pnlTotalDeportistas.Controls.Add(this.label1);
            this.pnlTotalDeportistas.Controls.Add(this.picTotalDeportistas);
            this.pnlTotalDeportistas.Location = new System.Drawing.Point(0, 5);
            this.pnlTotalDeportistas.Name = "pnlTotalDeportistas";
            this.pnlTotalDeportistas.Size = new System.Drawing.Size(270, 100);
            this.pnlTotalDeportistas.TabIndex = 0;
            // 
            // lblTextoTotal
            // 
            this.lblTextoTotal.AutoSize = true;
            this.lblTextoTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(150)))));
            this.lblTextoTotal.Location = new System.Drawing.Point(90, 52);
            this.lblTextoTotal.Name = "lblTextoTotal";
            this.lblTextoTotal.Size = new System.Drawing.Size(126, 17);
            this.lblTextoTotal.TabIndex = 5;
            this.lblTextoTotal.Text = "Total de deportistas";
            // 
            // lblTotalDeportistas
            // 
            this.lblTotalDeportistas.AutoSize = true;
            this.lblTotalDeportistas.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDeportistas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(107)))));
            this.lblTotalDeportistas.Location = new System.Drawing.Point(90, 17);
            this.lblTotalDeportistas.Name = "lblTotalDeportistas";
            this.lblTotalDeportistas.Size = new System.Drawing.Size(24, 25);
            this.lblTotalDeportistas.TabIndex = 4;
            this.lblTotalDeportistas.Text = "0";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(225)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(6, 98);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // pnlDeportistasDia
            // 
            this.pnlDeportistasDia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDeportistasDia.Controls.Add(this.lblTextoDia);
            this.pnlDeportistasDia.Controls.Add(this.lblDeportistasDia);
            this.pnlDeportistasDia.Controls.Add(this.pnlColorDia);
            this.pnlDeportistasDia.Controls.Add(this.picDeportistasDia);
            this.pnlDeportistasDia.Location = new System.Drawing.Point(285, 5);
            this.pnlDeportistasDia.Name = "pnlDeportistasDia";
            this.pnlDeportistasDia.Size = new System.Drawing.Size(270, 100);
            this.pnlDeportistasDia.TabIndex = 0;
            // 
            // lblTextoDia
            // 
            this.lblTextoDia.AutoSize = true;
            this.lblTextoDia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(150)))));
            this.lblTextoDia.Location = new System.Drawing.Point(90, 52);
            this.lblTextoDia.Name = "lblTextoDia";
            this.lblTextoDia.Size = new System.Drawing.Size(112, 17);
            this.lblTextoDia.TabIndex = 5;
            this.lblTextoDia.Text = "Deportistas al día";
            // 
            // lblDeportistasDia
            // 
            this.lblDeportistasDia.AutoSize = true;
            this.lblDeportistasDia.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeportistasDia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(107)))));
            this.lblDeportistasDia.Location = new System.Drawing.Point(90, 17);
            this.lblDeportistasDia.Name = "lblDeportistasDia";
            this.lblDeportistasDia.Size = new System.Drawing.Size(24, 25);
            this.lblDeportistasDia.TabIndex = 4;
            this.lblDeportistasDia.Text = "0";
            // 
            // pnlColorDia
            // 
            this.pnlColorDia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(184)))), ((int)(((byte)(78)))));
            this.pnlColorDia.Location = new System.Drawing.Point(0, 0);
            this.pnlColorDia.Name = "pnlColorDia";
            this.pnlColorDia.Size = new System.Drawing.Size(6, 98);
            this.pnlColorDia.TabIndex = 0;
            this.pnlColorDia.Text = "label1";
            // 
            // pnlDetalleDeportistas
            // 
            this.pnlDetalleDeportistas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalleDeportistas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalleDeportistas.Controls.Add(this.dgvDeportistasMonitoreo);
            this.pnlDetalleDeportistas.Controls.Add(this.lblDetalleDeportistas);
            this.pnlDetalleDeportistas.Location = new System.Drawing.Point(40, 365);
            this.pnlDetalleDeportistas.Name = "pnlDetalleDeportistas";
            this.pnlDetalleDeportistas.Size = new System.Drawing.Size(1142, 350);
            this.pnlDetalleDeportistas.TabIndex = 4;
            // 
            // dgvDeportistasMonitoreo
            // 
            this.dgvDeportistasMonitoreo.AllowUserToAddRows = false;
            this.dgvDeportistasMonitoreo.AllowUserToDeleteRows = false;
            this.dgvDeportistasMonitoreo.AllowUserToResizeColumns = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.dgvDeportistasMonitoreo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDeportistasMonitoreo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeportistasMonitoreo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeportistasMonitoreo.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeportistasMonitoreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeportistasMonitoreo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeportistasMonitoreo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDeportistasMonitoreo.ColumnHeadersHeight = 40;
            this.dgvDeportistasMonitoreo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDeportistasMonitoreo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdDeportista,
            this.colDeportista,
            this.colEdad,
            this.colDeporte,
            this.colEntrenador,
            this.colEstado,
            this.colAsistencia,
            this.colUltimaMedicion,
            this.colSeguimiento,
            this.colVerDetalle});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeportistasMonitoreo.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDeportistasMonitoreo.EnableHeadersVisualStyles = false;
            this.dgvDeportistasMonitoreo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dgvDeportistasMonitoreo.Location = new System.Drawing.Point(15, 55);
            this.dgvDeportistasMonitoreo.MultiSelect = false;
            this.dgvDeportistasMonitoreo.Name = "dgvDeportistasMonitoreo";
            this.dgvDeportistasMonitoreo.ReadOnly = true;
            this.dgvDeportistasMonitoreo.RowHeadersVisible = false;
            this.dgvDeportistasMonitoreo.RowTemplate.Height = 42;
            this.dgvDeportistasMonitoreo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeportistasMonitoreo.Size = new System.Drawing.Size(1110, 275);
            this.dgvDeportistasMonitoreo.TabIndex = 1;
            // 
            // lblDetalleDeportistas
            // 
            this.lblDetalleDeportistas.AutoSize = true;
            this.lblDetalleDeportistas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleDeportistas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(107)))));
            this.lblDetalleDeportistas.Location = new System.Drawing.Point(20, 15);
            this.lblDetalleDeportistas.Name = "lblDetalleDeportistas";
            this.lblDetalleDeportistas.Size = new System.Drawing.Size(217, 19);
            this.lblDetalleDeportistas.TabIndex = 0;
            this.lblDetalleDeportistas.Text = "Seguimiento de Deportistas";
            // 
            // colIdDeportista
            // 
            this.colIdDeportista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colIdDeportista.DataPropertyName = "ID";
            this.colIdDeportista.HeaderText = "ID";
            this.colIdDeportista.Name = "colIdDeportista";
            this.colIdDeportista.ReadOnly = true;
            // 
            // colDeportista
            // 
            this.colDeportista.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDeportista.DataPropertyName = "Deportista";
            this.colDeportista.HeaderText = "Deportista";
            this.colDeportista.Name = "colDeportista";
            this.colDeportista.ReadOnly = true;
            // 
            // colEdad
            // 
            this.colEdad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEdad.DataPropertyName = "Edad";
            this.colEdad.HeaderText = "Edad";
            this.colEdad.Name = "colEdad";
            this.colEdad.ReadOnly = true;
            // 
            // colDeporte
            // 
            this.colDeporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDeporte.DataPropertyName = "Deporte";
            this.colDeporte.HeaderText = "Deporte";
            this.colDeporte.Name = "colDeporte";
            this.colDeporte.ReadOnly = true;
            // 
            // colEntrenador
            // 
            this.colEntrenador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEntrenador.DataPropertyName = "Entrenador";
            this.colEntrenador.HeaderText = "Entrenador";
            this.colEntrenador.Name = "colEntrenador";
            this.colEntrenador.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEstado.DataPropertyName = "Estado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // colAsistencia
            // 
            this.colAsistencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAsistencia.DataPropertyName = "Asistencia";
            this.colAsistencia.HeaderText = "Asistencia";
            this.colAsistencia.Name = "colAsistencia";
            this.colAsistencia.ReadOnly = true;
            // 
            // colUltimaMedicion
            // 
            this.colUltimaMedicion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colUltimaMedicion.DataPropertyName = "Último Detalle";
            this.colUltimaMedicion.HeaderText = "Última Medición";
            this.colUltimaMedicion.Name = "colUltimaMedicion";
            this.colUltimaMedicion.ReadOnly = true;
            // 
            // colSeguimiento
            // 
            this.colSeguimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSeguimiento.DataPropertyName = "Seguimiento";
            this.colSeguimiento.HeaderText = "Seguimiento";
            this.colSeguimiento.Name = "colSeguimiento";
            this.colSeguimiento.ReadOnly = true;
            // 
            // colVerDetalle
            // 
            this.colVerDetalle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colVerDetalle.DataPropertyName = "Ver Detalle";
            this.colVerDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colVerDetalle.HeaderText = "Ver Detalle";
            this.colVerDetalle.Name = "colVerDetalle";
            this.colVerDetalle.ReadOnly = true;
            this.colVerDetalle.Text = "Ver";
            this.colVerDetalle.UseColumnTextForButtonValue = true;
            this.colVerDetalle.Width = 80;
            // 
            // picSinRegistro
            // 
            this.picSinRegistro.BackColor = System.Drawing.Color.Transparent;
            this.picSinRegistro.Image = global::wfZenova.Properties.Resources.icono_sin_actividad;
            this.picSinRegistro.Location = new System.Drawing.Point(18, 22);
            this.picSinRegistro.Name = "picSinRegistro";
            this.picSinRegistro.Size = new System.Drawing.Size(55, 55);
            this.picSinRegistro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSinRegistro.TabIndex = 3;
            this.picSinRegistro.TabStop = false;
            // 
            // picDeportistasRevisar
            // 
            this.picDeportistasRevisar.BackColor = System.Drawing.Color.Transparent;
            this.picDeportistasRevisar.Image = global::wfZenova.Properties.Resources.icono_alertas;
            this.picDeportistasRevisar.Location = new System.Drawing.Point(18, 22);
            this.picDeportistasRevisar.Name = "picDeportistasRevisar";
            this.picDeportistasRevisar.Size = new System.Drawing.Size(55, 55);
            this.picDeportistasRevisar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDeportistasRevisar.TabIndex = 3;
            this.picDeportistasRevisar.TabStop = false;
            // 
            // picTotalDeportistas
            // 
            this.picTotalDeportistas.BackColor = System.Drawing.Color.Transparent;
            this.picTotalDeportistas.Image = global::wfZenova.Properties.Resources.icono_entrenadores;
            this.picTotalDeportistas.Location = new System.Drawing.Point(18, 22);
            this.picTotalDeportistas.Name = "picTotalDeportistas";
            this.picTotalDeportistas.Size = new System.Drawing.Size(55, 55);
            this.picTotalDeportistas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTotalDeportistas.TabIndex = 3;
            this.picTotalDeportistas.TabStop = false;
            // 
            // picDeportistasDia
            // 
            this.picDeportistasDia.BackColor = System.Drawing.Color.Transparent;
            this.picDeportistasDia.Image = global::wfZenova.Properties.Resources.icono_cumplimiento;
            this.picDeportistasDia.Location = new System.Drawing.Point(18, 22);
            this.picDeportistasDia.Name = "picDeportistasDia";
            this.picDeportistasDia.Size = new System.Drawing.Size(55, 55);
            this.picDeportistasDia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDeportistasDia.TabIndex = 3;
            this.picDeportistasDia.TabStop = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(221)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = global::wfZenova.Properties.Resources.converted_image__1_;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(970, 19);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Padding = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.btnActualizar.Size = new System.Drawing.Size(118, 53);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = false;
            // 
            // picDeportistas
            // 
            this.picDeportistas.Image = global::wfZenova.Properties.Resources.icono_deportistas;
            this.picDeportistas.Location = new System.Drawing.Point(30, 15);
            this.picDeportistas.Name = "picDeportistas";
            this.picDeportistas.Size = new System.Drawing.Size(85, 85);
            this.picDeportistas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDeportistas.TabIndex = 0;
            this.picDeportistas.TabStop = false;
            // 
            // frmMonitoreoDeportistas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1234, 768);
            this.Controls.Add(this.pnlDetalleDeportistas);
            this.Controls.Add(this.pnlTarjetas);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMonitoreoDeportistas";
            this.Text = "frmMonitoreoDeportistas";
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlTarjetas.ResumeLayout(false);
            this.pnlSinRegistro.ResumeLayout(false);
            this.pnlSinRegistro.PerformLayout();
            this.pnlDeportistasRevisar.ResumeLayout(false);
            this.pnlDeportistasRevisar.PerformLayout();
            this.pnlTotalDeportistas.ResumeLayout(false);
            this.pnlTotalDeportistas.PerformLayout();
            this.pnlDeportistasDia.ResumeLayout(false);
            this.pnlDeportistasDia.PerformLayout();
            this.pnlDetalleDeportistas.ResumeLayout(false);
            this.pnlDetalleDeportistas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeportistasMonitoreo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSinRegistro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDeportistasRevisar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTotalDeportistas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDeportistasDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDeportistas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label pnlLinea;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picDeportistas;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ComboBox cmbSeguimiento;
        private System.Windows.Forms.Label lblSeguimiento;
        private System.Windows.Forms.ComboBox cmbEntrenador;
        private System.Windows.Forms.Label lblEntrenador;
        private System.Windows.Forms.ComboBox cmbDeporte;
        private System.Windows.Forms.Label lblDeporte;
        private System.Windows.Forms.TextBox txtBuscarDeportista;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Panel pnlTarjetas;
        private System.Windows.Forms.Panel pnlSinRegistro;
        private System.Windows.Forms.Label lblTextoSinActividad;
        private System.Windows.Forms.Label lblSinRegistro;
        private System.Windows.Forms.Label pnlColorSinActividad;
        private System.Windows.Forms.PictureBox picSinRegistro;
        private System.Windows.Forms.Panel pnlDeportistasRevisar;
        private System.Windows.Forms.Label lblTextoPendientes;
        private System.Windows.Forms.Label lblDeportistasRevisar;
        private System.Windows.Forms.Label pnlColorPendientes;
        private System.Windows.Forms.PictureBox picDeportistasRevisar;
        private System.Windows.Forms.Panel pnlTotalDeportistas;
        private System.Windows.Forms.Label lblTextoTotal;
        private System.Windows.Forms.Label lblTotalDeportistas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picTotalDeportistas;
        private System.Windows.Forms.Panel pnlDeportistasDia;
        private System.Windows.Forms.Label lblTextoDia;
        private System.Windows.Forms.Label lblDeportistasDia;
        private System.Windows.Forms.Label pnlColorDia;
        private System.Windows.Forms.PictureBox picDeportistasDia;
        private System.Windows.Forms.Panel pnlDetalleDeportistas;
        private System.Windows.Forms.DataGridView dgvDeportistasMonitoreo;
        private System.Windows.Forms.Label lblDetalleDeportistas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdDeportista;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeportista;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEdad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntrenador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAsistencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUltimaMedicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeguimiento;
        private System.Windows.Forms.DataGridViewButtonColumn colVerDetalle;
    }
}