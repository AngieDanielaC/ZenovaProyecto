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
    public partial class frmRegistroEntrenador : Form
    {
        public frmRegistroEntrenador()
        {
            InitializeComponent();
        }

        private void btnConfRegistro_Click(object sender, EventArgs e)
        {
            frmInicioDeSesion menu = new frmInicioDeSesion();

            this.Hide();

            menu.ShowDialog();

            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            frmInicioDeSesion menu = new frmInicioDeSesion();

            this.Hide();

            menu.ShowDialog();

            this.Close();
        }
    }
}
