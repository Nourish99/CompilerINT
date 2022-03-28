using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using CompilerCLI.Models;

namespace CompilerCLI.Helpers
{
    public class TokenStreamExporter
    {
        public List<TokenItem> Results;
        public List<TokenItem> Errors;

        public TokenStreamExporter(){
            Results = new List<TokenItem>();
            Errors = new List<TokenItem>();
        }
        public TokenStreamExporter(List<TokenItem> Res, List<TokenItem> Errs){
            Results = Res;
            Errors = Errs;
        }

        public void ExportLexerResults(string dirPath){
            
            if(File.Exists(dirPath+"res.csv")){
                File.Delete(dirPath+"res.csv");
            }
            using (StreamWriter file = File.CreateText((dirPath+"res.json")))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, Results);
            }
            if(File.Exists(dirPath+"errs.csv")){
                File.Delete(dirPath+"errs.csv");
            }
            using (StreamWriter file = File.CreateText((dirPath+"errs.json")))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, Errors);
            }

        }
        public void ExportLexerResultsCSV(string dirPath){
            StringBuilder ResultsCSV = new StringBuilder();
            StringBuilder ErrorsCSV = new StringBuilder();
            //saving results
            Console.WriteLine("RResultados");
            /*
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = true,
                Comment = '#',
                AllowComments = true,
                Delimiter = ","
            };
            
            Console.WriteLine(Results.Count);
            //prueba
            using(var writter = new StreamWriter(dirPath+"res.csv"))
            using(var csvWritter = new CsvWriter(writter, csvConfig)){
                csvWritter.WriteHeader<TokenItem>();
                csvWritter.NextRecord();
                csvWritter.WriteRecords(Results);
            }
            */
            if(File.Exists(dirPath+"res.csv")){
                File.Delete(dirPath+"res.csv");
            }

            ResultsCSV.AppendLine(string.Format("N°,TOKEN,DESCRIPCION,LINEA,COLUMNA"));
            File.WriteAllText((dirPath+"res.csv"),ResultsCSV.ToString());
            File.AppendAllText((dirPath+"res.csv"),ResultsCSV.ToString());
            int i = 1;
            foreach (var item in Results)
            {
                //Console.WriteLine(item.ToString());
                var newLine = $"{i},{item.TokenName},{item.TokenDesc},{item.TokenLine},{item.TokenCol}";
                ResultsCSV.AppendLine(newLine);
            }
            File.WriteAllText((dirPath+"res.csv"),ResultsCSV.ToString());


            if(File.Exists(dirPath+"errs.csv")){
                File.Delete(dirPath+"errs.csv");
            }
            Console.WriteLine("ERRORES");
            ErrorsCSV.AppendLine(string.Format("N°,TOKEN,DESCRIPCION,LINEA,COLUMNA"));
            i=1;
            foreach (var item in Errors)
            {
               var newLine = $"{i},{item.TokenName},{item.TokenDesc},{item.TokenLine},{item.TokenCol}";
                ErrorsCSV.AppendLine(newLine);
                //Console.WriteLine(item.ToString());
            }
            File.WriteAllText((dirPath+"errs.csv"),ErrorsCSV.ToString());
           
/*
            */
        }
    }
}