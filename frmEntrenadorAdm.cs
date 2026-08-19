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
        csConectaSQL oCon = new csConectaSQL(); 
        public frmEntrenadorAdm()
        {
            InitializeComponent();
            ConfigurarTablaEntrenadores();
            txtBuscarComp.TextChanged += txtBuscarComp_TextChanged;
            txtBuscarComp.Enter += txtBuscarComp_Enter;
            txtBuscarComp.Leave += txtBuscarComp_Leave;
            txtBuscarComp.KeyDown += txtBuscarComp_KeyDown;
        }
        private void ConfigurarTablaEntrenadores()
        {
            dgvEntrenadores.Columns.Clear();
            dgvEntrenadores.Rows.Clear();


            // ======================================
            // COLUMNAS
            // ======================================
            // ID OCULTO

            dgvEntrenadores.Columns.Add("IdEntrenador", "ID");
            dgvEntrenadores.Columns["IdEntrenador"].DataPropertyName = "IdEntrenador";

            dgvEntrenadores.Columns.Add("Nombre", "NOMBRE COMPLETO");
            dgvEntrenadores.Columns["Nombre"].DataPropertyName = "NOMBRE COMPLETO";

            dgvEntrenadores.Columns.Add("Edad", "EDAD");
            dgvEntrenadores.Columns["Edad"].DataPropertyName = "EDAD";

            dgvEntrenadores.Columns.Add("Telefono", "TELÉFONO");
            dgvEntrenadores.Columns["Telefono"].DataPropertyName = "TELÉFONO";

            dgvEntrenadores.Columns.Add("Deporte", "DEPORTES");
            dgvEntrenadores.Columns["Deporte"].DataPropertyName = "DEPORTES";

            dgvEntrenadores.Columns.Add("Estado", "ESTADO");
            dgvEntrenadores.Columns["Estado"].DataPropertyName = "ESTADO";

            dgvEntrenadores.Columns.Add("Deportistas", "DEPORTISTAS\nACTIVOS");
            dgvEntrenadores.Columns["Deportistas"].DataPropertyName = "DEPORTISTAS ACTIVOS";


            // Ocultar ID
            dgvEntrenadores.Columns["IdEntrenador"].Visible = false;


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
            if (dgvEntrenadores.SelectedRows.Count > 0)
            {
                int idSeleccionado = Convert.ToInt32(dgvEntrenadores.SelectedRows[0].Cells["IdEntrenador"].Value);
                Control Contenedor = this.Parent;
                frmRemplazarEntrenador changedtrainer = new frmRemplazarEntrenador(idSeleccionado);

                changedtrainer.TopLevel = false;
                changedtrainer.FormBorderStyle = FormBorderStyle.None;
                changedtrainer.Dock = DockStyle.Fill;

                Contenedor.Controls.Remove(this);
                Contenedor.Controls.Add(changedtrainer);

                changedtrainer.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un entrenador de la tabla para reemplazar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dgvEntrenadores.SelectedRows.Count > 0)
            {
                // Obtiene el ID oculto de la fila seleccionada
                int idSeleccionado = Convert.ToInt32(dgvEntrenadores.SelectedRows[0].Cells["IdEntrenador"].Value);

                // Instancia el formulario pasándole el ID
                frmVerEntrenador frm = new frmVerEntrenador(idSeleccionado);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un entrenador de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRegistrarEntrenador_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;
            frmRegistroEntrenadoresAdm frmSubCompetencia = new frmRegistroEntrenadoresAdm();

            frmSubCompetencia.TopLevel = false;
            frmSubCompetencia.FormBorderStyle = FormBorderStyle.None;
            frmSubCompetencia.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmSubCompetencia);

            frmSubCompetencia.Show();

            this.Close();

        }
        private void CargarTablaEntrenadores(string filtro = "")
        {
            dgvEntrenadores.AutoGenerateColumns = false;

            filtro = filtro.Replace("'", "''").Trim();

            if (filtro == "Buscar entrenador") filtro = "";

            string query = @"
        SELECT 
            E.IdEntrenador,
            (E.Nombres + ' ' + E.Apellidos) AS [NOMBRE COMPLETO],
            DATEDIFF(YEAR, E.FechaNacimiento, GETDATE()) - 
                CASE 
                    WHEN DATEADD(YEAR, DATEDIFF(YEAR, E.FechaNacimiento, GETDATE()), E.FechaNacimiento) > GETDATE() 
                    THEN 1 ELSE 0 
                END AS EDAD,
            E.Telefono AS TELÉFONO,
            ISNULL(STRING_AGG(D.NombreDeporte, ', ') WITHIN GROUP (ORDER BY D.NombreDeporte), 'Sin Deporte') AS DEPORTES,
            ISNULL(E.EstadoEntrenador, 'Inactivo') AS ESTADO,
            COUNT(DISTINCT I.IdInscripcion) AS [DEPORTISTAS ACTIVOS]
        FROM Entrenadores E
        LEFT JOIN EntrenadorDeporte ED ON E.IdEntrenador = ED.IdEntrenador AND ED.Activo = 1
        LEFT JOIN Deportes D ON ED.IdDeporte = D.IdDeporte
        LEFT JOIN Inscripciones I ON ED.IdEntrenadorDeporte = I.IdEntrenadorDeporte
        WHERE ((E.Nombres + ' ' + E.Apellidos) LIKE '%" + filtro + @"%' 
            OR D.NombreDeporte LIKE '%" + filtro + @"%'
            OR E.Telefono LIKE '%" + filtro + @"%')
        GROUP BY 
            E.IdEntrenador, E.Nombres, E.Apellidos, E.FechaNacimiento, 
            E.Telefono, E.EstadoEntrenador";

            dgvEntrenadores.DataSource = oCon.RetornaRegistros(query);
            dgvEntrenadores.ClearSelection();
        }
        private void frmEntrenadorAdm_Load(object sender, EventArgs e)
        {
            txtBuscarComp.Text = "Buscar entrenador";
            txtBuscarComp.ForeColor = Color.Gray;
            CargarTablaEntrenadores();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEntrenadores.SelectedRows.Count > 0)
            {
                int idSeleccionado = Convert.ToInt32(dgvEntrenadores.SelectedRows[0].Cells["IdEntrenador"].Value);

                frmEditarEntrenador frmEdit = new frmEditarEntrenador(idSeleccionado);
                frmEdit.StartPosition = FormStartPosition.CenterScreen;
                frmEdit.FormBorderStyle = FormBorderStyle.None;

                frmEdit.ShowDialog();
                CargarTablaEntrenadores();
            }
            else
            {
                MessageBox.Show("Seleccione un entrenador para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBuscarComp_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarComp.Text == "Buscar entrenador")
            {
                txtBuscarComp.Text = "";
                txtBuscarComp.ForeColor = Color.Black;
            }
        }

        private void txtBuscarComp_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarComp.Text))
            {
                txtBuscarComp.Text = "Buscar entrenador";
                txtBuscarComp.ForeColor = Color.Gray;
            }
        }

        private void txtBuscarComp_Enter(object sender, EventArgs e)
        {
            if (txtBuscarComp.Text == "Buscar entrenador")
            {
                txtBuscarComp.Text = "";
                txtBuscarComp.ForeColor = Color.Black;
            }
        }

        private void txtBuscarComp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el 'beep' de Windows al presionar Enter
                string texto = txtBuscarComp.Text == "Buscar entrenador" ? "" : txtBuscarComp.Text;
                CargarTablaEntrenadores(texto);
            }
        }
    }
}


