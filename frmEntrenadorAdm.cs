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
    public partial class frmEntrenadorAdm : Form
    {
        public frmEntrenadorAdm()
        {
            InitializeComponent();
            ConfigurarTablaEntrenadores();
            CargarEntrenadores();
        }
        private void ConfigurarTablaEntrenadores()
        {
            dgvEntrenadores.Columns.Clear();
            dgvEntrenadores.Rows.Clear();


            // ======================================
            // COLUMNAS
            // ======================================

            // ID OCULTO
            dgvEntrenadores.Columns.Add(
                "IdEntrenador",
                "ID");

            dgvEntrenadores.Columns.Add(
                "Nombre",
                "NOMBRE COMPLETO");

            dgvEntrenadores.Columns.Add(
                "Edad",
                "EDAD");

            dgvEntrenadores.Columns.Add(
                "Telefono",
                "TELÉFONO");

            dgvEntrenadores.Columns.Add(
                "Deporte",
                "DEPORTES");

            dgvEntrenadores.Columns.Add(
                "Estado",
                "ESTADO");

            dgvEntrenadores.Columns.Add(
                "Deportistas",
                "DEPORTISTAS\nACTIVOS");


            // Ocultar ID
            dgvEntrenadores.Columns[
                "IdEntrenador"].Visible = false;


            // ======================================
            // ESTILO GENERAL
            // ======================================
            dgvEntrenadores.BackgroundColor =
                Color.White;

            dgvEntrenadores.BorderStyle =
                BorderStyle.None;

            dgvEntrenadores.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvEntrenadores.GridColor =
                Color.FromArgb(235, 235, 235);


            // ======================================
            // ENCABEZADO
            // ======================================
            dgvEntrenadores.EnableHeadersVisualStyles =
                false;

            dgvEntrenadores.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgvEntrenadores
                .ColumnHeadersDefaultCellStyle
                .BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgvEntrenadores
                .ColumnHeadersDefaultCellStyle
                .ForeColor =
                Color.White;

            dgvEntrenadores
                .ColumnHeadersDefaultCellStyle
                .Font =
                new Font(
                    "Century Gothic",
                    11F,
                    FontStyle.Bold);

            dgvEntrenadores
                .ColumnHeadersDefaultCellStyle
                .Alignment =
                DataGridViewContentAlignment
                .MiddleCenter;

            dgvEntrenadores.ColumnHeadersHeight = 50;

            dgvEntrenadores
                .ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode
                .DisableResizing;


            // ======================================
            // FILAS
            // ======================================
            dgvEntrenadores.RowHeadersVisible = false;

            dgvEntrenadores.RowTemplate.Height = 50;

            dgvEntrenadores.DefaultCellStyle.BackColor =
                Color.White;

            dgvEntrenadores.DefaultCellStyle.ForeColor =
                Color.FromArgb(25, 30, 60);

            dgvEntrenadores.DefaultCellStyle.Font =
                new Font(
                    "Century Gothic",
                    10F,
                    FontStyle.Regular);

            dgvEntrenadores.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;


            // ======================================
            // SELECCIÓN
            // ======================================
            dgvEntrenadores
                .DefaultCellStyle
                .SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgvEntrenadores
                .DefaultCellStyle
                .SelectionForeColor =
                Color.FromArgb(25, 30, 60);


            // ======================================
            // COLUMNAS OCUPAN TODO
            // ======================================
            dgvEntrenadores.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;


            // ======================================
            // TAMAÑOS
            // ======================================
            dgvEntrenadores.Columns["Nombre"]
                .FillWeight = 130;

            dgvEntrenadores.Columns["Edad"]
                .FillWeight = 55;

            dgvEntrenadores.Columns["Telefono"]
                .FillWeight = 90;

            dgvEntrenadores.Columns["Deporte"]
                .FillWeight = 130;

            dgvEntrenadores.Columns["Estado"]
                .FillWeight = 75;

            dgvEntrenadores.Columns["Deportistas"]
                .FillWeight = 80;


            // ======================================
            // ALINEACIONES
            // ======================================
            dgvEntrenadores.Columns["Nombre"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvEntrenadores.Columns["Deporte"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;


            // ======================================
            // BLOQUEAR EDICIÓN
            // ======================================
            dgvEntrenadores.AllowUserToAddRows = false;

            dgvEntrenadores.AllowUserToDeleteRows = false;

            dgvEntrenadores.AllowUserToResizeRows = false;

            dgvEntrenadores.AllowUserToResizeColumns =
                false;

            dgvEntrenadores.ReadOnly = true;

            dgvEntrenadores.MultiSelect = false;

            dgvEntrenadores.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvEntrenadores.ClearSelection();
        }
        private void CargarEntrenadores()
        {
            dgvEntrenadores.Rows.Clear();

            csConectaSQL conexion =
                new csConectaSQL();

            if (!conexion.abrirConexion())
                return;

            try
            {
                string consulta = @"
                    SELECT
                        E.IdEntrenador,

                        U.Nombres + ' ' +
                        U.Apellidos
                        AS NombreCompleto,

                        U.FechaNacimiento,

                        U.Telefono,

                        E.EstadoEntrenador,

                        ISNULL(
                        STUFF(
                        (
                            SELECT DISTINCT
                                ', ' + D.NombreDeporte

                            FROM EntrenadorDeporte ED2

                            INNER JOIN Deportes D
                                ON ED2.IdDeporte =
                                   D.IdDeporte

                            WHERE
                                ED2.IdEntrenador =
                                E.IdEntrenador

                                AND ED2.Activo = 1

                            FOR XML PATH(''),
                            TYPE
                        ).value(
                            '.',
                            'NVARCHAR(MAX)'
                        ),
                        1,
                        2,
                        ''),
                        'Sin deportes'
                        ) AS Deportes,

                        (
                            SELECT
                                COUNT(
                                    DISTINCT
                                    I.IdDeportista
                                )

                            FROM Inscripciones I

                            INNER JOIN
                                EntrenadorDeporte ED3

                                ON I.IdEntrenadorDeporte =
                                   ED3.IdEntrenadorDeporte

                            INNER JOIN Deportistas DEP

                                ON I.IdDeportista =
                                   DEP.IdDeportista

                            WHERE
                                ED3.IdEntrenador =
                                E.IdEntrenador

                                AND I.Estado = 'Activa'

                                AND DEP.Estado = 1

                        ) AS DeportistasActivos

                    FROM Entrenadores E

                    INNER JOIN Usuarios U
                        ON E.IdUsuario =
                           U.IdUsuario

                    ORDER BY
                        U.Nombres,
                        U.Apellidos;
                ";


                SqlCommand comando =
                    new SqlCommand(
                        consulta,
                        conexion.oCon);

                SqlDataReader lector =
                    comando.ExecuteReader();


                while (lector.Read())
                {
                    // ==================================
                    // EDAD
                    // ==================================
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


                    // ==================================
                    // ESTADO
                    // ==================================
                    string estado =
                        lector["EstadoEntrenador"]
                        .ToString();


                    // ==================================
                    // AGREGAR FILA
                    // ==================================
                    dgvEntrenadores.Rows.Add(

                        lector["IdEntrenador"],

                        lector["NombreCompleto"]
                            .ToString(),

                        edad,

                        lector["Telefono"]
                            .ToString(),

                        lector["Deportes"]
                            .ToString(),

                        estado,

                        lector["DeportistasActivos"]
                            .ToString()
                    );
                }


                lector.Close();

                dgvEntrenadores.ClearSelection();
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmRegistroEntrenadoresAdm frmVerCompetencias = new frmRegistroEntrenadoresAdm();

            frmVerCompetencias.TopLevel = false;
            frmVerCompetencias.FormBorderStyle = FormBorderStyle.None;
            frmVerCompetencias.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmVerCompetencias);

            frmVerCompetencias.Show();

            this.Close();
        }

        private void btnInactivar_Click(object sender, EventArgs e)
        {
            frmInactivarEntrenador frm = new frmInactivarEntrenador();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnRemplazar_Click(object sender, EventArgs e)
        {
            if (dgvEntrenadores
                .SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un entrenador de la tabla.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }


            int idEntrenador =
                Convert.ToInt32(
                    dgvEntrenadores
                    .SelectedRows[0]
                    .Cells["IdEntrenador"]
                    .Value);


            frmRemplazarEntrenador frm =
                new frmRemplazarEntrenador(
                    idEntrenador);

            frm.ShowDialog();


            // Actualizar después del reemplazo
            CargarEntrenadores();
        }

    }

}
