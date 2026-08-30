using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            cmbTipoReporte.Items.Add("Deportistas");
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
                     "D.Cedula, D.FechaNacimiento, D.Genero, " +
                     "DEP.NombreDeporte as Deporte, " +
                     "EN.Nombres + ' ' + EN.Apellidos as Entrenador, " +
                     "D.FechaRegistro, " +
                     "case when D.Estado = 1 then 'Activo' else 'Inactivo' end as Estado " +
                     "from Deportistas D " +
                     "inner join Inscripciones I on D.IdDeportista = I.IdDeportista " +
                     "inner join EntrenadorDeporte ED on I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte " +
                     "inner join Deportes DEP on ED.IdDeporte = DEP.IdDeporte " +
                     "inner join Entrenadores EN on ED.IdEntrenador = EN.IdEntrenador " +
                     "where I.Estado = 'Activo'";

            dt = oConSQL.RetornaRegistros(cadena);

            dataset = new ReportDataSource("DsDeportistas", dt);

            rvwReporte.LocalReport.DataSources.Add(dataset);
            rvwReporte.LocalReport.Refresh();

            rvwReporte.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cmbTipoReporte.Text == "Deportistas")
            {
                CargarReporteDeportistas();
            }
        }
    }
}
