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
    public partial class frmDatosDeportivos : Form
    {
        private int idDeportista;
        csConectaSQL conSQL = new csConectaSQL();
        public frmDatosDeportivos(int idDeportista)
        {
            InitializeComponent();

            this.idDeportista = idDeportista;

            CargarDeportista();
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
        private void CargarDeportista()
        {
            DataTable tabla =
                conSQL.RetornaRegistros(
                    @"SELECT
                D.Nombres,
                D.Apellidos,
                DEP.NombreDeporte
              FROM Deportistas D

              INNER JOIN Inscripciones I
                  ON D.IdDeportista = I.IdDeportista

              INNER JOIN EntrenadorDeporte ED
                  ON I.IdEntrenadorDeporte =
                     ED.IdEntrenadorDeporte

              INNER JOIN Deportes DEP
                  ON ED.IdDeporte =
                     DEP.IdDeporte

              WHERE
                  D.IdDeportista = " + idDeportista + @"
                  AND I.Estado = 'Activa'"
                );

            if (tabla == null ||
                tabla.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No se encontró la información deportiva del deportista.",
                    "ZENOVA",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DataRow fila =
                tabla.Rows[0];

            lblNombreDeportista.Text =
                fila["Nombres"].ToString() +
                " " +
                fila["Apellidos"].ToString();

            lblDeporte.Text =
                fila["NombreDeporte"].ToString();
        }
    }
}
