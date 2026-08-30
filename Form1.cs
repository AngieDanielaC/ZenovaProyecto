using System;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class Form1 : Form
    {
        private Form currentForm = null;
        private Form formularioActivo = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelSubBienestar.Visible = false;
            PanelSubMenoMonitoreo.Visible = false;
            panel1.Visible = false;

            ConfigurarPermisos();

            OpenChildForm(new frmInicio());
        }

        private void ConfigurarPermisos()
        {
            OcultarTodosLosModulos();

            btnCerrar.Visible = true;
            btnReportes.Visible = true;

            string rol = frmInicioDeSesion.NombreRolActual;

            if (rol == null) rol = "";

            rol = rol.Trim();

            if (rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                MenuAdministrador();
            }
            else if (rol.Equals("Secretaria", StringComparison.OrdinalIgnoreCase) ||
                     rol.Equals("Secretaría", StringComparison.OrdinalIgnoreCase))
            {
                MenuSecretaria();
            }
            else if (rol.Equals("Coordinador de Competencias", StringComparison.OrdinalIgnoreCase) ||
                     rol.Equals("Organizador/Coordinador de Competencias", StringComparison.OrdinalIgnoreCase))
            {
                MenuCoordinadorCompetencias();
            }
            else if (rol.Equals("Entrenador", StringComparison.OrdinalIgnoreCase))
            {
                MenuEntrenador();
            }
            else
            {
                MessageBox.Show(
                    "El usuario no tiene un rol válido asignado.\n\n" +
                    "Rol recibido: " + rol,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void OcultarTodosLosModulos()
        {
            btnInicio.Visible = false;
            btnReportes.Visible = false;
            btnBienestar.Visible = false;
            panelSubBienestar.Visible = false;
            button1.Visible = false;
            btnEntrenamientos.Visible = false;

            btnMonitoreo.Visible = false;
            PanelSubMenoMonitoreo.Visible = false;

            btnMonitoreoEntrenador.Visible = false;
            panel1.Visible = false;

            btnDeportistas.Visible = false;
            btnCompetencias.Visible = false;
            btnAsignacionAdm.Visible = false;
            btnDeportistasAdm.Visible = false;
            btnEntrenadoresAdm.Visible = false;
            btnGestiondeEmpleados.Visible = false;
            btnGestionDeUsuarios.Visible = false;
        }

        private void MenuAdministrador()
        {
            btnInicio.Visible = true;
            btnReportes.Visible = true;
            btnBienestar.Visible = true;
            button1.Visible = true;
            btnEntrenamientos.Visible = true;

            btnMonitoreo.Visible = true;
            PanelSubMenoMonitoreo.Visible = false;

            btnMonitoreoEntrenador.Visible = false;
            panel1.Visible = false;

            btnDeportistas.Visible = true;
            btnCompetencias.Visible = true;
            btnAsignacionAdm.Visible = true;
            btnDeportistasAdm.Visible = true;
            btnEntrenadoresAdm.Visible = true;
            btnGestiondeEmpleados.Visible = true;
            btnGestionDeUsuarios.Visible = true;

            panelSubBienestar.Visible = false;
        }

        private void MenuSecretaria()
        {
            btnInicio.Visible = true;
            btnReportes.Visible = true;
            btnAsignacionAdm.Visible = true;
            btnDeportistasAdm.Visible = true;
            btnEntrenadoresAdm.Visible = true;
            btnGestiondeEmpleados.Visible = true;
            btnGestionDeUsuarios.Visible = true;

            btnMonitoreo.Visible = false;
            btnMonitoreoEntrenador.Visible = false;
        }

        private void MenuCoordinadorCompetencias()
        {
            btnInicio.Visible = true;
            btnReportes.Visible = true;
            btnCompetencias.Visible = true;

            btnMonitoreo.Visible = false;
            btnMonitoreoEntrenador.Visible = false;
        }

        private void MenuEntrenador()
        {
            btnInicio.Visible = true;
            btnReportes.Visible = true;
            btnDeportistas.Visible = true;
            btnEntrenamientos.Visible = true;
            button1.Visible = true;
            btnBienestar.Visible = true;

            btnMonitoreo.Visible = false;
            PanelSubMenoMonitoreo.Visible = false;

            btnMonitoreoEntrenador.Visible = true;
            panel1.Visible = false;

            panelSubBienestar.Visible = false;
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentForm != null) currentForm.Close();

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
            PanelSubMenoMonitoreo.Visible = !PanelSubMenoMonitoreo.Visible;

            if (PanelSubMenoMonitoreo.Visible)
            {
                panelSubBienestar.Visible = false;
                panel1.Visible = false;
            }
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmResumenMonitoreoAdm());
        }

        private void btnDepor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMonitoreoEntrenadores());
        }

        private void btnGestion_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMonitoreoDeportistas());
        }

        private void btnRegistrodeDatos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAlertasMonitoreo());
        }

        private void btnBienestar_Click(object sender, EventArgs e)
        {
            panelSubBienestar.Visible = !panelSubBienestar.Visible;

            if (panelSubBienestar.Visible)
            {
                PanelSubMenoMonitoreo.Visible = false;
                panel1.Visible = false;
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
            if (frmInicioDeSesion.NombreRolActual == "Entrenador" &&
                frmInicioDeSesion.IdEntrenadorActual.HasValue)
            {
                OpenChildForm(new frmDeportistas(
                    frmInicioDeSesion.IdEntrenadorActual.Value));
            }
            else
            {
                OpenChildForm(new frmDeportistas());
            }
        }

        private void btnEntrenamientos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmEntrenamientos());
        }

        private void btnCompetencias_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCompetencias());
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
            panel1.Visible = !panel1.Visible;
        }

        private void btnGestionDeUsuarios_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionDeUsuarios());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (frmInicioDeSesion.NombreRolActual == "Entrenador" &&
                frmInicioDeSesion.IdEntrenadorActual.HasValue)
            {
                OpenChildForm(new frmCompetenciasEntrenador(
                    frmInicioDeSesion.IdEntrenadorActual.Value));
            }
            else
            {
                OpenChildForm(new frmCompetenciasEntrenador());
            }
        }

        private void btnGestiondeEmpleados_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionEmpleados());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReportes());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (frmInicioDeSesion.IdEntrenadorActual.HasValue)
            {
                OpenChildForm(new frmCronogramaEntrenador(
                    frmInicioDeSesion.IdEntrenadorActual.Value));
            }
        }

        private void btncon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMoniDeportistas());
            panel1.Visible = false;
        }

        private void btnMonitoreoEntrenador_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;

            if (panel1.Visible)
            {
                PanelSubMenoMonitoreo.Visible = false;
                panelSubBienestar.Visible = false;
            }
        }

        private void btndepormoni_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmControles());
            panel1.Visible = false;
        }

        private void btngestiond_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmGestionTecnica());
            panel1.Visible = false;
        }

        private void btnregisd_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmRegistroDatosMonitoreo());
            panel1.Visible = false;
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAsistencia());
        }

        private void btnConsultaAdm_Click_1(object sender, EventArgs e)
        {
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            frmInicioDeSesion frm = new frmInicioDeSesion();
            frm.Show();
            this.Close();
        }

        private void PanelChildForm_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}