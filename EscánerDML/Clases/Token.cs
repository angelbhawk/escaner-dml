using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EscánerDML.Clases.Tokens
{
    class Token
    {
        private int tipo;
        private int indice;
        private string dato;

        public Token() { }

        public Token(string d, int i, int t)
        {
            Dato = d;
            Indice = i;
            Tipo = t;
        }

        public string Dato { get => dato; set => dato = value; }
        public int Indice { get => indice; set => indice = value; }
        public int Tipo { get => tipo; set => tipo = value; }
    }
}