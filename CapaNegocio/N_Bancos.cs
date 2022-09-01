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
    public class N_Bancos
    {
        D_Bancos objData = new D_Bancos();
        E_Bancos objEntidades = new E_Bancos();


        public List<E_Bancos> ListarBancos(String buscar)
        {
            return objData.ListarBancos(buscar);
        }
    }
}
