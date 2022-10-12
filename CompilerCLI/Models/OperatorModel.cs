using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerCLI.Models
{
    public class OperatorModel
    {
        public string Symbol { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }
}
