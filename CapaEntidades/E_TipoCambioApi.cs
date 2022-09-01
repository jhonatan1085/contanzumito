using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
   public  class E_TipoCambioApi
    {

        private decimal _compra;
        private decimal _venta;
        private string _Corigen;
        private string _Cmoneda;
        private string _Cfecha;

        public decimal Compra { get => _compra; set => _compra = value; }
        public decimal Venta { get => _venta; set => _venta = value; }
        public string Corigen { get => _Corigen; set => _Corigen = value; }
        public string Cmoneda { get => _Cmoneda; set => _Cmoneda = value; }
        public string Cfecha { get => _Cfecha; set => _Cfecha = value; }
    }
}
