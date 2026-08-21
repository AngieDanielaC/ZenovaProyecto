using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmGestionarParticipantes : Form
    {
        private int idCompetencia;
        private int idCompetenciaDeporte = 0;
        csConectaSQL conSQL = new csConectaSQL();

        public frmGestionarParticipantes(int idCompetencia)
        {
            InitializeComponent();
            this.idCompetencia = idCompetencia;
            ConfigurarTablaParticipantes();
            ConfigurarControles();
            CargarDatosCompetencia();
            CargarDeportesCompetencia();
        }

        private void CargarDatosCompetencia()
        {
            DataTable tabla = conSQL.RetornaRegistros(
                @"SELECT NombreCompetencia, Organizador, Lugar, Nivel, FechaInicio, FechaFin, FechaLimiteInscripcion
                  FROM Competencias
                  WHERE IdCompetencia = " + idCompetencia
            );

            if (tabla == null || tabla.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró la competencia.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRow fila = tabla.Rows[0];

            lblNombreCompetencia.Text = fila["NombreCompetencia"].ToString();
            lblOrganizador.Text = fila["Organizador"].ToString();
            lblLugar.Text = fila["Lugar"].ToString();
            lblNivel.Text = fila["Nivel"].ToString();
            lblFechaInicio.Text = Convert.ToDateTime(fila["FechaInicio"]).ToString("dd/MM/yyyy");
            lblFechaFin.Text = Convert.ToDateTime(fila["FechaFin"]).ToString("dd/MM/yyyy");

            if (fila["FechaLimiteInscripcion"] != DBNull.Value)
                lblFechaLimite.Text = Convert.ToDateTime(fila["FechaLimiteInscripcion"]).ToString("dd/MM/yyyy");
            else
                lblFechaLimite.Text = "Sin límite";
        }

        private void CargarDeportesCompetencia()
        {
            DataTable tabla = conSQL.RetornaRegistros(
                @"SELECT CD.IdCompetenciaDeporte, D.IdDeporte, D.NombreDeporte
                  FROM CompetenciaDeporte CD
                  INNER JOIN Deportes D ON CD.IdDeporte = D.IdDeporte
                  WHERE CD.IdCompetencia = " + idCompetencia +
                @" ORDER BY D.NombreDeporte"
            );

            if (tabla == null)
                return;

            cmbDeporte.DataSource = tabla;
            cmbDeporte.DisplayMember = "NombreDeporte";
            cmbDeporte.ValueMember = "IdCompetenciaDeporte";
            cmbDeporte.SelectedIndex = -1;
        }

        private void ConfigurarControles()
        {
            cmbDeporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBuscarDeportista.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBuscarDeportista.Enabled = false;
            lblDisponibles.Text = "Deportistas disponibles: 0";
            lblSeleccionados.Text = "Seleccionados: 0";
        }

        private void ConfigurarTablaParticipantes()
        {
            dgvParticipantes.Columns.Clear();
            dgvParticipantes.Rows.Clear();

            DataGridViewCheckBoxColumn colSeleccionar = new DataGridViewCheckBoxColumn();

            colSeleccionar.Name = "Seleccionar";
            colSeleccionar.HeaderText = "";
            colSeleccionar.FillWeight = 30;
            colSeleccionar.TrueValue = true;
            colSeleccionar.FalseValue = false;

            dgvParticipantes.Columns.Add(colSeleccionar);

            dgvParticipantes.Columns.Add("NombreCompleto", "NOMBRE COMPLETO");
            dgvParticipantes.Columns.Add("Cedula", "CÉDULA");
            dgvParticipantes.Columns.Add("Edad", "EDAD");
            dgvParticipantes.Columns.Add("Genero", "GÉNERO");
            dgvParticipantes.Columns.Add("Entrenador", "ENTRENADOR RESPONSABLE");

            dgvParticipantes.BackgroundColor = Color.White;
            dgvParticipantes.BorderStyle = BorderStyle.None;
            dgvParticipantes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvParticipantes.GridColor = Color.FromArgb(235, 235, 245);
            dgvParticipantes.RowHeadersVisible = false;
            dgvParticipantes.AllowUserToAddRows = false;
            dgvParticipantes.AllowUserToDeleteRows = false;
            dgvParticipantes.AllowUserToResizeRows = false;
            dgvParticipantes.AllowUserToResizeColumns = false;
            dgvParticipantes.MultiSelect = false;
            dgvParticipantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParticipantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvParticipantes.ReadOnly = false;

            foreach (DataGridViewColumn columna in dgvParticipantes.Columns)
                columna.ReadOnly = true;

            dgvParticipantes.Columns["Seleccionar"].ReadOnly = false;

            dgvParticipantes.EnableHeadersVisualStyles = false;
            dgvParticipantes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 63, 221);
            dgvParticipantes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvParticipantes.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            dgvParticipantes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvParticipantes.ColumnHeadersHeight = 50;
            dgvParticipantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvParticipantes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvParticipantes.RowTemplate.Height = 55;
            dgvParticipantes.DefaultCellStyle.BackColor = Color.White;
            dgvParticipantes.DefaultCellStyle.ForeColor = Color.FromArgb(25, 40, 95);
            dgvParticipantes.DefaultCellStyle.Font = new Font("Century Gothic", 10F, FontStyle.Regular);
            dgvParticipantes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvParticipantes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 238, 255);
            dgvParticipantes.DefaultCellStyle.SelectionForeColor = Color.FromArgb(25, 40, 95);

            dgvParticipantes.Columns["Seleccionar"].FillWeight = 30;
            dgvParticipantes.Columns["NombreCompleto"].FillWeight = 150;
            dgvParticipantes.Columns["Cedula"].FillWeight = 90;
            dgvParticipantes.Columns["Edad"].FillWeight = 55;
            dgvParticipantes.Columns["Genero"].FillWeight = 80;
            dgvParticipantes.Columns["Entrenador"].FillWeight = 140;

            dgvParticipantes.Columns["NombreCompleto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvParticipantes.Columns["Entrenador"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvParticipantes.Columns["Seleccionar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvParticipantes.ClearSelection();
        }

        private void cmbDeporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeporte.SelectedIndex == -1 || cmbDeporte.SelectedValue == null || cmbDeporte.SelectedValue is DataRowView)
                return;

            idCompetenciaDeporte = Convert.ToInt32(cmbDeporte.SelectedValue);

            CargarParticipantes();
            CargarBuscadorDeportistas();
        }

        private void CargarParticipantes()
        {
            if (idCompetenciaDeporte <= 0)
                return;

            DataTable datosCompetenciaDeporte = conSQL.RetornaRegistros(
                @"SELECT IdDeporte
                  FROM CompetenciaDeporte
                  WHERE IdCompetenciaDeporte = " + idCompetenciaDeporte
            );

            if (datosCompetenciaDeporte == null || datosCompetenciaDeporte.Rows.Count == 0)
                return;

            int idDeporte = Convert.ToInt32(datosCompetenciaDeporte.Rows[0]["IdDeporte"]);

            DataTable tabla = conSQL.RetornaRegistros(
                @"SELECT DISTINCT
                    D.IdDeportista,
                    D.Nombres + ' ' + D.Apellidos AS NombreCompleto,
                    D.Cedula,
                    D.FechaNacimiento,
                    D.Genero,
                    E.Nombres + ' ' + E.Apellidos AS Entrenador,
                    CASE
                        WHEN PC.IdParticipanteCompetencia IS NOT NULL
                        AND PC.EstadoParticipacion = 'Inscrito' THEN 1
                        ELSE 0
                    END AS Seleccionado
                  FROM Deportistas D
                  INNER JOIN Inscripciones I ON D.IdDeportista = I.IdDeportista
                  INNER JOIN EntrenadorDeporte ED ON I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte
                  INNER JOIN Entrenadores E ON ED.IdEntrenador = E.IdEntrenador
                  LEFT JOIN ParticipantesCompetencia PC ON PC.IdDeportista = D.IdDeportista
                    AND PC.IdCompetenciaDeporte = " + idCompetenciaDeporte + @"
                  WHERE D.Estado = 1
                    AND I.Estado = 'Activo'
                    AND ED.IdDeporte = " + idDeporte + @"
                  ORDER BY NombreCompleto"
            );

            dgvParticipantes.Rows.Clear();

            if (tabla == null)
            {
                ActualizarContadores();
                return;
            }

            foreach (DataRow fila in tabla.Rows)
            {
                DateTime fechaNacimiento = Convert.ToDateTime(fila["FechaNacimiento"]);
                int edad = DateTime.Today.Year - fechaNacimiento.Year;

                if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad))
                    edad--;

                bool seleccionado = Convert.ToInt32(fila["Seleccionado"]) == 1;

                int indice = dgvParticipantes.Rows.Add(
                    seleccionado,
                    fila["NombreCompleto"].ToString(),
                    fila["Cedula"].ToString(),
                    edad,
                    fila["Genero"].ToString(),
                    fila["Entrenador"].ToString()
                );

                dgvParticipantes.Rows[indice].Tag = Convert.ToInt32(fila["IdDeportista"]);
            }

            dgvParticipantes.ClearSelection();
            ActualizarContadores();
        }

        private void CargarBuscadorDeportistas()
        {
            DataTable tabla = new DataTable();

            tabla.Columns.Add("IdDeportista", typeof(int));
            tabla.Columns.Add("NombreCompleto", typeof(string));

            DataRow todos = tabla.NewRow();

            todos["IdDeportista"] = 0;
            todos["NombreCompleto"] = "Todos";

            tabla.Rows.Add(todos);

            foreach (DataGridViewRow fila in dgvParticipantes.Rows)
            {
                if (fila.Tag == null)
                    continue;

                DataRow nueva = tabla.NewRow();

                nueva["IdDeportista"] = Convert.ToInt32(fila.Tag);
                nueva["NombreCompleto"] = fila.Cells["NombreCompleto"].Value.ToString();

                tabla.Rows.Add(nueva);
            }

            cmbBuscarDeportista.DataSource = tabla;
            cmbBuscarDeportista.DisplayMember = "NombreCompleto";
            cmbBuscarDeportista.ValueMember = "IdDeportista";
            cmbBuscarDeportista.SelectedIndex = 0;
            cmbBuscarDeportista.Enabled = tabla.Rows.Count > 1;
        }

        private void cmbBuscarDeportista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuscarDeportista.SelectedValue == null || cmbBuscarDeportista.SelectedValue is DataRowView)
                return;

            int idDeportista = Convert.ToInt32(cmbBuscarDeportista.SelectedValue);

            foreach (DataGridViewRow fila in dgvParticipantes.Rows)
            {
                if (fila.Tag == null)
                    continue;

                int idFila = Convert.ToInt32(fila.Tag);
                fila.Visible = idDeportista == 0 || idFila == idDeportista;
            }

            dgvParticipantes.ClearSelection();
        }

        private void dgvParticipantes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvParticipantes.IsCurrentCellDirty)
                dgvParticipantes.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvParticipantes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvParticipantes.Columns[e.ColumnIndex].Name == "Seleccionar")
                ActualizarContadores();
        }

        private void ActualizarContadores()
        {
            int disponibles = dgvParticipantes.Rows.Count;
            int seleccionados = 0;

            foreach (DataGridViewRow fila in dgvParticipantes.Rows)
            {
                bool marcado = Convert.ToBoolean(fila.Cells["Seleccionar"].Value ?? false);

                if (marcado)
                    seleccionados++;
            }

            lblDisponibles.Text = "Deportistas disponibles: " + disponibles;
            lblSeleccionados.Text = "Seleccionados: " + seleccionados;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbDeporte.SelectedIndex == -1 || idCompetenciaDeporte <= 0)
            {
                MessageBox.Show(
                    "Seleccione un deporte.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                foreach (DataGridViewRow fila in dgvParticipantes.Rows)
                {
                    if (fila.Tag == null)
                        continue;

                    int idDeportista = Convert.ToInt32(fila.Tag);
                    bool seleccionado = Convert.ToBoolean(fila.Cells["Seleccionar"].Value ?? false);

                    DataTable tablaExiste = conSQL.RetornaRegistros(
                        @"SELECT IdParticipanteCompetencia, EstadoParticipacion
                          FROM ParticipantesCompetencia
                          WHERE IdCompetenciaDeporte = " + idCompetenciaDeporte +
                          @" AND IdDeportista = " + idDeportista
                    );

                    bool existe = tablaExiste != null && tablaExiste.Rows.Count > 0;

                    if (seleccionado)
                    {
                        if (!existe)
                        {
                            string campos = "IdCompetenciaDeporte, " +
                                            "IdDeportista, " +
                                            "EstadoParticipacion";

                            string datos = idCompetenciaDeporte + "," +
                                           idDeportista + ",'Inscrito'";

                            if (!conSQL.insertDatos("ParticipantesCompetencia", campos, datos))
                            {
                                MessageBox.Show(
                                    "No se pudo registrar uno de los participantes.",
                                    "ZENOVA",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                                return;
                            }
                        }
                        else
                        {
                            string estadoActual = tablaExiste.Rows[0]["EstadoParticipacion"].ToString();

                            if (estadoActual == "Retirado")
                            {
                                int idParticipante = Convert.ToInt32(tablaExiste.Rows[0]["IdParticipanteCompetencia"]);

                                string consulta =
                                    @"UPDATE ParticipantesCompetencia
                                      SET EstadoParticipacion = 'Inscrito',
                                          FechaInscripcion = GETDATE()
                                      WHERE IdParticipanteCompetencia = " + idParticipante + @";
                                      SELECT 1 AS Resultado;";

                                conSQL.RetornaRegistros(consulta);
                            }
                        }
                    }
                    else
                    {
                        if (existe)
                        {
                            string estadoActual = tablaExiste.Rows[0]["EstadoParticipacion"].ToString();

                            if (estadoActual == "Inscrito")
                            {
                                int idParticipante = Convert.ToInt32(tablaExiste.Rows[0]["IdParticipanteCompetencia"]);

                                string consulta =
                                    @"UPDATE ParticipantesCompetencia
                                      SET EstadoParticipacion = 'Retirado'
                                      WHERE IdParticipanteCompetencia = " + idParticipante + @";
                                      SELECT 1 AS Resultado;";

                                conSQL.RetornaRegistros(consulta);
                            }
                        }
                    }
                }

                MessageBox.Show(
                    "Participantes actualizados correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarParticipantes();
                CargarBuscadorDeportistas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al guardar los participantes:\n\n" + ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void frmGestionarParticipantes_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
                return;

            frmCompetencias frm = new frmCompetencias();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frm);

            frm.Show();
            this.Close();
        }
    }
}
