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
