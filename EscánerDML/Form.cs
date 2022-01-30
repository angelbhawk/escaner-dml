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
        private string cadena, eReg = @"(\W|((?<=\A)|(?<=\b))(\S+)((?<=\b)|(?=\z)))";

        private void Entrada()
        {
            tokens = new Tokens();
            cadena = tokens.formato(rtbInput.Text);
            reg = new Regex(eReg, RegexOptions.IgnoreCase);
            mCol = reg.Matches(cadena.ToUpper());
        }

        // Modulo de analisis
        private void Analisis()
        {
            int linea = 1;
            int numero = 1;

            foreach (Match c in mCol)
            {
                if (reg.IsMatch(c.ToString()))
                {
                    if (c.ToString() != "\r" && c.ToString() != "\r\n" && c.ToString() != "\n" && c.ToString() != " ")
                    {
                        //MessageBox.Show(c.Value + " " + linea + " " + numero);
                        if (tokens.esSimboloExistente(c.Value, numero, linea))
                        {
                            // Si son constantes
                            if (tokens.esConstante(c.Value, numero, linea))
                            {
                                // Si son identificadores
                                if (tokens.esIdentificador(c.Value, numero, linea))
                                {
                                    if(tokens.esAlfanumerico(c.Value, numero, linea))
                                    {
                                        // Identifica errores
                                    }
                                }
                            }
                        }
                        numero++;
                    }
                    else if (c.ToString() == "\r" || c.ToString() == "\r\n" || c.ToString() == "\n")
                    {
                        linea++;
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
                this.dgvOutput.Rows.Add(cadena.Numero, cadena.Linea, cadena.Valor.Dato, cadena.Valor.Tipo);
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
        private void Form_Load(object sender, EventArgs e)
        {
            cbxOpciones.SelectedIndex = 0;
        }
    }
}