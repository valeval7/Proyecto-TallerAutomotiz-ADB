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
        public string Formulario = "";
        public FrmLogin()
        {
            InitializeComponent();
            ml = new ManejadorLogin();

        }



        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string r = ml.Validar(txtUsuario, txtClave).ToUpper();
            if (!r.Equals("Error"))
            {
                this.Hide();
                switch (r)
                {
                    case "C0RR3CTO":
                        {
                            Formulario = ManejadorLogin.Formulario;
                            MessageBox.Show("Inicio de sesión, ¡Exitoso!");
                        }
                        break;
                    case "ERROR":
                        {
                            DialogResult rs = MessageBox.Show("Incorrecto, ¿Desea intentarlo de nuevo?", "!Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (rs == DialogResult.Yes)
                            {
                                this.Show();
                            }
                            else
                                this.Close();
                        }
                        break;
                }
            }
        }


        public void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
