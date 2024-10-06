using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class Herramientas
    {
        public Herramientas(string codigoHerramienta, string nombre, string medida, string marca, string descripcion, DateTime creacion, DateTime actualizacion)
        {
            CodigoHerramienta = codigoHerramienta;
            Nombre = nombre;
            Medida = medida;
            Marca = marca;
            Descripcion = descripcion;
            Creacion = creacion;
            Actualizacion = actualizacion;
        }

        public string CodigoHerramienta { get; set; }
        public string Nombre { get; set; }
        public string Medida { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime Actualizacion { get; set; }

    }
}