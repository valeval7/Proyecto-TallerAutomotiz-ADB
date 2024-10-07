using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void btnRefacciones_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            FrmLogin LOG = new FrmLogin();
            LOG.MdiParent = this;
            LOG.Show();

        }

        private void btnHerramientas_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            FrmLogin LOG = new FrmLogin();
            LOG.MdiParent = this;
            LOG.Show();
        }

        private void btnAdministrar_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            FrmLogin LOG = new FrmLogin();
            LOG.MdiParent = this;
            LOG.Show();
        }
    }
}
