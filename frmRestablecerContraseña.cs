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
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace wfZenova
{
    public partial class frmRestablecerContraseña : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        private int idUsuario;
        private string nombreUsuario;
        private string nuevaContrasena;
        public frmRestablecerContraseña(int idUsuario,string nombreUsuario)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;

            lblUsuario.Text = nombreUsuario;

            nuevaContrasena =
                GenerarContrasenaTemporal();

            txtNuevaContrasena.Text =
                nuevaContrasena;

            txtNuevaContrasena.ReadOnly = true;
        }
        public frmRestablecerContraseña()
        {
            InitializeComponent();
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
        private string GenerarContrasenaTemporal()
        {
            const string caracteres = "ABCDEFGHJKLMNPQRSTUVWXYZ" + "abcdefghijkmnopqrstuvwxyz" + "23456789" + "@#$";

            Random random = new Random();

            string contrasena = "";

            for (int i = 0; i < 10; i++)
            {
                contrasena += caracteres[ random.Next(caracteres.Length)];
            }
            return contrasena;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private byte[] GenerarSalt()
        {
            byte[] salt = new byte[16];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        private byte[] GenerarHash(string contrasena, byte[] salt)
        {
            using (Rfc2898DeriveBytes pbkdf2 =new Rfc2898DeriveBytes(contrasena, salt, 100000))
            {
                return pbkdf2.GetBytes(32);
            }
        }
        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
           "¿Desea restablecer la contraseña del usuario " +
           nombreUsuario + "?",
           "ZENOVA",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;


            byte[] salt =GenerarSalt();

            byte[] hash =GenerarHash(nuevaContrasena,salt);

            string hashSQL ="0x" +BitConverter.ToString(hash).Replace("-", "");

            string saltSQL ="0x" +BitConverter.ToString(salt).Replace("-", "");


            string sentencia =
                "UPDATE Usuarios SET " +
                "PasswordHash = " + hashSQL + ", " +
                "PasswordSalt = " + saltSQL + ", " +
                "DebeCambiarPassword = 1 " +
                "WHERE IdUsuario = " + idUsuario;


            if (conSQL.EjecutaSentenciaSRD(sentencia))
            {
                MessageBox.Show(
                    "Contraseña restablecida correctamente.\n\n" +
                    "Nueva contraseña temporal: " +
                    nuevaContrasena,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
        }
    }
}
