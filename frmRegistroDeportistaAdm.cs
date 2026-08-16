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
using System.Text.RegularExpressions;


namespace wfZenova
{
    public partial class frmRegistroDeportistaAdm : Form
    {
        private byte[] fotoDeportista = null;
        private csConectaSQL conSQL = new csConectaSQL();

        public frmRegistroDeportistaAdm()
        {
            InitializeComponent();
            txtNombres.KeyPress += SoloLetras_KeyPress;
            txtApellidos.KeyPress += SoloLetras_KeyPress;
            txtNombreContacto.KeyPress += SoloLetras_KeyPress;
        }

        private void btnGuardarDep_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            if (!ValidarDuplicados())
                return;
            string genero;

            if (rbMasculino.Checked)
                genero = "Masculino";
            else
                genero = "Femenino";

            string sentencia =
                "insert into Deportistas (" +
                "Nombres, Apellidos, Cedula, FechaNacimiento, Genero, " +
                "Direccion, Telefono, Correo, Foto, " +
                "NombreContactoEmergencia, TelefonoEmergencia, " +
                "ParentescoEmergencia) " +
                "values (" +
                "@Nombres, @Apellidos, @Cedula, @FechaNacimiento, @Genero, " +
                "@Direccion, @Telefono, @Correo, @Foto, " +
                "@NombreContactoEmergencia, @TelefonoEmergencia, " +
                "@ParentescoEmergencia)";
            bool guardado = conSQL.EjecutaSentenciaParametros( sentencia, new SqlParameter("@Nombres",SqlDbType.NVarChar,100)
            {
                Value = txtNombres.Text.Trim()
            },

            new SqlParameter( "@Apellidos",SqlDbType.NVarChar,100)
            {
                 Value = txtApellidos.Text.Trim()
            },
            new SqlParameter("@Cedula",SqlDbType.VarChar,10)
            {
                 Value = txtCedula.Text.Trim()
            },

            new SqlParameter( "@FechaNacimiento",SqlDbType.Date)
            {
                 Value = dtpFechaNacimiento.Value.Date
            },

            new SqlParameter("@Genero",SqlDbType.NVarChar,20)
            {
                 Value = genero
            },
            new SqlParameter("@Direccion",SqlDbType.NVarChar,200)
            {
                  Value = txtDireccion.Text.Trim()
            },
            new SqlParameter("@Telefono",SqlDbType.VarChar,10)
            {
                  Value = txtTelefono.Text.Trim()
            },

            new SqlParameter("@Correo",SqlDbType.NVarChar,150)
            {
                 Value = txtCorreo.Text.Trim()
            },
             new SqlParameter("@Foto",SqlDbType.VarBinary,-1)
            {
                 Value = fotoDeportista
            },

            new SqlParameter("@NombreContactoEmergencia",SqlDbType.NVarChar,150)
            {
                Value = txtNombreContacto.Text.Trim()
            },

            new SqlParameter("@TelefonoEmergencia",SqlDbType.VarChar,10)
            {
                Value = txtTelefonoEmergencia.Text.Trim()
            },
            new SqlParameter( "@ParentescoEmergencia",SqlDbType.NVarChar,50)
            {
                  Value = cmbParentesco.Text
            }
            );

