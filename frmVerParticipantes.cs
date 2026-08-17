using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmVerParticipantes : Form
    {
        public frmVerParticipantes()
        {
            InitializeComponent();
            ConfigurarTablaParticipantes();
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        private void frmVerParticipantes_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }
        private void ConfigurarTablaParticipantes()
        {
            // ==========================================
            // LIMPIAR TABLA
            // ==========================================
            dgvParticipantes.Columns.Clear();
            dgvParticipantes.Rows.Clear();


            // ==========================================
            // COLUMNAS
            // ==========================================
            dgvParticipantes.Columns.Add(
                "NombreCompleto",
                "NOMBRE COMPLETO");

            dgvParticipantes.Columns.Add(
                "Categoria",
                "CATEGORÍA");


            // ==========================================
            // CONFIGURACIÓN GENERAL
            // ==========================================
            dgvParticipantes.BackgroundColor = Color.White;

            dgvParticipantes.BorderStyle =
                BorderStyle.None;

            dgvParticipantes.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvParticipantes.GridColor =
                Color.FromArgb(235, 235, 245);

            dgvParticipantes.RowHeadersVisible = false;

            dgvParticipantes.AllowUserToAddRows = false;
            dgvParticipantes.AllowUserToDeleteRows = false;
            dgvParticipantes.AllowUserToResizeRows = false;
            dgvParticipantes.AllowUserToResizeColumns = false;

            dgvParticipantes.ReadOnly = true;
            dgvParticipantes.MultiSelect = false;

            dgvParticipantes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvParticipantes.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            // ==========================================
            // ENCABEZADO
            // ==========================================
            dgvParticipantes.EnableHeadersVisualStyles = false;

            dgvParticipantes.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(245, 248, 255);

            dgvParticipantes.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(25, 55, 125);

            dgvParticipantes.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    10F,
                    FontStyle.Bold);

            dgvParticipantes.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvParticipantes.ColumnHeadersHeight = 45;

            dgvParticipantes.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvParticipantes.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;


            // ==========================================
            // FILAS
            // ==========================================
            dgvParticipantes.RowTemplate.Height = 45;

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
                DataGridViewContentAlignment.MiddleLeft;

            dgvParticipantes.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvParticipantes.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 40, 95);


            // ==========================================
            // TAMAÑO DE COLUMNAS
            // ==========================================
            dgvParticipantes.Columns["NombreCompleto"]
                .FillWeight = 65;

            dgvParticipantes.Columns["Categoria"]
                .FillWeight = 35;


            dgvParticipantes.ClearSelection();
        }
    }
}
