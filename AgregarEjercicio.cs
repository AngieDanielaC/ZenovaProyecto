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

        public AgregarEjercicio()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor ingrese al menos el nombre y las series del ejercicio.");
                return;
            }

            NombreEjercicio = textBox1.Text;
            Series = textBox2.Text;
            Repeticiones = textBox4.Text;
            Peso = string.IsNullOrWhiteSpace(textBox3.Text) ? "0" : textBox3.Text;

            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
