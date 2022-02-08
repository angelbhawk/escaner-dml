using EscánerDML.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscánerDML
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        // Modulo de entrada
        private Regex reg;
        private Tokens tokens;
        private MatchCollection mCol;
        private string cadena, expreg = @"((\b)(\w+[#]?)(\s)|(?<=\b)(\w*[^=,+-])(\b)|(['-'])|(\W?))";
        //private string cadena, expreg = @"((\b)(\w*\W*[^,=])(?<=\B)(\b))";

        private void Entrada()
        {
            //string er = "";
            //er += @"(\W)"; // Toma todos los simbolos que no formen parte de una palabra (letras y números)
            //er += @"|"; // Si no
            //er += @"((?<=\A)|(?<=\b))"; // Mientras tenga un espacio o inicio de linea antes
            //er += @"|"; // Si no
            //er += @"()"; // Mientras tenga un espacio o inicio de linea antes
            tokens = new Tokens();
            cadena = rtbInput.Text;
            //reg = new Regex(expreg, RegexOptions.IgnoreCase);
            reg = new Regex(expreg, RegexOptions.IgnoreCase);
            mCol = reg.Matches(cadena.ToUpper());
        }

        // Modulo de analisis
        private void Analisis()
        {
            int linea = 1;
            int numero = 1;

            Queue<string> simbolos = new Queue<string>();
            Queue<string> alfanumericos = new Queue<string>();

            foreach (Match c in mCol)
            {
                if (reg.IsMatch(c.ToString()))
                {
                    if (c.ToString() == "‘" || c.ToString() == "’" || c.ToString() == "'" || alfanumericos.Count > 0) // Validar si es un alfa
                    {
                        alfanumericos.Enqueue(c.ToString());

                        if ((c.ToString() == "‘" || c.ToString() == "’" || c.ToString() == "'") && alfanumericos.Count > 1)
                        {
                            string temp = "";
                            foreach(string alfa in alfanumericos)
                            {
                                temp += alfa;
                            }
                            tokens.LCadenas.Add(new Cadena(numero, linea, new Token(temp, "Alfanumerico")));
                            //MessageBox.Show(temp);
                            alfanumericos.Clear();
                            numero++;
                        }
                    }
                    else if (tokens.esDelimitador(c.ToString())) // Validar si es un delimitador
                    {
                        tokens.LCadenas.Add(new Cadena(numero, linea, new Token(c.ToString(), "Delimitador")));
                        numero++;
                    }
                    else if (tokens.esOperador(c.ToString()))
                    {
                        if(simbolos.Count > 0)
                        {

                        }
                        tokens.LCadenas.Add(new Cadena(numero, linea, new Token(c.ToString(), "Operador")));
                        numero++;
                    }
                    else if (tokens.esReservada(c.ToString()))
                    {
                        tokens.LCadenas.Add(new Cadena(numero, linea, new Token(c.ToString(), "Reservada")));
                        numero++;
                    }
                    //else if (tokens.esNumerico(c.ToString()))
                    //{
                    //    tokens.LCadenas.Add(new Cadena(numero, linea, new Token(c.ToString(), "Numerico")));
                    //    numero++;
                    //}
                    else if (tokens.esNumerico2(c.ToString()))
                    {
                        tokens.LCadenas.Add(new Cadena(numero, linea, new Token(c.ToString(), "Numerico")));
                        numero++;
                    }
                    else if (tokens.esIdentificador(c.ToString()))
                    {
                        tokens.LCadenas.Add(new Cadena(numero, linea, new Token(c.ToString(), "Identificador")));
                        numero++;
                    }
                    
                    else if(c.ToString() == "\r" || c.ToString() == "\r\n" || c.ToString() == "\n")
                    {
                        linea++;
                    }
                    else if (c.ToString() == " ")
                    {
                        //nada++;
                    }
                    else
                    {
                        tokens.LCadenas.Add(new Cadena(numero, linea, new Token(c.ToString(), "Invalida")));
                        numero++;
                    }
                }
            }
        }

        // Modulo de resultados
        private void Resultados()
        {
            dgvOutput.Rows.Clear();
            dgvOutput.Columns.Clear();

            dgvOutput.Columns.Add("No", "Número");
            dgvOutput.Columns.Add("Li", "Linea");
            dgvOutput.Columns.Add("Va", "Cadena");
            dgvOutput.Columns.Add("Ti", "Tipo");

            foreach (Cadena cadena in tokens.LCadenas)
            {
                if(cadena.Valor.Tipo == "Alfanumerico" || cadena.Valor.Tipo == "Numerico")
                {
                    this.dgvOutput.Rows.Add(cadena.Numero, cadena.Linea, "CONSTANTE", cadena.Valor.Tipo);
                }
                else
                {
                    this.dgvOutput.Rows.Add(cadena.Numero, cadena.Linea, cadena.Valor.Dato, cadena.Valor.Tipo);
                }
               
            }

            dgvOutput.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOutput.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOutput.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOutput.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // Eventos
        private void btnEscanear_Click(object sender, EventArgs e)
        {
            Entrada();
            Analisis();
            Resultados();
        }
    }
}