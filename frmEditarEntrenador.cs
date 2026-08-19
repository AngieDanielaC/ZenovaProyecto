using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            string queryTodos = "SELECT IdDeporte, NombreDeporte FROM Deportes WHERE Activo = 1";
            DataTable dtTodos = oConSQl.RetornaRegistros(queryTodos);

            if (dtTodos == null || dtTodos.Rows.Count == 0) return;

            clbDeportes.DataSource = null;
            clbDeportes.DataSource = dtTodos;
            clbDeportes.DisplayMember = "NombreDeporte";
            clbDeportes.ValueMember = "IdDeporte";
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
            byte[] abyte;
            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap bmp = new Bitmap(ImagenEnt.Image))
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                abyte = ms.ToArray();
            }
            string queryEntrenador = @"
        UPDATE Entrenadores 
        SET Nombres = @Nombres, 
            Apellidos = @Apellidos, 
            Telefono = @Telefono, 
            Direccion = @Direccion, 
            Correo = @Correo, 
            Foto = @Foto 
        WHERE IdEntrenador = @IdEntrenador";

            SqlParameter[] parametros = new SqlParameter[]
            {
        new SqlParameter("@Nombres", txtNombreEn.Text.Trim()),
        new SqlParameter("@Apellidos", txtApEnt.Text.Trim()),
        new SqlParameter("@Telefono", txtTelefono.Text.Trim()),
        new SqlParameter("@Direccion", txtDirEnt.Text.Trim()),
        new SqlParameter("@Correo", txtCorreoEnt.Text.Trim()),
        new SqlParameter("@Foto", abyte),
        new SqlParameter("@IdEntrenador", this.idEntrenador)
            };

            oConSQl.EjecutaSentenciaParametros(queryEntrenador, parametros);
            string queryDesactivar = $"UPDATE EntrenadorDeporte SET Activo = 0 WHERE IdEntrenador = {this.idEntrenador}";
            oConSQl.EjecutaSentenciaSRD(queryDesactivar);
            foreach (DataRowView item in clbDeportes.CheckedItems)
            {
                int idDeporte = Convert.ToInt32(item["IdDeporte"]);
                string fechaInicio = DateTime.Now.ToString("yyyy-MM-dd");

                string queryExiste = $@"
            SELECT IdEntrenadorDeporte 
            FROM EntrenadorDeporte 
            WHERE IdEntrenador = {this.idEntrenador} AND IdDeporte = {idDeporte}";

                DataTable dtExiste = oConSQl.RetornaRegistros(queryExiste);

                if (dtExiste != null && dtExiste.Rows.Count > 0)
                {
                    string queryReactivar = $"UPDATE EntrenadorDeporte SET Activo = 1 WHERE IdEntrenador = {this.idEntrenador} AND IdDeporte = {idDeporte}";
                    oConSQl.EjecutaSentenciaSRD(queryReactivar);
                }
                else
                {
                    string camposRel = "IdEntrenador, IdDeporte, FechaInicio, Activo";
                    string datosRel = $"{this.idEntrenador}, {idDeporte}, '{fechaInicio}', 1";
                    oConSQl.insertDatos("EntrenadorDeporte", camposRel, datosRel);
                }
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
                using (var tempImg = Image.FromFile(ImagenEntrenador.FileName))
                {
                    ImagenEnt.Image = new Bitmap(tempImg);
                }
            }
        }
    }
}
