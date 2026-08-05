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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private Form currentForm = null;
        private void OpenChildForm(Form childForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            PanelChildForm.Controls.Clear();
            PanelChildForm.Controls.Add(childForm);
            PanelChildForm.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void btnMonitoreo_Click(object sender, EventArgs e)
        {
            if(PanelSubMenoMonitoreo.Visible == false)
            {
                PanelSubMenoMonitoreo.Visible = true;
            }
            else
            {
                PanelSubMenoMonitoreo.Visible = false;
            }

        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmControles());
        }

        private void btnDepor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMoniDeportistas());
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionTecnica());
        }

        private void btnRegistrodeDatos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmRegistroDatosMonitoreo());
        }

        private void btnBienestar_Click(object sender, EventArgs e)
        {
            if (panelSubBienestar.Visible == false)
            {
                panelSubBienestar.Visible = true;
            }
            else
            {
                panelSubBienestar.Visible = false;
            }
        }

        private void btnRiesgo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmRiego());
        }

        private void btnGasto_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGastoCalorico());
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmVisualizarDatosBienestar());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmInicio());
        }

        private void btnDeportistas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDeportistas());
        }

        private void btnEntrenamientos_Click(object sender, EventArgs e)
        {

        }

        private void btnCompetencias_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCompetencias());
        }

        private void btnMotivacion_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMotivacion());
        }
    }
}
