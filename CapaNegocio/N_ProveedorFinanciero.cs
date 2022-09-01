using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class N_ProveedorFinanciero
    {
        D_ProveedorFinanciero objData = new D_ProveedorFinanciero();
        
        public void InsertarProveedor(E_ProveedorFinanciero Proveedor)
        {
            objData.InsertarProveedor(Proveedor);
        }

        public DataTable BuscaProveedor(string Busqueda, string TipoBusqueda)
        {
            return objData.BuscaProveedor(Busqueda, TipoBusqueda);
        }
    }
}
