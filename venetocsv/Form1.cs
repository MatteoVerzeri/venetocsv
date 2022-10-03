using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace venetocsv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int recordlength = 528;
            var f = new FileStream(@"./veneto_verona.csv", FileMode.Open, FileAccess.ReadWrite);
            int tot=((int)f.Length);
            int linee=tot/recordlength+1;
            string line = Convert.ToString(linee);
            MessageBox.Show(line);
            
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            leggi(@"./veneto_verona.csv", text);
        }
        public static void leggi(string filename, string text)
        {
            StreamReader sr = new StreamReader(filename);
            string line;
            // Read and display lines from the file until the end of
            // the file is reached.
            while ((line = sr.ReadLine()) != null)
            {
                if ((line = sr.ReadLine()) == text)
                {
                    MessageBox.Show(line);
                    break;
                }
                
            }

            sr.Close();
        }
        public static void Ricerca(string filename, string nome, string x)
        {
            int i = 0, j = 527, m, pos = -1;
            StreamReader sr = new StreamReader(filename);


            do
            {
                m = (i + j) / 2;
                if ((nome = sr.ReadLine()) == x)
                    pos = m;
                else if (string.Compare((nome = sr.ReadLine()), x) == -1)
                    i = m + 1;
                else
                    j = m - 1;

            } while (i <= j && pos == -1);

            if (pos != -1)
                MessageBox.Show(pos.ToString());
            else
                MessageBox.Show("non trovato");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string x = textBox2.Text;
        }
    }
}
