using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidades;
using System.Data;
using CapaEntidades.cache;
using System.Xml;
using System.Xml.Linq;


namespace CapaDatos
{
    public class D_UsuarioAcceso
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public bool Login(E_UsuarioAcceso Acceso)
        {

            DataTable tabla = new DataTable();
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_ACCESOUSER", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@usuario", Acceso.Usuario);
            cmd.Parameters.AddWithValue("@password", Acceso.Password);

            LeerFilas = cmd.ExecuteReader();
            tabla.Load(LeerFilas);

            LeerFilas.Close();
            conexion.Close();

            if (tabla.Rows.Count == 0)
            {
                return false;
            }
            else
            {

                DataRow row = tabla.Rows[0];
                LoginCache.codUser = Acceso.Usuario;
                LoginCache.password = Acceso.Password;
                LoginCache.Tipo_usuario = row["TIPO_USUARIO"].ToString();

                return true;
            }

        }

        public List<E_Menu> ObtenerPermisos(string  P_idusuario)
        {
            List<E_Menu> permisos = new List<E_Menu>();
            try
            {

                XmlReader LeerFilas;
                SqlCommand cmd = new SqlCommand("SP_OBTENERPERMISOS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                cmd.Parameters.AddWithValue("@CODUSER", P_idusuario);
                LeerFilas = cmd.ExecuteXmlReader();

                

                while (LeerFilas.Read())
                {
                    XDocument doc = XDocument.Load(LeerFilas);

                    if (doc.Element("PERMISOS") != null) {

                        permisos = doc.Element("PERMISOS").Element("DetalleMenu") == null ? new List<E_Menu>() :
                            (from menu in doc.Element("PERMISOS").Element("DetalleMenu").Elements("Menu")
                             select new E_Menu()
                             {
                                 NOMBRE = menu.Element("Nombre").Value,
                                 ICONO = menu.Element("icono").Value,
                                 LISTASUBMENU = menu.Element("DetalleSubMenu") == null ? new List<E_SubMenu>() :
                             (
                               from submenu in menu.Element("DetalleSubMenu").Elements("SubMenu")
                               select new E_SubMenu() {
                                   NOMBRE = submenu.Element("nombre").Value,
                                   NOMBREFORMULARIO = submenu.Element("NombreFormulario").Value
                               }).ToList()

                             }).ToList();
                    }

                }

                //conexion.Close();
                // LeerFilas.Close();
                 return permisos;

            }
            catch (Exception e) {
                return permisos = new List<E_Menu>();
            };
    }


    }
}

