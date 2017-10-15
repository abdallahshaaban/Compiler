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
        

        

        public List<String> scan(String source_code)
        {
            List<String> tokens = new List<String>();

            for (int i = 0; i < source_code.Length; i++)
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
                    while (cur < source_code.Length &&(Helper.is_digit(source_code[cur]) || source_code[cur] == '.' || Helper.is_letter(source_code[cur])))
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
        }

    }
}
