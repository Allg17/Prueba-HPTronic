using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades_Albert;

namespace PruebaHpTronic.Clases
{
    public class Transacciones
    {
        public int Id { get; set; }
        public int Id_Banco { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
        public decimal Monto { get; set; }

        public Transacciones(int id, int id_Banco, string tipo, DateTime fecha, string detalle, decimal mondo)
        {
            Id = id;
            Id_Banco = id_Banco;
            Tipo = tipo;
            Fecha = fecha;
            Detalle = detalle;
            Monto = mondo;
        }

        public Transacciones()
        {
            Id = 0;
            Id_Banco = 0;
            Tipo = string.Empty;
            Fecha = DateTime.Now;
            Detalle = string.Empty;
            Monto = 0;
        }
    }
}
