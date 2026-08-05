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
    public partial class frmVerCompetencias : Form
    {
        public frmVerCompetencias()
        {
            InitializeComponent();
            ConfigurarTablaCompetencias();
        }
        private void ConfigurarTablaCompetencias()
        {
            // Limpiar columnas anteriores
            dgvCompetencias.Columns.Clear();
            dgvCompetencias.Rows.Clear();

            // Crear columnas
            dgvCompetencias.Columns.Add("Fecha", "FECHA");
            dgvCompetencias.Columns.Add("Competencia", "COMPETENCIA");
            dgvCompetencias.Columns.Add("Resultado", "RESULTADO");
            dgvCompetencias.Columns.Add("Posicion", "POSICIÓN");
            dgvCompetencias.Columns.Add("Participantes", "PARTICIPANTES");

            // Estilo general
            dgvCompetencias.BackgroundColor = Color.White;
            dgvCompetencias.BorderStyle = BorderStyle.None;

            dgvCompetencias.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvCompetencias.GridColor =
                Color.FromArgb(235, 235, 235);

            // Encabezado
            dgvCompetencias.EnableHeadersVisualStyles = false;

            dgvCompetencias.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

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
            dgvCompetencias.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 30, 60);

            dgvCompetencias.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F);

            dgvCompetencias.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvCompetencias.DefaultCellStyle.SelectionBackColor =
                Color.White;

            dgvCompetencias.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 30, 60);

            // Ajustar columnas al ancho disponible
            dgvCompetencias.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvCompetencias.Columns["Fecha"].FillWeight = 18;
            dgvCompetencias.Columns["Competencia"].FillWeight = 28;
            dgvCompetencias.Columns["Resultado"].FillWeight = 18;
            dgvCompetencias.Columns["Posicion"].FillWeight = 16;
            dgvCompetencias.Columns["Participantes"].FillWeight = 20;

            // Bloquear edición
            dgvCompetencias.AllowUserToAddRows = false;
            dgvCompetencias.AllowUserToDeleteRows = false;
            dgvCompetencias.AllowUserToResizeRows = false;
            dgvCompetencias.AllowUserToResizeColumns = false;

            dgvCompetencias.ReadOnly = true;
            dgvCompetencias.MultiSelect = false;

            dgvCompetencias.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Filas vacías solo para mostrar el diseño
            for (int i = 0; i < 5; i++)
            {
                dgvCompetencias.Rows.Add("", "", "", "", "");
            }

            dgvCompetencias.ClearSelection();
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
