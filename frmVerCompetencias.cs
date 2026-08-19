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
    public partial class frmVerCompetencias : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        private int idDeportista;

        private DataTable dtCompetencias;
        public frmVerCompetencias(
            int idDeportista)
        {
            InitializeComponent();

            this.idDeportista =
                idDeportista;
        }
        public frmVerCompetencias()
        {
            InitializeComponent();
            ConfigurarTablaCompetencias();
        }
        private void ConfigurarTablaCompetencias()
        {
            // ==========================================
            // LIMPIAR TABLA
            // ==========================================
            dgvCompetencias.Columns.Clear();
            dgvCompetencias.Rows.Clear();


            // ==========================================
            // CREAR COLUMNAS
            // ==========================================
            dgvCompetencias.Columns.Add(
                "FechaInicio",
                "FECHA INICIO");

            dgvCompetencias.Columns.Add(
                "FechaFin",
                "FECHA FIN");

            dgvCompetencias.Columns.Add(
                "Competencia",
                "COMPETENCIA");

            dgvCompetencias.Columns.Add(
                "Organizador",
                "ORGANIZADOR");

            dgvCompetencias.Columns.Add(
                "Lugar",
                "LUGAR");

            dgvCompetencias.Columns.Add(
                "Nivel",
                "NIVEL");

            dgvCompetencias.Columns.Add(
                "Deporte",
                "DEPORTE");

            dgvCompetencias.Columns.Add(
                "Prueba",
                "PRUEBA / EVENTO");

            dgvCompetencias.Columns.Add(
                "Puesto",
                "PUESTO");


            // ==========================================
            // ESTILO GENERAL
            // ==========================================
            dgvCompetencias.BackgroundColor =
                Color.White;

            dgvCompetencias.BorderStyle =
                BorderStyle.None;

            dgvCompetencias.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvCompetencias.GridColor =
                Color.FromArgb(
                    235,
                    235,
                    235);


            // ==========================================
            // ENCABEZADO
            // ==========================================
            dgvCompetencias.EnableHeadersVisualStyles =
                false;

            dgvCompetencias.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvCompetencias
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvCompetencias
                .ColumnHeadersDefaultCellStyle
                .ForeColor =
                Color.White;

            dgvCompetencias
                .ColumnHeadersDefaultCellStyle
                .Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold);

            dgvCompetencias
                .ColumnHeadersDefaultCellStyle
                .Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvCompetencias.ColumnHeadersHeight =
                50;

            dgvCompetencias.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;


            // ==========================================
            // FILAS
            // ==========================================
            dgvCompetencias.RowHeadersVisible =
                false;

            dgvCompetencias.RowTemplate.Height =
                45;

            dgvCompetencias
                .DefaultCellStyle
                .BackColor =
                Color.White;

            dgvCompetencias
                .DefaultCellStyle
                .ForeColor =
                Color.FromArgb(
                    25,
                    30,
                    60);

            dgvCompetencias
                .DefaultCellStyle
                .Font =
                new Font(
                    "Segoe UI",
                    9.5F);

            dgvCompetencias
                .DefaultCellStyle
                .Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvCompetencias
                .DefaultCellStyle
                .SelectionBackColor =
                Color.FromArgb(
                    240,
                    242,
                    255);

            dgvCompetencias
                .DefaultCellStyle
                .SelectionForeColor =
                Color.FromArgb(
                    25,
                    30,
                    60);


            // ==========================================
            // AJUSTAR COLUMNAS
            // ==========================================
            dgvCompetencias.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvCompetencias.Columns["FechaInicio"]
                .FillWeight = 12;

            dgvCompetencias.Columns["FechaFin"]
                .FillWeight = 12;

            dgvCompetencias.Columns["Competencia"]
                .FillWeight = 24;

            dgvCompetencias.Columns["Organizador"]
                .FillWeight = 22;

            dgvCompetencias.Columns["Lugar"]
                .FillWeight = 15;

            dgvCompetencias.Columns["Nivel"]
                .FillWeight = 13;

            dgvCompetencias.Columns["Deporte"]
                .FillWeight = 15;

            dgvCompetencias.Columns["Prueba"]
                .FillWeight = 20;

            dgvCompetencias.Columns["Puesto"]
                .FillWeight = 10;


            // ==========================================
            // BLOQUEAR EDICIÓN
            // ==========================================
            dgvCompetencias.AllowUserToAddRows =
                false;

            dgvCompetencias.AllowUserToDeleteRows =
                false;

            dgvCompetencias.AllowUserToResizeRows =
                false;

            dgvCompetencias.AllowUserToResizeColumns =
                false;

            dgvCompetencias.ReadOnly =
                true;

            dgvCompetencias.MultiSelect =
                false;

            dgvCompetencias.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;


            // ==========================================
            // SIN FILAS FALSAS
            // ==========================================
            dgvCompetencias.ClearSelection();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmCompetenciasEntrenador frmSubCompetencia = new frmCompetenciasEntrenador();

            frmSubCompetencia.TopLevel = false;
            frmSubCompetencia.FormBorderStyle = FormBorderStyle.None;
            frmSubCompetencia.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmSubCompetencia);

            frmSubCompetencia.Show();

            this.Close();
        }

        private void frmVerCompetencias_Load(object sender, EventArgs e)
        {
            ConfigurarTablaCompetencias();

            CargarDatosDeportista();

            CargarCompetencias();

            CargarTotalCompetencias();

            CargarFiltroDeportes();
        }

        private void CargarFiltroDeportes()
        {
            try
            {
                string consulta =
                    @"
            SELECT DISTINCT
                D.IdDeporte,
                D.NombreDeporte

            FROM ParticipantesCompetencia PC

            INNER JOIN CompetenciaDeporte CD
                ON PC.IdCompetenciaDeporte =
                   CD.IdCompetenciaDeporte

            INNER JOIN Deportes D
                ON CD.IdDeporte =
                   D.IdDeporte

            WHERE
                PC.IdDeportista = " +
                        idDeportista + @"

            ORDER BY
                D.NombreDeporte;
            ";

                DataTable dt =
                    conSQL.RetornaRegistros(consulta);

                // Fila para mostrar todos
                DataRow filaTodos =
                    dt.NewRow();

                filaTodos["IdDeporte"] = 0;
                filaTodos["NombreDeporte"] =
                    "Todos los deportes";

                dt.Rows.InsertAt(
                    filaTodos,
                    0);

                cmbDeporte.DataSource = dt;

                cmbDeporte.DisplayMember =
                    "NombreDeporte";

                cmbDeporte.ValueMember =
                    "IdDeporte";

                cmbDeporte.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los deportes.\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarDatosDeportista()
        {
            try
            {
                // ==========================================
                // DATOS PERSONALES
                // ==========================================
                string consultaDeportista =
                    @"
            SELECT
                IdDeportista,
                Nombres,
                Apellidos,
                Estado

            FROM Deportistas

            WHERE
                IdDeportista = " +
                        idDeportista + @";
            ";

                DataTable dtDeportista =
                    conSQL.RetornaRegistros(
                        consultaDeportista);

                if (dtDeportista == null ||
                    dtDeportista.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No se encontró el deportista.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DataRow fila =
                    dtDeportista.Rows[0];

                lblNombreDeportista.Text =
                    fila["Nombres"].ToString() +
                    " " +
                    fila["Apellidos"].ToString();

                bool estado =
                    Convert.ToBoolean(
                        fila["Estado"]);

                lblEstado.Text =
                    estado
                    ? "Activo"
                    : "Inactivo";


                // ==========================================
                // DEPORTES DEL DEPORTISTA
                // ==========================================
                string consultaDeportes =
                    @"
            SELECT DISTINCT
                D.NombreDeporte

            FROM Inscripciones I

            INNER JOIN EntrenadorDeporte ED
                ON I.IdEntrenadorDeporte =
                   ED.IdEntrenadorDeporte

            INNER JOIN Deportes D
                ON ED.IdDeporte =
                   D.IdDeporte

            WHERE
                I.IdDeportista = " +
                        idDeportista + @"

            ORDER BY
                D.NombreDeporte;
            ";

                DataTable dtDeportes =
                    conSQL.RetornaRegistros(
                        consultaDeportes);

                if (dtDeportes != null &&
                    dtDeportes.Rows.Count > 0)
                {
                    string deportes = "";

                    foreach (DataRow deporte in
                             dtDeportes.Rows)
                    {
                        if (deportes != "")
                            deportes += ", ";

                        deportes +=
                            deporte["NombreDeporte"]
                            .ToString();
                    }

                    lblDeporte.Text =
                        "- " + deportes;
                }
                else
                {
                    lblDeporte.Text =
                        "- Sin deporte asignado";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los datos del deportista.\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void CargarCompetencias()
        {
            try
            {
                string consulta =
                    @"
            SELECT
                C.IdCompetencia,

                C.FechaInicio,

                C.FechaFin,

                C.NombreCompetencia
                    AS Competencia,

                C.Organizador,

                C.Lugar,

                C.Nivel,

                D.NombreDeporte
                    AS Deporte,

                ISNULL(
                    RC.Prueba,
                    'Sin registrar'
                ) AS Prueba,

                ISNULL(
                    RC.PuestoObtenido,
                    'Sin registrar'
                ) AS Puesto

            FROM ParticipantesCompetencia PC

            INNER JOIN CompetenciaDeporte CD
                ON PC.IdCompetenciaDeporte =
                   CD.IdCompetenciaDeporte

            INNER JOIN Competencias C
                ON CD.IdCompetencia =
                   C.IdCompetencia

            INNER JOIN Deportes D
                ON CD.IdDeporte =
                   D.IdDeporte

            LEFT JOIN ResultadosCompetencia RC
                ON PC.IdParticipanteCompetencia =
                   RC.IdParticipanteCompetencia

            WHERE
                PC.IdDeportista = " +
                        idDeportista + @"

            ORDER BY
                C.FechaInicio DESC;
            ";

                dtCompetencias =
                    conSQL.RetornaRegistros(
                        consulta);

                dgvCompetencias.Rows.Clear();

                if (dtCompetencias == null ||
                    dtCompetencias.Rows.Count == 0)
                {
                    dgvCompetencias.ClearSelection();

                    return;
                }

                foreach (DataRow fila in
                         dtCompetencias.Rows)
                {
                    string fechaInicio =
                        Convert.ToDateTime(
                            fila["FechaInicio"])
                        .ToString("dd/MM/yyyy");

                    string fechaFin = "";

                    if (fila["FechaFin"] !=
                        DBNull.Value)
                    {
                        fechaFin =
                            Convert.ToDateTime(
                                fila["FechaFin"])
                            .ToString("dd/MM/yyyy");
                    }

                    dgvCompetencias.Rows.Add(
                        fechaInicio,
                        fechaFin,
                        fila["Competencia"].ToString(),
                        fila["Organizador"].ToString(),
                        fila["Lugar"].ToString(),
                        fila["Nivel"].ToString(),
                        fila["Deporte"].ToString(),
                        fila["Prueba"].ToString(),
                        fila["Puesto"].ToString()
                    );
                }

                dgvCompetencias.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el historial de competencias.\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void CargarTotalCompetencias()
        {
            try
            {
                string consulta =
                    @"
            SELECT
                COUNT(
                    DISTINCT CD.IdCompetencia
                ) AS Total

            FROM ParticipantesCompetencia PC

            INNER JOIN CompetenciaDeporte CD
                ON PC.IdCompetenciaDeporte =
                   CD.IdCompetenciaDeporte

            WHERE
                PC.IdDeportista = " +
                        idDeportista + @";
            ";

                DataTable dt =
                    conSQL.RetornaRegistros(
                        consulta);

                int total = 0;

                if (dt != null &&
                    dt.Rows.Count > 0)
                {
                    total =
                        Convert.ToInt32(
                            dt.Rows[0]["Total"]);
                }

                lblTotalCompetencias.Text =
                    "Total de Competencias: " +
                    total;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo obtener el total de competencias.\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtBuscarCompetencia_TextChanged(object sender, EventArgs e)
        {
            FiltrarCompetencias();
        }
        private void FiltrarCompetencias()
        {
            if (dtCompetencias == null)
                return;

            string texto =
                txtBuscarCompetencia.Text
                .Trim()
                .ToLower();

            string deporteSeleccionado = "";

            if (cmbDeporte.SelectedIndex > 0)
            {
                deporteSeleccionado =
                    cmbDeporte.Text
                    .Trim()
                    .ToLower();
            }

            dgvCompetencias.Rows.Clear();

            foreach (DataRow fila in dtCompetencias.Rows)
            {
                string competencia =
                    fila["Competencia"]
                    .ToString()
                    .ToLower();

                string organizador =
                    fila["Organizador"]
                    .ToString()
                    .ToLower();

                string lugar =
                    fila["Lugar"]
                    .ToString()
                    .ToLower();

                string deporte =
                    fila["Deporte"]
                    .ToString()
                    .ToLower();


                // ==========================================
                // FILTRO DEL BUSCADOR
                // ==========================================
                bool coincideBusqueda =
                    texto == "" ||
                    competencia.Contains(texto) ||
                    organizador.Contains(texto) ||
                    lugar.Contains(texto) ||
                    deporte.Contains(texto);


                // ==========================================
                // FILTRO DE DEPORTE
                // ==========================================
                bool coincideDeporte =
                    deporteSeleccionado == "" ||
                    deporte == deporteSeleccionado;


                // ==========================================
                // MOSTRAR SOLO SI CUMPLE AMBOS
                // ==========================================
                if (coincideBusqueda &&
                    coincideDeporte)
                {
                    string fechaInicio =
                        Convert.ToDateTime(
                            fila["FechaInicio"])
                        .ToString("dd/MM/yyyy");

                    string fechaFin = "";

                    if (fila["FechaFin"] != DBNull.Value)
                    {
                        fechaFin =
                            Convert.ToDateTime(
                                fila["FechaFin"])
                            .ToString("dd/MM/yyyy");
                    }

                    dgvCompetencias.Rows.Add(
                        fechaInicio,
                        fechaFin,
                        fila["Competencia"].ToString(),
                        fila["Organizador"].ToString(),
                        fila["Lugar"].ToString(),
                        fila["Nivel"].ToString(),
                        fila["Deporte"].ToString(),
                        fila["Prueba"].ToString(),
                        fila["Puesto"].ToString()
                    );
                }
            }

            dgvCompetencias.ClearSelection();
        }

        private void cmbDeporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarCompetencias();
        }
    }
}
