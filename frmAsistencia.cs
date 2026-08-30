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
    public partial class frmAsistencia : Form
    {
        private csConectaSQL conSQL = new csConectaSQL();
        private int idEntrenador;
        public frmAsistencia()
        {
            InitializeComponent();
        }

        private void frmAsistencia_Load(object sender, EventArgs e)
        {
            ConfigurarDgvAsistencia(dgvAsistencia);
            ConfigurarDgvPorcentaje(dgvPorcentaje);

            CargarDeportistas();
        }

        //Configurar DataGridView de asistencia
        private void ConfigurarDgvAsistencia(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(235, 235, 235);

            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;

            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.RowTemplate.Height = 45;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#333FDD");
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Century Gothic", 11F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersHeight = 45;
            dgv.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(25, 30, 60);
            dgv.DefaultCellStyle.Font =
                new Font("Century Gothic", 10F, FontStyle.Regular);
            dgv.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);
            dgv.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 30, 60);

            //Id del deportista
            DataGridViewTextBoxColumn colIdDeportista =
                new DataGridViewTextBoxColumn();

            colIdDeportista.Name = "colIdDeportista";
            colIdDeportista.HeaderText = "ID";
            colIdDeportista.Visible = false;
            colIdDeportista.ReadOnly = true;

            //Número
            DataGridViewTextBoxColumn colNumero =
                new DataGridViewTextBoxColumn();

            colNumero.Name = "colNumero";
            colNumero.HeaderText = "N#";
            colNumero.FillWeight = 15;
            colNumero.ReadOnly = true;

            //Nombre del deportista
            DataGridViewTextBoxColumn colNombre =
                new DataGridViewTextBoxColumn();

            colNombre.Name = "colNombre";
            colNombre.HeaderText = "Nombre";
            colNombre.FillWeight = 60;
            colNombre.ReadOnly = true;

            //Marcar asistencia
            DataGridViewCheckBoxColumn colMarcar =
                new DataGridViewCheckBoxColumn();

            colMarcar.Name = "colMarcar";
            colMarcar.HeaderText = "Marcar";
            colMarcar.FillWeight = 25;
            colMarcar.ReadOnly = false;

            dgv.ReadOnly = false;

            dgv.Columns.Add(colIdDeportista);
            dgv.Columns.Add(colNumero);
            dgv.Columns.Add(colNombre);
            dgv.Columns.Add(colMarcar);

            foreach (DataGridViewColumn columna in dgv.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgv.ClearSelection();
        }

        //Configurar DataGridView de porcentaje de asistencia
        private void ConfigurarDgvPorcentaje(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(235, 235, 235);

            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;

            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.RowTemplate.Height = 45;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                ColorTranslator.FromHtml("#333FDD");

            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font("Century Gothic", 11F, FontStyle.Bold);

            dgv.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersHeight = 45;

            dgv.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(25, 30, 60);

            dgv.DefaultCellStyle.Font =
                new Font("Century Gothic", 10F, FontStyle.Regular);

            dgv.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 238, 255);

            dgv.DefaultCellStyle.SelectionForeColor =
                Color.FromArgb(25, 30, 60);

            //Nombre del deportista
            DataGridViewTextBoxColumn colNombre =
                new DataGridViewTextBoxColumn();

            colNombre.Name = "colNombre";
            colNombre.HeaderText = "Nombre";
            colNombre.FillWeight = 60;

            //Porcentaje acumulado
            DataGridViewTextBoxColumn colPorcentaje =
                new DataGridViewTextBoxColumn();

            colPorcentaje.Name = "colPorcentaje";
            colPorcentaje.HeaderText = "Porcentaje";
            colPorcentaje.FillWeight = 40;

            dgv.Columns.Add(colNombre);
            dgv.Columns.Add(colPorcentaje);

            foreach (DataGridViewColumn columna in dgv.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgv.ClearSelection();
        }

        //Cargar deportistas asignados al entrenador
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

            DataTable dt = conSQL.RetornaRegistros($@"
            SELECT DISTINCT
                D.IdDeportista,
                D.Nombres + ' ' + D.Apellidos AS NombreCompleto
            FROM Deportistas D

            INNER JOIN Inscripciones I
                ON D.IdDeportista = I.IdDeportista

            INNER JOIN EntrenadorDeporte ED
                ON I.IdEntrenadorDeporte = ED.IdEntrenadorDeporte

            WHERE ED.IdEntrenador = {idEntrenador}
                AND D.Estado = 1
                AND ED.Activo = 1
                AND I.Estado <> 'Finalizado'

            ORDER BY NombreCompleto");

            dgvAsistencia.Rows.Clear();

            int numero = 1;

            foreach (DataRow fila in dt.Rows)
            {
                dgvAsistencia.Rows.Add(
                    fila["IdDeportista"],
                    numero,
                    fila["NombreCompleto"],
                    false
                );

                numero++;
            }

            dgvAsistencia.ClearSelection();
        }

        //Guardar asistencia
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validar entrenador
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

            //Validar que existan deportistas
            if (dgvAsistencia.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No hay deportistas para registrar asistencia.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int idEntrenador =
                frmInicioDeSesion.IdEntrenadorActual.Value;

            DateTime fecha = DateTime.Today;

            foreach (DataGridViewRow fila in dgvAsistencia.Rows)
            {
                int idDeportista = Convert.ToInt32(
                    fila.Cells["colIdDeportista"].Value
                );

                bool presente = false;

                if (fila.Cells["colMarcar"].Value != null)
                {
                    presente = Convert.ToBoolean(
                        fila.Cells["colMarcar"].Value
                    );
                }

                string sentencia = @"
            IF EXISTS
            (
                SELECT 1
                FROM Asistencias
                WHERE IdDeportista = @IdDeportista
                AND IdEntrenador = @IdEntrenador
                AND Fecha = @Fecha
            )
            BEGIN

                UPDATE Asistencias
                SET Presente = @Presente
                WHERE IdDeportista = @IdDeportista
                AND IdEntrenador = @IdEntrenador
                AND Fecha = @Fecha

            END
            ELSE
            BEGIN

                INSERT INTO Asistencias
                (
                    IdDeportista,
                    IdEntrenador,
                    Fecha,
                    Presente
                )
                VALUES
                (
                    @IdDeportista,
                    @IdEntrenador,
                    @Fecha,
                    @Presente
                )

            END";

                SqlParameter[] parametros =
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

            new SqlParameter("@Presente", SqlDbType.Bit)
            {
                Value = presente
            }
        };

                conSQL.EjecutaSentenciaParametros(
                    sentencia,
                    parametros
                );
            }

            MessageBox.Show(
                "Asistencia guardada correctamente.",
                "Asistencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

    }
}
