using Antlr.Runtime.Tree;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Tree;
using CompilerCLI.ANTLR4Files;
using CompilerCLI.ANTLRParser.antlrOutput;
using CompilerCLI.Models;
using CompilerCLI.ParserTools;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerCLI.Helpers
{

    public class ProceduresHelper
    {
        public static List<TokenItem> ResultsLexer = new List<TokenItem>();
        public static List<TokenItem> ErrorsLexer = new List<TokenItem>();

        public LexerResultModel GetLexerAnalisis(string filePath, string outDir)
        {
            try
            {
                ResultsLexer.Clear();
                ErrorsLexer.Clear();
                string text = System.IO.File.ReadAllText(filePath);
                AntlrInputStream inputStream = new AntlrInputStream(text);
                TINYLexer speakLexer = new TINYLexer(inputStream);
                CommonTokenStream commonTokenStream = new CommonTokenStream(speakLexer);
                TINYParser speakParser = new TINYParser(commonTokenStream);
                commonTokenStream.Fill();
                LexerResultModel lrm = new LexerResultModel() { Results = ResultsLexer, Errorrs = ErrorsLexer };
                if (!string.IsNullOrEmpty(outDir))
                {
                    SaveLexerFileResults(lrm, outDir);
                }
                return lrm;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                return null;
            }
        }

        public LexerResultModel GetLexerAnalisisFromText(string text)
        {
            try
            {
                ResultsLexer.Clear();
                ErrorsLexer.Clear();
                AntlrInputStream inputStream = new AntlrInputStream(text);
                TINYLexer speakLexer = new TINYLexer(inputStream);
                CommonTokenStream commonTokenStream = new CommonTokenStream(speakLexer);
                TINYParser speakParser = new TINYParser(commonTokenStream);
                commonTokenStream.Fill();
                LexerResultModel lrm = new LexerResultModel() { Results = ResultsLexer, Errorrs = ErrorsLexer };
                return lrm;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                return null;
            }
        }

        public void SaveLexerFileResults(LexerResultModel lrm, string dirPath)
        {
            TokenStreamExporter tkse = new TokenStreamExporter(lrm.Results, lrm.Errorrs);
            tkse.ExportLexerResults(dirPath);
            if (Directory.Exists(dirPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = dirPath,
                    FileName = "explorer.exe"
                };

                Process.Start(startInfo);
            }
            else
            {
                Console.WriteLine(string.Format("{0} Directory does not exist!", dirPath));
            }
        }
        public void PrintLexerAnalysis(LexerResultModel lrm)
        {
            Console.WriteLine("Resultado de analisis lexico!");
            Console.WriteLine("*********************************************");
            Console.WriteLine("TokenName\tLexema\tLinea\tColumna");
            foreach (var i in lrm.Results)
            {
                Console.WriteLine(i.TokenName + "\t" + i.TokenDesc + "\t" + i.TokenLine + "\t" + i.TokenCol);
            }
            Console.WriteLine("*********************************************");
            Console.WriteLine("Tokens No reconocidos!");
            Console.WriteLine("*********************************************");
            Console.WriteLine("TokenName\tLexema\tLinea\tColumna");
            foreach (var i in lrm.Errorrs)
            {
                Console.WriteLine(i.TokenName + "\t" + i.TokenDesc + "\t" + i.TokenLine + "\t" + i.TokenCol);
            }
        }

        public ParserResultModel GetParserAnalisis(string filePath, string outDir)
        {
            try
            {
                ParserResultModel parserResultModel = new ParserResultModel();

                string text = System.IO.File.ReadAllText(filePath);
                AntlrInputStream inputStream = new AntlrInputStream(text);
                tinyLexer speakLexer = new tinyLexer(inputStream);
                CommonTokenStream commonTokenStream = new CommonTokenStream(speakLexer);
                tinyParser speakParser = new tinyParser(commonTokenStream) { BuildParseTree = true };
                SyntaxErrorListener errorListener = new SyntaxErrorListener();
                speakParser.AddErrorListener(errorListener);
                commonTokenStream.Fill();
                IParseTree parseTree = speakParser.parse();
                ParseTreeWalker w = new ParseTreeWalker();
                tinyBaseListener S = new tinyBaseListener();
                w.Walk(S, parseTree);
                parserResultModel.Errors = errorListener.GetSyntaxErrors();
                parserResultModel.treeCST = parseTree;


                try
                {
                    ASTVisitor stV = new ASTVisitor();
                    stV.Visit(parseTree);
                    var a = stV.SemanticErrors;
                    stV.parent.PrintPretty(" ",false);
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                }

                //Console.WriteLine(Trees.ToStringTree(parseTree));
                parserResultModel.parss = speakParser.RuleNames.ToList<string>();
                return parserResultModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal Error: " + ex);
                return null;
            }
        }
        public ParserResultModel GetParserAnalisis(string text)
        {
            try
            {
                ParserResultModel parserResultModel = new ParserResultModel() { Errors=new List<SyntaxError>()};

                AntlrInputStream inputStream = new AntlrInputStream(text);
                tinyLexer speakLexer = new tinyLexer(inputStream);
                CommonTokenStream commonTokenStream = new CommonTokenStream(speakLexer);
                tinyParser speakParser = new tinyParser(commonTokenStream) { BuildParseTree = true };
                SyntaxErrorListener errorListener = new SyntaxErrorListener();
                speakParser.AddErrorListener(errorListener);
                commonTokenStream.Fill();
                IParseTree parseTree = speakParser.parse();
                ParseTreeWalker w = new ParseTreeWalker();
                tinyBaseListener S = new tinyBaseListener();
                w.Walk(S, parseTree);

                parserResultModel.Errors = errorListener.GetSyntaxErrors();
                parserResultModel.treeCST = parseTree;
                if (parserResultModel.Errors.Count>0)
                {
                    parserResultModel.IsCorrect = true;
                }
                else
                {
                    parserResultModel.IsCorrect = false;
                }
                parserResultModel.parss = speakParser.RuleNames.ToList<string>();
                //Console.WriteLine(Trees.ToStringTree(parseTree));
                return parserResultModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal Error: " + ex);
                return null;
            }
        }

        /*public void PrintTree(int level, IParseTree parent)
        {
            for (int i = 1; i < level; i++)
            {
                Console.Write("\t");
            }
            Console.WriteLine(parent.ToString());
            for (Nodo child : hijos)
            {
                if (child != null)
                {
                    child.print(level + 1);
                }
            }
    } */

        public void PrintParserAnalysis(ParserResultModel lrm)
        {
            Console.WriteLine("Resultado de analisis lexico!");
            Console.WriteLine("*********************************************");
            if (lrm.Errors.Count()>0)
            {

                Console.WriteLine("*********************************************");
                Console.WriteLine("Errores de sintaxis reconocidos!");
                Console.WriteLine("*********************************************");
                Console.WriteLine("Mensaje\tLinea\tColumna");
                foreach (var i in lrm.Errors)
                {
                    Console.WriteLine(i.getMessage() + "\t" + i.getLine() + "\t" +  i.getCharPositionInLine());
                }
            }
            else
            {
                Console.WriteLine("*********************************************");
                Console.WriteLine("Sin errores analisis correcto!");
                Console.WriteLine("*********************************************");
            }
        }
    }
}
