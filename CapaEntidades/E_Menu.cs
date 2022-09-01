using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class E_Menu
    {
        private String _NOMBRE;
        private String _ICONO;
        private List<E_SubMenu> _LISTASUBMENU;

        public string NOMBRE { get => _NOMBRE; set => _NOMBRE = value; }
        public string ICONO { get => _ICONO; set => _ICONO = value; }
        public List<E_SubMenu> LISTASUBMENU { get => _LISTASUBMENU; set => _LISTASUBMENU = value; }
    }
}
