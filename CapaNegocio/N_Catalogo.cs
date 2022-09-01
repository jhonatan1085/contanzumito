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
    public class N_Catalogo
    {

        D_Catalogo objData = new D_Catalogo();
        E_Catalogo objEntidades = new E_Catalogo();


        public List<E_Catalogo> ListarCatalogo (String buscar, String tipobusqueda)
        {
            return objData.ListarCatalogo(buscar, tipobusqueda);
        }

        public DataTable BuscandoCatalogo(String buscar, String tipoBusqueda)
        {
            objEntidades.Buscar = buscar;
            objEntidades.TipoBusqueda = tipoBusqueda;

            return objData.BuscarCatalogo(objEntidades);
        }

        public void seleccionaCuenta(E_Catalogo Catalogo)
        {
            objData.seleccionaCuenta(Catalogo);
        }
    }
}
