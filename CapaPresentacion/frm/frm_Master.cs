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
using System.IO;
using System.Reflection;

namespace CapaPresentacion.frm
{
    public partial class frm_Master : Form
    {

        private string cod_usuario;

        
        public frm_Master( string cod_user = "")
        {
            
            InitializeComponent();
            cod_usuario = cod_user;
            

        }

        private void frm_Master_Load(object sender, EventArgs e)
        {

            N_UsuarioAcceso obj_Acceso = new N_UsuarioAcceso();

            List<E_Menu> permisos_esperados = obj_Acceso.ObtenerPermisos(cod_usuario);

            MenuStrip miMenu = new MenuStrip();

            foreach (E_Menu objMenu in permisos_esperados) {

                ToolStripMenuItem menuPadre = new ToolStripMenuItem(objMenu.NOMBRE);
                menuPadre.TextImageRelation = TextImageRelation.ImageAboveText;
                string rutaimagen = Path.GetFullPath(Path.Combine(Application.StartupPath,@"../../") + objMenu.ICONO);

                menuPadre.Image = new Bitmap(rutaimagen);
                menuPadre.ImageScaling = ToolStripItemImageScaling.None;

                foreach (E_SubMenu objSubMenu  in objMenu.LISTASUBMENU) {

                    ToolStripMenuItem menuHijo = new ToolStripMenuItem(objSubMenu.NOMBRE,null,click_menu,objSubMenu.NOMBREFORMULARIO);
                    menuPadre.DropDownItems.Add(menuHijo);
                }


                miMenu.Items.Add(menuPadre);

            };

            this.MainMenuStrip = miMenu;
            Controls.Add(miMenu);



            frm_Periodo frm = new frm_Periodo();
            frm.ShowDialog();
        }

        private void click_menu(object sender, System.EventArgs e) {

            ToolStripMenuItem menuSeleccionado = (ToolStripMenuItem)sender;

            Assembly asm = Assembly.GetEntryAssembly();
            AssemblyName asmName = asm.GetName();

           // MessageBox.Show(asmName.Name + " - " +asm.FullName);


            Type elemento = asm.GetType(asm.GetName().Name + ".frm." + menuSeleccionado.Name);

           // Type elemento = asm.GetType("CapaPresentacion./.frm_RegistroComprobantes");


            if (elemento == null)
            {
                MessageBox.Show("Formulario no encontrado");
            }
            else {
                Form FormularioCreado = (Form)Activator.CreateInstance(elemento);

                int encontrado = this.MdiChildren.Where(x => x.Name == FormularioCreado.Name).ToList().Count();

                if (encontrado != 0)
                {
                    ((Form)(this.MdiChildren.Where(x => x.Name == FormularioCreado.Name).FirstOrDefault())).WindowState = FormWindowState.Normal ;
                    ((Form)(this.MdiChildren.Where(x => x.Name == FormularioCreado.Name).FirstOrDefault())).Activate();
                }
                else {
                    FormularioCreado.MdiParent = this;
                    FormularioCreado.Show();
                }

            }

            
        }


        }
    }

