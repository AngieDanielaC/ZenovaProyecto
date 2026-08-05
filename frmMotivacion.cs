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
    public partial class frmMotivacion : Form
    {
        public frmMotivacion()
        {
            InitializeComponent();
        }

        private void bttAsistencia_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmMotAsistencia frmSubCompetencia = new frmMotAsistencia();

            frmSubCompetencia.TopLevel = false;
            frmSubCompetencia.FormBorderStyle = FormBorderStyle.None;
            frmSubCompetencia.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmSubCompetencia);

            frmSubCompetencia.Show();

            this.Close();
        }

        private void bttDestacado_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmMotDestacado frmSubCompetencia = new frmMotDestacado();

            frmSubCompetencia.TopLevel = false;
            frmSubCompetencia.FormBorderStyle = FormBorderStyle.None;
            frmSubCompetencia.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmSubCompetencia);

            frmSubCompetencia.Show();

            this.Close();
        }

        private void bttRecordatorio_Click(object sender, EventArgs e)
        {
            Control contenedor = this.Parent;

            if (contenedor == null)
            {
                MessageBox.Show("No se encontró el contenedor del formulario.");
                return;
            }

            frmMotRecordatorios frmSubCompetencia = new frmMotRecordatorios();

            frmSubCompetencia.TopLevel = false;
            frmSubCompetencia.FormBorderStyle = FormBorderStyle.None;
            frmSubCompetencia.Dock = DockStyle.Fill;

            contenedor.Controls.Remove(this);
            contenedor.Controls.Add(frmSubCompetencia);

            frmSubCompetencia.Show();

            this.Close();
        }
    }
}
