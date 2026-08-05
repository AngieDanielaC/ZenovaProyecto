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
    public partial class frmCompararCompetencias : Form
    {
        public frmCompararCompetencias()
        {
            InitializeComponent();
            ConfigurarTablaComparar();
        }
        private void ConfigurarTablaComparar()
        {
            // Limpiar columnas y filas
            dgvComparar.Columns.Clear();
            dgvComparar.Rows.Clear();

            // Crear columnas
            dgvComparar.Columns.Add("Aspecto", "ASPECTO");
            dgvComparar.Columns.Add("CompetenciaA", "COMPETENCIA A");
            dgvComparar.Columns.Add("CompetenciaB", "COMPETENCIA B");
            dgvComparar.Columns.Add("Variacion", "VARIACIÓN");

            // Fondo
            dgvComparar.BackgroundColor = Color.White;
            dgvComparar.BorderStyle = BorderStyle.None;

            // Líneas
            dgvComparar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvComparar.GridColor = Color.FromArgb(235, 235, 235);

            // Encabezado
            dgvComparar.EnableHeadersVisualStyles = false;
            dgvComparar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvComparar.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvComparar.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvComparar.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvComparar.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvComparar.ColumnHeadersHeight = 50;
            dgvComparar.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Filas
            dgvComparar.RowHeadersVisible = false;
            dgvComparar.RowTemplate.Height = 45;

            dgvComparar.DefaultCellStyle.BackColor = Color.White;
            dgvComparar.DefaultCellStyle.ForeColor =
                Color.FromArgb(30, 30, 30);

            dgvComparar.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F);

            dgvComparar.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvComparar.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvComparar.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(30, 30, 30);

            // Ajuste de columnas
            dgvComparar.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvComparar.Columns["Aspecto"].FillWeight = 25;
            dgvComparar.Columns["CompetenciaA"].FillWeight = 30;
            dgvComparar.Columns["CompetenciaB"].FillWeight = 30;
            dgvComparar.Columns["Variacion"].FillWeight = 20;

            // Configuración general
            dgvComparar.AllowUserToAddRows = false;
            dgvComparar.AllowUserToDeleteRows = false;
            dgvComparar.AllowUserToResizeRows = false;
            dgvComparar.AllowUserToResizeColumns = false;

            dgvComparar.ReadOnly = true;
            dgvComparar.MultiSelect = false;
            dgvComparar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Filas vacías (solo diseño)
            for (int i = 0; i < 5; i++)
            {
                dgvComparar.Rows.Add("", "", "", "");
            }

            dgvComparar.ClearSelection();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmSubCompetencia frmSubCompetencia = new frmSubCompetencia();

            frmSubCompetencia.TopLevel = false;
            frmSubCompetencia.FormBorderStyle = FormBorderStyle.None;
            frmSubCompetencia.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmSubCompetencia);

            frmSubCompetencia.Show();

            this.Close();
        }
    }
}
