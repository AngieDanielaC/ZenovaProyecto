using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace wfZenova
{
    public partial class frmRemplazarEntrenador : Form
    {


        public frmRemplazarEntrenador(int idEntrenadorActual)
        {
            InitializeComponent();

        }


        public frmRemplazarEntrenador()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xF012, 0);
        }

        private void frmRemplazarEntrenador_Load(object sender, EventArgs e)
        {

        }
       

        private void cmbTipoReemplazo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void CargarNuevosEntrenadores(int idDeporte)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
