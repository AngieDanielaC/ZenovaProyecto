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
    public partial class frmCompetenciasEntrenador : Form
    {
        private bool esAdministrador;
        private int? idEntrenador;
        csConectaSQL conSQL = new csConectaSQL();
        public frmCompetenciasEntrenador()
        {
            InitializeComponent();

            esAdministrador = true;
            idEntrenador = null;

            ConfigurarTablaCompetencias();
            CargarFiltroDeportes();
            CargarCompetencias();
        }

        public frmCompetenciasEntrenador(int idEntrenador)
        {
            InitializeComponent();

            esAdministrador = false;
            this.idEntrenador = idEntrenador;

            ConfigurarTablaCompetencias();
            CargarFiltroDeportes();
            CargarCompetencias();
        }
        private void ConfigurarTablaCompetencias()
        {
            dgvCompetencias.Columns.Clear();
            dgvCompetencias.Rows.Clear();

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
                "Deportes",
                "DEPORTES");

            dgvCompetencias.Columns.Add(
                "FechaInicio",
                "FECHA INICIO");

            dgvCompetencias.Columns.Add(
                "FechaFin",
                "FECHA FIN");

            dgvCompetencias.Columns.Add(
                "MisInscritos",
                "MIS DEPORTISTAS INSCRITOS");

            dgvCompetencias.Columns.Add(
                "Estado",
                "ESTADO");


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

            dgvCompetencias.ColumnHeadersHeight =
                55;


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


            dgvCompetencias.Columns["NombreCompetencia"]
                .FillWeight = 150;

            dgvCompetencias.Columns["Organizador"]
                .FillWeight = 120;

            dgvCompetencias.Columns["Lugar"]
                .FillWeight = 90;

            dgvCompetencias.Columns["Nivel"]
                .FillWeight = 75;

            dgvCompetencias.Columns["Deportes"]
                .FillWeight = 110;

            dgvCompetencias.Columns["FechaInicio"]
                .FillWeight = 85;

            dgvCompetencias.Columns["FechaFin"]
                .FillWeight = 85;

            dgvCompetencias.Columns["MisInscritos"]
                .FillWeight = 100;

            dgvCompetencias.Columns["Estado"]
                .FillWeight = 75;


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

            dgvCompetencias.ClearSelection();
        }

        private void CargarFiltroDeportes()
        {
            DataTable tabla;

            if (esAdministrador)
            {
                tabla =
                    conSQL.RetornaRegistros(
                        @"SELECT
                    IdDeporte,
                    NombreDeporte
                  FROM Deportes
                  WHERE Activo = 1
                  ORDER BY NombreDeporte"
                    );
            }
            else
            {
                tabla =
                    conSQL.RetornaRegistros(
                        @"SELECT DISTINCT
                    D.IdDeporte,
                    D.NombreDeporte

                  FROM EntrenadorDeporte ED

                  INNER JOIN Deportes D
                    ON ED.IdDeporte =
                       D.IdDeporte

                  WHERE
                    ED.IdEntrenador = " +
                        idEntrenador.Value +
                        @" AND ED.Activo = 1

                  ORDER BY D.NombreDeporte"
                    );
            }

            if (tabla == null)
                return;


            DataRow todos =
                tabla.NewRow();

            todos["IdDeporte"] = 0;
            todos["NombreDeporte"] = "Todos";

            tabla.Rows.InsertAt(
                todos,
                0);


            cmbFiltroDeporte.DataSource =
                tabla;

            cmbFiltroDeporte.DisplayMember =
                "NombreDeporte";

            cmbFiltroDeporte.ValueMember =
                "IdDeporte";

            cmbFiltroDeporte.SelectedIndex =
                0;

            cmbFiltroDeporte.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }


        private void CargarCompetencias()
        {
            string textoBuscar =
                txtBuscarCompetencia.Text.Trim()
                .Replace("'", "''");

            int idDeporteFiltro = 0;

            if (cmbFiltroDeporte.SelectedValue != null &&
                !(cmbFiltroDeporte.SelectedValue
                is DataRowView))
            {
                idDeporteFiltro =
                    Convert.ToInt32(
                        cmbFiltroDeporte.SelectedValue);
            }


            string filtroBuscar = "";

            if (textoBuscar != "")
            {
                filtroBuscar =
                    @" AND (
                C.NombreCompetencia
                    LIKE '%" + textoBuscar + @"%'
                OR C.Organizador
                    LIKE '%" + textoBuscar + @"%'
                OR C.Lugar
                    LIKE '%" + textoBuscar + @"%'
            )";
            }


            string filtroDeporte = "";

            if (idDeporteFiltro > 0)
            {
                filtroDeporte =
                    @" AND EXISTS
            (
                SELECT 1
                FROM CompetenciaDeporte CDF
                WHERE
                    CDF.IdCompetencia =
                    C.IdCompetencia
                    AND CDF.IdDeporte =
                    " + idDeporteFiltro + @"
            )";
            }


            string filtroEntrenador = "";

            if (!esAdministrador)
            {
                filtroEntrenador =
                    @" AND EXISTS
            (
                SELECT 1

                FROM CompetenciaDeporte CDE

                INNER JOIN EntrenadorDeporte EDE
                    ON CDE.IdDeporte =
                       EDE.IdDeporte

                WHERE
                    CDE.IdCompetencia =
                        C.IdCompetencia

                    AND EDE.IdEntrenador =
                        " + idEntrenador.Value + @"

                    AND EDE.Activo = 1
            )";
            }


            string campoInscritos;

            if (esAdministrador)
            {
                campoInscritos =
                    @"(
                SELECT COUNT(*)

                FROM ParticipantesCompetencia PC

                INNER JOIN CompetenciaDeporte CDP
                    ON PC.IdCompetenciaDeporte =
                       CDP.IdCompetenciaDeporte

                WHERE
                    CDP.IdCompetencia =
                        C.IdCompetencia

                    AND PC.EstadoParticipacion =
                        'Inscrito'
            )";
            }
            else
            {
                campoInscritos =
                    @"(
                SELECT COUNT(DISTINCT PC.IdDeportista)

                FROM ParticipantesCompetencia PC

                INNER JOIN CompetenciaDeporte CDP
                    ON PC.IdCompetenciaDeporte =
                       CDP.IdCompetenciaDeporte

                INNER JOIN Inscripciones I
                    ON PC.IdDeportista =
                       I.IdDeportista

                INNER JOIN EntrenadorDeporte ED
                    ON I.IdEntrenadorDeporte =
                       ED.IdEntrenadorDeporte

                WHERE
                    CDP.IdCompetencia =
                        C.IdCompetencia

                    AND PC.EstadoParticipacion =
                        'Inscrito'

                    AND I.Estado =
                        'Activo'

                    AND ED.IdEntrenador =
                        " + idEntrenador.Value + @"
            )";
            }


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

            " + campoInscritos + @" AS MisInscritos,

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

                ELSE 'Finalizada'

            END AS EstadoActual

        FROM Competencias C

        WHERE 1 = 1

        " + filtroBuscar +
                filtroDeporte +
                filtroEntrenador + @"

        ORDER BY
            C.FechaInicio DESC,
            C.NombreCompetencia;
        ";


            DataTable tabla =
                conSQL.RetornaRegistros(
                    consulta);


            if (tabla == null)
                return;


            dgvCompetencias.Rows.Clear();


            foreach (DataRow fila
                     in tabla.Rows)
            {
                string deportes =
                    fila["Deportes"] ==
                    DBNull.Value
                    ? "Sin deportes"
                    : fila["Deportes"]
                        .ToString();


                string fechaInicio =
                    Convert.ToDateTime(
                        fila["FechaInicio"])
                    .ToString("dd/MM/yyyy");


                string fechaFin =
                    Convert.ToDateTime(
                        fila["FechaFin"])
                    .ToString("dd/MM/yyyy");


                int inscritos =
                    Convert.ToInt32(
                        fila["MisInscritos"]);


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

                        deportes,

                        fechaInicio,

                        fechaFin,

                        inscritos,

                        fila["EstadoActual"]
                            .ToString()
                    );


                dgvCompetencias
                    .Rows[indice]
                    .Tag =
                    Convert.ToInt32(
                        fila["IdCompetencia"]);
            }


            dgvCompetencias.ClearSelection();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAcDes_Click(object sender, EventArgs e)
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

            frmVerParticipantes frm;

            if (esAdministrador)
            {
                frm =
                    new frmVerParticipantes(
                        idCompetencia);
            }
            else
            {
                frm =
                    new frmVerParticipantes(
                        idCompetencia,
                        idEntrenador.Value);
            }

            frm.StartPosition =
                FormStartPosition.CenterParent;

            frm.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
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

            frmRegistrarResultados frm;

            if (esAdministrador)
            {
                frm =
                    new frmRegistrarResultados(
                        idCompetencia);
            }
            else
            {
                frm =
                    new frmRegistrarResultados(
                        idCompetencia,
                        idEntrenador.Value);
            }

            frm.StartPosition =
                FormStartPosition.CenterParent;

            if (frm.ShowDialog(this) ==
                DialogResult.OK)
            {
                CargarCompetencias();
            }
        }

        private void txtBuscarCompetencia_TextChanged(object sender, EventArgs e)
        {
            CargarCompetencias();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroDeporte.SelectedValue == null || cmbFiltroDeporte.SelectedValue
        is DataRowView)
            {
                return;
            }

            CargarCompetencias();
        }
    }
}
