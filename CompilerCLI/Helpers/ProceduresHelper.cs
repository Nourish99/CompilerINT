using Antlr4.Runtime;
using CompilerCLI.ANTLR4Files;
using CompilerCLI.Models;
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
        //public void Print
    }
}
