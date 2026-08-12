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
    public partial class frmDepAdm : Form
    {
        public frmDepAdm()
        {
            InitializeComponent();
            ConfigurarTablaDeportistas();
            CargarDeportistas();
        }
        private void ConfigurarTablaDeportistas()
        {
            // LIMPIAR TABLA
            dgvDeportistas.Columns.Clear();
            dgvDeportistas.Rows.Clear();

            // COLUMNA FOTO
            DataGridViewImageColumn colFoto =
                new DataGridViewImageColumn();

            colFoto.Name = "Foto";
            colFoto.HeaderText = "FOTO";
            colFoto.ImageLayout =
                DataGridViewImageCellLayout.Zoom;

            dgvDeportistas.Columns.Add(colFoto);


            // COLUMNAS
            dgvDeportistas.Columns.Add(
                "Nombre",
                "NOMBRE COMPLETO");

            dgvDeportistas.Columns.Add(
                "Cedula",
                "CÉDULA");

            dgvDeportistas.Columns.Add(
                "Edad",
                "EDAD");

            dgvDeportistas.Columns.Add(
                "Disciplinas",
                "DISCIPLINAS ACTIVAS");

            dgvDeportistas.Columns.Add(
                "Estado",
                "ESTADO");

            // CONFIGURACIÓN GENERAL

            dgvDeportistas.BackgroundColor =
                Color.White;

            dgvDeportistas.BorderStyle =
                BorderStyle.None;

            dgvDeportistas.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvDeportistas.GridColor =
                Color.FromArgb(235, 235, 245);

            dgvDeportistas.RowHeadersVisible = false;

            dgvDeportistas.AllowUserToAddRows = false;
            dgvDeportistas.AllowUserToDeleteRows = false;
            dgvDeportistas.AllowUserToResizeRows = false;
            dgvDeportistas.AllowUserToResizeColumns = false;

            dgvDeportistas.ReadOnly = true;

            dgvDeportistas.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvDeportistas.MultiSelect = false;

            dgvDeportistas.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            // ==========================================
            // ENCABEZADO
            // ==========================================
            dgvDeportistas.EnableHeadersVisualStyles =
                false;

            dgvDeportistas.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(52, 63, 221);

            dgvDeportistas.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvDeportistas.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    12,
                    FontStyle.Bold);

            dgvDeportistas.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.ColumnHeadersHeight = 50;

            dgvDeportistas.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvDeportistas.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;


            // ESTILO DE LAS FILAS
            dgvDeportistas.DefaultCellStyle.BackColor =
                Color.White;

            dgvDeportistas.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 40, 95);

            dgvDeportistas.DefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    10,
                    FontStyle.Regular);

            dgvDeportistas.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            // COLOR DE SELECCIÓN

            dgvDeportistas.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvDeportistas.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 40, 95);


            // ALTURA DE FILAS
            dgvDeportistas.RowTemplate.Height = 60;



            // TAMAÑO DE COLUMNAS

            dgvDeportistas.Columns["Foto"].FillWeight = 50;

            dgvDeportistas.Columns["Nombre"].FillWeight = 150;

            dgvDeportistas.Columns["Cedula"].FillWeight = 90;

            dgvDeportistas.Columns["Edad"].FillWeight = 55;

            dgvDeportistas.Columns["Disciplinas"].FillWeight = 130;

            dgvDeportistas.Columns["Estado"].FillWeight = 75;


            // ALINEACIÓN

            dgvDeportistas.Columns["Foto"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.Columns["Nombre"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvDeportistas.Columns["Cedula"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.Columns["Edad"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.Columns["Disciplinas"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.Columns["Estado"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            // Ninguna fila seleccionada inicialmente
            dgvDeportistas.ClearSelection();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmRegistroDeportistaAdm frmVerCompetencias = new frmRegistroDeportistaAdm();

            frmVerCompetencias.TopLevel = false;
            frmVerCompetencias.FormBorderStyle = FormBorderStyle.None;
            frmVerCompetencias.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmVerCompetencias);

            frmVerCompetencias.Show();
            CargarDeportistas();
            this.Close();
        }
        private void CargarDeportistas()
        {
            // Limpiar datos anteriores
            dgvDeportistas.Rows.Clear();

            csConectaSQL conexion = new csConectaSQL();

            if (conexion.abrirConexion())
            {
                try
                {
                    string consulta = @"
                SELECT
                    IdDeportista,
                    Foto,
                    Nombres,
                    Apellidos,
                    Cedula,
                    FechaNacimiento,
                    Estado
                FROM Deportistas
                ORDER BY Nombres, Apellidos;
            ";

                    SqlCommand comando =
                        new SqlCommand(consulta, conexion.oCon);

                    SqlDataReader lector =
                        comando.ExecuteReader();

                    while (lector.Read())
                    {
                        // =====================================
                        // NOMBRE COMPLETO
                        // =====================================
                        string nombreCompleto =
                            lector["Nombres"].ToString() + " " +
                            lector["Apellidos"].ToString();


                        // =====================================
                        // EDAD
                        // =====================================
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


                        // =====================================
                        // ESTADO
                        // =====================================
                        bool activo =
                            Convert.ToBoolean(
                                lector["Estado"]);

                        string estado =
                            activo ? "Activo" : "Inactivo";


                        // =====================================
                        // FOTO
                        // =====================================
                        Image foto = null;

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
                                    foto =
                                        new Bitmap(imagen);
                                }
                            }
                        }


                        // =====================================
                        // AGREGAR FILA
                        // =====================================
                        int indice =
                            dgvDeportistas.Rows.Add(
                                foto,
                                nombreCompleto,
                                lector["Cedula"].ToString(),
                                edad,
                                "Sin asignar",
                                estado
                            );


                        // Guardamos el ID ocultamente en la fila
                        dgvDeportistas.Rows[indice].Tag =
                            Convert.ToInt32(
                                lector["IdDeportista"]);
                    }

                    lector.Close();

                    dgvDeportistas.ClearSelection();
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
        }
        private void frmDepAdm_Load(object sender, EventArgs e)
        {

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dgvDeportistas.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un deportista de la tabla.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idDeportista =
                Convert.ToInt32(
                    dgvDeportistas.SelectedRows[0].Tag);

            frmVerDeportista frm =
                new frmVerDeportista(idDeportista);

            frm.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDeportistas.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un deportista de la tabla.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int idDeportista =
                Convert.ToInt32(
                    dgvDeportistas.SelectedRows[0].Tag);

            frmEditarDeportista frm =
                new frmEditarDeportista(idDeportista);

            frm.ShowDialog();

            CargarDeportistas();
        }

        private void btnAcDes_Click(object sender, EventArgs e)
        {
            if (dgvDeportistas.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un deportista de la tabla.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila =
                dgvDeportistas.SelectedRows[0];

            int idDeportista =
                Convert.ToInt32(fila.Tag);

            string nombre =
                fila.Cells["Nombre"].Value.ToString();

            string estadoActual =
                fila.Cells["Estado"].Value.ToString();


            bool estaActivo =
                estadoActual == "Activo";

            string mensaje;

            if (estaActivo)
            {
                mensaje =
                    "¿Está seguro de que desea desactivar al deportista " +
                    nombre + "?\n\n" +
                    "El deportista quedará inactivo, pero su información " +
                    "e historial permanecerán registrados.";
            }
            else
            {
                mensaje =
                    "¿Está seguro de que desea activar nuevamente al deportista " +
                    nombre + "?";
            }


            DialogResult respuesta =
                MessageBox.Show(
                    mensaje,
                    estaActivo
                        ? "Desactivar deportista"
                        : "Activar deportista",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);


            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
            {
                return;
            }


            try
            {
                string consulta = @"
            UPDATE Deportistas
            SET Estado = @Estado
            WHERE IdDeportista = @IdDeportista;
        ";


                SqlCommand comando =
                    new SqlCommand(
                        consulta,
                        conexion.oCon);


                // Si estaba activo -> 0
                // Si estaba inactivo -> 1
                comando.Parameters.AddWithValue(
                    "@Estado",
                    estaActivo ? 0 : 1);


                comando.Parameters.AddWithValue(
                    "@IdDeportista",
                    idDeportista);


                comando.ExecuteNonQuery();


                MessageBox.Show(
                    estaActivo
                        ? "El deportista fue desactivado correctamente."
                        : "El deportista fue activado correctamente.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarDeportistas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cambiar el estado del deportista:\n\n" +
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
