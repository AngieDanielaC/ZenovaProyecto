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
    public partial class frmGastoCalorico : Form
    {
        public frmGastoCalorico()
        {
            InitializeComponent();
            ConfigurarTablaEnergia();
        }
        private void ConfigurarTablaEnergia()
        {
            // Limpiar columnas y filas
            dgvEnergia.Columns.Clear();
            dgvEnergia.Rows.Clear();

            // Crear columnas
            dgvEnergia.Columns.Add("Deportista", "DEPORTISTA");
            dgvEnergia.Columns.Add("Peso", "PESO");
            dgvEnergia.Columns.Add("Energia", "ENERGÍA");
            dgvEnergia.Columns.Add("Intensidad", "INTENSIDAD");
            dgvEnergia.Columns.Add("Duracion", "DURACIÓN DEL\nENTRENAMIENTO");
            dgvEnergia.Columns.Add("GastoCalorico", "GASTO\nCALÓRICO");
            dgvEnergia.Columns.Add("Deficit", "DÉFICIT\nENERGÉTICO");

            // Apariencia general
            dgvEnergia.BackgroundColor = Color.White;
            dgvEnergia.BorderStyle = BorderStyle.None;
            dgvEnergia.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEnergia.GridColor = Color.FromArgb(235, 235, 235);

            // Encabezado
            dgvEnergia.EnableHeadersVisualStyles = false;
            dgvEnergia.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvEnergia.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvEnergia.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvEnergia.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvEnergia.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvEnergia.ColumnHeadersHeight = 55;
            dgvEnergia.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Filas
            dgvEnergia.RowHeadersVisible = false;
            dgvEnergia.RowTemplate.Height = 45;

            dgvEnergia.DefaultCellStyle.BackColor = Color.White;
            dgvEnergia.DefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
            dgvEnergia.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvEnergia.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvEnergia.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvEnergia.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Ajustar columnas
            dgvEnergia.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvEnergia.Columns["Deportista"].FillWeight = 22;
            dgvEnergia.Columns["Peso"].FillWeight = 12;
            dgvEnergia.Columns["Energia"].FillWeight = 16;
            dgvEnergia.Columns["Intensidad"].FillWeight = 16;
            dgvEnergia.Columns["Duracion"].FillWeight = 20;
            dgvEnergia.Columns["GastoCalorico"].FillWeight = 16;
            dgvEnergia.Columns["Deficit"].FillWeight = 16;

            // Configuración general
            dgvEnergia.AllowUserToAddRows = false;
            dgvEnergia.AllowUserToDeleteRows = false;
            dgvEnergia.AllowUserToResizeRows = false;
            dgvEnergia.AllowUserToResizeColumns = false;

            dgvEnergia.ReadOnly = true;
            dgvEnergia.MultiSelect = false;
            dgvEnergia.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Filas vacías (solo diseño)
            for (int i = 0; i < 5; i++)
            {
                dgvEnergia.Rows.Add("", "", "", "", "", "", "");
            }

            dgvEnergia.ClearSelection();
        }
    }
}
