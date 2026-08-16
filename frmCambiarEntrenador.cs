using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace wfZenova
{
    public partial class frmCambiarEntrenador : Form
    {
        csConectaSQL conSQL = new csConectaSQL();

        private int idInscripcion;
        private int idDeporte;        
        public frmCambiarEntrenador(int IdInscripcion)
        {
            InitializeComponent();
            this.idInscripcion = IdInscripcion;
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        private void frmCambiarEntrenador_Load(object sender, EventArgs e)
        {
            DataTable dt = conSQL.RetornaRegistros($@"
                SELECT
                    D.Nombres + ' ' + D.Apellidos AS Deportista,
                    DEP.IdDeporte,
                    DEP.NombreDeporte AS Deporte,
                    E.IdEntrenador,
                    E.Nombres + ' ' + E.Apellidos AS EntrenadorActual
                FROM Inscripciones I
                INNER JOIN Deportistas D
                    ON I.IdDeportista = D.IdDeportista
                INNER JOIN EntrenadorDeporte ED
                    ON I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte
                INNER JOIN Deportes DEP
                    ON ED.IdDeporte = DEP.IdDeporte
                INNER JOIN Entrenadores E
                    ON ED.IdEntrenador = E.IdEntrenador
                WHERE I.IdInscripcion = {idInscripcion}");

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No se encontró la inscripción.");
                Close();
                return;
            }

            DataRow fila = dt.Rows[0];

            lblDeportista.Text = fila["Deportista"].ToString();
            lblDisciplina.Text = fila["Disciplina"].ToString();
            lblEntrenadorActual.Text = fila["EntrenadorActual"].ToString();

            idDeporte = Convert.ToInt32(fila["IdDeporte"]);
            int idEntrenadorActual =
                Convert.ToInt32(fila["IdEntrenador"]);

            // Cargar SOLO entrenadores del mismo deporte
            DataTable entrenadores = conSQL.RetornaRegistros($@"
                SELECT DISTINCT
                    E.IdEntrenador,
                    E.Nombres + ' ' + E.Apellidos AS Entrenador
                FROM Entrenadores E
                INNER JOIN EntrenadorDeporte ED
                    ON E.IdEntrenador = ED.IdEntrenador
                WHERE ED.IdDeporte = {idDeporte}
                    AND ED.Activo = 1
                    AND E.IdEntrenador <> {idEntrenadorActual}
                ORDER BY Entrenador");

            cmbNuevoEntrenador.DataSource = entrenadores;
            cmbNuevoEntrenador.DisplayMember = "Entrenador";
            cmbNuevoEntrenador.ValueMember = "IdEntrenador";
            cmbNuevoEntrenador.SelectedIndex = -1;
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (cmbNuevoEntrenador.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Debe seleccionar un nuevo entrenador.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int idEntrenador = Convert.ToInt32(cmbNuevoEntrenador.SelectedValue);

            // Buscar la relación Entrenador-Deporte
            DataTable dt = conSQL.RetornaRegistros($@"
                SELECT IdEntrenadorDeporte
                FROM EntrenadorDeporte
                WHERE IdEntrenador = {idEntrenador}
                AND IdDeporte = {idDeporte}
                AND Activo = 1");

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró la asignación del entrenador para este deporte.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            int idEntrenadorDeporte =
                Convert.ToInt32(dt.Rows[0]["IdEntrenadorDeporte"]);

            // Cambiar entrenador de ESTA inscripción
            string sql = $@"
                UPDATE Inscripciones
                SET IdEntrenadorDeporte = {idEntrenadorDeporte}
                WHERE IdInscripcion = {idInscripcion}";

            if (conSQL.EjecutaSentenciaSRD(sql))
            {
                MessageBox.Show(
                    "Entrenador cambiado correctamente.",
                    "Cambio realizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmEntrenadorAdm frmVerCompetencias = new frmEntrenadorAdm();

            frmVerCompetencias.TopLevel = false;
            frmVerCompetencias.FormBorderStyle = FormBorderStyle.None;
            frmVerCompetencias.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmVerCompetencias);

            frmVerCompetencias.Show();
            this.Close();
        }
    }
}
