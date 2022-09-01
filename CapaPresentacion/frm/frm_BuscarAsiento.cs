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
using CapaEntidades.lib;

namespace CapaPresentacion.frm
{
    public partial class frm_BuscarAsiento : Form
    {
        E_TipoAsiento objEntidad = new E_TipoAsiento();
        N_TipoAsiento objNegocio = new N_TipoAsiento();

        E_Glosas objGlosas = new E_Glosas();
        N_Glosas objNGlosas = new N_Glosas();


        public frm_BuscarAsiento()
        {
            InitializeComponent();
            ListarTipoAsiento();
        }

        public void ListarTipoAsiento()
        {
            N_TipoAsiento objTipoAsiento = new N_TipoAsiento();
            cmbTipoAsiento.DataSource = objTipoAsiento.ListandoTipoAsiento("");
            cmbTipoAsiento.DisplayMember = "NomAsiento";
            cmbTipoAsiento.ValueMember = "TipoAsiento";
        }

        private void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            this.Close();
            Variables.busqueda = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
            Variables.busqueda = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNroAsiento.Text.Trim() != "")
                {
                    objGlosas.NRO_ASIENTO = Convert.ToInt32(txtNroAsiento.Text);
                    objGlosas.PERIODO = txtPeriodo.Text.Trim();
                    objGlosas.MES = txtMes.Text.Trim();
                    objGlosas.TIPO_ASIENTO = Convert.ToString(cmbTipoAsiento.SelectedValue);
                    //MessageBox.Show(Convert.ToString(cmbTipoAsiento.SelectedValue));
                    var valid = objNGlosas.BuscandoGlosas(objGlosas);

                    //MessageBox.Show(Convert.ToString(validLogin));
                    if (valid == true)
                    {
                        this.Close();
                        Variables.busqueda = true;
                    }
                    else
                    {
                       
                        frm_Alert.confirmacionForm("Asiento Contable no Existe, vuelva a intentarlo");
                    }
                }
                else {
                    
                    frm_Alert.confirmacionForm("Falta ingresar datos");
                    
                }
            }
            catch (Exception ex) {
                frm_Alert.confirmacionForm("error: " + ex);
            }
            
            

        }

        private void msgError(string msg)
        {
            lblError.Text = "       " + msg;
            lblError.Visible = true;
        }

        private void txtCodtipoAsiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                cmbTipoAsiento.SelectedValue = Convert.ToInt32(txtCodtipoAsiento.Text).ToString("D2");
                if (cmbTipoAsiento.Text == "")
                {
                    frm_Alert.confirmacionForm("CODIGO DE TIPO DE ASIENTO INCORRECTO");
                    txtCodtipoAsiento.Focus();

                }
                else
                {
                    txtNroAsiento.Focus(); 
                }
            }
        }

        private void cmbTipoAsiento_SelectedValueChanged(object sender, EventArgs e)
        {
            txtCodtipoAsiento.Text = Convert.ToString(cmbTipoAsiento.SelectedValue);
        }

        
    }
}
