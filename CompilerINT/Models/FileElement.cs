using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerINT.Models
{
    public class FileElement
    {
        public string? FilePath { get; set; }
        public string? FileContent { get; set; }
        public string? NewFileChanges { get; set; }
        public bool IsNewFile { get; set; }
        public bool FileSaved { get; set; }
    }
}
