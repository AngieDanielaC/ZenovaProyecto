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

namespace wfZenova
{
    public partial class frmNuevoUsuario : Form
    {
        private List<int> deportesSeleccionados = new List<int>();
        public frmNuevoUsuario()
        {
            InitializeComponent();
        }
        private void CargarRoles()
        {
            csConectaSQL conexion = new csConectaSQL();

            if (conexion.abrirConexion())
            {
                try
                {
                    string consulta =
                        "SELECT IdRol, NombreRol " +
                        "FROM Roles " +
                        "WHERE Activo = 1 " +
                        "ORDER BY NombreRol";

                    SqlDataAdapter adaptador =
                        new SqlDataAdapter(consulta, conexion.oCon);

                    DataTable tabla = new DataTable();

                    adaptador.Fill(tabla);

                    cmbRol.DataSource = tabla;

                    cmbRol.DisplayMember = "NombreRol";
                    cmbRol.ValueMember = "IdRol";

                    cmbDeporte.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al cargar los roles:\n" + ex.Message);
                }
                finally
                {
                    conexion.cerrarConexion();
                }
            }
        }
        private void CargarDeportes()
        {
            csConectaSQL conexion = new csConectaSQL();

            if (conexion.abrirConexion())
            {
                try
                {
                    string consulta =
                        "SELECT IdDeporte, NombreDeporte " +
                        "FROM Deportes " +
                        "WHERE Activo = 1 " +
                        "ORDER BY NombreDeporte";

                    SqlDataAdapter adaptador =
                        new SqlDataAdapter(consulta, conexion.oCon);

                    DataTable tabla = new DataTable();

                    adaptador.Fill(tabla);

                    cmbDeporte.DataSource = tabla;
                    cmbDeporte.DisplayMember = "NombreDeporte";
                    cmbDeporte.ValueMember = "IdDeporte";
                    cmbDeporte.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al cargar los deportes:\n" + ex.Message);
                }
                finally
                {
                    conexion.cerrarConexion();
                }
            }
        }

        private void frmNuevoUsuario_Load(object sender, EventArgs e)
        {
            txtCedula.MaxLength = 10;
            txtTelefono.MaxLength = 10;
            pnlDatosEntrenador.Visible = false;
            CargarRoles();
            cmbRol.SelectedIndex = -1;
            cmbDeporte.SelectedIndex = -1;
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRol.SelectedIndex == -1)
            {
                pnlDatosEntrenador.Visible = false;
                return;
            }

            string rolSeleccionado = cmbRol.Text;

            if (rolSeleccionado == "Entrenador")
            {
                pnlDatosEntrenador.Visible = true;

                CargarDeportes();
            }
            else
            {
                pnlDatosEntrenador.Visible = false;

                cmbDeporte.SelectedIndex = -1;
            }
        }

