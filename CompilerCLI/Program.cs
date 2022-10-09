using System;
using Antlr4.Runtime;
using System.Collections.Generic;
using CompilerCLI.Models;
using CompilerCLI.Helpers;
using CompilerCLI.ANTLR4Files;
using System.IO;
using System.Diagnostics;
using Antlr.Runtime.Tree;
using Antlr4.Runtime.Tree;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Collections;
using System.Linq;

namespace CompilerCLI
{
    public class Program
    {
        
        static void Main(string[] args)
        {
#if DEBUG
            //args = new[] {"-h"};
            //args = new[] { "-v","busca|elemento", "C:\\Users\\amaur\\Documents\\Compiladores I\\Actividades\\Tarea4\\primero.txt", "C:\\Users\\amaur\\Documents\\Compiladores I\\Actividades\\Tarea4\\segundo.txt" };
            args = new[] { "C:\\Users\\amaur\\Documents\\tn.txt",  "-pa", "/OD","C:\\Users\\amaur\\Documents\\Compiladores I\\PRUEBA" };

#endif

            string inputfile = null;
            string outputDir = null;
            bool showFiles = false;
            
            
            inputfile = args[0];

            var ph = new ProceduresHelper();

            for (var i = 1; i < args.Length; ++i)
            {
                switch (args[i])
                {
                    case "/OD":
                        if (args.Length - 1 == i) // check if we're at the end
                            throw new ArgumentException(string.Format
                            ("The parameter \"{0}\" is missing an argument", args[i].Substring(1)));
                        ++i; // advance 
                        outputDir = args[i];
                        break;
                    case "/SF":
                        if (args.Length - 1 == i) // check if we're at the end
                            throw new ArgumentException(string.Format
                            ("The parameter \"{0}\" is missing an argument", args[i].Substring(1)));
                        ++i; // advance 
                        showFiles = true;
                        break;
                    
                    //default:
                        //throw new ArgumentException(string.Format("Unknown switch {0}", args[i]));
                }
            }
            for (var i = 1; i < args.Length; ++i)
            {
                switch (args[i])
                {
                    case "-la":
                        if (args.Length - 1 == i) // check if we're at the end
                            throw new ArgumentException(string.Format
                            ("The parameter \"{0}\" is missing an argument", args[i].Substring(1)));
                        //realizar analisis lexico
                        var lexr = ph.GetLexerAnalisis(inputfile,outputDir);
                        ph.PrintLexerAnalysis(lexr);
                        break;
                    case "-pa":
                        if (args.Length - 1 == i) // check if we're at the end
                            throw new ArgumentException(string.Format
                            ("The parameter \"{0}\" is missing an argument", args[i].Substring(1)));
                        //realizar analisis lexico
                        var pars = ph.GetParserAnalisis(inputfile, outputDir);
                        ph.PrintParserAnalysis(pars);
                        Console.WriteLine(printSyntaxTree(pars.parss, pars.treeCST));
                        break;
                }
            }





        }

        public static string printSyntaxTree(List<string> rules, IParseTree root)
        {
            StringBuilder buf = new StringBuilder();
            try
            {
                recursive(root, buf, 0, rules);
                return buf.ToString();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }

        private static void recursive(IParseTree aRoot, StringBuilder buf, int offset, List<string> ruleNames)
        {
            for (int i = 0; i < offset; i++)
            {
                buf.Append(" ");
            }
            buf.Append(Trees.GetNodeText(aRoot, ruleNames)).Append("\n");
            if (typeof(ParserRuleContext).IsInstanceOfType(aRoot))
            {
                ParserRuleContext prc = (ParserRuleContext)aRoot;
                if (prc.children != null)
                {
                    foreach (IParseTree child in prc.children)
                    {
                        recursive(child, buf, offset + 1, ruleNames);
                    }
                }
            }

            
            /*if (aRoot.GetType() == typeof(ParserRuleContext)) {
                ParserRuleContext prc = (ParserRuleContext)aRoot;
               
            }*/
        }


    }
}
