using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmNuevoUsuario : Form
    {

        csConectaSQL conSQL = new csConectaSQL();

        private int idPersonaSeleccionada = 0;

        private string tipoPersona = "";

        private string nombresPersona = "";

        private string apellidosPersona = "";

        private string contrasenaGenerada = "";

        public frmNuevoUsuario()
        {
            InitializeComponent();

            ConfigurarFormulario();

            CargarPersonas();

            CargarRoles();
        }

        private void ConfigurarFormulario()
        {

            cmbPersona.DropDownStyle = ComboBoxStyle.DropDown;

            cmbPersona.AutoCompleteMode =AutoCompleteMode.SuggestAppend;

            cmbPersona.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbPersona.SelectedIndex =-1;

            cmbRol.SelectedIndex = -1;


            lblUsuario.Text = "";

            lblContrasena.Text = "";


            btnGenerarCredenciales.Enabled = false;

            btnGuardar.Enabled = false;
        }


        private void CargarPersonas()
        {
            try
            {
                string consulta =
                    @"
                        SELECT E.IdEmpleado AS IdPersona,
                            E.Nombres + ' ' + E.Apellidos AS NombreCompleto,
                            E.Nombres,
                            E.Apellidos,
                            'Empleado' AS TipoPersona
                        FROM Empleados E
                        WHERE E.Estado = 1
                            AND NOT EXISTS
                            (
                                SELECT 1
                                FROM Usuarios U
                                WHERE U.IdEmpleado = E.IdEmpleado
                            )

                        UNION ALL

                        SELECT EN.IdEntrenador AS IdPersona,
                            EN.Nombres + ' ' + EN.Apellidos AS NombreCompleto,
                            EN.Nombres,
                            EN.Apellidos,
                            'Entrenador' AS TipoPersona
                        FROM Entrenadores EN
                        WHERE EN.EstadoEntrenador = 'Activo'
                            AND NOT EXISTS
                            (
                                SELECT 1
                                FROM Usuarios U
                                WHERE U.IdEntrenador = EN.IdEntrenador
                            )
                        ORDER BY NombreCompleto;
                        ";


                DataTable tabla = conSQL.RetornaRegistros( consulta);


                if (tabla == null)
                    return;

                cmbPersona.DataSource = tabla;
                cmbPersona.DisplayMember ="NombreCompleto";
                cmbPersona.ValueMember ="IdPersona";

                cmbPersona.SelectedIndex = -1;

                cmbPersona.Text =  "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las personas:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void CargarRoles()
        {
            try
            {
                DataTable tabla = conSQL.RetornaRegistros(
                    @"SELECT IdRol, NombreRol
                        FROM Roles
                        WHERE Activo = 1
                        ORDER BY NombreRol;"
                );

                if (tabla == null)
                    return;

                cmbRol.DataSource = tabla;
                cmbRol.DisplayMember = "NombreRol";
                cmbRol.ValueMember = "IdRol";

                // No seleccionar automáticamente
                cmbRol.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los roles:\n\n" + ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void cmbPersona_SelectedIndexChanged(object sender,EventArgs e)
        {
            if (cmbPersona.SelectedIndex == -1 || cmbPersona.SelectedItem == null)
            {
                LimpiarPersonaSeleccionada();
                return;
            }

            DataRowView fila = cmbPersona.SelectedItem as DataRowView;

            if (fila == null)
            {
                LimpiarPersonaSeleccionada();
                return;
            }

            idPersonaSeleccionada = Convert.ToInt32(fila["IdPersona"]);
            tipoPersona = fila["TipoPersona"].ToString();
            nombresPersona = fila["Nombres"].ToString();
            apellidosPersona = fila["Apellidos"].ToString();

            LimpiarCredenciales();
            ActualizarBotones();
        }


        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarCredenciales();
            ActualizarBotones();
        }



        private void ActualizarBotones()
        {
            bool personaValida =  idPersonaSeleccionada > 0;


            bool rolValido = cmbRol.SelectedIndex != -1;


            btnGenerarCredenciales.Enabled = personaValida && rolValido;


            btnGuardar.Enabled = personaValida && rolValido && lblUsuario.Text.Trim() != "" && contrasenaGenerada != "";
        }


        private void btnGenerarCredenciales_Click(object sender,EventArgs e)
        {

            if (idPersonaSeleccionada <= 0)
            {
                MessageBox.Show( "Seleccione una persona.", "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbPersona.Focus();

                return;
            }

            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un rol.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbRol.Focus();

                return;
            }


            if (!ValidarRolPersona())
            {
                return;
            }


            string usuario = GenerarNombreUsuario();


            string contrasena = GenerarContrasena();


            if (usuario == "")
            {
                MessageBox.Show(
                    "No se pudo generar el nombre de usuario.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            lblUsuario.Text =  usuario;
            lblContrasena.Text = contrasena;
            contrasenaGenerada = contrasena;
            btnGuardar.Enabled =true;
        }

        private bool ValidarRolPersona()
        {
            string rol = cmbRol.Text.Trim();
            if (tipoPersona == "Entrenador" && rol != "Entrenador")
            {
                MessageBox.Show(
                    "La persona seleccionada está registrada como entrenador.\n\n" +
                    "Debe asignarle el rol Entrenador.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            if (tipoPersona == "Empleado" && rol == "Entrenador")
            {
                MessageBox.Show(
                    "El rol Entrenador solo puede asignarse a una persona registrada en Gestión de Entrenadores.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private string GenerarNombreUsuario()
        {
            string nombres = nombresPersona.Trim().ToLower();
            string apellidos = apellidosPersona.Trim().ToLower();

            if (nombres == "" || apellidos == "")
                return "";

            string primeraLetra = nombres.Substring(0, 1);

            string primerApellido = apellidos.Split(' ')[0];

            string usuarioBase = primeraLetra + primerApellido;
            string usuario = usuarioBase;
            int contador = 2;

            while (ExisteUsuario(usuario))
            {
                usuario = usuarioBase + contador;
                contador++;
            }

            return usuario;
        }



        private bool ExisteUsuario(string usuario)
        {
            string usuarioSeguro = usuario.Replace("'", "''");

            DataTable tabla = conSQL.RetornaRegistros(
                @"SELECT IdUsuario
                    FROM Usuarios
                    WHERE NombreUsuario = '" + usuarioSeguro + @"';")
                ;

            return tabla != null && tabla.Rows.Count > 0;
        }

        private string GenerarContrasena()
        {
            const string caracteres = "ABCDEFGHJKLMNPQRSTUVWXYZ" + "abcdefghijkmnopqrstuvwxyz" + "23456789" + "@#$";

            Random random = new Random();
            string contrasena = "";

            // Contraseña de 10 caracteres
            for (int i = 0; i < 10; i++)
            {
                int posicion = random.Next(caracteres.Length);
                contrasena += caracteres[posicion];
            }

            return contrasena;
        }


        private byte[] GenerarSalt()
        {
            byte[] salt = new byte[16];


            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes( salt);
            }
            return salt;
        }

        private byte[] GenerarHash(string contrasena, byte[] salt)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes( contrasena, salt, 100000))
            {
                return pbkdf2.GetBytes( 32);
            }
        }

        private void LimpiarPersonaSeleccionada()
        {
            idPersonaSeleccionada =  0;
            tipoPersona = "";
            nombresPersona = "";


            apellidosPersona ="";
            LimpiarCredenciales();
            ActualizarBotones();
        }


        private void LimpiarCredenciales()
        {
            lblUsuario.Text = "";
            lblContrasena.Text =  "";
            contrasenaGenerada = "";
            btnGuardar.Enabled = false;
        }


        private void btnCerrar_Click( object sender, EventArgs e)
        {
            this.Close();
        }


        [DllImport("user32.dll",EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();
        [DllImport(  "user32.dll",EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd,int Msg,int wParam,int lParam);

        private void panel1_MouseDown( object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage( this.Handle,0x112, 0xF012, 0);
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (idPersonaSeleccionada <= 0)
            {
                MessageBox.Show(
                    "Seleccione una persona.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbPersona.Focus();

                return;
            }


            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un rol.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbRol.Focus();

                return;
            }
            if (!ValidarRolPersona())
            {
                return;
            }

            if (lblUsuario.Text.Trim() == "" || contrasenaGenerada == "")
            {
                MessageBox.Show(
                    "Primero debe generar las credenciales.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }



            int idRol = Convert.ToInt32( cmbRol.SelectedValue);



            byte[] salt =GenerarSalt();


            byte[] hash = GenerarHash(contrasenaGenerada,salt);
            string hashSQL = "0x" + BitConverter.ToString(hash).Replace("-", "");


            string saltSQL = "0x" +BitConverter.ToString(salt).Replace("-", "");
            string idEmpleado = "NULL";
            string idEntrenador = "NULL";

            if (tipoPersona =="Empleado")
            {
                idEmpleado =idPersonaSeleccionada.ToString();
            }
            if (tipoPersona =="Entrenador")
            {
                idEntrenador =idPersonaSeleccionada.ToString();
            }

            string campos =
                "NombreUsuario, " + "PasswordHash, " +
                "PasswordSalt, " +
                "DebeCambiarPassword, " +
                "EstadoCuenta, " +
                "IdRol, " +
                "IdEmpleado, " +
                "IdEntrenador";


            string datos =
                "'" + lblUsuario.Text.Trim().Replace("'", "''") + "'," +
                hashSQL + "," +
                saltSQL + "," +
                "1," + // Debe cambiar contraseña cuando inicie sesión
                "1," + // Cuenta activa
                idRol + "," +
                idEmpleado + "," +
                idEntrenador;

            if (conSQL.insertDatos("Usuarios", campos, datos))
            {
                MessageBox.Show(
                    "Usuario creado correctamente.\n\n" +
                    "Usuario: " + lblUsuario.Text + "\n\n" +
                    "Contraseña temporal: " + contrasenaGenerada,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo crear el usuario.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}