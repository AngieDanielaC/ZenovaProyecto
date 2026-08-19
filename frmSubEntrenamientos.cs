using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class frmSubEntrenamientos : Form
    {
        private csConectaSQL bd = new csConectaSQL();

        public frmSubEntrenamientos()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmSubEntrenamientos_Load);
        }

        private void frmSubEntrenamientos_Load(object sender, EventArgs e)
        {
            CargarDeportistas();
            ConfigurarColumnasDgvEjercicios();
        }

        private void CargarDeportistas()
        {
            DataTable dt = bd.RetornaRegistros("SELECT IdDeportista, Nombres + ' ' + Apellidos AS NombreCompleto FROM Deportistas WHERE Estado = 'Activo'");
            if (dt != null)
            {
                checkedListBox3.DataSource = dt;
                checkedListBox3.DisplayMember = "NombreCompleto";
                checkedListBox3.ValueMember = "IdDeportista";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarEjercicio modal = new AgregarEjercicio();
            if (modal.ShowDialog() == DialogResult.OK)
            {
                dgvEjercicios.Rows.Add(
                    modal.NombreEjercicio,
                    modal.Series,
                    modal.Repeticiones,
                    modal.Peso
                );
                ActualizarContadorEjercicios();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvEjercicios.CurrentRow != null && !dgvEjercicios.CurrentRow.IsNewRow)
            {
                dgvEjercicios.Rows.Remove(dgvEjercicios.CurrentRow);
                ActualizarContadorEjercicios();
            }
            else
            {
                MessageBox.Show("Seleccione una fila válida para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ActualizarContadorEjercicios()
        {
            int total = dgvEjercicios.Rows.Count;
            if (dgvEjercicios.AllowUserToAddRows && total > 0) total--;
            label7.Text = "Total ejercicios: " + total;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkedListBox3.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un deportista de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvEjercicios.Rows.Count == 0 || (dgvEjercicios.AllowUserToAddRows && dgvEjercicios.Rows.Count == 1))
            {
                MessageBox.Show("Debe agregar al menos un ejercicio a la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEntrenadorDep = 1; 
            string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
            string hora = cboHoraInicio.Text;
            int duracion = string.IsNullOrEmpty(txtDuracion.Text) ? 0 : Convert.ToInt32(txtDuracion.Text);
            string tipo = cboTipoEntrenamiento.Text;
            string objetivo = txtObjetivo.Text;
            string estado = chkCompletado.Text; 

            int rpe = ObtenerNivelEsfuerzo();

            int tieneDolor = radioButton11.Checked ? 1 : 0;
            string zonaDolor = comboBox7.Text;
            string comentario = label19.Text;
            string observaciones = t.Text;

            string camposSesion = "IdDeportista, IdEntrenadorDeporte, Fecha, HoraInicio, Duracion, TipoEntrenamiento, Objetivo, Estado, NivelEsfuerzo, TieneDolor, ZonaDolor, ComentarioMolestia, Observaciones";

            foreach (var item in checkedListBox3.CheckedItems)
            {
                DataRowView filaDeportista = (DataRowView)item;
                int idDeportista = Convert.ToInt32(filaDeportista["IdDeportista"]);

                string valoresSesion = $"{idDeportista}, {idEntrenadorDep}, '{fecha}', '{hora}', {duracion}, '{tipo}', '{objetivo}', '{estado}', {rpe}, {tieneDolor}, '{zonaDolor}', '{comentario}', '{observaciones}'";

                if (bd.insertDatos("SesionesEntrenamiento", camposSesion, valoresSesion))
                {
                    DataTable dtMax = bd.RetornaRegistros("SELECT MAX(IdSesion) AS UltimoId FROM SesionesEntrenamiento");
                    if (dtMax != null && dtMax.Rows.Count > 0)
                    {
                        int idSesionGenerada = Convert.ToInt32(dtMax.Rows[0]["UltimoId"]);

                        foreach (DataGridViewRow filaGrid in dgvEjercicios.Rows)
                        {
                            if (filaGrid.IsNewRow) continue;

                            string nomEj = filaGrid.Cells["colNombre"].Value?.ToString() ?? "";
                            int seriesEj = Convert.ToInt32(filaGrid.Cells["colSeries"].Value ?? 0);
                            int repsEj = Convert.ToInt32(filaGrid.Cells["colRepeticiones"].Value ?? 0);
                            decimal pesoEj = Convert.ToDecimal(filaGrid.Cells["colPeso"].Value ?? 0);

                            string camposEj = "IdSesion, NombreEjercicio, Series, Repeticiones, CargaPeso";
                            string valoresEj = $"{idSesionGenerada}, '{nomEj}', {seriesEj}, {repsEj}, {pesoEj}";

                            bd.insertDatos("EjerciciosSesion", camposEj, valoresEj);
                        }
                    }
                }
            }

            MessageBox.Show("¡Entrenamiento registrado correctamente para todos los deportistas seleccionados!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarFormulario();
        }

        private int ObtenerNivelEsfuerzo()
        {
            if (radioButton1.Checked) return 1;
            if (radioButton2.Checked) return 2;
            if (radioButton3.Checked) return 3;
            if (radioButton4.Checked) return 4;
            if (radioButton5.Checked) return 5;
            if (radioButton6.Checked) return 6;
            if (radioButton7.Checked) return 7;
            if (radioButton8.Checked) return 8;
            if (radioButton9.Checked) return 9;
            if (radioButton10.Checked) return 10;
            return 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LimpiarFormulario()
        {
            dgvEjercicios.Rows.Clear();
            txtObjetivo.Clear();
            txtDuracion.SelectedIndex = -1;
            cboHoraInicio.SelectedIndex = -1;
            cboTipoEntrenamiento.SelectedIndex = -1;
            comboBox7.SelectedIndex = -1;
            label19.Text = "Texto...";
            t.Text = "Texto...";
            ActualizarContadorEjercicios();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void ConfigurarColumnasDgvEjercicios()
        {
            dgvEjercicios.Columns.Clear();

            dgvEjercicios.Columns.Add("colNombre", "Ejercicio");
            dgvEjercicios.Columns.Add("colSeries", "Series");
            dgvEjercicios.Columns.Add("colRepeticiones", "Repeticiones");
            dgvEjercicios.Columns.Add("colPeso", "Peso (Kg)");

            dgvEjercicios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEjercicios.AllowUserToAddRows = false; 
        }
    }
}