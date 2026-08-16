using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Linq;
using System.IO;
using System.Security.Cryptography;

namespace wfZenova
{
    public partial class frmNuevoUsuario : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        private Image fotoPredeterminada;
        private bool fotoSeleccionada = false;

        public frmNuevoUsuario()
        {
            InitializeComponent();
            if (picFoto.Image != null)
            {
                fotoPredeterminada =
                    new Bitmap(picFoto.Image);
            }

            pnlEntrenador.Visible = false;
            txtCedula.MaxLength = 10;
            txtTelefono.MaxLength = 10;

            cmbRol.DropDownStyle =
                ComboBoxStyle.DropDownList;
            CargarRoles();
        }
        private void CargarRoles()
        {
            DataTable tablaRoles =
                conSQL.RetornaRegistros(
                    "SELECT IdRol, NombreRol " +
                    "FROM Roles " +
                    "WHERE Activo = 1 " +
                    "ORDER BY NombreRol"
                );

            if (tablaRoles == null)
                return;

            cmbRol.DataSource = tablaRoles;
            cmbRol.DisplayMember = "NombreRol";
            cmbRol.ValueMember = "IdRol";

            cmbRol.SelectedIndex = -1;

            cmbRol.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void frmNuevoUsuario_Load(object sender, EventArgs e)
        {

        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRol.SelectedIndex == -1)
            {
                pnlEntrenador.Visible = false;
                BloquearDatosEntrenador(false);
                return;
            }

            if (cmbRol.SelectedValue == null ||
                cmbRol.SelectedValue is DataRowView)
            {
                return;
            }

            string rolSeleccionado = cmbRol.Text;

            if (rolSeleccionado == "Entrenador")
            {
                pnlEntrenador.Visible = true;

                BloquearDatosEntrenador(true);

                CargarEntrenadoresRegistrados();
            }
            else
            {
                pnlEntrenador.Visible = false;

                cmbEntrenador.DataSource = null;

                BloquearDatosEntrenador(false);

                LimpiarDatosPersonales();
            }
        }

        private void LimpiarDatosPersonales()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtCedula.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();

            rbMasculino.Checked = false;
            rbFemenino.Checked = false;

            dtpFechaNacimiento.Value = DateTime.Today;

            if (fotoPredeterminada != null)
            {
                picFoto.Image =
                    new Bitmap(fotoPredeterminada);

                picFoto.SizeMode =
                    PictureBoxSizeMode.Zoom;
            }

