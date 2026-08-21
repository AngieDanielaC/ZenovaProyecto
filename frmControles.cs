using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace wfZenova
{
    public partial class frmControles : Form
    {
        csConectaSQL conSQL = new csConectaSQL();
        public frmControles()
        {
            InitializeComponent();

        }

        private void frmControles_Load(object sender, EventArgs e)
        {
            CargarDeportistasActivos();
            CargarTotalDeportistas();
            CargarPosiblesLesionados();
            CargarBajasMedicas();
            CargarPrimerDeportistaActivo();
            CargarDeportistaEnRiesgo();
            CargarDeportistaRecuperacion();

        }
        private void CargarDeportistasActivos()
        {
            string consulta = "select count(*) as Total " + "from Deportistas " + "where Estado = 1 " + "and EstadoMonitoreo = 'Activo'";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                label25.Text = datos.Rows[0]["Total"].ToString();
            }
            else
            {
                label25.Text = "0";
            }
        }
        private void CargarTotalDeportistas()
        {
            string consulta = "select count(*) as Total " + "from Deportistas";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                label26.Text = datos.Rows[0]["Total"].ToString();
            }
            else
            {
                label26.Text = "0";
            }
        }
        private void CargarPosiblesLesionados()
        {
            string consulta = "select count(distinct idDeportista) as Total " + "from RiesgoFatiga " + "where Riesgo = 'Alto'";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                int total = Convert.ToInt32(datos.Rows[0]["Total"]);

                label27.Text = total.ToString("00");
            }
            else
            {
                label27.Text = "00";
            }
        }
        private void CargarBajasMedicas()
        {
            string consulta = "select count(*) as Total " + "from Deportistas " + "where Estado = 1 " + "and EstadoMonitoreo = 'Baja médica'";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                int total = Convert.ToInt32(datos.Rows[0]["Total"]);

                label28.Text = total.ToString("00");
            }
            else
            {
                label28.Text = "00";
            }
        }

        private void CargarPrimerDeportistaActivo()
        {
            string consulta =  "select top 1 " + "IdDeportista, " +  "Nombres + ' ' + Apellidos as Deportista, " +  "Foto " +
                "from Deportistas " + "where Estado = 1 " + "and EstadoMonitoreo = 'Activo' " +  "order by Apellidos, Nombres";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                label32.Text =  datos.Rows[0]["Deportista"].ToString();

                label31.Text = "ACTIVO";

                if (datos.Rows[0]["Foto"] != DBNull.Value)
                {
                    byte[] foto =  (byte[])datos.Rows[0]["Foto"];

                    using (MemoryStream memoria =  new MemoryStream(foto))
                    {
                        using (Image imagen =  Image.FromStream(memoria))
                        {
                            pictureBox7.Image =  new Bitmap(imagen);
                        }
                    }
                }

                int idDeportista = Convert.ToInt32( datos.Rows[0]["IdDeportista"]);
                CargarPruebaFisica(idDeportista);

                string consultaFatiga =  "select top 1 Riesgo " + "from RiesgoFatiga " + "where idDeportista = " + idDeportista;

                DataTable fatiga = conSQL.RetornaRegistros( consultaFatiga);

                if (fatiga != null && fatiga.Rows.Count > 0)
                {
                    label33.Text = fatiga.Rows[0]["Riesgo"] .ToString().ToUpper();
                }
                else
                {
                    label33.Text = "SIN DATO";
                }

                pictureBox7.SizeMode =  PictureBoxSizeMode.Zoom;

                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }

        }

        private void CargarDeportistaEnRiesgo()
        {
            string consulta =
                "select top 1 " +
                "d.Nombres + ' ' + d.Apellidos as Deportista, " +
                "d.Foto, r.IEntrenamiento, r.Riesgo " +
                "from Deportistas d " +
                "inner join RiesgoFatiga r " +
                "on d.IdDeportista = r.idDeportista " +
                "where d.Estado = 1 " +
                "and r.Riesgo = 'Alto' " +
                "order by d.Apellidos, d.Nombres";

            DataTable datos =conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                label3.Text = datos.Rows[0]["Deportista"].ToString();

                label9.Text = "EN DUDA";

                if (datos.Rows[0]["Foto"] != DBNull.Value)
                {
                    byte[] foto =  (byte[])datos.Rows[0]["Foto"];

                    using (MemoryStream memoria =  new MemoryStream(foto))
                    {
                        using (Image imagen = Image.FromStream(memoria))
                        {
                            pictureBox8.Image = new Bitmap(imagen);
                        }
                    }
                }

                pictureBox8.SizeMode =   PictureBoxSizeMode.Zoom;

                label18.Text =  datos.Rows[0]["Riesgo"] .ToString().ToUpper();

                label13.Text =  datos.Rows[0]["IEntrenamiento"].ToString().ToUpper();

                label1.Text = "--";

                panel12.Visible = true;
            }
            else
            {
                panel12.Visible = false;
            }
        }

        private void CargarDeportistaRecuperacion()
        {
            string consulta =  "select top 1 " +  "Nombres + ' ' + Apellidos as Deportista, " +  "Foto, FechaPosibleRegreso " +
                "from Deportistas " + "where Estado = 1 " + "and EstadoMonitoreo = 'En recuperación' " + "order by Apellidos, Nombres";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                label8.Text = datos.Rows[0]["Deportista"].ToString();

                label10.Text = "EN\nRECUP.";
                label6.Text = "RECUPERACIÓN";

                if (datos.Rows[0]["FechaPosibleRegreso"] != DBNull.Value)
                {
                    DateTime fechaRegreso = Convert.ToDateTime( datos.Rows[0]["FechaPosibleRegreso"]);

                    int dias =  (fechaRegreso.Date - DateTime.Today).Days;

                    if (dias < 0)
                        dias = 0;

                    int semanas = (int)Math.Ceiling(dias / 7.0);

                    label4.Text = "Posible regreso: " + semanas.ToString() + " semanas";
                }
                else
                {
                    label4.Text =  "Fecha de regreso pendiente";
                }

                if (datos.Rows[0]["Foto"] != DBNull.Value)
                {
                    byte[] foto =  (byte[])datos.Rows[0]["Foto"];

                    using (MemoryStream memoria =  new MemoryStream(foto))
                    {
                        using (Image imagen = Image.FromStream(memoria))
                        {
                            pictureBox10.Image =  new Bitmap(imagen);
                        }
                    }
                }

                pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
                panel13.Visible = true;
            }
            else
            {
                panel13.Visible = false;
            }
        }

        private void CargarDeportistaBajaMedica()
        {
            string consulta = "select top 1 " + "Nombres + ' ' + Apellidos as Deportista, " +  "Foto, FechaPosibleRegreso " +
                "from Deportistas " + "where Estado = 1 " +"and EstadoMonitoreo = 'Baja médica' " +"order by Apellidos, Nombres";

            DataTable datos =conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                label8.Text =datos.Rows[0]["Deportista"].ToString();

                label10.Text = "BAJA MÉDICA";
                label6.Text = "BAJA MÉDICA";

                if (datos.Rows[0]["FechaPosibleRegreso"] != DBNull.Value)
                {
                    DateTime fecha = Convert.ToDateTime( datos.Rows[0]["FechaPosibleRegreso"]);

                    label4.Text = "Posible regreso: " + fecha.ToString("dd/MM/yyyy");
                }
                else
                {
                    label4.Text = "Fecha de regreso pendiente";
                }

                pictureBox10.Image = null;

                if (datos.Rows[0]["Foto"] != DBNull.Value)
                {
                    byte[] foto = (byte[])datos.Rows[0]["Foto"];

                    using (MemoryStream memoria = new MemoryStream(foto))
                    {
                        using (Image imagen = Image.FromStream(memoria))
                        {
                            pictureBox10.Image = new Bitmap(imagen);
                        }
                    }
                }

                pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;

                panel13.Visible = true;
            }
            else
            {
                panel13.Visible = false;

                MessageBox.Show("No hay deportistas con baja médica.");
            }
        }

        private void CargarPruebaFisica(int idDeportista)
        {
            string consulta = "select top 1 " + "Rendimiento, NivelTecnico " + "from PruebasFisicas " + "where IdDeportista = " +
                idDeportista + " order by Fecha desc, IdPrueba desc";

            DataTable datos = conSQL.RetornaRegistros(consulta);

            if (datos != null && datos.Rows.Count > 0)
            {
                decimal rendimiento = Convert.ToDecimal( datos.Rows[0]["Rendimiento"]);

                decimal nivelTecnico = Convert.ToDecimal( datos.Rows[0]["NivelTecnico"]);

                label29.Text = rendimiento.ToString("0") + "%";

                label35.Text = nivelTecnico.ToString("0.0") + " / 10";

                int ancho = Convert.ToInt32( panel2.Width *rendimiento / 100);

                panel3.Width = Math.Min(panel2.Width, ancho);
            }
            else
            {
                label29.Text = "--";
                label35.Text = "-- / 10";
                panel3.Width = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarPrimerDeportistaActivo();
            CargarDeportistaEnRiesgo();
            CargarDeportistaRecuperacion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CargarPrimerDeportistaActivo();

            panel12.Visible = false;
            panel13.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel12.Visible = false;
            panel13.Visible = true;

            CargarDeportistaRecuperacion();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel12.Visible = false;
            panel13.Visible = true;
            CargarDeportistaBajaMedica();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string buscar = textBox1.Text.Trim().ToLower();

            if (buscar == "" ||  buscar == "buscar atleta...")
            {
                panel1.Visible = true;
                panel12.Visible = true;
                panel13.Visible = true;
                return;
            }

            panel1.Visible =  label32.Text.ToLower().Contains(buscar);

            panel12.Visible = label3.Text.ToLower().Contains(buscar);

            panel13.Visible = label8.Text.ToLower().Contains(buscar);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Buscar Atleta...")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = "Buscar Atleta...";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
