using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion.frm
{
    public partial class frm_MantenimientoProducto : Form
    {
        frm.frm_Productos frm = new frm_Productos();
        E_Productos entidad = new E_Productos();
        N_Productos negocio = new N_Productos();
        public bool Update = false;
        public frm_MantenimientoProducto()
        {
            InitializeComponent();
            ListarCategorias();
            ListarMarcas();
        }
        public void ListarCategorias()
        {
            N_Categoria objCategoria = new N_Categoria();
            cmbCategoria.DataSource = objCategoria.ListandoCaterogia("");
            cmbCategoria.DisplayMember = "Nombrecategoria";
            cmbCategoria.ValueMember = "Idcategoria";

        }

        public void ListarMarcas()
        {
            N_Marca objMarca = new N_Marca();
            cmbMarca.DataSource = objMarca.ListandoMarca("");
            cmbMarca.ValueMember = "Idmarca";
            cmbMarca.DisplayMember = "Nombremarca";
            
        }

        private void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Update == false)
            {
                try
                {
                    entidad.Producto = txtNombre.Text;
                    entidad.Preciocompra = Convert.ToDecimal(txtPrecioCompra.Text);
                    entidad.Precioventa = Convert.ToDecimal(txtPrecioVenta.Text);
                    entidad.Stock = Convert.ToInt32(txtStock.Text);
                    entidad.Idcategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                    entidad.Idmarca = Convert.ToInt32(cmbMarca.SelectedValue);

                    negocio.CreandoProductos(entidad);
                    frm_Success.confirmacionForm("PRODUCTO GUARDADO");
                    Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show("no se pudo guardar el producto" + ex);
                }
            }
            if (Update == true)
            {
                try
                {
                    entidad.Idproducto = Convert.ToInt32(txtId.Text);
                    entidad.Producto = txtNombre.Text;
                    entidad.Preciocompra = Convert.ToDecimal(txtPrecioCompra.Text);
                    entidad.Precioventa = Convert.ToDecimal(txtPrecioVenta.Text);
                    entidad.Stock = Convert.ToInt32(txtStock.Text);
                    entidad.Idcategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                    entidad.Idmarca = Convert.ToInt32(cmbMarca.SelectedValue);

                    negocio.EditandoProductos(entidad);
                    frm_Success.confirmacionForm("PRODUCTO EDITADO");
                    Close();

                    Update = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se pudo editar el producto" + ex);
                }
            }
        }
    }
}
