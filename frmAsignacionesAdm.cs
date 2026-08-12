using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace wfZenova
{
    public partial class frmAsignacionesAdm : Form
    {
        public frmAsignacionesAdm()
        {
            InitializeComponent();

            ConfigurarTablaAsignaciones();

            CargarDeportistas();
            CargarDisciplinas();

            cmbEntrenador.Enabled = false;
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Format = DateTimePickerFormat.Short;

            dtpFechaInicio.Value = DateTime.Today;
            dtpFechaFin.Value = DateTime.Today;
        }
        private void ConfigurarTablaAsignaciones()
        {
            dgvAsignaciones.Columns.Clear();
            dgvAsignaciones.Rows.Clear();

            // ID oculto
            dgvAsignaciones.Columns.Add("IdInscripcion", "ID");

            // Columnas visibles
            dgvAsignaciones.Columns.Add("Disciplina", "DISCIPLINA");
            dgvAsignaciones.Columns.Add("Entrenador", "ENTRENADOR");
            dgvAsignaciones.Columns.Add("Inicio", "INICIO");
            dgvAsignaciones.Columns.Add("Fin", "FIN");
            dgvAsignaciones.Columns.Add("Estado", "ESTADO");

            // Ocultar ID
            dgvAsignaciones.Columns["IdInscripcion"].Visible = false;

            // ==========================================
            // ESTILO GENERAL
            // ==========================================
            dgvAsignaciones.BackgroundColor = Color.White;
            dgvAsignaciones.BorderStyle = BorderStyle.None;

            dgvAsignaciones.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvAsignaciones.GridColor =
                Color.FromArgb(235, 235, 235);

            dgvAsignaciones.RowHeadersVisible = false;

            dgvAsignaciones.AllowUserToAddRows = false;
            dgvAsignaciones.AllowUserToDeleteRows = false;
            dgvAsignaciones.AllowUserToResizeRows = false;
            dgvAsignaciones.AllowUserToResizeColumns = false;

            dgvAsignaciones.ReadOnly = true;

            dgvAsignaciones.MultiSelect = false;

            dgvAsignaciones.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAsignaciones.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvAsignaciones.RowTemplate.Height = 50;


            // ==========================================
            // ENCABEZADO
            // ==========================================
            dgvAsignaciones.EnableHeadersVisualStyles = false;

            dgvAsignaciones.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    11F,
                    FontStyle.Bold);

            dgvAsignaciones.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvAsignaciones.ColumnHeadersHeight = 50;

            dgvAsignaciones.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;


            // ==========================================
            // FILAS
            // ==========================================
            dgvAsignaciones.DefaultCellStyle.BackColor =
                Color.White;

            dgvAsignaciones.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 30, 60);

            dgvAsignaciones.DefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    10F,
                    FontStyle.Regular);

            dgvAsignaciones.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvAsignaciones.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvAsignaciones.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 30, 60);


            // ==========================================
            // TAMAÑO DE COLUMNAS
            // ==========================================
            dgvAsignaciones.Columns["Disciplina"].FillWeight = 22;
            dgvAsignaciones.Columns["Entrenador"].FillWeight = 27;
            dgvAsignaciones.Columns["Inicio"].FillWeight = 17;
            dgvAsignaciones.Columns["Fin"].FillWeight = 17;
            dgvAsignaciones.Columns["Estado"].FillWeight = 17;


            // Ninguna fila seleccionada al inicio
            dgvAsignaciones.ClearSelection();
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // ================================
            // VALIDACIONES
            // ================================

            if (cmbDeportista.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un deportista.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cmbDisciplina.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione una disciplina.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (cmbEntrenador.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione un entrenador.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (dtpFechaFin.Value.Date <
                dtpFechaInicio.Value.Date)
            {
                MessageBox.Show(
                    "La fecha de fin no puede ser anterior a la fecha de inicio.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            int idDeportista =
                Convert.ToInt32(
                    cmbDeportista.SelectedValue);

            int idEntrenadorDeporte =
                Convert.ToInt32(
                    cmbEntrenador.SelectedValue);


            // ================================
            // CONEXIÓN
            // ================================

            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
                return;


            try
            {
                // ==========================================
                // VALIDAR QUE NO TENGA YA ESA DISCIPLINA
                // ==========================================

                string validar = @"
            SELECT COUNT(*)
            FROM Inscripciones I

            INNER JOIN EntrenadorDeporte ED
                ON I.IdEntrenadorDeporte =
                   ED.IdEntrenadorDeporte

            WHERE I.IdDeportista = @IdDeportista
              AND ED.IdDeporte = @IdDeporte
              AND I.Estado = 'Activa';
        ";

                SqlCommand cmdValidar =
                    new SqlCommand(
                        validar,
                        conexion.oCon);

                cmdValidar.Parameters.AddWithValue(
                    "@IdDeportista",
                    idDeportista);

                cmdValidar.Parameters.AddWithValue(
                    "@IdDeporte",
                    Convert.ToInt32(
                        cmbDisciplina.SelectedValue));


                int cantidad =
                    Convert.ToInt32(
                        cmdValidar.ExecuteScalar());


                if (cantidad > 0)
                {
                    MessageBox.Show(
                        "El deportista ya tiene una inscripción activa en esta disciplina.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                // ==========================================
                // INSERTAR INSCRIPCIÓN
                // ==========================================

                string consulta = @"
            INSERT INTO Inscripciones
            (
                IdDeportista,
                IdEntrenadorDeporte,
                FechaInicio,
                FechaFin,
                Estado
            )
            VALUES
            (
                @IdDeportista,
                @IdEntrenadorDeporte,
                @FechaInicio,
                @FechaFin,
                'Activa'
            );
        ";


                SqlCommand comando =
                    new SqlCommand(
                        consulta,
                        conexion.oCon);


                comando.Parameters.AddWithValue(
                    "@IdDeportista",
                    idDeportista);

                comando.Parameters.AddWithValue(
                    "@IdEntrenadorDeporte",
                    idEntrenadorDeporte);

                comando.Parameters.AddWithValue(
                    "@FechaInicio",
                    dtpFechaInicio.Value.Date);

                comando.Parameters.AddWithValue(
                    "@FechaFin",
                    dtpFechaFin.Value.Date);


                comando.ExecuteNonQuery();


                MessageBox.Show(
                    "Inscripción registrada correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al registrar la inscripción:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrarConexion();
            }


            CargarDatosDeportista(idDeportista);
            CargarInscripciones(idDeportista);
        }

        private void frmAsignacionesAdm_Load(object sender, EventArgs e)
        {
            
        }
        private void CargarDeportistas()
        {
            csConectaSQL conexion = new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            SELECT
                IdDeportista,
                Nombres + ' ' + Apellidos AS NombreCompleto
            FROM Deportistas
            WHERE Estado = 1
            ORDER BY Nombres, Apellidos;
        ";

                SqlDataAdapter adaptador =
                    new SqlDataAdapter(
                        consulta,
                        conexion.oCon);

                DataTable tabla =
                    new DataTable();

                adaptador.Fill(tabla);

                cmbDeportista.DataSource = tabla;

                cmbDeportista.DisplayMember =
                    "NombreCompleto";

                cmbDeportista.ValueMember =
                    "IdDeportista";

                cmbDeportista.SelectedIndex = -1;

                cmbDeportista.DropDownStyle =
                    ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los deportistas:\n\n" +
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

        private void cmbDeportista_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeportista.SelectedIndex == -1)
            {
                dgvAsignaciones.Rows.Clear();
                return;
            }

            if (cmbDeportista.SelectedValue == null)
                return;

            if (cmbDeportista.SelectedValue is DataRowView)
                return;

            int idDeportista =
                Convert.ToInt32(
                    cmbDeportista.SelectedValue);

            CargarDatosDeportista(idDeportista);

            CargarInscripciones(idDeportista);
        }

        private void CargarDatosDeportista(int idDeportista)
        {
            csConectaSQL conexion = new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            SELECT
                D.Foto,
                D.Nombres,
                D.Apellidos,
                D.FechaNacimiento,

                (
                    SELECT COUNT(*)
                    FROM Inscripciones I
                    WHERE I.IdDeportista = D.IdDeportista
                    AND I.Estado = 'Activa'
                ) AS DeportesActivos

            FROM Deportistas D
            WHERE D.IdDeportista = @IdDeportista;
        ";

                SqlCommand comando =
                    new SqlCommand(
                        consulta,
                        conexion.oCon);

                comando.Parameters.AddWithValue(
                    "@IdDeportista",
                    idDeportista);

                SqlDataReader lector =
                    comando.ExecuteReader();

                if (lector.Read())
                {
                    // NOMBRE
                    lblNombreDeportista.Text =
                        lector["Nombres"].ToString() + " " +
                        lector["Apellidos"].ToString();


                    // EDAD
                    DateTime fechaNacimiento =
                        Convert.ToDateTime(
                            lector["FechaNacimiento"]);

                    int edad =
                        DateTime.Today.Year -
                        fechaNacimiento.Year;

                    if (fechaNacimiento.Date >
                        DateTime.Today.AddYears(-edad))
                    {
                        edad--;
                    }

                    lblEdad.Text =
                        edad + " años";


                    // DEPORTES ACTIVOS
                    int deportes =
                        Convert.ToInt32(
                            lector["DeportesActivos"]);

                    lblDeportes.Text =
                        "Deportes: " + deportes;


                    // FOTO
                    if (lector["Foto"] != DBNull.Value)
                    {
                        byte[] bytesFoto =
                            (byte[])lector["Foto"];

                        using (MemoryStream ms =
                               new MemoryStream(bytesFoto))
                        {
                            using (Image imagen =
                                   Image.FromStream(ms))
                            {
                                picDeportista.Image =
                                    new Bitmap(imagen);
                            }
                        }

                        picDeportista.SizeMode =
                            PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        picDeportista.Image = null;
                    }
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los datos del deportista:\n\n" +
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

        private void CargarDisciplinas()
        {
            csConectaSQL conexion = new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            SELECT
                IdDeporte,
                NombreDeporte
            FROM Deportes
            ORDER BY NombreDeporte;
        ";

                SqlDataAdapter adaptador =
                    new SqlDataAdapter(consulta, conexion.oCon);

                DataTable tabla = new DataTable();

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

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDisciplina.SelectedIndex == -1)
            {
                cmbEntrenador.DataSource = null;
                cmbEntrenador.Enabled = false;
                return;
            }

            if (cmbDisciplina.SelectedValue == null ||
                cmbDisciplina.SelectedValue is DataRowView)
                return;

            int idDeporte =
                Convert.ToInt32(
                    cmbDisciplina.SelectedValue);

            CargarEntrenadores(idDeporte);
        }
        private void CargarEntrenadores(int idDeporte)
        {
            csConectaSQL conexion = new csConectaSQL();

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
                ON ED.IdEntrenador = E.IdEntrenador

            INNER JOIN Usuarios U
                ON E.IdUsuario = U.IdUsuario

            WHERE ED.IdDeporte = @IdDeporte
              AND ED.Activo = 1
              AND U.EstadoCuenta = 1

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

                DataTable tabla =
                    new DataTable();

                adaptador.Fill(tabla);

                cmbEntrenador.DataSource = tabla;

                cmbEntrenador.DisplayMember =
                    "NombreEntrenador";

                // IMPORTANTE:
                // Guardamos IdEntrenadorDeporte,
                // no solamente IdEntrenador.
                cmbEntrenador.ValueMember =
                    "IdEntrenadorDeporte";

                cmbEntrenador.SelectedIndex = -1;

                cmbEntrenador.DropDownStyle =
                    ComboBoxStyle.DropDownList;

                cmbEntrenador.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los entrenadores:\n\n" +
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


        private void CargarInscripciones(int idDeportista)
        {
            dgvAsignaciones.Rows.Clear();

            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            SELECT
                I.IdInscripcion,
                D.NombreDeporte AS Disciplina,
                U.Nombres + ' ' + U.Apellidos AS Entrenador,
                I.FechaInicio,
                I.FechaFin,
                I.Estado
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
                I.IdDeportista =
                @IdDeportista

            ORDER BY
                CASE
                    WHEN I.Estado = 'Activa' THEN 0
                    ELSE 1
                END,
                I.FechaInicio DESC;
        ";

                SqlCommand comando =
                    new SqlCommand(
                        consulta,
                        conexion.oCon);

                comando.Parameters.AddWithValue(
                    "@IdDeportista",
                    idDeportista);

                SqlDataReader lector =
                    comando.ExecuteReader();

                while (lector.Read())
                {
                    dgvAsignaciones.Rows.Add(
                        lector["IdInscripcion"],

                        lector["Disciplina"]
                            .ToString(),

                        lector["Entrenador"]
                            .ToString(),

                        Convert.ToDateTime(
                            lector["FechaInicio"])
                            .ToString("dd/MM/yyyy"),

                        Convert.ToDateTime(
                            lector["FechaFin"])
                            .ToString("dd/MM/yyyy"),

                        lector["Estado"]
                            .ToString()
                    );
                }

                lector.Close();

                dgvAsignaciones.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las inscripciones:\n\n" +
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

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            // ==========================================
            // VALIDAR QUE HAYA UNA FILA SELECCIONADA
            // ==========================================
            if (dgvAsignaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione una inscripción de la tabla.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            // ==========================================
            // OBTENER DATOS DE LA FILA
            // ==========================================
            DataGridViewRow fila =
                dgvAsignaciones.SelectedRows[0];

            int idInscripcion =
                Convert.ToInt32(
                    fila.Cells["IdInscripcion"].Value);

            string disciplina =
                fila.Cells["Disciplina"].Value.ToString();

            string estado =
                fila.Cells["Estado"].Value.ToString();


            // ==========================================
            // VALIDAR ESTADO
            // ==========================================
            if (estado != "Activa")
            {
                MessageBox.Show(
                    "Esta inscripción ya se encuentra finalizada.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }


            // ==========================================
            // CONFIRMACIÓN
            // ==========================================
            DialogResult respuesta =
                MessageBox.Show(
                    "¿Está seguro de finalizar la inscripción en " +
                    disciplina + "?\n\n" +
                    "El deportista dejará de tener esta disciplina activa.",
                    "Finalizar inscripción",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


            if (respuesta != DialogResult.Yes)
                return;


            // ==========================================
            // ACTUALIZAR BASE DE DATOS
            // ==========================================
            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
            UPDATE Inscripciones
            SET
                Estado = 'Finalizada',
                FechaFin = @FechaFin
            WHERE IdInscripcion = @IdInscripcion;
        ";

                SqlCommand comando =
                    new SqlCommand(
                        consulta,
                        conexion.oCon);

                comando.Parameters.AddWithValue(
                    "@FechaFin",
                    DateTime.Today);

                comando.Parameters.AddWithValue(
                    "@IdInscripcion",
                    idInscripcion);

                comando.ExecuteNonQuery();


                MessageBox.Show(
                    "La inscripción fue finalizada correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al finalizar la inscripción:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                conexion.cerrarConexion();
            }


            // ==========================================
            // ACTUALIZAR PANTALLA
            // ==========================================
            int idDeportista =
                Convert.ToInt32(
                    cmbDeportista.SelectedValue);

            CargarDatosDeportista(idDeportista);
            CargarInscripciones(idDeportista);
        }

        private void btnCambiarEntrenador_Click(object sender, EventArgs e)
        {
            if (dgvAsignaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione una inscripción de la tabla.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila =
                dgvAsignaciones.SelectedRows[0];

            int idInscripcion =
                Convert.ToInt32(
                    fila.Cells["IdInscripcion"].Value);

            string estado =
                fila.Cells["Estado"].Value.ToString();

            if (estado != "Activa")
            {
                MessageBox.Show(
                    "Solo puede cambiar el entrenador de una inscripción activa.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            frmCambiarEntrenador frm =
                new frmCambiarEntrenador(idInscripcion);

            frm.ShowDialog();

            int idDeportista =
                Convert.ToInt32(
                    cmbDeportista.SelectedValue);

            CargarInscripciones(idDeportista);
        }
    }
}
