using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmHistorialMediciones : Form
    {
        private int idDeportista;

        csConectaSQL conSQL = new csConectaSQL();
        public frmHistorialMediciones(int idDeportista)
        {
            InitializeComponent();

            this.idDeportista = idDeportista;

            ConfigurarTablaHistorial();
            CargarNombreDeportista();
            CargarHistorial();

        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }
        private void ConfigurarTablaHistorial()
        {
            // ==========================================
            // LIMPIAR TABLA
            // ==========================================
            dgvHistorial.Columns.Clear();
            dgvHistorial.Rows.Clear();


            // ==========================================
            // CREAR COLUMNAS
            // ==========================================
            dgvHistorial.Columns.Add(
                "Fecha",
                "FECHA");

            dgvHistorial.Columns.Add(
                "Peso",
                "PESO (kg)");

            dgvHistorial.Columns.Add(
                "Altura",
                "ALTURA (m)");
            dgvHistorial.Columns.Add(
                "CategoriaEdad",
                "CATEGORÍA (EDAD)");

            dgvHistorial.Columns.Add(
                "DivisionPeso",
                "DIVISIÓN PESO");


            // ==========================================
            // CONFIGURACIÓN GENERAL
            // ==========================================
            dgvHistorial.BackgroundColor =
                Color.White;

            dgvHistorial.BorderStyle =
                BorderStyle.None;

            dgvHistorial.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvHistorial.GridColor =
                Color.FromArgb(235, 235, 245);

            dgvHistorial.RowHeadersVisible =
                false;

            dgvHistorial.AllowUserToAddRows =
                false;

            dgvHistorial.AllowUserToDeleteRows =
                false;

            dgvHistorial.AllowUserToResizeRows =
                false;

            dgvHistorial.AllowUserToResizeColumns =
                false;

            dgvHistorial.ReadOnly =
                true;

            dgvHistorial.MultiSelect =
                false;

            dgvHistorial.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvHistorial.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            // ==========================================
            // ENCABEZADOS
            // ==========================================
            dgvHistorial.EnableHeadersVisualStyles =
                false;

            // Azul utilizado en las demás tablas
            dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 63, 221);

            dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvHistorial.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    9F,
                    FontStyle.Bold);

            dgvHistorial.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHistorial.ColumnHeadersDefaultCellStyle.WrapMode =
                DataGridViewTriState.True;

            dgvHistorial.ColumnHeadersHeight =
                50;

            dgvHistorial.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvHistorial.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;


            // ==========================================
            // FILAS
            // ==========================================
            dgvHistorial.RowTemplate.Height =
                50;

            dgvHistorial.DefaultCellStyle.BackColor =
                Color.White;

            dgvHistorial.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 40, 95);

            dgvHistorial.DefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    9F,
                    FontStyle.Regular);

            dgvHistorial.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHistorial.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvHistorial.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 40, 95);

            dgvHistorial.DefaultCellStyle.WrapMode =
                DataGridViewTriState.False;


            // ==========================================
            // TAMAÑO DE COLUMNAS
            // ==========================================
            dgvHistorial.Columns["Fecha"]
                .FillWeight = 85;

            dgvHistorial.Columns["Peso"]
                .FillWeight = 70;

            dgvHistorial.Columns["Altura"]
                .FillWeight = 75;

            dgvHistorial.Columns["CategoriaEdad"]
                .FillWeight = 110;

            dgvHistorial.Columns["DivisionPeso"]
                .FillWeight = 100;


            // ==========================================
            // ALINEACIÓN
            // ==========================================
            dgvHistorial.Columns["Fecha"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHistorial.Columns["Peso"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHistorial.Columns["Altura"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHistorial.Columns["CategoriaEdad"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvHistorial.Columns["DivisionPeso"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            // ==========================================
            // QUITAR SELECCIÓN INICIAL
            // ==========================================
            dgvHistorial.ClearSelection();
        }
        private void CargarHistorial()
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                FechaMedicion,
                Peso,
                Altura,
                CategoriaEdad,
                DivisionPeso
              FROM MedicionesDeportista
              WHERE IdDeportista = " + idDeportista + @"
              ORDER BY FechaMedicion DESC, IdMedicion DESC"
                );

            dgvHistorial.Rows.Clear();

            if (tabla == null)
                return;

            foreach (DataRow fila in tabla.Rows)
            {
                string fecha =
                    Convert.ToDateTime(
                        fila["FechaMedicion"])
                    .ToString("dd/MM/yyyy");

                string peso =
                    Convert.ToDecimal(
                        fila["Peso"])
                    .ToString("0.00");

                string altura =
                    Convert.ToDecimal(
                        fila["Altura"])
                    .ToString("0.00");

                string categoriaEdad =
                    fila["CategoriaEdad"].ToString();

                string divisionPeso =
                    fila["DivisionPeso"] == DBNull.Value
                    ? "No aplica"
                    : fila["DivisionPeso"].ToString();

                dgvHistorial.Rows.Add(
                    fecha,
                    peso,
                    altura,
                    categoriaEdad,
                    divisionPeso
                );
            }

            dgvHistorial.ClearSelection();
        }
        private void CargarNombreDeportista()
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                Nombres,
                Apellidos
              FROM Deportistas
              WHERE IdDeportista = " + idDeportista
                );

            if (tabla == null ||
                tabla.Rows.Count == 0)
            {
                return;
            }

            DataRow fila =
                tabla.Rows[0];

            lblNombreDeportista.Text =
                fila["Nombres"].ToString() +
                " " +
                fila["Apellidos"].ToString();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
