using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento.Models
{
    public class Estadia
    {
        public int id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Termino { get; set; }
        public Carro Carro { get; set; }
    }
}
