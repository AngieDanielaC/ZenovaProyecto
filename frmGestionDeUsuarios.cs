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
    public partial class frmGestionDeUsuarios : Form
    {
        public frmGestionDeUsuarios()
        {
            InitializeComponent();
            ConfigurarTablaUsuarios();
        }
        private void ConfigurarTablaUsuarios()
        {
            // Limpiar columnas y filas anteriores
            dgvUsuarios.Columns.Clear();
            dgvUsuarios.Rows.Clear();


            // ==========================================
            // COLUMNA FOTO
            // ==========================================
            DataGridViewImageColumn colFoto = new DataGridViewImageColumn();

            colFoto.Name = "Foto";
            colFoto.HeaderText = "FOTO";
            colFoto.ImageLayout = DataGridViewImageCellLayout.Zoom;

            dgvUsuarios.Columns.Add(colFoto);


            // ==========================================
            // COLUMNAS
            // ==========================================
            dgvUsuarios.Columns.Add("Nombre", "NOMBRE COMPLETO");
            dgvUsuarios.Columns.Add("Usuario", "USUARIO");
            dgvUsuarios.Columns.Add("Rol", "ROL");
            dgvUsuarios.Columns.Add("Estado", "ESTADO");
            dgvUsuarios.Columns.Add("Correo", "CORREO ELECTRÓNICO");


            // ==========================================
            // CONFIGURACIÓN GENERAL
            // ==========================================
            dgvUsuarios.BackgroundColor = Color.White;

            dgvUsuarios.BorderStyle = BorderStyle.None;

            dgvUsuarios.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvUsuarios.GridColor =
                Color.FromArgb(235, 235, 245);

            // Quitar columna lateral izquierda
            dgvUsuarios.RowHeadersVisible = false;

            // Evitar modificaciones manuales
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.AllowUserToResizeColumns = false;

            dgvUsuarios.ReadOnly = true;

            // Seleccionar fila completa
            dgvUsuarios.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Solo permitir seleccionar un usuario
            dgvUsuarios.MultiSelect = false;

            // Las columnas ocupan todo el espacio disponible
            dgvUsuarios.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Altura de las filas
            dgvUsuarios.RowTemplate.Height = 55;


            // ==========================================
            // ENCABEZADO
            // ==========================================
            dgvUsuarios.EnableHeadersVisualStyles = false;

            // Fondo azul
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 63, 221);

            // Letras blancas
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            // LETRA 12
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    12,
                    FontStyle.Bold
                );

            // Centrar encabezados
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // Altura del encabezado
            dgvUsuarios.ColumnHeadersHeight = 50;

            // Evitar que cambie automáticamente
            dgvUsuarios.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Quitar bordes del encabezado
            dgvUsuarios.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;


            // ==========================================
            // ESTILO DE LAS FILAS
            // ==========================================
            dgvUsuarios.DefaultCellStyle.BackColor =
                Color.White;

            dgvUsuarios.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 40, 95);

            // LETRA DE LOS DATOS
            dgvUsuarios.DefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    10,
                    FontStyle.Regular
                );

            dgvUsuarios.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            // ==========================================
            // COLOR CUANDO SE SELECCIONA
            // ==========================================
            dgvUsuarios.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvUsuarios.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 40, 95);


            // ==========================================
            // ALTURA
            // ==========================================
            dgvUsuarios.RowTemplate.Height = 60;


            // ==========================================
            // TAMAÑO DE COLUMNAS
            // ==========================================
            dgvUsuarios.Columns["Foto"].FillWeight = 50;

            dgvUsuarios.Columns["Nombre"].FillWeight = 145;

            dgvUsuarios.Columns["Usuario"].FillWeight = 85;

            dgvUsuarios.Columns["Rol"].FillWeight = 100;

            dgvUsuarios.Columns["Estado"].FillWeight = 85;

            dgvUsuarios.Columns["Correo"].FillWeight = 135;


            // ==========================================
            // ALINEACIÓN
            // ==========================================
            dgvUsuarios.Columns["Foto"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvUsuarios.Columns["Nombre"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvUsuarios.Columns["Usuario"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvUsuarios.Columns["Rol"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvUsuarios.Columns["Estado"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvUsuarios.Columns["Correo"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmNuevoUsuario frmSubCompetencia = new frmNuevoUsuario();

            frmSubCompetencia.TopLevel = false;
            frmSubCompetencia.FormBorderStyle = FormBorderStyle.None;
            frmSubCompetencia.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmSubCompetencia);

            frmSubCompetencia.Show();

            this.Close();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            frmVerUsuario frm = new frmVerUsuario();
            frm.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmEditarUsuariocs frm = new frmEditarUsuariocs();
            frm.Show();
        }

        private void btnAcDes_Click(object sender, EventArgs e)
        {

        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            frmRestablecerContraseña frm = new frmRestablecerContraseña();
            frm.Show();
        }
    }
}
