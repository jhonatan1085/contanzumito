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
    
    public class D_Productos
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public DataTable ListarProductos()
        {
            DataTable tabla = new DataTable();
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_LISTARPRODUCTOS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            
            LeerFilas = cmd.ExecuteReader();
            tabla.Load(LeerFilas);

            LeerFilas.Close();
            conexion.Close();
            
            return tabla;
        }

        public DataTable BuscarProductos(E_Productos productos)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_BUSCARPRODUCTOS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", productos.Buscar);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);

            conexion.Close();
            
            return tabla;
        }

        public void BorrarProductos(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARPRODUCTOS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDPRODUCTO", id);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void CrearProductos(E_Productos productos)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARPRODUCTOS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@PRODUCTO", productos.Producto);
            cmd.Parameters.AddWithValue("@PRECIOCOMPRA", productos.Preciocompra);
            cmd.Parameters.AddWithValue("@PRECIOVENTA", productos.Precioventa);
            cmd.Parameters.AddWithValue("@STOCK", productos.Stock);
            cmd.Parameters.AddWithValue("@IDCATEGORIA", productos.Idcategoria);
            cmd.Parameters.AddWithValue("@IDMARCA", productos.Idmarca);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarProducto(E_Productos productos)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAPRODUCTOS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDPRODUCTO", productos.Idproducto);
            cmd.Parameters.AddWithValue("@PRODUCTO", productos.Producto);
            cmd.Parameters.AddWithValue("@PRECIOCOMPRA", productos.Preciocompra);
            cmd.Parameters.AddWithValue("@PRECIOVENTA", productos.Precioventa);
            cmd.Parameters.AddWithValue("@STOCK", productos.Stock);
            cmd.Parameters.AddWithValue("@IDCATEGORIA", productos.Idcategoria);
            cmd.Parameters.AddWithValue("@IDMARCA", productos.Idmarca);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

    }
}
