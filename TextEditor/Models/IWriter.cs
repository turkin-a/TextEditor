using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Models
{
    interface IWriter : IDisposable
    {
        public void WriteLine(string line);
    }
}