            if (guardado)
            {
                MessageBox.Show(
                    "Deportista registrado correctamente.",
                    "Registro completado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }


        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubirFoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ventana = new OpenFileDialog())
            {
                ventana.Title = "Seleccionar fotografía";
                ventana.Filter =
                    "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
                if (ventana.ShowDialog() == DialogResult.OK)
                {
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

                        fotoDeportista =
                            File.ReadAllBytes(ventana.FileName);

                        using (MemoryStream memoria =
                            new MemoryStream(fotoDeportista))
                        using (Image imagen =
                            Image.FromStream(memoria))
                        {
                            picFoto.Image = new Bitmap(imagen);
                        }
                    }
                    catch (Exception ex)
                    {
                        fotoDeportista = null;

                        MessageBox.Show(
                            "No se pudo cargar la fotografía.\n" + ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void frmRegistroDeportistaAdm_Load(object sender, EventArgs e)
        {
            // Parentesco
            cmbParentesco.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbParentesco.SelectedIndex = -1;

            // Fecha de nacimiento
            dtpFechaNacimiento.MinDate = new DateTime(1900, 1, 1);
            dtpFechaNacimiento.MaxDate = DateTime.Today.AddDays(-1);

            // Límites de caracteres
            txtNombres.MaxLength = 50;
            txtApellidos.MaxLength = 50;
            txtCedula.MaxLength = 10;
            txtDireccion.MaxLength = 150;
            txtTelefono.MaxLength = 10;
            txtCorreo.MaxLength = 100;
            txtNombreContacto.MaxLength = 100;
            txtTelefonoEmergencia.MaxLength = 10;

            // Evita que la fotografía se deforme
            picFoto.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtCedula_KeyPress(object sender,KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

        private void txtTelefonoEmergencia_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

            if (!txtNombres.Text.All(c =>char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Los nombres solamente deben contener letras.");
                txtNombres.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                MessageBox.Show("Ingrese los apellidos del deportista.");
                txtApellidos.Focus();
                return false;
            }

            if (!txtApellidos.Text.All(c =>char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Los apellidos solamente deben contener letras.");
                txtApellidos.Focus();
                return false;
            }

            string cedula = txtCedula.Text.Trim();

            if (!Regex.IsMatch(cedula, @"^\d{10}$"))
            {
                MessageBox.Show("La cédula debe tener exactamente 10 dígitos.");

                txtCedula.Focus();
                return false;
            }

            if (dtpFechaNacimiento.Value.Date >= DateTime.Today)
            {
                MessageBox.Show( "Seleccione una fecha de nacimiento válida.");

                dtpFechaNacimiento.Focus();
                return false;
            }

            if (!rbMasculino.Checked && !rbFemenino.Checked)
            {
                MessageBox.Show("Seleccione el género del deportista.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Ingrese la dirección del deportista.");
                txtDireccion.Focus();
                return false;
            }

            string telefono = txtTelefono.Text.Trim();

            if (!Regex.IsMatch(telefono, @"^\d{10}$"))
            {
                MessageBox.Show("El teléfono personal debe tener exactamente 10 dígitos.");

                txtTelefono.Focus();
                return false;
            }

            string correo = txtCorreo.Text.Trim();

            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.");
                txtCorreo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreContacto.Text))
            {
                MessageBox.Show("Ingrese el nombre del contacto de emergencia.");

                txtNombreContacto.Focus();
                return false;
            }

            if (!txtNombreContacto.Text.All(c =>char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show( "El nombre del contacto solamente debe contener letras.");
                txtNombreContacto.Focus();
                return false;
            }

            string telefonoEmergencia = txtTelefonoEmergencia.Text.Trim();

            if (!Regex.IsMatch(telefonoEmergencia, @"^\d{10}$"))
            {
                MessageBox.Show("El teléfono de emergencia debe tener exactamente 10 dígitos.");
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
                MessageBox.Show("Seleccione una fotografía del deportista.");

                return false;
            }

            return true;
        }

        private bool ValidarDuplicados()
        {
            string cedula = txtCedula.Text.Trim();
            string correo = txtCorreo.Text.Trim().Replace("'", "''");

            DataTable resultadoCedula = conSQL.RetornaRegistros(
                "select IdDeportista from Deportistas " +
                "where Cedula = '" + cedula + "'");

            if (resultadoCedula == null)
                return false;

            if (resultadoCedula.Rows.Count > 0)
            {
                MessageBox.Show(
                    "Ya existe un deportista registrado con esta cédula.",
                    "Cédula duplicada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCedula.Focus();
                return false;
            }

            DataTable resultadoCorreo = conSQL.RetornaRegistros(
                "select IdDeportista from Deportistas " +
                "where Correo = '" + correo + "'");

            if (resultadoCorreo == null)
                return false;

            if (resultadoCorreo.Rows.Count > 0)
            {
                MessageBox.Show( "Ya existe un deportista registrado con este correo.",
                    "Correo duplicado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCorreo.Focus();
                return false;
            }

            return true;
        }

        private void SoloLetras_KeyPress(object sender,KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) & !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
