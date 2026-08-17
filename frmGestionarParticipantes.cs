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
    public partial class frmGestionarParticipantes : Form
    {
        public frmGestionarParticipantes()
        {
            InitializeComponent();
            ConfigurarTablaParticipantes();
        }
        private void ConfigurarTablaParticipantes()
        {
            // ==========================================
            // LIMPIAR TABLA
            // ==========================================
            dgvParticipantes.Columns.Clear();
            dgvParticipantes.Rows.Clear();


            // ==========================================
            // COLUMNA CHECKBOX
            // ==========================================
            DataGridViewCheckBoxColumn colSeleccionar =
                new DataGridViewCheckBoxColumn();

            colSeleccionar.Name = "Seleccionar";
            colSeleccionar.HeaderText = "";
            colSeleccionar.Width = 50;
            colSeleccionar.FillWeight = 30;

            colSeleccionar.TrueValue = true;
            colSeleccionar.FalseValue = false;

            dgvParticipantes.Columns.Add(colSeleccionar);


            // ==========================================
            // COLUMNAS
            // ==========================================
            dgvParticipantes.Columns.Add(
                "NombreCompleto",
                "NOMBRE COMPLETO");

            dgvParticipantes.Columns.Add(
                "Cedula",
                "CÉDULA");

            dgvParticipantes.Columns.Add(
                "Edad",
                "EDAD");

            dgvParticipantes.Columns.Add(
                "Genero",
                "GÉNERO");

            dgvParticipantes.Columns.Add(
                "Entrenador",
                "ENTRENADOR RESPONSABLE");


            // ==========================================
            // CONFIGURACIÓN GENERAL
            // ==========================================
            dgvParticipantes.BackgroundColor =
                Color.White;

            dgvParticipantes.BorderStyle =
                BorderStyle.None;

            dgvParticipantes.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvParticipantes.GridColor =
                Color.FromArgb(235, 235, 245);

            dgvParticipantes.RowHeadersVisible =
                false;

            dgvParticipantes.AllowUserToAddRows =
                false;

            dgvParticipantes.AllowUserToDeleteRows =
                false;

            dgvParticipantes.AllowUserToResizeRows =
                false;

            dgvParticipantes.AllowUserToResizeColumns =
                false;

            dgvParticipantes.MultiSelect =
                false;

            dgvParticipantes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvParticipantes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            // ==========================================
            // IMPORTANTE:
            // Permitimos marcar únicamente el CheckBox
            // ==========================================
            dgvParticipantes.ReadOnly = false;

            foreach (DataGridViewColumn columna
                     in dgvParticipantes.Columns)
            {
                columna.ReadOnly = true;
            }

            dgvParticipantes.Columns["Seleccionar"].ReadOnly =
                false;


            // ==========================================
            // ENCABEZADOS
            // ==========================================
            dgvParticipantes.EnableHeadersVisualStyles =
                false;

            dgvParticipantes.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 63, 221);

            dgvParticipantes.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvParticipantes.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    10F,
                    FontStyle.Bold);

            dgvParticipantes.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvParticipantes.ColumnHeadersHeight =
                50;

            dgvParticipantes.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvParticipantes.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;


            // ==========================================
            // FILAS
            // ==========================================
            dgvParticipantes.RowTemplate.Height =
                55;

            dgvParticipantes.DefaultCellStyle.BackColor =
                Color.White;

            dgvParticipantes.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 40, 95);

            dgvParticipantes.DefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    10F,
                    FontStyle.Regular);

            dgvParticipantes.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvParticipantes.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvParticipantes.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 40, 95);


            // ==========================================
            // TAMAÑOS
            // ==========================================
            dgvParticipantes.Columns["Seleccionar"]
                .FillWeight = 30;

            dgvParticipantes.Columns["NombreCompleto"]
                .FillWeight = 150;

            dgvParticipantes.Columns["Cedula"]
                .FillWeight = 90;

            dgvParticipantes.Columns["Edad"]
                .FillWeight = 55;

            dgvParticipantes.Columns["Genero"]
                .FillWeight = 80;

            dgvParticipantes.Columns["Entrenador"]
                .FillWeight = 140;


            // ==========================================
            // ALINEACIÓN
            // ==========================================
            dgvParticipantes.Columns["NombreCompleto"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvParticipantes.Columns["Entrenador"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvParticipantes.Columns["Seleccionar"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            dgvParticipantes.ClearSelection();
        }
    }
}
