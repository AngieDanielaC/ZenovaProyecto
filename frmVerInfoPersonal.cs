using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmVerInfoPersonal : Form
    {
        private int idDeportista;
        csConectaSQL conSQL = new csConectaSQL();

        public frmVerInfoPersonal(int idDeportista)
        {
            InitializeComponent();

            this.idDeportista = idDeportista;

            CargarInformacionPersonal();
        }
        private void CargarInformacionPersonal()
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
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
                ParentescoEmergencia,
                TelefonoEmergencia
              FROM Deportistas
              WHERE IdDeportista = " + idDeportista
                );

            if (tabla == null ||
                tabla.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró la información del deportista.",
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
            lblNombreCompleto.Text =
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
                    "No registrada";
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
            lblCorreo.Text =
                fila["Correo"] == DBNull.Value
                ? "No registrado"
                : fila["Correo"].ToString();


            // ==========================================
            // DIRECCIÓN
            // ==========================================
            lblDireccion.Text =
                fila["Direccion"].ToString();


            // ==========================================
            // CONTACTO DE EMERGENCIA
            // ==========================================
            lblNombreEmergencia.Text =
                fila["NombreContactoEmergencia"] == DBNull.Value
                ? "No registrado"
                : fila["NombreContactoEmergencia"].ToString();

            lblParentesco.Text =
                fila["ParentescoEmergencia"] == DBNull.Value
                ? "No registrado"
                : fila["ParentescoEmergencia"].ToString();

            lblTelefonoEmergencia.Text =
                fila["TelefonoEmergencia"] == DBNull.Value
                ? "No registrado"
                : fila["TelefonoEmergencia"].ToString();


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
                }
            }
            else
            {
                picFoto.Image = null;
            }
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
