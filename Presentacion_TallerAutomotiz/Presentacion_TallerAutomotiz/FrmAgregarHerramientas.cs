using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejador;

namespace Presentacion_TallerAutomotiz
{
    public partial class FrmAgregarHerramientas : Form
    {
        ManejadorHerramientas mh;
        public FrmAgregarHerramientas()
        {
            InitializeComponent();
            mh = new ManejadorHerramientas();
            if (FrmHerramientas.idh >0 )
            {
                txtCodigoHerramienta.Text = FrmHerramientas.CodigoHerramienta;
                txtNombre.Text = FrmHerramientas.Nombre;
                txtMarca.Text = FrmHerramientas.Marca;
                txtDescripcion.Text = FrmHerramientas.descripcion;
                FrmHerramientas.idh = 0;
            }
        }

        private void FrmAgregarHerramientas_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FrmHerramientas.idh >0 )
            {
                mh.Modificar(FrmHerramientas.idh, txtCodigoHerramienta, txtNombre, txtMedida, cmbMedidas, txtMarca, txtDescripcion);
                FrmHerramientas.idh = 0;
                txtCodigoHerramienta.Clear();
                txtNombre.Clear();
                txtMarca.Clear();
                txtMedida.Clear();
                txtDescripcion.Clear(); 
            }
            else
            MessageBox.Show(mh.GuardarHerramientas(txtCodigoHerramienta, txtNombre, txtMedida, cmbMedidas, txtMarca, txtDescripcion));
            txtCodigoHerramienta.Clear();
            txtNombre.Clear();
            txtMarca.Clear();
            txtMedida.Clear();
            txtDescripcion.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtMedida_Click(object sender, EventArgs e)
        {
            txtMedida.Clear();
        }
    }
    }
