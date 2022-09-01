using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
   public class E_Control
    {
        private string _PERIODO;
        private string _MES;
        private string _ESTADO;
        private string _NOMBREMES;

        public string PERIODO { get => _PERIODO; set => _PERIODO = value; }
        public string MES { get => _MES; set => _MES = value; }
        public string ESTADO { get => _ESTADO; set => _ESTADO = value; }
        public string NOMBREMES { get => _NOMBREMES; set => _NOMBREMES = value; }
    }
}
