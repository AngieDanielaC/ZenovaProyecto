using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace wfZenova
{
    public partial class frmReportes : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        string cadena;

        public frmReportes()
        {
            InitializeComponent();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            cmbTipoReporte.Items.Clear();

            if (frmInicioDeSesion.NombreRolActual == "Administrador")
            {
                cmbTipoReporte.Items.Add("Deportistas");
                cmbTipoReporte.Items.Add("Inscripciones");
                cmbTipoReporte.Items.Add("Entrenadores");
                cmbTipoReporte.Items.Add("Asignación Entrenadores");
                cmbTipoReporte.Items.Add("Competencias");
                cmbTipoReporte.Items.Add("Participantes Competencia");
                cmbTipoReporte.Items.Add("Resultados Competencias");
                cmbTipoReporte.Items.Add("Entrenamientos");
                cmbTipoReporte.Items.Add("Pruebas Físicas");
                cmbTipoReporte.Items.Add("Mediciones Corporales");
                cmbTipoReporte.Items.Add("Bienestar");
                cmbTipoReporte.Items.Add("Empleados");
            }
            else if (frmInicioDeSesion.NombreRolActual == "Secretaria")
            {
                cmbTipoReporte.Items.Add("Deportistas");
                cmbTipoReporte.Items.Add("Inscripciones");
                cmbTipoReporte.Items.Add("Entrenadores");
                cmbTipoReporte.Items.Add("Empleados");
            }
            else if (frmInicioDeSesion.NombreRolActual == "Coordinador de Competencias")
            {
                cmbTipoReporte.Items.Add("Competencias");
                cmbTipoReporte.Items.Add("Participantes Competencia");
                cmbTipoReporte.Items.Add("Resultados Competencias");
            }
            else if (frmInicioDeSesion.NombreRolActual == "Entrenador")
            {
                cmbTipoReporte.Items.Add("Entrenamientos");
                cmbTipoReporte.Items.Add("Pruebas Físicas");
                cmbTipoReporte.Items.Add("Mediciones Corporales");
                cmbTipoReporte.Items.Add("Bienestar");
            }

            if (cmbTipoReporte.Items.Count > 0)
                cmbTipoReporte.SelectedIndex = 0;
        }

        private void CargarReporteDeportistas()
        {
            csConectaSQL oConSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset;

            rvwReporte.LocalReport.DataSources.Clear();

            rvwReporte.LocalReport.ReportEmbeddedResource =
                "wfZenova.rptDeportistas.rdlc";

            cadena = "select D.Nombres + ' ' + D.Apellidos as NombreCompleto, " +
                     "D.Cedula, D.FechaNacimiento, D.Genero, D.Telefono, D.Correo, " +
                     "case when D.Estado = 1 then 'Activo' else 'Inactivo' end as Estado " +
                     "from Deportistas D " +
                     "order by D.Nombres, D.Apellidos";

            dt = oConSQL.RetornaRegistros(cadena);

            dataset = new ReportDataSource("dsDeportistas", dt);

            rvwReporte.LocalReport.DataSources.Add(dataset);
            rvwReporte.LocalReport.Refresh();
            rvwReporte.RefreshReport();
        }

        private void CargarReporteInscripciones()
        {
            csConectaSQL oConSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset;

            rvwReporte.LocalReport.DataSources.Clear();

            rvwReporte.LocalReport.ReportEmbeddedResource =
                "wfZenova.rptInscripciones.rdlc";

            cadena = "select D.Nombres + ' ' + D.Apellidos as Deportista, " +
                     "DEP.NombreDeporte as Deporte, " +
                     "E.Nombres + ' ' + E.Apellidos as Entrenador, " +
                     "I.FechaInicio as FechaInscripcion, " +
                     "I.Estado " +
                     "from Inscripciones I " +
                     "inner join Deportistas D on I.IdDeportista = D.IdDeportista " +
                     "inner join EntrenadorDeporte ED on I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte " +
                     "inner join Deportes DEP on ED.IdDeporte = DEP.IdDeporte " +
                     "inner join Entrenadores E on ED.IdEntrenador = E.IdEntrenador";

            dt = oConSQL.RetornaRegistros(cadena);

            dataset = new ReportDataSource("dsIncripciones", dt);

            rvwReporte.LocalReport.DataSources.Add(dataset);
            rvwReporte.LocalReport.Refresh();
            rvwReporte.RefreshReport();
        }

        private void CargarReporteEntrenadores()
        {
            csConectaSQL oConSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset;

            rvwReporte.LocalReport.DataSources.Clear();

            rvwReporte.LocalReport.ReportEmbeddedResource =
                "wfZenova.rptEntrenadores.rdlc";

            cadena = "select E.Nombres + ' ' + E.Apellidos as NombreCompleto, " +
                     "E.Cedula, E.FechaNacimiento, E.Genero, E.Telefono, E.Correo, " +
                     "E.EstadoEntrenador as Estado " +
                     "from Entrenadores E " +
                     "order by E.Nombres, E.Apellidos";

            dt = oConSQL.RetornaRegistros(cadena);

            dataset = new ReportDataSource("dsEntrenadores", dt);

            rvwReporte.LocalReport.DataSources.Add(dataset);
            rvwReporte.LocalReport.Refresh();
            rvwReporte.RefreshReport();
        }

        private void CargarReporteAsignacionesEntrenadores()
        {
            csConectaSQL oConSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset;

            rvwReporte.LocalReport.DataSources.Clear();

            rvwReporte.LocalReport.ReportEmbeddedResource =
                "wfZenova.rptAsignacionesEntrenadores.rdlc";

            cadena = "select E.Nombres + ' ' + E.Apellidos as Entrenador, " +
                     "D.NombreDeporte as Deporte, " +
                     "count(I.IdDeportista) as DeportistasAsignados, " +
                     "case when ED.Activo = 1 then 'Activo' else 'Inactivo' end as Estado " +
                     "from Entrenadores E " +
                     "inner join EntrenadorDeporte ED on E.IdEntrenador = ED.IdEntrenador " +
                     "inner join Deportes D on ED.IdDeporte = D.IdDeporte " +
                     "left join Inscripciones I on ED.IdEntrenadorDeporte = I.IdEntrenadorDeporte " +
                     "group by E.Nombres, E.Apellidos, D.NombreDeporte, ED.Activo";

            dt = oConSQL.RetornaRegistros(cadena);

            dataset = new ReportDataSource("dsAsignacionesEntrenadores", dt);

            rvwReporte.LocalReport.DataSources.Add(dataset);
            rvwReporte.LocalReport.Refresh();
            rvwReporte.RefreshReport();
        }

        private void CargarReporteCompetencias()
        {
            csConectaSQL oConSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset;

            rvwReporte.LocalReport.DataSources.Clear();

            rvwReporte.LocalReport.ReportEmbeddedResource =
                "wfZenova.rptCompetencias.rdlc";

            cadena = "select C.NombreCompetencia as Competencia, " +
                     "C.Organizador, C.Lugar, C.Nivel, " +
                     "C.FechaInicio, C.FechaFin, " +
                     "case " +
                     "when getdate() < C.FechaInicio then 'Próxima' " +
                     "when getdate() between C.FechaInicio and C.FechaFin then 'En curso' " +
                     "else 'Finalizada' end as Estado " +
                     "from Competencias C " +
                     "order by C.FechaInicio desc";

            dt = oConSQL.RetornaRegistros(cadena);

            dataset = new ReportDataSource("dsCompetencias", dt);

            rvwReporte.LocalReport.DataSources.Add(dataset);
            rvwReporte.LocalReport.Refresh();
            rvwReporte.RefreshReport();
        }

        private void CargarReporteParticipantes()
        {
            csConectaSQL oConSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset;

            rvwReporte.LocalReport.DataSources.Clear();

            rvwReporte.LocalReport.ReportEmbeddedResource =
                "wfZenova.rptParticipantes.rdlc";

            cadena = "select D.Nombres + ' ' + D.Apellidos as Deportista, " +
                     "C.NombreCompetencia as Competencia, " +
                     "DEP.NombreDeporte as Deporte, " +
                     "P.FechaInscripcion, " +
                     "P.EstadoParticipacion as Estado " +
                     "from ParticipantesCompetencia P " +
                     "inner join Deportistas D on P.IdDeportista = D.IdDeportista " +
                     "inner join CompetenciaDeporte CD on P.IdCompetenciaDeporte = CD.IdCompetenciaDeporte " +
                     "inner join Competencias C on CD.IdCompetencia = C.IdCompetencia " +
                     "inner join Deportes DEP on CD.IdDeporte = DEP.IdDeporte " +
                     "order by C.NombreCompetencia, D.Nombres";

            dt = oConSQL.RetornaRegistros(cadena);

            dataset = new ReportDataSource("dsParticipantes", dt);

            rvwReporte.LocalReport.DataSources.Add(dataset);
            rvwReporte.LocalReport.Refresh();
            rvwReporte.RefreshReport();
        }

        private void CargarReporteResultados()
        {
            csConectaSQL oConSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset;

            rvwReporte.LocalReport.DataSources.Clear();

            rvwReporte.LocalReport.ReportEmbeddedResource =
                "wfZenova.rptResultados.rdlc";

            cadena = "select D.Nombres + ' ' + D.Apellidos as Deportista, " +
                     "C.NombreCompetencia as Competencia, " +
                     "DEP.NombreDeporte as Deporte, " +
                     "R.Prueba as Resultado, " +
                     "R.PuestoObtenido as Posicion " +
                     "from ResultadosCompetencia R " +
                     "inner join ParticipantesCompetencia P on R.IdParticipanteCompetencia = P.IdParticipanteCompetencia " +
                     "inner join Deportistas D on P.IdDeportista = D.IdDeportista " +
                     "inner join CompetenciaDeporte CD on P.IdCompetenciaDeporte = CD.IdCompetenciaDeporte " +
                     "inner join Competencias C on CD.IdCompetencia = C.IdCompetencia " +
                     "inner join Deportes DEP on CD.IdDeporte = DEP.IdDeporte " +
                     "order by C.NombreCompetencia, D.Nombres";

            dt = oConSQL.RetornaRegistros(cadena);

            dataset = new ReportDataSource("dsResultados", dt);

            rvwReporte.LocalReport.DataSources.Add(dataset);
            rvwReporte.LocalReport.Refresh();
            rvwReporte.RefreshReport();
        }

        private void CargarReporteEntrenamientos()
        {
            csConectaSQL oConSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset;

            rvwReporte.LocalReport.DataSources.Clear();

            rvwReporte.LocalReport.ReportEmbeddedResource =
                "wfZenova.rptEntrenamientos.rdlc";

            cadena = "select D.Nombres + ' ' + D.Apellidos as Deportista, " +
                     "DEP.NombreDeporte as Deporte, " +
                     "S.Fecha, S.Duracion, S.TipoEntrenamiento, S.Objetivo, S.Estado " +
                     "from SesionesEntrenamiento S " +
                     "inner join Deportistas D on S.IdDeportista = D.IdDeportista " +
                     "inner join EntrenadorDeporte ED on S.IdEntrenadorDeporte = ED.IdEntrenadorDeporte " +
                     "inner join Deportes DEP on ED.IdDeporte = DEP.IdDeporte ";

            if (frmInicioDeSesion.NombreRolActual == "Entrenador" &&
                frmInicioDeSesion.IdEntrenadorActual.HasValue)
            {
                cadena += "where ED.IdEntrenador = " +
                          frmInicioDeSesion.IdEntrenadorActual.Value + " ";
            }

            cadena += "order by S.Fecha desc";

            dt = oConSQL.RetornaRegistros(cadena);

            dataset = new ReportDataSource("dsEntrenamientos", dt);

            rvwReporte.LocalReport.DataSources.Add(dataset);
            rvwReporte.LocalReport.Refresh();
            rvwReporte.RefreshReport();
        }

        private void CargarReportePruebasFisicas()
        {
            csConectaSQL oConSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset;

            rvwReporte.LocalReport.DataSources.Clear();

            rvwReporte.LocalReport.ReportEmbeddedResource =
                "wfZenova.rptPruebasFisicas.rdlc";

            cadena = "select D.Nombres + ' ' + D.Apellidos as Deportista, " +
                     "P.Fecha, P.TipoPrueba, P.PruebaRealizada, P.Duracion, P.RPE, P.Rendimiento " +
                     "from PruebasFisicas P " +
                     "inner join Deportistas D on P.IdDeportista = D.IdDeportista ";

            if (frmInicioDeSesion.NombreRolActual == "Entrenador" &&
                frmInicioDeSesion.IdEntrenadorActual.HasValue)
            {
                cadena += "inner join Inscripciones I on D.IdDeportista = I.IdDeportista " +
                          "inner join EntrenadorDeporte ED on I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte " +
                          "where ED.IdEntrenador = " +
                          frmInicioDeSesion.IdEntrenadorActual.Value + " " +
                          "and I.Estado = 'Activo' " +
                          "and ED.Activo = 1 ";
            }

            cadena += "order by P.Fecha desc";

            dt = oConSQL.RetornaRegistros(cadena);

            dataset = new ReportDataSource("dsPruebasFisicas", dt);

            rvwReporte.LocalReport.DataSources.Add(dataset);
            rvwReporte.LocalReport.Refresh();
            rvwReporte.RefreshReport();
        }

        private void CargarReporteMediciones()
        {
            csConectaSQL oConSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset;

            rvwReporte.LocalReport.DataSources.Clear();

            rvwReporte.LocalReport.ReportEmbeddedResource =
                "wfZenova.rptMediciones.rdlc";

            cadena = "select D.Nombres + ' ' + D.Apellidos as Deportista, " +
                     "M.FechaMedicion, M.Peso, M.Altura, M.CategoriaEdad " +
                     "from MedicionesDeportista M " +
                     "inner join Deportistas D on M.IdDeportista = D.IdDeportista ";

            if (frmInicioDeSesion.NombreRolActual == "Entrenador" &&
                frmInicioDeSesion.IdEntrenadorActual.HasValue)
            {
                cadena += "inner join Inscripciones I on D.IdDeportista = I.IdDeportista " +
                          "inner join EntrenadorDeporte ED on I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte " +
                          "where ED.IdEntrenador = " +
                          frmInicioDeSesion.IdEntrenadorActual.Value + " " +
                          "and I.Estado = 'Activo' " +
                          "and ED.Activo = 1 ";
            }

            cadena += "order by M.FechaMedicion desc";

            dt = oConSQL.RetornaRegistros(cadena);

            dataset = new ReportDataSource("dsMediciones", dt);

            rvwReporte.LocalReport.DataSources.Add(dataset);
            rvwReporte.LocalReport.Refresh();
            rvwReporte.RefreshReport();
        }

        private void CargarReporteBienestar()
        {
            csConectaSQL oConSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset;

            rvwReporte.LocalReport.DataSources.Clear();

            rvwReporte.LocalReport.ReportEmbeddedResource =
                "wfZenova.rptBienestar.rdlc";

            cadena = "select D.Nombres + ' ' + D.Apellidos as Deportista, " +
                     "isnull(cast(G.GastoCal as varchar), 'Sin registro') as GastoCalorico, " +
                     "isnull(R.Riesgo, 'Sin evaluar') as RiesgoLesion, " +
                     "isnull(cast(R.horas_de_sueño as varchar), 'Sin registro') as HorasSueno, " +
                     "(select top 1 M.Peso from MedicionesDeportista M " +
                     "where M.IdDeportista = D.IdDeportista " +
                     "order by M.FechaMedicion desc) as Peso " +
                     "from Deportistas D " +
                     "left join GastoCalorico G on D.IdDeportista = G.IdDeportista " +
                     "left join RiesgoFatiga R on D.IdDeportista = R.IdDeportista ";

            if (frmInicioDeSesion.NombreRolActual == "Entrenador" &&
                frmInicioDeSesion.IdEntrenadorActual.HasValue)
            {
                cadena += "inner join Inscripciones I on D.IdDeportista = I.IdDeportista " +
                          "inner join EntrenadorDeporte ED on I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte " +
                          "where D.Estado = 1 " +
                          "and ED.IdEntrenador = " +
                          frmInicioDeSesion.IdEntrenadorActual.Value + " " +
                          "and I.Estado = 'Activo' " +
                          "and ED.Activo = 1 ";
            }
            else
            {
                cadena += "where D.Estado = 1 ";
            }

            cadena += "order by D.Nombres, D.Apellidos";

            dt = oConSQL.RetornaRegistros(cadena);

            dataset = new ReportDataSource("dsBienestar", dt);

            rvwReporte.LocalReport.DataSources.Add(dataset);
            rvwReporte.LocalReport.Refresh();
            rvwReporte.RefreshReport();
        }

        private void CargarReporteEmpleados()
        {
            csConectaSQL oConSQL = new csConectaSQL();
            DataTable dt = new DataTable();
            ReportDataSource dataset;

            rvwReporte.LocalReport.DataSources.Clear();

            rvwReporte.LocalReport.ReportEmbeddedResource =
                "wfZenova.rptEmpleados.rdlc";

            cadena = "select E.Nombres + ' ' + E.Apellidos as Empleado, " +
                     "E.Cedula, E.Genero, E.Telefono, E.Correo, " +
                     "R.NombreRol as Rol, " +
                     "case when E.Estado = 1 then 'Activo' else 'Inactivo' end as Estado " +
                     "from Empleados E " +
                     "inner join Usuarios U on E.IdEmpleado = U.IdEmpleado " +
                     "inner join Roles R on U.IdRol = R.IdRol " +
                     "order by E.Nombres, E.Apellidos";

            dt = oConSQL.RetornaRegistros(cadena);

            dataset = new ReportDataSource("dsEmpleados", dt);

            rvwReporte.LocalReport.DataSources.Add(dataset);
            rvwReporte.LocalReport.Refresh();
            rvwReporte.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cmbTipoReporte.Text == "Deportistas")
                CargarReporteDeportistas();

            if (cmbTipoReporte.Text == "Inscripciones")
                CargarReporteInscripciones();

            if (cmbTipoReporte.Text == "Entrenadores")
                CargarReporteEntrenadores();

            if (cmbTipoReporte.Text == "Asignación Entrenadores")
                CargarReporteAsignacionesEntrenadores();

            if (cmbTipoReporte.Text == "Competencias")
                CargarReporteCompetencias();

            if (cmbTipoReporte.Text == "Participantes Competencia")
                CargarReporteParticipantes();

            if (cmbTipoReporte.Text == "Resultados Competencias")
                CargarReporteResultados();

            if (cmbTipoReporte.Text == "Entrenamientos")
                CargarReporteEntrenamientos();

            if (cmbTipoReporte.Text == "Pruebas Físicas")
                CargarReportePruebasFisicas();

            if (cmbTipoReporte.Text == "Mediciones Corporales")
                CargarReporteMediciones();

            if (cmbTipoReporte.Text == "Bienestar")
                CargarReporteBienestar();

            if (cmbTipoReporte.Text == "Empleados")
                CargarReporteEmpleados();
        }
    }
}