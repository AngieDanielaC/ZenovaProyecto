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
        private int idInscripcion;
        private int idDeporte;
        private int idEntrenadorDeporteActual;

        public frmCambiarEntrenador(int idInscripcion)
        {
            InitializeComponent();

            this.idInscripcion = idInscripcion;
        }

        public frmCambiarEntrenador()
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

        private void frmCambiarEntrenador_Load(object sender, EventArgs e)
        {
            CargarDatosInscripcion();
        }
        private void CargarDatosInscripcion()
        {
            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            SELECT
                I.IdEntrenadorDeporte,
                ED.IdDeporte,
                D.NombreDeporte,
                U.Nombres + ' ' + U.Apellidos
                    AS EntrenadorActual
            FROM Inscripciones I

            INNER JOIN EntrenadorDeporte ED
                ON I.IdEntrenadorDeporte =
                   ED.IdEntrenadorDeporte

            INNER JOIN Deportes D
                ON ED.IdDeporte =
                   D.IdDeporte

            INNER JOIN Entrenadores E
                ON ED.IdEntrenador =
                   E.IdEntrenador

            INNER JOIN Usuarios U
                ON E.IdUsuario =
                   U.IdUsuario

            WHERE
                I.IdInscripcion =
                @IdInscripcion;
        ";

                SqlCommand comando =
                    new SqlCommand(
                        consulta,
                        conexion.oCon);

                comando.Parameters.AddWithValue(
                    "@IdInscripcion",
                    idInscripcion);

                SqlDataReader lector =
                    comando.ExecuteReader();

                if (lector.Read())
                {
                    idEntrenadorDeporteActual =
                        Convert.ToInt32(
                            lector["IdEntrenadorDeporte"]);

                    idDeporte =
                        Convert.ToInt32(
                            lector["IdDeporte"]);

                    lblDisciplina.Text =
                        lector["NombreDeporte"]
                        .ToString();

                    lblEntrenadorActual.Text =
                        lector["EntrenadorActual"]
                        .ToString();
                }

                lector.Close();

                CargarEntrenadoresDisponibles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar la inscripción:\n\n" +
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
        private void CargarEntrenadoresDisponibles()
        {
            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            SELECT
                ED.IdEntrenadorDeporte,

                U.Nombres + ' ' + U.Apellidos
                    AS NombreEntrenador

            FROM EntrenadorDeporte ED

            INNER JOIN Entrenadores E
                ON ED.IdEntrenador =
                   E.IdEntrenador

            INNER JOIN Usuarios U
                ON E.IdUsuario =
                   U.IdUsuario

            WHERE
                ED.IdDeporte = @IdDeporte
                AND ED.Activo = 1
                AND U.EstadoCuenta = 1

                AND ED.IdEntrenadorDeporte
                    <> @Actual

            ORDER BY
                U.Nombres,
                U.Apellidos;
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
                        "@Actual",
                        idEntrenadorDeporteActual);

                DataTable tabla =
                    new DataTable();

                adaptador.Fill(tabla);

                cmbNuevoEntrenador.DataSource =
                    tabla;

                cmbNuevoEntrenador.DisplayMember =
                    "NombreEntrenador";

                cmbNuevoEntrenador.ValueMember =
                    "IdEntrenadorDeporte";

                cmbNuevoEntrenador.SelectedIndex =
                    -1;

                cmbNuevoEntrenador.DropDownStyle =
                    ComboBoxStyle.DropDownList;


                if (tabla.Rows.Count == 0)
                {
                    cmbNuevoEntrenador.Enabled =
                        false;

                    MessageBox.Show(
                        "No existen otros entrenadores disponibles para esta disciplina.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    cmbNuevoEntrenador.Enabled =
                        true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los entrenadores disponibles:\n\n" +
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbNuevoEntrenador.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione el nuevo entrenador.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int nuevoIdEntrenadorDeporte =
                Convert.ToInt32(
                    cmbNuevoEntrenador.SelectedValue);

            string nuevoEntrenador =
                cmbNuevoEntrenador.Text;


            DialogResult respuesta =
                MessageBox.Show(
                    "¿Desea cambiar el entrenador actual por " +
                    nuevoEntrenador + "?",
                    "Cambiar entrenador",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;


            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            UPDATE Inscripciones
            SET
                IdEntrenadorDeporte =
                    @IdEntrenadorDeporte
            WHERE
                IdInscripcion =
                    @IdInscripcion;
        ";

                SqlCommand comando =
                    new SqlCommand(
                        consulta,
                        conexion.oCon);

                comando.Parameters.AddWithValue(
                    "@IdEntrenadorDeporte",
                    nuevoIdEntrenadorDeporte);

                comando.Parameters.AddWithValue(
                    "@IdInscripcion",
                    idInscripcion);

                comando.ExecuteNonQuery();


                MessageBox.Show(
                    "El entrenador fue cambiado correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cambiar el entrenador:\n\n" +
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
