
using Antlr4.Runtime.Misc;
using Antlr4.Runtime ;
using System.Collections.Generic;
using System.IO;

namespace CompilerCLI.ANTLRParser.antlrOutput
{
    public class SyntaxErrorListener : BaseErrorListener{
        private readonly List<SyntaxError> sintaxErrors = new ArrayList<SyntaxError>();

        public SyntaxErrorListener(){

        }

        public List<SyntaxError> GetSyntaxErrors(){
            return this.sintaxErrors;
        }

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            sintaxErrors.Add(new SyntaxError(recognizer, offendingSymbol,line,charPositionInLine,msg,e));
        }

        public override string ToString()
        {
            return Utils.Join("\n",sintaxErrors);
        }
    }
}