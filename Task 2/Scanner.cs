using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Task2
{
  public class Scanner 
  {
    public List<String>tokens;
    
    public Scanner() 
    {
      tokens = new List<String>();
    }
    
    public bool is_digit(char c) 
    {
      return (c>='0' && c<='9');
    }
    
    public bool is_letter(char c) 
    {
      return (c>='a' && c<='z');
    }
    
    public bool is_one_operator(char c)
    {
      return (c=='+'||c=='-'||c=='*'||c=='/'||c=='>'||c=='<'||c=='='||c==';');
    }
    
    public bool is_two_operator(char c1, char c2) 
    {
      String s="";
      s+=c1;
      s+=c2;
      return (s=="<>"||s=="&&"||s=="||");
    }
    
    public void scan(String source_code) 
    {
      for(int i = 0; i < source_code.Length; i++) 
      {
        int cur=i;
        String lex="";
        if(is_letter(source_code[cur]))
        {
          while(is_letter(source_code[cur])||is_digit(source_code[cur]))
          {
            lex+=source_code[cur];
            cur++;
          }
          tokens.Add(lex);
          i=cur-1;
        }
        else if(is_digit(source_code[cur]))
        {
          int dots=0;
          while(is_digit(source_code[cur])||(source_code[cur]=='.'&&dots==0))
          {
            if(source_code[cur]=='.')
              dots++;
            lex+=source_code[cur];
            cur++;
          }
          tokens.Add(lex);
          i=cur-1;
        }
        else if(cur!=source_code.Length-1&&is_two_operator(source_code[cur],source_code[cur+1]))
        {
          lex+=source_code[cur];
          lex+=source_code[cur+1];
          i=cur+1;
          tokens.Add(lex);
        }
        else if(is_one_operator(source_code[cur]))
        {
          lex+=source_code[cur];
          i=cur;
          tokens.Add(lex);
        }
        else
        {
          continue;
        }
      }
    }
  }
  
}
