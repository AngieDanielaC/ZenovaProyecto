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
        public string RolUsuario;

        public Form1()
        {
            InitializeComponent();
            RolUsuario = "Administrador";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (RolUsuario == "Administrador")
            {
                MenuAdministrador();
            }
            else
            {
                MenuEntrenador();
            }
        }
        private void MenuAdministrador()
        {
            // Ocultar entrenador
            btnInicio.Visible = false;
            // Mostrar administrador

            btnDeportistasAdm.Visible = true;
            btnEntrenadoresAdm.Visible = true;
            btnAsignacionAdm.Visible = true;
            btnConsultaAdm.Visible = true;
        }
        private void MenuEntrenador()
        {
            // Mostrar entrenador
            btnInicio.Visible = true;
            btnDeportistas.Visible = true;
            btnMonitoreo.Visible = true;
            btnEntrenamientos.Visible = true;
            btnCompetencias.Visible = true;
            btnBienestar.Visible = true;
            btnMotivacion.Visible = true;


            // Ocultar administrador

            btnDeportistasAdm.Visible = false;
            btnEntrenadoresAdm.Visible = false;
            btnAsignacionAdm.Visible = false;
            btnConsultaAdm.Visible = false;
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
            OpenChildForm(new frmMoniDeportistas());
        }

        private void btnDepor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmControles());
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
            OpenChildForm(new frmEntrenamientos());
        }

        private void btnCompetencias_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCompetencias());
        }

        private void btnMotivacion_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMotivacion());
        }

        private void btnDeportistasAdm_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDepAdm());
        }

        private void btnEntrenadoresAdm_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmEntrenadorAdm());
        }

        private void btnAsignacionAdm_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAsignacionesAdm());
        }

        private void btnConsultaAdm_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmConsultaAdm());
        }

        private void btnGestionDeUsuarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionDeUsuarios());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCompetenciasEntrenador());
        }
    }
}
