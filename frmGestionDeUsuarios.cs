using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmGestionDeUsuarios : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        public frmGestionDeUsuarios()
        {
            InitializeComponent();

            ConfigurarTablaUsuarios();

            CargarFiltros();

            CargarUsuarios();

            dgvUsuarios.ClearSelection();
        }

        private void CargarFiltros()
        {

            DataTable tablaRoles = conSQL.RetornaRegistros(
                    @"SELECT IdRol, NombreRol
                      FROM Roles
                      WHERE Activo = 1
                      ORDER BY NombreRol"
                );
            if (tablaRoles != null)
            {
                DataRow todos = tablaRoles.NewRow();
                todos["IdRol"] = 0;
                todos["NombreRol"] = "Todos";
                tablaRoles.Rows.InsertAt(todos,0);
                cmbRol.DataSource = tablaRoles;
                cmbRol.DisplayMember ="NombreRol";
                cmbRol.ValueMember ="IdRol";
                cmbRol.SelectedIndex =0;
                cmbRol.DropDownStyle =ComboBoxStyle.DropDownList;
            }

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Todos");
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            cmbEstado.SelectedIndex =0;
            cmbEstado.DropDownStyle =ComboBoxStyle.DropDownList;
        }
        private void ConfigurarTablaUsuarios()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.Columns.Clear();
            dgvUsuarios.AutoGenerateColumns = false;

            dgvUsuarios.Columns.Add( "IdUsuario", "ID");
            dgvUsuarios.Columns["IdUsuario"].DataPropertyName = "IdUsuario";
            dgvUsuarios.Columns["IdUsuario"].Visible = false;


            dgvUsuarios.Columns.Add( "Nombre", "NOMBRE");
            dgvUsuarios.Columns["Nombre"].DataPropertyName ="Nombre";

            dgvUsuarios.Columns.Add( "Usuario", "USUARIO");
            dgvUsuarios.Columns["Usuario"].DataPropertyName = "Usuario";

            dgvUsuarios.Columns.Add("Rol","ROL");
            dgvUsuarios.Columns["Rol"].DataPropertyName ="Rol";

            dgvUsuarios.Columns.Add("Estado","ESTADO");
            dgvUsuarios.Columns["Estado"].DataPropertyName ="Estado";


            dgvUsuarios.BackgroundColor =Color.White;
            dgvUsuarios.BorderStyle =BorderStyle.None;
            dgvUsuarios.CellBorderStyle =DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsuarios.GridColor =Color.FromArgb(235,235,245);
            dgvUsuarios.RowHeadersVisible =false;
            dgvUsuarios.AllowUserToAddRows =false;
            dgvUsuarios.AllowUserToDeleteRows =false;
            dgvUsuarios.AllowUserToResizeRows =false;
            dgvUsuarios.AllowUserToResizeColumns =false;
            dgvUsuarios.ReadOnly =true;
            dgvUsuarios.MultiSelect =false;
            dgvUsuarios.SelectionMode =DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.Fill;

            dgvUsuarios.EnableHeadersVisualStyles =false;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52,63,221);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor =Color.White;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font =new Font("Century Gothic",10F,FontStyle.Bold);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvUsuarios.ColumnHeadersHeight = 50;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvUsuarios.ColumnHeadersBorderStyle =DataGridViewHeaderBorderStyle.None;


            dgvUsuarios.RowTemplate.Height = 55;

            dgvUsuarios.DefaultCellStyle.BackColor =Color.White;

            dgvUsuarios.DefaultCellStyle.ForeColor =Color.FromArgb(25,40,95);

            dgvUsuarios.DefaultCellStyle.Font =new Font("Century Gothic",10F,FontStyle.Regular);
            dgvUsuarios.DefaultCellStyle.Alignment =DataGridViewContentAlignment.MiddleCenter;
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb( 235,238,255);

            dgvUsuarios.DefaultCellStyle.SelectionForeColor =Color.FromArgb(25,40,95);

            dgvUsuarios.Columns["Nombre"].FillWeight =150;

            dgvUsuarios.Columns["Usuario"].FillWeight =100;

            dgvUsuarios.Columns["Rol"].FillWeight =100;

            dgvUsuarios.Columns["Estado"].FillWeight =75;


            dgvUsuarios.Columns["Nombre"].DefaultCellStyle.Alignment =DataGridViewContentAlignment.MiddleLeft;
            dgvUsuarios.ClearSelection();
        }


        private void CargarUsuarios()
        {
            try
            {

                string buscar = txtBuscar.Text.Trim();


                if (buscar.Equals("Buscar",StringComparison.OrdinalIgnoreCase))
                {
                    buscar = "";
                }


                buscar =buscar.Replace("'","''");


                int idRol = 0;


                if (cmbRol.SelectedValue != null &&!(cmbRol.SelectedValue is DataRowView))
                {
                    idRol =Convert.ToInt32(cmbRol.SelectedValue);
                }



                string estado = "Todos";


                if (cmbEstado.SelectedIndex > 0)
                {
                    estado = cmbEstado.Text;
                }


                string filtroBuscar ="";


                if (buscar != "")
                {
                    filtroBuscar =
                        @" AND (
                            ISNULL(EMP.Nombres + ' ' + EMP.Apellidos, ENT.Nombres + ' ' + ENT.Apellidos) LIKE '%" + buscar + @"%'
                            OR U.NombreUsuario LIKE '%" + buscar + @"%'
                            OR R.NombreRol LIKE '%" + buscar + @"%'
                                )";
                }

                string filtroRol = "";

                if (idRol > 0)
                {
                    filtroRol = " AND U.IdRol = " + idRol;
                }


                string filtroEstado = "";


                if (estado == "Activo")
                {
                    filtroEstado = " AND U.EstadoCuenta = 1";
                }
                else if (estado == "Inactivo")
                {
                    filtroEstado = " AND U.EstadoCuenta = 0";
                }


                string consulta =
                    @"
                     SELECT U.IdUsuario,
                        CASE
                            WHEN U.IdEmpleado IS NOT NULL THEN CONCAT(EMP.Nombres, ' ', EMP.Apellidos)
                            WHEN U.IdEntrenador IS NOT NULL THEN CONCAT(ENT.Nombres, ' ', ENT.Apellidos)
                            ELSE U.NombreUsuario
                        END AS Nombre,
                        U.NombreUsuario AS Usuario,
                        R.NombreRol AS Rol,
                        CASE
                            WHEN U.EstadoCuenta = 1 THEN 'Activo'
                            ELSE 'Inactivo'
                        END AS Estado
                    FROM Usuarios U
                    INNER JOIN Roles R ON U.IdRol = R.IdRol
                    LEFT JOIN Empleados EMP ON U.IdEmpleado = EMP.IdEmpleado
                    LEFT JOIN Entrenadores ENT ON U.IdEntrenador = ENT.IdEntrenador
                    WHERE 1 = 1
                    " +
                    filtroBuscar +
                    filtroRol +
                    filtroEstado +
                    @"
                    ORDER BY Nombre;
                    ";
                DataTable tabla = conSQL.RetornaRegistros(consulta);

                if (tabla == null)
                    return;


                dgvUsuarios.DataSource = tabla;
                dgvUsuarios.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los usuarios:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void btnNuevoUsuario_Click( object sender, EventArgs e)
        {
            frmNuevoUsuario frm = new frmNuevoUsuario();


            frm.StartPosition =FormStartPosition.CenterParent;


            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                CargarUsuarios();
            }
        }


        private void btnVer_Click(object sender,EventArgs e)
        {
        }


        private void btnActivarDesactivar_Click(object sender,EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idUsuario = Convert.ToInt32( dgvUsuarios.CurrentRow.Cells["IdUsuario"].Value);


            string nombre = dgvUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();


            string estadoActual =dgvUsuarios.CurrentRow.Cells["Estado"].Value.ToString();


            bool estaActivo = estadoActual == "Activo";


            string accion = estaActivo? "desactivar": "activar";


            DialogResult respuesta =
                MessageBox.Show(
                    "¿Está seguro de que desea " +
                    accion +
                    " la cuenta de " +
                    nombre +
                    "?",
                    "ZENOVA",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


            if (respuesta != DialogResult.Yes)
            {
                return;
            }


            string consulta =
                @"UPDATE Usuarios
                  SET EstadoCuenta = " + (estaActivo ? "0" : "1") +
                @" WHERE IdUsuario = " +idUsuario;


            if (conSQL.EjecutaSentenciaSRD(consulta))
            {
                MessageBox.Show(
                    estaActivo
                        ? "Cuenta desactivada correctamente."
                        : "Cuenta activada correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                CargarUsuarios();
            }
        }


        private void btnRestablecer_Click(object sender,EventArgs e)
        {
            if (dgvUsuarios.CurrentRow ==null)
            {
                MessageBox.Show(
                    "Seleccione un usuario.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            int idUsuario =  Convert.ToInt32( dgvUsuarios.CurrentRow.Cells["IdUsuario"].Value);
            string nombreUsuario = dgvUsuarios.CurrentRow.Cells["Usuario"].Value.ToString();


            frmRestablecerContraseña frm =new frmRestablecerContraseña(idUsuario,nombreUsuario);

            frm.StartPosition =FormStartPosition.CenterParent;
            frm.ShowDialog(this);
        }



        private void txtBuscar_TextChanged(object sender,EventArgs e)
        {
            CargarUsuarios();
        }


        private void cmbRol_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (cmbRol.SelectedValue == null || cmbRol.SelectedValue is DataRowView)
            {
                return;
            }
            CargarUsuarios();
        }



        private void cmbEstado_SelectedIndexChanged( object sender,EventArgs e)
        {
            if (cmbEstado.SelectedIndex == -1)
            {
                return;
            }
            CargarUsuarios();
        }
    }
}