
using CompilerINT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerINT.Helpers
{
    public interface IFileHelper
    {
        FileElement OpenFile();
        FileElement SaveFile(FileElement fe);
    }
}
