using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using CapaDatos;
using System.Data;



namespace CapaNegocio
{
    public class N_Glosas
    {
        D_Glosas objData = new D_Glosas();

        public bool BuscandoGlosas(E_Glosas Glosas)
        {
            return objData.BuscaGlosas(Glosas);
        }

        public DataSet DetallesGlosas(E_Movi movi) {
            return objData.DetalleGlosas(movi);
        }
    }
}
