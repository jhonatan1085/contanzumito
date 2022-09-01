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
    public class N_CtaCte
    {
        D_CtaCte objData = new D_CtaCte();
        E_CtaCte objEntidades = new E_CtaCte();
        public List<E_CtaCte> ListarCtaCte(String buscar)
        {
            objEntidades.COD_BANCO = buscar;
            
            return objData.ListarCtaCte(objEntidades);
        }
    }
}
