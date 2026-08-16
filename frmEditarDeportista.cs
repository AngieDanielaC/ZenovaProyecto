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
using System.Text.RegularExpressions;


namespace wfZenova
{
    public partial class frmEditarDeportista : Form
    {
        private csConectaSQL conSQL = new csConectaSQL();

        private int idDeportista;

        private byte[] fotoDeportista = null;

        public frmEditarDeportista()
        {
            InitializeComponent();
            txtNombres.KeyPress += SoloLetras_KeyPress;
            txtApellidos.KeyPress += SoloLetras_KeyPress;
            txtNombreContacto.KeyPress += SoloLetras_KeyPress;

            txtTelefono.KeyPress += SoloNumeros_KeyPress;
            txtTelefonoEmergencia.KeyPress += SoloNumeros_KeyPress;
        }
       public frmEditarDeportista(int idDeportista)
            : this()
        {
            this.idDeportista = idDeportista;
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
            cmbParentesco.DropDownStyle = ComboBoxStyle.DropDownList;

            txtNombres.MaxLength = 50;
            txtApellidos.MaxLength = 50;
            txtTelefono.MaxLength = 10;
            txtDireccion.MaxLength = 150;
            txtCorreo.MaxLength = 100;
            txtNombreContacto.MaxLength = 100;
            txtTelefonoEmergencia.MaxLength = 10;

            picFoto.SizeMode = PictureBoxSizeMode.Zoom;
            CargarDatosDeportista();

        }

        private void CargarDatosDeportista()
        {
            string consulta =
                "select Nombres, Apellidos, Telefono, " +
                "Direccion, Correo, Foto, " +
                "NombreContactoEmergencia, " +
                "TelefonoEmergencia, ParentescoEmergencia " +
                "from Deportistas " +
                "where IdDeportista = " + idDeportista;

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos == null)
                return;

            if (datos.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró el deportista.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                this.Close();
                return;
            }

            DataRow fila = datos.Rows[0];

            txtNombres.Text = fila["Nombres"].ToString();

            txtApellidos.Text = fila["Apellidos"].ToString();

            txtTelefono.Text = fila["Telefono"].ToString();

            txtDireccion.Text = fila["Direccion"].ToString();

            txtCorreo.Text =
                fila["Correo"] == DBNull.Value
                ? ""
                : fila["Correo"].ToString();

            txtNombreContacto.Text = fila["NombreContactoEmergencia"].ToString();

            txtTelefonoEmergencia.Text =
                fila["TelefonoEmergencia"].ToString();

            cmbParentesco.SelectedItem = fila["ParentescoEmergencia"].ToString();

            if (fila["Foto"] != DBNull.Value)
            {
                fotoDeportista = (byte[])fila["Foto"];

                if (fotoDeportista.Length > 0)
                {
                    using (MemoryStream memoria = new MemoryStream(fotoDeportista))
                    using (Image imagen = Image.FromStream(memoria))
                    {
                        picFoto.Image = new Bitmap(imagen);
                    }
                }
            }
        }

