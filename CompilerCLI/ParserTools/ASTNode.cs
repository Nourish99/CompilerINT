using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CompilerCLI.ParserTools
{
    public class ASTNode
    {
        public List<ASTNode> Children { get; set; }
        public int Id { get; set; }
        public string Label { get; set; }
        public string Valor { get; set; }
        public string Tipo { get; set; }

        public ASTNode()
        {
            Children = new List<ASTNode>();
        }
        public void PrintPretty(string indent, bool last, bool typed)
        {
            if (Children == null)
            {
                return;
            }
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\_");
                indent += "  ";
            }
            else
            {
                Console.Write("|_");
                indent += "| ";
            }
            if (Tipo != null && typed)
            {
                Console.WriteLine(Label + " --> ( "+Tipo+" )");
            }
            else
            {
                Console.WriteLine(Label);
            }


            if (Children != null)
                for (int i = 0; i < Children.Count; i++)
                {
                    if (Children[i] != null)
                    {
                        Children[i].PrintPretty(indent, i == Children.Count - 1, typed);
                    }                    
                }
                    
        }

    }
}
