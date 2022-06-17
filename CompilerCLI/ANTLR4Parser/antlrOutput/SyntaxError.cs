using Antlr4.Runtime;
using System;

namespace CompilerCLI.ANTLRParser.antlrOutput{
    public class SyntaxError{
        private readonly IRecognizer recognizer;
        private readonly Object offendingSymbol;
        private readonly int line;
        private readonly int charPositionInLine;
        private readonly string message;
        private readonly RecognitionException e;

        public SyntaxError(IRecognizer recognizer, Object offendingSymbol, int line, int charPositionInLine, String msg, RecognitionException e)
        {
            this.recognizer = recognizer;
            this.offendingSymbol = offendingSymbol;
            this.line = line;
            this.charPositionInLine = charPositionInLine;
            this.message = msg;
            this.e = e;
        }

        public IRecognizer getRecognizer()
        {
            return recognizer;
        }

        public Object getOffendingSymbol()
        {
            return offendingSymbol;
        }

        public int getLine()
        {
            return line;
        }

        public int getCharPositionInLine()
        {
            return charPositionInLine;
        }

        public string getMessage()
        {
            return message;
        }

        public RecognitionException getException()
        {
            return e;
        }
    }
     
}