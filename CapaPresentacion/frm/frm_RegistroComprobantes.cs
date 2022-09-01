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
using Microsoft.VisualBasic;

namespace CapaPresentacion.frm
{
    public partial class frm_RegistroComprobantes : Form
    {


        DataGridViewTextBoxColumn COL1 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL2 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL3 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL4 = new DataGridViewTextBoxColumn();

        DataGridViewTextBoxColumn COL11 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL22 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL33 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL44 = new DataGridViewTextBoxColumn();

        DataGridViewTextBoxColumn COL55 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL66 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL77 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL88 = new DataGridViewTextBoxColumn();



        DataGridViewTextBoxColumn COL01= new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL02 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL03 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL04 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL05 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL06 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL07 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL08 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL09 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL010 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL011 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL012 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL013 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL014 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL015 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL016 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL017 = new DataGridViewTextBoxColumn();





        double t_base;

        string sCaracteres;
        string sCaracteres1;
        int flag_new_edit;
        int Ndoc;
        string Tipo_usuario;
        string w_fecha_asiento;
        string nDieta;
        string TipIngreso;
       
        string compartido;
        double tipo_cambio_doc;
        string CF, BS, de_cr;


        



        public frm_RegistroComprobantes()
        {
            InitializeComponent();
            Variables.tipo_cambio = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frm_BuscarAsiento frm = new frm_BuscarAsiento();
            frm.ShowDialog();
            if (Variables.busqueda == true) {

                ListarTipoAsiento();
                ListarAgencias();
                MostrarDetalleAsiento();
                OcultarMoverAncharColumnas();
                sumar();
                inactivaCajas();
            }
            
        }
        

        public void ListarTipoAsiento()
        {
            N_TipoAsiento objTipoAsiento = new N_TipoAsiento();
            cmbTipoAsiento.DataSource = objTipoAsiento.ListandoTipoAsiento("");
            cmbTipoAsiento.DisplayMember = "NomAsiento";
            cmbTipoAsiento.ValueMember = "TipoAsiento";
        }

