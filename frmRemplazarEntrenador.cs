using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace wfZenova
{
    public partial class frmRemplazarEntrenador : Form
    {
        csConectaSQL oConSQl = new csConectaSQL();
        private int idEntrenadorSaliente;
        public frmRemplazarEntrenador(int idEntrenadorActual)
        {
            InitializeComponent();
            this.idEntrenadorSaliente = idEntrenadorActual;
        }


        public frmRemplazarEntrenador()
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

        private void frmRemplazarEntrenador_Load(object sender, EventArgs e)
        {
            CargarEntrenadorSaliente();
            CargarNuevosEntrenadores();
            CargarDisciplinas();
        }
        private void CargarEntrenadorSaliente()
        {
            if (this.idEntrenadorSaliente <= 0)
            {
                lblEntrenadorActual.Text = "No seleccionado";
                return;
            }

            string query = $@"
                SELECT (ISNULL(Nombres, '') + ' ' + ISNULL(Apellidos, '')) AS NombreCompleto 
                FROM Entrenadores 
                WHERE IdEntrenador = {this.idEntrenadorSaliente}";

            DataTable dt = oConSQl.RetornaRegistros(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                lblEntrenadorActual.Text = dt.Rows[0]["NombreCompleto"].ToString();
                lblEntrenadorActual.Refresh();
            }
            else
            {
                lblEntrenadorActual.Text = "Entrenador no encontrado";
            }
        }
        
        private void RegresarAAdministracion()
        {
            Control contenedor = this.Parent;
            frmEntrenadorAdm frmAdm = new frmEntrenadorAdm();

            frmAdm.TopLevel = false;
            frmAdm.FormBorderStyle = FormBorderStyle.None;
            frmAdm.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmAdm);

            frmAdm.Show();
            this.Close();
        }
        private void CargarDisciplinas()
        {
            string query = "SELECT IdDeporte, NombreDeporte FROM Deportes";

            DataTable dt = oConSQl.RetornaRegistros(query);

            clbDisciplina.DataSource = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                clbDisciplina.DataSource = dt;
                clbDisciplina.DisplayMember = "NombreDeporte";
                clbDisciplina.ValueMember = "IdDeporte";
            }
        }

        private void cmbTipoReemplazo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void CargarNuevosEntrenadores()
        {
            string query = $@"
                SELECT IdEntrenador, (Nombres + ' ' + Apellidos) AS NombreCompleto 
                FROM Entrenadores 
                WHERE IdEntrenador <> {this.idEntrenadorSaliente} 
                AND ISNULL(EstadoEntrenador, 'Activo') = 'Activo'";

            DataTable dt = oConSQl.RetornaRegistros(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                cmbNuevoEntrenador.DataSource = dt;
                cmbNuevoEntrenador.DisplayMember = "NombreCompleto";
                cmbNuevoEntrenador.ValueMember = "IdEntrenador";
            }
        }
        private bool ValidarCampos()
        {
            if (clbDisciplina.CheckedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos una disciplina a reemplazar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(cmbTipoReemplazo.Text))
            {
                MessageBox.Show("Ingrese la razón del reemplazo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoReemplazo.Focus();
                return false;
            }
            if (cmbNuevoEntrenador.SelectedValue == null)
            {
                MessageBox.Show("Seleccione el nuevo entrenador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (dtpFechaInicio.Value > dtpFechaFin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            int idNuevoEntrenador = Convert.ToInt32(cmbNuevoEntrenador.SelectedValue);
            string fechaInicio = dtpFechaInicio.Value.ToString("yyyy-MM-dd");
            string fechaFin = dtpFechaFin.Value.ToString("yyyy-MM-dd");
            string tipoVisual = cmbTipoReemplazo.Text.Trim();
            string tipoBD = "Temporal"; 
            if (tipoVisual.Equals("Retirado", StringComparison.OrdinalIgnoreCase) ||
                tipoVisual.Equals("Definitivo", StringComparison.OrdinalIgnoreCase) ||
                tipoVisual.Equals("Personal", StringComparison.OrdinalIgnoreCase))
            {
                tipoBD = "Definitivo";
            }
            string queryInactivar = $@"
        UPDATE Entrenadores 
        SET EstadoEntrenador = 'Inactivo' 
        WHERE IdEntrenador = {this.idEntrenadorSaliente}";

            oConSQl.RetornaRegistros(queryInactivar);
            foreach (DataRowView item in clbDisciplina.CheckedItems)
            {
                int idDeporte = Convert.ToInt32(item["IdDeporte"]);
                string queryUpdateDeporte = $@"
            UPDATE EntrenadorDeporte 
            SET Activo = 0 
            WHERE IdEntrenador = {this.idEntrenadorSaliente} AND IdDeporte = {idDeporte}";

                oConSQl.RetornaRegistros(queryUpdateDeporte);
                string camposED = "IdEntrenador, IdDeporte, FechaInicio, Activo";
                string valoresED = $"{idNuevoEntrenador}, {idDeporte}, '{fechaInicio}', 1";
                oConSQl.insertDatos("EntrenadorDeporte", camposED, valoresED);
                string camposHist = "IdEntrenadorOriginal, IdEntrenadorNuevo, IdDeporte, TipoReemplazo, FechaInicio, FechaFin, Estado, FechaRegistro";
                string valoresHist = $"{this.idEntrenadorSaliente}, {idNuevoEntrenador}, {idDeporte}, '{tipoBD}', '{fechaInicio}', '{fechaFin}', 'Inactivo', GETDATE()";

                oConSQl.insertDatos("ReemplazosEntrenador", camposHist, valoresHist);
            }

            MessageBox.Show("El reemplazo y la inhabilitación del entrenador se guardaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RegresarAAdministracion();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            RegresarAAdministracion();
        }
    }
}
