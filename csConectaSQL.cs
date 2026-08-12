using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfZenova
{
    internal class csConectaSQL
    {
        public SqlConnection oCon;

        private string Server;
        private string Database;
        private string Cadena;

        public csConectaSQL()
        {
            Server = @"DESKTOP-01HFO8T\SQLEXPRESS";
            Database = "ZenovaGestionDB";
        }

        public bool abrirConexion()
        {
            try
            {
                Cadena =
                    "Server=" + Server +
                    ";Database=" + Database +
                    ";Integrated Security=True;" +
                    "TrustServerCertificate=True;";

                oCon = new SqlConnection(Cadena);
                oCon.Open();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool cerrarConexion()
        {
            try
            {
                if (oCon != null &&
                    oCon.State == ConnectionState.Open)
                {
                    oCon.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
