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
    public partial class frm_Information : Form
    {
        public frm_Information(string mensaje)
        {
            InitializeComponent();
            lblMensaje.Text = mensaje;
        }

        private void frm_Information_Load(object sender, EventArgs e)
        {
            esclarecerform.ShowAsyc(this);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
