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

            // Filas vacías (solo diseño)
            for (int i = 0; i < 5; i++)
            {
                dgvRiesgo.Rows.Add("", "", "", "");
            }

            dgvRiesgo.ClearSelection();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
