using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades.lib;
using CapaEntidades;
using CapaNegocio;
using CapaEntidades.cache;
using System.IO;

namespace CapaPresentacion.frm
{
    public partial class frm_RegistroPrestamosProveedores : Form
    {
        E_ProveedorFinanciero objEProveedor = new E_ProveedorFinanciero();
        N_ProveedorFinanciero objNProveedor = new N_ProveedorFinanciero();

        DataGridViewTextBoxColumn COL01 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL02 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL03 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL04 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL05 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL06 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL07 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL08 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL09 = new DataGridViewTextBoxColumn();

        public frm_RegistroPrestamosProveedores()
        {
            InitializeComponent();
        }



        private void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public void formatoGridPrincipal()
        {

     
            COL01.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL01.Width = 40;
            COL01.HeaderText = "Nro.";
            COL01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            COL02.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL02.Width = 80;
            COL02.HeaderText = "Fecha";
            COL02.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            COL03.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL03.Width = 100;
            COL03.HeaderText = "Saldo";
            COL03.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;




            COL04.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL04.Width = 100;
            COL04.HeaderText = "Amortización";
            COL04.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            COL05.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL05.Width = 80;
            COL05.HeaderText = "Interes";
            COL05.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            COL06.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL06.Width = 60;
            COL06.HeaderText = "Igv";
            COL06.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            COL07.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL07.Width = 80;
            COL07.HeaderText = "Cuota";
            COL07.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            COL08.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL08.Width = 60;
            COL08.HeaderText = "Aportes";
            COL08.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            COL09.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL09.Width = 80;
            COL09.HeaderText = "Total";
            COL09.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            COL01.Name = "COL01";
            COL02.Name = "COL02";
            COL03.Name = "COL03";
            COL04.Name = "COL04";
            COL05.Name = "COL05";
            COL06.Name = "COL06";
            COL07.Name = "COL07";
            COL08.Name = "COL08";
            COL09.Name = "COL09";

            dgvCronograma.Columns.AddRange(COL01, COL02, COL03, COL04, COL05,COL06, COL07, COL08, COL09);

        }

        private void frm_RegistroPrestamosProveedores_Load(object sender, EventArgs e)
        {
            formatoGridPrincipal();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlProveedor.Enabled = true;
            dgvCronograma.Enabled = true;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            txtRuc.Focus();
            txtMes.Text = Variables.w_mes;
            txtAnio.Text = Variables.Num_Periodo;
            ListarBancos();
            ListarTipoFrecuencia();
        }


        public void ListarBancos()
        {
            N_Bancos objBancos = new N_Bancos();
            cmbBanco.DataSource = objBancos.ListarBancos("");
            cmbBanco.DisplayMember = "NOM_BANCO";
            cmbBanco.ValueMember = "COD_BANCO";
        }

        public void ListarTipoFrecuencia()
        {
            N_TipoFrecuencia objTipoFrecuencia = new N_TipoFrecuencia();
            cmbFrecuencia.DataSource = objTipoFrecuencia.ListarTipoFrecuencia();
            cmbFrecuencia.DisplayMember = "Descripcion";
            cmbFrecuencia.ValueMember = "id_Tipo_frecuencia";
        }



        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && txtRuc.Text.Length == 0)
            {

                pnlRegistroProveedor.Visible = true;
                pnlProveedor.Enabled = false;
                dgvCronograma.Enabled = false;
                txtRucProveedor.Focus();
            }

