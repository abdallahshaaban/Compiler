using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


enum Type { Identifier, constant, reservedKeyword, semicolon, loop, two_operator, Operator, program, IF, dataType, Return, end, Else, Elseif, until, repeat, then };

namespace WindowsFormsApplication1
{
    public class Token
    {
        Dictionary<String, Type> Classes ;


        public void filldic()
        {
            Classes.Add("if", Type.IF);
            Classes.Add(";", Type.semicolon);
            Classes.Add("program", Type.program);
            Classes.Add("+", Type.Operator);
            Classes.Add("-", Type.Operator);
            Classes.Add("*", Type.Operator);
            Classes.Add("/", Type.Operator);
            Classes.Add("int", Type.dataType);
            Classes.Add("float", Type.dataType);
            Classes.Add("string", Type.dataType);
            Classes.Add("read", Type.reservedKeyword);
            Classes.Add("write", Type.reservedKeyword);
          
            Classes.Add("repeat", Type.loop);
            Classes.Add("while", Type.loop);
            Classes.Add("until", Type.loop);
            Classes.Add("elseif", Type.Elseif);
            Classes.Add("else", Type.Else);
            Classes.Add("then", Type.then);
            Classes.Add("return", Type.Return);
            Classes.Add("end", Type.end);

        }
       public Token() {

            Classes = new Dictionary<string, Type>();
            filldic(); }



        public string check(string T)
        {
            
          T=  T.ToLower();
            string type = "Error";
            if (Classes.ContainsKey(T)) { type = Classes[T].ToString(); }
            else
            {

                int i = 0;
                    if (Helper.is_letter(T[i]))
                    {
                        while (i < T.Length && (Helper.is_letter(T[i]) || Helper.is_digit(T[i])))
                        {

                            i++;
                        }
                    if (i == T.Length)
                        type = Type.Identifier.ToString();
                    else i = 0;

                    }
                    else if (Helper.is_digit(T[i]))
                    {
                        int dots = 0;
                        while (i < T.Length &&(Helper.is_digit(T[i]) || (T[i] == '.' && dots == 0)))
                        {
                            if (T[i] == '.')
                                dots++;
                        ++i;
                         
                        }
                        if(dots<2 && i==T.Length) type = Type.constant.ToString();

                    }
                else if (i <= T.Length - 2 && Helper.is_two_operator(T[i], T[i + 1]))
                {


                    type= Type.two_operator.ToString();
                }
                else if (Helper.is_one_operator(T[i]))
                {
                    type = Type.Operator.ToString();
                }




            }



            return type;
        }
    }
}
