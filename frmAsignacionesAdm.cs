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
    public partial class frmAsignacionesAdm : Form
    {
        public frmAsignacionesAdm()
        {
            InitializeComponent();
            ConfigurarTablaAsignaciones();
        }
        private void ConfigurarTablaAsignaciones()
        {
            // Limpiar columnas anteriores
            dgvAsignaciones.Columns.Clear();
            dgvAsignaciones.Rows.Clear();


            // Crear columnas
            dgvAsignaciones.Columns.Add("Disciplina", "DISCIPLINA");
            dgvAsignaciones.Columns.Add("Entrenador", "ENTRENADOR");
            dgvAsignaciones.Columns.Add("Inicio", "INICIO");
            dgvAsignaciones.Columns.Add("Fin", "FIN");
            dgvAsignaciones.Columns.Add("Estado", "ESTADO");



            // Estilo general
            dgvAsignaciones.BackgroundColor = Color.White;
            dgvAsignaciones.BorderStyle = BorderStyle.None;

            dgvAsignaciones.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvAsignaciones.GridColor =
                Color.FromArgb(235, 235, 235);



            // Encabezado
            dgvAsignaciones.EnableHeadersVisualStyles = false;

            dgvAsignaciones.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvAsignaciones.ColumnHeadersHeight = 50;

            dgvAsignaciones.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;



            // Filas
            dgvAsignaciones.RowHeadersVisible = false;

            dgvAsignaciones.RowTemplate.Height = 45;


            dgvAsignaciones.DefaultCellStyle.BackColor =
                Color.White;

            dgvAsignaciones.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 30, 60);

            dgvAsignaciones.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F);

            dgvAsignaciones.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;



            dgvAsignaciones.DefaultCellStyle.SelectionBackColor =
                Color.White;

            dgvAsignaciones.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 30, 60);



            // Ajustar columnas
            dgvAsignaciones.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            dgvAsignaciones.Columns["Disciplina"].FillWeight = 22;

            dgvAsignaciones.Columns["Entrenador"].FillWeight = 25;

            dgvAsignaciones.Columns["Inicio"].FillWeight = 18;

            dgvAsignaciones.Columns["Fin"].FillWeight = 18;

            dgvAsignaciones.Columns["Estado"].FillWeight = 17;



            // Bloquear edición
            dgvAsignaciones.AllowUserToAddRows = false;

            dgvAsignaciones.AllowUserToDeleteRows = false;

            dgvAsignaciones.AllowUserToResizeRows = false;

            dgvAsignaciones.AllowUserToResizeColumns = false;


            dgvAsignaciones.ReadOnly = true;

            dgvAsignaciones.MultiSelect = false;


            dgvAsignaciones.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAsignaciones.ClearSelection();
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}
