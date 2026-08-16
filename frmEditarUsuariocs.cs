using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmEditarUsuariocs : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        private int idUsuario;
        private int idRolOriginal;
        private int? idEntrenadorActual;
        private string cedulaUsuario;
        public frmEditarUsuariocs()
        {
            InitializeComponent();
        }
        public frmEditarUsuariocs(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            txtTelefono.MaxLength = 10;
            CargarRoles();
            CargarUsuario();
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
        private void CargarRoles()
        {
            DataTable tablaRoles =
                conSQL.RetornaRegistros(
                    @"SELECT
                        IdRol,
                        NombreRol
                      FROM Roles
                      WHERE Activo = 1
                      ORDER BY NombreRol"
                );

            if (tablaRoles == null)
                return;


            cmbRol.DataSource =
                tablaRoles;

            cmbRol.DisplayMember =
                "NombreRol";

            cmbRol.ValueMember =
                "IdRol";

            cmbRol.SelectedIndex =
                -1;

            cmbRol.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }

        private void CargarUsuario()
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                U.Cedula,
                U.Nombres,
                U.Apellidos,
                U.Telefono,
                U.Correo,
                U.Direccion,
                U.Foto,
                U.IdRol,
                U.IdEntrenador
              FROM Usuarios U
              WHERE U.IdUsuario = " + idUsuario
                );

            if (tabla == null ||
                tabla.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró el usuario.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRow fila =
                tabla.Rows[0];

            cedulaUsuario =
                fila["Cedula"].ToString();

            idRolOriginal =
                Convert.ToInt32(
                    fila["IdRol"]);

            if (fila["IdEntrenador"] != DBNull.Value)
            {
                idEntrenadorActual =
                    Convert.ToInt32(
                        fila["IdEntrenador"]);
            }
            else
            {
                idEntrenadorActual = null;
            }

            txtNombres.Text =
                fila["Nombres"].ToString();

            txtApellidos.Text =
                fila["Apellidos"].ToString();

            txtTelefono.Text =
                fila["Telefono"].ToString();

            txtCorreo.Text =
                fila["Correo"].ToString();

            txtDireccion.Text =
                fila["Direccion"].ToString();

            cmbRol.SelectedValue =
                idRolOriginal;


            // FOTO
            if (fila["Foto"] != DBNull.Value)
            {
                byte[] bytesFoto =
                    (byte[])fila["Foto"];

                using (MemoryStream ms =
                       new MemoryStream(bytesFoto))
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
            if (idEntrenadorActual.HasValue)
            {
                BloquearDatosEntrenador(true);
            }
            else
            {
                BloquearDatosEntrenador(false);
            }
        }

        private void BloquearDatosEntrenador(bool bloquear)
        {
            txtNombres.ReadOnly = bloquear;
            txtApellidos.ReadOnly = bloquear;
            txtTelefono.ReadOnly = bloquear;
            txtDireccion.ReadOnly = bloquear;
            txtCorreo.ReadOnly = bloquear;

            btnSubirFoto.Enabled = !bloquear;
        }
        private bool TieneDeportistasActivos(int idEntrenador)
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                COUNT(*) AS Cantidad
              FROM Inscripciones I
              INNER JOIN EntrenadorDeporte ED
                  ON I.IdEntrenadorDeporte =
                     ED.IdEntrenadorDeporte
              WHERE ED.IdEntrenador = " +
                      idEntrenador +
                      @" AND I.Estado = 'Activa'"
                );

            if (tabla == null ||
                tabla.Rows.Count == 0)
            {
                return false;
            }

            int cantidad =
                Convert.ToInt32(
                    tabla.Rows[0]["Cantidad"]);

            return cantidad > 0;
        }
        private bool ValidarCambioRol()
        {
            string rolNuevo =
                cmbRol.Text;

            // Si era entrenador y quiere dejar de serlo
            if (idEntrenadorActual.HasValue &&
                rolNuevo != "Entrenador")
            {
                if (TieneDeportistasActivos(
                    idEntrenadorActual.Value))
                {
                    MessageBox.Show(
                        "No se puede cambiar el rol de este entrenador.\n\n" +
                        "Tiene deportistas activos asignados.\n" +
                        "Primero debe realizar la reasignación o reemplazo " +
                        "desde Gestión de Entrenadores.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return false;
                }
            }

            return true;
        }

        private bool ValidarCampos()
        {
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
            // NOMBRES
            // ==========================================
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


            // ==========================================
            // APELLIDOS
            // ==========================================
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


            // ==========================================
            // TELÉFONO
            // ==========================================
            string telefono =
                txtTelefono.Text.Trim();

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
            string correo =
                txtCorreo.Text.Trim();

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


            // ==========================================
            // CORREO REPETIDO
            // ==========================================
            DataTable tablaCorreo =
                conSQL.RetornaRegistros(
                    "SELECT IdUsuario " +
                    "FROM Usuarios " +
                    "WHERE Correo = '" +
                    correo.Replace("'", "''") +
                    "' AND IdUsuario <> " +
                    idUsuario
                );

            if (tablaCorreo != null &&
                tablaCorreo.Rows.Count > 0)
            {
                MessageBox.Show(
                    "Ya existe otro usuario con ese correo electrónico.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();
                return false;
            }

            return true;
        }
        private string ObtenerFotoSQL()
        {
            if (picFoto.Image == null)
                return "NULL";

            using (MemoryStream ms = new MemoryStream())
            {
                picFoto.Image.Save(
                    ms,
                    System.Drawing.Imaging.ImageFormat.Png);

                byte[] fotoBytes = ms.ToArray();

                return "0x" +
                    BitConverter.ToString(fotoBytes)
                    .Replace("-", "");
            }
        }

        private void frmEditarUsuariocs_Load(object sender, EventArgs e)
        {

        }
        private void btnAgregarDeporte_Click(object sender, EventArgs e)
        {
            
        }

        private void btnQuitarDeporte_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
       

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
        !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private int? BuscarEntrenadorPorCedula()
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    "SELECT IdEntrenador " +
                    "FROM Entrenadores " +
                    "WHERE Cedula = '" +
                    cedulaUsuario.Replace("'", "''") + "'"
                );

            if (tabla == null ||
                tabla.Rows.Count == 0)
            {
                return null;
            }

            return Convert.ToInt32(
                tabla.Rows[0]["IdEntrenador"]);
        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Validaciones normales
            if (!ValidarCampos())
                return;

            // Validación especial si era entrenador
            if (!ValidarCambioRol())
                return;


            int idRolNuevo =
                Convert.ToInt32(cmbRol.SelectedValue);

            string rolNuevo =
                cmbRol.Text;

            string idEntrenadorSQL = "NULL";

            // SI YA ERA ENTRENADOR

            if (idEntrenadorActual.HasValue)
            {
                if (rolNuevo == "Entrenador")
                {
                    // Sigue vinculado al mismo entrenador
                    idEntrenadorSQL =
                        idEntrenadorActual.Value.ToString();
                }
                else
                {
                    // Dejó de ser entrenador
                    idEntrenadorSQL = "NULL";
                }
            }


            // OTRO ROL INTENTA PASAR A ENTRENADOR

            if (!idEntrenadorActual.HasValue && rolNuevo == "Entrenador")
            {
                int? idEntrenadorEncontrado =
                    BuscarEntrenadorPorCedula();

                if (!idEntrenadorEncontrado.HasValue)
                {
                    MessageBox.Show(
                        "Esta persona no está registrada como entrenador.\n\n" +
                        "Primero debe registrarla desde Gestión de Entrenadores " +
                        "y después asignarle el rol Entrenador.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // VERIFICAR QUE NO TENGA OTRA CUENTA
                if (EntrenadorTieneOtraCuenta(
                    idEntrenadorEncontrado.Value))
                {
                    MessageBox.Show(
                        "Este entrenador ya tiene una cuenta de usuario asociada.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                idEntrenadorSQL =
                    idEntrenadorEncontrado.Value.ToString();
            }


            // FOTO
            string fotoSQL =
                ObtenerFotoSQL();


            // CAMPOS A ACTUALIZAR

            string campos;
            if (idEntrenadorActual.HasValue)
            {
                campos =
                    "IdRol = " + idRolNuevo + ", " +
                    "IdEntrenador = " + idEntrenadorSQL;
            }
            else
            {
                campos =
                    "Nombres = '" +
                    txtNombres.Text.Trim()
                    .Replace("'", "''") + "', " +

                    "Apellidos = '" +
                    txtApellidos.Text.Trim()
                    .Replace("'", "''") + "', " +

                    "Telefono = '" +
                    txtTelefono.Text.Trim() + "', " +

                    "Direccion = '" +
                    txtDireccion.Text.Trim()
                    .Replace("'", "''") + "', " +

                    "Correo = '" +
                    txtCorreo.Text.Trim()
                    .Replace("'", "''") + "', " +

                    "Foto = " +
                    fotoSQL + ", " +

                    "IdRol = " +
                    idRolNuevo + ", " +

                    "IdEntrenador = " +
                    idEntrenadorSQL;
            }


            // CONFIRMAR

            DialogResult respuesta =
                MessageBox.Show(
                    "¿Desea guardar los cambios realizados?",
                    "ZENOVA",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;


            // ACTUALIZAR

            string sentencia =
                "UPDATE Usuarios SET " +
                campos +
                " WHERE IdUsuario = " +
                idUsuario;


            if (conSQL.EjecutaSentenciaSRD(sentencia))
            {
                MessageBox.Show(
                    "Usuario actualizado correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
        }
        private bool EntrenadorTieneOtraCuenta(int idEntrenador)
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT IdUsuario
              FROM Usuarios
              WHERE IdEntrenador = " + idEntrenador +
                      @" AND IdUsuario <> " + idUsuario
                );

            if (tabla == null)
                return false;

            return tabla.Rows.Count > 0;
        }
    }
}
