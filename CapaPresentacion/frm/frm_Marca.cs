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

namespace CapaPresentacion
{
    public partial class frm_Marca : Form
    {
        private string idmarca;
        private bool editar = false;

        E_Marca objEntidad = new E_Marca();
        N_Marca objNegocio = new N_Marca();
        public frm_Marca()
        {
            InitializeComponent();
        }

        private void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Marca_Load(object sender, EventArgs e)
        {
            mostrarbuscarTabla("");
            accionesTabla();
        }

        public void accionesTabla()
        {
            dgvMarca.Columns[0].Visible = false;
            dgvMarca.Columns[1].Width = 60;
            dgvMarca.Columns[2].Width = 140;
            dgvMarca.ClearSelection();
        }

        private void limpiarCajas()
        {
            editar = false;
            txtCodigo.Text = "";
            txtNombres.Text = "";
            txtDescripcion.Text = "";

            txtNombres.Focus();
        }
        public void mostrarbuscarTabla(string buscar)
        {
            N_Marca objNegocio = new N_Marca();

            dgvMarca.DataSource = objNegocio.ListandoMarca(buscar);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCajas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMarca.SelectedRows.Count > 0)
            {
                editar = true;
                idmarca = dgvMarca.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = dgvMarca.CurrentRow.Cells[1].Value.ToString();
                txtNombres.Text = dgvMarca.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = dgvMarca.CurrentRow.Cells[3].Value.ToString();
                
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = new DialogResult();
                frm_Information frm = new frm_Information("¿Estas seguro de eliminar el registro?");
                resultado = frm.ShowDialog();

                if (resultado == DialogResult.OK) 
                {
                    objEntidad.Idmarca = Convert.ToInt32(dgvMarca.CurrentRow.Cells[0].Value.ToString());
                    objNegocio.EliminandoMarca(objEntidad);
                    frm_Success.confirmacionForm("ELIMINADO"); //MessageBox.Show("Se elimino el registro correctamente");
                    mostrarbuscarTabla("");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione la fila que desea editar" + ex);
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    objEntidad.Nombremarca = txtNombres.Text;
                    objEntidad.Descripcionmarca = txtDescripcion.Text;

                    objNegocio.InsertandoMarca(objEntidad);

                    frm_Success.confirmacionForm("GUARDADO");
                    mostrarbuscarTabla("");
                    limpiarCajas();
                }
                catch
                {
                    MessageBox.Show("no se pudo grabar el registro");
                }
            }

            if (editar == true)
            {
                try
                {
                    objEntidad.Idmarca = Convert.ToInt32(idmarca);
                    objEntidad.Nombremarca = txtNombres.Text;
                    objEntidad.Descripcionmarca = txtDescripcion.Text;

                    objNegocio.EditandoMarca(objEntidad);

                    frm_Success.confirmacionForm("EDITADO");
                    mostrarbuscarTabla("");
                    limpiarCajas();
                }
                catch
                {
                    MessageBox.Show("no se pudo editar el registro");
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarbuscarTabla(txtBuscar.Text);
        }
    }
}