            if (e.KeyChar == (char)Keys.Enter && txtRuc.Text.Length > 0)
            {



                N_ProveedorFinanciero objProveedor = new N_ProveedorFinanciero();

                DataTable data = objProveedor.BuscaProveedor(txtRuc.Text, "U");

                if (data.Rows.Count > 0)
                {

                    DataRow row = data.Rows[0];

                    txtRazonSocial.Text = row["RAZON_SOCIAL"].ToString();

                    txtDia.Focus();

                }
                else
                {
                    frm_Alert.confirmacionForm("NRO DE RUC NO SE ENCUENTRA REGISTRADO");
                    txtDescripcionCta.Text = string.Empty;
                    return;
                }


            }

        }

        private void txtCuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                frm_BuscaCodCuenta frm = new frm_BuscaCodCuenta();
                frm.ShowDialog();

                txtCuenta.Text = Variables.cod_cta;
                txtDescripcionCta.Text = Variables.nom_cta;


                Variables.cod_cta  = string.Empty;
                Variables.nom_cta = string.Empty;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            
            LimpiaRegProv();
        }

        private void LimpiaRegProv() {
            txtRucProveedor.Text = string.Empty;
            txtRSProv.Text = string.Empty;
            txtCuenta.Text = string.Empty;
            txtDescripcionCta.Text = string.Empty;
            pnlRegistroProveedor.Visible = false;
            dgvCronograma.Enabled = true;
            pnlProveedor.Enabled = true;
        }

        private void btnCancelarProveedor_Click(object sender, EventArgs e)
        {
           
            LimpiaRegProv();
        }

        private void txtCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && txtCuenta.Text.Length > 0)
            {

                
                if (txtCuenta.Text.Length == 2)
                {
                    frm_Alert.confirmacionForm("Ingrese mas digitos por favor!!");
                    return;
                }

                if (txtCuenta.Text.Substring(2, 1) == "0")
                {
                    frm_Alert.confirmacionForm("Esta cuenta no permite movimiento, por favor vuelva a intentarlo");
                    return;
                }

                if (txtCuenta.Text.Substring(0, 2) != "24")
                {
                    frm_Alert.confirmacionForm("Este nro de cuenta no esta permitido");
                    return;
                }


                N_Catalogo objCatalogo = new N_Catalogo();

                DataTable data = objCatalogo.BuscandoCatalogo(txtCuenta.Text, "U");

                if (data.Rows.Count > 0)
                {

                    DataRow row = data.Rows[0];


                    if (row["NIVEL_CTA"].ToString() != "M")
                    {
                        frm_Alert.confirmacionForm("Esta cuenta no permite movimiento, por favor vuelva a intentarlo");
                        txtDescripcionCta.Text = string.Empty;
                        return;
                    }


                    txtDescripcionCta.Text = row["NOM_CTA"].ToString();

                }
                else
                {
                    frm_Alert.confirmacionForm("Error, no existe en el plan de cuentas o su estado es inactivo");
                    txtDescripcionCta.Text = string.Empty;
                    return;
                }


            }
        }

        private void btnGravarProveedor_Click(object sender, EventArgs e)
        {
            try
            {

                objEProveedor.NRO_RUC = txtRucProveedor.Text;
                objEProveedor.RAZON_SOCIAL = txtRSProv.Text;
                objEProveedor.COD_CTA = txtCuenta.Text;

                objNProveedor.InsertarProveedor(objEProveedor);

                frm_Success.confirmacionForm("GUARDADO");
                txtRuc.Text = txtRucProveedor.Text;
                txtRazonSocial.Text = txtRSProv.Text;
                txtDia.Focus();
                LimpiaRegProv();

            }
            catch (Exception ex)
            {
                
                frm_Alert.confirmacionForm(ex.Message);
            }
        }

        private void txtRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                frm_BuscaProveedor frm = new frm_BuscaProveedor();
                frm.ShowDialog();

                txtRuc.Text = Variables.Ruc;
                txtRazonSocial.Text = Variables.Razon_Social;

                txtDia.Focus();

                Variables.Ruc = string.Empty;
                Variables.Razon_Social = string.Empty;

            }
        }

        private void cmbBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBanco.SelectedIndex != -1)
            {
                ListarCtaCte(Convert.ToString(cmbBanco.SelectedValue));
            }
        }

        public void ListarCtaCte(string codbanco)
        {
            N_CtaCte objCtaCte = new N_CtaCte();
            cmbCuenta.DataSource = objCtaCte.ListarCtaCte(codbanco);
            cmbCuenta.DisplayMember = "NRO_CTACTE";
            cmbCuenta.ValueMember = "COD_CTA";
        }

        private void txtDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtMonto.Focus();
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double d = Convert.ToDouble(txtMonto.Text);

                
                txtMonto.Text = d.ToString("#,##0.00");
                  //  Convert.ToString(String.Format("{0:#,##0.00}", txtMonto.Text));
                txtImpAbono.Focus();
            }
        }

        private void txtImpAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double d = Convert.ToDouble(txtImpAbono.Text);


                txtImpAbono.Text = d.ToString("#,##0.00");

                cmbFrecuencia.DroppedDown = true;
                cmbFrecuencia.Focus();
            }
        }


        private void cmbFrecuencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtFlat.Focus();
            }
        }

        private void txtFlat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double d = Convert.ToDouble(txtFlat.Text);


                txtFlat.Text = d.ToString("##0.00");

                txtTasa.Focus();
            }
        }

        private void txtTasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                double d = Convert.ToDouble(txtTasa.Text);
                txtTasa.Text = d.ToString("##0.00");

                txtPlazo.Focus();
            }
        }

        private void txtPlazo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                rbtSoles.Focus();
            }
        }

        private void rbtSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbBanco.DroppedDown = true;
                cmbBanco.Focus();
            }
        }

        private void rbtDolares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbBanco.DroppedDown = true;
                cmbBanco.Focus();
            }
        }

        private void cmbBanco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ListarCtaCte(Convert.ToString(cmbBanco.SelectedValue));
                cmbCuenta.DroppedDown = true;
                cmbCuenta.Focus();
            }
        }
    }
}
