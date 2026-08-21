using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmInicioDeSesion : Form
    {

        csConectaSQL conSQL =new csConectaSQL();

        // DATOS DE SESIÓN
        public static int IdUsuarioActual
        {
            get;
            private set;
        }
        public static int IdRolActual
        {
            get;
            private set;
        }
        public static string NombreRolActual
        {
            get;
            private set;
        }
        public static string NombreCompletoActual
        {
            get;
            private set;
        }

        public static int? IdEmpleadoActual
        {
            get;
            private set;
        }

        public static int? IdEntrenadorActual
        {
            get;
            private set;
        }

        public frmInicioDeSesion()
        {
            InitializeComponent();
            ConfigurarFormulario();
            CrearAdminPredeterminado();
        }


        private void ConfigurarFormulario()
        {

            txtUsuario.Text = "Usuario";

            txtUsuario.ForeColor = Color.FromArgb(206,209,239);
            txtContrasena.Text =  "Contraseña";
            txtContrasena.ForeColor = Color.FromArgb(206,209,239);
            txtContrasena.UseSystemPasswordChar =false;

            picVerContrasena.SizeMode =PictureBoxSizeMode.Zoom;

            picVerContrasena.Cursor = Cursors.Hand;
            if (imlOjo.Images.ContainsKey( "cerrado"))
            {
                picVerContrasena.Image =imlOjo.Images[ "cerrado"];
            }
        }
        private void CrearAdminPredeterminado()
        {
            try
            {

                DataTable tablaUsuario =conSQL.RetornaRegistros(
                        @" SELECT
                            IdUsuario

                        FROM Usuarios

                        WHERE
                            NombreUsuario =
                            'admin';
                        "
                    );

                if (tablaUsuario != null && tablaUsuario.Rows.Count > 0)
                {
                    return;
                }

                DataTable tablaRol = conSQL.RetornaRegistros(
                        @"
                        SELECT
                            IdRol

                        FROM Roles
                        WHERE
                            NombreRol =
                            'Administrador';
                        "
                    );

                if (tablaRol == null || tablaRol.Rows.Count == 0)
                {
                    MessageBox.Show( "No existe el rol Administrador.","ZENOVA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idRol = Convert.ToInt32( tablaRol.Rows[0]["IdRol"]);
                string contrasena ="Admin123#";
                byte[] salt =GenerarSalt();
                byte[] hash =GenerarHash(contrasena, salt);
                string hashSQL ="0x" +BitConverter.ToString(hash).Replace("-", "");
                string saltSQL ="0x" +BitConverter.ToString(salt).Replace("-", "");
                string sentencia =
                    @"
                    INSERT INTO Usuarios
                    (
                        NombreUsuario,
                        PasswordHash,
                        PasswordSalt,
                        DebeCambiarPassword,
                        EstadoCuenta,
                        IdRol,
                        IdEmpleado,
                        IdEntrenador
                    )
                    VALUES
                    (
                        'admin',
                        " + hashSQL + @",
                        " + saltSQL + @",
                        0,
                        1,
                        " + idRol + @",
                        NULL,
                        NULL
                    );
                    ";
                conSQL.EjecutaSentenciaSRD( sentencia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo crear el administrador predeterminado:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario =txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;
            if (usuario == "" ||usuario == "Usuario")
            {
                MessageBox.Show(
                    "Ingrese su nombre de usuario.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtUsuario.Focus();
                return;
            }
            if (contrasena == "" ||contrasena =="Contraseña")
            {
                MessageBox.Show(
                    "Ingrese su contraseña.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtContrasena.Focus();
                return;
            }
            string usuarioSeguro = usuario.Replace( "'", "''");

            string consulta =
                @"SELECT
                    U.IdUsuario,
                    U.NombreUsuario,
                    U.PasswordHash,
                    U.PasswordSalt,
                    U.DebeCambiarPassword,
                    U.EstadoCuenta,
                    U.IdRol,
                    U.IdEmpleado,
                    U.IdEntrenador,
                    R.NombreRol,
                    CASE
                        WHEN U.IdEmpleado   IS NOT NULL
                        THEN
                            ISNULL(
                                E.Nombres,
                                ''
                            )
                            +
                            ' '
                            +
                            ISNULL(
                                E.Apellidos,
                                ''
                            )

                        WHEN U.IdEntrenador
                             IS NOT NULL
                        THEN
                            ISNULL(
                                EN.Nombres,
                                ''
                            )
                            +
                            ' '
                            +
                            ISNULL(
                                EN.Apellidos,
                                ''
                            )

                        ELSE
                            U.NombreUsuario

                    END AS NombreCompleto

                FROM Usuarios U

                INNER JOIN Roles R
                    ON U.IdRol =
                       R.IdRol

                LEFT JOIN Empleados E
                    ON U.IdEmpleado =
                       E.IdEmpleado

                LEFT JOIN Entrenadores EN
                    ON U.IdEntrenador =
                       EN.IdEntrenador

                WHERE
                    U.NombreUsuario = '" +
                usuarioSeguro +
                @"';
                ";

            DataTable tabla =conSQL.RetornaRegistros( consulta);
            if (tabla == null ||tabla.Rows.Count == 0)
            {
                MostrarCredencialesIncorrectas();
                return;
            }
            DataRow fila = tabla.Rows[0];
            bool cuentaActiva =Convert.ToBoolean(fila[ "EstadoCuenta"]);
            if (!cuentaActiva)
            {
                MessageBox.Show(
                    "Esta cuenta se encuentra desactivada.\n\n" +
                    "Comuníquese con el administrador.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                LimpiarContrasena();

                return;
            }
            if (fila["PasswordHash"] == DBNull.Value || fila["PasswordSalt"] ==
                    DBNull.Value)
            {
                MessageBox.Show(
                    "La cuenta no tiene credenciales válidas.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            byte[] hashGuardado =(byte[])fila[ "PasswordHash"];
            byte[] saltGuardado =(byte[])fila[ "PasswordSalt"];
            byte[] hashIngresado = GenerarHash( contrasena, saltGuardado);
            if (!CompararHashes( hashGuardado, hashIngresado))
            {
                MostrarCredencialesIncorrectas();
                return;
            }
            int idUsuario = Convert.ToInt32(fila[ "IdUsuario"]);
            int idRol =  Convert.ToInt32(   fila["IdRol"]);
            string nombreRol =fila[  "NombreRol"].ToString();
            string nombreCompleto =fila[ "NombreCompleto"].ToString().Trim();
            int? idEmpleado = fila[ "IdEmpleado"] ==
                DBNull.Value

                ? (int?)null

                : Convert.ToInt32(
                    fila[
                        "IdEmpleado"]);

            int? idEntrenador =
                fila[ "IdEntrenador"] ==
                DBNull.Value

                ? (int?)null

                : Convert.ToInt32(
                    fila[
                        "IdEntrenador"]);


            bool debeCambiarPassword =Convert.ToBoolean( fila[ "DebeCambiarPassword"]);

            if (debeCambiarPassword)
            {
                frmCambiarContrasenaInicial frm =  new frmCambiarContrasenaInicial( idUsuario,   usuario);
                frm.StartPosition =FormStartPosition.CenterScreen;
                DialogResult resultado = frm.ShowDialog(this);
                if (resultado !=
                    DialogResult.OK)
                {
                    LimpiarContrasena();

                    return;
                }
            }

            IdUsuarioActual = idUsuario;
            IdRolActual = idRol;
            NombreRolActual = nombreRol;
            NombreCompletoActual =  nombreCompleto;
            IdEmpleadoActual =  idEmpleado;
            IdEntrenadorActual =  idEntrenador;
            conSQL.EjecutaSentenciaSRD(
                @"
                UPDATE Usuarios

                SET
                    UltimoAcceso =
                    GETDATE()

                WHERE
                    IdUsuario = " +
                idUsuario +
                @";
                "
            );

            Form1 form =   new Form1();
            form.Show();
            this.Hide();
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
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(contrasena,salt,100000))
            {
                return pbkdf2.GetBytes( 32);
            }
        }
        private bool CompararHashes(byte[] hashGuardado, byte[] hashIngresado)
        {
            if (hashGuardado == null || hashIngresado == null)
            {
                return false;
            }
            if (hashGuardado.Length !=hashIngresado.Length)
            {
                return false;
            }
            return hashGuardado.SequenceEqual( hashIngresado);
        }
        private void MostrarCredencialesIncorrectas()
        {
            MessageBox.Show(
                "Usuario o contraseña incorrectos.",
                "ZENOVA",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);


            LimpiarContrasena();
        }
        private void LimpiarContrasena()
        {
            txtContrasena.Text = "";
            txtContrasena.UseSystemPasswordChar =true;
            if (imlOjo.Images.ContainsKey("cerrado"))
            {
                picVerContrasena.Image =imlOjo.Images["cerrado"];
            }
            txtContrasena.Focus();
        }
        private void picVerContrasena_Click(
            object sender,
            EventArgs e)
        {
            if (txtContrasena.Text == "" ||txtContrasena.Text =="Contraseña")
            {
                return;
            }
            if (txtContrasena.UseSystemPasswordChar)
            {
                txtContrasena.UseSystemPasswordChar = false;
                if (imlOjo.Images.ContainsKey("abierto"))
                {
                    picVerContrasena.Image =imlOjo.Images[ "abierto"];
                }
            }
            else
            {
                txtContrasena.UseSystemPasswordChar =true;
                if (imlOjo.Images.ContainsKey("cerrado"))
                {
                    picVerContrasena.Image = imlOjo.Images["cerrado"];
                }
            }
        }
        private void txtUsuario_Enter(
            object sender,
            EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";


                txtUsuario.ForeColor = Color.FromArgb(83,85,175);
            }
        }
        private void txtUsuario_Leave( object sender,EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor =Color.FromArgb( 206, 209,239);
            }
        }
        private void txtContraseña_Enter(object sender,EventArgs e)
        {
            if (txtContrasena.Text =="Contraseña")
            {
                txtContrasena.Text ="";
                txtContrasena.ForeColor =Color.FromArgb( 83,85,175);
                txtContrasena.UseSystemPasswordChar = true;
                if (imlOjo.Images.ContainsKey("cerrado"))
                {
                    picVerContrasena.Image =imlOjo.Images["cerrado"];
                }
            }
        }
        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "Contraseña";
                txtContrasena.ForeColor = Color.FromArgb(206,209,239);
                txtContrasena.UseSystemPasswordChar =false;
                if (imlOjo.Images.ContainsKey("cerrado"))
                {
                    picVerContrasena.Image =imlOjo.Images["cerrado"];
                }
            }
        }
        private void txtContrasena_KeyDown(object sender,KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter)
            {
                btnIniciarSesion.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
        private void btnRegistrar_Click(object sender,EventArgs e)
        {
            frmRegistroEntrenador menu =new frmRegistroEntrenador();
            this.Hide();
            menu.ShowDialog();
            this.Close();
        }
    }
}