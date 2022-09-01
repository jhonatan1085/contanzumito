using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Data;
using CapaEntidades.lib;

namespace CapaDatos
{
    public class D_TipoFrecuencia
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_TipoFrecuencia> ListarTipoFrecuencia()
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCATIPOFRECUENCIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

           

            LeerFilas = cmd.ExecuteReader();

            List<E_TipoFrecuencia> Listar = new List<E_TipoFrecuencia>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_TipoFrecuencia
                {
                    Id_Tipo_frecuencia = LeerFilas.GetString(0),
                    Descripcion = LeerFilas.GetString(1),
                });
            }

            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }
    }
}
