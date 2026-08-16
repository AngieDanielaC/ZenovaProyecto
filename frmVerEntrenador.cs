using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmVerEntrenador : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        private int idEntrenador;
        public frmVerEntrenador(int idEntrenador)
        {
            InitializeComponent();
            this.idEntrenador = idEntrenador;

            CargarEntrenador();
        }
        private void CargarEntrenador()
        {
            string query = $@"
        SELECT 
            (Nombres + ' ' + Apellidos) AS NombreCompleto,
            Cedula,
            CONVERT(VARCHAR, FechaNacimiento, 103) AS FechaNacimiento,
            Genero,
            Telefono,
            Correo,
            Direccion,
            ISNULL(EstadoEntrenador, 'Inactivo') AS EstadoCuenta,
            Foto
        FROM Entrenadores
        WHERE IdEntrenador = {this.idEntrenador}";

            DataTable dt = conSQL.RetornaRegistros(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                lblNombre.Text = dr["NombreCompleto"].ToString();
                lblCedula.Text = dr["Cedula"].ToString();
                lblFechaNacimiento.Text = dr["FechaNacimiento"].ToString();
                lblGenero.Text = dr["Genero"].ToString();
                lblTelefono.Text = dr["Telefono"].ToString();
                lblCorreo.Text = dr["Correo"].ToString();
                lblDireccion.Text = dr["Direccion"].ToString();
                lblEstado.Text = dr["EstadoCuenta"].ToString();

                if (dr["Foto"] != DBNull.Value)
                {
                    byte[] imgData = (byte[])dr["Foto"];
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imgData))
                    {
                        picFoto.Image = Image.FromStream(ms);
                    }
                }
            }

            
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
