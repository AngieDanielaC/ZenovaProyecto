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
    public partial class frmSubEntrenamientos : Form
    {
        public frmSubEntrenamientos()
        {
            InitializeComponent();
            ConfigurarTablaEjercicios();
        }
        private void ConfigurarTablaEjercicios()
        {
            // Limpiar columnas y filas
            dgvEjercicios.Columns.Clear();
            dgvEjercicios.Rows.Clear();

            // Columnas
            dgvEjercicios.Columns.Add("Ejercicio", "EJERCICIO");
            dgvEjercicios.Columns.Add("Serie", "SERIE");
            dgvEjercicios.Columns.Add("Repeticiones", "REPETICIONES");
            dgvEjercicios.Columns.Add("Peso", "PESO");
            dgvEjercicios.Columns.Add("Tiempo", "TIEMPO /\nDISTANCIA");
            dgvEjercicios.Columns.Add("Descanso", "DESCANSO");
            dgvEjercicios.Columns.Add("Intensidad", "INTENSIDAD");

            // ===== Apariencia General =====
            dgvEjercicios.BackgroundColor = Color.White;
            dgvEjercicios.BorderStyle = BorderStyle.None;
            dgvEjercicios.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEjercicios.GridColor = Color.FromArgb(235, 235, 235);

            // ===== Encabezado =====
            dgvEjercicios.EnableHeadersVisualStyles = false;
            dgvEjercicios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvEjercicios.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvEjercicios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvEjercicios.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvEjercicios.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvEjercicios.ColumnHeadersHeight = 55;
            dgvEjercicios.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ===== Filas =====
            dgvEjercicios.RowHeadersVisible = false;
            dgvEjercicios.RowTemplate.Height = 42;

            dgvEjercicios.DefaultCellStyle.BackColor = Color.White;
            dgvEjercicios.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            dgvEjercicios.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Regular);

            dgvEjercicios.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvEjercicios.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(232, 238, 255);

            dgvEjercicios.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            // ===== Configuración =====
            dgvEjercicios.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvEjercicios.AllowUserToAddRows = false;
            dgvEjercicios.AllowUserToDeleteRows = false;
            dgvEjercicios.AllowUserToResizeRows = false;
            dgvEjercicios.AllowUserToResizeColumns = false;

            dgvEjercicios.ReadOnly = true;
            dgvEjercicios.MultiSelect = false;
            dgvEjercicios.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // ===== Tamaño de columnas =====
            dgvEjercicios.Columns["Ejercicio"].FillWeight = 24;
            dgvEjercicios.Columns["Serie"].FillWeight = 10;
            dgvEjercicios.Columns["Repeticiones"].FillWeight = 15;
            dgvEjercicios.Columns["Peso"].FillWeight = 12;
            dgvEjercicios.Columns["Tiempo"].FillWeight = 18;
            dgvEjercicios.Columns["Descanso"].FillWeight = 12;
            dgvEjercicios.Columns["Intensidad"].FillWeight = 14;

            // ===== Filas vacías (solo diseño) =====
            for (int i = 0; i < 5; i++)
            {
                dgvEjercicios.Rows.Add("", "", "", "", "", "", "");
            }

            dgvEjercicios.ClearSelection();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmEntrenamientos frmSubCompetencia = new frmEntrenamientos();

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
