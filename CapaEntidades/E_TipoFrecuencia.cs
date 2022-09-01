using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_TipoFrecuencia
    {
        private string _id_Tipo_frecuencia;
        private string _Descripcion;
        private int _Dias;
        private int _periodo;

        public string Id_Tipo_frecuencia { get => _id_Tipo_frecuencia; set => _id_Tipo_frecuencia = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int Dias { get => _Dias; set => _Dias = value; }
        public int Periodo { get => _periodo; set => _periodo = value; }
    }
}
