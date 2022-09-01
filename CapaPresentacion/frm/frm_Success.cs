using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frm_Success : Form
    {
        public frm_Success(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
        }

        private void frm_Success_Load(object sender, EventArgs e)
        {
            esclarecerform.ShowAsyc(this);
        }

        public static void confirmacionForm(string mensaje)
        {
            frm_Success frm = new frm_Success(mensaje);
            frm.ShowDialog();

        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
    }
}
