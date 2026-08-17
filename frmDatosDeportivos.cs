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

namespace wfZenova
{
    public partial class frmDatosDeportivos : Form
    {
        private int idDeportista;
        csConectaSQL conSQL = new csConectaSQL();
        public frmDatosDeportivos(int idDeportista)
        {
            InitializeComponent();

            this.idDeportista = idDeportista;

            dtpFechaMedicion.Value =
                DateTime.Today;

            CargarCategoriasEdad();
            CargarDeportista();

            CalcularCategoriaEdad();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarDeportista()
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                D.Nombres,
                D.Apellidos,
                D.FechaNacimiento,
                DEP.NombreDeporte
              FROM Deportistas D

              LEFT JOIN Inscripciones I
                    ON D.IdDeportista = I.IdDeportista
                    AND I.Estado = 'Activo'

              LEFT JOIN EntrenadorDeporte ED
                  ON I.IdEntrenadorDeporte =
                     ED.IdEntrenadorDeporte

              LEFT JOIN Deportes DEP
                  ON ED.IdDeporte =
                     DEP.IdDeporte

              WHERE
                  D.IdDeportista = " + idDeportista
                );

            if (tabla == null ||
                tabla.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró el deportista.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRow fila =
                tabla.Rows[0];

            lblNombreDeportista.Text =
                fila["Nombres"].ToString() +
                " " +
                fila["Apellidos"].ToString();

            if (fila["NombreDeporte"] != DBNull.Value)
            {
                lblDeporte.Text =
                    fila["NombreDeporte"].ToString();
            }
            else
            {
                lblDeporte.Text =
                    "Sin asignar";
            }

            if (fila["FechaNacimiento"] != DBNull.Value)
            {
                DateTime fechaNacimiento =
                    Convert.ToDateTime(fila["FechaNacimiento"]);

                DateTime fechaReferencia =
                    dtpFechaMedicion.Value.Date;

                int edad =
                    fechaReferencia.Year - fechaNacimiento.Year;

                if (fechaNacimiento.Date >
                    fechaReferencia.AddYears(-edad))
                {
                    edad--;
                }

                if (edad >= 5 && edad <= 11)
                {
                    cmbCategoriaEdad.SelectedItem =
                        "Infantil / Iniciación";
                }
                else if (edad >= 12 && edad <= 14)
                {
                    cmbCategoriaEdad.SelectedItem =
                        "Pre-Juvenil / Menores";
                }
                else if (edad >= 15 && edad <= 17)
                {
                    cmbCategoriaEdad.SelectedItem =
                        "Juvenil";
                }
                else if (edad >= 18 && edad <= 34)
                {
                    cmbCategoriaEdad.SelectedItem =
                        "Sénior / Abierta";
                }
                else if (edad >= 35)
                {
                    cmbCategoriaEdad.SelectedItem =
                        "Máster / Veteranos";
                }
                else
                {
                    cmbCategoriaEdad.SelectedIndex = -1;
                }
            }
        }
        private void CargarCategoriasEdad()
        {
            cmbCategoriaEdad.Items.Clear();

            cmbCategoriaEdad.Items.Add(
                "Infantil / Iniciación");

            cmbCategoriaEdad.Items.Add(
                "Pre-Juvenil / Menores");

            cmbCategoriaEdad.Items.Add(
                "Juvenil");

            cmbCategoriaEdad.Items.Add(
                "Sénior / Abierta");

            cmbCategoriaEdad.Items.Add(
                "Máster / Veteranos");

            cmbCategoriaEdad.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cmbCategoriaEdad.SelectedIndex = -1;
        }
        private bool ValidarPeso()
        {
            decimal peso;

            // Campo vacío
            if (txtPeso.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese el peso del deportista.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPeso.Focus();
                return false;
            }

            // Debe ser un número
            if (!decimal.TryParse(
                txtPeso.Text.Trim(),
                out peso))
            {
                MessageBox.Show(
                    "Ingrese un peso válido.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPeso.Focus();
                return false;
            }

            // No permitir cero ni negativos
            if (peso <= 0)
            {
                MessageBox.Show(
                    "El peso debe ser mayor a 0.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPeso.Focus();
                return false;
            }

            return true;
        }

        private void txtPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                return;

            // Permitir teclas como borrar
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir un solo separador decimal
            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                !txtPeso.Text.Contains(",") &&
                !txtPeso.Text.Contains("."))
            {
                return;
            }

            e.Handled = true;
        }
        private bool ValidarAltura()
        {
            decimal altura;

            // Campo vacío
            if (txtAltura.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Ingrese la altura del deportista.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAltura.Focus();
                return false;
            }

            // Aceptar punto o coma decimal
            string textoAltura =
                txtAltura.Text.Trim().Replace('.', ',');

            // Debe ser un número
            if (!decimal.TryParse(
                textoAltura,
                out altura))
            {
                MessageBox.Show(
                    "Ingrese una altura válida en metros.\nEjemplo: 1,62",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAltura.Focus();
                return false;
            }

            // No permitir cero ni negativos
            if (altura <= 0)
            {
                MessageBox.Show(
                    "La altura debe ser mayor a 0.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAltura.Focus();
                return false;
            }

            return true;
        }

        private void txtAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                return;

            // Borrar, Ctrl+C, etc.
            if (char.IsControl(e.KeyChar))
                return;

            // Un solo separador decimal
            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                !txtAltura.Text.Contains(",") &&
                !txtAltura.Text.Contains("."))
            {
                return;
            }

            e.Handled = true;
        }
        private bool ValidarCampos()
        {
            // FECHA
            if (!ValidarFechaMedicion())
                return false;

            // PESO
            if (!ValidarPeso())
                return false;

            // ALTURA
            if (!ValidarAltura())
                return false;

            // CATEGORÍA POR EDAD
            if (cmbCategoriaEdad.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Seleccione la categoría por edad.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCategoriaEdad.Focus();
                return false;
            }

            // CATEGORÍA / DIVISIÓN POR PESO
            // Por ahora es opcional, porque no aplica igual
            // para todos los deportes.

            return true;
        }
        private bool ValidarFechaMedicion()
        {
            DateTime fecha =
                dtpFechaMedicion.Value.Date;

            if (fecha > DateTime.Today)
            {
                MessageBox.Show(
                    "La fecha de medición no puede ser futura.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtpFechaMedicion.Focus();
                return false;
            }

            return true;
        }
        private void CalcularCategoriaEdad()
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT FechaNacimiento
              FROM Deportistas
              WHERE IdDeportista = " + idDeportista
                );

