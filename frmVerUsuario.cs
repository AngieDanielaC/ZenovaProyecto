using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmVerUsuario : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        private int idUsuario;
        public frmVerUsuario(int idUsuario)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;

            CargarUsuario();
        }

        private void CargarUsuario()
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                U.Foto,
                U.Nombres,
                U.Apellidos,
                U.Cedula,
                U.FechaNacimiento,
                U.Genero,
                U.Telefono,
                U.Correo,
                U.Direccion,
                U.NombreUsuario,
                R.NombreRol,
                CASE
                    WHEN U.EstadoCuenta = 1 THEN 'Activo'
                    ELSE 'Inactivo'
                END AS Estado
              FROM Usuarios U
              INNER JOIN Roles R
                  ON U.IdRol = R.IdRol
              WHERE U.IdUsuario = " + idUsuario
                );

            if (tabla == null ||
                tabla.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró el usuario.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRow fila =
                tabla.Rows[0];


            // ==========================================
            // NOMBRE COMPLETO
            // ==========================================
            lblNombre.Text =
                fila["Nombres"].ToString() +
                " " +
                fila["Apellidos"].ToString();


            // ==========================================
            // CÉDULA
            // ==========================================
            lblCedula.Text =
                fila["Cedula"].ToString();


            // ==========================================
            // FECHA DE NACIMIENTO
            // ==========================================
            if (fila["FechaNacimiento"] != DBNull.Value)
            {
                lblFechaNacimiento.Text =
                    Convert.ToDateTime(
                        fila["FechaNacimiento"])
                    .ToString("dd/MM/yyyy");
            }
            else
            {
                lblFechaNacimiento.Text =
                    "No disponible";
            }


            // ==========================================
            // GÉNERO
            // ==========================================
            lblGenero.Text =
                fila["Genero"].ToString();


            // ==========================================
            // TELÉFONO
            // ==========================================
            lblTelefono.Text =
                fila["Telefono"].ToString();


            // ==========================================
            // CORREO
            // ==========================================
            if (fila["Correo"] != DBNull.Value)
            {
                lblCorreo.Text =
                    fila["Correo"].ToString();
            }
            else
            {
                lblCorreo.Text =
                    "No registrado";
            }


            // ==========================================
            // DIRECCIÓN
            // ==========================================
            lblDireccion.Text =
                fila["Direccion"].ToString();


            // ==========================================
            // USUARIO
            // ==========================================
            lblUsuario.Text =
                fila["NombreUsuario"].ToString();


            // ==========================================
            // ROL
            // ==========================================
            lblRol.Text =
                fila["NombreRol"].ToString();


            // ==========================================
            // ESTADO
            // ==========================================
            lblEstado.Text =
                fila["Estado"].ToString();


            // ==========================================
            // FOTO
            // ==========================================
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
                            picFoto.Image =
                                new Bitmap(imagen);
                        }
                    }

                    picFoto.SizeMode =
                        PictureBoxSizeMode.Zoom;
                }
                catch
                {
                    picFoto.Image = null;

                    MessageBox.Show(
                        "La foto del usuario no pudo cargarse.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            else
            {
                picFoto.Image = null;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }
    }
}
