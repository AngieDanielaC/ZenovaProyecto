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

namespace wfZenova
{
    public partial class frmRegistrarCompetencia : Form
    {
        public int tipo; // 1 = nuevo, 2 = editar
        private int idCompetencia;
        public frmRegistrarCompetencia()
        {
            InitializeComponent();
            tipo = 1;

            lblTitulo.Text = "REGISTRAR COMPETENCIA";
            btnGuardar.Text = "Guardar competencia";
        }


        public frmRegistrarCompetencia(int idCompetencia)
        {
            InitializeComponent();

            tipo = 2;

            this.idCompetencia = idCompetencia;

            lblTitulo.Text = "EDITAR COMPETENCIA";
            btnGuardar.Text = "Guardar cambios";

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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
