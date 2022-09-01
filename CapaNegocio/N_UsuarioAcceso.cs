using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_UsuarioAcceso
    {
        D_UsuarioAcceso objData = new D_UsuarioAcceso();

        public bool Loguea(E_UsuarioAcceso Acceso)
        {
           return  objData.Login(Acceso);
        }

        public List<E_Menu> ObtenerPermisos(String buscar)
        {
            return objData.ObtenerPermisos(buscar);
        }
    }
}
