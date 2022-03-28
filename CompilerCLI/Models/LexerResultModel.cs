using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerCLI.Models
{
    public class LexerResultModel
    {
        public List<TokenItem> Results { get; set; }
        public List<TokenItem> Errorrs { get; set; }
    }
}
