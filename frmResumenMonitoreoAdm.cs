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
    public partial class frmResumenMonitoreoAdm : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        public frmResumenMonitoreoAdm()
        {
            InitializeComponent();
            bttActualizar.Click += bttActualizar_Click;
        }

        private void frmResumenMonitoreoAdm_Load(object sender, EventArgs e)
        {
            dgvAlertasRecientes.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgvAlertasRecientes.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            dgvResumenSesiones.RowsDefaultCellStyle.ForeColor = Color.Black;
            dgvResumenSesiones.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;

            ConfigurarFiltros();
            CargarEntrenadoresActivos();
            CargarDeportistasSeguimiento();
            CargarResumenSesiones();
            CargarAlertasPendientes();
            CargarDeportes();
            CargarAlertasRecientes();

        }
        private void CargarResumenSesiones()
        {
            string periodo = cmbPeriodo.SelectedItem == null ? "Este mes": cmbPeriodo.SelectedItem.ToString();

            string deporte = cbmDeporte.SelectedItem == null ? "Todos": cbmDeporte.SelectedItem.ToString();

            DateTime hoy = DateTime.Today;
            DateTime fechaInicio;
            DateTime fechaFin;

            if (periodo == "Últimos 3 meses")
            {
                fechaInicio = new DateTime( hoy.Year, hoy.Month, 1).AddMonths(-2);

                fechaFin = new DateTime( hoy.Year, hoy.Month,  1).AddMonths(1);
            }
            else if (periodo == "Este año")
            {
                fechaInicio = new DateTime( hoy.Year, 1, 1);

                fechaFin = fechaInicio.AddYears(1);
            }
            else
            {
                fechaInicio = new DateTime( hoy.Year,hoy.Month, 1);

                fechaFin = fechaInicio.AddMonths(1);
            }

            string consulta =  "select " + "count(*) as Programadas, " + "isnull(sum(case " +
                "when lower(ltrim(rtrim(isnull(s.Estado, '')))) = 'realizada' " + "then 1 else 0 end), 0) as Realizadas " +
                "from SesionesEntrenamiento s " + "inner join EntrenadorDeporte ed " +  "on s.IdEntrenadorDeporte = ed.IdEntrenadorDeporte " +
                "inner join Deportes d " + "on ed.IdDeporte = d.IdDeporte " + "where s.Fecha >= '" + fechaInicio.ToString("yyyyMMdd") + "' " +
                "and s.Fecha < '" +  fechaFin.ToString("yyyyMMdd") + "' ";

            if (deporte != "Todos")
            {
                string deporteSeguro =  deporte.Replace("'", "''");

                consulta +=  "and d.NombreDeporte = N'" + deporteSeguro + "' ";
            }

            DataTable datos =  conSQL.RetornaRegistros(consulta);

            int programadas = 0;
            int realizadas = 0;

            if (datos != null && datos.Rows.Count > 0)
            {
                programadas = Convert.ToInt32( datos.Rows[0]["Programadas"]);

                realizadas = Convert.ToInt32( datos.Rows[0]["Realizadas"]);
            }

            int pendientes = programadas - realizadas;

            int cumplimiento = 0;

            if (programadas > 0)
            {
                cumplimiento = (realizadas * 100) / programadas;
            }

            DataTable resumen = new DataTable();

            resumen.Columns.Add( "Periodo",  typeof(string));

            resumen.Columns.Add( "Programadas",  typeof(int));

            resumen.Columns.Add("Realizadas", typeof(int));

            resumen.Columns.Add( "Pendientes", typeof(int));

            resumen.Columns.Add( "Cumplimiento",typeof(string));

            resumen.Rows.Add( periodo,  programadas, realizadas, pendientes, cumplimiento + "%"
            );

            dgvResumenSesiones.AutoGenerateColumns = false;
            dgvResumenSesiones.DataSource = resumen;

            lblCumplimiento.Text = cumplimiento + "%";
        }
        private void ConfigurarFiltros()
        {
            cmbPeriodo.Items.Clear();
            cmbPeriodo.Items.Add("Este mes");
            cmbPeriodo.Items.Add("Últimos 3 meses");
            cmbPeriodo.Items.Add("Este año");
            cmbPeriodo.SelectedIndex = 0;

            CargarDeportes();
        }
        private void CargarEntrenadoresActivos()
        {
            string periodo = cmbPeriodo.SelectedItem == null ? "Este mes" : cmbPeriodo.SelectedItem.ToString();

            string deporte = cbmDeporte.SelectedItem == null ? "Todos" : cbmDeporte.SelectedItem.ToString();

            DateTime hoy = DateTime.Today;
            DateTime fechaInicio;
            DateTime fechaFin;

            if (periodo == "Últimos 3 meses")
            {
                fechaInicio = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(-2);

                fechaFin = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(1);
            }
            else if (periodo == "Este año")
            {
                fechaInicio = new DateTime(hoy.Year, 1, 1);

                fechaFin = fechaInicio.AddYears(1);
            }
            else
            {
                fechaInicio = new DateTime(hoy.Year, hoy.Month, 1);

                fechaFin = fechaInicio.AddMonths(1);
            }
            string consulta = "select " + "count(distinct e.IdEntrenador) as Total, " + "count(distinct case " +
            "when s.IdSesion is not null " + "then e.IdEntrenador end) as AlDia " + "from Entrenadores e " +
            "left join EntrenadorDeporte ed " + "on e.IdEntrenador = ed.IdEntrenador " + "and ed.Activo = 1 " + "left join Deportes d " +
            "on ed.IdDeporte = d.IdDeporte " + "left join SesionesEntrenamiento s " + "on ed.IdEntrenadorDeporte = " +
            "s.IdEntrenadorDeporte " + "and s.Fecha >= '" + fechaInicio.ToString("yyyyMMdd") + "' " + "and s.Fecha < '" +  fechaFin.ToString("yyyyMMdd") + "' " +
            "and lower(ltrim(rtrim(isnull(s.Estado, '')))) " +  "= 'realizada' " +  "where upper(ltrim(rtrim(e.EstadoEntrenador))) " + "= 'ACTIVO' ";

            if (deporte != "Todos")
            {
                string deporteSeguro =  deporte.Replace("'", "''");

                consulta += "and d.NombreDeporte = N'" +  deporteSeguro + "' ";
            }

            DataTable datos =   conSQL.RetornaRegistros(consulta);

            int total = 0;
            int alDia = 0;

            if (datos != null && datos.Rows.Count > 0)
            {
                total = Convert.ToInt32( datos.Rows[0]["Total"]);

                alDia = Convert.ToInt32(  datos.Rows[0]["AlDia"]);
            }
            int pendientes =  Math.Max(0, total - alDia);

            lblTotaldeEntrenadores.Text = total.ToString();

            lblEntrenadoresAlDia.Text =  alDia.ToString();

            lblEntrenadoresPendientes.Text = pendientes.ToString();


        }

        private void CargarDeportistasSeguimiento()
        {
            string periodo = cmbPeriodo.SelectedItem == null ? "Este mes": cmbPeriodo.SelectedItem.ToString();
            string deporte = cbmDeporte.SelectedItem == null ? "Todos": cbmDeporte.SelectedItem.ToString();
            DateTime hoy = DateTime.Today;
            DateTime fechaInicio;
            DateTime fechaFin;
            if (periodo == "Últimos 3 meses")
            {
                fechaInicio = new DateTime( hoy.Year, hoy.Month, 1).AddMonths(-2);

                fechaFin = new DateTime( hoy.Year, hoy.Month, 1).AddMonths(1);
            }
            else if (periodo == "Este año")
            {
                fechaInicio = new DateTime(hoy.Year, 1, 1);
                fechaFin = fechaInicio.AddYears(1);
            }
            else
            {
                fechaInicio = new DateTime(hoy.Year, hoy.Month, 1);

                fechaFin = fechaInicio.AddMonths(1);
            }
            string consulta = "select count(*) as Total, " + "isnull(sum(case when p.IdDeportista is not null " + "then 1 else 0 end), 0) as AlDia " +
            "from Deportistas d " +"left join " + "(select distinct IdDeportista " +"from PruebasFisicas " +"where Fecha >= '" +
             fechaInicio.ToString("yyyyMMdd") + "' " +"and Fecha < '" +fechaFin.ToString("yyyyMMdd") + "') p " +"on d.IdDeportista = p.IdDeportista " +
             "where d.Estado = 1";
            if (deporte != "Todos")
            {
                string deporteSeguro = deporte.Replace("'", "''");

                consulta +=
                    " and exists (" +
                    "select 1 from Inscripciones i " +
                    "inner join EntrenadorDeporte ed " +
                    "on i.IdEntrenadorDeporte = ed.IdEntrenadorDeporte " +
                    "inner join Deportes dep " +
                    "on ed.IdDeporte = dep.IdDeporte " +
                    "where i.IdDeportista = d.IdDeportista " +
                    "and dep.NombreDeporte = N'" + deporteSeguro + "'" +
                    ")";
            }

            DataTable datos = conSQL.RetornaRegistros(consulta);

            int total = 0;
            int alDia = 0;

            if (datos != null && datos.Rows.Count > 0)
            {
                total = Convert.ToInt32(datos.Rows[0]["Total"]);
                alDia = Convert.ToInt32(datos.Rows[0]["AlDia"]);
            }

            int porRevisar = Math.Max(0, total - alDia);
            lblTotalDeportistas.Text = total.ToString();

            lblDeportistasAlDia.Text = alDia.ToString();

            lblDeportistasPorRevisar.Text = porRevisar.ToString();
        }

        private void CargarAlertasPendientes()
        {
            string periodo = cmbPeriodo.SelectedItem == null? "Este mes" : cmbPeriodo.SelectedItem.ToString();

            string deporte = cbmDeporte.SelectedItem == null  ? "Todos" : cbmDeporte.SelectedItem.ToString();

            DateTime hoy = DateTime.Today;
            DateTime fechaInicio;
            DateTime fechaFin;

            if (periodo == "Últimos 3 meses")
            {
                fechaInicio = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(-2);
                fechaFin = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(1);
            }
            else if (periodo == "Este año")
            {
                fechaInicio = new DateTime(hoy.Year, 1, 1);
                fechaFin = fechaInicio.AddYears(1);
            }
            else
            {
                fechaInicio = new DateTime(hoy.Year, hoy.Month, 1);
                fechaFin = fechaInicio.AddMonths(1);
            }

            string consulta =  "select count(*) as Total " +"from AlertasMonitoreo a " + "where lower(ltrim(rtrim(isnull(a.Estado, '')))) = 'pendiente' " +
                "and a.Fecha >= '" + fechaInicio.ToString("yyyyMMdd") + "' " +  "and a.Fecha < '" + fechaFin.ToString("yyyyMMdd") + "' ";

            if (deporte != "Todos")
            {
                string deporteSeguro = deporte.Replace("'", "''");

                consulta += "and exists (" + "select 1 from Inscripciones i " + "inner join EntrenadorDeporte ed " + "on i.IdEntrenadorDeporte = ed.IdEntrenadorDeporte " +
                    "inner join Deportes dep " + "on ed.IdDeporte = dep.IdDeporte " +"where i.IdDeportista = a.IdDeportista " +
                    "and dep.NombreDeporte = N'" + deporteSeguro + "'" +")";
            }

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
                lblTotalAlertas.Text = datos.Rows[0]["Total"].ToString();
            else
                lblTotalAlertas.Text = "0";
        }
        private void CargarDeportes()
        {
            cbmDeporte.Items.Clear();
            cbmDeporte.Items.Add("Todos");

            string consulta =  "select NombreDeporte " + "from Deportes " + "where Activo = 1 " + "order by NombreDeporte";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null)
            {
                foreach (DataRow fila in datos.Rows)
                {
                    cbmDeporte.Items.Add(  fila["NombreDeporte"].ToString());
                }
            }

            cbmDeporte.SelectedIndex = 0;
        }

        private void bttActualizar_Click(object sender, EventArgs e)
        {
            CargarEntrenadoresActivos();
            CargarDeportistasSeguimiento();
            CargarResumenSesiones();
            CargarAlertasPendientes();
            CargarAlertasRecientes();
        }

        private void CargarAlertasRecientes()
        {
            string periodo = cmbPeriodo.SelectedItem == null ? "Este mes" : cmbPeriodo.SelectedItem.ToString();

            string deporte = cbmDeporte.SelectedItem == null ? "Todos" : cbmDeporte.SelectedItem.ToString();

            DateTime hoy = DateTime.Today;
            DateTime fechaInicio;
            DateTime fechaFin;

            if (periodo == "Últimos 3 meses")
            {
                fechaInicio = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(-2);
                fechaFin = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(1);
            }
            else if (periodo == "Este año")
            {
                fechaInicio = new DateTime(hoy.Year, 1, 1);
                fechaFin = fechaInicio.AddYears(1);
            }
            else
            {
                fechaInicio = new DateTime(hoy.Year, hoy.Month, 1);
                fechaFin = fechaInicio.AddMonths(1);
            }

            string consulta = "select top 5 a.Tipo, a.Persona, a.Motivo, " + "a.Fecha, a.Prioridad " + "from AlertasMonitoreo a " +
                "where lower(ltrim(rtrim(isnull(a.Estado, '')))) = 'pendiente' " + "and a.Fecha >= '" + fechaInicio.ToString("yyyyMMdd") + "' " +
                "and a.Fecha < '" + fechaFin.ToString("yyyyMMdd") + "' ";

            if (deporte != "Todos")
            {
                string deporteSeguro = deporte.Replace("'", "''");

                consulta += "and exists (" + "select 1 from Inscripciones i " + "inner join EntrenadorDeporte ed " +
                    "on i.IdEntrenadorDeporte = ed.IdEntrenadorDeporte " + "inner join Deportes dep " +"on ed.IdDeporte = dep.IdDeporte " +
                    "where i.IdDeportista = a.IdDeportista " + "and dep.NombreDeporte = N'" + deporteSeguro + "'" + ") ";
            }

            consulta += "order by a.Fecha desc, a.IdAlerta desc";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            dgvAlertasRecientes.AutoGenerateColumns = false;
            dgvAlertasRecientes.DataSource = datos;
        }
        private void btnVerTodasAlertas_Click(object sender, EventArgs e)
        {
            string periodo = cmbPeriodo.SelectedItem == null ? "Este mes" : cmbPeriodo.SelectedItem.ToString();

            string deporte = cbmDeporte.SelectedItem == null ? "Todos" : cbmDeporte.SelectedItem.ToString();

            DateTime hoy = DateTime.Today;
            DateTime fechaInicio;
            DateTime fechaFin;

            if (periodo == "Últimos 3 meses")
            {
                fechaInicio = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(-2);
                fechaFin = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(1);
            }
            else if (periodo == "Este año")
            {
                fechaInicio = new DateTime(hoy.Year, 1, 1);
                fechaFin = fechaInicio.AddYears(1);
            }
            else
            {
                fechaInicio = new DateTime(hoy.Year, hoy.Month, 1);
                fechaFin = fechaInicio.AddMonths(1);
            }
            string consulta =  "select a.Tipo, a.Persona, a.Motivo, a.Fecha, a.Prioridad " +"from AlertasMonitoreo a " +
                  "where lower(ltrim(rtrim(isnull(a.Estado, '')))) = 'pendiente' " +"and a.Fecha >= '" + fechaInicio.ToString("yyyyMMdd") + "' " +
                  "and a.Fecha < '" + fechaFin.ToString("yyyyMMdd") + "' ";

            if (deporte != "Todos")
            {
                string deporteSeguro = deporte.Replace("'", "''");

                consulta += "and exists (" +  "select 1 from Inscripciones i " + "inner join EntrenadorDeporte ed " +
                    "on i.IdEntrenadorDeporte = ed.IdEntrenadorDeporte " + "inner join Deportes dep " +
                    "on ed.IdDeporte = dep.IdDeporte " + "where i.IdDeportista = a.IdDeportista " +
                    "and dep.NombreDeporte = N'" + deporteSeguro + "'" + ") ";
            }

            consulta += "order by a.Fecha desc, a.IdAlerta desc";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            dgvAlertasRecientes.AutoGenerateColumns = false;
            dgvAlertasRecientes.DataSource = datos;


        }
    }
}
