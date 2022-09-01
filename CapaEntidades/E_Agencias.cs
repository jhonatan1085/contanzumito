using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Agencias
    {
        private string _COD_COOP;
        private string _COD_AGE_DESTINO;
        private string _NOM_AGE;
        private int _NRO_CUENTA;
        private string _DIRECCION;
        private string _DATE_ACT;
        private string _EMAIL;
        private char _STD_AGE;
        private char _EXONERA_IGV;
        private string _COD_CTA;
        private string _COD_CTA_H;
        private string _CIUDAD;
        private string _COD_CTA_ING;
        private string _COD_CTA_EGR;
        private string _CTA_GTOS_COMP_D;
        private string _CTA_GTOS_COMP_H;
        private char _INTEGRADA;
        private char _CREDITOFISCAL;

        public string COD_COOP { get => _COD_COOP; set => _COD_COOP = value; }
        public string COD_AGE_DESTINO { get => _COD_AGE_DESTINO; set => _COD_AGE_DESTINO = value; }
        public string NOM_AGE { get => _NOM_AGE; set => _NOM_AGE = value; }
        public int NRO_CUENTA { get => _NRO_CUENTA; set => _NRO_CUENTA = value; }
        public string DIRECCION { get => _DIRECCION; set => _DIRECCION = value; }
        public string DATE_ACT { get => _DATE_ACT; set => _DATE_ACT = value; }
        public string EMAIL { get => _EMAIL; set => _EMAIL = value; }
        public char STD_AGE { get => _STD_AGE; set => _STD_AGE = value; }
        public char EXONERA_IGV { get => _EXONERA_IGV; set => _EXONERA_IGV = value; }
        public string COD_CTA { get => _COD_CTA; set => _COD_CTA = value; }
        public string COD_CTA_H { get => _COD_CTA_H; set => _COD_CTA_H = value; }
        public string CIUDAD { get => _CIUDAD; set => _CIUDAD = value; }
        public string COD_CTA_ING { get => _COD_CTA_ING; set => _COD_CTA_ING = value; }
        public string COD_CTA_EGR { get => _COD_CTA_EGR; set => _COD_CTA_EGR = value; }
        public string CTA_GTOS_COMP_D { get => _CTA_GTOS_COMP_D; set => _CTA_GTOS_COMP_D = value; }
        public string CTA_GTOS_COMP_H { get => _CTA_GTOS_COMP_H; set => _CTA_GTOS_COMP_H = value; }
        public char INTEGRADA { get => _INTEGRADA; set => _INTEGRADA = value; }
        public char CREDITOFISCAL { get => _CREDITOFISCAL; set => _CREDITOFISCAL = value; }
    }
}
