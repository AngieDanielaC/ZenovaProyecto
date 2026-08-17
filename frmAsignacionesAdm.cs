using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace wfZenova
{
    public partial class frmAsignacionesAdm : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        int ClientexPag = 40;
        int Bandera = 0;

        public frmAsignacionesAdm()
        {
            InitializeComponent();

            ConfigurarTablaAsignaciones();
        }
        private void ConfigurarTablaAsignaciones()
        {
            dgvAsignaciones.AutoGenerateColumns = false;

            dgvAsignaciones.Columns.Clear();
            dgvAsignaciones.Rows.Clear();

            // ID oculto
            dgvAsignaciones.Columns.Add("IdInscripcion", "ID");

            // Columnas visibles
            dgvAsignaciones.Columns.Add("Deportista", "DEPORTISTA");
            dgvAsignaciones.Columns.Add("Disciplina", "DISCIPLINA");
            dgvAsignaciones.Columns.Add("Entrenador", "ENTRENADOR");
            dgvAsignaciones.Columns.Add("TipoInscripcion", "TIPO");
            dgvAsignaciones.Columns.Add("Inicio", "INICIO");
            dgvAsignaciones.Columns.Add("Fin", "FIN");
            dgvAsignaciones.Columns.Add("Estado", "ESTADO");

            // Relacionar columnas con VistaInscripciones
            dgvAsignaciones.Columns["IdInscripcion"].DataPropertyName = "IdInscripcion";
            dgvAsignaciones.Columns["Deportista"].DataPropertyName = "Deportista";
            dgvAsignaciones.Columns["Disciplina"].DataPropertyName = "Disciplina";
            dgvAsignaciones.Columns["Entrenador"].DataPropertyName = "Entrenador";
            dgvAsignaciones.Columns["TipoInscripcion"].DataPropertyName = "TipoInscripcion";
            dgvAsignaciones.Columns["Inicio"].DataPropertyName = "FechaInicio";
            dgvAsignaciones.Columns["Fin"].DataPropertyName = "FechaFin";
            dgvAsignaciones.Columns["Estado"].DataPropertyName = "Estado";

            // Ocultar ID
            dgvAsignaciones.Columns["IdInscripcion"].Visible = false;

            // ESTILO GENERAL
            dgvAsignaciones.BackgroundColor = Color.White;
            dgvAsignaciones.BorderStyle = BorderStyle.None;

            dgvAsignaciones.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvAsignaciones.GridColor =
                Color.FromArgb(235, 235, 235);

            dgvAsignaciones.RowHeadersVisible = false;

            dgvAsignaciones.AllowUserToAddRows = false;
            dgvAsignaciones.AllowUserToDeleteRows = false;
            dgvAsignaciones.AllowUserToResizeRows = false;
            dgvAsignaciones.AllowUserToResizeColumns = false;

            dgvAsignaciones.ReadOnly = true;
            dgvAsignaciones.MultiSelect = false;

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

            // TAMAÑO DE COLUMNAS
            dgvAsignaciones.Columns["Deportista"].FillWeight = 22;
            dgvAsignaciones.Columns["Disciplina"].FillWeight = 16;
            dgvAsignaciones.Columns["Entrenador"].FillWeight = 22;
            dgvAsignaciones.Columns["TipoInscripcion"].FillWeight = 15;
            dgvAsignaciones.Columns["Inicio"].FillWeight = 12;
            dgvAsignaciones.Columns["Fin"].FillWeight = 12;
            dgvAsignaciones.Columns["Estado"].FillWeight = 12;

            dgvAsignaciones.ClearSelection();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Validar fechas
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
            {
                MessageBox.Show(
                    "La fecha de inicio no puede ser mayor que la fecha de fin.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Validar ComboBox
            if (cmbDisciplina.SelectedIndex == -1 ||
                cmbEntrenador.SelectedIndex == -1 ||
                cmbTipoInscripcion.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Debe seleccionar la disciplina, el entrenador y el tipo de inscripción.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Validar deportista
            if (cmbDeportista.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Debe seleccionar un deportista.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int idDeportista = Convert.ToInt32(cmbDeportista.SelectedValue);
            int idDeporte = Convert.ToInt32(cmbDisciplina.SelectedValue);
            int idEntrenador = Convert.ToInt32(cmbEntrenador.SelectedValue);

            // Validar que no esté inscrito nuevamente en la misma disciplina
            DataTable dtExiste = conSQL.RetornaRegistros($@"
                SELECT COUNT(*) AS Cantidad
                FROM Inscripciones I
                INNER JOIN EntrenadorDeporte ED
                    ON I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte
                WHERE I.IdDeportista = {idDeportista}
                AND ED.IdDeporte = {idDeporte}
                AND I.Estado <> 'Finalizado'");

            int cantidad = Convert.ToInt32(dtExiste.Rows[0]["Cantidad"]);

            if (cantidad > 0)
            {
                MessageBox.Show(
                    "El deportista ya se encuentra inscrito en esta disciplina.",
                    "Inscripción existente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Buscar el IdEntrenadorDeporte
            DataTable dtRelacion = conSQL.RetornaRegistros($@"
                SELECT IdEntrenadorDeporte
                FROM EntrenadorDeporte
                WHERE IdEntrenador = {idEntrenador}
                AND IdDeporte = {idDeporte}
                AND Activo = 1");

            if (dtRelacion.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró la relación entre el entrenador y la disciplina.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            int idEntrenadorDeporte =
                Convert.ToInt32(dtRelacion.Rows[0]["IdEntrenadorDeporte"]);

            string tipoInscripcion =
                cmbTipoInscripcion.Text.Replace("'", "''");

            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFin = dtpFechaFin.Value.Date;

            // Guardar inscripción
            string sql = $@"
                INSERT INTO Inscripciones
                (
                    IdDeportista,
                    IdEntrenadorDeporte,
                    FechaInicio,
                    FechaFin,
                    Estado,
                    FechaRegistro,
                    TipoInscripcion
                )
                VALUES
                (
                    {idDeportista},
                    {idEntrenadorDeporte},
                    '{fechaInicio:yyyy-MM-dd}',
                    '{fechaFin:yyyy-MM-dd}',
                    'Activo',
                    GETDATE(),
                    '{tipoInscripcion}'
                 )";

            if (conSQL.EjecutaSentenciaSRD(sql))
            {
                MessageBox.Show(
                    "Inscripción registrada correctamente.",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Marcar deportista como activo
                conSQL.EjecutaSentenciaSRD(
                    "UPDATE Deportistas " +
                    "SET Estado = 1 " +
                    "WHERE IdDeportista = " + idDeportista
                );

                // Recargar tabla
                dgvAsignaciones.DataSource =
                    conSQL.RetornaRegistros("SELECT * FROM VistaInscripciones");

                // Limpiar selección
                cmbDisciplina.SelectedIndex = -1;
                cmbEntrenador.DataSource = null;
                cmbTipoInscripcion.SelectedIndex = -1;
            }
        }

        private void frmAsignacionesAdm_Load(object sender, EventArgs e)
        {
            Bandera = 1;
            CargarDisciplinas();
            CargarDeportistas();
            Bandera = 0;

            dgvAsignaciones.DataSource =
                    conSQL.RetornaRegistros("SELECT * FROM VistaInscripciones");
        }
        
        private void cmbDeportista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Bandera == 1 || cmbDeportista.SelectedIndex == -1)
                return;

            if (!int.TryParse(cmbDeportista.SelectedValue.ToString(), out int idDeportista))
                return;

            // DATOS DEL DEPORTISTA
            DataTable dt = conSQL.RetornaRegistros($@"
            SELECT 
                Nombres + ' ' + Apellidos AS Deportista,
                FechaNacimiento,
                Foto
            FROM Deportistas
            WHERE IdDeportista = {idDeportista}");

            if (dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];

                // Nombre
                lblNombreDeportista.Text = fila["Deportista"].ToString();

                // Edad
                DateTime fechaNacimiento =
                    Convert.ToDateTime(fila["FechaNacimiento"]);

                int edad = DateTime.Today.Year - fechaNacimiento.Year;

                if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad))
                    edad--;

                lblEdad.Text = edad + " años";

                // Foto
                if (fila["Foto"] != DBNull.Value)
                {
                    byte[] foto = (byte[])fila["Foto"];

                    using (MemoryStream ms = new MemoryStream(foto))
                    {
                        using (Image img = Image.FromStream(ms))
                        {
                            picDeportista.Image = new Bitmap(img);
                        }
                    }
                }
                else
                {
                    picDeportista.Image = null;
                }
            }

            // DEPORTES EN LOS QUE ESTÁ INSCRITO
            DataTable dtDeportes = conSQL.RetornaRegistros($@"
            SELECT DISTINCT D.NombreDeporte
            FROM Inscripciones I
            INNER JOIN EntrenadorDeporte ED
                ON I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte
            INNER JOIN Deportes D
                ON ED.IdDeporte = D.IdDeporte
            WHERE I.IdDeportista = {idDeportista}
            AND I.Estado <> 'Finalizado'");

            if (dtDeportes.Rows.Count == 0)
            {
                lblDeportes.Text = "Sin inscripción";
            }
            else
            {
                string deportes = "";

                foreach (DataRow fila in dtDeportes.Rows)
                {
                    if (deportes != "")
                        deportes += ", ";

                    deportes += fila["NombreDeporte"].ToString();
                }

                lblDeportes.Text = deportes;
            }
        }
        
        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Bandera == 1 || cmbDisciplina.SelectedIndex == -1)
                return;

            if (!int.TryParse(cmbDisciplina.SelectedValue.ToString(), out int idDeporte))
                return;

            Bandera = 1;

            DataTable dt = conSQL.RetornaRegistros($@"
            SELECT DISTINCT
                 E.IdEntrenador,
                 E.Nombres + ' ' + E.Apellidos AS Entrenador
            FROM Entrenadores E
            INNER JOIN EntrenadorDeporte ED
                 ON E.IdEntrenador = ED.IdEntrenador
            WHERE ED.IdDeporte = {idDeporte}
                 AND ED.Activo = 1
            ORDER BY Entrenador");

            cmbEntrenador.DataSource = dt;
            cmbEntrenador.DisplayMember = "Entrenador";
            cmbEntrenador.ValueMember = "IdEntrenador";
            cmbEntrenador.SelectedIndex = -1;

            Bandera = 0;
        }
        
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (dgvAsignaciones.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una inscripción.");
                return;
            }

            int idInscripcion = Convert.ToInt32(
                dgvAsignaciones.CurrentRow.Cells["IdInscripcion"].Value
            );

            string sql = "UPDATE Inscripciones " +
                         "SET Estado = 'Finalizado' " +
                         "WHERE IdInscripcion = " + idInscripcion;

            if (conSQL.EjecutaSentenciaSRD(sql))
            {
                MessageBox.Show("Inscripción finalizada correctamente.");

                dgvAsignaciones.DataSource =
                    conSQL.RetornaRegistros("SELECT * FROM VistaInscripciones");
            }
        }

        private void btnCambiarEntrenador_Click(object sender, EventArgs e)
        {
            if (dgvAsignaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Debe seleccionar una inscripción.",
                    "Seleccione un deportista",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            int idInscripcion = Convert.ToInt32(
                dgvAsignaciones.SelectedRows[0].Cells["IdInscripcion"].Value
            );

            frmCambiarEntrenador frm = new frmCambiarEntrenador(idInscripcion);
            frm.ShowDialog();

            dgvAsignaciones.DataSource =
                conSQL.RetornaRegistros("SELECT * FROM VistaInscripciones");
        }
        private void CargarDisciplinas()
        {
            DataTable dt = conSQL.RetornaRegistros(@"
               SELECT IdDeporte, NombreDeporte
               FROM Deportes
               ORDER BY NombreDeporte");

            cmbDisciplina.DataSource = dt;
            cmbDisciplina.DisplayMember = "NombreDeporte";
            cmbDisciplina.ValueMember = "IdDeporte";
            cmbDisciplina.SelectedIndex = -1;
        }
        private void CargarDeportistas()
        {
            cmbDeportista.DataSource = conSQL.RetornaRegistros(
                "SELECT IdDeportista, Nombres + ' ' + Apellidos AS Deportista FROM Deportistas"
            );

            cmbDeportista.DisplayMember = "Deportista";
            cmbDeportista.ValueMember = "IdDeportista";
            cmbDeportista.SelectedIndex = -1;
        }
        private void CargarEntrenadores()
        {
            DataTable dt = conSQL.RetornaRegistros(@"
                SELECT IdEntrenador, Nombres
                FROM Entrenadores
                ORDER BY Nombres");

            cmbEntrenador.DataSource = dt;
            cmbEntrenador.DisplayMember = "Nombres";
            cmbEntrenador.ValueMember = "IdEntrenador";
            cmbEntrenador.SelectedIndex = -1;
        }

        private void cmbEntrenador_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.Trim().Replace("'", "''");

            if (filtro == "")
            {
                dgvAsignaciones.DataSource =
                    conSQL.RetornaRegistros("SELECT * FROM VistaInscripciones");

                return;
            }

            dgvAsignaciones.DataSource = conSQL.RetornaRegistros(
                "SELECT * FROM VistaInscripciones WHERE " +
                "Deportista LIKE '%" + filtro + "%' OR " +
                "Disciplina LIKE '%" + filtro + "%' OR " +
                "Entrenador LIKE '%" + filtro + "%' OR " +
                "TipoInscripcion LIKE '%" + filtro + "%' OR " +
                "Estado LIKE '%" + filtro + "%' OR " +
                "CONVERT(VARCHAR, FechaInicio, 103) LIKE '%" + filtro + "%' OR " +
                "CONVERT(VARCHAR, FechaFin, 103) LIKE '%" + filtro + "%'"
            );
        }

        private void dgvAsignaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
