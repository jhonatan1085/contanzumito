using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidades.cache;

namespace CapaPresentacion.frm
{
    public partial class frm_Principal : Form
    {
        public frm_Principal()
        {
            InitializeComponent();
        }

        public void PantallaOk()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void frm_Principal_Load(object sender, EventArgs e)
        {
            PantallaOk();
            lblusuario.Text = LoginCache.codUser;
        }

        private void salir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new DialogResult();
            Form mensaje = new frm_Information("¿SEGURO DESEA SALIR DEL SISTEMA?");
            resultado = mensaje.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        public void SeleccionadoBotones(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            btnDashboard.Textcolor = Color.White;
            btnProductos.Textcolor = Color.White;
            btnComprobantes.Textcolor = Color.White;
            btnCompras.Textcolor = Color.White;
            btnProveedores.Textcolor = Color.White;
            btnTrabajadores.Textcolor = Color.White;
            btnClientes.Textcolor = Color.White;
            btnGanancias.Textcolor = Color.White;

            sender.selected = true;

            if (sender.selected)
            {
                sender.Textcolor = Color.FromArgb(98, 195, 140);
            }

        }

        private void seguirBoton(Bunifu.Framework.UI.BunifuFlatButton sender)
        {
            flecha.Top = sender.Top;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SeleccionadoBotones((Bunifu.Framework.UI.BunifuFlatButton) sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioenWrapper(new frm_Dashboard());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            SeleccionadoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            SeleccionadoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnTrabajadores_Click(object sender, EventArgs e)
        {
            SeleccionadoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            SeleccionadoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            SeleccionadoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioenWrapper(new frm_RegistroComprobantes());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            SeleccionadoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
            AbrirFormularioenWrapper(new frm_Productos());
        }

        private void btnGanancias_Click(object sender, EventArgs e)
        {
            SeleccionadoBotones((Bunifu.Framework.UI.BunifuFlatButton)sender);
            seguirBoton((Bunifu.Framework.UI.BunifuFlatButton)sender);
        }


        private Form formActivado = null;

        private void AbrirFormularioenWrapper(Form formHijo)
        {
            if (formActivado != null)
                formActivado.Close();
            formActivado = formHijo;
            formHijo.TopLevel = false;
            formHijo.Dock = DockStyle.Fill;
            Wrapper.Controls.Add(formHijo);
            formHijo.BringToFront();
            formHijo.Show();

        }

        
    }
}
