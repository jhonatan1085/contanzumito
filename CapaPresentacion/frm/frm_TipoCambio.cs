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
using CapaEntidades.cache;
using System.Net.Http;
using System.Net.Http.Headers;

using Newtonsoft.Json;

using System.Net.Http.Formatting;

namespace CapaPresentacion.frm
{
    public partial class frm_TipoCambio : Form
    {

      

        private bool editnew = false; //false agregar - true editar
        public frm_TipoCambio()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            buscacambio();

        }


        public void buscacambio() {

            DateTime inicio = monthCalendar1.SelectionStart;

           

            string agrega = inicio.ToString().Substring(0, 10);

            //MessageBox.Show( agrega.PadLeft(10,'0'));

            E_TipoCambio EtipoCambio = new E_TipoCambio();
            EtipoCambio.FEC_CAMBIO = inicio;

            N_TipoCambio objTipoCambio = new N_TipoCambio();

            DataTable data = objTipoCambio.BuscaTipoCambioFecha(EtipoCambio);



            if (data.Rows.Count > 0)
            {

                DataRow row = data.Rows[0];

                txtCSBS.Text = row["COMPR_CAMBIO"].ToString();
                txtVSBS.Text = row["VENTA_CAMBIO"].ToString();
                txtPSBS.Text = row["PROMEDIO_CAMBIO"].ToString();
                txtCSunat.Text = row["SUNAT_COMPRA"].ToString();
                txtVSunat.Text = row["SUNAT_VENTA"].ToString();
                txtPSunat.Text = row["SUNAT_PROMEDIO"].ToString();


                btnEditar.Enabled = true;
                btnEditar.Visible = true;

                btnCancelar.Enabled = false;
                btnCancelar.Visible = false;

                btnAgregar.Enabled = false;
                btnAgregar.Visible = false;

                btnGrabar.Enabled = false;
                btnGrabar.Visible = false;

                btnSunat.Visible = false;
                btnSunat.Enabled = false;

            }
            else
            {

              //  MessageBox.Show(inicio.ToString("yyyy-MM-dd").ToString());

               

                txtCSBS.Text = "0.000";
                txtVSBS.Text = "0.000";
                txtPSBS.Text = "0.000";
                txtCSunat.Text = "0.000";
                txtVSunat.Text = "0.000";
                txtPSunat.Text = "0.000";


                btnEditar.Enabled = false;
                btnEditar.Visible = false;

                btnCancelar.Enabled = false;
                btnCancelar.Visible = false;

                btnAgregar.Enabled = true;
                btnAgregar.Visible = true;

                btnGrabar.Enabled = false;
                btnGrabar.Visible = false;

                btnSunat.Visible = false;
                btnSunat.Enabled = false;

            }

            txtCSBS.Enabled = false;
            txtVSBS.Enabled = false;
            txtPSBS.Enabled = false;
            txtCSunat.Enabled = false;
            txtVSunat.Enabled = false;
            txtPSunat.Enabled = false;

            monthCalendar1.Enabled = true;

        }

        private void frm_TipoCambio_Load(object sender, EventArgs e)
        {
            /*monthCalendar1.BoldedDates = new DateTime[] {
            new DateTime(2022,5,10),
             new DateTime(2022,5,15),
             DateTime.Today.AddDays(5)
            };*/

            //api();

           // buscacambio();

        }

        private void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            editnew = false;


            btnEditar.Enabled = false;
            btnEditar.Visible = false;

            btnCancelar.Enabled = true;
            btnCancelar.Visible = true;

            btnAgregar.Enabled = false;
            btnAgregar.Visible = false;

            btnGrabar.Enabled = true;
            btnGrabar.Visible = true;


            txtCSBS.Enabled = true;
            txtVSBS.Enabled = true;
            txtPSBS.Enabled = true;
            txtCSunat.Enabled = true;
            txtVSunat.Enabled = true;
            txtPSunat.Enabled = true;

            monthCalendar1.Enabled = false;

            btnSunat.Visible = true;
            btnSunat.Enabled = true;


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            buscacambio();
            editnew = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            editnew = true;

