using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using Entidades;

namespace Manejador
{
    public class ManejadorRefacciones
    {
        Base b = new Base("localhost", "root", "", "BD_TallerAutomotriz");
        public string GuardarRefacciones(TextBox codigoBarras, TextBox Nombre, TextBox descripcion, TextBox Marca)
        {
            try
            {
                return b.Comando($"INSERT INTO Refacciones (CodigoBarras, Nombre, Descripcion, Marca) VALUES ('{codigoBarras.Text}', '{Nombre.Text}', '{descripcion.Text}', '{Marca.Text}')");
            }
            catch (Exception)
            {
                return "Error de valor";
            }
        }
        public void MostrarRefacciones(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            DataTable datos = b.Consultar($"SELECT * FROM Refacciones WHERE Nombre LIKE '%{filtro}%' OR Marca LIKE '%{filtro}%'", "Herramientas").Tables[0];
            Tabla.DataSource = datos;
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }
        public void Modificar(int IdR, TextBox codigoBarras, TextBox Nombre, TextBox descripcion, TextBox Marca)
        {
            b.Comando($"CALL p_ModificarRefacciones({IdR},'{codigoBarras.Text}', '{Nombre.Text}', '{descripcion.Text}', '{Marca.Text}')");
            MessageBox.Show("Registro Modificado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Eliminar(int idr, string Dato)
        {
            DialogResult rs = MessageBox.Show($"Está seguro de borrar {Dato}", "!Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"CALL p_EliminarRefacciones({idr})");
                MessageBox.Show("Registro Eliminado");
            }
        }
    }
}
