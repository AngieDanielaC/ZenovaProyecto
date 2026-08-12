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
using System.IO;


namespace wfZenova
{
    public partial class frmRegistroDeportistaAdm : Form
    {
        public frmRegistroDeportistaAdm()
        {
            InitializeComponent();
        }

        private void btnGuardarDep_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            string genero = ObtenerGenero();
            byte[] foto = ImagenABytes(picFoto.Image);

            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            INSERT INTO Deportistas
            (
                Nombres,
                Apellidos,
                Cedula,
                FechaNacimiento,
                Genero,
                Direccion,
                Telefono,
                Correo,
                Foto,
                NombreContactoEmergencia,
                TelefonoEmergencia,
                ParentescoEmergencia,
                Estado
            )
            VALUES
            (
                @Nombres,
                @Apellidos,
                @Cedula,
                @FechaNacimiento,
                @Genero,
                @Direccion,
                @Telefono,
                @Correo,
                @Foto,
                @NombreContactoEmergencia,
                @TelefonoEmergencia,
                @ParentescoEmergencia,
                1
            );
        ";

                SqlCommand comando =
                    new SqlCommand(
                        consulta,
                        conexion.oCon);

                comando.Parameters.AddWithValue(
                    "@Nombres",
                    txtNombres.Text.Trim());

                comando.Parameters.AddWithValue(
                    "@Apellidos",
                    txtApellidos.Text.Trim());

                comando.Parameters.AddWithValue(
                    "@Cedula",
                    txtCedula.Text.Trim());

                comando.Parameters.AddWithValue(
                    "@FechaNacimiento",
                    dtpFechaNacimiento.Value.Date);

                comando.Parameters.AddWithValue(
                    "@Genero",
                    genero);

                comando.Parameters.AddWithValue(
                    "@Direccion",
                    txtDireccion.Text.Trim());

                comando.Parameters.AddWithValue(
                    "@Telefono",
                    txtTelefono.Text.Trim());

                comando.Parameters.AddWithValue(
                    "@Correo",
                    txtCorreo.Text.Trim());

                if (foto != null)
                {
                    comando.Parameters.Add(
                        "@Foto",
                        SqlDbType.VarBinary).Value = foto;
                }
                else
                {
                    comando.Parameters.Add(
                        "@Foto",
                        SqlDbType.VarBinary).Value = DBNull.Value;
                }

                comando.Parameters.AddWithValue(
                    "@NombreContactoEmergencia",
                    txtNombreContacto.Text.Trim());

                comando.Parameters.AddWithValue(
                    "@TelefonoEmergencia",
                    txtTelefonoEmergencia.Text.Trim());

                comando.Parameters.AddWithValue(
                    "@ParentescoEmergencia",
                    cmbParentesco.Text);

                comando.ExecuteNonQuery();

                MessageBox.Show(
                    "Deportista registrado correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 ||
                    ex.Number == 2601)
                {
                    MessageBox.Show(
                        "Ya existe un deportista con esa cédula o correo electrónico.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        "Error al registrar el deportista:\n\n" +
                        ex.Message,
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al registrar el deportista:\n\n" +
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmDepAdm frmSubCompetencia = new frmDepAdm();

            frmSubCompetencia.TopLevel = false;
            frmSubCompetencia.FormBorderStyle = FormBorderStyle.None;
            frmSubCompetencia.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmSubCompetencia);

            frmSubCompetencia.Show();

            this.Close();
        }
        private string ObtenerGenero()
        {
            if (rbMasculino.Checked)
                return "Masculino";

            if (rbFemenino.Checked)
                return "Femenino";

            return "";
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

        private void btnSubirFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();

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
            }
        }

        private void frmRegistroDeportistaAdm_Load(object sender, EventArgs e)
        {
            cmbParentesco.Items.Clear();

            cmbParentesco.Items.Add("Madre");
            cmbParentesco.Items.Add("Padre");
            cmbParentesco.Items.Add("Hermano/a");
            cmbParentesco.Items.Add("Abuelo/a");
            cmbParentesco.Items.Add("Tío/a");
            cmbParentesco.Items.Add("Primo/a");
            cmbParentesco.Items.Add("Cónyuge");
            cmbParentesco.Items.Add("Tutor legal");
            cmbParentesco.Items.Add("Representante");
            cmbParentesco.Items.Add("Otro familiar");
            cmbParentesco.Items.Add("No familiar");

            cmbParentesco.SelectedIndex = -1;
            cmbParentesco.DropDownStyle =
                ComboBoxStyle.DropDownList;

            txtCedula.MaxLength = 10;
            txtTelefono.MaxLength = 10;
            txtTelefonoEmergencia.MaxLength = 10;
        }
        private bool ValidarCampos()
        {
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

            if (dtpFechaNacimiento.Value.Date >= DateTime.Today)
            {
                MessageBox.Show(
                    "Ingrese una fecha de nacimiento válida.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

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

            string telefonoEmergencia =
                txtTelefonoEmergencia.Text.Trim();

            if (telefonoEmergencia.Length != 10 ||
                !telefonoEmergencia.All(char.IsDigit))
            {
                MessageBox.Show(
                    "El teléfono de emergencia debe contener exactamente 10 dígitos.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTelefonoEmergencia.Focus();
                return false;
            }

            if (telefono == telefonoEmergencia)
            {
                MessageBox.Show(
                    "El teléfono de emergencia debe ser diferente al teléfono del deportista.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

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

            if (txtNombreContacto.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese el nombre del contacto de emergencia.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombreContacto.Focus();
                return false;
            }

            if (cmbParentesco.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione el parentesco del contacto de emergencia.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

    }
}
