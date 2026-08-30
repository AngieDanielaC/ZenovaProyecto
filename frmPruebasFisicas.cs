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
        private int idEntrenador;

        //Inicializar formulario
        public frmPruebasFisicas()
        {
            InitializeComponent();

            this.button4.Click += new EventHandler(button4_Click);
            this.button5.Click += new EventHandler(button5_Click);
            this.radioButton11.CheckedChanged += new EventHandler(RadioButtonDolor_CheckedChanged);
            this.radioButton12.CheckedChanged += new EventHandler(RadioButtonDolor_CheckedChanged);
        }

        //Volver a entrenamientos
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
                return;

            frmEntrenamientos frm = new frmEntrenamientos();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            contenedor.Controls.Clear();
            contenedor.Controls.Add(frm);

            frm.Show();
        }

        //Cargar formulario
        private void frmPruebasFisicas_Load(object sender, EventArgs e)
        {
            CargarDeportistas();
            ConfigurarEstadoInicial();
        }

        //Cargar deportistas activos
        private void CargarDeportistas()
        {
            if (frmInicioDeSesion.IdEntrenadorActual == null)
            {
                MessageBox.Show(
                    "La sesión actual no está asociada a un entrenador.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            idEntrenador = frmInicioDeSesion.IdEntrenadorActual.Value;

            DataTable dt = bd.RetornaRegistros(
                "SELECT IdDeportista, " +
                "Nombres + ' ' + Apellidos AS NombreCompleto " +
                "FROM Deportistas " +
                "WHERE Estado = 1"
            );

            if (dt != null)
            {
                comboBox15.DataSource = dt;
                comboBox15.DisplayMember = "NombreCompleto";
                comboBox15.ValueMember = "IdDeportista";
                comboBox15.SelectedIndex = -1;
            }
        }

        //Configurar valores iniciales
        private void ConfigurarEstadoInicial()
        {
            dateTimePicker2.Value = DateTime.Now;
            radioButton12.Checked = true;
            txtObservaciones.Text = "Sin observaciones registradas.";
        }

        //Controlar opción de dolor o molestia
        private void RadioButtonDolor_CheckedChanged(object sender, EventArgs e)
        {
            bool presentaDolor = radioButton11.Checked;
            panel5.Enabled = presentaDolor;
        }

        //Guardar prueba física
        private void button4_Click(object sender, EventArgs e)
        {
            //Validar deportista seleccionado
            if (comboBox15.SelectedValue == null)
            {
                MessageBox.Show(
                    "Por favor, seleccione un deportista.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int idDeportista = Convert.ToInt32(comboBox15.SelectedValue);

            if (string.IsNullOrWhiteSpace(comboBox10.Text))
            {
                MessageBox.Show(
                    "Seleccione o ingrese la prueba realizada.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DateTime fecha = dateTimePicker2.Value.Date;

            string horaInicio = comboBox12.Text;

            int duracion =
                int.TryParse(comboBox13.Text, out int d) ? d : 0;

            string lugar = comboBox14.Text;

            string tipoPrueba = comboBox11.Text;
            string pruebaRealizada = comboBox10.Text;

            int intentos =
                int.TryParse(comboBox9.Text, out int i) ? i : 1;

            decimal distancia =
                decimal.TryParse(textBox1.Text, out decimal dist)
                ? dist
                : 0;

            int tiempoTotal =
                int.TryParse(textBox2.Text, out int tt)
                ? tt
                : 0;

            int rpe =
                int.TryParse(textBox3.Text, out int r)
                ? r
                : 0;

            string clasificacion = comboBox8.Text;

            int tieneDolor =
                radioButton11.Checked ? 1 : 0;

            string obsGenerales =
                txtObservaciones.Text;

            string sentencia = @"INSERT INTO PruebasFisicas
                    (IdDeportista, IdEntrenador, Fecha, HoraInicio, Lugar, DuracionMin, Intentos, TipoPrueba, PruebaRealizada, DistanciaRecorrida, TiempoTotal, RPE, Clasificacion, TieneDolor, Observaciones)
                    VALUES
                    (@IdDeportista, @IdEntrenador, @Fecha, @HoraInicio, @Lugar, @DuracionMin, @Intentos, @TipoPrueba, @PruebaRealizada, @DistanciaRecorrida, @TiempoTotal, @RPE, @Clasificacion, @TieneDolor, @Observaciones)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdDeportista", SqlDbType.Int)
                {
                    Value = idDeportista
                },

                new SqlParameter("@IdEntrenador", SqlDbType.Int)
                {
                    Value = idEntrenador
                },

                new SqlParameter("@Fecha", SqlDbType.Date)
                {
                    Value = fecha
                },

                new SqlParameter("@HoraInicio", SqlDbType.NVarChar, 50)
                {
                    Value = string.IsNullOrWhiteSpace(horaInicio)
                        ? (object)DBNull.Value
                        : horaInicio
                },

                new SqlParameter("@Lugar", SqlDbType.NVarChar, 100)
                {
                    Value = string.IsNullOrWhiteSpace(lugar)
                        ? (object)DBNull.Value
                        : lugar
                },

                new SqlParameter("@DuracionMin", SqlDbType.Int)
                {
                    Value = duracion
                },

                new SqlParameter("@Intentos", SqlDbType.Int)
                {
                    Value = intentos
                },

                new SqlParameter("@TipoPrueba", SqlDbType.NVarChar, 100)
                {
                    Value = string.IsNullOrWhiteSpace(tipoPrueba)
                        ? (object)DBNull.Value
                        : tipoPrueba
                },

                new SqlParameter("@PruebaRealizada", SqlDbType.NVarChar, 100)
                {
                    Value = pruebaRealizada
                },

                new SqlParameter("@DistanciaRecorrida", SqlDbType.Decimal)
                {
                    Value = distancia
                },

                new SqlParameter("@TiempoTotal", SqlDbType.Int)
                {
                    Value = tiempoTotal
                },

                new SqlParameter("@RPE", SqlDbType.Int)
                {
                    Value = rpe
                },

                new SqlParameter("@Clasificacion", SqlDbType.NVarChar, 50)
                {
                    Value = string.IsNullOrWhiteSpace(clasificacion)
                        ? (object)DBNull.Value
                        : clasificacion
                },

                new SqlParameter("@TieneDolor", SqlDbType.Bit)
                {
                    Value = tieneDolor
                },

                new SqlParameter("@Observaciones", SqlDbType.NVarChar, -1)
                {
                    Value = string.IsNullOrWhiteSpace(obsGenerales)
                        ? (object)DBNull.Value
                        : obsGenerales
                }
            };

            if (bd.EjecutaSentenciaParametros(sentencia, parametros))
            {
                MessageBox.Show(
                    "¡Prueba física registrada exitosamente!",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show(
                    "Ocurrió un error al intentar guardar el registro.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        //Cancelar y limpiar formulario
        private void button5_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        //Limpiar campos
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
            txtObservaciones.Text = "Sin observaciones.";
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }
    }
}