using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corridas.Model
{
    public class Local
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        public string Cidade_Uf
        {
            get
            {
                return "(" + this.Uf + ") - " + this.Cidade;
            }
        }
    }
}
