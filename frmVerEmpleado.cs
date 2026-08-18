using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmVerEmpleado : Form
    {
        // ==========================================
        // VARIABLES
        // ==========================================
        private int idEmpleado;

        csConectaSQL conSQL =
            new csConectaSQL();


        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        public frmVerEmpleado(int idEmpleado)
        {
            InitializeComponent();

            this.idEmpleado =
                idEmpleado;

            ConfigurarFormulario();

            CargarEmpleado();
        }


        // ==========================================
        // CONFIGURAR FORMULARIO
        // ==========================================
        private void ConfigurarFormulario()
        {
            picFoto.SizeMode =
                PictureBoxSizeMode.Zoom;

            lblNombreCompleto.Text = "";
            lblCedula.Text = "";
            lblFechaNacimiento.Text = "";
            lblGenero.Text = "";
            lblTelefono.Text = "";
            lblCorreo.Text = "";
            lblDireccion.Text = "";
        }


        // ==========================================
        // CARGAR EMPLEADO
        // ==========================================
        private void CargarEmpleado()
        {
            try
            {
                DataTable tabla =
                    conSQL.RetornaRegistros(
                        @"SELECT
                            IdEmpleado,
                            Cedula,
                            Nombres,
                            Apellidos,
                            FechaNacimiento,
                            Genero,
                            Telefono,
                            Correo,
                            Direccion,
                            Foto,
                            Estado,
                            FechaRegistro

                          FROM Empleados

                          WHERE IdEmpleado = " +
                        idEmpleado
                    );


                if (tabla == null ||
                    tabla.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No se encontró la información del empleado.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    this.Close();

                    return;
                }


                DataRow fila =
                    tabla.Rows[0];


                // ==========================================
                // NOMBRE COMPLETO
                // ==========================================
                lblNombreCompleto.Text =
                    fila["Nombres"].ToString()
                    +
                    " "
                    +
                    fila["Apellidos"].ToString();


                // ==========================================
                // CÉDULA
                // ==========================================
                lblCedula.Text =
                    fila["Cedula"].ToString();


                // ==========================================
                // FECHA DE NACIMIENTO
                // ==========================================
                if (fila["FechaNacimiento"] !=
                    DBNull.Value)
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
                    fila["Correo"].ToString();


                // ==========================================
                // DIRECCIÓN
                // ==========================================
                lblDireccion.Text =
                    fila["Direccion"].ToString();


                // ==========================================
                // FOTO
                // ==========================================
                picFoto.Image = null;


                if (fila["Foto"] !=
                    DBNull.Value)
                {
                    try
                    {
                        byte[] bytesFoto =
                            (byte[])fila["Foto"];


                        using (MemoryStream ms =
                               new MemoryStream(
                                   bytesFoto))
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el empleado:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ==========================================
        // CERRAR
        // ==========================================
        private void btnCerrar_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }


        // ==========================================
        // MOVER VENTANA
        // ==========================================
        [DllImport(
            "user32.dll",
            EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();


        [DllImport(
            "user32.dll",
            EntryPoint = "SendMessage")]
        private static extern void SendMessage(
            IntPtr hWnd,
            int Msg,
            int wParam,
            int lParam);


        private void panel1_MouseDown(
            object sender,
            MouseEventArgs e)
        {
            ReleaseCapture();

            SendMessage(
                this.Handle,
                0x112,
                0xF012,
                0);
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
