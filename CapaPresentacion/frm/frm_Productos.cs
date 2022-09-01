using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion.frm
{
    public partial class frm_Productos : Form
    {

        N_Productos objproducto = new N_Productos();
        public frm_Productos()
        {
            InitializeComponent();
            
        }

        public void OcultarMoverAncharColumnas()
        {
            dgvProductos.Columns[2].Visible = false;
            dgvProductos.Columns[5].Visible = false;
            dgvProductos.Columns[7].Visible = false;
            dgvProductos.Columns[3].Width = 60;

            dgvProductos.Columns[4].Width = 200;

            dgvProductos.Columns[0].DisplayIndex = 11;
            dgvProductos.Columns[1].DisplayIndex = 11;

        }
        public void MostrarTablaProducto()
        {
            N_Productos objNegocio = new N_Productos();
            dgvProductos.DataSource = objNegocio.ListandoProductos();
        }

        public void BuscarProductos(string buscar)
        {
            N_Productos objNegocio = new N_Productos();
            dgvProductos.DataSource = objNegocio.BuscandoProductos(buscar);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarProductos(txtBuscar.Text);
        }


        private void frm_Productos_Load(object sender, EventArgs e)
        {
            MostrarTablaProducto();
            OcultarMoverAncharColumnas();
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            frm_MantenimientoProducto frm = new frm_MantenimientoProducto();
            frm.ShowDialog();
            frm.Update= false;
            MostrarTablaProducto();

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.Rows[e.RowIndex].Cells["eliminar"].Selected)
            {

                frm_Information mensaje = new frm_Information("¿Estas seguro de eliminar el registro?");
                DialogResult resultado = mensaje.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    int delete = Convert.ToInt32(dgvProductos.Rows[e.RowIndex].Cells[2].Value.ToString());
                    objproducto.EliminandoProductos(delete);
                    frm_Success.confirmacionForm("ELIMINADO");
                    MostrarTablaProducto();
                }
            }
            else if (dgvProductos.Rows[e.RowIndex].Cells["editar"].Selected)
            {
                frm_MantenimientoProducto frm = new frm_MantenimientoProducto();

                frm.Update = true;
                frm.txtId.Text = dgvProductos.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.txtCodigo.Text = dgvProductos.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.txtNombre.Text = dgvProductos.Rows[e.RowIndex].Cells[4].Value.ToString();
                frm.txtPrecioCompra.Text = dgvProductos.Rows[e.RowIndex].Cells[9].Value.ToString();
                frm.txtPrecioVenta.Text = dgvProductos.Rows[e.RowIndex].Cells[10].Value.ToString();
                frm.txtStock.Text = dgvProductos.Rows[e.RowIndex].Cells[11].Value.ToString();
                frm.cmbCategoria.Text = dgvProductos.Rows[e.RowIndex].Cells[6].Value.ToString();
                frm.cmbMarca.Text = dgvProductos.Rows[e.RowIndex].Cells[8].Value.ToString();

                frm.ShowDialog();
            }
        }

        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            frm_Categoria frm = new frm_Categoria();
            frm.ShowDialog();
        }

        private void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            frm_Marca frm = new frm_Marca();
            frm.ShowDialog();
        }
    }
    
}
