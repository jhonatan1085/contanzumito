using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion.frm
{
    public partial class frm_Login : Form
    {

        E_UsuarioAcceso objEntidad = new E_UsuarioAcceso();
        N_UsuarioAcceso objNegocio = new N_UsuarioAcceso();
        public frm_Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario") {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void frm_Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "Usuario")
            {
                if (txtPassword.Text != "Password")
                {
                    objEntidad.Usuario = txtUsuario.Text.Trim();
                    objEntidad.Password = txtPassword.Text.Trim();

                    var validLogin = objNegocio.Loguea(objEntidad);

                    //MessageBox.Show(Convert.ToString(validLogin));
                    if (validLogin == true)
                    {
                        frm_Master  mainmenu = new frm_Master(txtUsuario.Text.Trim());
                        mainmenu.Show();
                        this.Hide();
                    }
                    else {
                        msgError("Usuario y/o Password Incorrecto");
                    }
                }
                else {
                    msgError("Ingrese contraseña");
                }
            }
            else {
                msgError("Ingrese Usuario");
            }


            

        }

        private void msgError(string msg) 
        {
            lblError.Text = "       " + msg;
            lblError.Visible = true;
        }
    }
}
