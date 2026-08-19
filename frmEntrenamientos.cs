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
    public partial class frmEntrenamientos : Form
    {
        public frmEntrenamientos()
        {
            InitializeComponent();
            CargarMetricasDelMes();
        }

        private void CargarMetricasDelMes()
        {
            csConectaSQL conexion = new csConectaSQL();

            string query = @"
        SELECT 
            (SELECT COUNT(*) FROM SesionesEntrenamiento WHERE MONTH(Fecha) = MONTH(GETDATE()) AND YEAR(Fecha) = YEAR(GETDATE())) AS TotalEntrenamientos,
            (SELECT COUNT(*) FROM PruebasFisicas WHERE MONTH(Fecha) = MONTH(GETDATE()) AND YEAR(Fecha) = YEAR(GETDATE())) AS TotalPruebas,
            ISNULL((SELECT AVG(CAST(RPE AS FLOAT)) FROM PruebasFisicas WHERE MONTH(Fecha) = MONTH(GETDATE()) AND YEAR(Fecha) = YEAR(GETDATE())), 0) AS PromedioRPE;";

            DataTable dt = conexion.RetornaRegistros(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow fila = dt.Rows[0];

                label5.Text = fila["TotalEntrenamientos"].ToString();
                label6.Text = fila["TotalPruebas"].ToString();

                double promedioRPE = Convert.ToDouble(fila["PromedioRPE"]);
                label7.Text = $"{promedioRPE:0.0} RPE"; 
            }
        }

        private void btnContEntrenamiento_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmSubEntrenamientos frmSubCompetencia = new frmSubEntrenamientos();

            frmSubCompetencia.TopLevel = false;
            frmSubCompetencia.FormBorderStyle = FormBorderStyle.None;
            frmSubCompetencia.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmSubCompetencia);

            frmSubCompetencia.Show();

            this.Close();
        }

        private void btnPruebas_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmPruebasFisicas frmSubCompetencia = new frmPruebasFisicas();

            frmSubCompetencia.TopLevel = false;
            frmSubCompetencia.FormBorderStyle = FormBorderStyle.None;
            frmSubCompetencia.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmSubCompetencia);

            frmSubCompetencia.Show();

            this.Close();
        }
    }
}
