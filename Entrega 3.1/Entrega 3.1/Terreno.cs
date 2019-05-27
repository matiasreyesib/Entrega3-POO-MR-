using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega_3._1
{
    class Terreno
    {
        string tipo_terreno;

        public Terreno(string tipo)
        {
            tipo_terreno = tipo;
        }

        public string get_tipo_terreno()
        {
            return tipo_terreno;
        }
    }
}
