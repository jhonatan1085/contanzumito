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
    public class N_Agencias
    {
        D_Agencias objData = new D_Agencias();
        public List<E_Agencias> ListandoAgencias(String buscar, String tipobusqueda)
        {
            return objData.ListarAgencias(buscar, tipobusqueda);
        }

        public DataTable BuscaGastoCompartido(string periodo,string mes, decimal monto)
        {
           
            return objData.BuscaGastoCompartido(periodo,mes,monto);
        }
    }
}
