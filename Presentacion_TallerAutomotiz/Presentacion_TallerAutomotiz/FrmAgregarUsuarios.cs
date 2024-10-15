using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Manejador;

namespace Presentacion_TallerAutomotiz
{
    public partial class FrmAgregarUsuarios : Form
    {
        ManejadorUsuarios mu;
        public FrmAgregarUsuarios()
        {
            InitializeComponent();
            mu = new ManejadorUsuarios();
            if (cmbFormulario.Equals("Refacciones") || cmbFormulario.Equals("Herramientas") || cmbFormulario.Equals("Administrador"))
            {
                cmbNivel.Visible = true;
                label9.Visible = true;
                groupBox3.Visible = false;
            }
            else if (cmbFormulario.Equals("Refacciones y Herramientas"))
            {
                cmbNivel.Visible = false;
                label9.Visible = false;
                groupBox3.Visible = true;
            }

            if (FrmUsuarios.Id > 0)
            {
                txtNombre.Text = FrmUsuarios.Nombre;
                txtApellidoP.Text = FrmUsuarios.ApellidoP;
                txtApellidoM.Text = FrmUsuarios.ApellidoM;
                dtpFecha.Text = FrmUsuarios.Nacimiento.ToShortDateString();
                txtRFC.Text = FrmUsuarios.RFC;
                txtUser.Text = FrmUsuarios.NickName;
                cmbNivel.Text = FrmUsuarios.Tipo;
                cmbFormulario.Text = FrmUsuarios.Formulario;
                cmbNivelR.Text = FrmUsuarios.Tipo;
                cmbNivelH.Text = FrmUsuarios.Tipo;
                txtClave.Text = FrmUsuarios.Clave;
            }

            cmbNivel.Visible = false;
            label9.Visible = false;
            groupBox3.Visible = false;
            cmbFormulario.SelectionChangeCommitted += new EventHandler(cmbFormulario_SelectedIndexChanged);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FrmUsuarios.Id > 0)
            {
                mu.Modificar(FrmUsuarios.Id,txtNombre, txtApellidoP, txtApellidoM, dtpFecha, txtRFC,
                txtUser, cmbNivel, cmbFormulario, cmbNivelR, cmbNivelH,txtClave);
                FrmUsuarios.Id = 0;
                txtNombre.Clear();
                txtApellidoP.Clear();
                txtApellidoM.Clear();
                txtRFC.Clear();
                txtUser.Clear();
                txtClave.Clear();
            }
            else
            MessageBox.Show(mu.GuardarUser(txtNombre, txtApellidoP, txtApellidoM, dtpFecha, txtRFC,
                txtUser, cmbNivel, cmbFormulario, cmbNivelR, cmbNivelH, txtClave));
            txtNombre.Clear();
            txtApellidoP.Clear();
            txtApellidoM.Clear();
            txtRFC.Clear();
            txtUser.Clear();
            txtClave.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtApellidoP_Click(object sender, EventArgs e)
        {
            txtApellidoP.Clear();
            txtApellidoP.ForeColor = Color.Black;
        }

        private void txtApellidoM_Click(object sender, EventArgs e)
        {
            txtApellidoM.Clear();
            txtApellidoM.ForeColor = Color.Black;
        }

        private void cmbFormulario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cmbFormulario.Text;

            if (selectedValue == "Refacciones" || selectedValue == "Herramientas" || selectedValue == "Administrador")
            {
                cmbNivel.Visible = true;
                label9.Visible = true;
                groupBox3.Visible = false;
            }
            else if (selectedValue == "Refacciones y Herramientas")
            {
                cmbNivel.Visible = false;
                label9.Visible = false;
                groupBox3.Visible = true;
            }
            else
            {
                cmbNivel.Visible = false;
                label9.Visible = false;
                groupBox3.Visible = false;
            }
        }
    }
}
