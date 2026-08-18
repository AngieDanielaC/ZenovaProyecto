using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmCambiarContrasenaInicial : Form
    {
        // ==========================================
        // CONEXIÓN
        // ==========================================
        csConectaSQL conSQL =
            new csConectaSQL();


        // ==========================================
        // VARIABLES
        // ==========================================
        private int idUsuario;

        private string nombreUsuario;


        // ==========================================
        // CONSTRUCTOR PRINCIPAL
        // ==========================================
        public frmCambiarContrasenaInicial(
            int idUsuario,
            string nombreUsuario)
        {
            InitializeComponent();

            this.idUsuario =
                idUsuario;

            this.nombreUsuario =
                nombreUsuario;

            ConfigurarFormulario();
        }


        // ==========================================
        // CONSTRUCTOR VACÍO
        // PARA EL DISEÑADOR
        // ==========================================
        public frmCambiarContrasenaInicial()
        {
            InitializeComponent();

            ConfigurarFormulario();
        }


        // ==========================================
        // CONFIGURAR FORMULARIO
        // ==========================================
        private void ConfigurarFormulario()
        {
            lblUsuario.Text =
                nombreUsuario ?? "";


            txtNuevaContrasena.UseSystemPasswordChar =
                true;

            txtConfirmarContrasena.UseSystemPasswordChar =
                true;


            picVerNueva.SizeMode =
                PictureBoxSizeMode.Zoom;

            picVerConfirmar.SizeMode =
                PictureBoxSizeMode.Zoom;


            picVerNueva.Cursor =
                Cursors.Hand;

            picVerConfirmar.Cursor =
                Cursors.Hand;


            if (imlOjos.Images.ContainsKey(
                "cerrado"))
            {
                picVerNueva.Image =
                    imlOjos.Images[
                        "cerrado"];

                picVerConfirmar.Image =
                    imlOjos.Images[
                        "cerrado"];
            }
        }


        // ==========================================
        // VALIDAR CAMPOS
        // ==========================================
        private bool ValidarCampos()
        {
            string nueva =
                txtNuevaContrasena.Text;

            string confirmar =
                txtConfirmarContrasena.Text;


            if (nueva.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese la nueva contraseña.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNuevaContrasena.Focus();

                return false;
            }


            if (confirmar.Trim() == "")
            {
                MessageBox.Show(
                    "Confirme la nueva contraseña.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtConfirmarContrasena.Focus();

                return false;
            }


            if (nueva.Length < 8)
            {
                MessageBox.Show(
                    "La contraseña debe tener al menos 8 caracteres.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNuevaContrasena.Focus();

                return false;
            }


            if (nueva != confirmar)
            {
                MessageBox.Show(
                    "Las contraseñas no coinciden.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtConfirmarContrasena.Focus();

                return false;
            }


            return true;
        }


        // ==========================================
        // GENERAR SALT
        // ==========================================
        private byte[] GenerarSalt()
        {
            byte[] salt =
                new byte[16];


            using (RandomNumberGenerator rng =
                   RandomNumberGenerator.Create())
            {
                rng.GetBytes(
                    salt);
            }


            return salt;
        }


        // ==========================================
        // GENERAR HASH
        // ==========================================
        private byte[] GenerarHash(
            string contrasena,
            byte[] salt)
        {
            using (Rfc2898DeriveBytes pbkdf2 =
                   new Rfc2898DeriveBytes(
                       contrasena,
                       salt,
                       100000))
            {
                return pbkdf2.GetBytes(
                    32);
            }
        }


        // ==========================================
        // GUARDAR NUEVA CONTRASEÑA
        // ==========================================
        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidarCampos())
                return;


            string nuevaContrasena =
                txtNuevaContrasena.Text;


            // ==========================================
            // NUEVO SALT
            // ==========================================
            byte[] salt =
                GenerarSalt();


            // ==========================================
            // NUEVO HASH
            // ==========================================
            byte[] hash =
                GenerarHash(
                    nuevaContrasena,
                    salt);


            string hashSQL =
                "0x" +
                BitConverter
                .ToString(hash)
                .Replace("-", "");


            string saltSQL =
                "0x" +
                BitConverter
                .ToString(salt)
                .Replace("-", "");


            // ==========================================
            // ACTUALIZAR
            // ==========================================
            string sentencia =
                @"
                UPDATE Usuarios

                SET
                    PasswordHash = " +
                hashSQL +
                @",

                    PasswordSalt = " +
                saltSQL +
                @",

                    DebeCambiarPassword = 0

                WHERE
                    IdUsuario = " +
                idUsuario +
                @";
                ";


            if (conSQL.EjecutaSentenciaSRD(
                sentencia))
            {
                MessageBox.Show(
                    "Contraseña actualizada correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                this.DialogResult =
                    DialogResult.OK;


                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo actualizar la contraseña.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ==========================================
        // MOSTRAR / OCULTAR NUEVA
        // ==========================================
        private void picVerNueva_Click(
            object sender,
            EventArgs e)
        {
            txtNuevaContrasena.UseSystemPasswordChar =
                !txtNuevaContrasena.UseSystemPasswordChar;


            if (txtNuevaContrasena
                .UseSystemPasswordChar)
            {
                if (imlOjos.Images.ContainsKey(
                    "cerrado"))
                {
                    picVerNueva.Image =
                        imlOjos.Images[
                            "cerrado"];
                }
            }
            else
            {
                if (imlOjos.Images.ContainsKey(
                    "abierto"))
                {
                    picVerNueva.Image =
                        imlOjos.Images[
                            "abierto"];
                }
            }
        }


        // ==========================================
        // MOSTRAR / OCULTAR CONFIRMAR
        // ==========================================
        private void picVerConfirmar_Click(
            object sender,
            EventArgs e)
        {
            txtConfirmarContrasena
                .UseSystemPasswordChar =
                !txtConfirmarContrasena
                .UseSystemPasswordChar;


            if (txtConfirmarContrasena
                .UseSystemPasswordChar)
            {
                if (imlOjos.Images.ContainsKey(
                    "cerrado"))
                {
                    picVerConfirmar.Image =
                        imlOjos.Images[
                            "cerrado"];
                }
            }
            else
            {
                if (imlOjos.Images.ContainsKey(
                    "abierto"))
                {
                    picVerConfirmar.Image =
                        imlOjos.Images[
                            "abierto"];
                }
            }
        }


        // ==========================================
        // ENTER PARA GUARDAR
        // ==========================================
        private void txtConfirmarContrasena_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode ==
                Keys.Enter)
            {
                btnGuardar.PerformClick();

                e.SuppressKeyPress =
                    true;
            }
        }


        // ==========================================
        // CERRAR
        // ==========================================
        private void btnCerrar_Click(
            object sender,
            EventArgs e)
        {
            // Como este formulario aparece
            // porque DEBE cambiar su contraseña,
            // cerrar significa NO entrar al sistema.
            this.DialogResult =
                DialogResult.Cancel;

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
    }
}
