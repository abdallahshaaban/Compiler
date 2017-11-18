using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum Token_Class {String, Error,comment,Identifier, constant, reservedKeyword, semicolon, loop, two_operator, Operator, program, IF, dataType, Return, end, Else, Elseif, until, repeat, then };

namespace WindowsFormsApplication1
{
    public class TokenChecker
    {
        Dictionary<String, Token_Class> Classes;
        public void filldic()
        {
            Classes.Add("if", Token_Class.IF);
            Classes.Add(";", Token_Class.semicolon);
            Classes.Add("program", Token_Class.program);
            Classes.Add("+", Token_Class.Operator);
            Classes.Add("-", Token_Class.Operator);
            Classes.Add("*", Token_Class.Operator);
            Classes.Add("/", Token_Class.Operator);
            Classes.Add("int", Token_Class.dataType);
            Classes.Add("float", Token_Class.dataType);
            Classes.Add("string", Token_Class.dataType);
            Classes.Add("read", Token_Class.reservedKeyword);
            Classes.Add("write", Token_Class.reservedKeyword);

            Classes.Add("repeat", Token_Class.loop);
            Classes.Add("while", Token_Class.loop);
            Classes.Add("until", Token_Class.loop);
            Classes.Add("elseif", Token_Class.Elseif);
            Classes.Add("else", Token_Class.Else);
            Classes.Add("then", Token_Class.then);
            Classes.Add("return", Token_Class.Return);
            Classes.Add("end", Token_Class.end);
        }
        public TokenChecker()
        {
            Classes = new Dictionary<string, Token_Class>();
            filldic();
        }
        public string check(string T)
        {

            T = T.ToLower();
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
                        type = Token_Class.Identifier.ToString();
                    else i = 0;

                }
                else if (Helper.is_digit(T[i]))
                {
                    int dots = 0;
                    while (i < T.Length && (Helper.is_digit(T[i]) || (T[i] == '.' && dots == 0)))
                    {
                        if (T[i] == '.')
                            dots++;
                        ++i;

                    }
                    if (dots < 2 && i == T.Length) type = Token_Class.constant.ToString();

                }
                else if (i <= T.Length - 2 && Helper.is_two_operator(T[i], T[i + 1]))
                {

                    if (T[i] == '/' && T[i + 1] == '/')
                    {
                        type = Token_Class.comment.ToString();
                    }else if ( T[i] == '/' && T[i + 1] == '*')
                    {
                        if (T[T.Length - 2] == '*' && T[T.Length - 1] == '/')
                            type = Token_Class.comment.ToString();
                        else type = Token_Class.Error.ToString();

                    }
                    else
                    type = Token_Class.two_operator.ToString();
                }
                else if (Helper.is_one_operator(T[i]))
                {
                    //type = Type.Operator.ToString();
                    if (T[i] == '"')
                    {
                        if (T[T.Length - 1] == '"') type = Token_Class.String.ToString();

                    }
                    else type = Token_Class.Error.ToString();
                }
            }
                return type;
            }
        }
    }
