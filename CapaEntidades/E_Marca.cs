using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Marca
    {
        private int _Idmarca;
        private string _Codigomarca;
        private string _Nombremarca;
        private string _Descripcionmarca;

        public int Idmarca { get => _Idmarca; set => _Idmarca = value; }
        public string Codigomarca { get => _Codigomarca; set => _Codigomarca = value; }
        public string Nombremarca { get => _Nombremarca; set => _Nombremarca = value; }
        public string Descripcionmarca { get => _Descripcionmarca; set => _Descripcionmarca = value; }
    }
}
