using System;
using System.Windows.Forms;

namespace wfZenova
{
    public partial class Form1 : Form
    {
        // FORMULARIO ACTUAL
        private Form currentForm = null;
        private Form formularioActivo = null;

        // CONSTRUCTOR
        public Form1()
        {
            InitializeComponent();
        }

        // LOAD
        private void Form1_Load(
            object sender,
            EventArgs e)
        {
            // Los submenús empiezan cerrados
            panelSubBienestar.Visible =
                false;

            PanelSubMenoMonitoreo.Visible =
                false;


            // Configurar menú según
            // el usuario que inició sesión
            ConfigurarPermisos();
            panel1.Visible = false;
        }

        // CONFIGURAR PERMISOS
        private void ConfigurarPermisos()
        {
            // PRIMERO OCULTAMOS TODO
            OcultarTodosLosModulos();

            // ESTOS SON PARA TODOS
            btnCerrar.Visible =
                true;

            btnReportes.Visible =
                true;

            // ROL ACTUAL
            string rol =
                frmInicioDeSesion
                .NombreRolActual;


            if (rol == null)
            {
                rol = "";
            }


            rol =
                rol.Trim();

            // ADMINISTRADOR
            if (rol.Equals(
                "Administrador",
                StringComparison.OrdinalIgnoreCase))
            {
                MenuAdministrador();
            }

            // SECRETARÍA
            else if (
                rol.Equals(
                    "Secretaria",
                    StringComparison.OrdinalIgnoreCase)
                ||
                rol.Equals(
                    "Secretaría",
                    StringComparison.OrdinalIgnoreCase))
            {
                MenuSecretaria();
            }

            // COORDINADOR DE COMPETENCIAS
            else if (
                rol.Equals(
                    "Coordinador de Competencias",
                    StringComparison.OrdinalIgnoreCase)
                ||
                rol.Equals(
                    "Organizador/Coordinador de Competencias",
                    StringComparison.OrdinalIgnoreCase))
            {
                MenuCoordinadorCompetencias();
            }

            // ENTRENADOR
            else if (rol.Equals(
                "Entrenador",
                StringComparison.OrdinalIgnoreCase))
            {
                MenuEntrenador();
            }

            // ROL DESCONOCIDO
            else
            {
                MessageBox.Show(
                    "El usuario no tiene un rol válido asignado.\n\n" +
                    "Rol recibido: " +
                    rol,
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // OCULTAR TODOS LOS MÓDULOS
        private void OcultarTodosLosModulos()
        {
            // GENERALES
            btnInicio.Visible =
                false;

            btnReportes.Visible =
                false;

            // ENTRENADOR

            btnBienestar.Visible =
                false;

            panelSubBienestar.Visible =
                false;

            button1.Visible =
                false;

            btnEntrenamientos.Visible =
                false;

            btnMonitoreo.Visible =
                false;

            PanelSubMenoMonitoreo.Visible =
                false;

            btnDeportistas.Visible =
                false;

            // COORDINADOR
            btnCompetencias.Visible =
                false;

            // ADMINISTRATIVOS
            btnAsignacionAdm.Visible =
                false;

            btnDeportistasAdm.Visible =
                false;

            btnEntrenadoresAdm.Visible =
                false;

            btnGestiondeEmpleados.Visible =
                false;

            btnGestionDeUsuarios.Visible =
                false;

            btnConsultaAdm.Visible =
                false;
        }

        // ADMINISTRADOR
        // ACCESO A TODO
        private void MenuAdministrador()
        {
            // GENERAL
            btnInicio.Visible =
                true;

            btnReportes.Visible =
                true;

            // ENTRENADOR          
            btnBienestar.Visible =
                true;

            button1.Visible =
                true;

            btnEntrenamientos.Visible =
                true;

            btnMonitoreo.Visible =
                true;

            btnDeportistas.Visible =
                true;


            // Los submenús permanecen cerrados
            // hasta hacer clic
            panelSubBienestar.Visible =
                false;

            PanelSubMenoMonitoreo.Visible =
                false;

            // COMPETENCIAS
            btnCompetencias.Visible =
                true;


            // ADMINISTRACIÓN
            btnAsignacionAdm.Visible =
                true;

            btnDeportistasAdm.Visible =
                true;

            btnEntrenadoresAdm.Visible =
                true;

            btnGestiondeEmpleados.Visible =
                true;

            btnGestionDeUsuarios.Visible =
                true;

            btnConsultaAdm.Visible =
                true;
        }

        // SECRETARÍA
        // BOTONES ROSA
        private void MenuSecretaria()
        {
            btnInicio.Visible =
                true;

            btnReportes.Visible =
                true;


            btnAsignacionAdm.Visible =
                true;

            btnDeportistasAdm.Visible =
                true;

            btnEntrenadoresAdm.Visible =
                true;

            btnGestiondeEmpleados.Visible =
                true;

            btnGestionDeUsuarios.Visible =
                true;
        }

        // COORDINADOR DE COMPETENCIAS
        // BOTONES AMARILLOS
        private void MenuCoordinadorCompetencias()
        {
            btnInicio.Visible =
                true;

            btnReportes.Visible =
                true;

            btnCompetencias.Visible =
                true;
        }

        // ENTRENADOR
        // BOTONES AZULES
        private void MenuEntrenador()
        {
            btnInicio.Visible =
                true;

            btnReportes.Visible =
                true;

            // DEPORTISTAS
            btnDeportistas.Visible =
                true;

            // MONITOREO
            btnMonitoreo.Visible =
                true;

            PanelSubMenoMonitoreo.Visible =
                false;

            // ENTRENAMIENTOS
            btnEntrenamientos.Visible =
                true;

            // COMPETENCIAS ENTRENADOR
            // button1 abre frmCompetenciasEntrenador
            button1.Visible =
                true;

            // BIENESTAR
            btnBienestar.Visible =
                true;

            panelSubBienestar.Visible =
                false;

        }

        // ABRIR FORMULARIO HIJO
        private void OpenChildForm(
            Form childForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }


            currentForm =
                childForm;


            childForm.TopLevel =
                false;

            childForm.FormBorderStyle =
                FormBorderStyle.None;

            childForm.Dock =
                DockStyle.Fill;


            PanelChildForm.Controls.Clear();

            PanelChildForm.Controls.Add(
                childForm);

            PanelChildForm.Tag =
                childForm;


            childForm.BringToFront();

            childForm.Show();
        }

        // MONITOREO
        private void btnMonitoreo_Click(
            object sender,
            EventArgs e)
        {
            PanelSubMenoMonitoreo.Visible =
                !PanelSubMenoMonitoreo.Visible;


            // Si abrimos monitoreo,
            // cerramos bienestar
            if (PanelSubMenoMonitoreo.Visible)
            {
                panelSubBienestar.Visible =
                    false;
            }
        }


        private void btnControl_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmResumenMonitoreoAdm());
        }


