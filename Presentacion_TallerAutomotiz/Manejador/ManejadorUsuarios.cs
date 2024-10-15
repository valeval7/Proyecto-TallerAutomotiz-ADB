using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;

namespace Manejador
{
    public class ManejadorUsuarios
    {
        Base b = new Base("localhost", "root", "", "BD_TallerAutomotriz");
        public string GuardarUser(TextBox Nombre, TextBox ApellidoP, TextBox ApellidoM, DateTimePicker Nacimiento, TextBox RFC, TextBox NickName, ComboBox Tipo, ComboBox Formulario, ComboBox TipoR, ComboBox TipoH, TextBox Clave)
        {
            try
            {
                return b.Comando($"INSERT INTO Usuarios (idusuario, Nombre, apellidopaterno, apellidomaterno, fechanacimiento, rfc, NickName, Tipo, Formulario, TipoRefacciones, TipoHerramientas, Clave) " +
                $"VALUES (null, '{Nombre.Text}', '{ApellidoP.Text}', '{ApellidoM.Text}', '{Nacimiento.Value.ToString("yyyy-MM-dd HH:mm:ss")}', '{RFC.Text}', '{NickName.Text}', " +
                $"'{Tipo.SelectedItem}', '{Formulario.Text}', '{TipoR.SelectedItem}', '{TipoH.SelectedItem}', '{Sha1(Clave.Text)}')");
            }
            catch (Exception)
            {
                return "Error de valor";
            }
        }

        public void MostrarAdministrador(DataGridView Tabla, string filtro)
        {
            Tabla.Columns.Clear();
            DataTable datos = b.Consultar($"SELECT * FROM Usuarios WHERE Tipo LIKE '%{filtro}%' OR Nombre LIKE '%{filtro}%' AND ApellidoPaterno LIKE '%{filtro}%'", "Usuarios").Tables[0]; 
            Tabla.DataSource = datos;
            Tabla.AutoResizeColumns();
            Tabla.AutoResizeRows();
        }

        public void Modificar(int Id, TextBox Nombre, TextBox ApellidoP, TextBox ApellidoM, DateTimePicker Nacimiento, TextBox RFC, TextBox NickName, ComboBox Tipo, ComboBox Formulario, ComboBox TipoR, ComboBox TipoH, TextBox Clave)
        {
            b.Comando($"CALL p_ModificarUser({Id}, '{Nombre.Text}', '{ApellidoP.Text}', '{ApellidoM.Text}', '{Nacimiento.Value.ToString("yyyy-MM-dd HH:mm:ss")}', '{RFC.Text}', '{NickName.Text}', " +
                       $"'{Tipo.SelectedItem}', '{Formulario.Text}', {(string.IsNullOrWhiteSpace(Clave.Text) ? "NULL" : $"'{Sha1(Clave.Text)}'")});");
            MessageBox.Show("Registro Modificado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public void Eliminar(int Id, string Dato)
        {
            DialogResult rs = MessageBox.Show($"Está seguro de borrar {Dato}", "!Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"CALL p_EliminarUser({Id})");
                MessageBox.Show("Registro Eliminado");
            }
        }

        public static string Sha1(String texto)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(texto);
            Byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();
            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }
    }
}
