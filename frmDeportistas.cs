using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmDeportistas : Form
    {
        private int? idEntrenador;
        private bool esAdministrador;
        csConectaSQL conSQL = new csConectaSQL();

        public frmDeportistas(int idEntrenador)
        {
            InitializeComponent();

            this.idEntrenador = idEntrenador;
            esAdministrador = false;

            ConfigurarTablaDeportistas();
            CargarFiltros();
            CargarDeportistas();
        }

        public frmDeportistas()
        {
            InitializeComponent();

            esAdministrador = true;
            idEntrenador = null;

            ConfigurarTablaDeportistas();
            CargarFiltros();
            CargarDeportistas();
        }

        private void ConfigurarTablaDeportistas()
        {
            dgvDeportistas.Columns.Clear();
            dgvDeportistas.Rows.Clear();

            DataGridViewImageColumn colFoto = new DataGridViewImageColumn();
            colFoto.Name = "Foto";
            colFoto.HeaderText = "FOTO";
            colFoto.ImageLayout = DataGridViewImageCellLayout.Zoom;

            dgvDeportistas.Columns.Add(colFoto);

            dgvDeportistas.Columns.Add("Nombre", "NOMBRE");
            dgvDeportistas.Columns.Add("Edad", "EDAD");
            dgvDeportistas.Columns.Add("Deporte", "DEPORTE");
            dgvDeportistas.Columns.Add("CategoriaEdad", "CATEGORÍA (EDAD)");
            dgvDeportistas.Columns.Add("UltimaMedicion", "ÚLTIMA MEDICIÓN");

            dgvDeportistas.BackgroundColor = Color.White;
            dgvDeportistas.BorderStyle = BorderStyle.None;
            dgvDeportistas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDeportistas.GridColor = Color.FromArgb(235, 235, 245);
            dgvDeportistas.RowHeadersVisible = false;

            dgvDeportistas.AllowUserToAddRows = false;
            dgvDeportistas.AllowUserToDeleteRows = false;
            dgvDeportistas.AllowUserToResizeRows = false;
            dgvDeportistas.AllowUserToResizeColumns = false;

            dgvDeportistas.ReadOnly = true;
            dgvDeportistas.MultiSelect = false;
            dgvDeportistas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeportistas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDeportistas.EnableHeadersVisualStyles = false;
            dgvDeportistas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 55, 215);
            dgvDeportistas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDeportistas.ColumnHeadersDefaultCellStyle.Font =
                new Font("Century Gothic", 9F, FontStyle.Bold);

            dgvDeportistas.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.ColumnHeadersHeight = 45;
            dgvDeportistas.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvDeportistas.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvDeportistas.RowTemplate.Height = 55;

            dgvDeportistas.DefaultCellStyle.BackColor = Color.White;
            dgvDeportistas.DefaultCellStyle.ForeColor = Color.FromArgb(25, 40, 95);
            dgvDeportistas.DefaultCellStyle.Font =
                new Font("Century Gothic", 9F, FontStyle.Regular);

            dgvDeportistas.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvDeportistas.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 40, 95);

            dgvDeportistas.Columns["Foto"].FillWeight = 50;
            dgvDeportistas.Columns["Nombre"].FillWeight = 130;
            dgvDeportistas.Columns["Edad"].FillWeight = 55;
            dgvDeportistas.Columns["Deporte"].FillWeight = 130;
            dgvDeportistas.Columns["CategoriaEdad"].FillWeight = 100;
            dgvDeportistas.Columns["UltimaMedicion"].FillWeight = 100;

            dgvDeportistas.Columns["Nombre"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvDeportistas.Columns["Foto"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.Columns["Foto"].DefaultCellStyle.NullValue = null;

            dgvDeportistas.ClearSelection();
        }

        private void CargarDeportistas()
        {
            DataTable tabla;

            if (esAdministrador)
            {
                tabla = conSQL.RetornaRegistros(
                    @"SELECT
                        D.IdDeportista,
                        D.Foto,
                        D.Nombres + ' ' + D.Apellidos AS NombreCompleto,
                        D.FechaNacimiento,

                        (
                            SELECT MAX(M.FechaMedicion)
                            FROM MedicionesDeportista M
                            WHERE M.IdDeportista = D.IdDeportista
                        ) AS UltimaMedicion,

                        (
                            SELECT TOP 1 M.CategoriaEdad
                            FROM MedicionesDeportista M
                            WHERE M.IdDeportista = D.IdDeportista
                            ORDER BY M.FechaMedicion DESC, M.IdMedicion DESC
                        ) AS CategoriaEdad

                    FROM Deportistas D
                    WHERE D.Estado = 1
                    ORDER BY D.Nombres, D.Apellidos");
            }
            else
            {
                tabla = conSQL.RetornaRegistros(
                    @"SELECT
                        D.IdDeportista,
                        D.Foto,
                        D.Nombres + ' ' + D.Apellidos AS NombreCompleto,
                        D.FechaNacimiento,

                        (
                            SELECT MAX(M.FechaMedicion)
                            FROM MedicionesDeportista M
                            WHERE M.IdDeportista = D.IdDeportista
                        ) AS UltimaMedicion,

                        (
                            SELECT TOP 1 M.CategoriaEdad
                            FROM MedicionesDeportista M
                            WHERE M.IdDeportista = D.IdDeportista
                            ORDER BY M.FechaMedicion DESC, M.IdMedicion DESC
                        ) AS CategoriaEdad

                    FROM Deportistas D
                    WHERE D.Estado = 1

                    AND EXISTS
                    (
                        SELECT 1
                        FROM Inscripciones I
                        INNER JOIN EntrenadorDeporte ED
                            ON I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte

                        WHERE I.IdDeportista = D.IdDeportista
                        AND I.Estado = 'Activo'
                        AND ED.Activo = 1
                        AND ED.IdEntrenador = " + idEntrenador.Value + @"
                    )

                    ORDER BY D.Nombres, D.Apellidos");
            }

            if (tabla == null) return;

            dgvDeportistas.Rows.Clear();

            foreach (DataRow fila in tabla.Rows)
            {
                int idDeportista =
                    Convert.ToInt32(fila["IdDeportista"]);

                DateTime fechaNacimiento =
                    Convert.ToDateTime(fila["FechaNacimiento"]);

                int edad =
                    DateTime.Today.Year - fechaNacimiento.Year;

                if (fechaNacimiento.Date >
                    DateTime.Today.AddYears(-edad))
                {
                    edad--;
                }

                Image foto = null;

                if (fila["Foto"] != DBNull.Value)
                {
                    try
                    {
                        byte[] bytesFoto =
                            (byte[])fila["Foto"];

                        using (MemoryStream ms =
                               new MemoryStream(bytesFoto))
                        {
                            using (Image imagen =
                                   Image.FromStream(ms))
                            {
                                foto =
                                    new Bitmap(imagen);
                            }
                        }
                    }
                    catch
                    {
                        foto = null;
                    }
                }

                string deportes =
                    ObtenerDeportesDeportista(idDeportista);

                string categoriaEdad =
                    fila["CategoriaEdad"] == DBNull.Value
                    ? "Sin medición"
                    : fila["CategoriaEdad"].ToString();

                string ultimaMedicion =
                    fila["UltimaMedicion"] == DBNull.Value
                    ? "Sin mediciones"
                    : Convert.ToDateTime(
                        fila["UltimaMedicion"])
                      .ToString("dd/MM/yyyy");

                int indice =
                    dgvDeportistas.Rows.Add(
                        foto,
                        fila["NombreCompleto"].ToString(),
                        edad,
                        deportes,
                        categoriaEdad,
                        ultimaMedicion
                    );

                dgvDeportistas.Rows[indice].Tag =
                    idDeportista;
            }

            dgvDeportistas.ClearSelection();
        }

        private string ObtenerDeportesDeportista(int idDeportista)
        {
            string query;

            if (esAdministrador)
            {
                query =
                    @"SELECT DISTINCT DEP.NombreDeporte
                      FROM Inscripciones I
                      INNER JOIN EntrenadorDeporte ED
                          ON I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte
                      INNER JOIN Deportes DEP
                          ON ED.IdDeporte = DEP.IdDeporte
                      WHERE I.IdDeportista = " + idDeportista + @"
                      AND I.Estado = 'Activo'
                      AND ED.Activo = 1
                      ORDER BY DEP.NombreDeporte";
            }
            else
            {
                query =
                    @"SELECT DISTINCT DEP.NombreDeporte
                      FROM Inscripciones I
                      INNER JOIN EntrenadorDeporte ED
                          ON I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte
                      INNER JOIN Deportes DEP
                          ON ED.IdDeporte = DEP.IdDeporte
                      WHERE I.IdDeportista = " + idDeportista + @"
                      AND I.Estado = 'Activo'
                      AND ED.Activo = 1
                      AND ED.IdEntrenador = " + idEntrenador.Value + @"
                      ORDER BY DEP.NombreDeporte";
            }

            DataTable tablaDeportes =
                conSQL.RetornaRegistros(query);

            if (tablaDeportes == null ||
                tablaDeportes.Rows.Count == 0)
            {
                return "Sin asignar";
            }

            string deportes = "";

            foreach (DataRow fila in tablaDeportes.Rows)
            {
                if (deportes != "")
                    deportes += ", ";

                deportes +=
                    fila["NombreDeporte"].ToString();
            }

            return deportes;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dgvDeportistas.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un deportista.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idDeportista =
                Convert.ToInt32(
                    dgvDeportistas.CurrentRow.Tag);

            frmVerInfoPersonal frm =
                new frmVerInfoPersonal(idDeportista);

            frm.ShowDialog();
        }

        private void btnDatosDeportivos_Click(object sender, EventArgs e)
        {
            if (dgvDeportistas.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un deportista.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idDeportista =
                Convert.ToInt32(
                    dgvDeportistas.CurrentRow.Tag);

            frmDatosDeportivos frm =
                new frmDatosDeportivos(idDeportista);

            frm.ShowDialog();

            CargarDeportistas();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (dgvDeportistas.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un deportista.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idDeportista =
                Convert.ToInt32(
                    dgvDeportistas.CurrentRow.Tag);

            frmHistorialMediciones frm =
                new frmHistorialMediciones(idDeportista);

            frm.ShowDialog();
        }

        private void CargarFiltros()
        {
            DataTable tablaDeportes;

            if (esAdministrador)
            {
                tablaDeportes =
                    conSQL.RetornaRegistros(
                        @"SELECT
                            IdDeporte,
                            NombreDeporte
                          FROM Deportes
                          WHERE Activo = 1
                          ORDER BY NombreDeporte");
            }
            else
            {
                tablaDeportes =
                    conSQL.RetornaRegistros(
                        @"SELECT DISTINCT
                            D.IdDeporte,
                            D.NombreDeporte
                          FROM Deportes D
                          INNER JOIN EntrenadorDeporte ED
                              ON D.IdDeporte = ED.IdDeporte
                          WHERE D.Activo = 1
                          AND ED.Activo = 1
                          AND ED.IdEntrenador = " +
                          idEntrenador.Value +
                          @" ORDER BY D.NombreDeporte");
            }

            if (tablaDeportes != null)
            {
                DataRow filaTodos =
                    tablaDeportes.NewRow();

                filaTodos["IdDeporte"] = 0;
                filaTodos["NombreDeporte"] = "Todos";

                tablaDeportes.Rows.InsertAt(
                    filaTodos,
                    0);

                cmbFiltroDeporte.DataSource =
                    tablaDeportes;

                cmbFiltroDeporte.DisplayMember =
                    "NombreDeporte";

                cmbFiltroDeporte.ValueMember =
                    "IdDeporte";

                cmbFiltroDeporte.SelectedIndex = 0;

                cmbFiltroDeporte.DropDownStyle =
                    ComboBoxStyle.DropDownList;
            }

            cmbFiltroEstado.Items.Clear();
            cmbFiltroEstado.Items.Add("Todos");
            cmbFiltroEstado.Items.Add("Activo");
            cmbFiltroEstado.Items.Add("Inactivo");

            cmbFiltroEstado.SelectedIndex = 0;
            cmbFiltroEstado.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }

        private void AplicarFiltros()
        {
            string buscar =
                txtBuscarDeportista.Text
                .Trim()
                .ToLower();

            string deporte =
                cmbFiltroDeporte.SelectedIndex <= 0
                ? "Todos"
                : cmbFiltroDeporte.Text;

            string estado =
                cmbFiltroEstado.SelectedIndex <= 0
                ? "Todos"
                : cmbFiltroEstado.Text;

            foreach (DataGridViewRow fila
                     in dgvDeportistas.Rows)
            {
                if (fila.IsNewRow)
                    continue;

                string nombre =
                    fila.Cells["Nombre"]
                    .Value?.ToString()
                    .ToLower() ?? "";

                string deportesFila =
                    fila.Cells["Deporte"]
                    .Value?.ToString() ?? "";

                bool cumpleBusqueda =
                    buscar == "" ||
                    nombre.Contains(buscar);

                bool cumpleDeporte =
                    deporte == "Todos" ||
                    deportesFila.Contains(deporte);

                bool cumpleEstado =
                    estado == "Todos" ||
                    estado == "Activo";

                fila.Visible =
                    cumpleBusqueda &&
                    cumpleDeporte &&
                    cumpleEstado;
            }

            dgvDeportistas.ClearSelection();
        }

        private void txtBuscarDeportista_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cmbFiltroDeporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroDeporte.SelectedIndex == -1)
                return;

            AplicarFiltros();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltroEstado.SelectedIndex == -1)
                return;

            AplicarFiltros();
        }
    }
}