        private void btnDepor_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmMonitoreoEntrenadores());
        }


        private void btnGestion_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmMonitoreoDeportistas());
        }


        private void btnRegistrodeDatos_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmAlertasMonitoreo());
        }

        // BIENESTAR
        private void btnBienestar_Click(
            object sender,
            EventArgs e)
        {
            panelSubBienestar.Visible =
                !panelSubBienestar.Visible;


            // Si abrimos bienestar,
            // cerramos monitoreo
            if (panelSubBienestar.Visible)
            {
                PanelSubMenoMonitoreo.Visible =
                    false;
            }
        }


        private void btnRiesgo_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmRiego());
        }


        private void btnGasto_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmGastoCalorico());
        }


        private void btnVisualizar_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmVisualizarDatosBienestar());
        }

        // INICIO
        private void btnInicio_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmInicio());
        }

        // DEPORTISTAS ENTRENADOR
        private void btnDeportistas_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmDeportistas());
        }


        // ENTRENAMIENTOS
        private void btnEntrenamientos_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmEntrenamientos());
        }


        // COMPETENCIAS
        // ADMIN / COORDINADOR
        private void btnCompetencias_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmCompetencias());
        }

        // DEPORTISTAS ADMINISTRACIÓN
        private void btnDeportistasAdm_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmDepAdm());
        }

        // ENTRENADORES ADMINISTRACIÓN
        private void btnEntrenadoresAdm_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmEntrenadorAdm());
        }

        // ASIGNACIONES
        private void btnAsignacionAdm_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmAsignacionesAdm());
        }

        // CONSULTAS
        // SOLO ADMINISTRADOR
        private void btnConsultaAdm_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmConsultaAdm());
            panel1.Visible = !panel1.Visible;
        }

        // GESTIÓN DE USUARIOS
        private void btnGestionDeUsuarios_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmGestionDeUsuarios());
        }

        // COMPETENCIAS ENTRENADOR
        private void button1_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmCompetenciasEntrenador());
        }

        // GESTIÓN DE EMPLEADOS
        private void btnGestiondeEmpleados_Click(
            object sender,
            EventArgs e)
        {
            OpenChildForm(
                new frmGestionEmpleados());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(
                new frmCronogramaEntrenador(frmInicioDeSesion.IdEntrenadorActual.Value));
        }

        private void btncon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMoniDeportistas()); 
            panel1.Visible = false;
        }

        private void btnMonitoreoEntrenador_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
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
    }
    
}
