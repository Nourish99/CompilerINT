package codigo;

import com.google.gson.Gson;

import java.io.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.FileSystems;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Formatter;
import java.util.Map;

public class Principal {

    private static String outputDir;
    private static boolean showFiles;
    private static String inputFile;
    public static void main(String[] args) {
        //C:\Users\amaur\source\repos\CompilerINT\CompilerInJava\src\codigo
        String path = "C:\\Users\\amaur\\source\\repos\\CompilerINT\\CompilerInJava\\src\\codigo\\Lexer.flex";
        String path2 = "C:\\Users\\amaur\\source\\repos\\CompilerINT\\CompilerInJava\\src\\codigo\\sintax\\LexerCup.flex";
        String[] rutass = {"-parser", "Sintax", "C:\\Users\\amaur\\source\\repos\\CompilerINT\\CompilerInJava\\src\\codigo\\sintax\\Sintax.cup"};
        try{
            GenerateConfigurationFiles(path, path2, rutass);

        }catch (Exception e){
            System.out.println(e);
        }

        //MakeLexerAnalysis("" ,"");
        //args = new String[] { "C:\\Users\\amaur\\Documents\\tn.txt",  "-la", "/OD","C:\\Users\\amaur\\Documents\\wuuu" };
        //EvaluateArgs(args);
    }

    public static void EvaluateArgs(String[] args){
        inputFile = args[0];
        for (int i = 1; i < args.length; ++i)
        {
            switch (args[i])
            {
                case "/OD":
                    if (args.length - 1 == i) // check if we're at the end
                        throw new IllegalArgumentException(String.format
                                ("The parameter \"{0}\" is missing an argument", args[i].substring(1)));
                    ++i; // advance
                    outputDir = args[i];
                    break;
                case "/SF":
                    if (args.length - 1 == i) // check if we're at the end
                        throw new IllegalArgumentException(String.format
                                ("The parameter \"{0}\" is missing an argument", args[i].substring(1)));
                    ++i; // advance
                    showFiles = true;
                    break;

                //default:
                //throw new ArgumentException(string.Format("Unknown switch {0}", args[i]));
            }
        }

        for (int i = 1; i < args.length; ++i)
        {
            switch (args[i])
            {
                case "-la":
                    if (args.length - 1 == i) // check if we're at the end
                        throw new IllegalArgumentException(String.format
                                ("The parameter \"{0}\" is missing an argument", args[i].substring(1)));
                    //realizar analisis lexico
//                    var lexr = ph.GetLexerAnalisis(inputfile,outputDir);
//                    ph.PrintLexerAnalysis(lexr);
                    MakeLexerAnalysis(inputFile, "");
                    break;
                case "-pa":
                    if (args.length - 1 == i) // check if we're at the end
                        throw new IllegalArgumentException(String.format
                                ("The parameter \"{0}\" is missing an argument w", args[i].substring(1)));
                    //realizar analisis lexico
//                    var pars = ph.GetParserAnalisis(inputfile, outputDir);
//                    ph.PrintParserAnalysis(pars);
                    break;
            }
        }
    }

    public static void GenerateConfigurationFiles(String path, String path2, String[] rutass) throws Exception {
        File file ;
        java_cup.Main.main(rutass);
        file = new File(path);
        JFlex.Main.generate(file);
        file = new File(path2);
        JFlex.Main.generate(file);
        //C:\Users\amaur\source\repos\CompilerINT\CompilerInJava\src\codigo

        Path rutaSym = Paths.get("C:/Users/amaur/source/repos/CompilerINT/CompilerInJava/src/codigo/sintax/sym.java");
        if(Files.exists(rutaSym)){
            Files.delete(rutaSym);
        }
        Files.move(
                Paths.get("C:/Users/amaur/source/repos/CompilerINT/CompilerInJava/sym.java"),
                Paths.get("C:/Users/amaur/source/repos/CompilerINT/CompilerInJava/src/codigo/sintax/sym.java"));

        Path rutaSin = Paths.get("C:/Users/amaur/source/repos/CompilerINT/CompilerInJava/src/codigo/sintax/Sintax.java");
        if(Files.exists(rutaSin)){
            Files.delete(rutaSin);
        }
        Files.move(
                Paths.get("C:/Users/amaur/source/repos/CompilerINT/CompilerInJava/Sintax.java"),
                Paths.get("C:/Users/amaur/source/repos/CompilerINT/CompilerInJava/src/codigo/sintax/Sintax.java"));
    }

