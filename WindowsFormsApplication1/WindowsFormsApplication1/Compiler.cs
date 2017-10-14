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
    public class Compiler
    {
        string sourceCode;

        public List<string> tokens,types;
        Scanner scaner;
        Token tokensClassification;

        public void compile() {
           types=new List<string>();
            int numberOfElement = tokens.Count();
            for (int i = 0; i < numberOfElement; ++i) {
              types.Add( tokensClassification.check(tokens[i]));

            }

            
        }

        public Compiler(string sourceCode)
        {
            this.sourceCode = sourceCode;
             scaner = new Scanner();
             tokens = new List<string>();
           

            tokens = scaner.scan(sourceCode);
           

            tokensClassification = new Token();
            compile();
        }

    }
}
