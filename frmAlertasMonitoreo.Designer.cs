namespace wfZenova
{
    partial class frmAlertasMonitoreo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.pnlLinea = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picAlertas = new System.Windows.Forms.PictureBox();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.cmbEstadoAlerta = new System.Windows.Forms.ComboBox();
            this.lblEstadoAlerta = new System.Windows.Forms.Label();
            this.cmbPrioridad = new System.Windows.Forms.ComboBox();
            this.lblPrioridad = new System.Windows.Forms.Label();
            this.cmbTipoPersona = new System.Windows.Forms.ComboBox();
            this.lblTipoPersona = new System.Windows.Forms.Label();
            this.txtBuscarAlerta = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.pnlTarjetas = new System.Windows.Forms.Panel();
            this.pnlAlertasDeportistas = new System.Windows.Forms.Panel();
            this.lblTextoSinActividad = new System.Windows.Forms.Label();
            this.lblAlertasDeportistas = new System.Windows.Forms.Label();
            this.pnlColorSinActividad = new System.Windows.Forms.Label();
            this.picAlertasDeportistas = new System.Windows.Forms.PictureBox();
            this.pnlAlertasEntrenadores = new System.Windows.Forms.Panel();
            this.lblTextoPendientes = new System.Windows.Forms.Label();
            this.lblAlertasEntrenadores = new System.Windows.Forms.Label();
            this.pnlColorPendientes = new System.Windows.Forms.Label();
            this.picAlertasEntrenadores = new System.Windows.Forms.PictureBox();
            this.pnlTotalAlertas = new System.Windows.Forms.Panel();
            this.lblTextoTotal = new System.Windows.Forms.Label();
            this.lblTotalAlertas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picTotalAlertas = new System.Windows.Forms.PictureBox();
            this.pnlAlertasPendientes = new System.Windows.Forms.Panel();
            this.lblTextoDia = new System.Windows.Forms.Label();
            this.lblAlertasPendientes = new System.Windows.Forms.Label();
            this.pnlColorDia = new System.Windows.Forms.Label();
            this.picAlertasPendientes = new System.Windows.Forms.PictureBox();
            this.pnlListadoAlertas = new System.Windows.Forms.Panel();
            this.dgvAlertasMonitoreo = new System.Windows.Forms.DataGridView();
            this.colIdAlerta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPersona = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrioridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRevisar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblListadoAlertas = new System.Windows.Forms.Label();
            this.pnlEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertas)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.pnlTarjetas.SuspendLayout();
            this.pnlAlertasDeportistas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertasDeportistas)).BeginInit();
            this.pnlAlertasEntrenadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertasEntrenadores)).BeginInit();
            this.pnlTotalAlertas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTotalAlertas)).BeginInit();
            this.pnlAlertasPendientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertasPendientes)).BeginInit();
            this.pnlListadoAlertas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlertasMonitoreo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.Controls.Add(this.pnlLinea);
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Controls.Add(this.picAlertas);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(1254, 120);
            this.pnlEncabezado.TabIndex = 2;
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.pnlLinea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLinea.Location = new System.Drawing.Point(0, 119);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(1254, 1);
            this.pnlLinea.TabIndex = 3;
            this.pnlLinea.Text = "label1";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(63)))), ((int)(((byte)(105)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(137, 66);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(353, 17);
            this.lblSubtitulo.TabIndex = 2;
            this.lblSubtitulo.Text = "Revisa y atiende las alertas de entrenadores y deportistas.";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(107)))));
            this.lblTitulo.Location = new System.Drawing.Point(135, 27);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(216, 28);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Centro de Alertas";
            // 
            // picAlertas
            // 
            this.picAlertas.Image = global::wfZenova.Properties.Resources.icono_alertas;
            this.picAlertas.Location = new System.Drawing.Point(30, 15);
            this.picAlertas.Name = "picAlertas";
            this.picAlertas.Size = new System.Drawing.Size(85, 85);
            this.picAlertas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAlertas.TabIndex = 0;
            this.picAlertas.TabStop = false;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.pnlFiltros.Controls.Add(this.btnActualizar);
            this.pnlFiltros.Controls.Add(this.cmbEstadoAlerta);
            this.pnlFiltros.Controls.Add(this.lblEstadoAlerta);
            this.pnlFiltros.Controls.Add(this.cmbPrioridad);
            this.pnlFiltros.Controls.Add(this.lblPrioridad);
            this.pnlFiltros.Controls.Add(this.cmbTipoPersona);
            this.pnlFiltros.Controls.Add(this.lblTipoPersona);
            this.pnlFiltros.Controls.Add(this.txtBuscarAlerta);
            this.pnlFiltros.Controls.Add(this.lblBuscar);
            this.pnlFiltros.Location = new System.Drawing.Point(40, 135);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(1131, 85);
            this.pnlFiltros.TabIndex = 3;
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
            // cmbEstadoAlerta
            // 
            this.cmbEstadoAlerta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoAlerta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstadoAlerta.FormattingEnabled = true;
            this.cmbEstadoAlerta.Items.AddRange(new object[] {
            "Todas",
            "Pendiente",
            "En revisión",
            "Atendida"});
            this.cmbEstadoAlerta.Location = new System.Drawing.Point(725, 35);
            this.cmbEstadoAlerta.Name = "cmbEstadoAlerta";
            this.cmbEstadoAlerta.Size = new System.Drawing.Size(180, 25);
            this.cmbEstadoAlerta.TabIndex = 7;
            // 
            // lblEstadoAlerta
            // 
            this.lblEstadoAlerta.AutoSize = true;
            this.lblEstadoAlerta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(105)))));
            this.lblEstadoAlerta.Location = new System.Drawing.Point(725, 10);
            this.lblEstadoAlerta.Name = "lblEstadoAlerta";
            this.lblEstadoAlerta.Size = new System.Drawing.Size(54, 17);
            this.lblEstadoAlerta.TabIndex = 6;
            this.lblEstadoAlerta.Text = " Estado:";
            // 
            // cmbPrioridad
            // 
            this.cmbPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrioridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPrioridad.FormattingEnabled = true;
            this.cmbPrioridad.Items.AddRange(new object[] {
            "Todas",
            "Alta",
            "Media",
            "Baja"});
            this.cmbPrioridad.Location = new System.Drawing.Point(540, 35);
            this.cmbPrioridad.Name = "cmbPrioridad";
            this.cmbPrioridad.Size = new System.Drawing.Size(160, 25);
            this.cmbPrioridad.TabIndex = 5;
            // 
            // lblPrioridad
            // 
            this.lblPrioridad.AutoSize = true;
            this.lblPrioridad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(105)))));
            this.lblPrioridad.Location = new System.Drawing.Point(540, 10);
            this.lblPrioridad.Name = "lblPrioridad";
            this.lblPrioridad.Size = new System.Drawing.Size(67, 17);
            this.lblPrioridad.TabIndex = 4;
            this.lblPrioridad.Text = " Prioridad:";
            // 
            // cmbTipoPersona
            // 
            this.cmbTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPersona.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoPersona.FormattingEnabled = true;
            this.cmbTipoPersona.Items.AddRange(new object[] {
            "Todos",
            "Entrenador",
            "Deportista"});
            this.cmbTipoPersona.Location = new System.Drawing.Point(335, 35);
            this.cmbTipoPersona.Name = "cmbTipoPersona";
            this.cmbTipoPersona.Size = new System.Drawing.Size(180, 25);
            this.cmbTipoPersona.TabIndex = 3;
            // 
            // lblTipoPersona
            // 
            this.lblTipoPersona.AutoSize = true;
            this.lblTipoPersona.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(105)))));
            this.lblTipoPersona.Location = new System.Drawing.Point(335, 10);
            this.lblTipoPersona.Name = "lblTipoPersona";
            this.lblTipoPersona.Size = new System.Drawing.Size(35, 17);
            this.lblTipoPersona.TabIndex = 2;
            this.lblTipoPersona.Text = "Tipo:";
            // 
            // txtBuscarAlerta
            // 
            this.txtBuscarAlerta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscarAlerta.Location = new System.Drawing.Point(20, 35);
            this.txtBuscarAlerta.Name = "txtBuscarAlerta";
            this.txtBuscarAlerta.Size = new System.Drawing.Size(290, 22);
            this.txtBuscarAlerta.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(105)))));
            this.lblBuscar.Location = new System.Drawing.Point(20, 10);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(89, 17);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar alerta:";
            // 
            // pnlTarjetas
            // 
            this.pnlTarjetas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTarjetas.Controls.Add(this.pnlAlertasDeportistas);
            this.pnlTarjetas.Controls.Add(this.pnlAlertasEntrenadores);
            this.pnlTarjetas.Controls.Add(this.pnlTotalAlertas);
            this.pnlTarjetas.Controls.Add(this.pnlAlertasPendientes);
            this.pnlTarjetas.Location = new System.Drawing.Point(40, 235);
            this.pnlTarjetas.Name = "pnlTarjetas";
            this.pnlTarjetas.Size = new System.Drawing.Size(1149, 115);
            this.pnlTarjetas.TabIndex = 6;
            // 
            // pnlAlertasDeportistas
            // 
            this.pnlAlertasDeportistas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlertasDeportistas.Controls.Add(this.lblTextoSinActividad);
            this.pnlAlertasDeportistas.Controls.Add(this.lblAlertasDeportistas);
            this.pnlAlertasDeportistas.Controls.Add(this.pnlColorSinActividad);
            this.pnlAlertasDeportistas.Controls.Add(this.picAlertasDeportistas);
            this.pnlAlertasDeportistas.Location = new System.Drawing.Point(861, 5);
            this.pnlAlertasDeportistas.Name = "pnlAlertasDeportistas";
            this.pnlAlertasDeportistas.Size = new System.Drawing.Size(270, 100);
            this.pnlAlertasDeportistas.TabIndex = 6;
            // 
            // lblTextoSinActividad
            // 
            this.lblTextoSinActividad.AutoSize = true;
            this.lblTextoSinActividad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(150)))));
            this.lblTextoSinActividad.Location = new System.Drawing.Point(92, 52);
            this.lblTextoSinActividad.Name = "lblTextoSinActividad";
            this.lblTextoSinActividad.Size = new System.Drawing.Size(95, 17);
            this.lblTextoSinActividad.TabIndex = 5;
            this.lblTextoSinActividad.Text = "De deportistas";
            // 
            // lblAlertasDeportistas
            // 
            this.lblAlertasDeportistas.AutoSize = true;
            this.lblAlertasDeportistas.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertasDeportistas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(37)))), ((int)(((byte)(105)))));
            this.lblAlertasDeportistas.Location = new System.Drawing.Point(90, 17);
            this.lblAlertasDeportistas.Name = "lblAlertasDeportistas";
            this.lblAlertasDeportistas.Size = new System.Drawing.Size(24, 25);
            this.lblAlertasDeportistas.TabIndex = 4;
            this.lblAlertasDeportistas.Text = "0";
            // 
            // pnlColorSinActividad
            // 
            this.pnlColorSinActividad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(184)))), ((int)(((byte)(78)))));
            this.pnlColorSinActividad.Location = new System.Drawing.Point(0, 0);
            this.pnlColorSinActividad.Name = "pnlColorSinActividad";
            this.pnlColorSinActividad.Size = new System.Drawing.Size(6, 98);
            this.pnlColorSinActividad.TabIndex = 0;
            this.pnlColorSinActividad.Text = "label1";
            // 
            // picAlertasDeportistas
            // 
            this.picAlertasDeportistas.BackColor = System.Drawing.Color.Transparent;
            this.picAlertasDeportistas.Image = global::wfZenova.Properties.Resources.icono_deportistas;
            this.picAlertasDeportistas.Location = new System.Drawing.Point(18, 22);
            this.picAlertasDeportistas.Name = "picAlertasDeportistas";
            this.picAlertasDeportistas.Size = new System.Drawing.Size(55, 55);
            this.picAlertasDeportistas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAlertasDeportistas.TabIndex = 3;
            this.picAlertasDeportistas.TabStop = false;
            // 
            // pnlAlertasEntrenadores
            // 
            this.pnlAlertasEntrenadores.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlertasEntrenadores.Controls.Add(this.lblTextoPendientes);
            this.pnlAlertasEntrenadores.Controls.Add(this.lblAlertasEntrenadores);
            this.pnlAlertasEntrenadores.Controls.Add(this.pnlColorPendientes);
            this.pnlAlertasEntrenadores.Controls.Add(this.picAlertasEntrenadores);
            this.pnlAlertasEntrenadores.Location = new System.Drawing.Point(574, 5);
            this.pnlAlertasEntrenadores.Name = "pnlAlertasEntrenadores";
            this.pnlAlertasEntrenadores.Size = new System.Drawing.Size(270, 100);
            this.pnlAlertasEntrenadores.TabIndex = 6;
            // 
            // lblTextoPendientes
            // 
            this.lblTextoPendientes.AutoSize = true;
            this.lblTextoPendientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(150)))));
            this.lblTextoPendientes.Location = new System.Drawing.Point(90, 52);
            this.lblTextoPendientes.Name = "lblTextoPendientes";
            this.lblTextoPendientes.Size = new System.Drawing.Size(108, 17);
            this.lblTextoPendientes.TabIndex = 5;
            this.lblTextoPendientes.Text = "De entrenadores";
            // 
            // lblAlertasEntrenadores
            // 
            this.lblAlertasEntrenadores.AutoSize = true;
            this.lblAlertasEntrenadores.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertasEntrenadores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(107)))));
            this.lblAlertasEntrenadores.Location = new System.Drawing.Point(90, 17);
            this.lblAlertasEntrenadores.Name = "lblAlertasEntrenadores";
            this.lblAlertasEntrenadores.Size = new System.Drawing.Size(24, 25);
            this.lblAlertasEntrenadores.TabIndex = 4;
            this.lblAlertasEntrenadores.Text = "0";
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
            // picAlertasEntrenadores
            // 
            this.picAlertasEntrenadores.BackColor = System.Drawing.Color.Transparent;
            this.picAlertasEntrenadores.Image = global::wfZenova.Properties.Resources.icono_entrenadores;
            this.picAlertasEntrenadores.Location = new System.Drawing.Point(18, 22);
            this.picAlertasEntrenadores.Name = "picAlertasEntrenadores";
            this.picAlertasEntrenadores.Size = new System.Drawing.Size(55, 55);
            this.picAlertasEntrenadores.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAlertasEntrenadores.TabIndex = 3;
            this.picAlertasEntrenadores.TabStop = false;
            // 
            // pnlTotalAlertas
            // 
            this.pnlTotalAlertas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotalAlertas.Controls.Add(this.lblTextoTotal);
            this.pnlTotalAlertas.Controls.Add(this.lblTotalAlertas);
            this.pnlTotalAlertas.Controls.Add(this.label1);
            this.pnlTotalAlertas.Controls.Add(this.picTotalAlertas);
            this.pnlTotalAlertas.Location = new System.Drawing.Point(0, 5);
            this.pnlTotalAlertas.Name = "pnlTotalAlertas";
            this.pnlTotalAlertas.Size = new System.Drawing.Size(270, 100);
            this.pnlTotalAlertas.TabIndex = 0;
            // 
            // lblTextoTotal
            // 
            this.lblTextoTotal.AutoSize = true;
            this.lblTextoTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(150)))));
            this.lblTextoTotal.Location = new System.Drawing.Point(90, 52);
            this.lblTextoTotal.Name = "lblTextoTotal";
            this.lblTextoTotal.Size = new System.Drawing.Size(100, 17);
            this.lblTextoTotal.TabIndex = 5;
            this.lblTextoTotal.Text = "Total de alertas";
            // 
            // lblTotalAlertas
            // 
            this.lblTotalAlertas.AutoSize = true;
            this.lblTotalAlertas.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAlertas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(107)))));
            this.lblTotalAlertas.Location = new System.Drawing.Point(90, 17);
            this.lblTotalAlertas.Name = "lblTotalAlertas";
            this.lblTotalAlertas.Size = new System.Drawing.Size(24, 25);
            this.lblTotalAlertas.TabIndex = 4;
            this.lblTotalAlertas.Text = "0";
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
            // picTotalAlertas
            // 
            this.picTotalAlertas.BackColor = System.Drawing.Color.Transparent;
            this.picTotalAlertas.Image = global::wfZenova.Properties.Resources.icono_resumen;
            this.picTotalAlertas.Location = new System.Drawing.Point(18, 22);
            this.picTotalAlertas.Name = "picTotalAlertas";
            this.picTotalAlertas.Size = new System.Drawing.Size(55, 55);
            this.picTotalAlertas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTotalAlertas.TabIndex = 3;
            this.picTotalAlertas.TabStop = false;
            // 
            // pnlAlertasPendientes
            // 
            this.pnlAlertasPendientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAlertasPendientes.Controls.Add(this.lblTextoDia);
            this.pnlAlertasPendientes.Controls.Add(this.lblAlertasPendientes);
            this.pnlAlertasPendientes.Controls.Add(this.pnlColorDia);
            this.pnlAlertasPendientes.Controls.Add(this.picAlertasPendientes);
            this.pnlAlertasPendientes.Location = new System.Drawing.Point(285, 5);
            this.pnlAlertasPendientes.Name = "pnlAlertasPendientes";
            this.pnlAlertasPendientes.Size = new System.Drawing.Size(270, 100);
            this.pnlAlertasPendientes.TabIndex = 0;
            // 
            // lblTextoDia
            // 
            this.lblTextoDia.AutoSize = true;
            this.lblTextoDia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(150)))));
            this.lblTextoDia.Location = new System.Drawing.Point(90, 52);
            this.lblTextoDia.Name = "lblTextoDia";
            this.lblTextoDia.Size = new System.Drawing.Size(120, 17);
            this.lblTextoDia.TabIndex = 5;
            this.lblTextoDia.Text = "Alertas pendientes";
            // 
            // lblAlertasPendientes
            // 
            this.lblAlertasPendientes.AutoSize = true;
            this.lblAlertasPendientes.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlertasPendientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(37)))), ((int)(((byte)(42)))));
            this.lblAlertasPendientes.Location = new System.Drawing.Point(90, 17);
            this.lblAlertasPendientes.Name = "lblAlertasPendientes";
            this.lblAlertasPendientes.Size = new System.Drawing.Size(24, 25);
            this.lblAlertasPendientes.TabIndex = 4;
            this.lblAlertasPendientes.Text = "0";
            // 
            // pnlColorDia
            // 
            this.pnlColorDia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(37)))), ((int)(((byte)(42)))));
            this.pnlColorDia.Location = new System.Drawing.Point(0, 0);
            this.pnlColorDia.Name = "pnlColorDia";
            this.pnlColorDia.Size = new System.Drawing.Size(6, 98);
            this.pnlColorDia.TabIndex = 0;
            this.pnlColorDia.Text = "label1";
            // 
            // picAlertasPendientes
            // 
            this.picAlertasPendientes.BackColor = System.Drawing.Color.Transparent;
            this.picAlertasPendientes.Image = global::wfZenova.Properties.Resources.icono_alertas;
            this.picAlertasPendientes.Location = new System.Drawing.Point(18, 22);
            this.picAlertasPendientes.Name = "picAlertasPendientes";
            this.picAlertasPendientes.Size = new System.Drawing.Size(55, 55);
            this.picAlertasPendientes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAlertasPendientes.TabIndex = 3;
            this.picAlertasPendientes.TabStop = false;
            // 
            // pnlListadoAlertas
            // 
            this.pnlListadoAlertas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListadoAlertas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlListadoAlertas.Controls.Add(this.dgvAlertasMonitoreo);
            this.pnlListadoAlertas.Controls.Add(this.lblListadoAlertas);
            this.pnlListadoAlertas.Location = new System.Drawing.Point(40, 365);
            this.pnlListadoAlertas.Name = "pnlListadoAlertas";
            this.pnlListadoAlertas.Size = new System.Drawing.Size(1154, 350);
            this.pnlListadoAlertas.TabIndex = 7;
            // 
            // dgvAlertasMonitoreo
            // 
            this.dgvAlertasMonitoreo.AllowUserToAddRows = false;
            this.dgvAlertasMonitoreo.AllowUserToDeleteRows = false;
            this.dgvAlertasMonitoreo.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.dgvAlertasMonitoreo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAlertasMonitoreo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAlertasMonitoreo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlertasMonitoreo.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlertasMonitoreo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAlertasMonitoreo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(63)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlertasMonitoreo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAlertasMonitoreo.ColumnHeadersHeight = 40;
            this.dgvAlertasMonitoreo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAlertasMonitoreo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdAlerta,
            this.colTipp,
            this.colPersona,
            this.colMotivo,
            this.colFecha,
            this.colPrioridad,
            this.colEstado,
            this.colRevisar});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(107)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlertasMonitoreo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAlertasMonitoreo.EnableHeadersVisualStyles = false;
            this.dgvAlertasMonitoreo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.dgvAlertasMonitoreo.Location = new System.Drawing.Point(15, 55);
            this.dgvAlertasMonitoreo.MultiSelect = false;
            this.dgvAlertasMonitoreo.Name = "dgvAlertasMonitoreo";
            this.dgvAlertasMonitoreo.ReadOnly = true;
            this.dgvAlertasMonitoreo.RowHeadersVisible = false;
            this.dgvAlertasMonitoreo.RowTemplate.Height = 42;
            this.dgvAlertasMonitoreo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlertasMonitoreo.Size = new System.Drawing.Size(1122, 275);
            this.dgvAlertasMonitoreo.TabIndex = 1;
            // 
            // colIdAlerta
            // 
            this.colIdAlerta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colIdAlerta.DataPropertyName = "ID";
            this.colIdAlerta.HeaderText = "ID";
            this.colIdAlerta.Name = "colIdAlerta";
            this.colIdAlerta.ReadOnly = true;
            // 
            // colTipp
            // 
            this.colTipp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTipp.DataPropertyName = "Tipo";
            this.colTipp.HeaderText = "Tipo";
            this.colTipp.Name = "colTipp";
            this.colTipp.ReadOnly = true;
            // 
            // colPersona
            // 
            this.colPersona.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPersona.DataPropertyName = "Persona";
            this.colPersona.HeaderText = "Persona";
            this.colPersona.Name = "colPersona";
            this.colPersona.ReadOnly = true;
            // 
            // colMotivo
            // 
            this.colMotivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colMotivo.DataPropertyName = "Motivo";
            this.colMotivo.HeaderText = "Motivo";
            this.colMotivo.Name = "colMotivo";
            this.colMotivo.ReadOnly = true;
            // 
            // colFecha
            // 
            this.colFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colPrioridad
            // 
            this.colPrioridad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPrioridad.DataPropertyName = "Prioridad";
            this.colPrioridad.HeaderText = "Prioridad";
            this.colPrioridad.Name = "colPrioridad";
            this.colPrioridad.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEstado.DataPropertyName = "Estado";
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // colRevisar
            // 
            this.colRevisar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colRevisar.DataPropertyName = "Acción";
            this.colRevisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colRevisar.HeaderText = "Acción";
            this.colRevisar.Name = "colRevisar";
            this.colRevisar.ReadOnly = true;
            this.colRevisar.Text = "Revisar";
            this.colRevisar.UseColumnTextForButtonValue = true;
            this.colRevisar.Width = 85;
            // 
            // lblListadoAlertas
            // 
            this.lblListadoAlertas.AutoSize = true;
            this.lblListadoAlertas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListadoAlertas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(31)))), ((int)(((byte)(107)))));
            this.lblListadoAlertas.Location = new System.Drawing.Point(20, 15);
            this.lblListadoAlertas.Name = "lblListadoAlertas";
            this.lblListadoAlertas.Size = new System.Drawing.Size(143, 19);
            this.lblListadoAlertas.TabIndex = 0;
            this.lblListadoAlertas.Text = "Listado de Alertas";
            // 
            // frmAlertasMonitoreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1254, 749);
            this.Controls.Add(this.pnlListadoAlertas);
            this.Controls.Add(this.pnlTarjetas);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.pnlEncabezado);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAlertasMonitoreo";
            this.Text = "frmAlertasMonitoreo";
            this.Load += new System.EventHandler(this.frmAlertasMonitoreo_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertas)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlTarjetas.ResumeLayout(false);
            this.pnlAlertasDeportistas.ResumeLayout(false);
            this.pnlAlertasDeportistas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertasDeportistas)).EndInit();
            this.pnlAlertasEntrenadores.ResumeLayout(false);
            this.pnlAlertasEntrenadores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertasEntrenadores)).EndInit();
            this.pnlTotalAlertas.ResumeLayout(false);
            this.pnlTotalAlertas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTotalAlertas)).EndInit();
            this.pnlAlertasPendientes.ResumeLayout(false);
            this.pnlAlertasPendientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlertasPendientes)).EndInit();
            this.pnlListadoAlertas.ResumeLayout(false);
            this.pnlListadoAlertas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlertasMonitoreo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label pnlLinea;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picAlertas;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ComboBox cmbEstadoAlerta;
        private System.Windows.Forms.Label lblEstadoAlerta;
        private System.Windows.Forms.ComboBox cmbPrioridad;
        private System.Windows.Forms.Label lblPrioridad;
        private System.Windows.Forms.ComboBox cmbTipoPersona;
        private System.Windows.Forms.Label lblTipoPersona;
        private System.Windows.Forms.TextBox txtBuscarAlerta;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Panel pnlTarjetas;
        private System.Windows.Forms.Panel pnlAlertasDeportistas;
        private System.Windows.Forms.Label lblTextoSinActividad;
        private System.Windows.Forms.Label lblAlertasDeportistas;
        private System.Windows.Forms.Label pnlColorSinActividad;
        private System.Windows.Forms.PictureBox picAlertasDeportistas;
        private System.Windows.Forms.Panel pnlAlertasEntrenadores;
        private System.Windows.Forms.Label lblTextoPendientes;
        private System.Windows.Forms.Label lblAlertasEntrenadores;
        private System.Windows.Forms.Label pnlColorPendientes;
        private System.Windows.Forms.PictureBox picAlertasEntrenadores;
        private System.Windows.Forms.Panel pnlTotalAlertas;
        private System.Windows.Forms.Label lblTextoTotal;
        private System.Windows.Forms.Label lblTotalAlertas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picTotalAlertas;
        private System.Windows.Forms.Panel pnlAlertasPendientes;
        private System.Windows.Forms.Label lblTextoDia;
        private System.Windows.Forms.Label lblAlertasPendientes;
        private System.Windows.Forms.Label pnlColorDia;
        private System.Windows.Forms.PictureBox picAlertasPendientes;
        private System.Windows.Forms.Panel pnlListadoAlertas;
        private System.Windows.Forms.DataGridView dgvAlertasMonitoreo;
        private System.Windows.Forms.Label lblListadoAlertas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdAlerta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrioridad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewButtonColumn colRevisar;
    }
}