using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmRegistrarResultados : Form
    {
        private int idCompetencia;
        private int? idEntrenador;
        private bool esAdministrador;
        private int idParticipanteCompetencia = 0;

        csConectaSQL conSQL =
            new csConectaSQL();



        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        public frmRegistrarResultados()
        {
            InitializeComponent();

            esAdministrador = true;
            idEntrenador = null;

            ConfigurarFormulario();
        }
        public frmRegistrarResultados(int idCompetencia)
        {
            InitializeComponent();

            this.idCompetencia = idCompetencia;

            esAdministrador = true;
            idEntrenador = null;

            ConfigurarFormulario();
            CargarFechaCompetencia();
            CargarDeportistas();
        }
        public frmRegistrarResultados(
            int idCompetencia,
            int idEntrenador)
        {
            InitializeComponent();

            this.idCompetencia =
                idCompetencia;

            this.idEntrenador =
                idEntrenador;

            esAdministrador = false;

            ConfigurarFormulario();

            CargarFechaCompetencia();

            CargarDeportistas();
        }

        private void ConfigurarFormulario()
        {
            // Permitir escribir para buscar
            cmbDeportista.DropDownStyle =
                ComboBoxStyle.DropDown;

            cmbDeportista.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;

            cmbDeportista.AutoCompleteSource =
                AutoCompleteSource.ListItems;

            cmbDeportista.SelectedIndex =
                -1;

            lblDeporte.Text = "";

            lblCategoria.Text = "";

            lblFechaCompetencia.Text = "";

            txtPrueba.Clear();

            txtPuestoObtenido.Clear();

            idParticipanteCompetencia = 0;

            picFoto.Image = null;
        }

        private void CargarFechaCompetencia()
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                        FechaInicio,
                        FechaFin

                      FROM Competencias

                      WHERE IdCompetencia = " +
                    idCompetencia
                );


            if (tabla == null ||
                tabla.Rows.Count == 0)
            {
                lblFechaCompetencia.Text =
                    "No disponible";

                return;
            }


            DateTime fechaInicio =
                Convert.ToDateTime(
                    tabla.Rows[0]["FechaInicio"]);


            DateTime fechaFin =
                Convert.ToDateTime(
                    tabla.Rows[0]["FechaFin"]);


            if (fechaInicio.Date ==
                fechaFin.Date)
            {
                lblFechaCompetencia.Text =
                    fechaInicio
                    .ToString("dd/MM/yyyy");
            }
            else
            {
                lblFechaCompetencia.Text =
                    fechaInicio
                    .ToString("dd/MM/yyyy")
                    +
                    " - "
                    +
                    fechaFin
                    .ToString("dd/MM/yyyy");
            }
        }
        private void CargarDeportistas()
        {
            string filtroEntrenador = "";


            // ==========================================
            // ENTRENADOR:
            // SOLO SUS DEPORTISTAS
            // ==========================================
            if (!esAdministrador)
            {
                filtroEntrenador =
                    @" AND EXISTS
                    (
                        SELECT 1

                        FROM Inscripciones I

                        INNER JOIN EntrenadorDeporte ED2
                            ON I.IdEntrenadorDeporte =
                               ED2.IdEntrenadorDeporte

                        WHERE
                            I.IdDeportista =
                                D.IdDeportista

                            AND I.Estado =
                                'Activo'

                            AND ED2.IdEntrenador =
                                " + idEntrenador.Value + @"

                            AND ED2.IdDeporte =
                                CD.IdDeporte
                    )";
            }


            string consulta =
                @"SELECT DISTINCT

                    PC.IdParticipanteCompetencia,

                    D.IdDeportista,

                    D.Nombres + ' ' +
                    D.Apellidos
                        AS NombreCompleto

                  FROM ParticipantesCompetencia PC

                  INNER JOIN CompetenciaDeporte CD
                      ON PC.IdCompetenciaDeporte =
                         CD.IdCompetenciaDeporte

                  INNER JOIN Deportistas D
                      ON PC.IdDeportista =
                         D.IdDeportista

                  WHERE
                      CD.IdCompetencia =
                          " + idCompetencia + @"

                      AND PC.EstadoParticipacion =
                          'Inscrito'

                      " + filtroEntrenador + @"

                  ORDER BY
                      NombreCompleto";


            DataTable tabla =
                conSQL.RetornaRegistros(
                    consulta);


            if (tabla == null)
                return;


            cmbDeportista.DataSource =
                tabla;

            cmbDeportista.DisplayMember =
                "NombreCompleto";

            cmbDeportista.ValueMember =
                "IdParticipanteCompetencia";

            cmbDeportista.SelectedIndex =
                -1;
        }





        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        private void cmbDeportista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeportista.SelectedIndex == -1 ||
                cmbDeportista.SelectedValue == null ||
                cmbDeportista.SelectedValue
                    is DataRowView)
            {
                LimpiarDatosDeportista();

                return;
            }


            idParticipanteCompetencia =
                Convert.ToInt32(
                    cmbDeportista.SelectedValue);


            CargarDatosDeportista();
        }

        private void CargarDatosDeportista()
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                        D.IdDeportista,

                        D.Foto,

                        DEP.NombreDeporte,

                        (
                            SELECT TOP 1
                                M.CategoriaEdad

                            FROM MedicionesDeportista M

                            WHERE
                                M.IdDeportista =
                                    D.IdDeportista

                            ORDER BY
                                M.FechaMedicion DESC,
                                M.IdMedicion DESC

                        ) AS Categoria

                      FROM ParticipantesCompetencia PC

                      INNER JOIN Deportistas D
                          ON PC.IdDeportista =
                             D.IdDeportista

                      INNER JOIN CompetenciaDeporte CD
                          ON PC.IdCompetenciaDeporte =
                             CD.IdCompetenciaDeporte

                      INNER JOIN Deportes DEP
                          ON CD.IdDeporte =
                             DEP.IdDeporte

                      WHERE
                          PC.IdParticipanteCompetencia =
                          " + idParticipanteCompetencia
                );


            if (tabla == null ||
                tabla.Rows.Count == 0)
            {
                LimpiarDatosDeportista();

                return;
            }


            DataRow fila =
                tabla.Rows[0];


            // ==========================================
            // DEPORTE
            // ==========================================
            lblDeporte.Text =
                fila["NombreDeporte"]
                .ToString();


            // ==========================================
            // CATEGORÍA
            // ==========================================
            lblCategoria.Text =
                fila["Categoria"] ==
                DBNull.Value
                ? "Sin medición"
                : fila["Categoria"]
                    .ToString();


            // ==========================================
            // FOTO
            // ==========================================
            picFoto.Image = null;


            if (fila["Foto"] != DBNull.Value)
            {
                try
                {
                    byte[] foto =
                        (byte[])fila["Foto"];


                    using (MemoryStream ms =
                           new MemoryStream(foto))
                    {
                        using (Image imagen =
                               Image.FromStream(ms))
                        {
                            picFoto.Image =
                                new Bitmap(imagen);
                        }
                    }


                    picFoto.SizeMode =
                        PictureBoxSizeMode.Zoom;
                }
                catch
                {
                    picFoto.Image = null;
                }
            }
        }

        private void LimpiarDatosDeportista()
        {
            idParticipanteCompetencia = 0;

            lblDeporte.Text = "";

            lblCategoria.Text = "";

            picFoto.Image = null;
        }

        private bool ValidarCampos()
        {
            if (cmbDeportista.SelectedIndex == -1 ||
                cmbDeportista.SelectedValue == null ||
                cmbDeportista.SelectedValue
                    is DataRowView ||
                idParticipanteCompetencia <= 0)
            {
                MessageBox.Show(
                    "Seleccione un deportista válido de la lista.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbDeportista.Focus();

                return false;
            }


            if (txtPrueba.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese la prueba realizada.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPrueba.Focus();

                return false;
            }


            if (txtPuestoObtenido.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese el puesto obtenido.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPuestoObtenido.Focus();

                return false;
            }


            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;


            // ==========================================
            // COMPROBAR SI YA EXISTE RESULTADO
            // ==========================================
            DataTable tablaExiste =
                conSQL.RetornaRegistros(
                    @"SELECT
                        IdResultado

                      FROM ResultadosCompetencia

                      WHERE
                        IdParticipanteCompetencia =
                        " + idParticipanteCompetencia
                );


            if (tablaExiste != null &&
                tablaExiste.Rows.Count > 0)
            {
                MessageBox.Show(
                    "Este deportista ya tiene un resultado registrado en esta competencia.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // ==========================================
            // PREPARAR DATOS
            // ==========================================
            string prueba =
                txtPrueba.Text.Trim()
                .Replace("'", "''");


            string puesto =
                txtPuestoObtenido.Text.Trim()
                .Replace("'", "''");


            string campos =
                "IdParticipanteCompetencia, " +
                "Prueba, " +
                "PuestoObtenido";


            string datos =
                idParticipanteCompetencia +
                ",'" +
                prueba +
                "','" +
                puesto +
                "'";


            // ==========================================
            // GUARDAR
            // ==========================================
            if (conSQL.insertDatos(
                "ResultadosCompetencia",
                campos,
                datos))
            {
                MessageBox.Show(
                    "Resultado registrado correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);


                this.DialogResult =
                    DialogResult.OK;

                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "No se pudo registrar el resultado.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
