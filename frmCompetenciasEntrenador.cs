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
    public partial class frmCompetenciasEntrenador : Form
    {
        public frmCompetenciasEntrenador()
        {
            InitializeComponent();
            ConfigurarTablaCompetencias();
        }
        private void ConfigurarTablaCompetencias()
        {
            // ==========================================
            // LIMPIAR TABLA
            // ==========================================
            dgvCompetencias.Columns.Clear();
            dgvCompetencias.Rows.Clear();


            // ==========================================
            // CREAR COLUMNAS
            // ==========================================
            dgvCompetencias.Columns.Add(
                "NombreCompetencia",
                "NOMBRE DE LA COMPETENCIA");

            dgvCompetencias.Columns.Add(
                "Organizador",
                "ORGANIZADOR");

            dgvCompetencias.Columns.Add(
                "Lugar",
                "LUGAR");

            dgvCompetencias.Columns.Add(
                "Nivel",
                "NIVEL");

            dgvCompetencias.Columns.Add(
                "Deportes",
                "DEPORTES");

            dgvCompetencias.Columns.Add(
                "FechaInicio",
                "FECHA INICIO");

            dgvCompetencias.Columns.Add(
                "FechaFin",
                "FECHA FIN");

            dgvCompetencias.Columns.Add(
                "Inscritos",
                "MIS DEPORTISTAS INSCRITOS");

            dgvCompetencias.Columns.Add(
                "Estado",
                "ESTADO");


            // ==========================================
            // CONFIGURACIÓN GENERAL
            // ==========================================
            dgvCompetencias.BackgroundColor = Color.White;

            dgvCompetencias.BorderStyle =
                BorderStyle.None;

            dgvCompetencias.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvCompetencias.GridColor =
                Color.FromArgb(235, 235, 245);

            dgvCompetencias.RowHeadersVisible = false;

            dgvCompetencias.AllowUserToAddRows = false;
            dgvCompetencias.AllowUserToDeleteRows = false;
            dgvCompetencias.AllowUserToResizeRows = false;
            dgvCompetencias.AllowUserToResizeColumns = false;

            dgvCompetencias.ReadOnly = true;
            dgvCompetencias.MultiSelect = false;

            dgvCompetencias.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCompetencias.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            // ==========================================
            // ENCABEZADO
            // ==========================================
            dgvCompetencias.EnableHeadersVisualStyles = false;

            dgvCompetencias.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 63, 221);

            dgvCompetencias.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvCompetencias.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    9F,
                    FontStyle.Bold);

            dgvCompetencias.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvCompetencias.ColumnHeadersDefaultCellStyle.WrapMode =
                DataGridViewTriState.True;

            // Un poco más alto porque "MIS DEPORTISTAS INSCRITOS"
            // ocupa dos líneas
            dgvCompetencias.ColumnHeadersHeight = 55;

            dgvCompetencias.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvCompetencias.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;


            // ==========================================
            // FILAS
            // ==========================================
            dgvCompetencias.RowTemplate.Height = 55;

            dgvCompetencias.DefaultCellStyle.BackColor =
                Color.White;

            dgvCompetencias.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 40, 95);

            dgvCompetencias.DefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    9F,
                    FontStyle.Regular);

            dgvCompetencias.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvCompetencias.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvCompetencias.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 40, 95);


            // ==========================================
            // TAMAÑO DE COLUMNAS
            // ==========================================
            dgvCompetencias.Columns["NombreCompetencia"]
                .FillWeight = 145;

            dgvCompetencias.Columns["Organizador"]
                .FillWeight = 140;

            dgvCompetencias.Columns["Lugar"]
                .FillWeight = 75;

            dgvCompetencias.Columns["Nivel"]
                .FillWeight = 75;

            dgvCompetencias.Columns["Deportes"]
                .FillWeight = 100;

            dgvCompetencias.Columns["FechaInicio"]
                .FillWeight = 85;

            dgvCompetencias.Columns["FechaFin"]
                .FillWeight = 85;

            dgvCompetencias.Columns["Inscritos"]
                .FillWeight = 90;

            dgvCompetencias.Columns["Estado"]
                .FillWeight = 70;


            // ==========================================
            // ALINEACIÓN
            // ==========================================
            dgvCompetencias.Columns["NombreCompetencia"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvCompetencias.Columns["Organizador"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvCompetencias.Columns["Lugar"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvCompetencias.Columns["Deportes"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;


            // ==========================================
            // QUITAR SELECCIÓN INICIAL
            // ==========================================
            dgvCompetencias.ClearSelection();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAcDes_Click(object sender, EventArgs e)
        {
            if (dgvCompetencias.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione una competencia.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Esto funcionará cuando tengamos IdCompetencia desde SQL.
            int idCompetencia =
                Convert.ToInt32(
                    dgvCompetencias.CurrentRow
                    .Cells["IdCompetencia"].Value);

            frmVerParticipantes frm =
                new frmVerParticipantes();

            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvCompetencias.CurrentRow == null)
            {
                MessageBox.Show(
                    "Seleccione una competencia.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Esto funcionará cuando tengamos IdCompetencia desde SQL.
            int idCompetencia =
                Convert.ToInt32(
                    dgvCompetencias.CurrentRow
                    .Cells["IdCompetencia"].Value);

            frmRegistrarCompetencia frm =
                new frmRegistrarCompetencia(idCompetencia);

            frm.ShowDialog();
        }
    }
}
