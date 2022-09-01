using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
   public class N_Marca
    {
        D_Marca objData = new D_Marca();

        public List<E_Marca> ListandoMarca(String buscar)
        {
            return objData.ListarMarca(buscar);
        }

        public void InsertandoMarca(E_Marca Marca)
        {
            objData.InsertarMarca(Marca);
        }

        public void EditandoMarca(E_Marca Marca)
        {
            objData.EditarMarca(Marca);
        }

        public void EliminandoMarca(E_Marca Marca)
        {
            objData.EliminarMarca(Marca);
        }
    }
}
