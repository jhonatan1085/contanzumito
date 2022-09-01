using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_TipoFrecuencia
    {
       D_TipoFrecuencia objData = new D_TipoFrecuencia();
        E_TipoFrecuencia objEntidades = new E_TipoFrecuencia();


        public List<E_TipoFrecuencia> ListarTipoFrecuencia()
        {
            return objData.ListarTipoFrecuencia();
        }
    }
}
