using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace wfZenova
{
    public partial class frmRegistroEntrenadoresAdm : Form
    {
        csConectaSQL oCon = new csConectaSQL();
        public frmRegistroEntrenadoresAdm()
        {
            InitializeComponent();
        }
        private Form formularioActivo = null;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmEntrenadorAdm frmVerCompetencias = new frmEntrenadorAdm();

            frmVerCompetencias.TopLevel = false;
            frmVerCompetencias.FormBorderStyle = FormBorderStyle.None;
            frmVerCompetencias.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmVerCompetencias);

            frmVerCompetencias.Show();

            this.Close();
        }

        private void btnImgEnt_Click(object sender, EventArgs e)
        {
            OpenFileDialog ImagenEntrenador = new OpenFileDialog();
            ImagenEntrenador.Filter = "archivos Imagen (*jpg;*png;) | *jpg;*png; ";
            if (ImagenEntrenador.ShowDialog() == DialogResult.OK)
            {
                ImagenEnt.Image = Image.FromFile(ImagenEntrenador.FileName);
            }
        }

        private void btnGuardarDep_Click(object sender, EventArgs e)
        {
            if (VerificarData()==false)
            {
                return;
            }
            MemoryStream ms = new MemoryStream();
            ImagenEnt.Image.Save(ms, ImageFormat.Jpeg);//guardar en memoria
            byte[] abyte = ms.ToArray(); //convertir a byte 
            string imagenwa = "0x" + BitConverter.ToString(abyte).Replace("-", "");
            string datos;
            string campos;
            string fecha = DateEnt.Value.ToString("yyyy-MM-dd");
            string genero = " ";

            if (rdbMascEnt.Checked)
            {
                genero = "Masculino";
            }
            else if (rdbFemEnt.Checked)
            {
                genero = "Femenino";
            }

            campos = "Nombres, Apellidos, Cedula, FechaNacimiento, Genero, Direccion, Telefono, Correo, Foto ";

            datos = "' " + txtNombreEn.Text + "' , ' " + txtApEnt.Text + "','" +
                 txtCedulaEnt.Text + "','" + fecha + "','" + genero + "','" + 
                txtDirEnt.Text + "','" + txtTelefonoEnt.Text + "','" + txtCorreoEnt.Text + "'," +
                imagenwa;
            if (oCon.insertDatos("Entrenadores", campos, datos))
            {
                string idDeporte = cmbEspecialidadDeportiva.SelectedValue != null ?
                           cmbEspecialidadDeportiva.SelectedValue.ToString() : "1";
                string fechaInicio = DateTime.Now.ToString("yyyy-MM-dd");
                string camposRelacion = "IdEntrenador, IdDeporte, FechaInicio, Activo";
                string datosRelacion = "(SELECT MAX(IdEntrenador) FROM Entrenadores), " +
                                       idDeporte + ", '" +
                                       fechaInicio + "', 1";

                oCon.insertDatos("EntrenadorDeporte", camposRelacion, datosRelacion);
                MessageBox.Show("Entrenador registrado correctamente");
            }
        }

        private bool VerificarData()
        {
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrWhiteSpace(txtNombreEn.Text))
            {
                MessageBox.Show("Por favor ingrese los nombres del entrenador.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreEn.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtApEnt.Text))
            {
                MessageBox.Show("Por favor ingrese los apellidos del entrenador.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApEnt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCedulaEnt.Text) || txtCedulaEnt.Text.Trim().Length != 10)
            {
                MessageBox.Show("Por favor ingrese un número de cédula válido de 10 dígitos.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedulaEnt.Focus();
                return false;
            }
            if (!rdbMascEnt.Checked && !rdbFemEnt.Checked)
            {
                MessageBox.Show("Por favor seleccione el género del entrenador.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDirEnt.Text))
            {
                MessageBox.Show("Por favor ingrese la dirección.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDirEnt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCorreoEnt.Text) || !Regex.IsMatch(txtCorreoEnt.Text.Trim(), patronEmail))
            {
                MessageBox.Show("Por favor ingrese un correo electrónico válido (ejemplo: usuario@correo.com).", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreoEnt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTelefonoEnt.Text))
            {
                MessageBox.Show("Por favor ingrese el número de teléfono.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefonoEnt.Focus();
                return false;
            }
            if (cmbEspecialidadDeportiva.SelectedIndex == -1 && string.IsNullOrWhiteSpace(cmbEspecialidadDeportiva.Text))
            {
                MessageBox.Show("Por favor seleccione un deporte de la lista.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEspecialidadDeportiva.Focus();
                return false;
            }
            if (ImagenEnt.Image == null)
            {
                MessageBox.Show("Por favor cargue una foto para el entrenador.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnImgEnt.Focus();
                return false;
            }
            return true;
        }

        private void txtTelefonoEnt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefonoEnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
