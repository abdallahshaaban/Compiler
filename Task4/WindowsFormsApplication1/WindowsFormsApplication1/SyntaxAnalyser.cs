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
            node.token = new Token("Number", Token_Class.other);
            node.children.Add(match(Token_Class.constant));
            return node;
        }

        public static Node Reserver_keyword()
        {
            Node node = new Node();
            node.token = new Token("Reserver_keyword", Token_Class.reservedKeyword);

            if (LT[i].token_type==Token_Class.reservedKeyword)
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
            node.token = new Token("string", Token_Class.String);

            node.children.Add(match(Token_Class.String));

            return node;
        }
        public static Node Comment_State() {
            Node node = new Node();
            node.token = new Token("comment_state", Token_Class.comment);

            node.children.Add(match(Token_Class.comment));

            return node;
        }
    
        public static Node identifier() {
            Node node = new Node();
            node.token = new Token("identifier", Token_Class.Identifier);

            node.children.Add(match(Token_Class.Identifier));

            return node;
        }
           public static Node Factor() {
            Node node = new Node();
            node.token = new Token("factor", Token_Class.other);

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
            node.token = new Token("function_part", Token_Class.other);

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
            node.token = new Token("Term", Token_Class.other);

            node.children.Add(Factor());
            node.children.Add(Termdash());

            return node;
        }
        public static Node Termdash() {
            Node node = new Node();
            node.token = new Token("term dash", Token_Class.other);

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
            node.token = new Token("function call", Token_Class.other);

            node.children.Add(match(Token_Class.Identifier));
            node.children.Add(Function_Part());
            return node;
        }
        public static Node Parse(List<Token> Tokens)
        {
            Node root = new Node();
            
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
