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
    public partial class frmMotivoDesactivacion : Form
    {
        public string Motivo { get; private set; }
        public frmMotivoDesactivacion()
        {
            InitializeComponent();
            Motivo = "";
        }

        private void frmMotivoDesactivacion_Load(object sender, EventArgs e)
        {

        }

        private void btnConfir_Click(object sender, EventArgs e)
        {
            string motivoEscrito = txtMotivo.Text.Trim();

            if (string.IsNullOrWhiteSpace(motivoEscrito))
            {
                MessageBox.Show(
                    "Debe escribir el motivo de la desactivación.",
                    "Motivo obligatorio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMotivo.Focus();
                return;
            }

            Motivo = motivoEscrito;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
