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
    public partial class FrmHerramientas : Form
    {
        ManejadorHerramientas MK;
        int fila = 0, columna = 0;
        public static int idh = 0;
        public static string CodigoHerramienta = "", Nombre = "", Medida="", Medidas="", Marca="", descripcion="";


        private void btnEliminar_Click(object sender, EventArgs e)
        {
           idh = int.Parse(dtgvAdministrador.Rows[fila].Cells[0].Value.ToString());
            MK.Eliminar(idh, dtgvAdministrador.Rows[fila].Cells[1].Value.ToString());
            Limpiar();
            txtBuscar.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtgvAdministrador_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dtgvAdministrador.Visible = true;
            MK.MostrarHerramientas(dtgvAdministrador, txtBuscar.Text);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (fila >= 0)
            {
                idh = int.Parse(dtgvAdministrador.Rows[fila].Cells[0].Value.ToString());
                CodigoHerramienta = dtgvAdministrador.Rows[fila].Cells[1].Value.ToString();
                Nombre = dtgvAdministrador.Rows[fila].Cells[2].Value.ToString();
                Medida = dtgvAdministrador.Rows[fila].Cells[3].Value.ToString();
                Marca = dtgvAdministrador.Rows[fila].Cells[4].Value.ToString();
                descripcion = dtgvAdministrador.Rows[fila].Cells[5].Value.ToString();
                FrmAgregarHerramientas dm = new FrmAgregarHerramientas();
                dm.ShowDialog();
                Limpiar();
                txtBuscar.Focus();
            }
            else
                MessageBox.Show("Por favor, seleccione una fila válida para modificar.");
        }
        void Limpiar()
        {
            dtgvAdministrador.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            idh = 0;  CodigoHerramienta = ""; Nombre = ""; Medida = ""; Medidas = ""; Marca = "";  descripcion = "";
            FrmAgregarHerramientas dm = new FrmAgregarHerramientas();
            dm.ShowDialog();
            txtBuscar.Focus();
        }

        public FrmHerramientas()
        {
            InitializeComponent();
            MK= new ManejadorHerramientas();
            string Tipo = ManejadorLogin.Tipo;
            if (Tipo.Equals("Nivel 1"))
            {
                btnAgregar.Visible = true;
                btnEliminar.Visible = true;
                btnModificar.Visible = true;
            }
            else if (Tipo.Equals("Nivel 2"))
            {
                btnAgregar.Visible = true;
                btnEliminar.Visible = false;
                lblEliminar.Visible = false;
                btnModificar.Visible = false;
                lblModificar.Visible = false;
            }
        }

        private void FrmHerramientas_Load(object sender, EventArgs e)
        {

        }
    }
}
