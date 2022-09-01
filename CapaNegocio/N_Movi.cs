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
    public class N_Movi
    {
        D_Movi objData = new D_Movi();
        public DataTable BuscandoMovi(E_Movi movi)
        {
            return objData.BuscarMovi(movi);
        }
    }
}
