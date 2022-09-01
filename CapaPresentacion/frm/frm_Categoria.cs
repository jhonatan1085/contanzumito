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
    public partial class frm_Categoria : Form
    {

        private string idcategoria;
        private bool editar = false;

        E_Categoria objEntidad = new E_Categoria();
        N_Categoria objNegocio = new N_Categoria();
        public frm_Categoria()
        {
            InitializeComponent();
        }

        private void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Categoria_Load(object sender, EventArgs e)
        {
            mostrarbuscarTabla("");
            accionesTabla();
        }

        public void accionesTabla()
        {
            dgvCategoria.Columns[0].Visible = false;
            dgvCategoria.Columns[1].Width = 60;
            dgvCategoria.Columns[2].Width = 140;
            dgvCategoria.ClearSelection();
        }
        public void mostrarbuscarTabla(string buscar)
        {
            N_Categoria objNegocio = new N_Categoria();

            dgvCategoria.DataSource = objNegocio.ListandoCaterogia(buscar);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarbuscarTabla(txtBuscar.Text);
        }

        private void limpiarCajas() 
        {
            editar = false;
            txtCodigo.Text = "";
            txtNombres.Text = "";
            txtDescripcion.Text = "";

            txtNombres.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCajas();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.SelectedRows.Count > 0)
            {
                idcategoria = dgvCategoria.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = dgvCategoria.CurrentRow.Cells[1].Value.ToString();
                txtNombres.Text = dgvCategoria.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = dgvCategoria.CurrentRow.Cells[3].Value.ToString();
                editar = true;
            }
            else {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (editar == false) {
                try
                {
                    objEntidad.Nombrecategoria = txtNombres.Text;
                    objEntidad.Descripcioncategoria = txtDescripcion.Text;

                    objNegocio.InsertandoCategoria(objEntidad);

                    MessageBox.Show("se guardo el registro");
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
                    objEntidad.Idcategoria = Convert.ToInt32( idcategoria);
                    objEntidad.Nombrecategoria = txtNombres.Text;
                    objEntidad.Descripcioncategoria = txtDescripcion.Text;

                    objNegocio.EditandoCategoria(objEntidad);

                    MessageBox.Show("se edito el registro");
                    mostrarbuscarTabla("");
                    limpiarCajas();
                }
                catch
                {
                    MessageBox.Show("no se pudo editar el registro");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.SelectedRows.Count > 0)
            {
                objEntidad.Idcategoria = Convert.ToInt32(dgvCategoria.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminandoCategoria(objEntidad);
                MessageBox.Show("Se elimino el registro correctamente");
                mostrarbuscarTabla("");
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void dgvCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
