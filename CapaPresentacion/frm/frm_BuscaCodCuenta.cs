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
    
    public partial class frm_BuscaCodCuenta : Form
    {
        E_Catalogo objEntidad = new E_Catalogo();

        N_Catalogo objNegocioCat = new N_Catalogo();
        // public DataGridViewTextBoxColumn COL1 = new DataGridViewTextBoxColumn();
        // public DataGridViewTextBoxColumn COL2 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL1 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL2 = new DataGridViewTextBoxColumn();

        DataGridViewTextBoxColumn COL01 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL02 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL03 = new DataGridViewTextBoxColumn();

        public frm_BuscaCodCuenta()
        {
            InitializeComponent();
            
        }

        private void btnCerrarFormulario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                mostrarbuscarTabla(txtBuscar.Text);
            }
            
        }

        public void mostrarbuscarTabla(string buscar)
        {

           
            dgvCatalogo.Columns.Clear();
            formatoGridPrincipal();
            // dgvCatalogo.Columns.AddRange(new DataGridViewTextBoxColumn(), new DataGridViewTextBoxColumn());

            N_Catalogo objCatalogo = new N_Catalogo();

           DataTable data =  objCatalogo.BuscandoCatalogo(buscar, "T");
            if (data.Rows.Count > 0)
            {
                llenaDataGrid(data);

               // accionesTabla();
            }
            else
            {
                dgvCatalogo.DataSource = null;
            }

        }


        private void llenaDataGrid(DataTable data) {



           
            for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow dr = data.Rows[i];

                    dgvCatalogo.Rows.Add(dr["COD_CTA"], dr["NOM_CTA"], dr["nrocta"]
                        );
                }

            
        }



        private void frm_BuscaCodCuenta_Load(object sender, EventArgs e)
        {
            formatoGridPrincipal();
        }



        public void formatoGridPrincipal()
        {


            COL01.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL01.Width = 130;
            COL01.HeaderText = "Cuenta";
            COL01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            COL02.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL02.Width = 400;
            COL02.HeaderText = "Descripción";
            COL02.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            COL03.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL03.Width = 100;
            COL03.HeaderText = "nro.";
            COL03.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            COL03.Visible = false;


            COL01.Name = "COL01";
            COL02.Name = "COL02";
            COL03.Name = "COL03";


            dgvCatalogo.Columns.AddRange(COL01, COL02, COL03);

        }



        public void seleccionaDatos(String dato1, String dato2, String dato3) {

            Variables.nroctacte = Convert.ToInt32(dato3);
            Variables.cod_cta = dato1;
            Variables.nom_cta = dato2;


           /* objEntidad.COD_CTA = dato1;
            objEntidad.NOM_CTA = dato2;

            objNegocioCat.seleccionaCuenta(objEntidad);*/

            this.Hide();

        }

        private void dgvCatalogo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionaDatos(dgvCatalogo.SelectedCells[0].Value.ToString(), dgvCatalogo.SelectedCells[1].Value.ToString(), dgvCatalogo.SelectedCells[2].Value.ToString());

        }

        private void dgvCatalogo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                seleccionaDatos(dgvCatalogo.SelectedCells[0].Value.ToString(), dgvCatalogo.SelectedCells[1].Value.ToString(), dgvCatalogo.SelectedCells[2].Value.ToString());
            }
        }
    }
}
