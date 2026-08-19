using System;
using System.Data;
using System.Data.SqlClient;
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
            // Nota: this.Load ya se suscribe en el Designer (this.Load += ...frmSubEntrenamientos_Load).
            // Se elimina la suscripción duplicada que había aquí originalmente.

            // Botones que no tenían su evento cableado en el Designer:
            this.button2.Click += new EventHandler(button2_Click);
            this.button3.Click += new EventHandler(button3_Click);
            this.button5.Click += new EventHandler(button5_Click);
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
                if (!ValidarNumericos(modal.Series, modal.Repeticiones, modal.Peso))
                    return;

                dgvEjercicios.Rows.Add(
                    modal.NombreEjercicio,
                    modal.Series,
                    modal.Repeticiones,
                    modal.Peso
                );
                ActualizarContadorEjercicios();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvEjercicios.CurrentRow == null || dgvEjercicios.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Seleccione una fila válida para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow fila = dgvEjercicios.CurrentRow;

            string nombreActual = fila.Cells["colNombre"].Value?.ToString() ?? "";
            string seriesActual = fila.Cells["colSeries"].Value?.ToString() ?? "";
            string repsActual = fila.Cells["colRepeticiones"].Value?.ToString() ?? "";
            string pesoActual = fila.Cells["colPeso"].Value?.ToString() ?? "";

            AgregarEjercicio modal = new AgregarEjercicio(nombreActual, seriesActual, repsActual, pesoActual);

            if (modal.ShowDialog() == DialogResult.OK)
            {
                if (!ValidarNumericos(modal.Series, modal.Repeticiones, modal.Peso))
                    return;

                fila.Cells["colNombre"].Value = modal.NombreEjercicio;
                fila.Cells["colSeries"].Value = modal.Series;
                fila.Cells["colRepeticiones"].Value = modal.Repeticiones;
                fila.Cells["colPeso"].Value = modal.Peso;
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

        private bool ValidarNumericos(string series, string repeticiones, string peso)
        {
            if (!int.TryParse(series, out _))
            {
                MessageBox.Show("El campo 'Series' debe ser un número entero.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrWhiteSpace(repeticiones) && !int.TryParse(repeticiones, out _))
            {
                MessageBox.Show("El campo 'Repeticiones' debe ser un número entero.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(peso, out _))
            {
                MessageBox.Show("El campo 'Peso' debe ser un número.", "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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

            if (frmInicioDeSesion.IdEntrenadorActual == null)
            {
                MessageBox.Show("La sesión actual no está asociada a un entrenador. No se puede registrar el entrenamiento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEntrenadorDep = frmInicioDeSesion.IdEntrenadorActual.Value;

            DateTime fecha = dtpFecha.Value.Date;
            string hora = cboHoraInicio.Text;
            int duracion = string.IsNullOrEmpty(txtDuracion.Text) ? 0 : Convert.ToInt32(txtDuracion.Text);
            string tipo = cboTipoEntrenamiento.Text;
            string objetivo = txtObjetivo.Text;

            string estado = chkCompletado.CheckedItems.Count > 0
                ? chkCompletado.CheckedItems[0].ToString()
                : "Incompleto";

            int rpe = ObtenerNivelEsfuerzo();

            int tieneDolor = radioButton11.Checked ? 1 : 0;
            string zonaDolor = comboBox7.Text;
            string comentario = label19.Text;
            string observaciones = t.Text;

            string sentenciaSesion = @"INSERT INTO SesionesEntrenamiento
                (IdDeportista, IdEntrenadorDeporte, Fecha, HoraInicio, Duracion, TipoEntrenamiento, Objetivo, Estado, NivelEsfuerzo, TieneDolor, ZonaDolor, ComentarioMolestia, Observaciones)
                VALUES
                (@IdDeportista, @IdEntrenadorDeporte, @Fecha, @HoraInicio, @Duracion, @TipoEntrenamiento, @Objetivo, @Estado, @NivelEsfuerzo, @TieneDolor, @ZonaDolor, @ComentarioMolestia, @Observaciones);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            string sentenciaEjercicio = @"INSERT INTO EjerciciosSesion
                (IdSesion, NombreEjercicio, Series, Repeticiones, CargaPeso)
                VALUES
                (@IdSesion, @NombreEjercicio, @Series, @Repeticiones, @CargaPeso)";

            int sesionesCreadas = 0;

            foreach (var item in checkedListBox3.CheckedItems)
            {
                DataRowView filaDeportista = (DataRowView)item;
                int idDeportista = Convert.ToInt32(filaDeportista["IdDeportista"]);

                SqlParameter[] paramsSesion = new SqlParameter[]
                {
                    new SqlParameter("@IdDeportista", SqlDbType.Int) { Value = idDeportista },
                    new SqlParameter("@IdEntrenadorDeporte", SqlDbType.Int) { Value = idEntrenadorDep },
                    new SqlParameter("@Fecha", SqlDbType.Date) { Value = fecha },
                    new SqlParameter("@HoraInicio", SqlDbType.NVarChar, 50) { Value = string.IsNullOrEmpty(hora) ? (object)DBNull.Value : hora },
                    new SqlParameter("@Duracion", SqlDbType.Int) { Value = duracion },
                    new SqlParameter("@TipoEntrenamiento", SqlDbType.NVarChar, 100) { Value = string.IsNullOrEmpty(tipo) ? (object)DBNull.Value : tipo },
                    new SqlParameter("@Objetivo", SqlDbType.NVarChar, 200) { Value = string.IsNullOrEmpty(objetivo) ? (object)DBNull.Value : objetivo },
                    new SqlParameter("@Estado", SqlDbType.NVarChar, 50) { Value = estado },
                    new SqlParameter("@NivelEsfuerzo", SqlDbType.Int) { Value = rpe },
                    new SqlParameter("@TieneDolor", SqlDbType.Bit) { Value = tieneDolor },
                    new SqlParameter("@ZonaDolor", SqlDbType.NVarChar, 100) { Value = string.IsNullOrEmpty(zonaDolor) ? (object)DBNull.Value : zonaDolor },
                    new SqlParameter("@ComentarioMolestia", SqlDbType.NVarChar, -1) { Value = string.IsNullOrEmpty(comentario) || comentario == "Texto..." ? (object)DBNull.Value : comentario },
                    new SqlParameter("@Observaciones", SqlDbType.NVarChar, -1) { Value = string.IsNullOrEmpty(observaciones) || observaciones == "Texto..." ? (object)DBNull.Value : observaciones }
                };

                object resultado = bd.EjecutaEscalarParametros(sentenciaSesion, paramsSesion);

                if (resultado == null || resultado == DBNull.Value)
                {
                    MessageBox.Show($"No se pudo registrar la sesión para el deportista con Id {idDeportista}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                int idSesionGenerada = Convert.ToInt32(resultado);
                sesionesCreadas++;

                foreach (DataGridViewRow filaGrid in dgvEjercicios.Rows)
                {
                    if (filaGrid.IsNewRow) continue;

                    string nomEj = filaGrid.Cells["colNombre"].Value?.ToString() ?? "";
                    int seriesEj = Convert.ToInt32(filaGrid.Cells["colSeries"].Value ?? 0);
                    int repsEj = Convert.ToInt32(filaGrid.Cells["colRepeticiones"].Value ?? 0);
                    decimal pesoEj = Convert.ToDecimal(filaGrid.Cells["colPeso"].Value ?? 0);

                    SqlParameter[] paramsEjercicio = new SqlParameter[]
                    {
                        new SqlParameter("@IdSesion", SqlDbType.Int) { Value = idSesionGenerada },
                        new SqlParameter("@NombreEjercicio", SqlDbType.NVarChar, 150) { Value = nomEj },
                        new SqlParameter("@Series", SqlDbType.Int) { Value = seriesEj },
                        new SqlParameter("@Repeticiones", SqlDbType.Int) { Value = repsEj },
                        new SqlParameter("@CargaPeso", SqlDbType.Decimal) { Value = pesoEj }
                    };

                    bd.EjecutaSentenciaParametros(sentenciaEjercicio, paramsEjercicio);
                }
            }

            if (sesionesCreadas > 0)
            {
                MessageBox.Show("¡Entrenamiento registrado correctamente para los deportistas seleccionados!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
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

            dtpFecha.Value = DateTime.Now;

            for (int i = 0; i < checkedListBox3.Items.Count; i++)
            {
                checkedListBox3.SetItemChecked(i, false);
            }

            for (int i = 0; i < chkCompletado.Items.Count; i++)
            {
                chkCompletado.SetItemChecked(i, false);
            }

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;

            radioButton12.Checked = true; 

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