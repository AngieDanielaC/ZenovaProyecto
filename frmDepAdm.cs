using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            // LIMPIAR TABLA
            dgvDeportistas.Columns.Clear();
            dgvDeportistas.Rows.Clear();

            // COLUMNA FOTO
            DataGridViewImageColumn colFoto =
                new DataGridViewImageColumn();

            colFoto.Name = "Foto";
            colFoto.HeaderText = "FOTO";
            colFoto.ImageLayout =
                DataGridViewImageCellLayout.Zoom;

            dgvDeportistas.Columns.Add(colFoto);


            // COLUMNAS
            dgvDeportistas.Columns.Add(
                "Nombre",
                "NOMBRE COMPLETO");

            dgvDeportistas.Columns.Add(
                "Cedula",
                "CÉDULA");

            dgvDeportistas.Columns.Add(
                "Edad",
                "EDAD");

            dgvDeportistas.Columns.Add(
                "Disciplinas",
                "DISCIPLINAS ACTIVAS");

            dgvDeportistas.Columns.Add(
                "Estado",
                "ESTADO");

            // CONFIGURACIÓN GENERAL

            dgvDeportistas.BackgroundColor =
                Color.White;

            dgvDeportistas.BorderStyle =
                BorderStyle.None;

            dgvDeportistas.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvDeportistas.GridColor =
                Color.FromArgb(235, 235, 245);

            dgvDeportistas.RowHeadersVisible = false;

            dgvDeportistas.AllowUserToAddRows = false;
            dgvDeportistas.AllowUserToDeleteRows = false;
            dgvDeportistas.AllowUserToResizeRows = false;
            dgvDeportistas.AllowUserToResizeColumns = false;

            dgvDeportistas.ReadOnly = true;

            dgvDeportistas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvDeportistas.MultiSelect = false;

            dgvDeportistas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            // ==========================================
            // ENCABEZADO
            // ==========================================
            dgvDeportistas.EnableHeadersVisualStyles =
                false;

            dgvDeportistas.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 63, 221);

            dgvDeportistas.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvDeportistas.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    12,
                    FontStyle.Bold);

            dgvDeportistas.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.ColumnHeadersHeight = 50;

            dgvDeportistas.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvDeportistas.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;


            // ESTILO DE LAS FILAS
            dgvDeportistas.DefaultCellStyle.BackColor =
                Color.White;

            dgvDeportistas.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 40, 95);

            dgvDeportistas.DefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    10,
                    FontStyle.Regular);

            dgvDeportistas.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            // COLOR DE SELECCIÓN

            dgvDeportistas.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvDeportistas.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 40, 95);


            // ALTURA DE FILAS
            dgvDeportistas.RowTemplate.Height = 60;



            // TAMAÑO DE COLUMNAS

            dgvDeportistas.Columns["Foto"].FillWeight = 50;

            dgvDeportistas.Columns["Nombre"].FillWeight = 150;

            dgvDeportistas.Columns["Cedula"].FillWeight = 90;

            dgvDeportistas.Columns["Edad"].FillWeight = 55;

            dgvDeportistas.Columns["Disciplinas"].FillWeight = 130;

            dgvDeportistas.Columns["Estado"].FillWeight = 75;


            // ALINEACIÓN

            dgvDeportistas.Columns["Foto"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.Columns["Nombre"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvDeportistas.Columns["Cedula"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.Columns["Edad"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.Columns["Disciplinas"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.Columns["Estado"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            // Ninguna fila seleccionada inicialmente
            dgvDeportistas.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
        }
      
        
        private void frmDepAdm_Load(object sender, EventArgs e)
        {

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAcDes_Click(object sender, EventArgs e)
        {
           
        }
    }
}
