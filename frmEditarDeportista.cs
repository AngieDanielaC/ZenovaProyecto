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
    public partial class frmEditarDeportista : Form
    {
        private int idDeportista;
        public frmEditarDeportista(int idDeportista)
        {
            InitializeComponent();

            this.idDeportista = idDeportista;
        }
        public frmEditarDeportista()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        private void frmEditarDeportista_Load(object sender, EventArgs e)
        {
            CargarParentescos();

            txtTelefono.MaxLength = 10;
            txtTelefonoEmergencia.MaxLength = 10;

            CargarDeportista();
        }
        private void CargarParentescos()
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

            cmbParentesco.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbParentesco.SelectedIndex = -1;
        }

        private void CargarDeportista()
        {
            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            SELECT
                Foto,
                Nombres,
                Apellidos,
                Telefono,
                Direccion,
                Correo,
                NombreContactoEmergencia,
                TelefonoEmergencia,
                ParentescoEmergencia
            FROM Deportistas
            WHERE IdDeportista = @IdDeportista;
        ";

                SqlCommand comando =
                    new SqlCommand(
                        consulta,
                        conexion.oCon);

                comando.Parameters.AddWithValue(
                    "@IdDeportista",
                    idDeportista);

                SqlDataReader lector =
                    comando.ExecuteReader();

                if (lector.Read())
                {
                    txtNombres.Text =
                        lector["Nombres"].ToString();

                    txtApellidos.Text =
                        lector["Apellidos"].ToString();

                    txtTelefono.Text =
                        lector["Telefono"].ToString();

                    txtDireccion.Text =
                        lector["Direccion"].ToString();

                    txtCorreo.Text =
                        lector["Correo"] == DBNull.Value
                        ? ""
                        : lector["Correo"].ToString();

                    txtNombreContacto.Text =
                        lector["NombreContactoEmergencia"]
                        .ToString();

                    txtTelefonoEmergencia.Text =
                        lector["TelefonoEmergencia"]
                        .ToString();

                    cmbParentesco.Text =
                        lector["ParentescoEmergencia"]
                        .ToString();

                    // FOTO
                    if (lector["Foto"] != DBNull.Value)
                    {
                        byte[] bytesFoto =
                            (byte[])lector["Foto"];

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
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el deportista:\n\n" +
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

        private void btnSubirFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo =
        new OpenFileDialog();

            dialogo.Filter =
                "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialogo.ShowDialog() ==
                DialogResult.OK)
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

        private byte[] ImagenABytes(Image imagen)
        {
            if (imagen == null)
                return null;

            using (MemoryStream ms =
                   new MemoryStream())
            {
                imagen.Save(
                    ms,
                    System.Drawing.Imaging.ImageFormat.Png);

                return ms.ToArray();
            }
        }
        private bool ValidarCampos()
        {
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
                    "Seleccione el parentesco.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            byte[] foto =
                ImagenABytes(picFoto.Image);

            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            UPDATE Deportistas
            SET
                Nombres = @Nombres,
                Apellidos = @Apellidos,
                Telefono = @Telefono,
                Direccion = @Direccion,
                Correo = @Correo,
                Foto = @Foto,
                NombreContactoEmergencia =
                    @NombreContactoEmergencia,
                TelefonoEmergencia =
                    @TelefonoEmergencia,
                ParentescoEmergencia =
                    @ParentescoEmergencia
            WHERE IdDeportista =
                @IdDeportista;
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
                    "@Telefono",
                    txtTelefono.Text.Trim());

                comando.Parameters.AddWithValue(
                    "@Direccion",
                    txtDireccion.Text.Trim());

                comando.Parameters.AddWithValue(
                    "@Correo",
                    txtCorreo.Text.Trim());

                comando.Parameters.AddWithValue(
                    "@NombreContactoEmergencia",
                    txtNombreContacto.Text.Trim());

                comando.Parameters.AddWithValue(
                    "@TelefonoEmergencia",
                    txtTelefonoEmergencia.Text.Trim());

                comando.Parameters.AddWithValue(
                    "@ParentescoEmergencia",
                    cmbParentesco.Text);

                comando.Parameters.AddWithValue(
                    "@IdDeportista",
                    idDeportista);

                if (foto != null)
                {
                    comando.Parameters.Add(
                        "@Foto",
                        SqlDbType.VarBinary).Value =
                        foto;
                }
                else
                {
                    comando.Parameters.Add(
                        "@Foto",
                        SqlDbType.VarBinary).Value =
                        DBNull.Value;
                }

                comando.ExecuteNonQuery();

                MessageBox.Show(
                    "Los datos del deportista fueron actualizados correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar el deportista:\n\n" +
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
    }
}
