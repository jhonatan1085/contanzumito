using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_TipoAsiento
    {

        D_TipoAsiento objData = new D_TipoAsiento();
        public List<E_TipoAsiento> ListandoTipoAsiento(String buscar)
        {
            return objData.ListarTipoAsiento(buscar);
        }

    }
}