            lblUsuario.Text = "";
            lblContrasena.Text = "";
        }
        private void CargarEntrenadoresRegistrados()
        {
            DataTable tablaEntrenadores =
                conSQL.RetornaRegistros(
                    @"SELECT
                IdEntrenador,
                Nombres + ' ' + Apellidos AS NombreCompleto
              FROM Entrenadores
              WHERE EstadoEntrenador = 'Activo'
              ORDER BY Nombres, Apellidos"
                );

            if (tablaEntrenadores == null)
                return;

            cmbEntrenador.DataSource = tablaEntrenadores;

            cmbEntrenador.DisplayMember =
                "NombreCompleto";

            cmbEntrenador.ValueMember =
                "IdEntrenador";

            cmbEntrenador.SelectedIndex = -1;

            cmbEntrenador.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }
        private void btnAgregarDeporte_Click(object sender, EventArgs e)
        {
            
        }

        private void btnQuitarDeporte_Click(object sender, EventArgs e)
        {
          
        }
        
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGenerarCredenciales_Click(object sender, EventArgs e)
        {

            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione primero el rol.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (txtNombres.Text.Trim() == "" ||
                txtApellidos.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Debe ingresar o seleccionar los datos del usuario antes de generar el acceso.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string usuario =
                GenerarNombreUsuario();

            string contrasena =
                GenerarContrasena();

            lblUsuario.Text =
                usuario;

            lblContrasena.Text =
                contrasena;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            // VALIDAR TODO

            if (!ValidarCampos())
                return;

            // DATOS GENERALES

            string genero;

            if (rbMasculino.Checked)
                genero = "Masculino";
            else
                genero = "Femenino";


            string usuario =lblUsuario.Text.Trim();

            string contrasena =lblContrasena.Text.Trim();

            int idRol = Convert.ToInt32(cmbRol.SelectedValue);


            // ID ENTRENADOR
            // Para otros roles será NULL.
            string idEntrenador = "NULL";

            if (cmbRol.Text == "Entrenador")
            {
                idEntrenador =
                    cmbEntrenador.SelectedValue
                    .ToString();
            }


            // GENERAR SALT
            byte[] salt =
                new byte[16];

            using (RandomNumberGenerator rng =
                   RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // GENERAR HASH DE CONTRASEÑA
            byte[] hash;
            using (Rfc2898DeriveBytes pbkdf2 =
                   new Rfc2898DeriveBytes(contrasena,salt,100000))
            {
                hash =pbkdf2.GetBytes(32);
            }



            // CONVERTIR HASH Y SALT A HEXADECIMAL

            string hashSQL ="0x" +BitConverter.ToString(hash).Replace("-", "");


            string saltSQL ="0x" +BitConverter.ToString(salt).Replace("-", "");

            // FOTO
            // FOTO
            // ==========================================
            string fotoSQL = "NULL";

            if (picFoto.Image != null)
            {
                byte[] fotoBytes =
                    PrepararFotoParaGuardar(
                        picFoto.Image);

                fotoSQL =
                    "0x" +
                    BitConverter
                    .ToString(fotoBytes)
                    .Replace("-", "");
            }


            // CAMPOS DE LA TABLA USUARIOS
            string campos ="Cedula, " +"Nombres, " + "Apellidos, " +"FechaNacimiento, " +"Genero, " +"Telefono, " +"Correo, " +"Direccion, " +"Foto, " +
                "NombreUsuario, " +"PasswordHash, " +"PasswordSalt, " +"DebeCambiarPassword, " +
                "EstadoCuenta, " +"IdRol, " +"IdEntrenador";


            // DATOS

            string datos ="'" +txtCedula.Text.Trim() +"'," +"'" +
                txtNombres.Text.Trim().Replace("'", "''") +"'," +"'" +
                txtApellidos.Text.Trim().Replace("'", "''") +"'," +"'" +dtpFechaNacimiento.Value.ToString("yyyy-MM-dd") +
                "'," + "'" +genero +"'," +"'" +txtTelefono.Text.Trim() +"'," +"'" +
                txtCorreo.Text.Trim().Replace("'", "''") +"'," +"'" +
                txtDireccion.Text.Trim().Replace("'", "''") +"'," +
                // FOTO
                fotoSQL +"," +"'" +usuario.Replace("'", "''") +"'," +
                // PASSWORD HASH
                hashSQL +"," +
                // PASSWORD SALT
                saltSQL +"," +

                // Debe cambiar contraseña
                "1," +

                // Estado activo
                "1," +

                // Rol
                idRol +"," +
                // Entrenador o NULL
                idEntrenador;

            // GUARDAR
            if (conSQL.insertDatos("Usuarios",campos,datos))
            {
                MessageBox.Show(
                    "Usuario registrado correctamente.\n\n" +
                    "Usuario: " +
                    usuario +
                    "\n" +
                    "Contraseña temporal: " +
                    contrasena,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Control contenedor = this.Parent;

                if (contenedor != null)
                {
                    frmGestionDeUsuarios frm =
                        new frmGestionDeUsuarios();

                    frm.TopLevel = false;

                    frm.FormBorderStyle =
                        FormBorderStyle.None;

                    frm.Dock =
                        DockStyle.Fill;

                    contenedor.Controls.Remove(this);

                    contenedor.Controls.Add(frm);

                    frm.Show();

                    this.Close();
                }
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo =new OpenFileDialog();

            dialogo.Filter =
                "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                using (Image imagen =
                       Image.FromFile(dialogo.FileName))
                {
                    picFoto.Image =
                        new Bitmap(imagen);
                }

                picFoto.SizeMode =
                    PictureBoxSizeMode.Zoom;

                fotoSeleccionada = true;
            }
        }

        private void cmbEntrenador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEntrenador.SelectedIndex == -1 ||
                cmbEntrenador.SelectedValue == null ||
                cmbEntrenador.SelectedValue is DataRowView)
            {
                return;
            }

            int idEntrenador =
                Convert.ToInt32(cmbEntrenador.SelectedValue);

            CargarDatosEntrenador(idEntrenador);
        }
        private void CargarDatosEntrenador(int idEntrenador)
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                Nombres,
                Apellidos,
                Cedula,
                FechaNacimiento,
                Genero,
                Direccion,
                Telefono,
                Correo,
                Foto
              FROM Entrenadores
              WHERE IdEntrenador = " + idEntrenador
                );

            if (tabla == null || tabla.Rows.Count == 0)
                return;

            DataRow fila = tabla.Rows[0];

            txtNombres.Text = fila["Nombres"].ToString();
            txtApellidos.Text = fila["Apellidos"].ToString();
            txtCedula.Text = fila["Cedula"].ToString();

            dtpFechaNacimiento.Value =
                Convert.ToDateTime(fila["FechaNacimiento"]);

            txtDireccion.Text =
                fila["Direccion"].ToString();

            txtTelefono.Text =
                fila["Telefono"].ToString();

            txtCorreo.Text =
                fila["Correo"].ToString();


            // GÉNERO
            string genero =
                fila["Genero"].ToString();

            rbMasculino.Checked =
                genero == "Masculino";

            rbFemenino.Checked =
                genero == "Femenino";


            // FOTO
            if (fila["Foto"] != DBNull.Value)
            {
                byte[] foto =
                    (byte[])fila["Foto"];

                using (MemoryStream ms =
                       new MemoryStream(foto))
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
            else
            {
                picFoto.Image = null;
            }
        }
        private string GenerarNombreUsuario()
        {
            string nombres =
                txtNombres.Text.Trim().ToLower();

            string apellidos =
                txtApellidos.Text.Trim().ToLower();

            if (nombres == "" || apellidos == "")
                return "";

            // Primera letra del nombre
            string primeraLetra =
                nombres.Substring(0, 1);

            // Primer apellido
            string primerApellido =
                apellidos.Split(' ')[0];

            string usuarioBase =
                primeraLetra + primerApellido;

            string usuario =
                usuarioBase;

            int contador = 2;

            while (ExisteUsuario(usuario))
            {
                usuario =
                    usuarioBase + contador;

                contador++;
            }

            return usuario;
        }
        private bool ExisteUsuario(string usuario)
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    "SELECT IdUsuario " +
                    "FROM Usuarios " +
                    "WHERE NombreUsuario = '" +
                    usuario + "'"
                );

            if (tabla == null)
                return false;

            return tabla.Rows.Count > 0;
        }
        private string GenerarContrasena()
        {
            const string caracteres =
                "ABCDEFGHJKLMNPQRSTUVWXYZ" +
                "abcdefghijkmnopqrstuvwxyz" +
                "23456789" +
                "@#$";

            Random random =
                new Random();

            string contrasena = "";

            for (int i = 0; i < 10; i++)
            {
                int posicion =
                    random.Next(
                        caracteres.Length);

                contrasena +=
                    caracteres[posicion];
            }

            return contrasena;
        }
        private bool ValidarCampos()
        {
            if (!fotoSeleccionada)
            {
                MessageBox.Show(
                    "Debe subir una foto del usuario.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }
            // ROL
            if (cmbRol.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un rol.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbRol.Focus();
                return false;
            }

            // SI ES ENTRENADOR
            if (cmbRol.Text == "Entrenador" &&
                cmbEntrenador.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un entrenador registrado.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbEntrenador.Focus();
                return false;
            }

            // NOMBRES
            if (txtNombres.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese los nombres.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombres.Focus();
                return false;
            }

            if (!txtNombres.Text.Trim()
                .All(c => char.IsLetter(c) ||
                          char.IsWhiteSpace(c)))
            {
                MessageBox.Show(
                    "Los nombres solo pueden contener letras.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombres.Focus();
                return false;
            }

            // APELLIDOS
            if (txtApellidos.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese los apellidos.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtApellidos.Focus();
                return false;
            }

            if (!txtApellidos.Text.Trim()
                .All(c => char.IsLetter(c) ||
                          char.IsWhiteSpace(c)))
            {
                MessageBox.Show(
                    "Los apellidos solo pueden contener letras.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtApellidos.Focus();
                return false;
            }

            // CÉDULA
            string cedula = txtCedula.Text.Trim();

            if (cedula.Length != 10 ||
                !cedula.All(char.IsDigit))
            {
                MessageBox.Show(
                    "La cédula debe contener exactamente 10 dígitos.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCedula.Focus();
                return false;
            }

            // FECHA DE NACIMIENTO
            if (dtpFechaNacimiento.Value.Date >=
                DateTime.Today)
            {
                MessageBox.Show(
                    "Ingrese una fecha de nacimiento válida.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            // GÉNERO
            if (!rbMasculino.Checked &&
                !rbFemenino.Checked)
            {
                MessageBox.Show(
                    "Seleccione el género.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            // DIRECCIÓN
            if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese la dirección.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDireccion.Focus();
                return false;
            }

            // TELÉFONO
            string telefono = txtTelefono.Text.Trim();

            if (telefono.Length != 10 ||
                !telefono.All(char.IsDigit))
            {
                MessageBox.Show(
                    "El teléfono debe contener exactamente 10 dígitos.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTelefono.Focus();
                return false;
            }

            // CORREO
            string correo = txtCorreo.Text.Trim();

            if (correo == "")
            {
                MessageBox.Show(
                    "Ingrese el correo electrónico.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();
                return false;
            }

            try
            {
                System.Net.Mail.MailAddress correoValido =
                    new System.Net.Mail.MailAddress(correo);

                if (correoValido.Address != correo)
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show(
                    "Ingrese un correo electrónico válido.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();
                return false;
            }

            // USUARIO Y CONTRASEÑA GENERADOS
            if (lblUsuario.Text.Trim() == "" ||
                lblContrasena.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Primero debe generar el usuario y la contraseña.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            // DUPLICADO DE CÉDULA
            DataTable tablaCedula =
                conSQL.RetornaRegistros(
                    "SELECT IdUsuario FROM Usuarios " +
                    "WHERE Cedula = '" + cedula + "'"
                );

            if (tablaCedula != null &&
                tablaCedula.Rows.Count > 0)
            {
                MessageBox.Show(
                    "Ya existe un usuario con esa cédula.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            // DUPLICADO DE CORREO
            DataTable tablaCorreo =
                conSQL.RetornaRegistros(
                    "SELECT IdUsuario FROM Usuarios " +
                    "WHERE Correo = '" + correo + "'"
                );

            if (tablaCorreo != null &&
                tablaCorreo.Rows.Count > 0)
            {
                MessageBox.Show(
                    "Ya existe un usuario con ese correo electrónico.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            // DUPLICADO DE USUARIO
            DataTable tablaUsuario =
                conSQL.RetornaRegistros(
                    "SELECT IdUsuario FROM Usuarios " +
                    "WHERE NombreUsuario = '" +
                    lblUsuario.Text.Trim() + "'"
                );

            if (tablaUsuario != null &&
                tablaUsuario.Rows.Count > 0)
            {
                MessageBox.Show(
                    "El nombre de usuario ya existe. Genere uno nuevo.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
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
        private byte[] GenerarHash(string contrasena,byte[] salt)
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
        private void BloquearDatosEntrenador(bool bloquear)
        {
            txtNombres.ReadOnly = bloquear;
            txtApellidos.ReadOnly = bloquear;
            txtCedula.ReadOnly = bloquear;
            txtDireccion.ReadOnly = bloquear;
            txtTelefono.ReadOnly = bloquear;
            txtCorreo.ReadOnly = bloquear;

            dtpFechaNacimiento.Enabled = !bloquear;

            rbMasculino.Enabled = !bloquear;
            rbFemenino.Enabled = !bloquear;

            btnSubirFoto.Enabled = !bloquear;
        }
        private byte[] PrepararFotoParaGuardar(Image imagen)
        {
            if (imagen == null)
                return null;

            // Reducimos la imagen antes de guardarla
            using (Bitmap imagenReducida =
                   new Bitmap(imagen, new Size(300, 300)))
            {
                using (MemoryStream ms =
                       new MemoryStream())
                {
                    // JPG pesa mucho menos que PNG
                    imagenReducida.Save(
                        ms,
                        System.Drawing.Imaging.ImageFormat.Jpeg);

                    return ms.ToArray();
                }
            }
        }
    }
    
 }
