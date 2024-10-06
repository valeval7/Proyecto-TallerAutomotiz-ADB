using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Refacciones
    {
        public Refacciones(string codigoBarras, string nombre, string descripcion, string marca, DateTime creacion, DateTime actualizacion)
        {
            CodigoBarras = codigoBarras;
            Nombre = nombre;
            Descripcion = descripcion;
            Marca = marca;
            Creacion = creacion;
            Actualizacion = actualizacion;
        }

        public string CodigoBarras { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime Actualizacion { get; set; }
    }
}
