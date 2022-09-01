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
    public class D_TipoAsiento
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_TipoAsiento> ListarTipoAsiento(String buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCATIPOASIENTOREGISTRO", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerFilas = cmd.ExecuteReader();

            List<E_TipoAsiento> Listar = new List<E_TipoAsiento>();

            while (LeerFilas.Read())
            {
                Listar.Add(new E_TipoAsiento
                {
                    TipoAsiento = LeerFilas.GetString(0),
                    NomAsiento = LeerFilas.GetString(1),
                    FlagAutomatico = LeerFilas.GetString(2),
                    FlagBanco = LeerFilas.GetString(3),
                    HistoAjuste = LeerFilas.GetString(4)
                });
            }

            conexion.Close();
            LeerFilas.Close();
            return Listar;
        }
    }
}
