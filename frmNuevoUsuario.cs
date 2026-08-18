using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmNuevoUsuario : Form
    {
        // ==========================================
        // CONEXIÓN
        // ==========================================
        csConectaSQL conSQL =
            new csConectaSQL();


        // ==========================================
        // VARIABLES
        // ==========================================
        private int idPersonaSeleccionada = 0;

        private string tipoPersona = "";

        private string nombresPersona = "";

        private string apellidosPersona = "";

        private string contrasenaGenerada = "";


        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        public frmNuevoUsuario()
        {
            InitializeComponent();

            ConfigurarFormulario();

            CargarPersonas();

            CargarRoles();
        }


        // ==========================================
        // CONFIGURAR FORMULARIO
        // ==========================================
        private void ConfigurarFormulario()
        {
            // ==========================================
            // COMBO PERSONA
            // Se puede escribir y buscar
            // ==========================================
            cmbPersona.DropDownStyle =
                ComboBoxStyle.DropDown;

            cmbPersona.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;

            cmbPersona.AutoCompleteSource =
                AutoCompleteSource.ListItems;


            // ==========================================
            // COMBO ROL
            // ==========================================
            cmbRol.DropDownStyle =
                ComboBoxStyle.DropDownList;


            // ==========================================
            // VALORES INICIALES
            // ==========================================
            cmbPersona.SelectedIndex =
                -1;

            cmbRol.SelectedIndex =
                -1;


            lblUsuario.Text =
                "";

            lblContrasena.Text =
                "";


            btnGenerarCredenciales.Enabled =
                false;

            btnGuardar.Enabled =
                false;
        }


        // ==========================================
        // CARGAR PERSONAS
        //
        // SOLO PERSONAS QUE TODAVÍA
        // NO TIENEN USUARIO
        //
        // EMPLEADOS + ENTRENADORES
        // ==========================================
        private void CargarPersonas()
        {
            try
            {
                string consulta =
                    @"
                    SELECT
                        E.IdEmpleado
                            AS IdPersona,

                        E.Nombres + ' ' +
                        E.Apellidos
                            AS NombreCompleto,

                        E.Nombres,

                        E.Apellidos,

                        'Empleado'
                            AS TipoPersona

                    FROM Empleados E

                    WHERE
                        E.Estado = 1

                        AND NOT EXISTS
                        (
                            SELECT 1

                            FROM Usuarios U

                            WHERE
                                U.IdEmpleado =
                                E.IdEmpleado
                        )


                    UNION ALL


                    SELECT
                        EN.IdEntrenador
                            AS IdPersona,

                        EN.Nombres + ' ' +
                        EN.Apellidos
                            AS NombreCompleto,

                        EN.Nombres,

                        EN.Apellidos,

                        'Entrenador'
                            AS TipoPersona

                    FROM Entrenadores EN

                    WHERE
                        EN.EstadoEntrenador =
                        'Activo'

                        AND NOT EXISTS
                        (
                            SELECT 1

                            FROM Usuarios U

                            WHERE
                                U.IdEntrenador =
                                EN.IdEntrenador
                        )


                    ORDER BY
                        NombreCompleto;
                    ";


                DataTable tabla =
                    conSQL.RetornaRegistros(
                        consulta);


                if (tabla == null)
                    return;


                cmbPersona.DataSource =
                    tabla;

                cmbPersona.DisplayMember =
                    "NombreCompleto";

                cmbPersona.ValueMember =
                    "IdPersona";


                // IMPORTANTE
                // Que no seleccione automáticamente
                cmbPersona.SelectedIndex =
                    -1;


                cmbPersona.Text =
                    "";
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


        // ==========================================
        // CARGAR ROLES
        // ==========================================
        private void CargarRoles()
        {
            try
            {
                DataTable tabla =
                    conSQL.RetornaRegistros(
                        @"
                        SELECT
                            IdRol,
                            NombreRol

                        FROM Roles

                        WHERE Activo = 1

                        ORDER BY
                            NombreRol;
                        "
                    );


                if (tabla == null)
                    return;


                cmbRol.DataSource =
                    tabla;

                cmbRol.DisplayMember =
                    "NombreRol";

                cmbRol.ValueMember =
                    "IdRol";


                // No seleccionar automáticamente
                cmbRol.SelectedIndex =
                    -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los roles:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ==========================================
        // CAMBIAR PERSONA
        // ==========================================
        private void cmbPersona_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (cmbPersona.SelectedIndex == -1 ||
                cmbPersona.SelectedItem == null)
            {
                LimpiarPersonaSeleccionada();

                return;
            }


            DataRowView fila =
                cmbPersona.SelectedItem
                as DataRowView;


            if (fila == null)
            {
                LimpiarPersonaSeleccionada();

                return;
            }


            // ==========================================
            // GUARDAMOS LA PERSONA SELECCIONADA
            // ==========================================
            idPersonaSeleccionada =
                Convert.ToInt32(
                    fila["IdPersona"]);


            tipoPersona =
                fila["TipoPersona"]
                .ToString();


            nombresPersona =
                fila["Nombres"]
                .ToString();


            apellidosPersona =
                fila["Apellidos"]
                .ToString();


            // ==========================================
            // SI CAMBIA PERSONA,
            // BORRAMOS CREDENCIALES ANTERIORES
            // ==========================================
            LimpiarCredenciales();


            ActualizarBotones();
        }


        // ==========================================
        // CAMBIAR ROL
        // ==========================================
        private void cmbRol_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            // Si cambia el rol,
            // las credenciales anteriores
            // dejan de considerarse listas
            LimpiarCredenciales();


            ActualizarBotones();
        }


        // ==========================================
        // ACTUALIZAR BOTONES
        // ==========================================
        private void ActualizarBotones()
        {
            bool personaValida =
                idPersonaSeleccionada > 0;


            bool rolValido =
                cmbRol.SelectedIndex != -1;


            btnGenerarCredenciales.Enabled =
                personaValida &&
                rolValido;


            btnGuardar.Enabled =
                personaValida &&
                rolValido &&
                lblUsuario.Text.Trim() != "" &&
                contrasenaGenerada != "";
        }


        // ==========================================
        // GENERAR CREDENCIALES
        // ==========================================
        private void btnGenerarCredenciales_Click(
            object sender,
            EventArgs e)
        {
            // ==========================================
            // VALIDAR PERSONA
            // ==========================================
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


            // ==========================================
            // VALIDAR ROL
            // ==========================================
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


            // ==========================================
            // VALIDAR TIPO DE PERSONA Y ROL
            // ==========================================
            if (!ValidarRolPersona())
            {
                return;
            }


            // ==========================================
            // GENERAR
            // ==========================================
            string usuario =
                GenerarNombreUsuario();


            string contrasena =
                GenerarContrasena();


            if (usuario == "")
            {
                MessageBox.Show(
                    "No se pudo generar el nombre de usuario.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }


            lblUsuario.Text =
                usuario;


            lblContrasena.Text =
                contrasena;


            contrasenaGenerada =
                contrasena;


            btnGuardar.Enabled =
                true;
        }


        // ==========================================
        // VALIDAR PERSONA / ROL
        // ==========================================
        private bool ValidarRolPersona()
        {
            string rol =
                cmbRol.Text.Trim();


            // ==========================================
            // SI ES ENTRENADOR,
            // DEBE TENER ROL ENTRENADOR
            // ==========================================
            if (tipoPersona == "Entrenador" &&
                rol != "Entrenador")
            {
                MessageBox.Show(
                    "La persona seleccionada está registrada como entrenador.\n\n" +
                    "Debe asignarle el rol Entrenador.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }


            // ==========================================
            // UN EMPLEADO NORMAL NO PUEDE
            // RECIBIR ROL ENTRENADOR
            // ==========================================
            if (tipoPersona == "Empleado" &&
                rol == "Entrenador")
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


        // ==========================================
        // GENERAR NOMBRE DE USUARIO
        // ==========================================
        private string GenerarNombreUsuario()
        {
            string nombres =
                nombresPersona
                .Trim()
                .ToLower();


            string apellidos =
                apellidosPersona
                .Trim()
                .ToLower();


            if (nombres == "" ||
                apellidos == "")
            {
                return "";
            }


            // Primera letra del primer nombre
            string primeraLetra =
                nombres.Substring(
                    0,
                    1);


            // Primer apellido
            string primerApellido =
                apellidos
                .Split(' ')[0];


            // Ejemplo:
            // Ana López = alopez
            string usuarioBase =
                primeraLetra +
                primerApellido;


            string usuario =
                usuarioBase;


            int contador =
                2;


            // ==========================================
            // SI YA EXISTE:
            //
            // alopez
            // alopez2
            // alopez3
            // etc.
            // ==========================================
            while (ExisteUsuario(usuario))
            {
                usuario =
                    usuarioBase +
                    contador;


                contador++;
            }


            return usuario;
        }


        // ==========================================
        // COMPROBAR SI EXISTE USUARIO
        // ==========================================
        private bool ExisteUsuario(
            string usuario)
        {
            string usuarioSeguro =
                usuario.Replace(
                    "'",
                    "''");


            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"
                    SELECT
                        IdUsuario

                    FROM Usuarios

                    WHERE
                        NombreUsuario = '" +
                    usuarioSeguro +
                    @"';
                    "
                );


            return tabla != null &&
                   tabla.Rows.Count > 0;
        }


        // ==========================================
        // GENERAR CONTRASEÑA TEMPORAL
        // ==========================================
        private string GenerarContrasena()
        {
            const string caracteres =
                "ABCDEFGHJKLMNPQRSTUVWXYZ" +
                "abcdefghijkmnopqrstuvwxyz" +
                "23456789" +
                "@#$";


            Random random =
                new Random();


            string contrasena =
                "";


            // Contraseña de 10 caracteres
            for (int i = 0;
                 i < 10;
                 i++)
            {
                int posicion =
                    random.Next(
                        caracteres.Length);


                contrasena +=
                    caracteres[posicion];
            }


            return contrasena;
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
        // GUARDAR USUARIO
        // ==========================================



        // ==========================================
        // LIMPIAR PERSONA
        // ==========================================
        private void LimpiarPersonaSeleccionada()
        {
            idPersonaSeleccionada =
                0;


            tipoPersona =
                "";


            nombresPersona =
                "";


            apellidosPersona =
                "";


            LimpiarCredenciales();


            ActualizarBotones();
        }


        // ==========================================
        // LIMPIAR CREDENCIALES
        // ==========================================
        private void LimpiarCredenciales()
        {
            lblUsuario.Text =
                "";


            lblContrasena.Text =
                "";


            contrasenaGenerada =
                "";


            btnGuardar.Enabled =
                false;
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
        // MOVER FORMULARIO
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

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // ==========================================
            // VALIDAR PERSONA
            // ==========================================
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


            // ==========================================
            // VALIDAR ROL
            // ==========================================
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


            // ==========================================
            // VALIDAR ROL / PERSONA
            // ==========================================
            if (!ValidarRolPersona())
            {
                return;
            }


            // ==========================================
            // VALIDAR CREDENCIALES
            // ==========================================
            if (lblUsuario.Text.Trim() == "" ||
                contrasenaGenerada == "")
            {
                MessageBox.Show(
                    "Primero debe generar las credenciales.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // ==========================================
            // ID ROL
            // ==========================================
            int idRol =
                Convert.ToInt32(
                    cmbRol.SelectedValue);


            // ==========================================
            // GENERAR SALT Y HASH
            // ==========================================
            byte[] salt =
                GenerarSalt();


            byte[] hash =
                GenerarHash(
                    contrasenaGenerada,
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
            // DETERMINAR SI VIENE DE
            // EMPLEADOS O ENTRENADORES
            // ==========================================
            string idEmpleado =
                "NULL";


            string idEntrenador =
                "NULL";


            if (tipoPersona ==
                "Empleado")
            {
                idEmpleado =
                    idPersonaSeleccionada
                    .ToString();
            }


            if (tipoPersona ==
                "Entrenador")
            {
                idEntrenador =
                    idPersonaSeleccionada
                    .ToString();
            }


            // ==========================================
            // CAMPOS
            // ==========================================
            string campos =
                "NombreUsuario, " +
                "PasswordHash, " +
                "PasswordSalt, " +
                "DebeCambiarPassword, " +
                "EstadoCuenta, " +
                "IdRol, " +
                "IdEmpleado, " +
                "IdEntrenador";


            // ==========================================
            // DATOS
            // ==========================================
            string datos =
                "'" +
                lblUsuario.Text.Trim()
                .Replace("'", "''") +
                "'," +

                hashSQL +
                "," +

                saltSQL +
                "," +

                // Debe cambiar contraseña
                // cuando inicie sesión
                "1," +

                // Cuenta activa
                "1," +

                idRol +
                "," +

                idEmpleado +
                "," +

                idEntrenador;


            // ==========================================
            // INSERTAR
            // ==========================================
            if (conSQL.insertDatos(
                "Usuarios",
                campos,
                datos))
            {
                MessageBox.Show(
                    "Usuario creado correctamente.\n\n" +
                    "Usuario: " +
                    lblUsuario.Text +
                    "\n\n" +
                    "Contraseña temporal: " +
                    contrasenaGenerada,
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
                    "No se pudo crear el usuario.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}