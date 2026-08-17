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
    public partial class frmCompetencias : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        public frmCompetencias()
        {
            InitializeComponent();
            ConfigurarTablaCompetencias();
            CargarCompetencias();
        }
        private Form formularioActivo = null;
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
                "NombreCompetencia",
                "NOMBRE DE LA COMPETENCIA");

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
                "FechaInicio",
                "FECHA INICIO");

            dgvCompetencias.Columns.Add(
                "FechaFin",
                "FECHA FIN");

            dgvCompetencias.Columns.Add(
                "FechaLimite",
                "LÍMITE INSCRIPCIÓN");

            dgvCompetencias.Columns.Add(
                "Deportes",
                "DEPORTES");

            dgvCompetencias.Columns.Add( "Inscritos","INSCRITOS");

            dgvCompetencias.Columns.Add(
                "Estado",
                "ESTADO");


            // ==========================================
            // CONFIGURACIÓN GENERAL
            // ==========================================
            dgvCompetencias.BackgroundColor =
                Color.White;

            dgvCompetencias.BorderStyle =
                BorderStyle.None;

            dgvCompetencias.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvCompetencias.GridColor =
                Color.FromArgb(235, 235, 245);

            dgvCompetencias.RowHeadersVisible =
                false;

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

            dgvCompetencias.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            // ==========================================
            // ENCABEZADOS
            // ==========================================
            dgvCompetencias.EnableHeadersVisualStyles =
                false;

            dgvCompetencias.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 63, 221);

            dgvCompetencias.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvCompetencias.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    9F,
                    FontStyle.Bold);

            dgvCompetencias.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvCompetencias.ColumnHeadersDefaultCellStyle.WrapMode =
                DataGridViewTriState.True;

            dgvCompetencias.ColumnHeadersHeight =
                55;

            dgvCompetencias.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvCompetencias.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;


            // ==========================================
            // FILAS
            // ==========================================
            dgvCompetencias.RowTemplate.Height =
                55;

            dgvCompetencias.DefaultCellStyle.BackColor =
                Color.White;

            dgvCompetencias.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 40, 95);

            dgvCompetencias.DefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    9F,
                    FontStyle.Regular);

            dgvCompetencias.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvCompetencias.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvCompetencias.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 40, 95);

            dgvCompetencias.DefaultCellStyle.WrapMode =
                DataGridViewTriState.False;


            // ==========================================
            // TAMAÑO DE LAS COLUMNAS
            // ==========================================

            // Las más grandes
            dgvCompetencias.Columns["NombreCompetencia"]
                .FillWeight = 150;

            dgvCompetencias.Columns["Organizador"]
                .FillWeight = 140;

            dgvCompetencias.Columns["Deportes"]
                .FillWeight = 110;


            // Tamaño medio
            dgvCompetencias.Columns["Lugar"]
                .FillWeight = 85;

            dgvCompetencias.Columns["Nivel"]
                .FillWeight = 75;

            dgvCompetencias.Columns["Estado"]
                .FillWeight = 75;
            dgvCompetencias.Columns["Inscritos"].FillWeight = 65;

            // Fechas
            dgvCompetencias.Columns["FechaInicio"]
                .FillWeight = 85;

            dgvCompetencias.Columns["FechaFin"]
                .FillWeight = 85;

            dgvCompetencias.Columns["FechaLimite"]
                .FillWeight = 95;


            // ==========================================
            // ALINEACIÓN
            // ==========================================
            dgvCompetencias.Columns["NombreCompetencia"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvCompetencias.Columns["Organizador"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvCompetencias.Columns["Lugar"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvCompetencias.Columns["Deportes"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;


            // ==========================================
            // QUITAR SELECCIÓN INICIAL
            // ==========================================
            dgvCompetencias.ClearSelection();
        }
        private void CargarCompetencias()
        {
            try
            {
                // ==========================================
                // TEXTO DE BÚSQUEDA
                // ==========================================
                string buscar =
                    txtBuscarCompetencia.Text.Trim();

                // "Buscar" es solo texto visual
                if (buscar.Equals(
                    "Buscar",
                    StringComparison.OrdinalIgnoreCase))
                {
                    buscar = "";
                }

                buscar =
                    buscar.Replace("'", "''");


                // ==========================================
                // FILTRO
                // ==========================================
                string filtroBuscar = "";

                if (buscar != "")
                {
                    filtroBuscar =
                        @" AND
                (
                    C.NombreCompetencia
                        LIKE '%" + buscar + @"%'

                    OR C.Organizador
                        LIKE '%" + buscar + @"%'

                    OR C.Lugar
                        LIKE '%" + buscar + @"%'

                    OR C.Nivel
                        LIKE '%" + buscar + @"%'

                    OR EXISTS
                    (
                        SELECT 1

                        FROM CompetenciaDeporte CDF

                        INNER JOIN Deportes DF
                            ON CDF.IdDeporte =
                               DF.IdDeporte

                        WHERE
                            CDF.IdCompetencia =
                                C.IdCompetencia

                            AND DF.NombreDeporte
                                LIKE '%" + buscar + @"%'
                    )
                )";
                }


                // ==========================================
                // CONSULTA
                // ==========================================
                string consulta =
                    @"
            SELECT
                C.IdCompetencia,
                C.NombreCompetencia,
                C.Organizador,
                C.Lugar,
                C.Nivel,
                C.FechaInicio,
                C.FechaFin,
                C.FechaLimiteInscripcion,

                -- DEPORTES
                STUFF
                (
                    (
                        SELECT
                            ', ' +
                            D.NombreDeporte

                        FROM CompetenciaDeporte CD

                        INNER JOIN Deportes D
                            ON CD.IdDeporte =
                               D.IdDeporte

                        WHERE
                            CD.IdCompetencia =
                                C.IdCompetencia

                        ORDER BY
                            D.NombreDeporte

                        FOR XML PATH(''), TYPE

                    ).value(
                        '.',
                        'NVARCHAR(MAX)'
                    ),
                    1,
                    2,
                    ''
                ) AS Deportes,


                -- TOTAL INSCRITOS
                (
                    SELECT COUNT(*)

                    FROM ParticipantesCompetencia PC

                    INNER JOIN CompetenciaDeporte CD2
                        ON PC.IdCompetenciaDeporte =
                           CD2.IdCompetenciaDeporte

                    WHERE
                        CD2.IdCompetencia =
                            C.IdCompetencia

                        AND PC.EstadoParticipacion =
                            'Inscrito'

                ) AS Inscritos,


                -- ESTADO ACTUAL
                CASE

                    WHEN C.Estado =
                         'Cancelada'
                        THEN 'Cancelada'

                    WHEN CAST(GETDATE() AS DATE)
                         < C.FechaInicio
                        THEN 'Próxima'

                    WHEN CAST(GETDATE() AS DATE)
                         BETWEEN
                            C.FechaInicio
                            AND C.FechaFin
                        THEN 'En curso'

                    ELSE
                        'Finalizada'

                END AS EstadoActual


            FROM Competencias C

            WHERE 1 = 1

            " + filtroBuscar + @"

            ORDER BY
                C.FechaInicio DESC,
                C.NombreCompetencia;
            ";


                DataTable tabla =
                    conSQL.RetornaRegistros(
                        consulta);


                if (tabla == null)
                    return;


                // ==========================================
                // LIMPIAR TABLA
                // ==========================================
                dgvCompetencias.Rows.Clear();


                // ==========================================
                // MOSTRAR
                // ==========================================
                foreach (DataRow fila
                         in tabla.Rows)
                {
                    string fechaInicio =
                        Convert.ToDateTime(
                            fila["FechaInicio"])
                        .ToString("dd/MM/yyyy");


                    string fechaFin =
                        Convert.ToDateTime(
                            fila["FechaFin"])
                        .ToString("dd/MM/yyyy");


                    string fechaLimite;

                    if (fila["FechaLimiteInscripcion"]
                        != DBNull.Value)
                    {
                        fechaLimite =
                            Convert.ToDateTime(
                                fila["FechaLimiteInscripcion"])
                            .ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        fechaLimite =
                            "Sin límite";
                    }


                    string deportes =
                        fila["Deportes"] ==
                        DBNull.Value
                        ? "Sin deportes"
                        : fila["Deportes"]
                            .ToString();


                    int inscritos =
                        Convert.ToInt32(
                            fila["Inscritos"]);


                    int indice =
                        dgvCompetencias.Rows.Add(
                            fila["NombreCompetencia"]
                                .ToString(),

                            fila["Organizador"]
                                .ToString(),

                            fila["Lugar"]
                                .ToString(),

                            fila["Nivel"]
                                .ToString(),

                            fechaInicio,

                            fechaFin,

                            fechaLimite,

                            deportes,

                            inscritos,

                            fila["EstadoActual"]
                                .ToString()
                        );


                    // ID oculto mediante Tag
                    dgvCompetencias
                        .Rows[indice]
                        .Tag =
                        Convert.ToInt32(
                            fila["IdCompetencia"]);
                }


                dgvCompetencias.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las competencias:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrarCompetencia_Click(object sender, EventArgs e)
        {
            frmRegistrarCompetencia frm = new frmRegistrarCompetencia();

            if (frm.ShowDialog() ==
                DialogResult.OK)
            {
                CargarCompetencias();
            }
        }

        private void btnGestionarParticipantes_Click(object sender, EventArgs e)
        {
            if (dgvCompetencias.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione una competencia.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idCompetencia =
                Convert.ToInt32(
                    dgvCompetencias
                    .CurrentRow
                    .Tag);

            // CONTENEDOR DONDE ESTÁ ABIERTO
            // frmCompetencias
            Control contenedor =
                this.Parent;

            if (contenedor == null)
                return;

            frmGestionarParticipantes frm =
                new frmGestionarParticipantes(
                    idCompetencia);

            frm.TopLevel = false;

            frm.FormBorderStyle =
                FormBorderStyle.None;

            frm.Dock =
                DockStyle.Fill;

            // Quitamos la pantalla de competencias
            contenedor.Controls.Remove(this);

            // Abrimos Gestionar Participantes
            // dentro del mismo panel
            contenedor.Controls.Add(frm);

            frm.Show();

            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCompetencias.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione una competencia.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            int idCompetencia =
                Convert.ToInt32(
                    dgvCompetencias.CurrentRow.Tag);


            frmRegistrarCompetencia frm =
                new frmRegistrarCompetencia(
                    idCompetencia);


            if (frm.ShowDialog() ==
                DialogResult.OK)
            {
                CargarCompetencias();
            }
        }

        private void txtBuscarComp_TextChanged(object sender, EventArgs e)
        {
            CargarCompetencias();
        }
    }
}
