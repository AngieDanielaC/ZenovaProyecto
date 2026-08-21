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
    public partial class frmGestionTecnica : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        private int idDeportistaSeleccionado = 0;

        public frmGestionTecnica()
        {
            InitializeComponent();
            textBox1.KeyDown += textBox1_KeyDown;
   
            textBox1.Enter += textBox1_Enter;

            textBox1.Leave += textBox1_Leave;
        }

        private void frmGestionTecnica_Load(object sender, EventArgs e)
        {
            ConfigurarBuscador();
        
        }
        private void ConfigurarBuscador()
        {
            string consulta = "select IdDeportista, " + "Nombres + ' ' + Apellidos as Deportista " +"from Deportistas " +
                "where Estado = 1 " + "order by Nombres, Apellidos";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            AutoCompleteStringCollection nombres = new AutoCompleteStringCollection();

            if (datos != null)
            {
                foreach (DataRow fila in datos.Rows)
                {
                    nombres.Add( fila["Deportista"].ToString());
                }
            }

            textBox1.AutoCompleteMode =  AutoCompleteMode.SuggestAppend;

            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            textBox1.AutoCompleteCustomSource = nombres;
        }
        private void BuscarDeportista()
        {
            string nombre = textBox1.Text.Trim().Replace("'", "''");

            string consulta = "select top 1 " + "IdDeportista, " + "Nombres + ' ' + Apellidos as Deportista " +
                "from Deportistas " + "where Estado = 1 " + "and Nombres + ' ' + Apellidos = N'" + nombre + "'";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                idDeportistaSeleccionado = Convert.ToInt32( datos.Rows[0]["IdDeportista"]);

                label23.Text = datos.Rows[0]["Deportista"].ToString();
                CargarReporteTecnico();
            }
            else
            {
                idDeportistaSeleccionado = 0;

                MessageBox.Show( "Seleccione un deportista de la lista.");
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarDeportista();
                e.SuppressKeyPress = true;
            }
        }
        private void AjustarBarra(Panel fondo, Panel barra,decimal porcentaje)
        {
            porcentaje =Math.Max(0, Math.Min(100, porcentaje));

            barra.Width = Convert.ToInt32(fondo.Width * porcentaje / 100);

            barra.Height = fondo.Height;
        }
        private void CargarReporteTecnico()
        {
            if (idDeportistaSeleccionado == 0)
            {
                return;
            }

            string consulta = "select top 2 * " + "from ReporteTecnicoSemanal " + "where IdDeportista = " + idDeportistaSeleccionado +
                " order by Fecha desc, IdReporte desc";

            DataTable datos =conSQL.RetornaRegistros(consulta);

            if (datos == null || datos.Rows.Count == 0)
            {
                LimpiarReporteTecnico();

                MessageBox.Show("El deportista no tiene un reporte técnico.");

                return;
            }

            DataRow fila = datos.Rows[0];

            decimal intensidad = Convert.ToDecimal(fila["Intensidad"]);

            decimal concentracion = Convert.ToDecimal(fila["Concentracion"]);

            decimal recuperacion =Convert.ToDecimal(fila["Recuperacion"]);

            decimal velocidad = Convert.ToDecimal(fila["Velocidad"]);

            decimal resistencia = Convert.ToDecimal(fila["Resistencia"]);

            decimal flexibilidad =  Convert.ToDecimal(fila["Flexibilidad"]);

            decimal agilidad = Convert.ToDecimal(fila["Agilidad"]);

            decimal fuerza = Convert.ToDecimal(fila["Fuerza"]);

            decimal consistencia = Convert.ToDecimal( fila["ConsistenciaRendimiento"]);

            decimal disponibilidad =Convert.ToDecimal(fila["Disponibilidad"]);

            label9.Text = intensidad.ToString("0") + "%";
            label17.Text = concentracion.ToString("0") + "%";
            label18.Text = recuperacion.ToString("0") + "%";
            label19.Text = velocidad.ToString("0") + "%";
            label20.Text = resistencia.ToString("0") + "%";
            label21.Text = flexibilidad.ToString("0") + "%";
            label22.Text = agilidad.ToString("0") + "%";
            label24.Text = fuerza.ToString("0") + "%";

            AjustarBarra(panel14, panel15, intensidad);
            AjustarBarra(panel16, panel17, concentracion);
            AjustarBarra(panel18, panel19, recuperacion);
            AjustarBarra(panel20, panel21, velocidad);
            AjustarBarra(panel22, panel23, resistencia);
            AjustarBarra(panel24, panel25, flexibilidad);
            AjustarBarra(panel26, panel27, agilidad);
            AjustarBarra(panel28, panel29, fuerza);

            decimal rendimiento =(intensidad + concentracion +  recuperacion + velocidad + resistencia +
                    flexibilidad + agilidad + fuerza ) / 8;

            MostrarComparacion(datos, rendimiento);

            label26.Text =rendimiento.ToString("0.0") + "%";

            label27.Text =consistencia.ToString("0") + "%";

            label32.Text = recuperacion.ToString("0") + "%";

            label33.Text = fila["NivelFatiga"].ToString().ToUpper();

            label34.Text =fila["IntensidadSemanal"].ToString().ToUpper();

            label35.Text = disponibilidad.ToString("0") + "%";
            DateTime fechaReporte = Convert.ToDateTime(fila["Fecha"]);

            label3.Text = "Sin reporte anterior para comparar";

            label4.Text = "Último reporte: " + fechaReporte.ToString("dd/MM/yyyy");

            label5.Text = fila["Observaciones"].ToString();

            label5.MaximumSize = new Size(320, 0);

            if (rendimiento >= 80)
            {
                label25.Text = "RENDIMIENTO ÓPTIMO";
            }
            else if (rendimiento >= 60)
            {
                label25.Text = "RENDIMIENTO BUENO";
            }
            else
            {
                label25.Text = "RENDIMIENTO POR MEJORAR";
            }
        }
        private void LimpiarReporteTecnico()
        {
            label9.Text = "0%";
            label17.Text = "0%";
            label18.Text = "0%";
            label19.Text = "0%";
            label20.Text = "0%";
            label21.Text = "0%";
            label22.Text = "0%";
            label24.Text = "0%";

            AjustarBarra(panel14, panel15, 0);
            AjustarBarra(panel16, panel17, 0);
            AjustarBarra(panel18, panel19, 0);
            AjustarBarra(panel20, panel21, 0);
            AjustarBarra(panel22, panel23, 0);
            AjustarBarra(panel24, panel25, 0);
            AjustarBarra(panel26, panel27, 0);
            AjustarBarra(panel28, panel29, 0);

            label25.Text = "SIN REPORTE";
            label26.Text = "0%";
            label27.Text = "0%";
            label32.Text = "0%";
            label33.Text = "SIN REGISTRO";
            label34.Text = "SIN REGISTRO";
            label35.Text = "0%";

            label3.Text = "Sin reporte anterior para comparar";

            label4.Text = "Sin registros";
            label5.Text = "Sin observaciones";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Buscar Atleta...")
            {
                textBox1.Clear();
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Buscar Atleta...";

                textBox1.ForeColor =
                    Color.FromArgb(168, 34, 29);
            }
        }
        private decimal CalcularRendimiento( DataRow fila)
        {
            decimal suma =
                Convert.ToDecimal(fila["Intensidad"]) +
                Convert.ToDecimal(fila["Concentracion"]) +
                Convert.ToDecimal(fila["Recuperacion"]) +
                Convert.ToDecimal(fila["Velocidad"]) +
                Convert.ToDecimal(fila["Resistencia"]) +
                Convert.ToDecimal(fila["Flexibilidad"]) +
                Convert.ToDecimal(fila["Agilidad"]) +
                Convert.ToDecimal(fila["Fuerza"]);

            return suma / 8;

        }
        private void MostrarComparacion( DataTable datos,decimal rendimientoActual)
        {
            if (datos.Rows.Count < 2)
            {
                label3.Text = "Sin reporte anterior para comparar";

                return;
            }

            decimal rendimientoAnterior = CalcularRendimiento(datos.Rows[1]);

            decimal diferencia = rendimientoActual - rendimientoAnterior;

            if (diferencia > 0)
            {
                label3.Text = "Mejoró " + diferencia.ToString("0.0") + " puntos";
            }
            else if (diferencia < 0)
            {
                label3.Text =  "Disminuyó " + Math.Abs(diferencia).ToString("0.0") +" puntos";
            }
            else
            {
                label3.Text = "Se mantiene igual";
            }
        }
    }
    
}
