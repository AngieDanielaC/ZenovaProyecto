using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmGestionEmpleados : Form
    {
        // ==========================================
        // CONEXIÓN
        // ==========================================
        csConectaSQL conSQL =
            new csConectaSQL();


        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        public frmGestionEmpleados()
        {
            InitializeComponent();

            ConfigurarTablaEmpleados();

            CargarFiltros();

            CargarEmpleados();

            dgvEmpleados.ClearSelection();
        }


        // ==========================================
        // CONFIGURAR FILTROS
        // ==========================================
        private void CargarFiltros()
        {
            cmbEstado.Items.Clear();

            cmbEstado.Items.Add("Todos");
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");

            cmbEstado.SelectedIndex = 0;

            cmbEstado.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }


        // ==========================================
        // CONFIGURAR TABLA
        // ==========================================
        private void ConfigurarTablaEmpleados()
        {
            dgvEmpleados.DataSource = null;

            dgvEmpleados.Columns.Clear();

            dgvEmpleados.AutoGenerateColumns =
                false;


            // ==========================================
            // ID OCULTO
            // ==========================================
            dgvEmpleados.Columns.Add(
                "IdEmpleado",
                "ID");

            dgvEmpleados
                .Columns["IdEmpleado"]
                .DataPropertyName =
                "IdEmpleado";

            dgvEmpleados
                .Columns["IdEmpleado"]
                .Visible =
                false;


            // ==========================================
            // NOMBRE
            // ==========================================
            dgvEmpleados.Columns.Add(
                "NombreCompleto",
                "NOMBRE COMPLETO");

            dgvEmpleados
                .Columns["NombreCompleto"]
                .DataPropertyName =
                "NombreCompleto";


            // ==========================================
            // CÉDULA
            // ==========================================
            dgvEmpleados.Columns.Add(
                "Cedula",
                "CÉDULA");

            dgvEmpleados
                .Columns["Cedula"]
                .DataPropertyName =
                "Cedula";


            // ==========================================
            // TELÉFONO
            // ==========================================
            dgvEmpleados.Columns.Add(
                "Telefono",
                "TELÉFONO");

            dgvEmpleados
                .Columns["Telefono"]
                .DataPropertyName =
                "Telefono";


            // ==========================================
            // CORREO
            // ==========================================
            dgvEmpleados.Columns.Add(
                "Correo",
                "CORREO");

            dgvEmpleados
                .Columns["Correo"]
                .DataPropertyName =
                "Correo";


            // ==========================================
            // ESTADO
            // ==========================================
            dgvEmpleados.Columns.Add(
                "Estado",
                "ESTADO");

            dgvEmpleados
                .Columns["Estado"]
                .DataPropertyName =
                "Estado";


            // ==========================================
            // CONFIGURACIÓN GENERAL
            // ==========================================
            dgvEmpleados.BackgroundColor =
                Color.White;

            dgvEmpleados.BorderStyle =
                BorderStyle.None;

            dgvEmpleados.CellBorderStyle =
                DataGridViewCellBorderStyle
                .SingleHorizontal;

            dgvEmpleados.GridColor =
                Color.FromArgb(
                    235,
                    235,
                    245);

            dgvEmpleados.RowHeadersVisible =
                false;

            dgvEmpleados.AllowUserToAddRows =
                false;

            dgvEmpleados.AllowUserToDeleteRows =
                false;

            dgvEmpleados.AllowUserToResizeRows =
                false;

            dgvEmpleados.AllowUserToResizeColumns =
                false;

            dgvEmpleados.ReadOnly =
                true;

            dgvEmpleados.MultiSelect =
                false;

            dgvEmpleados.SelectionMode =
                DataGridViewSelectionMode
                .FullRowSelect;

            dgvEmpleados.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode
                .Fill;


            // ==========================================
            // ENCABEZADO
            // ==========================================
            dgvEmpleados.EnableHeadersVisualStyles =
                false;

            dgvEmpleados
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                Color.FromArgb(
                    52,
                    63,
                    221);

            dgvEmpleados
                .ColumnHeadersDefaultCellStyle
                .ForeColor =
                Color.White;

            dgvEmpleados
                .ColumnHeadersDefaultCellStyle
                .Font =
                new Font(
                    "Century Gothic",
                    10F,
                    FontStyle.Bold);

            dgvEmpleados
                .ColumnHeadersDefaultCellStyle
                .Alignment =
                DataGridViewContentAlignment
                .MiddleCenter;

            dgvEmpleados.ColumnHeadersHeight =
                50;

            dgvEmpleados
                .ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;

            dgvEmpleados
                .ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle
                .None;


            // ==========================================
            // FILAS
            // ==========================================
            dgvEmpleados.RowTemplate.Height =
                55;

            dgvEmpleados
                .DefaultCellStyle
                .BackColor =
                Color.White;

            dgvEmpleados
                .DefaultCellStyle
                .ForeColor =
                Color.FromArgb(
                    25,
                    40,
                    95);

            dgvEmpleados
                .DefaultCellStyle
                .Font =
                new Font(
                    "Century Gothic",
                    10F,
                    FontStyle.Regular);

            dgvEmpleados
                .DefaultCellStyle
                .Alignment =
                DataGridViewContentAlignment
                .MiddleCenter;

            dgvEmpleados
                .DefaultCellStyle
                .SelectionBackColor =
                Color.FromArgb(
                    235,
                    238,
                    255);

            dgvEmpleados
                .DefaultCellStyle
                .SelectionForeColor =
                Color.FromArgb(
                    25,
                    40,
                    95);


            // ==========================================
            // TAMAÑOS
            // ==========================================
            dgvEmpleados
                .Columns["NombreCompleto"]
                .FillWeight =
                140;

            dgvEmpleados
                .Columns["Cedula"]
                .FillWeight =
                80;

            dgvEmpleados
                .Columns["Telefono"]
                .FillWeight =
                80;

            dgvEmpleados
                .Columns["Correo"]
                .FillWeight =
                130;

            dgvEmpleados
                .Columns["Estado"]
                .FillWeight =
                65;


            // ==========================================
            // ALINEACIÓN
            // ==========================================
            dgvEmpleados
                .Columns["NombreCompleto"]
                .DefaultCellStyle
                .Alignment =
                DataGridViewContentAlignment
                .MiddleLeft;

            dgvEmpleados
                .Columns["Correo"]
                .DefaultCellStyle
                .Alignment =
                DataGridViewContentAlignment
                .MiddleLeft;


            dgvEmpleados.ClearSelection();
        }


        // ==========================================
        // CARGAR EMPLEADOS
        // ==========================================
        private void CargarEmpleados()
        {
            try
            {
                // ==========================================
                // BÚSQUEDA
                // ==========================================
                string buscar =
                    txtBuscar.Text.Trim();

                if (buscar.Equals(
                    "Buscar",
                    StringComparison.OrdinalIgnoreCase))
                {
                    buscar = "";
                }

                buscar =
                    buscar.Replace(
                        "'",
                        "''");


                // ==========================================
                // ESTADO
                // ==========================================
                string estado =
                    "Todos";

                if (cmbEstado.SelectedIndex > 0)
                {
                    estado =
                        cmbEstado.Text;
                }


                // ==========================================
                // FILTRO BUSCAR
                // ==========================================
                string filtroBuscar =
                    "";

                if (buscar != "")
                {
                    filtroBuscar =
                        @" AND
                        (
                            E.Nombres
                                LIKE '%" + buscar + @"%'

                            OR E.Apellidos
                                LIKE '%" + buscar + @"%'

                            OR
                            (
                                E.Nombres + ' ' +
                                E.Apellidos
                            )
                                LIKE '%" + buscar + @"%'

                            OR E.Cedula
                                LIKE '%" + buscar + @"%'

                            OR E.Telefono
                                LIKE '%" + buscar + @"%'

                            OR E.Correo
                                LIKE '%" + buscar + @"%'
                        )";
                }


                // ==========================================
                // FILTRO ESTADO
                // ==========================================
                string filtroEstado =
                    "";

                if (estado == "Activo")
                {
                    filtroEstado =
                        " AND E.Estado = 1";
                }
                else if (estado == "Inactivo")
                {
                    filtroEstado =
                        " AND E.Estado = 0";
                }


                // ==========================================
                // CONSULTA
                // ==========================================
                string consulta =
                    @"
                    SELECT
                        E.IdEmpleado,

                        E.Nombres + ' ' +
                        E.Apellidos
                            AS NombreCompleto,

                        E.Cedula,

                        E.Telefono,

                        E.Correo,

                        CASE
                            WHEN E.Estado = 1
                                THEN 'Activo'
                            ELSE
                                'Inactivo'
                        END AS Estado

                    FROM Empleados E

                    WHERE 1 = 1

                    " +
                    filtroBuscar +
                    filtroEstado +

                    @"

                    ORDER BY
                        E.Nombres,
                        E.Apellidos;
                    ";


                DataTable tabla =
                    conSQL.RetornaRegistros(
                        consulta);


                if (tabla == null)
                    return;


                dgvEmpleados.DataSource =
                    tabla;


                dgvEmpleados.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los empleados:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ==========================================
        // NUEVO EMPLEADO
        // ==========================================
        private void btnNuevo_Click(
            object sender,
            EventArgs e)
        {
            frmNuevoEmpleado frm =
        new frmNuevoEmpleado();

            frm.StartPosition =
                FormStartPosition.CenterParent;

            frm.ShowDialog(this);

            // Al cerrar, recargamos la tabla
            CargarEmpleados();
        }


        // ==========================================
        // VER
        // ==========================================
        private void btnVer_Click(
            object sender,
            EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un empleado.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            int idEmpleado =
                Convert.ToInt32(
                    dgvEmpleados
                    .CurrentRow
                    .Cells["IdEmpleado"]
                    .Value);


            frmVerEmpleado frm =
                new frmVerEmpleado(
                    idEmpleado);


            frm.StartPosition =
                FormStartPosition.CenterParent;


            frm.ShowDialog(this);
        }


        // ==========================================
        // EDITAR
        // ==========================================
        private void btnEditar_Click(
            object sender,
            EventArgs e)
        {
            if (dgvEmpleados.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un empleado.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            int idEmpleado =
                Convert.ToInt32(
                    dgvEmpleados
                    .CurrentRow
                    .Cells["IdEmpleado"]
                    .Value);


            frmNuevoEmpleado frm =
                new frmNuevoEmpleado(
                    idEmpleado);


            frm.StartPosition =
                FormStartPosition.CenterParent;


            if (frm.ShowDialog(this) ==
                DialogResult.OK)
            {
                CargarEmpleados();
            }
        }


        // ==========================================
        // ACTIVAR / DESACTIVAR
        // ==========================================
        private void btnActivarDesactivar_Click(
            object sender,
            EventArgs e)
        {
            
        }


        // ==========================================
        // BUSCAR
        // ==========================================
        private void txtBuscar_TextChanged(
            object sender,
            EventArgs e)
        {
            CargarEmpleados();
        }


        // ==========================================
        // FILTRAR ESTADO
        // ==========================================
        private void cmbEstado_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (cmbEstado.SelectedIndex ==
                -1)
            {
                return;
            }


            CargarEmpleados();
        }

        private void btnActivarDesactivar_Click_1(object sender, EventArgs e)
        {
            if (dgvEmpleados.CurrentRow ==
                null)
            {
                MessageBox.Show(
                    "Seleccione un empleado.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            int idEmpleado =
                Convert.ToInt32(
                    dgvEmpleados
                    .CurrentRow
                    .Cells["IdEmpleado"]
                    .Value);


            string nombre =
                dgvEmpleados
                .CurrentRow
                .Cells["NombreCompleto"]
                .Value
                .ToString();


            string estadoActual =
                dgvEmpleados
                .CurrentRow
                .Cells["Estado"]
                .Value
                .ToString();


            bool estaActivo =
                estadoActual ==
                "Activo";


            string accion =
                estaActivo
                ? "desactivar"
                : "activar";


            DialogResult respuesta =
                MessageBox.Show(
                    "¿Está seguro de que desea " +
                    accion +
                    " al empleado " +
                    nombre +
                    "?",
                    "ZENOVA",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


            if (respuesta !=
                DialogResult.Yes)
            {
                return;
            }


            string consulta =
                @"UPDATE Empleados
                  SET Estado = " +
                (estaActivo ? "0" : "1") +
                @" WHERE IdEmpleado = " +
                idEmpleado;


            if (conSQL.EjecutaSentenciaSRD(
                consulta))
            {
                MessageBox.Show(
                    estaActivo
                        ? "Empleado desactivado correctamente."
                        : "Empleado activado correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                CargarEmpleados();
            }
        }
    }
}
