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
        csConectaSQL conSQL = new csConectaSQL();

        public frmDepAdm()
        {
            InitializeComponent();
            ConfigurarTablaDeportistas();

        }
        private void ConfigurarTablaDeportistas()
        {

            dgvDeportistas.DataSource = null;
            dgvDeportistas.Columns.Clear();
            dgvDeportistas.AutoGenerateColumns = false;

            // ID OCULTO
            dgvDeportistas.Columns.Add(
                "IdDeportista",
                "ID");

            dgvDeportistas.Columns["IdDeportista"].DataPropertyName =
                "IdDeportista";

            dgvDeportistas.Columns["IdDeportista"].Visible = false;

            // FOTO
            DataGridViewImageColumn colFoto =
                new DataGridViewImageColumn();

            colFoto.Name = "Foto";
            colFoto.HeaderText = "FOTO";
            colFoto.DataPropertyName = "Foto";
            colFoto.ImageLayout =
                DataGridViewImageCellLayout.Zoom;

            dgvDeportistas.Columns.Add(colFoto);
            // NOMBRE
            dgvDeportistas.Columns.Add(
                "Nombre",
                "NOMBRE COMPLETO");

            dgvDeportistas.Columns["Nombre"].DataPropertyName =
                "Nombre";

            // CÉDULA
            dgvDeportistas.Columns.Add(
                "Cedula",
                "CÉDULA");

            dgvDeportistas.Columns["Cedula"].DataPropertyName =
                "Cedula";

            // EDAD
            dgvDeportistas.Columns.Add(
                "Edad",
                "EDAD");

            dgvDeportistas.Columns["Edad"].DataPropertyName =
                "Edad";

            // GÉNERO
            dgvDeportistas.Columns.Add(
                "Genero",
                "GÉNERO");

            dgvDeportistas.Columns["Genero"].DataPropertyName =
                "Genero";

            // TELÉFONO
            dgvDeportistas.Columns.Add(
                "Telefono",
                "TELÉFONO");

            dgvDeportistas.Columns["Telefono"].DataPropertyName =
                "Telefono";

            // ESTADO
            dgvDeportistas.Columns.Add(
                "Estado",
                "ESTADO");

            dgvDeportistas.Columns["Estado"].DataPropertyName =
                "Estado";
            // CONFIGURACIÓN GENERAL
            dgvDeportistas.BackgroundColor = Color.White;
            dgvDeportistas.BorderStyle = BorderStyle.None;

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
            // ENCABEZADO
            dgvDeportistas.EnableHeadersVisualStyles = false;

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
            // ESTILO DE FILAS
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

            dgvDeportistas.RowTemplate.Height = 60;
            // TAMAÑO DE COLUMNAS
            dgvDeportistas.Columns["Foto"].FillWeight = 50;
            dgvDeportistas.Columns["Nombre"].FillWeight = 150;
            dgvDeportistas.Columns["Cedula"].FillWeight = 90;
            dgvDeportistas.Columns["Edad"].FillWeight = 55;
            dgvDeportistas.Columns["Genero"].FillWeight = 75;
            dgvDeportistas.Columns["Telefono"].FillWeight = 90;
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

            dgvDeportistas.Columns["Genero"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.Columns["Telefono"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.Columns["Estado"]
                .DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvDeportistas.ClearSelection();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmRegistroDeportistaAdm formulario = new frmRegistroDeportistaAdm();

            formulario.ShowDialog();

            CargarDeportistas("");
        }
      
        
        private void frmDepAdm_Load(object sender, EventArgs e)
        {
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbEstado.SelectedIndex = 0;

            CargarDeportistas("");
        }

        private void CargarDeportistas(string texto)
        {
            texto = texto.Trim().Replace("'", "''");

            string consulta =
                "select IdDeportista, Foto, " +
                "Nombres + ' ' + Apellidos as Nombre, Cedula, " +
                "datediff(year, FechaNacimiento, getdate()) - " +
                "case when dateadd(year, " +
                "datediff(year, FechaNacimiento, getdate()), " +
                "FechaNacimiento) > getdate() " +
                "then 1 else 0 end as Edad, " +
                "Genero, Telefono, " +
                "case when Estado = 1 " +
                "then 'Activo' else 'Inactivo' end as Estado " +
                "from Deportistas ";

            List<string> condiciones = new List<string>();

            if (texto.Length > 0)
            {
                condiciones.Add(
                    "(Nombres like '%" + texto + "%' " +
                    "or Apellidos like '%" + texto + "%' " +
                    "or Cedula like '%" + texto + "%')");
            }

            if (cmbEstado.SelectedIndex == 1)
            {
                condiciones.Add("Estado = 1");
            }
            else if (cmbEstado.SelectedIndex == 2)
            {
                condiciones.Add("Estado = 0");
            }

            if (condiciones.Count > 0)
            {
                consulta +=
                    "where " +
                    string.Join(" and ", condiciones) + " ";
            }

            consulta += "order by Nombres, Apellidos";

            dgvDeportistas.DataSource = conSQL.RetornaRegistros(consulta);
            dgvDeportistas.ClearSelection();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dgvDeportistas.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un deportista para visualizarlo.",
                    "Sin selección",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataGridViewRow fila = dgvDeportistas.SelectedRows[0];

            int idDeportista = Convert.ToInt32( fila.Cells["IdDeportista"].Value);

            using (frmVerDeportista formulario = new frmVerDeportista(idDeportista))
            {
                formulario.ShowDialog(this);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDeportistas.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un deportista para editarlo.",
                    "Sin selección",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            DataGridViewRow fila = dgvDeportistas.SelectedRows[0];

            int idDeportista = Convert.ToInt32(fila.Cells["IdDeportista"].Value);

            using (frmEditarDeportista formulario = new frmEditarDeportista(idDeportista))
            {
                formulario.ShowDialog(this);
            }

            CargarDeportistas(txtBuscar.Text);
        }

        private void btnAcDes_Click(object sender, EventArgs e)
        {
            if (dgvDeportistas.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un deportista.",
                    "Sin selección",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }
            DataGridViewRow fila = dgvDeportistas.SelectedRows[0];

            int idDeportista = Convert.ToInt32(fila.Cells["IdDeportista"].Value);

            string estadoActual =  fila.Cells["Estado"].Value.ToString();

            bool nuevoEstado = estadoActual == "Inactivo";

            string accion = nuevoEstado ? "activar" : "desactivar";

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea " + accion +
                " a este deportista?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes)
                return;

            bool actualizado;

            if (!nuevoEstado)
            {
                using (frmMotivoDesactivacion formulario = new frmMotivoDesactivacion())
                {
                    if (formulario.ShowDialog() != DialogResult.OK)
                        return;

                    string sentencia =
                        "update Deportistas " +
                        "set Estado = 0, " +
                        "MotivoDesactivacion = @Motivo, " +
                        "FechaDesactivacion = getdate() " +
                        "where IdDeportista = @IdDeportista";

                    actualizado = conSQL.EjecutaSentenciaParametros(sentencia,

                    new SqlParameter( "@Motivo",SqlDbType.NVarChar,250)
                    {
                        Value = formulario.Motivo
                    },

                    new SqlParameter( "@IdDeportista", SqlDbType.Int)
                    {
                        Value = idDeportista
                    }
                    );
                }
            }
            else
            {
                string sentencia =
                    "update Deportistas " +
                    "set Estado = 1, " +
                    "MotivoDesactivacion = null, " +
                    "FechaDesactivacion = null " +
                    "where IdDeportista = @IdDeportista";

                actualizado = conSQL.EjecutaSentenciaParametros( sentencia,
                        new SqlParameter( "@IdDeportista", SqlDbType.Int)
                        {
                            Value = idDeportista
                        }
                );
            }
            if (actualizado)
            {
                MessageBox.Show( "El deportista fue " +
                    (nuevoEstado ? "activado" : "desactivado") +
                    " correctamente.",
                    "Estado actualizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarDeportistas(txtBuscar.Text);
            }
        }



        

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            CargarDeportistas(txtBuscar.Text);
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDeportistas(txtBuscar.Text);
        }
    }
}
