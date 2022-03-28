using System;
namespace CompilerCLI.Models
{
    public class TokenItem{
        public string TokenName {get; set;}
        public string TokenDesc {get;set;}
        public int TokenLine {get;set;}
        public int TokenCol {get;set;}
        public int TokenColor {get;set;}
    }
}