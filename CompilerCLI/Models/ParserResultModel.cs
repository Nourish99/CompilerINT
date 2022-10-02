using Antlr.Runtime.Tree;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CompilerCLI.ANTLRParser.antlrOutput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerCLI.Models
{
    public class ParserResultModel
    {
        public List<SyntaxError> Errors { get; set; }
        public CommonTree tree { get; set; }
        public IParseTree treeCST { get; set; }
        public bool IsCorrect { get; set; }
        public List<string> parss { get; set; }
    }
}
