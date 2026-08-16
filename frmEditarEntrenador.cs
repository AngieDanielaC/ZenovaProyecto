using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmEditarEntrenador : Form
    {
        csConectaSQL oConSQl = new csConectaSQL();
        private int idEntrenador;

        public frmEditarEntrenador()
        {
            InitializeComponent();
        }
        public frmEditarEntrenador(int idEntrenador)
        {
            InitializeComponent();
            this.idEntrenador = idEntrenador;
        }

        private void frmEditarEntrenador_Load(object sender, EventArgs e)
        {
            CargarDatosEntrenador();
            CargarDeportesEntrenador();
        }
        private void CargarDeportesEntrenador()
        {
            // 1. Cargar todos los deportes en el CheckedListBox
            string queryTodos = "SELECT IdDeporte, NombreDeporte FROM Deportes WHERE Activo = 1";
            DataTable dtTodos = oConSQl.RetornaRegistros(queryTodos);

            if (dtTodos == null || dtTodos.Rows.Count == 0) return;

            clbDeportes.DataSource = null;
            clbDeportes.DataSource = dtTodos;
            clbDeportes.DisplayMember = "NombreDeporte";
            clbDeportes.ValueMember = "IdDeporte";

            // 2. Cargar los deportes asignados al entrenador
            string queryAsignados = $@"
                SELECT IdDeporte 
                FROM EntrenadorDeporte 
                WHERE IdEntrenador = {this.idEntrenador} AND (Activo = 1 OR Activo = 'True')";

            DataTable dtAsignados = oConSQl.RetornaRegistros(queryAsignados);

            if (dtAsignados != null && dtAsignados.Rows.Count > 0)
            {
                List<int> idsAsignados = new List<int>();
                foreach (DataRow dr in dtAsignados.Rows)
                {
                    idsAsignados.Add(Convert.ToInt32(dr["IdDeporte"]));
                }

                // 3. Marcar los casilleros correspondientes
                for (int i = 0; i < clbDeportes.Items.Count; i++)
                {
                    DataRowView row = (DataRowView)clbDeportes.Items[i];
                    int idDeporteActual = Convert.ToInt32(row["IdDeporte"]);

                    if (idsAsignados.Contains(idDeporteActual))
                    {
                        clbDeportes.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }

        private void CargarDatosEntrenador()
        {
            string query = $@"
                SELECT Nombres, Apellidos, Telefono, Direccion, Correo, Foto
                FROM Entrenadores 
                WHERE IdEntrenador = {this.idEntrenador}";

            DataTable dt = oConSQl.RetornaRegistros(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                txtNombreEn.Text = dr["Nombres"].ToString().Trim();
                txtApEnt.Text = dr["Apellidos"].ToString().Trim();
                txtTelefono.Text = dr["Telefono"].ToString().Trim();
                txtDirEnt.Text = dr["Direccion"].ToString().Trim();
                txtCorreoEnt.Text = dr["Correo"].ToString().Trim();

                // Cargar Foto desde la BD
                if (dr["Foto"] != DBNull.Value && dr["Foto"] != null)
                {
                    byte[] imgData = (byte[])dr["Foto"];
                    using (MemoryStream ms = new MemoryStream(imgData))
                    {
                        ImagenEnt.Image = Image.FromStream(ms);
                    }
                }
            }
        }

        private bool VerificarData()
        {
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (string.IsNullOrWhiteSpace(txtNombreEn.Text))
            {
                MessageBox.Show("Por favor ingrese los nombres.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreEn.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtApEnt.Text))
            {
                MessageBox.Show("Por favor ingrese los apellidos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApEnt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Ingrese el teléfono.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDirEnt.Text))
            {
                MessageBox.Show("Ingrese la dirección.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDirEnt.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCorreoEnt.Text) || !Regex.IsMatch(txtCorreoEnt.Text.Trim(), patronEmail))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreoEnt.Focus();
                return false;
            }
            if (clbDeportes.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un deporte.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ImagenEnt.Image == null)
            {
                MessageBox.Show("Por favor seleccione una foto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (!VerificarData()) return;

            // Convertir la imagen a formato hexadecimal para SQL
            MemoryStream ms = new MemoryStream();
            ImagenEnt.Image.Save(ms, ImageFormat.Jpeg);
            byte[] abyte = ms.ToArray();
            string imagenwa = "0x" + BitConverter.ToString(abyte).Replace("-", "");
            string cadena = $"Nombres='{txtNombreEn.Text.Trim()}', " +
                           $"Apellidos='{txtApEnt.Text.Trim()}', " +
                           $"Telefono='{txtTelefono.Text.Trim()}', " +
                           $"Direccion='{txtDirEnt.Text.Trim()}', " +
                           $"Correo='{txtCorreoEnt.Text.Trim()}', " +
                           $"Foto={imagenwa}";

            oConSQl.ActualizarDatos("Entrenadores", cadena, $"IdEntrenador={this.idEntrenador}");

            oConSQl.ActualizarDatos("EntrenadorDeporte", "Activo = 0", $"IdEntrenador = {this.idEntrenador}");

            foreach (DataRowView item in clbDeportes.CheckedItems)
            {
                int idDeporte = Convert.ToInt32(item["IdDeporte"]);
                string fechaInicio = DateTime.Now.ToString("yyyy-MM-dd");

                string camposRel = "IdEntrenador, IdDeporte, FechaInicio, Activo";
                string datosRel = $"{this.idEntrenador}, {idDeporte}, '{fechaInicio}', 1";

                oConSQl.insertDatos("EntrenadorDeporte", camposRel, datosRel);
            }

            MessageBox.Show("Entrenador y deportes actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnSubirFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ImagenEntrenador = new OpenFileDialog();
            ImagenEntrenador.Filter = "archivos Imagen (*jpg;*png;) | *jpg;*png; ";
            if (ImagenEntrenador.ShowDialog() == DialogResult.OK)
            {
                ImagenEnt.Image = Image.FromFile(ImagenEntrenador.FileName);
            }
        }
    }
}
