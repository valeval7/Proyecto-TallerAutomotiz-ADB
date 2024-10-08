﻿using System;
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
    public partial class FrmAgregarUsuarios : Form
    {
        ManejadorUsuarios mu;
        public FrmAgregarUsuarios()
        {
            InitializeComponent();
            mu = new ManejadorUsuarios();
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
                txtClave.Text = FrmUsuarios.Clave;
                FrmUsuarios.Id = 0;
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FrmUsuarios.Id > 0)
            {
                mu.Modificar(FrmUsuarios.Id,txtNombre, txtApellidoP, txtApellidoM, dtpFecha, txtRFC,
                txtUser, cmbNivel, cmbFormulario, txtClave);
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
                txtUser, cmbNivel, cmbFormulario, txtClave));
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
    }
}
