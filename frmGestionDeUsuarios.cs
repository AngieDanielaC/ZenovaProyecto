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
    public partial class frmGestionDeUsuarios : Form
    {
        public frmGestionDeUsuarios()
        {
            InitializeComponent();
            ConfigurarTablaUsuarios();
        }
        private void ConfigurarTablaUsuarios()
        {
            // LIMPIAR TABLA
            dgvUsuarios.Columns.Clear();
            dgvUsuarios.Rows.Clear();

            // CREAR COLUMNAS

            DataGridViewImageColumn columnaFoto =
                new DataGridViewImageColumn();

            columnaFoto.Name = "Foto";
            columnaFoto.HeaderText = "FOTO";
            columnaFoto.ImageLayout =
                DataGridViewImageCellLayout.Zoom;

            dgvUsuarios.Columns.Add(columnaFoto);


            dgvUsuarios.Columns.Add(
                "Nombre",
                "NOMBRE COMPLETO");

            dgvUsuarios.Columns.Add(
                "Usuario",
                "USUARIO");

            dgvUsuarios.Columns.Add(
                "Rol",
                "ROL");

            dgvUsuarios.Columns.Add(
                "Estado",
                "ESTADO");

            dgvUsuarios.Columns.Add(
                "Correo",
                "CORREO ELECTRÓNICO");

            // ESTILO GENERAL
            dgvUsuarios.BackgroundColor = Color.White;

            dgvUsuarios.BorderStyle =
                BorderStyle.None;

            dgvUsuarios.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvUsuarios.GridColor =
                Color.FromArgb(235, 235, 245);

            dgvUsuarios.RowHeadersVisible = false;

            dgvUsuarios.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            // ENCABEZADO
            dgvUsuarios.EnableHeadersVisualStyles = false;

            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 63, 221);

            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    11F,
                    FontStyle.Bold);

            dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvUsuarios.ColumnHeadersHeight = 50;

            dgvUsuarios.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvUsuarios.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;


            // FILAS
            dgvUsuarios.RowTemplate.Height = 60;

            dgvUsuarios.DefaultCellStyle.BackColor =
                Color.White;

            dgvUsuarios.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 40, 95);

            dgvUsuarios.DefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    10F,
                    FontStyle.Regular);

            dgvUsuarios.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvUsuarios.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvUsuarios.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 40, 95);


            
            // TAMAÑO DE COLUMNAS
            dgvUsuarios.Columns["Foto"].FillWeight = 45;
            dgvUsuarios.Columns["Nombre"].FillWeight = 140;
            dgvUsuarios.Columns["Usuario"].FillWeight = 90;
            dgvUsuarios.Columns["Rol"].FillWeight = 100;
            dgvUsuarios.Columns["Estado"].FillWeight = 70;
            dgvUsuarios.Columns["Correo"].FillWeight = 140;


            // ALINEACIÓN
            dgvUsuarios.Columns["Nombre"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvUsuarios.Columns["Correo"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;


            // BLOQUEAR EDICIÓN
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.AllowUserToResizeColumns = false;

            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.MultiSelect = false;

            dgvUsuarios.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvUsuarios.ClearSelection();


        }
        private void btnNuevo_Click(object sender, EventArgs e)
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

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
