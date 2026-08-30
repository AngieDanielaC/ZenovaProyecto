using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class AgregarEjercicio : Form
    {
        public string NombreEjercicio { get; private set; }
        public string Series { get; private set; }
        public string Repeticiones { get; private set; }
        public string Peso { get; private set; }

        //Agregar ejercicio
        public AgregarEjercicio()
        {
            InitializeComponent();
        }

        //Editar ejercicio
        public AgregarEjercicio(string nombre, string series, string repeticiones, string peso) : this()
        {
            textBox1.Text = nombre;
            textBox2.Text = series;
            textBox4.Text = repeticiones;
            textBox3.Text = peso;

            button4.Text = "Guardar cambios";
            this.Text = "Editar ejercicio";
        }

        //Guardar ejercicio
        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show(
                    "Debe ingresar el nombre del ejercicio.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show(
                    "Debe ingresar las series.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            //Validar series
            if (!int.TryParse(textBox2.Text, out int series))
            {
                MessageBox.Show(
                    "Las series deben ser un número entero.",
                    "Dato inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            //Validar repeticiones
            if (!string.IsNullOrWhiteSpace(textBox4.Text) &&
                !int.TryParse(textBox4.Text, out int repeticiones))
            {
                MessageBox.Show(
                    "Las repeticiones deben ser un número entero.",
                    "Dato inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            //Validar peso
            if (!string.IsNullOrWhiteSpace(textBox3.Text) &&
                !decimal.TryParse(textBox3.Text, out decimal peso))
            {
                MessageBox.Show(
                    "El peso debe ser un número.",
                    "Dato inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            NombreEjercicio = textBox1.Text.Trim();
            Series = textBox2.Text.Trim();

            Repeticiones = string.IsNullOrWhiteSpace(textBox4.Text)
                ? "0"
                : textBox4.Text.Trim();

            Peso = string.IsNullOrWhiteSpace(textBox3.Text)
                ? "0"
                : textBox3.Text.Trim();

            //Solo llega aquí si todo está correcto
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //Cancelar
        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}