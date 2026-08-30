using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmGastoCalorico : Form
    {
        csConectaSQL oCon = new csConectaSQL();

        public frmGastoCalorico()
        {
            InitializeComponent();
            ConfigurarTablaEnergia();
        }

        private void ConfigurarTablaEnergia()
        {
            dgvEnergia.Columns.Clear();
            dgvEnergia.Rows.Clear();

            dgvEnergia.Columns.Add(new DataGridViewTextBoxColumn { Name = "Deportista", HeaderText = "DEPORTISTA", DataPropertyName = "DEPORTISTA" });
            dgvEnergia.Columns.Add(new DataGridViewTextBoxColumn { Name = "Peso", HeaderText = "PESO", DataPropertyName = "PESO" });
            dgvEnergia.Columns.Add(new DataGridViewTextBoxColumn { Name = "Energia", HeaderText = "ENERGÍA", DataPropertyName = "ENERGÍA" });
            dgvEnergia.Columns.Add(new DataGridViewTextBoxColumn { Name = "Intensidad", HeaderText = "INTENSIDAD", DataPropertyName = "INTENSIDAD" });
            dgvEnergia.Columns.Add(new DataGridViewTextBoxColumn { Name = "Duracion", HeaderText = "DURACIÓN DEL\nENTRENAMIENTO", DataPropertyName = "DURACIÓN DEL ENTRENAMIENTO" });
            dgvEnergia.Columns.Add(new DataGridViewTextBoxColumn { Name = "GastoCalorico", HeaderText = "GASTO\nCALÓRICO", DataPropertyName = "GASTO CALÓRICO" });
            dgvEnergia.Columns.Add(new DataGridViewTextBoxColumn { Name = "Deficit", HeaderText = "DÉFICIT\nENERGÉTICO", DataPropertyName = "DÉFICIT ENERGÉTICO" });

            dgvEnergia.BackgroundColor = Color.White;
            dgvEnergia.BorderStyle = BorderStyle.None;
            dgvEnergia.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvEnergia.GridColor = Color.FromArgb(235, 235, 235);

            dgvEnergia.EnableHeadersVisualStyles = false;
            dgvEnergia.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvEnergia.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#333FDD");
            dgvEnergia.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEnergia.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvEnergia.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEnergia.ColumnHeadersHeight = 55;
            dgvEnergia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvEnergia.RowHeadersVisible = false;
            dgvEnergia.RowTemplate.Height = 45;
            dgvEnergia.DefaultCellStyle.BackColor = Color.White;
            dgvEnergia.DefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
            dgvEnergia.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvEnergia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEnergia.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvEnergia.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvEnergia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvEnergia.Columns["Deportista"].FillWeight = 22;
            dgvEnergia.Columns["Peso"].FillWeight = 12;
            dgvEnergia.Columns["Energia"].FillWeight = 16;
            dgvEnergia.Columns["Intensidad"].FillWeight = 16;
            dgvEnergia.Columns["Duracion"].FillWeight = 20;
            dgvEnergia.Columns["GastoCalorico"].FillWeight = 16;
            dgvEnergia.Columns["Deficit"].FillWeight = 16;

            dgvEnergia.AllowUserToAddRows = false;
            dgvEnergia.AllowUserToDeleteRows = false;
            dgvEnergia.AllowUserToResizeRows = false;
            dgvEnergia.AllowUserToResizeColumns = false;
            dgvEnergia.ReadOnly = true;
            dgvEnergia.MultiSelect = false;
            dgvEnergia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvEnergia.ClearSelection();
        }

        private void frmGastoCalorico_Load(object sender, EventArgs e)
        {
            CargarDeportistas();
            CargarTablaEnergia();
        }

        private void CargarDeportistas()
        {
            string query;

            if (frmInicioDeSesion.NombreRolActual == "Entrenador" &&
                frmInicioDeSesion.IdEntrenadorActual.HasValue)
            {
                int idEntrenador = frmInicioDeSesion.IdEntrenadorActual.Value;

                query = "select distinct D.IdDeportista, " +
                        "D.Nombres + ' ' + D.Apellidos as NombreCompleto " +
                        "from Deportistas D " +
                        "inner join Inscripciones I on D.IdDeportista = I.IdDeportista " +
                        "inner join EntrenadorDeporte ED on I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte " +
                        "where D.Estado = 1 " +
                        "and ED.IdEntrenador = " + idEntrenador + " " +
                        "and ED.Activo = 1 " +
                        "and I.Estado <> 'Finalizado'";
            }
            else
            {
                query = "select IdDeportista, Nombres + ' ' + Apellidos as NombreCompleto " +
                        "from Deportistas where Estado = 1";
            }

            DataTable dtDeportistas = oCon.RetornaRegistros(query);

            if (dtDeportistas != null && dtDeportistas.Rows.Count > 0)
            {
                cmbSelect.DataSource = dtDeportistas;
                cmbSelect.DisplayMember = "NombreCompleto";
                cmbSelect.ValueMember = "IdDeportista";
                cmbSelect.SelectedIndex = -1;
            }
        }

        private void CargarTablaEnergia()
        {
            string query;

            if (frmInicioDeSesion.NombreRolActual == "Entrenador" &&
                frmInicioDeSesion.IdEntrenadorActual.HasValue)
            {
                int idEntrenador = frmInicioDeSesion.IdEntrenadorActual.Value;

                query = @"
                select distinct
                    D.Nombres + ' ' + D.Apellidos as DEPORTISTA,
                    cast(isnull(M.Peso, 70.0) as varchar) + ' kg' as PESO,
                    G.NivelEReport as ENERGÍA,
                    G.Intensidad as INTENSIDAD,
                    cast(G.[Duración] as varchar) + ' min' as [DURACIÓN DEL ENTRENAMIENTO],
                    cast(G.GastoCal as varchar) + ' kcal' as [GASTO CALÓRICO],
                    G.DeficitEn as [DÉFICIT ENERGÉTICO]
                from GastoCalorico G
                inner join Deportistas D on G.idDeportista = D.IdDeportista
                inner join Inscripciones I on D.IdDeportista = I.IdDeportista
                inner join EntrenadorDeporte ED on I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte
                left join (
                    select idDeportista, Peso,
                           row_number() over(partition by idDeportista order by FechaMedicion desc) as rn
                    from MedicionesDeportista
                ) M on D.IdDeportista = M.idDeportista and M.rn = 1
                where ED.IdEntrenador = " + idEntrenador + @"
                and ED.Activo = 1
                and I.Estado <> 'Finalizado'";
            }
            else
            {
                query = @"
                select
                    D.Nombres + ' ' + D.Apellidos as DEPORTISTA,
                    cast(isnull(M.Peso, 70.0) as varchar) + ' kg' as PESO,
                    G.NivelEReport as ENERGÍA,
                    G.Intensidad as INTENSIDAD,
                    cast(G.[Duración] as varchar) + ' min' as [DURACIÓN DEL ENTRENAMIENTO],
                    cast(G.GastoCal as varchar) + ' kcal' as [GASTO CALÓRICO],
                    G.DeficitEn as [DÉFICIT ENERGÉTICO]
                from GastoCalorico G
                inner join Deportistas D on G.idDeportista = D.IdDeportista
                left join (
                    select idDeportista, Peso,
                           row_number() over(partition by idDeportista order by FechaMedicion desc) as rn
                    from MedicionesDeportista
                ) M on D.IdDeportista = M.idDeportista and M.rn = 1";
            }

            DataTable dt = oCon.RetornaRegistros(query);

            dgvEnergia.DataSource = null;

            if (dt != null && dt.Rows.Count > 0)
                dgvEnergia.DataSource = dt;

            dgvEnergia.ClearSelection();
        }

        private bool ValidarCampos()
        {
            if (cmbSelect.SelectedIndex == -1 || cmbSelect.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un deportista.",
                    "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cmbSelect.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtBDuracion.Text))
            {
                MessageBox.Show("Por favor, ingrese la duración del entrenamiento en minutos.",
                    "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtBDuracion.Focus();
                return false;
            }

            if (!int.TryParse(txtBDuracion.Text.Trim(), out int duracion) ||
                duracion < 1 || duracion > 120)
            {
                MessageBox.Show("Ingrese una duración válida entre 1 y 120 minutos (máximo 2 horas por sesión).",
                    "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtBDuracion.SelectAll();
                txtBDuracion.Focus();
                return false;
            }

            if (cmbIER.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el nivel de intensidad del entrenamiento.",
                    "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cmbIER.Focus();
                return false;
            }

            if (cmbNERP.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el nivel de energía reportado.",
                    "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cmbNERP.Focus();
                return false;
            }

            return true;
        }

        private double ObtenerUltimoPesoDeportista(int idDeportista)
        {
            string query = "select top 1 Peso from MedicionesDeportista " +
                           "where idDeportista = " + idDeportista + " " +
                           "order by FechaMedicion desc";

            DataTable dt = oCon.RetornaRegistros(query);

            if (dt != null && dt.Rows.Count > 0 &&
                dt.Rows[0]["Peso"] != DBNull.Value)
            {
                return Convert.ToDouble(dt.Rows[0]["Peso"]);
            }

            return 70.0;
        }

        private void btnRegisterCarga_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            int idDeportista = Convert.ToInt32(cmbSelect.SelectedValue);
            int duracion = Convert.ToInt32(txtBDuracion.Text.Trim());
            string intensidad = cmbIER.SelectedItem.ToString();
            string nivelEnergia = cmbNERP.SelectedItem.ToString();
            double peso = ObtenerUltimoPesoDeportista(idDeportista);

            double met = 3.5;

            if (intensidad == "Medio")
                met = 6.0;
            else if (intensidad == "Alto")
                met = 8.5;

            double gastoCalorico =
                Math.Round(met * peso * (duracion / 60.0), 2);

            string deficit = "Normal";

            if (nivelEnergia == "Bajo" &&
                (intensidad == "Alto" || intensidad == "Medio"))
            {
                deficit = "Alto";
            }
            else if (nivelEnergia == "Bajo" ||
                     (nivelEnergia == "Medio" && intensidad == "Alto"))
            {
                deficit = "Moderado";
            }

            string campos =
                "idDeportista, [Duración], Intensidad, GastoCal, NivelEReport, DeficitEn";

            string valores =
                $"{idDeportista}, {duracion}, '{intensidad}', " +
                $"{gastoCalorico.ToString(System.Globalization.CultureInfo.InvariantCulture)}, " +
                $"'{nivelEnergia}', '{deficit}'";

            if (oCon.insertDatos("GastoCalorico", campos, valores))
            {
                MessageBox.Show(
                    $"Registro guardado correctamente.\n\n" +
                    $"Gasto Calórico Estimado: {gastoCalorico} kcal\n" +
                    $"Déficit Energético: {deficit}",
                    "Zenova",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                cmbSelect.SelectedIndex = -1;
                txtBDuracion.Clear();
                cmbIER.SelectedIndex = -1;
                cmbNERP.SelectedIndex = -1;

                CargarTablaEnergia();
            }
        }
    }
}
