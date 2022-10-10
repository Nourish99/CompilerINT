using CompilerCLI.ParserTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerCLI.Models
{
    public class SemanticResultModel
    {
        public ASTNode ASTTree { get; set; }
        public Dictionary<string, SymTableItem> Variables { get; set; }
        public List<string> SemanticErrors { get; set; }

    }
}
