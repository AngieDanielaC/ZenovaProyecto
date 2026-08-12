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
        private int idUsuario;
        private string nombreUsuario;
        public frmRestablecerContraseña(int idUsuario,string nombreUsuario)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;

            // Mostrar usuario
            lblUsuario.Text = nombreUsuario;

            // Generar contraseña automáticamente
            txtNuevaContrasena.Text = GenerarContrasenaTemporal();

            // Evitar que el administrador la modifique
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private string GenerarContrasenaTemporal()
        {
            const string caracteres =
                "ABCDEFGHJKLMNPQRSTUVWXYZ" +
                "abcdefghijkmnopqrstuvwxyz" +
                "23456789";

            using (RandomNumberGenerator rng =
                   RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[8];

                rng.GetBytes(bytes);

                char[] clave = new char[8];

                for (int i = 0; i < clave.Length; i++)
                {
                    clave[i] =
                        caracteres[
                            bytes[i] % caracteres.Length];
                }

                return new string(clave);
            }
        }
        private byte[] GenerarSalt()
        {
            byte[] salt = new byte[16];

            using (RandomNumberGenerator rng =
                   RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
        private byte[] GenerarHash(string contrasena, byte[] salt)
        {
            using (Rfc2898DeriveBytes pbkdf2 =
                   new Rfc2898DeriveBytes(
                       contrasena,
                       salt,
                       100000))
            {
                return pbkdf2.GetBytes(32);
            }
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            DialogResult respuesta =
        MessageBox.Show(
            "¿Está seguro de que desea restablecer " +
            "la contraseña de " + nombreUsuario + "?",
            "Restablecer contraseña",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }


            string nuevaContrasena =
                txtNuevaContrasena.Text.Trim();


            byte[] salt =
                GenerarSalt();

            byte[] hash =
                GenerarHash(
                    nuevaContrasena,
                    salt);


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
            SET
                PasswordHash = @PasswordHash,
                PasswordSalt = @PasswordSalt,
                DebeCambiarPassword = 1
            WHERE IdUsuario = @IdUsuario;
        ";


                SqlCommand comando =
                    new SqlCommand(
                        consulta,
                        conexion.oCon);


                comando.Parameters.Add(
                    "@PasswordHash",
                    SqlDbType.VarBinary,
                    32).Value = hash;


                comando.Parameters.Add(
                    "@PasswordSalt",
                    SqlDbType.VarBinary,
                    16).Value = salt;


                comando.Parameters.AddWithValue(
                    "@IdUsuario",
                    idUsuario);


                comando.ExecuteNonQuery();


                MessageBox.Show(
                    "Contraseña restablecida correctamente.\n\n" +
                    "Usuario: " + nombreUsuario + "\n" +
                    "Contraseña temporal: " +
                    nuevaContrasena + "\n\n" +
                    "El usuario deberá cambiarla " +
                    "en su próximo inicio de sesión.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al restablecer la contraseña:\n\n" +
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
}
