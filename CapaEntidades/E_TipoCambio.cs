using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_TipoCambio
    {
        private DateTime _FEC_CAMBIO;
        private decimal _COMPR_CAMBIO;
        private decimal _VENTA_CAMBIO;
        private decimal _PROMEDIO_CAMBIO;
        private string _EST_CAMBIO;
        private string _COD_USER;
        private decimal _SUNAT_COMPRA;
        private decimal _SUNAT_VENTA;
        private decimal _SUNAT_PROMEDIO;

        public DateTime FEC_CAMBIO { get => _FEC_CAMBIO; set => _FEC_CAMBIO = value; }
        public decimal COMPR_CAMBIO { get => _COMPR_CAMBIO; set => _COMPR_CAMBIO = value; }
        public decimal VENTA_CAMBIO { get => _VENTA_CAMBIO; set => _VENTA_CAMBIO = value; }
        public decimal PROMEDIO_CAMBIO { get => _PROMEDIO_CAMBIO; set => _PROMEDIO_CAMBIO = value; }
        public string EST_CAMBIO { get => _EST_CAMBIO; set => _EST_CAMBIO = value; }
        public string COD_USER { get => _COD_USER; set => _COD_USER = value; }
        public decimal SUNAT_COMPRA { get => _SUNAT_COMPRA; set => _SUNAT_COMPRA = value; }
        public decimal SUNAT_VENTA { get => _SUNAT_VENTA; set => _SUNAT_VENTA = value; }
        public decimal SUNAT_PROMEDIO { get => _SUNAT_PROMEDIO; set => _SUNAT_PROMEDIO = value; }
    }
}
