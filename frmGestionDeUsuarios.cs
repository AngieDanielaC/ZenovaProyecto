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
using System.Security.Cryptography;
using System.Diagnostics;

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
            // ==========================================
            // ROLES
            // ==========================================
            DataTable tablaRoles =
                conSQL.RetornaRegistros(
                    @"SELECT
                IdRol,
                NombreRol
              FROM Roles
              WHERE Activo = 1
              ORDER BY NombreRol"
                );

            if (tablaRoles != null)
            {
                DataRow filaTodos =
                    tablaRoles.NewRow();

                filaTodos["IdRol"] = 0;
                filaTodos["NombreRol"] = "Todos";

                tablaRoles.Rows.InsertAt(
                    filaTodos,
                    0);

                cmbRol.DataSource =
                    tablaRoles;

                cmbRol.DisplayMember =
                    "NombreRol";

                cmbRol.ValueMember =
                    "IdRol";

                cmbRol.SelectedIndex = 0;

                cmbRol.DropDownStyle =
                    ComboBoxStyle.DropDownList;
            }


            // ==========================================
            // ESTADO
            // ==========================================
            cmbEstado.Items.Clear();

            cmbEstado.Items.Add("Todos");
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");

            cmbEstado.SelectedIndex = 0;

            cmbEstado.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }
        private void CargarUsuarios()
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
                    buscar.Replace("'", "''");


                // ==========================================
                // ROL
                // ==========================================
                int idRol = 0;

                if (cmbRol.SelectedValue != null &&
                    !(cmbRol.SelectedValue is DataRowView))
                {
                    idRol =
                        Convert.ToInt32(
                            cmbRol.SelectedValue);
                }


                // ==========================================
                // ESTADO
                // ==========================================
                string estado = "Todos";

                if (cmbEstado.SelectedIndex > 0)
                {
                    estado =
                        cmbEstado.Text;
                }


                // ==========================================
                // FILTRO DE BÚSQUEDA
                // ==========================================
                string filtroBuscar = "";

                if (buscar != "")
                {
                    filtroBuscar =
                        @" AND
                (
                    U.Nombres LIKE '%" + buscar + @"%'
                    OR U.Apellidos LIKE '%" + buscar + @"%'
                    OR
                    (
                        U.Nombres + ' ' +
                        U.Apellidos
                    ) LIKE '%" + buscar + @"%'
                    OR U.NombreUsuario LIKE '%" + buscar + @"%'
                    OR U.Correo LIKE '%" + buscar + @"%'
                    OR U.Cedula LIKE '%" + buscar + @"%'
                )";
                }


                // ==========================================
                // FILTRO DE ROL
                // ==========================================
                string filtroRol = "";

                if (idRol > 0)
                {
                    filtroRol =
                        " AND U.IdRol = " +
                        idRol;
                }


                // ==========================================
                // FILTRO DE ESTADO
                // ==========================================
                string filtroEstado = "";

                if (estado == "Activo")
                {
                    filtroEstado =
                        " AND U.EstadoCuenta = 1";
                }
                else if (estado == "Inactivo")
                {
                    filtroEstado =
                        " AND U.EstadoCuenta = 0";
                }


                // ==========================================
                // CONSULTA
                // SIN FOTO
                // ==========================================
                string consulta =
                    @"SELECT
                U.IdUsuario,

                U.Nombres + ' ' +
                U.Apellidos AS Nombre,

                U.NombreUsuario AS Usuario,

                R.NombreRol AS Rol,

                CASE
                    WHEN U.EstadoCuenta = 1
                        THEN 'Activo'
                    ELSE
                        'Inactivo'
                END AS Estado,

                U.Correo

              FROM Usuarios U

              INNER JOIN Roles R
                  ON U.IdRol = R.IdRol

              WHERE 1 = 1 " +

                      filtroBuscar +
                      filtroRol +
                      filtroEstado +

                      @" ORDER BY
                    U.Nombres,
                    U.Apellidos";


                DataTable tabla =
                    conSQL.RetornaRegistros(
                        consulta);


                if (tabla == null)
                    return;


                // ==========================================
                // MOSTRAR
                // ==========================================
                dgvUsuarios.DataSource =
                    tabla;


                // ==========================================
                // OCULTAR ID
                // ==========================================
                if (dgvUsuarios.Columns[
                    "IdUsuario"] != null)
                {
                    dgvUsuarios.Columns[
                        "IdUsuario"]
                        .Visible = false;
                }


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
        private void CargarFotosUsuarios()
        {
            foreach (DataGridViewRow fila in dgvUsuarios.Rows)
            {
                int idUsuario =
                    Convert.ToInt32(
                        fila.Cells["IdUsuario"].Value);

                DataTable tablaFoto =
                    conSQL.RetornaRegistros(
                        "SELECT Foto " +
                        "FROM Usuarios " +
                        "WHERE IdUsuario = " +
                        idUsuario
                    );

                if (tablaFoto == null ||
                    tablaFoto.Rows.Count == 0)
                {
                    continue;
                }

                if (tablaFoto.Rows[0]["Foto"] ==
                    DBNull.Value)
                {
                    continue;
                }

                try
                {
                    byte[] bytesFoto =
                        (byte[])tablaFoto.Rows[0]["Foto"];

                    using (MemoryStream ms =
                           new MemoryStream(bytesFoto))
                    {
                        using (Image imagen =
                               Image.FromStream(ms))
                        {
                            fila.Cells["FotoUsuario"].Value =
                                new Bitmap(
                                    imagen,
                                    new Size(45, 45));
                        }
                    }
                }
                catch
                {
                    fila.Cells["FotoUsuario"].Value =
                        null;
                }
            }
        }

        private void ConfigurarTablaUsuarios()
        {
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.BorderStyle = BorderStyle.None;

            dgvUsuarios.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvUsuarios.GridColor =
                Color.FromArgb(235, 235, 245);

            dgvUsuarios.RowHeadersVisible = false;

            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.AllowUserToResizeColumns = false;

            dgvUsuarios.ReadOnly = true;

            dgvUsuarios.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvUsuarios.MultiSelect = false;

            dgvUsuarios.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvUsuarios.RowTemplate.Height = 55;


            // ENCABEZADO
            dgvUsuarios.EnableHeadersVisualStyles = false;

            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 63, 221);

            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    11F,
                    FontStyle.Bold);

            dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvUsuarios.ColumnHeadersHeight = 50;

            dgvUsuarios.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvUsuarios.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;


            // FILAS
            dgvUsuarios.DefaultCellStyle.BackColor =
                Color.White;

            dgvUsuarios.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 40, 95);

            dgvUsuarios.DefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    10F,
                    FontStyle.Regular);

            dgvUsuarios.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvUsuarios.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvUsuarios.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 40, 95);
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmNuevoUsuario frm = new frmNuevoUsuario();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frm);

            frm.Show();

            this.Close();
        }

        private void btnVer_Click(object sender, EventArgs e)
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

            int idUsuario =Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["IdUsuario"].Value);

            frmVerUsuario frm =new frmVerUsuario(idUsuario);

            frm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario de la tabla.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idUsuario =
                Convert.ToInt32(
                    dgvUsuarios.CurrentRow
                    .Cells["IdUsuario"].Value);

            frmEditarUsuariocs frm = new frmEditarUsuariocs(idUsuario);

            frm.ShowDialog();

            // Actualizar tabla al cerrar
            CargarUsuarios();

            dgvUsuarios.ClearSelection();
        }

        private void btnAcDes_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario de la tabla.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idUsuario =
                Convert.ToInt32(
                    dgvUsuarios.CurrentRow
                    .Cells["IdUsuario"].Value);

            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT EstadoCuenta, Nombres, Apellidos
              FROM Usuarios
              WHERE IdUsuario = " + idUsuario
                );

            if (tabla == null || tabla.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró el usuario.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            bool estadoActual =
                Convert.ToBoolean(
                    tabla.Rows[0]["EstadoCuenta"]);

            string nombreCompleto =
                tabla.Rows[0]["Nombres"].ToString() +
                " " +
                tabla.Rows[0]["Apellidos"].ToString();

            string accion =
                estadoActual
                ? "desactivar"
                : "activar";

            DialogResult respuesta =
                MessageBox.Show(
                    "¿Está seguro de que desea " +
                    accion +
                    " al usuario " +
                    nombreCompleto + "?",
                    "ZENOVA",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            int nuevoEstado =
                estadoActual ? 0 : 1;

            string sentencia =
                "UPDATE Usuarios " +
                "SET EstadoCuenta = " +
                nuevoEstado +
                " WHERE IdUsuario = " +
                idUsuario;

            if (conSQL.EjecutaSentenciaSRD(sentencia))
            {
                MessageBox.Show(
                    "Usuario " +
                    (nuevoEstado == 1
                        ? "activado"
                        : "desactivado") +
                    " correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarUsuarios();

                dgvUsuarios.ClearSelection();
            }
        }
        
        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione un usuario de la tabla.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idUsuario =
                Convert.ToInt32(
                    dgvUsuarios.CurrentRow
                    .Cells["IdUsuario"].Value);

            string nombreUsuario =
                dgvUsuarios.CurrentRow
                .Cells["USUARIO"]
                .Value.ToString();

            frmRestablecerContraseña frm = new frmRestablecerContraseña(idUsuario,nombreUsuario);

            frm.ShowDialog();
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRol.SelectedValue == null ||
        cmbRol.SelectedValue is DataRowView)
            {
                return;
            }

            CargarUsuarios();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstado.SelectedIndex == -1)
                return;

            CargarUsuarios();
        }
    }
}
