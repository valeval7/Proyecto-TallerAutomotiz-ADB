using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace Manejador
{
    public class ManejadorLogin
    {
        Base b = new Base("localhost", "root", "", "BD_TallerAutomotriz");
        public static string Tipo = "", TipoR="", TipoH="", Formulario = "";
        public string Validar(TextBox NickName, TextBox Clave)
        {
            DataSet ds = b.Consultar($"call p_validaru('{NickName.Text}', '{Sha1(Clave.Text)}')", "usuarios");
            DataTable dt = ds.Tables[0];

            if (dt.Rows[0]["rs"].ToString().Equals("C0rr3cto"))
            {
                Tipo = dt.Rows[0]["tipo"].ToString();
                Formulario = dt.Rows[0]["formulario"].ToString();
                TipoR = dt.Rows[0]["tipor"].ToString();
                TipoH = dt.Rows[0]["tipoh"].ToString();
                return dt.Rows[0]["rs"].ToString();
            }

            else
            {
                return "Error";
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
