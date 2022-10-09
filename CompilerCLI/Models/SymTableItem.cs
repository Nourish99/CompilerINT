using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerCLI.Models
{
    public class SymTableItem
    {
        public string Identifier { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }
        public int Col { get; set; }
        public int Line { get; set; }
    }
}
