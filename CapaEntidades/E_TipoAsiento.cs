using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_TipoAsiento
    {
        private string _TipoAsiento;
        private string _NomAsiento;
        private string _FlagAutomatico;
        private string _FlagBanco;
        private string _HistoAjuste;

        public string TipoAsiento { get => _TipoAsiento; set => _TipoAsiento = value; }
        public string NomAsiento { get => _NomAsiento; set => _NomAsiento = value; }
        public string FlagAutomatico { get => _FlagAutomatico; set => _FlagAutomatico = value; }
        public string FlagBanco { get => _FlagBanco; set => _FlagBanco = value; }
        public string HistoAjuste { get => _HistoAjuste; set => _HistoAjuste = value; }
    }
}