    public static void MakeLexerAnalysis(String path, String text ) {

        if (outputDir == null || outputDir.isEmpty()) {
            outputDir = FileSystems.getDefault().getPath("").toAbsolutePath().toString() + "\\results";
        }
        File directory = new File(outputDir);
        if (!directory.exists()) {
            directory.mkdir();
        }
        String resultsFile = outputDir + "\\LexicalResults.json";
        String errorsFile = outputDir + "\\LexicalErrors.json";

        Reader reading = null;
        try {
            if (!path.isEmpty()) {
                reading = new BufferedReader(new FileReader(path));
            } else if (!text.isEmpty()) {
                String tmpFile = outputDir + "\\TMP_FILE.txt";
                byte data[] = text.getBytes(StandardCharsets.UTF_8);
                FileOutputStream out = new FileOutputStream(tmpFile);
                out.write(data);
                out.close();
                reading = new BufferedReader(new FileReader(tmpFile));
            } else {
                //nothing to do
                System.out.println("Nada que analizar ");
            }
            Lexer lexer = new Lexer(reading);
            int numL = 0;
            TokenTitleConverter converter = new TokenTitleConverter();
            Map<Tokens, String> map = converter.getMap();
            Formatter fmtR = new Formatter();
            fmtR.format("%20s %50s %10s %10s \n", "Lexema", "Descripcion","Linea","Columna");
            Formatter fmtE = new Formatter();
            fmtE.format("%20s %50s %10s %10s \n", "Lexema", "Descripcion","Linea","Columna");
            ArrayList<LexerResult> LexerResults = new ArrayList<LexerResult>();
            ArrayList<LexerResult> LexerErrors = new ArrayList<LexerResult>();

            while (true) {
                Tokens tokens = lexer.yylex();
                if (tokens == null) {
                    System.out.println("Analisis Lexico Completado!");
                    System.out.println("Resultados");
                    System.out.println("*******************************************************************************************************************");
                    System.out.println(fmtR);
                    System.out.println("Errores");
                    System.out.println("*******************************************************************************************************************");
                    System.out.println(fmtE);
                    SaveFile(resultsFile, LexerResults);
                    SaveFile(errorsFile, LexerErrors);
                    return;
                }
                numL++;
                int line = lexer.line + 1;
                int column = lexer.column + 1;
                String desc ="";
                switch (tokens) {
                    case ERROR:
                        desc="\"Simbolo no definido en el lexema \"" + map.get(tokens);
                        fmtE.format("%20s %50s %10d %10d \n", lexer.lexeme, desc,line,column);
                        LexerErrors.add(new LexerResult(lexer.lexeme,  desc,line,column));
                        break;
                    case Reserved:
                        desc="Es una palabra " + map.get(tokens);
                        break;
                    case Add:
                    case Substract:
                    case Multiply:
                    case Divide:
                    case Pow:
                    case Assign:
                        desc ="Es un operador (" + map.get(tokens);
                        break;
                    case CommentBlock:
                        desc = "Es un" + map.get(tokens);
                        break;
                    case SingleComment:
                        desc = "Es un" + map.get(tokens);
                        break;
                    case Identifier:
                    case Number:
                        desc = "Es un " + map.get(tokens);
                        break;
                    case LT:
                    case LTEquals:
                    case GT:
                    case GTEquals:
                    case Equals:
                    case NEquals:
                        desc = "Es un comparador (\"" + map.get(tokens) + "\")";
                        break;
                    default:
                        desc = "Es un caracter especialr (\"" + map.get(tokens) + "\")";

                        break;
                }
                if(tokens != Tokens.ERROR){
                    LexerResults.add(new LexerResult(lexer.lexeme,  desc, line,column));
                    fmtR.format("%20s %50s %10d %10d \n", lexer.lexeme, desc,line,column);
                }
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static void MakeParserAnalysis(){

    }

    public static void SaveFile(String Path,  ArrayList<LexerResult> list){
        try {
            Gson gson = new Gson();
            String content = gson.toJson(list);
           //File f = new File(Path);
            if ( new File(Path)!=null) {
                try (FileWriter writer = new FileWriter(new File(Path))) {
                    writer.write(content);
                    //JOptionPane.showMessageDialog(rootPane, "Archivo actualizado");
                }
            }
        } catch (IOException ex) {
            //JOptionPane.showMessageDialog(this, ex.getMessage());
            System.out.println(ex);
        }
    }
}
