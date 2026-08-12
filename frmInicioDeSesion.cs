using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmInicioDeSesion : Form
    {
        public frmInicioDeSesion()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            // VALIDAR CAMPOS VACÍOS
            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show(
                    "Ingrese el usuario.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUsuario.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show(
                    "Ingrese la contraseña.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtContrasena.Focus();
                return;
            }

            csConectaSQL conexion = new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            SELECT
                U.IdUsuario,
                U.PasswordHash,
                U.PasswordSalt,
                U.EstadoCuenta,
                U.DebeCambiarPassword,
                R.NombreRol
            FROM Usuarios U
            INNER JOIN Roles R
                ON U.IdRol = R.IdRol
            WHERE U.NombreUsuario = @Usuario;
        ";

                SqlCommand comando =
                    new SqlCommand(consulta, conexion.oCon);

                comando.Parameters.AddWithValue(
                    "@Usuario",
                    usuario);

                SqlDataReader lector =
                    comando.ExecuteReader();

                // USUARIO NO EXISTE
                if (!lector.Read())
                {
                    lector.Close();

                    MessageBox.Show(
                        "Usuario o contraseña incorrectos.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    txtContrasena.Clear();
                    txtContrasena.Focus();

                    return;
                }

                bool estadoCuenta =
                    Convert.ToBoolean(
                        lector["EstadoCuenta"]);

                bool debeCambiarPassword =
                    Convert.ToBoolean(
                        lector["DebeCambiarPassword"]);

                string rol =
                    lector["NombreRol"].ToString();

                byte[] hashGuardado =
                    (byte[])lector["PasswordHash"];

                byte[] saltGuardado =
                    (byte[])lector["PasswordSalt"];

                lector.Close();


                // VERIFICAR CONTRASEÑA
                bool contrasenaCorrecta =
                    VerificarContrasena(
                        contrasena,
                        saltGuardado,
                        hashGuardado);

                if (!contrasenaCorrecta)
                {
                    MessageBox.Show(
                        "Usuario o contraseña incorrectos.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    txtContrasena.Clear();
                    txtContrasena.Focus();

                    return;
                }


                // VERIFICAR ESTADO
                if (!estadoCuenta)
                {
                    MessageBox.Show(
                        "La cuenta se encuentra desactivada.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // SOLO ADMINISTRADOR
                if (!rol.Equals(
                    "Administrador",
                    StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "Este usuario no tiene acceso como administrador.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // CONTRASEÑA TEMPORAL
                if (debeCambiarPassword)
                {
                    MessageBox.Show(
                        "Debe cambiar su contraseña temporal antes de ingresar.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }


                // LOGIN CORRECTO
                Form1 menu = new Form1();
                menu.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al iniciar sesión:\n\n" +
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
       
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.FromArgb(83, 85, 175);
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.FromArgb(206, 209, 239);
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "Contraseña")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.FromArgb(83, 85, 175);
                txtContrasena.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "Contraseña";
                txtContrasena.ForeColor = Color.FromArgb(206, 209, 239);
                txtContrasena.UseSystemPasswordChar = false;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistroEntrenador menu = new frmRegistroEntrenador();

            this.Hide();

            menu.ShowDialog();

            this.Close();
        }
        private bool VerificarContrasena(
    string contrasenaIngresada,
    byte[] saltGuardado,
    byte[] hashGuardado)
        {
            using (Rfc2898DeriveBytes pbkdf2 =
                   new Rfc2898DeriveBytes(
                       contrasenaIngresada,
                       saltGuardado,
                       100000))
            {
                byte[] hashIngresado =
                    pbkdf2.GetBytes(32);

                if (hashIngresado.Length != hashGuardado.Length)
                    return false;

                for (int i = 0; i < hashIngresado.Length; i++)
                {
                    if (hashIngresado[i] != hashGuardado[i])
                        return false;
                }

                return true;
            }
        }
    }
}
