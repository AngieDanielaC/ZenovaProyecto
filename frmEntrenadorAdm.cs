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
    public partial class frmEntrenadorAdm : Form
    {
        public frmEntrenadorAdm()
        {
            InitializeComponent();
            ConfigurarTablaEntrenadores();
        }
        private void ConfigurarTablaEntrenadores()
        {
            // Limpiar columnas anteriores
            dgvEntrenadores.Columns.Clear();
            dgvEntrenadores.Rows.Clear();


            // Crear columnas
            dgvEntrenadores.Columns.Add("ID", "ID");
            dgvEntrenadores.Columns.Add("Nombre", "NOMBRE COMPLETO");
            dgvEntrenadores.Columns.Add("Edad", "EDAD");
            dgvEntrenadores.Columns.Add("Telefono", "TELÉFONO");
            dgvEntrenadores.Columns.Add("Deporte", "DEPORTE");
            dgvEntrenadores.Columns.Add("Estado", "ESTADO");
            dgvEntrenadores.Columns.Add("Deportistas", "DEPORTISTAS\nACTIVOS");
            dgvEntrenadores.Columns.Add("Accion", "ACCIONES");



            // Estilo general
            dgvEntrenadores.BackgroundColor = Color.White;
            dgvEntrenadores.BorderStyle = BorderStyle.None;

            dgvEntrenadores.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvEntrenadores.GridColor =
                Color.FromArgb(235, 235, 235);



            // Encabezado
            dgvEntrenadores.EnableHeadersVisualStyles = false;

            dgvEntrenadores.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvEntrenadores.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvEntrenadores.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvEntrenadores.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvEntrenadores.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvEntrenadores.ColumnHeadersHeight = 50;

            dgvEntrenadores.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;



            // Filas
            dgvEntrenadores.RowHeadersVisible = false;

            dgvEntrenadores.RowTemplate.Height = 45;


            dgvEntrenadores.DefaultCellStyle.BackColor =
                Color.White;

            dgvEntrenadores.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 30, 60);

            dgvEntrenadores.DefaultCellStyle.Font =
                new Font("Segoe UI", 10F);

            dgvEntrenadores.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            dgvEntrenadores.DefaultCellStyle.SelectionBackColor =
                Color.White;

            dgvEntrenadores.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 30, 60);



            // Ajustar columnas
            dgvEntrenadores.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            dgvEntrenadores.Columns["ID"].FillWeight = 8;

            dgvEntrenadores.Columns["Nombre"].FillWeight = 25;

            dgvEntrenadores.Columns["Edad"].FillWeight = 10;

            dgvEntrenadores.Columns["Telefono"].FillWeight = 18;

            dgvEntrenadores.Columns["Deporte"].FillWeight = 22;

            dgvEntrenadores.Columns["Estado"].FillWeight = 15;

            dgvEntrenadores.Columns["Deportistas"].FillWeight = 18;

            dgvEntrenadores.Columns["Accion"].FillWeight = 12;



            // Bloquear edición
            dgvEntrenadores.AllowUserToAddRows = false;

            dgvEntrenadores.AllowUserToDeleteRows = false;

            dgvEntrenadores.AllowUserToResizeRows = false;

            dgvEntrenadores.AllowUserToResizeColumns = false;


            dgvEntrenadores.ReadOnly = true;

            dgvEntrenadores.MultiSelect = false;


            dgvEntrenadores.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvEntrenadores.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmRegistroEntrenadoresAdm frmVerCompetencias = new frmRegistroEntrenadoresAdm();

            frmVerCompetencias.TopLevel = false;
            frmVerCompetencias.FormBorderStyle = FormBorderStyle.None;
            frmVerCompetencias.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmVerCompetencias);

            frmVerCompetencias.Show();

            this.Close();
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            frmInactivarEntrenador frm = new frmInactivarEntrenador();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmRestablecerContraseña frm = new frmRestablecerContraseña();
            frm.Show();
        }
    }
}