        private void btnAgregarDeporte_Click(object sender, EventArgs e)
        {
            if (cmbDeporte.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un deporte.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idDeporte = Convert.ToInt32(cmbDeporte.SelectedValue);
            string nombreDeporte = cmbDeporte.Text;

            // Evitar deportes repetidos
            if (deportesSeleccionados.Contains(idDeporte))
            {
                MessageBox.Show(
                    "Este deporte ya fue agregado.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            deportesSeleccionados.Add(idDeporte);

            lstDeportes.Items.Add(nombreDeporte);

            // Dejar nuevamente vacío el ComboBox
            cmbDeporte.SelectedIndex = -1;
        }

        private void btnQuitarDeporte_Click(object sender, EventArgs e)
        {
            if (lstDeportes.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione el deporte que desea quitar.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int posicion = lstDeportes.SelectedIndex;

            deportesSeleccionados.RemoveAt(posicion);

            lstDeportes.Items.RemoveAt(posicion);
        }
        private string ObtenerGenero()
        {
            if (rbMasculino.Checked)
            {
                return "Masculino";
            }

            if (rbFemenino.Checked)
            {
                return "Femenino";
            }

            return "";
        }
        private string GenerarNombreUsuario()
        {
            string nombres =
                txtNombres.Text.Trim();

            string apellidos =
                txtApellidos.Text.Trim();

            if (nombres == "" || apellidos == "")
            {
                return "";
            }

            string primeraLetra =
                nombres.Substring(0, 1).ToLower();

            string primerApellido =
                apellidos.Split(' ')[0].ToLower();

            string usuarioBase =
                primeraLetra + primerApellido;

            string usuarioFinal =
                usuarioBase;

            int numero = 1;

            csConectaSQL conexion =
                new csConectaSQL();

            if (conexion.abrirConexion())
            {
                try
                {
                    while (true)
                    {
                        string consulta =
                            "SELECT COUNT(*) " +
                            "FROM Usuarios " +
                            "WHERE NombreUsuario = @Usuario";

                        SqlCommand comando =
                            new SqlCommand(
                                consulta,
                                conexion.oCon);

                        comando.Parameters.AddWithValue(
                            "@Usuario",
                            usuarioFinal);

                        int cantidad =
                            Convert.ToInt32(
                                comando.ExecuteScalar());

                        if (cantidad == 0)
                        {
                            break;
                        }

                        numero++;

                        usuarioFinal =
                            usuarioBase + numero;
                    }
                }
                finally
                {
                    conexion.cerrarConexion();
                }
            }

            return usuarioFinal;
        }
        private string GenerarContrasenaTemporal()
        {
            const string caracteres =
                "ABCDEFGHJKLMNPQRSTUVWXYZ" +
                "abcdefghijkmnopqrstuvwxyz" +
                "23456789";

            Random random = new Random();

            string clave = "";

            for (int i = 0; i < 8; i++)
            {
                int posicion =
                    random.Next(caracteres.Length);

                clave += caracteres[posicion];
            }

            return clave;
        }
        private byte[] GenerarSalt()
        {
            byte[] salt = new byte[16];

            using (RNGCryptoServiceProvider rng =
                   new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
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
                return pbkdf2.GetBytes(32);
            }
        }
        private bool ValidarCampos()
        {
            // ==========================================
            // CÉDULA
            // ==========================================
            string cedula = txtCedula.Text.Trim();

            if (cedula == "")
            {
                MessageBox.Show(
                    "Ingrese la cédula.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCedula.Focus();
                return false;
            }

            if (cedula.Length != 10 || !cedula.All(char.IsDigit))
            {
                MessageBox.Show(
                    "La cédula debe contener exactamente 10 dígitos numéricos.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCedula.Focus();
                return false;
            }


            // ==========================================
            // NOMBRES
            // ==========================================
            string nombres = txtNombres.Text.Trim();

            if (nombres == "")
            {
                MessageBox.Show(
                    "Ingrese los nombres.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombres.Focus();
                return false;
            }

            if (nombres.Length < 2)
            {
                MessageBox.Show(
                    "Ingrese un nombre válido.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombres.Focus();
                return false;
            }

            if (!nombres.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show(
                    "Los nombres solo pueden contener letras.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombres.Focus();
                return false;
            }


            // ==========================================
            // APELLIDOS
            // ==========================================
            string apellidos = txtApellidos.Text.Trim();

            if (apellidos == "")
            {
                MessageBox.Show(
                    "Ingrese los apellidos.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtApellidos.Focus();
                return false;
            }

            if (apellidos.Length < 2)
            {
                MessageBox.Show(
                    "Ingrese un apellido válido.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtApellidos.Focus();
                return false;
            }

            if (!apellidos.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show(
                    "Los apellidos solo pueden contener letras.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtApellidos.Focus();
                return false;
            }


            // ==========================================
            // FECHA DE NACIMIENTO
            // ==========================================
            if (dtpFechaNacimiento.Value.Date >= DateTime.Today)
            {
                MessageBox.Show(
                    "La fecha de nacimiento no puede ser igual o posterior a la fecha actual.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtpFechaNacimiento.Focus();
                return false;
            }


            // ==========================================
            // GÉNERO
            // ==========================================
            if (!rbMasculino.Checked && !rbFemenino.Checked)
            {
                MessageBox.Show(
                    "Seleccione el género.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }


            // ==========================================
            // TELÉFONO
            // ==========================================
            string telefono = txtTelefono.Text.Trim();

            if (telefono == "")
            {
                MessageBox.Show(
                    "Ingrese el número de teléfono.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTelefono.Focus();
                return false;
            }

            if (telefono.Length != 10 || !telefono.All(char.IsDigit))
            {
                MessageBox.Show(
                    "El teléfono debe contener exactamente 10 dígitos numéricos.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTelefono.Focus();
                return false;
            }


            // ==========================================
            // DIRECCIÓN
            // ==========================================
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


            // ==========================================
            // CORREO
            // ==========================================
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
                System.Net.Mail.MailAddress direccionCorreo =
                    new System.Net.Mail.MailAddress(correo);

                if (direccionCorreo.Address != correo)
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show(
                    "Ingrese un correo electrónico válido.\nEjemplo: usuario@correo.com",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();
                return false;
            }


            // ==========================================
            // ROL
            // ==========================================
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


            // ==========================================
            // ENTRENADOR
            // ==========================================
            if (cmbRol.Text == "Entrenador" &&
                deportesSeleccionados.Count == 0)
            {
                MessageBox.Show(
                    "Debe agregar al menos un deporte para el entrenador.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbDeporte.Focus();
                return false;
            }


            // ==========================================
            // CREDENCIALES
            // ==========================================
            if (lblUsuario.Text == "Pendiente de generar" ||
                lblContrasena.Text == "Pendiente de generar" ||
                string.IsNullOrWhiteSpace(lblUsuario.Text) ||
                string.IsNullOrWhiteSpace(lblContrasena.Text))
            {
                MessageBox.Show(
                    "Debe generar las credenciales antes de guardar el usuario.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }


            return true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGenerarCredenciales_Click(object sender, EventArgs e)
        {
            if (txtNombres.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese los nombres antes de generar las credenciales.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombres.Focus();
                return;
            }

            if (txtApellidos.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese los apellidos antes de generar las credenciales.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtApellidos.Focus();
                return;
            }

            // Generar automáticamente
            string usuario = GenerarNombreUsuario();
            string contrasena = GenerarContrasenaTemporal();

            // Mostrar en los Labels
            lblUsuario.Text = usuario;
            lblContrasena.Text = contrasena;

            MessageBox.Show(
                "Credenciales generadas correctamente.",
                "ZENOVA",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

            // 1. VALIDAR CAMPOS
            if (!ValidarCampos())
            {
                return;
            }

            // Verificar que primero se hayan generado
            // las credenciales
            if (lblUsuario.Text == "Pendiente de generar" ||
                lblContrasena.Text == "Pendiente de generar" ||
                string.IsNullOrWhiteSpace(lblUsuario.Text) ||
                string.IsNullOrWhiteSpace(lblContrasena.Text))
            {
                MessageBox.Show(
                    "Primero debe generar las credenciales del usuario.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // 2. TOMAR DATOS DEL FORMULARIO

            string usuario = lblUsuario.Text.Trim();

            string contrasenaTemporal =
                lblContrasena.Text.Trim();

            string genero = ObtenerGenero();

            int idRol =
                Convert.ToInt32(cmbRol.SelectedValue);

            // 3. PROTEGER CONTRASEÑA

            byte[] salt = GenerarSalt();

            byte[] hash =
                GenerarHash(
                    contrasenaTemporal,
                    salt);

            // 4. ABRIR CONEXIÓN


            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
            {
                return;
            }


            SqlTransaction transaccion =
                conexion.oCon.BeginTransaction();


            try
            {
                // 5. GUARDAR USUARIO


                string sqlUsuario = @"
                    INSERT INTO Usuarios
                    (
                        Cedula,
                        Nombres,
                        Apellidos,
                        FechaNacimiento,
                        Genero,
                        Direccion,
                        Telefono,
                        Correo,
                        Foto,
                        IdRol,
                        NombreUsuario,
                        PasswordHash,
                        PasswordSalt,
                        DebeCambiarPassword,
                        EstadoCuenta
                    )
                    VALUES
                    (
                        @Cedula,
                        @Nombres,
                        @Apellidos,
                        @FechaNacimiento,
                        @Genero,
                        @Direccion,
                        @Telefono,
                        @Correo,
                        @Foto,
                        @IdRol,
                        @NombreUsuario,
                        @PasswordHash,
                        @PasswordSalt,
                        1,
                        1
                    );

                    SELECT SCOPE_IDENTITY();
                    ";


                SqlCommand cmdUsuario =
                    new SqlCommand(
                        sqlUsuario,
                        conexion.oCon,
                        transaccion);


                // Cédula
                cmdUsuario.Parameters.AddWithValue(
                    "@Cedula",
                    txtCedula.Text.Trim());


                // Nombres
                cmdUsuario.Parameters.AddWithValue(
                    "@Nombres",
                    txtNombres.Text.Trim());


                // Apellidos
                cmdUsuario.Parameters.AddWithValue(
                    "@Apellidos",
                    txtApellidos.Text.Trim());


                // Fecha de nacimiento
                cmdUsuario.Parameters.AddWithValue(
                    "@FechaNacimiento",
                    dtpFechaNacimiento.Value.Date);


                // Género
                cmdUsuario.Parameters.AddWithValue(
                    "@Genero",
                    genero);


                // Dirección
                cmdUsuario.Parameters.AddWithValue(
                    "@Direccion",
                    txtDireccion.Text.Trim());


                // Teléfono
                cmdUsuario.Parameters.AddWithValue(
                    "@Telefono",
                    txtTelefono.Text.Trim());


                // Correo
                cmdUsuario.Parameters.AddWithValue(
                    "@Correo",
                    txtCorreo.Text.Trim());

                // Foto
                byte[] foto = ImagenABytes(picFoto.Image);

                if (foto != null)
                {
                    cmdUsuario.Parameters.Add(
                        "@Foto",
                        SqlDbType.VarBinary).Value = foto;
                }
                else
                {
                    cmdUsuario.Parameters.Add(
                        "@Foto",
                        SqlDbType.VarBinary).Value = DBNull.Value;
                }

                // Rol
                cmdUsuario.Parameters.AddWithValue(
                    "@IdRol",
                    idRol);


                // Usuario generado
                cmdUsuario.Parameters.AddWithValue(
                    "@NombreUsuario",
                    usuario);


                // Hash de contraseña
                cmdUsuario.Parameters.Add(
                    "@PasswordHash",
                    SqlDbType.VarBinary,
                    32).Value = hash;


                // Salt
                cmdUsuario.Parameters.Add(
                    "@PasswordSalt",
                    SqlDbType.VarBinary,
                    16).Value = salt;

                // OBTENER ID DEL NUEVO USUARIO

                int idUsuario =
                    Convert.ToInt32(
                        cmdUsuario.ExecuteScalar());

                // 6. SI EL USUARIO ES ENTRENADOR


                if (cmbRol.Text == "Entrenador")
                {
                    string sqlEntrenador = @"
            INSERT INTO Entrenadores
            (
                IdUsuario,
                EstadoEntrenador
            )
            VALUES
            (
                @IdUsuario,
                'Activo'
            );

            SELECT SCOPE_IDENTITY();
            ";


                    SqlCommand cmdEntrenador =
                        new SqlCommand(
                            sqlEntrenador,
                            conexion.oCon,
                            transaccion);


                    cmdEntrenador.Parameters.AddWithValue(
                        "@IdUsuario",
                        idUsuario);


                    int idEntrenador =
                        Convert.ToInt32(
                            cmdEntrenador.ExecuteScalar());


                    // ==================================
                    // 7. GUARDAR DEPORTES
                    // ==================================

                    foreach (int idDeporte
                             in deportesSeleccionados)
                    {
                        string sqlDeporte = @"
                INSERT INTO EntrenadorDeporte
                (
                    IdEntrenador,
                    IdDeporte,
                    Activo
                )
                VALUES
                (
                    @IdEntrenador,
                    @IdDeporte,
                    1
                )";


                        SqlCommand cmdDeporte =
                            new SqlCommand(
                                sqlDeporte,
                                conexion.oCon,
                                transaccion);


                        cmdDeporte.Parameters.AddWithValue(
                            "@IdEntrenador",
                            idEntrenador);


                        cmdDeporte.Parameters.AddWithValue(
                            "@IdDeporte",
                            idDeporte);


                        cmdDeporte.ExecuteNonQuery();
                    }
                }

                // 8. CONFIRMAR TODO


                transaccion.Commit();

                // 9. MENSAJE FINAL

                MessageBox.Show(
                    "Usuario registrado correctamente.\n\n" +
                    "Usuario: " + usuario + "\n" +
                    "Contraseña temporal: " +
                    contrasenaTemporal,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            // ERROR DE SQL
            catch (SqlException ex)
            {
                transaccion.Rollback();

                // Dato UNIQUE repetido
                if (ex.Number == 2627 ||
                    ex.Number == 2601)
                {
                    MessageBox.Show(
                        "Ya existe un usuario con esa cédula, " +
                        "correo o nombre de usuario.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Error al registrar el usuario:\n\n" +
                        ex.Message,
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                transaccion.Rollback();

                MessageBox.Show(
                    "Error al registrar el usuario:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            // 10. CERRAR CONEXIÓN
            finally
            {
                conexion.cerrarConexion();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
        !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
        !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSeleccionarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();

            dialogo.Filter =
                "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                picFoto.Image =
                    Image.FromFile(dialogo.FileName);

                picFoto.SizeMode =
                    PictureBoxSizeMode.Zoom;
            }
        }
        private byte[] ImagenABytes(Image imagen)
        {
            if (imagen == null)
                return null;

            using (MemoryStream ms = new MemoryStream())
            {
                imagen.Save(
                    ms,
                    System.Drawing.Imaging.ImageFormat.Png);

                return ms.ToArray();
            }
        }
    }
    
 }
