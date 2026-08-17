using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmVerParticipantes : Form
    {
        private int idCompetencia;
        private int? idEntrenador;
        private bool esAdministrador;
        csConectaSQL conSQL =  new csConectaSQL();


        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public frmVerParticipantes()
        {
            InitializeComponent();

            esAdministrador = true;
            idEntrenador = null;

            ConfigurarTablaParticipantes();
        }

        public frmVerParticipantes(
            int idCompetencia)
        {
            InitializeComponent();

            this.idCompetencia =
                idCompetencia;

            esAdministrador = true;
            idEntrenador = null;

            ConfigurarTablaParticipantes();

            CargarInformacionCompetencia();
            CargarParticipantes();
        }




        public frmVerParticipantes(
            int idCompetencia,
            int idEntrenador)
        {
            InitializeComponent();

            this.idCompetencia =
                idCompetencia;

            this.idEntrenador =
                idEntrenador;

            esAdministrador = false;

            ConfigurarTablaParticipantes();

            CargarInformacionCompetencia();

            CargarParticipantes();
        }


        private void ConfigurarTablaParticipantes()
        {
            dgvParticipantes.Columns.Clear();
            dgvParticipantes.Rows.Clear();


            // ==========================================
            // COLUMNAS
            // ==========================================
            dgvParticipantes.Columns.Add(
                "NombreCompleto",
                "NOMBRE COMPLETO");

            dgvParticipantes.Columns.Add(
                "Categoria",
                "DEPORTE / CATEGORÍA");


            // ==========================================
            // CONFIGURACIÓN GENERAL
            // ==========================================
            dgvParticipantes.BackgroundColor =
                Color.White;

            dgvParticipantes.BorderStyle =
                BorderStyle.None;

            dgvParticipantes.CellBorderStyle =
                DataGridViewCellBorderStyle
                .SingleHorizontal;

            dgvParticipantes.GridColor =
                Color.FromArgb(
                    235,
                    235,
                    245);

            dgvParticipantes.RowHeadersVisible =
                false;

            dgvParticipantes.AllowUserToAddRows =
                false;

            dgvParticipantes.AllowUserToDeleteRows =
                false;

            dgvParticipantes.AllowUserToResizeRows =
                false;

            dgvParticipantes.AllowUserToResizeColumns =
                false;

            dgvParticipantes.ReadOnly =
                true;

            dgvParticipantes.MultiSelect =
                false;

            dgvParticipantes.SelectionMode =
                DataGridViewSelectionMode
                .FullRowSelect;

            dgvParticipantes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode
                .Fill;


            // ==========================================
            // ENCABEZADO
            // ==========================================
            dgvParticipantes.EnableHeadersVisualStyles =
                false;

            dgvParticipantes
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                Color.FromArgb(
                    245,
                    248,
                    255);

            dgvParticipantes
                .ColumnHeadersDefaultCellStyle
                .ForeColor =
                Color.FromArgb(
                    25,
                    55,
                    125);

            dgvParticipantes
                .ColumnHeadersDefaultCellStyle
                .Font =
                new Font(
                    "Century Gothic",
                    10F,
                    FontStyle.Bold);

            dgvParticipantes
                .ColumnHeadersDefaultCellStyle
                .Alignment =
                DataGridViewContentAlignment
                .MiddleLeft;

            dgvParticipantes.ColumnHeadersHeight =
                45;

            dgvParticipantes
                .ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;

            dgvParticipantes
                .ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle
                .None;


            // ==========================================
            // FILAS
            // ==========================================
            dgvParticipantes.RowTemplate.Height =
                45;

            dgvParticipantes
                .DefaultCellStyle
                .BackColor =
                Color.White;

            dgvParticipantes
                .DefaultCellStyle
                .ForeColor =
                Color.FromArgb(
                    25,
                    40,
                    95);

            dgvParticipantes
                .DefaultCellStyle
                .Font =
                new Font(
                    "Century Gothic",
                    10F,
                    FontStyle.Regular);

            dgvParticipantes
                .DefaultCellStyle
                .Alignment =
                DataGridViewContentAlignment
                .MiddleLeft;

            dgvParticipantes
                .DefaultCellStyle
                .SelectionBackColor =
                Color.FromArgb(
                    235,
                    238,
                    255);

            dgvParticipantes
                .DefaultCellStyle
                .SelectionForeColor =
                Color.FromArgb(
                    25,
                    40,
                    95);


            // ==========================================
            // TAMAÑOS
            // ==========================================
            dgvParticipantes
                .Columns["NombreCompleto"]
                .FillWeight =
                60;

            dgvParticipantes
                .Columns["Categoria"]
                .FillWeight =
                40;


            dgvParticipantes.ClearSelection();
        }


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        private void CargarInformacionCompetencia()
        {
            // ==========================================
            // DATOS GENERALES
            // ==========================================
            DataTable tablaCompetencia =
                conSQL.RetornaRegistros(
                    @"SELECT
                        FechaInicio,
                        FechaFin
                      FROM Competencias
                      WHERE IdCompetencia = " +
                    idCompetencia
                );


            if (tablaCompetencia == null ||
                tablaCompetencia.Rows.Count == 0)
            {
                lblFecha.Text =
                    "No disponible";

                return;
            }


            DateTime fechaInicio =
                Convert.ToDateTime(
                    tablaCompetencia
                    .Rows[0]["FechaInicio"]);


            DateTime fechaFin =
                Convert.ToDateTime(
                    tablaCompetencia
                    .Rows[0]["FechaFin"]);


            // ==========================================
            // FECHA
            // ==========================================
            if (fechaInicio.Date ==
                fechaFin.Date)
            {
                lblFecha.Text =
                    fechaInicio
                    .ToString("dd/MM/yyyy");
            }
            else
            {
                lblFecha.Text =
                    fechaInicio
                    .ToString("dd/MM/yyyy")
                    +
                    " - "
                    +
                    fechaFin
                    .ToString("dd/MM/yyyy");
            }


            // ==========================================
            // DEPORTES
            // ==========================================
            string consultaDeportes;


            // ADMIN: TODOS LOS DEPORTES
            if (esAdministrador)
            {
                consultaDeportes =
                    @"SELECT
                        D.NombreDeporte

                      FROM CompetenciaDeporte CD

                      INNER JOIN Deportes D
                          ON CD.IdDeporte =
                             D.IdDeporte

                      WHERE
                          CD.IdCompetencia = " +
                    idCompetencia +

                    @" ORDER BY
                        D.NombreDeporte";
            }

            // ENTRENADOR:
            // SOLO LOS DEPORTES QUE LE CORRESPONDEN
            else
            {
                consultaDeportes =
                    @"SELECT DISTINCT
                        D.NombreDeporte

                      FROM CompetenciaDeporte CD

                      INNER JOIN Deportes D
                          ON CD.IdDeporte =
                             D.IdDeporte

                      INNER JOIN EntrenadorDeporte ED
                          ON CD.IdDeporte =
                             ED.IdDeporte

                      WHERE
                          CD.IdCompetencia = " +
                    idCompetencia +

                    @" AND ED.IdEntrenador = " +
                    idEntrenador.Value +

                    @" AND ED.Activo = 1

                      ORDER BY
                        D.NombreDeporte";
            }


            DataTable tablaDeportes =
                conSQL.RetornaRegistros(
                    consultaDeportes);


            if (tablaDeportes == null ||
                tablaDeportes.Rows.Count == 0)
            {
                lblDeporte.Text =
                    "Sin deportes";
            }
            else
            {
                string deportes = "";

                foreach (DataRow fila
                         in tablaDeportes.Rows)
                {
                    if (deportes != "")
                    {
                        deportes += ", ";
                    }

                    deportes +=
                        fila["NombreDeporte"]
                        .ToString();
                }

                lblDeporte.Text =
                    deportes;
            }
        }
        private void CargarParticipantes()
        {
            string filtroEntrenador = "";


            // ==========================================
            // SI ES ENTRENADOR:
            // SOLO SUS DEPORTISTAS
            // ==========================================
            if (!esAdministrador)
            {
                filtroEntrenador =
                    @" AND EXISTS
                    (
                        SELECT 1

                        FROM Inscripciones I

                        INNER JOIN EntrenadorDeporte ED
                            ON I.IdEntrenadorDeporte =
                               ED.IdEntrenadorDeporte

                        WHERE
                            I.IdDeportista =
                                DEP.IdDeportista

                            AND I.Estado =
                                'Activo'

                            AND ED.IdEntrenador =
                                " + idEntrenador.Value + @"

                            AND ED.IdDeporte =
                                CD.IdDeporte
                    )";
            }


            // ==========================================
            // CONSULTA
            // ==========================================
            string consulta =
                @"SELECT DISTINCT

                    DEP.IdDeportista,

                    DEP.Nombres + ' ' +
                    DEP.Apellidos
                        AS NombreCompleto,

                    D.NombreDeporte,

                    (
                        SELECT TOP 1
                            M.CategoriaEdad

                        FROM MedicionesDeportista M

                        WHERE
                            M.IdDeportista =
                                DEP.IdDeportista

                        ORDER BY
                            M.FechaMedicion DESC,
                            M.IdMedicion DESC

                    ) AS Categoria

                  FROM ParticipantesCompetencia PC

                  INNER JOIN CompetenciaDeporte CD
                      ON PC.IdCompetenciaDeporte =
                         CD.IdCompetenciaDeporte

                  INNER JOIN Deportistas DEP
                      ON PC.IdDeportista =
                         DEP.IdDeportista

                  INNER JOIN Deportes D
                      ON CD.IdDeporte =
                         D.IdDeporte

                  WHERE
                      CD.IdCompetencia =
                          " + idCompetencia + @"

                      AND PC.EstadoParticipacion =
                          'Inscrito'

                      " + filtroEntrenador + @"

                  ORDER BY
                      NombreCompleto";


            DataTable tabla =
                conSQL.RetornaRegistros(
                    consulta);


            // ==========================================
            // LIMPIAR
            // ==========================================
            dgvParticipantes.Rows.Clear();


            if (tabla == null)
            {
                lblTotalInscritos.Text =
                    "0";

                return;
            }


            // ==========================================
            // LLENAR
            // ==========================================
            foreach (DataRow fila
                     in tabla.Rows)
            {
                string categoria =
                    fila["Categoria"] ==
                    DBNull.Value
                    ? "Sin medición"
                    : fila["Categoria"]
                        .ToString();


                // Si la competencia tiene varios
                // deportes, mostramos también el deporte
                // junto a la categoría.
                string categoriaMostrar =
                    fila["NombreDeporte"]
                    .ToString();

                if (categoria !=
                    "Sin medición")
                {
                    categoriaMostrar +=
                        " - " +
                        categoria;
                }
                else
                {
                    categoriaMostrar +=
                        " - Sin medición";
                }


                int indice =
                    dgvParticipantes.Rows.Add(
                        fila["NombreCompleto"]
                            .ToString(),

                        categoriaMostrar
                    );


                dgvParticipantes
                    .Rows[indice]
                    .Tag =
                    Convert.ToInt32(
                        fila["IdDeportista"]);
            }


            // ==========================================
            // TOTAL INSCRITOS
            // ==========================================
            lblTotalInscritos.Text =
                dgvParticipantes
                .Rows.Count
                .ToString();


            dgvParticipantes.ClearSelection();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
