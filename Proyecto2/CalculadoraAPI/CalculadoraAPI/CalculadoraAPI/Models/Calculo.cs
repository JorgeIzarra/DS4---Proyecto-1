using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalculadoraAPI.Models
{
    public class Calculo
    {
        public int Id { get; set; }
        public double Numero1 { get; set; }
        public double Numero2 { get; set; }
        public string Operacion { get; set; }
        public double Resultado { get; set; }
        public DateTime FechaCalculo { get; set; }
    }
}