        public void ListarAgencias()
        {
            N_Agencias objAgencias = new N_Agencias();
            cmbAgenciaDestino.DataSource = objAgencias.ListandoAgencias("","T");
            cmbAgenciaDestino.DisplayMember = "NOM_AGE";
            cmbAgenciaDestino.ValueMember = "COD_AGE_DESTINO";

            cmbAgenciaOrigen.DataSource = objAgencias.ListandoAgencias("", "T");
            cmbAgenciaOrigen.DisplayMember = "NOM_AGE";
            cmbAgenciaOrigen.ValueMember = "COD_AGE_DESTINO";

        }
        public void OcultarMoverAncharColumnas()
        {

            dgvMovi.Columns[0].Width = 40;
            dgvMovi.Columns[1].Width = 100;
            dgvMovi.Columns[2].Width = 250;
            dgvMovi.Columns[3].Width = 35;
            dgvMovi.Columns[4].Width = 60;
            dgvMovi.Columns[5].Width = 60;
            dgvMovi.Columns[6].Width = 60;
            dgvMovi.Columns[7].Width = 150;

            
            dgvMovi.Columns[8].Visible = false;
            dgvMovi.Columns[9].Visible = false;
            dgvMovi.Columns[10].Visible = false;
            dgvMovi.Columns[11].Visible = false;
            dgvMovi.Columns[12].Visible = false;
            dgvMovi.Columns[13].Visible = false;
            dgvMovi.Columns[14].Visible = false;
            dgvMovi.Columns[15].Visible = false;
            dgvMovi.Columns[16].Visible = false;
            dgvMovi.Columns[17].Visible = false;
            dgvMovi.Columns[18].Visible = false;
            dgvMovi.Columns[19].Visible = false;
            dgvMovi.Columns[20].Visible = false;
            dgvMovi.Columns[21].Visible = false;
            

            dgvMovi.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMovi.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMovi.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMovi.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMovi.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        private void sumar()
        {
            try
            {

                int x;
                x = dgvMovi.Rows.Count;
                if (x == 0)
                {
                    txtdebeme.Text = "0.00";
                    txtHaberme.Text = "0.00";
                    txtDebemn.Text = "0.00";
                    txtHabermn.Text = "0.00";
                }

                double debemn;
                double habermn;
                double debeme;
                double haberme;

                debemn = 0;
                habermn = 0;
                debeme = 0;
                haberme = 0;

                foreach (DataGridViewRow fila in dgvMovi.Rows)
                {
                    if (Convert.ToString(fila.Cells["DE_HA"].Value) == "D") {
                        debemn += Convert.ToDouble(fila.Cells["IMP_SOlES"].Value);
                        debeme += Convert.ToDouble(fila.Cells["IMP_DOLAR"].Value);
                    }
                    else if (Convert.ToString(fila.Cells["DE_HA"].Value) == "H") {
                        habermn +=Convert.ToDouble(fila.Cells["IMP_SOlES"].Value);
                        haberme += Convert.ToDouble(fila.Cells["IMP_DOLAR"].Value);
                    }
                }

                txtDebemn.Text = Convert.ToString(String.Format("{0:#,##0.00}", debemn));
                txtdebeme.Text = Convert.ToString(String.Format("{0:#,##0.00}", debeme));
                txtHaberme.Text = Convert.ToString(String.Format("{0:#,##0.00}", haberme));
                txtHabermn.Text = Convert.ToString(String.Format("{0:#,##0.00}", habermn));

                double difMN;
                double difME;

                difMN = debemn - habermn;
                difME = debeme - haberme;

                txtDifMN.Text = String.Format("{0:#,##0.00}", difMN);
                txtDifME.Text = String.Format("{0:#,##0.00}", difME);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void MostrarDetalleAsiento()
        {
            
            E_Movi entimovi = new E_Movi();

            entimovi.NRO_ASIENTO = Variables.nroAsiento;
            entimovi.PERIODO = Variables.periodo;
            entimovi.TIPO_ASIENTO = Variables.tipoasiento;
            entimovi.MES = Variables.mes;
            
             N_Movi objmovi = new N_Movi();
            N_Glosas objGlosas = new N_Glosas();
            dgvMovi.DataSource = objmovi.BuscandoMovi(entimovi);

            DataSet ds = new DataSet();

            ds = objGlosas.DetallesGlosas(entimovi);
            if (ds.Tables.Count > 0)
            {
                txtNombreGlosa.Text = ds.Tables[0].Rows[0]["NOMBRE"].ToString();
                txtGlosa.Text = ds.Tables[0].Rows[0]["DETALLE"].ToString();
                txtMesGlosa.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["FECHA_ASIENTO"].ToString()).ToString("MM");
                txtAnioGlosa.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["FECHA_ASIENTO"].ToString()).ToString("yyyy");
                txtNroAsientoGlosa.Text = ds.Tables[0].Rows[0]["NRO_ASIENTO"].ToString();
                txtDiaGlosa.Text = Convert.ToDateTime( ds.Tables[0].Rows[0]["FECHA_ASIENTO"].ToString()).ToString("dd");
                cmbTipoAsiento.Text = ds.Tables[0].Rows[0]["NOM_ASIENTO"].ToString();
                cmbAgenciaDestino.Text = ds.Tables[0].Rows[0]["NOM_AGE_DESTINO"].ToString();
                cmbAgenciaOrigen.Text = ds.Tables[0].Rows[0]["NOM_AGE_ORIGEN"].ToString();
                if (ds.Tables[0].Rows[0]["ESTADO"].ToString().Trim() == "99" || ds.Tables[0].Rows[0]["ESTADO"].ToString().Trim() == "9") {
                    pbAnulado.Visible = true;
                }
                else
                {
                    pbAnulado.Visible = false;
                }


                if (ds.Tables[0].Rows[0]["MONEDA"].ToString() == "S")
                {
                    rbtSoles.Checked = true;
                }
                else if (ds.Tables[0].Rows[0]["MONEDA"].ToString() == "D") {
                    rbtDolares.Checked = true;
                }
            }
            
            
        }

        private void txtCodtipoAsiento_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                cmbTipoAsiento.SelectedValue = Convert.ToInt32(txtCodtipoAsiento.Text).ToString("D2");
                if (cmbTipoAsiento.Text == "")
                {
                    txtCodtipoAsiento.Focus();
                }
                else
                {
                    txtDiaGlosa.Focus();
                }
            }

        }

