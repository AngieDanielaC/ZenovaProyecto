using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmCronogramaEntrenador : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        private int idEntrenador;
        public frmCronogramaEntrenador(int idEntrenador)
        {
            InitializeComponent();

            this.idEntrenador = idEntrenador;
        }
        public frmCronogramaEntrenador()
        {
            InitializeComponent();
        }
        private void frmCronogramaEntrenador_Load(object sender, EventArgs e)
        {
            //Mostrar fecha actual
            lblFecha.Text = DateTime.Now.ToString(
             "dd 'de' MMMM 'de' yyyy");

            //Configurar tablas
            ConfigurarTablaAsignaciones();
            ConfigurarTablaProximas();

            //Actualizar actividades vencidas
            ActualizarEstadosVencidos();

            //Cargar datos
            CargarProximasActividades();
            CargarCronograma();
        }
        private void ConfigurarTablaAsignaciones()
        {
            dgvAsignaciones.AutoGenerateColumns = false;

            dgvAsignaciones.Columns.Clear();

            // ID oculto
            dgvAsignaciones.Columns.Add("IdCronograma", "ID");
            dgvAsignaciones.Columns["IdCronograma"].Visible = false;

            // Columnas visibles            
            dgvAsignaciones.Columns.Add("Fecha", "FECHA");
            dgvAsignaciones.Columns.Add("Hora", "HORA");
            dgvAsignaciones.Columns.Add("Actividad", "ACTIVIDAD");
            dgvAsignaciones.Columns.Add("Tipo", "TIPO");
            dgvAsignaciones.Columns.Add("Lugar", "LUGAR");
            dgvAsignaciones.Columns.Add("Estado", "ESTADO");

            // CONECTAR CON LOS CAMPOS DE SQL
            dgvAsignaciones.Columns["IdCronograma"].DataPropertyName = "IdCronograma";
            dgvAsignaciones.Columns["Fecha"].DataPropertyName = "Fecha";
            dgvAsignaciones.Columns["Hora"].DataPropertyName = "Hora";
            dgvAsignaciones.Columns["Actividad"].DataPropertyName = "Actividad";
            dgvAsignaciones.Columns["Tipo"].DataPropertyName = "Tipo";
            dgvAsignaciones.Columns["Lugar"].DataPropertyName = "Lugar";
            dgvAsignaciones.Columns["Estado"].DataPropertyName = "Estado";

            dgvAsignaciones.Columns["IdCronograma"].Visible = false;

            // ESTILO GENERAL
            dgvAsignaciones.BackgroundColor = Color.White;
            dgvAsignaciones.BorderStyle = BorderStyle.None;

            dgvAsignaciones.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvAsignaciones.GridColor =
                Color.FromArgb(235, 235, 235);

            dgvAsignaciones.RowHeadersVisible = false;

            dgvAsignaciones.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAsignaciones.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvAsignaciones.RowTemplate.Height = 50;

            // ENCABEZADO
            dgvAsignaciones.EnableHeadersVisualStyles = false;

            dgvAsignaciones.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.Font =
                new Font("Century Gothic", 11F, FontStyle.Bold);

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvAsignaciones.ColumnHeadersHeight = 50;

            dgvAsignaciones.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // FILAS
            dgvAsignaciones.DefaultCellStyle.BackColor = Color.White;

            dgvAsignaciones.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 30, 60);

            dgvAsignaciones.DefaultCellStyle.Font =
                new Font("Century Gothic", 10F, FontStyle.Regular);

            dgvAsignaciones.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvAsignaciones.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvAsignaciones.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 30, 60);

            // TAMAÑO
            dgvAsignaciones.Columns["Fecha"].FillWeight = 15;
            dgvAsignaciones.Columns["Hora"].FillWeight = 15;
            dgvAsignaciones.Columns["Actividad"].FillWeight = 20;
            dgvAsignaciones.Columns["Tipo"].FillWeight = 15;
            dgvAsignaciones.Columns["Lugar"].FillWeight = 20;
            dgvAsignaciones.Columns["Estado"].FillWeight = 15;

            dgvAsignaciones.ClearSelection();
        }
        private void ConfigurarTablaProximas()
        {
            dgvProximas.AutoGenerateColumns = false;
            dgvProximas.Columns.Clear();

            dgvProximas.Columns.Add("IdCronograma", "ID");
            dgvProximas.Columns["IdCronograma"].DataPropertyName = "IdCronograma";
            dgvProximas.Columns["IdCronograma"].Visible = false;

            dgvProximas.Columns.Add("Fecha", "FECHA");
            dgvProximas.Columns.Add("Actividad", "ACTIVIDAD");
            dgvProximas.Columns.Add("Lugar", "LUGAR");
            dgvProximas.Columns.Add("Estado", "ESTADO");

            dgvProximas.Columns["Fecha"].DataPropertyName = "Fecha";
            dgvProximas.Columns["Actividad"].DataPropertyName = "Actividad";
            dgvProximas.Columns["Lugar"].DataPropertyName = "Lugar";
            dgvProximas.Columns["Estado"].DataPropertyName = "Estado";

            // ESTILO GENERAL
            dgvProximas.BackgroundColor = Color.White;
            dgvProximas.BorderStyle = BorderStyle.None;

            dgvProximas.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvProximas.GridColor =
                Color.FromArgb(235, 235, 235);

            dgvProximas.RowHeadersVisible = false;

            dgvProximas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvProximas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvProximas.RowTemplate.Height = 50;

            // ENCABEZADO
            dgvProximas.EnableHeadersVisualStyles = false;

            dgvProximas.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvProximas.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvProximas.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvProximas.ColumnHeadersDefaultCellStyle.Font =
                new Font("Century Gothic", 11F, FontStyle.Bold);

            dgvProximas.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvProximas.ColumnHeadersHeight = 50;

            dgvProximas.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // FILAS
            dgvProximas.DefaultCellStyle.BackColor = Color.White;

            dgvProximas.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 30, 60);

            dgvProximas.DefaultCellStyle.Font =
                new Font("Century Gothic", 10F, FontStyle.Regular);

            dgvProximas.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvProximas.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvProximas.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 30, 60);

            dgvProximas.ClearSelection();
        }
        private void CargarProximasActividades()
        {
            dgvProximas.DataSource = conSQL.RetornaRegistros($@"
                SELECT TOP 5
                    IdCronograma,
                    Fecha,
                    Actividad,
                    Lugar,
                    Estado
                FROM CronogramaEntrenador
                WHERE IdEntrenador = {idEntrenador}
                AND (
                    Fecha > CAST(GETDATE() AS DATE)
                    OR (
                        Fecha = CAST(GETDATE() AS DATE)
                        AND HoraFin >= CAST(GETDATE() AS TIME)
                    )
                )
                AND Estado <> 'Finalizado'
                ORDER BY Fecha ASC, HoraInicio ASC");

            dgvProximas.ClearSelection();
        }
        private void CargarCronograma()
        {
            dgvAsignaciones.DataSource = conSQL.RetornaRegistros($@"
            SELECT
                IdCronograma,
                Fecha,
                CONVERT(VARCHAR(5), HoraInicio, 108) + ' - ' +
                CONVERT(VARCHAR(5), HoraFin, 108) AS Hora,
                Actividad,
                Tipo,
                Lugar,
                Estado
            FROM CronogramaEntrenador
            WHERE IdEntrenador = {idEntrenador}
            ORDER BY Fecha, HoraInicio");

            dgvAsignaciones.ClearSelection();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Abrir formulario para agregar actividad
            frmCronogramaActividad frm = new frmCronogramaActividad("Agregar", idEntrenador);
            frm.ShowDialog();

            //Actualizar estados y recargar tablas
            ActualizarEstadosVencidos();
            CargarCronograma();
            CargarProximasActividades();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {

            //Validar actividad seleccionada
            if (dgvAsignaciones.CurrentRow == null)
            {
                MessageBox.Show(
                    "Debe seleccionar una actividad.",
                    "Actividad no seleccionada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            //Obtener ID de la actividad
            int idCronograma = Convert.ToInt32(
                dgvAsignaciones.CurrentRow.Cells["IdCronograma"].Value
            );

            //Abrir formulario para editar
            frmCronogramaActividad frm =
                new frmCronogramaActividad(
                    "Editar",
                    idEntrenador,
                    idCronograma
                );

            frm.ShowDialog();

            //Actualizar estados y recargar tablas
            ActualizarEstadosVencidos();
            CargarCronograma();
            CargarProximasActividades();
        }
        private void MostrarDetalle(int idCronograma)
        {
            //Cargar detalle de la actividad
            DataTable dt = conSQL.RetornaRegistros($@"
            SELECT
                Fecha,
                HoraInicio,
                HoraFin,
                Actividad,
                Lugar,
                Tipo,
                Estado
            FROM CronogramaEntrenador
            WHERE IdCronograma = {idCronograma}");

            if (dt.Rows.Count == 0)
                return;

            DataRow fila = dt.Rows[0];

            lblFechaMostrar.Text =
                Convert.ToDateTime(fila["Fecha"]).ToString("dd/MM/yyyy");

            lblHoraMostrar.Text =
                fila["HoraInicio"].ToString().Substring(0, 5)
                + " - " +
                fila["HoraFin"].ToString().Substring(0, 5);

            lblActividadMostrar.Text =
                fila["Actividad"].ToString();

            lblLugarMostrar.Text =
                fila["Lugar"].ToString();

            lblTipoMostrar.Text =
                fila["Tipo"].ToString();

            lblEstadoMostrar.Text =
                fila["Estado"].ToString();
        }
        private void SeleccionarActividad(DataGridView dgv, int fila)
        {
            //Validar fila seleccionada
            if (fila < 0)
                return;

            int idCronograma = Convert.ToInt32(
                dgv.Rows[fila].Cells["IdCronograma"].Value
                );

            MostrarDetalle(idCronograma);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void btnFinalizar_Click(object sender, EventArgs e)
        {

            //Validar actividad seleccionada
            if (dgvAsignaciones.CurrentRow == null)
            {
                MessageBox.Show(
                    "Debe seleccionar una actividad.",
                    "Actividad no seleccionada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int idCronograma = Convert.ToInt32(
                dgvAsignaciones.CurrentRow.Cells["IdCronograma"].Value
            );

            //Confirmar finalización
            DialogResult resultado = MessageBox.Show(
                "¿Desea finalizar esta actividad?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.No)
                return;

            //Finalizar actividad en SQL
            string sql = $@"
            UPDATE CronogramaEntrenador
            SET Estado = 'Finalizado'
            WHERE IdCronograma = {idCronograma}
            AND IdEntrenador = {idEntrenador}";

            if (conSQL.EjecutaSentenciaSRD(sql))
            {
                MessageBox.Show(
                    "Actividad finalizada correctamente.",
                    "Actividad finalizada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                //Actualizar estados y recargar tablas
                ActualizarEstadosVencidos();
                CargarCronograma();
                CargarProximasActividades();
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void dgvProximas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Mostrar detalle de la actividad seleccionada
            SeleccionarActividad(dgvProximas, e.RowIndex);
        }
        private void dgvAsignaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Mostrar detalle de la actividad seleccionada
            SeleccionarActividad(dgvAsignaciones, e.RowIndex);
        }
        private void FiltrarCronograma()
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                return;
            }
            string filtro = cmbFiltro.Text;

            string condicion = "";

            // FILTRO POR TIPO
            if (filtro == "Entrenamiento" ||
                filtro == "Evaluación" ||
                filtro == "Medición" ||
                filtro == "Competencia")
            {
                condicion = " AND Tipo = '" + filtro + "'";
            }

            // FILTRO POR ESTADO
            else if (filtro == "Programado" ||
                     filtro == "Finalizado")
            {
                condicion = " AND Estado = '" + filtro + "'";
            }

            dgvAsignaciones.DataSource = conSQL.RetornaRegistros($@"
            SELECT
                IdCronograma,
                Fecha,
                CONVERT(VARCHAR(5), HoraInicio, 108) + ' - ' +
                CONVERT(VARCHAR(5), HoraFin, 108) AS Hora,
                Actividad,
                Tipo,
                Lugar,
                Estado
            FROM CronogramaEntrenador
            WHERE IdEntrenador = {idEntrenador}
            AND Fecha BETWEEN '{dtpDesde.Value:yyyy-MM-dd}'
                        AND '{dtpHasta.Value:yyyy-MM-dd}'
            {condicion}
            ORDER BY Fecha, HoraInicio");

            dgvAsignaciones.ClearSelection();
        }
        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Filtrar cronograma
            FiltrarCronograma();
        }
        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            //Filtrar por rango de fechas
            FiltrarCronograma();
        }
        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            //Filtrar por rango de fechas
            FiltrarCronograma();
        }
        private void ActualizarEstadosVencidos()
        {
            string sql = @"
            UPDATE CronogramaEntrenador
            SET Estado = 'Finalizado'
            WHERE Estado = 'Programado'
            AND (
                Fecha < CAST(GETDATE() AS DATE)
                OR (
                    Fecha = CAST(GETDATE() AS DATE)
                    AND HoraFin < CAST(GETDATE() AS TIME)
                )
            )";

            conSQL.EjecutaSentenciaSRD(sql);
        }

    }
}
