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
        private int idUsuario;
        public frmVerUsuario(int idUsuario)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;
            CargarUsuario();
        }
        private void CargarUsuario()
        {
            csConectaSQL conexion = new csConectaSQL();

            if (conexion.abrirConexion())
            {
                try
                {
                    string consulta = @"
                SELECT
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
                    U.EstadoCuenta
                FROM Usuarios U
                INNER JOIN Roles R
                    ON U.IdRol = R.IdRol
                WHERE U.IdUsuario = @IdUsuario;
            ";

                    SqlCommand comando =
                        new SqlCommand(consulta, conexion.oCon);

                    comando.Parameters.AddWithValue(
                        "@IdUsuario",
                        idUsuario);

                    SqlDataReader lector =
                        comando.ExecuteReader();

                    if (lector.Read())
                    {
                        lblNombre.Text =
                            lector["Nombres"].ToString() + " " +
                            lector["Apellidos"].ToString();

                        lblCedula.Text =
                            lector["Cedula"].ToString();

                        lblFechaNacimiento.Text =
                            Convert.ToDateTime(
                                lector["FechaNacimiento"])
                            .ToString("dd/MM/yyyy");

                        lblGenero.Text =
                            lector["Genero"].ToString();

                        lblTelefono.Text =
                            lector["Telefono"].ToString();

                        lblCorreo.Text =
                            lector["Correo"].ToString();

                        lblDireccion.Text =
                            lector["Direccion"].ToString();

                        lblUsuario.Text =
                            lector["NombreUsuario"].ToString();

                        lblRol.Text =
                            lector["NombreRol"].ToString();


                        // ESTADO
                        bool activo =
                            Convert.ToBoolean(
                                lector["EstadoCuenta"]);

                        lblEstado.Text =
                            activo ? "Activo" : "Inactivo";


                        // FOTO
                        if (lector["Foto"] != DBNull.Value)
                        {
                            byte[] bytesFoto =
                                (byte[])lector["Foto"];

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
                        else
                        {
                            picFoto.Image = null;
                        }
                    }

                    lector.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al cargar los datos del usuario:\n\n" +
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
