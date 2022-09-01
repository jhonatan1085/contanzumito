using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Catalogo
    {

        private string _COD_CTA;
        private string _NOM_CTA;
        private string _NIVEL_CTA;
        private string _TIPO_CTA;
        private string _TIPO_BAL;
        private string _TIPO_SALDO;
        private string _MONEDA;
        private string _ESTADO;
        private string _RELACION;
        private string _TIPO_PRESUP;
        private string _MIGRA;
        private string _CENTRO_COSTO;
        private DateTime _DATE_ACT;
        private string _COD_CTA_EQUI;
        private string _Buscar;
        private string _TipoBusqueda;

        public string COD_CTA { get => _COD_CTA; set => _COD_CTA = value; }
        public string NOM_CTA { get => _NOM_CTA; set => _NOM_CTA = value; }
        public string NIVEL_CTA { get => _NIVEL_CTA; set => _NIVEL_CTA = value; }
        public string TIPO_CTA { get => _TIPO_CTA; set => _TIPO_CTA = value; }
        public string TIPO_BAL { get => _TIPO_BAL; set => _TIPO_BAL = value; }
        public string TIPO_SALDO { get => _TIPO_SALDO; set => _TIPO_SALDO = value; }
        public string MONEDA { get => _MONEDA; set => _MONEDA = value; }
        public string ESTADO { get => _ESTADO; set => _ESTADO = value; }
        public string RELACION { get => _RELACION; set => _RELACION = value; }
        public string TIPO_PRESUP { get => _TIPO_PRESUP; set => _TIPO_PRESUP = value; }
        public string MIGRA { get => _MIGRA; set => _MIGRA = value; }
        public string CENTRO_COSTO { get => _CENTRO_COSTO; set => _CENTRO_COSTO = value; }
        public DateTime DATE_ACT { get => _DATE_ACT; set => _DATE_ACT = value; }
        public string COD_CTA_EQUI { get => _COD_CTA_EQUI; set => _COD_CTA_EQUI = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }
        public string TipoBusqueda { get => _TipoBusqueda; set => _TipoBusqueda = value; }
    }
}
