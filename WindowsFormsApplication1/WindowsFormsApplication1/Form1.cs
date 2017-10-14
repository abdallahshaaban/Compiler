using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        List<string> GetLines(string Jaconcode)
        {

            List<string> Lines = new List<string>();

            string tmp = "";

            for (int i = 0; i < Jaconcode.Length; i++)
            {
                if (Jaconcode[i] == '\n' || Jaconcode[i] == '\r') continue;
                tmp += Jaconcode[i];

                if (Jaconcode[i] == ';')
                {
                    Lines.Add(tmp);
                    tmp = "";
                }
            }

            return Lines;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // just for test 
            // you shoud display two lists (compile.tokens ,compile.types)
            string code = JaconCode.Text;
            Compiler compile = new Compiler(code);
           

            int numberOfElement = compile.tokens.Count();
           
            for (int i = 0; i < numberOfElement; ++i) {
                MessageBox.Show(compile.tokens[i].ToString());
                MessageBox.Show(compile.types[i].ToString());
               
           }
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
