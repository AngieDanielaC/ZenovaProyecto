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
    public partial class frmRemplazarEntrenador : Form
    {
        private int idEntrenadorActual;

        public frmRemplazarEntrenador(int idEntrenadorActual)
        {
            InitializeComponent();

            this.idEntrenadorActual = idEntrenadorActual;
        }


        public frmRemplazarEntrenador()
        {
            InitializeComponent();
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

        private void frmRemplazarEntrenador_Load(object sender, EventArgs e)
        {
            pnlPeriodoTemporal.Visible = false;

            CargarEntrenadorActual();
            CargarDisciplinasEntrenador();
            CargarTiposReemplazo();

            cmbNuevoEntrenador.DataSource = null;
            cmbNuevoEntrenador.Enabled = false;
        }
        private void CargarEntrenadorActual()
        {
            csConectaSQL conexion = new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            SELECT
                U.Nombres + ' ' + U.Apellidos AS NombreCompleto
            FROM Entrenadores E
            INNER JOIN Usuarios U
                ON E.IdUsuario = U.IdUsuario
            WHERE E.IdEntrenador = @IdEntrenador;
        ";

                SqlCommand comando =
                    new SqlCommand(
                        consulta,
                        conexion.oCon);

                comando.Parameters.AddWithValue(
                    "@IdEntrenador",
                    idEntrenadorActual);

                object resultado =
                    comando.ExecuteScalar();

                if (resultado != null)
                {
                    lblEntrenadorActual.Text =
                        resultado.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el entrenador:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }
        private void CargarDisciplinasEntrenador()
        {
            csConectaSQL conexion = new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            SELECT DISTINCT
                D.IdDeporte,
                D.NombreDeporte
            FROM EntrenadorDeporte ED
            INNER JOIN Deportes D
                ON ED.IdDeporte = D.IdDeporte
            WHERE
                ED.IdEntrenador = @IdEntrenador
                AND ED.Activo = 1
            ORDER BY D.NombreDeporte;
        ";

                SqlDataAdapter adaptador =
                    new SqlDataAdapter(
                        consulta,
                        conexion.oCon);

                adaptador.SelectCommand.Parameters
                    .AddWithValue(
                        "@IdEntrenador",
                        idEntrenadorActual);

                DataTable tabla =
                    new DataTable();

                adaptador.Fill(tabla);

                cmbDisciplina.DataSource = tabla;
                cmbDisciplina.DisplayMember = "NombreDeporte";
                cmbDisciplina.ValueMember = "IdDeporte";

                cmbDisciplina.SelectedIndex = -1;
                cmbDisciplina.DropDownStyle =
                    ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las disciplinas:\n\n" +
                    ex.Message);
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }
        private void CargarTiposReemplazo()
        {
            cmbTipoReemplazo.Items.Clear();

            cmbTipoReemplazo.Items.Add("Temporal");
            cmbTipoReemplazo.Items.Add("Definitivo");

            cmbTipoReemplazo.SelectedIndex = -1;

            cmbTipoReemplazo.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }

        private void cmbTipoReemplazo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoReemplazo.SelectedIndex == -1)
            {
                pnlPeriodoTemporal.Visible = false;
                return;
            }

            pnlPeriodoTemporal.Visible =
                cmbTipoReemplazo.Text == "Temporal";
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDisciplina.SelectedIndex == -1)
            {
                cmbNuevoEntrenador.DataSource = null;
                cmbNuevoEntrenador.Enabled = false;
                return;
            }

            if (cmbDisciplina.SelectedValue == null ||
                cmbDisciplina.SelectedValue is DataRowView)
                return;

            int idDeporte =
                Convert.ToInt32(
                    cmbDisciplina.SelectedValue);

            CargarNuevosEntrenadores(idDeporte);
        }
        private void CargarNuevosEntrenadores(int idDeporte)
        {
            csConectaSQL conexion = new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            SELECT
                E.IdEntrenador,
                ED.IdEntrenadorDeporte,
                U.Nombres + ' ' + U.Apellidos
                    AS NombreCompleto
            FROM EntrenadorDeporte ED

            INNER JOIN Entrenadores E
                ON ED.IdEntrenador = E.IdEntrenador

            INNER JOIN Usuarios U
                ON E.IdUsuario = U.IdUsuario

            WHERE
                ED.IdDeporte = @IdDeporte
                AND ED.Activo = 1
                AND U.EstadoCuenta = 1
                AND E.IdEntrenador <> @EntrenadorActual

            ORDER BY U.Nombres, U.Apellidos;
        ";

                SqlDataAdapter adaptador =
                    new SqlDataAdapter(
                        consulta,
                        conexion.oCon);

                adaptador.SelectCommand.Parameters
                    .AddWithValue(
                        "@IdDeporte",
                        idDeporte);

                adaptador.SelectCommand.Parameters
                    .AddWithValue(
                        "@EntrenadorActual",
                        idEntrenadorActual);

                DataTable tabla =
                    new DataTable();

                adaptador.Fill(tabla);

                cmbNuevoEntrenador.DataSource = tabla;

                cmbNuevoEntrenador.DisplayMember =
                    "NombreCompleto";

                cmbNuevoEntrenador.ValueMember =
                    "IdEntrenadorDeporte";

                cmbNuevoEntrenador.SelectedIndex = -1;

                cmbNuevoEntrenador.DropDownStyle =
                    ComboBoxStyle.DropDownList;

                cmbNuevoEntrenador.Enabled =
                    tabla.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar entrenadores disponibles:\n\n" +
                    ex.Message);
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbDisciplina.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione una disciplina.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (cmbTipoReemplazo.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione el tipo de reemplazo.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (cmbNuevoEntrenador.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione el nuevo entrenador.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }


            string tipo =
                cmbTipoReemplazo.Text;

            int idDeporte =
                Convert.ToInt32(
                    cmbDisciplina.SelectedValue);


            // ==========================================
            // OBTENER NUEVO ENTRENADOR
            // ==========================================
            DataRowView filaEntrenador =
                (DataRowView)cmbNuevoEntrenador.SelectedItem;

            int idEntrenadorNuevo =
                Convert.ToInt32(
                    filaEntrenador["IdEntrenador"]);

            int idEntrenadorDeporteNuevo =
                Convert.ToInt32(
                    filaEntrenador["IdEntrenadorDeporte"]);


            // ==========================================
            // VALIDAR FECHAS SI ES TEMPORAL
            // ==========================================
            if (tipo == "Temporal")
            {
                if (dtpFechaInicio.Value.Date != DateTime.Today)
                {
                    MessageBox.Show(
                        "El reemplazo temporal debe iniciar en la fecha actual.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (dtpFechaFin.Value.Date <=
                    dtpFechaInicio.Value.Date)
                {
                    MessageBox.Show(
                        "La fecha de fin debe ser posterior a la fecha de inicio.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }


            // ==========================================
            // CONFIRMACIÓN
            // ==========================================
            DialogResult respuesta =
                MessageBox.Show(
                    "Se reasignarán todos los deportistas activos " +
                    "de " + cmbDisciplina.Text +
                    " al entrenador " +
                    cmbNuevoEntrenador.Text + ".\n\n" +
                    "¿Desea continuar?",
                    "Confirmar reemplazo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;


            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
                return;


            // Usamos transacción porque debemos hacer
            // varios cambios juntos.
            SqlTransaction transaccion =
                conexion.oCon.BeginTransaction();


            try
            {
                // ==========================================
                // 1. REGISTRAR EL REEMPLAZO
                // ==========================================
                string insertarReemplazo = @"
            INSERT INTO ReemplazosEntrenador
            (
                IdEntrenadorOriginal,
                IdEntrenadorNuevo,
                IdDeporte,
                TipoReemplazo,
                FechaInicio,
                FechaFin,
                Estado
            )
            VALUES
            (
                @Original,
                @Nuevo,
                @Deporte,
                @Tipo,
                @FechaInicio,
                @FechaFin,
                'Activo'
            );
        ";

                SqlCommand cmdReemplazo =
                    new SqlCommand(
                        insertarReemplazo,
                        conexion.oCon,
                        transaccion);

                cmdReemplazo.Parameters.AddWithValue(
                    "@Original",
                    idEntrenadorActual);

                cmdReemplazo.Parameters.AddWithValue(
                    "@Nuevo",
                    idEntrenadorNuevo);

                cmdReemplazo.Parameters.AddWithValue(
                    "@Deporte",
                    idDeporte);

                cmdReemplazo.Parameters.AddWithValue(
                    "@Tipo",
                    tipo);


                // TEMPORAL = guarda fechas
                // DEFINITIVO = fechas NULL
                if (tipo == "Temporal")
                {
                    cmdReemplazo.Parameters.AddWithValue(
                        "@FechaInicio",
                        dtpFechaInicio.Value.Date);

                    cmdReemplazo.Parameters.AddWithValue(
                        "@FechaFin",
                        dtpFechaFin.Value.Date);
                }
                else
                {
                    cmdReemplazo.Parameters.AddWithValue(
                        "@FechaInicio",
                        DBNull.Value);

                    cmdReemplazo.Parameters.AddWithValue(
                        "@FechaFin",
                        DBNull.Value);
                }

                cmdReemplazo.ExecuteNonQuery();


                // ==========================================
                // 2. REASIGNAR TODAS LAS INSCRIPCIONES
                //    ACTIVAS DE ESA DISCIPLINA
                // ==========================================
                string actualizarInscripciones = @"
            UPDATE I

            SET I.IdEntrenadorDeporte =
                @NuevoEntrenadorDeporte

            FROM Inscripciones I

            INNER JOIN EntrenadorDeporte ED
                ON I.IdEntrenadorDeporte =
                   ED.IdEntrenadorDeporte

            WHERE
                ED.IdEntrenador =
                    @EntrenadorOriginal

                AND ED.IdDeporte =
                    @Deporte

                AND I.Estado = 'Activa';
        ";

                SqlCommand cmdInscripciones =
                    new SqlCommand(
                        actualizarInscripciones,
                        conexion.oCon,
                        transaccion);

                cmdInscripciones.Parameters.AddWithValue(
                    "@NuevoEntrenadorDeporte",
                    idEntrenadorDeporteNuevo);

                cmdInscripciones.Parameters.AddWithValue(
                    "@EntrenadorOriginal",
                    idEntrenadorActual);

                cmdInscripciones.Parameters.AddWithValue(
                    "@Deporte",
                    idDeporte);


                int deportistasReasignados =
                    cmdInscripciones.ExecuteNonQuery();


                // ==========================================
                // GUARDAR TODO
                // ==========================================
                transaccion.Commit();


                MessageBox.Show(
                    "Reemplazo registrado correctamente.\n\n" +
                    "Deportistas reasignados: " +
                    deportistasReasignados,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                // Si algo falla, deshacer TODO
                try
                {
                    transaccion.Rollback();
                }
                catch
                {
                }

                MessageBox.Show(
                    "Error al registrar el reemplazo:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }
    }
}
