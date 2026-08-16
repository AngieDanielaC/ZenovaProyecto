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
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                U.IdUsuario,
                U.Nombres + ' ' + U.Apellidos AS Nombre,
                U.NombreUsuario AS Usuario,
                R.NombreRol AS Rol,
                CASE
                    WHEN U.EstadoCuenta = 1 THEN 'Activo'
                    ELSE 'Inactivo'
                END AS Estado,
                U.Correo
              FROM Usuarios U
              INNER JOIN Roles R
                  ON U.IdRol = R.IdRol
              ORDER BY U.Nombres, U.Apellidos"
                );

            if (tabla == null)
                return;

            dgvUsuarios.DataSource = tabla;

            dgvUsuarios.Columns["IdUsuario"].Visible = false;

            dgvUsuarios.Columns["Nombre"].HeaderText =
                "NOMBRE COMPLETO";

            dgvUsuarios.Columns["Usuario"].HeaderText =
                "USUARIO";

            dgvUsuarios.Columns["Rol"].HeaderText =
                "ROL";

            dgvUsuarios.Columns["Estado"].HeaderText =
                "ESTADO";

            dgvUsuarios.Columns["Correo"].HeaderText =
                "CORREO ELECTRÓNICO";

            dgvUsuarios.Columns["Nombre"].FillWeight = 150;
            dgvUsuarios.Columns["Usuario"].FillWeight = 90;
            dgvUsuarios.Columns["Rol"].FillWeight = 110;
            dgvUsuarios.Columns["Estado"].FillWeight = 80;
            dgvUsuarios.Columns["Correo"].FillWeight = 150;

            dgvUsuarios.Columns["Nombre"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvUsuarios.Columns["Correo"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvUsuarios.ClearSelection();
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
    }
}
