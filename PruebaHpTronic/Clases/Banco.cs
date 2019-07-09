using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaHpTronic.Clases
{
    public class Banco
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cuenta { get; set; }

        public Banco(int id, string nombre, string cuenta)
        {
            Id = id;
            Nombre = nombre;
            Cuenta = cuenta;
        }

        public Banco()
        {
            Id = 0;
            Nombre = string.Empty;
            Cuenta = string.Empty;
        }
    }
}
