using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmMonitoreoEntrenadores : Form
    {
        private readonly csConectaSQL conSQL = new csConectaSQL();
        private bool cargando;

        public frmMonitoreoEntrenadores()
        {
            InitializeComponent();

            textBox1.TextChanged += Filtros_Cambiados;
            cmbDeporte.SelectedIndexChanged += Filtros_Cambiados;
            cmbEstado.SelectedIndexChanged += Filtros_Cambiados;
            cmbSeguimiento.SelectedIndexChanged += Filtros_Cambiados;
            btnActualizar.Click += btnActualizar_Click;
            dgvEntrenadoresMonitoreo.CellContentClick +=
                dgvEntrenadoresMonitoreo_CellContentClick;

            Color colorTexto = Color.FromArgb(16, 31, 107);
            dgvEntrenadoresMonitoreo.DefaultCellStyle.ForeColor = colorTexto;
            dgvEntrenadoresMonitoreo.RowsDefaultCellStyle.ForeColor = colorTexto;
            dgvEntrenadoresMonitoreo.AlternatingRowsDefaultCellStyle.ForeColor = colorTexto;
            dgvEntrenadoresMonitoreo.DefaultCellStyle.SelectionForeColor = colorTexto;

            
            colDeportistas.DataPropertyName = "Deportistas";
            colProgramadas.DataPropertyName = "Programadas";
            colVerDetalle.Text = "Ver detalle";
            colVerDetalle.UseColumnTextForButtonValue = true;

         
        }

        private void frmMonitoreoEntrenadores_Load(object sender, EventArgs e)
        {
            cargando = true;
            CargarDeportes();
            cmbEstado.SelectedIndex = 0;
            cmbSeguimiento.SelectedIndex = 0;
            textBox1.Clear();
            cargando = false;
            CargarEntrenadores();

        }

        private void CargarDeportes()
        {
            string consulta = "select NombreDeporte from Deportes order by NombreDeporte";
            cmbDeporte.Items.Clear();
            cmbDeporte.Items.Add("Todos");

            DataTable datos = conSQL.RetornaRegistros("select Nombres + ' ' + Apellidos as Entrenador " +"from Entrenadores order by Nombres, Apellidos");

            if (datos != null)
            {
                foreach (DataRow fila in datos.Rows)
                    cmbDeporte.Items.Add(fila["NombreDeporte"].ToString());
            }

            cmbDeporte.SelectedIndex = 0;
        }

        private void CargarEntrenadores()
        {
           
            string buscar = textBox1.Text.Trim().Replace("'", "''");
            string deporte = cmbDeporte.SelectedItem == null
                ? "Todos"
                : cmbDeporte.SelectedItem.ToString();
            string estado = cmbEstado.SelectedItem == null
                ? "Todos"
                : cmbEstado.SelectedItem.ToString();
            string seguimiento = cmbSeguimiento.SelectedItem == null
                ? "Todos"
                : cmbSeguimiento.SelectedItem.ToString();

            string consulta =
                "select * from (" +
                "select e.IdEntrenador as ID, " +
                "e.Nombres + ' ' + e.Apellidos as Entrenador, " +
                "isnull(dep.Deporte, 'Sin asignar') as Deporte, " +
                "case when upper(ltrim(rtrim(isnull(e.EstadoEntrenador, '')))) = 'ACTIVO' " +
                "then 'Activo' else 'Inactivo' end as Estado, " +
                "isnull(ins.Deportistas, 0) as Deportistas, " +
                "isnull(ses.Programadas, 0) as Programadas, " +
                "isnull(ses.Realizadas, 0) as Realizadas, " +
                "case when isnull(ses.Programadas, 0) = 0 then '0%' " +
                "else convert(varchar(10), cast(ses.Realizadas * 100.0 / " +
                "ses.Programadas as decimal(5,1))) + '%' end as Cumplimiento, " +
                "case when ses.UltimaActividad is null then 'Sin actividad' " +
                "else convert(varchar(10), ses.UltimaActividad, 103) end as [Última Actividad], " +
                "case " +
                "when isnull(ses.Pendientes, 0) > 0 then 'Pendiente' " +
                "when ses.UltimaActividad is null or " +
                "ses.UltimaActividad < dateadd(day, -7, cast(getdate() as date)) " +
                "then 'Sin actividad' else 'Al día' end as Seguimiento " +
                "from Entrenadores e " +
                "left join (" +
                "select ed.IdEntrenador, " +
                "case when count(distinct d.IdDeporte) > 1 then 'Varios' " +
                "else max(d.NombreDeporte) end as Deporte " +
                "from EntrenadorDeporte ed " +
                "inner join Deportes d on ed.IdDeporte = d.IdDeporte " +
                "where ed.Activo = 1 group by ed.IdEntrenador) dep " +
                "on e.IdEntrenador = dep.IdEntrenador " +
                "left join (" +
                "select ed.IdEntrenador, count(distinct i.IdDeportista) as Deportistas " +
                "from EntrenadorDeporte ed " +
                "left join Inscripciones i " +
                "on ed.IdEntrenadorDeporte = i.IdEntrenadorDeporte " +
                "where ed.Activo = 1 group by ed.IdEntrenador) ins " +
                "on e.IdEntrenador = ins.IdEntrenador " +
                "left join (" +
                "select ed.IdEntrenador, count(s.IdSesion) as Programadas, " +
                "sum(case when lower(ltrim(rtrim(isnull(s.Estado, '')))) = 'realizada' " +
                "then 1 else 0 end) as Realizadas, " +
                "sum(case when s.IdSesion is not null and " +
                "lower(ltrim(rtrim(isnull(s.Estado, '')))) <> 'realizada' " +
                "then 1 else 0 end) as Pendientes, " +
                "max(case when lower(ltrim(rtrim(isnull(s.Estado, '')))) = 'realizada' " +
                "then s.Fecha end) as UltimaActividad " +
                "from EntrenadorDeporte ed " +
                "left join SesionesEntrenamiento s " +
                "on ed.IdEntrenadorDeporte = s.IdEntrenadorDeporte " +
                "and s.Fecha >= dateadd(day, -30, cast(getdate() as date)) " +
                "and s.Fecha <= cast(getdate() as date) " +
                "where ed.Activo = 1 group by ed.IdEntrenador) ses " +
                "on e.IdEntrenador = ses.IdEntrenador) datos " +
                "where 1 = 1 ";

            if (buscar != "")
                consulta += "and Entrenador like N'%" + buscar + "%' ";

            if (deporte != "Todos")
            {
                string deporteSeguro = deporte.Replace("'", "''");
                consulta +=
                    "and exists (select 1 from EntrenadorDeporte edf " +
                    "inner join Deportes df on edf.IdDeporte = df.IdDeporte " +
                    "where edf.IdEntrenador = datos.ID and edf.Activo = 1 " +
                    "and df.NombreDeporte = N'" + deporteSeguro + "') ";
            }

            if (estado != "Todos")
                consulta += "and Estado = N'" + estado.Replace("'", "''") + "' ";

            if (seguimiento != "Todos")
            {
                consulta +=
                    "and Seguimiento = N'" +
                    seguimiento.Replace("'", "''") + "' ";
            }

            consulta += "order by Entrenador";

            DataTable datos = conSQL.RetornaRegistros(consulta);
            dgvEntrenadoresMonitoreo.AutoGenerateColumns = false;
            dgvEntrenadoresMonitoreo.DataSource = datos;
            CargarContadores(datos);
        }

        private void CargarContadores(DataTable datos)
        {
            int total = 0;
            int alDia = 0;
            int pendientes = 0;
            int sinActividad = 0;

            if (datos != null)
            {
                total = datos.Rows.Count;

                foreach (DataRow fila in datos.Rows)
                {
                    string valor = fila["Seguimiento"].ToString();

                    if (valor.Equals("Al día", StringComparison.OrdinalIgnoreCase))
                        alDia++;
                    else if (valor.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                        pendientes++;
                    else if (valor.Equals("Sin actividad", StringComparison.OrdinalIgnoreCase))
                        sinActividad++;
                }
            }

            lblTotalEntrenadores.Text = total.ToString();
            lblEntrenadoresDia.Text = alDia.ToString();
            lblEntrenadoresPendientes.Text = pendientes.ToString();
            lblSinActividad.Text = sinActividad.ToString();
        }

        private void Filtros_Cambiados(object sender, EventArgs e)
        {
            if (!cargando)
                CargarEntrenadores();
        }

        

        private void dgvEntrenadoresMonitoreo_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colVerDetalle.Index)
                return;

            DataGridViewRow fila = dgvEntrenadoresMonitoreo.Rows[e.RowIndex];

            MessageBox.Show(
                "Entrenador: " + Convert.ToString(fila.Cells["colEntrenador"].Value) + "\n" +
                "Deporte: " + Convert.ToString(fila.Cells["colDeporte"].Value) + "\n" +
                "Estado: " + Convert.ToString(fila.Cells["colEstado"].Value) + "\n" +
                "Deportistas: " + Convert.ToString(fila.Cells["colDeportistas"].Value) + "\n" +
                "Sesiones programadas: " + Convert.ToString(fila.Cells["colProgramadas"].Value) + "\n" +
                "Sesiones realizadas: " + Convert.ToString(fila.Cells["colRealizadas"].Value) + "\n" +
                "Cumplimiento: " + Convert.ToString(fila.Cells["colCumplimiento"].Value) + "\n" +
                "Seguimiento: " + Convert.ToString(fila.Cells["colSeguimiento"].Value),
                "Detalle del entrenador",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarEntrenadores();
        }
    }
}
