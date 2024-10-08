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
            while (true)  
            {
                LOG.ShowDialog();
                if (LOG.Formulario.Equals("REFACCIONES") || LOG.Formulario.Equals("REFACCIONES Y HERRAMIENTAS") || LOG.Formulario.Equals("ADMINISTRADOR"))
                {
                    FrmRefacciones a = new FrmRefacciones();
                    a.Show();
                    break; 
                }
                else
                {
                    MessageBox.Show("Incorrecto, inténtelo de nuevo.");
                }
            }
        }

        public void btnHerramientas_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            FrmLogin LOG = new FrmLogin();
            while (true)
            {
                LOG.ShowDialog();
                if (LOG.Formulario.Equals("HERRAMIENTAS") || LOG.Formulario.Equals("REFACCIONES Y HERRAMIENTAS") || LOG.Formulario.Equals("ADMINISTRADOR"))
                {
                    FrmHerramientas a = new FrmHerramientas();
                    a.Show();
                    break;
                }
                else
                {
                    MessageBox.Show("Incorrecto, inténtelo de nuevo.");
                }
            }   
        }

        private void btnAdministrar_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            FrmLogin LOG = new FrmLogin();
            while (true)
            {
                LOG.ShowDialog();
                if (LOG.Formulario.Equals("ADMINISTRADOR"))
                {
                    FrmUsuarios a = new FrmUsuarios();
                    a.Show();
                    break;
                }
                else
                {
                    MessageBox.Show("Incorrecto, inténtelo de nuevo.");
                }
            }
        }
    }
}
