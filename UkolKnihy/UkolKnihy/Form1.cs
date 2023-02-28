using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UkolKnihy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string jmeno = textBox1.Text;
            DataTable tabulka = new DataTable();
            tabulka.Columns.Add("Název");
            tabulka.Columns.Add("Autor");
            tabulka.Columns.Add("Umístění");
            tabulka.Columns.Add("Žánr");
            tabulka.Columns.Add("Datum");

            StreamReader ctenar = new StreamReader("knihy.txt");

            while (!ctenar.EndOfStream)
            {
                tabulka.Rows.Add(ctenar.ReadLine().Split(';'));
            }
            ctenar.Close();

            StreamWriter zapis1 = new StreamWriter("knihy1.txt",true);
            StreamWriter zapis2 = new StreamWriter("knihy2.txt",true);
            ctenar = new StreamReader("knihy.txt");
            bool prvni = true;
            while (!ctenar.EndOfStream)
            {
                string radek = ctenar.ReadLine(); 
                listBox1.Items.Add(radek);
                string[] neco = radek.Split(';');

                if(neco.Contains(jmeno) && prvni == true)
                {
                    MessageBox.Show(jmeno +" napsal/a knihu " + neco[0]);
                    prvni = false;
                }

                if(Convert.ToInt32(radek.Substring(radek.Length - 4)) <= 1950)
                {
                    zapis1.WriteLine(radek);
                }
                else
                {
                    zapis2.WriteLine(radek);
                }

            }
            zapis1.Close();
            zapis2.Close();
            ctenar.Close();

            dataGridView1.DataSource = tabulka;

           
        }
    }
}
