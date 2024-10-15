using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejador;

namespace Presentacion_TallerAutomotiz
{
    public partial class FrmMenu : Form
    {
        FrmLogin LOG;
        string Formulario = "";
        Form Activo = null;

        public FrmMenu()
        {
            InitializeComponent();
            groupBox1.Visible = true;
            LOG = new FrmLogin();
            Formulario = ManejadorLogin.Formulario;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CerrarFormulario()
        {
            if (Activo != null)
            {
               Activo.Close();
            }
        }

        public void btnRefacciones_Click(object sender, EventArgs e)
        {
            CerrarFormulario();
            groupBox1.Visible = false;
            
            if (Formulario.Equals("Refacciones") || Formulario.Equals("Refacciones y Herramientas") || Formulario.Equals("Administrador"))
            {
                FrmRefacciones a = new FrmRefacciones();
                a.Show();
                Activo = a;

            }
            else
            {
                MessageBox.Show("ERROR. Usted solo está ASIGNADO a los formularios: \n" + Formulario);
                this.Show();
            }
           
        }

        public void btnHerramientas_Click(object sender, EventArgs e)
        {
            CerrarFormulario();
            groupBox1.Visible = false;
            FrmHerramientas b = new FrmHerramientas();
            if (Formulario.Equals("Herramientas") || Formulario.Equals("Refacciones y Herramientas") || Formulario.Equals("Administrador"))
            {
                b.Show();
                Activo = b;
            }

            else
            {
                MessageBox.Show("ERROR. Usted solo está ASIGNADO a los formularios: \n" + Formulario);
                this.Show();
            }
           
        }



        private void btnAdministrar_Click(object sender, EventArgs e)
        {
            CerrarFormulario();
            groupBox1.Visible = false;
            FrmUsuarios c = new FrmUsuarios();
            if (Formulario.Equals("Administrador"))
            {
                c.Show();
                Activo = c;
                
            }
            else
            {
                MessageBox.Show("ERROR. Usted solo está ASIGNADO a los formularios: \n" + Formulario);
                this.Show();
            }
        }
    }
}
