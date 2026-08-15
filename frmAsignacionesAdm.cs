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
    public partial class frmAsignacionesAdm : Form
    {
        public frmAsignacionesAdm()
        {
            InitializeComponent();

            ConfigurarTablaAsignaciones();

           
        }
        private void ConfigurarTablaAsignaciones()
        {
            dgvAsignaciones.Columns.Clear();
            dgvAsignaciones.Rows.Clear();

            // ID oculto
            dgvAsignaciones.Columns.Add("IdInscripcion", "ID");

            // Columnas visibles
            dgvAsignaciones.Columns.Add("Disciplina", "DISCIPLINA");
            dgvAsignaciones.Columns.Add("Entrenador", "ENTRENADOR");
            dgvAsignaciones.Columns.Add("Inicio", "INICIO");
            dgvAsignaciones.Columns.Add("Fin", "FIN");
            dgvAsignaciones.Columns.Add("Estado", "ESTADO");

            // Ocultar ID
            dgvAsignaciones.Columns["IdInscripcion"].Visible = false;

            // ==========================================
            // ESTILO GENERAL
            // ==========================================
            dgvAsignaciones.BackgroundColor = Color.White;
            dgvAsignaciones.BorderStyle = BorderStyle.None;

            dgvAsignaciones.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvAsignaciones.GridColor =
                Color.FromArgb(235, 235, 235);

            dgvAsignaciones.RowHeadersVisible = false;

            dgvAsignaciones.AllowUserToAddRows = false;
            dgvAsignaciones.AllowUserToDeleteRows = false;
            dgvAsignaciones.AllowUserToResizeRows = false;
            dgvAsignaciones.AllowUserToResizeColumns = false;

            dgvAsignaciones.ReadOnly = true;

            dgvAsignaciones.MultiSelect = false;

            dgvAsignaciones.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAsignaciones.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvAsignaciones.RowTemplate.Height = 50;


            // ==========================================
            // ENCABEZADO
            // ==========================================
            dgvAsignaciones.EnableHeadersVisualStyles = false;

            dgvAsignaciones.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    11F,
                    FontStyle.Bold);

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvAsignaciones.ColumnHeadersHeight = 50;

            dgvAsignaciones.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            // ==========================================
            // FILAS
            // ==========================================
            dgvAsignaciones.DefaultCellStyle.BackColor =
                Color.White;

            dgvAsignaciones.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 30, 60);

            dgvAsignaciones.DefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    10F,
                    FontStyle.Regular);

            dgvAsignaciones.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvAsignaciones.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvAsignaciones.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 30, 60);


            // ==========================================
            // TAMAÑO DE COLUMNAS
            // ==========================================
            dgvAsignaciones.Columns["Disciplina"].FillWeight = 22;
            dgvAsignaciones.Columns["Entrenador"].FillWeight = 27;
            dgvAsignaciones.Columns["Inicio"].FillWeight = 17;
            dgvAsignaciones.Columns["Fin"].FillWeight = 17;
            dgvAsignaciones.Columns["Estado"].FillWeight = 17;


            // Ninguna fila seleccionada al inicio
            dgvAsignaciones.ClearSelection();
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
        }

        private void frmAsignacionesAdm_Load(object sender, EventArgs e)
        {
            
        }
        

        private void cmbDeportista_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        
        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        


        
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCambiarEntrenador_Click(object sender, EventArgs e)
        {
            
        }
    }
}
