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
    public partial class frmVisualizarDatosBienestar : Form
    {
        csConectaSQL oCon = new csConectaSQL();
        public frmVisualizarDatosBienestar()
        {
            InitializeComponent();
            ConfigurarTablaVisualizar();
        }
        private void ConfigurarTablaVisualizar()
        {
            // Limpiar columnas y filas
            dgvVisualizar.Columns.Clear();
            dgvVisualizar.Rows.Clear();

            // Crear columnas
            dgvVisualizar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Deportista", HeaderText = "DEPORTISTA", DataPropertyName = "DEPORTISTA" });
            dgvVisualizar.Columns.Add(new DataGridViewTextBoxColumn { Name = "GastoCalorico", HeaderText = "GASTO\nCALÓRICO", DataPropertyName = "GASTO CALÓRICO" });
            dgvVisualizar.Columns.Add(new DataGridViewTextBoxColumn { Name = "RiesgoLesion", HeaderText = "RIESGO DE\nLESIÓN", DataPropertyName = "RIESGO DE LESIÓN" });
            dgvVisualizar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Recuperacion", HeaderText = "RECUPERACIÓN\nESTIMADA", DataPropertyName = "RECUPERACIÓN ESTIMADA" });
            dgvVisualizar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Peso", HeaderText = "PESO (KG)", DataPropertyName = "PESO (KG)" });

            // Apariencia general
            dgvVisualizar.BackgroundColor = Color.White;
            dgvVisualizar.BorderStyle = BorderStyle.None;
            dgvVisualizar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvVisualizar.GridColor = Color.FromArgb(235, 235, 235);

            // Encabezado
            dgvVisualizar.EnableHeadersVisualStyles = false;
            dgvVisualizar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvVisualizar.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvVisualizar.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvVisualizar.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvVisualizar.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvVisualizar.ColumnHeadersHeight = 55;
            dgvVisualizar.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Filas
            dgvVisualizar.RowHeadersVisible = false;
            dgvVisualizar.RowTemplate.Height = 45;

            dgvVisualizar.DefaultCellStyle.BackColor = Color.White;
            dgvVisualizar.DefaultCellStyle.ForeColor = Color.FromArgb(35, 35, 35);
            dgvVisualizar.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvVisualizar.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvVisualizar.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvVisualizar.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Ajustar columnas
            dgvVisualizar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvVisualizar.Columns["Deportista"].FillWeight = 24;
            dgvVisualizar.Columns["GastoCalorico"].FillWeight = 18;
            dgvVisualizar.Columns["RiesgoLesion"].FillWeight = 18;
            dgvVisualizar.Columns["Recuperacion"].FillWeight = 22;
            dgvVisualizar.Columns["Peso"].FillWeight = 18;

            // Configuración
            dgvVisualizar.AllowUserToAddRows = false;
            dgvVisualizar.AllowUserToDeleteRows = false;
            dgvVisualizar.AllowUserToResizeRows = false;
            dgvVisualizar.AllowUserToResizeColumns = false;

            dgvVisualizar.ReadOnly = true;
            dgvVisualizar.MultiSelect = false;
            dgvVisualizar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
        private void frmVisualizarDatosBienestar_Load(object sender, EventArgs e)
        {
            CargarDatosConsolidados();
        }
        private void CargarDatosConsolidados()
        {
            string query = @"
        SELECT 
            (D.Nombres + ' ' + D.Apellidos) AS DEPORTISTA,
            ISNULL(CAST(G.GastoCal AS VARCHAR) + ' kcal', 'Sin registro') AS [GASTO CALÓRICO],
            ISNULL(R.Riesgo, 'Sin evaluar') AS [RIESGO DE LESIÓN],
            CASE 
                WHEN R.Riesgo = 'Alto' THEN '48 hrs'
                WHEN R.Riesgo = 'Medio' THEN '24 hrs'
                WHEN R.Riesgo = 'Bajo' THEN '12 hrs'
                ELSE 'No determinado'
            END AS [RECUPERACIÓN ESTIMADA],
            ISNULL(CAST(M.Peso AS VARCHAR) + ' kg', '70.0 kg') AS [PESO (KG)]
        FROM Deportistas D
        LEFT JOIN (
            SELECT idDeportista, GastoCal,
                   ROW_NUMBER() OVER (PARTITION BY idDeportista ORDER BY idDeportista DESC) as rn
            FROM GastoCalorico
        ) G ON D.IdDeportista = G.idDeportista AND G.rn = 1
        LEFT JOIN (
            SELECT idDeportista, Riesgo,
                   ROW_NUMBER() OVER (PARTITION BY idDeportista ORDER BY idDeportista DESC) as rn
            FROM RiesgoFatiga
        ) R ON D.IdDeportista = R.idDeportista AND R.rn = 1
        LEFT JOIN (
            SELECT idDeportista, Peso,
                   ROW_NUMBER() OVER (PARTITION BY idDeportista ORDER BY FechaMedicion DESC) as rn
            FROM MedicionesDeportista
        ) M ON D.IdDeportista = M.idDeportista AND M.rn = 1
        WHERE D.Estado = 1";

            DataTable dt = oCon.RetornaRegistros(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                dgvVisualizar.DataSource = dt;
            }

            dgvVisualizar.ClearSelection();
        }
    }
}
