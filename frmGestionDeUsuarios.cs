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
    public partial class frmGestionDeUsuarios : Form
    {
        public frmGestionDeUsuarios()
        {
            InitializeComponent();
            ConfigurarTablaUsuarios();
            CargarUsuarios();

            dgvUsuarios.ClearSelection();
        }
        private void ConfigurarTablaUsuarios()
        {
            // ==========================================
            // LIMPIAR COLUMNAS
            // ==========================================
            dgvUsuarios.Columns.Clear();

            // ==========================================
            // CONFIGURACIÓN GENERAL
            // ==========================================
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

            dgvUsuarios.RowTemplate.Height = 60;


            // ==========================================
            // ENCABEZADO
            // ==========================================
            dgvUsuarios.EnableHeadersVisualStyles = false;

            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 63, 221);

            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    12,
                    FontStyle.Bold
                );

            dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvUsuarios.ColumnHeadersHeight = 50;

            dgvUsuarios.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvUsuarios.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;


            // ==========================================
            // FILAS
            // ==========================================
            dgvUsuarios.DefaultCellStyle.BackColor =
                Color.White;

            dgvUsuarios.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 40, 95);

            dgvUsuarios.DefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    10,
                    FontStyle.Regular
                );

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

            frmNuevoUsuario frmSubCompetencia = new frmNuevoUsuario();

            frmSubCompetencia.TopLevel = false;
            frmSubCompetencia.FormBorderStyle = FormBorderStyle.None;
            frmSubCompetencia.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmSubCompetencia);

            frmSubCompetencia.Show();

            this.Close();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un usuario de la tabla.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idUsuario = Convert.ToInt32(
                dgvUsuarios.SelectedRows[0]
                .Cells["IdUsuario"].Value);

            frmVerUsuario verUsuario =
                new frmVerUsuario(idUsuario);

            verUsuario.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un usuario de la tabla.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idUsuario = Convert.ToInt32(
                dgvUsuarios.SelectedRows[0]
                .Cells["IdUsuario"].Value);

            frmEditarUsuariocs editar =
                new frmEditarUsuariocs(idUsuario);

            editar.ShowDialog();

            // Recargar tabla cuando cierre Editar
            CargarUsuarios();
        }

        private void btnAcDes_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un usuario de la tabla.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idUsuario = Convert.ToInt32(
                dgvUsuarios.SelectedRows[0]
                .Cells["IdUsuario"].Value);

            string nombre = dgvUsuarios.SelectedRows[0]
                .Cells["Nombre"].Value.ToString();

            string estadoActual = dgvUsuarios.SelectedRows[0]
                .Cells["Estado"].Value.ToString();


            bool estaActivo =
                estadoActual == "Activo";


            string mensaje;

            if (estaActivo)
            {
                mensaje =
                    "¿Está seguro de que desea desactivar la cuenta de " +
                    nombre + "?\n\n" +
                    "El usuario no podrá iniciar sesión mientras la cuenta esté desactivada.";
            }
            else
            {
                mensaje =
                    "¿Está seguro de que desea activar la cuenta de " +
                    nombre + "?\n\n" +
                    "El usuario podrá volver a iniciar sesión en ZENOVA.";
            }


            DialogResult respuesta =
                MessageBox.Show(
                    mensaje,
                    estaActivo
                        ? "Desactivar cuenta"
                        : "Activar cuenta",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


            if (respuesta != DialogResult.Yes)
            {
                return;
            }


            csConectaSQL conexion =
                new csConectaSQL();


            if (!conexion.abrirConexion())
            {
                return;
            }


            try
            {
                string consulta = @"
            UPDATE Usuarios
            SET EstadoCuenta = @Estado
            WHERE IdUsuario = @IdUsuario;
        ";


                SqlCommand comando =
                    new SqlCommand(
                        consulta,
                        conexion.oCon);


                comando.Parameters.AddWithValue(
                    "@Estado",
                    estaActivo ? 0 : 1);


                comando.Parameters.AddWithValue(
                    "@IdUsuario",
                    idUsuario);


                comando.ExecuteNonQuery();


                MessageBox.Show(
                    estaActivo
                        ? "La cuenta fue desactivada correctamente."
                        : "La cuenta fue activada correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                // Actualizar la tabla
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cambiar el estado de la cuenta:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un usuario de la tabla.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idUsuario = Convert.ToInt32(
                dgvUsuarios.SelectedRows[0]
                .Cells["IdUsuario"].Value);

            string nombreUsuario =
                dgvUsuarios.SelectedRows[0]
                .Cells["Usuario"].Value.ToString();

            frmRestablecerContraseña frm =
                new frmRestablecerContraseña(
                    idUsuario,
                    nombreUsuario);

            frm.ShowDialog();
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {

        }
        private void CargarUsuarios()
        {
            csConectaSQL conexion = new csConectaSQL();

            if (conexion.abrirConexion())
            {
                try
                {
                    string consulta = @"
                SELECT
                    U.IdUsuario,
                    U.Foto,
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
                ORDER BY U.Nombres, U.Apellidos;
            ";

                    SqlDataAdapter adaptador =
                        new SqlDataAdapter(consulta, conexion.oCon);

                    DataTable tabla = new DataTable();

                    adaptador.Fill(tabla);


                    // ==========================================
                    // CREAR COLUMNA VISUAL PARA LA FOTO
                    // ==========================================
                    DataColumn columnaFotoUsuario =
                        new DataColumn(
                            "FotoUsuario",
                            typeof(Image));

                    // La ponemos al principio
                    tabla.Columns.Add(columnaFotoUsuario);

                    columnaFotoUsuario.SetOrdinal(0);


                    // ==========================================
                    // CONVERTIR BYTE[] A IMAGE
                    // ==========================================
                    foreach (DataRow fila in tabla.Rows)
                    {
                        if (fila["Foto"] != DBNull.Value)
                        {
                            byte[] bytesFoto =
                                (byte[])fila["Foto"];

                            using (MemoryStream ms =
                                   new MemoryStream(bytesFoto))
                            {
                                using (Image imagen =
                                       Image.FromStream(ms))
                                {
                                    fila["FotoUsuario"] =
                                        new Bitmap(imagen);
                                }
                            }
                        }
                        else
                        {
                            fila["FotoUsuario"] =
                                DBNull.Value;
                        }
                    }


                    // ==========================================
                    // ASIGNAR DATOS
                    // ==========================================
                    dgvUsuarios.DataSource = tabla;


                    // ==========================================
                    // OCULTAR COLUMNAS INTERNAS
                    // ==========================================
                    dgvUsuarios.Columns["IdUsuario"].Visible = false;

                    dgvUsuarios.Columns["Foto"].Visible = false;


                    // ==========================================
                    // FOTO
                    // ==========================================
                    dgvUsuarios.Columns["FotoUsuario"].HeaderText =
                        "FOTO";

                    DataGridViewImageColumn columnaImagen =
                        dgvUsuarios.Columns["FotoUsuario"]
                        as DataGridViewImageColumn;

                    if (columnaImagen != null)
                    {
                        columnaImagen.ImageLayout =
                            DataGridViewImageCellLayout.Zoom;

                        columnaImagen.DefaultCellStyle.NullValue =
                            null;
                    }


                    // ==========================================
                    // ENCABEZADOS
                    // ==========================================
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


                    // ==========================================
                    // TAMAÑOS
                    // ==========================================
                    dgvUsuarios.Columns["FotoUsuario"].FillWeight = 50;

                    dgvUsuarios.Columns["Nombre"].FillWeight = 145;

                    dgvUsuarios.Columns["Usuario"].FillWeight = 85;

                    dgvUsuarios.Columns["Rol"].FillWeight = 100;

                    dgvUsuarios.Columns["Estado"].FillWeight = 85;

                    dgvUsuarios.Columns["Correo"].FillWeight = 135;


                    // ==========================================
                    // ALINEACIÓN
                    // ==========================================
                    dgvUsuarios.Columns["FotoUsuario"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;

                    dgvUsuarios.Columns["Nombre"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleLeft;

                    dgvUsuarios.Columns["Usuario"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;

                    dgvUsuarios.Columns["Rol"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;

                    dgvUsuarios.Columns["Estado"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;

                    dgvUsuarios.Columns["Correo"]
                        .DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleLeft;


                    // ==========================================
                    // ALTURA PARA QUE SE VEA LA FOTO
                    // ==========================================
                    dgvUsuarios.RowTemplate.Height = 60;

                    foreach (DataGridViewRow fila in dgvUsuarios.Rows)
                    {
                        fila.Height = 60;
                    }


                    // ==========================================
                    // QUITAR SELECCIÓN
                    // ==========================================
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
                finally
                {
                    conexion.cerrarConexion();
                }
            }
        }








        private Image BytesAImagen(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return null;
            }

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                using (Image imagen = Image.FromStream(ms))
                {
                    return new Bitmap(imagen);
                }
            }
        }

        private void btnProbarConexion_Click_1(object sender, EventArgs e)
        {

        }
    }
}
