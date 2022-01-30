using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EscánerDML.Clases
{
    class Token
    {
        private string tipo;
        private string dato;

        public Token() { }

        public Token(string d, string t)
        {
            Dato = d;
            Tipo = t;
        }

        public string Dato { get => dato; set => dato = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}