        private void btnSubirFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ventana = new OpenFileDialog())
            {
                ventana.Title = "Seleccionar fotografía";

                ventana.Filter =  "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (ventana.ShowDialog() != DialogResult.OK)
                    return;
                try
                {
                    FileInfo archivo = new FileInfo(ventana.FileName);

                    if (archivo.Length > 5 * 1024 * 1024)
                    {
                        MessageBox.Show(
                            "La fotografía no debe superar los 5 MB.",
                            "Fotografía demasiado grande",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }

                    fotoDeportista = File.ReadAllBytes(ventana.FileName);

                    using (MemoryStream memoria = new MemoryStream(fotoDeportista))
                    using (Image imagen = Image.FromStream(memoria))
                    {
                        picFoto.Image =
                            new Bitmap(imagen);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo cargar la fotografía.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("Ingrese los nombres del deportista.");
                txtNombres.Focus();
                return false;
            }

            if (!txtNombres.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show(  "Los nombres solamente deben contener letras.");
                txtNombres.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Ingrese los apellidos del deportista.");
                txtApellidos.Focus();
                return false;
            }

            if (!txtApellidos.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Los apellidos solamente deben contener letras.");
                txtApellidos.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtTelefono.Text.Trim(), @"^\d{10}$"))
            {
                MessageBox.Show( "El teléfono debe tener exactamente 10 dígitos.");
                txtTelefono.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Ingrese la dirección.");
                txtDireccion.Focus();
                return false;
            }

            if (!Regex.IsMatch( txtCorreo.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show( "Ingrese un correo electrónico válido.");
                txtCorreo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreContacto.Text))
            {
                MessageBox.Show("Ingrese el nombre del contacto de emergencia.");
                txtNombreContacto.Focus();
                return false;
            }

            if (!txtNombreContacto.Text.All(c =>  char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show( "El nombre del contacto solamente debe contener letras.");
                txtNombreContacto.Focus();
                return false;
            }

            if (!Regex.IsMatch( txtTelefonoEmergencia.Text.Trim(), @"^\d{10}$"))
            {
                MessageBox.Show( "El teléfono de emergencia debe tener exactamente 10 dígitos.");
                txtTelefonoEmergencia.Focus();
                return false;
            }

            if (cmbParentesco.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el parentesco.");
                cmbParentesco.Focus();
                return false;
            }

            if (fotoDeportista == null)
            {
                MessageBox.Show(  "El deportista debe tener una fotografía.");
                return false;
            }

            return true;
        }
        private bool ValidarCorreoDuplicado()
        {
            string correo = txtCorreo.Text.Trim().Replace("'", "''");

            string consulta =
                "select IdDeportista from Deportistas " +
                "where Correo = '" + correo + "' " +
                "and IdDeportista <> " + idDeportista;

            DataTable resultado = conSQL.RetornaRegistros(consulta);

            if (resultado == null)
                return false;

            if (resultado.Rows.Count > 0)
            {
                MessageBox.Show(
                    "Ya existe otro deportista registrado con este correo.",
                    "Correo duplicado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (!ValidarCampos())
                return;

            if (!ValidarCorreoDuplicado())
                return;

            DialogResult respuesta = MessageBox.Show(
                "¿Desea guardar los cambios realizados?",
                "Confirmar actualización",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;
            if (respuesta != DialogResult.Yes)
                return;

            string sentencia =
                "update Deportistas set " +
                "Nombres = @Nombres, " +
                "Apellidos = @Apellidos, " +
                "Telefono = @Telefono, " +
                "Direccion = @Direccion, " +
                "Correo = @Correo, " +
                "Foto = @Foto, " +
                "NombreContactoEmergencia = @NombreContacto, " +
                "TelefonoEmergencia = @TelefonoEmergencia, " +
                "ParentescoEmergencia = @Parentesco " +
                "where IdDeportista = @IdDeportista";
            bool actualizado = conSQL.EjecutaSentenciaParametros(
            sentencia,

            new SqlParameter("@Nombres", SqlDbType.NVarChar, 100)
            {
                Value = txtNombres.Text.Trim()
            },

            new SqlParameter("@Apellidos", SqlDbType.NVarChar, 100)
            {
                Value = txtApellidos.Text.Trim()
            },
            new SqlParameter("@Telefono", SqlDbType.VarChar, 10)
            {
                Value = txtTelefono.Text.Trim()
            },

            new SqlParameter("@Direccion", SqlDbType.NVarChar, 200)
            {
                Value = txtDireccion.Text.Trim()
            },

            new SqlParameter("@Correo", SqlDbType.NVarChar, 150)
            {
                Value = txtCorreo.Text.Trim()
            },
            new SqlParameter("@Foto", SqlDbType.VarBinary, -1)
            {
                Value = fotoDeportista
            },

            new SqlParameter("@NombreContacto", SqlDbType.NVarChar, 150)
            {
                Value = txtNombreContacto.Text.Trim()
            },

            new SqlParameter("@TelefonoEmergencia", SqlDbType.VarChar, 10)
            {
                Value = txtTelefonoEmergencia.Text.Trim()
            },
             new SqlParameter("@Parentesco", SqlDbType.NVarChar, 50)
             {
                 Value = cmbParentesco.Text
             },

            new SqlParameter("@IdDeportista", SqlDbType.Int)
            {
                Value = idDeportista
            }
            );
            if (actualizado)
            {
                MessageBox.Show("Los datos del deportista fueron actualizados correctamente.", "Actualización completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SoloLetras_KeyPress( object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SoloNumeros_KeyPress( object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
