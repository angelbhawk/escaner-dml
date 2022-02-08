using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscánerDML.Clases
{
    class Tokens
    {
        private List<Token> lTokens;
        private List<Cadena> lCadenas;

        string[] delimitador = new string[] { ",", "(", ")", ";", "[", "]", "{", "}", "|", "'", "‘", "’" };
        string[] operador = new string[] { "=", "<", ">", "+", "-", "*", "/", "<=", ">=", "==", "%", "!=", "<>", "===", "!==" };
        string[] reservadas = new string[] { "SELECT", "FROM", "WHERE", "AND", "ABORT", "ADMIN", "ALIGN", "ALL", "AS", "CHARACTER", 
                                             "COPY", "DECIMAL", "DEFAULT", "DISTINCT", "DO", "ELSE", "END", "EXCEPT", "EXTERNAL",
                                             "FALSE", "FLOAT", "FOR", "FOREIGN", "FUNCTION", "GROUP", "HAVING", "ILIKE", "IN", 
                                             "INDEX", "INNER", "INOUT", "INTERSECT", "INTO", "LIKE", "LEFT", "LIKE", "LIMIT", 
                                             "LOCK", "MINUS", "MOVE", "NATURAL", "NEW", "NOT", "NULL", "NULLIF", "NULLS", "NUMERIC", 
                                             "OLD", "ON", "OR", "OTHERS", "OUT", "OVER", "PRIMARY", "RESET", "REUSE", "RIGHT", "ROWS", 
                                             "SEARCH", "SYSTEM", "TIME", "TO", "TRANSACTION", "TRIGGER", "TRUE", "USER", "USING", "VIEW", 
                                             "WITH", "RESET", "REUSE" };

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

        public bool esDelimitador(string cadena)
        {
            foreach (string simbolo in delimitador)
            {
                if (cadena == simbolo)
                    return true;
            }
            return false;
        }

        public bool esOperador(string cadena)
        {
            foreach (string simbolo in operador)
            {
                if (cadena == simbolo)
                    return true;
            }
            return false;
        }

        //public bool esReservada(string cadena)
        //{
        //    foreach (string simbolo in reservadas)
        //    {
        //        if (cadena == simbolo)
        //            return true;
        //    }
        //    return false;
        //}
        public bool esReservada(string cadena)
        {
            Regex Reg;
            foreach (string simbolo in reservadas)
            {
                //Reg = new Regex(cadena,RegexOptions.IgnorePatternWhitespace);
                if (cadena.Replace(" ","")==simbolo)
                {
                    //MessageBox.Show(cadena + " " + simbolo);
                    return true;
                }
                    
                
            }
            return false;
        }

        public bool esNumerico(string cadena)
        {
            try
            {
                double i = Convert.ToDouble(cadena);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool esIdentificador(string cadena)
        {

            string erIde = @"^[A-Za-z0-9]*$";//@"\w+((?<!\W+)\W+)?";
            Regex Reg = new Regex(erIde, RegexOptions.IgnoreCase);

            if (Reg.IsMatch(cadena))
            {
                erIde = @"^[A-Za-z]+";//@"\w+((?<!\W+)\W+)?";
                Reg = new Regex(erIde, RegexOptions.IgnoreCase);
                if (Reg.IsMatch(cadena))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //public bool esIdentificador(string cadena)
        //{
        //    int reglas = 0;
        //    string erIde = @"^[A-Za-z]*$";//@"\w+((?<!\W+)\W+)?";
        //    string R2 = @"^[0-9]*$";
        //    Regex Reg = new Regex(erIde, RegexOptions.IgnoreCase);
        //    if (Reg.IsMatch(cadena))
        //    {
        //        reglas++;
        //    }
        //    Reg = new Regex(R2, RegexOptions.IgnoreCase);
        //    if (Reg.IsMatch(cadena))
        //    {
        //        reglas++;
        //    }
        //    if (reglas == 2)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public bool esNumerico2(string cadena)
        {
            string erIde = @"^[0-9]*$";//@"\w+((?<!\W+)\W+)?";
            Regex Reg = new Regex(erIde, RegexOptions.IgnoreCase);

            if (Reg.IsMatch(cadena))
            {
                erIde = @"^[0-9]+";//@"\w+((?<!\W+)\W+)?";
                Reg = new Regex(erIde, RegexOptions.IgnoreCase);
                if (Reg.IsMatch(cadena))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}