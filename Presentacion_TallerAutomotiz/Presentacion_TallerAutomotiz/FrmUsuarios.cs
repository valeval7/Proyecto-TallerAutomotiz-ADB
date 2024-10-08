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
    public partial class FrmUsuarios : Form
    {
        ManejadorUsuarios MM;
        int fila = 0, columna = 0;
        public static int Id = 0;
        public static string Nombre = "", ApellidoP = "", ApellidoM = "", RFC="", NickName = "", Tipo = "", Formulario="", Clave = "";

        public static DateTime Nacimiento = new DateTime();


        public FrmUsuarios()
        {
            InitializeComponent();
            MM = new ManejadorUsuarios();
            string Tipo = ManejadorLogin.Tipo;
            if(Tipo.Equals("Nivel 1"))
            {
                btnAgregar.Visible = true;
                btnEliminar.Visible = true;
                btnModificar.Visible = true;
            }
            else if(Tipo.Equals("Nivel 2"))
            {
                btnAgregar.Visible = true;
                btnEliminar.Visible = false;
                lblEliminar.Visible = false;
                btnModificar.Visible = false;
                lblModificar.Visible = false;
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void dtgvAdministrador_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Id = 0; Nombre = "";  ApellidoP = ""; ApellidoM = "";  Nacimiento = DateTime.Now; RFC = ""; NickName = ""; Tipo = ""; Formulario = ""; Clave = "";
            FrmAgregarUsuarios dm = new FrmAgregarUsuarios();
            dm.ShowDialog();
            txtBuscar.Focus();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (fila >= 0)
            {
                Id = int.Parse(dtgvAdministrador.Rows[fila].Cells[0].Value.ToString());
                Nombre = dtgvAdministrador.Rows[fila].Cells[1].Value.ToString();
                ApellidoP = dtgvAdministrador.Rows[fila].Cells[2].Value.ToString();
                ApellidoM = dtgvAdministrador.Rows[fila].Cells[3].Value.ToString();
                Nacimiento = DateTime.Parse(dtgvAdministrador.Rows[fila].Cells[4].Value.ToString());
                RFC = dtgvAdministrador.Rows[fila].Cells[5].Value.ToString();
                NickName = dtgvAdministrador.Rows[fila].Cells[6].Value.ToString();
                Tipo = dtgvAdministrador.Rows[fila].Cells[7].Value.ToString();
                Formulario = dtgvAdministrador.Rows[fila].Cells[8].Value.ToString();
                Clave = dtgvAdministrador.Rows[fila].Cells[9].Value.ToString();
                FrmAgregarUsuarios dm = new FrmAgregarUsuarios();
                dm.ShowDialog();
                Limpiar();
                txtBuscar.Focus();
            }
            else
                MessageBox.Show("Por favor, seleccione una fila válida para modificar.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Id = int.Parse(dtgvAdministrador.Rows[fila].Cells[0].Value.ToString());
            MM.Eliminar(Id, dtgvAdministrador.Rows[fila].Cells[1].Value.ToString());
            Limpiar();
            txtBuscar.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dtgvAdministrador.Visible = true;
            MM.MostrarAdministrador(dtgvAdministrador, txtBuscar.Text);
        }

        void Limpiar()
        {
            dtgvAdministrador.Visible = false;
        }
    }
}
