using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Models
{
    interface IReader : IDisposable
    {
        public bool ReadNextLine(ref string line);
    }
}
