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
    public partial class frmSubCompetencia : Form
    {
        public frmSubCompetencia()
        {
            InitializeComponent();
            ConfigurarTablaCompetencias();
        }
        private void ConfigurarTablaCompetencias()
        {
            // Limpiar columnas
            dgvCompetencias.Columns.Clear();

            // Crear columnas
            dgvCompetencias.Columns.Add("Fecha", "FECHA");
            dgvCompetencias.Columns.Add("Competencia", "COMPETENCIA");
            dgvCompetencias.Columns.Add("Resultado", "RESULTADO");
            dgvCompetencias.Columns.Add("Posicion", "POSICIÓN");
            dgvCompetencias.Columns.Add("Participantes", "PARTICIPANTES");

            // Fondo
            dgvCompetencias.BackgroundColor = Color.White;
            dgvCompetencias.BorderStyle = BorderStyle.None;

            // Encabezado
            dgvCompetencias.EnableHeadersVisualStyles = false;
            dgvCompetencias.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvCompetencias.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvCompetencias.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvCompetencias.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvCompetencias.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvCompetencias.ColumnHeadersHeight = 50;
            dgvCompetencias.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Filas
            dgvCompetencias.RowHeadersVisible = false;
            dgvCompetencias.RowTemplate.Height = 45;

            dgvCompetencias.DefaultCellStyle.BackColor = Color.White;
            dgvCompetencias.DefaultCellStyle.ForeColor = Color.Black;
            dgvCompetencias.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F);

            dgvCompetencias.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvCompetencias.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvCompetencias.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Bordes
            dgvCompetencias.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvCompetencias.GridColor =
                Color.FromArgb(235, 235, 235);

            // Ajustar columnas
            dgvCompetencias.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvCompetencias.Columns["Fecha"].FillWeight = 18;
            dgvCompetencias.Columns["Competencia"].FillWeight = 28;
            dgvCompetencias.Columns["Resultado"].FillWeight = 18;
            dgvCompetencias.Columns["Posicion"].FillWeight = 18;
            dgvCompetencias.Columns["Participantes"].FillWeight = 18;

            // Configuración general
            dgvCompetencias.AllowUserToAddRows = false;
            dgvCompetencias.AllowUserToDeleteRows = false;
            dgvCompetencias.AllowUserToResizeRows = false;
            dgvCompetencias.AllowUserToResizeColumns = false;

            dgvCompetencias.MultiSelect = false;
            dgvCompetencias.ReadOnly = true;
            dgvCompetencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Filas vacías (solo diseño)
            for (int i = 0; i < 5; i++)
            {
                dgvCompetencias.Rows.Add("", "", "", "", "");
            }

            dgvCompetencias.ClearSelection();
        }

        private void btnVerComptencias_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmVerCompetencias frmVerCompetencias  = new frmVerCompetencias();

            frmVerCompetencias.TopLevel = false;
            frmVerCompetencias.FormBorderStyle = FormBorderStyle.None;
            frmVerCompetencias.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmVerCompetencias);

            frmVerCompetencias.Show();

            this.Close();
        }

        private void btnCompetencias_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmCompararCompetencias frmSubCompetencia = new frmCompararCompetencias();

            frmSubCompetencia.TopLevel = false;
            frmSubCompetencia.FormBorderStyle = FormBorderStyle.None;
            frmSubCompetencia.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmSubCompetencia);

            frmSubCompetencia.Show();

            this.Close();
        }

        private void btnRegistrarCompetencia_Click(object sender, EventArgs e)
        {
            frmRegistrarCompetencia frm = new frmRegistrarCompetencia();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmCompetencias frmSubCompetencia = new frmCompetencias();

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
