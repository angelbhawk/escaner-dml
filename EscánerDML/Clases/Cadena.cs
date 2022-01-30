using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscánerDML.Clases
{
    class Cadena
    {
        private int numero, linea;
        private Token valor;

        public Cadena(int n, int l, Token t)
        {
            Numero = n;
            Linea = l;
            Valor = t;
        }

        public int Numero { get => numero; set => numero = value; }
        public int Linea { get => linea; set => linea = value; }
        internal Token Valor { get => valor; set => valor = value; }
    }
}