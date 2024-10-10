using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using System.Windows.Forms;

namespace Manejador
{
    public class ManejadorHerramientas
    {
        Base b = new Base("localhost", "root", "", "BD_TallerAutomotriz");

        public string GuardarHerramientas(TextBox codigoherramientas, TextBox Nombre, TextBox medida, ComboBox Medida, TextBox Marca, TextBox Descripcion)
        {
            try
            {
                return b.Comando($"INSERT INTO Herramientas (CodigoHerramienta, Nombre, Medida, Marca, Descripcion) VALUES ('{codigoherramientas.Text}', '{Nombre.Text}', '{medida.Text + " " + Medida.Text}', '{Marca.Text}', '{Descripcion.Text}')");
            }
            catch (Exception)
            {
                return "Error de valor";
            }
        }
        public void MostrarHerramientas(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            DataTable datos = b.Consultar($"SELECT * FROM Herramientas WHERE Nombre LIKE '%{filtro}%' OR Marca LIKE '%{filtro}%'", "Herramientas").Tables[0];
            Tabla.DataSource = datos;
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }
        public void Modificar(int idh, TextBox codigoherramientas, TextBox Nombre, TextBox medida, ComboBox Medida, TextBox Marca, TextBox Descripcion)
        {
            b.Comando($"CALL p_ModificarHerramientas({idh},'{codigoherramientas.Text}', '{Nombre.Text}', '{medida.Text + " " + Medida.Text}', '{Marca.Text}', '{Descripcion.Text}')");
            MessageBox.Show("Registro Modificado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Eliminar(int idh, string Dato)
        {

            DialogResult rs = MessageBox.Show($"Está seguro de borrar {Dato}", "!Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"CALL p_EliminarHerramienta({idh})");
                MessageBox.Show("Registro Eliminado");
            }
        }
    }
}
