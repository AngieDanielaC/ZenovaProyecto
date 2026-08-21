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
    public partial class frmMoniDeportistas : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        public frmMoniDeportistas()
        {
            InitializeComponent();
        }

        private void frmMoniDeportistas_Load(object sender, EventArgs e)
        {
            CargarDeportistasActivos();
            CargarSesionesDeHoy();
            CargarProximaSesion();
            CargarEstadoDeportistas();
            CargarAlertasCriticas();
            CargarEvaluacionesRecientes();
            CargarProximosEventos();
            CargarProgresoPlanificacion();
            CargarIntensidadPercibida();
        }
        private void CargarDeportistasActivos()
        {
            string consulta = "select count(*) as Total " + "from Deportistas " +
                "where Estado = 1 " + "and EstadoMonitoreo = 'Activo'";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                label12.Text =datos.Rows[0]["Total"].ToString();
            }
            else
            {
                label12.Text = "0";
            }
        }
        private void CargarSesionesDeHoy()
        {
            string consulta = "select count(*) as Total " + "from SesionesEntrenamiento " +
                "where cast(Fecha as date) = " + "cast(getdate() as date)";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                int total = Convert.ToInt32(datos.Rows[0]["Total"]);

                label11.Text = total.ToString("00");
            }
            else
            {
                label11.Text = "00";
            }
        }
        private void CargarProximaSesion()
        {
            string consulta = "select top 1 HoraInicio " + "from SesionesEntrenamiento " + "where Fecha = cast(getdate() as date) " +
                "and HoraInicio >= cast(getdate() as time) " +  "order by HoraInicio";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                TimeSpan hora = (TimeSpan)datos.Rows[0]["HoraInicio"];

                label13.Text =  "Próxima en: " + hora.ToString(@"hh\:mm");
            }
            else
            {
                label13.Text = "Sin sesiones pendientes";
            }
        }
        private void CargarEstadoDeportistas()
        {
            string consulta = "select " + "count(*) as Total, " + "isnull(sum(case " +
                "when Estado = 1 and EstadoMonitoreo = 'Activo' " + "then 1 else 0 end), 0) as Activos " +  "from Deportistas";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            int porcentaje = 0;

            if (datos != null && datos.Rows.Count > 0)
            {
                int total =  Convert.ToInt32(datos.Rows[0]["Total"]);

                int activos = Convert.ToInt32(datos.Rows[0]["Activos"]);

                if (total > 0)
                {
                    porcentaje = (activos * 100) / total;
                }
            }

            label10.Text = porcentaje.ToString() + "%";

            panel10.Width = (panel11.Width * porcentaje) / 100;

            panel10.Height = panel11.Height;
        }
        private void CargarAlertasCriticas()
        {
            flpAlertas.Controls.Clear();

            string consulta = "select Deportista, NivelFatiga as Riesgo " + "from (" + "select " +"d.Nombres + ' ' + d.Apellidos as Deportista, " + "r.NivelFatiga, " +
                              "row_number() over(" + "partition by r.IdDeportista " + "order by r.Fecha desc, r.IdReporte desc" +") as numero " + "from ReporteTecnicoSemanal r " +
                             "inner join Deportistas d " +"on r.IdDeportista = d.IdDeportista " + "where d.Estado = 1" + ") as datos " +"where numero = 1 " +"and NivelFatiga = 'Alto' " +"order by Deportista";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos == null || datos.Rows.Count == 0)
            {
                Label sinAlertas = new Label();

                sinAlertas.Text = "No hay alertas críticas";
                sinAlertas.AutoSize = true;
                sinAlertas.ForeColor = Color.Gray;
                sinAlertas.Margin = new Padding(5);

                flpAlertas.Controls.Add(sinAlertas);
                return;
            }

            foreach (DataRow fila in datos.Rows)
            {
                Panel tarjeta = new Panel();

                tarjeta.Width = flpAlertas.ClientSize.Width - 25;

                tarjeta.Height = 45;
                tarjeta.BackColor = Color.White;
                tarjeta.BorderStyle = BorderStyle.FixedSingle;

                Label nombre = new Label();

                nombre.Text =fila["Deportista"].ToString();

                nombre.Font = new Font(nombre.Font, FontStyle.Bold);

                nombre.AutoSize = true;
                nombre.Location = new Point(10, 6);

                Label riesgo = new Label();

                riesgo.Text = "RIESGO ALTO";
                riesgo.ForeColor = Color.Firebrick;
                riesgo.AutoSize = true;
                riesgo.Location = new Point(10, 24);

                tarjeta.Controls.Add(nombre);
                tarjeta.Controls.Add(riesgo);

                flpAlertas.Controls.Add(tarjeta);
            }
        }

        private void CargarEvaluacionesRecientes()
        {
            string consulta = "select top 5 " + "d.Nombres + ' ' + d.Apellidos as Deportista, " + "'Reporte semanal' as Test, " +  "concat(r.ConsistenciaRendimiento, '%') as Resultado, " +
                "case " +  "when r.NivelFatiga = 'Alto' then 'REVISAR' " + "else 'CORRECTO' end as Estado " + "from ReporteTecnicoSemanal r " + "inner join Deportistas d " +
                "on r.IdDeportista = d.IdDeportista " +  "order by r.Fecha desc, r.IdReporte desc";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            dgvEvaluaciones.DataSource = null;
            dgvEvaluaciones.Columns.Clear();
            dgvEvaluaciones.AutoGenerateColumns = true;
            dgvEvaluaciones.DataSource = datos;

            dgvEvaluaciones.AutoSizeColumnsMode =  DataGridViewAutoSizeColumnsMode.Fill;

            dgvEvaluaciones.ReadOnly = true;
            dgvEvaluaciones.AllowUserToAddRows = false;
            dgvEvaluaciones.RowHeadersVisible = false;
        }
        private void CargarProximosEventos()
        {
            flpEventos.Controls.Clear();

            string consulta = "select top 3 " + "TipoEntrenamiento, Fecha, HoraInicio " +"from SesionesEntrenamiento " +
                "where Fecha >= cast(getdate() as date) " + "order by Fecha, HoraInicio";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos == null || datos.Rows.Count == 0)
            {
                Label sinEventos = new Label();

                sinEventos.Text = "No hay eventos próximos";
                sinEventos.AutoSize = true;
                sinEventos.ForeColor = Color.Gray;
                sinEventos.Margin = new Padding(5);

                flpEventos.Controls.Add(sinEventos);
                return;
            }

            foreach (DataRow fila in datos.Rows)
            {
                DateTime fecha = Convert.ToDateTime(fila["Fecha"]);

                TimeSpan hora = (TimeSpan)fila["HoraInicio"];

                Label evento = new Label();

                evento.Text = fila["TipoEntrenamiento"].ToString() + "   " + fecha.ToString("dd/MM/yyyy") + "   " +hora.ToString(@"hh\:mm");

                evento.AutoSize = false;
                evento.Width = flpEventos.ClientSize.Width - 20;

                evento.Height = 25;
                evento.BorderStyle =BorderStyle.FixedSingle;

                evento.Padding =  new Padding(5, 3, 0, 0);

                flpEventos.Controls.Add(evento);
            }
        }
        private void CargarProgresoPlanificacion()
        {
            DateTime hoy = DateTime.Today;

            int diasDesdeLunes = ((int)hoy.DayOfWeek + 6) % 7;

            DateTime inicioSemana =  hoy.AddDays(-diasDesdeLunes);

            DateTime finSemana =inicioSemana.AddDays(7);

            string consulta = "select " +  "count(*) as Total, " +"isnull(sum(case " + "when lower(ltrim(rtrim(isnull(Estado, '')))) " +
                "= 'realizada' then 1 else 0 end), 0) " + "as Realizadas " +"from SesionesEntrenamiento " + "where Fecha >= '" +
                inicioSemana.ToString("yyyyMMdd") + "' " + "and Fecha < '" + finSemana.ToString("yyyyMMdd") + "'";

            DataTable datos =conSQL.RetornaRegistros(consulta);

            int porcentaje = 0;

            if (datos != null && datos.Rows.Count > 0)
            {
                int total = Convert.ToInt32(datos.Rows[0]["Total"]);

                int realizadas = Convert.ToInt32(datos.Rows[0]["Realizadas"]);

                if (total > 0)
                {
                    porcentaje = (realizadas * 100) / total;
                }
            }

            int semanaDelMes =  ((hoy.Day - 1) / 7) + 1;

            label17.Text ="Semana " + semanaDelMes;

            label18.Text = porcentaje.ToString() + "%";

            panel13.Width = (panel12.Width * porcentaje) / 100;

            panel13.Height = panel12.Height;
        }

        private void CargarIntensidadPercibida()
        {
            string consulta = "select top 1 NivelEsfuerzo " + "from SesionesEntrenamiento " + "where NivelEsfuerzo is not null " +
                "order by Fecha desc, HoraInicio desc, IdSesion desc";

            DataTable datos =conSQL.RetornaRegistros(consulta);

            int intensidad = 0;
            string nivel = "Sin registro";

            if (datos != null && datos.Rows.Count > 0)
            {
                intensidad = Convert.ToInt32(datos.Rows[0]["NivelEsfuerzo"]);

                intensidad = Math.Max(0, Math.Min(10, intensidad));

                if (intensidad <= 3)
                {
                    nivel = "BAJO";
                }
                else if (intensidad <= 6)
                {
                    nivel = "MODERADO";
                }
                else if (intensidad <= 8)
                {
                    nivel = "ALTO";
                }
                else
                {
                    nivel = "MUY ALTO";
                }
            }

            lblIntensidad.Text = intensidad.ToString() + "/10";

            lblNivelEsfuerzo.Text = nivel;

            pnlIntensidad.Width = (pnlIntensidadFondo.Width * intensidad) / 10;

            pnlIntensidad.Height = pnlIntensidadFondo.Height;
        }

    }
}
