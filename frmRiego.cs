using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmRiego : Form
    {
        csConectaSQL oCon = new csConectaSQL();
        public frmRiego()
        {
            InitializeComponent();
            ConfigurarTablaRiesgo();
        }
        private void ConfigurarTablaRiesgo()
        {
            // Limpiar columnas y filas
            dgvRiesgo.Columns.Clear();
            dgvRiesgo.Rows.Clear();

            // Crear columnas
            dgvRiesgo.Columns.Add("Deportista", "DEPORTISTA");
            dgvRiesgo.Columns.Add("HorasSueno", "HORAS DE\nSUEÑO");
            dgvRiesgo.Columns.Add("Intensidad", "INTENSIDAD");
            dgvRiesgo.Columns.Add("Riesgo", "RIESGO");

            // Apariencia general
            dgvRiesgo.BackgroundColor = Color.White;
            dgvRiesgo.BorderStyle = BorderStyle.None;
            dgvRiesgo.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRiesgo.GridColor = Color.FromArgb(235, 235, 235);

            // Encabezado
            dgvRiesgo.EnableHeadersVisualStyles = false;
            dgvRiesgo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvRiesgo.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvRiesgo.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvRiesgo.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvRiesgo.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvRiesgo.ColumnHeadersHeight = 55;
            dgvRiesgo.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Filas
            dgvRiesgo.RowHeadersVisible = false;
            dgvRiesgo.RowTemplate.Height = 45;

            dgvRiesgo.DefaultCellStyle.BackColor = Color.White;
            dgvRiesgo.DefaultCellStyle.ForeColor =
                Color.FromArgb(30, 30, 30);

            dgvRiesgo.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F);

            dgvRiesgo.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvRiesgo.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvRiesgo.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Ajustar columnas
            dgvRiesgo.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvRiesgo.Columns["Deportista"].FillWeight = 30;
            dgvRiesgo.Columns["HorasSueno"].FillWeight = 25;
            dgvRiesgo.Columns["Intensidad"].FillWeight = 22;
            dgvRiesgo.Columns["Riesgo"].FillWeight = 23;

            // Configuración
            dgvRiesgo.AllowUserToAddRows = false;
            dgvRiesgo.AllowUserToDeleteRows = false;
            dgvRiesgo.AllowUserToResizeRows = false;
            dgvRiesgo.AllowUserToResizeColumns = false;

            dgvRiesgo.ReadOnly = true;
            dgvRiesgo.MultiSelect = false;
            dgvRiesgo.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvRiesgo.AutoGenerateColumns = false;

            // Mapeo explicito de DataPropertyName
            dgvRiesgo.Columns["Deportista"].DataPropertyName = "DEPORTISTA";
            dgvRiesgo.Columns["HorasSueno"].DataPropertyName = "HORAS DE SUEÑO";
            dgvRiesgo.Columns["Intensidad"].DataPropertyName = "INTENSIDAD";
            dgvRiesgo.Columns["Riesgo"].DataPropertyName = "RIESGO";
        }
        private void CargarTablaRiesgo()
        {
            string query = @"
        SELECT 
            (D.Nombres + ' ' + D.Apellidos) AS DEPORTISTA,
            R.horas_de_sueño AS [HORAS DE SUEÑO],
            R.IEntrenamiento AS INTENSIDAD, -- Cambiado lEntrenamiento a IEntrenamiento
            R.Riesgo AS RIESGO
        FROM RiesgoFatiga R
        INNER JOIN Deportistas D ON R.idDeportista = D.IdDeportista";

            DataTable dt = oCon.RetornaRegistros(query);

            if (dt != null)
            {
                dgvRiesgo.DataSource = dt;
            }

            dgvRiesgo.ClearSelection();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void CargarDeportistas()
        {
            string query = "SELECT IdDeportista, (Nombres + ' ' + Apellidos) AS NombreCompleto FROM Deportistas WHERE Estado = 1";
            DataTable dtDeportistas = oCon.RetornaRegistros(query);
            if (dtDeportistas != null && dtDeportistas.Rows.Count > 0)
            {
                cmbSelDeportista.DataSource = dtDeportistas;
                cmbSelDeportista.DisplayMember = "NombreCompleto";
                cmbSelDeportista.ValueMember = "IdDeportista";
                cmbSelDeportista.SelectedIndex = -1;
            }
        }
        private void frmRiego_Load(object sender, EventArgs e)
        {
            CargarDeportistas();
            CargarTablaRiesgo();
        }

        private void txtbhorasS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool ValidarCampos()
        {
            if (cmbSelDeportista.SelectedIndex == -1 || cmbSelDeportista.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un deportista de la lista.",
                                "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSelDeportista.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtbhorasS.Text))
            {
                MessageBox.Show("Por favor, ingrese las horas de sueño.",
                                "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbhorasS.Focus();
                return false;
            }
            if (!int.TryParse(txtbhorasS.Text.Trim(), out int horas) || horas < 0 || horas > 12)
            {
                MessageBox.Show("Ingrese una cantidad válida de horas de sueño (entre 0 y 12 horas).",
                                "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbhorasS.SelectAll();
                txtbhorasS.Focus();
                return false;
            }
            if (!rbnAlto.Checked && !rbnMedio.Checked && !rbnBajo.Checked)
            {
                MessageBox.Show("Por favor, seleccione un nivel de intensidad de entrenamiento (Alto, Medio o Bajo).",
                                "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnRegisterSueño_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            int idDeportista = Convert.ToInt32(cmbSelDeportista.SelectedValue);
            int horasSueno = Convert.ToInt32(txtbhorasS.Text.Trim());

            string intensidad = "Bajo";
            if (rbnAlto.Checked) intensidad = "Alto";
            else if (rbnMedio.Checked) intensidad = "Medio";
            else if (rbnBajo.Checked) intensidad = "Bajo";
            string nivelRiesgo = "Bajo";
            if (horasSueno < 6 && intensidad == "Alto")
            {
                nivelRiesgo = "Alto";
            }
            else if (horasSueno < 7 || (horasSueno < 8 && intensidad == "Alto"))
            {
                nivelRiesgo = "Medio";
            }
            string campos = "idDeportista, horas_de_sueño, IEntrenamiento, Riesgo";
            string valores = $"{idDeportista}, {horasSueno}, '{intensidad}', '{nivelRiesgo}'";

            if (oCon.insertDatos("RiesgoFatiga", campos, valores))
            {
                MessageBox.Show($"Registro guardado correctamente.\nNivel de Riesgo Calculado: {nivelRiesgo}",
                                "Zenova", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbSelDeportista.SelectedIndex = -1;
                txtbhorasS.Clear();
                rbnAlto.Checked = false;
                rbnMedio.Checked = false;
                rbnBajo.Checked = false;
                CargarTablaRiesgo();
            }
        }
    }
}
