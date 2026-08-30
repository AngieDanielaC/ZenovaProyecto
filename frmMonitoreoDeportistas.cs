using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmMonitoreoDeportistas : Form
    {
        private readonly csConectaSQL conSQL = new csConectaSQL();
        private bool cargando;

        public frmMonitoreoDeportistas()
        {
            InitializeComponent();

            txtBuscarDeportista.TextChanged += Filtros_Cambiados;
            cmbDeporte.SelectedIndexChanged += Filtros_Cambiados;
            cmbEntrenador.SelectedIndexChanged += Filtros_Cambiados;
            cmbSeguimiento.SelectedIndexChanged += Filtros_Cambiados;
            btnActualizar.Click += btnActualizar_Click;
            dgvDeportistasMonitoreo.CellContentClick +=
                dgvDeportistasMonitoreo_CellContentClick;

            Color colorTexto = Color.FromArgb(16, 31, 107);
            dgvDeportistasMonitoreo.DefaultCellStyle.ForeColor = colorTexto;
            dgvDeportistasMonitoreo.RowsDefaultCellStyle.ForeColor = colorTexto;
            dgvDeportistasMonitoreo.AlternatingRowsDefaultCellStyle.ForeColor = colorTexto;
            dgvDeportistasMonitoreo.DefaultCellStyle.SelectionForeColor = colorTexto;

            colVerDetalle.Text = "Ver detalle";
            colVerDetalle.UseColumnTextForButtonValue = true;
        }

        private void frmMonitoreoDeportistas_Load(object sender, EventArgs e)
        {
            cargando = true;

            CargarDeportes();
            CargarEntrenadores();
            cmbSeguimiento.SelectedIndex = 0;
            txtBuscarDeportista.Clear();

            cargando = false;
            CargarDeportistas();
        }

        private void CargarDeportes()
        {
            cmbDeporte.Items.Clear();
            cmbDeporte.Items.Add("Todos");

            DataTable datos = conSQL.RetornaRegistros(
                "select NombreDeporte from Deportes order by NombreDeporte");

            if (datos != null)
            {
                foreach (DataRow fila in datos.Rows)
                {
                    cmbDeporte.Items.Add(fila["NombreDeporte"].ToString());
                }
            }

            cmbDeporte.SelectedIndex = 0;
        }

        private void CargarEntrenadores()
        {
            cmbEntrenador.Items.Clear();
            cmbEntrenador.Items.Add("Todos");

            DataTable datos = conSQL.RetornaRegistros(
                "select Nombres + ' ' + Apellidos as Entrenador " +
                "from Entrenadores order by Nombres, Apellidos");

            if (datos != null)
            {
                foreach (DataRow fila in datos.Rows)
                {
                    cmbEntrenador.Items.Add(fila["Entrenador"].ToString());
                }
            }

            cmbEntrenador.SelectedIndex = 0;
        }

        private void CargarDeportistas()
        {
            string buscar = txtBuscarDeportista.Text.Trim().Replace("'", "''");
            string deporte = cmbDeporte.SelectedItem == null
                ? "Todos"
                : cmbDeporte.SelectedItem.ToString();
            string entrenador = cmbEntrenador.SelectedItem == null
                ? "Todos"
                : cmbEntrenador.SelectedItem.ToString();
            string seguimiento = cmbSeguimiento.SelectedItem == null
                ? "Todos"
                : cmbSeguimiento.SelectedItem.ToString();

            string consulta =
                "select * from (" +
                "select d.IdDeportista as ID, " +
                "d.Nombres + ' ' + d.Apellidos as Deportista, " +
                "datediff(year, d.FechaNacimiento, getdate()) - " +
                "case when dateadd(year, datediff(year, d.FechaNacimiento, getdate()), " +
                "d.FechaNacimiento) > cast(getdate() as date) then 1 else 0 end as Edad, " +
                "isnull(asig.Deporte, 'Sin asignar') as Deporte, " +
                "isnull(asig.Entrenador, 'Sin asignar') as Entrenador, " +
                "case when d.Estado = 1 then 'Activo' else 'Inactivo' end as Estado, " +
                "case when isnull(asi.Total, 0) = 0 then 'Sin registro' " +
                "else convert(varchar(10), cast(asi.Presentes * 100.0 / asi.Total " +
                "as decimal(5,1))) + '%' end as Asistencia, " +
                "case when rep.UltimaMedicion is null then 'Sin registro' " +
                "else convert(varchar(10), rep.UltimaMedicion, 103) end as [Último Detalle], " +
                "case " +
                "when rep.UltimaMedicion is null or " +
                "rep.UltimaMedicion < dateadd(day, -7, cast(getdate() as date)) " +
                "then 'Sin registro reciente' " +
                "when isnull(ale.Pendientes, 0) > 0 then 'Por revisar' " +
                "else 'Al día' end as Seguimiento " +
                "from Deportistas d " +
                "outer apply (" +
                "select top 1 dep.NombreDeporte as Deporte, " +
                "e.Nombres + ' ' + e.Apellidos as Entrenador " +
                "from Inscripciones i " +
                "inner join EntrenadorDeporte ed " +
                "on i.IdEntrenadorDeporte = ed.IdEntrenadorDeporte " +
                "inner join Deportes dep on ed.IdDeporte = dep.IdDeporte " +
                "inner join Entrenadores e on ed.IdEntrenador = e.IdEntrenador " +
                "where i.IdDeportista = d.IdDeportista " +
                "order by i.FechaInicio desc) asig " +
                "outer apply (" +
                "select count(*) as Total, " +
                "sum(case when a.Presente = 1 then 1 else 0 end) as Presentes " +
                "from Asistencias a " +
                "where a.IdDeportista = d.IdDeportista " +
                "and a.Fecha >= dateadd(day, -30, cast(getdate() as date))) asi " +
                "outer apply (" +
                "select max(r.Fecha) as UltimaMedicion " +
                "from ReporteTecnicoSemanal r " +
                "where r.IdDeportista = d.IdDeportista) rep " +
                "outer apply (" +
                "select count(*) as Pendientes from AlertasMonitoreo a " +
                "where a.IdDeportista = d.IdDeportista " +
                "and lower(ltrim(rtrim(isnull(a.Estado, '')))) = 'pendiente') ale" +
                ") datos where 1 = 1 ";

            if (buscar != "")
                consulta += "and Deportista like N'%" + buscar + "%' ";

            if (deporte != "Todos")
                consulta += "and Deporte = N'" + deporte.Replace("'", "''") + "' ";

            if (entrenador != "Todos")
            {
                consulta +=
                    "and Entrenador = N'" +
                    entrenador.Replace("'", "''") + "' ";
            }

            if (seguimiento != "Todos")
            {
                consulta +=
                    "and Seguimiento = N'" +
                    seguimiento.Replace("'", "''") + "' ";
            }

            consulta += "order by Deportista";

            DataTable datos = conSQL.RetornaRegistros(consulta);
            dgvDeportistasMonitoreo.AutoGenerateColumns = false;
            dgvDeportistasMonitoreo.DataSource = datos;
            CargarContadores(datos);
        }

        private void CargarContadores(DataTable datos)
        {
            int total = 0;
            int alDia = 0;
            int revisar = 0;
            int sinRegistro = 0;

            if (datos != null)
            {
                total = datos.Rows.Count;

                foreach (DataRow fila in datos.Rows)
                {
                    string valor = fila["Seguimiento"].ToString();

                    if (valor.Equals("Al día", StringComparison.OrdinalIgnoreCase))
                        alDia++;
                    else if (valor.Equals("Por revisar", StringComparison.OrdinalIgnoreCase))
                        revisar++;
                    else if (valor.Equals("Sin registro reciente", StringComparison.OrdinalIgnoreCase))
                        sinRegistro++;
                }
            }

            lblTotalDeportistas.Text = total.ToString();
            lblDeportistasDia.Text = alDia.ToString();
            lblDeportistasRevisar.Text = revisar.ToString();
            lblSinRegistro.Text = sinRegistro.ToString();
        }

        private void Filtros_Cambiados(object sender, EventArgs e)
        {
            if (!cargando)
                CargarDeportistas();
        }

      

        private void dgvDeportistasMonitoreo_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colVerDetalle.Index)
                return;

            DataGridViewRow fila = dgvDeportistasMonitoreo.Rows[e.RowIndex];

            MessageBox.Show(
                "Deportista: " + Convert.ToString(fila.Cells["colDeportista"].Value) + "\n" +
                "Edad: " + Convert.ToString(fila.Cells["colEdad"].Value) + "\n" +
                "Deporte: " + Convert.ToString(fila.Cells["colDeporte"].Value) + "\n" +
                "Entrenador: " + Convert.ToString(fila.Cells["colEntrenador"].Value) + "\n" +
                "Estado: " + Convert.ToString(fila.Cells["colEstado"].Value) + "\n" +
                "Asistencia: " + Convert.ToString(fila.Cells["colAsistencia"].Value) + "\n" +
                "Último registro: " + Convert.ToString(fila.Cells["colUltimaMedicion"].Value) + "\n" +
                "Seguimiento: " + Convert.ToString(fila.Cells["colSeguimiento"].Value),
                "Detalle del deportista",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDeportistas();
        }
    }
}

