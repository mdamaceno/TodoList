using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corridas.Model
{
    public class Corrida
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public DateTime DataCorrida { get; set; }
        public int Distancia { get; set; }
        public Local Local { get; set; }
    }
}
