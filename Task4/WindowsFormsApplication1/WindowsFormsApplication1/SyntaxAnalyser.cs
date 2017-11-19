using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Node
    {
        public List<Node> children = new List<Node>();
        public Token token;
    }
    class SyntaxAnalyser
    {
        public static List<Token> LT;
        static int i = 0;
        //public SyntaxAnalyser() { LT = new List<Token>(); }
        public static Node match(Token_Class t) {
            Node match = new Node();

            if (i<LT.Count()&&LT[i].token_type == t)
                match.token = LT[i];
            i++;
            return match;
            
           
        }

         
        public static Node Number() {
            Node node = new Node();
            node.children.Add(match(Token_Class.constant));
            return node;
        }

        public static Node Reserver_keyword()
        {
            Node node = new Node();
            if(LT[i].token_type==Token_Class.reservedKeyword)
            node.children.Add(match(Token_Class.reservedKeyword));
            if (LT[i].token_type == Token_Class.Else)
                node.children.Add(match(Token_Class.Else));
            if (LT[i].token_type == Token_Class.Elseif)
                node.children.Add(match(Token_Class.Elseif));
            if (LT[i].token_type == Token_Class.IF)
                node.children.Add(match(Token_Class.IF));
            if (LT[i].token_type == Token_Class.then)
                node.children.Add(match(Token_Class.then));
            if (LT[i].token_type == Token_Class.Return)
                node.children.Add(match(Token_Class.Return));
            if (LT[i].token_type == Token_Class.repeat)
                node.children.Add(match(Token_Class.repeat));
            if (LT[i].token_type == Token_Class.until)
                node.children.Add(match(Token_Class.until));

            return node;
        }
        public static Node String() {
            Node node = new Node();
            node.children.Add(match(Token_Class.String));

            return node;
        }
        public static Node Comment_State() {
            Node node = new Node();
            node.children.Add(match(Token_Class.comment));

            return node;
        }
    
        public static Node identifier() {
            Node node = new Node();
            node.children.Add(match(Token_Class.Identifier));

            return node;
        }
           public static Node Factor() {
            Node node = new Node();
            if (LT[i].token_type == Token_Class.Identifier)
                node.children.Add(Function_Call());
            if (LT[i].token_type == Token_Class.String)
                node.children.Add(String());
            if (LT[i].token_type == Token_Class.constant)
                node.children.Add(Number());
            if (LT[i].lex == '('.ToString())
                node.children.Add(Expression());
            return node;
        }
        public static Node Function_Part() {
            Node node = new Node();
            if (LT[i].lex=='('.ToString())
                node.children.Add(match(Token_Class.Operator));
            node.children.Add(match(Token_Class.Identifier));
            while (LT[i].lex == ','.ToString())
            {
                node.children.Add(match(Token_Class.Operator));
                node.children.Add(match(Token_Class.Identifier));
            }
            if (LT[i].lex == ')'.ToString())
                node.children.Add(match(Token_Class.Operator));
            return node;
        }
        public static Node Term() {
            Node node = new Node();
            node.children.Add(Factor());
            node.children.Add(Termdash());

            return node;
        }
        public static Node Termdash() {
            Node node = new Node();
            if (LT[i].lex == '*'.ToString())
            {
                node.children.Add(match(Token_Class.Operator));
                node.children.Add(Termdash());
            }

            return node;
        }
        public static Node Function_Call()
        {
            Node node = new Node();
            node.children.Add(match(Token_Class.Identifier));
            node.children.Add(Function_Part());
            return node;
        }
        
        //18
        public static Node Return_Statement()
        {
            Node return_statement = new Node();
            return_statement.token = new Token("Return_Statement", Token_Class.Return);
            return_statement.children.Add(match(Token_Class.Return));
            return_statement.children.Add(Expression());
            return_statement.children.Add(match(Token_Class.semicolon));
            return return_statement;
        }

        //19
        public static Node Condition_Operator()
        {
            Node condition_op = new Node();
            condition_op.token = new Token("Condition_Operator", Token_Class.Other);
            if (LT[i].token_type == Token_Class.LessThanOp)
                condition_op.children.Add(match(Token_Class.LessThanOp));
            else if(LT[i].token_type == Token_Class.GreaterThanOp)
                condition_op.children.Add(match(Token_Class.GreaterThanOp));
            else if (LT[i].token_type == Token_Class.IsEqualOp)
                condition_op.children.Add(match(Token_Class.IsEqualOp));
            else if (LT[i].token_type == Token_Class.NotEqualOp)
                condition_op.children.Add(match(Token_Class.NotEqualOp));
            return condition_op;
        }

        //20
        public static Node Condition_Statement()
        {
            Node condition_statement = new Node();
            condition_statement.token = new Token("Condition_Statement", Token_Class.Other);
            condition_statement.children.Add(Condition_Term());
            condition_statement.children.Add(Condition_Statement_2());
            return condition_statement;
        }

        public static Node Condition_Statement_2()
        {
            Node cond_stmt_2 = new Node();
            cond_stmt_2.token = new Token("Condition_Statement_2", Token_Class.Other);
            if (LT[i].token_type == Token_Class.Or_Operator)
            {
                cond_stmt_2.children.Add(OrOp());
                cond_stmt_2.children.Add(Condition_Term());
                cond_stmt_2.children.Add(Condition_Statement_2());
            }
            return cond_stmt_2;
        }

        //21
        public static Node Condition_Term()
        {
            Node cond_term = new Node();
            cond_term.token = new Token("Condition_Term", Token_Class.Other);
            cond_term.children.Add(Condition());
            cond_term.children.Add(Condition_Term_2());
            return cond_term;
        }

        public static Node Condition_Term_2()
        {
            Node cond_term_2 = new Node();
            cond_term_2.token = new Token("Condition_Term_2", Token_Class.Other);
            if(LT[i].token_type == Token_Class.And_Operator)
            {
                cond_term_2.children.Add(AndOp());
                cond_term_2.children.Add(Condition());
                cond_term_2.children.Add(Condition_Term_2());
            }
            return cond_term_2;
        }

        //22
        public static Node Condition()
        {
            Node cond = new Node();
            cond.token = new Token("Condition", Token_Class.Other);
            cond.children.Add(Expression());
            cond.children.Add(Condition_Operator());
            cond.children.Add(Expression());
            return cond;
        }

        //23
        public static Node AndOp()
        {
            Node and_op = new Node();
            and_op.token = new Token("AndOp", Token_Class.And_Operator);
            and_op.children.Add(match(Token_Class.And_Operator));
            return and_op;
        }

        //24
        public static Node OrOp()
        {
            Node or_op = new Node();
            or_op.token = new Token("OrOp", Token_Class.Or_Operator);
            or_op.children.Add(match(Token_Class.Or_Operator));
            return or_op;
        }
        
        public static Node Parse(List<Token> Tokens)
        {
            Node root = new Node();
            LT = Tokens;
            //write your parser code

            return root;
        }



        //use this function to print the parse tree in TreeView Toolbox
        public static TreeNode PrintParseTree(Node root)
        {
            TreeNode tree = new TreeNode("Parse Tree");
            TreeNode treeRoot = PrintTree(root);
            if(treeRoot != null)
                tree.Nodes.Add(treeRoot);
            return tree;
        }
        static TreeNode PrintTree(Node root)
        {
            if (root == null || root.token == null)
                return null;
            TreeNode tree = new TreeNode(root.token.lex);
            if (root.children.Count == 0)
                return tree;
            foreach (Node child in root.children)
            {
                if (child == null)
                    continue;
                tree.Nodes.Add(PrintTree(child));
            }
            return tree;
        }
    }
}
