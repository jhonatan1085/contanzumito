using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
    public class D_Control
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);
        public List<E_Control> ListarPeriodos()
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SEL_CONTROL_02", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            LeerFilas = cmd.ExecuteReader();

            List<E_Control> Listar = new List<E_Control>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_Control
                {
                    PERIODO = LeerFilas.GetString(0)
                    
                    
                });
            }

            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }

        public DataTable BuscaControlAnio(string periodo)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("SEL_CONTROL_01", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@PERIODO", periodo);
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();

            return tabla;
        }
    }
}
