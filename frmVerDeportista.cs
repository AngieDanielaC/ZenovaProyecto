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

        private csConectaSQL conSQL = new csConectaSQL();
        private int idDeportista;

        public frmVerDeportista()
        {
            InitializeComponent();
        }
        public frmVerDeportista(int idDeportista): this()
        {
            this.idDeportista = idDeportista;
        }

        private void CargarDatosDeportista()
        {
            string consulta =
                "select Nombres, Apellidos, Cedula, " +
                "FechaNacimiento, Genero, Telefono, " +
                "Correo, Direccion, Foto, " +
                "NombreContactoEmergencia, " +
               "TelefonoEmergencia, ParentescoEmergencia, " +
                "Estado, MotivoDesactivacion, FechaDesactivacion " +
               "from Deportistas " + "where IdDeportista = " + idDeportista;

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos == null)
                return;

            if (datos.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró el deportista.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                this.Close();
                return;
            }

            DataRow fila = datos.Rows[0];

            lblNombre.Text =
                fila["Nombres"].ToString() + " " +
                fila["Apellidos"].ToString();

            lblCedula.Text = fila["Cedula"].ToString();

            lblFechaNacimiento.Text = Convert.ToDateTime(
                    fila["FechaNacimiento"])
                .ToString("dd/MM/yyyy");

            lblGenero.Text = fila["Genero"].ToString();

            lblTelefono.Text = fila["Telefono"].ToString();

            lblCorreo.Text = fila["Correo"] == DBNull.Value
                ? "No registrado"
                : fila["Correo"].ToString();

            lblDireccion.Text = fila["Direccion"].ToString();

            lblNombreContacto.Text = fila["NombreContactoEmergencia"].ToString();

            lblTelefonoEmergencia.Text = fila["TelefonoEmergencia"].ToString();

            lblParentesco.Text = fila["ParentescoEmergencia"].ToString();
            bool estaActivo = Convert.ToBoolean(fila["Estado"]);

            lblEstado.Text =
                estaActivo ? "Activo" : "Inactivo";

            lblEstado.ForeColor =
                estaActivo ? Color.SeaGreen : Color.Firebrick;

            if (estaActivo)
            {
                lblMotivoDesactivacion.Text ="No aplica";

                lblFechaDesactivacion.Text = "No aplica";
            }
            else
            {
                string motivo = fila["MotivoDesactivacion"] == DBNull.Value ? "" : fila["MotivoDesactivacion"].ToString();

                lblMotivoDesactivacion.Text =  string.IsNullOrWhiteSpace(motivo) ? "Sin motivo registrado" : motivo;

                lblFechaDesactivacion.Text = fila["FechaDesactivacion"] == DBNull.Value? "No registrada"
                    : Convert.ToDateTime(fila["FechaDesactivacion"]).ToString("dd/MM/yyyy HH:mm");
            }

            if (fila["Foto"] != DBNull.Value)
            {
                byte[] foto = (byte[])fila["Foto"];

                if (foto.Length > 0)
                {
                    using (MemoryStream memoria =
                        new MemoryStream(foto))
                    using (Image imagen =
                        Image.FromStream(memoria))
                    {
                        picFoto.Image =
                            new Bitmap(imagen);
                    }
                }
            }

            picFoto.SizeMode =
                PictureBoxSizeMode.Zoom;
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

        private void frmVerDeportista_Load(object sender, EventArgs e)
        {
            CargarDatosDeportista();
        }
    }
}
