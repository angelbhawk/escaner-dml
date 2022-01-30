using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EscánerDML.Clases
{
    class Tokens
    {
        private List<Token> lTokens;
        private List<Cadena> lCadenas;
        
        string[] operador = new string[] { "=", "<", ">", "+", "-", "*", "/" };
        string[] reservadas = new string[] { "SELECT", "FROM", "WHERE", "AND" };
        string[] delimitador = new string[] { ",", "(", ")", ";" };

        internal List<Token> LTokens { get => lTokens; set => lTokens = value; }
        internal List<Cadena> LCadenas { get => lCadenas; set => lCadenas = value; }

        public Tokens()
        {
            LTokens = new List<Token>();
            LCadenas = new List<Cadena>();

            foreach (string palabra in reservadas)
            {
                LTokens.Add(new Token(palabra, "Reservada"));
            }

            foreach (string simbolo in operador)
            {
                LTokens.Add(new Token(simbolo, "Operador"));
            }

            foreach (string simbolo in delimitador)
            {
                LTokens.Add(new Token(simbolo, "Delimitador"));
            }
        }

        public string formato(string cadena)
        {
            foreach(Token elemento in LTokens)
            {
                if(elemento.Tipo == "Operador" || elemento.Tipo == "Delimitador")
                cadena = cadena.Replace(elemento.Dato, " "+elemento.Dato+" ");
            }
            return cadena;
        }

        public bool esSimboloExistente(string cadena, int numero, int linea)
        {
            foreach (Token elemento in LTokens)
            {
                if(elemento.Dato == cadena)
                {
                    LCadenas.Add(new Cadena(numero, linea, elemento));
                    return false;
                }
            }
            return true;
        }

        public bool esConstante(string cadena, int numero, int linea)
        {
            try
            {
                double i = Convert.ToDouble(cadena);
                LCadenas.Add(new Cadena(numero, linea, new Token(cadena, "Constante")));
                return false;
            }
            catch
            {
                return true;
            }
        }

        public bool esIdentificador(string cadena, int numero, int linea)
        {
            string erIde = @"^[A-Za-z0-9]*$";
            Regex reg = new Regex(erIde, RegexOptions.IgnoreCase);

            if (reg.IsMatch(cadena))
            {
                LCadenas.Add(new Cadena(numero, linea, new Token(cadena, "Identificador")));
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool esAlfanumerico(string cadena, int numero, int linea)
        {
            string erIde = "";
            erIde += @"(";
            erIde += @"(\S+)"; // Mientras tenga una comilla antes y despues, toma todo
            erIde += @")";

            Regex reg = new Regex(erIde, RegexOptions.IgnoreCase);

            if (reg.IsMatch(cadena))
            {
                LCadenas.Add(new Cadena(numero, linea, new Token(cadena, "Alfanumerico")));
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}