        private void cmbTipoAsiento_SelectedValueChanged(object sender, EventArgs e)
        {
            txtCodtipoAsiento.Text = Convert.ToString(cmbTipoAsiento.SelectedValue);
        }

        private void frm_RegistroComprobantes_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.F3) {
                if (txtNroAsientoGlosa.Text == "")
                {
                    frm_Alert.confirmacionForm("No a realizado la busqueda de asiento a editar");
                }
                else {
                    
                    activacajaseditar();
                    txtDiaGlosa.Focus();
                }
            }
            if (e.KeyData == Keys.F2)
            {
                frm_Alert.confirmacionForm("presiono f2");
            }

        }

        public void inactivaCajasCuenta()
        {


            txtCuenta.Text = string.Empty;
            txtDescrip.Text = string.Empty;
            rbtDCuenta.Checked = false;
            rbtHCuenta.Checked = false;
            txtDocum.Text = string.Empty;
            txtDolares.Text = "0.00";
            txtTc.Text = "0.000";
            txtSoles.Text = "0.00";
            txtRef.Text = string.Empty;


            lblTipoReg.Text = string.Empty;
            lblFechaReg.Text = string.Empty;
            lblNroRuc.Text = string.Empty;
            lblDocSunat.Text = string.Empty;
            lblNroDocum.Text = string.Empty;
            lblTotalRel.Text = string.Empty;
            dgvBaseImponible.Columns.Clear();
            //faltan los botones

            txtCuenta.Focus();

        }
            public void inactivaCajas()
        {
            //falta de otros

            txtCodtipoAsiento.Text = string.Empty;
            cmbTipoAsiento.Text = string.Empty;

            //llena el dia y el periodo


            txtNombreGlosa.Text = string.Empty;
            txtGlosa.Text = string.Empty;


            cmbAgenciaDestino.Text = String.Empty;

            rbtSoles.Checked = true;
            rbtDolares.Checked = false;

            Frm_Glosa.Enabled = false;

            txtNroAsientoGlosa.Text = "< Autogenerado >";

            btnCuenta.Enabled = false;
            btnDocumento.Enabled = false;
            btnCheque.Enabled = false;

            btnCancelar.Enabled = false;

            btnNuevo.Enabled = true;
            btnBuscar.Enabled = true;
            btnListar.Enabled = true;

            btnGrabar.Enabled = false;


        }

        public void activacajaseditar()
        {
            txtCodtipoAsiento.Enabled = false;
            cmbTipoAsiento.Enabled = false;
            txtDiaGlosa.Enabled = true;
            txtMesGlosa.Enabled = false;
            txtAnioGlosa.Enabled = false;
            txtNombreGlosa.Enabled = true;
            txtGlosa.Enabled = true;
            cmbAgenciaOrigen.Enabled = false;
            cmbAgenciaDestino.Enabled = true;
            rbtSoles.Enabled = false;
            rbtDolares.Enabled = false;
            btnListar.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            inactivaCajas();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Ndoc = 0;

            cbkManual.Checked = false;
            txtMontoBaseImponible.Text = "0";
            TipIngreso = "3";

            if (LoginCache.Tipo_usuario != "02" && LoginCache.Tipo_usuario != "03") {
                frm_Alert.confirmacionForm("Su usuario es exclusivamente para consultas");

                return;

            }

            if (Variables.Estado_Mes == "C")
            {
                frm_Alert.confirmacionForm("El periodo seleccionado esta cerrado, no se admiten cambios");

                return;
            }


            txtNeto.Text = "0.00"; //falta este boton
            w_fecha_asiento = String.Empty;

            pbAnulado.Visible = false;

            txtCodtipoAsiento.Text = string.Empty;
            cmbTipoAsiento.Text = string.Empty;



            btnCuenta.Enabled = true;
            btnDocumento.Enabled = true;
            btnCheque.Enabled = true;
            btnCancelar.Enabled = true;

            btnNuevo.Enabled = false;
            btnBuscar.Enabled = false;
            btnListar.Enabled = false;

            btnGrabar.Enabled = true;

            //falta


            lbl_caja.Text = string.Empty; 
            lbl_origen.Text = "CONT";
            lbl_estado.Text = string.Empty;

            txtCodtipoAsiento.Text = string.Empty;
            cmbTipoAsiento.Text = string.Empty;

            //llena el dia y el periodo

            txtDiaGlosa.Text = string.Empty;

            if (Variables.Num_mes == "00")
            {
                txtMesGlosa.Text = "01";
            }
            else {
                if (Variables.Num_mes == "13") {
                    txtMesGlosa.Text = "12";
                }
                else {
                    txtMesGlosa.Text = Variables.Num_mes;
                }
            }

            txtAnioGlosa.Text = Variables.Num_Periodo;

            txtNroAsientoGlosa.Text = "< Autogenerado >";
            txtNombreGlosa.Text = string.Empty;
            txtGlosa.Text = string.Empty;

            cmbAgenciaDestino.Text = cmbAgenciaOrigen.Text;

            rbtSoles.Checked = true;
            rbtDolares.Checked = false;
            Frm_Glosa.Enabled = true;

            txtCodtipoAsiento.Focus();

        }

        private void frm_RegistroComprobantes_Load(object sender, EventArgs e)
        {
            ListarAgencias();
        }

        private void btnCuenta_Click(object sender, EventArgs e)
        {

            BS = "";
            TipIngreso = "0";
            frm_cuenta.Visible = true;
            inactivaCajasCuenta();
        }

        private void txtCuenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                frm_BuscaCodCuenta frm = new frm_BuscaCodCuenta();
                frm.ShowDialog();

                txtCuenta.Text = Variables.cod_cta;
                txtDescrip.Text = Variables.nom_cta;



                if (Variables.nroctacte > 0)
                {
                    txtDocum.Visible = true;
                    panel21.Visible = true;
                    label29.Visible = true;
                    txtDocum.Text = string.Empty;
                }
                else
                {
                    txtDocum.Visible = false;
                    panel21.Visible = false;
                    label29.Visible = false;
                    txtDocum.Text = string.Empty;
                }



                rbtDCuenta.Focus();
            }
        }

        public void activaDocum(string cuenta) {


            txtDocum.Visible = false;

        }

        private void txtCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter &&  txtCuenta.Text.Length == 0)
            {
                formatogrillaBaseImp();
                pnlBaseImponible.Visible = true;
                txtCuenta.Text = "DESGLOSE";
                txtMontoBaseImponible.Text = "";
                cbkManual.Checked = false;
                txtMontoBaseImponible.Enabled = false;
                dgvBaseImponible.Focus();

                if (rbtSoles.Checked == true) {
                    txtSoles.Text = String.Format("{0:#,##0.00}", t_base);
                    txtDolares.Text = "0.00";
                }
                if (rbtDolares.Checked == true)
                {
                    txtDolares.Text = String.Format("{0:#,##0.00}", t_base);
                }
            }


            if (e.KeyChar == (char)Keys.Enter && txtCuenta.Text != "DESGLOSE" )
            {

                
                
                if (txtCuenta.Text.Substring(2,1) == "0") {
                    frm_Alert.confirmacionForm("Esta cuenta no permite movimiento, por favor vuelva a intentarlo");
                    return;
                
                }


                N_Catalogo objCatalogo = new N_Catalogo();
                
                DataTable data = objCatalogo.BuscandoCatalogo(txtCuenta.Text, "U");

                if (data.Rows.Count > 0)
                {

                    DataRow row = data.Rows[0];


                    if (row["NIVEL_CTA"].ToString() != "M") {
                        frm_Alert.confirmacionForm("Esta cuenta no permite movimiento, por favor vuelva a intentarlo");
                        txtDescrip.Text = string.Empty;
                        txtCuenta.Focus();
                        return;
                    }


                    txtDescrip.Text = row["NOM_CTA"].ToString();


                    if ( Convert.ToInt32( row["nrocta"].ToString()) > 0)
                    {
                        txtDocum.Visible = true;
                        panel21.Visible = true;
                        label29.Visible = true;
                        txtDocum.Text = string.Empty;
                    }
                    else {
                        txtDocum.Visible = false;
                        panel21.Visible = false;
                        label29.Visible = false;
                        txtDocum.Text = string.Empty;
                    }

                    rbtDCuenta.Focus();
                }
                else
                {
                    frm_Alert.confirmacionForm("Error, no existe en el plan de cuentas o su estado es inactivo");
                    txtDescrip.Text = string.Empty;
                    return;
                }

                //
                if (rbtDCuenta.Checked == true || (rbtDCuenta.Checked == false && rbtHCuenta.Checked == false)) {
                    rbtDCuenta.Focus();
                }
                else {
                    rbtHCuenta.Focus();
                }


            }

        }





        private void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            pnlBaseImponible.Visible = false;

            t_base = 0;


            

            if (TipIngreso == "1")
            {

                foreach (DataGridViewRow fila in dgvBaseImponible.Rows)
                {
                    t_base = t_base + Convert.ToDouble(fila.Cells[1].Value);
                }

                txtBaseImponible.Text = String.Format("{0:#,##0.00}", t_base);
            }



            if (TipIngreso == "0")
            {

                foreach (DataGridViewRow fila in dgvBaseImponible.Rows)
                {
                        t_base = t_base + Convert.ToDouble(fila.Cells[1].Value); 
                }

                pnlBaseImponible.Visible = false;


                if (rbtSoles.Checked == true)
                {
                    txtSoles.Text = String.Format("{0:#,##0.00}", t_base);
                    txtDolares.Text = "0.00";
                    rbtDCuenta.Checked = true;
                }
                if (rbtDolares.Checked == true)
                {
                    txtDolares.Text = String.Format("{0:#,##0.00}", t_base);
                    txtSoles.Text = "0.00";
                    rbtDCuenta.Checked = true;
                }

                llenaGrillaMB();

                txtRef.Focus();

            }

        }

        public void llenaGrillaMB()
        {
            if (TipIngreso == "0")
            {

                Ndoc = Ndoc + 1;

                txtNroDocu.Text = Convert.ToString(Ndoc);
                txtDocu.Text = "99";
                txtTipoRegistro.Text = "88";
            }

            formatoGridMB();
            foreach (DataGridViewRow fila in dgvBaseImponible.Rows)
            {
                if (Convert.ToString(fila.Cells[0].Value).Length > 0) {
                    dgvGridMB.Rows.Add(new string[] {
                   Convert.ToString( fila.Cells[0].Value),
                   Convert.ToString( fila.Cells[1].Value),
                   Convert.ToString( fila.Cells[2].Value),
                    txtTipoRegistro.Text,
                    txtDiaGlosa.Text + "/" + txtMesGlosa.Text + "/" + txtAnioGlosa.Text,
                    txtRuc.Text,
                  txtDocu.Text,
                  txtNroDocu.Text
                   });

                }

            }


        }

        public void formatoGridPrincipal()
        {

            COL01.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL01.Width = 40;
            COL01.HeaderText = "Item";
            COL02.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL02.Width = 100;
            COL02.HeaderText = "Cuenta";
            COL03.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL03.Width = 310;
            COL03.HeaderText = "Descripcion";
            COL04.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL04.Width = 40;
            COL04.HeaderText = "D/H";
            COL04.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            COL05.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL05.Width = 70;
            COL05.HeaderText = "US $";
            COL05.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            COL06.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL06.Width = 60;
            COL06.HeaderText = "T.C.";
            COL06.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            COL07.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL07.Width = 70;
            COL07.HeaderText = "S/";
            COL07.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            COL08.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL08.Width = 250;
            COL08.HeaderText = "Referencia";
            COL09.Visible = false;
            COL010.Visible = false;
            COL011.Visible = false;
            COL012.Visible = false;
            COL013.Visible = false;
            COL014.Visible = false;
            COL015.Visible = false;
            COL016.Visible = false;
            COL017.Visible = false;


            COL01.Name = "COL1";
            COL02.Name = "COL2";
            COL03.Name = "COL3";
            COL04.Name = "COL4";
            COL05.Name = "COL5";
            COL06.Name = "COL6";
            COL07.Name = "COL7";
            COL08.Name = "COL8";
            COL09.Name = "COL9";
            COL010.Name = "COL10";
            COL011.Name = "COL11";
            COL012.Name = "COL12";
            COL013.Name = "COL13";
            COL014.Name = "COL14";
            COL015.Name = "COL15";
            COL016.Name = "COL16";
            COL017.Name = "COL17";


            dgvMovi.Columns.AddRange(new DataGridViewTextBoxColumn[] {
            COL01, COL02, COL03,COL04,COL05, COL06, COL07,COL08,COL09,COL010,COL011,COL012,COL013,COL014,COL015,COL016,COL017});

        }

        public void formatoGridMB()
        {
            dgvGridMB.Columns.Clear();

          

            COL11.Name = "COL1";
            COL22.Name = "COL2";
            COL33.Name = "COL3";
            COL44.Name = "COL4";
            COL55.Name = "COL5";
            COL66.Name = "COL6";
            COL77.Name = "COL7";
            COL88.Name = "COL8";

            dgvGridMB.Columns.AddRange(new DataGridViewTextBoxColumn[] {
            COL11, COL22, COL33,COL44,COL55, COL66, COL77,COL88});

        }


        private void btnCerrarRegCuenta_Click(object sender, EventArgs e)
        {

            frm_cuenta.Visible = false;
        }

        private void txtMontoBaseImponible_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                agregaDesglose();
            }
        }


        public void agregaDesglose()
        {
         
            formatogrillaBaseImp();
 
            N_Agencias objCatalogo = new N_Agencias();

            DataTable data = objCatalogo.BuscaGastoCompartido(txtAnioGlosa.Text, txtMesGlosa.Text, Convert.ToDecimal(txtMontoBaseImponible.Text));
            if (data.Rows.Count > 0)
            {
                llenaDataGrid(data);
                
            }
            else
            {
                dgvBaseImponible.DataSource = null;
            }

        }


        private void llenaDataGrid(DataTable data)
        {

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];

                dgvBaseImponible.Rows.Add(dr["CUENTA"],    String.Format("{0:#,##0.00}", dr["IMPORTE"]), dr["DESCRIP"],"S"
                    );
            }

        }

        public void formatogrillaBaseImp()
        {
            dgvBaseImponible.Columns.Clear();
            COL1.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //COL1.Resizable = DataGridViewTriState.False;
            //COL1.ReadOnly = true;
            COL1.Width = 120;
            COL2.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //COL2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            COL2.Width = 80;

           // COL3.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL3.Width = 120;
            COL4.Visible = false;

            //dgvCatalogo.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.Fill;

            dgvBaseImponible.Columns.AddRange(new DataGridViewTextBoxColumn[] {
            COL1, COL2, COL3,COL4});

        }



        private void cbkManual_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkManual.Checked == true) {
                txtMontoBaseImponible.Enabled = true;
                dgvBaseImponible.Columns.Clear();
                txtMontoBaseImponible.Focus();
            }
            if (cbkManual.Checked == false)
            {
                txtMontoBaseImponible.Enabled = false;
                txtMontoBaseImponible.Text = "";
                
                formatogrillaBaseImp();
            }

        }



        private void txtRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar("'") || e.KeyChar == Convert.ToChar(","))
            {
                e.KeyChar = Convert.ToChar(" ");
            }
            if (e.KeyChar == (char)Keys.Enter)
            {

                if (txtCuenta.Text == "" || Convert.ToDecimal(txtDolares.Text) <= 0 && Convert.ToDecimal(txtSoles.Text) <= 0)
                {

                    frm_Alert.confirmacionForm("Le falta ingresar datos");
                }
                else
                {
                    if (rbtDCuenta.Checked == false && rbtHCuenta.Checked == false)
                    {
                        frm_Alert.confirmacionForm("Debe Seleccionar D / H");
                    }
                    else {
                        String DeHa;
                        if (rbtDCuenta.Checked == true)
                        {
                            DeHa = "D";
                        }
                        else
                        {
                            DeHa = "H";
                        }
                        if (txtCuenta.Text != "DESGLOSE")
                        {


                            if (dgvMovi.Rows.Count == 0)
                            {
                                formatoGridPrincipal();
                            }

                            dgvMovi.Rows.Add(dgvMovi.Rows.Count + 1,
                                txtCuenta.Text,
                                txtDescrip.Text,
                                DeHa.Trim(),
                               String.Format("{0:#,##0.00}", txtDolares.Text),
                               String.Format("{0:#,##0.000}", txtTc.Text),
                                String.Format("{0:#,##0.00}", txtSoles.Text),
                                txtRef.Text,
                                txtDocum.Text,
                                lblTipoReg.Text,
                                lblFechaReg.Text,
                                lblNroRuc.Text,
                                lblDocSunat.Text,
                                lblNroDocum.Text,
                                lblTotalRel.Text,
                                "CODREL",
                                "DOC");
                        }
                        else {

                            if (dgvMovi.Rows.Count == 0)
                            {
                                formatoGridPrincipal();
                            }
                            foreach (DataGridViewRow fila in dgvGridMB.Rows)
                            {
                                if (Convert.ToString(fila.Cells[6].Value)== "99" && Convert.ToInt32( fila.Cells[7].Value) == Ndoc)
                                {
                                    if (Convert.ToString(fila.Cells[0].Value).Length > 0)
                                    {
                                        decimal varDolar;
                                        decimal varSol;

                                        if (Variables.tipo_cambio <= 0) {
                                            Variables.tipo_cambio = 1;
                                        }
                                        if (Convert.ToString(fila.Cells[0].Value).Substring(3, 1) == "2")
                                        {
                                            varDolar = Convert.ToDecimal(fila.Cells[1].Value);
                                        }
                                        else {
                                            varDolar = Convert.ToDecimal(fila.Cells[1].Value) / Variables.tipo_cambio;
                                        }

                                        if (Convert.ToString(fila.Cells[0].Value).Substring(3, 1) == "1")
                                        {
                                            varSol = Convert.ToDecimal(fila.Cells[1].Value);
                                        }
                                        else
                                        {
                                            varSol = Convert.ToDecimal(fila.Cells[1].Value) * Convert.ToDecimal(Variables.tipo_cambio) ;
                                        }

                                        dgvMovi.Rows.Add(
                                        dgvMovi.Rows.Count + 1,
                                            Convert.ToString(fila.Cells[0].Value),
                                        Convert.ToString(fila.Cells[2].Value),//agregar formula que agrege el nombre contable
                                        DeHa,
                                        Convert.ToString(varDolar),
                                        Variables.tipo_cambio,
                                        Convert.ToString(varSol),
                                        txtRef.Text,
                                        "2"
                                       
                                       ); ;
                                    }

                                }

                            }


                        }


                        DialogResult resultado = new DialogResult();
                        frm_Information frm = new frm_Information("¿Desea Ingresar otro registro?");
                        resultado = frm.ShowDialog();

                        if (resultado == DialogResult.OK)
                        {
                            inactivaCajasCuenta();
                        }
                        else
                        {
                            MessageBox.Show("no voy a ingresar");
                            frm_cuenta.Visible = false;
                            btnGrabar.Focus();
                        }

                    }
                }

            }

        }



        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMontoBaseImponible_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbtDCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterRadioDH();
        }


        private void rbtHCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterRadioDH();
        }

 

        public void enterRadioDH()
        {

            MessageBox.Show("consulta el tipo de cambio");
        }

        private void txtDolares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtTc.Focus();
            }
        }

        private void txtTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtSoles.Focus();
            }
        }

        private void txtSoles_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtRef.Focus();
            }
        }

        private void txtDocum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDolares.Focus();
            }

        }

        private void dgvBaseImponible_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                frm_BuscaCodCuenta frm = new frm_BuscaCodCuenta();
                frm.ShowDialog();

                int rowEscribir = dgvBaseImponible.Rows.Count - 1;

                dgvBaseImponible.Rows.Add(1);

                dgvBaseImponible.Rows[rowEscribir].Cells[0].Value = Variables.cod_cta;
                dgvBaseImponible.Rows[rowEscribir].Cells[2].Value = Variables.nom_cta;

               
            }
        }


        


    }
}
