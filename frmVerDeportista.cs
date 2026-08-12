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
    public partial class frmVerDeportista : Form
    {
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        private int idDeportista;
        public frmVerDeportista()
        {
            InitializeComponent();
        }
        public frmVerDeportista(int idDeportista)
        {
            InitializeComponent();

            this.idDeportista = idDeportista;

            CargarDeportista();
        }
        private void CargarDeportista()
        {
            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            SELECT
                Foto,
                Nombres,
                Apellidos,
                Cedula,
                FechaNacimiento,
                Genero,
                Telefono,
                Correo,
                Direccion,
                NombreContactoEmergencia,
                TelefonoEmergencia,
                ParentescoEmergencia
            FROM Deportistas
            WHERE IdDeportista = @IdDeportista;
        ";

                SqlCommand comando =
                    new SqlCommand(
                        consulta,
                        conexion.oCon);

                comando.Parameters.AddWithValue(
                    "@IdDeportista",
                    idDeportista);

                SqlDataReader lector =
                    comando.ExecuteReader();

                if (lector.Read())
                {
                    // =========================
                    // INFORMACIÓN PERSONAL
                    // =========================

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
                        lector["Correo"] == DBNull.Value
                        ? "No registrado"
                        : lector["Correo"].ToString();

                    lblDireccion.Text =
                        lector["Direccion"].ToString();



                    // CONTACTO DE EMERGENCIA


                    lblNombreContacto.Text =
                        lector["NombreContactoEmergencia"]
                        .ToString();

                    lblTelefonoEmergencia.Text =
                         lector["TelefonoEmergencia"]
                         .ToString();

                    lblParentesco.Text =
                        lector["ParentescoEmergencia"]
                        .ToString();

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
                else
                {
                    MessageBox.Show(
                        "No se encontró el deportista.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los datos del deportista:\n\n" +
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
