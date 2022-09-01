using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Glosas
    {

        private string _TIPO_ASIENTO;
        private int _NRO_ASIENTO;
        private DateTime _FECHA_ASIENTO;
        private string _COD_AGE_ORIGEN;
        private string _COD_AGE_DESTINO;
        private string _COD_CAJA;
        private string _NOMBRE;
        private string _DETALLE;
        private decimal _TC_SBS;
        private decimal _TC_COMPRA;
        private decimal _TC_VENTA;
        private decimal _DEBE_SOLES;
        private decimal _HABER_SOLES;
        private decimal _DEBE_DOLAR;
        private decimal _HABER_DOLAR;
        private string ESTADO;
        private string _TIPO_DOC;
        private int _NRO_DOC;
        private string _ORIGEN;
        private string _MONEDA;
        private int _ITEM;
        private string _PERIODO;
        private string _MES;
        private decimal _NETO;
        private string _COD_USER;
        private string _REGISTRO;
        private decimal _TC_SUNAT;
        private string _SITUACION;
        private DateTime _FECHA_PAGO;
        private DateTime _DATE_ACT;

        public string TIPO_ASIENTO { get => _TIPO_ASIENTO; set => _TIPO_ASIENTO = value; }
        public int NRO_ASIENTO { get => _NRO_ASIENTO; set => _NRO_ASIENTO = value; }
        public DateTime FECHA_ASIENTO { get => _FECHA_ASIENTO; set => _FECHA_ASIENTO = value; }
        public string COD_AGE_ORIGEN { get => _COD_AGE_ORIGEN; set => _COD_AGE_ORIGEN = value; }
        public string COD_AGE_DESTINO { get => _COD_AGE_DESTINO; set => _COD_AGE_DESTINO = value; }
        public string COD_CAJA { get => _COD_CAJA; set => _COD_CAJA = value; }
        public string NOMBRE { get => _NOMBRE; set => _NOMBRE = value; }
        public string DETALLE { get => _DETALLE; set => _DETALLE = value; }
        public decimal TC_SBS { get => _TC_SBS; set => _TC_SBS = value; }
        public decimal TC_COMPRA { get => _TC_COMPRA; set => _TC_COMPRA = value; }
        public decimal TC_VENTA { get => _TC_VENTA; set => _TC_VENTA = value; }
        public decimal DEBE_SOLES { get => _DEBE_SOLES; set => _DEBE_SOLES = value; }
        public decimal HABER_SOLES { get => _HABER_SOLES; set => _HABER_SOLES = value; }
        public decimal DEBE_DOLAR { get => _DEBE_DOLAR; set => _DEBE_DOLAR = value; }
        public decimal HABER_DOLAR { get => _HABER_DOLAR; set => _HABER_DOLAR = value; }
        public string ESTADO1 { get => ESTADO; set => ESTADO = value; }
        public string TIPO_DOC { get => _TIPO_DOC; set => _TIPO_DOC = value; }
        public int NRO_DOC { get => _NRO_DOC; set => _NRO_DOC = value; }
        public string ORIGEN { get => _ORIGEN; set => _ORIGEN = value; }
        public string MONEDA { get => _MONEDA; set => _MONEDA = value; }
        public int ITEM { get => _ITEM; set => _ITEM = value; }
        public string PERIODO { get => _PERIODO; set => _PERIODO = value; }
        public string MES { get => _MES; set => _MES = value; }
        public decimal NETO { get => _NETO; set => _NETO = value; }
        public string COD_USER { get => _COD_USER; set => _COD_USER = value; }
        public string REGISTRO { get => _REGISTRO; set => _REGISTRO = value; }
        public decimal TC_SUNAT { get => _TC_SUNAT; set => _TC_SUNAT = value; }
        public string SITUACION { get => _SITUACION; set => _SITUACION = value; }
        public DateTime FECHA_PAGO { get => _FECHA_PAGO; set => _FECHA_PAGO = value; }
        public DateTime DATE_ACT { get => _DATE_ACT; set => _DATE_ACT = value; }
    }
}
