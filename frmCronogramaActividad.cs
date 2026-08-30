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
    public partial class frmCronogramaActividad : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        private string modo;
        private int idEntrenador;
        private int idCronograma;

        //Constructor para agregar actividad
        public frmCronogramaActividad(string modo, int idEntrenador)
        {
            InitializeComponent();

            this.modo = modo;
            this.idEntrenador = idEntrenador;

            lblTitulo.Text = "Agregar Actividad";
        }

        //Constructor para editar actividad
        public frmCronogramaActividad(string modo, int idEntrenador, int idCronograma)
        {
            InitializeComponent();

            this.modo = modo;
            this.idEntrenador = idEntrenador;
            this.idCronograma = idCronograma;

            lblTitulo.Text = "Editar Actividad";
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Guardar o editar actividad
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // VALIDAR TIPO
            if (cmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Debe seleccionar un tipo de actividad.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // VALIDAR ACTIVIDAD
            if (string.IsNullOrWhiteSpace(txtActividad.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el nombre de la actividad.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // VALIDAR LUGAR
            if (string.IsNullOrWhiteSpace(txtLugar.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el lugar.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // VALIDAR ESTADO
            if (cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Debe seleccionar un estado.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // VALIDAR HORAS
            if (dtpHoraInicio.Value.TimeOfDay >= dtpHoraFin.Value.TimeOfDay)
            {
                MessageBox.Show(
                    "La hora de fin debe ser mayor que la hora de inicio.",
                    "Hora inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // OBTENER DATOS
            string actividad = txtActividad.Text.Trim().Replace("'", "''");
            string lugar = txtLugar.Text.Trim().Replace("'", "''");
            string tipo = cmbTipo.Text.Replace("'", "''");
            string estado = cmbEstado.Text.Replace("'", "''");

            string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");

            string horaInicio =
                dtpHoraInicio.Value.ToString("HH:mm:ss");

            string horaFin =
                dtpHoraFin.Value.ToString("HH:mm:ss");


            // NUEVA ACTIVIDAD
            if (modo == "Agregar")
            {
                string sql = $@"
            INSERT INTO CronogramaEntrenador
            (
                IdEntrenador,
                Fecha,
                HoraInicio,
                HoraFin,
                Actividad,
                Tipo,
                Lugar,
                Estado
            )
            VALUES
            (
                {idEntrenador},
                '{fecha}',
                '{horaInicio}',
                '{horaFin}',
                '{actividad}',
                '{tipo}',
                '{lugar}',
                '{estado}'
            )";

                if (conSQL.EjecutaSentenciaSRD(sql))
                {
                    MessageBox.Show(
                        "Actividad registrada correctamente.",
                        "Registro exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.Close();
                }
            }

            // EDITAR ACTIVIDAD
            else if (modo == "Editar")
            {
                string sql = $@"
            UPDATE CronogramaEntrenador
            SET
                Fecha = '{fecha}',
                HoraInicio = '{horaInicio}',
                HoraFin = '{horaFin}',
                Actividad = '{actividad}',
                Tipo = '{tipo}',
                Lugar = '{lugar}',
                Estado = '{estado}'
            WHERE IdCronograma = {idCronograma}
              AND IdEntrenador = {idEntrenador}";

                if (conSQL.EjecutaSentenciaSRD(sql))
                {
                    MessageBox.Show(
                        "Actividad actualizada correctamente.",
                        "Actualización exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.Close();
                }
            }
        }

        //Cerrar formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Cargar datos de la actividad seleccionada
        private void CargarDatosActividad()
        {
            DataTable dt = conSQL.RetornaRegistros($@"
            SELECT
                Fecha,
                HoraInicio,
                HoraFin,
                Actividad,
                Tipo,
                Lugar,
                Estado
            FROM CronogramaEntrenador
            WHERE IdCronograma = {idCronograma}
            AND IdEntrenador = {idEntrenador}");

            if (dt.Rows.Count == 0)
                return;

            DataRow fila = dt.Rows[0];

            dtpFecha.Value =
                Convert.ToDateTime(fila["Fecha"]);

            dtpHoraInicio.Value =
                DateTime.Today.Add((TimeSpan)fila["HoraInicio"]);

            dtpHoraFin.Value =
                DateTime.Today.Add((TimeSpan)fila["HoraFin"]);

            txtActividad.Text =
                fila["Actividad"].ToString();

            cmbTipo.Text =
                fila["Tipo"].ToString();

            txtLugar.Text =
                fila["Lugar"].ToString();

            cmbEstado.Text =
                fila["Estado"].ToString();
        }

        //Cargar formulario
        private void frmCronogramaActividad_Load(object sender, EventArgs e)
        {
            if (modo == "Editar")
            {
                CargarDatosActividad();
            }
        }
    }
}