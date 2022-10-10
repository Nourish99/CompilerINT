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
        public string tree { get; set; }
        public string TemporalVar { get; set; }

        public ASTNode()
        {
            Children = new List<ASTNode>();
            tree = "";
        }
        public void PrintPretty(string indent, bool last, bool typed)
        {
            if (Children == null)
            {
                return;
            }

            Console.Write(indent);
            tree += indent;
            if (last)
            {
                Console.Write("\\_");
                tree += "\\_";
                indent += "  ";
            }
            else
            {
                Console.Write("|_");
                tree += "!_";
                indent += "| ";
            }
            if (Tipo != null && typed)
            {
                Console.WriteLine(Label + " --> ( " + Tipo + " )");
                tree += string.Format("{0} --> ( {1} ){2}", Label, Tipo, Environment.NewLine);
            }
            else
            {
               Console.WriteLine(Label);
               tree += string.Format("{0}{1}", Label, Environment.NewLine);
            }

            Console.Write(tree);

            if (Children != null)
            {
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
}
