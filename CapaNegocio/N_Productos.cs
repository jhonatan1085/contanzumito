using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Productos
    {
        D_Productos objDato = new D_Productos();
        E_Productos objEntidades = new E_Productos();
        public DataTable ListandoProductos()
        {
            return objDato.ListarProductos();
        }

        public DataTable BuscandoProductos(String buscar)
        {
            objEntidades.Buscar = buscar;
            return objDato.BuscarProductos(objEntidades);
        }

        public void CreandoProductos(E_Productos productos)
        {
            objDato.CrearProductos(productos);
        }

        public void EditandoProductos(E_Productos productos)
        {
            objDato.EditarProducto(productos);
        }

        public void EliminandoProductos(int id)
        {
            objDato.BorrarProductos(id);
        }


    }
}
