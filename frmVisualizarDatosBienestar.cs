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
    public partial class frmVisualizarDatosBienestar : Form
    {
        public frmVisualizarDatosBienestar()
        {
            InitializeComponent();
            ConfigurarTablaVisualizar();
        }
        private void ConfigurarTablaVisualizar()
        {
            // Limpiar columnas y filas
            dgvVisualizar.Columns.Clear();
            dgvVisualizar.Rows.Clear();

            // Crear columnas
            dgvVisualizar.Columns.Add("Deportista", "DEPORTISTA");
            dgvVisualizar.Columns.Add("GastoCalorico", "GASTO\nCALÓRICO");
            dgvVisualizar.Columns.Add("RiesgoLesion", "RIESGO DE\nLESIÓN");
            dgvVisualizar.Columns.Add("Recuperacion", "RECUPERACIÓN\nESTIMADA");
            dgvVisualizar.Columns.Add("Peso", "PESO (KG)");

            // Apariencia general
            dgvVisualizar.BackgroundColor = Color.White;
            dgvVisualizar.BorderStyle = BorderStyle.None;
            dgvVisualizar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVisualizar.GridColor = Color.FromArgb(235, 235, 235);

            // Encabezado
            dgvVisualizar.EnableHeadersVisualStyles = false;
            dgvVisualizar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvVisualizar.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvVisualizar.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvVisualizar.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvVisualizar.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvVisualizar.ColumnHeadersHeight = 55;
            dgvVisualizar.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Filas
            dgvVisualizar.RowHeadersVisible = false;
            dgvVisualizar.RowTemplate.Height = 45;

            dgvVisualizar.DefaultCellStyle.BackColor = Color.White;
            dgvVisualizar.DefaultCellStyle.ForeColor = Color.FromArgb(35, 35, 35);
            dgvVisualizar.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvVisualizar.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvVisualizar.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvVisualizar.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Ajustar columnas
            dgvVisualizar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvVisualizar.Columns["Deportista"].FillWeight = 24;
            dgvVisualizar.Columns["GastoCalorico"].FillWeight = 18;
            dgvVisualizar.Columns["RiesgoLesion"].FillWeight = 18;
            dgvVisualizar.Columns["Recuperacion"].FillWeight = 22;
            dgvVisualizar.Columns["Peso"].FillWeight = 18;

            // Configuración
            dgvVisualizar.AllowUserToAddRows = false;
            dgvVisualizar.AllowUserToDeleteRows = false;
            dgvVisualizar.AllowUserToResizeRows = false;
            dgvVisualizar.AllowUserToResizeColumns = false;

            dgvVisualizar.ReadOnly = true;
            dgvVisualizar.MultiSelect = false;
            dgvVisualizar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Filas vacías (solo diseño)
            for (int i = 0; i < 5; i++)
            {
                dgvVisualizar.Rows.Add("", "", "", "", "");
            }

            dgvVisualizar.ClearSelection();
        }
    }
}
