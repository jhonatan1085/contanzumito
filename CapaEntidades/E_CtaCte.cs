using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_CtaCte
    {
        private string _COD_BANCO;
        private string _NRO_CTACTE;
        private string _COD_CTA;
        private string _CHEQUERA;
        private string _TIPO_CTA;
        private string _CTA_ESTADO;

        public string COD_BANCO { get => _COD_BANCO; set => _COD_BANCO = value; }
        public string NRO_CTACTE { get => _NRO_CTACTE; set => _NRO_CTACTE = value; }
        public string COD_CTA { get => _COD_CTA; set => _COD_CTA = value; }
        public string CHEQUERA { get => _CHEQUERA; set => _CHEQUERA = value; }
        public string TIPO_CTA { get => _TIPO_CTA; set => _TIPO_CTA = value; }
        public string CTA_ESTADO { get => _CTA_ESTADO; set => _CTA_ESTADO = value; }
    }
}
