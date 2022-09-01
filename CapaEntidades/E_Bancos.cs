using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
   public  class E_Bancos
    {
        private string _COD_BANCO;
        private string _NOM_BANCO;

        public string COD_BANCO { get => _COD_BANCO; set => _COD_BANCO = value; }
        public string NOM_BANCO { get => _NOM_BANCO; set => _NOM_BANCO = value; }
    }
}
