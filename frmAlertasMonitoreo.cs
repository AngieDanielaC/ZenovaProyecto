using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmAlertasMonitoreo : Form
    {
        private readonly csConectaSQL conSQL = new csConectaSQL();
        private bool cargando;

        public frmAlertasMonitoreo()
        {
            InitializeComponent();

            txtBuscarAlerta.TextChanged += Filtros_Cambiados;
            cmbTipoPersona.SelectedIndexChanged += Filtros_Cambiados;
            cmbPrioridad.SelectedIndexChanged += Filtros_Cambiados;
            cmbEstadoAlerta.SelectedIndexChanged += Filtros_Cambiados;
            btnActualizar.Click += btnActualizar_Click;
            dgvAlertasMonitoreo.CellFormatting += dgvAlertasMonitoreo_CellFormatting;
            dgvAlertasMonitoreo.CellContentClick += dgvAlertasMonitoreo_CellContentClick;

            Color colorTexto = Color.FromArgb(16, 31, 107);
            dgvAlertasMonitoreo.DefaultCellStyle.ForeColor = colorTexto;
            dgvAlertasMonitoreo.RowsDefaultCellStyle.ForeColor = colorTexto;
            dgvAlertasMonitoreo.AlternatingRowsDefaultCellStyle.ForeColor = colorTexto;
            dgvAlertasMonitoreo.DefaultCellStyle.SelectionForeColor = colorTexto;

            colRevisar.Text = "Revisar";
            colRevisar.UseColumnTextForButtonValue = true;
        }

        private void frmAlertasMonitoreo_Load(object sender, EventArgs e)
        {
            cargando = true;

            cmbTipoPersona.Items.Clear();
            cmbTipoPersona.Items.AddRange(new object[] { "Todos", "Entrenador", "Deportista" });

            cmbPrioridad.Items.Clear();
            cmbPrioridad.Items.AddRange(new object[] { "Todas", "Alta", "Media", "Baja" });

            cmbEstadoAlerta.Items.Clear();
            cmbEstadoAlerta.Items.AddRange(new object[] { "Todas", "Pendiente", "Revisada" });

            cmbTipoPersona.SelectedIndex = 0;
            cmbPrioridad.SelectedIndex = 0;
            cmbEstadoAlerta.SelectedIndex = 0;
            txtBuscarAlerta.Clear();

            cargando = false;

            GenerarAlertasDeportistas();
            GenerarAlertasEntrenadores();
            CargarAlertas();
            CargarContadores();
        }

        private void CargarAlertas()
        {
            string tipo = cmbTipoPersona.SelectedItem == null
                ? "Todos"
                : cmbTipoPersona.SelectedItem.ToString();

            string prioridad = cmbPrioridad.SelectedItem == null
                ? "Todas"
                : cmbPrioridad.SelectedItem.ToString();

            string estado = cmbEstadoAlerta.SelectedItem == null
                ? "Todas"
                : cmbEstadoAlerta.SelectedItem.ToString();

            string buscar = txtBuscarAlerta.Text.Trim().Replace("'", "''");

            string consulta =
                "select IdAlerta as ID, Tipo, Persona, Motivo, Fecha, Prioridad, Estado " +
                "from AlertasMonitoreo where 1 = 1 ";

            if (tipo != "Todos")
                consulta += "and Tipo = '" + tipo.Replace("'", "''") + "' ";

            if (prioridad != "Todas")
                consulta += "and Prioridad = '" + prioridad.Replace("'", "''") + "' ";

            if (estado != "Todas")
                consulta += "and Estado = '" + estado.Replace("'", "''") + "' ";

            if (buscar != "")
            {
                consulta +=
                    "and (Persona like N'%" + buscar + "%' " +
                    "or Motivo like N'%" + buscar + "%') ";
            }

            consulta += "order by Fecha desc";

            DataTable datos = conSQL.RetornaRegistros(consulta);
            dgvAlertasMonitoreo.AutoGenerateColumns = false;
            dgvAlertasMonitoreo.DataSource = datos;
        }

        private void CargarContadores()
        {
            string consulta =
                "select count(*) as Total, " +
                "isnull(sum(case when lower(ltrim(rtrim(Estado))) = 'pendiente' then 1 else 0 end), 0) as Pendientes, " +
                "isnull(sum(case when lower(ltrim(rtrim(Tipo))) = 'entrenador' then 1 else 0 end), 0) as Entrenadores, " +
                "isnull(sum(case when lower(ltrim(rtrim(Tipo))) = 'deportista' then 1 else 0 end), 0) as Deportistas " +
                "from AlertasMonitoreo";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                lblTotalAlertas.Text = datos.Rows[0]["Total"].ToString();
                lblAlertasPendientes.Text = datos.Rows[0]["Pendientes"].ToString();
                lblAlertasEntrenadores.Text = datos.Rows[0]["Entrenadores"].ToString();
                lblAlertasDeportistas.Text = datos.Rows[0]["Deportistas"].ToString();
            }
        }

        private void Filtros_Cambiados(object sender, EventArgs e)
        {
            if (!cargando)
                CargarAlertas();
        }

        

        private void GenerarAlertasDeportistas()
        {
            string consulta =
                "insert into AlertasMonitoreo " +
                "(Tipo, Persona, Motivo, Fecha, Prioridad, Estado, IdDeportista) " +
                "select 'Deportista', d.Nombres + ' ' + d.Apellidos, " +
                "case " +
                "when r.NivelFatiga = 'Alto' and r.Disponibilidad < 60 then 'Fatiga alta y disponibilidad baja' " +
                "when r.NivelFatiga = 'Alto' then 'Nivel de fatiga alto' " +
                "else 'Disponibilidad baja' end, " +
                "r.Fecha, " +
                "case when r.NivelFatiga = 'Alto' or r.Disponibilidad < 40 then 'Alta' else 'Media' end, " +
                "'Pendiente', d.IdDeportista " +
                "from ReporteTecnicoSemanal r " +
                "inner join Deportistas d on r.IdDeportista = d.IdDeportista " +
                "where (r.NivelFatiga = 'Alto' or r.Disponibilidad < 60) " +
                "and not exists (" +
                "select 1 from AlertasMonitoreo a " +
                "where a.IdDeportista = d.IdDeportista " +
                "and cast(a.Fecha as date) = cast(r.Fecha as date))";

            conSQL.EjecutaSentenciaParametros(consulta);
        }

        private void GenerarAlertasEntrenadores()
        {
            string consulta =
                "insert into AlertasMonitoreo " +
                "(Tipo, Persona, Motivo, Fecha, Prioridad, Estado, IdDeportista) " +
                "select 'Entrenador', e.Nombres + ' ' + e.Apellidos, " +
                "'Sin sesiones realizadas en los últimos 7 días', " +
                "getdate(), 'Media', 'Pendiente', null " +
                "from Entrenadores e " +
                "where upper(ltrim(rtrim(isnull(e.EstadoEntrenador, '')))) = 'ACTIVO' " +
                "and not exists (" +
                "select 1 from EntrenadorDeporte ed " +
                "inner join SesionesEntrenamiento s " +
                "on ed.IdEntrenadorDeporte = s.IdEntrenadorDeporte " +
                "where ed.IdEntrenador = e.IdEntrenador " +
                "and ed.Activo = 1 " +
                "and s.Fecha >= dateadd(day, -7, cast(getdate() as date)) " +
                "and lower(ltrim(rtrim(isnull(s.Estado, '')))) = 'realizada') " +
                "and not exists (" +
                "select 1 from AlertasMonitoreo a " +
                "where lower(ltrim(rtrim(a.Tipo))) = 'entrenador' " +
                "and a.Persona = e.Nombres + ' ' + e.Apellidos " +
                "and a.Motivo = 'Sin sesiones realizadas en los últimos 7 días' " +
                "and a.Fecha >= dateadd(day, -7, cast(getdate() as date)))";

            conSQL.EjecutaSentenciaParametros(consulta);
        }

        private void dgvAlertasMonitoreo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colRevisar.Index)
                return;

            object idValor = dgvAlertasMonitoreo.Rows[e.RowIndex]
                .Cells["colIdAlerta"].Value;

            if (idValor == null || idValor == DBNull.Value)
                return;

            int idAlerta = Convert.ToInt32(idValor);
            string estado = Convert.ToString(
                dgvAlertasMonitoreo.Rows[e.RowIndex].Cells["colEstado"].Value);

            if (estado.Equals("Revisada", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Esta alerta ya fue revisada.");
                return;
            }

            bool actualizado = conSQL.EjecutaSentenciaParametros(
                "update AlertasMonitoreo set Estado = @Estado where IdAlerta = @IdAlerta",
                new SqlParameter("@Estado", "Revisada"),
                new SqlParameter("@IdAlerta", idAlerta));

            if (actualizado)
            {
                MessageBox.Show("Alerta marcada como revisada.");
                CargarAlertas();
                CargarContadores();
            }
        }

        private void dgvAlertasMonitoreo_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.Value == null)
                return;

            string columna = dgvAlertasMonitoreo.Columns[e.ColumnIndex].Name;
            string valor = e.Value.ToString();

            if (columna == "colPrioridad")
            {
                if (valor.Equals("Alta", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.Firebrick;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (valor.Equals("Media", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.Gold;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (valor.Equals("Baja", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.SeaGreen;
                    e.CellStyle.ForeColor = Color.White;
                }
            }

            if (columna == "colEstado")
            {
                if (valor.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                    e.CellStyle.ForeColor = Color.Firebrick;
                else if (valor.Equals("Revisada", StringComparison.OrdinalIgnoreCase))
                    e.CellStyle.ForeColor = Color.SeaGreen;

                e.CellStyle.Font = new Font(
                    dgvAlertasMonitoreo.Font,
                    FontStyle.Bold);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            GenerarAlertasDeportistas();
            GenerarAlertasEntrenadores();
            CargarAlertas();
            CargarContadores();
        }
    }
}
