using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_ProveedorFinanciero
    {

        private string _idProveedorFinanciero;
        private string _NRO_RUC;
        private string _RAZON_SOCIAL;
        private string _COD_CTA;

        public string IdProveedorFinanciero { get => _idProveedorFinanciero; set => _idProveedorFinanciero = value; }
        public string NRO_RUC { get => _NRO_RUC; set => _NRO_RUC = value; }
        public string RAZON_SOCIAL { get => _RAZON_SOCIAL; set => _RAZON_SOCIAL = value; }
        public string COD_CTA { get => _COD_CTA; set => _COD_CTA = value; }
    }
}