            if (tabla == null ||
                tabla.Rows.Count == 0)
            {
                cmbCategoriaEdad.SelectedIndex = -1;
                return;
            }

            DataRow fila =
                tabla.Rows[0];

            if (fila["FechaNacimiento"] == DBNull.Value)
            {
                cmbCategoriaEdad.SelectedIndex = -1;
                return;
            }

            DateTime fechaNacimiento =
                Convert.ToDateTime(
                    fila["FechaNacimiento"]);

            DateTime fechaReferencia =
                dtpFechaMedicion.Value.Date;

            int edad =
                fechaReferencia.Year -
                fechaNacimiento.Year;

            if (fechaNacimiento.Date >
                fechaReferencia.AddYears(-edad))
            {
                edad--;
            }

            if (edad >= 5 && edad <= 11)
            {
                cmbCategoriaEdad.SelectedItem =
                    "Infantil / Iniciación";
            }
            else if (edad >= 12 && edad <= 14)
            {
                cmbCategoriaEdad.SelectedItem =
                    "Pre-Juvenil / Menores";
            }
            else if (edad >= 15 && edad <= 17)
            {
                cmbCategoriaEdad.SelectedItem =
                    "Juvenil";
            }
            else if (edad >= 18 && edad <= 34)
            {
                cmbCategoriaEdad.SelectedItem =
                    "Sénior / Abierta";
            }
            else if (edad >= 35)
            {
                cmbCategoriaEdad.SelectedItem =
                    "Máster / Veteranos";
            }
            else
            {
                cmbCategoriaEdad.SelectedIndex = -1;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                // ==========================================
                // FECHA
                // ==========================================
                string fechaMedicion =
                    dtpFechaMedicion.Value
                    .ToString("yyyy-MM-dd");


                // ==========================================
                // PESO
                // ==========================================
                decimal peso;

                string textoPeso =
                    txtPeso.Text.Trim()
                    .Replace(".", ",");

                decimal.TryParse(
                    textoPeso,
                    out peso);


                // ==========================================
                // ALTURA
                // ==========================================
                decimal altura;

                string textoAltura =
                    txtAltura.Text.Trim()
                    .Replace(".", ",");

                decimal.TryParse(
                    textoAltura,
                    out altura);


                // ==========================================
                // CATEGORÍA POR EDAD
                // ==========================================
                string categoriaEdad =
                    cmbCategoriaEdad.Text.Trim();


                // ==========================================
                // DIVISIÓN POR PESO
                // Puede quedar NULL
                // ==========================================
                string divisionPeso = "NULL";

                if (cmbCategoriaPeso.SelectedIndex != -1 &&
                    cmbCategoriaPeso.Text.Trim() != "")
                {
                    divisionPeso =
                        "'" +
                        cmbCategoriaPeso.Text
                        .Trim()
                        .Replace("'", "''") +
                        "'";
                }


                // ==========================================
                // CAMPOS
                // ==========================================
                string campos =
                    "IdDeportista, " +
                    "FechaMedicion, " +
                    "Peso, " +
                    "Altura, " +
                    "CategoriaEdad, " +
                    "DivisionPeso";


                // ==========================================
                // DATOS
                // ==========================================
                string datos =
                    idDeportista + "," +

                    "'" +
                    fechaMedicion +
                    "'," +

                    peso.ToString(
                        System.Globalization
                        .CultureInfo.InvariantCulture) +
                    "," +

                    altura.ToString(
                        System.Globalization
                        .CultureInfo.InvariantCulture) +
                    "," +

                    "'" +
                    categoriaEdad
                    .Replace("'", "''") +
                    "'," +

                    divisionPeso;


                // ==========================================
                // GUARDAR EN SQL
                // ==========================================
                if (conSQL.insertDatos(
                    "MedicionesDeportista",
                    campos,
                    datos))
                {
                    MessageBox.Show(
                        "Los datos deportivos se registraron correctamente.",
                        "ZENOVA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al guardar los datos deportivos:\n\n" +
                    ex.Message,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dtpFechaMedicion_ValueChanged(object sender, EventArgs e)
        {
            CalcularCategoriaEdad();
        }
    }
}
