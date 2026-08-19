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
    public partial class frmResumenMonitoreoAdm : Form
    {
        public frmResumenMonitoreoAdm()
        {
            InitializeComponent();
        }

        private void frmResumenMonitoreoAdm_Load(object sender, EventArgs e)
        {
            ConfigurarFiltros();
            
        }
        private void ConfigurarFiltros()
        {
            cmbPeriodo.Items.Clear();
            cmbPeriodo.Items.Add("Este mes");
            cmbPeriodo.Items.Add("Últimos 3 meses");
            cmbPeriodo.Items.Add("Este año");
            cmbPeriodo.SelectedIndex = 0;

            cbmDeporte.Items.Clear();
            cbmDeporte.Items.Add("Todos");
            cbmDeporte.Items.Add("Boxeo");
            cbmDeporte.Items.Add("Judo");
            cbmDeporte.Items.Add("Karate");
            cbmDeporte.Items.Add("Taekwondo");
            cbmDeporte.SelectedIndex = 0;
        }

    }
}
