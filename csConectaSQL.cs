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
        SqlConnection oCon;
        string Server;
        string Database;
        string Usuario;
        string Clave;
        string Cadena;
        DataTable ODT;
        SqlCommand oCom;
        SqlDataAdapter oDA;
        public csConectaSQL()
        {
            Server = @"LAPTOP-9VS1C12U\SQLEXPRESS";
            Database = "Zenova";
            Usuario = "sa";
            Clave = "Piguave67XD12!#";
        }

        public csConectaSQL(string Server, string Database, string Usuario, string Clave)
        {
            this.Server = Server;
            this.Database = Database;
            this.Usuario = Usuario;
            this.Clave = Clave;
        }

        public bool abrirConexion()
        {
            try
            {
                oCon = new SqlConnection();
                oCon.ConnectionString = Cadena = "Server=" + Server + "; Database=" + Database
                    + "; User id=" + Usuario + "; Password=" + Clave + ";";
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
                if (oCon != null)
                    oCon.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public DataTable RetornaRegistros(string sql)
        {
            try
            {
                if (abrirConexion())
                {
                    oDA = new SqlDataAdapter(sql, oCon);
                    ODT = new DataTable();
                    oDA.Fill(ODT);
                    cerrarConexion();
                    return ODT;
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool insertDatos(string tabla, string campos, string datos)
        {
            try
            {
                if (abrirConexion())
                {
                    Cadena = "insert into " + tabla + " (" + campos + ") values (" + datos + ")";
                    oCom = new SqlCommand(Cadena, oCon);
                    oCom.ExecuteNonQuery();
                    cerrarConexion();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool ActualizarDatos(string tabla, string campo, string condicion)
        {
            try
            {
                abrirConexion();
                Cadena = "Update" + tabla + " set " + campo + " where " + condicion;
                oCom = new SqlCommand(Cadena, oCon);
                oCom.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool EliminadDatos(string tabla, string condicion)
        {
            try
            {
                abrirConexion();
                Cadena = "Delete" + tabla + " where " + condicion;
                oCom = new SqlCommand(Cadena, oCon);
                oCom.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool EjecutaSentenciaSRD(string sentencia)
        {
            try
            {
                abrirConexion();
                oCom = new SqlCommand(sentencia, oCon);
                oCom.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public bool EjecutaSentenciaParametros(string sentencia,params SqlParameter[] parametros)
        {
            try
            {
                if (!abrirConexion())
                    return false;

                oCom = new SqlCommand(sentencia, oCon);

                if (parametros != null && parametros.Length > 0)
                {
                    oCom.Parameters.AddRange(parametros);
                }

                oCom.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                cerrarConexion();
            }
        }
    }
}
