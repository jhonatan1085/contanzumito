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
   public class N_TipoCambio
    {
        D_TipoCambio objData = new D_TipoCambio();
     
        public DataTable BuscaTipoCambio(E_Control control)
        {
            return objData.BuscaTipoCambio(control);
        }

        public DataTable BuscaTipoCambioFecha(E_TipoCambio tipocambio)
        {
            return objData.BuscaTipoCambioFecha(tipocambio);
        }

        public void InsertandoTipoCambio(E_TipoCambio TipoCambio)
        {
            objData.InsertandoTipoCambio(TipoCambio);
        }
        public void EditarTipoCambio(E_TipoCambio TipoCambio)
        {
            objData.EditarTipoCambio(TipoCambio);
        }
        


    }
}
