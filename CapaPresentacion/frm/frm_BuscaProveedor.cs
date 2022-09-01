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
using CapaNegocio;

namespace CapaPresentacion.frm
{
    public partial class frm_BuscaProveedor : Form
    {

        DataGridViewTextBoxColumn COL01 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL02 = new DataGridViewTextBoxColumn();
        DataGridViewTextBoxColumn COL03 = new DataGridViewTextBoxColumn();

        public frm_BuscaProveedor()
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

        public void mostrarbuscarTabla(string busqueda)
        {


            dgvProveedores.Columns.Clear();
            formatoGridPrincipal();

          
            N_ProveedorFinanciero objNProv = new N_ProveedorFinanciero();
            

           

            DataTable data = objNProv.BuscaProveedor(busqueda, "T");
            if (data.Rows.Count > 0)
            {
                llenaDataGrid(data);
                // accionesTabla();
            }
            else
            {
                dgvProveedores.DataSource = null;
            }

        }

        private void llenaDataGrid(DataTable data)
        {


            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];

                dgvProveedores.Rows.Add(dr["NRO_RUC"], dr["RAZON_SOCIAL"],dr["COD_CTA"]
                    );
            }


        }

        public void formatoGridPrincipal()
        {


            COL01.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL01.Width = 100;
            COL01.HeaderText = "RUC";
            COL01.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            COL02.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL02.Width = 300;
            COL02.HeaderText = "Razon Social";
            COL02.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            COL03.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            COL03.Width = 120;
            COL03.HeaderText = "COD CTA.";
            COL03.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



            COL01.Name = "COL01";
            COL02.Name = "COL02";
            COL03.Name = "COL03";
           

            dgvProveedores.Columns.AddRange(COL01, COL02, COL03);

        }

        private void dgvProveedores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionaDatos(dgvProveedores.SelectedCells[0].Value.ToString(), dgvProveedores.SelectedCells[1].Value.ToString());

        }

        public void seleccionaDatos(String dato1, String dato2)
        {

            Variables.Ruc = dato1;
            Variables.Razon_Social = dato2;
            

            this.Hide();

        }

        private void dgvProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            seleccionaDatos(dgvProveedores.SelectedCells[0].Value.ToString(), dgvProveedores.SelectedCells[1].Value.ToString());

        }
    }
}
