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
    public class Scanner
    {
        public List<String> tokens;

        public Scanner()
        {
            tokens = new List<String>();
        }

        public List<String> scan(String source_code)
        {

               /* for (int i = 0; i < source_code.Length; i++)
                {
                    int cur = i;
                    String lex = "";
                    if (Helper.is_letter(source_code[cur]))
                    {
                        while (cur < source_code.Length&&(Helper.is_letter(source_code[cur]) || Helper.is_digit(source_code[cur])))
                        {
                            lex += source_code[cur];
                            cur++;
                        }
                        tokens.Add(lex);
                        i = cur - 1;
                    }
                    else if (Helper.is_digit(source_code[cur]))
                    {
                        int dots = 0;
                        while (cur < source_code.Length &&(Helper.is_digit(source_code[cur]) || (source_code[cur] == '.' && dots == 0)))
                        {
                            if (source_code[cur] == '.')
                                dots++;
                            lex += source_code[cur];
                            cur++;
                        }
                        tokens.Add(lex);
                        i = cur - 1;
                    }
                    else if (cur != source_code.Length - 1 && Helper.is_two_operator(source_code[cur], source_code[cur + 1]))
                    {
                        lex += source_code[cur];
                        lex += source_code[cur + 1];
                        i = cur + 1;
                        tokens.Add(lex);
                    }
                    else if (Helper.is_one_operator(source_code[cur]))
                    {
                        lex += source_code[cur];
                        i = cur;
                        tokens.Add(lex);
                    }
                    else
                    {
                        continue;
                    }

                  }
                return tokens;
            }*/

            for (int i = 0; i < source_code.Length; i++)
            {
                String lex = "";
                if (source_code[i] == '\n' || source_code[i] == '\r' || source_code[i] == ' ') continue;
                lex += source_code[i];
              
                while (i < source_code.Length &&( source_code[i] != '\n' && source_code[i] != '\r' && source_code[i] != ' '))
                {
                    lex += source_code[i];
                    ++i;
                }
              
                tokens.Add(lex);
                
            }
            return tokens;
        }

    }
}