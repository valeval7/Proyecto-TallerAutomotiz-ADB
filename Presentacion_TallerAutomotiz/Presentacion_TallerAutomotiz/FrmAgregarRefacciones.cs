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
    public partial class FrmAgregarRefacciones : Form
    {
        ManejadorRefacciones mr;
        public FrmAgregarRefacciones()
        {
            InitializeComponent();
            mr = new ManejadorRefacciones();
            if (FrmRefacciones.idR > 0)
            {
                txtCodigoBarra.Text = FrmRefacciones.CodigoBarras;
                txtNombre.Text = FrmRefacciones.Nombre;
                txtDescripcion.Text = FrmRefacciones.Descripcion;
                txtMarca.Text = FrmRefacciones.Marca;
                FrmRefacciones.idR = 0;
            }
        }

        private void FrmAgregarRefacciones_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FrmRefacciones.idR > 0)
            {
                mr.Modificar(FrmRefacciones.idR, txtCodigoBarra, txtNombre, txtDescripcion, txtMarca);
                FrmRefacciones.idR = 0;
                txtCodigoBarra.Clear();
                txtNombre.Clear();
                txtDescripcion.Clear();
                txtMarca.Clear();
            }
            else
                MessageBox.Show(mr.GuardarRefacciones(txtCodigoBarra, txtNombre, txtDescripcion, txtMarca));
            txtCodigoBarra.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    }
