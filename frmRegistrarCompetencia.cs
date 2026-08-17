using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmRegistrarCompetencia : Form
    {
        public int tipo; // 1 = nuevo, 2 = editar

        private int idCompetencia;

        csConectaSQL conSQL =
            new csConectaSQL();
        private class DeporteSeleccionado
        {
            public int IdDeporte { get; set; }

            public string NombreDeporte { get; set; }

            public override string ToString()
            {
                return NombreDeporte;
            }
        }
        public frmRegistrarCompetencia()
        {
            InitializeComponent();

            tipo = 1;

            lblTitulo.Text =
                "REGISTRAR COMPETENCIA";

            btnGuardar.Text =
                "Guardar";

            ConfigurarFormulario();
        }


        public frmRegistrarCompetencia(int idCompetencia)
        {
            InitializeComponent();

            tipo = 2;

            this.idCompetencia =
                idCompetencia;

            lblTitulo.Text =
                "EDITAR COMPETENCIA";

            btnGuardar.Text =
                "Guardar cambios";

            ConfigurarFormulario();
            CargarCompetencia();
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

        private void ConfigurarFormulario()
        {
            // NIVEL
            cmbNivel.Items.Clear();

            cmbNivel.Items.Add("Cantonal");
            cmbNivel.Items.Add("Provincial");
            cmbNivel.Items.Add("Nacional");
            cmbNivel.Items.Add("Internacional");

            cmbNivel.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbNivel.SelectedIndex = -1;


            // DEPORTES
            cmbDeportes.DropDownStyle =
                ComboBoxStyle.DropDownList;

            CargarDeportes();


            // FECHAS
            dtpFechaInicio.Value =
                DateTime.Today;

            dtpFechaFin.Value =
                DateTime.Today;

            // La fecha límite puede ser opcional
            dtpFechaLimite.ShowCheckBox =
                true;

            dtpFechaLimite.Checked =
                false;

            dtpFechaLimite.Value =
                DateTime.Today;
        }


        private void CargarDeportes()
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                        IdDeporte,
                        NombreDeporte
                      FROM Deportes
                      WHERE Activo = 1
                      ORDER BY NombreDeporte"
                );

            if (tabla == null)
                return;

            cmbDeportes.DataSource =
                tabla;

            cmbDeportes.DisplayMember =
                "NombreDeporte";

            cmbDeportes.ValueMember =
                "IdDeporte";

            cmbDeportes.SelectedIndex =
                -1;
        }




        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarDeporte_Click(object sender, EventArgs e)
        {
            if (cmbDeportes.SelectedIndex == -1 ||
                cmbDeportes.SelectedValue == null)
            {
                MessageBox.Show(
                    "Seleccione un deporte.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idDeporte =
                Convert.ToInt32(
                    cmbDeportes.SelectedValue);

            string nombreDeporte =
                cmbDeportes.Text;


            // Evitar repetir el mismo deporte
            foreach (DeporteSeleccionado deporte
                     in lstDeportes.Items)
            {
                if (deporte.IdDeporte ==
                    idDeporte)
                {
                    MessageBox.Show(
                        "Ese deporte ya fue agregado.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }


            DeporteSeleccionado nuevo =
                new DeporteSeleccionado();

            nuevo.IdDeporte =
                idDeporte;

            nuevo.NombreDeporte =
                nombreDeporte;

            lstDeportes.Items.Add(
                nuevo);

            cmbDeportes.SelectedIndex =
                -1;
        }

        private void btnQuitarDeporte_Click(object sender, EventArgs e)
        {
            if (lstDeportes.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione el deporte que desea quitar.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            lstDeportes.Items.RemoveAt(
                lstDeportes.SelectedIndex);
        }
        private bool ValidarCampos()
        {
            // NOMBRE
            if (txtNombreCompetencia.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese el nombre de la competencia.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombreCompetencia.Focus();

                return false;
            }


            // ORGANIZADOR
            if (txtOrganizador.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese el organizador de la competencia.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtOrganizador.Focus();

                return false;
            }


            // LUGAR
            if (txtLugar.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese el lugar de la competencia.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtLugar.Focus();

                return false;
            }


            // NIVEL
            if (cmbNivel.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione el nivel de la competencia.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbNivel.Focus();

                return false;
            }


            // FECHA FIN
            if (dtpFechaFin.Value.Date <
                dtpFechaInicio.Value.Date)
            {
                MessageBox.Show(
                    "La fecha de fin no puede ser anterior a la fecha de inicio.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtpFechaFin.Focus();

                return false;
            }


            // FECHA LÍMITE
            if (dtpFechaLimite.Checked)
            {
                if (dtpFechaLimite.Value.Date >
                    dtpFechaInicio.Value.Date)
                {
                    MessageBox.Show(
                        "La fecha límite de inscripción no puede ser posterior a la fecha de inicio.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    dtpFechaLimite.Focus();

                    return false;
                }
            }


            // DEPORTES
            if (lstDeportes.Items.Count == 0)
            {
                MessageBox.Show(
                    "Agregue al menos un deporte a la competencia.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbDeportes.Focus();

                return false;
            }


            return true;
        }

        private string CalcularEstado()
        {
            DateTime hoy =
                DateTime.Today;

            DateTime inicio =
                dtpFechaInicio.Value.Date;

            DateTime fin =
                dtpFechaFin.Value.Date;


            if (hoy < inicio)
            {
                return "Próxima";
            }

            if (hoy >= inicio &&
                hoy <= fin)
            {
                return "En curso";
            }

            return "Finalizada";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;


            if (tipo == 1)
            {
                RegistrarCompetencia();
            }
            else
            {
                EditarCompetencia();
            }
        }

        private void RegistrarCompetencia()
        {
            try
            {
                // ==========================================
                // DATOS
                // ==========================================
                string nombre =
                    txtNombreCompetencia.Text.Trim()
                    .Replace("'", "''");

                string organizador =
                    txtOrganizador.Text.Trim()
                    .Replace("'", "''");

                string lugar =
                    txtLugar.Text.Trim()
                    .Replace("'", "''");

                string nivel =
                    cmbNivel.Text.Trim()
                    .Replace("'", "''");

                string fechaInicio =
                    dtpFechaInicio.Value
                    .ToString("yyyy-MM-dd");

                string fechaFin =
                    dtpFechaFin.Value
                    .ToString("yyyy-MM-dd");

                string estado =
                    CalcularEstado();


                // ==========================================
                // FECHA LÍMITE
                // ==========================================
                string fechaLimite = "NULL";

                if (dtpFechaLimite.Checked)
                {
                    fechaLimite =
                        "'" +
                        dtpFechaLimite.Value
                        .ToString("yyyy-MM-dd") +
                        "'";
                }


                // ==========================================
                // INSERTAR COMPETENCIA
                // OUTPUT nos devuelve el ID creado
                // ==========================================
                string consulta =
                    @"
            INSERT INTO Competencias
            (
                NombreCompetencia,
                Organizador,
                Lugar,
                Nivel,
                FechaInicio,
                FechaFin,
                FechaLimiteInscripcion,
                Estado
            )

            OUTPUT INSERTED.IdCompetencia

            VALUES
            (
                '" + nombre + @"',
                '" + organizador + @"',
                '" + lugar + @"',
                '" + nivel + @"',
                '" + fechaInicio + @"',
                '" + fechaFin + @"',
                " + fechaLimite + @",
                '" + estado + @"'
            );
            ";


                DataTable tabla =
                    conSQL.RetornaRegistros(
                        consulta);


                if (tabla == null ||
                    tabla.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No se pudo registrar la competencia.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }


                // ==========================================
                // ID DE LA NUEVA COMPETENCIA
                // ==========================================
                int nuevoIdCompetencia =
                    Convert.ToInt32(
                        tabla.Rows[0][0]);


                // ==========================================
                // GUARDAR DEPORTES
                // ==========================================
                foreach (DeporteSeleccionado deporte
                         in lstDeportes.Items)
                {
                    string campos =
                        "IdCompetencia, IdDeporte";

                    string datos =
                        nuevoIdCompetencia +
                        "," +
                        deporte.IdDeporte;


                    if (!conSQL.insertDatos(
                        "CompetenciaDeporte",
                        campos,
                        datos))
                    {
                        MessageBox.Show(
                            "La competencia se registró, pero ocurrió un error al guardar uno de los deportes.",
                            "ZENOVA",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return;
                    }
                }


                // ==========================================
                // ÉXITO
                // ==========================================
                MessageBox.Show(
                    "Competencia registrada correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult =
                    DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al registrar la competencia:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void EditarCompetencia()
        {
            try
            {
                // ==========================================
                // DATOS
                // ==========================================
                string nombre =
                    txtNombreCompetencia.Text.Trim()
                    .Replace("'", "''");

                string organizador =
                    txtOrganizador.Text.Trim()
                    .Replace("'", "''");

                string lugar =
                    txtLugar.Text.Trim()
                    .Replace("'", "''");

                string nivel =
                    cmbNivel.Text.Trim()
                    .Replace("'", "''");

                string fechaInicio =
                    dtpFechaInicio.Value
                    .ToString("yyyy-MM-dd");

                string fechaFin =
                    dtpFechaFin.Value
                    .ToString("yyyy-MM-dd");


                // ==========================================
                // ESTADO ACTUAL
                // ==========================================
                DataTable tablaEstado =
                    conSQL.RetornaRegistros(
                        @"SELECT Estado
                  FROM Competencias
                  WHERE IdCompetencia = " +
                        idCompetencia
                    );


                string estado =
                    CalcularEstado();


                // Si fue cancelada, no cambiarla
                // automáticamente a próxima/en curso/finalizada.
                if (tablaEstado != null &&
                    tablaEstado.Rows.Count > 0 &&
                    tablaEstado.Rows[0]["Estado"]
                        .ToString() == "Cancelada")
                {
                    estado = "Cancelada";
                }


                // ==========================================
                // FECHA LÍMITE
                // ==========================================
                string fechaLimite = "NULL";

                if (dtpFechaLimite.Checked)
                {
                    fechaLimite =
                        "'" +
                        dtpFechaLimite.Value
                        .ToString("yyyy-MM-dd") +
                        "'";
                }


                // ==========================================
                // ACTUALIZAR COMPETENCIA
                // ==========================================
                string actualizar =
                    @"
            UPDATE Competencias
            SET
                NombreCompetencia = '" + nombre + @"',
                Organizador = '" + organizador + @"',
                Lugar = '" + lugar + @"',
                Nivel = '" + nivel + @"',
                FechaInicio = '" + fechaInicio + @"',
                FechaFin = '" + fechaFin + @"',
                FechaLimiteInscripcion = " + fechaLimite + @",
                Estado = '" + estado + @"'

            WHERE IdCompetencia =
                " + idCompetencia + @";

            SELECT IdCompetencia
            FROM Competencias
            WHERE IdCompetencia =
                " + idCompetencia + @";
            ";


                DataTable resultado =
                    conSQL.RetornaRegistros(
                        actualizar);


                if (resultado == null ||
                    resultado.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "No se pudo actualizar la competencia.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }


                // ==========================================
                // COMPROBAR SI YA TIENE PARTICIPANTES
                // ==========================================
                DataTable tablaParticipantes =
                    conSQL.RetornaRegistros(
                        @"
                SELECT COUNT(*) AS Total

                FROM ParticipantesCompetencia PC

                INNER JOIN CompetenciaDeporte CD
                    ON PC.IdCompetenciaDeporte =
                       CD.IdCompetenciaDeporte

                WHERE CD.IdCompetencia =
                    " + idCompetencia
                    );


                int totalParticipantes = 0;

                if (tablaParticipantes != null &&
                    tablaParticipantes.Rows.Count > 0)
                {
                    totalParticipantes =
                        Convert.ToInt32(
                            tablaParticipantes
                            .Rows[0]["Total"]);
                }


                // ==========================================
                // SI NO HAY PARTICIPANTES,
                // PODEMOS REEMPLAZAR LOS DEPORTES
                // ==========================================
                if (totalParticipantes == 0)
                {
                    // Borrar deportes anteriores
                    conSQL.RetornaRegistros(
                        @"
                DELETE FROM CompetenciaDeporte
                WHERE IdCompetencia =
                    " + idCompetencia + @";

                SELECT 1 AS Resultado;
                "
                    );


                    // Guardar deportes actuales
                    foreach (DeporteSeleccionado deporte
                             in lstDeportes.Items)
                    {
                        string campos =
                            "IdCompetencia, IdDeporte";

                        string datos =
                            idCompetencia +
                            "," +
                            deporte.IdDeporte;


                        if (!conSQL.insertDatos(
                            "CompetenciaDeporte",
                            campos,
                            datos))
                        {
                            MessageBox.Show(
                                "Los datos generales se actualizaron, pero ocurrió un error al actualizar los deportes.",
                                "ZENOVA",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                // ==========================================
                // SI YA HAY PARTICIPANTES
                // ==========================================
                else
                {
                    MessageBox.Show(
                        "La información de la competencia se actualizó.\n\n" +
                        "Los deportes no se modificaron porque la competencia ya tiene participantes inscritos.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult =
                        DialogResult.OK;

                    this.Close();

                    return;
                }


                // ==========================================
                // ÉXITO
                // ==========================================
                MessageBox.Show(
                    "Competencia actualizada correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult =
                    DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al actualizar la competencia:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void CargarCompetencia()
        {
            // ======================================
            // DATOS GENERALES
            // ======================================
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                        NombreCompetencia,
                        Organizador,
                        Lugar,
                        Nivel,
                        FechaInicio,
                        FechaFin,
                        FechaLimiteInscripcion
                      FROM Competencias
                      WHERE IdCompetencia = " +
                    idCompetencia
                );


            if (tabla == null ||
                tabla.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró la competencia.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            DataRow fila =
                tabla.Rows[0];


            txtNombreCompetencia.Text =
                fila["NombreCompetencia"]
                .ToString();

            txtOrganizador.Text =
                fila["Organizador"]
                .ToString();

            txtLugar.Text =
                fila["Lugar"]
                .ToString();

            cmbNivel.SelectedItem =
                fila["Nivel"]
                .ToString();

            dtpFechaInicio.Value =
                Convert.ToDateTime(
                    fila["FechaInicio"]);

            dtpFechaFin.Value =
                Convert.ToDateTime(
                    fila["FechaFin"]);


            if (fila["FechaLimiteInscripcion"]
                != DBNull.Value)
            {
                dtpFechaLimite.Checked =
                    true;

                dtpFechaLimite.Value =
                    Convert.ToDateTime(
                        fila["FechaLimiteInscripcion"]);
            }
            else
            {
                dtpFechaLimite.Checked =
                    false;
            }


            // ======================================
            // DEPORTES
            // ======================================
            DataTable tablaDeportes =
                conSQL.RetornaRegistros(
                    @"SELECT
                        D.IdDeporte,
                        D.NombreDeporte
                      FROM CompetenciaDeporte CD
                      INNER JOIN Deportes D
                          ON CD.IdDeporte =
                             D.IdDeporte
                      WHERE CD.IdCompetencia = " +
                    idCompetencia +
                    @" ORDER BY D.NombreDeporte"
                );


            lstDeportes.Items.Clear();


            if (tablaDeportes == null)
                return;


            foreach (DataRow deporte
                     in tablaDeportes.Rows)
            {
                DeporteSeleccionado item =
                    new DeporteSeleccionado();

                item.IdDeporte =
                    Convert.ToInt32(
                        deporte["IdDeporte"]);

                item.NombreDeporte =
                    deporte["NombreDeporte"]
                    .ToString();

                lstDeportes.Items.Add(
                    item);
            }
        }

        





    }
}
