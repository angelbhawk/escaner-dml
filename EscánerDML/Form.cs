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
        private MatchCollection mCol;
        private string cadena, eReg = @"(\W|((?<=\A)|(?<=\b))(\S+)((?<=\b)|(?=\z)))";

        private void Entrada()
        {
            AsignarFormato();
            reg = new Regex(eReg, RegexOptions.IgnoreCase);
            mCol = reg.Matches(cadena);
        }

        private void AsignarFormato()
        {
            cadena = rtbInput.Text;
            cadena = cadena.Replace(",", " , ");
            cadena = cadena.Replace("=", " = ");
            cadena = cadena.Replace("<", " < ");
            cadena = cadena.Replace(">", " > ");
            cadena = cadena.Replace("(", " ( ");
            cadena = cadena.Replace(")", " ) ");
            cadena = cadena.Replace("[", " [ ");
            cadena = cadena.Replace("]", " ] ");
            cadena = cadena.Replace(";", " ; ");
        }

        // Modulo de analisis
        private void Analisis()
        {
            foreach (Match c in mCol)
            {
                if (reg.IsMatch(c.ToString()))
                {
                    if (c.ToString() != "\r" && c.ToString() != "\r\n" && c.ToString() != "\n" && c.ToString() != " ")
                    {
                        MessageBox.Show(c.Value);
                    }
                       
                }
            }
        }

        // Eventos

        private void btnEscanear_Click(object sender, EventArgs e)
        {
            Entrada();
            Analisis();
        }
        private void Form_Load(object sender, EventArgs e)
        {

        }
    }
}