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
    public partial class frm_Periodo : Form
    {
        


        DataGridViewTextBoxColumn COL01 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL02 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL03 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL04 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL05 = new DataGridViewTextBoxColumn();
        public frm_Periodo()
        {
            InitializeComponent();
            ListarPeriodo();
        }

        public void ListarPeriodo()
        {
            N_Control objTipoAsiento = new N_Control();
            cmbPeriodo.DataSource = objTipoAsiento.ListarPeriodos();
            cmbPeriodo.DisplayMember = "PERIODO";
            cmbPeriodo.ValueMember = "PERIODO";
        }

        public void ListaPeriodos(string periodo)
        {
            dgvListaPeriodo.Columns.Clear();
            formatoGridPrincipal();

            N_Control objCatalogo = new N_Control();

            DataTable data = objCatalogo.BuscaControlAnio(periodo);
            if (data.Rows.Count > 0)
            {
                llenaDataGrid(data);

            }
            else
            {
                dgvListaPeriodo.DataSource = null;
            }

        }


        private void llenaDataGrid(DataTable data)
        {

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];


                dgvListaPeriodo.Rows.Add(dr["PERIODO"],
                    dr["NOM_MES"],
                    dr["ESTADO"].ToString() == "A" ? "ABIERTO" : "CERRADO",
                    dr["ESTADO"], dr["MES"]);        }

        }

        public void formatoGridPrincipal()
        {
           
           // COL01.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
          //  COL01.Width = 40;
           // COL01.HeaderText = "Item";
            COL01.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL01.Width = 100;
            COL01.HeaderText = "Periodo";
            COL01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            COL02.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL02.Width = 100;
            COL02.HeaderText = "Mes";
            COL03.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL03.Width = 220;
            COL03.HeaderText = "Estado";

            COL04.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL04.Width = 40;
            COL04.HeaderText = "Estado";

            COL05.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL05.Width = 40;
            COL05.HeaderText = "Estado";

             COL04.Visible = false;
             COL05.Visible = false;


            COL01.Name = "COL01";
            COL02.Name = "COL02";
            COL03.Name = "COL03";
            COL04.Name = "COL04";
            COL05.Name = "COL05";

            dgvListaPeriodo.Columns.AddRange(COL01,COL02,COL03,COL04,COL05);

        }

        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListaPeriodos(Convert.ToString(cmbPeriodo.Text));
        }

        private void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Periodo_Load(object sender, EventArgs e)
        {
            ListaPeriodos(Convert.ToString(cmbPeriodo.Text));
        }

        private void dgvListaPeriodo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Variables.w_mes = dgvListaPeriodo.SelectedCells[4].Value.ToString();
            Variables.Estado_Mes = dgvListaPeriodo.SelectedCells[3].Value.ToString();
           Variables.Num_Periodo = dgvListaPeriodo.SelectedCells[0].Value.ToString();
           Variables.Num_mes = Variables.w_mes;
            this.Close();

            /* E_Control objControl = new E_Control();

             objControl.PERIODO = Variables.Num_Periodo;
             objControl.MES = Variables.Num_mes;

             N_TipoCambio objTipoCambio = new N_TipoCambio();

             DataTable data = objTipoCambio.BuscaTipoCambio(objControl);



             if (data.Rows.Count > 0)
             {

                 DataRow row = data.Rows[0];


                 //public frm_Master  frmmaster =  new  frm_Master;
      //  pasado(row["COMPR_CAMBIO"].ToString());

               // frmmaster.txtCSBS.Text = ;

             }
             else
             {
                 MessageBox.Show("NO EXITEN DATOS");
             }*/




        }


    }
}
