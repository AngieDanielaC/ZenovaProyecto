using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmNuevoEmpleado : Form
    {
        // ==========================================
        // VARIABLES
        // ==========================================
        private int tipo; // 1 = nuevo, 2 = editar

        private int idEmpleado;

        private bool fotoSeleccionada = false;

        csConectaSQL conSQL =
            new csConectaSQL();


        // ==========================================
        // CONSTRUCTOR NUEVO
        // ==========================================
        public frmNuevoEmpleado()
        {
            InitializeComponent();

            tipo = 1;

            lblTitulo.Text =
                "REGISTRAR EMPLEADO";

            btnGuardar.Text =
                "Guardar";

            ConfigurarFormulario();
        }


        // ==========================================
        // CONSTRUCTOR EDITAR
        // ==========================================
        public frmNuevoEmpleado(int idEmpleado)
        {
            InitializeComponent();

            tipo = 2;

            this.idEmpleado =
                idEmpleado;

            lblTitulo.Text =
                "EDITAR EMPLEADO";

            btnGuardar.Text =
                "Guardar cambios";

            ConfigurarFormulario();

            CargarEmpleado();
        }


        // ==========================================
        // CONFIGURAR FORMULARIO
        // ==========================================
        private void ConfigurarFormulario()
        {
            txtCedula.MaxLength = 10;

            txtTelefono.MaxLength = 10;

            dtpFechaNacimiento.MaxDate =
                DateTime.Today;

            picFoto.SizeMode =
                PictureBoxSizeMode.Zoom;
        }


        // ==========================================
        // CARGAR EMPLEADO
        // SOLO SE USA AL EDITAR
        // ==========================================
        private void CargarEmpleado()
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                        Cedula,
                        Nombres,
                        Apellidos,
                        FechaNacimiento,
                        Genero,
                        Telefono,
                        Correo,
                        Direccion,
                        Foto
                      FROM Empleados
                      WHERE IdEmpleado = " +
                    idEmpleado
                );


            if (tabla == null ||
                tabla.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró el empleado.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            DataRow fila =
                tabla.Rows[0];


            txtCedula.Text =
                fila["Cedula"].ToString();


            txtNombres.Text =
                fila["Nombres"].ToString();


            txtApellidos.Text =
                fila["Apellidos"].ToString();


            if (fila["FechaNacimiento"] != DBNull.Value)
            {
                dtpFechaNacimiento.Value =
                    Convert.ToDateTime(
                        fila["FechaNacimiento"]);
            }


            txtTelefono.Text =
                fila["Telefono"].ToString();


            txtCorreo.Text =
                fila["Correo"].ToString();


            txtDireccion.Text =
                fila["Direccion"].ToString();


            // ==========================================
            // GÉNERO
            // ==========================================
            string genero =
                fila["Genero"].ToString();


            rbMasculino.Checked =
                genero == "Masculino";


            rbFemenino.Checked =
                genero == "Femenino";


            // ==========================================
            // FOTO
            // ==========================================
            if (fila["Foto"] != DBNull.Value)
            {
                try
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


                    // IMPORTANTE:
                    // la foto cargada desde BD
                    // cuenta como foto válida
                    fotoSeleccionada = true;
                }
                catch
                {
                    picFoto.Image = null;

                    fotoSeleccionada = false;
                }
            }
            else
            {
                picFoto.Image = null;

                fotoSeleccionada = false;
            }
        }


        // ==========================================
        // VALIDAR CAMPOS
        // ==========================================
        private bool ValidarCampos()
        {
            // CÉDULA
            if (txtCedula.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese la cédula.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCedula.Focus();

                return false;
            }


            if (txtCedula.Text.Trim().Length != 10)
            {
                MessageBox.Show(
                    "La cédula debe tener 10 dígitos.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCedula.Focus();

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


            // FECHA NACIMIENTO
            if (dtpFechaNacimiento.Value.Date >
                DateTime.Today)
            {
                MessageBox.Show(
                    "La fecha de nacimiento no puede ser futura.",
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


            // TELÉFONO
            if (txtTelefono.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese el teléfono.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTelefono.Focus();

                return false;
            }


            if (txtTelefono.Text.Trim().Length != 10)
            {
                MessageBox.Show(
                    "El teléfono debe tener 10 dígitos.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTelefono.Focus();

                return false;
            }


            // CORREO
            if (txtCorreo.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese el correo.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();

                return false;
            }


            if (!txtCorreo.Text.Contains("@") ||
                !txtCorreo.Text.Contains("."))
            {
                MessageBox.Show(
                    "Ingrese un correo válido.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();

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


            // FOTO
            if (!fotoSeleccionada ||
                picFoto.Image == null)
            {
                MessageBox.Show(
                    "Seleccione una foto.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }


            return true;
        }


        // ==========================================
        // VALIDAR DUPLICADOS
        // ==========================================
        private bool ExisteDuplicado()
        {
            string condicionEditar = "";

            if (tipo == 2)
            {
                condicionEditar =
                    " AND IdEmpleado <> " +
                    idEmpleado;
            }


            string cedula =
                txtCedula.Text.Trim()
                .Replace("'", "''");


            string correo =
                txtCorreo.Text.Trim()
                .Replace("'", "''");


            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                        IdEmpleado

                      FROM Empleados

                      WHERE
                      (
                          Cedula = '" +
                    cedula +
                    @"'

                          OR Correo = '" +
                    correo +
                    @"'
                      )

                      " +
                    condicionEditar
                );


            if (tabla != null &&
                tabla.Rows.Count > 0)
            {
                MessageBox.Show(
                    "Ya existe un empleado con esa cédula o correo.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return true;
            }


            return false;
        }


        // ==========================================
        // IMAGEN A BYTES
        // ==========================================
        private byte[] ImagenABytes(Image imagen)
        {
            if (imagen == null)
                return null;


            using (MemoryStream ms =
                   new MemoryStream())
            {
                imagen.Save(
                    ms,
                    System.Drawing.Imaging
                    .ImageFormat.Png);


                return ms.ToArray();
            }
        }


        // ==========================================
        // SELECCIONAR FOTO
        // ==========================================
        private void btnSeleccionarFoto_Click(
            object sender,
            EventArgs e)
        {
            OpenFileDialog dialogo =
                new OpenFileDialog();


            dialogo.Filter =
                "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";


            if (dialogo.ShowDialog() ==
                DialogResult.OK)
            {
                using (Image imagen =
                       Image.FromFile(
                           dialogo.FileName))
                {
                    picFoto.Image =
                        new Bitmap(imagen);
                }


                picFoto.SizeMode =
                    PictureBoxSizeMode.Zoom;


                fotoSeleccionada = true;
            }
        }


        // ==========================================
        // GUARDAR
        // ==========================================
        private void btnGuardar_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidarCampos())
                return;


            if (ExisteDuplicado())
                return;


            string genero =
                rbMasculino.Checked
                ? "Masculino"
                : "Femenino";


            byte[] fotoBytes =
                ImagenABytes(
                    picFoto.Image);


            string fotoSQL =
                "NULL";


            if (fotoBytes != null)
            {
                fotoSQL =
                    "0x" +
                    BitConverter
                    .ToString(fotoBytes)
                    .Replace("-", "");
            }


            // ==========================================
            // REGISTRAR
            // ==========================================
            if (tipo == 1)
            {
                string campos =
                    "Cedula, " +
                    "Nombres, " +
                    "Apellidos, " +
                    "FechaNacimiento, " +
                    "Genero, " +
                    "Telefono, " +
                    "Correo, " +
                    "Direccion, " +
                    "Foto, " +
                    "Estado";


                string datos =
                    "'" +
                    txtCedula.Text.Trim()
                    .Replace("'", "''") +
                    "'," +

                    "'" +
                    txtNombres.Text.Trim()
                    .Replace("'", "''") +
                    "'," +

                    "'" +
                    txtApellidos.Text.Trim()
                    .Replace("'", "''") +
                    "'," +

                    "'" +
                    dtpFechaNacimiento.Value
                    .ToString("yyyy-MM-dd") +
                    "'," +

                    "'" +
                    genero +
                    "'," +

                    "'" +
                    txtTelefono.Text.Trim()
                    .Replace("'", "''") +
                    "'," +

                    "'" +
                    txtCorreo.Text.Trim()
                    .Replace("'", "''") +
                    "'," +

                    "'" +
                    txtDireccion.Text.Trim()
                    .Replace("'", "''") +
                    "'," +

                    fotoSQL +
                    "," +

                    "1";


                if (conSQL.insertDatos(
                    "Empleados",
                    campos,
                    datos))
                {
                    MessageBox.Show(
                        "Empleado registrado correctamente.",
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
                        "No se pudo registrar el empleado.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }


            // ==========================================
            // EDITAR
            // ==========================================
            else
            {
                string sentencia =
                    @"UPDATE Empleados

                      SET
                        Cedula = '" +
                    txtCedula.Text.Trim()
                    .Replace("'", "''") +
                    @"',

                        Nombres = '" +
                    txtNombres.Text.Trim()
                    .Replace("'", "''") +
                    @"',

                        Apellidos = '" +
                    txtApellidos.Text.Trim()
                    .Replace("'", "''") +
                    @"',

                        FechaNacimiento = '" +
                    dtpFechaNacimiento.Value
                    .ToString("yyyy-MM-dd") +
                    @"',

                        Genero = '" +
                    genero +
                    @"',

                        Telefono = '" +
                    txtTelefono.Text.Trim()
                    .Replace("'", "''") +
                    @"',

                        Correo = '" +
                    txtCorreo.Text.Trim()
                    .Replace("'", "''") +
                    @"',

                        Direccion = '" +
                    txtDireccion.Text.Trim()
                    .Replace("'", "''") +
                    @"',

                        Foto = " +
                    fotoSQL +

                    @"

                      WHERE
                        IdEmpleado = " +
                    idEmpleado;


                if (conSQL.EjecutaSentenciaSRD(
                    sentencia))
                {
                    MessageBox.Show(
                        "Empleado actualizado correctamente.",
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
                        "No se pudo actualizar el empleado.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }


        // ==========================================
        // SOLO NÚMEROS CÉDULA
        // ==========================================
        private void txtCedula_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        // ==========================================
        // SOLO NÚMEROS TELÉFONO
        // ==========================================
        private void txtTelefono_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
