using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmEntrenadorAdm : Form
    {
        public frmEntrenadorAdm()
        {
            InitializeComponent();
            ConfigurarTablaEntrenadores();
        }
        private void ConfigurarTablaEntrenadores()
        {
            dgvEntrenadores.Columns.Clear();
            dgvEntrenadores.Rows.Clear();


            // ======================================
            // COLUMNAS
            // ======================================

            // ID OCULTO
            dgvEntrenadores.Columns.Add(
                "IdEntrenador",
                "ID");

            dgvEntrenadores.Columns.Add(
                "Nombre",
                "NOMBRE COMPLETO");

            dgvEntrenadores.Columns.Add(
                "Edad",
                "EDAD");

            dgvEntrenadores.Columns.Add(
                "Telefono",
                "TELÉFONO");

            dgvEntrenadores.Columns.Add(
                "Deporte",
                "DEPORTES");

            dgvEntrenadores.Columns.Add(
                "Estado",
                "ESTADO");

            dgvEntrenadores.Columns.Add(
                "Deportistas",
                "DEPORTISTAS\nACTIVOS");


            // Ocultar ID
            dgvEntrenadores.Columns[
                "IdEntrenador"].Visible = false;


            // ======================================
            // ESTILO GENERAL
            // ======================================
            dgvEntrenadores.BackgroundColor =
                Color.White;

            dgvEntrenadores.BorderStyle =
                BorderStyle.None;

            dgvEntrenadores.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvEntrenadores.GridColor =
                Color.FromArgb(235, 235, 235);


            // ======================================
            // ENCABEZADO
            // ======================================
            dgvEntrenadores.EnableHeadersVisualStyles =
                false;

            dgvEntrenadores.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvEntrenadores
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvEntrenadores
                .ColumnHeadersDefaultCellStyle
                .ForeColor =
                Color.White;

            dgvEntrenadores
                .ColumnHeadersDefaultCellStyle
                .Font =
                new Font(
                    "Century Gothic",
                    11F,
                    FontStyle.Bold);

            dgvEntrenadores
                .ColumnHeadersDefaultCellStyle
                .Alignment =
                DataGridViewContentAlignment
                .MiddleCenter;

            dgvEntrenadores.ColumnHeadersHeight = 50;

            dgvEntrenadores
                .ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;


            // ======================================
            // FILAS
            // ======================================
            dgvEntrenadores.RowHeadersVisible = false;

            dgvEntrenadores.RowTemplate.Height = 50;

            dgvEntrenadores.DefaultCellStyle.BackColor =
                Color.White;

            dgvEntrenadores.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 30, 60);

            dgvEntrenadores.DefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    10F,
                    FontStyle.Regular);

            dgvEntrenadores.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            // ======================================
            // SELECCIÓN
            // ======================================
            dgvEntrenadores
                .DefaultCellStyle
                .SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvEntrenadores
                .DefaultCellStyle
                .SelectionForeColor =
                Color.FromArgb(25, 30, 60);


            // ======================================
            // COLUMNAS OCUPAN TODO
            // ======================================
            dgvEntrenadores.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            // ======================================
            // TAMAÑOS
            // ======================================
            dgvEntrenadores.Columns["Nombre"]
                .FillWeight = 130;

            dgvEntrenadores.Columns["Edad"]
                .FillWeight = 55;

            dgvEntrenadores.Columns["Telefono"]
                .FillWeight = 90;

            dgvEntrenadores.Columns["Deporte"]
                .FillWeight = 130;

            dgvEntrenadores.Columns["Estado"]
                .FillWeight = 75;

            dgvEntrenadores.Columns["Deportistas"]
                .FillWeight = 80;


            // ======================================
            // ALINEACIONES
            // ======================================
            dgvEntrenadores.Columns["Nombre"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvEntrenadores.Columns["Deporte"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;


            // ======================================
            // BLOQUEAR EDICIÓN
            // ======================================
            dgvEntrenadores.AllowUserToAddRows = false;

            dgvEntrenadores.AllowUserToDeleteRows = false;

            dgvEntrenadores.AllowUserToResizeRows = false;

            dgvEntrenadores.AllowUserToResizeColumns =
                false;

            dgvEntrenadores.ReadOnly = true;

            dgvEntrenadores.MultiSelect = false;

            dgvEntrenadores.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvEntrenadores.ClearSelection();
        }
        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            frmInactivarEntrenador frm = new frmInactivarEntrenador();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnRemplazar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVer_Click(object sender, EventArgs e)
        {

        }
    }

}
