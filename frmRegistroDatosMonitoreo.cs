using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace wfZenova
{
    public partial class frmRegistroDatosMonitoreo : Form
    {

        csConectaSQL conSQL = new csConectaSQL();
        int idDeportistaSeleccionado = 0;
        public frmRegistroDatosMonitoreo()
        {
            InitializeComponent();
            nudVelocidad.ValueChanged += Porcentajes_ValueChanged;
            nudResistencia.ValueChanged += Porcentajes_ValueChanged;
            nudFlexibilidad.ValueChanged += Porcentajes_ValueChanged;
            nudAgilidad.ValueChanged += Porcentajes_ValueChanged;
            nudFuerza.ValueChanged += Porcentajes_ValueChanged;


        }

        private void frmRegistroDatosMonitoreo_Load(object sender, EventArgs e)
        {

            ActualizarBarras();
            CargarDeportistas();
            MostrarDeportistas();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlMetricasAdicionales.Visible =!pnlMetricasAdicionales.Visible;

            if (pnlMetricasAdicionales.Visible)
            {
                button1.Text = "Ver menos";

                pnlMetricasAdicionales.BringToFront();
            }
            else
            {
                button1.Text = "Ver más";
            }
        }
        private void ActualizarBarras()
        {
            panel15.Width = panel14.Width * Convert.ToInt32(nudIntensidad.Value) / 100;

            panel11.Width = panel10.Width * Convert.ToInt32(nudConcentracion.Value) / 100;

            panel13.Width = panel12.Width *  Convert.ToInt32(nudRecuperacion.Value) / 100;

            panel2.Width = panel1.Width * Convert.ToInt32(nudVelocidad.Value) / 100;

            panel3.Width = panel4.Width * Convert.ToInt32(nudResistencia.Value) / 100;

            panel8.Width = panel16.Width * Convert.ToInt32(nudFlexibilidad.Value) / 100;

            panel18.Width = panel17.Width * Convert.ToInt32(nudAgilidad.Value) / 100;

            panel19.Width = panel20.Width * Convert.ToInt32(nudFuerza.Value) / 100;
        }
        private void CargarDeportistas()
        {
            string consulta = "select IdDeportista, " +  "Nombres + ' ' + Apellidos as Deportista " + "from Deportistas " +
                "where Estado = 1 " + "order by Nombres, Apellidos";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            AutoCompleteStringCollection lista =  new AutoCompleteStringCollection();

            if (datos != null)
            {
                foreach (DataRow fila in datos.Rows)
                {
                    lista.Add(fila["Deportista"].ToString());
                }
            }

            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            textBox1.AutoCompleteCustomSource = lista;
        }

        private void Porcentajes_ValueChanged(object sender, EventArgs e)
        {
            ActualizarBarras();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string deportista = textBox1.Text.Trim().Replace("'", "''");

            string consulta = "select top 1 IdDeportista, Foto " + "from Deportistas " + "where Estado = 1 " +
                "and Nombres + ' ' + Apellidos = '" + deportista + "'";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                idDeportistaSeleccionado = Convert.ToInt32(datos.Rows[0]["IdDeportista"]);

                label2.Text = "RENDIMIENTO TÉCNICO: " + textBox1.Text.Trim().ToUpper();

                if (datos.Rows[0]["Foto"] != DBNull.Value)
                {
                    byte[] foto = (byte[])datos.Rows[0]["Foto"];

                    using (MemoryStream memoria = new MemoryStream(foto))
                    {
                        using (Image imagen = Image.FromStream(memoria))
                        {
                            pbfto.Image = new Bitmap(imagen);
                        }
                    }

                    pbfto.Visible = true;
                }
                else
                {
                    pbfto.Image = null;
                    pbfto.Visible = false;
                }
            }
            else
            {
                idDeportistaSeleccionado = 0;
                pbfto.Image = null;
                pbfto.Visible = false;
            }
        
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idDeportistaSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un deportista.");
                return;
            }
            string consultaSemana =  "select count(*) " +"from ReporteTecnicoSemanal " + "where IdDeportista = @IdDeportista " +
            "and datepart(week, Fecha) = datepart(week, getdate()) " + "and year(Fecha) = year(getdate())";

            object resultado = conSQL.EjecutaEscalarParametros(consultaSemana, new SqlParameter( "@IdDeportista", idDeportistaSeleccionado) );

            if (resultado != null &&  Convert.ToInt32(resultado) > 0)
            {
                MessageBox.Show( "Este deportista ya tiene un reporte esta semana.");

                return;
            }

            decimal intensidad = nudIntensidad.Value;
            decimal concentracion = nudConcentracion.Value;
            decimal recuperacion = nudRecuperacion.Value;
            decimal velocidad = nudVelocidad.Value;
            decimal resistencia = nudResistencia.Value;
            decimal flexibilidad = nudFlexibilidad.Value;
            decimal agilidad = nudAgilidad.Value;
            decimal fuerza = nudFuerza.Value;

            if (intensidad == 0 && concentracion == 0 && recuperacion == 0 && velocidad == 0 && resistencia == 0 && flexibilidad == 0 && agilidad == 0 && fuerza == 0)
            {
                MessageBox.Show("Ingrese los porcentajes.");
                return;
            }

            decimal consistencia = Math.Round((intensidad + concentracion + recuperacion + velocidad + resistencia + flexibilidad + agilidad + fuerza) / 8, 2);

            string nivelFatiga;

            if (recuperacion >= 80)

                nivelFatiga = "Bajo";

            else if (recuperacion >= 60)

                nivelFatiga = "Moderado";

            else
                nivelFatiga = "Alto";

            string intensidadSemanal;

            if (intensidad >= 80)

                intensidadSemanal = "Alta";

            else if (intensidad >= 60)

                intensidadSemanal = "Moderada";

            else
                intensidadSemanal = "Baja";

            decimal disponibilidad = Math.Round((recuperacion + consistencia) / 2, 2);

            string consulta = "insert into ReporteTecnicoSemanal " +"(IdDeportista, Fecha, Intensidad, Concentracion, " + "Recuperacion, Velocidad, Resistencia, Flexibilidad, " +
                "Agilidad, Fuerza, ConsistenciaRendimiento, NivelFatiga, " +  "IntensidadSemanal, Disponibilidad, Observaciones) " + "values (@IdDeportista, @Fecha, @Intensidad, " + 
                "@Concentracion, @Recuperacion, @Velocidad, " +  "@Resistencia, @Flexibilidad, @Agilidad, @Fuerza, "
               + "@Consistencia, @NivelFatiga, @IntensidadSemanal, " + "@Disponibilidad, @Observaciones)";

            bool guardado = conSQL.EjecutaSentenciaParametros( consulta, new SqlParameter("@IdDeportista", idDeportistaSeleccionado), new SqlParameter("@Fecha", DateTime.Today),
              new SqlParameter("@Intensidad", intensidad), new SqlParameter("@Concentracion", concentracion), new SqlParameter("@Recuperacion", recuperacion),
              new SqlParameter("@Velocidad", velocidad), new SqlParameter("@Resistencia", resistencia),new SqlParameter("@Flexibilidad", flexibilidad),  new SqlParameter("@Agilidad", agilidad),
              new SqlParameter("@Fuerza", fuerza), new SqlParameter("@Consistencia", consistencia), new SqlParameter("@NivelFatiga", nivelFatiga),
              new SqlParameter("@IntensidadSemanal", intensidadSemanal), new SqlParameter("@Disponibilidad", disponibilidad), new SqlParameter("@Observaciones",
              txtObservaciones.Text.Trim())
            );

            if (guardado)
            {
                GenerarAlerta(nivelFatiga, disponibilidad);

                MessageBox.Show("Reporte semanal guardado correctamente.");

                nudIntensidad.Value = 0;
                nudConcentracion.Value = 0;
                nudRecuperacion.Value = 0;
                nudVelocidad.Value = 0;
                nudResistencia.Value = 0;
                nudFlexibilidad.Value = 0;
                nudAgilidad.Value = 0;
                nudFuerza.Value = 0;

                txtObservaciones.Clear();
                pnlMetricasAdicionales.Visible = false;
                button1.Text = "Ver más";
            }

        }
        private void MostrarDeportistas(string buscar = "")
        {
            flpDeportistas.Controls.Clear();

            string consulta = "select IdDeportista, Nombres, Apellidos, Foto " + "from Deportistas " + "where Estado = 1 " +
                "and (Nombres + ' ' + Apellidos) like @Buscar " + "order by Nombres, Apellidos";

            DataTable datos = conSQL.RetornaRegistrosParametros( consulta, new System.Data.SqlClient.SqlParameter("@Buscar", "%" + buscar + "%"));

            foreach (DataRow fila in datos.Rows)
            {
                int id = Convert.ToInt32(fila["IdDeportista"]);
                string nombreCompleto =fila["Nombres"].ToString() + " " + fila["Apellidos"].ToString();

                Panel tarjeta = new Panel();
                tarjeta.Size = new Size(220, 75);
                tarjeta.BackColor = Color.White;
                tarjeta.BorderStyle = BorderStyle.FixedSingle;
                tarjeta.Cursor = Cursors.Hand;

                PictureBox foto = new PictureBox();
                foto.Location = new Point(8, 8);
                foto.Size = new Size(55, 55);
                foto.SizeMode = PictureBoxSizeMode.Zoom;
                foto.Cursor = Cursors.Hand;

                if (fila["Foto"] != DBNull.Value)
                {
                    byte[] bytesFoto = (byte[])fila["Foto"];

                    using (MemoryStream memoria = new MemoryStream(bytesFoto))
                    using (Image imagen = Image.FromStream(memoria))
                    {
                        foto.Image = new Bitmap(imagen);
                    }
                }

                Label nombre = new Label();
                nombre.Text = nombreCompleto;
                nombre.Location = new Point(72, 23);
                nombre.Size = new Size(135, 35);
                nombre.AutoSize = false;
                nombre.ForeColor = Color.Black;
                nombre.BackColor = Color.White;
                nombre.TextAlign = ContentAlignment.MiddleLeft;
                nombre.Font = new Font("Century Gothic", 9, FontStyle.Bold);
                nombre.Cursor = Cursors.Hand;

                EventHandler seleccionar = (s, e) =>
                {
                    idDeportistaSeleccionado = id;
                    textBox1.Text = nombreCompleto;
                };

                tarjeta.Click += seleccionar;
                foto.Click += seleccionar;
                nombre.Click += seleccionar;

                tarjeta.Controls.Add(foto);
                tarjeta.Controls.Add(nombre);
                nombre.BringToFront();
                flpDeportistas.Controls.Add(tarjeta);
            }
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
            idDeportistaSeleccionado = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string buscar = textBox1.Text.Trim();

            if (buscar == "Buscar Atleta...")
                buscar = "";

            MostrarDeportistas(buscar);
        }
        private void GenerarAlerta(string nivelFatiga, decimal disponibilidad)
        {
            if (nivelFatiga != "Alto" && disponibilidad >= 70)
                return;

            string tipo;
            string motivo;

            if (nivelFatiga == "Alto" && disponibilidad < 70)
            {
                tipo = "Fatiga y disponibilidad";
                motivo = "Fatiga alta y disponibilidad de " + disponibilidad.ToString("0.00") + "%.";
            }
            else if (nivelFatiga == "Alto")
            {
                tipo = "Fatiga";
                motivo = "Nivel de fatiga alto.";
            }
            else
            {
                tipo = "Disponibilidad";
                motivo = "Disponibilidad baja: " + disponibilidad.ToString("0.00") + "%.";
            }
            string prioridad = nivelFatiga == "Alto" || disponibilidad < 50 ? "Alta": "Media";

            string consulta = "insert into AlertasMonitoreo " +  "(IdDeportista, Tipo, Persona, Motivo, Fecha, Prioridad, Estado) " +
                "values (@IdDeportista, @Tipo, @Persona, @Motivo, @Fecha, @Prioridad, 'Pendiente')";

            conSQL.EjecutaSentenciaParametros(consulta, new SqlParameter("@IdDeportista", idDeportistaSeleccionado),
                new SqlParameter("@Tipo", tipo),
                new SqlParameter("@Persona", textBox1.Text.Trim()),
                new SqlParameter("@Motivo", motivo),
                new SqlParameter("@Fecha", DateTime.Now),
                new SqlParameter("@Prioridad", prioridad));
        }
    }
}
