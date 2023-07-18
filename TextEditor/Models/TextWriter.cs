using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.Models
{
    public class TextWriter : IWriter
    {
        StreamWriter _writer;
        public TextWriter(string fileName)
        {
            _writer = new StreamWriter(fileName, false, Encoding.Default);
        }
        public void WriteString(string line)
        {
            _writer.Write(line);
        }
        public void Dispose()
        {
            _writer.Dispose();
        }
    }
}
