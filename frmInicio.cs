using System;
using System.Data;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmInicio : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        public frmInicio()
        {
            InitializeComponent();
        }

        private void frmInicio_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = "¡Bienvenido de vuelta, " +
                                 frmInicioDeSesion.NombreCompletoActual + "!";

            if (frmInicioDeSesion.NombreRolActual == "Entrenador" &&
                frmInicioDeSesion.IdEntrenadorActual.HasValue)
            {
                lblSubtitulo.Text = "Aquí tienes un resumen de tus deportistas y actividades.";
                CargarInicioEntrenador(frmInicioDeSesion.IdEntrenadorActual.Value);
            }
            else
            {
                lblSubtitulo.Text = "Aquí tienes un resumen general del sistema.";
                CargarInicioAdministrador();
            }
        }

        private void CargarInicioAdministrador()
        {
            lblDeportistasActivos.Text = ObtenerValor(
                "select count(*) as Total from Deportistas where Estado = 1");

            lblEntrenamientos.Text = ObtenerValor(
                "select count(*) as Total from SesionesEntrenamiento");

            lblCompetencias.Text = ObtenerValor(
                "select count(*) as Total from Competencias");

            lblRecordatorios.Text = ObtenerValor(
                @"select count(*) as Total
                from Competencias
                where FechaInicio >= cast(getdate() as date)
                and FechaInicio <= dateadd(day, 7, cast(getdate() as date))");

            CargarBienestarAdministrador();
            CargarRendimientoAdministrador();
            CargarCumplimientoAdministrador();
            CargarDeportistasRiesgoAdministrador();
        }

        private void CargarInicioEntrenador(int idEntrenador)
        {
            lblDeportistasActivos.Text = ObtenerValor(
                @"select count(distinct D.IdDeportista) as Total
                from Deportistas D
                inner join Inscripciones I
                    on D.IdDeportista = I.IdDeportista
                inner join EntrenadorDeporte ED
                    on I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte
                where D.Estado = 1
                and I.Estado = 'Activo'
                and ED.Activo = 1
                and ED.IdEntrenador = " + idEntrenador);

            lblEntrenamientos.Text = ObtenerValor(
                @"select count(*) as Total
                from SesionesEntrenamiento S
                inner join EntrenadorDeporte ED
                    on S.IdEntrenadorDeporte = ED.IdEntrenadorDeporte
                where ED.IdEntrenador = " + idEntrenador);

            lblCompetencias.Text = ObtenerValor(
                @"select count(distinct C.IdCompetencia) as Total
                from Competencias C
                inner join CompetenciaDeporte CD
                    on C.IdCompetencia = CD.IdCompetencia
                inner join EntrenadorDeporte ED
                    on CD.IdDeporte = ED.IdDeporte
                where ED.IdEntrenador = " + idEntrenador + @"
                and ED.Activo = 1");

            lblRecordatorios.Text = ObtenerValor(
                @"select count(distinct C.IdCompetencia) as Total
                from Competencias C
                inner join CompetenciaDeporte CD
                    on C.IdCompetencia = CD.IdCompetencia
                inner join EntrenadorDeporte ED
                    on CD.IdDeporte = ED.IdDeporte
                where ED.IdEntrenador = " + idEntrenador + @"
                and ED.Activo = 1
                and C.FechaInicio >= cast(getdate() as date)
                and C.FechaInicio <= dateadd(day, 7, cast(getdate() as date))");

            CargarBienestarEntrenador(idEntrenador);
            CargarRendimientoEntrenador(idEntrenador);
            CargarCumplimientoEntrenador(idEntrenador);
            CargarDeportistasRiesgoEntrenador(idEntrenador);
        }

        private void CargarBienestarAdministrador()
        {
            DataTable tabla = conSQL.RetornaRegistros(
                @"select
                count(*) as Total,
                sum(case when Riesgo = 'Alto' then 1 else 0 end) as RiesgoAlto
                from RiesgoFatiga");

            if (tabla == null || tabla.Rows.Count == 0 ||
                Convert.ToInt32(tabla.Rows[0]["Total"]) == 0)
            {
                lblBienestarPromedio.Text = "0%";
                return;
            }

            int total = Convert.ToInt32(tabla.Rows[0]["Total"]);
            int riesgoAlto = tabla.Rows[0]["RiesgoAlto"] == DBNull.Value
                ? 0
                : Convert.ToInt32(tabla.Rows[0]["RiesgoAlto"]);

            int porcentaje = (int)Math.Round(
                ((double)(total - riesgoAlto) / total) * 100);

            lblBienestarPromedio.Text = porcentaje + "%";
        }

        private void CargarBienestarEntrenador(int idEntrenador)
        {
            DataTable tabla = conSQL.RetornaRegistros(
                @"select
                count(*) as Total,
                sum(case when R.Riesgo = 'Alto' then 1 else 0 end) as RiesgoAlto
                from RiesgoFatiga R
                inner join Deportistas D
                    on R.idDeportista = D.IdDeportista
                where exists
                (
                    select 1
                    from Inscripciones I
                    inner join EntrenadorDeporte ED
                        on I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte
                    where I.IdDeportista = D.IdDeportista
                    and I.Estado = 'Activo'
                    and ED.Activo = 1
                    and ED.IdEntrenador = " + idEntrenador + @"
                )");

            if (tabla == null || tabla.Rows.Count == 0 ||
                Convert.ToInt32(tabla.Rows[0]["Total"]) == 0)
            {
                lblBienestarPromedio.Text = "0%";
                return;
            }

            int total = Convert.ToInt32(tabla.Rows[0]["Total"]);
            int riesgoAlto = tabla.Rows[0]["RiesgoAlto"] == DBNull.Value
                ? 0
                : Convert.ToInt32(tabla.Rows[0]["RiesgoAlto"]);

            int porcentaje = (int)Math.Round(
                ((double)(total - riesgoAlto) / total) * 100);

            lblBienestarPromedio.Text = porcentaje + "%";
        }

        private void CargarRendimientoAdministrador()
        {
            DataTable tabla = conSQL.RetornaRegistros(
                @"select
                count(*) as Total,
                sum(case when Rendimiento is not null
                    and Rendimiento <> '' then 1 else 0 end) as Evaluados
                from PruebasFisicas");

            lblRendimientoGeneral.Text = CalcularPorcentaje(tabla);
        }

        private void CargarRendimientoEntrenador(int idEntrenador)
        {
            DataTable tabla = conSQL.RetornaRegistros(
                @"select
                count(*) as Total,
                sum(case when P.Rendimiento is not null
                    and P.Rendimiento <> '' then 1 else 0 end) as Evaluados
                from PruebasFisicas P
                where P.IdEntrenador = " + idEntrenador);

            lblRendimientoGeneral.Text = CalcularPorcentaje(tabla);
        }

        private void CargarCumplimientoAdministrador()
        {
            DataTable tabla = conSQL.RetornaRegistros(
                @"select
                count(*) as Total,
                sum(case when Estado = 'Completado'
                    or Estado = 'Finalizado'
                    or Estado = 'Realizado'
                    then 1 else 0 end) as Cumplidos
                from SesionesEntrenamiento");

            lblCumplimientoEntrenamientos.Text = CalcularPorcentaje(tabla);
        }

        private void CargarCumplimientoEntrenador(int idEntrenador)
        {
            DataTable tabla = conSQL.RetornaRegistros(
                @"select
                count(*) as Total,
                sum(case when S.Estado = 'Completado'
                    or S.Estado = 'Finalizado'
                    or S.Estado = 'Realizado'
                    then 1 else 0 end) as Cumplidos
                from SesionesEntrenamiento S
                inner join EntrenadorDeporte ED
                    on S.IdEntrenadorDeporte = ED.IdEntrenadorDeporte
                where ED.IdEntrenador = " + idEntrenador);

            lblCumplimientoEntrenamientos.Text = CalcularPorcentaje(tabla);
        }

        private void CargarDeportistasRiesgoAdministrador()
        {
            lblDeportistasRiesgo.Text = ObtenerValor(
                @"select count(distinct idDeportista) as Total
                from RiesgoFatiga
                where Riesgo = 'Alto'");
        }

        private void CargarDeportistasRiesgoEntrenador(int idEntrenador)
        {
            lblDeportistasRiesgo.Text = ObtenerValor(
                @"select count(distinct R.idDeportista) as Total
                from RiesgoFatiga R
                inner join Deportistas D
                    on R.idDeportista = D.IdDeportista
                where R.Riesgo = 'Alto'
                and exists
                (
                    select 1
                    from Inscripciones I
                    inner join EntrenadorDeporte ED
                        on I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte
                    where I.IdDeportista = D.IdDeportista
                    and I.Estado = 'Activo'
                    and ED.Activo = 1
                    and ED.IdEntrenador = " + idEntrenador + @"
                )");
        }

        private string ObtenerValor(string consulta)
        {
            DataTable tabla = conSQL.RetornaRegistros(consulta);

            if (tabla == null ||
                tabla.Rows.Count == 0 ||
                tabla.Rows[0]["Total"] == DBNull.Value)
                return "0";

            return tabla.Rows[0]["Total"].ToString();
        }

        private string CalcularPorcentaje(DataTable tabla)
        {
            if (tabla == null || tabla.Rows.Count == 0)
                return "0%";

            int total = tabla.Rows[0]["Total"] == DBNull.Value
                ? 0
                : Convert.ToInt32(tabla.Rows[0]["Total"]);

            if (total == 0)
                return "0%";

            string columna = tabla.Columns[1].ColumnName;

            int cantidad = tabla.Rows[0][columna] == DBNull.Value
                ? 0
                : Convert.ToInt32(tabla.Rows[0][columna]);

            int porcentaje = (int)Math.Round(
                ((double)cantidad / total) * 100);

            return porcentaje + "%";
        }
    }
}