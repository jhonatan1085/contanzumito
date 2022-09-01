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
   public  class N_Control
    {

        D_Control objData = new D_Control();
        public List<E_Control> ListarPeriodos()
        {
            return objData.ListarPeriodos();
        }

        public DataTable BuscaControlAnio(string periodo)
        {
            return objData.BuscaControlAnio(periodo);
        }
    }
}
