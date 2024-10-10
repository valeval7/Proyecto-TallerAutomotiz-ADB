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
        public FrmMenu()
        {
            InitializeComponent();
            groupBox1.Visible = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public void btnRefacciones_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            FrmLogin LOG = new FrmLogin();
            

            LOG.ShowDialog();
            if (LOG.Formulario.Equals("Refacciones") || LOG.Formulario.Equals("Refacciones y Herramientas") || LOG.Formulario.Equals("Administrador"))
            {
                FrmRefacciones a = new FrmRefacciones();
                a.Show();
            }
            else
            {
                MessageBox.Show("ERROR.Usted solo está ASIGNADO a los formularios: \n" + LOG.Formulario);
                LOG.Close();
                this.Show();
            }
        }

        public void btnHerramientas_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            FrmLogin LOG = new FrmLogin();
            LOG.ShowDialog();
            if (LOG.Formulario.Equals("Herramientas") || LOG.Formulario.Equals("Refacciones y Herramientas") || LOG.Formulario.Equals("Administrador"))
            {
                FrmHerramientas a = new FrmHerramientas();
                a.Show();
                LOG.Close();
            }
            else
            {
                MessageBox.Show("ERROR.Usted solo está ASIGNADO a los formularios: \n" + LOG.Formulario);
                LOG.Close();
                this.Show();

            }
        }

        private void btnAdministrar_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            FrmLogin LOG = new FrmLogin();
            LOG.ShowDialog();

            if (LOG.Formulario.Equals("Administrador"))
            {
                FrmUsuarios a = new FrmUsuarios();
                a.Show();
            }
            else 
            {
                MessageBox.Show("ERROR.Usted solo está ASIGNADO a los formularios: \n" + LOG.Formulario);
                LOG.Close();
                this.Show();
            }
        }
    }
}