            btnEditar.Enabled = false;
            btnEditar.Visible = false;

            btnCancelar.Enabled = true;
            btnCancelar.Visible = true;

            btnAgregar.Enabled = false;
            btnAgregar.Visible = false;

            btnGrabar.Enabled = true;
            btnGrabar.Visible = true;


            txtCSBS.Enabled = true;
            txtVSBS.Enabled = true;
            txtPSBS.Enabled = true;
            txtCSunat.Enabled = true;
            txtVSunat.Enabled = true;
            txtPSunat.Enabled = true;

            monthCalendar1.Enabled = false;

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            if (editnew == false)
            { 

                try
                {
                    E_TipoCambio objEnTipocambio = new E_TipoCambio();

                    DateTime inicio = monthCalendar1.SelectionStart;

             
                    objEnTipocambio.FEC_CAMBIO = inicio;
                    objEnTipocambio.COMPR_CAMBIO = Convert.ToDecimal(txtCSBS.Text);
                    objEnTipocambio.VENTA_CAMBIO = Convert.ToDecimal(txtVSBS.Text);
                    objEnTipocambio.PROMEDIO_CAMBIO = Convert.ToDecimal(txtPSBS.Text);

                    objEnTipocambio.COD_USER = LoginCache.codUser;
                    objEnTipocambio.SUNAT_COMPRA = Convert.ToDecimal(txtCSunat.Text);
                    objEnTipocambio.SUNAT_VENTA = Convert.ToDecimal(txtVSunat.Text);
                    objEnTipocambio.SUNAT_PROMEDIO = Convert.ToDecimal(txtPSunat.Text);


                    N_TipoCambio objTipoCambio = new N_TipoCambio();

                    objTipoCambio.InsertandoTipoCambio(objEnTipocambio);

                    buscacambio();
                }
                catch
                {
                    MessageBox.Show("no se pudo grabar el registro");
                }

            }

            if (editnew == true)
            {

                try
                {
                    E_TipoCambio objEnTipocambio = new E_TipoCambio();

                    DateTime inicio = monthCalendar1.SelectionStart;


                    objEnTipocambio.FEC_CAMBIO = inicio;
                    objEnTipocambio.COMPR_CAMBIO = Convert.ToDecimal(txtCSBS.Text);
                    objEnTipocambio.VENTA_CAMBIO = Convert.ToDecimal(txtVSBS.Text);
                    objEnTipocambio.PROMEDIO_CAMBIO = Convert.ToDecimal(txtPSBS.Text);

                    objEnTipocambio.COD_USER = LoginCache.codUser;
                    objEnTipocambio.SUNAT_COMPRA = Convert.ToDecimal(txtCSunat.Text);
                    objEnTipocambio.SUNAT_VENTA = Convert.ToDecimal(txtVSunat.Text);
                    objEnTipocambio.SUNAT_PROMEDIO = Convert.ToDecimal(txtPSunat.Text);


                    N_TipoCambio objTipoCambio = new N_TipoCambio();

                    objTipoCambio.EditarTipoCambio(objEnTipocambio);

                    buscacambio();
                }
                catch
                {
                    MessageBox.Show("no se pudo grabar el registro");
                }

            }

        }


        public void api(string fecha)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.apis.net.pe/v1/tipo-cambio-sunat");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
            string urlParameters = "?fecha=" + fecha;

            var response =  client.GetStringAsync(urlParameters).Result;

          
        
                // MessageBox.Show();

                E_TipoCambioApi dataobjet = new E_TipoCambioApi();

  

                dataobjet =  JsonConvert.DeserializeObject<E_TipoCambioApi>(response);

            

                txtCSunat.Text = dataobjet.Compra.ToString();
                txtVSunat.Text = dataobjet.Venta.ToString();
          

            

            


        }

        private void btnSunat_Click(object sender, EventArgs e)
        {
            DateTime inicio = monthCalendar1.SelectionStart;
            api(inicio.ToString("yyyy-MM-dd").ToString());
        }
    }
}
