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
    public partial class FrmLogin : Form
    {
        ManejadorLogin ml;
        public string Formulario { get; private set; }
        public FrmLogin()
        {
            InitializeComponent();
            ml = new ManejadorLogin();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string r = ml.Validar(txtUsuario, txtClave).ToUpper();
            if (!r.Equals("Error"))
            {
                Formulario = r;
                this.Hide();
                switch (r)
                {
                    case "REFACCIONES":
                        MessageBox.Show("Inicio de sesión, ¡Exitoso!");
                        break; 

                    case "HERRAMIENTAS":
                        MessageBox.Show("Inicio de sesión, ¡Exitoso!");
                        break;

                    case "ADMINISTRADOR":
                        MessageBox.Show("Inicio de sesión, ¡Exitoso!");
                        break;

                    case "REFACCIONES Y HERRAMIENTAS":
                        MessageBox.Show("Inicio de sesión, ¡Exitoso!");
                        break;
                }
            }
        }
        
    }
}
