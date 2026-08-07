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
    public partial class frmDepAdm : Form
    {
        public frmDepAdm()
        {
            InitializeComponent();
            ConfigurarTablaDeportistas();
        }
        private void ConfigurarTablaDeportistas()
        {
            // Limpiar columnas anteriores
            dgvDeportistas.Columns.Clear();
            dgvDeportistas.Rows.Clear();


            // Crear columnas
            dgvDeportistas.Columns.Add("ID", "ID");
            dgvDeportistas.Columns.Add("NombreCompleto", "NOMBRE COMPLETO");
            dgvDeportistas.Columns.Add("Cedula", "CÉDULA");
            dgvDeportistas.Columns.Add("Edad", "EDAD");
            dgvDeportistas.Columns.Add("Disciplinas", "DISCIPLINAS\nACTIVAS");
            dgvDeportistas.Columns.Add("Estado", "ESTADO");
            dgvDeportistas.Columns.Add("Acciones", "ACCIONES");



            // Estilo general
            dgvDeportistas.BackgroundColor = Color.White;
            dgvDeportistas.BorderStyle = BorderStyle.None;

            dgvDeportistas.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvDeportistas.GridColor =
                Color.FromArgb(235, 235, 235);



            // Encabezado
            dgvDeportistas.EnableHeadersVisualStyles = false;

            dgvDeportistas.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

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

            dgvDeportistas.RowTemplate.Height = 45;


            dgvDeportistas.DefaultCellStyle.BackColor =
                Color.White;

            dgvDeportistas.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 30, 60);

            dgvDeportistas.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F);

            dgvDeportistas.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;



            dgvDeportistas.DefaultCellStyle.SelectionBackColor =
                Color.White;

            dgvDeportistas.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 30, 60);



            // Ajustar columnas
            dgvDeportistas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;



            dgvDeportistas.Columns["ID"].FillWeight = 8;

            dgvDeportistas.Columns["NombreCompleto"].FillWeight = 28;

            dgvDeportistas.Columns["Cedula"].FillWeight = 20;

            dgvDeportistas.Columns["Edad"].FillWeight = 12;

            dgvDeportistas.Columns["Disciplinas"].FillWeight = 18;

            dgvDeportistas.Columns["Estado"].FillWeight = 15;

            dgvDeportistas.Columns["Acciones"].FillWeight = 12;



            // Bloquear edición
            dgvDeportistas.AllowUserToAddRows = false;

            dgvDeportistas.AllowUserToDeleteRows = false;

            dgvDeportistas.AllowUserToResizeRows = false;

            dgvDeportistas.AllowUserToResizeColumns = false;


            dgvDeportistas.ReadOnly = true;

            dgvDeportistas.MultiSelect = false;


            dgvDeportistas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;



            // Datos de prueba para diseño
            
            dgvDeportistas.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmRegistroDeportistaAdm frmVerCompetencias = new frmRegistroDeportistaAdm();

            frmVerCompetencias.TopLevel = false;
            frmVerCompetencias.FormBorderStyle = FormBorderStyle.None;
            frmVerCompetencias.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmVerCompetencias);

            frmVerCompetencias.Show();

            this.Close();
        }
    }
}
