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
    public partial class frmDeportistas : Form
    {
        public frmDeportistas()
        {
            InitializeComponent();
            ConfigurarEncabezadoTabla();
        }
        private void ConfigurarEncabezadoTabla()
        {
            // Limpiar columnas
            dgvDeportistas.Columns.Clear();

            // Crear columnas
            dgvDeportistas.Columns.Add("Nombre", "NOMBRE");
            dgvDeportistas.Columns.Add("Deporte", "DEPORTE");
            dgvDeportistas.Columns.Add("Categoria", "CATEGORÍA");
            dgvDeportistas.Columns.Add("Edad", "EDAD");
            dgvDeportistas.Columns.Add("Accion", "ACCIÓN");

            // Fondo
            dgvDeportistas.BackgroundColor = Color.White;
            dgvDeportistas.BorderStyle = BorderStyle.None;

            // Quitar bordes
            dgvDeportistas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDeportistas.GridColor = Color.FromArgb(240, 240, 240);

            // Encabezado
            dgvDeportistas.EnableHeadersVisualStyles = false;
            dgvDeportistas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvDeportistas.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvDeportistas.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvDeportistas.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvDeportistas.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.ColumnHeadersHeight = 50;
            dgvDeportistas.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Filas
            dgvDeportistas.RowHeadersVisible = false;
            dgvDeportistas.RowTemplate.Height = 50;

            dgvDeportistas.DefaultCellStyle.BackColor = Color.White;
            dgvDeportistas.DefaultCellStyle.ForeColor = Color.Black;
            dgvDeportistas.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F);

            dgvDeportistas.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvDeportistas.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvDeportistas.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // Tamaño de columnas
            dgvDeportistas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvDeportistas.Columns["Nombre"].FillWeight = 35;
            dgvDeportistas.Columns["Deporte"].FillWeight = 20;
            dgvDeportistas.Columns["Categoria"].FillWeight = 18;
            dgvDeportistas.Columns["Edad"].FillWeight = 10;
            dgvDeportistas.Columns["Accion"].FillWeight = 17;

            // Configuración general
            dgvDeportistas.AllowUserToAddRows = false;
            dgvDeportistas.AllowUserToDeleteRows = false;
            dgvDeportistas.AllowUserToResizeRows = false;
            dgvDeportistas.AllowUserToResizeColumns = false;

            dgvDeportistas.MultiSelect = false;
            dgvDeportistas.ReadOnly = true;

            dgvDeportistas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Filas de ejemplo (solo diseño)
            dgvDeportistas.Rows.Clear();

            for (int i = 0; i < 6; i++)
            {
                dgvDeportistas.Rows.Add("", "", "", "", "");
            }

            dgvDeportistas.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmNuevoDeportista frm = new frmNuevoDeportista();
            frm.Show();
        }
    }
}
