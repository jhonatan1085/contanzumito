using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.frm
{
    public partial class frm_Alert : Form
    {
        public frm_Alert(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
           
        }

        private void frm_Alert_Load(object sender, EventArgs e)
        {
            esclarecerform.ShowAsyc(this);
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void confirmacionForm(string mensaje)
        {
            frm_Alert frm = new frm_Alert(mensaje);
            frm.ShowDialog();
           
        }

 
    }
}
