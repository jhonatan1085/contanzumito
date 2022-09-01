using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Categoria
    {
        D_Categoria objData = new D_Categoria();

        public List<E_Categoria>ListandoCaterogia(String buscar)
        {
            return objData.ListarCategorias(buscar);
        }

        public void InsertandoCategoria(E_Categoria Categoria)
        {
            objData.InsertarCategoria(Categoria);
        }

        public void EditandoCategoria(E_Categoria Categoria)
        {
            objData.EditarCategoria(Categoria);
        }

        public void EliminandoCategoria(E_Categoria Categoria)
        {
            objData.EliminarCategoria(Categoria);
        }
    }
}
