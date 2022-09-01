using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
   public  class E_Movi
    {

        private string _TIPO_ASIENTO;
        private int _NRO_ASIENTO;
        private DateTime _FECHA_ASIENTO;
        private int _NRO_ITEM;
        private string _COD_CTA;
        private string _COD_AGE_ORIGEN;
        private string _COD_AGE_DESTINO;
        private string _DE_HA;
        private decimal _IMP_DOLAR;
        private decimal _TIPO_CAMBIO;
        private decimal _IMP_SOLES;
        private string _TIPO_PRESUP;
        private string _COD_PARTIDA;
        private string _ESTADO;
        private string _GLOSA;
        private string _PERIODO;
        private string _MES;
        private string _COD_USER;
        private string _COD_CCOSTO;
        private string _ORIGEN;
        private DateTime _DATE_ACT;

        public string TIPO_ASIENTO { get => _TIPO_ASIENTO; set => _TIPO_ASIENTO = value; }
        public int NRO_ASIENTO { get => _NRO_ASIENTO; set => _NRO_ASIENTO = value; }
        public DateTime FECHA_ASIENTO { get => _FECHA_ASIENTO; set => _FECHA_ASIENTO = value; }
        public int NRO_ITEM { get => _NRO_ITEM; set => _NRO_ITEM = value; }
        public string COD_CTA { get => _COD_CTA; set => _COD_CTA = value; }
        public string COD_AGE_ORIGEN { get => _COD_AGE_ORIGEN; set => _COD_AGE_ORIGEN = value; }
        public string COD_AGE_DESTINO { get => _COD_AGE_DESTINO; set => _COD_AGE_DESTINO = value; }
        public string DE_HA { get => _DE_HA; set => _DE_HA = value; }
        public decimal IMP_DOLAR { get => _IMP_DOLAR; set => _IMP_DOLAR = value; }
        public decimal TIPO_CAMBIO { get => _TIPO_CAMBIO; set => _TIPO_CAMBIO = value; }
        public decimal IMP_SOLES { get => _IMP_SOLES; set => _IMP_SOLES = value; }
        public string TIPO_PRESUP { get => _TIPO_PRESUP; set => _TIPO_PRESUP = value; }
        public string COD_PARTIDA { get => _COD_PARTIDA; set => _COD_PARTIDA = value; }
        public string ESTADO { get => _ESTADO; set => _ESTADO = value; }
        public string GLOSA { get => _GLOSA; set => _GLOSA = value; }
        public string PERIODO { get => _PERIODO; set => _PERIODO = value; }
        public string MES { get => _MES; set => _MES = value; }
        public string COD_USER { get => _COD_USER; set => _COD_USER = value; }
        public string COD_CCOSTO { get => _COD_CCOSTO; set => _COD_CCOSTO = value; }
        public string ORIGEN { get => _ORIGEN; set => _ORIGEN = value; }
        public DateTime DATE_ACT { get => _DATE_ACT; set => _DATE_ACT = value; }
    }
}
