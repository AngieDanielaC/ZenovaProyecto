using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmPruebasFisicas : Form
    {
        private csConectaSQL bd = new csConectaSQL();

        public frmPruebasFisicas()
        {
            InitializeComponent();
            // Nota: la suscripción a Load ya se hace en el Designer (this.Load += ...frmPruebasFisicas_Load).
            // Se elimina la duplicada que había aquí para evitar que el evento se dispare dos veces.
            this.button4.Click += new EventHandler(button4_Click);
            this.button5.Click += new EventHandler(button5_Click);
            this.radioButton11.CheckedChanged += new EventHandler(RadioButtonDolor_CheckedChanged);
            this.radioButton12.CheckedChanged += new EventHandler(RadioButtonDolor_CheckedChanged);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmEntrenamientos frmSubCompetencia = new frmEntrenamientos();

            frmSubCompetencia.TopLevel = false;
            frmSubCompetencia.FormBorderStyle = FormBorderStyle.None;
            frmSubCompetencia.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmSubCompetencia);

            frmSubCompetencia.Show();

            this.Close();
        }

        private void frmPruebasFisicas_Load(object sender, EventArgs e)
        {
            CargarDeportistas();
            ConfigurarEstadoInicial();
        }

        private void CargarDeportistas()
        {
            DataTable dt = bd.RetornaRegistros("SELECT IdDeportista, Nombres + ' ' + Apellidos AS NombreCompleto FROM Deportistas WHERE Estado = 'Activo'");
            if (dt != null)
            {
                comboBox15.DataSource = dt;
                comboBox15.DisplayMember = "NombreCompleto";
                comboBox15.ValueMember = "IdDeportista";
                comboBox15.SelectedIndex = -1;
            }
        }

        private void ConfigurarEstadoInicial()
        {
            dateTimePicker2.Value = DateTime.Now;
            radioButton12.Checked = true;
            label23.Text = "Sin observaciones registradas.";
        }

        private void RadioButtonDolor_CheckedChanged(object sender, EventArgs e)
        {
            bool presentaDolor = radioButton11.Checked;
            panel5.Enabled = presentaDolor;

            if (!presentaDolor)
            {
                label23.Text = "El deportista no presenta molestias.";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox15.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un deportista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBox10.Text))
            {
                MessageBox.Show("Seleccione o ingrese la prueba realizada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idDeportista = Convert.ToInt32(comboBox15.SelectedValue);
            DateTime fecha = dateTimePicker2.Value.Date;

            // --- Mapeo corregido según las etiquetas reales del formulario ---
            // label31 "Fecha" -> dateTimePicker2 (ok)
            // label33 "Deportista" -> comboBox15 (ok)
            // label30 "Hora de inicio" -> comboBox12 (antes se leía mal desde comboBox14)
            // label29 "Duración" -> comboBox13 (antes se leía mal desde comboBox12)
            // label32 "Lugar de la prueba" -> comboBox14 (antes se leía mal desde comboBox13)
            // label28 "Tipo de prueba" -> comboBox11 (ok)
            // label26 "Prueba realizada" -> comboBox10 (ok)
            // label25 "Intentos" -> comboBox9 (ok)
            string horaInicio = comboBox12.Text;
            int duracion = int.TryParse(comboBox13.Text, out int d) ? d : 0;
            string lugar = comboBox14.Text;
            // -------------------------------------------------------------

            string tipoPrueba = comboBox11.Text;
            string pruebaRealizada = comboBox10.Text;
            int intentos = int.TryParse(comboBox9.Text, out int i) ? i : 1;

            decimal distancia = decimal.TryParse(textBox1.Text, out decimal dist) ? dist : 0;
            int tiempoTotal = int.TryParse(textBox2.Text, out int tt) ? tt : 0;
            int rpe = int.TryParse(textBox3.Text, out int r) ? r : 0;
            string clasificacion = comboBox8.Text;

            int tieneDolor = radioButton11.Checked ? 1 : 0;
            string obsGenerales = label23.Text;

            string sentencia = @"INSERT INTO PruebasFisicas
                (IdDeportista, Fecha, HoraInicio, Lugar, DuracionMin, Intentos, TipoPrueba, PruebaRealizada, DistanciaRecorrida, TiempoTotal, RPE, Clasificacion, TieneDolor, Observaciones)
                VALUES
                (@IdDeportista, @Fecha, @HoraInicio, @Lugar, @DuracionMin, @Intentos, @TipoPrueba, @PruebaRealizada, @DistanciaRecorrida, @TiempoTotal, @RPE, @Clasificacion, @TieneDolor, @Observaciones)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdDeportista", SqlDbType.Int) { Value = idDeportista },
                new SqlParameter("@Fecha", SqlDbType.Date) { Value = fecha },
                new SqlParameter("@HoraInicio", SqlDbType.NVarChar, 50) { Value = string.IsNullOrEmpty(horaInicio) ? (object)DBNull.Value : horaInicio },
                new SqlParameter("@Lugar", SqlDbType.NVarChar, 100) { Value = string.IsNullOrEmpty(lugar) ? (object)DBNull.Value : lugar },
                new SqlParameter("@DuracionMin", SqlDbType.Int) { Value = duracion },
                new SqlParameter("@Intentos", SqlDbType.Int) { Value = intentos },
                new SqlParameter("@TipoPrueba", SqlDbType.NVarChar, 100) { Value = string.IsNullOrEmpty(tipoPrueba) ? (object)DBNull.Value : tipoPrueba },
                new SqlParameter("@PruebaRealizada", SqlDbType.NVarChar, 100) { Value = pruebaRealizada },
                new SqlParameter("@DistanciaRecorrida", SqlDbType.Decimal) { Value = distancia },
                new SqlParameter("@TiempoTotal", SqlDbType.Int) { Value = tiempoTotal },
                new SqlParameter("@RPE", SqlDbType.Int) { Value = rpe },
                new SqlParameter("@Clasificacion", SqlDbType.NVarChar, 50) { Value = string.IsNullOrEmpty(clasificacion) ? (object)DBNull.Value : clasificacion },
                new SqlParameter("@TieneDolor", SqlDbType.Bit) { Value = tieneDolor },
                new SqlParameter("@Observaciones", SqlDbType.NVarChar, -1) { Value = string.IsNullOrEmpty(obsGenerales) ? (object)DBNull.Value : obsGenerales }
            };

            if (bd.EjecutaSentenciaParametros(sentencia, parametros))
            {
                MessageBox.Show("¡Prueba física registrada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar guardar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            comboBox15.SelectedIndex = -1;
            comboBox14.SelectedIndex = -1;
            comboBox13.SelectedIndex = -1;
            comboBox12.SelectedIndex = -1;
            comboBox11.SelectedIndex = -1;
            comboBox10.SelectedIndex = -1;
            comboBox9.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            dateTimePicker2.Value = DateTime.Now;

            radioButton12.Checked = true;
            label23.Text = "Sin observaciones registradas.";
        }
    }
}